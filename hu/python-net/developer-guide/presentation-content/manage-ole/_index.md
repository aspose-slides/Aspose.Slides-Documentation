---
title: OLE kezelése prezentációkban Python használatával
linktitle: OLE kezelése
type: docs
weight: 40
url: /hu/python-net/manage-ole/
keywords:
- OLE objektum
- Objektum összekapcsolása és beágyazása
- OLE hozzáadása
- OLE beágyazása
- objektum hozzáadása
- objektum beágyazása
- fájl hozzáadása
- fájl beágyazása
- kapcsolt objektum
- kapcsolt fájl
- OLE módosítása
- OLE ikon
- OLE cím
- OLE kinyerése
- objektum kinyerése
- fájl kinyerése
- PowerPoint
- prezentáció
- Python
- Aspose.Slides
description: "Optimalizálja az OLE objektumkezelést PowerPoint és OpenDocument fájlokban az Aspose.Slides for Python via .NET segítségével. Ágyazzon be, frissítsen és exportáljon OLE tartalmat zökkenőmentesen."
---
## **Bevezetés**

{{% alert color="info" title="Note" %}}

**OLE (Object Linking & Embedding)** egy Microsoft technológia, amely lehetővé teszi, hogy egy alkalmazásban létrehozott adatokat és objektumokat másik alkalmazásba linkeljük vagy beágyazzuk.

{{% /alert %}}

Például egy Microsoft Excelben létrehozott diagram, amelyet egy PowerPoint diára helyeznek, OLE objektum.

- Egy OLE objektum ikonként jelenhet meg. Az ikon duplakattintása megnyitja az objektumot a kapcsolódó alkalmazásban (például Excel), vagy arra kéri a felhasználót, hogy válasszon egy programot a megnyitáshoz vagy szerkesztéshez.
- Egy OLE objektum megjelenítheti a tartalmát (például egy diagram). Ebben az esetben a PowerPoint aktiválja a beágyazott objektumot, betölti a diagram felületét, és lehetővé teszi a diagram adatainak szerkesztését a PowerPointon belül.

Az Aspose.Slides for Python lehetővé teszi OLE objektumok beszúrását diákba OLE objektumkeretként ([OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/)).

## **OLE objektumok hozzáadása diákhoz**

Ha már létrehozott egy diagramot a Microsoft Excelben, és szeretné azt OLE objektumkeretként beágyazni egy diára az Aspose.Slides for Python használatával, kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) osztályból.
1. Szerezzen hivatkozást a diára index alapján.
1. Olvassa be az Excel fájlt bájt tömbbe.
1. Adjon hozzá egy [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) keretet a diához, a bájt tömböt és egyéb OLE objektum részleteket megadva.
1. Mentse a módosított prezentációt PPTX fájlként.

Az alábbi példában egy Excel fájlból származó diagramot ágyazunk be egy diára [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) keretként.

**Megjegyzés:** A [OleEmbeddedDataInfo](https://reference.aspose.com/slides/python-net/aspose.slides.dom.ole/oleembeddeddatainfo/) konstruktor második paramétereként az beágyazható objektum fájlkiterjesztését fogadja. A PowerPoint ezt a kiterjesztést használja a fájltípus azonosítására, és a megfelelő alkalmazást a OLE objektum megnyitásához.

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide_size = presentation.slide_size.size
    slide = presentation.slides[0]

    # Készítse elő az OLE objektum adatait.
    with open("book.xlsx", "rb") as file_stream:
        file_data = file_stream.read()
        data_info = slides.dom.ole.OleEmbeddedDataInfo(file_data, "xlsx")

    # OLE objektumkeret hozzáadása a diához.
    ole_frame = slide.shapes.add_ole_object_frame(0, 0, slide_size.width, slide_size.height, data_info)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

### **Kapcsolt OLE objektumok hozzáadása**

Az Aspose.Slides for Python lehetővé teszi, hogy egy [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) keretet hozzon létre, amely egy fájlra hivatkozik a beágyazás helyett.

Az alábbi Python példa bemutatja, hogyan adjon egy [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) keretet, amely egy Excel fájlra hivatkozik egy dián:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # OLE objektumkeret hozzáadása egy kapcsolt Excel fájllal.
    slide.shapes.add_ole_object_frame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx")

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **OLE objektumok elérése**

Ha egy OLE objektum már be van ágyazva egy diára, a következőképpen érheti el:

1. Töltse be a prezentációt, amely tartalmazza a beágyazott OLE objektumot, egy Presentation példány létrehozásával.
1. Szerezzen hivatkozást a diára index alapján.
1. Érje el az OleObjectFrame alakzatot.
1. Miután megkapta az OLE objektumkeretet, végezze el a szükséges műveleteket.

Az alábbi példa eléri az OLE objektumkeretet – egy beágyazott Excel diagramot – és lekéri annak fájladatait. Ebben a példában egy PPTX-et használunk, amelyen az első dián egyetlen alakzat van.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    if isinstance(shape, slides.OleObjectFrame):
        ole_frame = shape

        # Szerezze meg a beágyazott fájl adatait.
        file_data = ole_frame.embedded_data.embedded_file_data

        # Szerezze meg a beágyazott fájl kiterjesztését.
        file_extension = ole_frame.embedded_data.embedded_file_extension

        # ...
```

### **Kapcsolt OLE objektum tulajdonságainak elérése**

Az Aspose.Slides lehetővé teszi a kapcsolt OLE objektumkeret tulajdonságainak elérését.

Az alábbi Python példa ellenőrzi, hogy egy OLE objektum kapcsolt-e, és ha igen, lekéri a kapcsolt fájl elérési útját:

```py
import aspose.slides as slides

with slides.Presentation("sample.ppt") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    if isinstance(shape, slides.OleObjectFrame):
        ole_frame = shape

        # Ellenőrizze, hogy az OLE objektum kapcsolt-e.
        if ole_frame.is_object_link:
            # Írja ki a kapcsolt fájl teljes útvonalát.
            print("OLE object frame is linked to:", ole_frame.link_path_long)

            # Írja ki a kapcsolt fájl relatív útvonalát, ha létezik.
            # Csak .ppt prezentációk tartalmazhatnak relatív útvonalat.
            if ole_frame.link_path_relative:
                print("OLE object frame relative path:", ole_frame.link_path_relative)
```

## **OLE objektum adatok módosítása**

{{% alert color="info" title="Note" %}}

Ebben a szakaszban az alábbi kódrészlet a [Aspose.Cells for Python via .NET](https://docs.aspose.com/cells/python-net/) használatával készül.

{{% /alert %}}

Ha egy OLE objektum már be van ágyazva egy diára, a következőképpen érheti el és módosíthatja az adatait:

1. Töltse be a prezentációt egy [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) példány létrehozásával.
1. Szerezze meg a cél diát index alapján.
1. Érje el a [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) alakzatot.
1. Miután megvan az OLE objektumkeret, végezze el a szükséges műveleteket.
1. Hozzon létre egy `Workbook` objektumot és olvassa be az OLE adatokat.
1. Nyissa meg a kívánt `Worksheet`-et és szerkessze az adatokat.
1. Mentse a frissített `Workbook`-ot egy folyamba.
1. Cserélje le az OLE objektum adatait a folyam használatával.

Az alábbi példában egy OLE objektumkeret (egy beágyazott Excel diagram) kerül elérésre, és a fájladatai módosulnak a diagram frissítéséhez. A minta egy korábban létrehozott PPTX-et használ, amely egyetlen alakzatot tartalmaz az első dián.

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
            # Olvassa be az OLE objektum adatait Workbook objektumként.
            workbook = cells.Workbook(ole_stream)

        with io.BytesIO() as new_ole_stream:
            # Módosítsa a munkafüzet adatait.
            workbook.worksheets.get(0).cells.get(0, 4).put_value("E")
            workbook.worksheets.get(0).cells.get(1, 4).put_value(12)
            workbook.worksheets.get(0).cells.get(2, 4).put_value(14)
            workbook.worksheets.get(0).cells.get(3, 4).put_value(15)

            file_options = cells.OoxmlSaveOptions(cells.SaveFormat.XLSX)
            workbook.save(new_ole_stream, file_options)

            # Cserélje ki az OLE keret objektum adatait.
            new_data = slides.dom.ole.OleEmbeddedDataInfo(new_ole_stream.getvalue(), ole_frame.embedded_data.embedded_file_extension)
            ole_frame.set_embedded_data(new_data)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Fájlok beágyazása diákba**

Az Excel diagramok mellett az Aspose.Slides for Python más fájltípusok beágyazását is lehetővé teszi diákba. Például HTML, PDF és ZIP fájlokat helyezhet el objektumként. Amikor a felhasználó duplán kattint egy beszúrt objektumra, az automatikusan megnyílik a kapcsolódó alkalmazásban, vagy felkérik a megfelelő program kiválasztására.

Ez a Python kód bemutatja, hogyan ágyazzon be HTML és ZIP fájlokat egy diára:

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

## **Beágyazott objektumok fájltípusának beállítása**

Prezentációk kezelésénél előfordulhat, hogy régi OLE objektumokat kell cserélni újakra, vagy egy nem támogatott OLE objektumot egy támogatottra. Az Aspose.Slides for Python lehetővé teszi a beágyazott objektum fájltípusának beállítását, így frissítheti az OLE keret adatokat vagy a fájlkiterjesztést.

Ez a Python kód megmutatja, hogyan állítsa be a beágyazott OLE objektum fájltípusát `zip`-re:

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    ole_frame = slide.shapes[0]

    file_extension = ole_frame.embedded_data.embedded_file_extension
    file_data = ole_frame.embedded_data.embedded_file_data

    print(f"Current embedded file extension is: {file_extension}")

    # A fájltípus ZIP-re módosítása.
    ole_frame.set_embedded_data(slides.dom.ole.OleEmbeddedDataInfo(file_data, "zip"))

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Ikonkép és cím beállítása beágyazott objektumokhoz**

Miután beágyazott egy OLE objektumot, egy ikon alapú előnézet kerül automatikusan hozzáadásra. Ez az előnézet az, amit a felhasználók látnak, mielőtt hozzáférnének vagy megnyitnák az OLE objektumot. Ha egy meghatározott képet és szöveget szeretne az előnézetben, az Aspose.Slides for Python segítségével beállíthatja az ikon képet és címét.

Ez a Python kód mutatja, hogyan állítsa be az ikon képet és címet egy beágyazott objektumhoz:

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    ole_frame = slide.shapes[0]

    # Kép hozzáadása a prezentáció erőforrásaihoz.
    with slides.Images.from_file("image.png") as image:
        ole_image = presentation.images.add_image(image)

    # Cím és kép beállítása az OLE előnézethez.
    ole_frame.substitute_picture_title = "My title"
    ole_frame.substitute_picture_format.picture.image = ole_image
    ole_frame.is_object_icon = True

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Az OLE objektumkeretek átméretezésének és áthelyezésének megakadályozása**

Miután egy kapcsolt OLE objektumot ad hozzá egy diára, a PowerPoint felszólíthatja a linkek frissítésére a prezentáció megnyitásakor. A „Linkek frissítése” kiválasztása megváltoztathatja az OLE objektumkeret méretét és pozícióját, mivel a PowerPoint frissíti az előnézetet a kapcsolt objektum adataival. A PowerPoint felkérést elkerülendő, hogy frissítse az objektum adatait, állítsa a [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) osztály `update_automatic` tulajdonságát `False`-ra:

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    ole_frame = slide.shapes[0]

    ole_frame.update_automatic = False

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Beágyazott fájlok kinyerése**

Az Aspose.Slides for Python lehetővé teszi a diákba beágyazott OLE objektumként tárolt fájlok kinyerését a következő módon:

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) példányt, amely tartalmazza a kinyerni kívánt OLE objektumokat.
1. Iteráljon végig a prezentáció összes alakzaton, és keresse meg az OLEObjectFrame alakzatokat.
1. Szerezze meg a beágyazott fájladatokat minden [OLEObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) esetén, és írja őket lemezre.

Az alábbi Python kód megmutatja, hogyan kinyerjen fájlokat, amelyek OLE objektumként vannak beágyazva egy dián:

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

## **GYIK**

**Megjelenik-e az OLE tartalom a diák PDF/képek exportálásakor?**

Az, ami a dián látható, renderelődik – az ikon/helyettesítő kép (előnézet). A „valódi” OLE tartalom nem kerül végrehajtásra a renderelés során. Ha szükséges, állítson be saját előnézeti képet, hogy a várt megjelenés biztosítva legyen az exportált PDF-ben.

A beágyazott fájl PDF mellékletként való megőrzéséhez állítsa a [PdfOptions.include_ole_data](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/include_ole_data/) értékét `True`-ra. Ez a beállítás alapértelmezés szerint le van tiltva. Példa és az ellenőrzés módja megtalálható a [Beágyazott OLE fájlok megőrzése PDF mellékletként](/slides/hu/python-net/convert-powerpoint-to-pdf/#preserve-embedded-ole-files-as-pdf-attachments) oldalon.

**Hogyan zárhatom le egy OLE objektumot a dián, hogy a felhasználók ne mozgassák vagy szerkesszék PowerPointban?**

Zárolja az alakzatot: az Aspose.Slides [alakzatszintű zárolások](/slides/hu/python-net/applying-protection-to-presentation/) funkciót biztosít. Ez nem titkosítás, de hatékonyan megakadályozza a véletlen szerkesztéseket és mozgatásokat.

**Miért “jump” vagy méretet változtat egy kapcsolt Excel objektum, amikor megnyitom a prezentációt?**

A PowerPoint frissítheti a kapcsolt OLE előnézetét. A stabil megjelenésért kövesse a [Működő megoldás munkalap átméretezéshez](/slides/hu/python-net/working-solution-for-worksheet-resizing/) gyakorlatokat – vagy illessze a keretet a tartományhoz, vagy méretezze a tartományt egy rögzített keretre, és állítson be megfelelő helyettesítő képet.

**Megmaradnak-e a kapcsolt OLE objektumok relatív útvonalai a PPTX formátumban?**

A PPTX-ben a “relative path” információ nem érhető el – csak a teljes útvonal. A relatív útvonalak a régebbi PPT formátumban találhatók. A hordozhatóság érdekében javasolt megbízható abszolút útvonalakat / elérhető URI-ket vagy beágyazást használni.