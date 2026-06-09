---
title: Bölüm
type: docs
weight: 90
url: /tr/php-java/examples/elements/section/
keywords:
- bölüm
- slayt bölümü
- bölüm ekle
- bölüme eriş
- bölümü kaldır
- bölümü yeniden adlandır
- kod örnekleri
- PowerPoint
- OpenDocument
- sunum
- PHP
- Aspose.Slides
description: "PHP'de Aspose.Slides ile slayt bölümlerini yönetin: oluşturun, yeniden adlandırın, kolayca yeniden sıralayın, bölümler arasında slaytları taşıyın ve PPT, PPTX ve ODP için görünürlüğü kontrol edin."
---
Sunum bölümlerini yönetmek için örnekler — ekleme, erişim, silme ve yeniden adlandırma işlemlerini **Aspose.Slides for PHP via Java** ile programlı olarak gerçekleştirme.

## **Bölüm Ekle**

Belirli bir slaytta başlayan bir bölüm oluşturun.

```php
function addSection() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Bölümün başlangıcını belirten slaytı belirtin.
        $presentation->getSections()->addSection("New Section", $slide);

        $presentation->save("section.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Bölüme Eriş**

Bir sunumdan bölüm bilgilerini okuyun.

```php
function accessSection() {
    $presentation = new Presentation("section.pptx");
    try {
        // İndeks ile bir bölüme eriş.
        $section = $presentation->getSections()->get_Item(0);
        $sectionName = $section->getName();
    } finally {
        $presentation->dispose();
    }
}
```

## **Bölümü Kaldır**

Önceden eklenmiş bir bölümü silin.

```php
function removeSection() {
    $presentation = new Presentation("section.pptx");
    try {
        $section = $presentation->getSections()->get_Item(0);

        // Bölümü kaldır.
        $presentation->getSections()->removeSection($section);

        $presentation->save("section_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Bölümü Yeniden Adlandır**

Mevcut bir bölümün adını değiştirin.

```php
function renameSection() {
    $presentation = new Presentation("section.pptx");
    try {
        $section = $presentation->getSections()->get_Item(0);
        $section->setName("New Name");

        $presentation->save("section_renamed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```