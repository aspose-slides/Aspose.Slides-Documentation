---
title: تطبيق أو تغيير تخطيطات الشرائح في PHP
linktitle: تخطيط الشريحة
type: docs
weight: 60
url: /ar/php-java/slide-layout/
keywords:
- تخطيط الشرائح
- تخطيط المحتوى
- عنصر نائب
- تصميم العرض التقديمي
- تصميم الشريحة
- تخطيط غير مستخدم
- رؤية التذييل
- شريحة عنوان
- عنوان ومحتوى
- رأس القسم
- محتوى مزدوج
- مقارنة
- عنوان فقط
- تخطيط فارغ
- محتوى مع توضيح
- صورة مع توضيح
- عنوان ونص عمودي
- عنوان عمودي ونص
- PowerPoint
- OpenDocument
- عرض تقديمي
- PHP
- Aspose.Slides
description: "تطبيق وإنشاء وتعديل تخطيطات الشرائح في Aspose.Slides لـ PHP عبر Java، إضافة عناصر نائب، إزالة التخطيطات غير المستخدمة، والتحكم في رؤية التذييل."
---
## **نظرة عامة**

تعرف تخطيط الشريحة مواضع وتنسيق عناصر نائب مثل العناوين والنصوص والصور والرسوم البيانية والجداول. تطبيق تخطيط يمنح الشرائح بنية متسقة مع السماح لكل شريحة بأن تحتوي على محتواها الخاص.

أكثر التخطيطات شيوعًا تشمل:

- **شريحة عنوان**: تحتوي على عناصر نائب للعنوان والعنوان الفرعي.
- **العنوان والمحتوى**: تحتوي على عنصر نائب للعنوان وعنصر نائب للمحتوى العام.
- **فارغة**: لا تحتوي على أي عناصر نائب للمحتوى وتكون مفيدة عندما يتم وضع كل شكل يدوياً.

## **فهم وراثة التخطيط**

العرض التقديمي له ثلاث مستويات ذات صلة:

1. شريحة [رئيسية](https://reference.aspose.com/slides/ar/php-java/aspose.slides/masterslide/) تعرف السمة والتنسيق المشترك والخلفيات والكائنات العامة.
2. شريحة [تخطيط](https://reference.aspose.com/slides/ar/php-java/aspose.slides/layoutslide/) تنتمي إلى رئيسية وتحدد ترتيبًا معينًا لعناصر النايب.
3. شريحة [عادية](https://reference.aspose.com/slides/ar/php-java/aspose.slides/slide/) تستخدم تخطيطًا واحدًا وتخزن المحتوى الذي تم إدخاله لتلك الشريحة.

تَورِث الشريحة العادية السمة والتنسيق من التخطيط الخاص بها، ويتوارث التخطيط من رئيسيته. القيمة التي تُحدَّد مباشرةً على الشريحة العادية تتجاوز القيمة الموروثة في هذا المستوى. عند إنشاء شريحة عادية، تُنشأ أشكال عناصر النايب من التخطيط المحدد، بينما يخص المحتوى المدخل في تلك العناصر الشريحة العادية نفسها.

أضف عناصر نائب مطلوبة إلى التخطيط قبل إنشاء الشرائح منه. إضافة عنصر نائب آخر إلى التخطيط لاحقًا لا يضيف شكل عنصر نائب مقابل إلى الشرائح العادية الموجودة تلقائيًا.

هذه العلاقة لها نتيجتين مهمتين:

- تغيير التنسيق الموروث أو الشكل الهندسي لعناصر النايب الموجودة على التخطيط يمكن أن يُحدِّث كل شريحة تعتمد عليه. قبل تعديل تخطيط يُستخدم بالفعل، افحص الشرائح التابعة له واستعرض العرض الناتج.
- لا يمكن إزالة تخطيط لا يزال مستخدمًا من قبل شريحة. أعد تعيين الشرائح التابعة له إلى تخطيط آخر أولًا، أو احذف فقط التخطيطات غير المستخدمة.

لمزيد من المعلومات حول المستوى الأعلى من هذه الهرمية، راجع [الشريحة الرئيسية](/slides/ar/php-java/slide-master/).

لإخفاء الشعارات الموروثة أو الأشكال الزخرفية الرئيسية على شريحة واحدة أو عبر تخطيط مشترك، راجع [التحكم في رؤية الرسومات الرئيسية](/slides/ar/php-java/slide-master/). المقارنة توضح شريحتين تستخدمان نفس الرئيسية.

## **اختيار وتطبيق تخطيط الشريحة**

استخدم نوع تخطيط عندما يتبع العرض التقديمي تعريفات تخطيطات PowerPoint القياسية. أسماء التخطيطات يمكن تحريرها من قبل المستخدم ويمكن تعريبها، لذا يكون الاختيار القائم على الاسم أقل موثوقية ما لم تتحكم في القالب المصدر.

المثال التالي يبحث عن **Title and Content** في الأولى من الرئيسيات. إذا كان ذلك التخطيط غير متوفر، فإنه يعود عمداً إلى **Blank**. الفحص الثاني للخطأ `null` ضروري لأن العرض التقديمي قد يحتوي فقط على تخطيطات مخصصة. ثم يُطبق التخطيط المحدد على الشريحة العادية الأولى عبر طريقة [Slide.setLayoutSlide](https://reference.aspose.com/slides/ar/php-java/aspose.slides/slide/#setLayoutSlide).

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

تغيير تخطيط شريحة لا يزيل الأشكال العادية المضافة مباشرةً إلى الشريحة. ومع ذلك، قد تتغير مواضع عناصر النايب، التنسيق الموروث، والارتباط بين العناصر الحالية والتخطيط الجديد، لذا تحقق من الناتج عند التبديل بين تخطيطات مختلفة بشكل كبير.

## **إضافة شريحة تخطيط**

الاختيار والإنشاء عمليتان منفصلتان. المثال السابق يختار تخطيطًا موجودًا؛ لا ينشئ واحدًا. لإنشاء تخطيط، استدعِ طريقة [MasterLayoutSlideCollection.add](https://reference.aspose.com/slides/ar/php-java/aspose.slides/masterlayoutslidecollection/#add) على مجموعة تخطيطات الرئيسة المستهدفة.

المثال التالي يضيف دائمًا تخطيطًا جديدًا **Title and Content** باسم `Report Title and Content`، ثم يضيف شريحة عادية تعتمد عليه. يجب أن تكون أسماء التخطيطات فريدة داخل المجموعة.

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

أضف تخطيطًا فقط عندما يحتاج القالب فعليًا إلى هيكل قابل لإعادة الاستخدام آخر. إذا كان تخطيط مناسب موجودًا بالفعل، فاختره وأعد استخدامه بدلًا من إنشاء مكرر.

## **إضافة عناصر نائب إلى شريحة تخطيط**

توفر طريقة [LayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/ar/php-java/aspose.slides/layoutslide/#getPlaceholderManager) كائنًا من نوع [LayoutPlaceholderManager](https://reference.aspose.com/slides/ar/php-java/aspose.slides/layoutplaceholdermanager/) لإضافة أشكال عناصر نائب إلى تخطيط.

| عنصر نائب في PowerPoint | طريقة `LayoutPlaceholderManager` |
| ----------------------- | --------------------------------- |
| ![المحتوى](content.png) | [`addContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ar/php-java/aspose.slides/layoutplaceholdermanager/#addContentPlaceholder) |
| ![المحتوى (عمودي)](contentV.png) | [`addVerticalContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ar/php-java/aspose.slides/layoutplaceholdermanager/#addVerticalContentPlaceholder) |
| ![نص](text.png) | [`addTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ar/php-java/aspose.slides/layoutplaceholdermanager/#addTextPlaceholder) |
| ![نص (عمودي)](textV.png) | [`addVerticalTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ar/php-java/aspose.slides/layoutplaceholdermanager/#addVerticalTextPlaceholder) |
| ![صورة](picture.png) | [`addPicturePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ar/php-java/aspose.slides/layoutplaceholdermanager/#addPicturePlaceholder) |
| ![مخطط](chart.png) | [`addChartPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ar/php-java/aspose.slides/layoutplaceholdermanager/#addChartPlaceholder) |
| ![جدول](table.png) | [`addTablePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ar/php-java/aspose.slides/layoutplaceholdermanager/#addTablePlaceholder) |
| ![SmartArt](smartart.png) | [`addSmartArtPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ar/php-java/aspose.slides/layoutplaceholdermanager/#addSmartArtPlaceholder) |
| ![وسائط](media.png) | [`addMediaPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ar/php-java/aspose.slides/layoutplaceholdermanager/#addMediaPlaceholder) |
| ![صورة عبر الإنترنت](onlineImage.png) | [`addOnlineImagePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/ar/php-java/aspose.slides/layoutplaceholdermanager/#addOnlineImagePlaceholder) |

المثال التالي يتحقق من وجود تخطيط **Blank**، يضيف أربعة عناصر نائب إليه، ثم ينشئ شريحة عادية تستخدم التخطيط المعدّل. الترتيب مقصود: تُضاف عناصر النايب قبل إنشاء الشريحة العادية، بحيث يمكن Aspose.Slides توليد أشكال عناصر النايب المقابلة على تلك الشريحة.

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

![عناصر نائب على شريحة التخطيط](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
تغيير التنسيق الموروث أو الشكل الهندسي لعناصر النايب الحالية في التخطيط يمكن أن يؤثر على الشرائح التابعة. العنصر النايب المضاف حديثًا لا يُملأ تلقائيًا في الشرائح العادية الموجودة. اختبر تغييرات التخطيط على نسخة من العرض التقديمي وتفقد كل شريحة تابعة.
{{% /alert %}}

## **إزالة شرائح التخطيط غير المستخدمة**

استخدم طريقة [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/ar/php-java/aspose.slides/compress/#removeUnusedLayoutSlides) لإزالة التخطيطات التي لا تشير إليها أي شريحة عادية. تترك الطريقة التخطيطات التي لا تزال قيد الاستخدام غير متأثرة.

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

لإزالة تخطيط محدد، استخدم أولاً طريقة [hasDependingSlides](https://reference.aspose.com/slides/ar/php-java/aspose.slides/layoutslide/#hasDependingSlides) أو [getDependingSlides](https://reference.aspose.com/slides/ar/php-java/aspose.slides/layoutslide/#getDependingSlides). أعد تعيين أي شرائح تابعة قبل استدعاء طريقة [LayoutSlide.remove](https://reference.aspose.com/slides/ar/php-java/aspose.slides/layoutslide/#remove). محاولة إزالة تخطيط مستخدم تُسبب استثناءً من النوع [PptxEditException](https://reference.aspose.com/slides/ar/php-java/aspose.slides/pptxeditexception/).

## **التحكم في رؤية تذييل الصفحة على شريحة التخطيط**

يحتوي التخطيط على تذييل خاص به، ورقم شريحة، وعناصر نائب للتاريخ والوقت. استخدم طريقة [LayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/ar/php-java/aspose.slides/layoutslide/#getHeaderFooterManager) للتحكم في تلك العناصر الناِبة لتخطيط واحد. هذا مفيد عندما يجب أن تظهر تذييلات في تخطيطات المحتوى ولكن لا تظهر في تخطيطات العنوان.

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

لتطبيق إعدادات تذييل متسقة عبر تسلسل هرمي للرئيسية، استخدم طريقة [MasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/ar/php-java/aspose.slides/masterslide/#getHeaderFooterManager). تعمل طرق انتشار [MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/ar/php-java/aspose.slides/masterslideheaderfootermanager/) على الرئيسة وتخطيطاتها التابعة والشرائح العادية؛ لا تستهدف شريحة عادية واحدة فقط.

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

تعرف الشريحة الرئيسية سمة العرض التقديمي والتنسيق المشترك. تنتمي شريحة التخطيط إلى شريحة رئيسية وتحدد ترتيبًا قابلاً لإعادة الاستخدام لعناصر النايب. تستخدم الشرائح العادية تلك التخطيطات وتخزن محتوى الشريحة المحدد.

**هل يمكنني نسخ شريحة تخطيط من عرض تقديمي إلى آخر؟**

نعم. أضف نسخة إلى المجموعة الوجهة باستخدام طريقة [addClone](https://reference.aspose.com/slides/ar/php-java/aspose.slides/globallayoutslidecollection/#addClone). عند النسخ بين العروض التقديمية، تحقق أيضًا من الخطوط، السمات، الصورا، والموارد الأخرى المستخدمة في التخطيط المصدر.

**ماذا يحدث عندما أقوم بتعديل تخطيط يستخدمه عرض تقديمي؟**

تورّث الشرائح التابعة تغييرات التخطيط ما لم تقم بتجاوز التنسيق أو الكائنات المتأثرة محليًا. قد يتغيّر الشكل الهندسي وعناصر التصميم الموروثة على العديد من الشرائح دفعة واحدة. استخدم طريقة [getDependingSlides](https://reference.aspose.com/slides/ar/php-java/aspose.slides/layoutslide/#getDependingSlides) لتحديد الشرائح المتأثرة قبل تعديل التخطيط.

**ماذا يحدث إذا حاولت إزالة تخطيط لا يزال قيد الاستخدام؟**

تطلق Aspose.Slides استثناءً من النوع [PptxEditException](https://reference.aspose.com/slides/ar/php-java/aspose.slides/pptxeditexception/). أعد تعيين الشرائح التابعة أولًا، أو استخدم طريقة [removeUnusedLayoutSlides](https://reference.aspose.com/slides/ar/php-java/aspose.slides/compress/#removeUnusedLayoutSlides) لإزالة التخطيطات غير المشار إليها فقط.