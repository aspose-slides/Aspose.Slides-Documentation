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
- mezera mezi znaky
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
description: "Formátujte a stylizujte text v prezentacích PowerPoint a OpenDocument pomocí Aspose.Slides pro Python na platformě .NET. Přizpůsobte písma, barvy, zarovnání a další."
---
## **Přehled**

Tento článek ukazuje, jak formátovat text v prezentacích PowerPoint a OpenDocument pomocí Aspose.Slides for Python via .NET. Pokrývá barvy pozadí, průhlednost, mezery mezi znaky, vlastnosti písma, otáčení, mezery odstavců, chování automatického přizpůsobení, ukotvení textu, tabulátory a nastavení jazyka.

Pokud není uvedeno jinak, příklady používají [sample.pptx](sample.pptx). První tvar na první snímku je textové pole a jeho první odstavec obsahuje text zobrazený níže. Indexy snímků i tvarů jsou nulové. Příklady, které vybírají tučné části, používají účinné formátování, včetně zděděného tučného formátování:

![Ukázkový text](sample_text.png)

Pro vyhledání a zvýraznění doslovného textu nebo shod regulárních výrazů viz [Vyhledávání a nahrazování textu](/slides/cs/python-net/search-and-replace-text/).

## **Nastavení barvy pozadí textu**

Použijte [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_portion_format/) pro nastavení výchozí barvy zvýraznění odstavce nebo použijte [BasePortionFormat.highlight_color](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/highlight_color/) pro jednotlivé textové úseky.

Následující příklad nastaví světle šedé zvýraznění jako výchozí pro první odstavec. Explicitní barvy zvýraznění na jednotlivých úsecích mají přednost před tímto výchozím nastavením:

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

Ukázkový kód níže ukazuje, jak nastavit barvu pozadí pro **textové úseky s tučným fontem**:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # Nastavte barvu zvýraznění pro textový úsek.
            portion.portion_format.highlight_color.color = draw.Color.light_gray

    presentation.save("gray_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

Výsledek:

![Průhledné textové úseky](gray_text_portions.png)

## **Zarovnání odstavců textu**

Použijte [ParagraphFormat.alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/) k nastavení zarovnání odstavce v textovém rámečku. Hodnota může být centrovaná, zarovnaná vlevo, vpravo, do bloku a podobně.

Následující ukázkový kód ukazuje, jak zarovnat odstavec do **středu**:

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

## **Zarovnání fontů v rámci řádku**

Použijte [ParagraphFormat.font_alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/font_alignment/) pro svislé zarovnání textových úseků s různými velikostmi písma v rámci řádku. Toto nastavení platí pro celý odstavec a řídí zarovnání v každém jeho řádku.

Následující samostatný příklad vytváří čtyři označená textová pole na jednom snímku. Každý odstavec obsahuje stejný text v 18, 36 a 54 bodech, s různým zarovnáním písma. Používá Arial, vypíná automatické přizpůsobení a zalamování a udržuje textové rámečky dostatečně velké pro jeden řádek.

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

![Porovnání zarovnání Baseline, Top, Center a Bottom u smíšených velikostí písma](font_alignment.png)

Zarovnání písma používá metriky fontu, takže viditelné okraje jednotlivých písmen nemusí nutně přesně ležet na sobě. Příklad obsahuje jak velké písmeno, tak spádové písmo, aby ukázal rozdíl mezi základním a spodním zarovnáním. Dostupnost fontu a jeho náhrada, použité znaky a rozdíl ve velikostech písma ovlivňují výsledek. Rozměry rámce, okraje, řádkování, zalamování a automatické přizpůsobení také ovlivňují rozvržení; pro porovnání režimů používejte stejné fonty a nastavení rozvržení.

Toto nastavení se liší od [ParagraphFormat.alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/), které řídí horizontální zarovnání odstavce, a od [TextFrameFormat.anchoring_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/anchoring_type/), které umisťuje textový blok svisle uvnitř tvaru. Formátování horního a dolního indexu přes [BasePortionFormat.escapement](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/escapement/) posouvá jednotlivé úseky relativně k základní linii místo nastavení svislého zarovnání řádků odstavce.

## **Nastavení průhlednosti textu**

Průhlednost textu se řídí alfa-složkou barvy přiřazené k [BasePortionFormat.fill_format](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/fill_format/). V níže uvedených příkladech je `alpha = 50` hodnota kanálu ARGB na stupnici 0–255, nikoli procento průhlednosti.

Následující ukázkový kód ukazuje, jak aplikovat průhlednost na **celý odstavec**:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

alpha = 50

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Nastavte poloprůhlednou černou výplň pro text.
    paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.from_argb(alpha, draw.Color.black)

    presentation.save("transparent_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

Výsledek:

![Průhledný odstavec](transparent_paragraph.png)

Následující ukázkový kód ukazuje, jak aplikovat průhlednost na **textové úseky s tučným fontem**:

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
            # Nastavte průhlednost textového úseku.
            portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
            portion.portion_format.fill_format.solid_fill_color.color = draw.Color.from_argb(alpha, draw.Color.black)

    presentation.save("transparent_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

Výsledek:

![Průhledné textové úseky](transparent_text_portions.png)

## **Nastavení mezery mezi znaky textu**

Použijte [BasePortionFormat.spacing](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/spacing/) pro rozšíření nebo zmenšení mezery mezi znaky v textovém poli. Příklady přidávají 3 body mezery; záporné hodnoty mezery textu zmenšují.

Následující Python kód ukazuje, jak rozšířit mezeru mezi znaky v **celém odstavci**:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Poznámka: Použijte záporné hodnoty pro zúžení mezery mezi znaky.
    paragraph.paragraph_format.default_portion_format.spacing = 3  # Zvětšit mezeru mezi znaky.

    presentation.save("character_spacing_in_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

Výsledek:

![Mezera mezi znaky v odstavci](character_spacing_in_paragraph.png)

Ukázkový kód níže ukazuje, jak rozšířit mezeru mezi znaky v **textových úsecích s tučným fontem**:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # Poznámka: Použijte záporné hodnoty pro zúžení mezery mezi znaky.
            portion.portion_format.spacing = 3  # Zvětšit mezeru mezi znaky.

    presentation.save("character_spacing_in_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

Výsledek:

![Mezera mezi znaky v textových úsecích](character_spacing_in_text_portions.png)

### **Zakázání kerningu pro konkrétní fonty**

V některých případech může text vykreslený knihovnou Aspose.Slides vypadat mírně těsněji než stejný text zobrazený v PowerPointu. K tomu může dojít, protože PowerPoint může ignorovat kerningová data pro určité fonty, i když font obsahuje platná kerningová data a kerning je v nastavení PowerPointu povolen.

Aby výstup byl v takových situacích bližší PowerPointu, můžete pro textové úseky používající dotčený font kerning zakázat. Nastavte [BasePortionFormat.kerning_minimal_size](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/kerning_minimal_size/) na hodnotu větší než skutečná velikost fontu. Tento příklad vyžaduje soubor "presentation.pptx" s textovým polem jako prvním tvarem na prvním snímku. Kontroluje účinná jména fontů, včetně zděděných, a nastavuje prahovou hodnotu 100 bodů pro úseky používající Roboto. Tím se zakáže kerning pro úseky s touto velikostí menší než 100 bodů:

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

Pro úseky pod prahem toto nastavení zakazuje kerning a může pomoci sladit vykreslování Aspose.Slides s vizuálním výstupem PowerPointu u fontů, na které toto chování PowerPointu působí.

## **Správa vlastností fontu textu**

Vlastnosti fontu lze nastavit na úrovni odstavce pomocí [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_portion_format/) nebo na jednotlivých úsecích pomocí [PortionFormat](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/).

Následující příklad nastaví výchozí font prvního odstavce na Times New Roman 12 bodů s tučným, kurzívou a tečkovaným podtržením. Explicitní formátování na jednotlivých úsecích má přednost před těmito výchozími hodnotami:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Nastavte vlastnosti fontu pro odstavec.
    portion_format = paragraph.paragraph_format.default_portion_format
    portion_format.font_height = 12
    portion_format.font_bold = slides.NullableBool.TRUE
    portion_format.font_italic = slides.NullableBool.TRUE
    portion_format.font_underline = slides.TextUnderlineType.DOTTED
    portion_format.latin_font = slides.FontData("Times New Roman")

    presentation.save("font_properties_for_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

Výsledek:

![Vlastnosti fontu pro odstavec](font_properties_for_paragraph.png)

Následující příklad aplikuje Times New Roman 13 bodů, kurzívu a tečkované podtržení na úseky, jejichž účinné formátování je tučné:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # Nastavte vlastnosti fontu pro textový úsek.
            portion.portion_format.font_height = 13
            portion.portion_format.font_italic = slides.NullableBool.TRUE
            portion.portion_format.font_underline = slides.TextUnderlineType.DOTTED
            portion.portion_format.latin_font = slides.FontData("Times New Roman")

    presentation.save("font_properties_for_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

Výsledek:

![Vlastnosti fontu pro textové úseky](font_properties_for_text_portions.png)

## **Kontrola normalizace výšky textu**

Použijte [BasePortionFormat.normalise_height](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/normalise_height/) při reprodukci typografie šablony nebo zkoumání rozdílů ve výšce znaků. V PowerPointu povolení normalizace rozprostře nebo zmenší jednotlivé znaky vertikálně tak, aby měly jednotnou viditelnou výšku v rámci textového úseku. Normalizace neznamená, že výšky textu budou stejné napříč různými fonty.

Nastavte vlastnost na [NullableBool.TRUE nebo FALSE](https://reference.aspose.com/slides/python-net/aspose.slides/nullablebool/) pro explicitní povolení nebo zakázání normalizace. `NullableBool.NOT_DEFINED` ponechává lokální nastavení nevyplněné, takže úsek dědí hodnotu, například z [default_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_portion_format/) odstavce. Neznamená to `False`. Použijte [PortionFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/get_effective/) a přečtěte [IBasePortionFormatEffectiveData.normalise_height](https://reference.aspose.com/slides/python-net/aspose.slides/ibaseportionformateffectivedata/normalise_height/) pro získání vyřešené Boolean hodnoty.

Následující samostatný příklad vyžaduje **Arial** nainstalovaný. Vytváří dva textové bloky obsahující stejné velká písmena, malá písmena, spádové znaky a diakritiku při 54 bodech. Oba odstavce mají standardně normalizaci povolenu. Horní úsek ji explicitně zakazuje; spodní úsek ji dědí. Rozměry rámců, okraje a mezery odstavců jsou identické, přičemž zalamování a automatické přizpůsobení jsou vypnuté pro zachování konzistence porovnání. Příklad vypisuje `FALSE: False` a `NOT_DEFINED: True` a poté ukládá "text_height_normalization.pptx".

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

Porovnání níže bylo exportováno ze uložené prezentace. Horní řada má normalizaci zakázanou (`FALSE`); spodní řada ji dědí (`NOT_DEFINED` → `True`). Pro reprodukci tohoto vzhledu mějte nainstalovaný Arial.

![Arial 54‑bodový text s normalizací zakázanou nahoře a zděděnou normalizací povolenou dole](text_height_normalization.png)

Normalizace mění výšku znaků, aniž by měnila přiřazenou hodnotu [font_height](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/font_height/), která určuje velikost fontu v bodech. Odstavecní [space_within](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_within/) řídí řádkování, zatímco [autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/autofit_type/) textového rámce určuje, jak se text nebo jeho kontejner přizpůsobí. Tato nastavení slouží k odlišným účelům a mohou nezávisle ovlivnit celkové rozvržení. Další informace o formátování odstavců a dědičnosti najdete v článku [Správa odstavců](/slides/cs/python-net/manage-paragraph/).

## **Použití a odebrání přeškrtnutí**

Použijte [BasePortionFormat.strikethrough_type](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/strikethrough_type/) na textovém úseku pro zobrazení oprav, zrušených výrazů nebo předchozích cen bez odstranění původního textu. Nastavte na [TextStrikethroughType.SINGLE nebo DOUBLE](https://reference.aspose.com/slides/python-net/aspose.slides/textstrikethroughtype/) pro jednu nebo dvě čáry přes text.

Pro odebrání přeškrtnutí přiřaďte `TextStrikethroughType.NONE`. Tím se explicitně zakáže efekt, i když okolní formátování přeškrtnutí specifikuje. Naopak `TextStrikethroughType.NOT_DEFINED` nechává lokální nastavení nedefinované, takže úsek může dědit formátování, například z odstavce. To nezaručuje, že přeškrtnutí bude odstraněno. Použijte [PortionFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/get_effective/) pro čtení výsledného formátování, včetně zděděných hodnot.

Následující samostatný příklad vytváří tři srovnání cen. Každý odstavec má samostatné úseky pro popisek, předchozí cenu a aktuální cenu, takže pouze předchozí cena je ovlivněna. První řada aplikuje a následně odebere přeškrtnutí; ostatní řady zachovávají jednoduché a dvojité přeškrtnutí. Změna této vlastnosti zachovává text i ostatní formátování, včetně tučné předchozí ceny.

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

    # Použijte přeškrtnutí, poté jej explicitně odeberte z první předchozí ceny.
    paragraphs[0].portions[1].portion_format.strikethrough_type = slides.TextStrikethroughType.SINGLE
    paragraphs[0].portions[1].portion_format.strikethrough_type = slides.TextStrikethroughType.NONE

    paragraphs[1].portions[1].portion_format.strikethrough_type = slides.TextStrikethroughType.SINGLE
    paragraphs[2].portions[1].portion_format.strikethrough_type = slides.TextStrikethroughType.DOUBLE

    presentation.save("strikethrough.pptx", slides.export.SaveFormat.PPTX)
```

Výsledek z vrchu dolů: žádné přeškrtnutí, jednoduché přeškrtnutí a dvojité přeškrtnutí.

![Předchozí ceny bez přeškrtnutí, s jednoduchým přeškrtnutím a s dvojitým přeškrtnutím](strikethrough.png)

## **Nastavení otáčení textu**

Použijte [TextFrameFormat.text_vertical_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/text_vertical_type/) pro nastavení předdefinované orientace textu uvnitř tvaru.

Následující kód nastaví orientaci textu v tvaru na [TextVerticalType.VERTICAL270](https://reference.aspose.com/slides/python-net/aspose.slides/textverticaltype/), což otáčí text **o 90 stupňů proti směru hodinových ručiček**:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL270

    presentation.save("text_rotation.pptx", slides.export.SaveFormat.PPTX)
```

Výsledek:

![Otáčení textu](text_rotation.png)

## **Zobrazení číslic vedle sebe ve svislém textu**

Aby se dvouciferné číslo v svislém japonském popisku udrželo pohromadě, umístěte obě číslice do jednoho textového úseku a nastavte [BasePortionFormat.kumimoji](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/kumimoji/) na tomto úseku. Příklad vytváří dva popisky v nové prezentaci pomocí [TextVerticalType.EAST_ASIAN_VERTICAL](https://reference.aspose.com/slides/python-net/aspose.slides/textverticaltype/) a 40‑bodového MS Gothic. Pouze hodnota [NullableBool](https://reference.aspose.com/slides/python-net/aspose.slides/nullablebool/) přiřazená číselnému úseku se liší.

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

V PowerPointu levý popisek (`TRUE`) zobrazuje číslice svisle a vedle sebe mezi znaky 和 a 年. Pravý popisek (`FALSE`) otáčí dvojici o 90 stupňů po směru hodinových ručiček. Ostatní japonské znaky zůstávají svislé v obou popiscích.

![Porovnání svislých datumových popisků v PowerPointu – číslice svisle vlevo a otočené vpravo](vertical_date.png)

## **Nastavení vlastní rotace pro textové rámečky**

Použijte [TextFrameFormat.rotation_angle](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/rotation_angle/) pro nastavení vlastní úhlu rotace [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/).

Ukázkový kód níže otáčí textový rámec o 3 stupně po směru hodinových ručiček uvnitř tvaru:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.rotation_angle = 3

    presentation.save("custom_text_rotation.pptx", slides.export.SaveFormat.PPTX)
```

Výsledek:

![Vlastní otáčení textu](custom_text_rotation.png)

## **Nastavení řádkování odstavců**

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

Pravidla zalamování řádků odstavce jsou užitečná v úzkých textových blocích a prezentacích, které kombinují latinské a východoasijské texty. Následující vlastnosti patří do [ParagraphFormat](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/), takže se vztahují na celý odstavec:

- [latin_line_break](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/latin_line_break/) řídí pravidla zalamování pro latinsky psané řádky. V smíšeném textu může jeho změna také ovlivnit, kde se zalamují sousední východoasijské znaky a interpunkce.
- [east_asian_line_break](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/east_asian_line_break/) řídí pravidla zalamování pro východoasijské řádky, včetně omezení znaků na začátku a konci řádku.

Tato pravidla nenahrazují [TextFrameFormat.wrap_text](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/wrap_text/), které povoluje automatické zalamování v textovém rámečku. Ovlivňují rozvržení, když k zalamování dochází; nevkládají znaky konce řádku. Explicitní zalomení řádku vynutí nový řádek v odstavci nezávisle na dostupné šířce.

Následující samostatný příklad vytváří úzký textový blok obsahující čínštinu a latinku. Nastavuje explicitně obě vlastnosti zalamování řádků a ukládá "line_breaking.pptx". Pro experiment s libovolným pravidlem změňte hodnotu dané vlastnosti při zachování ostatních nastavení. Příklad používá 24‑bodový Arial a SimSun, šířku rámce 160 bodů a nulové vodorovné okraje textového rámce. [TextFrameFormat.autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/autofit_type/) je nastaven na [TextAutofitType.NONE](https://reference.aspose.com/slides/python-net/aspose.slides/textautofittype/), aby zůstala velikost textu i rozměry rámce pevné.

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

[ParagraphFormat.hanging_punctuation](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/hanging_punctuation/) umožňuje oprávněné interpunkci vystoupit za pravý okraj řádku místo aby zabírala následující řádek. Platí pro celý odstavec a liší se od visícího odsazení.

Následující samostatný příklad povolí visící interpunkci v 100‑bodovém širokém textovém rámečku a uloží "hanging_punctuation.pptx". S 24‑bodovým Arial a nulovými vodorovnými okraji textového rámce zůstane poslední tečka po slově "sentence" a vystoupí za pravý okraj textu. Nastavte vlastnost na [NullableBool.FALSE](https://reference.aspose.com/slides/python-net/aspose.slides/nullablebool/) pro porovnání: s tímto nastavením tečka zabírá samostatný řádek. Zalamování je povoleno a automatické přizpůsobení vypnuto, aby byla šířka pevná.

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

Ne každá interpunkční značka může viset. Viditelný výsledek závisí na [fontu a podmínkách rozvržení](#control-line-breaking): změna fontu, dostupné šířky, okrajů nebo nastavení automatického přizpůsobení může rozdíl odstranit.

## **Nastavení typu automatického přizpůsobení pro textové rámečky**

[TextFrameFormat.autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/autofit_type/) určuje, jak se text chová, když přesáhne hranice svého kontejneru. Použijte jej k řízení, zda se text zmenší, přeteče, nebo zda se tvar automaticky přizpůsobí. Následující příklad konfiguruje tvar tak, aby se velikost přizpůsobila textu, a výsledek uloží do "autofit_type.pptx".

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE

    presentation.save("autofit_type.pptx", slides.export.SaveFormat.PPTX)
```

Pro spočítání řádků po automatickém zalomení a zobrazení, jak se mění šířka textu nebo tvaru, viz [Počítání vykreslených řádků](/slides/cs/python-net/manage-paragraph/). Počet řádků sám o sobě neukazuje, zda text přesahuje svůj kontejner.

## **Nastavení ukotvení textových rámců**

[TextFrameFormat.anchoring_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/anchoring_type/) určuje, jak je text vertikálně umístěn uvnitř tvaru, například nahoře, uprostřed nebo dole. Následující příklad ukotví text na spodní část prvního tvaru a výsledek uloží do "text_anchor.pptx".

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.anchoring_type = slides.TextAnchorType.BOTTOM

    presentation.save("text_anchor.pptx", slides.export.SaveFormat.PPTX)
```

## **Nastavení tabulace textu**

Použijte [ParagraphFormat.default_tab_size](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_tab_size/) a [ParagraphFormat.tabs](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/tabs/) pro konfiguraci tabulátorů v odstavci. Následující příklad nastaví výchozí interval tabulátoru na 100 bodů a přidá levý zarovnaný tabulátor na 30 bodů. Tato nastavení ovlivňují text obsahující znaky tabulátoru.

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

## **Nastavení jazyka pro kontrolu pravopisu**

Aspose.Slides poskytuje [BasePortionFormat.language_id](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/language_id/), který umožňuje nastavit jazyk pro kontrolu pravopisu a gramatiky textového úseku. Jazyk pro kontrolu pravopisu určuje, jaký jazyk se použije pro kontrolu pravopisu a gramatiky v PowerPointu.

Následující příklad vyžaduje "presentation.pptx" s textovým polem jako prvním tvarem na prvním snímku a alespoň jedním odstavcem. Nahrazuje obsah prvního odstavce řetězcem "1。", nastaví SimSun jako jeho font a přiřadí zjednodušený čínský jazyk pro kontrolu pravopisu (`zh-CN`). Výsledek uloží do "proofing_language.pptx":

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

    # Nastavte jazyk kontroly pravopisu na zjednodušenou čínštinu.
    text_portion.portion_format.language_id = "zh-CN"

    text_portion.text = "1。"
    paragraph.portions.add(text_portion)

    presentation.save("proofing_language.pptx", slides.export.SaveFormat.PPTX)
```

### **Kopírování jazykových metadat**

Při kopírování vícejazyčného textu ze šablony zachovejte jak [BasePortionFormat.language_id](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/language_id/), tak [BasePortionFormat.alternative_language_id](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/alternative_language_id/). Následující samostatný příklad vytváří zdrojový úsek s jazykem US English a alternativním jazykem French a kopíruje text i identifikátory do úseku v nové prezentaci.

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

Pro vyzkoušení zdroje bez alternativního jazyka vynechejte přiřazení `"fr-FR"`. Alternativní identifikátor bude pak `None` a stejný příkaz pro kopírování zachová jeho nepřítomnost, aniž by vložil výchozí hodnotu, i když cíl dříve měl alternativní jazyk přiřazen.

Tyto identifikátory jsou uloženy jako jazyková metadata. Zachování neznamená, který slovník PowerPoint vybere pro kontrolu pravopisu nebo gramatiky.

## **Nastavení výchozího jazyka**

Použijte [LoadOptions.default_text_language](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/default_text_language/) pro definování výchozího jazyka textu vytvářeného během načítání nebo vytváření prezentace. Následující příklad vytvoří prezentaci s výchozím jazykem textu US English, přidá textové pole a vypíše `en-US` pro jeho první textový úsek.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.default_text_language = "en-US"

with slides.Presentation(load_options) as presentation:
    slide = presentation.slides[0]

    # Přidejte nový obdélníkový tvar s textem.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 50)
    shape.text_frame.text = "Sample text"

    # Zkontrolujte jazyk první úseku.
    portion = shape.text_frame.paragraphs[0].portions[0]
    print(portion.portion_format.language_id)
```

## **Nastavení výchozího stylu textu**

Pro aplikaci výchozího formátování textu na úrovni prezentace použijte [Presentation.default_text_style](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/default_text_style/).

Následující příklad nastaví 14‑bodový tučný font jako výchozí pro odstavce nejvyšší úrovně v nové prezentaci a výsledek uloží do "default_text_style.pptx". Text může tato výchozí nastavení dědit, pokud je nepřepíše konkrétnější formátování.

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

## **Extrahování textu s efektem Všechna velká písmena**

V PowerPointu aplikace efektu **All Caps** na font způsobí, že se text na snímku zobrazuje velkými písmeny, i když byl původně zadán malými. Když takový textový úsek získáte pomocí Aspose.Slides, knihovna vrátí text přesně tak, jak byl zadán. Pro shodu se zobrazeným textem zkontrolujte [TextCapType](https://reference.aspose.com/slides/python-net/aspose.slides/textcaptype/) a při hodnotě `ALL` převeďte vrácený řetězec na velká písmena.

Tento příklad vyžaduje "sample2.pptx" s textovým polem jako prvním tvarem na prvním snímku. Jeho první odstavec první úsek obsahuje "Hello, Aspose!" s aplikovaným efektem All Caps, jak je znázorněno níže.

![Efekt Všechna velká písmena](all_caps_effect.png)

Ukázkový kód níže ukazuje, jak extrahovat text s aplikovaným efektem **All Caps**:

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

## **Často kladené otázky**

**Jak mohu upravit text v tabulce na snímku?**

Pro úpravu textu v tabulce na snímku použijte [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/). Procházejte buňky a aktualizujte každou buňku přes [Cell.text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/cell/text_frame/) a formátování odstavců přes [Paragraph.paragraph_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/paragraph_format/).

**Jak mohu na text v PowerPoint snímku aplikovat gradientní barvu?**

Pro aplikaci gradientní barvy na text použijte [BasePortionFormat.fill_format](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/fill_format/). Nastavte [FillFormat.fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/) na [FillType.GRADIENT](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) a nakonfigurujte gradientní zastávky, směr a průhlednost.

Související funkce: [Formátování textu v prezentacích](/slides/cs/features/text-formatting/).