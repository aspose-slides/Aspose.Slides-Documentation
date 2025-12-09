---
title: ملاحظات العرض التقديمي
type: docs
weight: 110
url: /ar/nodejs-java/presentation-notes/
keywords: "ملاحظات المتحدث في PowerPoint باستخدام JavaScript"
description: "ملاحظات العرض، ملاحظات المتحدث باستخدام JavaScript"
---

{{% alert color="primary" %}} 
يدعم Aspose.Slides إزالة شرائح الملاحظات من العرض التقديمي. في هذا الموضوع، سنقدم هذه الميزة الجديدة لإزالة الملاحظات وكذلك إضافة شرائح نمط الملاحظات من أي عرض تقديمي. 
{{% /alert %}} 

Aspose.Slides for Node.js via Java يوفر ميزة إزالة ملاحظات أي شريحة بالإضافة إلى إضافة نمط للملاحظات الحالية. يمكن للمطورين إزالة الملاحظات بالطرق التالية:

* إزالة ملاحظات شريحة معينة من عرض تقديمي.
* إزالة ملاحظات جميع شرائح العرض التقديمي.


## **إزالة الملاحظات من الشريحة**
يمكن إزالة ملاحظات بعض الشرائح المحددة كما هو موضح في المثال أدناه:
```javascript
// إنشاء كائن Presentation يمثل ملف عرض تقديمي
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


## **إزالة الملاحظات من العرض التقديمي**
يمكن إزالة ملاحظات جميع شرائح العرض التقديمي كما هو موضح في المثال أدناه:
```javascript
// إنشاء كائن Presentation يمثل ملف عرض تقديمي
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


## **إضافة نمط الملاحظات**
تم إضافة طريقة [getNotesStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MasterNotesSlide#getNotesStyle--) إلى الفئة [MasterNotesSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MasterNotesSlide) وفئة [MasterNotesSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MasterNotesSlide) على التوالي. تحدد هذه الخاصية نمط نص الملاحظات. يتم توضيح التنفيذ في المثال أدناه.
```javascript
// إنشاء كائن Presentation يمثل ملف عرض تقديمي
var pres = new aspose.slides.Presentation("demo.pptx");
try {
    var notesMaster = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    if (notesMaster != null) {
        // الحصول على نمط نص MasterNotesSlide
        var notesStyle = notesMaster.getNotesStyle();
        // تعيين نقطة رمزية للمستوى الأول من الفقرات
        var paragraphFormat = notesStyle.getLevel(0);
        paragraphFormat.getBullet().setType(aspose.slides.BulletType.Symbol);
    }
    pres.save("NotesSlideWithNotesStyle.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **الأسئلة الشائعة**

**ما الكيان API الذي يوفر الوصول إلى ملاحظات شريحة معينة؟**

يتم الوصول إلى الملاحظات من خلال مدير الملاحظات للشرائح: تحتوي الشريحة على [NotesSlideManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/notesslidemanager/) و[طريقة](https://reference.aspose.com/slides/nodejs-java/aspose.slides/notesslidemanager/getnotesslide/) تُعيد كائن الملاحظات، أو `null` إذا لم تكن هناك ملاحظات.

**هل هناك اختلافات في دعم الملاحظات عبر إصدارات PowerPoint التي يعمل معها المكتبة؟**

تستهدف المكتبة مجموعة واسعة من صيغ Microsoft PowerPoint (من 97 إلى الأحدث) وODP؛ يتم دعم الملاحظات ضمن هذه الصيغ دون الاعتماد على نسخة مثبتة من PowerPoint.