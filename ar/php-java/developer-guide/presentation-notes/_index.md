---
title: ملاحظات العرض
type: docs
weight: 110
url: /php-java/presentation-notes/
keywords: "ملاحظات المتحدث في PowerPoint"
description: "ملاحظات العرض، ملاحظات المتحدث"
---


{{% alert color="primary" %}} 

Aspose.Slides يدعم إزالة شرائح الملاحظات من العرض التقديمي. في هذا الموضوع، سنقدم هذه الميزة الجديدة لإزالة الملاحظات بالإضافة إلى إضافة شرائح أنماط الملاحظات من أي عرض تقديمي.

{{% /alert %}} 

تقدم Aspose.Slides لـ PHP عبر Java ميزة إزالة ملاحظات أي شريحة بالإضافة إلى إضافة أنماط إلى الملاحظات الموجودة. يمكن للمطورين إزالة الملاحظات بعدة طرق:

* إزالة ملاحظات شريحة معينة من العرض التقديمي.
* إزالة ملاحظات جميع الشرائح من العرض التقديمي.


## **إزالة الملاحظات من الشريحة**
يمكن إزالة ملاحظات شريحة معينة كما هو موضح في المثال أدناه:

```php
  # إنشاء كائن Presentation يمثل ملف عرض تقديمي
  $pres = new Presentation("presWithNotes.pptx");
  try {
    # إزالة ملاحظات الشريحة الأولى
    $mgr = $pres->getSlides()->get_Item(0)->getNotesSlideManager();
    $mgr->removeNotesSlide();
    # حفظ العرض التقديمي على القرص
    $pres->save("test.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **إزالة الملاحظات من العرض التقديمي**
يمكن إزالة ملاحظات جميع الشرائح من عرض تقديمي كما هو موضح في المثال أدناه:

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
    # حفظ العرض التقديمي على القرص
    $pres->save("test.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **إضافة NotesStyle**
[getNotesStyle](https://reference.aspose.com/slides/php-java/aspose.slides/IMasterNotesSlide#getNotesStyle--) قد تمت إضافته إلى واجهة [IMasterNotesSlide](https://reference.aspose.com/slides/php-java/aspose.slides/IMasterNotesSlide) وclass [MasterNotesSlide](https://reference.aspose.com/slides/php-java/aspose.slides/MasterNotesSlide) على التوالي. تشير هذه الخاصية إلى نمط نص الملاحظات. يتم توضيح التنفيذ في المثال أدناه.

```php
  # إنشاء كائن Presentation يمثل ملف عرض تقديمي
  $pres = new Presentation("demo.pptx");
  try {
    $notesMaster = $pres->getMasterNotesSlideManager()->getMasterNotesSlide();
    if (!java_is_null($notesMaster)) {
      # الحصول على نمط نص MasterNotesSlide
      $notesStyle = $notesMaster->getNotesStyle();
      # تعيين نوع رمز للنقاط للفقرة من المستوى الأول
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