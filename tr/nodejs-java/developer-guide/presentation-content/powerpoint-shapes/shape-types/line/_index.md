---
title: JavaScript ile Sunumlara Çizgi Şekilleri Ekleme
linktitle: Çizgi
type: docs
weight: 50
url: /tr/nodejs-java/line/
keywords:
- çizgi
- çizgi oluştur
- çizgi ekle
- düz çizgi
- çizgi yapılandır
- çizgi özelleştir
- kesik stil
- ok ucu
- PowerPoint
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "JavaScript ve Aspose.Slides for Node.js kullanarak PowerPoint sunumlarında çizgi biçimlendirmeyi nasıl manipüle edeceğinizi öğrenin. Özellikleri, yöntemleri ve örnekleri keşfedin."
---
## **Genel Bakış**

Aspose.Slides, PowerPoint slaytlarına programlı olarak çizgi şekilleri eklemenizi sağlar. Bu makale, basit bir çizgi oluşturmayı ve çizgiyi bir ok gibi görünmesi için nasıl özelleştirileceğini gösterir.

Bir slayta çizgi şekli eklemeyi, görsel görünümünü ayarlamayı ve güncellenmiş sunumu kaydetmeyi öğreneceksiniz. Örnekler, stil, genişlik, kesik desen, ok ucu seçenekleri ve dolgu rengi gibi pratik çizgi biçimlendirme ayarlarına odaklanır.

## **Düz Çizgi Oluşturma**

Bir sunumun seçili slaytına basit bir düz çizgi eklemek için aşağıdaki adımları izleyin:

- [Presentation] sınıfının bir örneğini oluşturun.
- Bir slaydın referansını, indeksini kullanarak alın.
- [ShapeCollection] nesnesi tarafından sunulan [addAutoShape] metodunu kullanarak Çizgi türünde bir AutoShape ekleyin.
- Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

Aşağıda verilen örnekte, sunumun ilk slaytına bir çizgi ekledik.

```javascript
// PPTX dosyasını temsil eden PresentationEx sınıfını örnekleyin
var pres = new aspose.slides.Presentation();
try {
    // İlk slaytı al
    var sld = pres.getSlides().get_Item(0);
    // Çizgi türünde bir AutoShape ekle
    sld.getShapes().addAutoShape(aspose.slides.ShapeType.Line, 50, 150, 300, 0);
    // PPTX dosyasını diske kaydet
    pres.save("LineShape.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Ok Şeklinde Çizgi Oluşturma**

Aspose.Slides for Node.js via Java ayrıca geliştiricilerin çizginin bazı özelliklerini yapılandırarak daha çekici görünmesini sağlar. Çizgiyi bir ok gibi göstermek için birkaç özelliği yapılandıralım. Bunu yapmak için aşağıdaki adımları izleyin:

- [Presentation] sınıfının bir örneğini oluşturun.
- Bir slaydın referansını, indeksini kullanarak alın.
- [ShapeCollection] nesnesi tarafından sunulan [addAutoShape] metodunu kullanarak Çizgi türünde bir AutoShape ekleyin.
- [Çizgi Stili] öğesini, Aspose.Slides for Node.js via Java tarafından sunulan stillerden birine ayarlayın.
- Çizginin Genişliğini ayarlayın.
- [Kesik Çizgi Stili] öğesini, Aspose.Slides for Node.js via Java tarafından sunulan stillerden birine ayarlayın.
- Çizginin başlangıç noktasının [Ok Ucu Stili] ve [Uzunluk] değerlerini ayarlayın.
- Çizginin bitiş noktasının [Ok Ucu Stili] ve [Uzunluk] değerlerini ayarlayın.
- Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

```javascript
// PPTX dosyasını temsil eden PresentationEx sınıfını örnekleyin
var pres = new aspose.slides.Presentation();
try {
    // İlk slaytı al
    var sld = pres.getSlides().get_Item(0);
    // Çizgi türünde bir AutoShape ekle
    var shp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Line, 50, 150, 300, 0);
    // Çizgi üzerinde bazı biçimlendirmeler uygula
    shp.getLineFormat().setStyle(aspose.slides.LineStyle.ThickBetweenThin);
    shp.getLineFormat().setWidth(10);
    shp.getLineFormat().setDashStyle(aspose.slides.LineDashStyle.DashDot);
    shp.getLineFormat().setBeginArrowheadLength(aspose.slides.LineArrowheadLength.Short);
    shp.getLineFormat().setBeginArrowheadStyle(aspose.slides.LineArrowheadStyle.Oval);
    shp.getLineFormat().setEndArrowheadLength(aspose.slides.LineArrowheadLength.Long);
    shp.getLineFormat().setEndArrowheadStyle(aspose.slides.LineArrowheadStyle.Triangle);
    shp.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", aspose.slides.PresetColor.Maroon));
    // PPTX dosyasını diske kaydet
    pres.save("LineShape.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **SSS**

**Düzenli bir çizgiyi şekillere “yapışacak” şekilde bir bağlayıcıya dönüştürebilir miyim?**

Hayır. Düzenli bir çizgi (bir [AutoShape] türü [Line]) otomatik olarak bağlayıcı olmaz. Şekillere yapışmasını sağlamak için özel [Connector] türünü ve bağlantılar için [ilgili API'ler](/slides/tr/nodejs-java/connector/) kullanın.

**Bir çizginin özellikleri temadan devralındıysa ve nihai değerleri belirlemek zor oluyorsa ne yapmalıyım?**

[Etkili özellikleri okuyun](/slides/tr/nodejs-java/shape-effective-properties/) `ILineFormatEffectiveData`/`ILineFillFormatEffectiveData` sınıfları aracılığıyla — bunlar zaten kalıtımı ve tema stillerini hesaba katar.

**Bir çizgiyi düzenlemeye (taşıma, yeniden boyutlandırma) karşı kilitleyebilir miyim?**

Evet. Şekiller, düzenleme işlemlerine izin vermemenizi sağlayan [kilit nesneleri] (https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/autoshape/getautoshapelock/) sağlar.