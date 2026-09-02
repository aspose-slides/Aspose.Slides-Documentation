---
title: Képkeretek kezelése prezentációkban Python nyelven
linktitle: Képkeret
type: docs
weight: 10
url: /hu/python-net/picture-frame/
keywords:
- képkeret
- képkeret hozzáadása
- képkeret létrehozása
- beágyazott kép
- kapcsolt kép
- kép kinyerése
- raszteres kép
- SVG kép
- kép vágása
- vágott területek törlése
- kép tömörítése
- StretchOffset
- képkeret formázása
- relatív méretezés
- kép hatása
- oldalarány
- PowerPoint
- OpenDocument
- prezentáció
- Python
- Aspose.Slides
description: "Képkeretek létrehozása, formázása, összekapcsolása, vágása, kinyerése és tömörítése prezentációkban az Aspose.Slides for Python via .NET segítségével."
---
## **Áttekintés**

A picture frame egy dián lévő alakzat, amely képet jelenít meg. Az Aspose.Slides-ben a képernyöforrás és a megjelenítő alakzat külön objektumok: egy [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) beágyazott képforrásokat birtokol a [ImageCollection](https://reference.aspose.com/slides/hu/python-net/aspose.slides/imagecollection/) segítségével, míg egy [PictureFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/pictureframe/) szabályozza a kép pozícióját, méretét, vonalformázását, forgatását, vágását, kép hatásait és egyéb keretszintű beállításokat.

Ez a szétválasztás akkor hasznos, ha ugyanaz a kép többször is megjelenik. Addja a képet egyszer a prezentációhoz, tartsa meg a visszaadott [PPImage](https://reference.aspose.com/slides/hu/python-net/aspose.slides/ppimage/), és használja azt a képforrást képkeretek létrehozásakor.

A képkeretek raster képeket, például PNG vagy JPEG, valamint vektor SVG képeket is tartalmazhatnak. Ezenkívül hivatkozhatnak kapcsolt képekre is, ahelyett, hogy a kép bájtjait a prezentációban tárolnák. A választás befolyásolja a hordozhatóságot, a fájlméretet, a kinyerést és az export viselkedését, ezért hasznos meghatározni, hogyan legyen a kép tárolva a formázás vagy optimalizálás előtt.

## **Beágyazott kép hozzáadása és formázása**

Beágyazott kép esetén adja hozzá a kép adatát a prezentációhoz, és hozzon létre egy képkeretet a [ShapeCollection.add_picture_frame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/shapecollection/add_picture_frame/) segítségével. A kép a prezentáció csomagjának része lesz, így a prezentáció önmagában tartalmazza magát, amikor másik számítógépre kerül.

Az alábbi példa JPEG képet ad hozzá, keretet hoz létre a kép natív méreteiben, és vonalformázást valamint forgatást alkalmaz:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("photo.jpg") as source_image:
        image = presentation.images.add_image(source_image)

    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 100, image.width, image.height, image)
    picture_frame.line_format.fill_format.fill_type = slides.FillType.SOLID
    picture_frame.line_format.fill_format.solid_fill_color.color = draw.Color.blue
    picture_frame.line_format.width = 3
    picture_frame.rotation = 15

    presentation.save("picture-frame.pptx", slides.export.SaveFormat.PPTX)
```

A picture frame szabályozza a megjelenített geometriát; a keret méretének módosítása nem változtatja meg az eredeti, a beágyazott képforrásban tárolt pixelméreteket. Ez a különbség későbbi vágás vagy tömörítés esetén fontos.

## **Relatív méretezés használata**

A [PictureFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/pictureframe/) a [relative_scale_width](https://reference.aspose.com/slides/hu/python-net/aspose.slides/pictureframe/relative_scale_width/) és a [relative_scale_height](https://reference.aspose.com/slides/hu/python-net/aspose.slides/pictureframe/relative_scale_height/) értékeket exponálja a kerethez. Az `1.0` érték az eredeti kép 100%-ának felel meg. A relatív méretezés akkor hasznos, ha a munkafolyamatnak meg kell őriznie a kapcsolatot a forráskép méretével a végleges méretek kézi számítása helyett.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("photo.jpg") as source_image:
        image = presentation.images.add_image(source_image)

    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, 100, 100, image)
    picture_frame.relative_scale_width = 1.35
    picture_frame.relative_scale_height = 0.8

    presentation.save("relative-scale.pptx", slides.export.SaveFormat.PPTX)
```

A relatív méretezés a keret méretbeállításait változtatja; nem mintavételezi vagy tömöríti a beágyazott képet.

## **Beágyazott és kapcsolt képek**

A beágyazott kép a képadatot a prezentáció belsejében tárolja, ezért a hordozhatóság és az előre látható megjelenítés szempontjából a legbiztonságosabb választás. A kapcsolt kép a [Picture](https://reference.aspose.com/slides/hu/python-net/aspose.slides/picture/) hivatkozási útvonalán keresztül külső helyet tárol a képadatok beágyazása helyett.

A kapcsolt képek csökkenthetik a PPTX-ben tárolt képadatok mennyiségét, de külső függőséget hoznak létre. A kapcsolt fájlnak elérhetőnek kell maradnia ahhoz az alkalmazáshoz, amely megnyitja vagy rendereli a prezentációt. Ha az útvonal megváltozik, a fájl áthelyezésre kerül vagy az erőforrás nem hozzáférhető, a kapcsolt kép nem biztos, hogy a várt módon jelenik meg. Olyan prezentációk esetén, amelyeket e‑mailben kell elküldeni, archiválni vagy elszigetelt környezetben renderelni, a beágyazott képek általában megbízhatóbbak.

### **Kapcsolt kép hozzáadása**

Az alábbi példa egy picture frame-et hoz létre, és egy helyi képfájlra mutat. Csak a kép hivatkozását kezeli; a videó hivatkozás egy külön médiamunkafolyamat, és szándékosan nincs keverve ebben a példában.

```python
import os
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, 320, 180, None)
    linked_image_path = os.path.abspath("linked-image.jpg")
    picture_frame.picture_format.picture.link_path_long = linked_image_path

    presentation.save("linked-image.pptx", slides.export.SaveFormat.PPTX)
```

Használjon hivatkozásokat, ha a külső fájlkezelés szándékos. Ne használja őket csupán a tömörítés pótlására: egy kisebb PPTX törött képfüggőségekkel általában kevésbé hasznos, mint egy nagyobb, önmagában álló prezentáció.

## **Képek kinyerése képkeretekből**

Mielőtt képet nyerne ki egy meglévő prezentációból, ellenőrizze, hogy az alakzat valóban egy [PictureFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/pictureframe/), és hogy beágyazott képet tartalmaz-e. A kapcsolt képkeretek nem feltétlenül tartalmaznak képbyte-okat, amelyeket ugyanúgy ki lehetne nyerni.

### **Rasterkép kinyerése**

A modern kép API közvetlenül a [IImage](https://reference.aspose.com/slides/hu/python-net/aspose.slides/iimage/) használatával működik. Az alábbi példa megtalálja az első beágyazott raster képet egy dián, és PNG‑ként menti el:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if not isinstance(shape, slides.PictureFrame):
            continue

        embedded_image = shape.picture_format.picture.image
        if embedded_image is None or embedded_image.svg_image is not None:
            continue

        raster_image = embedded_image.image
        raster_image.save("extracted-image.png", slides.ImageFormat.PNG)
        break
```

A [IImage](https://reference.aspose.com/slides/hu/python-net/aspose.slides/iimage/) használatával a kinyert kép a kért kimeneti formátumba konvertálódik. Ha a prezentációban tárolt kódolt byte-okat szeretné megkapni egy konvertált raster fájl helyett, akkor használja a [PPImage.binary_data](https://reference.aspose.com/slides/hu/python-net/aspose.slides/ppimage/binary_data/) tulajdonságot.

### **SVG kép kinyerése**

SVG kép esetén a [PPImage](https://reference.aspose.com/slides/hu/python-net/aspose.slides/ppimage/) egy [SvgImage](https://reference.aspose.com/slides/hu/python-net/aspose.slides/svgimage/) objektumot exponál. Ez lehetővé teszi az SVG adat közvetlen lekérését a kép rasterizálása nélkül.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if not isinstance(shape, slides.PictureFrame):
            continue

        embedded_image = shape.picture_format.picture.image
        svg_image = embedded_image.svg_image if embedded_image is not None else None
        if svg_image is None:
            continue

        svg_data = bytes(svg_image.svg_data)
        with open("extracted-image.svg", "wb") as svg_stream:
            svg_stream.write(svg_data)
        break
```

Az SVG tartalom SVG‑ként való megtartása megőrzi a vektoralapot a prezentációban. A PNG vagy JPEG‑hez hasonló raster exportok kötelezően a vektort pixelekre renderelik. A PDF vagy SVG diaexport is egy renderelési művelet, ezért az exportált grafikákat nem szabad eredeti beágyazott SVG‑nek bit‑pontos másolatának tekinteni; használja a beágyazott [SvgImage.svg_data](https://reference.aspose.com/slides/hu/python-net/aspose.slides/svgimage/svg_data/) értéket, ha maga a vektor erőforrás szükséges.

## **Kép vágása**

A vágás megváltoztatja, hogy a kép mely része látható a keretben. A [PictureFillFormat](https://reference.aspose.com/slides/hu/python-net/aspose.slides/picturefillformat/) vágási értékei a forráskép méretének százalékában vannak megadva. A vágás kezdetben nem törli a rejtett pixeleket a beágyazott képből; csak a látható régiót módosítja.

Az alábbi példa biztonságosan megtalálja a picture frame‑et, és alkalmazza a vágási értékeket:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    picture_frame = None

    for shape in slide.shapes:
        if isinstance(shape, slides.PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        picture_frame.picture_format.crop_left = 23.6
        picture_frame.picture_format.crop_right = 21.5
        picture_frame.picture_format.crop_top = 3
        picture_frame.picture_format.crop_bottom = 31
        presentation.save("cropped-image.pptx", slides.export.SaveFormat.PPTX)
```

Mivel a rejtett képadatok továbbra is jelen vannak, a vágás később módosítható az eredeti pixelek elvesztése nélkül. Ha a fájlméret fontosabb, mint a visszafordíthatóság, a vágott területek fizikailag eltávolíthatók a következő szakaszban leírtak szerint.

## **Vágott képadatok eltávolítása**

A [PictureFillFormat.delete_picture_cropped_areas](https://reference.aspose.com/slides/hu/python-net/aspose.slides/picturefillformat/delete_picture_cropped_areas/) eltávolítja a képadatot az aktuális vágási téglalapon kívül, és visszaadja a kapott képforrást. Ez csökkentheti a fájlméretet, de destruktív optimalizálás: a prezentáció mentése után a törölt pixelek már nem állnak rendelkezésre egy későbbi „un‑crop” művelethez.

```python
import aspose.slides as slides

with slides.Presentation("cropped-image.pptx") as presentation:
    slide = presentation.slides[0]
    picture_frame = None

    for shape in slide.shapes:
        if isinstance(shape, slides.PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        cropped_image = picture_frame.picture_format.delete_picture_cropped_areas()
        if cropped_image is not None:
            presentation.save("cropped-data-removed.pptx", slides.export.SaveFormat.PPTX)
```

A metódus új képforrást adhat a prezentációhoz. Ha az eredeti képet más picture frame‑ek is használják, ezeknek továbbra is a meglévő forrásra van szükségük, így a vágott területek törlése nem feltétlenül csökkenti a képek összes számát. WMF vagy EMF tartalom ilyen módszerrel történő vágása a vágott eredményt PNG‑be rasterizálja.

## **Raster képek tömörítése**

A [PictureFillFormat.compress_image](https://reference.aspose.com/slides/hu/python-net/aspose.slides/picturefillformat/compress_image/) a raster kép felbontását csökkenti a kép megjelenítési méretéhez képest. Ugyanebben a műveletben eltávolíthatja a vágott területeket is. A metódus `True`‑t ad vissza, ha a képet átméretezték vagy levágták, és `False`‑t, ha nem volt szükség változtatásra.

Használjon előre definiált [PicturesCompression](https://reference.aspose.com/slides/hu/python-net/aspose.slides.export/picturescompression/) értéket, ha egy szabványos célfelbontás elegendő:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    picture_frame = None

    for shape in slide.shapes:
        if isinstance(shape, slides.PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        compressed = picture_frame.picture_format.compress_image(True, slides.export.PicturesCompression.DPI150)
        print("The image was compressed." if compressed else "No compression was necessary.")
        presentation.save("compressed-image.pptx", slides.export.SaveFormat.PPTX)
```

Egyedi pozitív DPI érték is megadható enum érték helyett, ha egy konkrét célpont szükséges.

A tömörítés raster képekre van tervezve. SVG‑ és metafájl tartalom nem csökken ezzel a raster tömörítési munkafolyamattal. Emlékezzen arra is, hogy az alacsonyabb felbontású és a törölt vágott területek nem állíthatók vissza az optimalizált prezentációból. Válasszon célfelbontást a legnagyobb megjelenítési vagy export méret alapján, ne pedig a legalacsonyabb DPI‑t globálisan alkalmazza.

## **Képtranszformációs hatások kezelése**

A teljes munkafolyamatért, amely lefedi a fényerő, kontraszt, színtranszformációk, elmosás, alfa‑hatások, láncok rendezését, ellenőrzését, eltávolítását és kerek‑úton való ellenőrzését, lásd a [Image Transform Effects](/slides/hu/python-net/image-transform-effects/) oldalt.

## **Képkeret geometria zárolása**

A [PictureFrameLock](https://reference.aspose.com/slides/hu/python-net/aspose.slides/pictureframelock/) beállítások határozzák meg, hogy mely szerkesztési műveletek vannak letiltva egy picture frame‑nél. Például az [aspect_ratio_locked](https://reference.aspose.com/slides/hu/python-net/aspose.slides/pictureframelock/aspect_ratio_locked/) tulajdonság megőrzi az alakzat arányait átméretezés közben.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("photo.jpg") as source_image:
        image = presentation.images.add_image(source_image)

    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 100, image.width, image.height, image)
    picture_frame.picture_frame_lock.aspect_ratio_locked = True

    presentation.save("locked-picture-frame.pptx", slides.export.SaveFormat.PPTX)
```

A zárolás a picture frame alakzatra vonatkozik. Nem kényszeríti a forrásképet a mintavételezésre vagy arra, hogy állandóan ugyanazzal az aránnyal rendelkezzen.

## **StretchOffset értékek módosítása**

Amikor a kép kitöltési mód stretch, a [PictureFillFormat](https://reference.aspose.com/slides/hu/python-net/aspose.slides/picturefillformat/) stretch‑offset értékei a kitöltő téglalapot definiálják a picture frame körülhatároló dobozához képest. A pozitív százalékok a szél felől beljebb hoznak, a negatív százalékok pedig kifelé.

Ez különbözik a vágástól. A vágási értékek azt határozzák meg, hogy a forráskép mely része látható; a stretch‑offsetok a látható kitöltés téglalapját változtatják meg.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("photo.png") as source_image:
        image = presentation.images.add_image(source_image)

    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 400, 300, image)
    picture_frame.picture_format.picture_fill_mode = slides.PictureFillMode.STRETCH
    picture_frame.picture_format.stretch_offset_left = 12
    picture_frame.picture_format.stretch_offset_right = 12
    picture_frame.picture_format.stretch_offset_top = 8
    picture_frame.picture_format.stretch_offset_bottom = 8

    presentation.save("stretch-offsets.pptx", slides.export.SaveFormat.PPTX)
```

Használja a stretch‑offsetokat a kitöltés elhelyezéséhez. Használja a vágási tulajdonságokat, ha a cél a forráskép széleinek elrejtése.

## **Tárolás, fájlméret és exportálási megfontolások**

A fő kompromisszumok könnyebben kezelhetők, ha a kép tárolását és a képkeret formázását különválasztjuk:

- **Beágyazott képek** önmagukban tartalmazzák a prezentációt, és a legmegbízhatóbbak megosztás és szerveroldali renderelés esetén, de a nagy raster képek növelik a PPTX méretét és memóriahasználatát.  
- **Kapcsolt képek** kisebbre tarthatják a csomagot, de a prezentáció függ a külső fájlok elérhetőségétől a tárolt útvonalakon vagy helyeken.  
- **Vágás** kezdetben nem destruktív. A rejtett pixelek beágyazva maradnak, amíg a vágott területeket kifejezetten nem törlik vagy a tömörítés során nem távolítják el.  
- **Tömörítés** jelentősen csökkentheti a fájlméretet a túlméretezett raster képeknél, de az eredeti felbontást feláldozza. A vágott képméret ismeretében kell alkalmazni.  
- **SVG képek** maradjanak SVG‑ként, ha fontos a vektor megőrzése. A beágyazott SVG közvetlenül kinyerhető, ha magára a vektor erőforrásra van szükség. A raster diaexportok mindig a renderelt diát konvertálják pixelekké.  
- **Ismétlődő képek** lehetőség szerint használják ugyanazt a meglévő [PPImage](https://reference.aspose.com/slides/hu/python-net/aspose.slides/ppimage/) erőforrást, ahelyett, hogy ugyanazt a fájlt többször betöltenék a prezentációs munkafolyamatba.

Nagy prezentációk esetén a képoptimalizálás általában a leginkább hatékony, ha szelektíven történik: tartsa a logókat és diagramokat vektor tartalomként, tömörítse a fényképeket a valós megjelenítési méretüknek megfelelően, csak akkor távolítsa el a vágott pixeleket, ha későbbi szerkesztés nem szükséges, és kerülje a külső hivatkozásokat, hacsak a függőségkezelés nem része a telepítési tervezésnek.

## **GYIK**

**Mi a különbség a picture frame és egy képforrás között?**  
A [PPImage](https://reference.aspose.com/slides/hu/python-net/aspose.slides/ppimage/) egy a prezentációhoz kapcsolódó képforrást reprezentál. Egy [PictureFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/pictureframe/) egy dián lévő alakzat, amely képet jelenít meg, és keretszintű geometriát és formázást (méret, forgatás, vágási értékek, hatások, zárolások) tárol.

**Beágyazzam vagy kapcsoljam a képeket?**  
Beágyazza a képeket, ha a prezentációnak hordozhatónak, archiválhatónak vagy külső erőforrások hozzáférése nélkül renderelhetőnek kell lennie. Kapcsolja a képeket csak akkor, ha a képfájlok külső tárolása szándékos, és a külső helyek megbízhatóan karbantarthatók.

**Csökkenti-e a vágás a PPTX fájlméretét?**  
Nem önmagában. A normál vágási beállítások elrejtik a forráskép részeit, de megtartják az alatta lévő pixeleket. Használja a [PictureFillFormat.delete_picture_cropped_areas](https://reference.aspose.com/slides/hu/python-net/aspose.slides/picturefillformat/delete_picture_cropped_areas/) vagy a képtömörítést vágott terület eltávolítással, ha ezeket a pixeleket véglegesen el lehet dobni.

**Vissza tudom állítani a képminőséget a tömörítés után?**  
Nem. A tömörítés csökkentheti a tárolt raster felbontást, és a vágott területek eltávolítása adatvesztést eredményez. Ha később nagy felbontású szerkesztésre van szükség, tartsa meg az eredeti forrásképet a prezentáción kívül.

**Hogyan kell kezelni az SVG képeket?**  
Tartsa meg az SVG tartalmat SVG‑ként, ha a vektor pontossága számít. A beágyazott [SvgImage](https://reference.aspose.com/slides/hu/python-net/aspose.slides/svgimage/) közvetlenül kinyerhető. A dia raster formátumra (PNG vagy JPEG) történő renderelése a SVG‑t pixelekre alakítja.

**Hogyan kerülhetem el a nem biztonságos cast‑eket létező diák olvasásakor?**  
Ellenőrizze az alakzat típusát a picture‑frame‑specifikus tagok használata előtt. Az `isinstance(shape, slides.PictureFrame)` használata megakadályozza az érvénytelen cast‑eket, és lehetővé teszi, hogy a kód a nem picture frame‑et tartalmazó diákra is helyesen reagáljon.