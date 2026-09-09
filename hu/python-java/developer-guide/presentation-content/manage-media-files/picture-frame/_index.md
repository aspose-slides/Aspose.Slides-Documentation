---
title: Képkeretek kezelése prezentációkban Python használatával
linktitle: Képkeret
type: docs
weight: 10
url: /hu/python-java/picture-frame/
keywords:
- képkeret
- képkeret hozzáadása
- képkeret létrehozása
- beágyazott kép
- összekapcsolt kép
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
- Java
- Aspose.Slides
description: "Képkeretek létrehozása, formázása, összekapcsolása, vágása, kinyerése és tömörítése prezentációkban az Aspose.Slides for Python via Java segítségével."
---
## **Áttekintés**

A picture frame egy dián lévő alakzat, amely egy képet jelenít meg. Az Aspose.Slides-ban a kép erőforrás és a megjelenítő alakzat külön objektumok: egy [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) a beágyazott képernyőforrásokat a saját [ImageCollection](https://reference.aspose.com/slides/hu/python-java/aspose.slides/imagecollection/)‑jén keresztül birtokolja, míg egy [PictureFrame](https://reference.aspose.com/slides/hu/python-java/aspose.slides/pictureframe/) vezérli a kép pozícióját, méretét, vonalformázását, forgatását, vágását, képhatásait és egyéb keret szintű beállításokat.

Ez a megkülönböztetés hasznos, amikor ugyanaz a kép többször is megjelenik. Adja hozzá a képet a prezentációhoz egyszer, tartsa meg a visszaadott [PPImage](https://reference.aspose.com/slides/hu/python-java/aspose.slides/ppimage/), és használja azt a kép erőforrást képkeretek létrehozásakor.

A picture frame tartalmazhat raszteres képeket, például PNG vagy JPEG, valamint vektoros SVG képeket. Emellett hivatkozhatnak összekapcsolt képekre is, ahelyett, hogy a kép bájtjait a prezentációban tárolnák. A választás befolyásolja a hordozhatóságot, a fájlméretet, a kinyerést és az export viselkedését, ezért célszerű eldönteni, hogyan legyen a kép tárolva, mielőtt formázást vagy optimalizálást alkalmazna.

## **Beágyazott kép hozzáadása és formázása**

Beágyazott kép esetén adja hozzá a kép adatait a prezentációhoz, és hozzon létre egy képkeretet a [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shapecollection/#addPictureFrame) metódussal. A kép a prezentáció csomagjának részévé válik, így a prezentáció önálló marad, amikor egy másik számítógépre kerül.

A következő példa egy JPEG képet ad hozzá, a kép natív méreteivel hoz létre egy keretet, és alkalmaz vonalformázást és forgatást:

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

A képkeret szabályozza a megjelenített geometriai adatokat; a keret méretének módosítása nem változtatja meg az eredeti pixelméreteket, amelyek a beágyazott kép erőforrásban tárolódnak. Ez a különbség későbbi képvágás vagy tömörítés esetén fontos.

## **Relatív méretezés használata**

A [PictureFrame](https://reference.aspose.com/slides/hu/python-java/aspose.slides/pictureframe/) a keret relatív szélesség‑ és magasság‑méretezését a [setRelativeScaleWidth](https://reference.aspose.com/slides/hu/python-java/aspose.slides/pictureframe/#setRelativeScaleWidth) és a [setRelativeScaleHeight](https://reference.aspose.com/slides/hu/python-java/aspose.slides/pictureframe/#setRelativeScaleHeight) metódusokon keresztül teszi elérhetővé. Az `1.0` érték az eredeti kép 100%-ának felel meg. A relatív méretezés akkor hasznos, amikor egy munkafolyamatnak a forráskép méretéhez viszonyított arányt kell megőriznie a végső méretek kézi kiszámítása helyett.

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

A relatív méretezés módosítja a keret méretezési beállításait; nem mintavételezi vagy tömöríti a beágyazott képet.

## **Beágyazott és összekapcsolt képek**

Egy beágyazott kép a kép adatokat a prezentációon belül tárolja, ezért a legbiztonságosabb választás a hordozhatóság és a kiszámítható megjelenítés szempontjából. Egy összekapcsolt kép egy külső helyet tárol a [Picture.setLinkPathLong](https://reference.aspose.com/slides/hu/python-java/aspose.slides/picture/#setLinkPathLong) metódus segítségével, ahelyett, hogy úgymond beágyazná a kép adatokat.

Az összekapcsolt képek csökkenthetik a PPTX‑ben tárolt képadatok mennyiségét, ám külső függőséget hoznak be. Az összekapcsolt fájlnak elérhetőnek kell maradnia azon alkalmazás számára, amely a prezentációt megnyitja vagy rendereli. Ha az útvonal megváltozik, a fájl áthelyezésre kerül, vagy az erőforrás nem érhető el, az összekapcsolt kép nem biztos, hogy a várt módon jelenik meg. Azoknak a prezentációknak, amelyeket e‑mailben kell küldeni, archiválni vagy elkülönített környezetben renderelni, a beágyazott képek általában megbízhatóbbak.

### **Összekapcsolt kép hozzáadása**

A következő példa egy képkeretet hoz létre, és egy helyi képfájlra mutat. Csak a képösszekapcsolást kezeli; a videóösszekapcsolás egy külön média munkafolyamat, és szándékosan nincs belekeverve ebbe a példába.

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

Használjon hivatkozásokat, ha a külső fájlkezelés szándékos. Ne használja őket csupán a tömörítés helyettesítésére: egy kis PPTX, ahol a képfüggőségek megszakadtak, általában kevésbé hasznos, mint egy nagyobb önálló prezentáció.

## **Képek kinyerése képkeretekből**

Mielőtt képet nyerne ki egy meglévő prezentációból, ellenőrizze, hogy az alakzat valóban egy [PictureFrame](https://reference.aspose.com/slides/hu/python-java/aspose.slides/pictureframe/)‑e, és hogy tartalmaz‑e beágyazott képet. Az összekapcsolt képkeretek esetleg nem tartalmaznak kép bájtokat, amelyeket ugyanúgy ki lehetne nyerni.

### **Raszteres kép kinyerése**

A modern kép API közvetlenül raszteres képekkel dolgozik, és nem igényli a régebbi Java képbevonót. A következő példa megtalálja az első beágyazott raszteres képet egy dián, és PNG‑ként menti el:

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

A raszteres kép mentése a kinyert képet a kívánt kimeneti formátumba konvertálja. Ha a prezentációban tárolt kódolt bájtokra van szüksége egy átalakított raszteres fájl helyett, akkor használja a kép erőforrás bináris adatait.

### **SVG kép kinyerése**

SVG kép esetén a [PPImage](https://reference.aspose.com/slides/hu/python-java/aspose.slides/ppimage/) egy [SvgImage](https://reference.aspose.com/slides/hu/python-java/aspose.slides/svgimage/) objektumot tesz elérhetővé. Ez lehetővé teszi az SVG adat közvetlen lekérését, a kép első rasterizálása nélkül.

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

Az SVG tartalom SVGként történő megőrzése megőrzi a vektor forrást a prezentációban. A PNG vagy JPEG‑hez hasonló raszteres exportok szükségszerűen pixelekre renderelik a vektor tartalmat. A PDF vagy SVG dia exportja szintén egy renderelési művelet, ezért az exportált grafika nem tekinthető az eredeti beágyazott SVG byte‑ról‑byte‑ra másolatának; használd a beágyazott [SvgImage.getSvgData](https://reference.aspose.com/slides/hu/python-java/aspose.slides/svgimage/#getSvgData) adatot, ha magára a vektor erőforrásra van szükség.

## **Kép vágása**

A vágás megváltoztatja, hogy a kép mely része látható a kereten belül. A [PictureFillFormat](https://reference.aspose.com/slides/hu/python-java/aspose.slides/picturefillformat/) vágási értékei a forráskép méretének százalékai. A vágás eleinte nem törli a rejtett pixeleket a beágyazott képből; csak a látható régiót módosítja.

A következő példa biztonságosan megtalál egy képkeretet, és alkalmazza a vágási értékeket:

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

Mivel a rejtett képadatok még mindig jelen vannak, a vágás később megváltoztatható az eredeti pixelek elvesztése nélkül. Ha a fájlméret fontosabb, mint a visszafordíthatóság, a vágott területek fizikailag eltávolíthatók, ahogy a következő szakaszban le van írva.

## **Vágott képadatok eltávolítása**

A [PictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/hu/python-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) eltávolítja a képadatokat a jelenlegi vágótéglalap kívül, és visszaadja a keletkezett kép erőforrást. Ez csökkentheti a fájlméretet, de destruktív optimalizáció: a prezentáció mentése után az eltávolított pixelek már nem állnak rendelkezésre egy későbbi vágás visszavonása esetén.

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

A metódus új kép erőforrást adhat a prezentációhoz. Ha az eredeti képet más képkeretek is használják, azoknak továbbra is szükségük van a meglévő erőforrásra, ezért a vágott területek törlése nem feltétlenül csökkenti a képek teljes számát. WMF vagy EMF tartalom ilyen módszerrel történő vágása a vágott eredményt PNG‑re rasterizálja.

## **Raszteres képek tömörítése**

A [PictureFillFormat.compressImage](https://reference.aspose.com/slides/hu/python-java/aspose.slides/picturefillformat/#compressImage) csökkenti a raszteres kép felbontását a kép megjelenítési méretéhez képest. Ugyanebben a műveletben eltávolíthatja a vágott területeket is. A metódus `True` értékkel tér vissza, ha a képet átméretezték vagy vágották, és `False`‑al, ha változtatás nem volt szükséges.

Használjon előre definiált [PicturesCompression](https://reference.aspose.com/slides/hu/python-java/aspose.slides/picturescompression/) értéket, amikor egy szabványos célfelbontás elegendő:

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

Egy egyedi pozitív DPI érték adható meg előre definiált érték helyett, ha egy meghatározott cél szükséges.

A tömörítés raszteres képekre vonatkozik. SVG és metafájl tartalom nem csökken ezzel a raszteres tömörítési munkafolyamattal. Emlékezzen arra is, hogy az alacsonyabb felbontás és a törölt vágott területek nem állíthatók helyre az optimalizált prezentációból. Válasszon célfelbontást a kép legnagyobb megjelenítési vagy exportálási mérete alapján, ahelyett, hogy globálisan a legalacsonyabb DPI‑t alkalmazná.

## **Képtranszformációs hatások kezelése**

A fényerő, kontraszt, színátalakítások, elmosás, alfa hatások, rendezett láncok, ellenőrzés, eltávolítás és körkörös ellenőrzés lefedését tartalmazó teljes munkafolyamatért tekintse meg a [Képtranszformációs hatások](/slides/hu/python-java/image-transform-effects/) oldalt.

## **Képkeret geometria zárolása**

A [PictureFrameLock](https://reference.aspose.com/slides/hu/python-java/aspose.slides/pictureframelock/) beállítások szabályozzák, hogy mely szerkesztési műveletek vannak letiltva egy képkeret esetén. Például a [setAspectRatioLocked](https://reference.aspose.com/slides/hu/python-java/aspose.slides/pictureframelock/#setAspectRatioLocked) megőrzi az alakzat arányait, miközben méreteződik.

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

A zárolás a képkeret alakzatra vonatkozik. Nem kényszeríti a forrásképet azonos arányra való újramintavételezésre vagy állandó módosításra.

## **StretchOffset értékek módosítása**

Ha a kép kitöltési mód a nyújtás, a [PictureFillFormat](https://reference.aspose.com/slides/hu/python-java/aspose.slides/picturefillformat/) stretch‑offset értékei a kitöltő téglalapot a képkeret határoló keretéhez viszonyítva definiálják. A pozitív százalékok egy belső eltolást hoznak létre az élről, míg a negatív százalékok egy külső kitolást.

Ez eltér a vágástól. A vágási értékek meghatározzák, a forráskép mely része látható; a stretch offsetok megváltoztatják azt a téglalapot, amelybe a látható kép kitöltése nyújtásra kerül.

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

Használja a stretch offsetokat a kitöltés elhelyezéséhez. Használja a vágás tulajdonságait, ha a cél a forráskép széleinek elrejtése.

## **Tárolás, fájlméret és exportálási szempontok**

A fő kompromisszumok könnyebben kezelhetők, ha a képtárolást és a képkeret formázást külön kezelik:

- **Beágyazott képek** teszik a prezentációt önállóvá, és a legmegbízhatóbban használhatók megosztásra és szerveroldali renderelésre, de a nagy raszteres képek növelik a PPTX méretét és a memóriahasználatot.
- **Összekapcsolt képek** kisebbre tarthatják a csomagot, de a prezentáció a tárolt útvonalakon vagy helyeken elérhető külső fájloktól függ.
- **Vágás** kezdetben nem destruktív. A rejtett pixelek a vágott területek kifejezett törléséig vagy a tömörítés során történő eltávolításáig beágyazva maradnak.
- **Tömörítés** jelentősen csökkentheti a fájlméretet a túl nagy raszteres képek esetén, de a forrásfelbontás rovására megy. Alkalmazni kell, miután a diáon való megjelenítendő méret ismert.
- **SVG képek** akkor maradjanak SVG formátumban, ha a vektorigazítás fontos. Nyissa ki a beágyazott SVG‑t közvetlenül, ha a vektor erőforrásra van szükség. A raszteres dia exportok mindig a renderelt diát pixelekre konvertálják.
- **Ismétlődő képek** esetén célszerű egy meglévő [PPImage](https://reference.aspose.com/slides/hu/python-java/aspose.slides/ppimage/) erőforrást újra felhasználni, ahelyett, hogy ugyanazt a fájlt többször betöltené a prezentáció munkafolyamatába.

Nagy prezentációk esetén a képek optimalizálása általában akkor a leghatékonyabb, ha szelektíven végezzük: tartsuk a logókat és diagramokat vektortartalomként, tömörítsük a fényképeket a tényleges megjelenítési méretüknek megfelelően, csak akkor távolítsuk el a vágott pixeleket, ha a későbbi szerkesztés nem szükséges, és kerüljük az külső hivatkozásokat, hacsak a függőségkezelés nem része a telepítési tervezésnek.

## **GYIK**

**Mi a különbség a képkeret és a kép erőforrás között?**

A [PPImage](https://reference.aspose.com/slides/hu/python-java/aspose.slides/ppimage/) egy a prezentációhoz társított kép erőforrást képvisel. A [PictureFrame](https://reference.aspose.com/slides/hu/python-java/aspose.slides/pictureframe/) egy dián lévő alakzat, amely képet jelenít meg, és a keret szintű geometriai és formázási adatokat tárolja, mint például méret, forgatás, vágási értékek, hatások és zárolások.

**Be kéne-e ágyazni vagy összekapcsolni a képeket?**

Ágyazza be a képeket, ha a prezentációnak hordozhatónak, archiválhatónak vagy külső erőforrások nélkül renderelhetőnek kell lennie. Kapcsolja össze a képeket csak akkor, ha a kép fájlok a PPTX‑en kívül történő tárolása szándékos, és a külső helyeket megbízhatóan tudja fenntartani.

**Csökkenti-e a vágás a PPTX fájlméretét?**

Nem önmagában. A normál vágási beállítások elrejtik a forráskép részleteit, de megtartják a mögöttes pixeleket. Használja a [PictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/hu/python-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) metódust vagy a képtömörítést vágott terület eltávolítással, ha ezek a pixelek véglegesen eltávolíthatók.

**Vissza lehet-e állítani a képminőséget a tömörítés után?**

Nem. A tömörítés csökkentheti a tárolt raszteres felbontást, és a vágott területek eltávolítása a képadatok elvesztését eredményezi. Tartsa meg az eredeti forrásképet a prezentáción kívül, ha későbbi nagy felbontású szerkesztésre lehet szükség.

**Hogyan kell kezelni az SVG képeket?**

Tartsa az SVG tartalmat SVG‑ként, ha a vektor pontosság fontos. A beágyazott [SvgImage](https://reference.aspose.com/slides/hu/python-java/aspose.slides/svgimage/) közvetlenül kinyerhető. A diák raszteres formátumba, például PNG vagy JPEG konvertálása rasterizálja az SVG‑t a dia képének részeként.

**Hogyan kerülhetem el a nem biztonságos átkódolásokat a meglévő diák olvasásakor?**

Ellenőrizze az alakzat típusát, mielőtt képkeret‑specifikus tagokat használna. Az `isinstance` ellenőrzés a [PictureFrame](https://reference.aspose.com/slides/hu/python-java/aspose.slides/pictureframe/) ellen elkerüli az érvénytelen átkódolásokat, és lehetővé teszi a kód számára, hogy azokkal a diákkal is megbirkózzon, amelyek nem tartalmaznak képkereteket.