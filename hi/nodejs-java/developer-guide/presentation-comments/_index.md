---
title: Node.js में प्रस्तुति टिप्पणियों का प्रबंधन
linktitle: प्रस्तुति टिप्पणियाँ
type: docs
weight: 100
url: /hi/nodejs-java/presentation-comments/
keywords:
- टिप्पणी
- आधुनिक टिप्पणी
- PowerPoint टिप्पणियाँ
- प्रस्तुति टिप्पणियाँ
- स्लाइड टिप्पणियाँ
- टिप्पणी जोड़ें
- टिप्पणी तक पहुँचें
- टिप्पणी संपादित करें
- टिप्पणी का उत्तर दें
- टिप्पणी हटाएँ
- टिप्पणी मिटाएँ
- PowerPoint
- प्रस्तुति
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java के साथ प्रस्तुति टिप्पणियों का प्रबंधन: PowerPoint प्रस्तुतियों में टिप्पणियाँ जोड़ें, पढ़ें, संपादित करें, उत्तर दें और हटाएँ।"
---
## **परिचय**

यह लेख Aspose.Slides for Node.js via Java के साथ प्रेज़ेंटेशन टिप्पणियों को प्रबंधित करने का तरीका समझाता है। यह मुख्य टिप्पणी-से सम्बंधित प्रकारों का परिचय कराता है और दर्शाता है कि स्लाइड्स में टिप्पणियाँ कैसे जोड़ी जाएँ, मौजूदा टिप्पणियों तक कैसे पहुँचें, उत्तरों और आधुनिक टिप्पणियों के साथ कैसे काम करें, और प्रेज़ेंटेशन से टिप्पणियाँ कैसे हटाएँ।

उदाहरण PowerPoint में सामान्य समीक्षा और सहयोग परिदृश्यों को कवर करते हैं, जैसे लेखकों को टिप्पणियाँ असाइन करना, टिप्पणी का पाठ और मेटाडेटा पढ़ना, उत्तर श्रृंखलाएँ बनाना, और चयनित टिप्पणियों या सभी टिप्पणियों को हटाना।

PowerPoint में, टिप्पणियाँ स्लाइड्स पर एनोटेशन के रूप में प्रदर्शित होती हैं। किसी टिप्पणी का चयन करने पर उसका पाठ और संबंधित चर्चा दिखती है।

## **प्रेज़ेंटेशन में टिप्पणियाँ क्यों जोड़ें?**

आप प्रेज़ेंटेशन की समीक्षा करते समय फ़ीडबैक देने और सहयोगियों के साथ सहयोग करने के लिए टिप्पणियों का उपयोग कर सकते हैं।

Aspose.Slides for Node.js via Java टिप्पणियों के साथ काम करने के लिए निम्नलिखित API प्रदान करता है:

* The [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/) class, जो प्रस्तुति के टिप्पणी लेखकों तक पहुँच प्रदान करती है।
* The [CommentCollection](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/commentcollection/) class, जो एक व्यक्तिगत लेखक से जुड़ी टिप्पणियों का प्रतिनिधित्व करती है।
* The [Comment](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/comment/) class, जो एक टिप्पणी के बारे में जानकारी प्रदान करती है, जिसमें लेखक, निर्माण समय, स्थिति और पाठ शामिल है।
* The [CommentAuthor](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/commentauthor/) class, जो एक लेखक के बारे में जानकारी प्रदान करती है, जिसमें उनका नाम, प्रारम्भिक अक्षर और जुड़ी टिप्पणियाँ शामिल हैं।

## **स्लाइड टिप्पणियाँ जोड़ें**

निम्नलिखित उदाहरण दिखाता है कि PowerPoint प्रस्तुति में स्लाइड्स में टिप्पणियाँ कैसे जोड़ी जाती हैं:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const firstSlide = presentation.getSlides().get_Item(0);
    const secondSlide = presentation.getSlides().addEmptySlide(presentation.getLayoutSlides().get_Item(0));
    const author = presentation.getCommentAuthors().addAuthor("Jawad", "MF");
    const position = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(0.2), java.newFloat(0.2));
    const createdTime = java.newInstanceSync("java.util.Date");

    author.getComments().addComment("Hello Jawad, this is a slide comment", firstSlide, position, createdTime);
    author.getComments().addComment("Hello Jawad, this is the second slide comment", secondSlide, position, createdTime);

    const comments = firstSlide.getSlideComments(author);
    if (comments.length > 0) {
        const firstComment = comments[0];
        console.log(firstComment.getText());

        const authorComments = firstComment.getAuthor().getComments();
        const commentText = authorComments.get_Item(0).getText();
        console.log(commentText);
    }

    presentation.save("Comments_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **स्लाइड टिप्पणियों तक पहुँचें**

निम्नलिखित उदाहरण दिखाता है कि PowerPoint प्रस्तुति में मौजूदा टिप्पणियों तक कैसे पहुँचें:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("Comments1.pptx");
try {
    const authors = presentation.getCommentAuthors();
    for (let authorIndex = 0; authorIndex < authors.size(); authorIndex++) {
        const author = authors.get_Item(authorIndex);
        const comments = author.getComments();

        for (let commentIndex = 0; commentIndex < comments.size(); commentIndex++) {
            const comment = comments.get_Item(commentIndex);
            console.log("Slide: " + comment.getSlide().getSlideNumber());
            console.log("Comment: " + comment.getText());
            console.log("Author: " + comment.getAuthor().getName());
            console.log("Posted at: " + comment.getCreatedTime());
            console.log();
        }
    }
} finally {
    presentation.dispose();
}
```

## **टिप्पणियों का उत्तर देना**

एक पैरेंट टिप्पणी उत्तर पदानुक्रम के शीर्ष पर मूल टिप्पणी होती है। [Comment.getParentComment](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/comment/getparentcomment/) और [Comment.setParentComment](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/comment/setparentcomment/) मेथड आपको टिप्पणी के पैरेंट को प्राप्त या सेट करने की अनुमति देते हैं।

निम्नलिखित उदाहरण दिखाता है कि उत्तर कैसे जोड़ें और परिणामी टिप्पणी पदानुक्रम का निरीक्षण कैसे करें:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const position = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10));
    const createdTime = java.newInstanceSync("java.util.Date");

    const author1 = presentation.getCommentAuthors().addAuthor("Author_1", "A.A.");
    const comment1 = author1.getComments().addComment("comment 1", slide, position, createdTime);

    const author2 = presentation.getCommentAuthors().addAuthor("Author_2", "B.B.");
    const reply1 = author2.getComments().addComment("reply 1 for comment 1", slide, position, createdTime);
    reply1.setParentComment(comment1);

    const reply2 = author2.getComments().addComment("reply 2 for comment 1", slide, position, createdTime);
    reply2.setParentComment(comment1);

    const subReply = author1.getComments().addComment("subreply 3 for reply 2", slide, position, createdTime);
    subReply.setParentComment(reply2);

    author2.getComments().addComment("comment 2", slide, position, createdTime);
    const comment3 = author2.getComments().addComment("comment 3", slide, position, createdTime);

    const reply3 = author1.getComments().addComment("reply 4 for comment 3", slide, position, createdTime);
    reply3.setParentComment(comment3);

    const comments = slide.getSlideComments(null);
    for (let index = 0; index < comments.length; index++) {
        let comment = comments[index];
        let indentation = "";
        while (comment.getParentComment() != null) {
            indentation += "\t";
            comment = comment.getParentComment();
        }

        console.log(indentation + comments[index].getAuthor().getName() + ": " + comments[index].getText());
    }

    presentation.save("parent_comment.pptx", aspose.slides.SaveFormat.Pptx);

    comment1.remove();
    presentation.save("remove_comment.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert color="warning" title="Warning" %}}
* जब [Comment.remove](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/comment/remove/) मेथड का उपयोग करके कोई टिप्पणी हटाई जाती है, तो उस टिप्पणी के सभी उत्तर भी हटा दिए जाते हैं।
* यदि [Comment.setParentComment](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/comment/setparentcomment/) एक सर्कुलर रेफ़रेंस बनाता है, तो एक [PptxEditException](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/pptxeditexception/) फेंका जाता है।
{{% /alert %}}

## **आधुनिक टिप्पणियाँ जोड़ें**

आधुनिक टिप्पणियों को स्लाइड स्वयं, किसी विशिष्ट शैप, या किसी [AutoShape](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/autoshape/) के अंदर टेक्स्ट रेंज के साथ जोड़ा जा सकता है। [CommentCollection.addModernComment](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/commentcollection/addmoderncomment/) मेथड स्लाइड और टिप्पणी-मार्कर निर्देशांकों के अतिरिक्त एक [Shape](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/shape/) आर्ग्यूमेंट स्वीकार करता है।

जब शैप आर्ग्यूमेंट के लिए `null` पास किया जाता है, तो टिप्पणी स्लाइड-स्तरीय टिप्पणी होती है। उसका मार्कर प्रदान किए गए निर्देशांकों द्वारा स्थित किया जाता है, लेकिन यह किसी विशिष्ट शैप से जुड़ा नहीं होता, इसलिए [ModernComment.getShape](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/moderncomment/getshape/) `null` लौटाता है। जब एक [Shape](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/shape/) प्रदान किया जाता है, तो टिप्पणी उस शैप से जुड़ी होती है। निर्देशांक अभी भी स्लाइड पर टिप्पणी मार्कर की स्थिति निर्धारित करते हैं, जबकि शैप एसोसिएशन को [ModernComment.getShape](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/moderncomment/getshape/) के माध्यम से प्राप्त किया जा सकता है।

### **एक आधुनिक टिप्पणी को शैप पर एंकर करें**

निम्नलिखित उदाहरण एक स्लाइड-स्तरीय आधुनिक टिप्पणी और एक विशिष्ट [AutoShape](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/autoshape/) से एंकर की गई आधुनिक टिप्पणी दोनों बनाता है। फिर यह प्रत्येक टिप्पणी से संबंधित शैप को पढ़ता है।

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const author = presentation.getCommentAuthors().addAuthor("Reviewer", "RV");
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 300, 80);
    shape.setName("Revenue title");
    shape.getTextFrame().setText("Quarterly revenue");

    const createdTime = java.newInstanceSync("java.util.Date");
    const slideCommentPosition = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(20), java.newFloat(20));
    const shapeCommentPosition = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(60), java.newFloat(60));
    const slideComment = author.getComments().addModernComment("Review the overall slide layout.", slide, null, slideCommentPosition, createdTime);
    const shapeComment = author.getComments().addModernComment("Check this title.", slide, shape, shapeCommentPosition, createdTime);

    console.log(slideComment.getShape() == null);
    console.log(shapeComment.getShape().getName());

    presentation.save("modern_comments.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **विभिन्न शैप प्रकारों पर टिप्पणियों को एंकर करें**

कोई भी स्लाइड ऑब्जेक्ट जो [Shape](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/shape/) से व्युत्पन्न है, शैप एंकर के रूप में उपयोग किया जा सकता है। सामान्य उदाहरणों में [AutoShape](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/autoshape/), [PictureFrame](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/pictureframe/), [GroupShape](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/groupshape/), [Connector](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/connector/), और चार्ट जैसी [GraphicalObject](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/graphicalobject/) इंस्टेंसेज़ शामिल हैं।

निम्नलिखित उदाहरण कई सामान्य शैप प्रकार बनाता है और प्रत्येक के साथ एक आधुनिक टिप्पणी को जोड़ता है।

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const author = presentation.getCommentAuthors().addAuthor("Reviewer", "RV");
    const createdTime = java.newInstanceSync("java.util.Date");

    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 180, 60);
    autoShape.getTextFrame().setText("AutoShape");
    const autoShapeCommentPosition = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(30), java.newFloat(30));
    author.getComments().addModernComment("Comment on an AutoShape.", slide, autoShape, autoShapeCommentPosition, createdTime);

    const imageBase64 = "iVBORw0KGgoAAAANSUhEUgAAAAIAAAACCAIAAAD91JpzAAAAFklEQVR4nGP8//8/AwMDEwMDAwMDAwAkBgMB/DXemwAAAABJRU5ErkJggg==";
    const imageData = java.newArray("byte", Array.from(Buffer.from(imageBase64, "base64")));
    const image = presentation.getImages().addImage(imageData);
    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 220, 20, 120, 80, image);
    const pictureCommentPosition = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(230), java.newFloat(30));
    author.getComments().addModernComment("Comment on a picture.", slide, pictureFrame, pictureCommentPosition, createdTime);

    const groupShape = slide.getShapes().addGroupShape();
    groupShape.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 0, 0, 80, 40);
    groupShape.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 100, 0, 80, 40);
    const groupCommentPosition = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(40), java.newFloat(150));
    author.getComments().addModernComment("Comment on a group.", slide, groupShape, groupCommentPosition, createdTime);

    const connector = slide.getShapes().addConnector(aspose.slides.ShapeType.StraightConnector1, 220, 150, 140, 40);
    const connectorCommentPosition = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(240), java.newFloat(150));
    author.getComments().addModernComment("Comment on a connector.", slide, connector, connectorCommentPosition, createdTime);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 400, 20, 250, 180);
    const chartCommentPosition = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(420), java.newFloat(40));
    author.getComments().addModernComment("Comment on a graphical object.", slide, chart, chartCommentPosition, createdTime);

    presentation.save("modern_comment_shape_types.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **टेक्स्ट पर टिप्पणी को एंकर करें और उसकी स्थिति सेट करें**

एक [AutoShape](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/autoshape/) से जुड़ी आधुनिक टिप्पणी के लिए, [ModernComment.getTextSelectionStart](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/moderncomment/gettextselectionstart/) और [ModernComment.setTextSelectionStart](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/moderncomment/settextselectionstart/) शैप के टेक्स्ट फ्रेम में चयनित टेक्स्ट की शुरुआती स्थिति तक पहुँचते हैं। [ModernComment.getTextSelectionLength](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/moderncomment/gettextselectionlength/) और [ModernComment.setTextSelectionLength](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/moderncomment/settextselectionlength/) चयन की लंबाई तक पहुँचते हैं। साथ में, ये मान टिप्पणी को [AutoShape](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/autoshape/) के अंदर एक विशिष्ट टेक्स्ट रेंज के साथ जोड़ते हैं।

[ModernComment.getStatus](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/moderncomment/getstatus/) और [ModernComment.setStatus](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/moderncomment/setstatus/) मेथड्स [ModernCommentStatus](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/moderncommentstatus/) एनेमरेशन से एक मान प्राप्त करते हैं:
- `NotDefined` — कोई विशिष्ट आधुनिक-टिप्पणी स्थिति परिभाषित नहीं है।
- `Active` — टिप्पणी सक्रिय है।
- `Resolved` — टिप्पणी को हल किया गया है।
- `Closed` — टिप्पणी बंद है।

निम्नलित उदाहरण एक शैप-एंकर की गई आधुनिक टिप्पणी बनाता है, इसे टेक्स्ट चयन के साथ जोड़ता है, इसे हल किए हुए चिह्नित करता है, प्रस्तुति को सहेजता है, और फ़ाइल को पुनः खोलने के बाद मानों की पुष्टि करता है।

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const outputFile = "modern_comment_text_anchor.pptx";
const shapeText = "Review the quarterly revenue forecast.";
const selectedText = "quarterly revenue";
const expectedSelectionStart = shapeText.indexOf(selectedText);

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 400, 100);
    shape.setName("Forecast text");
    shape.getTextFrame().setText(shapeText);

    const author = presentation.getCommentAuthors().addAuthor("Reviewer", "RV");
    const commentPosition = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(60), java.newFloat(60));
    const createdTime = java.newInstanceSync("java.util.Date");
    const comment = author.getComments().addModernComment("Verify this forecast wording.", slide, shape, commentPosition, createdTime);
    comment.setTextSelectionStart(expectedSelectionStart);
    comment.setTextSelectionLength(selectedText.length);
    comment.setStatus(aspose.slides.ModernCommentStatus.Resolved);

    presentation.save(outputFile, aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

const reopenedPresentation = new aspose.slides.Presentation(outputFile);
try {
    const reopenedSlide = reopenedPresentation.getSlides().get_Item(0);
    const reopenedComments = reopenedSlide.getSlideComments(null);

    for (let index = 0; index < reopenedComments.length; index++) {
        const reopenedComment = reopenedComments[index];
        if (!java.instanceOf(reopenedComment, "com.aspose.slides.IModernComment")) {
            continue;
        }

        const shapeMatches = reopenedComment.getShape() != null && reopenedComment.getShape().getName() === "Forecast text";
        const selectionStartMatches = reopenedComment.getTextSelectionStart() === expectedSelectionStart;
        const selectionLengthMatches = reopenedComment.getTextSelectionLength() === selectedText.length;
        const statusMatches = reopenedComment.getStatus() === aspose.slides.ModernCommentStatus.Resolved;

        console.log("Shape anchor preserved: " + shapeMatches);
        console.log("Text selection start preserved: " + selectionStartMatches);
        console.log("Text selection length preserved: " + selectionLengthMatches);
        console.log("Resolved status preserved: " + statusMatches);
    }
} finally {
    reopenedPresentation.dispose();
}
```

### **मौजूदा आधुनिक टिप्पणियों की जाँच करें**

किसी मौजूदा प्रस्तुति की जाँच करने के लिए, देखें कि कौन सी टिप्पणियाँ [ModernComment](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/moderncomment/) इंस्टेंसेज़ हैं, फिर [ModernComment.getShape](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/moderncomment/getshape/), [ModernComment.getTextSelectionStart](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/moderncomment/gettextselectionstart/), [ModernComment.getTextSelectionLength](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/moderncomment/gettextselectionlength/), और [ModernComment.getStatus](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/moderncomment/getstatus/) की जाँच करें। एक `null` शैप स्लाइड-स्तरीय टिप्पणी दर्शाता है। एक [AutoShape](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/autoshape/) एंकर के लिए, टेक्स्ट-सेलेक्शन मेथड्स शैप के टेक्स्ट फ्रेम में संबंधित रेंज की पहचान करते हैं।

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("comments.pptx");
try {
    const slides = presentation.getSlides();
    for (let slideIndex = 0; slideIndex < slides.size(); slideIndex++) {
        const slide = slides.get_Item(slideIndex);
        const comments = slide.getSlideComments(null);

        for (let commentIndex = 0; commentIndex < comments.length; commentIndex++) {
            const comment = comments[commentIndex];
            if (!java.instanceOf(comment, "com.aspose.slides.IModernComment")) {
                continue;
            }

            console.log("Slide: " + slide.getSlideNumber());
            console.log("Text: " + comment.getText());
            console.log("Status: " + comment.getStatus());

            const shape = comment.getShape();
            if (shape == null) {
                console.log("Anchor: slide level");
            } else {
                console.log("Anchor shape: " + shape.getName());
                console.log("Anchor type: " + shape.getClass().getSimpleName());

                if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                    console.log("Text selection start: " + comment.getTextSelectionStart());
                    console.log("Text selection length: " + comment.getTextSelectionLength());
                }
            }

            console.log();
        }
    }
} finally {
    presentation.dispose();
}
```

## **टिप्पणियाँ हटाएँ**

### **सभी टिप्पणियाँ और टिप्पणी लेखकों को हटाएँ**

निम्नलित उदाहरण दिखाता है कि प्रस्तुति से सभी टिप्पणियों और टिप्पणी लेखकों को कैसे हटाया जाए:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("example.pptx");
try {
    const authors = presentation.getCommentAuthors();
    for (let index = 0; index < authors.size(); index++) {
        authors.get_Item(index).getComments().clear();
    }

    authors.clear();
    presentation.save("example_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **विशिष्ट टिप्पणियों को हटाएँ**

निम्नलित उदाहरण दिखाता है कि स्लाइड से विशिष्ट टिप्पणियों को कैसे हटाया जाए:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const author = presentation.getCommentAuthors().addAuthor("Author", "A");
    const createdTime = java.newInstanceSync("java.util.Date");

    const firstCommentPosition = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(0.2), java.newFloat(0.2));
    const secondCommentPosition = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(0.3), java.newFloat(0.2));
    author.getComments().addComment("comment 1", slide, firstCommentPosition, createdTime);
    author.getComments().addComment("comment 2", slide, secondCommentPosition, createdTime);

    const authors = presentation.getCommentAuthors();
    for (let authorIndex = 0; authorIndex < authors.size(); authorIndex++) {
        const commentAuthor = authors.get_Item(authorIndex);
        const commentsToRemove = [];
        const comments = slide.getSlideComments(commentAuthor);

        for (let commentIndex = 0; commentIndex < comments.length; commentIndex++) {
            const comment = comments[commentIndex];
            if (comment.getText() === "comment 1") {
                commentsToRemove.push(comment);
            }
        }

        for (const comment of commentsToRemove) {
            commentAuthor.getComments().remove(comment);
        }
    }

    presentation.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या Aspose.Slides आधुनिक टिप्पणियों के लिए हल की गई स्थिति का समर्थन करता है?**

हां। [ModernComment.getStatus](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/moderncomment/getstatus/) और [ModernComment.setStatus](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/moderncomment/setstatus/) एक [ModernCommentStatus](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/moderncommentstatus/) मान तक पहुँचते हैं, जिसमें `Resolved` भी शामिल है। यह स्थिति प्रस्तुति में संग्रहीत रहती है और फ़ाइल को पुनः खोलने के बाद फिर से पढ़ी जा सकती है।

**क्या थ्रेडेड डिस्कशन (उत्तर श्रृंखलाएँ) समर्थित हैं, और क्या कोई नेस्टिंग सीमा है?**

हां। प्रत्येक टिप्पणी अपने [parent comment](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/comment/getparentcomment/) को संदर्भित कर सकती है, जिससे उत्तर श्रृंखलाएँ सक्षम होती हैं। API कोई विशिष्ट नेस्टिंग-गहराई सीमा निर्धारित नहीं करती।

**स्लाइड पर टिप्पणी मार्कर की स्थिति किस कॉर्डिनेट सिस्टम में परिभाषित होती है?**

मार्कर की स्थिति स्लाइड कॉर्डिनेट सिस्टम में फ्लोटिंग-पॉइंट निर्देशांकों द्वारा परिभाषित होती है, जिससे आप इसे सटीक रूप से स्लाइड पर रख सकते हैं।