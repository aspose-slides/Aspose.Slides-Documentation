---
title: Formátování textu v prezentaci v Pythonu přes Java
linktitle: Formátování textu
type: docs
weight: 50
url: /cs/python-java/text-formatting/
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
- textový rámeček
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

Tento článek ukazuje, jak formátovat text v prezentacích PowerPoint a OpenDocument pomocí Aspose.Slides pro Python prostřednictvím Javy. Pokrývá barvy pozadí, průhlednost, mezery mezi znaky, vlastnosti písma, otočení, mezery odstavců, chování automatického přizpůsobení, ukotvení textu, tabulátory a nastavení jazyka.

V níže uvedených příkladech použijeme soubor nazvaný **„sample.pptx“**, který obsahuje jediný textový rámeček na první snímku s následujícím textem:

![Ukázkový text](sample_text.png)

Pro vyhledání a zvýraznění doslovného textu nebo shod regulárních výrazů viz [Vyhledávání a nahrazování textu](/slides/cs/python-java/search-and-replace-text/).

## **Nastavení barvy pozadí textu**

Použijte [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/cs/python-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) pro nastavení výchozí barvy zvýraznění odstavce nebo [PortionFormat.getHighlightColor](https://reference.aspose.com/slides/cs/python-java/aspose.slides/portionformat/) pro jednotlivé textové úseky.

Následující ukázkový kód ukazuje, jak nastavit barvu pozadí **celého odstavce**:

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

![Šedý odstavec](gray_paragraph.png)

Níže uvedený kód demonstruje, jak nastavit barvu pozadí **textových úseků s tučným písmem**:

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

![Šedé textové úseky](gray_text_portions.png)

## **Zarovnání odstavců textu**

Použijte [ParagraphFormat.setAlignment](https://reference.aspose.com/slides/cs/python-java/aspose.slides/paragraphformat/#setAlignment) pro nastavení zarovnání odstavce v textovém rámečku. Hodnota může být centrovaná, zarovnaná vlevo, vpravo, do bloku atd.

Následující ukázkový kód ukazuje, jak zarovnat odstavec **do středu**:

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

![Zarovnaný odstavec](aligned_paragraph.png)

## **Nastavení průhlednosti textu**

Průhlednost textu se řídí alfou komponentou barvy přiřazené pomocí [PortionFormat.getFillFormat](https://reference.aspose.com/slides/cs/python-java/aspose.slides/portionformat/). V níže uvedených příkladech je `alpha = 50` hodnota alfa kanálu ARGB v rozsahu 0–255, nikoli procento průhlednosti.

Ukázkový kód níže ukazuje, jak aplikovat průhlednost na **celý odstavec**:

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

![Průhledný odstavec](transparent_paragraph.png)

Následující ukázkový kód ukazuje, jak aplikovat průhlednost na **textové úseky s tučným písmem**:

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

![Průhledné textové úseky](transparent_text_portions.png)

## **Nastavení mezery mezi znaky textu**

Použijte [PortionFormat.setSpacing](https://reference.aspose.com/slides/cs/python-java/aspose.slides/portionformat/) pro rozšíření nebo zmenšení mezery mezi znaky v textovém rámečku.

Níže uvedený Python kód ukazuje, jak rozšířit mezeru mezi znaky v **celém odstavci**:

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

    # Poznámka: Použijte záporné hodnoty pro zúžení mezery mezi znaky.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3) # Rozšířit mezeru mezi znaky.

    presentation.save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Výsledek:

![Mezera mezi znaky v odstavci](character_spacing_in_paragraph.png)

Ukázkový kód níže ukazuje, jak rozšířit mezeru mezi znaky v **textových úsecích s tučným písmem**:

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
            # Poznámka: Použijte záporné hodnoty pro zúžení mezery mezi znaky.
            portion.getPortionFormat().setSpacing(3) # Rozšířit mezeru mezi znaky.

    presentation.save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Výsledek:

![Mezera mezi znaky v textových úsecích](character_spacing_in_text_portions.png)

### **Zakázání kerningu pro konkrétní písma**

V některých případech může text vykreslený pomocí Aspose.Slides vypadat mírně těsněji než stejný text zobrazený v PowerPointu. K tomu může dojít, protože PowerPoint může ignorovat data kerningu u určitých písem, i když písmo obsahuje platné informace o kernování a kerning je v nastavení PowerPointu povolen.

Aby výstup lépe odpovídal PowerPointu, můžete pro textové úseky, které používají dotčené písmo, kerning zakázat. Nastavte [PortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/cs/python-java/aspose.slides/portionformat/) na hodnotu výrazně větší než skutečná velikost písma:

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
            portion_format = portion.getPortionFormat()
            fonts = (portion_format.getLatinFont(), portion_format.getEastAsianFont(), portion_format.getComplexScriptFont())
            if any(font is not None and font.getFontName() == target_font for font in fonts):
                portion_format.setKerningMinimalSize(100)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Toto nastavení zabrání aplikaci kerningu na odpovídající textové úseky a může pomoci sladit vykreslování Aspose.Slides s vizuálním výstupem PowerPointu u písem, na která se tento specifický PowerPoint‑specifický chování vztahuje.

## **Správa vlastností písma textu**

Vlastnosti písma lze nastavit na úrovni odstavce pomocí [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/cs/python-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) nebo pro jednotlivé úseky pomocí [PortionFormat](https://reference.aspose.com/slides/cs/python-java/aspose.slides/portionformat/).

Následující kód nastavuje písmo a styl textu pro celý odstavec: aplikuje velikost písma, tučné, kurzíva, tečkované podtržení a písmo Times New Roman na všechny úseky v odstavci.

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

![Vlastnosti písma pro odstavec](font_properties_for_paragraph.png)

Ukázkový kód níže aplikuje podobné vlastnosti na **textové úseky s tučným písmem**:

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

![Vlastnosti písma pro textové úseky](font_properties_for_text_portions.png)

## **Nastavení otočení textu**

Použijte [TextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/cs/python-java/aspose.slides/textframeformat/#setTextVerticalType) pro nastavení předdefinované orientace textu uvnitř tvaru.

Následující ukázkový kód nastavuje orientaci textu v tvaru na `Vertical270`, což otáčí text **o 90 stupňů proti směru hodinových ručiček**:

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

![Otočení textu](text_rotation.png)

## **Nastavení vlastního otočení pro textové rámečky**

Použijte [TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/cs/python-java/aspose.slides/textframeformat/#setRotationAngle) pro nastavení vlastního úhlu otočení pro [TextFrame](https://reference.aspose.com/slides/cs/python-java/aspose.slides/textframe/).

Ukázkový kód níže otáčí textový rámeček o 3 stupně po směru hodinových ručiček uvnitř tvaru:

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

![Vlastní otočení textu](custom_text_rotation.png)

## **Nastavení řádkování odstavců**

Aspose.Slides poskytuje [ParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/cs/python-java/aspose.slides/paragraphformat/#setSpaceAfter), [ParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/cs/python-java/aspose.slides/paragraphformat/#setSpaceBefore) a [ParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/cs/python-java/aspose.slides/paragraphformat/#setSpaceWithin) pro řízení mezery odstavců. Tyto vlastnosti se používají následovně:

* Použijte kladnou hodnotu pro určení řádkování jako procenta výšky řádku.
* Použijte zápornou hodnotu pro určení řádkování v bodech.

Následující ukázkový kód ukazuje, jak specifikovat řádkování v odstavci:

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

![Řádkování v odstavci](line_spacing.png)

## **Nastavení typu automatického přizpůsobení pro textové rámečky**

[TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/cs/python-java/aspose.slides/textframeformat/#setAutofitType) určuje, jak se text chová, když přesáhne hranice svého kontejneru. Použijte jej k řízení, zda se text zmenší, přeteče nebo automaticky změní velikost tvaru.

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

Pro spočítání řádků po automatickém zalomení a zjištění, jak se mění šířka textu nebo tvaru, viz [Počítání vykreslených řádků](/slides/cs/python-java/manage-paragraph/). Samotný počet řádků neukazuje, zda text přetéká svůj kontejner.

## **Nastavení ukotvení textových rámečků**

[TextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/cs/python-java/aspose.slides/textframeformat/#setAnchoringType) definuje, jak je text vertikálně umístěn uvnitř tvaru, například nahoře, uprostřed nebo dole.

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

## **Nastavení tabulace textu**

Použijte [ParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/cs/python-java/aspose.slides/paragraphformat/#setDefaultTabSize) a [ParagraphFormat.getTabs](https://reference.aspose.com/slides/cs/python-java/aspose.slides/paragraphformat/#getTabs) pro konfiguraci tabulátorů v odstavci.

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

## **Nastavení jazyka korektury**

Aspose.Slides poskytuje [PortionFormat.setLanguageId](https://reference.aspose.com/slides/cs/python-java/aspose.slides/portionformat/), který umožňuje nastavit jazyk korektury pro textový úsek. Jazyk korektury určuje jazyk použitého pravopisného a gramatického kontroloru v PowerPointu.

Následující ukázkový kód ukazuje, jak nastavit jazyk korektury pro textový úsek:

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

    # Nastavte Id jazykové korektury.
    text_portion.getPortionFormat().setLanguageId("zh-CN")

    text_portion.setText("1。")
    paragraph.getPortions().add(text_portion)

    presentation.save("proofing_language.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Nastavení výchozího jazyka**

Použijte [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/cs/python-java/aspose.slides/loadoptions/#setDefaultTextLanguage) k definování výchozího jazyka pro text vytvářený při načítání nebo tvorbě prezentace.

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

## **Nastavení výchozího textového stylu**

Pro aplikaci výchozího formátování textu na úrovni celé prezentace použijte [Presentation.getDefaultTextStyle](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/#getDefaultTextStyle).

Následující ukázkový kód ukazuje, jak nastavit výchozí tučný font o velikosti 14 pt pro veškerý text napříč snímky v nové prezentaci.

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

## **Extrahování textu s efektem VŠECHMISTOVÁNÍ**

V PowerPointu aplikace efektu **All Caps** (všechna písmena velká) způsobí, že se text na snímku zobrazuje velkými písmeny, i když byl původně zadán malými. Když takový textový úsek získáte pomocí Aspose.Slides, knihovna vrátí text přesně tak, jak byl zadán. Pro sladění se zobrazeným textem zkontrolujte [TextCapType](https://reference.aspose.com/slides/cs/python-java/aspose.slides/textcaptype/) a převedete vrácený řetězec na velká písmena, pokud je hodnota `All`.

Předpokládejme, že máme následující textový rámeček na prvním snímku souboru **sample2.pptx**.

![Efekt Všechna velká písmena](all_caps_effect.png)

Ukázkový kód níže ukazuje, jak extrahovat text s aplikovaným **All Caps** efektem:

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

Pro úpravu textu v tabulce na snímku použijte [Table](https://reference.aspose.com/slides/cs/python-java/aspose.slides/table/). Procházejte buňky a aktualizujte každou buňku pomocí [Cell.getTextFrame](https://reference.aspose.com/slides/cs/python-java/aspose.slides/cell/#getTextFrame) a formátování odstavců pomocí [Paragraph.getParagraphFormat](https://reference.aspose.com/slides/cs/python-java/aspose.slides/paragraph/#getParagraphFormat).

**Jak mohu aplikovat gradientní barvu na text ve snímku PowerPoint?**

Pro aplikaci gradientní barvy na text použijte [PortionFormat.getFillFormat](https://reference.aspose.com/slides/cs/python-java/aspose.slides/portionformat/). Nastavte [FillFormat.setFillType](https://reference.aspose.com/slides/cs/python-java/aspose.slides/fillformat/#setFillType) na [FillType.Gradient](https://reference.aspose.com/slides/cs/python-java/aspose.slides/filltype/#Gradient) a nakonfigurujte gradientní zastávky, směr a průhlednost.