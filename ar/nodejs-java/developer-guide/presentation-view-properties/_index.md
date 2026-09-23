---
title: استرجاع وتحديث خصائص عرض العرض التقديمي في JavaScript
linktitle: خصائص العرض
type: docs
weight: 80
url: /ar/nodejs-java/presentation-view-properties/
keywords:
- خصائص العرض
- العرض العادي
- محتوى المخطط التفصيلي
- أيقونات المخطط التفصيلي
- قفل الفاصل العمودي
- العرض المفرد
- حالة الشريط
- حجم البُعد
- ضبط تلقائي
- تكبير افتراضي
- PowerPoint
- OpenDocument
- عرض تقديمي
- Node.js
- JavaScript
- Aspose.Slides
description: "اكتشف Aspose.Slides لـ Node.js عبر Java خصائص العرض لتخصيص صيغ شرائح PPT و PPTX و ODP — ضبط التخطيطات ومستويات التكبير وإعدادات العرض."
---
## **المقدمة**

العرض العادي يتكون من ثلاث مناطق محتوى: الشريحة نفسها، منطقة محتوى جانبية، ومنطقة محتوى سفلية. الخصائص المتعلقة بتموضع مناطق المحتوى المختلفة. تتيح هذه المعلومات للتطبيق حفظ حالة العرض إلى الملف، بحيث عند إعادة الفتح تكون الحالة نفسها كما كانت عندما تم حفظ العرض التقديمي آخر مرة.

تم إضافة الطريقة [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/ViewProperties#getNormalViewProperties--) لتوفير الوصول إلى خصائص العرض العادي للعرض التقديمي. 

تمت إضافة الفئات [NormalViewProperties](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/NormalViewProperties)، [NormalViewRestoredProperties](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/NormalViewRestoredProperties) وما يتبعها، بالإضافة إلى تعداد [SplitterBarStateType](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/SplitterBarStateType).

## **حول NormalViewProperties**

يمثل خصائص العرض العادي.

تحدد الطرق [getShowOutlineIcons](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/NormalViewProperties#getShowOutlineIcons--) و[setShowOutlineIcons](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/NormalViewProperties#setShowOutlineIcons-boolean-) ما إذا كان يجب على التطبيق إظهار الأيقونات عند عرض محتوى المخطط التفصيلي في أي من مناطق المحتوى في وضع العرض العادي.

تحدد الطرق [getSnapVerticalSplitter](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/NormalViewProperties#getSnapVerticalSplitter--) و[setSnapVerticalSplitter](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/NormalViewProperties#setSnapVerticalSplitter-boolean-) ما إذا كان الفاصل العمودي يجب أن ينكمش إلى حالة مصغرة عندما تكون المنطقة الجانبية صغيرة بما يكفي.

تحدد الخاصية [getPreferSingleView](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/NormalViewProperties#getPreferSingleView--) و[setPreferSingleView](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/NormalViewProperties#setPreferSingleView-boolean-) ما إذا كان المستخدم يفضل رؤية منطقة محتوى واحدة عبر النافذة بالكامل بدلًا من العرض العادي القياسي الذي يحتوي على ثلاث مناطق محتوى. إذا تم تمكينها، قد يختار التطبيق عرض إحدى مناطق المحتوى في النافذة بأكملها.

تحدد الطرق [getVerticalBarState](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/NormalViewProperties#getVerticalBarState--) و[getHorizontalBarState](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/NormalViewProperties#getHorizontalBarState--) الحالة التي يجب أن يُظهر فيها شريط الفاصل العمودي أو الأفقي. شريط الفاصل الأفقي يفصل الشريحة عن منطقة المحتوى أسفل الشريحة، وشريط الفاصل العمودي يفصل الشريحة عن منطقة المحتوى الجانبية. القيم الممكنة هي: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/SplitterBarStateType#Minimized)، [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/SplitterBarStateType#Maximized) و[SplitterBarStateType.Restored](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/SplitterBarStateType#Restored).

تحدد الطرق [getRestoredLeft](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/NormalViewProperties#getRestoredLeft--) و[getRestoredTop](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/NormalViewProperties#getRestoredTop--) حجم المنطقة العلوية أو الجانبية للشريحة في العرض العادي، عندما تُطبق القيمة [SplitterBarStateType.Restored](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/SplitterBarStateType#Restored) على [getVerticalBarState](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/NormalViewProperties#getVerticalBarState--) و[getHorizontalBarState](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/NormalViewProperties#getHorizontalBarState--) تبعًا لذلك.

## **حول استعادة NormalViewProperties**

تحدد حجم منطقة الشريحة (العرض عندما يكون تابعًا لـ[getRestoredTop](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/NormalViewProperties#getRestoredTop--)، الارتفاع عندما يكون تابعًا لـ[getRestoredLeft](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/NormalViewProperties#getRestoredLeft--)) في العرض العادي، عندما تكون المنطقة بحجم مستعاد متغير (ليس مصغرة ولا مكبرة).

تحدد الطريقة [getDimensionSize](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/NormalViewRestoredProperties#getDimensionSize--) حجم منطقة الشريحة (العرض عندما يكون تابعًا لـrestoredTop، الارتفاع عندما يكون تابعًا لـrestoredLeft).

تحدد الطريقة [getAutoAdjust](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/NormalViewRestoredProperties#getAutoAdjust--) ما إذا كان حجم منطقة المحتوى الجانبية يجب أن يتعوض عن الحجم الجديد عند تغيير حجم النافذة التي تحتوي على العرض داخل التطبيق.

يوضح المثال أدناه كيفية الوصول إلى خصائص [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/ViewProperties#getNormalViewProperties--) لعرض تقديمي.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    pres.getViewProperties().getNormalViewProperties().setHorizontalBarState(aspose.slides.SplitterBarStateType.Restored);
    pres.getViewProperties().getNormalViewProperties().setVerticalBarState(aspose.slides.SplitterBarStateType.Maximized);

    // استعادة خصائص عرض العرض التقديمي
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

يدعم Aspose.Slides for Node.js via Java الآن تعيين قيمة التكبير الافتراضية للعرض التقديمي بحيث يتم ضبط التكبير بالفعل عند فتح العرض. يمكن القيام بذلك عن طريق تعيين [ViewProperties](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/ViewProperties) للعرض التقديمي. يمكن تعيين كل من [getSlideViewProperties](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/ViewProperties#getSlideViewProperties--) و[getNotesViewProperties](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/ViewProperties#getNotesViewProperties--) برمجيًا. في هذا الموضوع، سنوضح بمثال كيفية تعيين [View Properties](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/ViewProperties) للـ[Presentation](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation) في Aspose.Slides.

{{% /alert %}} 

لضبط خصائص العرض، يرجى اتباع الخطوات أدناه:

1. إنشاء مثال من فئة [Presentation](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation).
1. تعيين [View Properties](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/ViewProperties) للـ[Presentation](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation).
1. كتابة العرض التقديمي كملف [PPTX](https://docs.fileformat.com/presentation/pptx/).  
   في المثال المعطى أدناه، قمنا بتعيين قيمة التكبير لكل من عرض الشريحة وعرض الملاحظات.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    // تعيين خصائص عرض العرض التقديمي
    presentation.getViewProperties().getSlideViewProperties().setScale(100); // قيمة التكبير كنسبة مئوية لعرض الشريحة
    presentation.getViewProperties().getNotesViewProperties().setScale(100); // قيمة التكبير كنسبة مئوية لعرض الملاحظات
    presentation.save("Zoom_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **تعيين تباعد الشبكة**

استخدم [Presentation.getViewProperties](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/#getViewProperties--) للوصول إلى إعدادات العرض على مستوى العرض التقديمي. تقرأ أو تغير الطرق [ViewProperties.getGridSpacing](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/viewproperties/#getGridSpacing--) و[ViewProperties.setGridSpacing](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/viewproperties/#setGridSpacing-float-) الفاصل الزمني للشبكة التحريرية الأساسية. ينطبق هذا الإعداد على العرض التقديمي بأكمله، وليس على شريحة فردية. يُحدد تباعد الشبكة بالنقاط، حيث يساوي 72 نقطة بوصة واحدة. استخدم قيمة موجبة كما هو مطلوب في وثائق API.

يفتح المثال التالي ملف `demo.pptx` الموجود، يطبع تباعد الشبكة الحالي، يضبط فاصل ربع بوصة، ثم يحفظ النتيجة.

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

الشبكة مختلفة عن [drawing guides](/slides/ar/nodejs-java/drawing-guides/). يتحكم تباعد الشبكة في فاصل منتظم، بينما الأدلة الرسومية هي خطوط محاذاة أفقية أو عمودية موضوعة بشكل فردي. إضافة أو نقل أو مسح الأدلة الرسومية لا يغيّر تباعد الشبكة.

كل من الشبكة والأدلة الرسومية أدوات تحريرية. لا تُعرض كمحتوى شريحة في PDF أو صور أو SVG أو عرض شرائح. تخزين تباعد الشبكة لا يضمن أن المحرر سيظهر الشبكة: رؤيتها تعتمد أيضًا على تفضيلات المشاهد أو المحرر.

## **إظهار أو إخفاء التعليقات عند فتح عرض تقديمي**

استخدم [Presentation.getViewProperties](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/#getViewProperties--) للوصول إلى إعدادات العرض على مستوى العرض التقديمي. استخدم [ViewProperties.getShowComments](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/viewproperties/#getShowComments--) و[ViewProperties.setShowComments](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/viewproperties/#setShowComments-byte-) لقراءة أو تغيير التفضيل المخزن لما إذا كان يجب إظهار التعليقات عند فتح العرض التقديمي في PowerPoint أو محرر متوافق آخر.

هذه الإعدادات تتحكم فقط في تفضيل العرض المخزن. لا تضيف، ولا تزيل، ولا تعدل، ولا تحلّ التعليقات. إخفاء التعليقات يحافظ على محتواها ومؤلفيها ومواقعها والردود والحالات. راجع [Presentation Comments](/slides/ar/nodejs-java/presentation-comments/) للعمليات التي تغير التعليقات نفسها.

المثال التالي يتطلب وجود `comments.pptx` يحتوي على تعليقات. يطبع إعداد الرؤية الحالي، يطلب إخفاء التعليقات، ويحفظ ملف PPTX جديد دون إزالة أي تعليقات. يستخدم أيضًا [ViewProperties.setLastView](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/viewproperties/#setLastView-int-) مع [ViewType.SlideView](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/viewtype/#SlideView) لضبط طريقة التحرير الأولية إلى جانب رؤية التعليقات.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new aspose.slides.Presentation("comments.pptx");
try {
    var showComments = presentation.getViewProperties().getShowComments();
    console.log("Current comment visibility: " + showComments);

    var hideComments = java.newByte(aspose.slides.NullableBool.False);
    presentation.getViewProperties().setShowComments(hideComments);
    presentation.getViewProperties().setLastView(aspose.slides.ViewType.SlideView);
    presentation.save("comments-hidden.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

هذه الإعدادات لا تحدد ما إذا كانت التعليقات مُضمنة في تصدير PDF أو HTML أو صورة أو ملاحظات أو نشرة. اضبط الخيارات الخاصة بالتصدير ذات الصلة بشكل منفصل.

## **FAQ**

**لماذا لا تكون الشبكة مرئية بعد إعادة فتح العرض التقديمي؟**

الملف يخزن تباعد الشبكة، لكن المحرر هو من يتحكم فيما إذا كانت الشبكة تُعرض. تحقق من إعدادات رؤية الشبكة في المحرر.

**هل يغيّر مسح الأدلة الرسومية تباعد الشبكة؟**

لا. الأدلة الرسومية وتباعد الشبكة إعدادات مستقلة. مسح الأدلة يترك الفاصل المخزن للشبكة دون تغيير.

**هل يمكنني ضبط إعدادات عرض مختلفة لأقسام مختلفة من العرض التقديمي؟**

[إعدادات العرض](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/getviewproperties/) تُحدد على مستوى العرض التقديمي ([Normal View](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/viewproperties/getnormalviewproperties/)/[Slide View](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/viewproperties/getslideviewproperties/))، ليست لكل قسم، لذا مجموعة واحدة من المعلمات تُطبق على المستند بأكمله عند الفتح.

**هل يمكنني تحديد حالات عرض مختلفة لمستخدمين مختلفين مسبقًا؟**

لا. الإعدادات مخزنة في الملف وتُشارك. قد تلتزم تطبيقات العرض بتفضيلات المستخدم، لكن الملف نفسه يحتوي على مجموعة واحدة من خصائص العرض.

**هل يمكنني إعداد قالب يحتوي على خصائص عرض مسبقة بحيث تفتح العروض الجديدة بنفس الطريقة؟**

نعم. بما أن [خصائص العرض](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/getviewproperties/) تُخزن على مستوى العرض التقديمي، يمكنك تضمينها في قالب وإنشاء مستندات جديدة منه بنفس تكوين العرض الأولي.