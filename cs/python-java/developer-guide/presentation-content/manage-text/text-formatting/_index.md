---
title: Formátování textu prezentace v Pythonu přes Java
linktitle: Formátování textu
type: docs
weight: 50
url: /cs/python-java/text-formatting/
keywords:
- zarovnání odstavce
- styl textu
- pozadí textu
- průhlednost textu
- rozestup znaků
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
- Java
- Aspose.Slides
description: "Formátujte a stylizujte text v prezentacích PowerPoint a OpenDocument pomocí Aspose.Slides pro Python přes Java. Přizpůsobte písma, barvy, zarovnání a další."
---
## **Přehled**

Tento článek ukazuje, jak formátovat text v prezentacích PowerPoint a OpenDocument pomocí Aspose.Slides pro Python přes Java. Popisuje barvy pozadí, průhlednost, rozestupy znaků, vlastnosti písma, otočení, rozestupy odstavců, chování automatického přizpůsobení, ukotvení textu, tabulátory a nastavení jazyka.

Pokud není uvedeno jinak, příklady používají [sample.pptx](sample.pptx). První tvar na první snímku je textové pole a jeho první odstavec obsahuje text zobrazený níže. Jak indexy snímků, tak tvarů jsou číslovány od nuly. Příklady, které vybírají tučné části, používají efektivní formátování, včetně zděděného tučného formátování:

![Ukázkový text](sample_text.png)

Pro vyhledání a zvýraznění doslovného textu nebo shod regulárního výrazu viz [Vyhledávání a nahrazování textu](/slides/cs/python-java/search-and-replace-text/).

## **Nastavit barvu pozadí textu**

Použijte [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) k nastavení výchozí barvy zvýraznění pro odstavec, nebo použijte [BasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#getHighlightColor) pro jednotlivé textové části.

Následující příklad nastaví světle šedé zvýraznění jako výchozí pro první odstavec. Explicitní barvy zvýraznění na jednotlivých částech mají přednost před tímto výchozím nastavením:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat
from java.awt import Color

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    # Nastavit barvu zvýraznění pro celý odstavec.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getHighlightColor().setColor(Color.LIGHT_GRAY)

    presentation.save("gray_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Výsledek:

![Šedý odstavec](gray_paragraph.png)

Níže uvedený příklad kódu ukazuje, jak nastavit barvu pozadí pro **textové části s tučným písmem**:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat
from java.awt import Color

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    for portion in paragraph.getPortions():
        if portion.getPortionFormat().getEffective().getFontBold():
            # Nastavit barvu zvýraznění pro textovou část.
            portion.getPortionFormat().getHighlightColor().setColor(Color.LIGHT_GRAY)

    presentation.save("gray_text_portions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Výsledek:

![Šedé textové části](gray_text_portions.png)

## **Zarovnat odstavce textu**

Použijte [ParagraphFormat.setAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setAlignment) k nastavení zarovnání odstavce v textovém rámečku. Hodnota může být centrovaná, zarovnaná vlevo, vpravo, do bloku a tak dále.

Následující ukázka kódu zobrazuje, jak zarovnat odstavec na **střed**:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TextAlignment

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    # Nastavit zarovnání odstavce na střed.
    paragraph.getParagraphFormat().setAlignment(TextAlignment.Center)

    presentation.save("aligned_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Výsledek:

![Zarovnaný odstavec](aligned_paragraph.png)

## **Zarovnat písma v řádku**

Použijte [ParagraphFormat.setFontAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setFontAlignment) k vertikálnímu zarovnání textových částí s různými velikostmi písma v řádku. Toto nastavení platí pro celý odstavec a řídí zarovnání v každém jeho řádku.

Následující samostatný příklad vytváří čtyři označená textová pole na jednom snímku. Každý odstavec obsahuje stejný text ve velikostech 18, 36 a 54 bodů s různým zarovnáním písma. Používá Arial, vypíná automatické přizpůsobení a zalomení a udržuje rámečky dostatečně velké pro jediný řádek.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontAlignment, FontData, NullableBool, Paragraph, Portion, Presentation, SaveFormat, ShapeType, TextAlignment, TextAnchorType, TextAutofitType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    alignments = [FontAlignment.Baseline, FontAlignment.Top, FontAlignment.Center, FontAlignment.Bottom]
    alignment_names = ["Baseline", "Top", "Center", "Bottom"]
    font_sizes = [18.0, 36.0, 54.0]
    font = FontData("Arial")

    for i, alignment in enumerate(alignments):
        shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 20 + i * 130, 660, 120)
        shape.getFillFormat().setFillType(FillType.NoFill)
        shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill)

        text_frame = shape.getTextFrame()
        text_frame.getTextFrameFormat().setAnchoringType(TextAnchorType.Top)
        text_frame.getTextFrameFormat().setAutofitType(TextAutofitType.None_)
        text_frame.getTextFrameFormat().setWrapText(NullableBool.False_)

        label = text_frame.getParagraphs().get_Item(0)
        label.setText(alignment_names[i])
        label.getParagraphFormat().setAlignment(TextAlignment.Left)
        label.getParagraphFormat().getDefaultPortionFormat().setFontHeight(14)
        label.getParagraphFormat().getDefaultPortionFormat().setLatinFont(font)
        label.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
        label.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY)

        paragraph = Paragraph()
        paragraph.getParagraphFormat().setFontAlignment(alignment)
        paragraph.getParagraphFormat().setAlignment(TextAlignment.Left)
        paragraph.getParagraphFormat().getDefaultPortionFormat().setLatinFont(font)
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)

        for font_size in font_sizes:
            portion = Portion("Ag ")
            portion.getPortionFormat().setFontHeight(font_size)
            paragraph.getPortions().add(portion)

        text_frame.getParagraphs().add(paragraph)

    presentation.save("font_alignment.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Výsledek:

![Porovnání zarovnání Baseline, Top, Center a Bottom s promíchanými velikostmi písma](font_alignment.png)

Zarovnání písma používá metriky písma, takže viditelné hrany jednotlivých znaků se nemusí přesně shodovat. Příklad obsahuje velké písmeno i spodní část, aby pomohl ukázat rozdíl mezi zarovnáním na základní linii a dole. Dostupnost písma a jeho náhrada, použité znaky a rozdíly ve velikostech písma ovlivňují výsledek. Rozměry rámce, okraje, řádkování, zalamování a automatické přizpůsobení také ovlivňují rozvržení; použijte stejná písma a nastavení rozvržení při porovnávání režimů.

Toto nastavení se liší od [ParagraphFormat.setAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setAlignment), které řídí horizontální zarovnání odstavce, a od [TextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setAnchoringType), které vertikálně umisťuje textový blok uvnitř tvaru. Formátování horního a dolního indexu pomocí [BasePortionFormat.setEscapement](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setEscapement) posouvá jednotlivé části vzhledem k základní linii místo nastavení zarovnání písma pro řádky odstavce.

## **Nastavit průhlednost textu**

Průhlednost textu je řízena pomocí alfa komponenty barvy přiřazené k [BasePortionFormat.getFillFormat](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#getFillFormat). V níže uvedených příkladech je `alpha = 50` hodnota alfa kanálu ARGB na stupnici 0–255, nikoli procento průhlednosti.

Níže uvedený příklad kódu ukazuje, jak aplikovat průhlednost na **celý odstavec**:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat
from java.awt import Color

alpha = 50
text_color = Color(0, 0, 0, alpha)

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    # Nastavit barvu výplně textu na průhlednou barvu.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(text_color)

    presentation.save("transparent_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Výsledek:

![Průhledný odstavec](transparent_paragraph.png)

Následující příklad kódu ukazuje, jak aplikovat průhlednost na **textové části s tučným písmem**:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat
from java.awt import Color

alpha = 50
text_color = Color(0, 0, 0, alpha)

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    for portion in paragraph.getPortions():
        if portion.getPortionFormat().getEffective().getFontBold():
            # Nastavit průhlednost textové části.
            portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
            portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(text_color)

    presentation.save("transparent_text_portions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Výsledek:

![Průhledné textové části](transparent_text_portions.png)

## **Nastavit rozestup znaků v textu**

Použijte [BasePortionFormat.setSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setSpacing) k rozšíření nebo zmenšení rozestupu mezi znaky v textovém poli. Příklady přidávají 3 body rozestupu; záporné hodnoty text zmenšují.

Níže uvedený Python kód ukazuje, jak rozšířit rozestup znaků v **celém odstavci**:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    # Poznámka: Použijte záporné hodnoty ke zkomprimování rozestupu znaků.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3) # Rozšířit rozestup znaků.

    presentation.save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Výsledek:

![Rozestup znaků v odstavci](character_spacing_in_paragraph.png)

Níže uvedený příklad kódu ukazuje, jak rozšířit rozestup znaků v **textových částech s tučným písmem**:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    for portion in paragraph.getPortions():
        if portion.getPortionFormat().getEffective().getFontBold():
            # Poznámka: Použijte záporné hodnoty ke zkomprimování rozestupu znaků.
            portion.getPortionFormat().setSpacing(3) # Rozšířit rozestup znaků.

    presentation.save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Výsledek:

![Rozestup znaků v textových částech](character_spacing_in_text_portions.png)

### **Zakázat kerning pro konkrétní písma**

V některých případech může text vykreslený pomocí Aspose.Slides vypadat mírně těsněji než stejný text zobrazený v PowerPointu. K tomu může dojít, protože PowerPoint může ignorovat data kerningu pro určitá písma, i když písmo obsahuje platné kerningové informace a kerning je v nastavení PowerPointu povolen.

Aby výstup odpovídal PowerPointu, můžete pro textové části používající dotčené písmo zakázat kerning. Nastavte [BasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setKerningMinimalSize) na hodnotu větší než skutečná velikost písma. Tento příklad vyžaduje „presentation.pptx“ s textovým polem jako prvním tvarem na první snímek. Kontroluje efektivní názvy písem, včetně zděděných, a nastavuje práh 100 bodů pro části používající Roboto. Tím se pro odpovídající části s velikostí písma pod 100 bodů zakáže kerning:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    target_font = "Roboto"

    for paragraph in auto_shape.getTextFrame().getParagraphs():
        for portion in paragraph.getPortions():
            portion_format = portion.getPortionFormat().getEffective()
            fonts = (portion_format.getLatinFont(), portion_format.getEastAsianFont(), portion_format.getComplexScriptFont())
            if any(font is not None and font.getFontName() == target_font for font in fonts):
                portion.getPortionFormat().setKerningMinimalSize(100)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Pro text pod prahem toto nastavení zabraňuje kerningu a může pomoci sladit vykreslování Aspose.Slides s vizuálním výstupem PowerPointu pro písma, na která se toto chování vztahuje.

## **Spravovat vlastnosti písma textu**

Vlastnosti písma lze nastavit na úrovni odstavce pomocí [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) nebo na jednotlivých částech pomocí [PortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/portionformat/).

Následující příklad nastaví výchozí písmo prvního odstavce na Times New Roman 12 bodů s tučným, kurzívou a tečkovaným podtržením. Explicitní formátování na jednotlivých částech má přednost před těmito výchozími nastaveními.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, NullableBool, Presentation, SaveFormat, TextUnderlineType

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    # Nastavit vlastnosti písma pro odstavec.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(12)
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontBold(NullableBool.True_)
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontItalic(NullableBool.True_)
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontUnderline(TextUnderlineType.Dotted)
    font = FontData("Times New Roman")
    paragraph.getParagraphFormat().getDefaultPortionFormat().setLatinFont(font)

    presentation.save("font_properties_for_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Výsledek:

![Vlastnosti písma pro odstavec](font_properties_for_paragraph.png)

Následující příklad použije Times New Roman 13 bodů, kurzívu a tečkované podtržení pro části, jejichž efektivní formátování je tučné:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, NullableBool, Presentation, SaveFormat, TextUnderlineType

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    for portion in paragraph.getPortions():
        if portion.getPortionFormat().getEffective().getFontBold():
            # Nastavit vlastnosti písma pro textovou část.
            portion.getPortionFormat().setFontHeight(13)
            portion.getPortionFormat().setFontItalic(NullableBool.True_)
            portion.getPortionFormat().setFontUnderline(TextUnderlineType.Dotted)
            font = FontData("Times New Roman")
            portion.getPortionFormat().setLatinFont(font)

    presentation.save("font_properties_for_text_portions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Výsledek:

![Vlastnosti písma pro textové části](font_properties_for_text_portions.png)

## **Ovládání normalizace výšky textu**

Použijte [BasePortionFormat.setNormaliseHeight](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setNormaliseHeight) při reprodukci typografie šablony nebo zkoumání rozdílů ve výšce znaků. V PowerPointu zapíná normalizace roztažení nebo stažení jednotlivých znaků svisle tak, aby měly jednotnou viditelnou výšku v rámci textové části. Nezaručuje stejnou výšku textu napříč různými písmy.

Nastavte vlastnost na [NullableBool.True_ nebo False_](https://reference.aspose.com/slides/python-java/aspose.slides/nullablebool/) pro explicitní zapnutí nebo vypnutí normalizace. `NullableBool.NotDefined` ponechává místní nastavení nepřiřazené, takže část zdědí hodnotu, například z [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) odstavce. Neznamená to `False`. Použijte [PortionFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/portionformat/#getEffective) a přečtěte `getNormaliseHeight` na vráceném efektivním formátování pro získání rozlišené logické hodnoty.

Níže uvedený samostatný příklad vyžaduje instalovaný **Arial**. Vytvoří dva textové bloky obsahující stejná velká písmena, malá písmena, spády a diakritiku při 54 bodech. Oba odstavce mají výchozí zapnutou normalizaci. Horní část ji explicitně vypíná; dolní část ji dědí. Rozměry rámců, okraje a řádkování jsou identické, s vypnutým zalamováním a automatickým přizpůsobením pro zachování konzistence porovnání. Příklad vypíše `False: False` a `NotDefined: True`, poté uloží „text_height_normalization.pptx“.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontData, NullableBool, Presentation, SaveFormat, ShapeType, TextAlignment, TextAnchorType, TextAutofitType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    settings = [NullableBool.False_, NullableBool.NotDefined]
    setting_names = ["False", "NotDefined"]

    for i, setting in enumerate(settings):
        shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 60 + i * 200, 660, 150)
        shape.getFillFormat().setFillType(FillType.NoFill)
        shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill)

        text_frame = shape.getTextFrame()
        text_frame.setText("Hxgjpq ÅÉ 0123")
        text_frame.getTextFrameFormat().setAutofitType(TextAutofitType.None_)
        text_frame.getTextFrameFormat().setWrapText(NullableBool.False_)
        text_frame.getTextFrameFormat().setAnchoringType(TextAnchorType.Top)
        text_frame.getTextFrameFormat().setMarginTop(0)
        text_frame.getTextFrameFormat().setMarginLeft(0)

        paragraph = text_frame.getParagraphs().get_Item(0)
        paragraph.getParagraphFormat().setAlignment(TextAlignment.Left)
        paragraph.getParagraphFormat().setSpaceBefore(0)
        paragraph.getParagraphFormat().setSpaceAfter(0)
        paragraph.getParagraphFormat().setSpaceWithin(100)
        paragraph.getParagraphFormat().getDefaultPortionFormat().setNormaliseHeight(NullableBool.True_)

        portion = paragraph.getPortions().get_Item(0)
        font = FontData("Arial")
        portion.getPortionFormat().setLatinFont(font)
        portion.getPortionFormat().setFontHeight(54)
        portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
        portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
        portion.getPortionFormat().setNormaliseHeight(setting)

        print(f"{setting_names[i]}: {bool(portion.getPortionFormat().getEffective().getNormaliseHeight())}")

    presentation.save("text_height_normalization.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Porovnání níže bylo exportováno ze uložené prezentace. Horní řada má vypnutou normalizaci (`False`); dolní řada dědí zapnuté nastavení (`NotDefined` → `True`). Ujistěte se, že máte nainstalovaný Arial pro reprodukci tohoto vzhledu.

![Arial text 54 bodů s vypnutou normalizací nahoře a zděděnou zapnutou normalizací dole](text_height_normalization.png)

Normalizace mění výšku znaků bez změny přiřazené hodnoty [BasePortionFormat.getFontHeight](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#getFontHeight), která určuje velikost písma v bodech. Odstavec [ParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setSpaceWithin) řídí řádkování, zatímco [TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setAutofitType) v textovém rámečku řídí, jak se text nebo jeho kontejner přizpůsobuje. Tato nastavení slouží k různým účelům a mohou nezávisle ovlivnit celkové rozvržení. Další informace o formátování odstavců a dědičnosti naleznete v [Manage Paragraph](/slides/cs/python-java/manage-paragraph/).

## **Použít a odstranit přeškrtnutí**

Použijte [BasePortionFormat.setStrikethroughType](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setStrikethroughType) na textovou část pro zobrazení oprav, zrušených termínů nebo původních cen bez smazání původního textu. Nastavte na [TextStrikethroughType.Single nebo Double](https://reference.aspose.com/slides/python-java/aspose.slides/textstrikethroughtype/) pro jednu nebo dvě čáry přes text.

Pro odstranění přeškrtnutí použijte [TextStrikethroughType.None_](https://reference.aspose.com/slides/python-java/aspose.slides/textstrikethroughtype/#None). Tím se efekt explicitně zakáže, i když okolní formátování specifikuje přeškrtnutí. Naopak [TextStrikethroughType.NotDefined](https://reference.aspose.com/slides/python-java/aspose.slides/textstrikethroughtype/#NotDefined) ponechá místní nastavení nedefinované, takže část může zdědit formátování, například z odstavce. Nezaručuje to, že přeškrtnutí bude odstraněno. Použijte [PortionFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/portionformat/#getEffective) k přečtení výsledného formátování, včetně zděděných hodnot.

Níže uvedený samostatný příklad vytváří tři srovnání cen. Každý odstavec má samostatné části pro popisek, původní cenu a aktuální cenu, takže pouze původní cena je ovlivněna. První řádek použije a pak odstraní přeškrtnutí; ostatní řádky zachovají jednoduché a dvojité přeškrtnutí. Změna tohoto nastavení zachová text i ostatní formátování, včetně tučné původní ceny.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontData, NullableBool, Paragraph, Portion, Presentation, SaveFormat, ShapeType, TextAlignment, TextStrikethroughType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 620, 220)
    shape.getFillFormat().setFillType(FillType.NoFill)
    shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
    shape.getTextFrame().getParagraphs().clear()

    labels = ["None: ", "Single: ", "Double: "]

    for label in labels:
        paragraph = Paragraph()
        paragraph.getParagraphFormat().setAlignment(TextAlignment.Left)
        paragraph.getParagraphFormat().setSpaceAfter(20)

        portion_format = paragraph.getParagraphFormat().getDefaultPortionFormat()
        portion_format.setFontHeight(28)
        font = FontData("Arial")
        portion_format.setLatinFont(font)
        portion_format.getFillFormat().setFillType(FillType.Solid)
        portion_format.getFillFormat().getSolidFillColor().setColor(Color.BLACK)

        label_portion = Portion(label)
        paragraph.getPortions().add(label_portion)

        previous_price = Portion("$100")
        previous_price.getPortionFormat().setFontBold(NullableBool.True_)
        paragraph.getPortions().add(previous_price)
        current_price = Portion(" → $80")
        paragraph.getPortions().add(current_price)

        shape.getTextFrame().getParagraphs().add(paragraph)

    paragraphs = shape.getTextFrame().getParagraphs()

    # Použít přeškrtnutí a poté jej explicitně odstranit z první předchozí ceny.
    paragraphs.get_Item(0).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.Single)
    paragraphs.get_Item(0).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.None_)

    paragraphs.get_Item(1).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.Single)
    paragraphs.get_Item(2).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.Double)

    presentation.save("strikethrough.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Výsledek, shora dolů: bez přeškrtnutí, jednoduché přeškrtnutí a dvojité přeškrtnutí.

![Původní ceny bez přeškrtnutí, s jednoduchým a s dvojitým přeškrtnutím](strikethrough.png)

## **Nastavit rotaci textu**

Použijte [TextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setTextVerticalType) k nastavení předdefinované orientace textu uvnitř tvaru.

Níže uvedený příklad kódu nastaví orientaci textu ve tvaru na [TextVerticalType.Vertical270](https://reference.aspose.com/slides/python-java/aspose.slides/textverticaltype/), což otáčí text **o 90 stupňů proti směru hodinových ručiček**:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TextVerticalType

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    auto_shape.getTextFrame().getTextFrameFormat().setTextVerticalType(TextVerticalType.Vertical270)

    presentation.save("text_rotation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Výsledek:

![Rotace textu](text_rotation.png)

## **Zobrazit číslice vedle sebe ve svislém textu**

Aby byly číslice dvouciferného čísla vedle sebe ve svislém japonském popisku, umístěte obě číslice do jedné textové části a zavolejte [BasePortionFormat.setKumimoji](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setKumimoji) na tuto část. Oba popisky v tomto příkladu používají [TextVerticalType.EastAsianVertical](https://reference.aspose.com/slides/python-java/aspose.slides/textverticaltype/#EastAsianVertical) a 40‑bodový MS Gothic. Pouze nastavení [NullableBool](https://reference.aspose.com/slides/python-java/aspose.slides/nullablebool/) pro číslice se liší.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontData, NullableBool, Portion, Presentation, SaveFormat, ShapeType, TextVerticalType

Color = jpype.JClass("java.awt.Color")
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    font = FontData("MS Gothic")

    for x, kumimoji in [(120, NullableBool.True_), (360, NullableBool.False_)]:
        label = slide.getShapes().addAutoShape(ShapeType.Rectangle, x, 48, 120, 420)
        label.getFillFormat().setFillType(FillType.NoFill)
        label.getLineFormat().getFillFormat().setFillType(FillType.NoFill)

        frame = label.addTextFrame("")
        frame.getTextFrameFormat().setTextVerticalType(TextVerticalType.EastAsianVertical)

        paragraph = frame.getParagraphs().get_Item(0)
        default_format = paragraph.getParagraphFormat().getDefaultPortionFormat()
        default_format.setLatinFont(font)
        default_format.setEastAsianFont(font)
        default_format.setFontHeight(40)
        default_format.getFillFormat().setFillType(FillType.Solid)
        default_format.getFillFormat().getSolidFillColor().setColor(Color.BLACK)

        digits = Portion("12")
        digits.getPortionFormat().setKumimoji(kumimoji)
        
        portions = paragraph.getPortions()
        portions.clear()
        portions.add(Portion("令和"))
        portions.add(digits)
        portions.add(Portion("年"))

    presentation.save("vertical_date.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

V PowerPointu levý popisek (`True`) zobrazuje číslice svisle a vedle sebe mezi 和 a 年. Pravý popisek (`False`) otáčí dvojici o 90 stupňů po směru hodinových ručiček. Okolní japonské znaky zůstávají svislé v obou popiscích.

![Porovnání svislých datových popisků v PowerPointu s číslicemi svisle vlevo a otočenými vpravo.](vertical_date.png)

## **Nastavit vlastní rotaci pro textové rámy**

Použijte [TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setRotationAngle) k nastavení vlastní úhlu rotace pro [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/).

Níže uvedený příklad kódu otáčí textový rám o 3 stupně po směru hodinových ručiček uvnitř tvaru:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    auto_shape.getTextFrame().getTextFrameFormat().setRotationAngle(3)

    presentation.save("custom_text_rotation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Výsledek:

![Vlastní rotace textu](custom_text_rotation.png)

## **Nastavit řádkování odstavců**

Aspose.Slides poskytuje [ParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setSpaceAfter), [ParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setSpaceBefore) a [ParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setSpaceWithin) pro řízení rozestupů odstavců. Tyto vlastnosti se používají následovně:

* Použijte kladnou hodnotu k specifikaci řádkování jako procenta výšky řádku.
* Použijte zápornou hodnotu k specifikaci řádkování v bodech.

Následující příklad nastaví rozestup uvnitř prvního odstavce na 200 % výšky řádku (dvojnásobné řádkování):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)

    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)
    paragraph.getParagraphFormat().setSpaceWithin(200)

    presentation.save("line_spacing.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Výsledek:

![Řádkování uvnitř odstavce](line_spacing.png)

## **Ovládání zalamování řádků**

Pravidla pro zalamování řádků odstavce jsou užitečná v úzkých textových blocích a prezentacích, které kombinují latinský a východoasijský text. Následující metody patří do [ParagraphFormat](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/), takže se vztahují na celý odstavec:

- [ParagraphFormat.setLatinLineBreak](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setLatinLineBreak) řídí pravidla zalamování latinského textu. V smíšeném textu může jeho změna také změnit, kde se zalamuje sousední východoasijský text a interpunkce.
- [ParagraphFormat.setEastAsianLineBreak](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setEastAsianLineBreak) řídí pravidla zalamování východoasijského textu, včetně omezení znaků na začátku a konci řádku.

Tato pravidla nenahrazují [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setWrapText), která povoluje automatické zalamování uvnitř textového rámečku. Ovlivňují rozvržení, když dochází k zalamování; nevkládají znaky konce řádku. Explicitní konec řádku vynutí nový řádek v odstavci nezávisle na dostupné šířce.

Níže uvedený samostatný příklad vytváří úzký textový blok obsahující čínský a latinský text. Nastavuje oba parametry zalamování explicitně a ukládá „line_breaking.pptx“. Pro experimentování s některým pravidlem změňte odpovídající hodnotu při zachování ostatních nastavení. Příklad používá 24‑bodový Arial a SimSun s šířkou rámce 160 bodů a nulovými vodorovnými okraji textového rámečku. [TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setAutofitType) je voláno s [TextAutofitType.None_](https://reference.aspose.com/slides/python-java/aspose.slides/textautofittype/) tak, aby velikost textu a rozměry rámce zůstaly pevné.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontData, NullableBool, Presentation, SaveFormat, ShapeType, TextAlignment, TextAutofitType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 160, 300)
    shape.getFillFormat().setFillType(FillType.NoFill)

    text_frame = shape.getTextFrame()
    text_frame.getTextFrameFormat().setWrapText(NullableBool.True_)
    text_frame.getTextFrameFormat().setAutofitType(TextAutofitType.None_)
    text_frame.getTextFrameFormat().setMarginLeft(0)
    text_frame.getTextFrameFormat().setMarginRight(0)

    paragraph = text_frame.getParagraphs().get_Item(0)
    paragraph.setText("中文排版测试，PowerPoint 中文演示。")

    paragraph_format = paragraph.getParagraphFormat()
    paragraph_format.setAlignment(TextAlignment.Left)
    paragraph_format.getDefaultPortionFormat().setFontHeight(24)
    latin_font = FontData("Arial")
    paragraph_format.getDefaultPortionFormat().setLatinFont(latin_font)
    east_asian_font = FontData("SimSun")
    paragraph_format.getDefaultPortionFormat().setEastAsianFont(east_asian_font)
    paragraph_format.getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    paragraph_format.getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    paragraph_format.setLatinLineBreak(NullableBool.False_)
    paragraph_format.setEastAsianLineBreak(NullableBool.True_)

    presentation.save("line_breaking.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Ovládání visící interpunkce**

[ParagraphFormat.setHangingPunctuation](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setHangingPunctuation) umožňuje oprávněné interpunkční znaky přesahovat pravý okraj řádku textu místo aby zabíraly další řádek. Platí pro celý odstavec a liší se od visícího odsazení.

Níže uvedený samostatný příklad povoluje visící interpunkci v textovém rámci širokém 100 bodů a ukládá „hanging_punctuation.pptx“. S 24‑bodovým Arial a nulovými vodorovnými okraji textového rámce zůstává poslední tečka po slově „sentence“ a přesahuje pravý okraj textu. Nastavte vlastnost na [NullableBool.False_](https://reference.aspose.com/slides/python-java/aspose.slides/nullablebool/) pro srovnání: s těmito nastaveními tečka zabírá samostatný řádek. Zalamování je povoleno a automatické přizpůsobení je vypnuto, aby zůstala dostupná šířka pevná.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontData, NullableBool, Presentation, SaveFormat, ShapeType, TextAlignment, TextAutofitType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 100, 200)
    shape.getFillFormat().setFillType(FillType.NoFill)

    text_frame = shape.getTextFrame()
    text_frame.getTextFrameFormat().setWrapText(NullableBool.True_)
    text_frame.getTextFrameFormat().setAutofitType(TextAutofitType.None_)
    text_frame.getTextFrameFormat().setMarginLeft(0)
    text_frame.getTextFrameFormat().setMarginRight(0)

    paragraph = text_frame.getParagraphs().get_Item(0)
    paragraph.setText("Simple text, next sentence.")

    paragraph_format = paragraph.getParagraphFormat()
    paragraph_format.setAlignment(TextAlignment.Left)
    paragraph_format.getDefaultPortionFormat().setFontHeight(24)
    latin_font = FontData("Arial")
    paragraph_format.getDefaultPortionFormat().setLatinFont(latin_font)
    paragraph_format.getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    paragraph_format.getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    paragraph_format.setHangingPunctuation(NullableBool.True_)

    presentation.save("hanging_punctuation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Ne každá interpunkční značka může viset. [Podmínky písma a rozvržení popsané výše](#control-line-breaking) také platí pro toto srovnání: změna písma, dostupné šířky, okrajů nebo nastavení automatického přizpůsobení může odstranit viditelný rozdíl.

## **Nastavit typ automatického přizpůsobení pro textové rámy**

[TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setAutofitType) určuje, jak se text chová, když přesáhne hranice svého kontejneru. Použijte jej k řízení, zda se text zmenšuje, přetéka nebo automaticky mění velikost tvaru. Následující příklad konfiguruje tvar tak, aby se velikost automaticky přizpůsobila textu a ukládá výsledek do „autofit_type.pptx“.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TextAutofitType

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    auto_shape.getTextFrame().getTextFrameFormat().setAutofitType(TextAutofitType.Shape)

    presentation.save("autofit_type.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Pro počet řádků po automatickém zalamování a zjištění, jak se mění šířka textu nebo tvaru, viz [Count Rendered Lines](/slides/cs/python-java/manage-paragraph/). Počet řádků sám o sebe neukazuje, zda text přesahuje kontejner.

## **Nastavit ukotvení textových rámců**

[TextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setAnchoringType) určuje, jak je text vertikálně umístěn uvnitř tvaru, např. nahoře, uprostřed nebo dole. Následující příklad ukotví text na dno prvního tvaru a uloží výsledek do „text_anchor.pptx“.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TextAnchorType

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    auto_shape.getTextFrame().getTextFrameFormat().setAnchoringType(TextAnchorType.Bottom)

    presentation.save("text_anchor.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Nastavit tabulaci textu**

Použijte [ParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setDefaultTabSize) a [ParagraphFormat.getTabs](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getTabs) k nastavení tabulátorů v odstavci. Následující příklad nastaví výchozí interval tabulátoru na 100 bodů a přidá levý zarovnaný tabulátor na 30 bodů.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TabAlignment

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)

    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)
    paragraph.getParagraphFormat().setDefaultTabSize(100)
    paragraph.getParagraphFormat().getTabs().add(30, TabAlignment.Left)

    presentation.save("paragraph_tabs.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Výsledek:

![Tabulátory odstavce](paragraph_tabs.png)

## **Nastavit jazyk pravopisu**

Aspose.Slides poskytuje [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setLanguageId), který umožňuje nastavit jazyk pravopisu pro textovou část. Jazyk pravopisu určuje jazyk používaný k pravopisným a gramatickým kontrolám v PowerPointu.

Následující příklad vyžaduje „presentation.pptx“ s textovým polem jako prvním tvarem na první snímek a alespoň jedním odstavcem. Nahrazuje obsah prvního odstavce řetězcem „1。」“, nastaví SimSun jako písmo a přiřadí jazyk pravopisu zjednodušené čínštiny (`zh-CN`). Uloží výsledek jako „proofing_language.pptx“:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, Portion, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)

    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)
    paragraph.getPortions().clear()

    font = FontData("SimSun")

    text_portion = Portion()
    text_portion.getPortionFormat().setComplexScriptFont(font)
    text_portion.getPortionFormat().setEastAsianFont(font)
    text_portion.getPortionFormat().setLatinFont(font)

    # Nastavit Id jazyka pravopisu.
    text_portion.getPortionFormat().setLanguageId("zh-CN")

    text_portion.setText("1。")
    paragraph.getPortions().add(text_portion)

    presentation.save("proofing_language.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Kopírovat jazyková metadata**

Při kopírování vícejazyčného textu ze šablony zachovejte jak [BasePortionFormat.getLanguageId](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#getLanguageId), tak [BasePortionFormat.getAlternativeLanguageId](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#getAlternativeLanguageId). Níže uvedený samostatný příklad vytváří zdrojovou část s US English jako jazykem a francouzštinou jako alternativním jazykem a kopíruje text a identifikátory do části v nové prezentaci.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Portion, Presentation, SaveFormat, ShapeType

source = Portion("Hello! Bonjour!")
source.getPortionFormat().setLanguageId("en-US")
source.getPortionFormat().setAlternativeLanguageId("fr-FR")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 80)
    paragraph = shape.getTextFrame().getParagraphs().get_Item(0)
    paragraph.getPortions().clear()

    destination = Portion()
    destination.setText(source.getText())
    destination.getPortionFormat().setLanguageId(source.getPortionFormat().getLanguageId())
    # Pokud zdroj nemá alternativní jazyk, None vymaže hodnotu v cíli.
    destination.getPortionFormat().setAlternativeLanguageId(source.getPortionFormat().getAlternativeLanguageId())
    paragraph.getPortions().add(destination)

    presentation.save("copied_language_metadata.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Pro pokus o zdroj bez alternativního jazyka vynechte přiřazení `"fr-FR"`. Alternativní identifikátor potom bude `None` a stejný příkaz kopírování zachová jeho nepřítomnost, aniž zavede výchozí hodnotu, i když cíl měl dříve přiřazený alternativní jazyk.

Tyto identifikátory jsou uloženy jako jazyková metadata. Zachování jejich hodnot neznamená, který slovník PowerPoint použije pro pravopis nebo gramatické kontroly.

## **Nastavit výchozí jazyk**

Použijte [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setDefaultTextLanguage) k definování výchozího jazyka pro text vytvářený při načítání nebo vytváření prezentace. Níže uvedený příklad vytváří prezentaci s US English jako výchozím jazykem textu, přidá textové pole a vypíše `en-US` pro jeho první textovou část.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, ShapeType

load_options = LoadOptions()
load_options.setDefaultTextLanguage("en-US")

presentation = Presentation(load_options)
try:
    slide = presentation.getSlides().get_Item(0)

    # Přidat obdélníkový tvar s textem.
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 50)
    shape.getTextFrame().setText("Sample text")

    # Zkontrolovat jazyk první části.
    portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    print(portion.getPortionFormat().getLanguageId())
finally:
    presentation.dispose()
```

## **Nastavit výchozí styl textu**

Pro nastavení výchozího formátování textu na úrovni prezentace použijte [Presentation.getDefaultTextStyle](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getDefaultTextStyle).

Níže uvedený příklad nastaví 14‑bodové tučné písmo jako výchozí pro odstavce nejvyšší úrovně v nové prezentaci a uloží jej jako „default_text_style.pptx“. Text může dědit tato výchozí nastavení, pokud není přepsán konkrétnějším formátováním.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NullableBool, Presentation, SaveFormat

presentation = Presentation()
try:
    # Získat formát odstavce nejvyšší úrovně.
    paragraph_format = presentation.getDefaultTextStyle().getLevel(0)

    if paragraph_format is not None:
        paragraph_format.getDefaultPortionFormat().setFontHeight(14)
        paragraph_format.getDefaultPortionFormat().setFontBold(NullableBool.True_)

    presentation.save("default_text_style.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Extrahovat text s efektem All Caps**

V PowerPointu aplikace efektu **All Caps** způsobí, že text vypadá na snímku velkými písmeny, i když byl původně napsán malými. Když získáte takovou textovou část pomocí Aspose.Slides, knihovna vrací text přesně tak, jak byl zadán. Pro odpovídající zobrazený text zkontrolujte [TextCapType](https://reference.aspose.com/slides/python-java/aspose.slides/textcaptype/) a při hodnotě `All` převést vrácený řetězec na velká písmena.

Tento příklad vyžaduje „sample2.pptx“ s textovým polem jako prvním tvarem na první snímek. První odstavec první části obsahuje „Hello, Aspose!“ s aplikovaným efektem All Caps, jak je znázorněno níže.

![Efekt All Caps](all_caps_effect.png)

Níže uvedený příklad kódu ukazuje, jak extrahovat text s aplikovaným efektem **All Caps**:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, TextCapType

presentation = Presentation("sample2.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    
    auto_shape = slide.getShapes().get_Item(0)
    text_portion = auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)

    print("Original text: " + str(text_portion.getText()))

    text_format = text_portion.getPortionFormat().getEffective()
    if text_format.getTextCapType() == TextCapType.All:
        text = str(text_portion.getText()).upper()
        print("All-Caps effect: " + text)
finally:
    presentation.dispose()
```

Výstup:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **Často kladené otázky**

**Jak upravit text v tabulce na snímku?**

Pro upravení textu v tabulce na snímku použijte [Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/). Procházejte buňky a aktualizujte každou buňku pomocí [Cell.getTextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getTextFrame) a formátování odstavců pomocí [Paragraph.getParagraphFormat](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/#getParagraphFormat).

**Jak aplikovat gradientní barvu na text v PowerPointu?**

Pro aplikaci gradientní barvy na text použijte [BasePortionFormat.getFillFormat](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#getFillFormat). Nastavte [FillFormat.setFillType](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#setFillType) na [FillType.Gradient](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/) a konfigurujte gradientové zastávy, směr a průhlednost.