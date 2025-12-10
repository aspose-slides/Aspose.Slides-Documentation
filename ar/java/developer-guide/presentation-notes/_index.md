---
title: إدارة ملاحظات العرض التقديمي في Java
linktitle: ملاحظات العرض التقديمي
type: docs
weight: 110
url: /ar/java/presentation-notes/
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
- Java
- Aspose.Slides
description: "تخصيص ملاحظات العرض التقديمي باستخدام Aspose.Slides for Java. العمل بسلاسة مع ملاحظات PowerPoint وOpenDocument لتعزيز إنتاجيتك."
---

{{% alert color="primary" %}} 
يدعم Aspose.Slides إزالة شرائح الملاحظات من العرض التقديمي. في هذا الموضوع، سنقدم هذه الميزة الجديدة لإزالة الملاحظات بالإضافة إلى إضافة شرائح نمط الملاحظات من أي عرض تقديمي. 
{{% /alert %}} 

توفر Aspose.Slides for Java ميزة إزالة الملاحظات من أي شريحة بالإضافة إلى إضافة نمط إلى الملاحظات الحالية. يمكن للمطورين إزالة الملاحظات بالطرق التالية:

* إزالة ملاحظات شريحة محددة من العرض.
* إزالة ملاحظات جميع الشرائح من العرض.


## **إزالة الملاحظات من شريحة**
يمكن إزالة ملاحظات شريحة محددة كما هو موضح في المثال أدناه:
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


## **إزالة الملاحظات من العرض**
يمكن إزالة ملاحظات جميع شرائح العرض كما هو موضح في المثال أدناه:
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


## **إضافة نمط ملاحظات**
تم إضافة الطريقة [getNotesStyle](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterNotesSlide#getNotesStyle--) إلى الواجهة [IMasterNotesSlide](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterNotesSlide) والفئة [MasterNotesSlide](https://reference.aspose.com/slides/java/com.aspose.slides/MasterNotesSlide) على التوالي. تحدد هذه الخاصية نمط نص الملاحظات. يتم توضيح التنفيذ في المثال أدناه.
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


## **الأسئلة المتكررة**

**ما الكيان API الذي يوفر الوصول إلى ملاحظات شريحة محددة؟**

يتم الوصول إلى الملاحظات عبر مدير ملاحظات الشريحة: تحتوي الشريحة على [NotesSlideManager](https://reference.aspose.com/slides/java/com.aspose.slides/notesslidemanager/) و[طريقة](https://reference.aspose.com/slides/java/com.aspose.slides/notesslidemanager/#getNotesSlide--) تعيد كائن الملاحظات، أو `null` إذا لم تكن هناك ملاحظات.

**هل هناك اختلافات في دعم الملاحظات عبر إصدارات PowerPoint التي يعمل معها المكتبة؟**

تستهدف المكتبة مجموعة واسعة من صيغ Microsoft PowerPoint (97 وما بعده) وODP؛ وتدعم الملاحظات داخل هذه الصيغ دون الاعتماد على نسخة مثبتة من PowerPoint.