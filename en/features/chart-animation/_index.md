---
title: Animate charts
description: Animate chart content by series, category or individual elements.
type: docs
url: /features/chart-animation/
weight: 1040
feature_id: chart-animation
feature_group: charts
translationKey: slides-feature-chart-animation
feature_catalogue_version: 3
feature_guides:
- /slides/net/animated-charts/
---

## **Overview**

Add animation effects to chart elements to control how data is introduced during a presentation. Target series or categories, and choose the timing and triggers for their effects. The chart remains editable alongside its animation instructions.

## **Usage example**

This C# example uses Aspose.Slides for .NET. Create Sales and Target series and add click-triggered appearance effects for series indices 0 and 1. The saved presentation stores the sequence for a compatible slideshow. The PNG is a static chart preview; it does not demonstrate the animation or create a video. No input file is needed. It saves *chart-animation.pptx* and *chart-animation.png*. Install the library using the [installation guide](/slides/net/installation/).

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;
using Aspose.Slides.Animation;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 40, 40, 620, 350);
chart.HasTitle = false;
chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();
var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);
var firstCategory = workbook.GetCell(0, 1, 0, "North");
var secondCategory = workbook.GetCell(0, 2, 0, "South");
chart.ChartData.Categories.Add(firstCategory);
chart.ChartData.Categories.Add(secondCategory);
var nameCell = workbook.GetCell(0, 0, 1, "Sales");
var series = chart.ChartData.Series.Add(nameCell, chart.Type);
var firstValue = workbook.GetCell(0, 1, 1, 20);
var secondValue = workbook.GetCell(0, 2, 1, 40);
series.DataPoints.AddDataPointForBarSeries(firstValue);
series.DataPoints.AddDataPointForBarSeries(secondValue);
var secondName = workbook.GetCell(0, 0, 2, "Target");
var secondSeries = chart.ChartData.Series.Add(secondName, chart.Type);
var targetNorth = workbook.GetCell(0, 1, 2, 30);
var targetSouth = workbook.GetCell(0, 2, 2, 45);
secondSeries.DataPoints.AddDataPointForBarSeries(targetNorth);
secondSeries.DataPoints.AddDataPointForBarSeries(targetSouth);
var sequence = (Sequence)slide.Timeline.MainSequence;
sequence.AddEffect(chart, EffectChartMajorGroupingType.BySeries, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.OnClick);
sequence.AddEffect(chart, EffectChartMajorGroupingType.BySeries, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.OnClick);
presentation.Save("chart-animation.pptx", SaveFormat.Pptx);
using var image = presentation.Slides[0].GetImage(1f, 1f);
image.Save("chart-animation.png", ImageFormat.Png);
```

## **FAQ**

### **Can each category appear on a separate click?**

Yes. Assign click-triggered effects to the category elements when that is the sequence you want in the presentation.

### **Can I animate a chart by series rather than as one shape?**

Yes. Target a series index in the chart animation sequence, as in the sample. Use category or individual-element grouping when that matches the desired presentation.

### **How can I inspect the animation effects already attached to a chart?**

Inspect the slide's main and interactive sequences, selecting effects whose target is the chart. Read their type, grouping and timing before editing them.

## **Guides**

- [Animate PowerPoint Charts in .NET](/slides/net/animated-charts/)

Related feature: [Set animation order and timing](/slides/features/animation-timing/).
