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
- الخاصية المخفية
- مخطط التنظيم
- مخطط التنظيم بالصور
- PowerPoint
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "تعلم كيفية إنشاء وتعديل SmartArt في PowerPoint باستخدام Aspose.Slides للـ Android من خلال أمثلة كود Java واضحة تُسرّع تصميم الشرائح والأتمتة."
---
## **نظرة عامة**

SmartArt هو مخطط PowerPoint مكوّن من العقد وأشكال العقد وتخطيط. باستخدام Aspose.Slides for Android via Java، يمكنك إنشاء SmartArt، وقراءة النص من عقده، وتغيير تخطيطه، وفحص العقد المخفية، وتكوين تخطيطات مخطط التنظيم، وإنشاء مخططات تنظيمية بالصور.

## **الحصول على النص من كائن SmartArt**

يمكن أن يحتوي عقدة SmartArt على شكل واحد أو أكثر. لقراءة النص الظاهر، قم بالتكرار عبر [ISmartArt.getAllNodes](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ismartart/#getAllNodes--)، ثم اقرأ [ITextFrame](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/itextframe/) الذي يتم إرجاعه بواسطة [ISmartArtShape.getTextFrame](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ismartartshape/#getTextFrame--).

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    if (shape instanceof ISmartArt) {
        ISmartArt smartArt = (ISmartArt) shape;

        for (ISmartArtNode node : smartArt.getAllNodes()) {
            for (ISmartArtShape nodeShape : node.getShapes()) {
                if (nodeShape.getTextFrame() != null) {
                    System.out.println(nodeShape.getTextFrame().getText());
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **تغيير نوع التخطيط لكائن SmartArt**

يتحكم تخطيط SmartArt في كيفية ترتيب العقد وربطها. المثال التالي ينشئ كائن SmartArt باستخدام قيمة [SmartArtLayoutType](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/SmartArtLayoutType) `BasicBlockList`، يغيّرها إلى القيمة `BasicProcess`، ويحفظ العرض التقديمي.

```java
Presentation presentation = new Presentation();
try {
    ISmartArt smartArt = presentation.getSlides().get_Item(0).getShapes().addSmartArt(
        10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

    smartArt.setLayout(SmartArtLayoutType.BasicProcess);

    presentation.save("ChangeSmartArtLayout_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **التحقق مما إذا كانت عقدة SmartArt مخفية**

[ISmartArtNode.isHidden](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ismartartnode/#isHidden--) يشير إلى ما إذا كانت العقدة مخفية في نموذج بيانات SmartArt. يمكن أن توجد العقد المخفية في الهيكل حتى عندما لا يعرض التخطيط المحددها كعناصر مخطط مرئية.

المثال التالي يضيف عقدة إلى كائن SmartArt يستخدم قيمة [SmartArtLayoutType](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/SmartArtLayoutType) `RadialCycle` ويتحقق من حالة إخفاء العقدة.

```java
Presentation presentation = new Presentation();
try {
    ISmartArt smartArt = presentation.getSlides().get_Item(0).getShapes().addSmartArt(
        10, 10, 400, 300, SmartArtLayoutType.RadialCycle);

    ISmartArtNode node = smartArt.getAllNodes().addNode();
    boolean isHidden = node.isHidden();

    if (isHidden) {
        System.out.println("The node is hidden in the SmartArt data model.");
    }

    presentation.save("CheckSmartArtHiddenProperty_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **الحصول على تخطيط مخطط التنظيم أو تعيينه**

بالنسبة إلى مخططات SmartArt التي تستخدم تخطيط مخطط التنظيم، تحدد الدالتان [ISmartArtNode.getOrganizationChartLayout](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ISmartArtNode#getOrganizationChartLayout--) و[ISmartArtNode.setOrganizationChartLayout](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ISmartArtNode#setOrganizationChartLayout-int-) كيفية ترتيب العقد الفرعية تحت العقدة الأم. على سبيل المثال، يمكنك تعيين العقد الفرعية لتتدلى من اليسار أو اليمين أو الجانبين معًا، اعتمادًا على [OrganizationChartLayoutType](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/OrganizationChartLayoutType) المحدد.

المثال التالي ينشئ مخطط تنظيم ويضبط التخطيط للعقدة الأولى على القيمة [OrganizationChartLayoutType](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/OrganizationChartLayoutType) `LeftHanging`.

```java
Presentation presentation = new Presentation();
try {
    ISmartArt smartArt = presentation.getSlides().get_Item(0).getShapes().addSmartArt(
        10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);

    ISmartArtNode rootNode = smartArt.getNodes().get_Item(0);
    rootNode.setOrganizationChartLayout(OrganizationChartLayoutType.LeftHanging);

    presentation.save("OrganizationChartLayout_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **إنشاء مخطط تنظيم بالصور**

مخطط تنظيم بالصورة هو تخطيط SmartArt مصمم لمخططات الهرمية التي تتضمن نوافير صور. استخدم قيمة [SmartArtLayoutType](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/SmartArtLayoutType) `PictureOrganizationChart` عند إضافة كائن SmartArt إلى الشريحة.

```java
Presentation presentation = new Presentation();
try {
    ISmartArt smartArt = presentation.getSlides().get_Item(0).getShapes().addSmartArt(
        0, 0, 400, 400, SmartArtLayoutType.PictureOrganizationChart);

    presentation.save("PictureOrganizationChart_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **الأسئلة الشائعة**

**هل يدعم SmartArt الانعكاس أو العكس للغات من اليمين إلى اليسار؟**

نعم. الطريقة [ISmartArt.setReversed](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ismartart/#setReversed-boolean-) تغير اتجاه المخطط من اليسار إلى اليمين إلى اليمين إلى اليسار، أو العكس، عندما يدعم تخطيط SmartArt المختار العكس.

**كيف يمكنني نسخ SmartArt إلى نفس الشريحة أو إلى عرض تقديمي آخر مع الحفاظ على التنسيق؟**

يمكنك [استنساخ شكل SmartArt](/slides/ar/androidjava/shape-manipulations/) باستخدام [ShapeCollection.addClone](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/shapecollection/#addClone-com.aspose.slides.IShape-float-float-float-float-) أو [استنساخ الشريحة بالكامل](/slides/ar/androidjava/clone-slides/) التي تحتوي على SmartArt. كلا النهجين يحافظان على الحجم والموضع والتنسيق.

**كيف أقوم بإخراج SmartArt إلى صورة نقطية للمعاينة أو التصدير للويب؟**

[قم بإخراج الشريحة](/slides/ar/androidjava/convert-powerpoint-to-png/) أو العرض التقديمي بالكامل إلى PNG أو JPEG. يتم إخراج SmartArt كجزء من الشريحة.

**كيف يمكنني العثور على كائن SmartArt محدد في شريحة إذا كان هناك عدة كائنات؟**

قم بتعيين قيمة مميزة لـ [Shape.getAlternativeText](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/shape/#getAlternativeText--) أو [Shape.getName](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/shape/#getName--) على شكل SmartArt، ابحث عن تلك القيمة في [BaseSlide.getShapes](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/baseslide/#getShapes--)، ثم تأكد أن الشكل المطابق هو [ISmartArt](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ismartart/).