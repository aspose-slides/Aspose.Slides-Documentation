---
title: Not
type: docs
weight: 240
url: /tr/php-java/examples/elements/note/
keywords:
- not
- not slaytı ekle
- not slaytına eriş
- not slaytı kaldır
- not metnini güncelle
- kod örnekleri
- PowerPoint
- OpenDocument
- sunum
- PHP
- Aspose.Slides
description: "PHP'de Aspose.Slides ile konuşmacı notlarını ekleyin, okuyun, düzenleyin ve dışa aktarın: metni biçimlendirin, slayt başına notları yönetin ve PowerPoint ve OpenDocument'te görünürlüğü kontrol edin."
---
Aspose.Slides for PHP via Java kullanarak not slaytlarını ekleme, okuma, kaldırma ve güncelleme işlemlerinin nasıl yapılacağını gösterir.

## **Not Slaytı Ekle**

Bir not slaytı oluşturun ve ona metin atayın.

```php
function addNote() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $notesSlide = $slide->getNotesSlideManager()->addNotesSlide();
        $notesSlide->getNotesTextFrame()->setText("My note");

        $presentation->save("note.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Not Slaytına Erişim**

Mevcut bir not slaytından metni okuyun.

```php
function accessNote() {
    $presentation = new Presentation("note.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $notesSlide = $slide->getNotesSlideManager()->getNotesSlide();
        $notes = $notesSlide->getNotesTextFrame()->getText();
    } finally {
        $presentation->dispose();
    }
}
```

## **Not Slaytını Kaldır**

Bir slayt ile ilişkili not slaytını kaldırın.

```php
function removeNote() {
    $presentation = new Presentation("note.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $slide->getNotesSlideManager()->removeNotesSlide();

        $presentation->save("note_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Not Metnini Güncelle**

Bir not slaytının metnini değiştirin.

```php
function updateNoteText() {
    $presentation = new Presentation("note.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $notesSlide = $slide->getNotesSlideManager()->getNotesSlide();
        $notesSlide->getNotesTextFrame()->setText("Updated");

        $presentation->save("note_updated.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```