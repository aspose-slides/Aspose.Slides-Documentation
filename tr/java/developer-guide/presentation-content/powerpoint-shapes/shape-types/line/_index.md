---
title: Java'da Sunumlara Çizgi Şekilleri Ekle
linktitle: Çizgi
type: docs
weight: 50
url: /tr/java/line/
keywords:
- çizgi
- çizgi oluştur
- çizgi ekle
- düz çizgi
- çizgiyi yapılandır
- çizgiyi özelleştir
- kesikli stil
- ok ucu
- PowerPoint
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides for Java ile PowerPoint sunumlarında çizgi biçimlendirmesini nasıl manipüle edeceğinizi öğrenin. Özellikleri, yöntemleri ve örnekleri keşfedin."
---
## **Genel Bakış**

Aspose.Slides, PowerPoint slaytlarına programlı olarak çizgi şekilleri eklemenizi sağlar. Bu makale, basit bir çizgi oluşturmayı ve çizgiyi ok gibi görünecek şekilde nasıl özelleştireceğinizi gösterir.

Bir slayta çizgi şekli eklemeyi, görsel görünümünü ayarlamayı ve güncellenmiş sunumu kaydetmeyi öğreneceksiniz. Örnekler, stil, genişlik, kesikli desen, ok ucu seçenekleri ve dolgu rengi gibi pratik çizgi biçimlendirme ayarlarına odaklanır.

## **Düz Çizgi Oluştur**

Sunumun seçili slaytına basit bir düz çizgi eklemek için aşağıdaki adımları izleyin:

- Bir [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturun.
- İndeksini kullanarak bir slaytın referansını edinin.
- [addAutoShape](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) yöntemini kullanan [IShapeCollection](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IShapeCollection) nesnesi aracılığıyla Line tipinde bir AutoShape ekleyin.
- Değiştirilmiş sunumu PPTX dosyası olarak yazın.

Aşağıdaki örnekte, sunumun ilk slaytına bir çizgi ekledik.

```java
// PPTX dosyasını temsil eden PresentationEx sınıfını örnekle
Presentation pres = new Presentation();
try {
    // İlk slaytı al
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Çizgi tipinde bir AutoShape ekle
    sld.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);
    
    // PPTX'i diske yaz
    pres.save("LineShape.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ok Şeklinde Çizgi Oluştur**

Aspose.Slides for Java, geliştiricilerin çizgiyi daha çekici hâle getirmek için bazı özellikleri yapılandırmasına da izin verir. Çizgiyi ok gibi göstermek için birkaç özelliği yapılandıralım. Bunu aşağıdaki adımları izleyerek yapabilirsiniz:

- Bir [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturun.
- İndeksini kullanarak bir slaytın referansını edinin.
- [addAutoShape](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) yöntemini kullanan [IShapeCollection](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IShapeCollection) nesnesi aracılığıyla Line tipinde bir AutoShape ekleyin.
- [Line Style](https://reference.aspose.com/slides/tr/java/com.aspose.slides/LineStyle) özelliğini Aspose.Slides for Java tarafından sunulan stillerden birine ayarlayın.
- Çizginin genişliğini ayarlayın.
- Çizginin [Dash Style](https://reference.aspose.com/slides/tr/java/com.aspose.slides/LineDashStyle) özelliğini Aspose.Slides for Java tarafından sunulan stillerden birine ayarlayın.
- Çizginin başlangıç noktasının [Arrow Head Style](https://reference.aspose.com/slides/tr/java/com.aspose.slides/LineArrowheadStyle) ve [Length](https://reference.aspose.com/slides/tr/java/com.aspose.slides/LineArrowheadLength) özelliklerini ayarlayın.
- Çizginin bitiş noktasının [Arrow Head Style](https://reference.aspose.com/slides/tr/java/com.aspose.slides/LineArrowheadStyle) ve [Length](https://reference.aspose.com/slides/tr/java/com.aspose.slides/LineArrowheadLength) özelliklerini ayarlayın.
- Değiştirilmiş sunumu PPTX dosyası olarak yazın.

```java
// PPTX dosyasını temsil eden PresentationEx sınıfını örnekle
Presentation pres = new Presentation();
try {
    // İlk slaytı al
    ISlide sld = pres.getSlides().get_Item(0);

    // Çizgi tipinde bir AutoShape ekle
    IAutoShape shp = sld.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);

    // Çizgiye bazı biçimlendirmeler uygula
    shp.getLineFormat().setStyle(LineStyle.ThickBetweenThin);
    shp.getLineFormat().setWidth(10);

    shp.getLineFormat().setDashStyle(LineDashStyle.DashDot);

    shp.getLineFormat().setBeginArrowheadLength(LineArrowheadLength.Short);
    shp.getLineFormat().setBeginArrowheadStyle(LineArrowheadStyle.Oval);

    shp.getLineFormat().setEndArrowheadLength(LineArrowheadLength.Long);
    shp.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle);

    shp.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(new Color(PresetColor.Maroon));

    // PPTX'i diske yaz
    pres.save("LineShape.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **SSS**

**Normal bir çizgiyi bağlayıcıya dönüştürüp şekillere "yapışmasını" sağlayabilir miyim?**

Hayır. Normal bir çizgi (bir [AutoShape](https://reference.aspose.com/slides/tr/java/com.aspose.slides/autoshape/) türü [Line](https://reference.aspose.com/slides/tr/java/com.aspose.slides/shapetype/)) otomatik olarak bağlayıcı hâline gelmez. Şekillere yapışmasını sağlamak için özel [Connector](https://reference.aspose.com/slides/tr/java/com.aspose.slides/connector/) türünü ve bağlantılar için [ilgili API'leri](/slides/tr/java/connector/) kullanın.

**Bir çizginin özellikleri temadan devralındıysa ve nihai değerleri belirlemek zor ise ne yapmalıyım?**

[ILineFormatEffectiveData](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ilinefillformateffectivedata/) arabirimleri aracılığıyla [etkili özellikleri okuyun](/slides/tr/java/shape-effective-properties/) — bu arabirimler zaten devralma ve tema stillerini hesaba katar.

**Bir çizgiyi düzenlemeye (taşıma, yeniden boyutlandırma) karşı kilitleyebilir miyim?**

Evet. Şekiller, [kilitleme nesnelerini](https://reference.aspose.com/slides/tr/java/com.aspose.slides/autoshape/#getAutoShapeLock--) sağlayarak düzenleme işlemlerine izin vermemenizi sağlar; bununla ilgili ayrıntılar [/slides/tr/java/applying-protection-to-presentation/](/slides/tr/java/applying-protection-to-presentation/) sayfasında bulunabilir.