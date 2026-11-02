---
title: "Jelölt és számozott listák kezelése prezentációkban Pythonon keresztül Java használatával"
linktitle: "Listák kezelése"
type: docs
weight: 60
url: /hu/python-java/manage-lists/
keywords:
- "feliratozás"
- "jelölt lista"
- "számozott lista"
- "szimbólumos feliratozás"
- "képes feliratozás"
- "egyéni feliratozás"
- "többszintű lista"
- "feliratozás létrehozása"
- "feliratozás hozzáadása"
- "lista hozzáadása"
- "PowerPoint"
- "OpenDocument"
- "prezentáció"
- "Python"
- "Java"
- "Aspose.Slides"
description: "Ismerje meg, hogyan hozhat létre és formázhat jelölt listákat, képes feliratozásokat, többszintű listákat és számozott listákat PowerPoint és OpenDocument prezentációkban az Aspose.Slides for Python via Java használatával."
---
## **Áttekintés**

Az Aspose.Slides for Python via Java lehetővé teszi a jelölt és számozott listák létrehozását és formázását PowerPoint és OpenDocument prezentációkban. A listaelem egy bekezdés, amelynek feliratozási beállításait a bekezdés formátum szabályozza.

Használd a [Paragraph.getParagraphFormat](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/#getParagraphFormat) metódust a bekezdés szintű lista beállítások eléréséhez. A fő belépési pont a [ParagraphFormat.getBullet](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getBullet), amely egy [BulletFormat](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/) objektumot ad vissza. Ezzel az objektummal beállíthatod a feliratozás típusát, szimbólumát, képét, színét, méretét, számozási stílusát és a kezdő számot.

Ez a cikk azt mutatja be, hogyan:

- egy egyéni szimbólummal rendelkező jelölt listát létrehozni
- képfeliratozást létrehozni
- többszintű listát létrehozni a bekezdés mélységének beállításával
- számozott listát létrehozni
- megnézni és módosítani a lista formázását egy meglévő prezentációban
- valódi listajelölőket és számokat olvasni a bekezdés szövegével együtt

## **Jelölt lista létrehozása**

Jelölt lista létrehozásához adj [Paragraph](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/) objektumokat egy [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/)-hez, és állítsd be a [BulletFormat.setType](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#setType) értékét [BulletType.Symbol](https://reference.aspose.com/slides/python-java/aspose.slides/bullettype/#Symbol)-ra. Ezután használhatod a [BulletFormat.setChar](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#setChar), a [BulletFormat.getColor](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#getColor) és a [BulletFormat.setHeight](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#setHeight) metódusokat a feliratozás megjelenésének szabályozásához.

A következő Python kód bemutatja, hogyan hozhatsz létre jelölt listát egy dián:

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

![A szimbólum feliratozások](symbol_bullets.png)

## **Számozott lista létrehozása**

Használj számozott listákat, ha az elemek sorrendje fontos. Állítsd be a [BulletFormat.setType](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#setType) értékét [BulletType.Numbered](https://reference.aspose.com/slides/python-java/aspose.slides/bullettype/#Numbered)-ra. Választhatsz számozási formátumot a [BulletFormat.setNumberedBulletStyle](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#setNumberedBulletStyle) segítségével, vagy használhatod a [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#setNumberedBulletStartWith) metódust, ha a lista nem 1‑től kell, hogy induljon.

A következő Python kód megmutatja, hogyan hozhatsz létre számozott listát egy dián:

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

![A számozott feliratozások](numbered_bullets.png)

## **Képfeliratozás létrehozása**

Az Aspose.Slides lehetővé teszi egy szabályos feliratozási szimbólum helyettesítését egy képpel. A képes feliratozások legjobban egyszerű, kis méretben is olvasható képekkel működnek, például ikonokkal vagy kis átlátszó PNG fájlokkal.

{{% alert color="info" title="Note" %}}
Ha azt tervezed, hogy egy szabályos feliratozási szimbólumot képpel helyettesítesz, válassz egyszerű grafikát átlátszó háttérrel. Ilyen képek jól használhatók egyéni feliratozási szimbólumokként.
{{% /alert %}}

Tartsd szem előtt, hogy a képet nagyon kicsire fogják átméretezni. Emiatt erősen ajánljuk, hogy olyat válassz, amely tiszta és vizuálisan hatékony marad, amikor feliratozásként jelenik meg egy listában.

Képes feliratozás létrehozásához adj egy képet a [Presentation.getImages](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getImages) metódushoz, és a visszakapott képobjektumot rendeld a [BulletFormat.getPicture](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#getPicture) metódusnak. A kép hozzárendelése előtt állítsd be a [BulletFormat.setType](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#setType) értékét [BulletType.Picture](https://reference.aspose.com/slides/python-java/aspose.slides/bullettype/#Picture)-ra.

Tegyük fel, hogy van egy „image.png” nevű képfájlunk:

![Kép a feliratozásokhoz](picture_for_bullets.png)

A következő Python kód megmutatja, hogyan hozhatsz létre képes feliratozásokat egy dián:

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

![A képfeliratozások](picture_bullets.png)

## **Többszintű lista létrehozása**

Használd a [ParagraphFormat.setDepth](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setDepth) metódust, hogy a listaelemeket különböző szinteken helyezd el. A 0‑szint a legfelső, az 1‑szint alatta helyezkedik el, stb.

A következő Python kód megmutatja, hogyan hozhatsz létre többszintű jelölt listát:

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

Meglévő prezentációban a lista formázásának módosításához érj el a célbe kezdett bekezdést, és frissítsd a [ParagraphFormat.getBullet](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getBullet) beállításait. A listák létrehozásához használt ugyanazok a tulajdonságok használhatók a PPT, PPTX vagy ODP fájlból betöltött listák ellenőrzésére vagy módosítására.

A következő Python kód a szövegkeret első bekezdését számozott lista stílusra állítja:

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

## **Valódi feliratozási értékek olvasása**

Prezentáció tartalmának kinyerésekor tartsd meg a lista jelölőket a bekezdés szövegével együtt. Hívd meg a [ParagraphFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getEffective) metódust, és a `getBullet` segítségével szerezd meg a tényleges feliratozási formátumot. A `getActualBulletValue` meghívása előtt ellenőrizd a `getType` értékét.

Számozott listák esetén a következő három értéket különböztetjük meg:

- `getNumberedBulletStyle` határozza meg a formátumot, például arab számok ponttal vagy kisbetűs betűk ponttal.
- `getNumberedBulletStartWith` határozza meg a kezdő számot egy számozott bekezdéscsoport számára.
- `getActualBulletValue` visszaadja egy adott bekezdés formázott jelzőjét. Például egy 5‑től kezdődő listában a második elem `6.`‑ot ad.

Tartsd meg a [getDepth](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getDepth) értékét minden bekezdésnél, hogy megőrizd a beágyazottsági szintet. A tényleges jelző nem kódolja a teljes hierarchiát: egy beágyazott elem `c.`‑t adhat vissza a `6.c.`‑helyett.

Az alábbi önálló példa listákat hoz létre, elmenti őket egy prezentációba, majd újratölti a prezentációt, és minden bekezdés szövegét, mélységét, feliratozási típusát és valós értékét jelentésezi. A kicsi kék képjelző inline SVG‑ből készült.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, FillType, NullableBool, NumberedBulletStyle, Paragraph, Presentation, SaveFormat, ShapeType, SlideSizeScaleType, SvgImage
from java.awt import Color

presentation = Presentation()
try:
    presentation.getSlideSize().setSize(720, 440, SlideSizeScaleType.DoNotScale)
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 20, 660, 400)
    shape.getFillFormat().setFillType(FillType.NoFill)
    shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill)

    text_frame = shape.getTextFrame()
    text_frame.getParagraphs().clear()

    # Készítsen egy képes jelölőt külső képfájl nélkül.
    svg = SvgImage("<svg xmlns='http://www.w3.org/2000/svg' width='16' height='16'><rect width='16' height='16' rx='4' fill='#0078D4'/></svg>")
    bullet_image = presentation.getImages().addImage(svg)

    def add_paragraph(text, depth, bullet_type, start, style):
        paragraph = Paragraph()
        paragraph.setText(text)

        paragraph_format = paragraph.getParagraphFormat()
        paragraph_format.setDepth(depth)
        paragraph_format.setMarginLeft(30 + depth * 40)
        paragraph_format.setIndent(-28)
        paragraph_format.setSpaceAfter(8)
        paragraph_format.getDefaultPortionFormat().setFontHeight(22)
        paragraph_format.getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
        paragraph_format.getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
        paragraph_format.getBullet().setType(bullet_type)
        paragraph_format.getBullet().setBulletHardColor(NullableBool.True_)
        paragraph_format.getBullet().getColor().setColor(Color.BLACK)
        if bullet_type == BulletType.Numbered:
            paragraph_format.getBullet().setNumberedBulletStyle(style)
            paragraph_format.getBullet().setNumberedBulletStartWith(start)
        elif bullet_type == BulletType.Symbol:
            paragraph_format.getBullet().setChar('\u2022')
        elif bullet_type == BulletType.Picture:
            paragraph_format.getBullet().getPicture().setImage(bullet_image)

        text_frame.getParagraphs().add(paragraph)

    add_paragraph("First item", 0, BulletType.Numbered, 5, NumberedBulletStyle.BulletArabicPeriod)
    add_paragraph("Second item", 0, BulletType.Numbered, 5, NumberedBulletStyle.BulletArabicPeriod)
    add_paragraph("Nested item", 1, BulletType.Numbered, 3, NumberedBulletStyle.BulletAlphaLCPeriod)
    add_paragraph("Next nested item", 1, BulletType.Numbered, 3, NumberedBulletStyle.BulletAlphaLCPeriod)
    add_paragraph("Deep item", 2, BulletType.Numbered, 4, NumberedBulletStyle.BulletRomanLCPeriod)
    add_paragraph("Back to top level", 0, BulletType.Numbered, 5, NumberedBulletStyle.BulletArabicPeriod)
    add_paragraph("Symbol marker", 0, BulletType.Symbol, 1, NumberedBulletStyle.BulletArabicPeriod)
    add_paragraph("No bullet", 0, BulletType.None_, 1, NumberedBulletStyle.BulletArabicPeriod)
    add_paragraph("Picture marker", 0, BulletType.Picture, 1, NumberedBulletStyle.BulletArabicPeriod)
    presentation.save("actual_bullet_values.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()

loaded_presentation = Presentation("actual_bullet_values.pptx")
try:
    loaded_shape = loaded_presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    type_names = {
        BulletType.Numbered: "Numbered",
        BulletType.Symbol: "Symbol",
        BulletType.None_: "None",
        BulletType.Picture: "Picture",
    }
    print("Text | Depth | Type | Actual value")
    for paragraph in loaded_shape.getTextFrame().getParagraphs():
        bullet = paragraph.getParagraphFormat().getEffective().getBullet()
        bullet_type = bullet.getType()
        if bullet_type in (BulletType.Numbered, BulletType.Symbol):
            marker = bullet.getActualBulletValue()
        elif bullet_type == BulletType.None_:
            marker = f"{bullet.getActualBulletValue()} (no bullet)"
        elif bullet_type == BulletType.Picture:
            marker = f"{bullet.getActualBulletValue()} (image required)"
        else:
            marker = "unsupported bullet type"
        type_name = type_names.get(bullet_type, "Unknown")
        print(f"{paragraph.getText()} | {paragraph.getParagraphFormat().getDepth()} | {type_name} | {marker}")
finally:
    loaded_presentation.dispose()
```

Az alábbiakban láthatóak a forráslisták.

![5‑től kezdődő listák, beágyazott betű‑ és római számú elemek, egy szimbólum jelző, egy feliratozás nélküli bekezdés, és egy kék képfeliratozó](actual_bullet_values.png)

A jelentés egyezik a PowerPoint‑ban megjelenített jelzőkkel:

```text
Text | Depth | Type | Actual value
First item | 0 | Numbered | 5.
Second item | 0 | Numbered | 6.
Nested item | 1 | Numbered | c.
Next nested item | 1 | Numbered | d.
Deep item | 2 | Numbered | iv.
Back to top level | 0 | Numbered | 7.
Symbol marker | 0 | Symbol | •
No bullet | 0 | None | None (no bullet)
Picture marker | 0 | Picture | None (image required)
```

A [BulletType.None_ és BulletType.Picture](https://reference.aspose.com/slides/python-java/aspose.slides/bullettype/) esetén a `getActualBulletValue` `None`‑t (Java `null`-t) ad vissza, nem üres karakterláncot. Kezeld ezeket a típusokat külön: az elsőnek nincs jelzője, míg a másodiknál a feliratozási képet külön kell kinyerni. A képes feliratozást nem lehet csak szöveges jelző kinyerésével reprodukálni.

## **GYIK**

**Exportálhatóak a jelölt és számozott listák PDF vagy képek formátumba?**

Igen. Az Aspose.Slides megőrzi a lista formázását, ha a célformátum támogatja a megfelelő szövegelrendezést és feliratozási funkciókat.

**Szerkeszthetek listákat meglévő prezentációkban?**

Igen. Töltsd be a prezentációt, érj el a célbe kezdett bekezdést, ellenőrizd vagy frissítsd a [ParagraphFormat.getBullet](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getBullet) beállításait, majd mentsd el a prezentációt.

**Tartalmazhatnak a listák nem latin szöveget?**

Igen. A listaelemek szövege Unicode karaktereket is tartalmazhat, így többnyelvű listákat hozhatsz létre. Győződj meg róla, hogy a prezentációban használt betűtípusok támogatják a szükséges karaktereket.