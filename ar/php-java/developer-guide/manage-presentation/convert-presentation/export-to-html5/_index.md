---
title: تحويل العروض التقديمية إلى HTML5 باستخدام PHP
linktitle: العرض التقديمي إلى HTML5
type: docs
weight: 40
url: /ar/php-java/export-to-html5/
keywords:
- PowerPoint إلى HTML5
- OpenDocument إلى HTML5
- العرض التقديمي إلى HTML5
- الشريحة إلى HTML5
- PPT إلى HTML5
- PPTX إلى HTML5
- ODP إلى HTML5
- حفظ PPT كـ HTML5
- حفظ PPTX كـ HTML5
- حفظ ODP كـ HTML5
- تصدير PPT إلى HTML5
- تصدير PPTX إلى HTML5
- تصدير ODP إلى HTML5
- PHP
- Aspose.Slides
description: "تصدير عروض PowerPoint وOpenDocument إلى HTML5 متجاوب باستخدام Aspose.Slides لـ PHP عبر Java. الحفاظ على التنسيق، الرسوم المتحركة، والتفاعل."
---
## **نظرة عامة**

تشرح هذه المقالة كيفية تحويل عروض PowerPoint إلى HTML5 باستخدام Aspose.Slides لـ PHP عبر Java. تغطي التصدير الأساسي، والتحكم في تحريكات الأشكال وانتقالات الشرائح، وتخطيط التعليقات. كما تقارن ناتج HTML5 مع الناتج المستند إلى SVG للتصدير القياسي إلى HTML.

## **تصدير PowerPoint إلى HTML5**

المثال التالي يحمِّل عرضًا تقديميًا من دليل العمل ويحفظه بتنسيق HTML5. يستخدم الإعدادات الافتراضية للتصدير؛ المثال التالي يوضح كيفية التحكم في تشغيل الرسوم المتحركة بشكل صريح. استبدل مسار الإدخال بالمسار إلى عرضك التقديمي.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("pres.pptx");
try {
    $presentation->save("pres.html", SaveFormat::Html5);
} finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Note" %}}
بالإضافة إلى مستند HTML، يكتب التصدير ملفات CSS وJavaScript الداعمة لتنسيق الشرائح، الرسوم المتحركة، التأثيرات، والتنقل. احتفظ بهذه الملفات مع مستند HTML عند نقل أو نشر النتيجة. كما أن الصفحة المُولَّدة تقوم بتحميل jQuery وAnime.js من شبكات CDN العامة؛ بدونهما لا يعمل تنقل الشرائح ولا الرسوم المتحركة.
{{% /alert %}}

لتصدير دون تشغيل تحريك الأشكال أو انتقالات الشرائح، مرّر القيمة `false` إلى [setAnimateShapes](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/#setAnimateShapes) و[setAnimateTransitions](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/#setAnimateTransitions) في [Html5Options](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/). هذه الإعدادات مستقلة، لذا يمكنك تمكين واحدة وتعطيل الأخرى. يُصدّر المثال العرض التقديمي مع تعطيل كلا النوعين من الرسوم المتحركة في الصفحة المُولَّدة.

```php
use aspose\slides\Html5Options;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$html5Options = new Html5Options();
$html5Options->setAnimateShapes(false);
$html5Options->setAnimateTransitions(false);

$presentation = new Presentation("pres.pptx");
try {
    $presentation->save("pres5.html", SaveFormat::Html5, $html5Options);
} finally {
    $presentation->dispose();
}
```

## **تصدير PowerPoint إلى HTML**

يستخدم تصدير HTML القياسي نهجًا مختلفًا في العرض: يتم تمثيل محتوى الشريحة بواسطة SVG داخل صفحة HTML. المثال التالي يحوِّل عرضًا تقديميًا إلى مستند HTML باستخدام هذا النهج.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("pres.pptx");
try {
    $presentation->save("pres.html", SaveFormat::Html);
} finally {
    $presentation->dispose();
}
```

الترميز المبسط أدناه يوضح بنية الصفحة المُولَّدة. عنصر SVG يحتوي على محتوى الشريحة المرسوم؛ نص العنصر النائب يمثل ذلك المحتوى وليس ناتج تصدير حرفي.

```html
<body>
<div class="slide" name="slide" id="slideslideIface1">
     <svg version="1.1">
         <g> THE SLIDE CONTENT GOES HERE </g>
     </svg>
</div>
</body>
```

{{% alert title="Warning" color="warning" %}}
التصدير المستند إلى SVG لا يكشف عن أشكال PowerPoint كعناصر HTML منفصلة. استخدم تصدير HTML5 عندما تحتاج إلى خيارات تحريك الأشكال وانتقالات الشرائح الموضحة في هذه المقالة.
{{% /alert %}}

## **تصدير PowerPoint إلى عرض شرائح HTML5**

يُنتج تصدير HTML5 صفحة لعرض وتنقل شرائح العرض التقديمي في المتصفح. يفعّل هذا المثال كلًا من [setAnimateShapes](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/#setAnimateShapes) و[setAnimateTransitions](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/#setAnimateTransitions) حتى يتمكن عرض الشرائح المُصدَّر من تشغيل التأثيرات من العرض الأصلي.

استخدم عرضًا تقديميًا يحتوي مسبقًا على تحركات الأشكال وانتقالات الشرائح لرؤية تأثير هذه الإعدادات. تمكينها لا يضيف تأثيرات جديدة إلى الشرائح التي لا تحتوي على أي منها. بعد التصدير، افتح المستند HTML5 المُولَّد في متصفح مع توفر ملفاته الداعمة.

```php
use aspose\slides\Html5Options;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$html5Options = new Html5Options();
$html5Options->setAnimateShapes(true);
$html5Options->setAnimateTransitions(true);

$presentation = new Presentation("pres.pptx");
try {
    $presentation->save("HTML5-slide-view.html", SaveFormat::Html5, $html5Options);
} finally {
    $presentation->dispose();
}
```

## **تحويل عرض تقديمي إلى مستند HTML5 مع التعليقات**

يمكنك تضمين التعليقات الموجودة على الشرائح في ناتج HTML5 بحيث يتمكن القرّاء من رؤية الملاحظات بجانب محتوى الشريحة. المثال في هذا القسم يفترض أن العرض الأصلي يحتوي على تعليقات، كما هو موضح أدناه. يُصدّر تلك التعليقات؛ ولا ينشئ تعليقات جديدة.

![تعليقان على شريحة العرض](two_comments_pptx.png)

مرّر كائن [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/php-java/aspose.slides/notescommentslayoutingoptions/) إلى طريقة [setSlidesLayoutOptions](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/#setSlidesLayoutOptions) من [Html5Options](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/). استخدم [setCommentsPosition](https://reference.aspose.com/slides/php-java/aspose.slides/notescommentslayoutingoptions/#setCommentsPosition) لتحديد `Right` من تعداد [CommentsPositions](https://reference.aspose.com/slides/php-java/aspose.slides/commentspositions/) لوضع التعليقات إلى يمين كل شريحة.

المثال التالي يصدر العرض التقديمي إلى HTML5 مع تخطيط التعليقات هذا. العرض التقديمي بدون تعليقات لن يحتوي على نص تعليق للعرض.

```php
use aspose\slides\CommentsPositions;
use aspose\slides\Html5Options;
use aspose\slides\NotesCommentsLayoutingOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$layoutOptions = new NotesCommentsLayoutingOptions();
$layoutOptions->setCommentsPosition(CommentsPositions::Right);

$html5Options = new Html5Options();
$html5Options->setSlidesLayoutOptions($layoutOptions);

$presentation = new Presentation("sample.pptx");
try {
    $presentation->save("output.html", SaveFormat::Html5, $html5Options);
} finally {
    $presentation->dispose();
}
```

![التعليقات في مستند HTML5 الناتج](two_comments_html5.png)

## **استبعاد الروابط التشعبية JavaScript أثناء التصدير**

افترض أن الملف `hyperlinks.pptx` يحتوي على نص مرتبط بوجهة `javascript:alert('Hello')` ورابط عادي `https://example.com/`. لاستبعاد الرابط التشعبي JavaScript أثناء التصدير، مرّر القيمة `true` إلى [SaveOptions::setSkipJavaScriptLinks](https://reference.aspose.com/slides/php-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks). القيمة الافتراضية هي `false`، لذا لا يتم تصفية هذه الروابط إلا إذا فعلت الخيار.

المثال التالي يحمِّل العرض التقديمي من دليل العمل ويصدّره باستخدام [Html5Options](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/):

```php
use aspose\slides\Html5Options;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$html5Options = new Html5Options();
$html5Options->setSkipJavaScriptLinks(true);

$presentation = new Presentation("hyperlinks.pptx");
try {
    $presentation->save("filtered-html5.html", SaveFormat::Html5, $html5Options);
} finally {
    $presentation->dispose();
}
```

يستثني الملف المُصدَّر الرابط التشعبي JavaScript مع الحفاظ على نصه والرابط HTTPS العادي. لا يتغير العرض التقديمي الأصلي.

هذا الخيار يفلتر الروابط التشعبية JavaScript؛ لا يزيل جميع السكريبتات أو المحتوى النشط الآخر، ولا يضمن التوافق مع CSP. على سبيل المثال، لا يزال ناتج HTML5 يتضمن سكريبتات لتنقل الشرائح والرسوم المتحركة.

## **الأسئلة الشائعة**

**هل يمكنني التحكم فيما إذا كانت تحريكات الكائنات وانتقالات الشرائح ستُشغَّل في HTML5؟**

نعم، يوفر تصدير HTML5 خيارات منفصلة لتمكين أو تعطيل [تحريكات الشكل](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/#setAnimateShapes) و[انتقالات الشرائح](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/#setAnimateTransitions).

**هل يتم دعم التعليقات، وأين يمكن وضعها بالنسبة إلى الشريحة؟**

نعم، يمكن تضمين التعليقات الموجودة في ناتج HTML5 وتحديد موقعها (على سبيل المثال، إلى يمين الشريحة) من خلال [إعدادات التخطيط](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/#setSlidesLayoutOptions) للملاحظات والتعليقات.

**هل يمكنني تخطي الروابط التي تستدعي JavaScript لأسباب أمنية أو متعلقة بـ CSP؟**

نعم، يسمح لك إعداد [setSkipJavaScriptLinks](https://reference.aspose.com/slides/php-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks) بتخطي الروابط التشعبية التي تستدعي JavaScript أثناء الحفظ. القيمة الافتراضية هي `false`. انظر إلى [استبعاد الروابط التشعبية JavaScript أثناء التصدير](/slides/ar/php-java/export-to-html5/#exclude-javascript-hyperlinks-during-export) للحصول على مثال لتصدير HTML5 ونطاق الفلتر. لا يقوم هذا الإعداد بإزالة JavaScript المستخدم من قبل عارض HTML5 للتنقل والرسوم المتحركة.