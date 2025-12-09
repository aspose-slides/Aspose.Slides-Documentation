---
title: تحويل عروض PowerPoint إلى TIFF مع الملاحظات في Java
linktitle: PowerPoint إلى TIFF مع الملاحظات
type: docs
weight: 100
url: /ar/java/convert-powerpoint-to-tiff-with-notes/
keywords:
- تحويل PowerPoint
- تحويل العرض التقديمي
- تحويل الشريحة
- تحويل PPT
- تحويل PPTX
- PowerPoint إلى TIFF
- العرض التقديمي إلى TIFF
- الشريحة إلى TIFF
- PPT إلى TIFF
- PPTX إلى TIFF
- حفظ PPT كـ TIFF
- حفظ PPTX كـ TIFF
- تصدير PPT إلى TIFF
- تصدير PPTX إلى TIFF
- PowerPoint مع الملاحظات
- العرض التقديمي مع الملاحظات
- الشريحة مع الملاحظات
- PPT مع الملاحظات
- PPTX مع الملاحظات
- TIFF مع الملاحظات
- Java
- Aspose.Slides
description: "تحويل عروض PowerPoint إلى TIFF مع الملاحظات باستخدام Aspose.Slides للـ Java. تعلّم كيفية تصدير الشرائح مع ملاحظات المتحدث بكفاءة."
---

## **نظرة عامة**

Aspose.Slides for Java توفر حلاً بسيطًا لتحويل عروض PowerPoint وOpenDocument (PPT وPPTX وODP) مع الملاحظات إلى تنسيق TIFF. يُستخدم هذا التنسيق على نطاق واسع لتخزين الصور عالية الجودة والطباعة وأرشفة المستندات. باستخدام Aspose.Slides، يمكنك ليس فقط تصدير العروض بالكامل مع ملاحظات المتحدث بل أيضًا إنشاء صور مصغرة للشرائح في عرض ملاحظات الشريحة. عملية التحويل بسيطة وفعّالة، حيث يتم الاستفادة من طريقة `save` في الفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) لتحويل العرض بالكامل إلى سلسلة من صور TIFF مع الحفاظ على الملاحظات والتخطيط.

## **تحويل عرض تقديمي إلى TIFF مع الملاحظات**

حفظ عرض PowerPoint أو OpenDocument كملف TIFF مع الملاحظات باستخدام Aspose.Slides for Java يتضمن الخطوات التالية:

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/): تحميل ملف PowerPoint أو OpenDocument.  
1. تكوين خيارات تخطيط الإخراج: استخدم الفئة [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/java/com.aspose.slides/notescommentslayoutingoptions/) لتحديد كيفية عرض الملاحظات والتعليقات.  
1. حفظ العرض التقديمي كملف TIFF: مرّر الخيارات المكوّنة إلى طريقة [save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int-com.aspose.slides.ISaveOptions-).

لنفترض أن لدينا ملف "speaker_notes.pptx" يحتوي على الشريحة التالية:

![الشريحة مع ملاحظات المتحدث](slide_with_notes.png)

المقتطف البرمجي أدناه يوضح كيفية تحويل العرض إلى صورة TIFF في عرض ملاحظات الشريحة باستخدام طريقة [setSlidesLayoutOptions](https://reference.aspose.com/slides/java/com.aspose.slides/tiffoptions/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-).
```java
// إنشاء كائن من الفئة Presentation التي تمثل ملف عرض تقديمي.
Presentation presentation = new Presentation("speaker_notes.pptx");
try {
    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomFull); // عرض الملاحظات أسفل الشريحة.

    // تهيئة خيارات TIFF مع تخطيط الملاحظات.
    TiffOptions tiffOptions = new TiffOptions();
    tiffOptions.setDpiX(300);
    tiffOptions.setDpiY(300);
    tiffOptions.setSlidesLayoutOptions(notesOptions);

    // حفظ العرض التقديمي كملف TIFF مع ملاحظات المتحدث.
    presentation.save("TIFF_with_notes.tiff", SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```


النتيجة:

![صورة TIFF مع ملاحظات المتحدث](TIFF_with_notes.png)

{{% alert title="Tip" color="primary" %}}
تحقق من أداة Aspose [Free PowerPoint to Poster Converter](https://products.aspose.app/slides/conversion/convert-ppt-to-poster-online).
{{% /alert %}}