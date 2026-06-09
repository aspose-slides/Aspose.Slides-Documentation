---
title: Düzen Slaytı
type: docs
weight: 20
url: /tr/php-java/examples/elements/layout-slide/
keywords:
- düzen slaytı
- düzen slaytı ekle
- düzen slaytı erişimi
- düzen slaytı kaldır
- kullanılmayan düzen slaytı
- düzen slaytı çoğalt
- kod örnekleri
- PowerPoint
- OpenDocument
- sunum
- PHP
- Aspose.Slides
description: "Aspose.Slides ile PHP kullanarak düzen slaytlarını yönetin: sunumlarda PPT, PPTX ve ODP için yer tutucuları ve temaları oluşturun, uygulayın, çoğaltın, yeniden adlandırın ve özelleştirin."
---
Bu makale, Aspose.Slides for PHP via Java'da **Layout Slides** ile nasıl çalışılacağını gösterir. Bir düzen slaytı, normal slaytlar tarafından miras alınan tasarım ve biçimlendirmeyi tanımlar. Düzen slaytlarını ekleyebilir, erişebilir, kopyalayabilir ve kaldırabilir, ayrıca kullanılmayanları temizleyerek sunum boyutunu azaltabilirsiniz.

## **Düzen Slaytı Ekle**

Kendi özel bir düzen slaytı oluşturarak yeniden kullanılabilir biçimlendirme tanımlayabilirsiniz. Örneğin, bu düzeni kullanan tüm slaytlarda görünen bir metin kutusu ekleyebilirsiniz.

```php
function addLayoutSlide() {
    $presentation = new Presentation();
    try {
        $masterSlide = $presentation->getMasters()->get_Item(0);

        // Boş bir düzen türü ve özel bir ad ile bir düzen slaytı oluşturun.
        $layoutSlide = $presentation->getLayoutSlides()->add($masterSlide, SlideLayoutType::Blank, "Main layout");

        $presentation->save("layout_slide.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

> 💡 **İpucu 1:** Düzen slaytları, bireysel slaytlar için şablon görevi görür. Ortak öğeleri bir kez tanımlayıp birçok slayt arasında yeniden kullanabilirsiniz.

> 💡 **İpucu 2:** Bir düzen slaytına şekil veya metin eklediğinizde, bu düzeni temel alan tüm slaytlar bu ortak içeriği otomatik olarak gösterir.
> Aşağıdaki ekran görüntüsü, aynı düzen slaytından bir metin kutusu miras alan iki slaytı gösterir.

![Düzen İçeriğini Miras Alan Slaytlar](layout-slide-result.png)

## **Düzen Slaytına Erişim**

Düzen slaytlarına indeks ile ya da düzen türüne göre (ör. `Blank`, `Title`, `SectionHeader` vb.) erişilebilir.

```php
function accessLayoutSlide() {
    $presentation = new Presentation("layout_slide.pptx");
    try {
        // İndekse göre erişim.
        $firstLayoutSlide = $presentation->getLayoutSlides()->get_Item(0);

        // Düzen türüne göre erişim.
        $blankLayoutSlide = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Blank);
    } finally {
        $presentation->dispose();
    }
}
```

## **Düzen Slaytını Kaldır**

Artık ihtiyaç duyulmayan belirli bir düzen slaytını kaldırabilirsiniz.

```php
function removeLayoutSlide() {
    $presentation = new Presentation("layout_slide.pptx");
    try {
        // Tipine göre bir düzen slaytı al ve kaldır.
        $layoutSlide = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Custom);
        $presentation->getLayoutSlides()->remove($layoutSlide);

        $presentation->save("layout_slide_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Kullanılmayan Düzen Slaytlarını Kaldır**

Sunum boyutunu azaltmak için, hiçbir normal slayt tarafından kullanılmayan düzen slaytlarını kaldırmak isteyebilirsiniz.

```php
function removeUnusedLayoutSlides() {
    $presentation = new Presentation("layout_slide.pptx");
    try {
        // Otomatik olarak herhangi bir slayt tarafından referans edilmeyen tüm düzen slaytlarını kaldırır.
        $presentation->getLayoutSlides()->removeUnused();

        $presentation->save("layout_slides_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Düzen Slaytını Kopyala**

`addClone` yöntemi kullanılarak bir düzen slaytı çoğaltılabilir.

```php
function cloneLayoutSlides() {
    $presentation = new Presentation("layout_slide.pptx");
    try {
        // Tipine göre mevcut bir düzen slaytı al.
        $blankLayoutSlide = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Blank);

        // Düzen slaytını, düzen slaytı koleksiyonunun sonuna çoğalt.
        $clonedLayoutSlide = $presentation->getLayoutSlides()->addClone($blankLayoutSlide);

        $presentation->save("layout_slide_cloned.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

> ✅ **Özet:** Düzen slaytları, slaytlar arasında tutarlı biçimlendirmeyi yönetmek için güçlü araçlardır. Aspose.Slides, düzen slaytlarını oluşturma, yönetme ve optimize etme konularında tam kontrol sağlar.