---
title: "Aspose.Slides voor .NET 6 Cross-Platform (ZIP-pakket)"
type: docs
weight: 237
url: /nl/net/slides-for-net-6-cross-platform-zip-package/
aliases:
  - /net/slides-for-net-6-cross-platform/
keywords:
  - platformonafhankelijk
  - .NET 6
  - GLIBC
  - csproj
  - doelpad
  - afhankelijke bibliotheek
  - Aspose.Slides.dll
  - System.Drawing.Common
  - naamconflict
  - externe alias
  - CS0433
  - PowerPoint
  - OpenDocument
  - presentatie
  - .NET
  - C#
  - Aspose.Slides
description: "Gebruik Aspose.Slides voor .NET 6 om cross-platform C#-toepassingen te bouwen op Windows, Linux en macOS die PowerPoint PPT, PPTX en ODP-bestanden maken, bewerken en converteren."
---
## **Overzicht**

Dit artikel legt uit hoe u Aspose.Slides voor .NET 6 Cross-Platform gebruikt vanuit een ZIP‑pakket. Het beschrijft hoe u het pakket downloadt, de bestanden uit de `net6.0/crossplatform`‑map uitpakt, een verwijzing naar `Aspose.Slides.dll` toevoegt en het project‑bestand configureert zodat de vereiste afhankelijke bibliotheken naar de uitvoermap van de applicatie worden gekopieerd.

Het artikel beschrijft ook de inhoud van het cross‑platform‑pakket, inclusief de hoofd‑Aspose.Slides‑.NET‑assembly en platformspecifieke grafische subsysteem‑bibliotheken voor Windows, Linux en macOS.

{{% alert title="Note" color="info" %}}
Aspose.Slides voor .NET 6 Cross-Platform is ook beschikbaar via [NuGet](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform).
{{% /alert %}}

## **Gebruik van Aspose.Slides Cross‑Platform vanuit een ZIP‑pakket**

1. Download het ZIP‑pakket van de meest recente Aspose.Slides vanaf de [Release‑pagina](https://releases.aspose.com/slides/nl/net/).

2. Pak de bestanden uit *Aspose.Slides.zip\Aspose.Slides\net6.0\crossplatform* uit en plaats ze in de map die zal worden gebruikt voor afhankelijkheden in uw project.

3. Voeg een verwijzing toe naar Aspose.Slides.dll.

   ![add-project-reference-visual-studio](add-project-reference-visual-studio.png)

   In ons voorbeeld (hieronder) bevinden de bibliotheken zich in de projectmap langs dit pad: *ConsoleApp\libs\Aspose.Slides\net6.0\crossplatform\...*

   ![browse-console-app](browse-console-app.jpg)

4. Plaats de resterende bestanden (waarvan Aspose.Slides afhankelijk is) in de uitvoermap door instructies toe te voegen aan het csproj‑projectbestand op deze manier:

```xml
<ItemGroup>

   <None Update="libs\Aspose.Slides\net6.0\crossplatform\aspose.slides.drawing.capi_vc14x64.dll">
         <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
         <TargetPath>aspose.slides.drawing.capi_vc14x64.dll</TargetPath>
   </None>

   <None Update="libs\Aspose.Slides\net6.0\crossplatform\aspose.slides.drawing.capi_vc14x86.dll">
         <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
         <TargetPath>aspose.slides.drawing.capi_vc14x86.dll</TargetPath>
   </None>

   <None Update="libs\Aspose.Slides\net6.0\crossplatform\Aspose.Slides.xml">
         <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
         <TargetPath>Aspose.Slides.xml</TargetPath>
   </None>

   <None Update="libs\Aspose.Slides\net6.0\crossplatform\libaspose.slides.drawing.capi_appleclang_x86_64.dylib">
         <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
         <TargetPath>libaspose.slides.drawing.capi_appleclang_x86_64.dylib</TargetPath>
   </None>

   <None Update="libs\Aspose.Slides\net6.0\crossplatform\libaspose.slides.drawing.capi_appleclang_arm64.dylib">
         <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
         <TargetPath>libaspose.slides.drawing.capi_appleclang_arm64.dylib</TargetPath>
   </None>

   <None Update="libs\Aspose.Slides\net6.0\crossplatform\libaspose.slides.drawing.capi_x86_64_libstdcpp_libc2.23.so">
         <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
         <TargetPath>libaspose.slides.drawing.capi_x86_64_libstdcpp_libc2.23.so</TargetPath>
   </None>

</ItemGroup>
```

5. Let op `TargetPath`.

   Standaard kopieert `<CopyToOutputDirectory>` bestanden terwijl hun relatieve pad behouden blijft, maar we moeten dat de afhankelijke bibliotheken naar dezelfde map gaan als waar de uitvoer wordt gegenereerd (locatie van Aspose.Slides.dll).

## **Opmerkingen**

### **Propriëtair grafisch subsysteem**

Aspose.Slides cross‑platform is een verzameling bibliotheken:

| Aspose.Slides.dll                                          | Hoofd‑.NET‑assembly verantwoordelijk voor alle Aspose.Slides‑logica |
| ---------------------------------------------------------- | ----------------------------------------------------------------- |
| aspose.slides.drawing.capi_vc14x64.dll                     | Afhankelijkheid: implementatie van grafisch subsysteem voor Win x64 |
| aspose.slides.drawing.capi_vc14x86.dll                     | Afhankelijkheid: implementatie van grafisch subsysteem voor Win x64 |
| libaspose.slides.drawing.capi_x86_64_libstdcpp_libc2.23.so | Afhankelijkheid: implementatie van grafisch subsysteem voor Linux (x86/x64) |
| libaspose.slides.drawing.capi_appleclang_x86_64.dylib      | Afhankelijkheid: implementatie van grafisch subsysteem voor macOS AMD64 (x86-64/x64) |
| libaspose.slides.drawing.capi_appleclang_arm64.dylib       | Afhankelijkheid: implementatie van grafisch subsysteem voor macOS ARM64 (AArch64) |

Aspose.Slides.dll gebruikt de bibliotheek die het systeem waarop het draait vereist. De bibliotheken bevinden zich doorgaans op dezelfde locatie als Aspose.Slides.dll in elk bestandssysteem.

### **ZIP‑pakketstructuur**

Het ZIP‑pakket bevat de volgende mapstructuur:

  Aspose.Slides

  ├─── net6.0

  │  ├─── crossplatform

  │  └─── default

  ├─── net20

  ├─── net462

  └─── netstandard2.0

* Elke map bevat assemblies voor de bijbehorende .NET‑versie. Er zijn twee versies voor net6.0: default en crossplatform. Laatste bevat de cross‑platform Aspose.Slides.dll en al zijn afhankelijkheden. De uitgepakte inhoud van deze map kan worden gebruikt als een afhankelijkheids‑toevoeging in een project voor cross‑platform‑ontwikkeling en andere Aspose.Slides‑gebruiksgevallen.

## **Zie ook**

- [Systeemvereisten](/slides/nl/net/system-requirements/)