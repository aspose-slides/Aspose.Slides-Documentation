---
title: Vykreslení prezentací se záložními fonty v Pythonu
linktitle: Vykreslit prezentace
type: docs
weight: 30
url: /cs/python-net/render-presentation-with-fallback-font/
keywords:
- záložní font
- vykreslit PowerPoint
- vykreslit prezentaci
- vykreslit snímek
- PowerPoint
- prezentace
- Python
- Aspose.Slides
description: "Vykreslete prezentace se záložními fonty v Aspose.Slides pro Python pomocí .NET – zachovejte konzistentní text napříč PPT, PPTX a ODP s podrobnými ukázkovými kódy."
---
## **Přehled**

Aspose.Slides vám umožňuje vykreslovat prezentace pomocí pravidel pro záložní písma. Tento článek ukazuje, jak vytvořit kolekci pravidel pro záložní písma, upravit její pravidla odstraněním nebo přidáním záložních písem a přiřadit kolekci k vlastnosti `FontsManager.font_fall_back_rules_collection`.

Jakmile je kolekce pravidel pro záložní písma přiřazena k `fonts_manager` prezentace, jsou pravidla aplikována během operací, jako je ukládání, vykreslování a převod prezentace. Příklad ukazuje, jak použít nakonfigurovaná pravidla při vykreslování miniatury snímku a jejím uložení jako PNG obrázek.

## **Vykreslení snímku pomocí pravidel pro záložní písma**

1. Vytvoříme [kolekci pravidel pro záložní písma](/slides/cs/python-net/create-fallback-fonts-collection/).
2. [Odstraňte](https://reference.aspose.com/slides/cs/python-net/aspose.slides/fontfallbackrule/remove/) pravidlo pro záložní písmo a [add_fall_back_fonts](https://reference.aspose.com/slides/cs/python-net/aspose.slides/fontfallbackrule/add_fall_back_fonts/) přidejte k jinému pravidlu.
3. Nastavte kolekci pravidel na vlastnost [FontsManager.font_fall_back_rules_collection](https://reference.aspose.com/slides/cs/python-net/aspose.slides/fontsmanager/font_fall_back_rules_collection/).
4. Pomocí metody [Presentation.save()](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/) můžeme prezentaci uložit ve stejném formátu nebo ji uložit v jiném. Po nastavení kolekce pravidel pro záložní písma v FontsManager jsou tato pravidla aplikována během všech operací s prezentací: ukládání, vykreslování, převod atd.

```py
import aspose.slides as slides

# Vytvořit novou instanci kolekce pravidel
rulesList = slides.FontFallBackRulesCollection()

# vytvořit několik pravidel
rulesList.add(slides.FontFallBackRule(0x400, 0x4FF, "Times New Roman"))

for fallBackRule in rulesList:
	# Pokus o odstranění záložního fontu "Tahoma" z načtených pravidel
	fallBackRule.remove("Tahoma")

	# A aktualizovat pravidla pro zadaný rozsah
	if fallBackRule.range_end_index >= 0x4000 and fallBackRule.range_start_index < 0x5000:
		fallBackRule.add_fall_back_fonts("Verdana")

# Také můžeme odstranit jakákoli existující pravidla ze seznamu
if len(rulesList) > 0:
	rulesList.remove(rulesList[0])

with slides.Presentation(path + "input.pptx") as pres:
	# Přiřazení připraveného seznamu pravidel pro použití
	pres.fonts_manager.font_fall_back_rules_collection = rulesList

	# Vykreslení miniatury pomocí inicializované kolekce pravidel a uložení do PNG
	with pres.slides[0].get_image(1, 1) as img:
		img.save("Slide_0.png", slides.ImageFormat.PNG)
```

{{% alert color="primary" %}} 
Přečtěte si více o tom, jak [převést snímky PowerPointu na PNG v Pythonu](/slides/cs/python-net/convert-powerpoint-to-png/).
{{% /alert %}}