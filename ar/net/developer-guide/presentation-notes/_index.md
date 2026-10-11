---
title: إدارة ملاحظات العرض التقديمي في .NET
linktitle: ملاحظات العرض التقديمي
type: docs
weight: 110
url: /ar/net/presentation-notes/
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
- .NET
- C#
- Aspose.Slides
description: "قم بتخصيص ملاحظات العرض التقديمي باستخدام Aspose.Slides لـ .NET. اعمل بسلاسة مع ملاحظات PowerPoint و OpenDocument لتعزيز إنتاجيتك."
---
## **نظرة عامة**

تدعم Aspose.Slides إزالة شرائح الملاحظات من العرض التقديمي. في هذا الموضوع، سنقدم هذه الميزة، بما في ذلك كيفية إزالة الملاحظات وكيفية تطبيق نمط على شرائح الملاحظات في العرض التقديمي. تتيح لك Aspose.Slides إزالة الملاحظات من أي شريحة وكذلك تطبيق تنسيق على الملاحظات الموجودة. يمكن للمطورين إزالة الملاحظات بالطرق التالية:

- إزالة الملاحظات من شريحة معينة في العرض التقديمي.
- إزالة الملاحظات من جميع الشرائح في العرض التقديمي.

لقراءة أو تغيير أبعاد صفحة الملاحظات، وتبديل الاتجاه، والتحقق من سلوك التصدير، راجع [حجم صفحة الملاحظات](/slides/ar/net/notes-size/).

## **إزالة الملاحظات من شريحة**
يمكن إزالة ملاحظات بعض الشرائح المحددة كما هو موضح في المثال أدناه:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// إنشاء كائن Presentation يمثل ملف عرض تقديمي
Presentation presentation = new Presentation("AccessSlides.pptx");

// إزالة ملاحظات الشريحة الأولى
INotesSlideManager mgr = presentation.Slides[0].NotesSlideManager;
mgr.RemoveNotesSlide();

// حفظ العرض التقديمي إلى القرص
presentation.Save("RemoveNotesAtSpecificSlide_out.pptx", SaveFormat.Pptx);
```


## **إزالة الملاحظات من جميع الشرائح**
يمكن إزالة ملاحظات جميع شرائح العرض التقديمي كما هو موضح في المثال أدناه:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// إنشاء كائن Presentation يمثل ملف عرض تقديمي 
Presentation presentation = new Presentation("AccessSlides.pptx");

// إزالة ملاحظات جميع الشرائح
INotesSlideManager mgr = null;
for (int i = 0; i < presentation.Slides.Count; i++)
{
    mgr = presentation.Slides[i].NotesSlideManager;
    mgr.RemoveNotesSlide();
}
// حفظ العرض التقديمي إلى القرص
presentation.Save("RemoveNotesFromAllSlides_out.pptx", SaveFormat.Pptx);
```


## **إضافة نمط ملاحظات**
تمت إضافة الخاصية NotesStyle إلى واجهة [IMasterNotesSlide](https://reference.aspose.com/slides/ar/net/aspose.slides/imasternotesslide) وفئة [MasterNotesSlide](https://reference.aspose.com/slides/ar/net/aspose.slides/masternotesslide) على التوالي. تحدد هذه الخاصية نمط نص الملاحظات. يتم توضيح التنفيذ في المثال أدناه.

```c#
using Aspose.Slides;

// إنشاء كائن Presentation يمثل ملف العرض التقديمي
using (Presentation presentation = new Presentation("AccessSlides.pptx"))
{
    IMasterNotesSlide notesMaster = presentation.MasterNotesSlideManager.MasterNotesSlide;

    if (notesMaster != null)
    {
        // الحصول على نمط نص MasterNotesSlide
        ITextStyle notesStyle = notesMaster.NotesStyle;

        // تعيين نقطه رمزية للفقرات من المستوى الأول
        IParagraphFormat paragraphFormat = notesStyle.GetLevel(0);
        paragraphFormat.Bullet.Type = BulletType.Symbol;
    }

    // حفظ ملف PPTX إلى القرص
    presentation.Save("AddNotesSlideWithNotesStyle_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

}
```

## **الأسئلة الشائعة**

### أي كيان API يوفّر الوصول إلى ملاحظات شريحة معينة؟

يتم الوصول إلى الملاحظات عبر مدير ملاحظات الشريحة: تحتوي الشريحة على [NotesSlideManager](https://reference.aspose.com/slides/ar/net/aspose.slides/notesslidemanager/) و[خاصية](https://reference.aspose.com/slides/ar/net/aspose.slides/notesslidemanager/notesslide/) تُعيد كائن الملاحظات، أو `null` إذا لم تكن هناك ملاحظات.

### هل هناك اختلافات في دعم الملاحظات عبر إصدارات PowerPoint التي تعمل معها المكتبة؟

تستهدف المكتبة مجموعة واسعة من صيغ Microsoft PowerPoint (من 97 وإصدارات أحدث) وODP؛ يتم دعم الملاحظات داخل هذه الصيغ دون الاعتماد على نسخة مثبتة من PowerPoint.