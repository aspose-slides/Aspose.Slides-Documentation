---
title: Balíček pro více platforem pro .NET 6 a novější
linktitle: Balíček pro více platforem
type: docs
weight: 235
url: /cs/net/net6/
keywords:
  - Aspose.Slides.NET6.CrossPlatform
  - víceplatforem
  - podpora .NET 6
  - Linux
  - macOS
  - fontconfig
  - libgdiplus
  - System.Drawing.Common
  - CS0433
  - AWS Lambda
  - .NET
  - C#
  - Aspose.Slides
description: "Zjistěte, kdy použít balíček Aspose.Slides.NET6.CrossPlatform: proč existuje, na jakých platformách běží a co potřebuje na Linuxu místo libgdiplus."
---
## **Úvod**

Aspose.Slides for .NET je publikováno jako dva balíčky NuGet. [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET/) vykresluje snímky pomocí knihovny Microsoft System.Drawing.Common. [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/) je vykresluje pomocí vlastního grafického motoru. Tento článek vysvětluje, proč existuje druhý balíček, kde běží, co potřebuje na Linuxu a jak koexistuje se System.Drawing.Common v jednom projektu.

## **Proč samostatný balíček**

Od .NET 6 Microsoft podporuje System.Drawing.Common [pouze na Windows](https://learn.microsoft.com/en-us/dotnet/core/compatibility/core-libraries/6.0/system-drawing-common-windows-only). V důsledku toho Aspose.Slides.NET na Linuxu potřebuje přepínač `System.Drawing.EnableUnixSupport` i knihovnu `libgdiplus` a selže, pokud projekt odkazuje na System.Drawing.Common verze 7 nebo novější. [Požadavky systému](/slides/cs/net/system-requirements/) popisují tyto podmínky.

Aspose.Slides.NET6.CrossPlatform nepoužívá System.Drawing.Common ani `libgdiplus`. Jeho grafický motor je nativní knihovna, která je součástí balíčku v jedné sestavě pro každou podporovanou platformu. Oba balíčky poskytují stejné jmenné prostory a třídy Aspose.Slides, takže přechod mezi nimi mění pouze odkaz na balíček, ne váš kód.

| | Aspose.Slides.NET | Aspose.Slides.NET6.CrossPlatform |
|---|---|---|
| Grafika | System.Drawing.Common | Nativní grafický motor zahrnutý v balíčku |
| Cílové frameworky | `net462`, `net6.0`, `netstandard2.0` | `net6.0` |
| Požadavky na Linux | `libgdiplus` a přepínač `System.Drawing.EnableUnixSupport` | `fontconfig` |
| Alpine Linux | Podporováno | Nepodporováno |

## **Podporované platformy**

Aspose.Slides.NET6.CrossPlatform funguje s .NET 6 a novějšími verzemi na těchto platformách:

- **Windows**: x86 a x64. Nativní knihovna používá runtime Microsoft Visual C++; viz [Požadavky systému](/slides/cs/net/system-requirements/).
- **Linux**: x64 s glibc 2.23 nebo novější a ARM64 s glibc 2.39 nebo novější.
- **macOS**: x64 (Intel) a ARM64 (Apple silicon).

Nebehoří na Windows na ARM64, na Alpine Linux ani na dalších distribucích založených na musl místo glibc, ani na distribucích se starší glibc, např. CentOS 7. V takových systémech použijte Aspose.Slides.NET.

## **Instalace na Linuxu**

Na Linuxu balíček vyžaduje knihovnu `fontconfig`, ale ne `libgdiplus`. Na Debianu a Ubuntu nainstalujte `fontconfig` a poté přidejte balíček do svého projektu:

```bash
sudo apt-get update && sudo apt-get install -y libfontconfig1
dotnet add package Aspose.Slides.NET6.CrossPlatform
```

Na Debianu a Ubuntu `libfontconfig1` také nainstaluje fonty DejaVu, takže text se vykresluje bez dalších fontových balíčků. Bez `fontconfig` selže vytvoření [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) s výjimkou `TypeInitializationException`, jejíž vnitřní `DllNotFoundException` hlásí, že `libfontconfig.so.1` nelze otevřít. [Požadavky systému](/slides/cs/net/system-requirements/) obsahují krátký program, který kontroluje nastavení.

## **Cloud a kontejnery**

Protože nepotřebuje `libgdiplus`, Aspose.Slides.NET6.CrossPlatform je balíček, který se používá na Linuxových hostitelích, kde nemůžete nainstalovat `libgdiplus`. Stále však vyžaduje `fontconfig` a fonty, které mohou chybět v minimalistických základních obrazech. Například základní obraz AWS Lambda pro .NET 8 neobsahuje ani jedno. V kontejnerovém obrazu na něm postaveném spusťte `dnf install -y fontconfig`, což také nainstaluje fonty Noto Sans.

Pro návody k jednotlivým cloudovým platformám viz [Aspose.Slides on Cloud Platforms](/slides/cs/net/slides-on-cloud-platforms/).

## **Používání System.Drawing.Common ve stejném projektu (CS0433)**

Projekt, který používá Aspose.Slides.NET6.CrossPlatform, může také odkazovat na System.Drawing.Common, přímo nebo přes jiný balíček. Aktuální verze Aspose.Slides neexponuje žádné veřejné typy v jmenných prostorech `System`, takže knihovny nekolidují a můžete importovat jmenné prostory `Aspose.Slides` a `System.Drawing` ve stejném souboru.

Pokud kompilátor hlásí chybu CS0433, protože typ jako `Image` nebo `Graphics` existuje jak v Aspose.Slides, tak v System.Drawing.Common, váš projekt používá starší verzi Aspose.Slides. Aktualizujte balíček na nejnovější verzi. Aspose.Slides vrací vykreslené obrázky jako objekty [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/), které jsou popsány v [Moderní API](/slides/cs/net/modern-api/).

## **Často kladené otázky**

**Musím měnit kód, když přepnu z Aspose.Slides.NET na Aspose.Slides.NET6.CrossPlatform?**

Ne. Oba balíčky poskytují stejné jmenné prostory a třídy Aspose.Slides, takže stačí nahradit odkaz na balíček. Aspose.Slides.NET6.CrossPlatform nevyžaduje přepínač `System.Drawing.EnableUnixSupport`. Do projektu přidejte jen jeden z těchto dvou balíčků.

**Mohu použít Aspose.Slides.NET6.CrossPlatform v projektu .NET Framework?**

Ne. Balíček cílí pouze na .NET 6 a novější. Pro .NET Framework 4.6.2 a novější použijte Aspose.Slides.NET.