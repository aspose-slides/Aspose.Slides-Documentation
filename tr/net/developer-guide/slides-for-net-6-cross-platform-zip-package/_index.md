---
title: Aspose.Slides for .NET 6 Çapraz Platform (ZIP Paketi)
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
  - isim çakışması
  - harici alias
  - CS0433
  - PowerPoint
  - OpenDocument
  - sunum
  - .NET
  - C#
  - Aspose.Slides
description: "Aspose.Slides for .NET 6 kullanarak Windows, Linux ve macOS'ta çapraz platform C# uygulamaları geliştirip PowerPoint PPT, PPTX ve ODP dosyalarını oluşturun, düzenleyin ve dönüştürün."
---
## **Genel Bakış**

Bu makale, Aspose.Slides for .NET 6 Cross-Platform'u bir ZIP paketinden nasıl kullanacağınızı açıklar. Paketin nasıl indirileceğini, `net6.0/crossplatform` klasöründen dosyaların nasıl çıkarılacağını, `Aspose.Slides.dll`'ye nasıl referans ekleneceğini ve gerekli bağımlı kütüphanelerin uygulama çıktı dizinine kopyalanması için proje dosyasının nasıl yapılandırılacağını anlatır.

Makale ayrıca, ana Aspose.Slides .NET derlemesi ve Windows, Linux ve macOS için platforma özgü grafik alt sistemi kütüphanelerini içeren çapraz platform paketinin içeriğini de açıklar.

{{% alert title="Note" color="info" %}}
Aspose.Slides for .NET 6 Cross-Platform ayrıca [NuGet](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform) üzerinden de mevcuttur.
{{% /alert %}}

## **ZIP Paketiyle Çapraz Platform Aspose.Slides Kullanımı**

1. En son Aspose.Slides ZIP paketini [Release Page](https://releases.aspose.com/slides/tr/net/) adresinden indirin. 

2. *Aspose.Slides.zip\\Aspose.Slides\\net6.0\\crossplatform* içindeki dosyaları çıkarın ve projenizde bağımlılıklar için kullanılacak klasöre yerleştirin.

3. Aspose.Slides.dll'ye bir referans ekleyin.

   ![add-project-reference-visual-studio](add-project-reference-visual-studio.png)

   Örneğimizde (aşağıda), kütüphaneler proje klasöründe şu yol üzerinden yer alır: *ConsoleApp\\libs\\Aspose.Slides\\net6.0\\crossplatform\\...*

   ![browse-console-app](browse-console-app.jpg)

4. Kalan dosyaları (Aspose.Slides'in bağımlı olduğu) csproj proje dosyasına aşağıdaki şekilde talimat ekleyerek çıktı dizinine yerleştirin:

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

5. `TargetPath`'e dikkat edin. 

   Varsayılan olarak, `<CopyToOutputDirectory>` dosyaları göreceli yolunu koruyarak kopyalar, ancak bağımlı kütüphanelerin çıktının oluşturulduğu aynı klasöre (Aspose.Slides.dll konumu) gitmesini istiyoruz.

## **Notlar**

### **Özel Grafik Alt Sistemi**

| Aspose.Slides.dll                                          | Aspose.Slides Tüm Mantığını Yöneten Ana .NET Derlemesi                 |
| ---------------------------------------------------------- | -------------------------------------------------------------------------- |
| aspose.slides.drawing.capi_vc14x64.dll                     | Bağımlılık: Win x64 için grafik alt sistemi uygulaması                     |
| aspose.slides.drawing.capi_vc14x86.dll                     | Bağımlılık: Win x64 için grafik alt sistemi uygulaması                     |
| libaspose.slides.drawing.capi_x86_64_libstdcpp_libc2.23.so | Bağımlılık: Linux (x86/x64) için grafik alt sistemi uygulaması            |
| libaspose.slides.drawing.capi_appleclang_x86_64.dylib      | Bağımlılık: macOS AMD64 (x86-64/x64) için grafik alt sistemi uygulaması   |
| libaspose.slides.drawing.capi_appleclang_arm64.dylib       | Bağımlılık: macOS ARM64 (AArch64) için grafik alt sistemi uygulaması      |

Aspose.Slides.dll, çalıştığı sistemin gerektirdiği kütüphaneyi kullanır. Kütüphaneler genellikle Aspose.Slides.dll ile aynı konumda herhangi bir dosya sisteminde bulunur.

### **ZIP Paketi Yapısı**

ZIP paketi aşağıdaki klasör yapısını içerir:

  Aspose.Slides

  ├─── net6.0

  │  ├─── crossplatform

  │  └─── default

  ├─── net20

  ├─── net462

  └─── netstandard2.0

* Her klasör, ilgili .NET sürümü için derlemeleri içerir. net6.0 için iki sürüm vardır: default ve crossplatform. İkincisi, çapraz platform Aspose.Slides.dll ve tüm bağımlılıklarını içerir. Bu klasörün çıkarılmış içeriği, çapraz platform geliştirme ve diğer Aspose.Slides kullanım senaryoları için bir projeye bağımlılık ekleme olarak kullanılabilir.

## **Diğer Bilgiler**

- [Sistem Gereksinimleri](/slides/tr/net/system-requirements/)