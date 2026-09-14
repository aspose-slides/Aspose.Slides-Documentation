---
title: Compare Presentation Slides in Python
linktitle: Compare Slides
type: docs
weight: 50
url: /python-java/compare-slides/
keywords:
- compare slides
- slide comparison
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Compare PowerPoint and OpenDocument presentations programmatically with Aspose.Slides for Python via Java. Identify slide differences in code quickly."
---

## **Overview**

Aspose.Slides allows you to compare slides, layout slides, and master slides using the [equals](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#equals) method provided by the [BaseSlide](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/) class. This method returns `True` when the compared slides are identical in their structure and static content.

## **Compare Two Slides**

The [equals](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#equals) method in the [BaseSlide](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/) class returns `True` for slides, layout slides, and master slides that are identical in structure and static content.

Two slides are equal if all their shapes, styles, text, animations, and other settings are equal. The comparison does not take into account unique identifier values, such as slide IDs, or dynamic content, such as the current date in a date placeholder.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

source_presentation = Presentation("AccessSlides.pptx")
try:
    target_presentation = Presentation("HelloWorld.pptx")
    try:
        for i in range(source_presentation.getMasters().size()):
            for j in range(target_presentation.getMasters().size()):
                if source_presentation.getMasters().get_Item(i).equals(target_presentation.getMasters().get_Item(j)):
                    print(f"AccessSlides MasterSlide#{i} is equal to HelloWorld MasterSlide#{j}")
    finally:
        target_presentation.dispose()
finally:
    source_presentation.dispose()
```

## **FAQ**

**Does the fact that a slide is hidden affect the comparison of the slides themselves?**

[Hidden status](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getHidden) is a presentation/playback-level property, not visual content. The equality of two specific slides is determined by their structure and static content; the mere fact that a slide is hidden does not make the slides different.

**Are hyperlinks and their parameters taken into account?**

Yes. Links are part of a slide’s static content. If the URL or the hyperlink action differs, this is usually treated as a difference in static content.

**If a chart refers to an external Excel file, will the contents of that file be taken into account?**

No. The comparison is performed based on the slides themselves. External data sources are generally not read at comparison time; only what is present in the slide’s structure and static state is considered.
