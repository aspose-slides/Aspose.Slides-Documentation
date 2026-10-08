---
title: "Konfigurace náhrady písem v prezentacích pomocí Pythonu"
linktitle: "Náhrada písem"
type: docs
weight: 70
url: /cs/python-net/font-substitution/
keywords:
- "písmo"
- "náhradní písmo"
- "náhrada písma"
- "nahrazení písma"
- "nahrazení písma"
- "pravidlo náhrady"
- "pravidlo nahrazení"
- "PowerPoint"
- "OpenDocument"
- "prezentace"
- "Python"
- "Aspose.Slides"
description: "Konfigurujte pravidla náhrady písem a prohlédněte náhradní písma v Aspose.Slides pro Python pomocí .NET při vykreslování nebo převodu prezentací PowerPoint a OpenDocument."
---
## **Přehled**

Náhrada písma umožňuje Aspose.Slides použít dostupné písmo místo písma, ke kterému nelze přistupovat při vykreslování nebo převodu prezentace. Náhrada ovlivňuje vykreslený výstup; nemění písmo přiřazené k obsahu prezentace.

Můžete definovat písmo, které se použije, když je konkrétní písmo nedostupné, a můžete si prohlédnout náhrady, které Aspose.Slides během vykreslování provede. To pomáhá udržet výstup konzistentní napříč prostředími s různě nainstalovanými písmy.

Pokud je písmo dostupné, ale nemá dedikovaný tučný řez, viz [Zpracování písem bez dedikovaného tučného řezu](/slides/cs/python-net/convert-powerpoint-to-pdf/#handle-fonts-without-a-dedicated-bold-typeface). Tato sekce vysvětluje, jak během exportu PDF rasterizovat ovlivněný text a jaké jsou důsledky pro výběr textu, vyhledávání a škálování.

## **Získání náhrad písem**

Použijte metodu [FontsManager.get_substitutions](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/get_substitutions/) k určení, která písma budou nahrazena při vykreslení prezentace. Metoda vrací objekty [FontSubstitutionInfo](https://reference.aspose.com/slides/python-net/aspose.slides/fontsubstitutioninfo/), které identifikují původní a nahrazené názvy písem.

Následující příklad v Pythonu vypisuje všechny náhrady písem pro prezentaci:

```python
import aspose.slides as slides

with slides.Presentation("Presentation.pptx") as presentation:
    for substitution in presentation.fonts_manager.get_substitutions():
        print(f"{substitution.original_font_name} -> {substitution.substituted_font_name}")
```

## **Získání náhrad písem pro vybrané snímky**

Použijte [FontsManager.get_substitutions](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/get_substitutions/) se seznamem indexů snímků k prohlédnutí pouze náhrad potřebných k vykreslení konkrétních snímků. To je užitečné, když vykreslujete nebo exportujete část prezentace, provádíte postupnou kontrolu velké prezentace, hledáte snímky, které závisí na nedostupných písmech, připravujete minimální balíček písem pro server nebo kontejner, nebo diagnostikujete rozdíly ve vykreslování bez zpracování nesouvisejících snímků.

Seznam obsahuje indexy snímků začínající od jedné: `1` označuje první snímek. Naproti tomu je kolekce [Presentation.slides](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/slides/) indexována od nuly, takže stejný snímek je přístupný jako `presentation.slides[0]`. Mějte tento rozdíl na paměti při sestavování seznamu, abyste se vyhnuli chybám o jeden.

Metodu zavolejte přes vlastnost [Presentation.fonts_manager](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/fonts_manager/). Vrátí pouze náhrady určené během vykreslování vybraných snímků. Každý výsledek je objekt [FontSubstitutionInfo](https://reference.aspose.com/slides/python-net/aspose.slides/fontsubstitutioninfo/), který obsahuje původní a nahrazené názvy písem. Výsledek odráží aktuální prostředí písem, nakonfigurovaná pravidla záložních písem, pravidla náhrad uložená v [IFontSubstRuleCollection](https://reference.aspose.com/slides/python-net/aspose.slides/ifontsubstrulecollection/), a [externě načtená písma](/slides/cs/python-net/custom-font/).

Stejná náhrada může být vyžadována více než jedním vybraným snímkem. Při tvorbě inventáře písem nebo preflight zprávy odstraňte duplicitní výsledky. Následující příklad vypisuje každou vrácenou náhradu a poté vytváří seřazený seznam unikátních mapování písem:

```python
import aspose.slides as slides

with slides.Presentation("Presentation.pptx") as presentation:
    selected_slides = [1, 3, 5]
    substitutions = list(presentation.fonts_manager.get_substitutions(selected_slides))

    print("Substitutions for the selected slides:")
    for substitution in substitutions:
        print(f"{substitution.original_font_name} -> {substitution.substituted_font_name}")

    preflight_entries = [f"{substitution.original_font_name} -> {substitution.substituted_font_name}" for substitution in substitutions]
    unique_preflight_entries = {entry.casefold(): entry for entry in preflight_entries}
    sorted_preflight_entries = sorted(unique_preflight_entries.values(), key=str.casefold)

    print("Deduplicated font preflight report:")
    for entry in sorted_preflight_entries:
        print(entry)
```

Třída [FontsManager](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/) poskytuje obě formy metody. Vyberte jednu podle rozsahu vykreslovací operace:

| Volání metody | Použít kdy |
|---|---|
| [get_substitutions](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/get_substitutions/) with no arguments | Potřebujete náhrady pro celou prezentaci. |
| [get_substitutions](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/get_substitutions/) with a list of slide indexes | Potřebujete náhrady pro vybraný rozsah, postupnou kontrolu nebo částečný export. |

## **Nastavení pravidel náhrady písem**

Pro určení písma, které by mělo Aspose.Slides použít, když je zdrojové písmo nedostupné:

1. Načtěte prezentaci.
2. Vytvořte definice písem pro zdrojové a náhradní písmo.
3. Vytvořte [FontSubstRule](https://reference.aspose.com/slides/python-net/aspose.slides/fontsubstrule/) s podmínkou [WHEN_INACCESSIBLE](https://reference.aspose.com/slides/python-net/aspose.slides/fontsubstcondition/).
4. Přidejte pravidlo do [FontSubstRuleCollection](https://reference.aspose.com/slides/python-net/aspose.slides/fontsubstrulecollection/).
5. Přiřaďte kolekci k vlastnosti [FontsManager.font_subst_rule_list](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/font_subst_rule_list/).
6. Vykreslete nebo převedete prezentaci.

Následující příklad v Pythonu nahradí `Arial` za `SomeRareFont`, když je `SomeRareFont` nedostupné, a poté vykreslí první snímek k ověření výsledku. Náhradní písmo musí být pro Aspose.Slides dostupné.

```python
import aspose.slides as slides

with slides.Presentation("Fonts.pptx") as presentation:
    source_font = slides.FontData("SomeRareFont")
    substitute_font = slides.FontData("Arial")
    substitution_rule = slides.FontSubstRule(source_font, substitute_font, slides.FontSubstCondition.WHEN_INACCESSIBLE)

    substitution_rules = slides.FontSubstRuleCollection()
    substitution_rules.add(substitution_rule)
    presentation.fonts_manager.font_subst_rule_list = substitution_rules

    with presentation.slides[0].get_image(1, 1) as image:
        image.save("slide.jpg", slides.ImageFormat.JPEG)
```

{{% alert color="info" title="Note" %}}
Pro bezpodmínečnou změnu písem použitých v celé prezentaci viz [Nahrazení písem](/slides/cs/python-net/font-replacement/).
{{% /alert %}}

## **Omezení pro písma matematických rovnic**

Pravidla náhrady písem jsou součástí standardního procesu výběru písma používaného během vykreslování a převodu. Fungují pro běžný text, když Aspose.Slides dokáže nahradit nedostupné písmo dostupným písmem určeným pravidlem.

Rovnice Office Math mají dodatečný požadavek. Pokud rovnice používá **Cambria Math**, Aspose.Slides může potřebovat právě toto písmo k výpočtu a vykreslení rozvržení rovnice. Pravidlo, které nahrazuje jiným matematickým písmem, například **STIX Two Math**, nemůže nahradit **Cambria Math** pro tento účel a vykreslování může stále hlásit, že **Cambria Math** je vyžadováno.

Pro vykreslení nebo převod takové prezentace zpřístupněte **Cambria Math** pro Aspose.Slides. Nainstalujte jej v operačním systému nebo jej načtěte jako [externí písmo](/slides/cs/python-net/custom-font/).

Toto omezení se vztahuje na rozvržení rovnic. Výše popsaná pravidla náhrady se stále vztahují na běžný text prezentace.

## **Často kladené otázky**

**Jaký je rozdíl mezi nahrazením písem a náhradou písem?**

[Nahrazení písem](/slides/cs/python-net/font-replacement/) úmyslně mění jedno písmo na jiné v celé prezentaci. Náhrada písem vybírá písmo pro vykreslený výstup, když je splněna nakonfigurovaná podmínka, například když je původní písmo nedostupné.

**Kdy se pravidla náhrady používají?**

Pravidla se podílejí na [sekvenci výběru písma](/slides/cs/python-net/font-selection-sequence/) během vykreslování a převodu. S podmínkou `WHEN_INACCESSIBLE` je pravidlo použito pouze tehdy, když Aspose.Slides nemůže získat přístup ke zdrojovému písmu.

**Co se stane, když písmo chybí a není nakonfigurováno žádné pravidlo náhrady?**

Aspose.Slides vybere nejbližší dostupné písmo podle svého procesu výběru písma. Výsledek závisí na písmenech dostupných v běhovém prostředí.

**Mohu načíst externí písma, aby se předešlo náhradě?**

Ano. Můžete [načíst externí písma](/slides/cs/python-net/custom-font/), aby je Aspose.Slides mohl použít během vykreslování a převodu.

**Distribuuje Aspose písma s knihovnou?**

Ne. Za poskytování písem a dodržování jejich licencí jste zodpovědní.

**Mohou se výsledky náhrady lišit mezi Windows, Linux a macOS?**

Ano. Instalovaná písma a umístění pro vyhledávání písem se liší podle operačního systému, takže písmo dostupné na jednom počítači může vyžadovat náhradu na jiném.

**Jak zajistit konzistentní výběr písma při dávkových převodech?**

Používejte stejné soubory písem a jejich verze na každém počítači nebo kontejneru, [načtěte požadovaná externí písma](/slides/cs/python-net/custom-font/) a [vkládejte písma](/slides/cs/python-net/embedded-font/) pokud licence umožňuje. Můžete také zavolat [FontsManager.get_substitutions](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/get_substitutions/) před exportem, abyste identifikovali nečekané náhrady.