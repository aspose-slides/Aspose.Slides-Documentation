---
title: "PHP'de Grup Sunum Şekilleri"
linktitle: "Şekil Grubu"
type: docs
weight: 40
url: /tr/php-java/group/
keywords:
- grup şekli
- şekil grubu
- grup ekle
- alternatif metin
- PowerPoint
- sunum
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java kullanarak PowerPoint sunumlarında şekilleri gruplamayı ve gruptan çıkarmayı öğrenin — hızlı, adım adım ücretsiz kodlu rehber."
---
## **Genel Bakış**

Bu makale, Aspose.Slides'te grup şekilleriyle nasıl çalışılacağını açıklar. Bir slayta grup şekli ekleme, içine şekiller yerleştirme ve güncellenmiş sunumu kaydetme adımlarını gösterir. Ayrıca, bir grubun içinde depolanan şekillere erişme ve bunların `AlternativeText` değerlerini okuma yöntemlerini sunar. Ek olarak, iç içe gruplar, z-sırası ve kilitleme seçenekleri gibi ilgili grup‑şekli özelliklerine kısaca değinir.

## **Grup Şekli Ekleme**
Aspose.Slides, slaytlarda grup şekilleriyle çalışmayı destekler. Bu özellik, geliştiricilerin daha zengin sunumlar oluşturmasına yardımcı olur. Aspose.Slides for PHP via Java, grup şekilleri eklemeyi veya bunlara erişmeyi destekler. Eklenen bir grup şekline şekil ekleyerek onu doldurabilir veya grup şeklinin herhangi bir özelliğine erişebilirsiniz. Aspose.Slides for PHP via Java kullanarak bir slayta grup şekli eklemek için:

1. [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/Presentation) sınıfının bir örneğini oluşturun.
1. Slaytın indeksini kullanarak slayt referansını alın.
1. Slayta bir grup şekli ekleyin.
1. Eklenen grup şekline şekilleri ekleyin.
1. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

Aşağıdaki örnek, bir slayta grup şekli ekler.

```php
  # Presentation sınıfını örnekleyin
  $pres = new Presentation();
  try {
    # İlk slaytı alın
    $sld = $pres->getSlides()->get_Item(0);
    # Slaytların şekil koleksiyonuna erişme
    $slideShapes = $sld->getShapes();
    # Slayta bir grup şekli ekleme
    $groupShape = $slideShapes->addGroupShape();
    # Eklenen grup şeklinin içine şekiller ekleme
    $groupShape->getShapes()->addAutoShape(ShapeType::Rectangle, 300, 100, 100, 100);
    $groupShape->getShapes()->addAutoShape(ShapeType::Rectangle, 500, 100, 100, 100);
    $groupShape->getShapes()->addAutoShape(ShapeType::Rectangle, 300, 300, 100, 100);
    $groupShape->getShapes()->addAutoShape(ShapeType::Rectangle, 500, 300, 100, 100);
    # Grup şekli çerçevesi ekleme
    $groupShape->setFrame(new ShapeFrame(100, 300, 500, 40, NullableBool::False, NullableBool::False, 0));
    # PPTX dosyasını diske yazdırma
    $pres->save("GroupShape.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **AltText Özelliğine Erişme**
Bu bölüm, grup şekli ekleme ve slaytlardaki grup şekillerinin AltText özelliğine erişme adımlarını kod örnekleriyle birlikte gösterir. Aspose.Slides for PHP via Java kullanarak bir slayttaki grup şeklinin AltText değerine erişmek için:

1. PPTX dosyasını temsil eden [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/Presentation) sınıfının bir örneğini oluşturun.
1. Slaytın indeksini kullanarak slayt referansını alın.
1. Slaytların şekil koleksiyonuna erişin.
1. Grup şekline erişin.
1. [Alternative Text](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shape/#getAlternativeText) özelliğine erişin.

Aşağıdaki örnek, grup şeklinin alternatif metnine erişir.

```php
  # PPTX dosyasını temsil eden Presentation sınıfını örnekleyin
  $pres = new Presentation("AltText.pptx");
  try {
    # İlk slaytı alın
    $sld = $pres->getSlides()->get_Item(0);
    for($i = 0; $i < java_values($sld->getShapes()->size()) ; $i++) {
      # Slaytların şekil koleksiyonuna erişme
      $shape = $sld->getShapes()->get_Item($i);
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.GroupShape"))) {
        # Grup şekline erişme.
        $grphShape = $shape;
        for($j = 0; $j < java_values($grphShape->getShapes()->size()) ; $j++) {
          $shape2 = $grphShape->getShapes()->get_Item($j);
          # AltText özelliğine erişme
          echo($shape2->getAlternativeText());
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **SSS**

**İç içe gruplama (bir grup içinde başka bir grup) destekleniyor mu?**

Evet. [GroupShape](https://reference.aspose.com/slides/tr/php-java/aspose.slides/groupshape/) sınıfının [getParentGroup](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shape/getparentgroup/) yöntemi, hiyerarşi desteğini doğrudan gösterir (bir grup başka bir grubun çocuğu olabilir).

**Grubun z-sırasını slayttaki diğer nesnelere göre nasıl kontrol ederim?**

Grubun görüntü yığını içindeki konumunu incelemek için [GroupShape](https://reference.aspose.com/slides/tr/php-java/aspose.slides/groupshape/) sınıfının [getZOrderPosition](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shape/getzorderposition/) yöntemini kullanın.

**Taşıma/düzenleme/grup çözmeyi engelleyebilir miyim?**

Evet. Grubun kilitleme bölümü, nesne üzerindeki işlemleri kısıtlamanızı sağlayan [GroupShapeLock](https://reference.aspose.com/slides/tr/php-java/aspose.slides/groupshape/getgroupshapelock/) aracılığıyla sunulur.