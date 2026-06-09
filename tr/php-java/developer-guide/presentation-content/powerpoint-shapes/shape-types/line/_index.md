---
title: PHP'de Sunumlara Çizgi Şekilleri Ekleyin
linktitle: Çizgi
type: docs
weight: 50
url: /tr/php-java/Line/
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
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java ile PowerPoint sunumlarında çizgi biçimlendirmeyi nasıl manipüle edeceğinizi öğrenin. Özellikleri, yöntemleri ve örnekleri keşfedin."
---
## **Genel Bakış**

Aspose.Slides, PowerPoint slaytlarına programlı olarak çizgi şekilleri eklemenizi sağlar. Bu makale, basit bir çizgi oluşturmayı ve bir çizgiyi ok gibi görünmesi için nasıl özelleştireceğinizi gösterir.

Bir slayta çizgi şekli eklemeyi, görünümünü ayarlamayı ve güncellenen sunumu kaydetmeyi öğreneceksiniz. Örnekler, stil, genişlik, kesikli desen, ok ucu seçenekleri ve dolgu rengi gibi pratik çizgi biçimlendirme ayarlarına odaklanır.

## **Düz Bir Çizgi Oluşturma**

Sunumda seçili bir slayta basit bir düz çizgi eklemek için aşağıdaki adımları izleyin:

- Bir [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/Presentation) sınıfının bir örneğini oluşturun.
- Bir slaydın referansını, indeksini kullanarak alın.
- [ShapeCollection](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shapecollection/) nesnesinin sunduğu [addAutoShape](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shapecollection/#addAutoShape) metodunu kullanarak Line tipinde bir AutoShape ekleyin.
- Değiştirilmiş sunumu bir PPTX dosyası olarak yazın.

Aşağıda verilen örnekte, sunumun ilk slaydına bir çizgi ekledik.

```php
  # PPTX dosyasını temsil eden PresentationEx sınıfını örnekleyin
  $pres = new Presentation();
  try {
    # İlk slaytı al
    $sld = $pres->getSlides()->get_Item(0);
    # Tipi çizgi olan bir AutoShape ekle
    $sld->getShapes()->addAutoShape(ShapeType::Line, 50, 150, 300, 0);
    # PPTX'i diske kaydet
    $pres->save("LineShape.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Ok Şeklinde Çizgi Oluşturma**

Aspose.Slides for PHP via Java, geliştiricilerin çizginin bazı özelliklerini yapılandırarak daha çekici görünmesini de sağlar. Çizgiyi bir ok gibi göstermek için birkaç özelliği yapılandıralım. Bunu yapmak için aşağıdaki adımları izleyin:

- Bir [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/Presentation) sınıfının bir örneğini oluşturun.
- Bir slaydın referansını, indeksini kullanarak alın.
- [ShapeCollection](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shapecollection/) nesnesinin sunduğu [addAutoShape](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shapecollection/#addAutoShape) metodunu kullanarak Line tipinde bir AutoShape ekleyin.
- [Line Style](https://reference.aspose.com/slides/tr/php-java/aspose.slides/LineStyle) özelliğini Aspose.Slides for PHP via Java tarafından sunulan stillerden biri olarak ayarlayın.
- Çizginin Genişliğini ayarlayın.
- Çizginin [Dash Style](https://reference.aspose.com/slides/tr/php-java/aspose.slides/LineDashStyle) özelliğini Aspose.Slides for PHP via Java tarafından sunulan stillerden biri olarak ayarlayın.
- Çizginin başlangıç noktasının [Arrow Head Style](https://reference.aspose.com/slides/tr/php-java/aspose.slides/LineArrowheadStyle) ve [Length](https://reference.aspose.com/slides/tr/php-java/aspose.slides/LineArrowheadLength) değerlerini ayarlayın.
- Çizginin bitiş noktasının [Arrow Head Style](https://reference.aspose.com/slides/tr/php-java/aspose.slides/LineArrowheadStyle) ve [Length](https://reference.aspose.com/slides/tr/php-java/aspose.slides/LineArrowheadLength) değerlerini ayarlayın.
- Değiştirilmiş sunumu bir PPTX dosyası olarak yazın.

```php
  # PPTX dosyasını temsil eden PresentationEx sınıfını örnekleyin
  $pres = new Presentation();
  try {
    # İlk slaytı al
    $sld = $pres->getSlides()->get_Item(0);
    # Tipi çizgi olan bir AutoShape ekle
    $shp = $sld->getShapes()->addAutoShape(ShapeType::Line, 50, 150, 300, 0);
    # Çizgiye bazı formatlamalar uygulayın
    $shp->getLineFormat()->setStyle(LineStyle->ThickBetweenThin);
    $shp->getLineFormat()->setWidth(10);
    $shp->getLineFormat()->setDashStyle(LineDashStyle->DashDot);
    $shp->getLineFormat()->setBeginArrowheadLength(LineArrowheadLength->Short);
    $shp->getLineFormat()->setBeginArrowheadStyle(LineArrowheadStyle->Oval);
    $shp->getLineFormat()->setEndArrowheadLength(LineArrowheadLength->Long);
    $shp->getLineFormat()->setEndArrowheadStyle(LineArrowheadStyle->Triangle);
    $shp->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shp->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(new java("java.awt.Color", PresetColor->Maroon));
    # PPTX'i diske kaydet
    $pres->save("LineShape.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **SSS**

**Normal bir çizgiyi bağlayıcıya dönüştürerek şekillere "yapışmasını" sağlayabilir miyim?**

Hayır. Normal bir çizgi (türü [Line](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shapetype/) olan bir [AutoShape](https://reference.aspose.com/slides/tr/php-java/aspose.slides/autoshape/)) otomatik olarak bağlayıcı olmaz. Şekillere yapışmasını sağlamak için özel [Connector](https://reference.aspose.com/slides/tr/php-java/aspose.slides/connector/) tipini ve bağlamalar için [corresponding APIs](/slides/tr/php-java/connector/) kullanın.

**Bir çizginin özellikleri temadan miras alındığında ve nihai değerleri belirlemek zor olduğunda ne yapmalıyım?**

`LineFormatEffectiveData`/`LineFillFormatEffectiveData` aracılığıyla [etkin özellikleri okuyun](/slides/tr/php-java/shape-effective-properties/) — bunlar zaten miras alma ve tema stillerini göz önünde bulundurur.

**Bir çizgiyi düzenlemeye (taşımaya, yeniden boyutlandırmaya) karşı kilitleyebilir miyim?**

Evet. Şekiller, düzenleme işlemlerini engellemenizi sağlayan [lock objects](https://reference.aspose.com/slides/tr/php-java/aspose.slides/autoshape/getautoshapelock/) sunar.