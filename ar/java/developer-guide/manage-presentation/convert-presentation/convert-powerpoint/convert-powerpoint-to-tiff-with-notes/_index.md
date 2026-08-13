---
title: تحويل عروض PowerPoint إلى TIFF مع الملاحظات في Java
linktitle: PowerPoint إلى TIFF مع الملاحظات
type: docs
weight: 100
url: /ar/java/convert-powerpoint-to-tiff-with-notes/
keywords:
- تحويل PowerPoint
- تحويل العرض
- تحويل الشريحة
- تحويل PPT
- تحويل PPTX
- PowerPoint إلى TIFF
- العرض إلى TIFF
- الشريحة إلى TIFF
- PPT إلى TIFF
- PPTX إلى TIFF
- حفظ PPT كـ TIFF
- حفظ PPTX كـ TIFF
- تصدير PPT إلى TIFF
- تصدير PPTX إلى TIFF
- PowerPoint مع الملاحظات
- العرض مع الملاحظات
- الشريحة مع الملاحظات
- PPT مع الملاحظات
- PPTX مع الملاحظات
- TIFF مع الملاحظات
- Java
- Aspose.Slides
description: "تحويل عروض PowerPoint إلى TIFF مع الملاحظات باستخدام Aspose.Slides for Java. تعلّم كيفية تصدير الشرائح مع ملاحظات المتحدث بكفاءة."
---
## **المقدمة**

Aspose.Slides for Java يوفر حلاً بسيطًا لتحويل عروض PowerPoint وOpenDocument (PPT، PPTX، وODP) مع الملاحظات إلى تنسيق TIFF. يُستخدم هذا التنسيق على نطاق واسع لتخزين الصور عالية الجودة والطباعة وأرشفة المستندات. باستخدام Aspose.Slides، يمكنك ليس فقط تصدير العرض الكامل مع ملاحظات المتحدث بل أيضًا إنشاء صور مصغرة للشرائح في عرض ملاحظات الشريحة. عملية التحويل بسيطة وفعّالة، وتستفيد من طريقة `save` في فئة [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/) لتحويل العرض بالكامل إلى سلسلة من صور TIFF مع الحفاظ على الملاحظات والتخطيط.

## **تحويل عرض إلى TIFF مع الملاحظات**

حفظ عرض PowerPoint أو OpenDocument إلى TIFF مع الملاحظات باستخدام Aspose.Slides for Java يتضمن الخطوات التالية:

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/): تحميل ملف PowerPoint أو OpenDocument.  
1. تكوين خيارات تخطيط الإخراج: استخدم فئة [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ar/java/com.aspose.slides/notescommentslayoutingoptions/) لتحديد كيفية عرض الملاحظات والتعليقات.  
1. حفظ العرض بصيغة TIFF: مرّر الخيارات المعدة إلى طريقة [save](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) .

لنفترض أن لدينا ملف "speaker_notes.pptx" يحتوي على الشريحة التالية:

![The presentation slide with speaker notes](slide_with_notes.png)

المقتطف البرمجي أدناه يوضح كيفية تحويل العرض إلى صورة TIFF في عرض ملاحظات الشريحة باستخدام طريقة [setSlidesLayoutOptions](https://reference.aspose.com/slides/ar/java/com.aspose.slides/tiffoptions/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) .

```java
import com.aspose.slides.*;

// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
Presentation presentation = new Presentation("speaker_notes.pptx");
try {
    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomFull); // عرض الملاحظات أسفل الشريحة.

    // تكوين خيارات TIFF مع تخطيط الملاحظات.
    TiffOptions tiffOptions = new TiffOptions();
    tiffOptions.setDpiX(300);
    tiffOptions.setDpiY(300);
    tiffOptions.setSlidesLayoutOptions(notesOptions);

    // حفظ العرض بتنسيق TIFF مع ملاحظات المتحدث.
    presentation.save("TIFF_with_notes.tiff", SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

النتيجة:

![The TIFF image with speaker notes](TIFF_with_notes.png)

{{% alert title="Tip" color="info" %}}
تحقق من أداة Aspose [Free PowerPoint to Poster Converter](https://products.aspose.app/slides/ar/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **التعليمات المتكررة**

### هل يمكنني التحكم في موضع منطقة الملاحظات في ملف TIFF الناتج؟

نعم. استخدم [إعدادات تخطيط الملاحظات](https://reference.aspose.com/slides/ar/java/com.aspose.slides/tiffoptions/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) لاختيار أحد الخيارات مثل `None` أو `BottomTruncated` أو `BottomFull`، والتي تخفي الملاحظات أو تُلائمها في صفحة واحدة أو تسمح لها بالانتقال إلى صفحات إضافية.

### كيف يمكنني تقليل حجم ملف TIFF مع الملاحظات دون فقدان ملحوظ في الجودة؟

اختر [ضغطًا فعالًا](https://reference.aspose.com/slides/ar/java/com.aspose.slides/tiffoptions/#setCompressionType-int-) (مثل `LZW` أو `RLE`)، حدّد DPI مناسب، وإذا كان مقبولًا، استخدم [تنسيق بكسل](https://reference.aspose.com/slides/ar/java/com.aspose.slides/tiffoptions/#setPixelFormat-int-) أقل (مثل 8 bpp أو 1 bpp للون أحادي). تقليل أبعاد الصورة قليلاً قد يساعد أيضًا دون أن يؤثر بشكل واضح على وضوح النص.

### هل يؤثر الخط في الملاحظات على النتيجة إذا كانت الخطوط الأصلية مفقودة من النظام؟

نعم. الخطوط المفقودة تُسبب [استبدال](/slides/ar/java/font-selection-sequence/)، مما قد يغيّر قياسات النص ومظهره. لتجنب ذلك، [قم بتوفير الخطوط المطلوبة](/slides/ar/java/custom-font/) أو عيّن [خطًا احتياطيًا افتراضيًا](/slides/ar/java/fallback-font/) حتى تُستخدم الخطوط المقصودة.