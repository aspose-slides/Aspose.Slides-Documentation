---
title: Sekvence výběru písem v Aspose.Slides pro Java
linktitle: Výběr písem
type: docs
weight: 80
url: /cs/java/font-selection-sequence/
keywords:
- výběr písem
- substituce písem
- nahrazení písem
- pravidlo substituce
- dostupné písmo
- chybějící písmo
- PowerPoint
- OpenDocument
- prezentace
- Java
- Aspose.Slides
description: "Objevte, jak Aspose.Slides pro Java vybírá písma, aby zajistil ostrou a konzistentní prezentaci souborů PPT, PPTX a ODP — vylepšete své snímky nyní."
---
## **Přehled**

Když je prezentace načtena, vykreslena nebo převedena do jiného formátu, Aspose.Slides kontroluje, zda jsou písma použita v prezentaci dostupná v operačním systému. Pokud chybí požadované písmo, Aspose.Slides vybere náhradní písmo, které je co nejvíce podobné tomu, které by použil PowerPoint.

Aspose.Slides nejprve vyhledá vybrané písmo v operačním systému. Pokud je písmo nalezeno, použije se. Pokud není nalezeno, použije se vhodná náhrada. Když jsou pravidla substituce písma definována pomocí `FontSubstRule`, jsou tato pravidla také zohledněna.

Můžete také přidávat písma za běhu aplikace, používat vložená písma z prezentace nebo načítat externí písma pro výstupní dokumenty, jako jsou PDF soubory.

## **Výběr písem**

Na písma v prezentaci se vztahují určitá pravidla, když je prezentace načtena, vykreslena nebo převedena do jiného formátu. Například když se pokusíte převést prezentaci (její snímky) na obrázky, písma prezentace jsou zkontrolována, aby se ověřilo, že vybraná písma jsou dostupná v operačním systému. Pokud jsou písma potvrzena jako chybějící, jsou nahrazena — viz [**Nahrazení písem**](https://docs.aspose.com/slides/cs/java/font-replacement/) a [**Substituce písem**](https://docs.aspose.com/slides/cs/java/font-substitution/).

Tento proces Aspose.Slides používá při práci s písmy:

1. Aspose.Slides vyhledává písma v operačním systému, aby našlo písmo, které odpovídá vybranému písmu v prezentaci. 
2. Pokud je vybrané písmo nalezeno, Aspose.Slides jej použije. V opačném případě Aspose.Slides použije náhradní písmo, které je co nejblíže tomu, co by použil PowerPoint.
3. Pokud byla pravidla nahrazení písem nastavena pomocí [FontSubstRule](https://reference.aspose.com/slides/cs/java/com.aspose.slides/fontsubstrule/), jsou použita. 

Aspose.Slides vám umožňuje přidávat písma během běhu aplikace a pak tato písma používat. Viz [**Vlastní písma**](https://docs.aspose.com/slides/cs/java/custom-font/). 

Když jsou v prezentaci umístěna další písma, nazývají se [**Vložená písma**](https://docs.aspose.com/slides/cs/java/embedded-font/).

Aspose.Slides vám umožňuje přidávat písma, která jsou použita *pouze* pro výstupní dokumenty. Například pokud prezentace, kterou chcete převést do PDF, obsahuje písma chybějící ve vašem systému a vložená písma, můžete potřebná písma přidat nebo načíst jako **externí písma**. 

{{% alert title="Note" color="primary" %}} 
Nešleme žádná písma, ani placená ani zdarma. Naše API vám umožňuje načíst externí písma a vložit je do dokumentů, ale to provádíte s písmami podle vlastní volby a odpovědnosti.
{{% /alert %}}

## **Často kladené otázky**

**Jak mohu zjistit, která písma jsou ve prezentaci skutečně použita před konverzí?**

Aspose.Slides vám umožňuje zkontrolovat použitá písma pomocí [správce písem](https://reference.aspose.com/slides/cs/java/com.aspose.slides/fontsmanager/), takže můžete rozhodnout, zda [vložit](/slides/cs/java/embedded-font/), [nahradit](/slides/cs/java/font-replacement/) nebo přidat [externí zdroje](/slides/cs/java/custom-font/). To vám pomůže předejít nechtěným substitucím během vykreslování a exportu.

**Mohu přidat další adresáře s písmy bez jejich instalace do operačního systému?**

Ano. Můžete zaregistrovat [externí zdroje písem](/slides/cs/java/custom-font/) jako složky nebo paměťové proudy pro vykreslování a export. Tím odstraníte závislost na písmatech hostitelského systému a zachováte předvídatelné rozvržení.

**Jak zabránit tichému přepnutí na nevhodné písmo, když chybí znak?**

Definujte předem explicitní [nahrazení písem](/slides/cs/java/font-replacement/) a [pravidla pro náhradní písma](/slides/cs/java/fallback-font/). Analýzou použitého písma a nastavením řízené priority pro substituty zajistíte konzistentní typografii a vyhnete se neočekávaným výsledkům.