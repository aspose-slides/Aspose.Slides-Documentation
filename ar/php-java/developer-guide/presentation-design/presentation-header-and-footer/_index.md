---
title: إدارة رؤوس وتذييلات العرض التقديمي في PHP
linktitle: الترويس والتذييل
type: docs
weight: 140
url: /ar/php-java/presentation-header-and-footer/
keywords:
- ترويس
- نص الترويس
- تذييل
- نص التذييل
- تعيين الترويس
- تعيين التذييل
- نشرة
- ملاحظات
- PowerPoint
- OpenDocument
- عرض تقديمي
- PHP
- Aspose.Slides
description: "تعلم كيفية إدارة عناصر النائب للتذييل، التاريخ-الوقت، رقم الشريحة، والترويس على الشرائح، صفحات الملاحظات، والنشرات باستخدام Aspose.Slides للـ PHP عبر Java."
---
## **نظرة عامة**

يستخدم PowerPoint عناصر نائب مختلفة للترويس والتذييل اعتمادًا على نوع الصفحة. يتيح Aspose.Slides for PHP عبر Java التحكم في النص ورؤية هذه العناصر النائبة من خلال فئات مدير الترويس/التذييل.

تختلف العناصر النائبة المتاحة بحسب النطاق:

| النطاق | الترويس | التذييل | التاريخ/الوقت | رقم الشريحة/الصفحة |
|---|---|---|---|---|
| شريحة عادية | لا | نعم | نعم | نعم |
| قالب ملاحظات أساسي | نعم | نعم | نعم | نعم |
| شريحة ملاحظات | نعم | نعم | نعم | نعم |
| قالب النسخة المطبوعة أساسي | نعم | نعم | نعم | نعم |

الشريحة العادية في العرض لا تحتوي على عنصر نائب للترويس. تتوفر عناصر الترويس في صفحات الملاحظات والنسخ المطبوعة. بالنسبة للشرائح العادية، استخدم عناصر التذييل، التاريخ/الوقت، ورقم الشريحة بدلاً من ذلك.

يعتمد نطاق التغيّر على المدير الذي تستخدمه. تتحكم الفئة [`SlideHeaderFooterManager`](https://reference.aspose.com/slides/ar/php-java/aspose.slides/slideheaderfootermanager/) في شريحة عادية واحدة. تتحكم الفئة [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/ar/php-java/aspose.slides/notesslideheaderfootermanager/) في شريحة ملاحظات واحدة. يمكن لمديري القالب والتخطيط أيضًا نشر الإعدادات إلى الشرائح التابعة، بينما تتحكم الفئة [`MasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/ar/php-java/aspose.slides/masterhandoutslideheaderfootermanager/) في قالب النسخة المطبوعة.

## **تعيين التذييل، التاريخ/الوقت، وأرقام الشرائح على الشرائح العادية**

بالنسبة للشرائح العادية، سير العمل الأساسي هو الوصول إلى مدير الترويس/التذييل لكل شريحة، تعيين نص التذييل والتاريخ/الوقت، تمكين العناصر النائبة المطلوبة، ثم حفظ العرض. يتم إنشاء أرقام الشرائح تلقائيًا من قبل العرض، لذا تحتاج فقط إلى التحكم في رؤيتها.

استخدم [`setFooterText`](https://reference.aspose.com/slides/ar/php-java/aspose.slides/baseslideheaderfootermanager/setfootertext/) و[`setDateTimeText`](https://reference.aspose.com/slides/ar/php-java/aspose.slides/baseslideheaderfootermanager/setdatetimetext/) لتعيين النص، واستخدم [`setFooterVisibility`](https://reference.aspose.com/slides/ar/php-java/aspose.slides/baseslideheaderfootermanager/setfootervisibility/)، [`setDateTimeVisibility`](https://reference.aspose.com/slides/ar/php-java/aspose.slides/baseslideheaderfootermanager/setdatetimevisibility/)، و[`setSlideNumberVisibility`](https://reference.aspose.com/slides/ar/php-java/aspose.slides/baseslideheaderfootermanager/setslidenumbervisibility/) لإظهار العناصر النائبة المقابلة.

المثال التالي يطبق نفس التذييل، نص التاريخ/الوقت، ورؤية رقم الشريحة على جميع الشرائح العادية:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
try {
    foreach ($presentation->getSlides() as $slide) {
        $headerFooterManager = $slide->getHeaderFooterManager();

        $headerFooterManager->setFooterText("Company Confidential");
        $headerFooterManager->setFooterVisibility(true);

        $headerFooterManager->setDateTimeText("Date and time text");
        $headerFooterManager->setDateTimeVisibility(true);

        $headerFooterManager->setSlideNumberVisibility(true);
    }

    $presentation->save("presentation_with_slide_footers.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

إذا كنت تحتاج إلى تعديل شريحة واحدة فقط، يمكنك الوصول إلى تلك الشريحة مباشرة عبر طريقة [`getSlides`](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/getslides/) بدلاً من التكرار عبر المجموعة بالكامل.

## **تعيين الترويس والتذييل على قالب ملاحظات أساسي**

يحدد قالب الملاحظات التنسيق المشترك وسلوك العناصر النائبة لصفحات الملاحظات. استخدم الفئة [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/ar/php-java/aspose.slides/masternotesslideheaderfootermanager/) عندما تريد تعديل قالب الملاحظات الأساسي فقط.

المثال التالي يعيّن الترويس، التذييل، ونص التاريخ/الوقت على قالب الملاحظات ويجعل جميع العناصر النائبة المدعومة مرئية على ذلك القالب:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
try {
    $masterNotesSlide = $presentation->getMasterNotesSlideManager()->getMasterNotesSlide();

    if (!java_is_null($masterNotesSlide)) {
        $headerFooterManager = $masterNotesSlide->getHeaderFooterManager();

        $headerFooterManager->setHeaderText("Notes header");
        $headerFooterManager->setHeaderVisibility(true);

        $headerFooterManager->setFooterText("Notes footer");
        $headerFooterManager->setFooterVisibility(true);

        $headerFooterManager->setDateTimeText("Date and time text");
        $headerFooterManager->setDateTimeVisibility(true);

        $headerFooterManager->setSlideNumberVisibility(true);
    }

    $presentation->save("presentation_with_notes_master_footers.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

طريقة [`getMasterNotesSlide`](https://reference.aspose.com/slides/ar/php-java/aspose.slides/masternotesslidemanager/getmasternotesslide/) تُعيد `null` عندما لا يحتوي العرض على قالب ملاحظات أساسي.

## **تطبيق إعدادات قالب الملاحظات على شرائح الملاحظات التابعة**

يمكن لقالب الملاحظات تطبيق إعدادات الترويس والتذييل على نفسه وعلى جميع شرائح الملاحظات التابعة. استخدم أساليب النشر المتخصصة على [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/ar/php-java/aspose.slides/masternotesslideheaderfootermanager/) عندما يجب تطبيق نفس الإعدادات عبر هيكل الملاحظات.

على سبيل المثال، تقوم كل من [`setHeaderAndChildHeadersText`](https://reference.aspose.com/slides/ar/php-java/aspose.slides/masternotesslideheaderfootermanager/setheaderandchildheaderstext/) و[`setHeaderAndChildHeadersVisibility`](https://reference.aspose.com/slides/ar/php-java/aspose.slides/masternotesslideheaderfootermanager/setheaderandchildheadersvisibility/) بتحديث ترويس قالب الملاحظات وجميع الترويسات التابعة. تتوفر أساليب مماثلة للتذييل، التاريخ/الوقت، وأرقام الشرائح.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
try {
    $masterNotesSlide = $presentation->getMasterNotesSlideManager()->getMasterNotesSlide();

    if (!java_is_null($masterNotesSlide)) {
        $headerFooterManager = $masterNotesSlide->getHeaderFooterManager();

        $headerFooterManager->setHeaderAndChildHeadersText("Notes header");
        $headerFooterManager->setHeaderAndChildHeadersVisibility(true);

        $headerFooterManager->setFooterAndChildFootersText("Notes footer");
        $headerFooterManager->setFooterAndChildFootersVisibility(true);

        $headerFooterManager->setDateTimeAndChildDateTimesText("Date and time text");
        $headerFooterManager->setDateTimeAndChildDateTimesVisibility(true);

        $headerFooterManager->setSlideNumberAndChildSlideNumbersVisibility(true);
    }

    $presentation->save("presentation_with_child_notes_footers.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

أساليب النشر المستخدمة أعلاه هي [`setFooterAndChildFootersText`](https://reference.aspose.com/slides/ar/php-java/aspose.slides/masternotesslideheaderfootermanager/setfooterandchildfooterstext/)، [`setFooterAndChildFootersVisibility`](https://reference.aspose.com/slides/ar/php-java/aspose.slides/masternotesslideheaderfootermanager/setfooterandchildfootersvisibility/)، [`setDateTimeAndChildDateTimesText`](https://reference.aspose.com/slides/ar/php-java/aspose.slides/masternotesslideheaderfootermanager/setdatetimeandchilddatetimestext/)، [`setDateTimeAndChildDateTimesVisibility`](https://reference.aspose.com/slides/ar/php-java/aspose.slides/masternotesslideheaderfootermanager/setdatetimeandchilddatetimesvisibility/)، و[`setSlideNumberAndChildSlideNumbersVisibility`](https://reference.aspose.com/slides/ar/php-java/aspose.slides/masternotesslideheaderfootermanager/setslidenumberandchildslidenumbersvisibility/).

## **تعيين الترويس والتذييل على شريحة ملاحظات فردية**

تنتمي شريحة الملاحظات إلى شريحة عادية محددة. استخدم فئة [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/ar/php-java/aspose.slides/notesslideheaderfootermanager/) عندما تريد تخصيص تلك الصفحة الملاحظة فقط.

طريقة [`addNotesSlide`](https://reference.aspose.com/slides/ar/php-java/aspose.slides/notesslidemanager/addnotesslide/) تُعيد شريحة الملاحظات للشريحة الحالية وتُنشئ واحدة إذا لم تكن موجودة مسبقًا. المثال التالي يكوّن صفحة الملاحظات المرتبطة بأول شريحة في العرض:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $notesSlide = $slide->getNotesSlideManager()->addNotesSlide();
    $headerFooterManager = $notesSlide->getHeaderFooterManager();

    $headerFooterManager->setHeaderText("Header for the first notes page");
    $headerFooterManager->setHeaderVisibility(true);

    $headerFooterManager->setFooterText("Footer for the first notes page");
    $headerFooterManager->setFooterVisibility(true);

    $headerFooterManager->setDateTimeText("Date and time text");
    $headerFooterManager->setDateTimeVisibility(true);

    $headerFooterManager->setSlideNumberVisibility(true);

    $presentation->save("presentation_with_custom_notes_footers.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

إذا قمت أولاً بنشر الإعدادات من قالب الملاحظات ثم غيرت شريحة ملاحظات فردية، فإن الإعدادات الخاصة بالشريحة تُتيح لك تخصيص تلك الصفحة بشكل مستقل.

## **تعيين الترويس والتذييل على قالب النسخة المطبوعة**

تستخدم صفحات النسخة المطبوعة قالب النسخة المطبوعة لعناصر الترويس، التذييل، التاريخ/الوقت، ورقم الصفحة. على عكس صفحات الملاحظات، يتم إدارة إعدادات النسخة المطبوعة عبر القالب وليس عبر الشرائح الفردية.

استخدم طريقة [`getMasterHandoutSlide`](https://reference.aspose.com/slides/ar/php-java/aspose.slides/masterhandoutslidemanager/getmasterhandoutslide/) للوصول إلى قالب النسخة المطبوعة. إذا لم يكن موجودًا، استدعِ [`setDefaultMasterHandoutSlide`](https://reference.aspose.com/slides/ar/php-java/aspose.slides/masterhandoutslidemanager/setdefaultmasterhandoutslide/) لإنشاء القالب الافتراضي.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
try {
    $masterHandoutSlide = $presentation->getMasterHandoutSlideManager()->getMasterHandoutSlide();

    if (java_is_null($masterHandoutSlide)) {
        $masterHandoutSlide = $presentation->getMasterHandoutSlideManager()->setDefaultMasterHandoutSlide();
    }

    if (!java_is_null($masterHandoutSlide)) {
        $headerFooterManager = $masterHandoutSlide->getHeaderFooterManager();

        $headerFooterManager->setHeaderText("Handout header");
        $headerFooterManager->setHeaderVisibility(true);

        $headerFooterManager->setFooterText("Handout footer");
        $headerFooterManager->setFooterVisibility(true);

        $headerFooterManager->setDateTimeText("Date and time text");
        $headerFooterManager->setDateTimeVisibility(true);

        $headerFooterManager->setSlideNumberVisibility(true);
    }

    $presentation->save("presentation_with_handout_footers.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **فهم النطاق والوراثة**

اختر مدير الترويس/التذييل الذي يتطابق مع النطاق الذي تريد تغييره:

- [`SlideHeaderFooterManager`](https://reference.aspose.com/slides/ar/php-java/aspose.slides/slideheaderfootermanager/) يغيّر إعدادات التذييل، التاريخ/الوقت، ورقم الشريحة لشريحة عادية واحدة.
- [`LayoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/ar/php-java/aspose.slides/layoutslideheaderfootermanager/) يتحكم في شريحة تخطيط ويمكنه نشر الإعدادات المدعومة إلى الشرائح التابعة.
- [`MasterSlideHeaderFooterManager`](https://reference.aspose.com/slides/ar/php-java/aspose.slides/masterslideheaderfootermanager/) يتحكم في قالب شريحة عادية ويمكنه نشر الإعدادات المدعومة إلى الشرائح التابعة.
- [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/ar/php-java/aspose.slides/masternotesslideheaderfootermanager/) يتحكم في قالب الملاحظات ويمكنه نشر الإعدادات إلى جميع شرائح الملاحظات التابعة.
- [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/ar/php-java/aspose.slides/notesslideheaderfootermanager/) يغيّر شريحة ملاحظات واحدة ويدعم عنصر نائب للترويس بالإضافة إلى التذييل، التاريخ/الوقت، ورقم الشريحة.
- [`MasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/ar/php-java/aspose.slides/masterhandoutslideheaderfootermanager/) يغيّر قالب النسخة المطبوعة ويدعم جميع أنواع العناصر النائبة الأربعة.

استخدم النشر من قالب أو تخطيط عندما يجب تطبيق الإعداد نفسه عبر هيكله. استخدم مدير شريحة فردية أو شريحة ملاحظات عندما تحتاج إلى إعداد محلي لصفحة واحدة.

## **الأسئلة المتكررة**

**هل يمكنني إضافة ترويس إلى شريحة عادية؟**

لا. لا يحدد PowerPoint عنصرًا نائبًا للترويس في الشرائح العادية. في الشرائح العادية، استخدم عناصر التذييل، التاريخ/الوقت، ورقم الشريحة. تتوفر عناصر الترويس في صفحات الملاحظات والنسخ المطبوعة.

**ماذا يحدث إذا لم يكن عنصر التذييل أو التاريخ/الوقت أو رقم الشريحة مرئيًا؟**

استخدم مدير الترويس/التذييل المقابل للتحقق من رؤيته وتمكينه عند الحاجة. على سبيل المثال، تُبلغ طريقة [`isFooterVisible`](https://reference.aspose.com/slides/ar/php-java/aspose.slides/baseslideheaderfootermanager/isfootervisible/) ما إذا كان عنصر التذييل موجودًا، وتُغيّر طريقة [`setFooterVisibility`](https://reference.aspose.com/slides/ar/php-java/aspose.slides/baseslideheaderfootermanager/setfootervisibility/) رؤيته.

**كيف أبدأ ترقيم الشرائح من قيمة غير 1؟**

استدعِ طريقة [`setFirstSlideNumber`](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/setfirstslidenumber/) في العرض. ثم تستخدم عناصر رقم الشريحة التسلسل المحدث.

**ماذا يحدث للترويسات والتذييلات عند التصدير إلى PDF أو صور أو HTML؟**

يتم عرض عناصر الترويس والتذييل المرئية مع باقي محتوى العرض في صيغة الإخراج. يعتمد مظهرها على نوع الصفحة المُصدَّر وإعدادات رؤية العناصر النائبة المقابلة.