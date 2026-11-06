---
title: إدارة تعليقات العرض التقديمي على Android
linktitle: تعليقات العرض التقديمي
type: docs
weight: 100
url: /ar/androidjava/presentation-comments/
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
- Android
- Java
- Aspose.Slides
description: "إدارة تعليقات العرض التقديمي باستخدام Aspose.Slides لأندرويد عبر Java: إضافة، قراءة، تحرير، الرد على، وإزالة التعليقات في عروض PowerPoint بسرعة وسهولة."
---
## **نظرة عامة**

تشرح هذه المقالة كيفية إدارة تعليقات العرض التقديمي باستخدام Aspose.Slides for Android عبر Java. تُعرِّف الأنواع المتعلقة بالتعليقات الرئيسية وتوضح كيفية إضافة تعليقات إلى الشرائح، والوصول إلى التعليقات الموجودة، والعمل مع الردود والتعليقات الحديثة، وإزالة التعليقات من العرض التقديمي.

تغطي الأمثلة سيناريوهات المراجعة والتعاون الشائعة في PowerPoint، مثل تعيين التعليقات للمؤلفين، قراءة نص التعليق والبيانات الوصفية، بناء سلاسل الردود، وإزالة التعليقات المحددة أو جميع التعليقات.

في PowerPoint، تظهر التعليقات كannotations على الشرائح. عند اختيار تعليق يُظهر النص والنقاش المتعلق به.

لطلب إظهار أو إخفاء التعليقات عند فتح العرض التقديمي دون تغيير التعليقات نفسها، راجع [إظهار أو إخفاء التعليقات عند فتح عرض تقديمي](/slides/ar/androidjava/presentation-view-properties/).

## **لماذا نضيف تعليقات إلى العروض التقديمية؟**

يمكنك استخدام التعليقات لتقديم ملاحظات والتعاون مع الزملاء عند مراجعة العروض التقديمية.

يوفر Aspose.Slides for Android عبر Java واجهات برمجة التطبيقات (APIs) التالية للعمل مع التعليقات:

* الفئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) التي تُتيح الوصول إلى مؤلفي تعليقات العرض التقديمي.
* الواجهة [ICommentCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommentcollection/) التي تمثل التعليقات المرتبطة بمؤلف معين.
* الواجهة [IComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icomment/) التي تُوفر معلومات حول التعليق، بما في ذلك المؤلف، وقت الإنشاء، الموقع، والنص.
* الفئة [CommentAuthor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/commentauthor/) التي تُوفر معلومات حول المؤلف، بما في ذلك اسمه، الأحرف الأولى، والتعليقات المرتبطة به.

## **إضافة تعليقات إلى الشرائح**

ينشئ المثال شرائحتين ويسجل مؤلف تعليق باستخدام [addAuthor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommentauthorcollection/#addAuthor-java.lang.String-java.lang.String-). يستخدم [addComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommentcollection/#addComment-java.lang.String-com.aspose.slides.ISlide-android.graphics.PointF-java.util.Date-) لوضع تعليق واحد على كل شريحة، ثم يسترجع تعليقات الشريحة الأولى لهذا المؤلف باستخدام [getSlideComments](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#getSlideComments-com.aspose.slides.ICommentAuthor-). تعرض وحدة التحكم نص التعليق الأول مرتين، مما يُظهر الوصول من خلال كل من الشريحة والمؤلف، وتحتوي العرض التقديمي المحفوظ على كلا التعليقين.

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

## **البحث عن مؤلف تعليق أو إنشاؤه**

عند معالجة مراجعة تلقائية للعرض التقديمي نفسه بشكل متكرر، ابحث في التجميع المسترجع من خلال [getCommentAuthors](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getCommentAuthors--) قبل إضافة مؤلف. تُطابق [findByNameAndInitials](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommentauthorcollection/#findByNameAndInitials-java.lang.String-java.lang.String-) كلًا من الاسم والأحرف الأولى وتُعيد مصفوفة من المؤلفين المطابقين، أو مصفوفة فارغة إذا لم توجد مطابقات. بالمقابل، تبحث [findByName](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommentauthorcollection/#findByName-java.lang.String-) بالاسم فقط، بغض النظر عن الأحرف الأولى. استدعاء [addAuthor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommentauthorcollection/#addAuthor-java.lang.String-java.lang.String-) باسم وأحرف أولية موجودين بالفعل في التجميع يُسبب استثناءً.

يتطلب المثال ملف عرض تقديمي يحتوي على شريحة واحدة على الأقل. في كل من المرورين، يُعيد استخدام المؤلف المطابق الأول، أو ينشئ واحدًا فقط عندما تكون النتيجة فارغة. إذا كان هناك عدة مطابقات، يختار العنصر الأول من المصفوفة دون دمج أو إزالة المؤلفين الآخرين. ثم يستدعي [addComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommentcollection/#addComment-java.lang.String-com.aspose.slides.ISlide-android.graphics.PointF-java.util.Date-) للمؤلف المحدد ويحفظ العرض التقديمي. يفتح المرور الثاني مخرجات المرور الأول ويكرر العملية.

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

يضيف المرور الثاني تعليقًا آخر دون إضافة مؤلف آخر أو إزالة التعليقات الموجودة. يحتوي الملف النهائي، `review_pass_2.pptx`، على كل من التعليقات الجديدة وأي تعليقات أصلية. إعادة استخدام المؤلف لا تُزيل التكرارات: لتجنب إضافة نفس التعليق مرارًا، نفّذ كشفًا منفصلًا للنسخ المكررة قبل إضافته.

## **الوصول إلى تعليقات الشرائح**

يفتح المثال عرض تقديمي موجودًا ويقرأ التجميع المسترجع من خلال [getCommentAuthors](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getCommentAuthors--). لكل مؤلف، يتنقل عبر التجميع المسترجع من خلال [getComments](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommentauthor/#getComments--) ويطبع رقم الشريحة، نص التعليق، اسم المؤلف، ووقت الإنشاء. يجب أن يحتوي عرض الإدخال على تعليقات لتوليد مخرجات وحدة التحكم.

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

التعليق الأصلي هو التعليق الأصلي في قمة شجرة الردود. تسمح طُرُق [IComment.getParentComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icomment/#getParentComment--) و[IComment.setParentComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icomment/#setParentComment-com.aspose.slides.IComment-) بالحصول على أو تعيين التعليق الأب.

ينشئ المثال تعليقات من مؤلفين اثنين ويستخدم [setParentComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icomment/#setParentComment-com.aspose.slides.IComment-) لبناء الردود، بما في ذلك رد على رد آخر. تمرير `null` إلى [getSlideComments](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#getSlideComments-com.aspose.slides.ICommentAuthor-) يسترجع التعليقات من جميع المؤلفين؛ تُظهر وحدة التحكم كل إدخال مُزاحًا وفقًا لعمقه في شجرة الردود. يحفظ المثال النقاش الكامل، يستدعي [remove](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icomment/#remove--) على أول تعليق جذري، ويحفظ عرضًا تقديميًا ثانيًا مع ذلك التعليق وردوده مُزالة.

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
* عند استخدام طريقة [IComment.remove](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icomment/#remove--) لحذف تعليق، تُحذف جميع الردود على ذلك التعليق أيضًا.
* إذا أنشأت [IComment.setParentComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icomment/#setParentComment-com.aspose.slides.IComment-) مرجعًا دائريًا، يُطرح استثناء [PptxEditException](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pptxeditexception/).
{{% /alert %}}

## **إضافة تعليقات حديثة**

يمكن ربط التعليقات الحديثة بالشرائح نفسها، أو ب形状 معين، أو بنطاق نص داخل AutoShape. تقبل طريقة [ICommentCollection.addModernComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommentcollection/#addModernComment-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-android.graphics.PointF-java.util.Date-) وسيطًا من نوع [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) بالإضافة إلى الشريحة وإحداثيات مؤشر التعليق.

عند تمرير `null` كقيمة للمتغير الشكل، يكون التعليق تعليقًا على مستوى الشريحة. يُحدد موقع المؤشر بالإحداثيات المقدمة، لكنه غير مرتبط بشكل محدد؛ لذا تُعيد [IModernComment.getShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#getShape--) `null`. عند توفير [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/)، يُثبَّت التعليق على ذلك الشكل. لا تزال الإحداثيات تُحدِّد موقع مؤشر التعليق على الشريحة، ويمكن استرجاع ربط الشكل عبر [IModernComment.getShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#getShape--).

### **تثبيت تعليق حديث إلى شكل**

يستدعي المثال [addModernComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommentcollection/#addModernComment-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-android.graphics.PointF-java.util.Date-) مرتين: مرةً بـ `null` لشكل تعليق على مستوى الشريحة ومرةً بالمستطيل كمرساة. يطبع قراءة [getShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#getShape--) `true` للتحقق من `null` في تعليق مستوى الشريحة و`Revenue title` للتعليق المثبت. يُحفظ كلا التعليقين مع العرض التقديمي.

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

### **تثبيت التعليقات على أنواع أشكال مختلفة**

يمكن استخدام أي كائن شريحة يُنفِّذ [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) كمرساة للشكل. تشمل الأمثلة الشائعة [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/)، [IPictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframe/)، [IGroupShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshape/)، [IConnector](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iconnector/)، و[IIGraphicalObject](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igraphicalobject/) مثل المخططات.

يستخدم المثال [addModernComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommentcollection/#addModernComment-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-android.graphics.PointF-java.util.Date-) لربط تعليق مع كل من الأنواع الخمسة للأشكال: AutoShape، إطار صورة، مجموعة، موصل، ومخطط. تستخدم الصورة بيانات صورة مضمنة، لذا لا تحتاج إلى صورة خارجية. لكل تعليق موقع مؤشر خاص به، ويحتفظ العرض التقديمي المحفوظ بجميع الروابط الخمسة للأشكال.

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

### **تثبيت تعليق على نص وتعيين حالته**

لتعليق حديث مرتبط بـ [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/)، تُتيح طُرُق [IModernComment.getTextSelectionStart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#getTextSelectionStart--) و[IModernComment.setTextSelectionStart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#setTextSelectionStart-int-) الوصول إلى موضع بدء النص المحدد في إطار نص الـ AutoShape. وتُتيح [IModernComment.getTextSelectionLength](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#getTextSelectionLength--) و[IModernComment.setTextSelectionLength](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#setTextSelectionLength-int-) الوصول إلى طول الاختيار. معًا، تُربط هذه القيم التعليق بنطاق نص محدد داخل الـ AutoShape.

تُتيح طُرُق [IModernComment.getStatus](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#getStatus--) و[IModernComment.setStatus](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#setStatus-byte-) الوصول إلى قيمة من ثابت [ModernCommentStatus](https://reference.aspose.com/slides/androidjava/com.aspose.slides/moderncommentstatus/):

- `NotDefined` — لا توجد حالة محددة للتعليق الحديث.
- `Active` — التعليق نشط.
- `Resolved` — تم حل التعليق.
- `Closed` — التعليق مغلق.

يُثبت المثال تعليقًا حديثًا على الكلمات "quarterly revenue" في نص المستطيل. يحسب بداية الاختيار بصفر من النص ويمررها إلى [setTextSelectionStart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#setTextSelectionStart-int-) ويستخدم [setTextSelectionLength](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#setTextSelectionLength-int-) لتحديد عدد الأحرف المحددة. بعد استدعاء [setStatus](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#setStatus-byte-) بالقيمة `Resolved`، يحفظ ويعيد فتح العرض التقديمي. يجب أن تطبع الفحوصات الأربعة في وحدة التحكم `true`، مُؤكِّدة أن ربط الشكل، نطاق النص، والحالة تم حفظها.

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

### **فحص التعليقات الحديثة الموجودة**

يتطلب المثال عرضًا تقديميًا موجودًا يحتوي على تعليقات حديثة ويطبع نصها، حالتها، وتفاصيل الربط. لفحصه، تحقق من التعليقات التي تُنفِّذ [IModernComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/)، ثم افحص [IModernComment.getShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#getShape--)، [IModernComment.getTextSelectionStart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#getTextSelectionStart--)، [IModernComment.getTextSelectionLength](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#getTextSelectionLength--)، و[IModernComment.getStatus](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#getStatus--). يشير الشكل `null` إلى تعليق على مستوى الشريحة. بالنسبة لمرساة [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/)، تُحدِّد طرق اختيار النص النطاق المرتبط في إطار نص الشكل.

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

يسمح Aspose.Slides for Android عبر Java بإزالة جميع التعليقات ومؤلفيها من العرض التقديمي أو حذف تعليقات مختارة مع الحفاظ على البقية. تُظهر الأمثلة التالية كلا النهجين وتحفظ العرض التقديمي المحدث.

### **إزالة جميع التعليقات ومؤلفي التعليقات**

يفتح المثال عرضًا تقديميًا موجودًا ويستدعي [ICommentCollection.clear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommentcollection/#clear--) لكل مؤلف، ثم يستدعي [ICommentAuthorCollection.clear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommentauthorcollection/#clear--) لإزالة المؤلفين أنفسهم. يحتوي العرض التقديمي المحفوظ على لا تعليقات ولا مؤلفي تعليقات. استخدم عرضًا تقديميًا يحتوي على تعليقات لملاحظة الإزالة.

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

ينشئ المثال تعليقاتين على شريحة واحدة ويستخدم [getSlideComments](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#getSlideComments-com.aspose.slides.ICommentAuthor-) لإيجاد التعليقات لكل مؤلف. يجمع التعليقات التي يساوي نصها "comment 1" قبل استدعاء [ICommentCollection.remove](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommentcollection/#remove-com.aspose.slides.IComment-)، متجنبًا تعديل التجميع أثناء الاختيار. يحتفظ العرض التقديمي المحفوظ فقط بـ "comment 2".

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

## **الأسئلة المتكررة**

**هل يدعم Aspose.Slides حالة "مُحلولة" للتعليقات الحديثة؟**

نعم. تُتيح طُرُق [IModernComment.getStatus](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#getStatus--) و[IModernComment.setStatus](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#setStatus-byte-) الوصول إلى قيمة من [ModernCommentStatus](https://reference.aspose.com/slides/androidjava/com.aspose.slides/moderncommentstatus/) تشمل `Resolved`. تُحفظ الحالة في العرض التقديمي ويمكن قراءتها مرة أخرى بعد إعادة فتح الملف.

**هل تدعم المناقشات المتسلسلة (سلاسل الردود) وهل هناك حد للتعشيق؟**

نعم. يمكن لكل تعليق الإشارة إلى [parent comment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icomment/#getParentComment--) الخاص به، مما يمكّن سلاسل الردود. لا تُحدد الواجهة حدًا معينًا لعمق التعشيق.

**في أي نظام إحداثيات يُعرَّف موضع مؤشر التعليق على الشريحة؟**

يُعرَّف موضع المؤشر بإحداثيات نقطية عائمة في نظام إحداثيات الشريحة، مما يتيح لك وضعه بدقة على الشريحة.