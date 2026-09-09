---
title: Hantera OLE i presentationer med Python
linktitle: Hantera OLE
type: docs
weight: 40
url: /sv/python-java/manage-ole/
keywords:
- OLE-objekt
- Objektlänkning & inbäddning
- lägg till OLE
- bädda in OLE
- lägg till objekt
- bädda in objekt
- lägg till fil
- bädda in fil
- länkat objekt
- länkat fil
- ändra OLE
- OLE-ikon
- OLE-titel
- extrahera OLE
- extrahera objekt
- extrahera fil
- PowerPoint
- presentation
- Python
- Java
- Aspose.Slides
description: "Optimera hanteringen av OLE-objekt i PowerPoint- och OpenDocument-filer med Aspose.Slides för Python via Java. Bädda in, uppdatera och exportera OLE-innehåll sömlöst."
---
## **Introduktion**

{{% alert color="info" title="Obs" %}}
OLE (Object Linking & Embedding) är en Microsoft‑teknik som tillåter data och objekt som skapats i en applikation att placeras i en annan applikation via länkning eller inbäddning.
{{% /alert %}}

Tänk dig ett diagram skapat i MS Excel. Diagrammet placeras sedan i en PowerPoint‑bild. Detta Excel‑diagram betraktas som ett OLE‑objekt.

- Ett OLE‑objekt kan visas som en ikon. I så fall öppnas diagrammet i den tillhörande applikationen (Excel) när du dubbelklickar på ikonen, eller så blir du ombedd att välja en applikation för att öppna eller redigera objektet.
- Ett OLE‑objekt kan visa sitt faktiska innehåll, till exempel innehållet i ett diagram. I så fall aktiveras diagrammet i PowerPoint, diagramgränssnittet laddas och du kan ändra diagrammets data i PowerPoint.

[Aspose.Slides for Python via Java](https://products.aspose.com/slides/sv/python-java/) låter dig infoga OLE‑objekt i bilder som OLE‑objekt‑ramar ([OleObjectFrame](https://reference.aspose.com/slides/sv/python-java/aspose.slides/oleobjectframe/)).

## **Lägg till OLE‑objektram i bilder**

Om du redan har skapat ett diagram i Microsoft Excel och vill bädda in det i en bild som en OLE‑objektram med Aspose.Slides for Python via Java, kan du göra så här:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/).
2. Hämta en referens till en bild genom dess index.
3. Läs Excel‑filen som en bytearray.
4. Lägg till [OleObjectFrame](https://reference.aspose.com/slides/sv/python-java/aspose.slides/oleobjectframe/) på bilden med bytearrayen och annan information om OLE‑objektet.
5. Skriv den modifierade presentationen som en PPTX‑fil.

I exemplet nedan lade vi till ett diagram från en Excel‑fil på en bild som en OLE‑objektram med Aspose.Slides for Python via Java. **Obs** att konstruktorn för [OleEmbeddedDataInfo](https://reference.aspose.com/slides/sv/python-java/aspose.slides/oleembeddeddatainfo/) tar en inbäddningsbar objekt‑filändelse som sin andra parameter. Denna filändelse gör att PowerPoint kan tolka filtypen korrekt och välja rätt program för att öppna detta OLE‑objekt.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpile.isJVMStarted():
    jpile.startJVM()

from asposeslides.api import OleEmbeddedDataInfo, Presentation, SaveFormat

presentation = Presentation()
try:
    slide_size = presentation.getSlideSize().getSize()
    slide = presentation.getSlides().get_Item(0)

    # Förbered data för OLE-objektet.
    file_data = Path("book.xlsx").read_bytes()
    file_data = jpile.JArray(jpile.JByte)(file_data)
    data_info = OleEmbeddedDataInfo(file_data, "xlsx")

    # Lägg till OLE-objektram på bilden.
    frame_width = jpile.JFloat(slide_size.getWidth())
    frame_height = jpile.JFloat(slide_size.getHeight())
    slide.getShapes().addOleObjectFrame(0, 0, frame_width, frame_height, data_info)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Lägg till länkade OLE‑objektram**

Aspose.Slides for Python via Java låter dig lägga till en [OleObjectFrame](https://reference.aspose.com/slides/sv/python-java/aspose.slides/oleobjectframe/) med en länk till filen istället för inbäddad data.

Denna Python‑kod visar hur du lägger till en [OleObjectFrame](https://reference.aspose.com/slides/sv/python-java/aspose.slides/oleobjectframe/) med en länkad Excel‑fil på en bild:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Lägg till en OLE-objektram med en länkad Excel-fil.
    slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx")

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Åtkomst till OLE‑objektram**

Om ett OLE‑objekt redan är inbäddat i en bild kan du enkelt hitta eller åtkomma det på följande sätt:

1. Läs in en presentation med det inbäddade OLE‑objektet genom att skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/).
2. Hämta en referens till bilden genom dess index.
3. Åtkom [OleObjectFrame](https://reference.aspose.com/slides/sv/python-java/aspose.slides/oleobjectframe/)‑formen. I vårt exempel använde vi den tidigare skapade PPTX‑filen som bara har en form på den första bilden. Vi kontrollerade sedan att objektet var en [OleObjectFrame]. Detta var den önskade OLE‑objektram som skulle åtkommas.
4. När OLE‑objektramen har åtkomst kan du utföra vilken operation som helst på den.

I exemplet nedan åtkoms en OLE‑objektram (ett Excel‑diagramobjekt inbäddat i en bild) och dess fildata.

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

        # Hämta den inbäddade filens data.
        file_data = ole_frame.getEmbeddedData().getEmbeddedFileData()

        # Hämta filändelsen för den inbäddade filen.
        file_extension = ole_frame.getEmbeddedData().getEmbeddedFileExtension()

        # ...
finally:
    presentation.dispose()
```

### **Åtkomst till egenskaper för länkad OLE‑objektram**

Aspose.Slides låter dig komma åt egenskaper för länkade OLE‑objektram.

Denna Python‑kod visar hur du kontrollerar om ett OLE‑objekt är länkat och sedan får sökvägen till den länkade filen:

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

        # Kontrollera om OLE-objektet är länkat.
        if ole_frame.isObjectLink():
            # Skriv ut den fullständiga sökvägen till den länkade filen.
            print("OLE object frame is linked to: " + str(ole_frame.getLinkPathLong()))

            # Skriv ut den relativa sökvägen till den länkade filen om den finns.
            # Endast PPT-presentationer kan innehålla den relativa sökvägen.
            relative_path = ole_frame.getLinkPathRelative()
            if relative_path is not None and not relative_path.isEmpty():
                print("OLE object frame relative path: " + str(relative_path))
finally:
    presentation.dispose()
```

## **Ändra OLE‑objektsdata**

{{% alert color="info" title="Obs" %}}
I det här avsnittet använder kodexemplet nedan [Aspose.Cells for Python via Java](https://products.aspose.com/cells/python-java/).
{{% /alert %}}

Om ett OLE‑objekt redan är inbäddat i en bild kan du enkelt åtkomma det och ändra dess data på följande sätt:

1. Läs in en presentation med det inbäddade OLE‑objektet genom att skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/).
2. Hämta en referens till bilden genom dess index.
3. Åtkom OLE‑objektram‑formen. I vårt exempel använde vi den tidigare skapade PPTX‑filen som bara har en form på den första bilden. Vi kontrollerade sedan att objektet var en [OleObjectFrame]. Detta var den önskade OLE‑objektram som skulle åtkommas.
4. När OLE‑objektramen har åtkomst kan du utföra vilken operation som helst på den.
5. Skapa ett [Workbook](https://reference.aspose.com/cells/python-java/asposecells.api/workbook/)‑objekt och åtkom OLE‑datan.
6. Åtkom önskat [Worksheet](https://reference.aspose.com/cells/python-java/asposecells.api/worksheet/) och ändra datan.
7. Spara den uppdaterade [Workbook](https://reference.aspose.com/cells/python-java/asposecells.api/workbook/) i en ström.
8. Ändra OLE‑objektdatana från strömmen.

I exemplet nedan åtkoms en OLE‑objektram (ett Excel‑diagramobjekt inbäddat i en bild) och dess fildata ändras för att uppdatera diagrammets data.

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

        # Läs OLE-objektets data som ett Workbook-objekt.
        workbook = Workbook(ole_stream)

        new_ole_stream = ByteArrayOutputStream()

        # Modifiera arbetsbokens data.
        cells = workbook.getWorksheets().get(0).getCells()
        cells.get(0, 4).putValue("E")
        cells.get(1, 4).putValue(jpype.JInt(12))
        cells.get(2, 4).putValue(jpype.JInt(14))
        cells.get(3, 4).putValue(jpype.JInt(15))

        file_options = OoxmlSaveOptions(CellsSaveFormat.XLSX)
        workbook.save(new_ole_stream, file_options)

        # Ändra OLE-ramens objektdata.
        new_file_data = new_ole_stream.toByteArray()
        new_data = OleEmbeddedDataInfo(new_file_data, ole_frame.getEmbeddedData().getEmbeddedFileExtension())
        ole_frame.setEmbeddedData(new_data)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Bädda in andra filtyper i bilder**

Förutom Excel‑diagram låter Aspose.Slides for Python via Java dig bädda in andra typer av filer i bilder. Till exempel kan du infoga HTML‑, PDF‑ och ZIP‑filer som objekt. När en användare dubbelklickar på det infogade objektet öppnas det automatiskt i det relevanta programmet, eller så uppmanas användaren att välja ett lämpligt program för att öppna det.

Denna Python‑kod visar hur du infogar HTML och ZIP i en bild:

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

## **Ställ in filtyper för inbäddade objekt**

När du arbetar med presentationer kan du behöva ersätta gamla OLE‑objekt med nya eller ersätta ett ej‑stött OLE‑objekt med ett stödt. Aspose.Slides for Python via Java låter dig ställa in filtypen för ett inbäddat objekt, så att du kan uppdatera OLE‑ramens data eller dess filändelse.

Denna Python‑kod visar hur du ställer in filtypen för ett inbäddat OLE‑objekt till `zip`:

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

    # Ändra filtypen till ZIP.
    data_info = OleEmbeddedDataInfo(file_data, "zip")
    ole_frame.setEmbeddedData(data_info)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Ställ in ikonbilder och titlar för inbäddade objekt**

När ett OLE‑objekt har bäddats in läggs automatiskt en förhandsgranskning bestående av en ikonbild till. Denna förhandsgranskning är vad användarna ser innan de får åtkomst till eller öppnar OLE‑objektet. Om du vill använda en specifik bild och text som element i förhandsgranskningen kan du ställa in ikonbilden och titeln med Aspose.Slides for Python via Java.

Denna Python‑kod visar hur du ställer in ikonbilden och titeln för ett inbäddat objekt:

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

    # Lägg till en bild i presentationens resurser.
    image_data = Path("image.png").read_bytes()
    image_data = jpype.JArray(jpype.JByte)(image_data)
    ole_image = presentation.getImages().addImage(image_data)

    # Ange en titel och bilden för OLE-förhandsgranskningen.
    ole_frame.setSubstitutePictureTitle("My title")
    ole_frame.getSubstitutePictureFormat().getPicture().setImage(ole_image)
    ole_frame.setObjectIcon(True)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Förhindra att en OLE‑objektram storleksändras eller flyttas**

Efter att du har lagt till ett länkat OLE‑objekt på en presentationsbild kan du, när du öppnar presentationen i PowerPoint, se ett meddelande som ber dig uppdatera länkarna. Att klicka på knappen "Uppdatera länkar" kan ändra storlek och position för OLE‑objektramens eftersom PowerPoint uppdaterar datan från det länkade OLE‑objektet och uppdaterar objektets förhandsgranskning. För att hindra PowerPoint från att be om att uppdatera objektets data, sätt metodens [setUpdateAutomatic](https://reference.aspose.com/slides/sv/python-java/aspose.slides/oleobjectframe/#setUpdateAutomatic) i klassen [OleObjectFrame](https://reference.aspose.com/slides/sv/python-java/aspose.slides/oleobjectframe/) till `False`:

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

## **Extrahera inbäddade filer**

Aspose.Slides for Python via Java låter dig extrahera filerna som är inbäddade i bilder som OLE‑objekt på följande sätt:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/) som innehåller de OLE‑objekt du avser att extrahera.
2. Loopa igenom alla former i presentationen och åtkom [OleObjectFrame](https://reference.aspose.com/slides/sv/python-java/aspose.slides/oleobjectframe/)-formerna.
3. Åtkom data för inbäddade filer från OLE‑objektramarna och skriv dem till disk.

Denna Python‑kod visar hur du extraherar filer som är inbäddade i en bild som OLE‑objekt:

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

**Kommer OLE‑innehållet att renderas när man exporterar bilder till PDF/bilder?**

Det som syns på bilden renderas – ikonen/ersättningsbilden (förhandsgranskning). Det "levande" OLE‑innehållet körs inte under rendering. Vid behov kan du ange en egen förhandsgranskningsbild för att säkerställa önskat utseende i den exporterade PDF‑filen.

**Hur kan jag låsa ett OLE‑objekt på en bild så att användare inte kan flytta/redigera det i PowerPoint?**

Lås formen: Aspose.Slides tillhandahåller [formnivå‑lås](/slides/sv/python-java/applying-protection-to-presentation/). Detta är ingen kryptering, men det förhindrar effektivt oavsiktliga redigeringar och flyttningar.

**Varför hoppar ett länkat Excel‑objekt eller ändrar storlek när jag öppnar presentationen?**

PowerPoint kan uppdatera förhandsgranskningen av det länkade OLE‑objektet. För ett stabilt utseende, följ rekommendationerna i [Working Solution for Worksheet Resizing](/slides/sv/python-java/working-solution-for-worksheet-resizing/) – antingen anpassa ramen till området, eller skala området till en fast ram och ange en lämplig ersättningsbild.

**Behålls relativa sökvägar för länkade OLE‑objekt i PPTX‑formatet?**

I PPTX‑formatet finns ingen information om "relativ sökväg" – endast den fullständiga sökvägen. Relativa sökvägar finns i det äldre PPT‑formatet. För portabilitet bör du föredra pålitliga absoluta sökvägar/tillgängliga URI:er eller inbäddning.