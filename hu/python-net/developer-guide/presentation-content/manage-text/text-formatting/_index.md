---
title: Formázza a prezentáció szövegét Pythonban
linktitle: Szöveg formázása
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
- szövegkeret rögzítése
- szöveg tabuláció
- alapértelmezett nyelv
- PowerPoint
- OpenDocument
- prezentáció
- Python
- Aspose.Slides
description: "Formázza és stílusozza a szöveget PowerPoint és OpenDocument prezentációkban az Aspose.Slides for Python via .NET használatával. Testreszabhatja a betűtípusokat, színeket, igazítást és sok mást."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet formázni a szöveget PowerPoint és OpenDocument prezentációkban az Aspose.Slides for Python via .NET használatával. Lefedi a háttérszíneket, átlátszóságot, karakterközöket, betűtípus‑tulajdonságokat, forgatást, bekezdés‑közöket, automatikus méretezés viselkedését, szöveg‑rögzítést, tabulátor‑állomásokat és nyelvi beállításokat.

Kivéve ha másként szerepel, a példák a [sample.pptx](sample.pptx) fájlt használják. Az első dia első alakja egy szövegdoboz, és az első bekezdése a alább látható szöveget tartalmazza. Mind a dia, mind az alak indexelése nulláról indul. A félkövér részeket kiválasztó példák hatékony formázást használnak, beleértve az örökölt félkövér formázást:

![Sample text](sample_text.png)

A literális szöveg vagy reguláris kifejezés egyezéseinek megtalálásához és kiemeléséhez lásd a [Keresés és csere szöveg](/slides/hu/python-net/search-and-replace-text/) oldalt.

## **Szöveg háttérszín beállítása**

Használd a [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/hu/python-net/aspose.slides/paragraphformat/default_portion_format/)‑t, hogy beállítsd egy bekezdés alapértelmezett kiemelési színét, vagy a [BasePortionFormat.highlight_color](https://reference.aspose.com/slides/hu/python-net/aspose.slides/baseportionformat/highlight_color/)‑t egyedi szövegrészekhez.

A következő példa világosszürke kiemelést állít be alapértelmezettként az első bekezdéshez. Az egyedi részeken megadott kiemelési színek felülírják ezt az alapértelmezést:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Állítsa be a kiemelési színt a teljes bekezdéshez.
    paragraph.paragraph_format.default_portion_format.highlight_color.color = draw.Color.light_gray

    presentation.save("gray_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

Az eredmény:

![The gray paragraph](gray_paragraph.png)

Az alábbi kódrészlet bemutatja, hogyan állítsd be a háttérszínt **félkövér betűtípussal rendelkező szövegrészek** számára:

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

![The gray text portions](gray_text_portions.png)

## **Szöveg bekezdések igazítása**

Használd a [ParagraphFormat.alignment](https://reference.aspose.com/slides/hu/python-net/aspose.slides/paragraphformat/alignment/)‑t, hogy beállítsd a bekezdés igazítását egy szövegkeretben. Az érték lehet középre, balra, jobbra igazított, sorkizárt stb.

A következő kódrészlet mutatja, hogyan igazítsd a bekezdést **középre**:

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

![The aligned paragraph](aligned_paragraph.png)

## **Szöveg átlátszóság beállítása**

A szöveg átlátszósága a [BasePortionFormat.fill_format](https://reference.aspose.com/slides/hu/python-net/aspose.slides/baseportionformat/fill_format/)‑hez rendelt szín alfa komponensén keresztül szabályozható. Az alábbi példákban az `alpha = 50` egy ARGB alfa‑csatorna érték 0‑255 skálán, nem átlátszósági százalék.

Az alábbi kódrészlet megmutatja, hogyan alkalmazz átlátszóságot a **teljes bekezdésre**:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

alpha = 50

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Állítson be félátlátszó fekete kitöltést a szövegnek.
    paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.from_argb(alpha, draw.Color.black)

    presentation.save("transparent_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

Az eredmény:

![The transparent paragraph](transparent_paragraph.png)

Az alábbi kódrészlet megmutatja, hogyan alkalmazz átlátszóságot **félkövér betűtípussal rendelkező szövegrészekre**:

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

![The transparent text portions](transparent_text_portions.png)

## **Karakterköz beállítása szöveghez**

Használd a [BasePortionFormat.spacing](https://reference.aspose.com/slides/hu/python-net/aspose.slides/baseportionformat/spacing/)‑t, hogy növeld vagy szűkítsd a karakterek közti távolságot egy szövegdobozban. A példák 3 pont távolságot adnak hozzá; a negatív értékek összenyomják a szöveget.

Az alábbi Python kód megmutatja, hogyan növeld a karakterközt a **teljes bekezdésben**:

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

![The character spacing in the paragraph](character_spacing_in_paragraph.png)

Az alábbi kódrészlet megmutatja, hogyan növeld a karakterközt **félkövér betűtípussal rendelkező szövegrészekben**:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # Megjegyzés: Negatív értékeket használjon a karakterköz összenyomásához.
            portion.portion_format.spacing = 3  # Karakterköz növelése.

    presentation.save("character_spacing_in_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

Az eredmény:

![The character spacing in the text portions](character_spacing_in_text_portions.png)

### **Kerning letiltása bizonyos betűtípusoknál**

Bizonyos esetekben az Aspose.Slides által renderelt szöveg valamivel szorosabbnak tűnhet, mint a PowerPointban megjelenített ugyanaz a szöveg. Ez azért fordulhat elő, mert a PowerPoint bizonyos betűtípusoknál figyelmen kívül hagyhatja a kerning adatokat, még akkor is, ha a betűtípus tartalmaz érvényes kerning információt és a PowerPoint beállításaiban engedélyezve van a kerning.

Az ilyen esetekben a renderelt kimenet PowerPoint-hoz közeli megjelenéséhez letilthatod a kerninget az érintett betűtípust használó szövegrészeknél. Állítsd a [BasePortionFormat.kerning_minimal_size](https://reference.aspose.com/slides/hu/python-net/aspose.slides/baseportionformat/kerning_minimal_size/) értékét nagyobbra, mint a tényleges betűméret. Ez a példa a "presentation.pptx" fájlt igényli, ahol az első dia első alakja egy szövegdoboz. Ellenőrzi a hatékony betűtípusneveket, beleértve az örökölt betűtípusokat, és 100 pontos küszöböt állít be azoknál a részeknél, amelyek a Roboto-t használják. Ez letiltja a kerninget a 100 pont alatti betűmérettel rendelkező egyező részeknél:

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

Az alatti küszöbön lévő egyező szövegnél ez a beállítás megakadályozza a kerninget, és segíthet az Aspose.Slides renderelését a PowerPoint vizuális kimenetéhez igazítani az ilyen PowerPoint-specifikus viselkedés által érintett betűtípusok esetén.

## **Szöveg betűtípus tulajdonságok kezelése**

A betűtípus tulajdonságokat be lehet állítani bekezdés szinten a [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/hu/python-net/aspose.slides/paragraphformat/default_portion_format/)‑n keresztül, vagy egyedi részeknél a [PortionFormat](https://reference.aspose.com/slides/hu/python-net/aspose.slides/portionformat/)‑en keresztül.

A következő példa beállítja az első bekezdés alapértelmezett betűtípusát 12 pontos Times New Roman-ra, félkövér, dőlt és pontozott aláhúzással. Az egyedi részeken megadott formázás felülírja ezeket az alapértelmezéseket:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Állítsa be a betűtípus tulajdonságait a bekezdéshez.
    portion_format = paragraph.paragraph_format.default_portion_format
    portion_format.font_height = 12
    portion_format.font_bold = slides.NullableBool.TRUE
    portion_format.font_italic = slides.NullableBool.TRUE
    portion_format.font_underline = slides.TextUnderlineType.DOTTED
    portion_format.latin_font = slides.FontData("Times New Roman")

    presentation.save("font_properties_for_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

Az eredmény:

![The font properties for the paragraph](font_properties_for_paragraph.png)

Az alábbi példa 13 puntos Times New Roman-t, dőlt formátumot és pontozott aláhúzást alkalmaz a részekre, amelyek hatékony formázása félkövér:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # Állítsa be a betűtípus tulajdonságait a szövegrészhez.
            portion.portion_format.font_height = 13
            portion.portion_format.font_italic = slides.NullableBool.TRUE
            portion.portion_format.font_underline = slides.TextUnderlineType.DOTTED
            portion.portion_format.latin_font = slides.FontData("Times New Roman")

    presentation.save("font_properties_for_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

Az eredmény:

![The font properties for text portions](font_properties_for_text_portions.png)

## **Szöveg forgatás beállítása**

Használd a [TextFrameFormat.text_vertical_type](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframeformat/text_vertical_type/)‑t, hogy előre definiált szövegorientációt állíts be egy alakzatban.

Az alábbi kódrészlet a szövegorientációt a alakzatban a [TextVerticalType.VERTICAL270](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textverticaltype/) értékre állítja, amely **90 fokkal balra** forgatja a szöveget:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL270

    presentation.save("text_rotation.pptx", slides.export.SaveFormat.PPTX)
```

Az eredmény:

![The text rotation](text_rotation.png)

## **Egyéni forgatás beállítása szövegkeretekhez**

Használd a [TextFrameFormat.rotation_angle](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframeformat/rotation_angle/)‑t, hogy egyedi forgatási szöget állíts be egy [TextFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframe/) számára.

Az alábbi kódrészlet 3 fokkal az óramutató járásával megegyező irányban forgatja a szövegkeretet az alakzatban:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.rotation_angle = 3

    presentation.save("custom_text_rotation.pptx", slides.export.SaveFormat.PPTX)
```

Az eredmény:

![The custom text rotation](custom_text_rotation.png)

## **Bekezdések sortávolságának beállítása**

Az Aspose.Slides a [ParagraphFormat.space_after](https://reference.aspose.com/slides/hu/python-net/aspose.slides/paragraphformat/space_after/), [ParagraphFormat.space_before](https://reference.aspose.com/slides/hu/python-net/aspose.slides/paragraphformat/space_before/) és [ParagraphFormat.space_within](https://reference.aspose.com/slides/hu/python-net/aspose.slides/paragraphformat/space_within/) segítségével szabályozza a bekezdés távolságait. Ezeket a tulajdonságokat a következőképpen használják:

* Pozitív érték használatával a sortávolságot a sor magasságának százalékában adhatod meg.
* Negatív érték használatával a sortávolságot pontban adhatod meg.

Az alábbi példa a első bekezdésen belüli távolságot 200 %-ra állítja a sor magasságához képest (dupla sortávolság):

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

![The line spacing within the paragraph](line_spacing.png)

## **Sortörés vezérlése**

Az bekezdés sortörési szabályai szűk szövegtömbökben és olyan prezentációkban hasznosak, amelyek keverik a latin és kelet-ázsiai szöveget. A következő tulajdonságok a [ParagraphFormat](https://reference.aspose.com/slides/hu/python-net/aspose.slides/paragraphformat/)‑hez tartoznak, ezért egy teljes bekezdésre vonatkoznak:

- [latin_line_break](https://reference.aspose.com/slides/hu/python-net/aspose.slides/paragraphformat/latin_line_break/) szabályozza a latin sortörési szabályokat. Vegyes szöveg esetén a módosítása megváltoztathatja a szomszédos kelet-ázsiai szöveg és írásjel tördelési helyét.
- [east_asian_line_break](https://reference.aspose.com/slides/hu/python-net/aspose.slides/paragraphformat/east_asian_line_break/) szabályozza a kelet-ázsiai sortörési szabályokat, beleértve a sor elején és végén lévő karakterek korlátozását.

Ezek a szabályok nem helyettesítik a [TextFrameFormat.wrap_text](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframeformat/wrap_text/) funkciót, amely automatikus tördelést tesz lehetővé egy szövegkereten belül. A tördelés során befolyásolják a layoutot, de nem szúrnak be sortörés karaktert. Egy explicit sortörés új sort er force-oz a bekezdésben a rendelkezésre álló szélességtől függetlenül.

Az alábbi önálló példa szűk szövegtömböt hoz létre, amely kínai és latin szöveget tartalmaz. Mindkét sortörési tulajdonságot explicit módon állítja be, és elmenti a "line_breaking.pptx" fájlt. Az egyes szabályok kísérletezéséhez módosítsd az adott tulajdonság értékét, miközben a többi beállítást változatlanul hagyod. A példa 24 pontos Arial és SimSun betűket használ 160 pontos keretszélességgel és nulla horizontális szövegkeret margóval. A [TextFrameFormat.autofit_type](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframeformat/autofit_type/) értéke [TextAutofitType.NONE](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textautofittype/) , hogy a szövegméret és a keret méretei rögzítve maradjanak.

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

## **Függő írásjelek vezérlése**

A [ParagraphFormat.hanging_punctuation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/paragraphformat/hanging_punctuation/) lehetővé teszi, hogy a megfelelő írásjelek a szövegsor jobb szélén túlnyúljanak, ahelyett, hogy a következő sorba kerülnének. A teljes bekezdésre vonatkozik, és különbözik a függő behúzástól.

Az alábbi önálló példa engedélyezi a függő írásjeleket egy 100 pontos széles szövegkeretben, és elmenti a "hanging_punctuation.pptx" fájlt. 24 pontos Arial és nulla horizontális szövegkeret margó esetén a végpont a "sentence" után marad, és túlnyúlik a jobb szövegszélén. Állítsd a tulajdonságot [NullableBool.FALSE](https://reference.aspose.com/slides/hu/python-net/aspose.slides/nullablebool/) értékre összehasonlításként: ezekkel a beállításokkal a pont külön sorban jelenik meg. A tördelés engedélyezett, az automatikus méretezés letiltott, hogy a rendelkezésre álló szélesség rögzítve maradjon.

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

Nem minden írásjel függő lehet. A látható eredmény a betűtípustól és az elrendezési feltételektől függ: a betűtípus, a rendelkezésre álló szélesség, a margók vagy az autofit beállítások módosítása eltüntetheti a látható különbséget.

## **Autofit típus beállítása szövegkeretekhez**

A [TextFrameFormat.autofit_type](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframeformat/autofit_type/) meghatározza, hogyan viselkedik a szöveg, ha meghaladja a tároló határait. Használd, hogy szabályozd, a szöveg kicsinyüljön, túlnyúljon vagy automatikusan átméretezze az alakzatot. Az alábbi példa úgy konfigurálja az alakzatot, hogy átméretezze magát a szöveghez, és elmenti az eredményt a "autofit_type.pptx" fájlba.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE

    presentation.save("autofit_type.pptx", slides.export.SaveFormat.PPTX)
```

Az automatikus tördelés utáni sorok számolásához és a szöveg vagy alakzat szélességének változásához lásd a [Count Rendered Lines](/slides/hu/python-net/manage-paragraph/) oldalt. A sorok száma önmagában nem mutatja, hogy a szöveg túlnyúlik-e a tárolóján.

## **Szövegkeretek rögzítési pontjának beállítása**

A [TextFrameFormat.anchoring_type](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframeformat/anchoring_type/) meghatározza, hogyan helyezkedik el a szöveg függőlegesen egy alakzatban, például felül, középen vagy alul. Az alábbi példa a szöveget az első alakzat aljához rögzíti, és elmenti az eredményt a "text_anchor.pptx" fájlba.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.anchoring_type = slides.TextAnchorType.BOTTOM

    presentation.save("text_anchor.pptx", slides.export.SaveFormat.PPTX)
```

## **Szöveg tabuláció beállítása**

Használd a [ParagraphFormat.default_tab_size](https://reference.aspose.com/slides/hu/python-net/aspose.slides/paragraphformat/default_tab_size/) és a [ParagraphFormat.tabs](https://reference.aspose.com/slides/hu/python-net/aspose.slides/paragraphformat/tabs/)‑t, hogy beállítsd a tabulátorok állását egy bekezdésben. Az alábbi példa a alapértelmezett tabulátortávolságot 100 pontra állítja, és 30 pontnál balra igazított tabulátort állít be. Ezek a beállítások a tabulátor karaktereket tartalmazó szöveget érintik.

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

![The paragraph tabs](paragraph_tabs.png)

## **Helyesírási nyelv beállítása**

Az Aspose.Slides a [BasePortionFormat.language_id](https://reference.aspose.com/slides/hu/python-net/aspose.slides/baseportionformat/language_id/)‑t biztosítja, amely lehetővé teszi, hogy beállítsd egy szövegrész helyesírási nyelvét. A helyesírási nyelv meghatározza a PowerPointban a helyesírás- és nyelvtan-ellenőrzéshez használt nyelvet.

Az alábbi példa a "presentation.pptx" fájlt igényli, amelynek első diájának első alakja egy szövegdoboz, és legalább egy bekezdése van. Lecseréli az első bekezdés tartalmát "1。"‑re, a betűtípust SimSun-ra állítja, és a Simplified Chinese (`zh-CN`) helyesírási nyelvet rendeli hozzá. Az eredményt a "proofing_language.pptx" fájlba menti:

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

    # Állítsa be a helyesírási nyelvet egyszerű kínaira.
    text_portion.portion_format.language_id = "zh-CN"

    text_portion.text = "1。"
    paragraph.portions.add(text_portion)

    presentation.save("proofing_language.pptx", slides.export.SaveFormat.PPTX)
```

## **Alapértelmezett nyelv beállítása**

Használd a [LoadOptions.default_text_language](https://reference.aspose.com/slides/hu/python-net/aspose.slides/loadoptions/default_text_language/)‑t, hogy meghatározd az alapértelmezett nyelvet olyan szövegekhez, amelyeket prezentáció betöltése vagy létrehozása során hozunk létre. Az alábbi példa egy prezentációt hoz létre az amerikai angol alapértelmezett szövegnyelvvel, hozzáad egy szövegdobozt, és kiírja az első szövegrésznek az `en-US` értéket.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.default_text_language = "en-US"

with slides.Presentation(load_options) as presentation:
    slide = presentation.slides[0]

    # Adjon hozzá egy új téglalap alakzatot szöveggel.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 50)
    shape.text_frame.text = "Sample text"

    # Ellenőrizze az első szövegrész nyelvét.
    portion = shape.text_frame.paragraphs[0].portions[0]
    print(portion.portion_format.language_id)
```

## **Alapértelmezett szövegstílus beállítása**

Az alapértelmezett szövegformázás prezentáció szintű alkalmazásához használd a [Presentation.default_text_style](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/default_text_style/)‑t.

Az alábbi példa egy 14 pontos félkövér betűtípust állít be alapértelmezettként a felső szintű bekezdésekhez egy új prezentációban, és elmenti a "default_text_style.pptx" fájlt. A szöveg örökölheti ezeket az alapértelmezéseket, hacsak egy konkrétabb formázás nem írja felül őket.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    # Szerezze be a felső szintű bekezdés formátumát.
    paragraph_format = presentation.default_text_style.get_level(0)

    if paragraph_format is not None:
        paragraph_format.default_portion_format.font_height = 14
        paragraph_format.default_portion_format.font_bold = slides.NullableBool.TRUE

    presentation.save("default_text_style.pptx", slides.export.SaveFormat.PPTX)
```

## **Szöveg kinyerése a Nagybetűs hatással**

A PowerPointban a **All Caps** betűhatás alkalmazása a szöveget nagybetűvel jeleníti meg a dián, még akkor is, ha eredetileg kisbetűvel lett beírva. Ha ilyen szövegrészt kérsz le az Aspose.Slides segítségével, a könyvtár pontosan úgy adja vissza a szöveget, ahogy beírták. A megjelenített szöveghez való illesztéshez ellenőrizd a [TextCapType](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textcaptype/)‑t, és konvertáld a visszakapott karakterláncot nagybetűssé, ha az érték `ALL`.

Ez a példa a "sample2.pptx" fájlt igényli, amelynek első diájának első alakja egy szövegdoboz. Az első bekezdés első része tartalmazza a "Hello, Aspose!" szöveget All Caps hatással, ahogy alább látható.

![The All Caps effect](all_caps_effect.png)

Az alábbi kódrészlet megmutatja, hogyan nyerjük ki a szöveget a **All Caps** hatás alkalmazásával:

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

**Hogyan módosíthatom a táblázat szövegét egy dián?**

A táblázat szövegének módosításához egy dián használd a [Table](https://reference.aspose.com/slides/hu/python-net/aspose.slides/table/). Iterálj a cellákon, és frissítsd minden cellát a [Cell.text_frame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/cell/text_frame/)‑en keresztül, valamint a bekezdés formázását a [Paragraph.paragraph_format](https://reference.aspose.com/slides/hu/python-net/aspose.slides/paragraph/paragraph_format/)‑en keresztül.

**Hogyan alkalmazzak színátmenetes színt a szövegre egy PowerPoint dián?**

A szövegre színátmenetes szín alkalmazásához használd a [BasePortionFormat.fill_format](https://reference.aspose.com/slides/hu/python-net/aspose.slides/baseportionformat/fill_format/). Állítsd a [FillFormat.fill_type](https://reference.aspose.com/slides/hu/python-net/aspose.slides/fillformat/fill_type/) értékét [FillType.GRADIENT](https://reference.aspose.com/slides/hu/python-net/aspose.slides/filltype/)‑ra, és konfiguráld a színátmenet állomásait, irányát és átlátszóságát.