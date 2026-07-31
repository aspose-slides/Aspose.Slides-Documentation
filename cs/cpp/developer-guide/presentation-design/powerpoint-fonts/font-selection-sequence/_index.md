---
title: Sekvence výběru písma v Aspose.Slides pro C++
linktitle: Výběr písma
type: docs
weight: 80
url: /cs/cpp/font-selection-sequence/
keywords:
- výběr písma
- substituce písma
- náhrada písma
- pravidlo substituce
- dostupné písmo
- chybějící písmo
- PowerPoint
- OpenDocument
- prezentace
- C++
- Aspose.Slides
description: "Objevte, jak Aspose.Slides pro C++ vybírá písma, zajišťuje ostrou a konzistentní prezentaci souborů PPT, PPTX a ODP – vylepšete své snímky nyní."
---
## **Přehled**

Když je prezentace načtena, vykreslena nebo převedena do jiného formátu, Aspose.Slides zkontroluje, zda jsou písma použité v prezentaci dostupná v operačním systému. Pokud požadované písmo chybí, Aspose.Slides vybere náhradní písmo, které je co nejvíce podobné tomu, které by použil PowerPoint.

Aspose.Slides nejprve hledá vybrané písmo v operačním systému. Pokud je písmo nalezeno, použije se. Pokud není nalezeno, použije se vhodná náhrada. Když jsou pravidla nahrazování písem definována prostřednictvím `FontSubstRule`, jsou tato pravidla také zohledněna.

Můžete také přidat písma během běhu aplikace, použít vložená písma z prezentace nebo načíst externí písma pro výstupní dokumenty, například PDF soubory.

## **Výběr písma**

Na písma v prezentaci se vztahují určitá pravidla, když je prezentace načtena, vykreslena nebo převedena do jiného formátu. Například když se pokusíte převést prezentaci (její snímky) na obrázky, písma v prezentaci jsou kontrolována, aby se ověřilo, že vybraná písma jsou dostupná v operačním systému. Pokud jsou písma potvrzena jako chybějící, jsou nahrazena — viz [**Náhrada písem**](https://docs.aspose.com/slides/cs/cpp/font-replacement/) a [**Substituce písem**](https://docs.aspose.com/slides/cs/cpp/font-substitution/).

Tento proces Aspose.Slides používá při práci s písmy:

1. Aspose.Slides hledá písma v operačním systému, aby našel písmo, které odpovídá vybranému písmu v prezentaci. 
2. Pokud je vybrané písmo nalezeno, použije jej Aspose.Slides. V opačném případě Aspose.Slides použije náhradní písmo, které je co možná nejblíže tomu, co by použil PowerPoint.
3. Pokud byla pravidla nahrazování písem nastavena přes [FontSubstRule](https://reference.aspose.com/slides/cs/cpp/aspose.slides/fontsubstrule/), jsou aplikována. 

Aspose.Slides vám umožňuje přidat písma během běhu aplikace a poté tato písma používat. Viz [**Vlastní písma**](https://docs.aspose.com/slides/cs/cpp/custom-font/). 

Když jsou v prezentaci umístěna další písma, nazývají se [**Vložená písma**](https://docs.aspose.com/slides/cs/cpp/embedded-font/).

Aspose.Slides vám umožňuje přidat písma, která jsou aplikována *pouze* na výstupní dokumenty. Například pokud prezentace, kterou chcete převést do PDF, obsahuje písma chybějící ve vašem systému a vložená písma, můžete potřebná písma přidat nebo načíst jako **externí písma**. 

{{% alert title="Note" color="primary" %}} 
Nevydáváme žádná písma, ať už placená nebo zdarma. Naše API vám umožňuje načíst externí písma a vložit je do dokumentů, ale děláte tak s písmy na vlastní uvážení a odpovědnost.
{{% /alert %}}

## **Často kladené otázky**

**Jak mohu určit, která písma jsou v prezentaci skutečně použita před konverzí?**

Aspose.Slides vám umožňuje prohlédnout použité písma pomocí [správce písem](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/get_fontsmanager/), takže můžete rozhodnout, zda [vložit](/slides/cs/cpp/embedded-font/), [nahradit](/slides/cs/cpp/font-replacement/), nebo přidat [externí zdroje](/slides/cs/cpp/custom-font/). To vám pomůže zabránit nechtěným nahrazením během vykreslování a exportu.

**Mohu přidat další adresáře s písmy bez jejich instalace do operačního systému?**

Ano. Můžete zaregistrovat [externí zdroje písem](/slides/cs/cpp/custom-font/), jako jsou složky nebo proudy v paměti, pro vykreslování a export. Tím se odstraní závislost na písmu hostitelského systému a zachová se předvídatelnost rozvržení.

**Jak mohu zabránit tichému přepnutí na nevhodné písmo, když chybí glif?**

Definujte předem explicitní [náhradu písem](/slides/cs/cpp/font-replacement/) a pravidla [fallback](/slides/cs/cpp/fallback-font/) pro písma. Analýzou použitých písem a nastavením kontrolované priority pro náhrady zajistíte konzistentní typografii a vyhnete se neočekávaným výsledkům.