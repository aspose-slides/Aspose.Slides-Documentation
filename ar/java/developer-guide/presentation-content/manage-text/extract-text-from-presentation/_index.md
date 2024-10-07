---
title: استخراج النص من العرض
type: docs
weight: 90
url: /java/extract-text-from-presentation/
---

{{% alert color="primary" %}} 

ليس من غير المألوف أن يحتاج المطورون إلى استخراج النص من عرض تقديمي. للقيام بذلك، تحتاج إلى استخراج النص من جميع الأشكال الموجودة في جميع الشرائح في العرض التقديمي. يشرح هذا المقال كيفية استخراج النص من عروض Microsoft PowerPoint PPTX باستخدام Aspose.Slides. 

{{% /alert %}} 
## **استخراج النص من الشريحة**
تقدم Aspose.Slides لـ Java فئة [SlideUtil](https://reference.aspose.com/slides/java/com.aspose.slides/SlideUtil). تكشف هذه الفئة عن عدد من الطرق الثابتة الزائدة لاستخراج النص بالكامل من عرض تقديمي أو شريحة. لاستخراج النص من شريحة في عرض تقديمي PPTX، استخدم الطريقة الثابتة الزائدة [getAllTextBoxes](https://reference.aspose.com/slides/java/com.aspose.slides/SlideUtil#getAllTextBoxes-com.aspose.slides.IBaseSlide-) التي تكشف عنها فئة [SlideUtil](https://reference.aspose.com/slides/java/com.aspose.slides/SlideUtil). تقبل هذه الطريقة كائن الشريحة كمعامل.
عند التنفيذ، يقوم طريقة الشريحة بمسح النص بالكامل من الشريحة الممررة كمعامل ويعيد مصفوفة من كائنات [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrame). هذا يعني أن أي تنسيق نص مرتبط بالنص متاح. تقتطع قطعة الكود التالية جميع النصوص الموجودة على الشريحة الأولى من العرض التقديمي:

```java
//إنشاء كائن Presentation الذي يمثل ملف PPTX
Presentation pres = new Presentation("demo.pptx");
try {
    for (ISlide slide : pres.getSlides()) 
    {
        //احصل على مصفوفة من كائنات ITextFrame من جميع الشرائح في الPPTX
        ITextFrame[] textFramesPPTX = SlideUtil.getAllTextBoxes(slide);

        //التكرار عبر مصفوفة TextFrames
        for (int i = 0; i < textFramesPPTX.length; i++) {
            //التكرار عبر الفقرات في ITextFrame الحالي
            for (IParagraph para : textFramesPPTX[i].getParagraphs()) {
                //التكرار عبر الأجزاء في IParagraph الحالي
                for (IPortion port : para.getPortions()) {
                    //عرض النص في الجزء الحالي
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

## **استخراج النص من العرض**
لمسح النص من العرض التقديمي بالكامل، استخدم الطريقة الثابتة [getAllTextFrames](https://reference.aspose.com/slides/java/com.aspose.slides/SlideUtil#getAllTextFrames-com.aspose.slides.IPresentation-boolean-) التي تكشف عنها فئة SlideUtil. تأخذ هذه الطريقة معلمين:

1. أولاً، كائن [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/TextExtractionArrangingMode#Unarranged) يمثل العرض التقديمي الذي يتم استخراج النص منه.
2. ثانياً، قيمة منطقية تحدد ما إذا كان يجب تضمين الشريحة الرئيسية عند مسح النص من العرض التقديمي.
   تعيد الطريقة مصفوفة من كائنات [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrame)، كاملة مع معلومات تنسيق النص. يقوم الكود أدناه بمسح النص ومعلومات التنسيق من العرض التقديمي، بما في ذلك الشرائح الرئيسية.

```java
//إنشاء كائن Presentation الذي يمثل ملف PPTX
Presentation pres = new Presentation("demo.pptx");
try {
    //احصل على مصفوفة من كائنات ITextFrame من جميع الشرائح في الPPTX
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

                //عرض ارتفاع خط النص
                System.out.println(port.getPortionFormat().getFontHeight());

                //عرض اسم خط النص
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
لقد تمت إضافة الطريقة الثابتة الجديدة getPresentationText إلى فئة Presentation. هناك ثلاث طرق زائدة لهذه الطريقة:

```java
public IPresentationText getPresentationText(String file, int mode);
public IPresentationText getPresentationText(InputStream stream, int mode);
public IPresentationText getPresentationText(InputStream stream, int mode, ILoadOptions options);
``` 

يحدد المعامل [TextExtractionArrangingMode](https://reference.aspose.com/slides/java/com.aspose.slides/TextExtractionArrangingMode) الطريقة لتنظيم نتائج النص ويمكن تعيينه إلى القيم التالية:
- [Unarranged](https://reference.aspose.com/slides/java/com.aspose.slides/TextExtractionArrangingMode#Unarranged) - النص الخام بدون مراعاة الموضع على الشريحة
- [Arranged](https://reference.aspose.com/slides/java/com.aspose.slides/TextExtractionArrangingMode#Arranged) - النص موضوع بنفس ترتيب وجوده على الشريحة

يمكن استخدام وضع **Unarranged** عندما تكون السرعة أمراً حاسماً، فهو أسرع من وضع Arranged.

يمثل [IPresentationText](https://reference.aspose.com/slides/java/com.aspose.slides/IPresentationText) النص الخام المستخرج من العرض التقديمي. يحتوي على طريقة [getSlidesText](https://reference.aspose.com/slides/java/com.aspose.slides/IPresentationText#getSlidesText--) التي تعيد مصفوفة من كائنات [ISlideText](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideText). يمثل كل كائن النص على الشريحة المقابلة. يحتوي كائن [ISlideText](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideText) على الطرق التالية:

- [ISlideText.getText](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideText#getText--) - النص على أشكال الشريحة
- [ISlideText.getMasterText](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideText#getMasterText--) - النص على أشكال الصفحة الرئيسية لهذه الشريحة
- [ISlideText.getLayoutText](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideText#getLayoutText--) - النص على أشكال صفحة التخطيط لهذه الشريحة
- [ISlideText.getNotesText](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideText#getNotesText--) - النص على أشكال صفحة الملاحظات لهذه الشريحة

هناك أيضًا فئة [SlideText](https://reference.aspose.com/slides/java/com.aspose.slides/SlideText) التي تقوم بتنفيذ واجهة [ISlideText](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideText).

يمكن استخدام واجهة برمجة التطبيقات الجديدة على النحو التالي:

```java
IPresentationText text1 = PresentationFactory.getInstance().getPresentationText("presentation.pptx", TextExtractionArrangingMode.Unarranged);
System.out.println(text1.getSlidesText()[0].getText());
System.out.println(text1.getSlidesText()[0].getLayoutText());
System.out.println(text1.getSlidesText()[0].getMasterText());
System.out.println(text1.getSlidesText()[0].getNotesText());
```