---
title: Node.js में प्रस्तुति टिप्पणियों का प्रबंधन
linktitle: प्रस्तुति टिप्पणियां
type: docs
weight: 100
url: /hi/nodejs-java/presentation-comments/
keywords:
- टिप्पणी
- आधुनिक टिप्पणी
- PowerPoint टिप्पणियां
- प्रस्तुति टिप्पणियां
- स्लाइड टिप्पणियां
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
description: "Aspose.Slides for Node.js via Java के साथ प्रस्तुति टिप्पणियों का प्रबंधन: PowerPoint प्रस्तुतियों में टिप्पणियों को जोड़ें, पढ़ें, संपादित करें, उत्तर दें और हटाएँ।"
---
## **अवलोकन**

यह लेख Aspose.Slides for Node.js via Java के साथ प्रस्तुति टिप्पणियों का प्रबंधन करने के तरीके को समझाता है। यह मुख्य टिप्पणी-संबंधित प्रकारों का परिचय देता है और स्लाइड्स में टिप्पणियाँ जोड़ना, मौजूदा टिप्पणियों तक पहुँचना, उत्तरों और आधुनिक टिप्पणियों के साथ कार्य करना, तथा प्रस्तुति से टिप्पणियां हटाना दर्शाता है।

उदाहरण पारम्परिक समीक्षण और सहयोग परिदृश्यों को कवर करते हैं, जैसे टिप्पणियों को लेखकों को असाइन करना, टिप्पणी पाठ और मेटाडेटा पढ़ना, उत्तर श्रृंखलाएं बनाना, तथा चयनित टिप्पणियों या सभी टिप्पणियों को हटाना।

PowerPoint में, टिप्पणियां स्लाइडों पर एनोटेशन के रूप में दिखाई देती हैं। टिप्पणी का चयन करने पर उसका पाठ और संबंधित चर्चा प्रदर्शित होती है।

जब आप चाहते हैं कि प्रस्तुति खोलते समय टिप्पणियां दिखाई दें या छिपी रहें, बिना स्वयं टिप्पणियों को बदले, तो देखें [Show or Hide Comments When Opening a Presentation](/slides/hi/nodejs-java/presentation-view-properties/)।

## **प्रस्तुतियों में टिप्पणियां क्यों जोड़ें?**

आप समीक्षण के दौरान प्रतिक्रिया देने और सहकर्मियों के साथ सहयोग करने के लिए टिप्पणियों का उपयोग कर सकते हैं।

Aspose.Slides for Node.js via Java टिप्पणियों के साथ काम करने के लिए निम्नलिखित API प्रदान करता है:

* वह [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) क्लास, जो प्रस्तुति के टिप्पणी लेखकों तक पहुंच प्रदान करती है।
* वह [CommentCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentcollection/) क्लास, जो किसी विशिष्ट लेखक से संबंधित टिप्पणियों का प्रतिनिधित्व करती है।
* वह [Comment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/comment/) क्लास, जो टिप्पणी के बारे में जानकारी देती है, जिसमें लेखक, निर्माण समय, स्थिति और पाठ शामिल हैं।
* वह [CommentAuthor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentauthor/) क्लास, जो लेखक के बारे में जानकारी देती है, जिसमें उनका नाम, प्रारम्भिक अक्षर, और संबद्ध टिप्पणियां शामिल हैं।

## **स्लाइड टिप्पणियां जोड़ें**

उदाहरण दो स्लाइड बनाता है और [addAuthor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentauthorcollection/addauthor/) के साथ एक टिप्पणी लेखक को पंजीकृत करता है। यह प्रत्येक स्लाइड पर एक टिप्पणी रखने के लिये [addComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentcollection/addcomment/) का उपयोग करता है, फिर उस लेखक के लिये पहले स्लाइड की टिप्पणियों को [getSlideComments](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/getslidecomments/) द्वारा पुनः प्राप्त करता है। कंसोल पहले टिप्पणी का पाठ दो बार प्रदर्शित करता है, जो स्लाइड और लेखक दोनों के माध्यम से पहुंच को दर्शाता है, और सहेजी गई प्रस्तुति में दोनों टिप्पणियां सम्मिलित होती हैं।

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

        const commentText = firstComment.getAuthor().getComments().get_Item(0).getText();
        console.log(commentText);
    }

    presentation.save("Comments_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **टिप्पणी लेखक खोजें या बनाएं**

जब कोई स्वचालित समीक्षण एक ही प्रस्तुति को बार‑बार प्रोसेस करता है, तो लेखक जोड़ने से पहले [getCommentAuthors](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/getcommentauthors/) द्वारा लौटाए गए संग्रह को खोजें। [findByNameAndInitials](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentauthorcollection/findbynameandinitials/) नाम और प्रारम्भिक अक्षर दोनों से मिलान करता है और मिलते‑जुलते लेखकों की array लौटाता है, या यदि कोई मेल नहीं है तो खाली array। इसके विपरीत, [findByName](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentauthorcollection/findbyname/) केवल नाम से खोज करता है, प्रारम्भिक अक्षरों की परवाह किए बिना। संग्रह में पहले से मौजूद नाम और प्रारम्भिक अक्षर के साथ [addAuthor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentauthorcollection/addauthor/) को कॉल करने पर एक अपवाद उत्पन्न होता है।

उदाहरण को कम से कम एक स्लाइड वाली प्रस्तुति फ़ाइल की आवश्यकता होती है। दो पासों में, यह पहले मिलते‑जुलते लेखक को पुनः उपयोग करता है, या परिणाम खाली होने पर नया बनाता है। यदि कई मिलते‑जुलते मिलते हैं, तो यह पहला array तत्व चुनता है और अन्य लेखकों को मिलाएगा या हटाएगा नहीं। फिर यह चयनित लेखक के लिये [addComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentcollection/addcomment/) को कॉल करता है और प्रस्तुति सहेजता है। दूसरा पास पहले पास की आउटपुट खोलता है और वही प्रक्रिया दोहराता है।

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const authorName = "Reviewer";
const authorInitials = "RV";

let inputFile = "input.pptx";
const position = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(20), java.newFloat(20));

for (let pass = 1; pass <= 2; pass++) {
    const presentation = new aspose.slides.Presentation(inputFile);
    try {
        const matches = presentation.getCommentAuthors().findByNameAndInitials(authorName, authorInitials);

        const author = matches.length > 0 ? matches[0] : presentation.getCommentAuthors().addAuthor(authorName, authorInitials);
        const createdTime = java.newInstanceSync("java.util.Date");
        author.getComments().addComment("Please review this slide.", presentation.getSlides().get_Item(0), position, createdTime);

        const outputFile = "review_pass_" + pass + ".pptx";
        presentation.save(outputFile, aspose.slides.SaveFormat.Pptx);
        inputFile = outputFile;
    } finally {
        presentation.dispose();
    }
}
```

दूसरा पास एक और टिप्पणी जोड़ता है बिना नया लेखक जोड़े या मौजूदा टिप्पणियों को हटाए। अंतिम फ़ाइल, `review_pass_2.pptx`, दोनों नई टिप्पणियां मूल टिप्पणियों के साथ रखती है। लेखक का पुनः उपयोग करने से टिप्पणियां ड्यूप्लिकेट नहीं होतीं: समान टिप्पणी को दोहराव से बचने के लिये जोड़ने से पहले अलग ड्यूप्लिकेशन पहचान लागू करें।

## **स्लाइड टिप्पणियों तक पहुँचें**

उदाहरण मौजूदा प्रस्तुति खोलता है और [getCommentAuthors](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/getcommentauthors/) द्वारा लौटाए गए संग्रह को पढ़ता है। प्रत्येक लेखक के लिये, यह [getComments](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentauthor/getcomments/) द्वारा लौटाए गए संग्रह पर इटरिट करता है और स्लाइड नंबर, टिप्पणी पाठ, लेखक का नाम, और निर्माण समय प्रिंट करता है। इनपुट प्रस्तुति में टिप्पणियां होनी चाहिए जिससे कंसोल आउटपुट उत्पन्न हो सके।

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

## **टिप्पणियों का उत्तर दें**

एक पैरेंट टिप्पणी वह मूल टिप्पणी होती है जो उत्तर पदानुक्रम के शीर्ष पर होती है। [Comment.getParentComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/comment/getparentcomment/) और [Comment.setParentComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/comment/setparentcomment/) मेथड आपको टिप्पणी के पैरेंट को प्राप्त या सेट करने की अनुमति देते हैं।

उदाहरण दो लेखकों से टिप्पणियां बनाता है और [setParentComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/comment/setparentcomment/) का प्रयोग करके उत्तर बनाता है, जिसमें एक उत्तर का उत्तर भी शामिल है। `null` को [getSlideComments](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/getslidecomments/) में पास करने से सभी लेखकों की टिप्पणियां प्राप्त होती हैं; कंसोल प्रत्येक प्रविष्टि को उसकी उत्तर पदानुक्रम में गहराई के अनुसार इंडेंट करता है। उदाहरण पूर्ण चर्चा को सहेजता है, पहले मूल टिप्पणी पर [remove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/comment/remove/) को कॉल करता है, तथा उस टिप्पणी और उसके उत्तरों को हटाकर दूसरा प्रस्तुति सहेजता है।

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const position = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10));
    const createdTime = java.newInstanceSync("java.util.Date");

    const originalAuthor = presentation.getCommentAuthors().addAuthor("Author_1", "A.A.");
    const rootComment = originalAuthor.getComments().addComment("comment 1", slide, position, createdTime);

    const reviewer = presentation.getCommentAuthors().addAuthor("Author_2", "B.B.");
    const firstReply = reviewer.getComments().addComment("reply 1 for comment 1", slide, position, createdTime);
    firstReply.setParentComment(rootComment);

    const secondReply = reviewer.getComments().addComment("reply 2 for comment 1", slide, position, createdTime);
    secondReply.setParentComment(rootComment);

    const subReply = originalAuthor.getComments().addComment("subreply 3 for reply 2", slide, position, createdTime);
    subReply.setParentComment(secondReply);

    reviewer.getComments().addComment("comment 2", slide, position, createdTime);
    const separateComment = reviewer.getComments().addComment("comment 3", slide, position, createdTime);

    const separateReply = originalAuthor.getComments().addComment("reply 4 for comment 3", slide, position, createdTime);
    separateReply.setParentComment(separateComment);

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

    rootComment.remove();
    presentation.save("remove_comment.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert color="warning" title="Warning" %}}
* जब [Comment.remove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/comment/remove/) मेथड का उपयोग करके कोई टिप्पणी हटाई जाती है, तो उस टिप्पणी के सभी उत्तर भी हटाए जाते हैं।
* यदि [Comment.setParentComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/comment/setparentcomment/) एक चक्रीय संदर्भ बनाता है, तो एक [PptxEditException](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pptxeditexception/) उत्पन्न होता है।
{{% /alert %}}

## **आधुनिक टिप्पणियां जोड़ें**

आधुनिक टिप्पणियां स्लाइड स्वयं, किसी विशिष्ट आकृति, या AutoShape के भीतर किसी टेक्स्ट रेंज से संबंधित हो सकती हैं। [CommentCollection.addModernComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentcollection/addmoderncomment/) मेथड स्लाइड और टिप्पणी‑मार्कर निर्देशांक के अतिरिक्त एक [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) आर्ग्यूमेंट स्वीकार करता है।

जब `null` को shape आर्ग्यूमेंट के लिये पास किया जाता है, तो टिप्पणी एक स्लाइड‑स्तर टिप्पणी बनती है। इसका मार्कर प्रदान किए गए निर्देशांक द्वारा स्थित किया जाता है, लेकिन यह किसी विशिष्ट shape से जुड़ी नहीं होती, इसलिए [ModernComment.getShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/getshape/) `null` लौटाता है। जब कोई [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) प्रदान की जाती है, तो टिप्पणी उस shape से जुड़ी होती है। निर्देशांक अभी भी स्लाइड पर टिप्पणी मार्कर की स्थिति निर्धारित करते हैं, जबकि shape संबद्धता को [ModernComment.getShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/getshape/) द्वारा पुनः प्राप्त किया जा सकता है।

### **एक shape से आधुनिक टिप्पणी को एंकर करें**

उदाहरण [addModernComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentcollection/addmoderncomment/) को दो बार कॉल करता है: एक बार `null` shape के साथ स्लाइड‑स्तर टिप्पणी के लिये और एक बार आयत को एंकर के रूप में। [getShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/getshape/) को पढ़ने से स्लाइड‑स्तर टिप्पणी के `null` जाँच के लिये `true` और एंकर की गई टिप्पणी के लिये `Revenue title` प्रदर्शित होता है। दोनों टिप्पणियां प्रस्तुति के साथ सहेजी जाती हैं।

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

### **विभिन्न shape प्रकारों से टिप्पणियां एंकर करें**

[Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) से व्युत्पन्न कोई भी स्लाइड ऑब्जेक्ट shape एंकर के रूप में उपयोग किया जा सकता है। सामान्य उदाहरणों में [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/), [PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/), [GroupShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshape/), [Connector](https://reference.aspose.com/slides/nodejs-java/aspose.slides/connector/), और [GraphicalObject](https://reference.aspose.com/slides/nodejs-java/aspose.slides/graphicalobject/) जैसे चार्ट शामिल हैं।

उदाहरण [addModernComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentcollection/addmoderncomment/) का उपयोग करके प्रत्येक पाँच shape प्रकार के लिये एक टिप्पणी जोड़ता है: AutoShape, picture frame, group, connector, और chart। चित्र एम्बेडेड इमेज डेटा का उपयोग करता है, इसलिए बाहरी इमेज आवश्यक नहीं है। प्रत्येक टिप्पणी की अपनी मार्कर स्थिति होती है, और सहेजी गई प्रस्तुति सभी पाँच shape संबद्धताओं को रखती है।

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

### **टेक्स्ट से टिप्पणी को एंकर करें और उसकी स्थिति सेट करें**

[AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) से संबंधित एक आधुनिक टिप्पणी के लिये, [ModernComment.getTextSelectionStart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/gettextselectionstart/) और [ModernComment.setTextSelectionStart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/settextselectionstart/) shape के टेक्स्ट फ्रेम में चयनित टेक्स्ट की शुरुआती स्थिति तक पहुंचते हैं। [ModernComment.getTextSelectionLength](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/gettextselectionlength/) और [ModernComment.setTextSelectionLength](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/settextselectionlength/) चयन की लंबाई तक पहुंचते हैं। ये मान मिलकर टिप्पणी को AutoShape के भीतर विशिष्ट टेक्स्ट रेंज से जोड़ते हैं।

[ModernComment.getStatus](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/getstatus/) और [ModernComment.setStatus](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/setstatus/) मेथड [ModernCommentStatus](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncommentstatus/) enumeration से एक मान प्राप्त या सेट करते हैं:

- `NotDefined` — कोई विशिष्ट आधुनिक‑टिप्पणी स्थिति परिभाषित नहीं है।
- `Active` — टिप्पणी सक्रिय है।
- `Resolved` — टिप्पणी को हल किया गया है।
- `Closed` — टिप्पणी बंद है।

उदाहरण एक आयत के टेक्स्ट में शब्द “quarterly revenue” से एक आधुनिक टिप्पणी को एंकर करता है। यह टेक्स्ट से शून्य‑आधारित चयन शुरूआत की गणना करता है और उसे [setTextSelectionStart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/settextselectionstart/) में पास करता है, तथा चयनित अक्षरों की संख्या के लिये [setTextSelectionLength](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/settextselectionlength/) को उपयोग करता है। `Resolved` के साथ [setStatus](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/setstatus/) को कॉल करने के बाद, यह प्रस्तुति को सहेजता और पुनः खोलता है। चार कंसोल जाँच प्रत्येक `true` प्रदर्शित करनी चाहिए, यह पुष्टि करते हुए कि shape एंकर, टेक्स्ट रेंज, और स्थिति संरक्षित थीं।

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
    comment.setStatus(java.newByte(aspose.slides.ModernCommentStatus.Resolved));

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

### **मौजूदा आधुनिक टिप्पणियों की जांच करें**

उदाहरण को आधुनिक टिप्पणियों वाला मौजूदा प्रस्तुति चाहिए और वह उनका पाठ, स्थिति, और एंकर विवरण प्रिंट करता है। इसे जांचने के लिये, देखें कि कौन सी टिप्पणियां [ModernComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/) की इंस्टेंस हैं, फिर [ModernComment.getShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/getshape/), [ModernComment.getTextSelectionStart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/gettextselectionstart/), [ModernComment.getTextSelectionLength](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/gettextselectionlength/), और [ModernComment.getStatus](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/getstatus/) को देखें। `null` shape एक स्लाइड‑स्तर टिप्पणी को दर्शाता है। किसी [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) एंकर के लिये, टेक्स्ट‑सेलेक्शन मेथड shape के टेक्स्ट फ्रेम में संबद्ध रेंज की पहचान करते हैं।

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

## **टिप्पणियां हटाएं**

Aspose.Slides for Node.js via Java आपको पूरी प्रस्तुति या चयनित टिप्पणियों को हटाते हुए शेष को बरकरार रखते हुए सभी टिप्पणियां और उनके लेखकों को हटाने की सुविधा देता है। नीचे दिए गए उदाहरण दोनों तरीकों को दर्शाते हैं और अपडेटेड प्रस्तुति को सहेजते हैं।

### **सभी टिप्पणियां और टिप्पणी लेखकों को हटाएं**

उदाहरण मौजूदा प्रस्तुति खोलता है और प्रत्येक लेखक के लिये [CommentCollection.clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentcollection/clear/) को कॉल करता है, फिर [CommentAuthorCollection.clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentauthorcollection/clear/) को कॉल करके लेखकों को स्वयं हटाता है। सहेजी गई प्रस्तुति में न तो कोई टिप्पणी होगी और न ही कोई टिप्पणी लेखक। हटाने को देखने के लिये ऐसी प्रस्तुति उपयोग करें जिसमें टिप्पणियां हों।

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

### **विशिष्ट टिप्पणियां हटाएं**

उदाहरण एक स्लाइड पर दो टिप्पणियां बनाता है और प्रत्येक लेखक द्वारा [getSlideComments](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/getslidecomments/) का उपयोग करके टिप्पणियां खोजता है। यह "comment 1" पाठ वाली टिप्पणियों को इकट्ठा करता है और फिर [CommentCollection.remove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentcollection/remove/) को कॉल करता है, जिससे चयन के दौरान संग्रह में परिवर्तन नहीं होता। सहेजी गई प्रस्तुति में केवल “comment 2” ही रहता है।

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

## **FAQ**

**क्या Aspose.Slides आधुनिक टिप्पणियों के लिये हल की गई स्थिति (Resolved) को समर्थन देता है?**

हां। [ModernComment.getStatus](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/getstatus/) और [ModernComment.setStatus](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/setstatus/) [ModernCommentStatus](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncommentstatus/) मान तक पहुंच प्रदान करते हैं, जिसमें `Resolved` शामिल है। यह स्थिति प्रस्तुति में संग्रहीत रहती है और फ़ाइल को पुनः खोलने के बाद फिर से पढ़ी जा सकती है।

**क्या थ्रेडेड चर्चाएँ (उत्तर श्रृंखलाएं) समर्थित हैं, और क्या कोई गहराई सीमा है?**

हां। प्रत्येक टिप्पणी अपने [parent comment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/comment/getparentcomment/) को संदर्भित कर सकती है, जिससे उत्तर श्रृंखलाएं बनती हैं। API कोई विशिष्ट नेस्टिंग‑डेप्थ सीमा निर्धारित नहीं करता।

**स्लाइड पर टिप्पणी मार्कर की स्थिति किस निर्देशांक प्रणाली में निर्धारित होती है?**

मार्कर स्थिति स्लाइड निर्देशांक प्रणाली में फ्लोटिंग‑पॉइंट निर्देशांकों द्वारा परिभाषित होती है, जिससे आप इसे स्लाइड पर सटीक रूप से रख सकते हैं।