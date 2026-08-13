---
title: تحويل عروض PowerPoint إلى TIFF مع ملاحظات على Android
linktitle: PowerPoint إلى TIFF مع ملاحظات
type: docs
weight: 100
url: /ar/androidjava/convert-powerpoint-to-tiff-with-notes/
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
- PowerPoint مع ملاحظات
- العرض مع ملاحظات
- الشريحة مع ملاحظات
- PPT مع ملاحظات
- PPTX مع ملاحظات
- TIFF مع ملاحظات
- Android
- Java
- Aspose.Slides
description: "تحويل عروض PowerPoint إلى TIFF مع ملاحظات باستخدام Aspose.Slides للأندرويد عبر Java. تعلم كيفية تصدير الشرائح مع ملاحظات المتحدث بكفاءة."
---
## **المقدمة**

Aspose.Slides for Android via Java يوفر حلًا بسيطًا لتحويل عروض PowerPoint وOpenDocument (PPT وPPTX وODP) مع الملاحظات إلى تنسيق TIFF. يُستخدم هذا التنسيق على نطاق واسع لتخزين الصور عالية الجودة، والطباعة، وأرشفة المستندات. مع Aspose.Slides، يمكنك ليس فقط تصدير العروض بالكامل مع ملاحظات المتحدث ولكن أيضًا إنشاء صور مصغرة للشرائح في عرض ملاحظات الشريحة. عملية التحويل بسيطة وفعّالة، حيث يتم استخدام طريقة `save` من فئة [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/) لتحويل العرض بالكامل إلى سلسلة من صور TIFF مع الحفاظ على الملاحظات والتخطيط.

## **تحويل عرض تقديمي إلى TIFF مع الملاحظات**

حفظ عرض PowerPoint أو OpenDocument إلى TIFF مع الملاحظات باستخدام Aspose.Slides for Android via Java يتضمن الخطوات التالية:

1. إنشاء كائن فئة [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/): تحميل ملف PowerPoint أو OpenDocument.  
1. ضبط خيارات تخطيط الإخراج: استخدم فئة [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/notescommentslayoutingoptions/) لتحديد كيفية عرض الملاحظات والتعليقات.  
1. حفظ العرض بتنسيق TIFF: مرّر الخيارات المضبوطة إلى طريقة [save](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) .

لنفترض أن لدينا ملف "speaker_notes.pptx" يحتوي على الشريحة التالية:

![الشريحة مع ملاحظات المتحدث](slide_with_notes.png)

المقتطف البرمجي أدناه يوضح طريقة تحويل العرض إلى صورة TIFF في عرض ملاحظات الشريحة باستخدام طريقة [setSlidesLayoutOptions](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/tiffoptions/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) .

```java
import com.aspose.slides.*;

// إنشاء كائن فئة Presentation الذي يمثل ملف عرض تقديمي.
Presentation presentation = new Presentation("speaker_notes.pptx");
try {
    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomFull); // عرض الملاحظات أسفل الشريحة.

    // تهيئة خيارات TIFF مع تخطيط الملاحظات.
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

![صورة TIFF مع ملاحظات المتحدث](TIFF_with_notes.png)

{{% alert title="Tip" color="info" %}}
تحقق من أداة Aspose [Free PowerPoint to Poster Converter](https://products.aspose.app/slides/ar/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **الأسئلة المتكررة**

### هل يمكنني التحكم في موضع منطقة الملاحظات في ملف TIFF الناتج؟

نعم. استخدم [إعدادات تخطيط الملاحظات](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/tiffoptions/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) لاختيار أحد الخيارات مثل `None` أو `BottomTruncated` أو `BottomFull`، والتي على التوالي تخفي الملاحظات أو تُلائمها في صفحة واحدة أو تسمح لها بالانتقال إلى صفحات إضافية.

### كيف يمكنني تقليل حجم ملف TIFF مع الملاحظات دون فقدان ملحوظ في الجودة؟

اختر ضغطًا فعالًا عبر [efficient compression](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/tiffoptions/#setCompressionType-int-) (مثل `LZW` أو `RLE`)، واضبط DPI مناسب، وإذا كان مقبولًا، استخدم تنسيق بكسل أقل مثل 8 بت أو 1 بت للصور أحادية اللون. يمكن أيضًا تقليل أبعاد الصورة قليلًا عبر [image dimensions](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/tiffoptions/#setImageSize-java.awt.Dimension-) دون الإضرار الواضح بقراءة المحتوى.

### هل يؤثر الخط في الملاحظات على النتيجة إذا كانت الخطوط الأصلية غير موجودة على النظام؟

نعم. الخطوط المفقودة تُفعل [substitution](/slides/ar/androidjava/font-selection-sequence/)، مما قد يغيّر مقاييس النص ومظهره. لتجنب ذلك، [قم بتوفير الخطوط المطلوبة](/slides/ar/androidjava/custom-font/) أو اضبط خطًا احتياطيًا افتراضيًا عبر [fallback font](/slides/ar/androidjava/fallback-font/) لتستخدم الخطوط المقصودة.