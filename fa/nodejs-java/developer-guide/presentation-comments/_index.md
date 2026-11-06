---
title: "مدیریت نظرات ارائه در Node.js"
linktitle: "نظرات ارائه"
type: docs
weight: 100
url: /fa/nodejs-java/presentation-comments/
keywords:
- "نظر"
- "نظر مدرن"
- "نظرات PowerPoint"
- "نظرات ارائه"
- "نظرات اسلاید"
- "افزودن نظر"
- "دسترسی به نظر"
- "ویرایش نظر"
- "پاسخ به نظر"
- "حذف نظر"
- "حذف نظر"
- "PowerPoint"
- "ارائه"
- "Node.js"
- "JavaScript"
- "Aspose.Slides"
description: "مدیریت نظرات ارائه با Aspose.Slides برای Node.js از طریق Java: افزودن، خواندن، ویرایش، پاسخ‌به‌نظرات و حذف نظرات در ارائه‌های PowerPoint."
---
## **مرور کلی**

این مقاله توضیح می‌دهد چگونه نظرات ارائه را با Aspose.Slides برای Node.js از طریق Java مدیریت کنید. این مقاله انواع اصلی مرتبط با نظرات را معرفی می‌کند و نحوه افزودن نظرات به اسلایدها، دسترسی به نظرات موجود، کار با پاسخ‌ها و نظرات مدرن، و حذف نظرات از یک ارائه را نشان می‌دهد.

مثال‌ها شامل سناریوهای رایج بازبینی و همکاری در PowerPoint می‌شوند، از جمله اختصاص نظرات به نویسندگان، خواندن متن نظرات و متادیتا، ساخت زنجیره‌های پاسخ، و حذف نظرات انتخاب شده یا تمام نظرات.

در PowerPoint، نظرات به‌عنوان حاشیه‌نویسی بر روی اسلایدها ظاهر می‌شوند. انتخاب یک نظر متن و بحث مرتبط با آن را نمایش می‌دهد.

برای درخواست نمایش یا مخفی‌سازی نظرات هنگام باز کردن یک ارائه بدون تغییر خود نظرات، ببینید [نمایش یا مخفی‌سازی نظرات هنگام باز کردن یک ارائه](/slides/fa/nodejs-java/presentation-view-properties/).

## **چرا نظرات به ارائه‌ها اضافه می‌شوند؟**

می‌توانید از نظرات برای ارائه بازخورد و همکاری با همکاران هنگام بازبینی ارائه‌ها استفاده کنید.

Aspose.Slides برای Node.js از طریق Java APIهای زیر را برای کار با نظرات فراهم می‌کند:

* کلاس [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) که دسترسی به نویسندگان نظرات ارائه را فراهم می‌کند.
* کلاس [CommentCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentcollection/) که نظرات مرتبط با یک نویسنده خاص را نشان می‌دهد.
* کلاس [Comment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/comment/) که اطلاعاتی درباره یک نظر شامل نویسنده، زمان ایجاد، موقعیت و متن ارائه می‌دهد.
* کلاس [CommentAuthor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentauthor/) که اطلاعاتی درباره یک نویسنده شامل نام، حروف اولیه و نظرات مرتبط را فراهم می‌کند.

## **افزودن نظرات به اسلاید**

این مثال دو اسلاید ایجاد می‌کند و یک نویسنده نظر را با [addAuthor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentauthorcollection/addauthor/) ثبت می‌کند. از [addComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentcollection/addcomment/) برای قرار دادن یک نظر بر روی هر اسلاید استفاده می‌کند، سپس نظرات اسلاید اول برای آن نویسنده را با [getSlideComments](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/getslidecomments/) بازیابی می‌کند. کنسول متن اولین نظر را دو بار نمایش می‌دهد، که دسترسی از طریق هر دو اسلاید و نویسنده را نشان می‌دهد، و ارائه ذخیره‌شده شامل هر دو نظر است.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const firstSlide = presentation.getSlides().get_Item(0);
    const secondSlide = presentation.getSlides().addEmptySlide(presentation.getLayoutSlides().get_Item(0));

    const author = presentation.getCommentAuthors().addAuthor("Jawad", "MF");
    const position = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(0.2), java.newFloat(0.2));
    const createdTime = java.newInstanceSync("java.util.Date");

    author.getComments().addComment("Hello Jawad, this is a slide comment", firstSlide, position, createdTime);
    author.getComments().addComment("Hello Jawad, this is the second slide comment", secondSlide, position, createdTime);

    const comments = firstSlide.getSlideComments(author);
    if (comments.length > 0) {
        const firstComment = comments[0];
        console.log(firstComment.getText());

        const commentText = firstComment.getAuthor().getComments().get_Item(0).getText();
        console.log(commentText);
    }

    presentation.save("Comments_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **یافتن یا ایجاد نویسندهٔ نظر**

زمانی که یک بازبینی خودکار یک ارائه را بارها پردازش می‌کند، پیش از افزودن نویسنده، مجموعه‌ای که توسط [getCommentAuthors](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/getcommentauthors/) بازگردانده می‌شود جستجو کنید. [findByNameAndInitials](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentauthorcollection/findbynameandinitials/) هم نام و هم حروف اولیه را مطابقت می‌دهد و آرایه‌ای از نویسندگان منطبق بر می‌گرداند، یا آرایهٔ خالی اگر مطابقتی وجود نداشته باشد. برعکس، [findByName](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentauthorcollection/findbyname/) تنها بر اساس نام جستجو می‌کند، بدون در نظر گرفتن حروف اولیه. فراخوانی [addAuthor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentauthorcollection/addauthor/) با نام و حروف اولیه‌ای که در مجموعه موجود‌اند، استثنایی را می‌اندازد.

این مثال به یک فایل ارائه با حداقل یک اسلاید نیاز دارد. در هر یک از دو عبور، اولین نویسندهٔ هم‌خوان را دوباره استفاده می‌کند، یا فقط زمانی که نتیجه خالی باشد، یکی ایجاد می‌کند. اگر چندین هم‌خوانی وجود داشته باشد، اولین عنصر آرایه را بدون ادغام یا حذف سایر نویسندگان انتخاب می‌کند. سپس برای نویسندهٔ انتخاب‌شده [addComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentcollection/addcomment/) را فراخوانی می‌کند و ارائه را ذخیره می‌کند. عبور دوم خروجی عبور اول را باز می‌کند و عمل را تکرار می‌کند.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const authorName = "Reviewer";
const authorInitials = "RV";

let inputFile = "input.pptx";
const position = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(20), java.newFloat(20));

for (let pass = 1; pass <= 2; pass++) {
    const presentation = new aspose.slides.Presentation(inputFile);
    try {
        const matches = presentation.getCommentAuthors().findByNameAndInitials(authorName, authorInitials);

        const author = matches.length > 0 ? matches[0] : presentation.getCommentAuthors().addAuthor(authorName, authorInitials);
        const createdTime = java.newInstanceSync("java.util.Date");
        author.getComments().addComment("Please review this slide.", presentation.getSlides().get_Item(0), position, createdTime);

        const outputFile = "review_pass_" + pass + ".pptx";
        presentation.save(outputFile, aspose.slides.SaveFormat.Pptx);
        inputFile = outputFile;
    } finally {
        presentation.dispose();
    }
}
```

عبور دوم یک نظر دیگر اضافه می‌کند بدون افزودن نویسندهٔ دیگری یا حذف نظرات موجود. فایل نهایی، `review_pass_2.pptx`، هر دو نظر جدید را همراه با هر نظر اصلی دارد. استفاده مجدد از یک نویسنده نظرات را یکتا نمی‌کند: برای جلوگیری از افزودن مکرر همان نظر، قبل از افزودن، تشخیص تکرار جداگانه‌ای پیاده کنید.

## **دسترسی به نظرات اسلاید**

این مثال یک ارائهٔ موجود را باز می‌کند و مجموعه‌ای را که توسط [getCommentAuthors](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/getcommentauthors/) بازگردانده می‌شود می‌خواند. برای هر نویسنده، از مجموعه‌ای که توسط [getComments](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentauthor/getcomments/) برگردانده می‌شود پیمایش می‌کند و شمارهٔ اسلاید، متن نظر، نام نویسنده و زمان ایجاد را چاپ می‌کند. ارائهٔ ورودی باید حاوی نظرات باشد تا خروجی کنسول تولید شود.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("Comments1.pptx");
try {
    const authors = presentation.getCommentAuthors();
    for (let authorIndex = 0; authorIndex < authors.size(); authorIndex++) {
        const author = authors.get_Item(authorIndex);
        const comments = author.getComments();

        for (let commentIndex = 0; commentIndex < comments.size(); commentIndex++) {
            const comment = comments.get_Item(commentIndex);
            console.log("Slide: " + comment.getSlide().getSlideNumber());
            console.log("Comment: " + comment.getText());
            console.log("Author: " + comment.getAuthor().getName());
            console.log("Posted at: " + comment.getCreatedTime());
            console.log();
        }
    }
} finally {
    presentation.dispose();
}
```

## **پاسخ به نظرات**

یک نظر والد، نظر اصلی در بالای یک سلسله‌مراتب پاسخ است. متدهای [Comment.getParentComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/comment/getparentcomment/) و [Comment.setParentComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/comment/setparentcomment/) به شما امکان می‌دهند والد یک نظر را به‌دست آورید یا تنظیم کنید.

این مثال نظراتی از دو نویسنده ایجاد می‌کند و از [setParentComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/comment/setparentcomment/) برای ساخت پاسخ‌ها، از جمله یک پاسخ به پاسخ دیگر، استفاده می‌کند. ارسال `null` به [getSlideComments](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/getslidecomments/) نظرات را از تمام نویسندگان بازیابی می‌کند؛ کنسول هر ورودی را بر اساس عمق آن در سلسله‌مراتب پاسخ‌ها تو رفتگی می‌کند. مثال بحث کامل را ذخیره می‌کند، روی اولین نظر ریشه‌ای [remove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/comment/remove/) فراخوانی می‌کند و یک ارائهٔ دوم را با آن نظر و پاسخ‌هایش حذف‌شده ذخیره می‌کند.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const position = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(10), java.newFloat(10));
    const createdTime = java.newInstanceSync("java.util.Date");

    const originalAuthor = presentation.getCommentAuthors().addAuthor("Author_1", "A.A.");
    const rootComment = originalAuthor.getComments().addComment("comment 1", slide, position, createdTime);

    const reviewer = presentation.getCommentAuthors().addAuthor("Author_2", "B.B.");
    const firstReply = reviewer.getComments().addComment("reply 1 for comment 1", slide, position, createdTime);
    firstReply.setParentComment(rootComment);

    const secondReply = reviewer.getComments().addComment("reply 2 for comment 1", slide, position, createdTime);
    secondReply.setParentComment(rootComment);

    const subReply = originalAuthor.getComments().addComment("subreply 3 for reply 2", slide, position, createdTime);
    subReply.setParentComment(secondReply);

    reviewer.getComments().addComment("comment 2", slide, position, createdTime);
    const separateComment = reviewer.getComments().addComment("comment 3", slide, position, createdTime);

    const separateReply = originalAuthor.getComments().addComment("reply 4 for comment 3", slide, position, createdTime);
    separateReply.setParentComment(separateComment);

    const comments = slide.getSlideComments(null);
    for (let index = 0; index < comments.length; index++) {
        let comment = comments[index];
        let indentation = "";
        while (comment.getParentComment() != null) {
            indentation += "\t";
            comment = comment.getParentComment();
        }

        console.log(indentation + comments[index].getAuthor().getName() + ": " + comments[index].getText());
    }

    presentation.save("parent_comment.pptx", aspose.slides.SaveFormat.Pptx);

    rootComment.remove();
    presentation.save("remove_comment.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert color="warning" title="Warning" %}}
* هنگامی که متد [Comment.remove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/comment/remove/) برای حذف یک نظر استفاده شود، تمام پاسخ‌های آن نظر نیز حذف می‌شوند.
* اگر [Comment.setParentComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/comment/setparentcomment/) یک ارجاع دوری ایجاد کند، یک [PptxEditException](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pptxeditexception/) پرتاب می‌شود.
{{% /alert %}}

## **افزودن نظرات مدرن**

نظرات مدرن می‌توانند به خود اسلاید، به یک شکل خاص یا به یک بازهٔ متنی داخل یک AutoShape مرتبط شوند. متد [CommentCollection.addModernComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentcollection/addmoderncomment/) علاوه بر اسلاید و مختصات نشانگر نظر، یک آرگومان [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) می‌پذیرد.

هنگامی که `null` برای آرگومان shape ارسال شود، نظر یک نظر سطح‑اسلاید است. نشانگر آن با مختصات داده‌شده موقعیت‌گیری می‌شود، اما به شکل خاصی مرتبط نیست، بنابراین [ModernComment.getShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/getshape/) `null` برمی‌گرداند. وقتی یک [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) فراهم شود، نظر به آن شکل پیوند می‌خورد. مختصات همچنان موقعیت نشانگر نظر را روی اسلاید تعریف می‌کند، در حالی که ارتباط شکل می‌تواند از طریق [ModernComment.getShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/getshape/) بازیابی شود.

### **اتصال یک نظر مدرن به یک شکل**

این مثال دو بار [addModernComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentcollection/addmoderncomment/) را فراخوانی می‌کند: یک بار با shape برابر `null` برای یک نظر سطح‑اسلاید و یک بار با یک مستطیل به‌عنوان پیوند. خواندن [getShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/getshape/) برای نظر سطح‑اسلاید مقدار `true` را برای بررسی `null` چاپ می‌کند و برای نظر پیوندخورده مقدار `Revenue title` را چاپ می‌کند. هر دو نظر با ارائه ذخیره می‌شوند.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const author = presentation.getCommentAuthors().addAuthor("Reviewer", "RV");

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 300, 80);
    shape.setName("Revenue title");
    shape.getTextFrame().setText("Quarterly revenue");

    const createdTime = java.newInstanceSync("java.util.Date");
    const slideCommentPosition = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(20), java.newFloat(20));
    const shapeCommentPosition = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(60), java.newFloat(60));
    const slideComment = author.getComments().addModernComment("Review the overall slide layout.", slide, null, slideCommentPosition, createdTime);
    const shapeComment = author.getComments().addModernComment("Check this title.", slide, shape, shapeCommentPosition, createdTime);

    console.log(slideComment.getShape() == null);
    console.log(shapeComment.getShape().getName());

    presentation.save("modern_comments.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **اتصال نظرات به انواع مختلف شکل**

هر شیء اسلایدی که از [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) مشتق شود می‌تواند به‌عنوان پیوند شکل استفاده شود. مثال‌های رایج شامل [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/)، [PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/)، [GroupShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshape/)، [Connector](https://reference.aspose.com/slides/nodejs-java/aspose.slides/connector/)، و نمونه‌های [GraphicalObject](https://reference.aspose.com/slides/nodejs-java/aspose.slides/graphicalobject/) مانند نمودارها هستند.

این مثال از [addModernComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentcollection/addmoderncomment/) برای ارتباط یک نظر با هر یک از پنج نوع شکل استفاده می‌کند: یک AutoShape، یک picture frame، یک گروه، یک connector و یک نمودار. تصویر از داده‌های تصویر درونی استفاده می‌کند، بنابراین نیازی به تصویر خارجی نیست. هر نظر موقعیت نشانگر خود را دارد و ارائهٔ ذخیره‌شده تمام پنج ارتباط شکل را نگه می‌دارد.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const author = presentation.getCommentAuthors().addAuthor("Reviewer", "RV");
    const createdTime = java.newInstanceSync("java.util.Date");

    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 180, 60);
    autoShape.getTextFrame().setText("AutoShape");

    const autoShapeCommentPosition = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(30), java.newFloat(30));
    author.getComments().addModernComment("Comment on an AutoShape.", slide, autoShape, autoShapeCommentPosition, createdTime);

    const imageBase64 = "iVBORw0KGgoAAAANSUhEUgAAAAIAAAACCAIAAAD91JpzAAAAFklEQVR4nGP8//8/AwMDEwMDAwMDAwAkBgMB/DXemwAAAABJRU5ErkJggg==";
    const imageData = java.newArray("byte", Array.from(Buffer.from(imageBase64, "base64")));
    const image = presentation.getImages().addImage(imageData);
    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 220, 20, 120, 80, image);
    const pictureCommentPosition = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(230), java.newFloat(30));
    author.getComments().addModernComment("Comment on a picture.", slide, pictureFrame, pictureCommentPosition, createdTime);

    const groupShape = slide.getShapes().addGroupShape();
    groupShape.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 0, 0, 80, 40);
    groupShape.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 100, 0, 80, 40);
    const groupCommentPosition = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(40), java.newFloat(150));
    author.getComments().addModernComment("Comment on a group.", slide, groupShape, groupCommentPosition, createdTime);

    const connector = slide.getShapes().addConnector(aspose.slides.ShapeType.StraightConnector1, 220, 150, 140, 40);
    const connectorCommentPosition = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(240), java.newFloat(150));
    author.getComments().addModernComment("Comment on a connector.", slide, connector, connectorCommentPosition, createdTime);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 400, 20, 250, 180);
    const chartCommentPosition = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(420), java.newFloat(40));
    author.getComments().addModernComment("Comment on a graphical object.", slide, chart, chartCommentPosition, createdTime);

    presentation.save("modern_comment_shape_types.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **اتصال یک نظر به متن و تنظیم وضعیت آن**

برای یک نظر مدرن مرتبط با یک [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/)، متدهای [ModernComment.getTextSelectionStart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/gettextselectionstart/) و [ModernComment.setTextSelectionStart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/settextselectionstart/) موقعیت شروع متن انتخاب‌شده در فریم متنی شکل را برمی‌گردانند و تنظیم می‌کنند. متدهای [ModernComment.getTextSelectionLength](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/gettextselectionlength/) و [ModernComment.setTextSelectionLength](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/settextselectionlength/) طول انتخاب را دسترسی می‌دهند. این مقادیر با هم نظر را به بازهٔ متنی خاصی داخل AutoShape پیوند می‌دهند.

متدهای [ModernComment.getStatus](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/getstatus/) و [ModernComment.setStatus](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/setstatus/) مقدار از شمارندهٔ [ModernCommentStatus](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncommentstatus/) را دسترسی می‌دهند:

- `NotDefined` — وضعیت خاصی برای نظر مدرن تعریف نشده است.
- `Active` — نظر فعال است.
- `Resolved` — نظر حل شده است.
- `Closed` — نظر بسته شده است.

این مثال یک نظر مدرن را به کلمات «quarterly revenue» در متن یک مستطیل پیوند می‌دهد. شروع انتخاب صفر‑محور را از متن محاسبه می‌کند و به [setTextSelectionStart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/settextselectionstart/) می‌فرستد و با استفاده از [setTextSelectionLength](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/settextselectionlength/) تعداد کاراکترهای انتخاب‌شده را تنظیم می‌کند. پس از فراخوانی [setStatus](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/setstatus/) با مقدار `Resolved`، ارائه ذخیره و دوباره باز می‌شود. چهار بررسی کنسول باید هر کدام `true` چاپ کنند، که تأیید می‌کند پیوند شکل، بازهٔ متن و وضعیت حفظ شده‌اند.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const outputFile = "modern_comment_text_anchor.pptx";
const shapeText = "Review the quarterly revenue forecast.";
const selectedText = "quarterly revenue";
const expectedSelectionStart = shapeText.indexOf(selectedText);

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 400, 100);
    shape.setName("Forecast text");
    shape.getTextFrame().setText(shapeText);

    const author = presentation.getCommentAuthors().addAuthor("Reviewer", "RV");
    const commentPosition = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(60), java.newFloat(60));
    const createdTime = java.newInstanceSync("java.util.Date");
    const comment = author.getComments().addModernComment("Verify this forecast wording.", slide, shape, commentPosition, createdTime);
    comment.setTextSelectionStart(expectedSelectionStart);
    comment.setTextSelectionLength(selectedText.length);
    comment.setStatus(java.newByte(aspose.slides.ModernCommentStatus.Resolved));

    presentation.save(outputFile, aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

const reopenedPresentation = new aspose.slides.Presentation(outputFile);
try {
    const reopenedSlide = reopenedPresentation.getSlides().get_Item(0);
    const reopenedComments = reopenedSlide.getSlideComments(null);

    for (let index = 0; index < reopenedComments.length; index++) {
        const reopenedComment = reopenedComments[index];
        if (!java.instanceOf(reopenedComment, "com.aspose.slides.IModernComment")) {
            continue;
        }

        const shapeMatches = reopenedComment.getShape() != null && reopenedComment.getShape().getName() === "Forecast text";
        const selectionStartMatches = reopenedComment.getTextSelectionStart() === expectedSelectionStart;
        const selectionLengthMatches = reopenedComment.getTextSelectionLength() === selectedText.length;
        const statusMatches = reopenedComment.getStatus() === aspose.slides.ModernCommentStatus.Resolved;

        console.log("Shape anchor preserved: " + shapeMatches);
        console.log("Text selection start preserved: " + selectionStartMatches);
        console.log("Text selection length preserved: " + selectionLengthMatches);
        console.log("Resolved status preserved: " + statusMatches);
    }
} finally {
    reopenedPresentation.dispose();
}
```

### **بازرسی نظرات مدرن موجود**

این مثال به یک ارائهٔ موجود حاوی نظرات مدرن نیاز دارد و متن، وضعیت و جزئیات پیوند آن‌ها را چاپ می‌کند. برای بازرسی، ابتدا بررسی کنید که کدام نظرات نمونهٔ [ModernComment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/) هستند، سپس به [ModernComment.getShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/getshape/)، [ModernComment.getTextSelectionStart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/gettextselectionstart/)، [ModernComment.getTextSelectionLength](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/gettextselectionlength/) و [ModernComment.getStatus](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/getstatus/) مراجعه کنید. یک shape برابر `null` نشانگر نظر سطح‑اسلاید است. برای پیوند یک [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/)، متدهای انتخاب متن بازهٔ مربوطه در فریم متنی شکل را شناسایی می‌کنند.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("comments.pptx");
try {
    const slides = presentation.getSlides();
    for (let slideIndex = 0; slideIndex < slides.size(); slideIndex++) {
        const slide = slides.get_Item(slideIndex);
        const comments = slide.getSlideComments(null);

        for (let commentIndex = 0; commentIndex < comments.length; commentIndex++) {
            const comment = comments[commentIndex];
            if (!java.instanceOf(comment, "com.aspose.slides.IModernComment")) {
                continue;
            }

            console.log("Slide: " + slide.getSlideNumber());
            console.log("Text: " + comment.getText());
            console.log("Status: " + comment.getStatus());

            const shape = comment.getShape();
            if (shape == null) {
                console.log("Anchor: slide level");
            } else {
                console.log("Anchor shape: " + shape.getName());
                console.log("Anchor type: " + shape.getClass().getSimpleName());

                if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                    console.log("Text selection start: " + comment.getTextSelectionStart());
                    console.log("Text selection length: " + comment.getTextSelectionLength());
                }
            }

            console.log();
        }
    }
} finally {
    presentation.dispose();
}
```

## **حذف نظرات**

Aspose.Slides برای Node.js از طریق Java امکان حذف تمام نظرات و نویسندگان آن‌ها از یک ارائه یا حذف نظرات منتخب در حالی که بقیه حفظ می‌شوند را فراهم می‌کند. مثال‌های زیر هر دو روش را نشان می‌دهند و ارائه به‌روزشده را ذخیره می‌کنند.

### **حذف تمام نظرات و نویسندگان نظرات**

این مثال یک ارائهٔ موجود را باز می‌کند و برای هر نویسنده [CommentCollection.clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentcollection/clear/) را فراخوانی می‌کند، سپس برای حذف خود نویسندگان [CommentAuthorCollection.clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentauthorcollection/clear/) را فرا می‌خواند. ارائهٔ ذخیره‌شده نه نظرات دارد و نه نویسندگان نظرات. برای مشاهده حذف، از یک ارائه حاوی نظرات استفاده کنید.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("example.pptx");
try {
    const authors = presentation.getCommentAuthors();
    for (let index = 0; index < authors.size(); index++) {
        authors.get_Item(index).getComments().clear();
    }

    authors.clear();

    presentation.save("example_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **حذف نظرات خاص**

این مثال دو نظر در یک اسلاید ایجاد می‌کند و از [getSlideComments](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/getslidecomments/) برای یافتن نظرات هر نویسنده استفاده می‌کند. قبل از فراخوانی [CommentCollection.remove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commentcollection/remove/)، نظراتی که متن آن‌ها برابر «comment 1» است جمع‌آوری می‌کند تا از تغییر مجموعه هنگام انتخاب جلوگیری کند. ارائهٔ ذخیره‌شده فقط «comment 2» را حفظ می‌کند.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const author = presentation.getCommentAuthors().addAuthor("Author", "A");
    const createdTime = java.newInstanceSync("java.util.Date");

    const firstCommentPosition = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(0.2), java.newFloat(0.2));
    const secondCommentPosition = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(0.3), java.newFloat(0.2));
    author.getComments().addComment("comment 1", slide, firstCommentPosition, createdTime);
    author.getComments().addComment("comment 2", slide, secondCommentPosition, createdTime);

    const authors = presentation.getCommentAuthors();
    for (let authorIndex = 0; authorIndex < authors.size(); authorIndex++) {
        const commentAuthor = authors.get_Item(authorIndex);
        const commentsToRemove = [];
        const comments = slide.getSlideComments(commentAuthor);

        for (let commentIndex = 0; commentIndex < comments.length; commentIndex++) {
            const comment = comments[commentIndex];
            if (comment.getText() === "comment 1") {
                commentsToRemove.push(comment);
            }
        }

        for (const comment of commentsToRemove) {
            commentAuthor.getComments().remove(comment);
        }
    }

    presentation.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **پرسش‌های متداول**

**آیا Aspose.Slides وضعیت حل‌شده برای نظرات مدرن را پشتیبانی می‌کند؟**

بله. متدهای [ModernComment.getStatus](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/getstatus/) و [ModernComment.setStatus](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncomment/setstatus/) مقدار از شمارندهٔ [ModernCommentStatus](https://reference.aspose.com/slides/nodejs-java/aspose.slides/moderncommentstatus/) را دسترسی می‌دهند، از جمله `Resolved`. این وضعیت در ارائه ذخیره می‌شود و پس از بازگشایی فایل می‌توان آن را دوباره خواند.

**آیا بحث‌های زنجیره‌ای (زنجیره‌های پاسخ) پشتیبانی می‌شوند و آیا محدودیتی برای عمق تو در تو وجود دارد؟**

بله. هر نظر می‌تواند به [parent comment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/comment/getparentcomment/) خود ارجاع دهد، که امکان ایجاد زنجیره‌های پاسخ را فراهم می‌کند. API محدودیت خاصی برای عمق تو در تو تعریف نکرده است.

**در چه سیستم مختصاتی موقعیت نشانگر نظر در یک اسلاید تعریف می‌شود؟**

موقعیت نشانگر توسط مختصات نقطه‑شناور در سیستم مختصات اسلاید تعریف می‌شود، که امکان قرارگیری دقیق آن بر روی اسلاید را می‌دهد.