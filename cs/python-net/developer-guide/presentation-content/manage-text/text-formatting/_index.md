---
title: Formátování textu prezentace v Pythonu
linktitle: Formátování textu
type: docs
weight: 50
url: /cs/python-net/text-formatting/
keywords:
- zarovnání odstavce
- styl textu
- pozadí textu
- průhlednost textu
- mezery mezi znaky
- vlastnosti písma
- rodina písma
- otočení textu
- úhel otočení
- textový rámec
- řádkování
- vlastnost automatického přizpůsobení
- ukotvení textového rámce
- tabulace textu
- výchozí jazyk
- PowerPoint
- OpenDocument
- prezentace
- Python
- Aspose.Slides
description: "Formátujte a stylizujte text v prezentacích PowerPoint a OpenDocument pomocí Aspose.Slides pro Python přes .NET. Přizpůsobte písma, barvy, zarovnání a další."
---
## **Přehled**

Tento článek ukazuje, jak formátovat text v prezentacích PowerPoint a OpenDocument pomocí Aspose.Slides pro Python přes .NET. Pokrývá barvy pozadí, průhlednost, rozestupy mezi znaky, vlastnosti písma, rotaci, mezery odstavců, chování automatického přizpůsobení, ukotvení textu, tabulátory a nastavení jazyka.

Pokud není uvedeno jinak, příklady používají [sample.pptx](sample.pptx). První tvar na první snímku je textové pole a jeho první odstavec obsahuje text zobrazený níže. Indexy snímků i tvarů jsou založeny na nule. Příklady, které vybírají tučné části, používají efektivní formátování, včetně zděděného tučného formátování:

![Ukázkový text](sample_text.png)

Pro vyhledání a zvýraznění doslovného textu nebo shod regulárních výrazů viz [Search and Replace Text](/slides/cs/python-net/search-and-replace-text/).

## **Nastavit barvu pozadí textu**

Použijte [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_portion_format/) pro nastavení výchozí barvy zvýraznění odstavce nebo použijte [BasePortionFormat.highlight_color](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/highlight_color/) pro jednotlivé části textu.

Následující příklad nastaví světle šedé zvýraznění jako výchozí pro první odstavec. Výslovně nastavené barvy zvýraznění jednotlivých částí mají přednost před tímto výchozím nastavením:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Nastavte barvu zvýraznění pro celý odstavec.
    paragraph.paragraph_format.default_portion_format.highlight_color.color = draw.Color.light_gray

    presentation.save("gray_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

Výsledek:

![Šedý odstavec](gray_paragraph.png)

Níže uvedený příklad kódu ukazuje, jak nastavit barvu pozadí pro **části textu s tučným písmem**:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # Nastavte barvu zvýraznění pro část textu.
            portion.portion_format.highlight_color.color = draw.Color.light_gray

    presentation.save("gray_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

Výsledek:

![Šedé části textu](gray_text_portions.png)

## **Zarovnat odstavce textu**

Použijte [ParagraphFormat.alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/) pro nastavení zarovnání odstavce v textovém rámečku. Hodnota může být centrovaná, zarovnaná vlevo, vpravo, do bloku atd.

Následující příklad kódu ukazuje, jak zarovnat odstavec na **střed**:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Nastavte zarovnání odstavce na střed.
    paragraph.paragraph_format.alignment = slides.TextAlignment.CENTER

    presentation.save("aligned_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

Výsledek:

![Zarovnaný odstavec](aligned_paragraph.png)

## **Zarovnat písma v řádku**

Použijte [ParagraphFormat.font_alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/font_alignment/) pro svislé zarovnání částí textu s různými velikostmi písma v řádku. Toto nastavení se vztahuje na celý odstavec a řídí zarovnání v každém jeho řádku.

Následující samostatný příklad vytvoří čtyři označená textová pole na jednom snímku. Každý odstavec obsahuje stejný text velikostmi 18, 36 a 54 bodů s různým zarovnáním písma. Používá písmo Arial, vypíná automatické přizpůsobení a zalamování a udržuje textové rámečky dostatečně velké pro jediný řádek.

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

Výsledek:

![Porovnání zarovnání Baseline, Top, Center a Bottom s různými velikostmi písma](font_alignment.png)

Zarovnání písma používá metriky písma, takže viditelné hrany jednotlivých znaků nemusí přesně souhlasit. Příklad obsahuje velké písmeno i znak s dolním výčnem, aby ilustroval rozdíl mezi zarovnáním na základní linii a na spodní část. Dostupnost písma a jeho náhrada, použité znaky a rozdíl ve velikostech písma ovlivňují výsledek. Rozměry rámce, okraje, řádkování, zalamování a automatické přizpůsobení také ovlivňují rozvržení; při porovnávání režimů používejte stejná písma a nastavení rozvržení.

Toto nastavení se liší od [ParagraphFormat.alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/), které řídí horizontální zarovnání odstavce, a od [TextFrameFormat.anchoring_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/anchoring_type/), které umisťuje textový blok svisle uvnitř tvaru. Formátování horního a dolního indexu pomocí [BasePortionFormat.escapement](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/escapement/) posouvá jednotlivé části relativně k základní linii místo nastavení zarovnání písma pro řádky odstavce.

## **Nastavit průhlednost textu**

Průhlednost textu je řízena alfa komponentou barvy přiřazené k [BasePortionFormat.fill_format](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/fill_format/). V příkladech níže je `alpha = 50` hodnota kanálu ARGB v rozsahu 0–255, ne procento průhlednosti.

Níže uvedený příklad kódu ukazuje, jak aplikovat průhlednost na **celý odstavec**:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

alpha = 50

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Nastavte poloprůhlednou černou výplň textu.
    paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.from_argb(alpha, draw.Color.black)

    presentation.save("transparent_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

Výsledek:

![Průhledný odstavec](transparent_paragraph.png)

Následující příklad kódu ukazuje, jak aplikovat průhlednost na **části textu s tučným písmem**:

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
            # Nastavte průhlednost části textu.
            portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
            portion.portion_format.fill_format.solid_fill_color.color = draw.Color.from_argb(alpha, draw.Color.black)

    presentation.save("transparent_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

Výsledek:

![Průhledné části textu](transparent_text_portions.png)

## **Nastavit rozestupy mezi znaky textu**

Použijte [BasePortionFormat.spacing](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/spacing/) pro rozšíření nebo zúžení mezery mezi znaky v textovém poli. Příklady přidávají 3 body mezery; záporné hodnoty mezery text zúží.

Níže uvedený kód v Pythonu ukazuje, jak rozšířit mezery mezi znaky v **celém odstavci**:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Poznámka: Použijte záporné hodnoty k zúžení mezery mezi znaky.
    paragraph.paragraph_format.default_portion_format.spacing = 3  # Rozšířit mezery mezi znaky.

    presentation.save("character_spacing_in_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

Výsledek:

![Rozestupy mezi znaky v odstavci](character_spacing_in_paragraph.png)

Níže uvedený příklad kódu ukazuje, jak rozšířit mezery mezi znaky v **částech textu s tučným písmem**:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # Poznámka: Použijte záporné hodnoty k zúžení mezery mezi znaky.
            portion.portion_format.spacing = 3  # Rozšířit mezery mezi znaky.

    presentation.save("character_spacing_in_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

Výsledek:

![Rozestupy mezi znaky v částech textu](character_spacing_in_text_portions.png)

### **Zakázat kerning pro konkrétní písma**

V některých případech může text vykreslený pomocí Aspose.Slides vypadat mírně těsněji než stejný text v PowerPointu. K tomu může dojít, protože PowerPoint může ignorovat data kerningu pro určitá písma, i když písmo obsahuje platné informace o kerningu a kerning je v nastavení PowerPointu povolen.

Aby výstup byl vizuálně blíže PowerPointu, můžete zakázat kerning pro části textu, které používají dotčené písmo. Nastavte [BasePortionFormat.kerning_minimal_size](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/kerning_minimal_size/) na hodnotu větší než skutečná velikost písma. Tento příklad vyžaduje soubor "presentation.pptx" s textovým polem jako prvním tvarem na první snímku. Kontroluje efektivní názvy písem, včetně zděděných, a nastavuje práh 100 bodů pro části používající Roboto. Tím se zakáže kerning pro odpovídající části s velikostí písma pod 100 bodů:

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

Pro text pod prahem toto nastavení zabraňuje kerningu a může pomoci sladit vykreslování Aspose.Slides s vizuálním výstupem PowerPointu pro písma, na která se toto chování PowerPointu vztahuje.

## **Spravovat vlastnosti písma textu**

Vlastnosti písma lze nastavit na úrovni odstavce pomocí [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_portion_format/) nebo na jednotlivých částech pomocí [PortionFormat](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/).

Následující příklad nastaví výchozí písmo prvního odstavce na Times New Roman 12 bodů s tučným, kurzívou a tečkovaným podtržením. Výslovné formátování jednotlivých částí má přednost před těmito výchozími hodnotami:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Nastavte vlastnosti písma pro odstavec.
    portion_format = paragraph.paragraph_format.default_portion_format
    portion_format.font_height = 12
    portion_format.font_bold = slides.NullableBool.TRUE
    portion_format.font_italic = slides.NullableBool.TRUE
    portion_format.font_underline = slides.TextUnderlineType.DOTTED
    portion_format.latin_font = slides.FontData("Times New Roman")

    presentation.save("font_properties_for_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

Výsledek:

![Vlastnosti písma pro odstavec](font_properties_for_paragraph.png)

Následující příklad použije Times New Roman 13 bodů, kurzívu a tečkované podtržení na části, jejichž efektivní formátování je tučné:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # Nastavte vlastnosti písma pro část textu.
            portion.portion_format.font_height = 13
            portion.portion_format.font_italic = slides.NullableBool.TRUE
            portion.portion_format.font_underline = slides.TextUnderlineType.DOTTED
            portion.portion_format.latin_font = slides.FontData("Times New Roman")

    presentation.save("font_properties_for_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

Výsledek:

![Vlastnosti písma pro textové části](font_properties_for_text_portions.png)

## **Kontrola normalizace výšky textu**

Použijte [BasePortionFormat.normalise_height](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/normalise_height/) při reprodukci typografie šablon nebo zkoumání rozdílů ve výšce znaků. V PowerPointu aktivace normalizace natáhne nebo zmenší jednotlivé znaky svisle tak, aby měly jednotnou viditelnou výšku v textové části. Není zaručeno, že výška textu bude stejná napříč různými fonty.

Nastavte vlastnost na [NullableBool.TRUE nebo FALSE](https://reference.aspose.com/slides/python-net/aspose.slides/nullablebool/) pro explicitní zapnutí nebo vypnutí normalizace. `NullableBool.NOT_DEFINED` ponechává lokální nastavení nevyplněné, takže část zdědí hodnotu, např. z [default_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_portion_format/) odstavce. To neznamená `False`. Použijte [PortionFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/get_effective/) a přečtěte [IBasePortionFormatEffectiveData.normalise_height](https://reference.aspose.com/slides/python-net/aspose.slides/ibaseportionformateffectivedata/normalise_height/) pro získání vyřešené Boolovské hodnoty.

Následující samostatný příklad vyžaduje nainstalované **Arial**. Vytváří dva textové bloky obsahující stejná velká písmena, malá písmena, dolní výčny a diakritické znaky ve velikosti 54 bodů. Oba odstavce mají normalizaci ve výchozím nastavení zapnutou. Horní část ji explicitně vypíná; spodní část ji zdědí. Rozměry rámců, okraje a mezery odstavců jsou identické, zalamování a automatické přizpůsobení jsou vypnuté, aby byl výsledek srovnatelný. Příklad vypíše `FALSE: False` a `NOT_DEFINED: True` a uloží soubor "text_height_normalization.pptx".

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

Porovnání níže bylo exportováno ze uložené prezentace. Horní řádek má normalizaci vypnutou (`FALSE`); spodní řádek ji zdědí (`NOT_DEFINED` → `True`). Pro reprodukci vzhledu mějte nainstalované Arial.

![Arial 54‑bodový text s vypnutou normalizací nahoře a zděděnou zapnutou normalizací dole](text_height_normalization.png)

Normalizace mění výšku znaků, aniž by měnila přiřazenou hodnotu [font_height](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/font_height/), která udává velikost písma v bodech. Odstavecní [space_within](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_within/) řídí řádkování, zatímco [autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/autofit_type/) textového rámce určuje, jak se text nebo jeho kontejner přizpůsobí. Tato nastavení slouží různým účelům a mohou nezávisle ovlivnit celkové rozvržení. Další informace o formátování odstavců a dědičnosti najdete v [Manage Paragraph](/slides/cs/python-net/manage-paragraph/).

## **Použít a odstranit přeškrtnutí**

Použijte [BasePortionFormat.strikethrough_type](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/strikethrough_type/) na část textu k zobrazení oprav, zrušených termínů nebo předchozích cen bez smazání původního textu. Nastavte na [TextStrikethroughType.SINGLE nebo DOUBLE](https://reference.aspose.com/slides/python-net/aspose.slides/textstrikethroughtype/) pro jednu nebo dvě čáry přes text.

Pro odstranění přeškrtnutí přiřaďte `TextStrikethroughType.NONE`. Tím se efekt explicitně vypne, i když okolní formátování určuje přeškrtnutí. Naopak `TextStrikethroughType.NOT_DEFINED` nechává lokální nastavení nedefinované, což umožňuje části zdědit formátování, např. z odstavce. To nezaručuje, že přeškrtnutí bude odstraněno. Použijte [PortionFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/get_effective/) pro čtení výsledného formátování, včetně zděděných hodnot.

Následující samostatný příklad vytváří tři srovnání cen. Každý odstavec má samostatné části pro popisek, předchozí cenu a aktuální cenu, takže pouze předchozí cena je ovlivněna. První řádek nejprve použije a pak odstraní přeškrtnutí; ostatní řádky zachovávají jednoduché a dvojité přeškrtnutí. Změna této vlastnosti zachovává text i jeho další formátování, včetně tučné předchozí ceny.

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

    # Použijte přeškrtnutí, pak jej explicitně odstraňte z první předchozí ceny.
    paragraphs[0].portions[1].portion_format.strikethrough_type = slides.TextStrikethroughType.SINGLE
    paragraphs[0].portions[1].portion_format.strikethrough_type = slides.TextStrikethroughType.NONE

    paragraphs[1].portions[1].portion_format.strikethrough_type = slides.TextStrikethroughType.SINGLE
    paragraphs[2].portions[1].portion_format.strikethrough_type = slides.TextStrikethroughType.DOUBLE

    presentation.save("strikethrough.pptx", slides.export.SaveFormat.PPTX)
```

Výsledek shora dolů: bez přeškrtnutí, s jednoduchým přeškrtnutím a s dvojitým přeškrtnutím.

![Předchozí ceny bez přeškrtnutí, s jednoduchým přeškrtnutím a s dvojitým přeškrtnutím](strikethrough.png)

## **Nastavit otočení textu**

Použijte [TextFrameFormat.text_vertical_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/text_vertical_type/) pro nastavení předdefinované orientace textu uvnitř tvaru.

Následující příklad kódu nastaví orientaci textu ve tvaru na [TextVerticalType.VERTICAL270](https://reference.aspose.com/slides/python-net/aspose.slides/textverticaltype/), což otáčí text **o 90 stupňů proti směru hodinových ručiček**:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL270

    presentation.save("text_rotation.pptx", slides.export.SaveFormat.PPTX)
```

Výsledek:

![Otočení textu](text_rotation.png)

## **Nastavit vlastní otočení textových rámců**

Použijte [TextFrameFormat.rotation_angle](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/rotation_angle/) pro nastavení vlastního úhlu otočení [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/).

Níže uvedený příklad kódu otočí textový rámec o 3 stupně po směru hodinových ručiček uvnitř tvaru:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.rotation_angle = 3

    presentation.save("custom_text_rotation.pptx", slides.export.SaveFormat.PPTX)
```

Výsledek:

![Vlastní otočení textu](custom_text_rotation.png)

## **Nastavit řádkování odstavců**

Aspose.Slides poskytuje [ParagraphFormat.space_after](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_after/), [ParagraphFormat.space_before](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_before/) a [ParagraphFormat.space_within](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_within/) pro řízení mezery odstavců. Tyto vlastnosti se používají následovně:

* Použijte kladnou hodnotu pro určení řádkování jako procenta výšky řádku.
* Použijte zápornou hodnotu pro určení řádkování v bodech.

Následující příklad nastaví mezeru uvnitř prvního odstavce na 200 % výšky řádku (dvojité řádkování):

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    paragraph.paragraph_format.space_within = 200

    presentation.save("line_spacing.pptx", slides.export.SaveFormat.PPTX)
```

Výsledek:

![Řádkování uvnitř odstavce](line_spacing.png)

## **Řízení zalamování řádků**

Pravidla pro zalamování řádků odstavce jsou užitečná v úzkých textových blocích a prezentacích, které kombinují latinský a východoasijský text. Následující vlastnosti patří do [ParagraphFormat](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/), takže se vztahují na celý odstavec:

* [latin_line_break](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/latin_line_break/) řídí pravidla zalamování pro latinské texty. V smíšeném textu může jeho změna také změnit, kde se zalamuje sousední východoasijský text a interpunkce.
* [east_asian_line_break](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/east_asian_line_break/) řídí pravidla zalamování pro východoasijské texty, včetně omezení na znaky na začátku a konci řádku.

Tato pravidla nenahrazují [TextFrameFormat.wrap_text](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/wrap_text/), které umožňuje automatické zalamování v textovém rámečku. Ovlivňují rozvržení, když k zalamování dochází; nevkládají znaky konce řádku. Výslovný konec řádku vynutí nový řádek v odstavci nezávisle na dostupné šířce.

Následující samostatný příklad vytvoří úzký textový blok obsahující čínštinu a latinu. Explicitně nastaví obě vlastnosti zalamování a uloží soubor "line_breaking.pptx". Pro experimentování s libovolným pravidlem změňte hodnotu dané vlastnosti a nechte druhé nastavení beze změny. Příklad používá Arial 24 bodů a SimSun s šířkou rámce 160 bodů a nulovými horizontálními okraji textového rámce. [TextFrameFormat.autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/autofit_type/) je nastaven na [TextAutofitType.NONE](https://reference.aspose.com/slides/python-net/aspose.slides/textautofittype/), aby velikost textu a rozměry rámce zůstaly pevné.

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

## **Řízení visící interpunkce**

[ParagraphFormat.hanging_punctuation](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/hanging_punctuation/) umožňuje vhodné interpunkční znaky prodloužit přes pravý okraj řádku textu místo toho, aby zabíraly další řádek. Používá se na celý odstavec a liší se od visícího odsazení.

Následující samostatný příklad povolí visící interpunkci v textovém rámečku o šířce 100 bodů a uloží soubor "hanging_punctuation.pptx". S Arial 24 bodů a nulovými horizontálními okraji textového rámce zůstane poslední tečka po slově „sentence“ a prodlouží se za pravý okraj textu. Nastavte vlastnost na [NullableBool.FALSE](https://reference.aspose.com/slides/python-net/aspose.slides/nullablebool/) pro porovnání: s tímto nastavením tečka zabírá samostatný řádek. Zalamování je zapnuto a automatické přizpůsobení je vypnuto, aby šířka zůstala fixní.

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

Ne každá interpunkce může viset. Viditelný výsledek závisí na [podmínkách písma a rozvržení](#control-line-breaking): změna písma, dostupné šířky, okrajů nebo nastavení automatického přizpůsobení může rozdíl odstranit.

## **Nastavit typ automatického přizpůsobení pro textové rámečky**

[TextFrameFormat.autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/autofit_type/) určuje, jak se text chová, když přesáhne hranice svého kontejneru. Použijte jej ke kontrole, zda se text zmenší, přeteče nebo automaticky změní velikost tvaru. Následující příklad konfiguruje tvar tak, aby se změnil velikostí tak, aby odpovídal textu, a uloží výsledek do souboru "autofit_type.pptx".

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE

    presentation.save("autofit_type.pptx", slides.export.SaveFormat.PPTX)
```

Pro spočítání řádků po automatickém zalamování a zjištění, jak se mění šířka textu nebo tvaru, viz [Count Rendered Lines](/slides/cs/python-net/manage-paragraph/). Počet řádků sám o sobě neukazuje, zda text přesahuje svůj kontejner.

## **Nastavit ukotvení textových rámců**

[TextFrameFormat.anchoring_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/anchoring_type/) určuje, jak je text umístěn svisle uvnitř tvaru, například nahoře, uprostřed nebo dole. Následující příklad ukotví text ke spodní části prvního tvaru a uloží výsledek do souboru "text_anchor.pptx".

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.anchoring_type = slides.TextAnchorType.BOTTOM

    presentation.save("text_anchor.pptx", slides.export.SaveFormat.PPTX)
```

## **Nastavit tabulaci textu**

Použijte [ParagraphFormat.default_tab_size](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_tab_size/) a [ParagraphFormat.tabs](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/tabs/) pro konfiguraci tabulátorů v odstavci. Následující příklad nastaví výchozí interval tabulátoru na 100 bodů a přidá levý tabulátor na 30 bodů. Tato nastavení ovlivňují text obsahující znak tabulátoru.

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

Výsledek:

![Tabulátory odstavce](paragraph_tabs.png)

## **Nastavit jazyk korektury**

Aspose.Slides poskytuje [BasePortionFormat.language_id](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/language_id/), který umožňuje nastavit jazyk korektury pro část textu. Jazyk korektury určuje jazyk používaný pro kontrolu pravopisu a gramatiky v PowerPointu.

Následující příklad vyžaduje soubor "presentation.pptx" s textovým polem jako prvním tvarem na první snímku a alespoň jedním odstavcem. Nahrazuje obsah prvního odstavce textem „1。“, nastaví SimSun jako písmo a přiřadí jazyk korektury pro zjednodušenou čínštinu (`zh-CN`). Výsledek uloží do souboru "proofing_language.pptx":

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

    # Nastavte jazyk korektury na zjednodušenou čínštinu.
    text_portion.portion_format.language_id = "zh-CN"

    text_portion.text = "1。"
    paragraph.portions.add(text_portion)

    presentation.save("proofing_language.pptx", slides.export.SaveFormat.PPTX)
```

### **Kopírovat jazyková metadata**

Při kopírování vícejazyčného textu ze šablony zachovejte jak [BasePortionFormat.language_id](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/language_id/), tak [BasePortionFormat.alternative_language_id](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/alternative_language_id/). Následující samostatný příklad vytvoří zdrojovou část s US English jako jazykem a francouzštinou jako alternativním jazykem a zkopíruje text a identifikátory do části v nové prezentaci.

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
    # Pokud zdroj nemá alternativní jazyk, None vymaže hodnotu v cíli.
    destination.portion_format.alternative_language_id = source.portion_format.alternative_language_id
    paragraph.portions.add(destination)

    presentation.save("copied_language_metadata.pptx", slides.export.SaveFormat.PPTX)
```

Pro vyzkoušení zdroje bez alternativního jazyka vynechte přiřazení `"fr-FR"`. Alternativní identifikátor bude pak `None` a stejný příkaz pro kopírování zachová jeho nepřítomnost, aniž by zavedl výchozí hodnotu, i když cíl dříve měl nastaven alternativní jazyk.

Tyto identifikátory jsou uloženy jako jazyková metadata. Jejich zachování neovlivňuje, který slovník PowerPoint zvolí pro kontrolu pravopisu nebo gramatiky.

## **Nastavit výchozí jazyk**

Použijte [LoadOptions.default_text_language](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/default_text_language/) k definování výchozího jazyka pro text vytvářený při načítání nebo vytváření prezentace. Následující příklad vytvoří prezentaci s US English jako výchozím jazykem textu, přidá textové pole a vytiskne `en-US` pro jeho první část textu.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.default_text_language = "en-US"

with slides.Presentation(load_options) as presentation:
    slide = presentation.slides[0]

    # Přidejte nový obdélníkový tvar s textem.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 50)
    shape.text_frame.text = "Sample text"

    # Zkontrolujte jazyk první části.
    portion = shape.text_frame.paragraphs[0].portions[0]
    print(portion.portion_format.language_id)
```

## **Nastavit výchozí styl textu**

Pro použití výchozího formátování textu na úrovni celé prezentace použijte [Presentation.default_text_style](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/default_text_style/).

Následující příklad nastaví 14‑bodové tučné písmo jako výchozí pro odstavce nejvyšší úrovně v nové prezentaci a uloží jej do souboru "default_text_style.pptx". Text může tyto výchozí hodnoty zdědit, pokud není přepsán konkrétnějším formátováním.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    # Získejte formát odstavce nejvyšší úrovně.
    paragraph_format = presentation.default_text_style.get_level(0)

    if paragraph_format is not None:
        paragraph_format.default_portion_format.font_height = 14
        paragraph_format.default_portion_format.font_bold = slides.NullableBool.TRUE

    presentation.save("default_text_style.pptx", slides.export.SaveFormat.PPTX)
```

## **Extrahovat text s efektem Všechna velká písmena**

V PowerPointu aplikace efektu **All Caps** (všechna velká písmena) způsobí, že text na snímku vypadá jako velká písmena, i když byl původně zadán malými. Když takovou část textu získáte pomocí Aspose.Slides, knihovna vrátí text přesně tak, jak byl zadán. Pro shodu s zobrazeným textem zkontrolujte [TextCapType](https://reference.aspose.com/slides/python-net/aspose.slides/textcaptype/) a převeďte vrácený řetězec na velká písmena, pokud je hodnota `ALL`.

Tento příklad vyžaduje soubor "sample2.pptx" s textovým polem jako prvním tvarem na první snímku. První část prvního odstavce obsahuje „Hello, Aspose!“ s aplikovaným efektem All Caps, jak je ukázáno níže.

![Efekt All Caps](all_caps_effect.png)

Níže uvedený kód ukazuje, jak extrahovat text s **aplikovaným efektem All Caps**:

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

Výstup:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **FAQ**

**Jak upravit text v tabulce na snímku?**

Pro úpravu textu v tabulce na snímku použijte [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/). Procházejte buňky a aktualizujte každou buňku pomocí [Cell.text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/cell/text_frame/) a formátování odstavců pomocí [Paragraph.paragraph_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/paragraph_format/).

**Jak aplikovat gradientní barvu na text na snímku PowerPoint?**

Pro aplikaci gradientní barvy na text použijte [BasePortionFormat.fill_format](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/fill_format/). Nastavte [FillFormat.fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/) na [FillType.GRADIENT](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) a nakonfigurujte gradientní zastávky, směr a průhlednost.

Související funkce: [Format text within slides](/slides/cs/features/text-formatting/).