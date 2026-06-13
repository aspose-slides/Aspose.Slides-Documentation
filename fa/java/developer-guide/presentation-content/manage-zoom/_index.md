---
title: مدیریت زوم ارائه در جاوا
linktitle: مدیریت زوم
type: docs
weight: 60
url: /fa/java/manage-zoom/
keywords:
- زوم
- قاب زوم
- زوم اسلاید
- زوم بخش
- زوم خلاصه
- اضافه کردن زوم
- PowerPoint
- ارائه
- Java
- Aspose.Slides
description: "ایجاد و سفارشی‌سازی زوم با Aspose.Slides برای جاوا — بین بخش‌ها پرش کنید، تصویرهای بندانگشتی و انتقال‌ها را در ارائه‌های PPT، PPTX و ODP اضافه کنید."
---
## **مقدمه**

Zoomها در PowerPoint به شما امکان می‌دهند تا به اسلایدها، بخش‌ها و قسمت‌های خاص یک ارائه بپرند و از آن‌ها بازگردند. هنگام ارائه، این قابلیت برای جابجایی سریع در محتوا می‌تواند بسیار مفید باشد.

![overview_image](overview.png)

* برای خلاصه‌کردن یک ارائه کامل در یک اسلاید، از [خلاصه زوم](#Summary-Zoom) استفاده کنید.
* برای نمایش فقط اسلایدهای انتخاب‌شده، از [اسلاید زوم](#Slide-Zoom) استفاده کنید.
* برای نمایش فقط یک بخش، از [بخش زوم](#Section-Zoom) استفاده کنید.

## **نزول اسلاید**

یک اسلاید زوم می‌تواند ارائه شما را دینامیک‌تر کند و به شما اجازه می‌دهد به‌طور آزادانه بین اسلایدها به هر ترتیبی که می‌خواهید حرکت کنید بدون اینکه جریان ارائه شما قطع شود. اسلاید زوم‌ها برای ارائه‌های کوتاه بدون بخش‌های متعدد عالی هستند، اما می‌توانید آن‌ها را در سناریوهای مختلف ارائه نیز به کار ببرید.

اسلاید زوم‌ها به شما کمک می‌کنند تا به‌صورت همزمان به اطلاعات متعدد دسترسی پیدا کنید در حالی که حس می‌کنید روی یک بوم واحد هستید.

![overview_image](slidezoomsel.png)

برای اشیای اسلاید زوم، Aspose.Slides شمارش‌گر [ZoomImageType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ZoomImageType)، رابط [IZoomFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IZoomFrame) و برخی متدها زیر رابط [IShapeCollection](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IShapeCollection) را فراهم می‌کند.

### **ایجاد قاب‌های زوم**

می‌توانید یک قاب زوم را به اسلاید اضافه کنید به این روش:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation) ایجاد کنید.
2. اسلایدهای جدیدی که می‌خواهید به آن‌ها قاب زوم لینک شود، ایجاد کنید. 
3. متنی برای شناسایی و پس‌زمینه‌ای به اسلایدهای ایجاد شده اضافه کنید.
4. قاب‌های زوم (که شامل ارجاع به اسلایدهای ایجاد شده هستند) را به اسلاید اول اضافه کنید.
5. ارائه تغییر یافته را به‌عنوان فایل PPTX ذخیره کنید.

این کد Java نشان می‌دهد چگونه یک قاب زوم را بر روی اسلاید ایجاد کنید:

``` java
Presentation pres = new Presentation();
try {
    //اسلایدهای جدید را به ارائه اضافه می‌کند
    ISlide slide2 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    ISlide slide3 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());

    // پس‌زمینه‌ای برای اسلاید دوم ایجاد می‌کند
    slide2.getBackground().setType(BackgroundType.OwnBackground);
    slide2.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide2.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);

    // یک جعبه متن برای اسلاید دوم ایجاد می‌کند
    IAutoShape autoshape = slide2.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Second Slide");

    // پس‌زمینه‌ای برای اسلاید سوم ایجاد می‌کند
    slide3.getBackground().setType(BackgroundType.OwnBackground);
    slide3.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide3.getBackground().getFillFormat().getSolidFillColor().setColor(Color.darkGray);

    // یک جعبه متن برای اسلاید سوم ایجاد می‌کند
    autoshape = slide3.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Trird Slide");

    //اشیای ZoomFrame را اضافه می‌کند
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 250, 200, slide2);
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(200, 250, 250, 200, slide3);

    // ارائه را ذخیره می‌کند
    pres.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```
### **ایجاد قاب‌های زوم با تصاویر سفارشی**

با Aspose.Slides برای Java می‌توانید یک قاب زوم با تصویر پیش‌نمایش اسلاید متفاوت ایجاد کنید به این شکل: 
1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation) ایجاد کنید.
2. اسلاید جدیدی که می‌خواهید به آن قاب زوم لینک شود، ایجاد کنید. 
3. متنی برای شناسایی و پس‌زمینه‌ای به اسلاید اضافه کنید.
4. یک شیء [IPPImage](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IPPImage) با افزودن یک تصویر به مجموعه Images مرتبط با شیء [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation) که برای پر کردن قاب استفاده خواهد شد، ایجاد کنید.
5. قاب‌های زوم (که شامل ارجاع به اسلاید ایجاد شده هستند) را به اسلاید اول اضافه کنید.
6. ارائه تغییر یافته را به‌عنوان فایل PPTX ذخیره کنید.

این کد Java نشان می‌دهد چگونه یک قاب زوم با تصویر متفاوت ایجاد کنید:

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
    //اشیای ZoomFrame را اضافه می‌کند
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 300, 200, slide, picture);

    // ارائه را ذخیره می‌کند
    pres.save("presentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```
### **قالب‌بندی قاب‌های زوم**

در بخش‌های قبلی، نحوه ایجاد قاب‌های زوم ساده را نشان دادیم. برای ایجاد قاب‌های زوم پیچیده‌تر، باید قالب‌بندی یک قاب ساده را تغییر دهید. گزینه‌های قالب‌بندی متعددی می‌توانید روی یک قاب زوم اعمال کنید. 

می‌توانید قالب‌بندی یک قاب زوم را روی اسلاید به این شکل کنترل کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation) ایجاد کنید.
2. اسلایدهای جدیدی که می‌خواهید به آن‌ها قاب زوم لینک شود، ایجاد کنید. 
3. متنی برای شناسایی و پس‌زمینه‌ای به اسلایدهای ایجاد شده اضافه کنید.
4. قاب‌های زوم (که شامل ارجاع به اسلایدهای ایجاد شده هستند) را به اسلاید اول اضافه کنید.
5. یک شیء [IPPImage](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IPPImage) با افزودن یک تصویر به مجموعه Images مرتبط با شیء [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation) که برای پر کردن قاب استفاده خواهد شد، ایجاد کنید.
6. تصویر سفارشی را برای اولین قاب زوم تنظیم کنید.
7. قالب خط را برای دومین قاب زوم تغییر دهید.
8. پس‌زمینه تصویر دومین قاب زوم را حذف کنید.
5. ارائه تغییر یافته را به‌عنوان فایل PPTX ذخیره کنید.

این کد Java نشان می‌دهد چگونه قالب یک قاب زوم را روی اسلاید تغییر دهید: 

``` java 
Presentation pres = new Presentation();
try {
    //    اسلایدهای جدید را به ارائه اضافه می‌کند
    ISlide slide2 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    ISlide slide3 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());

    //    یک پس‌زمینه برای اسلاید دوم ایجاد می‌کند
    slide2.getBackground().setType(BackgroundType.OwnBackground);
    slide2.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide2.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);

    //    یک جعبه متن برای اسلاید دوم ایجاد می‌کند
    IAutoShape autoshape = slide2.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Second Slide");

    //    یک پس‌زمینه برای اسلاید سوم ایجاد می‌کند
    slide3.getBackground().setType(BackgroundType.OwnBackground);
    slide3.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide3.getBackground().getFillFormat().getSolidFillColor().setColor(Color.darkGray);

    //    یک جعبه متن برای اسلاید سوم ایجاد می‌کند
    autoshape = slide3.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Trird Slide");

    //    اشیای ZoomFrame را اضافه می‌کند
    IZoomFrame zoomFrame1 = pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 250, 200, slide2);
    IZoomFrame zoomFrame2 = pres.getSlides().get_Item(0).getShapes().addZoomFrame(200, 250, 250, 200, slide3);

    //    یک تصویر جدید برای شیء زوم ایجاد می‌کند
    IPPImage picture;
        IImage image = Images.fromFile("image.png");
        try {
            picture = pres.getImages().addImage(image);
        } finally {
            if (image != null) image.dispose();
        }
    //    تصویر سفارشی را برای شیء zoomFrame1 تنظیم می‌کند
    zoomFrame1.setImage(picture);

    //    قالب قاب زوم را برای شیء zoomFrame2 تنظیم می‌کند
    zoomFrame2.getLineFormat().setWidth(5);
    zoomFrame2.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    zoomFrame2.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.pink);
    zoomFrame2.getLineFormat().setDashStyle(LineDashStyle.DashDot);

    //    تنظیم برای عدم نمایش پس‌زمینه برای شیء zoomFrame2
    zoomFrame2.setShowBackground(false);

    //    ارائه را ذخیره می‌کند
    pres.save("presentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **بخش زوم**

یک بخش زوم یک لینک به یک بخش در ارائه شماست. می‌توانید از بخش زوم برای بازگشت به بخش‌هایی استفاده کنید که می‌خواهید به‌طور ویژه تأکید کنید. یا می‌توانید از آن برای نشان دادن نحوه ارتباط بخش‌های مختلف ارائه استفاده کنید. 

![overview_image](seczoomsel.png)

برای اشیای بخش زوم، Aspose.Slides رابط [ISectionZoomFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ISectionZoomFrame) و برخی متدها زیر رابط [IShapeCollection](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IShapeCollection) را فراهم می‌کند.

### **ایجاد قاب‌های بخش زوم**

می‌توانید یک قاب بخش زوم را به اسلاید اضافه کنید به این روش:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation) ایجاد کنید.
2. یک اسلاید جدید ایجاد کنید. 
3. پس‌زمینه‌ای برای شناسایی به اسلاید ایجاد شده اضافه کنید.
4. یک بخش جدید که می‌خواهید به آن قاب زوم لینک شود، ایجاد کنید. 
5. یک قاب بخش زوم (که شامل ارجاع به بخش ایجاد شده است) را به اسلاید اول اضافه کنید.
6. ارائه تغییر یافته را به‌عنوان فایل PPTX ذخیره کنید.

این کد Java نشان می‌دهد چگونه یک قاب زوم را بر روی اسلاید ایجاد کنید:

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

    // یک شیء SectionZoomFrame اضافه می‌کند
    ISectionZoomFrame sectionZoomFrame = pres.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, pres.getSections().get_Item(1));

    // ارائه را ذخیره می‌کند
    pres.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```
### **ایجاد قاب‌های بخش زوم با تصاویر سفارشی**

با Aspose.Slides برای Java می‌توانید یک قاب بخش زوم با تصویر پیش‌نمایش اسلاید متفاوت ایجاد کنید به این شکل: 

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation) ایجاد کنید.
2. یک اسلاید جدید ایجاد کنید.
3. پس‌زمینه‌ای برای شناسایی به اسلاید ایجاد شده اضافه کنید.
4. یک بخش جدید که می‌خواهید به آن قاب زوم لینک شود، ایجاد کنید. 
5. یک شیء [IPPImage](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IPPImage) با افزودن یک تصویر به مجموعه Images مرتبط با شیء [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation) که برای پر کردن قاب استفاده خواهد شد، ایجاد کنید.
5. یک قاب بخش زوم (که شامل ارجاع به بخش ایجاد شده است) را به اسلاید اول اضافه کنید.
6. ارائه تغییر یافته را به‌عنوان فایل PPTX ذخیره کنید.

این کد Java نشان می‌دهد چگونه یک قاب زوم با تصویر متفاوت ایجاد کنید:

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

    // یک تصویر جدید برای شیء زوم ایجاد می‌کند
    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // یک شیء SectionZoomFrame اضافه می‌کند
    ISectionZoomFrame sectionZoomFrame = pres.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, pres.getSections().get_Item(1), picture);

    // ارائه را ذخیره می‌کند
    pres.save("presentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```
### **قالب‌بندی قاب‌های بخش زوم**

برای ایجاد قاب‌های بخش زوم پیچیده‌تر، باید قالب‌بندی یک قاب ساده را تغییر دهید. گزینه‌های قالب‌بندی متعددی می‌توانید روی یک قاب بخش زوم اعمال کنید. 

می‌توانید قالب‌بندی یک قاب بخش زوم را روی اسلاید به این شکل کنترل کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation) ایجاد کنید.
2. یک اسلاید جدید ایجاد کنید.
3. پس‌زمینه‌ای برای شناسایی به اسلاید ایجاد شده اضافه کنید.
4. یک بخش جدید که می‌خواهید به آن قاب زوم لینک شود، ایجاد کنید. 
5. یک قاب بخش زوم (که شامل ارجاع به بخش ایجاد شده است) را به اسلاید اول اضافه کنید.
6. اندازه و موقعیت شیء بخش زوم ایجاد‌شده را تغییر دهید.
7. یک شیء [IPPImage](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IPPImage) با افزودن یک تصویر به مجموعه Images مرتبط با شیء [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation) که برای پر کردن قاب استفاده خواهد شد، ایجاد کنید.
8. تصویر سفارشی را برای قاب بخش زوم تنظیم کنید.
9. قابلیت *بازگشت به اسلاید اصلی از بخش پیوندخورده* را فعال کنید. 
10. پس‌زمینه تصویر قاب بخش زوم را حذف کنید.
11. قالب خط را برای دومین قاب زوم تغییر دهید.
12. مدت زمان انتقال را تغییر دهید.
13. ارائه تغییر یافته را به‌عنوان فایل PPTX ذخیره کنید.

این کد Java نشان می‌دهد چگونه قالب یک قاب بخش زوم را تغییر دهید:

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

    // یک شیء SectionZoomFrame اضافه می‌کند
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

## **خلاصه زوم**

یک خلاصه زوم شبیه یک صفحه فرود است که تمام بخش‌های ارائه شما به‌صورت همزمان نمایش داده می‌شود. هنگام ارائه می‌توانید از این زوم برای رفتن از یک نقطه به نقطه دیگر به هر ترتیبی که می‌خواهید استفاده کنید. می‌توانید خلاق باشید، پیش‌روی کنید یا به بخش‌های مختلف اسلایدشو بازگردید بدون اینکه جریان ارائه شما قطع شود.

![overview_image](sumzoomsel.png)

برای اشیای خلاصه زوم، Aspose.Slides رابط‌های [ISummaryZoomFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ISummaryZoomFrame)، [ISummaryZoomSection](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ISummaryZoomSection) و [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ISummaryZoomSectionCollection) و برخی متدها زیر رابط [IShapeCollection](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IShapeCollection) را فراهم می‌کند.

### **ایجاد یک خلاصه زوم**

می‌توانید یک قاب خلاصه زوم را به اسلاید اضافه کنید به این روش:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation) ایجاد کنید.
2. اسلایدهای جدیدی با پس‌زمینه شناسایی و بخش‌های جدید برای اسلایدهای ایجاد شده ایجاد کنید.
3. قاب خلاصه زوم را به اسلاید اول اضافه کنید.
4. ارائه تغییر یافته را به‌عنوان فایل PPTX ذخیره کنید.

این کد Java نشان می‌دهد چگونه یک قاب خلاصه زوم را بر روی اسلاید ایجاد کنید:

``` java 
Presentation pres = new Presentation();
try {
    //Adds a new slide to the presentation
    // یک اسلاید جدید به ارائه اضافه می‌کند
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.gray);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Adds a new section to the presentation
    // یک بخش جدید به ارائه اضافه می‌کند
    pres.getSections().addSection("Section 1", slide);

    //Adds a new slide to the presentation
    // یک اسلاید جدید به ارائه اضافه می‌کند
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Adds a new section to the presentation
    // یک بخش جدید به ارائه اضافه می‌کند
    pres.getSections().addSection("Section 2", slide);

    //Adds a new slide to the presentation
    // یک اسلاید جدید به ارائه اضافه می‌کند
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.magenta);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Adds a new section to the presentation
    // یک بخش جدید به ارائه اضافه می‌کند
    pres.getSections().addSection("Section 3", slide);

    //Adds a new slide to the presentation
    // یک اسلاید جدید به ارائه اضافه می‌کند
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.green);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Adds a new section to the presentation
    // یک بخش جدید به ارائه اضافه می‌کند
    pres.getSections().addSection("Section 4", slide);

    // Adds a SummaryZoomFrame object
    // یک شیء SummaryZoomFrame اضافه می‌کند
    ISummaryZoomFrame summaryZoomFrame = pres.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200);

    // Saves the presentation
    // ارائه را ذخیره می‌کند
    pres.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **افزودن و حذف یک بخش خلاصه زوم**

تمام بخش‌ها در یک قاب خلاصه زوم توسط اشیای [ISummaryZoomSection](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ISummaryZoomSection) نمایند که در شیء [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ISummaryZoomSectionCollection) ذخیره می‌شوند. می‌توانید یک بخش خلاصه زوم را از طریق رابط [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ISummaryZoomSectionCollection) اضافه یا حذف کنید به این شکل:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation) ایجاد کنید.
2. اسلایدهای جدیدی با پس‌زمینه شناسایی و بخش‌های جدید برای اسلایدهای ایجاد شده ایجاد کنید.
3. یک قاب خلاصه زوم را به اسلاید اول اضافه کنید.
4. یک اسلاید و بخش جدید به ارائه اضافه کنید.
5. بخش ایجادشده را به قاب خلاصه زوم اضافه کنید.
6. اولین بخش را از قاب خلاصه زوم حذف کنید.
7. ارائه تغییر یافته را به‌عنوان فایل PPTX ذخیره کنید.

این کد Java نشان می‌دهد چگونه بخش‌ها را در یک قاب خلاصه زوم اضافه و حذف کنید:

``` java
Presentation pres = new Presentation();
try {
    //Adds a new slide to the presentation
    //یک اسلاید جدید به ارائه اضافه می‌کند
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.gray);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Adds a new section to the presentation
    // یک بخش جدید به ارائه اضافه می‌کند
    pres.getSections().addSection("Section 1", slide);

    //Adds a new slide to the presentation
    //یک اسلاید جدید به ارائه اضافه می‌کند
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Adds a new section to the presentation
    // یک بخش جدید به ارائه اضافه می‌کند
    pres.getSections().addSection("Section 2", slide);

    // Adds SummaryZoomFrame object
    // یک شیء SummaryZoomFrame اضافه می‌کند
    ISummaryZoomFrame summaryZoomFrame = pres.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200);

    //Adds a new slide to the presentation
    //یک اسلاید جدید به ارائه اضافه می‌کند
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.magenta);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Adds a new section to the presentation
    // یک بخش جدید به ارائه اضافه می‌کند
    ISection section3 = pres.getSections().addSection("Section 3", slide);

    // Adds a section to the Summary Zoom
    // یک بخش به Summary Zoom اضافه می‌کند
    summaryZoomFrame.getSummaryZoomCollection().addSummaryZoomSection(section3);

    // Removes section from the Summary Zoom
    // بخش را از Summary Zoom حذف می‌کند
    summaryZoomFrame.getSummaryZoomCollection().removeSummaryZoomSection(pres.getSections().get_Item(1));

    // Saves the presentation
    // ارائه را ذخیره می‌کند
    pres.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **قالب‌بندی بخش‌های خلاصه زوم**

برای ایجاد اشیای بخش خلاصه زوم پیچیده‌تر، باید قالب‌بندی یک قاب ساده را تغییر دهید. گزینه‌های قالب‌بندی متعددی می‌توانید روی یک شیء بخش خلاصه زوم اعمال کنید. 

می‌توانید قالب‌بندی یک شیء بخش خلاصه زوم را در یک قاب خلاصه زوم به این شکل کنترل کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation) ایجاد کنید.
2. اسلایدهای جدیدی با پس‌زمینه شناسایی و بخش‌های جدید برای اسلایدهای ایجاد شده ایجاد کنید.
3. یک قاب خلاصه زوم را به اسلاید اول اضافه کنید.
4. یک شیء بخش خلاصه زوم برای اولین شیء از `ISummaryZoomSectionCollection` دریافت کنید.
7. یک شیء [IPPImage](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IPPImage) با افزودن یک تصویر به مجموعه images مرتبط با شیء [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation) که برای پر کردن قاب استفاده خواهد شد، ایجاد کنید.
8. تصویر سفارشی را برای شیء بخش زوم ایجاد‌شده تنظیم کنید.
9. قابلیت *بازگشت به اسلاید اصلی از بخش پیوندخورده* را فعال کنید. 
11. قالب خط را برای دومین قاب زوم تغییر دهید.
12. مدت زمان انتقال را تغییر دهید.
13. ارائه تغییر یافته را به‌عنوان فایل PPTX ذخیره کنید.

این کد Java نشان می‌دهد چگونه قالب یک شیء بخش خلاصه زوم را تغییر دهید:

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

**آیا می‌توانم بازگشت به اسلاید «والد» را پس از نمایش هدف کنترل کنم؟**

بله. قاب [Zoom frame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/zoomframe/) یا [section](https://reference.aspose.com/slides/fa/java/com.aspose.slides/sectionzoomframe/) رفتار `ReturnToParent` دارد که هنگام فعال‌سازی، بیننده را پس از بازدید از محتوای هدف به اسلاید اصلی بازمی‌گرداند.

**آیا می‌توانم «سرعت» یا مدت زمان انتقال زوم را تنظیم کنم؟**

بله. زوم از تنظیم `TransitionDuration` پشتیبانی می‌کند تا بتوانید مدت زمان انیمیشن پرش را کنترل کنید.

**آیا محدودیتی برای تعداد اشیای زوم در یک ارائه وجود دارد؟**

هیچ محدودیت سخت‌گیرانه‌ای در مستندات API ذکر نشده است. محدودیت‌های عملی به پیچیدگی کلی ارائه و عملکرد دستگاه نمایش‌دهنده بستگی دارد. می‌توانید تعداد زیادی قاب زوم اضافه کنید، اما به حجم فایل و زمان رندرینگ توجه داشته باشید.