---
title: تحويل عروض PowerPoint إلى PDF مع الملاحظات على نظام Android
linktitle: PowerPoint إلى PDF مع الملاحظات
type: docs
weight: 50
url: /ar/androidjava/convert-powerpoint-to-pdf-with-notes/
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
- Android
- Java
- Aspose.Slides
description: تحويل صيغ PPT و PPTX إلى PDF مع الملاحظات باستخدام Aspose.Slides لنظام Android عبر Java. الحفاظ على التخطيطات وملاحظات المتحدث لعرض تقديمي احترافي.
---
## **نظرة عامة**

في هذه المقالة، ستتعلم كيفية تحويل عروض PowerPoint إلى تنسيق PDF مع ملاحظات المتحدث باستخدام Aspose.Slides. سيغطي هذا الدليل الخطوات اللازمة ويقدم أمثلة على الشيفرة لمساعدتك على إنجاز هذه المهمة بكفاءة. في نهاية هذه المقالة، ستكون قادرًا على:

- تنفيذ عملية التحويل لتحويل شرائح PowerPoint إلى مستندات PDF مع الحفاظ على ملاحظات المتحدث.
- تخصيص ملف PDF الناتج لضمان تضمين ملاحظات المتحدث وتنسيقها وفقًا لمتطلباتك.

لتحديد أبعاد واتجاه صفحة الملاحظات قبل التصدير، راجع [Notes Page Size](/slides/ar/androidjava/notes-size/).

## **تحويل PowerPoint إلى PDF مع الملاحظات**

يمكن استخدام طريقة `save` في فئة [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/) لتحويل عرض PPT أو PPTX إلى PDF مع ملاحظات المتحدث. باستخدام Aspose.Slides، تقوم بتحميل العرض، وتكوين خيارات التخطيط باستخدام فئة [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/notescommentslayoutingoptions/) لتضمين ملاحظات المتحدث، ثم حفظ الملف كـ PDF. يوضح المقتطف البرمجي التالي كيفية تحويل عرض مثال إلى PDF في عرض شريحة الملاحظات.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
	// تكوين خيارات PDF لتصوير ملاحظات المتحدث.
	NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
	notesOptions.setNotesPosition(NotesPositions.BottomFull); // تصور ملاحظات المتحدث أسفل الشريحة.

	PdfOptions pdfOptions = new PdfOptions();
	pdfOptions.setSlidesLayoutOptions(notesOptions);

	// حفظ العرض التقديمي إلى PDF مع ملاحظات المتحدث.
	presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
	if (presentation != null) presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
قد ترغب في إلقاء نظرة على أداة Aspose [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/ar/conversion).
{{% /alert %}}