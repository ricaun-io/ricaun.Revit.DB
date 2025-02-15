using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace ricaun.Revit.DB.Shape.Revit.Commands
{
    [Transaction(TransactionMode.Manual)]
    public class ShapeCommand : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elementSet)
        {
            UIApplication uiapp = commandData.Application;

            UIDocument uidoc = uiapp.ActiveUIDocument;
            Document document = uidoc.Document;

            using (Transaction transaction = new Transaction(document))
            {
                transaction.Start("DirectShape");

                document.DeleteDirectShape();

                var materialRed = MaterialUtils.CreateMaterialRed(document);
                var materialGreen = MaterialUtils.CreateMaterialGreen(document);
                var materialBlue = MaterialUtils.CreateMaterialBlue(document);
                var materialWhite = MaterialUtils.CreateMaterialWhite(document);
                var materialMagenta = MaterialUtils.CreateMaterial(document, Colors.Magenta);
                var materialYellow = MaterialUtils.CreateMaterial(document, Colors.Yellow);
                var materialCyan = MaterialUtils.CreateMaterial(document, Colors.Cyan);

                var scale = 0.5;

                var box = document.CreateDirectShape(ShapeCreator.CreateBox(XYZ.Zero, scale, materialId: materialRed.Id));
                box.Location.Move(-(2 * scale) * XYZ.BasisX);

                var sphere = document.CreateDirectShape(ShapeCreator.CreateSphere(XYZ.Zero, scale, materialId: materialGreen.Id));
                sphere.Location.Move(-(4 * scale) * XYZ.BasisX);

                var cylinder = document.CreateDirectShape(ShapeCreator.CreateCylinder(XYZ.Zero, scale, materialId: materialBlue.Id));
                cylinder.Location.Move(-(6 * scale) * XYZ.BasisX);

                var cone = document.CreateDirectShape(ShapeCreator.CreateCone(XYZ.Zero, scale, materialId: materialMagenta.Id));
                cone.Location.Move(-(8 * scale) * XYZ.BasisX);

                var prism = document.CreateDirectShape(ShapeCreator.CreatePrism(XYZ.Zero, scale, materialId: materialYellow.Id));
                prism.Location.Move(-(10 * scale) * XYZ.BasisX);

                var pyramid = document.CreateDirectShape(ShapeCreator.CreatePyramid(XYZ.Zero, scale, materialId: materialCyan.Id));
                pyramid.Location.Move(-(12 * scale) * XYZ.BasisX);

                var boxLines = document.CreateDirectShape(ShapeCreator.CreateBoxLines(XYZ.Zero, scale));
                boxLines.Location.Move(-(14 * scale) * XYZ.BasisX);

                var arrowAxis = new XYZ(-1, -1, -1);
                var arrow = document.CreateDirectShape(ShapeCreator.CreateArrow(arrowAxis, materialMagenta.Id));
                arrow.Location.Move(arrowAxis / 10);

                var gizmo = ShapeCreator.CreateGizmo(document);
                document.CreateDirectShape(gizmo);

                transaction.Commit();
            }

            return Result.Succeeded;
        }
    }

}
