---
title: تحويل عروض PowerPoint إلى PDF مع الملاحظات في .NET
linktitle: PowerPoint إلى PDF مع الملاحظات
type: docs
weight: 50
url: /ar/net/convert-powerpoint-to-pdf-with-notes/
keywords:
- تحويل PowerPoint
- تحويل العرض
- تحويل الشريحة
- تحويل PPT
- تحويل PPTX
- PowerPoint إلى PDF
- العرض إلى PDF
- الشريحة إلى PDF
- PPT إلى PDF
- PPTX إلى PDF
- حفظ العرض كملف PDF
- حفظ PPT كملف PDF
- حفظ PPTX كملف PDF
- تصدير PPT إلى PDF
- تصدير PPTX إلى PDF
- ملاحظات المتحدث
- PDF مع ملاحظات
- .NET
- C#
- Aspose.Slides
description: "تحويل صيغ PPT و PPTX إلى PDF مع الملاحظات باستخدام Aspose.Slides لـ .NET. الحفاظ على التخطيطات وملاحظات المتحدث لعروض تقديمية احترافية."
---
## **نظرة عامة**

في هذه المقالة، ستتعلم كيفية تحويل عروض PowerPoint إلى صيغة PDF مع ملاحظات المتحدث باستخدام Aspose.Slides. يغطي هذا الدليل الخطوات اللازمة ويقدم أمثلة على الشيفرة لمساعدتك في إنجاز هذه المهمة بكفاءة. في نهاية هذه المقالة، ستكون قادرًا على:

- تنفيذ عملية التحويل لتحويل شرائح PowerPoint إلى مستندات PDF مع الحفاظ على ملاحظات المتحدث.
- تخصيص ملف PDF الناتج لضمان تضمين ملاحظات المتحدث وتنسيقها وفق متطلباتك.

لتعيين أبعاد صفحة الملاحظات واتجاهها قبل التصدير، راجع [Notes Page Size](/slides/ar/net/notes-size/).

## **تحويل PowerPoint إلى PDF مع الملاحظات**

يمكن استخدام طريقة `Save` في فئة [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/) لتحويل عرض PPT أو PPTX إلى PDF مع ملاحظات المتحدث. باستخدام Aspose.Slides، تقوم ببساطة بتحميل العرض، وتكوين خيارات التخطيط باستخدام فئة [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ar/net/aspose.slides.export/notescommentslayoutingoptions/) لتضمين ملاحظات المتحدث، ثم حفظ الملف كملف PDF. يوضح المقتطف التالي كيفية تحويل عرض تقديمي نموذج إلى PDF في وضع ملاحظات الشريحة.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    // تكوين خيارات PDF لتصيير ملاحظات المتحدث.
    PdfOptions pdfOptions = new PdfOptions
    {
        SlidesLayoutOptions = new NotesCommentsLayoutingOptions
        {
            NotesPosition = NotesPositions.BottomFull // عرض ملاحظات المتحدث أسفل الشريحة.
        }
    };

    // حفظ العرض بصيغة PDF مع ملاحظات المتحدث.
    presentation.Save("output.pdf", SaveFormat.Pdf, pdfOptions);
}
```

{{% alert color="info" %}} 

قد ترغب في تجربة أداة Aspose [محول PowerPoint إلى PDF عبر الإنترنت](https://products.aspose.app/slides/ar/conversion). 

{{% /alert %}}