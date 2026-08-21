---
title: "عمليات العرض التقديمي ذات الكود القليل في JavaScript"
linktitle: "API منخفض الكود"
type: docs
weight: 50
url: /ar/nodejs-java/low-code-presentation-operations/
keywords:
- API عرض تقديمي منخفض الكود
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
- Node.js
- JavaScript
- Aspose.Slides
description: "استخدم API منخفض الكود لـ Aspose.Slides في JavaScript لتحويل ودمج العروض التقديمية، والتنقل عبر المحتوى، وجمع الأشكال، وتقليل حجم العرض التقديمي."
---
## **نظرة عامة**

توفر مساحة الاسم `aspose.slides` فئات مساعد ثابتة لعمليات العرض التقديمي الشائعة. تغلف هذه المساعدات سير عمل نموذج الكائنات المستخدم كثيرًا في طرق مركزة، بحيث يمكنك تحويل أو دمج الملفات، معالجة عناصر العرض التقديمي، جمع الأشكال، وإزالة المحتوى غير المستخدم بكتابة أقل.

المساعدات ذات الكود القليل هي الأكثر فائدة عندما ينطبق العملية على ملف أو عرض تقديمي كامل ويتطابق سير العمل الافتراضي مع متطلباتك. استخدم نموذج الكائنات الكامل [Aspose.Slides object model](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/) عندما تحتاج إلى تحكم دقيق على الشرائح الفردية أو القوالب أو التخطيطات أو الأشكال أو إعدادات التصدير أو العلاقات بين عناصر العرض التقديمي.

الجدول التالي يلخّص المساعدات المتاحة:

| المساعد | الاستخدام |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/convert/) | تحويل عرض تقديمي إلى تنسيق آخر عبر استدعاء مباشر من ملف إلى ملف. |
| [Merger](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/merger/) | دمج ملفات العروض التقديمية الكاملة ذات التنسيق نفسه. |
| [ForEach](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/foreach/) | تنفيذ إجراء لكل شريحة أو شكل أو فقرة أو قطعة نصية. |
| [Collect](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/collect/) | استرجاع الأشكال من العرض التقديمي بأكمله للمعالجة المتكررة أو التحليل. |
| [Compress](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/compress/) | إزالة القوالب والتخطيطات غير المستخدمة وتقليل بيانات الخطوط المدمجة. |

## **تحويل عرض تقديمي**

استخدم [Convert.autoByExtension](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/convert/#autoByExtension) عندما تكون امتداد الملف الناتج كافياً لاختيار تنسيق التصدير. يفتح الأسلوب العرض التقديمي المصدر، يحدد التنسيق المطلوب من مسار الإخراج، ويكتب النتيجة.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

aspose.slides.Convert.autoByExtension("input.pptx", "output.pdf");
```

توفر فئة [Convert](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/convert/) أيضاً طرقًا مخصصة لإنشاء ملفات PDF و SVG و JPEG و PNG و TIFF. استخدم نموذج الكائنات الكامل عندما تحتاج إلى فحص أو تعديل العرض التقديمي قبل التصدير أو تكوين خيار تصدير غير متاح عبر المساعد المحدد. راجع [Convert Presentation](/nodejs-java/convert-presentation/) للحصول على سير عمل وخيارات خاصة بكل تنسيق.

## **دمج العروض التقديمية**

استخدم [Merger.process](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/merger/#process) لدمج ملفات عروض تقديمية كاملة بنقرة واحدة. يجب أن تكون العروض التقديمية المدخلة بتنسيق ملف واحد.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const inputFiles = ["first.pptx", "second.pptx"];
aspose.slides.Merger.process(inputFiles, "merged.pptx");
```

المساعد مناسب عندما يجب إلحاق جميع الشرائح بنتيجة واحدة دون اختيارها أو إعادة تعيينها بشكل فردي. استخدم نموذج الكائنات الكامل عندما تحتاج إلى دمج شرائح محددة، تطبيق قالب أو تخطيط وجهة، الحفاظ على الأقسام صراحة، أو توحيد أحجام الشرائح المختلفة. راجع [Merge Presentations](/nodejs-java/merge-presentation/) لهذه السيناريوهات.

## **التنقل عبر عناصر العرض التقديمي**

تستدعي فئة [ForEach](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/foreach/) رد نداء لكل نوع مطلوب من عناصر العرض التقديمي. إنها تتجنب الحلقات المتداخلة للمجموعات وتكون ملائمة للفحص أو تغييرات التنسيق على مستوى كامل للعرض. في Node.js، يمكنك إنشاء تنفيذ لواجهات رد النداء باستخدام `java.newProxy`.

المثال التالي يستخدم [ForEach.slide](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/foreach/#slide)، [ForEach.shape](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/foreach/#shape)، [ForEach.paragraph](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/foreach/#paragraph)، و[ForEach.portion](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/foreach/#portion) لفحص العناصر المقابلة:

```javascript
const java = require("java");
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slideCallback = java.newProxy("com.aspose.slides.ForEach$ForEachSlideCallback", {
        invoke: function (slide, index) {
            console.log(`Slide ${index}: ${slide.getShapes().size()} shapes`);
        }
    });
    aspose.slides.ForEach.slide(presentation, slideCallback);

    const shapeCallback = java.newProxy("com.aspose.slides.ForEach$ForEachShapeCallback", {
        invoke: function (shape, slide, index) {
            console.log(`Shape ${index} on ${slide.getClass().getSimpleName()}: ${shape.getName()}`);
        }
    });
    aspose.slides.ForEach.shape(presentation, shapeCallback);

    const paragraphCallback = java.newProxy("com.aspose.slides.ForEach$ForEachParagraphCallback", {
        invoke: function (paragraph, slide, index) {
            console.log(`Paragraph ${index} on ${slide.getClass().getSimpleName()}: ${paragraph.getText()}`);
        }
    });
    aspose.slides.ForEach.paragraph(presentation, paragraphCallback);

    const portionCallback = java.newProxy("com.aspose.slides.ForEach$ForEachPortionCallback", {
        invoke: function (portion, paragraph, slide, index) {
            console.log(`Portion ${index} on ${slide.getClass().getSimpleName()}: ${portion.getText()}`);
        }
    });
    aspose.slides.ForEach.portion(presentation, portionCallback);
} finally {
    presentation.dispose();
}
```

افتراضيًا، تشمل عملية اجتياز الأشكال والنص على مستوى العرض الشرائح العادية، والقوالب، والتخطيطات. يمكن للتحميل الزائد مع معامل `includeNotes` أيضًا معالجة شرائح الملاحظات. استخدم حلقات جمع مباشرة عندما تكون أولوية ترتيب الاجتياز، الخروج المبكر، التصفية قبل استدعاء رد النداء، أو التحكم المفصل بين الأصل والابن أمرًا مهمًا.

## **جمع الأشكال**

استخدم [Collect.shapes](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/collect/#shapes) عندما تحتاج إلى مجموعة تشمل جميع الأشكال في عرض تقديمي بدلاً من رد نداء لكل شكل. هذا مفيد عندما سيُطبق نفس المجموعة على تصفية أو عد أو معالجة متعددة.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const shapes = aspose.slides.Collect.shapes(presentation);
    const iterator = shapes.iterator();

    while (iterator.hasNext()) {
        const shape = iterator.next();
        console.log(`${shape.getName()}: ${shape.getClass().getSimpleName()}`);
    }
} finally {
    presentation.dispose();
}
```

استخدم [ForEach.shape](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/foreach/#shape) بدلاً من ذلك عندما يمكن معالجة كل شكل فورًا ولا تحتاج إلى الاحتفاظ بالنتيجة المجمعة.

## **ضغط محتوى العرض التقديمي**

يمكن لفئة [Compress](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/compress/) إزالة العناصر الهيكلية غير المستخدمة وتقليل بيانات الخطوط المدمجة:

- [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/compress/#removeUnusedLayoutSlides) يزيل تخطيطات الشرائح التي لا تُشير إليها أي شريحة عادية.
- [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/compress/#removeUnusedMasterSlides) يزيل القوالب التي لم يعد يتم استخدامها.
- [Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/compress/#compressEmbeddedFonts) يزيل الأحرف غير المستخدمة من الخطوط المدمجة.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    aspose.slides.Compress.removeUnusedLayoutSlides(presentation);
    aspose.slides.Compress.removeUnusedMasterSlides(presentation);
    aspose.slides.Compress.compressEmbeddedFonts(presentation);

    presentation.save("compressed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

قم بإزالة التخطيطات غير المستخدمة قبل القوالب غير المستخدمة بحيث يمكن أيضًا حذف القالب الذي يصبح غير مرجّع بعد تنظيف التخطيطات. احفظ العرض التقديمي المُحسّن في ملف جديد إذا كنت قد تحتاج إلى القوالب الأصلية، التخطيطات، أو بيانات الخط المدمج الكاملة لاحقًا. لمزيد من التفاصيل، راجع [Slide Master](/nodejs-java/slide-master/) و[Embedded Font](/nodejs-java/embedded-font/).

## **الأسئلة الشائعة**

**متى يجب علي استخدام API ذات الكود القليل بدلاً من نموذج الكائنات الكامل؟**

استخدم المساعدات ذات الكود القليل عندما تنطبق عملية معيارية على ملف أو عرض تقديمي كامل ولا تتطلب تحكمًا تفصيليًا في العناصر الفردية. استخدم نموذج الكائنات الكامل عندما تحتاج إلى اختيار شرائح محددة، التحكم في علاقات القالب والتخطيط، فحص الحالة المتوسطة، أو تكوين سلوك لا يقدمه المساعد.

**هل يمكن لـ Merger دمج عروض تقديمية بصيغ ملفات مختلفة؟**

لا. [Merger.process](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/merger/#process) يتطلب أن تكون العروض التقديمية المدخلة بنفس التنسيق. حوّل الملفات المدخلة إلى تنسيق مشترك أولًا، على سبيل المثال باستخدام [Convert.autoByExtension](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/convert/#autoByExtension)، ثم دمج الملفات المحوَّلة.

**هل يعالج ForEach الشرائح القوالب، التخطيطات، وملاحظات الشريحة؟**

[ForEach.slide](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/foreach/#slide) يتنقل عبر الشرائح العادية للعرض التقديمي. عمليات [ForEach.shape](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/foreach/#shape)، [ForEach.paragraph](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/foreach/#paragraph) و[ForEach.portion](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/foreach/#portion) تشمل الشرائح العادية، والقوالب، والتخطيطات بشكل افتراضي. استخدم التحميل الزائد مع `includeNotes` مضبوطًا على `true` لتضمين شرائح الملاحظات.

**ما الفرق بين ForEach.shape و Collect.shapes؟**

استخدم [ForEach.shape](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/foreach/#shape) لمعالجة كل شكل فورًا عبر رد نداء. استخدم [Collect.shapes](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/collect/#shapes) عندما تحتاج إلى نتيجة قابلة للتكرار يمكن الاحتفاظ بها، تصفيتها، عدها أو اجتيازها عدة مرات.

**هل يؤدي Compress دائمًا إلى تقليل حجم ملف العرض التقديمي؟**

ليس بالضرورة. النتيجة تعتمد على ما إذا كان العرض يحتوي على تخطيطات غير مستخدمة، قوالب غير مستخدمة، أو خطوط مدمجة بها أحرف غير مستخدمة. إذا لم يكن أي من هذه موجودًا، قد لا تقلل عمليات [Compress](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/compress/) حجم الملف.

**هل يتم حفظ التغييرات التي تُجريها ForEach أو Compress تلقائيًا؟**

لا. هذه المساعدات تعمل على كائن [Presentation](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/) المحمّل في الذاكرة. بعد تعديل العناصر في رد نداء [ForEach](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/foreach/) أو تشغيل [Compress](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/compress/)، استدعِ [Presentation.save](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/#save) لكتابة النتيجة.

## **مقالات ذات صلة**

- [Convert Presentation](/nodejs-java/convert-presentation/)
- [Merge Presentations](/nodejs-java/merge-presentation/)
- [Slide Master](/nodejs-java/slide-master/)
- [Manage Text Box](/nodejs-java/manage-textbox/)
- [Embedded Font](/nodejs-java/embedded-font/)