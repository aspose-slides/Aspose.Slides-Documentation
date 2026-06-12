---
title: Sekvence výběru písem v Aspose.Slides pro PHP
linktitle: Výběr písem
type: docs
weight: 80
url: /cs/php-java/font-selection-sequence/
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
- PHP
- Aspose.Slides
description: "Objevte, jak Aspose.Slides pro PHP přes Java vybírá písma, což zajišťuje jasnou a konzistentní prezentaci souborů PPT, PPTX a ODP — vylepšete své snímky nyní."
---
## **Přehled**

Když je prezentace načtena, vykreslena nebo převedena do jiného formátu, Aspose.Slides kontroluje, zda jsou v operačním systému dostupná písma použitá v prezentaci. Pokud požadované písmo chybí, Aspose.Slides vybere náhradní písmo, které je co možná nejblíže tomu, které by použil PowerPoint.

Aspose.Slides nejprve vyhledá vybrané písmo v operačním systému. Pokud je písmo nalezeno, použije se. Pokud není nalezeno, použije se vhodná náhrada. Když jsou pravidla pro substituci písem definována pomocí `FontSubstRule`, jsou tato pravidla také zohledněna.

Můžete také přidat písma během běhu aplikace, použít vložená písma z prezentace nebo načíst externí písma pro výstupní dokumenty, například PDF soubory.

## **Výběr písma**

Na písma v prezentaci se vztahují určitá pravidla, když je prezentace načtena, vykreslena nebo převedena do jiného formátu. Například když se snažíte převést prezentaci (její snímky) na obrázky, jsou písma prezentace zkontrolována, aby se ověřilo, že vybraná písma jsou dostupná v operačním systému. Pokud jsou písma potvrzena jako chybějící, jsou nahrazena — viz [**Náhrada písma**](https://docs.aspose.com/slides/cs/php-java/font-replacement/) a [**Substituce písma**](https://docs.aspose.com/slides/cs/php-java/font-substitution/).

Postup, který Aspose.Slides při práci s písmy používá, je následující:

1. Aspose.Slides vyhledá písma v operačním systému, aby našel písmo, které odpovídá vybranému písmu v prezentaci.  
2. Pokud je vybrané písmo nalezeno, Aspose.Slides jej použije. V opačném případě Aspose.Slides použije náhradní písmo, které je co nejblíže tomu, co by použil PowerPoint.  
3. Pokud byly nastaveny pravidla náhrady písem pomocí [FontSubstRule](https://reference.aspose.com/slides/cs/php-java/aspose.slides/fontsubstrule/), jsou aplikována.

Aspose.Slides vám umožňuje přidat písma do runtime Aspose a poté tato písma použít. Viz [**Vlastní písma**](https://docs.aspose.com/slides/cs/php-java/custom-font/).

Když jsou v prezentaci umístěna další písma, nazývají se [**Vložená písma**](https://docs.aspose.com/slides/cs/php-java/embedded-font/).

Aspose.Slides vám umožňuje přidat písma, která jsou aplikována **pouze** na výstupní dokumenty. Například pokud prezentace, kterou chcete převést do PDF, obsahuje písma chybějící ve vašem systému a vložená písma, můžete přidat nebo načíst potřebná písma jako **Externí písma**.

## **Často kladené otázky**

**Jak mohu zjistit, která písma jsou ve skutečnosti použita v prezentaci před převodem?**

Aspose.Slides vám umožňuje prozkoumat použité písma pomocí [správce písem](https://reference.aspose.com/slides/cs/php-java/aspose.slides/fontsmanager/), takže můžete rozhodnout, zda [vložit](/slides/cs/php-java/embedded-font/), [nahradit](/slides/cs/php-java/font-replacement/) nebo přidat [externí zdroje](/slides/cs/php-java/custom-font/). To vám pomůže zabránit nechtěným substitucím během vykreslování a exportu.

**Mohu přidat další adresáře s písmy, aniž bych je instaloval do operačního systému?**

Ano. Můžete zaregistrovat [externí zdroje písem](/slides/cs/php-java/custom-font/), jako jsou složky nebo paměťové proudy, pro vykreslování a export. Tím se odstraní závislost na písmatech hostitelského systému a zachová se předvídatelné rozvržení.

**Jak zabránit tichému přepnutí na nevhodné písmo, když chybí glyf?**

Předem definujte explicitní [náhradu písma](/slides/cs/php-java/font-replacement/) a pravidla [záložního písma](/slides/cs/php-java/fallback-font/). Analýzou používaných písem a nastavením řízené priority pro substituty zajistíte konzistentní typografii a vyhnete se neočekávaným výsledkům.