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
description: "قم باستخراج النص بسرعة من عروض PowerPoint وOpenDocument باستخدام Aspose.Slides للـ Java. اتبع دليلنا البسيط خطوة بخطوة لتوفير الوقت."
---

{{% alert color="primary" %}} 

ليس من غير المألوف أن يحتاج المطورون إلى استخراج النص من عرض تقديمي. للقيام بذلك، يجب استخراج النص من جميع الأشكال في جميع الشرائح في العرض التقديمي. يشرح هذا المقال كيفية استخراج النص من عروض Microsoft PowerPoint PPTX باستخدام Aspose.Slides. 

{{% /alert %}} 
## **استخراج النص من الشرائح**
توفر Aspose.Slides for Java الفئة [SlideUtil](https://reference.aspose.com/slides/java/com.aspose.slides/SlideUtil). تُظهر هذه الفئة عددًا من الطرق الساكنة المتجاوزة لاستخراج النص الكامل من عرض تقديمي أو شريحة. لاستخراج النص من شريحة في عرض PPTX، استخدم الطريقة الساكنة المتجاوزة [getAllTextBoxes](https://reference.aspose.com/slides/java/com.aspose.slides/SlideUtil#getAllTextBoxes-com.aspose.slides.IBaseSlide-) المقدمة من الفئة [SlideUtil](https://reference.aspose.com/slides/java/com.aspose.slides/SlideUtil). تقبل هذه الطريقة كائن Slide كمعامل.
عند التنفيذ، تقوم طريقة Slide بمسح النص الكامل من الشريحة التي تم تمريرها كمعامل وتعيد مصفوفة من كائنات [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrame). وهذا يعني أن أي تنسيق نصي مرتبط بالنص متاح. الجزء التالي من الشيفرة يستخرج كل النص في الشريحة الأولى من العرض التقديمي:
```java
//إنشاء كائن Presentation يمثل ملف PPTX
Presentation pres = new Presentation("demo.pptx");
try {
    for (ISlide slide : pres.getSlides()) 
    {
        //الحصول على مصفوفة من كائنات ITextFrame من جميع الشرائح في ملف PPTX
        ITextFrame[] textFramesPPTX = SlideUtil.getAllTextBoxes(slide);

        //التكرار عبر مصفوفة TextFrames
        for (int i = 0; i < textFramesPPTX.length; i++) {
            //التكرار عبر الفقرات في ITextFrame الحالي
            for (IParagraph para : textFramesPPTX[i].getParagraphs()) {
                //التكرار عبر الأجزاء في IParagraph الحالي
                for (IPortion port : para.getPortions()) {
                    //عرض النص في الجزء الحالي
                    System.out.println(port.getText());

                    //عرض ارتفاع الخط للنص
                    System.out.println(port.getPortionFormat().getFontHeight());

                    //عرض اسم الخط للنص
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
لمسح النص من العرض التقديمي كاملًا، استخدم الطريقة الساكنة [getAllTextFrames](https://reference.aspose.com/slides/java/com.aspose.slides/SlideUtil#getAllTextFrames-com.aspose.slides.IPresentation-boolean-) المقدمة من فئة SlideUtil. تأخذ هذه الطريقة معاملين:

1. أولاً، كائن [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/TextExtractionArrangingMode#Unarranged) يمثل العرض التقديمي الذي يتم استخراج النص منه.
2. ثانيًا، قيمة منطقية تحدد ما إذا كانت الشريحة الرئيسية ستُضمّن عند مسح النص من العرض التقديمي.
تُعيد الطريقة مصفوفة من كائنات [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrame)، كاملةً بمعلومات تنسيق النص. الشيفرة أدناه تمسح النص ومعلومات التنسيق من عرض تقديمي، بما في ذلك الشرائح الرئيسية.
```java
//إنشاء كائن Presentation يمثل ملف PPTX
Presentation pres = new Presentation("demo.pptx");
try {
    //الحصول على مصفوفة من كائنات ITextFrame من جميع الشرائح في ملف PPTX
    ITextFrame[] textFramesPPTX = SlideUtil.getAllTextFrames(pres, true);

    //التكرار عبر مصفوفة TextFrames
    for (int i = 0; i < textFramesPPTX.length; i++) 
    {
        //التكرار عبر الفقرات في ITextFrame الحالي
        for (IParagraph para : textFramesPPTX[i].getParagraphs())
        {
            //التكرار عبر الأجزاء في IParagraph الحالي
            for (IPortion port : para.getPortions())
            {
                //عرض النص في الجزء الحالي
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


## **استخراج النص المصنف والسريع**
تم إضافة الطريقة الساكنة الجديدة getPresentationText إلى فئة Presentation. هناك ثلاث طرق متجاوزة لهذه الطريقة:
```java
public IPresentationText getPresentationText(String file, int mode);
public IPresentationText getPresentationText(InputStream stream, int mode);
public IPresentationText getPresentationText(InputStream stream, int mode, ILoadOptions options);
```


## **الأسئلة الشائعة**

**ما مدى سرعة معالجة Aspose.Slides للعرض التقديمي الكبير أثناء استخراج النص؟**

تم تحسين Aspose.Slides لأداء عالي وتُعالج حتى [large presentations](/slides/ar/java/open-presentation/) بكفاءة، مما يجعلها مناسبة لسيناريوهات المعالجة في الوقت الفعلي أو الضخمة.

**هل يمكن لـ Aspose.Slides استخراج النص من الجداول والرسوم البيانية داخل العروض التقديمية؟**

نعم، يدعم Aspose.Slides بالكامل استخراج النص من الجداول والرسوم البيانية وعناصر الشرائح المعقدة الأخرى، مما يتيح لك الوصول إلى جميع المحتويات النصية وتحليلها بسهولة.

**هل أحتاج إلى ترخيص خاص لـ Aspose.Slides لاستخراج النص من العروض التقديمية؟**

يمكنك استخراج النص باستخدام نسخة التجربة المجانية من Aspose.Slides، على الرغم من أن لديها بعض القيود، مثل معالجة عدد محدود من الشرائح فقط. للحصول على استخدام غير مقيد ومعالجة عروض تقديمية أكبر، يُنصح بشراء ترخيص كامل.