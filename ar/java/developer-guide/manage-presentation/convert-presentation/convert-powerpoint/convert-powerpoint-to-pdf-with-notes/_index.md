---
title: تحويل عروض PowerPoint إلى PDF مع الملاحظات في Java
linktitle: PowerPoint إلى PDF مع الملاحظات
type: docs
weight: 50
url: /ar/java/convert-powerpoint-to-pdf-with-notes/
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
- Java
- Aspose.Slides
description: "تحويل صيغ PPT و PPTX إلى PDF مع الملاحظات باستخدام Aspose.Slides للغة Java. الحفاظ على التخطيطات وملاحظات المتحدث لعروض تقديمية احترافية."
---
## **نظرة عامة**

في هذه المقالة، ستتعلم كيفية تحويل عروض PowerPoint إلى تنسيق PDF مع ملاحظات المتحدث باستخدام Aspose.Slides. سيتناول هذا الدليل الخطوات اللازمة ويوفر أمثلة على الشيفرة لمساعدتك على إنجاز هذه المهمة بكفاءة. بحلول نهاية هذه المقالة، ستكون قادرًا على:

- تنفيذ عملية التحويل لتحويل شرائح PowerPoint إلى مستندات PDF مع الحفاظ على ملاحظات المتحدث.
- تخصيص PDF الناتج للتأكد من تضمين ملاحظات المتحدث وتنسيقها وفقًا لمتطلباتك.

لتعيين أبعاد واتجاه صفحة الملاحظات قبل التصدير، انظر [حجم صفحة الملاحظات](/slides/ar/java/notes-size/).

## **تحويل PowerPoint إلى PDF مع الملاحظات**

يمكن استخدام طريقة `save` في فئة [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/) لتحويل عرض PPT أو PPTX إلى PDF مع ملاحظات المتحدث. باستخدام Aspose.Slides، تقوم ببساطة بتحميل العرض، وتكوين خيارات التخطيط باستخدام فئة [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ar/java/com.aspose.slides/notescommentslayoutingoptions/) لتضمين ملاحظات المتحدث، ثم حفظ الملف كملف PDF. يوضح مقطع الشيفرة التالي كيفية تحويل عرض توضيحي تجريبي إلى PDF في وضع ملاحظات الشريحة.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");

// تكوين خيارات PDF لعرض ملاحظات المتحدث.
NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
notesOptions.setNotesPosition(NotesPositions.BottomFull); // عرض ملاحظات المتحدث أسفل الشريحة.

PdfOptions pdfOptions = new PdfOptions();
pdfOptions.setSlidesLayoutOptions(notesOptions);

// حفظ العرض التقديمي كملف PDF مع ملاحظات المتحدث.
presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
presentation.dispose();
```

{{% alert color="info" title="Note" %}}
قد ترغب في الاطلاع على Aspose [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/ar/conversion).
{{% /alert %}}