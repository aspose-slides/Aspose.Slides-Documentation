---
title: إدارة SmartArt
type: docs
weight: 10
url: /java/manage-smartart/
---

## **الحصول على النص من SmartArt**
الآن تمت إضافة طريقة TextFrame إلى واجهة [ISmartArtShape](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtShape) وفئة [SmartArtShape](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArtShape). هذه الخاصية تتيح لك الحصول على جميع النصوص من [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt) إذا كان يحتوي على نصوص العقد فقط. الكود المثالي التالي سوف يساعدك في الحصول على النص من عقدة SmartArt.

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
لتغيير نوع تخطيط [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt). يرجى اتباع الخطوات التالية:

- قم بإنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
- احصل على مرجع شريحة باستخدام الفهرس الخاص بها.
- أضف [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) BasicBlockList.
- قم بتغيير [LayoutType](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt#setLayout-int-) إلى BasicProcess.
- قم بحفظ العرض التقديمي كملف PPTX.
  في المثال الموجود أدناه، قمنا بإضافة موصل بين شكلين.

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

## **التحقق من خاصية مخفية لـ SmartArt**
يرجى ملاحظة: تعيد طريقة [ISmartArtNode.isHidden()](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtNode#isHidden--) القيمة true إذا كانت هذه العقدة عقدة مخفية في نموذج البيانات. للتحقق من الخاصية المخفية لأي عقدة في [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt). يرجى اتباع الخطوات التالية:

- قم بإنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
- أضف [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) RadialCycle.
- أضف عقدة على SmartArt.
- تحقق من خاصية [isHidden](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtNode#isHidden--).
- قم بحفظ العرض التقديمي كملف PPTX.

في المثال الموجود أدناه، قمنا بإضافة موصل بين شكلين.

```java
Presentation pres = new Presentation();
try {
    // إضافة SmartArt BasicProcess 
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);

    // إضافة عقدة على SmartArt 
    ISmartArtNode node = smart.getAllNodes().addNode();

    // تحقق من خاصية isHidden
    boolean hidden = node.isHidden(); // تعيد true

    if (hidden)
    {
        // قم بعمل بعض الإجراءات أو الإشعارات
    }
    // حفظ العرض التقديمي
    pres.save("CheckSmartArtHiddenProperty_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **الحصول على نوع مخطط المنظمة أو تعيينه**
تسمح الطرق [ISmartArtNode.getOrganizationChartLayout()](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtNode#getOrganizationChartLayout--)، [setOrganizationChartLayout(int)](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtNode#setOrganizationChartLayout-int-) بالحصول أو تعيين نوع مخطط المنظمة المرتبط بالعقدة الحالية. للحصول على نوع مخطط المنظمة أو تعيينه. يرجى اتباع الخطوات التالية:

- قم بإنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
- أضف [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) على الشريحة.
- احصل على أو [قم بتعيين نوع مخطط المنظمة](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtNode#setOrganizationChartLayout-int-).
- قم بحفظ العرض التقديمي كملف PPTX.
  في المثال الموجود أدناه، قمنا بإضافة موصل بين شكلين.

```java
Presentation pres = new Presentation();
try {
    // إضافة SmartArt BasicProcess
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);

    // احصل على أو عيّن نوع مخطط المنظمة
    smart.getNodes().get_Item(0).setOrganizationChartLayout(OrganizationChartLayoutType.LeftHanging);

    // حفظ العرض التقديمي
    pres.save("OrganizeChartLayoutType_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **إنشاء مخطط منظمة صورة**
توفر Aspose.Slides لـ Java واجهة برمجة تطبيقات بسيطة لإنشاء المخططات وPictureOrganization بطريقة سهلة. لإنشاء مخطط على شريحة:

1. قم بإنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. احصل على مرجع الشريحة بواسطة فهرسها.
1. أضف مخططاً مع بيانات افتراضية مع النوع المطلوب (ChartType.PictureOrganizationChart).
1. قم بكتابة العرض التقديمي المعدل إلى ملف PPTX

يستخدم الكود التالي لإنشاء مخطط.

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
لتغيير نوع تخطيط [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt). يرجى اتباع الخطوات التالية:

1. قم بإنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. أضف [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) على الشريحة.
1. [احصل](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt#isReversed--) أو [عيّن](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt#setReversed-boolean-) حالة مخطط SmartArt.
1. قم بحفظ العرض التقديمي كملف PPTX.

يستخدم الكود التالي لإنشاء مخطط.

```java
// إنشاء مثيل من فئة Presentation التي تمثل ملف PPTX
Presentation pres = new Presentation();
try {
    // إضافة SmartArt BasicProcess
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicProcess);
    
    // احصل على أو عيّن حالة مخطط SmartArt
    smart.setReversed(true);
    boolean flag = smart.isReversed();
    
    // حفظ العرض التقديمي
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```