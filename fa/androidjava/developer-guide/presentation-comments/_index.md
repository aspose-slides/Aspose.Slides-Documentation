---
title: مدیریت نظرات ارائه در اندروید
linktitle: نظرات ارائه
type: docs
weight: 100
url: /fa/androidjava/presentation-comments/
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
- حذف نظرات
- پاورپوینت
- ارائه
- اندروید
- جاوا
- Aspose.Slides
description: "مدیریت نظرات ارائه با Aspose.Slides برای اندروید از طریق جاوا: افزودن، خواندن، ویرایش، پاسخ به و حذف نظرات در ارائه‌های پاورپوینت به‌سرعت و به‌سهولت."
---
## **بررسی کلی**

این مقاله توضیح می‌دهد که چگونه می‌توان نظرات ارائه را با Aspose.Slides برای Android via Java مدیریت کرد. انواع اصلی مرتبط با نظرات را معرفی می‌کند و نشان می‌دهد چگونه نظرات را به اسلایدها اضافه کنید، نظرات موجود را دسترسی داشته باشید، با پاسخ‌ها و نظرات مدرن کار کنید و نظرات را از یک ارائه حذف کنید.

مثال‌ها سناریوهای رایج مرور و همکاری در PowerPoint را پوشش می‌دهند، از جمله اختصاص نظرات به نویسندگان، خواندن متن نظر و متادیتا، ساخت زنجیره پاسخ‌ها و حذف نظرات انتخاب شده یا تمام نظرات.

در PowerPoint، نظرات به عنوان حاشیه‌نویسی بر روی اسلایدها ظاهر می‌شوند. انتخاب یک نظر متن و بحث مربوطه را نمایش می‌دهد.

برای درخواست نمایش یا پنهان کردن نظرات هنگام باز کردن یک ارائه بدون تغییر نظرات، به [نمایش یا مخفی کردن نظرات هنگام باز کردن یک ارائه](/slides/fa/androidjava/presentation-view-properties/) مراجعه کنید.

## **چرا نظرات را به ارائه‌ها اضافه کنیم؟**

می‌توانید از نظرات برای ارائه بازخورد و همکاری با همکاران هنگام مرور ارائه‌ها استفاده کنید.

Aspose.Slides برای Android via Java APIهای زیر را برای کار با نظرات فراهم می‌کند:

* کلاس [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) که دسترسی به نویسندگان نظرات ارائه را فراهم می‌کند.
* اینترفیس [ICommentCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommentcollection/) که نظرات مرتبط با یک نویسنده خاص را نشان می‌دهد.
* اینترفیس [IComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icomment/) که اطلاعاتی درباره یک نظر شامل نویسنده، زمان ایجاد، موقعیت و متن را فراهم می‌کند.
* کلاس [CommentAuthor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/commentauthor/) که اطلاعاتی درباره یک نویسنده شامل نام، حروف ابتدایی و نظرات مرتبط را ارائه می‌دهد.

## **افزودن نظرات به اسلاید**

مثال دو اسلاید ایجاد می‌کند و یک نویسنده نظرسازی را با [addAuthor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommentauthorcollection/#addAuthor-java.lang.String-java.lang.String-) ثبت می‌کند. از [addComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommentcollection/#addComment-java.lang.String-com.aspose.slides.ISlide-android.graphics.PointF-java.util.Date-) برای قرار دادن یک نظر در هر اسلاید استفاده می‌کند، سپس نظرات اسلاید اول برای آن نویسنده را با [getSlideComments](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#getSlideComments-com.aspose.slides.ICommentAuthor-) دریافت می‌کند. کنسول متن اولین نظر را دو بار نمایش می‌دهد، دسترسی از طریق اسلاید و نویسنده را نشان می‌دهد و ارائه ذخیره‌شده شامل هر دو نظر است.

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

## **یافتن یا ایجاد یک نویسنده نظر**

وقتی یک بازنگری خودکار به طور مکرر همان ارائه را پردازش می‌کند، قبل از افزودن نویسنده، مجموعه بازگردانده‌شده توسط [getCommentAuthors](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getCommentAuthors--) را جستجو کنید. [findByNameAndInitials](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommentauthorcollection/#findByNameAndInitials-java.lang.String-java.lang.String-) هم نام و هم حروف ابتدایی را مطابق می‌کند و آرایه‌ای از نویسندگان مطابق را برمی‌گرداند، یا آرایه خالی اگر مطابقتی وجود نداشته باشد. در مقابل، [findByName](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommentauthorcollection/#findByName-java.lang.String-) فقط بر اساس نام جستجو می‌کند، بدون در نظر گرفتن حروف ابتدایی. فراخوانی [addAuthor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommentauthorcollection/#addAuthor-java.lang.String-java.lang.String-) با نام و حروف ابتدایی‌ای که قبلاً در مجموعه موجود است، استثنا پرتاب می‌کند.

مثال به یک فایل ارائه با حداقل یک اسلاید نیاز دارد. در هر یک از دو عبور، اولین نویسنده مطابق را دوباره استفاده می‌کند، یا تنها زمانی که نتیجه خالی باشد، یکی ایجاد می‌کند. اگر چندین مطابقت وجود داشته باشد، اولین عنصر آرایه را بدون ادغام یا حذف دیگر نویسندگان انتخاب می‌کند. سپس برای نویسنده انتخاب‌شده [addComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommentcollection/#addComment-java.lang.String-com.aspose.slides.ISlide-android.graphics.PointF-java.util.Date-) را فراخوانی می‌کند و ارائه را ذخیره می‌کند. عبور دوم خروجی عبور اول را باز می‌کند و عملیات را تکرار می‌کند.

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

عبور دوم یک نظر دیگر بدون افزودن نویسنده دیگر یا حذف نظرات موجود اضافه می‌کند. فایل نهایی، `review_pass_2.pptx`، هر دو نظر جدید را همراه با هر نظر اصلی موجود در بر دارد. استفاده مجدد از یک نویسنده تکرار نظرات را حذف نمی‌کند: برای جلوگیری از افزودن مکرر همان نظر، قبل از افزودن آن تشخیص تکراری جداگانه‌ای پیاده‌سازی کنید.

## **دسترسی به نظرات اسلاید**

مثال یک ارائه موجود را باز می‌کند و مجموعه بازگردانده‌شده توسط [getCommentAuthors](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getCommentAuthors--) را می‌خواند. برای هر نویسنده، از مجموعه بازگردانده‌شده توسط [getComments](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommentauthor/#getComments--) عبور می‌کند و شماره اسلاید، متن نظر، نام نویسنده و زمان ایجاد را چاپ می‌کند. ارائه ورودی باید شامل نظرات باشد تا خروجی کنسول تولید شود.

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

یک نظر والد، نظر اصلی در بالای یک سلسله‌مراتب پاسخ‌ها است. متدهای [IComment.getParentComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icomment/#getParentComment--) و [IComment.setParentComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icomment/#setParentComment-com.aspose.slides.IComment-) به شما امکان می‌دهند والد یک نظر را دریافت یا تنظیم کنید.

مثال نظراتی از دو نویسنده ایجاد می‌کند و از [setParentComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icomment/#setParentComment-com.aspose.slides.IComment-) برای ساخت پاسخ‌ها، از جمله پاسخ به یک پاسخ دیگر، استفاده می‌کند. پاس دادن `null` به [getSlideComments](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#getSlideComments-com.aspose.slides.ICommentAuthor-) نظرات را از تمام نویسندگان بازیابی می‌کند؛ کنسول هر ورودی را بر اساس عمق آن در سلسله‌مراتب پاسخ‌ها تورفتگی می‌دهد. مثال بحث کامل را ذخیره می‌کند، بر روی اولین نظر ریشه [remove](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icomment/#remove--) را فراخوانی می‌کند و ارائه دومین را با آن نظر و پاسخ‌هایش حذف‌شده ذخیره می‌کند.

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
* هنگامی که متد [IComment.remove](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icomment/#remove--) برای حذف یک نظر استفاده می‌شود، تمام پاسخ‌های آن نظر نیز حذف می‌شوند.
* اگر [IComment.setParentComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icomment/#setParentComment-com.aspose.slides.IComment-) یک ارجاع حلقه‌ای ایجاد کند، یک [PptxEditException](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pptxeditexception/) پرتاب می‌شود.
{{% /alert %}}

## **افزودن نظرات مدرن**

نظرات مدرن می‌توانند به خود اسلاید، به یک شکل خاص یا به بازه متنی داخل یک AutoShape مرتبط شوند. متد [ICommentCollection.addModernComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommentcollection/#addModernComment-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-android.graphics.PointF-java.util.Date-) علاوه بر اسلاید و مختصات نشانگر نظر، یک آرگومان [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) را نیز می‌پذیرد.

زمانی که برای آرگومان shape مقدار `null` پاس شود، نظر یک نظر سطح اسلاید است. نشانگر آن با مختصات ارائه شده موقعیت‌یابی می‌شود، اما به شکل خاصی مرتبط نیست، بنابراین [IModernComment.getShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#getShape--) مقدار `null` برمی‌گرداند. هنگامی که یک [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) فراهم شود، نظر به آن شکل متصل می‌شود. مختصات همچنان موقعیت نشانگر نظر بر روی اسلاید را تعریف می‌کند، در حالی که ارتباط شکل می‌تواند از طریق [IModernComment.getShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#getShape--) بازیابی شود.

### **اتصال یک نظر مدرن به یک شکل**

مثال دو بار [addModernComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommentcollection/#addModernComment-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-android.graphics.PointF-java.util.Date-) را فراخوانی می‌کند: یک بار با shape `null` برای یک نظر سطح اسلاید و یک بار با یک مستطیل به عنوان لنگر. خواندن [getShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#getShape--) برای نظر سطح اسلاید مقدار `true` برای بررسی null و برای نظر متصل به شکل مقدار `Revenue title` را چاپ می‌کند. هر دو نظر همراه با ارائه ذخیره می‌شوند.

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

### **اتصال نظرات به انواع مختلف شکل‌ها**

هر شیء اسلایدی که پیاده‌سازی [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) را داشته باشد می‌تواند به عنوان لنگر شکل استفاده شود. مثال‌های رایج شامل [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/)، [IPictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframe/)، [IGroupShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshape/)، [IConnector](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iconnector/) و نمونه‌های [IGraphicalObject](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igraphicalobject/) مانند نمودارها هستند.

مثال از [addModernComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommentcollection/#addModernComment-java.lang.String-com.aspose.slides.ISlide-com.aspose.slides.IShape-android.graphics.PointF-java.util.Date-) برای ارتباط یک نظر با هر یک از پنج نوع شکل استفاده می‌کند: یک AutoShape، یک picture frame، یک گروه، یک connector و یک chart. تصویر استفاده شده داده‌های تصویری تعبیه‌شده دارد، بنابراین نیازی به تصویر خارجی نیست. هر نظر موقعیت نشانگر خود را دارد و ارائه ذخیره‌شده تمام پنج ارتباط شکل را حفظ می‌کند.

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

### **اتصال یک نظر به متن و تنظیم وضعیت آن**

برای یک نظر مدرن مرتبط با یک [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/)، متدهای [IModernComment.getTextSelectionStart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#getTextSelectionStart--) و [IModernComment.setTextSelectionStart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#setTextSelectionStart-int-) موقعیت شروع متنی انتخاب‌شده در فریم متنی شکل را دسترسی می‌دهند. متدهای [IModernComment.getTextSelectionLength](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#getTextSelectionLength--) و [IModernComment.setTextSelectionLength](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#setTextSelectionLength-int-) طول انتخاب را دسترسی می‌دهند. این مقادیر با هم نظر را به بازه متنی خاصی داخل AutoShape مرتبط می‌کنند.

متدهای [IModernComment.getStatus](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#getStatus--) و [IModernComment.setStatus](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#setStatus-byte-) مقداری از ثابت‌های [ModernCommentStatus](https://reference.aspose.com/slides/androidjava/com.aspose.slides/moderncommentstatus/) را دسترسی می‌دهند:

- `NotDefined` — هیچ وضعیت خاصی برای نظر مدرن تعریف نشده است.
- `Active` — نظر فعال است.
- `Resolved` — نظر حل‌شده است.
- `Closed` — نظر بسته شده است.

مثال یک نظر مدرن را به کلمات "quarterly revenue" در متن یک مستطیل می‌چسباند. شروع انتخاب صفر‑مبنایی را از متن محاسبه می‌کند و به [setTextSelectionStart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#setTextSelectionStart-int-) پاس می‌دهد و با استفاده از [setTextSelectionLength](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#setTextSelectionLength-int-) تعداد کاراکترهای انتخاب‌شده را تنظیم می‌کند. پس از فراخوانی [setStatus](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#setStatus-byte-) با `Resolved`، ارائه را ذخیره و دوباره باز می‌کند. چهار بررسی کنسول باید هر کدام مقدار `true` چاپ کنند، تأیید می‌کنند که لنگر شکل، بازه متن و وضعیت حفظ شده‌اند.

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

### **بازرسی نظرات مدرن موجود**

مثال به یک ارائه موجود حاوی نظرات مدرن نیاز دارد و متن، وضعیت و جزئیات لنگر آنها را چاپ می‌کند. برای بازرسی، بررسی کنید کدام نظرات پیاده‌سازی [IModernComment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/) را دارند، سپس به [IModernComment.getShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#getShape--)، [IModernComment.getTextSelectionStart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#getTextSelectionStart--)، [IModernComment.getTextSelectionLength](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#getTextSelectionLength--) و [IModernComment.getStatus](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#getStatus--) نگاه کنید. یک shape `null` نشان‌دهنده یک نظر سطح اسلاید است. برای یک لنگر [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/)، متدهای انتخاب متن بازه‌ای را که در فریم متنی شکل مرتبط است، مشخص می‌کنند.

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

Aspose.Slides برای Android via Java به شما امکان می‌دهد تمام نظرات و نویسندگان آن‌ها را از یک ارائه حذف کنید یا نظرات انتخابی را حذف کنید در حالی که بقیه را نگه می‌دارید. مثال‌های زیر هر دو رویکرد را نمایش می‌دهند و ارائه به‌روزشده را ذخیره می‌کنند.

### **حذف تمام نظرات و نویسندگان نظرات**

مثال یک ارائه موجود را باز می‌کند و برای هر نویسنده متد [ICommentCollection.clear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommentcollection/#clear--) را فراخوانی می‌کند، سپس برای حذف خود نویسندگان متد [ICommentAuthorCollection.clear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommentauthorcollection/#clear--) را صدا می‌زند. ارائه ذخیره‌شده هیچ نظری یا نویسنده نظری ندارد. برای مشاهده حذف، از ارائه‌ای که حاوی نظرات است استفاده کنید.

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

مثال دو نظر بر روی یک اسلاید ایجاد می‌کند و از [getSlideComments](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#getSlideComments-com.aspose.slides.ICommentAuthor-) برای یافتن نظرات هر نویسنده استفاده می‌کند. نظراتی که متن آن‌ها برابر با "comment 1" باشد جمع‌آوری می‌شوند قبل از فراخوانی [ICommentCollection.remove](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommentcollection/#remove-com.aspose.slides.IComment-)، تا از تغییر مجموعه هنگام انتخاب جلوگیری شود. ارائه ذخیره‌شده فقط "comment 2" را نگه می‌دارد.

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

## **سوالات متداول**

**آیا Aspose.Slides از وضعیت حل‌شده برای نظرات مدرن پشتیبانی می‌کند؟**

بله. [IModernComment.getStatus](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#getStatus--) و [IModernComment.setStatus](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imoderncomment/#setStatus-byte-) مقداری از [ModernCommentStatus](https://reference.aspose.com/slides/androidjava/com.aspose.slides/moderncommentstatus/) را دسترسی می‌دهند، از جمله `Resolved`. وضعیت در ارائه ذخیره می‌شود و پس از بازگشایی فایل می‌تواند دوباره خوانده شود.

**آیا بحث‌های رشته‌ای (زنجیره‌های پاسخ) پشتیبانی می‌شوند و آیا محدودیتی برای عمق تو در تو وجود دارد؟**

بله. هر نظر می‌تواند به [parent comment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icomment/#getParentComment--) خود ارجاع دهد و زنجیره‌های پاسخ را فعال کند. API محدودیت خاصی برای عمق تو در تو تعریف نمی‌کند.

**موقعیت نشانگر نظر روی اسلاید در چه سیستم مختصاتی تعریف می‌شود؟**

موقعیت نشانگر با مختصات شناور (floating‑point) در سیستم مختصات اسلاید تعریف می‌شود که به شما امکان می‌دهد آن را دقیقاً بر روی اسلاید قرار دهید.