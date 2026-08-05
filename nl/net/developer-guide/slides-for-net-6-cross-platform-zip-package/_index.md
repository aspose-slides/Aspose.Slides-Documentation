---
title: Aspose.Slides voor .NET 6 Cross-Platform (ZIP-pakket)
type: docs
weight: 237
url: /nl/net/slides-for-net-6-cross-platform-zip-package/
aliases:
  - /net/slides-for-net-6-cross-platform/
keywords:
- cross-platform
- .NET 6
- GLIBC
- csproj
- doelpad
- afhankelijke bibliotheek
- Aspose.Slides.dll
- System.Drawing.Common
- naamconflict
- extern alias
- CS0433
- PowerPoint
- OpenDocument
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Gebruik Aspose.Slides voor .NET 6 om cross-platform C#‑applicaties te bouwen op Windows, Linux en macOS die PowerPoint‑PPT, PPTX‑ en ODP‑bestanden kunnen maken, bewerken en converteren."
---
## **Overzicht**

Dit artikel legt uit hoe u Aspose.Slides voor .NET 6 Cross-Platform vanuit een ZIP‑pakket gebruikt. Het beschrijft hoe u het pakket downloadt, de bestanden uit de map `net6.0/crossplatform` uitpakt, een verwijzing naar `Aspose.Slides.dll` toevoegt en het projectbestand configureert zodat de vereiste afhankelijke bibliotheken naar de uitvoermap van de applicatie worden gekopieerd.

Het artikel beschrijft tevens de inhoud van het cross‑platformpakket, inclusief de hoofd‑Aspose.Slides .NET‑assembly en platform‑specifieke graphics‑subsystem‑bibliotheken voor Windows, Linux en macOS.

{{% alert title="Opmerking" color="primary" %}}
Aspose.Slides for .NET 6 Cross-Platform is also available from [NuGet](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform).
{{% /alert %}}

## **Gebruik van de Cross‑Platform Aspose.Slides vanuit een ZIP‑pakket**

1. Download het ZIP‑pakket van de nieuwste Aspose.Slides vanaf de [Release‑pagina](https://releases.aspose.com/slides/nl/net/).

2. Pak de bestanden uit *Aspose.Slides.zip\Aspose.Slides\net6.0\crossplatform* uit en plaats ze in de map die u voor afhankelijkheden in uw project wilt gebruiken.

3. Voeg een verwijzing toe naar Aspose.Slides.dll.

   ![add-project-reference-visual-studio](add-project-reference-visual-studio.png)

   In ons voorbeeld (onder) bevinden de bibliotheken zich in de projectmap langs dit pad: *ConsoleApp\libs\Aspose.Slides\net6.0\crossplatform\...*

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

   Standaard kopieert `<CopyToOutputDirectory>` bestanden met behoud van hun relatieve pad, maar we moeten de afhankelijke bibliotheken naar dezelfde map laten gaan waar de output wordt gegenereerd (locatie van Aspose.Slides.dll).

## **Opmerkingen**

### **Eigen graphics‑subsystem**

| Aspose.Slides.dll                                          | Hoofd .NET‑assembly die verantwoordelijk is voor alle Aspose.Slides‑logica                 |
| ---------------------------------------------------------- | ------------------------------------------------------------------------------------------ |
| aspose.slides.drawing.capi_vc14x64.dll                     | Afhankelijkheid: graphics‑subsystemimplementatie voor Win x64                              |
| aspose.slides.drawing.capi_vc14x86.dll                     | Afhankelijkheid: graphics‑subsystemimplementatie voor Win x64                              |
| libaspose.slides.drawing.capi_x86_64_libstdcpp_libc2.23.so | Afhankelijkheid: graphics‑subsystemimplementatie voor Linux (x86/x64)                     |
| libaspose.slides.drawing.capi_appleclang_x86_64.dylib      | Afhankelijkheid: graphics‑subsystemimplementatie voor macOS AMD64 (x86-64/x64)            |
| libaspose.slides.drawing.capi_appleclang_arm64.dylib       | Afhankelijkheid: graphics‑subsystemimplementatie voor macOS ARM64 (AArch64)               |

Aspose.Slides.dll gebruikt de bibliotheek die door het systeem waarop het wordt uitgevoerd vereist is. De bibliotheken bevinden zich doorgaans op dezelfde locatie als Aspose.Slides.dll in elk bestandssysteem.

### **ZIP‑pakketstructuur**

Het ZIP‑pakket bevat de volgende mapstructuur:

  Aspose.Slides

  ├─── net6.0

  │  ├─── crossplatform

  │  └─── default

  ├─── net20

  ├─── net462

  └─── netstandard2.0

* Elke map bevat assemblies voor de bijbehorende .NET‑versie. Er zijn twee versies voor net6.0: default en crossplatform. Laatstgenoemde bevat de cross‑platform Aspose.Slides.dll en al haar afhankelijkheden. De uitgepakte inhoud van deze map kan worden gebruikt als een afhankelijkheids‑toevoeging in een project voor cross‑platformontwikkeling en andere gebruiksscenario’s van Aspose.Slides.

## **Zie ook**

- [Systeemvereisten](/slides/nl/net/system-requirements/)