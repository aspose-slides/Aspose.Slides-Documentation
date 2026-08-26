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
- टिप्पणी पहुंचें
- टिप्पणी संपादित करें
- टिप्पणी का उत्तर दें
- टिप्पणी हटाएँ
- टिप्पणी हटाएँ
- PowerPoint
- प्रस्तुति
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java के साथ प्रस्तुति टिप्पणियों को प्रबंधित करें: PowerPoint प्रस्तुतियों में टिप्पणियों को जल्दी और आसानी से जोड़ें, पढ़ें, संपादित करें, उत्तर दें और हटाएँ।"
---
## **अवलोकन**

यह लेख Aspose.Slides for Android via Java के साथ प्रस्तुति टिप्पणियों को प्रबंधित करने का तरीका समझाता है। यह मुख्य टिप्पणी-संबंधित प्रकारों का परिचय देता है और स्लाइड्स में टिप्पणियों को जोड़ने, मौजूद टिप्पणियों तक पहुंचने, उत्तरों और आधुनिक टिप्पणियों के साथ काम करने, तथा प्रस्तुति से टिप्पणियों को हटाने के तरीकों को दर्शाता है।

उदाहरण सामान्य समीक्षा और सहयोग परिदृश्यों को कवर करते हैं, जैसे लेखकों को टिप्पणियाँ असाइन करना, टिप्पणी पाठ और मेटाडेटा पढ़ना, उत्तर श्रृंखलाएँ बनाना, और चयनित टिप्पणियों या सभी टिप्पणियों को हटाना।

PowerPoint में, टिप्पणियाँ स्लाइड्स पर एनोटेशन के रूप में दिखाई देती हैं। टिप्पणी का चयन करने पर उसका पाठ और संबंधित चर्चा प्रदर्शित होती है।

## **प्रस्तुतियों में टिप्पणी क्यों जोड़ें?**

आप प्रस्तुतियों की समीक्षा करते समय प्रतिक्रिया प्रदान करने और सहयोगियों के साथ सहयोग करने के लिए टिप्पणियों का उपयोग कर सकते हैं।

Aspose.Slides for Android via Java टिप्पणियों के साथ काम करने के लिए निम्नलिखित APIs प्रदान करता है:

* The [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) class, जो प्रस्तुतिकरण के टिप्पणी लेखकों तक पहुंच प्रदान करता है।
* The [ICommentCollection](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/icommentcollection/) interface, जो व्यक्तिगत लेखक से जुड़ी टिप्पणियों का प्रतिनिधित्व करती है।
* The [IComment](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/icomment/) interface, जो टिप्पणी के बारे में जानकारी प्रदान करती है, जिसमें लेखक, निर्माण समय, स्थिति और पाठ शामिल है।
* The [CommentAuthor](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/commentauthor/) class, जो लेखक के बारे में जानकारी देती है, जिसमें उनका नाम, प्रारंभिक अक्षर, और संबंधित टिप्पणियाँ शामिल हैं।

## **स्लाइड टिप्पणियाँ जोड़ें**

निम्नलिखित उदाहरण दिखाता है कि PowerPoint प्रस्तुति में स्लाइड्स में टिप्पणियाँ कैसे जोड़ें:

```java
import com.aspose.slides.IComment;
import com.aspose.slides.ICommentAuthor;
import com.aspose.slides.ICommentCollection;
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

        ICommentCollection authorComments = firstComment.getAuthor().getComments();
        String commentText = authorComments.get_Item(0).getText();
        System.out.println(commentText);
    }

    presentation.save("Comments_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **स्लाइड टिप्पणियों तक पहुंचें**

निम्नलिखित उदाहरण दिखाता है कि PowerPoint प्रस्तुति में मौजूद टिप्पणियों तक कैसे पहुंचें:

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

## **टिप्पणियों का उत्तर दें**

एक पैरेंट टिप्पणी वह मूल टिप्पणी है जो उत्तर पदानुक्रम के शीर्ष पर स्थित होती है। [IComment.getParentComment](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/icomment/#getParentComment--) और [IComment.setParentComment](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/icomment/#setParentComment-com.aspose.slides.IComment-) मेथड आपको टिप्पणी के पैरेंट को प्राप्त या सेट करने की अनुमति देते हैं।

निम्नलिखित उदाहरण दिखाता है कि उत्तर कैसे जोड़ें और प्राप्त टिप्पणी पदानुक्रम की जाँच कैसे करें:

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

    ICommentAuthor author1 = presentation.getCommentAuthors().addAuthor("Author_1", "A.A.");
    IComment comment1 = author1.getComments().addComment("comment 1", slide, position, createdTime);

    ICommentAuthor author2 = presentation.getCommentAuthors().addAuthor("Author_2", "B.B.");
    IComment reply1 = author2.getComments().addComment("reply 1 for comment 1", slide, position, createdTime);
    reply1.setParentComment(comment1);

    IComment reply2 = author2.getComments().addComment("reply 2 for comment 1", slide, position, createdTime);
    reply2.setParentComment(comment1);

    IComment subReply = author1.getComments().addComment("subreply 3 for reply 2", slide, position, createdTime);
    subReply.setParentComment(reply2);

    author2.getComments().addComment("comment 2", slide, position, createdTime);
    IComment comment3 = author2.getComments().addComment("comment 3", slide, position, createdTime);

    IComment reply3 = author1.getComments().addComment("reply 4 for comment 3", slide, position, createdTime);
    reply3.setParentComment(comment3);

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

    comment1.remove();
    presentation.save("remove_comment.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert color="warning" title="चेतावनी" %}}
* जब [IComment.remove](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/icomment/#remove--) मेथड का उपयोग करके टिप्पणी हटाई जाती है, तो उस टिप्पणी के सभी उत्तर भी हटाए जाते हैं।
* यदि [IComment.setParentComment](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/icomment/#setParentComment-com.aspose.slides.IComment-) एक चक्रीय संदर्भ बनाता है, तो एक [PptxEditException](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/pptxeditexception/) फेंका जाता है।
{{% /alert %}}

## **आधुनिक टिप्पणियाँ जोड़ें**

आधुनिक टिप्पणियाँ स्लाइड स्वयं, किसी विशिष्ट आकार, या AutoShape के भीतर एक टेक्स्ट रेंज से जुड़ी हो सकती हैं। [ICommentCollection.addModernComment](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/icommentcollection/#addModernComment-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-android.graphics.PointF-java.util.Date-) मेथड स्लाइड और टिप्पणी‑मार्कर निर्देशांक के अतिरिक्त एक [IShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ishape/) तर्क स्वीकार करता है।

जब `null` को shape तर्क के रूप में पास किया जाता है, तो टिप्पणी स्लाइड‑स्तर की टिप्पणी होती है। इसका मार्कर प्रदान की गई निर्देशांक द्वारा स्थित होता है, लेकिन यह किसी विशेष आकार से जुड़ी नहीं होती, इसलिए [IModernComment.getShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/imoderncomment/#getShape--) `null` लौटाता है। जब एक [IShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ishape/) प्रदान किया जाता है, तो टिप्पणी उस आकार से जुड़ी होती है। निर्देशांक अभी भी स्लाइड पर टिप्पणी मार्कर की स्थिति निर्धारित करते हैं, जबकि आकार संबंध को [IModernComment.getShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/imoderncomment/#getShape--) के माध्यम से प्राप्त किया जा सकता है।

### **आधुनिक टिप्पणी को आकृति पर एंकर करें**

निम्नलिखित उदाहरण एक स्लाइड‑स्तर की आधुनिक टिप्पणी और एक विशिष्ट AutoShape से एंकर की गई आधुनिक टिप्पणी बनाता है। फिर यह प्रत्येक टिप्पणी से जुड़ी आकृति को पढ़ता है।

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

### **विभिन्न आकृति प्रकारों के लिए टिप्पणियों को एंकर करें**

कोई भी स्लाइड ऑब्जेक्ट जो [IShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ishape/) को लागू करता है, उसे आकार एंकर के रूप में उपयोग किया जा सकता है। सामान्य उदाहरणों में [IAutoShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iautoshape/), [IPictureFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipictureframe/), [IGroupShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/igroupshape/), [IConnector](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iconnector/), और चार्ट जैसे [IGraphicalObject](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/igraphicalobject/) उदाहरण शामिल हैं।

निम्नलिखित उदाहरण कई सामान्य आकार प्रकार बनाता है और प्रत्येक के साथ एक आधुनिक टिप्पणी जोड़ता है।

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
import java.util.Base64;
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
    byte[] imageData = Base64.getDecoder().decode(imageBase64);
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

### **टिप्पणी को पाठ पर एंकर करें और उसकी स्थिति सेट करें**

एक [IAutoShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iautoshape/) से जुड़ी आधुनिक टिप्पणी के लिए, [IModernComment.getTextSelectionStart](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/imoderncomment/#getTextSelectionStart--) और [IModernComment.setTextSelectionStart](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/imoderncomment/#setTextSelectionStart-int-) आकार के टेक्स्ट फ्रेम में चयनित पाठ की प्रारंभिक स्थिति तक पहुंचते हैं। [IModernComment.getTextSelectionLength](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/imoderncomment/#getTextSelectionLength--) और [IModernComment.setTextSelectionLength](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/imoderncomment/#setTextSelectionLength-int-) चयन की लंबाई तक पहुंचते हैं। ये मान मिलकर टिप्पणी को AutoShape के भीतर एक विशिष्ट टेक्स्ट रेंज से जोड़ते हैं।

[IModernComment.getStatus](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/imoderncomment/#getStatus--) और [IModernComment.setStatus](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/imoderncomment/#setStatus-byte-) मेथड [ModernCommentStatus](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/moderncommentstatus/) स्थिरांक से एक मान तक पहुंचते हैं:

- `NotDefined` — कोई विशिष्ट आधुनिक‑टिप्पणी स्थिति निर्धारित नहीं की गई है।
- `Active` — टिप्पणी सक्रिय है।
- `Resolved` — टिप्पणी हल कर दी गई है।
- `Closed` — टिप्पणी बंद है।

निम्नलिखित उदाहरण एक आकार‑एंकर वाली आधुनिक टिप्पणी बनाता है, इसे टेक्स्ट चयन से जोड़ता है, इसे हल की गई के रूप में चिह्नित करता है, प्रस्तुति सहेजता है, और फ़ाइल पुनः खोलने के बाद मानों की जाँच करता है।

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

### **मौजूदा आधुनिक टिप्पणियों की जाँच करें**

किसी मौजूदा प्रस्तुति की जाँच करने के लिए, देखें कि कौन सी टिप्पणियाँ [IModernComment](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/imoderncomment/) को लागू करती हैं, फिर [IModernComment.getShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/imoderncomment/#getShape--), [IModernComment.getTextSelectionStart](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/imoderncomment/#getTextSelectionStart--), [IModernComment.getTextSelectionLength](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/imoderncomment/#getTextSelectionLength--), और [IModernComment.getStatus](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/imoderncomment/#getStatus--) को देखें। `null` आकार एक स्लाइड‑स्तर की टिप्पणी दर्शाता है। किसी [IAutoShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iautoshape/) एंकर के लिए, टेक्स्ट‑सेलेक्शन मेथड आकार के टेक्स्ट फ्रेम में संबंधित रेंज की पहचान करते हैं।

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

## **टिप्पणियों को हटाएँ**

### **सभी टिप्पणियों और टिप्पणी लेखकों को हटाएँ**

निम्नलिखित उदाहरण दर्शाता है कि प्रस्तुति से सभी टिप्पणियों और टिप्पणी लेखकों को कैसे हटाएँ:

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

### **विशिष्ट टिप्पणियों को हटाएँ**

निम्नलिखित उदाहरण दर्शाता है कि स्लाइड से विशिष्ट टिप्पणियों को कैसे हटाएँ:

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

**क्या Aspose.Slides आधुनिकी टिप्पणी के लिए हल की गई स्थिति का समर्थन करता है?**

हाँ। [IModernComment.getStatus](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/imoderncomment/#getStatus--) और [IModernComment.setStatus](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/imoderncomment/#setStatus-byte-) एक [ModernCommentStatus](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/moderncommentstatus/) मान तक पहुंचते हैं, जिसमें `Resolved` शामिल है। स्थिति प्रस्तुति में संग्रहीत होती है और फ़ाइल पुनः खोलने के बाद फिर से पढ़ी जा सकती है।

**क्या थ्रेडेड चर्चाएँ (उत्तर श्रृंखला) समर्थित हैं, और क्या कोई नेस्टिंग सीमा है?**

हाँ। प्रत्येक टिप्पणी अपने [parent comment](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/icomment/#getParentComment--) को संदर्भित कर सकती है, जिससे उत्तर श्रृंखलाएँ संभव होती हैं। API में कोई विशिष्ट नेस्टिंग‑गहराई सीमा निर्धारित नहीं की गई है।

**किस निर्देशांक प्रणाली में स्लाइड पर टिप्पणी मार्कर की स्थिति परिभाषित की गई है?**

मार्कर की स्थिति स्लाइड निर्देशांक प्रणाली में फ्लोटिंग‑पॉइंट निर्देशांक द्वारा परिभाषित की गई है, जिससे आप इसे स्लाइड पर सटीक रूप से रख सकते हैं।