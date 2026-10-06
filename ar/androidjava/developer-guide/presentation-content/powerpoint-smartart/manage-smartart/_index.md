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
- خاصية مخفية
- مخطط تنظيم
- مخطط تنظيم بالصور
- PowerPoint
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "تعلم كيفية إنشاء وتعديل SmartArt في PowerPoint باستخدام Aspose.Slides للأندرويد من خلال أمثلة Java واضحة تُسرّع تصميم الشرائح وأتمتتها."
---
## **نظرة عامة**

SmartArt هو مخطط PowerPoint يتكون من العقد، أشكال العقد، وتخطيط. باستخدام Aspose.Slides for Android via Java، يمكنك إنشاء SmartArt، قراءة النص من عقده، تغيير تخطيطه، فحص العقد المخفية، تكوين تخطيطات مخطط التنظيم، وإنشاء مخططات تنظيم بالصور.

## **الحصول على نص من كائن SmartArt**

يمكن أن تحتوي عقدة SmartArt على شكل أو أكثر. لقراءة النص من أشكال العقدة، تكرّر عبر [ISmartArt.getAllNodes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ismartart/#getAllNodes--)، ثم اقرأ [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) المرتجع من [ISmartArtShape.getTextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ismartartshape/#getTextFrame--).

يتطلب المثال عرض تقديمي يحتوي على شريحة واحدة على الأقل وكائن SmartArt كأول شكل على تلك الشريحة. يطبع كل إطار نص متاح إلى وحدة التحكم.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ISmartArt smartArt = (ISmartArt) slide.getShapes().get_Item(0);
    for (ISmartArtNode node : smartArt.getAllNodes()) {
        for (ISmartArtShape nodeShape : node.getShapes()) {
            if (nodeShape.getTextFrame() != null) {
                System.out.println(nodeShape.getTextFrame().getText());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **تغيير نوع تخطيط كائن SmartArt**

يتحكم تخطيط SmartArt في طريقة ترتيب العقد وربطها. المثال التالي ينشئ كائن SmartArt باستخدام قيمة [SmartArtLayoutType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/smartartlayouttype/) `BasicBlockList`، ثم يغيّره إلى القيمة `BasicProcess`، ويحفظ العرض التقديمي. يتم قياس الموضع والحجم الممررين إلى [IShapeCollection.addSmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addSmartArt-float-float-float-float-int-) بالنقاط. استخدم [ISmartArt.setLayout](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ismartart/#setLayout-int-) لتغيير التخطيط.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ISmartArt smartArt = slide.getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);
    smartArt.setLayout(SmartArtLayoutType.BasicProcess);

    presentation.save("ChangeSmartArtLayout.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **التحقق مما إذا كانت عقدة SmartArt مخفية**

[ISmartArtNode.isHidden](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ismartartnode/#isHidden--) يوضح ما إذا كانت العقدة مخفية في نموذج بيانات SmartArt. يمكن أن توجد العقد المخفية في الهيكل حتى عندما لا يظهر التخطيط المختارها كعناصر مرئية في المخطط.

المثال التالي يضيف عقدة إلى كائن SmartArt يستخدم قيمة [SmartArtLayoutType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/smartartlayouttype/) `RadialCycle` ويتحقق من حالة الإخفاء للعقدة المضافة. يطبع رسالة إذا كانت العقدة مخفية ويحفظ المخطط.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ISmartArt smartArt = slide.getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);
    ISmartArtNode node = smartArt.getAllNodes().addNode();
    boolean isHidden = node.isHidden();

    if (isHidden) {
        System.out.println("The node is hidden in the SmartArt data model.");
    }

    presentation.save("CheckSmartArtHiddenProperty.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **الحصول على تخطيط مخطط التنظيم أو تعيينه**

بالنسبة لمخططات SmartArt التي تستخدم تخطيط مخطط التنظيم، يحدد كل من [ISmartArtNode.getOrganizationChartLayout](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ismartartnode/#getOrganizationChartLayout--) و[ISmartArtNode.setOrganizationChartLayout](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ismartartnode/#setOrganizationChartLayout-int-) طريقة ترتيب العقد الفرعية تحت العقدة الأم. على سبيل المثال، يمكنك تعيين العقد الفرعية لتتدلى من اليسار أو اليمين أو الجانبين، اعتمادًا على [OrganizationChartLayoutType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/organizationchartlayouttype/) المختار.

المثال التالي ينشئ مخطط تنظيم ويضبط التخطيط للعقدة الأولى إلى قيمة [OrganizationChartLayoutType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/organizationchartlayouttype/) `LeftHanging`. يحدد الفهرس الصفري `0` العقدة العليا الأولى؛ تستخدم عقدها الفرعية الترتيب المحدد. ثم يتم حفظ العرض التقديمي المعدل.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ISmartArt smartArt = slide.getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);
    ISmartArtNode rootNode = smartArt.getNodes().get_Item(0);
    rootNode.setOrganizationChartLayout(OrganizationChartLayoutType.LeftHanging);

    presentation.save("OrganizationChartLayout.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **إنشاء مخطط تنظيم بالصور**

مخطط تنظيم بالصور هو تخطيط SmartArt مصمم لمخططات الهرمية التي تتضمن عناصر نائبة للصور. استخدم قيمة [SmartArtLayoutType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/smartartlayouttype/) `PictureOrganizationChart` عند إضافة كائن SmartArt إلى شريحة. يحفظ هذا المثال مخططًا يحتوي على عناصر نائبة للصور؛ ولا يملأ هذه العناصر بالصور.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ISmartArt smartArt = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.PictureOrganizationChart);

    presentation.save("PictureOrganizationChart.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **تحويل المخططات القديمة إلى مجموعات من الأشكال**

عند تحديث عرض تقديمي موجود، قد تحتاج إلى تحديث مخطط تنظيم تم إنشاؤه أصلاً في PowerPoint 97–2003. تمثل Aspose.Slides هذه المخططات القديمة ككائنات [ILegacyDiagram](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilegacydiagram/). استخدم [LegacyDiagram.convertToGroupShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/legacydiagram/#convertToGroupShape--) لتحويل مخطط إلى مجموعة من الأشكال حتى تتمكن من تحرير العناصر البصرية الفردية. راجع [LegacyDiagram API Reference](https://reference.aspose.com/slides/androidjava/com.aspose.slides/legacydiagram/) للحصول على التفاصيل.

يضيف التحويل مجموعة جديدة إلى مجموعة الأشكال دون حذف المخطط الأصلي. بعد التحويل الناجح، احذف الأصلي باستخدام [IShapeCollection.remove](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) لتجنب المحتوى المكرر. جمع المخططات القديمة في قائمة قبل تحويلها حتى لا يؤثر إضافة وإزالة الأشكال على التكرار.

المثال التالي يفتح عرضًا تقديميًا، يبحث في كل شريحة، يحول المخططات إلى مجموعات من الأشكال، ويحفظ العرض المحدث كملف PPTX.

```java
import com.aspose.slides.*;
import java.util.ArrayList;
import java.util.List;

Presentation presentation = new Presentation("legacy-diagrams.ppt");
try {
    for (ISlide slide : presentation.getSlides()) {
        List<ILegacyDiagram> legacyDiagrams = new ArrayList<>();
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof ILegacyDiagram) {
                legacyDiagrams.add((ILegacyDiagram) shape);
            }
        }

        for (ILegacyDiagram legacyDiagram : legacyDiagrams) {
            IGroupShape groupShape = legacyDiagram.convertToGroupShape();

            if (groupShape != null) {
                slide.getShapes().remove(legacyDiagram);
            }
        }
    }

    presentation.save("modernized.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

العرض المحفوظ يحتوي على مجموعات من الأشكال القابلة للتحرير بدلاً من المخططات القديمة المحوّلة، دون ترك أي مخططات أصلية بجانبها. افتح ملف PPTX في PowerPoint لتحرير العناصر الفردية داخل كل مجموعة، مثل النص أو التعبئة أو الموضع.

## **الأسئلة المتكررة**

**هل يدعم SmartArt انعكاس أو عكس للغات RTL؟**

نعم. الطريقة [ISmartArt.setReversed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ismartart/#setReversed-boolean-) تغير اتجاه المخطط من اليسار إلى اليمين إلى اليمين إلى اليسار، أو العكس، عندما يدعم تخطيط SmartArt المختار العكس.

**كيف يمكنني نسخ SmartArt إلى الشريحة نفسها أو إلى عرض تقديمي آخر مع الحفاظ على التنسيق؟**

يمكنك [استنساخ شكل SmartArt](/slides/ar/androidjava/shape-manipulations/) باستخدام [ShapeCollection.addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shapecollection/#addClone-com.aspose.slides.IShape-float-float-float-float-) أو [استنساخ الشريحة بأكملها](/slides/ar/androidjava/clone-slides/) التي تحتوي على SmartArt. كلا النهجين يحافظان على الحجم والموقع والتنسيق.

**كيف يمكنني تصيير SmartArt إلى صورة نقطية للمعاينة أو التصدير إلى الويب؟**

[صوّر الشريحة](/slides/ar/androidjava/convert-powerpoint-to-png/) أو العرض التقديمي بالكامل إلى PNG أو JPEG. يتم تصيير SmartArt كجزء من الشريحة.

**كيف يمكنني العثور على كائن SmartArt محدد على شريحة إذا كان هناك عدة كائنات؟**

استخدم [Shape.setAlternativeText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#setAlternativeText-java.lang.String-) أو [Shape.setName](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#setName-java.lang.String-) لتعيين نص بديل أو اسم مميز لشكل SmartArt، وابحث عن تلك القيمة في [BaseSlide.getShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseslide/#getShapes--)، ثم تحقق من أن الشكل المطابق هو [ISmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ismartart/).