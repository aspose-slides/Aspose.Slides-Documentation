---
title: "Çapraz Platform Paketi .NET 6 ve Sonrası için"
linktitle: "Çapraz Platform Paketi"
type: docs
weight: 235
url: /tr/net/net6/
keywords:
- Aspose.Slides.NET6.CrossPlatform
- çapraz platform
- .NET 6 desteği
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
description: "Aspose.Slides.NET6.CrossPlatform paketini ne zaman kullanmanız gerektiğini öğrenin: neden var, hangi platformlarda çalışır ve Linux'ta libgdiplus yerine neye ihtiyaç duyar."
---
## **Giriş**

Aspose.Slides for .NET iki NuGet paketi olarak yayınlanır. [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET/) slaytları Microsoft'un System.Drawing.Common kütüphanesi üzerinden çizer. [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/) ise kendi grafik motoruyla çizer. Bu makale ikinci paketin neden var olduğunu, nerelerde çalıştığını, Linux'ta neye ihtiyacı olduğunu ve bir projede System.Drawing.Common ile nasıl bir arada bulunabileceğini açıklıyor.

## **Neden Ayrı Bir Paket**

.NET 6 ile başlayan Microsoft, System.Drawing.Common'ı yalnızca Windows'ta desteklemektedir. Sonuç olarak, Linux'ta Aspose.Slides.NET, `System.Drawing.EnableUnixSupport` anahtarını ve `libgdiplus` kitaplığını gerektirir ve proje System.Drawing.Common 7 veya daha yeni bir sürümü referans alıyorsa orada başarısız olur. [System Requirements](/slides/tr/net/system-requirements/) bu koşulları açıklar.

Aspose.Slides.NET6.CrossPlatform, System.Drawing.Common veya `libgdiplus` kullanmaz. Grafik motoru, paket içinde desteklenen her platform için bir derlemede bulunan yerel bir kitaplıktır. Her iki paket de aynı Aspose.Slides ad alanlarını ve sınıflarını sağlar, bu yüzden birinden diğerine geçiş sadece paket referansını değiştirir, kodunuz değişmez.

| | Aspose.Slides.NET | Aspose.Slides.NET6.CrossPlatform |
|---|---|---|
| Grafikler | System.Drawing.Common | Pakette bulunan yerel grafik motoru |
| Hedef çerçeveler | `net462`, `net6.0`, `netstandard2.0` | `net6.0` |
| Linux gereksinimleri | `libgdiplus` ve `System.Drawing.EnableUnixSupport` anahtarı | `fontconfig` |
| Alpine Linux | Destekleniyor | Desteklenmiyor |

## **Desteklenen Platformlar**

Aspose.Slides.NET6.CrossPlatform, .NET 6 ve sonraki sürümlerle şu platformlarda çalışır:

- **Windows**: x86 ve x64. Yerel kütüphane Microsoft Visual C++ çalışma zamanını kullanır; [System Requirements](/slides/tr/net/system-requirements/) bölümüne bakın.
- **Linux**: glibc 2.23 veya daha yeni bir sürümle x64 ve glibc 2.39 veya daha yeni bir sürümle ARM64.
- **macOS**: x64 (Intel) ve ARM64 (Apple silikon).

Windows ARM64'de, Alpine Linux'ta veya glibc yerine musl kullanan diğer dağıtımlarda, ayrıca daha eski glibc'ye (örneğin CentOS 7) sahip dağıtımlarda çalışmaz. Bu sistemlerde Aspose.Slides.NET kullanın.

## **Linux Üzerinde Kurulum**

Linux'ta paket `fontconfig` kitaplığını gerektirir, ancak `libgdiplus` gerekmez. Debian ve Ubuntu'da `fontconfig` kurun ve ardından paketi projenize ekleyin:

```bash
sudo apt-get update && sudo apt-get install -y libfontconfig1
dotnet add package Aspose.Slides.NET6.CrossPlatform
```

Debian ve Ubuntu'da `libfontconfig1` aynı zamanda DejaVu yazı tiplerini de kurar, böylece metin ek bir yazı tipi paketine ihtiyaç duymadan render edilir. `fontconfig` olmadan bir [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) oluşturmak, `libfontconfig.so.1` açılamadığı bildirilen bir `DllNotFoundException` içeren `TypeInitializationException` hatasına yol açar. [System Requirements](/slides/tr/net/system-requirements/) içinde kurulumu kontrol eden kısa bir program bulunur.

## **Bulut ve Konteyner Hostları**

`libgdiplus` gerektirmediği için Aspose.Slides.NET6.CrossPlatform, `libgdiplus` yükleyemediğiniz Linux hostlarında kullanmanız gereken pakettir. Yine de `fontconfig` ve yazı tiplerine ihtiyaç duyar; minimal temel görüntülerde bunlar eksik olabilir. Örneğin .NET 8 için AWS Lambda temel görüntüsü ikisini de içermez. Bu görüntü üzerine kurulu bir konteynerde `dnf install -y fontconfig` komutunu çalıştırın; bu aynı zamanda Noto Sans yazı tiplerini de kurar.

Belirli bulut platformları için kılavuzlara [Aspose.Slides on Cloud Platforms](/slides/tr/net/slides-on-cloud-platforms/) üzerinden bakabilirsiniz.

## **Aynı Projede System.Drawing.Common Kullanımı (CS0433)**

Aspose.Slides.NET6.CrossPlatform kullanan bir proje, doğrudan veya başka bir paket aracılığıyla System.Drawing.Common'ı da referans alabilir. Aspose.Slides'in mevcut sürümü `System` ad alanlarında hiç kamu tipi yayınlamaz, bu yüzden iki kütüphane çakışmaz ve aynı dosyada `Aspose.Slides` ve `System.Drawing` ad alanlarını içe aktarabilirsiniz.

Eğer derleyici, `Image` ya da `Graphics` gibi bir tipin hem Aspose.Slides hem de System.Drawing.Common içinde bulunduğu için CS0433 hatası veriyorsa, projeniz Aspose.Slides'in eski bir sürümünü kullanıyor demektir. Paketi en yeni sürüme güncelleyin. Aspose.Slides, render edilen görüntüleri [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) nesneleri olarak döndürür; bu nesneler [Modern API](/slides/tr/net/modern-api/) içinde açıklanmıştır.

## **FAQ**

**Aspose.Slides.NET'den Aspose.Slides.NET6.CrossPlatform'a geçerken kodumu değiştirmem gerekir mi?**

Hayır. Her iki paket de aynı Aspose.Slides ad alanlarını ve sınıflarını sağlar, bu yüzden sadece paket referansını değiştirmeniz yeterlidir. Aspose.Slides.NET6.CrossPlatform `System.Drawing.EnableUnixSupport` anahtarına ihtiyaç duymaz. Bir projeye sadece bu iki paketten birini ekleyin.

**Aspose.Slides.NET6.CrossPlatform'ı bir .NET Framework projesinde kullanabilir miyim?**

Hayır. Paket yalnızca .NET 6 ve sonraki sürümleri hedefler. .NET Framework 4.6.2 ve sonrası için Aspose.Slides.NET kullanın.