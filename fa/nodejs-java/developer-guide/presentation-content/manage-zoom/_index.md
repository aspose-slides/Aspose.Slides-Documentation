---
title: مدیریت زوم ارائه در جاوااسکریپت
linktitle: مدیریت زوم
type: docs
weight: 60
url: /fa/nodejs-java/manage-zoom/
keywords:
- زوم
- قاب زوم
- زوم اسلاید
- زوم بخش
- زوم خلاصه
- افزودن زوم
- PowerPoint
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "ایجاد و سفارشی‌سازی زوم با Aspose.Slides برای Node.js — پرش بین بخش‌ها، افزودن تصویرهای کوچک و انتقال‌ها در ارائه‌های PPT، PPTX و ODP."
---
## **مقدمه**

Zoomهای PowerPoint به شما امکان می‌دهند به اسلایدها، بخش‌ها و قسمت‌های خاصی از یک ارائه بروید و از آن‌ها خارج شوید. هنگام ارائه، این قابلیت برای حرکت سریع در میان محتوا بسیار مفید است. 

![تصویر_نمایش_کلی](overview.png)

* برای خلاصه‌کردن تمام ارائه در یک اسلاید، از [Summary Zoom](#Summary-Zoom) استفاده کنید.
* برای نمایش تنها اسلایدهای انتخابی، از [Slide Zoom](#Slide-Zoom) استفاده کنید.
* برای نمایش تنها یک بخش، از [Section Zoom](#Section-Zoom) استفاده کنید.

## **Slide Zoom**

یک Slide Zoom می‌تواند ارائه شما را پویاتر کند و به شما اجازه دهد بین اسلایدها به هر ترتیبی که می‌خواهید حرکت کنید بدون اینکه جریان ارائه مختل شود. Slide Zoomها برای ارائه‌های کوتاه بدون بخش‌های زیاد مناسب هستند، اما می‌توانید آن‌ها را در سناریوهای مختلف ارائه به کار ببرید.

Slide Zoomها به شما امکان می‌دهند چندین قطعه اطلاعات را در یک بوم واحد کاوش کنید. 

![تصویر_نمایش_کلی](slidezoomsel.png)

برای اشیاء Slide Zoom، Aspose.Slides مقدارهای [ZoomImageType](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/ZoomImageType) ، کلاس [ZoomFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/ZoomFrame) و برخی متدها در کلاس [ShapeCollection](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/ShapeCollection) را فراهم می‌کند.

### **ایجاد Zoom Frame‌ها**

می‌توانید یک Zoom Frame را به یک اسلاید به این شکل اضافه کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Presentation) ایجاد کنید.
2. اسلایدهای جدیدی که می‌خواهید به آن‌ها لینک دهید، بسازید. 
3. متنی برای شناسایی و پس‌زمینه‌ای به اسلایدهای ساخته شده اضافه کنید.
4. Zoom Frame‌ها (که شامل ارجاع به اسلایدهای ساخته شده هستند) را به اسلاید اول اضافه کنید.
5. ارائهٔ تغییر یافته را به صورت فایل PPTX ذخیره کنید.

این کد JavaScript نشان می‌دهد چگونه یک Zoom Frame بر روی اسلاید ایجاد کنید:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // اسلایدهای جدید را به ارائه اضافه می‌کند
    var slide2 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    var slide3 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    // یک پس‌زمینه برای اسلاید دوم ایجاد می‌کند
    slide2.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    slide2.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide2.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "cyan"));
    // یک جعبهٔ متن برای اسلاید دوم ایجاد می‌کند
    var autoshape = slide2.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Second Slide");
    // یک پس‌زمینه برای اسلاید سوم ایجاد می‌کند
    slide3.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    slide3.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide3.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "darkGray"));
    // یک جعبهٔ متن برای اسلاید سوم ایجاد می‌کند
    autoshape = slide3.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Trird Slide");
    // اشیای ZoomFrame را اضافه می‌کند
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 250, 200, slide2);
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(200, 250, 250, 200, slide3);
    // ارائه را ذخیره می‌کند
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **ایجاد Zoom Frame‌ها با تصاویر سفارشی**

با Aspose.Slides برای Node.js via Java می‌توانید یک Zoom Frame با تصویر پیش‌نمایش متفاوتی ایجاد کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Presentation) ایجاد کنید.
2. اسلاید جدیدی که می‌خواهید به آن لینک دهید، بسازید. 
3. متنی برای شناسایی و پس‌زمینه‌ای به اسلاید اضافه کنید.
4. یک شیء [PPImage](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/PPImage) با افزودن تصویر به مجموعه Images که به شیء [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Presentation) مرتبط است، ایجاد کنید تا فریم را پر کند.
5. Zoom Frame‌ها (که شامل ارجاع به اسلاید ساخته شده هستند) را به اسلاید اول اضافه کنید.
6. ارائهٔ تغییر یافته را به صورت فایل PPTX ذخیره کنید.

این کد JavaScript نشان می‌دهد چگونه یک Zoom Frame با تصویر متفاوت ایجاد کنید:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // یک اسلاید جدید به ارائه اضافه می‌کند
    var slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    // یک پس‌زمینه برای اسلاید دوم ایجاد می‌کند
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "cyan"));
    // یک جعبهٔ متن برای اسلاید سوم ایجاد می‌کند
    var autoshape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Second Slide");
    // یک تصویر جدید برای شیء زوم ایجاد می‌کند
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // شیء ZoomFrame را اضافه می‌کند
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 300, 200, slide, picture);
    // ارائه را ذخیره می‌کند
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **قالب‌بندی Zoom Frame‌ها**

در بخش‌های قبلی نحوهٔ ایجاد Zoom Frameهای ساده را نشان دادیم. برای ایجاد Zoom Frameهای پیچیده‌تر، باید قالب‌بندی یک فریم ساده را تغییر دهید. گزینه‌های قالب‌بندی متعددی می‌توانید بر روی یک Zoom Frame اعمال کنید. 

می‌توانید قالب‌بندی یک Zoom Frame را بر روی اسلاید به این طریق کنترل کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Presentation) ایجاد کنید.
2. اسلایدهای جدیدی که می‌خواهید به آن‌ها لینک دهید، ایجاد کنید. 
3. متنی برای شناسایی و پس‌زمینه‌ای به اسلایدهای ساخته شده اضافه کنید.
4. Zoom Frame‌ها (که شامل ارجاع به اسلایدهای ساخته شده هستند) را به اسلاید اول اضافه کنید.
5. یک شیء [PPImage](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/PPImage) با افزودن تصویر به مجموعه Images مرتبط با شیء [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Presentation) ایجاد کنید تا فریم را پر کند.
6. تصویر سفارشی برای اولین شیء Zoom Frame تنظیم کنید.
7. قالب خط برای دومین شیء Zoom Frame را تغییر دهید.
8. پس‌زمینهٔ تصویر دومین شیء Zoom Frame را حذف کنید.
5. ارائهٔ تغییر یافته را به صورت فایل PPTX ذخیره کنید.

این کد JavaScript نشان می‌دهد چگونه قالب‌بندی یک Zoom Frame را بر روی اسلاید تغییر دهید:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // اسلایدهای جدید را به ارائه اضافه می‌کند
    var slide2 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    var slide3 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    // یک پس‌زمینه برای اسلاید دوم ایجاد می‌کند
    slide2.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    slide2.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide2.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "cyan"));
    // یک جعبهٔ متن برای اسلاید دوم ایجاد می‌کند
    var autoshape = slide2.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Second Slide");
    // یک پس‌زمینه برای اسلاید سوم ایجاد می‌کند
    slide3.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    slide3.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide3.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "darkGray"));
    // یک جعبهٔ متن برای اسلاید سوم ایجاد می‌کند
    autoshape = slide3.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Trird Slide");
    // اشیای ZoomFrame را اضافه می‌کند
    var zoomFrame1 = pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 250, 200, slide2);
    var zoomFrame2 = pres.getSlides().get_Item(0).getShapes().addZoomFrame(200, 250, 250, 200, slide3);
    // یک تصویر جدید برای شیء زوم ایجاد می‌کند
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // تصویر سفارشی را برای شیء zoomFrame1 تنظیم می‌کند
    zoomFrame1.setImage(picture);
    // یک قالب فریم زوم را برای شیء zoomFrame2 تنظیم می‌کند
    zoomFrame2.getLineFormat().setWidth(5);
    zoomFrame2.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    zoomFrame2.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "pink"));
    zoomFrame2.getLineFormat().setDashStyle(aspose.slides.LineDashStyle.DashDot);
    // تنظیم برای عدم نمایش پس‌زمینه برای شیء zoomFrame2
    zoomFrame2.setShowBackground(false);
    // ارائه را ذخیره می‌کند
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Section Zoom**

یک Section Zoom لینک به یک بخش در ارائهٔ شماست. می‌توانید از Section Zoomها برای بازگشت به بخش‌هایی که می‌خواهید به‌طور خاص برجسته کنید استفاده کنید. یا می‌توانید از آن‌ها برای نشان دادن نحوهٔ ارتباط بخش‌های مختلف استفاده کنید. 

![تصویر_نمایش_کلی](seczoomsel.png)

برای اشیاء Section Zoom، Aspose.Slides کلاس [SectionZoomFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/SectionZoomFrame) و برخی متدها را در کلاس [ShapeCollection](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/ShapeCollection) فراهم می‌کند.

### **ایجاد Section Zoom Frame‌ها**

می‌توانید یک Section Zoom Frame را به اسلاید اضافه کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Presentation) ایجاد کنید.
2. اسلاید جدیدی ایجاد کنید. 
3. پس‌زمینهٔ شناسایی به اسلاید ساخته شده اضافه کنید.
4. یک بخش جدید که می‌خواهید به آن لینک دهید، ایجاد کنید. 
5. یک Section Zoom Frame (که شامل ارجاع به بخش ساخته شده است) را به اسلاید اول اضافه کنید.
6. ارائهٔ تغییر یافته را به صورت فایل PPTX ذخیره کنید.

این کد JavaScript نشان می‌دهد چگونه یک Zoom Frame بر روی اسلاید ایجاد کنید:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // یک اسلاید جدید به ارائه اضافه می‌کند
    var slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "yellow"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // یک بخش جدید به ارائه اضافه می‌کند
    pres.getSections().addSection("Section 1", slide);
    // یک شیء SectionZoomFrame اضافه می‌کند
    var sectionZoomFrame = pres.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, pres.getSections().get_Item(1));
    // ارائه را ذخیره می‌کند
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **ایجاد Section Zoom Frame‌ها با تصاویر سفارشی**

با استفاده از Aspose.Slides برای Node.js via Java می‌توانید یک Section Zoom Frame با تصویر پیش‌نمایش متفاوتی ایجاد کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Presentation) ایجاد کنید.
2. اسلاید جدیدی ایجاد کنید.
3. پس‌زمینهٔ شناسایی به اسلاید ساخته شده اضافه کنید.
4. یک بخش جدید که می‌خواهید به آن لینک دهید، ایجاد کنید. 
5. یک شیء [PPImage](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/PPImage) با افزودن تصویر به مجموعه Images مرتبط با شیء [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Presentation) ایجاد کنید تا فریم را پر کند.
5. یک Section Zoom Frame (که شامل ارجاع به بخش ساخته شده است) را به اسلاید اول اضافه کنید.
6. ارائهٔ تغییر یافته را به صورت فایل PPTX ذخیره کنید.

این کد JavaScript نشان می‌دهد چگونه یک Zoom Frame با تصویر متفاوت ایجاد کنید:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // اسلاید جدیدی به ارائه اضافه می‌کند
    var slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "yellow"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // یک بخش جدید به ارائه اضافه می‌کند
    pres.getSections().addSection("Section 1", slide);
    // یک تصویر جدید برای شیء زوم ایجاد می‌کند
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // شیء SectionZoomFrame را اضافه می‌کند
    var sectionZoomFrame = pres.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, pres.getSections().get_Item(1), picture);
    // ارائه را ذخیره می‌کند
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **قالب‌بندی Section Zoom Frame‌ها**

برای ایجاد Section Zoom Frameهای پیچیده‌تر، باید قالب‌بندی یک فریم ساده را تغییر دهید. گزینه‌های قالب‌بندی مختلفی می‌توانید بر یک Section Zoom Frame اعمال کنید. 

می‌توانید قالب‌بندی یک Section Zoom Frame را بر روی اسلاید به این روش کنترل کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Presentation) ایجاد کنید.
2. اسلاید جدیدی ایجاد کنید.
3. پس‌زمینهٔ شناسایی به اسلاید ساخته شده اضافه کنید.
4. یک بخش جدید که می‌خواهید به آن لینک دهید، ایجاد کنید. 
5. یک Section Zoom Frame (که شامل ارجاع به بخش ساخته شده است) را به اسلاید اول اضافه کنید.
6. اندازه و موقعیت شیء Section Zoom ساخته شده را تغییر دهید.
7. یک شیء [PPImage](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/PPImage) با افزودن تصویر به مجموعه Images مرتبط با شیء [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Presentation) ایجاد کنید تا فریم را پر کند.
8. تصویر سفارشی برای شیء Section Zoom ساخته شده تنظیم کنید.
9. قابلیت *بازگشت به اسلاید اصلی از بخش لینک‌شده* را فعال کنید. 
10. پس‌زمینهٔ تصویر شیء Section Zoom را حذف کنید.
11. قالب خط برای دومین شیء Zoom Frame را تغییر دهید.
12. مدت زمان انتقال را تغییر دهید.
13. ارائهٔ تغییر یافته را به صورت فایل PPTX ذخیره کنید.

این کد JavaScript نشان می‌دهد چگونه قالب‌بندی یک Section Zoom Frame را تغییر دهید:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // یک اسلاید جدید به ارائه اضافه می‌کند
    var slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "yellow"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // یک بخش جدید به ارائه اضافه می‌کند
    pres.getSections().addSection("Section 1", slide);
    // یک شیء SectionZoomFrame اضافه می‌کند
    var sectionZoomFrame = pres.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, pres.getSections().get_Item(1));
    // قالب‌بندی برای SectionZoomFrame
    sectionZoomFrame.setX(100);
    sectionZoomFrame.setY(300);
    sectionZoomFrame.setWidth(100);
    sectionZoomFrame.setHeight(75);
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    sectionZoomFrame.setImage(picture);
    sectionZoomFrame.setReturnToParent(true);
    sectionZoomFrame.setShowBackground(false);
    sectionZoomFrame.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    sectionZoomFrame.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "gray"));
    sectionZoomFrame.getLineFormat().setDashStyle(aspose.slides.LineDashStyle.DashDot);
    sectionZoomFrame.getLineFormat().setWidth(2.5);
    sectionZoomFrame.setTransitionDuration(1.5);
    // ارائه را ذخیره می‌کند
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Summary Zoom**

یک Summary Zoom شبیه یک صفحهٔ فرود است که تمام بخش‌های ارائهٔ شما به‌طور همزمان نمایش داده می‌شوند. هنگام ارائه می‌توانید از Zoom برای رفتن از یک محل به محل دیگر در هر ترتیب دلخواه استفاده کنید. می‌توانید خلاق باشید، جلو بپرید یا بخش‌هایی از نمایش اسلاید را بدون قطع جریان ارائه دوباره بازبینی کنید.

![تصویر_نمایش_کلی](sumzoomsel.png)

برای اشیاء Summary Zoom، Aspose.Slides کلاس‌های [SummaryZoomFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/SummaryZoomFrame)، [SummaryZoomSection](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/SummaryZoomSection) و [SummaryZoomSectionCollection](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/SummaryZoomSectionCollection) و برخی متدها را در کلاس [ShapeCollection](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/ShapeCollection) ارائه می‌دهد.

### **ایجاد Summary Zoom**

می‌توانید یک Summary Zoom Frame را به اسلاید اضافه کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Presentation) ایجاد کنید.
2. اسلایدهای جدیدی با پس‌زمینهٔ شناسایی و بخش‌های جدید برای اسلایدهای ساخته شده بسازید.
3. Summary Zoom Frame را به اسلاید اول اضافه کنید.
4. ارائهٔ تغییر یافته را به صورت فایل PPTX ذخیره کنید.

این کد JavaScript نشان می‌دهد چگونه یک Summary Zoom Frame بر روی اسلاید ایجاد کنید:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // یک اسلاید جدید به ارائه اضافه می‌کند
    var slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "gray"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // یک بخش جدید به ارائه اضافه می‌کند
    pres.getSections().addSection("Section 1", slide);
    // یک اسلاید جدید به ارائه اضافه می‌کند
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "cyan"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // یک بخش جدید به ارائه اضافه می‌کند
    pres.getSections().addSection("Section 2", slide);
    // یک اسلاید جدید به ارائه اضافه می‌کند
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "magenta"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // یک بخش جدید به ارائه اضافه می‌کند
    pres.getSections().addSection("Section 3", slide);
    // یک اسلاید جدید به ارائه اضافه می‌کند
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "green"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // یک بخش جدید به ارائه اضافه می‌کند
    pres.getSections().addSection("Section 4", slide);
    // یک شیء SummaryZoomFrame اضافه می‌کند
    var summaryZoomFrame = pres.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200);
    // ارائه را ذخیره می‌کند
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **افزودن و حذف بخش‌های Summary Zoom**

تمام بخش‌های یک Summary Zoom Frame توسط اشیاء [SummaryZoomSection](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/SummaryZoomSection) نمایان می‌شوند که در شیء [SummaryZoomSectionCollection](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/SummaryZoomSectionCollection) ذخیره می‌شوند. می‌توانید یک شیء Summary Zoom Section را از طریق کلاس [SummaryZoomSectionCollection](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/SummaryZoomSectionCollection) اضافه یا حذف کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Presentation) ایجاد کنید.
2. اسلایدهای جدیدی با پس‌زمینهٔ شناسایی و بخش‌های جدید برای اسلایدهای ساخته شده بسازید.
3. یک Summary Zoom Frame به اسلاید اول اضافه کنید.
4. اسلاید و بخش جدیدی به ارائه اضافه کنید.
5. بخش ساخته شده را به Summary Zoom Frame اضافه کنید.
6. اولین بخش را از Summary Zoom Frame حذف کنید.
7. ارائهٔ تغییر یافته را به صورت فایل PPTX ذخیره کنید.

این کد JavaScript نشان می‌دهد چگونه بخش‌ها را در یک Summary Zoom Frame اضافه و حذف کنید:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // یک اسلاید جدید به ارائه اضافه می‌کند
    var slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "gray"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // یک بخش جدید به ارائه اضافه می‌کند
    pres.getSections().addSection("Section 1", slide);
    // یک اسلاید جدید به ارائه اضافه می‌کند
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "cyan"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // یک بخش جدید به ارائه اضافه می‌کند
    pres.getSections().addSection("Section 2", slide);
    // یک شیء SummaryZoomFrame اضافه می‌کند
    var summaryZoomFrame = pres.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200);
    // یک اسلاید جدید به ارائه اضافه می‌کند
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "magenta"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // یک بخش جدید به ارائه اضافه می‌کند
    var section3 = pres.getSections().addSection("Section 3", slide);
    // یک بخش به Summary Zoom اضافه می‌کند
    summaryZoomFrame.getSummaryZoomCollection().addSummaryZoomSection(section3);
    // بخش را از Summary Zoom حذف می‌کند
    summaryZoomFrame.getSummaryZoomCollection().removeSummaryZoomSection(pres.getSections().get_Item(1));
    // ارائه را ذخیره می‌کند
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **قالب‌بندی بخش‌های Summary Zoom**

برای ایجاد اشیاء Summary Zoom Section پیچیده‌تر، باید قالب‌بندی یک فریم ساده را تغییر دهید. گزینه‌های قالب‌بندی متعددی می‌توانید بر یک Summary Zoom Section اعمال کنید. 

می‌توانید قالب‌بندی یک Summary Zoom Section را در یک Summary Zoom Frame به این روش کنترل کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Presentation) ایجاد کنید.
2. اسلایدهای جدیدی با پس‌زمینهٔ شناسایی و بخش‌های جدید برای اسلایدهای ساخته شده بسازید.
3. یک Summary Zoom Frame به اسلاید اول اضافه کنید.
4. یک شیء Summary Zoom Section برای اولین شیء از `ISummaryZoomSectionCollection` دریافت کنید.
7. یک شیء [PPImage](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/PPImage) با افزودن تصویر به مجموعه images مرتبط با شیء [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Presentation) ایجاد کنید تا فریم را پر کند.
8. تصویر سفارشی برای شیء Summary Zoom Section ساخته شده تنظیم کنید.
9. قابلیت *بازگشت به اسلاید اصلی از بخش لینک‌شده* را فعال کنید. 
11. قالب خط برای دومین شیء Zoom Frame را تغییر دهید.
12. مدت زمان انتقال را تغییر دهید.
13. ارائهٔ تغییر یافته را به صورت فایل PPTX ذخیره کنید.

این کد JavaScript نشان می‌دهد چگونه قالب‌بندی یک Summary Zoom Section را تغییر دهید:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // یک اسلاید جدید به ارائه اضافه می‌کند
    var slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "gray"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // یک بخش جدید به ارائه اضافه می‌کند
    pres.getSections().addSection("Section 1", slide);
    // یک اسلاید جدید به ارائه اضافه می‌کند
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "cyan"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // یک بخش جدید به ارائه اضافه می‌کند
    pres.getSections().addSection("Section 2", slide);
    // یک شیء SummaryZoomFrame اضافه می‌کند
    var summaryZoomFrame = pres.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200);
    // اولین شیء SummaryZoomSection را دریافت می‌کند
    var summarySection = summaryZoomFrame.getSummaryZoomCollection().get_Item(0);
    // قالب‌بندی برای شیء SummaryZoomSection
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(picture);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    summarySection.setImage(picture);
    summarySection.setReturnToParent(false);
    summarySection.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    summarySection.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "black"));
    summarySection.getLineFormat().setDashStyle(aspose.slides.LineDashStyle.DashDot);
    summarySection.getLineFormat().setWidth(1.5);
    summarySection.setTransitionDuration(1.5);
    // ارائه را ذخیره می‌کند
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**آیا می‌توانم کنترل کنم که پس از نشان دادن هدف به اسلاید «والد» بازگردم؟**

بله. متد `setReturnToParent` در [Zoom frame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/zoomframe/) یا [section](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/sectionzoomframe/) وقتی فعال باشد، بینندگان را پس از بازدید از محتوا هدف به اسلاید مبدأ باز می‌گرداند.

**آیا می‌توانم «سرعت» یا مدت زمان انتقال Zoom را تنظیم کنم؟**

بله. Zoom متد `setTransitionDuration` را ارائه می‌دهد تا بتوانید مدت زمان انیمیشن پرش را کنترل کنید.

**آیا محدودیتی برای تعداد اشیاء Zoom در یک ارائه وجود دارد؟**

هیچ محدودیت سخت‌گیرانه‌ای در API مستند نشده است. محدودیت‌های عملی به پیچیدگی کلی ارائه و عملکرد نمایشگر بستگی دارد. می‌توانید تعداد زیادی Zoom Frame اضافه کنید، اما به حجم فایل و زمان رندرینگ توجه کنید.