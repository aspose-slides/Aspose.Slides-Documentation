---
title: Aspose.Slides for .NET 6 Cross-Platform (ZIP Paketi)
type: docs
weight: 237
url: /tr/net/slides-for-net-6-cross-platform-zip-package/
aliases:
  - /net/slides-for-net-6-cross-platform/
keywords:
- çapraz platform
- .NET 6
- GLIBC
- csproj
- hedef yol
- bağımlı kütüphane
- Aspose.Slides.dll
- System.Drawing.Common
- ad çakışması
- extern takma ad
- CS0433
- PowerPoint
- OpenDocument
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET 6'yı kullanarak Windows, Linux ve macOS üzerinde çapraz platform C# uygulamaları oluşturun; PowerPoint PPT, PPTX ve ODP dosyalarını oluşturabilir, düzenleyebilir ve dönüştürebilirsiniz."
---
## **Genel Bakış**

Bu makale, Aspose.Slides for .NET 6 Cross-Platform'un bir ZIP paketinden nasıl kullanılacağını açıklar. Paketin nasıl indirileceği, `net6.0/crossplatform` klasöründen dosyaların nasıl açılacağı, `Aspose.Slides.dll`'e nasıl referans ekleneceği ve gerekli bağımlı kütüphanelerin uygulama çıkış dizinine kopyalanması için proje dosyasının nasıl yapılandırılacağı anlatılır.

Makale ayrıca, çapraz platform paketinin içeriğini, ana Aspose.Slides .NET derlemesi ve Windows, Linux ve macOS için platform‑specific grafik alt sistem kütüphanelerini tanımlar.

{{% alert title="Note" color="primary" %}}

Aspose.Slides for .NET 6 Cross-Platform ayrıca [NuGet](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform) adresinden de temin edilebilir.

{{% /alert %}}

## **ZIP Paketinden Cross-Platform Aspose.Slides Kullanma**

1. En son Aspose.Slides ZIP paketini [Release Page](https://releases.aspose.com/slides/tr/net/) üzerinden indirin.  

2. *Aspose.Slides.zip\Aspose.Slides\net6.0\crossplatform* içindeki dosyaları açın ve projenizde bağımlılık olarak kullanılacak klasöre yerleştirin.  

3. Aspose.Slides.dll'e bir referans ekleyin.

   ![add-project-reference-visual-studio](add-project-reference-visual-studio.png)

   Örneğimizde (aşağıda) kütüphaneler proje klasöründe şu yolda bulunuyor: *ConsoleApp\libs\Aspose.Slides\net6.0\crossplatform\...*

   ![browse-console-app](browse-console-app.jpg)

4. Kalan dosyaları (Aspose.Slides'ın bağımlı olduğu dosyalar) çıkış dizinine kopyalamak için csproj proje dosyasına aşağıdaki talimatı ekleyin:

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

5. `TargetPath` değerine dikkat edin.  

   Varsayılan olarak `<CopyToOutputDirectory>` dosyaları göreli yollarını koruyarak kopyalar, ancak bağımlı kütüphanelerin çıkışın oluşturulduğu aynı klasöre (Aspose.Slides.dll konumu) gitmesi gerekir.

## **Notlar**

### **Sahipli Grafik Alt Sistemi**

Aspose.Slides cross-platform bir kütüphane koleksiyonudur:

| Aspose.Slides.dll                                          | Tüm Aspose.Slides Mantığından Sorumlu Ana .NET Derlemesi |
| ---------------------------------------------------------- | -------------------------------------------------------- |
| aspose.slides.drawing.capi_vc14x64.dll                     | Bağımlılık: Win x64 için grafik alt sistem uygulaması |
| aspose.slides.drawing.capi_vc14x86.dll                     | Bağımlılık: Win x86 için grafik alt sistem uygulaması |
| libaspose.slides.drawing.capi_x86_64_libstdcpp_libc2.23.so | Bağımlılık: Linux (x86/x64) için grafik alt sistem uygulaması |
| libaspose.slides.drawing.capi_appleclang_x86_64.dylib      | Bağımlılık: macOS AMD64 (x86-64/x64) için grafik alt sistem uygulaması |
| libaspose.slides.drawing.capi_appleclang_arm64.dylib       | Bağımlılık: macOS ARM64 (AArch64) için grafik alt sistem uygulaması |

Aspose.Slides.dll, çalıştığı sistemin gerektirdiği kütüphaneyi kullanır. Kütüphaneler genellikle Aspose.Slides.dll ile aynı konumda bulunur.

### **ZIP Paket Yapısı**

ZIP paketi aşağıdaki klasör yapısını içerir:

  Aspose.Slides

  ├─── net6.0

  │  ├─── crossplatform

  │  └─── default

  ├─── net20

  ├─── net462

  └─── netstandard2.0

* Her klasör, ilgili .NET sürümü için derlemeler içerir. net6.0 için iki sürüm vardır: default ve crossplatform. İkincisi, çapraz platform Aspose.Slides.dll ve tüm bağımlılıklarını içerir. Bu klasörün açılmış içeriği, çapraz platform geliştirme ve diğer Aspose.Slides kullanım senaryoları için projeye bağımlılık olarak eklenebilir.

## **Ayrıca Bakınız**

- [System Requirements](/slides/tr/net/system-requirements/)