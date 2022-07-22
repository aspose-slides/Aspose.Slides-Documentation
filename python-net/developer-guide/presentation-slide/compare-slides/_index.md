---
title: Compare Slides
type: docs
weight: 50
url: /python-net/compare-slides/
keywords: "Compare PowerPoint slides, Compare two slides, Presentation, Python, Aspose.Slides"
description: "Compare PowerPoint presentation slides in Python"
---

## **Compare Two Slides**
Equals method has been added to [IBaseSlide](https://reference.aspose.com/slides/python-net/aspose.slides/ibaseslide/) interface and [BaseSlide](https://reference.aspose.com/slides/python-net/aspose.slides/baseslide/) class. It returns true for the slides/layout and slides/master slides which identical by its structure and static content.

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

