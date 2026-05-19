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
- خاصية مخفية
- مخطط المنظمة
- مخطط منظمة بالصورة
- PowerPoint
- عرض تقديمي
- Java
- Aspose.Slides
description: "تعلم كيفية إنشاء وتعديل SmartArt في PowerPoint باستخدام Aspose.Slides for Java عبر أمثلة شفرة واضحة تسرّع تصميم الشرائح والأتمتة."
---
## **نظرة عامة**

SmartArt هو مخطط PowerPoint يتكون من العقد وأشكال العقد وتخطيط. باستخدام Aspose.Slides for Java، يمكنك إنشاء SmartArt، وقراءة النص من عقده، وتغيير تخطيطه، وفحص العقد المخفية، وتكوين تخطيطات مخطط المنظمة، وإنشاء مخططات منظمة بصورة.

## **الحصول على النص من كائن SmartArt**

يمكن أن تحتوي عقدة SmartArt على شكل واحد أو أكثر. لقراءة النص الظاهر، قم بالتكرار عبر [ISmartArt.getAllNodes](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ismartart/#getAllNodes--)، ثم اقرأ الـ[ITextFrame](https://reference.aspose.com/slides/ar/java/com.aspose.slides/itextframe/) الذي تُرجعه [ISmartArtShape.getTextFrame](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ismartartshape/#getTextFrame--).

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

يتحكم تخطيط SmartArt في كيفية ترتيب العقد وربطها. المثال التالي ينشئ كائن SmartArt باستخدام قيمة [SmartArtLayoutType](https://reference.aspose.com/slides/ar/java/com.aspose.slides/SmartArtLayoutType) `BasicBlockList`، ثم يغيرها إلى قيمة `BasicProcess`، ويحفظ العرض التقديمي.

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

[ISmartArtNode.isHidden](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ismartartnode/#isHidden--) يشير إلى ما إذا كانت العقدة مخفية في نموذج بيانات SmartArt. يمكن أن توجد العقد المخفية في الهيكل حتى عندما لا يعرض التخطيط المحدد لها كعناصر مخطط مرئية.

المثال التالي يضيف عقدة إلى كائن SmartArt يستخدم قيمة [SmartArtLayoutType](https://reference.aspose.com/slides/ar/java/com.aspose.slides/SmartArtLayoutType) `RadialCycle` ويتحقق من حالة إخفاء العقدة.

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

## **الحصول على تخطيط مخطط المنظمة أو تعيينه**

للمخططات SmartArt التي تستخدم تخطيط مخطط المنظمة، يعرّف كل من [ISmartArtNode.getOrganizationChartLayout](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ISmartArtNode#getOrganizationChartLayout--) و[ISmartArtNode.setOrganizationChartLayout](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ISmartArtNode#setOrganizationChartLayout-int-) كيفية ترتيب العقد الفرعية تحت عقدة أصلية. على سبيل المثال، يمكنك تعيين العقد الفرعية للتدَلّ من اليسار أو اليمين أو كلا الجانبين، وفقًا لـ[OrganizationChartLayoutType](https://reference.aspose.com/slides/ar/java/com.aspose.slides/OrganizationChartLayoutType) المحدد.

المثال التالي ينشئ مخطط منظمة ويعين التخطيط للعقدة الأولى إلى قيمة [OrganizationChartLayoutType](https://reference.aspose.com/slides/ar/java/com.aspose.slides/OrganizationChartLayoutType) `LeftHanging`.

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

## **إنشاء مخطط منظمة بصورة**

مخطط المنظمة بالصورة هو تخطيط SmartArt صُمم لمخططات التسلسل الهرمي التي تتضمن نواقل صور. استخدم قيمة [SmartArtLayoutType](https://reference.aspose.com/slides/ar/java/com.aspose.slides/SmartArtLayoutType) `PictureOrganizationChart` عند إضافة كائن SmartArt إلى شريحة.

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

**هل يدعم SmartArt عكس أو انعكاس للغات من اليمين إلى اليسار؟**

نعم. الطريقة [ISmartArt.setReversed](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ismartart/#setReversed-boolean-) تغير اتجاه المخطط من اليسار إلى اليمين إلى اليمين إلى اليسار، أو العكس، عندما يدعم التخطيط المختار عكس الاتجاه.

**كيف يمكنني نسخ SmartArt إلى الشريحة نفسها أو إلى عرض تقديمي آخر مع الحفاظ على التنسيق؟**

يمكنك [clone the SmartArt shape](/slides/ar/java/shape-manipulations/) باستخدام [ShapeCollection.addClone](https://reference.aspose.com/slides/ar/java/com.aspose.slides/shapecollection/#addClone-com.aspose.slides.IShape-float-float-float-float-) أو [clone the whole slide](/slides/ar/java/clone-slides/) الذي يحتوي على SmartArt. كلا الطريقتين تحافظان على الحجم والموقع والتنسيق.

**كيف أقوم بتحويل SmartArt إلى صورة نقطية للمعاينة أو لتصدير الويب؟**

[Render the slide](/slides/ar/java/convert-powerpoint-to-png/) أو العرض التقديمي بالكامل إلى PNG أو JPEG. يتم تصيير SmartArt كجزء من الشريحة.

**كيف يمكنني العثور على كائن SmartArt محدد في شريحة إذا كان هناك عدة كائنات؟**

حدد قيمة مميزة باستخدام [Shape.getAlternativeText](https://reference.aspose.com/slides/ar/java/com.aspose.slides/shape/#getAlternativeText--) أو [Shape.getName](https://reference.aspose.com/slides/ar/java/com.aspose.slides/shape/#getName--) على شكل SmartArt، وابحث عن تلك القيمة في [BaseSlide.getShapes](https://reference.aspose.com/slides/ar/java/com.aspose.slides/baseslide/#getShapes--)، ثم تأكد أن الشكل المطابق هو [ISmartArt](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ismartart/).