---
title: Java'da Sunumlara Çizgi Şekilleri Eklemek
linktitle: Çizgi
type: docs
weight: 50
url: /tr/java/Line/
keywords:
- çizgi
- çizgi oluştur
- çizgi ekle
- düz çizgi
- çizgi yapılandır
- çizgi özelleştir
- kesikli stil
- ok ucu
- PowerPoint
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides for Java ile PowerPoint sunumlarında çizgi biçimlendirmesini nasıl yönetebileceğinizi öğrenin. Özellikleri, yöntemleri ve örnekleri keşfedin."
---
## **Genel Bakış**

Aspose.Slides, PowerPoint slaytlarına programlı olarak çizgi şekilleri eklemenizi sağlar. Bu makale, basit bir çizgi oluşturmayı ve çizgiyi ok gibi görüncek şekilde özelleştirmeyi gösterir.

Bir slayta çizgi şekli eklemeyi, görsel görünümünü ayarlamayı ve güncellenmiş sunumu kaydetmeyi öğreneceksiniz. Örnekler, stil, genişlik, kesikli desen, ok ucu seçenekleri ve dolgu rengi gibi pratik çizgi biçimlendirme ayarlarına odaklanır.

## **Düz Çizgi Oluşturma**

Seçili bir slayta basit bir düz çizgi eklemek için aşağıdaki adımları izleyin:

- Bir [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturun.
- Bir slaydın referansını, dizinini (Index) kullanarak alın.
- Bir AutoShape'i Çizgi (Line) türünde eklemek için [IShapeCollection](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IShapeCollection) nesnesi tarafından sunulan [addAutoShape](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) yöntemini kullanın.
- Değiştirilmiş sunumu PPTX dosyası olarak yazın.

```java
// PresentationEx sınıfını temsil eden PPTX dosyasını örnekleyin
Presentation pres = new Presentation();
try {
    // İlk slaytı alın
    ISlide sld = pres.getSlides().get_Item(0);
    
    // türü line olan bir AutoShape ekleyin
    sld.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);
    
    // PPTX'i diske yazdırın
    pres.save("LineShape.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ok Şeklinde Çizgi Oluşturma**

Aspose.Slides for Java ayrıca geliştiricilerin bir çizginin görünümünü daha çekici hale getirmek için bazı özelliklerini yapılandırmasına olanak tanır. Çizgiyi bir ok gibi göstermek için birkaç özelliği yapılandıralım. Bunu yapmak için aşağıdaki adımları izleyin:

- Bir [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturun.
- Bir slaydın referansını, dizinini (Index) kullanarak alın.
- Bir AutoShape'i Çizgi (Line) türünde eklemek için [IShapeCollection](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IShapeCollection) nesnesi tarafından sunulan [addAutoShape](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) yöntemini kullanın.
- [Line Style](https://reference.aspose.com/slides/tr/java/com.aspose.slides/LineStyle) öğesini, Aspose.Slides for Java tarafından sunulan stillerden birine ayarlayın.
- Çizginin Genişliğini ayarlayın.
- Çizginin [Dash Style](https://reference.aspose.com/slides/tr/java/com.aspose.slides/LineDashStyle) öğesini, Aspose.Slides for Java tarafından sunulan stillerden birine ayarlayın.
- Çizginin başlangıç noktasının [Arrow Head Style](https://reference.aspose.com/slides/tr/java/com.aspose.slides/LineArrowheadStyle) ve [Length](https://reference.aspose.com/slides/tr/java/com.aspose.slides/LineArrowheadLength) öğelerini ayarlayın.
- Çizginin bitiş noktasının [Arrow Head Style](https://reference.aspose.com/slides/tr/java/com.aspose.slides/LineArrowheadStyle) ve [Length](https://reference.aspose.com/slides/tr/java/com.aspose.slides/LineArrowheadLength) öğelerini ayarlayın.
- Değiştirilmiş sunumu PPTX dosyası olarak yazın.

```java
// PPTX dosyasını temsil eden PresentationEx sınıfını örnekleyin
Presentation pres = new Presentation();
try {
    // İlk slaytı al
    ISlide sld = pres.getSlides().get_Item(0);

    // line tipinde bir AutoShape ekle
    IAutoShape shp = sld.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);

    // çizgi üzerinde bazı biçimlendirmeler uygulayın
    shp.getLineFormat().setStyle(LineStyle.ThickBetweenThin);
    shp.getLineFormat().setWidth(10);

    shp.getLineFormat().setDashStyle(LineDashStyle.DashDot);

    shp.getLineFormat().setBeginArrowheadLength(LineArrowheadLength.Short);
    shp.getLineFormat().setBeginArrowheadStyle(LineArrowheadStyle.Oval);

    shp.getLineFormat().setEndArrowheadLength(LineArrowheadLength.Long);
    shp.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle);

    shp.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(new Color(PresetColor.Maroon));

    // PPTX'i diske kaydedin
    pres.save("LineShape.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **SSS**

**Düzenli bir çizgiyi şekillere "yapışacak" bir bağlayıcıya dönüştürebilir miyim?**

Hayır. Düzenli bir çizgi (türü [Line](https://reference.aspose.com/slides/tr/java/com.aspose.slides/shapetype/) olan bir [AutoShape](https://reference.aspose.com/slides/tr/java/com.aspose.slides/autoshape/)) otomatik olarak bağlayıcı haline gelmez. Şekillere yapışmasını sağlamak için özel [Connector](https://reference.aspose.com/slides/tr/java/com.aspose.slides/connector/) türünü ve bağlantılar için [corresponding APIs](/slides/tr/java/connector/) kullanın.

**Bir çizginin özellikleri temadan miras alındığında ve nihai değerleri belirlemek zor olduğunda ne yapmalıyım?**

[Etkili özellikleri](/slides/tr/java/shape-effective-properties/) [ILineFormatEffectiveData](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ilinefillformateffectivedata/) arabirimleri üzerinden okuyun—bunlar zaten miras ve tema stillerini hesaba katar.

**Bir çizgiyi düzenlemeye (taşımaya, yeniden boyutlandırmaya) karşı kilitleyebilir miyim?**

Evet. Şekiller, [lock objects](https://reference.aspose.com/slides/tr/java/com.aspose.slides/autoshape/#getAutoShapeLock--) sağlar ve bu sayede [düzenleme işlemlerini engelleyebilirsiniz](/slides/tr/java/applying-protection-to-presentation/).