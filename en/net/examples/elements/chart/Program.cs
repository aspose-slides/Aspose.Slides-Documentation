using System;
using System.Linq;
using System.Threading.Tasks;
using Aspose.Slides;
using Aspose.Slides.Charts;

internal static partial class Program
{
    public static Task<int> Main(string[] args) => ExampleBootstrap.RunAsync(args, context =>
    {
        string? selected = null;
        if (context.Arguments.Length != 0)
        {
            context.Prerequisite(
                context.Arguments.Length == 2 && context.Arguments[0] == "--action",
                "Use --action block-001, or omit it to run all cases.");
            selected = context.Arguments[1];
        }

        var cases = new (string Id, Action<ISlide> Run, string Check, Func<ISlide, bool> Verify)[]
        {
            ("block-001", Case01, "AddChart",
                slide => slide.Shapes.OfType<IChart>().Single().Type == ChartType.Area),
            ("block-002", Case02, "AccessChart",
                slide => slide.Shapes.OfType<IChart>().Single().Type == ChartType.Line),
            ("block-003", Case03, "RemoveChart",
                slide => !slide.Shapes.OfType<IChart>().Any()),
            ("block-004", Case04, "UpdateChartData",
                slide => slide.Shapes.OfType<IChart>().Single()
                    .ChartTitle.TextFrameForOverriding.Text == "Sales")
        };

        context.Prerequisite(
            selected == null || cases.Any(item => item.Id == selected),
            "Unknown action. Use one of: " + string.Join(", ", cases.Select(item => item.Id)));
        foreach (var item in cases.Where(item => selected == null || item.Id == selected))
        {
            var actionId = "elements/chart/" + item.Id;
            context.BeginAction(actionId);
            using var presentation = new Presentation();
            item.Run(presentation.Slides[0]);
            ChartVerification.SaveAndVerify(context, presentation, item.Id, item.Check, item.Verify);
            context.Pass(actionId, item.Check, "save-reopen-structure");
        }
        return Task.CompletedTask;
    });
}
