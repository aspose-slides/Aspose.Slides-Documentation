---
title: مدیریت پاراگراف‌های متن PowerPoint در اندروید
linktitle: مدیریت پاراگراف
type: docs
weight: 40
url: /fa/androidjava/manage-paragraph/
keywords:
- افزودن متن
- افزودن پاراگراف
- مدیریت متن
- مدیریت پاراگراف
- مدیریت نقطه
- تورفتگی پاراگراف
- تورفتگی معلق
- نقطه‌گذاری پاراگراف
- فهرست عددی
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
- Android
- Java
- Aspose.Slides
description: "قالب‌بندی پیشرفته پاراگراف‌ها را با Aspose.Slides برای اندروید به‌دست می‌آورید—ترازبندی، فواصل و استایل را در ارائه‌های PPT، PPTX و ODP در جاوا بهینه کنید."
---
## **معرفی**

Aspose.Slides تمام رابط‌ها و کلاس‌هایی را که برای کار با متن‌های PowerPoint، پاراگراف‌ها و بخش‌ها در Java نیاز دارید، فراهم می‌کند.

* Aspose.Slides رابط [ITextFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/itextframe/) را ارائه می‌دهد تا بتوانید اشیائی که نمایانگر یک پاراگراف هستند را اضافه کنید. یک شیء `ITextFame` می‌تواند یک یا چند پاراگراف داشته باشد (هر پاراگراف با یک بازگشت کاراکتر ایجاد می‌شود).
* Aspose.Slides رابط [IParagraph](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iparagraph/) را ارائه می‌دهد تا بتوانید اشیائی که نمایانگر بخش‌ها هستند را اضافه کنید. یک شیء `IParagraph` می‌تواند یک یا چند بخش داشته باشد (مجموعه‌ای از اشیاء iPortions).
* Aspose.Slides رابط [IPortion](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iportion/) را ارائه می‌دهد تا بتوانید اشیائی که نمایانگر متن و ویژگی‌های قالب‌بندی آن هستند را اضافه کنید.

یک شیء `IParagraph` قادر است متن‌ها را با ویژگی‌های قالب‌بندی متفاوت از طریق اشیاء زیرین `IPortion` خود مدیریت کند.

## **اضافه کردن چندین پاراگراف حاوی چندین بخش متنی**

این مراحل نشان می‌دهد چگونه یک قاب متن شامل 3 پاراگراف و هر پاراگراف شامل 3 بخش اضافه کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/) ایجاد کنید.
2. از طریق اندیس، به اسلاید مربوطه دسترسی پیدا کنید.
3. یک مستطیل [IAutoShape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iautoshape/) به اسلاید اضافه کنید.
4. `ITextFrame` مرتبط با [IAutoShape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iautoshape/) را دریافت کنید.
5. دو شیء [IParagraph](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iparagraph/) ایجاد کرده و به مجموعه `IParagraphs` از [ITextFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/itextframe/) اضافه کنید.
6. برای هر `IParagraph` جدید (دو شیء Portion برای پاراگراف پیش‌فرض) سه شیء [IPortion](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iportion/) ایجاد کرده و هر شیء `IPortion` را به مجموعه IPortion آن پاراگراف اضافه کنید.
7. برای هر بخش متنی، مقداری متن تنظیم کنید.
8. ویژگی‌های قالب‌بندی دلخواه خود را به هر بخش اعمال کنید با استفاده از ویژگی‌های قالب‌بندی موجود در شیء `IPortion`.
9. ارائه (پرزنتیشن) اصلاح‌شده را ذخیره کنید.

این کد Java پیاده‌سازی مراحل اضافه کردن پاراگراف‌های حاوی بخش‌ها است:

```java
// یک شیء Presentation ایجاد می‌کند که نمایانگر یک فایل PPTX است
Presentation pres = new Presentation();
try {
    // دسترسی به اولین اسلاید
    ISlide slide = pres.getSlides().get_Item(0);

    // اضافه کردن یک AutoShape از نوع Rectangle
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 300, 150);

    // دسترسی به TextFrame شکل AutoShape
    ITextFrame tf = ashp.getTextFrame();

    // ایجاد پاراگراف‌ها و بخش‌ها با قالب‌بندی‌های متنی مختلف
    IParagraph para0 = tf.getParagraphs().get_Item(0);
    IPortion port01 = new Portion();
    IPortion port02 = new Portion();
    para0.getPortions().add(port01);
    para0.getPortions().add(port02);

    IParagraph para1 = new Paragraph();
    tf.getParagraphs().add(para1);
    IPortion port10 = new Portion();
    IPortion port11 = new Portion();
    IPortion port12 = new Portion();
    para1.getPortions().add(port10);
    para1.getPortions().add(port11);
    para1.getPortions().add(port12);

    IParagraph para2 = new Paragraph();
    tf.getParagraphs().add(para2);
    IPortion port20 = new Portion();
    IPortion port21 = new Portion();
    IPortion port22 = new Portion();
    para2.getPortions().add(port20);
    para2.getPortions().add(port21);
    para2.getPortions().add(port22);

    for (int i = 0; i < 3; i++) 
    {
        for (int j = 0; j < 3; j++) 
        {
            IPortion portion = tf.getParagraphs().get_Item(i).getPortions().get_Item(j); 
            portion.setText("Portion0" + j);
            if (j == 0) {
                portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);
                portion.getPortionFormat().setFontBold(NullableBool.True);
                portion.getPortionFormat().setFontHeight(15);
            } else if (j == 1) {
                portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
                portion.getPortionFormat().setFontItalic(NullableBool.True);
                portion.getPortionFormat().setFontHeight(18);
            }
        }
    }

    //Write PPTX بر روی دیسک
    pres.save("multiParaPort_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **مدیریت نقطه‌گذاری (Bullets) پاراگراف**

فهرست‌های نقطه‌دار به شما کمک می‌کند تا اطلاعات را به‌سرعت و به‌صورت مؤثر سازماندهی و ارائه کنید. پاراگراف‌های نقطه‌دار همیشه خواناتر و قابل‌فهم‌تر هستند.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/) ایجاد کنید.
2. از طریق اندیس، به اسلاید مربوطه دسترسی پیدا کنید.
3. یک [autoshape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iautoshape/) به اسلاید انتخاب‌شده اضافه کنید.
4. به [TextFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/itextframe/) شکل دسترسی پیدا کنید.
5. پاراگراف پیش‌فرض در `TextFrame` را حذف کنید.
6. نمونه اولین پاراگراف را با استفاده از کلاس [Paragraph](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/paragraph/) ایجاد کنید.
7. ویژگی `Type` نقطه را برای پاراگراف به `Symbol` تنظیم کنید و کاراکتر نقطه را تعیین کنید.
8. متن پاراگراف را تنظیم کنید.
9. تورفتگی (Indent) پاراگراف برای نقطه را تنظیم کنید.
10. رنگی برای نقطه تعیین کنید.
11. ارتفاع نقطه را تنظیم کنید.
12. پاراگراف جدید را به مجموعه پاراگراف‌های `TextFrame` اضافه کنید.
13. پاراگراف دوم را اضافه کنید و مراحل 7 تا 12 را تکرار کنید.
14. ارائه را ذخیره کنید.

این کد Java نشان می‌دهد چگونه یک نقطه‌گذاری پاراگراف اضافه کنید:

```java
// یک شیء Presentation را که نمایانگر یک فایل PPTX است، ایجاد می‌کند
Presentation pres = new Presentation();
try {
    // به اولین اسلاید دسترسی پیدا می‌کند
    ISlide slide = pres.getSlides().get_Item(0);
    
    // افزودن و دسترسی به Autoshape
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // دسترسی به فریم متن autoshape
    ITextFrame txtFrm = aShp.getTextFrame();

    // حذف پاراگراف پیش‌فرض
    txtFrm.getParagraphs().removeAt(0);

    // ایجاد یک پاراگراف
    Paragraph para = new Paragraph();

    // تنظیم سبک و نماد نقطه‌گذاری پاراگراف
    para.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para.getParagraphFormat().getBullet().setChar((char)8226);

    // تنظیم متن پاراگراف
    para.setText("Welcome to Aspose.Slides");

    // تنظیم تورفتگی نقطه‌گذاری
    para.getParagraphFormat().setIndent(25);

    // تنظیم رنگ نقطه‌گذاری
    para.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    para.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    para.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True); // مقدار IsBulletHardColor را به true تنظیم می‌کند تا از رنگ دلخواه نقطه استفاده شود

    // تنظیم ارتفاع نقطه‌گذاری
    para.getParagraphFormat().getBullet().setHeight(100);

    // افزودن پاراگراف به فریم متن
    txtFrm.getParagraphs().add(para);

    // ایجاد پاراگراف دوم
    Paragraph para2 = new Paragraph();

    // تنظیم نوع و سبک نقطه‌گذاری پاراگراف
    para2.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    para2.getParagraphFormat().getBullet().setNumberedBulletStyle(NumberedBulletStyle.BulletCircleNumWDBlackPlain);

    // افزودن متن پاراگراف
    para2.setText("This is numbered bullet");

    // تنظیم تورفتگی نقطه‌گذاری
    para2.getParagraphFormat().setIndent(25);

    para2.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    para2.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    para2.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True); // مقدار IsBulletHardColor را به true تنظیم می‌کند تا از رنگ دلخواه نقطه استفاده شود

    // تنظیم ارتفاع نقطه‌گذاری
    para2.getParagraphFormat().getBullet().setHeight(100);

    // افزودن پاراگراف به فریم متن
    txtFrm.getParagraphs().add(para2);
    
    // ذخیره ارائه اصلاح‌شده
    pres.save("Bullet_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **مدیریت نقطه‌گذاری تصویر (Picture Bullets)**

فهرست‌های نقطه‌دار به شما کمک می‌کند تا اطلاعات را به‌سرعت و به‌صورت مؤثر سازماندهی و ارائه کنید. پاراگراف‌های تصویری نیز قابل‌خواندن و قابل‌فهم هستند.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/) ایجاد کنید.
2. از طریق اندیس، به اسلاید مربوطه دسترسی پیدا کنید.
3. یک [autoshape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iautoshape/) به اسلاید اضافه کنید.
4. به [TextFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/itextframe/) شکل دسترسی پیدا کنید.
5. پاراگراف پیش‌فرض در `TextFrame` را حذف کنید.
6. نمونه اولین پاراگراف را با استفاده از کلاس [Paragraph](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/paragraph/) ایجاد کنید.
7. تصویر را با استفاده از [IPPImage](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ippimage/) بارگذاری کنید.
8. نوع نقطه را به [Picture](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ippimage/) تنظیم کنید و تصویر را تعیین کنید.
9. متن پاراگراف را تنظیم کنید.
10. تورفتگی (Indent) پاراگراف برای نقطه را تنظیم کنید.
11. رنگی برای نقطه تعیین کنید.
12. ارتفاع نقطه را تنظیم کنید.
13. پاراگراف جدید را به مجموعه پاراگراف‌های `TextFrame` اضافه کنید.
14. پاراگراف دوم را اضافه کنید و همان فرآیند را بر اساس مراحل قبلی تکرار کنید.
15. ارائه اصلاح‌شده را ذخیره کنید.

این کد Java نشان می‌دهد چگونه نقاط تصویر اضافه و مدیریت کنید:

```java
// یک شیء Presentation را که نمایانگر یک فایل PPTX است، ایجاد می‌کند
Presentation presentation = new Presentation();
try {
    // به اولین اسلاید دسترسی پیدا می‌کند
    ISlide slide = presentation.getSlides().get_Item(0);

    // تصویر برای نقطه‌گذاری‌ها را ایجاد می‌کند
    IPPImage picture;
    IImage image = Images.fromFile("bullets.png");
    try {
        picture = presentation.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }
    // افزودن و دسترسی به Autoshape
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // دسترسی به فریم متن autoshape
    ITextFrame textFrame = autoShape.getTextFrame();

    // حذف پاراگراف پیش‌فرض
    textFrame.getParagraphs().removeAt(0);

    // ایجاد یک پاراگراف جدید
    Paragraph paragraph = new Paragraph();
    paragraph.setText("Welcome to Aspose.Slides");

    // تنظیم سبک نقطه‌گذاری پاراگراف و تصویر
    paragraph.getParagraphFormat().getBullet().setType(BulletType.Picture);
    paragraph.getParagraphFormat().getBullet().getPicture().setImage(picture);

    // تنظیم ارتفاع نقطه‌گذاری
    paragraph.getParagraphFormat().getBullet().setHeight(100);

    // افزودن پاراگراف به فریم متن
    textFrame.getParagraphs().add(paragraph);

    // نوشتن ارائه به عنوان فایل PPTX
    presentation.save("ParagraphPictureBulletsPPTX_out.pptx", SaveFormat.Pptx);

    // نوشتن ارائه به عنوان فایل PPT
    presentation.save("ParagraphPictureBulletsPPT_out.ppt", SaveFormat.Ppt);
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **مدیریت نقطه‌گذاری چندسطحی (Multilevel Bullets)**

فهرست‌های نقطه‌دار به شما کمک می‌کند تا اطلاعات را به‌سرعت و به‌صورت مؤثر سازماندهی و ارائه کنید. نقاط چندسطحی نیز قابل‌خواندن و قابل‌فهم هستند.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/) ایجاد کنید.
2. از طریق اندیس، به اسلاید مربوطه دسترسی پیدا کنید.
3. یک [autoshape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iautoshape/) در اسلاید جدید اضافه کنید.
4. به [TextFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/itextframe/) شکل دسترسی پیدا کنید.
5. پاراگراف پیش‌فرض در `TextFrame` را حذف کنید.
6. اولین پاراگراف را از طریق کلاس [Paragraph](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/paragraph/) ایجاد کنید و عمق را به 0 تنظیم کنید.
7. دومین پاراگراف را از طریق کلاس `Paragraph` ایجاد کنید و عمق را به 1 تنظیم کنید.
8. سومین پاراگراف را از طریق کلاس `Paragraph` ایجاد کنید و عمق را به 2 تنظیم کنید.
9. چهارمین پاراگراف را از طریق کلاس `Paragraph` ایجاد کنید و عمق را به 3 تنظیم کنید.
10. پاراگراف‌های جدید را به مجموعه پاراگراف‌های `TextFrame` اضافه کنید.
11. ارائه اصلاح‌شده را ذخیره کنید.

این کد Java نشان می‌دهد چگونه نقاط چندسطحی اضافه و مدیریت کنید:

```java
    // یک شیء Presentation که نمایانگر یک فایل PPTX است، ایجاد می‌کند
    Presentation pres = new Presentation();
    try {
        // به اولین اسلاید دسترسی پیدا می‌کند
        ISlide slide = pres.getSlides().get_Item(0);

        // افزودن و دسترسی به Autoshape
        IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

        // دسترسی به فریم متن شکل Autoshape ایجاد شده
        ITextFrame text = aShp.addTextFrame("");

        // حذف پاراگراف پیش‌فرض
        text.getParagraphs().clear();

        // افزودن اولین پاراگراف
        IParagraph para1 = new Paragraph();
        para1.setText("Content");
        para1.getParagraphFormat().getBullet().setType(BulletType.Symbol);
        para1.getParagraphFormat().getBullet().setChar((char)8226);
        para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
        para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
        // تنظیم سطح نقطه‌گذاری
        para1.getParagraphFormat().setDepth((short)0);

        // افزودن پاراگراف دوم
        IParagraph para2 = new Paragraph();
        para2.setText("Second Level");
        para2.getParagraphFormat().getBullet().setType(BulletType.Symbol);
        para2.getParagraphFormat().getBullet().setChar('-');
        para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
        para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
        // تنظیم سطح نقطه‌گذاری
        para2.getParagraphFormat().setDepth((short)1);

        // افزودن پاراگراف سوم
        IParagraph para3 = new Paragraph();
        para3.setText("Third Level");
        para3.getParagraphFormat().getBullet().setType(BulletType.Symbol);
        para3.getParagraphFormat().getBullet().setChar((char)8226);
        para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
        para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
        // تنظیم سطح نقطه‌گذاری
        para3.getParagraphFormat().setDepth((short)2);

        // افزودن پاراگراف چهارم
        IParagraph para4 = new Paragraph();
        para4.setText("Fourth Level");
        para4.getParagraphFormat().getBullet().setType(BulletType.Symbol);
        para4.getParagraphFormat().getBullet().setChar('-');
        para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
        para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
        // تنظیم سطح نقطه‌گذاری
        para4.getParagraphFormat().setDepth((short)3);

        // افزودن پاراگراف‌ها به مجموعه
        text.getParagraphs().add(para1);
        text.getParagraphs().add(para2);
        text.getParagraphs().add(para3);
        text.getParagraphs().add(para4);

        // ذخیره ارائه به عنوان فایل PPTX
        pres.save("MultilevelBullet.pptx", SaveFormat.Pptx);
    } finally {
        if (pres != null) pres.dispose();
    }
```

## **مدیریت پاراگراف با فهرست عددی سفارشی**

رابط [IBulletFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ibulletformat/) ویژگی [NumberedBulletStartWith](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) و دیگر ویژگی‌ها را فراهم می‌کند تا بتوانید پاراگراف‌ها را با شماره‌گذاری یا قالب‌بندی سفارشی مدیریت کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/) ایجاد کنید.
2. به اسلاید حاوی پاراگراف دسترسی پیدا کنید.
3. یک [autoshape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iautoshape/) به اسلاید اضافه کنید.
4. به [TextFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/itextframe/) شکل دسترسی پیدا کنید.
5. پاراگراف پیش‌فرض در `TextFrame` را حذف کنید.
6. اولین پاراگراف را از طریق کلاس [Paragraph](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/paragraph/) ایجاد کنید و [NumberedBulletStartWith](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) را به 2 تنظیم کنید.
7. دومین پاراگراف را از طریق کلاس `Paragraph` ایجاد کنید و `NumberedBulletStartWith` را به 3 تنظیم کنید.
8. سومین پاراگراف را از طریق کلاس `Paragraph` ایجاد کنید و `NumberedBulletStartWith` را به 7 تنظیم کنید.
9. پاراگراف‌های جدید را به مجموعه پاراگراف‌های `TextFrame` اضافه کنید.
10. ارائه اصلاح‌شده را ذخیره کنید.

این کد Java نشان می‌دهد چگونه پاراگراف‌های دارای شماره‌گذاری یا قالب‌بندی سفارشی اضافه و مدیریت کنید:

```java
Presentation presentation = new Presentation();
try {
    IAutoShape shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // به فریم متن شکل autoshape ایجاد شده دسترسی پیدا می‌کند
    ITextFrame textFrame = shape.getTextFrame();

    // پاراگراف پیش‌فرض موجود را حذف می‌کند
    textFrame.getParagraphs().removeAt(0);

    // فهرست اول
    Paragraph paragraph1 = new Paragraph();
    paragraph1.setText("bullet 2");
    paragraph1.getParagraphFormat().setDepth((short)4);
    paragraph1.getParagraphFormat().getBullet().setNumberedBulletStartWith((short)2);
    paragraph1.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    textFrame.getParagraphs().add(paragraph1);

    Paragraph paragraph2 = new Paragraph();
    paragraph2.setText("bullet 3");
    paragraph2.getParagraphFormat().setDepth((short)4);
    paragraph2.getParagraphFormat().getBullet().setNumberedBulletStartWith((short)3);
    paragraph2.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    textFrame.getParagraphs().add(paragraph2);


    Paragraph paragraph5 = new Paragraph();
    paragraph5.setText("bullet 7");
    paragraph5.getParagraphFormat().setDepth((short)4);
    paragraph5.getParagraphFormat().getBullet().setNumberedBulletStartWith((short)7);
    paragraph5.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    textFrame.getParagraphs().add(paragraph5);

    presentation.save("SetCustomBulletsNumber-slides.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **تنظیم تورفتگی خط اول برای پاراگراف**

از متد [IParagraphFormat.setIndent](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) برای کنترل تورفتگی خط اول یک پاراگراف استفاده کنید. این متد فقط خط اول را نسبت به حاشیه چپ پاراگراف جابه‌جا می‌کند. مقدار مثبت خط اول را به سمت راست منتقل می‌کند، در حالی که خطوط باقی‌مانده به متن اصلی چین‌خاست می‌مانند.

از [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) زمانی استفاده کنید که بخواهید کل پاراگراف را جابه‌جا کنید. از [IParagraphFormat.setIndent](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) زمانی استفاده کنید که فقط خط اول را جابه‌جا کنید.

مثال زیر چندین پاراگراف ایجاد می‌کند و مقادیر مختلف تورفتگی را اعمال می‌نماید تا نشان دهد تورفتگی خط اول چطور بر چیدمان پاراگراف اثر می‌گذارد.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/) ایجاد کنید.
2. به اسلاید هدف دسترسی پیدا کنید.
3. یک [AutoShape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/autoshape/) مستطیلی به اسلاید اضافه کنید.
4. یک [TextFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/textframe/) خالی به شکل اضافه کنید و پاراگراف پیش‌فرض را حذف کنید.
5. چندین پاراگراف ایجاد کرده و مقادیر مختلف [Indent](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) را برای آن‌ها تنظیم کنید.
6. پاراگراف‌ها را به فریم متنی اضافه کنید.
7. ارائه اصلاح‌شده را ذخیره کنید.

این کد نشان می‌دهد چگونه تورفتگی پاراگراف را تنظیم کنید:

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape rectangleShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 220);
    rectangleShape.getFillFormat().setFillType(FillType.NoFill);
    rectangleShape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    rectangleShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);

    ITextFrame textFrame = rectangleShape.addTextFrame("");
    textFrame.getTextFrameFormat().setAutofitType(TextAutofitType.Shape);
    textFrame.getParagraphs().removeAt(0);

    Paragraph firstParagraph = new Paragraph();
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    firstParagraph.setText("No first-line indent. Wrapped lines start at the same position as the first line.");
    firstParagraph.getParagraphFormat().setMarginLeft(20f);
    firstParagraph.getParagraphFormat().setIndent(0f);

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    secondParagraph.setText("First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.");
    secondParagraph.getParagraphFormat().setMarginLeft(20f);
    secondParagraph.getParagraphFormat().setIndent(20f);

    Paragraph thirdParagraph = new Paragraph();
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    thirdParagraph.setText("First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.");
    thirdParagraph.getParagraphFormat().setMarginLeft(20f);
    thirdParagraph.getParagraphFormat().setIndent(40f);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);
    textFrame.getParagraphs().add(thirdParagraph);

    presentation.save("paragraph_indent.pptx", SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

نتیجه:

![تورفتگی خط اول پاراگراف‌ها](first_line_indent.png)

## **تنظیم تورفتگی معلق برای پاراگراف**

تورفتگی معلق همان چیدمان پاراگرافی است که در آن خط اول به سمت چپ خطوط بعدی شروع می‌شود. در Aspose.Slides می‌توانید این اثر را با متد [IParagraphFormat.setIndent](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) ایجاد کنید. مقدار منفی به‌کار بگیرید تا خط اول نسبت به بدنه پاراگراف به سمت چپ حرکت کند.

در عمل، [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) موقعیت چپ بدنه پاراگراف را تعریف می‌کند و [IParagraphFormat.setIndent](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) موقعیت خط اول را نسبت به آن حاشیه تعیین می‌کند. برای ایجاد تورفتگی معلق، مقدار مثبت `MarginLeft` و مقدار منفی `Indent` را تنظیم کنید.

این قالب‌بندی برای کتابشناسی‌ها، مراجع، ورودی‌های واژه‌نامه و سایر پاراگراف‌هایی که خطوط پیچیده باید زیر بدنه پاراگراف نه زیر اولین کاراکتر خط اول قرار گیرند، مفید است.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/) ایجاد کنید.
2. به اسلاید هدف دسترسی پیدا کنید.
3. یک [AutoShape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/autoshape/) مستطیلی به اسلاید اضافه کنید.
4. یک [TextFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/textframe/) خالی به شکل اضافه کنید و پاراگراف پیش‌فرض را حذف کنید.
5. برای هر پاراگراف مقدار مثبت [MarginLeft](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) تنظیم کنید.
6. مقدار منفی [Indent](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) برای ایجاد اثر تورفتگی معلق تنظیم کنید.
7. پاراگراف‌ها را به فریم متنی اضافه کنید.
8. ارائه اصلاح‌شده را ذخیره کنید.

این کد نشان می‌دهد چگونه تورفتگی معلق برای پاراگراف تنظیم کنید:

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape rectangleShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 220);
    rectangleShape.getFillFormat().setFillType(FillType.NoFill);
    rectangleShape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    rectangleShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);

    ITextFrame textFrame = rectangleShape.addTextFrame("");
    textFrame.getTextFrameFormat().setAutofitType(TextAutofitType.Shape);
    textFrame.getParagraphs().removeAt(0);

    Paragraph firstParagraph = new Paragraph();
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    firstParagraph.setText("A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.");
    firstParagraph.getParagraphFormat().setMarginLeft(40f);
    firstParagraph.getParagraphFormat().setIndent(-20f);

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    secondParagraph.setText("This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.");
    secondParagraph.getParagraphFormat().setMarginLeft(60f);
    secondParagraph.getParagraphFormat().setIndent(-30f);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);

    presentation.save("hanging_indent.pptx", SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

نتیجه:

![تورفتگی معلق پاراگراف‌ها](hanging_indent.png)

## **مدیریت ویژگی‌های End برای پاراگراف**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/) ایجاد کنید.
1. مرجع اسلاید حاوی پاراگراف را از طریق موقعیت آن دریافت کنید.
1. یک [autoshape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iautoshape/) مستطیلی به اسلاید اضافه کنید.
1. یک [TextFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/itextframe/) با دو پاراگراف به مستطیل اضافه کنید.
1. `FontHeight` و نوع فونت را برای پاراگراف‌ها تنظیم کنید.
1. ویژگی‌های End را برای پاراگراف‌ها تنظیم کنید.
1. ارائه اصلاح‌شده را به‌صورت فایل PPTX ذخیره کنید.

این کد Java نشان می‌دهد چگونه ویژگی‌های End را برای پاراگراف‌ها در PowerPoint تنظیم کنید:

```java
Presentation pres = new Presentation();
try {
    IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 200, 250);

    Paragraph para1 = new Paragraph();
    para1.getPortions().add(new Portion("Sample text"));

    Paragraph para2 = new Paragraph();
    para2.getPortions().add(new Portion("Sample text 2"));

    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(48);
    portionFormat.setLatinFont(new FontData("Times New Roman"));
    para2.setEndParagraphPortionFormat(portionFormat);

    shape.getTextFrame().getParagraphs().add(para1);
    shape.getTextFrame().getParagraphs().add(para2);

    pres.save(resourcesOutputPath+"pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **وارد کردن متن HTML به پاراگراف‌ها**

Aspose.Slides پشتیبانی پیشرفته‌ای برای وارد کردن متن HTML به پاراگراف‌ها فراهم می‌کند.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/) ایجاد کنید.
2. از طریق اندیس، به اسلاید مربوطه دسترسی پیدا کنید.
3. یک [autoshape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iautoshape/) به اسلاید اضافه کنید.
4. `autoshape` را با [ITextFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/itextframe/) دریافت و دسترسی پیدا کنید.
5. پاراگراف پیش‌فرض در `ITextFrame` را حذف کنید.
6. فایل HTML منبع را با یک TextReader بخوانید.
7. اولین پاراگراف را از طریق کلاس [Paragraph](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/paragraph/) ایجاد کنید.
8. محتوای فایل HTML خوانده شده را به [ParagraphCollection](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/paragraphcollection/) فریم متنی اضافه کنید.
9. ارائه اصلاح‌شده را ذخیره کنید.

این کد Java پیاده‌سازی مراحل وارد کردن متن‌های HTML در پاراگراف‌ها است:

```java
// یک نمونه خالی از ارائه (Presentation) ایجاد می‌کند
Presentation pres = new Presentation();
try {
    // به اسلاید پیش‌فرض اول ارائه دسترسی پیدا می‌کند
    ISlide slide = pres.getSlides().get_Item(0);

    // اضافه کردن AutoShape برای جایگذاری محتوای HTML
    IAutoShape ashape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10,
            (float)pres.getSlideSize().getSize().getWidth() - 20, (float)pres.getSlideSize().getSize().getHeight() - 10);

    ashape.getFillFormat().setFillType(FillType.NoFill);

    // اضافه کردن فریم متن به شکل
    ashape.addTextFrame("");

    // پاک کردن تمام پاراگراف‌ها در فریم متن اضافه‌شده
    ashape.getTextFrame().getParagraphs().clear();

    // بارگذاری فایل HTML با استفاده از StreamReader
    TextReader tr = new StreamReader("file.html");

    // اضافه کردن متن از StreamReader HTML به فریم متن
    ashape.getTextFrame().getParagraphs().addFromHtml(tr.readToEnd());

    // ذخیرهٔ ارائه
    pres.save("output_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **صدور متن پاراگراف به HTML**

Aspose.Slides پشتیبانی پیشرفته‌ای برای صدور متن‌ها (موجود در پاراگراف‌ها) به HTML فراهم می‌کند.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/) ایجاد کنید و ارائه موردنظر را بارگذاری کنید.
2. از طریق اندیس، به اسلاید مربوطه دسترسی پیدا کنید.
3. به شیء شامل متنی که باید به HTML صادر شود، دسترسی پیدا کنید.
4. به [TextFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/textframe/) شکل دسترسی پیدا کنید.
5. یک نمونه از `StreamWriter` ایجاد کنید و فایل HTML جدید را اضافه کنید.
6. یک اندیس شروع به `StreamWriter` بدهید و پاراگراف‌های دلخواه خود را صادر کنید.

این کد Java نشان می‌دهد چگونه متن‌های پاراگراف PowerPoint را به HTML صادر کنید:

```java
// فایل ارائه را بارگذاری می‌کند
Presentation pres = new Presentation("ExportingHTMLText.pptx");
try {
    // به اسلاید پیش‌فرض اول ارائه دسترسی پیدا می‌کند
    ISlide slide = pres.getSlides().get_Item(0);

    // اندیس موردنظر
    int index = 0;

    // دسترسی به شکل اضافه‌شده
    IAutoShape ashape = (IAutoShape) slide.getShapes().get_Item(index);

    // ایجاد فایل خروجی HTML
    OutputStream os = new FileOutputStream("output.html");
    Writer writer = new OutputStreamWriter(os, "UTF-8");

    //استخراج اولین پاراگراف به صورت HTML
    // نوشتن داده‌های پاراگراف‌ها به HTML با ارائه اندیس شروع پاراگراف و تعداد کل پاراگراف‌های کپی‌شده
    writer.write(ashape.getTextFrame().getParagraphs().exportToHtml(0, ashape.getTextFrame().getParagraphs().getCount(), null));
    writer.close();
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **ذخیره یک پاراگراف به‌صورت تصویر**

در این بخش دو مثال بررسی می‌شود که نشان می‌دهد چگونه یک پاراگراف متنی، نمایانگر توسط رابط [IParagraph](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iparagraph/)، به‌صورت تصویر ذخیره شود. هر دو مثال شامل دریافت تصویر یک شکل حاوی پاراگراف با استفاده از متدهای `getImage` از رابط [IShape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ishape/) ، محاسبه مرزهای پاراگراف داخل شکل و استخراج آن به‌صورت تصویر Bitmap می‌باشند. این روش‌ها به شما امکان می‌دهند بخش‌های خاصی از متن را از ارائه‌های PowerPoint استخراج و به‌صورت تصاویر جداگانه ذخیره کنید که می‌تواند در سناریوهای مختلف مفید باشد.

فرض کنیم فایلی به نام sample.pptx داریم که شامل یک اسلاید است و اولین شکل آن یک جعبه متنی شامل سه پاراگراف می‌باشد.

![جعبه متن حاوی سه پاراگراف](paragraph_to_image_input.png)

**مثال 1**

در این مثال، پاراگراف دوم به‌صورت تصویر استخراج می‌شود. برای این کار، تصویر شکل از اسلاید اول استخراج می‌شود، سپس مرزهای پاراگراف دوم در فریم متنی شکل محاسبه می‌شود. سپس پاراگراف روی یک تصویر Bitmap جدید رسم می‌شود و به‌صورت PNG ذخیره می‌شود. این روش به‌ویژه وقتی مفید است که بخواهید یک پاراگراف خاص را به‌عنوان تصویر جداگانه ذخیره کنید در حالی که ابعاد و قالب‌بندی دقیق متن حفظ می‌شود.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape firstShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // شکل را در حافظه به صورت بیت‌مپ ذخیره می‌کند.
    IImage shapeImage = firstShape.getImage();
    ByteArrayOutputStream shapeImageStream = new ByteArrayOutputStream();
    shapeImage.save(shapeImageStream, ImageFormat.Png);
    shapeImage.dispose();

    // یک بیت‌مپ شکل را از حافظه ایجاد می‌کند.
    InputStream shapeImageInputStream = new ByteArrayInputStream(shapeImageStream.toByteArray());
    BufferedImage shapeBitmap = ImageIO.read(shapeImageInputStream);

    // مرزهای پاراگراف دوم را محاسبه می‌کند.
    IParagraph secondParagraph = firstShape.getTextFrame().getParagraphs().get_Item(1);
    RectF paragraphRectangle = secondParagraph.getRect();

    // مختصات و اندازه تصویر خروجی را محاسبه می‌کند (حداقل اندازه - ۱x۱ پیکسل).
    int imageX = (int) Math.floor(paragraphRectangle.left);
    int imageY = (int) Math.floor(paragraphRectangle.top);
    int imageWidth = Math.max(1, (int) Math.ceil(paragraphRectangle.width()));
    int imageHeight = Math.max(1, (int) Math.ceil(paragraphRectangle.height()));

    // بیت‌مپ شکل را برش می‌دهد تا فقط بیت‌مپ پاراگراف به دست آید.
    BufferedImage paragraphBitmap = shapeBitmap.getSubimage(imageX, imageY, imageWidth, imageHeight);

    ImageIO.write(paragraphBitmap, "png", new File("paragraph.png"));
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

نتیجه:

![تصویر پاراگراف](paragraph_to_image_output.png)

**مثال 2**

در این مثال، رویکرد قبلی با افزودن عوامل مقیاس به تصویر پاراگرف گسترش می‌یابد. شکل از ارائه استخراج می‌شود و به‌صورت تصویر با عامل مقیاس `2` ذخیره می‌شود. این امکان خروجی با رزولوشن بالاتر را هنگام صدور پاراگراف فراهم می‌کند. سپس مرزهای پاراگراف با در نظر گرفتن مقیاس محاسبه می‌شود. مقیاس‌گذاری می‌تواند وقتی که تصویر با جزئیات بیشتر نیاز باشد، مثلاً برای استفاده در مواد چاپی با کیفیت بالا، مفید باشد.

```java
float imageScaleX = 2f;
float imageScaleY = imageScaleX;

Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape firstShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // شکل را در حافظه به عنوان بیت‌مپ با مقیاس ذخیره می‌کند.
    IImage shapeImage = firstShape.getImage(ShapeThumbnailBounds.Shape, imageScaleX, imageScaleY);
    ByteArrayOutputStream shapeImageStream = new ByteArrayOutputStream();
    shapeImage.save(shapeImageStream, ImageFormat.Png);
    shapeImage.dispose();

    // یک بیت‌مپ شکل را از حافظه ایجاد می‌کند.
    InputStream shapeImageInputStream = new ByteArrayInputStream(shapeImageStream.toByteArray());
    BufferedImage shapeBitmap = ImageIO.read(shapeImageInputStream);

    // مرزهای پاراگراف دوم را محاسبه می‌کند.
    IParagraph secondParagraph = firstShape.getTextFrame().getParagraphs().get_Item(1);
    RectF paragraphRectangle = secondParagraph.getRect();
    paragraphRectangle.set(
            paragraphRectangle.left * imageScaleX,
            paragraphRectangle.top * imageScaleY,
            paragraphRectangle.right * imageScaleX,
            paragraphRectangle.bottom * imageScaleY
    );

    // مختصات و اندازه تصویر خروجی را محاسبه می‌کند (حداقل اندازه - ۱x۱ پیکسل).
    int imageX = (int) Math.floor(paragraphRectangle.left);
    int imageY = (int) Math.floor(paragraphRectangle.top);
    int imageWidth = Math.max(1, (int) Math.ceil(paragraphRectangle.width()));
    int imageHeight = Math.max(1, (int) Math.ceil(paragraphRectangle.height()));

    // بیت‌مپ شکل را برش می‌دهد تا فقط بیت‌مپ پاراگراف به دست آید.
    BufferedImage paragraphBitmap = shapeBitmap.getSubimage(imageX, imageY, imageWidth, imageHeight);

    ImageIO.write(paragraphBitmap, "png", new File("paragraph.png"));
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **سوالات متداول**

**آیا می‌توانم بسته‌بندی خطوط داخل یک فریم متنی را به‌طور کامل غیرفعال کنم؟**

بله. از تنظیمات بسته‌بندی فریم متنی ([setWrapText](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/textframeformat/#setWrapText-byte-)) استفاده کنید تا بسته‌بندی را خاموش کنید و خطوط در لبه‌های فریم قطع نشوند.

**چگونه می‌توانم محدوده دقیق روی اسلاید یک پاراگراف خاص را به‌دست آورم؟**

می‌توانید مستطیل محاطی پاراگراف (و حتی یک بخش منفرد) را دریافت کنید تا موقعیت و اندازه دقیق آن را روی اسلاید بشناسید.

**کنترل تراز پاراگراف (چپ/راست/وسط/توزیع) در کجا انجام می‌شود؟**

[Alignment](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/paragraphformat/#setAlignment-int-) تنظیمی در سطح پاراگراف در [ParagraphFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/paragraphformat/) است؛ این تنظیم برای تمام پاراگراف اعمال می‌شود بدون در نظر گرفتن قالب‌بندی بخش‌های جداگانه.

**آیا می‌توانم زبان بررسی املایی را فقط برای بخشی از یک پاراگراف (مثلاً یک کلمه) تنظیم کنم؟**

بله. زبان در سطح بخش تنظیم می‌شود ([PortionFormat.setLanguageId](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-))، بنابراین می‌توانید چندین زبان را در یک پاراگراف همزمان داشته باشید.