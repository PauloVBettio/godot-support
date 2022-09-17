using JetBrains.Application.Processes;
using JetBrains.ProjectModel;
using JetBrains.RdBackend.Common.Features.Processes;
using JetBrains.Util;

namespace JetBrains.ReSharper.Plugins.Godot.UnitTesting
{
    [SolutionInstanceComponent]
    public class GodotRiderProcessStartInfoPatcher : RiderProcessStartInfoPatcher
    {
        public GodotRiderProcessStartInfoPatcher(ILogger logger, ISolutionToolset solutionToolset, RiderProcessStartInfoEnvironment environment) : base(logger, solutionToolset, environment)
        {
        }

        public override ProcessStartInfoPatchResult Patch(JetProcessStartInfo info, JetProcessRuntimeRequest request)
        {
            if (info.FileName.Contains("Godot"))
                return base.Patch(new JetProcessStartInfo(info.FileName, info.Arguments, info.WorkingDirectory, info.ToProcessStartInfo().Environment), JetProcessRuntimeRequest.CreateDirect(request.EnvironmentVariableMutator));
            return base.Patch(info, request);
        }
        
    }
}