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
- प्रस्तुति टिप्पणी
- स्लाइड टिप्पणियाँ
- टिप्पणी जोड़ें
- टिप्पणी तक पहुँचें
- टिप्पणी संपादित करें
- टिप्पणी का उत्तर
- टिप्पणी हटाएँ
- टिप्पणी मिटाएँ
- PowerPoint
- OpenDocument
- प्रस्तुति
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java के साथ प्रस्तुति टिप्पणियों को प्रबंधित करें: PowerPoint फ़ाइलों में टिप्पणियों को तेज़ी से और सरलता से जोड़ें, पढ़ें, संपादित करें और हटाएँ।"
---
## **अवलोकन**

यह लेख Aspose.Slides में प्रस्तुति टिप्पणियों को प्रबंधित करने के तरीके को समझाता है। यह मुख्य टिप्पणी‑संबंधित प्रकारों को दिखाता है और स्लाइड में टिप्पणियाँ जोड़ने, मौजूदा टिप्पणियों तक पहुँचने, उत्तरों के साथ काम करने, आधुनिक टिप्पणियों का उपयोग करने, और प्रस्तुति से टिप्पणियों को हटाने का प्रदर्शन करता है।

उदाहरण सामान्य समीक्षा और सहयोग परिदृश्यों पर केंद्रित हैं, जैसे कि लेखकों को टिप्पणियाँ आवंटित करना, टिप्पणी सामग्री और मेटा‑डेटा पढ़ना, उत्तर श्रृंखलाएँ बनाना, और सभी टिप्पणियों को साफ़ करना या चयनित को हटाना।

PowerPoint में, एक टिप्पणी स्लाइड पर नोट या एनोटेशन के रूप में दिखाई देती है। जब टिप्पणी पर क्लिक किया जाता है, तो उसकी सामग्री या संदेश प्रकट होते हैं।

### **प्रस्तुतियों में टिप्पणियाँ क्यों जोड़ें?**

आप प्रस्तुतियों की समीक्षा करते समय प्रतिक्रिया देने या अपने सहयोगियों के साथ संवाद करने के लिए टिप्पणियों का उपयोग करना चाहते हो सकते हैं।

PowerPoint प्रस्तुतियों में टिप्पणियों के उपयोग की सुविधा देने के लिए, Aspose.Slides for Android via Java प्रदान करता है

* The [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Presentation) क्लास, जिसमें लेखकों का संग्रह होता है (जो [ICommentAuthorCollection](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ICommentAuthorCollection) इंटरफ़ेस से आता है)। लेखक स्लाइड में टिप्पणियाँ जोड़ते हैं।
* The  [ICommentCollection](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ICommentCollection) इंटरफ़ेस, जिसमें व्यक्तिगत लेखकों के लिए टिप्पणियों का संग्रह होता है।
* The  [IComment](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IComment) क्लास, जिसमें लेखकों और उनकी टिप्पणियों की जानकारी होती है: टिप्पणी कौन जोड़ता है, टिप्पणी कब जोड़ी गई, टिप्पणी की स्थिति, आदि।
* The [CommentAuthor](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/CommentAuthor) क्लास, जिसमें व्यक्तिगत लेखकों की जानकारी होती है: लेखक का नाम, उसके प्रारम्भिक अक्षर, लेखक के नाम से जुड़ी टिप्पणियाँ, आदि।

## **स्लाइड टिप्पणी जोड़ें**
यह Java कोड दिखाता है कि PowerPoint प्रस्तुति की स्लाइड में टिप्पणी कैसे जोड़ी जाए:

```java
// Presentation क्लास का इंस्टैंसिएशन करता है
Presentation pres = new Presentation();
try {
    // एक खाली स्लाइड जोड़ता है
    pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

    // एक लेखक जोड़ता है
    ICommentAuthor author = pres.getCommentAuthors().addAuthor("Jawad", "MF");

    // टिप्पणियों के लिए स्थिति सेट करता है
    Point2D.Float point = new Point2D.Float(0.2f, 0.2f);

    // स्लाइड 1 पर लेखक के लिए स्लाइड टिप्पणी जोड़ता है
    author.getComments().addComment("Hello Jawad, this is slide comment", pres.getSlides().get_Item(0), point, new Date());

    // स्लाइड 2 पर लेखक के लिए स्लाइड टिप्पणी जोड़ता है
    author.getComments().addComment("Hello Jawad, this is second slide comment", pres.getSlides().get_Item(1), point, new Date());

    // ISlide 1 तक पहुँचता है
    ISlide slide = pres.getSlides().get_Item(0);

    // जब null को तर्क के रूप में पास किया जाता है, तो सभी लेखकों की टिप्पणियाँ चयनित स्लाइड पर लाई जाती हैं
    IComment[] Comments = slide.getSlideComments(author);

    // स्लाइड 1 के लिए इंडेक्स 0 पर टिप्पणी तक पहुँचता है
    String str = Comments[0].getText();

    pres.save("Comments_out.pptx", SaveFormat.Pptx);

    if (Comments.length > 0)
    {
        // इंडेक्स 0 पर लेखक की टिप्पणी संग्रह चुनता है
        ICommentCollection commentCollection = Comments[0].getAuthor().getComments();
        String Comment = commentCollection.get_Item(0).getText();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **स्लाइड टिप्पणियों तक पहुँचें**
यह Java कोड दिखाता है कि PowerPoint प्रस्तुति की स्लाइड में मौजूद टिप्पणी तक कैसे पहुँचा जाए:

```java
// Presentation क्लास को इंस्टैंसिएट करता है
Presentation pres = new Presentation("Comments1.pptx");
try {
    for (ICommentAuthor commentAuthor : pres.getCommentAuthors())
    {
        CommentAuthor author = (CommentAuthor) commentAuthor;
        for (IComment comment1 : author.getComments())
        {
            Comment comment = (Comment) comment1;
            System.out.println("ISlide :" + comment.getSlide().getSlideNumber() + " has comment: " + comment.getText() +
                    " with Author: " + comment.getAuthor().getName() + " posted on time :" + comment.getCreatedTime() + "\n");
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **टिप्पणियों का उत्तर देना**
एक पैरेंट टिप्पणी वह शीर्ष या मूल टिप्पणी है जो टिप्पणी या उत्तरों के पदानुक्रम में होती है। [getParentComment](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IComment#getParentComment--) या [setParentComment](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IComment#setParentComment-com.aspose.slides.IComment-) मेथड्स (जो [IComment](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IComment) इंटरफ़ेस से हैं) का उपयोग करके आप पैरेंट टिप्पणी सेट या प्राप्त कर सकते हैं।

यह Java कोड दिखाता है कि टिप्पणियाँ कैसे जोड़ें और उनके उत्तर कैसे प्राप्त करें:

```java
Presentation pres = new Presentation();
try {
    // एक टिप्पणी जोड़ता है
    ICommentAuthor author1 = pres.getCommentAuthors().addAuthor("Author_1", "A.A.");
    IComment comment1 = author1.getComments().addComment("comment1", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());

    // टिप्पणी1 के लिए उत्तर जोड़ता है
    ICommentAuthor author2 = pres.getCommentAuthors().addAuthor("Autror_2", "B.B.");
    IComment reply1 = author2.getComments().addComment("reply 1 for comment 1", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());
    reply1.setParentComment(comment1);

    // टिप्पणी1 के लिए दूसरा उत्तर जोड़ता है
    IComment reply2 = author2.getComments().addComment("reply 2 for comment 1", pres.getSlides().get_Item(0),  new Point2D.Float(10, 10), new Date());
    reply2.setParentComment(comment1);

    // मौजूदा उत्तर में एक उत्तर जोड़ता है
    IComment subReply = author1.getComments().addComment("subreply 3 for reply 2", pres.getSlides().get_Item(0),  new Point2D.Float(10, 10), new Date());
    subReply.setParentComment(reply2);

    IComment comment2 = author2.getComments().addComment("comment 2", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());
    IComment comment3 = author2.getComments().addComment("comment 3", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());

    IComment reply3 = author1.getComments().addComment("reply 4 for comment 3", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());
    reply3.setParentComment(comment3);

    // कंसोल पर टिप्पणी पदानुक्रम दिखाता है
    ISlide slide = pres.getSlides().get_Item(0);
    IComment[] comments = slide.getSlideComments(null);
    for (int i = 0; i < comments.length; i++)
    {
        IComment comment = comments[i];
        while (comment.getParentComment() != null)
        {
            System.out.print("\t");
            comment = comment.getParentComment();
        }

        System.out.println(comments[i].getAuthor().getName() +  " : " + comments[i].getText());
        System.out.println();
    }
    pres.save("parent_comment.pptx",SaveFormat.Pptx);

    // टिप्पणी1 और उसकी सभी उत्तरों को हटाता है
    comment1.remove();

    pres.save("remove_comment.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="warning" title="Attention" %}} 
* जब [Remove](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IComment#remove--) मेथड (जो [IComment](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IComment) इंटरफ़ेस से है) का उपयोग टिप्पणी हटाने के लिए किया जाता है, तो टिप्पणी के उत्तर भी हटाए जाते हैं।
* यदि [setParentComment](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IComment#setParentComment-com.aspose.slides.IComment-) सेटिंग से सर्कुलर रेफ़रेंस बनता है, तो [PptxEditException](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/PptxEditException) फेंका जाएगा।
{{% /alert %}}

## **आधुनिक टिप्पणी जोड़ें**

2021 में, Microsoft ने PowerPoint में *आधुनिक टिप्पणियाँ* पेश कीं। आधुनिक टिप्पणियाँ फीचर PowerPoint में सहयोग को काफी सुधारता है। आधुनिक टिप्पणियों के माध्यम से, PowerPoint उपयोगकर्ता टिप्पणियों को हल कर सकते हैं, टिप्पणियों को वस्तुओं और पाठों से जोड़ सकते हैं, और इंटरैक्शन को पहले से बहुत आसान बना सकते हैं।

Aspose.Slides आधुनिक टिप्पणियों को [ModernComment](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ModernComment) क्लास द्वारा समर्थन देता है। [addModernComment](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/CommentCollection#addModernComment-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-java.awt.geom.Point2D.Float-java.util.Date-) और [insertModernComment](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/CommentCollection#insertModernComment-int-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-java.awt.geom.Point2D.Float-java.util.Date-) मेथड्स को [CommentCollection](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/CommentCollection) क्लास में जोड़ा गया है।

यह Java कोड दिखाता है कि PowerPoint प्रस्तुति की स्लाइड में आधुनिक टिप्पणी कैसे जोड़ें:

```java
Presentation pres = new Presentation();
try {
    ICommentAuthor newAuthor = pres.getCommentAuthors().addAuthor("Some Author", "SA");
    IModernComment modernComment = newAuthor.getComments().addModernComment("This is a modern comment", pres.getSlides().get_Item(0), null, new Point2D.Float(100, 100), new Date());

    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **टिप्पणी हटाएँ**

### **सभी टिप्पणियों और लेखकों को हटाएँ**

यह Java कोड दिखाता है कि प्रस्तुति में सभी टिप्पणियों और लेखकों को कैसे हटाया जाए:

```java
Presentation presentation = new Presentation("example.pptx");
try {
    // प्रस्तुति से सभी टिप्पणियों को हटाता है
    for (ICommentAuthor author : presentation.getCommentAuthors())
    {
        author.getComments().clear();
    }

    // सभी लेखकों को हटाता है
    presentation.getCommentAuthors().clear();

    presentation.save("example_out.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

### **विशिष्ट टिप्पणियों को हटाएँ**

यह Java कोड दिखाता है कि स्लाइड पर विशिष्ट टिप्पणियों को कैसे हटाया जाए:

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // टिप्पणियाँ जोड़ें...
    ICommentAuthor author = presentation.getCommentAuthors().addAuthor("Author", "A");
    author.getComments().addComment("comment 1", slide, new Point2D.Float(0.2f, 0.2f), new Date());
    author.getComments().addComment("comment 2", slide, new Point2D.Float(0.3f, 0.2f), new Date());

    // सभी टिप्पणियों को हटाएँ जिनमें "comment 1" टेक्स्ट शामिल है
    for (ICommentAuthor commentAuthor : presentation.getCommentAuthors())
    {
        ArrayList<IComment> toRemove = new ArrayList<IComment>();
        for (IComment comment : slide.getSlideComments(commentAuthor))
        {
            if (comment.getText().equals("comment 1"))
            {
                toRemove.add(comment);
            }
        }

        for (IComment comment : toRemove)
        {
            commentAuthor.getComments().remove(comment);
        }
    }

    presentation.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **FAQ**

**क्या Aspose.Slides आधुनिक टिप्पणियों के लिए 'resolved' जैसी स्थिति का समर्थन करता है?**

हां। [Modern comments](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/moderncomment/) में एक [setStatus](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/moderncomment/#setStatus-byte-) मेथड उपलब्ध है; आप एक [comment’s state](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/moderncommentstatus/) (उदाहरण के लिए, इसे हल किया हुआ चिह्नित) लिख सकते हैं, और यह स्थिति फ़ाइल में संग्रहीत रहती है तथा PowerPoint द्वारा पहचानी जाती है।

**क्या थ्रेडेड डिस्कशन (उत्तर श्रृंखलाएँ) समर्थित हैं, और क्या कोई नेस्टिंग सीमा है?**

हां। प्रत्येक टिप्पणी अपने [parent comment](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/comment/#getParentComment--) का संदर्भ दे सकती है, जिससे अनियमित उत्तर श्रृंखलाएँ बनती हैं। API ने कोई विशिष्ट नेस्टिंग गहराई सीमा निर्धारित नहीं की है।

**स्लाइड पर टिप्पणी मार्कर की स्थिति किस निर्देशांक प्रणाली में परिभाषित होती है?**

स्थिति स्लाइड की निर्देशांक प्रणाली में एक फ्लोटिंग‑पॉइंट बिंदु के रूप में संग्रहीत होती है। यह आपको टिप्पणी मार्कर को ठीक उसी स्थान पर रखने की अनुमति देता है जहाँ आवश्यक हो।