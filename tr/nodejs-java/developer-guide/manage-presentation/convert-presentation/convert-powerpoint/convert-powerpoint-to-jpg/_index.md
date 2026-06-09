---
title: JavaScript'te PPT ve PPTX'i JPG'ye Dönüştürme
linktitle: PowerPoint'ten JPG'ye
type: docs
weight: 60
url: /tr/nodejs-java/convert-powerpoint-to-jpg/
keywords:
- PowerPoint'i dönüştür
- sunumu dönüştür
- slaytı dönüştür
- PPT'yi dönüştür
- PPTX'i dönüştür
- PowerPoint'ten JPG'ye
- sunumu JPG'ye
- slaytı JPG'ye
- PPT'yi JPG'ye
- PPTX'i JPG'ye
- PowerPoint'i JPG olarak kaydet
- sunumu JPG olarak kaydet
- slaytı JPG olarak kaydet
- PPT'yi JPG olarak kaydet
- PPTX'in JPG olarak kaydet
- PPT'yi JPG'ye dışa aktar
- PPTX'i JPG'ye dışa aktar
- Node.js
- JavaScript
- Aspose.Slides
description: "JavaScript'te Aspose.Slides for Node.js via Java kullanarak hızlı ve güvenilir kod örnekleriyle PowerPoint (PPT, PPTX) slaytlarını yüksek kaliteli JPG görüntülerine dönüştürün."
---
## **Giriş**

PowerPoint ve OpenDocument sunumlarını JPG görüntülere dönüştürmek, slaytları paylaşmayı, performansı optimize etmeyi ve içeriği web sitelerine veya uygulamalara yerleştirmeyi kolaylaştırır. Aspose.Slides, PPTX, PPT ve ODP dosyalarını yüksek kalite JPEG görüntülere dönüştürmenizi sağlar. Bu kılavuz, dönüşümün farklı yöntemlerini açıklar.

Bu özelliklerle, kendi sunum görüntüleyicinizi uygulamak ve her slayt için bir küçük resim oluşturmak kolaydır. Bu, sunum slaytlarını kopyalamaya karşı korumak veya sunumu yalnızca okunabilir modda göstermek istediğinizde yararlı olabilir. Aspose.Slides, tüm sunumu veya belirli bir slaytı görüntü formatlarına dönüştürmenize izin verir.

## **PowerPoint PPT/PPTX'i JPG'ye Dönüştürme**
PPT/PPTX'i JPG'ye dönüştürmek için adımlar:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Presentation) örneği oluşturun.
2. [Presentation.getSlides()](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Presentation#getSlides--) koleksiyonundan bir [Slide](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Slide) nesnesi alın.
3. Her slaytın küçük resmini oluşturup ardından JPG'ye dönüştürün. [**Slide.getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Slide#getImage-float-float-) yöntemi, bir slaytın küçük resmini alır ve sonuç olarak bir [Images](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Images) nesnesi döndürür. [getImage](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Slide#getImage-aspose.slides.IRenderingOptions-float-float-) yöntemi, gerekli [Slide](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Slide) nesnesinden çağrılmalı ve çıkan küçük resmin ölçekleri metoda aktarılmalıdır.
4. Slayt küçük resmi elde edildikten sonra, küçük resim nesnesinden [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/iimage/#save) yöntemini çağırın. Oluşturulan dosya adını ve görüntü formatını bu yönteme geçirin.  

{{% alert color="primary" %}}

**Not**: PPT/PPTX'ten JPG'ye dönüşüm, Aspose.Slides API'sindeki diğer türlere dönüştürmeden farklıdır. Diğer türler için genellikle [**Presentation.Save(String fname, int format, ISaveOptions options)**](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Presentation#save-java.lang.String-int-aspose.slides.ISaveOptions-) yöntemi kullanılırken, burada [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/iimage/#save) yöntemi gerekmektedir.

{{% /alert %}} 

```javascript
var pres = new aspose.slides.Presentation("PowerPoint-Presentation.pptx");
try {
    for (let i = 0; i < pres.getSlides().size(); i++) {
        let sld = pres.getSlides().get_Item(i);
        // Tam ölçekli bir görüntü oluşturur
        var slideImage = sld.getImage(1.0, 1.0);
        // JPEG formatında resmi diske kaydeder
        try {
            slideImage.save(java.callStaticMethodSync("java.lang.String", "format", "Slide_%d.jpg", sld.getSlideNumber()), aspose.slides.ImageFormat.Jpeg);
        } finally {
            if (slideImage != null) {
                slideImage.dispose();
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Özelleştirilmiş Boyutlarla PowerPoint PPT/PPTX'i JPG'ye Dönüştürme**
Oluşturulan küçük resim ve JPG görüntüsünün boyutunu değiştirmek için *ScaleX* ve *ScaleY* değerlerini [**Slide.getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Slide#getImage-float-float-) metoduna parametre olarak geçirebilirsiniz:

```javascript
var pres = new aspose.slides.Presentation("PowerPoint-Presentation.pptx");
try {
    // Boyutları tanımlar
    var desiredX = 1200;
    var desiredY = 800;
    // X ve Y'nin ölçeklenmiş değerlerini alır
    var ScaleX = 1.0 / pres.getSlideSize().getSize().getWidth() * desiredX;
    var ScaleY = 1.0 / pres.getSlideSize().getSize().getHeight() * desiredY;
    for (let i = 0; i < pres.getSlides().size(); i++) {
        let sld = pres.getSlides().get_Item(i);
        // Tam ölçekli bir görüntü oluşturur
        var slideImage = sld.getImage(ScaleX, ScaleY);
        // Görüntüyü JPEG formatında diske kaydeder
        try {
            slideImage.save(java.callStaticMethodSync("java.lang.String", "format", "Slide_%d.jpg", sld.getSlideNumber()), aspose.slides.ImageFormat.Jpeg);
        } finally {
            if (slideImage != null) {
                slideImage.dispose();
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Sunumu Resim Olarak Kaydederken Yorumları İşleme**
Aspose.Slides for Node.js via Java, sunumdaki slaytlara yorumları render ederek bu slaytları görüntülere dönüştürmenizi sağlar. Bu JavaScript kodu işlemi gösterir:

```javascript
var pres = new aspose.slides.Presentation("presentation.pptx");
try {
    var notesOptions = new aspose.slides.NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(aspose.slides.NotesPositions.BottomTruncated);
    var opts = new aspose.slides.RenderingOptions();
    opts.setSlidesLayoutOptions(notesOptions);
    for (let i = 0; i < pres.getSlides().size(); i++) {
        let sld = pres.getSlides().get_Item(i);
        var slideImage = sld.getImage(opts, java.newInstanceSync("java.awt.Dimension", 740, 960));
        try {
            slideImage.save(java.callStaticMethodSync("java.lang.String", "format", "Slide_%d.png", sld.getSlideNumber()));
        } finally {
            if (slideImage != null) {
                slideImage.dispose();
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert title="İpucu" color="primary" %}}

Aspose, bir [ÜCRETSİZ Collage web uygulaması](https://products.aspose.app/slides/tr/collage) sunar. Bu çevrimiçi hizmeti kullanarak [JPG'den JPG'ye](https://products.aspose.app/slides/tr/collage/jpg) veya PNG'den PNG'ye görüntüleri birleştirebilir, [fotoğraf ızgaraları](https://products.aspose.app/slides/tr/collage/photo-grid) oluşturabilir ve benzeri işlemler yapabilirsiniz. 

{{% /alert %}}

## **Ayrıca Bakınız**

PPT/PPTX'i görüntüye dönüştürmenin diğer seçeneklerine bakın:

- [PPT/PPTX'ten SVG dönüşümü](/slides/tr/nodejs-java/render-a-slide-as-an-svg-image/).

## **SSS**

**Bu yöntem toplu dönüşümü destekliyor mu?**

Evet, Aspose.Slides birden çok slaytı tek bir işlemde JPG'ye toplu olarak dönüştürmenize olanak tanır.

**Dönüşüm SmartArt, grafikler ve diğer karmaşık nesneleri destekliyor mu?**

Evet, Aspose.Slides tüm içeriği, SmartArt, grafikler, tablolar, şekiller ve daha fazlasını render eder. Ancak, özel veya eksik yazı tipleri kullanıldığında render doğruluğu PowerPoint'e kıyasla biraz farklılık gösterebilir.

**İşlenebilecek slayt sayısı konusunda herhangi bir sınırlama var mı?**

Aspose.Slides kendisi işleyebileceğiniz slayt sayısı için katı bir sınır koymaz. Ancak büyük sunumlarla veya yüksek çözünürlüklü görüntülerle çalışırken bellek yetersizliği hatası alabilirsiniz.