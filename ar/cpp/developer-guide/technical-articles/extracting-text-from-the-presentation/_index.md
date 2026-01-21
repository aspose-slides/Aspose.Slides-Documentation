---
title: استخراج النص من العروض التقديمية
type: docs
weight: 60
url: /ar/cpp/extracting-text-from-the-presentation/
keywords:
- استخراج النص
- استرجاع النص
- شريحة
- مربع نص
- PowerPoint
- OpenDocument
- عرض تقديمي
- C++
- Aspose.Slides
description: "تعلم كيفية استخراج النص من الشرائح أو العروض التقديمية بالكامل في Aspose.Slides للغة C++ ومعالجة المحتوى من ملفات PPT و PPTX و ODP برمجياً."
---

{{% alert color="primary" %}} 

ليس من غير المألوف أن يحتاج المطورون إلى استخراج النص من عرض تقديمي. للقيام بذلك، تحتاج إلى استخراج النص من جميع الأشكال في جميع الشرائح داخل العرض التقديمي. يوضح هذا المقال كيفية استخراج النص من عروض Microsoft PowerPoint PPTX باستخدام Aspose.Slides. يمكن استخراج النص بالطرق التالية:

[استخراج النص من شريحة واحدة](/slides/ar/cpp/extracting-text-from-the-presentation/)
[استخراج النص باستخدام طريقة GetAllTextBoxes](/slides/ar/cpp/extracting-text-from-the-presentation/)
[استخراج النص بطريقة مصنفة وسريعة](/slides/ar/cpp/extracting-text-from-the-presentation/)

{{% /alert %}} 
## **استخراج النص من شريحة**
يوفر Aspose.Slides للغة C++ مساحة الاسم Aspose.Slides.Util التي تشمل فئة PresentationScanner. تُعرِّف هذه الفئة عددًا من الطرق الساكنة المتجاوزة لتحميل النص بالكامل من عرض تقديمي أو شريحة. لاستخراج النص من شريحة في عرض PPTX، استخدم طريقة [GetAllTextBoxes](https://reference.aspose.com/slides/cpp/aspose.slides.util/slideutil/getalltextboxes/) الساكنة المتجاوزة التي تُعرَضها فئة PresentationScanner. تقبل هذه الطريقة كمعامل كائن Slide.

عند التنفيذ، تقوم طريقة Slide بمسح النص بالكامل من الشريحة المرسلة كمعامل وتعيد مصفوفة من كائنات TextFrame. وهذا يعني أن أي تنسيق نصي مرتبط بالنص سيكون متاحًا. القطعة البرمجية التالية تستخرج كل النص في الشريحة الأولى من العرض التقديمي:

**C#**
``` cpp

 //إنشاء كائن PresentationEx الذي يمثل ملف PPTX

Presentation pptxPresentation = new Presentation(path + "demo.pptx");


//الحصول على مصفوفة من كائنات TextFrameEx من الشريحة الأولى

ITextFrame[] textFramesSlideOne = SlideUtil.GetAllTextBoxes(pptxPresentation.Slides[0]);

//التكرار عبر مصفوفة TextFrames

for (int i = 0; i < textFramesSlideOne.Length; i++)

    //التكرار عبر الفقرات في TextFrame الحالي

    foreach (Paragraph para in textFramesSlideOne[i].Paragraphs)

        //التكرار عبر الأجزاء في الفقرة الحالية

        foreach (Portion port in para.Portions)

        {

            //عرض النص في الجزء الحالي

            Console.WriteLine(port.Text);

            //عرض ارتفاع الخط للنص

            Console.WriteLine(port.PortionFormat.FontHeight);

            //عرض اسم الخط للنص

            Console.WriteLine(port.PortionFormat.LatinFont.FontName);

        }



```



## **استخراج النص من العرض التقديمي بالكامل**
لمسح النص من كامل العرض التقديمي، استخدم طريقة [GetAllTextFrames](https://reference.aspose.com/slides/cpp/aspose.slides.util/slideutil/getalltextframes/) الساكنة التي تُعرَضها فئة PresentationScanner. تأخذ هذه الطريقة معاملين:

1. أولاً، كائن Presentation يمثل عرض PPTX الذي يُستخرج منه النص.
2. ثانياً، قيمة منطقية تحدد ما إذا كان يجب تضمين الشريحة الرئيسة عند مسح النص من العرض التقديمي.

تُعيد الطريقة مصفوفة من كائنات TextFrame، مكتملةً بمعلومات تنسيق النص. الشيفرة أدناه تمسح النص ومعلومات التنسيق من عرض تقديمي، بما في ذلك الشرائح الرئيسة.

**C#**
``` cpp

 //إنشاء كائن Presentation الذي يمثل ملف PPTX

Presentation pptxPresentation = new Presentation(path + "demo.pptx");

//الحصول على مصفوفة من كائنات ITextFrame من جميع الشرائح في ملف PPTX

ITextFrame[] textFramesPPTX = Aspose.Slides.Util.SlideUtil.GetAllTextFrames(pptxPresentation, true);

//التكرار عبر مصفوفة TextFrames

for (int i = 0; i < textFramesPPTX.Length; i++)

    //التكرار عبر الفقرات في ITextFrame الحالي

    foreach (IParagraph para in textFramesPPTX[i].Paragraphs)

        //التكرار عبر الأجزاء في IParagraph الحالي

        foreach (IPortion port in para.Portions)

        {

            //عرض النص في الجزء الحالي

            Console.WriteLine(port.Text);

            //عرض ارتفاع الخط للنص

            Console.WriteLine(port.PortionFormat.FontHeight);

            //عرض اسم الخط للنص

            if (port.PortionFormat.LatinFont != null)

                Console.WriteLine(port.PortionFormat.LatinFont.FontName);

        }

```



## **استخراج النص بطريقة مصنفة وسريعة**
تم إضافة طريقة ساكنة جديدة GetPresentationText إلى فئة Presentation. هناك مرتان متجاوزتان لهذه الطريقة:
``` cpp

 PresentationText GetPresentationText(Stream stream)

PresentationText GetPresentationText(Stream stream, ExtractionMode mode)


```


معامل تعداد ExtractionMode يحدد وضع تنظيم ناتج النص ويمكن ضبطه على القيم التالية:
Unarranged - النص الخام دون مراعاة موضعه على الشريحة
Arranged - النص موضع بالترتيب نفسه كما هو على الشريحة

يمكن استخدام وضع Unarranged عندما تكون السرعة حرجة؛ فهو أسرع من وضع Arranged.

يمثل PresentationText النص الخام المستخرج من العرض التقديمي. يحتوي على خاصية SlidesText من مساحة الاسم Aspose.Slides.Util التي تُعيد مصفوفة من كائنات ISlideText. كل كائن يمثل النص على الشريحة المقابلة. كائن ISlideText يمتلك الخصائص التالية:

ISlideText.Text - النص على أشكال الشريحة
ISlideText.MasterText - النص على أشكال الصفحة الرئيسية لهذه الشريحة
ISlideText.LayoutText - النص على أشكال صفحة التخطيط لهذه الشريحة
ISlideText.NotesText - النص على أشكال صفحة الملاحظات لهذه الشريحة

هناك أيضًا فئة SlideText التي تُنفِّذ واجهة ISlideText.

يمكن استخدام الواجهة البرمجية الجديدة هكذا:
``` cpp

 PresentationText text1 = Presentation.GetPresentationText("presentation.ppt");

Console.WriteLine(text1.SlidesText[0].Text);

Console.WriteLine(text1.SlidesText[0].LayoutText);

Console.WriteLine(text1.SlidesText[0].MasterText);

Console.WriteLine(text1.SlidesText[0].NotesText);

PresentationText text2 = Presentation.GetPresentationText("presentation.pptx", ExtractionMode.Unarranged);


```
