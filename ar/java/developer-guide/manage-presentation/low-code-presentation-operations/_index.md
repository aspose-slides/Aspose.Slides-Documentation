---
title: عمليات عرض تقديمي منخفضة الكود في جافا
linktitle: واجهة برمجة التطبيقات منخفضة الكود
type: docs
weight: 50
url: /ar/java/low-code-presentation-operations/
keywords:
- واجهة برمجة تطبيقات عرض تقديمي منخفضة الكود
- تحويل العرض التقديمي
- دمج العروض التقديمية
- التنقل عبر الشرائح
- التنقل عبر الأشكال
- التنقل عبر النص
- جمع الأشكال
- ضغط العرض التقديمي
- إزالة القوالب غير المستخدمة
- إزالة التخطيطات غير المستخدمة
- ضغط الخطوط المدمجة
- PowerPoint
- OpenDocument
- عرض تقديمي
- Java
- Aspose.Slides
description: "استخدم واجهة برمجة التطبيقات منخفضة الكود ل Aspose.Slides في جافا لتحويل ودمج العروض التقديمية، والتنقل عبر المحتوى، وجمع الأشكال، وتقليل حجم العرض التقديمي."
---
## **نظرة عامة**

توفر الحزمة [com.aspose.slides](https://reference.aspose.com/slides/ar/java/com.aspose.slides/) فئات مساعدة ثابتة للعمليات الشائعة على العروض التقديمية. تُغلف هذه المساعدات تدفقات عمل نموذج الكائنات المُستخدمة بشكل متكرر في طرق مركّزة، بحيث يمكنك تحويل أو دمج الملفات، ومعالجة عناصر العرض، وجمع الأشكال، وإزالة المحتوى غير المستخدم بكتابة أقل.

تكون المساعدات ذات الشفرة القليلة أكثر فائدة عندما ينطبق العملية على ملف أو عرض تقديمي كامل ويتطابق سير العمل الافتراضي مع متطلباتك. استخدم نموذج الكائنات الكامل [Aspose.Slides object model](https://reference.aspose.com/slides/ar/java/com.aspose.slides/) عندما تحتاج إلى تحكم دقيق في الشرائح الفردية، أو القوالب، أو التخطيطات، أو الأشكال، أو إعدادات التصدير، أو العلاقات بين عناصر العرض.

الجدول التالي يلخّص المساعدات المتاحة:

| المساعد | الاستخدام |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/ar/java/com.aspose.slides/convert/) | تحويل عرض تقديمي إلى تنسيق آخر باستخدام استدعاء مباشر من ملف إلى ملف. |
| [Merger](https://reference.aspose.com/slides/ar/java/com.aspose.slides/merger/) | دمج ملفات عروض تقديمية كاملة من نفس التنسيق. |
| [ForEach](https://reference.aspose.com/slides/ar/java/com.aspose.slides/foreach/) | تنفيذ إجراء لكل شريحة، أو شكل، أو فقرة، أو جزء نص. |
| [Collect](https://reference.aspose.com/slides/ar/java/com.aspose.slides/collect/) | استرجاع الأشكال من العرض الكامل للمعالجة المتكررة أو التحليل. |
| [Compress](https://reference.aspose.com/slides/ar/java/com.aspose.slides/compress/) | إزالة القوالب والتخطيطات غير المستخدمة وتقليل بيانات الخطوط المدمجة. |

## **تحويل عرض تقديمي**

استخدم [Convert.autoByExtension](https://reference.aspose.com/slides/ar/java/com.aspose.slides/convert/#autoByExtension-java.lang.String-java.lang.String-) عندما يكون امتداد الملف الناتج كافياً لتحديد تنسيق التصدير. يفتح الطريقة العرض المصدر، يحدد التنسيق المطلوب من مسار الإخراج، ويكتب النتيجة.

```java
import com.aspose.slides.Convert;

Convert.autoByExtension("input.pptx", "output.pdf");
```

توفر فئة [Convert](https://reference.aspose.com/slides/ar/java/com.aspose.slides/convert/) أيضًا طرقاً مخصصة لإخراج PDF و SVG و JPEG و PNG و TIFF. استخدم نموذج الكائنات الكامل عندما تحتاج إلى فحص أو تعديل العرض قبل التصدير أو تكوين خيار تصدير غير مُعرّف في المساعد المحدد. راجع [Convert Presentation](/java/convert-presentation/) لسير العمل والخيارات الخاصة بكل تنسيق.

## **دمج العروض التقديمية**

استخدم [Merger.process](https://reference.aspose.com/slides/ar/java/com.aspose.slides/merger/#process-java.lang.String:A-java.lang.String-) لدمج ملفات عروض تقديمية كاملة باستدعاء واحد. يجب أن تكون صيغ الملفات المدخلة متطابقة.

```java
import com.aspose.slides.Merger;

String[] inputFiles = { "part-1.pptx", "part-2.pptx" };
Merger.process(inputFiles, "merged.pptx");
```

المساعد مناسب عندما يجب إلحاق جميع الشرائح بنتيجة واحدة دون اختيار أو إعادة تعيين كل واحدة على حدة. استخدم نموذج الكائنات الكامل عندما تحتاج إلى دمج شرائح مختارة، أو تطبيق قالب أو تخطيط وجهة، أو الحفاظ على الأقسام بصورة صريحة، أو توحيد أحجام الشرائح المختلفة. راجع [Merge Presentations](/java/merge-presentation/) لتلك السيناريوهات.

## **التنقُّل عبر عناصر العرض التقديمي**

تستدعي فئة [ForEach](https://reference.aspose.com/slides/ar/java/com.aspose.slides/foreach/) دالة رد نداء لكل نوع مطلوب من عناصر العرض. إنها تتجنب حلقات التجميع المتداخلة وتُسهّل الفحص أو تعديل التنسيق على مستوى العرض بأكمله.

المثال التالي يستخدم [ForEach.slide](https://reference.aspose.com/slides/ar/java/com.aspose.slides/foreach/#slide-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachSlideCallback-)، [ForEach.shape](https://reference.aspose.com/slides/ar/java/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-)، [ForEach.paragraph](https://reference.aspose.com/slides/ar/java/com.aspose.slides/foreach/#paragraph-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachParagraphCallback-)، و[ForEach.portion](https://reference.aspose.com/slides/ar/java/com.aspose.slides/foreach/#portion-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachPortionCallback-) لتفحص العناصر المقابلة:

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

بشكل افتراضي، يشمل استعراض الأشكال والنص على مستوى العرض الشرائح العادية، والقوالب، والتخطيطات. يمكن للتحميلات ذات المعامل `includeNotes` أيضاً معالجة شرائح الملاحظات. استخدم حلقات التجميع المباشرة عندما يكون ترتيب الاستعراض، أو الخروج المبكر، أو الترشيح قبل استدعاء رد نداء، أو التحكم التفصيلي في الأبواب والأطفال مهماً.

## **جمع الأشكال**

استخدم [Collect.shapes](https://reference.aspose.com/slides/ar/java/com.aspose.slides/collect/#shapes-com.aspose.slides.Presentation-) عندما تحتاج إلى مجموعة من جميع الأشكال في عرض تقديمي بدلاً من رد نداء لكل شكل. هذا مفيد عندما سيتم تصفية المجموعة نفسها أو عدّها أو معالجتها أكثر من مرة.

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

استخدم [ForEach.shape](https://reference.aspose.com/slides/ar/java/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-) بدلاً من ذلك عندما يمكن التعامل مع كل شكل فوراً ولا تحتاج إلى الاحتفاظ بالنتيجة المجمعة.

## **ضغط محتوى العرض التقديمي**

يمكن لفئة [Compress](https://reference.aspose.com/slides/ar/java/com.aspose.slides/compress/) إزالة العناصر الهيكلية غير المستخدمة وتقليل بيانات الخطوط المدمجة:

- يُزيل [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/ar/java/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) تخطيطات الشرائح التي لا تُشير إليها أي شريحة عادية.
- يُزيل [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/ar/java/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) القوالب التي لم تعد مستخدمة.
- يُقلّص [Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/ar/java/com.aspose.slides/compress/#compressEmbeddedFonts-com.aspose.slides.Presentation-) الخطوط المدمجة بإزالة الأحرف غير المستخدمة.

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

قم بإزالة التخطيطات غير المستخدمة قبل القوالب غير المستخدمة حتى يتمكن القالب الذي يصبح غير مُشار إليه بعد تنظيف التخطيطات من الإزالة أيضًا. احفظ العرض المُحسّن إلى ملف جديد إذا قد تحتاج إلى القوالب أو التخطيطات الأصلية أو بيانات الخط المدمج الكاملة لاحقًا. للمزيد من التفاصيل، راجع [Slide Master](/java/slide-master/) و[Embedded Font](/java/embedded-font/).

## **الأسئلة الشائعة**

**متى يجب استخدام واجهة برمجة التطبيقات ذات الشفرة القليلة بدلاً من نموذج الكائنات الكامل؟**

استخدم المساعدات منخفضة الكود عندما تكون عملية قياسية تُطبّق على ملف أو عرض كامل ولا تتطلب تحكمًا مفصّلاً في العناصر الفردية. استخدم نموذج الكائنات الكامل عندما تحتاج إلى اختيار شرائح معينة، أو التحكم في علاقات القوالب والتخطيطات، أو فحص الحالة الوسيطة، أو تكوين سلوك لا يُظهره المساعد.

**هل يمكن للمساعد Merger دمج عروض تقديمية بتنسيقات ملفات مختلفة؟**

لا. يتطلب [Merger.process](https://reference.aspose.com/slides/ar/java/com.aspose.slides/merger/#process-java.lang.String:A-java.lang.String-) صيغ ملفات الإدخال متساوية. قم بتحويل الملفات المدخلة إلى تنسيق موحد أولاً، على سبيل المثال باستخدام [Convert.autoByExtension](https://reference.aspose.com/slides/ar/java/com.aspose.slides/convert/#autoByExtension-java.lang.String-java.lang.String-), ثم دمج الملفات المحوّلة.

**هل يعالج ForEach القوالب والتخطيطات وشرائح الملاحظات؟**

[ForEach.slide](https://reference.aspose.com/slides/ar/java/com.aspose.slides/foreach/#slide-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachSlideCallback-) يتنقّح الشرائح العادية فقط. تشمل عمليات [ForEach.shape](https://reference.aspose.com/slides/ar/java/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-)، [ForEach.paragraph](https://reference.aspose.com/slides/ar/java/com.aspose.slides/foreach/#paragraph-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachParagraphCallback-)، و[ForEach.portion](https://reference.aspose.com/slides/ar/java/com.aspose.slides/foreach/#portion-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachPortionCallback-) على مستوى العرض الشرائح العادية، والقوالب، والتخطيطات بشكل افتراضي. استخدم التحميلات ذات المعامل `includeNotes` مُعيَّن إلى `true` لتضمين شرائح الملاحظات.

**ما الفرق بين ForEach.shape و Collect.shapes؟**

استخدم [ForEach.shape](https://reference.aspose.com/slides/ar/java/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-) لمعالجة كل شكل فوراً عبر رد نداء. استخدم [Collect.shapes](https://reference.aspose.com/slides/ar/java/com.aspose.slides/collect/#shapes-com.aspose.slides.Presentation-) عندما تحتاج إلى نتيجة قابلة للتكرار يمكن الاحتفاظ بها، وتصفيةها، وعدّها، أو التمرّ عبرها عدة مرات.

**هل يؤدي Compress دائمًا إلى تقليل حجم ملف العرض؟**

ليس بالضرورة. تعتمد النتيجة على ما إذا كان العرض يحتوي على تخطيطات غير مستخدمة أو قوالب غير مستخدمة أو خطوط مدمجة بأحرف غير مستخدمة. إذا لم يتوفر أي منها، قد لا تُقلّص عمليات [Compress](https://reference.aspose.com/slides/ar/java/com.aspose.slides/compress/) حجم الملف.

**هل تُحفظ التغييرات التي يجريها ForEach أو Compress تلقائيًا؟**

لا. تعمل هذه المساعدات على كائن [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/) المحمّل في الذاكرة. بعد تعديل العناصر في رد نداء [ForEach](https://reference.aspose.com/slides/ar/java/com.aspose.slides/foreach/) أو تشغيل [Compress](https://reference.aspose.com/slides/ar/java/com.aspose.slides/compress/)، استدعِ [Presentation.save](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/#save-java.lang.String-int-) لكتابة النتيجة.

## **مقالات ذات صلة**

- [تحويل عرض تقديمي](/java/convert-presentation/)
- [دمج العروض التقديمية](/java/merge-presentation/)
- [قالب الشريحة](/java/slide-master/)
- [إدارة مربع النص](/java/manage-textbox/)
- [الخط المدمج](/java/embedded-font/)