---
title: إدارة التكبير
type: docs
weight: 60
url: /java/manage-zoom/
keywords: "تكبير, إطار تكبير, إضافة تكبير, تنسيق إطار التكبير, ملخص تكبير, عرض PowerPoint, جافا, Aspose.Slides for Java"
description: "إضافة تكبير أو إطارات تكبير إلى عروض PowerPoint في جافا"
---

## **نظرة عامة**
يسمح لك التكبير في PowerPoint بالقفز إلى ومن شرائح معينة، وأقسام، وأجزاء من العرض التقديمي. عندما تكون في وضع العرض، قد تكون هذه القدرة على التنقل بسرعة عبر المحتوى مفيدة للغاية.

![overview_image](overview.png)

* لتلخيص عرض تقديمي كامل في شريحة واحدة، استخدم [ملخص تكبير](#ملخص-تكبير).
* لعرض الشرائح المحددة فقط، استخدم [تكبير الشريحة](#تكبير-الشريحة).
* لعرض قسم واحد فقط، استخدم [تكبير القسم](#تكبير-القسم).

## **تكبير الشريحة**
يمكن لتكبير الشريحة أن يجعل عرضك أكثر ديناميكية، مما يسمح لك بالتنقل بحرية بين الشرائح بأي ترتيب تختاره دون مقاطعة تدفق عرضك. تعتبر تكبير الشرائح رائعة للعروض القصيرة التي لا تحتوي على العديد من الأقسام، لكن يمكنك استخدامها أيضًا في سيناريوهات عرض مختلفة.

تساعد تكبير الشرائح في الغوص في قطع متعددة من المعلومات بينما تشعر وكأنك على لوحة قماشية واحدة.

![overview_image](slidezoomsel.png)

بالنسبة لكائنات تكبير الشريحة، توفر Aspose.Slides [ZoomImageType](https://reference.aspose.com/slides/java/com.aspose.slides/ZoomImageType) والتعداد، و [IZoomFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IZoomFrame) الواجهة، وبعض الطرق تحت [IShapeCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection) الواجهة.

### **إنشاء إطارات التكبير**

يمكنك إضافة إطار تكبير على شريحة بهذه الطريقة:

1. أنشئ مثيلاً لفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. أنشئ شرائح جديدة ترغب في ربط إطارات التكبير بها.
3. أضف نص تعريف وخلفية للشرائح التي أنشأتها.
4. أضف إطارات تكبير (تحتوي على مراجع للشرائح التي أنشأتها) إلى الشريحة الأولى.
5. اكتب العرض التقديمي المعدل كملف PPTX.

يوضح هذا الكود بلغة جافا كيفية إنشاء إطار تكبير على شريحة:

``` java
Presentation pres = new Presentation();
try {
    //Adds new slides to the presentation
    ISlide slide2 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    ISlide slide3 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());

    // Creates a background for the second slide
    slide2.getBackground().setType(BackgroundType.OwnBackground);
    slide2.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide2.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);

    // Creates a text box for the second slide
    IAutoShape autoshape = slide2.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("الشريحة الثانية");

    // Creates a background for the third slide
    slide3.getBackground().setType(BackgroundType.OwnBackground);
    slide3.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide3.getBackground().getFillFormat().getSolidFillColor().setColor(Color.darkGray);

    // Create a text box for the third slide
    autoshape = slide3.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("الشريحة الثالثة");

    //Adds ZoomFrame objects
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 250, 200, slide2);
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(200, 250, 250, 200, slide3);

    // Saves the presentation
    pres.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```
### **إنشاء إطارات التكبير باستخدام صور مخصصة**
مع Aspose.Slides لـ Java، يمكنك إنشاء إطار تكبير مع صورة معاينة شريحة مختلفة بهذه الطريقة: 
1. أنشئ مثيلاً لفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. أنشئ شريحة جديدة ترغب في ربط إطار التكبير بها.
3. أضف نص تعريف وخلفية إلى الشريحة.
4. أنشئ كائن [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/IPPImage) عن طريق إضافة صورة إلى مجموعة الصور المرتبطة بكائن [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) التي ستستخدم لملء الإطار.
5. أضف إطارات تكبير (تحتوي على مرجع للعرض التقديمي الذي تم إنشاؤه) إلى الشريحة الأولى.
6. اكتب العرض التقديمي المعدل كملف PPTX.

يوضح هذا الكود بلغة جافا كيفية إنشاء إطار تكبير بصورة مختلفة:

``` java
Presentation pres = new Presentation();
try {
    //Adds a new slide to the presentation
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());

    // Creates a background for the second slide
    slide.getBackground().setType(BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);

    // Creates a text box for the third slide
    IAutoShape autoshape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("الشريحة الثانية");

    // Creates a new image for the zoom object
    IPPImage picture;
        IImage image = Images.fromFile("image.png");
        try {
            picture = pres.getImages().addImage(image);
        } finally {
            if (image != null) image.dispose();
        }
    //Adds the ZoomFrame object
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 300, 200, slide, picture);

    // Saves the presentation
    pres.save("presentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```
### **تنسيق إطارات التكبير**
في الأقسام السابقة، أوضحنا لك كيفية إنشاء إطارات تكبير بسيطة. لإنشاء إطارات تكبير أكثر تعقيدًا، يجب عليك تعديل تنسيق الإطار البسيط. هناك العديد من خيارات التنسيق التي يمكنك تطبيقها على إطار التكبير. 

يمكنك التحكم في تنسيق إطار التكبير على شريحة بهذه الطريقة:

1. أنشئ مثيلاً لفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. أنشئ شرائح جديدة تريد الربط بها لإطار التكبير. 
3. أضف بعض نص التعريف والخلفية للشرائح التي أنشأتها.
4. أضف إطارات التكبير (تحتوي على مراجع للشرائح التي تم إنشاؤها) إلى الشريحة الأولى.
5. أنشئ كائن [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/IPPImage) عن طريق إضافة صورة إلى مجموعة الصور المرتبطة بكائن [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) التي ستستخدم لملء الإطار.
6. قم بتعيين صورة مخصصة لعنصر إطار التكبير الأول.
7. غيّر تنسيق الخط للعنصر الثاني لإطار التكبير.
8. قم بإزالة الخلفية من صورة العنصر الثاني لإطار التكبير.
5. اكتب العرض التقديمي المعدل كملف PPTX.

يوضح هذا الكود بلغة جافا كيفية تغيير تنسيق إطار تكبير على شريحة: 

``` java 
Presentation pres = new Presentation();
try {
    //Adds new slides to the presentation
    ISlide slide2 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    ISlide slide3 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());

    // Creates a background for the second slide
    slide2.getBackground().setType(BackgroundType.OwnBackground);
    slide2.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide2.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);

    // Creates a text box for the second slide
    IAutoShape autoshape = slide2.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("الشريحة الثانية");

    // Creates a background for the third slide
    slide3.getBackground().setType(BackgroundType.OwnBackground);
    slide3.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide3.getBackground().getFillFormat().getSolidFillColor().setColor(Color.darkGray);

    // Creates a text box for the third slide
    autoshape = slide3.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("الشريحة الثالثة");

    //Adds ZoomFrame objects
    IZoomFrame zoomFrame1 = pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 250, 200, slide2);
    IZoomFrame zoomFrame2 = pres.getSlides().get_Item(0).getShapes().addZoomFrame(200, 250, 250, 200, slide3);

    // Creates a new image for the zoom object
    IPPImage picture;
        IImage image = Images.fromFile("image.png");
        try {
            picture = pres.getImages().addImage(image);
        } finally {
            if (image != null) image.dispose();
        }
    // Sets custom image for zoomFrame1 object
    zoomFrame1.setImage(picture);

    // Sets a zoom frame format for the zoomFrame2 object
    zoomFrame2.getLineFormat().setWidth(5);
    zoomFrame2.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    zoomFrame2.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.pink);
    zoomFrame2.getLineFormat().setDashStyle(LineDashStyle.DashDot);

    // Setting for Do not show background for zoomFrame2 object
    zoomFrame2.setShowBackground(false);

    // Saves the presentation
    pres.save("presentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **تكبير القسم**

تعتبر تكبير القسم ارتباطًا بقسم في عرضك. يمكنك استخدام تكبير الأقسام للعودة إلى الأقسام التي تريد التأكيد عليها حقًا. أو يمكنك استخدامها لتسليط الضوء على كيفية ارتباط بعض قطع عرضك معًا.

![overview_image](seczoomsel.png)

بالنسبة لكائنات تكبير الأقسام، توفر Aspose.Slides الواجهة [ISectionZoomFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ISectionZoomFrame) وبعض الطرق تحت الواجهة [IShapeCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection).

### **إنشاء إطارات تكبير القسم**

يمكنك إضافة إطار تكبير قسم إلى شريحة بهذه الطريقة:

1. أنشئ مثيلاً لفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. أنشئ شريحة جديدة. 
3. أضف خلفية تعريف إلى الشريحة التي أنشأتها.
4. أنشئ قسمًا جديدًا ترغب في ربط إطار التكبير به. 
5. أضف إطار تكبير قسم (يحتوي على مراجع إلى القسم الذي تم إنشاؤه) إلى الشريحة الأولى.
6. اكتب العرض التقديمي المعدل كملف PPTX.

يوضح هذا الكود بلغة جافا كيفية إنشاء إطار تكبير على شريحة:

``` java
Presentation pres = new Presentation();
try {
    //Adds a new slide to the presentation
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.yellow);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Adds a new Section to the presentation
    pres.getSections().addSection("القسم 1", slide);

    // Adds a SectionZoomFrame object
    ISectionZoomFrame sectionZoomFrame = pres.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, pres.getSections().get_Item(1));

    // Saves the presentation
    pres.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```
### **إنشاء إطارات تكبير القسم باستخدام صور مخصصة**

باستخدام Aspose.Slides لـ Java، يمكنك إنشاء إطار تكبير قسم بصورة معاينة شريحة مختلفة بهذه الطريقة: 

1. أنشئ مثيلاً لفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. أنشئ شريحة جديدة.
3. أضف خلفية تعريف إلى الشريحة التي تم إنشاؤها.
4. أنشئ قسمًا جديدًا ترغب في ربط إطار التكبير به. 
5. أنشئ كائن [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/IPPImage) عن طريق إضافة صورة إلى مجموعة الصور المرتبطة بكائن [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) التي ستستخدم لملء الإطار.
5. أضف إطار تكبير قسم (يحتوي على مرجع إلى القسم الذي تم إنشاؤه) إلى الشريحة الأولى.
6. اكتب العرض التقديمي المعدل كملف PPTX.

يوضح هذا الكود بلغة جافا كيفية إنشاء إطار تكبير بصورة مختلفة:

``` java 
Presentation pres = new Presentation();
try {
    //Adds new slide to the presentation
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.yellow);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Adds a new Section to the presentation
    pres.getSections().addSection("القسم 1", slide);

    // Creates a new image for the zoom object
    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // Adds SectionZoomFrame object
    ISectionZoomFrame sectionZoomFrame = pres.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, pres.getSections().get_Item(1), picture);

    // Saves the presentation
    pres.save("presentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```
### **تنسيق إطارات تكبير القسم**

لإنشاء إطارات تكبير قسم أكثر تعقيدًا، يجب عليك تعديل تنسيق الإطار البسيط. هناك العديد من خيارات التنسيق التي يمكنك تطبيقها على إطارات تكبير القسم. 

يمكنك التحكم في تنسيق إطار تكبير القسم على شريحة بهذه الطريقة:

1. أنشئ مثيلاً لفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. أنشئ شريحة جديدة.
3. أضف خلفية تعريف إلى الشريحة التي أنشأتها.
4. أنشئ قسمًا جديدًا ترغب في ربط إطار التكبير به. 
5. أضف إطار تكبير قسم (يحتوي على مراجع إلى القسم الذي تم إنشاؤه) إلى الشريحة الأولى.
6. غير الحجم والموضع لكائن تكبير القسم الذي تم إنشاؤه.
7. أنشئ كائن [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/IPPImage) عن طريق إضافة صورة إلى مجموعة الصور المرتبطة بكائن [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) التي ستستخدم لملء الإطار.
8. قم بتعيين صورة مخصصة لإطار تكبير القسم الذي تم إنشاؤه.
9. عيّن القدرة على *العودة إلى الشريحة الأصلية من القسم المرتبط*. 
10. قم بإزالة الخلفية من صورة إطار تكبير القسم.
11. غيّر تنسيق الخط لكائن إطار التكبير الثاني.
12. غيّر مدة الانتقال.
13. اكتب العرض التقديمي المعدل كملف PPTX.

يوضح هذا الكود بلغة جافا كيفية تغيير تنسيق إطار تكبير القسم:

``` java
Presentation pres = new Presentation();
try {
    //Adds a new slide to the presentation
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.yellow);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Adds a new Section to the presentation
    pres.getSections().addSection("القسم 1", slide);

    // Add SectionZoomFrame object
    ISectionZoomFrame sectionZoomFrame = pres.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, pres.getSections().get_Item(1));

    // Formatting for SectionZoomFrame
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

    // Saves the presentation
    pres.save("presentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


## **ملخص التكبير**

يعتبر ملخص التكبير مثل صفحة الهبوط حيث يتم عرض جميع قطع عرضك مرة واحدة. عندما تقدم، يمكنك استخدام التكبير للانتقال من مكان إلى آخر في عرضك بأي ترتيب تريده. يمكنك أن تكون مبدعًا، وتخطي إلى الأمام، أو إعادة زيارة قطع من عرض الشرائح الخاص بك دون مقاطعة تدفق عرضك.

![overview_image](sumzoomsel.png)

بالنسبة لكائنات ملخص التكبير، توفر Aspose.Slides الواجهة [ISummaryZoomFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ISummaryZoomFrame)، و [ISummaryZoomSection](https://reference.aspose.com/slides/java/com.aspose.slides/ISummaryZoomSection)، و [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/java/com.aspose.slides/ISummaryZoomSectionCollection) وبعض الطرق تحت الواجهة [IShapeCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection).

### **إنشاء ملخص التكبير**

يمكنك إضافة إطار ملخص التكبير إلى شريحة بهذه الطريقة:

1. أنشئ مثيلاً لفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. أنشئ شرائح جديدة مع خلفية تعريف وأقسام جديدة للشرائح التي تم إنشاؤها.
3. أضف إطار الملخص التكبير إلى الشريحة الأولى.
4. اكتب العرض التقديمي المعدل كملف PPTX.

يوضح هذا الكود بلغة جافا كيفية إنشاء إطار ملخص التكبير على شريحة:

``` java 
Presentation pres = new Presentation();
try {
    //Adds a new slide to the presentation
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.gray);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Adds a new section to the presentation
    pres.getSections().addSection("القسم 1", slide);

    //Adds a new slide to the presentation
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Adds a new section to the presentation
    pres.getSections().addSection("القسم 2", slide);

    //Adds a new slide to the presentation
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.magenta);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Adds a new section to the presentation
    pres.getSections().addSection("القسم 3", slide);

    //Adds a new slide to the presentation
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.green);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Adds a new section to the presentation
    pres.getSections().addSection("القسم 4", slide);

    // Adds a SummaryZoomFrame object
    ISummaryZoomFrame summaryZoomFrame = pres.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200);

    // Saves the presentation
    pres.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **إضافة وإزالة قسم ملخص التكبير**

تمثل جميع الأقسام في إطار ملخص التكبير بواسطة كائنات [ISummaryZoomSection](https://reference.aspose.com/slides/java/com.aspose.slides/ISummaryZoomSection)، والتي يتم تخزينها في كائن [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/java/com.aspose.slides/ISummaryZoomSectionCollection). يمكنك إضافة أو إزالة كائن قسم ملخص التكبير من خلال واجهة [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/java/com.aspose.slides/ISummaryZoomSectionCollection) بهذه الطريقة:

1. أنشئ مثيلاً لفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. أنشئ شرائح جديدة مع خلفية تعريف وأقسام جديدة للشرائح التي تم إنشاؤها.
3. أضف إطار ملخص التكبير إلى الشريحة الأولى.
4. أضف شريحة جديدة وقسمًا إلى العرض التقديمي.
5. أضف القسم الذي تم إنشاؤه إلى إطار ملخص التكبير.
6. أزل القسم الأول من إطار ملخص التكبير.
7. اكتب العرض التقديمي المعدل كملف PPTX.

يظهر لك هذا الكود بلغة جافا كيفية إضافة وإزالة أقسام من إطار ملخص التكبير:

``` java
Presentation pres = new Presentation();
try {
    //Adds a new slide to the presentation
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.gray);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Adds a new section to the presentation
    pres.getSections().addSection("القسم 1", slide);

    //Adds a new slide to the presentation
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Adds a new section to the presentation
    pres.getSections().addSection("القسم 2", slide);

    // Adds SummaryZoomFrame object
    ISummaryZoomFrame summaryZoomFrame = pres.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200);

    //Adds a new slide to the presentation
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.magenta);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Adds a new section to the presentation
    ISection section3 = pres.getSections().addSection("القسم 3", slide);

    // Adds a section to the Summary Zoom
    summaryZoomFrame.getSummaryZoomCollection().addSummaryZoomSection(section3);

    // Removes section from the Summary Zoom
    summaryZoomFrame.getSummaryZoomCollection().removeSummaryZoomSection(pres.getSections().get_Item(1));

    // Saves the presentation
    pres.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **تنسيق أقسام ملخص التكبير**

لإنشاء كائنات أقسام ملخص التكبير الأكثر تعقيدًا، يجب عليك تعديل تنسيق الإطار البسيط. هناك العديد من خيارات التنسيق التي يمكنك تطبيقها على كائن قسم ملخص التكبير. 

يمكنك التحكم في تنسيق كائن قسم الملخص التكبير في إطار الملخص بهذه الطريقة:

1. أنشئ مثيلاً لفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. أنشئ شرائح جديدة مع خلفية تعريف وأقسام جديدة للشرائح التي تم إنشاؤها.
3. أضف إطار ملخص التكبير إلى الشريحة الأولى.
4. احصل على كائن قسم ملخص التكبير الأول من `ISummaryZoomSectionCollection`.
7. أنشئ كائن [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/IPPImage) عن طريق إضافة صورة إلى مجموعة الصور المرتبطة بكائن [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) التي ستستخدم لملء الإطار.
8. قم بتعيين صورة مخصصة لكائن قسم الملخص التكبير الذي تم إنشاؤه.
9. عيّن القدرة على *العودة إلى الشريحة الأصلية من القسم المرتبط*. 
11. غيّر تنسيق الخط لكائن إطار التكبير الثاني.
12. غيّر مدة الانتقال.
13. اكتب العرض التقديمي المعدل كملف PPTX.

يوضح هذا الكود بلغة جافا كيفية تغيير التنسيق لكائن قسم ملخص التكبير:

``` java
Presentation pres = new Presentation();
try {
    //Adds a new slide to the presentation
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.gray);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Adds a new section to the presentation
    pres.getSections().addSection("القسم 1", slide);

    //Adds a new slide to the presentation
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Adds a new section to the presentation
    pres.getSections().addSection("القسم 2", slide);

    // Adds a SummaryZoomFrame object
    ISummaryZoomFrame summaryZoomFrame = pres.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200);

    // Gets the first SummaryZoomSection object
    ISummaryZoomSection summarySection = summaryZoomFrame.getSummaryZoomCollection().get_Item(0);

    // Formatting for SummaryZoomSection object
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

    // Saves the presentation
    pres.save("presentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```