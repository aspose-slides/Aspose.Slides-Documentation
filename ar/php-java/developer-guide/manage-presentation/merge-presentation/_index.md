---
title: دمج العروض التقديمية بفعالية في PHP
linktitle: دمج العروض التقديمية
type: docs
weight: 40
url: /ar/php-java/merge-presentation/
keywords:
- دمج PowerPoint
- دمج العروض التقديمية
- دمج الشرائح
- دمج PPT
- دمج PPTX
- دمج ODP
- تجميع PowerPoint
- تجميع العروض التقديمية
- تجميع الشرائح
- تجميع PPT
- تجميع PPTX
- تجميع ODP
- PHP
- Aspose.Slides
description: "تعلم كيفية دمج العروض التقديمية بتنسيق PowerPoint وOpenDocument في PHP عن طريق استنساخ الشرائح، والتحكم في الماسترز والتخطيطات، وتغيير حجم محتوى الشرائح، والحفاظ على الأقسام، ومعالجة الملفات المحمية أو الكبيرة."
---
## **نظرة عامة**

Aspose.Slides for PHP via Java يدمج العروض التقديمية عن طريق استنساخ الشرائح من **Presentation** واحد إلى آخر. العملية الأساسية هي [SlideCollection::addClone()](https://reference.aspose.com/slides/ar/php-java/aspose.slides/slidecollection/addclone/)، والتي يمكنها الحفاظ على تنسيق الشريحة المصدر أو إرفاق الشريحة المستنسخة إلى ماستر أو تخطيط في العرض التقديمي الوجهة.

هذا المقال يغطي أكثر سيناريوهات الدمج شيوعًا:

- دمج جميع الشرائح مع الحفاظ على تنسيق المصدر؛
- دمج شرائح مختارة؛
- تطبيق ماستر من العرض التقديمي الوجهة؛
- تطبيق تخطيط محدد من العرض التقديمي الوجهة؛
- توحيد أحجام الشرائح المختلفة قبل الدمج؛
- إضافة الشرائح المستنسخة إلى قسم؛
- دمج عدة عروض تقديمية في سير عمل شامل؛
- التعامل مع الماسترز، الموارد، الملاحظات، التعليقات، الوسائط، الخطوط، كلمات المرور، الملفات الكبيرة، ومشكلات تعدد الخيوط.

## **كيف يؤثر استنساخ الشرائح على الماسترز والتخطيطات**

تستمد الشريحة جزءًا كبيرًا من مظهرها من التخطيط والماستر الخاصين بها. لذلك، يحدد التحميل الزائد (overload) الذي تختاره كيفية دمج الشريحة المستنسخة في عرض تقديمي الوجهة.

استخدم [SlideCollection::addClone()](https://reference.aspose.com/slides/ar/php-java/aspose.slides/slidecollection/addclone/) بأحد الطرق التالية:

- `addClone(sourceSlide)` — الحفاظ على تخطيط وتنسيق الشريحة المصدر. عند الضرورة، يمكن استنساخ الماستر المصدر إلى العرض التقديمي الوجهة تلقائيًا. تتعقب Aspose.Slides الماسترز المستنسخة تلقائيًا حتى لا تتكرر عملية الاستنساخ لنفس الماستر.
- `addClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — إرفاق الشريحة المستنسخة إلى [MasterSlide] معين في الوجهة. يبحث Aspose.Slides عن تخطيط مطابق تحت ذلك الماستر بناءً على نوع التخطيط أو الاسم.
- `addClone(sourceSlide, destinationLayout)` — إرفاق الشريحة المستنسخة مباشرة إلى [LayoutSlide] محدد في الوجهة.

يجب أن يكون الماستر أو التخطيط الممرر إلى نسخة `addClone` تابعًا لعرض **الوجهة**، لا للعرض المصدر.

## **دمج عروض تقديمية بالكامل مع الحفاظ على تنسيق المصدر**

أبسط طريقة دمج هي نسخ كل شريحة من العرض المصدر إلى العرض الهدف. وهذا هو الاختيار المناسب عندما يجب أن تحتفظ الشرائح المستوردة بموضوعها الأصلي والماستر وعلاقات التخطيط الخاصة بها.

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$destination = new Presentation("destination.pptx");
try {
    $source = new Presentation("source.pptx");
    try {
        foreach ($source->getSlides() as $slide) {
            $destination->getSlides()->addClone($slide);
        }
    } finally {
        $source->dispose();
    }

    $destination->save("merged.pptx", SaveFormat::Pptx);
} finally {
    $destination->dispose();
}
```

قد يحتوي العرض الناتج على عدة ماسترز عندما يستخدم المصدر والوجهة تصاميم مختلفة. هذا متوقع عندما يتم الحفاظ على تنسيق المصدر عن عمد.

## **دمج شرائح مختارة**

ليس من الضروري استنساخ كل شريحة. المثال التالي يستورد فقط فهارس الشرائح المختارة من العرض المصدر.

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$destination = new Presentation("destination.pptx");
try {
    $source = new Presentation("source.pptx");
    try {
        $slideIndexes = [0, 2, 4];

        foreach ($slideIndexes as $index) {
            $destination->getSlides()->addClone($source->getSlides()->get_Item($index));
        }
    } finally {
        $source->dispose();
    }

    $destination->save("merged-selected-slides.pptx", SaveFormat::Pptx);
} finally {
    $destination->dispose();
}
```

تحقق من صحة فهارس الشرائح قبل الاستنساخ عندما تأتي من مدخلات المستخدم أو تكوين خارجي.

## **دمج شرائح باستخدام ماستر الوجهة**

استخدم التحميل الزائد [addClone(Slide, MasterSlide, boolean)](https://reference.aspose.com/slides/ar/php-java/aspose.slides/slidecollection/addclone/) عندما يجب أن تتبع الشرائح المستوردة ماسترًا موجودًا بالفعل في عرض الوجهة.

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$destination = new Presentation("destination.pptx");
try {
    $source = new Presentation("source.pptx");
    try {
        $destinationMaster = $destination->getMasters()->get_Item(0);

        foreach ($source->getSlides() as $slide) {
            $destination->getSlides()->addClone($slide, $destinationMaster, true);
        }
    } finally {
        $source->dispose();
    }

    $destination->save("merged-with-destination-master.pptx", SaveFormat::Pptx);
} finally {
    $destination->dispose();
}
```

تختار Aspose.Slides تخطيطًا مناسبًا تحت الماستر المحدد بمطابقة نوع أو اسم التخطيط المصدر. إذا لم يوجد تخطيط مناسب وكان `allowCloneMissingLayout` يساوي `true`، يتم استنساخ التخطيط المصدر حتى يمكن إضافة الشريحة. إذا كان `false`، يُرمى [PptxEditException](https://reference.aspose.com/slides/ar/php-java/aspose.slides/pptxeditexception/).

استخدم `false` عندما تريد أن يفشل الدمج بدلًا من إضافة تخطيط إضافي إلى ماستر الوجهة.

## **دمج شرائح باستخدام تخطيط وجهة محدد**

استخدم التحميل الزائد [addClone(Slide, LayoutSlide)](https://reference.aspose.com/slides/ar/php-java/aspose.slides/slidecollection/addclone/) عندما تعرف بالضبط أي تخطيط وجهة يجب أن تستخدمه الشرائح المستوردة.

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$destination = new Presentation("destination.pptx");
try {
    $source = new Presentation("source.pptx");
    try {
        $destinationLayout = $destination->getLayoutSlides()->get_Item(0);

        foreach ($source->getSlides() as $slide) {
            $destination->getSlides()->addClone($slide, $destinationLayout);
        }
    } finally {
        $source->dispose();
    }

    $destination->save("merged-with-destination-layout.pptx", SaveFormat::Pptx);
} finally {
    $destination->dispose();
}
```

تطبيق تخطيط الوجهة يغيّر علاقة التخطيط الموروثة؛ لكنه لا يعيد تصميم محتوى الشريحة المصدر. إذا كان للتخطيطات المصدر والوجهة بنية نائبة مختلفة، فافحص النتيجة للتأكد من أن التنسيق والسلوك النائب مناسبان.

## **دمج عروض تقديمية بأحجام شرائح مختلفة**

يمكن دمج عروض تقديمية ذات أبعاد شرائح مختلفة، لكن استنساخ شريحة إلى عرض بأبعاد مختلفة لا يعيد تصميم محتواها تلقائيًا ليتناسب مع القماش الجديد. قد تظهر الأشكال مُحَوَّلة أو مُقاسة بشكل غير متوقع أو خارج مساحة الشريحة المرئية.

نهج عملي هو تعديل حجم العرض المصدر قبل الاستنساخ. طريقة [SlideSize::setSize()](https://reference.aspose.com/slides/ar/php-java/aspose.slides/slidesize/setsize/) يمكنها تحجيم المحتوى الموجود أثناء تغيير أبعاد الشريحة. [SlideSizeScaleType::EnsureFit](https://reference.aspose.com/slides/ar/php-java/aspose.slides/slidesizescaletype/) تحجيم المحتوى ليتناسب مع الحجم المطلوب.

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideSizeScaleType;

$destination = new Presentation("destination.pptx");
try {
    $source = new Presentation("source.pptx");
    try {
        $sourceWidth = java_values($source->getSlideSize()->getSize()->getWidth());
        $sourceHeight = java_values($source->getSlideSize()->getSize()->getHeight());
        $destinationWidth = java_values($destination->getSlideSize()->getSize()->getWidth());
        $destinationHeight = java_values($destination->getSlideSize()->getSize()->getHeight());

        if ($sourceWidth != $destinationWidth || $sourceHeight != $destinationHeight) {
            $source->getSlideSize()->setSize($destinationWidth, $destinationHeight, SlideSizeScaleType::EnsureFit);
        }

        foreach ($source->getSlides() as $slide) {
            $destination->getSlides()->addClone($slide);
        }
    } finally {
        $source->dispose();
    }

    $destination->save("merged-same-slide-size.pptx", SaveFormat::Pptx);
} finally {
    $destination->dispose();
}
```

إعادة التحجيم تغير كائن العرض المصدر في الذاكرة. إذا كنت بحاجة إلى الحفاظ على العرض الأصلي دون تعديل لعمليات أخرى، افتح نسخة منفصلة للدمج.

## **دمج الشرائح في قسم من العرض التقديمي**

الحلقة الأساسية لاستنساخ الشرائح لا تعيد إنشاء تسلسل أقسام العرض المصدر. إذا كانت الأقسام مهمة في الناتج، أنشئ أو حدد أقسامًا في العرض الوجهة واستنسخ الشرائح إليها صراحةً باستخدام [addClone(Slide, Section)](https://reference.aspose.com/slides/ar/php-java/aspose.slides/slidecollection/addclone/).

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$destination = new Presentation("destination.pptx");
try {
    $source = new Presentation("source.pptx");
    try {
        $importedSection = $destination->getSections()->appendEmptySection("Imported slides");

        foreach ($source->getSlides() as $slide) {
            $destination->getSlides()->addClone($slide, $importedSection);
        }
    } finally {
        $source->dispose();
    }

    $destination->save("merged-with-section.pptx", SaveFormat::Pptx);
} finally {
    $destination->dispose();
}
```

تُضاف الشرائح المستنسخة إلى القسم الوجهة المحدد. للحفاظ على عدة أقسام مصدر، أعد إنشاء تلك الأقسام في الوجهة واربط كل شريحة مصدر بالقسم الوجهة المناسب.

## **دمج عدة عروض تقديمية بأمان**

المثال التالي لإنهاء إلى النهاية يستخدم العرض الأول كوجهة، يوحد حجم الشريحة لكل مصدر إضافي، يبقي كل مصدر مفتوحًا فقط أثناء النسخ، ويحفظ الملف النهائي مرة واحدة.

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideSizeScaleType;

$inputFiles = ["part1.pptx", "part2.pptx", "part3.pptx"];

$merged = new Presentation($inputFiles[0]);
try {
    $mergedWidth = java_values($merged->getSlideSize()->getSize()->getWidth());
    $mergedHeight = java_values($merged->getSlideSize()->getSize()->getHeight());

    for ($fileIndex = 1; $fileIndex < count($inputFiles); $fileIndex++) {
        $source = new Presentation($inputFiles[$fileIndex]);
        try {
            $sourceWidth = java_values($source->getSlideSize()->getSize()->getWidth());
            $sourceHeight = java_values($source->getSlideSize()->getSize()->getHeight());

            if ($sourceWidth != $mergedWidth || $sourceHeight != $mergedHeight) {
                $source->getSlideSize()->setSize($mergedWidth, $mergedHeight, SlideSizeScaleType::EnsureFit);
            }

            foreach ($source->getSlides() as $slide) {
                $merged->getSlides()->addClone($slide);
            }
        } finally {
            $source->dispose();
        }
    }

    $merged->save("merged.pptx", SaveFormat::Pptx);
} finally {
    $merged->dispose();
}
```

هذا أساس مفيد للحفاظ على تنسيق الشرائح المستوردة. إذا كان المخرجات يجب أن تستخدم موضوعًا موحدًا، استبدل استدعاء `addClone($slide)` البسيط بالتحميل الزائد للماستر أو التخطيط الوجهة المناسب كما هو موضح أعلاه.

## **اعتبارات عملية**

### **الماسترز، التخطيطات، ودقة التنسيق**

يمكن لاستنساخ الشرائح الافتراضي أن يجلب ماستر مصدر مطلوب إلى العرض الوجهة تلقائيًا. تحتفظ Aspose.Slides بسجل داخلي للماسترز المستنسخة تلقائيًا لتجنب استنساخ نفس الماستر مرارًا. لا يتم تتبع الماسترز المستنسخة يدويًا بهذا السجل، لذا تجنّب استنساخ الماسترز مسبقًا ما لم تكن بحاجة إلى سيطرة صريحة على بنية الماستر.

لا تفترض أن ماسترين أو تخطيطين لهما نفس الاسم متكافئان بصريًا. إذا كان قالب الشركة يجب أن يتحكم في المظهر النهائي، اختر ماستر أو تخطيط وجهة صريحًا وتحقق من النتيجة بعد الدمج.

### **الملاحظات والتعليقات**

ملاحظات المتحدث وتعليقات الشرائح مرتبطة بمحتوى الشريحة وتُنسخ عند استنساخ الشريحة. توفر Aspose.Slides أيضًا واجهات برمجة تطبيقات مخصصة لـ [presentation notes](https://docs.aspose.com/slides/ar/php-java/presentation-notes/) و [presentation comments](https://docs.aspose.com/slides/ar/php-java/presentation-comments/).

إذا كان تنسيق صفحة الملاحظات مهمًا، تحقق من العرض المدمج لأن ماسترات الملاحظات هي كائنات على مستوى العرض وقد تختلف بين الملفات المصدر. بالنسبة لسير عمل المراجعة، تحقق أيضًا من مؤلفي التعليقات أو التعليقات المتسلسلة بعد دمج ملفات من مؤلفين أو قوالب مختلفة.

### **الصور، الصوت، الفيديو، كائنات OLE، والروابط الخارجية**

يمكن للشرائح الإشارة إلى موارد على مستوى العرض مثل الصور، الصوت المدمج، الفيديو المدمج، وبيانات OLE. استنسخ الشريحة نفسها بدلاً من نسخ الأشكال الظاهرة فقط حتى تتمكن Aspose.Slides من الحفاظ على علاقات الشريحة بمواردها.

يجب معالجة الموارد المدمجة والمرتبطة بشكل مختلف. يبقى الصوت أو الفيديو أو كائن OLE أو الارتباط التشعبي المرتبط معتمدًا على هدفه الخارجي؛ استنساخ الشريحة لا يتحول إلى محتوى مدمج. اختبر مسارات الموارد المرتبطة وعناوين URL في البيئة التي سيفتح فيها العرض المدمج.

تتبع Aspose.Slides الماسترز المستنسخة تلقائيًا، لكن لا ينبغي اعتبار ذلك ضمانًا عامًا بأن الموارد الثنائية المتطابقة من عروض تقديمية مختلفة ستتم إزالة تكرارها دائمًا. إذا كان حجم ملف الإخراج مهمًا، افحص الحزمة المدمجة وقس النتيجة بدلاً من الاعتماد على إزالة التكرار الضمنية.

### **الخطوط المدمجة وتوافر الخطوط**

تُدار الخطوط على مستوى العرض. إذا كان يجب الحفاظ على الطباعة عبر الأجهزة، لا تفترض أن استنساخ الشرائح يضمن توفر كل خط مطلوب في بيئة الوجهة. يمكنك فحص الخطوط المدمجة باستخدام [FontsManager::getEmbeddedFonts()](https://reference.aspose.com/slides/ar/php-java/aspose.slides/fontsmanager/getembeddedfonts/) وإدارة الدمج صراحةً كما هو موضح في [Embed Fonts in Presentations](https://docs.aspose.com/slides/ar/php-java/embedded-font/).

تحقق أيضًا من أنك مسموح لك بدمج الخطوط المستخدمة في الملفات المصدر. قد تقيد تراخيص الخطوط عملية الدمج.

### **العروض التقديمية المحمية بكلمة مرور**

يجب فتح المصدر المحمي بكلمة مرور بنجاح قبل أن يمكن استنساخ شرائحه. زوِّد كلمة المرور عبر [LoadOptions::setPassword()](https://reference.aspose.com/slides/ar/php-java/aspose.slides/loadoptions/setpassword/).

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\LoadOptions;
use aspose\slides\Presentation;

$loadOptions = new LoadOptions();
$loadOptions->setPassword("YOUR_PASSWORD");

$source = new Presentation("protected.pptx", $loadOptions);
try {
    // العمل مع العرض التقديمي المفكوك.
} finally {
    $source->dispose();
}
```

فتح مصدر مشفر لا يطبق تلقائيًا نفس الحماية على العرض الوجهة. قم بتكوين حماية الإخراج بشكل منفصل عند الحاجة.

### **العروض الكبيرة واستخدام الذاكرة**

العروض الكبيرة التي تحتوي على صور عالية الدقة أو صوت أو فيديو أو كائنات ثنائية كبيرة قد تستهلك ذاكرة كبيرة. توفر [LoadOptions::getBlobManagementOptions()](https://reference.aspose.com/slides/ar/php-java/aspose.slides/loadoptions/getblobmanagementoptions/) ضوابط لمعالجة الـ BLOB والاستخدام المؤقت للملفات. راجع [Open Presentations](https://docs.aspose.com/slides/ar/php-java/open-presentation/#open-large-presentations) للحصول على مثال لملف كبير في PHP عبر Java.

للملفات الكبيرة، يفضَّل تحميلها من مسارات الملفات عندما يكون ذلك ممكنًا، وتخلص من كل عرض مصدر بمجرد دمجه، وتجنّب حفظ النتائج الوسيطة بشكل متكرر إلا إذا احتاج سير العمل إلى نقاط تفتيش.

### **سلامة الخيوط**

لا تقم بتحميل أو تعديل أو حفظ أو استنساخ كائنات [Presentation] في عدة خيوط. هذه العمليات غير مدعومة للاستخدام متعدد الخيوط في PHP عبر Java. إذا احتجت إلى وظائف دمج متوازية، شغّلها في عمليات منفصلة أحادية الخيط، بحيث يستخدم كل عملية نسخته الخاصة من العروض، وتبع توجيهات [Aspose.Slides multithreading guidance](https://docs.aspose.com/slides/ar/php-java/multithreading/).

## **الأسئلة الشائعة**

**كيف يمكنني الحفاظ على التصميم الأصلي لكل عرض تقديمي مصدر؟**

استخدم [`addClone(sourceSlide)`](https://reference.aspose.com/slides/ar/php-java/aspose.slides/slidecollection/addclone/) دون تمرير ماستر أو تخطيط وجهة. يمكن لـ Aspose.Slides استنساخ الماستر المصدر تلقائيًا عندما تحتاجه الشريحة المستوردة.

**كيف أجعل الشرائح المستوردة تستخدم سمة الوجهة؟**

استخدم التحميل الزائد الذي يقبل ماستر وجهة. مرّر ماسترًا من العرض الوجهة، ليس من المصدر. ستحاول Aspose.Slides مطابقة كل شريحة مصدر لتخطيط مناسب تحت ذلك الماستر.

**متى يجب استخدام تخطيط وجهة محدد بدلًا من ماستر وجهة؟**

استخدم تخطيطًا محددًا عندما يجب أن تستخدم كل شريحة مستوردة تخطيطًا معروفًا واحدًا. استخدم ماسترًا عندما تريد من Aspose.Slides اختيار التخطيط المناسب من بين تخطيطات ذلك الماستر بناءً على نوع أو اسم التخطيط المصدر.

**هل يمكن دمج عروض تقديمية ذات أحجام شرائح مختلفة؟**

نعم، لكن محتوى الشريحة لا يُعاد تصميمه تلقائيًا لأبعاد الوجهة. قم بتغيير حجم العرض المصدر أولاً عندما تحتاج إلى موضعية متوقعة، على سبيل المثال باستخدام [SlideSize::setSize()](https://reference.aspose.com/slides/ar/php-java/aspose.slides/slidesize/setsize/) و [SlideSizeScaleType::EnsureFit](https://reference.aspose.com/slides/ar/php-java/aspose.slides/slidesizescaletype/).

**هل يمكنني دمج ملفات PPT و PPTX و ODP في ملف واحد؟**

نعم. حمّل كل عرض مصدر، استنسخ الشرائح المطلوبة إلى عرض وجهة واحد، واحفظ الوجهة بصيغة مدعومة. نظرًا لأن تنسيقات العروض لا تدعم نفس مجموعة الميزات تمامًا، تحقق من المحتوى المعقد بعد عمليات الدمج عبر الصيغ. راجع [Supported File Formats](https://docs.aspose.com/slides/ar/php-java/supported-file-formats/).

**هل يتم الحفاظ على أقسام المصدر تلقائيًا؟**

ليس عبر الحلقة الأساسية التي تستنسخ الشرائح فقط. أعد إنشاء الأقسام المطلوبة في الوجهة واستخدم التحميل الزائد لـ [addClone](https://reference.aspose.com/slides/ar/php-java/aspose.slides/slidecollection/addclone/) عندما يجب الحفاظ على بنية الأقسام.

**هل يتم الحفاظ على ملاحظات المتحدث والتعليقات؟**

يتم نسخها مع الشريحة المستنسخة. بالنسبة لسير عمل يعتمد على نمط ماستر الملاحظات أو مؤلفي التعليقات أو بيانات المراجعة المتسلسلة، تحقق من النتيجة المدمجة لأن هذه السيناريوهات تشمل هياكل على مستوى العرض بالإضافة إلى محتوى الشرائح.

**ماذا يحدث للملفات الصوتية والفيديوية وكائنات OLE والروابط التشعبية؟**

يتم نقل المحتوى المدمج كجزء من علاقات موارد الشريحة المستنسخة. تبقى الروابط الخارجية خارجية، لذا يجب أن تكون ملفات الهدف أو عناوين URL الخاصة بها متاحة بعد الدمج.

**هل الخطوط المدمجة من كل مصدر مضمونة التوافر في العرض المدمج؟**

لا تعتمد على استنساخ الشرائح فقط لنشر الخطوط. افحص الخطوط المدمجة في الوجهة وادِر دمج الخطوط صراحةً أو تأكد من توفر الخطوط الخارجية عندما تكون الطباعة مهمة.

**كيف أدمج ملفًا محميًا بكلمة مرور؟**

افتحه باستخدام [LoadOptions::setPassword()](https://reference.aspose.com/slides/ar/php-java/aspose.slides/loadoptions/setpassword/) ثم استنسخ شرائحه كالمعتاد. يتم تكوين حماية الإخراج بشكل منفصل.

**كيف يجب أن أتعامل مع عروض تقديمية كبيرة جدًا؟**

استخدم إدارة BLOB عندما تهيمن الكائنات الثنائية الكبيرة على استهلاك الذاكرة، وفضّل تحميل من مسار الملف للملفات الضخمة، وتخلص من عروض المصدر بسرعة، واحفظ النتيجة النهائية فقط عند الحاجة.

**هل يمكنني دمج شرائح من خيوط متعددة؟**

تحميل أو حفظ أو استنساخ عروض تقديمية في خيوط متعددة غير مدعوم في PHP عبر Java. للعمل المتوازي، استخدم عمليات منفصلة أحادية الخيط واحفظ كائنات العرض معزولة داخل كل عملية.