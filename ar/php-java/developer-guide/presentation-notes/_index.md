---
title: إدارة ملاحظات العرض التقديمي في PHP
linktitle: ملاحظات العرض التقديمي
type: docs
weight: 110
url: /ar/php-java/presentation-notes/
keywords:
- ملاحظات
- شريحة ملاحظات
- إضافة ملاحظات
- إزالة ملاحظات
- نمط الملاحظات
- ملاحظات رئيسية
- PowerPoint
- OpenDocument
- عرض تقديمي
- PHP
- Aspose.Slides
description: "تخصيص ملاحظات العرض التقديمي باستخدام Aspose.Slides للـ PHP عبر Java. العمل بسلاسة مع ملاحظات PowerPoint و OpenDocument لتعزيز إنتاجيتك."
---
## **نظرة عامة**

تدعم Aspose.Slides إزالة شرائح الملاحظات من العرض التقديمي. في هذا الموضوع، سنقدم هذه الميزة، بما في ذلك كيفية إزالة الملاحظات وكيفية تطبيق نمط على شرائح الملاحظات في العرض التقديمي. تتيح Aspose.Slides لك إزالة الملاحظات من أي شريحة وكذلك تطبيق تنسيق على الملاحظات الموجودة. يمكن للمطورين إزالة الملاحظات بالطرق التالية:

- إزالة الملاحظات من شريحة محددة في العرض التقديمي.
- إزالة الملاحظات من جميع الشرائح في العرض التقديمي.

لقراءة أو تغيير أبعاد صفحة الملاحظات، تغيير الاتجاه، والتحقق من سلوك التصدير، راجع [حجم صفحة الملاحظات](/slides/ar/php-java/notes-size/).

## **إزالة الملاحظات من شريحة**

يمكن إزالة الملاحظات من شريحة محددة كما هو موضح في المثال أدناه:

```php
  # إنشاء كائن Presentation يمثل ملف عرض تقديمي
  $pres = new Presentation("presWithNotes.pptx");
  try {
    # إزالة ملاحظات الشريحة الأولى
    $mgr = $pres->getSlides()->get_Item(0)->getNotesSlideManager();
    $mgr->removeNotesSlide();
    # حفظ العرض التقديمي إلى القرص
    $pres->save("test.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **إزالة الملاحظات من العرض التقديمي**

يمكن إزالة الملاحظات من جميع الشرائح في العرض التقديمي كما هو موضح في المثال أدناه:

```php
  # إنشاء كائن Presentation يمثل ملف عرض تقديمي
  $pres = new Presentation("presWithNotes.pptx");
  try {
    # إزالة ملاحظات جميع الشرائح
    $mgr = null;
    for($i = 0; $i < java_values($pres->getSlides()->size()) ; $i++) {
      $mgr = $pres->getSlides()->get_Item($i)->getNotesSlideManager();
      $mgr->removeNotesSlide();
    }
    # حفظ العرض التقديمي إلى القرص
    $pres->save("test.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **إضافة نمط للملاحظات**

توفر طريقة [getNotesStyle](https://reference.aspose.com/slides/ar/php-java/aspose.slides/MasterNotesSlide#getNotesStyle) في الفئة [MasterNotesSlide](https://reference.aspose.com/slides/ar/php-java/aspose.slides/MasterNotesSlide) إمكانية الوصول إلى نمط نص الملاحظات. تم توضيح التنفيذ في المثال أدناه.

```php
  # إنشاء كائن Presentation يمثل ملف عرض تقديمي
  $pres = new Presentation("demo.pptx");
  try {
    $notesMaster = $pres->getMasterNotesSlideManager()->getMasterNotesSlide();
    if (!java_is_null($notesMaster)) {
      # الحصول على نمط نص MasterNotesSlide
      $notesStyle = $notesMaster->getNotesStyle();
      # تعيين نقطه رمزية للفقرات من المستوى الأول
      $paragraphFormat = $notesStyle->getLevel(0);
      $paragraphFormat::getBullet()->setType(BulletType::Symbol);
    }
    $pres->save("NotesSlideWithNotesStyle.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **الأسئلة الشائعة**

**أي كيان API يوفر الوصول إلى ملاحظات شريحة محددة؟**

يتم الوصول إلى الملاحظات عبر مدير ملاحظات الشريحة: تحتوي الشريحة على كائن [NotesSlideManager](https://reference.aspose.com/slides/ar/php-java/aspose.slides/notesslidemanager/) و[طريقة](https://reference.aspose.com/slides/ar/php-java/aspose.slides/notesslidemanager/getnotesslide/) تُعيد كائن الملاحظات، أو `null` إذا لم تكن هناك ملاحظات.

**هل هناك اختلافات في دعم الملاحظات عبر إصدارات PowerPoint التي تعمل معها المكتبة؟**

تستهدف المكتبة مجموعة واسعة من صيغ Microsoft PowerPoint (من 97‑إلى الأحدث) وODP؛ يتم دعم الملاحظات داخل هذه الصيغ دون الاعتماد على نسخة مثبتة من PowerPoint.