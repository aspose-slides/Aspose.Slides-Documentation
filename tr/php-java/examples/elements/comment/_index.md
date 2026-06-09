---
title: Yorum
type: docs
weight: 230
url: /tr/php-java/examples/elements/comment/
keywords:
- yorum
- modern yorum
- yorum ekle
- yoruma eriş
- yorumu kaldır
- yoruma yanıtla
- kod örnekleri
- PowerPoint
- OpenDocument
- sunum
- PHP
- Aspose.Slides
description: "Aspose.Slides ile PHP'de slayt yorumlarını yönetin: ekleyin, okuyun, yanıtlayın, düzenleyin, silin ve PowerPoint ve OpenDocument için zincirli yorumlarla çalışın."
---
Modern yorumları ekleme, okuma, kaldırma ve yanıt verme işlemlerini **Aspose.Slides for PHP via Java** kullanarak gösterir.

## **Modern Yorum Ekle**

Kullanıcı tarafından oluşturulmuş bir yorum oluşturun ve sunumu kaydedin.

```php
function addModernComment() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Modern bir yorum ekle.
        $author = $presentation->getCommentAuthors()->addAuthor("User", "U1");
        $author->getComments()->addModernComment("This is a modern comment", $slide, null, new Point2DFloat(100, 100), new Java("java.util.Date"));

        $presentation->save("modern_comment.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Modern Yorum Erişim**

Mevcut bir sunumdan modern bir yorumu okuyun.

```php
function accessModernComment() {
    $presentation = new Presentation("modern_comment.pptx");
    try {
        $author = $presentation->getCommentAuthors()->get_Item(0);
        $comment = $author->getComments()->get_Item(0);
        echo "Author: " . $author->getName() . ", Comment: " . $comment->getText() . PHP_EOL;
    } finally {
        $presentation->dispose();
    }
}
```

## **Modern Yorum Kaldır**

Bir yorumu kaldırın ve güncellenmiş dosyayı kaydedin.

```php
function removeModernComment() {
    $presentation = new Presentation("modern_comment.pptx");
    try {
        $author = $presentation->getCommentAuthors()->get_Item(0);
        $comment = $author->getComments()->get_Item(0);

        $comment->remove();

        $presentation->save("modern_comment_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Modern Yorum'a Yanıtla**

Üst modern yoruma yanıtlar ekleyin.

```php
function replyToModernComment() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Yorum yazarını ekle.
        $author = $presentation->getCommentAuthors()->addAuthor("User", "U1");

        // Üst yorum ve yanıtları ekle.
        $parent = $author->getComments()->addModernComment("Parent comment", $slide, null, new Point2DFloat(100, 100), new Java("java.util.Date"));
        $reply1 = $author->getComments()->addModernComment("Reply 1", $slide, null, new Point2DFloat(110, 100), new Java("java.util.Date"));
        $reply2 = $author->getComments()->addModernComment("Reply 2", $slide, null, new Point2DFloat(120, 100), new Java("java.util.Date"));

        // Yanıtlar için üst yorumu ayarla.
        $reply1->setParentComment($parent);
        $reply2->setParentComment($parent);

        // Yanıtlarla birlikte sunumu kaydet.
        $presentation->save("modern_comment_replies.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```