---
title: Customize Doughnut Charts in Presentations Using С++
linktitle: Doughnut Chart
type: docs
weight: 30
url: /cpp/doughnut-chart/
keywords:
- doughnut chart
- center gap
- hole size
- PowerPoint
- presentation
- С++
- Aspose.Slides
description: "Discover how to create and customize doughnut charts in Aspose.Slides for С++, supporting PowerPoint formats for dynamic presentations."
---

## **Specify the Center Gap in a Doughnut Chart**
In order to specify the size of the hole in a doughnut chart. Please follow the steps below:

- Instantiate [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) class.
- Add doughnut chart on the slide.
- Specify the size of the hole in a doughnut chart.
- Write presentation to disk.

In the example given below, we have set the size of the hole in a doughnut chart.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-DoughnutChartHole-DoughnutChartHole.cpp" >}}

## **FAQ**

**Can I create a multi-level doughnut with multiple rings?**

Yes. Add multiple series to a single doughnut chart—each series becomes a separate ring. The ring order is determined by the order of the series in the collection.

**Is an "exploded" doughnut (separated slices) supported?**

Yes. There is an Exploded Doughnut [chart type](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/) and an explosion property on data points; you can separate individual slices.

**How can I get an image of a doughnut chart (PNG/SVG) for a report?**

A chart is a shape; you can render it to a [raster image](https://reference.aspose.com/slides/cpp/aspose.slides/shape/getimage/) or export the chart to an [SVG image](https://reference.aspose.com/slides/cpp/aspose.slides/shape/writeassvg/).
