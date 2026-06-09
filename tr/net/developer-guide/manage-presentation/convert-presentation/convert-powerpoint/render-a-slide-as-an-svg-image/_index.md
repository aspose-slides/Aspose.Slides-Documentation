---
title: ".NET'te Sunum Slaytlarını SVG Görüntüleri Olarak Oluşturma"
linktitle: "Slaytı SVG'ye"
type: docs
weight: 50
url: /tr/net/render-a-slide-as-an-svg-image/
keywords:
- "PowerPoint'ten SVG'ye"
- "sunumdan SVG'ye"
- "slayttan SVG'ye"
- "PPT'den SVG'ye"
- "PPTX'ten SVG'ye"
- "PPT'yi SVG olarak kaydet"
- "PPTX'i SVG olarak kaydet"
- "PPT'yi SVG'ye dışa aktar"
- "PPTX'i SVG'ye dışa aktar"
- "slaytı oluştur"
- "slaytı dönüştür"
- "slaytı dışa aktar"
- "vektör görüntü"
- "PowerPoint"
- "sunum"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "Aspose.Slides for .NET kullanarak PowerPoint slaytlarını SVG görüntüleri olarak oluşturmayı öğrenin. Basit C# kod örnekleriyle yüksek kaliteli görseller."
---
## **Genel Bakış**

Bu makale, Aspose.Slides kullanarak sunum slaytlarını SVG görüntüleri olarak nasıl oluşturacağınızı açıklar. SVG formatını ve ölçeklenebilirlik, erişilebilirlik ve web geliştirme için uygunluk gibi avantajlarını açıklar.

Sunum dosyasını nasıl yükleyeceğinizi, slaytları nasıl yineleyeceğinizi ve her slaytı ayrı bir SVG dosyası olarak nasıl kaydedeceğinizi öğreneceksiniz. Makale, PPT, PPTX, ODP ve PPS dahil olmak üzere PowerPoint ve OpenDocument sunum formatlarını kapsar ve dönüşümün `Presentation` sınıfı ve `WriteAsSvg` yöntemiyle programlı olarak nasıl yapılacağını gösterir.

## **SVG Biçimi**
SVG—Scalable Vector Graphics (Ölçeklenebilir Vektör Grafikleri) kısaltmasıdır—iki boyutlu görüntüler oluşturmak için kullanılan standart bir grafik türü veya formatıdır. SVG, görüntüleri davranışlarını veya görünümünü tanımlayan ayrıntılarla XML içinde vektör olarak depolar.

SVG, ölçeklenebilirlik, etkileşim, performans, erişilebilirlik, programlanabilirlik ve benzeri konularda çok yüksek standartları karşılayan birkaç formattan biridir. Bu nedenlerle web geliştirmede yaygın olarak kullanılır.

- **sunumunuzu *çok büyük bir formatta* yazdırın**. SVG görüntüleri herhangi bir çözünürlüğe veya seviyeye ölçeklenebilir. Kaliteden ödün vermeden SVG görüntülerini ihtiyacınız kadar yeniden boyutlandırabilirsiniz.
- **slaytlarınızdan grafik ve çizelgeleri *farklı ortamlar veya platformlarda* kullanın**. Çoğu okuyucu SVG dosyalarını yorumlayabilir.
- **görüntülerin *mümkün olan en küçük boyutlarını* kullanın**. SVG dosyaları genellikle diğer formatlardaki yüksek çözünürlüklü eşdeğerlerinden daha küçüktür, özellikle bitmap (JPEG veya PNG) tabanlı formatlar.

## **Bir Slaytı SVG Görüntüsü Olarak Oluşturma**

Aspose.Slides for .NET, sunumlarınızdaki slaytları SVG görüntüleri olarak dışa aktarmanıza olanak tanır. SVG görüntüleri oluşturmak için bu adımları izleyin:

_Adımlar: C#'ta PowerPoint'ten SVG'ye Dönüşümler_

Aşağıdaki örnek kod, bu dönüşümleri .NET kullanarak açıklar.
- <a name="csharp-powerpoint-to-svg" id="csharp-powerpoint-to-svg"><strong>Adımlar: PowerPoint'i C#'ta SVG'ye Dönüştür</strong></a>
- <a name="csharp-ppt-to-svg" id="csharp-ppt-to-svg"><strong>Adımlar: PPT'yi C#'ta SVG'ye Dönüştür</strong></a>
- <a name="csharp-pptx-to-svg" id="csharp-pptx-to-svg"><strong>Adımlar: PPTX'i C#'ta SVG'ye Dönüştür</strong></a>
- <a name="csharp-odp-to-svg" id="csharp-odp-to-svg"><strong>Adımlar: ODP'yi C#'ta SVG'ye Dönüştür</strong></a>

Kod Adımları:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
   * _.ppt_ uzantısı **PPT** dosyasını _Presentation_ sınıfı içinde yüklemek için.
   * _.pptx_ uzantısı **PPTX** dosyasını _Presentation_ sınıfı içinde yüklemek için.
   * _.odp_ uzantısı **ODP** dosyasını _Presentation_ sınıfı içinde yüklemek için.
   * _.pps_ uzantısı **PPS** dosyasını _Presentation_ sınıfı içinde yüklemek için.
2. Sunumdaki tüm slaytlar arasında yineleme yapın.
3. Her slaytı FileStream aracılığıyla ayrı bir SVG dosyasına yazın.

{{% alert color="primary" %}} 
Aspose.Slides for .NET'ten PPT'den SVG'ye dönüşüm işlevini uyguladığımız [ücretsiz web uygulamamızı](https://products.aspose.app/slides/tr/conversion/ppt-to-svg) denemek isteyebilirsiniz.
{{% /alert %}} 

Bu C# örnek kodu, Aspose.Slides kullanarak PowerPoint'i SVG'ye nasıl dönüştüreceğinizi gösterir:

``` csharp
// Presentation nesnesi PPT, PPTX, ODP gibi PowerPoint formatlarını yükleyebilir.
using (Presentation pres = new Presentation("pres.pptx"))
{
    for (var index = 0; index < pres.Slides.Count; index++)
    {
        ISlide slide = pres.Slides[index];

        using (FileStream fileStream = new FileStream($"slide-{index}.svg", FileMode.Create, FileAccess.Write))
        {
            slide.WriteAsSvg(fileStream);   
        }
    }
}
```

## **SSS**

**Neden elde edilen SVG tarayıcılara göre farklı görünebilir?**  
Belirli SVG özelliklerine destek tarayıcı motorları tarafından farklı uygulanır. [SVGOptions](https://reference.aspose.com/slides/tr/net/aspose.slides.export/svgoptions/) parametreleri uyumsuzlukları gidermeye yardımcı olur.

**Sadece slaytları değil, aynı zamanda tek tek şekilleri de SVG olarak dışa aktarmak mümkün mü?**  
Evet. Her [şekil ayrı bir SVG olarak kaydedilebilir](https://reference.aspose.com/slides/tr/net/aspose.slides/shape/writeassvg/), bu da simgeler, piktogramlar ve grafiklerin yeniden kullanılmasını kolaylaştırır.

**Birden fazla slayt tek bir SVG (şerit/belge) içinde birleştirilebilir mi?**  
Standart senaryo bir slayt → bir SVG'dir. Birkaç slaytı tek bir SVG tuvali içinde birleştirmek, uygulama seviyesinde gerçekleştirilen bir son‑işleme adımıdır.

## **Ayrıca Bakınız** 

Bu makale ayrıca aşağıdaki konuları da kapsar. Kodlar yukarıdakilerle aynıdır.

_Biçim_: **PowerPoint**
- [C# PowerPoint'ten SVG Kodu](#csharp-powerpoint-to-svg)
- [C# PowerPoint'ten SVG API](#csharp-powerpoint-to-svg)
- [C# PowerPoint'ten SVG Programlı](#csharp-powerpoint-to-svg)
- [C# PowerPoint'ten SVG Kütüphanesi](#csharp-powerpoint-to-svg)
- [C# PowerPoint'i SVG Olarak Kaydet](#csharp-powerpoint-to-svg)
- [C# PowerPoint'ten SVG Oluştur](#csharp-powerpoint-to-svg)
- [C# PowerPoint'ten SVG Oluşturma](#csharp-powerpoint-to-svg)
- [C# PowerPoint'ten SVG Dönüştürücü](#csharp-powerpoint-to-svg)

_Biçim_: **PPT**
- [C# PPT'den SVG Kodu](#csharp-ppt-to-svg)
- [C# PPT'den SVG API](#csharp-ppt-to-svg)
- [C# PPT'den SVG Programlı](#csharp-ppt-to-svg)
- [C# PPT'den SVG Kütüphanesi](#csharp-ppt-to-svg)
- [C# PPT'yi SVG Olarak Kaydet](#csharp-ppt-to-svg)
- [C# PPT'den SVG Oluştur](#csharp-ppt-to-svg)
- [C# PPT'den SVG Oluşturma](#csharp-ppt-to-svg)
- [C# PPT'den SVG Dönüştürücü](#csharp-ppt-to-svg)

_Biçim_: **PPTX**
- [C# PPTX'den SVG Kodu](#csharp-pptx-to-svg)
- [C# PPTX'den SVG API](#csharp-pptx-to-svg)
- [C# PPTX'den SVG Programlı](#csharp-pptx-to-svg)
- [C# PPTX'den SVG Kütüphanesi](#csharp-pptx-to-svg)
- [C# PPTX'i SVG Olarak Kaydet](#csharp-pptx-to-svg)
- [C# PPTX'den SVG Oluştur](#csharp-pptx-to-svg)
- [C# PPTX'den SVG Oluşturma](#csharp-pptx-to-svg)
- [C# PPTX'den SVG Dönüştürücü](#csharp-pptx-to-svg)

_Biçim_: **ODP**
- [C# ODP'den SVG Kodu](#csharp-odp-to-svg)
- [C# ODP'den SVG API](#csharp-odp-to-svg)
- [C# ODP'den SVG Programlı](#csharp-odp-to-svg)
- [C# ODP'den SVG Kütüphanesi](#csharp-odp-to-svg)
- [C# ODP'yi SVG Olarak Kaydet](#csharp-odp-to-svg)
- [C# ODP'den SVG Oluştur](#csharp-odp-to-svg)
- [C# ODP'den SVG Oluşturma](#csharp-odp-to-svg)
- [C# ODP'den SVG Dönüştürücü](#csharp-odp-to-svg)