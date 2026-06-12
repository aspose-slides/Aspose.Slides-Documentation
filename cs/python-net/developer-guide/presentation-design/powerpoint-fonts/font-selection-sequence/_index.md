---
title: Sekvence výběru písma v Aspose.Slides pro Python
linktitle: Výběr písma
type: docs
weight: 80
url: /cs/python-net/font-selection-sequence/
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
- Python
- Aspose.Slides
description: "Objevte, jak Aspose.Slides pro Python přes .NET vybírá písma, což zajišťuje ostrou a konzistentní prezentaci souborů PPT, PPTX a ODP - zlepšete své snímky nyní."
---
## **Přehled**

Když je prezentace načtena, vykreslena nebo převedena do jiného formátu, Aspose.Slides kontroluje, zda jsou písma použitá v prezentaci dostupná v operačním systému. Pokud požadované písmo chybí, Aspose.Slides vybere náhradní písmo, které je co nejblíže tomu, které by použil PowerPoint.

Aspose.Slides nejprve vyhledá vybrané písmo v operačním systému. Pokud je písmo nalezeno, použije se. Pokud není nalezeno, použije se vhodná náhrada. Když jsou pravidla nahrazování písma definována prostřednictvím `FontSubstRule`, jsou tato pravidla také zohledněna.

Můžete také přidávat písma za běhu aplikace, používat vložená písma z prezentace nebo načítat externí písma pro výstupní dokumenty, například soubory PDF.

## **Výběr písma**

Na písma v prezentaci se vztahují určitá pravidla, když je prezentace načtena, vykreslena nebo převedena do jiného formátu. Například když se pokusíte převést prezentaci (její snímky) na obrázky, jsou písma v prezentaci zkontrolována, aby se ověřilo, že vybraná písma jsou dostupná v operačním systému. Pokud jsou písma potvrzena jako chybějící, jsou nahrazena — viz [**Náhrada písma**](https://docs.aspose.com/slides/cs/python-net/font-replacement/) a [**Substituce písma**](https://docs.aspose.com/slides/cs/python-net/font-substitution/).

Toto je proces, který Aspose.Slides používá při práci s písmy:

1. Aspose.Slides vyhledá písma v operačním systému, aby našlo písmo, které odpovídá vybranému písmu v prezentaci.  
2. Pokud je vybrané písmo nalezeno, Aspose.Slides jej použije. V opačném případě Aspose.Slides použije náhradní písmo, které je co nejblíže tomu, co by použil PowerPoint.  
3. Pokud byla nastavena pravidla nahrazování písma přes [FontSubstRule](https://reference.aspose.com/slides/cs/python-net/aspose.slides/fontsubstrule/), jsou aplikována.

Aspose.Slides vám umožňuje přidávat písma do běhu aplikace a poté tato písma používat. Viz [**Vlastní písma**](https://docs.aspose.com/slides/cs/python-net/custom-font/).

Když jsou v prezentaci umístěna další písma, nazývají se [**Vložená písma**](https://docs.aspose.com/slides/cs/python-net/embedded-font/).

Aspose.Slides vám umožňuje přidávat písma, která se použijí **pouze** pro výstupní dokumenty. Například pokud prezentace, kterou chcete převést do PDF, obsahuje písma chybějící ve vašem systému a vložená písma, můžete přidat nebo načíst potřebná písma jako **externí písma**.

{{% alert title="Poznámka" color="primary" %}} 
Neš distribuujeme žádná písma, ať už placená nebo zdarma. Naše API vám umožňuje načíst externí písma a vložit je do dokumentů, ale děláte tak s písmy na vlastní uvážení a odpovědnost.
{{% /alert %}}

## **Často kladené otázky**

**Jak mohu zjistit, která písma jsou ve skutečnosti použita v prezentaci před konverzí?**

Aspose.Slides vám umožňuje prozkoumat použité písma pomocí [správce písem](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/fonts_manager/), takže můžete rozhodnout, zda [vložit](/slides/cs/python-net/embedded-font/), [nahradit](/slides/cs/python-net/font-replacement/) nebo přidat [externí zdroje](/slides/cs/python-net/custom-font/). To vám pomůže zabránit nechtěným substitucím během vykreslování a exportu.

**Mohu přidat další adresáře s písmy, aniž bych je instaloval do operačního systému?**

Ano. Můžete zaregistrovat [externí zdroje písem](/slides/cs/python-net/custom-font/), jako jsou složky nebo paměťové proudy, pro vykreslování a export. Tím odstraníte závislost na písmech hostitelského systému a zachováte předvídatelné rozvržení.

**Jak zabránit tichému přepnutí na nevhodné písmo, když chybí glif?**

Předem definujte explicitní [náhradu písma](/slides/cs/python-net/font-replacement/) a pravidla [fallback font](/slides/cs/python-net/fallback-font/). Analýzou použitých písem a nastavením řízené priority pro náhrady zajistíte konzistentní typografii a vyhnete se neočekávaným výsledkům.