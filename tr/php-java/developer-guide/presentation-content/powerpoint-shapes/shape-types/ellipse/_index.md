---
title: PHP'de Sunumlara Elips Ekleyin
linktitle: Elips
type: docs
weight: 30
url: /tr/php-java/ellipse/
keywords:
- elips
- şekil
- elips ekle
- elips oluştur
- elips çiz
- biçimlendirilmiş elips
- PowerPoint
- sunum
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java kullanarak PPT ve PPTX sunumlarında elips şekilleri oluşturmayı, biçimlendirmeyi ve manipüle etmeyi öğrenin — kod örnekleri dahil."
---
## **Genel Bakış**

Bu makale, Aspose.Slides kullanarak PowerPoint slaytlarına elips şekilleri eklemeyi gösterir. Basit bir elips oluşturmayı, biçimlendirilmiş bir elips oluşturmayı ve güncellenen sunumu PPTX dosyası olarak kaydetmeyi kapsar. Ayrıca elips konumu ve boyutu ile çalışma, yığılma sırasını kontrol etme ve animasyon efektleri uygulama gibi ilgili sorulara da değinir.

## **Elips Oluşturma**
Bir slaytın seçili bir slaytına basit bir elips eklemek için aşağıdaki adımları izleyin:

- Bir [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation) sınıfının bir örneğini oluşturun.
- Kaydırmanın indeksini kullanarak bir slayt referansı alın.
- [ShapeCollection](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shapecollection/) nesnesi tarafından sunulan [addAutoShape](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shapecollection/#addAutoShape) yöntemini kullanarak Ellipse tipinde bir AutoShape ekleyin.
- Değiştirilmiş sunumu PPTX dosyası olarak yazın.

Aşağıdaki örnekte, ilk slayta bir elips ekledik

```php
  # PPTX'i temsil eden Presentation sınıfını örnekleyin
  $pres = new Presentation();
  try {
    # İlk slaytı alın
    $sld = $pres->getSlides()->get_Item(0);
    # Ellipse tipinde AutoShape ekleyin
    $sld->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 150, 150, 50);
    # PPTX dosyasını diske yazın
    $pres->save("EllipseShp1.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Biçimlendirilmiş Elips Oluşturma**
Bir slayta daha iyi biçimlendirilmiş bir elips eklemek için aşağıdaki adımları izleyin:

- Bir [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation) sınıfının bir örneğini oluşturun.
- Kaydırmanın indeksini kullanarak bir slayt referansı alın.
- [ShapeCollection](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shapecollection/) nesnesi tarafından sunulan [addAutoShape](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shapecollection/#addAutoShape) yöntemini kullanarak Ellipse tipinde bir AutoShape ekleyin.
- Elipsin Dolgu Türünü Solid olarak ayarlayın.
- `SolidFillColor::setColor` yöntemiyle Elipsin rengini, [Shape](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shape/) nesnesiyle ilişkili [FillFormat](https://reference.aspose.com/slides/tr/php-java/aspose.slides/fillformat/) nesnesi tarafından sunulan şekilde ayarlayın.
- Elipsin çizgi rengini ayarlayın.
- Elipsin çizgi kalınlığını ayarlayın.
- Değiştirilmiş sunumu PPTX dosyası olarak yazın.

Aşağıdaki örnekte, sunumun ilk slaytına biçimlendirilmiş bir elips ekledik.

```php
  # PPTX'i temsil eden Presentation sınıfını örnekleyin
  $pres = new Presentation();
  try {
    # İlk slaytı alın
    $sld = $pres->getSlides()->get_Item(0);
    # Ellipse tipinde AutoShape ekleyin
    $shp = $sld->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 150, 150, 50);
    # Elips şekline bazı biçimlendirmeler uygulayın
    $shp->getFillFormat()->setFillType(FillType::Solid);
    $shp->getFillFormat()->getSolidFillColor()->setColor(new java("java.awt.Color", PresetColor->Chocolate));
    # Ellipse'in çizgiine bazı biçimlendirmeler uygulayın
    $shp->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shp->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $shp->getLineFormat()->setWidth(5);
    # PPTX dosyasını diske yazın
    $pres->save("EllipseShp1.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **SSS**

**Bir elipsin kesin konumunu ve boyutunu slayt birimlerine göre nasıl ayarlarım?**

Koordinatlar ve boyutlar genellikle **nokta** cinsinden belirtilir. Öngörülebilir sonuçlar için hesaplamalarınızı slayt boyutuna göre yapın ve değerleri atamadan önce gerekli milimetre veya inçleri noktalara dönüştürün.

**Bir elipsi diğer nesnelerin üzerine ya da altına nasıl yerleştiririm (yığılma sırasını kontrol etme)?**

Nesnenin çizim sırasını öne getirerek ya da arkaya göndererek ayarlayın. Bu, elipsin diğer nesnelerin üzerine gelmesini ya da altındakileri ortaya çıkarmasını sağlar.

**Bir elipsin görünümünü veya vurgusunu nasıl canlandırırım?**

Şekle giriş, vurgu veya çıkış efektleri [Apply](/slides/tr/php-java/shape-animation/) uygulayın ve tetikleyicileri ve zamanlamayı yapılandırarak animasyonun ne zaman ve nasıl oynatılacağını yönetin.