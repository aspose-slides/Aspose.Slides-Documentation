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
description: "Zjistěte, jak Aspose.Slides pro C++ vybírá písma, aby zajistil ostrou a konzistentní prezentaci souborů PPT, PPTX a ODP — vylepšete své snímky nyní."
---
## **Přehled**

Když je prezentace načtena, vykreslena nebo převedena do jiného formátu, Aspose.Slides kontroluje, zda jsou písma použité v prezentaci dostupná v operačním systému. Pokud požadované písmo chybí, Aspose.Slides vybere nahrazující písmo, které je co nejblíže tomu, které by použil PowerPoint.

Aspose.Slides nejprve vyhledá vybrané písmo v operačním systému. Pokud je písmo nalezeno, použije se. Pokud není nalezeno, použije se vhodné nahrazení. Když jsou pravidla nahrazování písma definována pomocí `FontSubstRule`, jsou tato pravidla také zohledněna.

Také můžete přidávat písma během běhu aplikace, používat vložená písma z prezentace nebo načíst externí písma pro výstupní dokumenty, jako jsou soubory PDF.

## **Výběr písma**

Na písma v prezentaci se vztahují určitá pravidla, když je prezentace načtena, vykreslena nebo převedena do jiného formátu. Například když se pokusíte převést prezentaci (její snímky) na obrázky, písma v prezentaci jsou kontrolována, aby se ověřilo, že zvolená písma jsou dostupná v operačním systému. Pokud jsou písma potvrzena jako chybějící, jsou nahrazena — viz [**Náhrada písma**](https://docs.aspose.com/slides/cs/cpp/font-replacement/) a [**Substituce písma**](https://docs.aspose.com/slides/cs/cpp/font-substitution/).

Toto je proces, který Aspose.Slides používá při práci s písmy:

1. Aspose.Slides vyhledává písma v operačním systému, aby našel písmo, které odpovídá zvolenému písmu v prezentaci. 
2. Pokud je zvolené písmo nalezeno, Aspose.Slides jej použije. V opačném případě Aspose.Slides použije náhradní písmo, které je co nejblíže tomu, co by použil PowerPoint.
3. Pokud byly nastavena pravidla nahrazování písma prostřednictvím [FontSubstRule](https://reference.aspose.com/slides/cs/cpp/aspose.slides/fontsubstrule/), jsou aplikována. 

Aspose.Slides vám umožňuje přidávat písma během běhu aplikace a poté je používat. Viz [**Vlastní písma**](https://docs.aspose.com/slides/cs/cpp/custom-font/). 

Když jsou v prezentaci umístěna další písma, označují se jako [**Vložená písma**](https://docs.aspose.com/slides/cs/cpp/embedded-font/).

Aspose.Slides vám umožňuje přidávat písma, která jsou použita *pouze* pro výstupní dokumenty. Například pokud prezentace, kterou chcete převést do PDF, obsahuje písma chybějící ve vašem systému a vložená písma, můžete přidat nebo načíst potřebná písma jako **externí písma**.

{{% alert title="Note" color="info" %}} 
Nedistribuujeme žádná písma, ať už placená nebo zdarma. Naše API vám umožňuje načíst externí písma a vložit je do dokumentů, ale činíte tak s písmy na vlastní uvážení a odpovědnost.
{{% /alert %}}

## **Často kladené otázky**

### Jak mohu zjistit, která písma jsou v prezentaci skutečně použita před konverzí?

Aspose.Slides vám umožňuje prohlédnout použité fonty prostřednictvím [font manager](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/get_fontsmanager/), takže můžete rozhodnout, zda [vložit](/slides/cs/cpp/embedded-font/), [nahradit](/slides/cs/cpp/font-replacement/), nebo přidat [externí zdroje](/slides/cs/cpp/custom-font/). To vám pomůže zabránit nechtěným substitucím během vykreslování a exportu.

### Mohu přidat další složky s fonty, aniž bych je instaloval do operačního systému?

Ano. Můžete registrovat [externí zdroje fontů](/slides/cs/cpp/custom-font/) jako složky nebo paměťové proudy pro vykreslování a export. To odstraňuje závislost na fontech hostitelského systému a zachovává předvídatelné rozložení.

### Jak zabránit tichému přepnutí na nevhodné písmo, když chybí glyf?

Definujte explicitně [nahrazení fontu](/slides/cs/cpp/font-replacement/) a pravidla [fallback fontu](/slides/cs/cpp/fallback-font/) předem. Analýzou použitých fontů a nastavením řízené priority pro náhrady zajistíte konzistentní typografii a vyhnete se neočekávaným výsledkům.