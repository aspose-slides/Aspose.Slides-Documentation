---
title: تحويل PowerPoint إلى PDF مع الملاحظات في C#
linktitle: تحويل PowerPoint إلى PDF مع الملاحظات
type: docs
weight: 50
url: /net/convert-powerpoint-to-pdf-with-notes/
keywords: "تحويل PowerPoint، عرض تقديمي، PowerPoint إلى PDF، ملاحظات، c#، csharp، .NET، Aspose.Slides"
description: "تحويل PowerPoint إلى PDF مع الملاحظات باستخدام C# أو .NET"
---

## **نظرة عامة**

أثناء [تحويل PowerPoint إلى PDF](https://docs.aspose.com/slides/net/convert-powerpoint-to-pdf/)، يمكنك أيضًا التحكم في كيفية وضع الملاحظات والتعليقات في الوثيقة المصدرة. يتناول هذا الموضع الموضوعات التالية.

- [C# تحويل PPT إلى PDF مع الملاحظات](#convert-powerpoint-to-pdf-with-notes)
- [C# تحويل PPTX إلى PDF مع الملاحظات](#convert-powerpoint-to-pdf-with-notes)
- [C# تحويل ODP إلى PDF مع الملاحظات](#convert-powerpoint-to-pdf-with-notes)
- [C# تحويل PowerPoint إلى PDF مع الملاحظات](#convert-powerpoint-to-pdf-with-notes)

## **تحويل PowerPoint إلى PDF مع الملاحظات**

يمكن استخدام [طريقة حفظ](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save/index) التي تعرضها فئة Presentation لتحويل عرض PowerPoint PPT أو PPTX إلى PDF مع الملاحظات. يتم حفظ عرض Microsoft PowerPoint إلى PDF مع الملاحظات باستخدام Aspose.Slides لـ .NET في عمليتين فقط. تقوم ببساطة بفتح العرض وحفظه إلى PDF مع الملاحظات. تعمل الشيفرات البرمجية C# أدناه على تحديث العرض النموذجي إلى PDF في عرض ملاحظات الشرائح:

```c#
// إنشاء كائن Presentation يمثل ملف عرض تقديمي
Presentation presentation = new Presentation("SelectedSlides.pptx");
Presentation auxPresentation = new Presentation();

ISlide slide = presentation.Slides[0];

auxPresentation.Slides.InsertClone(0, slide);

// إعداد نوع وحجم الشريحة 
//auxPresentation.SlideSize.SetSize(presentation.SlideSize.Size.Width, presentation.SlideSize.Size.Height,SlideSizeScaleType.EnsureFit);
auxPresentation.SlideSize.SetSize(612F, 792F, SlideSizeScaleType.EnsureFit);

PdfOptions pdfOptions = new PdfOptions();
pdfOptions.NotesCommentsLayouting.NotesPosition = NotesPositions.BottomFull;

auxPresentation.Save("PDFnotes_out.pdf", SaveFormat.Pdf, pdfOptions);
```

{{% alert color="primary" %}} 

قد ترغب في الاطلاع على Aspose [تحويل PowerPoint إلى PDF](https://products.aspose.app/slides/conversion/powerpoint-to-pdf) أو [تحويل PPT إلى PDF](https://products.aspose.app/slides/conversion/ppt-to-pdf). 

{{% /alert %}} 