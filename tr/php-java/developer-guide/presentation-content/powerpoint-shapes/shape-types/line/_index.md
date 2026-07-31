---
title: PHP'de Sunumlara Çizgi Şekilleri Ekle
linktitle: Çizgi
type: docs
weight: 50
url: /tr/php-java/line/
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
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java ile PowerPoint sunumlarında çizgi biçimlendirmesini nasıl manipüle edeceğinizi öğrenin. Özellikleri, yöntemleri ve örnekleri keşfedin."
---
## **Genel Bakış**

Aspose.Slides, PowerPoint slaytlarına programlı olarak çizgi şekilleri eklemenizi sağlar. Bu makale, basit bir çizgi oluşturmayı ve bir çizgiyi ok gibi görünmesi için nasıl özelleştireceğinizi gösterir.

Bir çizgi şekli eklemeyi, görsel görünümünü ayarlamayı ve güncellenmiş sunumu kaydetmeyi öğreneceksiniz. Örnekler, stil, genişlik, kesikli desen, ok ucu seçenekleri ve dolgu rengi gibi pratik çizgi biçimlendirme ayarlarına odaklanır.

## **Düz Çizgi Oluştur**

Sunumun seçili bir slaytına basit bir düz çizgi eklemek için aşağıdaki adımları izleyin:

- Bir [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/Presentation) sınıfının bir örneğini oluşturun.
- Slaytın indeksini kullanarak slayt referansını alın.
- [ShapeCollection](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shapecollection/) nesnesi tarafından sunulan [addAutoShape](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shapecollection/#addAutoShape) yöntemini kullanarak Line türünde bir AutoShape ekleyin.
- Değiştirilmiş sunumu PPTX dosyası olarak yazın.

Aşağıda verilen örnekte, sunumun ilk slaytına bir çizgi ekledik.

```php
  # PPTX dosyasını temsil eden PresentationEx sınıfını örnekleyin
  $pres = new Presentation();
  try {
    # İlk slaytı alın
    $sld = $pres->getSlides()->get_Item(0);
    # Çizgi türünde bir AutoShape ekleyin
    $sld->getShapes()->addAutoShape(ShapeType::Line, 50, 150, 300, 0);
    # PPTX'yi diske kaydedin
    $pres->save("LineShape.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Ok Şeklinde Çizgi Oluştur**

Aspose.Slides for PHP via Java, geliştiricilerin çizgiyi daha çekici hâle getirmek için bazı özelliklerini yapılandırmasına da izin verir. Çizgiyi ok gibi görünmesi için birkaç özelliği yapılandıralım. Bunu yapmak için aşağıdaki adımları izleyin:

- Bir [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/Presentation) sınıfının bir örneğini oluşturun.
- Slaytın indeksini kullanarak slayt referansını alın.
- [ShapeCollection](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shapecollection/) nesnesi tarafından sunulan [addAutoShape](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shapecollection/#addAutoShape) yöntemini kullanarak Line türünde bir AutoShape ekleyin.
- [Line Style](https://reference.aspose.com/slides/tr/php-java/aspose.slides/LineStyle) öğesini Aspose.Slides for PHP via Java tarafından sunulan stillerden birine ayarlayın.
- Çizginin genişliğini ayarlayın.
- [Dash Style](https://reference.aspose.com/slides/tr/php-java/aspose.slides/LineDashStyle) öğesini Aspose.Slides for PHP via Java tarafından sunulan stillerden birine ayarlayın.
- Çizginin başlangıç noktasının [Arrow Head Style](https://reference.aspose.com/slides/tr/php-java/aspose.slides/LineArrowheadStyle) ve [Length](https://reference.aspose.com/slides/tr/php-java/aspose.slides/LineArrowheadLength) değerlerini ayarlayın.
- Çizginin bitiş noktasının [Arrow Head Style](https://reference.aspose.com/slides/tr/php-java/aspose.slides/LineArrowheadStyle) ve [Length](https://reference.aspose.com/slides/tr/php-java/aspose.slides/LineArrowheadLength) değerlerini ayarlayın.
- Değiştirilmiş sunumu PPTX dosyası olarak yazın.

```php
  # PPTX dosyasını temsil eden PresentationEx sınıfını örnekleyin
  $pres = new Presentation();
  try {
    # İlk slaytı alın
    $sld = $pres->getSlides()->get_Item(0);
    # Çizgi türünde bir AutoShape ekleyin
    $shp = $sld->getShapes()->addAutoShape(ShapeType::Line, 50, 150, 300, 0);
    # Çizgiye bazı biçimlendirmeler uygulayın
    $shp->getLineFormat()->setStyle(LineStyle->ThickBetweenThin);
    $shp->getLineFormat()->setWidth(10);
    $shp->getLineFormat()->setDashStyle(LineDashStyle->DashDot);
    $shp->getLineFormat()->setBeginArrowheadLength(LineArrowheadLength->Short);
    $shp->getLineFormat()->setBeginArrowheadStyle(LineArrowheadStyle->Oval);
    $shp->getLineFormat()->setEndArrowheadLength(LineArrowheadLength->Long);
    $shp->getLineFormat()->setEndArrowheadStyle(LineArrowheadStyle->Triangle);
    $shp->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shp->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(new java("java.awt.Color", PresetColor->Maroon));
    # PPTX'yi diske kaydedin
    $pres->save("LineShape.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **SSS**

**Düzenli bir çizgiyi bağlayıcıya dönüştürüp şekillere “yapışmasını” sağlayabilir miyim?**

Hayır. Düzenli bir çizgi (bir [AutoShape](https://reference.aspose.com/slides/tr/php-java/aspose.slides/autoshape/) türü olarak [Line](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shapetype/)) otomatik olarak bağlayıcı hâline gelmez. Şekillere yapışmasını sağlamak için özel [Connector](https://reference.aspose.com/slides/tr/php-java/aspose.slides/connector/) türünü ve bağlantılar için [ilgili API'ler](/slides/tr/php-java/connector/) kullanın.

**Bir çizginin özellikleri temadan devralındıysa ve son değerleri belirlemek zor ise ne yapmalıyım?**

[Effective properties](/slides/tr/php-java/shape-effective-properties/) (Etkili özellikleri) `LineFormatEffectiveData`/`LineFillFormatEffectiveData` aracılığıyla okuyun—bunlar zaten devralma ve tema stillerini hesaba katar.

**Bir çizgiyi düzenlemeye (taşıma, yeniden boyutlandırma) karşı kilitleyebilir miyim?**

Evet. Şekiller, düzenleme işlemlerine izin vermemenizi sağlayan [lock objects](https://reference.aspose.com/slides/tr/php-java/aspose.slides/autoshape/getautoshapelock/) (kilit nesneleri) sunar.