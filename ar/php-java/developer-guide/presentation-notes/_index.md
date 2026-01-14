---
title: إدارة ملاحظات العرض التقديمي في PHP
linktitle: ملاحظات العرض التقديمي
type: docs
weight: 110
url: /ar/php-java/presentation-notes/
keywords:
- ملاحظات
- شريحة الملاحظات
- إضافة ملاحظات
- إزالة ملاحظات
- نمط الملاحظات
- الملاحظات الرئيسية
- PowerPoint
- OpenDocument
- عرض تقديمي
- PHP
- Aspose.Slides
description: "قم بتخصيص ملاحظات العرض التقديمي باستخدام Aspose.Slides للـ PHP عبر Java. اعمل بسلاسة مع ملاحظات PowerPoint وOpenDocument لتعزيز إنتاجيتك."
---

{{% alert color="primary" %}} 

يدعم Aspose.Slides إزالة شرائح الملاحظات من العرض التقديمي. في هذا المقال، سوف نقدم هذه الميزة الجديدة لإزالة الملاحظات وإضافة أنماط الملاحظات إلى أي عرض تقديمي.

{{% /alert %}} 

يوفر Aspose.Slides لـ PHP عبر Java إمكانية إزالة ملاحظات أي شريحة وكذلك إضافة نمط للملاحظات الموجودة. يمكن للمطورين إزالة الملاحظات بالطرق التالية:

* إزالة ملاحظات شريحة معينة من العرض التقديمي.
* إزالة ملاحظات جميع الشرائح في العرض التقديمي.


## **Remove Notes from a Slide**
يمكن إزالة ملاحظات شريحة معينة كما هو موضح في المثال أدناه:
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


## **Remove Notes from a Presentation**
يمكن إزالة ملاحظات جميع شرائح العرض التقديمي كما هو موضح في المثال أدناه:
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


## **Add a Notes Style**
تم إضافة طريقة [getNotesStyle](https://reference.aspose.com/slides/php-java/aspose.slides/MasterNotesSlide#getNotesStyle) إلى الفئة [MasterNotesSlide](https://reference.aspose.com/slides/php-java/aspose.slides/MasterNotesSlide) على التوالي. تُحدد هذه الخاصية نمط نص الملاحظات. يتم توضيح التنفيذ في المثال أدناه.
```php
  # إنشاء كائن Presentation يمثل ملف عرض تقديمي
  $pres = new Presentation("demo.pptx");
  try {
    $notesMaster = $pres->getMasterNotesSlideManager()->getMasterNotesSlide();
    if (!java_is_null($notesMaster)) {
      # الحصول على نمط نص MasterNotesSlide
      $notesStyle = $notesMaster->getNotesStyle();
      # تعيين نقطة رمزية للمستوى الأول من الفقرات
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


## **FAQ**

**Which API entity provides access to the notes of a specific slide?**

يتم الوصول إلى الملاحظات عبر مدير ملاحظات الشريحة: تحتوي الشريحة على [NotesSlideManager](https://reference.aspose.com/slides/php-java/aspose.slides/notesslidemanager/) و[method](https://reference.aspose.com/slides/php-java/aspose.slides/notesslidemanager/getnotesslide/) التي تُعيد كائن الملاحظات، أو `null` إذا لم تتوفر ملاحظات.

**Are there differences in notes support across the PowerPoint versions the library works with?**

تستهدف المكتبة مجموعة واسعة من تنسيقات Microsoft PowerPoint (من الإصدار 97 وما بعده) وODP؛ يتم دعم الملاحظات داخل هذه التنسيقات دون الاعتماد على نسخة مثبتة من PowerPoint.