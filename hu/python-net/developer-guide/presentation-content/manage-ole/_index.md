---
title: OLE kezelése prezentációkban Python segítségével
linktitle: OLE kezelése
type: docs
weight: 40
url: /hu/python-net/manage-ole/
keywords:
- OLE objektum
- Objektum hivatkozás és beágyazás
- OLE hozzáadása
- OLE beágyazása
- objektum hozzáadása
- objektum beágyazása
- fájl hozzáadása
- fájl beágyazása
- hivatkozott objektum
- hivatkozott fájl
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
description: "Optimalizálja az OLE objektumok kezelését PowerPoint és OpenDocument fájlokban az Aspose.Slides for Python via .NET segítségével. Könnyedén ágyazza be, frissítse és exportálja az OLE tartalmat."
---
## **Bevezetés**

{{% alert title="Info" color="info" %}}

**OLE (Object Linking & Embedding)** egy Microsoft technológia, amely lehetővé teszi, hogy egy alkalmazásban létrehozott adatokat és objektumokat egy másik alkalmazásba linkeljék vagy beágyazzák.

{{% /alert %}}

Például egy Microsoft Excelben létrehozott diagram, amely egy PowerPoint diára kerül, OLE-objektum.

- Az OLE-objektum megjelenhet ikonként. A double‑click megnyitja az objektumot a hozzárendelt alkalmazásban (pl. Excel), vagy felszéri a felhasználót, hogy válasszon egy alkalmazást a megnyitáshoz vagy szerkesztéshez.
- Az OLE-objektum megjelenítheti a tartalmát (például egy diagramot). Ebben az esetben a PowerPoint aktiválja a beágyazott objektumot, betölti a diagram felületét, és lehetővé teszi a diagram adatainak szerkesztését a PowerPointon belül.

Az Aspose.Slides for Python lehetővé teszi OLE‑objektumok beszúrását diákba OLE‑objektumkeretként ([OleObjectFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/oleobjectframe/)).

## **OLE‑objektumok hozzáadása diákhoz**

Ha már létrehoztál egy diagramot a Microsoft Excelben, és OLE‑objektumkeretként szeretnéd beágyazni egy diára az Aspose.Slides for Python segítségével, kövesd az alábbi lépéseket:

1. Hozz létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztályból.
1. Szerezd meg a dia referenciáját az indexe alapján.
1. Olvasd be az Excel‑fájlt byte‑tömbbe.
1. Adj hozzá egy [OleObjectFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/oleobjectframe/) elemet a diához, megadva a byte‑tömböt és egyéb OLE‑objektum részleteket.
1. Mentsd el a módosított prezentációt PPTX fájlként.

Az alábbi példában egy Excel‑fájlból származó diagram be van ágyazva egy diára [OleObjectFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/oleobjectframe/)ként.

**Megjegyzés:** A [OleEmbeddedDataInfo](https://reference.aspose.com/slides/hu/python-net/aspose.slides.dom.ole/oleembeddeddatainfo/) konstruktorának második paramétere a beágyazandó objektum fájlkiterjesztése. A PowerPoint ezt a kiterjesztést használja a fájltípus azonosításához és a megfelelő alkalmazás kiválasztásához az OLE‑objektum megnyitásához.

```py
with slides.Presentation() as presentation:
    slide_size = presentation.slide_size.size
    slide = presentation.slides[0]

    # Készítse elő az OLE objektum adatait.
    with open("book.xlsx", "rb") as file_stream:
        file_data = file_stream.read()
        data_info = slides.dom.ole.OleEmbeddedDataInfo(file_data, "xlsx")

    # Adjon hozzá egy OLE objektumkeretet a diára.
    ole_frame = slide.shapes.add_ole_object_frame(0, 0, slide_size.width, slide_size.height, data_info)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

### **Linkelt OLE‑objektumok hozzáadása**

Az Aspose.Slides for Python lehetővé teszi egy [OleObjectFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/oleobjectframe/) hozzáadását, amely egy fájlra hivatkozik a beágyazás helyett.

Az alábbi Python‑példa bemutatja, hogyan adhatunk egy Excel‑fájlra hivatkozó [OleObjectFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/oleobjectframe/) elemet egy diára:

```py
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Adj hozzá egy OLE objektumkeretet egy linkelt Excel fájllal.
    slide.shapes.add_ole_object_frame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx")

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **OLE‑objektumok elérése**

Ha egy OLE‑objektum már be van ágyazva egy diára, a következő módon érheted el:

1. Töltsd be a prezentációt, amely tartalmazza a beágyazott OLE‑objektumot, egy Presentation példány létrehozásával.
1. Szerezd meg a dia referenciáját az indexe alapján.
1. Érj el az OleObjectFrame alakzatot.
1. Miután megvan az OLE‑objektumkeret, végezz el rajta minden szükséges műveletet.

Az alábbi példa hozzáfér az OLE‑objektumkerethez – egy beágyazott Excel‑diagramhoz – és lekéri a fájl adatait. Ebben a példában egy PPTX‑fájlt használunk, amelynek az első dián egyetlen alakzata van.

```py
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    if isinstance(shape, slides.OleObjectFrame):
        ole_frame = shape

        # Szerezze be a beágyazott fájl adatait.
        file_data = ole_frame.embedded_data.embedded_file_data

        # Szerezze be a beágyazott fájl kiterjesztését.
        file_extension = ole_frame.embedded_data.embedded_file_extension

        # ...
```

### **Linkelt OLE‑objektum tulajdonságainak elérése**

Az Aspose.Slides lehetővé teszi a linkelt OLE‑objektumkeret tulajdonságainak elérését.

Az alábbi Python‑példa ellenőrzi, hogy egy OLE‑objektum linkelt‑e, és ha igen, lekéri a linkelt fájl útvonalát:

```py
with slides.Presentation("sample.ppt") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    if isinstance(shape, slides.OleObjectFrame):
        ole_frame = shape

        # Ellenőrizze, hogy az OLE objektum linkelt-e.
        if ole_frame.is_object_link:
            # Írja ki a linkelt fájl teljes útvonalát.
            print("OLE object frame is linked to:", ole_frame.link_path_long)

            # Írja ki a linkelt fájl relatív útvonalát, ha létezik.
            # Csak .ppt prezentációk tartalmazhatnak relatív útvonalat.
            if ole_frame.link_path_relative:
                print("OLE object frame relative path:", ole_frame.link_path_relative)
```

## **OLE‑objektum adatainak módosítása**

{{% alert color="primary" %}}

Ebben a szakaszban az alábbi kódrészlet a [Aspose.Cells for Python via .NET](/cells/python-net/) használatát mutatja be.

{{% /alert %}}

Ha egy OLE‑objektum már be van ágyazva egy diára, a következő módon érheted el és módosíthatod az adatait:

1. Hozz létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztályból.
1. Szerezd meg a cél dia referenciáját az indexe alapján.
1. Érj el egy [OleObjectFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/oleobjectframe/) alakzatot.
1. Miután megvan az OLE‑objektumkeret, végrehajthatod a szükséges műveleteket.
1. Hozz létre egy `Workbook` objektumot és olvasd be az OLE‑adatokat.
1. Nyisd meg a kívánt `Worksheet`‑et és szerkeszd az adatokat.
1. Mentsd el a frissített `Workbook`‑ot egy streamba.
1. Cseréld le az OLE‑objektum adatait a stream használatával.

Az alábbi példában egy OLE‑objektumkeret (beágyazott Excel‑diagram) adatait módosítjuk, hogy frissítsük a diagramot. A minta egy korábban létrehozott PPTX‑fájlt használ, amelynek az első dián egyetlen alakzata van.

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
            # Olvassa be az OLE objektum adatát Workbook objektumként.
            workbook = cells.Workbook(ole_stream)

        with io.BytesIO() as new_ole_stream:
            # Módosítsa a munkafüzet adatait.
            workbook.worksheets.get(0).cells.get(0, 4).put_value("E")
            workbook.worksheets.get(0).cells.get(1, 4).put_value(12)
            workbook.worksheets.get(0).cells.get(2, 4).put_value(14)
            workbook.worksheets.get(0).cells.get(3, 4).put_value(15)

            file_options = cells.OoxmlSaveOptions(cells.SaveFormat.XLSX)
            workbook.save(new_ole_stream, file_options)

            # Módosítsa az OLE keret objektum adatait.
            new_data = slides.dom.ole.OleEmbeddedDataInfo(new_ole_stream.getvalue(), ole_frame.embedded_data.embedded_file_extension)
            ole_frame.set_embedded_data(new_data)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Fájlok beágyazása diákba**

Az Excel‑diagramokon túl az Aspose.Slides for Python lehetővé teszi más fájltípusok beágyazását diákba is. Például HTML, PDF és ZIP fájlokat is beszúrhatsz objektumként. Amikor a felhasználó duplán ráklikkel egy beillesztett objektumra, az automatikusan megnyílik a hozzárendelt alkalmazásban, vagy a felhasználó felkérést kap egy megfelelő program kiválasztására.

Ez a Python‑kód megmutatja, hogyan ágyazz be HTML‑ és ZIP‑fájlokat egy diára:

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

## **Beágyazott objektumok fájltípusának beállítása**

Prezentációk kezelésekor előfordulhat, hogy régi OLE‑objektumokat újakkal kell helyettesíteni, vagy egy nem támogatott OLE‑objektumot egy támogatottra cserélni. Az Aspose.Slides for Python lehetővé teszi a beágyazott objektum fájltípusának beállítását, így frissítheted az OLE‑keret adatait vagy a fájlkiterjesztését.

Ez a Python‑kód megmutatja, hogyan állítsd be a beágyazott OLE‑objektum fájltípusát `zip`‑re:

```py
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    ole_frame = slide.shapes[0]

    file_extension = ole_frame.embedded_data.embedded_file_extension
    file_data = ole_frame.embedded_data.embedded_file_data

    print(f"Current embedded file extension is: {file_extension}")

    # A fájltípus módosítása ZIP-re.
    ole_frame.set_embedded_data(slides.dom.ole.OleEmbeddedDataInfo(file_data, "zip"))

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Ikonképek és címek beállítása beágyazott objektumokhoz**

Miután beágyazz egy OLE‑objektumot, automatikusan hozzáadódik egy ikon‑alapú előnézet. Ez az előnézet látható a felhasználók számára, mielőtt hozzáférnének vagy megnyitnák az OLE‑objektumot. Ha egy adott képet és szöveget szeretnél használni az előnézetben, beállíthatod az ikon képet és a címet az Aspose.Slides for Python segítségével.

Ez a Python‑kód megmutatja, hogyan állítsd be az ikon képet és a címet egy beágyazott objektumhoz:

```py
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

## **OLE‑objektumkeretek átméretezésének és áthelyezésének megakadályozása**

Miután linkelt OLE‑objektumot adtál egy diához, a PowerPoint felkérhet a linkek frissítésére, amikor megnyitod a prezentációt. Az „Update Links” választása módosíthatja az OLE‑objektumkeret méretét és pozícióját, mivel a PowerPoint frissíti az előnézetet a linkelt objektum adataival. Ahhoz, hogy a PowerPoint ne kérje a frissítést, állítsd a [OleObjectFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/oleobjectframe/) osztály `update_automatic` tulajdonságát **False**‑ra:

```py
ole_frame.update_automatic = False
```

## **Beágyazott fájlok kinyerése**

Az Aspose.Slides for Python lehetővé teszi a diákba beágyazott OLE‑objektumokként tárolt fájlok kinyerését a következő módon:

1. Hozz létre egy [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) példányt, amely tartalmazza a kinyerni kívánt OLE‑objektumokat.
1. Iterálj végig a prezentáció összes alakzata között, és keresd meg az OLEObjectFrame alakzatokat.
1. Nyerd ki a beágyazott fájl adatokat minden [OLEObjectFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/oleobjectframe/) elemből, és írd őket lemezre.

Az alábbi Python‑kód megmutatja, hogyan nyerj ki fájlokat, amelyeket egy diára OLE‑objektumként ágyaztak be:

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

## **GYIK**

**Megjelenik‑e az OLE‑tartalom a diák PDF‑/képfájlba exportálásakor?**

A dián látható elem kerül renderelésre – az ikon/helyettesítő kép (előnézet). Az „élő” OLE‑tartalom nem kerül végrehajtásra a renderelés során. Szükség esetén állíts be saját előnézeti képet, hogy a várt megjelenés megmaradjon az exportált PDF‑ben.

**Hogyan tudok egy OLE‑objektumot rögzíteni a dián, hogy a felhasználók ne mozgathassák vagy szerkeszthessék a PowerPointban?**

Zárolhatod az alakzatot: az Aspose.Slides [alakzatszintű zárolásokat]( /slides/hu/python-net/applying-protection-to-presentation/) biztosít. Ez nem titkosítás, de hatékonyan megakadályozza a véletlen szerkesztéseket és mozgatást.

**Miért „ugrik” vagy változik a mérete egy linkelt Excel‑objektumnak, amikor megnyitom a prezentációt?**

A PowerPoint frissítheti a linkelt OLE‑előnézetet. Stabil megjelenéshez kövesd a [Worksheet Resizing megoldást]( /slides/hu/python-net/working-solution-for-worksheet-resizing/) – vagy illeszd a keretet a tartományhoz, vagy skálázd a tartományt egy rögzített keretre, és állíts be megfelelő helyettesítő képet.

**Megmaradnak‑e a linkelt OLE‑objektumok relatív útvonalai a PPTX formátumban?**

A PPTX‑ben nincs elérhető „relatív útvonal” információ – csak a teljes útvonal. Relatív útvonalak a régebbi PPT formátumban találhatók. A hordozhatóság érdekében részesítsd előnyben a megbízható abszolút útvonalakat vagy elérhető URI‑kat, vagy használj beágyazást.