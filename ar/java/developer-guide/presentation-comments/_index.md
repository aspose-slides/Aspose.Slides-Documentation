---
title: إدارة تعليقات العرض التقديمي في جافا
linktitle: تعليقات العرض التقديمي
type: docs
weight: 100
url: /ar/java/presentation-comments/
keywords:
- تعليق
- تعليق حديث
- تعليقات PowerPoint
- تعليقات العرض التقديمي
- تعليقات الشريحة
- إضافة تعليق
- الوصول إلى التعليق
- تحرير التعليق
- الرد على التعليق
- إزالة التعليق
- حذف التعليق
- PowerPoint
- العرض التقديمي
- جافا
- Aspose.Slides
description: "إدارة تعليقات العرض التقديمي باستخدام Aspose.Slides لجافا: إضافة، قراءة، تحرير، الرد على، وإزالة التعليقات في عروض PowerPoint بسرعة وسهولة."
---
## **نظرة عامة**

يشرح هذا المقال كيفية إدارة تعليقات العرض التقديمي باستخدام Aspose.Slides for Java. يقدم الأنواع الرئيسية المتعلقة بالتعليقات ويظهر كيفية إضافة تعليقات إلى الشرائح، الوصول إلى التعليقات الموجودة، التعامل مع الردود والتعليقات الحديثة، وإزالة التعليقات من العرض التقديمي.

تغطي الأمثلة السيناريوهات الشائعة للمراجعة والتعاون في PowerPoint، مثل تعيين التعليقات للمؤلفين، قراءة نص التعليق والبيانات الوصفية، بناء سلاسل الردود، وإزالة التعليقات المحددة أو جميع التعليقات.

في PowerPoint، تظهر التعليقات كأنوتات على الشرائح. عند اختيار تعليق يتم عرض نصه والنقاش المرتبط به.

## **لماذا نضيف تعليقات إلى العروض التقديمية؟**

يمكنك استخدام التعليقات لتقديم ملاحظات والتعاون مع الزملاء عند مراجعة العروض التقديمية.

توفر Aspose.Slides for Java الـ APIs التالية للعمل مع التعليقات:

* الفئة [العرض] (https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/) التي توفر الوصول إلى مؤلفي تعليقات العرض التقديمي.
* الواجهة [ICommentCollection] (https://reference.aspose.com/slides/ar/java/com.aspose.slides/icommentcollection/) التي تمثل التعليقات المرتبطة بمؤلف فردي.
* الواجهة [IComment] (https://reference.aspose.com/slides/ar/java/com.aspose.slides/icomment/) التي توفر معلومات حول التعليق، بما في ذلك المؤلف، وقت الإنشاء، الموقع، والنص.
* الفئة [CommentAuthor] (https://reference.aspose.com/slides/ar/java/com.aspose.slides/commentauthor/) التي توفر معلومات حول المؤلف، بما في ذلك اسمه، الأحرف الأولى، والتعليقات المرتبطة به.

## **إضافة تعليقات إلى الشرائح**

يوضح المثال التالي كيفية إضافة تعليقات إلى الشرائح في عرض PowerPoint:

```java
import com.aspose.slides.IComment;
import com.aspose.slides.ICommentAuthor;
import com.aspose.slides.ICommentCollection;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.awt.geom.Point2D;
import java.util.Date;

Presentation presentation = new Presentation();
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);
    ISlide secondSlide = presentation.getSlides().addEmptySlide(presentation.getLayoutSlides().get_Item(0));
    ICommentAuthor author = presentation.getCommentAuthors().addAuthor("Jawad", "MF");
    Point2D.Float position = new Point2D.Float(0.2f, 0.2f);
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

## **الوصول إلى تعليقات الشرائح**

يوضح المثال التالي كيفية الوصول إلى التعليقات الموجودة في عرض PowerPoint:

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

## **الرد على التعليقات**

التعليق الأصلي هو التعليق الأساسي في أعلى هيكل الردود. تتيح لك طريقتا [IComment.getParentComment] (https://reference.aspose.com/slides/ar/java/com.aspose.slides/icomment/#getParentComment--) و[IComment.setParentComment] (https://reference.aspose.com/slides/ar/java/com.aspose.slides/icomment/#setParentComment-com.aspose.slides.IComment-) الحصول على أو تعيين التعليق الأصلي.

يوضح المثال التالي كيفية إضافة ردود وفحص هيكل التعليقات الناتج:

```java
import com.aspose.slides.IComment;
import com.aspose.slides.ICommentAuthor;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.awt.geom.Point2D;
import java.util.Date;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    Point2D.Float position = new Point2D.Float(10, 10);
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

{{% alert color="warning" title="Warning" %}}
* عند استخدام طريقة [IComment.remove] (https://reference.aspose.com/slides/ar/java/com.aspose.slides/icomment/#remove--) لحذف تعليق، يتم حذف جميع الردود المرتبطة به أيضًا.
* إذا أنشأت طريقة [IComment.setParentComment] (https://reference.aspose.com/slides/ar/java/com.aspose.slides/icomment/#setParentComment-com.aspose.slides.IComment-) إشارة دائرية، سيتم رمي استثناء [PptxEditException] (https://reference.aspose.com/slides/ar/java/com.aspose.slides/pptxeditexception/).
{{% /alert %}}

## **إضافة تعليقات حديثة**

يمكن ربط التعليقات الحديثة بالشرائح نفسها، أو بصورة محددة، أو بنطاق نص داخل AutoShape. تقبل طريقة [ICommentCollection.addModernComment] (https://reference.aspose.com/slides/ar/java/com.aspose.slides/icommentcollection/#addModernComment-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-java.awt.geom.Point2D.Float-java.util.Date-) معاملًا من نوع [IShape] (https://reference.aspose.com/slides/ar/java/com.aspose.slides/ishape/) بالإضافة إلى الشريحة وإحداثيات علامة التعليق.

عند تمرير `null` كقيمة للمعامل shape، تكون التعليق تعليقًا على مستوى الشريحة. يتم تحديد موقع العلامة بالإحداثيات المقدمة، لكنه لا يرتبط بصورة معينة، لذلك تُعيد طريقة [IModernComment.getShape] (https://reference.aspose.com/slides/ar/java/com.aspose.slides/imoderncomment/#getShape--) القيمة `null`. عند تزويد [IShape]، يتم تثبيت التعليق على تلك الصورة. لا تزال الإحداثيات تحدد موقع علامة التعليق على الشريحة، بينما يمكن استرجاع الارتباط بالصورة عبر [IModernComment.getShape] (https://reference.aspose.com/slides/ar/java/com.aspose.slides/imoderncomment/#getShape--).

### **تثبيت تعليق حديث على صورة**

ينشئ المثال التالي كلًا من تعليق حديث على مستوى الشريحة وتعليق حديث مثبت على AutoShape محدد. ثم يقرأ الصورة المرتبطة بكل تعليق.

```java
import com.aspose.slides.IAutoShape;
import com.aspose.slides.ICommentAuthor;
import com.aspose.slides.IModernComment;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ShapeType;
import java.awt.geom.Point2D;
import java.util.Date;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ICommentAuthor author = presentation.getCommentAuthors().addAuthor("Reviewer", "RV");
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 300, 80);
    shape.setName("Revenue title");
    shape.getTextFrame().setText("Quarterly revenue");

    Date createdTime = new Date();
    Point2D.Float slideCommentPosition = new Point2D.Float(20, 20);
    Point2D.Float shapeCommentPosition = new Point2D.Float(60, 60);
    IModernComment slideComment = author.getComments().addModernComment("Review the overall slide layout.", slide, null, slideCommentPosition, createdTime);
    IModernComment shapeComment = author.getComments().addModernComment("Check this title.", slide, shape, shapeCommentPosition, createdTime);

    System.out.println(slideComment.getShape() == null);
    System.out.println(shapeComment.getShape().getName());

    presentation.save("modern_comments.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **تثبيت التعليقات على أنواع صور مختلفة**

يمكن استخدام أي كائن شريحة يطبق [IShape] (https://reference.aspose.com/slides/ar/java/com.aspose.slides/ishape/) كمرساة للصورة. تشمل الأمثلة الشائعة [IAutoShape] (https://reference.aspose.com/slides/ar/java/com.aspose.slides/iautoshape/)، [IPictureFrame] (https://reference.aspose.com/slides/ar/java/com.aspose.slides/ipictureframe/)، [IGroupShape] (https://reference.aspose.com/slides/ar/java/com.aspose.slides/igroupshape/)، [IConnector] (https://reference.aspose.com/slides/ar/java/com.aspose.slides/iconnector/)، و[IGraphicalObject] (https://reference.aspose.com/slides/ar/java/com.aspose.slides/igraphicalobject/) مثل المخططات.

ينشئ المثال التالي عدة أنواع صور شائعة ويربط كل منها بتعليق حديث.

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
import java.awt.geom.Point2D;
import java.util.Base64;
import java.util.Date;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ICommentAuthor author = presentation.getCommentAuthors().addAuthor("Reviewer", "RV");
    Date createdTime = new Date();

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 180, 60);
    autoShape.getTextFrame().setText("AutoShape");
    Point2D.Float autoShapeCommentPosition = new Point2D.Float(30, 30);
    author.getComments().addModernComment("Comment on an AutoShape.", slide, autoShape, autoShapeCommentPosition, createdTime);

    String imageBase64 = "iVBORw0KGgoAAAANSUhEUgAAAAIAAAACCAIAAAD91JpzAAAAFklEQVR4nGP8//8/AwMDEwMDAwMDAwAkBgMB/DXemwAAAABJRU5ErkJggg==";
    byte[] imageData = Base64.getDecoder().decode(imageBase64);
    IPPImage image = presentation.getImages().addImage(imageData);
    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 220, 20, 120, 80, image);
    Point2D.Float pictureCommentPosition = new Point2D.Float(230, 30);
    author.getComments().addModernComment("Comment on a picture.", slide, pictureFrame, pictureCommentPosition, createdTime);

    IGroupShape groupShape = slide.getShapes().addGroupShape();
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 80, 40);
    groupShape.getShapes().addAutoShape(ShapeType.Ellipse, 100, 0, 80, 40);
    Point2D.Float groupCommentPosition = new Point2D.Float(40, 150);
    author.getComments().addModernComment("Comment on a group.", slide, groupShape, groupCommentPosition, createdTime);

    IConnector connector = slide.getShapes().addConnector(ShapeType.StraightConnector1, 220, 150, 140, 40);
    Point2D.Float connectorCommentPosition = new Point2D.Float(240, 150);
    author.getComments().addModernComment("Comment on a connector.", slide, connector, connectorCommentPosition, createdTime);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 400, 20, 250, 180);
    Point2D.Float chartCommentPosition = new Point2D.Float(420, 40);
    author.getComments().addModernComment("Comment on a graphical object.", slide, chart, chartCommentPosition, createdTime);

    presentation.save("modern_comment_shape_types.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **تثبيت تعليق على نص وتعيين حالته**

بالنسبة لتعليق حديث مرتبط بـ [IAutoShape] (https://reference.aspose.com/slides/ar/java/com.aspose.slides/iautoshape/)، توفر طرق [IModernComment.getTextSelectionStart] (https://reference.aspose.com/slides/ar/java/com.aspose.slides/imoderncomment/#getTextSelectionStart--) و[IModernComment.setTextSelectionStart] (https://reference.aspose.com/slides/ar/java/com.aspose.slides/imoderncomment/#setTextSelectionStart-int-) موضع بداية النص المحدد داخل إطار النص الخاص بالصورة. وتوفر طرق [IModernComment.getTextSelectionLength] (https://reference.aspose.com/slides/ar/java/com.aspose.slides/imoderncomment/#getTextSelectionLength--) و[IModernComment.setTextSelectionLength] (https://reference.aspose.com/slides/ar/java/com.aspose.slides/imoderncomment/#setTextSelectionLength-int-) طول التحديد. معًا، تربط هذه القيم التعليق بنطاق نص محدد داخل AutoShape.

توفر طريقتا [IModernComment.getStatus] (https://reference.aspose.com/slides/ar/java/com.aspose.slides/imoderncomment/#getStatus--) و[IModernComment.setStatus] (https://reference.aspose.com/slides/ar/java/com.aspose.slides/imoderncomment/#setStatus-byte--) قيمة من ثوابت [ModernCommentStatus] (https://reference.aspose.com/slides/ar/java/com.aspose.slides/moderncommentstatus/):

- `NotDefined` — لا يتم تعريف حالة تعليق حديث محددة.
- `Active` — التعليق نشط.
- `Resolved` — تم حل التعليق.
- `Closed` — التعليق مغلق.

ينشئ المثال التالي تعليقًا حديثًا مثبتًا على صورة، يربطه باختيار نص، يحدد حالته كـ "محلول"، يحفظ العرض التقديمي، ويتحقق من القيم بعد إعادة فتح الملف.

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
import java.awt.geom.Point2D;
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
    Point2D.Float commentPosition = new Point2D.Float(60, 60);
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

### **فحص التعليقات الحديثة الموجودة**

لفحص عرض تقديمي موجود، تحقق من التعليقات التي تنفذ [IModernComment] (https://reference.aspose.com/slides/ar/java/com.aspose.slides/imoderncomment/)، ثم استعرض [IModernComment.getShape] (https://reference.aspose.com/slides/ar/java/com.aspose.slides/imoderncomment/#getShape--)، [IModernComment.getTextSelectionStart] (https://reference.aspose.com/slides/ar/java/com.aspose.slides/imoderncomment/#getTextSelectionStart--)، [IModernComment.getTextSelectionLength] (https://reference.aspose.com/slides/ar/java/com.aspose.slides/imoderncomment/#getTextSelectionLength--)، و[IModernComment.getStatus] (https://reference.aspose.com/slides/ar/java/com.aspose.slides/imoderncomment/#getStatus--). يشير الشكل `null` إلى تعليق على مستوى الشريحة. بالنسبة لمرساة [IAutoShape]، تحدد طرق اختيار النص النطاق المرتبط بإطار نص الصورة.

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

## **إزالة التعليقات**

### **إزالة جميع التعليقات ومؤلفي التعليقات**

يعرض المثال التالي كيفية إزالة جميع التعليقات ومؤلفي التعليقات من عرض تقديمي:

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

### **إزالة تعليقات محددة**

يعرض المثال التالي كيفية إزالة تعليقات محددة من شريحة:

```java
import com.aspose.slides.IComment;
import com.aspose.slides.ICommentAuthor;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.awt.geom.Point2D;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ICommentAuthor author = presentation.getCommentAuthors().addAuthor("Author", "A");
    Date createdTime = new Date();

    Point2D.Float firstCommentPosition = new Point2D.Float(0.2f, 0.2f);
    Point2D.Float secondCommentPosition = new Point2D.Float(0.3f, 0.2f);
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

## **الأسئلة المتكررة**

**هل تدعم Aspose.Slides حالة "محلول" للتعليقات الحديثة؟**

نعم. تُتيح طريقتا [IModernComment.getStatus] (https://reference.aspose.com/slides/ar/java/com.aspose.slides/imoderncomment/#getStatus--) و[IModernComment.setStatus] (https://reference.aspose.com/slides/ar/java/com.aspose.slides/imoderncomment/#setStatus-byte-) الوصول إلى قيمة من [ModernCommentStatus] (https://reference.aspose.com/slides/ar/java/com.aspose.slides/moderncommentstatus/) تشمل `Resolved`. تُحفظ الحالة في العرض التقديمي ويمكن قراءتها مرة أخرى بعد إعادة فتح الملف.

**هل يتم دعم المناقشات المتسلسلة (سلاسل الردود)، وهل هناك حد للتعشيق؟**

نعم. يمكن لكل تعليق الإشارة إلى [التعليق الأصلي] (https://reference.aspose.com/slides/ar/java/com.aspose.slides/icomment/#getParentComment--) الخاص به، مما يتيح سلاسل الردود. لا تُعرّف الـ API حدًا محددًا لعمق التعشيق.

**في أي نظام إحداثيات يتم تعريف موضع علامة التعليق على الشريحة؟**

يتم تعريف موضع العلامة بواسطة إحداثيات ذات نقطة عائمة في نظام إحداثيات الشريحة، مما يتيح لك وضعها بدقة على الشريحة.