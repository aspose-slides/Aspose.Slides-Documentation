---
title: إدارة SmartArt في عروض PowerPoint باستخدام Java
linktitle: إدارة SmartArt
type: docs
weight: 10
url: /ar/java/manage-smartart/
keywords:
- SmartArt
- نص SmartArt
- نوع التخطيط
- خاصية الإخفاء
- مخطط المؤسسة
- مخطط تنظيم الصور
- PowerPoint
- عرض تقديمي
- Java
- Aspose.Slides
description: "تعلم كيفية إنشاء وتحرير SmartArt في PowerPoint باستخدام Aspose.Slides for Java عبر أمثلة شفرة واضحة تُسرّع تصميم الشرائح والأتمتة."
---

## **الحصول على النص من كائن SmartArt**
تمت إضافة طريقة TextFrame إلى واجهة [ISmartArtShape](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtShape) والفئة [SmartArtShape](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArtShape) على التوالي. تسمح هذه الخاصية بالحصول على كل النص من [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt) إذا كان يحتوي على نص ليس فقط نص العقد. الكود النموذجي التالي سيساعدك على الحصول على النص من عقدة SmartArt.
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
من أجل تغيير نوع التخطيط لـ [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt). يرجى اتباع الخطوات أدناه:

- إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
- الحصول على مرجع الشريحة باستخدام الفهرس الخاص بها.
- إضافة [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) BasicBlockList.
- تغيير [LayoutType](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt#setLayout-int-) إلى BasicProcess.
- حفظ العرض التقديمي كملف PPTX.

في المثال المعطى أدناه، قمنا بإضافة موصل بين شكلين.
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


## **التحقق من خاصية الرؤية لكائن SmartArt**
يرجى ملاحظة: طريقة [ISmartArtNode.isHidden()](https://reference.aspose.com/slides/java/com.aspose.slides/ismartartnode/#isHidden--) تُعيد true إذا كانت هذه العقدة مخفية في نموذج البيانات. للتحقق من خاصية الإخفاء لأي عقدة من [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt). يرجى اتباع الخطوات أدناه:

- إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
- إضافة [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) RadialCycle.
- إضافة عقدة إلى SmartArt.
- التحقق من خاصية [visibility](https://reference.aspose.com/slides/java/com.aspose.slides/ismartartnode/#isHidden--).
- حفظ العرض التقديمي كملف PPTX.

في المثال المعطى أدناه، قمنا بإضافة موصل بين شكلين.
```java
Presentation pres = new Presentation();
try {
    // إضافة SmartArt BasicProcess 
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);

    // إضافة عقدة على SmartArt 
    ISmartArtNode node = smart.getAllNodes().addNode();

    // فحص خاصية isHidden
    boolean hidden = node.isHidden(); // يرجع true

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
تسمح الطرق [ISmartArtNode.getOrganizationChartLayout()](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtNode#getOrganizationChartLayout--) و[setOrganizationChartLayout(int)](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtNode#setOrganizationChartLayout-int-) بالحصول على أو تعيين نوع مخطط المؤسسة المرتبط بالعقدة الحالية. للحصول على أو تعيين نوع مخطط المؤسسة. يرجى اتباع الخطوات أدناه:

- إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
- إضافة [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) إلى الشريحة.
- الحصول على أو [تعيين نوع مخطط المؤسسة](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtNode#setOrganizationChartLayout-int-).
- حفظ العرض التقديمي كملف PPTX.

في المثال المعطى أدناه، قمنا بإضافة موصل بين شكلين.
```java
Presentation pres = new Presentation();
try {
    // إضافة SmartArt BasicProcess
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);

    // الحصول على أو تعيين نوع مخطط المؤسسة
    smart.getNodes().get_Item(0).setOrganizationChartLayout(OrganizationChartLayoutType.LeftHanging);

    // حفظ العرض التقديمي
    pres.save("OrganizeChartLayoutType_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **إنشاء مخطط Picture Organization**
توفر Aspose.Slides for Java واجهة برمجة تطبيقات بسيطة لإنشاء مخططات PictureOrganization بطريقة سهلة. لإنشاء مخطط على شريحة:

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. الحصول على مرجع الشريحة باستخدام الفهرس الخاص بها.
1. إضافة مخطط ببيانات افتراضية مع النوع المطلوب (ChartType.PictureOrganizationChart).
1. حفظ العرض التقديمي المعدل إلى ملف PPTX.

الكود التالي يُستخدم لإنشاء المخطط.
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
من أجل تغيير نوع التخطيط لـ [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt). يرجى اتباع الخطوات أدناه:

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. إضافة [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) إلى الشريحة.
1. [الحصول](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt#isReversed--) أو [تعيين](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt#setReversed-boolean-) حالة مخطط SmartArt.
1. حفظ العرض التقديمي كملف PPTX.

الكود التالي يُستخدم لإنشاء المخطط.
```java
// إنشاء كائن Presentation الذي يمثل ملف PPTX
Presentation pres = new Presentation();
try {
    // إضافة SmartArt BasicProcess
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicProcess);
    
    // الحصول على أو تعيين حالة مخطط SmartArt
    smart.setReversed(true);
    boolean flag = smart.isReversed();
    
    // حفظ العرض التقديمي
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**هل يدعم SmartArt انعكاس/عكس الاتجاه للغات من اليمين إلى اليسار؟**

نعم. طريقة [setReversed](https://reference.aspose.com/slides/java/com.aspose.slides/smartart/#setReversed-boolean-) تعكس اتجاه المخطط (LTR/RTL) إذا كان نوع SmartArt المختار يدعم العكس.

**كيف يمكنني نسخ SmartArt إلى نفس الشريحة أو إلى عرض تقديمي آخر مع الحفاظ على التنسيق؟**

يمكنك [استنساخ شكل SmartArt](/slides/ar/java/shape-manipulations/) عبر مجموعة الأشكال ([ShapeCollection.addClone](https://reference.aspose.com/slides/java/com.aspose.slides/shapecollection/#addClone-com.aspose.slides.IShape-float-float-float-float-)) أو [استنساخ الشريحة بالكامل](/slides/ar/java/clone-slides/) التي تحتوي على هذا الشكل. كلا الطريقتين تحافظان على الحجم والموقع والأنماط.

**كيف أقوم بتحويل SmartArt إلى صورة نقطية للمعاينة أو للتصدير إلى الويب؟**

[حوّل الشريحة](/slides/ar/java/convert-powerpoint-to-png/) (أو العرض الكامل) إلى PNG/JPEG عبر API الذي يحول الشرائح/العروض إلى صور—سيتم رسم SmartArt كجزء من الشريحة.

**كيف يمكنني برمجياً اختيار SmartArt محدد على شريحة إذا كان هناك عدة عناصر؟**

الممارسة الشائعة هي استخدام [النص البديل](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getAlternativeText--) (Alt Text) أو [الاسم](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getName--) والبحث عن الشكل بناءً على تلك السمة داخل [أشكال الشريحة](https://reference.aspose.com/slides/java/com.aspose.slides/baseslide/#getShapes--)، ثم التحقق من النوع للتأكد من أنه [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/smartart/). توثيق Aspose يوضح تقنيات شائعة للعثور على الأشكال والعمل معها.