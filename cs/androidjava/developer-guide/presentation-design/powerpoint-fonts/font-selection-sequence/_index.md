---
title: Sekvence výběru fontů v Aspose.Slides pro Android pomocí Javy
linktitle: Výběr fontů
type: docs
weight: 80
url: /cs/androidjava/font-selection-sequence/
keywords:
- výběr fontů
- substituce fontů
- nahrazení fontů
- pravidlo substituce
- dostupný font
- chybějící font
- PowerPoint
- OpenDocument
- prezentace
- Android
- Java
- Aspose.Slides
description: "Objevte, jak Aspose.Slides pro Android pomocí Javy vybírá fonty, což zajišťuje ostrý a konzistentní vzhled PPT, PPTX a ODP souborů—vylepšete své snímky již nyní."
---
## **Přehled**

Když je prezentace načtena, vykreslena nebo převedena do jiného formátu, Aspose.Slides kontroluje, zda jsou písma použité v prezentaci dostupná v operačním systému. Pokud chybí požadované písmo, Aspose.Slides vybere náhradní písmo, které je co nejvíce podobné tomu, které by použil PowerPoint.

Aspose.Slides nejprve hledá vybrané písmo v operačním systému. Pokud je písmo nalezeno, použije se. Pokud není nalezeno, použije se vhodná náhrada. Když jsou pravidla substituce písma definována pomocí `FontSubstRule`, jsou tato pravidla také zohledněna.

Můžete také přidávat písma během běhu aplikace, použít vnořená písma z prezentace nebo načíst externí písma pro výstupní dokumenty, jako jsou PDF soubory.

## **Výběr písma**

Na písma v prezentaci se vztahují určitá pravidla při načítání, vykreslování nebo konverzi do jiného formátu. Například když se pokoušíte převést prezentaci (její snímky) na obrázky, jsou písma v prezentaci zkontrolována, aby se ověřilo, že vybraná písma jsou dostupná v operačním systému. Pokud jsou písma potvrzena jako chybějící, jsou nahrazena — viz [**Nahrazení fontů**](https://docs.aspose.com/slides/cs/androidjava/font-replacement/) a [**Substituce fontů**](https://docs.aspose.com/slides/cs/androidjava/font-substitution/).

Postup, který Aspose.Slides při práci s písmy používá, je následující:

1. Aspose.Slides hledá písma v operačním systému, aby našlo písmo, které odpovídá vybranému písmu v prezentaci.  
2. Pokud je vybrané písmo nalezeno, Aspose.Slides jej použije. V opačném případě Aspose.Slides použije náhradní písmo, které je co nejvíce podobné tomu, co by použil PowerPoint.  
3. Pokud byly nastaveny pravidla nahrazení písma pomocí [FontSubstRule](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/fontsubstrule/), jsou aplikována.

Aspose.Slides vám umožňuje přidat písma během běhu aplikace a poté je použít. Viz [**Vlastní fonty**](https://docs.aspose.com/slides/cs/androidjava/custom-font/).

Když jsou v prezentaci umístěna další písma, nazývají se [**Vnořené fonty**](https://docs.aspose.com/slides/cs/androidjava/embedded-font/).

Aspose.Slides vám umožňuje přidat písma, která jsou aplikována **pouze** na výstupní dokumenty. Například pokud prezentace, kterou chcete převést do PDF, obsahuje písma chybějící ve vašem systému a vnořená písma, můžete potřebná písma přidat nebo načíst jako **externí fonty**.

{{% alert title="Poznámka" color="info" %}} 
Nešleme žádná písma, ať už placená nebo zdarma. Naše API vám umožňuje načíst externí písma a vložit je do dokumentů, ale děláte tak s fonty na vlastní odpovědnost a podle vlastního uvážení.
{{% /alert %}}

## **Často kladené otázky**

### Jak mohu zjistit, které fonty jsou ve skutečnosti použity v prezentaci před konverzí?

Aspose.Slides vám umožňuje prozkoumat použité fonty pomocí [font manageru](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/fontsmanager/), takže můžete rozhodnout, zda [vložit](/slides/cs/androidjava/embedded-font/), [nahradit](/slides/cs/androidjava/font-replacement/) nebo přidat [externí zdroje](/slides/cs/androidjava/custom-font/). To vám pomůže zabránit nechtěným substitucím během vykreslování a exportu.

### Mohu přidat další složky s fonty bez jejich instalace v operačním systému?

Ano. Můžete registrovat [externí zdroje fontů](/slides/cs/androidjava/custom-font/), například složky nebo paměťové proudy, pro vykreslování a export. Tím se odstraní závislost na systémových fontech a zachová se předvídatelná podoba rozvržení.

### Jak zabránit tichému přepnutí na nevhodné písmo, když chybí glyph?

Definujte předem explicitní [nahrazení fontů](/slides/cs/androidjava/font-replacement/) a pravidla [fallback fontů](/slides/cs/androidjava/fallback-font/). Analýzou použitých fontů a nastavením řízené priority pro náhrady zajistíte konzistentní typografii a vyhnete se neočekávaným výsledkům.