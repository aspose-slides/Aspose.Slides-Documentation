---
title: ملاحظات العرض
type: docs
weight: 110
url: /ar/net/presentation-notes/
keywords: "ملاحظات، ملاحظات PowerPoint، إضافة ملاحظات، إزالة ملاحظات، عرض PowerPoint، C#، Csharp، Aspose.Slides لـ .NET"
description: "إضافة وإزالة ملاحظات في عروض PowerPoint باستخدام C# أو .NET"
---



تدعم Aspose.Slides إزالة شرائح الملاحظات من العرض. في هذا الموضوع، سنقدم هذه الميزة الجديدة لإزالة الملاحظات بالإضافة إلى إضافة شرائح بنمط الملاحظات من أي عرض. توفر Aspose.Slides لـ .NET ميزة إزالة ملاحظات أي شريحة بالإضافة إلى إضافة نمط للملاحظات الحالية. يمكن للمطورين إزالة الملاحظات بالطرق التالية:

- إزالة ملاحظات شريحة محددة من العرض.
- إزالة ملاحظات كل الشرائح في العرض.
## **إزالة الملاحظات من الشريحة**
يمكن إزالة ملاحظات شريحة معينة كما هو موضح في المثال أدناه:

```c#
// إنشاء كائن Presentation يمثل ملف العرض 
Presentation presentation = new Presentation(dataDir + "AccessSlides.pptx");

// إزالة ملاحظات الشريحة الأولى
INotesSlideManager mgr = presentation.Slides[0].NotesSlideManager;
mgr.RemoveNotesSlide();

// حفظ العرض إلى القرص
presentation.Save(dataDir + "RemoveNotesAtSpecificSlide_out.pptx", SaveFormat.Pptx);
```


## **إزالة الملاحظات من جميع الشرائح**
يمكن إزالة ملاحظات جميع الشرائح في العرض كما هو موضح في المثال أدناه:

```c#
// إنشاء كائن Presentation يمثل ملف العرض 
Presentation presentation = new Presentation("AccessSlides.pptx");

// إزالة ملاحظات جميع الشرائح
INotesSlideManager mgr = null;
for (int i = 0; i < presentation.Slides.Count; i++)
{
    mgr = presentation.Slides[i].NotesSlideManager;
    mgr.RemoveNotesSlide();
}
// حفظ العرض إلى القرص
presentation.Save("RemoveNotesFromAllSlides_out.pptx", SaveFormat.Pptx);
```


## **إضافة نمط الملاحظات**
تم إضافة خاصية NotesStyle إلى [IMasterNotesSlide](https://reference.aspose.com/slides/net/aspose.slides/imasternotesslide) و [MasterNotesSlide](https://reference.aspose.com/slides/net/aspose.slides/masternotesslide) على التوالي. تحدد هذه الخاصية نمط نص الملاحظات.  يتم توضيح التنفيذ في المثال أدناه.

```c#
// إنشاء كائن من فئة Presentation يمثل ملف العرض
using (Presentation presentation = new Presentation("AccessSlides.pptx"))
{
    IMasterNotesSlide notesMaster = presentation.MasterNotesSlideManager.MasterNotesSlide;

    if (notesMaster != null)
    {
        // الحصول على نمط نص MasterNotesSlide
        ITextStyle notesStyle = notesMaster.NotesStyle;

        // تعيين رمز كرمز للنقاط للفقرات بمستوى أول
        IParagraphFormat paragraphFormat = notesStyle.GetLevel(0);
        paragraphFormat.Bullet.Type = BulletType.Symbol;
    }

    // حفظ ملف PPTX إلى القرص
    presentation.Save("AddNotesSlideWithNotesStyle_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

}
```