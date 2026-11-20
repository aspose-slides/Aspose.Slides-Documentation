---
title: Prezentáció szövegének formázása Pythonban
linktitle: Szövegformázás
type: docs
weight: 50
url: /hu/python-net/text-formatting/
keywords:
- bekezdés igazítása
- szövegstílus
- szöveg háttér
- szöveg átlátszóság
- karakterköz
- betűtípus tulajdonságok
- betűtípus család
- szöveg forgatás
- forgatási szög
- szövegkeret
- sorköz
- automatikus méretezés tulajdonság
- szövegkeret horgony
- szöveg tabuláció
- alapértelmezett nyelv
- PowerPoint
- OpenDocument
- prezentáció
- Python
- Aspose.Slides
description: "Formázza és stilizálja a szöveget a PowerPoint és OpenDocument prezentációkban az Aspose.Slides for Python via .NET segítségével. Testreszabhatja a betűtípusokat, színeket, igazítást és még sok mást."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet szöveget formázni PowerPoint és OpenDocument bemutatókban az Aspose.Slides for Python via .NET használatával. Kitér a háttérszínekre, átlátszóságra, karakterközökre, betűtípus‑tulajdonságokra, forgatásra, bekezdésszénekre, automatikus méretezés viselkedésére, szöveg‑horgonyzásra, tabulátorokra és nyelvi beállításokra.

Kivéve ha másként van megadva, a példák a [sample.pptx](sample.pptx) fájlt használják. Első alakzatának első diáján egy szövegdoboz található, és az első bekezdés tartalmazza az alább látható szöveget. Mind a dia, mind az alakzat indexelése nullával kezdődik. A félkövér részeket kiválasztó példák hatékony formázást használnak, beleértve az örökölt félkövér formázást:

![Minta szöveg](sample_text.png)

A szöveg szó szerinti kereséséhez vagy reguláris kifejezésekkel való egyezéshez lásd a [Search and Replace Text](/slides/hu/python-net/search-and-replace-text/) oldalt.

## **Szöveg háttérszínének beállítása**

Használd a [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_portion_format/) tulajdonságot egy bekezdés alapértelmezett kiemelési színének beállításához, vagy a [BasePortionFormat.highlight_color](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/highlight_color/) tulajdonságot egyedi szövegrészekhez.

Az alábbi példa egy világosszürke kiemelést állít be alapértelmezettnek az első bekezdéshez. Az egyedi részeken megadott kiemelési színek felülírják ezt az alapértelmezést:

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

Az alábbi kódrészlet bemutatja, hogyan állítható be a háttérszín **félkövér betűtípusú szövegrészek** esetén:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # Állítsa be a kiemelési színt a szövegrészhez.
            portion.portion_format.highlight_color.color = draw.Color.light_gray

    presentation.save("gray_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

Az eredmény:

![A szürke szövegrészek](gray_text_portions.png)

## **Szövegbekezdések igazítása**

Használd a [ParagraphFormat.alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/) tulajdonságot a bekezdés igazításának beállításához egy szövegdobozon belül. Az érték lehet középre igazított, balra, jobbra, sorkizárt stb.

Az alábbi kódrészlet bemutatja, hogyan igazítható a bekezdés **középre**:

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

## **Betűk igazítása egy soron belül**

Használd a [ParagraphFormat.font_alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/font_alignment/) tulajdonságot a különböző betűméretű szövegrészek függőleges igazításához egy soron belül. Ez a beállítás a teljes bekezdésre vonatkozik, és minden sorban szabályozza az igazítást.

Az alábbi önálló példa négy címkézett szövegdobozt hoz létre egy dián. Minden bekezdés ugyanazt a szöveget tartalmazza 18, 36 és 54 pont méretben, különböző betűigazítással. Az Arial betűtípust használja, letiltja az automatikus méretezést és a sortörést, és a szövegdobozok elég nagyok egy sorhoz.

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

![Alapvonal, felső, középső és alsó betűigazítás összehasonlítása kevert betűméretekkel](font_alignment.png)

A betűigazítás betűmetrikákat használ, ezért az egyes betűk látható szélei nem feltétlenül illeszkednek pontosan egymáshoz. A példa egy nagybetűt és egy alsónyúlást (descender) tartalmaz, hogy megmutassa a különbséget az alapvonal és az alsó igazítás között. A betűtípus elérhetősége és helyettesítése, a használt karakterek, valamint a betűméretek közötti különbség befolyásolja az eredményt. A keret méretei, margói, sortávolsága, sortörés és automatikus méretezés szintén hatással vannak a megjelenésre; a módok összehasonlításakor tartsd meg ugyanazt a betűtípust és elrendezési beállításokat.

Ez a beállítás eltér a [ParagraphFormat.alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/)‑tól, amely a vízszintes bekezdés‑igazítást szabályozza, valamint a [TextFrameFormat.anchoring_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/anchoring_type/)‑tól, amely a szöveglapot függőlegesen helyezi el az alakzatban. A [BasePortionFormat.escapement](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/escapement/) használatával elvégzett felső- és alsóindexelés egyéni részeket eltol a alapvonalhoz képest, a bekezdés sorainak betűigazítását nem befolyásolja.

## **Szöveg átlátszóságának beállítása**

A szöveg átlátszósága a [BasePortionFormat.fill_format](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/fill_format/) színének alfa komponensén keresztül szabályozható. Az alábbi példákban a `alpha = 50` egy ARGB alfa‑csatorna érték a 0–255 tartományban, nem átlátszósági százalék.

Az alábbi kódrészlet mutatja, hogyan alkalmazható átlátszóság a **teljes bekezdésre**:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

alpha = 50

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Állítsa be a félig átlátszó fekete kitöltést a szöveghez.
    paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.from_argb(alpha, draw.Color.black)

    presentation.save("transparent_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

Az eredmény:

![Az átlátszó bekezdés](transparent_paragraph.png)

A következő kódrészlet azt mutatja, hogyan alkalmazható átlátszóság **félkövér betűtípusú szövegrészekre**:

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

Használd a [BasePortionFormat.spacing](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/spacing/) tulajdonságot a karakterek közötti távolság növelésére vagy csökkentésére egy szövegdobozban. A példák 3 pont távolságot adnak hozzá; a negatív értékek tömörítik a szöveget.

Az alábbi Python‑kód megmutatja, hogyan növelhető a karakterköz a **teljes bekezdésben**:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Megjegyzés: Negatív értékek használata a karakterköz összenyomásához.
    paragraph.paragraph_format.default_portion_format.spacing = 3  # Karakterköz növelése.

    presentation.save("character_spacing_in_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

Az eredmény:

![A karakterköz a bekezdésben](character_spacing_in_paragraph.png)

Az alábbi kódrészlet mutatja, hogyan növelhető a karakterköz **félkövér betűtípusú szövegrészeknél**:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # Megjegyzés: Negatív értékek használata a karakterköz összenyomásához.
            portion.portion_format.spacing = 3  # Karakterköz növelése.

    presentation.save("character_spacing_in_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

Az eredmény:

![A karakterköz a szövegrészekben](character_spacing_in_text_portions.png)

### **Kerning letiltása bizonyos betűtípusoknál**

Bizonyos esetekben az Aspose.Slides által renderelt szöveg kissé szorosabb lehet, mint a PowerPointban megjelenő változat. Ennek oka lehet, hogy a PowerPoint figyelmen kívül hagyja egyes betűtípusok kerning adatait, még ha a betűtípus tartalmaz érvényes kerning információt, és a PowerPoint beállításaiban a kerning engedélyezve is van.

Az ilyen esetekben a renderelt kimenet PowerPoint‑hoz közeli megjelenítéséhez letilthatod a kerninget a betűtípust használó szövegrészeknél. Állítsd a [BasePortionFormat.kerning_minimal_size](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/kerning_minimal_size/) értékét a tényleges betűméretnél nagyobbra. Ez a példa a "presentation.pptx" fájlt igényli, ahol az első alakzaton egy szövegdoboz van az első dián. Ellenőrzi a hatékony betűneveket, beleértve az örökölt betűket, és 100 pontos küszöböt állít be azokhoz a részekhez, amelyek a Roboto betűtípust használják. Ez letiltja a kerninget azokra a részekre, amelyek betűmérete 100 pont alatt van:

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

A küszöb alatti egyező szöveg esetén ez a beállítás megakadályozza a kerninget, és segíthet az Aspose.Slides megjelenésének a PowerPoint‑specifikus viselkedés által befolyásolt betűtípusok esetén való igazításában.

## **Szöveg betűtípus‑tulajdonságainak kezelése**

A betűtípus‑tulajdonságokat beállíthatod a bekezdés szintjén a [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_portion_format/) segítségével, vagy egyedi részeknél a [PortionFormat](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/) használatával.

Az alábbi példa a első bekezdés alapértelmezett betűtípusát 12 pontos Times New Romanra állítja félkövér, dőlt és pontozott aláhúzással. Az egyedi részeken megadott formázás felülírja ezeket az alapértékeket.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Állítsa be a bekezdés betűtulajdonságait.
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

Az alábbi példa 13 pontos Times New Roman, dőlt formázás és pontozott aláhúzás alkalmazását mutatja azon részekre, amelyek hatékony formázása félkövér:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # Állítsa be a betűtulajdonságokat a szövegrészhez.
            portion.portion_format.font_height = 13
            portion.portion_format.font_italic = slides.NullableBool.TRUE
            portion.portion_format.font_underline = slides.TextUnderlineType.DOTTED
            portion.portion_format.latin_font = slides.FontData("Times New Roman")

    presentation.save("font_properties_for_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

Az eredmény:

![A szövegrészek betűtípus‑tulajdonságai](font_properties_for_text_portions.png)

## **Szövegmagasság normalizálásának vezérlése**

Használd a [BasePortionFormat.normalise_height](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/normalise_height/) tulajdonságot sablon‑tipográfia reprodukálásakor vagy a karaktermagasság‑eltérések vizsgálatakor. PowerPointban a normalizálás engedélyezése függőlegesen nyújtja vagy összenyomja az egyes karaktereket, hogy egyenletes látható magasságuk legyen a szövegrészben. Nem garantálja a betűtípusok közötti magasság egységességét.

Állítsd a tulajdonságot a [NullableBool.TRUE vagy FALSE](https://reference.aspose.com/slides/python-net/aspose.slides/nullablebool/) értékekkel a normalizálás kifejezett engedélyezéséhez vagy tiltásához. A `NullableBool.NOT_DEFINED` helyi beállítást nem definiálja, ezért a rész örökli az értéket, például a bekezdés [default_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_portion_format/)‑ből. Ez nem ugyanaz, mint a `False`. Használd a [PortionFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/get_effective/) és olvasd a [IBasePortionFormatEffectiveData.normalise_height](https://reference.aspose.com/slides/python-net/aspose.slides/ibaseportionformateffectivedata/normalise_height/) értékét a feloldott logikai értékhez.

Az alábbi önálló példa a **Arial** betűtípus telepítését igényli. Két szöveglapot hoz létre, amelyek ugyanazokat a nagy‑ és kisbetűket, alsónyúlókat és ékezetes karaktereket tartalmazzák 54 ponton. Mindkét bekezdés alapértelmezés szerint engedélyezi a normalizálást. A felső rész explicit módon letiltja, az alsó rész pedig örökli. A keretméretek, margók és bekezdésszének azonosak, a sortörés és az automatikus méretezés le van tiltva a konzisztens összehasonlítás érdekében. A példa kiírja a `FALSE: False` és a `NOT_DEFINED: True` értékeket, majd elmenti a "text_height_normalization.pptx" fájlt.

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

Az alábbi összehasonlítás a mentett bemutatóból került exportálásra. A felső sorban a normalizálás le van tiltva (`FALSE`), az alsó sorban örökli az engedélyezett beállítást (`NOT_DEFINED` → `True`). A megjelenés reprodukálásához tartsd telepítve az Arial betűtípust.

![Arial 54‑pontos szöveg normalizálással letiltva felül és örökölt normalizálással alul](text_height_normalization.png)

A normalizálás a karaktermagasságot változtatja anélkül, hogy a hozzárendelt [font_height](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/font_height/) értéke változna, amely a betűméretet pontban adja meg. A bekezdés [space_within](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_within/) vezérli a sortávolságot, míg a szövegdoboz [autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/autofit_type/) szabályozza, hogy a szöveg vagy a tároló hogyan alkalmazkodik a mérethez. Ezek a beállítások különböző célokra szolgálnak, és önállóan befolyásolhatják a teljes elrendezést. A bekezdésformázás és öröklődés további részletei a [Manage Paragraph](/slides/hu/python-net/manage-paragraph/) oldalán találhatók.

## **Áthúzás alkalmazása és eltávolítása**

Használd a [BasePortionFormat.strikethrough_type](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/strikethrough_type/) tulajdonságot egy szövegrészhez, hogy javításokat, törölt kifejezéseket vagy korábbi árakat jeleníts meg anélkül, hogy a kiinduló szöveget törölnéd. Állítsd a [TextStrikethroughType.SINGLE vagy DOUBLE](https://reference.aspose.com/slides/python-net/aspose.slides/textstrikethroughtype/) értékre egy vagy két vonal megjelenítéséhez.

Az áthúzás eltávolításához állítsd `TextStrikethroughType.NONE`‑ra. Ez kifejezetten letiltja a hatást, még akkor is, ha a környező formázás áthúzást tartalmaz. Ezzel szemben a `TextStrikethroughType.NOT_DEFINED` helyi beállítást nem definiálja, így a rész örökölheti a formázást, például a bekezdéstől. Nem garantálja, hogy az áthúzás eltávolításra kerül. Használd a [PortionFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/get_effective/)‑t a végső formázás, így az örökölt értékek lekérdezéséhez.

Az alábbi önálló példa három ár‑összehasonlítást hoz létre. Minden bekezdés külön részeket tartalmaz a címke, a korábbi ár és az aktuális ár számára, így csak a korábbi ár érintett. Az első sorban alkalmazzák, majd eltávolítják az áthúzást; a többi sorban egy‑ és kétszeres áthúzás marad. Ennek a tulajdonságnak a módosítása megőrzi a szöveget és egyéb formázását, beleértve a félkövér korábbi árat.

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

    # Alkalmazza az áthúzást, majd kifejezetten távolítsa el az első korábbi árból.
    paragraphs[0].portions[1].portion_format.strikethrough_type = slides.TextStrikethroughType.SINGLE
    paragraphs[0].portions[1].portion_format.strikethrough_type = slides.TextStrikethroughType.NONE

    paragraphs[1].portions[1].portion_format.strikethrough_type = slides.TextStrikethroughType.SINGLE
    paragraphs[2].portions[1].portion_format.strikethrough_type = slides.TextStrikethroughType.DOUBLE

    presentation.save("strikethrough.pptx", slides.export.SaveFormat.PPTX)
```

Az eredmény felülről lefelé: nincs áthúzás, egyes áthúzás és kétszeres áthúzás.

![Korábbi árak áthúzás nélkül, egyes áthúzással és kétszeres áthúzással](strikethrough.png)

## **Szöveg elforgatása**

Használd a [TextFrameFormat.text_vertical_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/text_vertical_type/) tulajdonságot előre definiált szögelemzés beállításához egy alakzaton belül.

Az alábbi kódrészlet a szövegorientációt a [TextVerticalType.VERTICAL270](https://reference.aspose.com/slides/python-net/aspose.slides/textverticaltype/) értékre állítja, amely **90 fokkal óramutató járásával ellentétesen** forgatja a szöveget:

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

## **Egyéni forgatás beállítása szövegdobozokhoz**

Használd a [TextFrameFormat.rotation_angle](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/rotation_angle/) tulajdonságot egy egyéni forgatási szög beállításához egy [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/)-hez.

Az alábbi kódrészlet a szövegdobozt 3 fokkal az óramutató járásával megegyező irányban forgatja az alakzaton belül:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.rotation_angle = 3

    presentation.save("custom_text_rotation.pptx", slides.export.SaveFormat.PPTX)
```

Az eredmény:

![Az egyéni szövegforgatás](custom_text_rotation.png)

## **Bekezdés sortávolságának beállítása**

Az Aspose.Slides a [ParagraphFormat.space_after](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_after/), [ParagraphFormat.space_before](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_before/) és [ParagraphFormat.space_within](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_within/) tulajdonságokkal szabályozza a bekezdés‑távolságot. Ezeket a következőképpen használhatod:

* Pozitív érték esetén a sortávolság a sormagasság százalékában határozható meg.
* Negatív érték esetén a sortávolság pontban adható meg.

Az alábbi példa a bekezdésen belüli távolságot a sormagasság 200 %-ára (dupla sorköz) állítja:

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

## **Sortörés szabályainak vezérlése**

A bekezdés sortörési szabályai szűk szövegtömbökben és olyan prezentációkban hasznosak, ahol latin és ázsiai szöveg keveredik. Ezek a tulajdonságok a [ParagraphFormat](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/)‑hez tartoznak, így egy teljes bekezdésre vonatkoznak:

* A [latin_line_break](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/latin_line_break/) vezérli a latin szöveg sortörési szabályait. Vegyes szöveg esetén ennek módosítása megváltoztathatja az ázsiai szöveg és írásjelek tördelését is.
* Az [east_asian_line_break](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/east_asian_line_break/) vezérli az ázsiai szöveg sortörési szabályait, beleértve a sor elején és végén lévő karakterek korlátozását.

Ezek a szabályok nem helyettesítik a [TextFrameFormat.wrap_text](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/wrap_text/)‑t, amely automatikus sortörést engedélyez egy szövegdobozon belül. A sortörés befolyásolja a megjelenést, ha a környezeti beállítások engedélyezik, de nem szúr be sortörés‑karaktert. Egy explicite sortörés új sort hoz létre a bekezdésen belül, függetlenül a rendelkezésre álló szélességtől.

Az alábbi önálló példa egy szűk szövegtömböt hoz létre, amely kínai és latin szöveget tartalmaz. Mindkét sortörési tulajdonságot explicit módon állítja, és elmenti a "line_breaking.pptx" fájlt. A szabályok kísérletezéséhez módosítsd az adott tulajdonság értékét, miközben a másik beállítást változatlanul hagyod. A példa 24‑pontos Arial és SimSun betűket használ 160‑pontos keretszélességgel és nulla vízszintes szövegdoboz‑margóval. A [TextFrameFormat.autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/autofit_type/) értéke [TextAutofitType.NONE](https://reference.aspose.com/slides/python-net/aspose.slides/textautofittype/), így a szövegméret és a keretméretek rögzítve maradnak.

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

## **Függőleges írásjelek kezelése**

A [ParagraphFormat.hanging_punctuation](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/hanging_punctuation/) lehetővé teszi, hogy a jogosult írásjelek a sor jobb szélén túlnyúljanak a következő sor elfoglalása helyett. A beállítás a teljes bekezdésre vonatkozik, és eltér a függőleges behúzástól.

Az alábbi önálló példa 100 pont széles szövegdobozban engedélyezi a függőleges írásjeleket, és elmenti a "hanging_punctuation.pptx" fájlt. 24 pontos Arial betűtípussal és nulla vízszintes margóval a végső pont a "mondat" után marad, és a sor jobb szélén túlnyúlik. Állítsd a tulajdonságot [NullableBool.FALSE](https://reference.aspose.com/slides/python-net/aspose.slides/nullablebool/) értékre a összehasonlításhoz: ezekkel a beállításokkal a pont külön sorba kerül. A sortörés engedélyezett, az automatikus méretezés le van tiltva a szélesség fixen tartásához.

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

Nem minden írásjel akasztható fel. A látható eredmény a [betűtípus és elrendezési feltételektől](#control-line-breaking) függ: a betűtípus, a rendelkezésre álló szélesség, a margók vagy az automatikus méretezés módosítása eltüntetheti a látható különbséget.

## **Szövegdobozok automatikus méretezésének beállítása**

A [TextFrameFormat.autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/autofit_type/) határozza meg, hogyan viselkedjen a szöveg, ha túllépi a tároló határait. Használd a szöveg méretezésének, túltúlcsordulásának vagy a forma automatikus átméretezésének szabályozására. Az alábbi példa a formát úgy konfigurálja, hogy a szöveghez illeszkedően átméretezze a alakzatot, és elmenti az eredményt a "autofit_type.pptx" fájlba.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE

    presentation.save("autofit_type.pptx", slides.export.SaveFormat.PPTX)
```

A sorok számolásához automatikus sortörés után és ahhoz, hogy a szöveg vagy a forma szélessége miként változtatja az eredményt, lásd a [Count Rendered Lines](/slides/hu/python-net/manage-paragraph/). A sorok száma önmagában nem mutatja, hogy a szöveg túllépi-e a tárolót.

## **Szövegdobozok horgonypontjának beállítása**

A [TextFrameFormat.anchoring_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/anchoring_type/) meghatározza, hogyan helyezkedjen el a szöveg függőlegesen egy alakzatban, például fent, középen vagy lent. Az alábbi példa a szöveget az első alakzat aljához horgonyozza, és elmenti az eredményt a "text_anchor.pptx" fájlba.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.anchoring_type = slides.TextAnchorType.BOTTOM

    presentation.save("text_anchor.pptx", slides.export.SaveFormat.PPTX)
```

## **Szöveg tabulációjának beállítása**

Használd a [ParagraphFormat.default_tab_size](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_tab_size/) és a [ParagraphFormat.tabs](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/tabs/) tulajdonságokat a tabulátorok konfigurálásához egy bekezdésben. Az alábbi példa az alapértelmezett tabulátort 100 ponton állítja, és egy balra igazított tabulátort ad hozzá 30 pontnál. Ezek a beállítások a tabulátor‑karaktert tartalmazó szöveget érintik.

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

## **Nyelvi ellenőrzés beállítása**

Az Aspose.Slides a [BasePortionFormat.language_id](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/language_id/) tulajdonságával lehetővé teszi a nyelvi ellenőrzés beállítását egy szövegrészhez. A nyelvi ellenőrzés meghatározza, hogy a PowerPoint milyen nyelven végez helyesírási és nyelvtani ellenőrzést.

Az alábbi példa a "presentation.pptx" fájlt igényli, amelynek első alakzatán egy szövegdoboz van az első dián, és legalább egy bekezdést tartalmaz. A első bekezdés tartalmát "1。"‑re cseréli, a betűtípust SimSunra állítja, és a Simplified Chinese nyelvi ellenőrzést (`zh-CN`) rendeli hozzá. Az eredményt a "proofing_language.pptx" fájlba menti:

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

### **Nyelvi metaadatok másolása**

Többnyelvű szöveg sablonból történő másolásakor meg kell őrizni a [BasePortionFormat.language_id](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/language_id/) és a [BasePortionFormat.alternative_language_id](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/alternative_language_id/) értékeket. Az alábbi önálló példa egy forrás‑részletet hoz létre, amely US English nyelvet használ elsődleges nyelvként, és French‑t mint alternatív nyelvet, majd a szöveget és az azonosítókat egy új bemutató részéhez másolja.

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

Ha alternatív nyelv nélküli forrást szeretnél kipróbálni, hagyd el a `"fr-FR"` hozzárendelését. Ebben az esetben az alternatív azonosító `None`, és a másolás utasítás megőrzi a hiányát anélkül, hogy alapértelmezett értéket vezetne be, még ha a célhelyen korábban már volt alternatív nyelv beállítva is.

Ezek az azonosítók nyelvi metaadatként tárolódnak. Az őrzésük nem határozza meg, hogy a PowerPoint melyik szótárat használja a helyesírás- vagy nyelvtani ellenőrzéshez.

## **Alapértelmezett nyelv beállítása**

Használd a [LoadOptions.default_text_language](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/default_text_language/) tulajdonságot a szöveg alapértelmezett nyelvének meghatározásához a bemutató betöltése vagy létrehozása során. Az alábbi példa egy bemutatót hoz létre, amely US English‑et használ alapértelmezett szövegnyelvként, egy szövegdobozt ad hozzá, és kiírja az első szövegrész nyelvét `en-US`‑ként.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.default_text_language = "en-US"

with slides.Presentation(load_options) as presentation:
    slide = presentation.slides[0]

    # Új téglalap alakzat szöveggel.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 50)
    shape.text_frame.text = "Sample text"

    # Ellenőrizze az első szövegrész nyelvét.
    portion = shape.text_frame.paragraphs[0].portions[0]
    print(portion.portion_format.language_id)
```

## **Alapértelmezett szövegstílus beállítása**

Az alapértelmezett szövegformázás alkalmazásához a prezentáció szintjén használd a [Presentation.default_text_style](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/default_text_style/) tulajdonságot.

Az alábbi példa 14 pontos félkövér betűtípust állít be alapértelmezettként a felső szintű bekezdésekhez egy új bemutatóban, és elmenti a "default_text_style.pptx" fájlt. A szöveg örökölheti ezeket az alapértékeket, hacsak egy specifikusabb formázás nem felülírja őket.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    # Szerezze meg a felső szintű bekezdésformátumot.
    paragraph_format = presentation.default_text_style.get_level(0)

    if paragraph_format is not None:
        paragraph_format.default_portion_format.font_height = 14
        paragraph_format.default_portion_format.font_bold = slides.NullableBool.TRUE

    presentation.save("default_text_style.pptx", slides.export.SaveFormat.PPTX)
```

## **Szöveg kinyerése All‑Caps hatással**

PowerPointban az **All Caps** betűtípus‑effektus alkalmazásakor a szöveg nagybetűként jelenik meg a dián, még ha eredetileg kisbetűvel írták is. Amikor az Aspose.Slides‑kel lekéred ezt a szövegrészt, a könyvtár a pontosan beírt szöveget adja vissza. A megjelenő szöveghez való illeszkedéshez ellenőrizd a [TextCapType](https://reference.aspose.com/slides/python-net/aspose.slides/textcaptype/) értékét, és ha `ALL`, akkor alakítsd a visszakapott karakterláncot nagybetűssé.

Ez a példa a "sample2.pptx" fájlt igényli, amelynek első alakzatán egy szövegdoboz van az első dián. Az első bekezdés első része a **All Caps** hatással rendelkező "Hello, Aspose!" szöveget tartalmazza, az alábbi képen látható módon.

![Az All Caps hatás](all_caps_effect.png)

Az alábbi kódrészlet megmutatja, hogyan lehet kinyerni a **All Caps** hatással ellátott szöveget:

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

**Hogyan módosítható a szöveg egy dián lévő táblázatban?**

A dián lévő táblázat szövegének módosításához használd a [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/)‑t. Iterálj a cellákon, és frissítsd őket a [Cell.text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/cell/text_frame/) segítségével, valamint a bekezdésformázást a [Paragraph.paragraph_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/paragraph_format/)‑on keresztül.

**Hogyan alkalmazható fokozatos színátmenet a szövegre egy PowerPoint dián?**

A fokozatos színátmenet alkalmazásához a szövegre használd a [BasePortionFormat.fill_format](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/fill_format/)‑t. Állítsd a [FillFormat.fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/) értékét [FillType.GRADIENT](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/)‑ra, és konfiguráld a gradient‑állomásokat, irányt és átlátszóságot.

Kapcsolódó funkció: [Format text within slides](/slides/hu/features/text-formatting/).