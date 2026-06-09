---
title: Ana Slayt
type: docs
weight: 30
url: /tr/php-java/examples/elements/master-slide/
keywords:
- ana slayt
- ana slayt ekle
- ana slayt eriş
- ana slayt kaldır
- kullanılmayan ana slayt
- kod örnekleri
- PowerPoint
- OpenDocument
- sunum
- PHP
- Aspose.Slides
description: "Aspose.Slides ile PHP'de ana slaytları yönetin: PowerPoint ve OpenDocument'ta slaytları birleştirmek için temaları, arka planları, yer tutucuları oluşturun, düzenleyin, klonlayın ve biçimlendirin."
---
Ana slaytlar, PowerPoint'te slayt miras hiyerarşisinin en üst seviyesini oluşturur. **Ana slayt**, arka planlar, logolar ve metin biçimlendirmesi gibi ortak tasarım öğelerini tanımlar. **Düzen slaytları**, ana slaytlardan miras alır ve **normal slaytlar** ise düzen slaytlarından miras alır.

Bu makale, Aspose.Slides for PHP via Java kullanarak ana slaytları nasıl oluşturacağınızı, değiştireceğinizi ve yöneteceğinizi gösterir.

## **Bir Ana Slayt Ekle**

Bu örnek, varsayılanı kopyalayarak yeni bir ana slayt oluşturmayı gösterir.

```php
function addMasterSlide() {
    $presentation = new Presentation();
    try {
        // Varsayılan ana slaytı klonla.
        $defaultMasterSlide = $presentation->getMasters()->get_Item(0);
        $newMasterSlide = $presentation->getMasters()->addClone($defaultMasterSlide);

        $presentation->save("master_slide.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

> 💡 **İpucu 1:** Ana slaytlar, tüm slaytlar arasında tutarlı bir marka kimliği veya ortak tasarım öğeleri uygulamanın bir yolunu sağlar. Ana slaytta yapılan herhangi bir değişiklik, bağımlı düzen ve normal slaytlara otomatik olarak yansır.

> 💡 **İpucu 2:** Ana slayta eklenen tüm şekiller veya biçimlendirmeler, düzen slaytları tarafından ve ardından bu düzenleri kullanan tüm normal slaytlara miras olarak geçer.  
> Aşağıdaki görüntü, ana slayta eklenen bir metin kutusunun son slaytta otomatik olarak nasıl render edildiğini gösterir.

![Ana Miras Örneği](master-slide-banner.png)

## **Bir Ana Slayta Erişme**

`Presentation::getMasters` yöntemiyle ana slaytlara erişebilirsiniz. İşte onları nasıl alacağınız ve üzerinde çalışacağınız:

```php
function accessMasterSlide() {
    $presentation = new Presentation("master_slide.pptx");
    try {
        // İlk ana slayta eriş.
        $firstMasterSlide = $presentation->getMasters()->get_Item(0);
    } finally {
        $presentation->dispose();
    }
}
```

## **Bir Ana Slaytı Kaldır**

Ana slaytlar, indeks veya referans ile kaldırılabilir.

```php
function removeMasterSlide() {
    $presentation = new Presentation("master_slide.pptx");
    try {
        // Indeks ile kaldır.
        $presentation->getMasters()->removeAt(0);

        // Veya referans ile kaldır.
        $firstMasterSlide = $presentation->getMasters()->get_Item(0);
        $presentation->getMasters()->remove($firstMasterSlide);

        $presentation->save("master_slide_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Kullanılmayan Ana Slaytları Kaldır**

Bazı sunumlar kullanılmayan ana slaytlara sahiptir. Bu slaytların kaldırılması dosya boyutunun azaltılmasına yardımcı olabilir.

```php
function removeUnusedMasterSlide() {
    $presentation = new Presentation("master_slide.pptx");
    try {
        // Kullanılmayan tüm ana slaytları kaldır (koruma olarak işaretlenmiş olanlar dahil).
        $presentation->getMasters()->removeUnused(true);

        $presentation->save("master_slides_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

> ⚙️ **İpucu:** Kullanılmayan ana slaytları temizlemek ve sunum boyutunu en aza indirmek için `removeUnused(true)` kullanın.