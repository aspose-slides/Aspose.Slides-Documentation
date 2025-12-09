---
title: Animate PowerPoint Charts in C++
linktitle: Animated Charts
type: docs
weight: 80
url: /cpp/animated-charts/
keywords:
- chart
- animated chart
- chart animation
- chart series
- chart category
- series element
- category element
- add effect
- effect type
- PowerPoint
- presentation
- C++
- Aspose.Slides
description: "Create stunning animated charts in C++ with Aspose.Slides. Boost presentations with dynamic visuals in PPT and PPTX files—get started now."
---


## **Chart Series Animation**
If you want to animate a chart series, write the code according to the steps listed below:

1. Load a presentation.
1. Get reference of the chart object.
1. Animate the series.
1. Write the presentation file to disk.

In the example given below, we animated chart series.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AnimatingSeries-AnimatingSeries.cpp" >}}

## **Animation in a Series Element**
If you want to animate series elements, write the code according to the steps listed below:

1. Load a presentation.
1. Get reference of the chart object.
1. Animate series elements.
1. Write the presentation file to disk.

In the example given below, we have animated series' elements.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AnimatingSeriesElements-AnimatingSeriesElements.cpp" >}}

## **Chart Category Animation**
If you want to animate a chart series, write the code according to the steps listed below:

1. Load a presentation.
1. Get reference of the chart object.
1. Animate the Category.
1. Write the presentation file to disk.

In the example given below, we animated chart category.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AnimatingSeries-AnimatingSeries.cpp" >}}

## **Animation in a Category Element**
If you want to animate categories elements, write the code according to the steps listed below:

1. Load a presentation.
1. Get reference of the chart object.
1. Animate categories elements.
1. Write the presentation file to disk.

In the example given below, we have animated categories elements.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AnimatingCategoriesElements-AnimatingCategoriesElements.cpp" >}}

## **FAQ**

**Are different effect types (e.g., entrance, emphasis, exit) supported for charts like for regular shapes?**

Yes. A chart is treated as a shape, so it supports the standard animation effect types, including entrance, emphasis, and exit, with full control via the slide's timeline and animation sequences.

**Can I combine chart animation with slide transitions?**

Yes. [Transitions](/slides/cpp/slide-transition/) apply to the slide, while animation effects apply to objects on the slide. You can use both together in the same presentation and control them independently.

**Are chart animations preserved when saving to PPTX?**

Yes. When you [save to PPTX](/slides/cpp/save-presentation/), all animation effects and their ordering are preserved because they are part of the presentation's native animation model.

**Can I read existing chart animations from a presentation and modify them?**

Yes. The [API](https://reference.aspose.com/slides/cpp/aspose.slides.animation/) provides access to the slide timeline, sequences, and effects, allowing you to inspect existing chart animations and adjust them without recreating everything from scratch.

**Can I produce a video that includes chart animations using Aspose.Slides?**

Yes. You can [export a presentation to video](/slides/cpp/convert-powerpoint-to-video/) while preserving animations, configuring timings and other export settings so the resulting clip reflects the animated playback.
