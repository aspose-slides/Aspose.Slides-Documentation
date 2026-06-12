---
title: Vykreslování prezentací se záložními písmy v .NET
linktitle: Vykreslování prezentací
type: docs
weight: 30
url: /cs/net/render-presentation-with-fallback-font/
keywords:
- záložní písmo
- vykreslení PowerPoint
- vykreslení prezentace
- vykreslení snímku
- PowerPoint
- OpenDocument
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Vykreslujte prezentace se záložními písmy v Aspose.Slides pro .NET – zachovejte konzistentní text napříč PPT, PPTX a ODP pomocí krok za krokem ukázek kódu v C#."
---
## **Přehled**

Aspose.Slides vám umožňuje vykreslovat prezentace pomocí pravidel záložních písem. Tento článek ukazuje, jak vytvořit kolekci pravidel záložních písem, upravit její pravidla odebráním nebo přidáním záložních písem a přiřadit kolekci k vlastnosti `FontsManager.FontFallBackRulesCollection`.

Jakmile je kolekce pravidel záložních písem přiřazena k `FontsManager` prezentace, pravidla se použijí během operací, jako je ukládání, vykreslování a převod prezentace. Příklad ukazuje, jak použít nakonfigurovaná pravidla při vykreslování miniatury snímku a jejím uložení jako PNG obrázek.

## **Vykreslení snímku pomocí pravidel záložních písem**

Následující příklad zahrnuje tyto kroky:

1. Vytvoříme [kolekci pravidel záložních písem](/slides/cs/net/create-fallback-fonts-collection/).
2. [Remove()](https://reference.aspose.com/slides/cs/net/aspose.slides/fontfallbackrule/methods/remove) pravidlo záložního písma a [AddFallBackFonts()](https://reference.aspose.com/slides/cs/net/aspose.slides/fontfallbackrule/methods/addfallbackfonts) k dalšímu pravidlu.
3. Nastavte kolekci pravidel na vlastnost [FontsManager.FontFallBackRulesCollection](https://reference.aspose.com/slides/cs/net/aspose.slides/fontsmanager/properties/fontfallbackrulescollection).
4. Pomocí metody [Presentation.Save()](https://reference.aspose.com/slides/cs/net/aspose.slides.presentation/save/methods/4) můžeme prezentaci uložit ve stejném formátu nebo v jiném. Po nastavení kolekce pravidel záložních písem do FontsManageru se tato pravidla použijí během jakýchkoli operací s prezentací: ukládání, vykreslování, převod atd.

```c#
// Vytvořte novou instanci kolekce pravidel
IFontFallBackRulesCollection rulesList = new FontFallBackRulesCollection();

// vytvořte několik pravidel
rulesList.Add(new FontFallBackRule(0x400, 0x4FF, "Times New Roman"));
//rulesList.Add(new FontFallBackRule(...));

foreach (IFontFallBackRule fallBackRule in rulesList)
{
	// Pokus o odebrání záložního písma "Tahoma" z načtených pravidel
	fallBackRule.Remove("Tahoma");

	// A aktualizovat pravidla pro zadaný rozsah
	if ((fallBackRule.RangeEndIndex >= 0x4000) && (fallBackRule.RangeStartIndex < 0x5000))
		fallBackRule.AddFallBackFonts("Verdana");
}

// Také můžeme odstranit jakákoli existující pravidla ze seznamu
if (rulesList.Count > 0)
	rulesList.Remove(rulesList[0]);

using (Presentation pres = new Presentation("input.pptx"))
{
    // Přiřazení připraveného seznamu pravidel k použití
    pres.FontsManager.FontFallBackRulesCollection = rulesList;

    // Renderování miniatury s použitím inicializované kolekce pravidel a uložení do PNG
    using (IImage image = pres.Slides[0].GetImage(1f, 1f))
    {
        image.Save("Slide_0.png", ImageFormat.Png);
    }
}
```

{{% alert color="primary" %}} 
Přečtěte si více o [Ukládání a převodu v prezentaci](/slides/cs/net/convert-powerpoint-to-png/).
{{% /alert %}}