---
title: إدارة الزوم
type: docs
weight: 60
url: /ar/androidjava/manage-zoom/
keywords: "الزوم, إطار الزوم, إضافة زوم, تنسيق إطار الزوم, ملخص زوم, عرض بوربوينت, جافا, Aspose.Slides لاندرويد عبر جافا"
description: "أضف الزوم أو إطارات الزوم إلى عروض بوربوينت في جافا"
---

## **نظرة عامة**
يمكن أن يسمح لك الزوم في PowerPoint بالانتقال بسرعة إلى ومن شرائح معينة أو أقسام أو أجزاء من العرض التقديمي. عندما تقدم عرضًا، قد تكون هذه القدرة على التنقل بسرعة عبر المحتوى مفيدة جدًا.

![overview_image](overview.png)

* لتلخيص عرض كامل على شريحة واحدة، استخدم [ملخص زوم](#Summary-Zoom).
* لإظهار الشرائح المختارة فقط، استخدم [زوم الشريحة](#Slide-Zoom).
* لإظهار قسم واحد فقط، استخدم [زوم القسم](#Section-Zoom).

## **زوم الشريحة**
يمكن أن يجعل زوم الشريحة عرضك أكثر ديناميكية، مما يتيح لك التنقل بحرية بين الشرائح بأي ترتيب تختاره دون مقاطعة تدفق عرضك. زوم الشرائح رائع للعروض القصيرة دون العديد من الأقسام، لكن يمكنك استخدامه في سيناريوهات عرض مختلفة.

يساعد زوم الشرائح في الوصول إلى قطع متعددة من المعلومات بينما تشعر أنك على لوحة واحدة.

![overview_image](slidezoomsel.png)

لتحديد كائنات زوم الشريحة، تقدم Aspose.Slides التعداد [ZoomImageType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ZoomImageType)، الواجهة [IZoomFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IZoomFrame)، وبعض الطرق ضمن واجهة [IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection).

### **إنشاء إطارات الزوم**

يمكنك إضافة إطار زوم على شريحة بهذه الطريقة:

1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. أنشئ شرائح جديدة تريد ربط إطارات الزوم بها.
3. أضف نص تعريف وخلفية للشرائح التي تم إنشاؤها.
4. أضف إطارات الزوم (التي تحتوي على مراجع للشرائح التي تم إنشاؤها) للشريحة الأولى.
5. اكتب العرض التقديمي المعدل كملف PPTX.

يوضح لك كود جافا هذا كيفية إنشاء إطار زوم على شريحة:

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
    autoshape.getTextFrame().setText("شريحة ثانية");

    // Creates a background for the third slide
    slide3.getBackground().setType(BackgroundType.OwnBackground);
    slide3.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide3.getBackground().getFillFormat().getSolidFillColor().setColor(Color.darkGray);

    // Create a text box for the third slide
    autoshape = slide3.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("شريحة ثالثة");

    //Adds ZoomFrame objects
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 250, 200, slide2);
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(200, 250, 250, 200, slide3);

    // Saves the presentation
    pres.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```
### **إنشاء إطارات الزوم باستخدام صور مخصصة**
مع Aspose.Slides لاندرويد عبر جافا، يمكنك إنشاء إطار زوم بصورة معاينة شريحة مختلفة بهذه الطريقة:
1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. أنشئ شريحة جديدة تريد ربط إطار الزوم بها.
3. أضف نص تعريف وخلفية للشريحة.
4. أنشئ كائن [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPPImage) عن طريق إضافة صورة إلى مجموعة الصور المرتبطة بكائن [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) التي ستستخدم لملء الإطار.
5. أضف إطارات الزوم (التي تحتوي على مرجع للشريحة التي تم إنشاؤها) للشريحة الأولى.
6. اكتب العرض التقديمي المعدل كملف PPTX.

يوضح لك كود جافا هذا كيفية إنشاء إطار زوم بصورة مختلفة:

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
    autoshape.getTextFrame().setText("شريحة ثانية");

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
### **تنسيق إطارات الزوم**
في الأقسام السابقة، أظهرنا لك كيفية إنشاء إطارات زوم بسيطة. لإنشاء إطارات زوم أكثر تعقيدًا، يجب عليك تغيير تنسيق إطار بسيط. هناك العديد من خيارات التنسيق التي يمكنك تطبيقها على إطار الزوم. 

يمكنك التحكم في تنسيق إطار الزوم على شريحة بهذه الطريقة:

1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. أنشئ شرائح جديدة لربطها بإطار الزوم الذي تنوي ربطه.
3. أضف بعض نص التعريف وخلفية للشرائح التي تم إنشاؤها.
4. أضف إطارات الزوم (التي تحتوي على مراجع إلى الشرائح التي تم إنشاؤها) للشريحة الأولى.
5. أنشئ كائن [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPPImage) عن طريق إضافة صورة إلى مجموعة الصور المرتبطة بكائن [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) التي ستستخدم لملء الإطار.
6. قم بتعيين صورة مخصصة لكائن إطار الزوم الأول.
7. غيّر تنسيق الخط للكائن الثاني من إطار الزوم.
8. أزل الخلفية من صورة العنصر الثاني من إطار الزوم.
9. اكتب العرض التقديمي المعدل كملف PPTX.

يوضح لك كود جافا هذا كيفية تغيير تنسيق إطار الزوم على شريحة:

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
    autoshape.getTextFrame().setText("شريحة ثانية");

    // Creates a background for the third slide
    slide3.getBackground().setType(BackgroundType.OwnBackground);
    slide3.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide3.getBackground().getFillFormat().getSolidFillColor().setColor(Color.darkGray);

    // Creates a text box for the third slide
    autoshape = slide3.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("شريحة ثالثة");

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

## **زوم القسم**

زوم القسم هو رابط إلى قسم في عرضك التقديمي. يمكنك استخدام زوم الأقسام للعودة إلى الأقسام التي تريد التأكيد عليها. أو يمكنك استخدامها لتسليط الضوء على كيفية ارتباط بعض أجزاء عرضك. 

![overview_image](seczoomsel.png)

بالنسبة لأجزاء زوم القسم، توفر Aspose.Slides الواجهة [ISectionZoomFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISectionZoomFrame) وبعض الطرق ضمن الواجهة [IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection).

### **إنشاء إطارات زوم القسم**

يمكنك إضافة إطار زوم القسم إلى شريحة بهذه الطريقة:

1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. أنشئ شريحة جديدة. 
3. أضف خلفية تعريفية إلى الشريحة التي تم إنشاؤها.
4. أنشئ قسمًا جديدًا تريد ربط إطار الزوم به. 
5. أضف إطار زوم قسم (يحتوي على مراجع إلى القسم الذي تم إنشاؤه) إلى الشريحة الأولى.
6. اكتب العرض التقديمي المعدل كملف PPTX.

يوضح لك كود جافا هذا كيفية إنشاء إطار زوم على شريحة:

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
### **إنشاء إطارات زوم القسم باستخدام صور مخصصة**

باستخدام Aspose.Slides لاندرويد عبر جافا، يمكنك إنشاء إطار زوم قسم بصورة معاينة شريحة مختلفة بهذه الطريقة:

1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. أنشئ شريحة جديدة.
3. أضف خلفية تعريفية للشريحة التي تم إنشاؤها.
4. أنشئ قسمًا جديدًا تريد ربط إطار الزوم به. 
5. أنشئ كائن [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPPImage) عن طريق إضافة صورة إلى مجموعة الصور المرتبطة بكائن [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) التي ستستخدم لملء الإطار.
5. أضف إطار زوم قسم (يحتوي على مرجع إلى القسم الذي تم إنشاؤه) إلى الشريحة الأولى.
6. اكتب العرض التقديمي المعدل كملف PPTX.

يوضح لك كود جافا هذا كيفية إنشاء إطار زوم بصورة مختلفة:

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
### **تنسيق إطارات زوم القسم**

لإنشاء إطارات زوم القسم الأكثر تعقيدًا، يجب عليك تغيير تنسيق إطار بسيط. هناك العديد من خيارات التنسيق التي يمكنك تطبيقها على إطار زوم القسم. 

يمكنك التحكم في تنسيق إطار زوم القسم بهذه الطريقة:

1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. أنشئ شريحة جديدة.
3. أضف خلفية تعريفية للشريحة التي تم إنشاؤها.
4. أنشئ قسمًا جديدًا تريد ربط إطار الزوم به. 
5. أضف إطار زوم قسم (يحتوي على مراجع إلى القسم الذي تم إنشاؤه) إلى الشريحة الأولى.
6. غيّر الحجم والموضع لكائن الزوم القسم الذي تم إنشاؤه.
7. أنشئ كائن [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPPImage) عن طريق إضافة صورة إلى مجموعة الصور المرتبطة بكائن [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) التي ستستخدم لملء الإطار.
8. قم بتعيين صورة مخصصة لإطار زوم القسم الذي تم إنشاؤه.
9. قم بتعيين القدرة على *العودة إلى الشريحة الأصلية من القسم المرتبط*. 
10. أزل الخلفية من صورة إطار زوم القسم.
11. غيّر تنسيق الخط لكائن الزوم الثاني.
12. غيّر مدة الانتقال.
13. اكتب العرض التقديمي المعدل كملف PPTX.

يوضح لك كود جافا هذا كيفية تغيير تنسيق إطار زوم القسم:

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

## **ملخص الزوم**

ملخص الزوم يشبه صفحة الهبوط حيث تظهر جميع أجزاء عرضك التقديمي دفعة واحدة. عند تقديمك، يمكنك استخدام الزوم للانتقال من مكان في عرضك إلى آخر بأي ترتيب تريده. يمكنك أن تكون مبدعًا، تخطي، أو إعادة زيارة أجزاء من عرض الشرائح الخاص بك دون مقاطعة تدفق عرضك.

![overview_image](sumzoomsel.png)

لأجزاء ملخص الزوم، توفر Aspose.Slides الواجهات [ISummaryZoomFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISummaryZoomFrame)، [ISummaryZoomSection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISummaryZoomSection)، و [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISummaryZoomSectionCollection) وبعض الطرق ضمن الواجهة [IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection).

### **إنشاء ملخص الزوم**

يمكنك إضافة إطار ملخص الزوم إلى شريحة بهذه الطريقة:

1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. أنشئ شرائح جديدة مع خلفية تعريفية وأقسام جديدة للشرائح التي تم إنشاؤها.
3. أضف إطار ملخص الزوم إلى الشريحة الأولى.
4. اكتب العرض التقديمي المعدل كملف PPTX.

يوضح لك كود جافا هذا كيفية إنشاء إطار ملخص الزوم على شريحة:

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

### **إضافة وإزالة قسم ملخص الزوم**

تمثل جميع الأقسام في إطار ملخص الزوم كائنات [ISummaryZoomSection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISummaryZoomSection)، والتي يتم تخزينها في كائن [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISummaryZoomSectionCollection). يمكنك إضافة أو إزالة كائن قسم ملخص الزوم من خلال واجهة [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISummaryZoomSectionCollection) بهذه الطريقة:

1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. أنشئ شرائح جديدة مع خلفية تعريفية وأقسام جديدة للشرائح التي تم إنشاؤها.
3. أضف إطار ملخص الزوم إلى الشريحة الأولى.
4. أضف شريحة جديدة وقسمًا إلى العرض التقديمي.
5. أضف القسم الذي تم إنشاؤه إلى إطار الزوم الملخص.
6. أزل القسم الأول من إطار الزوم الملخص.
7. اكتب العرض التقديمي المعدل كملف PPTX.

يوضح لك كود جافا هذا كيفية إضافة وإزالة الأقسام في إطار ملخص الزوم:

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

### **تنسيق أقسام ملخص الزوم**

لإنشاء كائنات أقسام ملخص الزوم الأكثر تعقيدًا، يجب عليك تغيير تنسيق إطار بسيط. هناك العديد من خيارات التنسيق التي يمكنك تطبيقها على كائن قسم ملخص الزوم. 

يمكنك التحكم في التنسيق لكائن قسم ملخص الزوم في إطار ملخص الزوم بهذه الطريقة:

1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. أنشئ شرائح جديدة مع خلفية تعريفية وأقسام جديدة للشرائح التي تم إنشاؤها.
3. أضف إطار ملخص الزوم إلى الشريحة الأولى.
4. احصل على كائن قسم ملخص الزوم الأول من `ISummaryZoomSectionCollection`.
5. أنشئ كائن [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPPImage) عن طريق إضافة صورة إلى مجموعة الصور المرتبطة بكائن [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) التي ستستخدم لملء الإطار.
6. قم بتعيين صورة مخصصة لكائن إطار القسم الزوم الذي تم إنشاؤه.
7. قم بتعيين الخاصية *العودة إلى الشريحة الأصلية من القسم المرتبط*. 
8. غيّر تنسيق الخط لكائن الزوم الثاني.
9. غيّر مدة الانتقال.
10. اكتب العرض التقديمي المعدل كملف PPTX.

يوضح لك كود جافا هذا كيفية تغيير التنسيق لكائن قسم ملخص الزوم:

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