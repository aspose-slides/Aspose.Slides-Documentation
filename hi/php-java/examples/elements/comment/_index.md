---
title: टिप्पणी
type: docs
weight: 230
url: /hi/php-java/examples/elements/comment/
keywords:
- टिप्पणी
- आधुनिक टिप्पणी
- टिप्पणी जोड़ें
- टिप्पणी तक पहुंचें
- टिप्पणी हटाएँ
- टिप्पणी का उत्तर दें
- कोड उदाहरण
- PowerPoint
- OpenDocument
- प्रस्तुति
- PHP
- Aspose.Slides
description: "Aspose.Slides के साथ PHP में स्लाइड टिप्पणियों को प्रबंधित करें: जोड़ें, पढ़ें, उत्तर दें, संपादित करें, हटाएँ, और PowerPoint तथा OpenDocument के लिए थ्रेडेड टिप्पणियों के साथ काम करें।"
---
**Aspose.Slides for PHP via Java** का उपयोग करके आधुनिक टिप्पणियों को जोड़ने, पढ़ने, हटाने और उनका उत्तर देने का प्रदर्शन करता है।

## **आधुनिक टिप्पणी जोड़ें**

एक उपयोगकर्ता द्वारा लिखी गई टिप्पणी बनाएं और प्रस्तुति को सहेजें।

```php
function addModernComment() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // एक आधुनिक टिप्पणी जोड़ें।
        $author = $presentation->getCommentAuthors()->addAuthor("User", "U1");
        $author->getComments()->addModernComment("This is a modern comment", $slide, null, new Point2DFloat(100, 100), new Java("java.util.Date"));

        $presentation->save("modern_comment.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **आधुनिक टिप्पणी तक पहुंचें**

एक मौजूदा प्रस्तुति से आधुनिक टिप्पणी पढ़ें।

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

## **आधुनिक टिप्पणी हटाएँ**

एक टिप्पणी हटाएँ और अद्यतन फ़ाइल को सहेजें।

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

## **आधुनिक टिप्पणी का उत्तर दें**

एक मूल आधुनिक टिप्पणी में उत्तर जोड़ें।

```php
function replyToModernComment() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // टिप्पणी लेखक जोड़ें।
        $author = $presentation->getCommentAuthors()->addAuthor("User", "U1");

        // मूल टिप्पणी और उत्तर जोड़ें।
        $parent = $author->getComments()->addModernComment("Parent comment", $slide, null, new Point2DFloat(100, 100), new Java("java.util.Date"));
        $reply1 = $author->getComments()->addModernComment("Reply 1", $slide, null, new Point2DFloat(110, 100), new Java("java.util.Date"));
        $reply2 = $author->getComments()->addModernComment("Reply 2", $slide, null, new Point2DFloat(120, 100), new Java("java.util.Date"));

        // उत्तरों के लिए मूल टिप्पणी सेट करें।
        $reply1->setParentComment($parent);
        $reply2->setParentComment($parent);

        // उत्तरों के साथ प्रस्तुति को सहेजें।
        $presentation->save("modern_comment_replies.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```