---
title: Sunumlara JavaScript'te Elips Ekleme
linktitle: Elips
type: docs
weight: 30
url: /tr/nodejs-java/ellipse/
keywords:
- elips
- şekil
- elips ekle
- elips oluştur
- elips çiz
- biçimlendirilmiş elips
- PowerPoint
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js içinde PPT ve PPTX sunumları için elips şekilleri oluşturmayı, biçimlendirmeyi ve manipüle etmeyi öğrenin—JavaScript kod örnekleri dahil."
---
## **Genel Bakış**

Bu makale, Aspose.Slides kullanarak PowerPoint slaytlarına elips şekilleri eklemeyi gösterir. Basit bir elips oluşturmayı, biçimlendirilmiş bir elips oluşturmayı ve güncellenmiş sunumu PPTX dosyası olarak kaydetmeyi kapsar. Ayrıca elips konumu ve boyutu üzerinde çalışma, yığılma sırasını kontrol etme ve animasyon efektleri uygulama gibi ilgili sorulara da değinir.

## **Elips Oluştur**
Sunumun seçili bir slaytına basit bir elips eklemek için aşağıdaki adımları izleyin:

- Bir [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation) sınıfının bir örneğini oluşturun.
- Bir slaytın referansını, **Index**ini kullanarak alın.
- Elips türünde bir AutoShape eklemek için [ShapeCollection](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ShapeCollection) nesnesi tarafından sunulan [addAutoShape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ShapeCollection#addAutoShape-int-float-float-float-float-) yöntemini kullanın.
- Değiştirilmiş sunumu PPTX dosyası olarak yazın.

Aşağıdaki örnekte, ilk slayta bir elips ekledik

```javascript
// PPTX'i temsil eden Presentation sınıfını örnekleyin
var pres = new aspose.slides.Presentation();
try {
    // İlk slaytı al
    var sld = pres.getSlides().get_Item(0);
    // Elips tipinde AutoShape ekle
    sld.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 50, 150, 150, 50);
    // PPTX dosyasını diske yaz
    pres.save("EllipseShp1.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Biçimlendirilmiş Elips Oluştur**
Bir slayta daha iyi biçimlendirilmiş bir elips eklemek için aşağıdaki adımları izleyin:

- Bir [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation) sınıfının bir örneğini oluşturun.
- Bir slaytın referansını, **Index**ini kullanarak alın.
- Elips türünde bir AutoShape eklemek için [ShapeCollection](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ShapeCollection) nesnesi tarafından sunulan [addAutoShape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ShapeCollection#addAutoShape-int-float-float-float-float-) yöntemini kullanın.
- Elipsin Doldurma Türünü **Solid** olarak ayarlayın.
- Elipsin rengini, [FillFormat](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/FillFormat) nesnesi tarafından sunulan **SolidFillColor.Color** özelliğini kullanarak ayarlayın.
- Elipsin çizgi rengini ayarlayın.
- Elipsin çizgi genişliğini ayarlayın.
- Değiştirilmiş sunumu PPTX dosyası olarak yazın.

Aşağıdaki örnekte, sunumun ilk slaytına biçimlendirilmiş bir elips ekledik.

```javascript
// PPTX'i temsil eden Presentation sınıfını örnekleyin
var pres = new aspose.slides.Presentation();
try {
    // İlk slaytı al
    var sld = pres.getSlides().get_Item(0);
    // Elips tipinde AutoShape ekle
    var shp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 50, 150, 150, 50);
    // Elips şekline bazı biçimlendirmeler uygula
    shp.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shp.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", aspose.slides.PresetColor.Chocolate));
    // Elipsin çizgisine bazı biçimlendirmeler uygula
    shp.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    shp.getLineFormat().setWidth(5);
    // PPTX dosyasını diske yaz
    pres.save("EllipseShp1.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```
 
## **SSS**

**Bir elipsin konumunu ve boyutunu slayt birimlerine göre tam olarak nasıl ayarlarım?**

Koordinatlar ve boyutlar genellikle **nokta** cinsinden belirtilir. Öngörülebilir sonuçlar için, hesaplamalarınızı slayt boyutuna göre yapın ve değerleri atamadan önce gereken milimetre veya inçleri noktalara dönüştürün.

**Bir elipsi diğer nesnelerin üzerine ya da altına nasıl yerleştiririm (yığılma sırasını kontrol ederim)?**

Nesnenin çizim sırasını öne getirerek ya da arkaya göndererek ayarlayın. Bu, elipsin diğer nesnelerin üstüne gelmesini veya altındakileri ortaya çıkarmasını sağlar.

**Bir elipsin görünümünü veya vurgusunu nasıl canlandırırım?**

[Apply](/slides/tr/nodejs-java/shape-animation/) giriş, vurgu veya çıkış efektlerini şekle uygulayın ve animasyonun ne zaman ve nasıl oynatılacağını düzenlemek için tetikleyicileri ve zamanlamayı yapılandırın.