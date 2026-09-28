---
title: Güvenlik
type: docs
weight: 160
url: /tr/net/security/
keywords:
- güvenlik
- bağımlılıklar
- üçüncü taraf bileşenler
- NuGet
- güvenlik açıkları taraması
- PowerPoint
- OpenDocument
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET'in sunumları nasıl işlediğini, her hedef çerçeve için hangi NuGet paketlerine bağımlı olduğunu ve hangi üçüncü taraf bileşenleri içerdiğini inceleyin."
---
## **Aspose.Slides'ta Güvenlik**

* Aspose.Slides for .NET, sunumları manipüle etmek ve diğer formatlara dönüştürmek için kullanılır. Sunumlardaki scriptleri çalıştırmaz. Aspose.Slides, sunum yapısını ayrıştırır ve son kullanıcı kodunun nesne modelini uygun bir şekilde manipüle etmesine olanak tanır.
* Aspose.Slides, uzaktan kod çalıştırmadan belgeleri ayrıştıran ve yorumlayan bir kütüphane olarak işlev görür. Tüm Aspose ürünleri sizin makinelerinizde çalışır. Aspose'a herhangi bir veri göndermezler. Tek istisna, bir [metered license](https://purchase.aspose.com/faqs/licensing/metered) kullanıyorsanız; bu durumda yalnızca API kullanım bilgileriniz işlenir.
* Aspose bileşenleri, normal uygulamalarla aynı kullanıcı bağlamında çalışır. Bu nedenle, Aspose bileşenleri kritik sistem kaynakları için bir risk oluşturmaz. Ayrıca, bir Aspose bileşeni bir belge açtığında makrolar otomatik olarak çalıştırılmaz.
* Microsoft Office paketine özgü ya da ona bağlı riskler Aspose bileşenlerine uygulanmaz; bu yüzden Aspose ürünleri çok güvenlidir.

## **NuGet Bağımlılıkları**

Aspose.Slides for .NET, Microsoft'un NuGet üzerinde yayınladığı paketlere bağımlıdır. Bağımlılıklar paket ve hedef çerçeveye göre değişir:

| Paket | Hedef çerçeve | Bağımlılıklar |
|---|---|---|
| Aspose.Slides.NET | `net462` | System.Text.Json |
| Aspose.Slides.NET | `net6.0` | System.Drawing.Common, System.Security.Cryptography.Xml |
| Aspose.Slides.NET | `netstandard2.0` | System.Drawing.Common, System.Security.Cryptography.Xml, System.Text.Encoding.CodePages, System.Text.Json |
| Aspose.Slides.NET6.CrossPlatform | `net6.0` | System.Security.Cryptography.Xml |

NuGet üzerindeki [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET/) ve [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/) sayfalarının **Bağımlılıklar** bölümü, her sürüm için her bir bağımlılığın minimum sürümünü listeler.

Aspose.Slides'ı bir projeye eklediğinizde, NuGet bu paketlerin bağımlılıklarını da geri yükler. Projenizin geri yüklediği tüm paketleri, bu geçişli bağımlılıkları da içerecek şekilde listelemek için proje klasöründe şu komutu çalıştırın:

```bash
dotnet list package --include-transitive
```

Aynı paket setini bilinen güvenlik açıklarına karşı kontrol etmek için şu komutu çalıştırın:

```bash
dotnet list package --vulnerable --include-transitive
```

NuGet paketlerini denetlemenin diğer yolları için, [Auditing package dependencies for security vulnerabilities](https://learn.microsoft.com/en-us/nuget/concepts/auditing-packages) sayfasına bakın.

## **Üçüncü Parti Bileşenler**

Aspose.Slides, üçüncü taraf açık kaynak bileşenlerinden kod içerir. Bunlar ürünün bir parçasıdır, ayrı NuGet paketleri değildir; bu yüzden yalnızca NuGet bağımlılıklarını okuyan araçlar onları listeler. Her iki paket de *thirdpartylicenses.Aspose.Slides.for.NET.pdf* dosyasını içerir; bu dosya bileşenleri ve lisanslarını listeler:

| Bileşen | Bildiride belirtilen lisans |
|---|---|
| DotNetZip | Microsoft Public License (Ms-PL) |
| ANTLR | BSD License |
| sfntly | Apache License 2.0 |
| Skia | BSD-style license |
| HarfBuzz | "Old MIT" license |
| Boost | Boost Software License 1.0 |
| Double Conversion | BSD-style license |
| ICU (International Components for Unicode) | Unicode copyright and terms of use |

## **SSS**

**Aspose kodundaki güvenlik açıklarını izlemek için hangi sistemler kullanılır?**

Her Aspose.Slides sürümü için statik kod analizi gerçekleştiriyoruz. Aspose.Slides kodunun OWASP Top 10'ı geçtiğini kanıtlayan güvenlik raporları sağlayabiliriz.

**Aspose.Slides dış paketler kullanıyor mu?**

Evet. [NuGet Dependencies](#nuget-dependencies) bölümünde listelenen Microsoft NuGet paketlerine bağımlıdır ve [Third-Party Components](#third-party-components) bölümünde listelenen üçüncü taraf bileşenleri içerir. Her ikisini de güvenlik incelemenize dahil edin ve projenizin geri yüklediği NuGet paketlerini kontrol etmek için `dotnet list package --vulnerable --include-transitive` komutunu kullanın.