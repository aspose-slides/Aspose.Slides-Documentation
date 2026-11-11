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
- bekezdés felsorolásjel
- számozott lista
- felsoroláslista
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
description: "Ismerje meg, hogyan hozhat létre és formázhat bekezdéseket, részeket, felsorolásjeleket, számozott listákat, behúzásokat, HTML tartalmat és bekezdésképeket az Aspose.Slides for Python via .NET használatával."
---
## **Áttekintés**

Az Aspose.Slides for Python via .NET a szöveget szövegdobozok, bekezdések és részek hierarchiájaként ábrázolja:

* [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) egy alakzat szövegtárolóját képviseli, és hozzáférést biztosít a bekezdésgyűjteményéhez.
* [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) egy bekezdést képvisel a szövegdobozban, és hozzáférést ad annak részeihez és bekezdés-szintű formázásához.
* [Portion](https://reference.aspose.com/slides/python-net/aspose.slides/portion/) egy szövegrészt (run) képvisel egy bekezdésen belül. Minden résznek saját szövege és karakter-szintű formázása lehet.

Egy bekezdés ezért több különböző betűtípussal, színnel, mérettel és egyéb formázással ellátott szöveget tartalmazhat több rész felhasználásával.

## **Bekezdések létrehozása és formázása**

Hozzon létre bekezdéseket egy alakzat szövegdobozában, és használjon részeket az egyedi szövegrészek formázásához. Ez a szakasz bemutatja, hogyan kombinálhatók több rész egy bekezdésben, valamint hogyan alkalmazhatók különböző színek, betűméretek és stílusok.

### **Bekezdések létrehozása több résszel**

A következő Python példa három bekezdést hoz létre, mindegyik három szövegrészt tartalmaz a [Paragraph.portions](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/portions/) gyűjteményében. Újra felhasználja az alapértelmezett bekezdést és annak üres részét, majd hozzáadja a maradék bekezdéseket és részeket. A formázás a [Portion.portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/portion/portion_format/) segítségével történik: az első rész minden bekezdésben piros, félkövér és 15 pont, a második kék, dőlt és 18 pont. A harmadik rész megtartja az alapértelmezett formázást:

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

Rendezzük a bekezdés szövegét listákba szimbólumok, számok vagy egyéni képek segítségével. Ebben a szakaszban a felsorolás formázását, a többszintű listákat és az egyéni kezdőszámokat mutatjuk be.

### **Felsorolásos vagy számozott lista létrehozása**

A felsorolások és a számozás megkönnyítik a kapcsolódó elemek áttekintését. Az Aspose.Slides listabeállításait a [BulletFormat](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/) definiálja.

Ez a Python példa egy szimbólum jelzést és egy számozott elemet ad hozzá ugyanahhoz a szövegdobozhoz. A [BulletFormat.type](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/type/) választja ki a jelzés típusát, a [BulletFormat.char](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/char/) adja meg a szimbólumot, a [BulletFormat.numbered_bullet_style](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/numbered_bullet_style/) pedig a számozási stílust. Mindkét elem fekete jelzést használ 100 % magassággal és 25 pont bekezdésbehúzással:

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

### **Képes jelzés használata**

A képes jelzések lehetővé teszik egy egyéni kép használatát szimbólum vagy szám helyett.

A példa megköveteli, hogy a munkakönyvtárban legyen egy `bullets.png` fájl. Ez a Python példa a prezentáció képgyűjteményéhez ad egy [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) elemet, és azt használja bekezdés jelzésként. A [BulletFormat.type](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/type/) értékét képes jelzésre állítja, a képet a [BulletFormat.picture](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/picture/) határozza meg. A [BulletFormat.height](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/height/) 100 %-ra van állítva, hogy a jelzés mérete a bekezdés szövegéhez viszonyítva legyen:

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

A [ParagraphFormat.depth](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/depth/) beállításával helyezhetjük a bekezdéseket a lista különböző szintjeire. A legfelső szint mélysége `0`.

Ez a Python példa a [ParagraphFormat.depth](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/depth/) értékeit 0‑tól 3‑ig rendeli négy bekezdéshez, ezzel egy hierarchiát hozva létre egy szövegdobozon belül. Minden bekezdés szimbólum jelzést használ, a [BulletFormat.char](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/char/) egy kör alakú jelzés és egy kötőjel között váltakozik a szomszédos szintek megkülönböztetésére:

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

### **Számozott listaelemek saját értékekkel kezdése**

A [BulletFormat.numbered_bullet_start_with](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/numbered_bullet_start_with/) segítségével állítható be egy számozott bekezdés kezdeti száma.

Ez a Python példa a [BulletFormat.type](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/type/) értékét számozásra állítja három bekezdésnél, és a [BulletFormat.numbered_bullet_start_with](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/numbered_bullet_start_with/) értékeit 2, 3 és 7‑re állítja. A kezdőérték minden bekezdésnél külön van beállítva, így a megjelenített számok kihagyhatnak értékeket:

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

## **Bekezdéselrendezés és befejező tulajdonságok vezérlése**

Állítsa be a bekezdés margóit és behúzásait az első sor és a tördelődő sorok pozíciójának szabályozásához. A bekezdés végjelet is formázhatja külön a látható szövegrészektől.

### **Első sor behúzásának beállítása**

Használja a [ParagraphFormat.indent](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/indent/) tulajdonságot az első sor behúzásának szabályozásához. Ez a tulajdonság csak az első sort mozgatja a bekezdés bal margójához képest. A pozitív érték jobbra tolja az első sort, míg a többi sor a bekezdés törzséhez igazodik.

Használja a [ParagraphFormat.margin_left](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/margin_left/)‑t, ha a teljes bekezdést szeretné eltolni. Használja a [ParagraphFormat.indent](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/indent/)‑t, ha csak az első sort akarja eltolni.

A következő példa három bekezdést ugyanazzal a [ParagraphFormat.margin_left](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/margin_left/) 20 pont értékkel és [ParagraphFormat.indent](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/indent/) 0, 20 illetve 40 pont értékekkel lát el. Az első sorok egyre nagyobb eltolással kezdődnek, míg a tördelődő sorok ugyanazt a bal margót tartják:

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

A függő behúzás egy olyan bekezdéselrendezés, ahol az első sor a többi sor bal oldalára indul. Az Aspose.Slides-ben ezt a hatást a [ParagraphFormat.indent](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/indent/) tulajdonsággal érheti el. Állítsa az `indent`‑et negatív értékre, hogy az első sor balra tolódjon a bekezdéstörzshöz képest.

Gyakorlatban a [ParagraphFormat.margin_left](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/margin_left/) határozza meg a bekezdéstörzs bal pozícióját, a [ParagraphFormat.indent](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/indent/) pedig az első sor pozícióját ehhez a margóhoz képest. Függő behúzás létrehozásához állítson be pozitív `margin_left` értéket és negatív `indent` értéket.

Ez a formázás hasznos bibliográfiák, hivatkozások, szószedet-bejegyzések és egyéb bekezdések esetén, ahol a tördelődő soroknak a bekezdéstörzs alá kell igazulniuk, nem pedig az első sor első karakteréhez.

A következő Python példa a [ParagraphFormat.margin_left](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/margin_left/) 40 pont és 60 pont értékeit párosítja a [ParagraphFormat.indent](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/indent/) –20 pont és –30 pont értékeivel. Minden bekezdésben az első sor a tördelődő sorok bal oldalára indul; a második bekezdés mélyebb függő behúzást kap:

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

![A függő behúzás a bekezdésekben](hanging_indent.png)

### **Bekezdés végi futtatott tulajdonságok beállítása**

A [Paragraph.end_paragraph_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/end_paragraph_portion_format/) tulajdonság szabályozza a bekezdés befejező jelzés formázását. A példa betölti a `Test.pptx`‑et, amelynek legalább egy diát kell tartalmaznia, és létrehoz egy [PortionFormat](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/) objektumot, amelynek a [PortionFormat.font_height](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/font_height/) 48 pont, a [PortionFormat.latin_font](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/latin_font/) pedig Times New Roman. Ezt a formátumot rendeli a második bekezdés befejező jelzéséhez, a látható szövegrészeket változatlanul hagyva:

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

A bekezdés szabályairól, amelyek az automatikus tördelést és a sorvégi írásjelek kezelését befolyásolják, lásd a [Control Line Breaking](/slides/hu/python-net/text-formatting/#control-line-breaking) és a [Control Hanging Punctuation](/slides/hu/python-net/text-formatting/#control-hanging-punctuation) oldalakat.

Használja a [Paragraph.get_lines_count](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_lines_count/) metódust a bekezdés által elfoglalt sorok számának meghatározásához a szöveg elrendezése után, beleértve az automatikus tördelést is. Ez hasznos a szöveghossz és az elrendezés ellenőrzéséhez prezentációs sablonokban.

Egy bekezdés egy elem a [TextFrame.paragraphs](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/paragraphs/) gyűjteményben, és több megjelenített sorba is kerülhet. Egy explicit sortörés egy bekezdésen belül új sort eredményez anélkül, hogy új bekezdést hozna létre. Az automatikus tördelés a rendelkezésre álló szélesség alapján hoz létre sorokat, anélkül, hogy explicit sortörés karaktereket illesztene a szövegbe. A bekezdések vagy sortörés karakterek számlálása ezért nem adja meg a megjelenített sorok számát.

A következő példa egy szöveges alakzatot hoz létre, megszámolja a sorait, szűkíti az alakzatot, majd a szöveget egy rövidebb karakterláncra cseréli. A példa engedélyezi a [TextFrameFormat.wrap_text](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/wrap_text/) beállítást, és letiltja a [TextFrameFormat.autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/autofit_type/)‑ot, így a forma szélessége szabályozza a tördelést anélkül, hogy automatikusan zsugorítaná a szöveget vagy átméretezné a formát. Minden mérés a [Paragraph.get_lines_count](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_lines_count/)‑t használja. A forma méretei pontokban vannak. Végül a példa egy újabb bekezdést ad hozzá, és összeadja a sorok számát a szövegdobozon belül.

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

Ezzel a szöveggel és ezekkel a méretekkel a forma szűkítése növeli a sorok számát, míg a rövidebb szövegre cseréléssel csökken az. A pontos számok a betűtípusok elérhetőségétől, a helyettesítéstől, a betűmérettől, a margóktól, a behúzástól, a tördeléstől és az autofit beállításoktól függnek. A célkörnyezetben használt betűtípusok és elrendezési beállítások használata ajánlott a sablon ellenőrzésekor.

A sorok száma önmagában nem határozza meg, hogy a szöveg túlhúzza‑e a tárolóját. A rendelkezésre álló magasság, a sormagasságok, a bekezdés‑ és sorköz, valamint az autofit viselkedés is számít; még egyetlen sor is meghaladhatja a rendelkezésre álló szélességet, ha a tördelés le van tiltva.

## **Bekezdés tartalmának importálása és exportálása**

Használja a HTML‑t a szöveg prezentációba történő importálásához vagy a meglévő bekezdések exportálásához külső felhasználáshoz. Ez a szakasz megmutatja, hogyan renderelhetünk egyedi bekezdéseket képként, beleértve a táblázatcellákban lévő bekezdéseket is.

### **HTML‑szöveg importálása bekezdésekbe**

Használja a [ParagraphCollection.add_from_html](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphcollection/add_from_html/) metódust, hogy a HTML‑markupot bekezdésekké és részekké konvertálja egy szövegdobozban.

Ez a Python példa a munkakönyvtárban lévő `file.html`‑ből olvas HTML‑t, és a markupot átadja a [ParagraphCollection.add_from_html](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphcollection/add_from_html/)‑nek. Törli a szövegdoboz alapértelmezett bekezdését, hogy a dobz csak a importált tartalmat tartalmazza. A téglalap alakzat 10 pont margót hagy minden oldalán a dián:

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

Használja a [ParagraphCollection.export_to_html](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphcollection/export_to_html/) metódust, hogy a kiválasztott bekezdés‑tartományt HTML‑ként exportálja. Ha a prezentáció szövegét egy weboldalon szeretné újra felhasználni, érdemes megtartani a helyi kiemeléseket anélkül, hogy a prezentáció betűtípusa, mérete vagy szövegmező‑stílusa átkerülne. Állítsa a [TextToHtmlConversionOptions.text_inheritance_limit](https://reference.aspose.com/slides/python-net/aspose.slides.export/texttohtmlconversionoptions/text_inheritance_limit/)‑t, hogy szabályozza, meddig követi az exportáló a formázási öröklődést.

Töltse le a [mintaprezentációt](text-inheritance.pptx), és helyezze az alkalmazás munkakönyvtárába. Az első dia egy szövegdobozt tartalmaz a „Inherited text; explicit red 18pt” szöveggel. A bemenet szándékosan több formázási szintet használ:

- A prezentáció alapértelmezett szövegstílusa Calibri‑t és 28 pt méretet ad.
- A szövegdoboz első szintű szövegstílusa kék szöveget és dőlt betűt biztosít.
- A bekezdés explicit módon félkövér szöveget állít be.
- A második rész, „explicit red 18pt”, explicit módon piros szöveget és 18 pt méretet ad meg.

A következő teljes példa háromszor exportálja ugyanazokat a bekezdéseket. A [TextToHtmlConversionOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/texttohtmlconversionoptions/)‑t átadja az exportáló metódusnak, és minden eredményt külön UTF‑8 HTML fájlként ír:

```python
import aspose.slides as slides

with slides.Presentation("text-inheritance.pptx") as presentation:
    text_shape = presentation.slides[0].shapes[0]
    paragraphs = text_shape.text_frame.paragraphs
    
    modes = {
        "All": slides.export.TextInheritanceLimit.ALL,
        "TextBox": slides.export.TextInheritanceLimit.TEXT_BOX,
        "ParagraphOnly": slides.export.TextInheritanceLimit.PARAGRAPH_ONLY,
    }

    for name, mode in modes.items():
        options = slides.export.TextToHtmlConversionOptions()
        options.text_inheritance_limit = mode

        html = paragraphs.export_to_html(0, paragraphs.count, options)
        with open(f"{name}.html", "w", encoding="utf-8") as html_stream:
            html_stream.write(html)
```

A generált HTML a következő CSS‑t tartalmazza az első részhez, „Inherited text; “. A táblázat a releváns deklarációkat sorolja fel; a többi generált tulajdonság a tisztaság kedvéért elmaradt.

| Kimenet | Az első részhez releváns CSS | Megjelenés |
| --- | --- | --- |
| `All.html` | `font-family:'Calibri'; font-size:28pt; color:#0000ff; font-style:italic; font-weight:bold` | Kék, félkövér, dőlt szöveg 28 pt méretben Calibri betűtípussal, ha elérhető. |
| `TextBox.html` | `color:#0000ff; font-style:italic; font-weight:bold` | Kék, félkövér, dőlt szöveg; a környező oldal vagy böngésző biztosítja a betűcsaládot és a méretet. |
| `ParagraphOnly.html` | `font-weight:bold` | Félkövér szöveg; a környező oldal vagy böngésző biztosítja a betűcsaládot, méretet, színt és a dőlt stílust. |

A második rész megőriz minden kimenetben a `color:#ff0000`, `font-size:18pt` és `font-weight:bold` értékeket. Az `ALL` és `TEXT_BOX` esetén megtartja a dőlt stílust, de a `PARAGRAPH_ONLY` esetén nem. Az öröklődés korlátozása tehát nem távolítja el a bekezdéshez vagy részhez explicit módon hozzárendelt formázást.

Nyissa meg a fájlokat ugyanabban a böngészőben a összehasonlításhoz. A két korlátozott mód esetén az elhagyott CSS‑tulajdonságokat a céloldal stílusa vagy a böngésző alapértelmezései oldják fel, így a végső megjelenés attól függ, hol használják a HTML‑t.

### **HTML‑vágólap‑töredék generálása**

A [ParagraphCollection.export_to_html](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphcollection/export_to_html/) egy HTML‑stringet ad vissza. Állítsa a [TextToHtmlConversionOptions.add_clipboard_fragment_header](https://reference.aspose.com/slides/python-net/aspose.slides.export/texttohtmlconversionoptions/add_clipboard_fragment_header/)‑t `False`‑ra az egyszerű HTML‑hez, vagy `True`‑ra a Windows vágólap‑fejléc hozzáadásához. A fejléc tartalmazza a környező HTML (`StartHTML` és `EndHTML`) és a beillesztendő töredék (`StartFragment` és `EndFragment`) UTF‑8 bájteltolásait.

Ez a példa két formázott bekezdést exportál egyszerű HTML‑ként (`html`) és HTML‑vágólap‑töredékként (`clipboard_html`). A töredék rendszer‑vágólapra való írása külön alkalmazás‑lépés. Ha a vágólap‑API nyers bájtokat vár, kódolja a töredéket UTF‑8‑ban BOM nélkül.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 0, 0, 400, 100)
    paragraphs = shape.text_frame.paragraphs
    paragraphs.clear()
    paragraphs.add_from_html("<p>Status: <b>Ready</b></p><p><i>Next steps</i></p>")

    options = slides.export.TextToHtmlConversionOptions()
    options.add_clipboard_fragment_header = False
    html = paragraphs.export_to_html(0, paragraphs.count, options)

    options.add_clipboard_fragment_header = True
    clipboard_html = paragraphs.export_to_html(0, paragraphs.count, options)
```

### **Bekezdés renderelése képként**

A [Paragraph.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_image/) egyedi bekezdést renderel közvetlenül, és egy [IImage](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/) objektumot ad vissza. Mentse az eredményt fájlba vagy adatfolyamba a [IImage.save](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/save/)‑nel. Nem szükséges a tartalmazó alakzatot renderelni vagy a bitmapet manuálisan kivágni.

A [Paragraph.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_image/) `None`‑t adhat vissza, ha a bekezdés nem található a szülőgyűjteményben, nincs érvényes renderelési határa, vagy nem renderelhető. Ellenőrizze az eredményt a mentés előtt, és a használat után szabadítsa fel a visszakapott képet.

#### **Bekezdés renderelése alapértelmezett méretezéssel**

A példa a `sample.pptx`‑et használja, egyetlen diával, amelynek első alakzata egy három bekezdést tartalmazó szövegmező.

![A három bekezdést tartalmazó szövegmező](paragraph_to_image_input.png)

A következő példa a második bekezdést (index 1) választja, és a [Paragraph.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_image/)‑t paraméterek nélkül hívja. Ellenőrzi, hogy az alakzat tartalmazza‑e a szükséges bekezdést, és a renderelés képet ad‑e vissza, mielőtt a [IImage.save](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/save/)‑nel PNG‑formátumban mentené. A context manager a kép erőforrásait a használat után felszabadítja.

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

Használja a [Paragraph.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_image/) túlterhelést, amely `scale_x` és `scale_y` paramétereket fogad, a vízszintes és függőleges skálázási faktorok beállításához. A következő példa létrehoz egy táblázatot, a bekezdést az első cellájában kétszeres alap‑szélesség és -magasság mellett rendereli, és PNG‑képként menti az eredményt.

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

Az `1`‑es skálafaktor megtartja az adott tengelyt az alap‑pixeleméretén. Például a `2` mindkét faktorra egy olyan képet eredményez, amelynek szélessége és magassága körülbelül kétszerese az alap‑dimenzióknak, így négy‑ször annyi pixel keletkezik. A nagyobb faktorok általában élesebb szöveget adnak a nagyítás vagy magas felbontású kimenet esetén, de növelik a memória‑használatot és a fájlméretet. Az `1`‑nél kisebb faktorok kisebb képet eredményeznek kevesebb részlettel. Egyenlő faktorok megőrzik a bekezdés képarányát; a különböző vízszintes és függőleges faktorok önállóan nyújtják az eredményt.

Egy egész alakzat renderelése a [Shape.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/shape/get_image/)‑vel akkor hasznos, ha a kimenetnek tartalmaznia kell az alakzat kitöltését, szegélyét vagy egyéb vizuális kontextusát. Egy csak bekezdést tartalmazó képhez használja a [Paragraph.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_image/)‑t.

## **GYIK**

**Letiltom teljesen a sortörést egy szövegdobozon belül?**

Igen. Állítsa a [TextFrameFormat.wrap_text](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/wrap_text/) értékét a sortörés letiltásához, így a sorok nem törnek meg a szövegdoboz szélén.

**Hogyan kaphatom meg egy adott bekezdés pontos helyi határait a dián?**

Használja a [Paragraph.get_rect](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_rect/) metódust a bekezdés határoló téglalapjának lekéréséhez. A [Portion.get_rect](https://reference.aspose.com/slides/python-net/aspose.slides/portion/get_rect/) egy egyedi rész határait adja vissza.

**Hol van szabályozva a bekezdés igazítása (balra, jobbra, középre vagy sorkizárt)?**

A [ParagraphFormat.alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/) bekezdés‑szintű beállítás, amely az egész bekezdésre vonatkozik, függetlenül az egyes részek formázásától.

Különböző betűmérettel rendelkező részek függőleges igazításához lásd a [Align Fonts Within a Line](/slides/hu/python-net/text-formatting/#align-fonts-within-a-line) oldalt.

**Beállíthatok ellenőrző nyelvet a bekezdés egy részére?**

Igen. A [PortionFormat.language_id](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/language_id/) beállítható egyedi részeknél, így egy bekezdés több nyelven is tartalmazhat szöveget.