---
title: "مدیریت پاراگراف‌های متن پاورپوینت در جاوا اسکریپت"
linktitle: "مدیریت پاراگراف"
type: docs
weight: 40
url: /fa/nodejs-java/manage-paragraph/
aliases:
  - /nodejs-java/paragraph/
  - /nodejs-java/portion/
keywords:
  - "اضافه کردن متن"
  - "اضافه کردن پاراگراف"
  - "مدیریت متن"
  - "مدیریت پاراگراف"
  - "مدیریت گلوله"
  - "تورفتگی پاراگراف"
  - "تورفتگی آویزان"
  - "گلوله پاراگراف"
  - "فهرست شماره‌دار"
  - "فهرست گلوله‌ای"
  - "ویژگی‌های پاراگراف"
  - "وارد کردن HTML"
  - "متن به HTML"
  - "پاراگراف به HTML"
  - "پاراگراف به تصویر"
  - "متن به تصویر"
  - "صادرات پاراگراف"
  - "PowerPoint"
  - "OpenDocument"
  - "ارائه"
  - "Node.js"
  - "جاوا اسکریپت"
  - "Aspose.Slides"
description: "قالب‌بندی پاراگراف‌ها را با Aspose.Slides برای Node.js از طریق Java به‌صورت کامل فراگیرید—تراز، فاصله‌گذاری و سبک را در ارائه‌های PPT، PPTX و ODP در جاوا اسکریپت بهینه کنید."
---
## **مقدمه**

Aspose.Slides تمام کلاس‌ها و اجزای مورد نیاز برای کار با متون، پاراگراف‌ها و بخش‌های PowerPoint را در Java فراهم می‌کند.

* Aspose.Slides کلاس [TextFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textframe/) را ارائه می‌دهد تا بتوانید شیئی که نمایانگر یک پاراگراف است را اضافه کنید. یک شیء `TextFame` می‌تواند یک یا چند پاراگراف داشته باشد (هر پاراگراف از طریق یک کاراکتر برگشت‌خط ایجاد می‌شود).
* Aspose.Slides کلاس [Paragraph](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/paragraph/) را ارائه می‌دهد تا بتوانید شیئی که نمایانگر بخش‌ها است را اضافه کنید. یک شیء `Paragraph` می‌تواند یک یا چند بخش (مجموعه‌ای از اشیاء بخش متنی) داشته باشد.
* Aspose.Slides کلاس [Portion](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/portion/) را ارائه می‌دهد تا بتوانید شیئی که متون و خصوصیات قالب‌بندی آنها را نشان می‌دهد، اضافه کنید.

یک شیء `Paragraph` می‌تواند متونی با خصوصیات قالب‌بندی مختلف را از طریق اشیاء `Portion` زیرین خود مدیریت کند.

## **افزودن چندین پاراگراف حاوی چندین بخش**

این مراحل نشان می‌دهد چگونه یک فریم متن شامل ۳ پاراگراف و هر پاراگراف حاوی ۳ بخش اضافه کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) ایجاد کنید.
2. مرجع اسلاید مربوطه را از طریق اندیس آن دریافت کنید.
3. یک [AutoShape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/autoshape/) مستطیلی به اسلاید اضافه کنید.
4. `ITextFrame` مرتبط با [AutoShape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/autoshape/) را دریافت کنید.
5. دو شیء [Paragraph](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/paragraph/) ایجاد کنید و آنها را به مجموعه `IParagraphs` از [TextFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textframe/) اضافه کنید.
6. برای هر `Paragraph` جدید سه شیء [Portion](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/portion/) ایجاد کنید (دو شیء Portion برای پاراگراف پیش‌فرض) و هر شیء `Portion` را به مجموعه IPortion مربوط به هر `Paragraph` اضافه کنید.
7. برای هر بخش متنی تعیین کنید.
8. ویژگی‌های قالب‌بندی دلخواه خود را به هر بخش اعمال کنید با استفاده از خصوصیات قالب‌بندی ارائه‌شده توسط شیء `Portion`.
9. ارائهٔ تغییر یافته را ذخیره کنید.

این کد Javascript پیاده‌سازی مراحل افزودن پاراگراف‌های حاوی بخش‌ها است:

```javascript
// یک کلاس Presentation ایجاد می‌کند که نمایانگر یک فایل PPTX است
var pres = new aspose.slides.Presentation();
try {
    // دسترسی به اولین اسلاید
    var slide = pres.getSlides().get_Item(0);
    // افزودن یک AutoShape از نوع Rectangle
    var ashp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 150, 300, 150);
    // دسترسی به TextFrame شکل AutoShape
    var tf = ashp.getTextFrame();
    // ایجاد پاراگراف‌ها و بخش‌ها با قالب‌بندی متنی متفاوت
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

## **مدیریت گلوله‌های پاراگراف**

فهرست‌های گلوله‌ای به شما کمک می‌کند اطلاعات را به‌سرعت و کارآمد سازماندهی و ارائه کنید. پاراگراف‌های گلوله‌ای همیشه خواناتر و قابل درک‌تر هستند.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) ایجاد کنید.
2. مرجع اسلاید مربوطه را از طریق اندیس آن دریافت کنید.
3. یک [AutoShape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/autoshape/) به اسلاید انتخاب‌شده اضافه کنید.
4. به [TextFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textframe/) شکل دسترسی پیدا کنید.
5. پاراگراف پیش‌فرض موجود در `TextFrame` را حذف کنید.
6. اولین نمونهٔ پاراگراف را با استفاده از کلاس [Paragraph](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/paragraph/) ایجاد کنید.
7. نوع گلوله `Type` را برای پاراگراف به `Symbol` تنظیم کنید و کاراکتر گلوله را تعیین کنید.
8. متن پاراگراف را تنظیم کنید.
9. تورفتگی `Indent` پاراگراف برای گلوله را تنظیم کنید.
10. رنگی برای گلوله تعیین کنید.
11. ارتفاع گلوله را تنظیم کنید.
12. پاراگراف جدید را به مجموعه پاراگراف‌های `TextFrame` اضافه کنید.
13. پاراگراف دوم را اضافه کنید و مراحل ۷ تا ۱۳ را تکرار کنید.
14. ارائه را ذخیره کنید.

این کد Javascript نشان می‌دهد چگونه یک گلولهٔ پاراگراف اضافه کنید:

```javascript
// یک کلاس Presentation ایجاد می‌کند که نمایانگر یک فایل PPTX است
var pres = new aspose.slides.Presentation();
try {
    // به اولین اسلاید دسترسی پیدا می‌کند
    var slide = pres.getSlides().get_Item(0);
    // یک Autoshape اضافه می‌کند و به آن دسترسی می‌یابد
    var aShp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    // به فریم متنی autoshape دسترسی پیدا می‌کند
    var txtFrm = aShp.getTextFrame();
    // پاراگراف پیش‌فرض را حذف می‌کند
    txtFrm.getParagraphs().removeAt(0);
    // یک پاراگراف ایجاد می‌کند
    var para = new aspose.slides.Paragraph();
    // سبک گلوله و نماد پاراگراف را تنظیم می‌کند
    para.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para.getParagraphFormat().getBullet().setChar(8226);
    // متن پاراگراف را تنظیم می‌کند
    para.setText("Welcome to Aspose.Slides");
    // تورفتگی گلوله را تنظیم می‌کند
    para.getParagraphFormat().setIndent(25);
    // رنگ گلوله را تنظیم می‌کند
    para.getParagraphFormat().getBullet().getColor().setColorType(aspose.slides.ColorType.RGB);
    para.getParagraphFormat().getBullet().getColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    para.getParagraphFormat().getBullet().setBulletHardColor(aspose.slides.NullableBool.True);// تنظیم IsBulletHardColor به true برای استفاده از رنگ سفارشی گلوله
    // ارتفاع گلوله را تنظیم می‌کند
    para.getParagraphFormat().getBullet().setHeight(100);
    // پاراگراف را به فریم متن اضافه می‌کند
    txtFrm.getParagraphs().add(para);
    // پاراگراف دوم را ایجاد می‌کند
    var para2 = new aspose.slides.Paragraph();
    // نوع و سبک گلوله پاراگراف را تنظیم می‌کند
    para2.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Numbered);
    para2.getParagraphFormat().getBullet().setNumberedBulletStyle(aspose.slides.NumberedBulletStyle.BulletCircleNumWDBlackPlain);
    // متن پاراگراف را اضافه می‌کند
    para2.setText("This is numbered bullet");
    // تورفتگی گلوله را تنظیم می‌کند
    para2.getParagraphFormat().setIndent(25);
    para2.getParagraphFormat().getBullet().getColor().setColorType(aspose.slides.ColorType.RGB);
    para2.getParagraphFormat().getBullet().getColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    para2.getParagraphFormat().getBullet().setBulletHardColor(aspose.slides.NullableBool.True);// تنظیم IsBulletHardColor به true برای استفاده از رنگ سفارشی گلوله
    // ارتفاع گلوله را تنظیم می‌کند
    para2.getParagraphFormat().getBullet().setHeight(100);
    // پاراگراف را به فریم متن اضافه می‌کند
    txtFrm.getParagraphs().add(para2);
    // ارائهٔ تغییر یافته را ذخیره می‌کند
    pres.save("Bullet_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **مدیریت گلوله‌های تصویری**

فهرست‌های گلوله‌ای به شما کمک می‌کند اطلاعات را به‌سرعت و کارآمد سازماندهی و ارائه کنید. پاراگراف‌های تصویری خوانا و قابل درک هستند.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) ایجاد کنید.
2. مرجع اسلاید مربوطه را از طریق اندیس آن دریافت کنید.
3. یک [AutoShape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/autoshape/) به اسلاید اضافه کنید.
4. به [TextFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textframe/) شکل دسترسی پیدا کنید.
5. پاراگراف پیش‌فرض موجود در `TextFrame` را حذف کنید.
6. اولین نمونهٔ پاراگراف را با استفاده از کلاس [Paragraph](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/paragraph/) ایجاد کنید.
7. تصویر را در [PPImage](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/ppimage/) بارگذاری کنید.
8. نوع گلوله را به [Picture](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/ppimage/) تنظیم کنید و تصویر را تعیین کنید.
9. متن پاراگراف را تنظیم کنید.
10. تورفتگی `Indent` پاراگراف برای گلوله را تنظیم کنید.
11. رنگی برای گلوله تعیین کنید.
12. ارتفاع گلوله را تنظیم کنید.
13. پاراگراف جدید را به مجموعه پاراگراف‌های `TextFrame` اضافه کنید.
14. پاراگراف دوم را اضافه کنید و فرآیند را بر اساس مراحل قبلی تکرار کنید.
15. ارائهٔ تغییر یافته را ذخیره کنید.

این کد Javascript نشان می‌دهد چگونه گلوله‌های تصویری را اضافه و مدیریت کنید:

```javascript
// یک کلاس Presentation را نمونه‌سازی می‌کند که نمایانگر یک فایل PPTX است
var presentation = new aspose.slides.Presentation();
try {
    // به اسلاید اول دسترسی پیدا می‌کند
    var slide = presentation.getSlides().get_Item(0);
    // تصویر برای گلوله‌ها را ایجاد می‌کند
    var picture;
    var image = aspose.slides.Images.fromFile("bullets.png");
    try {
        picture = presentation.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // یک Autoshape اضافه می‌کند و به آن دسترسی پیدا می‌کند
    var autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    // به فریم متنی autoshape دسترسی پیدا می‌کند
    var textFrame = autoShape.getTextFrame();
    // پاراگراف پیش‌فرض را حذف می‌کند
    textFrame.getParagraphs().removeAt(0);
    // یک پاراگراف جدید ایجاد می‌کند
    var paragraph = new aspose.slides.Paragraph();
    paragraph.setText("Welcome to Aspose.Slides");
    // سبک گلوله پاراگراف و تصویر را تنظیم می‌کند
    paragraph.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Picture);
    paragraph.getParagraphFormat().getBullet().getPicture().setImage(picture);
    // ارتفاع گلوله را تنظیم می‌کند
    paragraph.getParagraphFormat().getBullet().setHeight(100);
    // پاراگراف را به فریم متنی اضافه می‌کند
    textFrame.getParagraphs().add(paragraph);
    // ارائه را به عنوان فایل PPTX ذخیره می‌کند
    presentation.save("ParagraphPictureBulletsPPTX_out.pptx", aspose.slides.SaveFormat.Pptx);
    // ارائه را به عنوان فایل PPT ذخیره می‌کند
    presentation.save("ParagraphPictureBulletsPPT_out.ppt", aspose.slides.SaveFormat.Ppt);
} catch (e) {console.log(e);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **مدیریت گلوله‌های چندسطحی**

فهرست‌های گلوله‌ای به شما کمک می‌کند اطلاعات را به‌سرعت و کارآمد سازماندهی و ارائه کنید. گلوله‌های چندسطحی خوانا و قابل درک هستند.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) ایجاد کنید.
2. مرجع اسلاید مربوطه را از طریق اندیس آن دریافت کنید.
3. یک [AutoShape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/autoshape/) در اسلاید جدید اضافه کنید.
4. به [TextFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textframe/) شکل دسترسی پیدا کنید.
5. پاراگراف پیش‌فرض موجود در `TextFrame` را حذف کنید.
6. اولین پاراگراف را از طریق کلاس [Paragraph](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/paragraph/) ایجاد کنید و عمق را روی ۰ تنظیم کنید.
7. دومین پاراگراف را از طریق کلاس `Paragraph` ایجاد کنید و عمق را روی ۱ تنظیم کنید.
8. سومین پاراگراف را از طریق کلاس `Paragraph` ایجاد کنید و عمق را روی ۲ تنظیم کنید.
9. چهارمین پاراگراف را از طریق کلاس `Paragraph` ایجاد کنید و عمق را روی ۳ تنظیم کنید.
10. پاراگراف‌های جدید را به مجموعه پاراگراف‌های `TextFrame` اضافه کنید.
11. ارائهٔ تغییر یافته را ذخیره کنید.

این کد Javascript نشان می‌دهد چگونه گلوله‌های چندسطحی را اضافه و مدیریت کنید:

```javascript
// یک کلاس Presentation ایجاد می‌کند که نمایانگر یک فایل PPTX است
var pres = new aspose.slides.Presentation();
try {
    // به اولین اسلاید دسترسی پیدا می‌کند
    var slide = pres.getSlides().get_Item(0);
    // یک Autoshape اضافه می‌کند و به آن دسترسی پیدا می‌کند
    var aShp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    // به فریم متنی شکل autoshape ایجاد شده دسترسی پیدا می‌کند
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
    // سطح گلوله را تنظیم می‌کند
    para1.getParagraphFormat().setDepth(0);
    // پاراگراف دوم را اضافه می‌کند
    var para2 = new aspose.slides.Paragraph();
    para2.setText("Second Level");
    para2.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para2.getParagraphFormat().getBullet().setChar('-');
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // سطح گلوله را تنظیم می‌کند
    para2.getParagraphFormat().setDepth(1);
    // پاراگراف سوم را اضافه می‌کند
    var para3 = new aspose.slides.Paragraph();
    para3.setText("Third Level");
    para3.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para3.getParagraphFormat().getBullet().setChar(8226);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // سطح گلوله را تنظیم می‌کند
    para3.getParagraphFormat().setDepth(2);
    // پاراگراف چهارم را اضافه می‌کند
    var para4 = new aspose.slides.Paragraph();
    para4.setText("Fourth Level");
    para4.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para4.getParagraphFormat().getBullet().setChar('-');
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // سطح گلوله را تنظیم می‌کند
    para4.getParagraphFormat().setDepth(3);
    // پاراگراف‌ها را به مجموعه اضافه می‌کند
    text.getParagraphs().add(para1);
    text.getParagraphs().add(para2);
    text.getParagraphs().add(para3);
    text.getParagraphs().add(para4);
    // ارائه را به صورت فایل PPTX ذخیره می‌کند
    pres.save("MultilevelBullet.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **مدیریت پاراگراف با فهرست شماره‌دار سفارشی**

کلاس [BulletFormat](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/bulletformat/) ویژگی [NumberedBulletStartWith](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/bulletformat/#setNumberedBulletStartWith-short-) و سایر ویژگی‌ها را فراهم می‌کند تا بتوانید پاراگراف‌ها را با شماره‌گذاری یا قالب‌بندی سفارشی مدیریت کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) ایجاد کنید.
2. به اسلاید حاوی پاراگراف دسترسی پیدا کنید.
3. یک [AutoShape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/autoshape/) به اسلاید اضافه کنید.
4. به [TextFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textframe/) شکل دسترسی پیدا کنید.
5. پاراگراف پیش‌فرض موجود در `TextFrame` را حذف کنید.
6. اولین پاراگراف را از طریق کلاس [Paragraph](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/paragraph/) ایجاد کنید و [NumberedBulletStartWith](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/bulletformat/#setNumberedBulletStartWith-short-) را روی ۲ تنظیم کنید.
7. دومین پاراگراف را از طریق کلاس `Paragraph` ایجاد کنید و `NumberedBulletStartWith` را روی ۳ تنظیم کنید.
8. سومین پاراگراف را از طریق کلاس `Paragraph` ایجاد کنید و `NumberedBulletStartWith` را روی ۷ تنظیم کنید.
9. پاراگراف‌های جدید را به مجموعه پاراگراف‌های `TextFrame` اضافه کنید.
10. ارائهٔ تغییر یافته را ذخیره کنید.

این کد Javascript نشان می‌دهد چگونه پاراگراف‌ها را با شماره‌گذاری یا قالب‌بندی سفارشی اضافه و مدیریت کنید:

```javascript
var presentation = new aspose.slides.Presentation();
try {
    var shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    // به فریم متنی autoshape ایجاد شده دسترسی پیدا می‌کند
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

## **تنظیم تورفتگی خط اول برای یک پاراگراف**

از متد [ParagraphFormat.setIndent](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/paragraphformat/setindent/) برای کنترل تورفتگی خط اول یک پاراگراف استفاده کنید. این متد تنها خط اول را نسبت به حاشیهٔ چپ پاراگراف جابه‌جا می‌کند. مقدار مثبت خط اول را به راست می‌برد، در حالی که بقیه خطوط به بدنهٔ پاراگراف هم‌راستا می‌مانند.

هنگامی که نیاز به جابه‌جایی کل پاراگراف دارید از [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) استفاده کنید. برای جابه‌جایی تنها خط اول از [ParagraphFormat.setIndent](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/paragraphformat/setindent/) استفاده کنید.

مثال زیر چندین پاراگراف ایجاد می‌کند و مقادیر تورفتگی متفاوتی را برای نشان دادن تأثیر تورفتگی خط اول بر چیدمان پاراگراف اعمال می‌نماید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) ایجاد کنید.
2. به اسلاید هدف دسترسی پیدا کنید.
3. یک [AutoShape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/autoshape/) مستطیلی به اسلاید اضافه کنید.
4. یک [TextFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textframe/) خالی به شکل اضافه کنید و پاراگراف پیش‌فرض را حذف کنید.
5. چندین پاراگراف ایجاد کنید و مقادیر مختلف [Indent](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/paragraphformat/setindent/) را برای آنها تنظیم کنید.
6. پاراگراف‌ها را به فریم متن اضافه کنید.
7. ارائهٔ تغییر یافته را ذخیره کنید.

این کد نشان می‌دهد چگونه تورفتگی یک پاراگراف را تنظیم کنید:

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

![The first-line indent of the paragraphs](first_line_indent.png)

## **تنظیم تورفتگی آویزان برای یک پاراگراف**

تورفتگی آویزان، چیدمان پاراگرافی است که در آن خط اول به سمت چپ خطوط دیگر می‌آید. در Aspose.Slides این اثر را با استفاده از متد [ParagraphFormat.setIndent](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/paragraphformat/setindent/) ایجاد می‌کنید. برای جابه‌جایی خط اول به سمت چپ، مقدار تورفتگی را منفی تنظیم کنید.

در عمل، [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) موقعیت سمت چپ بدنهٔ پاراگراف را تعیین می‌کند و [ParagraphFormat.setIndent](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/paragraphformat/setindent/) موقعیت خط اول را نسبت به آن حاشیه تنظیم می‌کند. برای ایجاد تورفتگی آویزان، مقدار `MarginLeft` را مثبت و مقدار `Indent` را منفی بگذارید.

این قالب‌بندی برای فهرست‌های مراجع، کتاب‌نامه‌ها، واژگان و سایر پاراگراف‌هایی که خطوط بسته‌بندی‌شده باید زیر بدنهٔ پاراگراف قرار گیرند، مفید است.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) ایجاد کنید.
2. به اسلاید هدف دسترسی پیدا کنید.
3. یک [AutoShape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/autoshape/) مستطیلی به اسلاید اضافه کنید.
4. یک [TextFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textframe/) خالی به شکل اضافه کنید و پاراگراف پیش‌فرض را حذف کنید.
5. برای هر پاراگراف مقدار مثبت [MarginLeft](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) تنظیم کنید.
6. مقدار منفی [Indent](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/paragraphformat/setindent/) را برای ایجاد اثر تورفتگی آویزان تنظیم کنید.
7. پاراگراف‌ها را به فریم متن اضافه کنید.
8. ارائهٔ تغییر یافته را ذخیره کنید.

این کد نشان می‌دهد چگونه تورفتگی آویزان برای یک پاراگراف تنظیم کنید:

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

![The hanging indent of the paragraphs](hanging_indent.png)

## **مدیریت ویژگی‌های End Run برای پاراگراف**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) ایجاد کنید.
1. مرجع اسلاید حاوی پاراگراف را از طریق موقعیت آن دریافت کنید.
1. یک [AutoShape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/autoshape/) مستطیلی به اسلاید اضافه کنید.
1. یک [TextFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textframe/) با دو پاراگراف به مستطیل اضافه کنید.
1. `FontHeight` و نوع قلم را برای پاراگراف‌ها تنظیم کنید.
1. ویژگی‌های End را برای پاراگراف‌ها تنظیم کنید.
1. ارائهٔ تغییر یافته را به‌صورت فایل PPTX ذخیره کنید.

این کد Javascript نشان می‌دهد چگونه ویژگی‌های End را برای پاراگراف‌ها در PowerPoint تنظیم کنید:

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
2. مرجع اسلاید مربوطه را از طریق اندیس آن دریافت کنید.
3. یک [AutoShape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/autoshape/) به اسلاید اضافه کنید.
4. `AutoShape`‌'s [TextFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textframe/) را اضافه و دسترسی پیدا کنید.
5. پاراگراف پیش‌فرض موجود در `TextFrame` را حذف کنید.
6. فایل HTML منبع را در یک TextReader بخوانید.
7. اولین پاراگراف را از طریق کلاس [Paragraph](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/paragraph/) ایجاد کنید.
8. محتوای فایل HTML خوانده‌شده را به [ParagraphCollection](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/paragraphcollection/) فریم متن اضافه کنید.
9. ارائهٔ تغییر یافته را ذخیره کنید.

این کد Javascript پیاده‌سازی مراحل وارد کردن متون HTML به پاراگراف‌هاست:

```javascript
// یک نمونهٔ خالی از ارائه ایجاد می‌کند
var pres = new aspose.slides.Presentation();
try {
    // به اسلاید پیش‌فرض اول ارائه دسترسی پیدا می‌کند
    var slide = pres.getSlides().get_Item(0);
    // اضافه کردن AutoShape برای جایگیری محتوای HTML
    var ashape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, pres.getSlideSize().getSize().getWidth() - 20, pres.getSlideSize().getSize().getHeight() - 10);
    ashape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    // افزودن فریم متنی به شکل
    ashape.addTextFrame("");
    // پاک‌سازی تمام پاراگراف‌های موجود در فریم متن اضافه‌شده
    ashape.getTextFrame().getParagraphs().clear();
    // بارگذاری فایل HTML با استفاده از StreamReader
    var tr = java.newInstanceSync("StreamReader", "file.html");
    // اضافه کردن متن از StreamReader HTML به فریم متن
    ashape.getTextFrame().getParagraphs().addFromHtml(tr.readToEnd());
    // ذخیرهٔ ارائه
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **صادر کردن متن پاراگراف‌ها به HTML**

Aspose.Slides پشتیبانی پیشرفته‌ای برای صادرات متون (موجود در پاراگراف‌ها) به HTML فراهم می‌کند.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) ایجاد کنید و ارائهٔ موردنظر را بارگذاری کنید.
2. مرجع اسلاید مربوطه را از طریق اندیس آن دریافت کنید.
3. به شکل حاکی از متنی که به HTML صادر خواهد شد دسترسی پیدا کنید.
4. به [TextFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textframe/) شکل دسترسی پیدا کنید.
5. یک نمونه از `StreamWriter` ایجاد کنید و فایل HTML جدید را اضافه کنید.
6. یک ایندکس شروع به StreamWriter بدهید و پاراگراف‌های دلخواه را صادر کنید.

این کد Javascript نشان می‌دهد چگونه متون پاراگراف‌های PowerPoint را به HTML صادر کنید:

```javascript
// فایل ارائه را بارگذاری کنید
var pres = new aspose.slides.Presentation("ExportingHTMLText.pptx");
try {
    // به اسلاید پیش‌فرض اول ارائه دسترسی پیدا می‌کند
    var slide = pres.getSlides().get_Item(0);
    // اندیس موردنظر
    var index = 0;
    // دسترسی به شکل اضافه‌شده
    var ashape = slide.getShapes().get_Item(index);
    // ایجاد فایل خروجی HTML
    var os = java.newInstanceSync("java.io.FileOutputStream", "output.html");
    var writer = java.newInstanceSync("java.io.OutputStreamWriter", os, "UTF-8");
    // استخراج اولین پاراگراف به‌صورت HTML
    // نوشتن داده‌های پاراگراف‌ها به HTML با ارائه اندیس شروع پاراگراف و تعداد کل پاراگراف‌های قابل کپی
    writer.write(ashape.getTextFrame().getParagraphs().exportToHtml(0, ashape.getTextFrame().getParagraphs().getCount(), null));
    writer.close();
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **ذخیره یک پاراگراف به‌صورت تصویر**

در این بخش دو مثال برای نشان دادن نحوهٔ ذخیرهٔ یک پاراگراف متنی، نمایان‌شده توسط کلاس [Paragraph](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/paragraph/)، به‌صورت تصویر بررسی می‌شود. هر دو مثال شامل دریافت تصویر شکل حاوی پاراگراف با استفاده از متدهای `getImage` از کلاس [Shape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/shape/)، محاسبهٔ محدودهٔ پاراگراف داخل شکل و صادرات آن به‌عنوان تصویر بیت‌مپ است. این روش‌ها به شما امکان می‌دهند بخش‌های خاصی از متن ارائه‌های PowerPoint را استخراج و به‌صورت تصاویر جداگانه ذخیره کنید که می‌تواند در سناریوهای مختلف مفید باشد.

فرض کنید فایلی به نام sample.pptx داریم که شامل یک اسلاید است و اولین شکل آن یک باکس متن حاوی سه پاراگراف می‌باشد.

![The text box with three paragraphs](paragraph_to_image_input.png)

**مثال ۱**

در این مثال، پاراگراف دوم به‌صورت تصویر استخراج می‌شود. برای این کار، تصویر شکل را از اسلاید اول استخراج می‌کنیم، سپس محدودهٔ پاراگراف دوم را در فریم متن شکل محاسبه می‌کنیم. پاراگراف سپس روی یک بیت‌مپ جدید رسم می‌شود و به‌صورت PNG ذخیره می‌گردد. این روش برای ذخیرهٔ پاراگراف خاصی به‌عنوان تصویر جداگانه با حفظ ابعاد و قالب‌بندی دقیق متن مفید است.

```java
const imageio = java.import("javax.imageio.ImageIO");
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const firstShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // شکل را به‌عنوان بیت‌مپ در حافظه ذخیره می‌کند.
    const shapeImage = firstShape.getImage();
        
    const shapeImageStream = java.newInstanceSync("java.io.ByteArrayOutputStream");
    shapeImage.save(shapeImageStream, aspose.slides.ImageFormat.Png);
    shapeImage.dispose();
    shapeImageStream.flush();
    
    // بیت‌مپ شکل را از حافظه ایجاد می‌کند.
    const byteBuffer = java.callMethodSync(shapeImageStream, "toByteArray");    
    const javaBytes = java.newArray("byte", Array.from(byteBuffer));
    const ByteArrayInputStream = java.import("java.io.ByteArrayInputStream");
    const shapeImageInputStream = new ByteArrayInputStream(javaBytes);
    const shapeBitmap = imageio.read(shapeImageInputStream);

    // مرزهای پاراگراف دوم را محاسبه می‌کند.
    const secondParagraph = firstShape.getTextFrame().getParagraphs().get_Item(1);
    const paragraphRectangle = secondParagraph.getRect();

    // مختصات و اندازهٔ تصویر خروجی را محاسبه می‌کند (حداقل اندازه - 1×1 پیکسل).
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

![The paragraph image](paragraph_to_image_output.png)

**مثال ۲**

در این مثال، رویکرد قبلی با افزودن عوامل مقیاس‌گذاری به تصویر پاراگراف گسترش می‌یابد. شکل از ارائه استخراج می‌شود و با عامل مقیاس `2` به‌عنوان تصویر ذخیره می‌شود. این امکان خروجی با وضوح بالاتر را در زمان صادرات پاراگراف فراهم می‌کند. سپس محدودهٔ پاراگراف با در نظرگیری مقیاس محاسبه می‌شود. مقیاس‌گذاری به‌ویژه هنگام نیاز به تصویر با جزئیات بیشتر، مثلاً برای استفاده در مطالب چاپی با کیفیت بالا، مفید است.

```java
const imageScaleX = 2;
const imageScaleY = imageScaleX;

const imageio = java.import("javax.imageio.ImageIO");
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const firstShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // شکل را به‌عنوان بیت‌مپ در حافظه ذخیره می‌کند با مقیاس.
    const shapeImage = firstShape.getImage(aspose.slides.ShapeThumbnailBounds.Shape, imageScaleX, imageScaleY);
    const shapeImageStream = java.newInstanceSync("java.io.ByteArrayOutputStream");
    shapeImage.save(shapeImageStream, aspose.slides.ImageFormat.Png);
    shapeImage.dispose();

    // یک بیت‌مپ شکل را از حافظه ایجاد می‌کند.
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

    // مختصات و اندازه تصویر خروجی را محاسبه می‌کند (حداقل اندازه - 1×1 پیکسل).
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

## **سؤالات متداول**

**آیا می‌توانم بسته‌بندی خطوط داخل فریم متن را به‌طور کامل غیرفعال کنم؟**

بله. از تنظیمات بسته‌بندی فریم متن ([setWrapText](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textframeformat/setwraptext/)) استفاده کنید تا بسته‌بندی خاموش شود و خطوط در لبه‌های فریم شکسته نشوند.

**چگونه می‌توانم مرزهای دقیق یک پاراگراف خاص را روی اسلاید بدست آورم؟**

می‌توانید مستطیل محدودهٔ پاراگراف (و حتی یک بخش) را برای دانستن موقعیت و اندازهٔ دقیق آن روی اسلاید بازیابی کنید.

**کنترل تراز پاراگراف (چپ/راست/وسط/تراز) در کجا قرار دارد؟**

[setAlignment](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/paragraphformat/setalignment/) متدی برای تنظیم سطح پاراگراف در [ParagraphFormat](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/paragraphformat/) است؛ این تنظیم برای کل پاراگراف اعمال می‌شود صرف‌نظر از قالب‌بندی هر بخش جداگانه.

**آیا می‌توانم زبان بررسی املا را فقط برای بخشی از پاراگراف (مثلاً یک کلمه) تنظیم کنم؟**

بله. زبان در سطح بخش تنظیم می‌شود ([PortionFormat.setLanguageId](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/baseportionformat/#setLanguageId))، بنابراین می‌توان چندین زبان را در یک پاراگراف همزمان داشته باشید.