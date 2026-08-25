---
title: عمليات العرض التقديمي منخفضة الشيفرة في PHP
linktitle: واجهة برمجة التطبيقات منخفضة الشيفرة
type: docs
weight: 50
url: /ar/php-java/low-code-presentation-operations/
keywords:
- واجهة برمجة التطبيقات للعرض التقديمي منخفضة الشيفرة
- تحويل العرض التقديمي
- دمج العروض التقديمية
- تكرار الشرائح
- تكرار الأشكال
- تكرار النص
- جمع الأشكال
- ضغط العرض التقديمي
- إزالة شرائح الماستر غير المستخدمة
- إزالة شرائح التخطيط غير المستخدمة
- ضغط الخطوط المضمّنة
- PowerPoint
- OpenDocument
- العرض التقديمي
- PHP
- Aspose.Slides
description: "استخدام واجهة برمجة التطبيقات منخفضة الشيفرة لـ Aspose.Slides في PHP لتحويل ودمج العروض التقديمية، وتكرار المحتوى، وجمع الأشكال، وتقليل حجم العرض التقديمي."
---
## **نظرة عامة**

توفر مساحة الأسماء [aspose.slides](https://reference.aspose.com/slides/ar/php-java/aspose.slides/) فئات مساعدة ثابتة للعمليات الشائعة على العروض التقديمية. تُغلف هذه المساعدات سير عمل نموذج الكائنات المستخدم بشكل متكرر في طرق مركزة، بحيث يمكنك تحويل أو دمج الملفات، معالجة عناصر العرض التقديمي، جمع الأشكال، وإزالة المحتوى غير المستخدم بكتابة أقل.

تكون المساعدات منخفضة الشيفرة أكثر فائدة عندما ينطبق العملية على ملف أو عرض تقديمي كامل وتطابق سير العمل الافتراضي متطلباتك. استخدم نموذج الكائن الكامل لـ [Aspose.Slides object model](https://reference.aspose.com/slides/ar/php-java/aspose.slides/) عندما تحتاج إلى تحكم دقيق على الشرائح الفردية، الماسترز، التخطيطات، الأشكال، إعدادات التصدير، أو العلاقات بين عناصر العرض التقديمي.

الجدول التالي يلخص المساعدات المتوفرة:

| المساعد | الاستخدام |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/ar/php-java/aspose.slides/convert/) | تحويل عرض تقديمي إلى تنسيق آخر باستخدام استدعاء مباشر من ملف إلى ملف. |
| [Merger](https://reference.aspose.com/slides/ar/php-java/aspose.slides/merger/) | دمج ملفات عرض تقديمي كاملة ذات نفس التنسيق. |
| [ForEach_](https://reference.aspose.com/slides/ar/php-java/aspose.slides/foreach_/) | تشغيل دالة رد نداء لكل شريحة أو شكل أو فقرة أو جزء نصي. |
| [Collect](https://reference.aspose.com/slides/ar/php-java/aspose.slides/collect/) | استرجاع الأشكال من العرض التقديمي بالكامل لإعادة المعالجة أو التحليل المتكرر. |
| [Compress](https://reference.aspose.com/slides/ar/php-java/aspose.slides/compress/) | إزالة الماسترز والتخطيطات غير المستخدمة وتقليل بيانات الخط المضمّن. |

## **تحويل عرض تقديمي**

استخدم [Convert::autoByExtension](https://reference.aspose.com/slides/ar/php-java/aspose.slides/convert/#autoByExtension) عندما تكون امتداد ملف الإخراج كافياً لاختيار تنسيق التصدير. تقوم الطريقة بفتح عرض التقديمي المصدر، تحدد التنسيق المطلوب من مسار الإخراج، وتكتب النتيجة.

```php
use aspose\slides\Convert;

Convert::autoByExtension("input.pptx", "output.pdf");
```

توفر فئة [Convert](https://reference.aspose.com/slides/ar/php-java/aspose.slides/convert/) أيضاً طرقاً مخصصة لإنتاج PDF وSVG وJPEG وPNG وTIFF. استخدم نموذج الكائن الكامل عندما تحتاج إلى فحص أو تعديل العرض التقديمي قبل التصدير أو تكوين خيار تصدير غير معروض بواسطة المساعد المحدد. راجع [Convert Presentation](/slides/ar/php-java/convert-presentation/) للحصول على سير عمل وخيارات خاصة بكل تنسيق.

## **دمج العروض التقديمية**

استخدم [Merger::process](https://reference.aspose.com/slides/ar/php-java/aspose.slides/merger/#process) لدمج ملفات عرض تقديمي كاملة باستدعاء واحد. يجب أن تكون العروض التقديمية المدخلة ذات تنسيق ملف متماثل.

```php
use aspose\slides\Merger;

$inputFiles = ["part-1.pptx", "part-2.pptx"];
Merger::process($inputFiles, "merged.pptx");
```

المساعد مناسب عندما ينبغي إلحاق جميع الشرائح إلى نتيجة واحدة دون اختيارها أو إعادة تعيينها بشكل فردي. استخدم نموذج الكائن الكامل عندما تحتاج إلى دمج شرائح مختارة، تطبيق ماستر أو تخطيط وجهة، الحفاظ على الأقسام صراحة، أو توحيد أحجام الشرائح المختلفة. راجع [Merge Presentations](/slides/ar/php-java/merge-presentation/) لهذه السيناريوهات.

## **التنقل عبر عناصر العرض التقديمي**

تستدعي فئة [ForEach_](https://reference.aspose.com/slides/ar/php-java/aspose.slides/foreach_/) دالة رد نداء لكل نوع طلب من عناصر العرض التقديمي. إنها تتجنب حلقات الجمع المتداخلة وتوفر راحة في الفحص أو تغييرات التنسيق على مستوى العرض بالكامل.

المثال التالي يستخدم [ForEach_::slide](https://reference.aspose.com/slides/ar/php-java/aspose.slides/foreach_/#slide)، [ForEach_::shape](https://reference.aspose.com/slides/ar/php-java/aspose.slides/foreach_/#shape)، [ForEach_::paragraph](https://reference.aspose.com/slides/ar/php-java/aspose.slides/foreach_/#paragraph)، و[ForEach_::portion](https://reference.aspose.com/slides/ar/php-java/aspose.slides/foreach_/#portion) لفحص العناصر المقابلة:

```php
use aspose\slides\ForEach_;
use aspose\slides\Presentation;

class SlideCallback {
    public function invoke($slide, $index): void {
        $slideIndex = java_values($index);
        $shapeCount = java_values($slide->getShapes()->size());
        echo sprintf("Slide %d: %d shapes", $slideIndex, $shapeCount) . PHP_EOL;
    }
}

class ShapeCallback {
    public function invoke($shape, $slide, $index): void {
        $shapeIndex = java_values($index);
        $slideType = java_values($slide->getClass()->getSimpleName());
        $shapeName = java_values($shape->getName());
        echo sprintf("Shape %d on %s: %s", $shapeIndex, $slideType, $shapeName) . PHP_EOL;
    }
}

class ParagraphCallback {
    public function invoke($paragraph, $slide, $index): void {
        $paragraphIndex = java_values($index);
        $slideType = java_values($slide->getClass()->getSimpleName());
        $text = java_values($paragraph->getText());
        echo sprintf("Paragraph %d on %s: %s", $paragraphIndex, $slideType, $text) . PHP_EOL;
    }
}

class PortionCallback {
    public function invoke($portion, $paragraph, $slide, $index): void {
        $portionIndex = java_values($index);
        $slideType = java_values($slide->getClass()->getSimpleName());
        $text = java_values($portion->getText());
        echo sprintf("Portion %d on %s: %s", $portionIndex, $slideType, $text) . PHP_EOL;
    }
}

$presentation = new Presentation("input.pptx");
try {
    $slideCallback = java_closure(new SlideCallback(), null, java('com.aspose.slides.ForEach_$ForEachSlideCallback'));
    $shapeCallback = java_closure(new ShapeCallback(), null, java('com.aspose.slides.ForEach_$ForEachShapeCallback'));
    $paragraphCallback = java_closure(new ParagraphCallback(), null, java('com.aspose.slides.ForEach_$ForEachParagraphCallback'));
    $portionCallback = java_closure(new PortionCallback(), null, java('com.aspose.slides.ForEach_$ForEachPortionCallback'));

    ForEach_::slide($presentation, $slideCallback);
    ForEach_::shape($presentation, $shapeCallback);
    ForEach_::paragraph($presentation, $paragraphCallback);
    ForEach_::portion($presentation, $portionCallback);
} finally {
    $presentation->dispose();
}
```

بشكل افتراضي، يشمل التجوال عبر الأشكال والنصوص على مستوى العرض الشرائح العادية، والماستر، والتخطيط. يمكن للتحميلات التي تتضمن معلمة `includeNotes` معالجة شرائح الملاحظات أيضاً. استخدم حلقات الجمع المباشرة عندما تكون ترتيب التجوال أو الخروج المبكر أو التصفية قبل استدعاء رد النداء أو التحكم التفصيلي في العلاقات الأصلية- الفرعية أمرًا مهمًا.

## **جمع الأشكال**

استخدم [Collect::shapes](https://reference.aspose.com/slides/ar/php-java/aspose.slides/collect/#shapes) عندما تحتاج إلى مجموعة كل الأشكال في عرض تقديمي بدلاً من رد نداء لكل شكل. هذا مفيد عندما سيتم تصفية المجموعة نفسها أو عدّها أو معالجتها أكثر من مرة.

```php
use aspose\slides\Collect;
use aspose\slides\Presentation;

$presentation = new Presentation("input.pptx");
try {
    $shapes = Collect::shapes($presentation);

    foreach ($shapes as $shape) {
        $shapeName = java_values($shape->getName());
        $shapeType = java_values($shape->getClass()->getSimpleName());
        echo sprintf("%s: %s", $shapeName, $shapeType) . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

استخدم [ForEach_::shape](https://reference.aspose.com/slides/ar/php-java/aspose.slides/foreach_/#shape) بدلاً من ذلك عندما يمكن التعامل مع كل شكل فورًا ولا تحتاج إلى الاحتفاظ بالنتيجة المجموعة.

## **ضغط محتوى العرض التقديمي**

يمكن لفئة [Compress](https://reference.aspose.com/slides/ar/php-java/aspose.slides/compress/) إزالة العناصر الهيكلية غير المستخدمة وتقليل بيانات الخط المضمّن:

- [Compress::removeUnusedLayoutSlides](https://reference.aspose.com/slides/ar/php-java/aspose.slides/compress/#removeUnusedLayoutSlides) يزيل شرائح التخطيط التي لا تشير إليها أي شريحة عادية.
- [Compress::removeUnusedMasterSlides](https://reference.aspose.com/slides/ar/php-java/aspose.slides/compress/#removeUnusedMasterSlides) يزيل الماسترز التي لم تعد مستخدمة.
- [Compress::compressEmbeddedFonts](https://reference.aspose.com/slides/ar/php-java/aspose.slides/compress/#compressEmbeddedFonts) يزيل الأحرف غير المستخدمة من الخطوط المضمَّنة.

```php
use aspose\slides\Compress;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("input.pptx");
try {
    Compress::removeUnusedLayoutSlides($presentation);
    Compress::removeUnusedMasterSlides($presentation);
    Compress::compressEmbeddedFonts($presentation);

    $presentation->save("compressed.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

قم بإزالة التخطيطات غير المستخدمة قبل الماسترز غير المستخدمة حتى يتمكن ماستر يصبح غير مُشار إليه بعد تنظيف التخطيطات من الإزالة أيضاً. احفظ العرض التقديمي المُحسّن إلى ملف جديد إذا قد تحتاج إلى الماسترز الأصلية أو التخطيطات أو بيانات الخط المضمّن الكاملة لاحقًا. لمزيد من التفاصيل، راجع [Slide Master](/slides/ar/php-java/slide-master/) و[Embedded Font](/slides/ar/php-java/embedded-font/).

## **الأسئلة الشائعة**

**متى يجب علي استخدام واجهة برمجة التطبيقات منخفضة الشيفرة بدلاً من نموذج الكائن الكامل؟**

استخدم المساعدات منخفضة الشيفرة عندما تُطبق عملية قياسية على ملف أو عرض تقديمي كامل ولا تتطلب تحكمًا مفصلًا في العناصر الفردية. استخدم نموذج الكائن الكامل عندما تحتاج إلى اختيار شرائح معينة، التحكم في علاقات الماستر والترتيب، فحص الحالة المتوسطة، أو تكوين سلوك لا يُظهره المساعد.

**هل يمكن للمجمع (Merger) دمج العروض التقديمية ذات الصيغ المختلفة؟**

لا. يتطلب [Merger::process](https://reference.aspose.com/slides/ar/php-java/aspose.slides/merger/#process) أن تكون عروض التقديمية المدخلة بنفس الصيغة. حوِّل الملفات المدخلة إلى صيغة موحدة أولًا، على سبيل المثال باستخدام [Convert::autoByExtension](https://reference.aspose.com/slides/ar/php-java/aspose.slides/convert/#autoByExtension)، ثم دمج الملفات المحوَّلة.

**هل تعالج ForEach_ الشرائح الماستر، التخطيط، والملاحظات؟**

تقوم [ForEach_::slide](https://reference.aspose.com/slides/ar/php-java/aspose.slides/foreach_/#slide) بالتنقل عبر الشرائح العادية للعرض. تشمل عمليات [ForEach_::shape](https://reference.aspose.com/slides/ar/php-java/aspose.slides/foreach_/#shape) و[ForEach_::paragraph](https://reference.aspose.com/slides/ar/php-java/aspose.slides/foreach_/#paragraph) و[ForEach_::portion](https://reference.aspose.com/slides/ar/php-java/aspose.slides/foreach_/#portion) على مستوى العرض الشرائح العادية، والماستر، والتخطيط افتراضيًا. استخدم التحميلات التي يتضمن فيها `includeNotes` القيمة `true` لتضمين شرائح الملاحظات.

**ما الفرق بين ForEach_::shape وCollect::shapes؟**

استخدم [ForEach_::shape](https://reference.aspose.com/slides/ar/php-java/aspose.slides/foreach_/#shape) لمعالجة كل شكل فورًا عبر رد نداء. استخدم [Collect::shapes](https://reference.aspose.com/slides/ar/php-java/aspose.slides/collect/#shapes) عندما تحتاج إلى نتيجة قابلة للتكرار يمكن الاحتفاظ بها، تصفيتها، عدّها، أو اجتيازها عدة مرات.

**هل يجعل Compress دائمًا ملف العرض التقديمي أصغر؟**

ليس بالضرورة. تعتمد النتيجة على ما إذا كان العرض يحتوي على تخطيطات غير مستخدمة، ماسترز غير مستخدمة، أو خطوط مضمنة بأحرف غير مستخدمة. إذا لم يتوفر أي منها، قد لا تقلل عمليات [Compress](https://reference.aspose.com/slides/ar/php-java/aspose.slides/compress/) الحجم الفعلي للملف.

**هل يتم حفظ التغييرات التي يجريها ForEach_ أو Compress تلقائيًا؟**

لا. تعمل هذه المساعدات على كائن [Presentation](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/) المحمل في الذاكرة. بعد تعديل العناصر في رد نداء [ForEach_](https://reference.aspose.com/slides/ar/php-java/aspose.slides/foreach_) أو تشغيل [Compress](https://reference.aspose.com/slides/ar/php-java/aspose.slides/compress/)، استدعِ [Presentation::save](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/#save) لكتابة النتيجة.

## **مقالات ذات صلة**

- [تحويل عرض تقديمي](/slides/ar/php-java/convert-presentation/)
- [دمج العروض التقديمية](/slides/ar/php-java/merge-presentation/)
- [ماستر الشريحة](/slides/ar/php-java/slide-master/)
- [إدارة مربع النص](/slides/ar/php-java/manage-textbox/)
- [الخط المضمّن](/slides/ar/php-java/embedded-font/)