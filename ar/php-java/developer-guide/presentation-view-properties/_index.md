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
- تقسيم عمودي قابل للضغط
- عرض منفرد
- حالة الشريط
- حجم البُعد
- تعديل تلقائي
- تكبير افتراضي
- PowerPoint
- OpenDocument
- عرض تقديمي
- PHP
- Aspose.Slides
description: "استخدم Aspose.Slides لـ PHP عبر Java لتكوين تخطيط العرض العادي، وتكبير الشريحة والملاحظات، وتباعد الشبكة، وإظهار التعليقات في عروض PowerPoint التقديمية."
---
## **المقدمة**

في طريقة العرض العادية لـ PowerPoint، تظهر الشريحة بين جزء جانبي للصور المصغرة أو المخطط وجانب الملاحظات أسفلها. Aspose.Slides for PHP عبر Java يكشف عن تفضيلات التحرير المحفوظة للعرض من خلال [Presentation::getViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getviewproperties/). تشمل هذه تخطيط الجزء، مستويات التكبير، تباعد الشبكة، وإظهار التعليقات.

## **حول NormalViewProperties**

استخدم [getNormalViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/viewproperties/getnormalviewproperties/) للوصول إلى فئة [NormalViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/). يتحكم [setShowOutlineIcons](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/setshowoutlineicons/) فيما إذا كانت الأيقونات تظهر بجوار عناوين الشرائح في المخطط. يتيح [setSnapVerticalSplitter](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/setsnapverticalsplitter/) للجزء الجانبي الانتقال إلى حالة التصغير عندما يقلل المستخدم حجمه. يشير [setPreferSingleView](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/setprefersingleview/) إلى تفضيل عرض جزء واحد في النافذة الكاملة.

[setVerticalBarState](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/setverticalbarstate/) يتحكم في الفاصل بين الجزء الجانبي والشريحة. [setHorizontalBarState](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/sethorizontalbarstate/) يتحكم في الفاصل أعلى جزء الملاحظات. كلاهما يقبل قيمة من نوع [SplitterBarStateType](https://reference.aspose.com/slides/php-java/aspose.slides/splitterbarstatetype/) هي `Minimized` أو `Maximized` أو `Restored`.

## **حول استعادة NormalViewProperties**

عند استعادة الفاصل، توفر [getRestoredLeft](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/getrestoredleft/) حجم الجزء الجانبي المحفوظ وتوفر [getRestoredTop](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/getrestoredtop/) حجم المنطقة العليا للشريحة المحفوظ. كلاهما يُظهر [NormalViewRestoredProperties](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewrestoredproperties/). طريقة [setDimensionSize](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewrestoredproperties/setdimensionsize/) تقبل نسبة مئوية من 0 إلى 100، و[setAutoAdjust](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewrestoredproperties/setautoadjust/) يتحكم فيما إذا كان المحرر يضبط الحجم عند تغيير حجم النافذة.

يُحدّث هذا المثال عرضًا تقديميًا موجودًا. يستعيد الفاصل الأفقي، يضبط الحجم الذي تُرجعه [getRestoredTop](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/getrestoredtop/) إلى 80٪ مع تمكين التعديل التلقائي، ويُعظم الفاصل العمودي. كما يستدعي [setShowOutlineIcons](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/setshowoutlineicons/) لعرض الأيقونات في عرض المخطط.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SplitterBarStateType;

$presentation = new Presentation("demo.pptx");
try {
    $normalView = $presentation->getViewProperties()->getNormalViewProperties();
    $normalView->setHorizontalBarState(SplitterBarStateType::Restored);
    $normalView->setVerticalBarState(SplitterBarStateType::Maximized);
    $normalView->getRestoredTop()->setAutoAdjust(true);
    $normalView->getRestoredTop()->setDimensionSize(80);
    $normalView->setShowOutlineIcons(true);

    $presentation->save("presentation_normal_view_state.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **تعيين قيمة التكبير الافتراضية**

يخزن كل من [getSlideViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/viewproperties/getslideviewproperties/) و[getNotesViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/viewproperties/getnotesviewproperties/) إعدادات تكبير مستقلة للمحرر. هذه الإعدادات لا تؤثر على أبعاد الشريحة، تشغيل العرض التقديمي، أو دقة تصدير الصورة.

يفتح هذا المثال عرضًا تقديميًا موجودًا ويستدعي [setVariableScale](https://reference.aspose.com/slides/php-java/aspose.slides/commonslideviewproperties/setvariablescale/) لضبط الشريحة لتناسب نافذة التحرير. لصفحة الملاحظات، يُعطل التحجيم التلقائي ويستدعي [setScale](https://reference.aspose.com/slides/php-java/aspose.slides/commonslideviewproperties/setscale/) لضبط تكبير ثابت بنسبة 80٪.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("demo.pptx");
try {
    $viewProperties = $presentation->getViewProperties();
    $viewProperties->getSlideViewProperties()->setVariableScale(true);
    $viewProperties->getNotesViewProperties()->setVariableScale(false);
    $viewProperties->getNotesViewProperties()->setScale(80);

    $presentation->save("zoom.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **تحديد تباعد الشبكة**

طريقة `setGridSpacing` في فئة [ViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/viewproperties/) تحدد المسافة بين خطوط الشبكة أثناء التحرير في جميع أنحاء العرض التقديمي. تأخذ قيمة موجبة بالنقاط، مع 72 نقطة لكل بوصة. يطبع هذا المثال التباعد الحالي في عرض تقديمي موجود ويخزن شبكة بربع بوصة عبر ضبط الفاصل إلى 18 نقطة.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("demo.pptx");
try {
    $viewProperties = $presentation->getViewProperties();
    echo "Current grid spacing: " . java_values($viewProperties->getGridSpacing()) . " points" . PHP_EOL;

    $viewProperties->setGridSpacing(18.0);
    
    $presentation->save("grid-spacing.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

تتكرر الشبكة على فاصل ثابت. [Drawing guides](/slides/ar/php-java/drawing-guides/) تُظهر مواضع أفقية أو رأسية فردية. كلاهما أدوات مساعدة في التحرير وتظهر فقط في المحررات التي تعرضها. لا تظهر في عروض الشرائح أو عند التصدير إلى PDF أو صور أو SVG.

## **إظهار أو إخفاء التعليقات عند فتح العرض التقديمي**

[setShowComments](https://reference.aspose.com/slides/php-java/aspose.slides/viewproperties/setshowcomments/) يخزن تفضيلًا يستخدمه المحررات المتوافقة عند فتح العرض التقديمي. لعرض تقديمي موجود يحتوي على تعليقات، يطبع هذا المثال الإعداد الحالي ويحفظ نسخة مع إخفاء التعليقات. كما يستدعي [setLastView](https://reference.aspose.com/slides/php-java/aspose.slides/viewproperties/setlastview/) مع [ViewType::SlideView](https://reference.aspose.com/slides/php-java/aspose.slides/viewtype/#SlideView) لكي تُفتح النسخة في وضع الشريحة.

```php
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ViewType;

$presentation = new Presentation("comments.pptx");
try {
    $viewProperties = $presentation->getViewProperties();
    echo "Current comment visibility: " . java_values($viewProperties->getShowComments()) . PHP_EOL;

    $viewProperties->setShowComments(NullableBool::False);
    $viewProperties->setLastView(ViewType::SlideView);

    $presentation->save("comments-hidden.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

إخفاء التعليقات يحافظ على نصها، مؤلفيها، مواقعها، ردودها، وحالاتها. لتغيير التعليقات نفسها، راجع [Presentation Comments](/slides/ar/php-java/presentation-comments/). تتحكم إعدادات التصدير فيما إذا كانت التعليقات تظهر في PDF أو HTML أو صور أو ملاحظات أو نماذج توزيع.

## **الأسئلة المتكررة**

**لماذا تكون الشبكة مخفية عند إعادة فتح العرض التقديمي؟**  
يخزن العرض التقديمي فاصل الشبكة. لعرض الشبكة، فعّل رؤيتها في المحرر.

**هل تغيير الأدلة المرسومة يغيّر تباعد الشبكة؟**  
لا. إضافة دليل أو تحريكه أو مسحه لا يغيّر فاصل الشبكة.

**هل يمكن لأقسام مختلفة من العرض التقديمي أن تكون لها إعدادات عرض مختلفة؟**  
لا. [Presentation::getViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getviewproperties/) ينطبق على العرض التقديمي بأكمله.

**هل يمكنني حفظ إعدادات عرض مختلفة لمستخدمين مختلفين؟**  
يحفظ الملف مجموعة واحدة من خصائص العرض للجميع. قد يطبق المحرر أيضًا تفضيلات محلية للمستخدم.

**هل يمكنني حفظ إعدادات العرض في قالب؟**  
نعم. العروض التقديمية التي تُنشأ من القالب ترث إعدادات العرض المحفوظة.