---
title: Manage Callouts in Presentation Charts Using С++
linktitle: Callout
type: docs
url: /cpp/callout/
keywords:
- chart callout
- use callout
- data label
- label format
- PowerPoint
- presentation
- С++
- Aspose.Slides
description: "Create and style callouts in Aspose.Slides for С++ with concise code examples, compatible with PPT and PPTX to automate presentation workflows."
---

## **Using Callouts**
New property **ShowLabelAsDataCallout** has been added to **DataLabelFormat** class and **IDataLabelFormat** interface, which determines either specified chart's data label will be displayed as data callout or as data label. In the example given below, we have set the Callouts.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-DisplayChartLabels-DisplayChartLabels.cpp" >}}

## **Set a Callout for a Doughnut Chart**
Aspose.Slides for C++ provides support for setting series data label callout shape for a Doughnut chart. Below sample example is given.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddDoughnutCallout-AddDoughnutCallout.cpp" >}}

## **FAQ**

**Are callouts preserved when converting a presentation to PDF, HTML5, SVG, or images?**

Yes. Callouts are part of the chart rendering, so when you export to [PDF](/slides/cpp/convert-powerpoint-to-pdf/), [HTML5](/slides/cpp/export-to-html5/), [SVG](/slides/cpp/render-a-slide-as-an-svg-image/), or [raster images](/slides/cpp/convert-powerpoint-to-png/), they are preserved together with the slide’s formatting.

**Do custom fonts work in callouts, and can their appearance be preserved on export?**

Yes. Aspose.Slides supports [embedding fonts](/slides/cpp/embedded-font/) into the presentation and controls font embedding during exports such as [PDF](/slides/cpp/convert-powerpoint-to-pdf/), ensuring the callouts look the same across different systems.
