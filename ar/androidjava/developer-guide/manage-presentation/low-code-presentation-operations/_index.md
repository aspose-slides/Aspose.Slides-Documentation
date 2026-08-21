---
title: عمليات عرض تقديمي منخفضة الشيفرة على Android
linktitle: API منخفضة الشيفرة
type: docs
weight: 50
url: /ar/androidjava/low-code-presentation-operations/
keywords:
- واجهة برمجة تطبيقات عرض تقديمي منخفضة الشيفرة
- تحويل العرض التقديمي
- دمج العروض التقديمية
- التنقل عبر الشرائح
- التنقل عبر الأشكال
- التنقل عبر النص
- جمع الأشكال
- ضغط العرض التقديمي
- إزالة ماسترات الشرائح غير المستخدمة
- إزالة تخطيطات الشرائح غير المستخدمة
- ضغط الخطوط المدمجة
- PowerPoint
- OpenDocument
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "استخدم API منخفضة الشيفرة لـ Aspose.Slides على Android لتحويل وعرض العروض التقديمية، دمجها، التنقل عبر المحتوى، جمع الأشكال، وتقليل حجم العرض التقديمي."
---
## **نظرة عامة**

تقدم الحزمة [com.aspose.slides](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/) فئات مساعد ثابتة لعمليات العرض التقديمي الشائعة. تقوم هذه المساعدات بلف تدفقات عمل نموذج الكائنات المتكررة في طرق مركزة، مما يتيح لك تحويل أو دمج الملفات، ومعالجة عناصر العرض، وجمع الأشكال، وإزالة المحتوى غير المستخدم بكتابة أقل.

تكون المساعدات منخفضة الشيفرة أكثر فائدة عندما ينطبق العملية على ملف أو عرض تقديمي كامل ويتطابق سير العمل الافتراضي مع متطلباتك. استخدم نموذج كائنات [Aspose.Slides الكامل](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/) عندما تحتاج إلى تحكم دقيق على الشرائح الفردية، والماسترز، والتخطيطات، والأشكال، وإعدادات التصدير، أو العلاقات بين عناصر العرض.

الجدول التالي يلخّص المساعدات المتوفرة:

| المساعد | الاستخدام |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/convert/) | تحويل عرض تقديمي إلى تنسيق آخر من خلال استدعاء مباشر من ملف إلى ملف. |
| [Merger](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/merger/) | دمج ملفات عرض تقديمي كاملة ذات نفس التنسيق. |
| [ForEach](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/foreach/) | تشغيل إجراء لكل شريحة أو شكل أو فقرة أو قطعة نصية. |
| [Collect](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/collect/) | استخراج الأشكال من العرض التقديمي بالكامل لمعالجة أو تحليل متكرر. |
| [Compress](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/compress/) | إزالة الماسترز والتخطيطات غير المستخدمة وتقليل بيانات الخطوط المدمجة. |

## **تحويل عرض تقديمي**

استخدم [Convert.autoByExtension](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/convert/#autoByExtension-java.lang.String-java.lang.String-) عندما تكون امتداد ملف الإخراج كافيًا لاختيار تنسيق التصدير. يقوم الأسلوب بفتح العرض التقديمي الأصلي، وتحديد التنسيق المطلوب من مسار الإخراج، وكتابة النتيجة.

```java
import com.aspose.slides.Convert;

Convert.autoByExtension("input.pptx", "output.pdf");
```

توفر الفئة [Convert](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/convert/) أيضًا طرقًا مخصصة للإخراج بتنسيقات PDF وSVG وJPEG وPNG وTIFF. استخدم نموذج الكائن الكامل عندما تحتاج إلى فحص أو تعديل العرض التقديمي قبل التصدير أو ضبط خيار تصدير غير متاح عبر المساعد المحدد. راجع [Convert Presentation](/androidjava/convert-presentation/) لتدفقات عمل وخيارات خاصة بالتنسيق.

## **دمج العروض التقديمية**

استخدم [Merger.process](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/merger/#process-java.lang.String:A-java.lang.String-) لدمج ملفات عرض تقديمي كاملة باستدعاء واحد. يجب أن تكون العروض التقديمية الداخلة بنفس تنسيق الملف.

```java
import com.aspose.slides.Merger;

String[] inputFiles = { "part-1.pptx", "part-2.pptx" };
Merger.process(inputFiles, "merged.pptx");
```

المساعد مناسب عندما يجب إلحاق جميع الشرائح بنتيجة واحدة دون اختيارها أو إعادة تعيينها بشكل فردي. استخدم نموذج الكائن الكامل عندما تحتاج إلى دمج شرائح مختارة، أو تطبيق ماستر أو تخطيط الوجهة، أو الحفاظ على الأقسام بصورة صريحة، أو توحيد أحجام الشرائح المختلفة. راجع [Merge Presentations](/androidjava/merge-presentation/) لهذه السيناريوهات.

## **التنقل عبر عناصر العرض التقديمي**

تستدعي الفئة [ForEach](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/foreach/) استدعاءً عكسيًا لكل نوع مطلوب من عناصر العرض التقديمي. إنها تتجنب حلقات التجميع المتداخلة وتُعدّ مريحة للفحص أو تغييرات التنسيق على مستوى العرض بأكمله.

المثال التالي يستخدم [ForEach.slide](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/foreach/#slide-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachSlideCallback-)، [ForEach.shape](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-)، [ForEach.paragraph](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/foreach/#paragraph-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachParagraphCallback-)، و[ForEach.portion](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/foreach/#portion-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachPortionCallback-) لتفحص العناصر المقابلة:

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

افتراضيًا، تشمل عملية التنقل عبر الأشكال والنص على مستوى العرض الشرائح العادية، والماسترات، والتخطيطات. يمكن للنسخ المتعددة التي تتضمن معامل `includeNotes` أيضًا معالجة شرائح الملاحظات. استخدم حلقات التجميع المباشرة عندما يكون ترتيب التنقل، أو الخروج المبكر، أو التصفية قبل استدعاء النداء العكسي، أو التحكم التفصيلي في العلاقات الأبوية-الابنية مهمًا.

## **جمع الأشكال**

استخدم [Collect.shapes](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/collect/#shapes-com.aspose.slides.Presentation-) عندما تحتاج إلى مجموعة من جميع الأشكال في عرض تقديمي بدلاً من استدعاء عكسي لكل شكل. هذا مفيد عندما سيتم تصفية أو عد أو معالجة نفس المجموعة أكثر من مرة.

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

يمكن للفئة [Compress](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/compress/) إزالة العناصر الهيكلية غير المستخدمة وتقليل بيانات الخطوط المدمجة:

- [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) يزيل شرائح التخطيط التي لا تشير إليها أي شريحة عادية.
- [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) يزيل ماسترات الشرائح التي لم تعد مستخدمة.
- [Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/compress/#compressEmbeddedFonts-com.aspose.slides.Presentation-) يزيل الأحرف غير المستخدمة من الخطوط المدمجة.

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

احذف التخطيطات غير المستخدمة قبل الماسترز غير المستخدمة حتى يمكن إزالة ماستر يصبح غير مُشار إليه بعد تنظيف التخطيطات. احفظ العرض التقديمي المُحسّن في ملف جديد إذا قد تحتاج إلى الماسترز أو التخطيطات الأصلية أو بيانات الخط المدمج الكاملة لاحقًا. لمزيد من التفاصيل، راجع [Slide Master](/androidjava/slide-master/) و[Embedded Font](/androidjava/embedded-font/).

## **الأسئلة المتكررة**

**متى يجب استخدام API منخفض الشيفرة بدلاً من نموذج الكائن الكامل؟**

استخدم المساعدات منخفضة الشيفرة عندما ينطبق إجراء قياسي على ملف أو عرض تقديمي كامل ولا يتطلب تحكمًا مفصلاً في العناصر الفردية. استخدم نموذج الكائن الكامل عندما تحتاج إلى اختيار شرائح محددة، أو التحكم في علاقات الماستر والتخطيط، أو فحص الحالة الوسيطة، أو ضبط سلوك لا يوفره المساعد.

**هل يمكن لـ Merger دمج عروض تقديمية بتنسيقات ملفات مختلفة؟**

لا. يتطلب [Merger.process](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/merger/#process-java.lang.String:A-java.lang.String-) أن تكون العروض التقديمية المدخلة بنفس التنسيق. قم بتحويل ملفات الإدخال إلى تنسيق مشترك أولاً، على سبيل المثال باستخدام [Convert.autoByExtension](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/convert/#autoByExtension-java.lang.String-java.lang.String-)، ثم دمج الملفات المحوّلة.

**هل يعالج ForEach ماسترات، وتخطيطات، وشرائح الملاحظات؟**

[ForEach.slide](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/foreach/#slide-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachSlideCallback-) يتنقل عبر شرائح العرض التقديمي العادية. تشمل عمليات [ForEach.shape](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-)، [ForEach.paragraph](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/foreach/#paragraph-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachParagraphCallback-)، و[ForEach.portion](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/foreach/#portion-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachPortionCallback-) على مستوى العرض الشرائح العادية، والماسترات، والتخطيطات بشكل افتراضي. استخدم النسخ المتعددة ذات المعامل `includeNotes` مضبوطة على `true` لتضمين شرائح الملاحظات.

**ما الفرق بين ForEach.shape و Collect.shapes؟**

استخدم [ForEach.shape](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-) لمعالجة كل شكل فورًا عبر استدعاء عكسي. استخدم [Collect.shapes](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/collect/#shapes-com.aspose.slides.Presentation-) عندما تحتاج إلى نتيجة قابلة للتكرار يمكن الاحتفاظ بها، وتصفيتها، وعدّها، أو التنقل فيها عدة مرات.

**هل يجعل Compress دائمًا ملف العرض التقديمي أصغر؟**

ليس بالضرورة. يعتمد النتيجة على ما إذا كان العرض التقديمي يحتوي على تخطيطات غير مستخدمة، ماسترات غير مستخدمة، أو خطوط مدمجة تحتوي على أحرف غير مستعملة. إذا لم يتوافر أي من هذه العناصر، فقد لا تقلل عمليات [Compress](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/compress/) حجم الملف.

**هل تُحفظ التغييرات التي تُجريها ForEach أو Compress تلقائيًا؟**

لا. تعمل هذه المساعدات على كائن [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/) المحمّل في الذاكرة. بعد تعديل العناصر في استدعاء عكسي لـ [ForEach](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/foreach/) أو تشغيل [Compress](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/compress/)، اتّصل بـ [Presentation.save](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) لكتابة النتيجة.

## **مقالات ذات صلة**

- [تحويل العرض التقديمي](/androidjava/convert-presentation/)
- [دمج العروض التقديمية](/androidjava/merge-presentation/)
- [ماستر الشريحة](/androidjava/slide-master/)
- [إدارة مربع النص](/androidjava/manage-textbox/)
- [الخط المدمج](/androidjava/embedded-font/)