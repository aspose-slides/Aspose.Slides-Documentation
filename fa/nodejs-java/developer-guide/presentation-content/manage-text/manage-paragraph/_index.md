---
title: مدیریت پاراگراف‌های متن PowerPoint در JavaScript
linktitle: مدیریت پاراگراف
type: docs
weight: 40
url: /fa/nodejs-java/manage-paragraph/
keywords:
- افزودن متن
- افزودن پاراگراف
- مدیریت متن
- مدیریت پاراگراف
- مدیریت نقطه‌گذاری
- تورفتگی پاراگراف
- تورفتگی معلق
- نقطه‌گذاری پاراگراف
- فهرست شماره‌دار
- فهرست نقطه‌دار
- ویژگی‌های پاراگراف
- وارد کردن HTML
- متن به HTML
- پاراگراف به HTML
- پاراگراف به تصویر
- متن به تصویر
- صادرات پاراگراف
- PowerPoint
- OpenDocument
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "قالب‌بندی پیشرفته پاراگراف‌ها را با Aspose.Slides برای Node.js از طریق Java - تنظیم تراز، فواصل و سبک در ارائه‌های PPT، PPTX و ODP را در JavaScript بهینه کنید."
---
## **مقدمه**

Aspose.Slides تمام کلاس‌ها و مجموعه‌های مورد نیاز شما برای کار با متن‌ها، پاراگراف‌ها و بخش‌های PowerPoint در Java را فراهم می‌کند.

* Aspose.Slides کلاس [TextFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textframe/) را فراهم می‌کند تا بتوانید اشیائی که یک پاراگراف را نمایندگی می‌کنند اضافه کنید. یک شیء `TextFame` می‌تواند یک یا چند پاراگراف داشته باشد (هر پاراگراف از طریق یک برگشت‌خط ایجاد می‌شود).
* Aspose.Slides کلاس [Paragraph](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/paragraph/) را فراهم می‌کند تا بتوانید اشیائی که بخش‌ها را نمایندگی می‌کنند اضافه کنید. یک شیء `Paragraph` می‌تواند یک یا چند بخش داشته باشد (مجموعه‌ای از اشیای بخش متن).
* Aspose.Slides کلاس [Portion](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/portion/) را فراهم می‌کند تا بتوانید اشیائی که متن‌ها و ویژگی‌های قالب‌بندی آن‌ها را نمایندگی می‌کنند اضافه کنید.

یک شیء `Paragraph` قادر است متونی با ویژگی‌های قالب‌بندی مختلف را از طریق اشیای زیرمجموعه `Portion` خود مدیریت کند.

## **افزودن چندین پاراگراف حاوی چندین بخش**

این مراحل نشان می‌دهد چگونه یک فریم متن حاوی ۳ پاراگراف و هر پاراگراف حاوی ۳ بخش اضافه کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) ایجاد کنید.
2. از طریق شاخص، به مرجع اسلاید مربوطه دسترسی پیدا کنید.
3. یک [AutoShape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/autoshape/) مستطیلی به اسلاید اضافه کنید.
4. ITextFrame مرتبط با [AutoShape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/autoshape/) را دریافت کنید.
5. دو شیء [Paragraph](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/paragraph/) ایجاد کنید و آن‌ها را به مجموعه `IParagraphs` از [TextFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textframe/) اضافه کنید.
6. برای هر `Paragraph` جدید، سه شیء [Portion](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/portion/) ایجاد کنید (برای پاراگراف پیش‌فرض دو شیء Portion) و هر شیء `Portion` را به مجموعه IPortion هر `Paragraph` اضافه کنید.
7. متنی برای هر بخش تنظیم کنید.
8. ویژگی‌های قالب‌بندی دلخواه خود را با استفاده از ویژگی‌های قالب‌بندی موجود در شیء `Portion` برای هر بخش اعمال کنید.
9. ارائه اصلاح‌شده را ذخیره کنید.

این کد Javascript پیاده‌سازی مراحل افزودن پاراگراف‌های حاوی بخش‌هاست:

```javascript
// یک شیء از کلاس Presentation ایجاد می‌کند که نمایانگر یک فایل PPTX است
var pres = new aspose.slides.Presentation();
try {
    // دسترسی به اولین اسلاید
    var slide = pres.getSlides().get_Item(0);
    // افزودن یک AutoShape از نوع Rectangle
    var ashp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 150, 300, 150);
    // دسترسی به TextFrame خودکارشکل
    var tf = ashp.getTextFrame();
    // ایجاد پاراگراف‌ها و بخش‌ها با قالب‌بندی‌های متنی متفاوت
    var para0 = tf.getParagraphs().get_Item(0);
    var port01 = new aspose.slides.Portion();
    var port02 = new aspose.slides.Portion();
    para0.getPortions().add(port01);
    para0.getPortions().add(port02);
    var para1 = new aspose.slides.Paragraph();
    tf.getParagraphs().add(para1);
    var port10 = new aspose.slides.Portion();
    var port11 = new aspose.slides.Portion();
    var port12 = new aspose.slides.Portion();
    para1.getPortions().add(port10);
    para1.getPortions().add(port11);
    para1.getPortions().add(port12);
    var para2 = new aspose.slides.Paragraph();
    tf.getParagraphs().add(para2);
    var port20 = new aspose.slides.Portion();
    var port21 = new aspose.slides.Portion();
    var port22 = new aspose.slides.Portion();
    para2.getPortions().add(port20);
    para2.getPortions().add(port21);
    para2.getPortions().add(port22);
    for (var i = 0; i < 3; i++) {
        for (var j = 0; j < 3; j++) {
            var portion = tf.getParagraphs().get_Item(i).getPortions().get_Item(j);
            portion.setText("Portion0" + j);
            if (j == 0) {
                portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
                portion.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
                portion.getPortionFormat().setFontHeight(15);
            } else if (j == 1) {
                portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
                portion.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
                portion.getPortionFormat().setFontHeight(18);
            }
        }
    }
    // نوشتن PPTX بر روی دیسک
    pres.save("multiParaPort_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **مدیریت لیست‌های نقطه‌ای پاراگراف**

لیست‌های نقطه‌ای به شما کمک می‌کند تا اطلاعات را به سرعت و به‌طور مؤثر سازماندهی و ارائه دهید. پاراگراف‌های نقطه‌دار همیشه خواندن و درک آن‌ها آسان‌تر است.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) ایجاد کنید.
2. از طریق شاخص، به مرجع اسلاید مربوطه دسترسی پیدا کنید.
3. یک [AutoShape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/autoshape/) به اسلاید انتخابی اضافه کنید.
4. [TextFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textframe/) خودکارشکل را دسترسی پیدا کنید.
5. پاراگراف پیش‌فرض موجود در `TextFrame` را حذف کنید.
6. اولین نمونه پاراگراف را با استفاده از کلاس [Paragraph](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/paragraph/) ایجاد کنید.
7. نوع نقطه‌گذاری `Type` پاراگراف را به `Symbol` تنظیم کنید و کاراکتر نقطه را تعیین کنید.
8. متن پاراگراف را تنظیم کنید.
9. تورفتگی `Indent` پاراگراف برای نقطه را تنظیم کنید.
10. رنگی برای نقطه تعیین کنید.
11. ارتفاع نقطه را تنظیم کنید.
12. پاراگراف جدید را به مجموعه پاراگراف‌های `TextFrame` اضافه کنید.
13. پاراگراف دوم را اضافه کنید و مراحل ۷ تا ۱۳ را تکرار کنید.
14. ارائه را ذخیره کنید.

این کد Javascript نشان می‌دهد چگونه یک نقطه لیست پاراگراف اضافه کنید:

```javascript
// یک شی از کلاس Presentation ایجاد می‌کند که نمایانگر یک فایل PPTX است
var pres = new aspose.slides.Presentation();
try {
    // به اولین اسلاید دسترسی می‌یابد
    var slide = pres.getSlides().get_Item(0);
    // یک AutoShape اضافه می‌کند و به آن دسترسی می‌یابد
    var aShp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    // به فریم متن AutoShape دسترسی می‌یابد
    var txtFrm = aShp.getTextFrame();
    // پاراگراف پیش‌فرض را حذف می‌کند
    txtFrm.getParagraphs().removeAt(0);
    // یک پاراگراف ایجاد می‌کند
    var para = new aspose.slides.Paragraph();
    // سبک و نماد نقطه‌گذاری پاراگراف را تنظیم می‌کند
    para.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para.getParagraphFormat().getBullet().setChar(8226);
    // متن پاراگراف را تنظیم می‌کند
    para.setText("Welcome to Aspose.Slides");
    // تورفتگی نقطه‌گذاری را تنظیم می‌کند
    para.getParagraphFormat().setIndent(25);
    // رنگ نقطه‌گذاری را تنظیم می‌کند
    para.getParagraphFormat().getBullet().getColor().setColorType(aspose.slides.ColorType.RGB);
    para.getParagraphFormat().getBullet().getColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    para.getParagraphFormat().getBullet().setBulletHardColor(aspose.slides.NullableBool.True);// مقدار IsBulletHardColor را به true تنظیم می‌کند تا از رنگ نقطه‌گذاری سفارشی استفاده شود
    // ارتفاع نقطه‌گذاری را تنظیم می‌کند
    para.getParagraphFormat().getBullet().setHeight(100);
    // پاراگراف را به فریم متن اضافه می‌کند
    txtFrm.getParagraphs().add(para);
    // پاراگراف دوم را ایجاد می‌کند
    var para2 = new aspose.slides.Paragraph();
    // نوع و سبک نقطه‌گذاری پاراگراف را تنظیم می‌کند
    para2.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Numbered);
    para2.getParagraphFormat().getBullet().setNumberedBulletStyle(aspose.slides.NumberedBulletStyle.BulletCircleNumWDBlackPlain);
    // متن پاراگراف را اضافه می‌کند
    para2.setText("This is numbered bullet");
    // تورفتگی نقطه‌گذاری را تنظیم می‌کند
    para2.getParagraphFormat().setIndent(25);
    para2.getParagraphFormat().getBullet().getColor().setColorType(aspose.slides.ColorType.RGB);
    para2.getParagraphFormat().getBullet().getColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    para2.getParagraphFormat().getBullet().setBulletHardColor(aspose.slides.NullableBool.True);// مقدار IsBulletHardColor را به true تنظیم می‌کند تا از رنگ نقطه‌گذاری سفارشی استفاده شود
    // ارتفاع نقطه‌گذاری را تنظیم می‌کند
    para2.getParagraphFormat().getBullet().setHeight(100);
    // پاراگراف را به فریم متن اضافه می‌کند
    txtFrm.getParagraphs().add(para2);
    // ارائه اصلاح‌شده را ذخیره می‌کند
    pres.save("Bullet_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **مدیریت نقطه‌گذاری تصویر**

لیست‌های نقطه‌ای به شما کمک می‌کند تا اطلاعات را به سرعت و به‌طور مؤثر سازماندهی و ارائه دهید. پاراگراف‌های تصویری خواندن و درک آسانی دارند.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) ایجاد کنید.
2. از طریق شاخص، به مرجع اسلاید مربوطه دسترسی پیدا کنید.
3. یک [AutoShape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/autoshape/) به اسلاید اضافه کنید.
4. [TextFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textframe/) خودکارشکل را دسترسی پیدا کنید.
5. پاراگراف پیش‌فرض موجود در `TextFrame` را حذف کنید.
6. اولین نمونه پاراگراف را با استفاده از کلاس [Paragraph](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/paragraph/) ایجاد کنید.
7. تصویر را با استفاده از [PPImage](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/ppimage/) بارگذاری کنید.
8. نوع نقطه‌گذاری را به [Picture](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/ppimage/) تنظیم کنید و تصویر را تعیین کنید.
9. متن پاراگراف را تنظیم کنید.
10. تورفتگی `Indent` پاراگراف برای تصویر را تنظیم کنید.
11. رنگی برای تصویر تعیین کنید.
12. ارتفاع تصویر را تنظیم کنید.
13. پاراگراف جدید را به مجموعه پاراگراف‌های `TextFrame` اضافه کنید.
14. پاراگراف دوم را اضافه کنید و فرآیند را بر اساس مراحل قبلی تکرار کنید.
15. ارائه اصلاح‌شده را ذخیره کنید.

این کد Javascript نشان می‌دهد چگونه نقطه‌گذاری تصویر اضافه و مدیریت کنید:

```javascript
// یک شی از کلاس Presentation ایجاد می‌کند که نمایانگر یک فایل PPTX است
var presentation = new aspose.slides.Presentation();
try {
    // به اولین اسلاید دسترسی می‌یابد
    var slide = presentation.getSlides().get_Item(0);
    // تصویر برای نقطه‌گذاری را ایجاد می‌کند
    var picture;
    var image = aspose.slides.Images.fromFile("bullets.png");
    try {
        picture = presentation.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // یک AutoShape اضافه می‌کند و به آن دسترسی می‌یابد
    var autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    // به فریم متن AutoShape دسترسی می‌یابد
    var textFrame = autoShape.getTextFrame();
    // پاراگراف پیش‌فرض را حذف می‌کند
    textFrame.getParagraphs().removeAt(0);
    // یک پاراگراف جدید ایجاد می‌کند
    var paragraph = new aspose.slides.Paragraph();
    paragraph.setText("Welcome to Aspose.Slides");
    // سبک و تصویر نقطه‌گذاری پاراگراف را تنظیم می‌کند
    paragraph.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Picture);
    paragraph.getParagraphFormat().getBullet().getPicture().setImage(picture);
    // ارتفاع نقطه‌گذاری را تنظیم می‌کند
    paragraph.getParagraphFormat().getBullet().setHeight(100);
    // پاراگراف را به فریم متن اضافه می‌کند
    textFrame.getParagraphs().add(paragraph);
    // ارائه را به عنوان فایل PPTX می‌نویسد
    presentation.save("ParagraphPictureBulletsPPTX_out.pptx", aspose.slides.SaveFormat.Pptx);
    // ارائه را به عنوان فایل PPT می‌نویسد
    presentation.save("ParagraphPictureBulletsPPT_out.ppt", aspose.slides.SaveFormat.Ppt);
} catch (e) {console.log(e);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **مدیریت نقطه‌گذاری چندسطحی**

لیست‌های نقطه‌ای به شما کمک می‌کند تا اطلاعات را به سرعت و به‌طور مؤثر سازماندهی و ارائه دهید. نقطه‌گذاری چندسطحی خواندن و درک آسانی دارد.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) ایجاد کنید.
2. از طریق شاخص، به مرجع اسلاید مربوطه دسترسی پیدا کنید.
3. یک [AutoShape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/autoshape/) در اسلاید جدید اضافه کنید.
4. [TextFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textframe/) خودکارشکل را دسترسی پیدا کنید.
5. پاراگراف پیش‌فرض موجود در `TextFrame` را حذف کنید.
6. اولین نمونه پاراگراف را از طریق کلاس [Paragraph](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/paragraph/) ایجاد کنید و عمق را به ۰ تنظیم کنید.
7. دومین نمونه پاراگراف را از طریق کلاس `Paragraph` ایجاد کنید و عمق را به ۱ تنظیم کنید.
8. سومین نمونه پاراگراف را از طریق کلاس `Paragraph` ایجاد کنید و عمق را به ۲ تنظیم کنید.
9. چهارمین نمونه پاراگراف را از طریق کلاس `Paragraph` ایجاد کنید و عمق را به ۳ تنظیم کنید.
10. پاراگراف‌های جدید را به مجموعه پاراگراف‌های `TextFrame` اضافه کنید.
11. ارائه اصلاح‌شده را ذخیره کنید.

این کد Javascript نشان می‌دهد چگونه نقطه‌گذاری چندسطحی اضافه و مدیریت کنید:

```javascript
// یک شی از کلاس Presentation ایجاد می‌کند که نمایانگر یک فایل PPTX است
var pres = new aspose.slides.Presentation();
try {
    // به اولین اسلاید دسترسی می‌یابد
    var slide = pres.getSlides().get_Item(0);
    // یک AutoShape اضافه می‌کند و به آن دسترسی می‌یابد
    var aShp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    // به فریم متن AutoShape ایجاد شده دسترسی می‌یابد
    var text = aShp.addTextFrame("");
    // پاراگراف پیش‌فرض را پاک می‌کند
    text.getParagraphs().clear();
    // پاراگراف اول را اضافه می‌کند
    var para1 = new aspose.slides.Paragraph();
    para1.setText("Content");
    para1.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para1.getParagraphFormat().getBullet().setChar(8226);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // سطح نقطه‌گذاری را تنظیم می‌کند
    para1.getParagraphFormat().setDepth(0);
    // پاراگراف دوم را اضافه می‌کند
    var para2 = new aspose.slides.Paragraph();
    para2.setText("Second Level");
    para2.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para2.getParagraphFormat().getBullet().setChar('-');
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // سطح نقطه‌گذاری را تنظیم می‌کند
    para2.getParagraphFormat().setDepth(1);
    // پاراگراف سوم را اضافه می‌کند
    var para3 = new aspose.slides.Paragraph();
    para3.setText("Third Level");
    para3.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para3.getParagraphFormat().getBullet().setChar(8226);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // سطح نقطه‌گذاری را تنظیم می‌کند
    para3.getParagraphFormat().setDepth(2);
    // پاراگراف چهارم را اضافه می‌کند
    var para4 = new aspose.slides.Paragraph();
    para4.setText("Fourth Level");
    para4.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para4.getParagraphFormat().getBullet().setChar('-');
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // سطح نقطه‌گذاری را تنظیم می‌کند
    para4.getParagraphFormat().setDepth(3);
    // پاراگراف‌ها را به مجموعه اضافه می‌کند
    text.getParagraphs().add(para1);
    text.getParagraphs().add(para2);
    text.getParagraphs().add(para3);
    text.getParagraphs().add(para4);
    // ارائه را به صورت فایل PPTX می‌نویسد
    pres.save("MultilevelBullet.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **مدیریت پاراگراف با فهرست شماره‌گذاری سفارشی**

کلاس [BulletFormat](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/bulletformat/) خاصیت [NumberedBulletStartWith](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/bulletformat/#setNumberedBulletStartWith-short-) و سایر ویژگی‌ها را فراهم می‌کند که به شما امکان مدیریت پاراگراف‌ها با شماره‌گذاری یا قالب‌بندی سفارشی را می‌دهد.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) ایجاد کنید.
2. به اسلاید حاوی پاراگراف دسترسی پیدا کنید.
3. یک [AutoShape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/autoshape/) به اسلاید اضافه کنید.
4. [TextFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textframe/) خودکارشکل را دسترسی پیدا کنید.
5. پاراگراف پیش‌فرض موجود در `TextFrame` را حذف کنید.
6. اولین نمونه پاراگراف را از طریق کلاس [Paragraph](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/paragraph/) ایجاد کنید و [NumberedBulletStartWith](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/bulletformat/#setNumberedBulletStartWith-short-) را به ۲ تنظیم کنید.
7. دومین نمونه پاراگراف را از طریق کلاس `Paragraph` ایجاد کنید و `NumberedBulletStartWith` را به ۳ تنظیم کنید.
8. سومین نمونه پاراگراف را از طریق کلاس `Paragraph` ایجاد کنید و `NumberedBulletStartWith` را به ۷ تنظیم کنید.
9. پاراگراف‌های جدید را به مجموعه پاراگراف‌های `TextFrame` اضافه کنید.
10. ارائه اصلاح‌شده را ذخیره کنید.

این کد Javascript نشان می‌دهد چگونه پاراگراف‌ها را با شماره‌گذاری یا قالب‌بندی سفارشی اضافه و مدیریت کنید:

```javascript
var presentation = new aspose.slides.Presentation();
try {
    var shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    // به فریم متن AutoShape ایجاد شده دسترسی می‌یابد
    var textFrame = shape.getTextFrame();
    // پاراگراف پیش‌فرض موجود را حذف می‌کند
    textFrame.getParagraphs().removeAt(0);
    // لیست اول
    var paragraph1 = new aspose.slides.Paragraph();
    paragraph1.setText("bullet 2");
    paragraph1.getParagraphFormat().setDepth(4);
    paragraph1.getParagraphFormat().getBullet().setNumberedBulletStartWith(2);
    paragraph1.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Numbered);
    textFrame.getParagraphs().add(paragraph1);
    var paragraph2 = new aspose.slides.Paragraph();
    paragraph2.setText("bullet 3");
    paragraph2.getParagraphFormat().setDepth(4);
    paragraph2.getParagraphFormat().getBullet().setNumberedBulletStartWith(3);
    paragraph2.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Numbered);
    textFrame.getParagraphs().add(paragraph2);
    var paragraph5 = new aspose.slides.Paragraph();
    paragraph5.setText("bullet 7");
    paragraph5.getParagraphFormat().setDepth(4);
    paragraph5.getParagraphFormat().getBullet().setNumberedBulletStartWith(7);
    paragraph5.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Numbered);
    textFrame.getParagraphs().add(paragraph5);
    presentation.save("SetCustomBulletsNumber-slides.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **تنظیم تورفتگی خط اول برای پاراگراف**

از متد [ParagraphFormat.setIndent](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/paragraphformat/setindent/) برای کنترل تورفتگی خط اول یک پاراگراف استفاده کنید. این متد فقط خط اول را نسبت به حاشیه چپ پاراگراف جابه‌جا می‌کند. مقدار مثبت خط اول را به راست می‌برد، در حالی که بقیه خطوط همانند متن اصلی باقی می‌مانند.

زمانی که می‌خواهید کل پاراگراف را جابه‌جا کنید، از [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) استفاده کنید. وقتی فقط خط اول را می‌خواهید جابه‌جا کنید، از [ParagraphFormat.setIndent](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/paragraphformat/setindent/) استفاده کنید.

مثال زیر چندین پاراگراف ایجاد می‌کند و مقادیر مختلف تورفتگی را برای نشان دادن تأثیر تورفتگی خط اول بر چیدمان پاراگراف اعمال می‌کند.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) ایجاد کنید.
2. اسلاید هدف را دسترسی پیدا کنید.
3. یک [AutoShape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/autoshape/) مستطیلی به اسلاید اضافه کنید.
4. یک [TextFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textframe/) خالی به شکل اضافه کنید و پاراگراف پیش‌فرض را حذف کنید.
5. چندین پاراگراف ایجاد کنید و مقادیر مختلف [Indent](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/paragraphformat/setindent/) را برای آن‌ها تنظیم کنید.
6. پاراگراف‌ها را به فریم متن اضافه کنید.
7. ارائه اصلاح‌شده را ذخیره کنید.

این کد نشان می‌دهد چگونه تورفتگی پاراگراف تنظیم شود:

```js
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let rectangleShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 420, 220);
    rectangleShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    rectangleShape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    rectangleShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));

    let textFrame = rectangleShape.addTextFrame("");
    textFrame.getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.Shape));
    textFrame.getParagraphs().removeAt(0);

    let firstParagraph = new aspose.slides.Paragraph();
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    firstParagraph.setText("No first-line indent. Wrapped lines start at the same position as the first line.");
    firstParagraph.getParagraphFormat().setMarginLeft(20);
    firstParagraph.getParagraphFormat().setIndent(0);

    let secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    secondParagraph.setText("First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.");
    secondParagraph.getParagraphFormat().setMarginLeft(20);
    secondParagraph.getParagraphFormat().setIndent(20);

    let thirdParagraph = new aspose.slides.Paragraph();
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    thirdParagraph.setText("First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.");
    thirdParagraph.getParagraphFormat().setMarginLeft(20);
    thirdParagraph.getParagraphFormat().setIndent(40);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);
    textFrame.getParagraphs().add(thirdParagraph);

    presentation.save("paragraph_indent.pptx", aspose.slides.SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

نتیجه:

![فاصله‌برداری خط اول پاراگراف‌ها](first_line_indent.png)

## **تنظیم تورفتگی معلق برای پاراگراف**

تورفتگی معلق چیدمان پاراگرافی است که در آن خط اول نسبت به بقیه خطوط به سمت چپ شروع می‌شود. در Aspose.Slides، این اثر را با متد [ParagraphFormat.setIndent](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/paragraphformat/setindent/) ایجاد می‌کنید. مقدار منفی به `Indent` بدهید تا خط اول نسبت به بدنه پاراگراف به سمت چپ جابه‌جا شود.

در عمل، [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) موقعیت چپ بدنه پاراگراف را تعیین می‌کند و [ParagraphFormat.setIndent](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/paragraphformat/setindent/) موقعیت خط اول را نسبت به آن حاشیه تعیین می‌کند. برای ایجاد تورفتگی معلق، مقدار مثبت `MarginLeft` و مقدار منفی `Indent` را تنظیم کنید.

این قالب‌بندی برای کتابشناسی‌ها، مراجع، واژه‌نامه‌ها و سایر پاراگراف‌هایی که خطوط بسته‌بندی باید زیر بدنه پاراگراف تراز شوند مفید است.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) ایجاد کنید.
2. اسلاید هدف را دسترسی پیدا کنید.
3. یک [AutoShape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/autoshape/) مستطیلی به اسلاید اضافه کنید.
4. یک [TextFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textframe/) خالی به شکل اضافه کنید و پاراگراف پیش‌فرض را حذف کنید.
5. پاراگراف‌ها را ایجاد کنید و برای هر کدام مقدار مثبت [MarginLeft](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) تنظیم کنید.
6. مقدار منفی [Indent](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/paragraphformat/setindent/) را برای ایجاد اثر تورفتگی معلق تنظیم کنید.
7. پاراگراف‌ها را به فریم متن اضافه کنید.
8. ارائه اصلاح‌شده را ذخیره کنید.

این کد نشان می‌دهد چگونه تورفتگی معلق برای پاراگراف تنظیم شود:

```js
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let rectangleShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 420, 220);
    rectangleShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    rectangleShape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    rectangleShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));

    let textFrame = rectangleShape.addTextFrame("");
    textFrame.getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.Shape));
    textFrame.getParagraphs().removeAt(0);

    let firstParagraph = new aspose.slides.Paragraph();
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    firstParagraph.setText("A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.");
    firstParagraph.getParagraphFormat().setMarginLeft(40);
    firstParagraph.getParagraphFormat().setIndent(-20);

    let secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    secondParagraph.setText("This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.");
    secondParagraph.getParagraphFormat().setMarginLeft(60);
    secondParagraph.getParagraphFormat().setIndent(-30);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);

    presentation.save("hanging_indent.pptx", aspose.slides.SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

نتیجه:

![فاصله‌برداری معلق پاراگراف‌ها](hanging_indent.png)

## **مدیریت ویژگی‌های End برای پاراگراف**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) ایجاد کنید.
1. مرجع اسلاید حاوی پاراگراف را از طریق موقعیت آن دریافت کنید.
1. یک [AutoShape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/autoshape/) مستطیلی به اسلاید اضافه کنید.
1. یک [TextFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textframe/) با دو پاراگراف به مستطیل اضافه کنید.
1. `FontHeight` و نوع فونت را برای پاراگراف‌ها تنظیم کنید.
1. ویژگی‌های End را برای پاراگراف‌ها تنظیم کنید.
1. ارائه اصلاح‌شده را به عنوان فایل PPTX ذخیره کنید.

این کد Javascript نشان می‌دهد چگونه ویژگی‌های End برای پاراگراف‌ها در PowerPoint تنظیم شود:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 200, 250);
    var para1 = new aspose.slides.Paragraph();
    para1.getPortions().add(new aspose.slides.Portion("Sample text"));
    var para2 = new aspose.slides.Paragraph();
    para2.getPortions().add(new aspose.slides.Portion("Sample text 2"));
    var portionFormat = new aspose.slides.PortionFormat();
    portionFormat.setFontHeight(48);
    portionFormat.setLatinFont(new aspose.slides.FontData("Times New Roman"));
    para2.setEndParagraphPortionFormat(portionFormat);
    shape.getTextFrame().getParagraphs().add(para1);
    shape.getTextFrame().getParagraphs().add(para2);
    pres.save(resourcesOutputPath + "pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **وارد کردن متن HTML به پاراگراف‌ها**

Aspose.Slides پشتیبانی پیشرفته‌ای برای وارد کردن متن HTML به پاراگراف‌ها فراهم می‌کند.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) ایجاد کنید.
2. از طریق شاخص، به مرجع اسلاید مربوطه دسترسی پیدا کنید.
3. یک [AutoShape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/autoshape/) به اسلاید اضافه کنید.
4. [TextFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textframe/) خودکارشکل را اضافه و دسترسی پیدا کنید.
5. پاراگراف پیش‌فرض موجود در `TextFrame` را حذف کنید.
6. فایل HTML منبع را در یک TextReader بخوانید.
7. اولین نمونه پاراگراف را از طریق کلاس [Paragraph](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/paragraph/) ایجاد کنید.
8. محتوای فایل HTML خوانده‌شده را به [ParagraphCollection](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/paragraphcollection/) فریم متن اضافه کنید.
9. ارائه اصلاح‌شده را ذخیره کنید.

این کد Javascript پیاده‌سازی مراحل وارد کردن متون HTML در پاراگراف‌هاست:

```javascript
// یک نمونهٔ خالی از ارائه ایجاد می‌کند
var pres = new aspose.slides.Presentation();
try {
    // به اسلاید پیش‌فرض اول ارائه دسترسی می‌یابد
    var slide = pres.getSlides().get_Item(0);
    // افزودن AutoShape برای جایگذاری محتوای HTML
    var ashape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, pres.getSlideSize().getSize().getWidth() - 20, pres.getSlideSize().getSize().getHeight() - 10);
    ashape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    // افزودن فریم متن به شکل
    ashape.addTextFrame("");
    // پاک‌سازی تمام پاراگراف‌ها در فریم متنی اضافه‌شده
    ashape.getTextFrame().getParagraphs().clear();
    // بارگذاری فایل HTML با استفاده از StreamReader
    var tr = java.newInstanceSync("StreamReader", "file.html");
    // افزودن متن از StreamReader HTML به فریم متن
    ashape.getTextFrame().getParagraphs().addFromHtml(tr.readToEnd());
    // ذخیرهٔ ارائه
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **خروجی متن پاراگراف‌ها به HTML**

Aspose.Slides پشتیبانی پیشرفته‌ای برای خروجی متون (موجود در پاراگراف‌ها) به HTML فراهم می‌کند.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) ایجاد کنید و ارائه مورد نظر را بارگذاری کنید.
2. از طریق شاخص، به مرجع اسلاید مربوطه دسترسی پیدا کنید.
3. شکل حاوی متنی را که به HTML خروجی داده خواهد شد دسترسی پیدا کنید.
4. [TextFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textframe/) شکل را دسترسی پیدا کنید.
5. یک نمونه از `StreamWriter` ایجاد کنید و فایل HTML جدید را اضافه کنید.
6. یک شاخص شروع به `StreamWriter` بدهید و پاراگراف‌های مورد نظر را خروجی بگیرید.

این کد Javascript نشان می‌دهد چگونه متون پاراگراف‌های PowerPoint را به HTML خروجی بگیرید:

```javascript
// فایل ارائه را بارگذاری می‌کند
var pres = new aspose.slides.Presentation("ExportingHTMLText.pptx");
try {
    // به اسلاید پیش‌فرض اول ارائه دسترسی می‌یابد
    var slide = pres.getSlides().get_Item(0);
    // شاخص مورد نظر
    var index = 0;
    // دسترسی به شکل اضافه‌شده
    var ashape = slide.getShapes().get_Item(index);
    // ایجاد فایل خروجی HTML
    var os = java.newInstanceSync("java.io.FileOutputStream", "output.html");
    var writer = java.newInstanceSync("java.io.OutputStreamWriter", os, "UTF-8");
    // استخراج اولین پاراگراف به صورت HTML
    // نوشتن داده‌های پاراگراف‌ها به HTML با فراهم کردن شاخص شروع پاراگراف و تعداد کل پاراگراف‌های قابل کپی
    writer.write(ashape.getTextFrame().getParagraphs().exportToHtml(0, ashape.getTextFrame().getParagraphs().getCount(), null));
    writer.close();
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **ذخیره یک پاراگراف به عنوان تصویر**

در این بخش دو مثال را بررسی می‌کنیم که نشان می‌دهند چگونه یک پاراگراف متن، که توسط کلاس [Paragraph](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/paragraph/) نمایندگی می‌شود، به‌صورت تصویر ذخیره شود. هر دو مثال شامل دریافت تصویر یک شکل حاوی پاراگراف با استفاده از متدهای `getImage` از کلاس [Shape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/shape/) ، محاسبه مرزهای پاراگراف داخل شکل و خروجی آن به‌صورت تصویر بیت‌مپ هستند. این روش‌ها به شما امکان می‌دهند بخش‌های خاصی از متن را از ارائه‌های PowerPoint استخراج کنید و به‌صورت تصاویر جداگانه ذخیره کنید که می‌تواند در سناریوهای مختلف مفید باشد.

فرض کنیم یک فایل ارائه به نام sample.pptx با یک اسلاید داشته باشیم که اولین شکل آن یک جعبه متن شامل سه پاراگراف باشد.

![کادر متن با سه پاراگراف](paragraph_to_image_input.png)

**مثال 1**

در این مثال پاراگراف دوم را به‌صورت تصویر دریافت می‌کنیم. برای این کار تصویر شکل را از اولین اسلاید ارائه استخراج کرده و سپس مرزهای پاراگراف دوم در فریم متن شکل را محاسبه می‌کنیم. سپس پاراگراف روی یک تصویر بیت‌مپ جدید بازنقاشی می‌شود و به‌صورت PNG ذخیره می‌گردد. این روش به‌ویژه زمانی مفید است که بخواهید یک پاراگراف خاص را به‌عنوان تصویر جداگانه ذخیره کنید در حالی که ابعاد و قالب‌بندی دقیق متن حفظ می‌شود.

```java
const imageio = java.import("javax.imageio.ImageIO");
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const firstShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // شکل را در حافظه به صورت بیت‌مپ ذخیره می‌کند.
    const shapeImage = firstShape.getImage();
        
    const shapeImageStream = java.newInstanceSync("java.io.ByteArrayOutputStream");
    shapeImage.save(shapeImageStream, aspose.slides.ImageFormat.Png);
    shapeImage.dispose();
    shapeImageStream.flush();
    
    // یک بیت‌مپ شکل را از حافظه می‌سازد.
    const byteBuffer = java.callMethodSync(shapeImageStream, "toByteArray");    
    const javaBytes = java.newArray("byte", Array.from(byteBuffer));
    const ByteArrayInputStream = java.import("java.io.ByteArrayInputStream");
    const shapeImageInputStream = new ByteArrayInputStream(javaBytes);
    const shapeBitmap = imageio.read(shapeImageInputStream);

    // مرزهای پاراگراف دوم را محاسبه می‌کند.
    const secondParagraph = firstShape.getTextFrame().getParagraphs().get_Item(1);
    const paragraphRectangle = secondParagraph.getRect();

    // مختصات و اندازه تصویر خروجی را محاسبه می‌کند (حداقل اندازه - ۱×۱ پیکسل).
    const imageX = Math.floor(paragraphRectangle.getX());
    const imageY = Math.floor(paragraphRectangle.getY());
    const imageWidth = Math.max(1, Math.ceil(paragraphRectangle.getWidth()));
    const imageHeight = Math.max(1, Math.ceil(paragraphRectangle.getHeight()));

    // بیت‌مپ شکل را برش می‌دهد تا فقط بیت‌مپ پاراگراف به دست آید.
    const paragraphBitmap = shapeBitmap.getSubimage(imageX, imageY, imageWidth, imageHeight);

    const file = java.newInstanceSync("java.io.File", "paragraph.png");

    imageio.write(paragraphBitmap, "png", file);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

نتیجه:

![تصویر پاراگراف](paragraph_to_image_output.png)

**مثال 2**

در این مثال، روش قبلی را با افزودن عوامل مقیاس به تصویر پاراگراف گسترش می‌دهیم. شکل از ارائه استخراج می‌شود و با عامل مقیاس `2` به‌عنوان تصویر ذخیره می‌شود. این امکان خروجی با وضوح بالاتر را هنگام خروجی‌گیری پاراگراف فراهم می‌کند. سپس مرزهای پاراگراف با در نظر گرفتن مقیاس محاسبه می‌شوند. مقیاس‌بندی می‌تواند زمانی مفید باشد که تصویری با جزئیات بیشتر نیاز باشد، مثلاً برای استفاده در مواد چاپی با کیفیت بالا.

```java
const imageScaleX = 2;
const imageScaleY = imageScaleX;

const imageio = java.import("javax.imageio.ImageIO");
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const firstShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // شکل را در حافظه به صورت بیت‌مپ با مقیاس‌گذاری ذخیره می‌کند.
    const shapeImage = firstShape.getImage(aspose.slides.ShapeThumbnailBounds.Shape, imageScaleX, imageScaleY);
    const shapeImageStream = java.newInstanceSync("java.io.ByteArrayOutputStream");
    shapeImage.save(shapeImageStream, aspose.slides.ImageFormat.Png);
    shapeImage.dispose();

    // یک بیت‌مپ شکل را از حافظه می‌سازد.
    const byteBuffer = java.callMethodSync(shapeImageStream, "toByteArray");    
    const javaBytes = java.newArray("byte", Array.from(byteBuffer));
    const ByteArrayInputStream = java.import("java.io.ByteArrayInputStream");
    const shapeImageInputStream = new ByteArrayInputStream(javaBytes);
    const shapeBitmap = imageio.read(shapeImageInputStream);

    // مرزهای پاراگراف دوم را محاسبه می‌کند.
    const secondParagraph = firstShape.getTextFrame().getParagraphs().get_Item(1);
    const paragraphRectangle = secondParagraph.getRect();
    paragraphRectangle.setRect(
            paragraphRectangle.getX() * imageScaleX,
            paragraphRectangle.getY() * imageScaleY,
            paragraphRectangle.getWidth() * imageScaleX,
            paragraphRectangle.getHeight() * imageScaleY
    );

    // مختصات و اندازه تصویر خروجی را محاسبه می‌کند (حداقل اندازه - ۱×۱ پیکسل).
    const imageX = Math.floor(paragraphRectangle.getX());
    const imageY = Math.floor(paragraphRectangle.getY());
    const imageWidth = Math.max(1, Math.ceil(paragraphRectangle.getWidth()));
    const imageHeight = Math.max(1, Math.ceil(paragraphRectangle.getHeight()));

    // بیت‌مپ شکل را برش می‌دهد تا فقط بیت‌مپ پاراگراف به دست آید.
    const paragraphBitmap = shapeBitmap.getSubimage(imageX, imageY, imageWidth, imageHeight);

    const file = java.newInstanceSync("java.io.File", "paragraph.png");

    imageio.write(paragraphBitmap, "png", file);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **سوالات رایج**

**آیا می‌توانم کاملاً بسته‌بندی خطوط داخل یک فریم متن را غیرفعال کنم؟**

بله. از تنظیم بسته‌بندی فریم متن ([setWrapText](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textframeformat/setwraptext/)) استفاده کنید تا بسته‌بندی را خاموش کنید، بنابراین خطوط در لبه‌های فریم شکسته نمی‌شوند.

**چگونه می‌توانم مرزهای دقیق یک پاراگراف خاص را بر روی اسلاید بدست آورم؟**

می‌توانید مستطیل محصور کننده پاراگراف (و حتی یک بخش منفرد) را بازیابی کنید تا موقعیت و اندازه دقیق آن را روی اسلاید بدانید.

**کنترل تراز پاراگراف (چپ/راست/وسط/توزیع) در کجا انجام می‌شود؟**

متد [setAlignment](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/paragraphformat/setalignment/) تنظیم سطح پاراگراف در [ParagraphFormat](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/paragraphformat/) است؛ این تنظیم برای کل پاراگراف اعمال می‌شود صرف‌نظر از قالب‌بندی هر بخش جداگانه.

**آیا می‌توانم زبان بررسی املا را فقط برای بخشی از پاراگراف (مثلاً یک کلمه) تنظیم کنم؟**

بله. زبان در سطح بخش تنظیم می‌شود ([PortionFormat.setLanguageId](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/baseportionformat/#setLanguageId))، بنابراین می‌توان چندین زبان را در یک پاراگراف همزمان داشته باشید.