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
description: "تحويل صيغ PPT و PPTX إلى PDF مع ملاحظات باستخدام Aspose.Slides لـ Java. حافظ على التخطيطات وملاحظات المتحدث لعروض تقديمية احترافية."
---
## **نظرة عامة**

في هذه المقالة، ستتعلم كيفية تحويل عروض PowerPoint إلى تنسيق PDF مع ملاحظات المتحدث باستخدام Aspose.Slides. سيغطي هذا الدليل الخطوات اللازمة ويوفر أمثلة على الشيفرة لمساعدتك في إنجاز هذه المهمة بفعالية. بنهاية هذه المقالة، ستكون قادرًا على:

- تنفيذ عملية التحويل لتحويل شرائح PowerPoint إلى مستندات PDF مع الحفاظ على ملاحظات المتحدث.
- تخصيص ملف PDF الناتج لضمان تضمين ملاحظات المتحدث وتنسيقها وفقًا لمتطلباتك.

## **تحويل PowerPoint إلى PDF مع الملاحظات**

`save` طريقة في فئة [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/) يمكن استخدامها لتحويل عرض PPT أو PPTX إلى PDF مع ملاحظات المتحدث. باستخدام Aspose.Slides، تقوم ببساطة بتحميل العرض، وضبط خيارات التخطيط باستخدام فئة [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ar/java/com.aspose.slides/notescommentslayoutingoptions/) لتضمين ملاحظات المتحدث، ثم حفظ الملف كـ PDF. يوضح المقتطف البرمجي التالي كيفية تحويل عرض تقديمي مثال إلى PDF في وضع ملاحظات الشريحة.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");

// تكوين خيارات PDF لتصوير ملاحظات المتحدث.
NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
notesOptions.setNotesPosition(NotesPositions.BottomFull); // عرض ملاحظات المتحدث أسفل الشريحة.

PdfOptions pdfOptions = new PdfOptions();
pdfOptions.setSlidesLayoutOptions(notesOptions);

// Save the presentation to PDF with speaker notes.
presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
presentation.dispose();
```

{{% alert color="info" %}} 
قد ترغب في الاطلاع على أداة Aspose [محول PowerPoint إلى PDF عبر الإنترنت](https://products.aspose.app/slides/ar/conversion). 
{{% /alert %}}