---
title: استخراج النص المتقدم من العروض التقديمية في جافا سكريبت
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
- جافا سكريبت
- Aspose.Slides
description: "استخراج النص بسرعة من عروض PowerPoint و OpenDocument باستخدام Aspose.Slides لـ Node.js. اتبع دليلنا البسيط خطوة بخطوة لتوفير الوقت."
---

{{% alert color="primary" %}} 

ليس من غير المعتاد أن يحتاج المطورون إلى استخراج النص من عرض تقديمي. للقيام بذلك، تحتاج إلى استخراج النص من جميع الأشكال على جميع الشرائح في العرض التقديمي. تشرح هذه المقالة كيفية استخراج النص من عروض Microsoft PowerPoint PPTX باستخدام Aspose.Slides. 

{{% /alert %}} 

## **استخراج النص من الشريحة**

توفر Aspose.Slides for Node.js عبر Java الفئة [SlideUtil](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideUtil) . تعرض هذه الفئة عددًا من الأساليب الساكنة المتجاوزة لاستخراج النص الكامل من عرض تقديمي أو شريحة. لاستخراج النص من شريحة في عرض PPTX، استخدم الأسلوب الساكن المتجاوز [getAllTextBoxes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideUtil#getAllTextBoxes-aspose.slides.IBaseSlide-) المقدم من الفئة [SlideUtil](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideUtil) . يتلقى هذا الأسلوب كائن Slide كمعامل.
عند التنفيذ، يقوم أسلوب Slide بمسح النص الكامل من الشريحة الممرَّرة كمعامل ويعيد مصفوفة من كائنات [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame) . هذا يعني أن أي تنسيق نصي مرتبط بالنص متاح. القطعة البرمجية التالية تستخرج كل النص في الشريحة الأولى من العرض التقديمي:
```javascript
// إنشاء كائن من الفئة Presentation التي تمثل ملف PPTX
var pres = new aspose.slides.Presentation("demo.pptx");
try {
    for (var s = 0; s < pres.getSlides().size(); s++) {
        let slide = pres.getSlides().get_Item(s);
        // احصل على مصفوفة من كائنات ITextFrame من جميع الشرائح في PPTX
        var textFramesPPTX = aspose.slides.SlideUtil.getAllTextBoxes(slide);
        // التكرار عبر مصفوفة TextFrames
        for (var i = 0; i < textFramesPPTX.length; i++) {
            // التكرار عبر الفقرات في ITextFrame الحالي
            for (let j = 0; j < textFramesPPTX[i].getParagraphs().getCount(); j++) {
                let para = textFramesPPTX[i].getParagraphs().get_Item(j);
                // التكرار عبر الأجزاء في IParagraph الحالي
                for (let k = 0; k < para.getPortions().getCount(); k++) {
                    let port = para.getPortions().get_Item(k);
                    // عرض النص في الجزء الحالي
                    console.log(port.getText());
                    // عرض ارتفاع الخط للنص
                    console.log(port.getPortionFormat().getFontHeight());
                    // عرض اسم الخط للنص
                    if (port.getPortionFormat().getLatinFont() != null) {
                        console.log(port.getPortionFormat().getLatinFont().getFontName());
                    }
                });
            }
        }
    });
} finally {
    pres.dispose();
}
```


## **استخراج النص من العرض التقديمي**

لمسح النص من كامل العرض التقديمي، استخدم الأسلوب الساكن [getAllTextFrames](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideUtil#getAllTextFrames-aspose.slides.IPresentation-boolean-) المقدم من الفئة SlideUtil. يأخذ هذا الأسلوب معاملين:

1. أولًا، كائن [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextExtractionArrangingMode#Unarranged) يمثل العرض التقديمي الذي يتم استخراج النص منه.
1. ثانيًا، قيمة منطقية تحدد ما إذا كان يجب تضمين الشريحة الرئيسة عند مسح النص من العرض التقديمي.
   يعيد الأسلوب مصفوفة من كائنات [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame) ، مع معلومات تنسيق النص. الشيفرة أدناه تمسح النص ومعلومات التنسيق من عرض تقديمي، بما في ذلك الشرائح الرئيسة.
```javascript
// إنشاء كائن من الفئة Presentation التي تمثل ملف PPTX
var pres = new aspose.slides.Presentation("demo.pptx");
try {
    // الحصول على مصفوفة من كائنات ITextFrame من جميع الشرائح في PPTX
    var textFramesPPTX = aspose.slides.SlideUtil.getAllTextFrames(pres, true);
    // التكرار عبر مصفوفة TextFrames
    for (var i = 0; i < textFramesPPTX.length; i++) {
        // التكرار عبر الفقرات في ITextFrame الحالي
        for (let j = 0; j < textFramesPPTX[i].getParagraphs().getCount(); j++) {
            let para = textFramesPPTX[i].getParagraphs().get_Item(j);
            // التكرار عبر الأجزاء في IParagraph الحالي
            for (let k = 0; k < para.getPortions().getCount(); k++) {
                let port = para.getPortions().get_Item(k);
                // عرض النص في الجزء الحالي
                console.log(port.getText());
                // عرض ارتفاع الخط للنص
                console.log(port.getPortionFormat().getFontHeight());
                // عرض اسم الخط للنص
                if (port.getPortionFormat().getLatinFont() != null) {
                    console.log(port.getPortionFormat().getLatinFont().getFontName());
                }
            }
        }
    }
} finally {
    pres.dispose();
}
```


## **استخراج النص المصنف والسريع**

تم إضافة الأسلوب الساكن الجديد getPresentationText إلى الفئة Presentation. هناك ثلاثة تجاوزات لهذا الأسلوب:
```javascript
IPresentationText getPresentationText(String file, int mode);
IPresentationText getPresentationText(InputStream stream, int mode);
IPresentationText getPresentationText(InputStream stream, int mode, ILoadOptions options);
``` 

The [TextExtractionArrangingMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextExtractionArrangingMode) enum argument indicates the mode to organize the output of text result and can be set to the following values:
- [Unarranged](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextExtractionArrangingMode#Unarranged) - The raw text with no respect to position on the slide
- [Arranged](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextExtractionArrangingMode#Arranged) - The text is positioned in the same order as on the slide

**Unarranged** mode can be used when speed is critical, it's faster than Arranged mode.

[PresentationText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PresentationText) represents the raw text extracted from the presentation. It contains a [getSlidesText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PresentationText#getSlidesText--) method which returns an array of `SlideText` objects. Every object represent the text on the corresponding slide. `SlideText` object have the following methods:

- `SlideText.getText` - The text on the slide's shapes
- `SlideText.getMasterText` - The text on the master page's shapes for this slide
- `SlideText.getLayoutText` - The text on the layout page's shapes for this slide
- `SlideText.getNotesText` - The text on the notes page's shapes for this slide

There is also a `SlideText` class which implements the `SlideText` class.

The new API can be used like this:

```javascript
var text1 = aspose.slides.PresentationFactory.getInstance().getPresentationText("presentation.pptx", aspose.slides.TextExtractionArrangingMode.Unarranged);
console.log(text1.getSlidesText()[0].getText());
console.log(text1.getSlidesText()[0].getLayoutText());
console.log(text1.getSlidesText()[0].getMasterText());
console.log(text1.getSlidesText()[0].getNotesText());
```


## **الأسئلة الشائعة**

**ما مدى سرعة معالجة Aspose.Slides للعروض التقديمية الكبيرة أثناء استخراج النص؟**

تم تحسين Aspose.Slides لأداء عالٍ وتقوم بمعالجة العروض التقديمية الكبيرة بكفاءة، مما يجعلها مناسبة لسيناريوهات المعالجة في الوقت الحقيقي أو المعالجة الضخمة.

**هل يمكن لـ Aspose.Slides استخراج النص من الجداول والرسوم البيانية داخل العروض التقديمية؟**

نعم، يدعم Aspose.Slides بالكامل استخراج النص من الجداول والرسوم البيانية وغيرها من عناصر الشريحة المعقدة، مما يتيح لك الوصول إلى كل المحتوى النصي وتحليله بسهولة.

**هل أحتاج إلى ترخيص خاص من Aspose.Slides لاستخراج النص من العروض التقديمية؟**

يمكنك استخراج النص باستخدام النسخة التجريبية المجانية من Aspose.Slides، على الرغم من أنها ستفرض بعض القيود، مثل معالجة عدد محدود من الشرائح فقط. للاستخدام غير المقيد وللتعامل مع عروض تقديمية أكبر، يُنصح بشراء ترخيص كامل.