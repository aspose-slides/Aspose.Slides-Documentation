---
title: مدیریت پاراگراف‌های متن PowerPoint در جاوا
linktitle: مدیریت پاراگراف
type: docs
weight: 40
url: /fa/java/manage-paragraph/
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
- صادر کردن پاراگراف
- PowerPoint
- OpenDocument
- ارائه
- Java
- Aspose.Slides
description: "فرمت‌بندی پیشرفته پاراگراف‌ها با Aspose.Slides برای جاوا—بهینه‌سازی تراز، فاصله‌گذاری و سبک در ارائه‌های PPT، PPTX و ODP در جاوا."
---
## **مقدمه**

Aspose.Slides تمام رابط‌ها و کلاس‌های مورد نیاز شما برای کار با متن‌ها، پاراگراف‌ها و بخش‌های PowerPoint در جاوا را فراهم می‌کند.

* Aspose.Slides رابط [ITextFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/itextframe/) را فراهم می‌کند تا بتوانید اشیایی که نمایانگر یک پاراگراف هستند را اضافه کنید. یک شی `ITextFame` می‌تواند یک یا چند پاراگراف داشته باشد (هر پاراگراف از طریق یک بازگشت carriage ایجاد می‌شود).
* Aspose.Slides رابط [IParagraph](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iparagraph/) را فراهم می‌کند تا بتوانید اشیایی که نمایانگر بخش‌ها هستند را اضافه کنید. یک شی `IParagraph` می‌تواند یک یا چند بخش داشته باشد (مجموعه‌ای از اشیای iPortions).
* Aspose.Slides رابط [IPortion](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iportion/) را فراهم می‌کند تا بتوانید اشیایی که نمایانگر متن‌ها و ویژگی‌های قالب‌بندی آن‌ها هستند را اضافه کنید.

یک شی `IParagraph` می‌تواند متون با ویژگی‌های قالب‌بندی متفاوت را از طریق اشیای زیرین `IPortion` آن مدیریت کند.

## **افزودن چند پاراگراف حاوی چندین بخش**

این مراحل نشان می‌دهد چگونه یک چارچوب متن حاوی ۳ پاراگراف و هر پاراگراف شامل ۳ بخش اضافه کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) ایجاد کنید.
2. از طریق ایندکس، به مرجع اسلاید مربوطه دسترسی پیدا کنید.
3. یک [IAutoShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iautoshape/) مستطیلی به اسلاید اضافه کنید.
4. ITextFrame مرتبط با [IAutoShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iautoshape/) را دریافت کنید.
5. دو شی [IParagraph](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iparagraph/) ایجاد کنید و آن‌ها را به مجموعه `IParagraphs` از [ITextFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/itextframe/) اضافه کنید.
6. برای هر `IParagraph` جدید، سه شی [IPortion](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iportion/) ایجاد کنید (دو شی Portion برای پاراگراف پیش‌فرض) و هر شی `IPortion` را به مجموعه IPortion هر `IParagraph` اضافه کنید.
7. متن مورد نظر را برای هر بخش تنظیم کنید.
8. ویژگی‌های قالب‌بندی دلخواه خود را به هر بخش با استفاده از ویژگی‌های قالب‌بندی ارائه‌شده توسط شی `IPortion` اعمال کنید.
9. ارائه اصلاح شده را ذخیره کنید.

```java
// یک کلاس Presentation که نمایانگر فایل PPTX است را نمونه‌سازی کنید
Presentation pres = new Presentation();
try {
    // دسترسی به اسلاید اول
    ISlide slide = pres.getSlides().get_Item(0);

    // یک AutoShape از نوع Rectangle اضافه کنید
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 300, 150);

    // دسترسی به TextFrame اتوشیپ
    ITextFrame tf = ashp.getTextFrame();

    // ایجاد پاراگراف‌ها و بخش‌ها با قالب‌بندی‌های متنی متفاوت
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

    //ذخیره PPTX به دیسک
    pres.save("multiParaPort_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **مدیریت گلوله‌های پاراگراف**

فهرست‌های گلوله‌ای به شما کمک می‌کند تا اطلاعات را به سرعت و به‌صورت مؤثر سازماندهی و ارائه دهید. پاراگراف‌های دارای گلوله همیشه خواناتر و قابل درک‌تر هستند.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) ایجاد کنید.
2. از طریق ایندکس، به مرجع اسلاید مربوطه دسترسی پیدا کنید.
3. یک [autoshape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iautoshape/) به اسلاید انتخاب شده اضافه کنید.
4. به [TextFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/itextframe/) اتوشیپ دسترسی پیدا کنید.
5. پاراگراف پیش‌فرض را در `TextFrame` حذف کنید.
6. نمونه اولین پاراگراف را با استفاده از کلاس [Paragraph](https://reference.aspose.com/slides/fa/java/com.aspose.slides/paragraph/) ایجاد کنید.
7. نوع گلوله `Type` پاراگراف را به `Symbol` تنظیم کنید و کاراکتر گلوله را تعیین کنید.
8. متن پاراگراف `Text` را تنظیم کنید.
9. تورفتگی `Indent` پاراگراف برای گلوله را تنظیم کنید.
10. رنگی برای گلوله تنظیم کنید.
11. ارتفاعی برای گلوله تنظیم کنید.
12. پاراگراف جدید را به مجموعه پاراگراف‌های `TextFrame` اضافه کنید.
13. پاراگراف دوم را اضافه کنید و فرآیند مراحل ۷ تا ۱۳ را تکرار کنید.
14. ارائه را ذخیره کنید.

```java
// یک کلاس Presentation که نمایانگر فایل PPTX است را نمونه‌سازی می‌کند
Presentation pres = new Presentation();
try {
    // دسترسی به اسلاید اول
    ISlide slide = pres.getSlides().get_Item(0);
    
    // یک Autoshape اضافه می‌کند و به آن دسترسی می‌یابد
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // دسترسی به چارچوب متن (TextFrame) اتوشیپ
    ITextFrame txtFrm = aShp.getTextFrame();

    // پاراگراف پیش‌فرض را حذف می‌کند
    txtFrm.getParagraphs().removeAt(0);

    // یک پاراگراف ایجاد می‌کند
    Paragraph para = new Paragraph();

    // سبک گلوله پاراگراف و نماد را تنظیم می‌کند
    para.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para.getParagraphFormat().getBullet().setChar((char)8226);

    // متن پاراگراف را تنظیم می‌کند
    para.setText("Welcome to Aspose.Slides");

    // تورفتگی گلوله را تنظیم می‌کند
    para.getParagraphFormat().setIndent(25);

    // رنگ گلوله را تنظیم می‌کند
    para.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    para.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    para.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True); // مقدار IsBulletHardColor را به true تنظیم می‌کند تا از رنگ دلخواه گلوله استفاده شود

    // ارتفاع گلوله را تنظیم می‌کند
    para.getParagraphFormat().getBullet().setHeight(100);

    // پاراگراف را به چارچوب متن اضافه می‌کند
    txtFrm.getParagraphs().add(para);

    // پاراگراف دوم را ایجاد می‌کند
    Paragraph para2 = new Paragraph();

    // نوع و سبک گلوله پاراگراف را تنظیم می‌کند
    para2.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    para2.getParagraphFormat().getBullet().setNumberedBulletStyle(NumberedBulletStyle.BulletCircleNumWDBlackPlain);

    // متن پاراگراف را اضافه می‌کند
    para2.setText("This is numbered bullet");

    // تورفتگی گلوله را تنظیم می‌کند
    para2.getParagraphFormat().setIndent(25);

    para2.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    para2.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    para2.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True); // مقدار IsBulletHardColor را به true تنظیم می‌کند تا از رنگ دلخواه گلوله استفاده شود

    // ارتفاع گلوله را تنظیم می‌کند
    para2.getParagraphFormat().getBullet().setHeight(100);

    // پاراگراف را به چارچوب متن اضافه می‌کند
    txtFrm.getParagraphs().add(para2);
    
    // ارائه اصلاح‌شده را ذخیره می‌کند
    pres.save("Bullet_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **مدیریت گلوله‌های تصویری**

فهرست‌های گلوله‌ای به شما کمک می‌کند تا اطلاعات را به سرعت و به‌صورت مؤثر سازماندهی و ارائه دهید. پاراگراف‌های تصویری خواناتر و قابل درک‌تر هستند.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) ایجاد کنید.
2. از طریق ایندکس، به مرجع اسلاید مربوطه دسترسی پیدا کنید.
3. یک [autoshape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iautoshape/) به اسلاید اضافه کنید.
4. به [TextFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/itextframe/) اتوشیپ دسترسی پیدا کنید.
5. پاراگراف پیش‌فرض را در `TextFrame` حذف کنید.
6. نمونه اولین پاراگراف را با استفاده از کلاس [Paragraph](https://reference.aspose.com/slides/fa/java/com.aspose.slides/paragraph/) ایجاد کنید.
7. تصویر را در [IPPImage](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ippimage/) بارگذاری کنید.
8. نوع گلوله را به [Picture](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ippimage/) تنظیم کنید و تصویر را تعیین کنید.
9. متن پاراگراف `Text` را تنظیم کنید.
10. تورفتگی `Indent` پاراگراف برای گلوله را تنظیم کنید.
11. رنگی برای گلوله تنظیم کنید.
12. ارتفاعی برای گلوله تنظیم کنید.
13. پاراگراف جدید را به مجموعه پاراگراف‌های `TextFrame` اضافه کنید.
14. پاراگراف دوم را اضافه کنید و فرآیند مراحل قبلی را تکرار کنید.
15. ارائه اصلاح شده را ذخیره کنید.

```java
// یک کلاس Presentation که نمایانگر یک فایل PPTX است را نمونه‌سازی می‌کند
Presentation presentation = new Presentation();
try {
    // به اسلاید اول دسترسی می‌یابد
    ISlide slide = presentation.getSlides().get_Item(0);

    // تصویر برای گلوله‌ها را نمونه‌سازی می‌کند
    IPPImage picture;
    IImage image = Images.fromFile("bullets.png");
    try {
        picture = presentation.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }
    // یک Autoshape اضافه می‌کند و به آن دسترسی می‌یابد
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // به TextFrame اتوشیپ دسترسی می‌یابد
    ITextFrame textFrame = autoShape.getTextFrame();

    // پاراگراف پیش‌فرض را حذف می‌کند
    textFrame.getParagraphs().removeAt(0);

    // یک پاراگراف جدید ایجاد می‌کند
    Paragraph paragraph = new Paragraph();
    paragraph.setText("Welcome to Aspose.Slides");

    // سبک گلوله پاراگراف و تصویر را تنظیم می‌کند
    paragraph.getParagraphFormat().getBullet().setType(BulletType.Picture);
    paragraph.getParagraphFormat().getBullet().getPicture().setImage(picture);

    // ارتفاع گلوله را تنظیم می‌کند
    paragraph.getParagraphFormat().getBullet().setHeight(100);

    // پاراگراف را به TextFrame اضافه می‌کند
    textFrame.getParagraphs().add(paragraph);

    // ارائه را به عنوان یک فایل PPTX ذخیره می‌کند
    presentation.save("ParagraphPictureBulletsPPTX_out.pptx", SaveFormat.Pptx);

    // ارائه را به عنوان یک فایل PPT ذخیره می‌کند
    presentation.save("ParagraphPictureBulletsPPT_out.ppt", SaveFormat.Ppt);
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **مدیریت گلوله‌های چندسطحی**

فهرست‌های گلوله‌ای به شما کمک می‌کند تا اطلاعات را به سرعت و به‌صورت مؤثر سازماندهی و ارائه دهید. گلوله‌های چندسطحی خواناتر و قابل درک‌تر هستند.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) ایجاد کنید.
2. از طریق ایندکس، به مرجع اسلاید مربوطه دسترسی پیدا کنید.
3. یک [autoshape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iautoshape/) در اسلاید جدید اضافه کنید.
4. به [TextFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/itextframe/) اتوشیپ دسترسی پیدا کنید.
5. پاراگراف پیش‌فرض را در `TextFrame` حذف کنید.
6. اولین پاراگراف را از طریق کلاس [Paragraph](https://reference.aspose.com/slides/fa/java/com.aspose.slides/paragraph/) ایجاد کنید و عمق را به ۰ تنظیم کنید.
7. پاراگراف دوم را از طریق کلاس `Paragraph` ایجاد کنید و عمق را به ۱ تنظیم کنید.
8. پاراگراف سوم را از طریق کلاس `Paragraph` ایجاد کنید و عمق را به ۲ تنظیم کنید.
9. پاراگراف چهارم را از طریق کلاس `Paragraph` ایجاد کنید و عمق را به ۳ تنظیم کنید.
10. پاراگراف‌های جدید را به مجموعه پاراگراف‌های `TextFrame` اضافه کنید.
11. ارائه اصلاح شده را ذخیره کنید.

```java
// یک کلاس Presentation که نمایانگر یک فایل PPTX است را نمونه‌سازی می‌کند
Presentation pres = new Presentation();
try {
    // به اسلاید اول دسترسی می‌یابد
    ISlide slide = pres.getSlides().get_Item(0);

    // یک Autoshape اضافه می‌کند و به آن دسترسی می‌یابد
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // به فریم متن (TextFrame) اتوشیپ ایجاد شده دسترسی می‌یابد
    ITextFrame text = aShp.addTextFrame("");

    // پاراگراف پیش‌فرض را پاک می‌کند
    text.getParagraphs().clear();

    // پاراگراف اول را اضافه می‌کند
    IParagraph para1 = new Paragraph();
    para1.setText("Content");
    para1.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para1.getParagraphFormat().getBullet().setChar((char)8226);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // سطح گلوله را تنظیم می‌کند
    para1.getParagraphFormat().setDepth((short)0);

    // پاراگراف دوم را اضافه می‌کند
    IParagraph para2 = new Paragraph();
    para2.setText("Second Level");
    para2.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para2.getParagraphFormat().getBullet().setChar('-');
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // سطح گلوله را تنظیم می‌کند
    para2.getParagraphFormat().setDepth((short)1);

    // پاراگراف سوم را اضافه می‌کند
    IParagraph para3 = new Paragraph();
    para3.setText("Third Level");
    para3.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para3.getParagraphFormat().getBullet().setChar((char)8226);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // سطح گلوله را تنظیم می‌کند
    para3.getParagraphFormat().setDepth((short)2);

    // پاراگراف چهارم را اضافه می‌کند
    IParagraph para4 = new Paragraph();
    para4.setText("Fourth Level");
    para4.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para4.getParagraphFormat().getBullet().setChar('-');
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // سطح گلوله را تنظیم می‌کند
    para4.getParagraphFormat().setDepth((short)3);

    // پاراگراف‌ها را به مجموعه اضافه می‌کند
    text.getParagraphs().add(para1);
    text.getParagraphs().add(para2);
    text.getParagraphs().add(para3);
    text.getParagraphs().add(para4);

    // ارائه را به صورت فایل PPTX ذخیره می‌کند
    pres.save("MultilevelBullet.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **مدیریت پاراگراف با فهرست شماره‌گذاری سفارشی**

رابط [IBulletFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ibulletformat/) ویژگی [NumberedBulletStartWith](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) و دیگر ویژگی‌ها را فراهم می‌کند که به شما امکان مدیریت پاراگراف‌ها با شماره‌گذاری یا قالب‌بندی سفارشی را می‌دهد.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) ایجاد کنید.
2. به اسلاید حاوی پاراگراف دسترسی پیدا کنید.
3. یک [autoshape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iautoshape/) به اسلاید اضافه کنید.
4. به [TextFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/itextframe/) اتوشیپ دسترسی پیدا کنید.
5. پاراگراف پیش‌فرض را در `TextFrame` حذف کنید.
6. اولین پاراگراف را از طریق کلاس [Paragraph](https://reference.aspose.com/slides/fa/java/com.aspose.slides/paragraph/) ایجاد کنید و [NumberedBulletStartWith] را به ۲ تنظیم کنید.
7. پاراگراف دوم را از طریق کلاس `Paragraph` ایجاد کنید و `NumberedBulletStartWith` را به ۳ تنظیم کنید.
8. پاراگراف سوم را از طریق کلاس `Paragraph` ایجاد کنید و `NumberedBulletStartWith` را به ۷ تنظیم کنید.
9. پاراگراف‌های جدید را به مجموعه پاراگراف‌های `TextFrame` اضافه کنید.
10. ارائه اصلاح شده را ذخیره کنید.

```java
Presentation presentation = new Presentation();
try {
    IAutoShape shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // به فریم متن (TextFrame) اتوشیپ ایجاد شده دسترسی می‌یابد
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

از متد [IParagraphFormat.setIndent](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iparagraphformat/#setIndent-float-) برای کنترل تورفتگی خط اول یک پاراگراف استفاده کنید. این متد تنها خط اول را نسبت به حاشیه چپ پاراگراف جابجا می‌کند. مقدار مثبت خط اول را به سمت راست می‌برد، در حالی که خطوط باقی‌مانده به بدنه پاراگراف تراز می‌مانند.

زمانی که نیاز به جابجایی کل پاراگراف دارید از [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) استفاده کنید. برای جابجایی فقط خط اول از [IParagraphFormat.setIndent](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iparagraphformat/#setIndent-float-) استفاده کنید.

مثال زیر چند پاراگراف ایجاد می‌کند و مقادیر مختلف تورفتگی را برای نشان دادن تأثیر تورفتگی خط اول بر چینش پاراگراف اعمال می‌کند.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) ایجاد کنید.
2. به اسلاید هدف دسترسی پیدا کنید.
3. یک [AutoShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/autoshape/) مستطیلی به اسلاید اضافه کنید.
4. یک [TextFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/textframe/) خالی به شکل اضافه کنید و پاراگراف پیش‌فرض را حذف کنید.
5. چندین پاراگراف ایجاد کنید و مقادیر مختلف [Indent](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iparagraphformat/#setIndent-float-) را برای آن‌ها تنظیم کنید.
6. پاراگراف‌ها را به چارچوب متن اضافه کنید.
7. ارائه اصلاح شده را ذخیره کنید.

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

![تورفتگی خط اول پاراگراف‌ها](first_line_indent.png)

## **تنظیم تورفتگی آویزان برای پاراگراف**

تورفتگی آویزان یک طرح‌بندی پاراگراف است که در آن خط اول به سمت چپ خطوط باقی‌مانده شروع می‌شود. در Aspose.Slides این اثر را با متد [IParagraphFormat.setIndent](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iparagraphformat/#setIndent-float-) ایجاد می‌کنید. مقدار منفی به این متد تنظیم کنید تا خط اول نسبت به بدنه پاراگراف به سمت چپ جابه‌جا شود.

در عمل، [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) موقعیت چپ بدنه پاراگراف را تعیین می‌کند و [IParagraphFormat.setIndent](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iparagraphformat/#setIndent-float-) موقعیت خط اول را نسبت به آن حاشیه مشخص می‌سازد. برای ایجاد تورفتگی آویزان، مقدار مثبت `MarginLeft` و مقدار منفی `Indent` تنظیم کنید.

این قالب‌بندی برای کتابشناسی‌ها، مراجع، ورودی‌های واژه‌نامه و سایر پاراگراف‌هایی که خطوط بسته‌شده باید زیر بدنه پاراگراف نه زیر اولین کاراکتر خط اول قرار گیرند، مفید است.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) ایجاد کنید.
2. به اسلاید هدف دسترسی پیدا کنید.
3. یک [AutoShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/autoshape/) مستطیلی به اسلاید اضافه کنید.
4. یک [TextFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/textframe/) خالی به شکل اضافه کنید و پاراگراف پیش‌فرض را حذف کنید.
5. پاراگراف‌ها را ایجاد کنید و برای هر پاراگراف مقدار مثبت [MarginLeft](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) تنظیم کنید.
6. مقدار منفی [Indent](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iparagraphformat/#setIndent-float-) تنظیم کنید تا اثر تورفتگی آویزان حاصل شود.
7. پاراگراف‌ها را به چارچوب متن اضافه کنید.
8. ارائه اصلاح شده را ذخیره کنید.

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

![تورفتگی آویزان پاراگراف‌ها](hanging_indent.png)

## **مدیریت ویژگی‌های End برای پاراگراف‌ها**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) ایجاد کنید.
2. مرجع اسلاید شامل پاراگراف را از طریق موقعیت آن دریافت کنید.
3. یک [autoshape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iautoshape/) مستطیلی به اسلاید اضافه کنید.
4. یک [TextFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/itextframe/) با دو پاراگراف به مستطیل اضافه کنید.
5. ارتفاع قلم `FontHeight` و نوع فونت را برای پاراگراف‌ها تنظیم کنید.
6. ویژگی‌های End را برای پاراگراف‌ها تنظیم کنید.
7. ارائه اصلاح‌شده را به‌صورت فایل PPTX ذخیره کنید.

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

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) ایجاد کنید.
2. از طریق ایندکس، به مرجع اسلاید مربوطه دسترسی پیدا کنید.
3. یک [autoshape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iautoshape/) به اسلاید اضافه کنید.
4. `autoshape` [ITextFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/itextframe/) را اضافه و دسترسی پیدا کنید.
5. پاراگراف پیش‌فرض را در `ITextFrame` حذف کنید.
6. فایل HTML منبع را با استفاده از یک TextReader بخوانید.
7. اولین پاراگراف را از طریق کلاس [Paragraph](https://reference.aspose.com/slides/fa/java/com.aspose.slides/paragraph/) ایجاد کنید.
8. محتوای فایل HTML خوانده‌شده از TextReader را به [ParagraphCollection](https://reference.aspose.com/slides/fa/java/com.aspose.slides/paragraphcollection/) چارچوب متن اضافه کنید.
9. ارائه اصلاح شده را ذخیره کنید.

```java
// ایجاد یک نمونه خالی از ارائه
Presentation pres = new Presentation();
try {
    // دسترسی به اسلاید پیش‌فرض اول ارائه
    ISlide slide = pres.getSlides().get_Item(0);

    // افزودن AutoShape برای قرار دادن محتوای HTML
    IAutoShape ashape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10,
            (float)pres.getSlideSize().getSize().getWidth() - 20, (float)pres.getSlideSize().getSize().getHeight() - 10);

    ashape.getFillFormat().setFillType(FillType.NoFill);

    // افزودن فریم متن به شکل
    ashape.addTextFrame("");

    // پاک‌سازی تمام پاراگراف‌ها در فریم متن اضافه‌شده
    ashape.getTextFrame().getParagraphs().clear();

    // بارگذاری فایل HTML با استفاده از StreamReader
    TextReader tr = new StreamReader("file.html");

    // افزودن متن از StreamReader HTML به فریم متن
    ashape.getTextFrame().getParagraphs().addFromHtml(tr.readToEnd());

    // ذخیره‌سازی ارائه
    pres.save("output_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **صادر کردن متن پاراگراف به HTML**

Aspose.Slides پشتیبانی پیشرفته‌ای برای صادر کردن متون (موجود در پاراگراف‌ها) به HTML فراهم می‌کند.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) ایجاد کنید و ارائه موردنظر را بارگذاری کنید.
2. از طریق ایندکس، به مرجع اسلاید مربوطه دسترسی پیدا کنید.
3. به شکل حاوی متنی که می‌خواهید به HTML صادر شود دسترسی پیدا کنید.
4. به [TextFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/textframe/) شکل دسترسی پیدا کنید.
5. یک نمونه از `StreamWriter` ایجاد کنید و فایل HTML جدید را اضافه کنید.
6. یک شاخص شروع به StreamWriter بدهید و پاراگراف‌های موردنظر خود را صادر کنید.

```java
// فای�� ارائه را بارگذاری کنید
Presentation pres = new Presentation("ExportingHTMLText.pptx");
try {
    // به اسلاید پیش‌فرض اول ارائه دسترسی پیدا کنید
    ISlide slide = pres.getSlides().get_Item(0);

    // اندیس مورد نظر
    int index = 0;

    // دستیابی به شکل اضافه‌شده
    IAutoShape ashape = (IAutoShape) slide.getShapes().get_Item(index);

    // ایجاد فایل خروجی HTML
    OutputStream os = new FileOutputStream("output.html");
    Writer writer = new OutputStreamWriter(os, "UTF-8");

    //استخراج اولین پاراگراف به صورت HTML
    // نوشتن داده‌های پاراگراف‌ها به HTML با ارائه ایندکس شروع پاراگراف و تعداد کل پاراگراف‌های قابل کپی
    writer.write(ashape.getTextFrame().getParagraphs().exportToHtml(0, ashape.getTextFrame().getParagraphs().getCount(), null));
    writer.close();
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **ذخیره یک پاراگراف به عنوان تصویر**

در این بخش دو مثال بررسی می‌کنیم که نشان می‌دهند چگونه یک پاراگراف متن، که توسط رابط [IParagraph](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iparagraph/) نمایش داده می‌شود، به صورت تصویر ذخیره شود. هر دو مثال شامل به‌دست آوردن تصویر یک شکل حاوی پاراگراف با استفاده از روش‌های `getImage` از رابط [IShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ishape/) است، محاسبه مرزهای پاراگراف داخل شکل و صادر کردن آن به عنوان تصویر بیت‌مپ. این روش‌ها به شما امکان می‌دهند بخش‌های خاصی از متن را از ارائه‌های PowerPoint استخراج و به‌صورت تصاویر جداگانه ذخیره کنید که می‌تواند در سناریوهای مختلف مفید باشد.

فرض کنیم فایلی به نام sample.pptx با یک اسلاید داریم که اولین شکل آن یک کادر متن حاوی سه پاراگراف است.

![کادر متن با سه پاراگراف](paragraph_to_image_input.png)

**مثال 1**

در این مثال پاراگراف دوم را به‌عنوان تصویر استخراج می‌کنیم. برای این کار تصویر شکل را از اسلاید اول استخراج می‌کنیم و سپس مرزهای پاراگراف دوم را در چارچوب متن شکل محاسبه می‌کنیم. سپس پاراگراف روی یک تصویر بیت‌مپ جدید بازنگری می‌شود و به صورت PNG ذخیره می‌شود. این روش به‌ویژه زمانی مفید است که بخواهید یک پاراگراف خاص را به‌عنوان تصویر جداگانه ذخیره کنید در حالی که ابعاد و قالب‌بندی دقیق متن حفظ شود.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape firstShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // شکل را به عنوان یک بیت‌مپ در حافظه ذخیره کنید.
    IImage shapeImage = firstShape.getImage();
    ByteArrayOutputStream shapeImageStream = new ByteArrayOutputStream();
    shapeImage.save(shapeImageStream, ImageFormat.Png);
    shapeImage.dispose();

    // یک بیت‌مپ شکل از حافظه ایجاد کنید.
    InputStream shapeImageInputStream = new ByteArrayInputStream(shapeImageStream.toByteArray());
    BufferedImage shapeBitmap = ImageIO.read(shapeImageInputStream);

    // مرزهای پاراگراف دوم را محاسبه کنید.
    IParagraph secondParagraph = firstShape.getTextFrame().getParagraphs().get_Item(1);
    Rectangle2D paragraphRectangle = secondParagraph.getRect();

    // مختصات و اندازه تصویر خروجی را محاسبه کنید (حداقل اندازه - 1x1 پیکسل).
    int imageX = (int) Math.floor(paragraphRectangle.getX());
    int imageY = (int) Math.floor(paragraphRectangle.getY());
    int imageWidth = Math.max(1, (int) Math.ceil(paragraphRectangle.getWidth()));
    int imageHeight = Math.max(1, (int) Math.ceil(paragraphRectangle.getHeight()));

    // بیت‌مپ شکل را برش دهید تا تنها بیت‌مپ پاراگراف به دست آید.
    BufferedImage paragraphBitmap = shapeBitmap.getSubimage(imageX, imageY, imageWidth, imageHeight);

    ImageIO.write(paragraphBitmap, "png", new File("paragraph.png"));
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

![تصویر پاراگراف](paragraph_to_image_output.png)

**مثال 2**

در این مثال رویکرد قبلی را با افزودن عوامل مقیاس به تصویر پاراگراف گسترش می‌دهیم. شکل از ارائه استخراج می‌شود و به‌عنوان تصویر با عامل مقیاس ۲ ذخیره می‌شود. این امکان خروجی با وضوح بالاتر را هنگام صادر کردن پاراگراف فراهم می‌کند. سپس مرزهای پاراگراف با درنظر گرفتن مقیاس محاسبه می‌شود. مقیاس‌بندی می‌تواند زمانی مفید باشد که به تصویر با جزئیات بیشتر نیاز دارید، به‌عنوان مثال برای استفاده در مواد چاپی با کیفیت بالا.

```java
float imageScaleX = 2f;
float imageScaleY = imageScaleX;

Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape firstShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // شکل را به عنوان یک بیت‌مپ در حافظه ذخیره کنید با مقیاس‌بندی.
    IImage shapeImage = firstShape.getImage(ShapeThumbnailBounds.Shape, imageScaleX, imageScaleY);
    ByteArrayOutputStream shapeImageStream = new ByteArrayOutputStream();
    shapeImage.save(shapeImageStream, ImageFormat.Png);
    shapeImage.dispose();

    // یک بیت‌مپ شکل را از حافظه ایجاد کنید.
    InputStream shapeImageInputStream = new ByteArrayInputStream(shapeImageStream.toByteArray());
    BufferedImage shapeBitmap = ImageIO.read(shapeImageInputStream);

    // مرزهای پاراگراف دوم را محاسبه کنید.
    IParagraph secondParagraph = firstShape.getTextFrame().getParagraphs().get_Item(1);
    Rectangle2D paragraphRectangle = secondParagraph.getRect();
    paragraphRectangle.setRect(
            paragraphRectangle.getX() * imageScaleX,
            paragraphRectangle.getY() * imageScaleY,
            paragraphRectangle.getWidth() * imageScaleX,
            paragraphRectangle.getHeight() * imageScaleY
    );

    // مختصات و اندازه تصویر خروجی را محاسبه کنید (حداقل اندازه - 1x1 پیکسل).
    int imageX = (int) Math.floor(paragraphRectangle.getX());
    int imageY = (int) Math.floor(paragraphRectangle.getY());
    int imageWidth = Math.max(1, (int) Math.ceil(paragraphRectangle.getWidth()));
    int imageHeight = Math.max(1, (int) Math.ceil(paragraphRectangle.getHeight()));

    // بیت‌مپ شکل را برش دهید تا فقط بیت‌مپ پاراگراف به‌دست آید.
    BufferedImage paragraphBitmap = shapeBitmap.getSubimage(imageX, imageY, imageWidth, imageHeight);

    ImageIO.write(paragraphBitmap, "png", new File("paragraph.png"));
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **سؤالات متداول**

**آیا می‌توانم بسته شدن خط داخل یک TextFrame را به‌طور کامل غیرفعال کنم؟**

بله. از تنظیمات بسته شدن متن در TextFrame (متد [setWrapText](https://reference.aspose.com/slides/fa/java/com.aspose.slides/textframeformat/#setWrapText-byte-)) استفاده کنید تا بسته شدن را غیرفعال کنید، بنابراین خطوط در لبه‌های فریم شکسته نمی‌شوند.

**چگونه می‌توانم محدوده دقیق یک پاراگراف خاص را بر روی اسلاید به‌دست آورم؟**

می‌توانید مستطیل محاطی پاراگراف (و حتی یک بخش منفرد) را دریافت کنید تا موقعیت و اندازه دقیق آن را بر روی اسلاید بدانید.

**قالب‌بندی تراز پاراگراف (چپ/راست/وسط/تعدیل) در کجا کنترل می‌شود؟**

[Alignment](https://reference.aspose.com/slides/fa/java/com.aspose.slides/paragraphformat/#setAlignment-int-) یک تنظیم در سطح پاراگراف در [ParagraphFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/paragraphformat/) است؛ این تنظیم برای کل پاراگراف اعمال می‌شود، صرف‌نظر از قالب‌بندی هر بخش به‌صورت جداگانه.

**آیا می‌توانم زبان بررسی املا را فقط برای بخشی از یک پاراگراف (مثلاً یک کلمه) تنظیم کنم؟**

بله. زبان در سطح بخش تنظیم می‌شود ([PortionFormat.setLanguageId](https://reference.aspose.com/slides/fa/java/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-))، بنابراین می‌توان چند زبان را در یک پاراگراف ترکیب کرد.