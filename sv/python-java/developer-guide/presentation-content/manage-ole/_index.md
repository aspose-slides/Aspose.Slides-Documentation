---
title: Hantera OLE i presentationer med Python
linktitle: Hantera OLE
type: docs
weight: 40
url: /sv/python-java/manage-ole/
keywords:
- OLE-objekt
- Objektlänkning och inbäddning
- lägg till OLE
- bädda in OLE
- lägg till objekt
- bädda in objekt
- lägg till fil
- bädda in fil
- länkat objekt
- länkad fil
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
description: "Optimera hanteringen av OLE-objekt i PowerPoint- och OpenDocument-filer med Aspose.Slides för Python via Java. Bädda in, uppdatera och exportera OLE-innehåll smidigt."
---
## **Introduktion**

{{% alert color="info" title="Obs" %}}
OLE (Object Linking & Embedding) är en Microsoft‑teknik som tillåter data och objekt som skapats i en applikation att placeras i en annan applikation genom länkning eller inbäddning.
{{% /alert %}}

Tänk på ett diagram som skapats i MS Excel. Diagrammet placeras sedan i en PowerPoint‑bild. Det Excel‑diagrammet betraktas som ett OLE‑objekt.

- Ett OLE‑objekt kan visas som en ikon. I så fall, när du dubbelklickar på ikonen, öppnas diagrammet i den associerade applikationen (Excel), eller så blir du ombedd att välja en applikation för att öppna eller redigera objektet.
- Ett OLE‑objekt kan visa sitt faktiska innehåll, till exempel innehållet i ett diagram. I så fall aktiveras diagrammet i PowerPoint, diagramgränssnittet laddas och du kan ändra diagrammets data i PowerPoint.

[Aspose.Slides for Python via Java](https://products.aspose.com/slides/sv/python-java/) möjliggör att du infogar OLE‑objekt i bilder som OLE‑object‑frames ([OleObjectFrame](https://reference.aspose.com/slides/sv/python-java/aspose.slides/oleobjectframe/)).

## **Lägg till OLE‑objekt‑ramar i bilder**

Förutsatt att du redan har skapat ett diagram i Microsoft Excel och vill bädda in det i en bild som en OLE‑objekt‑ram med Aspose.Slides for Python via Java, kan du göra så här:

1. Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/) klassen.
1. Hämta referensen till en bild via dess index.
1. Läs Excel‑filen som en byte‑array.
1. Lägg till [OleObjectFrame](https://reference.aspose.com/slides/sv/python-java/aspose.slides/oleobjectframe/) i bilden med byte‑arrayen och annan information om OLE‑objektet.
1. Skriv den ändrade presentationen som en PPTX‑fil.

I exemplet nedan har vi lagt till ett diagram från en Excel‑fil i en bild som en OLE‑objekt‑ram med Aspose.Slides for Python via Java.  
**Obs** att konstruktorn för [OleEmbeddedDataInfo](https://reference.aspose.com/slides/sv/python-java/aspose.slides/oleembeddeddatainfo/) tar en inbäddningsbar objekt‑filändelse som andra parameter. Denna filändelse gör att PowerPoint korrekt tolkar filtypen och väljer rätt program för att öppna detta OLE‑objekt.

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

    # Förbered data för OLE-objektet.
    file_data = Path("book.xlsx").read_bytes()
    file_data = jpype.JArray(jpype.JByte)(file_data)
    data_info = OleEmbeddedDataInfo(file_data, "xlsx")

    # Lägg till OLE-objektramen på bilden.
    frame_width = jpype.JFloat(slide_size.getWidth())
    frame_height = jpype.JFloat(slide_size.getHeight())
    slide.getShapes().addOleObjectFrame(0, 0, frame_width, frame_height, data_info)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Lägg till länkade OLE‑objekt‑ramar**

Aspose.Slides for Python via Java låter dig lägga till en [OleObjectFrame](https://reference.aspose.com/slides/sv/python-java/aspose.slides/oleobjectframe/) utan att bädda in data, utan bara med en länk till filen.

Denna Python‑kod visar hur du lägger till ett [OleObjectFrame](https://reference.aspose.com/slides/sv/python-java/aspose.slides/oleobjectframe/) med en länkad Excel‑fil till en bild:

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

## **Åtkomst till OLE‑objekt‑ramar**

Om ett OLE‑objekt redan är inbäddat i en bild kan du enkelt hitta eller komma åt det på följande sätt:

1. Ladda en presentation med det inbäddade OLE‑objektet genom att skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/) klassen.
2. Hämta referensen till bilden genom att använda dess index.
3. Åtkomst till [OleObjectFrame](https://reference.aspose.com/slides/sv/python-java/aspose.slides/oleobjectframe/)‑formen.
   I vårt exempel använde vi den tidigare skapade PPTX‑filen som har endast en form på den första bilden.  Vi kontrollerade sedan att objektet var en [OleObjectFrame](https://reference.aspose.com/slides/sv/python-java/aspose.slides/oleobjectframe/). Detta var den önskade OLE‑objekt‑ramen som skulle nås.
4. När OLE‑objekt‑ramen har nåtts kan du utföra vilken operation som helst på den.

I exemplet nedan nås en OLE‑objekt‑ram (ett Excel‑diagramobjekt inbäddat i en bild) och dess fildata.

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

        # Hämta den inbäddade filens filändelse.
        file_extension = ole_frame.getEmbeddedData().getEmbeddedFileExtension()

        # ...
finally:
    presentation.dispose()
```

### **Åtkomst till egenskaper för länkade OLE‑objekt‑ramar**

Aspose.Slides låter dig komma åt egenskaper för länkade OLE‑objekt‑ramar.

Denna Python‑kod visar hur du kontrollerar om ett OLE‑objekt är länkat och sedan hämtar sökvägen till den länkade filen:

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

## **Ändra OLE‑objektdata**

{{% alert color="info" title="Obs" %}}
I det här avsnittet använder kodexemplet nedan [Aspose.Cells for Python via Java](https://products.aspose.com/cells/python-java/).
{{% /alert %}}

Om ett OLE‑objekt redan är inbäddat i en bild kan du enkelt nå det objektet och ändra dess data på följande sätt:

1. Ladda en presentation med det inbäddade OLE‑objektet genom att skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/) klassen.
2. Hämta bildens referens via dess index.
3. Åtkomst till OLE‑objekt‑ramens form.
   I vårt exempel använde vi den tidigare skapade PPTX‑filen som har en form på den första bilden. Vi kontrollerade sedan att objektet var ett [OleObjectFrame](https://reference.aspose.com/slides/sv/python-java/aspose.slides/oleobjectframe/). Detta var den önskade OLE‑objekt‑ramen som skulle nås.
4. När OLE‑objekt‑ramen har nåtts kan du utföra vilken operation som helst på den.
5. Skapa ett [Workbook](https://reference.aspose.com/cells/python-java/asposecells.api/workbook/)‑objekt och få åtkomst till OLE‑datat.
6. Få åtkomst till önskat [Worksheet](https://reference.aspose.com/cells/python-java/asposecells.api/worksheet/) och ändra datan.
7. Spara den uppdaterade [Workbook](https://reference.aspose.com/cells/python-java/asposecells.api/workbook/) i ett flöde.
8. Ändra OLE‑objektdatan från flödet.

I exemplet nedan nås en OLE‑objekt‑ram (ett Excel‑diagramobjekt inbäddat i en bild) och dess fildata förändras för att uppdatera diagramdatat.

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

        # Läs OLE-objektdatan som ett Workbook-objekt.
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

        # Ändra OLE-ramobjektets data.
        new_file_data = new_ole_stream.toByteArray()
        new_data = OleEmbeddedDataInfo(new_file_data, ole_frame.getEmbeddedData().getEmbeddedFileExtension())
        ole_frame.setEmbeddedData(new_data)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Bädda in andra filtyper i bilder**

Förutom Excel‑diagram låter Aspose.Slides for Python via Java dig bädda in andra filtyper i bilder. Till exempel kan du infoga HTML‑, PDF‑ och ZIP‑filer som objekt. När en användare dubbelklickar på det infogade objektet öppnas det automatiskt i det relevanta programmet, eller så blir användaren ombedd att välja ett lämpligt program för att öppna det.

Denna Python‑kod visar hur du bäddar in HTML och ZIP i en bild:

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

## **Ange filtyper för inbäddade objekt**

När du arbetar med presentationer kan du behöva ersätta gamla OLE‑objekt med nya eller ersätta ett icke‑stött OLE‑objekt med ett stödd. Aspose.Slides for Python via Java låter dig ange filtypen för ett inbäddat objekt, vilket möjliggör att du uppdaterar OLE‑ramens data eller dess filändelse.

Denna Python‑kod visar hur du sätter filtypen för ett inbäddat OLE‑objekt till `zip`:

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

## **Ange ikonbilder och titlar för inbäddade objekt**

Efter att ett OLE‑objekt har bäddats in läggs automatiskt en förhandsgranskning bestående av en ikonbild till. Denna förhandsgranskning är vad användarna ser innan de öppnar eller får åtkomst till OLE‑objektet. Om du vill använda en specifik bild och text som element i förhandsgranskningen kan du ange ikonbilden och titeln med Aspose.Slides for Python via Java.

Denna Python‑kod visar hur du anger ikonbilden och titeln för ett inbäddat objekt:

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

    # Ange en titel och bilden för OLE‑förhandsgranskningen.
    ole_frame.setSubstitutePictureTitle("My title")
    ole_frame.getSubstitutePictureFormat().getPicture().setImage(ole_image)
    ole_frame.setObjectIcon(True)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Förhindra att en OLE‑objekt‑ram kan ändras i storlek och position**

Efter att du har lagt till ett länkat OLE‑objekt i en presentationsbild kan du vid öppning av presentationen i PowerPoint se ett meddelande som ber dig uppdatera länkarna. Att klicka på knappen ”Update Links” kan ändra storlek och position för OLE‑objekt‑ramen eftersom PowerPoint uppdaterar data från det länkade OLE‑objektet och förnyar förhandsgranskningen. För att hindra PowerPoint från att fråga om att uppdatera objektets data, sätt metoden [setUpdateAutomatic](https://reference.aspose.com/slides/sv/python-java/aspose.slides/oleobjectframe/#setUpdateAutomatic) för klassen [OleObjectFrame](https://reference.aspose.com/slides/sv/python-java/aspose.slides/oleobjectframe/) till `False`:

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

Aspose.Slides for Python via Java låter dig extrahera de filer som är inbäddade i bilder som OLE‑objekt på följande sätt:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/) som innehåller de OLE‑objekt du avser att extrahera.
2. Loopa igenom alla former i presentationen och få åtkomst till [OleObjectFrame](https://reference.aspose.com/slides/sv/python-java/aspose.slides/oleobjectframe/)‑formerna.
3. Få åtkomst till data för inbäddade filer från OLE‑objekt‑ramar och skriv dem till disk.

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

**Kommer OLE‑innehållet att renderas när bilder exporteras till PDF/bilder?**  
Det som är synligt på bilden renderas – ikonen/ersättningsbilden (förhandsgranskning). Det ”levande” OLE‑innehåll körs inte under rendering. Vid behov, sätt en egen förhandsgranskningsbild för att säkerställa önskat utseende i den exporterade PDF‑filen.

**Hur kan jag låsa ett OLE‑objekt på en bild så att användare inte kan flytta/redigera det i PowerPoint?**  
Lås formen: Aspose.Slides erbjuder [formnivå‑lås](/slides/sv/python-java/applying-protection-to-presentation/). Detta är ingen kryptering, men det förhindrar effektivt oavsiktliga redigeringar och förflyttningar.

**Varför hoppar ett länkat Excel‑objekt eller ändrar storlek när jag öppnar presentationen?**  
PowerPoint kan uppdatera förhandsgranskningen av det länkade OLE‑objektet. För ett stabilt utseende, följ rekommendationerna i [Working Solution for Worksheet Resizing](/slides/sv/python-java/working-solution-for-worksheet-resizing/) – anpassa antingen ramen till intervallet, eller skala intervallet till en fast ram och sätt en lämplig ersättningsbild.

**Kommer relativa sökvägar för länkade OLE‑objekt att bevaras i PPTX‑formatet?**  
I PPTX‑formatet finns ingen information om ”relativa sökvägar” – endast den fullständiga sökvägen. Relativa sökvägar finns i det äldre PPT‑formatet. För portabilitet, föredra pålitliga absoluta sökvägar/tillgängliga URI:er eller inbäddning.