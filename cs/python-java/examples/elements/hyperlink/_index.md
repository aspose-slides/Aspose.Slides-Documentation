---
title: Hyperodkaz
type: docs
weight: 130
url: /cs/python-java/examples/elements/hyperlink/
keywords:
- ukázka kódu
- hyperodkaz
- přidat hyperodkaz
- přístup k hyperodkazu
- odebrat hyperodkaz
- aktualizovat hyperodkaz
- PowerPoint
- OpenDocument
- prezentace
- Python
- Java
- Aspose.Slides
description: "Přidávejte a spravujte hyperodlinky v Aspose.Slides pro Python via Java: vytvářejte, získávejte, odstraňujte a aktualizujte odkazy v prezentacích PPT, PPTX a ODP."
---
Tento článek ukazuje přidávání, získávání, odstraňování a aktualizaci hyperodkazů na tvarech pomocí **Aspose.Slides for Python via Java**.

Nainstalujte balíček podle popisu v [Instalace](/slides/cs/python-java/installation/). Každý příklad importuje `asposeslides` před spuštěním JVM a poté importuje API po spuštění JVM.

## **Přidat hyperodkaz**

Vytvořte obdélníkový tvar s hyperodkazem směřujícím na externí webovou stránku.

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

## **Získat hyperodkaz**

Přečtěte informace o hyperodkazu z textové části tvaru.

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

## **Odebrat hyperodkaz**

Odstraňte hyperodkaz z textu tvaru.

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

## **Aktualizovat hyperodkaz**

Změňte cíl existujícího hyperodkazu. Použijte [HyperlinkManager](https://reference.aspose.com/slides/cs/python-java/aspose.slides/hyperlinkmanager/) k úpravě textu, který již obsahuje hyperodkaz, což napodobuje způsob, jakým PowerPoint bezpečně aktualizuje hyperodlinky.

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

    # Změna hyperodkazu v existujícím textu by měla být provedena pomocí
    # HyperlinkManageru namísto přímého nastavení vlastnosti.
    # Toto napodobuje, jak PowerPoint bezpečně aktualizuje hyperodkazy.
    text_portion.getPortionFormat().getHyperlinkManager().setExternalHyperlinkClick("https://new.example.com")
finally:
    presentation.dispose()
```