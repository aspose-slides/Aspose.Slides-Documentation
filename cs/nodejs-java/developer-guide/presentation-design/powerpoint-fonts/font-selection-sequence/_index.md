---
title: "Sekvence výběru písma v Aspose.Slides pro Node.js přes Java"
linktitle: "Výběr písma"
type: docs
weight: 80
url: /cs/nodejs-java/font-selection-sequence/
keywords:
- "výběr písma"
- "nahrazení písma"
- "náhrada písma"
- "pravidlo substituce"
- "dostupné písmo"
- "chybějící písmo"
- "PowerPoint"
- "OpenDocument"
- "prezentace"
- "Node.js"
- "JavaScript"
- "Aspose.Slides"
description: "Objevte, jak Aspose.Slides pro Node.js přes Java vybírá písma, aby zajistil ostrou a konzistentní prezentaci souborů PPT, PPTX a ODP — vylepšete své snímky nyní."
---
## **Přehled**

Když je prezentace načtena, vykreslena nebo převedena do jiného formátu, Aspose.Slides kontroluje, zda jsou písma použité v prezentaci dostupná v operačním systému. Pokud chybí požadované písmo, Aspose.Slides vybere náhradní písmo, které je co nejblíže tomu, které by použil PowerPoint.

Aspose.Slides nejprve hledá vybrané písmo v operačním systému. Pokud je písmo nalezeno, použije se. Pokud není nalezeno, použije se vhodná náhrada. Když jsou pravidla nahrazování písem definována pomocí `FontSubstRule`, jsou tato pravidla také zohledněna.

Také můžete přidávat písma během běhu aplikace, používat vložená písma z prezentace nebo načíst externí písma pro výstupní dokumenty, například PDF soubory.

## **Výběr písma**

Na písma v prezentaci se vztahují určitá pravidla při načtení, vykreslení nebo převodu do jiného formátu. Například když se pokusíte převést prezentaci (její snímky) na obrázky, písma prezentace jsou zkontrolována, aby se ověřilo, že vybraná písma jsou dostupná v operačním systému. Pokud je potvrzeno, že písma chybí, jsou nahrazena — viz [**Nahrazení písma**](https://docs.aspose.com/slides/cs/nodejs-java/font-replacement/) a [**Substituce písma**](https://docs.aspose.com/slides/cs/nodejs-java/font-substitution/).

Toto je proces, který Aspose.Slides při práci s písmy používá:

1. Aspose.Slides hledá písma v operačním systému, aby našel písmo, které odpovídá vybranému písmu v prezentaci. 
2. Pokud je vybrané písmo nalezeno, Aspose.Slides jej použije. V opačném případě Aspose.Slides použije náhradní písmo, které je co nejblíže tomu, co by použil PowerPoint.
3. Pokud byly pravidla nahrazování písem nastavena pomocí [FontSubstRule](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/fontsubstrule/), jsou aplikována.

Aspose.Slides vám umožňuje přidávat písma během běhu aplikace a následně je používat. Viz [**Vlastní písma**](https://docs.aspose.com/slides/cs/nodejs-java/custom-font/).

Když jsou v prezentaci umístěna další písma, nazývají se [**Vložená písma**](https://docs.aspose.com/slides/cs/nodejs-java/embedded-font/).

Aspose.Slides vám umožňuje přidávat písma, která jsou použita pouze ve výstupních dokumentech. Například pokud prezentace, kterou chcete převést do PDF, obsahuje písma chybějící ve vašem systému a vložená písma, můžete potřebná písma přidat nebo načíst jako **externí písma**. 

{{% alert title="Note" color="primary" %}} 
Nešleme žádná písma, ať už placená nebo zdarma. Naše API vám umožňuje načíst externí písma a vložit je do dokumentů, ale činíte tak na vlastní rozhodnutí a odpovědnost.
{{% /alert %}}

## **Často kladené otázky**

**Jak mohu zjistit, která písma jsou v prezentaci skutečně použita před převodem?**

Aspose.Slides vám umožňuje prozkoumat použité písma pomocí [správce písem](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/getfontsmanager/), takže můžete rozhodnout, zda [vložit](/slides/cs/nodejs-java/embedded-font/), [nahradit](/slides/cs/nodejs-java/font-replacement/) nebo přidat [externí zdroje](/slides/cs/nodejs-java/custom-font/). To vám pomůže zabránit nechtěným substitucím během vykreslování a exportu.

**Mohu přidat další složky s písmy, aniž bych je instaloval do operačního systému?**

Ano. Můžete zaregistrovat [externí zdroje písem](/slides/cs/nodejs-java/custom-font/), jako jsou složky nebo paměťové proudy, pro vykreslování a export. Tím se odstraní závislost na písmatech hostitelského systému a zachová se předvídatelné rozvržení.

**Jak zabránit tichému přechodu na nevhodné písmo, když chybí glif?**

Předem definujte explicitní [nahrazení písma](/slides/cs/nodejs-java/font-replacement/) a [pravidla pro náhradní písma](/slides/cs/nodejs-java/fallback-font/). Analýzou použitých písem a nastavením řízené priority pro náhrady zajistíte konzistentní typografii a vyhnete se neočekávaným výsledkům.