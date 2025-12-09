---
title: إدارة التكبير
type: docs
weight: 60
url: /ar/nodejs-java/manage-zoom/
keywords: "التكبير, إطار التكبير, إضافة تكبير, تنسيق إطار التكبير, تكبير ملخص, عرض PowerPoint, Java, Aspose.Slides لـ Node.js عبر Java"
description: "إضافة تكبير أو إطارات تكبير إلى عروض PowerPoint في JavaScript"
---

## **نظرة عامة**

تسمح خاصية التكبير في PowerPoint بالانتقال إلى شرائح أو أقسام أو أجزاء محددة من العرض ثم العودة منها. عند تقديم العرض قد يكون القدرة على التنقل السريع بين المحتوى مفيدة جداً.

![صورة النظرة العامة](overview.png)

* لتلخيص عرض كامل على شريحة واحدة، استخدم [ملخص التكبير](#Summary-Zoom).
* لعرض شرائح مختارة فقط، استخدم [تكبير الشريحة](#Slide-Zoom).
* لعرض قسم واحد فقط، استخدم [تكبير القسم](#Section-Zoom).

## **تكبير الشريحة**

يمكن لتكبير الشريحة أن يجعل عرضك أكثر ح dinamية، حيث يتيح لك التنقل بحرية بين الشرائح بأي ترتيب تختاره دون إيقاف تدفق العرض. تكبيرات الشرائح مفيدة للعروض القصيرة التي لا تحتوي على عدة أقسام، لكن يمكنك استخدامها أيضاً في سيناريوهات عرض مختلفة.

تساعدك تكبيرات الشرائح على الغوص في معلومات متعددة بينما تشعر أنك تعمل على لوحة واحدة.

![صورة النظرة العامة](slidezoomsel.png)

بالنسبة لكائنات تكبير الشريحة، توفر Aspose.Slides تعداد [ZoomImageType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ZoomImageType) وفئة [ZoomFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ZoomFrame) وبعض الأساليب تحت فئة [ShapeCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection).

### **إنشاء إطارات التكبير**

يمكنك إضافة إطار تكبير إلى شريحة بهذه الطريقة:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. إنشاء شرائح جديدة تريد ربط إطارات التكبير بها.
3. إضافة نص تعريف وخلفية إلى الشرائح التي تم إنشاؤها.
4. إضافة إطارات تكبير (تحتوي على مراجع للشرائح التي تم إنشاؤها) إلى الشريحة الأولى.
5. كتابة العرض المعدل كملف PPTX.

هذا الكود JavaScript يوضح كيفية إنشاء إطار تكبير على شريحة:
```javascript
var pres = new aspose.slides.Presentation();
try {
    // يضيف شرائح جديدة إلى العرض
    var slide2 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    var slide3 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    // ينشئ خلفية للشرحة الثانية
    slide2.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    slide2.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide2.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "cyan"));
    // ينشئ مربع نص للشرحة الثانية
    var autoshape = slide2.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Second Slide");
    // ينشئ خلفية للشرحة الثالثة
    slide3.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    slide3.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide3.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "darkGray"));
    // ينشئ مربع نص للشرحة الثالثة
    autoshape = slide3.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Trird Slide");
    // يضيف كائنات ZoomFrame
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 250, 200, slide2);
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(200, 250, 250, 200, slide3);
    // يحفظ العرض
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


### **إنشاء إطارات التكبير بصور مخصصة**

مع Aspose.Slides لـ Node.js عبر Java، يمكنك إنشاء إطار تكبير بصورة معاينة شريحة مختلفة بهذه الطريقة:
1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. إنشاء شريحة جديدة تريد ربط إطار التكبير بها.
3. إضافة نص تعريف وخلفية إلى الشريحة.
4. إنشاء كائن [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PPImage) بإضافة صورة إلى مجموعة Images المرتبطة بكائن [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) الذي سيُملأ الإطار به.
5. إضافة إطارات تكبير (تحتوي على مرجع إلى الشريحة التي تم إنشاؤها) إلى الشريحة الأولى.
6. كتابة العرض المعدل كملف PPTX.

هذا الكود JavaScript يوضح كيفية إنشاء إطار تكبير بصورة مختلفة:
```javascript
var pres = new aspose.slides.Presentation();
try {
    // يضيف شريحة جديدة إلى العرض
    var slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    // ينشئ خلفية للشرحة الثانية
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "cyan"));
    // ينشئ مربع نص للشرحة الثالثة
    var autoshape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Second Slide");
    // ينشئ صورة جديدة لكائن التكبير
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // يضيف كائن ZoomFrame
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 300, 200, slide, picture);
    // يحفظ العرض
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


### **تنسيق إطارات التكبير**

في الأقسام السابقة، أظهرنا لك كيفية إنشاء إطارات تكبير بسيطة. لإنشاء إطارات تكبير أكثر تعقيداً، عليك تعديل تنسيق إطار بسيط. هناك عدة خيارات تنسيق يمكنك تطبيقها على إطار التكبير.

يمكنك التحكم في تنسيق إطار التكبير على شريحة بهذه الطريقة:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. إنشاء شرائح جديدة تريد ربط إطار التكبير بها.
3. إضافة نص تعريف وخلفية إلى الشرائح التي تم إنشاؤها.
4. إضافة إطارات تكبير (تحتوي على مراجع للشرائح التي تم إنشاؤها) إلى الشريحة الأولى.
5. إنشاء كائن [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PPImage) بإضافة صورة إلى مجموعة Images المرتبطة بكائن [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) الذي سيُملأ الإطار به.
6. تعيين صورة مخصصة للإطار التكبير الأول.
7. تغيير تنسيق الخط للإطار التكبير الثاني.
8. إزالة الخلفية من صورة الإطار التكبير الثاني.
9. كتابة العرض المعدل كملف PPTX.

هذا الكود JavaScript يوضح كيفية تغيير تنسيق إطار التكبير على شريحة:
```javascript
var pres = new aspose.slides.Presentation();
try {
    // يضيف شرائح جديدة إلى العرض
    var slide2 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    var slide3 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    // ينشئ خلفية للشريحة الثانية
    slide2.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    slide2.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide2.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "cyan"));
    // ينشئ مربع نص للشريحة الثانية
    var autoshape = slide2.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Second Slide");
    // ينشئ خلفية للشريحة الثالثة
    slide3.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    slide3.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide3.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "darkGray"));
    // ينشئ مربع نص للشريحة الثالثة
    autoshape = slide3.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Trird Slide");
    // يضيف كائنات ZoomFrame
    var zoomFrame1 = pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 250, 200, slide2);
    var zoomFrame2 = pres.getSlides().get_Item(0).getShapes().addZoomFrame(200, 250, 250, 200, slide3);
    // ينشئ صورة جديدة لكائن التكبير
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // يحدد صورة مخصصة لكائن zoomFrame1
    zoomFrame1.setImage(picture);
    // يحدد تنسيق إطار التكبير لكائن zoomFrame2
    zoomFrame2.getLineFormat().setWidth(5);
    zoomFrame2.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    zoomFrame2.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "pink"));
    zoomFrame2.getLineFormat().setDashStyle(aspose.slides.LineDashStyle.DashDot);
    // إعداد لعدم إظهار الخلفية لكائن zoomFrame2
    zoomFrame2.setShowBackground(false);
    // يحفظ العرض
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **تكبير القسم**

تكبير القسم هو رابط إلى قسم في عرضك. يمكنك استخدام تكبيرات الأقسام للعودة إلى أقسام تريد التأكيد عليها بشدة، أو لتسليط الضوء على كيفية ارتباط أجزاء معينة من العرض.

![صورة النظرة العامة](seczoomsel.png)

بالنسبة لكائنات تكبير القسم، توفر Aspose.Slides فئة [SectionZoomFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SectionZoomFrame) وبعض الأساليب تحت فئة [ShapeCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection).

### **إنشاء إطارات تكبير القسم**

يمكنك إضافة إطار تكبير قسم إلى شريحة بهذه الطريقة:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. إنشاء شريحة جديدة.
3. إضافة خلفية تعريف إلى الشريحة التي تم إنشاؤها.
4. إنشاء قسم جديد تريد ربط إطار التكبير به.
5. إضافة إطار تكبير قسم (يحتوي على مراجع إلى القسم الذي تم إنشاؤه) إلى الشريحة الأولى.
6. كتابة العرض المعدل كملف PPTX.

هذا الكود JavaScript يوضح كيفية إنشاء إطار تكبير على شريحة:
```javascript
var pres = new aspose.slides.Presentation();
try {
    // يضيف شريحة جديدة إلى العرض
    var slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "yellow"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // يضيف قسمًا جديدًا إلى العرض
    pres.getSections().addSection("Section 1", slide);
    // يضيف كائن SectionZoomFrame
    var sectionZoomFrame = pres.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, pres.getSections().get_Item(1));
    // يحفظ العرض
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


### **إنشاء إطارات تكبير القسم بصور مخصصة**

باستخدام Aspose.Slides لـ Node.js عبر Java، يمكنك إنشاء إطار تكبير قسم بصورة معاينة شريحة مختلفة بهذه الطريقة:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. إنشاء شريحة جديدة.
3. إضافة خلفية تعريف إلى الشريحة التي تم إنشاؤها.
4. إنشاء قسم جديد تريد ربط إطار التكبير به.
5. إنشاء كائن [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PPImage) بإضافة صورة إلى مجموعة Images المرتبطة بكائن [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) الذي سيُملأ الإطار به.
6. إضافة إطار تكبير قسم (يحتوي على مرجع إلى القسم الذي تم إنشاؤه) إلى الشريحة الأولى.
7. كتابة العرض المعدل كملف PPTX.

هذا الكود JavaScript يوضح كيفية إنشاء إطار تكبير بصورة مختلفة:
```javascript
var pres = new aspose.slides.Presentation();
try {
    // يضيف شريحة جديدة إلى العرض
    var slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "yellow"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // يضيف قسمًا جديدًا إلى العرض
    pres.getSections().addSection("Section 1", slide);
    // ينشئ صورة جديدة لكائن التكبير
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // يضيف كائن SectionZoomFrame
    var sectionZoomFrame = pres.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, pres.getSections().get_Item(1), picture);
    // يحفظ العرض
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


### **تنسيق إطارات تكبير القسم**

لإنشاء إطارات تكبير قسم أكثر تعقيداً، عليك تعديل تنسيق إطار بسيط. هناك عدة خيارات تنسيق يمكنك تطبيقها على إطار تكبير القسم.

يمكنك التحكم في تنسيق إطار تكبير القسم على شريحة بهذه الطريقة:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. إنشاء شريحة جديدة.
3. إضافة خلفية تعريف إلى الشريحة التي تم إنشاؤها.
4. إنشاء قسم جديد تريد ربط إطار التكبير به.
5. إضافة إطار تكبير قسم (يحتوي على مراجع إلى القسم الذي تم إنشاؤه) إلى الشريحة الأولى.
6. تغيير الحجم والموضع للكائن تكبير القسم الذي تم إنشاؤه.
7. إنشاء كائن [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PPImage) بإضافة صورة إلى مجموعة Images المرتبطة بكائن [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) الذي سيُملأ الإطار به.
8. تعيين صورة مخصصة لكائن إطار تكبير القسم الذي تم إنشاؤه.
9. تمكين *العودة إلى الشريحة الأصلية من القسم المرتبط*.
10. إزالة الخلفية من صورة إطار تكبير القسم.
11. تغيير تنسيق الخط لكائن تكبير القسم الثاني.
12. تغيير مدة الانتقال.
13. كتابة العرض المعدل كملف PPTX.

هذا الكود JavaScript يوضح كيفية تغيير تنسيق إطار تكبير القسم:
```javascript
var pres = new aspose.slides.Presentation();
try {
    // يضيف شريحة جديدة إلى العرض
    var slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "yellow"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // يضيف قسمًا جديدًا إلى العرض
    pres.getSections().addSection("Section 1", slide);
    // يضيف كائن SectionZoomFrame
    var sectionZoomFrame = pres.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, pres.getSections().get_Item(1));
    // تنسيق لكائن SectionZoomFrame
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
    // يحفظ العرض
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **ملخص التكبير**

ملخص التكبير يشبه صفحة هبوط تُظهر جميع أجزاء العرض مرة واحدة. عند تقديمك، يمكنك استخدام التكبير للانتقال من مكان إلى آخر في العرض بأي ترتيب تفضله. يمكنك الإبداع، تخطي أجزاء، أو العودة إلى شرائح سابقة دون إيقاف تدفق العرض.

![صورة النظرة العامة](sumzoomsel.png)

بالنسبة لكائنات ملخص التكبير، توفر Aspose.Slides الفئات [SummaryZoomFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SummaryZoomFrame)، [SummaryZoomSection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SummaryZoomSection) و[SummaryZoomSectionCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SummaryZoomSectionCollection) وبعض الأساليب تحت فئة [ShapeCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection).

### **إنشاء ملخص التكبير**

يمكنك إضافة إطار ملخص تكبير إلى شريحة بهذه الطريقة:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. إنشاء شرائح جديدة مع خلفية تعريف وأقسام جديدة للشرائح التي تم إنشاؤها.
3. إضافة إطار ملخص التكبير إلى الشريحة الأولى.
4. كتابة العرض المعدل كملف PPTX.

هذا الكود JavaScript يوضح كيفية إنشاء إطار ملخص تكبير على شريحة:
```javascript
var pres = new aspose.slides.Presentation();
try {
    // يضيف شريحة جديدة إلى العرض
    var slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "gray"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // يضيف قسمًا جديدًا إلى العرض
    pres.getSections().addSection("Section 1", slide);
    // يضيف شريحة جديدة إلى العرض
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "cyan"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // يضيف قسمًا جديدًا إلى العرض
    pres.getSections().addSection("Section 2", slide);
    // يضيف شريحة جديدة إلى العرض
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "magenta"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // يضيف قسمًا جديدًا إلى العرض
    pres.getSections().addSection("Section 3", slide);
    // يضيف شريحة جديدة إلى العرض
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "green"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // يضيف قسمًا جديدًا إلى العرض
    pres.getSections().addSection("Section 4", slide);
    // يضيف كائن SummaryZoomFrame
    var summaryZoomFrame = pres.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200);
    // يحفظ العرض
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


### **إضافة وإزالة قسم ملخص التكبير**

جميع الأقسام في إطار ملخص التكبير ممثلة بكائنات [SummaryZoomSection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SummaryZoomSection)، المخزنة في كائن [SummaryZoomSectionCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SummaryZoomSectionCollection). يمكنك إضافة أو إزالة كائن قسم ملخص التكبير عبر فئة [SummaryZoomSectionCollection] بهذه الطريقة:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. إنشاء شرائح جديدة مع خلفية تعريف وأقسام جديدة للشرائح التي تم إنشاؤها.
3. إضافة إطار ملخص التكبير إلى الشريحة الأولى.
4. إضافة شريحة جديدة وقسم إلى العرض.
5. إضافة القسم الذي تم إنشاؤه إلى إطار ملخص التكبير.
6. إزالة القسم الأول من إطار ملخص التكبير.
7. كتابة العرض المعدل كملف PPTX.

هذا الكود JavaScript يوضح كيفية إضافة وإزالة أقسام في إطار ملخص التكبير:
```javascript
var pres = new aspose.slides.Presentation();
try {
    // يضيف شريحة جديدة إلى العرض
    var slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "gray"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // يضيف قسمًا جديدًا إلى العرض
    pres.getSections().addSection("Section 1", slide);
    // يضيف شريحة جديدة إلى العرض
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "cyan"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // يضيف قسمًا جديدًا إلى العرض
    pres.getSections().addSection("Section 2", slide);
    // يضيف كائن SummaryZoomFrame
    var summaryZoomFrame = pres.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200);
    // يضيف شريحة جديدة إلى العرض
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "magenta"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // يضيف قسمًا جديدًا إلى العرض
    var section3 = pres.getSections().addSection("Section 3", slide);
    // يضيف قسمًا إلى ملخص التكبير
    summaryZoomFrame.getSummaryZoomCollection().addSummaryZoomSection(section3);
    // يزيل قسمًا من ملخص التكبير
    summaryZoomFrame.getSummaryZoomCollection().removeSummaryZoomSection(pres.getSections().get_Item(1));
    // يحفظ العرض
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


### **تنسيق أقسام ملخص التكبير**

لإنشاء كائنات أقسام ملخص التكبير أكثر تعقيداً، عليك تعديل تنسيق إطار بسيط. هناك عدة خيارات تنسيق يمكنك تطبيقها على كائن قسم ملخص التكبير.

يمكنك التحكم في تنسيق كائن قسم ملخص التكبير داخل إطار ملخص التكبير بهذه الطريقة:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. إنشاء شرائح جديدة مع خلفية تعريف وأقسام جديدة للشرائح التي تم إنشاؤها.
3. إضافة إطار ملخص التكبير إلى الشريحة الأولى.
4. الحصول على كائن قسم ملخص التكبير لأول كائن من `ISummaryZoomSectionCollection`.
5. إنشاء كائن [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PPImage) بإضافة صورة إلى مجموعة images المرتبطة بكائن [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) الذي سيُملأ الإطار به.
6. تعيين صورة مخصصة لكائن إطار تكبير القسم الذي تم إنشاؤه.
7. تمكين *العودة إلى الشريحة الأصلية من القسم المرتبط*.
8. تغيير تنسيق الخط لكائن تكبير القسم الثاني.
9. تغيير مدة الانتقال.
10. كتابة العرض المعدل كملف PPTX.

هذا الكود JavaScript يوضح كيفية تغيير تنسيق كائن قسم ملخص التكبير:
```javascript
var pres = new aspose.slides.Presentation();
try {
    // يضيف شريحة جديدة إلى العرض
    var slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "gray"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // يضيف قسمًا جديدًا إلى العرض
    pres.getSections().addSection("Section 1", slide);
    // يضيف شريحة جديدة إلى العرض
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "cyan"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // يضيف قسمًا جديدًا إلى العرض
    pres.getSections().addSection("Section 2", slide);
    // يضيف كائن SummaryZoomFrame
    var summaryZoomFrame = pres.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200);
    // يحصل على أول كائن SummaryZoomSection
    var summarySection = summaryZoomFrame.getSummaryZoomCollection().get_Item(0);
    // تنسيق كائن SummaryZoomSection
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
    // يحفظ العرض
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **الأسئلة المتكررة**

**هل يمكنني التحكم في العودة إلى الشريحة "الأصلية" بعد عرض الهدف؟**

نعم. يحتوي [Zoom frame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/zoomframe/) أو [section](https://reference.aspose.com/slides/nodejs-java/aspose.slides/sectionzoomframe/) على طريقة `setReturnToParent` التي عند تفعيلها تُعيد المشاهد إلى الشريحة الأصلية بعد زيارة المحتوى المستهدف.

**هل يمكنني تعديل "سرعة" أو مدة انتقال التكبير؟**

نعم. يوفّر التكبير طريقة `setTransitionDuration` لتتمكن من التحكم في مدة حركة القفزة.

**هل هناك حدود لعدد كائنات التكبير التي يمكن أن يحتويها العرض؟**

لا توجد حدود صريحة موثقة في API. تعتمد الحدود العملية على تعقيد العرض الكلي وأداء المشاهد. يمكنك إضافة عدد كبير من إطارات التكبير، لكن يجب مراعاة حجم الملف ووقت التقديم.