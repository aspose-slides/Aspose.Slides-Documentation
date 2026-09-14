---
title: Správa fontů v prezentacích pomocí Pythonu přes Java
linktitle: Správa fontů
type: docs
weight: 10
url: /cs/python-java/manage-fonts/
keywords:
- správa fontů
- vlastnosti fontu
- odstavec
- formátování textu
- PowerPoint
- OpenDocument
- prezentace
- Python
- Java
- Aspose.Slides
description: "Ovládejte fonty v Pythonu přes Java s Aspose.Slides: vkládejte, nahrazujte a načítejte vlastní fonty, abyste zajistili, že prezentace PPT, PPTX a ODP jsou čitelné, bezpečné pro značku a konzistentní."
---
## **Přehled**

Aspose.Slides vám umožňuje spravovat vlastnosti písma v textu prezentace přímo z vašeho kódu. K textu na snímcích můžete přistupovat přes tvary, textová pole, odstavce a úseky a poté aplikovat formátování na vybraný text.

Tento článek vysvětluje, jak nastavit vlastnosti související s písmem pro existující text v prezentaci, včetně rodiny písma, tučného a kurzívního stylu, zarovnání odstavce a barvy písma. Také ukazuje, jak vytvořit textové pole, přidat do něj text a nastavit vlastnosti písma, jako je rodina písma, tučné, kurzíva, podtržení, velikost písma a barva, před uložením výsledku jako soubor PPTX.

{{% alert color="info" title="Poznámka" %}} 

Prezentace obvykle obsahují jak text, tak obrázky. Text lze formátovat různými způsoby, ať už pro zvýraznění konkrétních částí a slov, nebo aby odpovídal firemním stylům. Formátování textu pomáhá uživatelům měnit vzhled a pocit obsahu prezentace. Tento článek ukazuje, jak použít Aspose.Slides pro Python via Java k nastavení vlastností písma odstavců textu na snímcích.

{{% /alert %}} 

Pro správu vlastností písma odstavce pomocí Aspose.Slides pro Python via Java:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/).
1. Získejte odkaz na snímek pomocí jeho indexu.
1. Přístup k tvarům [Placeholder](https://reference.aspose.com/slides/cs/python-java/aspose.slides/placeholder/) na snímku jako [AutoShape](https://reference.aspose.com/slides/cs/python-java/aspose.slides/autoshape/).
1. Získejte [Paragraph](https://reference.aspose.com/slides/cs/python-java/aspose.slides/paragraph/) z [TextFrame](https://reference.aspose.com/slides/cs/python-java/aspose.slides/textframe/) poskytovaného [AutoShape](https://reference.aspose.com/slides/cs/python-java/aspose.slides/autoshape/).
1. Zarovnejte odstavec.
1. Přístup k textu [Portion](https://reference.aspose.com/slides/cs/python-java/aspose.slides/portion/) odstavce.
1. Definujte písmo pomocí [FontData](https://reference.aspose.com/slides/cs/python-java/aspose.slides/fontdata/) a nastavte **Font** textu [Portion](https://reference.aspose.com/slides/cs/python-java/aspose.slides/portion/) podle toho.
   1. Nastavte písmo tučné.
   1. Nastavte písmo kurzívou.
1. Nastavte barvu písma pomocí [FillFormat](https://reference.aspose.com/slides/cs/python-java/aspose.slides/fillformat/) poskytovaného objektem [Portion](https://reference.aspose.com/slides/cs/python-java/aspose.slides/portion/).
1. Uložte upravenou prezentaci do souboru PPTX.

Implementace výše uvedených kroků je uvedena níže. Bere se jednoduchá prezentace a formátuje písma na jednom ze snímků. Následující snímky obrazovky ukazují vstupní soubor a jak jej kódy mění. Kód mění písmo, barvu a styl písma.

|![Text in the input presentation](https://i.imgur.com/rqpPgJn.jpg)|
| :- |
|**Obrázek: Text ve vstupním souboru**|

|![Text with updated font formatting](https://i.imgur.com/rY27Lt9.png)|
| :- |
|**Obrázek: Stejný text s aktualizovaným formátováním**|

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontData, NullableBool, Presentation, SaveFormat, TextAlignment
from java.awt import Color

# Načtěte prezentaci.
presentation = Presentation("FontProperties.pptx")
try:
    # Přístup k prvnímu snímku a textovým rámcům jeho prvních dvou placeholderů.
    slide = presentation.getSlides().get_Item(0)
    title_text_frame = slide.getShapes().get_Item(0).getTextFrame()
    body_text_frame = slide.getShapes().get_Item(1).getTextFrame()

    # Přístup k prvnímu odstavci v každém textovém rámci.
    title_paragraph = title_text_frame.getParagraphs().get_Item(0)
    body_paragraph = body_text_frame.getParagraphs().get_Item(0)
    body_paragraph.getParagraphFormat().setAlignment(TextAlignment.JustifyLow)

    # Přístup k prvnímu úseku v každém odstavci.
    title_portion = title_paragraph.getPortions().get_Item(0)
    body_portion = body_paragraph.getPortions().get_Item(0)

    # Definujte a přiřaďte nová písma.
    title_font = FontData("Elephant")
    body_font = FontData("Castellar")
    title_portion.getPortionFormat().setLatinFont(title_font)
    body_portion.getPortionFormat().setLatinFont(body_font)

    # Nastavte písma na tučné a kurzívu.
    title_portion.getPortionFormat().setFontBold(NullableBool.True_)
    body_portion.getPortionFormat().setFontBold(NullableBool.True_)
    title_portion.getPortionFormat().setFontItalic(NullableBool.True_)
    body_portion.getPortionFormat().setFontItalic(NullableBool.True_)

    # Nastavte barvy písma.
    title_portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    title_portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    body_portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    body_portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GREEN)

    # Uložte prezentaci.
    presentation.save("WelcomeFont.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Nastavení vlastností písma textu**
{{% alert color="info" title="Poznámka" %}} 

Jak je uvedeno v sekci **Správa vlastností souvisejících s písmem**, [Portion](https://reference.aspose.com/slides/cs/python-java/aspose.slides/portion/) se používá k uchování textu se stejným stylem formátování v odstavci. Tento článek ukazuje, jak pomocí Aspose.Slides pro Python via Java vytvořit textové pole s textem a poté definovat konkrétní písmo a různé další vlastnosti písma.

{{% /alert %}} 

Pro vytvoření textového pole a nastavení vlastností písma textu v něm:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/).
1. Získejte odkaz na snímek pomocí jeho indexu.
1. Přidejte [AutoShape](https://reference.aspose.com/slides/cs/python-java/aspose.slides/autoshape/) typu **Rectangle** na snímek.
1. Odstraňte výplňový styl spojený s [AutoShape](https://reference.aspose.com/slides/cs/python-java/aspose.slides/autoshape/).
1. Přístup k [TextFrame](https://reference.aspose.com/slides/cs/python-java/aspose.slides/textframe/) [AutoShape](https://reference.aspose.com/slides/cs/python-java/aspose.slides/autoshape/).
1. Přidejte do [TextFrame](https://reference.aspose.com/slides/cs/python-java/aspose.slides/textframe/) nějaký text.
1. Přístup k objektu [Portion](https://reference.aspose.com/slides/cs/python-java/aspose.slides/portion/) spojenému s [TextFrame](https://reference.aspose.com/slides/cs/python-java/aspose.slides/textframe/).
1. Definujte písmo, které se má použít pro [Portion](https://reference.aspose.com/slides/cs/python-java/aspose.slides/portion/).
1. Nastavte další vlastnosti písma jako tučné, kurzíva, podtržení, barva a výška pomocí příslušných vlastností poskytovaných objektem [Portion](https://reference.aspose.com/slides/cs/python-java/aspose.slides/portion/).
1. Uložte upravenou prezentaci jako soubor PPTX.

Implementace výše uvedených kroků je uvedena níže.

|![Text with font properties applied](https://i.imgur.com/n5r12dS.jpg)|
| :- |
|**Obrázek: Text s některými nastavenými vlastnostmi písma pomocí Aspose.Slides pro Python via Java**|

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontData, NullableBool, Presentation, SaveFormat, ShapeType, TextUnderlineType
from java.awt import Color

presentation = Presentation()
try:
    # Získat první snímek a přidat obdélník.
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 50)

    # Odstranit výplň tvaru.
    shape.getFillFormat().setFillType(FillType.NoFill)

    # Přidat text do textového rámce tvaru.
    text_frame = shape.getTextFrame()
    text_frame.setText("Aspose TextBox")
    portion = text_frame.getParagraphs().get_Item(0).getPortions().get_Item(0)

    # Nastavit rodinu písma.
    font = FontData("Times New Roman")
    portion.getPortionFormat().setLatinFont(font)

    # Nastavit tučné, kurzívu, podtržení a velikost písma.
    portion.getPortionFormat().setFontBold(NullableBool.True_)
    portion.getPortionFormat().setFontItalic(NullableBool.True_)
    portion.getPortionFormat().setFontUnderline(TextUnderlineType.Single)
    portion.getPortionFormat().setFontHeight(25)

    # Nastavit barvu písma.
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    # Uložit prezentaci.
    presentation.save("pptxFont.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```