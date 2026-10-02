---
title: PowerPoint szöveg bekezdések kezelése Pythonon keresztül Java segítségével
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
  - pontozás kezelése
  - bekezdés behúzása
  - függő behúzás
  - bekezdés bullet
  - számozott lista
  - pontozott lista
  - bekezdés tulajdonságok
  - HTML importálása
  - szöveg HTML-re
  - bekezdés HTML-re
  - bekezdés képre
  - szöveg képre
  - bekezdés exportálása
  - PowerPoint
  - prezentáció
  - Python
  - Java
  - Aspose.Slides
description: "Ismerje meg, hogyan hozhat létre és formázhat bekezdéseket, részeket, pontozásokat, számozott listákat, behúzásokat, HTML tartalmat és bekezdés képeket az Aspose.Slides for Python via Java segítségével."
---
## **Áttekintés**

Aspose.Slides for Python via Java a szöveget szövegkeretek, bekezdések és részek hierarchiájában reprezentálja:

* [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/) a szöveget tartalmazó tároló egy alakzatban, és hozzáférést biztosít a bekezdésgyűjteményéhez.
* [Paragraph](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/) egy bekezdést képvisel egy szövegkeretben, és hozzáférést biztosít a részeihez és a bekezdés-szintű formázáshoz.
* [Portion](https://reference.aspose.com/slides/python-java/aspose.slides/portion/) egy szövegrészt jelöl egy bekezdésen belül. Minden rész saját szöveggel és karakter-szintű formázással rendelkezhet.

Egy bekezdés ezért különböző betűtípusokkal, színekkel, méretekkel és egyéb formázásokkal is tartalmazhat szöveget, ha több részt használ.

## **Bekezdések létrehozása és formázása**

### **Bekezdések létrehozása több részzel**

Az alábbi lépések egy szövegkeretet hoznak létre három bekezdéssel, mindegyik három részt tartalmaz:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) osztályból.
2. A megfelelő diát az indexén keresztül érheti el.
3. Létrehozzon egy téglalap alakú [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) elemet a diára.
4. Érje el az alakzat [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/) elemét.
5. Használja az alapértelmezett bekezdést, és adjon hozzá további két [Paragraph](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/) objektumot a szövegkerethez.
6. Adjon elegendő [Portion](https://reference.aspose.com/slides/python-java/aspose.slides/portion/) objektumot minden bekezdéshez, hogy három részt tartalmazzon. Az alapértelmezett bekezdés már egy üres részt tartalmaz.
7. Állítsa be minden rész szövegét.
8. Alkalmazzon karakter szintű formázást a [Portion.getPortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/portion/#getPortionFormat) segítségével.
9. Mentse el a módosított prezentációt.

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

## **Pontozott és számozott listák létrehozása**

### **Pontozott vagy számozott lista létrehozása**

A pontok és a számozás megkönnyítik az elemek áttekintését. Az Aspose.Slides-ben a lista beállításait a [BulletFormat](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/) határozza meg.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) osztályból.
2. A megfelelő diát az indexén keresztül érheti el.
3. Adjon egy [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) elemet a kiválasztott diára.
4. Érje el az alakzat [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/) elemét.
5. Távolítsa el az alapértelmezett bekezdést a szövegkeretből.
6. Hozzon létre egy [Paragraph](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/) elemet egy szimbólum bullethez.
7. Állítsa a [BulletFormat.setType](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#setType) értékét [BulletType.Symbol](https://reference.aspose.com/slides/python-java/aspose.slides/bullettype/#Symbol) -ra, és adja meg a bullet karaktert.
8. Állítsa be a bekezdés szövegét, behúzását, a bullet színét és magasságát.
9. Adja hozzá a bekezdést a szövegkerethez.
10. Hozzon létre egy második bekezdést, és állítsa a [BulletFormat.setType](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#setType) értékét [BulletType.Numbered](https://reference.aspose.com/slides/python-java/aspose.slides/bullettype/#Numbered) -ra.
11. Konfigurálja a számozott bullet stílust, és adja hozzá a bekezdést a szövegkerethez.
12. Mentse el a prezentációt.

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

### **Képes bullet-ek használata**

Az képes bullet-ek lehetővé teszik egy egyéni kép használatát szimbólum vagy szám helyett.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) osztályból.
2. A megfelelő diát az indexén keresztül érheti el.
3. Adjon hozzá egy [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) elemet, és érje el annak [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/) elemét.
4. Távolítsa el az alapértelmezett bekezdést a szövegkeretből.
5. Töltse be a bullet képet, és adja hozzá a prezentáció képgyűjteményéhez [PPImage](https://reference.aspose.com/slides/python-java/aspose.slides/ppimage/)ként.
6. Hozzon létre egy [Paragraph](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/) elemet, és állítsa be a szövegét.
7. Állítsa a [BulletFormat.setType](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#setType) értékét [BulletType.Picture](https://reference.aspose.com/slides/python-java/aspose.slides/bullettype/#Picture) -ra.
8. Rendelje hozzá a képet a [BulletFormat.getPicture](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#getPicture) segítségével, és állítsa be a bullet magasságát.
9. Adja hozzá a bekezdést a szövegkerethez.
10. Mentse el a módosított prezentációt.

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

Állítsa be a [ParagraphFormat.setDepth](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setDepth) értékét, hogy a bekezdéseket a lista különböző szintjeire helyezze. A legfelső szint mélysége `0`.

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) példányt, és érje el egy diát.
2. Adjon hozzá egy [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) elemet, és törölje az alapértelmezett bekezdést a szövegkeretéből.
3. Négy bekezdést hoz létre, és konfigurálja azok bullet szimbólumait.
4. Állítsa be a [ParagraphFormat.setDepth](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setDepth) értékeket `0`, `1`, `2` és `3`-ra.
5. Adja hozzá a bekezdéseket a szövegkerethez, és mentse el a prezentációt.

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

### **Számozott listaelemek indítása egyéni értékekkel**

Használja a [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#setNumberedBulletStartWith) metódust, hogy beállítsa a számozott bekezdés kezdeti számát.

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) példányt, és adjon egy [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) elemet egy diára.
2. Törölje az alapértelmezett bekezdést az alakzat szövegkeretéből.
3. Hozzon létre három számozott bekezdést.
4. Állítsa be a [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#setNumberedBulletStartWith) értékét a megfelelő bekezdésekhez `2`, `3` és `7`-re.
5. Adja hozzá a bekezdéseket a szövegkerethez, és mentse el a prezentációt.

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

## **Bekezdések elrendezésének és végpontjainak vezérlése**

### **Első sor behúzásának beállítása**

Használja a [ParagraphFormat.setIndent](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setIndent) metódust a bekezdés első sorának behúzásának szabályozásához. Ez a metódus csak az első sort mozgatja a bekezdés bal margójához képest. A pozitív érték jobbra tolja az első sort, míg a többi sor a bekezdés törzséhez igazodik.

Használja a [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setMarginLeft) metódust, ha az egész bekezdést kell eltolni. Használja a [ParagraphFormat.setIndent](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setIndent) metódust, ha csak az első sort kell eltolni.

A következő példa több bekezdést hoz létre, és különböző [ParagraphFormat.setIndent](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setIndent) értékeket alkalmaz, hogy bemutassa, hogyan befolyásolja az első sor behúzása a bekezdés elrendezését.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) osztályból.
2. Cél diához férjen hozzá.
3. Adjon a diára egy téglalap alakú [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) elemet.
4. Érje el az alakzat [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/) elemét, és távolítsa el az alapértelmezett bekezdést.
5. Hozzon létre több bekezdést, és állítson be különböző [ParagraphFormat.setIndent](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setIndent) értékeket.
6. Adja hozzá a bekezdéseket a szövegkerethez.
7. Mentse el a módosított prezentációt.

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

Az eredmény:
![Az első sor behúzása a bekezdéseknél](first_line_indent.png)

### **Függő behúzás beállítása**

A függő behúzás olyan bekezdéselrendezés, ahol az első sor balra kezdődik a többi sorhoz képest. Az Aspose.Slides-ben ezt a hatást a [ParagraphFormat.setIndent](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setIndent) segítségével hozhatja létre. Negatív értéket adva az első sort balra mozdítja a bekezdés törzséhez képest.

Gyakorlatban a [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setMarginLeft) határozza meg a bekezdés törzsének bal pozícióját, a [ParagraphFormat.setIndent](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setIndent) pedig az első sor pozícióját ehhez a margóhoz képest. Függő behúzás létrehozásához adjon pozitív értéket a [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setMarginLeft)-nek, és negatív értéket a [ParagraphFormat.setIndent](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setIndent)-nek.

Ez a formázás hasznos bibliográfiákhoz, hivatkozásokhoz, szószedet-bejegyzésekhez és más bekezdésekhez, ahol a sortörés utáni soroknak a bekezdés törzsének alá kell igazodniuk, nem az első sor első karaktere alá.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) osztályból.
2. Cél diához férjen hozzá.
3. Adjon a diára egy téglalap alakú [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) elemet.
4. Érje el az alakzat [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/) elemét, és távolítsa el az alapértelmezett bekezdést.
5. Hozzon létre bekezdéseket, és minden bekezdéshez adjon pozitív értéket a [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setMarginLeft)-nek.
6. Adjon negatív értéket a [ParagraphFormat.setIndent](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setIndent)-nek a függő behúzás létrehozásához.
7. Adja hozzá a bekezdéseket a szövegkerethez.
8. Mentse el a módosított prezentációt.

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

Az eredmény:
![A bekezdések függő behúzása](hanging_indent.png)

### **A bekezdés befejező részének tulajdonságainak beállítása**

[Paragraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/#setEndParagraphPortionFormat) szabályozza a bekezdés befejező jel formázását. A következő példa betűméretet és latin betűtípust rendel a második bekezdés befejező jeléhez:

1. Töltsön be egy [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) példányt, és érje el egy diát.
2. Adjon hozzá egy [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) elemet, és törölje az alapértelmezett bekezdését.
3. Hozzon létre két bekezdést, és adjon hozzá szövegrészeket.
4. Hozzon létre egy [PortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/portionformat/) objektumot a második bekezdés befejező jeléhez.
5. Állítsa be a [BasePortionFormat.setFontHeight](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setFontHeight) és a [BasePortionFormat.setLatinFont](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setLatinFont) értékeket.
6. Rendelje hozzá a formátumot a [Paragraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/#setEndParagraphPortionFormat) segítségével, és mentse el a prezentációt.

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

Az automatikus sortörést és a sorvégeken lévő központozást érintő bekezdés szabályokért lásd a [Vonalak törésének vezérlése](/slides/hu/python-java/text-formatting/#control-line-breaking) és a [Függő központozás vezérlése](/slides/hu/python-java/text-formatting/#control-hanging-punctuation).

Használja a [Paragraph.getLinesCount](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/#getLinesCount) metódust a bekezdés által elfoglalt sorok számolásához a szöveg elrendezése után, beleértve az automatikus sortörést. Ez hasznos a szöveg hossza és az elrendezés ellenőrzésekor prezentációs sablonokban.

A bekezdés egy elem a [TextFrame.getParagraphs](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/#getParagraphs) gyűjteményben, és több megjelenített sort is elfoglalhat. A bekezdésen belüli explicit sortörés új sort hoz létre anélkül, hogy újabb bekezdést hozna létre. Az automatikus sortörés a rendelkezésre álló szélesség alapján hoz létre sorokat anélkül, hogy explicit sortöréseket szúrna be a szövegbe. A bekezdések vagy sortörés karakterek számlálása ezért nem adja meg a megjelenített sorok számát.

Az alábbi példa létrehoz egy szöveges alakzatot, megszámolja a sorait, szűkíti az alakzatot, majd helyettesíti a szöveget egy rövidebb karakterlánccal. A sortörés engedélyezve van és az automatikus illeszkedés le van tiltva, így az alakzat szélessége szabályozza a sortörést anélkül, hogy a szöveget automatikusan lekicsinyítené vagy az alakzatot átméretezné. Az alakzat méretei pontban vannak megadva. Végül a példa egy újabb bekezdést ad hozzá és összeadja a sorok számát a szövegkeretben.

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

Ebben a szövegben és ezen méretek mellett a forma szűkítése növeli a sorok számát, míg a rövid szövegre cserélés csökkenti azt. A pontos számok eltérhetnek a betűtípusok elérhetőségétől és helyettesítésétől, a betűmérettől, margóktól, behúzásoktól, sortöréstől és az automatikus illeszkedés beállításaitól. Használja azokat a betűtípusokat és elrendezési beállításokat, amelyek a célkörnyezethez vannak tervezve sablon ellenőrzésekor.

A sorok száma önmagában nem határozza meg, hogy a szöveg túllépi-e a konténert. A rendelkezésre álló magasság, sor magasságok, bekezdés- és sorközök, valamint az automatikus illeszkedés viselkedése is számít; még egyetlen sor is meghaladhatja a rendelkezésre álló szélességet, ha a sortörés le van tiltva.

## **Bekezdés tartalmának importálása és exportálása**

### **HTML szöveg importálása bekezdésekbe**

Használja a [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphcollection/#addFromHtml) metódust, hogy HTML jelölőnyelvet konvertáljon bekezdésekké és részekké egy szövegkeretben.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) osztályból.
2. Érje el a diát, és adjon hozzá egy [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) elemet.
3. Érje el az alakzat [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/) elemét, és törölje az alapértelmezett bekezdést.
4. Olvassa be a forrás HTML fájlt.
5. Adja át a HTML karakterláncot a [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphcollection/#addFromHtml) metódusnak.
6. Mentse el a módosított prezentációt.

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

### **Bekezdés szöveg exportálása HTML-be**

Használja a [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphcollection/#exportToHtml) metódust, hogy a kijelölt bekezdésszegletet HTML-ként exportálja.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) osztályból, és töltse be a kívánt prezentációt.
2. Érje el a diát, és keresse meg a szöveget tartalmazó [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) elemet.
3. Érje el az alakzat [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/) elemét.
4. Hívja meg a [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphcollection/#exportToHtml) metódust a kezdő bekezdés indexével és az exportálandó bekezdések számával.
5. Írja a visszakapott HTML karakterláncot egy fájlba.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Presentation
from pathlib import Path

presentation = Presentation("ExportingHTMLText.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    if isinstance(shape, AutoShape):
        text_shape = shape
        text_frame = text_shape.getTextFrame()
        if text_frame is not None:
            paragraphs = text_frame.getParagraphs()
            html = paragraphs.exportToHtml(0, paragraphs.getCount(), None)
            try:
                Path("paragraphs.html").write_text(str(html), encoding="utf-8")
            except OSError as exception:
                print("The HTML file could not be written: " + str(exception))
        else:
            print("The first shape does not contain a text frame.")
    else:
        print("The first shape is not a text shape.")
finally:
    presentation.dispose()
```

### **Bekezdés renderelése képként**

[Paragraph.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/) közvetlenül rendereli egy adott bekezdést, és képtárgyat ad vissza. Mentse az eredményt fájlba vagy áramlásba a `save` metódusával. Nem kell a tartalmazó alakzatot renderelni vagy bitmapet manuálisan vágni.

[Paragraph.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/) `None` értéket adhat vissza, ha a bekezdés nem található a szülő gyűjteményben, nincs érvényes renderelési határa, vagy nem renderelhető. Ellenőrizze az eredményt a mentés előtt, és használat után szabadítsa fel a visszakapott képet.

#### **Bekezdés renderelése alapértelmezett mérettel**

Tegyük fel, hogy van egy sample.pptx nevű prezentációs fájlunk, amely egy diát tartalmaz, ahol az első alakzat egy szövegdoboz három bekezdéssel.

![A három bekezdést tartalmazó szövegdoboz](paragraph_to_image_input.png)

A következő példa a második bekezdést egy normál szöveges alakzatban rendereli alapértelmezett mérettel, és a visszakapott képet PNG formátumban menti. A `finally` blokk biztosítja, hogy a kép megfelelően felszabaduljon.

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

Az eredmény:
![A bekezdés képe](paragraph_to_image_output.png)

#### **Bekezdés renderelése táblázatcella méretezéssel**

Használja a [Paragraph.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/) túlterhelést, amely a `scale_x` és `scale_y` paramétereket fogadja, a vízszintes és függőleges méretezési tényezők beállításához. A következő példa egy táblázatot hoz létre, a bekezdést az első cellájában kétszeres szélességre és magasságra rendereli, és az eredményt PNG képként menti.

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

Az 1-es méretezési tényező megtartja az adott tengely alapértelmezett pixeles méretét. Például a 2-es mindkét tényező esetén a kép szélessége és magassága megközelítőleg duplája az alapértelmezett méreteknek, így a pixelek száma négyszeres. A nagyobb tényezők általában élesebb szöveget eredményeznek nagyításhoz vagy nagy felbontású kimenethez, de növelik a memóriahasználatot és a fájlméretet. Az 1 alatti tényezők kisebb képeket hoznak kevesebb részlettel. Használjon egyenlő tényezőket a bekezdés arányainak megtartásához; a különböző vízszintes és függőleges tényezők önállóan nyújtják a kimenetet.

A teljes alakzat renderelése a [Shape.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getImage) segítségével továbbra is hasznos, ha a kimenetnek tartalmaznia kell az alakzat kitöltését, szegélyét vagy egyéb vizuális kontextusát. Egy csak bekezdés-képre, használja a [Paragraph.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/) metódust.

## **GYIK**

**Letiltom teljesen a sortörést egy szövegkereten belül?**  
Igen. Állítsa a [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setWrapText) értékét a sortörés letiltásához, így a sorok nem törnek meg a szövegkeret szélén.

**Hogyan kaphatok pontos dián lévő határokat egy adott bekezdéshez?**  
Használja a [Paragraph.getRect](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/#getRect) metódust a bekezdés körülhatároló téglalapjának lekéréséhez. A [Portion.getRect](https://reference.aspose.com/slides/python-java/aspose.slides/portion/#getRect) egy egyedi rész határait adja.

**Hol van szabályozva a bekezdés igazítása (balra, jobbra, középre vagy sorkizáró)?**  
A [ParagraphFormat.setAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setAlignment) bekezdés szintű beállítás, amely az egész bekezdésre vonatkozik, függetlenül az egyes részformázásoktól. Az egy soron belül különböző betűméretű részek függőleges igazításához lásd a [Betűk soron belüli függőleges igazítása](/slides/hu/python-java/text-formatting/#align-fonts-within-a-line).

**Beállíthatom a helyesírási nyelvet egy bekezdés egy részére?**  
Igen. Állítsa be a [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setLanguageId) értékét egyes részekhez, így egy bekezdés több nyelven is tartalmazhat szöveget.