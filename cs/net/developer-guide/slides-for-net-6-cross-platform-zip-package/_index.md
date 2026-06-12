---
title: Aspose.Slides pro .NET 6 Cross-Platform (ZIP balíček)
type: docs
weight: 237
url: /cs/net/slides-for-net-6-cross-platform-zip-package/
keywords:
- multiplatformní
- .NET 6
- GLIBC
- csproj
- cesta cíle
- závislá knihovna
- Aspose.Slides.dll
- System.Drawing.Common
- konflikt názvů
- externí alias
- CS0433
- PowerPoint
- OpenDocument
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Použijte Aspose.Slides pro .NET 6 k vytváření multiplatformních C# aplikací ve Windows, Linuxu a macOS, které vytvářejí, upravují a převádějí soubory PowerPoint PPT, PPTX a ODP."
---
## **Přehled**

Tento článek vysvětluje, jak používat Aspose.Slides pro .NET 6 Cross‑Platform ze ZIP balíčku. Popisuje, jak stáhnout balíček, rozbalit soubory ze složky `net6.0/crossplatform`, přidat odkaz na `Aspose.Slides.dll` a nakonfigurovat soubor projektu tak, aby požadované závislé knihovny byly zkopírovány do výstupního adresáře aplikace.

Článek také popisuje obsah cross‑platform balíčku, včetně hlavního Aspose.Slides .NET sestavení a platformně specifických knihoven grafického subsystému pro Windows, Linux a macOS.

{{% alert title="Poznámka" color="primary" %}}

Aspose.Slides pro .NET 6 Cross‑Platform je také dostupný na [NuGet](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform).

{{% /alert %}}

## **Použití Cross‑Platform Aspose.Slides ze ZIP balíčku**

1. Stáhněte ZIP balíček nejnovější verze Aspose.Slides z [Release Page](https://releases.aspose.com/slides/cs/net/).

2. Rozbalte soubory z *Aspose.Slides.zip\Aspose.Slides\net6.0\crossplatform* a umístěte je do složky, která bude použita pro závislosti ve vašem projektu.

3. Přidejte odkaz na Aspose.Slides.dll.

   ![add-project-reference-visual-studio](add-project-reference-visual-studio.png)

   V našem příkladu (níže) jsou knihovny umístěny ve složce projektu pod touto cestou: *ConsoleApp\libs\Aspose.Slides\net6.0\crossplatform\...*

   ![browse-console-app](browse-console-app.jpg)

4. Umístěte zbývající soubory (na které Aspose.Slides odkazuje) do výstupního adresáře přidáním instrukcí do souboru csproj tímto způsobem:

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

5. Věnujte pozornost `TargetPath`.

   Ve výchozím nastavení `<CopyToOutputDirectory>` kopíruje soubory se zachováním jejich relativní cesty, ale potřebujeme, aby závislé knihovny byly umístěny ve stejném adresáři, kde je generován výstup (umístění Aspose.Slides.dll).

## **Poznámky**

### **Proprietární grafický subsystém**

Aspose.Slides cross‑platform je kolekce knihoven:

| Aspose.Slides.dll                                          | Hlavní .NET sestavení zodpovědné za veškerou logiku Aspose.Slides |
| ---------------------------------------------------------- | ---------------------------------------------------------------- |
| aspose.slides.drawing.capi_vc14x64.dll                     | Závislost: implementace grafického subsystému pro Win x64          |
| aspose.slides.drawing.capi_vc14x86.dll                     | Závislost: implementace grafického subsystému pro Win x86          |
| libaspose.slides.drawing.capi_x86_64_libstdcpp_libc2.23.so | Závislost: implementace grafického subsystému pro Linux (x86/x64) |
| libaspose.slides.drawing.capi_appleclang_x86_64.dylib      | Závislost: implementace grafického subsystému pro macOS AMD64 (x86‑64/x64) |
| libaspose.slides.drawing.capi_appleclang_arm64.dylib       | Závislost: implementace grafického subsystému pro macOS ARM64 (AArch64) |

Aspose.Slides.dll používá knihovnu, kterou vyžaduje operační systém, na kterém běží. Knihovny jsou obvykle umístěny ve stejném umístění jako Aspose.Slides.dll v libovolném souborovém systému.

### **Struktura ZIP balíčku**

ZIP balíček obsahuje následující strukturu složek:

  Aspose.Slides

  ├─── net6.0

  │  ├─── crossplatform

  │  └─── default

  ├─── net20

  ├─── net462

  └─── netstandard2.0

* Každá složka obsahuje sestavení pro odpovídající verzi .NET. Pro net6.0 existují dvě verze: default a crossplatform. Ta druhá obsahuje cross‑platform Aspose.Slides.dll a všechny její závislosti. Rozbalený obsah této složky může být použit jako přídavek závislosti v projektu pro vývoj cross‑platform a další případy použití Aspose.Slides.

## **Související odkazy**

- [System Requirements](/slides/cs/net/system-requirements/)