---
title: Sekvence výběru písma v Aspose.Slides pro Python přes Java
linktitle: Výběr písma
type: docs
weight: 80
url: /cs/python-java/font-selection-sequence/
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
- Java
- Aspose.Slides
description: "Objevte, jak Aspose.Slides pro Python přes Java vybírá písma a zajišťuje ostré, konzistentní zobrazení souborů PPT, PPTX a ODP - vylepšete své snímky nyní."
---
## **Přehled**

Když je prezentace načtena, vykreslena nebo převedena do jiného formátu, Aspose.Slides kontroluje, zda jsou písma použité v prezentaci dostupná v operačním systému. Pokud požadované písmo chybí, Aspose.Slides vybere náhradní písmo, které je co nejblíže tomu, které by použil PowerPoint.

Aspose.Slides nejprve vyhledá vybrané písmo v operačním systému. Pokud je písmo nalezeno, použije se. Pokud není nalezeno, použije se vhodná náhrada. Pokud jsou pravidla pro substituci písma definována pomocí [FontSubstRule](https://reference.aspose.com/slides/cs/python-java/aspose.slides/fontsubstrule/), jsou tato pravidla také zohledněna.

Můžete také přidat písma v průběhu běhu aplikace, použít vložená písma z prezentace nebo načíst externí písma pro výstupní dokumenty, jako jsou PDF soubory.

## **Výběr písma**

Na písma v prezentaci se vztahují určitá pravidla při načítání, vykreslování nebo převodu do jiného formátu. Například když se pokusíte převést prezentaci (její snímky) na obrázky, jsou písma prezentace zkontrolována, aby se ověřilo, že vybraná písma jsou dostupná v operačním systému. Pokud jsou písma potvrzena jako chybějící, jsou nahrazena — viz [Font Replacement](/slides/cs/python-java/font-replacement/) a [Font Substitution](/slides/cs/python-java/font-substitution/).

Toto je postup, který Aspose.Slides používá při práci s písmy:

1. Aspose.Slides vyhledá písma v operačním systému, aby našel písmo, které odpovídá vybranému písmu v prezentaci.
2. Pokud je vybrané písmo nalezeno, Aspose.Slides jej použije. V opačném případě Aspose.Slides použije náhradní písmo, které je co nejblíže tomu, co by použil PowerPoint.
3. Pokud byla nastavena pravidla náhrady písma pomocí [FontSubstRule](https://reference.aspose.com/slides/cs/python-java/aspose.slides/fontsubstrule/), jsou aplikována.

Aspose.Slides vám umožňuje přidat písma během běhu aplikace a následně je použít. Viz [Custom fonts](/slides/cs/python-java/custom-font/).

Když jsou v prezentaci umístěna další písma, nazývají se [Embedded fonts](/slides/cs/python-java/embedded-font/).

Aspose.Slides vám umožňuje přidat písma, která jsou aplikována *pouze* na výstupní dokumenty. Například pokud prezentace, kterou chcete převést na PDF, používá písma, která nejsou nainstalována ve vašem systému ani vložena v prezentaci, můžete přidat nebo načíst potřebná písma jako **externí písma**.

{{% alert title="Note" color="info" %}}
Nevydáváme žádná písma, ať už placená nebo zdarma. Naše API vám umožňuje načíst externí písma a vložit je do dokumentů, ale děláte tak na své vlastní uvážení a odpovědnost.
{{% /alert %}}

## **FAQ**

**Jak mohu zjistit, která písma jsou v prezentaci skutečně použita před konverzí?**

Aspose.Slides vám umožňuje prozkoumat použité písma pomocí [font manager](https://reference.aspose.com/slides/cs/python-java/aspose.slides/fontsmanager/), takže můžete rozhodnout, zda [embed](/slides/cs/python-java/embedded-font/), [replace](/slides/cs/python-java/font-replacement/), nebo přidat [external sources](/slides/cs/python-java/custom-font/). To vám pomůže zabránit nechtěným substitucím během vykreslování a exportu.

**Mohu přidat další adresáře písem bez jejich instalace do operačního systému?**

Ano. Můžete zaregistrovat [external font sources](/slides/cs/python-java/custom-font/) například složky nebo paměťové proudy pro vykreslování a export. To odstraňuje závislost na písmenech hostitelského systému a udržuje rozložení předvídatelné.

**Jak zabránit tichému přechodu na nevhodné písmo, když chybí glyf?**

Definujte explicitní [font replacement](/slides/cs/python-java/font-replacement/) a [fallback rules](/slides/cs/python-java/fallback-font/) předem. Analýzou použitých písem a nastavením řízené priority pro náhrady zajistíte konzistentní typografii a vyhnete se neočekávaným výsledkům.