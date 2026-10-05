---
title: OLE beheren in presentaties met Python
linktitle: OLE beheren
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
description: "Optimaliseer het beheer van OLE-objecten in PowerPoint- en OpenDocument-bestanden met Aspose.Slides voor Python via .NET. Voeg OLE-inhoud in, werk deze bij en exporteer naadloos."
---
## **Introductie**

{{% alert color="info" title="Note" %}}

**OLE (Object Linking & Embedding)** is een Microsoft‑technologie die het mogelijk maakt gegevens en objecten die in één toepassing zijn gemaakt, te koppelen of in te sluiten in een andere.

{{% /alert %}}

Bijvoorbeeld, een grafiek die in Microsoft Excel is gemaakt en op een PowerPoint‑dia is geplaatst, is een OLE‑object.

- Een OLE‑object kan verschijnen als een pictogram. Dubbelklikken op het pictogram opent het object in de bijbehorende toepassing (bijv. Excel) of vraagt u een app te kiezen om het te openen of te bewerken.
- Een OLE‑object kan zijn inhoud tonen (bijvoorbeeld een grafiek). In dat geval activeert PowerPoint het ingesloten object, laadt de grafiekinterface en stelt u in staat de gegevens van de grafiek binnen PowerPoint te bewerken.

Aspose.Slides voor Python stelt u in staat OLE‑objecten in dia's in te voegen als OLE‑objectframes ([OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/)).

## **OLE‑objecten toevoegen aan dia's**

Als u al een grafiek in Microsoft Excel hebt gemaakt en deze in een dia wilt insluiten als OLE‑objectframe met Aspose.Slides voor Python, volg dan deze stappen:

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) aan.
1. Haal een referentie op naar de dia op basis van zijn index.
1. Lees het Excel‑bestand in een byte‑array.
1. Voeg een [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) toe aan de dia, waarbij u de byte‑array en andere OLE‑objectdetails opgeeft.
1. Sla de gewijzigde presentatie op als een PPTX‑bestand.

In het onderstaande voorbeeld wordt een grafiek uit een Excel‑bestand in een dia ingesloten als een [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/).

**Opmerking:** De constructor van [OleEmbeddedDataInfo](https://reference.aspose.com/slides/python-net/aspose.slides.dom.ole/oleembeddeddatainfo/) neemt de bestandsextensie van het in te sluiten object als tweede parameter. PowerPoint gebruikt deze extensie om het bestandstype te identificeren en de juiste toepassing te selecteren om het OLE‑object te openen.

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide_size = presentation.slide_size.size
    slide = presentation.slides[0]

    # Bereid de gegevens voor het OLE-object voor.
    with open("book.xlsx", "rb") as file_stream:
        file_data = file_stream.read()
        data_info = slides.dom.ole.OleEmbeddedDataInfo(file_data, "xlsx")

    # Voeg een OLE-objectframe toe aan de dia.
    ole_frame = slide.shapes.add_ole_object_frame(0, 0, slide_size.width, slide_size.height, data_info)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

### **Gelinkte OLE‑objecten toevoegen**

Aspose.Slides voor Python laat u een [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) toevoegen die naar een bestand koppelt in plaats van de gegevens in te sluiten.

Het volgende Python‑voorbeeld laat zien hoe u een [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) toevoegt die naar een Excel‑bestand op een dia linkt:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Voeg een OLE-objectframe toe met een gelinkte Excel‑file.
    slide.shapes.add_ole_object_frame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx")

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **OLE‑objecten benaderen**

Als een OLE‑object al in een dia is ingesloten, kunt u het als volgt benaderen:

1. Laad de presentatie die het ingesloten OLE‑object bevat door een instantie van de klasse Presentation te maken.
1. Haal een referentie op naar de dia op basis van zijn index.
1. Benader de OleObjectFrame‑vorm.
1. Zodra u het OLE‑objectframe hebt, voert u de benodigde bewerkingen uit.

Het onderstaande voorbeeld benadert het OLE‑objectframe — een ingesloten Excel‑grafiek — en haalt de bestandsgegevens op. In dit voorbeeld gebruiken we een PPTX met één vorm op de eerste dia.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    if isinstance(shape, slides.OleObjectFrame):
        ole_frame = shape

        # Haal de gegevens van het ingebedde bestand op.
        file_data = ole_frame.embedded_data.embedded_file_data

        # Haal de extensie van het ingebedde bestand op.
        file_extension = ole_frame.embedded_data.embedded_file_extension

        # ...
```

### **Eigenschappen van gelinkte OLE‑objecten benaderen**

Aspose.Slides stelt u in staat de eigenschappen van een gelinkt OLE‑objectframe te benaderen.

Het onderstaande Python‑voorbeeld controleert of een OLE‑object gelinkt is en, zo ja, haalt het pad naar het gelinkte bestand op:

```py
import aspose.slides as slides

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

{{% alert color="info" title="Note" %}}

In deze sectie gebruikt het onderstaande code‑voorbeeld [Aspose.Cells for Python via .NET](https://docs.aspose.com/cells/python-net/).

{{% /alert %}}

Als een OLE‑object al in een dia is ingesloten, kunt u het benaderen en de gegevens wijzigen als volgt:

1. Laad de presentatie door een instantie van de klasse [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) te maken.
1. Haal de doel‑dia op op basis van zijn index.
1. Benader de vorm [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/).
1. Zodra u het OLE‑objectframe hebt, voert u de vereiste bewerkingen uit.
1. Maak een `Workbook`‑object aan en lees de OLE‑gegevens.
1. Open het gewenste `Worksheet` en bewerk de gegevens.
1. Sla de bijgewerkte `Workbook` op naar een stream.
1. Vervang de gegevens van het OLE‑object met die stream.

In het onderstaande voorbeeld wordt een OLE‑objectframe (een ingesloten Excel‑grafiek) benaderd en worden de bestandsgegevens aangepast om de grafiek bij te werken. Het voorbeeld maakt gebruik van een eerder aangemaakte PPTX met één vorm op de eerste dia.

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
            # Wijzig de workbook-gegevens.
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

## **Bestanden insluiten in dia's**

Naast Excel‑grafieken laat Aspose.Slides voor Python u andere bestandstypen in dia's insluiten. U kunt bijvoorbeeld HTML‑, PDF‑ en ZIP‑bestanden als objecten invoegen. Wanneer een gebruiker dubbelklikt op een ingevoegd object, wordt het automatisch geopend in de bijbehorende toepassing, of wordt de gebruiker gevraagd een geschikt programma te kiezen.

Deze Python‑code toont hoe u HTML‑ en ZIP‑bestanden in een dia kunt insluiten:

```py
import aspose.slides as slides

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

Bij het werken met presentaties moet u mogelijk oude OLE‑objecten vervangen door nieuwe of een niet‑ondersteund OLE‑object ruilen voor een ondersteund. Aspose.Slides voor Python laat u het bestandstype van een ingesloten object instellen, zodat u de OLE‑framedata of de bestandsextensie kunt bijwerken.

Deze Python‑code toont hoe u het bestandstype van het ingesloten OLE‑object instelt op `zip`:

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    ole_frame = slide.shapes[0]

    file_extension = ole_frame.embedded_data.embedded_file_extension
    file_data = ole_frame.embedded_data.embedded_file_data

    print(f"Current embedded file extension is: {file_extension}")

    # Verander het bestandstype naar ZIP.
    ole_frame.set_embedded_data(slides.dom.ole.OleEmbeddedDataInfo(file_data, "zip"))

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Pictogramafbeeldingen en titels voor ingesloten objecten instellen**

Nadat u een OLE‑object hebt ingesloten, wordt er automatisch een op pictogrammen gebaseerde voorbeeldweergave toegevoegd. Deze voorbeeldweergave is wat gebruikers zien voordat ze het OLE‑object openen of benaderen. Als u een specifieke afbeelding en tekst in de voorbeeldweergave wilt gebruiken, kunt u de pictogramafbeelding en titel instellen met Aspose.Slides voor Python.

Deze Python‑code toont hoe u de pictogramafbeelding en titel voor een ingesloten object instelt:

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    ole_frame = slide.shapes[0]

    # Voeg een afbeelding toe aan de presentatieresources.
    with slides.Images.from_file("image.png") as image:
        ole_image = presentation.images.add_image(image)

    # Stel een titel en de afbeelding in voor de OLE-voorbeeldweergave.
    ole_frame.substitute_picture_title = "My title"
    ole_frame.substitute_picture_format.picture.image = ole_image
    ole_frame.is_object_icon = True

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Voorkomen dat OLE‑objectframes worden geresized en verplaatst**

Nadat u een gelinkt OLE‑object aan een dia hebt toegevoegd, kan PowerPoint u bij het openen van de presentatie vragen de koppelingen bij te werken. Het selecteren van “Update Links” kan de grootte en positie van het OLE‑objectframe wijzigen omdat PowerPoint de voorbeeldweergave ververst met gegevens van het gelinkte object. Om te voorkomen dat PowerPoint u vraagt de gegevens van het object bij te werken, stelt u de eigenschap `update_automatic` van de klasse [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) in op `False`:

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    ole_frame = slide.shapes[0]

    ole_frame.update_automatic = False

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Ingesloten bestanden extraheren**

Aspose.Slides voor Python laat u bestanden die als OLE‑objecten in dia's zijn ingesloten extraheren als volgt:

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) die de OLE‑objecten bevat die u wilt extraheren.
2. Doorloop alle vormen in de presentatie en zoek de OLEObjectFrame‑vormen.
3. Haal de ingesloten bestandsgegevens op van elke [OLEObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) en schrijf deze naar schijf.

De volgende Python‑code toont hoe u bestanden die in een dia als OLE‑objecten zijn ingesloten kunt extraheren:

```py
import aspose.slides as slides

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

Wat zichtbaar is op de dia wordt gerenderd — het pictogram/de vervangingsafbeelding (preview). De “live” OLE‑inhoud wordt niet uitgevoerd tijdens het renderen. Indien nodig stelt u uw eigen voorbeeldafbeelding in om de verwachte weergave in de geëxporteerde PDF te garanderen.

Om ook het ingesloten bestand als PDF‑bijlage te behouden, stelt u [PdfOptions.include_ole_data](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/include_ole_data/) in op `True`. Deze optie is standaard uitgeschakeld. Voor een voorbeeld en instructies om de bijlage te controleren, zie [Preserve Embedded OLE Files as PDF Attachments](/slides/nl/python-net/convert-powerpoint-to-pdf/#preserve-embedded-ole-files-as-pdf-attachments).

**Hoe kan ik een OLE‑object op een dia vergrendelen zodat gebruikers het niet kunnen verschuiven/bewerken in PowerPoint?**

Vergrendel de vorm: Aspose.Slides biedt [shape-level locks](/slides/nl/python-net/applying-protection-to-presentation/). Dit is geen encryptie, maar voorkomt effectief onbedoelde bewerkingen en verplaatsingen.

**Waarom “springt” of verandert een gelinkt Excel‑object van grootte wanneer ik de presentatie open?**

PowerPoint kan de preview van het gelinkte OLE verversen. Voor een stabiele weergave volgt u de praktijken uit de [Working Solution for Worksheet Resizing](/slides/nl/python-net/working-solution-for-worksheet-resizing/) — pas het frame aan de reikwijdte aan, of schaalk de reikwijdte naar een vast frame en stel een passende vervangingsafbeelding in.

**Worden relatieve paden voor gelinkte OLE‑objecten behouden in het PPTX‑formaat?**

In PPTX is informatie over “relatieve paden” niet beschikbaar — alleen het volledige pad. Relatieve paden komen voor in het oudere PPT‑formaat. Voor draagbaarheid heeft u de voorkeur voor betrouwbare absolute paden/toegankelijke URI’s of insluiten.