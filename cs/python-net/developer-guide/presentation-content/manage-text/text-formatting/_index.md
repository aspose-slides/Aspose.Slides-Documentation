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
  - rotace textu
  - úhel rotace
  - textový rám
  - řádkování
  - vlastnost automatického přizpůsobení
  - ukotvení textového rámu
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

Tento článek ukazuje, jak formátovat text v prezentacích PowerPoint a OpenDocument pomocí Aspose.Slides pro Python via .NET. Pokrývá barvy pozadí, průhlednost, mezery mezi znaky, vlastnosti písma, rotaci, mezery odstavců, chování automatického přizpůsobení, ukotvení textu, tabulátory a nastavení jazyka.

Pokud není uvedeno jinak, příklady používají [sample.pptx](sample.pptx). První tvar na první snímku je textové pole a jeho první odstavec obsahuje text zobrazený níže. Indexy snímků i tvarů jsou nulové. Příklady, které vybírají tučné části, používají efektivní formátování, včetně zděděného tučného formátování:

![Ukázkový text](sample_text.png)

Pro vyhledání a zvýraznění doslovného textu nebo shod regulárního výrazu viz [Vyhledat a nahradit text](/slides/cs/python-net/search-and-replace-text/).

## **Nastavit barvu pozadí textu**

Použijte [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_portion_format/) k nastavení výchozí barvy zvýraznění pro odstavec, nebo použijte [BasePortionFormat.highlight_color](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/highlight_color/) pro jednotlivé textové úseky.

Následující příklad nastaví světle šedé zvýraznění jako výchozí pro první odstavec. Výslovné barvy zvýraznění u jednotlivých úseků mají přednost před tímto výchozím nastavením:

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

Kód níže ukazuje, jak nastavit barvu pozadí pro **textové úseky s tučným písmem**:

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

![Šedé textové úseky](gray_text_portions.png)

## **Zarovnat odstavce textu**

Použijte [ParagraphFormat.alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/) k nastavení zarovnání odstavce v textovém rámci. Hodnota může být centrovaná, zarovnaná vlevo, vpravo, zarovnaná do bloku a tak dále.

Následující ukázka kódu ukazuje, jak zarovnat odstavec na **střed**:

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

Použijte [ParagraphFormat.font_alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/font_alignment/) k vertikálnímu zarovnání textových úseků různých velikostí písma v jednom řádku. Toto nastavení se vztahuje na celý odstavec a řídí zarovnání v každém jeho řádku.

Následující samostatný příklad vytvoří čtyři popsaná textová pole na jednom snímku. Každý odstavec obsahuje stejný text v 18, 36 a 54 bodech, s různým zarovnáním písma. Používá Arial, vypíná automatické přizpůsobení a zalamování a udržuje textové rámy dostatečně velké pro jeden řádek.

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

![Porovnání zarovnání na základní linii, vrchu, středu a spodku s různými velikostmi písma](font_alignment.png)

Zarovnání písma používá fontové metriky, takže viditelné hrany jednotlivých znaků se nemusí přesně shodovat. Příklad zahrnuje velké písmeno a znak s dolním výčnem, aby ukázal rozdíl mezi zarovnáním na základní linii a spodním zarovnáním. Dostupnost fontů a jejich náhrada, použité znaky a rozdíl ve velikostech písma ovlivňují výsledek. Rozměry rámu, okraje, řádkování, zalamování a automatické přizpůsobení také ovlivňují rozložení; při porovnávání režimů použijte stejné fonty a nastavení rozložení.

Toto nastavení se liší od [ParagraphFormat.alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/), který řídí horizontální zarovnání odstavce, a [TextFrameFormat.anchoring_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/anchoring_type/), který vertikálně umisťuje textový blok uvnitř jeho tvaru. Formátování horního a dolního indexu pomocí [BasePortionFormat.escapement](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/escapement/) posouvá jednotlivé úseky relativně k základní linii místo nastavení zarovnání písma pro řádky odstavce.

## **Nastavit průhlednost textu**

Průhlednost textu je řízena pomocí alfa komponenty barvy přiřazené k [BasePortionFormat.fill_format](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/fill_format/). V níže uvedených příkladech `alpha = 50` představuje hodnotu alfa kanálu ARGB v rozsahu 0–255, nikoli procento průhlednosti.

Kód níže ukazuje, jak použít průhlednost na **celý odstavec**:

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

Následující ukázka kódu ukazuje, jak použít průhlednost na **textové úseky s tučným písmem**:

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

## **Nastavit mezery mezi znaky pro text**

Použijte [BasePortionFormat.spacing](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/spacing/) k rozšíření nebo zmenšení mezery mezi znaky v textovém poli. Příklady přidávají 3 body mezery; záporné hodnoty text zmenšují.

Následující Python kód ukazuje, jak rozšířit mezery mezi znaky v **celém odstavci**:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Poznámka: Použijte záporné hodnoty ke zmenšení mezery mezi znaky.
    paragraph.paragraph_format.default_portion_format.spacing = 3  # Rozšířit mezeru mezi znaky.

    presentation.save("character_spacing_in_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

Výsledek:

![Mezery mezi znaky v odstavci](character_spacing_in_paragraph.png)

Kód níže ukazuje, jak rozšířit mezery mezi znaky v **textových úsecích s tučným písmem**:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # Poznámka: Použijte záporné hodnoty ke zmenšení mezery mezi znaky.
            portion.portion_format.spacing = 3  # Rozšířit mezeru mezi znaky.

    presentation.save("character_spacing_in_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

Výsledek:

![Mezery mezi znaky v textových úsecích](character_spacing_in_text_portions.png)

### **Zakázat kerningu pro konkrétní fonty**

V některých případech může text vykreslený Aspose.Slides vypadat o něco těsněji než stejný text v PowerPointu. K tomu může dojít, protože PowerPoint může ignorovat data kerningu pro určité fonty, i když font obsahuje platné informace o kerningu a kerning je v nastavení PowerPointu povolen.

Aby výstup byl bližší PowerPointu, můžete zakázat kerning pro textové úseky, které používají dotčený font. Nastavte [BasePortionFormat.kerning_minimal_size](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/kerning_minimal_size/) na hodnotu vyšší, než je skutečná velikost fontu. Tento příklad vyžaduje "presentation.pptx" s textovým polem jako první tvar na první snímku. Kontroluje efektivní názvy fontů, včetně zděděných, a nastaví práh 100 bodů pro úseky používající Roboto. Tím se zakáže kerning pro úseky s velikostí písma pod 100 bodů:

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

Pro text pod prahem toto nastavení zabrání kerningu a může pomoci sladit vykreslování Aspose.Slides s vizuálním výstupem PowerPointu pro fonty, na které se toto chování PowerPointu vztahuje.

## **Spravovat vlastnosti písma textu**

Vlastnosti písma lze nastavit na úrovni odstavce pomocí [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_portion_format/) nebo na jednotlivých úsecích přes [PortionFormat](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/).

Následující příklad nastaví výchozí písmo prvního odstavce na 12‑bodový Times New Roman s tučným, kurzívou a tečkovaným podtržením. Výslovné formátování na jednotlivých úsecích má přednost před těmito výchozími hodnotami:

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

Následující příklad aplikuje 13‑bodový Times New Roman, kurzívu a tečkované podtržení na úseky, jejichž efektivní formátování je tučné:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # Nastavte vlastnosti písma pro textový úsek.
            portion.portion_format.font_height = 13
            portion.portion_format.font_italic = slides.NullableBool.TRUE
            portion.portion_format.font_underline = slides.TextUnderlineType.DOTTED
            portion.portion_format.latin_font = slides.FontData("Times New Roman")

    presentation.save("font_properties_for_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

Výsledek:

![Vlastnosti písma pro textové úseky](font_properties_for_text_portions.png)

## **Nastavit rotaci textu**

Použijte [TextFrameFormat.text_vertical_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/text_vertical_type/) k nastavení předdefinované orientace textu uvnitř tvaru.

Následující ukázka kódu nastavuje orientaci textu v tvaru na [TextVerticalType.VERTICAL270](https://reference.aspose.com/slides/python-net/aspose.slides/textverticaltype/), což otáčí text **o 90 stupňů proti směru hodinových ručiček**:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL270

    presentation.save("text_rotation.pptx", slides.export.SaveFormat.PPTX)
```

Výsledek:

![Rotace textu](text_rotation.png)

## **Nastavit vlastní rotaci pro textové rámy**

Použijte [TextFrameFormat.rotation_angle](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/rotation_angle/) k nastavení vlastní úhlu rotace pro [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/).

Kód níže otáčí textový rám o 3 stupně po směru hodinových ručiček uvnitř tvaru:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.rotation_angle = 3

    presentation.save("custom_text_rotation.pptx", slides.export.SaveFormat.PPTX)
```

Výsledek:

![Vlastní rotace textu](custom_text_rotation.png)

## **Nastavit řádkování odstavců**

Aspose.Slides poskytuje [ParagraphFormat.space_after](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_after/), [ParagraphFormat.space_before](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_before/), a [ParagraphFormat.space_within](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_within/) pro řízení mezery odstavců. Tyto vlastnosti se používají následovně:

* Použijte kladnou hodnotu k určení řádkování jako procenta výšky řádku.
* Použijte zápornou hodnotu k určení řádkování v bodech.

Následující příklad nastavuje mezeru uvnitř prvního odstavce na 200 % výšky řádku (dvojité řádkování):

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

## **Řídit zalamování řádků**

Pravidla pro zalamování řádků v odstavci jsou užitečná v úzkých textových blocích a prezentacích, které kombinují latinské a východoasijské texty. Následující vlastnosti patří do [ParagraphFormat](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/), takže se vztahují na celý odstavec:

- [latin_line_break](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/latin_line_break/) řídí pravidla zalamování latinských řádků. Ve smíšeném textu může změna také ovlivnit, kde se zalamuje sousední východoasijský text a interpunkce.
- [east_asian_line_break](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/east_asian_line_break/) řídí pravidla zalamování východoasijských řádků, včetně omezení znaků na začátku a konci řádku.

Tato pravidla nenahrazují [TextFrameFormat.wrap_text](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/wrap_text/), který umožňuje automatické zalamování v textovém rámci. Ovlivňují rozvržení, když k zalamování dochází; nezasazují znaky konce řádku. Výslovné zalomení řádku vynutí nový řádek v odstavci nezávisle na dostupné šířce.

Následující samostatný příklad vytvoří úzký textový blok obsahující čínštinu a latinu. Nastaví oba parametry zalamování explicitně a uloží "line_breaking.pptx". Pro experimentování s libovolným pravidlem změňte hodnotu dané vlastnosti při zachování ostatních nastavení. Příklad používá 24‑bodový Arial a SimSun s šířkou rámu 160 bodů a nulovými horizontálními okraji textového rámu. [TextFrameFormat.autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/autofit_type/) je nastaven na [TextAutofitType.NONE](https://reference.aspose.com/slides/python-net/aspose.slides/textautofittype/)…, aby velikost textu a rozměry rámu zůstaly pevné.

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

## **Řídit visící interpunkci**

[ParagraphFormat.hanging_punctuation](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/hanging_punctuation/) umožňuje oprávněné interpunkci vystoupit za pravý okraj řádku místo aby zabírala další řádek. Platí pro celý odstavec a liší se od visícího odsazení.

Následující samostatný příklad povoluje visící interpunkci v 100‑bodovém širokém textovém rámci a uloží "hanging_punctuation.pptx". S 24‑bodovým Arial a nulovými horizontálními okraji textového rámu, konečná tečka zůstane za slovem "sentence" a vystoupí za pravý okraj textu. Nastavte vlastnost na [NullableBool.FALSE](https://reference.aspose.com/slides/python-net/aspose.slides/nullablebool/)…, aby se tečka zobrazila na samostatném řádku. Zalamování je povoleno a automatické přizpůsobení zakázáno, aby šířka zůstala pevná.

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

Ne každá interpunkční značka může viset. Viditelný výsledek závisí na [font a podmínkách rozložení](#control-line-breaking): změna fontu, dostupné šířky, okrajů nebo nastavení automatického přizpůsobení může odstranit viditelný rozdíl.

## **Nastavit typ automatického přizpůsobení pro textové rámy**

[TextFrameFormat.autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/autofit_type/) určuje, jak se text chová, když překročí hranice svého kontejneru. Použijte k řízení, zda se text zmenšuje, přetéká nebo automaticky mění velikost tvaru. Následující příklad konfiguruje tvar tak, aby se změnil velikostí podle textu a uloží výsledek do "autofit_type.pptx".

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE

    presentation.save("autofit_type.pptx", slides.export.SaveFormat.PPTX)
```

Chcete‑li po automatickém zalomení spočítat řádky a vidět, jak se mění šířka textu nebo tvaru, podívejte se na [Count Rendered Lines](/slides/cs/python-net/manage-paragraph/). Pouze počet řádků neindikujte, zda text přesahuje kontejner.

## **Nastavit ukotvení textových rámů**

[TextFrameFormat.anchoring_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/anchoring_type/) definuje, jak je text vertikálně umístěn uvnitř tvaru, například nahoře, uprostřed nebo dole. Následující příklad ukotví text ke dnu prvního tvaru a uloží výsledek do "text_anchor.pptx".

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.anchoring_type = slides.TextAnchorType.BOTTOM

    presentation.save("text_anchor.pptx", slides.export.SaveFormat.PPTX)
```

## **Nastavit tabulaci textu**

Použijte [ParagraphFormat.default_tab_size](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_tab_size/) a [ParagraphFormat.tabs](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/tabs/) k nastavení tabulátorů v odstavci. Následující příklad nastaví výchozí interval tabulátoru na 100 bodů a přidá levý zarovnaný tabulátor na 30 bodů. Tato nastavení ovlivňují text obsahující tabulátory.

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

![Tabulátory v odstavci](paragraph_tabs.png)

## **Nastavit jazyk kontroly pravopisu**

Aspose.Slides poskytuje [BasePortionFormat.language_id](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/language_id/), který umožňuje nastavit jazyk kontroly pravopisu pro textový úsek. Jazyk kontroly určuje, jaký jazyk se použije pro kontrolu pravopisu a gramatiky v PowerPointu.

Následující příklad vyžaduje "presentation.pptx" s textovým polem jako první tvar na první snímku a alespoň jeden odstavec. Nahrazuje obsah prvního odstavce řetězcem "1。", nastaví SimSun jako jeho písmo a přiřadí jazyk kontroly Simplified Chinese (`zh-CN`). Uloží výsledek do "proofing_language.pptx":

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

## **Nastavit výchozí jazyk**

Použijte [LoadOptions.default_text_language](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/default_text_language/) k definování výchozího jazyka pro text vytvořený během načítání nebo vytváření prezentace. Následující příklad vytvoří prezentaci s americkou angličtinou jako výchozím jazykem textu, přidá textové pole a vytiskne `en-US` pro první textový úsek.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.default_text_language = "en-US"

with slides.Presentation(load_options) as presentation:
    slide = presentation.slides[0]

    # Přidejte nový obdélníkový tvar s textem.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 50)
    shape.text_frame.text = "Sample text"

    # Zkontrolujte jazyk prvního úseku.
    portion = shape.text_frame.paragraphs[0].portions[0]
    print(portion.portion_format.language_id)
```

## **Nastavit výchozí styl textu**

Pro aplikaci výchozího formátování textu na úrovni prezentace použijte [Presentation.default_text_style](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/default_text_style/).

Následující příklad nastaví 14‑bodové tučné písmo jako výchozí pro odstavce nejvyšší úrovně v nové prezentaci a uloží ji do "default_text_style.pptx". Text může tyto výchozí hodnoty dědit, pokud nejsou přepsány konkrétnějším formátováním.

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

## **Extrahovat text s efektem Všech Velkých Písmen**

V PowerPointu aplikace efektu **All Caps** způsobí, že text se na snímku zobrazuje velkými písmeny, i když byl původně napsán malými. Když takový textový úsek načítáte pomocí Aspose.Slides, knihovna vrátí text přesně tak, jak byl zadán. Pro zobrazení odpovídajícího textu zkontrolujte [TextCapType](https://reference.aspose.com/slides/python-net/aspose.slides/textcaptype/) a pokud je hodnota `ALL`, převedete získaný řetězec na velká písmena.

Tento příklad vyžaduje "sample2.pptx" s textovým polem jako první tvar na první snímku. V jeho prvním odstavci první úsek obsahuje "Hello, Aspose!" s aplikovaným efektem All Caps, jak je znázorněno níže.

![Efekt Všech Velkých Písmen](all_caps_effect.png)

Kód níže ukazuje, jak extrahovat text s aplikovaným efektem **All Caps**:

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

Chcete‑li upravit text v tabulce na snímku, použijte [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/). Procházejte buňky a aktualizujte každou buňku pomocí [Cell.text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/cell/text_frame/) a formátování odstavců pomocí [Paragraph.paragraph_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/paragraph_format/).

**Jak aplikovat gradientovou barvu na text na snímku PowerPointu?**

Pro aplikaci gradientové barvy na text použijte [BasePortionFormat.fill_format](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/fill_format/). Nastavte [FillFormat.fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/) na [FillType.GRADIENT](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) a nakonfigurujte gradientové zastavení, směr a průhlednost.