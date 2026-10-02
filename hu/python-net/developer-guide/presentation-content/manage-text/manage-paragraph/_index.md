---
title: PowerPoint szöveg bekezdések kezelése Pythonban
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
- pont kezelése
- bekezdés behúzása
- függő behúzás
- bekezdés pont
- számozott lista
- pontozott lista
- bekezdés tulajdonságai
- HTML importálása
- szöveg HTML-be
- bekezdés HTML-be
- bekezdés képpé
- szöveg képpé
- bekezdés exportálása
- PowerPoint
- prezentáció
- Python
- Aspose.Slides
description: "Tanulja meg, hogyan hozhat létre és formázhat bekezdéseket, szakaszokat, pontokat, számozott listákat, behúzásokat, HTML-tartalmakat és bekezdésképeket az Aspose.Slides for Python via .NET segítségével."
---
## **Áttekintés**

Az Aspose.Slides for Python via .NET a szöveget szövegkeretek, bekezdések és szakaszok hierarchiájaként ábrázolja:

* [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) egy alakzatban lévő szövegkonténert képvisel, és hozzáférést biztosít a bekezdésgyűjteményéhez.
* [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) egy bekezdést képvisel egy szövegkeretben, és hozzáférést biztosít a szakaszokhoz és a bekezdés szintű formázáshoz.
* [Portion](https://reference.aspose.com/slides/python-net/aspose.slides/portion/) egy szövegrészt képvisel egy bekezdésen belül. Minden szakasz saját szöveget és karakter szintű formázást is tartalmazhat.

Ezért egy bekezdés több szakasz használatával különböző betűtípusokkal, színekkel, méretekkel és egyéb formázással rendelkező szöveget tartalmazhat.

## **Bekezdések létrehozása és formázása**

### **Több szakaszos bekezdések létrehozása**

A következő lépések egy szövegkeretet hoznak létre három bekezdéssel, mindegyik három szakaszt tartalmaz:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) osztályból.
2. Érje el a megfelelő diát az indexén keresztül.
3. Adj egy téglalap alakú [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) a diához.
4. Érje el az alakzat [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/)-jét.
5. Használja az alapértelmezett bekezdést, és adjon hozzá két további [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) objektumot a szövegkerethez.
6. Adjon elegendő [Portion](https://reference.aspose.com/slides/python-net/aspose.slides/portion/) objektumot minden bekezdéshez, hogy három szakaszt tartalmazzanak. Az alapértelmezett bekezdés már tartalmaz egy üres szakaszt.
7. Állítsa be minden szakasz szövegét.
8. Alkalmazzon karakter szintű formázást a [Portion.portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/portion/portion_format/) segítségével.
9. Mentse a módosított prezentációt.

Ez a Python példa megvalósítja a lépéseket:

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

A pontok és a számozás megkönnyíti a kapcsolódó elemek átláthatóságát. Az Aspose.Slides-ben a lista beállításait a [BulletFormat](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/) határozza meg.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) osztályból.
2. Érje el a megfelelő diát az indexén keresztül.
3. Adj egy [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) a kiválasztott diához.
4. Érje el az alakzat [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/)-jét.
5. Távolítsa el az alapértelmezett bekezdést a szövegkeretből.
6. Hozzon létre egy [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) egy szimbólum pontozáshoz.
7. Állítsa be a [BulletFormat.type](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/type/) értékét [BulletType.SYMBOL](https://reference.aspose.com/slides/python-net/aspose.slides/bullettype/)‑ra, és adja meg a pont karaktert.
8. Állítsa be a bekezdés szövegét, a behúzást, a pont színét és a pont magasságát.
9. Adja hozzá a bekezdést a szövegkerethez.
10. Hozzon létre egy második bekezdést, és állítsa be a [BulletFormat.type](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/type/) értékét [BulletType.NUMBERED](https://reference.aspose.com/slides/python-net/aspose.slides/bullettype/)‑ra.
11. Állítsa be a számozott pont stílusát, és adja hozzá a bekezdést a szövegkerethez.
12. Mentse a prezentációt.

Ez a Python példa egy szimbólum pontot és egy számozott pontot hoz létre:

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

### **Képpontok használata**

A képpontok lehetővé teszik egy egyéni kép használatát a szimbólum vagy szám helyett.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) osztályból.
2. Érje el a megfelelő diát az indexén keresztül.
3. Adj egy [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) és érje el annak [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/)-jét.
4. Távolítsa el az alapértelmezett bekezdést a szövegkeretből.
5. Töltsön be egy pontképet, és adja hozzá a prezentáció képgyűjteményéhez [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/)‑ként.
6. Hozzon létre egy [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) elemet, és állítsa be a szövegét.
7. Állítsa be a [BulletFormat.type](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/type/) értékét [BulletType.PICTURE](https://reference.aspose.com/slides/python-net/aspose.slides/bullettype/)‑ra.
8. Rendelje hozzá a képet a [BulletFormat.picture](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/picture/) segítségével, és állítsa be a pont magasságát.
9. Adja hozzá a bekezdést a szövegkerethez.
10. Mentse a módosított prezentációt.

Ez a Python példa egy képpontot hoz létre:

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

Állítsa be a [ParagraphFormat.depth](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/depth/) értékét, hogy a bekezdéseket a lista különböző szintjeire helyezze. A legfelső szint mélysége `0`.

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑t, és érje el egy diát.
2. Adj egy [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/)‑t, és törölje az alapértelmezett bekezdést a szövegkeretből.
3. Hozzon létre négy bekezdést, és állítsa be azok pontszimbólumait.
4. Állítsa be a [ParagraphFormat.depth](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/depth/) értékét `0`, `1`, `2` és `3`‑ra.
5. Adja hozzá a bekezdéseket a szövegkerethez, és mentse a prezentációt.

Ez a Python példa egy négyszintű pontozott listát hoz létre:

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

### **Számozott listaelemek egyéni kezdő értékkel**

A [BulletFormat.numbered_bullet_start_with](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/numbered_bullet_start_with/) segítségével állítható be a számozott bekezdés kezdeti száma.

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑t, és adj egy [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/)‑t egy diához.
2. Törölje az alapértelmezett bekezdést az alakzat szövegkeretéből.
3. Hozzon létre három számozott bekezdést.
4. Állítsa be a [BulletFormat.numbered_bullet_start_with](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/numbered_bullet_start_with/) értékét `2`, `3` és `7`‑re a megfelelő bekezdéseknél.
5. Adja hozzá a bekezdéseket a szövegkerethez, és mentse a prezentációt.

Ez a Python példa minden bekezdéshez egy egyéni kezdő számot rendel:

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

## **Bekezdés elrendezésének és befejező tulajdonságainak vezérlése**

### **Első sor behúzás beállítása**

Használja a [ParagraphFormat.indent](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/indent/) tulajdonságot egy bekezdés első sorának behúzásához. Ez a tulajdonság csak az első sort mozdítja el a bekezdés bal margójához képest. A pozitív érték jobbra tolja az első sort, míg a többi sor a bekezdés törzséhez igazodik.

Használja a [ParagraphFormat.margin_left](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/margin_left/)‑t, ha az egész bekezdést szeretné elmozdítani. Használja a [ParagraphFormat.indent](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/indent/)‑t, ha csak az első sort akarja eltolni.

Az alábbi példa több bekezdést hoz létre, és különböző [ParagraphFormat.indent](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/indent/) értékeket alkalmaz, hogy bemutassa, hogyan befolyásolja az első sor behúzása a bekezdés elrendezését.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) osztályból.
2. Érje el a céldiát.
3. Adj egy téglalap alakú [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/)‑t a diára.
4. Érje el az alakzat [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/)‑jét, és távolítsa el az alapértelmezett bekezdést.
5. Hozzon létre több bekezdést, és különböző [ParagraphFormat.indent](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/indent/) értékeket állítson be számukra.
6. Adja hozzá a bekezdéseket a szövegkerethez.
7. Mentse a módosított prezentációt.

Ez a kód megmutatja, hogyan állíthat be bekezdésbehúzást:

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

![Az első sor behúzása a bekezdéseknél](first_line_indent.png)

### **Függő behúzás beállítása**

A függő behúzás egy olyan bekezdéselrendezés, ahol az első sor balra indul a többi sorhoz képest. Az Aspose.Slides-ben ezt a hatást a [ParagraphFormat.indent](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/indent/) segítségével hozhatja létre. Állítsa az `indent`‑et negatív értékre, hogy az első sort balra mozgassa a bekezdéstörzshez képest.

Gyakorlatilag a [ParagraphFormat.margin_left](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/margin_left/) határozza meg a bekezdéstörzs bal pozícióját, a [ParagraphFormat.indent](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/indent/) pedig az első sor helyzetét ehhez a margóhoz képest. A függő behúzás létrehozásához állítson be pozitív `margin_left` értéket, és negatív `indent` értéket.

Ez a formázás hasznos bibliográfiákhoz, hivatkozásokhoz, szójegyzékekhez és egyéb bekezdésekhez, ahol a sortöréses soroknak a bekezdéstörzs alatt kell igazodniuk, nem az első sor első karaktere alatt.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) osztályból.
2. Érje el a céldiát.
3. Adj egy téglalap alakú [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/)‑t a diára.
4. Érje el az alakzat [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/)‑jét, és távolítsa el az alapértelmezett bekezdést.
5. Hozzon létre bekezdéseket, és állítson be minden bekezdéshez egy pozitív [ParagraphFormat.margin_left](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/margin_left/) értéket.
6. Állítson be egy negatív [ParagraphFormat.indent](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/indent/) értéket a függő behúzás hatásának létrehozásához.
7. Adja hozzá a bekezdéseket a szövegkerethez.
8. Mentse a módosított prezentációt.

Ez a kód megmutatja, hogyan állíthat be függő behúzást egy bekezdéshez:

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

### **A bekezdés befejező szakaszának tulajdonságainak beállítása**

A [Paragraph.end_paragraph_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/end_paragraph_portion_format/) tulajdonság szabályozza a bekezdés végejele formázását. Az alábbi példa betűméretet és latin betűtípust rendel a második bekezdés végejeléhez:

1. Töltsön be egy [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑t, és érje el egy diát.
2. Adj egy [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/)‑t, és törölje az alapértelmezett bekezdést.
3. Hozzon létre két bekezdést, és adjon hozzá szövegszakaszokat.
4. Hozzon létre egy [PortionFormat](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/)‑t a második bekezdés végejeléhez.
5. Állítsa be a [PortionFormat.font_height](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/font_height/) és a [PortionFormat.latin_font](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/latin_font/) értékeket.
6. Rendelje hozzá a formátumot a [Paragraph.end_paragraph_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/end_paragraph_portion_format/) tulajdonsághoz, majd mentse a prezentációt.

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

## **Megjelenített sorok számolása**

A bekezdés szabályai, melyek az automatikus sortörést és a sorvégi írásjelek kezelését befolyásolják, a [Sorok törésének vezérlése](/slides/hu/python-net/text-formatting/#control-line-breaking) és a [Függő elválasztás vezérlése](/slides/hu/python-net/text-formatting/#control-hanging-punctuation) szekciókban találhatók.

Használja a [Paragraph.get_lines_count](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_lines_count/)‑t a bekezdés által elfoglalt sorok számának meghatározásához a szöveg elrendezése után, beleértve az automatikus sortörést. Ez hasznos a szöveghossz és az elrendezés ellenőrzéséhez prezentációs sablonokban.

Egy bekezdés egy elem a [TextFrame.paragraphs](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/paragraphs/) gyűjteményben, és több megjelenített sort is elfoglalhat. Egy explicites sortörés egy bekezdésen belül új sort hoz létre anélkül, hogy újabb bekezdést generálna. Az automatikus sortörés a rendelkezésre álló szélesség alapján hoz létre sorokat, anélkül hogy explicit sortöréseket szúrna be a szövegbe. Így a bekezdések vagy sortörő karakterek számlálása nem adja meg a megjelenített sorok számát.

Az alábbi példa egy szöveges alakzatot hoz létre, megszámolja a sorait, szűkíti az alakzatot, majd rövidebb karakterláncra cseréli a szöveget. A sortörés engedélyezett, az automatikus illeszkedés (autofit) le van tiltva, így az alakzat szélessége szabályozza a sortörést anélkül, hogy a szöveg automatikusan zsugorodna vagy az alakzat átméreteződne. Az alakzat méretei pontokban vannak megadva. Végül a példa egy további bekezdést ad hozzá, és összeadja a sorok számát az egész szövegkeretben.

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

Ezzel a szöveggel és ezekkel a méretekkel a forma szűkítése növeli a sorok számát, míg a szöveg rövidebb változatra cserélése csökkenti azt. A pontos számok betűtípus‑elérhetőségtől és helyettesítéstől, betűmérettől, margóktól, behúzástól, sortöréstől és az automatikus illeszkedés beállításaitól függően változhatnak. Használja a célkörnyezetben tervezett betűtípusokat és elrendezési beállításokat a sablon ellenőrzésekor.

A sorok száma önmagában nem határozza meg, hogy a szöveg túlnyúlik‑e a tárolóján. A rendelkezésre álló magasság, a sorközök, a bekezdés‑ és sorköz‑beállítások, valamint az automatikus illeszkedés viselkedése is számít; még egyetlen sor is meghaladhatja a rendelkezésre álló szélességet, ha a sortörés ki van kapcsolva.

## **Bekezdés tartalmának importálása és exportálása**

### **HTML-szöveg importálása bekezdésekbe**

Használja a [ParagraphCollection.add_from_html](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphcollection/add_from_html/)‑t HTML‑jelölők bekezdésekké és szakaszokká konvertálásához egy szövegkeretben.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) osztályból.
2. Érje el egy diát, és adj egy [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/)‑t.
3. Érje el az alakzat [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/)‑jét, és törölje az alapértelmezett bekezdést.
4. Olvassa be a forrás‑HTML fájlt.
5. Adja át az HTML‑sztringet a [ParagraphCollection.add_from_html](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphcollection/add_from_html/)‑nek.
6. Mentse a módosított prezentációt.

Ez a Python példa HTML‑t importál egy szövegkeretbe:

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

### **Bekezdés szövegének exportálása HTML‑be**

Használja a [ParagraphCollection.export_to_html](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphcollection/export_to_html/)‑t, hogy egy kiválasztott bekezdéstartományt HTML‑ként exportálja.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) osztályból, és töltse be a kívánt prezentációt.
2. Érje el a diát, és keresse meg azt az [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/)‑t, amelyik a szöveget tartalmazza.
3. Érje el az alakzat [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/)-jét.
4. Hívja meg a [ParagraphCollection.export_to_html](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphcollection/export_to_html/)‑t a kezdő bekezdés indexével és az exportálandó bekezdések számával.
5. Írja a visszakapott HTML‑sztringet egy fájlba.

Ez a Python példa az első szövegalakzat összes bekezdését exportálja:

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

A [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) a `get_image` metódust biztosítja egy egyedi bekezdés közvetlen rendereléséhez. A metódus egy [IImage](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/) objektumot ad vissza, amelyet fájlba vagy adatfolyamba menthet a [IImage.save](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/save/)‑nel. Nem szükséges a tartalmazó alakzatot renderelni, vagy bitmapet manuálisan vágni.

A `get_image` metódus `None`‑t adhat vissza, ha a bekezdés nem található a szülőgyűjteményben, nincs érvényes renderelési határa, vagy nem renderelhető. Ellenőrizze az eredményt a mentés előtt, és használja a visszakapott képet kontextuskezelőként a forrás felszabadításához.

#### **Bekezdés renderelése alapértelmezett méretezésben**

Tegyük fel, hogy van egy sample.pptx nevű prezentációs fájlunk, amely egy diát tartalmaz, ahol az első alakzat egy három bekezdést tartalmazó szövegdoboz.

![A három bekezdést tartalmazó szövegdoboz](paragraph_to_image_input.png)

Az alábbi példa a második bekezdést rendereli egy szabályos szövegalakzatban alapértelmezett méretezésben, és PNG formátumban menti a visszakapott képet:

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

Adjunk meg vízszintes és függőleges skálázási tényezőket a `get_image`‑nek a renderelt bekezdés méretének vezérléséhez. Az alábbi példa táblázatot hoz létre, a bekezdést az első cellájában kétszeres szélesség és magasság mellett rendereli, és PNG képként menti az eredményt:

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

Az `1`‑es skálázási tényező az adott tengelyen az alapértelmezett képpontméretet tartja. Például a `2` mindkét tényezőnél egy képet eredményez, amelynek szélessége és magassága megközelítőleg kétszerese az alapértelmezett méreteknek, így négyszeres a pixel szám. A nagyobb tényezők általában élesebb szöveget eredményeznek nagyítás vagy nagy felbontású kimenet esetén, de növelik a memóriahasználatot és a fájlméretet. Az `1`‑nél kisebb tényezők kisebb, kevésbé részletes képet adnak. Használjon egyenlő tényezőket a bekezdés méretarányának megtartásához; a különböző vízszintes és függőleges tényezők a kimenetet egyedülállóan nyújtják.

Egy egész alakzat renderelése a [Shape.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/shape/get_image/)‑nel továbbra is hasznos, ha a kimenetnek tartalmaznia kell az alakzat kitöltését, szegélyét vagy egyéb vizuális környezetét. Egy kizárólag bekezdést tartalmazó képhez használja a `Paragraph.get_image`‑et.

## **GYIK**

**Letiltathatom teljesen a sortörést egy szövegkereten belül?**

Igen. Állítsa be a [TextFrameFormat.wrap_text](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/wrap_text/)‑t a sortörés letiltásához, így a sorok nem törnek meg a szövegkeret szélén.

**Hogyan szerezhetem meg egy adott bekezdés pontos diákon belüli határait?**

Használja a [Paragraph.get_rect](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_rect/) metódust a bekezdés körülhatároló téglalap lekéréséhez. A [Portion.get_rect](https://reference.aspose.com/slides/python-net/aspose.slides/portion/get_rect/) egy adott szakasz határait adja.

**Hol van szabályozva a bekezdés igazítása (bal, jobb, közép vagy sorkizárt)?**

A [ParagraphFormat.alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/) bekezdés‑szintű beállítás, amely a teljes bekezdésre vonatkozik, függetlenül az egyes szakaszok formázásától.

A különböző betűméretű szakaszok függőleges igazításához egy sorban lásd a [Betűtípusok függőleges igazítása soron belül](/slides/hu/python-net/text-formatting/#align-fonts-within-a-line) szekciót.

**Beállíthatom a helyesírási nyelvet egy bekezdés egy részén?**

Igen. Állítsa be a [PortionFormat.language_id](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/language_id/) értékét az egyes szakaszokra, így egy bekezdés több nyelven is tartalmazhat szöveget.