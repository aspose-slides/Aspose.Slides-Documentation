---
title: إدارة SmartArt في عروض PowerPoint التقديمية على Android
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
- مخطط تنظيم صورة
- PowerPoint
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "تعرّف على كيفية إنشاء وتحرير SmartArt في PowerPoint باستخدام Aspose.Slides for Android من خلال أمثلة شفرة Java واضحة تُسرّع تصميم الشرائح والأتمتة."
---

## **استخراج النص من كائن SmartArt**
الآن تم إضافة طريقة TextFrame إلى واجهة [ISmartArtShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArtShape) وفئة [SmartArtShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArtShape) على التوالي. تتيح هذه الخاصية الحصول على جميع النص من [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArt) إذا كان يحتوي على نص العقد فقط. سيساعدك الكود التجريبي التالي في استخراج النص من عقدة SmartArt.
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

- إنشاء مثال من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
- الحصول على مرجع الشريحة باستخدام الفهرس الخاص بها.
- إضافة [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) BasicBlockList.
- تغيير [LayoutType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt#setLayout-int-) إلى BasicProcess.
- حفظ العرض التقديمي كملف PPTX.

في المثال التالي، قمنا بإضافة موصل بين شكلين.
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
يرجى ملاحظة: الطريقة [ISmartArtNode.isHidden()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ismartartnode/#isHidden) تُعيد true إذا كانت هذه العقدة مخفية في نموذج البيانات. من أجل التحقق من خاصية الإخفاء لأي عقدة من [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArt). يرجى اتباع الخطوات التالية:

- إنشاء مثال من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
- إضافة [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) RadialCycle.
- إضافة عقدة إلى SmartArt.
- التحقق من خاصية [visibility](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ismartartnode/#isHidden).
- حفظ العرض التقديمي كملف PPTX.

في المثال التالي، قمنا بإضافة موصل بين شكلين.
```java
Presentation pres = new Presentation();
try {
    // إضافة SmartArt BasicProcess 
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);

    // إضافة عقدة إلى SmartArt 
    ISmartArtNode node = smart.getAllNodes().addNode();

    // فحص الخاصية isHidden
    boolean hidden = node.isHidden(); // إرجاع true

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


## **الحصول على نوع مخطط المنظمة أو تعيينه**
تسمح الطرق [ISmartArtNode.getOrganizationChartLayout()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArtNode#getOrganizationChartLayout--) و[setOrganizationChartLayout(int)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArtNode#setOrganizationChartLayout-int-) بالحصول أو تعيين نوع مخطط المنظمة المرتبط بالعقدة الحالية. من أجل الحصول على نوع مخطط المنظمة أو تعيينه، يرجى اتباع الخطوات التالية:

- إنشاء مثال من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
- إضافة [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) إلى الشريحة.
- الحصول أو [set the organization chart type](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArtNode#setOrganizationChartLayout-int-).
- حفظ العرض التقديمي كملف PPTX.

في المثال التالي، قمنا بإضافة موصل بين شكلين.
```java
Presentation pres = new Presentation();
try {
    // إضافة SmartArt BasicProcess
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);

    // الحصول أو تعيين نوع مخطط المنظمة
    smart.getNodes().get_Item(0).setOrganizationChartLayout(OrganizationChartLayoutType.LeftHanging);

    // حفظ العرض التقديمي
    pres.save("OrganizeChartLayoutType_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **إنشاء مخطط تنظيم صورة**
توفر Aspose.Slides for Android عبر Java واجهة برمجة تطبيقات بسيطة لإنشاء مخططات PictureOrganization بطريقة سهلة. لإنشاء مخطط على شريحة:

1. إنشاء مثال من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. الحصول على مرجع الشريحة باستخدام الفهرس الخاص بها.
3. إضافة مخطط بالبيانات الافتراضية مع النوع المطلوب (ChartType.PictureOrganizationChart).
4. حفظ العرض التقديمي المعدل كملف PPTX.

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


## **الحصول على حالة SmartArt أو تعيينها**
من أجل تغيير حالة مخطط SmartArt، يرجى اتباع الخطوات التالية:

1. إنشاء مثال من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. إضافة [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) إلى الشريحة.
3. [Get](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt#isReversed--) أو [Set](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt#setReversed-boolean-) حالة مخطط SmartArt.
4. حفظ العرض التقديمي كملف PPTX.

الكود التالي يُستخدم لإنشاء المخطط.
```java
// إنشاء كائن من فئة Presentation التي تمثل ملف PPTX
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


## **اسئلة شائعة**

**هل يدعم SmartArt عكس/انعكاس للغات RTL؟**

نعم. تقوم طريقة [setReversed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/smartart/#setReversed-boolean-) بتغيير اتجاه المخطط (LTR/RTL) إذا كان نوع SmartArt المختار يدعم العكس.

**كيف يمكنني نسخ SmartArt إلى نفس الشريحة أو إلى عرض تقديمي آخر مع الحفاظ على التنسيق؟**

يمكنك [clone the SmartArt shape](/slides/ar/androidjava/shape-manipulations/) عبر مجموعة الأشكال ([ShapeCollection.addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shapecollection/#addClone-com.aspose.slides.IShape-float-float-float-float-)) أو [clone the entire slide](/slides/ar/androidjava/clone-slides/) التي تحتوي على هذا الشكل. كلا الطريقتين تحافظان على الحجم والموقع والأسلوب.

**كيف أقوم بتحويل SmartArt إلى صورة نقطية للمعاينة أو التصدير إلى الويب؟**

[Render the slide](/slides/ar/androidjava/convert-powerpoint-to-png/) (أو العرض التقديمي بأكمله) إلى PNG/JPEG عبر واجهة برمجة التطبيقات التي تحول الشرائح/العروض إلى صور—سيتم رسم SmartArt كجزء من الشريحة.

**كيف يمكنني برمجيًا تحديد SmartArt معين على شريحة إذا كان هناك عدة عناصر؟**

من الممارسات الشائعة استخدام [alternative text](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getAlternativeText--) (نص بديل) أو [name](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getName--) والبحث عن الشكل بواسطة هذه الخاصية ضمن [slide shapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseslide/#getShapes--)، ثم فحص النوع للتأكد من أنه [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/smartart/). الوثائق توضح تقنيات شائعة للعثور على الأشكال والعمل معها.