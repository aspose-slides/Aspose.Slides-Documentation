---
title: "Prezentáció szövegformázása Pythonban"
linktitle: "Szövegformázás"
type: docs
weight: 50
url: /hu/python-net/text-formatting/
keywords:
- "bekezdés igazítása"
- "szövegstílus"
- "szöveg háttér"
- "szöveg átlátszóság"
- "karakterköz"
- "betűtípus‑tulajdonságok"
- "betűtípuscsalád"
- "szöveg forgatása"
- "forgatási szög"
- "szövegkeret"
- "sorköz"
- "automatikus illesztés tulajdonság"
- "szövegkeret rögzítése"
- "szöveg tabulálás"
- "alapértelmezett nyelv"
- "PowerPoint"
- "OpenDocument"
- "prezentáció"
- "Python"
- "Aspose.Slides"
description: "Formázd és stílusozd a szöveget PowerPoint és OpenDocument prezentációkban az Aspose.Slides for Python via .NET használatával. Testre szabhatod a betűtípusokat, színeket, igazítást és egyebeket."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet formázni a szöveget PowerPoint és OpenDocument prezentációkban az Aspose.Slides for Python via .NET segítségével. Kifejti a háttérszíneket, átlátszóságot, karakterközöket, betűtípus‑tulajdonságokat, forgatást, bekezdésközöket, automatikus illesztés viselkedését, szöveg‑ankorlást, tabulátor‑állításokat és nyelvi beállításokat.

Kivéve, ha máshogy nem állítják, a példák a [sample.pptx](sample.pptx) fájlt használják. Az első dia első alakzatában egy szövegdoboz található, és az első bekezdésben az alább látható szöveg van. Mind a dia, mind az alakzat indexelése nulláról indul. A félkövér részek kiválasztását hatékony formázással, beleértve az örökölt félkövér formázást, mutatják:

![Minta szöveg](sample_text.png)

A szöveg szó szerinti vagy reguláris kifejezés szerinti kereséséhez és kiemeléséhez lásd a [Search and Replace Text](/slides/hu/python-net/search-and-replace-text/) oldalt.

## **Szöveg háttérszín beállítása**

Használd a [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_portion_format/) metódust a bekezdés alapértelmezett kiemelési színének beállításához, vagy a [BasePortionFormat.highlight_color](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/highlight_color/) metódust az egyes szöverrészekhez.

Az alábbi példa a könnyű szürke kiemelést állítja be alapértelmezettként az első bekezdéshez. Az egyes részeken megadott konkrét kiemelési színek felülírják ezt az alapbeállítást:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Állítsa be a teljes bekezdés kiemelési színét.
    paragraph.paragraph_format.default_portion_format.highlight_color.color = draw.Color.light_gray

    presentation.save("gray_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

Az eredmény:

![A szürke bekezdés](gray_paragraph.png)

Az alábbi kódrészlet bemutatja, hogyan állítható be a háttérszín **félkövér betűvel** rendelkező **szövegrészek** számára:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # Állítsa be a szövegrész kiemelési színét.
            portion.portion_format.highlight_color.color = draw.Color.light_gray

    presentation.save("gray_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

Az eredmény:

![A szürke szövegrészek](gray_text_portions.png)

## **Szöveg bekezdések igazítása**

Használd a [ParagraphFormat.alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/) metódust a bekezdés igazításához egy szövegkereten belül. Az érték lehet középre, balra, jobbra, sorkizárás stb.

Az alábbi kódrészlet azt mutatja, hogyan igazítsuk a bekezdést **középre**:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Állítsa be a bekezdés igazítását középre.
    paragraph.paragraph_format.alignment = slides.TextAlignment.CENTER

    presentation.save("aligned_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

Az eredmény:

![Az igazított bekezdés](aligned_paragraph.png)

## **Betűk vízszintes igazítása egy soron belül**

Használd a [ParagraphFormat.font_alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/font_alignment/) metódust a különböző betűméretű szövegrészek függőleges igazításához egy soron belül. Ez a beállítás az egész bekezdésre vonatkozik, és minden sorra érvényes.

Az alábbi önálló példa négy címkézett szövegdobozt hoz létre egy dián. Minden bekezdés ugyanazt a szöveget tartalmazza 18, 36 és 54 pontban, eltérő betűigazítással. Az Arial betűtípust használja, letiltja az automatikus illesztést és a sortörést, és a szövegkereteket elég nagyra állítja, hogy egy sorba férjenek.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    alignments = [slides.FontAlignment.BASELINE, slides.FontAlignment.TOP, slides.FontAlignment.CENTER, slides.FontAlignment.BOTTOM]
    font_sizes = [18, 36, 54]

    for i, alignment in enumerate(alignments):
        shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 20 + i * 130, 660, 120)
        shape.fill_format.fill_type = slides.FillType.NO_FILL
        shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL

        text_frame = shape.text_frame
        text_frame.text_frame_format.anchoring_type = slides.TextAnchorType.TOP
        text_frame.text_frame_format.autofit_type = slides.TextAutofitType.NONE
        text_frame.text_frame_format.wrap_text = slides.NullableBool.FALSE

        label = text_frame.paragraphs[0]
        label.text = alignment.name.title()
        label.paragraph_format.alignment = slides.TextAlignment.LEFT
        label.paragraph_format.default_portion_format.font_height = 14
        label.paragraph_format.default_portion_format.latin_font = slides.FontData("Arial")
        label.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
        label.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.gray

        paragraph = slides.Paragraph()
        paragraph.paragraph_format.font_alignment = alignment
        paragraph.paragraph_format.alignment = slides.TextAlignment.LEFT
        paragraph.paragraph_format.default_portion_format.latin_font = slides.FontData("Arial")
        paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
        paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black

        for font_size in font_sizes:
            portion = slides.Portion("Ag ")
            portion.portion_format.font_height = font_size
            paragraph.portions.add(portion)

        text_frame.paragraphs.add(paragraph)

    presentation.save("font_alignment.pptx", slides.export.SaveFormat.PPTX)
```

Az eredmény:

![Alapvonal, felső, középső és alsó betűigazítás kevert betűméretekkel](font_alignment.png)

A betűigazítás a betűmetrikán alapul, ezért az egyes betűk látható szélei nem feltétlenül hajuknak tökéletesen. A példa tartalmaz nagybetűt és egy alsó szervát, hogy bemutassa a különbséget az alapvonal és az alsó igazítás között. A betűtípus‑elérhetőség és helyettesítés, a használt karakterek és a betűméret‑különbségek mind befolyásolják az eredményt. A keretméretek, margók, sorköz, sortörés és automatikus illesztés szintén hatnak a megjelenésre; a módok összehasonlításához ugyanazokat a betűket és elrendezési beállításokat használd.

Ez a beállítás eltér a [ParagraphFormat.alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/)‑tól, amely a vízszintes bekezdés‑igazítást szabályozza, valamint a [TextFrameFormat.anchoring_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/anchoring_type/)-tól, amely a szöveglapot függőlegesen helyezi el az alakzatban. A felső‑ és alsó indexelés a [BasePortionFormat.escapement](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/escapement/) használatával egyes részeket az alapvonalhoz képest eltol, a bekezdés sorainak betűigazítása helyett.

## **Szöveg átlátszóságának beállítása**

A szöveg átlátszósága a [BasePortionFormat.fill_format](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/fill_format/) színének alfa‑komponensén keresztül szabályozható. Az alábbi példákban a `alpha = 50` egy ARGB alfa‑csatorna‑érték a 0‑255 tartományban, nem százalékos átlátszóság.

Az alábbi kódrészlet azt mutatja, hogyan alkalmazz átlátszóságot a **teljes bekezdésre**:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

alpha = 50

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Állítsa be a szöveg félig átlátszó fekete kitöltését.
    paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.from_argb(alpha, draw.Color.black)

    presentation.save("transparent_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

Az eredmény:

![Az átlátszó bekezdés](transparent_paragraph.png)

A következő kódrészlet azt mutatja, hogyan alkalmazz átlátszóságot **félkövér betűvel** rendelkező szövegrészekre:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

alpha = 50

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # Állítsa be a szövegrész átlátszóságát.
            portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
            portion.portion_format.fill_format.solid_fill_color.color = draw.Color.from_argb(alpha, draw.Color.black)

    presentation.save("transparent_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

Az eredmény:

![Az átlátszó szövegrészek](transparent_text_portions.png)

## **Karakterköz beállítása szöveghez**

Használd a [BasePortionFormat.spacing](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/spacing/) metódust a karakterköz növelésére vagy szűkítésére egy szövegdobozban. A példák 3 pont közet adnak hozzá; negatív értékek szűkítik a szöveget.

Az alábbi Python‑kód azt mutatja, hogyan növelhető a karakterköz a **teljes bekezdésben**:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Megjegyzés: Negatív értékek használata a karakterköz szorításához.
    paragraph.paragraph_format.default_portion_format.spacing = 3  # Növelje a karakterközt.

    presentation.save("character_spacing_in_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

Az eredmény:

![A karakterköz a bekezdésben](character_spacing_in_paragraph.png)

Az alábbi kódrészlet azt mutatja, hogyan növelhető a karakterköz **félkövér betűvel** rendelkező szövegrészeknél:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # Megjegyzés: Negatív értékek használata a karakterköz szorításához.
            portion.portion_format.spacing = 3  # Növelje a karakterközt.

    presentation.save("character_spacing_in_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

Az eredmény:

![A karakterköz a szövegrészekben](character_spacing_in_text_portions.png)

### **Kerning letiltása bizonyos betűtípusoknál**

Bizonyos esetekben az Aspose.Slides által renderelt szöveg kicsit szorosabbnak tűnhet, mint a PowerPoint‑ban megjelenő szöveg. Ennek oka, hogy a PowerPoint bizonyos betűtípusoknál figyelmen kívül hagyja a kerning adatokat, még akkor is, ha a betűtípus tartalmaz érvényes kerning információt és a PowerPoint beállításaiban a kerning engedélyezve van.

Az ilyen esetekben a renderelt eredményt a PowerPoint‑hoz közelebb hozhatod, ha letiltod a kerninget azon szövegrészeknél, amelyek az érintett betűtípust használják. Állítsd a [BasePortionFormat.kerning_minimal_size](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/kerning_minimal_size/) értékét a tényleges betűméretnél nagyobbra. Ez a példa a "presentation.pptx" fájlt igényli, ahol az első dián az első alakzat egy szövegdoboz. A hatékony betűneveket (beleértve az örökölt betűket) ellenőrzi, és 100 pontos küszöböt állít be azoknál a részeknél, amelyek a Roboto betűtípust használják. Így a 100 pont alatti betűmérettel rendelkező, a feltételnek megfelelő részeknél a kerning letiltásra kerül:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    target_font = "Roboto"

    for paragraph in auto_shape.text_frame.paragraphs:
        for portion in paragraph.portions:
            text_format = portion.portion_format.get_effective()
            fonts = (text_format.latin_font, text_format.east_asian_font, text_format.complex_script_font)
            uses_target_font = any(font is not None and font.font_name == target_font for font in fonts)

            if uses_target_font:
                portion.portion_format.kerning_minimal_size = 100

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

Az alacsonyabb küszöb alatt lévő szövegrészeknél ez a beállítás megakadályozza a kerninget, és segíthet az Aspose.Slides renderelését a PowerPoint‑ban megjelenő vizuális kimenettel összhangba hozni az érintett betűtípusok esetén.

## **Szöveg‑betűtípus‑tulajdonságok kezelése**

A betűtípus‑tulajdonságok beállíthatók bekezdés‑szinten a [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_portion_format/) segítségével vagy egyes részeknél a [PortionFormat](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/) használatával.

Az alábbi példa az első bekezdés alapértelmezett betűtípusát 12 pontos Times New Roman-re állítja be félkövér, dőlt és pontozott aláhúzással. Az egyes részeken megadott konkrét formázás felülírja az alapértelmezést.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Állítsa be a bekezdés betűtípus‑tulajdonságait.
    portion_format = paragraph.paragraph_format.default_portion_format
    portion_format.font_height = 12
    portion_format.font_bold = slides.NullableBool.TRUE
    portion_format.font_italic = slides.NullableBool.TRUE
    portion_format.font_underline = slides.TextUnderlineType.DOTTED
    portion_format.latin_font = slides.FontData("Times New Roman")

    presentation.save("font_properties_for_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

Az eredmény:

![A bekezdés betűtípus‑tulajdonságai](font_properties_for_paragraph.png)

Az alábbi példa 13 pontos Times New Roman‑t, dőlt formázást és pontozott aláhúzást alkalmaz azoknak a részeknek, amelyek hatékony formázása félkövér:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # Állítsa be a betűtípus‑tulajdonságokat a szövegrészhez.
            portion.portion_format.font_height = 13
            portion.portion_format.font_italic = slides.NullableBool.TRUE
            portion.portion_format.font_underline = slides.TextUnderlineType.DOTTED
            portion.portion_format.latin_font = slides.FontData("Times New Roman")

    presentation.save("font_properties_for_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

Az eredmény:

![A szövegrészek betűtípus‑tulajdonságai](font_properties_for_text_portions.png)

## **Szövegmagasság normalizálásának vezérlése**

Használd a [BasePortionFormat.normalise_height](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/normalise_height/) metódust sablon‑tipográfia reprodukálásakor vagy a karaktermagasság‑különbségek vizsgálatakor. PowerPoint‑ban a normalizálás engedélyezése függőlegesen nyújtja vagy összenyomja az egyes karaktereket, hogy egyenletes látható magasságot kapjanak a szövegrészben. Nem garantálja, hogy a különböző betűtípusok magassága egyenlő lesz.

Állítsd a tulajdonságot a [NullableBool.TRUE vagy FALSE](https://reference.aspose.com/slides/python-net/aspose.slides/nullablebool/) értékre a normalizálás kifejezett engedélyezéséhez vagy letiltásához. A `NullableBool.NOT_DEFINED` helyi beállítást nem definiálja, így a részörökli az értéket, például a bekezdés [default_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_portion_format/)-ből. Nem ugyanaz, mint a `False`. Használd a [PortionFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/get_effective/) és olvasd a [IBasePortionFormatEffectiveData.normalise_height](https://reference.aspose.com/slides/python-net/aspose.slides/ibaseportionformateffectivedata/normalise_height/) értékét a feloldott Boolean érték megállapításához.

Az alábbi önálló példa **Arial** betűtípus telepítését igényli. Két szövegváltozatot hoz létre, amelyek ugyanazokat a nagy‑ és kisbetűs betűket, lejjebb lógó karaktereket és ékezetes betűket tartalmazzák 54 pontban. Mindkét bekezdés alapértelmezés szerint engedélyezi a normalizálást. A felső rész kifejezetten letiltja, az alsó rész örökli. A keretméretek, margók és bekezdés‑közök azonosak, a sortörés és az automatikus illesztés le van tiltva a konzisztens összehasonlítás érdekében. A példa kiírja a `FALSE: False` és `NOT_DEFINED: True` üzeneteket, majd elmenti a **text_height_normalization.pptx** fájlt.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    settings = [slides.NullableBool.FALSE, slides.NullableBool.NOT_DEFINED]

    for i, setting in enumerate(settings):
        shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 60 + i * 200, 660, 150)
        shape.fill_format.fill_type = slides.FillType.NO_FILL
        shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL

        text_frame = shape.text_frame
        text_frame.text = "Hxgjpq ÅÉ 0123"
        text_frame.text_frame_format.autofit_type = slides.TextAutofitType.NONE
        text_frame.text_frame_format.wrap_text = slides.NullableBool.FALSE
        text_frame.text_frame_format.anchoring_type = slides.TextAnchorType.TOP
        text_frame.text_frame_format.margin_top = 0
        text_frame.text_frame_format.margin_left = 0

        paragraph = text_frame.paragraphs[0]
        paragraph.paragraph_format.alignment = slides.TextAlignment.LEFT
        paragraph.paragraph_format.space_before = 0
        paragraph.paragraph_format.space_after = 0
        paragraph.paragraph_format.space_within = 100
        paragraph.paragraph_format.default_portion_format.normalise_height = slides.NullableBool.TRUE

        portion = paragraph.portions[0]
        portion.portion_format.latin_font = slides.FontData("Arial")
        portion.portion_format.font_height = 54
        portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
        portion.portion_format.fill_format.solid_fill_color.color = "black"
        portion.portion_format.normalise_height = setting

        print(f"{setting.name}: {portion.portion_format.get_effective().normalise_height}")

    presentation.save("text_height_normalization.pptx", slides.export.SaveFormat.PPTX)
```

Az alábbi összehasonlítás a mentett prezentációból lett exportálva. A felső sorban a normalizálás le van tiltva (`FALSE`); az alsó sor örökli az engedélyezett beállítást (`NOT_DEFINED` → `True`). Az eredmény reprodukálásához telepítsd az Arial‑t.

![Arial 54‑pontos szöveg normalizálással letiltva felül és örökölt normalizálással alul](text_height_normalization.png)

A normalizálás módosítja a karaktermagasságot anélkül, hogy megváltoztatná a hozzárendelt [font_height](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/font_height/) értéket, amely a betűméretet pontban adja meg. A bekezdés [space_within](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_within/) vezérli a sorközöt, míg a szövegkeret [autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/autofit_type/) szabályozza, hogyan igazodik a szöveg vagy a keret mérete. Ezek a beállítások különböző célokat szolgálnak, és önállóan befolyásolhatják az elrendezést. További információkért a bekezdés‑formázásról és öröklésről lásd a [Manage Paragraph](/slides/hu/python-net/manage-paragraph/) oldalt.

## **Áthúzás alkalmazása és eltávolítása**

Használd a [BasePortionFormat.strikethrough_type](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/strikethrough_type/) metódust egy szövegrészben, ha javításokat, törölt kifejezéseket vagy korábbi árakat szeretnél megjeleníteni a eredeti szöveg törlése nélkül. Állítsd a [TextStrikethroughType.SINGLE vagy DOUBLE](https://reference.aspose.com/slides/python-net/aspose.slides/textstrikethroughtype/) értékre egy vagy két vonal megjelenítéséhez a szöveg felett.

Az áthúzás eltávolításához állítsd `TextStrikethroughType.NONE`‑ra. Ez kifejezetten letiltja a hatást, akkor is, ha a környező formázás áthúzást tartalmaz. Ezzel szemben a `TextStrikethroughType.NOT_DEFINED` helyi beállítást nem definiálja, így a rész örökíti a formázást, például a bekezdésből. Nem garantálja, hogy az áthúzás eltűnik. A végeredmény‑formázás, beleértve az örökölt értékeket, lekérdezéséhez használd a [PortionFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/get_effective/) metódust.

Az alábbi önálló példa három ár‑összehasonlítást hoz létre. Minden bekezdésben külön rész van a címke, az előző ár és a jelenlegi ár számára, így csak az előző árra vonatkozik az áthúzás. Az első sorban alkalmazzák, majd eltávolítják az áthúzást; a többi sorban egy‑ és kétszeres áthúzás marad. Ennek a tulajdonságnak a módosítása megőrzi a szöveget és egyéb formázását, beleértve a félkövér előző árat.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 620, 220)
    shape.fill_format.fill_type = slides.FillType.NO_FILL
    shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL
    shape.text_frame.paragraphs.clear()

    labels = ["None: ", "Single: ", "Double: "]

    for label in labels:
        paragraph = slides.Paragraph()
        paragraph.paragraph_format.alignment = slides.TextAlignment.LEFT
        paragraph.paragraph_format.space_after = 20

        portion_format = paragraph.paragraph_format.default_portion_format
        portion_format.font_height = 28
        portion_format.latin_font = slides.FontData("Arial")
        portion_format.fill_format.fill_type = slides.FillType.SOLID
        portion_format.fill_format.solid_fill_color.color = draw.Color.black

        paragraph.portions.add(slides.Portion(label))

        previous_price = slides.Portion("$100")
        previous_price.portion_format.font_bold = slides.NullableBool.TRUE
        paragraph.portions.add(previous_price)
        paragraph.portions.add(slides.Portion(" → $80"))

        shape.text_frame.paragraphs.add(paragraph)

    paragraphs = shape.text_frame.paragraphs

    # Alkalmazzon áthúzást, majd kifejezetten távolítsa el az első előző árból.
    paragraphs[0].portions[1].portion_format.strikethrough_type = slides.TextStrikethroughType.SINGLE
    paragraphs[0].portions[1].portion_format.strikethrough_type = slides.TextStrikethroughType.NONE

    paragraphs[1].portions[1].portion_format.strikethrough_type = slides.TextStrikethroughType.SINGLE
    paragraphs[2].portions[1].portion_format.strikethrough_type = slides.TextStrikethroughType.DOUBLE

    presentation.save("strikethrough.pptx", slides.export.SaveFormat.PPTX)
```

Az eredmény felülről lefelé: nincs áthúzás, egyszeres áthúzás és kétszeres áthúzás.

![Az előző árak áthúzás nélkül, egyszeres áthúzással és kétszeres áthúzással](strikethrough.png)

## **Szöveg forgatása**

Használd a [TextFrameFormat.text_vertical_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/text_vertical_type/) metódust, hogy előre definiált szöveg‑orientációt állíts be egy alakzaton belül.

Az alábbi kódrészlet a szöveg‑orientációt a [TextVerticalType.VERTICAL270](https://reference.aspose.com/slides/python-net/aspose.slides/textverticaltype/) értékre állítja, amely a szöveget **90 fokkal az óramutató járása ellenkező irányba** forgatja:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL270

    presentation.save("text_rotation.pptx", slides.export.SaveFormat.PPTX)
```

Az eredmény:

![A szöveg forgatása](text_rotation.png)

## **Számjegyek egymás mellett megjelenítése függőleges szövegben**

Kétjegyű szám függőleges japán címkében való egyben tartásához helyezd mindkét számjegyet egy szövegrészbe, és állítsd be a [BasePortionFormat.kumimoji](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/kumimoji/) értékét. A példa két címkét hoz létre egy új prezentációban a [TextVerticalType.EAST_ASIAN_VERTICAL](https://reference.aspose.com/slides/python-net/aspose.slides/textverticaltype/) és a 40‑pontos MS Gothic használatával. A numerikus részhez rendelt [NullableBool](https://reference.aspose.com/slides/python-net/aspose.slides/nullablebool/) érték különbözik.

```python
import aspose.slides as slides


def add_label(slide, x, kumimoji):
    label = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, x, 48, 120, 420)
    label.fill_format.fill_type = slides.FillType.NO_FILL
    label.line_format.fill_format.fill_type = slides.FillType.NO_FILL

    frame = label.add_text_frame("")
    frame.text_frame_format.text_vertical_type = slides.TextVerticalType.EAST_ASIAN_VERTICAL

    paragraph = frame.paragraphs[0]
    portion_format = paragraph.paragraph_format.default_portion_format
    font = slides.FontData("MS Gothic")
    portion_format.latin_font = font
    portion_format.east_asian_font = font
    portion_format.font_height = 40
    portion_format.fill_format.fill_type = slides.FillType.SOLID
    portion_format.fill_format.solid_fill_color.color = "black"

    digits = slides.Portion("12")
    digits.portion_format.kumimoji = kumimoji

    paragraph.portions.clear()
    paragraph.portions.add(slides.Portion("令和"))
    paragraph.portions.add(digits)
    paragraph.portions.add(slides.Portion("年"))


with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    add_label(slide, 120, slides.NullableBool.TRUE)
    add_label(slide, 360, slides.NullableBool.FALSE)
    
    presentation.save("vertical_date.pptx", slides.export.SaveFormat.PPTX)
```

PowerPoint‑ban a bal oldali címke (`TRUE`) egyenes, egymás mellett álló számjegyeket mutat a 和 és 年 közötti részen. A jobb oldali címke (`FALSE`) a párt 90 fokkal az óramutató járásával megegyező irányban forgatja. A körülvevő japán karakterek mindkét címkénél egyenesek maradnak.

![PowerPoint összehasonlítás a függőleges dátumcímkékről, bal oldalon álló számjegyekkel, jobb oldalon elforgatott számjegyekkel.](vertical_date.png)

## **Egyéni forgatás beállítása szövegkeretekhez**

Használd a [TextFrameFormat.rotation_angle](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/rotation_angle/) metódust, hogy egyedi forgatási szöget állíts be egy [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/)-hez.

Az alábbi kódrészlet 3 fokkal az óramutató járása irányában forgatja a szövegkeretet az alakzaton belül:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.rotation_angle = 3

    presentation.save("custom_text_rotation.pptx", slides.export.SaveFormat.PPTX)
```

Az eredmény:

![Az egyéni szöveg forgatása](custom_text_rotation.png)

## **Bekezdések sortávolságának beállítása**

Az Aspose.Slides a [ParagraphFormat.space_after](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_after/), [ParagraphFormat.space_before](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_before/) és [ParagraphFormat.space_within](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_within/) használatával szabályozza a bekezdések távolságát. Ezeket a tulajdonságokat a következőképpen használhatod:

* Pozitív érték esetén a sortávolság a sorköz százalékában adható meg.
* Negatív érték esetén a sortávolság pontban adható meg.

Az alábbi példa az első bekezdés távolságát a sortávolság 200 %-ára (dupla sorköz) állítja:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    paragraph.paragraph_format.space_within = 200

    presentation.save("line_spacing.pptx", slides.export.SaveFormat.PPTX)
```

Az eredmény:

![A bekezdésen belüli sortávolság](line_spacing.png)

## **Sortörés szabályozása**

A bekezdés sortörés‑szabályai szűk szövegblokkban és olyan prezentációkban hasznosak, ahol latin és kelet‑ázsiai szöveg keveredik. A következő tulajdonságok a [ParagraphFormat](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/)-hez tartoznak, ezért egy egész bekezdésre vonatkoznak:

- [latin_line_break](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/latin_line_break/) szabályozza a latin sortörés‑szabályokat. Vegyes szöveg esetén ennek változtatása befolyásolhatja a kelet‑ázsiai szöveg és írásjelek sortörését is.
- [east_asian_line_break](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/east_asian_line_break/) szabályozza a kelet‑ázsiai sortörés‑szabályokat, beleértve a sor elején és végén elhelyezhető karakterek korlátozását.

Ezek a szabályok nem helyettesítik a [TextFrameFormat.wrap_text](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/wrap_text/)-et, amely automatikus sortörést engedélyez egy szövegkereten belül. A sortörés‑szabályok befolyásolják a layoutot, ha sortörés történik; nem illesztenek sortörés‑karaktert. Egy explicit sortörés új sort hoz létre a bekezdésen belül, függetlenül a rendelkezésre álló szélességtől.

Az alábbi önálló példa egy keskeny szövegblokkot hoz létre, amely kínai és latin szöveget tartalmaz. Mindkét sortörés‑tulajdonságot explicit módon beállítja, majd elmenti a **line_breaking.pptx** fájlt. A szabály egyikének értékének módosításához változtasd meg a megfelelő tulajdonságot, a másik beállítást változatlanul hagyva. A példa 24 pontos Arial‑t és SimSun‑t használ 160 pont széles kerettel és nulla vízszintes szövegkeret‑margóval. A [TextFrameFormat.autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/autofit_type/) értéke [TextAutofitType.NONE](https://reference.aspose.com/slides/python-net/aspose.slides/textautofittype/), így a szöveg mérete és a keret méretei rögzítve maradnak.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 160, 300)
    shape.fill_format.fill_type = slides.FillType.NO_FILL

    text_frame = shape.text_frame
    text_frame.text_frame_format.wrap_text = slides.NullableBool.TRUE
    text_frame.text_frame_format.autofit_type = slides.TextAutofitType.NONE
    text_frame.text_frame_format.margin_left = 0
    text_frame.text_frame_format.margin_right = 0

    paragraph = text_frame.paragraphs[0]
    paragraph.text = "中文排版测试，PowerPoint 中文演示。"

    paragraph_format = paragraph.paragraph_format
    paragraph_format.alignment = slides.TextAlignment.LEFT
    paragraph_format.default_portion_format.font_height = 24
    paragraph_format.default_portion_format.latin_font = slides.FontData("Arial")
    paragraph_format.default_portion_format.east_asian_font = slides.FontData("SimSun")
    paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    paragraph_format.latin_line_break = slides.NullableBool.FALSE
    paragraph_format.east_asian_line_break = slides.NullableBool.TRUE

    presentation.save("line_breaking.pptx", slides.export.SaveFormat.PPTX)
```

## **Legördülő központozás szabályozása**

A [ParagraphFormat.hanging_punctuation](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/hanging_punctuation/) lehetővé teszi, hogy az alkalmas írásjelek a sor jobb szélén túlnyúljanak a következő sor helyett. Ez az egész bekezdésre vonatkozik, és eltér a függőleges behúzástól.

Az alábbi önálló példa 100 pont széles szövegkeretben engedélyezi a legördülő központozást, és elmenti a **hanging_punctuation.pptx** fájlt. 24 pontos Arial és nulla vízszintes szövegkeret‑margó esetén a végpont a “sentence” szó után marad, és túlnyúlik a jobb szöveg szélén. Állítsd a tulajdonságot [NullableBool.FALSE](https://reference.aspose.com/slides/python-net/aspose.slides/nullablebool/) értékre a összehasonlításhoz: ezekkel a beállításokkal a pont külön sorban jelenik meg. A sortörés engedélyezett, az automatikus illesztés tiltott, hogy a rendelkezésre álló szélesség rögzített maradjon.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 100, 200)
    shape.fill_format.fill_type = slides.FillType.NO_FILL

    text_frame = shape.text_frame
    text_frame.text_frame_format.wrap_text = slides.NullableBool.TRUE
    text_frame.text_frame_format.autofit_type = slides.TextAutofitType.NONE
    text_frame.text_frame_format.margin_left = 0
    text_frame.text_frame_format.margin_right = 0

    paragraph = text_frame.paragraphs[0]
    paragraph.text = "Simple text, next sentence."

    paragraph_format = paragraph.paragraph_format
    paragraph_format.alignment = slides.TextAlignment.LEFT
    paragraph_format.default_portion_format.font_height = 24
    paragraph_format.default_portion_format.latin_font = slides.FontData("Arial")
    paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    paragraph_format.hanging_punctuation = slides.NullableBool.TRUE

    presentation.save("hanging_punctuation.pptx", slides.export.SaveFormat.PPTX)
```

Nem minden írásjel tud „lefutni”. A látható eredmény a [betűtípus és elrendezési feltételektől](#control-line-breaking) függ; a betűtípus, a rendelkezésre álló szélesség, a margók vagy az automatikus illesztés módosítása eltüntetheti a látható különbséget.

## **Automatikus illesztés típusának beállítása szövegkeretekhez**

A [TextFrameFormat.autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/autofit_type/) határozza meg, hogyan viselkedik a szöveg, ha túllépi a tartályának határait. Használd a szöveg automatikus zsugorodásának, kiterülésének vagy az alakzat automatikus átméretezésének vezérlésére. Az alábbi példa úgy konfigurálja az alakzatot, hogy a szöveghez igazodva átméretezze magát, majd elmenti a **autofit_type.pptx** fájlt.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE

    presentation.save("autofit_type.pptx", slides.export.SaveFormat.PPTX)
```

Az automatikus sortörés utáni sorok számának és a szöveg‑ vagy alakzat‑szélesség változásának megtekintéséhez lásd a [Count Rendered Lines](/slides/hu/python-net/manage-paragraph/) oldalt. A sorok száma önmagában nem mutatja, hogy a szöveg túlnyúlik‑e a tárolóján.

## **Szövegkeretek rögzítésének beállítása**

A [TextFrameFormat.anchoring_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/anchoring_type/) meghatározza, hogyan helyezkedik el a szöveg függőlegesen egy alakzaton belül, például a tetején, közepén vagy alján. Az alábbi példa a szöveget az első alakzat aljára rögzíti, majd elmenti a **text_anchor.pptx** fájlt.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.anchoring_type = slides.TextAnchorType.BOTTOM

    presentation.save("text_anchor.pptx", slides.export.SaveFormat.PPTX)
```

## **Szöveg tabulálásának beállítása**

Használd a [ParagraphFormat.default_tab_size](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_tab_size/) és a [ParagraphFormat.tabs](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/tabs/) metódusokat a tabulátor‑állítások konfigurálásához egy bekezdésben. Az alábbi példa az alapértelmezett tabulátor‑intervallumot 100 pontra állítja, és egy 30 pontnál balra igazított tabulátort ad hozzá. Ezek a beállítások a tabulátor‑karaktert tartalmazó szövegre hatnak.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    paragraph.paragraph_format.default_tab_size = 100
    paragraph.paragraph_format.tabs.add(30, slides.TabAlignment.LEFT)

    presentation.save("paragraph_tabs.pptx", slides.export.SaveFormat.PPTX)
```

Az eredmény:

![A bekezdés tabulátorai](paragraph_tabs.png)

## **Helyesírás‑nyelv beállítása**

Az Aspose.Slides a [BasePortionFormat.language_id](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/language_id/) használatával lehetővé teszi a szövegrész helyesírás‑nyelvének beállítását. A helyesírás‑nyelv határozza meg, hogy a PowerPoint milyen nyelvet használ a helyesírás‑ és nyelvtani ellenőrzéshez.

Az alábbi példa a “presentation.pptx” fájlt igényli, amelynek első diáján az első alakzat egy szövegdoboz, és legalább egy bekezdést tartalmaz. Az első bekezdés tartalmát “1。”‑ra cseréli, a betűtípust SimSunra állítja, és a Simplified Chinese (`zh-CN`) helyesírás‑nyelvet rendeli hozzá. Az eredményt a **proofing_language.pptx** fájlba menti:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    paragraph = auto_shape.text_frame.paragraphs[0]
    paragraph.portions.clear()

    font = slides.FontData("SimSun")

    text_portion = slides.Portion()
    text_portion.portion_format.complex_script_font = font
    text_portion.portion_format.east_asian_font = font
    text_portion.portion_format.latin_font = font

    # Állítsa be a helyesírási nyelvet egyszerű kínai nyelvre.
    text_portion.portion_format.language_id = "zh-CN"

    text_portion.text = "1。"
    paragraph.portions.add(text_portion)

    presentation.save("proofing_language.pptx", slides.export.SaveFormat.PPTX)
```

### **Nyelvi metaadat másolása**

Többnyelvű szöveg sablonból való másolásakor őrizd meg mind a [BasePortionFormat.language_id](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/language_id/), mind a [BasePortionFormat.alternative_language_id](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/alternative_language_id/) értékét. Az alábbi önálló példa egy forrás‑részletet hoz létre, amelynek nyelve az amerikai angol, alternatív nyelve pedig a francia, és átmásolja a szöveget és az azonosítókat egy új prezentációban lévő részletbe.

```python
import aspose.slides as slides

source = slides.Portion("Hello! Bonjour!")
source.portion_format.language_id = "en-US"
source.portion_format.alternative_language_id = "fr-FR"

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 80)
    paragraph = shape.text_frame.paragraphs[0]
    paragraph.portions.clear()

    destination = slides.Portion()
    destination.text = source.text
    destination.portion_format.language_id = source.portion_format.language_id
    # Ha a forrásnak nincs alternatív nyelve, a None törli a cél értékét.
    destination.portion_format.alternative_language_id = source.portion_format.alternative_language_id
    paragraph.portions.add(destination)

    presentation.save("copied_language_metadata.pptx", slides.export.SaveFormat.PPTX)
```

Ha forrást akarsz alternatív nyelv nélkül, hagyd ki a `"fr-FR"` hozzárendelését. Ebben az esetben az alternatív azonosító `None`, és a másolási utasítás megőrzi a hiányát anélkül, hogy alapértelmezett értéket hozna be, még akkor sem, ha a cél már rendelkezik alternatív nyelvvel.

Ezek az azonosítók nyelvi metaadatként tárolódnak. A megőrzésük nem határozza meg, hogy a PowerPoint melyik szótárat használja a helyesírás‑ vagy nyelvtani ellenőrzéshez.

## **Alapértelmezett nyelv beállítása**

Használd a [LoadOptions.default_text_language](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/default_text_language/) metódust a szöveg alapértelmezett nyelvének meghatározásához a prezentáció betöltése vagy létrehozása során. Az alábbi példa egy prezentációt hoz létre, amelynek alapértelmezett szövegnyelvén az amerikai angol van, egy szövegdobozt ad hozzá, majd az első szövegrészre `en-US`‑t ír ki.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.default_text_language = "en-US"

with slides.Presentation(load_options) as presentation:
    slide = presentation.slides[0]

    # Hozzon létre egy új négyszög alakzatot szöveggel.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 50)
    shape.text_frame.text = "Sample text"

    # Ellenőrizze az első rész nyelvét.
    portion = shape.text_frame.paragraphs[0].portions[0]
    print(portion.portion_format.language_id)
```

## **Alapértelmezett szöveg‑stílus beállítása**

Az alapértelmezett szövegformázás beállításához a prezentáció szintjén használd a [Presentation.default_text_style](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/default_text_style/) metódust.

Az alábbi példa 14 pontos félkövér betűtípust állít be alapértelmezettként az új prezentáció felső‑szintű bekezdéseihez, majd a **default_text_style.pptx** fájlba menti. A szöveg örökölheti ezeket az alapértelmezéseket, hacsak egy specifikusabb formázás nem írja felül őket.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    # Szerezze meg a legfelső szintű bekezdésformátumot.
    paragraph_format = presentation.default_text_style.get_level(0)

    if paragraph_format is not None:
        paragraph_format.default_portion_format.font_height = 14
        paragraph_format.default_portion_format.font_bold = slides.NullableBool.TRUE

    presentation.save("default_text_style.pptx", slides.export.SaveFormat.PPTX)
```

## **Szöveg kinyerése nagybetűs hatással**

PowerPoint‑ban a **All Caps** betűhatás alkalmazása miatt a szöveg nagybetűként jelenik meg a dián, még akkor is, ha eredetileg kisbetűkkel lett begépelve. Amikor az Aspose.Slides‑el ilyen szövegrészt kérsz le, a könyvtár pontosan úgy adja vissza a szöveget, ahogy beírták. A megjelenített szöveghez való illeszkedéshez ellenőrizd a [TextCapType](https://reference.aspose.com/slides/python-net/aspose.slides/textcaptype/) értékét, és a `ALL` állapot esetén konvertáld a visszakapott karakterláncot nagybetűssé.

Ez a példa a “sample2.pptx” fájlt igényli, amelynek első diáján az első alakzat egy szövegdoboz. Az első bekezdés első része a “Hello, Aspose!” szöveget tartalmazza a **All Caps** hatással, az alább látható módon.

![A All Caps hatás](all_caps_effect.png)

Az alábbi kódrészlet azt mutatja, hogyan nyerjük ki a szöveget a **All Caps** hatással:

```python
import aspose.slides as slides

with slides.Presentation("sample2.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    text_portion = auto_shape.text_frame.paragraphs[0].portions[0]

    print("Original text:", text_portion.text)

    text_format = text_portion.portion_format.get_effective()
    if text_format.text_cap_type == slides.TextCapType.ALL:
        text = text_portion.text.upper()
        print("All-Caps effect:", text)
```

Kimenet:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **GYIK**

**Hogyan módosítható a szöveg egy táblázatban egy dián?**

A táblázat szövegének módosításához egy dián használd a [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) osztályt. Iterálj a cellákon, és frissítsd őket a [Cell.text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/cell/text_frame/) és a bekezdés‑formázás a [Paragraph.paragraph_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/paragraph_format/) segítségével.

**Hogyan alkalmazhatok színátmenetet a szövegre egy PowerPoint dián?**

A színátmenet alkalmazásához a szövegre használd a [BasePortionFormat.fill_format](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/fill_format/) metódust. Állítsd a [FillFormat.fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/) értékét [FillType.GRADIENT](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/)‑re, és konfiguráld a színátmenet‑állomásokat, irányt és átlátszóságot.

Kapcsolódó funkció: [Format text within slides](/slides/hu/features/text-formatting/).