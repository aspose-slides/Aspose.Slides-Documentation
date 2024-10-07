---
title: تحويل PowerPoint إلى SWF فلاش
type: docs
weight: 80
url: /net/convert-powerpoint-to-swf-flash/
keywords: "تحويل PowerPoint، تقديم، PowerPoint إلى SWF، SWF فلاش PPT إلى SWF، PPTX إلى SWF، C#، Csharp، .NET"
description: "تحويل تقديم PowerPoint إلى SWF فلاش في C# أو .NET"
---

يمكن استخدام الطريقة [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save/index) المكشوفة من قبل [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) لتحويل العرض التقديمي بالكامل إلى وثيقة SWF. يمكنك أيضًا تضمين التعليقات في SWF الناتج باستخدام [SWFOptions](https://reference.aspose.com/slides/net/aspose.slides.export/swfoptions) وفئة [INotesCommentsLayoutingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/inotescommentslayoutingoptions) . توضح المثال التالي كيفية تحويل عرض تقديمي إلى وثيقة SWF باستخدام الخيارات المقدمة من فئة SWFOptions.

```c#
// إنشاء كائن Presentation يمثل ملف تقديم
using (Presentation presentation = new Presentation("HelloWorld.pptx"))
{
    SwfOptions swfOptions = new SwfOptions();
    swfOptions.ViewerIncluded = false;

    INotesCommentsLayoutingOptions notesOptions = swfOptions.NotesCommentsLayouting;
    notesOptions.NotesPosition = NotesPositions.BottomFull;

    // حفظ عرض تقديمي وصفحات الملاحظات
    presentation.Save("SaveAsSwf_out.swf", SaveFormat.Swf, swfOptions);
    swfOptions.ViewerIncluded = true;
    presentation.Save("SaveNotes_out.swf", SaveFormat.Swf, swfOptions);
}
```