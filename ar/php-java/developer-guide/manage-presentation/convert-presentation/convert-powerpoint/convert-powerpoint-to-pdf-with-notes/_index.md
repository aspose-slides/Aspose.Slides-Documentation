---
title: تحويل عروض PowerPoint إلى PDF مع الملاحظات في PHP
linktitle: PowerPoint إلى PDF مع الملاحظات
type: docs
weight: 50
url: /ar/php-java/convert-powerpoint-to-pdf-with-notes/
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
- PHP
- Aspose.Slides
description: "تحويل صيغ PPT و PPTX إلى PDF مع ملاحظات باستخدام Aspose.Slides للـ PHP عبر Java. الحفاظ على التخطيطات وملاحظات المتحدث للعروض التقديمية الاحترافية."
---
## **نظرة عامة**

في هذه المقالة، ستتعلم كيفية تحويل عروض PowerPoint إلى صيغة PDF مع ملاحظات المتحدث باستخدام Aspose.Slides. سيغطي هذا الدليل الخطوات الضرورية ويقدّم أمثلة على الشيفرة لمساعدتك على إنجاز هذه المهمة بفعالية. بنهاية هذه المقالة، ستكون قادرًا على:

- تنفيذ عملية التحويل لتحويل شرائح PowerPoint إلى مستندات PDF مع الحفاظ على ملاحظات المتحدث.
- تخصيص ملف PDF الناتج لضمان تضمين ملاحظات المتحدث وتنسيقها وفقًا لمتطلباتك.

لتحديد أبعاد صفحة الملاحظات واتجاهها قبل التصدير، راجع [حجم صفحة الملاحظات](/slides/ar/php-java/notes-size/).

## **تحويل PowerPoint إلى PDF مع الملاحظات**

يمكن استخدام طريقة `save` في فئة [Presentation](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/) لتحويل عرض PPT أو PPTX إلى PDF مع ملاحظات المتحدث. مع Aspose.Slides، تقوم بتحميل العرض، وتكوين خيارات التخطيط باستخدام فئة [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ar/php-java/aspose.slides/notescommentslayoutingoptions/) لتضمين ملاحظات المتحدث، ثم حفظ الملف كـ PDF. يوضح المقتطف البرمجي التالي كيفية تحويل عرض تقديمي نموذجي إلى PDF في وضع ملاحظات الشريحة.

```php
$presentation = new Presentation("sample.pptx");

// تكوين خيارات PDF لتصوير ملاحظات المتحدث.
$notesOptions = new NotesCommentsLayoutingOptions();
$notesOptions->setNotesPosition(NotesPositions::BottomFull); // تصوير ملاحظات المتحدث أسفل الشريحة.

$pdfOptions = new PdfOptions();
$pdfOptions->setSlidesLayoutOptions($notesOptions);

// حفظ العرض التقديمي كـ PDF مع ملاحظات المتحدث.
$presentation->save("output.pdf", SaveFormat::Pdf, $pdfOptions);
$presentation->dispose();
```

{{% alert color="info" title="Note" %}}
قد ترغب في تجربة [محول PowerPoint إلى PDF عبر الإنترنت]https://products.aspose.app/slides/ar/conversion.
{{% /alert %}}