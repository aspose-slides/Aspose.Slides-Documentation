---
title: जावा स्क्रिप्ट में प्रस्तुति टिप्पणियों का प्रबंधन
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
  - OpenDocument
  - प्रस्तुति
  - Node.js
  - JavaScript
  - Aspose.Slides
description: "Aspose.Slides for Node.js के साथ प्रस्तुति टिप्पणियों को पूरी तरह नियंत्रित करें: जावा स्क्रिप्ट का उपयोग करके PowerPoint फ़ाइलों में टिप्पणियों को तेज़ी से और आसानी से जोड़ें, पढ़ें, संपादित करें और हटाएँ।"
---
## **अवलोकन**

यह लेख Aspose.Slides में प्रेज़ेंटेशन टिप्पणियों को प्रबंधित करने के तरीके को समझाता है। यह मुख्य टिप्पणी-संबंधित प्रकारों को दर्शाता है और स्लाइड्स में टिप्पणी जोड़ना, मौजूदा टिप्पणियों तक पहुँच, उत्तरों के साथ काम करना, आधुनिक टिप्पणियों का उपयोग करना, तथा प्रेज़ेंटेशन से टिप्पणियों को हटाना प्रदर्शित करता है।

उदाहरण सामान्य समीक्षा और सहयोग परिदृश्यों पर केंद्रित हैं, जैसे लेखकों को टिप्पणियाँ असाइन करना, टिप्पणी की सामग्री और मेटाडेटा पढ़ना, उत्तर श्रृंखला बनाना, और सभी टिप्पणियाँ साफ़ करना या चयनित टिप्पणियों को हटाना।

PowerPoint में, टिप्पणी स्लाइड पर नोट या एनोटेशन के रूप में दिखाई देती है। जब टिप्पणी पर क्लिक किया जाता है, तो उसकी सामग्री या संदेश प्रकट होते हैं।

## **प्रेज़ेंटेशन में टिप्पणियाँ क्यों जोड़ें?**

आप प्रेज़ेंटेशन की समीक्षा करते समय प्रतिक्रिया प्रदान करने या सहयोगियों के साथ संवाद करने के लिए टिप्पणियों का उपयोग करना चाह सकते हैं।

PowerPoint प्रेज़ेंटेशन में टिप्पणियों का उपयोग करने के लिए Aspose.Slides for Node.js via Java निम्नलिखित प्रदान करता है:

* The [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Presentation) class, जिसमें लेखकों के संग्रह ( [CommentAuthorCollection](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/CommentAuthorCollection) class से) शामिल हैं। लेखक स्लाइड्स में टिप्पणियाँ जोड़ते हैं।
* The [CommentCollection](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/CommentCollection) class, जिसमें व्यक्तिगत लेखकों के लिए टिप्पणी संग्रह रहता है।
* The [Comment](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Comment) class, जो लेखकों और उनकी टिप्पणियों की जानकारी रखती है: टिप्पणी किसने जोड़ी, कब जोड़ी गई, टिप्पणी की स्थिति आदि।
* The [CommentAuthor](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/CommentAuthor) class, जो व्यक्तिगत लेखकों की जानकारी रखती है: लेखक का नाम, उसके आद्याक्षर, लेखक के नाम से जुड़ी टिप्पणियाँ आदि।

## **स्लाइड टिप्पणी जोड़ें**
यह JavaScript कोड दिखाता है कि PowerPoint प्रेज़ेंटेशन में स्लाइड पर टिप्पणी कैसे जोड़ें:

```javascript
// Presentation क्लास का उदाहरण बनाता है
var pres = new aspose.slides.Presentation();
try {
    // एक खाली स्लाइड जोड़ता है
    pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    // एक लेखक जोड़ता है
    var author = pres.getCommentAuthors().addAuthor("Jawad", "MF");
    // टिप्पणियों के लिए स्थिति सेट करता है
    var point = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(0.2), java.newFloat(0.2));
    // लेखक के लिए स्लाइड 1 पर स्लाइड टिप्पणी जोड़ता है
    author.getComments().addComment("Hello Jawad, this is slide comment", pres.getSlides().get_Item(0), point, java.newInstanceSync("java.util.Date"));
    // लेखक के लिए स्लाइड 2 पर स्लाइड टिप्पणी जोड़ता है
    author.getComments().addComment("Hello Jawad, this is second slide comment", pres.getSlides().get_Item(1), point, java.newInstanceSync("java.util.Date"));
    // ISlide 1 को एक्सेस करता है
    var slide = pres.getSlides().get_Item(0);
    // जब null को आर्ग्यूमेंट के रूप में पास किया जाता है, तो सभी लेखकों की टिप्पणियाँ चयनित स्लाइड में लायी जाती हैं
    var Comments = slide.getSlideComments(author);
    // स्लाइड 1 के लिए इंडेक्स 0 पर टिप्पणी को एक्सेस करता है
    var str = Comments[0].getText();
    pres.save("Comments_out.pptx", aspose.slides.SaveFormat.Pptx);
    if (Comments.length > 0) {
        // इंडेक्स 0 पर लेखक की टिप्पणियों का संग्रह चुनता है
        var commentCollection = Comments[0].getAuthor().getComments();
        var Comment = commentCollection.get_Item(0).getText();
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **स्लाइड टिप्पणियों तक पहुँचें**
यह JavaScript कोड दिखाता है कि PowerPoint प्रेज़ेंटेशन में स्लाइड पर मौजूदा टिप्पणी तक कैसे पहुँचें:

```javascript
var pres = new aspose.slides.Presentation("Comments1.pptx");
try {
    for (let i = 0; i < pres.getCommentAuthors().size(); i++) {
        let commentAuthor = pres.getCommentAuthors().get_Item(i);
        for (let j = 0; j < commentAuthor.getComments().size(); j++) {
            const comment = commentAuthor.getComments().get_Item(j);
            console.log("ISlide :" + comment.getSlide().getSlideNumber() + " has comment: " + comment.getText() + " with Author: " + comment.getAuthor().getName() + " posted on time :" + comment.getCreatedTime() + "\n");
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **टिप्पणियों का उत्तर देना**
पैरेंट टिप्पणी वह शीर्ष या मूल टिप्पणी होती है जो टिप्पणी या उत्तरों की पदानुक्रम में रहती है। [Comment](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Comment) class की [getParentComment](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Comment#getParentComment--) या [setParentComment](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Comment#setParentComment-aspose.slides.IComment-) मेथड का उपयोग करके आप पैरेंट टिप्पणी को सेट या प्राप्त कर सकते हैं।

यह JavaScript कोड दिखाता है कि टिप्पणी कैसे जोड़ें और उनके उत्तर कैसे प्राप्त करें:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // एक टिप्पणी जोड़ता है
    var author1 = pres.getCommentAuthors().addAuthor("Author_1", "A.A.");
    var comment1 = author1.getComments().addComment("comment1", pres.getSlides().get_Item(0), java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10)), java.newInstanceSync("java.util.Date"));
    // comment1 के लिए उत्तर जोड़ता है
    var author2 = pres.getCommentAuthors().addAuthor("Autror_2", "B.B.");
    var reply1 = author2.getComments().addComment("reply 1 for comment 1", pres.getSlides().get_Item(0), java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10)), java.newInstanceSync("java.util.Date"));
    reply1.setParentComment(comment1);
    // comment1 के लिए एक और उत्तर जोड़ता है
    var reply2 = author2.getComments().addComment("reply 2 for comment 1", pres.getSlides().get_Item(0), java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10)), java.newInstanceSync("java.util.Date"));
    reply2.setParentComment(comment1);
    // एक मौजूदा उत्तर पर उत्तर जोड़ता है
    var subReply = author1.getComments().addComment("subreply 3 for reply 2", pres.getSlides().get_Item(0), java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10)), java.newInstanceSync("java.util.Date"));
    subReply.setParentComment(reply2);
    var comment2 = author2.getComments().addComment("comment 2", pres.getSlides().get_Item(0), java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10)), java.newInstanceSync("java.util.Date"));
    var comment3 = author2.getComments().addComment("comment 3", pres.getSlides().get_Item(0), java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10)), java.newInstanceSync("java.util.Date"));
    var reply3 = author1.getComments().addComment("reply 4 for comment 3", pres.getSlides().get_Item(0), java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10)), java.newInstanceSync("java.util.Date"));
    reply3.setParentComment(comment3);
    // कंसोल में टिप्पणी पदानुक्रम दिखाता है
    var slide = pres.getSlides().get_Item(0);
    var comments = slide.getSlideComments(null);
    for (var i = 0; i < comments.length; i++) {
        var comment = comments[i];
        while (comment.getParentComment() != null) {
            console.log("\t");
            comment = comment.getParentComment();
        }
        console.log((comments[i].getAuthor().getName() + " : ") + comments[i].getText());
        console.log();
    }
    pres.save("parent_comment.pptx", aspose.slides.SaveFormat.Pptx);
    // comment1 और उसकी सभी उत्तरों को हटाता है
    comment1.remove();
    pres.save("remove_comment.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert color="warning" title="Attention" %}} 
* जब [Comment](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Comment) class की [Remove](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Comment#remove--) मेथड का उपयोग करके कोई टिप्पणी हटाई जाती है, तो उस टिप्पणी के उत्तर भी हटा दिए जाते हैं।
* यदि [setParentComment](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Comment#setParentComment-aspose.slides.IComment-) सेट करने से सर्कुलर रेफ़रेंस बन जाता है, तो [PptxEditException](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/PptxEditException) उत्पन्न होगी।
{{% /alert %}}

## **आधुनिक टिप्पणी जोड़ें**

2021 में Microsoft ने PowerPoint में *आधुनिक टिप्पणियों* को प्रस्तुत किया। आधुनिक टिप्पणी सुविधा PowerPoint में सहयोग को काफी सुधारती है। आधुनिक टिप्पणियों के माध्यम से उपयोगकर्ता टिप्पणियों को हल कर सकते हैं, उन्हें ऑब्जेक्ट और पाठ से जोड़ सकते हैं, और पहले से अधिक आसानी से इंटरैक्शन कर सकते हैं।

Aspose.Slides [ModernComment](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/ModernComment) class द्वारा आधुनिक टिप्पणियों का समर्थन करता है। [CommentCollection](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/CommentCollection) class में [addModernComment](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/CommentCollection#addModernComment-java.lang.String-aspose.slides.ISlide-aspose.slides.IShape-java.awt.geom.Point2D$Float-java.util.Date-) और [insertModernComment](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/CommentCollection#insertModernComment-int-java.lang.String-aspose.slides.ISlide-aspose.slides.IShape-java.awt.geom.Point2D$Float-java.util.Date-) मेथड जोड़े गए हैं।

यह JavaScript कोड दिखाता है कि PowerPoint प्रेज़ेंटेशन में स्लाइड पर आधुनिक टिप्पणी कैसे जोड़ें:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var newAuthor = pres.getCommentAuthors().addAuthor("Some Author", "SA");
    var modernComment = newAuthor.getComments().addModernComment("This is a modern comment", pres.getSlides().get_Item(0), null, java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(100), java.newFloat(100)), java.newInstanceSync("java.util.Date"));
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **टिप्पणी हटाएँ**

### **सभी टिप्पणियाँ और लेखक हटाएँ**

यह JavaScript कोड दिखाता है कि प्रेज़ेंटेशन में सभी टिप्पणियाँ और लेखक कैसे हटाएँ:

```javascript
var presentation = new aspose.slides.Presentation("example.pptx");
try {
    // प्रेज़ेंटेशन से सभी टिप्पणियाँ हटाता है
    for (let i = 0; i < presentation.getCommentAuthors().size(); i++) {
    var author = presentation.getCommentAuthors().get_Item(i)
        author.getComments().clear();
    }
    // सभी लेखकों को हटाता है
    presentation.getCommentAuthors().clear();
    presentation.save("example_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

### **विशिष्ट टिप्पणियाँ हटाएँ**

यह JavaScript कोड दिखाता है कि स्लाइड पर विशिष्ट टिप्पणियों को कैसे हटाएँ:

```javascript
var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);
    // टिप्पणियाँ जोड़ें...
    var author = presentation.getCommentAuthors().addAuthor("Author", "A");
    author.getComments().addComment("comment 1", slide, java.newInstanceSync("com.aspose.slides.Point2DFloat",  java.newFloat(0.2), java.newFloat(0.2)), java.newInstanceSync("java.util.Date"));
    author.getComments().addComment("comment 2", slide, java.newInstanceSync("com.aspose.slides.Point2DFloat",  java.newFloat(0.3), java.newFloat(0.2)), java.newInstanceSync("java.util.Date"));
    // सभी टिप्पणियों को हटाएँ जिनमें "comment 1" पाठ शामिल है
    
    
    for (var i = 0; i < presentation.getCommentAuthors().length; i++) {
        var commentAuthor = presentation.getCommentAuthors().get_Item(i);
        var toRemove = java.newInstanceSync("java.util.ArrayList");
        for (let j = 0; j < slide.getSlideComments(commentAuthor).size(); j++) {
            let comment = slide.getSlideComments(commentAuthor).get_Item(j);
            if (comment.getText() === "comment 1") {
                toRemove.add(comment);
            }
        }
        for (var i = 0; i < toRemove.length; i++) {
            var comment = toRemove.get_Item(i);
            commentAuthor.getComments().remove(comment);
        }
    }
    presentation.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या Aspose.Slides आधुनिक टिप्पणियों के लिए 'resolved' जैसी स्थिति का समर्थन करता है?**

हां। [Modern comments](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/moderncomment/) में [getStatus](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/moderncomment/getstatus/) और [setStatus](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/moderncomment/setStatus/) मेथड उपलब्ध हैं; आप टिप्पणी की स्थिति पढ़ और सेट कर सकते हैं (उदाहरण के लिए, इसे हल के रूप में चिह्नित करें), और यह स्थिति फ़ाइल में सहेजी जाती है तथा PowerPoint द्वारा मान्यता प्राप्त होती है।

**क्या थ्रेडेड डिस्कशन (उत्तर श्रृंखलाएं) समर्थित हैं, और क्या नेस्टिंग की कोई सीमा है?**

हां। प्रत्येक टिप्पणी अपने [parent comment](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/comment/getparentcomment/) को संदर्भित कर सकती है, जिससे अनियंत्रित उत्तर श्रृंखलाएँ संभव होती हैं। API ने कोई विशिष्ट नेस्टिंग गहराई सीमा घोषित नहीं की है।

**स्लाइड पर टिप्पणी मार्कर की स्थिति किस कोऑर्डिनेट सिस्टम में निर्धारित की जाती है?**

स्थिति स्लाइड के कोऑर्डिनेट सिस्टम में एक फ्लोटिंग पॉइंट बिंदु के रूप में संग्रहीत होती है। यह आपको टिप्पणी मार्कर को सटीक रूप से जहाँ आवश्यक हो वहाँ रखने की अनुमति देता है।