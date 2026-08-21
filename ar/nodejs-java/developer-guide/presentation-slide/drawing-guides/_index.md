---
title: إدارة أدلة الرسم في العروض التقديمية في جافا سكريبت
linktitle: أدلة الرسم
type: docs
weight: 85
url: /ar/nodejs-java/drawing-guides/
keywords:
- دليل رسم
- دليل أفقي
- دليل عمودي
- دليل محاذاة
- عرض الشريحة
- شريحة رئيسية
- شريحة تخطيط
- قالب ملاحظات
- قالب نشرة
- PowerPoint
- عرض تقديمي
- Node.js
- JavaScript
- Aspose.Slides
description: "إضافة، وصول، ومسح أدلة الرسم الأفقية والعمودية في عروض PowerPoint التقديمية باستخدام Aspose.Slides لـ Node.js عبر Java."
---
## **نظرة عامة**

تعد خطوط الأدلة القابلة للتعديل أفقية وعمودية تساعد المستخدمين على محاذاة الأشكال بشكل ثابت أثناء تحرير عرض تقديمي في PowerPoint. تكون مفيدة بشكل خاص عندما يولد تطبيق عرضًا تقديميًا سيُصقَل يدويًا لاحقًا: يمكن للتطبيق حفظ نفس أدوات المحاذاة التي يجب على المؤلفين اتباعها عند إضافة أو نقل المحتوى.

تُعد خطوط الأدلة أدوات تحرير، ليست محتوىً للشرائح. لا تظهر في عرض الشرائح أو في المخرجات المُصدرة. يُظهر Aspose.Slides for Node.js عبر Java هذه الأدلة من خلال الفئة [DrawingGuidesCollection](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/drawingguidescollection/) . تمثل دليلًا الفئة [DrawingGuide](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/drawingguide/) وتحتوي على اتجاه، وموقع، ولون.

يُقاس الموضع بالنقاط من الزاوية العليا اليسرى للشرائح أو القالب ذات الصلة. يستخدم الدليل العمودي إحداثيًا أفقيًا، عادةً بين الصفر وعرض الشريحة. يستخدم الدليل الأفقي إحداثيًا عموديًا، عادةً بين الصفر وارتفاع الشريحة.

## **إضافة أدلة إلى عرض الشريحة**

استخدم [CommonSlideViewProperties.getDrawingGuides](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/commonslideviewproperties/#getDrawingGuides) لإدارة الأدلة المعروضة أثناء تحرير الشرائح العادية. استدعِ [DrawingGuidesCollection.add](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/drawingguidescollection/#add) مع قيمة [Orientation](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/orientation/) وموقع بالنقاط.

المثال التالي يضيف دليلًا عموديًا واحدًا إلى يمين مركز الشريحة ودليلًا أفقيًا أسفله:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const slideSize = presentation.getSlideSize().getSize();
    const guides = presentation.getViewProperties().getSlideViewProperties().getDrawingGuides();

    guides.add(slides.Orientation.Vertical, slideSize.getWidth() / 2 + 12.5);
    guides.add(slides.Orientation.Horizontal, slideSize.getHeight() / 2 + 12.5);

    presentation.save("drawing-guides.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **الوصول إلى أدلة الرسم**

توفر طُرُق [DrawingGuidesCollection.getCount](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/drawingguidescollection/#getCount) و[DrawingGuidesCollection.get_Item](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/drawingguidescollection/#get_Item) إمكانية الوصول إلى الأدلة الموجودة. تُعيد طُرُق [DrawingGuide.getOrientation](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/drawingguide/#getOrientation)، [DrawingGuide.getPosition](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/drawingguide/#getPosition)، و[DrawingGuide.getColor](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/drawingguide/#getColor) قيمًا يمكن أيضًا تعديلها عبر طرق الضبط المقابلة.

المثال التالي يقرأ أدلة عرض الشريحة من العرض التقديمي الذي تم إنشاؤه أعلاه:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("drawing-guides.pptx");
try {
    const guides = presentation.getViewProperties().getSlideViewProperties().getDrawingGuides();

    for (let index = 0; index < guides.getCount(); index++) {
        const guide = guides.get_Item(index);
        console.log("Guide " + index + ": orientation = " + guide.getOrientation() + ", position = " + guide.getPosition() + ", color = " + guide.getColor());
    }
} finally {
    presentation.dispose();
}
```

## **إضافة أدلة إلى الشرائح الرئيسية وتخطيطات الشرائح**

يمكن للقالب الرئيسي للشرائح وكل من تخطيطاتها أن يمتلك مجموعات أدلة الرسم الخاصة به. استخدم [MasterSlide.getDrawingGuides](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/masterslide/#getDrawingGuides) للقالب الرئيسي و[LayoutSlide.getDrawingGuides](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/layoutslide/#getDrawingGuides) لتخطيط الشريحة.

المثال التالي يضيف دليلًا عموديًا إلى أول شريحة رئيسية ودليلًا أفقيًا إلى أول شريحة تخطيط:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const slideSize = presentation.getSlideSize().getSize();
    const masterGuides = presentation.getMasters().get_Item(0).getDrawingGuides();
    const layoutGuides = presentation.getLayoutSlides().get_Item(0).getDrawingGuides();

    masterGuides.add(slides.Orientation.Vertical, slideSize.getWidth() / 2 - 20);
    layoutGuides.add(slides.Orientation.Horizontal, slideSize.getHeight() / 2 + 20);

    presentation.save("master-layout-drawing-guides.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **إضافة أدلة إلى القوالب الملاحظات والنشرات**

تدعم القوالب الملاحظات والقوالب النشرات أيضًا أدلة الرسم. استخدم [MasterNotesSlide.getDrawingGuides](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/masternotesslide/#getDrawingGuides) و[MasterHandoutSlide.getDrawingGuides](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/masterhandoutslide/#getDrawingGuides) للوصول إلى مجموعاتهما. إذا لم يحتوي العرض التقديمي على أحد هذه القوالب، فإن `MasterNotesSlideManager.setDefaultMasterNotesSlide` أو `MasterHandoutSlideManager.setDefaultMasterHandoutSlide` ينشئ القالب الافتراضي ويعيده.

المثال التالي يضيف دليلًا أفقيًا إلى قالب الملاحظات ودليلًا عموديًا إلى قالب النشرة:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const notesSize = presentation.getNotesSize().getSize();
    const notesMaster = presentation.getMasterNotesSlideManager().setDefaultMasterNotesSlide();
    const handoutMaster = presentation.getMasterHandoutSlideManager().setDefaultMasterHandoutSlide();

    notesMaster.getDrawingGuides().add(slides.Orientation.Horizontal, notesSize.getHeight() / 2 + 50);
    handoutMaster.getDrawingGuides().add(slides.Orientation.Vertical, notesSize.getWidth() / 2 - 50);

    presentation.save("notes-handout-drawing-guides.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **مسح أدلة الرسم**

استدعِ [DrawingGuidesCollection.clear](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/drawingguidescollection/#clear) لإزالة جميع الأدلة من مجموعة معينة. مسح مجموعة واحدة لا يؤثر على الأدلة المخزنة في نطاق آخر.

المثال التالي يمسح أدلة عرض الشريحة وجميع الأدلة على القوالب الرئيسية، وتخطيطات الشرائح، وقالب الملاحظات، وقالب النشرة دون إنشاء القوالب المفقودة:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("presentation-with-guides.pptx");
try {
    presentation.getViewProperties().getSlideViewProperties().getDrawingGuides().clear();

    for (let index = 0; index < presentation.getMasters().size(); index++) {
        presentation.getMasters().get_Item(index).getDrawingGuides().clear();
    }

    for (let index = 0; index < presentation.getLayoutSlides().size(); index++) {
        presentation.getLayoutSlides().get_Item(index).getDrawingGuides().clear();
    }

    const notesMaster = presentation.getMasterNotesSlideManager().getMasterNotesSlide();
    if (notesMaster !== null) {
        notesMaster.getDrawingGuides().clear();
    }

    const handoutMaster = presentation.getMasterHandoutSlideManager().getMasterHandoutSlide();
    if (handoutMaster !== null) {
        handoutMaster.getDrawingGuides().clear();
    }

    presentation.save("presentation-without-guides.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **الأسئلة المتكررة**

**هل تظهر أدلة الرسم في عرض الشرائح أو الصور المصدرة؟**

لا. أدلة الرسم هي أدوات محاذاة للتحرير ولا تُعرض كجزء من محتوى العرض التقديمي.

**هل يمكن إضافة دليل رسم مباشرةً إلى شريحة عادية فردية؟**

تُخزن أدلة تحرير الشرائح العادية في خصائص عرض الشرائح الخاصة بالعرض التقديمي. تتوفر مجموعات أدلة منفصلة للقوالب الرئيسية، وتخطيطات الشرائح، وقوالب الملاحظات، وقوالب النشرات.

**ما هي الوحدات المستخدمة لمواقع الأدلة؟**

يُحدد الموضع بالنقاط، حيث 72 نقطة تساوي بوصة واحدة. تُقاس المواقع العمودية من الحافة اليسرى، وتُقاس المواقع الأفقية من الحافة العليا.

**هل يؤدي مسح أدلة الرسم إلى إزالة الأشكال أو تغيير محتوى الشريحة؟**

لا. تُزيل طريقة [DrawingGuidesCollection.clear](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/drawingguidescollection/#clear) فقط الأدلة في المجموعة المحددة. تبقى الأشكال ومحتوى الشريحة الآخر دون تغيير.