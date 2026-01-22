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
description: "عزز عروض PowerPoint التقديمية بإضافة مستطيلات باستخدام Aspose.Slides لـ Android عبر Java—صمم وعدّل الأشكال برمجيًا بسهولة."
---

{{% alert color="primary" %}} 

مثل المواضيع السابقة، يتناول هذا أيضًا إضافة شكل، وهذه المرة الشكل الذي سنناقشه هو **مستطيل**. في هذا الموضوع، وصفنا كيف يمكن للمطورين إضافة مستطيلات بسيطة أو مُنسقة إلى شرائحهم باستخدام Aspose.Slides لـ Android عبر Java.

{{% /alert %}} 

## **إضافة مستطيل إلى شريحة**
لإضافة مستطيل بسيط إلى شريحة مختارة من العرض التقديمي، يرجى اتباع الخطوات التالية:

- إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) .
- احصل على مرجع الشريحة باستخدام فهرستها.
- أضف [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape) من نوع مستطيل باستخدام طريقة [addAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) المعروضة من كائن [IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection) .
- احفظ العرض التقديمي المعدل كملف PPTX.

في المثال المعروض أدناه، قمنا بإضافة مستطيل بسيط إلى الشريحة الأولى من العرض التقديمي.
```java
// إنشاء كائن من فئة Presentation الذي يمثل ملف PPTX
Presentation pres = new Presentation();
try {
    // الحصول على الشريحة الأولى
    ISlide sld = pres.getSlides().get_Item(0);

    // إضافة AutoShape من نوع إهليلجي
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 50);

    // حفظ ملف PPTX إلى القرص
    pres.save("RecShp1.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **إضافة مستطيل منسق إلى شريحة**
لإضافة مستطيل منسق إلى شريحة، يرجى اتباع الخطوات التالية:

- إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) .
- احصل على مرجع الشريحة باستخدام فهرستها.
- أضف [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape) من نوع مستطيل باستخدام طريقة [addAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) المعروضة من كائن [IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection) .
- عيّن [Fill Type](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FillType) للمستطيل إلى Solid.
- عيّن لون المستطيل باستخدام طريقة [SolidFillColor.setColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IColorFormat#setColor-java.awt.Color-) كما هي معروضة في كائن [IFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IFillFormat) المرتبط بكائن [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape) .
- عيّن لون خطوط المستطيل.
- عيّن عرض خطوط المستطيل.
- احفظ العرض التقديمي المعدل كملف PPTX.

تم تنفيذ الخطوات السابقة في المثال المعروض أدناه.
```java
// إنشاء كائن من فئة Presentation التي تمثل ملف PPTX
Presentation pres = new Presentation();
try {
    // الحصول على الشريحة الأولى
    ISlide sld = pres.getSlides().get_Item(0);

    // إضافة AutoShape من نوع إهليلجي
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 50);

    // تطبيق بعض التنسيقات على شكل الإهليلج
    shp.getFillFormat().setFillType(FillType.Solid);
    shp.getFillFormat().getSolidFillColor().setColor(Color.GRAY);

    // تطبيق بعض التنسيقات على خط الإهليلج
    shp.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shp.getLineFormat().setWidth(5);

    // حفظ ملف PPTX إلى القرص
    pres.save("RecShp2.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **الأسئلة المتكررة**

**كيف يمكنني إضافة مستطيل بزوايا مدورة؟**

استخدم نوع الشكل ذو الزوايا المدورة [shape type](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shapetype/) واضبط نصف قطر الزاوية في خصائص الشكل؛ يمكن أيضًا تطبيق التدوير على كل زاوية على حدة عبر تعديل الهندسة.

**كيف أملأ مستطيلًا بصورة (نقش)؟**

اختر نوع التعبئة للصور [fill type](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/), قدّم مصدر الصورة، وقم بتكوين أوضاع [التمدد/التكرار](https://reference.aspose.com/slides/androidjava/com.aspose.slides/picturefillmode/).

**هل يمكن للمستطيل أن يحتوي على ظل وتوهج؟**

نعم. [الظل الخارجي/الداخلي، التوهج، والحواف الناعمة](/slides/ar/androidjava/shape-effect/) متاحة مع معلمات قابلة للتعديل.

**هل يمكنني تحويل المستطيل إلى زر مع ارتباط تشعبي؟**

نعم. [إسناد ارتباط تشعبي](/slides/ar/androidjava/manage-hyperlinks/) إلى نقر الشكل (القفز إلى شريحة أو ملف أو عنوان ويب أو بريد إلكتروني).

**كيف يمكنني حماية المستطيل من التحريك والتغييرات؟**

استخدم أقفال الأشكال: يمكنك منع التحريك، تغيير الحجم، التحديد، أو تحرير النص للحفاظ على التخطيط.

**هل يمكنني تحويل المستطيل إلى صورة نقطية أو SVG؟**

نعم. يمكنك [تصيير الشكل](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getImage-int-float-float-) إلى صورة بحجم/مقياس محدد أو [تصديره كملف SVG](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) للاستخدام كتوجيه رسوم متجهية.

**كيف أحصل بسرعة على الخصائص الفعلية (الفعّالة) للمستطيل مع مراعاة السمة والوراثة؟**

[استخدم الخصائص الفعّالة للشكل](/slides/ar/androidjava/shape-effective-properties/): تُعيد الواجهة البرمجية القيم المحسوبة التي تأخذ في الاعتبار أنماط السمة، التخطيط، والإعدادات المحلية، مما يبسط تحليل التنسيق.