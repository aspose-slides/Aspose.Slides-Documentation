---
title: Android'de Sunumlara Çizgi Şekilleri Ekleyin
linktitle: Çizgi
type: docs
weight: 50
url: /tr/androidjava/line/
keywords:
- çizgi
- çizgi oluştur
- çizgi ekle
- düz çizgi
- çizgiyi yapılandır
- çizgiyi özelleştir
- çizgi stili
- ok ucu
- PowerPoint
- sunum
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android ile PowerPoint sunumlarında çizgi biçimlendirmesini nasıl manipüle edeceğinizi öğrenin. Özellikleri, yöntemleri ve Java örneklerini keşfedin."
---
## **Genel Bakış**

Aspose.Slides, PowerPoint slaytlarına programlı olarak çizgi şekilleri eklemenizi sağlar. Bu makale, basit bir çizgi oluşturmayı ve bir çizgiyi ok gibi görünmesi için nasıl özelleştireceğinizi gösterir.

Bir slayta çizgi şekli eklemeyi, görsel görünümünü ayarlamayı ve güncellenmiş sunumu kaydetmeyi öğrenacaksınız. Örnekler, stil, genişlik, tire deseni, ok ucu seçenekleri ve dolgu rengi gibi pratik çizgi biçimlendirme ayarlarına odaklanır.

## **Düz Çizgi Oluşturma**

Sunumun seçili bir slaytına basit bir düz çizgi eklemek için lütfen aşağıdaki adımları izleyin:

- [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturun.
- Bir slaydın referansını, indeksini kullanarak alın.
- [IShapeCollection](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IShapeCollection) nesnesi tarafından sunulan [addAutoShape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) metodunu kullanarak Çizgi tipinde bir AutoShape ekleyin.
- Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

Aşağıda verilen örnekte, sunumun ilk slaydına bir çizgi ekledik.

```java
// PPTX dosyasını temsil eden PresentationEx sınıfını örnekleyin
Presentation pres = new Presentation();
try {
    // İlk slaytı alın
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Tipi çizgi olan bir AutoShape ekleyin
    sld.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);
    
    // PPTX dosyasını diske kaydedin
    pres.save("LineShape.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ok Şeklinde Çizgi Oluşturma**

Aspose.Slides for Android via Java, geliştiricilerin çizginin bazı özelliklerini daha çekici hâle getirecek şekilde yapılandırmasına da izin verir. Bir çizgiyi ok gibi görünmesi için birkaç özelliği yapılandıralım. Bunu yapmak için lütfen aşağıdaki adımları izleyin:

- [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturun.
- Bir slaydın referansını, indeksini kullanarak alın.
- [IShapeCollection](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IShapeCollection) nesnesi tarafından sunulan [addAutoShape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) metodunu kullanarak Çizgi tipinde bir AutoShape ekleyin.
- Aspose.Slides for Android via Java tarafından sunulan stillerden birine [Line Style](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/LineStyle) ayarlayın.
- Çizginin genişliğini ayarlayın.
- Aspose.Slides for Android via Java tarafından sunulan stillerden birine [Dash Style](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/LineDashStyle) ayarlayın.
- Çizginin başlangıç noktasının [Arrow Head Style](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/LineArrowheadStyle) ve [Length](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/LineArrowheadLength) ayarlarını yapın.
- Çizginin bitiş noktasının [Arrow Head Style](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/LineArrowheadStyle) ve [Length](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/LineArrowheadLength) ayarlarını yapın.
- Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

```java
// PPTX dosyasını temsil eden PresentationEx sınıfını örnekleyin
Presentation pres = new Presentation();
try {
    // İlk slaytı alın
    ISlide sld = pres.getSlides().get_Item(0);

    // Tipi çizgi olan bir AutoShape ekleyin
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

**Düzenli bir çizgiyi bağlayıcıya dönüştürüp şekillere "yapışmasını" sağlayabilir miyim?**

Hayır. Düzenli bir çizgi (tipi [Line] olan bir [AutoShape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/autoshape/)) otomatik olarak bağlayıcı haline gelmez. Şekillere yapışmasını sağlamak için özel [Connector](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/connector/) tipini ve bağlantılar için [corresponding APIs](/slides/tr/androidjava/connector/) kullanın.

**Bir çizginin özellikleri temadan devralındığında ve nihai değerleri belirlemek zor olduğunda ne yapmalıyım?**

[Read the effective properties](/slides/tr/androidjava/shape-effective-properties/) üzerinden [ILineFormatEffectiveData](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ilinefillformateffectivedata/) arayüzlerini okuyun—bunlar zaten kalıtım ve tema stillerini hesaba katar.

**Bir çizgiyi düzenlemeye (taşımaya, yeniden boyutlandırmaya) karşı kilitleyebilir miyim?**

Evet. Şekiller, düzenleme işlemlerine izin vermemenizi sağlayan [lock objects](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/autoshape/#getAutoShapeLock--) sunar.