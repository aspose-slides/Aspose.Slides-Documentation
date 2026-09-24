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
- bekezdés behúzás
- függő behúzás
- bekezdés pont
- számozott lista
- pontozott lista
- bekezdés tulajdonságok
- HTML importálás
- szöveg HTML-re
- bekezdés HTML-re
- bekezdés képre
- szöveg képre
- bekezdés exportálása
- PowerPoint
- prezentáció
- Python
- Aspose.Slides
description: "Ismerje meg, hogyan hozhat létre és formázhat bekezdéseket, szakaszokat, pontozásokat, számozott listákat, behúzásokat, HTML tartalmakat és bekezdés képeket az Aspose.Slides for Python via .NET segítségével."
---
## **Áttekintés**

Aspose.Slides for Python via .NET a szöveget szövegdobozok, bekezdések és szakaszok hierarchiájaként reprezentálja:

* [TextFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframe/) egy alakzat szövegkonténerét képviseli, és hozzáférést biztosít a bekezdésgyűjteményéhez.
* [Paragraph](https://reference.aspose.com/slides/hu/python-net/aspose.slides/paragraph/) egy szövegdobozban lévő bekezdést képvisel, és hozzáférést biztosít a szakaszaihoz és a bekezdés szintű formázáshoz.
* [Portion](https://reference.aspose.com/slides/hu/python-net/aspose.slides/portion/) egy szövegrészt képvisel egy bekezdésen belül. Minden szakasz saját szöveggel és karakter szintű formázással rendelkezhet.

Ezáltal egy bekezdés különböző betűtípusú, színű, méretű és egyéb formázású szöveget tartalmazhat több szakasz használatával.

## **Bekezdések létrehozása és formázása**

### **Bekezdések létrehozása több szakaszzal**

A következő lépések egy szövegdobozt hoznak létre három bekezdéssel, amelyek mindegyike három szakaszt tartalmaz:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztályból.
2. Érje el a megfelelő diát az indexén keresztül.
3. Adjon hozzá egy téglalap alakú [AutoShape](https://reference.aspose.com/slides/hu/python-net/aspose.slides/autoshape/) elemet a diára.
4. Érje el az alakzat [TextFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframe/) elemét.
5. Használja az alapértelmezett bekezdést, és adjon hozzá további két [Paragraph](https://reference.aspose.com/slides/hu/python-net/aspose.slides/paragraph/) objektumot a szövegdobozhoz.
6. Adjon hozzá elegendő [Portion](https://reference.aspose.com/slides/hu/python-net/aspose.slides/portion/) objektumot minden bekezdéshez, hogy három szakaszt tartalmazzon. Az alapértelmezett bekezdés már egy üres szakaszt tartalmaz.
7. Állítsa be minden szakasz szövegét.
8. Alkalmazzon karakter szintű formázást a [Portion.portion_format](https://reference.aspose.com/slides/hu/python-net/aspose.slides/portion/portion_format/) segítségével.
9. Mentse a módosított bemutatót.

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

A pontok és a számozás megkönnyítik a kapcsolódó elemek átlapozását. Az Aspose.Slides-ben a lista beállításait a [BulletFormat](https://reference.aspose.com/slides/hu/python-net/aspose.slides/bulletformat/) határozza meg.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztályból.
2. Érje el a megfelelő diát az indexén keresztül.
3. Adjon hozzá egy [AutoShape](https://reference.aspose.com/slides/hu/python-net/aspose.slides/autoshape/) elemet a kiválasztott diához.
4. Érje el az alakzat [TextFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframe/) elemét.
5. Távolítsa el az alapértelmezett bekezdést a szövegdobozból.
6. Hozzon létre egy [Paragraph](https://reference.aspose.com/slides/hu/python-net/aspose.slides/paragraph/) elemet egy szimbólum pontozáshoz.
7. Állítsa a [BulletFormat.type] értékét [BulletType.SYMBOL]‑ra, és adja meg a pont karakterét.
8. Állítsa be a bekezdés szövegét, behúzását, a pont színét és magasságát.
9. Adja hozzá a bekezdést a szövegdobozhoz.
10. Hozzon létre egy második bekezdést, és állítsa a [BulletFormat.type] értékét [BulletType.NUMBERED]‑ra.
11. Állítsa be a számozott pont stílusát, és adja hozzá a bekezdést a szövegdobozhoz.
12. Mentse a bemutatót.

Ez a Python példa szimbólum pontot és számozott pontot hoz létre:

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

### **Képes pontok használata**

A képes pontok lehetővé teszik egy egyedi kép használatát szimbólum vagy szám helyett.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztályból.
2. Érje el a megfelelő diát az indexén keresztül.
3. Adjon hozzá egy [AutoShape](https://reference.aspose.com/slides/hu/python-net/aspose.slides/autoshape/) elemet, és érje el annak [TextFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframe/) elemét.
4. Távolítsa el az alapértelmezett bekezdést a szövegdobozból.
5. Töltsa be a pont képet, és adja hozzá a bemutató képgyűjteményéhez [PPImage] formájában.
6. Hozzon létre egy [Paragraph](https://reference.aspose.com/slides/hu/python-net/aspose.slides/paragraph/) elemet, és állítsa be a szövegét.
7. Állítsa a [BulletFormat.type] értékét [BulletType.PICTURE]‑ra.
8. Rendelje hozzá a képet a [BulletFormat.picture] segítségével, és állítsa be a pont magasságát.
9. Adja hozzá a bekezdést a szövegdobozhoz.
10. Mentse a módosított bemutatót.

Ez a Python példa képes pontot hoz létre:

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

Állítsa be a [ParagraphFormat.depth] értékét, hogy a bekezdéseket a lista különböző szintjeire helyezze. A legfelső szint mélysége `0`.

1. Hozzon létre egy [Presentation] objektumot, és érje el egy diát.
2. Adjon hozzá egy [AutoShape] elemet, és törölje az alapértelmezett bekezdést a szövegdobozából.
3. Hozzon létre négy bekezdést, és állítsa be a pont szimbólumaikat.
4. Állítsa be a [ParagraphFormat.depth] értéküket `0`, `1`, `2` és `3`‑ra.
5. Adja hozzá a bekezdéseket a szövegdobozhoz, majd mentse a bemutatót.

Ez a Python példa négy szintű pontozott listát hoz létre:

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

### **Számozott listaelemek indítása egyéni értékekkel**

Használja a [BulletFormat.numbered_bullet_start_with] beállítást, hogy megadja a számozott bekezdés kezdeti számát.

1. Hozzon létre egy [Presentation] objektumot, és adjon hozzá egy [AutoShape] elemet egy diához.
2. Törölje az alapértelmezett bekezdést az alakzat szövegdobozából.
3. Hozzon létre három számozott bekezdést.
4. Állítsa a [BulletFormat.numbered_bullet_start_with] értékét a megfelelő bekezdésekhez `2`, `3` és `7`‑re.
5. Adja hozzá a bekezdéseket a szövegdobozhoz, majd mentse a bemutatót.

Ez a Python példa egyedi kezdőszámot rendel minden bekezdéshez:

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

### **Első sor behúzás beállítása**

Használja a [ParagraphFormat.indent] tulajdonságot a bekezdés első sorának behúzásának vezérléséhez. Ez a tulajdonság csak az első sort mozgatja a bekezdés bal margójához képest. A pozitív érték jobbra tolja az első sort, míg a többi sor a bekezdés törzséhez igazodik.

Használja a [ParagraphFormat.margin_left]‑t, ha az egész bekezdést szeretné mozgatni. Használja a [ParagraphFormat.indent]‑t, ha csak az első sort akarja eltolni.

Az alábbi példa több bekezdést hoz létre, és különböző [ParagraphFormat.indent] értékeket alkalmaz, hogy bemutassa, hogyan befolyásolja az első sor behúzása a bekezdés elrendezését.

1. Hozzon létre egy példányt a [Presentation] osztályból.
2. Érje el a cél diát.
3. Adjon hozzá egy téglalap alakú [AutoShape] elemet a diára.
4. Érje el az alakzat [TextFrame] elemét, és távolítsa el az alapértelmezett bekezdést.
5. Hozzon létre több bekezdést, és állítson be különböző [ParagraphFormat.indent] értékeket.
6. Adja hozzá a bekezdéseket a szövegdobozhoz.
7. Mentse a módosított bemutatót.

Ez a kód megmutatja, hogyan állíthat be bekezdés behúzást:

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

![The first-line indent of the paragraphs](first_line_indent.png)

### **Függő behúzás beállítása**

A függő behúzás olyan bekezdéselrendezés, ahol az első sor balra indul a többi sorhoz képest. Az Aspose.Slides-ben ezt a hatást a [ParagraphFormat.indent] tulajdonsággal hozhatja létre. Állítsa az `indent` értékét negatívra, hogy az első sort a bekezdés törzséhez képest balra mozgassa.

Gyakorlatban a [ParagraphFormat.margin_left] határozza meg a bekezdés törzsének bal pozícióját, a [ParagraphFormat.indent] pedig az első sor pozícióját ehhez a margóhoz képest. A függő behúzás létrehozásához állítson be pozitív `margin_left` értéket és negatív `indent` értéket.

Ez a formázás hasznos bibliográfiák, hivatkozások, szószedet-bejegyzések és egyéb bekezdések esetén, ahol a sortöréses soroknak a bekezdés törzsének alá kell illeszkedniük, nem pedig az első sor első karaktere alá.

1. Hozzon létre egy példányt a [Presentation] osztályból.
2. Érje el a cél diát.
3. Adjon hozzá egy téglalap alakú [AutoShape] elemet a diára.
4. Érje el az alakzat [TextFrame] elemét, és távolítsa el az alapértelmezett bekezdést.
5. Hozzon létre bekezdéseket, és állítson be minden bekezdéshez pozitív [ParagraphFormat.margin_left] értéket.
6. Állítson be negatív [ParagraphFormat.indent] értéket a függő behúzás létrehozásához.
7. Adja hozzá a bekezdéseket a szövegdobozhoz.
8. Mentse a módosított bemutatót.

Ez a kód megmutatja, hogyan állíthat be függő behúzást egy bekezdésnél:

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

![The hanging indent of the paragraphs](hanging_indent.png)

### **Bekezdés végének részformázási tulajdonságainak beállítása**

A [Paragraph.end_paragraph_portion_format] tulajdonság szabályozza a bekezdés végejelének formázását. A következő példa betűméretet és latin betűtípust rendel a második bekezdés végejeléhez:

1. Töltsön be egy [Presentation] objektumot, és érje el egy diát.
2. Adjon hozzá egy [AutoShape] elemet, és törölje az alapértelmezett bekezdését.
3. Hozzon létre két bekezdést, és adjon hozzá szöveg szakaszokat.
4. Hozzon létre egy [PortionFormat] objektumot a második bekezdés végejeléhez.
5. Állítsa be a [PortionFormat.font_height] és a [PortionFormat.latin_font] értékeket.
6. Rendelje hozzá a formátumot a [Paragraph.end_paragraph_portion_format] tulajdonsághoz, majd mentse a bemutatót.

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

Használja a [Paragraph.get_lines_count] metódust, hogy megszámolja egy bekezdés által elfoglalt sorok számát a szöveg elrendezése után, beleértve az automatikus sortörést is. Ez hasznos a szöveghossz és az elrendezés ellenőrzésénél a prezentációs sablonokban.

Egy bekezdés a [TextFrame.paragraphs] egy eleme, és több megjelenített sorba is elférhet. Egy explicit sortörés egy bekezdésen belül új sort kényszerít anélkül, hogy új bekezdést hozna létre. Az automatikus sortörés a rendelkezésre álló szélesség alapján hoz létre sorokat, anélkül, hogy explicit sortörés karaktereket szúrna be a szövegbe. Így a bekezdések vagy sortörés karakterek számolása nem adja meg a megjelenített sorok számát.

A következő példa egy szövegtáblát hoz létre, megszámolja a sorait, szűkíti a táblát, majd egy rövidebb szövegre cseréli a tartalmat. A sortörés engedélyezett és az automatikus méretezés le van tiltva, így a tábla szélessége határozza meg a sortörést anélkül, hogy automatikusan zsugorítaná a szöveget vagy átméretezné a táblát. A tábla méretei pontban vannak megadva. Végül a példa egy másik bekezdést ad hozzá, és összeadja a sorok számát a szövegdobozon belül.

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

Ezzel a szöveggel és ezekkel a dimenziókkal a tábla szűkítése növeli a sorok számát, míg a szöveg rövid lánccal való helyettesítése csökkenti azt. A pontos számok változhatnak a betűtípus elérhetősége és helyettesítése, betűméret, margók, behúzás, sortörés és automatikus méretezés beállításai szerint. Használja az adott környezethez tervezett betűtípusokat és elrendezési beállításokat, amikor egy sablont ellenőriz.

A sorok száma önmagában nem határozza meg, hogy a szöveg kilóg-e a tárolóból. A rendelkezésre álló magasság, a sormagasságok, a bekezdés- és sorköz, valamint az automatikus méretezés viselkedése is számít; még egyetlen sor is túllépheti a rendelkezésre álló szélességet, ha a sortörés le van tiltva.

## **Bekezdés tartalmának importálása és exportálása**

### **HTML szöveg importálása bekezdésekbe**

Használja a [ParagraphCollection.add_from_html] metódust, hogy HTML jelölőnyelvet konvertáljon bekezdésekké és szakaszokká egy szövegdobozban.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztályból.
2. Érje el egy diát, és adjon hozzá egy [AutoShape](https://reference.aspose.com/slides/hu/python-net/aspose.slides/autoshape/) elemet.
3. Érje el az alakzat [TextFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframe/) elemét, és törölje az alapértelmezett bekezdését.
4. Olvassa be a forrás HTML fájlt.
5. Adja át a HTML karakterláncot a [ParagraphCollection.add_from_html](https://reference.aspose.com/slides/hu/python-net/aspose.slides/paragraphcollection/add_from_html/) metódusnak.
6. Mentse a módosított bemutatót.

Ez a Python példa HTML-t importál egy szövegdobozba:

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

Használja a [ParagraphCollection.export_to_html] metódust, hogy a kiválasztott bekezdéssort HTML-ként exportálja.

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) példányt, és töltse be a kívánt bemutatót.
2. Érje el a diát, és keresse meg a szöveget tartalmazó [AutoShape](https://reference.aspose.com/slides/hu/python-net/aspose.slides/autoshape/) elemet.
3. Érje el az alakzat [TextFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframe/) elemét.
4. Hívja meg a [ParagraphCollection.export_to_html](https://reference.aspose.com/slides/hu/python-net/aspose.slides/paragraphcollection/export_to_html/) metódust a kezdő bekezdés indexével és az exportálandó bekezdések számával.
5. Írja a visszakapott HTML karakterláncot egy fájlba.

Ez a Python példa az első szövegelem összes bekezdését exportálja:

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

A [Paragraph] biztosítja a `get_image` metódust egy egyedi bekezdés közvetlen rendereléséhez. A metódus egy [IImage] objektumot ad vissza, amelyet fájlba vagy adatfolyamba menthet a [IImage.save] segítségével. Nem szükséges a környező alakzatot renderelni vagy a bitmapet manuálisan kivágni.

A `get_image` metódus `None` értéket adhat vissza, ha a bekezdés nem található a szülő gyűjteményben, nincs érvényes renderelési határa, vagy nem renderelhető. Ellenőrizze az eredményt a mentés előtt, és használja a visszakapott képet kontextuskezelőként a erőforrások felszabadításához.

#### **Bekezdés renderelése alapértelmezett méretben**

Tegyük fel, hogy van egy sample.pptx nevű prezentációs fájlunk egy diával, ahol az első alakzat egy három bekezdést tartalmazó szövegdoboz.

![The text box with three paragraphs](paragraph_to_image_input.png)

A következő példa a második bekezdést egy normál szövegalakzatban alapértelmezett méretben rendereli, majd a visszakapott képet PNG formátumban menti:

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

![The paragraph image](paragraph_to_image_output.png)

#### **Bekezdés renderelése táblázatcellában méretezéssel**

Adjon meg vízszintes és függőleges méretezési tényezőket a `get_image` metódusnak, hogy a renderelt bekezdés méretét szabályozza. A következő példa egy táblázatot hoz létre, a bekezdést az első cellájában a alapértelmezett szélesség és magasság kétszeresére rendereli, és a végeredményt PNG képként menti:

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

Az `1` méretezési tényező az adott tengelyet az alapértelmezett pixelméretben hagyja. Például a `2` mindkét tényező esetén egy olyan képet eredményez, amelynek szélessége és magassága körülbelül kétszerese az alapértelmezettnek, ez négyzet annyi pixelt jelent. A nagyobb tényezők általában élesebb szöveget biztosítanak nagyításhoz vagy nagy felbontású kimenethez, de növelik a memóriahasználatot és a fájlméretet. Az `1`‑nél kisebb tényezők kisebb, kevésbé részletes képeket adnak. Azonos tényezőket használjon a bekezdés méretarányának megőrzéséhez; a különböző vízszintes és függőleges tényezők önállóan nyújtják a kimenetet.

Egy egész alakzat renderelése a [Shape.get_image](https://reference.aspose.com/slides/hu/python-net/aspose.slides/shape/get_image/) segítségével továbbra is hasznos, ha a kimenetnek tartalmaznia kell az alakzat kitöltését, keretét vagy egyéb vizuális kontextusát. Egy csak bekezdést tartalmazó képhez használja a `Paragraph.get_image` metódust.

## **GYIK**

**Letilthatom a sortörést teljesen egy szövegdobozban?**  
Igen. Állítsa a [TextFrameFormat.wrap_text] értéket a sortörés letiltásához, így a sorok nem törnek a szövegdoboz szélén.

**Hogyan kaphatom meg egy adott bekezdés pontos diakörvonalát?**  
Használja a [Paragraph.get_rect] metódust a bekezdés határoló téglalapjának lekérésére. A [Portion.get_rect] egy adott szakasz határait adja vissza.

**Hol állítható be a bekezdés igazítása (balra, jobbra, középre vagy sorkizárás)?**  
A [ParagraphFormat.alignment] a bekezdés szintű beállítás, amely a teljes bekezdésre vonatkozik, függetlenül az egyes szakaszok formázásától.

**Beállíthatok lektorálási nyelvet a bekezdés egy részére?**  
Igen. Állítsa a [PortionFormat.language_id] értéket az egyes szakaszokhoz, így egy bekezdés több nyelven is tartalmazhat szöveget.