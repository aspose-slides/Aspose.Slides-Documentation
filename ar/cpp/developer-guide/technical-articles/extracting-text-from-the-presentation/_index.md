---
title: استخراج النص من العرض التقديمي
type: docs
weight: 60
url: /ar/cpp/extracting-text-from-the-presentation/
---

{{% alert color="primary" %}} 

ليس من غير المألوف أن يحتاج المطورون إلى استخراج النص من عرض تقديمي. للقيام بذلك، تحتاج إلى استخراج النص من جميع الأشكال على جميع الشرائح في العرض التقديمي. تشرح هذه المقالة كيفية استخراج النص من عروض PowerPoint PPTX باستخدام Aspose.Slides. يمكن استخراج النص بطرق التالية:

[استخراج النص من شريحة واحدة](/slides/ar/cpp/extracting-text-from-the-presentation/)
[استخراج النص باستخدام طريقة GetAllTextBoxes](/slides/ar/cpp/extracting-text-from-the-presentation/)
[استخراج النص بسرعة وبشكل مصنف](/slides/ar/cpp/extracting-text-from-the-presentation/)

{{% /alert %}} 
## **استخراج النص من شريحة**
تقدم Aspose.Slides للغة C++ مساحة الأسماء Aspose.Slides.Util التي تتضمن فئة PresentationScanner. تعرض هذه الفئة عددًا من الطرق الثابتة المثقلة لاستخراج النص الكامل من عرض تقديمي أو شريحة. لاستخراج النص من شريحة في عرض PPTX، استخدم طريقة [GetAllTextBoxes](http://docs.aspose.com/display/slidesnet/PresentationScanner+Members) الثابتة المثقلة التي تعرضها فئة PresentationScanner. تقبل هذه الطريقة كائن الشريحة كمعامل.
عند التنفيذ، تقوم طريقة الشريحة بمسح النص بالكامل من الشريحة المرسلة كمعامل وتعيد مصفوفة من كائنات TextFrame. هذا يعني أن أي تنسيق نصي مرتبط بالنص متاح. المقطع البرمجي التالي يستخرج كل النص في الشريحة الأولى من العرض التقديمي:

**C#**

``` cpp

 //إنشاء كائن من فئة PresentationEx التي تمثل ملف PPTX

Presentation pptxPresentation = new Presentation(path + "demo.pptx");


//احصل على مصفوفة من كائنات TextFrameEx من الشريحة الأولى

ITextFrame[] textFramesSlideOne = SlideUtil.GetAllTextBoxes(pptxPresentation.Slides[0]);

//قم بالتكرار عبر مصفوفة TextFrames

for (int i = 0; i < textFramesSlideOne.Length; i++)

    //قم بالتكرار عبر الفقرات في TextFrame الحالي

    foreach (Paragraph para in textFramesSlideOne[i].Paragraphs)

        //قم بالتكرار عبر الأجزاء في الفقرة الحالية

        foreach (Portion port in para.Portions)

        {

            //عرض النص في الجزء الحالي

            Console.WriteLine(port.Text);

            //عرض ارتفاع خط النص

            Console.WriteLine(port.PortionFormat.FontHeight);

            //عرض اسم خط النص

            Console.WriteLine(port.PortionFormat.LatinFont.FontName);

        }



```


## **استخراج النص من العرض التقديمي بالكامل**
لتمسح النص من كل العرض التقديمي، استخدم الطريقة الثابتة [GetAllTextFrames](http://docs.aspose.com/display/slidesnet/PresentationScanner+Members) التي تعرضها فئة PresentationScanner. تأخذ طريقتان:

1. أولاً، كائن Presentation يمثل عرض PPTX الذي يتم استخراج النص منه.
1. ثانياً، قيمة منطقية تحدد ما إذا كان ينبغي تضمين الشريحة الرئيسية عند مسح النص من العرض التقديمي.
   تعيد الطريقة مصفوفة من كائنات TextFrame، مكتملة بمعلومات تنسيق النص. الكود أدناه يمسح النص ومعلومات التنسيق من عرض تقديمي، بما في ذلك الشرائح الرئيسية.

**C#**

``` cpp

 //إنشاء كائن من فئة Presentation التي تمثل ملف PPTX

Presentation pptxPresentation = new Presentation(path + "demo.pptx");

//احصل على مصفوفة من كائنات ITextFrame من جميع الشرائح في PPTX

ITextFrame[] textFramesPPTX = Aspose.Slides.Util.SlideUtil.GetAllTextFrames(pptxPresentation, true);

//قم بالتكرار عبر مصفوفة TextFrames

for (int i = 0; i < textFramesPPTX.Length; i++)

    //قم بالتكرار عبر الفقرات في ITextFrame الحالي

    foreach (IParagraph para in textFramesPPTX[i].Paragraphs)

        //قم بالتكرار عبر الأجزاء في IParagraph الحالي

        foreach (IPortion port in para.Portions)

        {

            //عرض النص في الجزء الحالي

            Console.WriteLine(port.Text);

            //عرض ارتفاع خط النص

            Console.WriteLine(port.PortionFormat.FontHeight);

            //عرض اسم خط النص

            if (port.PortionFormat.LatinFont != null)

                Console.WriteLine(port.PortionFormat.LatinFont.FontName);

        }


```


## **استخراج النص بسرعة وبشكل مصنف**
تمت إضافة الطريقة الثابتة الجديدة GetPresentationText إلى فئة Presentation. هناك طريقتان مثقلتان لهذه الطريقة:

``` cpp

 PresentationText GetPresentationText(Stream stream)

PresentationText GetPresentationText(Stream stream, ExtractionMode mode)


```

تشير الوسيطة من نوع ExtractionMode enum إلى وضع تنظيم نتائج النص ويمكن تعيينها إلى القيم التالية:
غير مرتبة - النص الخام دون اعتبار لموقعه على الشريحة
مرتبة - النص موضوعة بنفس ترتيبها كما هو على الشريحة

يمكن استخدام وضع غير مرتب عندما تكون السرعة حرجة، فهو أسرع من الوضع المرتب.

يمثل PresentationText النص الخام المستخرج من العرض التقديمي. يحتوي على خاصية SlidesText من مساحة Aspose.Slides.Util التي تعيد مصفوفة من كائنات ISlideText. يمثل كل كائن النص على الشريحة المقابلة. تحتوي كائنات ISlideText على الخصائص التالية:

ISlideText.Text - النص على أشكال الشريحة
ISlideText.MasterText - النص على أشكال الصفحة الرئيسية لهذه الشريحة
ISlideText.LayoutText - النص على أشكال صفحة التخطيط لهذه الشريحة
ISlideText.NotesText - النص على أشكال صفحة الملاحظات لهذه الشريحة

هناك أيضًا فئة SlideText التي تنفذ واجهة ISlideText.

يمكن استخدام API الجديد كما يلي:

``` cpp

 PresentationText text1 = Presentation.GetPresentationText("presentation.ppt");

Console.WriteLine(text1.SlidesText[0].Text);

Console.WriteLine(text1.SlidesText[0].LayoutText);

Console.WriteLine(text1.SlidesText[0].MasterText);

Console.WriteLine(text1.SlidesText[0].NotesText);

PresentationText text2 = Presentation.GetPresentationText("presentation.pptx", ExtractionMode.Unarranged);


```