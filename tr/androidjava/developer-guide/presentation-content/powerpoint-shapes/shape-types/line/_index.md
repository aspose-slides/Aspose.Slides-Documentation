---
title: Android'de Sunumlara Çizgi Şekilleri Ekleme
linktitle: Çizgi
type: docs
weight: 50
url: /tr/androidjava/Line/
keywords:
- çizgi
- çizgi oluştur
- çizgi ekle
- düz çizgi
- çizgi yapılandır
- çizgi özelleştir
- çizgi dash stili
- ok ucu
- PowerPoint
- sunum
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android ile PowerPoint sunumlarında çizgi biçimlendirmesini nasıl manipüle edeceğinizi öğrenin. Özellikleri, yöntemleri ve Java örneklerini keşfedin."
---
## **Genel Bakış**

Aspose.Slides, PowerPoint slaytlarına programlı olarak çizgi şekilleri eklemenizi sağlar. Bu makale, basit bir çizgi oluşturmayı ve bir çizgiyi ok şeklinde nasıl özelleştireceğinizi gösterir.

Bir slayta çizgi şekli eklemeyi, görsel görünümünü ayarlamayı ve güncellenmiş sunumu kaydetmeyi öğreneceksiniz. Örnekler, stil, genişlik, tire deseni, ok ucu seçenekleri ve dolgu rengi gibi pratik çizgi biçimlendirme ayarlarına odaklanır.

## **Düz Bir Çizgi Oluşturma**

Sunumun seçili bir slaytına basit bir düz çizgi eklemek için aşağıdaki adımları izleyin:

- [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturun.
- Slaytının dizinini kullanarak slayt referansını alın.
- [IShapeCollection](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IShapeCollection) nesnesi tarafından sunulan [addAutoShape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) yöntemiyle Çizgi türünde bir AutoShape ekleyin.
- Değiştirilen sunumu PPTX dosyası olarak yazın.

Aşağıdaki örnekte, sunumun ilk slaytına bir çizgi ekledik.

```java
// PPTX dosyasını temsil eden PresentationEx sınıfını örnekleyin
Presentation pres = new Presentation();
try {
    // İlk slaytı al
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Çizgi tipinde bir AutoShape ekle
    sld.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);
    
    // PPTX dosyasını diske kaydet
    pres.save("LineShape.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ok Şeklinde Çizgi Oluşturma**

Aspose.Slides for Android via Java, geliştiricilerin çizginin bazı özelliklerini daha çekici hale getirecek şekilde yapılandırmasına da olanak tanır. Çizgiyi ok gibi göstermek için birkaç özelliği yapılandıralım. Bunu yapmak için aşağıdaki adımları izleyin:

- [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturun.
- Slaytının dizinini kullanarak slayt referansını alın.
- [IShapeCollection](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IShapeCollection) nesnesi tarafından sunulan [addAutoShape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) yöntemiyle Çizgi türünde bir AutoShape ekleyin.
- [Line Style](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/LineStyle) özelliğini Aspose.Slides for Android via Java tarafından sunulan stillerden biri olarak ayarlayın.
- Çizginin genişliğini ayarlayın.
- [Dash Style](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/LineDashStyle) özelliğini Aspose.Slides for Android via Java tarafından sunulan stillerden biri olarak ayarlayın.
- Çizginin başlangıç noktasının [Arrow Head Style](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/LineArrowheadStyle) ve [Length](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/LineArrowheadLength) özelliklerini ayarlayın.
- Çizginin bitiş noktasının [Arrow Head Style](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/LineArrowheadStyle) ve [Length](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/LineArrowheadLength) özelliklerini ayarlayın.
- Değiştirilen sunumu PPTX dosyası olarak yazın.

```java
// PPTX dosyasını temsil eden PresentationEx sınıfını örnekleyin
Presentation pres = new Presentation();
try {
    // İlk slaytı al
    ISlide sld = pres.getSlides().get_Item(0);

    // Çizgi tipinde bir AutoShape ekle
    IAutoShape shp = sld.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);

    // Çizgiye bazı biçimlendirmeler uygulayın
    shp.getLineFormat().setStyle(LineStyle.ThickBetweenThin);
    shp.getLineFormat().setWidth(10);

    shp.getLineFormat().setDashStyle(LineDashStyle.DashDot);

    shp.getLineFormat().setBeginArrowheadLength(LineArrowheadLength.Short);
    shp.getLineFormat().setBeginArrowheadStyle(LineArrowheadStyle.Oval);

    shp.getLineFormat().setEndArrowheadLength(LineArrowheadLength.Long);
    shp.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle);

    shp.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(new Color(PresetColor.Maroon));

    // PPTX dosyasını diske kaydedin
    pres.save("LineShape.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **SSS**

**Normal bir çizgiyi bağlayıcıya dönüştürüp şekillere “yapışmasını” sağlayabilir miyim?**

Hayır. Normal bir çizgi (type [Line](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/shapetype/) olan bir [AutoShape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/autoshape/)) otomatik olarak bağlayıcı olmaz. Şekillere yapışmasını sağlamak için özel [Connector](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/connector/) türünü ve bağlantılar için [corresponding APIs](/slides/tr/androidjava/connector/) kullanın.

**Bir çizginin özellikleri temadan devralındıysa ve nihai değerleri belirlemek zor ise ne yapmalıyım?**

[ILineFormatEffectiveData](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ilinefillformateffectivedata/) arayüzleri aracılığıyla [etkili özellikleri okuyun](/slides/tr/androidjava/shape-effective-properties/)—bunlar zaten kalıtımı ve tema stillerini hesaba katar.

**Bir çizgiyi düzenlemeye (taşıma, yeniden boyutlandırma) karşı kilitleyebilir miyim?**

Evet. Şekiller, düzenleme işlemlerine izin vermemek için [lock objects](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/autoshape/#getAutoShapeLock--) sağlar.