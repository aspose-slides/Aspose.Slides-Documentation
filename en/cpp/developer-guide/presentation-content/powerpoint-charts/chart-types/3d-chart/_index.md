---
title: Customize 3D Charts in Presentations Using С++
linktitle: 3D Chart
type: docs
url: /cpp/3d-chart/
keywords:
- 3D chart
- rotation
- depth
- PowerPoint
- presentation
- С++
- Aspose.Slides
description: "Learn how to create and customize 3-D charts in Aspose.Slides for С++, with support for PPT and PPTX files—boost your presentations today."
---

## **Set RotationX, RotationY and DepthPercents Properties of a 3D Chart**
Aspose.Slides for C++ provides a simple API for setting these properties. This following article will help you how set different properties like X,Y Rotation , **DepthPercents** etc. The sample code applies setting the above said properties.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) class.
1. Access first slide.
1. Add chart with default data.
1. Set Rotation3D properties.
1. Write the modified presentation to a PPTX file.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ManagePropertiesCharts-ManagePropertiesCharts.cpp" >}}

## **FAQ**

**Which chart types support 3D mode in Aspose.Slides?**

Aspose.Slides supports 3D variants of column charts, including Column 3D, Clustered Column 3D, Stacked Column 3D, and 100% Stacked Column 3D, along with related 3D types exposed through the [ChartType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/) enumeration. For an exact, up-to-date list, check the [ChartType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/) members in the API reference of your installed version.

**Can I get a raster image of a 3D chart for a report or the web?**

Yes. You can export a chart to an image via the [chart API](https://reference.aspose.com/slides/cpp/aspose.slides/shape/getimage/) or [render the entire slide](/slides/cpp/convert-powerpoint-to-png/) to formats like PNG or JPEG. This is useful when you need a pixel-perfect preview or want to embed the chart into documents, dashboards, or web pages without requiring PowerPoint.

**How performant is building and rendering large 3D charts?**

Performance depends on data volume and visual complexity. For best results, keep 3D effects minimal, avoid heavy textures on walls and plot areas, limit the number of data points per series when possible, and render to an appropriately sized output (resolution and dimensions) to match the target display or print needs.
