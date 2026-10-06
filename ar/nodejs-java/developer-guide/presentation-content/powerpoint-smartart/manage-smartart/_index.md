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
- خاصية مخفية
- مخطط المنظمة
- مخطط المنظمة بالصور
- PowerPoint
- عرض تقديمي
- Node.js
- JavaScript
- Aspose.Slides
description: "تعلم كيفية بناء وتعديل SmartArt في PowerPoint باستخدام Aspose.Slides لـ Node.js عبر أمثلة شفرة JavaScript واضحة تُسرّع تصميم الشرائح والأتمتة."
---
## **نظرة عامة**

SmartArt هو مخطط PowerPoint يتكون من العقد وأشكال العقد وتخطيط. باستخدام Aspose.Slides لـ Node.js عبر Java ، يمكنك إنشاء SmartArt ، قراءة النص من عقده ، تغيير التخطيط الخاص به ، فحص العقد المخفية ، تهيئة تخطيطات مخططات المنظمة ، وإنشاء مخططات منظمة بالصور.

## **الحصول على النص من كائن SmartArt**

يمكن أن يحتوي عقدة SmartArt على شكل واحد أو أكثر. لقراءة النص من أشكال العقدة ، قم بالتكرار عبر [SmartArt.getAllNodes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartart/getallnodes/)، ثم اقرأ [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) الذي تُعيده [SmartArtShape.getTextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartartshape/gettextframe/).

يتطلب المثال عرضًا تقديميًا يحتوي على شريحة واحدة على الأقل وكائن SmartArt كأول شكل في تلك الشريحة. يقوم بطباعة كل إطار نص متاح إلى وحدة التحكم.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

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
    } else {
        console.log("The first shape is not a SmartArt object.");
    }
} finally {
    presentation.dispose();
}
```

## **تغيير نوع التخطيط لكائن SmartArt**

يتحكم تخطيط SmartArt في كيفية ترتيب العقد وربطها. المثال التالي يخلق كائن SmartArt باستخدام قيمة [SmartArtLayoutType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartartlayouttype/) `BasicBlockList`، ويغيّره إلى قيمة `BasicProcess`، ثم يحفظ العرض التقديمي. الموضع والحجم الممرران إلى [ShapeCollection.addSmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addsmartart/) يُقاسان بالنقاط. استخدم [SmartArt.setLayout](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartart/setlayout/) لتغيير التخطيط.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let smartArt = slide.getShapes().addSmartArt(10, 10, 400, 300, aspose.slides.SmartArtLayoutType.BasicBlockList);
    smartArt.setLayout(aspose.slides.SmartArtLayoutType.BasicProcess);

    presentation.save("ChangeSmartArtLayout.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **التحقق مما إذا كانت عقدة SmartArt مخفية**

[SmartArtNode.isHidden](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartartnode/ishidden/) يشير إلى ما إذا كانت العقدة مخفية في نموذج بيانات SmartArt. يمكن أن توجد العقد المخفية في البنية حتى عندما لا يعرض التخطيط المختارها كعناصر مخطط مرئية.

المثال التالي يضيف عقدة إلى كائن SmartArt يستخدم قيمة [SmartArtLayoutType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartartlayouttype/) `RadialCycle` ويتحقق من حالة إخفاء العقدة المضافة. يطبع رسالة إذا كانت العقدة مخفية ويحفظ المخطط.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let smartArt = slide.getShapes().addSmartArt(10, 10, 400, 300, aspose.slides.SmartArtLayoutType.RadialCycle);
    let node = smartArt.getAllNodes().addNode();
    let isHidden = node.isHidden();

    if (isHidden) {
        console.log("The node is hidden in the SmartArt data model.");
    }

    presentation.save("CheckSmartArtHiddenProperty.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **الحصول على أو تعيين تخطيط مخطط المنظمة**

بالنسبة لمخططات SmartArt التي تستخدم تخطيط مخطط المنظمة، تُحدد [SmartArtNode.getOrganizationChartLayout](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartartnode/getorganizationchartlayout/) و[SmartArtNode.setOrganizationChartLayout](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartartnode/setorganizationchartlayout/) كيفية ترتيب العقد الفرعية تحت عقدة أصلية. على سبيل المثال، يمكنك تعيين العقد الفرعية لتعلق من اليسار أو اليمين أو كلاً الطرفين، اعتمادًا على [OrganizationChartLayoutType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/organizationchartlayouttype/) المختار.

المثال التالي يخلق مخطط منظمة ويعين التخطيط للعقدة الأولى إلى قيمة [OrganizationChartLayoutType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/organizationchartlayouttype/) `LeftHanging`. الفهرس الصفري `0` يختار أول عقدة من المستوى العلوي؛ تستخدم عقدها الفرعية الترتيب المحدد. ثم يُحفظ العرض التقديمي المعدَّل.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let smartArt = slide.getShapes().addSmartArt(10, 10, 400, 300, aspose.slides.SmartArtLayoutType.OrganizationChart);
    let rootNode = smartArt.getNodes().get_Item(0);
    rootNode.setOrganizationChartLayout(aspose.slides.OrganizationChartLayoutType.LeftHanging);

    presentation.save("OrganizationChartLayout.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **إنشاء مخطط منظمة بالصور**

مخطط منظمة بالصور هو تخطيط SmartArt مصمم لمخططات التسلسل الهرمي التي تتضمن عناصر نائبة للصور. استخدم قيمة [SmartArtLayoutType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartartlayouttype/) `PictureOrganizationChart` عند إضافة كائن SmartArt إلى شريحة. هذا المثال يحفظ مخططًا بعناصر نائبة للصور؛ لا يملأ العناصر النائبة بالصور.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let smartArt = slide.getShapes().addSmartArt(0, 0, 400, 400, aspose.slides.SmartArtLayoutType.PictureOrganizationChart);

    presentation.save("PictureOrganizationChart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **تحويل المخططات القديمة إلى مجموعات من الأشكال**

عند تحديث عرض تقديمي موجود، قد تحتاج إلى تحديث مخطط منظمة تم إنشاؤه أصلاً في PowerPoint 97–2003. تمثل Aspose.Slides هذه المخططات القديمة ككائنات [LegacyDiagram](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legacydiagram/). استخدم [LegacyDiagram.convertToGroupShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legacydiagram/converttogroupshape/) لتحويل مخطط إلى مجموعة من الأشكال حتى يمكنك تحرير العناصر البصرية الفردية. راجع [LegacyDiagram API Reference](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legacydiagram/) للمزيد من التفاصيل.

يضيف التحويل مجموعة جديدة إلى مجموعة الأشكال دون إزالة المخطط الأصلي. بعد التحويل الناجح، أزل الأصلي باستخدام [ShapeCollection.remove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/remove/) لتجنب المحتوى المكرر. اجمع المخططات القديمة في قائمة قبل تحويلها حتى لا يؤثر إضافة وإزالة الأشكال على عملية التكرار.

المثال التالي يفتح عرضًا تقديميًا، يبحث في كل شريحة، يحول المخططات إلى مجموعات من الأشكال، ويحفظ العرض التقديمي المحدث كملف PPTX.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("legacy-diagrams.ppt");
try {
    let slides = presentation.getSlides();
    for (let slideIndex = 0; slideIndex < slides.size(); slideIndex++) {
        let slide = slides.get_Item(slideIndex);
        let shapes = slide.getShapes();
        let legacyDiagrams = [];
        for (let shapeIndex = 0; shapeIndex < shapes.size(); shapeIndex++) {
            let shape = shapes.get_Item(shapeIndex);
            if (java.instanceOf(shape, "com.aspose.slides.ILegacyDiagram")) {
                legacyDiagrams.push(shape);
            }
        }

        for (let legacyDiagram of legacyDiagrams) {
            let groupShape = legacyDiagram.convertToGroupShape();

            if (groupShape != null) {
                shapes.remove(legacyDiagram);
            }
        }
    }

    presentation.save("modernized.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

العرض التقديمي المحفوظ يحتوي على مجموعات قابلة للتحرير من الأشكال بدلاً من المخططات القديمة المحوّلة، دون بقاء المخططات الأصلية بجانبها. افتح ملف PPTX في PowerPoint لتحرير العناصر الفردية داخل كل مجموعة، مثل النص أو التعبئة أو الموضع.

## **الأسئلة الشائعة**

**هل يدعم SmartArt المرآة أو العكس للغات من اليمين إلى اليسار؟**

نعم. طريقة [SmartArt.setReversed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartart/setreversed/) تبدّل اتجاه المخطط من اليسار إلى اليمين إلى اليمين إلى اليسار، أو العكس، عندما يدعم التخطيط المختار الانعكاس.

**كيف يمكنني نسخ SmartArt إلى نفس الشريحة أو إلى عرض تقديمي آخر مع الحفاظ على التنسيق؟**

يمكنك [نسخ شكل SmartArt](/slides/ar/nodejs-java/shape-manipulations/) باستخدام [ShapeCollection.addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addclone/) أو [نسخ الشريحة بالكامل](/slides/ar/nodejs-java/clone-slides/) التي تحتوي على SmartArt. كلا الطريقتين تحافظان على الحجم والموقع والتنسيق.

**كيف أقوم بتصيير SmartArt إلى صورة نقطية للمعاينة أو تصدير الويب؟**

[تصيير الشريحة](/slides/ar/nodejs-java/convert-powerpoint-to-png/) أو العرض التقديمي بالكامل إلى PNG أو JPEG. يُصير SmartArt كجزء من الشريحة.

**كيف يمكنني العثور على كائن SmartArt محدد في شريحة إذا كان هناك عدة؟**

استخدم [Shape.setAlternativeText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/setalternativetext/) أو [Shape.setName](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/setname/) لتعيين نص بديل مميز أو اسم لشكل SmartArt، وابحث عن تلك القيمة في [BaseSlide.getShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseslide/#getShapes)، ثم تحقق من أن الشكل المطابق هو [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartart/).