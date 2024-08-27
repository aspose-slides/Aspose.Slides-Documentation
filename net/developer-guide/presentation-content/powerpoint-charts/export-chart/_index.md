---
title: Export Chart
type: docs
weight: 90
url: /net/export-chart/
keywords:
- chart
- chart image
- extract chart image
- PowerPoint
- presentation
- C#
- Csharp
- Aspose.Slides for .NET
description: "Get chart images from PowerPoint presentations in C# or .NET"
---

## **Get Chart Image**
Aspose.Slides for .NET provides support for extracting image of specific chart. Below sample example is given. 

```c#
using (Presentation presentation = new Presentation("test.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    using (IImage image = chart.GetImage())
    {
        image.Save("image.png", ImageFormat.Png);
    }
}
```
