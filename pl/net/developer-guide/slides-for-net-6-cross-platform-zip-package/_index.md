---
title: Aspose.Slides dla .NET 6 wieloplatformowy (pakiet ZIP)
type: docs
weight: 237
url: /pl/net/slides-for-net-6-cross-platform-zip-package/
keywords:
- wieloplatformowy
- .NET 6
- GLIBC
- csproj
- ścieżka docelowa
- biblioteka zależna
- Aspose.Slides.dll
- System.Drawing.Common
- konflikt nazw
- alias zewnętrzny
- CS0433
- PowerPoint
- OpenDocument
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Użyj Aspose.Slides dla .NET 6, aby budować wieloplatformowe aplikacje C# na Windows, Linux i macOS, które tworzą, edytują i konwertują pliki PowerPoint PPT, PPTX i ODP."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak używać Aspose.Slides for .NET 6 Cross-Platform z pakietu ZIP. Opisuje, jak pobrać pakiet, rozpakować pliki z folderu `net6.0/crossplatform`, dodać odwołanie do `Aspose.Slides.dll` oraz skonfigurować plik projektu tak, aby wymagane zależne biblioteki zostały skopiowane do katalogu wyjściowego aplikacji.

Artykuł opisuje także zawartość pakietu cross‑platform, w tym główny zestaw Aspose.Slides .NET oraz biblioteki podsystemu graficznego specyficzne dla platform Windows, Linux i macOS.

{{% alert title="Note" color="primary" %}}
Aspose.Slides for .NET 6 Cross-Platform jest również dostępny w [NuGet](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform).
{{% /alert %}}

## **Używanie Aspose.Slides Cross-Platform z pakietu ZIP**

1. Pobierz pakiet ZIP najnowszej wersji Aspose.Slides ze [strony wydania](https://releases.aspose.com/slides/pl/net/).

2. Rozpakuj pliki z *Aspose.Slides.zip\Aspose.Slides\net6.0\crossplatform* i umieść je w folderze, który będzie używany jako zależności w Twoim projekcie.

3. Dodaj odwołanie do Aspose.Slides.dll.

   ![add-project-reference-visual-studio](add-project-reference-visual-studio.png)

   W naszym przykładzie (poniżej) biblioteki znajdują się w folderze projektu pod następującą ścieżką: *ConsoleApp\libs\Aspose.Slides\net6.0\crossplatform\...*

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

   Domyślnie `<CopyToOutputDirectory>` kopiuje pliki, zachowując ich względną ścieżkę, ale potrzebujemy, aby zależne biblioteki trafiły do tego samego folderu, w którym generowany jest output (lokalizacja Aspose.Slides.dll).

## **Uwaga**

### **Własny podsystem graficzny**

Aspose.Slides cross‑platform to zbiór bibliotek:

| Aspose.Slides.dll                                          | Główny zestaw .NET odpowiedzialny za całą logikę Aspose.Slides |
| ---------------------------------------------------------- | -------------------------------------------------------------- |
| aspose.slides.drawing.capi_vc14x64.dll                     | Zależność: implementacja podsystemu graficznego dla Win x64    |
| aspose.slides.drawing.capi_vc14x86.dll                     | Zależność: implementacja podsystemu graficznego dla Win x64    |
| libaspose.slides.drawing.capi_x86_64_libstdcpp_libc2.23.so | Zależność: implementacja podsystemu graficznego dla Linux (x86/x64) |
| libaspose.slides.drawing.capi_appleclang_x86_64.dylib      | Zależność: implementacja podsystemu graficznego dla macOS AMD64 (x86-64/x64) |
| libaspose.slides.drawing.capi_appleclang_arm64.dylib       | Zależność: implementacja podsystemu graficznego dla macOS ARM64 (AArch64) |

Aspose.Slides.dll używa biblioteki wymaganą przez system, na którym jest uruchamiany. Biblioteki te zazwyczaj znajdują się w tym samym miejscu, co Aspose.Slides.dll, w dowolnym systemie plików.

### **Struktura pakietu ZIP**

Pakiet ZIP zawiera następującą strukturę folderów:

  Aspose.Slides

  ├─── net6.0

  │  ├─── crossplatform

  │  └─── default

  ├─── net20

  ├─── net462

  └─── netstandard2.0

* Każdy folder zawiera zestawy dla odpowiadającej mu wersji .NET. Dla net6.0 dostępne są dwie wersje: default i crossplatform. Ta druga zawiera Aspose.Slides.dll cross‑platform oraz wszystkie jego zależności. Rozpakowana zawartość tego folderu może być użyta jako dodatkowa zależność w projekcie przeznaczonym do rozwoju cross‑platform oraz w innych scenariuszach użycia Aspose.Slides.

## **Zobacz także**

- [Wymagania systemowe](/slides/pl/net/system-requirements/)