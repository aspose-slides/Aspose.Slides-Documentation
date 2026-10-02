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
- szöveg átlátszósága
- karakterközelet
- betűtulajdonságok
- betűcsalád
- szöveg forgatása
- forgatási szög
- szövegdoboz
- sortávolság
- automatikus méretezés tulajdonság
- szövegdoboz rögzítése
- szöveg tabuláció
- alapértelmezett nyelv
- PowerPoint
- OpenDocument
- prezentáció
- Python
- Aspose.Slides
description: "Formázza és stílusozza a szöveget PowerPoint és OpenDocument prezentációkban az Aspose.Slides for Python via .NET segítségével. Testreszabhatja a betűtípusokat, színeket, igazítást és sok mást."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan formázhatja a szöveget PowerPoint és OpenDocument prezentációkban az Aspose.Slides for Python via .NET segítségével. Tárgyalja a háttérszíneket, átlátszóságot, karakterközeletet, betűtulajdonságokat, forgatást, bekezdésközeletet, automatikus méretezést, szöveg rögzítését, tabulátorállásokat és nyelvi beállításokat.

Hacsak másként nincs megjelölve, a példák a [sample.pptx](sample.pptx) fájlt használják. Az első diáján az első alakzat egy szövegdoboz, és az első bekezdése a lent bemutatott szöveget tartalmazza. A diák és az alakzat indexei nullától indulnak. A félkövér szakaszokat kiválasztó példák a hatékony formázást használják, beleértve az örökölt félkövér formázást:

![Minta szöveg](sample_text.png)

A szó szerinti szöveg vagy reguláris kifejezés találatok megtalálásához és kiemeléséhez lásd a [Keresés és szövegcsere](/slides/hu/python-net/search-and-replace-text/) oldalt.

## **Szöveg háttérszín beállítása**

Használja a [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_portion_format/) metódust a bekezdés alapértelmezett kiemelési színének beállításához, vagy a [BasePortionFormat.highlight_color](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/highlight_color/) metódust az egyes szövegrészekhez.

Az alábbi példa a első bekezdés alapértelmezett kiemelését világosszürkére állítja. Az egyes részekre kifejezett kiemelési színek felülbírálják ezt az alapértelmezettet:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Állítsa be a teljes bekezdés kiemelésének színét.
    paragraph.paragraph_format.default_portion_format.highlight_color.color = draw.Color.light_gray

    presentation.save("gray_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

Az eredmény:

![A szürke bekezdés](gray_paragraph.png)

Az alábbi kódrészlet bemutatja, hogyan állítható be a háttérszín **félkövér betűtípusú szövegrészek** számára:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # Állítsa be a szövegrész kiemelésének színét.
            portion.portion_format.highlight_color.color = draw.Color.light_gray

    presentation.save("gray_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

Az eredmény:

![A szürke szövegrészek](gray_text_portions.png)

## **Bekezdés szöveg igazítása**

Használja a [ParagraphFormat.alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/) tulajdonságot a bekezdés igazításának beállításához egy szövegdobozon belül. Az érték lehet középre, balra, jobbra, sorkizárás stb.

Az alábbi kódrészlet a bekezdést **középre** igazítja:

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

![A rendezett bekezdés](aligned_paragraph.png)

## **Betűk igazítása egy soron belül**

Használja a [ParagraphFormat.font_alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/font_alignment/) tulajdonságot a különböző betűméretű szövegrészek függőleges igazításához egy soron belül. Ez a beállítás az egész bekezdésre vonatkozik, és a sorokban végzi az igazítást.

Az alábbi önálló példa négy címkézett szövegdobozt hoz létre egy dián. Minden bekezdés ugyanazt a szöveget tartalmazza 18, 36 és 54 pontos mérettel, különböző betűigazítással. Arial betűtípust használ, letiltja az automatikus méretezést és a sortörést, és a szövegdobozok elég nagyok egy sor megjelenítéséhez.

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

![Baseline, felső, középső és alsó betűigazítás összehasonlítása vegyes betűméretekkel](font_alignment.png)

A betűigazítás betűmetrikákon alapul, ezért az egyes betűk látható szélei nem feltétlenül esnek pontosan egy vonalra. A példa tartalmaz nagybetűt és egy lejjebb nyúló (descender) karaktert, hogy bemutassa a baseline és az alsó igazítás közti különbséget. A betűtípus elérhetősége, helyettesítése, a használt karakterek és a betűméretek közötti különbség mind hatással van az eredményre. A keret méretei, margók, sortávolság, sortörés és az automatikus méretezés szintén befolyásolják a megjelenést; a módok összehasonlításakor használjon ugyanazokat a betűket és elrendezési beállításokat.

Ez a beállítás eltér a [ParagraphFormat.alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/)‑tól, amely a vízszintes bekezdésigazítást szabályozza, valamint a [TextFrameFormat.anchoring_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/anchoring_type/)‑tól, amely a szövegblokk függőleges pozícióját állítja be az alakzatban. A [BasePortionFormat.escapement](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/escapement/) segítségével a fel‑ és alsó indexelés egyedi részeket helyez el a baseline-hez képest, ahelyett, hogy a bekezdés soraira vonatkozó betűigazítást állítaná be.

## **Szöveg átlátszóságának beállítása**

A szöveg átlátszóságát a [BasePortionFormat.fill_format](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/fill_format/) színének alfa komponense szabályozza. Az alábbi példákban az `alpha = 50` egy 0–255 skálájú ARGB alfa-érték, nem átlátszósági százalék.

Az alábbi kódrészlet a **teljes bekezdés** átlátszóságát állítja be:

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

A következő kódrészlet a **félkövér betűtípusú szövegrészek** átlátszóságát állítja be:

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

## **Karakterközelet beállítása szöveghez**

Használja a [BasePortionFormat.spacing](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/spacing/) tulajdonságot a karakterek közötti távolság növelésére vagy csökkentésére egy szövegdobozban. A példák 3 pont távolságot adnak hozzá; a negatív értékek a szöveget tömörítik.

Az alábbi Python kód a **teljes bekezdés** karakterközeletét növeli:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Megjegyzés: Negatív értékekkel lehet összenyomni a karakterközeletet.
    paragraph.paragraph_format.default_portion_format.spacing = 3  # Bővítse a karakterközeletet.

    presentation.save("character_spacing_in_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

Az eredmény:

![A bekezdés karakterközelete](character_spacing_in_paragraph.png)

Az alábbi kódrészlet a **félkövér betűtípusú szövegrészek** karakterközeletét növeli:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # Megjegyzés: Negatív értékekkel lehet összenyomni a karakterközeletet.
            portion.portion_format.spacing = 3  # Bővítse a karakterközeletet.

    presentation.save("character_spacing_in_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

Az eredmény:

![A szövegrészek karakterközelete](character_spacing_in_text_portions.png)

### **Kerning letiltása adott betűtípusokra**

Bizonyos esetekben az Aspose.Slides által renderelt szöveg kissé szorosabb lehet, mint a PowerPointban megjelenített szöveg. Ez előfordulhat, ha a PowerPoint bizonyos betűtípusok esetén figyelmen kívül hagyja a kerning adatokat, még akkor is, ha a betűtípus rendelkezik érvényes kerning információval, és a PowerPoint beállításaiban engedélyezve van a kerning.

Az ilyen esetekben a szövegrészeknél, amelyek az érintett betűtípust használják, letilthatja a kerninget. Állítsa a [BasePortionFormat.kerning_minimal_size](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/kerning_minimal_size/) értékét a tényleges betűmérettől nagyobbra. Ez a példa a „presentation.pptx” fájlt igényli, amelynek első alakzata egy szövegdoboz az első dián. A hatékony betűneveket, beleértve az örökölt betűtípusokat, ellenőrzi, és 100 pontos küszöböt állít be a Roboto betűtípust használó részekre. Ez letiltja a kerninget a 100 pont alatti méretű részeknél:

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

Az alacsonyabb küszöb alatti egyező szöveg esetén ez a beállítás megakadályozza a kerninget, és segíthet az Aspose.Slides renderelésének összhangba hozásában a PowerPoint vizuális megjelenésével az érintett betűtípusok esetén.

## **Szöveg betűtulajdonságainak kezelése**

A betűtulajdonságok beállíthatók bekezdés szinten a [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_portion_format/) vagy egyes részeknél a [PortionFormat](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/) segítségével.

Az alábbi példa az első bekezdés alapértelmezett betűtípusát 12 pontos Times New Romanra állítja be, félkövér, dőlt és pontozott aláhúzással. Az egyes részekre kifejezett formázás felülbírálja ezeket az alapértelmezéseket:

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

![A bekezdés betűtulajdonságai](font_properties_for_paragraph.png)

Az alábbi példa 13 pontos Times New Roman, dőlt formázás és pontozott aláhúzás alkalmazását mutatja a **félkövér** hatékony formázású részekre:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # Állítsa be a szövegrész betűtulajdonságait.
            portion.portion_format.font_height = 13
            portion.portion_format.font_italic = slides.NullableBool.TRUE
            portion.portion_format.font_underline = slides.TextUnderlineType.DOTTED
            portion.portion_format.latin_font = slides.FontData("Times New Roman")

    presentation.save("font_properties_for_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

Az eredmény:

![A szövegrészek betűtulajdonságai](font_properties_for_text_portions.png)

## **Szöveg forgatása**

Használja a [TextFrameFormat.text_vertical_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/text_vertical_type/) tulajdonságot egy előre definiált szövegtorientáció beállításához egy alakzaton belül.

Az alábbi kódrészlet a szövegorientációt a [TextVerticalType.VERTICAL270](https://reference.aspose.com/slides/python-net/aspose.slides/textverticaltype/) értékre állítja, amely a szöveget **90 fokkal óramutató járásával ellentétesen** forgatja:

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

Használja a [TextFrameFormat.rotation_angle](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/rotation_angle/) tulajdonságot egy egyéni forgatási szög beállításához egy [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) számára.

Az alábbi kódrészlet a szövegdobozt 3 fokkal óramutató járásával megegyező irányban forgatja az alakzaton belül:

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

## **Bekezdés sorhúzása beállítása**

Az Aspose.Slides a [ParagraphFormat.space_after](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_after/), [ParagraphFormat.space_before](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_before/) és [ParagraphFormat.space_within](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_within/) tulajdonságokkal szabályozza a bekezdésközt. Ezeket a következő módon használhatja:

* Pozitív érték meghatározza a sorhúzást a sor magasságának százalékában.
* Negatív érték meghatározza a sorhúzást pontban.

Az alábbi példa a bekezdés sorhúzását a sormagasság 200%-ára (dupla sorhúzás) állítja:

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

![A bekezdés sorhúzása](line_spacing.png)

## **Sortörés szabályainak vezérlése**

A bekezdés sortörési szabályai szűk szövegtömbökben és olyan prezentációkban hasznosak, ahol latin és kelet-ázsiai szöveg keveredik. Az alábbi tulajdonságok a [ParagraphFormat](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/) részei, így egy egész bekezdésre vonatkoznak:

- [latin_line_break](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/latin_line_break/) szabályozza a latin sortörési szabályokat. Vegyes szöveg esetén ennek módosítása megváltoztathatja a kelet-ázsiai szöveg és írásjel tördelésének helyét is.
- [east_asian_line_break](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/east_asian_line_break/) szabályozza a kelet-ázsiai sortörési szabályokat, beleértve a sor elején és végén megengedett karaktereket.

Ezek a szabályok nem helyettesítik a [TextFrameFormat.wrap_text](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/wrap_text/) beállítást, amely a szövegdobozon belüli automatikus sortörést engedélyezi. A szabályok a csomagoláskor befolyásolják az elrendezést; nem helyettesítik a sortörő karaktereket. Egy explicit sortörés új sort hoz létre a bekezdésen belül, függetlenül a rendelkezésre álló szélességtől.

Az alábbi önálló példa egy keskeny szövegtömböt hoz létre, amely kínai és latin szöveget tartalmaz. Mindkét sortörési tulajdonságot explicit módon beállítja, és a „line_breaking.pptx” fájlt menti. A szabályok kipróbálásához változtassa meg az adott tulajdonság értékét, miközben a másik beállítást változatlanul hagyja. A példa 24 pontos Arial és SimSun betűket, 160 pontos keretszélességet és nulla vízszintes szövegdoboz-margót használ. A [TextFrameFormat.autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/autofit_type/) értéke [TextAutofitType.NONE](https://reference.aspose.com/slides/python-net/aspose.slides/textautofittype/), így a szövegméret és a keretméretek rögzítve maradnak:

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

A [ParagraphFormat.hanging_punctuation](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/hanging_punctuation/) lehetővé teszi, hogy a jogosult írásjelek a sor jobb szélén túlnyúljanak ahelyett, hogy a következő sorra kerülnek. Ez az egész bekezdésre vonatkozik, és különbözik a függőleges behúzástól.

Az alábbi önálló példa 100 pontos széles szövegdobozban engedélyezi a függőleges írásjeleket, és a „hanging_punctuation.pptx” fájlt menti. 24 pontos Arial és nulla vízszintes szövegdoboz-margó mellett a végpont a „sentence” után marad, és túlnyúlik a jobb szövegszegmensen. A tulajdonság beállítása [NullableBool.FALSE](https://reference.aspose.com/slides/python-net/aspose.slides/nullablebool/) értékre összehasonlításhoz: e beállítás esetén a pont külön sorban jelenik meg. A sortörés engedélyezett, az automatikus méretezés letiltott a szélesség rögzítése érdekében.

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

Nem minden írásjel tud függőlegesen nyúlni. A látható eredmény a [betűtípus és elrendezési feltételektől](#control-line-breaking) függ: a betűtípus, a rendelkezésre álló szélesség, a margók vagy az automatikus méretezés módosítása eltüntetheti a látható különbséget.

## **Automatikus méretezés típusa szövegdobozokhoz**

A [TextFrameFormat.autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/autofit_type/) határozza meg, hogyan viselkedik a szöveg, ha túllépi a tárolójának határait. Használja a szöveg zsugorodásának, átfedésének vagy az alakzat automatikus átméretezésének vezérlésére. Az alábbi példa úgy konfigurálja a alakzatot, hogy a szöveghez igazodjon, és a „autofit_type.pptx” fájlba menti az eredményt:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE

    presentation.save("autofit_type.pptx", slides.export.SaveFormat.PPTX)
```

Az automatikus sortörés utáni sorok számlálásához és a szöveg vagy alakzat szélességének változásának megtekintéséhez lásd a [Renderelt sorok számlálása](/slides/hu/python-net/manage-paragraph/). A sorok száma önmagában nem mutatja, hogy a szöveg túlcsordul-e a tárolóban.

## **Szövegdoboz rögzítésének beállítása**

A [TextFrameFormat.anchoring_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/anchoring_type/) meghatározza, hogyan helyezkedik el a szöveg függőlegesen egy alakzaton belül, például a tetején, közepén vagy alján. Az alábbi példa a szöveget az első alakzat aljához rögzíti, és a „text_anchor.pptx” fájlba menti az eredményt:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.anchoring_type = slides.TextAnchorType.BOTTOM

    presentation.save("text_anchor.pptx", slides.export.SaveFormat.PPTX)
```

## **Szöveg tabuláció beállítása**

Használja a [ParagraphFormat.default_tab_size](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_tab_size/) és a [ParagraphFormat.tabs](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/tabs/) beállításokat a bekezdés tabulátorpontjainak konfigurálásához. Az alábbi példa az alapértelmezett tabulátorintervallumot 100 pontra állítja, és balra igazított tabot ad hozzá 30 pontnál. Ezek a beállítások a tabulátor karaktert tartalmazó szövegre hatnak.

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

## **Helyesírási nyelv beállítása**

Az Aspose.Slides a [BasePortionFormat.language_id](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/language_id/) tulajdonsággal lehetővé teszi a szövegrész helyesírási nyelvének beállítását. A helyesírási nyelv határozza meg a PowerPointban a helyesírás- és nyelvtani ellenőrzés nyelvét.

Az alábbi példa a „presentation.pptx” fájlt igényli, amelynek első alakzata egy szövegdoboz az első dián, és legalább egy bekezdést tartalmaz. Az első bekezdés tartalmát „1。”‑re cseréli, a betűtípust SimSunra állítja, és a leegyszerűsített kínai helyesírási nyelvet (`zh-CN`) rendeli hozzá. Az eredményt a „proofing_language.pptx” fájlba menti:

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

    # Állítsa be a helyesírási nyelvet leegyszerűsített kínaira.
    text_portion.portion_format.language_id = "zh-CN"

    text_portion.text = "1。"
    paragraph.portions.add(text_portion)

    presentation.save("proofing_language.pptx", slides.export.SaveFormat.PPTX)
```

## **Alapértelmezett nyelv beállítása**

Használja a [LoadOptions.default_text_language](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/default_text_language/) beállítást a prezentáció betöltése vagy létrehozása során létrehozott szöveg alapértelmezett nyelvének meghatározásához. Az alábbi példa egy prezentációt hoz létre, amelynek alapértelmezett szövegnyelvének az amerikai angol van beállítva, egy szövegdobozt ad hozzá, és az első szövegrész nyelvének `en-US` értéket ír ki.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.default_text_language = "en-US"

with slides.Presentation(load_options) as presentation:
    slide = presentation.slides[0]

    # Adjon hozzá egy új téglalap alakzatot szöveggel.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 50)
    shape.text_frame.text = "Sample text"

    # Ellenőrizze az első rész nyelvét.
    portion = shape.text_frame.paragraphs[0].portions[0]
    print(portion.portion_format.language_id)
```

## **Alapértelmezett szövegstílus beállítása**

A prezentáció szintjén alapértelmezett szövegformázás alkalmazásához használja a [Presentation.default_text_style](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/default_text_style/) tulajdonságot.

Az alábbi példa egy 14 pontos félkövér betűtípust állít be alapértelmezettként a felső szintű bekezdésekhez egy új prezentációban, és a „default_text_style.pptx” fájlba menti. A szöveg örökölheti ezeket az alapértelmezéseket, hacsak egy specifikusabb formázás felül nem írja őket.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    # Szerezze meg a felső szintű bekezdés formátumát.
    paragraph_format = presentation.default_text_style.get_level(0)

    if paragraph_format is not None:
        paragraph_format.default_portion_format.font_height = 14
        paragraph_format.default_portion_format.font_bold = slides.NullableBool.TRUE

    presentation.save("default_text_style.pptx", slides.export.SaveFormat.PPTX)
```

## **Szöveg kinyerése All-Caps effektussal**

PowerPointban az **All Caps** betűhatás alkalmazása a szöveget nagybetűs formában jeleníti meg a dián, még akkor is, ha eredetileg kisbetűvel lett beírása. Amikor az Aspose.Slides ezzel a szövegrészlettel dolgozik, a könyvtár pontosan úgy adja vissza a szöveget, ahogyan azt beírták. A megjelenített szöveghez illeszkedéshez ellenőrizze a [TextCapType](https://reference.aspose.com/slides/python-net/aspose.slides/textcaptype/) értékét, és a visszaadott karakterláncot nagybetűssé konvertálja, ha az érték `ALL`.

Ez a példa a „sample2.pptx” fájlt igényli, amelynek első alakzata egy szövegdoboz az első dián. Első bekezdésének első része a „Hello, Aspose!” szöveget tartalmazza All Caps effektussal, az alábbi módon:

![All Caps effektus](all_caps_effect.png)

Az alábbi kódrészlet megmutatja, hogyan nyerhető ki a **All Caps** effektussal ellátott szöveg:

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

**Hogyan módosíthatom a táblázatban lévő szöveget egy dián?**

A táblázat szövegének módosításához használja a [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) osztályt. Iteráljon a cellákon, és frissítse a cellát a [Cell.text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/cell/text_frame/) segítségével, valamint a bekezdés formázását a [Paragraph.paragraph_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/paragraph_format/) segítségével.

**Hogyan alkalmazhatok színátmenetet a szövegre egy PowerPoint dián?**

A színátmenet alkalmazásához a szövegre használja a [BasePortionFormat.fill_format](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/fill_format/) tulajdonságot. Állítsa a [FillFormat.fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/) értékét [FillType.GRADIENT](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/)-ra, és konfigurálja a színátmeneti állomásokat, az irányt és az átlátszóságot.