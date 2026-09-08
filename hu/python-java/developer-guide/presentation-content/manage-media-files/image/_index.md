---
title: Prezentációk képszabályozásának optimalizálása Python használatával
linktitle: Képek kezelése
type: docs
weight: 10
url: /hu/python-java/image/
keywords:
- kép hozzáadása
- kép beillesztése
- kép cseréje
- képgyűjtemény
- képkeret
- hivatkozott kép
- háttér
- PNG hozzáadása
- JPG hozzáadása
- SVG hozzáadása
- SVG alakzatokká
- külső SVG erőforrások
- PowerPoint
- OpenDocument
- prezentáció
- Python
- Java
- Aspose.Slides
description: "Ismerje meg, hogyan adhat hozzá, használhat újra, hivatkozhat, cserélhet és kezelhet raszteres és SVG képeket PowerPoint és OpenDocument prezentációkban az Aspose.Slides for Python via Java segítségével."
---
## **Bevezetés**

Az Aspose.Slides for Python via Java többféle módot biztosít a képekkel való munkához, és mindegyik más célra szolgál. Tárolhat képet egy prezentációban, megjelenítheti azt egy képkeretben, használhatja diak háttérként, hivatkozhat külső képre, cserélhet megosztott kép erőforrást, vagy SVG tartalmat konvertálhat szerkeszthető alakzatokká.

Ez a cikk a kép erőforrásokra és azok használatára összpontosít a prezentációban. A vágás, átlátszóság, hatások, nyújtás és egyéb egyedi képkeretre alkalmazott formázásokért lásd a [Képkeret](/slides/hu/python-java/picture-frame/).

## **Ismerje meg a képmodellt**

A következő API-koncepciók szorosan kapcsolódnak egymáshoz, de nem helyettesíthetők:

- A [prezentáció képgyűjtemény](https://reference.aspose.com/slides/hu/python-java/aspose.slides/imagecollection/) tárolja a prezentáció által használt kép erőforrásokat. Használja az [ImageCollection.addImage](https://reference.aspose.com/slides/hu/python-java/aspose.slides/imagecollection/#addImage) metódust képadatok hozzáadásához, és egy [PPImage](https://reference.aspose.com/slides/hu/python-java/aspose.slides/ppimage/) erőforrást kap.
- A [képkeret](https://reference.aspose.com/slides/hu/python-java/aspose.slides/pictureframe/) egy alakzat, amely képet jelenít meg egy dián, elrendezésen vagy masteren. Használja a [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shapecollection/#addPictureFrame) metódust kép erőforrás elhelyezéséhez a dián.
- A dia háttér egy képet használ a dia kitöltésének részeként, nem alakzatként. Ennek következtében nem viselkedik úgy, mint egy képkeret.
- A [PPImage.replaceImage](https://reference.aspose.com/slides/hu/python-java/aspose.slides/ppimage/#replaceImage) lecserél egy kép erőforrást. Ha több prezentációelem használja azt az erőforrást, mindegyik a cserét használja.
- Az SVG alakzatokká konvertálása szerkeszthető dia alakzatokat hoz létre. A konverzió után a tartalom már nem egy képernyő erőforrásként kerül kezelve.

Ezért a tipikus munkafolyamat a következő: adjon hozzá kép adatot a képgyűjteményhez, kapjon egy [PPImage](https://reference.aspose.com/slides/hu/python-java/aspose.slides/ppimage/) erőforrást, majd használja azt egy vagy több képkeretben vagy kitöltésben.

## **Beágyazott kép hozzáadása**

Helyi kép beszúrásához töltse be a fájlt, adja hozzá a képgyűjteményhez, és hozzon létre egy képkeretet, amely a visszaadott [PPImage](https://reference.aspose.com/slides/hu/python-java/aspose.slides/ppimage/) erőforrást használja.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    source_image = Images.fromFile("photo.png")
    try:
        image = presentation.getImages().addImage(source_image)
    finally:
        source_image.dispose()

    slide = presentation.getSlides().get_Item(0)
    slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 320, 180, image)

    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Így hozzáadott kép beágyazott a prezentációba, ezért a keletkező fájl nem függ a forrás kép fájl elérhetőségétől.

### **Kép hozzáadása a webről**

Ha egy kép HTTP vagy HTTPS-en keresztül érhető el, töltse le a bájtjait, adja hozzá a prezentáció képgyűjteményéhez, és a visszaadott kép erőforrást ugyanúgy használja, mint egy helyi képet.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from urllib.request import urlopen
from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    with urlopen("https://example.com/image.png", timeout=10) as response:
        image_data = response.read()

    image_bytes = jpype.JArray(jpype.JByte)(image_data)
    image = presentation.getImages().addImage(image_bytes)
    slide = presentation.getSlides().get_Item(0)
    slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 320, 180, image)

    presentation.save("presentation-from-web.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Hosszú ideig futó alkalmazásokban újrahasználjon HTTP‑klienst vagy a feladathoz megfelelő kapcsolatkezelési stratégiát, ahelyett, hogy folyamatosan felesleges hálózati infrastruktúrát hozna létre. Emellett ellenőrizze a távoli URL‑eket, a válasz méretét és a tartalom típusát, ha a forrás nem megbízható.

## **Képek újrahasználata diákon át**

Ha ugyanaz a kép többet is szükséges, adja hozzá a prezentációhoz egyszer, majd a visszaadott [PPImage](https://reference.aspose.com/slides/hu/python-java/aspose.slides/ppimage/) erőforrást használja további képkeretek létrehozásakor. Ez elkerüli a forrásadatok többszörös betöltését, és egyértelművé teszi a megosztott kép erőforrás és annak felhasználásai közti kapcsolatot.

Az olyan grafikákhoz, amelyeknek automatikusan meg kell jelenniük sok dián, például egy vállalati logó, fontolja meg, hogy a képkeretet egy [dia master](/slides/hu/python-java/slide-master/) vagy elrendezésre helyezi, ahelyett, hogy minden diára külön alakzatot adna.

## **Kép használata diák háttérként**

A háttérkép a dia kitöltéséhez van hozzárendelve; nem kerül képkeret alakzatként hozzáadásra. Ez akkor hasznos, ha a képnek a dia hátterét kell lefednie, és nem kell normál diaobjektumként manipulálni.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, PictureFillMode, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_image = Images.fromFile("background.jpg")
    try:
        image = presentation.getImages().addImage(source_image)
    finally:
        source_image.dispose()

    slide.getBackground().setType(BackgroundType.OwnBackground)
    slide.getBackground().getFillFormat().setFillType(FillType.Picture)
    slide.getBackground().getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch)
    slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().setImage(image)

    presentation.save("background-image.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

További háttérlehetőségekért, beleértve a master és elrendezés háttereket, lásd a [Prezentáció háttér](/slides/hu/python-java/presentation-background/).

## **Beágyazott és hivatkozott képek**

A beágyazott és a hivatkozott képek különböző hordozhatósági és fájlméretbeli kompromisszumokkal járnak:

- **Beágyazott kép:** a képadat a prezentáción belül tárolódik. A prezentáció önálló, de a fájlméret magában foglalja a képadatot.
- **Hivatkozott kép:** a prezentáció egy útvonalat vagy URL‑t tárol egy külső képre. Ez csökkentheti a prezentáció méretét, de a külső erőforrásnak elérhetőnek kell maradnia a prezentáció megnyitásakor vagy renderelésekor.

Egy hivatkozott képet úgy hozhat létre, hogy a külső útvonalat vagy URL‑t a [Picture.setLinkPathLong](https://reference.aspose.com/slides/hu/python-java/aspose.slides/picture/#setLinkPathLong) metódussal állítja be, a képadat beágyazása helyett.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    picture_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 320, 180, None)
    picture_frame.getPictureFormat().getPicture().setLinkPathLong("https://example.com/image.png")

    presentation.save("linked-image.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Használjon hivatkozott képeket csak akkor, amikor a telepítési környezet megbízhatóan hozzá tud férni a külső erőforráshoz. Offline működő vagy rendszerek között áthelyezendő prezentációk esetén a beágyazott képek általában biztonságosabbak.

## **Működés SVG képekkel**

Az SVG egy vektoros formátum, így hasznos lehet ikonokhoz, diagramokhoz és egyéb grafikákhoz, amelyeknek a részletek elvesztése nélkül kell skálázódniuk, mint a raszteres képek esetében. Az Aspose.Slides támogatja az SVG‑t mind képernyő erőforrásként, mind szerkeszthető dia alakzatok forrásaként.

### **SVG kép hozzáadása**

Hozzon létre egy [SvgImage](https://reference.aspose.com/slides/hu/python-java/aspose.slides/svgimage/) objektumot, adja hozzá a képgyűjteményhez, és helyezze a keletkező kép erőforrást egy képkeretbe.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import Presentation, SaveFormat, ShapeType, SvgImage

presentation = Presentation()
try:
    svg_content = Path("icon.svg").read_text(encoding="utf-8")
    svg_image = SvgImage(svg_content)

    image = presentation.getImages().addImage(svg_image)
    slide = presentation.getSlides().get_Item(0)
    slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 200, 200, image)

    presentation.save("svg-image.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **SVG fájlok külső erőforrásokkal**

Az SVG hivatkozhat külső képekre, stíluslapokra vagy betűtípusokra. Ilyen esetekben a [SvgImage](https://reference.aspose.com/slides/hu/python-java/aspose.slides/svgimage/) olyan konstruktorokat biztosít, amelyek egy [ExternalResourceResolver](https://reference.aspose.com/slides/hu/python-java/aspose.slides/externalresourceresolver/) és egy alap-URI paramétert fogadnak. A resolver képes egy relatív URI‑t egy engedélyezett abszolút URI‑ra leképezni, és visszaad egy adatfolyamot a kért erőforráshoz.

A resolver elérhetővé teszi a külső erőforrásokat, amíg az Aspose.Slides feldolgozza az SVG‑t, de nem írja át az SVG‑t egy önálló dokumentummá. Ha az SVG‑nek hordozhatónak kell maradnia, ágyazza be a szükséges erőforrásokat magába az SVG‑be, például `data:` URI‑k használatával a hivatkozott képekhez.

Amikor az SVG fájlok nem megbízható forrásból érkeznek, korlátozza a sémákat, fájlhelyeket és hostokat, amelyeket a resolver elérhet. A hálózati resolveroknak időkorlátot, válaszméret‑korlátot és tartalom‑validációt is kell alkalmazniuk.

### **SVG konvertálása szerkeszthető alakzatokká**

Az Aspose.Slides képes az SVG‑t szerkeszthető dia alakzatok csoportjává konvertálni, hasonlóan a megfelelő PowerPoint parancshoz.

![PowerPoint felugró menü](img_01_01.png)

Használja a [ShapeCollection.addGroupShape](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shapecollection/#addGroupShape) túlterhelést, amely egy [SvgImage](https://reference.aspose.com/slides/hu/python-java/aspose.slides/svgimage/) objektumot fogad a konverzió végrehajtásához.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import Presentation, SaveFormat, SvgImage

presentation = Presentation()
try:
    svg_content = Path("diagram.svg").read_text(encoding="utf-8")
    svg_image = SvgImage(svg_content)

    slide_size = presentation.getSlideSize().getSize()
    slide = presentation.getSlides().get_Item(0)
    slide_width = jpype.JFloat(slide_size.getWidth())
    slide_height = jpype.JFloat(slide_size.getHeight())
    slide.getShapes().addGroupShape(svg_image, 0, 0, slide_width, slide_height)

    presentation.save("editable-svg-shapes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Használja az SVG‑alakzat konvertálást, ha az egyedi vektor elemeket PowerPoint alakzatként kell szerkeszteni. Ha az SVG csak megjelenítésre van szükség, a képként tartás egyszerűbb és elkerüli a sok különálló alakzat létrehozását.

## **Meglévő kép erőforrás cseréje**

Használja a [PPImage.replaceImage](https://reference.aspose.com/slides/hu/python-java/aspose.slides/ppimage/#replaceImage) metódust, ha egy meglévő kép erőforrást szeretne cserélni. Ez különösen hasznos megosztott grafikák, például logók esetén.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, Presentation, SaveFormat

presentation = Presentation("input.pptx")
try:
    image_to_replace = presentation.getImages().get_Item(0)

    replacement_image = Images.fromFile("new-logo.png")
    try:
        image_to_replace.replaceImage(replacement_image)
    finally:
        replacement_image.dispose()

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Ha több képkeret, háttér, master vagy elrendezés használja ugyanazt a kép erőforrást, a cserélés frissíti az összes ilyen felhasználást. Ha csak egy képkeretet kell módosítani, egy másik képet rendeljünk ahhoz a kerethez a megosztott erőforrás cseréje helyett.

A [PPImage.replaceImage](https://reference.aspose.com/slides/hu/python-java/aspose.slides/ppimage/#replaceImage) további túlterheléseket is kínál, amelyek bájt‑tömböt vagy egy másik [PPImage](https://reference.aspose.com/slides/hu/python-java/aspose.slides/ppimage/) objektumot fogadnak.

## **Gyakorlati képkezelési útmutató**

### **A prezentáció méretének szabályozása**

A nagy raszteres képek feleslegesen nagy méretű prezentációt eredményezhetnek. Használjon forrásképeket a kívánt megjelenítési mérethez megfelelő mérettel, ahol lehetséges újrahasználja a megosztott kép erőforrásokat, és kerülje a ugyanazon teljes felbontású grafika többszöri beágyazását.

Azoknál a raszteres képeknél, amelyeket már képkeretben helyeztek el, a [PictureFillFormat.compressImage](https://reference.aspose.com/slides/hu/python-java/aspose.slides/picturefillformat/#compressImage) csökkentheti a képadatot a kiválasztott felbontás és vágóbeállítások szerint. Ez képkeret-feldolgozás, nem a képgyűjtemény kezelése, ezért lásd a [Képkeret](/slides/hu/python-java/picture-frame/) oldalt a kapcsolódó formázási műveletekhez.

### **Válasszon beágyazott és hivatkozott tartalom között**

A beágyazás hordozhatóvá teszi a prezentációt, mivel minden szükséges képadat a fájllal együtt kerül szállításra. A hivatkozás csökkentheti a fájlméretet, de külső függőséget vezet be. Hivatkozásokat csak akkor használjon, ha a függőség elfogadható és stabil.

### **Megosztott arculat újrahasználata**

Ismétlődő logók, vízjelek vagy díszítő grafikák esetén használjon egy kép erőforrást és újrahasználja. Ha a grafika a prezentáció tervezéséhez tartozik, nem a dia tartalmához, helyezze el egy masterre vagy elrendezésre, hogy a megfelelő diák örököljék.

### **Tartsa hordozhatóan az SVG erőforrásokat**

Egy önálló SVG könnyebben mozgatható és konzisztensen renderelhető, mint egy külső fájlokra vagy hálózati erőforrásokra támaszkodó SVG. Ha lehetséges, ágyazza be a szükséges erőforrásokat az SVG importálása előtt. Konvertálja az SVG‑t alakzatokká csak akkor, ha az egyedi vektor elemeket szerkeszteni kell.

### **Használja a modern többplatformos kép API‑t**

Új Python via Java kódban használja az Aspose.Slides többplatformos kép objektumait és a [Images](https://reference.aspose.com/slides/hu/python-java/aspose.slides/images/) API‑kat a `java.awt.image.BufferedImage` alapú régi nyilvános API helyett. A migrációs útmutatásért lásd a [Modern API](/slides/hu/python-java/modern-api/) oldalt.

A WMF és EMF különleges megfontolást igényel. Ha ezeket a formátumokat egy többplatformos kép objektumon keresztül adjuk át, a [ImageCollection.addImage](https://reference.aspose.com/slides/hu/python-java/aspose.slides/imagecollection/#addImage) a metafájlt raszteres PNG ábrázolássá konvertálja a beszúrás előtt. Ha a metafájl adat megőrzése fontos, használjon adatfolyam‑alapú [ImageCollection.addImage](https://reference.aspose.com/slides/hu/python-java/aspose.slides/imagecollection/#addImage) túlterhelést. Az EMF tartalom generálása táblázatokból vagy más termékekből külön integrációs munkafolyamat, és kívül esik a cikk hatókörén.

## **GYIK**

**Mi a különbség a képgyűjtemény és a képkeret között?**

A képgyűjtemény újrahasználható kép erőforrásokat tárol. A képkeret egy dia alakzat, amely ezeket az erőforrásokat jeleníti meg, és képspecifikus formázást biztosít, például vágást és hatásokat.

**Mi a legjobb módja annak, hogy mindenhol lecseréljük ugyanazt a logót?**

Ha a logó már megosztott egy kép erőforrásként, cserélje azt a [PPImage.replaceImage](https://reference.aspose.com/slides/hu/python-java/aspose.slides/ppimage/#replaceImage) metódussal. A teljes prezentációra kiterjedő arculat esetén a logó masterre vagy elrendezésre való helyezése szintén csökkentheti a duplikált dia tartalmat.

**Miért tűnik el a hivatkozott kép egy másik számítógépen?**

Egy hivatkozott kép a külső fájltól vagy URL‑től függ. Ha a másik számítógépről nem érhető el az erőforrás, a hivatkozott kép nem lesz elérhető. Ágyazza be a képet, ha a prezentációnak önállónak kell maradnia.

**Lehet egy beszúrt SVG‑t PowerPoint alakzatként szerkeszteni?**

Igen. Konvertálja az SVG‑t a [ShapeCollection.addGroupShape](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shapecollection/#addGroupShape) segítségével; az eredményül kapott csoport szerkeszthető dia alakzatokat tartalmaz, nem egy SVG képet.

**Hogyan tarthatom kisebb méretűnek a sok képet tartalmazó prezentációkat?**

Használjon megosztott kép erőforrásokat, kerülje a szükségtelenül nagy raszteres forrásokat, tömörítse a megfelelő raszteres képeket, ha szükséges, tartsa a ismétlődő arculatot masteren vagy elrendezésen, és csak akkor használjon hivatkozott képeket, ha a külső függőség elfogadható.