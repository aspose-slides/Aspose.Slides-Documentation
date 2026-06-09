---
title: Slayt
type: docs
weight: 10
url: /tr/php-java/examples/elements/slide/
keywords:
- slayt
- slayt ekle
- slayta eriş
- slayt indeksi
- slayt kopyala
- slaytları yeniden sırala
- slayt kaldır
- kod örnekleri
- PowerPoint
- OpenDocument
- sunum
- PHP
- Aspose.Slides
description: "PHP'de Aspose.Slides ile slaytları yönetin: oluşturun, kopyalayın, yeniden sıralayın, gizleyin, arka planları ve boyutu ayarlayın, geçişler uygulayın ve PowerPoint ve OpenDocument için dışa aktarın."
---
Bu makale, **Aspose.Slides for PHP via Java** kullanarak slaytlarla nasıl çalışılacağını gösteren bir dizi örnek sunar. `Presentation` sınıfını kullanarak slayt ekleme, erişme, kopyalama, sıralamayı değiştirme ve kaldırma konularını öğreneceksiniz.

Aşağıdaki her örnek, kısa bir açıklama ve ardından PHP kod parçacığını içerir.

## **Bir Slayt Ekle**

Yeni bir slayt eklemek için önce bir düzen seçmeniz gerekir. Bu örnekte, `Blank` düzenini kullanarak sunuma boş bir slayt ekliyoruz.

```php
function addSlide() {
    $presentation = new Presentation();
    try {
        // Her slayt, kendisi bir ana slayta dayalı bir düzen üzerine kuruludur.
        // Yeni bir slayt oluşturmak için Boş düzeni kullanın.
        $blankLayout = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Blank);

        // Seçilen düzeni kullanarak yeni boş bir slayt ekleyin.
        $presentation->getSlides()->addEmptySlide($blankLayout);

        $presentation->save("slide.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

> 💡 **İpucu:** Her slayt düzeni, genel tasarımı ve yer tutucu yapısını tanımlayan bir ana slayttan türetilir. Aşağıdaki görsel, ana slaytların ve bunlarla ilişkili düzenlerin PowerPoint'te nasıl organize edildiğini gösterir.

![Ana ve Düzen İlişkisi](master-layout-slide.png)

## **Dizine Göre Slaytlara Erişim**

```php
function accessSlide() {
    $presentation = new Presentation("slide.pptx");
    try {
        // Bir slayta indeksle eriş.
        $firstSlide = $presentation->getSlides()->get_Item(0);
    } finally {
        $presentation->dispose();
    }
}
```

## **Bir Slaytı Kopyala**

Bu örnek, mevcut bir slaytı nasıl kopyalayacağınızı gösterir. Kopyalanan slayt, slayt koleksiyonunun sonuna otomatik olarak eklenir.

```php
function cloneSlide() {
    // Varsayılan olarak, sunum bir boş slayt içerir.
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // İlk slaytı kopyala; sunumun sonuna eklenecek.
        $clonedSlide = $presentation->getSlides()->addClone($slide);

        // Kopyalanan slaytın indeksi 1'dir (sunumdaki ikinci slayt).
        $clonedSlideIndex = $presentation->getSlides()->indexOf($clonedSlide);

        $presentation->save("slide_cloned.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Slaytların Sırasını Değiştir**

Bir slaytı yeni bir dizine taşıyarak slaytların sırasını değiştirebilirsiniz. Bu örnekte, bir slaytı ilk konuma taşıyoruz.

```php
function reorderSlide() {
    $presentation = new Presentation("slide.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(1);

        // Slaytı ilk konuma taşı (diğerleri aşağı kayar).
        $presentation->getSlides()->reorder(0, $slide);

        $presentation->save("slide_reordered.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Bir Slaytı Kaldır**

Bir slaytı kaldırmak için, sadece ona referans verip `remove` metodunu çağırmanız yeterlidir. Bu örnek, slaytları dizine ve referansa göre kaldırır.

```php
function removeSlide() {
    $presentation = new Presentation("slide.pptx");
    try {
        // Bir slaytı indeksle kaldır.
        $presentation->getSlides()->removeAt(0);

        // Bir slaytı referansla kaldır.
        $slide = $presentation->getSlides()->get_Item(0);
        $presentation->getSlides()->remove($slide);

        $presentation->save("slides_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```