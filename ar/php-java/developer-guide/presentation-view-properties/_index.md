---
title: استرجاع وتحديث خصائص عرض العرض التقديمي في PHP
linktitle: خصائص العرض
type: docs
weight: 80
url: /ar/php-java/presentation-view-properties/
keywords:
- خصائص العرض
- العرض العادي
- محتوى المخطط
- أيقونات المخطط
- تثبيت المقسم العمودي
- عرض فردي
- حالة الشريط
- حجم البُعد
- ضبط تلقائي
- التكبير الافتراضي
- PowerPoint
- OpenDocument
- عرض تقديمي
- PHP
- Aspose.Slides
description: "اكتشف خصائص عرض Aspose.Slides للـ PHP عبر Java لتخصيص صيغ شرائح PPT و PPTX و ODP — ضبط التخطيطات ومستويات التكبير وإعدادات العرض."
---
## **المقدمة**

العرض العادي يتكون من ثلاث مناطق محتوى: الشريحة نفسها، منطقة محتوى جانبية، ومنطقة محتوى سفلية. الخصائص المتعلقة بوضعية المناطق المختلفة للمحتوى. تسمح هذه المعلومات للتطبيق بحفظ حالة العرض إلى الملف، بحيث عند إعادة الفتح يكون العرض في نفس الحالة كما كان عندما تم حفظ العرض التقديمي آخر مرة.

تمت إضافة الطريقة [ViewProperties::getNormalViewProperties](https://reference.aspose.com/slides/ar/php-java/aspose.slides/ViewProperties/#getNormalViewProperties) لتوفير الوصول إلى خصائص العرض العادي للعرض التقديمي.  

تمت إضافة الفئات [NormalViewProperties](https://reference.aspose.com/slides/ar/php-java/aspose.slides/NormalViewProperties)، [NormalViewRestoredProperties](https://reference.aspose.com/slides/ar/php-java/aspose.slides/NormalViewRestoredProperties) وفروعها، والعدد [SplitterBarStateType](https://reference.aspose.com/slides/ar/php-java/aspose.slides/SplitterBarStateType) enum.

## **حول INormalViewProperties**

يمثل خصائص العرض العادي.

الطريقة [getShowOutlineIcons](https://reference.aspose.com/slides/ar/php-java/aspose.slides/NormalViewProperties/#getShowOutlineIcons) والطريقة [setShowOutlineIcons](https://reference.aspose.com/slides/ar/php-java/aspose.slides/NormalViewProperties/#setShowOutlineIcons) تحددان ما إذا كان يجب على التطبيق إظهار الأيقونات عند عرض محتوى المخطط التفصيلي في أي من مناطق المحتوى في وضع العرض العادي.

الطريقة [getSnapVerticalSplitter](https://reference.aspose.com/slides/ar/php-java/aspose.slides/NormalViewProperties/#getSnapVerticalSplitter) والطريقة [setSnapVerticalSplitter](https://reference.aspose.com/slides/ar/php-java/aspose.slides/NormalViewProperties/#setSnapVerticalSplitter) تحددان ما إذا كان يجب أن ينتقل المقسم العمودي إلى حالة مصغرة عندما تكون المنطقة الجانبية صغيرة بما فيه الكفاية.

الخاصية [getPreferSingleView](https://reference.aspose.com/slides/ar/php-java/aspose.slides/NormalViewProperties/#getPreferSingleView) والطريقة [setPreferSingleView](https://reference.aspose.com/slides/ar/php-java/aspose.slides/NormalViewProperties/#setPreferSingleView) تحددان ما إذا كان يفضل المستخدم رؤية منطقة محتوى واحدة تغطي كامل النافذة بدلاً من العرض العادي القياسي الذي يحتوي على ثلاث مناطق محتوى. إذا تم تمكينها، قد يختار التطبيق عرض إحدى مناطق المحتوى في النافذة بالكامل.

الطريقة [getVerticalBarState](https://reference.aspose.com/slides/ar/php-java/aspose.slides/NormalViewProperties/#getVerticalBarState) والطريقة [getHorizontalBarState](https://reference.aspose.com/slides/ar/php-java/aspose.slides/NormalViewProperties/#getHorizontalBarState) تحددان الحالة التي يجب أن يظهر بها شريط المقسم العمودي أو الأفقي. شريط المقسم الأفقي يفصل الشريحة عن منطقة المحتوى أسفل الشريحة، وشريط المقسم العمودي يفصل الشريحة عن منطقة المحتوى الجانبية. القيم الممكنة هي: [SplitterBarStateType::Minimized](https://reference.aspose.com/slides/ar/php-java/aspose.slides/SplitterBarStateType/#Minimized)، [SplitterBarStateType::Maximized](https://reference.aspose.com/slides/ar/php-java/aspose.slides/SplitterBarStateType/#Maximized) و[SplitterBarStateType::Restored](https://reference.aspose.com/slides/ar/php-java/aspose.slides/SplitterBarStateType/#Restored).

الطريقة [getRestoredLeft](https://reference.aspose.com/slides/ar/php-java/aspose.slides/NormalViewProperties/#getRestoredLeft) والطريقة [getRestoredTop](https://reference.aspose.com/slides/ar/php-java/aspose.slides/NormalViewProperties#getRestoredTop) تحددان حجم المنطقة العلوية أو الجانبية للشريحة في العرض العادي عندما تُطبق القيمة [SplitterBarStateType::Restored](https://reference.aspose.com/slides/ar/php-java/aspose.slides/SplitterBarStateType/#Restored) على [getVerticalBarState](https://reference.aspose.com/slides/ar/php-java/aspose.slides/NormalViewProperties/#getVerticalBarState) و[getHorizontalBarState](https://reference.aspose.com/slides/ar/php-java/aspose.slides/NormalViewProperties/#getHorizontalBarState) وفقاً لذلك.

## **حول Restoring INormalViewProperties**

تحدد حجم منطقة الشريحة (العرض عندما تكون ابنًا لـ [getRestoredTop](https://reference.aspose.com/slides/ar/php-java/aspose.slides/NormalViewProperties/#getRestoredTop)، الارتفاع عندما تكون ابنًا لـ [getRestoredLeft](https://reference.aspose.com/slides/ar/php-java/aspose.slides/NormalViewProperties/#getRestoredLeft)) في العرض العادي، عندما تكون المنطقة ذات حجم مستعاد متغيّر (ليس مصغّرًا ولا مكبرًا).

الطريقة [getDimensionSize](https://reference.aspose.com/slides/ar/php-java/aspose.slides/NormalViewRestoredProperties/#getDimensionSize) تحدد حجم منطقة الشريحة (العرض عندما تكون ابنًا لـ restoredTop، الارتفاع عندما تكون ابنًا لـ restoredLeft).

الطريقة [getAutoAdjust](https://reference.aspose.com/slides/ar/php-java/aspose.slides/NormalViewRestoredProperties/#getAutoAdjust) تحدد ما إذا كان يجب أن تعوض منطقة المحتوى الجانبية عن الحجم الجديد عند تغيير حجم النافذة التي تحتوي على العرض داخل التطبيق.

يُظهر المثال أدناه كيفية الوصول إلى خصائص [ViewProperties::getNormalViewProperties](https://reference.aspose.com/slides/ar/php-java/aspose.slides/ViewProperties/#getNormalViewProperties) لعرض تقديمي.

```php
  $pres = new Presentation();
  try {
    $pres->getViewProperties()->getNormalViewProperties()->setHorizontalBarState(SplitterBarStateType::Restored);
    $pres->getViewProperties()->getNormalViewProperties()->setVerticalBarState(SplitterBarStateType::Maximized);

    # استعادة خصائص العرض للعرض التقديمي
    $pres->getViewProperties()->getNormalViewProperties()->getRestoredTop()->setAutoAdjust(true);
    $pres->getViewProperties()->getNormalViewProperties()->getRestoredTop()->setDimensionSize(80);
    $pres->getViewProperties()->getNormalViewProperties()->setShowOutlineIcons(true);
    $pres->save("presentation_normal_view_state.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **تعيين قيمة التكبير الافتراضية**
{{% alert color="info" %}} 

يدعم Aspose.Slides للـ PHP عبر Java الآن تعيين قيمة التكبير الافتراضية للعرض التقديمي بحيث يتم تعيين التكبير مسبقًا عند فتح العرض. يمكن تحقيق ذلك عن طريق تعيين [ViewProperties](https://reference.aspose.com/slides/ar/php-java/aspose.slides/ViewProperties) للعرض التقديمي. يمكن تعيين [getSlideViewProperties](https://reference.aspose.com/slides/ar/php-java/aspose.slides/ViewProperties/#getSlideViewProperties) وكذلك [getNotesViewProperties](https://reference.aspose.com/slides/ar/php-java/aspose.slides/ViewProperties/#getNotesViewProperties) برمجيًا. في هذا الموضوع، سنستعرض مثالًا يوضح كيفية تعيين [View Properties](https://reference.aspose.com/slides/ar/php-java/aspose.slides/ViewProperties) للـ [Presentation](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation) في Aspose.Slides.

{{% /alert %}} 

للتعيين، يرجى اتباع الخطوات التالية:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation).
1. تعيين [View Properties](https://reference.aspose.com/slides/ar/php-java/aspose.slides/ViewProperties) للـ [Presentation](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation).
1. كتابة العرض التقديمي كملف [PPTX](https://docs.fileformat.com/presentation/pptx/).  
   في المثال أدناه، قمنا بتعيين قيمة التكبير لكل من عرض الشريحة وعرض الملاحظات.

```php
  $presentation = new Presentation();
  try {
    # تعيين خصائص العرض للعرض التقديمي
    $presentation->getViewProperties()->getSlideViewProperties()->setScale(100); // قيمة التكبير بالنسب المئوية لعرض الشريحة
    $presentation->getViewProperties()->getNotesViewProperties()->setScale(100); // قيمة التكبير بالنسب المئوية لعرض الملاحظات

    $presentation->save("Zoom_out.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```

## **تعيين تباعد الشبكة**

استخدم [Presentation::getViewProperties](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/#getViewProperties) للوصول إلى إعدادات العرض على مستوى العرض التقديمي. تقرأ الطريقة [ViewProperties::getGridSpacing](https://reference.aspose.com/slides/ar/php-java/aspose.slides/viewproperties/#getGridSpacing) أو تغير الفاصل الزمني للشبكة التحريرية الأساسية. هذا الإعداد يُطبق على كامل العرض التقديمي، وليس على شريحة فردية. يُحدد تباعد الشبكة بالنقاط، حيث يساوي 72 نقطة بوصة واحدة. استخدم قيمة موجبة كما هو موضح في وثائق API.

المثال التالي يفتح ملف `demo.pptx` موجود، يطبع تباعد الشبكة الحالي، يعيّن فاصل ربع بوصة، ثم يحفظ النتيجة.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("demo.pptx");
try {
    $gridSpacing = $presentation->getViewProperties()->getGridSpacing();
    echo "Current grid spacing: " . $gridSpacing . " points\n";

    $presentation->getViewProperties()->setGridSpacing(18.0);
    $presentation->save("grid-spacing.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

الشبكة تختلف عن [drawing guides](/slides/ar/php-java/drawing-guides/). يتحكم تباعد الشبكة في فاصل منتظم، بينما الأدلة الرسومية هي خطوط محاذاة أفقية أو عمودية موضوعة بشكل فردي. إضافة أو نقل أو مسح الأدلة الرسومية لا يغيّر تباعد الشبكة.

كلا من الشبكة والأدلة الرسومية هما أدوات تحرير. لا يتم عرضهما كمحتوى شريحة في PDF أو صور أو SVG أو عرض شرائح. تخزين تباعد الشبكة لا يضمن أن يعرض المحرر الشبكة: فالرؤية تعتمد أيضًا على تفضيلات المشاهد أو المحرر.

## **إظهار أو إخفاء التعليقات عند فتح العرض التقديمي**

استخدم [Presentation::getViewProperties](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/getviewproperties/) للوصول إلى إعدادات العرض على مستوى العرض التقديمي. استخدم [ViewProperties::getShowComments](https://reference.aspose.com/slides/ar/php-java/aspose.slides/viewproperties/getshowcomments/) و[ViewProperties::setShowComments](https://reference.aspose.com/slides/ar/php-java/aspose.slides/viewproperties/setshowcomments/) لقراءة أو تغيير التفضيل المخزن بشأن ما إذا كان يجب إظهار التعليقات عند فتح العرض التقديمي في PowerPoint أو محرر متوافق آخر.

هذا الإعداد يتحكم فقط في تفضيل العرض المخزن. لا يضيف، لا يزيل، لا يحرر، ولا يحل التعليقات. إخفاء التعليقات يحافظ على محتواها، مؤلفيها، مواضعها، ردودها، وحالاتها. راجع [Presentation Comments](/slides/ar/php-java/presentation-comments/) للعمليات التي تغير التعليقات نفسها.

المثال التالي يتطلب وجود ملف `comments.pptx` يحتوي على تعليقات. يطبع إعداد الرؤية الحالي، يطلب إخفاء التعليقات، ويحفظ ملف PPTX جديد دون إزالة أي تعليقات. كما يستخدم [ViewProperties::setLastView](https://reference.aspose.com/slides/ar/php-java/aspose.slides/viewproperties/setlastview/) مع [ViewType::SlideView](https://reference.aspose.com/slides/ar/php-java/aspose.slides/viewtype/#SlideView) لتكوين عرض التحرير الأولي جنبًا إلى جنب مع رؤية التعليقات.

```php
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ViewType;

$presentation = new Presentation("comments.pptx");
try {
    $showComments = $presentation->getViewProperties()->getShowComments();
    echo "Current comment visibility: " . java_values($showComments) . PHP_EOL;

    $presentation->getViewProperties()->setShowComments(NullableBool::False);
    $presentation->getViewProperties()->setLastView(ViewType::SlideView);
    $presentation->save("comments-hidden.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

هذا الإعداد لا يحدد ما إذا كانت التعليقات مشمولة في تصديرات PDF أو HTML أو صورة أو ملاحظات أو نشرة. قم بتكوين الخيارات المحددة للتصدير بشكل منفصل.

## **الأسئلة الشائعة**

**لماذا لا تكون الشبكة مرئية بعد إعادة فتح العرض التقديمي؟**  
الملف يخزن تباعد الشبكة، ولكن المحرر يتحكم فيما إذا كانت الشبكة مُعروضة. راجع إعدادات رؤية الشبكة في المحرر.

**هل يؤدي مسح الأدلة الرسومية إلى تغيير تباعد الشبكة؟**  
لا. الأدلة الرسومية وتباعد الشبكة إعدادات مستقلة. مسح الأدلة يترك الفاصل الزمني المخزن للشبكة دون تغيير.

**هل يمكنني تعيين إعدادات عرض مختلفة لأقسام مختلفة من العرض التقديمي؟**  
[إعدادات العرض](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/getviewproperties/) تُعرّف على مستوى العرض التقديمي ([Normal View](https://reference.aspose.com/slides/ar/php-java/aspose.slides/viewproperties/getnormalviewproperties/)/[Slide View](https://reference.aspose.com/slides/ar/php-java/aspose.slides/viewproperties/getslideviewproperties/))، وليس لكل قسم، لذا مجموعة واحدة من المعلمات تنطبق على المستند بالكامل عند فتحه.

**هل يمكنني تعريف حالات عرض مسبقة لمستخدمين مختلفين؟**  
لا. تُخزن الإعدادات في الملف وتُشارك بين الجميع. قد تRespect تطبيقات المشاهدة تفضيلات المستخدم، لكن الملف نفسه يحتوي على مجموعة واحدة من خصائص العرض.

**هل يمكنني إعداد قالب يحتوي على خصائص عرض مُعرّفة مسبقًا بحيث تُفتح العروض التقديمية الجديدة بنفس الطريقة؟**  
نعم. لأن [خصائص العرض](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/getviewproperties/) تُخزن على مستوى العرض التقديمي، يمكنك تضمينها في قالب وإنشاء مستندات جديدة منه مع نفس تكوين العرض الأولي.