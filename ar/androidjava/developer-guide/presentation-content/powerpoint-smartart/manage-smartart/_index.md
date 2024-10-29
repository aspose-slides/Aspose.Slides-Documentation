---
title: إدارة SmartArt
type: docs
weight: 10
url: /ar/androidjava/manage-smartart/
---

## **الحصول على النص من SmartArt**
الآن تم إضافة طريقة TextFrame إلى واجهة [ISmartArtShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArtShape) وclass [SmartArtShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArtShape). هذه الخاصية تتيح لك الحصول على كل النص من [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArt) إذا كان يحتوي على نصوص داخل العقد. الكود العينة التالي سيساعدك على الحصول على النص من عقدة SmartArt.

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

## **تغيير نوع تخطيط SmartArt**
لتغيير نوع التخطيط ل [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArt). يرجى اتباع الخطوات التالية:

- أنشئ مثيلًا من class [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
- احصل على مرجع شريحة باستخدام رقم الفهرس الخاص بها.
- أضف [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) BasicBlockList.
- غير [LayoutType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt#setLayout-int-) إلى BasicProcess.
- قم بكتابة العرض التقديمي كملف PPTX.
  في المثال المقدم أدناه، أضفنا موصل بين شكلين.

```java
Presentation pres = new Presentation();
try {
    // Add SmartArt BasicProcess
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

    // Change LayoutType to BasicProcess
    smart.setLayout(SmartArtLayoutType.BasicProcess);

    // Saving Presentation
    pres.save("ChangeSmartArtLayout_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **تحقق من خاصية الإخفاء ل SmartArt**
يرجى ملاحظة: تعيد طريقة [ISmartArtNode.isHidden()]((https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArtNode#isHidden--)) قيمة true إذا كانت هذه العقدة عقدة مخفية في نموذج البيانات. للتحقق من خاصية الإخفاء لأي عقدة من [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArt). يرجى اتباع الخطوات التالية:

- أنشئ مثيلًا من class [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
- أضف [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) RadialCycle.
- أضف عقدة على SmartArt.
- تحقق من خاصية [isHidden](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArtNode#isHidden--) .
- قم بكتابة العرض التقديمي كملف PPTX.

في المثال المقدم أدناه، أضفنا موصل بين شكلين.

```java
Presentation pres = new Presentation();
try {
    // Add SmartArt BasicProcess 
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);

    // Add node on SmartArt 
    ISmartArtNode node = smart.getAllNodes().addNode();

    // Check isHidden property
    boolean hidden = node.isHidden(); // Returns true

    if (hidden)
    {
        // قم ببعض الإجراءات أو الإشعارات
    }
    // Saving Presentation
    pres.save("CheckSmartArtHiddenProperty_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **الحصول على أو ضبط نوع مخطط التنظيم**
تتيح الطرق [ISmartArtNode.getOrganizationChartLayout()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArtNode#getOrganizationChartLayout--), [setOrganizationChartLayout(int)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArtNode#setOrganizationChartLayout-int-) الحصول على نوع مخطط التنظيم المرتبط بالعقدة الحالية أو ضبطه. للحصول على أو ضبط نوع مخطط التنظيم. يرجى اتباع الخطوات التالية:

- أنشئ مثيلًا من class [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
- أضف [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) على الشريحة.
- احصل على أو [اضبط نوع مخطط التنظيم](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArtNode#setOrganizationChartLayout-int-) .
- قم بكتابة العرض التقديمي كملف PPTX.
  في المثال المقدم أدناه، أضفنا موصل بين شكلين.

```java
Presentation pres = new Presentation();
try {
    // Add SmartArt BasicProcess
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);

    // Get or Set the organization chart type
    smart.getNodes().get_Item(0).setOrganizationChartLayout(OrganizationChartLayoutType.LeftHanging);

    // Saving Presentation
    pres.save("OrganizeChartLayoutType_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **إنشاء مخطط تنظيم بالصورة**
توفر Aspose.Slides لـ Android عبر Java واجهة برمجة تطبيقات بسيطة لإنشاء المخططات بصورة وتقديمها بطريقة سهلة. لإنشاء مخطط على شريحة:

1. أنشئ مثيلًا من class [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. احصل على مرجع الشريحة بواسطة فهرسها.
1. أضف مخططًا ببيانات افتراضية جنبًا إلى جنب مع النوع المطلوب (ChartType.PictureOrganizationChart).
1. قم بكتابة العرض التقديمي المعدل إلى ملف PPTX.

الكود التالي يستخدم لإنشاء مخطط.

```java
Presentation pres = new Presentation("test.pptx");
try {
    ISmartArt smartArt = pres.getSlides().get_Item(0).getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.PictureOrganizationChart);
    pres.save("OrganizationChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **الحصول على أو ضبط حالة SmartArt**
لتغيير نوع التخطيط ل [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArt). يرجى اتباع الخطوات التالية:

1. أنشئ مثيلًا من class [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. أضف [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) على الشريحة.
1. [احصل](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt#isReversed--) أو [اضبط](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt#setReversed-boolean-) حالة مخطط SmartArt.
1. قم بكتابة العرض التقديمي كملف PPTX.

الكود التالي يستخدم لإنشاء مخطط.

```java
// إنشاء مثيل class Presentation الذي يمثل ملف PPTX
Presentation pres = new Presentation();
try {
    // Add SmartArt BasicProcess
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicProcess);
    
    // Get or Set the state of SmartArt Diagram
    smart.setReversed(true);
    boolean flag = smart.isReversed();
    
    // Saving Presentation
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```