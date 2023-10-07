using Nuke.Common;
using Nuke.Common.Execution;
using ricaun.Nuke;
using ricaun.Nuke.Components;

class Build : NukeBuild, IPublishPack, ICompileExample, ITestLocal //, IBuildPackages
{
    string IHazExample.Name => "ricaun.Revit.DB.*";
    public static int Main() => Execute<Build>(x => x.From<IPublishPack>().Build);
}
