---
title: عمليات العرض التقديمي منخفضة الشيفرة في JavaScript
linktitle: API منخفضة الشيفرة
type: docs
weight: 50
url: /ar/nodejs-java/low-code-presentation-operations/
keywords:
- API عرض تقديمي منخفض الشيفرة
- تحويل العرض التقديمي
- دمج العروض التقديمية
- التكرار عبر الشرائح
- التكرار عبر الأشكال
- التكرار عبر النص
- جمع الأشكال
- ضغط العرض التقديمي
- إزالة القوالب غير المستخدمة
- إزالة التخطيطات غير المستخدمة
- ضغط الخطوط المضمّنة
- PowerPoint
- OpenDocument
- عرض تقديمي
- Node.js
- JavaScript
- Aspose.Slides
description: "استخدم واجهة برمجة تطبيقات Aspose.Slides منخفضة الشيفرة في JavaScript لتحويل ودمج العروض التقديمية، والتكرار عبر المحتوى، وجمع الأشكال، وتقليل حجم العرض."
---
## **نظرة عامة**

توفر مساحة الاسم `aspose.slides` فئات مساعدة ثابتة للعمليات الشائعة على العروض التقديمية. تقوم هذه المساعدات بلف سير عمل نموذج الكائنات المتكرر في أساليب مركزة، بحيث يمكنك تحويل أو دمج الملفات، معالجة عناصر العرض، جمع الأشكال، وإزالة المحتوى غير المستخدم مع أقل قدر من الشيفرة.

تكون المساعدات منخفضة الشيفرة أكثر فائدة عندما تنطبق العملية على ملف أو عرض تقديمي كامل ويتطابق سير العمل الافتراضي مع متطلباتك. استخدم نموذج الكائن الكامل لـ [Aspose.Slides object model](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/) عندما تحتاج إلى تحكم دقيق في الشرائح الفردية، القوالب، التخطيطات، الأشكال، إعدادات التصدير، أو العلاقات بين عناصر العرض.

تلخص الجدول التالي المساعدات المتاحة:

| مساعد | استخدامه لـ |
| --- | --- |
| [تحويل](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/convert/) | تحويل عرض تقديمي إلى تنسيق آخر عبر استدعاء ملف إلى ملف مباشر. |
| [دمج](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/merger/) | دمج ملفات عروض تقديمية كاملة من نفس التنسيق. |
| [لكل](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/foreach/) | تشغيل إجراء لكل شريحة أو شكل أو فقرة أو جزء نصي. |
| [جمع](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/collect/) | استرجاع الأشكال من كامل العرض للتعامل المتكرر أو التحليل. |
| [ضغط](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/compress/) | إزالة القوالب والتخطيطات غير المستخدمة وتقليل بيانات الخطوط المضمّنة. |

## **تحويل عرض تقديمي**

استخدم [Convert.autoByExtension](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/convert/#autoByExtension) عندما تكون امتداد الملف الناتج كافياً لاختيار تنسيق التصدير. يفتح الأسلوب العرض المصدر، يحدّد التنسيق المطلوب من مسار الإخراج، ويكتب النتيجة.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

aspose.slides.Convert.autoByExtension("input.pptx", "output.pdf");
```

توفر فئة [تحويل](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/convert/) أيضاً أساليب مخصصة لإنتاج PDF و SVG و JPEG و PNG و TIFF. استخدم نموذج الكائن الكامل عندما تحتاج إلى فحص أو تعديل العرض قبل التصدير أو تكوين خيار تصدير غير متاح عبر المساعد المحدد. راجع [Convert Presentation](/slides/ar/nodejs-java/convert-presentation/) للحصول على سير عمل وخيارات خاصة بالتنسيق.

## **دمج عروض تقديمية**

استخدم [دمج.process](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/merger/#process) لدمج ملفات عروض تقديمية كاملة باستدعاء واحد. يجب أن تكون الصيغة المتوفرة للعرضين متماثلة.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const inputFiles = ["first.pptx", "second.pptx"];
aspose.slides.Merger.process(inputFiles, "merged.pptx");
```

المساعد مناسب عندما يجب إلحاق جميع الشرائح بنتيجة واحدة دون اختيارها أو إعادة تعيينها بشكل فردي. استخدم نموذج الكائن الكامل عندما تحتاج إلى دمج شرائح مختارة، تطبيق قالب أو تخطيط وجهة، الحفاظ على الأقسام صراحة، أو التوفيق بين أحجام الشرائح المختلفة. راجع [Merge Presentations](/slides/ar/nodejs-java/merge-presentation/) لتلك السيناريوهات.

## **التكرار عبر عناصر العرض التقديمي**

تستدعي فئة [لكل](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/foreach/) استدعاءً ردًا لكل نوع مطلوب من عناصر العرض. يخفف ذلك من حلقات التجميع المتداخلة ويكون مناسبًا للفحص أو تعديل التنسيقات على مستوى العرض بالكامل. في Node.js، أنشئ تطبيقات لواجهات الرد باستخدام `java.newProxy`.

يستخدم المثال التالي [لكل.slide](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/foreach/#slide)، [لكل.shape](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/foreach/#shape)، [لكل.paragraph](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/foreach/#paragraph)، و [لكل.portion](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/foreach/#portion) لتفقد العناصر المقابلة:

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

افتراضيًا، يتضمن استعراض الأشكال والنص على مستوى العرض الشرائح العادية، والقوالب، والتخطيطات. يمكن للتحميلات التي تتضمن معامل `includeNotes` أيضًا معالجة شرائح الملاحظات. استخدم حلقات التجميع المباشرة عندما تكون أولوية ترتيب الاستعراض، الخروج المبكر، الترشيح قبل استدعاء الرد، أو التحكم المفصل في العلاقات الأب‑ابن.

## **جمع الأشكال**

استخدم [جمع.shapes](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/collect/#shapes) عندما تحتاج إلى مجموعة من جميع الأشكال في عرض تقديمي بدلاً من رد لكل شكل. يكون ذلك مفيدًا عندما سيتم ترشيح المجموعة نفسها أو عدّها أو معالجتها أكثر من مرة.

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

استخدم [لكل.shape](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/foreach/#shape) بدلاً من ذلك عندما يمكن معالجة كل شكل فورًا ولا تحتاج إلى الاحتفاظ بالنتيجة المجمّعة.

## **ضغط محتوى العرض التقديمي**

يمكن لفئة [ضغط](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/compress/) إزالة العناصر الهيكلية غير المستخدمة وتقليل بيانات الخطوط المضمّنة:

- [ضغط.removeUnusedLayoutSlides](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/compress/#removeUnusedLayoutSlides) يزيل شرائح التخطيط التي لا تشير إليها أي شريحة عادية.
- [ضغط.removeUnusedMasterSlides](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/compress/#removeUnusedMasterSlides) يزيل القوالب التي لم تعد مستخدمة.
- [ضغط.compressEmbeddedFonts](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/compress/#compressEmbeddedFonts) يزيل الأحرف غير المستخدمة من الخطوط المضمّنة.

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

أزل التخطيطات غير المستخدمة قبل القوالب غير المستخدمة بحيث يمكن أيضًا حذف القالب غير المرتبط بعد تنظيف التخطيطات. احفظ العرض المُحسّن في ملف جديد إذا كنت قد تحتاج القوالب، التخطيطات، أو بيانات الخط المضمّنة بالكامل لاحقًا. للمزيد من التفاصيل، راجع [Slide Master](/slides/ar/nodejs-java/slide-master/) و [Embedded Font](/slides/ar/nodejs-java/embedded-font/).

## **الأسئلة المتكررة**

**متى يجب أن أستخدم واجهة برمجة التطبيقات منخفضة الشيفرة بدلاً من نموذج الكائن الكامل؟**

استخدم المساعدات منخفضة الشيفرة عندما ينطبق عملية قياسية على ملف أو عرض تقديمي كامل ولا تتطلب تحكمًا دقيقًا في العناصر الفردية. استخدم نموذج الكائن الكامل عندما تحتاج إلى اختيار شرائح محددة، التحكم في علاقات القالب والتخطيط، فحص الحالة الوسيطة، أو تكوين سلوك لا يُظهره المساعد.

**هل يمكن لـ دمج دمج عروض تقديمية بصيغ ملفات مختلفة؟**

لا. يتطلب [دمج.process](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/merger/#process) أن تكون العروض المدخلة بنفس الصيغة. حوّل الملفات المدخلة إلى صيغة مشتركة أولاً، على سبيل المثال باستخدام [Convert.autoByExtension](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/convert/#autoByExtension)، ثم دمج الملفات المحوّلة.

**هل يعالج لكل الشرائح القوالب، التخطيطات، وشرائح الملاحظات؟**

يتجول [لكل.slide](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/foreach/#slide) عبر الشرائح العادية للعرض. تشمل عمليات [لكل.shape](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/foreach/#shape)، [لكل.paragraph](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/foreach/#paragraph)، و [لكل.portion](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/foreach/#portion) الشرائح العادية، القوالب، والتخطيطات بشكل افتراضي. استخدم التحميلات التي لديها `includeNotes` مضبوطة على `true` لتضمين شرائح الملاحظات.

**ما الفرق بين لكل.shape و جمع.shapes؟**

استخدم [لكل.shape](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/foreach/#shape) لمعالجة كل شكل فورًا عبر رد. استخدم [جمع.shapes](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/collect/#shapes) عندما تحتاج إلى نتيجة قابلة للتكرار يمكن الاحتفاظ بها، ترشيحها، عدّها، أو استعراضها عدة مرات.

**هل يجعل الضغط دائمًا ملف العرض أصغر؟**

ليس بالضرورة. يعتمد النتيجة على ما إذا كان العرض يحتوي على تخطيطات غير مستخدمة، قوالب غير مستخدمة، أو خطوط مضمّنة بأحرف غير مستخدمة. إذا لم يكن أي من ذلك موجودًا، قد لا تقلل عمليات [ضغط](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/compress/) حجم الملف.

**هل تُحفظ التغييرات التي يجريها لكل أو ضغط تلقائيًا؟**

لا. تعمل هذه المساعدات على كائن [Presentation](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/) المحمّل في الذاكرة. بعد تعديل العناصر في رد [لكل](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/foreach/) أو تشغيل [ضغط](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/compress/)، استدعِ [Presentation.save](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/#save) لكتابة النتيجة.

## **مقالات ذات صلة**

- [تحويل عرض تقديمي](/slides/ar/nodejs-java/convert-presentation/)
- [دمج عروض تقديمية](/slides/ar/nodejs-java/merge-presentation/)
- [قالب الشريحة](/slides/ar/nodejs-java/slide-master/)
- [إدارة مربع النص](/slides/ar/nodejs-java/manage-textbox/)
- [خط مضمّن](/slides/ar/nodejs-java/embedded-font/)