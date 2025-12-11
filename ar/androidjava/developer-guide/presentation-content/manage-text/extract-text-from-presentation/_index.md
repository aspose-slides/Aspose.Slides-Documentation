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
- العرض التقديمي
- Android
- Java
- Aspose.Slides
description: "استخراج النص بسرعة من عروض PowerPoint و OpenDocument باستخدام Aspose.Slides لنظام Android عبر Java. اتبع دليلنا البسيط خطوة بخطوة لتوفير الوقت."
---

{{% alert color="primary" %}} 

ليس بالأمر النادر أن يحتاج المطورون إلى استخراج النص من عرض تقديمي. للقيام بذلك، تحتاج إلى استخراج النص من جميع الأشكال في جميع الشرائح في العرض التقديمي. تشرح هذه المقالة كيفية استخراج النص من عروض PowerPoint PPTX باستخدام Aspose.Slides. 

{{% /alert %}} 
## **استخراج النص من شريحة**
Aspose.Slides for Android via Java يوفر الفئة [SlideUtil](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SlideUtil) . هذه الفئة تعرض عددًا من الطرق الثابتة المحملة لاستخراج النص بالكامل من عرض تقديمي أو شريحة. لاستخراج النص من شريحة في عرض PPTX، استخدم الطريقة الثابتة المحملة [getAllTextBoxes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SlideUtil#getAllTextBoxes-com.aspose.slides.IBaseSlide-) التي توفرها فئة [SlideUtil](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SlideUtil) . تقبل هذه الطريقة كائن Slide كمعامل.
عند التنفيذ، تقوم طريقة Slide بمسح جميع النصوص من الشريحة التي تم تمريرها كمعامل وتعيد مصفوفة من كائنات [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrame) . وهذا يعني أن أي تنسيق نص مرتبط بالنص متاح. الجزء التالي من الكود يستخرج كل النص على الشريحة الأولى من العرض التقديمي:
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


## **استخراج النص من عرض تقديمي**
لمسح النص من كامل العرض التقديمي، استخدم الطريقة الثابتة [getAllTextFrames](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SlideUtil#getAllTextFrames-com.aspose.slides.IPresentation-boolean-) التي توفرها فئة SlideUtil. تأخذ هذه الطريقة معاملين:

1. أولاً، كائن [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextExtractionArrangingMode#Unarranged) يمثل العرض التقديمي الذي يجري استخراج النص منه.
1. ثانيًا، قيمة منطقية تحدد ما إذا كان يجب تضمين الشريحة الرئيسية عند مسح النص من العرض التقديمي.
   تُعيد الطريقة مصفوفة من كائنات [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrame) مع معلومات تنسيق النص. الكود أدناه يمسح النص ومعلومات التنسيق من عرض تقديمي، بما في ذلك الشرائح الرئيسية.
```java
//إنشاء كائن من فئة Presentation التي تمثل ملف PPTX
Presentation pres = new Presentation("demo.pptx");
try {
    //احصل على مصفوفة من كائنات ITextFrame من جميع الشرائح في ملف PPTX
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
تمت إضافة الطريقة الثابتة الجديدة getPresentationText إلى فئة Presentation. هناك ثلاث تحميلات لهذه الطريقة:
```java
public IPresentationText getPresentationText(String file, int mode);
public IPresentationText getPresentationText(InputStream stream, int mode);
public IPresentationText getPresentationText(InputStream stream, int mode, ILoadOptions options);
```


## **الأسئلة المتكررة**

**ما مدى سرعة معالجة Aspose.Slides للعرض التقديمي الكبير أثناء استخراج النص؟**

تم تحسين Aspose.Slides للأداء العالي وتعمل بكفاءة حتى مع [العروض التقديمية الكبيرة](/slides/ar/androidjava/open-presentation/)، مما يجعلها مناسبة لسيناريوهات المعالجة في الوقت الفعلي أو الكميات الكبيرة.

**هل يمكن لـ Aspose.Slides استخراج النص من الجداول والرسوم البيانية داخل العروض التقديمية؟**

نعم، يدعم Aspose.Slides استخراج النص من الجداول، والرسوم البيانية، وغيرها من عناصر الشريحة المعقدة، مما يتيح لك الوصول إلى جميع المحتويات النصية وتحليلها بسهولة.

**هل أحتاج إلى ترخيص خاص من Aspose.Slides لاستخراج النص من العروض التقديمية؟**

يمكنك استخراج النص باستخدام النسخة التجريبية المجانية من Aspose.Slides، على الرغم من أنها ستكون لها بعض القيود، مثل معالجة عدد محدود من الشرائح فقط. للحصول على استخدام غير محدود ومعالجة عروض تقديمية أكبر، يُنصح بشراء ترخيص كامل.