---
title: ملاحظات العرض
type: docs
weight: 110
url: /ar/androidjava/presentation-notes/
keywords: "ملاحظات المتحدث في PowerPoint بلغة Java"
description: "ملاحظات العرض، ملاحظات المتحدث بلغة Java"
---


{{% alert color="primary" %}} 

تدعم Aspose.Slides إزالة شرائح الملاحظات من العرض التقديمي. في هذا الموضوع، سنقدم هذه الميزة الجديدة المتعلقة بإزالة الملاحظات وأيضًا إضافة شرائح ملاحظات بأسلوب من أي عرض تقديمي.

{{% /alert %}} 

توفر Aspose.Slides لنظام Android عبر Java ميزة إزالة ملاحظات أي شريحة وكذلك إضافة أسلوب إلى الملاحظات الموجودة. يمكن للمطورين إزالة الملاحظات بالطرق التالية:

* إزالة ملاحظات شريحة معينة من العرض التقديمي.
* إزالة ملاحظات جميع الشرائح من العرض التقديمي


## **إزالة الملاحظات من الشريحة**
يمكن إزالة ملاحظات شريحة معينة كما هو موضح في المثال أدناه:

```java
// إنشاء كائن Presentation يمثل ملف عرض تقديمي
Presentation pres = new Presentation("presWithNotes.pptx");
try {
    // إزالة ملاحظات الشريحة الأولى
    INotesSlideManager mgr = pres.getSlides().get_Item(0).getNotesSlideManager();
    mgr.removeNotesSlide();

    // حفظ العرض التقديمي على القرص
    pres.save("test.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **إزالة الملاحظات من العرض التقديمي**
يمكن إزالة ملاحظات جميع الشرائح من العرض التقديمي كما هو موضح في المثال أدناه:

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
    
    // حفظ العرض التقديمي على القرص
    pres.save("test.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **إضافة NotesStyle**
[getNotesStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMasterNotesSlide#getNotesStyle--) تم إضافته إلى واجهة [IMasterNotesSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMasterNotesSlide) وفئة [MasterNotesSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MasterNotesSlide) على التوالي. تُحدد هذه الخاصية أسلوب نص الملاحظات. يتم توضيح التنفيذ في المثال أدناه.

```java
// إنشاء كائن Presentation يمثل ملف عرض تقديمي
Presentation pres = new Presentation("demo.pptx");
try {
    IMasterNotesSlide notesMaster = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    
    if (notesMaster != null)
    {
        // الحصول على أسلوب نص MasterNotesSlide
        ITextStyle notesStyle = notesMaster.getNotesStyle();
    
        // ضبط الرمز النقطي للفقرات في المستوى الأول
        IParagraphFormat paragraphFormat = notesStyle.getLevel(0);
        paragraphFormat.getBullet().setType(BulletType.Symbol);
    }
    pres.save("NotesSlideWithNotesStyle.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```