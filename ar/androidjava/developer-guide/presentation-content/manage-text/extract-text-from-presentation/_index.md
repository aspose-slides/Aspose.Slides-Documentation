---
title: استخراج النص المتقدم من العروض التقديمية على Android
linktitle: استخراج النص
type: docs
weight: 90
url: /ar/androidjava/extract-text-from-presentation/
keywords:
- استخراج النص
- استخراج النص من شريحة
- استخراج النص من عرض تقديمي
- استخراج النص من PowerPoint
- استخراج النص من OpenDocument
- استخراج النص من PPT
- استخراج النص من PPTX
- استخراج النص من ODP
- استرجاع النص
- استرجاع النص من شريحة
- استرجاع النص من عرض تقديمي
- استرجاع النص من PowerPoint
- استرجاع النص من OpenDocument
- استرجاع النص من PPT
- استرجاع النص من PPTX
- استرجاع النص من ODP
- PowerPoint
- OpenDocument
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "استخراج النص بسرعة من عروض PowerPoint و OpenDocument باستخدام Aspose.Slides لأندرويد عبر جافا. اتبع دليلنا البسيط خطوة بخطوة لتوفير الوقت."
---

{{% alert color="primary" %}} 

ليس من غير المألوف أن يحتاج المطورون إلى استخراج النص من عرض تقديمي. للقيام بذلك، تحتاج إلى استخراج النص من جميع الأشكال في جميع الشرائح داخل العرض التقديمي. توضح هذه المقالة كيفية استخراج النص من عروض Microsoft PowerPoint PPTX باستخدام Aspose.Slides. 

{{% /alert %}} 
## **استخراج النص من شريحة**
توفر Aspose.Slides for Android عبر Java الفئة [SlideUtil](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SlideUtil) . تكشف هذه الفئة عن عدد من الطرق الساكنة المتعددة الأحمال لاستخراج النص الكامل من عرض تقديمي أو شريحة. لاستخراج النص من شريحة في عرض PPTX، استخدم الطريقة الساكنة المتعددة الأحمال [getAllTextBoxes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SlideUtil#getAllTextBoxes-com.aspose.slides.IBaseSlide-) التي تكشف عنها الفئة [SlideUtil](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SlideUtil) . تقبل هذه الطريقة كائن Slide كمعامل.  
عند التنفيذ، تقوم طريقة Slide بمسح النص الكامل من الشريحة التي تم تمريرها كمعامل وتعيد مصفوفة من كائنات [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrame) . وهذا يعني أن أي تنسيق نصي مرتبط بالنص متاح. الجزء التالي من الشفرة يستخرج كل النص في الشريحة الأولى من العرض التقديمي:
```java
//إنشاء كائن من فئة Presentation التي تمثل ملف PPTX
Presentation pres = new Presentation("demo.pptx");
try {
    for (ISlide slide : pres.getSlides()) 
    {
        //الحصول على مصفوفة من كائنات ITextFrame من جميع الشرائح في ملف PPTX
        ITextFrame[] textFramesPPTX = SlideUtil.getAllTextBoxes(slide);

        //التكرار عبر مصفوفة TextFrames
        for (int i = 0; i < textFramesPPTX.length; i++) {
            //التكرار عبر الفقرات في كائن ITextFrame الحالي
            for (IParagraph para : textFramesPPTX[i].getParagraphs()) {
                //التكرار عبر الأجزاء في كائن IParagraph الحالي
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


## **استخراج النص من عرض تقديمي**
لمسح النص من كامل العرض التقديمي، استخدم الطريقة الساكنة [getAllTextFrames](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SlideUtil#getAllTextFrames-com.aspose.slides.IPresentation-boolean-) التي تكشف عنها فئة SlideUtil. تأخذ هذه الطريقة معاملين:

1. أولاً، كائن [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextExtractionArrangingMode#Unarranged) يمثل العرض التقديمي الذي يتم استخراج النص منه.  
2. ثانياً، قيمة منطقية تحدد ما إذا كان يجب تضمين الشريحة الرئيسية عند مسح النص من العرض التقديمي.  
تعيد الطريقة مصفوفة من كائنات [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrame) مكتملة بمعلومات تنسيق النص. الشفرة أدناه تمسح النص ومعلومات التنسيق من عرض تقديمي، بما في ذلك الشرائح الرئيسية.
```java
//Instatiate Presentation class that represents a PPTX file
Presentation pres = new Presentation("demo.pptx");
try {
    //Get an Array of ITextFrame objects from all slides in the PPTX
    ITextFrame[] textFramesPPTX = SlideUtil.getAllTextFrames(pres, true);

    //Loop through the Array of TextFrames
    for (int i = 0; i < textFramesPPTX.length; i++) 
    {
        //Loop through paragraphs in current ITextFrame
        for (IParagraph para : textFramesPPTX[i].getParagraphs())
        {
            //Loop through portions in the current IParagraph
            for (IPortion port : para.getPortions())
            {
                //Display text in the current portion
                System.out.println(port.getText());

                //Display font height of the text
                System.out.println(port.getPortionFormat().getFontHeight());

                //Display font name of the text
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
تم إضافة الطريقة الساكنة الجديدة getPresentationText إلى فئة Presentation. هناك ثلاث تحميلات لهذه الطريقة:
```java
public IPresentationText getPresentationText(String file, int mode);
public IPresentationText getPresentationText(InputStream stream, int mode);
public IPresentationText getPresentationText(InputStream stream, int mode, ILoadOptions options);
``` 

The [TextExtractionArrangingMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextExtractionArrangingMode) enum argument indicates the mode to organize the output of text result and can be set to the following values:
- [Unarranged](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextExtractionArrangingMode#Unarranged) - The raw text with no respect to position on the slide
- [Arranged](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextExtractionArrangingMode#Arranged) - The text is positioned in the same order as on the slide

**Unarranged** mode can be used when speed is critical, it's faster than Arranged mode.

[IPresentationText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPresentationText) represents the raw text extracted from the presentation. It contains a [getSlidesText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPresentationText#getSlidesText--) method which returns an array of [ISlideText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideText) objects. Every object represent the text on the corresponding slide. [ISlideText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideText) object have the following methods:

- [ISlideText.getText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideText#getText--) - The text on the slide's shapes
- [ISlideText.getMasterText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideText#getMasterText--) - The text on the master page's shapes for this slide
- [ISlideText.getLayoutText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideText#getLayoutText--) - The text on the layout page's shapes for this slide
- [ISlideText.getNotesText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideText#getNotesText--) - The text on the notes page's shapes for this slide

There is also a [SlideText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SlideText) class which implements the [ISlideText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideText) interface.

The new API can be used like this:

```java
IPresentationText text1 = PresentationFactory.getInstance().getPresentationText("presentation.pptx", TextExtractionArrangingMode.Unarranged);
System.out.println(text1.getSlidesText()[0].getText());
System.out.println(text1.getSlidesText()[0].getLayoutText());
System.out.println(text1.getSlidesText()[0].getMasterText());
System.out.println(text1.getSlidesText()[0].getNotesText());
```


## **الأسئلة المتكررة**

**ما مدى سرعة معالجة Aspose.Slides للعرض التقديمي الكبير أثناء استخراج النص؟**

تم تحسين Aspose.Slides للأداء العالي ويعالج بشكل فعال حتى [العروض التقديمية الكبيرة](/slides/ar/androidjava/open-presentation/)، مما يجعله مناسبًا لسيناريوهات المعالجة في الوقت الحقيقي أو على نطاق واسع.

**هل يمكن لـ Aspose.Slides استخراج النص من الجداول والمخططات داخل العروض التقديمية؟**

نعم، يدعم Aspose.Slides استخراج النص من الجداول والمخططات وعناصر الشرائح المعقدة الأخرى بالكامل، مما يتيح لك الوصول إلى جميع المحتويات النصية وتحليلها بسهولة.

**هل أحتاج إلى ترخيص خاص من Aspose.Slides لاستخراج النص من العروض التقديمية؟**

يمكنك استخراج النص باستخدام نسخة التجربة المجانية من Aspose.Slides، رغم أنها ستفرض بعض القيود، مثل معالجة عدد محدود من الشرائح فقط. للاستخدام غير المقيد ولمعالجة عروض تقديمية أكبر، يُنصح بشراء ترخيص كامل.