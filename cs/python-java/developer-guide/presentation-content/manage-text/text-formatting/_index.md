---
title: Formátování textu prezentace v Pythonu pomocí Javy
linktitle: Formátování textu
type: docs
weight: 50
url: /cs/python-java/text-formatting/
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
- Java
- Aspose.Slides
description: "Formátujte a stylizujte text v prezentacích PowerPoint a OpenDocument pomocí Aspose.Slides pro Python přes Java. Přizpůsobte písma, barvy, zarovnání a další."
---
## **Přehled**

Tento článek ukazuje, jak formátovat text v prezentacích PowerPoint a OpenDocument pomocí Aspose.Slides for Python via Java. Pokrývá barvy pozadí, průhlednost, mezery mezi znaky, vlastnosti písma, otočení, řádkování odstavců, chování automatického přizpůsobení, ukotvení textu, tabulátory a nastavení jazyka.

Pokud není uvedeno jinak, příklady používají [sample.pptx](sample.pptx). První tvar na první snímku je textové pole a jeho první odstavec obsahuje text uvedený níže. Indexy snímků i tvarů jsou nulové. Příklady, které vybírají tučné části, používají efektivní formátování, včetně zděděného tučného formátování:

![Sample text](sample_text.png)

Pro vyhledání a zvýraznění doslovného textu nebo shod regulárních výrazů viz [Search and Replace Text](/slides/cs/python-java/search-and-replace-text/).

## **Nastavit barvu pozadí textu**

Použijte [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) k nastavení výchozí barvy zvýraznění pro odstavec nebo použijte [BasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#getHighlightColor) pro jednotlivé textové úseky.

Následující příklad nastaví světle šedé zvýraznění jako výchozí pro první odstavec. Explicitní barvy zvýraznění na jednotlivých úsecích mají přednost před tímto výchozím nastavením:

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

    # Nastavte barvu zvýraznění pro celý odstavec.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getHighlightColor().setColor(Color.LIGHT_GRAY)

    presentation.save("gray_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Výsledek:

![The gray paragraph](gray_paragraph.png)

Níže uvedený kód ukazuje, jak nastavit barvu pozadí **textových úseků s tučným písmem**:

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
            # Nastavte barvu zvýraznění pro textový úsek.
            portion.getPortionFormat().getHighlightColor().setColor(Color.LIGHT_GRAY)

    presentation.save("gray_text_portions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Výsledek:

![The gray text portions](gray_text_portions.png)

## **Zarovnat odstavce textu**

Použijte [ParagraphFormat.setAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setAlignment) k nastavení zarovnání odstavce v textovém rámci. Hodnota může být centrovaná, zarovnaná vlevo, vpravo, do bloku atd.

Následující kód ukazuje, jak zarovnat odstavec **na střed**:

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

    # Nastavte zarovnání odstavce na střed.
    paragraph.getParagraphFormat().setAlignment(TextAlignment.Center)

    presentation.save("aligned_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Výsledek:

![The aligned paragraph](aligned_paragraph.png)

## **Zarovnat písma v řádku**

Použijte [ParagraphFormat.setFontAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setFontAlignment) k vertikálnímu zarovnání textových úseků různých velikostí písma v řádku. Toto nastavení se vztahuje na celý odstavec a řídí zarovnání v každém z jeho řádků.

Následující samostatný příklad vytváří čtyři označená textová pole na jednom snímku. Každý odstavec obsahuje stejný text v 18, 36 a 54 bodech s různým zarovnáním písma. Používá Arial, zakazuje automatické přizpůsobení a zalamování a udržuje textové rámce dostatečně velké pro jediný řádek.

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

![Comparison of Baseline, Top, Center, and Bottom font alignment with mixed font sizes](font_alignment.png)

Zarovnání písma používá metriky písma, takže viditelné hrany jednotlivých znaků se nemusí přesně shodovat. Příklad obsahuje jak velké písmeno, tak spodní část (descender), aby ukázal rozdíl mezi zarovnáním k základně a ke spodní hraně. Dostupnost písma a jeho substituce, použité znaky a rozdíl ve velikostech písma ovlivňují výsledek. Rozměry rámce, okraje, řádkování, zalamování a automatické přizpůsobení také ovlivňují rozložení; při porovnávání režimů používejte stejná písma a nastavení rozložení.

Toto nastavení se liší od [ParagraphFormat.setAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setAlignment), který řídí horizontální zarovnání odstavce, a od [TextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setAnchoringType), který vertikálně umisťuje textový blok uvnitř tvaru. Formátování horního a dolního indexu pomocí [BasePortionFormat.setEscapement](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setEscapement) posouvá jednotlivé úseky relativně k základně místo nastavení zarovnání písma pro řádky odstavce.

## **Nastavit průhlednost textu**

Průhlednost textu se řídí alfa komponentou barvy přiřazené pomocí [BasePortionFormat.getFillFormat](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#getFillFormat). V níže uvedených příkladech je `alpha = 50` hodnota kanálu alfa ARGB v rozsahu 0–255, nikoli procento průhlednosti.

Níže uvedený kód ukazuje, jak aplikovat průhlednost na **celý odstavec**:

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

    # Nastavte barvu výplně textu na průhlednou barvu.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(text_color)

    presentation.save("transparent_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Výsledek:

![The transparent paragraph](transparent_paragraph.png)

Následující kód ukazuje, jak aplikovat průhlednost na **textové úseky s tučným písmem**:

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
            # Nastavte průhlednost textového úseku.
            portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
            portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(text_color)

    presentation.save("transparent_text_portions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Výsledek:

![The transparent text portions](transparent_text_portions.png)

## **Nastavit mezery mezi znaky textu**

Použijte [BasePortionFormat.setSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setSpacing) pro rozšíření nebo zmenšení mezery mezi znaky v textovém poli. Příklady přidávají 3 body mezery; záporné hodnoty mezery zmenšují text.

Níže uvedený Python kód ukazuje, jak rozšířit mezery mezi znaky v **celém odstavci**:

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

    # Poznámka: Použijte záporné hodnoty k zmenšení mezery mezi znaky.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3) # Zvětšete mezeru mezi znaky.

    presentation.save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Výsledek:

![The character spacing in the paragraph](character_spacing_in_paragraph.png)

Níže uvedený kód ukazuje, jak rozšířit mezery mezi znaky v **textových úsecích s tučným písmem**:

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
            # Poznámka: Použijte záporné hodnoty k zmenšení mezery mezi znaky.
            portion.getPortionFormat().setSpacing(3) # Zvětšete mezeru mezi znaky.

    presentation.save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Výsledek:

![The character spacing in the text portions](character_spacing_in_text_portions.png)

### **Zakázat kerning pro konkrétní písma**

V některých případech může text vykreslený Aspose.Slides vypadat mírně těsněji než stejný text v PowerPointu. K tomu může dojít, protože PowerPoint může ignorovat kerningová data pro určitá písma, i když písmo obsahuje platná kerningová data a kerning je v nastaveních PowerPointu povolen.

Pro dosažení výstupu blíže PowerPointu můžete zakázat kerning pro textové úseky používající dotčené písmo. Nastavte [BasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setKerningMinimalSize) na hodnotu vyšší než skutečná velikost písma. Tento příklad vyžaduje "presentation.pptx" s textovým polem jako první tvar na první snímku. Kontroluje efektivní názvy písem, včetně zděděných, a nastaví práh 100 bodů pro úseky používající Roboto. Tím se zakáže kerning pro odpovídající úseky s velikostí písma pod 100 bodů:

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

Pro text pod prahem toto nastavení zabraňuje kerningu a může pomoci sladit vykreslení Aspose.Slides s vizuálním výstupem PowerPointu pro písma, na která se tato specifická chování PowerPointu vztahují.

## **Spravovat vlastnosti písma textu**

Vlastnosti písma lze nastavit na úrovni odstavce pomocí [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) nebo na jednotlivých úsecích pomocí [PortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/portionformat/).

Následující příklad nastaví výchozí písmo prvního odstavce na 12‑bodové Times New Roman s tučným, kurzívovým a tečkovaným podtržením. Explicitní formátování na jednotlivých úsecích má přednost před těmito výchozími hodnotami:

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

    # Nastavte vlastnosti písma pro odstavec.
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

![The font properties for the paragraph](font_properties_for_paragraph.png)

Následující příklad použije 13‑bodové Times New Roman, kurzívu a tečkované podtržení na úseky, jejichž efektivní formátování je tučné:

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
            # Nastavte vlastnosti písma pro textový úsek.
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

![The font properties for text portions](font_properties_for_text_portions.png)

## **Ovládání normalizace výšky textu**

Použijte [BasePortionFormat.setNormaliseHeight](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setNormaliseHeight) při reprodukci typografie šablony nebo zkoumání rozdílů ve výšce znaků. V PowerPointu povolení normalizace rozprostírá nebo stlačuje jednotlivé znaky vertikálně tak, aby měly jednotnou viditelnou výšku v rámci textového úseku. Nezaručuje stejné výšky textu mezi různými písmy.

Nastavte vlastnost na [NullableBool.True_ or False_](https://reference.aspose.com/slides/python-java/aspose.slides/nullablebool/) pro explicitní povolení nebo zakázání normalizace. `NullableBool.NotDefined` ponechá lokální nastavení nedefinované, takže úsek zdědí hodnotu, např. z [getDefaultPortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) odstavce. To neznamená `False`. Použijte [PortionFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/portionformat/#getEffective) a přečtěte `getNormaliseHeight` na vráceném efektivním formátování pro získání rozlišené boolovské hodnoty.

Následující samostatný příklad vyžaduje nainstalovaný **Arial**. Vytváří dva textové bloky obsahující stejné velké a malé písmeno, spodní části znaků a diakritiku při 54 bodech. Oba odstavce mají ve výchozím nastavení normalizaci povolenou. Horní úsek ji explicitně zakazuje; spodní úsek ji dědí. Rozměry rámců, okraje a řádkování jsou identické, zalamování a automatické přizpůsobení jsou vypnuté pro zachování konzistence porovnání. Příklad vytiskne `False: False` a `NotDefined: True` a uloží soubor "text_height_normalization.pptx".

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

Porovnání níže bylo exportováno ze uložené prezentace. Horní řádek má normalizaci zakázanou (`False`); spodní řádek ji dědí (`NotDefined` → `True`). Pro reprodukci vzhledu mějte nainstalovaný Arial.

![Arial 54-point text with normalization disabled above and inherited normalization enabled below](text_height_normalization.png)

Normalizace mění výšku znaků bez změny přiřazené hodnoty [getFontHeight](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#getFontHeight), která udává velikost písma v bodech. Metoda odstavce [setSpaceWithin](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setSpaceWithin) řídí řádkování, zatímco [setAutofitType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setAutofitType) v textovém rámci určuje, jak se text nebo jeho kontejner přizpůsobuje. Tato nastavení slouží k různým účelům a mohou nezávisle ovlivnit celkové rozložení. Další informace o formátování odstavců a dědičnosti najdete v [Manage Paragraph](/slides/cs/python-java/manage-paragraph/).

## **Použít a odstranit přeškrtnutí**

Použijte [BasePortionFormat.setStrikethroughType](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setStrikethroughType) na textový úsek k zobrazení oprav, zrušených výrazů nebo starých cen bez mazání původního textu. Nastavte na [TextStrikethroughType.Single or Double](https://reference.aspose.com/slides/python-java/aspose.slides/textstrikethroughtype/) pro jednu nebo dvě čáry přes text.

Pro odstranění přeškrtnutí použijte [TextStrikethroughType.None_](https://reference.aspose.com/slides/python-java/aspose.slides/textstrikethroughtype/#None). Tím se efekt explicitně zakáže, i když okolní formátování přeškrtnutí specifikuje. Naopak [TextStrikethroughType.NotDefined](https://reference.aspose.com/slides/python-java/aspose.slides/textstrikethroughtype/#NotDefined) ponechává lokální nastavení nedefinované, což umožňuje úseku zdědit formátování, např. z odstavce. To nezaručuje, že je přeškrtnutí odstraněno. Použijte [PortionFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/portionformat/#getEffective) pro načtení výsledného formátování včetně zděděných hodnot.

Následující samostatný příklad vytváří tři srovnání cen. Každý odstavec má samostatné úseky pro popisek, starou cenu a novou cenu, takže pouze stará cena je ovlivněna. První řádek použije přeškrtnutí a poté jej odstraní; ostatní řádky zachovají jednoduché a dvojité přeškrtnutí. Změna tohoto nastavení zachovává text a jeho další formátování, včetně tučné staré ceny.

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

    # Aplikujte přeškrtnutí a poté jej explicitně odeberte od první předchozí ceny.
    paragraphs.get_Item(0).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.Single)
    paragraphs.get_Item(0).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.None_)

    paragraphs.get_Item(1).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.Single)
    paragraphs.get_Item(2).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.Double)

    presentation.save("strikethrough.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Výsledek zhora dolů: bez přeškrtnutí, jednoduché přeškrtnutí a dvojité přeškrtnutí.

![Previous prices without strikethrough, with single strikethrough, and with double strikethrough](strikethrough.png)

## **Nastavit otočení textu**

Použijte [TextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setTextVerticalType) k nastavení předdefinované orientace textu uvnitř tvaru.

Následující kód nastaví orientaci textu ve tvaru na [TextVerticalType.Vertical270](https://reference.aspose.com/slides/python-java/aspose.slides/textverticaltype/), což otáčí text **o 90 stupňů proti směru hodinových ručiček**:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpime.startJVM()

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

![The text rotation](text_rotation.png)

## **Nastavit vlastní otočení pro textové rámečky**

Použijte [TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setRotationAngle) k nastavení vlastního úhlu otočení pro [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/).

Následující kód otáčí textový rámec o 3 stupně po směru hodinových ručiček uvnitř tvaru:

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

![The custom text rotation](custom_text_rotation.png)

## **Nastavit řádkování odstavců**

Aspose.Slides poskytuje [ParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setSpaceAfter), [ParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setSpaceBefore) a [ParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setSpaceWithin) pro řízení řádkování odstavců. Tyto vlastnosti se používají takto:

* Použijte kladnou hodnotu k určení řádkování jako procenta výšky řádku.
* Použijte zápornou hodnotu k určení řádkování v bodech.

Následující příklad nastaví řádkování uvnitř prvního odstavce na 200 % výšky řádku (dvojité řádkování):

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

![The line spacing within the paragraph](line_spacing.png)

## **Ovládání zalamování řádků**

Pravidla zalamování řádků odstavce jsou užitečná v úzkých textových blocích a prezentacích, které kombinují latinský a východoasijský text. Následující metody patří do [ParagraphFormat](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/), takže se vztahují na celý odstavec:

- [setLatinLineBreak](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setLatinLineBreak) řídí pravidla zalamování latinského textu. V smíšeném textu může změna ovlivnit i místo, kde se zalamuje sousední východoasijský text a interpunkce.
- [setEastAsianLineBreak](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setEastAsianLineBreak) řídí pravidla zalamování východoasijského textu, včetně omezení znaků na začátku a konci řádku.

Tato pravidla nenahrazují [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setWrapText), které povoluje automatické zalamování uvnitř textového rámce. Ovlivňují rozložení, když k zalamování dochází; nevkládají znaky konce řádku. Výslovné zalomení řádku vynutí nový řádek v odstavci nezávisle na dostupné šířce.

Následující samostatný příklad vytváří úzký textový blok obsahující čínštinu a latinku. Nastaví obě možnosti zalamování explicitně a uloží soubor "line_breaking.pptx". Pro experimentování s libovolným pravidlem změňte odpovídající hodnotu při zachování druhého nastavení. Příklad používá 24‑bodové Arial a SimSun s šířkou rámce 160 bodů a nulovými horizontálními okraji textového rámce. [TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setAutofitType) se volá s [TextAutofitType.None_](https://reference.aspose.com/slides/python-java/aspose.slides/textautofittype/) tak, aby velikost textu a rozměry rámce zůstaly pevné.

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

[ParagraphFormat.setHangingPunctuation](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setHangingPunctuation) umožňuje oprávněné interpunkci přesáhnout pravý okraj řádku textu místo toho, aby obsadila následující řádek. Týká se celého odstavce a liší se od visícího odsazení.

Následující samostatný příklad povolí visící interpunkci v 100‑bodovém širokém textovém rámci a uloží soubor "hanging_punctuation.pptx". S 24‑bodovým Arial a nulovými horizontálními okraji textového rámce poslední tečka zůstane za slovem "sentence" a přesáhne pravý okraj textu. Nastavte vlastnost na [NullableBool.False_](https://reference.aspose.com/slides/python-java/aspose.slides/nullablebool/) pro srovnání: s tímto nastavením tečka obsadí samostatný řádek. Zalamování je povoleno a automatické přizpůsobení je zakázáno, aby zůstala dostupná šířka pevná.

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

Ne každá interpunkční značka může viset. Výše popsané [podmínky písma a rozložení](#control-line-breaking) také platí pro toto srovnání: změna písma, dostupné šířky, okrajů nebo nastavení automatického přizpůsobení může viditelný rozdíl odstranit.

## **Nastavit typ automatického přizpůsobení pro textové rámečky**

[TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setAutofitType) určuje, jak se text chová, když přesáhne hranice svého kontejneru. Použijte jej k řízení, zda se text zmenšuje, přetéká, nebo automaticky mění velikost tvaru. Následující příklad konfiguruje tvar tak, aby se přizpůsobil svému textu, a uloží výsledek do souboru "autofit_type.pptx".

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

Pro spočítání řádků po automatickém zalamování a zjištění, jak se mění šířka textu nebo tvaru, viz [Count Rendered Lines](/slides/cs/python-java/manage-paragraph/). Počet řádků sám o sobě neukazuje, zda text přesahuje svůj kontejner.

## **Nastavit ukotvení textových rámečků**

[TextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setAnchoringType) určuje, jak je text vertikálně umístěn uvnitř tvaru, např. nahoře, uprostřed nebo dole. Následující příklad ukotví text ke dnu prvního tvaru a uloží výsledek do souboru "text_anchor.pptx".

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

Použijte [ParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setDefaultTabSize) a [ParagraphFormat.getTabs](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getTabs) k nastavení tabulátorů v odstavci. Následující příklad nastaví výchozí interval tabulátoru na 100 bodů a přidá levostráněný tabulátor na 30 bodů. Tato nastavení ovlivňují text obsahující tabulátory.

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

![The paragraph tabs](paragraph_tabs.png)

## **Nastavit jazyk kontroly pravopisu**

Aspose.Slides poskytuje [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setLanguageId), který umožňuje nastavit jazyk kontroly pravopisu pro textový úsek. Jazyk kontroly určuje, jaký jazyk se použije pro kontrolu pravopisu a gramatiky v PowerPointu.

Následující příklad vyžaduje "presentation.pptx" s textovým polem jako první tvar na první snímku a alespoň jedním odstavcem. Nahrazuje obsah prvního odstavce řetězcem "1。", nastaví SimSun jako písmo a přiřadí jazyk pravopisu zjednodušené čínštiny (`zh-CN`). Výsledek uloží do souboru "proofing_language.pptx":

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

    # Nastavte Id jazyka pro korekturu.
    text_portion.getPortionFormat().setLanguageId("zh-CN")

    text_portion.setText("1。")
    paragraph.getPortions().add(text_portion)

    presentation.save("proofing_language.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Kopírovat jazyková metadata**

Při kopírování vícejazykového textu ze šablony zachovejte jak [BasePortionFormat.getLanguageId](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#getLanguageId), tak [BasePortionFormat.getAlternativeLanguageId](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#getAlternativeLanguageId). Následující samostatný příklad vytváří zdrojový úsek s US English jako jazykem a francouzštinou jako alternativním jazykem a kopíruje text i identifikátory do úseku v nové prezentaci.

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

Pro vyzkoušení zdroje bez alternativního jazyka vynechte přiřazení `"fr-FR"`. Alternativní identifikátor bude poté `None` a stejný příkaz pro kopírování zachová jeho nepřítomnost, aniž by zavedl výchozí hodnotu, i když cíl dříve měl alternativní jazyk přiřazený.

Tyto identifikátory jsou uloženy jako jazyková metadata. Jejich zachování nevymezuje, který slovník PowerPoint vybere pro kontrolu pravopisu nebo gramatiky.

## **Nastavit výchozí jazyk**

Použijte [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setDefaultTextLanguage) k definování výchozího jazyka pro text vytvářený při načítání nebo tvorbě prezentace. Následující příklad vytváří prezentaci s US English jako výchozím jazykem textu, přidá textové pole a vytiskne `en-US` pro jeho první textový úsek.

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

    # Přidejte obdélníkový tvar s textem.
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 50)
    shape.getTextFrame().setText("Sample text")

    # Zkontrolujte jazyk prvního úseku.
    portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    print(portion.getPortionFormat().getLanguageId())
finally:
    presentation.dispose()
```

## **Nastavit výchozí styl textu**

Pro aplikaci výchozího formátování textu na úrovni celé prezentace použijte [Presentation.getDefaultTextStyle](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getDefaultTextStyle).

Následující příklad nastaví 14‑bodové tučné písmo jako výchozí pro odstavce nejvyšší úrovně v nové prezentaci a uloží jej do souboru "default_text_style.pptx". Text může tyto výchozí hodnoty dědit, pokud není přepsán specifickým formátováním.

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

## **Extrahovat text s efektem Všechna velká písmena**

V PowerPointu aplikace efektu **All Caps** způsobí, že se text na snímku zobrazí velkými písmeny, i když byl původně zadán malými. Při získávání takového textového úseku pomocí Aspose.Slides knihovna vrací text přesně tak, jak byl zadán. Pro odpovídání zobrazenému textu zkontrolujte [TextCapType](https://reference.aspose.com/slides/python-java/aspose.slides/textcaptype/) a při hodnotě `All` převedete vrácený řetězec na velká písmena.

Tento příklad vyžaduje "sample2.pptx" s textovým polem jako první tvar na první snímku. První odstavec jeho prvního úseku obsahuje "Hello, Aspose!" s aplikovaným efektem All Caps, jak je znázorněno níže.

![The All Caps effect](all_caps_effect.png)

Níže uvedený kód ukazuje, jak extrahovat text s aplikovaným efektem **All Caps**:

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

**Jak mohu upravit text v tabulce na snímku?**

Pro úpravu textu v tabulce na snímku použijte [Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/). Procházejte buňky a aktualizujte každou buňku pomocí [Cell.getTextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getTextFrame) a formátování odstavců pomocí [Paragraph.getParagraphFormat](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/#getParagraphFormat).

**Jak mohu aplikovat gradientní barvu na text v PowerPoint snímku?**

Pro aplikaci gradientní barvy na text použijte [BasePortionFormat.getFillFormat](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#getFillFormat). Nastavte [FillFormat.setFillType](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#setFillType) na [FillType.Gradient](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/) a nakonfigurujte gradientní zastávky, směr a průhlednost.