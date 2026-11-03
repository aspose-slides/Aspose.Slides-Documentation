using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using Aspose.Slides;
using Aspose.Slides.Charts;

internal static class Example
{
    public static ExampleContext Context = null!;
    public static void Setup()
    {
        Directory.CreateDirectory("output");
    }

    public static void Require(bool value, string message)
    {
        if (!value)
            throw new InvalidOperationException(message);
    }

    public static void Result(object checks)
    {
        File.WriteAllText("output/result.json", JsonSerializer.Serialize(new { checks }, new JsonSerializerOptions { WriteIndented = true }), new UTF8Encoding(false));
    }

    public static void Json(string path, object value)
    {
        File.WriteAllText(path, JsonSerializer.Serialize(value, new JsonSerializerOptions { WriteIndented = true }), new UTF8Encoding(false));
    }

    public static IEnumerable<IShape> Walk(IShapeCollection shapes)
    {
        foreach (IShape shape in shapes)
        {
            yield return shape;
            if (shape is IGroupShape group)
                foreach (var child in Walk(group.Shapes))
                    yield return child;
        }
    }

    public static IChart Chart(ISlide slide, string name)
    {
        var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 40, 130, 620, 290);
        chart.Name = name;
        return chart;
    }

    public static void ChartData(IChart chart, string[] categories, string[] series, double[][] values)
    {
        var data = chart.ChartData;
        var book = data.ChartDataWorkbook;
        data.Series.Clear();
        data.Categories.Clear();
        book.Clear(0);
        for (int r = 0; r < categories.Length; r++)
            data.Categories.Add(book.GetCell(0, r + 1, 0, categories[r]));
        for (int c = 0; c < series.Length; c++)
        {
            var item = data.Series.Add(book.GetCell(0, 0, c + 1, series[c]), ChartType.ClusteredColumn);
            for (int r = 0; r < categories.Length; r++)
                item.DataPoints.AddDataPointForBarSeries(book.GetCell(0, r + 1, c + 1, values[c][r]));
        }
    }
}
