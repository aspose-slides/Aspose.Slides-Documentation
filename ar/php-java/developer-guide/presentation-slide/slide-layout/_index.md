---
title: "تطبيق أو تغيير تخطيطات الشرائح في PHP"
linktitle: "تخطيط الشريحة"
type: docs
weight: 60
url: /ar/php-java/slide-layout/
keywords:
- "تخطيط الشريحة"
- "تخطيط المحتوى"
- "عنصر نائب"
- "تصميم العرض التقديمي"
- "تصميم الشريحة"
- "تخطيط غير مستخدم"
- "رؤية التذييل"
- "شريحة العنوان"
- "العنوان والمحتوى"
- "عنوان القسم"
- "محتوى مزدوج"
- "مقارنة"
- "عنوان فقط"
- "تخطيط فارغ"
- "محتوى مع توضيح"
- "صورة مع توضيح"
- "العنوان والنص العمودي"
- "عنوان عمودي ونص"
- "PowerPoint"
- "OpenDocument"
- "عرض تقديمي"
- "PHP"
- "Aspose.Slides"
description: "تطبيق وإنشاء وتعديل تخطيطات الشرائح في Aspose.Slides لـ PHP عبر Java، إضافة عناصر نائبة، إزالة التخطيطات غير المستخدمة، والتحكم في رؤية التذييل."
---
## **نظرة عامة**

يحدد تخطيط الشريحة المواضع وتنسيق عناصر النائب مثل العناوين والنصوص والصور والمخططات والجداول. تطبيق التخطيط يمنح الشرائح بنية متسقة مع السماح لكل شريحة باحتواء محتواها الخاص.

أكثر التخطيطات شيوعًا تشمل:

- **شريحة العنوان**: يحتوي على عناصر نائب للعنوان والعنوان الفرعي.
- **العنوان والمحتوى**: يحتوي على عنصر نائب للعنوان وعنصر نائب عام للمحتوى.
- **فارغ**: لا يحتوي على أي عناصر نائب للمحتوى ويكون مفيدًا عندما يتم وضع كل شكل يدويًا.

## **فهم وراثة التخطيط**

للعرض التقديمي ثلاثة مستويات متعلقة:

1. [الشريحة الرئيسية](https://reference.aspose.com/slides/ar/php-java/aspose.slides/masterslide/) تحدد السمة، التنسيق المشترك، الخلفيات، والكائنات العامة.
1. [شريحة التخطيط](https://reference.aspose.com/slides/ar/php-java/aspose.slides/layoutslide/) تنتمي إلى شريحة رئيسية وتحدد ترتيبًا معينًا لعناصر النائب.
1. [الشريحة العادية](https://reference.aspose.com/slides/ar/php-java/aspose.slides/slide/) تستخدم تخطيطًا واحدًا وتخزن المحتوى المدخل لتلك الشريحة.

ترث الشريحة العادية السمة والتنسيق من تخطيطها، ويورث التخطيط من الشريحة الرئيسية. القيمة المحددة مباشرةً على الشريحة العادية تتجاوز القيمة الموروثة في ذلك المستوى. عند إنشاء شريحة عادية، تُنشأ أشكال العناصر النائبة من التخطيط المحدد، بينما المحتوى المدخل في تلك العناصر النائبة يخص الشريحة العادية.

أضف العناصر النائبة المطلوبة إلى تخطيط قبل إنشاء الشرائح منه. إضافة عنصر نائب آخر إلى تخطيط لاحقًا لا يضيف تلقائيًا شكل عنصر نائب مماثل إلى الشرائح العادية الموجودة.

هذه العلاقة لها نتيجتين مهمتين:

- تغيير التنسيق الموروث أو شكل عناصر النائب الموجودة على تخطيط يمكن أن يُحدّث كل شريحة تعتمد عليه. قبل تعديل تخطيط يُستَخدم بالفعل، راقب الشرائح التابعة له وراجع العرض الناتج.
- لا يمكن إزالة تخطيط لا يزال مستخدمًا من قبل شريحة. أعد تعيين الشرائح التابعة له إلى تخطيط آخر أولاً، أو احذف فقط التخطيطات غير المستخدمة.

لمزيد من المعلومات حول المستوى الأعلى من هذه الهرمية، انظر إلى [الشريحة الرئيسية](/slides/ar/php-java/slide-master/).

## **اختيار وتطبيق تخطيط الشريحة**

استخدم نوع التخطيط عندما يتبع العرض تعريفات تخطيط PowerPoint القياسية. أسماء التخطيطات قابلة للتحرير من قبل المستخدم ويمكن توطينها، لذا فإن الاختيار بناءً على الاسم أقل موثوقية إلا إذا كنت تتحكم في القالب المصدر.

المثال التالي يبحث عن **العنوان والمحتوى** في أول شريحة رئيسية. إذا كان ذلك التخطيط غير متاح، فإنه يتراجع عمدًا إلى **فارغ**. الفحص الثاني للـ null ضروري لأن العرض قد يحتوي فقط على تخطيطات مخصصة. ثم يُطبق التخطيط المختار على أول شريحة عادية عبر طريقة [Slide.setLayoutSlide](https://reference.aspose.com/slides/ar/php-java/aspose.slides/slide/#setLayoutSlide).

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideLayoutType;

$presentation = new Presentation("input.pptx");
try {
    $layoutSlides = $presentation->getMasters()->get_Item(0)->getLayoutSlides();
    $targetLayout = $layoutSlides->getByType(SlideLayoutType::TitleAndObject);

    if (java_is_null($targetLayout)) {
        $targetLayout = $layoutSlides->getByType(SlideLayoutType::Blank);
    }

    if (java_is_null($targetLayout)) {
        throw new \RuntimeException("The first master does not contain a suitable layout slide.");
    }

    $presentation->getSlides()->get_Item(0)->setLayoutSlide($targetLayout);
    $presentation->save("output-with-new-layout.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

تغيير تخطيط الشريحة لا يزيل الأشكال العادية المضافة مباشرةً إلى الشريحة. ومع ذلك، قد تتغير مواضع العناصر النائبة، التنسيق الموروث، والارتباط بين العناصر النائبة الموجودة والتخطيط الجديد، لذا راقب النتيجة عند التبديل بين تخطيطات مختلفة بشكل كبير.

## **إضافة شريحة تخطيط**

الاختيار والإنشاء عمليتان منفصلتان. المثال السابق يختار تخطيطًا موجودًا؛ لا ينشئ واحدًا. لإنشاء تخطيط، استدعِ طريقة [MasterLayoutSlideCollection.add](https://reference.aspose.com/slides/ar/php-java/aspose.slides/masterlayoutslidecollection/#add) على مجموعة تخطيطات الشريحة الرئيسية المستهدفة.

المثال التالي يضيف دائمًا تخطيطًا جديدًا **العنوان والمحتوى** باسم `Report Title and Content`، ثم يضيف شريحة عادية بناءً عليه. يجب أن تكون أسماء التخطيط فريدة داخل المجموعة.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideLayoutType;

$presentation = new Presentation("input.pptx");
try {
    $masterSlide = $presentation->getMasters()->get_Item(0);
    $reportLayout = $masterSlide->getLayoutSlides()->add(SlideLayoutType::TitleAndObject, "Report Title and Content");
    $presentation->getSlides()->addEmptySlide($reportLayout);

    $presentation->save("output-with-report-layout.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

أضف تخطيطًا فقط عندما يحتاج القالب فعلاً إلى بنية قابلة لإعادة الاستخدام. إذا كان هناك تخطيط مناسب موجودًا بالفعل، فاختره واستخدمه بدلاً من إنشاء نسخة مكررة.

## **إضافة عناصر نائب إلى شريحة تخطيط**

توفر طريقة [LayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/ar/php-java/aspose.slides/layoutslide/#getPlaceholderManager) كائنًا من نوع [LayoutPlaceholderManager](https://reference.aspose.com/slides/ar/php-java/aspose.slides/layoutplaceholdermanager/) لإضافة أشكال عناصر نائب إلى تخطيط.

| عنصر نائب PowerPoint               | `LayoutPlaceholderManager` Method |
| ----------------------------------- | --------------------------------- |
| ![محتوى](content.png)               | [`addContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ar/php-java/aspose.slides/layoutplaceholdermanager/#addContentPlaceholder) |
| ![محتوى (عمودي)](contentV.png)     | [`addVerticalContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ar/php-java/aspose.slides/layoutplaceholdermanager/#addVerticalContentPlaceholder) |
| ![نص](text.png)                     | [`addTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ar/php-java/aspose.slides/layoutplaceholdermanager/#addTextPlaceholder) |
| ![نص (عمودي)](textV.png)           | [`addVerticalTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ar/php-java/aspose.slides/layoutplaceholdermanager/#addVerticalTextPlaceholder) |
| ![صورة](picture.png)                | [`addPicturePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ar/php-java/aspose.slides/layoutplaceholdermanager/#addPicturePlaceholder) |
| ![مخطط](chart.png)                  | [`addChartPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ar/php-java/aspose.slides/layoutplaceholdermanager/#addChartPlaceholder) |
| ![جدول](table.png)                  | [`addTablePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ar/php-java/aspose.slides/layoutplaceholdermanager/#addTablePlaceholder) |
| ![SmartArt](smartart.png)           | [`addSmartArtPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ar/php-java/aspose.slides/layoutplaceholdermanager/#addSmartArtPlaceholder) |
| ![وسائط](media.png)                 | [`addMediaPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ar/php-java/aspose.slides/layoutplaceholdermanager/#addMediaPlaceholder) |
| ![صورة عبر الإنترنت](onlineImage.png) | [`addOnlineImagePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ar/php-java/aspose.slides/layoutplaceholdermanager/#addOnlineImagePlaceholder) |

يتحقق المثال التالي من وجود تخطيط **فارغ**، يضيف إليه أربعة عناصر نائب، ثم ينشئ شريحة عادية تستخدم التخطيط المعدل. الترتيب مقصود: تُضاف العناصر النائبة قبل إنشاء الشريحة العادية، بحيث يمكن Aspose.Slides توليد أشكال العناصر النائبة المقابلة على تلك الشريحة.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideLayoutType;

$presentation = new Presentation();
try {
    $blankLayout = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Blank);

    if (java_is_null($blankLayout)) {
        throw new \RuntimeException("The presentation does not contain a Blank layout slide.");
    }

    $placeholderManager = $blankLayout->getPlaceholderManager();
    $placeholderManager->addContentPlaceholder(20, 20, 310, 270);
    $placeholderManager->addVerticalTextPlaceholder(350, 20, 350, 270);
    $placeholderManager->addChartPlaceholder(20, 310, 310, 180);
    $placeholderManager->addTablePlaceholder(350, 310, 350, 180);

    $presentation->getSlides()->addEmptySlide($blankLayout);
    $presentation->save("output-with-placeholders.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

النتيجة:

![العناصر النائبة على شريحة التخطيط](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
تغيير التنسيق الموروث أو شكل عناصر النائب الموجودة على التخطيط يمكن أن يؤثر على الشرائح التابعة. العنصر النائب المضاف حديثًا لا يُملأ تلقائيًا في الشرائح العادية الموجودة. اختبر تغييرات التخطيط على نسخة من العرض وراجع كل شريحة تابعة.
{{% /alert %}}

## **إزالة شرائح التخطيط غير المستخدمة**

استخدم طريقة [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/ar/php-java/aspose.slides/compress/#removeUnusedLayoutSlides) لإزالة التخطيطات التي لا تُشير إليها أي شريحة عادية. تبقي الطريقة التخطيطات التي لا تزال قيد الاستخدام دون تعديل.

```php
use aspose\slides\Compress;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("input.pptx");
try {
    Compress::removeUnusedLayoutSlides($presentation);
    $presentation->save("output-without-unused-layouts.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

لإزالة تخطيط محدد، استخدم أولاً طريقتي [hasDependingSlides](https://reference.aspose.com/slides/ar/php-java/aspose.slides/layoutslide/#hasDependingSlides) أو [getDependingSlides](https://reference.aspose.com/slides/ar/php-java/aspose.slides/layoutslide/#getDependingSlides). أعد تعيين أي شرائح تابعة قبل استدعاء [LayoutSlide.remove](https://reference.aspose.com/slides/ar/php-java/aspose.slides/layoutslide/#remove). محاولة إزالة تخطيط مستخدم تُثير استثناءً من نوع [PptxEditException](https://reference.aspose.com/slides/ar/php-java/aspose.slides/pptxeditexception/).

## **التحكم في رؤية تذييل الصفحة على شريحة التخطيط**

للتخطيط لديه تذييل خاص به، وعناصر نائب لرقم الشريحة وتاريخ/وقت. استخدم طريقة [LayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/ar/php-java/aspose.slides/layoutslide/#getHeaderFooterManager) للتحكم في تلك العناصر النائبة لتخطيط واحد. هذا مفيد عندما، على سبيل المثال، يجب أن تُظهر تخطيطات المحتوى التذييلات لكن لا ينبغي لتخطيطات العنوان إظهارها.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideLayoutType;

$presentation = new Presentation("input.pptx");
try {
    $layoutSlide = $presentation->getLayoutSlides()->getByType(SlideLayoutType::TitleAndObject);

    if (java_is_null($layoutSlide)) {
        $layoutSlide = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Blank);
    }

    if (java_is_null($layoutSlide)) {
        throw new \RuntimeException("The presentation does not contain a suitable layout slide.");
    }

    $headerFooterManager = $layoutSlide->getHeaderFooterManager();
    $headerFooterManager->setFooterVisibility(true);
    $headerFooterManager->setSlideNumberVisibility(true);
    $headerFooterManager->setDateTimeVisibility(true);
    $headerFooterManager->setFooterText("Footer text");
    $headerFooterManager->setDateTimeText("Date and time text");

    $presentation->save("output-with-layout-footers.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **التحكم في رؤية تذييل الصفحة على الشريحة الرئيسية وتخطيطاتها الفرعية**

لتطبيق إعدادات تذييل متسقة عبر هيكل شريحة رئيسية، استخدم طريقة [MasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/ar/php-java/aspose.slides/masterslide/#getHeaderFooterManager). تعمل طرق النشر الخاصة بـ [MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/ar/php-java/aspose.slides/masterslideheaderfootermanager/) على الشريحة الرئيسية وتخطيطاتها التابعة والشرائح العادية؛ فهي لا تستهدف شريحة عادية واحدة فقط.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("input.pptx");
try {
    $headerFooterManager = $presentation->getMasters()->get_Item(0)->getHeaderFooterManager();
    $headerFooterManager->setFooterAndChildFootersVisibility(true);
    $headerFooterManager->setSlideNumberAndChildSlideNumbersVisibility(true);
    $headerFooterManager->setDateTimeAndChildDateTimesVisibility(true);
    $headerFooterManager->setFooterAndChildFootersText("Footer text");
    $headerFooterManager->setDateTimeAndChildDateTimesText("Date and time text");

    $presentation->save("output-with-master-footers.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **الأسئلة المتكررة**

**ما الفرق بين الشريحة الرئيسية وشريحة التخطيط؟**

تحدد الشريحة الرئيسية سمة العرض التقديمي وتنسيقها المشترك. شريحة التخطيط تنتمي إلى شريحة رئيسية وتحدد ترتيبًا قابلًا لإعادة الاستخدام لعناصر النائب. تستخدم الشرائح العادية تلك التخطيطات وتخزن محتوىًا خاصًا بكل شريحة.

**هل يمكنني نسخ شريحة تخطيط من عرض تقديمي إلى آخر؟**

نعم. أضف نسخة إلى مجموعة الوجهة باستخدام طريقة [addClone](https://reference.aspose.com/slides/ar/php-java/aspose.slides/globallayoutslidecollection/#addClone). عند النسخ بين العروض، تحقق أيضًا من الخطوط والسمات والصور وغيرها من الموارد المستخدمة في التخطيط المصدر.

**ماذا يحدث عندما أقوم بتعديل تخطيط قيد الاستخدام بالفعل؟**

ترث الشرائح التابعة تغييرات التخطيط ما لم تكن قد تجاوزت التنسيق أو الكائنات المتأثرة محليًا. يمكن أن يتغير شكل عناصر النائب والتنسيق الموروث على العديد من الشرائح مرةً واحدة. استخدم [getDependingSlides](https://reference.aspose.com/slides/ar/php-java/aspose.slides/layoutslide/#getDependingSlides) لتحديد الشرائح المتأثرة قبل تعديل التخطيط.

**ماذا يحدث إذا قمت بإزالة تخطيط لا يزال قيد الاستخدام؟**

تثير Aspose.Slides استثناءً من نوع [PptxEditException](https://reference.aspose.com/slides/ar/php-java/aspose.slides/pptxeditexception/). أعد تعيين الشرائح التابعة أولاً، أو استخدم طريقة [removeUnusedLayoutSlides](https://reference.aspose.com/slides/ar/php-java/aspose.slides/compress/#removeUnusedLayoutSlides) لإزالة التخطيطات غير المرجعية فقط.