---
title: Java'da Sunumlara Elips Ekleme
linktitle: Elips
type: docs
weight: 30
url: /tr/java/ellipse/
keywords:
- elips
- şekil
- elips ekle
- elips oluştur
- elips çiz
- biçimlendirilmiş elips
- PowerPoint
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides for Java kullanarak PPT ve PPTX sunumlarında elips şekilleri oluşturmayı, biçimlendirmeyi ve manipüle etmeyi öğrenin—Java kod örnekleri dahil."
---
## **Genel Bakış**

Bu makale, Aspose.Slides kullanarak PowerPoint slaytlarına elips şekilleri eklemeyi gösterir. Basit bir elips oluşturmayı, biçimlendirilmiş bir elips oluşturmayı ve güncellenmiş sunumu PPTX dosyası olarak kaydetmeyi kapsar. Ayrıca elips konumu ve boyutu, yığılma sırasını kontrol etme ve animasyon efektleri uygulama gibi ilgili konulara da değinir.

## **Elips Oluşturma**
Sunumun seçili slaytına basit bir elips eklemek için aşağıdaki adımları izleyin:

- [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation) sınıfının bir örneğini oluşturun.
- Slaytın indeksini kullanarak slayt referansını alın.
- [IShapeCollection](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IShapeCollection) nesnesi tarafından sunulan [addAutoShape](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) yöntemini kullanarak Ellipse türünde bir AutoShape ekleyin.
- Değiştirilmiş sunumu PPTX dosyası olarak yazın.

Aşağıdaki örnekte, ilk slayta bir elips ekledik

```java
// PPTX'i temsil eden Presentation sınıfını oluştur
Presentation pres = new Presentation();
try {
    // İlk slaytı al
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Elips türünde AutoShape ekle
    sld.getShapes().addAutoShape(ShapeType.Ellipse, 50, 150, 150, 50);
    
    // PPTX dosyasını diske yaz
    pres.save("EllipseShp1.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Biçimlendirilmiş Elips Oluşturma**
Bir slayta daha iyi biçimlendirilmiş bir elips eklemek için aşağıdaki adımları izleyin:

- [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation) sınıfının bir örneğini oluşturun.
- Slaytın indeksini kullanarak slayt referansını alın.
- [IShapeCollection](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IShapeCollection) nesnesi tarafından sunulan [addAutoShape](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) yöntemini kullanarak Ellipse türünde bir AutoShape ekleyin.
- Elipsin Dolgu Türünü Katı olarak ayarlayın.
- [FillFormat](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IFillFormat) nesnesi aracılığıyla [IShape](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IShape) nesnesine bağlı SolidFillColor.Color özelliğini kullanarak Elipsin Rengini ayarlayın.
- Elipsin hatlarının Rengini ayarlayın.
- Elipsin hatlarının Genişliğini ayarlayın.
- Değiştirilmiş sunumu PPTX dosyası olarak yazın.

Aşağıdaki örnekte, sunumun ilk slaytına biçimlendirilmiş bir elips ekledik.

```java
// PPTX'i temsil eden Presentation sınıfını oluştur
Presentation pres = new Presentation();
try {
    // İlk slaytı al
    ISlide sld = pres.getSlides().get_Item(0);

    // Elips türünde AutoShape ekle
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Ellipse, 50, 150, 150, 50);

    // Elips şekline bazı biçimlendirmeler uygula
    shp.getFillFormat().setFillType(FillType.Solid);
    shp.getFillFormat().getSolidFillColor().setColor(new Color(PresetColor.Chocolate));

    // Elipsin çizgisinde bazı biçimlendirmeler uygula
    shp.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shp.getLineFormat().setWidth(5);

    // PPTX dosyasını diske kaydet
    pres.save("EllipseShp1.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **SSS**

**Elipsin slayt birimlerine göre tam konumunu ve boyutunu nasıl ayarlarım?**

Koordinatlar ve boyutlar genellikle **puan** cinsinden belirtilir. Öngörülebilir sonuçlar elde etmek için hesaplamalarınızı slayt boyutuna göre yapın ve değerleri atamadan önce gerekli milimetre veya inçleri puana dönüştürün.

**Elipsi diğer nesnelerin üstüne veya altına nasıl yerleştiririm (yığılma sırasını kontrol etme)?**

Nesnenin çizim sırasını öne getirme ya da arkaya gönderme ile ayarlayın. Bu, elipsin diğer nesnelerin üstüne gelmesini veya altında kalanları ortaya çıkarmasını sağlar.

**Elipsin görünümünü veya vurgusunu nasıl canlandırırım?**

[Apply](/slides/tr/java/shape-animation/) giriş, vurgulama veya çıkış efektlerini şekle uygulayın ve tetikleyicileri ile zamanlamayı yapılandırarak animasyonun ne zaman ve nasıl oynatılacağını yönetin.