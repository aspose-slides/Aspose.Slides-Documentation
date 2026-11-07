---
title: Sekvence výběru písem v Aspose.Slides pro .NET
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
description: "Objevte, jak Aspose.Slides pro .NET vybírá písma, zajišťuje ostrou, konzistentní prezentaci souborů PPT, PPTX a ODP — zlepšete své snímky nyní."
---
## **Přehled**

Když je prezentace načtena, vykreslena nebo převedena do jiného formátu, Aspose.Slides zohledňuje její vložená písma a písma dostupná aplikaci. Pokud požadované písmo není k dispozici, Aspose.Slides vybere náhradní písmo, které je co nejvíce podobné tomu, které by použil PowerPoint.

Dostupná písma mohou zahrnovat systémová písma, písma načtená aplikací a písma vložená v prezentaci. Pro shodná vložená a registrovaná písma řídí níže popsaná předvolba .NET 26.11, která má přednost. Pravidla náhrady písem definovaná pomocí [FontSubstRule](https://reference.aspose.com/slides/net/aspose.slides/fontsubstrule/) jsou samostatný mechanismus.

Můžete také přidávat písma během běhu aplikace, používat vložená písma z prezentace nebo načítat externí písma pro výstupní dokumenty, například soubory PDF.

## **Výběr písma**

Text může odkazovat na motivové písmo, například `+mn-lt`, namísto explicitního názvu rodiny. Viz [Rozpoznání odkazů na motivová písma](/slides/cs/net/presentation-theme/#resolve-theme-font-references) pro získání rodiny určené příslušným motivem. Vyřešení tohoto odkazu je oddělené od kontroly dostupnosti písem a aplikace náhrady během vykreslování nebo náhradního glyphu; neidentifikuje soubor písma, který je nakonec použit k vykreslení textu.

Při vykreslování snímků nebo převodu prezentace zkontrolujte, zda požadovaná písma jsou vložena nebo dostupná z registrovaných zdrojů. Chybějící písma mohou vyžadovat náhradu nebo substituci; viz [**Náhrada písma**](/slides/cs/net/font-replacement/) a [**Substituce písma**](/slides/cs/net/font-substitution/).

Při zkoumání výběru písma:

1. Vyřešte požadovanou rodinu a styl, včetně jakéhokoli odkazu na motiv.
2. Zkontrolujte vložená písma a registrované zdroje, včetně systémových písem a písem načtených aplikací. Použijte níže uvedenou předvolbu, pokud soutěží shodná vložená a registrovaná verze.
3. Prohlédněte si [pravidla substituce písem](https://reference.aspose.com/slides/net/aspose.slides/fontsubstrule/) a náhradu glyphů, pokud požadované písmo nebo znaky nejsou k dispozici.

Aspose.Slides vám umožňuje přidávat písma během běhu aplikace a poté tato písma používat. Viz [**Vlastní písma**](/slides/cs/net/custom-font/).

Když jsou do prezentace vloženy další písma, nazývají se [**Vložená písma**](/slides/cs/net/embedded-font/).

Aspose.Slides vám umožňuje přidat písma, která jsou aplikována *pouze* na výstupní dokumenty. Například pokud prezentace, kterou chcete převést do PDF, obsahuje písma chybějící ve vašem systému a ve vložených písmech, můžete potřebná písma přidat nebo načíst jako **externí písma**.

{{% alert title="Note" color="info" %}} 
Nedistribuujeme žádná písma, ani placená, ani zdarma. Naše API vám umožňuje načíst externí písma a vložit je do dokumentů, ale děláte tak s písmami na své vlastní uvážení a odpovědnost.
{{% /alert %}}

## **Preferování registrovaných písem před vloženými písmy**

Od verze .NET 26.11 umožňuje [IFontsManager.PreferRegisteredFontsOverEmbedded](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/preferregisteredfontsoverembedded/) nechat shodné registrované písmo mít přednost před vloženým písmem během exportu. Výchozí hodnota je `false`. Shoda používá název písma a styl; jiný název rodiny není shodná náhrada. Registrovaná písma mohou pocházet ze systému nebo z [explicitně načtených zdrojů písem](/slides/cs/net/custom-font/).

Následující příklad používá balíček **Aspose.Slides.NET6.CrossPlatform 26.11** na .NET 8. Postupujte podle [průvodce instalací](/slides/cs/net/installation/) pro své prostředí. Poskytněte `embedded-fonts.pptx` s vloženým písmem a `preferred.ttf` se stejným názvem rodiny a stylem. Oba soubory písem by se měly viditelně lišit, pokud chcete porovnat výstup.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

var fontBytes = File.ReadAllBytes("preferred.ttf");
FontsLoader.LoadExternalFont(fontBytes);
using var presentation = new Presentation("embedded-fonts.pptx");

presentation.FontsManager.PreferRegisteredFontsOverEmbedded = false;
presentation.Save("embedded-preference.pdf", SaveFormat.Pdf);

presentation.FontsManager.PreferRegisteredFontsOverEmbedded = true;
presentation.Save("registered-preference.pdf", SaveFormat.Pdf);

presentation.FontsManager.PreferRegisteredFontsOverEmbedded = false;
presentation.Save("restored-preference.pdf", SaveFormat.Pdf);
```

Toto nastavení mění prioritu písem během exportu; nepřejmenuje písmo textu, neodstraní data vloženého písma ani neprovádí opětovné vložení registrovaného souboru. Jedná se o nastavení za běhu: nastavte jej znovu po opětovném otevření prezentace. Pokud není k dispozici žádné shodné registrované písmo, povolení předvolby žádné nepřidá; ověřte výsledné písmo a rozvržení ve svém cílovém prostředí.

Výstup PNG a PDF s explicitně načtenými běžnými písmy byl zkontrolován pro výše uvedenou konfiguraci. Zkontrolujte své vlastní soubory písem, styly, sestavení SDK a výstupní formáty, než se budete spoléhat na identické výsledky. Metrička písem může měnit zalomení řádků a umístění. Použijte [náhradu písem](/slides/cs/net/font-replacement/) nebo [substituci](/slides/cs/net/font-substitution/) když potřebujete jinou rodinu, a [operace s vloženými písmy](/slides/cs/net/embedded-font/) když potřebujete změnit písma uložená v prezentaci.

## **Často kladené otázky**

**Jak mohu zjistit, která písma jsou ve skutečnosti v prezentaci použita před konverzí?**

Aspose.Slides vám umožňuje prozkoumat použitá písma prostřednictvím [správce písem](https://reference.aspose.com/slides/net/aspose.slides/presentation/fontsmanager/), takže můžete rozhodnout, zda [vložit](/slides/cs/net/embedded-font/), [nahradit](/slides/cs/net/font-replacement/), nebo přidat [externí zdroje](/slides/cs/net/custom-font/). To vám pomůže zabránit nechtěným substitucím během vykreslování a exportu.

**Mohu přidat další adresáře s písmy, aniž bych je instaloval do operačního systému?**

Ano. Můžete registrovat [externí zdroje písem](/slides/cs/net/custom-font/) jako složky nebo paměťové proudy pro vykreslování a export. Toto odstraňuje závislost na písmech hostitelského systému a udržuje rozvržení předvídatelné.

**Jak zabráním tichému přechodu na nevhodné písmo, když chybí glyph?**

Definujte explicitně [náhradu písem](/slides/cs/net/font-replacement/) a [pravidla fallbacku](/slides/cs/net/fallback-font/) předem. Analýzou použitých písem a nastavením řízené priority pro náhrady zajistíte konzistentní typografii a vyhnete se neočekávaným výsledkům.