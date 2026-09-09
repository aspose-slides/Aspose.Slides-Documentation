---
title: Beheer OLE in presentaties met Python
linktitle: Beheer OLE
type: docs
weight: 40
url: /nl/python-java/manage-ole/
keywords:
- OLE-object
- Objectkoppeling en insluiting
- OLE toevoegen
- OLE insluiten
- object toevoegen
- object insluiten
- bestand toevoegen
- bestand insluiten
- gekoppeld object
- gekoppeld bestand
- OLE wijzigen
- OLE-pictogram
- OLE-titel
- OLE extraheren
- object extraheren
- bestand extraheren
- PowerPoint
- presentatie
- Python
- Java
- Aspose.Slides
description: "Optimaliseer het beheer van OLE-objecten in PowerPoint- en OpenDocument-bestanden met Aspose.Slides voor Python via Java. Insluiten, bijwerken en exporteren van OLE-inhoud naadloos."
---
## **Introductie**

{{% alert color="info" title="Note" %}}

OLE (Object Linking & Embedding) is een Microsoft‑technologie die het mogelijk maakt gegevens en objecten die in één toepassing zijn gemaakt, in een andere toepassing te plaatsen via koppeling of insluiting.

{{% /alert %}}

Beschouw een grafiek die in MS Excel is gemaakt. De grafiek wordt vervolgens in een PowerPoint‑dia geplaatst. Die Excel‑grafiek wordt beschouwd als een OLE‑object.

- Een OLE‑object kan verschijnen als een pictogram. In dat geval opent een dubbelklik op het pictogram de grafiek in de bijbehorende toepassing (Excel), of wordt u gevraagd een toepassing te selecteren om het object te openen of te bewerken.
- Een OLE‑object kan de eigenlijke inhoud weergeven, bijvoorbeeld de inhoud van een grafiek. In dat geval wordt de grafiek geactiveerd in PowerPoint, laadt de grafiek‑interface en kunt u de gegevens van de grafiek binnen PowerPoint aanpassen.

[Aspose.Slides for Python via Java](https://products.aspose.com/slides/nl/python-java/) maakt het mogelijk OLE‑objecten in dia's in te voegen als OLE‑objectframes ([OleObjectFrame](https://reference.aspose.com/slides/nl/python-java/aspose.slides/oleobjectframe/)).

## **OLE‑objectframes aan dia's toevoegen**

Stel dat u al een grafiek in Microsoft Excel hebt gemaakt en deze wilt insluiten in een dia als OLE‑objectframe met Aspose.Slides for Python via Java, dan kunt u dit als volgt doen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/)‑klasse.
2. Verkrijg een referentie naar een dia op basis van de index.
3. Lees het Excel‑bestand in als een byte‑array.
4. Voeg het [OleObjectFrame](https://reference.aspose.com/slides/nl/python-java/aspose.slides/oleobjectframe/) toe aan de dia met de byte‑array en andere informatie over het OLE‑object.
5. Schrijf de gewijzigde presentatie weg als een PPTX‑bestand.

In het voorbeeld hieronder hebben we een grafiek uit een Excel‑bestand aan een dia toegevoegd als OLE‑objectframe met Aspose.Slides for Python via Java. **Let op** dat de [OleEmbeddedDataInfo](https://reference.aspose.com/slides/nl/python-java/aspose.slides/oleembeddeddatainfo/)‑constructor een uitbreidbare object‑extensie als tweede parameter neemt. Deze extensie stelt PowerPoint in staat het bestandstype correct te interpreteren en de juiste toepassing te kiezen om dit OLE‑object te openen.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleEmbeddedDataInfo, Presentation, SaveFormat

presentation = Presentation()
try:
    slide_size = presentation.getSlideSize().getSize()
    slide = presentation.getSlides().get_Item(0)

    # Bereid de data voor het OLE-object.
    file_data = Path("book.xlsx").read_bytes()
    file_data = jpype.JArray(jpype.JByte)(file_data)
    data_info = OleEmbeddedDataInfo(file_data, "xlsx")

    # Voeg het OLE-objectframe toe aan de dia.
    frame_width = jpype.JFloat(slide_size.getWidth())
    frame_height = jpype.JFloat(slide_size.getHeight())
    slide.getShapes().addOleObjectFrame(0, 0, frame_width, frame_height, data_info)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Gekoppelde OLE‑objectframes toevoegen**

Aspose.Slides for Python via Java maakt het mogelijk een [OleObjectFrame](https://reference.aspose.com/slides/nl/python-java/aspose.slides/oleobjectframe/) toe te voegen met een koppeling naar het bestand in plaats van ingesloten gegevens.

Deze Python‑code laat zien hoe u een [OleObjectFrame](https://reference.aspose.com/slides/nl/python-java/aspose.slides/oleobjectframe/) met een gekoppeld Excel‑bestand aan een dia toevoegt:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Voeg een OLE-objectframe toe met een gekoppeld Excel-bestand.
    slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx")

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **OLE‑objectframes benaderen**

Als een OLE‑object al in een dia is ingesloten, kunt u het op deze manier gemakkelijk vinden of benaderen:

1. Laad een presentatie met het ingesloten OLE‑object door een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/)‑klasse te maken.
2. Verkrijg een referentie naar de dia op basis van de index.
3. Benader de [OleObjectFrame](https://reference.aspose.com/slides/nl/python-java/aspose.slides/oleobjectframe/)‑vorm. In ons voorbeeld gebruikten we de eerder gemaakte PPTX die slechts één vorm op de eerste dia heeft. Vervolgens controleerden we of het object een [OleObjectFrame](https://reference.aspose.com/slides/nl/python-java/aspose.slides/oleobjectframe/) was. Dit was het gewenste OLE‑objectframe om te benaderen.
4. Zodra het OLE‑objectframe is benaderd, kunt u elke bewerking erop uitvoeren.

In het voorbeeld hieronder worden een OLE‑objectframe (een Excel‑grafiekobject ingesloten in een dia) en de bestandsgegevens ervan benaderd.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleObjectFrame, Presentation

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)

    if isinstance(shape, OleObjectFrame):
        ole_frame = shape

        # Haal de ingesloten bestandsgegevens op.
        file_data = ole_frame.getEmbeddedData().getEmbeddedFileData()

        # Haal de extensie van het ingesloten bestand op.
        file_extension = ole_frame.getEmbeddedData().getEmbeddedFileExtension()

        # ...
finally:
    presentation.dispose()
```

### **Eigenschappen van gekoppelde OLE‑objectframes benaderen**

Aspose.Slides maakt het mogelijk de eigenschappen van gekoppelde OLE‑objectframes te benaderen.

Deze Python‑code laat zien hoe u controleert of een OLE‑object gekoppeld is en vervolgens het pad naar het gekoppelde bestand verkrijgt:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleObjectFrame, Presentation

presentation = Presentation("sample.ppt")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)

    if isinstance(shape, OleObjectFrame):
        ole_frame = shape

        # Controleer of het OLE-object gekoppeld is.
        if ole_frame.isObjectLink():
            # Print het volledige pad naar het gekoppelde bestand.
            print("OLE object frame is linked to: " + str(ole_frame.getLinkPathLong()))

            # Print het relatieve pad naar het gekoppelde bestand indien aanwezig.
            # Alleen PPT-presentaties kunnen het relatieve pad bevatten.
            relative_path = ole_frame.getLinkPathRelative()
            if relative_path is not None and not relative_path.isEmpty():
                print("OLE object frame relative path: " + str(relative_path))
finally:
    presentation.dispose()
```

## **OLE‑objectgegevens wijzigen**

{{% alert color="info" title="Note" %}}

In dit gedeelte gebruikt het code‑voorbeeld hieronder [Aspose.Cells for Python via Java](https://products.aspose.com/cells/python-java/).

{{% /alert %}}

Als een OLE‑object al in een dia is ingesloten, kunt u dat object op deze manier eenvoudig benaderen en de gegevens ervan wijzigen:

1. Laad een presentatie met het ingesloten OLE‑object door een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/)‑klasse te maken.
2. Verkrijg een referentie naar de dia op basis van de index.
3. Benader de OLE‑objectframe‑vorm. In ons voorbeeld gebruikten we de eerder gemaakte PPTX die één vorm op de eerste dia heeft. Vervolgens controleerden we of het object een [OleObjectFrame](https://reference.aspose.com/slides/nl/python-java/aspose.slides/oleobjectframe/) was. Dit was het gewenste OLE‑objectframe om te benaderen.
4. Zodra het OLE‑objectframe is benaderd, kunt u elke bewerking erop uitvoeren.
5. Maak een [Workbook](https://reference.aspose.com/cells/python-java/asposecells.api/workbook/)‑object en benader de OLE‑gegevens.
6. Benader het gewenste [Worksheet](https://reference.aspose.com/cells/python-java/asposecells.api/worksheet/) en pas de gegevens aan.
7. Sla het bijgewerkte [Workbook](https://reference.aspose.com/cells/python-java/asposecells.api/workbook/) op in een stream.
8. Wijzig de OLE‑objectgegevens vanaf de stream.

In het voorbeeld hieronder wordt een OLE‑objectframe (een Excel‑grafiekobject ingesloten in een dia) benaderd en worden de bestandsgegevens aangepast om de grafiekgegevens bij te werken.

```python
import jpype
import asposeslides
import asposecells

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleEmbeddedDataInfo, OleObjectFrame, Presentation, SaveFormat
from asposecells.api import Workbook, OoxmlSaveOptions
from asposecells.api import SaveFormat as CellsSaveFormat
from java.io import ByteArrayInputStream, ByteArrayOutputStream

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)

    if isinstance(shape, OleObjectFrame):
        ole_frame = shape

        file_data = ole_frame.getEmbeddedData().getEmbeddedFileData()
        ole_stream = ByteArrayInputStream(file_data)

        # Lees de OLE-objectgegevens als een Workbook-object.
        workbook = Workbook(ole_stream)

        new_ole_stream = ByteArrayOutputStream()

        # Pas de workbook-gegevens aan.
        cells = workbook.getWorksheets().get(0).getCells()
        cells.get(0, 4).putValue("E")
        cells.get(1, 4).putValue(jpype.JInt(12))
        cells.get(2, 4).putValue(jpype.JInt(14))
        cells.get(3, 4).putValue(jpype.JInt(15))

        file_options = OoxmlSaveOptions(CellsSaveFormat.XLSX)
        workbook.save(new_ole_stream, file_options)

        # Wijzig de OLE-frame-objectgegevens.
        new_file_data = new_ole_stream.toByteArray()
        new_data = OleEmbeddedDataInfo(new_file_data, ole_frame.getEmbeddedData().getEmbeddedFileExtension())
        ole_frame.setEmbeddedData(new_data)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Andere bestandstypen in dia's insluiten**

Naast Excel‑grafieken maakt Aspose.Slides for Python via Java het mogelijk andere soorten bestanden in dia's in te sluiten. U kunt bijvoorbeeld HTML, PDF en ZIP‑bestanden als objecten invoegen. Wanneer een gebruiker dubbelklikt op het ingevoegde object, wordt het automatisch geopend in het relevante programma, of wordt de gebruiker gevraagd een geschikt programma te selecteren om het te openen.

Deze Python‑code laat zien hoe u HTML en ZIP in een dia insluit:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleEmbeddedDataInfo, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    html_data = Path("sample.html").read_bytes()
    html_data = jpype.JArray(jpype.JByte)(html_data)
    html_data_info = OleEmbeddedDataInfo(html_data, "html")
    html_ole_frame = slide.getShapes().addOleObjectFrame(150, 120, 50, 50, html_data_info)
    html_ole_frame.setObjectIcon(True)

    zip_data = Path("sample.zip").read_bytes()
    zip_data = jpype.JArray(jpype.JByte)(zip_data)
    zip_data_info = OleEmbeddedDataInfo(zip_data, "zip")
    zip_ole_frame = slide.getShapes().addOleObjectFrame(150, 220, 50, 50, zip_data_info)
    zip_ole_frame.setObjectIcon(True)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Bestandstypen voor ingesloten objecten instellen**

Bij het werken met presentaties kan het nodig zijn oude OLE‑objecten te vervangen door nieuwe of een niet‑ondersteund OLE‑object te vervangen door een ondersteund object. Aspose.Slides for Python via Java maakt het mogelijk het bestandstype voor een ingesloten object in te stellen, zodat u de OLE‑frame‑gegevens of de extensie kunt bijwerken.

Deze Python‑code laat zien hoe u het bestandstype voor een ingesloten OLE‑object instelt op `zip`:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleEmbeddedDataInfo, Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    ole_frame = slide.getShapes().get_Item(0)

    file_extension = ole_frame.getEmbeddedData().getEmbeddedFileExtension()
    file_data = ole_frame.getEmbeddedData().getEmbeddedFileData()

    print("Current embedded file extension is: " + str(file_extension))

    # Verander het bestandstype naar ZIP.
    data_info = OleEmbeddedDataInfo(file_data, "zip")
    ole_frame.setEmbeddedData(data_info)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Pictogrammen en titels voor ingesloten objecten instellen**

Nadat een OLE‑object is ingesloten, wordt er automatisch een voorbeeld met een pictogramafbeelding toegevoegd. Dit voorbeeld is wat gebruikers zien voordat ze het OLE‑object benaderen of openen. Als u een specifieke afbeelding en tekst wilt gebruiken als elementen in het voorbeeld, kunt u het pictogram en de titel instellen met Aspose.Slides for Python via Java.

Deze Python‑code laat zien hoe u het pictogram en de titel voor een ingesloten object instelt:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    ole_frame = slide.getShapes().get_Item(0)

    # Voeg een afbeelding toe aan de presentatie‑resources.
    image_data = Path("image.png").read_bytes()
    image_data = jpype.JArray(jpype.JByte)(image_data)
    ole_image = presentation.getImages().addImage(image_data)

    # Stel een titel en de afbeelding in voor het OLE‑voorbeeld.
    ole_frame.setSubstitutePictureTitle("My title")
    ole_frame.getSubstitutePictureFormat().getPicture().setImage(ole_image)
    ole_frame.setObjectIcon(True)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Voorkom dat een OLE‑objectframe wordt verkleind en verplaatst**

Nadat u een gekoppeld OLE‑object aan een presentatiedia hebt toegevoegd, kunt u bij het openen van de presentatie in PowerPoint een bericht zien dat vraagt de koppelingen bij te werken. Door op de knop “Update Links” te klikken kan de grootte en positie van het OLE‑objectframe veranderen omdat PowerPoint de gegevens van het gekoppelde OLE‑object bijwerkt en het voorbeeld ververst. Om te voorkomen dat PowerPoint vraagt de gegevens van het object bij te werken, stelt u de [setUpdateAutomatic](https://reference.aspose.com/slides/nl/python-java/aspose.slides/oleobjectframe/#setUpdateAutomatic)‑methode van de [OleObjectFrame](https://reference.aspose.com/slides/nl/python-java/aspose.slides/oleobjectframe/)‑klasse in op `False`:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    ole_frame = slide.getShapes().get_Item(0)

    ole_frame.setUpdateAutomatic(False)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Ingesloten bestanden extraheren**

Aspose.Slides for Python via Java maakt het mogelijk de in dia's ingesloten bestanden als OLE‑objecten te extraheren op de volgende manier:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/)‑klasse die de OLE‑objecten bevat die u wilt extraheren.
2. Loop door alle vormen in de presentatie en benader de [OleObjectFrame](https://reference.aspose.com/slides/nl/python-java/aspose.slides/oleobjectframe/)‑vormen.
3. Haal de gegevens van ingesloten bestanden op uit de OLE‑objectframes en schrijf ze naar schijf.

Deze Python‑code laat zien hoe u bestanden die in een dia als OLE‑objecten zijn ingesloten, kunt extraheren:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleObjectFrame, Presentation

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)

        if isinstance(shape, OleObjectFrame):
            ole_frame = shape

            file_data = ole_frame.getEmbeddedData().getEmbeddedFileData()
            file_extension = ole_frame.getEmbeddedData().getEmbeddedFileExtension()

            file_path = Path(f"OLE_object_{index}.{str(file_extension).lstrip('.')}")
            file_path.write_bytes(bytes(file_data))
finally:
    presentation.dispose()
```

## **FAQ**

**Wordt de OLE‑inhoud gerenderd bij het exporteren van dia's naar PDF/afbeeldingen?**

Wat zichtbaar is op de dia wordt gerenderd — het pictogram/substituut‑beeld (voorbeeld). De “live” OLE‑inhoud wordt niet uitgevoerd tijdens het renderen. Indien nodig kunt u uw eigen voorbeeldafbeelding instellen om het verwachte uiterlijk in de geëxporteerde PDF te waarborgen.

**Hoe kan ik een OLE‑object op een dia vergrendelen zodat gebruikers het niet kunnen verplaatsen/bewerken in PowerPoint?**

Vergrendel de vorm: Aspose.Slides biedt [shape-level locks](/slides/nl/python-java/applying-protection-to-presentation/). Dit is geen versleuteling, maar voorkomt effectief accidentele bewerkingen en verplaatsingen.

**Waarom “springt” een gekoppeld Excel‑object of verandert van grootte wanneer ik de presentatie open?**

PowerPoint kan het voorbeeld van het gekoppelde OLE‑object verversen. Voor een stabiel uiterlijk volgt u de richtlijnen van de [Working Solution for Worksheet Resizing](/slides/nl/python-java/working-solution-for-worksheet-resizing/) — ofwel het frame aan de gegevens aanpassen, of de gegevens schalen naar een vast frame en een geschikt substituut‑beeld instellen.

**Blijven relatieve paden voor gekoppelde OLE‑objecten behouden in het PPTX‑formaat?**

In PPTX is “relatief pad” niet beschikbaar — alleen het volledige pad. Relatieve paden komen voor in het oudere PPT‑formaat. Voor draagbaarheid heeft u beter absolute paden/bruikbare URI’s of insluiting te gebruiken.