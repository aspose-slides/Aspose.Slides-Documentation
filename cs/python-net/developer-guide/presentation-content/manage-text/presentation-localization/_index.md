---
title: Automatizace lokalizace prezentace pomocí Pythonu
linktitle: Lokalizace prezentace
type: docs
weight: 100
url: /cs/python-net/presentation-localization/
keywords:
- změna jazyka
- kontrola pravopisu
- potlačení kontroly pravopisu
- jazyk korektury
- ID jazyka
- vícejazyčný text
- PowerPoint
- prezentace
- Python
- Aspose.Slides
description: "Nastavte jazyky korektury pro text v prezentacích PowerPoint a OpenDocument v Pythonu s Aspose.Slides, včetně výchozích hodnot a vícejazyčných odstavců."
---
## **Přehled**

Aspose.Slides pro Python přes .NET vám umožňuje konfigurovat metadata korektury pro jednotlivé textové úseky. Použijte [BasePortionFormat.language_id](https://reference.aspose.com/slides/cs/python-net/aspose.slides/baseportionformat/language_id/) k určení jazyka korektury, [BasePortionFormat.spell_check](https://reference.aspose.com/slides/cs/python-net/aspose.slides/baseportionformat/spell_check/) k povolení nebo potlačení kontrol pravopisu a [BasePortionFormat.proof_disabled](https://reference.aspose.com/slides/cs/python-net/aspose.slides/baseportionformat/proof_disabled/) k řízení širšího stavu „neprovádět korekturu“. Protože jsou tato nastavení aplikována na úroveň úseku, jeden odstavec může obsahovat více jazyků a různá pravidla korektury.

Tento článek vysvětluje, jak přiřadit jazyk konkrétnímu textu, nastavit výchozí jazyk pro nový text pomocí [LoadOptions.default_text_language](https://reference.aspose.com/slides/cs/python-net/aspose.slides/loadoptions/default_text_language/), vytvořit vícejazyčné odstavce, vybrat mezi `spell_check` a `proof_disabled` a zachovat požadovaná nastavení při použití [Presentation.join_portions_with_same_formatting](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/join_portions_with_same_formatting/). Tyto vlastnosti ukládají metadata pro prezentační aplikace; nepřekládají text, neprovádějí kontrolu pravopisu založenou na slovníku ani nevrací slova s pravopisnými chybami.

## **Nastavte jazyk korektury pro text**

Vytvořte nebo načtěte [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/), získáte požadovaný úsek textu přes [Portion.portion_format](https://reference.aspose.com/slides/cs/python-net/aspose.slides/portion/portion_format/) a přiřadíte jeho identifikátor jazyka. Následující příklad vytvoří tvar, nastaví britskou angličtinu jako jazyk korektury a výsledek uloží pomocí [Presentation.save](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/save/):

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 320, 80)
    shape.text_frame.text = "Set the proofing language for this text."

    portion = shape.text_frame.paragraphs[0].portions[0]
    portion.portion_format.language_id = "en-GB"

    presentation.save("proofing_language.pptx", slides.export.SaveFormat.PPTX)
```

## **Nastavte výchozí jazyk pro nový text**

Použijte [LoadOptions.default_text_language](https://reference.aspose.com/slides/cs/python-net/aspose.slides/loadoptions/default_text_language/) k určení jazyka korektury, který Aspose.Slides přiřadí nově vytvořenému textu. Toto nastavení je užitečné, když většina nebo celý nový text v prezentaci používá stejný jazyk. Nemění metadata jazyka textu, který již má explicitně nastavený jazyk.

Následující příklad vytvoří prezentaci, jejíž nový text používá německá pravidla korektury:

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.default_text_language = "de-DE"

with slides.Presentation(load_options) as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 320, 80)
    shape.text_frame.text = "Willkommen zur Präsentation"

    presentation.save("default_text_language.pptx", slides.export.SaveFormat.PPTX)
```

## **Použijte více jazyků v jednom odstavci**

[Paragraph](https://reference.aspose.com/slides/cs/python-net/aspose.slides/paragraph/) obsahuje kolekci textových úseků. Vytvořte samostatný [Portion](https://reference.aspose.com/slides/cs/python-net/aspose.slides/portion/) pro každý jazyk a nezávisle nastavte jeho `language_id`.

Tento příklad vytvoří jeden odstavec s úseky v angličtině a francouzštině:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 420, 80)
    paragraph = shape.text_frame.paragraphs[0]
    paragraph.portions.clear()

    english_portion = slides.Portion("Welcome")
    english_portion.portion_format.language_id = "en-US"
    paragraph.portions.add(english_portion)

    french_portion = slides.Portion(" — Bienvenue")
    french_portion.portion_format.language_id = "fr-FR"
    paragraph.portions.add(french_portion)

    presentation.save("multilingual_text.pptx", slides.export.SaveFormat.PPTX)
```

## **Povolte nebo potlačte kontrolu pravopisu pro jednotlivé úseky**

[PortionFormat](https://reference.aspose.com/slides/cs/python-net/aspose.slides/portionformat/) dědí společné textové vlastnosti definované v [BasePortionFormat](https://reference.aspose.com/slides/cs/python-net/aspose.slides/baseportionformat/). Přistupte k formátu úseku přes [Portion.portion_format](https://reference.aspose.com/slides/cs/python-net/aspose.slides/portion/portion_format/) a nastavte [BasePortionFormat.spell_check](https://reference.aspose.com/slides/cs/python-net/aspose.slides/baseportionformat/spell_check/) k určení, zda prezentační aplikace může kontrolovat pravopis pro tento úsek. Výchozí hodnota je `False`: `True` povolí kontrolu pravopisu, zatímco `False` ji potlačí.

Nastavení se vztahuje na jednotlivé textové úseky. Různé úseky ve stejném odstavci tak mohou mít odlišné hodnoty. [BasePortionFormat.language_id](https://reference.aspose.com/slides/cs/python-net/aspose.slides/baseportionformat/language_id/) a `spell_check` slouží doplňujícím způsobem: `language_id` určuje jazyk korektury, zatímco `spell_check` určuje, zda je kontrola pravopisu pro úsek povolena.

[BasePortionFormat.proof_disabled](https://reference.aspose.com/slides/cs/python-net/aspose.slides/baseportionformat/proof_disabled/) také řídí korekturu, ale představuje širší stav „neprovádět korekturu“ jako [NullableBool](https://reference.aspose.com/slides/cs/python-net/aspose.slides/nullablebool/). Používejte `spell_check`, když potřebujete přímý logický přepínač specificky pro kontrolu pravopisu. Používejte `proof_disabled`, když chcete zachovat nebo výslovně řídit metadata o neprovádění korektury prezentace, včetně jejího stavu `NOT_DEFINED`. Pokud nastavíte obě vlastnosti, udržujte jejich hodnoty konzistentní; nekombinujte `spell_check = True` s `proof_disabled = slides.NullableBool.TRUE`.

Tyto vlastnosti konfigurují metadata korektury používaná PowerPointem a dalšími prezentačními aplikacemi. Aspose.Slides je nepoužívá k provádění slovníkových kontrol pravopisu ani k vracení seznamu pravopisně chybujících slov.

Následující kompletní příklad vytvoří vstupní prezentaci, načte ji, přiřadí různá nastavení kontroly pravopisu a jazyky korektury dvěma úsekům ve stejném odstavci, uloží výsledek, znovu jej otevře a ověří uložené hodnoty:

```python
import aspose.slides as slides

input_file = "spell_check_input.pptx"
output_file = "spell_check_settings.pptx"

with slides.Presentation() as source_presentation:
    source_slide = source_presentation.slides[0]
    source_shape = source_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 420, 80)
    source_paragraph = source_shape.text_frame.paragraphs[0]
    source_paragraph.portions.clear()

    source_english_portion = slides.Portion("Check this text. ")
    source_english_portion.portion_format.language_id = "en-US"
    source_paragraph.portions.add(source_english_portion)

    source_french_portion = slides.Portion("Ignorer ce code : ZX-81.")
    source_french_portion.portion_format.language_id = "fr-FR"
    source_paragraph.portions.add(source_french_portion)

    source_presentation.save(input_file, slides.export.SaveFormat.PPTX)

with slides.Presentation(input_file) as presentation:
    shape = presentation.slides[0].shapes[0]
    portions = shape.text_frame.paragraphs[0].portions

    checked_portion = portions[0]
    checked_portion.portion_format.language_id = "en-US"
    checked_portion.portion_format.spell_check = True

    suppressed_portion = portions[1]
    suppressed_portion.portion_format.language_id = "fr-FR"
    suppressed_portion.portion_format.spell_check = False

    presentation.save(output_file, slides.export.SaveFormat.PPTX)

with slides.Presentation(output_file) as reopened_presentation:
    reopened_shape = reopened_presentation.slides[0].shapes[0]
    stored_portions = reopened_shape.text_frame.paragraphs[0].portions

    has_two_portions = stored_portions.count == 2

    first_portion_stored = (
        has_two_portions 
        and stored_portions[0].portion_format.language_id == "en-US" 
        and stored_portions[0].portion_format.spell_check
    )

    second_portion_stored = (
        has_two_portions
        and stored_portions[1].portion_format.language_id == "fr-FR" 
        and not stored_portions[1].portion_format.spell_check
    )

    if first_portion_stored and second_portion_stored:
        print("The proofing settings were stored correctly.")
    else:
        print("The proofing settings could not be verified.")
```

[Presentation.join_portions_with_same_formatting](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/join_portions_with_same_formatting/) spojuje sousední úseky, které mají stejné formátování. Rozdíl pouze v `spell_check` neudrží úseky oddělené; po jejich sloučení nový úsek zachová hodnotu `spell_check` prvního úseku. Pokud úseky potřebují odlišná nastavení kontroly pravopisu, zavolejte `join_portions_with_same_formatting` před přiřazením těchto nastavení nebo po sloučení zkontrolujte hranice úseků a nastavení znovu aplikujte. Úseky s různými hodnotami `language_id` zůstávají oddělené, protože jejich formátování korektury jazyka se liší.

## **FAQ**

**Překládá ID jazyka text?**

Ne. [BasePortionFormat.language_id](https://reference.aspose.com/slides/cs/python-net/aspose.slides/baseportionformat/language_id/) ukládá metadata korektury pro pravopis a gramatiku; nemění obsah textu. Přeložte text zvlášť a poté nastavte odpovídající identifikátor jazyka pro každý přeložený úsek.

**Řídí jazyk korektury písma, dělení slov nebo zalomení řádků?**

Ne. Identifikátor jazyka slouží jen ke korektuře. Vykreslování a rozvržení textu především závisí na dostupných [fonts](/slides/cs/python-net/powerpoint-fonts/), písmovém systému a nastaveních textového rámce. Pro spolehlivé vykreslení poskytněte požadovaná písma, nakonfigurujte [font substitution](/slides/cs/python-net/font-substitution/) nebo [embed fonts](/slides/cs/python-net/embedded-font/) v prezentaci.

**Může jeden odstavec používat několik jazyků korektury?**

Ano. Přiřaďte každý jazyk samostatnému úseku, jak ukazuje příklad vícejazyčného odstavce.

**Mám používat `default_text_language` nebo `language_id`?**

Použijte [LoadOptions.default_text_language](https://reference.aspose.com/slides/cs/python-net/aspose.slides/loadoptions/default_text_language/), když chcete výchozí jazyk pro nově vytvořený text. Použijte [BasePortionFormat.language_id](https://reference.aspose.com/slides/cs/python-net/aspose.slides/baseportionformat/language_id/), když konkrétní úsek potřebuje explicitní jazyk korektury nebo když odstavec obsahuje více jazyků.