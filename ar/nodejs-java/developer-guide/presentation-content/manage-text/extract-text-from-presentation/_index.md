---
title: استخراج النص من العرض التقديمي
type: docs
weight: 90
url: /ar/nodejs-java/extract-text-from-presentation/
---

{{% alert color="primary" %}} 

ليس من غير المألوف أن يحتاج المطورون إلى استخراج النص من عرض تقديمي. للقيام بذلك، تحتاج إلى استخراج النص من جميع الأشكال في جميع الشرائح في العرض التقديمي. يشرح هذا المقال كيفية استخراج النص من عروض PowerPoint PPTX باستخدام Aspose.Slides. 

{{% /alert %}} 

## **استخراج نص من الشريحة**

Aspose.Slides for Node.js via Java يوفّر الفئة [SlideUtil](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideUtil). تعرض هذه الفئة عددًا من الطرق الساكنة المتعددة الأحمال لاستخراج النص الكامل من عرض تقديمي أو شريحة. لاستخراج النص من شريحة في عرض PPTX،
استخدم الطريقة الساكنة المتعددة الأحمال [getAllTextBoxes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideUtil#getAllTextBoxes-aspose.slides.IBaseSlide-) التي تعرضها الفئة [SlideUtil](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideUtil). تقبل هذه الطريقة كائن Slide كمعامل.
عند التنفيذ، تقوم طريقة Slide بمسح النص بالكامل من الشريحة الممرَّرة كمعامل وتعيد مصفوفة من كائنات [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame). هذا يعني أن أي تنسيق نص مرتبط بالنص متاح. يُظهر المقطع التالي الكود الذي يستخرج كل النص في الشريحة الأولى من العرض:
```javascript
// إنشاء كائن من فئة Presentation التي تمثّل ملف PPTX
var pres = new aspose.slides.Presentation("demo.pptx");
try {
    for (var s = 0; s < pres.getSlides().size(); s++) {
        let slide = pres.getSlides().get_Item(s);
        // الحصول على مصفوفة من كائنات ITextFrame من جميع الشرائح في ملف PPTX
        var textFramesPPTX = aspose.slides.SlideUtil.getAllTextBoxes(slide);
        // التكرار عبر مصفوفة TextFrames
        for (var i = 0; i < textFramesPPTX.length; i++) {
            // التكرار عبر الفقرات في ITextFrame الحالي
            for (let j = 0; j < textFramesPPTX[i].getParagraphs().getCount(); j++) {
                let para = textFramesPPTX[i].getParagraphs().get_Item(j);
                // التكرار عبر المقاطع في IParagraph الحالي
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


## **استخراج نص من العرض التقديمي**

لمسح النص من كامل العرض التقديمي، استخدم الطريقة الساكنة [getAllTextFrames](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideUtil#getAllTextFrames-aspose.slides.IPresentation-boolean-) التي تعرضها الفئة SlideUtil. تأخذ هذه الطريقة معاملين:

1. أولاً، كائن [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextExtractionArrangingMode#Unarranged) يمثل العرض التقديمي الذي يتم استخراج النص منه.
2. ثانياً، قيمة منطقية تحدد ما إذا كان يجب تضمين الشريحة الرئيسية عند مسح النص من العرض التقديمي.
   تُعيد الطريقة مصفوفة من كائنات [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame) مع معلومات تنسيق النص. الكود أدناه يمسح النص ومعلومات التنسيق من عرض تقديمي، بما في ذلك الشرائح الرئيسية.
```javascript
// إنشاء كائن من فئة Presentation التي تمثل ملف PPTX
var pres = new aspose.slides.Presentation("demo.pptx");
try {
    // الحصول على مصفوفة من كائنات ITextFrame من جميع الشرائح في ملف PPTX
    var textFramesPPTX = aspose.slides.SlideUtil.getAllTextFrames(pres, true);
    // التكرار عبر مصفوفة TextFrames
    for (var i = 0; i < textFramesPPTX.length; i++) {
        // التكرار عبر الفقرات في ITextFrame الحالي
        for (let j = 0; j < textFramesPPTX[i].getParagraphs().getCount(); j++) {
            let para = textFramesPPTX[i].getParagraphs().get_Item(j);
            // التكرار عبر المقاطع في IParagraph الحالي
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


## **استخراج نص مصنف وسريع**

تم إضافة الطريقة الساكنة الجديدة getPresentationText إلى فئة Presentation. هناك ثلاثة أحمال لهذه الطريقة:
```javascript
IPresentationText getPresentationText(String file, int mode);
IPresentationText getPresentationText(InputStream stream, int mode);
IPresentationText getPresentationText(InputStream stream, int mode, ILoadOptions options);
``` 

The [TextExtractionArrangingMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextExtractionArrangingMode) enum argument indicates the mode to organize the output of text result and can be set to the following values:
- [Unarranged](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextExtractionArrangingMode#Unarranged) - The raw text with no respect to position on the slide
- [Arranged](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextExtractionArrangingMode#Arranged) - The text is positioned in the same order as on the slide

**Unarranged** mode can be used when speed is critical, it's faster than Arranged mode.

[PresentationText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PresentationText) represents the raw text extracted from the presentation. It contains a [getSlidesText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PresentationText#getSlidesText--) method which returns an array of [SlideText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideText) objects. Every object represent the text on the corresponding slide. [SlideText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideText) object have the following methods:

- [SlideText.getText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideText#getText--) - The text on the slide's shapes
- [SlideText.getMasterText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideText#getMasterText--) - The text on the master page's shapes for this slide
- [SlideText.getLayoutText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideText#getLayoutText--) - The text on the layout page's shapes for this slide
- [SlideText.getNotesText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideText#getNotesText--) - The text on the notes page's shapes for this slide

There is also a [SlideText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideText) class which implements the [SlideText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideText) class.

The new API can be used like this:

```javascript
var text1 = aspose.slides.PresentationFactory.getInstance().getPresentationText("presentation.pptx", aspose.slides.TextExtractionArrangingMode.Unarranged);
console.log(text1.getSlidesText()[0].getText());
console.log(text1.getSlidesText()[0].getLayoutText());
console.log(text1.getSlidesText()[0].getMasterText());
console.log(text1.getSlidesText()[0].getNotesText());
```


## **FAQ**

**ما مدى سرعة معالجة Aspose.Slides للعروض الكبيرة أثناء استخراج النص؟**

تم تحسين Aspose.Slides للأداء العالي ويعالج حتى العروض الكبيرة بكفاءة، مما يجعله مناسبًا للسيناريوهات الفورية أو المعالجة الضخمة.

**هل يمكن لـ Aspose.Slides استخراج النص من الجداول والرسوم البيانية داخل العروض التقديمية؟**

نعم، يدعم Aspose.Slides استخراج النص من الجداول والرسوم البيانية وغيرها من عناصر الشرائح المعقَّدة، مما يتيح لك الوصول إلى جميع المحتويات النصية وتحليلها بسهولة.

**هل أحتاج إلى ترخيص خاص من Aspose.Slides لاستخراج النص من العروض؟**

يمكنك استخراج النص باستخدام نسخة التجربة المجانية من Aspose.Slides، على الرغم من وجود قيود معينة، مثل معالجة عدد محدود من الشرائح. للحصول على استخدام غير مقيد وللتعامل مع عروض أكبر، يُنصح بشراء ترخيص كامل.