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
  - حفظ العرض كـ PDF
  - حفظ PPT كـ PDF
  - حفظ PPTX كـ PDF
  - تصدير PPT إلى PDF
  - تصدير PPTX إلى PDF
  - ملاحظات المتحدث
  - PDF مع الملاحظات
  - .NET
  - C#
  - Aspose.Slides
description: "تحويل صيغ PPT و PPTX إلى PDF مع الملاحظات باستخدام Aspose.Slides لـ .NET. الحفاظ على التنسيقات وملاحظات المتحدث لعرض تقديمي احترافي."
---

## **نظرة عامة**

في هذه المقالة، ستتعلم如何 تحويل عروض PowerPoint إلى تنسيق PDF مع ملاحظات المتحدث باستخدام Aspose.Slides. سيتناول هذا الدليل الخطوات اللازمة ويقدم أمثلة على الشيفرة لمساعدتك في إنجاز هذه المهمة بفعالية. في نهاية هذه المقالة، ستكون قادرًا على:

- تنفيذ عملية التحويل لتحويل شرائح PowerPoint إلى مستندات PDF مع الحفاظ على ملاحظات المتحدث.
- تخصيص ملف PDF الناتج لضمان تضمين ملاحظات المتحدث وتنسيقها وفقًا لمتطلباتك.

## **تحويل PowerPoint إلى PDF مع الملاحظات**

يمكن استخدام طريقة `Save` في الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) لتحويل عرض PPT أو PPTX إلى PDF مع ملاحظات المتحدث. باستخدام Aspose.Slides، يمكنك ببساطة تحميل العرض، وتكوين خيارات التخطيط باستخدام الفئة [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/notescommentslayoutingoptions/) لتضمين ملاحظات المتحدث، ثم حفظ الملف كـ PDF. يوضح المقتطف البرمجي التالي كيفية تحويل عرض توضيحي نموذجي إلى PDF في وضع شريحة الملاحظات.
```cs
using (Presentation presentation = new Presentation("sample.pptx"))
{
    // تكوين خيارات PDF لتصيير ملاحظات المتحدث.
    PdfOptions pdfOptions = new PdfOptions
    {
        SlidesLayoutOptions = new NotesCommentsLayoutingOptions
        {
            NotesPosition = NotesPositions.BottomFull // تصيير ملاحظات المتحدث أسفل الشريحة.
        }
    };

    // حفظ العرض التقديمي إلى PDF مع ملاحظات المتحدث.
    presentation.Save("output.pdf", SaveFormat.Pdf, pdfOptions);
}
```


{{% alert color="primary" %}} 

قد ترغب في تجربة أداة Aspose [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/conversion). 

{{% /alert %}}