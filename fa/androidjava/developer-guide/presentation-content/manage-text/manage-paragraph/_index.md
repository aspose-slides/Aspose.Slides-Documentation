---
title: مدیریت پاراگراف‌های متن PowerPoint در Android
linktitle: مدیریت پاراگراف
type: docs
weight: 40
url: /fa/androidjava/manage-paragraph/
aliases:
  - /androidjava/paragraph/
keywords:
- افزودن متن
- افزودن پاراگراف
- مدیریت متن
- مدیریت پاراگراف
- مدیریت گلوله
- تورفتگی پاراگراف
- تورفتگی آویزان
- گلوله پاراگراف
- فهرست شماره‌دار
- فهرست گلوله‌ای
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
description: "قالب‌بندی پیشرفته پاراگراف‌ها با Aspose.Slides برای Android—بهینه‌سازی تراز، فاصله‌ها و سبک در ارائه‌های PPT، PPTX و ODP با Java."
---
## **مقدمه**

Aspose.Slides تمام رابط‌ها و کلاس‌های مورد نیاز برای کار با متن‌های PowerPoint، پاراگراف‌ها و بخش‌ها در Java را فراهم می‌کند.

* Aspose.Slides رابط [ITextFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/itextframe/) را فراهم می‌کند تا بتوانید اشیائی که نمایانگر یک پاراگراف هستند را اضافه کنید. یک شیء `ITextFame` می‌تواند یک یا چند پاراگراف داشته باشد (هر پاراگراف از طریق یک بازگشت carriage ایجاد می‌شود).
* Aspose.Slides رابط [IParagraph](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iparagraph/) را فراهم می‌کند تا بتوانید اشیائی که نمایانگر بخش‌ها هستند را اضافه کنید. یک شیء `IParagraph` می‌تواند یک یا چند بخش (مجموعه‌ای از اشیاء iPortions) داشته باشد.
* Aspose.Slides رابط [IPortion](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iportion/) را فراهم می‌کند تا بتوانید اشیائی که نمایانگر متن‌ها و ویژگی‌های قالب‌بندی آن‌ها هستند را اضافه کنید.

یک شیء `IParagraph` می‌تواند متون با ویژگی‌های قالب‌بندی مختلف را از طریق اشیاء پایه‌ای `IPortion` خود مدیریت کند.

## **افزودن چند پاراگراف حاوی چندین بخش متن**

این مراحل نشان می‌دهد چگونه یک فریم متن حاوی ۳ پاراگراف و هر پاراگراف حاوی ۳ بخش اضافه کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/) ایجاد کنید.
2. مرجع اسلاید مورد نظر را از طریق ایندکس آن دسترسی پیدا کنید.
3. یک شکل مستطیل [IAutoShape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iautoshape/) به اسلاید اضافه کنید.
4. `ITextFrame` مرتبط با [IAutoShape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iautoshape/) را دریافت کنید.
5. دو شیء [IParagraph](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iparagraph/) ایجاد کنید و آنها را به مجموعه `IParagraphs` مربوط به [ITextFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/itextframe/) اضافه کنید.
6. برای هر `IParagraph` جدید سه شیء [IPortion](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iportion/) (دو شیء Portion برای پاراگراف پیش‌فرض) ایجاد کنید و هر شیء `IPortion` را به مجموعه IPortion آن `IParagraph` اضافه کنید.
7. برای هر بخش متنی تعیین کنید.
8. ویژگی‌های قالب‌بندی دلخواه خود را به هر بخش با استفاده از ویژگی‌های قالب‌بندی موجود در شیء `IPortion` اعمال کنید.
9. ارائه‌ (presentation) تغییر یافته را ذخیره کنید.

این کد Java اجرای این مراحل برای افزودن پاراگراف‌های حاوی بخش‌ها است:

```java
// یک شیء از کلاس Presentation ایجاد کنید که نمایانگر یک فایل PPTX است
Presentation pres = new Presentation();
try {
    // دسترسی به اسلاید اول
    ISlide slide = pres.getSlides().get_Item(0);

    // یک AutoShape از نوع مستطیل اضافه کنید
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 300, 150);

    // دسترسی به TextFrame خود AutoShape
    ITextFrame tf = ashp.getTextFrame();

    // پاراگراف‌ها و بخش‌ها را با قالب‌های متنی مختلف ایجاد کنید
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

    // نوشتن فایل PPTX بر روی دیسک
    pres.save("multiParaPort_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **مدیریت گلوله‌های پاراگراف**

لیست‌های گلوله‌ای به شما کمک می‌کنند تا اطلاعات را به سرعت و به‌صورت کارآمد سازماندهی و ارائه دهید. پاراگراف‌های دارای گلوله همیشه خواناتر و قابل درک‌تر هستند.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/) ایجاد کنید.
2. مرجع اسلاید مورد نظر را از طریق ایندکس آن دسترسی پیدا کنید.
3. یک [autoshape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iautoshape/) به اسلاید انتخاب‌شده اضافه کنید.
4. به [TextFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/itextframe/) آن autoshape دسترسی پیدا کنید.
5. پاراگراف پیش‌فرض در `TextFrame` را حذف کنید.
6. اولین نمونه پاراگراف را با استفاده از کلاس [Paragraph](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/paragraph/) ایجاد کنید.
7. ویژگی `Type` گلوله را برای پاراگراف به `Symbol` تنظیم کنید و کاراکتر گلوله را مشخص کنید.
8. متن پاراگراف را تنظیم کنید.
9. مقدار `Indent` پاراگراف را برای گلوله تنظیم کنید.
10. رنگی برای گلوله تعیین کنید.
11. ارتفاع گلوله را تنظیم کنید.
12. پاراگراف جدید را به مجموعه پاراگراف‌های `TextFrame` اضافه کنید.
13. پاراگراف دوم را اضافه کنید و فرآیند مراحل ۷ تا ۱۳ را تکرار کنید.
14. ارائه را ذخیره کنید.

این کد Java نشان می‌دهد چگونه یک گلوله پاراگرافی اضافه کنید:

```java
// یک شیء از کلاس Presentation ایجاد می‌کند که نمایانگر یک فایل PPTX است
Presentation pres = new Presentation();
try {
    // دسترسی به اسلاید اول
    ISlide slide = pres.getSlides().get_Item(0);
    
    //    اضافه می‌کند و به Autoshape دسترسی می‌یابد
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // دسترسی به فریم متن Autoshape
    ITextFrame txtFrm = aShp.getTextFrame();

    // حذف پاراگراف پیش‌فرض
    txtFrm.getParagraphs().removeAt(0);

    // ایجاد یک پاراگر
    Paragraph para = new Paragraph();

    // تنظیم سبک گلوله پاراگراف و نماد
    para.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para.getParagraphFormat().getBullet().setChar((char)8226);

    // تنظیم متن پاراگراف
    para.setText("Welcome to Aspose.Slides");

    // تنظیم تورفتگی گلوله
    para.getParagraphFormat().setIndent(25);

    // تنظیم رنگ گلوله
    para.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    para.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    para.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True); // تنظیم IsBulletHardColor به true برای استفاده از رنگ گلوله سفارشی

    // تنظیم ارتفاع گلوله
    para.getParagraphFormat().getBullet().setHeight(100);

    // افزودن پاراگراف به فریم متن
    txtFrm.getParagraphs().add(para);

    // ایجاد پاراگراف دوم
    Paragraph para2 = new Paragraph();

    // تنظیم نوع و سبک گلوله پاراگراف
    para2.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    para2.getParagraphFormat().getBullet().setNumberedBulletStyle(NumberedBulletStyle.BulletCircleNumWDBlackPlain);

    // افزودن متن به پاراگراف
    para2.setText("This is numbered bullet");

    // تنظیم تورفتگی گلوله
    para2.getParagraphFormat().setIndent(25);

    para2.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    para2.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    para2.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True); // تنظیم IsBulletHardColor به true برای استفاده از رنگ گلوله سفارشی

    // تنظیم ارتفاع گلوله
    para2.getParagraphFormat().getBullet().setHeight(100);

    // افزودن پاراگراف به فریم متن
    txtFrm.getParagraphs().add(para2);
    
    // ذخیره ارائه تغییر یافته
    pres.save("Bullet_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **مدیریت گلوله‌های تصویری**

لیست‌های گلوله‌ای به شما کمک می‌کنند تا اطلاعات را به سرعت و به‌صورت کارآمد سازماندهی و ارائه دهید. پاراگراف‌های تصویری نیز به همان شکل خوانا هستند.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/) ایجاد کنید.
2. مرجع اسلاید مورد نظر را از طریق ایندکس آن دسترسی پیدا کنید.
3. یک [autoshape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iautoshape/) به اسلاید اضافه کنید.
4. به [TextFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/itextframe/) آن autoshape دسترسی پیدا کنید.
5. پاراگراف پیش‌فرض در `TextFrame` را حذف کنید.
6. اولین نمونه پاراگراف را با استفاده از کلاس [Paragraph](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/paragraph/) ایجاد کنید.
7. تصویر را در [IPPImage](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ippimage/) بارگذاری کنید.
8. نوع گلوله را به [Picture](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ippimage/) تنظیم کنید و تصویر را تعیین کنید.
9. متن پاراگراف را تنظیم کنید.
10. مقدار `Indent` پاراگراف را برای گلوله تنظیم کنید.
11. رنگی برای گلوله تعیین کنید.
12. ارتفاع گلوله را تنظیم کنید.
13. پاراگراف جدید را به مجموعه پاراگراف‌های `TextFrame` اضافه کنید.
14. پاراگراف دوم را اضافه کنید و فرآیند قبلی را تکرار کنید.
15. ارائه تغییر یافته را ذخیره کنید.

این کد Java نشان می‌دهد چگونه گلوله‌های تصویری را اضافه و مدیریت کنید:

```java
// یک شیء از کلاس Presentation ایجاد می‌کند که نمایانگر یک فایل PPTX است
Presentation presentation = new Presentation();
try {
    // دسترسی به اسلاید اول
    ISlide slide = presentation.getSlides().get_Item(0);

    // یک تصویر برای گلوله‌ها ایجاد می‌کند
    IPPImage picture;
    IImage image = Images.fromFile("bullets.png");
    try {
        picture = presentation.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }
    // اضافه می‌کند و به Autoshape دسترسی می‌یابد
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // دسترسی به فریم متن autoshape
    ITextFrame textFrame = autoShape.getTextFrame();

    // حذف پاراگراف پیش‌فرض
    textFrame.getParagraphs().removeAt(0);

    // یک پاراگراف جدید ایجاد می‌کند
    Paragraph paragraph = new Paragraph();
    paragraph.setText("Welcome to Aspose.Slides");

    // تنظیم سبک گلوله پاراگراف و تصویر
    paragraph.getParagraphFormat().getBullet().setType(BulletType.Picture);
    paragraph.getParagraphFormat().getBullet().getPicture().setImage(picture);

    // تنظیم ارتفاع گلوله
    paragraph.getParagraphFormat().getBullet().setHeight(100);

    // افزودن پاراگراف به فریم متن
    textFrame.getParagraphs().add(paragraph);

    // نوشتن ارائه به عنوان یک فایل PPTX
    presentation.save("ParagraphPictureBulletsPPTX_out.pptx", SaveFormat.Pptx);

    // نوشتن ارائه به عنوان یک فایل PPT
    presentation.save("ParagraphPictureBulletsPPT_out.ppt", SaveFormat.Ppt);
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **مدیریت گلوله‌های چندسطحی**

لیست‌های گلوله‌ای به شما کمک می‌کنند تا اطلاعات را به سرعت و به‌صورت کارآمد سازماندهی و ارائه دهید. گلوله‌های چندسطحی به راحتی قابل خواندن هستند.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/) ایجاد کنید.
2. مرجع اسلاید مورد نظر را از طریق ایندکس آن دسترسی پیدا کنید.
3. یک [autoshape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iautoshape/) در اسلاید جدید اضافه کنید.
4. به [TextFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/itextframe/) آن autoshape دسترسی پیدا کنید.
5. پاراگراف پیش‌فرض در `TextFrame` را حذف کنید.
6. اولین پاراگراف را از طریق کلاس [Paragraph](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/paragraph/) ایجاد کنید و عمق را به ۰ تنظیم کنید.
7. دومین پاراگراف را از طریق کلاس `Paragraph` ایجاد کنید و عمق را به ۱ تنظیم کنید.
8. سومین پاراگراف را از طریق کلاس `Paragraph` ایجاد کنید و عمق را به ۲ تنظیم کنید.
9. چهارمین پاراگراف را از طریق کلاس `Paragraph` ایجاد کنید و عمق را به ۳ تنظیم کنید.
10. پاراگراف‌های جدید را به مجموعه پاراگراف‌های `TextFrame` اضافه کنید.
11. ارائه تغییر یافته را ذخیره کنید.

این کد Java نشان می‌دهد چگونه گلوله‌های چندسطحی را اضافه و مدیریت کنید:

```java
// یک شیء از کلاس Presentation ایجاد می‌کند که نمایانگر یک فایل PPTX است
Presentation pres = new Presentation();
try {
    // دسترسی به اسلاید اول
    ISlide slide = pres.getSlides().get_Item(0);

    // اضافه می‌کند و به Autoshape دسترسی می‌یابد
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // دسترسی به فریم متن autoshape ایجاد‌شده
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
    // تنظیم سطح گلوله
    para1.getParagraphFormat().setDepth((short)0);

    // افزودن پاراگراف دوم
    IParagraph para2 = new Paragraph();
    para2.setText("Second Level");
    para2.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para2.getParagraphFormat().getBullet().setChar('-');
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // تنظیم سطح گلوله
    para2.getParagraphFormat().setDepth((short)1);

    // افزودن پاراگراف سوم
    IParagraph para3 = new Paragraph();
    para3.setText("Third Level");
    para3.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para3.getParagraphFormat().getBullet().setChar((char)8226);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // تنظیم سطح گلوله
    para3.getParagraphFormat().setDepth((short)2);

    // افزودن پاراگراف چهارم
    IParagraph para4 = new Paragraph();
    para4.setText("Fourth Level");
    para4.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para4.getParagraphFormat().getBullet().setChar('-');
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // تنظیم سطح گلوله
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

## **مدیریت پاراگراف با فهرست شماره‌دار سفارشی**

رابط [IBulletFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ibulletformat/) ویژگی [NumberedBulletStartWith](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) و دیگر گزینه‌ها را فراهم می‌کند تا بتوانید پاراگراف‌های دارای شماره‌گذاری یا قالب‌بندی سفارشی را مدیریت کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/) ایجاد کنید.
2. اسلاید حاوی پاراگراف را دسترسی پیدا کنید.
3. یک [autoshape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iautoshape/) به اسلاید اضافه کنید.
4. به [TextFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/itextframe/) آن autoshape دسترسی پیدا کنید.
5. پاراگراف پیش‌فرض در `TextFrame` را حذف کنید.
6. اولین پاراگراف را از طریق کلاس [Paragraph](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/paragraph/) ایجاد کنید و [NumberedBulletStartWith](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) را به ۲ تنظیم کنید.
7. دومین پاراگراف را از طریق کلاس `Paragraph` ایجاد کنید و `NumberedBulletStartWith` را به ۳ تنظیم کنید.
8. سومین پاراگراف را از طریق کلاس `Paragraph` ایجاد کنید و `NumberedBulletStartWith` را به ۷ تنظیم کنید.
9. پاراگراف‌های جدید را به مجموعه پاراگراف‌های `TextFrame` اضافه کنید.
10. ارائه تغییر یافته را ذخیره کنید.

این کد Java نشان می‌دهد چگونه پاراگراف‌های دارای شماره‌گذاری یا قالب‌بندی سفارشی را اضافه و مدیریت کنید:

```java
Presentation presentation = new Presentation();
try {
    IAutoShape shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // دسترسی به فریم متن autoshape ایجاد شده
    ITextFrame textFrame = shape.getTextFrame();

    // حذف پاراگراف پیش‌فرض موجود
    textFrame.getParagraphs().removeAt(0);

    // لیست اول
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

## **تنظیم تورفتگی خط اول برای یک پاراگراف**

از روش [IParagraphFormat.setIndent](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) برای کنترل تورفتگی خط اول یک پاراگراف استفاده کنید. این متد تنها خط اول را نسبت به حاشیه‌ چپ پاراگراف جابه‌جا می‌کند. مقدار مثبت خط اول را به سمت راست می‌برد، در حالی که بقیه خطوط در جای خود باقی می‌مانند.

از [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) زمانی استفاده کنید که بخواهید کل پاراگراف را جابه‌جا کنید. از [IParagraphFormat.setIndent](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) زمانی استفاده کنید که فقط خط اول را جابه‌جا کنید.

مثال زیر چند پاراگراف ایجاد می‌کند و مقادیر متفاوتی برای تورفتگی خط اول تنظیم می‌کند تا نشان دهد این ویژگی چطور بر چیدمان پاراگراف‌ها تأثیر می‌گذارد.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/) ایجاد کنید.
2. اسلاید هدف را دسترسی پیدا کنید.
3. یک [AutoShape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/autoshape/) مستطیلی به اسلاید اضافه کنید.
4. یک [TextFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/textframe/) خالی به شکل اضافه کنید و پاراگراف پیش‌فرض را حذف کنید.
5. چند پاراگراف ایجاد کنید و مقادیر متفاوتی برای [Indent](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) برای هر یک تنظیم کنید.
6. پاراگراف‌ها را به فریم متن اضافه کنید.
7. ارائه تغییر یافته را ذخیره کنید.

این کد نشان می‌دهد چگونه تورفتگی یک پاراگراف تنظیم شود:

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

## **تنظیم تورفتگی آویزان برای یک پاراگراف**

تورفتگی آویزان، چیدمان پاراگرافی است که در آن خط اول به سمت چپ خطوط باقی مانده شروع می‌شود. در Aspose.Slides این اثر را با متد [IParagraphFormat.setIndent](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) ایجاد می‌کنید. مقدار منفی برای تورفتگی تنظیم کنید تا خط اول نسبت به بدنه پاراگراف به سمت چپ جابه‌جا شود.

در عمل، [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) موقعیت چپ بدنه پاراگراف را تعریف می‌کند و [IParagraphFormat.setIndent](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) موقعیت خط اول را نسبت به آن حاشیه تعیین می‌کند. برای ایجاد تورفتگی آویزان، مقدار مثبت `MarginLeft` و مقدار منفی `Indent` تنظیم کنید.

این قالب‌بندی برای کتاب‌شناسی‌ها، مراجع، واژگان و سایر پاراگراف‌هایی که خطوط بسته شدن باید زیر بدنه پاراگراف قرار گیرند نه زیر اولین کاراکتر خط اول، مفید است.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/) ایجاد کنید.
2. اسلاید هدف را دسترسی پیدا کنید.
3. یک [AutoShape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/autoshape/) مستطیلی به اسلاید اضافه کنید.
4. یک [TextFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/textframe/) خالی به شکل اضافه کنید و پاراگراف پیش‌فرض را حذف کنید.
5. برای هر پاراگراف مقدار مثبت [MarginLeft](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) تنظیم کنید.
6. مقدار منفی [Indent](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) تنظیم کنید تا اثر تورفتگی آویزان ایجاد شود.
7. پاراگراف‌ها را به فریم متن اضافه کنید.
8. ارائه تغییر یافته را ذخیره کنید.

این کد نشان می‌دهد چگونه تورفتگی آویزان برای یک پاراگراف تنظیم شود:

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

![تورفتگی آویزان پاراگراف‌ها](hanging_indent.png)

## **مدیریت ویژگی‌های End برای پاراگراف**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/) ایجاد کنید.
1. مرجع اسلاید حاوی پاراگراف را از طریق موقعیت آن دریافت کنید.
1. یک [autoshape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iautoshape/) مستطیلی به اسلاید اضافه کنید.
1. یک [TextFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/itextframe/) با دو پاراگراف به مستطیل اضافه کنید.
1. `FontHeight` و نوع فونت را برای پاراگراف‌ها تنظیم کنید.
1. ویژگی‌های End را برای پاراگراف‌ها تنظیم کنید.
1. ارائه تغییر یافته را به عنوان فایل PPTX بنویسید.

این کد Java نشان می‌دهد چگونه ویژگی‌های End برای پاراگراف‌ها در PowerPoint تنظیم شود:

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
2. مرجع اسلاید مربوطه را از طریق ایندکس آن دسترسی پیدا کنید.
3. یک [autoshape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iautoshape/) به اسلاید اضافه کنید.
4. `autoshape` را به [ITextFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/itextframe/) متصل کنید و دسترسی پیدا کنید.
5. پاراگراف پیش‌فرض در `ITextFrame` را حذف کنید.
6. فایل HTML منبع را در یک TextReader بخوانید.
7. اولین پاراگراف را از طریق کلاس [Paragraph](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/paragraph/) ایجاد کنید.
8. محتوای فایل HTML را از TextReader خوانده شده به [ParagraphCollection](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/paragraphcollection/) فریم متن اضافه کنید.
9. ارائه تغییر یافته را ذخیره کنید.

این کد Java پیاده‌سازی مراحل وارد کردن متون HTML در پاراگراف‌ها است:

```java
// ایجاد یک نمونه خالی از ارائه
Presentation pres = new Presentation();
try {
    // دسترسی به اسلاید پیش‌فرض اول ارائه
    ISlide slide = pres.getSlides().get_Item(0);

    // اضافه‌کردن AutoShape برای قرار دادن محتوای HTML
    IAutoShape ashape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10,
            (float)pres.getSlideSize().getSize().getWidth() - 20, (float)pres.getSlideSize().getSize().getHeight() - 10);

    ashape.getFillFormat().setFillType(FillType.NoFill);

    // اضافه‌کردن فریم متن به شکل
    ashape.addTextFrame("");

    // پاک‌سازی تمام پاراگراف‌ها در فریم متن اضافه شده
    ashape.getTextFrame().getParagraphs().clear();

    // بارگذاری فایل HTML با استفاده از StreamReader
    TextReader tr = new StreamReader("file.html");

    // اضافه‌کردن متن از StreamReader HTML به فریم متن
    ashape.getTextFrame().getParagraphs().addFromHtml(tr.readToEnd());

    // ذخیره‌سازی ارائه
    pres.save("output_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **صادر کردن متن پاراگراف به HTML**

Aspose.Slides پشتیبانی پیشرفته‌ای برای صادر کردن متون (موجود در پاراگراف‌ها) به HTML فراهم می‌کند.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/) ایجاد کنید و ارائه مورد نظر را بارگذاری کنید.
2. مرجع اسلاید مربوطه را از طریق ایندکس آن دسترسی پیدا کنید.
3. به شکل حاوی متنی که قرار است به HTML صادر شود دسترسی پیدا کنید.
4. به [TextFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/textframe/) شکل دسترسی پیدا کنید.
5. یک نمونه از `StreamWriter` ایجاد کنید و فایل HTML جدید را اضافه کنید.
6. یک ایندکس شروع برای StreamWriter تعیین کنید و پاراگراف‌های دلخواه خود را صادر کنید.

این کد Java نشان می‌دهد چگونه متون پاراگراف‌های PowerPoint را به HTML صادر کنید:

```java
// بارگذاری فایل ارائه
Presentation pres = new Presentation("ExportingHTMLText.pptx");
try {
    // دسترسی به اسلاید پیش‌فرض اول ارائه
    ISlide slide = pres.getSlides().get_Item(0);

    // ایندکس مورد نظر
    int index = 0;

    // دسترسی به شکل اضافه‌شده
    IAutoShape ashape = (IAutoShape) slide.getShapes().get_Item(index);

    // ایجاد فایل خروجی HTML
    OutputStream os = new FileOutputStream("output.html");
    Writer writer = new OutputStreamWriter(os, "UTF-8");

    //استخراج اولین پاراگراف به‌صورت HTML
    // نوشتن داده‌های پاراگراف‌ها به HTML با ارائه ایندکس شروع پاراگراف و تعداد کل پاراگراف‌های کپی شده
    writer.write(ashape.getTextFrame().getParagraphs().exportToHtml(0, ashape.getTextFrame().getParagraphs().getCount(), null));
    writer.close();
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **ذخیره یک پاراگراف به عنوان تصویر**

در این بخش دو مثال بررسی می‌شود که نشان می‌دهد چگونه یک پاراگراف متنی، نمایانگر توسط رابط [IParagraph](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iparagraph/) را به عنوان تصویر ذخیره کنیم. هر دو مثال شامل دریافت تصویر یک شکل حاوی پاراگراف با استفاده از متدهای `getImage` از رابط [IShape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ishape/) است، محاسبه مرزهای پاراگراف داخل شکل، و صادرات آن به عنوان تصویر bitmap. این روش‌ها به شما اجازه می‌دهند تا بخش‌های خاصی از متن را از ارائه‌های PowerPoint استخراج کرده و به‌صورت تصاویر جداگانه ذخیره کنید، که می‌تواند برای استفاده‌های مختلف مفید باشد.

فرض کنید فایلی به نام sample.pptx داریم که یک اسلاید دارد و اولین شکل آن یک جعبه متن حاوی سه پاراگراف است.

![جعبه متن با سه پاراگراف](paragraph_to_image_input.png)

**مثال 1**

در این مثال پاراگراف دوم را به عنوان تصویر به‌دست می‌آوریم. برای این کار تصویر شکل را از اسلاید اول ارائه استخراج می‌کنیم، سپس مرزهای پاراگراف دوم در فریم متن شکل را محاسبه می‌کنیم. سپس پاراگراف روی یک تصویر bitmap جدید بازنگری می‌شود و در قالب PNG ذخیره می‌شود. این روش به‌ویژه هنگامی مفید است که نیاز به ذخیره یک پاراگراف خاص به‌صورت تصویر جداگانه دارید، در حالی که ابعاد و قالب‌بندی دقیق متن حفظ می‌شود.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape firstShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // ذخیره شکل در حافظه به‌صورت یک bitmap.
    IImage shapeImage = firstShape.getImage();
    ByteArrayOutputStream shapeImageStream = new ByteArrayOutputStream();
    shapeImage.save(shapeImageStream, ImageFormat.Png);
    shapeImage.dispose();

    // ایجاد bitmap شکل از حافظه.
    InputStream shapeImageInputStream = new ByteArrayInputStream(shapeImageStream.toByteArray());
    BufferedImage shapeBitmap = ImageIO.read(shapeImageInputStream);

    // محاسبه مرزهای پاراگراف دوم.
    IParagraph secondParagraph = firstShape.getTextFrame().getParagraphs().get_Item(1);
    RectF paragraphRectangle = secondParagraph.getRect();

    // محاسبه مختصات و اندازه تصویر خروجی (حداقل اندازه - 1x1 پیکسل).
    int imageX = (int) Math.floor(paragraphRectangle.left);
    int imageY = (int) Math.floor(paragraphRectangle.top);
    int imageWidth = Math.max(1, (int) Math.ceil(paragraphRectangle.width()));
    int imageHeight = Math.max(1, (int) Math.ceil(paragraphRectangle.height()));

    // برش bitmap شکل برای دریافت تنها bitmap پاراگراف.
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

در این مثال رویکرد قبلی را با افزودن عامل مقیاس به تصویر پاراگراف گسترش می‌دهیم. شکل از ارائه استخراج می‌شود و با عامل مقیاس `2` به‌صورت تصویر ذخیره می‌شود که باعث خروجی با وضوح بالاتر می‌شود. سپس مرزهای پاراگراف با در نظر گرفتن مقیاس محاسبه می‌شود. مقیاس‌گذاری به‌ویژه زمانی مفید است که به تصویر دقیق‌تری برای مثال برای استفاده در مواد چاپی با کیفیت بالا نیاز باشد.

```java
float imageScaleX = 2f;
float imageScaleY = imageScaleX;

Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape firstShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // ذخیره شکل در حافظه به‌صورت bitmap با مقیاس‌دهی.
    IImage shapeImage = firstShape.getImage(ShapeThumbnailBounds.Shape, imageScaleX, imageScaleY);
    ByteArrayOutputStream shapeImageStream = new ByteArrayOutputStream();
    shapeImage.save(shapeImageStream, ImageFormat.Png);
    shapeImage.dispose();

    // ایجاد bitmap شکل از حافظه.
    InputStream shapeImageInputStream = new ByteArrayInputStream(shapeImageStream.toByteArray());
    BufferedImage shapeBitmap = ImageIO.read(shapeImageInputStream);

    // محاسبه مرزهای پاراگراف دوم.
    IParagraph secondParagraph = firstShape.getTextFrame().getParagraphs().get_Item(1);
    RectF paragraphRectangle = secondParagraph.getRect();
    paragraphRectangle.set(
            paragraphRectangle.left * imageScaleX,
            paragraphRectangle.top * imageScaleY,
            paragraphRectangle.right * imageScaleX,
            paragraphRectangle.bottom * imageScaleY
    );

    // محاسبه مختصات و اندازه تصویر خروجی (حداقل اندازه - ۱×۱ پیکسل).
    int imageX = (int) Math.floor(paragraphRectangle.left);
    int imageY = (int) Math.floor(paragraphRectangle.top);
    int imageWidth = Math.max(1, (int) Math.ceil(paragraphRectangle.width()));
    int imageHeight = Math.max(1, (int) Math.ceil(paragraphRectangle.height()));

    // بریدن bitmap شکل برای دریافت تنها bitmap پاراگراف.
    BufferedImage paragraphBitmap = shapeBitmap.getSubimage(imageX, imageY, imageWidth, imageHeight);

    ImageIO.write(paragraphBitmap, "png", new File("paragraph.png"));
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **سوالات متداول**

**آیا می‌توانم بسته‌بندی خطوط داخل یک فریم متن را به‌طور کامل غیرفعال کنم؟**

بله. از تنظیمات بسته‌بندی فریم متن ([setWrapText](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/textframeformat/#setWrapText-byte-)) استفاده کنید تا بسته‌بندی را خاموش کنید؛ به این ترتیب خطوط در لبه‌های فریم شکسته نمی‌شوند.

**چگونه می‌توانم مرزهای دقیق یک پاراگراف خاص روی اسلاید را به‌دست آورم؟**

می‌توانید مستطیل محدوده (Bounding Rectangle) پاراگراف (و حتی یک بخش منفرد) را برای دانستن موقعیت و اندازه دقیق آن روی اسلاید بازیابی کنید.

**کنترل تراز پاراگراف (چپ/راست/وسط/توزیع) در کجا قرار دارد؟**

[Alignment](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/paragraphformat/#setAlignment-int-) یک تنظیم سطح پاراگراف در [ParagraphFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/paragraphformat/) است؛ این تنظیم برای کل پاراگراف اعمال می‌شود، صرف‌نظر از قالب‌بندی هر بخش جداگانه.

**آیا می‌توانم زبان بررسی املایی را فقط برای بخشی از یک پاراگراف (مثلاً یک کلمه) تنظیم کنم؟**

بله. زبان در سطح بخش تنظیم می‌شود ([PortionFormat.setLanguageId](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-))، بنابراین می‌توان چند زبان را در یک پاراگراف همزمان داشته باشید.