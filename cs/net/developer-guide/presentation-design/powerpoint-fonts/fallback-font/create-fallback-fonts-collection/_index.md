---
title: Konfigurace kolekcí záložních písem v .NET
linktitle: Kolekce záložních písem
type: docs
weight: 20
url: /cs/net/create-fallback-fonts-collection/
keywords:
- záložní písmo
- záložní pravidlo
- kolekce písem
- konfigurace písma
- nastavení písma
- PowerPoint
- OpenDocument
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Nastavte kolekci záložních písem v Aspose.Slides pro .NET, aby byl text v PowerPoint a OpenDocument prezentacích konzistentní a ostrý."
---
## **Přehled**

Aspose.Slides vám umožňuje nakonfigurovat kolekci pravidel záložních písem pro prezentaci. Každé pravidlo záložního písma je reprezentováno třídou `FontFallBackRule` a může být přidáno do `FontFallBackRulesCollection`, která implementuje rozhraní `IFontFallBackRulesCollection`.

Po vytvoření kolekce ji můžete přiřadit k vlastnosti `FontFallBackRulesCollection` v `FontsManager` prezentace. `FontsManager` řídí písma v celé prezentaci a každá instance `Presentation` má svůj vlastní `FontsManager`.

Jakmile je `FontsManager` inicializován s kolekcí záložních písem, jsou během vykreslování prezentace použita specifikovaná záložní písma.

## **Použití záložních pravidel**

Instance třídy [FontFallBackRule](https://reference.aspose.com/slides/cs/net/aspose.slides/FontFallBackRule) mohou být uspořádány do [FontFallBackRulesCollection](https://reference.aspose.com/slides/cs/net/aspose.slides/fontfallbackrulescollection), která implementuje rozhraní [IFontFallBackRulesCollection](https://reference.aspose.com/slides/cs/net/aspose.slides/ifontfallbackrulescollection). Je možné přidávat nebo odstraňovat pravidla z kolekce.

Pak může být tato kolekce přiřazena k [FontFallBackRulesCollection](https://reference.aspose.com/slides/cs/net/aspose.slides/fontsmanager/properties/fontfallbackrulescollection) vlastnosti třídy [FontsManager](https://reference.aspose.com/slides/cs/net/aspose.slides/fontsmanager). `FontsManager` řídí písma v celé prezentaci.

Každá [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation) má vlastnost [FontsManager](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/properties/fontsmanager) s vlastní instancí třídy `FontsManager`.

Zde je příklad, jak vytvořit kolekci pravidel záložních písem a přiřadit ji do `FontsManager` konkrétní prezentace:  

```c#
using (Presentation presentation = new Presentation())
{
	IFontFallBackRulesCollection userRulesList = new FontFallBackRulesCollection();

	userRulesList.Add(new FontFallBackRule(0x0B80, 0x0BFF, "Vijaya"));
	userRulesList.Add(new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic"));

	presentation.FontsManager.FontFallBackRulesCollection = userRulesList;
}
```

Po inicializaci `FontsManager` s kolekcí záložních písem jsou během vykreslování prezentace použita záložní písma.

{{% alert color="primary" %}} 
Přečtěte si více o tom, jak [Vykreslit prezentaci se záložním písmem](/slides/cs/net/render-presentation-with-fallback-font/).
{{% /alert %}}

## **Často kladené otázky**

**Budou mé záložní pravidla vložena do souboru PPTX a viditelná v PowerPointu po uložení?**

Ne. Záložní pravidla jsou nastavení vykreslování za běhu; nejsou serializována do souboru PPTX a nebudou se zobrazovat v uživatelském rozhraní PowerPointu.

**Platí záložní písmo i pro text uvnitř SmartArt, WordArt, grafů a tabulek?**

Ano. Pro jakýkoli text v těchto objektech se používá stejný mechanismus substituce glyphů.

**Distribuuje Aspose nějaká písma spolu s knihovnou?**

Ne. Písma přidáváte a používáte na své straně a nesete za ně plnou odpovědnost.

**Lze současně použít nahrazení/substituci chybějících písem a záložní písmo pro chybějící glyfy?**

Ano. Jedná se o nezávislé fáze stejného pipeline pro řešení písem: nejprve engine zjistí dostupnost písem ([nahrazení](/slides/cs/net/font-replacement/)/[substituce](/slides/cs/net/font-substitution/)), poté záložní písmo vyplní mezery pro chybějící glyfy v dostupných písmech.