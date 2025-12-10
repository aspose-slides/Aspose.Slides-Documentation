---
title: إضافة مستطيلات إلى العروض التقديمية في Java
linktitle: مستطيل
type: docs
weight: 80
url: /ar/java/rectangle/
keywords:
- إضافة مستطيل
- إنشاء مستطيل
- شكل مستطيل
- مستطيل بسيط
- مستطيل منسق
- PowerPoint
- عرض تقديمي
- Java
- Aspose.Slides
description: "قم بتحسين عروض PowerPoint التقديمية بإضافة مستطيلات باستخدام Aspose.Slides for Java—صمم وعدّل الأشكال برمجياً بسهولة."
---

{{% alert color="primary" %}} 

مثل المواضيع السابقة، هذا الموضوع يتحدث أيضًا عن إضافة شكل وهذه المرة الشكل الذي سنناقشه هو **مستطيل**. في هذا الموضوع، وصفنا كيفية إضافة مستطيلات بسيطة أو منسقة إلى شرائحهم باستخدام Aspose.Slides for Java.

{{% /alert %}} 

## **إضافة مستطيل إلى شريحة**
لإضافة مستطيل بسيط إلى شريحة مختارة من العرض التقديمي، يرجى اتباع الخطوات أدناه:

- إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation).
- الحصول على مرجع الشريحة باستخدام الفهرس الخاص بها.
- إضافة [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape) من نوع مستطيل باستخدام طريقة [addAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) التي يوفرها كائن [IShapeCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection).
- حفظ العرض التقديمي المعدل كملف PPTX.

في المثال المعروض أدناه، قمنا بإضافة مستطيل بسيط إلى الشريحة الأولى من العرض التقديمي.
```java
// إنشاء كائن من فئة Presentation التي تمثل ملف PPTX
Presentation pres = new Presentation();
try {
    // الحصول على الشريحة الأولى
    ISlide sld = pres.getSlides().get_Item(0);

    // إضافة AutoShape من نوع إهليلج
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 50);

    // حفظ ملف PPTX على القرص
    pres.save("RecShp1.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **إضافة مستطيل منسق إلى شريحة**
لإضافة مستطيل منسق إلى شريحة، يرجى اتباع الخطوات أدناه:

- إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation).
- الحصول على مرجع الشريحة باستخدام الفهرس الخاص بها.
- إضافة [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape) من نوع مستطيل باستخدام طريقة [addAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) التي يوفرها كائن [IShapeCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection).
- تعيين [Fill Type](https://reference.aspose.com/slides/java/com.aspose.slides/FillType) للمستطيل إلى Solid.
- تعيين لون المستطيل باستخدام طريقة [SolidFillColor.setColor](https://reference.aspose.com/slides/java/com.aspose.slides/IColorFormat#setColor-java.awt.Color-) التي يوفرها كائن [IFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/IFillFormat) المرتبط بكائن [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/IShape).
- تعيين لون خطوط المستطيل.
- تعيين عرض خطوط المستطيل.
- حفظ العرض التقديمي المعدل كملف PPTX.

تم تنفيذ الخطوات أعلاه في المثال المعروض أدناه.
```java
// إنشاء كائن من فئة Presentation التي تمثل ملف PPTX
Presentation pres = new Presentation();
try {
    // الحصول على الشريحة الأولى
    ISlide sld = pres.getSlides().get_Item(0);

    // إضافة AutoShape من نوع إهليلج
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 50);

    // تطبيق بعض التنسيق على شكل الإهليلج
    shp.getFillFormat().setFillType(FillType.Solid);
    shp.getFillFormat().getSolidFillColor().setColor(Color.GRAY);

    // تطبيق بعض التنسيق على خط الإهليلج
    shp.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shp.getLineFormat().setWidth(5);

    // حفظ ملف PPTX على القرص
    pres.save("RecShp2.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **الأسئلة الشائعة**

**كيف يمكنني إضافة مستطيل بزوايا مستديرة؟**

استخدم نوع الشكل [shape type](https://reference.aspose.com/slides/java/com.aspose.slides/shapetype/) ذو الزوايا المستديرة وضبط نصف قطر الزاوية في خصائص الشكل؛ يمكن أيضًا تطبيق التقويس على كل زاوية على حدة عبر تعديل الهندسة.

**كيف أملأ مستطيل بصورة (نقش)؟**

اختر [fill type](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) للصور، قدم مصدر الصورة، وقم بتكوين أوضاع [stretching/tiling](https://reference.aspose.com/slides/java/com.aspose.slides/picturefillmode/).

**هل يمكن للمستطيل أن يحتوي على ظل أو توهج؟**

نعم. الظلال الخارجية/الداخلية، التوهج، والحواف الناعمة متاحة مع معلمات قابلة للتعديل [/slides/java/shape-effect/].

**هل يمكن تحويل المستطيل إلى زر مع ارتباط تشعبي؟**

نعم. يمكن [Assign a hyperlink](/slides/ar/java/manage-hyperlinks/) إلى النقر على الشكل (الانتقال إلى شريحة، ملف، عنوان ويب، أو بريد إلكتروني).

**كيف يمكنني حماية المستطيل من التحريك أو التعديل؟**

استخدم [shape locks](/slides/ar/java/applying-protection-to-presentation/): يمكنك منع التحريك، تغيير الحجم، الاختيار، أو تحرير النص للحفاظ على التخطيط.

**هل يمكن تحويل المستطيل إلى صورة نقطية أو SVG؟**

نعم. يمكنك [render the shape](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getImage-int-float-float-) إلى صورة بحجم/مقياس محدد أو [export it as SVG](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) للاستخدام كمتجه.

**كيف أحصل بسرعة على الخصائص الفعلية (effective) للمستطيل مع مراعاة السمات والوراثة؟**

استخدم [shape’s effective properties](/slides/ar/java/shape-effective-properties/): تُعيد واجهة البرمجة القيم المحسوبة التي تأخذ في الاعتبار أنماط السمات، التخطيط، والإعدادات المحلية، مما يبسط تحليل التنسيق.