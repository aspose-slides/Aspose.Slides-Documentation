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
description: "قم بتخصيص ملاحظات العرض التقديمي باستخدام Aspose.Slides لأجهزة Android عبر Java. اعمل بسلاسة مع ملاحظات PowerPoint وOpenDocument لتعزيز إنتاجيتك."
---
## **نظرة عامة**

يدعم Aspose.Slides إزالة شرائح الملاحظات من العرض التقديمي. في هذا الموضوع، سنقدم هذه الميزة، بما في ذلك كيفية إزالة الملاحظات وكيفية تطبيق نمط على شرائح الملاحظات في العرض التقديمي. يسمح Aspose.Slides لك بإزالة الملاحظات من أي شريحة وكذلك تطبيق تنسيق على الملاحظات الموجودة. يمكن للمطورين إزالة الملاحظات بالطرق التالية:

- إزالة الملاحظات من شريحة محددة في العرض التقديمي.
- إزالة الملاحظات من جميع الشرائح في العرض التقديمي.

لقراءة أو تغيير أبعاد صفحة الملاحظات، تبديل الاتجاه، والتحقق من سلوك التصدير، راجع [Notes Page Size](/slides/ar/androidjava/notes-size/).

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

## **إزالة الملاحظات من العرض التقديمي**
يمكن إزالة الملاحظات من جميع الشرائح في العرض التقديمي كما هو موضح في المثال أدناه:

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

## **إضافة نمط للملاحظات**
تم إضافة الطريقة [getNotesStyle](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/IMasterNotesSlide#getNotesStyle--) إلى واجهة [IMasterNotesSlide](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/IMasterNotesSlide) وفئة [MasterNotesSlide](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/MasterNotesSlide) على التوالي. تحدد هذه الخاصية نمط نص الملاحظات. يتم توضيح التنفيذ في المثال أدناه.

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
    
        //تعيين رمز نقطي للفقرات من المستوى الأول
        IParagraphFormat paragraphFormat = notesStyle.getLevel(0);
        paragraphFormat.getBullet().setType(BulletType.Symbol);
    }
    pres.save("NotesSlideWithNotesStyle.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**ما الكيان API الذي يتيح الوصول إلى ملاحظات شريحة معينة؟**

يتم الوصول إلى الملاحظات عبر مدير ملاحظات الشريحة: تحتوي الشريحة على [NotesSlideManager](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/notesslidemanager/) و[طريقة](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/notesslidemanager/#getNotesSlide--) تُعيد كائن الملاحظات، أو `null` إذا لم توجد ملاحظات.

**هل هناك اختلافات في دعم الملاحظات عبر إصدارات PowerPoint التي تعمل معها المكتبة؟**

تستهدف المكتبة مجموعة واسعة من صيغ Microsoft PowerPoint (97‑أحدث) وODP؛ يتم دعم الملاحظات ضمن هذه الصيغ دون الاعتماد على نسخة مثبتة من PowerPoint.