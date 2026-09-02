---
title: Konfigurace substituce písma v prezentacích s Pythonem
linktitle: Substituce písma
type: docs
weight: 70
url: /cs/python-net/font-substitution/
keywords:
- písmo
- náhradní písmo
- substituce písma
- nahrazení písma
- výměna písma
- pravidlo substituce
- pravidlo nahrazení
- PowerPoint
- OpenDocument
- prezentace
- Python
- Aspose.Slides
description: "Konfigurujte pravidla substituce písma a prohlížejte substituovaná písma v Aspose.Slides pro Python přes .NET při vykreslování nebo konverzi prezentací PowerPoint a OpenDocument."
---
## **Přehled**

Substituce písem umožňuje Aspose.Slides použít dostupné písmo místo písma, které není přístupné při vykreslování nebo konverzi prezentace. Substituce ovlivňuje výstup vykresleného obrazu; nemění písmo přiřazené obsahu prezentace.

Můžete definovat písmo, které se má použít, když je konkrétní písmo nedostupné, a můžete prozkoumat substituce, které Aspose.Slides během vykreslování provede. To pomáhá udržet výstup konzistentní napříč prostředími s různě nainstalovanými písmy.

## **Získání substitucí písem**

Použijte [FontsManager.get_substitutions](https://reference.aspose.com/slides/cs/python-net/aspose.slides/fontsmanager/get_substitutions/) metodu k určení, která písma budou substituována při vykreslení prezentace. Metoda vrací objekty [FontSubstitutionInfo](https://reference.aspose.com/slides/cs/python-net/aspose.slides/fontsubstitutioninfo/), které identifikují původní a substituované názvy písem.

Následující příklad v jazyce Python vypisuje všechny substituce písem pro prezentaci:

```python
import aspose.slides as slides

with slides.Presentation("Presentation.pptx") as presentation:
    for substitution in presentation.fonts_manager.get_substitutions():
        print(f"{substitution.original_font_name} -> {substitution.substituted_font_name}")
```

## **Získání substitucí písem pro vybrané snímky**

Použijte [FontsManager.get_substitutions](https://reference.aspose.com/slides/cs/python-net/aspose.slides/fontsmanager/get_substitutions/) se seznamem indexů snímků, abyste zkontrolovali pouze substituce potřebné pro vykreslení konkrétních snímků. To je užitečné při vykreslování nebo exportu části prezentace, inkrementální kontrole velké prezentace, vyhledávání snímků závislých na nedostupných písmech, přípravě minimálního balíčku písem pro server nebo kontejner, nebo diagnostice rozdílů ve vykreslování bez zpracování nesouvisejících snímků.

Seznam obsahuje jednorozměrné indexy snímků: `1` identifikuje první snímek. Naproti tomu kolekce [Presentation.slides](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/slides/cs/) je indexována od nuly, takže stejný snímek je přístupný jako `presentation.slides[0]`. Pamatujte na tento rozdíl při sestavování seznamu, abyste se vyhnuli chybám o jeden.

Volání metody provádějte přes vlastnost [Presentation.fonts_manager](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/fonts_manager/). Vrací pouze substituce určené během vykreslování vybraných snímků. Každý výsledek je objekt [FontSubstitutionInfo](https://reference.aspose.com/slides/cs/python-net/aspose.slides/fontsubstitutioninfo/), který obsahuje původní a substituovaný název písma. Výsledek odráží aktuální prostředí písem, nakonfigurovaná pravidla záložních písem, pravidla substituce uložená v [IFontSubstRuleCollection](https://reference.aspose.com/slides/cs/python-net/aspose.slides/ifontsubstrulecollection/) a [externě načtená písma](/slides/cs/python-net/custom-font/).

Stejná substituce může být požadována více než jedním vybraným snímkem. Při tvorbě inventáře písem nebo preflight zprávy deduplikujte výsledky. Následující příklad vypisuje každou vrácenou substituci a poté vytváří setříděný seznam unikátních mapování písem:

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

Třída [FontsManager](https://reference.aspose.com/slides/cs/python-net/aspose.slides/fontsmanager/) poskytuje obě formy metody. Vyberte si podle rozsahu operace vykreslování:

| Volání metody | Použijte, když |
|---|---|
| [get_substitutions](https://reference.aspose.com/slides/cs/python-net/aspose.slides/fontsmanager/get_substitutions/) bez argumentů | Potřebujete substituce pro celou prezentaci. |
| [get_substitutions](https://reference.aspose.com/slides/cs/python-net/aspose.slides/fontsmanager/get_substitutions/) se seznamem indexů snímků | Potřebujete substituce pro vybraný rozsah, inkrementální kontrolu nebo částečný export. |

## **Nastavení pravidel substituce písem**

Pro specifikaci písma, které má Aspose.Slides použít, když je zdrojové písmo nedostupné:

1. Načtěte prezentaci.  
2. Vytvořte definice písem pro zdrojové a náhradní písmo.  
3. Vytvořte [FontSubstRule](https://reference.aspose.com/slides/cs/python-net/aspose.slides/fontsubstrule/) s podmínkou [WHEN_INACCESSIBLE](https://reference.aspose.com/slides/cs/python-net/aspose.slides/fontsubstcondition/).  
4. Přidejte pravidlo do [FontSubstRuleCollection](https://reference.aspose.com/slides/cs/python-net/aspose.slides/fontsubstrulecollection/).  
5. Přiřaďte kolekci k vlastnosti [FontsManager.font_subst_rule_list](https://reference.aspose.com/slides/cs/python-net/aspose.slides/fontsmanager/font_subst_rule_list/).  
6. Vykreslete nebo konvertujte prezentaci.

Následující příklad v jazyce Python substituuje `Arial` za `SomeRareFont`, když je `SomeRareFont` nedostupné, a poté vykreslí první snímek pro ověření výsledku. Náhradní písmo musí být dostupné pro Aspose.Slides.

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

{{% alert color="info" title="Poznámka" %}}
Pro necondiční změnu písem použitých v celé prezentaci, viz [Nahrazení písem](/slides/cs/python-net/font-replacement/).
{{% /alert %}}

## **Omezení pro písma matematických rovnic**

Pravidla substituce písem jsou součástí standardního procesu výběru písem používaného během vykreslování a konverze. Fungují pro běžný text, když Aspose.Slides může nahradit nedostupné písmo dostupným písmem určeným pravidlem.

Matematické rovnice Office Math mají další požadavek. Pokud rovnice používá **Cambria Math**, Aspose.Slides může potřebovat právě toto písmo k výpočtu a vykreslení rozvržení rovnice. Pravidlo, které substituuje jiné matematické písmo, například **STIX Two Math**, nemůže nahradit **Cambria Math** pro tento účel, a při vykreslování se může nadále uvádět, že **Cambria Math** je vyžadováno.

Pro vykreslení nebo konverzi takové prezentace zajistěte, aby bylo **Cambria Math** dostupné pro Aspose.Slides. Nainstalujte jej v operačním systému nebo jej načtěte jako [externí písmo](/slides/cs/python-net/custom-font/).

Toto omezení se vztahuje na rozvržení rovnic. Pravidla substituce popsaná výše se i nadále vztahují na běžný text prezentace.

## **Často kladené otázky**

**Jaký je rozdíl mezi nahrazením písma a substitucí písma?**

[Font replacement](/slides/cs/python-net/font-replacement/) úmyslně mění jedno písmo na jiné v celé prezentaci. Substituce písma vybírá písmo pro vykreslený výstup, když je splněna nakonfigurovaná podmínka, například když je původní písmo nedostupné.

**Kdy se pravidla substituce aplikují?**

Pravidla se podílejí na [sekvenci výběru písem](/slides/cs/python-net/font-selection-sequence/) během vykreslování a konverze. S podmínkou `WHEN_INACCESSIBLE` se pravidlo používá pouze tehdy, když Aspose.Slides nemůže získat přístup ke zdrojovému písmu.

**Co se stane, když písmo chybí a není nakonfigurováno žádné pravidlo substituce?**

Aspose.Slides vybere nejbližší dostupné písmo podle svého procesu výběru písem. Výsledek závisí na písmech dostupných v běhovém prostředí.

**Mohu načíst externí písma, abych se vyhnul substituci?**

Ano. Můžete [načíst externí písma](/slides/cs/python-net/custom-font/), aby je Aspose.Slides mohl použít během vykreslování a konverze.

**Distribuuje Aspose písma spolu s knihovnou?**

Ne. Za poskytování písem a dodržování jejich licencí jste zodpovědní vy.

**Mohou se výsledky substituce lišit mezi Windows, Linux a macOS?**

Ano. Instalovaná písma a umístění vyhledávání písem se liší podle operačního systému, takže písmo dostupné na jednom počítači může vyžadovat substituci na jiném.

**Jak zajistit konzistentní výběr písem při hromadných konverzích?**

Používejte stejné soubory písem a jejich verze na každém stroji nebo kontejneru, [načtěte požadovaná externí písma](/slides/cs/python-net/custom-font/), a [vložená písma](/slides/cs/python-net/embedded-font/) pokud licence umožňuje. Můžete také před exportem volat [FontsManager.get_substitutions](https://reference.aspose.com/slides/cs/python-net/aspose.slides/fontsmanager/get_substitutions/) pro identifikaci neočekávaných substitucí.