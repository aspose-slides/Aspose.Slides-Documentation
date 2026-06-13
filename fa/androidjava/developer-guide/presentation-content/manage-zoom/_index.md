---
title: مدیریت زوم ارائه در اندروید
linktitle: مدیریت زوم
type: docs
weight: 60
url: /fa/androidjava/manage-zoom/
keywords:
- زوم
- فریم زوم
- زوم اسلاید
- زوم بخش
- زوم خلاصه
- افزودن زوم
- پاورپوینت
- ارائه
- اندروید
- جاوا
- Aspose.Slides
description: "ایجاد و سفارشی‌سازی زوم با Aspose.Slides برای اندروید از طریق جاوا — پرش بین بخش‌ها، افزودن تصویر بندانگشتی و انتقال‌ها در ارائه‌های PPT، PPTX و ODP."
---
## **مقدمه**

Zoomها در PowerPoint به شما امکان می‌دهند که به اسلایدها، بخش‌ها و قسمت‌های خاص یک ارائه بپیوندید و از آن‌ها خارج شوید. هنگام ارائه، این قابلیت برای ناوبری سریع در محتوا می‌تواند بسیار مفید باشد.

![overview_image](overview.png)

* برای خلاصه‌کردن یک ارائه کامل در یک اسلاید، از [Summary Zoom](#Summary-Zoom) استفاده کنید.
* برای نمایش فقط اسلایدهای انتخاب‌شده، از [Slide Zoom](#Slide-Zoom) استفاده کنید.
* برای نمایش فقط یک بخش، از [Section Zoom](#Section-Zoom) استفاده کنید.

## **Zoom اسلاید**
یک Zoom اسلاید می‌تواند ارائه شما را پویاتر کند و به شما اجازه دهد بین اسلایدها به هر ترتیب دلخواه بدون قطع جریان ارائه حرکت کنید. Zoomهای اسلاید برای ارائه‌های کوتاه بدون بخش‌های زیاد عالی‌اند، اما می‌توانید آن‌ها را در سناریوهای مختلف ارائه نیز به کار ببرید.

Zoomهای اسلاید به شما کمک می‌کنند تا به چندین قطعه اطلاعات در حالی که حس می‌کنید روی یک بوم واحد هستید، نفوذ کنید.

![overview_image](slidezoomsel.png)

برای اشیای Zoom اسلاید، Aspose.Slides ارائه می‌دهد [ZoomImageType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ZoomImageType) enumeration، [IZoomFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IZoomFrame) interface و برخی متدها تحت [IShapeCollection](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IShapeCollection) interface.

### **ایجاد فریم‌های Zoom**

می‌توانید یک فریم Zoom را به این شکل به اسلاید اضافه کنید:

1.	یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation) ایجاد کنید.
2.	اسلایدهای جدیدی که می‌خواهید فریم‌های Zoom به آن‌ها لینک شوند، ایجاد کنید. 
3.	یک متن شناسایی و پس‌زمینه به اسلایدهای ایجاد شده اضافه کنید.
4.	فریم‌های Zoom (شامل ارجاع به اسلایدهای ایجاد شده) را به اسلاید اول اضافه کنید.
5.	پیشنهاد ارائه تغییر یافته را به عنوان فایل PPTX بنویسید.

این کد Java نشان می‌دهد چگونه یک فریم Zoom را روی اسلاید ایجاد کنید:

``` java
Presentation pres = new Presentation();
try {
    //اسلایدهای جدید را به ارائه اضافه می‌کند
    ISlide slide2 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    ISlide slide3 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());

    // یک پس‌زمینه برای اسلاید دوم ایجاد می‌کند
    slide2.getBackground().setType(BackgroundType.OwnBackground);
    slide2.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide2.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);

    // یک جعبه متن برای اسلاید دوم ایجاد می‌کند
    IAutoShape autoshape = slide2.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Second Slide");

    // یک پس‌زمینه برای اسلاید سوم ایجاد می‌کند
    slide3.getBackground().setType(BackgroundType.OwnBackground);
    slide3.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide3.getBackground().getFillFormat().getSolidFillColor().setColor(Color.darkGray);

    // یک جعبه متن برای اسلاید سوم ایجاد می‌کند
    autoshape = slide3.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Trird Slide");

    //فریم‌های Zoom را اضافه می‌کند
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 250, 200, slide2);
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(200, 250, 250, 200, slide3);

    // ارائه را ذخیره می‌کند
    pres.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```
### **ایجاد فریم‌های Zoom با تصاویر سفارشی**
با Aspose.Slides برای Android از طریق Java، می‌توانید یک فریم Zoom با تصویر پیش‌نمایش اسلاید متفاوت به این شکل ایجاد کنید:
1.	یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation) ایجاد کنید.
2.	یک اسلاید جدید که می‌خواهید فریم Zoom به آن لینک شود، ایجاد کنید. 
3.	یک متن شناسایی و پس‌زمینه به اسلاید اضافه کنید.
4.	یک شیء [IPPImage](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IPPImage) با افزودن تصویر به مجموعه Images مرتبط با شیء [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation) که برای پر کردن فریم استفاده می‌شود، ایجاد کنید.
5.	فریم‌های Zoom (شامل ارجاع به اسلاید ایجاد شده) را به اسلاید اول اضافه کنید.
6.	پیشنهاد ارائه تغییر یافته را به عنوان فایل PPTX بنویسید.

این کد Java نشان می‌دهد چگونه یک فریم Zoom با تصویر متفاوت ایجاد کنید:

``` java
Presentation pres = new Presentation();
try {
    //یک اسلاید جدید به ارائه اضافه می‌کند
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());

    // یک پس‌زمینه برای اسلاید دوم ایجاد می‌کند
    slide.getBackground().setType(BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);

    // یک جعبه متن برای اسلاید سوم ایجاد می‌کند
    IAutoShape autoshape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Second Slide");

    // یک تصویر جدید برای شیء زوم ایجاد می‌کند
    IPPImage picture;
        IImage image = Images.fromFile("image.png");
        try {
            picture = pres.getImages().addImage(image);
        } finally {
            if (image != null) image.dispose();
        }
    //فریم Zoom را اضافه می‌کند
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 300, 200, slide, picture);

    // ارائه را ذخیره می‌کند
    pres.save("presentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```
### **قالب‌بندی فریم‌های Zoom**
در بخش‌های قبلی، نشان دادیم چگونه فریم‌های Zoom ساده را ایجاد کنید. برای ایجاد فریم‌های Zoom پیچیده‌تر، باید قالب‌بندی یک فریم ساده را تغییر دهید. گزینه‌های قالب‌بندی متعددی می‌توانید بر روی یک فریم Zoom اعمال کنید. 

می‌توانید قالب‌بندی فریم Zoom را روی اسلاید به این شکل کنترل کنید:

1.	یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation) ایجاد کنید.
2.	اسلایدهای جدیدی که می‌خواهید فریم Zoom به آن‌ها لینک شود، ایجاد کنید. 
3.	متن شناسایی و پس‌زمینه‌ای به اسلایدهای ایجاد شده اضافه کنید.
4.	فریم‌های Zoom (شامل ارجاع به اسلایدهای ایجاد شده) را به اسلاید اول اضافه کنید.
5.	یک شیء [IPPImage](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IPPImage) با افزودن تصویر به مجموعه Images مرتبط با شیء [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation) که برای پر کردن فریم استفاده می‌شود، ایجاد کنید.
6.	تصویر سفارشی برای اولین شیء فریم Zoom تنظیم کنید.
7.	قالب خط برای شیء دوم فریم Zoom را تغییر دهید.
8.	پس‌زمینه تصویر شیء دوم فریم Zoom را حذف کنید.
5.	پیشنهاد ارائه تغییر یافته را به عنوان فایل PPTX بنویسید.

این کد Java نشان می‌دهد چگونه قالب‌بندی فریم Zoom را روی اسلاید تغییر دهید: 

``` java 
Presentation pres = new Presentation();
try {
    //اسلایدهای جدید را به ارائه اضافه می‌کند
    ISlide slide2 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    ISlide slide3 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());

    // یک پس‌زمینه برای اسلاید دوم ایجاد می‌کند
    slide2.getBackground().setType(BackgroundType.OwnBackground);
    slide2.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide2.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);

    // یک جعبه متن برای اسلاید دوم ایجاد می‌کند
    IAutoShape autoshape = slide2.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Second Slide");

    // یک پس‌زمینه برای اسلاید سوم ایجاد می‌کند
    slide3.getBackground().setType(BackgroundType.OwnBackground);
    slide3.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide3.getBackground().getFillFormat().getSolidFillColor().setColor(Color.darkGray);

    // یک جعبه متن برای اسلاید سوم ایجاد می‌کند
    autoshape = slide3.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Trird Slide");

    //فریم‌های Zoom را اضافه می‌کند
    IZoomFrame zoomFrame1 = pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 250, 200, slide2);
    IZoomFrame zoomFrame2 = pres.getSlides().get_Item(0).getShapes().addZoomFrame(200, 250, 250, 200, slide3);

    // یک تصویر جدید برای شیء زوم ایجاد می‌کند
    IPPImage picture;
        IImage image = Images.fromFile("image.png");
        try {
            picture = pres.getImages().addImage(image);
        } finally {
            if (image != null) image.dispose();
        }
    // تصویر سفارشی را برای شیء zoomFrame1 تنظیم می‌کند
    zoomFrame1.setImage(picture);

    // قالب فریم زوم را برای شیء zoomFrame2 تنظیم می‌کند
    zoomFrame2.getLineFormat().setWidth(5);
    zoomFrame2.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    zoomFrame2.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.pink);
    zoomFrame2.getLineFormat().setDashStyle(LineDashStyle.DashDot);

    // تنظیم برای عدم نمایش پس‌زمینه برای شیء zoomFrame2
    zoomFrame2.setShowBackground(false);

    // ارائه را ذخیره می‌کند
    pres.save("presentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Zoom بخش**

Zoom بخش یک لینک به یک بخش در ارائه شما است. می‌توانید از Zoomهای بخش برای بازگشت به بخش‌هایی که می‌خواهید به‌طور ویژه برجسته کنید استفاده کنید. یا می‌توانید از آن‌ها برای نشان دادن چگونگی ارتباط بخش‌های مختلف ارائه‌تان بهره بگیرید. 

![overview_image](seczoomsel.png)

برای اشیای Zoom بخش، Aspose.Slides ارائه می‌دهد [ISectionZoomFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ISectionZoomFrame) interface و برخی متدها تحت [IShapeCollection](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IShapeCollection) interface.

### **ایجاد فریم‌های Zoom بخش**

می‌توانید یک فریم Zoom بخش را به این شکل به اسلاید اضافه کنید:

1.	یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation) ایجاد کنید.
2.	یک اسلاید جدید ایجاد کنید. 
3.	پس‌زمینه شناسایی به اسلاید ایجاد شده اضافه کنید.
4.	یک بخش جدید که می‌خواهید فریم Zoom به آن لینک شود، ایجاد کنید. 
5.	یک فریم Zoom بخش (شامل ارجاع به بخش ایجاد شده) را به اسلاید اول اضافه کنید.
6.	پیشنهاد ارائه تغییر یافته را به عنوان فایل PPTX بنویسید.

این کد Java نشان می‌دهد چگونه یک فریم Zoom را روی اسلاید ایجاد کنید:

``` java
Presentation pres = new Presentation();
try {
    // یک اسلاید جدید به ارائه اضافه می‌کند
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.yellow);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // یک بخش جدید به ارائه اضافه می‌کند
    pres.getSections().addSection("Section 1", slide);

    // یک شیء SectionZoomFrame اضافه می‌کند
    ISectionZoomFrame sectionZoomFrame = pres.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, pres.getSections().get_Item(1));

    // ارائه را ذخیره می‌کند
    pres.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```
### **ایجاد فریم‌های Zoom بخش با تصاویر سفارشی**

با استفاده از Aspose.Slides برای Android via Java، می‌توانید یک فریم Zoom بخش با تصویر پیش‌نمایش اسلاید متفاوت به این شکل ایجاد کنید:

1.	یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation) ایجاد کنید.
2.	یک اسلاید جدید ایجاد کنید.
3.	پس‌زمینه شناسایی به اسلاید ایجاد شده اضافه کنید.
4.	یک بخش جدید که می‌خواهید فریم Zoom به آن لینک شود، ایجاد کنید. 
5.	یک شیء [IPPImage](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IPPImage) با افزودن تصویر به مجموعه Images مرتبط با شیء [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation) که برای پر کردن فریم استفاده می‌شود، ایجاد کنید.
5.	یک فریم Zoom بخش (شامل ارجاع به بخش ایجاد شده) را به اسلاید اول اضافه کنید.
6.	پیشنهاد ارائه تغییر یافته را به عنوان فایل PPTX بنویسید.

این کد Java نشان می‌دهد چگونه یک فریم Zoom با تصویر متفاوت ایجاد کنید:

``` java 
Presentation pres = new Presentation();
try {
    // یک اسلاید جدید به ارائه اضافه می‌کند
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.yellow);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // یک بخش جدید به ارائه اضافه می‌کند
    pres.getSections().addSection("Section 1", slide);

    // یک تصویر جدید برای شیء زوم ایجاد می‌کند
    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // شیء SectionZoomFrame را اضافه می‌کند
    ISectionZoomFrame sectionZoomFrame = pres.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, pres.getSections().get_Item(1), picture);

    // ارائه را ذخیره می‌کند
    pres.save("presentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```
### **قالب‌بندی فریم‌های Zoom بخش**

برای ایجاد فریم‌های Zoom بخش پیچیده‌تر، باید قالب‌بندی یک فریم ساده را تغییر دهید. گزینه‌های قالب‌بندی متعددی می‌توانید بر روی یک فریم Zoom بخش اعمال کنید. 

می‌توانید قالب‌بندی فریم Zoom بخش را روی اسلاید به این شکل کنترل کنید:

1.	یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation) ایجاد کنید.
2.	یک اسلاید جدید ایجاد کنید.
3.	پس‌زمینه شناسایی به اسلاید ایجاد شده اضافه کنید.
4.	یک بخش جدید که می‌خواهید فریم Zoom به آن لینک شود، ایجاد کنید. 
5.	یک فریم Zoom بخش (شامل ارجاع به بخش ایجاد شده) را به اسلاید اول اضافه کنید.
6.	اندازه و موقعیت شیء Zoom بخش ایجاد شده را تغییر دهید.
7.	یک شیء [IPPImage](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IPPImage) با افزودن تصویر به مجموعه Images مرتبط با شیء [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation) که برای پر کردن فریم استفاده می‌شود، ایجاد کنید.
8.	تصویر سفارشی برای شیء فریم Zoom بخش ایجاد شده تنظیم کنید.
9.	قابلیت *بازگشت به اسلاید اصلی از بخش لینک‌شده* را تنظیم کنید. 
10.	پس‌زمینه تصویر شیء فریم Zoom بخش را حذف کنید.
11.	قالب خط برای شیء دوم فریم Zoom را تغییر دهید.
12.	مدت زمان انتقال را تغییر دهید.
13.	پیشنهاد ارائه تغییر یافته را به عنوان فایل PPTX بنویسید.

این کد Java نشان می‌دهد چگونه قالب‌بندی فریم Zoom بخش را تغییر دهید:

``` java
Presentation pres = new Presentation();
try {
    //یک اسلاید جدید به ارائه اضافه می‌کند
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.yellow);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // یک بخش جدید به ارائه اضافه می‌کند
    pres.getSections().addSection("Section 1", slide);

    // شیء SectionZoomFrame را اضافه می‌کند
    ISectionZoomFrame sectionZoomFrame = pres.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, pres.getSections().get_Item(1));

    // قالب‌بندی برای SectionZoomFrame
    sectionZoomFrame.setX(100);
    sectionZoomFrame.setY(300);
    sectionZoomFrame.setWidth(100);
    sectionZoomFrame.setHeight(75);

    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
         picture = pres.getImages().addImage(image);
     } finally {
        if (image != null) image.dispose();
     }
    sectionZoomFrame.setImage(picture);

    sectionZoomFrame.setReturnToParent(true);
    sectionZoomFrame.setShowBackground(false);

    sectionZoomFrame.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    sectionZoomFrame.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.gray);
    sectionZoomFrame.getLineFormat().setDashStyle(LineDashStyle.DashDot);
    sectionZoomFrame.getLineFormat().setWidth(2.5f);

    sectionZoomFrame.setTransitionDuration(1.5f);

    // ارائه را ذخیره می‌کند
    pres.save("presentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


## **Zoom خلاصه**

Zoom خلاصه شبیه یک صفحهٔ فرودی است که تمام قطعات ارائه شما به‌صورت همزمان نمایش داده می‌شوند. هنگام ارائه می‌توانید از این Zoom برای رفتن از یک نقطه به نقطه دیگر در هر ترتیب دلخواه استفاده کنید. می‌توانید خلاق باشید، جلوتر بپرید یا بخش‌های مختلف نمایش‌تان را بدون قطع جریان ارائه مرور کنید.

![overview_image](sumzoomsel.png)

برای اشیای Zoom خلاصه، Aspose.Slides ارائه می‌دهد [ISummaryZoomFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ISummaryZoomFrame)، [ISummaryZoomSection](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ISummaryZoomSection) و [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ISummaryZoomSectionCollection) interfaces و برخی متدها تحت [IShapeCollection](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IShapeCollection) interface.

### **ایجاد Zoom خلاصه**

می‌توانید یک فریم Zoom خلاصه را به اسلاید به این شکل اضافه کنید:

1.	یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation) ایجاد کنید.
2.	اسلایدهای جدید با پس‌زمینه شناسایی و بخش‌های جدید برای اسلایدهای ایجاد شده ایجاد کنید.
3.	فریم Zoom خلاصه را به اسلاید اول اضافه کنید.
4.	پیشنهاد ارائه تغییر یافته را به عنوان فایل PPTX بنویسید.

این کد Java نشان می‌دهد چگونه فریم Zoom خلاصه را روی اسلاید ایجاد کنید:

``` java 
Presentation pres = new Presentation();
try {
    //یک اسلاید جدید به ارائه اضافه می‌کند
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.gray);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // یک بخش جدید به ارائه اضافه می‌کند
    pres.getSections().addSection("Section 1", slide);

    //یک اسلاید جدید به ارائه اضافه می‌کند
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // یک بخش جدید به ارائه اضافه می‌کند
    pres.getSections().addSection("Section 2", slide);

    //یک اسلاید جدید به ارائه اضافه می‌کند
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.magenta);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // یک بخش جدید به ارائه اضافه می‌کند
    pres.getSections().addSection("Section 3", slide);

    //یک اسلاید جدید به ارائه اضافه می‌کند
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.green);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // یک بخش جدید به ارائه اضافه می‌کند
    pres.getSections().addSection("Section 4", slide);

    // یک شیء SummaryZoomFrame اضافه می‌کند
    ISummaryZoomFrame summaryZoomFrame = pres.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200);

    // ارائه را ذخیره می‌کند
    pres.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **افزودن و حذف بخش Zoom خلاصه**

تمام بخش‌ها در فریم Zoom خلاصه توسط اشیای [ISummaryZoomSection](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ISummaryZoomSection) نمایش داده می‌شوند که در شیء [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ISummaryZoomSectionCollection) ذخیره می‌شوند. می‌توانید یک شیء بخش Zoom خلاصه را از طریق رابط [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ISummaryZoomSectionCollection) به این شکل اضافه یا حذف کنید:

1.	یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation) ایجاد کنید.
2.	اسلایدهای جدید با پس‌زمینه شناسایی و بخش‌های جدید برای اسلایدهای ایجاد شده ایجاد کنید.
3.	فریم Zoom خلاصه را به اسلاید اول اضافه کنید.
4.	یک اسلاید و بخش جدید به ارائه اضافه کنید.
5.	بخش ایجاد شده را به فریم Zoom خلاصه اضافه کنید.
6.	اولین بخش را از فریم Zoom خلاصه حذف کنید.
7.	پیشنهاد ارائه تغییر یافته را به عنوان فایل PPTX بنویسید.

این کد Java نشان می‌دهد چگونه بخش‌ها را در فریم Zoom خلاصه اضافه و حذف کنید:

``` java
Presentation pres = new Presentation();
try {
    //یک اسلاید جدید به ارائه اضافه می‌کند
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.gray);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // یک بخش جدید به ارائه اضافه می‌کند
    pres.getSections().addSection("Section 1", slide);

    //Adds a new slide to the presentation
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // یک بخش جدید به ارائه اضافه می‌کند
    pres.getSections().addSection("Section 2", slide);

    // یک شیء SummaryZoomFrame اضافه می‌کند
    ISummaryZoomFrame summaryZoomFrame = pres.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200);

    //Adds a new slide to the presentation
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.magenta);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // یک بخش جدید به ارائه اضافه می‌کند
    ISection section3 = pres.getSections().addSection("Section 3", slide);

    // یک بخش به Summary Zoom اضافه می‌کند
    summaryZoomFrame.getSummaryZoomCollection().addSummaryZoomSection(section3);

    // بخش را از Summary Zoom حذف می‌کند
    summaryZoomFrame.getSummaryZoomCollection().removeSummaryZoomSection(pres.getSections().get_Item(1));

    // ارائه را ذخیره می‌کند
    pres.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **قالب‌بندی بخش‌های Zoom خلاصه**

برای ایجاد اشیای بخش Zoom خلاصه پیچیده‌تر، باید قالب‌بندی یک فریم ساده را تغییر دهید. گزینه‌های قالب‌بندی متعددی می‌توانید بر روی یک شیء بخش Zoom خلاصه اعمال کنید. 

می‌توانید قالب‌بندی یک شیء بخش Zoom خلاصه را در فریم Zoom خلاصه به این شکل کنترل کنید:

1.	یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation) ایجاد کنید.
2.	اسلایدهای جدید با پس‌زمینه شناسایی و بخش‌های جدید برای اسلایدهای ایجاد شده ایجاد کنید.
3.	فریم Zoom خلاصه را به اسلاید اول اضافه کنید.
4.	یک شیء بخش Zoom خلاصه را از `ISummaryZoomSectionCollection` برای اولین شیء دریافت کنید.
7.	یک شیء [IPPImage](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IPPImage) با افزودن تصویر به مجموعه images مرتبط با شیء [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation) که برای پر کردن فریم استفاده می‌شود، ایجاد کنید.
8.	تصویر سفارشی برای شیء فریم Zoom بخش ایجاد شده تنظیم کنید.
9.	قابلیت *بازگشت به اسلاید اصلی از بخش لینک‌شده* را تنظیم کنید. 
11.	قالب خط برای شیء دوم فریم Zoom را تغییر دهید.
12.	مدت زمان انتقال را تغییر دهید.
13.	پیشنهاد ارائه تغییر یافته را به عنوان فایل PPTX بنویسید.

این کد Java نشان می‌دهد چگونه قالب‌بندی شیء بخش Zoom خلاصه را تغییر دهید:

``` java
Presentation pres = new Presentation();
try {
    //یک اسلاید جدید به ارائه اضافه می‌کند
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.gray);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // یک بخش جدید به ارائه اضافه می‌کند
    pres.getSections().addSection("Section 1", slide);

    //یک اسلاید جدید به ارائه اضافه می‌کند
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // یک بخش جدید به ارائه اضافه می‌کند
    pres.getSections().addSection("Section 2", slide);

    // یک شیء SummaryZoomFrame اضافه می‌کند
    ISummaryZoomFrame summaryZoomFrame = pres.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200);

    // اولین شیء SummaryZoomSection را دریافت می‌کند
    ISummaryZoomSection summarySection = summaryZoomFrame.getSummaryZoomCollection().get_Item(0);

    // قالب‌بندی برای شیء SummaryZoomSection
    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
    picture = pres.getImages().addImage(picture);
    } finally {
          if (image != null) image.dispose();
    }
    summarySection.setImage(picture);

    summarySection.setReturnToParent(false);

    summarySection.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    summarySection.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.black);
    summarySection.getLineFormat().setDashStyle(LineDashStyle.DashDot);
    summarySection.getLineFormat().setWidth(1.5f);

    summarySection.setTransitionDuration(1.5f);

    // ارائه را ذخیره می‌کند
    pres.save("presentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **پرسش‌های متداول**

**آیا می‌توانم بازگشت به اسلاید «مادر» پس از نمایش هدف را کنترل کنم؟**

بله. فریم [Zoom](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/zoomframe/) یا [section](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/sectionzoomframe/) دارای رفتار بازگشت به والد است که وقتی فعال می‌شود، مخاطبان را پس از بازدید از محتوای هدف به اسلاید مبدأ باز می‌گرداند.

**آیا می‌توانم «سرعت» یا مدت زمان انتقال Zoom را تنظیم کنم؟**

بله. Zoom از تنظیم مدت زمان انتقال پشتیبانی می‌کند تا بتوانید طول انیمیشن پرش را کنترل کنید.

**آیا محدودیتی برای تعداد اشیای Zoom که یک ارائه می‌تواند داشته باشد وجود دارد؟**

محدودیت سخت‌افزاری مستندی در API وجود ندارد. محدودیت‌های عملی به پیچیدگی کلی ارائه و عملکرد نمایشگر وابسته است. می‌توانید فریم‌های Zoom زیادی اضافه کنید، اما به حجم فایل و زمان رندر توجه داشته باشید.