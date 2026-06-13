---
title: टिप्पणी
type: docs
weight: 230
url: /hi/java/examples/elements/comment/
keywords:
- कोड उदाहरण
- टिप्पणी
- PowerPoint
- OpenDocument
- प्रस्तुति
- Java
- Aspose.Slides
description: "Aspose.Slides for Java में स्लाइड टिप्पणियों के साथ काम करें: जोड़ें, उत्तर दें, संपादित करें, समाधान करें, और PPT, PPTX, और ODP प्रस्तुतियों में टिप्पणियों को निर्यात करें, Java कोड उदाहरणों के साथ।"
---
यह लेख **Aspose.Slides for Java** का उपयोग करके आधुनिक टिप्पणियों को जोड़ने, पढ़ने, हटाने और उनका उत्तर देने को प्रदर्शित करता है।

## **आधुनिक टिप्पणी जोड़ें**

एक उपयोगकर्ता द्वारा लिखी गई टिप्पणी बनाएं और प्रस्तुति को सहेजें।

```java
static void addModernComment() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        ICommentAuthor author = presentation.getCommentAuthors().addAuthor("User", "U1");
        author.getComments().addModernComment(
                "This is a modern comment", slide, null, new Point2D.Float(100, 100), new java.util.Date());

        presentation.save("modern_comment.pptx", SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **आधुनिक टिप्पणी तक पहुँचें**

एक मौजूदा प्रस्तुति से आधुनिक टिप्पणी पढ़ें।

```java
static void accessModernComment() {
    Presentation presentation = new Presentation("modern_comment.pptx");
    try {
        ICommentAuthor author = presentation.getCommentAuthors().get_Item(0);
        IModernComment comment = (IModernComment) author.getComments().get_Item(0);
        System.out.println("Author: " + author.getName() + ", Comment: " + comment.getText() + ", Position: " + comment.getPosition());
    } finally {
        presentation.dispose();
    }
}
```

## **आधुनिक टिप्पणी हटाएँ**

एक टिप्पणी हटाएँ और अद्यतन फ़ाइल सहेजें।

```java
static void removeModernComment() {
    Presentation presentation = new Presentation("modern_comment.pptx");
    try {
        ICommentAuthor author = presentation.getCommentAuthors().get_Item(0);

        IComment comment = author.getComments().get_Item(0);
        comment.remove();

        presentation.save("modern_comment_removed.pptx", SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **आधुनिक टिप्पणी का उत्तर दें**

मूल आधुनिक टिप्पणी पर उत्तर जोड़ें।

```java
static void replyToModernComment() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        ICommentAuthor author = presentation.getCommentAuthors().addAuthor("User", "U1");

        IModernComment parentComment = author.getComments().addModernComment(
                "Parent comment", slide, null, new Point2D.Float(100, 100), new java.util.Date());
        
        IModernComment reply1 = author.getComments().addModernComment(
                "Reply 1", slide, null, new Point2D.Float(110, 100), new java.util.Date());
        
        IModernComment reply2 = author.getComments().addModernComment(
                "Reply 2", slide, null, new Point2D.Float(120, 100), new java.util.Date());

        reply1.setParentComment(parentComment);
        reply2.setParentComment(parentComment);

        presentation.save("modern_comment_replies.pptx", SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```