---
title: Compare Slides
type: docs
weight: 50
url: /net/compare-slides/
---

## **Compare Two Slides**
Equals method has been added to [IBaseSlide](https://apireference.aspose.com/net/slides/aspose.slides/ibaseslide) interface and [BaseSlide](https://apireference.aspose.com/net/slides/aspose.slides/baseslide) class. It returns true for the slides/layout and slides/master slides which identical by its structure and static content.

Two slides are equal if all shapes, styles, texts, animation and other settings. etc. The comparison doesn't take into account unique identifier values, e.g. SlideId and dynamic content, e.g. current date value in Date Placeholder.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Slides-Layout-CheckSlidesComparison-CheckSlidesComparison.cs" >}}
