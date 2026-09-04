---
title: Hyperlink
type: docs
weight: 130
url: /de/python-java/examples/elements/hyperlink/
keywords:
- Codebeispiel
- Hyperlink
- Hyperlink hinzufügen
- Hyperlink abrufen
- Hyperlink entfernen
- Hyperlink aktualisieren
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Java
- Aspose.Slides
description: "Hyperlinks in Aspose.Slides for Python via Java hinzufügen und verwalten: Links in PPT-, PPTX- und ODP-Präsentationen erstellen, abrufen, entfernen und aktualisieren."
---
Dieser Artikel demonstriert das Hinzufügen, Zugreifen, Entfernen und Aktualisieren von Hyperlinks in Formen mithilfe von **Aspose.Slides for Python via Java**.

Installieren Sie das Paket wie in [Installation](/slides/de/python-java/installation/) beschrieben. Jeder Beispielcode importiert `asposeslides`, bevor die JVM gestartet wird, und importiert anschließend die API, nachdem die JVM läuft.

## **Hyperlink hinzufügen**

Erstellen Sie eine Rechteckform mit einem Hyperlink, der auf eine externe Website verweist.

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

## **Hyperlink abrufen**

Lesen Sie Hyperlink-Informationen aus dem Textteil einer Form.

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

## **Hyperlink entfernen**

Löschen Sie den Hyperlink aus dem Text einer Form.

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

## **Hyperlink aktualisieren**

Ändern Sie das Ziel eines bestehenden Hyperlinks. Verwenden Sie [HyperlinkManager](https://reference.aspose.com/slides/de/python-java/aspose.slides/hyperlinkmanager/), um Text, der bereits einen Hyperlink enthält, zu ändern, was dem sicheren Aktualisieren von Hyperlinks in PowerPoint entspricht.

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

    # Das Ändern eines Hyperlinks im bestehenden Text sollte über
    # HyperlinkManager erfolgen, anstatt die Eigenschaft direkt zu setzen.
    # Dies ahmt nach, wie PowerPoint Hyperlinks sicher aktualisiert.
    text_portion.getPortionFormat().getHyperlinkManager().setExternalHyperlinkClick("https://new.example.com")
finally:
    presentation.dispose()
```