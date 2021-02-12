---
title: Compare Slides
type: docs
weight: 50
url: /java/compare-slides/
---

## **Compare Two Slides**
Equals method has been added to IBaseSlide interface and BaseSlide class. It returns true for the slides / layout slides / master slides which identical by its structure and static content. Two slides are equal if all shapes, styles, texts, animation and other settings. etc. are equal. The comparison doesn't take into account unique identifier values, e.g. SlideId and dynamic content, e.g. current date value in Date Placeholder.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Layout-CheckSlidesComparison-CheckSlidesComparison.java" >}}
