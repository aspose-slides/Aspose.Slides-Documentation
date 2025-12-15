---
title: إضافة مستطيلات إلى العروض التقديمية على Android
linktitle: مستطيل
type: docs
weight: 80
url: /ar/androidjava/rectangle/
keywords:
- إضافة مستطيل
- إنشاء مستطيل
- شكل مستطيل
- مستطيل بسيط
- مستطيل منسق
- PowerPoint
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "قم بتحسين عروض PowerPoint التقديمية عن طريق إضافة مستطيلات باستخدام Aspose.Slides لنظام Android عبر Java—صمم وعدّل الأشكال برمجيًا بسهولة."
---

{{% alert color="primary" %}} 

مثل المواضيع السابقة، يتناول هذا الموضوع أيضاً إضافة شكل، وهذه المرة سيكون الشكل الذي سنناقشه هو **Rectangle**. في هذا الموضوع، وصفنا كيف يمكن للمطورين إضافة مستطيلات بسيطة أو مُنسقة إلى الشرائح باستخدام Aspose.Slides لنظام Android عبر Java.

{{% /alert %}} 

## **إضافة مستطيل إلى شريحة**
لإضافة مستطيل بسيط إلى شريحة مختارة من العرض التقديمي، يرجى اتباع الخطوات أدناه:

- إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation)
- الحصول على مرجع شريحة باستخدام فهرسها.
- إضافة [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape) من النوع Rectangle باستخدام طريقة [addAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) المعروضة بواسطة كائن [IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection).
- حفظ العرض التقديمي المعدل كملف PPTX.

في المثال المذكور أدناه، قمنا بإضافة مستطيل بسيط إلى الشريحة الأولى من العرض التقديمي.
```java
// إنشاء كائن من الفئة Presentation التي تمثل ملف PPTX
Presentation pres = new Presentation();
try {
    // الحصول على الشريحة الأولى
    ISlide sld = pres.getSlides().get_Item(0);

    // إضافة AutoShape من نوع إهليلجي
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 50);

    // كتابة ملف PPTX إلى القرص
    pres.save("RecShp1.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **إضافة مستطيل مُنسق إلى شريحة**
لإضافة مستطيل مُنسق إلى شريحة، يرجى اتباع الخطوات أدناه:

- إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation)
- الحصول على مرجع شريحة باستخدام فهرسها.
- إضافة [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape) من النوع Rectangle باستخدام طريقة [addAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) المعروضة بواسطة كائن [IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection).
- تعيين [Fill Type](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FillType) للمستطيل إلى Solid.
- تعيين لون المستطيل باستخدام طريقة [SolidFillColor.setColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IColorFormat#setColor-java.awt.Color-) المعروضة بواسطة كائن [IFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IFillFormat) المرتبط بكائن [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape).
- تعيين لون خطوط المستطيل.
- تعيين عرض خطوط المستطيل.
- حفظ العرض التقديمي المعدل كملف PPTX.

تم تنفيذ الخطوات السابقة في المثال المذكور أدناه.
```java
// إنشاء كائن من فئة Presentation التي تمثل ملف PPTX
Presentation pres = new Presentation();
try {
    // الحصول على الشريحة الأولى
    ISlide sld = pres.getSlides().get_Item(0);

    // إضافة AutoShape من نوع إهليلجي
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 50);

    // تطبيق بعض التنسيق على شكل الإهليلج
    shp.getFillFormat().setFillType(FillType.Solid);
    shp.getFillFormat().getSolidFillColor().setColor(Color.GRAY);

    // تطبيق بعض التنسيق على خط الإهليلج
    shp.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shp.getLineFormat().setWidth(5);

    // كتابة ملف PPTX إلى القرص
    pres.save("RecShp2.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **الأسئلة الشائعة**

**كيف يمكنني إضافة مستطيل بزوايا مستديرة؟**

استخدم نوع الشكل ذو الزوايا المستديرة [نوع الشكل](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shapetype/) واضبط نصف قطر الزاوية في خصائص الشكل؛ يمكن أيضاً تطبيق التقوس على كل زاوية على حدة عبر تعديلات الهندسة.

**كيف أملأ مستطيلاً بصورة (نقش)؟**

اختر نوع تعبئة الصورة [نوع التعبئة](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/)، قدم مصدر الصورة، واضبط أوضاع [أوضاع التمدد/التبليط](https://reference.aspose.com/slides/androidjava/com.aspose.slides/picturefillmode/).

**هل يمكن للمستطيل أن يحتوي على ظل وتوهج؟**

نعم. [الظل الخارجي/الداخلي، التوهج، والحواف الناعمة](/slides/ar/androidjava/shape-effect/) متاحة مع معلمات قابلة للتعديل.

**هل يمكنني تحويل المستطيل إلى زر مع ارتباط تشعبي؟**

نعم. [تعيين ارتباط تشعبي](/slides/ar/androidjava/manage-hyperlinks/) للنقر على الشكل (للانتقال إلى شريحة، ملف، عنوان ويب، أو بريد إلكتروني).

**كيف يمكنني حماية المستطيل من التحريك والتغييرات؟**

[استخدام أقفال الشكل](/slides/ar/androidjava/applying-protection-to-presentation/): يمكنك منع التحريك، تغيير الحجم، الاختيار، أو تعديل النص للحفاظ على التخطيط.

**هل يمكنني تحويل المستطيل إلى صورة نقطية أو SVG؟**

نعم. يمكنك [تصيير الشكل](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getImage-int-float-float-) إلى صورة بحجم/مقياس محدد أو [تصديره كـ SVG](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) للاستخدام المتجه.

**كيف أحصل بسرعة على الخصائص الفعلية (الفعّالة) للمستطيل مع مراعاة السمة والوراثة؟**

[استخدام الخصائص الفعّالة للشكل](/slides/ar/androidjava/shape-effective-properties/): تُعيد الواجهة البرمجية قيماً محسوبة تأخذ في الاعتبار أنماط السمة، التخطيط، والإعدادات المحلية، مما يبسط تحليل التنسيق.