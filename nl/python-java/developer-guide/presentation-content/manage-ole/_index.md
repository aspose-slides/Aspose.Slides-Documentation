---
title: OLE beheren in presentaties met Python
linktitle: OLE beheren
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
description: "Optimaliseer het beheer van OLE-objecten in PowerPoint- en OpenDocument-bestanden met Aspose.Slides voor Python via Java. Sluit OLE-inhoud in, werk deze bij en exporteer naadloos."
---
## **Inleiding**

{{% alert color="info" title="Opmerking" %}}
OLE (Object Linking & Embedding) is een Microsoft‑technologie die het mogelijk maakt gegevens en objecten die in één applicatie zijn aangemaakt in een andere applicatie te plaatsen via koppelen of insluiten.
{{% /alert %}}

Beschouw een diagram dat is gemaakt in MS Excel. Het diagram wordt vervolgens in een PowerPoint‑dia geplaatst. Dat Excel‑diagram wordt beschouwd als een OLE‑object.

- Een OLE‑object kan als een pictogram verschijnen. In dat geval, wanneer u dubbelklikt op het pictogram, wordt het diagram geopend in de bijbehorende applicatie (Excel), of wordt u gevraagd een applicatie te selecteren voor het openen of bewerken van het object.
- Een OLE‑object kan de eigenlijke inhoud weergeven, zoals de inhoud van een diagram. In dat geval wordt het diagram geactiveerd in PowerPoint, laadt de diagram‑interface en kunt u de gegevens van het diagram wijzigen binnen PowerPoint.

[Aspose.Slides for Python via Java](https://products.aspose.com/slides/nl/python-java/) stelt u in staat OLE‑objecten in dia’s in te voegen als OLE‑objectframes ([OleObjectFrame](https://reference.aspose.com/slides/nl/python-java/aspose.slides/oleobjectframe/)).

## **OLE‑objectframes aan dia's toevoegen**

Ga ervan uit dat u al een diagram in Microsoft Excel heeft aangemaakt en dit wilt insluiten in een dia als OLE‑objectframe met Aspose.Slides for Python via Java; doe dat als volgt:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/) klasse.
2. Haal een dia‑referentie op via de index.
3. Lees het Excel‑bestand in als een byte‑array.
4. Voeg het [OleObjectFrame](https://reference.aspose.com/slides/nl/python-java/aspose.slides/oleobjectframe/) toe aan de dia met de byte‑array en andere informatie over het OLE‑object.
5. Schrijf de gewijzigde presentatie weg als een PPTX‑bestand.

In het voorbeeld hieronder hebben we een diagram uit een Excel‑bestand aan een dia toegevoegd als OLE‑objectframe met Aspose.Slides for Python via Java.  
**Opmerking** dat de constructor van [OleEmbeddedDataInfo](https://reference.aspose.com/slides/nl/python-java/aspose.slides/oleembeddeddatainfo/) een extensie van het in te sluiten object als tweede parameter accepteert. Deze extensie stelt PowerPoint in staat het bestandstype correct te interpreteren en de juiste applicatie te kiezen om dit OLE‑object te openen.

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

    # Bereid de gegevens voor het OLE-object voor.
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

Aspose.Slides for Python via Java maakt het mogelijk een [OleObjectFrame](https://reference.aspose.com/slides/nl/python-java/aspose.slides/oleobjectframe/) toe te voegen zonder gegevens in te sluiten, maar alleen met een koppeling naar het bestand.

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

    # Voeg een OLE-objectframe toe met een gekoppeld Excel‑bestand.
    slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx")

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **OLE‑objectframes benaderen**

Als een OLE‑object al is ingesloten in een dia, kunt u het eenvoudig op deze manier vinden of benaderen:

1. Laad een presentatie met het ingesloten OLE‑object door een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/) klasse te maken.
2. Haal de referentie van de dia op via de index.
3. Benader de [OleObjectFrame](https://reference.aspose.com/slides/nl/python-java/aspose.slides/oleobjectframe/)‑vorm. In ons voorbeeld gebruikten we de eerder aangemaakte PPTX die slechts één vorm op de eerste dia bevat. We controleerden vervolgens dat het object een [OleObjectFrame](https://reference.aspose.com/slides/nl/python-java/aspose.slides/oleobjectframe/) was. Dit was het gewenste OLE‑objectframe om te benaderen.
4. Zodra het OLE‑objectframe is benaderd, kunt u er elke gewenste bewerking op uitvoeren.

In het voorbeeld hieronder wordt een OLE‑objectframe (een Excel‑diagramobject ingesloten in een dia) en de bestandsgegevens ervan benaderd.

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

### **Eigenschappen van gekoppelde OLE‑objectframe benaderen**

Aspose.Slides stelt u in staat de eigenschappen van gekoppelde OLE‑objectframes te benaderen.

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

{{% alert color="info" title="Opmerking" %}}
In dit gedeelte gebruikt het onderstaande code‑voorbeeld [Aspose.Cells for Python via Java](https://products.aspose.com/cells/python-java/).
{{% /alert %}}

Als een OLE‑object al is ingesloten in een dia, kunt u dat object eenvoudig benaderen en de gegevens ervan op deze manier wijzigen:

1. Laad een presentatie met het ingesloten OLE‑object door een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/) klasse te maken.
2. Haal de dia‑referentie op via de index.
3. Benader de OLE‑objectframe‑vorm. In ons voorbeeld gebruikten we de eerder aangemaakte PPTX die één vorm op de eerste dia bevat. We controleerden vervolgens dat het object een [OleObjectFrame](https://reference.aspose.com/slides/nl/python-java/aspose.slides/oleobjectframe/) was. Dit was het gewenste OLE‑objectframe om te benaderen.
4. Zodra het OLE‑objectframe is benaderd, kunt u er elke gewenste bewerking op uitvoeren.
5. Maak een [Workbook](https://reference.aspose.com/cells/python-java/asposecells.api/workbook/)‑object en benader de OLE‑gegevens.
6. Benader het gewenste [Worksheet](https://reference.aspose.com/cells/python-java/asposecells.api/worksheet/) en wijzig de gegevens.
7. Sla het bijgewerkte [Workbook](https://reference.aspose.com/cells/python-java/asposecells.api/workbook/) op in een stream.
8. Wijzig de OLE‑objectgegevens vanuit de stream.

In het voorbeeld hieronder wordt een OLE‑objectframe (een Excel‑diagramobject ingesloten in een dia) benaderd en worden de bestandsgegevens ervan aangepast om de diagramgegevens bij te werken.

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

        # Wijzig de workbook-gegevens.
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

Naast Excel‑diagrammen maakt Aspose.Slides for Python via Java het mogelijk andere soorten bestanden in dia’s in te sluiten. U kunt bijvoorbeeld HTML‑, PDF‑ en ZIP‑bestanden als objecten toevoegen. Wanneer een gebruiker dubbelklikt op het ingevoegde object, wordt het automatisch geopend in het bijbehorende programma, of wordt de gebruiker gevraagd een geschikt programma te selecteren.

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

Bij het werken met presentaties moet u soms oude OLE‑objecten vervangen door nieuwe of een niet‑ondersteund OLE‑object vervangen door een ondersteund. Aspose.Slides for Python via Java maakt het mogelijk het bestandstype voor een ingesloten object in te stellen, waardoor u de OLE‑framedata of de extensie kunt bijwerken.

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

## **Pictogramafbeeldingen en titels voor ingesloten objecten instellen**

Na het insluiten van een OLE‑object wordt er automatisch een voorbeeld bestaande uit een pictogramafbeelding toegevoegd. Dit voorbeeld is wat gebruikers zien voordat ze het OLE‑object benaderen of openen. Als u een specifiek beeld en tekst als elementen in het voorbeeld wilt gebruiken, kunt u via Aspose.Slides for Python via Java de pictogramafbeelding en titel instellen.

Deze Python‑code laat zien hoe u de pictogramafbeelding en titel voor een ingesloten object instelt:

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

    # Voeg een afbeelding toe aan de presentatieresources.
    image_data = Path("image.png").read_bytes()
    image_data = jpype.JArray(jpype.JByte)(image_data)
    ole_image = presentation.getImages().addImage(image_data)

    # Stel een titel en de afbeelding in voor de OLE-preview.
    ole_frame.setSubstitutePictureTitle("My title")
    ole_frame.getSubstitutePictureFormat().getPicture().setImage(ole_image)
    ole_frame.setObjectIcon(True)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Voorkomen dat een OLE‑objectframe wordt geschaald en verplaatst**

Nadat u een gekoppeld OLE‑object aan een presentatiedia hebt toegevoegd, ziet u bij het openen van de presentatie in PowerPoint mogelijk een bericht dat vraagt de koppelingen bij te werken. Het klikken op de knop “Koppelingen bijwerken” kan de grootte en positie van het OLE‑objectframe wijzigen omdat PowerPoint de gegevens van het gekoppelde OLE‑object bijwerkt en het voorbeeld ververst. Om te voorkomen dat PowerPoint vraagt de objectgegevens bij te werken, stelt u de [setUpdateAutomatic](https://reference.aspose.com/slides/nl/python-java/aspose.slides/oleobjectframe/#setUpdateAutomatic)‑methode van de [OleObjectFrame](https://reference.aspose.com/slides/nl/python-java/aspose.slides/oleobjectframe/)‑klasse in op `False`:

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

Aspose.Slides for Python via Java maakt het mogelijk de bestanden die in dia’s als OLE‑objecten zijn ingesloten, als volgt te extraheren:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/)‑klasse die de OLE‑objecten bevat die u wilt extraheren.
2. Loop door alle vormen in de presentatie en benader de [OleObjectFrame](https://reference.aspose.com/slides/nl/python-java/aspose.slides/oleobjectframe/)‑vormen.
3. Benader de gegevens van de ingesloten bestanden vanuit OLE‑objectframes en schrijf ze naar schijf.

Deze Python‑code laat zien hoe u bestanden die in een dia zijn ingesloten als OLE‑objecten kunt extraheren:

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

## **Veelgestelde vragen**

**Wordt de OLE‑inhoud gerenderd bij het exporteren van dia’s naar PDF/afbeeldingen?**  
Wat op de dia zichtbaar is, wordt gerenderd – het pictogram/alternatieve beeld (preview). De “live” OLE‑inhoud wordt niet uitgevoerd tijdens het renderen. Indien nodig, stel uw eigen preview‑afbeelding in om het verwachte uiterlijk in de geëxporteerde PDF te garanderen.

**Hoe kan ik een OLE‑object op een dia vergrendelen zodat gebruikers het niet kunnen verplaatsen/bewerken in PowerPoint?**  
Vergrendel de vorm: Aspose.Slides biedt [vergrendelingen op vormniveau](/slides/nl/python-java/applying-protection-to-presentation/). Dit is geen encryptie, maar voorkomt effectief onbedoelde bewerkingen en verplaatsingen.

**Waarom “springt” of verandert een gekoppeld Excel‑object van grootte wanneer ik de presentatie open?**  
PowerPoint kan het preview‑beeld van het gekoppelde OLE‑object vernieuwen. Voor een stabiel uiterlijk volgt u de praktijken van de [werkende oplossing voor het aanpassen van werkbladgroottes](/slides/nl/python-java/working-solution-for-worksheet-resizing/) – ofwel het frame aanpassen aan het bereik, of het bereik schalen naar een vast frame en een passend vervangend beeld instellen.

**Worden relatieve paden voor gekoppelde OLE‑objecten behouden in het PPTX‑formaat?**  
In PPTX is “relatief pad” informatie niet beschikbaar – alleen het volledige pad. Relatieve paden komen voor in het oudere PPT‑formaat. Voor draagbaarheid wordt aangeraden betrouwbare absolute paden/toegankelijke URI’s of insluiting te gebruiken.