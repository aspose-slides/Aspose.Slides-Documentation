---
title: عمليات العرض التقديمي منخفضة الشيفرة على Android
linktitle: API منخفضة الشيفرة
type: docs
weight: 50
url: /ar/androidjava/low-code-presentation-operations/
keywords:
- واجهة برمجة التطبيقات للعرض التقديمي منخفضة الشيفرة
- تحويل العرض التقديمي
- دمج العروض التقديمية
- التنقل عبر الشرائح
- التنقل عبر الأشكال
- التنقل عبر النص
- جمع الأشكال
- ضغط العرض التقديمي
- إزالة القوالب الرئيسية غير المستخدمة
- إزالة تخطيطات الشرائح غير المستخدمة
- ضغط الخطوط المضمّنة
- PowerPoint
- OpenDocument
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "استخدم API منخفضة الشيفرة لـ Aspose.Slides على Android لتحويل ودمج العروض التقديمية، والتنقل عبر المحتوى، وجمع الأشكال، وتقليل حجم العرض التقديمي."
---
## **نظرة عامة**

توفر حزمة [com.aspose.slides](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/) فئات مساعدة ثابتة للعمليات الشائعة على العروض التقديمية. تغلف هذه المساعدات سير عمل نموذج الكائنات المُستخدم بصورة متكررة في طرق مركّزة، بحيث يمكنك تحويل أو دمج الملفات، معالجة عناصر العرض، جمع الأشكال، وإزالة المحتوى غير المستخدم بكتابة أقل.

تكون المساعدات منخفضة الشيفرة الأكثر فائدة عندما يُطبق العملية على ملف أو عرض تقديمي كامل ويتطابق سير العمل الافتراضي مع متطلباتك. استخدم نموذج كائنات [Aspose.Slides الكامل](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/) عندما تحتاج إلى تحكم دقيق في الشرائح الفردية، القوالب الرئيسية، التخطيطات، الأشكال، إعدادات التصدير، أو العلاقات بين عناصر العرض.

الجدول التالي يلخّص المساعدات المتوفرة:

| المساعد | الاستخدام |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/convert/) | تحويل عرض تقديمي إلى تنسيق آخر باستخدام استدعاء مباشر من ملف إلى ملف. |
| [Merger](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/merger/) | دمج ملفات عروض تقديمية كاملة من نفس التنسيق. |
| [ForEach](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/foreach/) | تنفيذ إجراء لكل شريحة أو شكل أو فقرة أو جزء نصي. |
| [Collect](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/collect/) | استخراج الأشكال من العرض التقديمي بالكامل لإجراء معالجة أو تحليل متكرر. |
| [Compress](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/compress/) | إزالة القوالب الرئيسية والتخطيطات غير المستخدمة وتقليل بيانات الخطوط المضمّنة. |

## **تحويل عرض تقديمي**

استخدم [Convert.autoByExtension](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/convert/#autoByExtension-java.lang.String-java.lang.String-) عندما يكون امتداد ملف الإخراج كافياً لاختيار تنسيق التصدير. يفتح الأسلوب العرض التقديمي المصدر، يحدد التنسيق المطلوب من مسار الإخراج، ثم يكتب النتيجة.

```java
import com.aspose.slides.Convert;

Convert.autoByExtension("input.pptx", "output.pdf");
```

فئة [Convert](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/convert/) توفر أيضاً طرقاً مخصصة لإنتاج PDF وSVG وJPEG وPNG وTIFF. استخدم نموذج الكائن الكامل عندما تحتاج إلى فحص أو تعديل العرض قبل التصدير أو تكوين خيار تصدير غير متاح في المساعد المختار. راجع [Convert Presentation](/slides/ar/androidjava/convert-presentation/) للحصول على سير عمل وخيارات خاصة بكل تنسيق.

## **دمج العروض التقديمية**

استخدم [Merger.process](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/merger/#process-java.lang.String:A-java.lang.String-) لدمج ملفات عروض تقديمية كاملة باستدعاء واحد. يجب أن تكون العروض المدخلة بنفس تنسيق الملف.

```java
import com.aspose.slides.Merger;

String[] inputFiles = { "part-1.pptx", "part-2.pptx" };
Merger.process(inputFiles, "merged.pptx");
```

المساعد مناسب عندما يجب إلحاق جميع الشرائح بنتيجة واحدة دون اختيارها أو إعادة تعيينها فردياً. استخدم نموذج الكائن الكامل عندما تحتاج إلى دمج شرائح مختارة، تطبيق قالب أو تخطيط هدف، الحفاظ على الأقسام بوضوح، أو التوفيق بين أحجام الشرائح المختلفة. راجع [Merge Presentations](/slides/ar/androidjava/merge-presentation/) لهذه السيناريوهات.

## **التنقل عبر عناصر العرض التقديمي**

فئة [ForEach](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/foreach/) تستدعي رد نداء لكل نوع مطلوب من عناصر العرض. إنها تتجنب الحلقات المتداخلة للمجموعات وتُعد مريحة للفحص أو تغييرات التنسيق على مستوى العرض بالكامل.

المثال التالي يستخدم [ForEach.slide](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/foreach/#slide-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachSlideCallback-)، [ForEach.shape](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-)، [ForEach.paragraph](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/foreach/#paragraph-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachParagraphCallback-)، و[ForEach.portion](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/foreach/#portion-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachPortionCallback-) لتفتيش العناصر المقابلة:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    ForEach.slide(presentation, (slide, index) -> {
        System.out.println(String.format("Slide %d: %d shapes", index, slide.getShapes().size()));
    });

    ForEach.shape(presentation, (shape, slide, index) -> {
        System.out.println(String.format("Shape %d on %s: %s", index, slide.getClass().getSimpleName(), shape.getName()));
    });

    ForEach.paragraph(presentation, (paragraph, slide, index) -> {
        System.out.println(String.format("Paragraph %d on %s: %s", index, slide.getClass().getSimpleName(), paragraph.getText()));
    });

    ForEach.portion(presentation, (portion, paragraph, slide, index) -> {
        System.out.println(String.format("Portion %d on %s: %s", index, slide.getClass().getSimpleName(), portion.getText()));
    });
} finally {
    presentation.dispose();
}
```

افتراضيًا، يشمل التنقل عبر الأشكال والنص على مستوى العرض الشرائح العادية، والقوالب، والتخطيطات. يمكن للنسخ الزائدة التي تقبل معلمة `includeNotes` معالجة شرائح الملاحظات أيضًا. استخدم حلقات جمع مباشرة عندما يكون ترتيب التنقل، الخروج المبكر، التصفية قبل استدعاء رد النداء، أو التحكم التفصيلي بين الأب والابن أمرًا مهمًا.

## **جمع الأشكال**

استخدم [Collect.shapes](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/collect/#shapes-com.aspose.slides.Presentation-) عندما تحتاج إلى مجموعة تشمل جميع الأشكال في عرض تقديمي بدلاً من رد نداء لكل شكل. يكون ذلك مفيدًا عندما سيتم تصفية نفس المجموعة أو عدها أو معالجتها أكثر من مرة.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    Iterable<Shape> shapes = Collect.shapes(presentation);

    for (Shape shape : shapes) {
        System.out.println(String.format("%s: %s", shape.getName(), shape.getClass().getSimpleName()));
    }
} finally {
    presentation.dispose();
}
```

استخدم [ForEach.shape](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-) بدلاً من ذلك عندما يمكن معالجة كل شكل فورًا ولا تحتاج إلى الاحتفاظ بالنتيجة المجمعة.

## **ضغط محتوى العرض التقديمي**

فئة [Compress](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/compress/) يمكنها إزالة العناصر الهيكلية غير المستخدمة وتقليل بيانات الخطوط المضمّنة:

- [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) يزيل شرائح التخطيط التي لا تشير إليها أي شريحة عادية.
- [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) يزيل القوالب الرئيسية التي لم تعد مستخدمة.
- [Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/compress/#compressEmbeddedFonts-com.aspose.slides.Presentation-) يزيل الأحرف غير المستخدمة من الخطوط المضمّنة.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    Compress.removeUnusedLayoutSlides(presentation);
    Compress.removeUnusedMasterSlides(presentation);
    Compress.compressEmbeddedFonts(presentation);

    presentation.save("compressed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

أزل التخطيطات غير المستخدمة قبل القوالب غير المستخدمة بحيث يمكن أيضًا حذف قالب يصبح غير مشار إليه بعد تنظيف التخطيطات. احفظ العرض المحسّن إلى ملف جديد إذا قد تحتاج لاحقًا إلى القوالب أو التخطيطات الأصلية أو بيانات الخط المضمّن الكاملة. لمزيد من التفاصيل، راجع [Slide Master](/slides/ar/androidjava/slide-master/) و[Embedded Font](/slides/ar/androidjava/embedded-font/).

## **الأسئلة المتكررة**

**متى ينبغي أن أستخدم واجهة برمجة التطبيقات منخفضة الشيفرة بدلاً من نموذج الكائن الكامل؟**

استخدم المساعدات منخفضة الشيفرة عندما تُطبق عملية قياسية على ملف أو عرض تقديمي كامل ولا تتطلب تحكمًا تفصيليًا في العناصر الفردية. استخدم نموذج الكائن الكامل عندما تحتاج إلى اختيار شرائح محددة، التحكم في علاقات القوالب والتخطيطات، فحص الحالة المتوسطة، أو تكوين سلوك لا يُظهره المساعد.

**هل يمكن لـ Merger دمج عروض تقديمية بتنسيقات ملفات مختلفة؟**

لا. يتطلب [Merger.process](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/merger/#process-java.lang.String:A-java.lang.String-) أن تكون العروض المدخلة بنفس التنسيق. حوّل الملفات المدخلة إلى تنسيق مشترك أولاً، على سبيل المثال باستخدام [Convert.autoByExtension](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/convert/#autoByExtension-java.lang.String-java.lang.String-)، ثم دمج الملفات المحوّلة.

**هل يعالج ForEach القوالب، التخطيطات، وشرائح الملاحظات؟**

[ForEach.slide](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/foreach/#slide-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachSlideCallback-) يتنقل عبر الشرائح العادية فقط. عمليات [ForEach.shape](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-)، [ForEach.paragraph](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/foreach/#paragraph-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachParagraphCallback-)، و[ForEach.portion](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/foreach/#portion-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachPortionCallback-) تشمل الشرائح العادية والقوالب والتخطيطات بشكل افتراضي. استخدم النسخ ذات المعلمة `includeNotes` مُعينة إلى `true` لتضمين شرائح الملاحظات.

**ما الفرق بين ForEach.shape و Collect.shapes؟**

استخدم [ForEach.shape](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-) لمعالجة كل شكل فورًا عبر رد نداء. استخدم [Collect.shapes](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/collect/#shapes-com.aspose.slides.Presentation-) عندما تحتاج إلى نتيجة قابلة للتكرار يمكن الاحتفاظ بها، تصفيتها، عدّها أو تنقّلها عدة مرات.

**هل يجعل Compress دائمًا ملف العرض أصغر؟**

ليس بالضرورة. النتيجة تعتمد على ما إذا كان العرض يحتوي على تخطيطات غير مستخدمة، قوالب رئيسية غير مستخدمة، أو خطوط مضمنة بأحرف غير مستعملة. إذا لم يتوفر أي من هذه العناصر، قد لا تقلل عمليات [Compress](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/compress/) حجم الملف.

**هل تُحفظ التغييرات التي يجريها ForEach أو Compress تلقائيًا؟**

لا. هذه المساعدات تعمل على كائن [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/) المحمّل في الذاكرة. بعد تعديل العناصر في رد نداء [ForEach](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/foreach/) أو تشغيل [Compress](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/compress/)، يجب استدعاء [Presentation.save](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) لكتابة النتيجة.

## **مقالات ذات صلة**

- [تحويل العرض التقديمي](/slides/ar/androidjava/convert-presentation/)
- [دمج العروض التقديمية](/slides/ar/androidjava/merge-presentation/)
- [قالب الشريحة](/slides/ar/androidjava/slide-master/)
- [إدارة مربع النص](/slides/ar/androidjava/manage-textbox/)
- [خط مضمّن](/slides/ar/androidjava/embedded-font/)