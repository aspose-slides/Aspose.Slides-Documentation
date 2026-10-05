---
title: Hantera OLE i presentationer med Python
linktitle: Hantera OLE
type: docs
weight: 40
url: /sv/python-net/manage-ole/
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
- Aspose.Slides
description: "Optimera hanteringen av OLE-objekt i PowerPoint- och OpenDocument-filer med Aspose.Slides för Python via .NET. Bädda in, uppdatera och exportera OLE-innehåll sömlöst."
---
## **Introduktion**

{{% alert color="info" title="Note" %}}

**OLE (Object Linking & Embedding)** är en Microsoft-teknik som låter data och objekt som skapats i en applikation länkas eller bäddas in i en annan.

{{% /alert %}}

Till exempel är ett diagram som skapats i Microsoft Excel och placerats på en PowerPoint‑bild ett OLE‑objekt.

- Ett OLE‑objekt kan visas som en ikon. Att dubbelklicka på ikonen öppnar objektet i dess associerade program (t.ex. Excel) eller uppmanar dig att välja ett program för att öppna eller redigera det.
- Ett OLE‑objekt kan visa sitt innehåll (t.ex. ett diagram). I så fall aktiverar PowerPoint det inbäddade objektet, laddar diagramgränssnittet och låter dig redigera diagrammets data i PowerPoint.

Aspose.Slides för Python låter dig infoga OLE‑objekt i bilder som OLE‑objekt‑ramar ([OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/)).

## **Lägg till OLE‑objekt på bilder**

Om du redan har skapat ett diagram i Microsoft Excel och vill bädda in det i en bild som en OLE‑objekt‑ram med Aspose.Slides för Python, följ dessa steg:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Hämta en referens till bilden med dess index.
3. Läs in Excel‑filen till en byte‑array.
4. Lägg till ett [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) på bilden och ange byte‑arrayen samt övriga OLE‑objektdetaljer.
5. Spara den modifierade presentationen som en PPTX‑fil.

I exempel nedan är ett diagram från en Excel‑fil inbäddat i en bild som ett [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/).

**Obs:** Konstruktoren för [OleEmbeddedDataInfo](https://reference.aspose.com/slides/python-net/aspose.slides.dom.ole/oleembeddeddatainfo/) tar den inbäddade objektets filändelse som sin andra parameter. PowerPoint använder denna ändelse för att identifiera filtypen och välja lämpligt program för att öppna OLE‑objektet.

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide_size = presentation.slide_size.size
    slide = presentation.slides[0]

    # Förbered data för OLE-objektet.
    with open("book.xlsx", "rb") as file_stream:
        file_data = file_stream.read()
        data_info = slides.dom.ole.OleEmbeddedDataInfo(file_data, "xlsx")

    # Lägg till en OLE-objekt-ram på bilden.
    ole_frame = slide.shapes.add_ole_object_frame(0, 0, slide_size.width, slide_size.height, data_info)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

### **Lägg till länkade OLE‑objekt**

Aspose.Slides för Python låter dig lägga till ett [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) som länkar till en fil istället för att bädda in dess data.

Följande Python‑exempel visar hur man lägger till ett [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) länkat till en Excel‑fil på en bild:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Lägg till en OLE-objekt-ram med en länkad Excel-fil.
    slide.shapes.add_ole_object_frame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx")

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Åtkomst till OLE‑objekt**

Om ett OLE‑objekt redan är inbäddat i en bild kan du komma åt det enligt följande:

1. Läs in presentationen som innehåller det inbäddade OLE‑objektet genom att skapa en instans av Presentation‑klassen.
2. Hämta en referens till bilden med dess index.
3. Åtkomst till OleObjectFrame‑formen.
4. När du har OLE‑objekt‑ramen utför de nödvändiga operationerna på den.

I exemplet nedan nås OLE‑objekt‑ramen — ett inbäddat Excel‑diagram — och dess fildata hämtas. I detta exempel använder vi en PPTX som har en enda form på den första bilden.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    if isinstance(shape, slides.OleObjectFrame):
        ole_frame = shape

        # Hämta den inbäddade fildatan.
        file_data = ole_frame.embedded_data.embedded_file_data

        # Hämta filens filändelse.
        file_extension = ole_frame.embedded_data.embedded_file_extension

        # ...
```

### **Åtkomst till egenskaper för länkade OLE‑objekt**

Aspose.Slides låter dig komma åt egenskaperna för en länkad OLE‑objekt‑ram.

Python‑exemplet nedan kontrollerar om ett OLE‑objekt är länkat och, om så är fallet, hämtar sökvägen till den länkade filen:

```py
import aspose.slides as slides

with slides.Presentation("sample.ppt") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    if isinstance(shape, slides.OleObjectFrame):
        ole_frame = shape

        # Kontrollera om OLE-objektet är länkat.
        if ole_frame.is_object_link:
            # Skriv ut den fullständiga sökvägen till den länkade filen.
            print("OLE object frame is linked to:", ole_frame.link_path_long)

            # Skriv ut den relativa sökvägen till den länkade filen, om den finns.
            # Endast .ppt-presentationer kan innehålla en relativ sökväg.
            if ole_frame.link_path_relative:
                print("OLE object frame relative path:", ole_frame.link_path_relative)
```

## **Ändra OLE‑objektsdata**

{{% alert color="info" title="Note" %}}

I det här avsnittet använder kodexemplet nedan [Aspose.Cells for Python via .NET](https://docs.aspose.com/cells/python-net/).

{{% /alert %}}

Om ett OLE‑objekt redan är inbäddat i en bild kan du komma åt det och ändra dess data enligt följande:

1. Läs in presentationen genom att skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Hämta mål‑bilden med dess index.
3. Åtkomst till formen [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/).
4. När du har OLE‑objekt‑ramen utför de nödvändiga operationerna på den.
5. Skapa ett `Workbook`‑objekt och läs OLE‑data.
6. Öppna önskat `Worksheet` och redigera datan.
7. Spara den uppdaterade `Workbook` till en ström.
8. Ersätt OLE‑objektets data med hjälp av den strömmen.

I exemplet nedan nås en OLE‑objekt‑ram (ett inbäddat Excel‑diagram) och dess fildata ändras för att uppdatera diagrammet. Exemplet använder en tidigare skapad PPTX som innehåller en enda form på den första bilden.

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
            # Läs OLE-objektets data som ett Workbook-objekt.
            workbook = cells.Workbook(ole_stream)

        with io.BytesIO() as new_ole_stream:
            # Modifiera arbetsbokens data.
            workbook.worksheets.get(0).cells.get(0, 4).put_value("E")
            workbook.worksheets.get(0).cells.get(1, 4).put_value(12)
            workbook.worksheets.get(0).cells.get(2, 4).put_value(14)
            workbook.worksheets.get(0).cells.get(3, 4).put_value(15)

            file_options = cells.OoxmlSaveOptions(cells.SaveFormat.XLSX)
            workbook.save(new_ole_stream, file_options)

            # Ändra OLE-ramens objektdatat.
            new_data = slides.dom.ole.OleEmbeddedDataInfo(new_ole_stream.getvalue(), ole_frame.embedded_data.embedded_file_extension)
            ole_frame.set_embedded_data(new_data)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Bädda in filer i bilder**

Förutom Excel‑diagram låter Aspose.Slides för Python dig bädda in andra filtyper i bilder. Du kan till exempel infoga HTML‑, PDF‑ och ZIP‑filer som objekt. När en användare dubbelklickar på ett infogat objekt öppnas det automatiskt i det associerade programmet, eller så uppmanas användaren att välja ett lämpligt program.

Den här Python‑koden visar hur man bäddar in HTML‑ och ZIP‑filer i en bild:

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

## **Ställ in filtyper för inbäddade objekt**

När du arbetar med presentationer kan det vara nödvändigt att ersätta gamla OLE‑objekt med nya eller byta ut ett icke‑stödd OLE‑objekt mot ett stödd. Aspose.Slides för Python låter dig ange filtypen för ett inbäddat objekt, vilket gör att du kan uppdatera OLE‑ramens data eller dess filändelse.

Den här Python‑koden visar hur du ställer in den inbäddade OLE‑objektets filtyp till `zip`:

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    ole_frame = slide.shapes[0]

    file_extension = ole_frame.embedded_data.embedded_file_extension
    file_data = ole_frame.embedded_data.embedded_file_data

    print(f"Current embedded file extension is: {file_extension}")

    # Ändra filtypen till ZIP.
    ole_frame.set_embedded_data(slides.dom.ole.OleEmbeddedDataInfo(file_data, "zip"))

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Ställ in ikonbilder och titlar för inbäddade objekt**

När du har bäddat in ett OLE‑objekt läggs en ikonbaserad förhandsgranskning till automatiskt. Denna förhandsgranskning är vad användarna ser innan de öppnar eller åtkommer OLE‑objektet. Om du vill använda en specifik bild och text i förhandsgranskningen kan du ange ikonbilden och titeln med Aspose.Slides för Python.

Den här Python‑koden visar hur du anger ikonbilden och titeln för ett inbäddat objekt:

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    ole_frame = slide.shapes[0]

    # Lägg till en bild i presentationens resurser.
    with slides.Images.from_file("image.png") as image:
        ole_image = presentation.images.add_image(image)

    # Ange en titel och bilden för OLE‑förhandsvisning.
    ole_frame.substitute_picture_title = "My title"
    ole_frame.substitute_picture_format.picture.image = ole_image
    ole_frame.is_object_icon = True

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Förhindra att OLE‑objekt‑ramar ändras i storlek eller flyttas**

När du har lagt till ett länkat OLE‑objekt på en bild kan PowerPoint be dig att uppdatera länkarna när du öppnar presentationen. Att välja Uppdatera länkar kan ändra OLE‑objekt‑ramens storlek och position eftersom PowerPoint uppdaterar förhandsgranskningen med data från det länkade objektet. För att förhindra att PowerPoint ber dig att uppdatera objektets data, sätt egenskapen `update_automatic` för klassen [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) till `False`:

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    ole_frame = slide.shapes[0]

    ole_frame.update_automatic = False

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Extrahera inbäddade filer**

Aspose.Slides för Python låter dig extrahera filer som är inbäddade i bilder som OLE‑objekt på följande sätt:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) som innehåller de OLE‑objekt du vill extrahera.
2. Iterera genom alla former i presentationen och lokalisera OLEObjectFrame‑formerna.
3. Hämta den inbäddade fildatan från varje [OLEObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) och skriv den till disk.

Följande Python‑kod visar hur man extraherar filer som är inbäddade i en bild som OLE‑objekt:

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

**Kommer OLE‑innehållet att renderas när man exporterar bilder till PDF/bilder?**

Det som syns på bilden renderas — ikonen/ersättningsbilden (förhandsgranskning). Det "levande" OLE‑innehållet körs inte under rendering. Vid behov, ställ in en egen förhandsgranskningsbild för att säkerställa det förväntade utseendet i den exporterade PDF‑filen.

För att även behålla den inbäddade filen som en PDF‑bilaga, sätt [PdfOptions.include_ole_data](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/include_ole_data/) till `True`. Detta alternativ är inaktiverat som standard. För ett exempel och instruktioner för att kontrollera bilagan, se [Preserve Embedded OLE Files as PDF Attachments](/slides/sv/python-net/convert-powerpoint-to-pdf/#preserve-embedded-ole-files-as-pdf-attachments).

**Hur kan jag låsa ett OLE‑objekt på en bild så att användare inte kan flytta/redigera det i PowerPoint?**

Lås formen: Aspose.Slides erbjuder [shape-level locks](/slides/sv/python-net/applying-protection-to-presentation/). Detta är ingen kryptering, men det förhindrar effektivt oavsiktliga redigeringar och flyttningar.

**Varför "hoppar" ett länkat Excel‑objekt eller ändrar storlek när jag öppnar presentationen?**

PowerPoint kan uppdatera förhandsgranskningen av den länkade OLE:n. För ett stabilt utseende, följ praxis i [Working Solution for Worksheet Resizing](/slides/sv/python-net/working-solution-for-worksheet-resizing/) — antingen anpassa ramen till området, eller skala området till en fast ram och ange en lämplig ersättningsbild.

**Kommer relativa sökvägar för länkade OLE‑objekt att bevaras i PPTX‑formatet?**

I PPTX finns ingen information om "relativ sökväg" — endast den fullständiga sökvägen. Relativa sökvägar finns i det äldre PPT‑formatet. För portabilitet, föredra pålitliga absoluta sökvägar/tillgängliga URI:er eller inbäddning.