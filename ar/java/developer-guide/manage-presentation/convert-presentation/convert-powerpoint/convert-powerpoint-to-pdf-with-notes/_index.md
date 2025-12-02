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
- حفظ العرض التقديمي كملف PDF
- حفظ PPT كملف PDF
- حفظ PPTX كملف PDF
- تصدير PPT إلى PDF
- تصدير PPTX إلى PDF
- ملاحظات المتحدث
- PDF مع الملاحظات
- Java
- Aspose.Slides
description: "تحويل صيغ PPT و PPTX إلى PDF مع الملاحظات باستخدام Aspose.Slides for Java. الحفاظ على التخطيطات وملاحظات المتحدث للعروض التقديمية الاحترافية."
---

## **نظرة عامة**

في هذه المقالة، ستتعلم كيفية تحويل عروض PowerPoint التقديمية إلى تنسيق PDF مع ملاحظات المتحدث باستخدام Aspose.Slides. سيغطي هذا الدليل الخطوات اللازمة ويقدم أمثلة على الشيفرة لمساعدتك على إتمام هذه المهمة بكفاءة. بنهاية هذه المقالة، ستكون قادرًا على:

- تنفيذ عملية التحويل لتحويل شرائح PowerPoint إلى مستندات PDF مع الحفاظ على ملاحظات المتحدث.
- تخصيص ملف PDF الناتج لضمان تضمين ملاحظات المتحدث وتنسيقها وفقًا لمتطلباتك.

## **تحويل PowerPoint إلى PDF مع الملاحظات**

يمكن استخدام طريقة `save` في الفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) لتحويل عرض تقديمي بصيغة PPT أو PPTX إلى PDF مع ملاحظات المتحدث. باستخدام Aspose.Slides، تقوم ببساطة بتحميل العرض التقديمي، وتكوين خيارات التخطيط باستخدام الفئة [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/java/com.aspose.slides/notescommentslayoutingoptions/) لتضمين ملاحظات المتحدث، ثم حفظ الملف كملف PDF. يوضح المقتطف البرمجي التالي كيفية تحويل عرض تقديمي عينة إلى PDF في وضع شريحة الملاحظات.
```java
Presentation presentation = new Presentation("sample.pptx");

// تكوين خيارات PDF لتصوير ملاحظات المتحدث.
NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
notesOptions.setNotesPosition(NotesPositions.BottomFull); // عرض ملاحظات المتحدث أسفل الشريحة.

PdfOptions pdfOptions = new PdfOptions();
pdfOptions.setSlidesLayoutOptions(notesOptions);

// حفظ العرض التقديمي كملف PDF مع ملاحظات المتحدث.
presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
presentation.dispose();
```


{{% alert color="primary" %}} 
قد ترغب في الاطلاع على Aspose [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/conversion). 
{{% /alert %}}