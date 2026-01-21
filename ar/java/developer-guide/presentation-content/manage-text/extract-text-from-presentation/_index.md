---
title: استخراج النص المتقدم من العروض التقديمية في Java
linktitle: استخراج النص
type: docs
weight: 90
url: /ar/java/extract-text-from-presentation/
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
- Java
- Aspose.Slides
description: "استخراج النص بسرعة من عروض PowerPoint و OpenDocument باستخدام Aspose.Slides for Java. اتبع دليلنا البسيط خطوة بخطوة لتوفير الوقت."
---

{{% alert color="primary" %}} 

ليس من الغريب أن يحتاج المطورون إلى استخراج النص من عرض تقديمي. للقيام بذلك، تحتاج إلى استخراج النص من جميع الأشكال على جميع الشرائح في العرض التقديمي. يشرح هذا المقال كيفية استخراج النص من عروض Microsoft PowerPoint PPTX باستخدام Aspose.Slides. 

{{% /alert %}} 
## **استخراج النص من الشرائح**
توفر Aspose.Slides for Java فئة [SlideUtil](https://reference.aspose.com/slides/java/com.aspose.slides/SlideUtil). تكشف هذه الفئة عن عدد من الأساليب الساكنة المحملة لاستخراج النص بالكامل من عرض تقديمي أو شريحة. لاستخراج النص من شريحة في عرض PPTX، استخدم الطريقة الساكنة المحملة [getAllTextBoxes](https://reference.aspose.com/slides/java/com.aspose.slides/SlideUtil#getAllTextBoxes-com.aspose.slides.IBaseSlide-) التي تكشفها فئة [SlideUtil](https://reference.aspose.com/slides/java/com.aspose.slides/SlideUtil). تقبل هذه الطريقة كائن Slide كمعامل.
عند التنفيذ، تقوم طريقة Slide بمسح النص بالكامل من الشريحة التي تم تمريرها كمعامل وتعيد مصفوفة من كائنات [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrame). هذا يعني أن أي تنسيق نص مرتبط بالنص متاح. الجزء التالي من الشيفرة يستخرج كل النص في الشريحة الأولى من العرض التقديمي:
```java
//إنشاء كائن من فئة Presentation التي تمثل ملف PPTX
Presentation pres = new Presentation("demo.pptx");
try {
    for (ISlide slide : pres.getSlides()) 
    {
        //احصل على مصفوفة من كائنات ITextFrame من جميع الشرائح في ملف PPTX
        ITextFrame[] textFramesPPTX = SlideUtil.getAllTextBoxes(slide);

        //التكرار عبر مصفوفة TextFrames
        for (int i = 0; i < textFramesPPTX.length; i++) {
            //التكرار عبر الفقرات في كائن ITextFrame الحالي
            for (IParagraph para : textFramesPPTX[i].getParagraphs()) {
                //التكرار عبر المقاطع في كائن IParagraph الحالي
                for (IPortion port : para.getPortions()) {
                    //عرض النص في المقطع الحالي
                    System.out.println(port.getText());

                    //عرض ارتفاع خط النص
                    System.out.println(port.getPortionFormat().getFontHeight());

                    //عرض اسم خط النص
                    if (port.getPortionFormat().getLatinFont() != null)
                        System.out.println(port.getPortionFormat().getLatinFont().getFontName());
                }
            }
        }
    }
} finally {
    pres.dispose();
}
```


## **استخراج النص من العروض التقديمية**
للمسح النص من كامل العرض التقديمي، استخدم الطريقة الساكنة [getAllTextFrames](https://reference.aspose.com/slides/java/com.aspose.slides/SlideUtil#getAllTextFrames-com.aspose.slides.IPresentation-boolean-) التي تكشفها فئة SlideUtil. تأخذ هذه الطريقة معاملين:
1. أولاً، كائن [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/TextExtractionArrangingMode#Unarranged) الذي يمثل العرض التقديمي الذي يُستخرج منه النص.
2. ثانياً، قيمة من نوع boolean تحدد ما إذا كان يجب تضمين الشريحة الأصلية (master slide) عند مسح النص من العرض التقديمي.
تُعيد الطريقة مصفوفة من كائنات [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrame)، مع كامل معلومات تنسيق النص. الشيفرة أدناه تقوم بمسح النص ومعلومات التنسيق من عرض تقديمي، بما في ذلك الشرائح الأصلية.
```java
//إنشاء كائن من فئة Presentation التي تمثل ملف PPTX
Presentation pres = new Presentation("demo.pptx");
try {
    //احصل على مصفوفة من كائنات ITextFrame من جميع الشرائح في ملف PPTX
    ITextFrame[] textFramesPPTX = SlideUtil.getAllTextFrames(pres, true);

    //التكرار عبر مصفوفة TextFrames
    for (int i = 0; i < textFramesPPTX.length; i++) 
    {
        //التكرار عبر الفقرات في كائن ITextFrame الحالي
        for (IParagraph para : textFramesPPTX[i].getParagraphs())
        {
            //التكرار عبر المقاطع في كائن IParagraph الحالي
            for (IPortion port : para.getPortions())
            {
                //عرض النص في المقطع الحالي
                System.out.println(port.getText());

                //عرض ارتفاع الخط للنص
                System.out.println(port.getPortionFormat().getFontHeight());

                //عرض اسم الخط للنص
                if (port.getPortionFormat().getLatinFont() != null)
                    System.out.println(port.getPortionFormat().getLatinFont().getFontName());
            }
        }
    }
} finally {
    pres.dispose();
}
```


## **استخراج نص مصنف وسريع**
تمت إضافة الطريقة الساكنة الجديدة getPresentationText إلى فئة Presentation. هناك ثلاث تحميلات (overloads) لهذه الطريقة:
```java
public IPresentationText getPresentationText(String file, int mode);
public IPresentationText getPresentationText(InputStream stream, int mode);
public IPresentationText getPresentationText(InputStream stream, int mode, ILoadOptions options);
``` 

The [TextExtractionArrangingMode](https://reference.aspose.com/slides/java/com.aspose.slides/TextExtractionArrangingMode) enum argument indicates the mode to organize the output of text result and can be set to the following values:
- [Unarranged](https://reference.aspose.com/slides/java/com.aspose.slides/TextExtractionArrangingMode#Unarranged) - The raw text with no respect to position on the slide
- [Arranged](https://reference.aspose.com/slides/java/com.aspose.slides/TextExtractionArrangingMode#Arranged) - The text is positioned in the same order as on the slide

**Unarranged** mode can be used when speed is critical, it's faster than Arranged mode.

[IPresentationText](https://reference.aspose.com/slides/java/com.aspose.slides/IPresentationText) represents the raw text extracted from the presentation. It contains a [getSlidesText](https://reference.aspose.com/slides/java/com.aspose.slides/IPresentationText#getSlidesText--) method which returns an array of [ISlideText](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideText) objects. Every object represent the text on the corresponding slide. [ISlideText](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideText) object have the following methods:

- [ISlideText.getText](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideText#getText--) - The text on the slide's shapes
- [ISlideText.getMasterText](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideText#getMasterText--) - The text on the master page's shapes for this slide
- [ISlideText.getLayoutText](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideText#getLayoutText--) - The text on the layout page's shapes for this slide
- [ISlideText.getNotesText](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideText#getNotesText--) - The text on the notes page's shapes for this slide

The new API can be used like this:

```java
IPresentationText text1 = PresentationFactory.getInstance().getPresentationText("presentation.pptx", TextExtractionArrangingMode.Unarranged);
System.out.println(text1.getSlidesText()[0].getText());
System.out.println(text1.getSlidesText()[0].getLayoutText());
System.out.println(text1.getSlidesText()[0].getMasterText());
System.out.println(text1.getSlidesText()[0].getNotesText());
```


## **الأسئلة المتكررة**

**ما مدى سرعة معالجة Aspose.Slides للعروض الكبيرة أثناء استخراج النص؟**

تم تحسين Aspose.Slides لأداء عالي وتقوم بمعالجة حتى [العروض الكبيرة](/slides/ar/java/open-presentation/) بكفاءة، مما يجعلها مناسبة للسيناريوهات في الوقت الحقيقي أو المعالجة الضخمة.

**هل يمكن لـ Aspose.Slides استخراج النص من الجداول والرسوم البيانية داخل العروض التقديمية؟**

نعم، تدعم Aspose.Slides بالكامل استخراج النص من الجداول والرسوم البيانية وغيرها من عناصر الشريحة المعقدة، مما يتيح لك الوصول إلى جميع المحتويات النصية وتحليلها بسهولة.

**هل أحتاج إلى ترخيص خاص من Aspose.Slides لاستخراج النص من العروض التقديمية؟**

يمكنك استخراج النص باستخدام نسخة التجربة المجانية من Aspose.Slides، رغم أنها ستفرض بعض القيود مثل معالجة عدد محدود من الشرائح فقط. للحصول على استخدام غير مقيد وللتعامل مع العروض الأكبر، يُنصح بشراء ترخيص كامل.