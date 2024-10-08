---
title: ملاحظات العرض
type: docs
weight: 110
url: /ar/java/presentation-notes/
keywords: "ملاحظات متحدث PowerPoint في Java"
description: "ملاحظات العرض، ملاحظات المتحدث في Java"
---


{{% alert color="primary" %}} 

يدعم Aspose.Slides إزالة شرائح الملاحظات من العرض التقديمي. في هذا الموضوع، سنقدم هذه الميزة الجديدة لإزالة الملاحظات بالإضافة إلى إضافة شرائح نمط الملاحظات من أي عرض تقديمي. 

{{% /alert %}} 

توفر Aspose.Slides لـ Java ميزة إزالة ملاحظات أي شريحة بالإضافة إلى إضافة نمط للملاحظات الموجودة. يمكن للمطورين إزالة الملاحظات بالطرق التالية:

* إزالة ملاحظات شريحة معينة من العرض التقديمي.
* إزالة ملاحظات جميع الشرائح من العرض التقديمي.


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
يمكن إزالة ملاحظات جميع الشرائح في عرض تقديمي كما هو موضح في المثال أدناه:

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

## **إضافة نمط الملاحظات**
[getNotesStyle](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterNotesSlide#getNotesStyle--) تمت إضافته إلى واجهة [IMasterNotesSlide](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterNotesSlide) وطبقة [MasterNotesSlide](https://reference.aspose.com/slides/java/com.aspose.slides/MasterNotesSlide) على التوالي. تحدد هذه الخاصية نمط نص الملاحظات. تم عرض التنفيذ في المثال أدناه.

```java
// إنشاء كائن Presentation يمثل ملف عرض تقديمي
Presentation pres = new Presentation("demo.pptx");
try {
    IMasterNotesSlide notesMaster = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    
    if (notesMaster != null)
    {
        // الحصول على نمط نص MasterNotesSlide
        ITextStyle notesStyle = notesMaster.getNotesStyle();
    
        // تعيين رمز الرصاص للفقرات من المستوى الأول
        IParagraphFormat paragraphFormat = notesStyle.getLevel(0);
        paragraphFormat.getBullet().setType(BulletType.Symbol);
    }
    pres.save("NotesSlideWithNotesStyle.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```