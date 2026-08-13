---
title: Sekvence výběru písma v Aspose.Slides pro .NET
linktitle: Výběr písma
type: docs
weight: 80
url: /cs/net/font-selection-sequence/
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
- .NET
- C#
- Aspose.Slides
description: "Objevte, jak Aspose.Slides pro .NET vybírá písma, což zajišťuje ostrou a konzistentní prezentaci souborů PPT, PPTX a ODP - vylepšete své snímky ještě dnes."
---
## **Přehled**

Když je prezentace načtena, vykreslena nebo převedena do jiného formátu, Aspose.Slides zkontroluje, zda jsou písma použitá v prezentaci dostupná v operačním systému. Pokud požadované písmo chybí, Aspose.Slides vybere náhradní písmo, které je co nejvíce podobné tomu, které by použil PowerPoint.

Aspose.Slides nejprve hledá vybrané písmo v operačním systému. Pokud je písmo nalezeno, použije se. Pokud není nalezeno, použije se vhodná náhrada. Když jsou pravidla nahrazování písma definována pomocí `FontSubstRule`, jsou tato pravidla také zohledněna.

Můžete také přidat písma během běhu aplikace, použít v prezentaci vložená písma nebo načíst externí písma pro výstupní dokumenty, například PDF soubory.

## **Výběr písma**

Na písma v prezentaci se vztahují určitá pravidla, když je prezentace načtena, vykreslena nebo převedena do jiného formátu. Například když se pokusíte převést prezentaci (její snímky) na obrázky, písma v prezentaci jsou zkontrolována, aby se ověřilo, že vybraná písma jsou dostupná v operačním systému. Pokud jsou písma zjištěna jako chybějící, jsou nahrazena — viz [**Náhrada písma**](https://docs.aspose.com/slides/cs/net/font-replacement/) a [**Substituce písma**](https://docs.aspose.com/slides/cs/net/font-substitution/).

Toto je postup, který Aspose.Slides používá při práci s písmy:

1. Aspose.Slides hledá písma v operačním systému, aby našlo písmo, které odpovídá vybranému písmu v prezentaci. 
2. Pokud je vybrané písmo nalezeno, Aspose.Slides jej použije. V opačném případě Aspose.Slides použije náhradní písmo, které je co nejblíže tomu, co by použil PowerPoint.
3. Pokud byly nastaveny pravidla náhrady písma pomocí [FontSubstRule](https://reference.aspose.com/slides/cs/net/aspose.slides/fontsubstrule/), jsou použita. 

Aspose.Slides vám umožňuje přidat písma během běhu aplikace a pak tato písma použít. Viz [**Vlastní písma**](https://docs.aspose.com/slides/cs/net/custom-font/). 

Když jsou v prezentaci umístěna další písma, nazývají se [**Vložená písma**](https://docs.aspose.com/slides/cs/net/embedded-font/).

Aspose.Slides vám umožňuje přidat písma, která jsou aplikována *pouze* na výstupní dokumenty. Například pokud prezentace, kterou chcete převést do PDF, obsahuje písma chybějící ve vašem systému a vložená písma, můžete přidat nebo načíst potřebná písma jako **externí písma**. 

{{% alert title="Note" color="info" %}} 
Nešleme žádná písma, ať už placená nebo bezplatná. Naše API vám umožňuje načíst externí písma a vložit je do dokumentů, ale činíte tak na vlastní odpovědnost a podle vlastního uvážení.
{{% /alert %}}

## **Často kladené otázky**

### Jak mohu zjistit, která písma jsou ve skutečnosti v prezentaci použita před konverzí?

Aspose.Slides vám umožňuje prohlédnout písma použitá pomocí [správce písem](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/fontsmanager/), takže můžete rozhodnout, zda [vložit](/slides/cs/net/embedded-font/), [nahradit](/slides/cs/net/font-replacement/) nebo přidat [externí zdroje](/slides/cs/net/custom-font/). To vám pomůže zabránit nechtěným substitucím během vykreslování a exportu.

### Mohu přidat další adresáře s písmy, aniž bych je instaloval do operačního systému?

Ano. Můžete registrovat [externí zdroje písem](/slides/cs/net/custom-font/), například složky nebo paměťové proudy, pro vykreslování a export. Tím odstraníte závislost na písmech hostitelského systému a zachováte předvídatelný rozvrh.

### Jak zabránit tichému přepnutí na nevhodné písmo, když chybí glyph?

Definujte předem explicitní [náhradu písma](/slides/cs/net/font-replacement/) a [pravidla pro fallback písma](/slides/cs/net/fallback-font/). Analýzou použitých písem a nastavením řízené priority pro substituty zajistíte konzistentní typografii a vyhnete se neočekávaným výsledkům.