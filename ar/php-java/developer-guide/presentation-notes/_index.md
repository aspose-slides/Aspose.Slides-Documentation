---
title: إدارة ملاحظات العرض التقديمي في PHP
linktitle: ملاحظات العرض التقديمي
type: docs
weight: 110
url: /ar/php-java/presentation-notes/
keywords:
- الملاحظات
- شريحة الملاحظات
- إضافة ملاحظات
- إزالة ملاحظات
- نمط الملاحظات
- الملاحظات الرئيسية
- PowerPoint
- OpenDocument
- العرض التقديمي
- PHP
- Aspose.Slides
description: "قم بتخصيص ملاحظات العرض التقديمي باستخدام Aspose.Slides للـ PHP عبر Java. اعمل بسلاسة مع ملاحظات PowerPoint و OpenDocument لتعزيز إنتاجيتك."
---

{{% alert color="primary" %}} 

Aspose.Slides يدعم إزالة شرائح الملاحظات من العرض التقديمي. في هذا الموضوع، سنقدم هذه الميزة الجديدة لإزالة الملاحظات بالإضافة إلى إضافة شرائح نمط الملاحظات من أي عرض تقديمي.

{{% /alert %}} 

Aspose.Slides لـ PHP عبر Java يوفر ميزة إزالة ملاحظات أي شريحة وكذلك إضافة نمط إلى الملاحظات الموجودة. يمكن للمطورين إزالة الملاحظات بالطرق التالية:

* إزالة ملاحظات شريحة محددة من عرض تقديمي.
* إزالة ملاحظات جميع الشرائح من عرض تقديمي.

## **إزالة الملاحظات من شريحة**
يمكن إزالة ملاحظات بعض الشرائح المحددة كما هو موضح في المثال أدناه:
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


## **إزالة الملاحظات من عرض تقديمي**
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


## **إضافة نمط ملاحظات**
تمت إضافة طريقة [getNotesStyle](https://reference.aspose.com/slides/php-java/aspose.slides/IMasterNotesSlide#getNotesStyle--) إلى واجهة [IMasterNotesSlide](https://reference.aspose.com/slides/php-java/aspose.slides/IMasterNotesSlide) وفئة [MasterNotesSlide](https://reference.aspose.com/slides/php-java/aspose.slides/MasterNotesSlide) على التوالي. تحدد هذه الخاصية نمط نص الملاحظات. يتم توضيح التنفيذ في المثال أدناه.
```php
  # إنشاء كائن Presentation يمثل ملف عرض تقديمي
  $pres = new Presentation("demo.pptx");
  try {
    $notesMaster = $pres->getMasterNotesSlideManager()->getMasterNotesSlide();
    if (!java_is_null($notesMaster)) {
      # الحصول على نمط نص MasterNotesSlide
      $notesStyle = $notesMaster->getNotesStyle();
      # تعيين رصاصة رمزية للفقرات المستوى الأول
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

**ما الكيان API الذي يتيح الوصول إلى ملاحظات شريحة محددة؟**

يتم الوصول إلى الملاحظات عبر مدير ملاحظات الشريحة: تحتوي الشريحة على [NotesSlideManager](https://reference.aspose.com/slides/php-java/aspose.slides/notesslidemanager/) و[طريقة](https://reference.aspose.com/slides/php-java/aspose.slides/notesslidemanager/getnotesslide/) تُعيد كائن الملاحظات، أو `null` إذا لم توجد ملاحظات.

**هل هناك اختلافات في دعم الملاحظات عبر إصدارات PowerPoint التي تعمل معها المكتبة؟**

تستهدف المكتبة مجموعة واسعة من صيغ Microsoft PowerPoint (من 97 وما بعدها) وODP؛ يتم دعم الملاحظات داخل هذه الصيغ دون الاعتماد على نسخة مثبتة من PowerPoint.