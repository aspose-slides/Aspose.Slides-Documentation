---
title: استخراج النص من العرض التقديمي
type: docs
weight: 90
url: /ar/androidjava/extract-text-from-presentation/
---

{{% alert color="primary" %}} 

ليس من غير المعتاد أن يحتاج المطورون إلى استخراج النص من العرض التقديمي. للقيام بذلك، تحتاج إلى استخراج النص من جميع الأشكال الموجودة على جميع الشرائح في العرض التقديمي. يشرح هذا المقال كيفية استخراج النص من عروض PowerPoint PPTX باستخدام Aspose.Slides. 

{{% /alert %}} 
## **استخراج النص من الشريحة**
توفر Aspose.Slides لنظام Android عبر Java فئة [SlideUtil](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SlideUtil). تكشف هذه الفئة عن عدد من الأساليب الثابتة التي يتم تحميلها بشكل زائد لاستخراج النص بالكامل من عرض تقديمي أو شريحة. لاستخراج النص من شريحة في عرض تقديمي PPTX،
استخدم الطريقة الثابتة المحملة بشكل زائد [getAllTextBoxes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SlideUtil#getAllTextBoxes-com.aspose.slides.IBaseSlide-) المقدمة بواسطة فئة [SlideUtil](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SlideUtil). تأخذ هذه الطريقة كائن الشريحة كمعامل.
عند التنفيذ، تقوم هذه الطريقة بمسح النص بالكامل من الشريحة المرسلة كمعامل وتعيد مصفوفة من كائنات [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrame). وهذا يعني أن أي تنسيق نصي مرتبط بالنص سيكون متاحًا. القطعة التالية من الكود تستخرج كل النصوص في الشريحة الأولى من العرض التقديمي:

```java
//إنشاء مثيل لفئة العرض التقديمي التي تمثل ملف PPTX
Presentation pres = new Presentation("demo.pptx");
try {
    for (ISlide slide : pres.getSlides()) 
    {
        //الحصول على مصفوفة من كائنات ITextFrame من جميع الشرائح في PPTX
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

## **استخراج النص من العرض التقديمي**
للمسح النصي من العرض التقديمي بالكامل، استخدم الطريقة الثابتة [getAllTextFrames](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SlideUtil#getAllTextFrames-com.aspose.slides.IPresentation-boolean-) المقدمة بواسطة فئة SlideUtil. تأخذ هذه الطريقة معاملين:

1. أولاً، كائن [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextExtractionArrangingMode#Unarranged) يمثل العرض التقديمي الذي يتم استخراج النص منه.
2. ثانيًا، قيمة بوليانية تحدد ما إذا كان يجب تضمين الشريحة الرئيسية عند مسح النص من العرض التقديمي.
   تُعيد الطريقة مصفوفة من كائنات [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrame) كاملة مع معلومات تنسيق النص. الكود أدناه يمسح النص ومعلومات التنسيق من عرض تقديمي، بما في ذلك الشرائح الرئيسية.

```java
//إنشاء مثيل لفئة العرض التقديمي التي تمثل ملف PPTX
Presentation pres = new Presentation("demo.pptx");
try {
    //الحصول على مصفوفة من كائنات ITextFrame من جميع الشرائح في PPTX
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

## **استخراج نص منظم وسريع**
تمت إضافة الطريقة الثابتة getPresentationText إلى فئة Presentation. هناك ثلاثة تحميلات زائدة لهذه الطريقة:

```java
public IPresentationText getPresentationText(String file, int mode);
public IPresentationText getPresentationText(InputStream stream, int mode);
public IPresentationText getPresentationText(InputStream stream, int mode, ILoadOptions options);
``` 

معامل التعداد [TextExtractionArrangingMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextExtractionArrangingMode) يشير إلى الوضع لتنظيم مخرجات نتيجة النص ويمكن تعيينه إلى القيم التالية:
- [Unarranged](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextExtractionArrangingMode#Unarranged) - النص الخام بدون مراعاة الوضع على الشريحة
- [Arranged](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextExtractionArrangingMode#Arranged) - يتم تحديد النص بنفس ترتيب ظهوره في الشريحة

يمكن استخدام وضع **Unarranged** عندما تكون السرعة ذات أهمية كبيرة، فهو أسرع من وضع Arranged.

يمثل [IPresentationText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPresentationText) النص الخام المستخرج من العرض التقديمي. يحتوي على طريقة [getSlidesText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPresentationText#getSlidesText--) التي تُعيد مصفوفة من كائنات [ISlideText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideText). يمثل كل كائن النص الموجود على الشريحة المقابلة. كائن [ISlideText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideText) يتمتع بالطرق التالية:

- [ISlideText.getText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideText#getText--) - النص على أشكال الشريحة
- [ISlideText.getMasterText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideText#getMasterText--) - النص على أشكال الصفحة الرئيسية لهذه الشريحة
- [ISlideText.getLayoutText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideText#getLayoutText--) - النص على أشكال صفحة التخطيط لهذه الشريحة
- [ISlideText.getNotesText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideText#getNotesText--) - النص على أشكال صفحة الملاحظات لهذه الشريحة

هناك أيضًا فئة [SlideText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SlideText) التي تنفذ واجهة [ISlideText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideText).

يمكن استخدام واجهة برمجة التطبيقات الجديدة كالتالي:

```java
IPresentationText text1 = PresentationFactory.getInstance().getPresentationText("presentation.pptx", TextExtractionArrangingMode.Unarranged);
System.out.println(text1.getSlidesText()[0].getText());
System.out.println(text1.getSlidesText()[0].getLayoutText());
System.out.println(text1.getSlidesText()[0].getMasterText());
System.out.println(text1.getSlidesText()[0].getNotesText());
```