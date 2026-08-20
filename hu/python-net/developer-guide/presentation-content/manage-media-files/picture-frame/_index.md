---
title: Képkeretek kezelése prezentációkban Python használatával
linktitle: Képkeret
type: docs
weight: 10
url: /hu/python-net/picture-frame/
keywords:
- képkeret
- képkeret hozzáadása
- képkeret létrehozása
- beágyazott kép
- linkelt kép
- kép kinyerése
- raszteres kép
- SVG kép
- kép vágása
- vágott területek törlése
- kép tömörítése
- StretchOffset
- képkeret formázása
- relatív méretezés
- kép hatás
- oldalarány
- PowerPoint
- OpenDocument
- prezentáció
- Python
- Aspose.Slides
description: Képkeretek létrehozása, formázása, összekapcsolása, vágása, kinyerése és tömörítése prezentációkban az Aspose.Slides for Python via .NET használatával.
---
## **Áttekintés**

A picture frame egy diaképdoboz, amely képet jelenít meg. Az Aspose.Slides-ben a kép erőforrás és a megjelenítő alakzat külön objektumok: egy [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) beágyazott képerny erőforrásokat birtokol a [ImageCollection](https://reference.aspose.com/slides/hu/python-net/aspose.slides/imagecollection/) segítségével, míg egy [PictureFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/pictureframe/) szabályozza a kép pozícióját, méretét, vonalformázását, forgatását, vágását, képhatásait és egyéb keretszintű beállításait.

Ez a felosztás akkor hasznos, amikor ugyanaz a kép többször jelenik meg. Adjunk hozzá a képhez egyszer a prezentációhoz, tartsuk meg a visszaadott [PPImage](https://reference.aspose.com/slides/hu/python-net/aspose.slides/ppimage/), és használjuk ezt a kép erőforrást picture frame-ek létrehozásakor.

A picture frame-ek raster képeket (például PNG vagy JPEG) és vektor SVG képeket is tartalmazhatnak. Emellett hivatkozhatnak linkelt képekre is, ahelyett, hogy a kép bájtjait tárolnák a prezentációban. A választás befolyásolja a hordozhatóságot, a fájlméretet, a kinyerést és az export viselkedését, ezért hasznos előre eldönteni, hogyan legyen a kép tárolva a formázás vagy optimalizálás előtt.

## **Beágyazott kép hozzáadása és formázása**

Beágyazott kép esetén adjuk hozzá a kép adatot a prezentációhoz, és hozzunk létre egy picture frame-et a [ShapeCollection.add_picture_frame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/shapecollection/add_picture_frame/) segítségével. A kép a prezentációcsomag részévé válik, így a prezentáció önálló marad, ha egy másik számítógépre kerül.

Az alábbi példa JPEG képet ad hozzá, a kép natív méreteiben hoz létre egy keretet, és vonalformázást valamint forgatást alkalmaz:

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

A picture frame szabályozza a megjelenített geometriát; a keret méretének módosítása nem változtatja meg az eredeti pixelméreteket, amelyeket a beágyazott kép erőforrás tárol. Ez a megkülönböztetés akkor válik fontosá, ha később vágunk vagy tömörítünk egy képet.

## **Relatív méretezés használata**

A [PictureFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/pictureframe/) rendelkezik a [relative_scale_width](https://reference.aspose.com/slides/hu/python-net/aspose.slides/pictureframe/relative_scale_width/) és a [relative_scale_height](https://reference.aspose.com/slides/hu/python-net/aspose.slides/pictureframe/relative_scale_height/) tulajdonságokkal. Az `1.0` érték az eredeti kép méretének 100%-ának felel meg. A relatív méretezés akkor hasznos, amikor egy munkafolyamatnak meg kell őriznie a kapcsolatot a forráskép méretével, ahelyett, hogy manuálisan számolná ki a végleges méreteket.

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

A relatív méretezés megváltoztatja a keret méretbeállításait; nem mintavételezi vagy tömöríti a beágyazott képet.

## **Beágyazott és linkelt képek**

A beágyazott picture a kép adatot a prezentáción belül tárolja, ezért a legbiztonságosabb választás a hordozhatóság és az előre kiszámítható megjelenítés szempontjából. Egy linkelt picture a [Picture](https://reference.aspose.com/slides/hu/python-net/aspose.slides/picture/) linkútvonalon keresztül tárolja a külső helyet, ahelyett, hogy a kép adatot beágyazná ugyanúgy.

A linkelt képek csökkenthetik a PPTX-ben tárolt kép adat mennyiségét, de külső függőséget hoznak be. A linkelt fájlnak elérhetőnek kell maradnia azon alkalmazás számára, amely megnyitja vagy rendereli a prezentációt. Ha az útvonal megváltozik, a fájl átkerül, vagy az erőforrás nem érhető el, a linkelt picture előre nem látható módon nem jelenik meg. Azoknál a prezentációknál, amelyeket e‑mailben kell küldeni, archiválni kell, vagy izolált környezetben kell renderelni, a beágyazott képek általában megbízhatóbbak.

### **Linkelt kép hozzáadása**

Az alábbi példa egy picture frame-et hoz létre, és egy helyi kép fájlra mutat. Csak a kép linkelésével foglalkozik; a video linkelés egy külön médiamunkafolyamat, és szándékosan nincs keverve ebbe a példába.

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

Használjunk linkeket, ha a külső fájlkezelés szándékos. Ne használjuk őket pusztán a tömörítés helyettesítésére: egy kis PPTX, amelyben törött kép függőségek vannak, általában kevésbé hasznos, mint egy nagyobb, önálló prezentáció.

## **Képek kinyerése picture frame-ekből**

Mielőtt képet nyernénk ki egy meglévő prezentációból, ellenőrizzük, hogy a forma valóban egy [PictureFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/pictureframe/), és hogy beágyazott képet tartalmaz‑e. A linkelt picture frame-ek nem feltétlenül tartalmaznak kivonható kép bájtokat.

### **Raster kép kinyerése**

A modern kép API közvetlenül a [IImage](https://reference.aspose.com/slides/hu/python-net/aspose.slides/iimage/) használja. Az alábbi példa megtalálja az első beágyazott raster képet a dián, és PNG‑ként menti el:

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

A [IImage](https://reference.aspose.com/slides/hu/python-net/aspose.slides/iimage/) használatával a kinyert kép a kért kimeneti formátumba konvertálódik. Ha a prezentációban tárolt kódolt bájtokra van szükség a konvertált raster fájl helyett, használja a [PPImage.binary_data](https://reference.aspose.com/slides/hu/python-net/aspose.slides/ppimage/binary_data/) tulajdonságot.

### **SVG kép kinyerése**

SVG picture esetén a [PPImage](https://reference.aspose.com/slides/hu/python-net/aspose.slides/ppimage/) egy [SvgImage](https://reference.aspose.com/slides/hu/python-net/aspose.slides/svgimage/) objektumot tesz elérhetővé. Ez lehetővé teszi az SVG adat közvetlen lekérését, a picture rasterizálása előtt.

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

Az SVG tartalom SVG‑ként történő megtartása megőrzi a vektor forrást a prezentáción belül. A raster exportok, mint a PNG vagy JPEG, a vektort pixelekké alakítják. A PDF vagy SVG diák exportálása szintén egy renderelési művelet, ezért az exportált grafikákat nem szabad az eredeti beágyazott SVG pontos byte‑másolataként kezelni; használja a beágyazott [SvgImage.svg_data](https://reference.aspose.com/slides/hu/python-net/aspose.slides/svgimage/svg_data/)‑t, ha a vektor erőforrásra magára van szükség.

## **Kép vágása**

A vágás megváltoztatja, hogy a kép mely része látható a kereten belül. A [PictureFillFormat](https://reference.aspose.com/slides/hu/python-net/aspose.slides/picturefillformat/) vágási értékei a forráskép méreteinek százalékában vannak megadva. A vágás kezdetben nem törli a rejtett pixeleket a beágyazott képből; csak a látható régiót változtatja meg.

Az alábbi példa biztonságosan megtalál egy picture frame‑et, és alkalmaz vágási értékeket:

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

Mivel a rejtett képadat továbbra is jelen van, a vágás később módosítható az eredeti pixelek elvesztése nélkül. Ha a fájlméret fontosabb, mint a visszavonhatóság, a vágott területek fizikai eltávolíthatók a következő szakaszban leírt módon.

## **Vágott képadat eltávolítása**

A [PictureFillFormat.delete_picture_cropped_areas](https://reference.aspose.com/slides/hu/python-net/aspose.slides/picturefillformat/delete_picture_cropped_areas/) eltávolítja a képadatot a jelenlegi vágási téglalapon kívül, és visszaadja az eredményül kapott kép erőforrást. Ez csökkentheti a fájlméretet, de destruktív optimalizáció: a prezentáció mentése után a eltávolított pixelek már nem állnak rendelkezésre későbbi visszavágási művelethez.

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

A metódus új kép erőforrást adhat a prezentációhoz. Ha az eredeti kép más picture frame‑ek által is használva van, azoknak továbbra is szükségük van a meglévő erőforrásra, ezért a vágott területek törlése nem feltétlenül csökkenti a képek teljes számát. WMF vagy EMF tartalom vágása ezzel a módszerrel rasterizálja a vágott eredményt PNG‑be.

## **Raster képek tömörítése**

A [PictureFillFormat.compress_image](https://reference.aspose.com/slides/hu/python-net/aspose.slides/picturefillformat/compress_image/) csökkenti a raster kép felbontását a kép megjelenítési méretéhez képest. Ugyanabban a műveletben eltávolíthatja a vágott területeket is. A metódus `True`‑t ad vissza, ha a kép mérete megváltozott vagy vágás történt, és `False`‑t, ha nincs szükség változtatásra.

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

Egyedi pozitív DPI érték is megadható enum helyett, ha egy konkrét célra van szükség.

A tömörítés raster képekre vonatkozik. SVG és metafájl tartalom nem csökken ezzel a raster tömörítési munkafolyamattal. Ne feledje, hogy az alacsonyabb felbontás és a törölt vágott régiók nem állíthatók vissza az optimalizált prezentációból. Válasszon célfelbontást a kép legnagyobb megjelenítési vagy export mérete alapján, ne pedig a legalacsonyabb DPI-t alkalmazza globálisan.

## **Kép hatások vizsgálata**

A kép hatásokat a frame által használt picture tárolja. A kép transzformációs gyűjtemény tartalmazhat hatásokat, mint például a fix alfa moduláció a átlátszósághoz és a luminancia a fényerő és kontraszt beállításához. Az alábbi példa biztonságosan beolvassa mindkét típusú hatást az első picture frame‑ről a dián:

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
        for effect in picture_frame.picture_format.picture.image_transform:
            if isinstance(effect, slides.effects.AlphaModulateFixed):
                transparency = 100 - effect.amount
                print("Transparency: " + str(transparency))

            if isinstance(effect, slides.effects.Luminance):
                luminance = effect.get_effective()
                print("Brightness: " + str(luminance.brightness))
                print("Contrast: " + str(luminance.contrast))
```

Az [AlphaModulateFixed](https://reference.aspose.com/slides/hu/python-net/aspose.slides.effects/alphamodulatefixed/) és a [Luminance](https://reference.aspose.com/slides/hu/python-net/aspose.slides.effects/luminance/) megváltoztatja, hogyan jelenik meg a kép a keretben; nem írja felül az eredeti beágyazott kép bájtjait.

## **Picture Frame geometria zárolása**

A [PictureFrameLock](https://reference.aspose.com/slides/hu/python-net/aspose.slides/pictureframelock/) beállítások határozzák meg, hogy mely szerkesztési műveletek vannak letiltva egy picture frame‑nél. Például a [aspect_ratio_locked](https://reference.aspose.com/slides/hu/python-net/aspose.slides/pictureframelock/aspect_ratio_locked/) tulajdonság megőrzi a forma arányait, amikor az méreteződik.

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

A zárolás a picture frame alakzatra vonatkozik. Nem kényszeríti a forrásképet, hogy ugyanarra az arányra legyen újramintavéve vagy végleg módosítva.

## **StretchOffset értékek beállítása**

Amikor a kép kitöltési mód a nyújtás, a [PictureFillFormat](https://reference.aspose.com/slides/hu/python-net/aspose.slides/picturefillformat/) stretch‑offset értékei határozzák meg a kitöltési téglalapot a picture frame körülhatároló dobozához képest. A pozitív százalékok a szél felől beljebb hoznak, míg a negatív százalékok kifelé tolásra használhatók.

Ez különbözik a vágástól. A vágási értékek kiválasztják, hogy a forráskép mely része látható; a stretch offsetek megváltoztatják a téglalapot, amelybe a látható kép kitöltése nyújtva kerül.

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

Használja a stretch offseteket a kitöltés elhelyezéséhez. Használja a vágási tulajdonságokat, ha a cél a forráskép széleit elrejteni.

## **Tárolás, fájlméret és export szempontok**

A fő kompromisszumok kezelése egyszerűbb, ha a kép tárolását és a picture‑frame formázást külön kezeljük:

- **Beágyazott képek** önállóvá teszik a prezentációt, és a legmegbízhatóbbak a megosztás és szerveroldali renderelés esetén, de nagy raster képek növelik a PPTX méretét és a memóriahasználatot.
- **Linkelt képek** kisebb csomagot eredményezhetnek, de a prezentáció függ a külső fájlok elérhetőségétől a tárolt útvonalakon vagy helyeken.
- **Vágás** kezdetben nem destruktív. A rejtett pixelek beágyazva maradnak, amíg a vágott területek kifejezetten nincsenek törölve vagy a tömörítés során el nem távolítva.
- **Tömörítés** jelentősen csökkentheti a fájlméretet a túlméretezett raster képek esetén, de feláldozza a forrás felbontást. A dián megjelenítendő méret ismertét követően kell alkalmazni.
- **SVG képek** esetén a SVG megőrzése fontos, ha a vektor megőrzése lényeges. Közvetlenül kinyerhető a beágyazott SVG, ha a vektor erőforrásra van szükség. A raster diák exportok mindig a slide képeit pixelekké konvertálják.
- **Ismétlődő képek** esetén használja újra a meglévő [PPImage](https://reference.aspose.com/slides/hu/python-net/aspose.slides/ppimage/) erőforrást, ahelyett, hogy ugyanazt a fájlt többször betöltené a prezentációs munkafolyamatba.

Nagy prezentációknál a képoptimalizálás általában akkor a leghatékonyabb, ha szelektíven történik: tartsuk a logókat és diagramokat vektor tartalomként, tömörítsük a fényképeket a tényleges megjelenítési méretüknek megfelelően, távolítsuk el a vágott pixeleket csak akkor, ha a későbbi szerkesztés nem szükséges, és kerüljük a külső linkeket, hacsak a függőségkezelés nem része a telepítési tervnek.

## **GYIK**

**Mi a különbség a picture frame és a kép erőforrás között?**

Egy [PPImage](https://reference.aspose.com/slides/hu/python-net/aspose.slides/ppimage/) kép erőforrást képvisel, amely a prezentációhoz van kapcsolva. Egy [PictureFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/pictureframe/) egy alakzat a dián, amely képet jelenít meg, és a keretszintű geometriát és formázást tárolja, mint a méret, forgatás, vágási értékek, hatások és zárolások.

**Beágyazzam vagy linkeljem a képeket?**

Beágyazzon képeket, ha a prezentáció hordozhatónak, archiválhatónak vagy külső erőforrások nélkül renderelhetőnek kell lennie. Linkelje a képeket csak akkor, ha a képfájlok kívül tartása szándékos, és a külső helyek megbízhatóan karbantarthatók.

**Csökkenti-e a vágás a PPTX fájlméretet?**

Nem önmagában. A normál vágási beállítások elrejtik a forráskép részeit, de a pixeleket megtartják. Használja a [PictureFillFormat.delete_picture_cropped_areas](https://reference.aspose.com/slides/hu/python-net/aspose.slides/picturefillformat/delete_picture_cropped_areas/) vagy a kép tömörítést vágott terület eltávolítással, ha ezek a pixelek véglegesen eldobhatók.

**Visszaállítható-e a képminőség a tömörítés után?**

Nem. A tömörítés csökkentheti a tárolt raster felbontást, és a vágott régiók eltávolítása adatvesztést eredményez. Tartsa meg az eredeti forrásképet a prezentáció kívül, ha később nagy felbontású szerkesztésre lehet szükség.

**Hogyan kell kezelni az SVG képeket?**

Tartsa meg az SVG tartalmat SVG‑ként, ha a vektor pontossága fontos. A beágyazott [SvgImage](https://reference.aspose.com/slides/hu/python-net/aspose.slides/svgimage/) közvetlenül kinyerhető. A slide raster formátumba, például PNG vagy JPEG, való exportálása rasterizálja az SVG‑t a slide képként.

**Hogyan kerülhető el az unsafe cast a meglévő diák olvasásakor?**

Ellenőrizze a forma típusát, mielőtt picture‑frame‑specifikus tagokat használna. Az `isinstance(shape, slides.PictureFrame)` használata elkerüli a hibás cast‑ot, és lehetővé teszi, hogy a kód kezelje azokat a diákot, amelyek nem tartalmaznak picture frame‑eket.