---
title: إدارة SmartArt في عروض PowerPoint على Android
linktitle: إدارة SmartArt
type: docs
weight: 10
url: /ar/androidjava/manage-smartart/
keywords:
- SmartArt
- نص SmartArt
- نوع التخطيط
- خاصية الإخفاء
- مخطط المؤسسة
- مخطط صورة المؤسسة
- PowerPoint
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "تعرّف على كيفية إنشاء وتحرير SmartArt في PowerPoint باستخدام Aspose.Slides for Android من خلال أمثلة شفرة Java واضحة تُسرّع تصميم الشرائح وتُحسّن الأتمتة."
---

## **الحصول على النص من كائن SmartArt**
الآن تم إضافة طريقة TextFrame إلى واجهة [ISmartArtShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArtShape) وفئة [SmartArtShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArtShape) على التوالي. تسمح لك هذه الخاصية بالحصول على كل النص من [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArt) إذا لم يكن يحتوي فقط على نص العقد. سيساعدك الكود المثال التالي في الحصول على النص من عقدة SmartArt.
```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);
    ISmartArt smartArt = (ISmartArt)slide.getShapes().get_Item(0);

    ISmartArtNodeCollection smartArtNodes = smartArt.getAllNodes();
    for (ISmartArtNode smartArtNode : smartArtNodes)
    {
        for (ISmartArtShape nodeShape : smartArtNode.getShapes())
        {
            if (nodeShape.getTextFrame() != null)
                System.out.println(nodeShape.getTextFrame().getText());
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```


## **تغيير نوع التخطيط لكائن SmartArt**
من أجل تغيير نوع التخطيط لـ [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArt). يرجى اتباع الخطوات التالية:

- إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
- الحصول على مرجع الشريحة باستخدام الفهرس الخاص بها.
- إضافة [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) BasicBlockList.
- تغيير [LayoutType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt#setLayout-int-) إلى BasicProcess.
- كتابة العرض التقديمي كملف PPTX.

في المثال الموضح أدناه، أضفنا موصلًا بين شكلين.
```java
Presentation pres = new Presentation();
try {
    // إضافة SmartArt BasicProcess
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

    // تغيير LayoutType إلى BasicProcess
    smart.setLayout(SmartArtLayoutType.BasicProcess);

    // حفظ العرض التقديمي
    pres.save("ChangeSmartArtLayout_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **التحقق من خاصية الإخفاء لكائن SmartArt**
يرجى الملاحظة: الطريقة [ISmartArtNode.isHidden()]((https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArtNode#isHidden--)) تُعيد true إذا كانت هذه العقدة عقدة مخفية في نموذج البيانات. للتحقق من خاصية الإخفاء لأي عقدة من [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArt). يرجى اتباع الخطوات التالية:

- إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
- إضافة [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) RadialCycle.
- إضافة عقدة إلى SmartArt.
- التحقق من خاصية [isHidden](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArtNode#isHidden--) .
- كتابة العرض التقديمي كملف PPTX.

في المثال الموضح أدناه، أضفنا موصلًا بين شكلين.
```java
Presentation pres = new Presentation();
try {
    // إضافة SmartArt BasicProcess 
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);

    // إضافة عقدة إلى SmartArt 
    ISmartArtNode node = smart.getAllNodes().addNode();

    // التحقق من خاصية isHidden
    boolean hidden = node.isHidden(); // يعيد true

    if (hidden)
    {
        // تنفيذ بعض الإجراءات أو الإشعارات
    }
    // حفظ العرض التقديمي
    pres.save("CheckSmartArtHiddenProperty_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **الحصول على أو تعيين نوع مخطط المؤسسة**
الطرق [ISmartArtNode.getOrganizationChartLayout()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArtNode#getOrganizationChartLayout--)، [setOrganizationChartLayout(int)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArtNode#setOrganizationChartLayout-int-) تتيح الحصول أو تعيين نوع مخطط المؤسسة المرتبط بالعقدة الحالية. للحصول على أو تعيين نوع مخطط المؤسسة، يرجى اتباع الخطوات التالية:

- إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
- إضافة [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) إلى الشريحة.
- الحصول أو [تعيين نوع مخطط المؤسسة](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArtNode#setOrganizationChartLayout-int-).
- كتابة العرض التقديمي كملف PPTX.

في المثال الموضح أدناه، أضفنا موصلًا بين شكلين.
```java
Presentation pres = new Presentation();
try {
    // إضافة SmartArt BasicProcess
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);

    // الحصول أو تعيين نوع مخطط المؤسسة
    smart.getNodes().get_Item(0).setOrganizationChartLayout(OrganizationChartLayoutType.LeftHanging);

    // حفظ العرض التقديمي
    pres.save("OrganizeChartLayoutType_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **إنشاء مخطط مؤسسة صورة**
توفر Aspose.Slides للأندرويد عبر جافا واجهة برمجة تطبيقات بسيطة لإنشاء مخططات PictureOrganization بطريقة سهلة. لإنشاء مخطط على شريحة:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. الحصول على مرجع الشريحة عبر فهرستها.
3. إضافة مخطط مع بيانات افتراضية مع النوع المطلوب (ChartType.PictureOrganizationChart).
4. كتابة العرض التقديمي المعدل إلى ملف PPTX

يتم استخدام الكود التالي لإنشاء المخطط.
```java
Presentation pres = new Presentation("test.pptx");
try {
    ISmartArt smartArt = pres.getSlides().get_Item(0).getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.PictureOrganizationChart);
    pres.save("OrganizationChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **الحصول على أو تعيين حالة SmartArt**
من أجل تغيير حالة [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArt). يرجى اتباع الخطوات التالية:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. إضافة [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) إلى الشريحة.
1. [Get](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt#isReversed--) أو [Set](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt#setReversed-boolean-) حالة مخطط SmartArt.
1. كتابة العرض التقديمي كملف PPTX.

يتم استخدام الكود التالي لإنشاء المخطط.
```java
// إنشاء كائن من فئة Presentation التي تمثل ملف PPTX
Presentation pres = new Presentation();
try {
    // إضافة SmartArt BasicProcess
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicProcess);
    
    // الحصول أو تعيين حالة مخطط SmartArt
    smart.setReversed(true);
    boolean flag = smart.isReversed();
    
    // حفظ العرض التقديمي
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **الأسئلة الشائعة**

**هل يدعم SmartArt العكس/العكس للغات RTL؟**

نعم. الطريقة [setReversed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/smartart/#setReversed-boolean-) تغير اتجاه المخطط (LTR/RTL) إذا كان نوع SmartArt المحدد يدعم العكس.

**كيف يمكنني نسخ SmartArt إلى الشريحة نفسها أو إلى عرض تقديمي آخر مع الحفاظ على التنسيق؟**

يمكنك [استنساخ شكل SmartArt](/slides/ar/androidjava/shape-manipulations/) عبر مجموعة الأشكال ([ShapeCollection.addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shapecollection/#addClone-com.aspose.slides.IShape-float-float-float-float-)) أو [استنساخ الشريحة بالكامل](/slides/ar/androidjava/clone-slides/) التي تحتوي على هذا الشكل. كلا النهجين يحافظان على الحجم والموضع والنمط.

**كيف أقوم بتصوير SmartArt إلى صورة نقطية للمعاينة أو لتصدير الويب؟**

[قم بتصوير الشريحة](/slides/ar/androidjava/convert-powerpoint-to-png/) (أو العرض التقديمي بالكامل) إلى PNG/JPEG عبر الـ API الذي يحول الشرائح/العروض إلى صور—سيتم رسم SmartArt كجزء من الشريحة.

**كيف يمكنني اختيار SmartArt محدد برمجيًا على شريحة إذا كان هناك عدة عناصر؟**

ممارسة شائعة هي استخدام [النص البديل](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getAlternativeText--) (Alt Text) أو [الاسم](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getName--) والبحث عن الشكل بواسطة تلك السمة داخل [شكل الشريحة](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseslide/#getShapes--)، ثم التحقق من النوع لتأكيد أنه [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/smartart/). الوثائق تصف التقنيات النموذجية للعثور على الأشكال والعمل معها.