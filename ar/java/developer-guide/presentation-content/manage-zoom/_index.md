---
title: إدارة تكبير العرض التقديمي في Java
linktitle: إدارة التكبير
type: docs
weight: 60
url: /ar/java/manage-zoom/
keywords:
- تكبير
- إطار التكبير
- تكبير الشريحة
- تكبير القسم
- تكبير الملخص
- إضافة تكبير
- PowerPoint
- العرض التقديمي
- Java
- Aspose.Slides
description: "إنشاء وتخصيص التكبير باستخدام Aspose.Slides for Java — الانتقال بين الأقسام، إضافة الصور المصغرة والانتقالات عبر عروض PPT و PPTX و ODP."
---

## **نظرة عامة**
تسمح لك ميزة التكبير في PowerPoint بالانتقال من وإلى الشرائح والأقسام والأجزاء المحددة في العرض التقديمي. عند تقديم العرض، قد تكون القدرة على التنقل السريع عبر المحتوى مفيدة للغاية. 

![overview_image](overview.png)

* لتلخيص العرض التقديمي بالكامل على شريحة واحدة، استخدم [ملخص التكبير](#Summary-Zoom).
* لعرض شرائح مختارة فقط، استخدم [تكبير الشريحة](#Slide-Zoom).
* لعرض قسم واحد فقط، استخدم [تكبير القسم](#Section-Zoom).

## **تكبير الشريحة**
يمكن لتكبير الشريحة جعل عرضك أكثر ديناميكية، حيث يتيح لك التنقل بحرية بين الشرائح بأي ترتيب تختاره دون إيقاف تدفق العرض. تكبير الشرائح مفيد للعروض القصيرة التي لا تحتوي على أقسام كثيرة، ولكن يمكنك أيضًا استخدامه في سيناريوهات عرض مختلفة.

يساعدك تكبير الشرائح على استكشاف قطع متعددة من المعلومات وأنت تشعر وكأنك على لوحة واحدة. 

![overview_image](slidezoomsel.png)

بالنسبة لكائنات تكبير الشرائح، توفر Aspose.Slides التعداد [ZoomImageType](https://reference.aspose.com/slides/java/com.aspose.slides/ZoomImageType) والواجهة [IZoomFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IZoomFrame) وبعض الأساليب تحت واجهة [IShapeCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection).

### **إنشاء إطارات التكبير**

يمكنك إضافة إطار تكبير إلى شريحة بهذه الطريقة:

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. إنشاء شرائح جديدة تريد ربط إطارات التكبير بها. 
3. إضافة نص تعريف وخلفية إلى الشرائح التي تم إنشاؤها.
4. إضافة إطارات التكبير (التي تحتوي على مراجع للشرائح التي تم إنشاؤها) إلى الشريحة الأولى.
5. كتابة العرض المعدل كملف PPTX.

هذا الكود في Java يوضح كيفية إنشاء إطار تكبير على شريحة:
``` java
Presentation pres = new Presentation();
try {
    //يضيف شرائح جديدة إلى العرض التقديمي
    ISlide slide2 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    ISlide slide3 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());

    // ينشئ خلفية للشرحة الثانية
    slide2.getBackground().setType(BackgroundType.OwnBackground);
    slide2.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide2.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);

    // ينشئ مربع نص للشرحة الثانية
    IAutoShape autoshape = slide2.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Second Slide");

    // ينشئ خلفية للشرحة الثالثة
    slide3.getBackground().setType(BackgroundType.OwnBackground);
    slide3.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide3.getBackground().getFillFormat().getSolidFillColor().setColor(Color.darkGray);

    // ينشئ مربع نص للشرحة الثالثة
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

### **إنشاء إطارات تكبير بصور مخصصة**
مع Aspose.Slides for Java، يمكنك إنشاء إطار تكبير بصورة معاينة شريحة مختلفة بهذه الطريقة: 
1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. إنشاء شريحة جديدة تريد ربط إطار التكبير بها. 
3. إضافة نص تعريف وخلفية إلى الشريحة.
4. إنشاء كائن [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/IPPImage) بإضافة صورة إلى مجموعة Images المرتبطة بكائن [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) التي ستُستخدم لملء الإطار.
5. إضافة إطارات التكبير (التي تحتوي على مرجع الشريحة التي تم إنشاؤها) إلى الشريحة الأولى.
6. كتابة العرض المعدل كملف PPTX.

هذا الكود في Java يوضح كيفية إنشاء إطار تكبير بصورة مختلفة:
``` java
Presentation pres = new Presentation();
try {
    //يضيف شريحة جديدة إلى العرض التقديمي
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());

    // ينشئ خلفية للشريحة الثانية
    slide.getBackground().setType(BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);

    // ينشئ مربع نص للشريحة الثالثة
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
    //يضيف كائن ZoomFrame
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 300, 200, slide, picture);

    // يحفظ العرض التقديمي
    pres.save("presentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

### **تنسيق إطارات التكبير**
في الأقسام السابقة، أوضحنا لك كيفية إنشاء إطارات تكبير بسيطة. لإنشاء إطارات تكبير أكثر تعقيدًا، عليك تعديل تنسيق الإطار البسيط. هناك عدة خيارات تنسيق يمكنك تطبيقها على إطار التكبير. 

يمكنك التحكم في تنسيق إطار التكبير على الشريحة بهذه الطريقة:

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. إنشاء شرائح جديدة تريد ربط إطار التكبير بها. 
3. إضافة نص تعريف وخلفية إلى الشرائح التي تم إنشاؤها.
4. إضافة إطارات التكبير (التي تحتوي على مراجع للشرائح التي تم إنشاؤها) إلى الشريحة الأولى.
5. إنشاء كائن [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/IPPImage) بإضافة صورة إلى مجموعة Images المرتبطة بكائن [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) التي ستُستخدم لملء الإطار.
6. تعيين صورة مخصصة للإطار التكبير الأول.
7. تغيير تنسيق الخط للإطار التكبير الثاني.
8. إزالة الخلفية من صورة الإطار التكبير الثاني.
5. كتابة العرض المعدل كملف PPTX.

هذا الكود في Java يوضح كيفية تغيير تنسيق إطار التكبير على الشريحة: 
``` java 
Presentation pres = new Presentation();
try {
    // يضيف شرائح جديدة إلى العرض التقديمي
    ISlide slide2 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    ISlide slide3 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());

    // ينشئ خلفية للشرحة الثانية
    slide2.getBackground().setType(BackgroundType.OwnBackground);
    slide2.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide2.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);

    // ينشئ مربع نص للشرحة الثانية
    IAutoShape autoshape = slide2.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Second Slide");

    // ينشئ خلفية للشرحة الثالثة
    slide3.getBackground().setType(BackgroundType.OwnBackground);
    slide3.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide3.getBackground().getFillFormat().getSolidFillColor().setColor(Color.darkGray);

    // ينشئ مربع نص للشرحة الثالثة
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
    // يحدد صورة مخصصة لكائن zoomFrame1
    zoomFrame1.setImage(picture);

    // يحدد تنسيق إطار التكبير لكائن zoomFrame2
    zoomFrame2.getLineFormat().setWidth(5);
    zoomFrame2.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    zoomFrame2.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.pink);
    zoomFrame2.getLineFormat().setDashStyle(LineDashStyle.DashDot);

    // إعداد لعدم إظهار الخلفية لكائن zoomFrame2
    zoomFrame2.setShowBackground(false);

    // يحفظ العرض التقديمي
    pres.save("presentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


## **تكبير القسم**

تكبير القسم هو رابط إلى قسم في عرضك التقديمي. يمكنك استخدام تكبير الأقسام للعودة إلى الأقسام التي تريد التأكيد عليها بشدة. أو يمكنك استخدامها لتسليط الضوء على كيفية ارتباط أجزاء معينة من عرضك. 

![overview_image](seczoomsel.png)

بالنسبة لكائنات تكبير الأقسام، توفر Aspose.Slides الواجهة [ISectionZoomFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ISectionZoomFrame) وبعض الأساليب تحت واجهة [IShapeCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection).

### **إنشاء إطارات تكبير القسم**

يمكنك إضافة إطار تكبير قسم إلى شريحة بهذه الطريقة:

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. إنشاء شريحة جديدة. 
3. إضافة خلفية تعريف إلى الشريحة التي تم إنشاؤها.
4. إنشاء قسم جديد تريد ربط إطار التكبير به. 
5. إضافة إطار تكبير قسم (الذي يحتوي على مراجع للقسم الذي تم إنشاؤه) إلى الشريحة الأولى.
6. كتابة العرض المعدل كملف PPTX.

هذا الكود في Java يوضح كيفية إنشاء إطار تكبير على شريحة:
``` java
Presentation pres = new Presentation();
try {
    //يضيف شريحة جديدة إلى العرض التقديمي
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

### **إنشاء إطارات تكبير قسم بصور مخصصة**

باستخدام Aspose.Slides for Java، يمكنك إنشاء إطار تكبير قسم بصورة معاينة شريحة مختلفة بهذه الطريقة: 

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. إنشاء شريحة جديدة.
3. إضافة خلفية تعريف إلى الشريحة التي تم إنشاؤها.
4. إنشاء قسم جديد تريد ربط إطار التكبير به. 
5. إنشاء كائن [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/IPPImage) بإضافة صورة إلى مجموعة Images المرتبطة بكائن [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) التي ستُستخدم لملء الإطار.
5. إضافة إطار تكبير قسم (الذي يحتوي على مرجع للقسم الذي تم إنشاؤه) إلى الشريحة الأولى.
6. كتابة العرض المعدل كملف PPTX.

هذا الكود في Java يوضح كيفية إنشاء إطار تكبير بصورة مختلفة:
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

لإنشاء إطارات تكبير قسم أكثر تعقيدًا، عليك تعديل تنسيق الإطار البسيط. هناك عدة خيارات تنسيق يمكنك تطبيقها على إطار تكبير القسم. 

يمكنك التحكم في تنسيق إطار تكبير القسم على الشريحة بهذه الطريقة:

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. إنشاء شريحة جديدة.
3. إضافة خلفية تعريف إلى الشريحة التي تم إنشاؤها.
4. إنشاء قسم جديد تريد ربط إطار التكبير به. 
5. إضافة إطار تكبير قسم (الذي يحتوي على مراجع للقسم الذي تم إنشاؤه) إلى الشريحة الأولى.
6. تغيير الحجم والموضع للكائن تكبير القسم الذي تم إنشاؤه.
7. إنشاء كائن [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/IPPImage) بإضافة صورة إلى مجموعة Images المرتبطة بكائن [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) التي ستُستخدم لملء الإطار.
8. تعيين صورة مخصصة لكائن إطار تكبير القسم الذي تم إنشاؤه.
9. تمكين القدرة على *العودة إلى الشريحة الأصلية من القسم المرتبط*. 
10. إزالة الخلفية من صورة إطار تكبير القسم.
11. تغيير تنسيق الخط للإطار التكبير الثاني.
12. تعديل مدة الانتقال.
13. كتابة العرض المعدل كملف PPTX.

هذا الكود في Java يوضح كيفية تغيير تنسيق إطار تكبير القسم:
``` java
Presentation pres = new Presentation();
try {
    //يضيف شريحة جديدة إلى العرض التقديمي
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.yellow);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // يضيف قسمًا جديدًا إلى العرض التقديمي
    pres.getSections().addSection("Section 1", slide);

    // يضيف كائن SectionZoomFrame
    ISectionZoomFrame sectionZoomFrame = pres.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, pres.getSections().get_Item(1));

    // تنسيق لكائن SectionZoomFrame
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



## **ملخص التكبير**

ملخص التكبير يشبه صفحة هبوط تُظهر جميع أجزاء العرض التقديمي مرة واحدة. عند تقديم العرض، يمكنك استخدام التكبير للانتقال من مكان إلى آخر في العرض بأي ترتيب تريده. يمكنك الإبداع، التخطي إلى الأمام، أو الرجوع إلى أجزاء من العرض دون إيقاف تدفقه.

![overview_image](sumzoomsel.png)

بالنسبة لكائنات ملخص التكبير، توفر Aspose.Slides الواجهات [ISummaryZoomFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ISummaryZoomFrame)، [ISummaryZoomSection](https://reference.aspose.com/slides/java/com.aspose.slides/ISummaryZoomSection) و[ISummaryZoomSectionCollection](https://reference.aspose.com/slides/java/com.aspose.slides/ISummaryZoomSectionCollection) وبعض الأساليب تحت واجهة [IShapeCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection).

### **إنشاء ملخص تكبير**

يمكنك إضافة إطار ملخص تكبير إلى شريحة بهذه الطريقة:

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. إنشاء شرائح جديدة مع خلفية تعريف وأقسام جديدة للشرائح التي تم إنشاؤها.
3. إضافة إطار ملخص التكبير إلى الشريحة الأولى.
4. كتابة العرض المعدل كملف PPTX.

هذا الكود في Java يوضح كيفية إنشاء إطار ملخص تكبير على شريحة:
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


### **إضافة وإزالة قسم في ملخص التكبير**

جميع الأقسام في إطار ملخص التكبير ممثلة بواسطة كائنات [ISummaryZoomSection](https://reference.aspose.com/slides/java/com.aspose.slides/ISummaryZoomSection)، المخزنة في كائن [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/java/com.aspose.slides/ISummaryZoomSectionCollection). يمكنك إضافة أو إزالة كائن قسم ملخص التكبير عبر واجهة [ISummaryZoomSectionCollection] بهذه الطريقة:

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. إنشاء شرائح جديدة مع خلفية تعريف وأقسام جديدة للشرائح التي تم إنشاؤها.
3. إضافة إطار ملخص التكبير إلى الشريحة الأولى.
4. إضافة شريحة جديدة وقسم إلى العرض.
5. إضافة القسم الذي تم إنشاؤه إلى إطار ملخص التكبير.
6. إزالة القسم الأول من إطار ملخص التكبير.
7. كتابة العرض المعدل كملف PPTX.

هذا الكود في Java يوضح كيفية إضافة وإزالة أقسام في إطار ملخص التكبير:
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

    // يضيف كائن SummaryZoomFrame
    ISummaryZoomFrame summaryZoomFrame = pres.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200);

    // يضيف شريحة جديدة إلى العرض التقديمي
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


### **تنسيق أقسام ملخص التكبير**

لإنشاء كائنات أقسام ملخص التكبير أكثر تعقيدًا، عليك تعديل تنسيق الإطار البسيط. هناك عدة خيارات تنسيق يمكنك تطبيقها على كائن قسم ملخص التكبير. 

يمكنك التحكم في تنسيق كائن قسم ملخص التكبير داخل إطار ملخص التكبير بهذه الطريقة:

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. إنشاء شرائح جديدة مع خلفية تعريف وأقسام جديدة للشرائح التي تم إنشاؤها.
3. إضافة إطار ملخص التكبير إلى الشريحة الأولى.
4. الحصول على كائن قسم ملخص التكبير الأول من `ISummaryZoomSectionCollection`.
7. إنشاء كائن [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/IPPImage) بإضافة صورة إلى مجموعة الصور المرتبطة بكائن [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) التي ستُستخدم لملء الإطار.
8. تعيين صورة مخصصة لكائن إطار تكبير القسم الذي تم إنشاؤه.
9. تمكين القدرة على *العودة إلى الشريحة الأصلية من القسم المرتبط*. 
11. تغيير تنسيق الخط للإطار التكبير الثاني.
12. تعديل مدة الانتقال.
13. كتابة العرض المعدل كملف PPTX.

هذا الكود في Java يوضح كيفية تغيير تنسيق كائن قسم ملخص التكبير:
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

    // يضيف كائن SummaryZoomFrame
    ISummaryZoomFrame summaryZoomFrame = pres.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200);

    // يحصل على كائن SummaryZoomSection الأول
    ISummaryZoomSection summarySection = summaryZoomFrame.getSummaryZoomCollection().get_Item(0);

    // تنسيق لكائن SummaryZoomSection
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


## **الأسئلة المتكررة**

**هل يمكنني التحكم في العودة إلى الشريحة "الأصلية" بعد عرض الهدف؟**

نعم. يحتوي إطار [Zoom frame](https://reference.aspose.com/slides/java/com.aspose.slides/zoomframe/) أو [section](https://reference.aspose.com/slides/java/com.aspose.slides/sectionzoomframe/) على سلوك `ReturnToParent`، وعند تمكينه يعيد المشاهدين إلى الشريحة الأصلية بعد زيارة المحتوى المستهدف.

**هل يمكنني تعديل "سرعة" أو مدة انتقال التكبير؟**

نعم. يدعم التكبير ضبط `TransitionDuration` لتتمكن من التحكم في مدة حركة القفزة.

**هل هناك حدود لعدد كائنات التكبير التي يمكن أن يحتويها العرض؟**

لا يوجد حد صريح موثق في واجهة البرمجة. تعتمد الحدود العملية على تعقيد العرض العام وأداء المشاهد. يمكنك إضافة العديد من إطارات التكبير، ولكن يجب مراعاة حجم الملف ووقت التجسيد.