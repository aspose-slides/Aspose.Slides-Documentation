---
title: استرجاع وتحديث خصائص عرض العرض التقديمي في جافا سكريبت
linktitle: خصائص العرض
type: docs
weight: 80
url: /ar/nodejs-java/presentation-view-properties/
keywords:
- خصائص العرض
- العرض العادي
- محتوى المخطط
- أيقونات المخطط
- تثبيت المقسم العمودي
- عرض واحد
- حالة الشريط
- حجم البُعد
- ضبط تلقائي
- التكبير الافتراضي
- PowerPoint
- OpenDocument
- عرض تقديمي
- Node.js
- جافا سكريبت
- Aspose.Slides
description: "استخدم Aspose.Slides for Node.js عبر Java لتكوين تخطيط العرض العادي، وتكبير الشرائح والملاحظات، وتباعد الشبكة، وإمكانية رؤية التعليقات في عروض PowerPoint."
---
## **مقدمة**

في العرض العادي لبرنامج PowerPoint، تظهر الشريحة بين لوحة جانبية للصور المصغرة أو المخطط و لوحة ملاحظات أسفلها. تُظهر Aspose.Slides for Node.js عبر Java تفضيلات التحرير المحفوظة للعرض من خلال [Presentation.getViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getViewProperties). تتضمن هذه التفضيلات تخطيط اللوحات، مستويات التكبير، تباعد الشبكة، وإظهار التعليقات.

## **حول NormalViewProperties**

استخدم [getNormalViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewproperties/#getNormalViewProperties) للوصول إلى الفئة [NormalViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/). يتحكم [setShowOutlineIcons](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#setShowOutlineIcons) في ما إذا كانت الأيقونات تظهر بجانب عناوين الشرائح في المخطط. يتيح [setSnapVerticalSplitter](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#setSnapVerticalSplitter) للوحة الجانبية أن تُقفل إلى وضعها المصغر عندما يقوم المستخدم بتقليصها. يشير [setPreferSingleView](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#setPreferSingleView) إلى تفضيل عرض لوحة واحدة في النافذة بالكامل.

يتحكم [setVerticalBarState](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#setVerticalBarState) في الفاصل بين اللوحة الجانبية والشريحة. يتحكم [setHorizontalBarState](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#setHorizontalBarState) في الفاصل فوق لوحة الملاحظات. كلاهما يقبل قيمة من [SplitterBarStateType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/splitterbarstatetype/) وهي `Minimized` أو `Maximized` أو `Restored`.

## **حول استعادة NormalViewProperties**

عند استعادة الفاصل، تُوفر [getRestoredLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#getRestoredLeft) الحجم المحفوظ للوحة الجانبية و [getRestoredTop](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#getRestoredTop) الحجم المحفوظ للمنطقة العليا من الشريحة. كلاهما يُظهر [NormalViewRestoredProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewrestoredproperties/). طريقة [setDimensionSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewrestoredproperties/#setDimensionSize) تقبل نسبة مئوية من 0 إلى 100، و [setAutoAdjust](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewrestoredproperties/#setAutoAdjust) تتحكم فيما إذا كان المحرر يضبط الحجم عند تغيير حجم النافذة.

هذا المثال يُحدّث عرضًا تقديميًا موجودًا. يستعيد الفاصل الأفقي، يضبط الحجم الذي تُعيده [getRestoredTop](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#getRestoredTop) إلى 80% مع تمكين الضبط التلقائي، ويكبر الفاصل العمودي. كما يستدعي [setShowOutlineIcons](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#setShowOutlineIcons) لعرض الأيقونات في وضع المخطط.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    const normalView = presentation.getViewProperties().getNormalViewProperties();
    normalView.setHorizontalBarState(slides.SplitterBarStateType.Restored);
    normalView.setVerticalBarState(slides.SplitterBarStateType.Maximized);
    normalView.getRestoredTop().setAutoAdjust(true);
    normalView.getRestoredTop().setDimensionSize(80);
    normalView.setShowOutlineIcons(true);

    presentation.save("presentation_normal_view_state.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **تعيين قيمة التكبير الافتراضية**

تخزن [getSlideViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewproperties/#getSlideViewProperties) و [getNotesViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewproperties/#getNotesViewProperties) إعدادات تكبير مستقلة للمحرر. هذه الإعدادات لا تؤثر على أبعاد الشريحة، تشغيل عرض الشرائح، أو دقة تصدير الصورة.

يفتح هذا المثال عرضًا تقديميًا موجودًا ويستدعي [setVariableScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commonslideviewproperties/#setVariableScale) لتلائم الشريحة مع نافذة التحرير. بالنسبة لصفحة الملاحظات، يقوم بتعطيل التحجيم التلقائي ويستدعي [setScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commonslideviewproperties/#setScale) لتعيين تكبير ثابت بنسبة 80%.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    const viewProperties = presentation.getViewProperties();
    viewProperties.getSlideViewProperties().setVariableScale(true);
    viewProperties.getNotesViewProperties().setVariableScale(false);
    viewProperties.getNotesViewProperties().setScale(80);

    presentation.save("zoom.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **تعيين تباعد الشبكة**

يحدد [setGridSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewproperties/#setGridSpacing) المسافة بين خطوط الشبكة التحريرية في كامل العرض التقديمي. يأخذ قيمة إيجابية بالنقاط، حيث يوجد 72 نقطة لكل بوصة. يطبع هذا المثال التباعد الحالي في عرض تقديمي موجود ويحفظ شبكة ربع بوصة بتعيين الفاصل إلى 18 نقطة.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    const viewProperties = presentation.getViewProperties();
    console.log("Current grid spacing: " + viewProperties.getGridSpacing() + " points");

    viewProperties.setGridSpacing(18);

    presentation.save("grid-spacing.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

تتكرر الشبكة على فاصل ثابت. [إرشادات الرسم](/slides/ar/nodejs-java/drawing-guides/) تُحدد مواضع أفقية أو عمودية فردية. كلاهما أدوات تحرير وتظهر فقط في المحررات التي تعرضها. عروض الشرائح وتصديرها إلى PDF أو صور أو SVG تتجاوزها.

## **إظهار أو إخفاء التعليقات عند فتح عرض تقديمي**

يخزّن [setShowComments](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewproperties/#setShowComments) تفضيلًا تستخدمه المحررات المتوافقة عند فتح العرض التقديمي. لعرض تقديمي موجود يحتوي على تعليقات، يطبع هذا المثال الإعداد الحالي ويحفظ نسخة مع إخفاء التعليقات. كما يستدعي [setLastView](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewproperties/#setLastView) مع [ViewType.SlideView](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewtype/#SlideView) لكي تُفتح النسخة في وضع عرض الشريحة.

```javascript
const java = require("java");
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    const viewProperties = presentation.getViewProperties();
    console.log("Current comment visibility: " + viewProperties.getShowComments());

    const hideComments = java.newByte(slides.NullableBool.False);
    viewProperties.setShowComments(hideComments);
    viewProperties.setLastView(slides.ViewType.SlideView);

    presentation.save("comments-hidden.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

إخفاء التعليقات يحافظ على نصها والمؤلفين والمواقع والردود والحالات. لتغيير التعليقات نفسها، راجع [تعليقات العرض التقديمي](/slides/ar/nodejs-java/presentation-comments/). تتحكم إعدادات التصدير فيما إذا كانت التعليقات تظهر في PDF أو HTML أو صور أو ملاحظات أو ملخصات.

## **الأسئلة الشائعة**

**لماذا تكون الشبكة مخفية عندما أعيد فتح العرض التقديمي؟**

يقوم العرض بتخزين فاصل الشبكة. لرؤية الشبكة، فعّل رؤية الشبكة في المحرر.

**هل يؤثر مسح إرشادات الرسم على تباعد الشبكة؟**

لا. إضافة أو تحريك أو مسح إرشاد لا يغيّر فاصل الشبكة.

**هل يمكن لأقسام مختلفة من العرض التقديمي أن تكون لها إعدادات عرض مختلفة؟**

لا. [Presentation.getViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getViewProperties) ينطبق على كامل العرض التقديمي.

**هل يمكنني حفظ إعدادات عرض مختلفة لمستخدمين مختلفين؟**

يحفظ الملف مجموعة واحدة من خصائص العرض للجميع. قد يطبق المحرر تفضيلات محلية للمستخدم أيضًا.

**هل يمكنني حفظ إعدادات العرض في قالب؟**

نعم. العروض التقديمية التي تُنشأ من القالب ترث إعدادات العرض المحفوظة.