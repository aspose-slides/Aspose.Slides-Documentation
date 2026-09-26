---
title: إدارة ملاحظات العرض التقديمي في جافا
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
- الملاحظات الرئيسية
- PowerPoint
- OpenDocument
- عرض تقديمي
- Java
- Aspose.Slides
description: "خصص ملاحظات العرض التقديمي باستخدام Aspose.Slides لجافا. اعمل بسلاسة مع ملاحظات PowerPoint وOpenDocument لتعزيز إنتاجيتك."
---
## **نظرة عامة**

Aspose.Slides يدعم إزالة شرائح الملاحظات من عرض تقديمي. في هذا الموضوع، سنقدم هذه الميزة، بما في ذلك كيفية إزالة الملاحظات وكيفية تطبيق نمط على شرائح الملاحظات في عرض تقديمي. Aspose.Slides يتيح لك إزالة الملاحظات من أي شريحة وكذلك تطبيق تنسيق على الملاحظات الموجودة. يمكن للمطورين إزالة الملاحظات بالطرق التالية:

- إزالة الملاحظات من شريحة محددة في عرض تقديمي.
- إزالة الملاحظات من جميع الشرائح في عرض تقديمي.

لقراءة أو تغيير أبعاد صفحة الملاحظات، وتبديل الاتجاه، والتحقق من سلوك التصدير، راجع [حجم صفحة الملاحظات](/slides/ar/java/notes-size/).

## **إزالة الملاحظات من شريحة**
يمكن إزالة الملاحظات من شريحة محددة كما هو موضح في المثال أدناه:

```java
import com.aspose.slides.*;

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

## **إزالة الملاحظات من عرض تقديمي**
يمكن إزالة الملاحظات من جميع الشرائح في عرض تقديمي كما هو موضح في المثال أدناه:

```java
import com.aspose.slides.*;

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
[getNotesStyle](https://reference.aspose.com/slides/ar/java/com.aspose.slides/IMasterNotesSlide#getNotesStyle--) تمّت إضافة طريقة إلى واجهة [IMasterNotesSlide](https://reference.aspose.com/slides/ar/java/com.aspose.slides/IMasterNotesSlide) وفئة [MasterNotesSlide](https://reference.aspose.com/slides/ar/java/com.aspose.slides/MasterNotesSlide) على التوالي. تحدد هذه الخاصية نمط نص الملاحظات. يتم توضيح التنفيذ في المثال أدناه.

```java
import com.aspose.slides.*;

// إنشاء كائن Presentation يمثل ملف عرض تقديمي
Presentation pres = new Presentation("demo.pptx");
try {
    IMasterNotesSlide notesMaster = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    
    if (notesMaster != null)
    {
        // الحصول على نمط نص MasterNotesSlide
        ITextStyle notesStyle = notesMaster.getNotesStyle();
    
        // تعيين رمز نقطي للفقرة من المستوى الأول
        IParagraphFormat paragraphFormat = notesStyle.getLevel(0);
        paragraphFormat.getBullet().setType(BulletType.Symbol);
    }
    pres.save("NotesSlideWithNotesStyle.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **الأسئلة الشائعة**

**ما الكيان API الذي يتيح الوصول إلى ملاحظات شريحة محددة؟**

يتم الوصول إلى الملاحظات عبر مدير ملاحظات الشريحة: تحتوي الشريحة على [NotesSlideManager](https://reference.aspose.com/slides/ar/java/com.aspose.slides/notesslidemanager/) وطريقة [method](https://reference.aspose.com/slides/ar/java/com.aspose.slides/notesslidemanager/#getNotesSlide--) التي تُرجع كائن الملاحظات، أو `null` إذا لم تكن هناك ملاحظات.

**هل هناك اختلافات في دعم الملاحظات عبر إصدارات PowerPoint التي يعمل معها المكتبة؟**

المكتبة تستهدف مجموعة واسعة من صيغ Microsoft PowerPoint (من 97 وما بعده) وODP؛ يتم دعم الملاحظات ضمن هذه الصيغ دون الاعتماد على نسخة مثبتة من PowerPoint.