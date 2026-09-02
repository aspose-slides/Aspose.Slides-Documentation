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
- دمج PowerPoint
- دمج العروض التقديمية
- دمج الشرائح
- دمج PPT
- دمج PPTX
- دمج ODP
- PHP
- Aspose.Slides
description: "تعرف على كيفية دمج عروض PowerPoint وOpenDocument في PHP عن طريق استنساخ الشرائح، التحكم في الماسترز والتخطيطات، تعديل حجم محتوى الشرائح، الحفاظ على الأقسام، ومعالجة الملفات المحمية أو الكبيرة."
---
## **نظرة عامة**

Aspose.Slides for PHP via Java يجمع العروض التقديمية عن طريق استنساخ الشرائح من [Presentation](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/) إلى أخرى. العملية الرئيسية هي [SlideCollection::addClone()](https://reference.aspose.com/slides/ar/php-java/aspose.slides/slidecollection/addclone/)، والتي يمكنها الحفاظ على تنسيق الشريحة المصدر أو ربط الشريحة المستنسخة بماستر أو تخطيط في العرض التقديمي الوجهة.

تغطي هذه المقالة أكثر سير عمل دمج شائع:
- دمج جميع الشرائح مع الحفاظ على تنسيق المصدر;
- دمج شرائح مختارة;
- تطبيق ماستر من العرض التقديمي الوجهة;
- تطبيق تخطيط محدد من العرض التقديمي الوجهة;
- توحيد أحجام الشرائح المختلفة قبل الدمج;
- إضافة شرائح مستنسخة إلى قسم;
- دمج عدة عروض تقديمية في سير عمل شامل من البداية إلى النهاية;
- التعامل مع الماسترز، الموارد، الملاحظات، التعليقات، الوسائط، الخطوط، كلمات المرور، الملفات الكبيرة، ومخاوف تعدد الخيوط.

## **كيفية تأثير استنساخ الشرائح على الماسترز والتخطيطات**

تستمد الشريحة جزءًا كبيرًا من مظهرها من التخطيط والماستر الخاص بها. لهذا السبب، يحدد التحميل الزائد (overload) الذي تختاره كيفية دمج الشريحة المستنسخة في العرض التقديمي الوجهة.

استخدم [SlideCollection::addClone()](https://reference.aspose.com/slides/ar/php-java/aspose.slides/slidecollection/addclone/) بأحد الطرق التالية:
- `addClone(sourceSlide)` — الحفاظ على تخطيط وشكل الشريحة المصدر. عند الحاجة، يمكن استنساخ الماستر المصدر إلى العرض التقديمي الوجهة تلقائيًا. تتتبع Aspose.Slides الماسترز المستنسخة تلقائيًا بحيث لا يتم استنساخ الماستر نفسه مرارًا إذا استخدمت شرائح متعددة نفس الماستر المصدر.
- `addClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — ربط الشريحة المستنسخة بماستر وجهة محدد [MasterSlide](https://reference.aspose.com/slides/ar/php-java/aspose.slides/masterslide/). يبحث Aspose.Slides عن تخطيط مطابق تحت ذلك الماستر حسب نوع التخطيط أو اسمه.
- `addClone(sourceSlide, destinationLayout)` — ربط الشريحة المستنسخة مباشرةً بتخطيط وجهة محدد [LayoutSlide](https://reference.aspose.com/slides/ar/php-java/aspose.slides/layoutslide/).

يجب أن ينتمي الماستر أو التخطيط الممرّر إلى **العرض التقديمي الوجهة**، وليس إلى العرض التقديمي المصدر.

## **دمج العروض التقديمية بالكامل مع الحفاظ على تنسيق المصدر**

أبسط عملية دمج هي نسخ كل شريحة من العرض التقديمي المصدر إلى العرض التقديمي الوجهة. هذا هو الاختيار المناسب عندما يجب أن تحتفظ الشرائح المستوردة بالموضوع والماستر وعلاقات التخطيط الأصلية.

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

قد يحتوي العرض التقديمي الناتج على عدة ماسترات عندما يستخدم المصدر والوجهة تصاميم مختلفة. هذا متوقع عندما يتم الحفاظ على تنسيق المصدر عن قصد.

## **دمج شرائح مختارة**

ليس عليك استنساخ كل شريحة. المثال التالي يستورد فقط فهارس الشرائح المختارة من العرض التقديمي المصدر.

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

## **دمج الشرائح باستخدام ماستر الوجهة**

استخدم التحميل الزائد [addClone(Slide, MasterSlide, boolean)](https://reference.aspose.com/slides/ar/php-java/aspose.slides/slidecollection/addclone/) عندما يجب أن تتبع الشرائح المستوردة ماسترًا ينتمي بالفعل إلى العرض التقديمي الوجهة.

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

تختار Aspose.Slides تخطيطًا مناسبًا تحت الماستر المحدد من خلال مطابقة نوع التخطيط أو اسمه. إذا لم يكن هناك تخطيط مناسب وكان `allowCloneMissingLayout` يساوي `true`, يتم استنساخ التخطيط المصدر بحيث يمكن إضافة الشريحة. إذا كان `false`, يتم إلقاء استثناء [PptxEditException](https://reference.aspose.com/slides/ar/php-java/aspose.slides/pptxeditexception/).

استخدم `false` عندما تريد أن يفشل الدمج بدلاً من إضافة تخطيط إضافي إلى ماستر الوجهة.

## **دمج الشرائح باستخدام تخطيط وجهة محدد**

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

تغيير التخطيط الوجهة يغيّر علاقة التخطيط الموروثة؛ ولا يعيد تصميم محتوى الشريحة المصدر. إذا كان للتصاميم المصدر والوجهة بنى عناصر نائبة مختلفة، فافحص النتيجة لتأكيد أن التنسيق والسلوك النائب مناسبين.

## **دمج عروض تقديمية بأحجام شرائح مختلفة**

يمكن دمج العروض التقديمية ذات أبعاد شرائح مختلفة، لكن استنساخ شريحة إلى عرض يقدم بأبعاد شريحة أخرى لا يعيد تصميم محتواها تلقائيًا لتناسب القماش الجديد. قد تظهر الأشكال مُحَرَّكة أو مُقَاسَّة بشكل غير متوقع، أو خارج منطقة الشريحة المرئية.

نهج عملي هو تغيير حجم العرض التقديمي المصدر قبل الاستنساخ. يمكن لطريقة [SlideSize::setSize()](https://reference.aspose.com/slides/ar/php-java/aspose.slides/slidesize/setsize/) أن تُقَلِّب المحتوى الحالي أثناء تغيير أبعاد الشريحة. طريقة [SlideSizeScaleType::EnsureFit](https://reference.aspose.com/slides/ar/php-java/aspose.slides/slidesizescaletype/) تُقَلِّب المحتوى ليتلاءم مع الحجم المطلوب.

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

يُغيّر تغيير الحجم كائن العرض التقديمي المصدر في الذاكرة. إذا كنت تحتاج إلى إبقاء العرض التقديمي المصدر الأصلي دون تعديل لعمليات أخرى، افتح نسخة منفصلة للدمج.

## **دمج الشرائح في قسم من العرض التقديمي**

الحلقة الأساسية لاستنساخ الشرائح لا تعيد إنشاء هيكلية أقسام العرض التقديمي المصدر. إذا كانت الأقسام مهمة في الناتج، أنشئ أو اختر أقسامًا في العرض التقديمي الوجهة واستنسخ الشرائح إليها صراحةً باستخدام [addClone(Slide, Section)](https://reference.aspose.com/slides/ar/php-java/aspose.slides/slidecollection/addclone/).

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

تُضاف الشرائح المستنسخة إلى القسم الوجهة المحدد. للحفاظ على عدة أقسام مصدر، استدعِ [Presentation::getSections](https://reference.aspose.com/slides/ar/php-java/aspose.slides/Presentation/#getSections)، احصل على الشرائح الحالية لكل قسم مصدر باستخدام [Section::getSlidesListOfSection](https://reference.aspose.com/slides/ar/php-java/aspose.slides/Section/#getSlidesListOfSection)، أعد إنشاء الأقسام في الوجهة، واستنسخ كل شريحة مسترجعة إلى القسم الوجهة المقابل. راجع [Manage Slide Sections](/slides/ar/php-java/slide-section/) للحصول على مثال كامل لتعداد الأقسام، بما في ذلك الأقسام الفارغة والتغييرات الهيكلية.

## **دمج عدة عروض تقديمية بأمان**

المثال التالي من البداية إلى النهاية يستخدم العرض التقديمي الأول كوجهة، يُوحِّد حجم الشريحة لكل مصدر إضافي، يحتفظ بكل مصدر مفتوحًا فقط أثناء نسخه، ويحفظ الملف النهائي مرة واحدة.

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

هذا نموذج أساسي مفيد للحفاظ على تنسيق المصدر للشرائح المستوردة. إذا كان يجب أن يستخدم الناتج موضوعًا موحدًا واحدًا، استبدل استدعاء `addClone($slide)` البسيط بالتحميل الزائد للماستر أو التخطيط الوجهة المناسب المشار إليه سابقًا.

## **اعتبارات عملية**

### **الماسترات، التخطيطات، ودقة التنسيق**

يمكن للاستنساخ الافتراضي للشرائح أن يجلب ماستر مصدر مطلوب إلى العرض التقديمي الوجهة تلقائيًا. تحتفظ Aspose.Slides بسجل داخلي للماسترات المستنسخة تلقائيًا لتجنب استنساخ نفس الماستر مرارًا. لا يتم تتبع الماسترات المستنسخة يدويًا في ذلك السجل، لذا تجنّب استنساخ الماسترات مسبقًا إلا إذا كنت بحاجة إلى تحكم صريح في بنية الماستر.

لا تفترض أن ماسترين أو تخطيطين لهما نفس الاسم متساويان بصريًا. إذا كان قالب الشركة يجب أن يتحكم بالمظهر النهائي، اختر ماستر أو تخطيط وجهة صراحةً وتحقق من النتيجة بعد الدمج.

### **الملاحظات والتعليقات**

الملاحظات الصوتية وتعليقات الشرائح مرتبطة بمحتوى الشريحة وتُنسخ عندما تُستنسخ الشريحة. توفر Aspose.Slides أيضًا واجهات برمجة تطبيقات مخصصة لـ [presentation notes](/slides/ar/php-java/presentation-notes/) و[presentation comments](/slides/ar/php-java/presentation-comments/).

إذا كان تنسيق صفحة الملاحظات مهمًا، تحقق من العرض التقديمي المدمج لأن ماسترات الملاحظات هي كائنات على مستوى العرض وقد تختلف بين ملفات المصدر. في سير عمل المراجعة، تحقق أيضًا من مؤلفي التعليقات وتعليقات السلاسل بعد دمج ملفات من مؤلفين أو قوالب مختلفة.

### **الصور، الصوت، الفيديو، كائنات OLE، والروابط الخارجية**

يمكن للشرائح الرجوع إلى موارد على مستوى العرض مثل الصور، الصوت المدمج، الفيديو المدمج، وبيانات OLE. استنسخ الشريحة نفسها بدلاً من نسخ الأشكال المرئية فقط حتى تتمكن Aspose.Slides من الحفاظ على علاقات الشريحة بمواردها.

يجب معاملة الموارد المدمجة والمربوطة بشكل مختلف. يبقى الصوت أو الفيديو أو كائن OLE أو الرابط الخارجي معتمدًا على هدفه الخارجي؛ استنساخ الشريحة لا يحوِّل الرابط الخارجي إلى محتوى مدمج. اختبر مسارات الموارد المربوطة وعناوين URL في البيئة التي سيفتح فيها العرض المدمج.

تتبع Aspose.Slides الماسترات المستنسخة تلقائيًا، لكن لا ينبغي اعتبار ذلك ضمانًا عامًا بأن الموارد الثنائية المتطابقة من عروض تقديمية مصدرية غير مرتبطة ستتم إزالتها دائمًا. إذا كان حجم ملف الإخراج مهمًا، افحص الحزمة المدمجة وقِس النتيجة بدلاً من الاعتماد على الإزالة الضمنية للتكرارات.

### **الخطوط المدمجة وتوافر الخطوط**

تُدار الخطوط على مستوى العرض التقديمي. إذا كان يجب أن يظل الطباعة ثابتة عبر الأجهزة، لا تفترض أن استنساخ الشرائح وحده يضمن توفر كل خط مطلوب في بيئة الوجهة. يمكنك فحص الخطوط المدمجة باستخدام [FontsManager::getEmbeddedFonts()](https://reference.aspose.com/slides/ar/php-java/aspose.slides/fontsmanager/getembeddedfonts/) وإدارة الدمج صراحةً كما هو موضح في [Embed Fonts in Presentations](/slides/ar/php-java/embedded-font/).

تحقق أيضًا من أنك مسموح لك بدمج الخطوط المستخدمة في ملفات المصدر. قد تقيد تراخيص الخطوط عملية الدمج.

### **العروض التقديمية المحمية بكلمة مرور**

يجب فتح مصدر محمي بكلمة مرور بنجاح قبل أن يمكن استنساخ شرائحه. قدّم كلمة المرور عبر [LoadOptions::setPassword()](https://reference.aspose.com/slides/ar/php-java/aspose.slides/loadoptions/setpassword/).

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

فتح مصدر مشفر لا يطبق الحماية نفسها تلقائيًا على العرض التقديمي الوجهة. اضبط حماية الإخراج بشكل منفصل عند الحاجة.

### **العروض التقديمية الكبيرة واستخدام الذاكرة**

العروض التقديمية الكبيرة التي تحتوي على صور عالية الدقة أو صوت أو فيديو أو كائنات ثنائية كبيرة يمكن أن تستهلك ذاكرة كبيرة. توفر [LoadOptions::getBlobManagementOptions()](https://reference.aspose.com/slides/ar/php-java/aspose.slides/loadoptions/getblobmanagementoptions/) عناصر تحكم لمعالجة BLOB واستخدام ملفات مؤقتة. راجع [Open Presentations](/slides/ar/php-java/open-presentation/#open-large-presentations) للحصول على مثال ملف كبير في PHP عبر Java.

بالنسبة للملفات الكبيرة، يفضَّل التحميل من مسارات الملفات عندما يكون ذلك ممكنًا، حرِّر كل عرض تقديمي مصدر بمجرد الانتهاء من دمجه، وتجنب حفظ النتائج الوسيطة بشكل متكرر ما لم تحتاج سير العمل إلى نقاط تفتيش.

### **سلامة الخيوط**

لا تقم بتحميل أو تعديل أو حفظ أو استنساخ كائنات [Presentation](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/) في عدة خيوط. هذه العمليات غير مدعومة للاستخدام متعدد الخيوط في PHP عبر Java. إذا كنت تحتاج إلى وظائف دمج متوازية، نفّذها في عمليات منفصلة ذات خيط واحد، بحيث يستخدم كل عملية مثيلاتها الخاصة من العروض التقديمية، واتبع إرشادات [Aspose.Slides multithreading guidance](/slides/ar/php-java/multithreading/).

## **FAQ**

**كيف يمكنني الحفاظ على التصميم الأصلي لكل عرض تقديمي مصدر؟**

استخدم [SlideCollection::addClone](https://reference.aspose.com/slides/ar/php-java/aspose.slides/slidecollection/addclone/) دون تمرير ماستر أو تخطيط وجهة. يمكن لـ Aspose.Slides استنساخ الماستر المصدر تلقائيًا عندما تكون بحاجة إليه الشريحة المستوردة.

**كيف أجعل الشرائح المستوردة تستخدم موضوع الوجهة؟**

استخدم التحميل الزائد الذي يقبل ماستر وجهة. مرّر ماسترًا من العرض التقديمي الوجهة، وليس من المصدر. سيحاول Aspose.Slides مطابقة كل شريحة مصدر لتخطيط مناسب تحت ذلك الماستر.

**متى يجب استخدام تخطيط وجهة محدد بدلاً من ماستر وجهة؟**

استخدم تخطيطًا محددًا عندما يجب أن تستخدم كل شريحة مستوردة تخطيطًا معروفًا واحدًا. استخدم ماسترًا عندما تريد أن تختار Aspose.Slides بين تخطيطات ذلك الماستر بناءً على نوع أو اسم التخطيط المصدر.

**هل يمكن دمج عروض تقديمية بأحجام شرائح مختلفة؟**

نعم، ولكن محتوى الشريحة لا يُعاد تصميمه تلقائيًا لأبعاد الوجهة. قم بتغيير حجم العرض التقديمي المصدر أولاً عندما تحتاج إلى موضع ثابت، على سبيل المثال باستخدام [SlideSize::setSize()](https://reference.aspose.com/slides/ar/php-java/aspose.slides/slidesize/setsize/) و[SlideSizeScaleType::EnsureFit](https://reference.aspose.com/slides/ar/php-java/aspose.slides/slidesizescaletype/).

**هل يمكنني دمج ملفات PPT و PPTX و ODP في ملف واحد؟**

نعم. حمّل كل عرض تقديمي مصدر، استنسخ الشرائح المطلوبة إلى عرض تقديمي واحد وجهة، واحفظ الوجهة بصيغة إخراج مدعومة. نظرًا لاختلاف مجموعات الميزات بين صيغ العروض، تحقق من المحتوى المعقد بعد دمج صيغ متعددة. راجع [Supported File Formats](/slides/ar/php-java/supported-file-formats/).

**هل يتم الحفاظ على أقسام المصدر تلقائيًا؟**

ليس عبر حلقة أساسية تستنسخ الشرائح فقط. أعد إنشاء الأقسام المطلوبة في الوجهة واستخدم تحميلًا زائداً لـ [addClone](https://reference.aspose.com/slides/ar/php-java/aspose.slides/slidecollection/addclone/) عندما يجب الحفاظ على هيكل الأقسام.

**هل يتم الحفاظ على ملاحظات المتحدث والتعليقات؟**

يتم نسخها مع الشريحة المستنسخة. بالنسبة لسير العمل الذي يعتمد على تنسيق ماستر الملاحظات، مؤلفي التعليقات، أو بيانات المراجعة المتسلسلة، تحقق من النتيجة المدمجة لأن هذه السيناريوهات تشمل هياكل على مستوى العرض بالإضافة إلى محتوى على مستوى الشريحة.

**ماذا يحدث للملفات الصوتية، الفيديو، كائنات OLE، والروابط التشعبية؟**

يُحمل المحتوى المدمج كجزء من علاقات موارد الشريحة المستنسخة. تبقى الروابط الخارجية خارجية، لذا يجب أن تظل ملفات الهدف أو عناوين URL متاحة بعد الدمج.

**هل الخطوط المدمجة من كل مصدر مضمونة التوفر في العرض المدمج؟**

لا تعتمد على استنساخ الشرائح فقط لنشر الخطوط. افحص الخطوط المدمجة في الوجهة وأدرج الخطوط بشكل صريح أو تأكد من توفر الخطوط الخارجية عندما تكون الطباعة مهمة.

**كيف أدمج ملفًا محميًا بكلمة مرور؟**

افتحه باستخدام [LoadOptions::setPassword()](https://reference.aspose.com/slides/ar/php-java/aspose.slides/loadoptions/setpassword/)، ثم استنسخ شِعاره كالمعتاد. يتم تكوين حماية الإخراج بشكل منفصل.

**كيف أتعامل مع العروض التقديمية الكبيرة جدًا؟**

استخدم إدارة BLOB عندما تهيمن الكائنات الثنائية الكبيرة على استهلاك الذاكرة، وفضّل التحميل من مسار الملف للملفات الضخمة، حرّر عروض المصدر بسرعة بعد دمجها، واحفظ النتيجة النهائية فقط عند الحاجة.

**هل يمكنني دمج شرائح من عدة خيوط؟**

تحميل أو حفظ أو استنساخ كائنات [Presentation](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/) في خيوط متعددة غير مدعوم في PHP عبر Java. للعمليات المتوازية، استخدم عمليات منفصلة ذات خيط واحد، واحفظ مثيلات العروض التقديمية منفصلة داخل كل عملية.