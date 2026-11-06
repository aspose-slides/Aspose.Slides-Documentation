---
title: مدیریت نظرات ارائه در Java
linktitle: نظرات ارائه
type: docs
weight: 100
url: /fa/java/presentation-comments/
keywords:
- نظر
- نظر مدرن
- نظرات PowerPoint
- نظرات ارائه
- نظرات اسلاید
- افزودن نظر
- دسترسی به نظر
- ویرایش نظر
- پاسخ به نظر
- حذف نظر
- حذف نظر
- PowerPoint
- ارائه
- Java
- Aspose.Slides
description: "نظرات ارائه را با Aspose.Slides برای Java مدیریت کنید: اضافه‌کردن، خواندن، ویرایش، پاسخ‌دادن و حذف نظرات در ارائه‌های PowerPoint به‌سرعت و به‌سادگی."
---
## **مرور کلی**

این مقاله توضیح می‌دهد که چگونه نظرات ارائه را با Aspose.Slides for Java مدیریت کنید. انواع اصلی مرتبط با نظرات معرفی می‌شود و نشان داده می‌شود چطور نظرات را به اسلایدها اضافه کنید، نظرات موجود را دسترسی داشته باشید، با پاسخ‌ها و نظرات مدرن کار کنید و نظرات را از یک ارائه حذف کنید.

نمونه‌ها سناریوهای رایج مرور و همکاری در PowerPoint را پوشش می‌دهند، مانند اختصاص نظرات به نویسندگان، خواندن متن و متادیتای نظر، ساخت زنجیره‌های پاسخ و حذف نظرات انتخابی یا تمام نظرات.

در PowerPoint، نظرات به‌عنوان حاشیه‌نویسی بر روی اسلایدها ظاهر می‌شوند. انتخاب یک نظر، متن و بحث مرتبط را نمایش می‌دهد.

برای درخواست نمایش یا پنهان کردن نظرات هنگام باز کردن یک ارائه بدون تغییر نظرات، به [نمایش یا پنهان کردن نظرات هنگام باز کردن ارائه](/slides/fa/java/presentation-view-properties/) مراجعه کنید.

## **چرا نظرات به ارائه‌ها اضافه کنیم؟**

می‌توانید از نظرات برای ارائه بازخورد و همکاری با همکاران هنگام مرور ارائه‌ها استفاده کنید.

Aspose.Slides for Java APIهای زیر را برای کار با نظرات فراهم می‌کند:

* کلاس [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) که دسترسی به نویسندگان نظرات ارائه را فراهم می‌کند.
* اینترفیس [ICommentCollection](https://reference.aspose.com/slides/java/com.aspose.slides/icommentcollection/) که نظرات مرتبط با یک نویسندهٔ خاص را نمایندگی می‌کند.
* اینترفیس [IComment](https://reference.aspose.com/slides/java/com.aspose.slides/icomment/) که اطلاعاتی دربارهٔ یک نظر شامل نویسنده، زمان ایجاد، موقعیت و متن را ارائه می‌دهد.
* کلاس [CommentAuthor](https://reference.aspose.com/slides/java/com.aspose.slides/commentauthor/) که اطلاعاتی دربارهٔ یک نویسنده شامل نام، حروف اولیه و نظرات مرتبط را فراهم می‌کند.

## **افزودن نظرات اسلاید**

این مثال دو اسلاید ایجاد می‌کند و یک نویسندهٔ نظر را با [addAuthor](https://reference.aspose.com/slides/java/com.aspose.slides/icommentauthorcollection/#addAuthor-java.lang.String-java.lang.String-) ثبت می‌کند. سپس با [addComment](https://reference.aspose.com/slides/java/com.aspose.slides/icommentcollection/#addComment-java.lang.String-com.aspose.slides.ISlide-java.awt.geom.Point2D.Float-java.util.Date-) یک نظر روی هر اسلاید قرار می‌دهد و نظرات اسلاید اول برای آن نویسنده را با [getSlideComments](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#getSlideComments-com.aspose.slides.ICommentAuthor-) بازیابی می‌کند. کنسول متن اولین نظر را دو بار نمایش می‌دهد تا دسترسی هم از طریق اسلاید و هم از طریق نویسنده نشان داده شود و ارائهٔ ذخیره‌شده شامل هر دو نظر می‌شود.

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

## **پیدا کردن یا ایجاد نویسندهٔ نظر**

هنگامی که یک مرور خودکار همان ارائه را بارها پردازش می‌کند، قبل از افزودن نویسنده از مجموعه‌ای که توسط [getCommentAuthors](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getCommentAuthors--) برگردانده می‌شود جستجو کنید. متد [findByNameAndInitials](https://reference.aspose.com/slides/java/com.aspose.slides/icommentauthorcollection/#findByNameAndInitials-java.lang.String-java.lang.String-) هم نام و هم حروف اولیه را مطابقت می‌دهد و یک آرایهٔ نویسندگان منطبق یا آرایهٔ خالی برمی‌گرداند. در مقابل، [findByName](https://reference.aspose.com/slides/java/com.aspose.slides/icommentauthorcollection/#findByName-java.lang.String-) تنها بر اساس نام جستجو می‌کند، بدون توجه به حروف اولیه. فراخوانی [addAuthor](https://reference.aspose.com/slides/java/com.aspose.slides/icommentauthorcollection/#addAuthor-java.lang.String-java.lang.String-) با یک نام و حروف اولیهٔ که پیش‌اپ پیش در مجموعه موجود است، باعث پرتاب استثنا می‌شود.

این مثال نیاز به فایلی دارد که حداقل یک اسلاید داشته باشد. در هر دو پاس، نویسندهٔ اولین مطابقت را بازاستفاده می‌کند یا فقط زمانی که نتیجه خالی باشد نویسنده‌ای جدید می‌سازد. اگر چند مطابقت وجود داشته باشد، اولین عنصر آرایه انتخاب می‌شود بدون ترکیب یا حذف نویسندگان دیگر. سپس برای نویسندهٔ انتخاب‌شده با [addComment](https://reference.aspose.com/slides/java/com.aspose.slides/icommentcollection/#addComment-java.lang.String-com.aspose.slides.ISlide-java.awt.geom.Point2D.Float-java.util.Date-) نظر اضافه می‌کند و ارائه را ذخیره می‌کند. پاس دوم خروجی پاس اول را باز می‌کند و عملیات را تکرار می‌کند.

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

پاس دوم نظر دیگری اضافه می‌کند بدون اینکه نویسندهٔ دیگری اضافه یا نظرات موجود حذف شود. فایل نهایی، `review_pass_2.pptx`، هر دو نظر جدید را همراه با هر نظر اصلی شامل می‌شود. بازاستفاده از نویسنده باعث حذف مضduplicate نظرات نمی‌شود: برای جلوگیری از افزودن مکرر همان نظر، قبل از افزودن آن تشخیص تکراری جداگانه‌ای پیاده‌سازی کنید.

## **دسترسی به نظرات اسلاید**

این مثال یک ارائهٔ موجود را باز می‌کند و مجموعه‌ای که توسط [getCommentAuthors](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getCommentAuthors--) برگردانده می‌شود می‌خواند. برای هر نویسنده، از مجموعه‌ای که توسط [getComments](https://reference.aspose.com/slides/java/com.aspose.slides/icommentauthor/#getComments--) برگردانده می‌شود می‌گردد و شماره اسلاید، متن نظر، نام نویسنده و زمان ایجاد را چاپ می‌کند. ارائهٔ ورودی باید شامل نظرات باشد تا خروجی کنسول تولید شود.

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

یک نظر والد، نظر اصلی در بالای یک سلسله‌مراتب پاسخ است. متدهای [IComment.getParentComment](https://reference.aspose.com/slides/java/com.aspose.slides/icomment/#getParentComment--) و [IComment.setParentComment](https://reference.aspose.com/slides/java/com.aspose.slides/icomment/#setParentComment-com.aspose.slides.IComment-) به شما اجازه می‌دهند والد یک نظر را دریافت یا تنظیم کنید.

این مثال نظراتی از دو نویسنده ایجاد می‌کند و با [setParentComment](https://reference.aspose.com/slides/java/com.aspose.slides/icomment/#setParentComment-com.aspose.slides.IComment-) پاسخ‌ها را می‌سازد، از جمله پاسخی به یک پاسخ دیگر. پاس دادن `null` به [getSlideComments](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#getSlideComments-com.aspose.slides.ICommentAuthor-) نظرات همهٔ نویسندگان را بازیابی می‌کند؛ کنسول هر ورودی را بر اساس عمق آن در سلسله‌مراتب پاسخ تورفتگی می‌کند. مثال بحث کامل را ذخیره می‌کند، روی اولین نظر ریشه‌ای [remove](https://reference.aspose.com/slides/java/com.aspose.slides/icomment/#remove--) صدا می‌زند و یک ارائهٔ دوم را با حذف آن نظر و پاسخ‌هایش ذخیره می‌کند.

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
* هنگام استفاده از متد [IComment.remove](https://reference.aspose.com/slides/java/com.aspose.slides/icomment/#remove--) برای حذف یک نظر، تمام پاسخ‌های آن نیز حذف می‌شوند.
* اگر [IComment.setParentComment](https://reference.aspose.com/slides/java/com.aspose.slides/icomment/#setParentComment-com.aspose.slides.IComment-) یک ارجاع حلقه‌ای ایجاد کند، یک [PptxEditException](https://reference.aspose.com/slides/java/com.aspose.slides/pptxeditexception/) پرتاب می‌شود.
{{% /alert %}}

## **افزودن نظرات مدرن**

نظرات مدرن می‌توانند به خود اسلاید، به یک شکل خاص یا به یک بازهٔ متنی داخل یک AutoShape مرتبط شوند. متد [ICommentCollection.addModernComment](https://reference.aspose.com/slides/java/com.aspose.slides/icommentcollection/#addModernComment-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-java.awt.geom.Point2D.Float-java.util.Date-) علاوه بر اسلاید و مختصات نشانگر نظر، آرگومان یک [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) را می‌پذیرد.

زمانی که برای آرگومان shape مقدار `null` پاس داده شود، نظر یک نظر سطح اسلاید است. نشانگر آن توسط مختصات ارائه‌شده موقعیت می‌یابد، اما به شکل خاصی مرتبط نیست، بنابراین [IModernComment.getShape](https://reference.aspose.com/slides/java/com.aspose.slides/imoderncomment/#getShape--) `null` برمی‌گرداند. وقتی یک [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) فراهم شود، نظر به آن شکل لنگر می‌گیرد. مختصات همچنان موقعیت نشانگر نظر را روی اسلاید تعریف می‌کند، در حالی که ارتباط شکل می‌تواند از طریق [IModernComment.getShape](https://reference.aspose.com/slides/java/com.aspose.slides/imoderncomment/#getShape--) بازیابی شود.

### **اتصال یک نظر مدرن به یک شکل**

این مثال دو بار [addModernComment](https://reference.aspose.com/slides/java/com.aspose.slides/icommentcollection/#addModernComment-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-java.awt.geom.Point2D.Float-java.util.Date-) را صدا می‌کند: یک بار با شکل `null` برای نظری سطح اسلاید و یک بار با یک مستطیل به‌عنوان لنگر. خواندن [getShape](https://reference.aspose.com/slides/java/com.aspose.slides/imoderncomment/#getShape--) برای نظر سطح اسلاید `true` در بررسی `null` چاپ می‌کند و برای نظر لنگری `Revenue title` را چاپ می‌کند. هر دو نظر با ارائه ذخیره می‌شوند.

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

### **اتصال نظرات به انواع مختلف شکل‌ها**

هر شیء اسلایدی که پیاده‌سازی‌کنندهٔ [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) باشد می‌تواند به عنوان لنگر شکل استفاده شود. مثال‌های رایج شامل [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/)، [IPictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframe/)، [IGroupShape](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshape/)، [IConnector](https://reference.aspose.com/slides/java/com.aspose.slides/iconnector/) و نمونه‌های [IGraphicalObject](https://reference.aspose.com/slides/java/com.aspose.slides/igraphicalobject/) مانند نمودارها هستند.

این مثال از [addModernComment](https://reference.aspose.com/slides/java/com.aspose.slides/icommentcollection/#addModernComment-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-java.awt.geom.Point2D.Float-java.util.Date-) برای ارتباط یک نظر با هر یک از پنج نوع شکل استفاده می‌کند: یک AutoShape، یک picture frame، یک گروه، یک connector و یک نمودار. تصویر استفاده‌شده دادهٔ تصویری نهفته دارد، بنابراین نیازی به تصویر خارجی نیست. هر نظر موقعیت نشانگر خود را دارد و ارائهٔ ذخیره‌شده تمام پنج ارتباط شکل را نگه می‌دارد.

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

### **اتصال یک نظر به متن و تنظیم وضعیت آن**

برای یک نظر مدرن مرتبط با یک [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/)، متدهای [IModernComment.getTextSelectionStart](https://reference.aspose.com/slides/java/com.aspose.slides/imoderncomment/#getTextSelectionStart--) و [IModernComment.setTextSelectionStart](https://reference.aspose.com/slides/java/com.aspose.slides/imoderncomment/#setTextSelectionStart-int-) موقعیت شروع متن انتخاب‌شده در فریم متنی شکل را می‌گردانند. متدهای [IModernComment.getTextSelectionLength](https://reference.aspose.com/slides/java/com.aspose.slides/imoderncomment/#getTextSelectionLength--) و [IModernComment.setTextSelectionLength](https://reference.aspose.com/slides/java/com.aspose.slides/imoderncomment/#setTextSelectionLength-int-) طول انتخاب را برمی‌گردانند. ترکیب این مقادیر نظر را به بازهٔ متنی خاصی داخل AutoShape مرتبط می‌کند.

متدهای [IModernComment.getStatus](https://reference.aspose.com/slides/java/com.aspose.slides/imoderncomment/#getStatus--) و [IModernComment.setStatus](https://reference.aspose.com/slides/java/com.aspose.slides/imoderncomment/#setStatus-byte-) مقداری از ثابت‌های [ModernCommentStatus](https://reference.aspose.com/slides/java/com.aspose.slides/moderncommentstatus/) را برمی‌گردانند:

- `NotDefined` — وضعیت خاصی برای نظر مدرن تعریف نشده است.
- `Active` — نظر فعال است.
- `Resolved` — نظر حل شده است.
- `Closed` — نظر بسته است.

این مثال یک نظر مدرن را به کلمات «quarterly revenue» در متن یک مستطیل لنگر می‌کند. شروع انتخاب صفر‑مبنای متن را محاسبه می‌کند و به [setTextSelectionStart](https://reference.aspose.com/slides/java/com.aspose.slides/imoderncomment/#setTextSelectionStart-int-) می‌فرستد و با [setTextSelectionLength](https://reference.aspose.com/slides/java/com.aspose.slides/imoderncomment/#setTextSelectionLength-int-) تعداد کاراکترهای انتخاب‌شده را تنظیم می‌کند. پس از فراخوانی [setStatus](https://reference.aspose.com/slides/java/com.aspose.slides/imoderncomment/#setStatus-byte-) با `Resolved`، ارائه را ذخیره و دوباره باز می‌کند. چهار بررسی کنسول باید هر کدام `true` چاپ کنند تا تأیید شود که لنگر شکل، بازهٔ متنی و وضعیت حفظ شده‌اند.

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

### **بررسی نظرات مدرن موجود**

این مثال به یک ارائهٔ موجود حاوی نظرات مدرن نیاز دارد و متن، وضعیت و جزئیات لنگر آن‌ها را چاپ می‌کند. برای بررسی، تعیین کنید کدام نظرات پیاده‌سازی‌کنندهٔ [IModernComment](https://reference.aspose.com/slides/java/com.aspose.slides/imoderncomment/) هستند، سپس [IModernComment.getShape](https://reference.aspose.com/slides/java/com.aspose.slides/imoderncomment/#getShape--)، [IModernComment.getTextSelectionStart](https://reference.aspose.com/slides/java/com.aspose.slides/imoderncomment/#getTextSelectionStart--)، [IModernComment.getTextSelectionLength](https://reference.aspose.com/slides/java/com.aspose.slides/imoderncomment/#getTextSelectionLength--)، و [IModernComment.getStatus](https://reference.aspose.com/slides/java/com.aspose.slides/imoderncomment/#getStatus--) را بررسی کنید. یک shape `null` نشانگر نظر سطح اسلاید است. برای لنگر یک [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/)، متدهای انتخاب متن بازهٔ متنی مرتبط در فریم متنی شکل را شناسایی می‌کنند.

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

Aspose.Slides for Java به شما امکان می‌دهد تمام نظرات و نویسندگان آن‌ها را از یک ارائه حذف کنید یا نظرات منتخب را حذف کنید در حالی که بقیه حفظ می‌شوند. مثال‌های زیر هر دو روش را نشان می‌دهند و ارائه به‌روز‌شده را ذخیره می‌کنند.

### **حذف تمام نظرات و نویسندگان نظرات**

این مثال یک ارائهٔ موجود را باز می‌کند و برای هر نویسنده [ICommentCollection.clear](https://reference.aspose.com/slides/java/com.aspose.slides/icommentcollection/#clear--) را صدا می‌زند، سپس [ICommentAuthorCollection.clear](https://reference.aspose.com/slides/java/com.aspose.slides/icommentauthorcollection/#clear--) را برای حذف خود نویسندگان فراخوانی می‌کند. ارائهٔ ذخیره‌شده نه نظرات و نه نویسندگان نظرات را دارد. برای مشاهده حذف، از ارائه‌ای حاوی نظرات استفاده کنید.

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

این مثال دو نظر روی یک اسلاید ایجاد می‌کند و با [getSlideComments](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#getSlideComments-com.aspose.slides.ICommentAuthor-) نظرات هر نویسنده را پیدا می‌کند. نظراتی که متن آن‌ها برابر با «comment 1» است جمع‌آوری می‌کند قبل از اینکه [ICommentCollection.remove](https://reference.aspose.com/slides/java/com.aspose.slides/icommentcollection/#remove-com.aspose.slides.IComment-) را صدا بزند، تا از تغییر مجموعه هنگام انتخاب جلوگیری شود. ارائهٔ ذخیره‌شده فقط «comment 2» را حفظ می‌کند.

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

**آیا Aspose.Slides وضعیت حل‌شده را برای نظرات مدرن پشتیبانی می‌کند؟**

بله. متدهای [IModernComment.getStatus](https://reference.aspose.com/slides/java/com.aspose.slides/imoderncomment/#getStatus--) و [IModernComment.setStatus](https://reference.aspose.com/slides/java/com.aspose.slides/imoderncomment/#setStatus-byte-) مقداری از [ModernCommentStatus](https://reference.aspose.com/slides/java/com.aspose.slides/moderncommentstatus/) شامل `Resolved` را دسترسی می‌دهند. این وضعیت در ارائه ذخیره می‌شود و پس از بازگشایی فایل قابل خواندن است.

**آیا بحث‌های رشته‌ای (زنجیره پاسخ) پشتیبانی می‌شوند و آیا محدودیتی برای عمق تو در توی آن‌ها وجود دارد؟**

بله. هر نظر می‌تواند به [parent comment](https://reference.aspose.com/slides/java/com.aspose.slides/icomment/#getParentComment--) خود ارجاع دهد و زنجیره پاسخ‌ها را فعال کند. API محدودیت عمق خاصی تعریف نمی‌کند.

**موقعیت نشانگر نظر روی اسلاید بر پایهٔ چه سامانهٔ مختصاتی تعریف می‌شود؟**

موقعیت نشانگر توسط مختصات نقطه‌ای شناور در سامانهٔ مختصات اسلاید تعریف می‌شود، که امکان قرارگیری دقیق آن بر روی اسلاید را می‌دهد.