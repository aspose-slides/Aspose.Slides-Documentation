---
title: Prezentáció szövegének formázása Pythonban
linktitle: Szöveg formázása
type: docs
weight: 50
url: /hu/python-net/text-formatting/
keywords:
- bekezdés igazítása
- szövegstílus
- szöveg háttér
- szöveg átlátszóság
- karaktertávolság
- betűtulajdonságok
- betűcsalád
- szöveg forgatása
- forgatási szög
- szövegkeret
- sorköz
- automatikus illesztés tulajdonság
- szövegkeret rögzítése
- szöveg tabuláció
- alapértelmezett nyelv
- PowerPoint
- OpenDocument
- prezentáció
- Python
- Aspose.Slides
description: "Formázza és stílusozza a szöveget PowerPoint és OpenDocument prezentációkban az Aspose.Slides for Python via .NET használatával. Testreszabhatja betűket, színeket, igazítást és egyebet."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet szöveget formázni PowerPoint és OpenDocument prezentációkban az Aspose.Slides for Python via .NET használatával. Tárgyalja a háttérszíneket, átlátszóságot, karaktertávolságot, betűtípus‑tulajdonságokat, forgatást, bekezdés‑távolságot, automatikus illesztés viselkedését, szöveg‑rögzítést, tabulátor‑állásokat és nyelvi beállításokat.

Ha nincs másként jelölve, a példák a [sample.pptx](sample.pptx) fájlt használják. Az első dián az első alakzat egy szövegdoboz, és az első bekezdés tartalmazza az alább bemutatott szöveget. Mind a dia, mind az alakzat indexei nulláról indulnak. A félkövér részeket kiválasztó példák hatékony formázást használnak, beleértve az örökölt félkövér formázást:

![Minta szöveg](sample_text.png)

A szó szerinti szöveg vagy reguláris‑kifejezés egyezések megtalálásához és kiemeléséhez lásd a [Szöveg keresése és cseréje](/slides/hu/python-net/search-and-replace-text/) oldalt.

## **Szöveg háttérszín beállítása**

Használja a [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_portion_format/) a bekezdés alapértelmezett kiemelés színének beállításához, vagy a [BasePortionFormat.highlight_color](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/highlight_color/) egyedi szövegrészekhez.

Az alábbi példa világosszürke kiemelést állít be alapértelmezettként az első bekezdéshez. Az egyes részeken megadott kiemelés felülírja ezt az alapértelmezést:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Állítsa be a kiemelés színét az egész bekezdéshez.
    paragraph.paragraph_format.default_portion_format.highlight_color.color = draw.Color.light_gray

    presentation.save("gray_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

Az eredmény:

![A szürke bekezdés](gray_paragraph.png)

Az alábbi kódpélda bemutatja, hogyan állítsuk be a háttérszínt **félkövér betűvel rendelkező szövegrészek** számára:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # Állítsa be a kiemelés színét a szövegrészhez.
            portion.portion_format.highlight_color.color = draw.Color.light_gray

    presentation.save("gray_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

Az eredmény:

![A szürke szövegrészek](gray_text_portions.png)

## **Szöveg bekezdések igazítása**

Használja a [ParagraphFormat.alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/) a bekezdés igazításához egy szövegkereten belül. Az érték lehet középre, balra, jobbra igazított, sorkizárt stb.

Az alábbi kódpélda megmutatja, hogyan igazítsuk a bekezdést a **közép** pozícióba:

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

## **Betűtípusok igazítása egy soron belül**

Használja a [ParagraphFormat.font_alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/font_alignment/) a különböző betűméretű szövegrészek függőleges igazításához egy soron belül. Ez a beállítás a teljes bekezdésre vonatkozik, és a sorok minden egyes sorában szabályozza az igazítást.

Az alábbi önálló példa négy feliratozott szövegdobozt hoz létre egy dián. Minden bekezdés ugyanazt a szöveget tartalmazza 18, 36 és 54 pontos mérettel, eltérő betűigazítással. Arial‑t használ, letiltja az automatikus illesztést és a sortörést, és a szövegkereteket elég nagyra állítja, hogy egy sorba férjenek.

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

![Az alapvonal, felső, közép és alsó betűigazítás összehasonlítása vegyes betűméretekkel](font_alignment.png)

A betűigazítás betűmetrikákat használ, ezért az egyes betűk látható szélei nem feltétlenül illeszkednek tökéletesen egymáshoz. A példa nagybetűt és egy lenyúló karaktert is tartalmaz, hogy megmutassa a különbséget az alapvonal és az alsó igazítás között. A betűk elérhetősége, a helyettesítés, a használt karakterek és a betűméretek különbsége befolyásolja az eredményt. A keretméretek, margók, sorköz, sortörés és az automatikus illesztés szintén hatnak a megjelenésre; a módok összehasonlításakor ugyanazokat a betűket és elrendezési beállításokat használja.

Ez a beállítás eltér a [ParagraphFormat.alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/)‑től, amely a vízszintes bekezdés‑igazítást szabályozza, valamint a [TextFrameFormat.anchoring_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/anchoring_type/)‑tól, amely a szövegblokk függőleges pozícióját határozza meg az alakzaton belül. A felső- és alsó indexelés a [BasePortionFormat.escapement](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/escapement/) segítségével egyes részeket a baseline-hez viszonyítva helyez el, a bekezdés sorainak betűigazítását pedig nem módosítja.

## **Szöveg átlátszóság beállítása**

A szöveg átlátszóságát a [BasePortionFormat.fill_format](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/fill_format/)‑hez rendelt szín alfa komponense szabályozza. Az alábbi példákban a `alpha = 50` egy ARGB alfa‑csatorna‑érték a 0–255 skálán, nem átlátszósági százalék.

Az alábbi kódpélda megmutatja, hogyan alkalmazzon átlátszóságot a **teljes bekezdésre**:

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

Az alábbi kódpélda megmutatja, hogyan alkalmazzon átlátszóságot **félkövér betűvel rendelkező szövegrészek** számára:

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

## **Karaktertávolság beállítása szöveghez**

Használja a [BasePortionFormat.spacing](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/spacing/)‑t a karakterek közti távolság növelésére vagy csökkentésére egy szövegdobozban. A példák 3 pont távolságot adnak hozzá; a negatív értékek összenyomják a szöveget.

Az alábbi Python‑kód megmutatja, hogyan növelje a karaktertávolságot a **teljes bekezdésben**:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Megjegyzés: Negatív értékek használata a karaktertávolság összenyomásához.
    paragraph.paragraph_format.default_portion_format.spacing = 3  # Karaktertávolság növelése.

    presentation.save("character_spacing_in_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

Az eredmény:

![A karaktertávolság a bekezdésben](character_spacing_in_paragraph.png)

Az alábbi kódpélda megmutatja, hogyan növelje a karaktertávolságot **félkövér betűvel rendelkező szövegrészek** esetén:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # Megjegyzés: Negatív értékek használata a karaktertávolság összenyomásához.
            portion.portion_format.spacing = 3  # Karaktertávolság növelése.

    presentation.save("character_spacing_in_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

Az eredmény:

![A karaktertávolság a szövegrészekben](character_spacing_in_text_portions.png)

### **Kernálás letiltása bizonyos betűtípusoknál**

Bizonyos esetekben az Aspose.Slides által renderelt szöveg kissé szorosabbnak tűnhet, mint a PowerPoint‑ban megjelenített változat. Ennek oka lehet, hogy a PowerPoint bizonyos betűtípusoknál figyelmen kívül hagyja a kernálási adatokat, még akkor is, ha a betűtípus tartalmaz érvényes kernálási információkat, és a PowerPoint beállításaiban a kernálás engedélyezve van.

A renderelt kimenet PowerPoint‑hoz való közelítése érdekében letilthatja a kernálást az érintett betűtípust használó szövegrészeknél. Állítsa a [BasePortionFormat.kerning_minimal_size](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/kerning_minimal_size/) értékét a tényleges betűméretnél nagyobbra. Ez a példa a „presentation.pptx” fájlt igényli, amelynek első alakzata az első dián egy szövegdoboz. Ellenőrzi a hatékony betűneveket, beleértve az örökölt betűket, és 100 pontos küszöböt állít be azokhoz a részekhez, amelyek a Roboto‑t használják. Ez letiltja a kernálást a 100 pont alatti betűmérettel rendelkező, egyező részeknél:

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

A küszöb alatti egyező szöveg esetén ez a beállítás megakadályozza a kernálást, és segíthet az Aspose.Slides renderelésének a PowerPoint vizuális kimenetéhez való igazításában az érintett betűtípusoknál.

## **Szöveg betűtulajdonságainak kezelése**

A betűtulajdonságok beállíthatók bekezdés szinten a [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_portion_format/) segítségével, vagy egyedi részeknél a [PortionFormat](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/)‑on keresztül.

Az alábbi példa az első bekezdés alapértelmezett betűtípusát 12 pontos Times New Roman‑ra állítja, félkövér, dőlt és pontozott aláhúzással. Az egyes részekre alkalmazott explicitebb formázás felülírja ezeket az alapértelmezéseket:

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

Az alábbi példa 13 pontos Times New Roman‑t, dőlt formázást és pontozott aláhúzást alkalmaz a hatékonyan félkövérként formázott részekre:

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

![A szövegrészek betűtulajdonságai](font_properties_for_text_portions.png)

## **Szöveg magasság normalizációjának vezérlése**

Használja a [BasePortionFormat.normalise_height](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/normalise_height/)‑t sablon‑tipográfia reprodukciójához vagy a karaktermagasság‑különbségek vizsgálatához. PowerPoint‑ban a normalizálás engedélyezése függőlegesen nyújtja vagy összenyomja az egyes karaktereket, hogy egységes látható magasságot biztosítson a szövegrészben. Nem garantálja a különböző betűtípusok szövegmagasságának egységességét.

Állítsa a tulajdonságot a [NullableBool.TRUE vagy FALSE](https://reference.aspose.com/slides/python-net/aspose.slides/nullablebool/) értékre a normalizálás kifejezett engedélyezéséhez vagy tiltásához. A `NullableBool.NOT_DEFINED` helyi beállítást nem definiálja, így a rész örökli az értéket, például a bekezdés [default_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_portion_format/)-ból. Ez nem ugyanaz, mint a `False`. Használja a [PortionFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/get_effective/)‑t és olvassa el az [IBasePortionFormatEffectiveData.normalise_height](https://reference.aspose.com/slides/python-net/aspose.slides/ibaseportionformateffectivedata/normalise_height/)‑t a feloldott Boolean értékhez.

Az alábbi önálló példa **Arial**‑t igényel. Két szövegrészletet hoz létre, amely ugyanazokat a nagybetűket, kisbetűket, lenyúló karaktereket és ékezetes betűket tartalmazza 54 pontos méretben. Mindkét bekezdés alapértelmezésben engedélyezi a normalizálást. A felső rész kifejezetten letiltja; az alsó rész örökli. A keretméretek, margók és bekezdés‑távolság azonos, a sortörés és az automatikus illesztés le van tiltva, hogy a összehasonlítás konzisztens maradjon. A példa `FALSE: False` és `NOT_DEFINED: True` értékeket ír ki, majd elmenti a „text_height_normalization.pptx” fájlt.

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

Az alább látható összehasonlítás a mentett prezentációból származik. A felső sorban a normalizálás ki van kapcsolva (`FALSE`); az alsó sor örökli az engedélyezett beállítást (`NOT_DEFINED` → `True`). Az eredmény reprodukálásához telepítve kell legyen az Arial.

![Arial 54‑pontos szöveg normalizálással letiltva felül, és örökölt normalizálással alul](text_height_normalization.png)

A normalizálás a karakter magasságát változtatja anélkül, hogy a hozzárendelt [font_height](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/font_height/) érték megváltozna, amely a betűméretet pontban adja meg. A bekezdés [space_within](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_within/) a sorközöt, míg a szövegkeret [autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/autofit_type/) a szöveg vagy a tároló méretezését szabályozza. Ezek a beállítások különböző célokat szolgálnak, és önállóan befolyásolhatják a teljes elrendezést. A bekezdés formázásáról és öröklődéséről további információkért lásd a [Bekezdés kezelése](/slides/hu/python-net/manage-paragraph/) oldalt.

## **Áthúzás alkalmazása és eltávolítása**

Használja a [BasePortionFormat.strikethrough_type](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/strikethrough_type/) szövegrészen, hogy javításokat, törölt kifejezéseket vagy korábbi árakat jelenítsen meg anélkül, hogy törölné az eredeti szöveget. Állítsa be a [TextStrikethroughType.SINGLE vagy DOUBLE](https://reference.aspose.com/slides/python-net/aspose.slides/textstrikethroughtype/) értékek egyikére egy vagy két vonallal áthúzva a szöveget.

Az áthúzás eltávolításához állítsa `TextStrikethroughType.NONE`‑ra. Ez kifejezetten letiltja a hatást, még ha a környező formázás áthúzást is tartalmaz. Ezzel szemben a `TextStrikethroughType.NOT_DEFINED` helyi beállítást nem definiálja, így a rész örökölheti a formázást például a bekezdéstől. Nem garantálja, hogy az áthúzás eltávolításra kerül. Használja a [PortionFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/get_effective/)‑t a végső formázás, beleértve az örökölt értékek olvasását.

Az alábbi önálló példa három ár‑összehasonlítást hoz létre. Minden bekezdésnek külön részei vannak: címke, korábbi ár és aktuális ár, így csak a korábbi ár érintett. Az első sor alkalmaz és majd eltávolítja az áthúzást; a többi sor egy‑ és dupla áthúzást tart meg. Ennek a tulajdonságnak a módosítása megőrzi a szöveget és egyéb formázását, beleértve a félkövér korábbi árat.

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

    # Alkalmazza az áthúzást, majd kifejezetten távolítsa el az első korábbi árról.
    paragraphs[0].portions[1].portion_format.strikethrough_type = slides.TextStrikethroughType.SINGLE
    paragraphs[0].portions[1].portion_format.strikethrough_type = slides.TextStrikethroughType.NONE

    paragraphs[1].portions[1].portion_format.strikethrough_type = slides.TextStrikethroughType.SINGLE
    paragraphs[2].portions[1].portion_format.strikethrough_type = slides.TextStrikethroughType.DOUBLE

    presentation.save("strikethrough.pptx", slides.export.SaveFormat.PPTX)
```

Az eredmény felülről lefelé: nincs áthúzás, egyszeres áthúzás és dupla áthúzás.

![Korábbi árak áthúzás nélkül, egyszeres áthúzással és dupla áthúzással](strikethrough.png)

## **Szöveg forgatása**

Használja a [TextFrameFormat.text_vertical_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/text_vertical_type/)‑t, hogy előre definiált szöveg‑orientációt állítson be egy alakzaton belül.

Az alábbi kódpélda a szöveg orientációját a [TextVerticalType.VERTICAL270](https://reference.aspose.com/slides/python-net/aspose.slides/textverticaltype/) értékre állítja, amely **90 fokkal óramutató járásával ellentétesen** forgatja a szöveget:

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

## **Egyedi forgatás beállítása szövegkeretekhez**

Használja a [TextFrameFormat.rotation_angle](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/rotation_angle/)‑t, hogy egyedi forgatási szöget állítson be egy [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) számára.

Az alábbi kódpélda 3 fokkal óramutató járásával megegyezően forgatja a szövegkeretet az alakzaton belül:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.rotation_angle = 3

    presentation.save("custom_text_rotation.pptx", slides.export.SaveFormat.PPTX)
```

Az eredmény:

![Az egyedi szöveg forgatása](custom_text_rotation.png)

## **Bekezdés sorközének beállítása**

Az Aspose.Slides a [ParagraphFormat.space_after](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_after/), [ParagraphFormat.space_before](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_before/) és [ParagraphFormat.space_within](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_within/) tulajdonságokat biztosítja a bekezdés‑távolság szabályozásához. Ezeket a következőképpen használhatja:

* Pozitív érték esetén a sorköz a sormagasság százalékában adható meg.
* Negatív érték esetén a sorköz pontban adható meg.

Az alábbi példa a első bekezdésen belüli távolságot a sormagasság 200 %-ára (duplázott sorköz) állítja:

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

![A bekezdés sorköz belül](line_spacing.png)

## **Sortörés szabályozása**

A bekezdés sortörési szabályai szűk szövegblokkokban és olyan prezentációkban hasznosak, amelyek latin és kelet‑ázsiai szöveget kevernek. Az alábbi tulajdonságok a [ParagraphFormat](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/) részei, ezért egy teljes bekezdésre vonatkoznak:

- A [latin_line_break](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/latin_line_break/) a latin sortörési szabályokat szabályozza. Vegyes szöveg esetén ennek módosítása megváltoztathatja, hogy a szomszédos kelet‑ázsiai szöveg és írásjel hol törik.
- A [east_asian_line_break](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/east_asian_line_break/) a kelet‑ázsiai sortörési szabályokat szabályozza, beleértve a sor elején és végén álló karakterek korlátozásait.

Ezek a szabályok nem helyettesítik a [TextFrameFormat.wrap_text](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/wrap_text/)‑t, amely automatikus sortörést engedélyez egy szövegkereten belül. A sortörési szabályok a layout‑ot befolyásolják, amikor a sortörés megtörténik; nem szúrnak be sortörés‑karaktereket. Egy explicit sortörés új sort hoz létre a bekezdésen belül, függetlenül a rendelkezésre álló szélességtől.

Az alábbi önálló példa egy szűk szövegblokkot hoz létre, amely kínai és latin szöveget tartalmaz. Mindkét sortörési tulajdonságot explicit módon beállítja, majd elmenti a „line_breaking.pptx” fájlt. A szabályok kipróbálásához módosítsa az adott tulajdonság értékét, miközben a másik beállítást változatlanul hagyja. A példa 24 pontos Arial‑t és SimSun‑t használ 160 pont széles kerettel és nulla vízszintes szövegkeret‑margóval. A [TextFrameFormat.autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/autofit_type/) a [TextAutofitType.NONE](https://reference.aspose.com/slides/python-net/aspose.slides/textautofittype/) értékre van állítva, hogy a szövegméret és a keretméretek fixek maradjanak.

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

## **Lengő írásjelek szabályozása**

A [ParagraphFormat.hanging_punctuation](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/hanging_punctuation/) lehetővé teszi, hogy az illetékes írásjelek a sor jobb szélén kívülre nyúljanak, ahelyett hogy a következő sorba kerülnek. Ez a teljes bekezdésre vonatkozik, és különbözik a függőleges behúzástól.

Az alábbi önálló példa 100 pont széles szövegkeretben engedélyezi a lengő írásjeleket, majd elmenti a „hanging_punctuation.pptx” fájlt. 24 pontos Arial és nulla vízszintes szövegkeret‑margó mellett a végső pont a „sentence” szó után marad, és túlnyúlik a jobb szövegélén. Állítsa a tulajdonságot [NullableBool.FALSE](https://reference.aspose.com/slides/python-net/aspose.slides/nullablebool/) értékre a összehasonlításhoz: ebben a beállításban a pont külön sorba kerül. A sortörés engedélyezve van, az automatikus illesztés le van tiltva, hogy a rendelkezésre álló szélesség rögzítve maradjon.

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

Nem minden írásjel függőlegesen nyúlhat. A látható eredmény a [betű‑ és elrendezési feltételektől](#control-line-breaking) függ: a betűtípus, a rendelkezésre álló szélesség, a margók vagy az automatikus illesztés módosítása eltávolíthatja a látható különbséget.

## **Automatikus illesztés típusának beállítása szövegkeretekhez**

A [TextFrameFormat.autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/autofit_type/) meghatározza, hogyan viselkedik a szöveg, ha meghaladja a tároló határait. Használja a szöveg összehúzódásának, túlcsordulásának vagy az alakzat automatikus átméretezésének vezérlésére. Az alábbi példa a szöveghez való igazítást konfigurálja, majd elmenti az eredményt a „autofit_type.pptx” fájlba.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE

    presentation.save("autofit_type.pptx", slides.export.SaveFormat.PPTX)
```

Az automatikus sortörés után a sorok számolásához és a szöveg vagy az alakzat szélességének változásához lásd a [Renderelt sorok számolása](/slides/hu/python-net/manage-paragraph/) oldalt. A sorok száma önmagában nem mutatja, hogy a szöveg túllépi-e a tárolót.

## **Szövegkeret rögzítésének beállítása**

A [TextFrameFormat.anchoring_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/anchoring_type/) meghatározza, hogyan helyezkedik el a szöveg függőlegesen egy alakzaton belül, például felül, középen vagy alul. Az alábbi példa a szöveget az első alakzat aljára rögzíti, majd elmenti az eredményt a „text_anchor.pptx” fájlba.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.anchoring_type = slides.TextAnchorType.BOTTOM

    presentation.save("text_anchor.pptx", slides.export.SaveFormat.PPTX)
```

## **Szöveg tabuláció beállítása**

Használja a [ParagraphFormat.default_tab_size](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_tab_size/) és a [ParagraphFormat.tabs](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/tabs/) beállításokat a tabulátor‑állások konfigurálásához egy bekezdésben. Az alábbi példa az alapértelmezett tabulátor‑intervallumot 100 pontra állítja, és egy balra igazított tabulátort ad hozzá 30 pontnál. Ezek a beállítások a tabulátor‑karaktereket tartalmazó szövegre hatnak.

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

Az Aspose.Slides a [BasePortionFormat.language_id](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/language_id/) segítségével lehetővé teszi a helyesírási nyelv beállítását egy szövegrészre. A helyesírási nyelv határozza meg, hogy a PowerPoint milyen nyelvet használ a helyesírás- és nyelvtani ellenőrzéshez.

Az alábbi példa a „presentation.pptx” fájlt igényli, amelynek első alakzata az első dián egy szövegdoboz, és legalább egy bekezdést tartalmaz. Lecseréli az első bekezdés tartalmát „1。”‑re, a betűtípust SimSun‑ra állítja, és a Simplified Chinese (`zh-CN`) helyesírási nyelvet rendeli hozzá. Az eredményt a „proofing_language.pptx” fájlba menti:

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

## **Alapértelmezett nyelv beállítása**

Használja a [LoadOptions.default_text_language](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/default_text_language/)‑t a szöveg alapértelmezett nyelvének meghatározásához prezentáció betöltése vagy létrehozása során. Az alábbi példa egy prezentációt hoz létre, amelynek alapértelmezett szövegnyelvként az amerikai angolt használja, hozzáad egy szövegdobozt, és kiírja az első szövegrész `en-US` értékét.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.default_text_language = "en-US"

with slides.Presentation(load_options) as presentation:
    slide = presentation.slides[0]

    # Adjunk hozzá egy új téglalap alakzatot szöveggel.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 50)
    shape.text_frame.text = "Sample text"

    # Ellenőrizzük az első rész nyelvét.
    portion = shape.text_frame.paragraphs[0].portions[0]
    print(portion.portion_format.language_id)
```

## **Alapértelmezett szövegstílus beállítása**

Az alapértelmezett szövegformázás alkalmazásához a prezentáció szintjén használja a [Presentation.default_text_style](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/default_text_style/)‑t.

Az alábbi példa 14 pontos félkövér betűt állít be alapértelmezettként a felső szintű bekezdésekhez egy új prezentációban, majd elmenti a „default_text_style.pptx” fájlt. A szöveg örökölheti ezeket az alapértelmezéseket, hacsak egy konkrétabb formázás felül nem írja őket.

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

## **Szöveg kinyerése nagybetűs hatással**

PowerPoint‑ban a **All Caps** betűhatás alkalmazása a szöveget nagybetűsnek jeleníti meg a dián, még akkor is, ha eredetileg kisbetűvel írták. Az Aspose.Slides‑kel ilyen szövegrészt lekérdezve a könyvtár a szöveget pontosan úgy adja vissza, ahogy be lett gépelve. A megjelenített szöveghez való illesztéshez ellenőrizze a [TextCapType](https://reference.aspose.com/slides/python-net/aspose.slides/textcaptype/) értékét, és ha az `ALL`, a visszakapott karakterláncot alakítsa nagybetűssé.

Ez a példa a „sample2.pptx” fájlt igényli, amelynek első alakzata az első dián egy szövegdoboz. Az első bekezdés első része a „Hello, Aspose!” szöveget tartalmazza, amelyre a All Caps hatás van alkalmazva, ahogy alább látható.

![Az All Caps hatás](all_caps_effect.png)

Az alábbi kódpélda megmutatja, hogyan nyerjük ki a **All Caps** hatású szöveget:

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

**Hogyan módosíthatom egy dián lévő táblázat szövegét?**

A dián lévő táblázat szövegének módosításához használja a [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/)‑t. Iterálja a cellákat, és frissítse minden cellát a [Cell.text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/cell/text_frame/)‑en keresztül, valamint a bekezdésformázást a [Paragraph.paragraph_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/paragraph_format/)‑gel.

**Hogyan alkalmazhatok fokozatos színátmenetet a szövegre egy PowerPoint dián?**

A szövegre fokozatos színátmenet alkalmazásához használja a [BasePortionFormat.fill_format](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/fill_format/)‑t. Állítsa a [FillFormat.fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/) értékét a [FillType.GRADIENT](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/)‑ra, és konfigurálja a gradient‑állomásokat, az irányt és az átlátszóságot.

Kapcsolódó funkció: [Szöveg formázása a diákon](/slides/hu/features/text-formatting/).