---
title: Pořadí výběru písem v Aspose.Slides pro Android pomocí Javy
linktitle: Výběr písma
type: docs
weight: 80
url: /cs/androidjava/font-selection-sequence/
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
- Android
- Java
- Aspose.Slides
description: "Objevte, jak Aspose.Slides pro Android pomocí Javy vybírá písma, zajišťuje ostrou a konzistentní prezentaci souborů PPT, PPTX a ODP — vylepšete své snímky nyní."
---
## **Přehled**

Když je prezentace načtena, vykreslena nebo převedena do jiného formátu, Aspose.Slides kontroluje, zda jsou písma použité v prezentaci dostupná v operačním systému. Pokud požadované písmo chybí, Aspose.Slides vybere náhradní písmo, které je co nejblíže tomu, které by použil PowerPoint.

Aspose.Slides nejprve vyhledá vybrané písmo v operačním systému. Pokud je písmo nalezeno, použije se. Pokud není nalezeno, použije se vhodná náhrada. Když jsou pravidla pro substituci písem definována pomocí `FontSubstRule`, jsou tato pravidla také zohledněna.

Můžete také přidat písma během běhu aplikace, použít vložená písma z prezentace nebo načíst externí písma pro výstupní dokumenty, jako jsou PDF soubory.

## **Výběr písma**

Na písma v prezentaci se vztahují určitá pravidla, když je prezentace načtena, vykreslena nebo převedena do jiného formátu. Například když se pokoušíte převést prezentaci (její snímky) na obrázky, jsou písma v prezentaci kontrolována, aby se ověřilo, že vybraná písma jsou dostupná v operačním systému. Pokud jsou písma potvrzena jako chybějící, jsou nahrazena — viz [**Font Replacement**](https://docs.aspose.com/slides/cs/androidjava/font-replacement/) a [**Font Substitution**](https://docs.aspose.com/slides/cs/androidjava/font-substitution/).

Toto je proces, který Aspose.Slides následuje při práci s písmy:

1. Aspose.Slides vyhledává písma v operačním systému, aby našel písmo odpovídající vybranému písmu v prezentaci. 
2. Pokud je vybrané písmo nalezeno, Aspose.Slides jej použije. V opačném případě Aspose.Slides použije náhradní písmo, které je co nejblíže tomu, co by použil PowerPoint.
3. Pokud byla pravidla náhrady písem nastavena pomocí [FontSubstRule](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/fontsubstrule/), jsou použita.

Aspose.Slides vám umožňuje přidat písma během běhu aplikace a poté je použít. Viz [**Custom fonts**](https://docs.aspose.com/slides/cs/androidjava/custom-font/).

Když jsou v prezentaci umístěna další písma, nazývají se [**Embedded fonts**](https://docs.aspose.com/slides/cs/androidjava/embedded-font/).

Aspose.Slides vám umožňuje přidat písma, která jsou použita pouze ve výstupních dokumentech. Například pokud prezentace, kterou chcete převést do PDF, obsahuje písma chybějící ve vašem systému a vložená písma, můžete potřebná písma přidat nebo načíst jako **externí písma**.

{{% alert title="Note" color="primary" %}} 
Nešíříme žádná písma, ať už placená nebo bezplatná. Naše API vám umožňuje načíst externí písma a vložit je do dokumentů, ale děláte tak s písy na vlastní uvážení a odpovědnost.
{{% /alert %}}

## **Často kladené otázky**

**Jak mohu zjistit, která písma jsou v prezentaci skutečně použita před převodem?**

Aspose.Slides vám umožňuje prozkoumat použitá písma prostřednictvím [font manager](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/fontsmanager/), takže můžete rozhodnout, zda [embed](/slides/cs/androidjava/embedded-font/), [replace](/slides/cs/androidjava/font-replacement/), nebo přidat [external sources](/slides/cs/androidjava/custom-font/). To vám pomůže zabránit nechtěným substitucím během vykreslování a exportu.

**Mohu přidat další adresáře s písmy bez jejich instalace do operačního systému?**

Ano. Můžete zaregistrovat [external font sources](/slides/cs/androidjava/custom-font/), jako jsou složky nebo paměťové proudy, pro vykreslování a export. Tím se odstraní závislost na písmenech hostitelského systému a zachová se předvídatelné rozložení.

**Jak zabránit tichému přechodu na nevhodné písmo, když chybí glyf?**

Definujte předem explicitní [font replacement](/slides/cs/androidjava/font-replacement/) a font [fallback rules](/slides/cs/androidjava/fallback-font/). Analýzou použitých písem a nastavením řízené priority pro náhrady zajistíte konzistentní typografii a vyhnete se nečekaným výsledkům.