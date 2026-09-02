---
title: عمليات العروض التقديمية منخفضة الكود في Java
linktitle: واجهة برمجة التطبيقات منخفضة الكود
type: docs
weight: 50
url: /ar/java/low-code-presentation-operations/
keywords:
- واجهة برمجة تطبيقات العروض منخفضة الكود
- تحويل العرض التقديمي
- دمج العروض التقديمية
- تكرار الشرائح
- تكرار الأشكال
- تكرار النص
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
description: "استخدم واجهة برمجة تطبيقات Aspose.Slides منخفضة الكود في Java لتحويل ودمج العروض التقديمية، وتكرار المحتوى، وجمع الأشكال، وتقليل حجم العرض."
---
## **نظرة عامة**

توفر حزمة [com.aspose.slides](https://reference.aspose.com/slides/ar/java/com.aspose.slides/) فئات مساعدة ثابتة للعمليات الشائعة على العروض التقديمية. تغلف هذه المساعدات سير عمل نموذج الكائن المتكرر في طرق مركزة، بحيث يمكنك تحويل الملفات أو دمجها، معالجة عناصر العرض، جمع الأشكال، وإزالة المحتوى غير المستخدم مع كتابة أقل من الشيفرة.

تكون المساعدات منخفضة الكود أكثر فائدة عندما ينطبق العملية على ملف أو عرض تقديمي كامل وتطابق سير العمل الافتراضي متطلباتك. استخدم نموذج كائن [Aspose.Slides الكامل](https://reference.aspose.com/slides/ar/java/com.aspose.slides/) عندما تحتاج إلى تحكم دقيق في الشرائح الفردية أو القوالب أو التخطيطات أو الأشكال أو إعدادات التصدير أو العلاقات بين عناصر العرض.

الجدول التالي يلخص المساعدين المتاحين:

| المساعد | استخدامه لل |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/ar/java/com.aspose.slides/convert/) | تحويل عرض تقديمي إلى صيغة أخرى بواسطة استدعاء مباشر من ملف إلى ملف. |
| [Merger](https://reference.aspose.com/slides/ar/java/com.aspose.slides/merger/) | دمج ملفات عروض تقديمية كاملة بنفس الصيغة. |
| [ForEach](https://reference.aspose.com/slides/ar/java/com.aspose.slides/foreach/) | تنفيذ إجراء لكل شريحة أو شكل أو فقرة أو جزء نصي. |
| [Collect](https://reference.aspose.com/slides/ar/java/com.aspose.slides/collect/) | استخراج الأشكال من كامل العرض التقديمي للمعالجة أو التحليل المتكرر. |
| [Compress](https://reference.aspose.com/slides/ar/java/com.aspose.slides/compress/) | إزالة القوالب والتخطيطات غير المستخدمة وتقليل بيانات الخطوط المدمجة. |

## **تحويل عرض تقديمي**

استخدام [Convert.autoByExtension](https://reference.aspose.com/slides/ar/java/com.aspose.slides/convert/#autoByExtension-java.lang.String-java.lang.String-) عندما يكون امتداد الملف الناتج كافيًا لاختيار صيغة التصدير. يفتح الأسلوب العرض المصدر، يحدد الصيغة المطلوبة من مسار الإخراج، ثم يكتب النتيجة.

```java
import com.aspose.slides.Convert;

Convert.autoByExtension("input.pptx", "output.pdf");
```

تقدم فئة [Convert](https://reference.aspose.com/slides/ar/java/com.aspose.slides/convert/) أيضًا طرقًا مخصصة لإخراج PDF و SVG و JPEG و PNG و TIFF. استخدم نموذج الكائن الكامل عندما تحتاج إلى فحص أو تعديل العرض قبل التصدير أو تكوين خيار تصدير غير متاح في المساعد المختار. راجع [Convert Presentation](/slides/ar/java/convert-presentation/) للحصول على سير عمل وخيارات محددة حسب الصيغة.

## **دمج العروض التقديمية**

استخدام [Merger.process](https://reference.aspose.com/slides/ar/java/com.aspose.slides/merger/#process-java.lang.String:A-java.lang.String-) لدمج ملفات عروض تقديمية كاملة بند واحدة. يجب أن تكون صيغ ملفات العروض المدخلة متطابقة.

```java
import com.aspose.slides.Merger;

String[] inputFiles = { "part-1.pptx", "part-2.pptx" };
Merger.process(inputFiles, "merged.pptx");
```

المساعد مناسب عندما يجب إلحاق جميع الشرائح إلى نتيجة واحدة دون اختيارها أو إعادة تعيينها بشكل فردي. استخدم نموذج الكائن الكامل عندما تحتاج إلى دمج شرائح مختارة، تطبيق قالب أو تخطيط هدف، الحفاظ على الأقسام صراحة، أو توحيد أحجام الشرائح المختلفة. راجع [Merge Presentations](/slides/ar/java/merge-presentation/) لهذه السيناريوهات.

## **التنقل عبر عناصر العرض التقديمي**

تستدعي فئة [ForEach](https://reference.aspose.com/slides/ar/java/com.aspose.slides/foreach/) رد اتصال لكل نوع مطلوب من عناصر العرض. إنها تتجنب الحلقات المتداخلة للمجموعات وتكون ملائمة للفحص أو تغييرات التنسيق على مستوى العرض بأكمله.

يستخدم المثال التالي [ForEach.slide](https://reference.aspose.com/slides/ar/java/com.aspose.slides/foreach/#slide-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachSlideCallback-)، [ForEach.shape](https://reference.aspose.com/slides/ar/java/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-)، [ForEach.paragraph](https://reference.aspose.com/slides/ar/java/com.aspose.slides/foreach/#paragraph-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachParagraphCallback-)، و[ForEach.portion](https://reference.aspose.com/slides/ar/java/com.aspose.slides/foreach/#portion-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachPortionCallback-) لفحص العناصر المقابلة:

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

افتراضيًا، تشمل عملية استعراض الأشكال والنص على مستوى العرض الشرائح العادية، والقوالب، والتخطيطات. يمكن للأنماط التي تتضمن معامل `includeNotes` معالجة شرائح الملاحظات أيضًا. استخدم حلقات الجمع المباشرة عندما تكون أولوية ترتيب الاستعراض، الخروج المبكر، الترشيح قبل استدعاء رد الاتصال، أو التحكم التفصيلي بين الأب والابن.

## **جمع الأشكال**

استخدم [Collect.shapes](https://reference.aspose.com/slides/ar/java/com.aspose.slides/collect/#shapes-com.aspose.slides.Presentation-) عندما تحتاج إلى مجموعة من جميع الأشكال في العرض بدلاً من رد اتصال لكل شكل. يكون هذا مفيدًا عندما سيتم ترشيح المجموعة نفسها أو عدّها أو معالجتها أكثر من مرة.

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

استخدم [ForEach.shape](https://reference.aspose.com/slides/ar/java/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-) بدلاً من ذلك عندما يمكن التعامل مع كل شكل فورًا ولا تحتاج إلى الاحتفاظ بالنتيجة المجمعة.

## **ضغط محتوى العرض التقديمي**

يمكن لفئة [Compress](https://reference.aspose.com/slides/ar/java/com.aspose.slides/compress/) إزالة العناصر الهيكلية غير المستخدمة وتقليل بيانات الخطوط المدمجة:

- [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/ar/java/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) يزيل شرائح التخطيط التي لا تشير إليها أي شريحة عادية.
- [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/ar/java/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) يزيل القوالب التي لم تعد مستخدمة.
- [Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/ar/java/com.aspose.slides/compress/#compressEmbeddedFonts-com.aspose.slides.Presentation-) يزيل الأحرف غير المستخدمة من الخطوط المدمجة.

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

أزل التخطيطات غير المستخدمة قبل القوالب غير المستخدمة حتى يتمكن القالب الذي يصبح غير مُشار إليه بعد تنظيف التخطيطات من الإزالة أيضًا. احفظ العرض المُحسّن إلى ملف جديد إذا كنت قد تحتاج القوالب الأصلية أو التخطيطات أو بيانات الخط المدمج الكاملة لاحقًا. لمزيد من التفاصيل، راجع [Slide Master](/slides/ar/java/slide-master/) و[Embedded Font](/slides/ar/java/embedded-font/).

## **الأسئلة الشائعة**

**متى ينبغي لي استخدام واجهة برمجة التطبيقات منخفضة الكود بدلاً من نموذج الكائن الكامل؟**

استخدم المساعدات منخفضة الكود عندما تنطبق عملية قياسية على ملف أو عرض تقديمي كامل ولا تتطلب تحكمًا مفصلاً في العناصر الفردية. استخدم نموذج الكائن الكامل عندما تحتاج إلى اختيار شرائح محددة، التحكم في علاقات القالب والتخطيط، فحص الحالة الوسيطة، أو تكوين سلوك لا ي expose المساعد.

**هل يمكن لـ Merger دمج عروض تقديمية بصيغ ملفات مختلفة؟**

لا. يتطلب [Merger.process](https://reference.aspose.com/slides/ar/java/com.aspose.slides/merger/#process-java.lang.String:A-java.lang.String-) أن تكون عروض الإدخال بنفس الصيغة. حوّل ملفات الإدخال إلى صيغة موحدة أولًا، على سبيل المثال باستخدام [Convert.autoByExtension](https://reference.aspose.com/slides/ar/java/com.aspose.slides/convert/#autoByExtension-java.lang.String-java.lang.String-)، ثم دمج الملفات المحوَّلة.

**هل تقوم ForEach بمعالجة الشرائح الرئيسية، والتخطيطات، وشريحة الملاحظات؟**

تستعرض [ForEach.slide](https://reference.aspose.com/slides/ar/java/com.aspose.slides/foreach/#slide-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachSlideCallback-) الشرائح العادية في العرض. تشمل عمليات [ForEach.shape](https://reference.aspose.com/slides/ar/java/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-)، [ForEach.paragraph](https://reference.aspose.com/slides/ar/java/com.aspose.slides/foreach/#paragraph-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachParagraphCallback-)، و[ForEach.portion](https://reference.aspose.com/slides/ar/java/com.aspose.slides/foreach/#portion-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachPortionCallback-) القوالب والتخطيطات بشكل افتراضي. استخدم الإصدارات التي تحتوي على `includeNotes` مُعينة إلى `true` لتضمين شرائح الملاحظات.

**ما الفرق بين ForEach.shape و Collect.shapes؟**

استخدم [ForEach.shape](https://reference.aspose.com/slides/ar/java/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-) لمعالجة كل شكل فورًا عبر رد اتصال. استخدم [Collect.shapes](https://reference.aspose.com/slides/ar/java/com.aspose.slides/collect/#shapes-com.aspose.slides.Presentation-) عندما تحتاج إلى نتيجة قابلة للتكرار يمكن الاحتفاظ بها، ترشيحها، عدّها، أو استعراضها عدة مرات.

**هل يقلل Compress دائمًا من حجم ملف العرض التقديمي؟**

ليس بالضرورة. تعتمد النتيجة على ما إذا كان العرض يحتوي على تخطيطات أو قوالب غير مستخدمة أو خطوط مدمجة بها أحرف غير مستخدمة. إذا لم تتوافر أي من هذه العناصر، قد لا تقلل عمليات [Compress](https://reference.aspose.com/slides/ar/java/com.aspose.slides/compress/) حجم الملف.

**هل يتم حفظ التغييرات التي تُجرى بواسطة ForEach أو Compress تلقائيًا؟**

لا. تعمل هذه المساعدات على كائن [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/) المحمَّل في الذاكرة. بعد تعديل العناصر في رد اتصال [ForEach] أو تشغيل [Compress]، استدعِ [Presentation.save](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/#save-java.lang.String-int-) لكتابة النتيجة.

## **مقالات ذات صلة**

- [تحويل العرض التقديمي](/slides/ar/java/convert-presentation/)
- [دمج العروض التقديمية](/slides/ar/java/merge-presentation/)
- [قالب الشريحة](/slides/ar/java/slide-master/)
- [إدارة مربع النص](/slides/ar/java/manage-textbox/)
- [الخط المدمج](/slides/ar/java/embedded-font/)