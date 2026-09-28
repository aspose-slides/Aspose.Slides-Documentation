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
- felsorolásjel kezelése
- bekezdés behúzása
- akasztott behúzás
- bekezdés felsorolásjele
- számozott lista
- felsorolási lista
- bekezdés tulajdonságai
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
description: "Ismerje meg, hogyan hozhat létre és formázhat bekezdéseket, részeket, felsorolásjeleket, számozott listákat, behúzásokat, HTML-tartalmakat és bekezdésképeket az Aspose.Slides for Python via Java segítségével."
---
## **Áttekintés**

Az Aspose.Slides for Python via Java a szöveget szövegdobozok, bekezdések és részek hierarchiájaként ábrázolja:

* [TextFrame](https://reference.aspose.com/slides/hu/python-java/aspose.slides/textframe/) egy alakzat szövegtárolója, és hozzáférést biztosít a bekezdésgyűjteményéhez.
* [Paragraph](https://reference.aspose.com/slides/hu/python-java/aspose.slides/paragraph/) egy bekezdést képvisel egy szövegdobozban, és hozzáférést ad a részeihez és a bekezdés szintű formázáshoz.
* [Portion](https://reference.aspose.com/slides/hu/python-java/aspose.slides/portion/) egy szövegrészt jelöl egy bekezdésen belül. Minden rész saját szöveggel és karakter szintű formázással rendelkezhet.

Egy bekezdés ezért több rész használatával tartalmazhat különböző betűtípusú, színű, méretű és egyéb formázású szöveget.

## **Létrehozás és formázás bekezdések**

### **Létrehozás több részt tartalmazó bekezdésekkel**

A következő lépések egy szövegdobozt hoznak létre három bekezdéssel, mindegyik három részt tartalmazva:

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) példányt.
2. Érje el a megfelelő diát az indexe alapján.
3. Adjon hozzá egy téglalap alakú [AutoShape](https://reference.aspose.com/slides/hu/python-java/aspose.slides/autoshape/) elemet a diához.
4. Érje el az alakzat [TextFrame](https://reference.aspose.com/slides/hu/python-java/aspose.slides/textframe/) elemét.
5. Használja az alapértelmezett bekezdést, és adjon hozzá további két [Paragraph](https://reference.aspose.com/slides/hu/python-java/aspose.slides/paragraph/) objektumot a szövegdobozhoz.
6. Adjon elegendő [Portion](https://reference.aspose.com/slides/hu/python-java/aspose.slides/portion/) objektumot ahhoz, hogy minden bekezdés három részt tartalmazzon. Az alapértelmezett bekezdés már egy üres részt tartalmaz.
7. Állítsa be minden rész szövegét.
8. Alkalmazzon karakter szintű formázást a [Portion.getPortionFormat](https://reference.aspose.com/slides/hu/python-java/aspose.slides/portion/#getPortionFormat) segítségével.
9. Mentse a módosított prezentációt.

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

### **Felsorolási vagy számozott lista létrehozása**

A felsorolások és a számozás segítik a kapcsolódó elemek gyorsabb átlátását. Az Aspose.Slides listabeállításait a [BulletFormat](https://reference.aspose.com/slides/hu/python-java/aspose.slides/bulletformat/) definiálja.

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) példányt.
2. Érje el a megfelelő diát az indexe alapján.
3. Adjon hozzá egy [AutoShape](https://reference.aspose.com/slides/hu/python-java/aspose.slides/autoshape/) elemet a kiválasztott diához.
4. Érje el az alakzat [TextFrame](https://reference.aspose.com/slides/hu/python-java/aspose.slides/textframe/) elemét.
5. Távolítsa el az alapértelmezett bekezdést a szövegdobozból.
6. Hozzon létre egy [Paragraph](https://reference.aspose.com/slides/hu/python-java/aspose.slides/paragraph/) elemet egy szimbólum jelöléshez.
7. Állítsa a [BulletFormat.setType](https://reference.aspose.com/slides/hu/python-java/aspose.slides/bulletformat/#setType) értékét a [BulletType.Symbol](https://reference.aspose.com/slides/hu/python-java/aspose.slides/bullettype/#Symbol) típusra, és adja meg a jel karakterét.
8. Állítsa be a bekezdés szövegét, behúzását, a jel színét és magasságát.
9. Adja hozzá a bekezdést a szövegdobozhoz.
10. Hozzon létre egy második bekezdést, és állítsa a [BulletFormat.setType](https://reference.aspose.com/slides/hu/python-java/aspose.slides/bulletformat/#setType) értékét a [BulletType.Numbered](https://reference.aspose.com/slides/hu/python-java/aspose.slides/bullettype/#Numbered) típusra.
11. Konfigurálja a számozott jel stílusát, majd adja hozzá a bekezdést a szövegdobozhoz.
12. Mentse a prezentációt.

Ez a Python példa egy szimbólum jelölést és egy számozott jelölést hoz létre:

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

### **Képes felsorolásjel használata**

A képes felsorolásjelek lehetővé teszik egy egyedi kép használatát a szimbólum vagy szám helyett.

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) példányt.
2. Érje el a megfelelő diát az indexe alapján.
3. Adjon hozzá egy [AutoShape](https://reference.aspose.com/slides/hu/python-java/aspose.slides/autoshape/) elemet, és érje el annak [TextFrame](https://reference.aspose.com/slides/hu/python-java/aspose.slides/textframe/) elemét.
4. Távolítsa el az alapértelmezett bekezdést a szövegdobozból.
5. Töltse be a jelképképet, és adja hozzá a prezentáció képgyűjteményéhez [PPImage](https://reference.aspose.com/slides/hu/python-java/aspose.slides/ppimage/)ként.
6. Hozzon létre egy [Paragraph](https://reference.aspose.com/slides/hu/python-java/aspose.slides/paragraph/) elemet, és állítsa be a szövegét.
7. Állítsa a [BulletFormat.setType](https://reference.aspose.com/slides/hu/python-java/aspose.slides/bulletformat/#setType) értékét a [BulletType.Picture](https://reference.aspose.com/slides/hu/python-java/aspose.slides/bullettype/#Picture) típusra.
8. Rendelje hozzá a képet a [BulletFormat.getPicture](https://reference.aspose.com/slides/hu/python-java/aspose.slides/bulletformat/#getPicture) segítségével, és állítsa be a jel magasságát.
9. Adja hozzá a bekezdést a szövegdobozhoz.
10. Mentse a módosított prezentációt.

Ez a Python példa egy képes felsorolásjelet hoz létre:

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

Állítsa be a [ParagraphFormat.setDepth](https://reference.aspose.com/slides/hu/python-java/aspose.slides/paragraphformat/#setDepth) értékét, hogy a bekezdéseket a lista különböző szintjeire helyezze. A legfelső szint mélysége `0`.

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) példányt, és érje el egy diát.
2. Adjon hozzá egy [AutoShape](https://reference.aspose.com/slides/hu/python-java/aspose.slides/autoshape/) elemet, és törölje az alapértelmezett bekezdést a szövegdobozából.
3. Hozzon létre négy bekezdést, és konfigurálja azok felsorolásjeleit.
4. Állítsa be a [ParagraphFormat.setDepth](https://reference.aspose.com/slides/hu/python-java/aspose.slides/paragraphformat/#setDepth) értékét `0`, `1`, `2` és `3`-ra.
5. Adja hozzá a bekezdéseket a szövegdobozhoz, majd mentse a prezentációt.

Ez a Python példa egy négy szintű felsorolási listát hoz létre:

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

### **Számozott listaelemek egyedi kezdőértékekkel**

Használja a [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/hu/python-java/aspose.slides/bulletformat/#setNumberedBulletStartWith) metódust, hogy megadja a számozott bekezdés kezdeti számát.

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) példányt, és adjon egy [AutoShape](https://reference.aspose.com/slides/hu/python-java/aspose.slides/autoshape/) elemet egy diához.
2. Törölje az alapértelmezett bekezdést az alakzat szövegdobozából.
3. Hozzon létre három számozott bekezdést.
4. Állítsa a [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/hu/python-java/aspose.slides/bulletformat/#setNumberedBulletStartWith) értékét `2`, `3` és `7`‑re a megfelelő bekezdéseknél.
5. Adja hozzá a bekezdéseket a szövegdobozhoz, majd mentse a prezentációt.

Ez a Python példa minden bekezdéshez egyedi kezdőszámot rendel:

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

### **Első sor behúzásának beállítása**

Használja a [ParagraphFormat.setIndent](https://reference.aspose.com/slides/hu/python-java/aspose.slides/paragraphformat/#setIndent) metódust az első sor behúzásának szabályozásához. Ez a módszer csak az első sort helyezi el a bekezdés bal margójához képest. Pozitív érték jobbra tolja az első sort, míg a többi sor a bekezdés törzséhez igazodik.

Ha az egész bekezdést szeretné elmozgatni, használja a [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/hu/python-java/aspose.slides/paragraphformat/#setMarginLeft) metódust. Ha csak az első sort szeretné mozgatni, használja a [ParagraphFormat.setIndent](https://reference.aspose.com/slides/hu/python-java/aspose.slides/paragraphformat/#setIndent) metódust.

Az alábbi példa több bekezdést hoz létre, és különböző [ParagraphFormat.setIndent](https://reference.aspose.com/slides/hu/python-java/aspose.slides/paragraphformat/#setIndent) értékeket alkalmaz, hogy bemutassa, hogyan befolyásolja az első sor behúzása a bekezdés elrendezését.

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) példányt.
2. Érje el a cél diát.
3. Adjon hozzá egy téglalap alakú [AutoShape](https://reference.aspose.com/slides/hu/python-java/aspose.slides/autoshape/) elemet a diához.
4. Érje el az alakzat [TextFrame](https://reference.aspose.com/slides/hu/python-java/aspose.slides/textframe/) elemét, és távolítsa el az alapértelmezett bekezdést.
5. Hozzon létre több bekezdést, és állítson be különböző [ParagraphFormat.setIndent](https://reference.aspose.com/slides/hu/python-java/aspose.slides/paragraphformat/#setIndent) értékeket számukra.
6. Adja hozzá a bekezdéseket a szövegdobozhoz.
7. Mentse a módosított prezentációt.

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

![Az első sor behúzása a bekezdéseknél](first_line_indent.png)

### **Akasztott behúzás beállítása**

Az akasztott behúzás olyan bekezdéselrendezés, amelyben az első sor balra helyezkedik a többi sorhoz képest. Az Aspose.Slides‑ben ezt a hatást a [ParagraphFormat.setIndent](https://reference.aspose.com/slides/hu/python-java/aspose.slides/paragraphformat/#setIndent) segítségével hozhatja létre. Negatív érték megadása az első sort balra toja a bekezdés törzséhez képest.

Gyakorlatban a [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/hu/python-java/aspose.slides/paragraphformat/#setMarginLeft) határozza meg a bekezdés törzsének bal pozícióját, a [ParagraphFormat.setIndent](https://reference.aspose.com/slides/hu/python-java/aspose.slides/paragraphformat/#setIndent) pedig az első sor pozícióját ehhez a margóhoz képest. Akasztott behúzás létrehozásához adjon pozitív értéket a [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/hu/python-java/aspose.slides/paragraphformat/#setMarginLeft)‑nek, és negatív értéket a [ParagraphFormat.setIndent](https://reference.aspose.com/slides/hu/python-java/aspose.slides/paragraphformat/#setIndent)‑nek.

Ez a formázás hasznos bibliográfiák, hivatkozások, szójegyzék-bejegyzések és egyéb bekezdések esetén, ahol a megtörtt soroknak a bekezdés törzsének alá kell illeszkedniük, nem az első sor első karakteréhez.

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) példányt.
2. Érje el a cél diát.
3. Adjon hozzá egy téglalap alakú [AutoShape](https://reference.aspose.com/slides/hu/python-java/aspose.slides/autoshape/) elemet a diához.
4. Érje el az alakzat [TextFrame](https://reference.aspose.com/slides/hu/python-java/aspose.slides/textframe/) elemét, és távolítsa el az alapértelmezett bekezdést.
5. Hozzon létre bekezdéseket, és adjon minden bekezdéshez egy pozitív értéket a [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/hu/python-java/aspose.slides/paragraphformat/#setMarginLeft)‑nek.
6. Adj egy negatív értéket a [ParagraphFormat.setIndent](https://reference.aspose.com/slides/hu/python-java/aspose.slides/paragraphformat/#setIndent)‑nek az akasztott behúzás hatásának létrehozásához.
7. Adja hozzá a bekezdéseket a szövegdobozhoz.
8. Mentse a módosított prezentációt.

Ez a kód megmutatja, hogyan állítható be akasztott behúzás egy bekezdéshez:

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

![Az akasztott behúzás a bekezdéseknél](hanging_indent.png)

### **Bekezdés végjellemzőinek beállítása**

A [Paragraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/hu/python-java/aspose.slides/paragraph/#setEndParagraphPortionFormat) szabályozza a bekezdés végjelének formázását. Az alábbi példa a második bekezdés végjeléhez betűméretet és latin betűtípust rendel:

1. Töltsön be egy [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) fájlt, és érje el egy diát.
2. Adjon egy [AutoShape](https://reference.aspose.com/slides/hu/python-java/aspose.slides/autoshape/) elemet, és törölje annak alapértelmezett bekezdését.
3. Hozzon létre két bekezdést, és adjon hozzá szövegrészeket.
4. Hozzon létre egy [PortionFormat](https://reference.aspose.com/slides/hu/python-java/aspose.slides/portionformat/) objektumot a második bekezdés végjeléhez.
5. Állítsa be a [BasePortionFormat.setFontHeight](https://reference.aspose.com/slides/hu/python-java/aspose.slides/baseportionformat/#setFontHeight) és a [BasePortionFormat.setLatinFont](https://reference.aspose.com/slides/hu/python-java/aspose.slides/baseportionformat/#setLatinFont) értékeket.
6. Rendelje hozzá a formátumot a [Paragraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/hu/python-java/aspose.slides/paragraph/#setEndParagraphPortionFormat) metódussal, majd mentse a prezentációt.

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

## **Megjelenített sorok számolása**

Az automatikus sortörést és a sorvégi írásjelek kezelését érintő bekezdés-szabályokért lásd a [Control Line Breaking](/slides/hu/python-java/text-formatting/#control-line-breaking) és a [Control Hanging Punctuation](/slides/hu/python-java/text-formatting/#control-hanging-punctuation) oldalt.

Használja a [Paragraph.getLinesCount](https://reference.aspose.com/slides/hu/python-java/aspose.slides/paragraph/#getLinesCount) metódust a bekezdés által a szöveg elrendezése után elfoglalt sorok számának meghatározásához, beleértve az automatikus sortörést. Ez hasznos a szöveg hossza és elrendezése ellenőrzésénél prezentációs sablonokban.

Egy bekezdés a [TextFrame.getParagraphs](https://reference.aspose.com/slides/hu/python-java/aspose.slides/textframe/#getParagraphs) elemek egyike, és több megjelenített sorba is beleférhet. Egy explicit sortörés a bekezdésen belül új sort kényszerít anélkül, hogy új bekezdést hozna létre. Az automatikus sortörés a rendelkezésre álló szélesség alapján hoz létre sorokat, anélkül hogy a szövegbe explicit sortörés karaktereket szúrna be. Így a bekezdések vagy sortörés karakterek számolása nem adja meg a tényleges megjelenített sorok számát.

Az alábbi példa egy szöveges alakzatot hoz létre, megszámolja a sorait, szűkíti az alakzatot, majd a szöveget egy rövidebb karakterláncra cseréli. A sortörés engedélyezett, az automatikus illesztés le van tiltva, így az alakzat szélessége szabályozza a sortörést anélkül, hogy a szöveg vagy az alakzat automatikusan zsugorodna. Az alakzat méretei pontban vannak megadva. Végül a példa egy további bekezdést ad hozzá, és összeadja a sorok számát a szövegdobozban.

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

Ezzel a szöveggel és ezekkel a méretekkel a forma szűkítése növeli a sorok számát, míg a rövidebb szövegre cserélése csökkenti azt. A pontos számok változhatnak a betűtípus elérhetőségétől és helyettesítésétől, a betűmérettől, a margóktól, a behúzástól, a sortöréstől és az automatikus illesztés beállításaitól. A sablon ellenőrzésekor használja a célkörnyezetben tervezett betűtípusokat és elrendezési beállításokat.

Magát a sorok számát önmagában nem határozza meg, hogy a szöveg kifolyik-e a tárolóból. A rendelkezésre álló magasság, a sormagasságok, a bekezdés‑ és sor‑távolság, valamint az automatikus illesztés viselkedése is számít; még egyetlen sor is meghaladhatja a rendelkezésre álló szélességet, ha a sortörés ki van kapcsolva.

## **Bekezdés tartalmának importálása és exportálása**

### **HTML szöveg importálása bekezdésekbe**

Használja a [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/hu/python-java/aspose.slides/paragraphcollection/#addFromHtml) metódust a HTML jelölés bekezdésekké és részekké konvertálásához egy szövegdobozban.

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) példányt.
2. Érje el egy diát, és adjon hozzá egy [AutoShape](https://reference.aspose.com/slides/hu/python-java/aspose.slides/autoshape/) elemet.
3. Érje el az alakzat [TextFrame](https://reference.aspose.com/slides/hu/python-java/aspose.slides/textframe/) elemét, és törölje az alapértelmezett bekezdést.
4. Olvassa be a forrás HTML fájlt.
5. Adja át a HTML karakterláncot a [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/hu/python-java/aspose.slides/paragraphcollection/#addFromHtml) metódusnak.
6. Mentse a módosított prezentációt.

Ez a Python példa HTML‑t importál egy szövegdobozba:

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

### **Bekezdés szöveg exportálása HTML‑re**

Használja a [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/hu/python-java/aspose.slides/paragraphcollection/#exportToHtml) metódust a kiválasztott bekezdéstarcs azok HTML‑ként történő exportálásához.

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) példányt, és töltse be a kívánt prezentációt.
2. Érje el a diát, és keresse meg azt az [AutoShape](https://reference.aspose.com/slides/hu/python-java/aspose.slides/autoshape/) elemet, amely a szöveget tartalmazza.
3. Érje el az alakzat [TextFrame](https://reference.aspose.com/slides/hu/python-java/aspose.slides/textframe/) elemét.
4. Hívja meg a [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/hu/python-java/aspose.slides/paragraphcollection/#exportToHtml) metódust a kezdő bekezdés indexével és az exportálandó bekezdések számával.
5. Írja a visszakapott HTML karakterláncot egy fájlba.

Ez a Python példa az első szöveges alakzat összes bekezdését exportálja:

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

A [Paragraph.getImage](https://reference.aspose.com/slides/hu/python-java/aspose.slides/paragraph/) közvetlenül rendereli az egyes bekezdéseket, és egy képobjektust ad vissza. A kapott eredményt mentse fájlba vagy adatfolyamba a `save` metódussal. Nem szükséges a környező alakzatot renderelni vagy a bitmapet manuálisan vágni.

A [Paragraph.getImage](https://reference.aspose.com/slides/hu/python-java/aspose.slides/paragraph/) `None` értékkel térhet vissza, ha a bekezdés nem található a szülőgyűjteményben, nincs érvényes megjelenítési határa, vagy nem renderelhető. Ellenőrizze az eredményt a mentés előtt, és a használat után szabadítsa fel a visszakapott képet.

#### **Bekezdés renderelése alapértelmezett mérettel**

Tegyük fel, hogy van egy `sample.pptx` nevű prezentáció egy diával, ahol az első alakzat egy három bekezdést tartalmazó szövegdoboz.

![A szövegdoboz három bekezdéssel](paragraph_to_image_input.png)

Az alábbi példa a második bekezdést rendereli egy szokásos szövegdobozon alapértelmezett mérettel, majd PNG formátumban menti a visszakapott képet. A `finally` blokk biztosítja, hogy a kép megfelelően legyen felszabadítva.

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

#### **Bekezdés renderelése táblázatcellában skálázással**

Használja a [Paragraph.getImage](https://reference.aspose.com/slides/hu/python-java/aspose.slides/paragraph/) túllépését, amely a `scale_x` és `scale_y` paramétereket fogadja a vízszintes és függőleges méretarányok meghatározásához. Az alábbi példa egy táblázatot hoz létre, és az első cellájában lévő bekezdést kétszeres szélességgel és magassággal rendereli, majd PNG képként menti az eredményt.

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

Az `1` érték megtartja az adott tengelyt az alapértelmezett pixelméretben. Például a `2` mindkét tényezőre egy képhez vezet, amelynek szélessége és magassága megközelítőleg kétszerese az alapértelmezett méretnek, ami négyzetes pixel számot eredményez. A nagyobb tényezők általában élesebb szöveget biztosítanak nagyításhoz vagy nagy felbontású kimenethez, de növelik a memóriahasználatot és a fájlméretet. Az `1` alatti tényezők kisebb képeket hoznak létre, kevesebb részlettel. Az egyenlő tényezők megtartják a bekezdés oldalarányát; a különböző vízszintes és függőleges tényezők pedig önállóan nyújtják vagy zsugorítják a képet.

Az egész alakzat [Shape.getImage](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shape/#getImage) metódussal való renderelése akkor hasznos, ha a kimenetnek tartalmaznia kell az alakzat kitöltését, keretét vagy egyéb vizuális kontextusát. Kizárólag bekezdés‑kép esetén használja a [Paragraph.getImage](https://reference.aspose.com/slides/hu/python-java/aspose.slides/paragraph/) metódust.

## **GYIK**

**Teljesen letiltható a sortörés a szövegdobozban?**

Igen. Állítsa a [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/hu/python-java/aspose.slides/textframeformat/#setWrapText) értékét a sortörés letiltásához, így a sorok nem törnek meg a szövegdoboz szélén.

**Hogyan kapható meg egy adott bekezdés pontos dián lévő határa?**

Használja a [Paragraph.getRect](https://reference.aspose.com/slides/hu/python-java/aspose.slides/paragraph/#getRect) metódust a bekezdés határoló téglalapjának lekérdezéséhez. A [Portion.getRect](https://reference.aspose.com/slides/hu/python-java/aspose.slides/portion/#getRect) egyetlen rész határait adja vissza.

**Hol van szabályozva a bekezdés igazítása (balra, jobbra, középre vagy sorkizárt)?**

A [ParagraphFormat.setAlignment](https://reference.aspose.com/slides/hu/python-java/aspose.slides/paragraphformat/#setAlignment) bekezdés‑szintű beállítás, és a teljes bekezdésre érvényes, függetlenül az egyes részek formázásától.

**Beállítható a nyelvi ellenőrzés egy bekezdés egy részére?**

Igen. Állítsa a [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/hu/python-java/aspose.slides/baseportionformat/#setLanguageId) értékét az egyes részekre, így egy bekezdés több nyelven írt szöveget is tartalmazhat.