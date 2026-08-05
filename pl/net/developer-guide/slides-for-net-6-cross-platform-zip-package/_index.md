---
title: "Aspose.Slides dla .NET 6 Cross-Platform (pakiet ZIP)"
type: docs
weight: 237
url: /pl/net/slides-for-net-6-cross-platform-zip-package/
aliases:
  - /net/slides-for-net-6-cross-platform/
keywords:
  - "wieloplatformowy"
  - ".NET 6"
  - "GLIBC"
  - "csproj"
  - "ścieżka docelowa"
  - "biblioteka zależna"
  - "Aspose.Slides.dll"
  - "System.Drawing.Common"
  - "konflikt nazw"
  - "zewnętrzny alias"
  - "CS0433"
  - "PowerPoint"
  - "OpenDocument"
  - "prezentacja"
  - ".NET"
  - "C#"
  - "Aspose.Slides"
description: "Użyj Aspose.Slides dla .NET 6, aby budować aplikacje C# wieloplatformowe na Windows, Linux i macOS, które tworzą, edytują i konwertują pliki PowerPoint PPT, PPTX i ODP."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak używać Aspose.Slides dla .NET 6 Cross-Platform z pakietu ZIP. Opisuje, jak pobrać pakiet, rozpakować pliki z folderu `net6.0/crossplatform`, dodać odwołanie do `Aspose.Slides.dll` oraz skonfigurować plik projektu, aby wymagane biblioteki zależne zostały skopiowane do katalogu wyjściowego aplikacji.

Artykuł opisuje także zawartość pakietu cross‑platform, w tym główny zestaw Aspose.Slides .NET oraz bibliotek podsystemu graficznego specyficzne dla platform Windows, Linux i macOS.

{{% alert title="Uwaga" color="primary" %}}

Aspose.Slides dla .NET 6 Cross-Platform jest również dostępny z [NuGet](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform).

{{% /alert %}}

## **Używanie Aspose.Slides Cross‑Platform z pakietu ZIP**

1. Pobierz najnowszy pakiet ZIP Aspose.Slides ze [Strony wydań](https://releases.aspose.com/slides/pl/net/).

2. Rozpakuj pliki z *Aspose.Slides.zip\Aspose.Slides\net6.0\crossplatform* i umieść je w folderze, który będzie używany jako zależność w Twoim projekcie.

3. Dodaj odwołanie do Aspose.Slides.dll.

   ![add-project-reference-visual-studio](add-project-reference-visual-studio.png)

   W naszym przykładzie (poniżej) biblioteki znajdują się w folderze projektu pod ścieżką: *ConsoleApp\libs\Aspose.Slides\net6.0\crossplatform\...*

   ![browse-console-app](browse-console-app.jpg)

4. Umieść pozostałe pliki (od których zależy Aspose.Slides) w katalogu wyjściowym, dodając instrukcje do pliku projektu csproj w następujący sposób:

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

5. Zwróć uwagę na `TargetPath`.

   Domyślnie element `<CopyToOutputDirectory>` kopiuje pliki, zachowując ich ścieżkę względną, ale potrzebujemy, aby biblioteki zależne trafiły do tego samego folderu, w którym znajduje się wynik (lokalizacja Aspose.Slides.dll).

## **Uwaga**

### **Własny podsystem graficzny**

Aspose.Slides cross‑platform jest zestawem bibliotek:

| Aspose.Slides.dll                                          | Główny zestaw .NET odpowiedzialny za całą logikę Aspose.Slides |
| ---------------------------------------------------------- | -------------------------------------------------------------- |
| aspose.slides.drawing.capi_vc14x64.dll                     | Zależność: implementacja podsystemu graficznego dla Win x64   |
| aspose.slides.drawing.capi_vc14x86.dll                     | Zależność: implementacja podsystemu graficznego dla Win x86   |
| libaspose.slides.drawing.capi_x86_64_libstdcpp_libc2.23.so | Zależność: implementacja podsystemu graficznego dla Linux (x86/x64) |
| libaspose.slides.drawing.capi_appleclang_x86_64.dylib      | Zależność: implementacja podsystemu graficznego dla macOS AMD64 (x86‑64/x64) |
| libaspose.slides.drawing.capi_appleclang_arm64.dylib       | Zależność: implementacja podsystemu graficznego dla macOS ARM64 (AArch64) |

Aspose.Slides.dll używa biblioteki wymagań systemu, na którym jest uruchamiany. Biblioteki zazwyczaj znajdują się w tym samym miejscu, co Aspose.Slides.dll w dowolnym systemie plików.

### **Struktura pakietu ZIP**

Pakiet ZIP zawiera następującą strukturę folderów:

Aspose.Slides
├─── net6.0
│   ├─── crossplatform
│   └─── default
├─── net20
├─── net462
└─── netstandard2.0

* Każdy folder zawiera zestawy dla odpowiadającej wersji .NET. Dla net6.0 istnieją dwie wersje: default i crossplatform. Druga z nich zawiera cross‑platformowy Aspose.Slides.dll oraz wszystkie jego zależności. Rozpakowane treści tego folderu mogą być użyte jako dodatek zależności w projekcie do tworzenia aplikacji cross‑platform oraz w innych przypadkach użycia Aspose.Slides.

## **Zobacz także**

- [Wymagania systemowe](/slides/pl/net/system-requirements/)