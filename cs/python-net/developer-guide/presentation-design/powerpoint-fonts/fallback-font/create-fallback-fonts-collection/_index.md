---
title: Konfigurace kolekcí záložních písem v Pythonu
linktitle: Kolekce záložních písem
type: docs
weight: 20
url: /cs/python-net/create-fallback-fonts-collection/
keywords:
- záložní písmo
- záložní pravidlo
- kolekce písem
- konfigurace písma
- nastavení písma
- PowerPoint
- OpenDocument
- prezentace
- Python
- Aspose.Slides
description: "Nastavte kolekci záložních písem v Aspose.Slides pro Python pomocí .NET, aby byl text v prezentacích PowerPoint a OpenDocument konzistentní a ostře vykreslený."
---
## **Přehled**

Aspose.Slides vám umožňuje nakonfigurovat kolekci pravidel záložních písem pro prezentaci. Každé pravidlo zálohy je reprezentováno třídou `FontFallBackRule` a může být přidáno do `FontFallBackRulesCollection`.

Po vytvoření kolekce ji můžete přiřadit k vlastnosti `font_fall_back_rules_collection` objektu `fonts_manager` prezentace. `fonts_manager` řídí písma v celé prezentaci a každá instance `Presentation` má svůj vlastní `FontsManager`.

Jakmile je `FontsManager` inicializován s kolekcí záložních písem, jsou při vykreslování prezentace použita určená náhradní písma.

## **Použití pravidel náhrady**

Instance třídy [FontFallBackRule](https://reference.aspose.com/slides/cs/python-net/aspose.slides/FontFallBackRule/) lze uspořádat do [FontFallBackRulesCollection](https://reference.aspose.com/slides/cs/python-net/aspose.slides/fontfallbackrulescollection/). Je možné přidávat nebo odebírat pravidla z kolekce.

Pak může být tato kolekce přiřazena k vlastnosti [font_fall_back_rules_collection](https://reference.aspose.com/slides/cs/python-net/aspose.slides/fontsmanager/font_fall_back_rules_collection/) třídy [FontsManager](https://reference.aspose.com/slides/cs/python-net/aspose.slides/fontsmanager/). FontsManager řídí písma v celé prezentaci.

Každá [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/) má vlastnost [fonts_manager](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/fonts_manager/), která obsahuje vlastní instanci třídy FontsManager.

Zde je příklad, jak vytvořit kolekci pravidel náhradních písem a přiřadit ji do FontsManageru konkrétní prezentace:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
	userRulesList = slides.FontFallBackRulesCollection()

	userRulesList.add(slides.FontFallBackRule(0x0B80, 0x0BFF, "Vijaya"))
	userRulesList.add(slides.FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic"))

	presentation.fonts_manager.font_fall_back_rules_collection = userRulesList
```

Po inicializaci FontsManageru s kolekcí náhradních písem jsou během vykreslování prezentace použita náhradní písma.

{{% alert color="primary" %}} 
Přečtěte si více o tom, jak [Vykreslit prezentaci s náhradním písmem](/slides/cs/python-net/render-presentation-with-fallback-font/).
{{% /alert %}}

## **Často kladené otázky**

**Budou moje pravidla náhrady vložena do souboru PPTX a viditelná v PowerPointu po uložení?**

Ne. Pravidla náhrady jsou nastavení vykreslování za běhu; nejsou serializována do PPTX a nebudou se zobrazovat v uživatelském rozhraní PowerPointu.

**Použije se náhrada na text uvnitř SmartArt, WordArt, grafů a tabulek?**

Ano. Stejný mechanismus substituce glyfů se používá pro jakýkoli text v těchto objektech.

**Distribuuje Aspose nějaká písma spolu s knihovnou?**

Ne. Písma přidáváte a používáte na své straně a na vlastní odpovědnost.

**Lze použít nahrazení/substituci chybějících písem a náhradu chybějících glyfů společně?**

Ano. Jedná se o nezávislé fáze stejného procesu řešení písem: nejprve engine určuje dostupnost písem ([replacement](/slides/cs/python-net/font-replacement/)/[substitution](/slides/cs/python-net/font-substitution/)), poté náhrada vyplní mezery chybějících glyfů v dostupných písmech.