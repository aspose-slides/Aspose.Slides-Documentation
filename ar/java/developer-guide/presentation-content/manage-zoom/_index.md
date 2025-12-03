---
title: إدارة تكبير العرض التقديمي في Java
linktitle: إدارة التكبير
type: docs
weight: 60
url: /ar/java/manage-zoom/
keywords:
- تكبير
- إطار تكبير
- تكبير الشريحة
- تكبير القسم
- تكبير الملخص
- إضافة تكبير
- PowerPoint
- عرض تقديمي
- Java
- Aspose.Slides
description: "إنشاء وتخصيص التكبير باستخدام Aspose.Slides for Java — الانتقال بين الأقسام، إضافة مصغرات وانتقالات عبر عروض PPT و PPTX و ODP."
---

## **نظرة عامة**
تتيح لك التكبيرات في PowerPoint الانتقال إلى ومن شرائح محددة، أقسام، وأجزاء من العرض التقديمي. عندما تقوم بالعرض، قد تكون هذه القدرة على التنقل السريع عبر المحتوى مفيدة جدًا. 

![overview_image](overview.png)

* لتلخيص العرض التقديمي بالكامل في شريحة واحدة، استخدم [ملخص التكبير](#Summary-Zoom).
* لعرض الشرائح المختارة فقط، استخدم [تكبير الشريحة](#Slide-Zoom).
* لعرض قسم واحد فقط، استخدم [تكبير القسم](#Section-Zoom).

## **تكبير الشريحة**
يمكن لتكبير الشريحة أن يجعل عرضك التقديمي أكثر ديناميكية، مما يسمح لك بالتنقل بحرية بين الشرائح بأي ترتيب تختاره دون إقفال تدفق عرضك. تكبيرات الشرائح رائعة للعروض القصيرة التي لا تحتوي على أقسام كثيرة، لكن يمكنك استخدامها أيضًا في سيناريوهات عرض مختلفة.

تساعدك تكبيرات الشرائح على الغوص في عدة قطع من المعلومات بينما تشعر وكأنك على لوحة واحدة. 

![overview_image](slidezoomsel.png)

بالنسبة لكائنات تكبير الشريحة، توفر Aspose.Slides تعداد [ZoomImageType](https://reference.aspose.com/slides/java/com.aspose.slides/ZoomImageType)، والواجهة [IZoomFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IZoomFrame)، وبعض الأساليب تحت الواجهة [IShapeCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection).

### **إنشاء إطارات التكبير**

يمكنك إضافة إطار تكبير إلى شريحة بهذه الطريقة:

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. إنشاء شرائط جديدة تريد ربط إطارات التكبير بها.
3. إضافة نص تعريف وخلفية إلى الشرائح التي تم إنشاؤها.
4. إضافة إطارات التكبير (التي تحتوي على مراجع للشرائح التي تم إنشاؤها) إلى الشريحة الأولى.
5. حفظ العرض التقديمي المعدل كملف PPTX.

``` java
Presentation pres = new Presentation();
try {
    //إضافة شرائح جديدة إلى العرض التقديمي
    ISlide slide2 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    ISlide slide3 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());

    // إنشاء خلفية للشريحة الثانية
    slide2.getBackground().setType(BackgroundType.OwnBackground);
    slide2.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide2.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);

    // إنشاء مربع نص للشريحة الثانية
    IAutoShape autoshape = slide2.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Second Slide");

    // إنشاء خلفية للشريحة الثالثة
    slide3.getBackground().setType(BackgroundType.OwnBackground);
    slide3.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide3.getBackground().getFillFormat().getSolidFillColor().setColor(Color.darkGray);

    // إنشاء مربع نص للشريحة الثالثة
    autoshape = slide3.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Trird Slide");

    //إضافة كائنات ZoomFrame
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 250, 200, slide2);
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(200, 250, 250, 200, slide3);

    // حفظ العرض التقديمي
    pres.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **إنشاء إطارات تكبير بصور مخصصة**
باستخدام Aspose.Slides for Java، يمكنك إنشاء إطار تكبير بصورة معاينة شريحة مختلفة بهذه الطريقة: 
1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. إنشاء شريحة جديدة تريد ربط إطار التكبير بها.
3. إضافة نص تعريف وخلفية إلى الشريحة.
4. إنشاء كائن [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/IPPImage) بإضافة صورة إلى مجموعة Images المرتبطة بكائن [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) الذي سيُستخدم لملء الإطار.
5. إضافة إطارات التكبير (التي تحتوي على مرجع إلى الشريحة التي تم إنشاؤها) إلى الشريحة الأولى.
6. حفظ العرض التقديمي المعدل كملف PPTX.

``` java
Presentation pres = new Presentation();
try {
    //إضافة شريحة جديدة إلى العرض التقديمي
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());

    // إنشاء خلفية للشريحة الثانية
    slide.getBackground().setType(BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);

    // إنشاء مربع نص للشريحة الثالثة
    IAutoShape autoshape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Second Slide");

    // إنشاء صورة جديدة لكائن التكبير
    IPPImage picture;
        IImage image = Images.fromFile("image.png");
        try {
            picture = pres.getImages().addImage(image);
        } finally {
            if (image != null) image.dispose();
        }
    //إضافة كائن ZoomFrame
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 300, 200, slide, picture);

    // حفظ العرض التقديمي
    pres.save("presentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

### **تنسيق إطارات التكبير**
في الأقسام السابقة، أوضحنا لك كيفية إنشاء إطارات تكبير بسيطة. لإنشاء إطارات تكبير أكثر تعقيدًا، عليك تعديل تنسيق الإطار البسيط. هناك عدة خيارات تنسيق يمكنك تطبيقها على إطار التكبير. 

يمكنك التحكم في تنسيق إطار التكبير على شريحة بهذه الطريقة:

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. إنشاء شرائح جديدة تريد ربط إطارات التكبير بها.
3. إضافة بعض نصوص التعريف والخلفية إلى الشرائح التي تم إنشاؤها.
4. إضافة إطارات التكبير (التي تحتوي على مراجع للشرائح التي تم إنشاؤها) إلى الشريحة الأولى.
5. إنشاء كائن [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/IPPImage) بإضافة صورة إلى مجموعة Images المرتبطة بكائن [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) الذي سيُستخدم لملء الإطار.
6. تعيين صورة مخصصة للإطار الأول.
7. تغيير تنسيق الخط لإطار التكبير الثاني.
8. إزالة الخلفية من صورة إطار التكبير الثاني.
5. حفظ العرض التقديمي المعدل كملف PPTX.

``` java 
Presentation pres = new Presentation();
try {
    //إضافة شرائح جديدة إلى العرض التقديمي
    ISlide slide2 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    ISlide slide3 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());

    // إنشاء خلفية للشريحة الثانية
    slide2.getBackground().setType(BackgroundType.OwnBackground);
    slide2.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide2.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);

    // إنشاء مربع نص للشريحة الثانية
    IAutoShape autoshape = slide2.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Second Slide");

    // إنشاء خلفية للشريحة الثالثة
    slide3.getBackground().setType(BackgroundType.OwnBackground);
    slide3.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide3.getBackground().getFillFormat().getSolidFillColor().setColor(Color.darkGray);

    // إنشاء مربع نص للشريحة الثالثة
    autoshape = slide3.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Trird Slide");

    //إضافة كائنات ZoomFrame
    IZoomFrame zoomFrame1 = pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 250, 200, slide2);
    IZoomFrame zoomFrame2 = pres.getSlides().get_Item(0).getShapes().addZoomFrame(200, 250, 250, 200, slide3);

    // إنشاء صورة جديدة لكائن التكبير
    IPPImage picture;
        IImage image = Images.fromFile("image.png");
        try {
            picture = pres.getImages().addImage(image);
        } finally {
            if (image != null) image.dispose();
        }
    // تعيين صورة مخصصة لكائن zoomFrame1
    zoomFrame1.setImage(picture);

    // تعيين تنسيق إطار التكبير لكائن zoomFrame2
    zoomFrame2.getLineFormat().setWidth(5);
    zoomFrame2.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    zoomFrame2.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.pink);
    zoomFrame2.getLineFormat().setDashStyle(LineDashStyle.DashDot);

    // إعداد عدم إظهار الخلفية لكائن zoomFrame2
    zoomFrame2.setShowBackground(false);

    // حفظ العرض التقديمي
    pres.save("presentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


## **تكبير القسم**
يُعَد تكبير القسم رابطًا إلى قسم في عرضك التقديمي. يمكنك استخدام تكبير الأقسام للعودة إلى الأقسام التي تريد التأكيد عليها حقًا. أو يمكنك استخدامها لتسليط الضوء على كيفية ارتباط أجزاء معينة من العرض. 

![overview_image](seczoomsel.png)

بالنسبة لكائنات تكبير القسم، توفر Aspose.Slides الواجهة [ISectionZoomFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ISectionZoomFrame) وبعض الأساليب تحت الواجهة [IShapeCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection).

### **إنشاء إطارات تكبير القسم**

يمكنك إضافة إطار تكبير قسم إلى شريحة بهذه الطريقة:

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. إنشاء شريحة جديدة.
3. إضافة خلفية تعريف إلى الشريحة التي تم إنشاؤها.
4. إنشاء قسم جديد تريد ربط إطار التكبير به.
5. إضافة إطار تكبير قسم (الذي يحتوي على مراجع إلى القسم الذي تم إنشاؤه) إلى الشريحة الأولى.
6. حفظ العرض التقديمي المعدل كملف PPTX.

``` java
Presentation pres = new Presentation();
try {
    //إضافة شريحة جديدة إلى العرض التقديمي
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.yellow);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // إضافة قسم جديد إلى العرض التقديمي
    pres.getSections().addSection("Section 1", slide);

    // إضافة كائن SectionZoomFrame
    ISectionZoomFrame sectionZoomFrame = pres.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, pres.getSections().get_Item(1));

    // حفظ العرض التقديمي
    pres.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **إنشاء إطارات تكبير القسم بصور مخصصة**

باستخدام Aspose.Slides for Java، يمكنك إنشاء إطار تكبير قسم بصورة معاينة شريحة مختلفة بهذه الطريقة: 

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. إنشاء شريحة جديدة.
3. إضافة خلفية تعريف إلى الشريحة التي تم إنشاؤها.
4. إنشاء قسم جديد تريد ربط إطار التكبير به.
5. إنشاء كائن [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/IPPImage) بإضافة صورة إلى مجموعة Images المرتبطة بكائن [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) الذي سيُستخدم لملء الإطار.
5. إضافة إطار تكبير قسم (الذي يحتوي على مرجع إلى القسم الذي تم إنشاؤه) إلى الشريحة الأولى.
6. حفظ العرض التقديمي المعدل كملف PPTX.

``` java 
Presentation pres = new Presentation();
try {
    //إضافة شريحة جديدة إلى العرض التقديمي
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.yellow);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // إضافة قسم جديد إلى العرض التقديمي
    pres.getSections().addSection("Section 1", slide);

    // إنشاء صورة جديدة لكائن التكبير
    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // إضافة كائن SectionZoomFrame
    ISectionZoomFrame sectionZoomFrame = pres.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, pres.getSections().get_Item(1), picture);

    // حفظ العرض التقديمي
    pres.save("presentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

### **تنسيق إطارات تكبير القسم**

لإنشاء إطارات تكبير قسم أكثر تعقيدًا، عليك تعديل تنسيق الإطار البسيط. هناك عدة خيارات تنسيق يمكنك تطبيقها على إطار تكبير القسم. 

يمكنك التحكم في تنسيق إطار تكبير القسم على شريحة بهذه الطريقة:

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. إنشاء شريحة جديدة.
3. إضافة خلفية تعريف إلى الشريحة التي تم إنشاؤها.
4. إنشاء قسم جديد تريد ربط إطار التكبير به.
5. إضافة إطار تكبير قسم (الذي يحتوي على مراجع إلى القسم الذي تم إنشاؤه) إلى الشريحة الأولى.
6. تغيير الحجم والموقع للكائن الذي تم إنشاءه لتكبير القسم.
7. إنشاء كائن [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/IPPImage) بإضافة صورة إلى مجموعة Images المرتبطة بكائن [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) الذي سيُستخدم لملء الإطار.
8. تعيين صورة مخصصة لإطار تكبير القسم الذي تم إنشاؤه.
9. تعيين قدرة *العودة إلى الشريحة الأصلية من القسم المرتبط*.
10. إزالة الخلفية من صورة إطار تكبير القسم.
11. تغيير تنسيق الخط لإطار التكبير الثاني.
12. تغيير مدة الانتقال.
13. حفظ العرض التقديمي المعدل كملف PPTX.

``` java
Presentation pres = new Presentation();
try {
    //إضافة شريحة جديدة إلى العرض التقديمي
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.yellow);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    //إضافة قسم جديد إلى العرض التقديمي
    pres.getSections().addSection("Section 1", slide);

    //إضافة كائن SectionZoomFrame
    ISectionZoomFrame sectionZoomFrame = pres.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, pres.getSections().get_Item(1));

    //تنسيق SectionZoomFrame
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

    //حفظ العرض التقديمي
    pres.save("presentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


## **ملخص التكبير**

ملخص التكبير يشبه صفحة هبوط حيث يتم عرض جميع أجزاء العرض التقديمي مرة واحدة. عند تقديمك، يمكنك استخدام التكبير للانتقال من مكان إلى آخر في عرضك بأي ترتيب تريده. يمكنك أن تكون مبدعًا، تتخطى أجزاءً، أو تعيد زيارة شرائح دون إيقاف تدفق العرض.

![overview_image](sumzoomsel.png)

بالنسبة لكائنات ملخص التكبير، توفر Aspose.Slides الواجهات [ISummaryZoomFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ISummaryZoomFrame)، [ISummaryZoomSection](https://reference.aspose.com/slides/java/com.aspose.slides/ISummaryZoomSection)، و[ISummaryZoomSectionCollection](https://reference.aspose.com/slides/java/com.aspose.slides/ISummaryZoomSectionCollection) وبعض الأساليب تحت الواجهة [IShapeCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection).

### **إنشاء ملخص التكبير**

يمكنك إضافة إطار ملخص التكبير إلى شريحة بهذه الطريقة:

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. إنشاء شرائح جديدة بخلفية تعريف وأقسام جديدة للشرائح التي تم إنشاؤها.
3. إضافة إطار ملخص التكبير إلى الشريحة الأولى.
4. حفظ العرض التقديمي المعدل كملف PPTX.

``` java 
Presentation pres = new Presentation();
try {
    //إضافة شريحة جديدة إلى العرض التقديمي
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.gray);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // إضافة قسم جديد إلى العرض التقديمي
    pres.getSections().addSection("Section 1", slide);

    //إضافة شريحة جديدة إلى العرض التقديمي
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // إضافة قسم جديد إلى العرض التقديمي
    pres.getSections().addSection("Section 2", slide);

    //إضافة شريحة جديدة إلى العرض التقديمي
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.magenta);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // إضافة قسم جديد إلى العرض التقديمي
    pres.getSections().addSection("Section 3", slide);

    //إضافة شريحة جديدة إلى العرض التقديمي
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.green);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // إضافة قسم جديد إلى العرض التقديمي
    pres.getSections().addSection("Section 4", slide);

    // إضافة كائن SummaryZoomFrame
    ISummaryZoomFrame summaryZoomFrame = pres.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200);

    // حفظ العرض التقديمي
    pres.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


### **إضافة وإزالة قسم ملخص التكبير**

جميع الأقسام في إطار ملخص التكبير ممثلة بكائنات [ISummaryZoomSection](https://reference.aspose.com/slides/java/com.aspose.slides/ISummaryZoomSection) المخزنة في كائن [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/java/com.aspose.slides/ISummaryZoomSectionCollection). يمكنك إضافة أو إزالة كائن قسم ملخص التكبير من خلال الواجهة [ISummaryZoomSectionCollection] بهذه الطريقة:

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. إنشاء شرائح جديدة بخلفية تعريف وأقسام جديدة للشرائح التي تم إنشاؤها.
3. إضافة إطار ملخص التكبير إلى الشريحة الأولى.
4. إضافة شريحة جديدة وقسم جديد إلى العرض التقديمي.
5. إضافة القسم الذي تم إنشاؤه إلى إطار ملخص التكبير.
6. إزالة القسم الأول من إطار ملخص التكبير.
7. حفظ العرض التقديمي المعدل كملف PPTX.

``` java
Presentation pres = new Presentation();
try {
    //إضافة شريحة جديدة إلى العرض التقديمي
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.gray);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    //إضافة قسم جديد إلى العرض التقديمي
    pres.getSections().addSection("Section 1", slide);

    //إضافة شريحة جديدة إلى العرض التقديمي
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    //إضافة قسم جديد إلى العرض التقديمي
    pres.getSections().addSection("Section 2", slide);

    //إضافة كائن SummaryZoomFrame
    ISummaryZoomFrame summaryZoomFrame = pres.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200);

    //إضافة شريحة جديدة إلى العرض التقديمي
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.magenta);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    //إضافة قسم جديد إلى العرض التقديمي
    ISection section3 = pres.getSections().addSection("Section 3", slide);

    //إضافة قسم إلى Summary Zoom
    summaryZoomFrame.getSummaryZoomCollection().addSummaryZoomSection(section3);

    //إزالة قسم من Summary Zoom
    summaryZoomFrame.getSummaryZoomCollection().removeSummaryZoomSection(pres.getSections().get_Item(1));

    //حفظ العرض التقديمي
    pres.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


### **تنسيق أقسام ملخص التكبير**

لإنشاء كائنات قسم ملخص التكبير أكثر تعقيدًا، عليك تعديل تنسيق الإطار البسيط. هناك عدة خيارات تنسيق يمكنك تطبيقها على كائن قسم ملخص التكبير. 

يمكنك التحكم في تنسيق كائن قسم ملخص التكبير داخل إطار ملخص التكبير بهذه الطريقة:

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. إنشاء شرائح جديدة بخلفية تعريف وأقسام جديدة للشرائح التي تم إنشاؤها.
3. إضافة إطار ملخص التكبير إلى الشريحة الأولى.
4. الحصول على كائن قسم ملخص التكبير لأول عنصر من `ISummaryZoomSectionCollection`.
7. إنشاء كائن [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/IPPImage) بإضافة صورة إلى مجموعة الصور المرتبطة بكائن [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) الذي سيُستخدم لملء الإطار.
8. تعيين صورة مخصصة لكائن إطار قسم التكبير الذي تم إنشاؤه.
9. تعيين قدرة *العودة إلى الشريحة الأصلية من القسم المرتبط*.
11. تغيير تنسيق الخط لكائن إطار التكبير الثاني.
12. تغيير مدة الانتقال.
13. حفظ العرض التقديمي المعدل كملف PPTX.

``` java
Presentation pres = new Presentation();
try {
    //إضافة شريحة جديدة إلى العرض التقديمي
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.gray);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // إضافة قسم جديد إلى العرض التقديمي
    pres.getSections().addSection("Section 1", slide);

    //إضافة شريحة جديدة إلى العرض التقديمي
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // إضافة قسم جديد إلى العرض التقديمي
    pres.getSections().addSection("Section 2", slide);

    // إضافة كائن SummaryZoomFrame
    ISummaryZoomFrame summaryZoomFrame = pres.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200);

    // الحصول على أول كائن SummaryZoomSection
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

    // حفظ العرض التقديمي
    pres.save("presentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


## **الأسئلة الشائعة**

**هل يمكنني التحكم في العودة إلى الشريحة "الأم" بعد عرض الهدف؟**  
نعم. يحتوي كل من [Zoom frame](https://reference.aspose.com/slides/java/com.aspose.slides/zoomframe/) أو [section](https://reference.aspose.com/slides/java/com.aspose.slides/sectionzoomframe/) على سلوك `ReturnToParent`، عند تمكينه يعيد المشاهدين إلى الشريحة الأصلية بعد زيارة المحتوى المستهدف.

**هل يمكنني تعديل "السرعة" أو مدة انتقال التكبير؟**  
نعم. يدعم التكبير إعداد `TransitionDuration` بحيث يمكنك التحكم في طول مدة حركة القفزة.

**هل توجد حدود على عدد كائنات التكبير التي يمكن أن يحتويها عرض تقديمي؟**  
لا يوجد حد صريح موثق في واجهة البرمجة. تعتمد الحدود العملية على تعقيد العرض التقديمي العام وأداء المشاهد. يمكنك إضافة العديد من إطارات التكبير، لكن يجدر مراعاة حجم الملف ووقت المعالجة.