---
title: जावा में प्रस्तुति टिप्पणियों को प्रबंधित करें
linktitle: प्रस्तुति टिप्पणियाँ
type: docs
weight: 100
url: /hi/java/presentation-comments/
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
- Java
- Aspose.Slides
description: "Aspose.Slides for Java के साथ प्रस्तुति टिप्पणियों में महारत हासिल करें: PowerPoint फ़ाइलों में टिप्पणियाँ तेज़ी और आसानी से जोड़ें, पढ़ें, संपादित करें और हटाएँ।"
---
## **अवलोकन**

यह लेख Aspose.Slides में प्रस्तुति टिप्पणी (presentation comments) को प्रबंधित करने का तरीका बताता है। यह मुख्य टिप्पणी‑संबंधित प्रकारों को दिखाता है और स्लाइड्स में टिप्पणी जोड़ने, मौजूदा टिप्पणियों तक पहुँचने, उत्तरों के साथ काम करने, आधुनिक टिप्पणियों (modern comments) का उपयोग करने और प्रस्तुति से टिप्पणियाँ हटाने का प्रदर्शन करता है।

उदाहरण सामान्य समीक्षा और सहयोग परिदृश्यों पर केंद्रित हैं, जैसे कि लेखकों को टिप्पणी असाइन करना, टिप्पणी की सामग्री और मेटाडेटा पढ़ना, उत्तर श्रृंखलाएँ बनाना, तथा सभी टिप्पणियों को साफ़ करना या चयनित टिप्पणियों को हटाना।

PowerPoint में, टिप्पणी स्लाइड पर नोट या एनोटेशन के रूप में दिखाई देती है। जब टिप्पणी पर क्लिक किया जाता है, तो उसकी सामग्री या संदेश प्रदर्शित होते हैं।

## **प्रस्तुतियों में टिप्पणी क्यों जोड़ें?**

आप प्रस्तुतियों की समीक्षा करते समय प्रतिक्रिया देने या सहयोगियों के साथ संपर्क स्थापित करने के लिए टिप्पणी का उपयोग करना चाह सकते हैं।

PowerPoint प्रस्तुतियों में टिप्पणी का उपयोग करने के लिए, Aspose.Slides for Java प्रदान करता है:

* वह [प्रस्तुति](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation) क्लास, जिसमें लेखकों के संग्रह ([ICommentAuthorCollection](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ICommentAuthorCollection) इंटरफ़ेस) होते हैं। लेखक स्लाइड्स पर टिप्पणी जोड़ते हैं।  
* वह [ICommentCollection](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ICommentCollection) इंटरफ़ेस, जिसमें व्यक्तिगत लेखकों के लिए टिप्पणी का संग्रह रहता है।  
* वह [IComment](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IComment) क्लास, जिसमें लेखकों और उनकी टिप्पणियों की जानकारी होती है: किसने टिप्पणी जोड़ी, टिप्पणी कब जोड़ी गई, टिप्पणी की स्थिति आदि।  
* वह [CommentAuthor](https://reference.aspose.com/slides/hi/java/com.aspose.slides/CommentAuthor) क्लास, जिसमें व्यक्तिगत लेखकों की जानकारी रहती है: लेखक का नाम, उनके शुरुआती अक्षर, लेखक के नाम से जुड़ी टिप्पणियाँ आदि।  

## **स्लाइड टिप्पणियाँ जोड़ें**
यह Java कोड दिखाता है कि PowerPoint प्रस्तुति में स्लाइड पर टिप्पणी कैसे जोड़ें:

```java
// Presentation क्लास को इंस्टैंशिएट करता है
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

    // जब तर्क के रूप में null पास किया जाता है, तो सभी लेखकों की टिप्पणियां चयनित स्लाइड में लाई जाती हैं
    IComment[] Comments = slide.getSlideComments(author);

    // स्लाइड 1 के लिए इंडेक्स 0 पर टिप्पणी तक पहुँचता है
    String str = Comments[0].getText();

    pres.save("Comments_out.pptx", SaveFormat.Pptx);

    if (Comments.length > 0)
    {
        // इंडेक्स 0 पर लेखक की टिप्पणी संग्रह को चुनता है
        ICommentCollection commentCollection = Comments[0].getAuthor().getComments();
        String Comment = commentCollection.get_Item(0).getText();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **स्लाइड टिप्पणियों तक पहुँचें**
यह Java कोड दिखाता है कि PowerPoint प्रस्तुति में स्लाइड पर मौजूदा टिप्पणी तक कैसे पहुँचें:

```java
// Presentation क्लास को इंस्टैंशिएट करता है
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

## **टिप्पणियों का उत्तर दें**
एक मूल (parent) टिप्पणी वह शीर्ष या मूल टिप्पणी होती है जिसके नीचे उत्तर या अन्य टिप्पणी पदानुक्रमित होते हैं। आप [getParentComment](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IComment#getParentComment--) या [setParentComment](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IComment#setParentComment-com.aspose.slides.IComment-) विधियों (जो [IComment](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IComment) इंटरफ़ेस में हैं) का उपयोग करके मूल टिप्पणी सेट या प्राप्त कर सकते हैं।

यह Java कोड दर्शाता है कि टिप्पणी कैसे जोड़ें और उनके उत्तर कैसे प्राप्त करें:

```java
Presentation pres = new Presentation();
try {
    // एक टिप्पणी जोड़ता है
    ICommentAuthor author1 = pres.getCommentAuthors().addAuthor("Author_1", "A.A.");
    IComment comment1 = author1.getComments().addComment("comment1", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());

    // comment1 के लिए उत्तर जोड़ता है
    ICommentAuthor author2 = pres.getCommentAuthors().addAuthor("Autror_2", "B.B.");
    IComment reply1 = author2.getComments().addComment("reply 1 for comment 1", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());
    reply1.setParentComment(comment1);

    // comment1 के लिए एक और उत्तर जोड़ता है
    IComment reply2 = author2.getComments().addComment("reply 2 for comment 1", pres.getSlides().get_Item(0),  new Point2D.Float(10, 10), new Date());
    reply2.setParentComment(comment1);

    // मौजूदा उत्तर के लिए एक उत्तर जोड़ता है
    IComment subReply = author1.getComments().addComment("subreply 3 for reply 2", pres.getSlides().get_Item(0),  new Point2D.Float(10, 10), new Date());
    subReply.setParentComment(reply2);

    IComment comment2 = author2.getComments().addComment("comment 2", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());
    IComment comment3 = author2.getComments().addComment("comment 3", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());

    IComment reply3 = author1.getComments().addComment("reply 4 for comment 3", pres.getSlides().get_Item(0), new Point2D.Float(10, 10), new Date());
    reply3.setParentComment(comment3);

    // कंसोल पर टिप्पणियों की पदानुक्रम दिखाता है
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

    // comment1 और उसके सभी उत्तरों को हटाता है
    comment1.remove();

    pres.save("remove_comment.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="warning" title="Attention" %}} 
* जब [Remove](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IComment#remove--) विधि (जो [IComment](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IComment) इंटरफ़ेस में है) का उपयोग करके टिप्पणी हटाई जाती है, तो उस टिप्पणी के उत्तर भी हटाए जाते हैं।  
* यदि [setParentComment](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IComment#setParentComment-com.aspose.slides.IComment-) सेट करने से चक्रीय संदर्भ बनता है, तो [PptxEditException](https://reference.aspose.com/slides/hi/java/com.aspose.slides/PptxEditException) उत्पन्न होगा।  
{{% /alert %}}

## **आधुनिक टिप्पणियाँ जोड़ें**

2021 में, Microsoft ने PowerPoint में *आधुनिक टिप्पणियाँ* (modern comments) प्रस्तुत कीं। यह सुविधा PowerPoint में सहयोग को काफी सुधारती है। आधुनिक टिप्पणियों के माध्यम से, PowerPoint उपयोगकर्ता टिप्पणियों को हल (resolve) कर सकते हैं, टिप्पणियों को वस्तुओं और टेक्स्ट से जोड़ सकते हैं, और बातचीत को पहले से अधिक आसानी से संचालित कर सकते हैं।

[Aspose Slides for Java 21.11](https://docs.aspose.com/slides/hi/java/aspose-slides-for-java-21-11-release-notes/) में, हमने [ModernComment](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ModernComment) क्लास जोड़कर आधुनिक टिप्पणियों के समर्थन को लागू किया। [addModernComment](https://reference.aspose.com/slides/hi/java/com.aspose.slides/CommentCollection#addModernComment-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-java.awt.geom.Point2D.Float-java.util.Date-) और [insertModernComment](https://reference.aspose.com/slides/hi/java/com.aspose.slides/CommentCollection#insertModernComment-int-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-java.awt.geom.Point2D.Float-java.util.Date-) विधियाँ [CommentCollection](https://reference.aspose.com/slides/hi/java/com.aspose.slides/CommentCollection) क्लास में जोड़ी गईं।

यह Java कोड दर्शाता है कि PowerPoint प्रस्तुति की स्लाइड में आधुनिक टिप्पणी कैसे जोड़ें:

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

## **टिप्पणियाँ हटाएँ**

### **सभी टिप्पणी और लेखक हटाएँ**

यह Java कोड दिखाता है कि प्रस्तुति में सभी टिप्पणी और लेखक कैसे हटाएँ:

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

### **विशिष्ट टिप्पणियाँ हटाएँ**

यह Java कोड दिखाता है कि स्लाइड पर विशिष्ट टिप्पणियों को कैसे हटाएँ:

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // टिप्पणियाँ जोड़ें...
    ICommentAuthor author = presentation.getCommentAuthors().addAuthor("Author", "A");
    author.getComments().addComment("comment 1", slide, new Point2D.Float(0.2f, 0.2f), new Date());
    author.getComments().addComment("comment 2", slide, new Point2D.Float(0.3f, 0.2f), new Date());

    // "comment 1" पाठ वाली सभी टिप्पणियों को हटाएँ
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

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या Aspose.Slides आधुनिक टिप्पणियों के लिए 'resolved' जैसी स्थिति का समर्थन करता है?**

हाँ। [Modern comments](https://reference.aspose.com/slides/hi/java/com.aspose.slides/moderncomment/) में एक [setStatus](https://reference.aspose.com/slides/hi/java/com.aspose.slides/moderncomment/#setStatus-byte-) विधि होती है; आप टिप्पणी की स्थिति (उदाहरण के लिए, इसे हल के रूप में चिह्नित) लिख सकते हैं, और यह स्थिति फ़ाइल में सहेजी जाती है तथा PowerPoint द्वारा पहचानी जाती है।

**क्या थ्रेडेड चर्चाएँ (उत्तर श्रृंखलाएँ) समर्थित हैं, और क्या कोई नेस्टिंग सीमा है?**

हाँ। प्रत्येक टिप्पणी अपने [parent comment](https://reference.aspose.com/slides/hi/java/com.aspose.slides/comment/#getParentComment--) को संदर्भित कर सकती है, जिससे मनमानी उत्तर श्रृंखलाएँ बनती हैं। API ने कोई विशिष्ट नेस्टिंग गहराई सीमा निर्धारित नहीं की है।

**स्लाइड पर टिप्पणी मार्कर की स्थिति किस समन्वय प्रणाली (coordinate system) में परिभाषित होती है?**

स्थिति स्लाइड के समन्वय प्रणाली में एक फ्लोटिंग‑पॉइंट पॉइंट के रूप में संग्रहीत होती है। यह आपको टिप्पणी मार्कर को बिल्कुल वही स्थान पर रखने की सुविधा देता है।