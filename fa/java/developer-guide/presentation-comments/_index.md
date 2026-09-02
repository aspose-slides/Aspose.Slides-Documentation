---
title: مدیریت نظرات ارائه در جاوا
linktitle: نظرات ارائه
type: docs
weight: 100
url: /fa/java/presentation-comments/
keywords:
- نظر
- نظر مدرن
- نظرات پاورپوینت
- نظرات ارائه
- نظرات اسلاید
- افزودن نظر
- دسترسی به نظر
- ویرایش نظر
- پاسخ به نظر
- حذف نظر
- پاک کردن نظر
- پاورپوینت
- ارائه
- جاوا
- Aspose.Slides
description: "نظرات ارائه را با Aspose.Slides برای جاوا مدیریت کنید: نظرات را به‌سرعت و به‌سادگی در ارائه‌های پاورپوینت اضافه، بخوانید، ویرایش کنید، به آن‌ها پاسخ دهید و حذف کنید."
---
## **مروری کلی**

این مقاله توضیح می‌دهد که چگونه می‌توان نظرات ارائه را با Aspose.Slides for Java مدیریت کرد. انواع اصلی مرتبط با نظرات معرفی می‌شود و نحوه افزودن نظرات به اسلایدها، دسترسی به نظرات موجود، کار با پاسخ‌ها و نظرات مدرن، و حذف نظرات از یک ارائه نشان داده می‌شود.

مثال‌ها سناریوهای رایج بازبینی و همکاری در PowerPoint را پوشش می‌دهند، از جمله اختصاص نظرات به نویسندگان، خواندن متن نظر و فراداده‌ها، ساخت زنجیره‌های پاسخ، و حذف نظرات انتخابی یا همه نظرات.

در PowerPoint، نظرات به‌صورت حاشیه‌نویسی روی اسلایدها ظاهر می‌شوند. انتخاب یک نظر متن و بحث مرتبط با آن را نمایش می‌دهد.

## **چرا نظرات را به ارائه‌ها اضافه کنیم؟**

می‌توانید از نظرات برای ارائه بازخورد و همکاری با همکاران هنگام بازبینی ارائه‌ها استفاده کنید.

Aspose.Slides for Java APIهای زیر را برای کار با نظرات فراهم می‌کند:

* کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) که دسترسی به نویسندگان نظرات ارائه را فراهم می‌کند.
* اینترفیس [ICommentCollection](https://reference.aspose.com/slides/fa/java/com.aspose.slides/icommentcollection/) که نظرات مرتبط با یک نویسنده خاص را نشان می‌دهد.
* اینترفیس [IComment](https://reference.aspose.com/slides/fa/java/com.aspose.slides/icomment/) که اطلاعاتی درباره یک نظر شامل نویسنده، زمان ایجاد، موقعیت و متن را ارائه می‌دهد.
* کلاس [CommentAuthor](https://reference.aspose.com/slides/fa/java/com.aspose.slides/commentauthor/) که اطلاعاتی درباره یک نویسنده از جمله نام، حروف اولیه و نظرات مرتبط را فراهم می‌کند.

## **افزودن نظرات به اسلاید**

مثال زیر نشان می‌دهد چگونه به اسلایدهای یک ارائه PowerPoint نظر اضافه کنیم:

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

## **دسترسی به نظرات اسلاید**

مثال زیر نشان می‌دهد چگونه به نظرات موجود در یک ارائه PowerPoint دسترسی پیدا کنیم:

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

## **پاسخ به نظرات**

یک نظر والد، نظر اصلی در بالای سلسله‌مراتبی پاسخ‌هاست. متدهای [IComment.getParentComment](https://reference.aspose.com/slides/fa/java/com.aspose.slides/icomment/#getParentComment--) و [IComment.setParentComment](https://reference.aspose.com/slides/fa/java/com.aspose.slides/icomment/#setParentComment-com.aspose.slides.IComment-) به شما امکان دریافت یا تنظیم والد یک نظر را می‌دهند.

مثال زیر نشان می‌دهد چگونه پاسخ‌ها را اضافه کرده و ساختار سلسله‌مراتبی نظرات حاصل را بررسی کنیم:

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
* وقتی متد [IComment.remove](https://reference.aspose.com/slides/fa/java/com.aspose.slides/icomment/#remove--) برای حذف یک نظر استفاده می‌شود، تمام پاسخ‌های آن نیز حذف می‌شوند.
* اگر [IComment.setParentComment](https://reference.aspose.com/slides/fa/java/com.aspose.slides/icomment/#setParentComment-com.aspose.slides.IComment-) باعث ایجاد ارجاع دوری شود، یک [PptxEditException](https://reference.aspose.com/slides/fa/java/com.aspose.slides/pptxeditexception/) پرتاب می‌گردد.
{{% /alert %}}

## **افزودن نظرات مدرن**

نظرات مدرن می‌توانند به خود اسلاید، به یک شکل خاص، یا به بازه متنی داخل یک AutoShape مرتبط شوند. متد [ICommentCollection.addModernComment](https://reference.aspose.com/slides/fa/java/com.aspose.slides/icommentcollection/#addModernComment-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-java.awt.geom.Point2D.Float-java.util.Date-) علاوه بر اسلاید و مختصات نشانگر نظر، یک آرگومان [IShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ishape/) دریافت می‌کند.

زمانی که برای آرگومان shape مقدار `null` ارسال شود، نظر یک نظر سطح اسلاید است. نشانگر آن توسط مختصات ارائه شده موقعیت می‌گیرد، اما به شکل خاصی پیوست نشده است، بنابراین [IModernComment.getShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/imoderncomment/#getShape--) مقدار `null` برمی‌گرداند. وقتی یک [IShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ishape/) فراهم شود، نظر به آن شکل متصل می‌شود. مختصات همچنان موقعیت نشانگر نظر روی اسلاید را تعریف می‌کند، در حالی که ارتباط شکل از طریق [IModernComment.getShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/imoderncomment/#getShape--) قابل بازیابی است.

### **پیوست کردن یک نظر مدرن به یک شکل**

مثال زیر هم یک نظر مدرن سطح اسلاید و هم یک نظر مدرن متصل به یک AutoShape خاص ایجاد می‌کند. سپس شکل مرتبط با هر نظر را می‌خواند:

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

### **پیوست کردن نظرات به انواع مختلف شکل‌ها**

هر شیء اسلایدی که اینترفیس [IShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ishape/) را پیاده‌سازی کند می‌تواند به‌عنوان نقطه اتصال شکل مورد استفاده قرار گیرد. نمونه‌های رایج شامل [IAutoShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iautoshape/)، [IPictureFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ipictureframe/)، [IGroupShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/igroupshape/)، [IConnector](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iconnector/)، و نمونه‌های [IGraphicalObject](https://reference.aspose.com/slides/fa/java/com.aspose.slides/igraphicalobject/) مانند نمودارها است.

مثال زیر چند نوع شکل رایج ایجاد کرده و یک نظر مدرن را به هر یک پیوست می‌کند:

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

### **پیوست کردن یک نظر به متن و تنظیم وضعیت آن**

برای یک نظر مدرن مرتبط با یک [IAutoShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iautoshape/)، متدهای [IModernComment.getTextSelectionStart](https://reference.aspose.com/slides/fa/java/com.aspose.slides/imoderncomment/#getTextSelectionStart--) و [IModernComment.setTextSelectionStart](https://reference.aspose.com/slides/fa/java/com.aspose.slides/imoderncomment/#setTextSelectionStart-int-) موقعیت شروع متن انتخاب‌شده در فریم متن شکل را برمی‌گردانند. متدهای [IModernComment.getTextSelectionLength](https://reference.aspose.com/slides/fa/java/com.aspose.slides/imoderncomment/#getTextSelectionLength--) و [IModernComment.setTextSelectionLength](https://reference.aspose.com/slides/fa/java/com.aspose.slides/imoderncomment/#setTextSelectionLength-int-) طول انتخاب را بازمی‌گردانند. این مقادیر با هم نظر را به بازه متنی مشخصی داخل AutoShape مرتبط می‌کنند.

متدهای [IModernComment.getStatus](https://reference.aspose.com/slides/fa/java/com.aspose.slides/imoderncomment/#getStatus--) و [IModernComment.setStatus](https://reference.aspose.com/slides/fa/java/com.aspose.slides/imoderncomment/#setStatus-byte-) مقدار یک ثابت از  [ModernCommentStatus](https://reference.aspose.com/slides/fa/java/com.aspose.slides/moderncommentstatus/) را فراهم می‌کنند:

- `NotDefined` — هیچ وضعیت خاصی برای نظر مدرن تعریف نشده است.
- `Active` — نظر فعال است.
- `Resolved` — نظر حل شده است.
- `Closed` — نظر بسته شده است.

مثال زیر یک نظر مدرن متصل به شکل ایجاد می‌کند، آن را به یک بازه متنی پیوست می‌سازد، به عنوان حل‌شده علامت‌گذاری می‌کند، ارائه را ذخیره می‌کند و پس از بازگشایی فایل مقادیر را تأیید می‌کند:

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

### **بازرسی نظرات مدرن موجود**

برای بازرسی یک ارائه موجود، ابتدا بررسی کنید کدام نظرات پیاده‌سازی [IModernComment](https://reference.aspose.com/slides/fa/java/com.aspose.slides/imoderncomment/) را دارند، سپس به [IModernComment.getShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/imoderncomment/#getShape--)، [IModernComment.getTextSelectionStart](https://reference.aspose.com/slides/fa/java/com.aspose.slides/imoderncomment/#getTextSelectionStart--)، [IModernComment.getTextSelectionLength](https://reference.aspose.com/slides/fa/java/com.aspose.slides/imoderncomment/#getTextSelectionLength--) و [IModernComment.getStatus](https://reference.aspose.com/slides/fa/java/com.aspose.slides/imoderncomment/#getStatus--) نگاهی بیندازید. یک شکل `null` نشان‌دهنده یک نظر سطح اسلاید است. برای یک نقطه اتصال [IAutoShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iautoshape/)، متدهای انتخاب متن بازه متنی مرتبط در فریم متن شکل را شناسایی می‌کنند.

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

## **حذف نظرات**

### **حذف همه نظرات و نویسندگان نظرات**

مثال زیر نشان می‌دهد چگونه همه نظرات و نویسندگان نظرات را از یک ارائه حذف کنیم:

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

### **حذف نظرات خاص**

مثال زیر نشان می‌دهد چگونه نظرات خاصی را از یک اسلاید حذف کنیم:

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

## **سؤالات متداول**

**آیا Aspose.Slides وضعیت حل‌شده برای نظرات مدرن را پشتیبانی می‌کند؟**

بله. متدهای [IModernComment.getStatus](https://reference.aspose.com/slides/fa/java/com.aspose.slides/imoderncomment/#getStatus--) و [IModernComment.setStatus](https://reference.aspose.com/slides/fa/java/com.aspose.slides/imoderncomment/#setStatus-byte-) یک مقدار از [ModernCommentStatus](https://reference.aspose.com/slides/fa/java/com.aspose.slides/moderncommentstatus/) را در اختیار می‌گذارند، از جمله `Resolved`. این وضعیت در ارائه ذخیره می‌شود و پس از بازگشایی فایل قابل خواندن است.

**آیا بحث‌های سلسله‌مراتبی (زنجیره‌های پاسخ) پشتیبانی می‌شوند و آیا محدودیتی برای تو در تو بودن وجود دارد؟**

بله. هر نظر می‌تواند به [parent comment](https://reference.aspose.com/slides/fa/java/com.aspose.slides/icomment/#getParentComment--) خود ارجاع دهد و زنجیره‌های پاسخ را فعال کند. API محدودیت مشخصی برای عمق تو در تویی تعریف نمی‌کند.

**موقعیت نشانگر نظر بر روی اسلاید بر پایهٔ چه سیستم مختصاتی تعریف می‌شود؟**

موقعیت نشانگر توسط مختصات نقطه شناور در سیستم مختصات اسلاید تعریف می‌شود، که امکان قرارگیری دقیق آن روی اسلاید را فراهم می‌کند.