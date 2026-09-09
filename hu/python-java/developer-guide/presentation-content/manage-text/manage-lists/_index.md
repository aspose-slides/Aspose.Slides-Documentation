---
title: Gyorstaláncolt és számozott listák kezelése prezentációkban Python via Java használatával
linktitle: Listák kezelése
type: docs
weight: 60
url: /hu/python-java/manage-lists/
keywords:
- felsorolásjel
- felsorolásjeles lista
- számozott lista
- szimbólum felsorolásjel
- képes felsorolásjel
- egyedi felsorolásjel
- többszintű lista
- felsorolásjel létrehozása
- felsorolásjel hozzáadása
- lista hozzáadása
- PowerPoint
- OpenDocument
- prezentáció
- Python
- Java
- Aspose.Slides
description: "Tudja meg, hogyan hozhat létre és formázhat felsorolásjeles listákat, képes felsorolásjeleket, többszintű listákat és számozott listákat PowerPoint és OpenDocument prezentációkban az Aspose.Slides for Python via Java használatával."
---
## **Áttekintés**

Az Aspose.Slides for Python via Java lehetővé teszi, hogy felsorolásjelekkel ellátott és számozott listákat hozzon létre és formázzon PowerPoint és OpenDocument prezentációkban. Egy listaelem egy bekezdés, amelynek a felsorolásjel beállításait a bekezdés formátuma vezérli.

Használja a [Paragraph.getParagraphFormat](https://reference.aspose.com/slides/hu/python-java/aspose.slides/paragraph/#getParagraphFormat) metódust a bekezdés szintű lista beállítások eléréséhez. A fő belépési pont a [ParagraphFormat.getBullet](https://reference.aspose.com/slides/hu/python-java/aspose.slides/paragraphformat/#getBullet), amely egy [BulletFormat](https://reference.aspose.com/slides/hu/python-java/aspose.slides/bulletformat/) objektumot ad vissza. Ezzel az objektummal beállíthatja a felsorolásjel típusát, szimbólumát, képét, színét, méretét, számozási stílusát és a kezdő számot.

Ez a cikk bemutatja, hogyan:

- létrehozni egy felsorolásjeles listát egy egyedi szimbólummal
- létrehozni egy képes felsorolásjelet
- létrehozni egy többszintű listát a bekezdés mélységének beállításával
- létrehozni egy számozott listát
- ellenőrizni és módosítani a lista formázását egy meglévő prezentációban

## **Felsorolásjelekkel ellátott lista létrehozása**

Felsorolásjeles lista létrehozásához adjon [Paragraph](https://reference.aspose.com/slides/hu/python-java/aspose.slides/paragraph/) objektumokat egy [TextFrame](https://reference.aspose.com/slides/hu/python-java/aspose.slides/textframe/)‑hez, és állítsa a [BulletFormat.setType](https://reference.aspose.com/slides/hu/python-java/aspose.slides/bulletformat/#setType) értékét [BulletType.Symbol](https://reference.aspose.com/slides/hu/python-java/aspose.slides/bullettype/#Symbol)-ra. Ezután a [BulletFormat.setChar](https://reference.aspose.com/slides/hu/python-java/aspose.slides/bulletformat/#setChar), a [BulletFormat.getColor](https://reference.aspose.com/slides/hu/python-java/aspose.slides/bulletformat/#getColor) és a [BulletFormat.setHeight](https://reference.aspose.com/slides/hu/python-java/aspose.slides/bulletformat/#setHeight) segítségével szabályozhatja a felsorolásjel megjelenését.

Az alábbi Python kód bemutatja, hogyan hozhat létre felsorolásjeles listát egy dián:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, NullableBool, Paragraph, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 200, 50)

    text_frame = auto_shape.getTextFrame()
    text_frame.getParagraphs().clear()

    bullet_color = Color(205, 92, 92)

    first_paragraph = Paragraph()
    first_paragraph.getParagraphFormat().getBullet().setType(BulletType.Symbol)
    first_paragraph.getParagraphFormat().getBullet().setChar('*')
    first_paragraph.getParagraphFormat().setIndent(15)
    first_paragraph.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True_)
    first_paragraph.getParagraphFormat().getBullet().getColor().setColor(bullet_color)
    first_paragraph.getParagraphFormat().getBullet().setHeight(100)
    first_paragraph.setText("The first paragraph")
    text_frame.getParagraphs().add(first_paragraph)

    second_paragraph = Paragraph()
    second_paragraph.getParagraphFormat().getBullet().setType(BulletType.Symbol)
    second_paragraph.getParagraphFormat().getBullet().setChar('*')
    second_paragraph.getParagraphFormat().setIndent(15)
    second_paragraph.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True_)
    second_paragraph.getParagraphFormat().getBullet().getColor().setColor(bullet_color)
    second_paragraph.getParagraphFormat().getBullet().setHeight(100)
    second_paragraph.setText("The second paragraph")
    text_frame.getParagraphs().add(second_paragraph)

    presentation.save("symbol_bullets.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Az eredmény:

![A szimbólum felsorolásjelek](symbol_bullets.png)

## **Számozott lista létrehozása**

Használjon számozott listákat, ha az elemek sorrendje fontos. Állítsa a [BulletFormat.setType](https://reference.aspose.com/slides/hu/python-java/aspose.slides/bulletformat/#setType) értékét [BulletType.Numbered](https://reference.aspose.com/slides/hu/python-java/aspose.slides/bullettype/#Numbered)-ra. A [BulletFormat.setNumberedBulletStyle](https://reference.aspose.com/slides/hu/python-java/aspose.slides/bulletformat/#setNumberedBulletStyle) segítségével kiválaszthat egy számozási formátumot, vagy a [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/hu/python-java/aspose.slides/bulletformat/#setNumberedBulletStartWith) használatával megadhatja, hogy a lista ne az 1‑es számmal kezdődjön.

Az alábbi Python kód bemutatja, hogyan hozhat létre számozott listát egy dián:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, Paragraph, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 90, 80)

    text_frame = auto_shape.getTextFrame()
    text_frame.getParagraphs().clear()

    first_paragraph = Paragraph()
    first_paragraph.getParagraphFormat().getBullet().setType(BulletType.Numbered)
    first_paragraph.setText("Apple")
    text_frame.getParagraphs().add(first_paragraph)

    second_paragraph = Paragraph()
    second_paragraph.getParagraphFormat().getBullet().setType(BulletType.Numbered)
    second_paragraph.setText("Orange")
    text_frame.getParagraphs().add(second_paragraph)

    third_paragraph = Paragraph()
    third_paragraph.getParagraphFormat().getBullet().setType(BulletType.Numbered)
    third_paragraph.setText("Banana")
    text_frame.getParagraphs().add(third_paragraph)

    presentation.save("numbered_bullets.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Az eredmény:

![A számozott felsorolásjelek](numbered_bullets.png)

## **Képes felsorolásjel létrehozása**

Az Aspose.Slides lehetővé teszi, hogy a szabályos felsorolásjel szimbólumát egy képpel helyettesítse. A képes felsorolásjelek a legegyszerűbb, kis méretben is olvasható képekkel működnek a legjobban, például ikonokkal vagy kis átlátszó PNG fájlokkal.

{{% alert color="info" title="Note" %}}
Ha a szabályos felsorolásjel szimbólumát képpel szeretné helyettesíteni, válasszon egyszerű grafikát átlátszó háttérrel. Az ilyen képek jól működnek egyedi felsorolásjel szimbólumokként.

Ne feledje, hogy a képet nagyon kicsi méretre fogják méretezni. Emiatt határozottan ajánljuk, hogy olyan képet válasszon, amely a lista felsorolásjeleként használva is tiszta és vizuálisan hatékony marad.
{{% /alert %}}

Képes felsorolásjel létrehozásához adjon egy képet a [Presentation.getImages](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/#getImages) metódushoz, és rendelje hozzá a visszakapott képobjektumot a [BulletFormat.getPicture](https://reference.aspose.com/slides/hu/python-java/aspose.slides/bulletformat/#getPicture)‑hez. A kép hozzárendelése előtt állítsa a [BulletFormat.setType](https://reference.aspose.com/slides/hu/python-java/aspose.slides/bulletformat/#setType) értékét [BulletType.Picture](https://reference.aspose.com/slides/hu/python-java/aspose.slides/bullettype/#Picture)-ra.

Tegyük fel, hogy van egy `image.png` nevű képünk:

![Kép a felsorolásjelekhez](picture_for_bullets.png)

Az alábbi Python kód bemutatja, hogyan hozhat létre képes felsorolásjeleket egy dián:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, Images, Paragraph, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 200, 50)

    text_frame = auto_shape.getTextFrame()
    text_frame.getParagraphs().clear()

    image = Images.fromFile("image.png")
    try:
        bullet_image = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    first_paragraph = Paragraph()
    first_paragraph.getParagraphFormat().getBullet().setType(BulletType.Picture)
    first_paragraph.getParagraphFormat().getBullet().getPicture().setImage(bullet_image)
    first_paragraph.getParagraphFormat().setIndent(15)
    first_paragraph.getParagraphFormat().getBullet().setHeight(100)
    first_paragraph.setText("The first paragraph")
    text_frame.getParagraphs().add(first_paragraph)

    second_paragraph = Paragraph()
    second_paragraph.getParagraphFormat().getBullet().setType(BulletType.Picture)
    second_paragraph.getParagraphFormat().getBullet().getPicture().setImage(bullet_image)
    second_paragraph.getParagraphFormat().setIndent(15)
    second_paragraph.getParagraphFormat().getBullet().setHeight(100)
    second_paragraph.setText("The second paragraph")
    text_frame.getParagraphs().add(second_paragraph)

    presentation.save("picture_bullets.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Az eredmény:

![A képes felsorolásjelek](picture_bullets.png)

## **Többszintű lista létrehozása**

Használja a [ParagraphFormat.setDepth](https://reference.aspose.com/slides/hu/python-java/aspose.slides/paragraphformat/#setDepth) metódust a listaelemek különböző szintekre helyezéséhez. A 0. szint a legfelső szint, az 1. szint alatta van, és így tovább.

Az alábbi Python kód bemutatja, hogyan hozhat létre többszintű felsorolásjeles listát:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Paragraph, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 260, 110)

    text_frame = auto_shape.getTextFrame()
    text_frame.getParagraphs().clear()

    first_paragraph = Paragraph()
    first_paragraph.getParagraphFormat().setDepth(0)
    first_paragraph.setText("My text - Depth 0")
    text_frame.getParagraphs().add(first_paragraph)

    second_paragraph = Paragraph()
    second_paragraph.getParagraphFormat().setDepth(1)
    second_paragraph.setText("My text - Depth 1")
    text_frame.getParagraphs().add(second_paragraph)

    third_paragraph = Paragraph()
    third_paragraph.getParagraphFormat().setDepth(2)
    third_paragraph.setText("My text - Depth 2")
    text_frame.getParagraphs().add(third_paragraph)

    fourth_paragraph = Paragraph()
    fourth_paragraph.getParagraphFormat().setDepth(3)
    fourth_paragraph.setText("My text - Depth 3")
    text_frame.getParagraphs().add(fourth_paragraph)

    presentation.save("multilevel_bullets.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Az eredmény:

![A többszintű lista](multilevel_list.png)

## **Meglévő lista módosítása**

A lista formázásának módosításához egy meglévő prezentációban, érje el a cél bekezdést, és frissítse annak [ParagraphFormat.getBullet](https://reference.aspose.com/slides/hu/python-java/aspose.slides/paragraphformat/#getBullet) beállításait. A listák létrehozásához használt ugyanazok a tulajdonságok használhatók a PPT, PPTX vagy ODP fájlból betöltött listák ellenőrzésére vagy módosítására.

Az alábbi Python kód megváltoztatja a szövegkeret első bekezdését, hogy számozott lista stílust használjon:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, NumberedBulletStyle, Presentation, SaveFormat

presentation = Presentation("input.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    paragraph.getParagraphFormat().getBullet().setType(BulletType.Numbered)
    paragraph.getParagraphFormat().getBullet().setNumberedBulletStyle(NumberedBulletStyle.BulletRomanUCPeriod)
    paragraph.getParagraphFormat().getBullet().setNumberedBulletStartWith(1)
    paragraph.getParagraphFormat().setMarginLeft(30)
    paragraph.getParagraphFormat().setIndent(-20)

    presentation.save("updated_list.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **GYIK**

**Exportálhatók a felsorolásjelekkel és számozott listákkal PDF vagy képek formátumba?**

Igen. Az Aspose.Slides megőrzi a lista formázását, amikor a célformátum támogatja a megfelelő szövegelrendezést és felsorolásjel‑funkciókat.

**Szerkeszthetek listákat meglévő prezentációkban?**

Igen. Töltse be a prezentációt, érje el a cél bekezdést, ellenőrizze vagy frissítse annak [ParagraphFormat.getBullet](https://reference.aspose.com/slides/hu/python-java/aspose.slides/paragraphformat/#getBullet) beállításait, majd mentse a prezentációt.

**Tartalmazhatnak a listák nem latin betűket?**

Igen. A listaelemek szövege tartalmazhat Unicode karaktereket, így készíthet listákat többnyelvű prezentációkban. Győződjön meg arról, hogy a prezentációban használt betűtípusok támogatják a szükséges karaktereket.