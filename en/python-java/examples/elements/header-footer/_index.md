---
title: Header Footer
type: docs
weight: 220
url: /python-java/examples/elements/header-footer/
keywords:
- code example
- header
- footer
- PowerPoint
- OpenDocument
- presentation
- Python
- Java
- Aspose.Slides
description: "Control slide headers and footers with Aspose.Slides for Python via Java: add dates, slide numbers, and custom text in PPT, PPTX, and ODP presentations."
---

This article demonstrates how to add footers and update date and time placeholders using **Aspose.Slides for Python via Java**.

Install the package as described in [Installation](/slides/python-java/installation/). Each example imports `asposeslides` before starting the JVM, then imports the API after the JVM is running.

## **Add a Footer**

Add text to the footer area of a slide and make it visible.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    slide.getHeaderFooterManager().setFooterText("My footer")
    slide.getHeaderFooterManager().setFooterVisibility(True)
finally:
    presentation.dispose()
```

## **Update Date and Time**

Modify the date and time placeholder on a slide.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    slide.getHeaderFooterManager().setDateTimeText("01/01/2024")
    slide.getHeaderFooterManager().setDateTimeVisibility(True)
finally:
    presentation.dispose()
```
