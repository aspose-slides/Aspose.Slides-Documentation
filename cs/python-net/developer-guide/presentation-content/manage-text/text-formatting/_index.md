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
- rotace textu
- úhel rotace
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

Tento článek ukazuje, jak formátovat text v prezentacích PowerPoint a OpenDocument pomocí Aspose.Slides pro Python přes .NET. Pokrývá barvy pozadí, průhlednost, mezery mezi znaky, vlastnosti písma, rotaci, mezery odstavců, chování automatického přizpůsobení, ukotvení textu, tabulátory a nastavení jazyka.

V níže uvedených příkladech použijeme soubor nazvaný "sample.pptx", který obsahuje jediný textový rámeček na první snímku s následujícím textem:

![Ukázkový text](sample_text.png)

Pro vyhledání a zvýraznění doslovného textu nebo shod regulárních výrazů viz [Vyhledat a nahradit text](/slides/cs/python-net/search-and-replace-text/).

## **Nastavit barvu pozadí textu**

Pomocí [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/cs/python-net/aspose.slides/paragraphformat/default_portion_format/) nastavíte výchozí barvu zvýraznění pro odstavec, nebo použijte [PortionFormat.highlight_color](https://reference.aspose.com/slides/cs/python-net/aspose.slides/portionformat/highlight_color/) pro jednotlivé části textu.

Následující ukázka kódu ukazuje, jak nastavit barvu pozadí pro **celý odstavec**:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Nastavte barvu zvýraznění pro celý odstavec.
    paragraph.paragraph_format.default_portion_format.highlight_color.color = draw.Color.light_gray

    presentation.save("gray_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

Výsledek:

![Šedý odstavec](gray_paragraph.png)

Níže uvedená ukázka kódu demonstruje, jak nastavit barvu pozadí pro **části textu s tučným písmem**:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # Nastavte barvu zvýraznění pro část textu.
            portion.portion_format.highlight_color.color = draw.Color.light_gray

    presentation.save("gray_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

Výsledek:

![Šedé části textu](gray_text_portions.png)

## **Zarovnat textové odstavce**

Pomocí [ParagraphFormat.alignment](https://reference.aspose.com/slides/cs/python-net/aspose.slides/paragraphformat/alignment/) nastavíte zarovnání odstavce v textovém rámečku. Hodnota může být centrovaná, zarovnaná vlevo, vpravo, zarovnaná do bloku a podobně.

Následující ukázka kódu ukazuje, jak zarovnat odstavec **na střed**:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Nastavte zarovnání odstavce na střed.
    paragraph.paragraph_format.alignment = slides.TextAlignment.CENTER

    presentation.save("aligned_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

Výsledek:

![Zarovnaný odstavec](aligned_paragraph.png)

## **Nastavit průhlednost textu**

Průhlednost textu se řídí alfa komponentou barvy přiřazené k [PortionFormat.fill_format](https://reference.aspose.com/slides/cs/python-net/aspose.slides/portionformat/fill_format/). V níže uvedených příkladech je `alpha = 50` hodnota alfa kanálu ARGB v rozsahu 0‑255, nikoli procento průhlednosti.

Ukázka kódu níže ukazuje, jak aplikovat průhlednost na **celý odstavec**:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

alpha = 50

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Nastavte výplňovou barvu textu na průhlednou barvu.
    paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.from_argb(alpha, draw.Color.black)

    presentation.save("transparent_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

Výsledek:

![Průhledný odstavec](transparent_paragraph.png)

Následující ukázka kódu ukazuje, jak aplikovat průhlednost na **části textu s tučným písmem**:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

alpha = 50

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
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

## **Nastavit mezery mezi znaky v textu**

Pomocí [BasePortionFormat.spacing](https://reference.aspose.com/slides/cs/python-net/aspose.slides/baseportionformat/spacing/) rozšíříte nebo zmenšíte mezery mezi znaky v textovém rámečku.

Následující Python kód ukazuje, jak rozšířit mezery mezi znaky v **celém odstavci**:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Poznámka: Použijte záporné hodnoty ke zmenšení mezery mezi znaky.
    paragraph.paragraph_format.default_portion_format.spacing = 3  # Zvětšit mezeru mezi znaky.

    presentation.save("character_spacing_in_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

Výsledek:

![Mezery mezi znaky v odstavci](character_spacing_in_paragraph.png)

Ukázka kódu níže ukazuje, jak rozšířit mezery mezi znaky v **částech textu s tučným písmem**:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # Poznámka: Použijte záporné hodnoty ke zmenšení mezery mezi znaky.
            portion.portion_format.spacing = 3  # Zvětšit mezeru mezi znaky.

    presentation.save("character_spacing_in_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

Výsledek:

![Mezery mezi znaky v částích textu](character_spacing_in_text_portions.png)

### **Zakázat kerningu pro konkrétní písma**

V některých případech může text vykreslený pomocí Aspose.Slides vypadat mírně těsněji než stejný text zobrazený v PowerPointu. K tomu může dojít, protože PowerPoint může ignorovat data kerningu pro určitá písma, i když písmo obsahuje platné informace o kerningu a kerning je v nastavení PowerPointu povolen.

Aby byl výstup rendering blíže PowerPointu, můžete v takových případech zakázat kerning pro části textu, které používají dotčené písmo. Nastavte [BasePortionFormat.kerning_minimal_size](https://reference.aspose.com/slides/cs/python-net/aspose.slides/baseportionformat/kerning_minimal_size/) na hodnotu podstatně větší než skutečná velikost písma:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    target_font = "Roboto"

    for paragraph in auto_shape.text_frame.paragraphs:
        for portion in paragraph.portions:
            latin_font = portion.portion_format.latin_font
            east_asian_font = portion.portion_format.east_asian_font
            complex_script_font = portion.portion_format.complex_script_font

            if ((latin_font is not None and latin_font.font_name == target_font) or
                    (east_asian_font is not None and east_asian_font.font_name == target_font) or
                    (complex_script_font is not None and complex_script_font.font_name == target_font)):
                portion.portion_format.kerning_minimal_size = 100

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Spravovat vlastnosti písma textu**

Vlastnosti písma lze nastavit na úrovni odstavce pomocí [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/cs/python-net/aspose.slides/paragraphformat/default_portion_format/) nebo na jednotlivých částech pomocí [PortionFormat](https://reference.aspose.com/slides/cs/python-net/aspose.slides/portionformat/).

Následující kód nastavuje písmo a styl textu pro celý odstavec: použije velikost písma, tučné, kurzívu, tečkované podtržení a písmo Times New Roman na všechny části odstavce.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Nastavte vlastnosti písma pro odstavec.
    paragraph.paragraph_format.default_portion_format.font_height = 12
    paragraph.paragraph_format.default_portion_format.font_bold = slides.NullableBool.TRUE
    paragraph.paragraph_format.default_portion_format.font_italic = slides.NullableBool.TRUE
    paragraph.paragraph_format.default_portion_format.font_underline = slides.TextUnderlineType.DOTTED
    paragraph.paragraph_format.default_portion_format.latin_font = slides.FontData("Times New Roman")

    presentation.save("font_properties_for_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

Výsledek:

![Vlastnosti písma pro odstavec](font_properties_for_paragraph.png)

Ukázka kódu níže aplikuje podobné vlastnosti na **části textu s tučným písmem**:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
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

![Vlastnosti písma pro části textu](font_properties_for_text_portions.png)

## **Nastavit rotaci textu**

Pomocí [TextFrameFormat.text_vertical_type](https://reference.aspose.com/slides/cs/python-net/aspose.slides/textframeformat/text_vertical_type/) nastavíte předdefinovanou orientaci textu uvnitř tvaru.

Následující ukázka kódu nastaví orientaci textu ve tvaru na `VERTICAL270`, což otáčí text **o 90 stupňů proti směru hodinových ručiček**:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]

    auto_shape.text_frame.text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL270

    presentation.save("text_rotation.pptx", slides.export.SaveFormat.PPTX)
```

Výsledek:

![Rotace textu](text_rotation.png)

## **Nastavit vlastní rotaci textových rámců**

Pomocí [TextFrameFormat.rotation_angle](https://reference.aspose.com/slides/cs/python-net/aspose.slides/textframeformat/rotation_angle/) nastavíte vlastní úhel rotace pro [TextFrame](https://reference.aspose.com/slides/cs/python-net/aspose.slides/textframe/).

Ukázka kódu níže otáčí textový rámec o 3 stupně po směru hodinových ručiček uvnitř tvaru:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]

    auto_shape.text_frame.text_frame_format.rotation_angle = 3

    presentation.save("custom_text_rotation.pptx", slides.export.SaveFormat.PPTX)
```

Výsledek:

![Vlastní rotace textu](custom_text_rotation.png)

## **Nastavit řádkování odstavců**

Aspose.Slides poskytuje [ParagraphFormat.space_after](https://reference.aspose.com/slides/cs/python-net/aspose.slides/paragraphformat/space_after/), [ParagraphFormat.space_before](https://reference.aspose.com/slides/cs/python-net/aspose.slides/paragraphformat/space_before/) a [ParagraphFormat.space_within](https://reference.aspose.com/slides/cs/python-net/aspose.slides/paragraphformat/space_within/) k řízení mezer odstavců. Tyto vlastnosti se používají následovně:

* Použijte kladnou hodnotu k určení řádkování jako procento výšky řádku.
* Použijte zápornou hodnotu k určení řádkování v bodech.

Následující ukázka kódu ukazuje, jak specifikovat řádkování v odstavci:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    paragraph.paragraph_format.space_within = 200

    presentation.save("line_spacing.pptx", slides.export.SaveFormat.PPTX)
```

Výsledek:

![Řádkování v odstavci](line_spacing.png)

## **Nastavit typ automatického přizpůsobení pro textové rámce**

[TextFrameFormat.autofit_type](https://reference.aspose.com/slides/cs/python-net/aspose.slides/textframeformat/autofit_type/) určuje, jak se text chová, když přesáhne hranice svého kontejneru. Použijte jej ke kontrole, zda se text zmenší, přeteče nebo tvar automaticky změní velikost.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]

    auto_shape.text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE

    presentation.save("autofit_type.pptx", slides.export.SaveFormat.PPTX)
```

## **Nastavit ukotvení textových rámců**

[TextFrameFormat.anchoring_type](https://reference.aspose.com/slides/cs/python-net/aspose.slides/textframeformat/anchoring_type/) určuje, jak je text vertikálně umístěn uvnitř tvaru, např. nahoře, uprostřed nebo dole.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]

    auto_shape.text_frame.text_frame_format.anchoring_type = slides.TextAnchorType.BOTTOM

    presentation.save("text_anchor.pptx", slides.export.SaveFormat.PPTX)
```

## **Nastavit tabulaci textu**

Pomocí [ParagraphFormat.default_tab_size](https://reference.aspose.com/slides/cs/python-net/aspose.slides/paragraphformat/default_tab_size/) a [ParagraphFormat.tabs](https://reference.aspose.com/slides/cs/python-net/aspose.slides/paragraphformat/tabs/) nakonfigurujete tabulátory v odstavci.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    paragraph.paragraph_format.default_tab_size = 100
    paragraph.paragraph_format.tabs.add(30, slides.TabAlignment.LEFT)

    presentation.save("paragraph_tabs.pptx", slides.export.SaveFormat.PPTX)
```

Výsledek:

![Tabulátory odstavce](paragraph_tabs.png)

## **Nastavit jazyk kontroly pravopisu**

Aspose.Slides poskytuje [PortionFormat.language_id](https://reference.aspose.com/slides/cs/python-net/aspose.slides/portionformat/language_id/), což vám umožní nastavit jazyk kontroly pravopisu pro část textu. Jazyk kontroly určuje jazyk použitý pro kontrolu pravopisu a gramatiky v PowerPointu.

Následující ukázka kódu ukazuje, jak nastavit jazyk kontroly pravopisu pro část textu:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]

    paragraph = auto_shape.text_frame.paragraphs[0]
    paragraph.portions.clear()

    font = slides.FontData("SimSun")

    text_portion = slides.Portion()
    text_portion.portion_format.complex_script_font = font
    text_portion.portion_format.east_asian_font = font
    text_portion.portion_format.latin_font = font

    # Nastavte Id jazykové kontroly pravopisu.
    text_portion.portion_format.language_id = "zh-CN"

    text_portion.text = "1。"
    paragraph.portions.add(text_portion)

    presentation.save("proofing_language.pptx", slides.export.SaveFormat.PPTX)
```

## **Nastavit výchozí jazyk**

Použijte [LoadOptions.default_text_language](https://reference.aspose.com/slides/cs/python-net/aspose.slides/loadoptions/default_text_language/) k definování výchozího jazyka pro text vytvořený při načítání nebo vytváření prezentace.

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

Pro použití výchozího formátování textu na úrovni prezentace použijte [Presentation.default_text_style](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/default_text_style/). Následující ukázka kódu ukazuje, jak nastavit výchozí tučné písmo o velikosti 14 pt pro celý text napříč snímky v nové prezentaci.

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

## **Extrahovat text s efektem VELKÁ PÍSMENA**

V PowerPointu aplikace efektu **All Caps** (všechna písmena velká) způsobí, že se text na snímku zobrazuje velkými písmeny, i když byl původně napsán malými. Když takovou část textu načtete pomocí Aspose.Slides, knihovna vrátí text přesně tak, jak byl zadán. Pro shodu s zobrazeným textem zkontrolujte [TextCapType](https://reference.aspose.com/slides/cs/python-net/aspose.slides/textcaptype/) a pokud je hodnota `ALL`, převeďte vrácený řetězec na velká písmena.

Řekněme, že na první snímek souboru sample2.pptx máme následující textový rámeček.

![Efekt Všechna velká písmena](all_caps_effect.png)

Ukázka kódu níže ukazuje, jak extrahovat text s aplikovaným efektem **All Caps**:

```python
import aspose.slides as slides

with slides.Presentation("sample2.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
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

**Jak upravit text v tabulce na snímku?**

Pro úpravu textu v tabulce na snímku použijte [Table](https://reference.aspose.com/slides/cs/python-net/aspose.slides/table/). Projděte buňky a aktualizujte každou buňku pomocí [Cell.text_frame](https://reference.aspose.com/slides/cs/python-net/aspose.slides/cell/text_frame/) a formátování odstavců pomocí [Paragraph.paragraph_format](https://reference.aspose.com/slides/cs/python-net/aspose.slides/paragraph/paragraph_format/).

**Jak aplikovat gradientní barvu na text v PowerPoint snímku?**

Pro aplikaci gradientní barvy na text použijte [PortionFormat.fill_format](https://reference.aspose.com/slides/cs/python-net/aspose.slides/portionformat/fill_format/). Nastavte [FillFormat.fill_type](https://reference.aspose.com/slides/cs/python-net/aspose.slides/fillformat/fill_type/) na [FillType.GRADIENT](https://reference.aspose.com/slides/cs/python-net/aspose.slides/filltype/) a nakonfigurujte gradientové zastavení, směr a průhlednost.