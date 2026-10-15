---
title: PowerPoint szövegbekezdések kezelése Pythonon keresztül Java-val
linktitle: Bekezdés kezelése
type: docs
weight: 40
url: /hu/python-java/manage-paragraph/
aliases:
  - /python-java/paragraph/
  - /python-java/portion/
keywords:
- szöveg hozzáadása
- bekezdés hozzáadása
- szöveg kezelése
- bekezdés kezelése
- felsorolás kezelése
- bekezdés behúzása
- függő behúzás
- bekezdés felsorolás
- számozott lista
- felsorolt lista
- bekezdés tulajdonságok
- HTML importálása
- szöveg HTML-be
- bekezdés HTML-be
- bekezdés képpé
- szöveg képpé
- bekezdés exportálása
- PowerPoint
- prezentáció
- Python
- Java
- Aspose.Slides
description: "Ismerje meg, hogyan lehet bekezdéseket, részeket, felsorolásokat, számozott listákat, behúzásokat, HTML tartalmat és bekezdés képeket létrehozni és formázni az Aspose.Slides for Python via Java segítségével."
---
## **Áttekintés**

Az Aspose.Slides for Python via Java a szöveget szövegkeretek, bekezdések és részek hierarchiájaként ábrázolja:

* [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/) a formában a szöveg tárolóját képviseli, és hozzáférést biztosít a bekezdésgyűjteményéhez.
* [Paragraph](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/) egy bekezdést képvisel egy szövegkeretben, és hozzáférést biztosít a részeihez és a bekezdés-szintű formázáshoz.
* [Portion](https://reference.aspose.com/slides/python-java/aspose.slides/portion/) egy szövegfolyamot képvisel egy bekezdésen belül. Minden résznek saját szövege és karakter-szintű formázása lehet.

Ezáltal egy bekezdés különböző betűtípusú, színű, méretű és egyéb formázású szöveget tartalmazhat több rész használatával.

## **Bekezdések létrehozása és formázása**

Hozzon létre bekezdéseket egy alakzat szövegkeretében, és használjon részeket az egyedi szövegfolyamok formázásához. Ez a rész bemutatja, hogyan lehet több részt kombinálni egy bekezdésen belül, és különböző színeket, betűméreteket és stílusokat alkalmazni.

### **Több részes bekezdések létrehozása**

Az alábbi Python példa három bekezdést hoz létre, mindegyik három szövegfolyamot tartalmaz a [Paragraph.getPortions](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/#getPortions) által visszaadott gyűjteményben. Újrahasználja az alapértelmezett bekezdést és annak üres részét, majd hozzáadja a többi bekezdést és részt. A formázás a [Portion.getPortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/portion/#getPortionFormat) segítségével alkalmazódik: az első rész minden bekezdésben piros, félkövér és 15 pont; a második kék, dőlt és 18 pont. A harmadik rész megőrzi az alapértelmezett formázását:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, NullableBool, Paragraph, Portion, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 300, 150)
    text_frame = shape.getTextFrame()

    first_paragraph = text_frame.getParagraphs().get_Item(0)
    first_paragraph.getPortions().add(Portion())
    first_paragraph.getPortions().add(Portion())

    second_paragraph = Paragraph()
    second_paragraph.getPortions().add(Portion())
    second_paragraph.getPortions().add(Portion())
    second_paragraph.getPortions().add(Portion())
    text_frame.getParagraphs().add(second_paragraph)

    third_paragraph = Paragraph()
    third_paragraph.getPortions().add(Portion())
    third_paragraph.getPortions().add(Portion())
    third_paragraph.getPortions().add(Portion())
    text_frame.getParagraphs().add(third_paragraph)

    paragraph_count = text_frame.getParagraphs().getCount()
    for paragraph_index in range(paragraph_count):
        paragraph = text_frame.getParagraphs().get_Item(paragraph_index)
        portion_count = paragraph.getPortions().getCount()
        for portion_index in range(portion_count):
            portion = paragraph.getPortions().get_Item(portion_index)
            portion.setText(f"Portion {paragraph_index + 1}.{portion_index + 1}")

            if portion_index == 0:
                portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.RED)
                portion.getPortionFormat().setFontBold(NullableBool.True_)
                portion.getPortionFormat().setFontHeight(15)
            elif portion_index == 1:
                portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
                portion.getPortionFormat().setFontItalic(NullableBool.True_)
                portion.getPortionFormat().setFontHeight(18)

    presentation.save("paragraphs_with_portions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Felsorolások és számozott listák létrehozása**

Szervezze a bekezdés szövegét listákba szimbólumokkal, számokkal vagy egyedi képekkel. A szakasz példái a felsorolásformázást, a többszintű listákat és az egyéni kezdőszámokat fedik le.

### **Felsorolás vagy számozott lista létrehozása**

A felsorolások és a számozás megkönnyítik a kapcsolódó elemek átláthatóságát. Az Aspose.Slides-ben a lista beállításait a [BulletFormat](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/) definiálja.

Ez a Python példa egy szimbólum felsorolást és egy számozott elemet ad ugyanahhoz a szövegkerethez. A [BulletFormat.setType](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#setType) a felsorolás típusát választja, míg a [BulletFormat.setChar](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#setChar) a szimbólumot adja meg, és a [BulletFormat.setNumberedBulletStyle](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#setNumberedBulletStyle) a számozási stílust. Mindkét elem fekete felsorolást használ 100 százalékos magassággal és 25 pont bekezdésbehúzással:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, ColorType, NullableBool, NumberedBulletStyle, Paragraph, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = shape.getTextFrame()
    text_frame.getParagraphs().clear()

    symbol_paragraph = Paragraph()
    symbol_paragraph.setText("Welcome to Aspose.Slides")
    symbol_paragraph.getParagraphFormat().getBullet().setType(BulletType.Symbol)
    symbol_paragraph.getParagraphFormat().getBullet().setChar("•")
    symbol_paragraph.getParagraphFormat().setIndent(25)
    symbol_paragraph.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB)
    symbol_paragraph.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK)
    symbol_paragraph.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True_)
    symbol_paragraph.getParagraphFormat().getBullet().setHeight(100)
    text_frame.getParagraphs().add(symbol_paragraph)

    numbered_paragraph = Paragraph()
    numbered_paragraph.setText("This is a numbered item")
    numbered_paragraph.getParagraphFormat().getBullet().setType(BulletType.Numbered)
    numbered_paragraph.getParagraphFormat().getBullet().setNumberedBulletStyle(NumberedBulletStyle.BulletCircleNumWDBlackPlain)
    numbered_paragraph.getParagraphFormat().setIndent(25)
    numbered_paragraph.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB)
    numbered_paragraph.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK)
    numbered_paragraph.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True_)
    numbered_paragraph.getParagraphFormat().getBullet().setHeight(100)
    text_frame.getParagraphs().add(numbered_paragraph)

    presentation.save("bulleted_and_numbered_list.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Kép alapú felsorolások használata**

A kép alapú felsorolások lehetővé teszik egy egyedi kép használatát szimbólum vagy szám helyett.

Ez a Python példa egy képet ad a prezentáció képgyűjteményéhez [PPImage](https://reference.aspose.com/slides/python-java/aspose.slides/ppimage/) formájában, és azt használja bekezdés felsorolásként. A [BulletFormat.setType](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#setType) hívásával kép alapú felsorolást állít be, és a képet a [BulletFormat.getPicture](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#getPicture) segítségével rendeli hozzá. A [BulletFormat.setHeight](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#setHeight) 100 százalékra van állítva, hogy a felsorolás mérete a bekezdés szövegéhez viszonyítva legyen:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, Images, Paragraph, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    bullet_image = Images.fromFile("bullets.png")
    try:
        presentation_image = presentation.getImages().addImage(bullet_image)
    finally:
        bullet_image.dispose()

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = shape.getTextFrame()
    text_frame.getParagraphs().clear()

    paragraph = Paragraph()
    paragraph.setText("Welcome to Aspose.Slides")
    paragraph.getParagraphFormat().getBullet().setType(BulletType.Picture)
    paragraph.getParagraphFormat().getBullet().getPicture().setImage(presentation_image)
    paragraph.getParagraphFormat().getBullet().setHeight(100)
    text_frame.getParagraphs().add(paragraph)

    presentation.save("picture_bullet.pptx", SaveFormat.Pptx)
    presentation.save("picture_bullet.ppt", SaveFormat.Ppt)
finally:
    presentation.dispose()
```

### **Többszintű lista létrehozása**

A [ParagraphFormat.setDepth](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setDepth) beállításával a bekezdéseket a lista különböző szintjeire helyezi. A legfelső szint mélysége `0`.

Ez a Python példa a [ParagraphFormat.setDepth](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setDepth) értékeket 0-tól 3-ig rendeli négy bekezdéshez, egy hierarchiát hozva létre egy szövegkereten belül. Minden bekezdés szimbólum felsorolást használ, a [BulletFormat.setChar](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#setChar) pedig kör alakú felsorolás és kötőjel között váltakozik a szomszédos szintek megkülönböztetéséhez:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, FillType, Paragraph, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = shape.getTextFrame()
    text_frame.getParagraphs().clear()

    first_paragraph = Paragraph()
    first_paragraph.setText("Content")
    first_paragraph.getParagraphFormat().getBullet().setType(BulletType.Symbol)
    first_paragraph.getParagraphFormat().getBullet().setChar("•")
    first_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    first_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    first_paragraph.getParagraphFormat().setDepth(0)

    second_paragraph = Paragraph()
    second_paragraph.setText("Second level")
    second_paragraph.getParagraphFormat().getBullet().setType(BulletType.Symbol)
    second_paragraph.getParagraphFormat().getBullet().setChar('-')
    second_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    second_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    second_paragraph.getParagraphFormat().setDepth(1)

    third_paragraph = Paragraph()
    third_paragraph.setText("Third level")
    third_paragraph.getParagraphFormat().getBullet().setType(BulletType.Symbol)
    third_paragraph.getParagraphFormat().getBullet().setChar("•")
    third_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    third_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    third_paragraph.getParagraphFormat().setDepth(2)

    fourth_paragraph = Paragraph()
    fourth_paragraph.setText("Fourth level")
    fourth_paragraph.getParagraphFormat().getBullet().setType(BulletType.Symbol)
    fourth_paragraph.getParagraphFormat().getBullet().setChar('-')
    fourth_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    fourth_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    fourth_paragraph.getParagraphFormat().setDepth(3)

    text_frame.getParagraphs().add(first_paragraph)
    text_frame.getParagraphs().add(second_paragraph)
    text_frame.getParagraphs().add(third_paragraph)
    text_frame.getParagraphs().add(fourth_paragraph)

    presentation.save("multilevel_list.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Számozott listaelemek indítása egyedi értékekkel**

Használja a [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#setNumberedBulletStartWith) függvényt, hogy beállítsa egy számozott bekezdés kezdeti számát.

Ez a Python példa a [BulletFormat.setType](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#setType) beállítással három bekezdés számára számozást alkalmaz, és a [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#setNumberedBulletStartWith) értékeket 2, 3 és 7-re állítja. A kezdő érték minden bekezdésnél külön konfigurálható, lehetővé téve a megjelenített számok kihagyását:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, Paragraph, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = shape.getTextFrame()
    text_frame.getParagraphs().clear()

    first_paragraph = Paragraph()
    first_paragraph.setText("Start at 2")
    first_paragraph.getParagraphFormat().getBullet().setType(BulletType.Numbered)
    first_paragraph.getParagraphFormat().getBullet().setNumberedBulletStartWith(2)

    text_frame.getParagraphs().add(first_paragraph)

    second_paragraph = Paragraph()
    second_paragraph.setText("Start at 3")
    second_paragraph.getParagraphFormat().getBullet().setType(BulletType.Numbered)
    second_paragraph.getParagraphFormat().getBullet().setNumberedBulletStartWith(3)
    text_frame.getParagraphs().add(second_paragraph)

    third_paragraph = Paragraph()
    third_paragraph.setText("Start at 7")
    third_paragraph.getParagraphFormat().getBullet().setType(BulletType.Numbered)
    third_paragraph.getParagraphFormat().getBullet().setNumberedBulletStartWith(7)
    text_frame.getParagraphs().add(third_paragraph)

    presentation.save("custom_numbered_list.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Bekezdéselrendezés és végjellemzők vezérlése**

Állítsa be a bekezdés margóit és behúzásait, hogy szabályozza az első sor és a tördelés sorok helyzetét. A bekezdés zárójelét is formázhatja külön a látható szövegrészektől.

### **Első sor behúzásának beállítása**

Használja a [ParagraphFormat.setIndent](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setIndent) metódust a bekezdés első sorának behúzásának szabályozásához. Ez a beállítás csak az első sort mozgatja a bekezdés bal margójához képest. A pozitív érték az első sort jobbra helyezi, míg a többi sor a bekezdés törzséhez igazodik.

Használja a [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setMarginLeft) függvényt, ha az egész bekezdést akarja elmozgatni. Használja a [ParagraphFormat.setIndent](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setIndent) függvényt, ha csak az első sort akarja elmozgatni.

Az alábbi példa három bekezdést ad ugyanazzal a [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setMarginLeft) 20 pont értékkel, és [ParagraphFormat.setIndent](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setIndent) értékekkel 0, 20 és 40 pontban. Az első sorok egyre nagyobb eltolással indulnak, míg a tördelés sorok ugyanazt a bal margót megtartják:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Paragraph, Presentation, SaveFormat, ShapeType, TextAutofitType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 220)
    shape.getFillFormat().setFillType(FillType.NoFill)
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY)

    text_frame = shape.getTextFrame()
    text_frame.getTextFrameFormat().setAutofitType(TextAutofitType.Shape)
    text_frame.getParagraphs().clear()

    first_paragraph = Paragraph()
    first_paragraph.setText("No first-line indent. Wrapped lines start at the same position as the first line.")
    first_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    first_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    first_paragraph.getParagraphFormat().setMarginLeft(20.0)
    first_paragraph.getParagraphFormat().setIndent(0.0)

    second_paragraph = Paragraph()
    second_paragraph.setText("First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.")
    second_paragraph.getParagraphFormat().getDefaultPortionFormat().setFillType(FillType.Solid)
    second_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    second_paragraph.getParagraphFormat().setMarginLeft(20.0)
    second_paragraph.getParagraphFormat().setIndent(20.0)

    third_paragraph = Paragraph()
    third_paragraph.setText("First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.")
    third_paragraph.getParagraphFormat().getDefaultPortionFormat().setFillType(FillType.Solid)
    third_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    third_paragraph.getParagraphFormat().setMarginLeft(20.0)
    third_paragraph.getParagraphFormat().setIndent(40.0)

    text_frame.getParagraphs().add(first_paragraph)
    text_frame.getParagraphs().add(second_paragraph)
    text_frame.getParagraphs().add(third_paragraph)

    presentation.save("paragraph_indent.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

The result:

![The first-line indent of the paragraphs](first_line_indent.png)

### **Függő behúzás beállítása**

A függő behúzás egy olyan bekezdéselrendezés, ahol az első sor a többi sor bal oldalán kezdődik. Az Aspose.Slides-ben ezt a hatást a [ParagraphFormat.setIndent](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setIndent) tulajdonsággal hozhatja létre. Állítsa az `Indent` értékét negatívra, hogy az első sor a bekezdés törzséhez képest balra mozduljon.

Gyakorlatban a [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setMarginLeft) határozza meg a bekezdés törzsének bal pozícióját, és a [ParagraphFormat.setIndent](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setIndent) az első sor pozícióját a margóhoz képest. Függő behúzás létrehozásához állítson be pozitív `MarginLeft` értéket és negatív `Indent` értéket.

Ez a formázás hasznos bibliográfiákhoz, hivatkozásokhoz, szójegyzék bejegyzésekhez és egyéb bekezdésekhez, ahol a tördelés soroknak a bekezdés törzse alá kell illeszkedniük, nem pedig az első sor első karaktere alá.

Az alábbi Python példa a [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setMarginLeft) 40 és 60 pont értékeit párosítja a [ParagraphFormat.setIndent](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setIndent) -20 és -30 pont értékeivel. Minden bekezdésben az első sor a tördelés sorok bal oldalán kezdődik; a második bekezdés mélyebb függő behúzással rendelkezik:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Paragraph, Presentation, SaveFormat, ShapeType, TextAutofitType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 220)
    shape.getFillFormat().setFillType(FillType.NoFill)
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY)

    text_frame = shape.getTextFrame()
    text_frame.getTextFrameFormat().setAutofitType(TextAutofitType.Shape)
    text_frame.getParagraphs().clear()

    first_paragraph = Paragraph()
    first_paragraph.setText("A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.")
    first_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    first_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    first_paragraph.getParagraphFormat().setMarginLeft(40.0)
    first_paragraph.getParagraphFormat().setIndent(-20.0)

    second_paragraph = Paragraph()
    second_paragraph.setText("This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.")
    second_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    second_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    second_paragraph.getParagraphFormat().setMarginLeft(60.0)
    second_paragraph.getParagraphFormat().setIndent(-30.0)

    text_frame.getParagraphs().add(first_paragraph)
    text_frame.getParagraphs().add(second_paragraph)

    presentation.save("hanging_indent.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

The result:

![The hanging indent of the paragraphs](hanging_indent.png)

### **Bekezdés vége futás tulajdonságainak beállítása**

A [Paragraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/#setEndParagraphPortionFormat) metódus szabályozza a bekezdés végjelének formázását. A következő példa egy [PortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/portionformat/) objektumot hoz létre, amelynek a [BasePortionFormat.setFontHeight](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setFontHeight) 48 pontra, a [BasePortionFormat.setLatinFont](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setLatinFont) pedig Times New Roman-ra van állítva. Ezt a formátumot a második bekezdés végjeléhez rendeli, miközben a látható szövegrészek változatlanok maradnak:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, Paragraph, Portion, PortionFormat, Presentation, SaveFormat, ShapeType

presentation = Presentation("Test.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 200, 250)
    text_frame = shape.getTextFrame()
    text_frame.getParagraphs().clear()

    first_paragraph = Paragraph()
    first_portion = Portion("Sample text")
    first_paragraph.getPortions().add(first_portion)

    second_paragraph = Paragraph()
    second_portion = Portion("Sample text 2")
    second_paragraph.getPortions().add(second_portion)

    end_paragraph_format = PortionFormat()
    end_paragraph_format.setFontHeight(48)
    latin_font = FontData("Times New Roman")
    end_paragraph_format.setLatinFont(latin_font)
    second_paragraph.setEndParagraphPortionFormat(end_paragraph_format)

    text_frame.getParagraphs().add(first_paragraph)
    text_frame.getParagraphs().add(second_paragraph)

    presentation.save("end_paragraph_format.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Megjelenített sorok számlálása**

A bekezdés szabályokhoz, amelyek az automatikus tördelést és a sorvégi írásjeleket érintik, lásd a [Control Line Breaking](/slides/hu/python-java/text-formatting/#control-line-breaking) és a [Control Hanging Punctuation](/slides/hu/python-java/text-formatting/#control-hanging-punctuation) cikkeket.

Használja a [Paragraph.getLinesCount](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/#getLinesCount) függvényt a bekezdés által a szövegelrendezés után elfoglalt sorok számolásához, beleértve az automatikus tördelést. Ez hasznos a szöveghossz és elrendezés ellenőrzésénél prezentáció sablonokban.

Egy bekezdés egy elem a [TextFrame.getParagraphs](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/#getParagraphs) gyűjteményben, és több megjelenített sort is elfoglalhat. Egy explicite sortörés a bekezdésen belül új sort hoz létre anélkül, hogy új bekezdést generálna. Az automatikus tördelés a rendelkezésre álló szélesség alapján hoz létre sorokat, anélkül, hogy explicite sortöréseket szúrna be a szövegbe. Ezért a bekezdések vagy sortörés karakterek számlálása nem adja meg a megjelenített sorok számát.

Az alábbi példa egy szöveges alakzatot hoz létre, megszámolja a sorait, szűkíti az alakzatot, majd a szöveget egy rövidebb karakterláncra cseréli. A példa a [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setWrapText) segítségével engedélyezi a tördelést, és a [TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setAutofitType) segítségével letiltja az automatikus illesztést, így az alakzat szélessége szabályozza a tördelést anélkül, hogy automatikusan kicsinyítené a szöveget vagy módosítaná az alakzat méretét. Minden mérés a [Paragraph.getLinesCount](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/#getLinesCount) használatával történik. Az alakzat méretei pontban vannak megadva. Végül a példa egy további bekezdést ad hozzá, és összeadja a sorok számát a szövegkeretben.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NullableBool, Paragraph, Presentation, ShapeType, TextAutofitType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 400, 200)
    text_frame = shape.getTextFrame()
    text_frame.getTextFrameFormat().setWrapText(NullableBool.True_)
    text_frame.getTextFrameFormat().setAutofitType(TextAutofitType.None_)

    paragraph = text_frame.getParagraphs().get_Item(0)
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(20)
    paragraph.setText("This text demonstrates how automatic wrapping changes the number of rendered lines.")
    print("Original width:", paragraph.getLinesCount())

    shape.setWidth(150)
    print("Narrower shape:", paragraph.getLinesCount())

    paragraph.setText("Short text.")
    print("Shorter text:", paragraph.getLinesCount())

    second_paragraph = Paragraph()
    second_paragraph.setText("Another paragraph.")
    second_paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(20)
    text_frame.getParagraphs().add(second_paragraph)

    total_line_count = 0
    for current_paragraph in text_frame.getParagraphs():
        total_line_count += current_paragraph.getLinesCount()
    print("Total lines in the text frame:", total_line_count)
finally:
    presentation.dispose()
```

Ezzel a szöveggel és ezekkel a méretekkel a forma szűkítése növeli a sorok számát, míg a szöveg rövid karakterláncra cserélése csökkenti azt. A pontos számok függnek a betűtípus elérhetőségétől és helyettesítésétől, betűmérettől, margóktól, behúzástól, tördeléstől és az automatikus illesztés beállításaitól. A sablon ellenőrzésekor használja a célnak megfelelő betűtípusokat és elrendezési beállításokat.

A sorok száma önmagában nem határozza meg, hogy a szöveg túlcsordul-e a tárolójától. Az elérhető magasság, sormagasság, bekezdés- és sorköz, valamint az automatikus illesztés viselkedése is számít; még egyetlen sor is meghaladhatja a rendelkezésre álló szélességet, ha a tördelés le van tiltva.

## **Bekezdés tartalmának importálása és exportálása**

Használjon HTML-t a szöveg egy prezentációba való beillesztéséhez vagy a meglévő bekezdések exportálásához külső használatra. Ez a szakasz bemutatja, hogyan lehet egyedi bekezdéseket képeként megjeleníteni, beleértve a táblázatcellákban lévő bekezdéseket is.

### **HTML szöveg importálása bekezdésekbe**

Használja a [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphcollection/#addFromHtml) metódust a HTML jelölés bekezdésekké és részekké alakításához egy szövegkeretben.

Ez a Python példa egy fájlból olvas HTML-t, és átadja a jelölést a [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphcollection/#addFromHtml) metódusnak. Törli a szövegkeret alapértelmezett bekezdését, hogy a keret csak az importált tartalmat tartalmazza. A téglalap alakzat minden oldalán 10 pont margót hagy a dián:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from pathlib import Path

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape_width = presentation.getSlideSize().getSize().getWidth() - 20
    shape_height = presentation.getSlideSize().getSize().getHeight() - 20

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, shape_width, shape_height)
    shape.getFillFormat().setFillType(FillType.NoFill)
    shape.getTextFrame().getParagraphs().clear()

    try:
        html = Path("file.html").read_text(encoding="utf-8")
        shape.getTextFrame().getParagraphs().addFromHtml(html)

        presentation.save("html_text.pptx", SaveFormat.Pptx)
    except OSError as exception:
        print("The HTML file could not be read: " + str(exception))
finally:
    presentation.dispose()
```

### **Bekezdés szövegének exportálása HTML-be**

Használja a [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphcollection/#exportToHtml) metódust a kiválasztott bekezdéstartomány HTML-ként való exportálásához. Amikor a prezentáció szövegét egy weboldalon újra felhasználja, megőrizheti a helyi hangsúlyt anélkül, hogy a prezentáció betűtípusa, mérete vagy szövegdoboz stílusa átkerülne. Állítsa be a [TextToHtmlConversionOptions.setTextInheritanceLimit](https://reference.aspose.com/slides/python-java/aspose.slides/texttohtmlconversionoptions/#setTextInheritanceLimit) értékét, hogy szabályozza, milyen mértékben követi az exportáló a formázás öröklődését.

Töltse le a [mintaprezentációt](text-inheritance.pptx) és helyezze az alkalmazás munkakönyvtárába. Az első diája egy szöveges alakzatot tartalmaz a "Inherited text; explicit red 18pt" szöveggel. A bemenet szándékosan több formázási szintet használ:

- A prezentáció alapértelmezett szövegstílusa Calibri-t és 28 pt méretet ad.
- A szövegkeret első szintű szövegstílusa kék szöveget és dőlt betűt ad.
- A bekezdés kifejezetten félkövér szöveget állít be.
- A második rész, "explicit red 18pt", kifejezetten piros szöveget és 18 pt méretet állít be.

Az alábbi teljes példa háromszor exportálja ugyanazokat a bekezdéseket. A [TextToHtmlConversionOptions](https://reference.aspose.com/slides/python-java/aspose.slides/texttohtmlconversionoptions/) objektumot átadja az export metódusnak, és minden eredményt külön UTF-8 HTML fájlba ír:

```python
import jpype
import asposeslides
from pathlib import Path

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Presentation, TextInheritanceLimit, TextToHtmlConversionOptions

presentation = Presentation("text-inheritance.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)

    if isinstance(shape, AutoShape):
        text_frame = shape.getTextFrame()
        if text_frame is not None:
            paragraphs = text_frame.getParagraphs()
            
            modes = [TextInheritanceLimit.All, TextInheritanceLimit.TextBox, TextInheritanceLimit.ParagraphOnly]
            file_names = ["All.html", "TextBox.html", "ParagraphOnly.html"]

            for mode, file_name in zip(modes, file_names):
                options = TextToHtmlConversionOptions()
                options.setTextInheritanceLimit(mode)

                html = paragraphs.exportToHtml(0, paragraphs.getCount(), options)
                try:
                    Path(file_name).write_text(str(html), encoding="utf-8")
                except OSError as exception:
                    print("The HTML file could not be written: " + str(exception))
        else:
            print("The first shape does not contain a text frame.")
    else:
        print("The first shape is not a text shape.")
finally:
    presentation.dispose()
```

A generált HTML a következő CSS-t tartalmazza az első részhez, "Inherited text; ". A táblázat felsorolja a releváns deklarációkat; a többi generált tulajdonság az érthetőség kedvéért hiányzik.

| Output | Az első részhez tartozó releváns CSS | Megjelenés |
| --- | --- | --- |
| `All.html` | `font-family:'Calibri'; font-size:28pt; color:#0000ff; font-style:italic; font-weight:bold` | Kék, félkövér, dőlt szöveg 28 pt Calibri betűtípussal, ha az elérhető. |
| `TextBox.html` | `color:#0000ff; font-style:italic; font-weight:bold` | Kék, félkövér, dőlt szöveg; a környező oldal vagy böngésző biztosítja a betűcsaládot és méretet. |
| `ParagraphOnly.html` | `font-weight:bold` | Félkövér szöveg; a környező oldal vagy böngésző biztosítja a betűcsaládot, méretet, színt és dőlt stílust. |

A második rész megtartja a `color:#ff0000`, `font-size:18pt` és `font-weight:bold` értékeket mindhárom kimenetben. Emellett megtartja a dőlt stílust az `All` és `TextBox` esetén, de nem a `ParagraphOnly` esetén. Az öröklődés korlátozása ezért nem távolítja el a bekezdéshez vagy részhez kifejezetten hozzárendelt formázást.

Nyissa meg a fájlokat ugyanabban a böngészőben a összehasonlításhoz. A két korlátozott módban a kihagyott CSS tulajdonságokat a célnak megfelelő oldal stílusai vagy a böngésző alapértelmezett beállításai oldják fel, így a végső megjelenés attól függ, hogy hol használják a HTML-t.

### **Bekezdés megjelenítése képként**

A [Paragraph.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/) közvetlenül megjeleníti az egyedi bekezdést és egy képtárgyat ad vissza. A `save` metódusával mentse az eredményt fájlba vagy streambe. Nem szükséges a környező alakzatot megjeleníteni vagy a bitmapet manuálisan vágni.

A [Paragraph.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/) `None` értéket adhat vissza, ha a bekezdés nem található a szülő gyűjteményben, nincs érvényes renderelési határa, vagy nem jeleníthető meg. Ellenőrizze az eredményt a mentés előtt, és használat után szabadítsa fel a visszakapott képet.

#### **Bekezdés megjelenítése alapértelmezett méretezéssel**

A példa egy olyan prezentációt használ, amely egy diát tartalmaz, és az első alakzat egy három bekezdést tartalmazó szövegdoboz.

![The text box with three paragraphs](paragraph_to_image_input.png)

Az alábbi példa a második bekezdést (index 1) választja ki, és a [Paragraph.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/) metódust skálaparaméterek nélkül hívja meg. Ellenőrzi, hogy az alakzat tartalmazza-e a szükséges bekezdést, és hogy a renderelés képet ad-e vissza, mielőtt a `save` metódusával PNG formátumban mentené. A `finally` blokk a kép használat után felszabadítja azt.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, ImageFormat, Presentation

presentation = Presentation("sample.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)

    if isinstance(shape, AutoShape):
        text_shape = shape
        text_frame = text_shape.getTextFrame()
        if text_frame is not None and text_frame.getParagraphs().getCount() > 1:
            paragraph = text_frame.getParagraphs().get_Item(1)
            paragraph_image = paragraph.getImage()

            if paragraph_image is not None:
                try:
                    paragraph_image.save("paragraph.png", ImageFormat.Png)
                finally:
                    paragraph_image.dispose()
            else:
                print("The paragraph could not be rendered.")
        else:
            print("The expected paragraph was not found.")
    else:
        print("The first shape is not a text shape.")
finally:
    presentation.dispose()
```

The result:

![The paragraph image](paragraph_to_image_output.png)

#### **Bekezdés megjelenítése táblázatcellában skálázással**

Használja a [Paragraph.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/) túlterhelését, amely elfogadja a `scale_x` és `scale_y` paramétereket a vízszintes és függőleges skálafaktorok beállításához. Az alábbi példa egy táblázatot hoz létre, a bekezdést az első cellájában a szélesség és magasság kétszeresére skálázva megjeleníti, és a eredményt PNG képként menti.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

scale_x = 2.0
scale_y = 2.0
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    table = slide.getShapes().addTable(50, 50, [300.0], [80.0])

    paragraph = table.get_Item(0, 0).getTextFrame().getParagraphs().get_Item(0)
    paragraph.setText("Text in a table cell")

    paragraph_image = paragraph.getImage(scale_x, scale_y)

    if paragraph_image is not None:
        try:
            paragraph_image.save("table_paragraph.png", ImageFormat.Png)
        finally:
            paragraph_image.dispose()
    else:
        print("The paragraph could not be rendered.")
finally:
    presentation.dispose()
```

Az `1` skálafaktor az adott tengelyet az alapértelmezett pixelméretben tartja. Például a `2` mindkét faktor esetén egy olyan képet eredményez, amelynek szélessége és magassága körülbelül kétszerese az alapértelmezett méretnek, ez négyzetes pixel számot eredményez. A nagyobb faktorok általában élesebb szöveget adnak a nagyításhoz vagy a nagy felbontású kimenethez, de megnövelik a memóriahasználatot és a fájlméretet. Az `1` alatti faktorok kisebb képeket hoznak létre kevesebb részlettel. Azonos faktorok használata megőrzi a bekezdés képarányát; a különböző vízszintes és függőleges faktorok önállóan nyújtják a kimenetet.

Egy egész alakzat megjelenítése a [Shape.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getImage) segítségével továbbra is hasznos, ha a kimenetnek tartalmaznia kell az alakzat kitöltését, szegélyét vagy egyéb vizuális kontextusát. Egy csak bekezdéses képhez használja a [Paragraph.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/).

## **FAQ**

**Teljesen le lehet tiltani a sortörést egy szövegkereten belül?**

Igen. Állítsa a [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setWrapText) értékét a tördelés letiltására, így a sorok nem törnek meg a szövegkeret szélén.

**Hogyan kaphatom meg egy adott bekezdés pontos dián lévő határait?**

Használja a [Paragraph.getRect](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/#getRect) metódust a bekezdés körülhatároló téglalap lekéréséhez. A [Portion.getRect](https://reference.aspose.com/slides/python-java/aspose.slides/portion/#getRect) egyedi rész határait adja meg.

**Hol szabályozható a bekezdés igazítása (balra, jobbra, középre vagy sorkizárásra)?**

A [ParagraphFormat.setAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setAlignment) bekezdés-szintű beállítás, amely a teljes bekezdésre vonatkozik, függetlenül az egyedi rész formázásától.

A soron belül különböző betűméretű részek függőleges igazításához lásd a [Align Fonts Within a Line](/slides/hu/python-java/text-formatting/#align-fonts-within-a-line) cikket.

**Beállíthatom-e a helyesírási nyelvet a bekezdés egy részéhez?**

Igen. Állítsa be a [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setLanguageId) értékét az egyes részeknél, így egy bekezdés több nyelven is tartalmazhat szöveget.