---
title: استخراج النص المتقدم من العروض التقديمية في JavaScript
linktitle: استخراج النص
type: docs
weight: 90
url: /ar/nodejs-java/extract-text-from-presentation/
keywords:
- استخراج النص
- استخراج النص من الشريحة
- استخراج النص من العرض التقديمي
- استخراج النص من PowerPoint
- استخراج النص من OpenDocument
- استخراج النص من PPT
- استخراج النص من PPTX
- استخراج النص من ODP
- استرجاع النص
- استرجاع النص من الشريحة
- استرجاع النص من العرض التقديمي
- استرجاع النص من PowerPoint
- استرجاع النص من OpenDocument
- استرجاع النص من PPT
- استرجاع النص من PPTX
- استرجاع النص من ODP
- PowerPoint
- OpenDocument
- عرض تقديمي
- Node.js
- JavaScript
- Aspose.Slides
description: "استخراج النص بسرعة من عروض PowerPoint وOpenDocument باستخدام Aspose.Slides for Node.js عبر Java. اتبع دليلنا البسيط خطوة بخطوة لتوفير الوقت."
---
## **نظرة عامة**

استخراج النص من العروض التقديمية هو مهمة شائعة لكنها أساسية للمطورين الذين يتعاملون مع محتوى الشرائح. سواء كنت تتعامل مع ملفات Microsoft PowerPoint بصيغة PPT أو PPTX، أو عروض OpenDocument (ODP)، فإن الوصول إلى البيانات النصية واسترجاعها يمكن أن يكون حاسمًا للتحليل أو الأتمتة أو الفهرسة أو أغراض ترحيل المحتوى.

توفر هذه المقالة دليلًا شاملًا حول كيفية استخراج النص بكفاءة من صيغ عروض تقديمية متعددة، بما في ذلك PPT وPPTX وODP، باستخدام Aspose.Slides for Node.js via Java. ستتعلم كيفية التجول بشكل منهجي عبر عناصر العرض التقديمي لاسترجاع محتوى النص الذي تحتاجه بدقة.

## **استخراج النص من شريحة**

Aspose.Slides for Node.js via Java يوفر الفئة [SlideUtil](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/slideutil/). هذه الفئة تعرض عدة طرق ثابتة محملة لاستخراج كل النص من عرض تقديمي أو شريحة. لاستخراج النص من شريحة في عرض تقديمي، استخدم طريقة [getAllTextBoxes](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/slideutil/#getAllTextBoxes-aspose.slides.IBaseSlide-) . تقبل هذه الطريقة كائن شريحة كمعامل. عندما تُنفذ، تقوم الطريقة بفحص كامل الشريحة للبحث عن النص وتعيد مصفوفة من كائنات [TextFrame](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/textframe/) مع الحفاظ على أي تنسيق للنص.

المقتطف البرمجي التالي يستخرج كل النص من الشريحة الأولى في العرض التقديمي:



## **استخراج النص من عرض تقديمي**

لفحص النص من كامل العرض التقديمي، استخدم الطريقة الثابتة [getAllTextFrames](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/slideutil/#getAllTextFrames-aspose.slides.IPresentation-boolean-) المعروضة في الفئة [SlideUtil](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/slideutil/). تقبل الطريقة معاملين:

1. أولاً، كائن [Presentation](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/) يمثل عرض PowerPoint أو OpenDocument سيُستخرج منه النص.
1. ثانياً، قيمة `boolean` تُحدِّد ما إذا كان يجب تضمين الشرائح الرئيسية عند فحص النص من العرض التقديمي.

تعود الطريقة بمصفوفة من كائنات [TextFrame](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/textframe/) تشمل معلومات تنسيق النص. الشيفرة أدناه تفحص النص وتفاصيل التنسيق من عرض تقديمي، بما في ذلك الشرائح الرئيسية.

```javascript
const presentation = new aspose.slides.Presentation("demo.pptx");
try {
    const includeMasterSlides = true;
    const textFrames = aspose.slides.SlideUtil.getAllTextFrames(presentation, includeMasterSlides);

    for (let textFrameIndex = 0; textFrameIndex < textFrames.length; textFrameIndex++) {
        const textFrame = textFrames[textFrameIndex];

        const paragraphs = textFrame.getParagraphs();
        const paragraphCount = paragraphs.getCount();
        for (let paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++) {
            const paragraph = paragraphs.get_Item(paragraphIndex);

            const portions = paragraph.getPortions();
            const portionCount = portions.getCount();
            for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
                const portion = portions.get_Item(portionIndex);

                const portionText = portion.getText();
                console.log(portionText);

                const portionFormat = portion.getPortionFormat();
                const fontHeight = portionFormat.getFontHeight();
                console.log(fontHeight);

                const latinFont = portionFormat.getLatinFont();
                if (latinFont !== null) {
                    const fontName = latinFont.getFontName();
                    console.log(fontName);
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **استخراج النص المصنف والسريع**

الفئة [PresentationFactory](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentationfactory/) توفر أيضاً طرقًا لاستخراج كل النص من العروض التقديمية:

```javascript
PresentationText getPresentationText(String file, int mode);
PresentationText getPresentationText(InputStream stream, int mode);
PresentationText getPresentationText(InputStream stream, int mode, LoadOptions options);
```

معامل تعداد [TextExtractionArrangingMode](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/textextractionarrangingmode/) يحدد نمط تنظيم نتيجة استخراج النص ويمكن تعيينه إلى القيم التالية:
- `Unarranged` - النص الخام دون مراعاة موقعه على الشريحة.
- `Arranged` - يتم ترتيب النص بنفس الترتيب الموجود على الشريحة.

يمكن استخدام وضع `Unarranged` عندما تكون السرعة حاسمة؛ فهو أسرع من وضع `Arranged`.

الفئة [PresentationText](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentationtext/) تمثل النص الخام المستخرج من العرض التقديمي. تُعيد الطريقة `getSlidesText` مصفوفة من الكائنات، كل منها يمثل النص على الشريحة المقابلة. لكل كائن نص شريحة الطرق التالية:

- طريقة `getText` تُعيد النص داخل أشكال الشريحة.
- طريقة `getMasterText` تُعيد النص داخل أشكال الشريحة الرئيسية المرتبطة بهذه الشريحة.
- طريقة `getLayoutText` تُعيد النص داخل أشكال شريحة التخطيط المرتبطة بهذه الشريحة.
- طريقة `getNotesText` تُعيد النص داخل أشكال شريحة الملاحظات المرتبطة بهذه الشريحة.
- طريقة `getCommentsText` تُعيد النص داخل التعليقات المرتبطة بهذه الشريحة.

```javascript
const presentationPath = "presentation.ppt";
const arrangingMode = aspose.slides.TextExtractionArrangingMode.Unarranged;
const presentationText = aspose.slides.PresentationFactory.getInstance().getPresentationText(presentationPath, arrangingMode);
const firstSlideText = presentationText.getSlidesText()[0];

console.log(firstSlideText.getText());
console.log(firstSlideText.getLayoutText());
console.log(firstSlideText.getMasterText());
console.log(firstSlideText.getNotesText());
console.log(firstSlideText.getCommentsText());
```

## **FAQ**

**ما هي سرعة معالجة Aspose.Slides للعروض الكبيرة أثناء استخراج النص؟**

Aspose.Slides مُحسَّن لأداء عالي ويمكنه معالجة حتى [العروض الكبيرة](/slides/ar/nodejs-java/open-presentation/)، مما يجعله مناسبًا لسيناريوهات المعالجة الفورية أو الضخمة.

**هل يمكن لـ Aspose.Slides استخراج النص من الجداول والرسوم البيانية داخل العروض؟**

نعم. يمكن لـ Aspose.Slides استخراج النص من العديد من عناصر الشريحة، بما في ذلك الجداول والكائنات المتعلقة بالرسوم البيانية، بحيث يمكنك الوصول إلى المحتوى النصي وتحليله في هياكل العرض الشائعة.

**هل أحتاج إلى ترخيص خاص من Aspose.Slides لاستخراج النص من العروض؟**

يمكنك استخراج النص باستخدام نسخة التجربة المجانية من Aspose.Slides، على الرغم من أنها ستحتوي على [قيود معينة](/slides/ar/nodejs-java/licensing/)، مثل معالجة عدد محدود من الشرائح فقط. للاستخدام غير المقيد ومعالجة عروض أكبر، يُنصح بشراء ترخيص كامل.