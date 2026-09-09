---
title: Automatizace lokalizace prezentací v Pythonu přes Java
linktitle: Lokalizace prezentace
type: docs
weight: 100
url: /cs/python-java/presentation-localization/
keywords:
- změna jazyka
- kontrola pravopisu
- potlačit kontrolu pravopisu
- jazyk korektury
- ID jazyka
- vícejazyčný text
- PowerPoint
- prezentace
- Python
- Java
- Aspose.Slides
description: "Nastavte jazyky korektury pro text prezentací PowerPoint a OpenDocument v Pythonu přes Java s Aspose.Slides, včetně výchozích nastavení a vícejazyčných odstavců."
---
## **Přehled**

Aspose.Slides pro Python přes Java vám umožňuje konfigurovat metadata korektury pro jednotlivé části textu. Použijte [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/cs/python-java/aspose.slides/baseportionformat/#setLanguageId) k určení jazyka korektury, [BasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/cs/python-java/aspose.slides/baseportionformat/#setSpellCheck) k povolení nebo potlačení kontrol pravopisu a [BasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/cs/python-java/aspose.slides/baseportionformat/#setProofDisabled) ke kontrole širšího stavu „neprovádět korekturu“. Protože jsou tato nastavení aplikována na úrovni části, jeden odstavec může obsahovat více jazyků a různá pravidla korektury.

Tento článek vysvětluje, jak přiřadit jazyk konkrétnímu textu, nastavit výchozí jazyk pro nový text pomocí [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/cs/python-java/aspose.slides/loadoptions/#setDefaultTextLanguage), vytvořit vícejazyčné odstavce, zvolit mezi [BasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/cs/python-java/aspose.slides/baseportionformat/#setSpellCheck) a [BasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/cs/python-java/aspose.slides/baseportionformat/#setProofDisabled) a zachovat zamýšlená nastavení při použití [Presentation.joinPortionsWithSameFormatting](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/#joinPortionsWithSameFormatting). Tyto vlastnosti ukládají metadata pro prezentační aplikace; nepřekládají text, neprovádějí kontrolu pravopisu založenou na slovníku ani nevrací chybně napsaná slova.

## **Nastavení jazyka korektury pro text**

Vytvořte nebo načtěte [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/), získáte požadovanou část textu pomocí [Portion.getPortionFormat](https://reference.aspose.com/slides/cs/python-java/aspose.slides/portion/#getPortionFormat), a přiřadíte její identifikátor jazyka. Následující příklad vytvoří tvar, nastaví britskou angličtinu jako jazyk korektury a výsledek uloží pomocí [Presentation.save](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/#save):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 320, 80)
    shape.getTextFrame().setText("Set the proofing language for this text.")

    portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.getPortionFormat().setLanguageId("en-GB")

    presentation.save("proofing_language.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Nastavení výchozího jazyka pro nový text**

Použijte [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/cs/python-java/aspose.slides/loadoptions/#setDefaultTextLanguage) k určení jazyka korektury, který Aspose.Slides přiřadí nově vytvořenému textu. Toto nastavení je užitečné, když většina nebo veškerý nový text v prezentaci používá stejný jazyk. Nemění metadata jazyka textu, který již má explicitně nastavený jazyk.

Následující příklad vytvoří prezentaci, ve které nový text používá pravidla korektury pro němčinu:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, SaveFormat, ShapeType

load_options = LoadOptions()
load_options.setDefaultTextLanguage("de-DE")

presentation = Presentation(load_options)
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 320, 80)
    shape.getTextFrame().setText("Willkommen zur Präsentation")

    presentation.save("default_text_language.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Použití více jazyků v jednom odstavci**

[Paragraph](https://reference.aspose.com/slides/cs/python-java/aspose.slides/paragraph/) obsahuje kolekci částí textu. Pro každý jazyk vytvořte samostatný [Portion](https://reference.aspose.com/slides/cs/python-java/aspose.slides/portion/) a nezávisle nastavte jeho [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/cs/python-java/aspose.slides/baseportionformat/#setLanguageId).

Tento příklad vytvoří jeden odstavec s částmi v angličtině a francouzštině:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpade.startJVM()

from asposeslides.api import Portion, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 80)
    paragraph = shape.getTextFrame().getParagraphs().get_Item(0)
    paragraph.getPortions().clear()

    english_portion = Portion("Welcome")
    english_portion.getPortionFormat().setLanguageId("en-US")
    paragraph.getPortions().add(english_portion)

    french_portion = Portion(" — Bienvenue")
    french_portion.getPortionFormat().setLanguageId("fr-FR")
    paragraph.getPortions().add(french_portion)

    presentation.save("multilingual_text.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Povolení nebo potlačení kontroly pravopisu pro jednotlivé části**

[PortionFormat](https://reference.aspose.com/slides/cs/python-java/aspose.slides/portionformat/) dědí společné vlastnosti textu definované v [BasePortionFormat](https://reference.aspose.com/slides/cs/python-java/aspose.slides/baseportionformat/). Přístup k formátu části získáte pomocí [Portion.getPortionFormat](https://reference.aspose.com/slides/cs/python-java/aspose.slides/portion/#getPortionFormat) a použijte [BasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/cs/python-java/aspose.slides/baseportionformat/#setSpellCheck) k ovládání, zda prezentační aplikace může pro tuto část kontrolovat pravopis. Výchozí hodnota je `False`: `True` povolí kontrolu pravopisu, zatímco `False` ji potlačí.

Nastavení se vztahuje na jednotlivé části textu. Různé části ve stejném odstavci tak mohou mít odlišné hodnoty. [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/cs/python-java/aspose.slides/baseportionformat/#setLanguageId) a [setSpellCheck](https://reference.aspose.com/slides/cs/python-java/aspose.slides/baseportionformat/#setSpellCheck) mají doplňující si účely: [setLanguageId](https://reference.aspose.com/slides/cs/python-java/aspose.slides/baseportionformat/#setLanguageId) určuje jazyk korektury, zatímco [setSpellCheck](https://reference.aspose.com/slides/cs/python-java/aspose.slides/baseportionformat/#setSpellCheck) stanovuje, zda je pro část povolena kontrola pravopisu.

[BasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/cs/python-java/aspose.slides/baseportionformat/#setProofDisabled) také řídí korekturu, ale představuje širší stav „neprovádět korekturu“ jako [NullableBool](https://reference.aspose.com/slides/cs/python-java/aspose.slides/nullablebool/). Použijte [setSpellCheck](https://reference.aspose.com/slides/cs/python-java/aspose.slides/baseportionformat/#setSpellCheck), pokud potřebujete přímý Boolean přepínač konkrétně pro kontrolu pravopisu. Použijte [setProofDisabled](https://reference.aspose.com/slides/cs/python-java/aspose.slides/baseportionformat/#setProofDisabled), pokud potřebujete zachovat nebo explicitně řídit metadata prezentace o neprovádění korektury, včetně jejího stavu [NullableBool.NotDefined](https://reference.aspose.com/slides/cs/python-java/aspose.slides/nullablebool/#NotDefined). Pokud nastavíte obě vlastnosti, udržujte jejich hodnoty konzistentní; nekombinujte [setSpellCheck](https://reference.aspose.com/slides/cs/python-java/aspose.slides/baseportionformat/#setSpellCheck) nastavený na `True` s [setProofDisabled](https://reference.aspose.com/slides/cs/python-java/aspose.slides/baseportionformat/#setProofDisabled) nastaveným na stav [NullableBool.True](https://reference.aspose.com/slides/cs/python-java/aspose.slides/nullablebool/#True).

Tyto vlastnosti konfigrují metadata korektury používaná aplikacemi PowerPoint a dalšími prezentačními programy. Aspose.Slides je nepoužívá k provádění kontrol pravopisu založených na slovníku ani k vracení seznamu chybně napsaných slov.

Následující kompletní příklad vytvoří vstupní prezentaci, načte ji, přiřadí různé nastavení kontroly pravopisu a jazyky korektury dvěma částem ve stejném odstavci, výsledek uloží, znovu otevře a ověří uložené hodnoty:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Portion, Presentation, SaveFormat, ShapeType

input_file = "spell_check_input.pptx"
output_file = "spell_check_settings.pptx"

source_presentation = Presentation()
try:
    source_slide = source_presentation.getSlides().get_Item(0)
    source_shape = source_slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 80)
    source_paragraph = source_shape.getTextFrame().getParagraphs().get_Item(0)
    source_paragraph.getPortions().clear()

    source_english_portion = Portion("Check this text. ")
    source_english_portion.getPortionFormat().setLanguageId("en-US")
    source_paragraph.getPortions().add(source_english_portion)

    source_french_portion = Portion("Ignorer ce code : ZX-81.")
    source_french_portion.getPortionFormat().setLanguageId("fr-FR")
    source_paragraph.getPortions().add(source_french_portion)

    source_presentation.save(input_file, SaveFormat.Pptx)
finally:
    source_presentation.dispose()

presentation = Presentation(input_file)
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    portions = shape.getTextFrame().getParagraphs().get_Item(0).getPortions()

    checked_portion = portions.get_Item(0)
    checked_portion.getPortionFormat().setLanguageId("en-US")
    checked_portion.getPortionFormat().setSpellCheck(True)

    suppressed_portion = portions.get_Item(1)
    suppressed_portion.getPortionFormat().setLanguageId("fr-FR")
    suppressed_portion.getPortionFormat().setSpellCheck(False)

    presentation.save(output_file, SaveFormat.Pptx)
finally:
    presentation.dispose()

reopened_presentation = Presentation(output_file)
try:
    reopened_shape = reopened_presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    stored_portions = reopened_shape.getTextFrame().getParagraphs().get_Item(0).getPortions()

    first_portion_stored = stored_portions.getCount() == 2 and stored_portions.get_Item(0).getPortionFormat().getLanguageId() == "en-US" and stored_portions.get_Item(0).getPortionFormat().getSpellCheck()

    second_portion_stored = stored_portions.getCount() == 2 and stored_portions.get_Item(1).getPortionFormat().getLanguageId() == "fr-FR" and not stored_portions.get_Item(1).getPortionFormat().getSpellCheck()

    if first_portion_stored and second_portion_stored:
        print("The proofing settings were stored correctly.")
    else:
        print("The proofing settings could not be verified.")

finally:
    reopened_presentation.dispose()
```

[Presentation.joinPortionsWithSameFormatting](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/#joinPortionsWithSameFormatting) spojuje přilehlé části, které mají stejné formátování. Rozdíl pouze v [BasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/cs/python-java/aspose.slides/baseportionformat/#setSpellCheck) neudrží takové části oddělené; po sloučení si výsledná část zachová hodnotu [BasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/cs/python-java/aspose.slides/baseportionformat/#setSpellCheck) první části. Pokud části potřebují odlišná nastavení kontroly pravopisu, zavolejte [joinPortionsWithSameFormatting](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/#joinPortionsWithSameFormatting) před přiřazením těchto nastavení, nebo prozkoumejte hranice výsledných částí a po sloučení nastavení znovu aplikujte. Části s různými hodnotami [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/cs/python-java/aspose.slides/baseportionformat/#setLanguageId) zůstávají oddělené, protože se liší formátování jazykové korektury.

## **Často kladené otázky**

**Překládá ID jazyka text?**

Ne. [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/cs/python-java/aspose.slides/baseportionformat/#setLanguageId) ukládá metadata korektury pro pravopis a gramatiku; nemění obsah textu. Přeložte text samostatně a poté nastavte příslušný identifikátor jazyka pro každou přeloženou část.

**Řídí jazyk korektury písma, dělení slov nebo zalamování řádků?**

Ne. Identifikátor jazyka slouží jen pro korekturu. Vykreslování a rozvržení textu závisí převážně na dostupných [fonts](/slides/cs/python-java/powerpoint-fonts/), psacím systému a nastaveních textového rámce. Pro spolehlivé vykreslení poskytněte požadovaná písma, nakonfigurujte [font substitution](/slides/cs/python-java/font-substitution/) nebo [embed fonts](/slides/cs/python-java/embedded-font/) v prezentaci.

**Může jeden odstavec používat několik jazyků korektury?**

Ano. Přiřaďte každý jazyk k samostatné části, jak je ukázáno v příkladu vícejazyčného odstavce.

**Mám použít [setDefaultTextLanguage](https://reference.aspose.com/slides/cs/python-java/aspose.slides/loadoptions/#setDefaultTextLanguage) nebo [setLanguageId](https://reference.aspose.com/slides/cs/python-java/aspose.slides/baseportionformat/#setLanguageId)?**

Použijte [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/cs/python-java/aspose.slides/loadoptions/#setDefaultTextLanguage), pokud chcete výchozí jazyk pro nově vytvořený text. Použijte [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/cs/python-java/aspose.slides/baseportionformat/#setLanguageId), pokud konkrétní část potřebuje explicitní jazyk korektury nebo když odstavec obsahuje více jazyků.