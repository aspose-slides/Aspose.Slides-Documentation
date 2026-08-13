---
title: تحويل عروض PowerPoint إلى PDF مع الملاحظات على Android
linktitle: PowerPoint إلى PDF مع الملاحظات
type: docs
weight: 50
url: /ar/androidjava/convert-powerpoint-to-pdf-with-notes/
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
- Android
- Java
- Aspose.Slides
description: "تحويل صيغ PPT و PPTX إلى PDF مع ملاحظات باستخدام Aspose.Slides لأندرويد عبر جافا. الحفاظ على التخطيطات وملاحظات المتحدث للعروض التقديمية الاحترافية."
---
## **نظرة عامة**

في هذه المقالة، ستتعلم كيفية تحويل عروض PowerPoint إلى صيغة PDF مع ملاحظات المتحدث باستخدام Aspose.Slides. سيتناول هذا الدليل الخطوات الضرورية ويوفر أمثلة على الشيفرة لمساعدتك على إنجاز هذه المهمة بفعالية. بنهاية هذه المقالة، سيمكنك:

- تنفيذ عملية التحويل لتحويل شرائح PowerPoint إلى مستندات PDF مع الحفاظ على ملاحظات المتحدث.
- تخصيص ملف PDF الناتج لضمان تضمين ملاحظات المتحدث وتنسيقها وفق متطلباتك.

## **تحويل PowerPoint إلى PDF مع الملاحظات**

يمكن استخدام طريقة `save` في فئة [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/) لتحويل عرض PPT أو PPTX إلى PDF مع ملاحظات المتحدث. باستخدام Aspose.Slides، تقوم بتحميل العرض، وتكوين خيارات التخطيط باستخدام فئة [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/notescommentslayoutingoptions/) لتضمين ملاحظات المتحدث، ثم حفظ الملف كـ PDF. يوضح المقتطف البرمجي التالي كيفية تحويل عرض توضيحي نموذجي إلى PDF في طريقة عرض ملاحظات الشرائح.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
	// تهيئة خيارات PDF لعرض ملاحظات المتحدث.
	NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
	notesOptions.setNotesPosition(NotesPositions.BottomFull); // عرض ملاحظات المتحدث أسفل الشريحة.

	PdfOptions pdfOptions = new PdfOptions();
	pdfOptions.setSlidesLayoutOptions(notesOptions);

	// حفظ العرض التقديمي كـ PDF مع ملاحظات المتحدث.
	presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
	if (presentation != null) presentation.dispose();
}
```

{{% alert color="info" %}} 
قد ترغب في تجربة أداة Aspose [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/ar/conversion). 
{{% /alert %}}