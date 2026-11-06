---
title: Android पर प्रस्तुति टिप्पणियों का प्रबंधन
linktitle: प्रस्तुति टिप्पणियाँ
type: docs
weight: 100
url: /hi/androidjava/presentation-comments/
keywords:
- टिप्पणी
- आधुनिक टिप्पणी
- PowerPoint टिप्पणियाँ
- प्रस्तुति टिप्पणियाँ
- स्लाइड टिप्पणियाँ
- टिप्पणी जोड़ें
- टिप्पणी पहुँचें
- टिप्पणी संपादित करें
- टिप्पणी का उत्तर दें
- टिप्पणी हटाएँ
- टिप्पणी मिटाएँ
- PowerPoint
- प्रस्तुति
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java के साथ प्रस्तुति टिप्पणियों को प्रबंधित करें: PowerPoint प्रस्तुतियों में टिप्पणियों को जल्दी और आसानी से जोड़ें, पढ़ें, संपादित करें, उत्तर दें और हटाएँ।"
---
## **अवलोकन**

यह लेख Aspose.Slides for Android via Java के साथ प्रस्तुति टिप्पणियों को प्रबंधित करने के बारे में बताता है। यह मुख्य टिप्पणी‑संबंधित प्रकारों का परिचय कराता है और स्लाइड पर टिप्पणी जोड़ना, मौजूदा टिप्पणियों तक पहुँच, उत्तरों और आधुनिक टिप्पणियों के साथ काम करना, तथा प्रस्तुति से टिप्पणियों को हटाना प्रदर्शित करता है।

उदाहरण सामान्य समीक्षा और सहयोग परिदृश्यों को कवर करते हैं, जैसे कि पाठकों को टिप्पणी असाइन करना, टिप्पणी पाठ और मेटा‑डेटा पढ़ना, उत्तर श्रंखलाएँ बनाना, और चयनित टिप्पणियों या सभी टिप्पणियों को हटाना।

PowerPoint में, स्लाइड पर टिप्पणियाँ एनोटेशन के रूप में दिखाई देती हैं। टिप्पणी का चयन करने पर उसका पाठ और संबंधित चर्चा प्रदर्शित होती है।

प्रस्तुति खोलते समय टिप्पणी को दिखाने या छुपाने का अनुरोध करने के लिए (बिना स्वयं टिप्पणी बदले), देखें [प्रस्तुति खोलते समय टिप्पणी दिखाएँ या छुपाएँ](/slides/hi/androidjava/presentation-view-properties/)।

## **प्रस्तुति में टिप्पणियाँ क्यों जोड़ें?**

आप प्रस्तुति की समीक्षा के दौरान प्रतिक्रिया देने और सहयोगियों के साथ मिलकर काम करने के लिए टिप्पणियों का उपयोग कर सकते हैं।

Aspose.Slides for Android via Java टिप्पणियों को संभालने के लिए नीचे दिए गए API प्रदान करता है:

* The [प्रेज़ेंटेशन](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) class, जो प्रेज़ेंटेशन के टिप्पणी लेखकों तक पहुँच प्रदान करती है।
* The [ICommentCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommentcollection/) interface, जो व्यक्तिगत लेखक से जुड़ी टिप्पणियों का प्रतिनिधित्व करता है।
* The [IComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icomment/) interface, जो टिप्पणी के बारे में जानकारी देता है, जिसमें लेखक, निर्माण समय, स्थिति और पाठ शामिल हैं।
* The [CommentAuthor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/commentauthor/) class, जो लेखक के बारे में जानकारी प्रदान करता है, जिसमें उनका नाम, प्रारम्भिक अक्षर और सम्बद्ध टिप्पणियाँ शामिल हैं।

## **स्लाइड टिप्पणियाँ जोड़ें**

उदाहरण दो स्लाइड बनाता है और [addAuthor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommentauthorcollection/#addAuthor-java.lang.String-java.lang.String-) के साथ एक टिप्पणी लेखक को पंजीकृत करता है। यह प्रत्येक स्लाइड पर एक टिप्पणी रखने के लिए [addComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommentcollection/#addComment-java.lang.String-com.aspose.slides.ISlide-android.graphics.PointF-java.util.Date-) का उपयोग करता है, फिर उस लेखक के लिए पहली स्लाइड की टिप्पणियाँ [getSlideComments](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#getSlideComments-com.aspose.slides.ICommentAuthor-) के साथ प्राप्त करता है। कंसोल पहली टिप्पणी का पाठ दो बार दिखाता है, जिससे स्लाइड और लेखक दोनों के माध्यम से पहुँच दर्शायी जाती है, और सहेजा गया प्रेज़ेंटेशन दोनों टिप्पणियों को शामिल करता है।

```java
import com.aspose.slides.IComment;
import com.aspose.slides.ICommentAuthor;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import android.graphics.PointF;
import java.util.Date;

Presentation presentation = new Presentation();
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);
    ISlide secondSlide = presentation.getSlides().addEmptySlide(presentation.getLayoutSlides().get_Item(0));

    ICommentAuthor author = presentation.getCommentAuthors().addAuthor("Jawad", "MF");
    PointF position = new PointF(0.2f, 0.2f);
    Date createdTime = new Date();

    author.getComments().addComment("Hello Jawad, this is a slide comment", firstSlide, position, createdTime);
    author.getComments().addComment("Hello Jawad, this is the second slide comment", secondSlide, position, createdTime);

    IComment[] comments = firstSlide.getSlideComments(author);
    if (comments.length > 0) {
        IComment firstComment = comments[0];
        System.out.println(firstComment.getText());

        String commentText = firstComment.getAuthor().getComments().get_Item(0).getText();
        System.out.println(commentText);
    }

    presentation.save("Comments_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **टिप्पणी लेखक खोजें या बनाएं**

जब एक स्वचालित समीक्षा एक ही प्रस्तुति को बार‑बार प्रोसेस करती है, तो लेखक जोड़ने से पहले [getCommentAuthors](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getCommentAuthors--) द्वारा लौटाई गई संग्रह को खोजें। [findByNameAndInitials](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommentauthorcollection/#findByNameAndInitials-java.lang.String-java.lang.String-) नाम और प्रारम्भिक अक्षर दोनों को मिलाता है और मिलते‑जुले लेखकों की एक श्रृंखला लौटाता है, या यदि कोई मेल नहीं है तो खाली श्रृंखला। इसके विपरीत, [findByName](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommentauthorcollection/#findByName-java.lang.String-) केवल नाम से खोज करता है, प्रारम्भिक अक्षर की परवाह किए बिना। उसी नाम और प्रारम्भिक अक्षर वाले लेखक को फिर से जोड़ने के लिए [addAuthor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommentauthorcollection/#addAuthor-java.lang.String-java.lang.String-) कॉल करने पर एक अपवाद फेंका जाता है।

उदाहरण के लिए कम से कम एक स्लाइड वाली प्रस्तुति फ़ाइल आवश्यक है। दो चरणों में यह पहली मिलती‑जुलती लेखक को पुनः उपयोग करता है, या परिणाम खाली होने पर ही नया बनाता है। यदि कई मिलान मिलते हैं, तो यह पहले तत्व को चुनता है और अन्य लेखकों को मिलाए या हटाए नहीं जाता। फिर यह चयनित लेखक के लिए [addComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommentcollection/#addComment-java.lang.String-com.aspose.slides.ISlide-android.graphics.PointF-java.util.Date-) को कॉल करता है और प्रस्तुति को सहेजता है। दूसरा चरण पहली चरण के आउटपुट को खोलता है और वही प्रक्रिया दोहराता है।

```java
import com.aspose.slides.ICommentAuthor;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import android.graphics.PointF;
import java.util.Date;

final String authorName = "Reviewer";
final String authorInitials = "RV";

String inputFile = "input.pptx";
PointF position = new PointF(20, 20);

for (int pass = 1; pass <= 2; pass++) {
    Presentation presentation = new Presentation(inputFile);
    try {
        ICommentAuthor[] matches = presentation.getCommentAuthors().findByNameAndInitials(authorName, authorInitials);

        ICommentAuthor author = matches.length > 0 ? matches[0] : presentation.getCommentAuthors().addAuthor(authorName, authorInitials);
        author.getComments().addComment("Please review this slide.", presentation.getSlides().get_Item(0), position, new Date());

        String outputFile = "review_pass_" + pass + ".pptx";
        presentation.save(outputFile, SaveFormat.Pptx);
        inputFile = outputFile;
    } finally {
        presentation.dispose();
    }
}
```

दूसरा चरण एक अतिरिक्त टिप्पणी जोड़ता है बिना किसी अतिरिक्त लेखक को जोड़े या मौजूदा टिप्पणियों को हटाए। अंतिम फ़ाइल `review_pass_2.pptx` नई दोनों टिप्पणियों को मूल टिप्पणियों के साथ रखती है। लेखक को पुनः उपयोग करने से टिप्पणियों का डिडुप्लिकेशन नहीं होता: समान टिप्पणी को बार‑बार जोड़ने से बचने के लिए, जोड़ने से पहले अलग डुप्लिकेट पहचान लागू करें।

## **स्लाइड टिप्पणियों तक पहुँच**

उदाहरण एक मौजूदा प्रस्तुति को खोलता है और [getCommentAuthors](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getCommentAuthors--) द्वारा लौटाई गई संग्रह को पढ़ता है। प्रत्येक लेखक के लिए यह [getComments](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommentauthor/#getComments--) द्वारा लौटाए गए संग्रह पर इटररेट करता है और स्लाइड संख्या, टिप्पणी पाठ, लेखक नाम, तथा निर्माण समय को प्रिंट करता है। इनपुट प्रस्तुति में टिप्पणी होना आवश्यक है ताकि कंसोल आउटपुट उत्पन्न हो सके।

```java
import com.aspose.slides.IComment;
import com.aspose.slides.ICommentAuthor;
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("Comments1.pptx");
try {
    for (ICommentAuthor author : presentation.getCommentAuthors()) {
        for (IComment comment : author.getComments()) {
            System.out.println("Slide: " + comment.getSlide().getSlideNumber());
            System.out.println("Comment: " + comment.getText());
            System.out.println("Author: " + comment.getAuthor().getName());
            System.out.println("Posted at: " + comment.getCreatedTime());
            System.out.println();
        }
    }
} finally {
    presentation.dispose();
}
```

## **टिप्पणियों का उत्तर देना**

एक पैरेंट टिप्पणी वह मूल टिप्पणी है जो उत्तर पदक्रम के शीर्ष पर आती है। [IComment.getParentComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icomment/#getParentComment--) और [IComment.setParentComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icomment/#setParentComment-com.aspose.slides.IComment-) विधियाँ आपको टिप्पणी के पैरेंट को प्राप्त या सेट करने देती हैं।

उदाहरण दो लेखकों से टिप्पणियाँ बनाता है और उत्तर बनाने के लिए [setParentComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icomment/#setParentComment-com.aspose.slides.IComment-) का उपयोग करता है, जिसमें किसी उत्तर का उत्तर भी शामिल है। सभी लेखकों से टिप्पणियाँ प्राप्त करने के लिए [getSlideComments](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#getSlideComments-com.aspose.slides.ICommentAuthor-) को `null` पास किया जाता है; कंसोल प्रत्येक प्रविष्टि को उसकी उत्तर पदक्रम में गहराई के अनुसार इंडेंट करता है। उदाहरण संपूर्ण चर्चा को सहेजता है, पहले मूल टिप्पणी पर [remove](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icomment/#remove--) कॉल करता है, और फिर उस टिप्पणी तथा उसके उत्तरों को हटाए हुए दूसरी प्रस्तुति को सहेजता है।

```java
import com.aspose.slides.IComment;
import com.aspose.slides.ICommentAuthor;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import android.graphics.PointF;
import java.util.Date;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    PointF position = new PointF(10, 10);
    Date createdTime = new Date();

    ICommentAuthor originalAuthor = presentation.getCommentAuthors().addAuthor("Author_1", "A.A.");
    IComment rootComment = originalAuthor.getComments().addComment("comment 1", slide, position, createdTime);

    ICommentAuthor reviewer = presentation.getCommentAuthors().addAuthor("Author_2", "B.B.");
    IComment firstReply = reviewer.getComments().addComment("reply 1 for comment 1", slide, position, createdTime);
    firstReply.setParentComment(rootComment);

    IComment secondReply = reviewer.getComments().addComment("reply 2 for comment 1", slide, position, createdTime);
    secondReply.setParentComment(rootComment);

    IComment subReply = originalAuthor.getComments().addComment("subreply 3 for reply 2", slide, position, createdTime);
    subReply.setParentComment(secondReply);

    reviewer.getComments().addComment("comment 2", slide, position, createdTime);
    IComment separateComment = reviewer.getComments().addComment("comment 3", slide, position, createdTime);

    IComment separateReply = originalAuthor.getComments().addComment("reply 4 for comment 3", slide, position, createdTime);
    separateReply.setParentComment(separateComment);

    IComment[] comments = slide.getSlideComments(null);
    for (int i = 0; i < comments.length; i++) {
        IComment comment = comments[i];
        while (comment.getParentComment() != null) {
            System.out.print("\t");
            comment = comment.getParentComment();
        }

        System.out.println(comments[i].getAuthor().getName() + ": " + comments[i].getText());
    }

    presentation.save("parent_comment.pptx", SaveFormat.Pptx);

    rootComment.remove();
    presentation.save("remove_comment.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert color="warning" title="Warning" %}}
* जब [IComment.remove](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icomment/#remove--) विधि का उपयोग करके टिप्पणी को हटाया जाता है, तो उस टिप्पणी के सभी उत्तर भी हटाए जाते हैं।
* यदि [IComment.setParentComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icomment/#setParentComment-com.aspose.slides.IComment-) एक वर्णात्मक (circular) संदर्भ बनाता है, तो [PptxEditException](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pptxeditexception/) फेंका जाता है।
{{% /alert %}}

## **आधुनिक टिप्पणियाँ जोड़ें**

आधुनिक टिप्पणियों को स्लाइड स्वयं, किसी विशिष्ट आकार, या AutoShape के भीतर किसी टेक्स्ट रेंज से जोड़ा जा सकता है। [ICommentCollection.addModernComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommentcollection/#addModernComment-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-android.graphics.PointF-java.util.Date-) विधि में स्लाइड और टिप्पणी‑मार्कर निर्देशांक के अलावा एक [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) तर्क स्वीकार किया जाता है।

जब आकार तर्क के लिए `null` पास किया जाता है, तो टिप्पणी स्लाइड‑स्तर की टिप्पणी होती है। इसका मार्कर प्रदान किए गए निर्देशांकों द्वारा स्थित किया जाता है, लेकिन यह कोई विशेष आकार से जुड़ा नहीं होता, इसलिए [IModernComment.getShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#getShape--) `null` लौटाता है। जब एक [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) उपलब्ध कराया जाता है, तो टिप्पणी उस आकार से जुड़ी होती है। निर्देशांक अभी भी स्लाइड पर टिप्पणी‑मार्कर की स्थिति निर्धारित करते हैं, जबकि आकार संबद्धता को [IModernComment.getShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#getShape--) के माध्यम से प्राप्त किया जा सकता है।

### **आधुनिक टिप्पणी को आकार (Shape) से जोड़ें**

उदाहरण दो बार [addModernComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommentcollection/#addModernComment-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-android.graphics.PointF-java.util.Date-) को कॉल करता है: एक बार `null` आकार के साथ स्लाइड‑स्तर टिप्पणी के लिये और एक बार आयत को एंकर के रूप में। [getShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#getShape--) को पढ़ने से स्लाइड‑स्तर टिप्पणी के null जांच के लिए `true` और एंकर की गई टिप्पणी के लिए `Revenue title` प्रिंट होता है। दोनों टिप्पणियों को प्रस्तुति के साथ सहेजा जाता है।

```java
import com.aspose.slides.IAutoShape;
import com.aspose.slides.ICommentAuthor;
import com.aspose.slides.IModernComment;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ShapeType;
import android.graphics.PointF;
import java.util.Date;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ICommentAuthor author = presentation.getCommentAuthors().addAuthor("Reviewer", "RV");

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 300, 80);
    shape.setName("Revenue title");
    shape.getTextFrame().setText("Quarterly revenue");

    Date createdTime = new Date();
    PointF slideCommentPosition = new PointF(20, 20);
    PointF shapeCommentPosition = new PointF(60, 60);
    IModernComment slideComment = author.getComments().addModernComment("Review the overall slide layout.", slide, null, slideCommentPosition, createdTime);
    IModernComment shapeComment = author.getComments().addModernComment("Check this title.", slide, shape, shapeCommentPosition, createdTime);

    System.out.println(slideComment.getShape() == null);
    System.out.println(shapeComment.getShape().getName());

    presentation.save("modern_comments.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **विभिन्न आकार प्रकारों से टिप्पणियों को जोड़ें**

कोई भी स्लाइड ऑब्जेक्ट जो [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) को लागू करता है, आकार एंकर के रूप में उपयोग किया जा सकता है। सामान्य उदाहरणों में [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/), [IPictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframe/), [IGroupShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshape/), [IConnector](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iconnector/), तथा चार्ट जैसे [IGraphicalObject](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igraphicalobject/) उदाहरण शामिल हैं।

उदाहरण [addModernComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommentcollection/#addModernComment-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-android.graphics.PointF-java.util.Date-) का उपयोग करके प्रत्येक पाँच आकार प्रकार – AutoShape, चित्र फ़्रेम, ग्रुप, कनेक्टर और चार्ट – के साथ एक टिप्पणी को जोड़ता है। चित्र एम्बेडेड इमेज डेटा का उपयोग करता है, इसलिए कोई बाहरी छवि आवश्यक नहीं है। प्रत्येक टिप्पणी की अपनी मार्कर स्थिति होती है, और सहेजी गई प्रस्तुति सभी पाँच आकार संबद्धताओं को बनाए रखती है।

```java
import com.aspose.slides.ChartType;
import com.aspose.slides.IAutoShape;
import com.aspose.slides.IChart;
import com.aspose.slides.ICommentAuthor;
import com.aspose.slides.IConnector;
import com.aspose.slides.IGroupShape;
import com.aspose.slides.IPPImage;
import com.aspose.slides.IPictureFrame;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ShapeType;
import android.graphics.PointF;
import android.util.Base64;
import java.util.Date;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ICommentAuthor author = presentation.getCommentAuthors().addAuthor("Reviewer", "RV");
    Date createdTime = new Date();

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 180, 60);
    autoShape.getTextFrame().setText("AutoShape");

    PointF autoShapeCommentPosition = new PointF(30, 30);
    author.getComments().addModernComment("Comment on an AutoShape.", slide, autoShape, autoShapeCommentPosition, createdTime);

    String imageBase64 = "iVBORw0KGgoAAAANSUhEUgAAAAIAAAACCAIAAAD91JpzAAAAFklEQVR4nGP8//8/AwMDEwMDAwMDAwAkBgMB/DXemwAAAABJRU5ErkJggg==";
    byte[] imageData = Base64.decode(imageBase64, Base64.DEFAULT);
    IPPImage image = presentation.getImages().addImage(imageData);
    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 220, 20, 120, 80, image);
    PointF pictureCommentPosition = new PointF(230, 30);
    author.getComments().addModernComment("Comment on a picture.", slide, pictureFrame, pictureCommentPosition, createdTime);

    IGroupShape groupShape = slide.getShapes().addGroupShape();
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 80, 40);
    groupShape.getShapes().addAutoShape(ShapeType.Ellipse, 100, 0, 80, 40);
    PointF groupCommentPosition = new PointF(40, 150);
    author.getComments().addModernComment("Comment on a group.", slide, groupShape, groupCommentPosition, createdTime);

    IConnector connector = slide.getShapes().addConnector(ShapeType.StraightConnector1, 220, 150, 140, 40);
    PointF connectorCommentPosition = new PointF(240, 150);
    author.getComments().addModernComment("Comment on a connector.", slide, connector, connectorCommentPosition, createdTime);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 400, 20, 250, 180);
    PointF chartCommentPosition = new PointF(420, 40);
    author.getComments().addModernComment("Comment on a graphical object.", slide, chart, chartCommentPosition, createdTime);

    presentation.save("modern_comment_shape_types.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **टेक्स्ट से टिप्पणी जोड़ें और उसकी स्थिति सेट करें**

एक आधुनिक टिप्पणी जो [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) से जुड़ी है, उसके लिए [IModernComment.getTextSelectionStart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#getTextSelectionStart--) और [IModernComment.setTextSelectionStart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#setTextSelectionStart-int-) चयनित टेक्स्ट की प्रारम्भिक स्थिति तक पहुँच प्रदान करते हैं। [IModernComment.getTextSelectionLength](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#getTextSelectionLength--) और [IModernComment.setTextSelectionLength](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#setTextSelectionLength-int-) चयन की लंबाई तक पहुँच प्रदान करते हैं। ये मान मिलकर टिप्पणी को AutoShape के भीतर विशिष्ट टेक्स्ट रेंज से जोड़ते हैं।

[IModernComment.getStatus](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#getStatus--) और [IModernComment.setStatus](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#setStatus-byte-) विधियाँ [ModernCommentStatus](https://reference.aspose.com/slides/androidjava/com.aspose.slides/moderncommentstatus/) स्थिरांक से एक मान तक पहुँच देती हैं:

- `NotDefined` — कोई विशिष्ट आधुनिक‑टिप्पणी स्थिति परिभाषित नहीं है।
- `Active` — टिप्पणी सक्रिय है।
- `Resolved` — टिप्पणी को हल कर दिया गया है।
- `Closed` — टिप्पणी बंद है।

उदाहरण आयत के टेक्स्ट में “quarterly revenue” शब्दों पर एक आधुनिक टिप्पणी को एंकर करता है। यह टेक्स्ट से शून्य‑आधारित चयन प्रारम्भ निकालता है और उसे [setTextSelectionStart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#setTextSelectionStart-int-) को पास करता है, और चयनित अक्षरों की संख्या को सेट करने के लिये [setTextSelectionLength](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#setTextSelectionLength-int-) का उपयोग करता है। फिर `Resolved` के साथ [setStatus](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#setStatus-byte-) को कॉल करके प्रस्तुति को सहेजता है और पुनः खोलता है। चार कंसोल जांचें क्रमशः `true` प्रिंट करनी चाहिए, यह सत्यापित करने के लिये कि आकार एंकर, टेक्स्ट रेंज, और स्थिति संरक्षित रहे।

```java
import com.aspose.slides.IAutoShape;
import com.aspose.slides.IComment;
import com.aspose.slides.ICommentAuthor;
import com.aspose.slides.IModernComment;
import com.aspose.slides.ISlide;
import com.aspose.slides.ModernCommentStatus;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ShapeType;
import android.graphics.PointF;
import java.util.Date;

String outputFile = "modern_comment_text_anchor.pptx";
String shapeText = "Review the quarterly revenue forecast.";
String selectedText = "quarterly revenue";
int expectedSelectionStart = shapeText.indexOf(selectedText);

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
    shape.setName("Forecast text");
    shape.getTextFrame().setText(shapeText);

    ICommentAuthor author = presentation.getCommentAuthors().addAuthor("Reviewer", "RV");
    PointF commentPosition = new PointF(60, 60);
    IModernComment comment = author.getComments().addModernComment("Verify this forecast wording.", slide, shape, commentPosition, new Date());
    comment.setTextSelectionStart(expectedSelectionStart);
    comment.setTextSelectionLength(selectedText.length());
    comment.setStatus(ModernCommentStatus.Resolved);

    presentation.save(outputFile, SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

Presentation reopenedPresentation = new Presentation(outputFile);
try {
    ISlide reopenedSlide = reopenedPresentation.getSlides().get_Item(0);
    IComment[] reopenedComments = reopenedSlide.getSlideComments(null);

    for (IComment reopenedComment : reopenedComments) {
        if (!(reopenedComment instanceof IModernComment)) {
            continue;
        }

        IModernComment modernComment = (IModernComment) reopenedComment;
        boolean shapeMatches = modernComment.getShape() != null && "Forecast text".equals(modernComment.getShape().getName());
        boolean selectionStartMatches = modernComment.getTextSelectionStart() == expectedSelectionStart;
        boolean selectionLengthMatches = modernComment.getTextSelectionLength() == selectedText.length();
        boolean statusMatches = modernComment.getStatus() == ModernCommentStatus.Resolved;

        System.out.println("Shape anchor preserved: " + shapeMatches);
        System.out.println("Text selection start preserved: " + selectionStartMatches);
        System.out.println("Text selection length preserved: " + selectionLengthMatches);
        System.out.println("Resolved status preserved: " + statusMatches);
    }
} finally {
    reopenedPresentation.dispose();
}
```

### **मौजूदा आधुनिक टिप्पणियों का निरीक्षण करें**

उदाहरण को एक मौजूदा प्रस्तुति की आवश्यकता है जिसमें आधुनिक टिप्पणियाँ हों, और वह उनके पाठ, स्थिति, तथा एंकर विवरण को प्रिंट करता है। इसे निरीक्षण करने के लिये देखें कि कौन‑सी टिप्पणियाँ [IModernComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/) को लागू करती हैं, फिर [IModernComment.getShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#getShape--), [IModernComment.getTextSelectionStart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#getTextSelectionStart--), [IModernComment.getTextSelectionLength](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#getTextSelectionLength--), और [IModernComment.getStatus](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#getStatus--) का निरीक्षण करें। `null` आकार का अर्थ है स्लाइड‑स्तर की टिप्पणी। किसी [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) एंकर के लिये, टेक्स्ट‑सेलेक्शन विधियाँ आकार के टेक्स्ट फ्रेम में सम्बद्ध रेंज को पहचानती हैं।

```java
import com.aspose.slides.IAutoShape;
import com.aspose.slides.IComment;
import com.aspose.slides.IModernComment;
import com.aspose.slides.IShape;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("comments.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        IComment[] comments = slide.getSlideComments(null);
        for (IComment comment : comments) {
            if (!(comment instanceof IModernComment)) {
                continue;
            }

            IModernComment modernComment = (IModernComment) comment;
            System.out.println("Slide: " + slide.getSlideNumber());
            System.out.println("Text: " + modernComment.getText());
            System.out.println("Status: " + modernComment.getStatus());

            IShape shape = modernComment.getShape();
            if (shape == null) {
                System.out.println("Anchor: slide level");
            } else {
                System.out.println("Anchor shape: " + shape.getName());
                System.out.println("Anchor type: " + shape.getClass().getSimpleName());

                if (shape instanceof IAutoShape) {
                    System.out.println("Text selection start: " + modernComment.getTextSelectionStart());
                    System.out.println("Text selection length: " + modernComment.getTextSelectionLength());
                }
            }

            System.out.println();
        }
    }
} finally {
    presentation.dispose();
}
```

## **टिप्पणियाँ हटाएँ**

Aspose.Slides for Android via Java आपको प्रस्तुति से सभी टिप्पणियाँ और उनके लेखकों को हटाने या चयनित टिप्पणियों को हटाते हुए शेष को बनाए रखने की अनुमति देता है। नीचे दिए गए उदाहरण दोनों तरीकों को दर्शाते हैं और अद्यतन प्रस्तुति को सहेजते हैं।

### **सभी टिप्पणियाँ और टिप्पणी लेखकों को हटाएँ**

उदाहरण एक मौजूदा प्रस्तुति को खोलता है और प्रत्येक लेखक के लिये [ICommentCollection.clear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommentcollection/#clear--) को कॉल करता है, फिर लेखकों को हटाने के लिये [ICommentAuthorCollection.clear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommentauthorcollection/#clear--) को कॉल करता है। सहेजा गया प्रेज़ेंटेशन न तो टिप्पणी रखता है न ही टिप्पणी लेखक। हटाने को देखना है तो ऐसी प्रस्तुति का उपयोग करें जिसमें टिप्पणी हों।

```java
import com.aspose.slides.ICommentAuthor;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("example.pptx");
try {
    for (ICommentAuthor author : presentation.getCommentAuthors()) {
        author.getComments().clear();
    }

    presentation.getCommentAuthors().clear();

    presentation.save("example_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **विशिष्ट टिप्पणियाँ हटाएँ**

उदाहरण एक ही स्लाइड पर दो टिप्पणियाँ बनाता है और प्रत्येक लेखक द्वारा टिप्पणियों को खोजने के लिये [getSlideComments](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#getSlideComments-com.aspose.slides.ICommentAuthor-) का उपयोग करता है। यह उन टिप्पणियों को इकट्ठा करता है जिनका पाठ “comment 1” के बराबर है, फिर [ICommentCollection.remove](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommentcollection/#remove-com.aspose.slides.IComment-) को कॉल करता है, जिससे चयन के दौरान संग्रह में परिवर्तन नहीं होता। सहेजा गया प्रेज़ेंटेशन केवल “comment 2” को रखता है।

```java
import com.aspose.slides.IComment;
import com.aspose.slides.ICommentAuthor;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import android.graphics.PointF;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ICommentAuthor author = presentation.getCommentAuthors().addAuthor("Author", "A");
    Date createdTime = new Date();

    PointF firstCommentPosition = new PointF(0.2f, 0.2f);
    PointF secondCommentPosition = new PointF(0.3f, 0.2f);
    author.getComments().addComment("comment 1", slide, firstCommentPosition, createdTime);
    author.getComments().addComment("comment 2", slide, secondCommentPosition, createdTime);

    for (ICommentAuthor commentAuthor : presentation.getCommentAuthors()) {
        List<IComment> commentsToRemove = new ArrayList<IComment>();
        IComment[] comments = slide.getSlideComments(commentAuthor);

        for (IComment comment : comments) {
            if ("comment 1".equals(comment.getText())) {
                commentsToRemove.add(comment);
            }
        }

        for (IComment comment : commentsToRemove) {
            commentAuthor.getComments().remove(comment);
        }
    }

    presentation.save("pres.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या Aspose.Slides आधुनिक टिप्पणियों के लिए resolved स्थिति का समर्थन करता है?**

हाँ। [IModernComment.getStatus](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#getStatus--) और [IModernComment.setStatus](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#setStatus-byte-) एक [ModernCommentStatus](https://reference.aspose.com/slides/androidjava/com.aspose.slides/moderncommentstatus/) मान तक पहुँच प्रदान करते हैं, जिसमें `Resolved` भी शामिल है। स्थिति प्रस्तुति में संग्रहीत रहती है और फ़ाइल को पुनः खोलने के बाद फिर से पढ़ी जा सकती है।

**क्या थ्रेडेड चर्चाएँ (उत्तर शृंखलाएँ) समर्थित हैं, तथा क्या कोई नेस्टिंग सीमा है?**

हाँ। प्रत्येक टिप्पणी अपने [parent comment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icomment/#getParentComment--) को संदर्भित कर सकती है, जिससे उत्तर शृंखलाएँ बनती हैं। API में कोई विशिष्ट नेस्टिंग‑गहराई सीमा परिभाषित नहीं है।

**स्लाइड पर टिप्पणी‑मार्कर की स्थिति किस निर्देशांक प्रणाली में परिभाषित है?**

मार्कर की स्थिति स्लाइड के निर्देशांक प्रणाली में फ्लोटिंग‑पॉइंट निर्देशांक द्वारा परिभाषित होती है, जिससे आप इसे सटीक रूप से स्लाइड पर रख सकते हैं।