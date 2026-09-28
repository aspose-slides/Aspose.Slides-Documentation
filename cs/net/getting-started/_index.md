---
title: Začínáme
type: docs
weight: 10
url: /cs/net/getting-started/
keywords:
- začínáme
- systémové požadavky
- instalace
- první prezentace
- NuGet
- zpracování PPT
- zpracování PPTX
- zpracování ODP
- PowerPoint
- OpenDocument
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Cesta od nového .NET projektu k první uložené prezentaci s Aspose.Slides: zkontrolujte požadavky, nainstalujte balíček, spusťte první program a pokračujte ve společných úkolech."
---
## **Přehled**

Proveďte níže uvedené čtyři kroky v pořádku. Každý krok uvádí, co dělat, a odkazuje na článek s podrobnostmi. Hodnocení, licencování a podpora jsou popsány po krocích.

## **Krok 1: Zkontrolujte systémové požadavky**

Aspose.Slides for .NET běží na Windows, Linuxu a macOS. [System Requirements](/slides/cs/net/system-requirements/) uvádí operační systémy a verze .NET, které každý balíček podporuje, a knihovny, které Linux potřebuje navíc.

## **Krok 2: Instalace balíčku**

Aspose.Slides for .NET je distribuováno přes NuGet ve dvou balíčcích, které poskytují stejné třídy. Přidejte jeden z nich do svého projektu:

- Na Windows: `dotnet add package Aspose.Slides.NET`
- Na Linuxu a macOS: `dotnet add package Aspose.Slides.NET6.CrossPlatform`. Na Linuxu nejprve nainstalujte knihovnu `fontconfig`.
- Na Alpine Linux a na Linuxových systémech, jejichž glibc je starší než 2.23 (x64) nebo 2.39 (ARM64): Aspose.Slides.NET s nainstalovanou knihovnou `libgdiplus`.

[Installation](/slides/cs/net/installation/) uvádí linuxové příkazy, dodatečné nastavení spuštění, které Aspose.Slides.NET na Linuxu potřebuje, a kroky pro Visual Studio.

## **Krok 3: Vytvořte svou první prezentaci**

[Quick start on the Aspose.Slides for .NET home page](/slides/cs/net/#your-first-presentation) je kompletní konzolová aplikace: přidá textové pole do snímku a uloží prezentaci jako soubor PPTX. [Create Presentations](/slides/cs/net/create-presentation/) popisuje stejné kroky podrobněji a ukazuje, jak otevřít existující prezentaci a uložit ji v jiném formátu.

## **Krok 4: Pokračujte ve společných úkolech**

- [Open a presentation](/slides/cs/net/open-presentation/) → Otevřít prezentaci
- [Save a presentation](/slides/cs/net/save-presentation/) → Uložit prezentaci
- [Convert a presentation to PDF](/slides/cs/net/convert-powerpoint-to-pdf/) → Převést prezentaci do PDF
- [Render slides as images](/slides/cs/net/convert-slide/) → Vykreslit snímky jako obrázky
- [Edit presentation text](/slides/cs/net/manage-text/) → Upravit text v prezentaci
- [Examples by slide element](/slides/cs/net/examples/) → Příklady podle prvku snímku

## **Vyhodnocení a licence**

Bez licence běží Aspose.Slides v evaluačním režimu: přidává vodoznak ke každému uloženému snímku a zkracuje text načtený z prezentací.

- [Evaluate Aspose.Slides](/slides/cs/net/evaluate-aspose-slides/) popisuje omezení hodnocení a jak požádat o dočasnou licenci.
- [Licensing](/slides/cs/net/licensing/) ukazuje, jak použít licenci ze souboru, proudu nebo vloženého zdroje.
- [Metered Licensing](/slides/cs/net/metered-licensing/) popisuje licencování účtované podle využití.
- [Supported File Formats](/slides/cs/net/supported-file-formats/) uvádí formáty, které Aspose.Slides dokáže načíst a uložit.

## **Získat pomoc**

[Product Support](/slides/cs/net/product-support/) vysvětluje, jak položit otázku na [free support forum](https://forum.aspose.com/c/slides/cs/11) a co zahrnout, když hlásíte problém.

## **FAQ**

**Potřebuji mít nainstalovaný Microsoft PowerPoint?**

Ne. Aspose.Slides čte a zapisuje soubory prezentací sám a nepoužívá PowerPoint, takže funguje i na serverech a na Linuxu.

**Který balíček mám použít pro aplikaci .NET Framework?**

Aspose.Slides.NET. Obsahuje sestavení pro .NET Framework 4.6.2 a novější, .NET 6 a novější a .NET Standard 2.0. Aspose.Slides.NET6.CrossPlatform vyžaduje .NET 6 nebo novější.