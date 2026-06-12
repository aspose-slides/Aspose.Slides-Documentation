---
title: Sekvence výběru písma v Aspose.Slides pro .NET
linktitle: Výběr písma
type: docs
weight: 80
url: /cs/net/font-selection-sequence/
keywords:
- výběr písma
- náhrada písma
- nahrazení písma
- pravidlo náhrady
- dostupné písmo
- chybějící písmo
- PowerPoint
- OpenDocument
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Objevte, jak Aspose.Slides pro .NET vybírá písma, což zajišťuje ostrý a konzistentní vzhled PPT, PPTX a ODP souborů — vylepšete své snímky nyní."
---
## **Přehled**

Když je prezentace načtena, vykreslena nebo převedena do jiného formátu, Aspose.Slides kontroluje, zda jsou písma použité v prezentaci dostupná v operačním systému. Pokud požadované písmo chybí, Aspose.Slides vybere náhradní písmo, které je co nejvíce podobné tomu, které by použil PowerPoint.

Aspose.Slides nejprve vyhledá vybrané písmo v operačním systému. Pokud je písmo nalezeno, je použito. Pokud není nalezeno, použije se vhodná náhrada. Když jsou pravidla náhrady písma definována pomocí `FontSubstRule`, jsou tato pravidla také zohledněna.

Můžete také přidávat písma během běhu aplikace, používat vložená písma z prezentace nebo načíst externí písma pro výstupní dokumenty, například PDF soubory.

## **Výběr písma**

Na písma v prezentaci se vztahují určitá pravidla, když je prezentace načtena, vykreslena nebo převedena do jiného formátu. Například když se pokusíte převést prezentaci (její snímky) na obrázky, písma prezentace jsou kontrolována, aby se ověřilo, že vybraná písma jsou dostupná v operačním systému. Pokud je potvrzeno, že písma chybí, jsou nahrazena — viz [**Font Replacement**](https://docs.aspose.com/slides/cs/net/font-replacement/) a [**Font Substitution**](https://docs.aspose.com/slides/cs/net/font-substitution/).

Toto je proces, který Aspose.Slides používá při práci s písmy:

1. Aspose.Slides vyhledá písma v operačním systému, aby našel písmo, které odpovídá vybranému písmu v prezentaci. 
2. Pokud je vybrané písmo nalezeno, Aspose.Slides jej použije. V opačném případě Aspose.Slides použije náhradní písmo, které je co nejvíce podobné tomu, co by použil PowerPoint. 
3. Pokud byla pravidla náhrady písma nastavena pomocí [FontSubstRule](https://reference.aspose.com/slides/cs/net/aspose.slides/fontsubstrule/), jsou aplikována. 

Aspose.Slides vám umožňuje přidávat písma během běhu aplikace a poté tato písma používat. Viz [**Custom fonts**](https://docs.aspose.com/slides/cs/net/custom-font/). 

Když jsou v prezentaci umístěna další písma, nazývají se [**Embedded fonts**](https://docs.aspose.com/slides/cs/net/embedded-font/).

Aspose.Slides vám umožňuje přidávat písma, která se aplikují *pouze* na výstupní dokumenty. Například pokud prezentace, kterou chcete převést do PDF, obsahuje písma chybějící ve vašem systému a vložená písma, můžete potřebná písma přidat nebo načíst jako **external fonts**. 

{{% alert title="Note" color="primary" %}} 
Nešíříme žádná písma, ať už placená nebo zdarma. Naše API vám umožňuje načíst externí písma a vložit je do dokumentů, ale děláte tak s písmy na vlastní odpovědnost a uvážení.
{{% /alert %}}

## **Často kladené otázky**

**Jak mohu zjistit, která písma jsou v prezentaci skutečně používána před konverzí?**

Aspose.Slides vám umožňuje prozkoumat použitá písma pomocí [font manager](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/fontsmanager/), takže můžete rozhodnout, zda [embed](/slides/cs/net/embedded-font/), [replace](/slides/cs/net/font-replacement/), nebo přidat [external sources](/slides/cs/net/custom-font/). To vám pomůže zabránit nechtěným náhradám během vykreslování a exportu.

**Mohu přidat další adresáře s písmy, aniž bych je instaloval do operačního systému?**

Ano. Můžete zaregistrovat [external font sources](/slides/cs/net/custom-font/) jako složky nebo paměťové proudy pro vykreslování a export. Tím se odstraní závislost na písmatech hostitelského systému a zachová se předvídatelné rozvržení.

**Jak zabráním tichému přechodu na nevhodné písmo, když chybí konkrétní glyf?**

Definujte předem explicitní [font replacement](/slides/cs/net/font-replacement/) a pravidla [fallBack rules](/slides/cs/net/fallback-font/). Analýzou použitých písem a nastavením řízené priority pro náhrady zajistíte konzistentní typografii a vyhnete se neočekávaným výsledkům.