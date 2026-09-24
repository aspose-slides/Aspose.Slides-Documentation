---
title: Formátování textu v prezentaci v Pythonu
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
- úhel otáčení
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
description: "Formátujte a stylizujte text v prezentacích PowerPoint a OpenDocument pomocí Aspose.Slides pro Python prostřednictvím .NET. Přizpůsobte písma, barvy, zarovnání a další."
---
## **Přehled**

Tento článek ukazuje, jak formátovat text v prezentacích PowerPoint a OpenDocument pomocí Aspose.Slides pro Python prostřednictvím .NET. Pokrývá barvy pozadí, průhlednost, mezery mezi znaky, vlastnosti písma, otáčení, mezery odstavců, chování automatického přizpůsobení, ukotvení textu, tabulátory a nastavení jazyka.

V níže uvedených příkladech použijeme soubor pojmenovaný „sample.pptx“, který obsahuje jedno textové pole na první snímku s následujícím textem:

![Ukázkový text](sample_text.png)

Pro vyhledání a zvýraznění doslovného textu nebo shod regulárních výrazů viz [Vyhledávání a nahrazování textu](/slides/cs/python-net/search-and-replace-text/).

## **Nastavení barvy pozadí textu**

Použijte [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/cs/python-net/aspose.slides/paragraphformat/default_portion_format/) k nastavení výchozí barvy zvýraznění pro odstavec nebo použijte [PortionFormat.highlight_color](https://reference.aspose.com/slides/cs/python-net/aspose.slides/portionformat/highlight_color/) pro jednotlivé části textu.

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

Následující ukázka kódu demonstruje, jak nastavit barvu pozadí pro **části textu s tučným písmem**:

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

## **Zarovnání textových odstavců**

Použijte [ParagraphFormat.alignment](https://reference.aspose.com/slides/cs/python-net/aspose.slides/paragraphformat/alignment/) k nastavení zarovnání odstavce v textovém rámci. Hodnota může být centrovaná, zarovnaná vlevo, vpravo, zarovnaná do bloku a tak dále.

Následující ukázka kódu ukazuje, jak zarovnat odstavec do **středu**:

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

## **Nastavení průhlednosti textu**

Průhlednost textu se řídí alfa komponentou barvy přiřazené k [PortionFormat.fill_format](https://reference.aspose.com/slides/cs/python-net/aspose.slides/portionformat/fill_format/). V níže uvedených příkladech je `alpha = 50` hodnota kanálu ARGB v rozsahu 0‑255, ne procento průhlednosti.

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

## **Nastavení mezery mezi znaky u textu**

Použijte [BasePortionFormat.spacing](https://reference.aspose.com/slides/cs/python-net/aspose.slides/baseportionformat/spacing/) k roztažení nebo zúžení mezery mezi znaky v textovém poli.

Následující Python kód ukazuje, jak rozšířit mezeru mezi znaky v **celém odstavci**:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Poznámka: Použijte záporné hodnoty ke zmenšení mezery mezi znaky.
    paragraph.paragraph_format.default_portion_format.spacing = 3  # Rozšířit mezeru mezi znaky.

    presentation.save("character_spacing_in_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

Výsledek:

![Mezera mezi znaky v odstavci](character_spacing_in_paragraph.png)

Ukázka kódu níže ukazuje, jak rozšířit mezeru mezi znaky v **částech textu s tučným písmem**:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # Poznámka: Použijte záporné hodnoty ke zmenšení mezery mezi znaky.
            portion.portion_format.spacing = 3  # Rozšířit mezeru mezi znaky.

    presentation.save("character_spacing_in_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

Výsledek:

![Mezera mezi znaky v částech textu](character_spacing_in_text_portions.png)

### **Zakázat kerning pro konkrétní písma**

V některých případech může text vykreslený pomocí Aspose.Slides vypadat mírně těsněji než stejný text zobrazený v PowerPointu. K tomu může dojít, protože PowerPoint může ignorovat data kerningu pro určitá písma, i když písmo obsahuje platné informace o kerningu a kerning je v nastavení PowerPointu povolen.

Aby výstup byl bližší vzhledu v PowerPointu, můžete vypnout kerning pro části textu, které používají dotčené písmo. Nastavte [BasePortionFormat.kerning_minimal_size](https://reference.aspose.com/slides/cs/python-net/aspose.slides/baseportionformat/kerning_minimal_size/) na hodnotu výrazně vyšší než skutečná velikost písma:

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

Toto nastavení zabraňuje aplikaci kerningu na odpovídající části textu a může pomoci sladit vykreslování Aspose.Slides s vizuálním výstupem PowerPointu pro písma, na která se tato specifická chování PowerPointu vztahuje.

## **Správa vlastností písma textu**

Vlastnosti písma lze nastavit na úrovni odstavce pomocí [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/cs/python-net/aspose.slides/paragraphformat/default_portion_format/) nebo na jednotlivých částech pomocí [PortionFormat](https://reference.aspose.com/slides/cs/python-net/aspose.slides/portionformat/).

Následující kód nastavuje písmo a styl textu pro celý odstavec: aplikuje velikost písma, tučné, kurzívu, tečkované podtržení a písmo Times New Roman na všechny části odstavce.

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

## **Nastavení otáčení textu**

Použijte [TextFrameFormat.text_vertical_type](https://reference.aspose.com/slides/cs/python-net/aspose.slides/textframeformat/text_vertical_type/) k nastavení předdefinované orientace textu uvnitř tvaru.

Následující ukázka kódu nastavuje orientaci textu v tvaru na `VERTICAL270`, což otáčí text **o 90 stupňů proti směru hodinových ručiček**:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]

    auto_shape.text_frame.text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL270

    presentation.save("text_rotation.pptx", slides.export.SaveFormat.PPTX)
```

Výsledek:

![Otáčení textu](text_rotation.png)

## **Nastavení vlastního otáčení pro textové rámečky**

Použijte [TextFrameFormat.rotation_angle](https://reference.aspose.com/slides/cs/python-net/aspose.slides/textframeformat/rotation_angle/) k nastavení vlastního úhlu otáčení pro [TextFrame](https://reference.aspose.com/slides/cs/python-net/aspose.slides/textframe/).

Ukázka kódu níže otáčí textový rámec o 3 stupně po směru hodinových ručiček uvnitř tvaru:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]

    auto_shape.text_frame.text_frame_format.rotation_angle = 3

    presentation.save("custom_text_rotation.pptx", slides.export.SaveFormat.PPTX)
```

Výsledek:

![Vlastní otáčení textu](custom_text_rotation.png)

## **Nastavení řádkování odstavců**

Aspose.Slides poskytuje [ParagraphFormat.space_after](https://reference.aspose.com/slides/cs/python-net/aspose.slides/paragraphformat/space_after/), [ParagraphFormat.space_before](https://reference.aspose.com/slides/cs/python-net/aspose.slides/paragraphformat/space_before/) a [ParagraphFormat.space_within](https://reference.aspose.com/slides/cs/python-net/aspose.slides/paragraphformat/space_within/) pro řízení mezer odstavců. Tyto vlastnosti se používají následovně:

* Použijte kladnou hodnotu pro určení řádkování jako procenta výšky řádku.
* Použijte zápornou hodnotu pro určení řádkování v bodech.

Následující ukázka kódu ukazuje, jak určit řádkování v odstavci:

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

## **Nastavení typu automatického přizpůsobení pro textové rámečky**

[TextFrameFormat.autofit_type](https://reference.aspose.com/slides/cs/python-net/aspose.slides/textframeformat/autofit_type/) určuje, jak se text chová, když přesáhne hranice svého kontejneru. Použijte jej k řízení, zda se text zmenšuje, přeteče nebo automaticky mění velikost tvaru.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]

    auto_shape.text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE

    presentation.save("autofit_type.pptx", slides.export.SaveFormat.PPTX)
```

Pro spočítání řádků po automatickém zalomení a zobrazení, jak se mění šířka textu nebo tvaru, viz [Počítání vykreslených řádků](/slides/cs/python-net/manage-paragraph/). Samotný počet řádků neindikuje, zda text přesahuje svůj kontejner.

## **Nastavení ukotvení textových rámečků**

[TextFrameFormat.anchoring_type](https://reference.aspose.com/slides/cs/python-net/aspose.slides/textframeformat/anchoring_type/) definuje, jak je text vertikálně umístěn uvnitř tvaru, například nahoře, uprostřed nebo dole.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]

    auto_shape.text_frame.text_frame_format.anchoring_type = slides.TextAnchorType.BOTTOM

    presentation.save("text_anchor.pptx", slides.export.SaveFormat.PPTX)
```

## **Nastavení tabulátorů textu**

Použijte [ParagraphFormat.default_tab_size](https://reference.aspose.com/slides/cs/python-net/aspose.slides/paragraphformat/default_tab_size/) a [ParagraphFormat.tabs](https://reference.aspose.com/slides/cs/python-net/aspose.slides/paragraphformat/tabs/) k nastavení tabulátorů v odstavci.

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

## **Nastavení jazyka kontroly pravopisu**

Aspose.Slides poskytuje [PortionFormat.language_id](https://reference.aspose.com/slides/cs/python-net/aspose.slides/portionformat/language_id/), který umožňuje nastavit jazyk kontroly pravopisu pro část textu. Jazyk kontroly určuje jazyk používaný pro kontrolu pravopisu a gramatiky v PowerPointu.

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

    # Nastavte ID jazyka pro kontrolu pravopisu.
    text_portion.portion_format.language_id = "zh-CN"

    text_portion.text = "1。"
    paragraph.portions.add(text_portion)

    presentation.save("proofing_language.pptx", slides.export.SaveFormat.PPTX)
```

## **Nastavení výchozího jazyka**

Použijte [LoadOptions.default_text_language](https://reference.aspose.com/slides/cs/python-net/aspose.slides/loadoptions/default_text_language/) k definování výchozího jazyka pro text vytvářený při načítání nebo tvorbě prezentace.

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

## **Nastavení výchozího stylu textu**

Pro aplikaci výchozího formátování textu na úrovni celé prezentace použijte [Presentation.default_text_style](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/default_text_style/).

Následující ukázka kódu ukazuje, jak nastavit výchozí tučné písmo s velikostí 14 pt pro veškerý text napříč snímky v nové prezentaci.

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

## **Extrahování textu s efektem Všech Velkých Písmen**

V PowerPointu aplikace efektu **All Caps** (všechna velká písmena) způsobí, že se text na snímku zobrazí velkými písmeny, i když byl původně zadán malými písmeny. Při získávání takové části textu pomocí Aspose.Slides knihovna vrací text přesně tak, jak byl zadán. Pro shodu se zobrazovaným textem zkontrolujte [TextCapType](https://reference.aspose.com/slides/cs/python-net/aspose.slides/textcaptype/) a pokud je hodnota `ALL`, převedete vrácený řetězec na velká písmena.

Předpokládejme, že na první snímek souboru sample2.pptx máme následující textové pole.

![Efekt Všech Velkých Písmen](all_caps_effect.png)

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

Pro úpravu textu v tabulce na snímku použijte [Table](https://reference.aspose.com/slides/cs/python-net/aspose.slides/table/). Procházejte buňky a aktualizujte každou buňku pomocí [Cell.text_frame](https://reference.aspose.com/slides/cs/python-net/aspose.slides/cell/text_frame/) a formátování odstavců pomocí [Paragraph.paragraph_format](https://reference.aspose.com/slides/cs/python-net/aspose.slides/paragraph/paragraph_format/).

**Jak použít gradientní barvu na text v PowerPoint snímku?**

Pro aplikaci gradientní barvy na text použijte [PortionFormat.fill_format](https://reference.aspose.com/slides/cs/python-net/aspose.slides/portionformat/fill_format/). Nastavte [FillFormat.fill_type](https://reference.aspose.com/slides/cs/python-net/aspose.slides/fillformat/fill_type/) na [FillType.GRADIENT](https://reference.aspose.com/slides/cs/python-net/aspose.slides/filltype/) a nakonfigurujte gradientní zastavení, směr a průhlednost.