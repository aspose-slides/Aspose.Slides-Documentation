---
title: PHP में प्रस्तुति टिप्पणियों को प्रबंधित करें
linktitle: प्रस्तुति टिप्पणियाँ
type: docs
weight: 100
url: /hi/php-java/presentation-comments/
keywords:
- टिप्पणी
- आधुनिक टिप्पणी
- PowerPoint टिप्पणियां
- प्रस्तुति टिप्पणियां
- स्लाइड टिप्पणियां
- टिप्पणी जोड़ें
- टिप्पणी तक पहुंचें
- टिप्पणी संपादित करें
- टिप्पणी का उत्तर दें
- टिप्पणी हटाएँ
- टिप्पणी मिटाएँ
- PowerPoint
- प्रस्तुति
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java के साथ प्रस्तुति टिप्पणियों को प्रबंधित करें: PowerPoint प्रस्तुतियों में टिप्पणियों को जल्दी और आसानी से जोड़ें, पढ़ें, संपादित करें, उत्तर दें और हटाएँ।"
---
## **अवलोकन**

यह लेख Aspose.Slides for PHP via Java के साथ प्रस्तुति टिप्पणी प्रबंधन के तरीके को समझाता है। यह मुख्य टिप्पणी‑संबंधी प्रकारों का परिचय देता है और स्लाइड्स में टिप्पणियाँ जोड़ना, मौजूदा टिप्पणियों तक पहुंचना, उत्तरों और आधुनिक टिप्पणियों के साथ काम करना, तथा प्रस्तुति से टिप्पणियाँ हटाना दर्शाता है।

उदाहरण सामान्य समीक्षात्मक और सहयोगात्मक परिदृश्यों को कवर करते हैं, जैसे कि लेखकों को टिप्पणियाँ असाइन करना, टिप्पणी पाठ और मेटाडेटा पढ़ना, उत्तर श्रृंखलाएं बनाना, तथा चयनित टिप्पणियों या सभी टिप्पणियों को हटाना।

PowerPoint में, टिप्पणियाँ स्लाइड्स पर एनोटेशन के रूप में दिखाई देती हैं। किसी टिप्पणी का चयन करने पर उसका पाठ और संबंधित चर्चा प्रदर्शित होती है।

प्रेजेंटेशन खोलते समय टिप्पणियों को दिखाने या छिपाने का अनुरोध करने के लिए, बिना स्वयं टिप्पणियों को बदले, देखें [प्रेजेंटेशन खोलते समय टिप्पणियों को दिखाने या छिपाने का अनुरोध](/slides/hi/php-java/presentation-view-properties/)।

## **प्रेजेंटेशनों में टिप्पणियाँ क्यों जोड़ें?**

आप समीक्षण के दौरान प्रस्तुतियों की प्रतिक्रिया देने और सहयोगियों के साथ मिलकर काम करने के लिए टिप्पणियों का उपयोग कर सकते हैं।

Aspose.Slides for PHP via Java टिप्पणियों के साथ काम करने के लिए निम्नलिखित API प्रदान करता है:

* The [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) class, which provides access to the presentation's comment authors.
* The [CommentCollection](https://reference.aspose.com/slides/hi/php-java/aspose.slides/commentcollection/) class, which represents the comments associated with an individual author.
* The [Comment](https://reference.aspose.com/slides/hi/php-java/aspose.slides/comment/) class, which provides information about a comment, including its author, creation time, position, and text.
* The [CommentAuthor](https://reference.aspose.com/slides/hi/php-java/aspose.slides/commentauthor/) class, which provides information about an author, including their name, initials, and associated comments.

## **स्लाइड टिप्पणियाँ जोड़ें**

नीचे दिया गया उदाहरण PowerPoint प्रस्तुति में स्लाइड्स पर टिप्पणियाँ जोड़ने का तरीका दर्शाता है:

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

## **स्लाइड टिप्पणियों तक पहुंचें**

नीचे दिया गया उदाहरण PowerPoint प्रस्तुति में मौजूदा टिप्पणियों तक पहुंचने का तरीका दर्शाता है:

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

एक पैरेंट टिप्पणी उत्तर पदानुक्रम के शीर्ष पर मूल टिप्पणी होती है। The [Comment::getParentComment](https://reference.aspose.com/slides/hi/php-java/aspose.slides/comment/getparentcomment/) and [Comment::setParentComment](https://reference.aspose.com/slides/hi/php-java/aspose.slides/comment/setparentcomment/) methods let you get or set the parent of a comment.

नीचे दिया गया उदाहरण उत्तर जोड़ने और परिणामी टिप्पणी पदानुक्रम को निरीक्षण करने का तरीका दर्शाता है:

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
* जब [Comment::remove](https://reference.aspose.com/slides/hi/php-java/aspose.slides/comment/remove/) method का उपयोग करके कोई टिप्पणी हटाई जाती है, तो उस टिप्पणी के सभी उत्तर भी हटाए जाते हैं।
* यदि [Comment::setParentComment](https://reference.aspose.com/slides/hi/php-java/aspose.slides/comment/setparentcomment/) एक चक्राकार संदर्भ बनाता है, तो एक [PptxEditException](https://reference.aspose.com/slides/hi/php-java/aspose.slides/pptxeditexception/) उत्पन्न होता है।
{{% /alert %}}

## **आधुनिक टिप्पणियाँ जोड़ें**

आधुनिक टिप्पणियों को स्लाइड स्वयं, किसी विशिष्ट आकार, या AutoShape के भीतर एक टेक्स्ट रेंज से जोड़ा जा सकता है। The [CommentCollection::addModernComment](https://reference.aspose.com/slides/hi/php-java/aspose.slides/commentcollection/addmoderncomment/) method accepts a [Shape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shape/) argument in addition to the slide and comment‑marker coordinates.

जब `null` को shape तर्क के रूप में पास किया जाता है, तो टिप्पणी स्लाइड‑स्तर की होती है। इसका मार्कर प्रदान किए गए निर्देशांक द्वारा स्थित होता है, लेकिन यह किसी विशेष आकार से जुड़ी नहीं होती, इसलिए [ModernComment::getShape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/moderncomment/getshape/) `null` लौटाता है। जब एक [Shape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shape/) प्रदान किया जाता है, तो टिप्पणी उस आकार से जुड़ी होती है। निर्देशांक फिर भी स्लाइड पर टिप्पणी मार्कर की स्थिति निर्धारित करते हैं, जबकि आकार का संबंध [ModernComment::getShape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/moderncomment/getshape/) के माध्यम से प्राप्त किया जा सकता है।

### **आधुनिक टिप्पणी को आकार से जोड़ें**

नीचे दिया गया उदाहरण एक स्लाइड‑स्तर की आधुनिक टिप्पणी और एक विशिष्ट AutoShape से जुड़ी आधुनिक टिप्पणी दोनों बनाता है। फिर यह प्रत्येक टिप्पणी से संबंधित आकार को पढ़ता है।

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

### **टिप्पणियों को विभिन्न आकार प्रकारों से जोड़ें**

[Shape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shape/) क्लास द्वारा प्रतिनिधित्व किए गए किसी भी स्लाइड ऑब्जेक्ट को आकार एंकर के रूप में उपयोग किया जा सकता है। सामान्य उदाहरणों में [AutoShape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/autoshape/), [PictureFrame](https://reference.aspose.com/slides/hi/php-java/aspose.slides/pictureframe/), [GroupShape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/groupshape/), [Connector](https://reference.aspose.com/slides/hi/php-java/aspose.slides/connector/), और [GraphicalObject](https://reference.aspose.com/slides/hi/php-java/aspose.slides/graphicalobject/) जैसे चार्ट शामिल हैं।

नीचे दिया गया उदाहरण कई सामान्य आकार प्रकार बनाता है और प्रत्येक के साथ एक आधुनिक टिप्पणी संलग्न करता है।

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

### **टिप्पणी को टेक्स्ट से जोड़ें और उसकी स्थिति सेट करें**

एक AutoShape से जुड़ी आधुनिक टिप्पणी के लिए, [ModernComment::getTextSelectionStart](https://reference.aspose.com/slides/hi/php-java/aspose.slides/moderncomment/gettextselectionstart/) और [ModernComment::setTextSelectionStart](https://reference.aspose.com/slides/hi/php-java/aspose.slides/moderncomment/settextselectionstart/) shape के टेक्स्ट फ्रेम में चयनित टेक्स्ट की प्रारम्भिक स्थिति तक पहुंचते हैं। [ModernComment::getTextSelectionLength](https://reference.aspose.com/slides/hi/php-java/aspose.slides/moderncomment/gettextselectionlength/) और [ModernComment::setTextSelectionLength](https://reference.aspose.com/slides/hi/php-java/aspose.slides/moderncomment/settextselectionlength/) चयन की लंबाई तक पहुंचते हैं। इन मानों को मिलाकर टिप्पणी को AutoShape के भीतर एक विशिष्ट टेक्स्ट रेंज से जोड़ा जाता है।

[ModernComment::getStatus](https://reference.aspose.com/slides/hi/php-java/aspose.slides/moderncomment/getstatus/) और [ModernComment::setStatus](https://reference.aspose.com/slides/hi/php-java/aspose.slides/moderncomment/setstatus/) methods [ModernCommentStatus](https://reference.aspose.com/slides/hi/php-java/aspose.slides/moderncommentstatus/) स्थिरांक से एक मान प्राप्त करते हैं:

- `NotDefined` — कोई विशिष्ट आधुनिक‑टिप्पणी स्थिति परिभाषित नहीं है।
- `Active` — टिप्पणी सक्रिय है।
- `Resolved` — टिप्पणी हल हो गई है।
- `Closed` — टिप्पणी बंद है।

नीचे दिया गया उदाहरण एक आकार‑एंकर वाली आधुनिक टिप्पणी बनाता है, उसे टेक्स्ट चयन से जोड़ता है, उसे हल की हुई चिह्नित करता है, प्रस्तुति सहेजता है, और फ़ाइल को पुनः खोलने के बाद मानों की पुष्टि करता है।

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

### **मौजूदा आधुनिक टिप्पणियों की जांच करें**

किसी मौजूदा प्रस्तुति का निरीक्षण करने के लिए, पहले जाँचें कि प्रत्येक टिप्पणी [ModernComment](https://reference.aspose.com/slides/hi/php-java/aspose.slides/moderncomment/) है या नहीं, फिर [ModernComment::getShape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/moderncomment/getshape/), [ModernComment::getTextSelectionStart](https://reference.aspose.com/slides/hi/php-java/aspose.slides/moderncomment/gettextselectionstart/), [ModernComment::getTextSelectionLength](https://reference.aspose.com/slides/hi/php-java/aspose.slides/moderncomment/gettextselectionlength/), और [ModernComment::getStatus](https://reference.aspose.com/slides/hi/php-java/aspose.slides/moderncomment/getstatus/) का निरीक्षण करें। `null` आकार का अर्थ है स्लाइड‑स्तर की टिप्पणी। एक [AutoShape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/autoshape/) एंकर के लिए, टेक्स्ट‑सेलेक्शन मेथड्स आकार के टेक्स्ट फ्रेम में संबंधित रेंज की पहचान करते हैं।

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

### **सभी टिप्पणियाँ और टिप्पणी लेखकों को हटाएँ**

नीचे दिया गया उदाहरण प्रस्तुति से सभी टिप्पणियाँ और टिप्पणी लेखकों को हटाने का तरीका दर्शाता है:

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

नीचे दिया गया उदाहरण स्लाइड से विशिष्ट टिप्पणियों को हटाने का तरीका दर्शाता है:

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

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या Aspose.Slides आधुनिक टिप्पणियों के लिए हल की हुई स्थिति का समर्थन करता है?**

हाँ। [ModernComment::getStatus](https://reference.aspose.com/slides/hi/php-java/aspose.slides/moderncomment/getstatus/) और [ModernComment::setStatus](https://reference.aspose.com/slides/hi/php-java/aspose.slides/moderncomment/setstatus/) [ModernCommentStatus](https://reference.aspose.com/slides/hi/php-java/aspose.slides/moderncommentstatus/) मूल्य तक पहुंचते हैं, जिसमें `Resolved` भी शामिल है। स्थिति प्रस्तुति में संग्रहीत रहती है और फ़ाइल को पुनः खोलने के बाद फिर से पढ़ी जा सकती है।

**क्या धागा‑बद्ध चर्चाएँ (उत्तर श्रृंखलाएँ) समर्थित हैं, और क्या कोई नेस्टिंग सीमा है?**

हाँ। प्रत्येक टिप्पणी अपने [parent comment](https://reference.aspose.com/slides/hi/php-java/aspose.slides/comment/getparentcomment/) को संदर्भित कर सकती है, जिससे उत्तर श्रृंखलाएँ बनती हैं। API में कोई विशिष्ट नेस्टिंग‑गहराई सीमा परिभाषित नहीं है।

**किस समन्वय प्रणाली में स्लाइड पर टिप्पणी मार्कर की स्थिति निर्धारित होती है?**

मार्कर स्थिति स्लाइड कोऑर्डिनेट सिस्टम में फ्लोटिंग‑पॉइंट समन्वयों द्वारा निर्धारित होती है, जिससे आप इसे स्लाइड पर सटीक रूप से रख सकते हैं।