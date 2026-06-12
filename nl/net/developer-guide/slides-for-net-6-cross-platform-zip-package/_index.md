---
title: Aspose.Slides voor .NET 6 Cross-Platform (ZIP-pakket)
type: docs
weight: 237
url: /nl/net/slides-for-net-6-cross-platform-zip-package/
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
description: "Gebruik Aspose.Slides voor .NET 6 om cross-platform C#-toepassingen te bouwen op Windows, Linux en macOS die PowerPoint-bestanden (PPT, PPTX) en ODP-bestanden kunnen maken, bewerken en converteren."
---
## **Overzicht**

Dit artikel legt uit hoe u Aspose.Slides voor .NET 6 Cross-Platform kunt gebruiken vanuit een ZIP‑pakket. Het beschrijft hoe u het pakket downloadt, de bestanden uit de map `net6.0/crossplatform` uitpakt, een referentie naar `Aspose.Slides.dll` toevoegt en het project‑bestand zo configureert dat de vereiste afhankelijke bibliotheken naar de uitvoermap van de toepassing worden gekopieerd.

Het artikel beschrijft bovendien de inhoud van het cross‑platform pakket, inclusief de hoofd‑Aspose.Slides .NET‑assembly en platform‑specifieke graphics‑subsystembibliotheken voor Windows, Linux en macOS.

{{% alert title="Note" color="primary" %}}

Aspose.Slides voor .NET 6 Cross-Platform is ook beschikbaar via [NuGet](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform).

{{% /alert %}}

## **Gebruik van de Cross‑Platform Aspose.Slides vanuit een ZIP‑pakket**

1. Download het ZIP‑pakket van de nieuwste Aspose.Slides van de [Release Page](https://releases.aspose.com/slides/nl/net/).

2. Pak de bestanden uit *Aspose.Slides.zip\Aspose.Slides\net6.0\crossplatform* uit en plaats ze in de map die u als afhankelijkheden in uw project wilt gebruiken.

3. Voeg een referentie toe aan Aspose.Slides.dll.

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

   Standaard kopieert `<CopyToOutputDirectory>` bestanden terwijl hun relatieve pad behouden blijft, maar we moeten de afhankelijke bibliotheken naar dezelfde map laten gaan waar de uitvoer wordt gegenereerd (de locatie van Aspose.Slides.dll).

## **Opmerkingen**

### **Propriëtair grafisch subsysteem**

Aspose.Slides cross‑platform is een verzameling bibliotheken:

| Aspose.Slides.dll                                          | Hoofd‑.NET‑assembly die verantwoordelijk is voor alle Aspose.Slides‑logica                 |
| ---------------------------------------------------------- | ------------------------------------------------------------------------------------------ |
| aspose.slides.drawing.capi_vc14x64.dll                     | Afhankelijkheid: implementatie van het graphics‑subsystem voor Win x64                  |
| aspose.slides.drawing.capi_vc14x86.dll                     | Afhankelijkheid: implementatie van het graphics‑subsystem voor Win x64                  |
| libaspose.slides.drawing.capi_x86_64_libstdcpp_libc2.23.so | Afhankelijkheid: implementatie van het graphics‑subsystem voor Linux (x86/x64)          |
| libaspose.slides.drawing.capi_appleclang_x86_64.dylib      | Afhankelijkheid: implementatie van het graphics‑subsystem voor macOS AMD64 (x86-64/x64) |
| libaspose.slides.drawing.capi_appleclang_arm64.dylib       | Afhankelijkheid: implementatie van het graphics‑subsystem voor macOS ARM64 (AArch64)    |

Aspose.Slides.dll gebruikt de bibliotheek die het systeem waarop het wordt uitgevoerd vereist. De bibliotheken bevinden zich meestal op dezelfde locatie als Aspose.Slides.dll in elk bestandssysteem.

### **Structuur van het ZIP‑pakket**

Het ZIP‑pakket bevat de volgende mapstructuur:

  Aspose.Slides

  ├─── net6.0

  │  ├─── crossplatform

  │  └─── default

  ├─── net20

  ├─── net462

  └─── netstandard2.0

* Elke map bevat assemblies voor de bijbehorende .NET‑versie. Er zijn twee versies voor net6.0: default en crossplatform. Laatstgenoemde bevat de cross‑platform Aspose.Slides.dll en al zijn afhankelijkheden. De uitgepakte inhoud van deze map kan worden gebruikt als een extra afhankelijkheid in een project voor cross‑platform ontwikkeling en andere gebruikssituaties van Aspose.Slides.

## **Zie ook**

- [Systeemvereisten](/slides/nl/net/system-requirements/)