---
title: Képkeretek kezelése prezentációkban Python segítségével
linktitle: Képkeret
type: docs
weight: 10
url: /hu/python-java/picture-frame/
keywords:
- képkeret
- képkeret hozzáadása
- képkeret létrehozása
- beágyazott kép
- csatolt kép
- kép kinyerése
- raster kép
- SVG kép
- kép levágása
- levágott területek törlése
- kép tömörítése
- StretchOffset
- képkeret formázása
- relatív méretezés
- kép effektus
- oldalarány
- PowerPoint
- OpenDocument
- prezentáció
- Python
- Java
- Aspose.Slides
description: "Képkeretek létrehozása, formázása, csatolása, levágása, kinyerése és tömörítése prezentációkban az Aspose.Slides for Python via Java segítségével."
---
## **Áttekintés**

Egy képkocka egy dián lévő forma, amely képet jelenít meg. Az Aspose.Slides-ben a képernyőforrás és a megjelenítő forma külön objektumok: egy [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) beágyazott képernyőforrásokat birtokol a [ImageCollection](https://reference.aspose.com/slides/hu/python-java/aspose.slides/imagecollection/) segítségével, míg egy [PictureFrame](https://reference.aspose.com/slides/hu/python-java/aspose.slides/pictureframe/) vezérli a kép pozícióját, méretét, vonalformázását, forgatását, levágását, kép effekteket és egyéb keret szintű beállításokat.

Ez a szétválasztás akkor hasznos, ha ugyanaz a kép többször kerül megjelenítésre. Add hozzá a képet a prezentációhoz egyszer, őrizd meg a visszakapott [PPImage](https://reference.aspose.com/slides/hu/python-java/aspose.slides/ppimage/), és használja ezt a képernyőforrást képkockák létrehozásakor.

A képkeretek raster képeket, például PNG vagy JPEG, valamint vektor SVG képeket is tartalmazhatnak. Emellett hivatkozhatnak kapcsolt képekre is, ahelyett, hogy a kép bájtjait a prezentációban tárolnák. A választás befolyásolja a hordozhatóságot, a fájlméretet, a kinyerést és az export viselkedését, ezért érdemes eldönteni, hogyan legyen a kép tárolva, mielőtt a formázást vagy optimalizálást alkalmaznánk.

## **Beágyazott kép hozzáadása és formázása**

Beágyazott kép esetén add hozzá a képadatokat a prezentációhoz, és hozz létre egy képkeretet a [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shapecollection/#addPictureFrame) segítségével. A kép a prezentáció csomagjának részévé válik, így a prezentáció önálló marad, ha egy másik számítógépre kerül.

A következő példa egy JPEG képet ad hozzá, a kép eredeti méreteiben hoz létre egy keretet, és vonalformázást valamint forgatást alkalmaz:
```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from java.awt import Color
from asposeslides.api import FillType, Images, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_image = Images.fromFile("photo.jpg")
    try:
        image = presentation.getImages().addImage(source_image)
    finally:
        source_image.dispose()

    picture_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 100, image.getWidth(), image.getHeight(), image)
    picture_frame.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    picture_frame.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    picture_frame.getLineFormat().setWidth(3)
    picture_frame.setRotation(15)

    presentation.save("picture-frame.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

A képkeret irányítja a megjelenített geometriát; a keret méretének módosítása nem változtatja meg a beágyazott képernyőforrásban tárolt eredeti pixelméreteket. Ez a különbség később fontos lesz, ha a képet levágjuk vagy tömörítjük.

## **Relatív méretezés használata**

[PictureFrame](https://reference.aspose.com/slides/hu/python-java/aspose.slides/pictureframe/) lehetővé teszi a keret relatív szélesség- és magasságméretezését a [setRelativeScaleWidth](https://reference.aspose.com/slides/hu/python-java/aspose.slides/pictureframe/#setRelativeScaleWidth) és a [setRelativeScaleHeight](https://reference.aspose.com/slides/hu/python-java/aspose.slides/pictureframe/#setRelativeScaleHeight) segítségével. Az `1.0` érték az eredeti kép 100%-ának felel meg. A relatív méretezés akkor hasznos, ha egy munkafolyamatnak meg kell őriznie a kapcsolatot a forráskép méretével, ahelyett, hogy manuálisan számolná a végső dimenziókat.
```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_image = Images.fromFile("photo.jpg")
    try:
        image = presentation.getImages().addImage(source_image)
    finally:
        source_image.dispose()

    picture_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, image)
    picture_frame.setRelativeScaleWidth(1.35)
    picture_frame.setRelativeScaleHeight(0.8)

    presentation.save("relative-scale.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

A relatív méretezés megváltoztatja a keret méretezési beállításait; nem mintavételez vagy tömörít beágyazott képet.

## **Beágyazott és csatolt képek**

Egy beágyazott kép a kép adatokat a prezentáción belül tárolja, így a hordozhatóság és a kiszámítható megjelenítés tekintetében a legbiztonságosabb választás. Egy csatolt kép egy külső helyet tárol a [Picture.setLinkPathLong](https://reference.aspose.com/slides/hu/python-java/aspose.slides/picture/#setLinkPathLong) metódus segítségével, ahelyett, hogy a képadatokat beágyazná.

A csatolt képek csökkenthetik a PPTX-ben tárolt képadatok mennyiségét, de külső függőséget vezetnek be. A csatolt fájlnak elérhetőnek kell maradnia azon alkalmazás számára, amely megnyitja vagy rendereli a prezentációt. Ha az elérési út megváltozik, a fájl áthelyezésre kerül, vagy a forrás nem érhető el, a csatolt kép nem jelenhet meg a várttal megegyezően. Azoknál a prezentációknál, amelyeket e-mailben kell elküldeni, archiválni vagy izolált környezetben renderelni kell, a beágyazott képek általában megbízhatóbbak.

### **Csatolt kép hozzáadása**

A következő példa egy képkeretet hoz létre, és egy helyi képfájlra mutatja. Csak a képhivatkozásra vonatkozik; a videohivatkozás egy külön média munkafolyamat, és szándékosan nincs összekapcsolva ebben a példában.
```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    picture_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 320, 180, None)
    linked_image_file = Path("linked-image.jpg").resolve()
    link_path = str(linked_image_file)
    picture_frame.getPictureFormat().getPicture().setLinkPathLong(link_path)

    presentation.save("linked-image.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Használj hivatkozásokat, ha a külső fájlkezelés szándékos. Ne használd őket pusztán tömörítés helyettesítésére: egy kis méretű PPTX, amelyben a képfüggőségek hibásak, általában kevésbé hasznos, mint egy nagyobb önálló prezentáció.

## **Képek kinyerése képkeretekből**

Mielőtt képet nyernél ki egy meglévő prezentációból, ellenőrizd, hogy a forma valóban egy [PictureFrame](https://reference.aspose.com/slides/hu/python-java/aspose.slides/pictureframe/) legyen, és tartalmaz-e beágyazott képet. A csatolt képkeretek nem feltétlenül tartalmaznak olyan képbájtokat, amelyeket ugyanígy ki lehetne nyerni.

### **Raster kép kinyerése**

A modern képadat API közvetlenül raster képekkel dolgozik, és nem igényli a régebbi Java képfedélkét. A következő példa megtalálja az első beágyazott raster képet egy dián, és PNG‑ként menti el:
```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation, PictureFrame

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for shape in slide.getShapes():
        if not isinstance(shape, PictureFrame):
            continue

        picture_frame = shape
        embedded_image = picture_frame.getPictureFormat().getPicture().getImage()
        if embedded_image is None or embedded_image.getSvgImage() is not None:
            continue

        raster_image = embedded_image.getImage()
        try:
            raster_image.save("extracted-image.png", ImageFormat.Png)
        finally:
            raster_image.dispose()
        break
finally:
    presentation.dispose()
```

A raster kép mentése a kinyert képet a kért kimeneti formátumba konvertálja. Ha a prezentációban tárolt kódolt bájtokra van szükséged egy konvertált raster fájl helyett, használd inkább a képernyőforrás bináris adatát.

### **SVG kép kinyerése**

SVG kép esetén a [PPImage](https://reference.aspose.com/slides/hu/python-java/aspose.slides/ppimage/) egy [SvgImage](https://reference.aspose.com/slides/hu/python-java/aspose.slides/svgimage/) objektumot biztosít. Ez lehetővé teszi, hogy közvetlenül lekérd az SVG adatot, ahelyett, hogy először rasterizálnád a képet.
```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import Presentation, PictureFrame

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for shape in slide.getShapes():
        if not isinstance(shape, PictureFrame):
            continue

        picture_frame = shape
        embedded_image = picture_frame.getPictureFormat().getPicture().getImage()
        svg_image = embedded_image.getSvgImage() if embedded_image is not None else None
        if svg_image is None:
            continue

        svg_data = svg_image.getSvgData()
        Path("extracted-image.svg").write_bytes(bytes(svg_data))
        break
finally:
    presentation.dispose()
```

Az SVG tartalom SVG‑nek megtartása megőrzi a vektoralapot a prezentáción belül. A raster exportok, például PNG vagy JPEG, kötelezően a vektor tartalmat pixelekre renderelik. A PDF vagy SVG dia export is egy renderelési művelet, ezért az exportált grafikát nem szabad az eredeti beágyazott SVG bit‑pontos másolatának tekinteni; használd a beágyazott [SvgImage.getSvgData](https://reference.aspose.com/slides/hu/python-java/aspose.slides/svgimage/#getSvgData) adatot, ha magára a vektorforrásra van szükség.

## **Kép levágása**

A levágás megváltoztatja, hogy a kép mely része látható a kereten belül. A [PictureFillFormat](https://reference.aspose.com/slides/hu/python-java/aspose.slides/picturefillformat/) levágási értékei a forráskép méretének százalékai. A levágás kezdetben nem törli a rejtett pixeleket a beágyazott képből; csak a látható területet módosítja.

A következő példa biztonságosan megtalál egy képkeretet, és alkalmazza a levágási értékeket:
```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, PictureFrame

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    picture_frame = None

    for shape in slide.getShapes():
        if isinstance(shape, PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        picture_frame.getPictureFormat().setCropLeft(23.6)
        picture_frame.getPictureFormat().setCropRight(21.5)
        picture_frame.getPictureFormat().setCropTop(3)
        picture_frame.getPictureFormat().setCropBottom(31)
        presentation.save("cropped-image.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Mivel a rejtett képadatok még jelen vannak, a levágás később megváltoztatható az eredeti pixelek elvesztése nélkül. Ha a fájlméret fontosabb, mint a visszafordíthatóság, a levágott területeket fizikailag eltávolíthatod a következő szakaszban leírt módon.

## **Levágott képadatok eltávolítása**

[PictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/hu/python-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) eltávolítja a képadatokat a jelenlegi levágási téglalapon kívül, és visszaadja a keletkezett képernyőforrást. Ez csökkentheti a fájlméretet, de destruktív optimalizáció: a prezentáció mentése után az eltávolított pixelek már nem állnak rendelkezésre egy későbbi visszaállítási művelethez.
```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, PictureFrame

presentation = Presentation("cropped-image.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    picture_frame = None

    for shape in slide.getShapes():
        if isinstance(shape, PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        cropped_image = picture_frame.getPictureFormat().deletePictureCroppedAreas()
        if cropped_image is not None:
            presentation.save("cropped-data-removed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

A metódus új képernyőforrást is hozzáadhat a prezentációhoz. Ha az eredeti képet más képkeretek is használják, azoknak még mindig szükségük van a meglévő forrásra, így a levágott területek törlése nem feltétlenül csökkenti a képek összes számát. WMF vagy EMF tartalom levágása ezzel a módszerrel a levágott eredményt PNG‑re rasterizálja.

## **Raster képek tömörítése**

[PictureFillFormat.compressImage](https://reference.aspose.com/slides/hu/python-java/aspose.slides/picturefillformat/#compressImage) csökkenti a raster kép felbontását a kép megjelenítési méretéhez képest. Ugyanebben a műveletben eltávolíthatja a levágott területeket is. A metódus `True` értéket ad vissza, ha a képet átméretezték vagy levágták, és `False`‑t, ha nem volt szükség változtatásra.

Használj előre definiált [PicturesCompression](https://reference.aspose.com/slides/hu/python-java/aspose.slides/picturescompression/) értéket, ha egy szabványos célfelbontás elegendő:
```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PicturesCompression, Presentation, SaveFormat, PictureFrame

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    picture_frame = None

    for shape in slide.getShapes():
        if isinstance(shape, PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        compressed = picture_frame.getPictureFormat().compressImage(True, PicturesCompression.Dpi150)
        print("The image was compressed." if compressed else "No compression was necessary.")
        presentation.save("compressed-image.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Egy egyedi pozitív DPI érték is megadható előre definiált érték helyett, ha egy specifikus cél szükséges.

A tömörítés raster képekre van tervezve. Az SVG és a metafájl tartalom nem csökken ebben a raster tömörítési munkafolyamatban. Ne feledd, hogy az alacsonyabb felbontás és a törölt levágott területek nem állíthatók vissza az optimalizált prezentációból. Válassz célfelbontást a kép ténylegesen megtekintett vagy exportált legnagyobb mérete alapján, ne alkalmazd a legalacsonyabb DPI‑t globálisan.

## **Képek transzformációs effektusainak kezelése**

Egy teljes munkafolyamat, amely a fényerőt, kontrasztot, színátalakításokat, elmosást, alfa effektusokat, sorrendelt láncokat, ellenőrzést, eltávolítást és körkörös ellenőrzést fedi le, megtalálható a [Image Transform Effects](/slides/hu/python-java/image-transform-effects/) oldalon.

## **Képkeret geometria zárolása**

A [PictureFrameLock](https://reference.aspose.com/slides/hu/python-java/aspose.slides/pictureframelock/) beállítások szabályozzák, hogy mely szerkesztési műveletek vannak letiltva egy képkeretnél. Például a [setAspectRatioLocked](https://reference.aspose.com/slides/hu/python-java/aspose.slides/pictureframelock/#setAspectRatioLocked) megőrzi a forma arányait, miközben átméreteződik.
```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_image = Images.fromFile("photo.jpg")
    try:
        image = presentation.getImages().addImage(source_image)
    finally:
        source_image.dispose()

    picture_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 100, image.getWidth(), image.getHeight(), image)
    picture_frame.getPictureFrameLock().setAspectRatioLocked(True)

    presentation.save("locked-picture-frame.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

A zárolás a képkeret alakzatára vonatkozik. Nem kényszeríti a forrásképet, hogy újra legyen mintavéve vagy állandóan ugyanarra az arányra módosítva.

## **StretchOffset értékek beállítása**

Ha a kép kitöltési mód nyújtás (stretch), a [PictureFillFormat](https://reference.aspose.com/slides/hu/python-java/aspose.slides/picturefillformat/) stretch-offset értékei a kitöltési téglalapot a képkeret határoló dobozához viszonyítva határozzák meg. A pozitív százalékok szélről befelé húznak, míg a negatív százalékok kifelé nyújtanak.

Ez eltér a levágástól. A levágási értékek azt határozzák meg, a forráskép mely része látható; a stretch offset értékek pedig a téglalapot változtatják meg, amelybe a látható képkitöltés nyújtva lesz.
```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, PictureFillMode, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_image = Images.fromFile("photo.png")
    try:
        image = presentation.getImages().addImage(source_image)
    finally:
        source_image.dispose()

    picture_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 400, 300, image)
    picture_frame.getPictureFormat().setPictureFillMode(PictureFillMode.Stretch)
    picture_frame.getPictureFormat().setStretchOffsetLeft(12)
    picture_frame.getPictureFormat().setStretchOffsetRight(12)
    picture_frame.getPictureFormat().setStretchOffsetTop(8)
    picture_frame.getPictureFormat().setStretchOffsetBottom(8)

    presentation.save("stretch-offsets.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Használd a stretch offseteket a kitöltés elhelyezéséhez. A crop tulajdonságokat pedig akkor, amikor a cél a forráskép szélének elrejtése.

## **Tárolás, fájlméret és export szempontok**

A fő kompromisszumok könnyebben kezelhetők, ha a képtárolást és a képkeret formázását külön kezeljük:
- **Beágyazott képek** önállóvá teszik a prezentációt, és a legmegbízhatóbbak a megosztás és a szerveroldali renderelés során, azonban a nagy raster képek megnövelik a PPTX méretét és a memóriahasználatot.
- **Csatolt képek** a csomagot kisebbre tudják tartani, de a prezentáció függ a külső fájloktól, amelyeknek a tárolt útvonalakon vagy helyeken elérhetőknek kell maradniuk.
- **Levágás** eleinte nem destruktív. A rejtett pixelek beágyazva maradnak, amíg a levágott területeket kifejezetten nem törlik vagy a tömörítés során nem távolítják el.
- **Tömörítés** jelentősen csökkentheti a fájlméretet a túl nagy raster képek esetén, de a forrásfelbontás rovására megy. Alkalmazni kell, miután a diában tervezett méret ismert.
- **SVG képek** esetén maradniuk kell SVG formátumban, ha a vektor megőrzése fontos. Kinyerheted a beágyazott SVG‑t közvetlenül, ha magára a vektorforrásra van szükség. A raster dia exportok mindig a renderelt diát pixelekre konvertálják.
- **Ismétlődő képek** esetén használj újra egy meglévő [PPImage](https://reference.aspose.com/slides/hu/python-java/aspose.slides/ppimage/) forrást, ha lehetséges, ahelyett, hogy ugyanazt a fájlt többször betöltenéd a prezentáció munkafolyamatába.

## **GYIK**

**Mi a különbség a képkeret és a képernyőforrás között?**

A [PPImage](https://reference.aspose.com/slides/hu/python-java/aspose.slides/ppimage/) a prezentációhoz kapcsolódó képernyőforrást képviseli. A [PictureFrame](https://reference.aspose.com/slides/hu/python-java/aspose.slides/pictureframe/) egy dián lévő forma, amely képet jelenít meg, és tárolja a keret szintű geometriát és formázást, mint például méret, forgatás, levágási értékek, effektek és zárolások.

**Be kell-e ágyaznom, vagy kell-e csatolnom a képeket?**

Ágyazz be képeket, ha a prezentációnak hordozhatónak, archiválhatónak vagy külső források nélkül renderelhetőnek kell lennie. Csak akkor csatolj képeket, ha a képfájlokat a PPTX‑en kívül szándékosan tartod, és a külső helyeket megbízhatóan tudod fenntartani.

**Csökkenti-e a levágás a PPTX fájlméretét?**

Önmagában nem. A normál levágási beállítások elrejtik a forráskép részeit, de megtartják az alatta lévő pixeleket. Használd a [PictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/hu/python-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) vagy a képtömörítést levágott területek eltávolításával, ha ezeket a pixeleket végleg el lehet dobni.

**Vissza tudom állítani a képminőséget a tömörítés után?**

Nem. A tömörítés csökkentheti a tárolt raster felbontást, és a levágott területek eltávolítása eldobja a képadatokat. Tartsd meg az eredeti forrásképet a prezentáción kívül, ha később nagy felbontású szerkesztésre lehet szükség.

**Hogyan kell kezelni az SVG képeket?**

Tartsd meg az SVG tartalmat SVG‑nek, ha a vektor pontosság fontos. A beágyazott [SvgImage](https://reference.aspose.com/slides/hu/python-java/aspose.slides/svgimage/) közvetlenül kinyerhető. Egy dia raster formátumba, például PNG vagy JPEG formátumba történő renderelése rasterizálja az SVG‑t a dia képeként.

**Hogyan kerülhetem el a nem biztonságos átalakításokat meglévő diák olvasásakor?**

Ellenőrizd a forma típusát, mielőtt képkeretre specifikus tagokat használnál. Egy `isinstance` ellenőrzés a [PictureFrame](https://reference.aspose.com/slides/hu/python-java/aspose.slides/pictureframe/) ellen megakadályozza az érvénytelen átalakításokat, és lehetővé teszi a kód számára, hogy olyan diákot kezeljen, amelyek nem tartalmaznak képkereteket.