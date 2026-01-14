---
title: Compare Presentation Slides in Python
linktitle: Compare Slides
type: docs
weight: 50
url: /python-net/compare-slides/
keywords:
- compare slides
- slide comparison
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Compare PowerPoint and OpenDocument presentations programmatically with Aspose.Slides for Python via .NET. Identify slide differences in code quickly."
---

## **Compare Two Slides**
The `equals` method has been added to the [BaseSlide](https://reference.aspose.com/slides/python-net/aspose.slides/baseslide/) class. It returns true for the slides/layout and slides/master slides which identical by its structure and static content.

Two slides are equal if all shapes, styles, texts, animation and other settings. etc. The comparison doesn't take into account unique identifier values, e.g. SlideId and dynamic content, e.g. current date value in Date Placeholder.

```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as p1:
    with slides.Presentation(path + "HelloWorld.pptx") as p2:
        for i in range(len(p1.masters)):
            for j in range(len(p2.masters)):
                if p1.masters[i] == p2.masters[j]:
                    print("Presentation1 MasterSlide#{0} is equal to Presentation2 MasterSlide#{1}".format(i,j))
```

## **FAQ**

**Does the fact that a slide is hidden affect the comparison of the slides themselves?**

[Hidden status](https://reference.aspose.com/slides/python-net/aspose.slides/slide/hidden/) is a presentation/playback-level property, not visual content. The equality of two specific slides is determined by their structure and static content; the mere fact that a slide is hidden does not make the slides different.

**Are hyperlinks and their parameters taken into account?**

Yes. Links are part of a slide’s static content. If the URL or the hyperlink action differs, this is usually treated as a difference in static content.

**If a chart refers to an external Excel file, will the contents of that file be taken into account?**

No. The comparison is performed based on the slides themselves. External data sources are generally not read at comparison time; only what is present in the slide’s structure and static state is considered.
