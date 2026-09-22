---
title: استرجاع وتحديث خصائص عرض العرض التقديمي في JavaScript
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
- عرض منفرد
- حالة الشريط
- حجم البعد
- تعديل تلقائي
- التكبير الافتراضي
- PowerPoint
- OpenDocument
- عرض تقديمي
- Node.js
- JavaScript
- Aspose.Slides
description: "اكتشف Aspose.Slides for Node.js عبر Java لخصائص العرض لتخصيص صيغ شرائح PPT و PPTX و ODP—ضبط التخطيطات ومستويات التكبير وإعدادات العرض."
---
## **المقدمة**

يتكون العرض العادي من ثلاث مناطق محتوى: الشريحة نفسها، ومنطقة محتوى جانبية، ومنطقة محتوى سفلية. الخصائص المتعلقة بتموضع مناطق المحتوى المختلفة. تسمح هذه المعلومات للتطبيق بحفظ حالة عرضه في الملف، بحيث يكون العرض في نفس الحالة عند إعادة الفتح كما كان عندما تم حفظ العرض الأخير.

تم إضافة الطريقة [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/ViewProperties#getNormalViewProperties--) لتوفير الوصول إلى خصائص العرض العادي للعرض التقديمي. 

تم إضافة الفئات [NormalViewProperties](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/NormalViewProperties)، [NormalViewRestoredProperties](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/NormalViewRestoredProperties) والوراثيات الخاصة بها، [SplitterBarStateType](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/SplitterBarStateType) كقائمة قيم.

## **حول NormalViewProperties**

تمثل خصائص العرض العادي.

الطريقتان [getShowOutlineIcons](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/NormalViewProperties#getShowOutlineIcons--) و[setShowOutlineIcons](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/NormalViewProperties#setShowOutlineIcons-boolean-) تحددان ما إذا كان يجب على التطبيق إظهار أيقونات عند عرض محتوى المخطط التفصيلي في أي من مناطق المحتوى في وضع العرض العادي.

الطريقتان [getSnapVerticalSplitter](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/NormalViewProperties#getSnapVerticalSplitter--) و[setSnapVerticalSplitter](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/NormalViewProperties#setSnapVerticalSplitter-boolean-) تحددان ما إذا كان يجب أن ينقذب المقسم العمودي إلى حالة مصغرة عندما تكون المنطقة الجانبية صغيرة بما فيه الكفاية.

الخاصيتان [getPreferSingleView](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/NormalViewProperties#getPreferSingleView--) و[setPreferSingleView](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/NormalViewProperties#setPreferSingleView-boolean-) تحددان ما إذا كان المستخدم يفضل رؤية منطقة محتوى واحدة في نافذة كاملة بدلاً من العرض العادي القياسي الذي يحتوي على ثلاث مناطق محتوى. إذا تم تفعيلها، قد يختار التطبيق عرض إحدى مناطق المحتوى في النافذة بأكملها.

الطريقتان [getVerticalBarState](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/NormalViewProperties#getVerticalBarState--) و[getHorizontalBarState](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/NormalViewProperties#getHorizontalBarState--) تحددان الحالة التي يجب أن يظهر فيها شريط المقسم الأفقي أو العمودي. شريط المقسم الأفقي يفصل الشريحة عن منطقة المحتوى أسفل الشريحة، وشريط المقسم العمودي يفصل الشريحة عن المنطقة الجانبية. القيم المحتملة هي: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/SplitterBarStateType#Minimized)، [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/SplitterBarStateType#Maximized) و[SplitterBarStateType.Restored](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/SplitterBarStateType#Restored).

الطريقتان [getRestoredLeft](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/NormalViewProperties#getRestoredLeft--) و[getRestoredTop](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/NormalViewProperties#getRestoredTop--) تحددان حجم المنطقة العلوية أو الجانبية للشريحة في العرض العادي، عندما يتم تطبيق القيمة [SplitterBarStateType.Restored](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/SplitterBarStateType#Restored) لكلٍ من [getVerticalBarState](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/NormalViewProperties#getVerticalBarState--) و[getHorizontalBarState](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/NormalViewProperties#getHorizontalBarState--) وفقاً لذلك.

## **حول استعادة NormalViewProperties**

تحدد حجم منطقة الشريحة (العرض عندما تكون طفلاً لـ [getRestoredTop](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/NormalViewProperties#getRestoredTop--)، والارتفاع عندما تكون طفلاً لـ [getRestoredLeft](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/NormalViewProperties#getRestoredLeft--)) في العرض العادي، عندما تكون المنطقة ذات حجم مستعاد متغير (ليس مصغرة ولا مكبرة). 

الطريقة [getDimensionSize](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/NormalViewRestoredProperties#getDimensionSize--) تحدد حجم منطقة الشريحة (العرض عندما تكون طفلاً لـ restoredTop، الارتفاع عندما تكون طفلاً لـ restoredLeft).

الطريقة [getAutoAdjust](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/NormalViewRestoredProperties#getAutoAdjust--) تحدد ما إذا كان يجب أن يعوض حجم منطقة المحتوى الجانبية عن الحجم الجديد عند تغيير حجم النافذة التي تحتوي على العرض داخل التطبيق.

يوضح المثال أدناه كيفية الوصول إلى خصائص [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/ViewProperties#getNormalViewProperties--) لعرض تقديمي.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    pres.getViewProperties().getNormalViewProperties().setHorizontalBarState(aspose.slides.SplitterBarStateType.Restored);
    pres.getViewProperties().getNormalViewProperties().setVerticalBarState(aspose.slides.SplitterBarStateType.Maximized);

    // استعادة خصائص العرض للعرض التقديمي
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setAutoAdjust(true);
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setDimensionSize(80);
    pres.getViewProperties().getNormalViewProperties().setShowOutlineIcons(true);
    pres.save("presentation_normal_view_state.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **تعيين قيمة التكبير الافتراضية**

{{% alert color="info" %}} 

يدعم Aspose.Slides for Node.js via Java الآن تعيين قيمة التكبير الافتراضية للعرض التقديمي بحيث يكون التكبير محددًا مسبقًا عند فتح العرض. يمكن تحقيق ذلك عبر تعيين [ViewProperties](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/ViewProperties) للعرض التقديمي. يمكن تعيين كلٍ من [getSlideViewProperties](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/ViewProperties#getSlideViewProperties--) و[getNotesViewProperties](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/ViewProperties#getNotesViewProperties--) برمجيًا. في هذا الموضوع، سنستعرض مثالاً يوضح كيفية تعيين [View Properties](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/ViewProperties) لـ [Presentation](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation) في Aspose.Slides. 

{{% /alert %}} 

لإعداد خصائص العرض، يرجى اتباع الخطوات التالية:

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation).
1. تعيين [View Properties](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/ViewProperties) للـ [Presentation](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation).
1. حفظ العرض التقديمي كملف [PPTX](https://docs.fileformat.com/presentation/pptx/).  
   في المثال أدناه، قمنا بتعيين قيمة التكبير لعرض الشريحة وكذلك عرض الملاحظات.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    // تعيين خصائص العرض للعرض التقديمي
    presentation.getViewProperties().getSlideViewProperties().setScale(100); // قيمة التكبير بالنسب المئوية لعرض الشريحة
    presentation.getViewProperties().getNotesViewProperties().setScale(100); // قيمة التكبير بالنسب المئوية لعرض الملاحظات
    presentation.save("Zoom_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **تعيين تباعد الشبكة**

استخدم [Presentation.getViewProperties](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/#getViewProperties--) للوصول إلى إعدادات العرض على مستوى العرض التقديمي. طريقتا [ViewProperties.getGridSpacing](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/viewproperties/#getGridSpacing--) و[ViewProperties.setGridSpacing](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/viewproperties/#setGridSpacing-float-) تقرأ أو تغير الفاصل الزمني للشبكة التحريرية الأساسية. هذا الإعداد ينطبق على كامل العرض التقديمي، وليس على شريحة فردية. يُحدد تباعد الشبكة بالنقاط، حيث يساوي 72 نقطة بوصة واحدة. استخدم قيمة موجبة، وفقًا لتوثيق API.  

المثال التالي يفتح ملف `demo.pptx` موجود، يطبع تباعد الشبكة الحالي، يضع فاصل ربع بوصة، ثم يحفظ النتيجة.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("demo.pptx");
try {
    var gridSpacing = presentation.getViewProperties().getGridSpacing();
    console.log("Current grid spacing: " + gridSpacing + " points");

    presentation.getViewProperties().setGridSpacing(18);
    presentation.save("grid-spacing.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

الشبكة تختلف عن [دلالات الرسم](/slides/ar/nodejs-java/drawing-guides/). تتحكم تباعدات الشبكة في فواصل منتظمة، بينما تكون دلالات الرسم خطوط محاذاة أفقية أو عمودية موضوعة يدويًا. إضافة أو نقل أو مسح دلالات الرسم لا يغيّر تباعد الشبكة.

كلا من الشبكة ودلالات الرسم هما أدوات تحرير. لا يتم إظهارهما كجزء من محتوى الشريحة في PDF أو الصور أو SVG أو عرض الشرائح. حفظ تباعد الشبكة لا يضمن أن المحرر سيظهر الشبكة: رؤية الشبكة تعتمد أيضًا على تفضيلات المشاهد أو المحرر.

## **الأسئلة المتكررة**

**لماذا لا تكون الشبكة مرئية بعد إعادة فتح العرض التقديمي؟**

الملف يخزن تباعد الشبكة، لكن المحرر هو من يتحكم في ما إذا كانت الشبكة معروضة. تحقق من إعدادات رؤية الشبكة في المحرر.

**هل يؤدي مسح دلالات الرسم إلى تغيير تباعد الشبكة؟**

لا. دلالات الرسم وتباعد الشبكة إعدادات مستقلة. مسح الدلالات يترك الفاصل المخزن للشبكة دون تغيير.

**هل يمكنني تعيين إعدادات عرض مختلفة لأقسام مختلفة من العرض التقديمي؟**

[إعدادات العرض](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/getviewproperties/) تُعرَّف على مستوى العرض التقديمي ([Normal View](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/viewproperties/getnormalviewproperties/)/[Slide View](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/viewproperties/getslideviewproperties/))، وليست لكل قسم، لذلك يُطبق مجموعة واحدة من المعلمات على المستند كله عند الفتح.

**هل يمكنني تعريف حالات عرض مختلفة لمستخدمين مختلفين؟**

لا. تُخزن الإعدادات في الملف وتُشارك بين الجميع. قد تحترم تطبيقات العرض تفضيلات المستخدم، لكن الملف نفسه يحتوي على مجموعة واحدة من خصائص العرض.

**هل يمكنني إعداد قالب يحتوي على خصائص عرض محددة مسبقًا بحيث تفتح العروض التقديمية الجديدة بنفس الطريقة؟**

نعم. بما أن [خصائص العرض](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/getviewproperties/) تُخزن على مستوى العرض التقديمي، يمكنك تضمينها في قالب وإنشاء مستندات جديدة منه مع نفس تكوين العرض الأولي.