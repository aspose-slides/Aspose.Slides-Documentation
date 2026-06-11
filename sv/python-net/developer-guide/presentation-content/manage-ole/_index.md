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
- Aspose.Slides
description: "Optimera hanteringen av OLE-objekt i PowerPoint- och OpenDocument-filer med Aspose.Slides för Python via .NET. Bädda in, uppdatera och exportera OLE-innehåll sömlöst."
---
## **Introduction**

{{% alert title="Info" color="info" %}}

**OLE (Object Linking & Embedding)** är en Microsoft‑teknik som låter data och objekt som skapats i en applikation länkas eller bäddas in i en annan.

{{% /alert %}}

Till exempel är ett diagram som skapats i Microsoft Excel och placerats på en PowerPoint‑bild ett OLE‑objekt.

- Ett OLE‑objekt kan visas som en ikon. Om du dubbelklickar på ikonen öppnas objektet i dess associerade program (t.ex. Excel) eller så får du en uppmaning att välja ett program för att öppna eller redigera det.
- Ett OLE‑objekt kan visa sitt innehåll (till exempel ett diagram). I så fall aktiverar PowerPoint det inbäddade objektet, läser in diagramgränssnittet och låter dig redigera diagrammets data i PowerPoint.

Aspose.Slides för Python låter dig infoga OLE‑objekt i bilder som OLE‑objektramlar ([OleObjectFrame](https://reference.aspose.com/slides/sv/python-net/aspose.slides/oleobjectframe/)).

## **Add OLE Objects to Slides**

Om du redan har skapat ett diagram i Microsoft Excel och vill bädda in det i en bild som ett OLE‑objektram med Aspose.Slides för Python, följ dessa steg:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/).
1. Hämta en referens till bilden genom dess index.
1. Läs Excel‑filen till en byte‑array.
1. Lägg till ett [OleObjectFrame](https://reference.aspose.com/slides/sv/python-net/aspose.slides/oleobjectframe/) på bilden och ange byte‑arrayen samt övriga OLE‑objektdetaljer.
1. Spara den modifierade presentationen som en PPTX‑fil.

I exemplet nedan är ett diagram från en Excel‑fil inbäddat i en bild som ett [OleObjectFrame](https://reference.aspose.com/slides/sv/python-net/aspose.slides/oleobjectframe/).

**Obs:** Konstruktorn för [OleEmbeddedDataInfo](https://reference.aspose.com/slides/sv/python-net/aspose.slides.dom.ole/oleembeddeddatainfo/) tar den inbäddningsbara objektets filtillägg som sin andra parameter. PowerPoint använder detta tillägg för att identifiera filtypen och välja rätt program för att öppna OLE‑objektet.

```py
with slides.Presentation() as presentation:
    slide_size = presentation.slide_size.size
    slide = presentation.slides[0]

    # Förbered data för OLE-objektet.
    with open("book.xlsx", "rb") as file_stream:
        file_data = file_stream.read()
        data_info = slides.dom.ole.OleEmbeddedDataInfo(file_data, "xlsx")

    # Lägg till en OLE-objektram på bilden.
    ole_frame = slide.shapes.add_ole_object_frame(0, 0, slide_size.width, slide_size.height, data_info)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

### **Add Linked OLE Objects**

Aspose.Slides för Python låter dig lägga till ett [OleObjectFrame](https://reference.aspose.com/slides/sv/python-net/aspose.slides/oleobjectframe/) som länkar till en fil i stället för att bädda in dess data.

Följande Python‑exempel visar hur du lägger till ett [OleObjectFrame](https://reference.aspose.com/slides/sv/python-net/aspose.slides/oleobjectframe/) länkat till en Excel‑fil på en bild:

```py
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Lägg till en OLE-objektram med en länkad Excel-fil.
    slide.shapes.add_ole_object_frame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx")

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Access OLE Objects**

Om ett OLE‑objekt redan är inbäddat i en bild kan du komma åt det på följande sätt:

1. Skapa en instans av klassen Presentation som innehåller det inbäddade OLE‑objektet.
1. Hämta en referens till bilden genom dess index.
1. Åtkom OleObjectFrame‑formen.
1. När du har OLE‑objektram‑ramen kan du utföra önskade operationer på den.

Exemplet nedan hämtar OLE‑objektram‑ramen – ett inbäddat Excel‑diagram – och läser dess fildata. I detta exempel använder vi en PPTX‑fil som har en enda form på den första bilden.

```py
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    if isinstance(shape, slides.OleObjectFrame):
        ole_frame = shape

        # Hämta den inbäddade filens data.
        file_data = ole_frame.embedded_data.embedded_file_data

        # Hämta filtillägget för den inbäddade filen.
        file_extension = ole_frame.embedded_data.embedded_file_extension

        # ...
```

### **Access Linked OLE Object Properties**

Aspose.Slides låter dig komma åt egenskaperna för en länkad OLE‑objektram.

Python‑exemplet nedan kontrollerar om ett OLE‑objekt är länkat och, om så är fallet, hämtar sökvägen till den länkade filen:

```py
with slides.Presentation("sample.ppt") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    if isinstance(shape, slides.OleObjectFrame):
        ole_frame = shape

        # Kontrollera om OLE-objektet är länkat.
        if ole_frame.is_object_link:
            # Skriv ut hela sökvägen till den länkade filen.
            print("OLE object frame is linked to:", ole_frame.link_path_long)

            # Skriv ut den relativa sökvägen till den länkade filen, om den finns.
            # Endast .ppt-presentationer kan innehålla en relativ sökväg.
            if ole_frame.link_path_relative:
                print("OLE object frame relative path:", ole_frame.link_path_relative)
```

## **Change OLE Object Data**

{{% alert color="primary" %}}

I det här avsnittet använder kodexemplet nedan [Aspose.Cells for Python via .NET](/cells/python-net/).

{{% /alert %}}

Om ett OLE‑objekt redan är inbäddat i en bild kan du komma åt det och ändra dess data på följande sätt:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/).
1. Hämta mål‑bilden genom dess index.
1. Åtkom formen [OleObjectFrame](https://reference.aspose.com/slides/sv/python-net/aspose.slides/oleobjectframe/).
1. När du har OLE‑objektram‑ramen kan du utföra de nödvändiga operationerna på den.
1. Skapa ett `Workbook`‑objekt och läs OLE‑data.
1. Öppna önskad `Worksheet` och redigera data.
1. Spara den uppdaterade `Workbook`‑en till en ström.
1. Ersätt OLE‑objektets data med den strömmen.

Exemplet nedan visar hur ett OLE‑objektram (ett inbäddat Excel‑diagram) hämtas och hur dess fildata modifieras för att uppdatera diagrammet. Exemplet använder en tidigare skapad PPTX‑fil som innehåller en enda form på den första bilden.

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
            # Ändra workbook-data.
            workbook.worksheets.get(0).cells.get(0, 4).put_value("E")
            workbook.worksheets.get(0).cells.get(1, 4).put_value(12)
            workbook.worksheets.get(0).cells.get(2, 4).put_value(14)
            workbook.worksheets.get(0).cells.get(3, 4).put_value(15)

            file_options = cells.OoxmlSaveOptions(cells.SaveFormat.XLSX)
            workbook.save(new_ole_stream, file_options)

            # Ändra OLE-ramens objektdata.
            new_data = slides.dom.ole.OleEmbeddedDataInfo(new_ole_stream.getvalue(), ole_frame.embedded_data.embedded_file_extension)
            ole_frame.set_embedded_data(new_data)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Embed Files in Slides**

Förutom Excel‑diagram låter Aspose.Slides för Python dig bädda in andra filtyper i bilder. Du kan till exempel infoga HTML‑, PDF‑ och ZIP‑filer som objekt. När en användare dubbelklickar på ett infogat objekt öppnas det automatiskt i det associerade programmet, eller så får användaren en uppmaning att välja ett lämpligt program.

Denna Python‑kod visar hur du bäddar in HTML‑ och ZIP‑filer i en bild:

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

## **Set File Types for Embedded Objects**

När du arbetar med presentationer kan du behöva ersätta gamla OLE‑objekt med nya eller byta ut ett icke‑stött OLE‑objekt mot ett som stöds. Aspose.Slides för Python låter dig ange filtypen för ett inbäddat objekt, vilket gör att du kan uppdatera OLE‑ramens data eller dess filtillägg.

Denna Python‑kod visar hur du anger den inbäddade OLE‑objektets filtyp till `zip`:

```py
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

## **Set Icon Images and Titles for Embedded Objects**

Efter att du har bäddat in ett OLE‑objekt läggs en ikonbaserad förhandsvisning automatiskt till. Denna förhandsvisning är vad användarna ser innan de får åtkomst till eller öppnar OLE‑objektet. Om du vill använda en specifik bild och text i förhandsvisningen kan du ange ikonbilden och titeln med Aspose.Slides för Python.

Denna Python‑kod visar hur du anger ikonbilden och titeln för ett inbäddat objekt:

```py
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    ole_frame = slide.shapes[0]

    # Lägg till en bild till presentationens resurser.
    with slides.Images.from_file("image.png") as image:
        ole_image = presentation.images.add_image(image)

    # Ange en titel och bilden för OLE-förhandsvisningen.
    ole_frame.substitute_picture_title = "My title"
    ole_frame.substitute_picture_format.picture.image = ole_image
    ole_frame.is_object_icon = True

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Prevent OLE Object Frames from Being Resized and Pepositioned**

Efter att du har lagt till ett länkat OLE‑objekt på en bild kan PowerPoint uppmana dig att uppdatera länkar när du öppnar presentationen. Att välja 'Uppdatera länkar' kan ändra OLE‑objektramens storlek och position eftersom PowerPoint uppdaterar förhandsvisningen med data från det länkade objektet. För att förhindra att PowerPoint ber dig uppdatera objektets data, sätt egenskapen `update_automatic` för klassen [OleObjectFrame](https://reference.aspose.com/slides/sv/python-net/aspose.slides/oleobjectframe/) till `False`:

```py
ole_frame.update_automatic = False
```

## **Extract Embedded Files**

Aspose.Slides för Python låter dig extrahera filer som är inbäddade i bilder som OLE‑objekt på följande sätt:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/) som innehåller de OLE‑objekt du vill extrahera.
1. Iterera igenom alla former i presentationen och lokalisera OLEObjectFrame‑former.
1. Hämta den inbäddade fildatan från varje [OLEObjectFrame](https://reference.aspose.com/slides/sv/python-net/aspose.slides/oleobjectframe/) och skriv den till disk.

Följande Python‑kod visar hur du extraherar filer som är inbäddade i en bild som OLE‑objekt:

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

**Will the OLE content be rendered when exporting slides to PDF/images?**  
**Kommer OLE‑innehållet att renderas när bilder exporteras till PDF/bilder?**  
Det som syns på bilden renderas – ikonen/substitutionsbilden (förhandsvisning). Det "levande" OLE‑innehållet körs inte under rendering. Om så behövs, ange en egen förhandsvisningsbild för att säkerställa det förväntade utseendet i den exporterade PDF‑filen.

**How can I lock an OLE object on a slide so users cannot move/edit it in PowerPoint?**  
**Hur kan jag låsa ett OLE‑objekt på en bild så att användare inte kan flytta/redigera det i PowerPoint?**  
Lås formen: Aspose.Slides tillhandahåller [shape-level locks](/slides/sv/python-net/applying-protection-to-presentation/). Detta är ingen kryptering, men det förhindrar effektivt oavsiktliga redigeringar och förflyttning.

**Why does a linked Excel object "jump" or change size when I open the presentation?**  
**Varför hoppar ett länkat Excel‑objekt eller ändrar storlek när jag öppnar presentationen?**  
PowerPoint kan uppdatera förhandsvisningen av det länkade OLE‑objektet. För ett stabilt utseende, följ bästa praxis i [Working Solution for Worksheet Resizing](/slides/sv/python-net/working-solution-for-worksheet-resizing/) – antingen anpassa ramen till området eller skala området till en fast ram och ange en lämplig substitutionsbild.

**Will relative paths for linked OLE objects be preserved in the PPTX format?**  
**Kommer relativa sökvägar för länkade OLE‑objekt att bevaras i PPTX‑formatet?**  
I PPTX finns ingen information om "relativ sökväg" – endast den fullständiga sökvägen. Relativa sökvägar finns i det äldre PPT‑formatet. För portabilitet, föredra pålitliga absoluta sökvägar/tillgängliga URI:er eller inbäddning.