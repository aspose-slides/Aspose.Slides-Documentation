---
title: Vykreslování prezentací se záložními fonty v .NET
linktitle: Vykreslování prezentací
type: docs
weight: 30
url: /cs/net/render-presentation-with-fallback-font/
keywords:
- záložní font
- vykreslit PowerPoint
- vykreslit prezentaci
- vykreslit snímek
- PowerPoint
- OpenDocument
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Vykreslování prezentací se záložními fonty v Aspose.Slides pro .NET – zajistěte konzistentní text napříč PPT, PPTX a ODP pomocí krok za krokem ukázek kódu v C#."
---
## **Přehled**

Aspose.Slides vám umožňuje vykreslovat prezentace pomocí pravidel záložních písem. Tento článek ukazuje, jak vytvořit kolekci pravidel záložních písem, upravit její pravidla odebráním nebo přidáním záložních písem a přiřadit kolekci k vlastnosti `FontsManager.FontFallBackRulesCollection`.

Jakmile je kolekce pravidel záložních písem přiřazena k `FontsManager` prezentace, pravidla se aplikují během operací, jako je ukládání, vykreslování a převod prezentace. Příklad ukazuje, jak použít nakonfigurovaná pravidla při vykreslování miniatury snímku a uložení jako PNG obrázek.

## **Vykreslení snímku pomocí pravidel záložních písem**

1. Vytvoříme [kolekci pravidel záložních písem](/slides/cs/net/create-fallback-fonts-collection/).
1. [Remove()](https://reference.aspose.com/slides/cs/net/aspose.slides/fontfallbackrule/methods/remove) pravidlo záložního písma a [AddFallBackFonts()](https://reference.aspose.com/slides/cs/net/aspose.slides/fontfallbackrule/methods/addfallbackfonts) k jinému pravidlu.
1. Nastavte kolekci pravidel na vlastnost [FontsManager.FontFallBackRulesCollection](https://reference.aspose.com/slides/cs/net/aspose.slides/fontsmanager/properties/fontfallbackrulescollection).
1. Pomocí metody [Presentation.Save()](https://reference.aspose.com/slides/cs/net/aspose.slides.presentation/save/methods/4) můžeme prezentaci uložit ve stejném formátu nebo v jiném. Po nastavení kolekce pravidel záložních písem do FontsManager se tato pravidla použijí během všech operací s prezentací: ukládání, vykreslování, konverze atd.

```c#
using Aspose.Slides;

// Vytvořit novou instanci kolekce pravidel
IFontFallBackRulesCollection rulesList = new FontFallBackRulesCollection();

// vytvořit řadu pravidel
rulesList.Add(new FontFallBackRule(0x400, 0x4FF, "Times New Roman"));
rulesList.Add(new FontFallBackRule(0x600, 0x6FF, "Tahoma, Arial"));

foreach (IFontFallBackRule fallBackRule in rulesList)
{
	//Pokoušíme se odstranit záložní font "Tahoma" ze načtených pravidel
	fallBackRule.Remove("Tahoma");

	//A aktualizovat pravidla pro určený rozsah
	if ((fallBackRule.RangeEndIndex >= 0x400) && (fallBackRule.RangeStartIndex < 0x500))
		fallBackRule.AddFallBackFonts("Verdana");
}

//Také můžeme odstranit jakákoli existující pravidla ze seznamu, ponechávajíc alespoň jedno pravidlo pro vykreslení
if (rulesList.Count > 1)
	rulesList.Remove(rulesList[1]);

using (Presentation pres = new Presentation("input.pptx"))
{
    //Přiřazení připraveného seznamu pravidel k použití
    pres.FontsManager.FontFallBackRulesCollection = rulesList;

    // Vykreslení miniatury pomocí inicializované kolekce pravidel a uložení do PNG
    using (IImage image = pres.Slides[0].GetImage(1f, 1f))
    {
        image.Save("Slide_0.png", ImageFormat.Png);
    }
}
```

{{% alert color="info" %}} 
Přečtěte si více o [Ukládání a konverzi v prezentaci](/slides/cs/net/convert-powerpoint-to-png/).
{{% /alert %}}