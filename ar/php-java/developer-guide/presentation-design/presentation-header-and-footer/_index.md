---
title: إدارة رؤوس وتذييلات العروض التقديمية في PHP
linktitle: رأس وتذييل
type: docs
weight: 140
url: /ar/php-java/presentation-header-and-footer/
keywords:
- رأس
- نص الرأس
- تذييل
- نص التذييل
- تعيين الرأس
- تعيين التذييل
- نشرة
- ملاحظات
- PowerPoint
- OpenDocument
- عرض تقديمي
- PHP
- Aspose.Slides
description: "استخدم Aspose.Slides for PHP via Java لإضافة وتخصيص رؤوس وتذييلات في عروض PowerPoint وOpenDocument للحصول على مظهر احترافي."
---

{{% alert color="primary" %}} 

[Aspose.Slides](/slides/ar/php-java/) يقدم دعماً للعمل مع نصوص رؤوس وتذييلات الشرائح التي تُدار فعلياً على مستوى ماستر الشريحة.

{{% /alert %}} 

[Aspose.Slides for PHP via Java](/slides/ar/php-java/) يوفر ميزة إدارة الرؤوس والتذييلات داخل شرائح العرض. هذه تُدار في الواقع على مستوى ماستر العرض.

## **إدارة الرؤوس والتذييلات في عرض تقديمي**
يمكن إزالة ملاحظات شريحة معينة كما هو موضح في المثال أدناه:
```php
  # تحميل العرض
  $pres = new Presentation("headerTest.pptx");
  try {
    # تعيين التذييل
    $pres->getHeaderFooterManager()->setAllFootersText("My Footer text");
    $pres->getHeaderFooterManager()->setAllFootersVisibility(true);
    # الوصول وتحديث الرأس
    $masterNotesSlide = $pres->getMasterNotesSlideManager()->getMasterNotesSlide();
    if (null != $masterNotesSlide) {
      updateHeaderFooterText($masterNotesSlide);
    }
    # حفظ العرض
    $pres->save("HeaderFooterJava.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

```php

```


## **إدارة الرؤوس والتذييلات في شرائح الملاحظات والنشرات**
يدعم Aspose.Slides for PHP via Java الرؤوس والتذييلات في شرائح الملاحظات والنشرات. يرجى اتباع الخطوات أدناه:

- تحميل [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) يحتوي على فيديو.
- تعديل إعدادات الرؤوس والتذييلات لماستر الملاحظات وجميع شرائح الملاحظات.
- جعل عناصر النائب (Placeholder) الخاصة بالتذييل في ماستر الملاحظات وجميع الفروع مرئية.
- جعل عناصر النائب الخاصة بالتاريخ والوقت في ماستر الملاحظات وجميع الفروع مرئية.
- تعديل إعدادات الرؤوس والتذييلات للشرائح الملاحظة الأولى فقط.
- جعل عنصر النائب الخاص برأس الشريحة الملاحظة مرئياً.
- تعيين نص لعنصر النائب الخاص برأس الشريحة الملاحظة.
- تعيين نص لعنصر النائب الخاص بالتاريخ‑الوقت في الشريحة الملاحظة.
- كتابة ملف العرض المعدل.

كود المثال المرفق أدناه.
```php
  $pres = new Presentation("presentation.pptx");
  try {
    # تغيير إعدادات الرأس والتذييل للماستر الملاحظات وجميع شرائح الملاحظات
    $masterNotesSlide = $pres->getMasterNotesSlideManager()->getMasterNotesSlide();
    if (!java_is_null($masterNotesSlide)) {
      $headerFooterManager = $masterNotesSlide->getHeaderFooterManager();
      $headerFooterManager->setHeaderAndChildHeadersVisibility(true);// اجعل شريحة الملاحظات الرئيسية وجميع عناصر نائب التذييل الفرعية مرئية

      $headerFooterManager->setFooterAndChildFootersVisibility(true);// اجعل شريحة الملاحظات الرئيسية وجميع عناصر نائب الرأس الفرعية مرئية

      $headerFooterManager->setSlideNumberAndChildSlideNumbersVisibility(true);// اجعل شريحة الملاحظات الرئيسية وجميع عناصر نائب رقم الشريحة الفرعية مرئية

      $headerFooterManager->setDateTimeAndChildDateTimesVisibility(true);// اجعل شريحة الملاحظات الرئيسية وجميع عناصر نائب التاريخ والوقت الفرعية مرئية

      $headerFooterManager->setHeaderAndChildHeadersText("Header text");// تعيين النص لشريحة الملاحظات الرئيسية وجميع عناصر نائب الرأس الفرعية

      $headerFooterManager->setFooterAndChildFootersText("Footer text");// تعيين النص لشريحة الملاحظات الرئيسية وجميع عناصر نائب التذييل الفرعية

      $headerFooterManager->setDateTimeAndChildDateTimesText("Date and time text");// تعيين النص لشريحة الملاحظات الرئيسية وجميع عناصر نائب التاريخ والوقت الفرعية

    }
    # تغيير إعدادات الرأس والتذييل لشريحة الملاحظات الأولى فقط
    $notesSlide = $pres->getSlides()->get_Item(0)->getNotesSlideManager()->getNotesSlide();
    if (!java_is_null($notesSlide)) {
      $headerFooterManager = $notesSlide->getHeaderFooterManager();
      if (!$headerFooterManager->isHeaderVisible()) {
        $headerFooterManager->setHeaderVisibility(true);
      }// اجعل عنصر نائب الرأس في هذه الشريحة مرئياً

      if (!$headerFooterManager->isFooterVisible()) {
        $headerFooterManager->setFooterVisibility(true);
      }// اجعل عنصر نائب التذييل في هذه الشريحة مرئياً

      if (!$headerFooterManager->isSlideNumberVisible()) {
        $headerFooterManager->setSlideNumberVisibility(true);
      }// اجعل عنصر نائب رقم الشريحة في هذه الشريحة مرئياً

      if (!$headerFooterManager->isDateTimeVisible()) {
        $headerFooterManager->setDateTimeVisibility(true);
      }// اجعل عنصر نائب التاريخ والوقت في هذه الشريحة مرئياً

      $headerFooterManager->setHeaderText("New header text");// تعيين النص لعنصر نائب الرأس في شريحة الملاحظات

      $headerFooterManager->setFooterText("New footer text");// تعيين النص لعنصر نائب التذييل في شريحة الملاحظات

      $headerFooterManager->setDateTimeText("New date and time text");// تعيين النص لعنصرب نائب التاريخ والوقت في شريحة الملاحظات

    }
    $pres->save("testresult.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **الأسئلة الشائعة**

**هل يمكنني إضافة "رأس" إلى الشرائح العادية؟**

في PowerPoint، "الرأس" موجود فقط للملاحظات والنشرات؛ في الشرائح العادية، العناصر المدعومة هي التذييل، التاريخ/الوقت، ورقم الشريحة. في Aspose.Slides يتطابق ذلك مع نفس القيود: الرأس فقط للملاحظات/النشرات، وعلى الشرائح—التذييل/التاريخ‑الوقت/رقم الشريحة.

**ماذا لو لم يحتوي التصميم على مساحة للتذييل—هل يمكنني "تفعيل" رؤيته؟**

نعم. تحقق من الرؤية عبر مدير الرأس/التذييل وفعلها إذا لزم الأمر. تم تصميم مؤشرات وطرق API هذه للحالات التي يكون فيها العنصر النائب مفقوداً أو مخفياً.

**كيف أجعل رقم الشريحة يبدأ من قيمة غير 1؟**

اضبط [first slide number](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/setfirstslidenumber/) في العرض؛ بعد ذلك يُعاد حساب جميع الأرقام. على سبيل المثال، يمكنك البدء من 0 أو 10، وإخفاء الرقم على شريحة العنوان.

**ماذا يحدث للرؤوس/التذييلات عند التصدير إلى PDF/صور/HTML؟**

يتم عرضها كعناصر نصية عادية في العرض. بمعنى إذا كانت العناصر مرئية على الشرائح/صفحات الملاحظات، فستظهر أيضاً في صيغة الإخراج إلى جانب باقي المحتوى.