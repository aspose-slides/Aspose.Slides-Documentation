---
title: عمليات عرض تقديمي منخفضة الشيفرة في PHP
linktitle: واجهة برمجة التطبيقات منخفضة الشيفرة
type: docs
weight: 50
url: /ar/php-java/low-code-presentation-operations/
keywords:
- واجهة برمجة تطبيقات عرض تقديمي منخفضة الشيفرة
- تحويل عرض تقديمي
- دمج عروض تقديمية
- تكرار الشرائح
- تكرار الأشكال
- تكرار النص
- جمع الأشكال
- ضغط العرض التقديمي
- إزالة شرائح القالب غير المستخدمة
- إزالة شرائح التخطيط غير المستخدمة
- ضغط الخطوط المدمجة
- PowerPoint
- OpenDocument
- عرض تقديمي
- PHP
- Aspose.Slides
description: "استخدام واجهة برمجة التطبيقات منخفضة الشيفرة لـ Aspose.Slides في PHP لتحويل ودمج العروض التقديمية، والتكرار عبر المحتوى، وجمع الأشكال، وتقليل حجم العرض."
---
## **نظرة عامة**

توفر مساحة الأسماء [aspose.slides](https://reference.aspose.com/slides/ar/php-java/aspose.slides/) فئات مساعدة ثابتة للعمليات الشائعة على العروض التقديمية. تقوم هذه المساعدات بلف سير عمل نموذج الكائنات المستخدم بشكل متكرر في أساليب مركزة، بحيث يمكنك تحويل أو دمج الملفات، ومعالجة عناصر العرض، وتجميع الأشكال، وإزالة المحتوى غير المستخدم بكتابة أقل.

تكون المساعدات منخفضة الشيفرة مفيدة عندما ينطبق العملية على ملف أو عرض تقديمي كامل ويتطابق سير العمل الافتراضي مع متطلباتك. استخدم نموذج الكائن الكامل لـ [Aspose.Slides](https://reference.aspose.com/slides/ar/php-java/aspose.slides/) عندما تحتاج إلى تحكم دقيق في الشرائح الفردية أو القوالب أو التخطيطات أو الأشكال أو إعدادات التصدير أو العلاقات بين عناصر العرض.

<table>
| المساعد | الاستخدام |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/ar/php-java/aspose.slides/convert/) | تحويل عرض تقديمي إلى تنسيق آخر باستدعاء مباشر من ملف إلى ملف. |
| [Merger](https://reference.aspose.com/slides/ar/php-java/aspose.slides/merger/) | دمج ملفات عرض تقديمي كاملة ذات نفس التنسيق. |
| [ForEach_](https://reference.aspose.com/slides/ar/php-java/aspose.slides/foreach_/) | تشغيل رد نداء لكل شريحة أو شكل أو فقرة أو جزء نصي. |
| [Collect](https://reference.aspose.com/slides/ar/php-java/aspose.slides/collect/) | استرداد الأشكال من العرض الكامل للمعالجة أو التحليل المتكرر. |
| [Compress](https://reference.aspose.com/slides/ar/php-java/aspose.slides/compress/) | إزالة القوالب والتخطيطات غير المستخدمة وتقليل بيانات الخطوط المدمجة. |
</table>

## **تحويل عرض تقديمي**

استخدم [Convert::autoByExtension](https://reference.aspose.com/slides/ar/php-java/aspose.slides/convert/#autoByExtension) عندما تكون امتداد ملف الإخراج كافية لاختيار تنسيق التصدير. تقوم الطريقة بفتح العرض المصدر، وتحديد التنسيق المطلوب من مسار الإخراج، ثم كتابة النتيجة.

```php
use aspose\slides\Convert;

Convert::autoByExtension("input.pptx", "output.pdf");
```

كما توفر الفئة [Convert](https://reference.aspose.com/slides/ar/php-java/aspose.slides/convert/) أساليب مخصصة لإنتاج PDF و SVG و JPEG و PNG و TIFF. استخدم نموذج الكائن الكامل عندما تحتاج إلى فحص أو تعديل العرض قبل التصدير أو تكوين خيار تصدير غير متاح عبر المساعد المختار. راجع [Convert Presentation](/php-java/convert-presentation/) للحصول على سير عمل وخيارات خاصة بكل تنسيق.

## **دمج العروض التقديمية**

استخدم [Merger::process](https://reference.aspose.com/slides/ar/php-java/aspose.slides/merger/#process) لدمج ملفات عرض تقديمي كاملة باستدعاء واحد. يجب أن تكون العروض المدخلة ذات نفس تنسيق الملف.

```php
use aspose\slides\Merger;

$inputFiles = ["part-1.pptx", "part-2.pptx"];
Merger::process($inputFiles, "merged.pptx");
```

المساعد مناسب عندما يجب إلحاق جميع الشرائح إلى نتيجة واحدة دون اختيارها أو إعادة تعيينها بشكل فردي. استخدم نموذج الكائن الكامل عندما تحتاج إلى دمج شرائح محددة، أو تطبيق قالب أو تخطيط وجهة، أو الحفاظ على الأقسام صراحة، أو موائمة أحجام الشرائح المختلفة. راجع [Merge Presentations](/php-java/merge-presentation/) لهذه السيناريوهات.

## **التكرار عبر عناصر العرض التقديمي**

الفئة [ForEach_](https://reference.aspose.com/slides/ar/php-java/aspose.slides/foreach_/) تستدعي رد نداء لكل نوع مطلوب من عناصر العرض. فهي تتجنب الحلقات المتداخلة وتكون مريحة للتفتيش أو تغييرات التنسيق على مستوى العرض الكامل.

المثال التالي يستخدم [ForEach_::slide](https://reference.aspose.com/slides/ar/php-java/aspose.slides/foreach_/#slide)، [ForEach_::shape](https://reference.aspose.com/slides/ar/php-java/aspose.slides/foreach_/#shape)، [ForEach_::paragraph](https://reference.aspose.com/slides/ar/php-java/aspose.slides/foreach_/#paragraph)، و[ForEach_::portion](https://reference.aspose.com/slides/ar/php-java/aspose.slides/foreach_/#portion) لتفقد العناصر المقابلة:

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

بشكل افتراضي، تشمل عملية التجوال عبر الأشكال والنصوص على مستوى العرض الشرائح العادية، والقوالب، والتخطيطات. يمكن للتحميلات التي تحتوي على معامل `includeNotes` أيضًا معالجة شرائح الملاحظات. استخدم حلقات جمع مباشرة عندما يكون ترتيب التجوال أو الخروج المبكر أو التصفية قبل استدعاء رد النداء أو التحكم التفصيلي في العلاقات الأبوية مهمًا.

## **جمع الأشكال**

استخدم [Collect::shapes](https://reference.aspose.com/slides/ar/php-java/aspose.slides/collect/#shapes) عندما تحتاج إلى مجموعة تشمل جميع الأشكال في عرض تقديمي بدلاً من رد نداء لكل شكل. هذا مفيد عندما سيتم تصفية أو عد أو معالجة نفس المجموعة أكثر من مرة.

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

استخدم [ForEach_::shape](https://reference.aspose.com/slides/ar/php-java/aspose.slides/foreach_/#shape) بدلاً من ذلك عندما يمكن معالجة كل شكل فورًا ولا تحتاج إلى الاحتفاظ بالنتيجة المجموعة.

## **ضغط محتوى العرض التقديمي**

يمكن لفئة [Compress](https://reference.aspose.com/slides/ar/php-java/aspose.slides/compress/) إزالة العناصر الهيكلية غير المستخدمة وتقليل بيانات الخطوط المدمجة:

- [Compress::removeUnusedLayoutSlides](https://reference.aspose.com/slides/ar/php-java/aspose.slides/compress/#removeUnusedLayoutSlides) يزيل شرائح التخطيط التي لا تشير إليها أي شريحة عادية.
- [Compress::removeUnusedMasterSlides](https://reference.aspose.com/slides/ar/php-java/aspose.slides/compress/#removeUnusedMasterSlides) يزيل القوالب التي لم تعد مستخدمة.
- [Compress::compressEmbeddedFonts](https://reference.aspose.com/slides/ar/php-java/aspose.slides/compress/#compressEmbeddedFonts) يزيل الأحرف غير المستخدمة من الخطوط المدمجة.

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

قم بإزالة التخطيطات غير المستخدمة قبل القوالب غير المستخدمة بحيث يمكن إزالة القالب الذي يصبح غير مرتبط بعد تنظيف التخطيطات. احفظ العرض المُحسّن إلى ملف جديد إذا قد تحتاج القوالب أو التخطيطات الأصلية أو بيانات الخطوط المدمجة الكاملة لاحقًا. لمزيد من التفاصيل، راجع [Slide Master](/php-java/slide-master/) و[Embedded Font](/php-java/embedded-font/).

## **الأسئلة المتكررة**

**متى يجب عليَّ استخدام واجهة برمجة التطبيقات منخفضة الشيفرة بدلاً من نموذج الكائن الكامل؟**

استخدم المساعدات منخفضة الشيفرة عندما تنطبق عملية معيارية على ملف أو عرض تقديمي كامل ولا تتطلب تحكمًا دقيقًا في العناصر الفردية. استخدم نموذج الكائن الكامل عندما تحتاج إلى اختيار شرائح محددة، أو التحكم في علاقات القالب والتخطيط، أو فحص الحالة المتوسطة، أو تكوين سلوك لا يطلعه المساعد.

**هل يمكن لـ Merger دمج عروض تقديمية بتنسيقات ملفات مختلفة؟**

لا. يتطلب [Merger::process](https://reference.aspose.com/slides/ar/php-java/aspose.slides/merger/#process) أن تكون العروض المدخلة بنفس التنسيق. حوّل الملفات المدخلة إلى تنسيق موحد أولًا، على سبيل المثال باستخدام [Convert::autoByExtension](https://reference.aspose.com/slides/ar/php-java/aspose.slides/convert/#autoByExtension)، ثم دمج الملفات المحوَّلة.

**هل يعالج ForEach_ القوالب، والتخطيطات، وشرائح الملاحظات؟**

[ForEach_::slide](https://reference.aspose.com/slides/ar/php-java/aspose.slides/foreach_/#slide) يتكرر عبر الشرائح العادية في العرض. تشمل عمليات [ForEach_::shape](https://reference.aspose.com/slides/ar/php-java/aspose.slides/foreach_/#shape)، [ForEach_::paragraph](https://reference.aspose.com/slides/ar/php-java/aspose.slides/foreach_/#paragraph) و[ForEach_::portion](https://reference.aspose.com/slides/ar/php-java/aspose.slides/foreach_/#portion) القوالب والتخطيطات بشكل افتراضي. استخدم التحميلات مع تعيين `includeNotes` إلى `true` لتضمين شرائح الملاحظات.

**ما الفرق بين ForEach_::shape و Collect::shapes؟**

استخدم [ForEach_::shape](https://reference.aspose.com/slides/ar/php-java/aspose.slides/foreach_/#shape) لمعالجة كل شكل فورًا عبر رد نداء. استخدم [Collect::shapes](https://reference.aspose.com/slides/ar/php-java/aspose.slides/collect/#shapes) عندما تحتاج إلى نتيجة قابلة للتكرار يمكن الاحتفاظ بها، وتصفيةها، وعدّها، أو تجوالها عدة مرات.

**هل يجعل Compress دائمًا ملف العرض أصغر؟**

ليس بالضرورة. تعتمد النتيجة على ما إذا كان العرض يحتوي على تخطيطات أو قوالب غير مستخدمة أو خطوط مدمجة فيها أحرف غير مستخدمة. إذا لم تكن أي من هذه العناصر موجودة، قد لا تقلل عمليات [Compress](https://reference.aspose.com/slides/ar/php-java/aspose.slides/compress/) حجم الملف.

**هل يتم حفظ التغييرات التي يجريها ForEach_ أو Compress تلقائيًا؟**

لا. تعمل هذه المساعدات على كائن [Presentation](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/) المحمل في الذاكرة. بعد تعديل العناصر في رد نداء [ForEach_](https://reference.aspose.com/slides/ar/php-java/aspose.slides/foreach_) أو تشغيل [Compress](https://reference.aspose.com/slides/ar/php-java/aspose.slides/compress/)، استدعِ [Presentation::save](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/#save) لكتابة النتيجة.

## **مقالات ذات صلة**

- [Convert Presentation](/php-java/convert-presentation/)
- [Merge Presentations](/php-java/merge-presentation/)
- [Slide Master](/php-java/slide-master/)
- [Manage Text Box](/php-java/manage-textbox/)
- [Embedded Font](/php-java/embedded-font/)