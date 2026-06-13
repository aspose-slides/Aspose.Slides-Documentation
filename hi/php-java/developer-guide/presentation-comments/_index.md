---
title: PHP में प्रस्तुति टिप्पणियों का प्रबंधन
linktitle: प्रस्तुति टिप्पणियाँ
type: docs
weight: 100
url: /hi/php-java/presentation-comments/
keywords:
- टिप्पणी
- आधुनिक टिप्पणी
- PowerPoint टिप्पणियाँ
- प्रस्तुति टिप्पणियाँ
- स्लाइड टिप्पणियाँ
- टिप्पणी जोड़ें
- टिप्पणी तक पहुंचें
- टिप्पणी संपादित करें
- टिप्पणी का उत्तर दें
- टिप्पणी हटाएँ
- टिप्पणी को हटाएँ
- PowerPoint
- OpenDocument
- प्रस्तुति
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java के साथ प्रस्तुति टिप्पणियों को महारत हासिल करें: PowerPoint फाइलों में टिप्पणियों को तेज़ी और आसानी से जोड़ें, पढ़ें, संपादित करें और हटाएँ।"
---
## **परिचय**

यह लेख Aspose.Slides में प्रस्तुति टिप्पणी को प्रबंधित करने के तरीकों को समझाता है। यह मुख्य टिप्पणी-से संबंधित प्रकारों को दिखाता है और स्लाइड में टिप्पणी जोड़ने, मौजूदा टिप्पणियों तक पहुंचने, उत्तरों के साथ काम करने, आधुनिक टिप्पणियों का उपयोग करने, और प्रस्तुति से टिप्पणियों को हटाने का प्रदर्शन करता है।

उदाहरण PowerPoint में सामान्य समीक्षा और सहयोग परिदृश्यों पर केंद्रित हैं, जैसे लेखकों को टिप्पणियाँ असाइन करना, टिप्पणी की सामग्री और मेटा डेटा पढ़ना, उत्तर श्रृंखलाएँ बनाना, और सभी टिप्पणियों को साफ़ करना या चयनित टिप्पणियों को हटाना।

PowerPoint में, एक टिप्पणी स्लाइड पर नोट या एनोटेशन के रूप में दिखाई देती है। जब टिप्पणी पर क्लिक किया जाता है, तो उसकी सामग्री या संदेश प्रदर्शित होते हैं।

## **प्रस्तुतियों में टिप्पणियाँ क्यों जोड़ें?**

आप प्रस्तुतियों की समीक्षा करते समय प्रतिक्रिया प्रदान करने या अपने सहयोगियों के साथ संवाद करने के लिए टिप्पणियों का उपयोग करना चाह सकते हैं।

PowerPoint प्रस्तुतियों में टिप्पणियों का उपयोग करने की सुविधा देने के लिए, Aspose.Slides for PHP via Java प्रदान करता है

* The [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) क्लास, जिसमें लेखकों के संग्रह ( [CommentAuthorCollection](https://reference.aspose.com/slides/hi/php-java/aspose.slides/commentauthorcollection/) क्लास से) होते हैं। लेखक स्लाइड में टिप्पणियाँ जोड़ते हैं।
* The  [CommentCollection](https://reference.aspose.com/slides/hi/php-java/aspose.slides/commentcollection/) क्लास, जिसमें व्यक्तिगत लेखकों के लिए टिप्पणियों का संग्रह होता है।
* The  [Comment](https://reference.aspose.com/slides/hi/php-java/aspose.slides/comment/) क्लास, जिसमें लेखकों और उनकी टिप्पणियों की जानकारी होती है: किसने टिप्पणी जोड़ी, टिप्पणी जोड़ने का समय, टिप्पणी की स्थिति आदि।
* The [CommentAuthor](https://reference.aspose.com/slides/hi/php-java/aspose.slides/commentauthor/) क्लास, जिसमें व्यक्तिगत लेखकों की जानकारी होती है: लेखक का नाम, उसके प्रारम्भिक अक्षर, लेखक के नाम से जुड़ी टिप्पणियाँ आदि।

## **स्लाइड टिप्पणियाँ जोड़ें**

यह PHP कोड दिखाता है कि PowerPoint प्रस्तुति में एक स्लाइड पर टिप्पणी कैसे जोड़ें:

```php
  # Presentation क्लास का उदाहरण बनाता है
  $pres = new Presentation();
  $Array = new java_class("java.lang.reflect.Array");
  try {
    # एक खाली स्लाइड जोड़ता है
    $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->get_Item(0));
    # एक लेखक जोड़ता है
    $author = $pres->getCommentAuthors()->addAuthor("Jawad", "MF");
    # टिप्पणियों के लिए स्थिति निर्धारित करता है
    $point = new Point2DFloat(0.2, 0.2);
    # स्लाइड 1 पर लेखक के लिए स्लाइड टिप्पणी जोड़ता है
    $author->getComments()->addComment("Hello Jawad, this is slide comment", $pres->getSlides()->get_Item(0), $point, new Java("java.util.Date"));
    # स्लाइड 2 पर लेखक के लिए स्लाइड टिप्पणी जोड़ता है
    $author->getComments()->addComment("Hello Jawad, this is second slide comment", $pres->getSlides()->get_Item(1), $point, new Java("java.util.Date"));
    # ISlide 1 तक पहुँचता है
    $slide = $pres->getSlides()->get_Item(0);
    # जब तर्क के रूप में null पास किया जाता है, सभी लेखकों की टिप्पणियाँ चयनित स्लाइड में लाई जाती हैं
    $Comments = $slide->getSlideComments($author);
    # स्लाइड 1 के लिए इंडेक्स 0 पर टिप्पणी तक पहुँचता है
    $str = $Comments[0]->getText();
    $pres->save("Comments_out.pptx", SaveFormat::Pptx);
    if (java_values($Array->getLength($Comments)) > 0) {
      # इंडेक्स 0 पर लेखक की टिप्पणियों का संग्रह चुनता है
      $commentCollection = $Comments[0]->getAuthor()->getComments();
      $Comment = $commentCollection->get_Item(0)->getText();
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **स्लाइड टिप्पणियों तक पहुंचें**

यह PHP कोड दिखाता है कि PowerPoint प्रस्तुति में एक स्लाइड पर मौजूदा टिप्पणी तक कैसे पहुंचें:

```php
  # Presentation क्लास का उदाहरण बनाता है
  $pres = new Presentation("Comments1.pptx");
  try {
    foreach($pres->getCommentAuthors() as $commentAuthor) {
      $author = $commentAuthor;
      foreach($author->getComments() as $comment1) {
        $comment = $comment1;
        echo("ISlide :" . $comment->getSlide()->getSlideNumber() . " has comment: " . $comment->getText() . " with Author: " . $comment->getAuthor()->getName() . " posted on time :" . $comment->getCreatedTime() . "\n");
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **टिप्पणियों का उत्तर दें**

एक पैरेंट टिप्पणी वह शीर्ष या मूल टिप्पणी होती है जो टिप्पणियों या उत्तरों की पदानुक्रम में होती है। [getParentComment](https://reference.aspose.com/slides/hi/php-java/aspose.slides/comment/getparentcomment/) या [setParentComment](https://reference.aspose.com/slides/hi/php-java/aspose.slides/comment/setparentcomment/) मेथड्स ( [Comment](https://reference.aspose.com/slides/hi/php-java/aspose.slides/comment/) क्लास से) का उपयोग करके आप पैरेंट टिप्पणी सेट या प्राप्त कर सकते हैं।

यह PHP कोड दिखाता है कि टिप्पणियाँ कैसे जोड़ें और उनके उत्तर कैसे प्राप्त करें:

```php
  $pres = new Presentation();
  $Array = new java_class("java.lang.reflect.Array");
  try {
    # टिप्पणी जोड़ता है
    $author1 = $pres->getCommentAuthors()->addAuthor("Author_1", "A.A.");
    $comment1 = $author1->getComments()->addComment("comment1", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    # टिप्पणी1 के लिए उत्तर जोड़ता है
    $author2 = $pres->getCommentAuthors()->addAuthor("Autror_2", "B.B.");
    $reply1 = $author2->getComments()->addComment("reply 1 for comment 1", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $reply1->setParentComment($comment1);
    # टिप्पणी1 के लिए दूसरा उत्तर जोड़ता है
    $reply2 = $author2->getComments()->addComment("reply 2 for comment 1", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $reply2->setParentComment($comment1);
    # मौजूदा उत्तर का उत्तर जोड़ता है
    $subReply = $author1->getComments()->addComment("subreply 3 for reply 2", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $subReply->setParentComment($reply2);
    $comment2 = $author2->getComments()->addComment("comment 2", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $comment3 = $author2->getComments()->addComment("comment 3", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $reply3 = $author1->getComments()->addComment("reply 4 for comment 3", $pres->getSlides()->get_Item(0), new Point2DFloat(10, 10), new Java("java.util.Date"));
    $reply3->setParentComment($comment3);
    # कंसोल पर टिप्पणी पदानुक्रम प्रदर्शित करता है
    $slide = $pres->getSlides()->get_Item(0);
    $comments = $slide->getSlideComments(null);
    for($i = 0; $i < java_values($Array->getLength($comments)) ; $i++) {
      $comment = $comments[$i];
      while (!java_is_null($comment->getParentComment())) {
        System->out->print("\t");
        $comment = $comment->getParentComment();
      } 
      echo($comments[$i]->getAuthor()->getName() . " : " . $comments[$i]->getText());
      echo();
    }
    $pres->save("parent_comment.pptx", SaveFormat::Pptx);
    # टिप्पणी1 और उसके सभी उत्तरों को हटाता है
    $comment1->remove();
    $pres->save("remove_comment.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="warning" title="ध्यान" %}} 

* जब [remove](https://reference.aspose.com/slides/hi/php-java/aspose.slides/comment/remove/) मेथड ( [Comment](https://reference.aspose.com/slides/hi/php-java/aspose.slides/comment/) क्लास से) का उपयोग करके कोई टिप्पणी हटाई जाती है, तो उसकी टिप्पणी के उत्तर भी हट जाते हैं।
* यदि [setParentComment](https://reference.aspose.com/slides/hi/php-java/aspose.slides/comment/setparentcomment/) सेटिंग से एक चक्रीय संदर्भ बनता है, तो [PptxEditException](https://reference.aspose.com/slides/hi/php-java/aspose.slides/pptxeditexception/) उत्पन्न होगा।

{{% /alert %}}

## **आधुनिक टिप्पणियाँ जोड़ें**

2021 में, Microsoft ने PowerPoint में *आधुनिक टिप्पणियाँ* पेश कीं। आधुनिक टिप्पणी फीचर PowerPoint में सहयोग को काफी सुधरता है। आधुनिक टिप्पणियों के माध्यम से, PowerPoint उपयोगकर्ता टिप्पणियों को हल कर सकते हैं, वस्तुओं और पाठों से टिप्पणी को एंकर कर सकते हैं, और पहले की तुलना में बहुत आसानी से इंटरैक्शन कर सकते हैं। 

Aspose Slides [ModernComment](https://reference.aspose.com/slides/hi/php-java/aspose.slides/moderncomment/) क्लास द्वारा आधुनिक टिप्पणियों का समर्थन करता है। [addModernComment](https://reference.aspose.com/slides/hi/php-java/aspose.slides/commentcollection/addmoderncomment/) और [insertModernComment](https://reference.aspose.com/slides/hi/php-java/aspose.slides/commentcollection/insertmoderncomment/) मेथड्स को [CommentCollection](https://reference.aspose.com/slides/hi/php-java/aspose.slides/commentcollection/) क्लास में जोड़ा गया है।

यह PHP कोड दिखाता है कि PowerPoint प्रस्तुति में एक स्लाइड में आधुनिक टिप्पणी कैसे जोड़ें:

```php
  $pres = new Presentation();
  try {
    $newAuthor = $pres->getCommentAuthors()->addAuthor("Some Author", "SA");
    $modernComment = $newAuthor->getComments()->addModernComment("This is a modern comment", $pres->getSlides()->get_Item(0), null, new Point2DFloat(100, 100), new Java("java.util.Date"));
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **टिप्पणियों को हटाएँ**

### **सभी टिप्पणियों और लेखकों को हटाएँ**

यह PHP कोड दिखाता है कि प्रस्तुति में सभी टिप्पणियों और लेखकों को कैसे हटाएँ:

```php
  $presentation = new Presentation("example.pptx");
  try {
    # प्रस्तुति से सभी टिप्पणियाँ हटाता है
    foreach($presentation->getCommentAuthors() as $author) {
      $author->getComments()->clear();
    }
    # सभी लेखकों को हटाता है
    $presentation->getCommentAuthors()->clear();
    $presentation->save("example_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

### **विशिष्ट टिप्पणियों को हटाएँ**

यह PHP कोड दिखाता है कि स्लाइड पर विशिष्ट टिप्पणियों को कैसे हटाएँ:

```php
  $presentation = new Presentation();
  try {
    $slide = $presentation->getSlides()->get_Item(0);
    # टिप्पणियाँ जोड़ें...
    $author = $presentation->getCommentAuthors()->addAuthor("Author", "A");
    $author->getComments()->addComment("comment 1", $slide, new Point2DFloat(0.2, 0.2), new Java("java.util.Date"));
    $author->getComments()->addComment("comment 2", $slide, new Point2DFloat(0.3, 0.2), new Java("java.util.Date"));
    # उन सभी टिप्पणियों को हटाएँ जिनमें "comment 1" पाठ है
    foreach($presentation->getCommentAuthors() as $commentAuthor) {
      $toRemove = new Java("java.util.ArrayList");
      foreach($slide->getSlideComments($commentAuthor) as $comment) {
        if ($comment->getText()->equals("comment 1")) {
          $toRemove->add($comment);
        }
      }
      foreach($toRemove as $comment) {
        $commentAuthor->getComments()->remove($comment);
      }
    }
    $presentation->save("pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या Aspose.Slides आधुनिक टिप्पणियों के लिए 'हल किया गया' जैसी स्थिति का समर्थन करता है?**

हाँ। [Modern comments](https://reference.aspose.com/slides/hi/php-java/aspose.slides/moderncomment/) एक [setStatus](https://reference.aspose.com/slides/hi/php-java/aspose.slides/moderncomment/setstatus/) मेथड प्रदान करता है; आप एक [comment’s state](https://reference.aspose.com/slides/hi/php-java/aspose.slides/moderncommentstatus/) लिख सकते हैं (उदाहरण के लिए, इसे हल किया गया मान कर), और यह स्थिति फ़ाइल में सहेजी जाती है और PowerPoint द्वारा पहचानी जाती है।

**क्या थ्रेडेड चर्चा (उत्तर श्रृंखलाएँ) समर्थित हैं, और क्या कोई नेस्टिंग सीमा है?**

हाँ। प्रत्येक टिप्पणी अपने [parent comment](https://reference.aspose.com/slides/hi/php-java/aspose.slides/comment/getparentcomment/) का संदर्भ दे सकती है, जिससे मनमानी उत्तर श्रृंखलाएँ संभव होती हैं। API कोई विशिष्ट नेस्टिंग गहराई सीमा घोषित नहीं करता है।

**स्लाइड पर टिप्पणी मार्कर की स्थिति किस निर्देशांक प्रणाली में परिभाषित है?**

स्थिति स्लाइड की निर्देशांक प्रणाली में एक फ्लोटिंग-पॉइंट बिंदु के रूप में संग्रहीत होती है। यह आपको टिप्पणी मार्कर को ठीक उसी स्थान पर रखने की अनुमति देता है जहाँ आपको आवश्यकता है।