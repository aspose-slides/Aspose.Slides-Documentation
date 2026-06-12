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
description: "Objevte, jak Aspose.Slides pro C++ vybírá písma, aby zajistil ostrou a konzistentní prezentaci souborů PPT, PPTX a ODP — vylepšete své snímky nyní."
---
## **Přehled**

Když je prezentace načtena, vykreslena nebo převedena do jiného formátu, Aspose.Slides kontroluje, zda jsou písma použité v prezentaci dostupná v operačním systému. Pokud požadované písmo chybí, Aspose.Slides vybere náhradní písmo, které je co nejblíže tomu, které by použil PowerPoint.

Aspose.Slides nejprve vyhledá vybrané písmo v operačním systému. Pokud je písmo nalezeno, použije se. Pokud není nalezeno, použije se vhodná náhrada. Když jsou pravidla pro substituci písma definována pomocí `FontSubstRule`, jsou tato pravidla také zohledněna.

Můžete také přidávat písma za běhu aplikace, použít vložená písma z prezentace nebo načíst externí písma pro výstupní dokumenty, například PDF soubory.

## **Výběr písma**

Na písma v prezentaci se vztahují určitá pravidla při načtení, vykreslení nebo převodu prezentace do jiného formátu. Například když se pokusíte převést prezentaci (její snímky) na obrázky, písma v prezentaci jsou kontrolována, aby se ověřilo, že vybraná písma jsou dostupná v operačním systému. Pokud jsou písma potvrzena jako chybějící, jsou nahrazena — viz [**Font Replacement**](https://docs.aspose.com/slides/cs/cpp/font-replacement/) a [**Font Substitution**](https://docs.aspose.com/slides/cs/cpp/font-substitution/).

Toto je proces, který Aspose.Slides používá při práci s písmy:

1. Aspose.Slides vyhledává písma v operačním systému, aby našel písmo odpovídající vybranému písmu v prezentaci. 
2. Pokud je vybrané písmo nalezeno, Aspose.Slides jej použije. V opačném případě Aspose.Slides použije náhradní písmo, které je co nejblíže tomu, co by použil PowerPoint.
3. Pokud byly pravidla náhrady písma nastaveny pomocí [FontSubstRule](https://reference.aspose.com/slides/cs/cpp/aspose.slides/fontsubstrule/), jsou použita. 

Aspose.Slides vám umožňuje přidávat písma během běhu aplikace a poté je používat. Viz [**Custom fonts**](https://docs.aspose.com/slides/cs/cpp/custom-font/). 

Když jsou v prezentaci umístěna další písma, nazývají se [**Embedded fonts**](https://docs.aspose.com/slides/cs/cpp/embedded-font/).

Aspose.Slides vám umožňuje přidávat písma, která jsou použita *pouze* ve výstupních dokumentech. Například pokud prezentace, kterou chcete převést do PDF, obsahuje písma chybějící ve vašem systému a vložená písma, můžete potřebná písma přidat nebo načíst jako **externí písma**. 

{{% alert title="Note" color="primary" %}} 
Nezveřejňujeme žádná písma, ať už placená nebo zdarma. Naše API vám umožňuje načíst externí písma a vložit je do dokumentů, ale provádíte to s písmy podle vlastního uvážení a odpovědnosti.
{{% /alert %}}

## **FAQ**

**Jak mohu zjistit, která písma jsou v prezentaci skutečně používána před konverzí?**

Aspose.Slides vám umožňuje prozkoumat použita písma pomocí [font manager](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/get_fontsmanager/), takže můžete rozhodnout, zda [embed](/slides/cs/cpp/embedded-font/), [replace](/slides/cs/cpp/font-replacement/), nebo přidat [external sources](/slides/cs/cpp/custom-font/). To vám pomůže zabránit nechtěným substitucím během vykreslování a exportu.

**Mohu přidat extra adresáře s písmy bez jejich instalace do operačního systému?**

Ano. Můžete zaregistrovat [external font sources](/slides/cs/cpp/custom-font/) jako složky nebo paměťové proudy pro vykreslování a export. To odstraňuje závislost na písmech hostitelského systému a udržuje rozvržení předvídatelné.

**Jak zabránit tichému přepnutí na nevhodné písmo, když chybí glyph?**

Definujte předem explicitní [font replacement](/slides/cs/cpp/font-replacement/) a pravidla [fallBack](/slides/cs/cpp/fallback-font/) pro písma. Analýzou použitých písem a nastavením řízené priority pro náhrady zajistíte konzistentní typografii a vyhnete se neočekávaným výsledkům.