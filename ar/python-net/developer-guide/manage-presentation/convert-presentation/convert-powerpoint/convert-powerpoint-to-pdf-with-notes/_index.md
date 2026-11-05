---
title: تحويل العروض التقديمية إلى PDF مع الملاحظات في Python
linktitle: العرض التقديمي إلى PDF مع الملاحظات
type: docs
weight: 50
url: /ar/python-net/convert-powerpoint-to-pdf-with-notes/
keywords:
- تحويل PowerPoint
- تحويل OpenDocument
- تحويل العرض
- تحويل PPT
- تحويل PPTX
- تحويل ODP
- PowerPoint إلى PDF
- OpenDocument إلى PDF
- العرض إلى PDF
- PPT إلى PDF
- PPTX إلى PDF
- ODP إلى PDF
- ملاحظات المتحدث
- PDF مع ملاحظات
- Python
- Aspose.Slides
description: "تحويل صيغ PPT و PPTX و ODP إلى PDF مع ملاحظات باستخدام Aspose.Slides للغة Python. الحفاظ على التخطيطات وملاحظات المتحدث لعروض تقديمية احترافية."
---
## **نظرة عامة**

في هذه المقالة، ستتعلم كيفية تحويل عروض PowerPoint إلى صيغة PDF مع ملاحظات المتحدث باستخدام Aspose.Slides. سيتناول هذا الدليل الخطوات اللازمة ويقدم أمثلة شفرة لمساعدتك على إكمال هذه المهمة بكفاءة. بحلول نهاية هذه المقالة، ستكون قادرًا على:

- تنفيذ عملية التحويل لتحويل شرائح PowerPoint إلى مستندات PDF مع الحفاظ على ملاحظات المتحدث.
- تخصيص ملف PDF الناتج لضمان تضمين ملاحظات المتحدث وتنسيقها وفقًا لمتطلباتك.

لتعيين أبعاد صفحة الملاحظات والاتجاه قبل التصدير، راجع [حجم صفحة الملاحظات](/slides/ar/python-net/notes-size/).

## **تحويل PowerPoint إلى PDF مع الملاحظات**

يمكن استخدام طريقة `save` في فئة [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/) لتحويل عرض PPT أو PPTX إلى PDF مع ملاحظات المتحدث. باستخدام Aspose.Slides، تقوم ببساطة بتحميل العرض، وتكوين خيارات التخطيط باستخدام فئة [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ar/python-net/aspose.slides.export/notescommentslayoutingoptions/) لتضمين ملاحظات المتحدث، ثم حفظ الملف كملف PDF. يوضح المقتطف التالي كيفية تحويل عرض مثال إلى PDF في عرض شريحة الملاحظات.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:

    # تهيئة خيارات PDF لتصيير ملاحظات المتحدث.
    notes_options = slides.export.NotesCommentsLayoutingOptions()
    notes_options.notes_position = slides.export.NotesPositions.BOTTOM_FULL

    pdf_options = slides.export.PdfOptions()
    pdf_options.slides_layout_options = notes_options

    # حفظ العرض التقديمي إلى PDF مع ملاحظات المتحدث.
    presentation.save("output.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

{{% alert color="info" title="Note" %}}
قد ترغب في تجربة أداة Aspose [محوّل PowerPoint إلى PDF عبر الإنترنت](https://products.aspose.app/slides/ar/conversion).
{{% /alert %}}