---
title: PHP'de Sunumları Verimli Şekilde Birleştirin
linktitle: Sunumları Birleştir
type: docs
weight: 40
url: /tr/php-java/merge-presentation/
keywords:
- PowerPoint birleştir
- sunumları birleştir
- slaytları birleştir
- PPT birleştir
- PPTX birleştir
- ODP birleştir
- PowerPoint birleştir
- sunumları birleştir
- slaytları birleştir
- PPT birleştir
- PPTX birleştir
- ODP birleştir
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java ile PowerPoint (PPT, PPTX) ve OpenDocument (ODP) sunumlarını sorunsuz bir şekilde birleştirerek iş akışınızı hızlandırın."
---
## **Genel Bakış**

Aspose.Slides, bir sunumdan diğerine slaytları klonlayarak sunumları birleştirmenizi sağlar. Bu makale, tüm sunumları veya seçili slaytları nasıl birleştireceğinizi, birleştirme sırasında bir slayt master'ı veya belirli bir düzeni nasıl kullanacağınızı, farklı slayt boyutlarına sahip sunumları nasıl ele alacağınızı ve birleştirilen slaytları bir sunum bölümüne nasıl ekleyeceğinizi açıklar. Ayrıca birleştirilen içeriğe ilişkin pratik notları kapsar; konuşmacı notları, yorumlar, şifre korumalı kaynak dosyalar ve iş parçacığı kullanımı gibi.

## **Sunum Birleştirme**

Bir sunumu diğerine birleştirdiğinizde, aslında slaytlarını tek bir sunumda birleştirerek tek bir dosya elde etmiş olursunuz.

{{% alert title="Info" color="info" %}}

Çoğu sunum programı (PowerPoint veya OpenOffice), kullanıcıların sunumları bu şekilde birleştirmesine izin veren işlevlere sahip değildir. 

[**Aspose.Slides for PHP via Java**](https://products.aspose.com/slides/tr/php-java/), ancak, farklı şekillerde sunumları birleştirmenize izin verir. Sunumları, tüm şekilleri, stilleri, metinleri, biçimlendirmeleri, yorumları, animasyonları vb. ile birlikte, kalite ya da veri kaybı konusunda endişelenmeden birleştirebilirsiniz.

**Ayrıca bakınız**

[Slaytları Klonla](/slides/tr/php-java/clone-slides/).

{{% /alert %}}

### **Ne Birleştirilebilir**

Aspose.Slides ile şunları birleştirebilirsiniz  

* **tüm sunumlar**. Sunumlardan tüm slaytlar tek bir sunumda birleştirilir  
* **belirli slaytlar**. Seçili slaytlar tek bir sunumda birleştirilir  
* **bir formatta (PPT'den PPT'ye, PPTX'den PPTX'e vb.) ve farklı formatlarda (PPT'den PPTX'e, PPTX'den ODP'ye vb.)** sunumları birbirine.

{{% alert title="Note" color="warning" %}} 

Sunumların yanı sıra, Aspose.Slides diğer dosyaları da birleştirmenize olanak tanır:

* [Görseller](https://products.aspose.com/slides/tr/php-java/merger/image-to-image/), örneğin [JPG to JPG](https://products.aspose.com/slides/tr/php-java/merger/jpg-to-jpg/) veya [PNG to PNG](https://products.aspose.com/slides/tr/php-java/merger/png-to-png/)
* **Belgeler**, örneğin [PDF to PDF](https://products.aspose.com/slides/tr/php-java/merger/pdf-to-pdf/) veya [HTML to HTML](https://products.aspose.com/slides/tr/php-java/merger/html-to-html/)
* Ve iki farklı dosyayı, örneğin [image to PDF](https://products.aspose.com/slides/tr/php-java/merger/image-to-pdf/) veya [JPG to PDF](https://products.aspose.com/slides/tr/php-java/merger/jpg-to-pdf/) veya [TIFF to PDF](https://products.aspose.com/slides/tr/php-java/merger/tiff-to-pdf/).

{{% /alert %}}

### **Birleştirme Seçenekleri**

Aşağıdakileri belirleyen seçenekler uygulayabilirsiniz:

* çıktı sunumundaki her slayt benzersiz bir stil korur
* çıktı sunumundaki tüm slaytlar için belirli bir stil kullanılır.  

Sunumları birleştirmek için Aspose.Slides, [SlideCollection](https://reference.aspose.com/slides/tr/php-java/aspose.slides/slidecollection/) sınıfından gelen [addClone](https://reference.aspose.com/slides/tr/php-java/aspose.slides/slidecollection/addclone/) yöntemlerini sağlar. `addClone` yöntemlerinin çeşitli uygulamaları, sunum birleştirme işlemi parametrelerini tanımlar. Her Presentation nesnesinin bir [slide](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/getslides/) koleksiyonu vardır; böylece slaytları birleştirmek istediğiniz sunumdan bir `addClone` yöntemi çağırabilirsiniz.

`addClone` yöntemi, kaynak slaytın bir klonu olan bir `Slide` nesnesi döndürür. Çıktı sunumundaki slaytlar, kaynak slaytlardan alınan bir kopyadır. Bu nedenle, sonuç slaytları (örneğin stiller, biçimlendirme seçenekleri veya düzenler uygulamak) üzerinde değişiklik yapabilir, kaynak sunumların etkilenmesi konusunda endişelenmenize gerek kalmaz. 

## **Sunumları Birleştir** 

Aspose.Slides, slaytların düzenlerini ve stillerini koruyarak (varsayılan parametreler) slaytları birleştirmenizi sağlayan [addClone(Slide)](https://reference.aspose.com/slides/tr/php-java/aspose.slides/slidecollection/addclone/) metodunu sunar.

Bu PHP kodu, sunumları nasıl birleştireceğinizi gösterir:

```php
  $pres1 = new Presentation("pres1.pptx");
  try {
    $pres2 = new Presentation("pres2.pptx");
    try {
      foreach($pres2->getSlides() as $slide) {
        $pres1->getSlides()->addClone($slide);
      }
    } finally {
      if (!java_is_null($pres2)) {
        $pres2->dispose();
      }
    }
    $pres1->save("combined.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres1)) {
      $pres1->dispose();
    }
  }
```

## **Sunumları Slayt Master'ı ile Birleştir** 

Aspose.Slides, slayt master sunum şablonu uygularken slaytları birleştirmenizi sağlayan [addClone(Slide, MasterSlide, boolean)](https://reference.aspose.com/slides/tr/php-java/aspose.slides/slidecollection/addclone/) metodunu sunar. Bu sayede, gerektiğinde çıktı sunumundaki slaytların stilini değiştirebilirsiniz.

Bu kod, açıklanan işlemi göstermektedir:

```php
  $pres1 = new Presentation("pres1.pptx");
  try {
    $pres2 = new Presentation("pres2.pptx");
    try {
      foreach($pres2->getSlides() as $slide) {
        $pres1->getSlides()->addClone($slide, $pres2->getMasters()->get_Item(0), true);
      }
    } finally {
      if (!java_is_null($pres2)) {
        $pres2->dispose();
      }
    }
    $pres1->save("combined.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres1)) {
      $pres1->dispose();
    }
  }
```

{{% alert title="Note" color="warning" %}} 

Slayt master için slayt düzeni otomatik olarak belirlenir. Uygun bir düzen belirlenemediğinde, `addClone` yönteminin `allowCloneMissingLayout` boolean parametresi true olarak ayarlanmışsa, kaynak slaytın düzeni kullanılır. Aksi takdirde, [PptxEditException](https://reference.aspose.com/slides/tr/php-java/aspose.slides/PptxEditException) istisnası fırlatılır.

{{% /alert %}}

Çıktı sunumundaki slaytların farklı bir slayt düzenine sahip olmasını istiyorsanız, birleştirirken [addClone(Slide, LayoutSlide)](https://reference.aspose.com/slides/tr/php-java/aspose.slides/slidecollection/addclone/) yöntemini kullanın.

## **Sunumlardan Belirli Slaytları Birleştir** 

Birden çok sunumdan belirli slaytları birleştirmek, özelleştirilmiş slayt desteleri oluşturmak için kullanışlıdır. Aspose.Slides for PHP via Java, yalnızca ihtiyacınız olan slaytları seçip içe aktarmanıza izin verir. API, orijinal slaytların biçimlendirmesini, düzenini ve tasarımını korur.

Aşağıdaki PHP kodu yeni bir sunum oluşturur, iki diğer sunumdan başlık slaytları ekler ve sonucu bir dosyaya kaydeder:

```php
function getTitleSlide(Presentation $presentation) {
    for ($i = 0; $i < java_values($presentation->getSlides()->size()); $i++) {
        $slide = $presentation->getSlides()->get_Item($i);
        if (java_values($slide->getLayoutSlide()->getLayoutType()) === SlideLayoutType::Title) {
            return $slide;
        }
    }
    return null;
}
```
```php
$presentation = new Presentation();
$presentation1 = new Presentation($folderPath . "presentation1.pptx");
$presentation2 = new Presentation($folderPath . "presentation2.pptx");
try {
    $presentation->getSlides()->removeAt(0);
    
    $slide1 = getTitleSlide($presentation1);

    if ($slide1 != null)
        $presentation->getSlides()->addClone($slide1);

    $slide2 = getTitleSlide($presentation2);

    if ($slide2 != null)
        $presentation->getSlides()->addClone($slide2);

    $presentation->save($folderPath . "combined.pptx", SaveFormat::Pptx);
} finally {
    $presentation2->dispose();
    $presentation1->dispose();
    $presentation->dispose();
}
```

## **Sunumları Slayt Düzeni ile Birleştir** 

Bu PHP kodu, slaytları birleştirirken tercih ettiğiniz slayt düzenini uygulayarak tek bir çıktı sunumu elde etmenizi gösterir:

```php
  $pres1 = new Presentation("pres1.pptx");
  try {
    $pres2 = new Presentation("pres2.pptx");
    try {
      foreach($pres2->getSlides() as $slide) {
        $pres1->getSlides()->addClone($slide, $pres2->getLayoutSlides()->get_Item(0));
      }
    } finally {
      if (!java_is_null($pres2)) {
        $pres2->dispose();
      }
    }
    $pres1->save("combined.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres1)) {
      $pres1->dispose();
    }
  }
```

## **Farklı Slayt Boyutlu Sunumları Birleştir** 

{{% alert title="Note" color="warning" %}} 

Farklı slayt boyutlarına sahip sunumları birleştiremezsiniz. 

{{% /alert %}}

Farklı slayt boyutlarına sahip 2 sunumu birleştirmek için, sunumlardan birinin boyutunu diğerine eşit olacak şekilde yeniden boyutlandırmanız gerekir.

Bu örnek kod, açıklanan işlemi göstermektedir:

```php
  $pres1 = new Presentation("pres1.pptx");
  try {
    $pres2 = new Presentation("pres2.pptx");
    try {
      $pres2->getSlideSize()->setSize($pres1->getSlideSize()->getSize()->getWidth(), $pres1->getSlideSize()->getSize()->getHeight(), SlideSizeScaleType::EnsureFit);
      foreach($pres2->getSlides() as $slide) {
        $pres1->getSlides()->addClone($slide);
      }
    } finally {
      if (!java_is_null($pres2)) {
        $pres2->dispose();
      }
    }
    $pres1->save("combined.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres1)) {
      $pres1->dispose();
    }
  }
```

## **Slaytları Sunum Bölümüne Birleştir** 

Bu PHP kodu, belirli bir slaytı bir sunum bölümüne nasıl birleştireceğinizi gösterir:

```php
  $pres1 = new Presentation("pres1.pptx");
  try {
    $pres2 = new Presentation("pres2.pptx");
    try {
      foreach($pres2->getSlides() as $slide) {
        $pres1->getSlides()->addClone($slide, $pres1->getSections()->get_Item(0));
      }
    } finally {
      if (!java_is_null($pres2)) {
        $pres2->dispose();
      }
    }
    $pres1->save("combined.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres1)) {
      $pres1->dispose();
    }
  }
```

Slayt, bölümün sonuna eklenir. 

## **Ayrıca Bakınız**


Aspose, bir [ÜCRETSİZ Online Kolaj Oluşturucu](https://products.aspose.app/slides/tr/collage) sunar. Bu çevrimiçi hizmeti kullanarak [JPG to JPG](https://products.aspose.app/slides/tr/collage/jpg) veya PNG to PNG görüntülerini birleştirebilir, [fotoğraf ızgaraları](https://products.aspose.app/slides/tr/collage/photo-grid) oluşturabilir ve daha fazlasını yapabilirsiniz.

[Aspose ÜCRETSİZ Online Birleştirici](https://products.aspose.app/slides/tr/merger)'yi inceleyin. Aynı formatta (ör. PPT'den PPT'ye, PPTX'ten PPTX'e) veya farklı formatlarda (ör. PPT'den PPTX'e, PPTX'ten ODP'ye) PowerPoint sunumlarını birleştirmenize olanak tanır.

[![Aspose FREE Online Merger](slides-merger.png)](https://products.aspose.app/slides/tr/merger)

## **SSS**

**Sunumları birleştirirken slayt sayısı konusunda herhangi bir sınırlama var mı?**

Sıkı sınırlamalar yoktur. Aspose.Slides büyük dosyaları işleyebilir, ancak performans dosya boyutuna ve sistem kaynaklarına bağlıdır. Çok büyük sunumlar için 64‑bit JVM kullanmanız ve yeterli heap belleği ayırmanız önerilir.

**Gömülü video veya ses içeren sunumları birleştirebilir miyim?**

Evet, Aspose.Slides slaytlara gömülü multimedya içeriğini korur, ancak sonuç sunum önemli ölçüde daha büyük olabilir.

**Sunumları birleştirirken yazı tipleri korunacak mı?**

Evet. Kaynak sunumlardaki yazı tipleri, sistemde yüklü olduğu sürece veya [gömülü](/slides/tr/php-java/embedded-font/) olduğu sürece çıktı dosyasında korunur.