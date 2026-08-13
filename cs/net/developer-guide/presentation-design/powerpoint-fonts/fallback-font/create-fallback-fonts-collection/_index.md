---
title: Konfigurace kolekcí náhradních fontů v .NET
linktitle: Kolekce náhradních fontů
type: docs
weight: 20
url: /cs/net/create-fallback-fonts-collection/
keywords:
- náhradní font
- náhradní pravidlo
- kolekce fontů
- nastavení fontu
- založení fontu
- PowerPoint
- OpenDocument
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Nastavte kolekci náhradních fontů v Aspose.Slides pro .NET, aby text v prezentacích PowerPoint a OpenDocument byl konzistentní a ostrý."
---
## **Přehled**

Aspose.Slides vám umožňuje nakonfigurovat kolekci pravidel pro náhradní písmo (fallback) pro prezentaci. Každé pravidlo náhradního písma je reprezentováno třídou `FontFallBackRule` a může být přidáno do `FontFallBackRulesCollection`, která implementuje rozhraní `IFontFallBackRulesCollection`.

Po vytvoření kolekce ji můžete přiřadit k vlastnosti `FontFallBackRulesCollection` třídy `FontsManager` prezentace. `FontsManager` řídí písma v celé prezentaci a každá instance `Presentation` má svůj vlastní `FontsManager`.

Jakmile je `FontsManager` inicializován s kolekcí náhradních písem, specifikovaná náhradní písma jsou použita během vykreslování prezentace.

## **Použití pravidel náhradního písma**

Instance třídy [FontFallBackRule](https://reference.aspose.com/slides/cs/net/aspose.slides/FontFallBackRule) mohou být uspořádány v [FontFallBackRulesCollection](https://reference.aspose.com/slides/cs/net/aspose.slides/fontfallbackrulescollection), která implementuje [IFontFallBackRulesCollection](https://reference.aspose.com/slides/cs/net/aspose.slides/ifontfallbackrulescollection) rozhraní. Je možné přidávat nebo odstraňovat pravidla z kolekce.

Poté může být tato kolekce přiřazena k [FontFallBackRulesCollection](https://reference.aspose.com/slides/cs/net/aspose.slides/fontsmanager/properties/fontfallbackrulescollection) vlastnosti třídy [FontsManager](https://reference.aspose.com/slides/cs/net/aspose.slides/fontsmanager). FontsManager řídí písma v celé prezentaci.

Každý [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation) má vlastnost [FontsManager](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/properties/fontsmanager) s vlastní instancí třídy FontsManager.

Zde je příklad, jak vytvořit kolekci pravidel náhradních písem a přiřadit ji do FontsManager určité prezentace:

```c#
using Aspose.Slides;

using (Presentation presentation = new Presentation())
{
	IFontFallBackRulesCollection userRulesList = new FontFallBackRulesCollection();

	userRulesList.Add(new FontFallBackRule(0x0B80, 0x0BFF, "Vijaya"));
	userRulesList.Add(new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic"));

	presentation.FontsManager.FontFallBackRulesCollection = userRulesList;
}
```

Po inicializaci FontsManager s kolekcí náhradních písem jsou náhradní písma použita během vykreslování prezentace.

{{% alert color="info" %}} 
Přečtěte si více o tom, jak [Render Presentation with Fallback Font](/slides/cs/net/render-presentation-with-fallback-font/).
{{% /alert %}}

## **Často kladené otázky**

### Budou moje pravidla náhradního písma vložena do souboru PPTX a viditelné v PowerPointu po uložení?

Ne. Pravidla náhradního písma jsou nastaveními vykreslování za běhu; nejsou serializována do PPTX a neobjeví se v uživatelském rozhraní PowerPointu.

### Platí náhradní písmo na text uvnitř SmartArt, WordArt, grafů a tabulek?

Ano. Stejný mechanismus substituce glifů se používá pro jakýkoli text v těchto objektech.

### Distribuuje Aspose nějaká písma s knihovnou?

Ne. Písma přidáváte a používáte na své straně a nesete za to odpovědnost.

### Lze kombinovat nahrazení/substituci chybějících písem a náhradní písmo pro chybějící glify?

Ano. Jedná se o nezávislé fáze stejného pipeline pro řešení písem: nejprve engine řeší dostupnost písem ([replacement](/slides/cs/net/font-replacement/)/[substitution](/slides/cs/net/font-substitution/)), poté náhradní písmo vyplňuje mezery pro chybějící glify v dostupných písmech.