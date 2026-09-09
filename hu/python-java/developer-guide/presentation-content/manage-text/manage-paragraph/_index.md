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
  - pont kezelése
  - bekezdésbehúzás
  - függő behúzás
  - bekezdés pont
  - számozott lista
  - pontozott lista
  - bekezdés tulajdonságai
  - HTML importálása
  - szöveg HTML-é
  - bekezdés HTML-é
  - bekezdés képpé
  - szöveg képpé
  - bekezdés exportálása
  - PowerPoint
  - bemutató
  - Python
  - Java
  - Aspose.Slides
description: "Ismerje meg, hogyan hozhat létre és formázhat bekezdéseket, részeket, pontokat, számozott listákat, behúzásokat, HTML tartalmat és bekezdési képeket az Aspose.Slides for Python via Java segítségével."
---
## **Áttekintés**

Aspose.Slides for Python via Java a szöveget szövegkeretek, bekezdések és részek (Portion) hierarchiájában ábrázolja:

* [TextFrame](https://reference.aspose.com/slides/hu/python-java/aspose.slides/textframe/) a szövegtároló egy alakzatban, és hozzáférést biztosít a bekezdésgyűjteményéhez.
* [Paragraph](https://reference.aspose.com/slides/hu/python-java/aspose.slides/paragraph/) egy bekezdést képvisel egy szövegkeretben, és hozzáférést biztosít a részeihez és a bekezdés szintű formázáshoz.
* [Portion](https://reference.aspose.com/slides/hu/python-java/aspose.slides/portion/) egy szövegtöredéket (run) képvisel egy bekezdésen belül. Minden résznek saját szövege és karakter szintű formázása lehet.

Egy bekezdés tehát több rész használatával különböző betűtípusú, színű, méretű és egyéb formázású szöveget tartalmazhat.

## **Bekezdések létrehozása és formázása**

### **Bekezdések létrehozása több részekkel**

A következő lépések egy szövegkeretet hoznak létre három bekezdéssel, mindegyik három részt tartalmazva:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) osztályból.
2. Érje el a megfelelő diát indexe alapján.
3. Adjon egy téglalap alakú [AutoShape](https://reference.aspose.com/slides/hu/python-java/aspose.slides/autoshape/) elemet a diára.
4. Érje el a forma [TextFrame](https://reference.aspose.com/slides/hu/python-java/aspose.slides/textframe/) tulajdonságát.
5. Használja az alapértelmezett bekezdést, és adjon hozzá két további [Paragraph](https://reference.aspose.com/slides/hu/python-java/aspose.slides/paragraph/) objektumot a szövegkerethez.
6. Adjon elegendő [Portion](https://reference.aspose.com/slides/hu/python-java/aspose.slides/portion/) objektumot minden bekezdéshez, hogy három részt tartalmazzanak. Az alap bekezdés már egy üres részt tartalmaz.
7. Állítsa be minden rész szövegét.
8. Alkalmazzon karakter szintű formázást a [Portion.getPortionFormat](https://reference.aspose.com/slides/hu/python-java/aspose.slides/portion/#getPortionFormat) segítségével.
9. Mentse el a módosított bemutatót.

Ez a Python példa megvalósítja a lépéseket:

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

## **Felsorolás és számozott lista létrehozása**

### **Felsorolás vagy számozott lista létrehozása**

A pontok és a számozás megkönnyítik a kapcsolódó elemek átláthatóságát. Az Aspose.Slides-ben a lista beállításait a [BulletFormat](https://reference.aspose.com/slides/hu/python-java/aspose.slides/bulletformat/) határozza meg.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) osztályból.
2. Érje el a megfelelő diát indexe alapján.
3. Adjon egy [AutoShape](https://reference.aspose.com/slides/hu/python-java/aspose.slides/autoshape/) elemet a kiválasztott diára.
4. Érje el a forma [TextFrame](https://reference.aspose.com/slides/hu/python-java/aspose.slides/textframe/) tulajdonságát.
5. Távolítsa el az alap bekezdést a szövegkeretből.
6. Hozzon létre egy [Paragraph](https://reference.aspose.com/slides/hu/python-java/aspose.slides/paragraph/) objektumot egy szimbólum pont számára.
7. Állítsa a [BulletFormat.setType](https://reference.aspose.com/slides/hu/python-java/aspose.slides/bulletformat/#setType) értékét [BulletType.Symbol](https://reference.aspose.com/slides/hu/python-java/aspose.slides/bullettype/#Symbol)‑re, és adja meg a pont karakterét.
8. Állítsa be a bekezdés szövegét, behúzását, pont színét és magasságát.
9. Adja hozzá a bekezdést a szövegkerethez.
10. Hozzon létre egy második bekezdést, és állítsa a [BulletFormat.setType](https://reference.aspose.com/slides/hu/python-java/aspose.slides/bulletformat/#setType) értékét [BulletType.Numbered](https://reference.aspose.com/slides/hu/python-java/aspose.slides/bullettype/#Numbered)‑re.
11. Konfigurálja a számozott pont stílusát, és adja hozzá a bekezdést a szövegkerethez.
12. Mentse el a bemutatót.

Ez a Python példa szimbólum pontot és számozott pontot hoz létre:

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

### **Képpontok használata**

A képpontok lehetővé teszik egyéni kép használatát szimbólum vagy szám helyett.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) osztályból.
2. Érje el a megfelelő diát indexe alapján.
3. Adjon egy [AutoShape](https://reference.aspose.com/slides/hu/python-java/aspose.slides/autoshape/) elemet, és érje el annak [TextFrame](https://reference.aspose.com/slides/hu/python-java/aspose.slides/textframe/) tulajdonságát.
4. Távolítsa el az alap bekezdést a szövegkeretből.
5. Töltse be a pont képet, és adja hozzá a bemutató képgyűjteményéhez [PPImage](https://reference.aspose.com/slides/hu/python-java/aspose.slides/ppimage/)‑ként.
6. Hozzon létre egy [Paragraph](https://reference.aspose.com/slides/hu/python-java/aspose.slides/paragraph/) objektumot, és állítsa be a szövegét.
7. Állítsa a [BulletFormat.setType](https://reference.aspose.com/slides/hu/python-java/aspose.slides/bulletformat/#setType) értékét [BulletType.Picture](https://reference.aspose.com/slides/hu/python-java/aspose.slides/bullettype/#Picture)‑re.
8. Rendelje hozzá a képet a [BulletFormat.getPicture](https://reference.aspose.com/slides/hu/python-java/aspose.slides/bulletformat/#getPicture) segítségével, és állítsa be a pont magasságát.
9. Adja hozzá a bekezdést a szövegkerethez.
10. Mentse el a módosított bemutatót.

Ez a Python példa képpontot hoz létre:

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

A [ParagraphFormat.setDepth](https://reference.aspose.com/slides/hu/python-java/aspose.slides/paragraphformat/#setDepth) beállításával helyezhetünk bekezdéseket egy lista különböző szintjeire. A legfelső szint mélysége `0`.

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) objektumot, és érje el egy diát.
2. Adjon egy [AutoShape](https://reference.aspose.com/slides/hu/python-java/aspose.slides/autoshape/) elemet, és ürítse ki az alap bekezdést a szövegkeretből.
3. Hozzon létre négy bekezdést, és konfigurálja azok pont szimbólumait.
4. Állítsa be a [ParagraphFormat.setDepth](https://reference.aspose.com/slides/hu/python-java/aspose.slides/paragraphformat/#setDepth) értékeket `0`, `1`, `2` és `3`‑ra.
5. Adja hozzá a bekezdéseket a szövegkerethez, és mentse el a bemutatót.

Ez a Python példa négyszintű felsorolást hoz létre:

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

### **Számozott listaelemek egyedi kezdőértékkel**

A [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/hu/python-java/aspose.slides/bulletformat/#setNumberedBulletStartWith) segítségével állítható be a számozott bekezdés kezdeti száma.

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) objektumot, és adjon egy [AutoShape](https://reference.aspose.com/slides/hu/python-java/aspose.slides/autoshape/) elemet egy diára.
2. Távolítsa el az alap bekezdést a forma szövegkeretéből.
3. Hozzon létre három számozott bekezdést.
4. Állítsa be a [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/hu/python-java/aspose.slides/bulletformat/#setNumberedBulletStartWith) értékét `2`, `3` és `7`‑re a megfelelő bekezdésekhez.
5. Adja hozzá a bekezdéseket a szövegkerethez, és mentse el a bemutatót.

Ez a Python példa egyedi kezdőszámot rendel minden bekezdéshez:

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

## **Bekezdéselrendezés és végpont tulajdonságok vezérlése**

### **Első sor behúzásának beállítása**

A [ParagraphFormat.setIndent](https://reference.aspose.com/slides/hu/python-java/aspose.slides/paragraphformat/#setIndent) segítségével szabályozható egy bekezdés első sorának behúzása. Ez a módszer csak az első sort helyezi el a bekezdés bal margójához képest. Pozitív érték a első sort jobbra tolja, míg a többi sor a bekezdés törzséhez igazodik.

Használja a [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/hu/python-java/aspose.slides/paragraphformat/#setMarginLeft)‑t, ha az egész bekezdést szeretné elmozgatni. A [ParagraphFormat.setIndent](https://reference.aspose.com/slides/hu/python-java/aspose.slides/paragraphformat/#setIndent) csak az első sor eltolására szolgál.

Az alábbi példa több bekezdést hoz létre, és különböző [ParagraphFormat.setIndent](https://reference.aspose.com/slides/hu/python-java/aspose.slides/paragraphformat/#setIndent) értékeket alkalmaz, hogy bemutassa, a első sor behúzása hogyan befolyásolja a bekezdés elrendezését.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) osztályból.
2. Érje el a cél diát.
3. Adjon egy téglalap alakú [AutoShape](https://reference.aspose.com/slides/hu/python-java/aspose.slides/autoshape/) elemet a diára.
4. Érje el a forma [TextFrame](https://reference.aspose.com/slides/hu/python-java/aspose.slides/textframe/) tulajdonságát, és távolítsa el az alap bekezdést.
5. Hozzon létre több bekezdést, és állítson be különböző [ParagraphFormat.setIndent](https://reference.aspose.com/slides/hu/python-java/aspose.slides/paragraphformat/#setIndent) értékeket.
6. Adja hozzá a bekezdéseket a szövegkerethez.
7. Mentse el a módosított bemutatót.

Ez a kód megmutatja, hogyan állítható be egy bekezdés behúzása:

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
    second_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    second_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    second_paragraph.getParagraphFormat().setMarginLeft(20.0)
    second_paragraph.getParagraphFormat().setIndent(20.0)
    third_paragraph = Paragraph()
    third_paragraph.setText("First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.")
    third_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
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

![A bekezdések első sorának behúzása](first_line_indent.png)

### **Függő behúzás beállítása**

A függő behúzás olyan bekezdéselrendezés, ahol az első sor balra indul a többi sorhoz képest. Az Aspose.Slides‑ben ezt a hatást a [ParagraphFormat.setIndent](https://reference.aspose.com/slides/hu/python-java/aspose.slides/paragraphformat/#setIndent) segítségével hozhatja létre. Negatív érték átmozgatja az első sort balra a bekezdés törzséhez képest.

Gyakorlatban a [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/hu/python-java/aspose.slides/paragraphformat/#setMarginLeft) határozza meg a bekezdés törzsének bal pozícióját, a [ParagraphFormat.setIndent](https://reference.aspose.com/slides/hu/python-java/aspose.slides/paragraphformat/#setIndent) pedig az első sor helyzetét ehhez a margóhoz képest. Függő behúzás létrehozásához adjon pozitív értéket a [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/hu/python-java/aspose.slides/paragraphformat/#setMarginLeft)‑nek, és negatív értéket a [ParagraphFormat.setIndent](https://reference.aspose.com/slides/hu/python-java/aspose.slides/paragraphformat/#setIndent)‑nek.

Ez a formázás hasznos bibliográfiák, hivatkozások, szószedetek és egyéb bekezdések esetén, ahol a sortöréseknek a bekezdés törzsének alá kell illeszkedniük, nem pedig az első sor első karakteréhez.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) osztályból.
2. Érje el a cél diát.
3. Adjon egy téglalap alakú [AutoShape](https://reference.aspose.com/slides/hu/python-java/aspose.slides/autoshape/) elemet a diára.
4. Érje el a forma [TextFrame](https://reference.aspose.com/slides/hu/python-java/aspose.slides/textframe/) tulajdonságát, és távolítsa el az alap bekezdést.
5. Hozzon létre bekezdéseket, és adjon pozitív értéket a [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/hu/python-java/aspose.slides/paragraphformat/#setMarginLeft) számára minden bekezdéshez.
6. Adjon negatív értéket a [ParagraphFormat.setIndent](https://reference.aspose.com/slides/hu/python-java/aspose.slides/paragraphformat/#setIndent) számára a függő behúzás eléréséhez.
7. Adja hozzá a bekezdéseket a szövegkerethez.
8. Mentse el a módosított bemutatót.

Ez a kód megmutatja, hogyan állítható be egy bekezdés függő behúzása:

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

### **Bekezdés végpont formátumának beállítása**

A [Paragraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/hu/python-java/aspose.slides/paragraph/#setEndParagraphPortionFormat) szabályozza a bekezdés végjelezésének formázását. Az alábbi példa betűméretet és latin betűtípust állít be a második bekezdés végjelezésére:

1. Töltsön be egy [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) fájlt, és érje el egy diát.
2. Adjon egy [AutoShape](https://reference.aspose.com/slides/hu/python-java/aspose.slides/autoshape/) elemet, és távolítsa el az alap bekezdést.
3. Hozzon létre két bekezdést, és adjon szövegrétegeket hozzájuk.
4. Hozzon létre egy [PortionFormat](https://reference.aspose.com/slides/hu/python-java/aspose.slides/portionformat/) objektumot a második bekezdés végjelezéséhez.
5. Állítsa be a [BasePortionFormat.setFontHeight](https://reference.aspose.com/slides/hu/python-java/aspose.slides/baseportionformat/#setFontHeight) és a [BasePortionFormat.setLatinFont](https://reference.aspose.com/slides/hu/python-java/aspose.slides/baseportionformat/#setLatinFont) értékeket.
6. Rendelje hozzá a formátumot a [Paragraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/hu/python-java/aspose.slides/paragraph/#setEndParagraphPortionFormat) segítségével, és mentse el a bemutatót.

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

## **Bekezdés tartalmának importálása és exportálása**

### **HTML szöveg importálása bekezdésekbe**

A [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/hu/python-java/aspose.slides/paragraphcollection/#addFromHtml) használatával HTML jelölést alakíthat bekezdésekké és részekké egy szövegkeretben.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) osztályból.
2. Érje el egy diát, és adjon egy [AutoShape](https://reference.aspose.com/slides/hu/python-java/aspose.slides/autoshape/) elemet.
3. Érje el a forma [TextFrame](https://reference.aspose.com/slides/hu/python-java/aspose.slides/textframe/) tulajdonságát, és távolítsa el az alap bekezdést.
4. Olvassa be a forrás HTML fájlt.
5. Adja át a HTML karakterláncot a [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/hu/python-java/aspose.slides/paragraphcollection/#addFromHtml) metódusnak.
6. Mentse el a módosított bemutatót.

Ez a Python példa HTML-t importál egy szövegkeretbe:

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

A [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/hu/python-java/aspose.slides/paragraphcollection/#exportToHtml) segítségével egy kiválasztott bekezdéstarományt exportálhat HTML formátumban.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) osztályból, és töltse be a kívánt bemutatót.
2. Érje el a diát, és keresse meg a szöveget tartalmazó [AutoShape](https://reference.aspose.com/slides/hu/python-java/aspose.slides/autoshape/) elemet.
3. Érje el a forma [TextFrame](https://reference.aspose.com/slides/hu/python-java/aspose.slides/textframe/) tulajdonságát.
4. Hívja meg a [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/hu/python-java/aspose.slides/paragraphcollection/#exportToHtml) metódust a kezdő bekezdés indexével és a exportálandó bekezdések számával.
5. Írja a visszakapott HTML karakterláncot egy fájlba.

Ez a Python példa az első szövegforma összes bekezdését exportálja:

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

A [Paragraph.getImage](https://reference.aspose.com/slides/hu/python-java/aspose.slides/paragraph/) közvetlenül renderel egy egyedi bekezdést, és képobjektust ad vissza. A visszakapott képet a `save` metódussal mentheti fájlba vagy streambe. Nem szükséges a tartalmazó alakzatot renderelni vagy a bitmapet manuálisan vágni.

A [Paragraph.getImage](https://reference.aspose.com/slides/hu/python-java/aspose.slides/paragraph/) `None`‑t adhat vissza, ha a bekezdés nem található a szülőgyűjteményben, nincs érvényes renderelési határa, vagy nem renderelhető. Ellenőrizze az eredményt mentés előtt, és a használat után szabadítsa fel a visszakapott képet.

#### **Bekezdés renderelése az alapméretezésben**

Tegyük fel, hogy van egy sample.pptx nevű bemutatófájl egy diával, ahol az első alakzat egy három bekezdést tartalmazó szövegdoboz.

![A szövegdoboz három bekezdéssel](paragraph_to_image_input.png)

Az alábbi példa a második bekezdést rendereli egy szabványos szövegalakzatban alapméretezésben, és PNG formátumban menti a visszakapott képet. A `finally` blokk biztosítja a kép helyes felszabadítását.

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

#### **Bekezdés renderelése táblázatcellában méretezéssel**

Használja a [Paragraph.getImage](https://reference.aspose.com/slides/hu/python-java/aspose.slides/paragraph/) túlterhelést, amely `scale_x` és `scale_y` paramétereket fogad a vízszintes és függőleges méretező tényezők beállításához. Az alábbi példa egy táblázatot hoz létre, és az első cellájában lévő bekezdést kétszeres szélesség és magasság mellett rendereli, majd PNG képként menti.

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

Az `1` tényező megtartja az adott tengelyt alap pixelméretben. Például a `2` mindkét tényezőnél olyan képet eredményez, amelynek szélessége és magassága megközelítőleg kétszerese az alapméretnek, ezáltal négyszer annyi pixel keletkezik. A nagyobb tényezők általában élesebb szöveget eredményeznek nagyítás vagy nagy felbontású kimenet esetén, de nő a memóriaigény és a fájlméret is. Az `1`‑nél kisebb tényezők kisebb, kevésbé részletes képeket adnak. Az azonos tényezők megőrzik a bekezdés képarányát; a különböző vízszintes és függőleges tényezők önállóan nyújtják a kimenetet.

Egy teljes alakzat renderelése a [Shape.getImage](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shape/#getImage) segítségével akkor hasznos, ha a kimenetnek tartalmaznia kell az alakzat kitöltését, szegélyét vagy egyéb vizuális kontextusát. Csak bekezdésképhez használja a [Paragraph.getImage](https://reference.aspose.com/slides/hu/python-java/aspose.slides/paragraph/)‑t.

## **GYIK**

**Teljesen letilthatom a sortörést egy szövegkereten belül?**

Igen. Állítsa a [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/hu/python-java/aspose.slides/textframeformat/#setWrapText) értékét a törléshez, hogy a sorok ne törjenek meg a szövegkeret szélén.

**Hogyan kaphatom meg egy adott bekezdés pontos diákon lévő határait?**

Használja a [Paragraph.getRect](https://reference.aspose.com/slides/hu/python-java/aspose.slides/paragraph/#getRect) metódust a bekezdés körülhatároló téglalap lekéréséhez. A [Portion.getRect](https://reference.aspose.com/slides/hu/python-java/aspose.slides/portion/#getRect) egyedi rész határait adja vissza.

**Hol van a bekezdés igazítás (balra, jobbra, középre vagy sorkizárt) szabályozva?**

A [ParagraphFormat.setAlignment](https://reference.aspose.com/slides/hu/python-java/aspose.slides/paragraphformat/#setAlignment) egy bekezdés-szintű beállítás, amely a teljes bekezdésre vonatkozik, függetlenül az egyedi részek formázásától.

**Beállíthatom a nyelvhelyességi nyelvet a bekezdés egy részére?**

Igen. Állítsa a [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/hu/python-java/aspose.slides/baseportionformat/#setLanguageId) értékét egyedi részeknél, így egy bekezdés több nyelven is tartalmazhat szöveget.