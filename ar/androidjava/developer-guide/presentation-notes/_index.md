---
title: إدارة ملاحظات العرض التقديمي على Android
linktitle: ملاحظات العرض التقديمي
type: docs
weight: 110
url: /ar/androidjava/presentation-notes/
keywords:
- ملاحظات
- شريحة ملاحظات
- إضافة ملاحظات
- إزالة ملاحظات
- نمط الملاحظات
- الملاحظات الرئيسية
- PowerPoint
- OpenDocument
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "خصّص ملاحظات العرض التقديمي باستخدام Aspose.Slides لأندرويد عبر جافا. اعمل بسلاسة مع ملاحظات PowerPoint وOpenDocument لتعزيز إنتاجيتك."
---

{{% alert color="primary" %}} 

يدعم Aspose.Slides إزالة شرائح الملاحظات من العرض التقديمي. في هذا الموضوع، سنقدم هذه الميزة الجديدة لإزالة الملاحظات بالإضافة إلى إضافة شرائح بنمط الملاحظات إلى أي عرض تقديمي. 

{{% /alert %}} 

يوفر Aspose.Slides for Android عبر Java ميزة إزالة ملاحظات أي شريحة وكذلك إضافة نمط إلى الملاحظات الموجودة. يمكن للمطورين إزالة الملاحظات بالطرق التالية:

* إزالة ملاحظات شريحة محددة من العرض التقديمي.
* إزالة ملاحظات جميع شرائح العرض التقديمي.


## **Remove Notes from a Slide**
يمكن إزالة ملاحظات شريحة معينة كما هو موضح في المثال أدناه:
```java
// إنشاء كائن Presentation يمثل ملف عرض تقديمي
Presentation pres = new Presentation("presWithNotes.pptx");
try {
    // إزالة ملاحظات الشريحة الأولى
    INotesSlideManager mgr = pres.getSlides().get_Item(0).getNotesSlideManager();
    mgr.removeNotesSlide();

    // حفظ العرض التقديمي إلى القرص
    pres.save("test.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Remove Notes from a Presentation**
يمكن إزالة ملاحظات جميع الشرائح في العرض التقديمي كما هو موضح في المثال أدناه:
```java
// إنشاء كائن Presentation يمثل ملف عرض تقديمي
Presentation pres = new Presentation("presWithNotes.pptx");
try {
    // إزالة ملاحظات جميع الشرائح
    INotesSlideManager mgr = null;
    for (int i = 0; i < pres.getSlides().size(); i++) {
        mgr = pres.getSlides().get_Item(i).getNotesSlideManager();
        mgr.removeNotesSlide();
    }
    
    // حفظ العرض التقديمي إلى القرص
    pres.save("test.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Add a Notes Style**
تم إضافة طريقة [getNotesStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMasterNotesSlide#getNotesStyle--) إلى واجهة [IMasterNotesSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMasterNotesSlide) وفئة [MasterNotesSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MasterNotesSlide) على التوالي. تحدد هذه الخاصية نمط نص الملاحظات. يتم توضيح التنفيذ في المثال أدناه.
```java
// إنشاء كائن Presentation يمثل ملف عرض تقديمي
Presentation pres = new Presentation("demo.pptx");
try {
    IMasterNotesSlide notesMaster = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    
    if (notesMaster != null)
    {
        // الحصول على نمط نص MasterNotesSlide
        ITextStyle notesStyle = notesMaster.getNotesStyle();
    
        // تعيين نقطه رمزية للفقرات من المستوى الأول
        IParagraphFormat paragraphFormat = notesStyle.getLevel(0);
        paragraphFormat.getBullet().setType(BulletType.Symbol);
    }
    pres.save("NotesSlideWithNotesStyle.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**Which API entity provides access to the notes of a specific slide?**

يتم الوصول إلى الملاحظات عبر مدير ملاحظات الشريحة: تحتوي الشريحة على [NotesSlideManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/notesslidemanager/) و[method](https://reference.aspose.com/slides/androidjava/com.aspose.slides/notesslidemanager/#getNotesSlide--) التي تُرجع كائن الملاحظات، أو `null` إذا لم تكن هناك ملاحظات.

**Are there differences in notes support across the PowerPoint versions the library works with?**

تستهدف المكتبة مجموعة واسعة من صيغ Microsoft PowerPoint (97‑أحدث) وODP؛ تدعم الملاحظات ضمن هذه الصيغ دون الاعتماد على نسخة مثبتة من PowerPoint.