---
title: ملاحظات العرض التقديمي
type: docs
weight: 110
url: /ar/net/presentation-notes/
keywords: "ملاحظات, ملاحظات PowerPoint, إضافة ملاحظات, إزالة ملاحظات, عرض PowerPoint, C#, Csharp, Aspose.Slides for .NET"
description: "إضافة وإزالة الملاحظات في عروض PowerPoint باستخدام C# أو .NET"
---

يدعم Aspose.Slides إزالة شرائح الملاحظات من العرض التقديمي. في هذا الموضوع، سنقدم هذه الميزة الجديدة لإزالة الملاحظات وكذلك إضافة شرائح نمط الملاحظات من أي عرض تقديمي. يوفر Aspose.Slides for .NET ميزة إزالة ملاحظات أي شريحة بالإضافة إلى إضافة نمط للملاحظات الموجودة. يمكن للمطورين إزالة الملاحظات بالطرق التالية:

- إزالة ملاحظات شريحة محددة من عرض تقديمي.
- إزالة ملاحظات جميع الشرائح من عرض تقديمي.

## **إزالة الملاحظات من الشريحة**
يمكن إزالة ملاحظات شريحة معينة كما هو موضح في المثال أدناه:
```c#
// إنشاء كائن Presentation يمثل ملف عرض تقديمي
Presentation presentation = new Presentation(dataDir + "AccessSlides.pptx");

// إزالة ملاحظات الشريحة الأولى
INotesSlideManager mgr = presentation.Slides[0].NotesSlideManager;
mgr.RemoveNotesSlide();

// حفظ العرض التقديمي إلى القرص
presentation.Save(dataDir + "RemoveNotesAtSpecificSlide_out.pptx", SaveFormat.Pptx);
```


## **إزالة الملاحظات من جميع الشرائح**
يمكن إزالة ملاحظات جميع شرائح العرض التقديمي كما هو موضح في المثال أدناه:
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


## **إضافة NotesStyle**
تم إضافة خاصية NotesStyle إلى واجهة [IMasterNotesSlide](https://reference.aspose.com/slides/net/aspose.slides/imasternotesslide) والفئة [MasterNotesSlide](https://reference.aspose.com/slides/net/aspose.slides/masternotesslide) على التوالي. تحدد هذه الخاصية نمط نص الملاحظات. يتم توضيح التنفيذ في المثال أدناه.
```c#
// إنشاء فئة Presentation التي تمثل ملف العرض التقديمي
using (Presentation presentation = new Presentation("AccessSlides.pptx"))
{
    IMasterNotesSlide notesMaster = presentation.MasterNotesSlideManager.MasterNotesSlide;

    if (notesMaster != null)
    {
        // الحصول على نمط النص في MasterNotesSlide
        ITextStyle notesStyle = notesMaster.NotesStyle;

        // تعيين نقطه رمزية للمستوى الأول من الفقرات
        IParagraphFormat paragraphFormat = notesStyle.GetLevel(0);
        paragraphFormat.Bullet.Type = BulletType.Symbol;
    }

    // حفظ ملف PPTX إلى القرص
    presentation.Save("AddNotesSlideWithNotesStyle_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

}
```


## **الأسئلة المتكررة**

**ما الكيان API الذي يوفر الوصول إلى ملاحظات شريحة محددة؟**
يتم الوصول إلى الملاحظات من خلال مدير ملاحظات الشريحة: تحتوي الشريحة على [NotesSlideManager](https://reference.aspose.com/slides/net/aspose.slides/notesslidemanager/) و[خاصية](https://reference.aspose.com/slides/net/aspose.slides/notesslidemanager/notesslide/) تُرجِع كائن الملاحظات، أو `null` إذا لم تكن هناك ملاحظات.

**هل هناك اختلافات في دعم الملاحظات عبر إصدارات PowerPoint التي يعمل معها المكتبة؟**
تستهدف المكتبة مجموعة واسعة من تنسيقات Microsoft PowerPoint (97 وما بعد) وODP؛ يتم دعم الملاحظات ضمن هذه التنسيقات دون الاعتماد على نسخة مثبتة من PowerPoint.