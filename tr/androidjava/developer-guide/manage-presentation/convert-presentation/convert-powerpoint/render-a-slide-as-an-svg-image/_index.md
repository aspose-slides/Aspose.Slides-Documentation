---
title: Android'de Sunum Slaytlarını SVG Görüntüleri Olarak İşlemek
linktitle: Slaytı SVG'ye
type: docs
weight: 50
url: /tr/androidjava/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint'ten SVG'ye
- sunumdan SVG'ye
- slayttan SVG'ye
- PPT'den SVG'ye
- PPTX'ten SVG'ye
- PPT'yi SVG olarak kaydet
- PPTX'i SVG olarak kaydet
- PPT'yi SVG'ye dışa aktar
- PPTX'i SVG'ye dışa aktar
- slaytı işlemek
- slaytı dönüştürmek
- slaytı dışa aktarmak
- vektör görüntü
- PowerPoint
- sunum
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android kullanarak PowerPoint slaytlarını SVG görüntüleri olarak nasıl işleteceğinizi öğrenin. Basit Java kod örnekleriyle yüksek kaliteli görseller."
---
## **Genel Bakış**

Bu makale, Aspose.Slides kullanarak sunum slaytlarını SVG görüntüleri olarak nasıl işleneceğini açıklar. SVG formatını ve ölçeklenebilirlik, erişilebilirlik ve web geliştirme için uygunluk gibi avantajlarını tanımlar.

Sunum dosyasını nasıl yükleyeceğinizi, slaytları üzerinden nasıl döneceğinizi ve her bir slaytı ayrı bir SVG dosyası olarak nasıl kaydedeceğinizi öğreneceksiniz. Makale, PPT, PPTX, ODP ve PPS dahil olmak üzere PowerPoint ve OpenDocument sunum formatlarını kapsar ve dönüşümün `Presentation` sınıfı ve `writeAsSvg` yöntemiyle programlı olarak nasıl yapılacağını gösterir.

## **SVG Formatı**

SVG—Scalable Vector Graphics (Ölçeklenebilir Vektör Grafikleri) kısaltmasıdır—iki boyutlu görüntüleri işlemek için kullanılan bir standart grafik türü veya formatıdır. SVG, görüntüleri davranışlarını veya görünüşlerini tanımlayan ayrıntılarla XML içinde vektör olarak depolar.

SVG, ölçeklenebilirlik, etkileşim, performans, erişilebilirlik, programlanabilirlik ve diğerleri gibi çok yüksek standartları karşılayan nadir görüntü formatlarından biridir. Bu nedenlerle, web geliştirmede yaygın olarak kullanılır.

SVG dosyalarını şu durumlarda kullanmak isteyebilirsiniz:

- **sunumunuzu *çok büyük bir formatta* yazdırmak**. SVG görüntüler herhangi bir çözünürlük veya seviyeye kadar ölçeklenebilir. Kaliteden ödün vermeden SVG görüntülerini gerektiği kadar yeniden boyutlandırabilirsiniz.
- **slaytlarınızdaki grafik ve çizelgeleri *farklı ortam veya platformlarda* kullanmak**. Çoğu okuyucu SVG dosyalarını yorumlayabilir.
- **görüntüleri *mümkün olan en küçük boyutlarda* kullanmak**. SVG dosyaları genellikle diğer formatlardaki yüksek çözünürlüklü eşdeğerlerinden daha küçüktür, özellikle bitmap (JPEG veya PNG) tabanlı formatlar.

## **Bir Slaytı SVG Görüntüsü Olarak İşlemek**

Aspose.Slides for Android via Java, sunumlarınızdaki slaytları SVG görüntüleri olarak dışa aktarmanıza olanak tanır. SVG görüntüleri oluşturmak için şu adımları izleyin:

1. Presentation sınıfının bir örneğini oluşturun.
2. Sunumdaki tüm slaytlar üzerinde döngü yapın.
3. Her slaytı FileOutputStream aracılığıyla kendi SVG dosyasına yazın.

{{% alert color="primary" %}} 
Aspose.Slides for Android via Java'dan PPT'den SVG'ye dönüşüm işlevini uyguladığımız [ücretsiz web uygulamamızı](https://products.aspose.app/slides/tr/conversion/ppt-to-svg) denemek isteyebilirsiniz.
{{% /alert %}} 

Java'da bu örnek kod, Aspose.Slides kullanarak PPT'yi SVG'ye nasıl dönüştüreceğinizi gösterir:

``` java
Presentation pres = new Presentation("pres.pptx");
try {
    for (int index = 0; index < pres.getSlides().size(); index++)
    {
        ISlide slide = pres.getSlides().get_Item(index);

        FileOutputStream fileStream = new FileOutputStream("slide-" + index + ".svg");
        try {
            slide.writeAsSvg(fileStream);
        } finally {
            fileStream.close();
        }
    }
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **SSS**

**Sonuçta oluşan SVG, tarayıcılara göre neden farklı görünebilir?**

Belirli SVG özelliklerinin desteği tarayıcı motorları tarafından farklı şekilde uygulanır. [SVGOptions](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/svgoptions/) parametreleri, uyumsuzlukları gidermeye yardımcı olur.

**Yalnızca slaytları değil, aynı zamanda ayrı şekilleri de SVG olarak dışa aktarmak mümkün mü?**

Evet. Herhangi bir [şekil ayrı bir SVG olarak kaydedilebilir](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-), bu da simgeler, piktogramlar ve grafiklerin yeniden kullanımı için uygundur.

**Birden fazla slayt tek bir SVG (strip/döküman) içine birleştirilebilir mi?**

Standart senaryo bir slayt → bir SVG'dir. Birden fazla slaytı tek bir SVG tuvali içinde birleştirmek, uygulama seviyesinde gerçekleştirilen bir son‑işlem adımıdır.