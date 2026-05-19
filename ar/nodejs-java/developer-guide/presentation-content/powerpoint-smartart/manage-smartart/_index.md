---
title: إدارة SmartArt في عروض PowerPoint التقديمية باستخدام JavaScript
linktitle: إدارة SmartArt
type: docs
weight: 10
url: /ar/nodejs-java/manage-smartart/
keywords:
- SmartArt
- نص SmartArt
- نوع التخطيط
- الخاصية المخفية
- مخطط المنظمة
- مخطط المنظمة بالصورة
- PowerPoint
- عرض تقديمي
- Node.js
- JavaScript
- Aspose.Slides
description: "تعلم كيفية إنشاء وتحرير SmartArt في PowerPoint باستخدام Aspose.Slides للـ Node.js باستخدام أمثلة شفرة JavaScript واضحة تُسرِّع تصميم الشرائح والأتمتة."
---
## **نظرة عامة**

SmartArt هو مخطط PowerPoint مكوّن من العقد وأشكال العقد وتخطيط. باستخدام Aspose.Slides للـ Node.js عبر Java، يمكنك إنشاء SmartArt، قراءة النص من عقده، تغيير تخطيطه، فحص العقد المخفية، تكوين تخطيطات مخطط المنظمة، وإنشاء مخططات منظمة بالصور.

## **الحصول على نص من كائن SmartArt**

يمكن لعقدة SmartArt أن تحتوي على شكل واحد أو أكثر. لقراءة النص الظاهر، تنقّ عبر [SmartArt.getAllNodes](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/smartart/#getAllNodes--), ثم اقرأ [TextFrame](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/textframe/) الذي تُعيده [SmartArtShape.getTextFrame](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/smartartshape/#getTextFrame--).

```javascript
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().get_Item(0);

    if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
        let smartArt = shape;
        let nodes = smartArt.getAllNodes();

        for (let nodeIndex = 0; nodeIndex < nodes.size(); nodeIndex++) {
            let node = nodes.get_Item(nodeIndex);
            let nodeShapes = node.getShapes();

            for (let shapeIndex = 0; shapeIndex < nodeShapes.size(); shapeIndex++) {
                let nodeShape = nodeShapes.get_Item(shapeIndex);

                if (nodeShape.getTextFrame() != null) {
                    console.log(nodeShape.getTextFrame().getText());
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **تغيير نوع التخطيط لكائن SmartArt**

يتحكم تخطيط SmartArt في طريقة ترتيب العقد وربطها. المثال التالي ينشئ كائن SmartArt باستخدام قيمة [SmartArtLayoutType](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/smartartlayouttype/) `BasicBlockList`، يغيّرها إلى القيمة `BasicProcess`، ويحفظ العرض التقديمي.

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let smartArt = presentation.getSlides().get_Item(0).getShapes().addSmartArt(
        10, 10, 400, 300, aspose.slides.SmartArtLayoutType.BasicBlockList);

    smartArt.setLayout(aspose.slides.SmartArtLayoutType.BasicProcess);

    presentation.save("ChangeSmartArtLayout_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **التحقق مما إذا كانت عقدة SmartArt مخفية**

[SmartArtNode.isHidden](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/smartartnode/ishidden/) يشير إلى ما إذا كانت العقدة مخفية في نموذج بيانات SmartArt. يمكن أن توجد عقد مخفية في البنية حتى عندما لا يعرض التخطيط المختارها كعناصر مخطط مرئية.

المثال التالي يضيف عقدة إلى كائن SmartArt يستخدم قيمة [SmartArtLayoutType](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/smartartlayouttype/) `RadialCycle` ويتحقق من حالة إخفاء العقدة.

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let smartArt = presentation.getSlides().get_Item(0).getShapes().addSmartArt(
        10, 10, 400, 300, aspose.slides.SmartArtLayoutType.RadialCycle);

    let node = smartArt.getAllNodes().addNode();
    let isHidden = node.isHidden();

    if (isHidden) {
        console.log("The node is hidden in the SmartArt data model.");
    }

    presentation.save("CheckSmartArtHiddenProperty_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **الحصول على تخطيط مخطط المنظمة أو ضبطه**

بالنسبة لمخططات SmartArt التي تستخدم تخطيط مخطط المنظمة، تُحدد [SmartArtNode.getOrganizationChartLayout](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/smartartnode/#getOrganizationChartLayout--) و[SmartArtNode.setOrganizationChartLayout](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/smartartnode/#setOrganizationChartLayout-int-) طريقة ترتيب العقد الفرعية تحت عقدة أصلية. على سبيل المثال، يمكنك ضبط العقد الفرعية لتُعلّق من اليسار أو اليمين أو كلا الجانبين، اعتمادًا على [OrganizationChartLayoutType](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/organizationchartlayouttype/) المختار.

المثال التالي يُنشئ مخطط منظمة ويضبط التخطيط للعقدة الأولى إلى قيمة [OrganizationChartLayoutType](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/organizationchartlayouttype/) `LeftHanging`.

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let smartArt = presentation.getSlides().get_Item(0).getShapes().addSmartArt(
        10, 10, 400, 300, aspose.slides.SmartArtLayoutType.OrganizationChart);

    let rootNode = smartArt.getNodes().get_Item(0);
    rootNode.setOrganizationChartLayout(aspose.slides.OrganizationChartLayoutType.LeftHanging);

    presentation.save("OrganizationChartLayout_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **إنشاء مخطط منظمة بصورة**

مخطط المنظمة بالصورة هو تخطيط SmartArt مصمم لمخططات الهيكل الهرمي التي تتضمن نواقل صور. استخدم قيمة [SmartArtLayoutType](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/smartartlayouttype/) `PictureOrganizationChart` عند إضافة كائن SmartArt إلى شريحة.

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let smartArt = presentation.getSlides().get_Item(0).getShapes().addSmartArt(
        0, 0, 400, 400, aspose.slides.SmartArtLayoutType.PictureOrganizationChart);

    presentation.save("PictureOrganizationChart_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **الأسئلة الشائعة**

**هل يدعم SmartArt عكس أو انعكاس للغات من اليمين إلى اليسار؟**

نعم. طريقة [SmartArt.setReversed](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/smartart/setreversed/) تغير اتجاه المخطط من اليسار إلى اليمين إلى اليمين إلى اليسار، أو العكس، عندما يدعم التخطيط المختار عكس الاتجاه.

**كيف يمكنني نسخ SmartArt إلى الشريحة نفسها أو إلى عرض تقديمي آخر مع الحفاظ على التنسيق؟**

يمكنك [استنساخ شكل SmartArt](/slides/ar/nodejs-java/shape-manipulations/) باستخدام [ShapeCollection.addClone](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/shapecollection/addclone/) أو [استنساخ الشريحة بالكامل](/slides/ar/nodejs-java/clone-slides/) التي تحتوي على SmartArt. كلا الطريقتين تحافظان على الحجم والموقع والتنسيق.

**كيف أقوم بتصوير SmartArt إلى صورة نقطية للمعاودة أو لتصدير الويب؟**

[Render the slide](/slides/ar/nodejs-java/convert-powerpoint-to-png/) أو العرض التقديمي بالكامل إلى PNG أو JPEG. يتم تصوير SmartArt كجزء من الشريحة.

**كيف يمكنني العثور على كائن SmartArt معين على شريحة إذا كان هناك عدة كائنات؟**

عيّن نصًا بديلًا مميزًا باستخدام [Shape.setAlternativeText](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/shape/setalternativetext/) أو اسمًا مميزًا باستخدام [Shape.setName](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/shape/setname/) على شكل SmartArt، ابحث عن تلك القيمة في [BaseSlide.getShapes](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/baseslide/#getShapes)، ثم تحقّق من أن الشكل المطابق هو [SmartArt](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/smartart/).