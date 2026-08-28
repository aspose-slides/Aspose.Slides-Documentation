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
- felsorolásjel kezelése
- bekezdés behúzás
- akasztott behúzás
- bekezdés pont
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
- Aspose.Slides
description: "Ismerje meg, hogyan hozhat létre és formázhat bekezdéseket, szakaszokat, felsorolásjeleket, számozott listákat, behúzásokat, HTML-tartalmat és bekezdés képeket az Aspose.Slides for Python via .NET segítségével."
---
## **Áttekintés**

Az Aspose.Slides for Python via .NET a szöveget szövegkeretek, bekezdések és szakaszok hierarchiájában ábrázolja:

* [TextFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframe/) a szövegtároló egy alakzatban, és hozzáférést biztosít a bekezdésgyűjteményéhez.
* [Paragraph](https://reference.aspose.com/slides/hu/python-net/aspose.slides/paragraph/) egy bekezdést jelöl egy szövegkeretben, és hozzáférést biztosít a szakaszaihoz és a bekezdés‑szintű formázáshoz.
* [Portion](https://reference.aspose.com/slides/hu/python-net/aspose.slides/portion/) egy szövegrészt jelöl egy bekezdésen belül. Minden szakasz saját szöveggel és karakter‑szintű formázással rendelkezhet.

Egy bekezdés tehát több szakasz használatával tartalmazhat különböző betűtípusú, színű, méretű és egyéb formázású szöveget.

## **Bekezdések létrehozása és formázása**

### **Bekezdések létrehozása több szakaszzal**

Az alábbi lépések egy szövegkeretet hoznak létre három bekezdéssel, mindegyik három szakaszt tartalmazva:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztályból.
2. Hozzáférés a megfelelő diára az indexén keresztül.
3. Adjunk hozzá egy téglalap alakú [AutoShape](https://reference.aspose.com/slides/hu/python-net/aspose.slides/autoshape/) elemet a diára.
4. Hozzáférés az alakzat [TextFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframe/) eleméhez.
5. Használja az alapértelmezett bekezdést, és adjon hozzá még két [Paragraph](https://reference.aspose.com/slides/hu/python-net/aspose.slides/paragraph/) objektumot a szövegkerethez.
6. Adjon elegendő [Portion](https://reference.aspose.com/slides/hu/python-net/aspose.slides/portion/) objektumot minden bekezdéshez, hogy három szakaszt tartalmazzon. Az alapértelmezett bekezdés már tartalmaz egy üres szakaszt.
7. Állítsa be minden szakasz szövegét.
8. Alkalmazzon karakter‑szintű formázást a [Portion.portion_format](https://reference.aspose.com/slides/hu/python-net/aspose.slides/portion/portion_format/) segítségével.
9. Mentse a módosított prezentációt.

Ez a Python‑példa megvalósítja a lépéseket:

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

## **Felsorolásos és számozott listák létrehozása**

### **Felsorolás vagy számozott lista létrehozása**

A pontok és a számozás segít a kapcsolódó elemek gyors áttekintésében. Az Aspose.Slides‑ben a lista beállításait a [BulletFormat](https://reference.aspose.com/slides/hu/python-net/aspose.slides/bulletformat/) határozza meg.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztályból.
2. Hozzáférés a megfelelő diára az indexén keresztül.
3. Adjunk hozzá egy [AutoShape](https://reference.aspose.com/slides/hu/python-net/aspose.slides/autoshape/) elemet a kiválasztott diához.
4. Hozzáférés az alakzat [TextFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframe/) eleméhez.
5. Távolítsa el az alapértelmezett bekezdést a szövegkeretből.
6. Hozzon létre egy [Paragraph](https://reference.aspose.com/slides/hu/python-net/aspose.slides/paragraph/) elemet egy szimbólum‑ponthoz.
7. Állítsa be a [BulletFormat.type](https://reference.aspose.com/slides/hu/python-net/aspose.slides/bulletformat/type/) értékét [BulletType.SYMBOL](https://reference.aspose.com/slides/hu/python-net/aspose.slides/bullettype/)‑ra, és adja meg a pont karakterét.
8. Állítsa be a bekezdés szövegét, behúzását, a pont színét és magasságát.
9. Adja hozzá a bekezdést a szövegkerethez.
10. Hozzon létre egy második bekezdést, és állítsa be a [BulletFormat.type](https://reference.aspose.com/slides/hu/python-net/aspose.slides/bulletformat/type/) értékét [BulletType.NUMBERED](https://reference.aspose.com/slides/hu/python-net/aspose.slides/bullettype/)‑ra.
11. Konfigurálja a számozott pont stílusát, majd adja hozzá a bekezdést a szövegkerethez.
12. Mentse a prezentációt.

Ez a Python‑példa szimbólum‑pontot és számozott pontot hoz létre:

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

### **Kép‑pontok használata**

A kép‑pontok lehetővé teszik egy egyéni kép használatát a szimbólum vagy szám helyett.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztályból.
2. Hozzáférés a megfelelő diára az indexén keresztül.
3. Adjunk hozzá egy [AutoShape](https://reference.aspose.com/slides/hu/python-net/aspose.slides/autoshape/) elemet, és férjünk hozzá a [TextFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframe/) eleméhez.
4. Távolítsa el az alapértelmezett bekezdést a szövegkeretből.
5. Töltse be a pontképet, és adja hozzá a prezentáció képgyűjteményéhez [PPImage](https://reference.aspose.com/slides/hu/python-net/aspose.slides/ppimage/)‑ként.
6. Hozzon létre egy [Paragraph](https://reference.aspose.com/slides/hu/python-net/aspose.slides/paragraph/) elemet, és állítsa be a szövegét.
7. Állítsa be a [BulletFormat.type](https://reference.aspose.com/slides/hu/python-net/aspose.slides/bulletformat/type/) értékét [BulletType.PICTURE](https://reference.aspose.com/slides/hu/python-net/aspose.slides/bullettype/)‑ra.
8. Rendelje hozzá a képet a [BulletFormat.picture](https://reference.aspose.com/slides/hu/python-net/aspose.slides/bulletformat/picture/) segítségével, és állítsa be a pont magasságát.
9. Adja hozzá a bekezdést a szövegkerethez.
10. Mentse a módosított prezentációt.

Ez a Python‑példa kép‑pontot hoz létre:

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

Állítsa be a [ParagraphFormat.depth](https://reference.aspose.com/slides/hu/python-net/aspose.slides/paragraphformat/depth/) értékét, hogy a bekezdéseket a lista különböző szintjein helyezze el. A legfelső szint mélysége `0`.

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) elemet, és nyisson meg egy diát.
2. Adjunk hozzá egy [AutoShape](https://reference.aspose.com/slides/hu/python-net/aspose.slides/autoshape/) elemet, és törölje az alapértelmezett bekezdést a szövegkeretből.
3. Hozzon létre négy bekezdést, és állítsa be a pontszimbólumaikat.
4. Állítsa be a [ParagraphFormat.depth](https://reference.aspose.com/slides/hu/python-net/aspose.slides/paragraphformat/depth/) értékét `0`, `1`, `2` és `3`‑ra.
5. Adja hozzá a bekezdéseket a szövegkerethez, majd mentse a prezentációt.

Ez a Python‑példa négy szintű pontozott listát hoz létre:

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

### **Számozott listaelemek egyedi kezdőértékkel**

A [BulletFormat.numbered_bullet_start_with](https://reference.aspose.com/slides/hu/python-net/aspose.slides/bulletformat/numbered_bullet_start_with/) beállítással meghatározható a számozott bekezdés kezdeti száma.

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) elemet, és adjunk hozzá egy [AutoShape](https://reference.aspose.com/slides/hu/python-net/aspose.slides/autoshape/) elemet egy diához.
2. Törölje az alapértelmezett bekezdést az alakzat szövegkeretéből.
3. Hozzon létre három számozott bekezdést.
4. Állítsa be a [BulletFormat.numbered_bullet_start_with](https://reference.aspose.com/slides/hu/python-net/aspose.slides/bulletformat/numbered_bullet_start_with/) értékét `2`, `3` és `7`‑re a megfelelő bekezdésekhez.
5. Adja hozzá a bekezdéseket a szövegkerethez, majd mentse a prezentációt.

Ez a Python‑példa egyedi kezdőszámot rendel minden bekezdéshez:

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

## **Bekezdés elrendezésének és vége tulajdonságainak vezérlése**

### **Első sor behúzásának beállítása**

Használja a [ParagraphFormat.indent](https://reference.aspose.com/slides/hu/python-net/aspose.slides/paragraphformat/indent/) tulajdonságot a bekezdés első sorának behúzásához. Ez a tulajdonság csak az első sort mozdítja el a bekezdés bal margójához képest. Egy pozitív érték jobbra tolják az első sort, míg a többi sor a bekezdés törzséhez igazodik.

A teljes bekezdés elmozdításához használja a [ParagraphFormat.margin_left](https://reference.aspose.com/slides/hu/python-net/aspose.slides/paragraphformat/margin_left/)‑t. Ha csak az első sort szeretné elmozdítani, használja a [ParagraphFormat.indent](https://reference.aspose.com/slides/hu/python-net/aspose.slides/paragraphformat/indent/)‑et.

Az alábbi példa több bekezdést hoz létre, és különböző [ParagraphFormat.indent](https://reference.aspose.com/slides/hu/python-net/aspose.slides/paragraphformat/indent/) értékeket alkalmaz, hogy bemutassa, miként befolyásolja az első sor behúzása a bekezdés elrendezését.

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) példányt.
2. Nyissa meg a cél diát.
3. Adjunk hozzá egy téglalap [AutoShape](https://reference.aspose.com/slides/hu/python-net/aspose.slides/autoshape/) elemet a diához.
4. Hozzáférés az alakzat [TextFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframe/) eleméhez, és távolítsa el az alapértelmezett bekezdést.
5. Hozzon létre több bekezdést, és állítson be különböző [ParagraphFormat.indent](https://reference.aspose.com/slides/hu/python-net/aspose.slides/paragraphformat/indent/) értékeket számukra.
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

![A bekezdések első sorának behúzása](first_line_indent.png)

### **Akasztott behúzás beállítása**

Az akasztott behúzás egy olyan bekezdéselrendezés, ahol az első sor balra indul a többi sorhoz képest. Az Aspose.Slides‑ben ezt a hatást a [ParagraphFormat.indent](https://reference.aspose.com/slides/hu/python-net/aspose.slides/paragraphformat/indent/) tulajdonsággal hozhatja létre. Állítsa az `indent` értékét negatívra, hogy az első sort balra mozdítsa a bekezdéstörzshöz képest.

Gyakorlatban a [ParagraphFormat.margin_left](https://reference.aspose.com/slides/hu/python-net/aspose.slides/paragraphformat/margin_left/) határozza meg a bekezdés törzs bal pozícióját, míg a [ParagraphFormat.indent](https://reference.aspose.com/slides/hu/python-net/aspose.slides/paragraphformat/indent/) az első sor helyzetét ezen a margón belül. Akasztott behúzás létrehozásához adjon meg egy pozitív `margin_left` értéket, és egy negatív `indent` értéket.

Ez a formázás hasznos bibliográfiák, hivatkozások, szószedeti bejegyzések és egyéb bekezdések esetén, ahol a tördelődő soroknak a bekezdés törzse alá kell illeszkedniük, nem pedig az első sor első karaktere alá.

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) példányt.
2. Nyissa meg a cél diát.
3. Adjunk hozzá egy téglalap [AutoShape](https://reference.aspose.com/slides/hu/python-net/aspose.slides/autoshape/) elemet a diához.
4. Hozzáférés az alakzat [TextFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframe/) eleméhez, és távolítsa el az alapértelmezett bekezdést.
5. Hozzon létre bekezdéseket, és állítson be egy pozitív [ParagraphFormat.margin_left](https://reference.aspose.com/slides/hu/python-net/aspose.slides/paragraphformat/margin_left/) értéket minden bekezdéshez.
6. Állítson be egy negatív [ParagraphFormat.indent](https://reference.aspose.com/slides/hu/python-net/aspose.slides/paragraphformat/indent/) értéket az akasztott behúzás létrehozásához.
7. Adja hozzá a bekezdéseket a szövegkerethez.
8. Mentse a módosított prezentációt.

Ez a kód megmutatja, hogyan állíthat be akasztott behúzást egy bekezdéshez:

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

![A bekezdések akasztott behúzása](hanging_indent.png)

### **A bekezdés végének formázási tulajdonságainak beállítása**

A [Paragraph.end_paragraph_portion_format](https://reference.aspose.com/slides/hu/python-net/aspose.slides/paragraph/end_paragraph_portion_format/) tulajdonság szabályozza a bekezdés végjelének formázását. Az alábbi példa betűméretet és latin betűtípust rendel a második bekezdés végjeléhez:

1. Töltsön be egy [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) elemet, és nyissa meg egy diát.
2. Adjunk hozzá egy [AutoShape](https://reference.aspose.com/slides/hu/python-net/aspose.slides/autoshape/) elemet, és törölje az alapértelmezett bekezdést.
3. Hozzon létre két bekezdést, és adjon hozzá szövegszakaszokat.
4. Hozzon létre egy [PortionFormat](https://reference.aspose.com/slides/hu/python-net/aspose.slides/portionformat/) elemet a második bekezdés végjeléhez.
5. Állítsa be a [PortionFormat.font_height](https://reference.aspose.com/slides/hu/python-net/aspose.slides/portionformat/font_height/) és a [PortionFormat.latin_font](https://reference.aspose.com/slides/hu/python-net/aspose.slides/portionformat/latin_font/) értékeket.
6. Rendelje hozzá a formátumot a [Paragraph.end_paragraph_portion_format](https://reference.aspose.com/slides/hu/python-net/aspose.slides/paragraph/end_paragraph_portion_format/) tulajdonsághoz, majd mentse a prezentációt.

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

## **Bekezdés tartalmának importálása és exportálása**

### **HTML‑szöveg importálása bekezdésekbe**

A [ParagraphCollection.add_from_html](https://reference.aspose.com/slides/hu/python-net/aspose.slides/paragraphcollection/add_from_html/) segítségével HTML‑jelölést alakíthat bekezdésekké és szakaszókká egy szövegkeretben.

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) példányt.
2. Nyisson meg egy diát, és adjunk hozzá egy [AutoShape](https://reference.aspose.com/slides/hu/python-net/aspose.slides/autoshape/) elemet.
3. Hozzáférés az alakzat [TextFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframe/) eleméhez, és törölje az alapértelmezett bekezdést.
4. Olvassa be a forrás‑HTML‑fájlt.
5. Adja át az HTML‑sztringet a [ParagraphCollection.add_from_html](https://reference.aspose.com/slides/hu/python-net/aspose.slides/paragraphcollection/add_from_html/) metódusnak.
6. Mentse a módosított prezentációt.

Ez a Python‑példa HTML‑t importál egy szövegkeretbe:

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

### **Bekezdésszöveg exportálása HTML‑be**

A [ParagraphCollection.export_to_html](https://reference.aspose.com/slides/hu/python-net/aspose.slides/paragraphcollection/export_to_html/) metódus segítségével egy kiválasztott bekezdéstartományt exportálhat HTML‑ként.

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) példányt, és töltse be a kívánt prezentációt.
2. Nyissa meg a diát, és keresse meg a szöveget tartalmazó [AutoShape](https://reference.aspose.com/slides/hu/python-net/aspose.slides/autoshape/) elemet.
3. Hozzáférés az alakzat [TextFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframe/) eleméhez.
4. Hívja meg a [ParagraphCollection.export_to_html](https://reference.aspose.com/slides/hu/python-net/aspose.slides/paragraphcollection/export_to_html/) metódust a kezdő bekezdés indexével és az exportálandó bekezdések számával.
5. Írja a visszaadott HTML‑sztringet egy fájlba.

Ez a Python‑példa az első szöveges alakzat összes bekezdését exportálja:

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

A [Paragraph](https://reference.aspose.com/slides/hu/python-net/aspose.slides/paragraph/) osztály biztosítja a `get_image` metódust egyetlen bekezdés közvetlen rendereléséhez. A metódus egy [IImage](https://reference.aspose.com/slides/hu/python-net/aspose.slides/iimage/) objektumot ad vissza, amelyet a [IImage.save](https://reference.aspose.com/slides/hu/python-net/aspose.slides/iimage/save/) metódussal menthet fájlba vagy stream‑be. Nem szükséges a tartalmazó alakzatot renderelni vagy a bitmapet manuálisan levágni.

A `get_image` metódus `None`‑t adhat vissza, ha a bekezdés nem található a szülőgyűjteményben, nincs érvényes renderelési határa, vagy nem renderelhető. Ellenőrizze az eredményt a mentés előtt, és használja a visszakapott képet context manager‑ként a erőforrások felszabadításához.

#### **Bekezdés renderelése alapértelmezett méretarányban**

Tegyük fel, hogy van egy *sample.pptx* nevű prezentációs fájlunk egy diával, ahol az első alakzat egy három bekezdést tartalmazó szövegdoboz.

![A szövegdoboz három bekezdéssel](paragraph_to_image_input.png)

Az alábbi példa a második bekezdést rendereli egy szabványos szöveges alakzaton alapértelmezett méretarányban, és PNG‑formátumban menti a visszakapott képet:

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

#### **Bekezdés renderelése táblázatcellában skálázással**

Adjunk meg vízszintes és függőleges méretarány‑faktorokat a `get_image` metódusnak a renderelt bekezdés méretének szabályozásához. Az alábbi példa egy táblázatot hoz létre, a bekezdést az első cellájában a kétszeres szélességben és magasságban rendereli, majd PNG‑képként menti az eredményt:

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

Az `1`‑es faktor megtartja az adott tengely alapértelmezett pixelméretét. Például a `2` mindkét tényező esetén egy képet eredményez, amelynek szélessége és magassága körülbelül kétszerese az alapértelmezettnek, így a pixelek száma négyszeres. A nagyobb tényezők általában élesebb szöveget biztosítanak nagyítás vagy nagy felbontású kimenet esetén, de növelik a memóriahasználatot és a fájlméretet. Az `1`‑nél kisebb tényezők kisebb, részletgazdagabb képet adnak. A méretarány megtartásához használjon egyenlő tényezőket; eltérő vízszintes és függőleges tényezők külön-külön nyújtják a kimenetet.

Az egész alakzat renderelése a [Shape.get_image](https://reference.aspose.com/slides/hu/python-net/aspose.slides/shape/get_image/) metódussal akkor hasznos, ha a kimenetnek tartalmaznia kell az alakzat kitöltését, szegélyét vagy egyéb vizuális kontextusát. Kizárólag bekezdés‑képekhez használja a `Paragraph.get_image`‑t.

## **GYIK**

**Teljesen le tudom tiltani a sorok megtörését egy szövegkeretben?**

Igen. Állítsa a [TextFrameFormat.wrap_text](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframeformat/wrap_text/) értékét a megtörés letiltásához, így a sorok nem törnek meg a szövegkeret szélein.

**Hogyan kaphatom meg egy adott bekezdés pontos, dián lévő határait?**

Használja a [Paragraph.get_rect](https://reference.aspose.com/slides/hu/python-net/aspose.slides/paragraph/get_rect/) metódust a bekezdés határoló téglalapjának lekéréséhez. A [Portion.get_rect](https://reference.aspose.com/slides/hu/python-net/aspose.slides/portion/get_rect/) egy adott szakasz határait adja vissza.

**Hol van szabályozva a bekezdés igazítása (balra, jobbra, középre vagy sorkizárt)?**

A [ParagraphFormat.alignment](https://reference.aspose.com/slides/hu/python-net/aspose.slides/paragraphformat/alignment/) egy bekezdés‑szintű beállítás, amely a teljes bekezdésre vonatkozik, függetlenül az egyes szakaszok formázásától.

**Be tudok-e állítani nyelvellenőrzési nyelvet a bekezdés egy részére?**

Igen. Állítsa be a [PortionFormat.language_id](https://reference.aspose.com/slides/hu/python-net/aspose.slides/portionformat/language_id/) értékét az egyes szakaszoknál, így egy bekezdés több nyelven is tartalmazhat szöveget.