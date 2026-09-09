---
title: Beheer tekstvakken in presentaties met Python via Java
linktitle: Beheer tekstvak
type: docs
weight: 20
url: /nl/python-java/manage-textbox/
keywords:
- tekstvak
- tekstkader
- tekst toevoegen
- tekst bijwerken
- tekstvak maken
- tekstvak controleren
- tekstkolom toevoegen
- hyperlink toevoegen
- PowerPoint
- presentatie
- Python
- Java
- Aspose.Slides
description: "Maak, identificeer, formatteer en werk tekstvakken bij in PowerPoint- en OpenDocument-presentaties met Aspose.Slides voor Python via Java."
---
## **Inleiding**

In Aspose.Slides for Python via Java wordt de tekst van een dia opgeslagen in tekstkaders die behoren tot vormen. De AutoShape‑klasse vertegenwoordigt de meest voorkomende vorm met tekst en geeft de tekst beschikbaar via de AutoShape.getTextFrame‑methode.

{{% alert color="info" title="Note" %}}
Elke auto‑vorm erft van Shape, maar niet elke vorm is een auto‑vorm of ondersteunt een tekstkader. Wanneer u een bestaande presentatie verwerkt, controleer dan of een vorm een instantie is van AutoShape voordat u de tekst benadert.
{{% /alert %}}

## **Maak een tekstvak op een dia**

Om een tekstvak te maken, voegt u een auto‑vorm toe aan een dia, voegt u tekst toe aan het tekstkader en slaat u de presentatie op. Het volgende voorbeeld maakt een rechthoekig tekstvak:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    text_box = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 300, 50)
    text_box.addTextFrame("Aspose TextBox")

    presentation.save("TextBox.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

De coördinaten en afmetingen die aan ShapeCollection.addAutoShape worden doorgegeven, worden gemeten in punten. AutoShape.addTextFrame initialiseert het tekstkader met de opgegeven tekst.

## **Controleer op een tekstvakvorm**

Gebruik de AutoShape.isTextBox‑methode om te bepalen of een auto‑vorm wordt beschouwd als een tekstvak. Dit is nuttig wanneer een presentatie zowel tekstdragende als louter grafische auto‑vormen bevat.

![A text box and a shape](istextbox.png)

Het volgende voorbeeld inspecteert elke auto‑vorm in een presentatie:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    text_box = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 120, 40)
    text_box.addTextFrame("Text box")
    slide.getShapes().addAutoShape(ShapeType.Ellipse, 150, 10, 40, 40)

    for current_slide in presentation.getSlides():
        for shape in current_slide.getShapes():
            if isinstance(shape, AutoShape):
                print("The shape is a text box." if shape.isTextBox() else "The shape is not a text box.")
finally:
    presentation.dispose()
```

Een nieuw toegevoegde auto‑vorm wordt pas als tekstvak beschouwd zodra deze niet‑lege tekst bevat. U kunt die tekst leveren via AutoShape.addTextFrame of TextFrame.setText. Het toevoegen of toewijzen van een lege tekenreeks zorgt ervoor dat AutoShape.isTextBox `False` teruggeeft:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    added_text_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 40)
    added_text_shape.addTextFrame("Shape 1")
    print(added_text_shape.isTextBox())

    assigned_text_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 70, 100, 40)
    assigned_text_shape.getTextFrame().setText("Shape 2")
    print(assigned_text_shape.isTextBox())

    added_empty_text_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 130, 100, 40)
    added_empty_text_shape.addTextFrame("")
    print(added_empty_text_shape.isTextBox())

    assigned_empty_text_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 190, 100, 40)
    assigned_empty_text_shape.getTextFrame().setText("")
    print(assigned_empty_text_shape.isTextBox())
finally:
    presentation.dispose()
```

De eerste twee aanroepen geven `True` weer; de laatste twee geven `False` weer.

## **Zoek de vorm die een tekstkader bezit**

Generieke tekstverwerkingscode kan een TextFrame ontvangen zonder te weten welk presentatie‑object het bevat. Gebruik de alleen‑lezen TextFrame.getParentShape‑methode om terug te navigeren naar de bijbehorende Shape.

Voor een tekstkader dat eigendom is van een auto‑vorm of een andere tekstdragende vorm, geeft TextFrame.getParentShape de eigenaar terug en geeft TextFrame.getParentCell `None`. Controleer de geretourneerde waarde voordat u deze benadert. Om zowel vorm‑ als tabelcel‑eigenaren te identificeren, inclusief vormen die gekoppeld zijn aan SmartArt‑knopen, zie [Zoeken en vervangen van tekst](/slides/nl/python-java/search-and-replace-text/).

## **Kolommen toevoegen aan een tekstvak**

De TextFrameFormat.setColumnCount‑methode verdeelt het tekstkader in kolommen, terwijl TextFrameFormat.setColumnSpacing de ruimte tussen kolommen in punten instelt. Beide instellingen behoren tot TextFrameFormat en kunnen worden gewijzigd via het tekstkader van een bestaand tekstvak. Tekst vloeit tussen kolommen binnen dezelfde vorm; het gaat niet door naar een andere vorm.

Het volgende voorbeeld maakt een tekstvak met drie kolommen en 10 punten tussen de kolommen, slaat de presentatie op en leest de opgeslagen instellingen terug uit het uitvoerbestand:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    text_box = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 200)
    text_box.addTextFrame("This text is distributed automatically across all columns in the text box.")

    text_frame_format = text_box.getTextFrame().getTextFrameFormat()
    text_frame_format.setColumnCount(3)
    text_frame_format.setColumnSpacing(10)

    presentation.save("TextBoxColumns.pptx", SaveFormat.Pptx)

    saved_presentation = Presentation("TextBoxColumns.pptx")
    try:
        saved_text_box = saved_presentation.getSlides().get_Item(0).getShapes().get_Item(0)
        saved_format = saved_text_box.getTextFrame().getTextFrameFormat()
        print(f"Columns: {saved_format.getColumnCount()}; spacing: {saved_format.getColumnSpacing()} points")
    finally:
        saved_presentation.dispose()
finally:
    presentation.dispose()
```

## **Tekst extraheren uit individuele kolommen**

Gebruik TextFrame.splitTextByColumns om de tekst op te halen die aan elke visuele kolom in een bestaand tekstkader is toegewezen. De methode retourneert één tekenreeks per kolom, in kolomgebaseerde leesvolgorde. Een tekstkader met één kolom levert een array met één element op, en een lege kolom wordt weergegeven door een lege tekenreeks. De tekenreeksen bevatten alleen platte tekst; opmaak op portieniveau wordt niet behouden.

Dit is nuttig wanneer u wilt:

- Tekst extraheren terwijl de kolomgebaseerde leesvolgorde behouden blijft.
- De inhoud van dia's met meerdere kolommen indexeren of vergelijken.
- Elke kolom exporteren naar een apart bestand, databaseveld of andere bestemming.
- Inspecteren hoe tekst wordt herverdeeld na het wijzigen van het aantal kolommen met TextFrameFormat.setColumnCount, de tussenruimte met TextFrameFormat.setColumnSpacing, het lettertype of de grootte van het tekstkader.

De methode rapporteert de tekst die binnen het huidige TextFrame is verdeeld; ze laat tekst niet automatisch van de ene vorm naar de andere of van het ene tekstvak naar het andere vloeien. Kolomverdeling kan afhangen van beschikbare lettertypen en andere lay‑outinstellingen, dus zorg ervoor dat de vereiste lettertypen beschikbaar zijn wanneer consistente resultaten belangrijk zijn.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import AutoShape, Presentation

presentation = Presentation("MultiColumnText.pptx")
try:
    text_box = None
    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, AutoShape):
            if shape.getTextFrame() is not None:
                column_count = shape.getTextFrame().getTextFrameFormat().getColumnCount()
                if column_count > 1:
                    text_box = shape
                    break

    if text_box is None:
        print("No multi-column text frame was found.")
    else:
        text_frame = text_box.getTextFrame()
        configured_column_count = text_frame.getTextFrameFormat().getColumnCount()
        column_texts = text_frame.splitTextByColumns()

        print(f"Configured columns: {configured_column_count}")

        for column_number, column_text in enumerate(column_texts, start=1):
            print(f"Column {column_number}: {column_text}")
            output_path = Path(f"Column-{column_number}.txt")
            try:
                output_path.write_text(str(column_text), encoding="utf-8")
            except OSError as exception:
                print(f"Could not write column {column_number}: {exception}")
finally:
    presentation.dispose()
```

## **Tekst bijwerken**

Om tekst door de hele presentatie heen bij te werken, doorloopt u de dia's en vormen, selecteert u auto‑vormen en bewerkt u vervolgens hun tekstdelen. Werken op portieniveau laat u zowel tekst als tekenopmaak wijzigen.

Het volgende voorbeeld vervangt elke voorkoming van `years` door `months` in auto‑shape‑tekst en maakt elk getroffen deel vet:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, NullableBool, Presentation, SaveFormat

presentation = Presentation("Text.pptx")
try:
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if not isinstance(shape, AutoShape):
                continue

            text_frame = shape.getTextFrame()
            if text_frame is None:
                continue

            for paragraph in text_frame.getParagraphs():
                for portion in paragraph.getPortions():
                    text = portion.getText()
                    if text is not None and "years" in str(text):
                        portion.setText(str(text).replace("years", "months"))
                        portion.getPortionFormat().setFontBold(NullableBool.True_)

    presentation.save("TextChanged.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Deze doorloop werkt tekst alleen bij in auto‑vormen. Tekst die is opgeslagen in tabellen, grafieken, SmartArt of gegroepeerde vormen vereist een doorloop van de eigen verzamelingen van die objecten.

## **Een tekstvak met een hyperlink toevoegen**

Een hyperlink kan aan een specifiek tekstdeler worden toegewezen, zodat alleen die tekst als klikbare link fungeert. Gebruik HyperlinkManager.setExternalHyperlinkClick om de deler te koppelen aan een externe URL.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    text_box = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 200, 50)
    text_box.addTextFrame("Aspose.Slides")

    text_portion = text_box.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    text_portion.getPortionFormat().getHyperlinkManager().setExternalHyperlinkClick("https://www.aspose.com/")

    presentation.save("Hyperlink.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Wat is het verschil tussen een tekstvak en een tekst‑placeholder op een master‑ of layout‑dia?**

Een placeholder kan zijn positie en opmaak overnemen van een masterslide of layoutslide. Een gewoon tekstvak is een onafhankelijke vorm op de dia waarop het is aangemaakt en neemt geen placeholder‑gedrag over wanneer de lay‑out verandert.

**Hoe kan ik tekst vervangen zonder de tekst in grafieken, tabellen of SmartArt te wijzigen?**

Beperk de doorloop tot vormen die instanties zijn van AutoShape, zoals getoond in het voorbeeld Tekst bijwerken. Grafieken, tabellen en SmartArt slaan tekst op in hun eigen objectmodellen, dus die worden niet aangepast door die lus.