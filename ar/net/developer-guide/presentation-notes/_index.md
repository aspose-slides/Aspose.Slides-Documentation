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
- الملاحظات الرئيسية
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "خصّص ملاحظات العرض التقديمي باستخدام Aspose.Slides لـ .NET. اعمل بسلاسة مع ملاحظات PowerPoint وOpenDocument لتعزيز إنتاجيتك."
---

يدعم Aspose.Slides حذف شرائح الملاحظات من العرض التقديمي. في هذا الموضوع، سنقدم هذه الميزة الجديدة لحذف الملاحظات وإضافة شرائح نمط الملاحظات من أي عرض تقديمي. يوفر Aspose.Slides for .NET إمكانية حذف ملاحظات أي شريحة بالإضافة إلى إضافة نمط للملاحظات الموجودة. يمكن للمطورين حذف الملاحظات بالطرق التالية:

- حذف ملاحظات شريحة محددة من العرض التقديمي.
- حذف ملاحظات جميع الشرائح من العرض التقديمي.

## **حذف الملاحظات من شريحة**
يمكن حذف ملاحظات بعض الشرائح المحددة كما هو موضح في المثال أدناه:
```c#
// إنشاء كائن Presentation يمثل ملف عرض تقديمي 
Presentation presentation = new Presentation(dataDir + "AccessSlides.pptx");

// إزالة ملاحظات الشريحة الأولى
INotesSlideManager mgr = presentation.Slides[0].NotesSlideManager;
mgr.RemoveNotesSlide();

// حفظ العرض التقديمي إلى القرص
presentation.Save(dataDir + "RemoveNotesAtSpecificSlide_out.pptx", SaveFormat.Pptx);
```


## **حذف الملاحظات من جميع الشرائح**
يمكن حذف ملاحظات جميع شرائح العرض التقديمي كما هو موضح في المثال أدناه:
```c#
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
تمت إضافة الخاصية NotesStyle إلى واجهة [IMasterNotesSlide](https://reference.aspose.com/slides/net/aspose.slides/imasternotesslide) وفئة [MasterNotesSlide](https://reference.aspose.com/slides/net/aspose.slides/masternotesslide) على التوالي. تحدد هذه الخاصية نمط نص الملاحظات. تم توضيح التنفيذ في المثال أدناه.
```c#
// إنشاء فئة Presentation التي تمثل ملف العرض التقديمي
using (Presentation presentation = new Presentation("AccessSlides.pptx"))
{
    IMasterNotesSlide notesMaster = presentation.MasterNotesSlideManager.MasterNotesSlide;

    if (notesMaster != null)
    {
        // الحصول على نمط نص MasterNotesSlide
        ITextStyle notesStyle = notesMaster.NotesStyle;

        // تعيين نقطه رمزية للمستوى الأول من الفقرات
        IParagraphFormat paragraphFormat = notesStyle.GetLevel(0);
        paragraphFormat.Bullet.Type = BulletType.Symbol;
    }

    // حفظ ملف PPTX إلى القرص
    presentation.Save("AddNotesSlideWithNotesStyle_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

}
```


## **الأسئلة الشائعة**

**ما كيان الـ API الذي يتيح الوصول إلى ملاحظات شريحة محددة؟**
يتم الوصول إلى الملاحظات عبر مدير ملاحظات الشريحة: تحتوي الشريحة على [NotesSlideManager](https://reference.aspose.com/slides/net/aspose.slides/notesslidemanager/) و[خاصية](https://reference.aspose.com/slides/net/aspose.slides/notesslidemanager/notesslide/) تُعيد كائن الملاحظات، أو `null` إذا لم توجد ملاحظات.

**هل توجد اختلافات في دعم الملاحظات عبر إصدارات PowerPoint التي يعمل معها المكتبة؟**
تستهدف المكتبة مجموعة واسعة من صيغ Microsoft PowerPoint (97 وما بعد) وODP؛ يتم دعم الملاحظات ضمن هذه الصيغ دون الاعتماد على نسخة مثبتة من PowerPoint.