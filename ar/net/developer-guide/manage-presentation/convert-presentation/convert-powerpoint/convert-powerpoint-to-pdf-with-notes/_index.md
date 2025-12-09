---
title: تحويل عروض PowerPoint إلى PDF مع الملاحظات في .NET
linktitle: PowerPoint إلى PDF مع الملاحظات
type: docs
weight: 50
url: /ar/net/convert-powerpoint-to-pdf-with-notes/
keywords:
- تحويل PowerPoint
- تحويل العرض التقديمي
- تحويل الشريحة
- تحويل PPT
- تحويل PPTX
- PowerPoint إلى PDF
- العرض التقديمي إلى PDF
- الشريحة إلى PDF
- PPT إلى PDF
- PPTX إلى PDF
- حفظ العرض التقديمي كـ PDF
- حفظ PPT كـ PDF
- حفظ PPTX كـ PDF
- تصدير PPT إلى PDF
- تصدير PPTX إلى PDF
- ملاحظات المتحدث
- PDF مع ملاحظات
- .NET
- C#
- Aspose.Slides
description: "تحويل صيغ PPT و PPTX إلى PDF مع الملاحظات باستخدام Aspose.Slides لـ .NET. الحفاظ على التخطيطات وملاحظات المتحدث للعروض التقديمية المهنية."
---

## **نظرة عامة**

في هذه المقالة، ستتعلم كيفية تحويل عروض PowerPoint إلى صيغة PDF مع ملاحظات المتحدث باستخدام Aspose.Slides. سيتضمن هذا الدليل الخطوات اللازمة ويوفر أمثلة على التعليمات البرمجية لمساعدتك في إتمام هذه المهمة بفعالية. بنهاية هذه المقالة، ستكون قادرًا على:

- تنفيذ عملية التحويل لتحويل شرائح PowerPoint إلى مستندات PDF مع الحفاظ على ملاحظات المتحدث.
- تخصيص ملف PDF الناتج لضمان تضمين ملاحظات المتحدث وتنسيقها وفقًا لمتطلباتك.

## **تحويل PowerPoint إلى PDF مع الملاحظات**

يمكن استخدام طريقة `Save` في الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) لتحويل عرض PPT أو PPTX إلى PDF مع ملاحظات المتحدث. باستخدام Aspose.Slides، تقوم ببساطة بتحميل العرض، وتكوين خيارات التخطيط باستخدام الفئة [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/notescommentslayoutingoptions/) لتضمن ملاحظات المتحدث، ثم حفظ الملف كـ PDF. يوضح مقطع الشيفرة التالي كيفية تحويل عرض تجريبي إلى PDF في وضع ملاحظات الشرائح.
```cs
using (Presentation presentation = new Presentation("sample.pptx"))
{
    // تهيئة خيارات PDF لتصوير ملاحظات المتحدث.
    PdfOptions pdfOptions = new PdfOptions
    {
        SlidesLayoutOptions = new NotesCommentsLayoutingOptions
        {
            NotesPosition = NotesPositions.BottomFull // عرض ملاحظات المتحدث أسفل الشريحة.
        }
    };

    // حفظ العرض التقديمي كملف PDF مع ملاحظات المتحدث.
    presentation.Save("output.pdf", SaveFormat.Pdf, pdfOptions);
}
```


{{% alert color="primary" %}} 
قد ترغب في الاطلاع على Aspose [محول PowerPoint إلى PDF عبر الإنترنت](https://products.aspose.app/slides/conversion). 
{{% /alert %}}