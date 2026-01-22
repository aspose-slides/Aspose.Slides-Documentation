---
title: استخراج النص المتقدم من العروض التقديمية على Android
linktitle: استخراج النص
type: docs
weight: 90
url: /ar/androidjava/extract-text-from-presentation/
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
- Android
- Java
- Aspose.Slides
description: "استخراج النص بسرعة من عروض PowerPoint و OpenDocument باستخدام Aspose.Slides لنظام Android عبر Java. اتبع دليلنا البسيط خطوة بخطوة لتوفير الوقت."
---

{{% alert color="primary" %}} 

ليس من غير المألوف أن يحتاج المطورون إلى استخراج النص من عرض تقديمي. للقيام بذلك، يجب استخراج النص من جميع الأشكال في جميع الشرائح في العرض التقديمي. يوضح هذا المقال كيفية استخراج النص من عروض PowerPoint PPTX باستخدام Aspose.Slides. 

{{% /alert %}} 
## **استخراج النص من الشريحة**
توفر Aspose.Slides for Android via Java الفئة [SlideUtil](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SlideUtil). تعرض هذه الفئة عددًا من الطرق الساكنة المحملة للمتغيرات لاستخراج النص الكامل من عرض تقديمي أو شريحة. لاستخراج النص من شريحة في عرض PPTX،
استخدم الطريقة الساكنة المحملة للمتغيرات [getAllTextBoxes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SlideUtil#getAllTextBoxes-com.aspose.slides.IBaseSlide-) التي تعرضها الفئة [SlideUtil](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SlideUtil). تقبل هذه الطريقة كائن Slide كمعامل.
عند التنفيذ، تفحص طريقة Slide النص الكامل من الشريحة التي تم تمريرها كمعامل وتعيد مصفوفة من كائنات [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrame). وهذا يعني أن أي تنسيق نصي مرتبط بالنص متاح. الجزء التالي من الشيفرة يستخرج كل النص في الشريحة الأولى من العرض التقديمي:
```java
//إنشاء كائن Presentation الذي يمثل ملف PPTX
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
                //التكرار عبر المقاطع في IParagraph الحالي
                for (IPortion port : para.getPortions()) {
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
    }
} finally {
    pres.dispose();
}
```


## **استخراج النص من العرض التقديمي**
لمسح النص من كامل العرض التقديمي، استخدم
الطريقة الساكنة [getAllTextFrames](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SlideUtil#getAllTextFrames-com.aspose.slides.IPresentation-boolean-) التي تعرضها فئة SlideUtil. تأخذ هذه الطريقة معاملين:

1. أولًا، كائن [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextExtractionArrangingMode#Unarranged) يمثل العرض التقديمي الذي يتم استخراج النص منه.
1. ثانيًا، قيمة منطقية تحدد ما إذا كان ينبغي تضمين شريحة القالب الأساسي عند مسح النص من العرض التقديمي.
   تعيد الطريقة مصفوفة من كائنات [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrame) مكتملة بمعلومات تنسيق النص. الشيفرة أدناه تمسح النص ومعلومات التنسيق من عرض تقديمي، بما في ذلك شرائح القالب.
```java
//إنشاء كائن Presentation الذي يمثل ملف PPTX
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
            //التكرار عبر المقاطع في IParagraph الحالي
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


## **استخراج النص المصنف والسريع**
تمت إضافة الطريقة الساكنة الجديدة getPresentationText إلى فئة Presentation. هناك ثلاثة تحميلات لهذه الطريقة:
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

The new API can be used like this:

```java
IPresentationText text1 = PresentationFactory.getInstance().getPresentationText("presentation.pptx", TextExtractionArrangingMode.Unarranged);
System.out.println(text1.getSlidesText()[0].getText());
System.out.println(text1.getSlidesText()[0].getLayoutText());
System.out.println(text1.getSlidesText()[0].getMasterText());
System.out.println(text1.getSlidesText()[0].getNotesText());
```


## **الأسئلة الشائعة**

**ما مدى سرعة معالجة Aspose.Slides للعروض التقديمية الكبيرة أثناء استخراج النص؟**

تم تحسين Aspose.Slides للأداء العالي وتقوم بمعالجة حتى [العروض التقديمية الكبيرة](/slides/ar/androidjava/open-presentation/) بكفاءة، مما يجعلها مناسبة لسيناريوهات المعالجة في الوقت الفعلي أو على نطاق واسع.

**هل يمكن لـ Aspose.Slides استخراج النص من الجداول والرسوم البيانية داخل العروض التقديمية؟**

نعم، يدعم Aspose.Slides استخراج النص بالكامل من الجداول والرسوم البيانية وغيرها من عناصر الشرائح المعقدة، مما يتيح لك الوصول إلى جميع المحتويات النصية بسهولة وتحليلها.

**هل أحتاج إلى ترخيص خاص لـ Aspose.Slides لاستخراج النص من العروض التقديمية؟**

يمكنك استخراج النص باستخدام النسخة التجريبية المجانية من Aspose.Slides، رغم أنها تحتوي على بعض القيود مثل معالجة عدد محدود من الشرائح فقط. للحصول على استخدام غير مقيد ولمعالجة عروض تقديمية أكبر، يوصى بشراء ترخيص كامل.