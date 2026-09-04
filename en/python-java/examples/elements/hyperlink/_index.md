---
title: Hyperlink
type: docs
weight: 130
url: /python-java/examples/elements/hyperlink/
keywords:
- code example
- hyperlink
- add hyperlink
- access hyperlink
- remove hyperlink
- update hyperlink
- PowerPoint
- OpenDocument
- presentation
- Python
- Java
- Aspose.Slides
description: "Add and manage hyperlinks in Aspose.Slides for Python via Java: create, access, remove, and update links in PPT, PPTX, and ODP presentations."
---

This article demonstrates adding, accessing, removing, and updating hyperlinks on shapes using **Aspose.Slides for Python via Java**.

Install the package as described in [Installation](/slides/python-java/installation/). Each example imports `asposeslides` before starting the JVM, then imports the API after the JVM is running.

## **Add a Hyperlink**

Create a rectangle shape with a hyperlink pointing to an external website.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50)
    shape.getTextFrame().setText("Aspose")

    paragraph = shape.getTextFrame().getParagraphs().get_Item(0)
    text_portion = paragraph.getPortions().get_Item(0)
    text_portion.getPortionFormat().setHyperlinkClick(Hyperlink("https://www.aspose.com"))
finally:
    presentation.dispose()
```

## **Access a Hyperlink**

Read hyperlink information from a shape's text portion.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50)
    shape.getTextFrame().setText("Aspose")

    paragraph = shape.getTextFrame().getParagraphs().get_Item(0)
    text_portion = paragraph.getPortions().get_Item(0)
    text_portion.getPortionFormat().setHyperlinkClick(Hyperlink("https://www.aspose.com"))

    hyperlink = text_portion.getPortionFormat().getHyperlinkClick()
finally:
    presentation.dispose()
```

## **Remove a Hyperlink**

Clear the hyperlink from a shape's text.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50)
    shape.getTextFrame().setText("Aspose")

    paragraph = shape.getTextFrame().getParagraphs().get_Item(0)
    text_portion = paragraph.getPortions().get_Item(0)
    text_portion.getPortionFormat().setHyperlinkClick(Hyperlink("https://www.aspose.com"))

    text_portion.getPortionFormat().setHyperlinkClick(None)
finally:
    presentation.dispose()
```

## **Update a Hyperlink**

Change the target of an existing hyperlink. Use [HyperlinkManager](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkmanager/) to modify text that already contains a hyperlink, which mimics how PowerPoint updates hyperlinks safely.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50)
    shape.getTextFrame().setText("Aspose")

    paragraph = shape.getTextFrame().getParagraphs().get_Item(0)
    text_portion = paragraph.getPortions().get_Item(0)
    text_portion.getPortionFormat().setHyperlinkClick(Hyperlink("https://old.example.com"))

    # Changing a hyperlink inside existing text should be done via
    # HyperlinkManager rather than setting the property directly.
    # This mimics how PowerPoint safely updates hyperlinks.
    text_portion.getPortionFormat().getHyperlinkManager().setExternalHyperlinkClick("https://new.example.com")
finally:
    presentation.dispose()
```
