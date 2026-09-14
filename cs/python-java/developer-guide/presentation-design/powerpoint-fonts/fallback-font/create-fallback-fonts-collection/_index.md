---
title: Konfigurace kolekcí náhradních písem v Pythonu prostřednictvím Javy
linktitle: Kolekce náhradních písem
type: docs
weight: 20
url: /cs/python-java/create-fallback-fonts-collection/
keywords:
- náhradní písmo
- náhradní pravidlo
- kolekce písem
- nastavení písma
- instalace písma
- PowerPoint
- OpenDocument
- prezentace
- Python
- Java
- Aspose.Slides
description: "Nastavte kolekci náhradních písem v Aspose.Slides pro Python přes Java, aby byl text v prezentacích PowerPoint a OpenDocument konzistentní a ostrý."
---
## **Přehled**

Aspose.Slides umožňuje nakonfigurovat kolekci pravidel náhradního písma pro prezentaci. Každé pravidlo náhradního písma je reprezentováno třídou [FontFallBackRule](https://reference.aspose.com/slides/cs/python-java/aspose.slides/fontfallbackrule/) a může být přidáno do [FontFallBackRulesCollection](https://reference.aspose.com/slides/cs/python-java/aspose.slides/fontfallbackrulescollection/).

Po vytvoření kolekce ji můžete přiřadit pomocí metody [setFontFallBackRulesCollection](https://reference.aspose.com/slides/cs/python-java/aspose.slides/fontsmanager/#setFontFallBackRulesCollection) třídy [FontsManager](https://reference.aspose.com/slides/cs/python-java/aspose.slides/fontsmanager/) prezentace. [FontsManager](https://reference.aspose.com/slides/cs/python-java/aspose.slides/fontsmanager/) řídí písma v celé prezentaci a každá instance [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/) má svůj vlastní [FontsManager](https://reference.aspose.com/slides/cs/python-java/aspose.slides/fontsmanager/).

Jakmile je [FontsManager](https://reference.aspose.com/slides/cs/python-java/aspose.slides/fontsmanager/) inicializován s kolekcí náhradních písem, jsou při vykreslování prezentace použita určená náhradní písma.

## **Použití pravidel náhradního písma**

Instance třídy [FontFallBackRule](https://reference.aspose.com/slides/cs/python-java/aspose.slides/fontfallbackrule/) lze uspořádat v kolekci [FontFallBackRulesCollection](https://reference.aspose.com/slides/cs/python-java/aspose.slides/fontfallbackrulescollection/). Pravidla můžete přidávat nebo odebírat z kolekce.

Tuto kolekci lze následně přiřadit pomocí metody [setFontFallBackRulesCollection](https://reference.aspose.com/slides/cs/python-java/aspose.slides/fontsmanager/#setFontFallBackRulesCollection) třídy [FontsManager](https://reference.aspose.com/slides/cs/python-java/aspose.slides/fontsmanager/), která řídí písma v celé prezentaci.

Každá [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/) má metodu [getFontsManager](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/#getFontsManager), která vrací její vlastní instanci třídy [FontsManager](https://reference.aspose.com/slides/cs/python-java/aspose.slides/fontsmanager/).

Následující příklad ukazuje, jak vytvořit kolekci pravidel náhradního písma a přiřadit ji [FontsManager](https://reference.aspose.com/slides/cs/python-java/aspose.slides/fontsmanager/) prezentace:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontFallBackRule, FontFallBackRulesCollection, Presentation

presentation = Presentation()
try:
    fallback_rules = FontFallBackRulesCollection()

    tamil_rule = FontFallBackRule(0x0B80, 0x0BFF, "Vijaya")
    fallback_rules.add(tamil_rule)
    hiragana_rule = FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic")
    fallback_rules.add(hiragana_rule)

    presentation.getFontsManager().setFontFallBackRulesCollection(fallback_rules)
finally:
    presentation.dispose()
```

Po inicializaci [FontsManager](https://reference.aspose.com/slides/cs/python-java/aspose.slides/fontsmanager/) s kolekcí náhradních písem se během vykreslování prezentace použijí náhradní písma.

{{% alert color="info" title="Poznámka" %}}
Přečtěte si více o tom, jak [vykreslit prezentaci s náhradním písmem](/slides/cs/python-java/render-presentation-with-fallback-font/).
{{% /alert %}}

## **Často kladené otázky**

**Budou moje pravidla náhradního písma vložena do souboru PPTX a viditelná v PowerPointu po uložení?**

Ne. Pravidla náhradního písma jsou nastavení vykreslování za běhu; nejsou serializována do PPTX a nebudou se zobrazovat v uživatelském rozhraní PowerPointu.

**Platí náhrada i pro text uvnitř SmartArt, WordArt, grafů a tabulek?**

Ano. Stejný mechanismus substituce glyfů se používá pro jakýkoli text v těchto objektech.

**Distribuuje Aspose nějaká písma spolu s knihovnou?**

Ne. Písma přidáváte a používáte na své straně a na své vlastní odpovědnosti.

**Lze kombinovat náhradu/substituci chybějících písem a náhradní písmo pro chybějící glyfy?**

Ano. Jedná se o nezávislé fáze stejného pipeline pro řešení písem: nejprve engine řeší dostupnost písem ([nahrazení](/slides/cs/python-java/font-replacement/)/[substituce](/slides/cs/python-java/font-substitution/)), poté náhradní písmo doplňuje mezery pro chybějící glyfy v dostupných písmech.