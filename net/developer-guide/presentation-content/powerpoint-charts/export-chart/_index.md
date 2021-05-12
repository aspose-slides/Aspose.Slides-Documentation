---
title: Export Chart
type: docs
weight: 90
url: /net/export-chart/
---

## **Get Chart Image**
Aspose.Slides for .NET provides support for extracting image of specific chart. Below sample example is given. 

```c#
// The path to the documents directory.
string dataDir = RunExamples.GetDataDir_Charts();

using (Presentation pres = new Presentation(dataDir+"test.pptx"))
         {
         	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
          	Image img = chart.GetThumbnail();
          	img.Save(dataDir+"image.png", ImageFormat.Png);
}
```
