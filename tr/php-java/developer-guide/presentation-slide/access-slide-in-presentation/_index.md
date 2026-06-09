---
title: PHP'de Sunum Slaytlarına Erişim
linktitle: Slayta Erişim
type: docs
weight: 20
url: /tr/php-java/access-slide-in-presentation/
keywords:
- slayta erişim
- slayt indeksi
- slayt kimliği
- slayt konumu
- konumu değiştir
- slayt özellikleri
- slayt numarası
- PowerPoint
- OpenDocument
- sunum
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java ile PowerPoint ve OpenDocument sunumlarındaki slaytlara nasıl erişileceğini ve yönetileceğini öğrenin. Kod örnekleriyle üretkenliği artırın."
---
## **Genel Bakış**

Bu makale, bir sunumda slaytları Aspose.Slides kullanarak nasıl erişileceğini ve yönetileceğini açıklar. Slayt koleksiyonundan sıfır tabanlı indeksle slaytları nasıl alacağınızı ve `getSlideById` yöntemiyle bir slaytı benzersiz kimliğiyle nasıl erişeceğinizi gösterir.

Ayrıca `setSlideNumber` yöntemiyle bir slaytın konumunu nasıl değiştireceğinizi ve `setFirstSlideNumber` yöntemiyle bir sunumun başlangıç slayt numarasını nasıl tanımlayacağınızı öğreneceksiniz. Örnekler, bir sunumu yüklemeyi, slayt referansları almayı, slayt sırasını veya numaralandırmasını güncellemeyi ve değiştirilmiş sunumu kaydetmeyi göstermektedir.

## **İndeks ile Slayta Erişim**

Bir sunumdaki tüm slaytlar, slayt konumuna göre 0'dan başlayarak sayısal olarak düzenlenir. İlk slayt indeks 0 ile erişilebilir; ikinci slayt indeks 1 ile erişilir; vb.

Sunum dosyasını temsil eden Presentation sınıfı, tüm slaytları bir [SlideCollection](https://reference.aspose.com/slides/tr/php-java/aspose.slides/slidecollection/) koleksiyonu ( [Slide](https://reference.aspose.com/slides/tr/php-java/aspose.slides/slide/) nesnelerinin koleksiyonu) olarak sunar. Bu PHP kodu, bir slayta indeksine göre nasıl erişileceğini gösterir:

```php
  # Bir sunum dosyasını temsil eden Presentation nesnesini oluşturur
  $pres = new Presentation("demo.pptx");
  try {
    # Slayt indeksini kullanarak bir slayta erişir
    $slide = $pres->getSlides()->get_Item(0);
  } finally {
    $pres->dispose();
  }
```

## **ID ile Slayta Erişim**

Bir sunumdaki her slayt, ona özgü benzersiz bir ID'ye sahiptir. Bu ID'yi hedeflemek için [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) sınıfı tarafından sunulan [getSlideById](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/#getSlideById-long-) yöntemini kullanabilirsiniz. Bu PHP kodu, geçerli bir slayt ID'si nasıl sağlanır ve bu slayta [getSlideById](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/#getSlideById-long-) yöntemiyle nasıl erişileceğini gösterir:

```php
  # Bir sunum dosyasını temsil eden Presentation nesnesini oluşturur
  $pres = new Presentation("demo.pptx");
  try {
    # Bir slayt kimliği alır
    $id = $pres->getSlides()->get_Item(0)->getSlideId();
    # Slaytı kimliğiyle erişir
    $slide = $pres->getSlideById($id);
  } finally {
    $pres->dispose();
  }
```

## **Slayt Konumunu Değiştirme**

Aspose.Slides, bir slayt konumunu değiştirmenize olanak tanır. Örneğin, ilk slaytın ikinci slayt haline gelmesini belirtebilirsiniz.

1. [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. Konumunu değiştirmek istediğiniz slaytın referansını indeksine göre alın
1. Slayt için yeni bir konum belirlemek amacıyla [setSlideNumber](https://reference.aspose.com/slides/tr/php-java/aspose.slides/slide/#setSlideNumber) yöntemini kullanın.
1. Değiştirilmiş sunumu kaydedin.

Bu PHP kodu, konumu 1 olan slaytın konumu 2'ye taşındığı bir işlemi göstermektedir:

```php
  # Bir sunum dosyasını temsil eden Presentation nesnesini oluşturur
  $pres = new Presentation("Presentation.pptx");
  try {
    # Konumu değiştirilecek slaytı alır
    $sld = $pres->getSlides()->get_Item(0);
    # Slayt için yeni konumu ayarlar
    $sld->setSlideNumber(2);
    # Değiştirilmiş sunumu kaydeder
    $pres->save("helloworld_Pos.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

İlk slayt ikinci oldu; ikinci slayt birinci oldu. Bir slaytın konumunu değiştirdiğinizde, diğer slaytlar otomatik olarak ayarlanır.

## **Slayt Numarasını Ayarlama**

[setFirstSlideNumber](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/#setFirstSlideNumber-int-) yöntemini ([Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) sınıfı tarafından sunulan) kullanarak, bir sunumdaki ilk slayt için yeni bir numara belirtebilirsiniz. Bu işlem diğer slayt numaralarının yeniden hesaplanmasına neden olur.

1. [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. Slayt numarasını alın.
1. Slayt numarasını ayarlayın.
1. Değiştirilmiş sunumu kaydedin.

Bu PHP kodu, ilk slayt numarasının 10 olarak ayarlandığı bir işlemi gösterir:

```php
  # Bir sunum dosyasını temsil eden Presentation nesnesini oluşturur
  $pres = new Presentation("HelloWorld.pptx");
  try {
    # Slayt numarasını alır
    $firstSlideNumber = $pres->getFirstSlideNumber();
    # Slayt numarasını ayarlar
    $pres->setFirstSlideNumber(10);
    # Değiştirilmiş sunumu kaydeder
    $pres->save("Set_Slide_Number_out.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

İlk slaytı atlamayı tercih ediyorsanız, numaralandırmayı ikinci slayttan başlayabilir (ve ilk slayt için numaralandırmayı gizleyebilirsiniz) şu şekilde:

```php
  $presentation = new Presentation();
  try {
    $layoutSlide = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Blank);
    $presentation->getSlides()->addEmptySlide($layoutSlide);
    $presentation->getSlides()->addEmptySlide($layoutSlide);
    $presentation->getSlides()->addEmptySlide($layoutSlide);
    # Sunumun ilk slaytı için numarayı ayarlar
    $presentation->setFirstSlideNumber(0);
    # Tüm slaytlar için slayt numaralarını gösterir
    $presentation->getHeaderFooterManager()->setAllSlideNumbersVisibility(true);
    # İlk slayt için slayt numarasını gizler
    $presentation->getSlides()->get_Item(0)->getHeaderFooterManager()->setSlideNumberVisibility(false);
    # Değiştirilmiş sunumu kaydeder
    $presentation->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **SSS**

**Kullanıcının gördüğü slayt numarası, koleksiyonun sıfır tabanlı indeksine eşleşir mi?**

Bir slaytta gösterilen numara, isteğe bağlı bir değerden (ör. 10) başlayabilir ve indeksle eşleşmek zorunda değildir; ilişki, sunumun [first slide number](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/setfirstslidenumber/) ayarıyla kontrol edilir.

**Gizli slaytlar indekslemeyi etkiler mi?**

Evet. Gizli bir slayt koleksiyon içinde kalır ve indekslemeye dahil edilir; “gizli” ifadesi görüntülenmeye dair bir özelliktir, koleksiyondaki konumunu etkilemez.

**Diğer slaytlar eklendiğinde veya kaldırıldığında bir slaytın indeksi değişir mi?**

Evet. İndeksler her zaman slaytlardaki mevcut sıralamayı yansıtır ve ekleme, silme ve taşıma işlemleri sırasında yeniden hesaplanır.