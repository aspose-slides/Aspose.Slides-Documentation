---
title: تعليق
type: docs
weight: 230
url: /ar/java/examples/elements/comment/
keywords:
- مثال على الكود
- تعليق
- PowerPoint
- OpenDocument
- عرض تقديمي
- Java
- Aspose.Slides
description: "التعامل مع تعليقات الشرائح في Aspose.Slides for Java: إضافة، رد، تعديل، حل، وتصدير التعليقات في عروض PPT و PPTX و ODP باستخدام أمثلة شفرة Java."
---
هذا المقال يوضح كيفية إضافة، قراءة، إزالة، والرد على التعليقات الحديثة باستخدام **Aspose.Slides for Java**.

## **إضافة تعليق حديث**

إنشاء تعليق من مؤلفه مستخدم وحفظ العرض التقديمي.

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

## **الوصول إلى تعليق حديث**

قراءة تعليق حديث من عرض تقديمي موجود.

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

## **إزالة تعليق حديث**

إزالة تعليق وحفظ الملف المُحدَّث.

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

## **الرد على تعليق حديث**

إضافة ردود إلى تعليق حديث رئيسي.

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