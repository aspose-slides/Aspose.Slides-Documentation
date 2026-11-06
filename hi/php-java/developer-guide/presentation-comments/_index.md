---
title: PHP में प्रेज़ेंटेशन टिप्पणियों का प्रबंधन
linktitle: प्रेज़ेंटेशन टिप्पणियां
type: docs
weight: 100
url: /hi/php-java/presentation-comments/
keywords:
- टिप्पणी
- आधुनिक टिप्पणी
- PowerPoint टिप्पणियाँ
- प्रेज़ेंटेशन टिप्पणियाँ
- स्लाइड टिप्पणियाँ
- टिप्पणी जोड़ें
- टिप्पणी तक पहुँचें
- टिप्पणी संपादित करें
- टिप्पणी का उत्तर दें
- टिप्पणी हटाएँ
- टिप्पणी विलोपित करें
- PowerPoint
- प्रेज़ेंटेशन
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java के साथ प्रेज़ेंटेशन टिप्पणियों को प्रबंधित करें: PowerPoint प्रेज़ेंटेशनों में टिप्पणियों को जल्दी और आसानी से जोड़ें, पढ़ें, संपादित करें, उत्तर दें और हटाएँ।"
---
## **अवलोकन**

यह लेख Aspose.Slides for PHP via Java के साथ प्रेज़ेंटेशन टिप्पणी प्रबंधन को समझाता है। यह मुख्य टिप्पणी‑संबंधित प्रकारों का परिचय देता है और स्लाइड में टिप्पणी जोड़ने, मौजूदा टिप्पणी तक पहुँचने, प्रतिक्रियाओं और आधुनिक टिप्पणियों के साथ काम करने, तथा प्रेज़ेंटेशन से टिप्पणियों को हटाने का प्रदर्शन करता है।

उदाहरण PowerPoint में सामान्य समीक्षा और सहयोग परिदृश्यों को कवर करते हैं, जैसे टिप्पणी को लेखकों को सौंपना, टिप्पणी का पाठ और मेटाडेटा पढ़ना, उत्तर श्रृंखलाएँ बनाना, तथा चयनित टिप्पणियों या सभी टिप्पणियों को हटाना।

PowerPoint में, टिप्पणियाँ स्लाइड पर एनोटेशन के रूप में दिखाई देती हैं। किसी टिप्पणी का चयन करने से उसका पाठ और संबंधित चर्चा प्रदर्शित होती है।

जब प्रेज़ेंटेशन खुलता है, तब टिप्पणियों को दिखाने या छिपाने का अनुरोध करने के लिए, बिना स्वयं टिप्पणियों को बदले, देखें [प्रेज़ेंटेशन खोलते समय टिप्पणियों को दिखाएँ या छिपाएँ](/slides/hi/php-java/presentation-view-properties/)।

## **प्रेज़ेंटेशन में टिप्पणियाँ क्यों जोड़ें?**

आप प्रेज़ेंटेशन की समीक्षा करते समय प्रतिक्रिया देने और सहयोगियों के साथ मिलकर काम करने के लिए टिप्पणियों का उपयोग कर सकते हैं।

Aspose.Slides for PHP via Java टिप्पणी के साथ काम करने के लिए निम्नलिखित API प्रदान करता है:

* The [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) क्लास, जो प्रेज़ेंटेशन के टिप्पणी लेखकों तक पहुँच प्रदान करती है।
* The [CommentCollection](https://reference.aspose.com/slides/php-java/aspose.slides/commentcollection/) क्लास, जो एक व्यक्तिगत लेखक से जुड़ी टिप्पणियों का प्रतिनिधित्व करती है।
* The [Comment](https://reference.aspose.com/slides/php-java/aspose.slides/comment/) क्लास, जो टिप्पणी की जानकारी प्रदान करती है, जिसमें लेखक, निर्माण समय, स्थिति, और पाठ शामिल हैं।
* The [CommentAuthor](https://reference.aspose.com/slides/php-java/aspose.slides/commentauthor/) क्लास, जो एक लेखक की जानकारी प्रदान करती है, जिसमें उनका नाम, प्रारंभिक अक्षर, और संबंधित टिप्पणियाँ शामिल हैं।

## **स्लाइड टिप्पणियाँ जोड़ें**

उदाहरण दो स्लाइड बनाता है और [addAuthor](https://reference.aspose.com/slides/php-java/aspose.slides/commentauthorcollection/addauthor/) के साथ एक टिप्पणी लेखक पंजीकृत करता है। यह प्रत्येक स्लाइड पर एक टिप्पणी रखने के लिए [addComment](https://reference.aspose.com/slides/php-java/aspose.slides/commentcollection/addcomment/) का उपयोग करता है, फिर उस लेखक के लिए पहली स्लाइड की टिप्पणियाँ [getSlideComments](https://reference.aspose.com/slides/php-java/aspose.slides/slide/getslidecomments/) से प्राप्त करता है। कन्सोल पहली टिप्पणी का पाठ दो बार प्रदर्शित करता है, जो स्लाइड और लेखक दोनों के माध्यम से पहुँच को दर्शाता है, और संग्रहीत प्रेज़ेंटेशन में दोनों टिप्पणियाँ होती हैं।

```php
use aspose\slides\Point2DFloat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $firstSlide = $presentation->getSlides()->get_Item(0);
    $secondSlide = $presentation->getSlides()->addEmptySlide($presentation->getLayoutSlides()->get_Item(0));

    $author = $presentation->getCommentAuthors()->addAuthor("Jawad", "MF");
    $position = new Point2DFloat(0.2, 0.2);
    $createdTime = new Java("java.util.Date");

    $author->getComments()->addComment("Hello Jawad, this is a slide comment", $firstSlide, $position, $createdTime);
    $author->getComments()->addComment("Hello Jawad, this is the second slide comment", $secondSlide, $position, $createdTime);

    $comments = $firstSlide->getSlideComments($author);
    $arrayClass = new JavaClass("java.lang.reflect.Array");
    $commentCount = java_values($arrayClass->getLength($comments));
    if ($commentCount > 0) {
        $firstComment = $comments[0];
        echo java_values($firstComment->getText()) . PHP_EOL;

        $authorComments = $firstComment->getAuthor()->getComments();
        $commentText = $authorComments->get_Item(0)->getText();
        echo java_values($commentText) . PHP_EOL;
    }

    $presentation->save("Comments_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **टिप्पणी लेखक खोजें या बनाएं**

जब एक स्वचालित समीक्षा एक ही प्रेज़ेंटेशन को बार‑बार प्रोसेस करती है, तो लेखक जोड़ने से पहले [getCommentAuthors](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getcommentauthors/) द्वारा लौटाई गई संग्रह को खोजें। [findByNameAndInitials](https://reference.aspose.com/slides/php-java/aspose.slides/commentauthorcollection/findbynameandinitials/) नाम और प्रारंभिक दोनों से मेल खाता है और मिलते‑जुलते लेखकों का एक एरे लौटाता है, या यदि कोई मेल नहीं मिलता तो खाली एरे। इसके विपरीत, [findByName](https://reference.aspose.com/slides/php-java/aspose.slides/commentauthorcollection/findbyname/) केवल नाम से खोज करता है, प्रारंभिक को नजरअंदाज करते हुए। संग्रह में पहले से मौजूद नाम और प्रारंभिक के साथ [addAuthor](https://reference.aspose.com/slides/php-java/aspose.slides/commentauthorcollection/addauthor/) को कॉल करने से अपवाद उत्पन्न होता है।

उदाहरण के लिए एक प्रेज़ेंटेशन फ़ाइल आवश्यक है जिसमें कम से कम एक स्लाइड हो। दो पासों में प्रत्येक पर, यह पहले मेल खाने वाले लेखक को पुनः उपयोग करता है, या केवल परिणाम खाली होने पर नया बनाता है। यदि कई मिलते हैं, तो यह पहले एरे तत्व को चुनता है बिना अन्य लेखकों को मिलाए या हटाए। फिर यह चयनित लेखक के लिए [addComment](https://reference.aspose.com/slides/php-java/aspose.slides/commentcollection/addcomment/) को कॉल करता है और प्रेज़ेंटेशन को सहेजता है। दूसरा पास पहले पास के आउटपुट को खोलता है और ऑपरेशन को दोहराता है।

```php
use aspose\slides\Point2DFloat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$authorName = "Reviewer";
$authorInitials = "RV";

$inputFile = "input.pptx";
$position = new Point2DFloat(20, 20);
$arrayClass = new JavaClass("java.lang.reflect.Array");

for ($pass = 1; $pass <= 2; $pass++) {
    $presentation = new Presentation($inputFile);
    try {
        $matches = $presentation->getCommentAuthors()->findByNameAndInitials($authorName, $authorInitials);
        $matchCount = java_values($arrayClass->getLength($matches));

        $author = $matchCount > 0 ? $matches[0] : $presentation->getCommentAuthors()->addAuthor($authorName, $authorInitials);
        $createdTime = new Java("java.util.Date");
        $author->getComments()->addComment("Please review this slide.", $presentation->getSlides()->get_Item(0), $position, $createdTime);

        $outputFile = "review_pass_" . $pass . ".pptx";
        $presentation->save($outputFile, SaveFormat::Pptx);
        $inputFile = $outputFile;
    } finally {
        $presentation->dispose();
    }
}
```

दूसरा पास एक और टिप्पणी जोड़ता है बिना अतिरिक्त लेखक जोड़ें या मौजूदा टिप्पणियों को हटाए। अंतिम फ़ाइल, `review_pass_2.pptx`, दोनों नई टिप्पणियों को किसी भी मूल टिप्पणी के साथ रखती है। एक लेखक को पुनः उपयोग करने से टिप्पणियों की डुप्लिकेशन नहीं हटती: एक ही टिप्पणी को बार‑बार जोड़ने से बचने के लिए, उसे जोड़ने से पहले अलग डुप्लिकेट जाँच लागू करें।

## **स्लाइड टिप्पणियों तक पहुँचें**

उदाहरण एक मौजूदा प्रेज़ेंटेशन खोलता है और [getCommentAuthors](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getcommentauthors/) द्वारा लौटाए गए संग्रह को पढ़ता है। प्रत्येक लेखक के लिए, यह [getComments](https://reference.aspose.com/slides/php-java/aspose.slides/commentauthor/getcomments/) द्वारा लौटाए गए संग्रह में इटररेट करता है और स्लाइड संख्या, टिप्पणी पाठ, लेखक नाम, और निर्माण समय को प्रिंट करता है। इनपुट प्रेज़ेंटेशन में टिप्पणी होनी चाहिए ताकि कन्सोल आउटपुट उत्पन्न हो सके।

```php
use aspose\slides\Presentation;

$presentation = new Presentation("Comments1.pptx");
try {
    foreach ($presentation->getCommentAuthors() as $author) {
        foreach ($author->getComments() as $comment) {
            echo "Slide: " . java_values($comment->getSlide()->getSlideNumber()) . PHP_EOL;
            echo "Comment: " . java_values($comment->getText()) . PHP_EOL;
            echo "Author: " . java_values($comment->getAuthor()->getName()) . PHP_EOL;
            echo "Posted at: " . java_values($comment->getCreatedTime()->toString()) . PHP_EOL;
            echo PHP_EOL;
        }
    }
} finally {
    $presentation->dispose();
}
```

## **टिप्पणियों का उत्तर देना**

एक पैरेंट टिप्पणी वह मूल टिप्पणी है जो उत्तर पदानुक्रम के शीर्ष पर होती है। [Comment::getParentComment](https://reference.aspose.com/slides/php-java/aspose.slides/comment/getparentcomment/) और [Comment::setParentComment](https://reference.aspose.com/slides/php-java/aspose.slides/comment/setparentcomment/) मेथड आपको टिप्पणी के पैरेंट को प्राप्त या सेट करने की अनुमति देते हैं।

उदाहरण दो लेखकों की टिप्पणियाँ बनाता है और [setParentComment](https://reference.aspose.com/slides/php-java/aspose.slides/comment/setparentcomment/) का उपयोग करके उत्तर बनाता है, जिसमें किसी उत्तर का उत्तर भी शामिल है। `null` को [getSlideComments](https://reference.aspose.com/slides/php-java/aspose.slides/slide/getslidecomments/) में पास करने से सभी लेखकों की टिप्पणियाँ प्राप्त होती हैं; कन्सोल प्रत्येक प्रविष्टि को उसकी उत्तर पदानुक्रम में गहराई के अनुसार इंडेंट करता है। उदाहरण पूर्ण चर्चा को सहेजता है, पहले रूट टिप्पणी पर [remove](https://reference.aspose.com/slides/php-java/aspose.slides/comment/remove/) को कॉल करता है, और उस टिप्पणी तथा उसकी उत्तरों को हटाकर दूसरा प्रेज़ेंटेशन सहेजता है।

```php
use aspose\slides\Point2DFloat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $position = new Point2DFloat(10, 10);
    $createdTime = new Java("java.util.Date");

    $author1 = $presentation->getCommentAuthors()->addAuthor("Author_1", "A.A.");
    $comment1 = $author1->getComments()->addComment("comment 1", $slide, $position, $createdTime);

    $author2 = $presentation->getCommentAuthors()->addAuthor("Author_2", "B.B.");
    $reply1 = $author2->getComments()->addComment("reply 1 for comment 1", $slide, $position, $createdTime);
    $reply1->setParentComment($comment1);

    $reply2 = $author2->getComments()->addComment("reply 2 for comment 1", $slide, $position, $createdTime);
    $reply2->setParentComment($comment1);

    $subReply = $author1->getComments()->addComment("subreply 3 for reply 2", $slide, $position, $createdTime);
    $subReply->setParentComment($reply2);

    $author2->getComments()->addComment("comment 2", $slide, $position, $createdTime);
    $comment3 = $author2->getComments()->addComment("comment 3", $slide, $position, $createdTime);

    $reply3 = $author1->getComments()->addComment("reply 4 for comment 3", $slide, $position, $createdTime);
    $reply3->setParentComment($comment3);

    $comments = $slide->getSlideComments(null);
    $arrayClass = new JavaClass("java.lang.reflect.Array");
    $commentCount = java_values($arrayClass->getLength($comments));
    for ($i = 0; $i < $commentCount; $i++) {
        $comment = $comments[$i];
        while (!java_is_null($comment->getParentComment())) {
            echo "\t";
            $comment = $comment->getParentComment();
        }

        echo java_values($comments[$i]->getAuthor()->getName()) . ": " . java_values($comments[$i]->getText()) . PHP_EOL;
    }

    $presentation->save("parent_comment.pptx", SaveFormat::Pptx);

    $comment1->remove();
    $presentation->save("remove_comment.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

{{% alert color="warning" title="Warning" %}}
* जब [Comment::remove](https://reference.aspose.com/slides/php-java/aspose.slides/comment/remove/) मेथड का उपयोग टिप्पणी हटाने के लिए किया जाता है, तो उस टिप्पणी के सभी उत्तर भी हटाए जाते हैं।
* यदि [Comment::setParentComment](https://reference.aspose.com/slides/php-java/aspose.slides/comment/setparentcomment/) एक सर्कुलर रेफरेंस बनाता है, तो एक [PptxEditException](https://reference.aspose.com/slides/php-java/aspose.slides/pptxeditexception/) उत्पन्न होता है।
{{% /alert %}}

## **आधुनिक टिप्पणियाँ जोड़ें**

आधुनिक टिप्पणियाँ स्लाइड स्वयं, किसी विशिष्ट शेप, या AutoShape के भीतर टेक्स्ट रेंज से जुड़ी हो सकती हैं। [CommentCollection::addModernComment](https://reference.aspose.com/slides/php-java/aspose.slides/commentcollection/addmoderncomment/) मेथड स्लाइड और टिप्पणी‑मार्कर निर्देशांकों के अतिरिक्त एक [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) तर्क को स्वीकार करता है।

`null` को shape तर्क में पास करने पर, टिप्पणी स्लाइड‑स्तर की टिप्पणी बन जाती है। इसका मार्कर प्रदान किए गए निर्देशांकों द्वारा स्थित किया जाता है, लेकिन यह किसी विशिष्ट शेप से जुड़ी नहीं होती, इसलिए [ModernComment::getShape](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/getshape/) `null` लौटाता है। जब एक [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) प्रदान किया जाता है, तो टिप्पणी उस शेप से एँकर हो जाती है। निर्देशांक अभी भी स्लाइड पर टिप्पणी मार्कर की स्थिति को परिभाषित करते हैं, जबकि शेप असाइंमेंट को [ModernComment::getShape](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/getshape/) के माध्यम से प्राप्त किया जा सकता है।

### **एक शेप में आधुनिक टिप्पणी को एँकर करें**

उदाहरण दो बार [addModernComment](https://reference.aspose.com/slides/php-java/aspose.slides/commentcollection/addmoderncomment/) को कॉल करता है: एक बार स्लाइड‑स्तर टिप्पणी के लिए `null` shape के साथ और एक बार रेक्टैंगल को एँकर के रूप में। [getShape](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/getshape/) को पढ़ने से स्लाइड‑स्तर टिप्पणी के null चेक के लिए `true` और एँकर की टिप्पणी के लिए `Revenue title` प्रिंट होता है। दोनों टिप्पणियाँ प्रेज़ेंटेशन के साथ सहेजी जाती हैं।

```php
use aspose\slides\Point2DFloat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $author = $presentation->getCommentAuthors()->addAuthor("Reviewer", "RV");

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 300, 80);
    $shape->setName("Revenue title");
    $shape->getTextFrame()->setText("Quarterly revenue");

    $createdTime = new Java("java.util.Date");
    $slideCommentPosition = new Point2DFloat(20, 20);
    $shapeCommentPosition = new Point2DFloat(60, 60);
    $slideComment = $author->getComments()->addModernComment("Review the overall slide layout.", $slide, null, $slideCommentPosition, $createdTime);
    $shapeComment = $author->getComments()->addModernComment("Check this title.", $slide, $shape, $shapeCommentPosition, $createdTime);

    echo (java_is_null($slideComment->getShape()) ? "true" : "false") . PHP_EOL;
    echo java_values($shapeComment->getShape()->getName()) . PHP_EOL;

    $presentation->save("modern_comments.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **विभिन्न शेप प्रकारों में टिप्पणियों को एँकर करें**

[Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) क्लास द्वारा दर्शाए गए किसी भी स्लाइड ऑब्जेक्ट को शेप एँकर के रूप में उपयोग किया जा सकता है। सामान्य उदाहरणों में [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/), [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/), [GroupShape](https://reference.aspose.com/slides/php-java/aspose.slides/groupshape/), [Connector](https://reference.aspose.com/slides/php-java/aspose.slides/connector/), और चार्ट जैसे [GraphicalObject](https://reference.aspose.com/slides/php-java/aspose.slides/graphicalobject/) उदाहरण शामिल हैं।

उदाहरण [addModernComment](https://reference.aspose.com/slides/php-java/aspose.slides/commentcollection/addmoderncomment/) का उपयोग करके एक टिप्पणी को पाँच शैप प्रकारों से जोड़ता है: AutoShape, PictureFrame, GroupShape, Connector, और Chart। चित्र एम्बेडेड इमेज डेटा का उपयोग करता है, इसलिए किसी बाहरी इमेज की आवश्यकता नहीं है। प्रत्येक टिप्पणी का अपना मार्कर स्थान होता है, और सहेजा गया प्रेज़ेंटेशन सभी पाँच शैप एसोसिएशन को बनाए रखता है।

```php
use aspose\slides\ChartType;
use aspose\slides\Point2DFloat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $author = $presentation->getCommentAuthors()->addAuthor("Reviewer", "RV");
    $createdTime = new Java("java.util.Date");

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 180, 60);
    $autoShape->getTextFrame()->setText("AutoShape");

    $autoShapeCommentPosition = new Point2DFloat(30, 30);
    $author->getComments()->addModernComment("Comment on an AutoShape.", $slide, $autoShape, $autoShapeCommentPosition, $createdTime);

    $imageBase64 = "iVBORw0KGgoAAAANSUhEUgAAAAIAAAACCAIAAAD91JpzAAAAFklEQVR4nGP8//8/AwMDEwMDAwMDAwAkBgMB/DXemwAAAABJRU5ErkJggg==";
    $base64Class = new JavaClass("java.util.Base64");
    $imageData = $base64Class->getDecoder()->decode($imageBase64);
    $image = $presentation->getImages()->addImage($imageData);
    $pictureFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 220, 20, 120, 80, $image);
    $pictureCommentPosition = new Point2DFloat(230, 30);
    $author->getComments()->addModernComment("Comment on a picture.", $slide, $pictureFrame, $pictureCommentPosition, $createdTime);

    $groupShape = $slide->getShapes()->addGroupShape();
    $groupShape->getShapes()->addAutoShape(ShapeType::Rectangle, 0, 0, 80, 40);
    $groupShape->getShapes()->addAutoShape(ShapeType::Ellipse, 100, 0, 80, 40);
    $groupCommentPosition = new Point2DFloat(40, 150);
    $author->getComments()->addModernComment("Comment on a group.", $slide, $groupShape, $groupCommentPosition, $createdTime);

    $connector = $slide->getShapes()->addConnector(ShapeType::StraightConnector1, 220, 150, 140, 40);
    $connectorCommentPosition = new Point2DFloat(240, 150);
    $author->getComments()->addModernComment("Comment on a connector.", $slide, $connector, $connectorCommentPosition, $createdTime);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 400, 20, 250, 180);
    $chartCommentPosition = new Point2DFloat(420, 40);
    $author->getComments()->addModernComment("Comment on a graphical object.", $slide, $chart, $chartCommentPosition, $createdTime);

    $presentation->save("modern_comment_shape_types.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **टिप्पणी को टेक्स्ट से एँकर करें और उसकी स्थिति सेट करें**

एक [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) से जुड़ी आधुनिक टिप्पणी के लिए, [ModernComment::getTextSelectionStart](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/gettextselectionstart/) और [ModernComment::setTextSelectionStart](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/settextselectionstart/) शेप के टेक्स्ट फ्रेम में चयनित टेक्स्ट की शुरुआती स्थिति तक पहुँच प्रदान करते हैं। [ModernComment::getTextSelectionLength](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/gettextselectionlength/) और [ModernComment::setTextSelectionLength](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/settextselectionlength/) चयन की लंबाई तक पहुँचते हैं। मिलकर, ये मान टिप्पणी को AutoShape के भीतर एक विशिष्ट टेक्स्ट रेंज से जोड़ते हैं।

[ModernComment::getStatus](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/getstatus/) और [ModernComment::setStatus](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/setstatus/) मेथड [ModernCommentStatus](https://reference.aspose.com/slides/php-java/aspose.slides/moderncommentstatus/) कॉन्स्टेंट्स से एक मान प्राप्त करते हैं:

- `NotDefined` — कोई विशिष्ट आधुनिक‑टिप्पणी स्थिति परिभाषित नहीं है।
- `Active` — टिप्पणी सक्रिय है।
- `Resolved` — टिप्पणी को हल किया गया है।
- `Closed` — टिप्पणी बंद है।

उदाहरण एक रेक्टैंगल के टेक्स्ट में "quarterly revenue" शब्दों से एक आधुनिक टिप्पणी को एँकर करता है। यह टेक्स्ट से शून्य‑आधारित चयन प्रारंभ की गणना करता है और इसे [setTextSelectionStart](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/settextselectionstart/) को पास करता है तथा चयनित अक्षरों की संख्या सेट करने के लिए [setTextSelectionLength](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/settextselectionlength/) का उपयोग करता है। `Resolved` के साथ [setStatus](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/setstatus/) को कॉल करने के बाद, यह प्रेज़ेंटेशन को सहेजता और पुनः खोलता है। चार कन्सोल जांचें प्रत्येक `true` प्रिंट करनी चाहिए, जिससे पुष्टि होती है कि शेप एँकर, टेक्स्ट रेंज, और स्थिति संरक्षित रही।

```php
use aspose\slides\ModernCommentStatus;
use aspose\slides\Point2DFloat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$outputFile = "modern_comment_text_anchor.pptx";
$shapeText = "Review the quarterly revenue forecast.";
$selectedText = "quarterly revenue";
$expectedSelectionStart = strpos($shapeText, $selectedText);

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 400, 100);
    $shape->setName("Forecast text");
    $shape->getTextFrame()->setText($shapeText);

    $author = $presentation->getCommentAuthors()->addAuthor("Reviewer", "RV");
    $commentPosition = new Point2DFloat(60, 60);
    $comment = $author->getComments()->addModernComment("Verify this forecast wording.", $slide, $shape, $commentPosition, new Java("java.util.Date"));
    $comment->setTextSelectionStart($expectedSelectionStart);
    $comment->setTextSelectionLength(strlen($selectedText));
    $comment->setStatus(ModernCommentStatus::Resolved);

    $presentation->save($outputFile, SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}

$reopenedPresentation = new Presentation($outputFile);
try {
    $reopenedSlide = $reopenedPresentation->getSlides()->get_Item(0);
    $reopenedComments = $reopenedSlide->getSlideComments(null);
    $modernCommentClass = new JavaClass("com.aspose.slides.ModernComment");

    foreach ($reopenedComments as $reopenedComment) {
        if (!java_instanceof($reopenedComment, $modernCommentClass)) {
            continue;
        }

        $shape = $reopenedComment->getShape();
        $shapeMatches = !java_is_null($shape) && java_values($shape->getName()) === "Forecast text";
        $selectionStartMatches = java_values($reopenedComment->getTextSelectionStart()) === $expectedSelectionStart;
        $selectionLengthMatches = java_values($reopenedComment->getTextSelectionLength()) === strlen($selectedText);
        $statusMatches = java_values($reopenedComment->getStatus()) === ModernCommentStatus::Resolved;

        echo "Shape anchor preserved: " . ($shapeMatches ? "true" : "false") . PHP_EOL;
        echo "Text selection start preserved: " . ($selectionStartMatches ? "true" : "false") . PHP_EOL;
        echo "Text selection length preserved: " . ($selectionLengthMatches ? "true" : "false") . PHP_EOL;
        echo "Resolved status preserved: " . ($statusMatches ? "true" : "false") . PHP_EOL;
    }
} finally {
    $reopenedPresentation->dispose();
}
```

### **मौजूदा आधुनिक टिप्पणियों का निरीक्षण करें**

उदाहरण को आधुनिक टिप्पणियों वाली मौजूदा प्रेज़ेंटेशन की आवश्यकता होती है और वे उनका टेक्स्ट, स्थिति, और एँकर विवरण प्रिंट करता है। निरीक्षण के लिए, जांचें कि प्रत्येक टिप्पणी [ModernComment](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/) है या नहीं, फिर [ModernComment::getShape](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/getshape/), [ModernComment::getTextSelectionStart](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/gettextselectionstart/), [ModernComment::getTextSelectionLength](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/gettextselectionlength/), और [ModernComment::getStatus](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/getstatus/) को देखें। `null` शेप स्लाइड‑स्तर टिप्पणी को दर्शाता है। एक [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) एँकर के लिए, टेक्स्ट‑सेलेक्शन मेथड शेप के टेक्स्ट फ्रेम में संबंधित रेंज की पहचान करते हैं।

```php
use aspose\slides\Presentation;

$presentation = new Presentation("comments.pptx");
try {
    $modernCommentClass = new JavaClass("com.aspose.slides.ModernComment");
    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");

    foreach ($presentation->getSlides() as $slide) {
        $comments = $slide->getSlideComments(null);
        foreach ($comments as $comment) {
            if (!java_instanceof($comment, $modernCommentClass)) {
                continue;
            }

            echo "Slide: " . java_values($slide->getSlideNumber()) . PHP_EOL;
            echo "Text: " . java_values($comment->getText()) . PHP_EOL;
            echo "Status: " . java_values($comment->getStatus()) . PHP_EOL;

            $shape = $comment->getShape();
            if (java_is_null($shape)) {
                echo "Anchor: slide level" . PHP_EOL;
            } else {
                echo "Anchor shape: " . java_values($shape->getName()) . PHP_EOL;
                echo "Anchor type: " . java_values($shape->getClass()->getSimpleName()) . PHP_EOL;

                if (java_instanceof($shape, $autoShapeClass)) {
                    echo "Text selection start: " . java_values($comment->getTextSelectionStart()) . PHP_EOL;
                    echo "Text selection length: " . java_values($comment->getTextSelectionLength()) . PHP_EOL;
                }
            }

            echo PHP_EOL;
        }
    }
} finally {
    $presentation->dispose();
}
```

## **टिप्पणियाँ हटाएँ**

Aspose.Slides for PHP via Java आपको एक प्रेज़ेंटेशन से सभी टिप्पणियाँ और उनके लेखकों को हटाने या चयनित टिप्पणियों को बाकी को रखकर डिलीट करने की सुविधा देता है। नीचे दिए गए उदाहरण दोनों दृष्टिकोण दर्शाते हैं और अद्यतन प्रेज़ेंटेशन को सहेजते हैं।

### **सभी टिप्पणियों और टिप्पणी लेखकों को हटाएँ**

उदाहरण एक मौजूदा प्रेज़ेंटेशन खोलता है और प्रत्येक लेखक के लिए [CommentCollection::clear](https://reference.aspose.com/slides/php-java/aspose.slides/commentcollection/clear/) को कॉल करता है, फिर लेखकों को स्वयं हटाने के लिए [CommentAuthorCollection::clear](https://reference.aspose.com/slides/php-java/aspose.slides/commentauthorcollection/clear/) को कॉल करता है। सहेजा गया प्रेज़ेंटेशन न तो टिप्पणियाँ और न ही टिप्पणी लेखक रखता है। हटाव को देखने के लिए टिप्पणी वाली प्रेज़ेंटेशन का उपयोग करें।

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("example.pptx");
try {
    foreach ($presentation->getCommentAuthors() as $author) {
        $author->getComments()->clear();
    }

    $presentation->getCommentAuthors()->clear();

    $presentation->save("example_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **विशिष्ट टिप्पणियों को हटाएँ**

उदाहरण एक स्लाइड पर दो टिप्पणी बनाता है और प्रत्येक लेखक की टिप्पणियों को खोजने के लिए [getSlideComments](https://reference.aspose.com/slides/php-java/aspose.slides/slide/getslidecomments/) का उपयोग करता है। यह "comment 1" पाठ वाली टिप्पणियों को [CommentCollection::remove](https://reference.aspose.com/slides/php-java/aspose.slides/commentcollection/remove/) को कॉल करने से पहले इकट्ठा करता है, ताकि चयन के दौरान संग्रह में बदलाव न हों। सहेजा गया प्रेज़ेंटेशन केवल "comment 2" को रखता है।

```php
use aspose\slides\Point2DFloat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $author = $presentation->getCommentAuthors()->addAuthor("Author", "A");
    $createdTime = new Java("java.util.Date");

    $firstCommentPosition = new Point2DFloat(0.2, 0.2);
    $secondCommentPosition = new Point2DFloat(0.3, 0.2);
    $author->getComments()->addComment("comment 1", $slide, $firstCommentPosition, $createdTime);
    $author->getComments()->addComment("comment 2", $slide, $secondCommentPosition, $createdTime);

    foreach ($presentation->getCommentAuthors() as $commentAuthor) {
        $commentsToRemove = new Java("java.util.ArrayList");
        $comments = $slide->getSlideComments($commentAuthor);

        foreach ($comments as $comment) {
            if ($comment->getText()->equals("comment 1")) {
                $commentsToRemove->add($comment);
            }
        }

        foreach ($commentsToRemove as $comment) {
            $commentAuthor->getComments()->remove($comment);
        }
    }

    $presentation->save("pres.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**क्या Aspose.Slides आधुनिक टिप्पणियों के लिए Resolved स्थिति का समर्थन करता है?**  
हाँ। [ModernComment::getStatus](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/getstatus/) और [ModernComment::setStatus](https://reference.aspose.com/slides/php-java/aspose.slides/moderncomment/setstatus/) एक [ModernCommentStatus](https://reference.aspose.com/slides/php-java/aspose.slides/moderncommentstatus/) मान तक पहुँचते हैं, जिसमें `Resolved` शामिल है। यह स्थिति प्रेज़ेंटेशन में संग्रहीत रहती है और फ़ाइल पुनः खोलने के बाद फिर से पढ़ी जा सकती है।

**क्या थ्रेडेड चर्चाएँ (उत्तर श्रृंखलाएँ) समर्थित हैं, और क्या कोई नेस्टिंग सीमा है?**  
हाँ। प्रत्येक टिप्पणी अपने [parent comment](https://reference.aspose.com/slides/php-java/aspose.slides/comment/getparentcomment/) को संदर्भित कर सकता है, जिससे उत्तर श्रृंखलाएँ संभव होती हैं। API कोई विशिष्ट नेस्टिंग‑गहराई सीमा निर्दिष्ट नहीं करता।

**स्लाइड पर टिप्पणी मार्कर की स्थिति किस कॉर्डिनेट सिस्टम में परिभाषित है?**  
मार्कर की स्थिति स्लाइड कॉर्डिनेट सिस्टम में फ्लोटिंग‑पॉइंट निर्देशांकों द्वारा परिभाषित होती है, जिससे आप इसे स्लाइड पर सटीक रूप से रख सकते हैं।