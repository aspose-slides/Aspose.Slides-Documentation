---
title: Android'de Sunumlara Elips Ekleyin
linktitle: Elips
type: docs
weight: 30
url: /tr/androidjava/ellipse/
keywords:
- elips
- şekil
- elips ekle
- elips oluştur
- elips çiz
- biçimlendirilmiş elips
- PowerPoint
- sunum
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android'de PPT ve PPTX sunumları boyunca elips şekillerini oluşturma, biçimlendirme ve manipüle etme konusunda nasıl çalışılacağını öğrenin—Java kod örnekleri dahil."
---
## **Genel Bakış**

Bu makale, Aspose.Slides kullanarak PowerPoint slaytlarına elips şekilleri eklemeyi gösterir. Basit bir elips oluşturmayı, biçimlendirilmiş bir elips yaratmayı ve güncellenen sunumu PPTX dosyası olarak kaydetmeyi kapsar. Ayrıca elipsin konumu ve boyutu, yığılma sırasını kontrol etme ve animasyon efektleri uygulama gibi ilgili sorulara da değinir.

## **Elips Oluşturma**
Sunumun seçili bir slaytına basit bir elips eklemek için lütfen aşağıdaki adımları izleyin:

- Bir [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation) sınıfının bir örneğini oluşturun.
- Bir slaydın referansını indeksini kullanarak elde edin.
- Elips türünde bir AutoShape eklemek için [IShapeCollection](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IShapeCollection) nesnesi tarafından sunulan [addAutoShape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) metodunu kullanın.
- Değiştirilen sunumu PPTX dosyası olarak yazın.

Aşağıda verilen örnekte, ilk slayta bir elips ekledik

```java
// PPTX'i temsil eden Presentation sınıfını örnekleyin
Presentation pres = new Presentation();
try {
    // İlk slaytı alın
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Elips türünde AutoShape ekle
    sld.getShapes().addAutoShape(ShapeType.Ellipse, 50, 150, 150, 50);
    
    // PPTX dosyasını diske kaydedin
    pres.save("EllipseShp1.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Biçimlendirilmiş Elips Oluşturma**
Bir slayta daha iyi biçimlendirilmiş bir elips eklemek için lütfen aşağıdaki adımları izleyin:

- Bir [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation) sınıfının bir örneğini oluşturun.
- Bir slaydın referansını indeksini kullanarak elde edin.
- Elips türünde bir AutoShape eklemek için [IShapeCollection](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IShapeCollection) nesnesi tarafından sunulan [addAutoShape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) metodunu kullanın.
- Elipsin Doldurma Türünü Katı olarak ayarlayın.
- Elipsin Rengini, [IShape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IShape) nesnesiyle ilişkili [FillFormat](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IFillFormat) nesnesi tarafından sunulan SolidFillColor.Color özelliğini kullanarak ayarlayın.
- Elipsin çizgi rengini ayarlayın.
- Elipsin çizgi kalınlığını ayarlayın.
- Değiştirilen sunumu PPTX dosyası olarak yazın.

Aşağıda verilen örnekte, sunumun ilk slaytına biçimlendirilmiş bir elips ekledik.

```java
// PPTX'i temsil eden Presentation sınıfını örnekleyin
Presentation pres = new Presentation();
try {
    // İlk slaytı alın
    ISlide sld = pres.getSlides().get_Item(0);

    // Elips türünde AutoShape ekle
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Ellipse, 50, 150, 150, 50);

    // Elips şekline bazı biçimlendirmeler uygulayın
    shp.getFillFormat().setFillType(FillType.Solid);
    shp.getFillFormat().getSolidFillColor().setColor(new Color(PresetColor.Chocolate));

    // Elipsin çizgisine bazı biçimlendirmeler uygulayın
    shp.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shp.getLineFormat().setWidth(5);

    // PPTX dosyasını diske kaydedin
    pres.save("EllipseShp1.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **SSS**

**Bir elipsin konumunu ve boyutunu slayt birimlerine göre tam olarak nasıl ayarlarım?**  
Koordinatlar ve boyutlar genellikle **nokta** cinsinden belirtilir. Öngörülebilir sonuçlar için hesaplamalarınızı slayt boyutuna göre yapın ve değer atamadan önce gerekli milimetre veya inçleri noktalara dönüştürün.

**Bir elipsi diğer nesnelerin üzerine ya da altına nasıl yerleştiririm (yığılma sırasını kontrol etmek)?**  
Nesnenin çizim sırasını öne getirerek ya da geriye göndererek ayarlayın. Bu, elipsin diğer nesnelerin üzerine gelmesini veya altındaki nesneleri ortaya çıkarmasını sağlar.

**Bir elipsin görünümünü veya vurgusunu nasıl canlandırırım?**  
[Apply](/slides/tr/androidjava/shape-animation/) giriş, vurgu veya çıkış efektlerini şekle uygulayın ve tetikleyicileri ve zamanlamayı yapılandırarak animasyonun ne zaman ve nasıl oynatılacağını düzenleyin.