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
- تكبير الموجز
- إضافة تكبير
- PowerPoint
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "إنشاء وتخصيص التكبير باستخدام Aspose.Slides لنظام Android عبر Java — الانتقال بين الأقسام، إضافة الصور المصغرة والانتقالات عبر عروض PPT و PPTX و ODP."
---

## **نظرة عامة**
تسمح لك أدوات التكبير في PowerPoint بالقفز إلى ومن الشرائح المحددة، الأقسام، وأجزاء العرض التقديمي. عند تقديم العرض، قد تكون هذه القدرة على التنقل السريع عبر المحتوى مفيدة للغاية.

![overview_image](overview.png)

* لتلخيص عرض كامل على شريحة واحدة، استخدم [التكبير الموجز](#Summary-Zoom).
* لعرض الشرائح المحددة فقط، استخدم [تكبير الشريحة](#Slide-Zoom).
* لعرض قسم واحد فقط، استخدم [تكبير القسم](#Section-Zoom).

## **تكبير الشريحة**
يمكن أن يجعل تكبير الشريحة عرضك التقديمي أكثر ديناميكية، حيث يتيح لك التنقل بحرية بين الشرائح بأي ترتيب تختاره دون إيقاف تدفق العرض. تكبير الشرائح رائع للعروض القصيرة التي لا تحتوي على أقسام كثيرة، لكن لا يزال بإمكانك استخدامه في سيناريوهات عرض مختلفة.

يساعدك تكبير الشرائح على استكشاف معلومات متعددة بينما تشعر أنك على لوحة واحدة.

![overview_image](slidezoomsel.png)

لكائنات تكبير الشريحة، توفر Aspose.Slides تعداد ZoomImageType، واجهة IZoomFrame، وبعض الأساليب تحت واجهة IShapeCollection.

### **إنشاء إطارات التكبير**
يمكنك إضافة إطار تكبير إلى شريحة بهذه الطريقة:

1. إنشاء كائن من فئة Presentation.
2. إنشاء شرائح جديدة لربط إطارات التكبير بها.
3. إضافة نص تعريف وخلفية إلى الشرائح التي تم إنشاؤها.
4. إضافة إطارات تكبير (التي تحتوي على مراجع للشرائح التي تم إنشاؤها) إلى الشريحة الأولى.
5. كتابة العرض المعدل كملف PPTX.

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

    // ينشئ مربع نص للشريحة الثانية
    IAutoShape autoshape = slide2.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Second Slide");

    // ينشئ خلفية للشريحة الثالثة
    slide3.getBackground().setType(BackgroundType.OwnBackground);
    slide3.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide3.getBackground().getFillFormat().getSolidFillColor().setColor(Color.darkGray);

    // ينشئ مربع نص للشريحة الثالثة
    autoshape = slide3.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Trird Slide");

    //يضيف كائنات ZoomFrame objects
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 250, 200, slide2);
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(200, 250, 250, 200, slide3);

    // يحفظ العرض التقديمي
    pres.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


### **إنشاء إطارات التكبير بصور مخصصة**
باستخدام Aspose.Slides لنظام Android عبر Java، يمكنك إنشاء إطار تكبير بصورة معاينة شريحة مختلفة بهذه الطريقة:

1. إنشاء كائن من فئة Presentation.
2. إنشاء شريحة جديدة لربط إطار التكبير بها.
3. إضافة نص تعريف وخلفية إلى الشريحة.
4. إنشاء كائن IPPImage عبر إضافة صورة إلى مجموعة Images المرتبطة بكائن Presentation الذي سيُستخدم لتعبئة الإطار.
5. إضافة إطارات تكبير (التي تحتوي على مرجع إلى الشريحة التي تم إنشاؤها) إلى الشريحة الأولى.
6. كتابة العرض المعدل كملف PPTX.

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
    //يضيف كائن ZoomFrame object
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 300, 200, slide, picture);

    // يحفظ العرض التقديمي
    pres.save("presentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


### **تنسيق إطارات التكبير**
في الأقسام السابقة، أظهرنا لك كيفية إنشاء إطارات تكبير بسيطة. لإنشاء إطارات تكبير أكثر تعقيدًا، تحتاج إلى تعديل تنسيق الإطار البسيط. هناك عدة خيارات تنسيق يمكنك تطبيقها على إطار التكبير.

يمكنك التحكم في تنسيق إطار التكبير على شريحة بهذه الطريقة:

1. إنشاء كائن من فئة Presentation.
2. إنشاء شرائح جديدة للربط التي تنوي ربط إطار التكبير بها.
3. إضافة نص تعريف وخلفية إلى الشرائح التي تم إنشاؤها.
4. إضافة إطارات تكبير (التي تحتوي على مراجع إلى الشرائح التي تم إنشاؤها) إلى الشريحة الأولى.
5. إنشاء كائن IPPImage عبر إضافة صورة إلى مجموعة Images المرتبطة بكائن Presentation الذي سيُستخدم لتعبئة الإطار.
6. تعيين صورة مخصصة لكائن إطار التكبير الأول.
7. تغيير تنسيق الخط لكائن إطار التكبير الثاني.
8. إزالة الخلفية من صورة كائن إطار التكبير الثاني.
5. كتابة العرض المعدل كملف PPTX.

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

    // ينشئ مربع نص للشريحة الثانية
    IAutoShape autoshape = slide2.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Second Slide");

    // ينشئ خلفية للشريحة الثالثة
    slide3.getBackground().setType(BackgroundType.OwnBackground);
    slide3.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide3.getBackground().getFillFormat().getSolidFillColor().setColor(Color.darkGray);

    // ينشئ مربع نص للشريحة الثالثة
    autoshape = slide3.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Trird Slide");

    //يضيف كائنات ZoomFrame
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
    // يضبط صورة مخصصة لكائن zoomFrame1
    zoomFrame1.setImage(picture);

    // يضبط تنسيق إطار التكبير لكائن zoomFrame2
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
تكبير القسم هو ارتباط إلى قسم في عرضك التقديمي. يمكنك استخدام تكبير الأقسام للعودة إلى الأقسام التي ترغب في التأكيد عليها. أو يمكنك استخدامها لتسليط الضوء على كيفية ارتباط أجزاء معينة من عرضك.

![overview_image](seczoomsel.png)

لكائنات تكبير القسم، توفر Aspose.Slides واجهة ISectionZoomFrame وبعض الأساليب تحت واجهة IShapeCollection.

### **إنشاء إطارات تكبير القسم**
يمكنك إضافة إطار تكبير القسم إلى شريحة بهذه الطريقة:

1. إنشاء كائن من فئة Presentation.
2. إنشاء شريحة جديدة.
3. إضافة خلفية تعريفية إلى الشريحة التي تم إنشاؤها.
4. إنشاء قسم جديد لربط إطار التكبير به.
5. إضافة إطار تكبير قسم (الذي يحتوي على مراجع إلى القسم الذي تم إنشاؤه) إلى الشريحة الأولى.
6. كتابة العرض المعدل كملف PPTX.

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


### **إنشاء إطارات تكبير القسم بصور مخصصة**
باستخدام Aspose.Slides لنظام Android عبر Java، يمكنك إنشاء إطار تكبير قسم بصورة معاينة شريحة مختلفة بهذه الطريقة:

1. إنشاء كائن من فئة Presentation.
2. إنشاء شريحة جديدة.
3. إضافة خلفية تعريفية إلى الشريحة التي تم إنشاؤها.
4. إنشاء قسم جديد لربط إطار التكبير به.
5. إنشاء كائن IPPImage عبر إضافة صورة إلى مجموعة Images المرتبطة بكائن Presentation الذي سيُستخدم لتعبئة الإطار.
5. إضافة إطار تكبير قسم (الذي يحتوي على مرجع إلى القسم الذي تم إنشاؤه) إلى الشريحة الأولى.
6. كتابة العرض المعدل كملف PPTX.

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

    //ينشئ صورة جديدة لكائن التكبير
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
لإنشاء إطارات تكبير قسم أكثر تعقيدًا، يجب تعديل تنسيق إطار بسيط. هناك عدة خيارات تنسيق يمكنك تطبيقها على إطار تكبير القسم.

يمكنك التحكم في تنسيق إطار تكبير القسم على شريحة بهذه الطريقة:

1. إنشاء كائن من فئة Presentation.
2. إنشاء شريحة جديدة.
3. إضافة خلفية تعريفية إلى الشريحة التي تم إنشاؤها.
4. إنشاء قسم جديد لربط إطار التكبير به.
5. إضافة إطار تكبير قسم (الذي يحتوي على مراجع إلى القسم الذي تم إنشاؤه) إلى الشريحة الأولى.
6. تغيير الحجم والموقع لكائن تكبير القسم الذي تم إنشاؤه.
7. إنشاء كائن IPPImage عبر إضافة صورة إلى مجموعة Images المرتبطة بكائن Presentation الذي سيُستخدم لتعبئة الإطار.
8. تعيين صورة مخصصة لكائن إطار تكبير القسم الذي تم إنشاؤه.
9. تفعيل قدرة *العودة إلى الشريحة الأصلية من القسم المرتبط*.
10. إزالة الخلفية من صورة كائن إطار تكبير القسم.
11. تغيير تنسيق الخط لكائن إطار التكبير الثاني.
12. تغيير مدة الانتقال.
13. كتابة العرض المعدل كملف PPTX.

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

    // تنسيق SectionZoomFrame
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


## **تكبير الموجز**
تكبير الموجز يشبه صفحة هبوط يتم فيها عرض جميع أجزاء عرضك التقديمي مرة واحدة. عند تقديم العرض، يمكنك استخدام التكبير للانتقال من مكان إلى آخر في عرضك بأي ترتيب تختاره. يمكنك الإبداع، التخطي إلى الأمام، أو إعادة زيارة أجزاء عرض الشرائح دون إيقاف تدفق العرض.

![overview_image](sumzoomsel.png)

لكائنات تكبير الموجز، توفر Aspose.Slides واجهات ISummaryZoomFrame و ISummaryZoomSection و ISummaryZoomSectionCollection وبعض الأساليب تحت واجهة IShapeCollection.

### **إنشاء تكبير الموجز**
يمكنك إضافة إطار تكبير الموجز إلى شريحة بهذه الطريقة:

1. إنشاء كائن من فئة Presentation.
2. إنشاء شرائح جديدة مع خلفية تعريفية وأقسام جديدة للشرائح التي تم إنشاؤها.
3. إضافة إطار تكبير الموجز إلى الشريحة الأولى.
4. كتابة العرض المعدل كملف PPTX.

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

    //يضيف شريحة جديدة إلى العرض التقديمي
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.magenta);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // يضيف قسمًا جديدًا إلى العرض التقديمي
    pres.getSections().addSection("Section 3", slide);

    //يضيف شريحة جديدة إلى العرض التقديمي
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


### **إضافة وإزالة قسم تكبير الموجز**
جميع الأقسام في إطار تكبير الموجز تمثلها كائنات ISummaryZoomSection، والتي تُخزن في كائن ISummaryZoomSectionCollection. يمكنك إضافة أو إزالة كائن قسم تكبير الموجز عبر واجهة ISummaryZoomSectionCollection بهذه الطريقة:

1. إنشاء كائن من فئة Presentation.
2. إنشاء شرائح جديدة مع خلفية تعريفية وأقسام جديدة للشرائح التي تم إنشاؤها.
3. إضافة إطار تكبير الموجز إلى الشريحة الأولى.
4. إضافة شريحة جديدة وقسم إلى العرض.
5. إضافة القسم الذي تم إنشاؤه إلى إطار تكبير الموجز.
6. إزالة القسم الأول من إطار تكبير الموجز.
7. كتابة العرض المعدل كملف PPTX.

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

    // يضيف قسمًا إلى تكبير الموجز
    summaryZoomFrame.getSummaryZoomCollection().addSummaryZoomSection(section3);

    // يزيل القسم من تكبير الموجز
    summaryZoomFrame.getSummaryZoomCollection().removeSummaryZoomSection(pres.getSections().get_Item(1));

    // يحفظ العرض التقديمي
    pres.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


### **تنسيق أقسام تكبير الموجز**
لإنشاء كائنات أقسام تكبير الموجز أكثر تعقيدًا، يجب تعديل تنسيق إطار بسيط. هناك عدة خيارات تنسيق يمكنك تطبيقها على كائن قسم تكبير الموجز.

يمكنك التحكم في تنسيق كائن قسم تكبير الموجز داخل إطار تكبير الموجز بهذه الطريقة:

1. إنشاء كائن من فئة Presentation.
2. إنشاء شرائح جديدة مع خلفية تعريفية وأقسام جديدة للشرائح التي تم إنشاؤها.
3. إضافة إطار تكبير الموجز إلى الشريحة الأولى.
4. الحصول على كائن قسم تكبير الموجز الأول من `ISummaryZoomSectionCollection`.
7. إنشاء كائن IPPImage عبر إضافة صورة إلى مجموعة images المرتبطة بكائن Presentation الذي سيُستخدم لتعبئة الإطار.
8. تعيين صورة مخصصة لكائن إطار تكبير القسم الذي تم إنشاؤه.
9. تفعيل قدرة *العودة إلى الشريحة الأصلية من القسم المرتبط*.
11. تغيير تنسيق الخط لكائن إطار التكبير الثاني.
12. تغيير مدة الانتقال.
13. كتابة العرض المعدل كملف PPTX.

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

    // يحصل على كائن SummaryZoomSection الأول
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


## **الأسئلة المتكررة**
**هل يمكنني التحكم في العودة إلى الشريحة "الأصلية" بعد عرض الهدف؟**  
نعم. يمتلك إطار التكبير أو القسم سلوك العودة إلى الأصل، والذي عند تفعيله يُعيد المشاهدين إلى الشريحة الأصلية بعد زيارة المحتوى المستهدف.

**هل يمكنني تعديل "السرعة" أو مدة انتقال التكبير؟**  
نعم. يدعم التكبير تعيين مدة الانتقال لتتمكن من التحكم في مدى طول مدة حركة القفزة.

**هل هناك حدود لعدد كائنات التكبير التي يمكن للعرض التقديمي احتواؤها؟**  
لا توجد حدود صريحة في وثائق API. تعتمد الحدود العملية على تعقيد العرض التقديمي العام وأداء المشاهد. يمكنك إضافة العديد من إطارات التكبير، لكن يجدر مراعاة حجم الملف وزمن التجسيد.