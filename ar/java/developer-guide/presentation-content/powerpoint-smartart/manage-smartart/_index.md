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
- الخاصية المخفية
- مخطط المنظمة
- مخطط منظمة الصورة
- PowerPoint
- العرض التقديمي
- Java
- Aspose.Slides
description: "تعلم كيفية إنشاء وتعديل SmartArt في PowerPoint باستخدام Aspose.Slides for Java من خلال عينات كود واضحة تُسرّع تصميم الشرائح والأتمتة."
---

## **احصل على النص من كائن SmartArt**
تم إضافة طريقة TextFrame الآن إلى واجهة [ISmartArtShape](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtShape) وفئة [SmartArtShape](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArtShape) على التوالي. تتيح لك هذه الخاصية الحصول على جميع النصوص من [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt) إذا لم يقتصر على نص العقد فقط. سيساعدك رمز العينة التالي في الحصول على النص من عقدة SmartArt.
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

- إنشاء مثال من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) .
- الحصول على مرجع الشريحة باستخدام فهرستها.
- إضافة [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) BasicBlockList.
- تغيير [LayoutType](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt#setLayout-int-) إلى BasicProcess.
- حفظ العرض التقديمي كملف PPTX.

في المثال أدناه، قمنا بإضافة موصل بين شكلين.
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


## **التحقق من الخاصية المخفية لكائن SmartArt**
يرجى ملاحظة: تُعيد الطريقة [ISmartArtNode.isHidden()]((https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtNode#isHidden--)) true إذا كانت هذه العقدة مخفية في نموذج البيانات. من أجل التحقق من الخاصية المخفية لأي عقدة من [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt). يرجى اتباع الخطوات أدناه:

- إنشاء مثال من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) .
- إضافة [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) RadialCycle.
- إضافة عقدة إلى SmartArt.
- التحقق من الخاصية [isHidden](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtNode#isHidden--) .
- حفظ العرض التقديمي كملف PPTX.

في المثال أدناه، قمنا بإضافة موصل بين شكلين.
```java
Presentation pres = new Presentation();
try {
    // إضافة SmartArt BasicProcess 
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);

    // إضافة عقدة على SmartArt 
    ISmartArtNode node = smart.getAllNodes().addNode();

    // التحقق من خاصية isHidden
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


## **الحصول أو تعيين نوع مخطط المنظمة**
تسمح الطرق [ISmartArtNode.getOrganizationChartLayout()](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtNode#getOrganizationChartLayout--) و [setOrganizationChartLayout(int)](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtNode#setOrganizationChartLayout-int-) بالحصول على أو تعيين نوع مخطط المنظمة المرتبط بالعقدة الحالية. من أجل الحصول أو تعيين نوع مخطط المنظمة، يرجى اتباع الخطوات أدناه:

- إنشاء مثال من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) .
- إضافة [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) إلى الشريحة.
- الحصول أو [تعيين نوع مخطط المنظمة](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtNode#setOrganizationChartLayout-int-) .
- حفظ العرض التقديمي كملف PPTX.

في المثال أدناه، قمنا بإضافة موصل بين شكلين.
```java
Presentation pres = new Presentation();
try {
    // إضافة SmartArt BasicProcess
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);

    // الحصول على أو تعيين نوع مخطط المنظمة
    smart.getNodes().get_Item(0).setOrganizationChartLayout(OrganizationChartLayoutType.LeftHanging);

    // حفظ العرض التقديمي
    pres.save("OrganizeChartLayoutType_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **إنشاء مخطط منظمة صورة**
توفر Aspose.Slides for Java واجهة برمجة تطبيقات بسيطة لإنشاء مخططات PictureOrganization بسهولة. لإنشاء مخطط على شريحة:

1. إنشاء مثال من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) .
2. الحصول على مرجع الشريحة عبر الفهرس الخاص بها.
3. إضافة مخطط ببيانات افتراضية مع النوع المطلوب (ChartType.PictureOrganizationChart).
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


## **الحصول أو تعيين حالة SmartArt**
من أجل تغيير نوع التخطيط لـ [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt). يرجى اتباع الخطوات أدناه:

1. إنشاء مثال من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) .
2. إضافة [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) إلى الشريحة.
3. [Get](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt#isReversed--) أو [Set](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt#setReversed-boolean-) حالة مخطط SmartArt.
4. حفظ العرض التقديمي كملف PPTX.

الكود التالي يُستخدم لإنشاء المخطط.
```java
// إنشاء كائن Presentation الذي يمثل ملف PPTX
Presentation pres = new Presentation();
try {
    // إضافة SmartArt BasicProcess
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicProcess);
    
    // الحصول على حالة مخطط SmartArt أو تعيينها
    smart.setReversed(true);
    boolean flag = smart.isReversed();
    
    // حفظ العرض التقديمي
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **الأسئلة الشائعة**

**هل يدعم SmartArt المرآة/العكس للغات من اليمين إلى اليسار؟**  
نعم. تقوم طريقة [setReversed](https://reference.aspose.com/slides/java/com.aspose.slides/smartart/#setReversed-boolean-) بتغيير اتجاه المخطط (LTR/RTL) إذا كان نوع SmartArt المحدد يدعم العكس.

**كيف يمكنني نسخ SmartArt إلى نفس الشريحة أو إلى عرض تقديمي آخر مع الحفاظ على التنسيق؟**  
يمكنك [clone the SmartArt shape](/slides/ar/java/shape-manipulations/) عبر مجموعة الأشكال ([ShapeCollection.addClone](https://reference.aspose.com/slides/java/com.aspose.slides/shapecollection/#addClone-com.aspose.slides.IShape-float-float-float-float-)) أو [clone the entire slide](/slides/ar/java/clone-slides/) الذي يحتوي على هذا الشكل. كلا الطريقتين تحافظان على الحجم والموضع والتنسيق.

**كيف أقوم بتصيير SmartArt إلى صورة نقطية للمعاينة أو تصدير الويب؟**  
يمكنك [Render the slide](/slides/ar/java/convert-powerpoint-to-png/) (أو العرض التقديمي بالكامل) إلى PNG/JPEG عبر واجهة برمجة التطبيقات التي تحول الشرائح/العروض إلى صور—سيتم رسم SmartArt كجزء من الشريحة.

**كيف يمكنني برمجياً اختيار SmartArt معين على شريحة إذا كان هناك عدة عناصر؟**  
من الممارسات الشائعة استخدام [alternative text](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getAlternativeText--) (نص بديل) أو [name](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getName--) والبحث عن الشكل باستخدام تلك السمة داخل [slide shapes](https://reference.aspose.com/slides/java/com.aspose.slides/baseslide/#getShapes--)، ثم التحقق من النوع للتأكد من أنه [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/smartart/). توضح الوثائق تقنيات شائعة للعثور على الأشكال والعمل معها.