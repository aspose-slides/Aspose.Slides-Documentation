---
title: إدارة ملاحظات العرض التقديمي في JavaScript
linktitle: ملاحظات العرض التقديمي
type: docs
weight: 110
url: /ar/nodejs-java/presentation-notes/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "قم بتخصيص ملاحظات العرض التقديمي في JavaScript باستخدام Aspose.Slides لـ Node.js. اعمل بسلاسة مع ملاحظات PowerPoint وOpenDocument لزيادة إنتاجيتك."
---
## **نظرة عامة**

يدعم Aspose.Slides إزالة شرائح الملاحظات من العرض التقديمي. في هذا الموضوع، سنقدم هذه الميزة، بما في ذلك كيفية إزالة الملاحظات وكيفية تطبيق نمط على شرائح الملاحظات في العرض التقديمي. يتيح Aspose.Slides لك إزالة الملاحظات من أي شريحة وتطبيق تنسيق على الملاحظات الموجودة. يمكن للمطورين إزالة الملاحظات بالطرق التالية:

- إزالة الملاحظات من شريحة محددة في العرض التقديمي.
- إزالة الملاحظات من جميع الشرائح في العرض التقديمي.

لقراءة أو تغيير أبعاد صفحة الملاحظات، وتبديل الاتجاه، والتحقق من سلوك التصدير، راجع [Notes Page Size](/slides/ar/nodejs-java/notes-size/).

## **إزالة ملاحظات من شريحة**
يمكن إزالة الملاحظات من شريحة محددة كما هو موضح في المثال أدناه:

```javascript
// إنشاء كائن Presentation الذي يمثل ملف عرض تقديمي
var pres = new aspose.slides.Presentation("presWithNotes.pptx");
try {
    // إزالة ملاحظات الشريحة الأولى
    var mgr = pres.getSlides().get_Item(0).getNotesSlideManager();
    mgr.removeNotesSlide();
    // حفظ العرض التقديمي على القرص
    pres.save("test.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **إزالة ملاحظات من عرض تقديمي**
يمكن إزالة الملاحظات من جميع الشرائح في عرض تقديمي كما هو موضح في المثال أدناه:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// إنشاء كائن Presentation الذي يمثل ملف عرض تقديمي
var pres = new aspose.slides.Presentation("presWithNotes.pptx");
try {
    // إزالة ملاحظات جميع الشرائح
    var mgr = null;
    for (var i = 0; i < pres.getSlides().size(); i++) {
        mgr = pres.getSlides().get_Item(i).getNotesSlideManager();
        mgr.removeNotesSlide();
    }
    // حفظ العرض التقديمي على القرص
    pres.save("test.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **إضافة NotesStyle**
تمت إضافة الطريقة [getNotesStyle](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/MasterNotesSlide#getNotesStyle--) إلى فئة [MasterNotesSlide](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/MasterNotesSlide) وفئة [MasterNotesSlide](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/MasterNotesSlide) على التوالي. تحدد هذه الخاصية نمط نص الملاحظات. يتم توضيح التنفيذ في المثال أدناه.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// إنشاء كائن Presentation الذي يمثل ملف عرض تقديمي
var pres = new aspose.slides.Presentation("demo.pptx");
try {
    var notesMaster = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    if (notesMaster != null) {
        // الحصول على نمط نص MasterNotesSlide
        var notesStyle = notesMaster.getNotesStyle();
        // تعيين نقطه رمزية للفقرة من المستوى الأول
        var paragraphFormat = notesStyle.getLevel(0);
        paragraphFormat.getBullet().setType(java.newByte(aspose.slides.BulletType.Symbol));
    }
    pres.save("NotesSlideWithNotesStyle.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **الأسئلة الشائعة**

**ما الكيان في API الذي يوفر الوصول إلى ملاحظات شريحة محددة؟**

يتم الوصول إلى الملاحظات من خلال مدير ملاحظات الشريحة: الشريحة لديها [NotesSlideManager](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/notesslidemanager/) و[طريقة](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/notesslidemanager/getnotesslide/) تُعيد كائن الملاحظات، أو `null` إذا لم تكن هناك ملاحظات.

**هل هناك اختلافات في دعم الملاحظات عبر إصدارات PowerPoint التي تعمل معها المكتبة؟**

تستهدف المكتبة مجموعة واسعة من تنسيقات Microsoft PowerPoint (97‑الأحدث) وODP؛ يتم دعم الملاحظات داخل هذه التنسيقات دون الاعتماد على نسخة مثبتة من PowerPoint.