---
title: إدارة تكبير العرض التقديمي على Android
linktitle: إدارة التكبير
type: docs
weight: 60
url: /ar/androidjava/manage-zoom/
keywords:
- تكبير
- إطار التكبير
- تكبير الشريحة
- تكبير القسم
- تكبير الملخص
- إضافة تكبير
- PowerPoint
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "إنشاء وتخصيص التكبير باستخدام Aspose.Slides لأندرويد عبر جافا — الانتقال بين الأقسام، إضافة الصور المصغرة والانتقالات عبر عروض PPT و PPTX و ODP."
---

## **نظرة عامة**
Zooms in PowerPoint allow you to jump to and from specific slides, sections, and portions of a presentation. When you are presenting, this ability to navigate quickly across content might prove very useful. 

![overview_image](overview.png)

* لتلخيص عرض تقديمي كامل على شريحة واحدة، استخدم [ملخص التكبير](#Summary-Zoom).
* لعرض الشرائح المحددة فقط، استخدم [تكبير الشريحة](#Slide-Zoom).
* لعرض قسم واحد فقط، استخدم [تكبير القسم](#Section-Zoom).

## **تكبير الشريحة**
A slide zoom can make your presentation more dynamic, allowing you to navigate freely between slides in any order you choose without interrupting the flow of your presentation. Slide zooms are great for short presentations without many sections, but you can still use them in different presentation scenarios.

Slide zooms help you drill into multiple pieces of information while you feel like you are on a single canvas. 

![overview_image](slidezoomsel.png)

For slide zoom objects, Aspose.Slides provides the [ZoomImageType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ZoomImageType) enumeration, the [IZoomFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IZoomFrame) interface, and some methods under the [IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection) interface.

### **إنشاء إطارات التكبير**
You can add a zoom frame on a slide this way:

1.	إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) .
2.	إنشاء شرائح جديدة لتربط إطارات التكبير بها. 
3.	إضافة نص تعريف وخلفية إلى الشرائح التي تم إنشاؤها.
4.	إضافة إطارات التكبير (التي تحتوي على مراجع إلى الشرائح التي تم إنشاؤها) إلى الشريحة الأولى.
5.	حفظ العرض المعدل كملف PPTX.

This Java code shows you how to create a zoom frame on a slide:
``` java
Presentation pres = new Presentation();
try {
    //يضيف شرائح جديدة إلى العرض التقديمي
    ISlide slide2 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    ISlide slide3 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());

    // ينشئ خلفية للشريحة الثانية
    slide2.getBackground().setType(BackgroundType.OwnBackground);
    slide2.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide2.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);

    // ينشئ صندوق نص للشريحة الثانية
    IAutoShape autoshape = slide2.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Second Slide");

    // ينشئ خلفية للشريحة الثالثة
    slide3.getBackground().setType(BackgroundType.OwnBackground);
    slide3.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide3.getBackground().getFillFormat().getSolidFillColor().setColor(Color.darkGray);

    // ينشئ صندوق نص للشريحة الثالثة
    autoshape = slide3.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Trird Slide");

    //يضيف كائنات ZoomFrame
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 250, 200, slide2);
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(200, 250, 250, 200, slide3);

    // يحفظ العرض التقديمي
    pres.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **إنشاء إطارات التكبير بصور مخصصة**
With Aspose.Slides for Android via Java, you can create a zoom frame with a different slide preview image this way:
1.	إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) .
2.	إنشاء شريحة جديدة لتربط إطار التكبير بها. 
3.	إضافة نص تعريف وخلفية إلى الشريحة.
4.	إنشاء كائن [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPPImage) عن طريق إضافة صورة إلى مجموعة Images المرتبطة بكائن [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) الذي سيُستخدم لملء الإطار.
5.	إضافة إطارات التكبير (التي تحتوي على مرجع إلى الشريحة التي تم إنشاؤها) إلى الشريحة الأولى.
6.	حفظ العرض المعدل كملف PPTX.

This Java code shows you how to create a zoom frame with a different image:
``` java
Presentation pres = new Presentation();
try {
    // يضيف شريحة جديدة إلى العرض التقديمي
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());

    // ينشئ خلفية للشريحة الثانية
    slide.getBackground().setType(BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);

    // ينشئ صندوق نص للشريحة الثالثة
    IAutoShape autoshape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Second Slide");

    // ينشئ صورة جديدة لكائن التكبير
    IPPImage picture;
        IImage image = Images.fromFile("image.png");
        try {
            picture = pres.getImages().addImage(image);
        } finally {
            if (image != null) image.dispose();
        }
    // يضيف كائن ZoomFrame
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 300, 200, slide, picture);

    // يحفظ العرض التقديمي
    pres.save("presentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

### **تنسيق إطارات التكبير**
In the previous sections, we showed you how to create simple zoom frames. To create more complicated zoom frames, you have to alter a simple frame's formatting. There are several formatting options you can apply to a zoom frame. 

You can control a zoom frame's formatting on a slide this way:

1.	إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) .
2.	إنشاء شرائح جديدة لتربط إطارات التكبير بها. 
3.	إضافة بعض نصوص التعريف والخلفية إلى الشرائح التي تم إنشاؤها.
4.	إضافة إطارات التكبير (التي تحتوي على المراجع إلى الشرائح التي تم إنشاؤها) إلى الشريحة الأولى.
5.	إنشاء كائن [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPPImage) عن طريق إضافة صورة إلى مجموعة Images المرتبطة بكائن [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) الذي سيُستخدم لملء الإطار.
6.	تعيين صورة مخصصة لكائن إطار التكبير الأول.
7.	تغيير تنسيق الخط لكائن إطار التكبير الثاني.
8.	إزالة الخلفية من صورة كائن إطار التكبير الثاني.
5.	احفظ العرض المعدل كملف PPTX.

This Java code shows you how to change a zoom frame's formatting on a slide: 
``` java
Presentation pres = new Presentation();
try {
    // يضيف شرائح جديدة إلى العرض التقديمي
    ISlide slide2 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    ISlide slide3 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());

    // ينشئ خلفية للشريحة الثانية
    slide2.getBackground().setType(BackgroundType.OwnBackground);
    slide2.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide2.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);

    // ينشئ صندوق نص للشريحة الثانية
    IAutoShape autoshape = slide2.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Second Slide");

    // ينشئ خلفية للشريحة الثالثة
    slide3.getBackground().setType(BackgroundType.OwnBackground);
    slide3.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide3.getBackground().getFillFormat().getSolidFillColor().setColor(Color.darkGray);

    // ينشئ صندوق نص للشريحة الثالثة
    autoshape = slide3.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Trird Slide");

    // يضيف كائنات ZoomFrame
    IZoomFrame zoomFrame1 = pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 250, 200, slide2);
    IZoomFrame zoomFrame2 = pres.getSlides().get_Item(0).getShapes().addZoomFrame(200, 250, 250, 200, slide3);

    // ينشئ صورة جديدة لكائن التكبير
    IPPImage picture;
        IImage image = Images.fromFile("image.png");
        try {
            picture = pres.getImages().addImage(image);
        } finally {
            if (image != null) image.dispose();
        }
    // يعيّن صورة مخصصة لكائن zoomFrame1
    zoomFrame1.setImage(picture);

    // يعيّن تنسيق إطار التكبير لكائن zoomFrame2
    zoomFrame2.getLineFormat().setWidth(5);
    zoomFrame2.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    zoomFrame2.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.pink);
    zoomFrame2.getLineFormat().setDashStyle(LineDashStyle.DashDot);

    // إعداد عدم إظهار الخلفية لكائن zoomFrame2
    zoomFrame2.setShowBackground(false);

    // يحفظ العرض التقديمي
    pres.save("presentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


## **تكبير القسم**

A section zoom is a link to a section in your presentation. You can use section zooms to go back to sections you want to really emphasize. Or you can use them to highlight how certain pieces of your presentation connect. 

![overview_image](seczoomsel.png)

For section zoom objects, Aspose.Slides provides the [ISectionZoomFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISectionZoomFrame) interface and some methods under the [IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection) interface.

### **إنشاء إطارات تكبير القسم**
You can add a section zoom frame to a slide this way:

1.	إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) .
2.	إنشاء شريحة جديدة. 
3.	إضافة خلفية تعريف إلى الشريحة التي تم إنشاؤها.
4.	إنشاء قسم جديد لتربط إطاره إطار التكبير.
5.	إضافة إطار تكبير القسم (الذي يحتوي على مراجع إلى القسم الذي تم إنشاؤه) إلى الشريحة الأولى.
6.	حفظ العرض المعدل كملف PPTX.

This Java code shows you how to create a zoom frame on a slide:
``` java
Presentation pres = new Presentation();
try {
    // يضيف شريحة جديدة إلى العرض التقديمي
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.yellow);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // يضيف قسمًا جديدًا إلى العرض التقديمي
    pres.getSections().addSection("Section 1", slide);

    // يضيف كائن SectionZoomFrame
    ISectionZoomFrame sectionZoomFrame = pres.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, pres.getSections().get_Item(1));

    // يحفظ العرض التقديمي
    pres.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **إنشاء إطارات تكبير القسم بصور مخصصة**
Using Aspose.Slides for Android via Java, you can create a section zoom frame with a different slide preview image this way:

1.	إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) .
2.	إنشاء شريحة جديدة.
3.	إضافة خلفية تعريف إلى الشريحة التي تم إنشاؤها.
4.	إنشاء قسم جديد لتربط إطاره إطار التكبير. 
5.	إنشاء كائن [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPPImage) عن طريق إضافة صورة إلى مجموعة Images المرتبطة بكائن [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) الذي سيُستخدم لملء الإطار.
5.	إضافة إطار تكبير القسم (الذي يحتوي على مرجع إلى القسم الذي تم إنشاؤه) إلى الشريحة الأولى.
6.	حفظ العرض المعدل كملف PPTX.

This Java code shows you how to create a zoom frame with a different image:
``` java 
Presentation pres = new Presentation();
try {
    // يضيف شريحة جديدة إلى العرض التقديمي
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.yellow);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // يضيف قسمًا جديدًا إلى العرض التقديمي
    pres.getSections().addSection("Section 1", slide);

    // ينشئ صورة جديدة لكائن التكبير
    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // يضيف كائن SectionZoomFrame
    ISectionZoomFrame sectionZoomFrame = pres.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, pres.getSections().get_Item(1), picture);

    // يحفظ العرض التقديمي
    pres.save("presentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

### **تنسيق إطارات تكبير القسم**
To create more complicated section zoom frames, you have to alter a simple frame's formatting. There are several formatting options you can apply to a section zoom frame. 

You can control a section zoom frame's formatting on a slide this way:

1.	إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) .
2.	إنشاء شريحة جديدة.
3.	إضافة خلفية تعريف إلى الشريحة التي تم إنشاؤها.
4.	إنشاء قسم جديد لتربط إطاره إطار التكبير. 
5.	إضافة إطار تكبير القسم (الذي يحتوي على مراجع إلى القسم الذي تم إنشاؤه) إلى الشريحة الأولى.
6.	تغيير الحجم والموقع لكائن تكبير القسم الذي تم إنشاؤه.
7.	إنشاء كائن [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPPImage) عن طريق إضافة صورة إلى مجموعة Images المرتبطة بكائن [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) الذي سيُستخدم لملء الإطار.
8.	تعيين صورة مخصصة لكائن إطار تكبير القسم الذي تم إنشاؤه.
9.	تفعيل إمكانية *العودة إلى الشريحة الأصلية من القسم المرتبط*.
10.	إزالة الخلفية من صورة كائن إطار تكبير القسم.
11.	تغيير تنسيق الخط لكائن إطار التكبير الثاني.
12.	تغيير مدة الانتقال.
13.	احفظ العرض المعدل كملف PPTX.

This Java code shows you how to change a section zoom frame's formatting:
``` java
Presentation pres = new Presentation();
try {
    // يضيف شريحة جديدة إلى العرض التقديمي
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.yellow);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // يضيف قسمًا جديدًا إلى العرض التقديمي
    pres.getSections().addSection("Section 1", slide);

    // يضيف كائن SectionZoomFrame
    ISectionZoomFrame sectionZoomFrame = pres.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, pres.getSections().get_Item(1));

    // تنسيق كائن SectionZoomFrame
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

    // يحفظ العرض التقديمي
    pres.save("presentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```



## **تكبير الملخص**

A summary zoom is like a landing page where all the pieces of your presentation are displayed at once. When you're presenting, you can use the zoom to go from one place in your presentation to another in any order you like. You can get creative, skip ahead, or revisit pieces of your slide show without interrupting the flow of your presentation.

![overview_image](sumzoomsel.png)

For summary zoom objects, Aspose.Slides provides the [ISummaryZoomFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISummaryZoomFrame), [ISummaryZoomSection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISummaryZoomSection), and [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISummaryZoomSectionCollection) interfaces and some methods under the [IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection) interface.

### **إنشاء تكبير الملخص**
You can add a summary zoom frame to a slide this way:

1.	إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) .
2.	إنشاء شرائح جديدة مع خلفية تعريف وأقسام جديدة للشرائح التي تم إنشاؤها.
3.	إضافة إطار تكبير الملخص إلى الشريحة الأولى.
4.	حفظ العرض المعدل كملف PPTX.

This Java code shows you how to create a summary zoom frame on a slide:
``` java 
Presentation pres = new Presentation();
try {
    // يضيف شريحة جديدة إلى العرض التقديمي
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.gray);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // يضيف قسمًا جديدًا إلى العرض التقديمي
    pres.getSections().addSection("Section 1", slide);

    // يضيف شريحة جديدة إلى العرض التقديمي
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // يضيف قسمًا جديدًا إلى العرض التقديمي
    pres.getSections().addSection("Section 2", slide);

    // يضيف شريحة جديدة إلى العرض التقديمي
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.magenta);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // يضيف قسمًا جديدًا إلى العرض التقديمي
    pres.getSections().addSection("Section 3", slide);

    // يضيف شريحة جديدة إلى العرض التقديمي
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.green);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // يضيف قسمًا جديدًا إلى العرض التقديمي
    pres.getSections().addSection("Section 4", slide);

    // يضيف كائن SummaryZoomFrame
    ISummaryZoomFrame summaryZoomFrame = pres.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200);

    // يحفظ العرض التقديمي
    pres.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


### **إضافة وإزالة قسم تكبير الملخص**
All sections in a summary zoom frame are represented by [ISummaryZoomSection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISummaryZoomSection) objects, which are stored in the [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISummaryZoomSectionCollection) object. You can add or remove a summary zoom section object through the [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISummaryZoomSectionCollection) interface this way:

1.	إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) .
2.	إنشاء شرائح جديدة مع خلفية تعريف وأقسام جديدة للشرائح التي تم إنشاؤها.
3.	إضافة إطار تكبير الملخص إلى الشريحة الأولى.
4.	إضافة شريحة وقسم جديدين إلى العرض.
5.	إضافة القسم الذي تم إنشاؤه إلى إطار تكبير الملخص.
6.	إزالة القسم الأول من إطار تكبير الملخص.
7.	حفظ العرض المعدل كملف PPTX.

This Java code shows you how to add and remove sections in a summary zoom frame:
``` java
Presentation pres = new Presentation();
try {
    //يضيف شريحة جديدة إلى العرض التقديمي
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.gray);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // يضيف قسمًا جديدًا إلى العرض التقديمي
    pres.getSections().addSection("Section 1", slide);

    //يضيف شريحة جديدة إلى العرض التقديمي
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // يضيف قسمًا جديدًا إلى العرض التقديمي
    pres.getSections().addSection("Section 2", slide);

    // يضيف كائن SummaryZoomFrame
    ISummaryZoomFrame summaryZoomFrame = pres.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200);

    //يضيف شريحة جديدة إلى العرض التقديمي
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.magenta);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // يضيف قسمًا جديدًا إلى العرض التقديمي
    ISection section3 = pres.getSections().addSection("Section 3", slide);

    // يضيف قسمًا إلى ملخص التكبير
    summaryZoomFrame.getSummaryZoomCollection().addSummaryZoomSection(section3);

    // يزيل القسم من ملخص التكبير
    summaryZoomFrame.getSummaryZoomCollection().removeSummaryZoomSection(pres.getSections().get_Item(1));

    // يحفظ العرض التقديمي
    pres.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


### **تنسيق أقسام تكبير الملخص**
To create more complicated summary zoom section objects, you have to alter a simple frame's formatting. There are several formatting options you can apply to a summary zoom section object. 

You can control the formatting for a summary zoom section object in a summary zoom frame this way:

1.	إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) .
2.	إنشاء شرائح جديدة مع خلفية تعريف وأقسام جديدة للشرائح التي تم إنشاؤها.
3.	إضافة إطار تكبير الملخص إلى الشريحة الأولى.
4.	احصل على كائن قسم تكبير الملخص للكائن الأول من `ISummaryZoomSectionCollection`.
5.	إنشاء كائن [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPPImage) عن طريق إضافة صورة إلى مجموعة images المرتبطة بكائن [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) الذي سيُستخدم لملء الإطار.
6.	تعيين صورة مخصصة لكائن إطار تكبير القسم الذي تم إنشاؤه.
7.	تفعيل إمكانية *العودة إلى الشريحة الأصلية من القسم المرتبط*.
8.	تغيير تنسيق الخط لكائن إطار التكبير الثاني.
9.	تغيير مدة الانتقال.
10.	احفظ العرض المعدل كملف PPTX.

This Java code shows you how to change the formatting for a summary zoom section object:
``` java
Presentation pres = new Presentation();
try {
    //يضيف شريحة جديدة إلى العرض التقديمي
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.gray);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // يضيف قسمًا جديدًا إلى العرض التقديمي
    pres.getSections().addSection("Section 1", slide);

    //يضيف شريحة جديدة إلى العرض التقديمي
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // يضيف قسمًا جديدًا إلى العرض التقديمي
    pres.getSections().addSection("Section 2", slide);

    // يضيف كائن SummaryZoomFrame
    ISummaryZoomFrame summaryZoomFrame = pres.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200);

    // يحصل على أول كائن SummaryZoomSection
    ISummaryZoomSection summarySection = summaryZoomFrame.getSummaryZoomCollection().get_Item(0);

    // تنسيق كائن SummaryZoomSection
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

    // يحفظ العرض التقديمي
    pres.save("presentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


## **الأسئلة الشائعة**

**هل يمكنني التحكم في العودة إلى الشريحة 'الأم' بعد عرض الهدف؟**

نعم. يحتوي إطار [Zoom frame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/zoomframe/) أو [section](https://reference.aspose.com/slides/androidjava/com.aspose.slides/sectionzoomframe/) على سلوك العودة إلى الأصل، والذي عندما يُفعَّل، يُعيد المشاهدين إلى الشريحة الأصلية بعد زيارة المحتوى المستهدف.

**هل يمكنني تعديل 'السرعة' أو مدة الانتقال في التكبير؟**

نعم. يدعم Zoom تعيين مدة الانتقال بحيث يمكنك التحكم في طول مدة حركة القفز.

**هل هناك حدود لعدد كائنات Zoom التي يمكن أن يحتويها العرض التقديمي؟**

لا يوجد حد صريح في واجهة برمجة التطبيقات موثق. تعتمد الحدود العملية على تعقيد العرض التقديمي العام وأداء المشاهد. يمكنك إضافة العديد من إطارات Zoom، لكن يجب مراعاة حجم الملف ووقت العرض.