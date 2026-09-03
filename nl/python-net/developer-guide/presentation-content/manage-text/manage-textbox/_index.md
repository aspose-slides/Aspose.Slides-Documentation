---
title: "Beheer tekstvakken in presentaties met Python"
linktitle: "Beheer tekstvak"
type: docs
weight: 20
url: /nl/python-net/manage-textbox/
keywords:
- "tekstvak"
- "tekstframe"
- "tekst toevoegen"
- "tekst bijwerken"
- "tekstvak maken"
- "tekstvak controleren"
- "tekstkolom toevoegen"
- "hyperlink toevoegen"
- "PowerPoint"
- "presentatie"
- "Python"
- "Aspose.Slides"
description: "Maak, identificeer, formatteer en werk tekstvakken bij in PowerPoint- en OpenDocument-presentaties met Aspose.Slides voor Python via .NET."
---
## **Introductie**

In Aspose.Slides for Python via .NET wordt de tekst van een dia opgeslagen in tekstframes die bij vormen horen. De [AutoShape](https://reference.aspose.com/slides/nl/python-net/aspose.slides/autoshape/) klasse vertegenwoordigt de meest voorkomende tekstdragende vorm en maakt haar tekst beschikbaar via de [AutoShape.text_frame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/autoshape/text_frame/) eigenschap.

{{% alert color="info" title="Note" %}}

Elke auto‑vorm erft van [Shape](https://reference.aspose.com/slides/nl/python-net/aspose.slides/shape/), maar niet elke vorm is een auto‑vorm of ondersteunt een tekstframe. Bij het verwerken van een bestaande presentatie, gebruik `isinstance(shape, slides.AutoShape)` om het type vorm te controleren voordat u de tekst benadert.

{{% /alert %}}

## **Een tekstvak op een dia maken**

Om een tekstvak te maken, voegt u een auto‑vorm toe aan een dia, voegt u tekst toe aan het tekstframe en slaat u de presentatie op. Het volgende voorbeeld maakt een rechthoekig tekstvak:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    text_box = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 75, 300, 50)
    text_box.add_text_frame("Aspose TextBox")

    presentation.save("TextBox.pptx", slides.export.SaveFormat.PPTX)
```

De coördinaten en afmetingen die worden doorgegeven aan [ShapeCollection.add_auto_shape](https://reference.aspose.com/slides/nl/python-net/aspose.slides/shapecollection/add_auto_shape/) worden gemeten in punten. [AutoShape.add_text_frame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/autoshape/add_text_frame/) initialiseert het tekstframe met de opgegeven tekst.

## **Controleren op een tekstvak‑vorm**

Gebruik de eigenschap [AutoShape.is_text_box](https://reference.aspose.com/slides/nl/python-net/aspose.slides/autoshape/is_text_box/) om te bepalen of een auto‑vorm als een tekstvak wordt beschouwd. Dit is nuttig wanneer een presentatie zowel tekstdragende als louter grafische auto‑vormen bevat.

![A text box and a shape](istextbox.png)

Het volgende voorbeeld inspecteert elke auto‑vorm in een presentatie:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    text_box = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 120, 40)
    text_box.add_text_frame("Text box")
    slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 150, 10, 40, 40)

    for current_slide in presentation.slides:
        for shape in current_slide.shapes:
            if isinstance(shape, slides.AutoShape):
                print("The shape is a text box." if shape.is_text_box else "The shape is not a text box.")
```

Een nieuw toegevoegde auto‑vorm wordt niet gezien als een tekstvak totdat deze niet‑leeg tekst bevat. U kunt die tekst leveren via [AutoShape.add_text_frame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/autoshape/add_text_frame/) of [TextFrame.text](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textframe/text/). Het toevoegen of toewijzen van een lege tekenreeks laat [is_text_box](https://reference.aspose.com/slides/nl/python-net/aspose.slides/autoshape/is_text_box/) op `False` staan:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 40)
    shape1.add_text_frame("Shape 1")
    print(shape1.is_text_box)

    shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 70, 100, 40)
    shape2.text_frame.text = "Shape 2"
    print(shape2.is_text_box)

    shape3 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 130, 100, 40)
    shape3.add_text_frame("")
    print(shape3.is_text_box)

    shape4 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 190, 100, 40)
    shape4.text_frame.text = ""
    print(shape4.is_text_box)
```

De eerste twee oproepen geven `True` weer; de laatste twee geven `False` weer.

## **De vorm vinden die een tekstframe bezit**

Generieke tekstverwerkingscode kan een [TextFrame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textframe/) ontvangen zonder te weten welk presentatiesobject het bevat. Gebruik de alleen‑lezen [TextFrame.parent_shape](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textframe/parent_shape/) eigenschap om terug te navigeren naar de bijbehorende [Shape](https://reference.aspose.com/slides/nl/python-net/aspose.slides/shape/).

Voor een tekstframe dat eigendom is van een auto‑vorm of een andere tekstdragende vorm, bevat [parent_shape](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textframe/parent_shape/) de eigenaar en is [TextFrame.parent_cell](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textframe/parent_cell/) `None`. Controleer de geretourneerde waarde voordat u deze benadert. Om zowel vorm‑ als tabelcellaandelen te identificeren, inclusief vormen die aan SmartArt‑knooppunten zijn gekoppeld, zie [Zoek en vervang tekst](/slides/nl/python-net/search-and-replace-text/).

## **Kolommen toevoegen aan een tekstvak**

De eigenschap [TextFrameFormat.column_count](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textframeformat/column_count/) verdeelt het tekstframe in kolommen, terwijl [TextFrameFormat.column_spacing](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textframeformat/column_spacing/) de tussenruimte tussen kolommen in punten instelt. Beide instellingen behoren tot [TextFrameFormat](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textframeformat/) en kunnen worden gewijzigd via het tekstframe van een bestaand tekstvak. Tekst wordt opnieuw verdeeld tussen kolommen binnen dezelfde vorm; hij gaat niet door naar een andere vorm.

Het volgende voorbeeld maakt een tekstvak met drie kolommen en 10 punten tussen de kolommen, slaat de presentatie op en leest de opgeslagen instellingen terug uit het uitvoerbestand:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    text_box = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 300, 200)
    text_box.add_text_frame("This text is distributed automatically across all columns in the text box.")

    text_frame_format = text_box.text_frame.text_frame_format
    text_frame_format.column_count = 3
    text_frame_format.column_spacing = 10

    presentation.save("TextBoxColumns.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("TextBoxColumns.pptx") as saved_presentation:
    saved_text_box = saved_presentation.slides[0].shapes[0]
    if isinstance(saved_text_box, slides.AutoShape):
        saved_format = saved_text_box.text_frame.text_frame_format
        print(f"Columns: {saved_format.column_count}; spacing: {saved_format.column_spacing} points")
```

## **Tekst extraheren uit individuele kolommen**

Gebruik [TextFrame.split_text_by_columns](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textframe/split_text_by_columns/) om de tekst op te halen die aan elke visuele kolom in een bestaand tekstframe is toegewezen. De methode retourneert één tekenreeks per kolom, in kolomgebaseerde leesvolgorde. Een tekstframe met één kolom levert een lijst met één element op, en een lege kolom wordt weergegeven door een lege tekenreeks. De tekenreeksen bevatten alleen platte tekst; op‑gedeelte‑niveau opmaak wordt niet behouden.

Dit is nuttig wanneer u wilt:

- Tekst extraheren terwijl de kolomgebaseerde leesvolgorde behouden blijft.
- De inhoud van dia's met meerdere kolommen indexeren of vergelijken.
- Elke kolom exporteren naar een apart bestand, databaseveld of andere bestemming.
- Controleren hoe tekst wordt herverdeeld na het wijzigen van [TextFrameFormat.column_count](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textframeformat/column_count/), [TextFrameFormat.column_spacing](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textframeformat/column_spacing/), het lettertype of de grootte van het tekstframe.

De methode geeft de tekst weer die binnen het huidige [TextFrame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textframe/) is verdeeld; hij laat tekst niet automatisch van de ene vorm of tekstvak naar de andere vloeien. De kolomverdeling kan afhankelijk zijn van beschikbare lettertypen en andere tekst‑layoutinstellingen, dus zorg ervoor dat de benodigde lettertypen beschikbaar zijn wanneer consistente resultaten belangrijk zijn.

Het volgende voorbeeld laadt een presentatie, zoekt de eerste auto‑vorm met meerdere kolommen en een tekstframe, leest het geconfigureerde aantal kolommen en schrijft de tekst van elke kolom naar een apart bestand. Vormen die geen tekstframe bieden, worden overgeslagen.

```python
import aspose.slides as slides

with slides.Presentation("MultiColumnText.pptx") as presentation:
    text_box = None
    for shape in presentation.slides[0].shapes:
        if isinstance(shape, slides.AutoShape) and shape.text_frame is not None:
            column_count = shape.text_frame.text_frame_format.column_count
            if column_count > 1:
                text_box = shape
                break

    if text_box is None:
        print("No multi-column text frame was found.")
    else:
        text_frame = text_box.text_frame
        configured_column_count = text_frame.text_frame_format.column_count
        column_texts = text_frame.split_text_by_columns()

        print(f"Configured columns: {configured_column_count}")

        for column_number, column_text in enumerate(column_texts, start=1):
            print(f"Column {column_number}: {column_text}")
            with open(f"Column-{column_number}.txt", "w", encoding="utf-8") as column_file:
                column_file.write(column_text)
```

## **Tekst bijwerken**

Om tekst in een hele presentatie bij te werken, doorloopt u de dia's en vormen, selecteert u auto‑vormen en bewerkt u vervolgens hun tekstgedeelten. Werken op het gedeelte‑niveau stelt u in staat zowel de tekst als de karakteropmaak te wijzigen.

Het volgende voorbeeld vervangt elke voorkomen van `years` door `months` in auto‑shape‑tekst en maakt elk getroffen gedeelte vet:

```python
import aspose.slides as slides

with slides.Presentation("Text.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if not isinstance(shape, slides.AutoShape) or shape.text_frame is None:
                continue

            for paragraph in shape.text_frame.paragraphs:
                for portion in paragraph.portions:
                    if "years" in portion.text:
                        portion.text = portion.text.replace("years", "months")
                        portion.portion_format.font_bold = slides.NullableBool.TRUE

    presentation.save("TextChanged.pptx", slides.export.SaveFormat.PPTX)
```

Deze doorloop werkt alleen tekst bij in auto‑vormen. Tekst opgeslagen in tabellen, grafieken, SmartArt of gegroepeerde vormen vereist een doorloop van de respectieve collecties van die objecten.

## **Een tekstvak met een hyperlink toevoegen**

Een hyperlink kan worden toegewezen aan een specifiek tekstgedeelte, zodat alleen die tekst als klikbare link fungeert. Gebruik [HyperlinkManager.set_external_hyperlink_click](https://reference.aspose.com/slides/nl/python-net/aspose.slides/hyperlinkmanager/set_external_hyperlink_click/) om het gedeelte te koppelen aan een externe URL.

Het volgende voorbeeld maakt gekoppelde tekst aan en slaat deze op in een presentatie:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    text_box = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 150, 200, 50)
    text_box.add_text_frame("Aspose.Slides")

    text_portion = text_box.text_frame.paragraphs[0].portions[0]
    text_portion.portion_format.hyperlink_manager.set_external_hyperlink_click("https://www.aspose.com/")

    presentation.save("Hyperlink.pptx", slides.export.SaveFormat.PPTX)
```

## **Veelgestelde vragen**

**Wat is het verschil tussen een tekstvak en een tekst‑placeholder op een master‑ of lay‑outdia?**

Een placeholder kan zijn positie en opmaak overnemen van een [master slide](https://reference.aspose.com/slides/nl/python-net/aspose.slides/masterslide/) of [layout slide](https://reference.aspose.com/slides/nl/python-net/aspose.slides/layoutslide/). Een regulier tekstvak is een onafhankelijke vorm op de dia waarop het is aangemaakt en krijgt geen placeholder‑gedrag wanneer de lay‑out verandert.

**Hoe kan ik tekst vervangen zonder de tekst in grafieken, tabellen of SmartArt te wijzigen?**

Beperk de doorloop tot [AutoShape](https://reference.aspose.com/slides/nl/python-net/aspose.slides/autoshape/) instanties, zoals getoond in het voorbeeld Tekst bijwerken. Grafieken, tabellen en SmartArt slaan tekst op in hun eigen objectmodellen, waardoor ze niet worden gewijzigd door die lus.