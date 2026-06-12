---
title: Beheer OLE in presentaties met Python
linktitle: Beheer OLE
type: docs
weight: 40
url: /nl/python-net/manage-ole/
keywords:
- OLE-object
- Objectkoppeling & insluiting
- OLE toevoegen
- OLE insluiten
- object toevoegen
- object insluiten
- bestand toevoegen
- bestand insluiten
- gelinkt object
- gelinkt bestand
- OLE wijzigen
- OLE-pictogram
- OLE-titel
- OLE extraheren
- object extraheren
- bestand extraheren
- PowerPoint
- presentatie
- Python
- Aspose.Slides
description: "Optimaliseer het beheer van OLE-objecten in PowerPoint- en OpenDocument-bestanden met Aspose.Slides for Python via .NET. Voeg OLE-inhoud in, werk deze bij en exporteer deze moeiteloos."
---
## **Inleiding**

{{% alert title="Info" color="info" %}}

**OLE (Object Linking & Embedding)** is een Microsoft‑technologie die het mogelijk maakt data en objecten die in een toepassing zijn gemaakt, te koppelen of in te sluiten in een andere.

{{% /alert %}}

Een diagram dat in Microsoft Excel is gemaakt en op een PowerPoint‑dia wordt geplaatst, is een OLE‑object.

- Een OLE‑object kan verschijnen als een pictogram. Door te dubbelklikken op het pictogram wordt het object geopend in de bijbehorende toepassing (bijv. Excel) of krijgt u de mogelijkheid om een applicatie te kiezen om het te openen of te bewerken.
- Een OLE‑object kan zijn inhoud weergeven (bijvoorbeeld een diagram). In dat geval activeert PowerPoint het ingesloten object, laadt de diagraminterface en stelt u in staat de diagramgegevens te bewerken binnen PowerPoint.

Aspose.Slides for Python stelt u in staat OLE‑objecten in dia's in te voegen als OLE‑objectframes ([OleObjectFrame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/oleobjectframe/)).

## **OLE‑objecten toevoegen aan dia’s**

Als u al een diagram in Microsoft Excel heeft gemaakt en dit als OLE‑objectframe in een dia wilt insluiten met Aspose.Slides for Python, volg dan deze stappen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/)‑klasse.
1. Verkrijg een referentie naar de dia op basis van de index.
1. Lees het Excel‑bestand in als byte‑array.
1. Voeg een [OleObjectFrame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/oleobjectframe/) toe aan de dia, waarbij u het byte‑array en andere OLE‑objectdetails opgeeft.
1. Sla de gewijzigde presentatie op als een PPTX‑bestand.

In het voorbeeld hieronder wordt een diagram uit een Excel‑bestand ingesloten in een dia als een [OleObjectFrame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/oleobjectframe/).

**Opmerking:** De constructor van [OleEmbeddedDataInfo](https://reference.aspose.com/slides/nl/python-net/aspose.slides.dom.ole/oleembeddeddatainfo/) neemt de bestandsextensie van het in te sluiten object als tweede parameter. PowerPoint gebruikt deze extensie om het bestandstype te identificeren en de juiste toepassing te selecteren om het OLE‑object te openen.

```py
with slides.Presentation() as presentation:
    slide_size = presentation.slide_size.size
    slide = presentation.slides[0]

    # Bereid de data voor het OLE-object voor.
    with open("book.xlsx", "rb") as file_stream:
        file_data = file_stream.read()
        data_info = slides.dom.ole.OleEmbeddedDataInfo(file_data, "xlsx")

    # Voeg een OLE-objectframe toe aan de dia.
    ole_frame = slide.shapes.add_ole_object_frame(0, 0, slide_size.width, slide_size.height, data_info)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

### **Gelinkte OLE‑objecten toevoegen**

Aspose.Slides for Python stelt u in staat een [OleObjectFrame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/oleobjectframe/) toe te voegen die naar een bestand linkt in plaats van de gegevens in te sluiten.

Het volgende Python‑voorbeeld toont hoe u een [OleObjectFrame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/oleobjectframe/) kunt toevoegen dat gelinkt is aan een Excel‑bestand op een dia:

```py
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Voeg een OLE-objectframe toe met een gekoppeld Excel-bestand.
    slide.shapes.add_ole_object_frame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx")

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **OLE‑objecten benaderen**

Als een OLE‑object al is ingesloten in een dia, kunt u het als volgt benaderen:

1. Laad de presentatie die het ingesloten OLE‑object bevat door een instantie van de Presentation‑klasse te maken.
1. Verkrijg een referentie naar de dia op basis van de index.
1. Benader de OleObjectFrame‑shape.
1. Zodra u het OLE‑objectframe heeft, kunt u de gewenste bewerkingen uitvoeren.

Het voorbeeld hieronder benadert het OLE‑objectframe — een ingesloten Excel‑diagram — en haalt de bestandsgegevens op. In dit voorbeeld gebruiken we een PPTX met één enkele shape op de eerste dia.

```py
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    if isinstance(shape, slides.OleObjectFrame):
        ole_frame = shape

        # Haal de ingesloten bestandsgegevens op.
        file_data = ole_frame.embedded_data.embedded_file_data

        # Haal de extensie van het ingesloten bestand op.
        file_extension = ole_frame.embedded_data.embedded_file_extension

        # ...
```

### **Eigenschappen van gelinkte OLE‑objecten benaderen**

Aspose.Slides stelt u in staat de eigenschappen van een gelinkt OLE‑objectframe te benaderen.

Het onderstaande Python‑voorbeeld controleert of een OLE‑object gelinkt is en, zo ja, haalt het pad naar het gelinkte bestand op:

```py
with slides.Presentation("sample.ppt") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    if isinstance(shape, slides.OleObjectFrame):
        ole_frame = shape

        # Controleer of het OLE-object gelinkt is.
        if ole_frame.is_object_link:
            # Print het volledige pad naar het gelinkte bestand.
            print("OLE object frame is linked to:", ole_frame.link_path_long)

            # Print het relatieve pad naar het gelinkte bestand, indien aanwezig.
            # Alleen .ppt-presentaties kunnen een relatief pad bevatten.
            if ole_frame.link_path_relative:
                print("OLE object frame relative path:", ole_frame.link_path_relative)
```

## **OLE‑objectgegevens wijzigen**

{{% alert color="primary" %}}

In dit gedeelte gebruikt het onderstaande code‑voorbeeld Aspose.Cells for Python via .NET.

{{% /alert %}}

Als een OLE‑object al is ingesloten in een dia, kunt u het benaderen en de gegevens wijzigen als volgt:

1. Laad de presentatie door een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/)‑klasse te maken.
1. Verkrijg de doel‑dia op basis van de index.
1. Benader de [OleObjectFrame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/oleobjectframe/)‑shape.
1. Zodra u het OLE‑objectframe heeft, voert u de benodigde bewerkingen uit.
1. Maak een `Workbook`‑object aan en lees de OLE‑gegevens.
1. Open het gewenste `Worksheet` en bewerk de gegevens.
1. Sla het bijgewerkte `Workbook` op naar een stream.
1. Vervang de OLE‑objectgegevens met behulp van die stream.

In het voorbeeld hieronder wordt een OLE‑objectframe (een ingesloten Excel‑diagram) benaderd en worden de bestandsgegevens aangepast om het diagram bij te werken. Het voorbeeld maakt gebruik van een eerder gemaakte PPTX die één enkele shape bevat op de eerste dia.

```py
import io
import aspose.slides as slides
import aspose.cells as cells

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    if isinstance(shape, slides.OleObjectFrame):
        ole_frame = shape

        with io.BytesIO(ole_frame.embedded_data.embedded_file_data) as ole_stream:
            # Lees de OLE-objectgegevens als een Workbook-object.
            workbook = cells.Workbook(ole_stream)

        with io.BytesIO() as new_ole_stream:
            # Pas de workbook-gegevens aan.
            workbook.worksheets.get(0).cells.get(0, 4).put_value("E")
            workbook.worksheets.get(0).cells.get(1, 4).put_value(12)
            workbook.worksheets.get(0).cells.get(2, 4).put_value(14)
            workbook.worksheets.get(0).cells.get(3, 4).put_value(15)

            file_options = cells.OoxmlSaveOptions(cells.SaveFormat.XLSX)
            workbook.save(new_ole_stream, file_options)

            # Wijzig de OLE-frame-objectgegevens.
            new_data = slides.dom.ole.OleEmbeddedDataInfo(new_ole_stream.getvalue(), ole_frame.embedded_data.embedded_file_extension)
            ole_frame.set_embedded_data(new_data)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Bestanden insluiten in dia’s**

Naast Excel‑diagrammen maakt Aspose.Slides for Python het mogelijk andere bestandstypen in dia's in te sluiten. U kunt bijvoorbeeld HTML‑, PDF‑ en ZIP‑bestanden als objecten invoegen. Wanneer een gebruiker dubbelklikt op een ingevoegd object, wordt dit automatisch geopend in de bijbehorende toepassing, of krijgt de gebruiker de mogelijkheid om een geschikt programma te kiezen.

Deze Python‑code laat zien hoe u HTML‑ en ZIP‑bestanden in een dia kunt insluiten:

```py
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("sample.html", "rb") as html_stream:
        html_data = html_stream.read()

    html_data_info = slides.dom.ole.OleEmbeddedDataInfo(html_data, "html")
    html_ole_frame = slide.shapes.add_ole_object_frame(150, 120, 50, 50, html_data_info)
    html_ole_frame.is_object_icon = True

    with open("sample.zip", "rb") as zip_stream:
        zip_data = zip_stream.read()

    zip_data_info = slides.dom.ole.OleEmbeddedDataInfo(zip_data, "zip")
    zip_ole_frame = slide.shapes.add_ole_object_frame(150, 220, 50, 50, zip_data_info)
    zip_ole_frame.is_object_icon = True

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Bestandstypen voor ingesloten objecten instellen**

Bij het werken met presentaties kan het nodig zijn oude OLE‑objecten te vervangen door nieuwe, of een niet‑ondersteund OLE‑object te ruilen voor een ondersteund. Aspose.Slides for Python laat u het bestandstype van een ingesloten object instellen, zodat u de OLE‑frame‑gegevens of de bestandsextensie kunt bijwerken.

Deze Python‑code laat zien hoe u het bestandstype van het ingesloten OLE‑object op `zip` instelt:

```py
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    ole_frame = slide.shapes[0]

    file_extension = ole_frame.embedded_data.embedded_file_extension
    file_data = ole_frame.embedded_data.embedded_file_data

    print(f"Current embedded file extension is: {file_extension}")

    # Wijzig het bestandstype naar ZIP.
    ole_frame.set_embedded_data(slides.dom.ole.OleEmbeddedDataInfo(file_data, "zip"))

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Pictogramafbeeldingen en titels voor ingesloten objecten instellen**

Nadat u een OLE‑object heeft ingesloten, wordt er automatisch een pictogram‑preview toegevoegd. Deze preview is wat gebruikers zien voordat ze het OLE‑object benaderen of openen. Als u een specifieke afbeelding en tekst in de preview wilt gebruiken, kunt u de pictogramafbeelding en titel instellen via Aspose.Slides for Python.

Deze Python‑code laat zien hoe u de pictogramafbeelding en titel voor een ingesloten object instelt:

```py
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    ole_frame = slide.shapes[0]

    # Voeg een afbeelding toe aan de presentatiebronnen.
    with slides.Images.from_file("image.png") as image:
        ole_image = presentation.images.add_image(image)

    # Stel een titel en de afbeelding in voor de OLE‑preview.
    ole_frame.substitute_picture_title = "My title"
    ole_frame.substitute_picture_format.picture.image = ole_image
    ole_frame.is_object_icon = True

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Voorkom dat OLE‑objectframes worden geschaald en verplaatst**

Nadat u een gelinkt OLE‑object aan een dia hebt toegevoegd, kan PowerPoint u bij het openen van de presentatie vragen de koppelingen bij te werken. Het kiezen van ‘Update Links’ kan de grootte en positie van het OLE‑objectframe wijzigen omdat PowerPoint de preview ververst met gegevens uit het gelinkte object. Om te voorkomen dat PowerPoint u vraagt de objectgegevens bij te werken, stelt u de `update_automatic`‑eigenschap van de [OleObjectFrame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/oleobjectframe/)‑klasse in op `False`:

```py
ole_frame.update_automatic = False
```

## **Ingesloten bestanden extraheren**

Aspose.Slides for Python laat u bestanden die in dia's als OLE‑objecten zijn ingesloten als volgt extraheren:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/)‑klasse die de OLE‑objecten bevat die u wilt extraheren.
1. Doorloop alle shapes in de presentatie en zoek de OleObjectFrame‑shapes.
1. Haal de ingesloten bestandsgegevens op uit elke [OLEObjectFrame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/oleobjectframe/) en schrijf ze naar schijf.

De volgende Python‑code laat zien hoe u bestanden die in een dia als OLE‑objecten zijn ingesloten, kunt extraheren:

```py
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    for index, shape in enumerate(slide.shapes):
        if isinstance(shape, slides.OleObjectFrame):
            ole_frame = shape

            file_data = ole_frame.embedded_data.embedded_file_data
            file_extension = ole_frame.embedded_data.embedded_file_extension

            file_path = f"OLE_object_{index}{file_extension}"
            with open(file_path, 'wb') as file_stream:
                file_stream.write(file_data)
```

## **FAQ**

**Wordt de OLE‑inhoud gerenderd bij het exporteren van dia's naar PDF/afbeeldingen?**

Wat op de dia zichtbaar is, wordt gerenderd — het pictogram/vervangende beeld (preview). De “live” OLE‑inhoud wordt niet uitgevoerd tijdens het renderen. Indien nodig, stel een eigen preview‑afbeelding in om het verwachte uiterlijk in de geëxporteerde PDF te garanderen.

**Hoe kan ik een OLE‑object op een dia vergrendelen zodat gebruikers het niet kunnen verplaatsen/bewerken in PowerPoint?**

Vergrendel de shape: Aspose.Slides biedt [shape‑level locks](/slides/nl/python-net/applying-protection-to-presentation/). Dit is geen versleuteling, maar voorkomt effectief onbedoelde bewerkingen en verplaatsingen.

**Waarom springt een gelinkt Excel‑object of verandert van grootte wanneer ik de presentatie open?**

PowerPoint kan de preview van het gelinkte OLE verversen. Voor een stabiele weergave volgt u de praktijken van de [Working Solution for Worksheet Resizing](/slides/nl/python-net/working-solution-for-worksheet-resizing/) — pas het frame aan op het bereik, of schaal het bereik naar een vast frame en stel een passend vervangend beeld in.

**Worden relatieve paden voor gelinkte OLE‑objecten bewaard in het PPTX‑formaat?**

In PPTX is informatie over “relatieve paden” niet beschikbaar — alleen het volledige pad. Relatieve paden bestaan in het oudere PPT‑formaat. Voor draagbaarheid heeft u de voorkeur aan betrouwbare absolute paden/toegankelijke URI’s of aan insluitingen.