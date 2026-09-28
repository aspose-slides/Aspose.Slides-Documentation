---
title: PowerPoint szövegbekezdések kezelése Pythonban
linktitle: Bekezdés kezelése
type: docs
weight: 40
url: /hu/python-net/manage-paragraph/
aliases:
  - /python-net/paragraph/
  - /python-net/portion/
keywords:
- szöveg hozzáadása
- bekezdés hozzáadása
- szöveg kezelése
- bekezdés kezelése
- felsorolás kezelése
- bekezdés behúzás
- függő behúzás
- bekezdés felsorolás
- számozott lista
- pontozott lista
- bekezdés tulajdonságok
- HTML importálása
- szöveg HTML-be
- bekezdés HTML-be
- bekezdés képre
- szöveg képre
- bekezdés exportálása
- PowerPoint
- prezentáció
- Python
- Aspose.Slides
description: "Tanulja meg, hogyan hozhat létre és formázhat bekezdéseket, részeket, felsorolásjeleket, számozott listákat, behúzások, HTML tartalmakat és bekezdés képeket az Aspose.Slides for Python via .NET segítségével."
---
## **Áttekintés**

Az Aspose.Slides for Python via .NET a szöveget szövegkeretek, bekezdések és részek hierarchiájaként ábrázolja:

* [TextFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframe/) a alakzat szövegtárolóját képviseli, és hozzáférést biztosít a bekezdésgyűjteményéhez.
* [Paragraph](https://reference.aspose.com/slides/hu/python-net/aspose.slides/paragraph/) egy bekezdést képvisel egy szövegkeretben, és hozzáférést biztosít a részeihez és a bekezdés szintű formázáshoz.
* [Portion](https://reference.aspose.com/slides/hu/python-net/aspose.slides/portion/) a bekezdésen belüli szövegegységet jelöli. Minden résznek saját szövege és karakter szintű formázása lehet.

A bekezdés ezért több rész használatával különböző betűtípusú, színű, méretű és egyéb formázású szöveget tartalmazhat.

## **Bekezdések létrehozása és formázása**

### **Több részes bekezdések létrehozása**

Az alábbi lépések egy szövegkeretet hoznak létre három bekezdéssel, mindegyikben három résszel:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztályból.
2. A megfelelő diát az indexén keresztül érje el.
3. Adjon egy téglalap alakú [AutoShape](https://reference.aspose.com/slides/hu/python-net/aspose.slides/autoshape/) elemet a diához.
4. A forma [TextFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframe/) elemét érje el.
5. Használja az alapértelmezett bekezdést, és adjon hozzá további két [Paragraph](https://reference.aspose.com/slides/hu/python-net/aspose.slides/paragraph/) objektumot a szövegkerethez.
6. Adjunk elegendő [Portion](https://reference.aspose.com/slides/hu/python-net/aspose.slides/portion/) objektumot minden bekezdéshez, hogy három részt tartalmazzon. Az alapértelmezett bekezdés már egy üres részt tartalmaz.
7. Állítsa be minden rész szövegét.
8. Alkalmazzon karakter szintű formázást a [Portion.portion_format](https://reference.aspose.com/slides/hu/python-net/aspose.slides/portion/portion_format/) segítségével.
9. Mentse a módosított prezentációt.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 300, 150)
    text_frame = shape.text_frame

    first_paragraph = text_frame.paragraphs[0]
    first_paragraph.portions.add(slides.Portion())
    first_paragraph.portions.add(slides.Portion())

    second_paragraph = slides.Paragraph()
    second_paragraph.portions.add(slides.Portion())
    second_paragraph.portions.add(slides.Portion())
    second_paragraph.portions.add(slides.Portion())
    text_frame.paragraphs.add(second_paragraph)

    third_paragraph = slides.Paragraph()
    third_paragraph.portions.add(slides.Portion())
    third_paragraph.portions.add(slides.Portion())
    third_paragraph.portions.add(slides.Portion())
    text_frame.paragraphs.add(third_paragraph)

    for paragraph_index in range(text_frame.paragraphs.count):
        paragraph = text_frame.paragraphs[paragraph_index]
        for portion_index in range(paragraph.portions.count):
            portion = paragraph.portions[portion_index]
            portion.text = f"Portion {paragraph_index + 1}.{portion_index + 1}"

            if portion_index == 0:
                portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
                portion.portion_format.fill_format.solid_fill_color.color = draw.Color.red
                portion.portion_format.font_bold = slides.NullableBool.TRUE
                portion.portion_format.font_height = 15
            elif portion_index == 1:
                portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
                portion.portion_format.fill_format.solid_fill_color.color = draw.Color.blue
                portion.portion_format.font_italic = slides.NullableBool.TRUE
                portion.portion_format.font_height = 18

    presentation.save("paragraphs_with_portions.pptx", slides.export.SaveFormat.PPTX)
```

## **Pontozott és számozott listák létrehozása**

### **Pontozott vagy számozott lista létrehozása**

A felsorolások és a számozás megkönnyítik az egymáshoz kapcsolódó elemek áttekintését. Az Aspose.Slides-ben a lista beállításait a [BulletFormat](https://reference.aspose.com/slides/hu/python-net/aspose.slides/bulletformat/) határozza meg.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztályból.
2. A megfelelő diát az indexén keresztül érje el.
3. Adjon egy [AutoShape](https://reference.aspose.com/slides/hu/python-net/aspose.slides/autoshape/) elemet a kiválasztott diához.
4. A forma [TextFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframe/) elemét érje el.
5. Távolítsa el az alapértelmezett bekezdést a szövegkeretből.
6. Hozzon létre egy [Paragraph](https://reference.aspose.com/slides/hu/python-net/aspose.slides/paragraph/) elemet egy szimbólumjelzőhöz.
7. Állítsa be a [BulletFormat.type](https://reference.aspose.com/slides/hu/python-net/aspose.slides/bulletformat/type/) értékét [BulletType.SYMBOL](https://reference.aspose.com/slides/hu/python-net/aspose.slides/bullettype/)‑ra, és adja meg a jelző karaktert.
8. Állítsa be a bekezdés szövegét, behúzását, a jelző színét és magasságát.
9. Adja hozzá a bekezdést a szövegkerethez.
10. Hozzon létre egy második bekezdést, és állítsa be a [BulletFormat.type](https://reference.aspose.com/slides/hu/python-net/aspose.slides/bulletformat/type/) értékét [BulletType.NUMBERED](https://reference.aspose.com/slides/hu/python-net/aspose.slides/bullettype/).
11. Konfigurálja a számozott jelző stílusát, és adja hozzá a bekezdést a szövegkerethez.
12. Mentse a prezentációt.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)
    text_frame = shape.text_frame
    text_frame.paragraphs.clear()

    symbol_paragraph = slides.Paragraph()
    symbol_paragraph.text = "Welcome to Aspose.Slides"
    symbol_paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    symbol_paragraph.paragraph_format.bullet.char = chr(0x2022)
    symbol_paragraph.paragraph_format.indent = 25
    symbol_paragraph.paragraph_format.bullet.color.color_type = slides.ColorType.RGB
    symbol_paragraph.paragraph_format.bullet.color.color = draw.Color.black
    symbol_paragraph.paragraph_format.bullet.is_bullet_hard_color = slides.NullableBool.TRUE
    symbol_paragraph.paragraph_format.bullet.height = 100
    text_frame.paragraphs.add(symbol_paragraph)

    numbered_paragraph = slides.Paragraph()
    numbered_paragraph.text = "This is a numbered item"
    numbered_paragraph.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    numbered_paragraph.paragraph_format.bullet.numbered_bullet_style = slides.NumberedBulletStyle.BULLET_CIRCLE_NUM_WD_BLACK_PLAIN
    numbered_paragraph.paragraph_format.indent = 25
    numbered_paragraph.paragraph_format.bullet.color.color_type = slides.ColorType.RGB
    numbered_paragraph.paragraph_format.bullet.color.color = draw.Color.black
    numbered_paragraph.paragraph_format.bullet.is_bullet_hard_color = slides.NullableBool.TRUE
    numbered_paragraph.paragraph_format.bullet.height = 100
    text_frame.paragraphs.add(numbered_paragraph)

    presentation.save("bulleted_and_numbered_list.pptx", slides.export.SaveFormat.PPTX)
```

### **Képes jelzők használata**

Az képes jelzők lehetővé teszik, hogy egy egyedi képet használjon szimbólum vagy szám helyett.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztályból.
2. A megfelelő diát az indexén keresztül érje el.
3. Adjon egy [AutoShape](https://reference.aspose.com/slides/hu/python-net/aspose.slides/autoshape/) elemet, és annak [TextFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframe/) elemét érje el.
4. Távolítsa el az alapértelmezett bekezdést a szövegkeretből.
5. Töltse be a jelző képet, és adja hozzá a prezentáció képgyűjteményéhez [PPImage](https://reference.aspose.com/slides/hu/python-net/aspose.slides/ppimage/)ként.
6. Hozzon létre egy [Paragraph](https://reference.aspose.com/slides/hu/python-net/aspose.slides/paragraph/) elemet, és állítsa be a szövegét.
7. Állítsa be a [BulletFormat.type](https://reference.aspose.com/slides/hu/python-net/aspose.slides/bulletformat/type/) értékét [BulletType.PICTURE](https://reference.aspose.com/slides/hu/python-net/aspose.slides/bullettype/).
8. Rendelje hozzá a képet a [BulletFormat.picture](https://reference.aspose.com/slides/hu/python-net/aspose.slides/bulletformat/picture/)‑en keresztül, és állítsa be a jelző magasságát.
9. Adja hozzá a bekezdést a szövegkerethez.
10. Mentse a módosított prezentációt.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("bullets.png") as bullet_image:
        presentation_image = presentation.images.add_image(bullet_image)

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)
    text_frame = shape.text_frame
    text_frame.paragraphs.clear()

    paragraph = slides.Paragraph()
    paragraph.text = "Welcome to Aspose.Slides"
    paragraph.paragraph_format.bullet.type = slides.BulletType.PICTURE
    paragraph.paragraph_format.bullet.picture.image = presentation_image
    paragraph.paragraph_format.bullet.height = 100
    text_frame.paragraphs.add(paragraph)

    presentation.save("picture_bullet.pptx", slides.export.SaveFormat.PPTX)
    presentation.save("picture_bullet.ppt", slides.export.SaveFormat.PPT)
```

### **Többszintű lista létrehozása**

Állítsa be a [ParagraphFormat.depth](https://reference.aspose.com/slides/hu/python-net/aspose.slides/paragraphformat/depth/) értékét a bekezdések listában való különböző szintekre helyezéséhez. A legfelső szint mélysége `0`.

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) objektumot, és érje el egy diát.
2. Adjon egy [AutoShape](https://reference.aspose.com/slides/hu/python-net/aspose.slides/autoshape/) elemet, és törölje az alapértelmezett bekezdést a szövegkeretből.
3. Hozzon létre négy bekezdést, és állítsa be a jelző szimbólumaikat.
4. Állítsa be a [ParagraphFormat.depth](https://reference.aspose.com/slides/hu/python-net/aspose.slides/paragraphformat/depth/) értékeket `0`, `1`, `2` és `3`‑ra.
5. Adja hozzá a bekezdéseket a szövegkerethez, és mentse a prezentációt.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)
    text_frame = shape.text_frame
    text_frame.paragraphs.clear()

    first_paragraph = slides.Paragraph()
    first_paragraph.text = "Content"
    first_paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    first_paragraph.paragraph_format.bullet.char = chr(0x2022)
    first_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    first_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    first_paragraph.paragraph_format.depth = 0

    second_paragraph = slides.Paragraph()
    second_paragraph.text = "Second level"
    second_paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    second_paragraph.paragraph_format.bullet.char = "-"
    second_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    second_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    second_paragraph.paragraph_format.depth = 1

    third_paragraph = slides.Paragraph()
    third_paragraph.text = "Third level"
    third_paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    third_paragraph.paragraph_format.bullet.char = chr(0x2022)
    third_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    third_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    third_paragraph.paragraph_format.depth = 2

    fourth_paragraph = slides.Paragraph()
    fourth_paragraph.text = "Fourth level"
    fourth_paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    fourth_paragraph.paragraph_format.bullet.char = "-"
    fourth_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    fourth_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    fourth_paragraph.paragraph_format.depth = 3

    text_frame.paragraphs.add(first_paragraph)
    text_frame.paragraphs.add(second_paragraph)
    text_frame.paragraphs.add(third_paragraph)
    text_frame.paragraphs.add(fourth_paragraph)

    presentation.save("multilevel_list.pptx", slides.export.SaveFormat.PPTX)
```

### **Számozott listaelemek egyéni kezdőértékkel**

Használja a [BulletFormat.numbered_bullet_start_with](https://reference.aspose.com/slides/hu/python-net/aspose.slides/bulletformat/numbered_bullet_start_with/) beállítást, hogy megadja a számozott bekezdés kezdeti számát.

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) objektumot, és adjon egy [AutoShape](https://reference.aspose.com/slides/hu/python-net/aspose.slides/autoshape/) elemet egy diához.
2. Törölje az alapértelmezett bekezdést a forma szövegkeretéből.
3. Hozzon létre három számozott bekezdést.
4. Állítsa be a [BulletFormat.numbered_bullet_start_with](https://reference.aspose.com/slides/hu/python-net/aspose.slides/bulletformat/numbered_bullet_start_with/) értékét a megfelelő bekezdésekhez `2`, `3` és `7`‑re.
5. Adja hozzá a bekezdéseket a szövegkerethez, és mentse a prezentációt.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)
    text_frame = shape.text_frame
    text_frame.paragraphs.clear()

    first_paragraph = slides.Paragraph()
    first_paragraph.text = "Start at 2"
    first_paragraph.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    first_paragraph.paragraph_format.bullet.numbered_bullet_start_with = 2
    text_frame.paragraphs.add(first_paragraph)

    second_paragraph = slides.Paragraph()
    second_paragraph.text = "Start at 3"
    second_paragraph.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    second_paragraph.paragraph_format.bullet.numbered_bullet_start_with = 3
    text_frame.paragraphs.add(second_paragraph)

    third_paragraph = slides.Paragraph()
    third_paragraph.text = "Start at 7"
    third_paragraph.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    third_paragraph.paragraph_format.bullet.numbered_bullet_start_with = 7
    text_frame.paragraphs.add(third_paragraph)

    presentation.save("custom_numbered_list.pptx", slides.export.SaveFormat.PPTX)
```

## **Bekezdéselrendezés és végjellemzők szabályozása**

### **Első sor behúzás beállítása**

A [ParagraphFormat.indent](https://reference.aspose.com/slides/hu/python-net/aspose.slides/paragraphformat/indent/) tulajdonságot használja a bekezdés első sorának behúzásának szabályozásához. Ez a tulajdonság csak az első sort mozgatja a bekezdés bal margójához képest. A pozitív érték jobbra tolja az első sort, míg a többi sor a bekezdés törzséhez igazodik.

Használja a [ParagraphFormat.margin_left](https://reference.aspose.com/slides/hu/python-net/aspose.slides/paragraphformat/margin_left/)‑t, ha a teljes bekezdést szeretné elmozdítani. Használja a [ParagraphFormat.indent](https://reference.aspose.com/slides/hu/python-net/aspose.slides/paragraphformat/indent/)‑t, ha csak az első sort kell eltolni.

Az alábbi példa több bekezdést hoz létre, és különböző [ParagraphFormat.indent](https://reference.aspose.com/slides/hu/python-net/aspose.slides/paragraphformat/indent/) értékeket alkalmaz, hogy bemutassa, miként befolyásolja az első sor behúzása a bekezdéselrendezést.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztályból.
2. Érje el a cél diát.
3. Adjon egy téglalap alakú [AutoShape](https://reference.aspose.com/slides/hu/python-net/aspose.slides/autoshape/) elemet a diához.
4. A forma [TextFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframe/) elemét érje el, és távolítsa el az alapértelmezett bekezdést.
5. Hozzon létre több bekezdést, és állítson be nekik különböző [ParagraphFormat.indent](https://reference.aspose.com/slides/hu/python-net/aspose.slides/paragraphformat/indent/) értékeket.
6. Adja a bekezdéseket a szövegkerethez.
7. Mentse a módosított prezentációt.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 420, 220)
    shape.fill_format.fill_type = slides.FillType.NO_FILL
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.gray

    text_frame = shape.text_frame
    text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE
    text_frame.paragraphs.clear()

    first_paragraph = slides.Paragraph()
    first_paragraph.text = "No first-line indent. Wrapped lines start at the same position as the first line."
    first_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    first_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    first_paragraph.paragraph_format.margin_left = 20
    first_paragraph.paragraph_format.indent = 0

    second_paragraph = slides.Paragraph()
    second_paragraph.text = "First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body."
    second_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    second_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    second_paragraph.paragraph_format.margin_left = 20
    second_paragraph.paragraph_format.indent = 20

    third_paragraph = slides.Paragraph()
    third_paragraph.text = "First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see."
    third_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    third_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    third_paragraph.paragraph_format.margin_left = 20
    third_paragraph.paragraph_format.indent = 40

    text_frame.paragraphs.add(first_paragraph)
    text_frame.paragraphs.add(second_paragraph)
    text_frame.paragraphs.add(third_paragraph)

    presentation.save("paragraph_indent.pptx", slides.export.SaveFormat.PPTX)
```

Az eredmény:

![Az első sor behúzása a bekezdésekben](first_line_indent.png)

### **Függő behúzás beállítása**

A függő behúzás egy bekezdéselrendezés, ahol az első sor a többi sor bal oldalán kezdődik. Az Aspose.Slides-ben ezt a hatást a [ParagraphFormat.indent](https://reference.aspose.com/slides/hu/python-net/aspose.slides/paragraphformat/indent/) tulajdonsággal hozhatja létre. Állítsa a `indent`‑et negatív értékre, hogy az első sort a bekezdés törzséhez képest balra mozgassa.

Gyakorlatban a [ParagraphFormat.margin_left](https://reference.aspose.com/slides/hu/python-net/aspose.slides/paragraphformat/margin_left/) határozza meg a bekezdés törzsének bal pozícióját, míg a [ParagraphFormat.indent](https://reference.aspose.com/slides/hu/python-net/aspose.slides/paragraphformat/indent/) definiálja az első sor helyzetét ehhez a margóhoz képest. Függő behúzás létrehozásához állítson be pozitív `margin_left` értéket és negatív `indent` értéket.

Ez a formázás hasznos bibliográfiák, hivatkozások, szójegyzék bejegyzések és más bekezdések esetén, ahol a sortöréses soroknak a bekezdés törzse alatt kell igazodni, nem pedig az első sor első karaktere alatt.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztályból.
2. Érje el a cél diát.
3. Adjon egy téglalap alakú [AutoShape](https://reference.aspose.com/slides/hu/python-net/aspose.slides/autoshape/) elemet a diához.
4. A forma [TextFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframe/) elemét érje el, és távolítsa el az alapértelmezett bekezdést.
5. Hozzon létre bekezdéseket, és állítson be egy pozitív [ParagraphFormat.margin_left](https://reference.aspose.com/slides/hu/python-net/aspose.slides/paragraphformat/margin_left/) értéket minden bekezdéshez.
6. Állítson be egy negatív [ParagraphFormat.indent](https://reference.aspose.com/slides/hu/python-net/aspose.slides/paragraphformat/indent/) értéket a függő behúzás hatásának létrehozásához.
7. Adja a bekezdéseket a szövegkerethez.
8. Mentse a módosított prezentációt.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 420, 220)
    shape.fill_format.fill_type = slides.FillType.NO_FILL
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.gray

    text_frame = shape.text_frame
    text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE
    text_frame.paragraphs.clear()

    first_paragraph = slides.Paragraph()
    first_paragraph.text = "A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body."
    first_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    first_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    first_paragraph.paragraph_format.margin_left = 40
    first_paragraph.paragraph_format.indent = -20

    second_paragraph = slides.Paragraph()
    second_paragraph.text = "This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare."
    second_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    second_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    second_paragraph.paragraph_format.margin_left = 60
    second_paragraph.paragraph_format.indent = -30

    text_frame.paragraphs.add(first_paragraph)
    text_frame.paragraphs.add(second_paragraph)

    presentation.save("hanging_indent.pptx", slides.export.SaveFormat.PPTX)
```

Az eredmény:

![A bekezdések függő behúzása](hanging_indent.png)

### **Bekezdésvégi futtatási tulajdonságok beállítása**

A [Paragraph.end_paragraph_portion_format](https://reference.aspose.com/slides/hu/python-net/aspose.slides/paragraph/end_paragraph_portion_format/) tulajdonság szabályozza a bekezdés végjelének formázását. Az alábbi példa betűméretet és latin betűtípust rendel a második bekezdés végjeléhez:

1. Töltsön be egy [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) objektumot, és érje el egy diát.
2. Adjon egy [AutoShape](https://reference.aspose.com/slides/hu/python-net/aspose.slides/autoshape/) elemet, és törölje az alapértelmezett bekezdését.
3. Hozzon létre két bekezdést, és adjon szövegrészeket hozzájuk.
4. Hozzon létre egy [PortionFormat](https://reference.aspose.com/slides/hu/python-net/aspose.slides/portionformat/) objektumot a második bekezdés végjeléhez.
5. Állítsa be a [PortionFormat.font_height](https://reference.aspose.com/slides/hu/python-net/aspose.slides/portionformat/font_height/) és a [PortionFormat.latin_font](https://reference.aspose.com/slides/hu/python-net/aspose.slides/portionformat/latin_font/) értékeket.
6. Rendelje a formátumot a [Paragraph.end_paragraph_portion_format](https://reference.aspose.com/slides/hu/python-net/aspose.slides/paragraph/end_paragraph_portion_format/)‑hez, és mentse a prezentációt.

```python
import aspose.slides as slides

with slides.Presentation("Test.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 200, 250)
    text_frame = shape.text_frame
    text_frame.paragraphs.clear()

    first_paragraph = slides.Paragraph()
    first_paragraph.portions.add(slides.Portion("Sample text"))

    second_paragraph = slides.Paragraph()
    second_paragraph.portions.add(slides.Portion("Sample text 2"))

    end_paragraph_format = slides.PortionFormat()
    end_paragraph_format.font_height = 48
    end_paragraph_format.latin_font = slides.FontData("Times New Roman")
    second_paragraph.end_paragraph_portion_format = end_paragraph_format

    text_frame.paragraphs.add(first_paragraph)
    text_frame.paragraphs.add(second_paragraph)

    presentation.save("end_paragraph_format.pptx", slides.export.SaveFormat.PPTX)
```

## **Megjelenített sorok számlálása**

A bekezdés szabályok, amelyek az automatikus sortörést és a sorvégi írásjeleket befolyásolják, lásd [Control Line Breaking](/slides/hu/python-net/text-formatting/#control-line-breaking) és [Control Hanging Punctuation](/slides/hu/python-net/text-formatting/#control-hanging-punctuation).

Használja a [Paragraph.get_lines_count](https://reference.aspose.com/slides/hu/python-net/aspose.slides/paragraph/get_lines_count/) metódust, hogy megszámolja a bekezdés által elfoglalt sorok számát a szöveg elrendezése után, beleértve az automatikus sortörést. Ez hasznos a szöveghossz és az elrendezés ellenőrzésénél prezentáció sablonokban.

Egy bekezdés a [TextFrame.paragraphs](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframe/paragraphs/) egy eleme, és több megjelenített sort is elfoglalhat. Egy kifejezett sortörés a bekezdésen belül új sort kényszerít, anélkül, hogy új bekezdést hozna létre. Az automatikus sortörés a rendelkezésre álló szélesség alapján hoz sorokat, anélkül, hogy kifejezett sortöréseket szúrna a szövegbe. Így a bekezdések vagy sortörés karakterek számolása nem adja meg a megjelenített sorok számát.

Az alábbi példa létrehoz egy szöveges alakzatot, megszámolja a sorait, szűkíti az alakzatot, majd a szöveget egy rövidebb karaktersorral helyettesíti. A sortörés engedélyezett, az automatikus illesztés le van tiltva, így az alakzat szélessége szabályozza a sortörést anélkül, hogy automatikusan zsugorítaná a szöveget vagy átméretezné az alakzatot. Az alakzat méretei pontban vannak megadva. Végül a példa hozzáad egy újabb bekezdést, és összegzi a sorok számát a szövegkereten belül.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 400, 200)
    text_frame = shape.text_frame
    text_frame.text_frame_format.wrap_text = slides.NullableBool.TRUE
    text_frame.text_frame_format.autofit_type = slides.TextAutofitType.NONE

    paragraph = text_frame.paragraphs[0]
    paragraph.paragraph_format.default_portion_format.font_height = 20
    paragraph.text = "This text demonstrates how automatic wrapping changes the number of rendered lines."
    print(f"Original width: {paragraph.get_lines_count()}")

    shape.width = 150
    print(f"Narrower shape: {paragraph.get_lines_count()}")

    paragraph.text = "Short text."
    print(f"Shorter text: {paragraph.get_lines_count()}")

    second_paragraph = slides.Paragraph()
    second_paragraph.text = "Another paragraph."
    second_paragraph.paragraph_format.default_portion_format.font_height = 20
    text_frame.paragraphs.add(second_paragraph)

    total_line_count = 0
    for current_paragraph in text_frame.paragraphs:
        total_line_count += current_paragraph.get_lines_count()
    print(f"Total lines in the text frame: {total_line_count}")
```

Ezzel a szöveggel és ezekkel a méretekkel a forma szűkítése növeli a sorok számát, míg a szöveg rövid sztringgel való helyettesítése csökkenti azt. A pontos számok változhatnak a betűtípus elérhetőségének és helyettesítésének, betűméretnek, margóknak, behúzásnak, sortörésnek és automatikus illesztés beállításainak függvényében. A sablon ellenőrzésekor használja a célkörnyezethez szánt betűtípusokat és elrendezési beállításokat.

A sorok száma önmagában nem határozza meg, hogy a szöveg túlcsordul-e a tárolóban. A rendelkezésre álló magasság, sormagasságok, bekezdés- és sortávolság, valamint az automatikus illesztés viselkedése is számít; még egyetlen sor is túllépheti a rendelkezésre álló szélességet, ha a sortörés le van tiltva.

## **Bekezdés tartalmának importálása és exportálása**

### **HTML szöveg importálása bekezdésekbe**

Használja a [ParagraphCollection.add_from_html](https://reference.aspose.com/slides/hu/python-net/aspose.slides/paragraphcollection/add_from_html/) módszert, hogy a HTML jelölőnyelvet bekezdésekké és részekké (portions) alakítsa egy szövegkeretben.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztályból.
2. A diát egy [AutoShape](https://reference.aspose.com/slides/hu/python-net/aspose.slides/autoshape/) hozzáadásával érje el.
3. A forma [TextFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframe/) elemét érje el, és törölje az alapértelmezett bekezdést.
4. Olvassa be a forrás HTML fájlt.
5. A HTML karakterláncot adja át a [ParagraphCollection.add_from_html](https://reference.aspose.com/slides/hu/python-net/aspose.slides/paragraphcollection/add_from_html/)‑nek.
6. Mentse a módosított prezentációt.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape_width = presentation.slide_size.size.width - 20
    shape_height = presentation.slide_size.size.height - 20
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, shape_width, shape_height)
    shape.fill_format.fill_type = slides.FillType.NO_FILL
    shape.text_frame.paragraphs.clear()

    with open("file.html", "r", encoding="utf-8") as html_stream:
        html = html_stream.read()

    shape.text_frame.paragraphs.add_from_html(html)
    presentation.save("html_text.pptx", slides.export.SaveFormat.PPTX)
```

### **Bekezdés szövegének exportálása HTML-be**

Használja a [ParagraphCollection.export_to_html](https://reference.aspose.com/slides/hu/python-net/aspose.slides/paragraphcollection/export_to_html/) módszert, hogy a kiválasztott bekezdés tartományt HTML-ként exportálja.

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) példányt, és töltse be a kívánt prezentációt.
2. A diát érje el, és keresse meg a szöveget tartalmazó [AutoShape](https://reference.aspose.com/slides/hu/python-net/aspose.slides/autoshape/) elemet.
3. A forma [TextFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframe/) elemét érje el.
4. Hívja meg a [ParagraphCollection.export_to_html](https://reference.aspose.com/slides/hu/python-net/aspose.slides/paragraphcollection/export_to_html/)‑t a kezdő bekezdés indexével és az exportálandó bekezdések számával.
5. Írja a visszakapott HTML karakterláncot egy fájlba.

```python
import aspose.slides as slides

with slides.Presentation("ExportingHTMLText.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    if isinstance(shape, slides.AutoShape) and shape.text_frame is not None:
        paragraphs = shape.text_frame.paragraphs
        html = paragraphs.export_to_html(0, paragraphs.count, None)
        with open("paragraphs.html", "w", encoding="utf-8") as html_stream:
            html_stream.write(html)
    else:
        print("The first shape is not a text shape.")
```

### **Bekezdés renderelése képként**

A [Paragraph](https://reference.aspose.com/slides/hu/python-net/aspose.slides/paragraph/) a `get_image` metódust biztosítja egy egyedi bekezdés közvetlen rendereléséhez. A metódus egy [IImage](https://reference.aspose.com/slides/hu/python-net/aspose.slides/iimage/) objektumot ad vissza, amelyet a [IImage.save](https://reference.aspose.com/slides/hu/python-net/aspose.slides/iimage/save/)‑vel fájlba vagy adatfolyamba menthet. Nem kell a tartalmazó alakzatot renderelni, vagy a bitmapet kézzel vágni.

A `get_image` metódus `None`‑t adhat vissza, ha a bekezdés nem található meg a szülőgyűjteményben, nincs érvényes renderelési határa, vagy nem renderelhető. Ellenőrizze az eredményt mentés előtt, és a visszakapott képet használja kontextuskezelőként a erőforrások felszabadításához.

#### **Bekezdés renderelése alapértelmezett méretben**

Tegyük fel, hogy van egy sample.pptx nevű prezentációs fájlunk, egy diával, ahol az első alakzat egy három bekezdést tartalmazó szövegdoboz.

![A három bekezdést tartalmazó szövegdoboz](paragraph_to_image_input.png)

Az alábbi példa a második bekezdést rendereli egy szabályos szöveges alakzatban alapértelmezett méretben, és a visszakapott képet PNG formátumban menti:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    if isinstance(shape, slides.AutoShape) and shape.text_frame is not None and shape.text_frame.paragraphs.count > 1:
        paragraph = shape.text_frame.paragraphs[1]
        paragraph_image = paragraph.get_image()

        if paragraph_image is not None:
            with paragraph_image:
                paragraph_image.save("paragraph.png", slides.ImageFormat.PNG)
        else:
            print("The paragraph could not be rendered.")
    else:
        print("The expected text shape or paragraph was not found.")
```

Az eredmény:

![A bekezdés képe](paragraph_to_image_output.png)

#### **Bekezdés renderelése táblázatcellában méretezéssel**

Adjunk meg vízszintes és függőleges méretezési tényezőket a `get_image`‑nek, hogy szabályozzuk a renderelt bekezdés méretét. Az alábbi példa létrehoz egy táblázatot, a bekezdést az első cellájában kétszeres alapértelmezett szélesség és magasság mellett rendereli, és a resultat PNG képként menti:

```python
import aspose.slides as slides

scale_x = 2
scale_y = 2

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    table = slide.shapes.add_table(50, 50, [300], [80])
    paragraph = table.rows[0][0].text_frame.paragraphs[0]
    paragraph.text = "Text in a table cell"

    paragraph_image = paragraph.get_image(scale_x, scale_y)
    if paragraph_image is not None:
        with paragraph_image:
            paragraph_image.save("table_paragraph.png", slides.ImageFormat.PNG)
    else:
        print("The paragraph could not be rendered.")
```

Egy `1` méretezési tényező az adott tengelyen az alapértelmezett pixeleméretet tartja. Például a mindkét tényező `2`‑je egy olyan képet eredményez, amelynek szélessége és magassága megközelítőleg kétszerese az alapértelmezett méretnek, így négyszer annyi pixel. A nagyobb tényezők általában élesebb szöveget eredményeznek nagyításhoz vagy nagy felbontású kimenethez, de növelik a memóriahasználatot és a fájlméretet. Az `1`‑nél kisebb tényezők kisebb, kevésbé részletes képeket hoznak létre. Használjon egyenlő tényezőket a bekezdés képarányának megtartásához; a különböző vízszintes és függőleges tényezők önállóan nyújtják a kimenetet.

Egy egész alakzat renderelése a [Shape.get_image](https://reference.aspose.com/slides/hu/python-net/aspose.slides/shape/get_image/)‑vel továbbra is hasznos, ha a kimenetnek tartalmaznia kell az alakzat kitöltését, szegélyét vagy más vizuális kontextusát. Csak bekezdés képe esetén használja a `Paragraph.get_image`‑t.

## **GYIK**

**Letilthatom teljesen a sortörést egy szövegkereten belül?**

Igen. Állítsa a [TextFrameFormat.wrap_text](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframeformat/wrap_text/) értékét a sortörés letiltásához, így a sorok nem törnek meg a szövegkeret szélén.

**Hogyan kaphatom meg egy adott bekezdés pontos dián lévő határait?**

Használja a [Paragraph.get_rect](https://reference.aspose.com/slides/hu/python-net/aspose.slides/paragraph/get_rect/)‑t a bekezdés határoló téglalapjának lekérdezéséhez. A [Portion.get_rect](https://reference.aspose.com/slides/hu/python-net/aspose.slides/portion/get_rect/) egy adott rész határait adja vissza.

**Hol szabályozható a bekezdés igazítása (balra, jobbra, középre vagy sorkizárás)?**

A [ParagraphFormat.alignment](https://reference.aspose.com/slides/hu/python-net/aspose.slides/paragraphformat/alignment/) bekezdés szintű beállítás, amely a teljes bekezdésre vonatkozik, a részletekre vonatkozó formázástól függetlenül.

**Beállíthatok bizonyítási nyelvet a bekezdés egy részére?**

Igen. Állítsa be a [PortionFormat.language_id](https://reference.aspose.com/slides/hu/python-net/aspose.slides/portionformat/language_id/) értékét az egyes részeknél, így egy bekezdés több nyelven írt szöveget is tartalmazhat.