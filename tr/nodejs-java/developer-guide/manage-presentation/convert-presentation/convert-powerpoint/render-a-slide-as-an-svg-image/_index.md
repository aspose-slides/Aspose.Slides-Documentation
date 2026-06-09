---
title: JavaScript'te Sunum Slaytlarını SVG Görüntüleri Olarak Oluşturma
linktitle: Slaytı SVG'ye
type: docs
weight: 50
url: /tr/nodejs-java/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint'ten SVG'ye
- sunumdan SVG'ye
- slayttan SVG'ye
- PPT'den SVG'ye
- PPTX'ten SVG'ye
- PPT'yi SVG olarak kaydet
- PPTX'i SVG olarak kaydet
- PPT'yi SVG'ye aktar
- PPTX'i SVG'ye aktar
- slaytı renderla
- slaytı dönüştür
- slaytı dışa aktar
- vektör görüntü
- PowerPoint
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java kullanarak PowerPoint slaytlarını SVG görüntüleri olarak nasıl oluşturacağınızı öğrenin. Basit JavaScript kod örnekleriyle yüksek kaliteli görseller."
---
## **Genel Bakış**

Bu makale, Aspose.Slides kullanarak sunum slaytlarını SVG görüntüleri olarak nasıl oluşturacağınızı açıklar. SVG formatını ve ölçeklenebilirlik, erişilebilirlik ve web geliştirme için uygunluk gibi avantajlarını anlatır.

Bir sunum dosyasını nasıl yükleyeceğinizi, slaytlarını nasıl dolaşacağınızı ve her slaytı ayrı bir SVG dosyası olarak nasıl kaydedeceğinizi öğreneceksiniz. Makale, PPT, PPTX, ODP ve PPS dahil olmak üzere PowerPoint ve OpenDocument sunum formatlarını kapsar ve dönüşümün `Presentation` sınıfı ve `writeAsSvg` yöntemiyle programlı olarak nasıl gerçekleştirileceğini gösterir.

## **SVG Formatı**

SVG—Scalable Vector Graphics (Ölçeklenebilir Vektör Grafikleri) kısaltmasıdır—iki boyutlu görüntüleri oluşturmak için kullanılan standart bir grafik türü veya formatıdır. SVG, görüntüleri davranışlarını veya görünümünü tanımlayan ayrıntılarla XML içinde vektör olarak saklar.

SVG, ölçeklenebilirlik, etkileşim, performans, erişilebilirlik, programlanabilirlik ve benzeri konularda çok yüksek standartları karşılayan nadir görüntü formatlarından biridir. Bu nedenlerle, genellikle web geliştirmede kullanılır.

SVG dosyalarını şu durumlarda kullanmak isteyebilirsiniz

- **sunumunuzu *çok büyük bir formatta* yazdırın**. SVG görüntüleri herhangi bir çözünürlüğe veya seviyeye ölçeklenebilir. Kaliteden ödün vermeden SVG görüntülerini istediğiniz kadar yeniden boyutlandırabilirsiniz.
- **slaytlarınızdaki grafik ve çizelgeleri *farklı ortamlar veya platformlarda* kullanın**. Çoğu okuyucu SVG dosyalarını yorumlayabilir.
- **görüntülerin *olabilecek en küçük boyutlarını* kullanın**. SVG dosyaları genellikle diğer formatlardaki yüksek çözünürlüklü eşdeğerlerinden daha küçüktür, özellikle bitmap (JPEG veya PNG) tabanlı formatlardan.

## **Slaytları SVG Görüntüleri Olarak Oluşturma**

Aspose.Slides for Node.js via Java, sunumlarınızdaki slaytları SVG görüntüleri olarak dışa aktarmanıza olanak tanır. SVG görüntüleri oluşturmak için aşağıdaki adımları izleyin:

1. `Presentation` sınıfının bir örneğini oluşturun.
2. Sunumdaki tüm slaytlar üzerinde döngü oluşturun.
3. Her slaytı `FileOutputStream` aracılığıyla kendi SVG dosyasına yazın.

{{% alert color="primary" %}} 
PPT'den SVG'ye dönüşüm işlevini Aspose.Slides for Node.js via Java üzerinden uyguladığımız [ücretsiz web uygulamamızı](https://products.aspose.app/slides/tr/conversion/ppt-to-svg) deneyebilirsiniz.
{{% /alert %}} 

Bu JavaScript örnek kodu, Aspose.Slides kullanarak PPT'yi SVG'ye nasıl dönüştüreceğinizi gösterir:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    for (var index = 0; index < pres.getSlides().size(); index++) {
        var slide = pres.getSlides().get_Item(index);
        var fileStream = java.newInstanceSync("java.io.FileOutputStream", ("slide-" + index) + ".svg");
        try {
            slide.writeAsSvg(fileStream);
        } finally {
            fileStream.close();
        }
    }
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **SSS**

**Neden oluşan SVG tarayıcılara göre farklı görünebilir?**

Belirli SVG özelliklerinin desteği tarayıcı motorları tarafından farklı şekilde uygulanır. [SVGOptions](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/svgoptions/) parametreleri uyumsuzlukları gidermeye yardımcı olur.

**Sadece slaytları değil, aynı zamanda bireysel şekilleri de SVG olarak dışa aktarmak mümkün mü?**

Evet. Herhangi bir [şekil ayrı bir SVG olarak kaydedilebilir](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/shape/writeassvg/), bu da simgeler, piktogramlar ve grafiklerin yeniden kullanılmasını kolaylaştırır.

**Birden fazla slayt tek bir SVG (şerit/doküman) içinde birleştirilebilir mi?**

Standart senaryo bir slayt → bir SVG'dir. Birden fazla slaytı tek bir SVG tuvali içinde birleştirmek, uygulama seviyesinde yapılan bir son işlem adımıdır.