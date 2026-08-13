---
title: Sekvence výběru písma v Aspose.Slides pro Java
linktitle: Výběr písma
type: docs
weight: 80
url: /cs/java/font-selection-sequence/
keywords:
- výběr písma
- záměna písma
- náhrada písma
- pravidlo záměny
- dostupné písmo
- chybějící písmo
- PowerPoint
- OpenDocument
- prezentace
- Java
- Aspose.Slides
description: "Objevte, jak Aspose.Slides pro Java vybírá písma, což zajišťuje ostrou a konzistentní prezentaci souborů PPT, PPTX a ODP — vylepšete své snímky nyní."
---
## **Přehled**

Když je prezentace načtena, vykreslena nebo převedena do jiného formátu, Aspose.Slides kontroluje, zda jsou písma použité v prezentaci dostupná v operačním systému. Pokud požadované písmo chybí, Aspose.Slides vybere náhradní písmo, které je co nejblíže tomu, které by použil PowerPoint.

Aspose.Slides nejprve vyhledá vybrané písmo v operačním systému. Pokud je písmo nalezeno, použije se. Pokud není nalezeno, použije se vhodná náhrada. Když jsou pravidla záměny písma definována pomocí `FontSubstRule`, jsou tato pravidla také zohledněna.

Můžete také přidávat písma během běhu aplikace, použít zabudovaná písma z prezentace nebo načíst externí písma pro výstupní dokumenty, například PDF soubory.

## **Výběr písma**

Na písma v prezentaci se aplikují určitá pravidla, když je prezentace načtena, vykreslena nebo převedena do jiného formátu. Například když se pokoušíte převést prezentaci (její snímky) na obrázky, písma prezentace jsou zkontrolována, aby se ověřilo, že vybraná písma jsou dostupná v operačním systému. Pokud je potvrzeno, že písma chybí, jsou nahrazena – viz [**Náhrada písma**](https://docs.aspose.com/slides/cs/java/font-replacement/) a [**Záměna písma**](https://docs.aspose.com/slides/cs/java/font-substitution/).

Toto je proces, který Aspose.Slides používá při práci s písmy:

1. Aspose.Slides vyhledává písma v operačním systému, aby našlo písmo, které odpovídá vybranému písmu v prezentaci. 
2. Pokud je vybrané písmo nalezeno, Aspose.Slides jej použije. V opačném případě Aspose.Slides použije náhradní písmo, které je co nejblíže tomu, co by použil PowerPoint.
3. Pokud byla pravidla náhrady písma nastavena pomocí [FontSubstRule](https://reference.aspose.com/slides/cs/java/com.aspose.slides/fontsubstrule/), jsou aplikována. 

Aspose.Slides vám umožňuje přidávat písma během běhu aplikace a následně je používat. Viz [**Vlastní písma**](https://docs.aspose.com/slides/cs/java/custom-font/). 

Když jsou v prezentaci umístěna další písma, nazývají se [**Zabudovaná písma**](https://docs.aspose.com/slides/cs/java/embedded-font/).

Aspose.Slides vám umožňuje přidávat písma, která jsou použita *pouze* ve výstupních dokumentech. Například pokud prezentace, kterou chcete převést do PDF, obsahuje písma chybějící ve vašem systému a zabudovaná písma, můžete potřebná písma přidat nebo načíst jako **externí písma**. 

{{% alert title="Poznámka" color="info" %}} 
Distribuujeme žádná písma, ať už placená nebo zdarma. Naše API vám umožňuje načíst externí písma a zabudovat je do dokumentů, ale činíte tak na vlastní odpovědnost a podle vlastního uvážení.
{{% /alert %}}

## **Často kladené otázky**

### Jak mohu zjistit, která písma jsou v prezentaci skutečně použita před konverzí?

Aspose.Slides vám umožňuje prozkoumat použitá písma prostřednictvím [správce písem](https://reference.aspose.com/slides/cs/java/com.aspose.slides/fontsmanager/), takže můžete rozhodnout, zda [zabudovat](/slides/cs/java/embedded-font/), [nahradit](/slides/cs/java/font-replacement/), nebo přidat [externí zdroje](/slides/cs/java/custom-font/). To vám pomáhá zabránit nechtěným záměnám během vykreslování a exportu.

### Můžu přidat další adresáře s písmy, aniž bych je instaloval do operačního systému?

Ano. Můžete zaregistrovat [externí zdroje písem](/slides/cs/java/custom-font/) jako složky nebo paměťové toky pro vykreslování a export. Tím odstraníte závislost na písmech hostitelského systému a udržíte předvídatelné rozvržení.

### Jak zabránit tichému přechodu na nevhodné písmo, když chybí znak (glyph)?

Definujte předem explicitní [náhradu písma](/slides/cs/java/font-replacement/) a [pravidla záložních písem](/slides/cs/java/fallback-font/). Analýzou použitých písem a nastavením řízené priority pro náhrady zajistíte konzistentní typografii a vyhnete se neočekávaným výsledkům.