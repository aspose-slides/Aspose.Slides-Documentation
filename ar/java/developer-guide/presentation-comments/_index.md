---
title: إدارة تعليقات العروض التقديمية في Java
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
- الوصول إلى تعليق
- تحرير تعليق
- الرد على التعليق
- إزالة تعليق
- حذف تعليق
- PowerPoint
- عرض تقديمي
- Java
- Aspose.Slides
description: "إدارة تعليقات العروض التقديمية باستخدام Aspose.Slides for Java: إضافة، قراءة، تحرير، الرد على، وإزالة التعليقات في عروض PowerPoint بسرعة وسهولة."
---
## **نظرة عامة**

تشرح هذه المقالة كيفية إدارة تعليقات العروض التقديمية باستخدام Aspose.Slides for Java. إنها تُقدِّم الأنواع الرئيسية المتعلقة بالتعليقات وتظهر كيفية إضافة تعليقات إلى الشرائح، الوصول إلى التعليقات الموجودة، التعامل مع الردود والتعليقات الحديثة، وإزالة التعليقات من العرض التقديمي.

تغطي الأمثلة سيناريوهات مراجعة وتعاون شائعة في PowerPoint، مثل تعيين تعليقات للمؤلفين، قراءة نص التعليق والبيانات الوصفية، بناء سلاسل الردود، وإزالة التعليقات المختارة أو جميع التعليقات.

في PowerPoint، تظهر التعليقات كتوannotations على الشرائح. اختيار تعليق يعرض نصه والنقاش المرتبط به.

لطلب إظهار أو إخفاء التعليقات عند فتح عرض تقديمي دون تعديل التعليقات نفسها، راجع [إظهار أو إخفاء التعليقات عند فتح عرض تقديمي](/slides/ar/java/presentation-view-properties/).

## **لماذا نضيف تعليقات إلى العروض التقديمية؟**

يمكنك استخدام التعليقات لتقديم ملاحظات والتعاون مع الزملاء عند مراجعة العروض التقديمية.

توفر Aspose.Slides for Java واجهات برمجة التطبيقات التالية للعمل مع التعليقات:

* فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) التي توفر الوصول إلى مؤلفي تعليقات العرض التقديمي.
* الواجهة [ICommentCollection](https://reference.aspose.com/slides/java/com.aspose.slides/icommentcollection/) التي تمثل التعليقات المرتبطة بمؤلف فردي.
* الواجهة [IComment](https://reference.aspose.com/slides/java/com.aspose.slides/icomment/) التي توفر معلومات حول التعليق، بما في ذلك مؤلفه، وقت الإنشاء، الموقع، والنص.
* الفئة [CommentAuthor](https://reference.aspose.com/slides/java/com.aspose.slides/commentauthor/) التي توفر معلومات حول المؤلف، بما في ذلك اسمه، الأحرف الأولى، والتعليقات المرتبطة به.

## **إضافة تعليقات إلى الشرائح**

يقوم المثال بإنشاء شريحتين ويسجل مؤلف تعليق باستخدام [addAuthor](https://reference.aspose.com/slides/java/com.aspose.slides/icommentauthorcollection/#addAuthor-java.lang.String-java.lang.String-). يستخدم [addComment](https://reference.aspose.com/slides/java/com.aspose.slides/icommentcollection/#addComment-java.lang.String-com.aspose.slides.ISlide-java.awt.geom.Point2D.Float-java.util.Date-) لوضع تعليق واحد على كل شريحة، ثم يسترجع تعليقات الشريحة الأولى لذلك المؤلف باستخدام [getSlideComments](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#getSlideComments-com.aspose.slides.ICommentAuthor-). تعرض وحدة التحكم نص التعليق الأول مرتين، مظهرًا الوصول من خلال كل من الشريحة والمؤلف، ويحتوي العرض التقديمي المحفوظ على التعليقين.

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

        String commentText = firstComment.getAuthor().getComments().get_Item(0).getText();
        System.out.println(commentText);
    }

    presentation.save("Comments_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **البحث عن مؤلف تعليق أو إنشاؤه**

عند تنفيذ مراجعة تلقائية للعرض نفسه مرارًا، ابحث في المجموعة التي تُرجعها [getCommentAuthors](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getCommentAuthors--) قبل إضافة مؤلف. يطابق [findByNameAndInitials](https://reference.aspose.com/slides/java/com.aspose.slides/icommentauthorcollection/#findByNameAndInitials-java.lang.String-java.lang.String-) كلًا من الاسم والأحرف الأولى ويُرجع مصفوفة بالمؤلفين المطابقين، أو مصفوفة فارغة إذا لم توجد مطابقات. بالمقابل، يبحث [findByName](https://reference.aspose.com/slides/java/com.aspose.slides/icommentauthorcollection/#findByName-java.lang.String-) بالاسم فقط، بغض النظر عن الأحرف الأولى. استدعاء [addAuthor](https://reference.aspose.com/slides/java/com.aspose.slides/icommentauthorcollection/#addAuthor-java.lang.String-java.lang.String-) باسم وأحرف أولية موجودة بالفعل في المجموعة يُلقي استثناءً.

يتطلب المثال ملف عرض تقديمي يحتوي على شريحة واحدة على الأقل. في كل من المرورين، يُعيد استخدام أول مؤلف مطابقة، أو ينشئ واحدًا فقط عندما تكون النتيجة فارغة. إذا كان هناك عدة مطابقات، يختار العنصر الأول في المصفوفة دون دمج أو إزالة المؤلفين الآخرين. ثم يستدعي [addComment](https://reference.aspose.com/slides/java/com.aspose.slides/icommentcollection/#addComment-java.lang.String-com.aspose.slides.ISlide-java.awt.geom.Point2D.Float-java.util.Date-) للمؤلف المحدد ويحفظ العرض التقديمي. يفتح المرور الثاني مخرجات المرور الأول ويعيد تنفيذ العملية.

```java
import com.aspose.slides.ICommentAuthor;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.awt.geom.Point2D;
import java.util.Date;

final String authorName = "Reviewer";
final String authorInitials = "RV";

String inputFile = "input.pptx";
Point2D.Float position = new Point2D.Float(20, 20);

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

يضيف المرور الثاني تعليقًا آخر دون إضافة مؤلف آخر أو إزالة التعليقات الموجودة. يحتوي الملف النهائي `review_pass_2.pptx` على كلا التعليقين الجديدين إلى جانب أي تعليقات أصلية. إعادة استخدام مؤلف لا تُزيل التكرار من التعليقات: لتجنب إضافة التعليق نفسه مرارًا، نفّذ كشف التكرارات قبل إضافته.

## **الوصول إلى تعليقات الشرائح**

يفتح المثال عرضًا تقديميًا موجودًا ويقرأ المجموعة التي تُرجعها [getCommentAuthors](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getCommentAuthors--). لكل مؤلف، يتنقل عبر المجموعة التي تُرجعها [getComments](https://reference.aspose.com/slides/java/com.aspose.slides/icommentauthor/#getComments--) ويطبع رقم الشريحة، نص التعليق، اسم المؤلف، ووقت الإنشاء. يجب أن يحتوي عرض الإدخال على تعليقات لإنتاج مخرجات في وحدة التحكم.

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

التعليق الأصلي هو التعليق الأول في شجرة الردود. تسمح طريقتا [IComment.getParentComment](https://reference.aspose.com/slides/java/com.aspose.slides/icomment/#getParentComment--) و[IComment.setParentComment](https://reference.aspose.com/slides/java/com.aspose.slides/icomment/#setParentComment-com.aspose.slides.IComment-) بالحصول على مُعرّف التعليق الأب أو تعيينه.

ينشئ المثال تعليقات من مؤلفين اثنين ويستخدم [setParentComment](https://reference.aspose.com/slides/java/com.aspose.slides/icomment/#setParentComment-com.aspose.slides.IComment-) لبناء الردود، بما في ذلك رد على رد آخر. تمرير `null` إلى [getSlideComments](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#getSlideComments-com.aspose.slides.ICommentAuthor-) يسترجع التعليقات من جميع المؤلفين؛ تُظهر وحدة التحكم كل إدخال مع إزاحة وفقًا لعمقها في شجرة الردود. يحفظ المثال النقاش الكامل، ثم يستدعي [remove](https://reference.aspose.com/slides/java/com.aspose.slides/icomment/#remove--) على أول تعليق جذري، ويحفظ عرضًا تقديميًا ثانٍ مع حذف ذلك التعليق والردود المرتبطة به.

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
* عندما تُستخدم طريقة [IComment.remove](https://reference.aspose.com/slides/java/com.aspose.slides/icomment/#remove--) لحذف تعليق، تُحذف جميع الردود على ذلك التعليق أيضًا.
* إذا أنشأت [IComment.setParentComment](https://reference.aspose.com/slides/java/com.aspose.slides/icomment/#setParentComment-com.aspose.slides.IComment-) مرجعًا دائريًا، يُرمى [PptxEditException](https://reference.aspose.com/slides/java/com.aspose.slides/pptxeditexception/).
{{% /alert %}}

## **إضافة تعليقات حديثة**

يمكن ربط التعليقات الحديثة بالشريحة نفسها، أو بشكل معين، أو بمدى نص داخل AutoShape. تقبل طريقة [ICommentCollection.addModernComment](https://reference.aspose.com/slides/java/com.aspose.slides/icommentcollection/#addModernComment-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-java.awt.geom.Point2D.Float-java.util.Date-) معاملًا من نوع [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) بالإضافة إلى الشريحة وإحداثيات علامة التعليق.

عند تمرير `null` كقيمة للمعامل shape، يصبح التعليق تعليقًا على مستوى الشريحة. تُحدد العلامة بإحداثيات مُعطاة، لكنه غير مرتبط بأي شكل معين، وبالتالي تُعيد [IModernComment.getShape](https://reference.aspose.com/slides/java/com.aspose.slides/imoderncomment/#getShape--) القيمة `null`. عندما يتم توفير [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/)، يُربط التعليق بذلك الشكل. ما زالت الإحداثيات تُحدِّد موضع علامة التعليق على الشريحة، ويمكن استرجاع ارتباط الشكل عبر [IModernComment.getShape](https://reference.aspose.com/slides/java/com.aspose.slides/imoderncomment/#getShape--).

### **تثبيت تعليق حديث على شكل**

يستدعي المثال [addModernComment](https://reference.aspose.com/slides/java/com.aspose.slides/icommentcollection/#addModernComment-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-java.awt.geom.Point2D.Float-java.util.Date-) مرتين: مرةً مع شكل `null` لتعليق على مستوى الشريحة ومرةً أخرى مع مستطيل كمرساة. قراءة [getShape](https://reference.aspose.com/slides/java/com.aspose.slides/imoderncomment/#getShape--) تُطبع `true` للتحقق من التعليق على مستوى الشريحة وتُظهر `Revenue title` للتعليق المثبت. يتم حفظ كل من التعليقين مع العرض التقديمي.

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

### **تثبيت التعليقات على أنواع أشكال مختلفة**

يمكن استخدام أي كائن شريحة يطبق [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) كمرساة للشكل. تشمل الأمثلة الشائعة [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/)، [IPictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframe/)، [IGroupShape](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshape/)، [IConnector](https://reference.aspose.com/slides/java/com.aspose.slides/iconnector/)، و[IGraphicalObject](https://reference.aspose.com/slides/java/com.aspose.slides/igraphicalobject/) مثل المخططات.

يستخدم المثال [addModernComment](https://reference.aspose.com/slides/java/com.aspose.slides/icommentcollection/#addModernComment-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-java.awt.geom.Point2D.Float-java.util.Date-) لربط تعليق مع كل من خمس أنواع أشكال: AutoShape، إطار صورة، مجموعة، موصل، ومخطط. تستخدم الصورة بيانات صورة مدمجة، لذا لا يلزم صورة خارجية. لكل تعليق موقع علامة خاص به، ويحافظ العرض التقديمي المحفوظ على جميع ارتباطات الأشكال الخمس.

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

بالنسبة لتعليق حديث مرتبط بـ [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/)، تُتيح طريقتا [IModernComment.getTextSelectionStart](https://reference.aspose.com/slides/java/com.aspose.slides/imoderncomment/#getTextSelectionStart--) و[IModernComment.setTextSelectionStart](https://reference.aspose.com/slides/java/com.aspose.slides/imoderncomment/#setTextSelectionStart-int-) الوصول إلى موضع بدء النص المحدد في إطار نص الشكل. وتُتيح [IModernComment.getTextSelectionLength](https://reference.aspose.com/slides/java/com.aspose.slides/imoderncomment/#getTextSelectionLength--) و[IModernComment.setTextSelectionLength](https://reference.aspose.com/slides/java/com.aspose.slides/imoderncomment/#setTextSelectionLength-int-) الوصول إلى طول الاختيار. معًا، تُربط هذه القيم التعليق بمدى نص محدد داخل AutoShape.

تُتيح طريقتا [IModernComment.getStatus](https://reference.aspose.com/slides/java/com.aspose.slides/imoderncomment/#getStatus--) و[IModernComment.setStatus](https://reference.aspose.com/slides/java/com.aspose.slides/imoderncomment/#setStatus-byte-) الحصول على قيمة من ثوابت [ModernCommentStatus](https://reference.aspose.com/slides/java/com.aspose.slides/moderncommentstatus/):

- `NotDefined` — لا يُعرَّف حالة تعليق حديث محددة.
- `Active` — التعليق نشط.
- `Resolved` — تم حل التعليق.
- `Closed` — التعليق مغلق.

يربط المثال تعليقًا حديثًا بكلمات "quarterly revenue" في نص مستطيل. يحسب موضع بدء الاختيار بالصيغة الصفرية من النص ويمرره إلى [setTextSelectionStart](https://reference.aspose.com/slides/java/com.aspose.slides/imoderncomment/#setTextSelectionStart-int-) ويستخدم [setTextSelectionLength](https://reference.aspose.com/slides/java/com.aspose.slides/imoderncomment/#setTextSelectionLength-int-) لتعيين عدد الأحرف المحددة. بعد استدعاء [setStatus](https://reference.aspose.com/slides/java/com.aspose.slides/imoderncomment/#setStatus-byte-) بـ `Resolved`, يحفظ ويعيد فتح العرض التقديمي. يجب أن تُطبع الفحوصات الأربع في وحدة التحكم القيمة `true`، لتأكيد حفظ ارتباط الشكل، مدى النص، والحالة.

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

يتطلب المثال عرضًا تقديميًا موجودًا يحتوي على تعليقات حديثة ويطبع نصها، حالتها، وتفاصيل الارتباط. للفحص، تحقق من أي تعليقات تُنفذ [IModernComment](https://reference.aspose.com/slides/java/com.aspose.slides/imoderncomment/)، ثم استعرض [IModernComment.getShape](https://reference.aspose.com/slides/java/com.aspose.slides/imoderncomment/#getShape--)، [IModernComment.getTextSelectionStart](https://reference.aspose.com/slides/java/com.aspose.slides/imoderncomment/#getTextSelectionStart--)، [IModernComment.getTextSelectionLength](https://reference.aspose.com/slides/java/com.aspose.slides/imoderncomment/#getTextSelectionLength--)، و[IModernComment.getStatus](https://reference.aspose.com/slides/java/com.aspose.slides/imoderncomment/#getStatus--). يشير الشكل `null` إلى تعليق على مستوى الشريحة. بالنسبة لمرساة [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/)، تحدد طرق اختيار النص المدى المرتبط بإطار نص الشكل.

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

تتيح Aspose.Slides for Java إزالة جميع التعليقات ومؤلفيها من عرض تقديمي أو حذف تعليقات مختارة مع الحفاظ على البقية. توضح الأمثلة التالية كلا النهجين وتُحفظ العرض المحدث.

### **إزالة جميع التعليقات ومؤلفي التعليقات**

يفتح المثال عرضًا تقديميًا موجودًا ويستدعي [ICommentCollection.clear](https://reference.aspose.com/slides/java/com.aspose.slides/icommentcollection/#clear--) لكل مؤلف، ثم يستدعي [ICommentAuthorCollection.clear](https://reference.aspose.com/slides/java/com.aspose.slides/icommentauthorcollection/#clear--) لإزالة المؤلفين أنفسهم. يحتوي العرض التقديمي المحفوظ على لا تعليقات ولا مؤلفي تعليقات. استخدم عرضًا يحتوي على تعليقات لملاحظة الإزالة.

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

ينشئ المثال تعليقيْن على شريحة واحدة ويستخدم [getSlideComments](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#getSlideComments-com.aspose.slides.ICommentAuthor-) للعثور على التعليقات لكل مؤلف. يجمع التعليقات التي يساوي نصها "comment 1" قبل استدعاء [ICommentCollection.remove](https://reference.aspose.com/slides/java/com.aspose.slides/icommentcollection/#remove-com.aspose.slides.IComment-)، متجنبًا تعديل المجموعة أثناء الاختيار. يحتفظ العرض التقديمي المحفوظ بـ "comment 2" فقط.

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

**هل تدعم Aspose.Slides حالة "مُحَلَّة" للتعليقات الحديثة؟**

نعم. تُتيح كل من [IModernComment.getStatus](https://reference.aspose.com/slides/java/com.aspose.slides/imoderncomment/#getStatus--) و[IModernComment.setStatus](https://reference.aspose.com/slides/java/com.aspose.slides/imoderncomment/#setStatus-byte-) الوصول إلى قيمة من [ModernCommentStatus](https://reference.aspose.com/slides/java/com.aspose.slides/moderncommentstatus/) بما في ذلك `Resolved`. تُحفظ الحالة في العرض التقديمي ويمكن قراءتها مرة أخرى بعد إعادة فتح الملف.

**هل تدعم المناقشات المتسلسلة (سلاسل الردود) وهل هناك حد للتعمق؟**

نعم. يمكن لكل تعليق الإشارة إلى [parent comment](https://reference.aspose.com/slides/java/com.aspose.slides/icomment/#getParentComment--) الخاص به، مما يتيح سلاسل الردود. لا تُحدِّد واجهة برمجة التطبيقات حدًا محددًا لعمق التعمق.

**في أي نظام إحداثيات يُعرَّف موضع علامة التعليق على الشريحة؟**

يُعرَّف موضع العلامة بإحداثيات نقطية ذات قيم عائمة في نظام إحداثيات الشريحة، مما يتيح وضعها بدقة على الشريحة.