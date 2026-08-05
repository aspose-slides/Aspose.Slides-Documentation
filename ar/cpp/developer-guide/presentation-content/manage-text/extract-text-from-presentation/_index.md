---
title: "استخراج النص المتقدم من العروض التقديمية في C++"
linktitle: "استخراج النص"
type: docs
weight: 90
url: /ar/cpp/extract-text-from-presentation/
aliases:
  - /cpp/extracting-text-from-the-presentation/
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
- C++
- Aspose.Slides
description: "استخراج النص بسرعة من عروض PowerPoint و OpenDocument باستخدام Aspose.Slides for C++. اتبع دليلنا البسيط خطوة بخطوة لتوفير الوقت."
---
## **نظرة عامة**

استخراج النص من العروض التقديمية مهمة شائعة ولكنها أساسية للمطورين الذين يعملون مع محتوى الشرائح. سواء كنت تتعامل مع ملفات Microsoft PowerPoint بصيغة PPT أو PPTX، أو عروض OpenDocument (ODP)، فإن الوصول إلى البيانات النصية واسترجاعها يمكن أن يكون حيويًا للتحليل، والأتمتة، والفهرسة، أو ترحيل المحتوى.

تقدم هذه المقالة دليلًا شاملًا حول كيفية استخراج النص بكفاءة من صيغ العروض المختلفة، بما في ذلك PPT و PPTX و ODP، باستخدام Aspose.Slides for C++. ستتعلم كيفية التنقُّل عبر عناصر العرض بصورة منهجية لاسترجاع المحتوى النصي الذي تحتاجه بدقة.

## **استخراج النص من شريحة**

توفر Aspose.Slides for C++ مساحة الأسماء [Aspose.Slides.Util](https://reference.aspose.com/slides/ar/cpp/aspose.slides.util/) التي تضم الفئة [SlideUtil](https://reference.aspose.com/slides/ar/cpp/aspose.slides.util/slideutil/). تُعرّف هذه الفئة عدة أساليب ثابتة محمّلة لاستخراج كل النص من عرض تقديمي أو شريحة. لاستخراج النص من شريحة في عرض تقديمي، استخدم الطريقة [GetAllTextBoxes](https://reference.aspose.com/slides/ar/cpp/aspose.slides.util/slideutil/getalltextboxes/). تقبل هذه الطريقة كمعامل كائنًا من النوع [IBaseSlide](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ibaseslide/). عند تنفيذها، تقوم الطريقة بتمرير كامل الشريحة للبحث عن النص وتعيد مصفوفة من الكائنات من النوع [ITextFrame](https://reference.aspose.com/slides/ar/cpp/aspose.slides/itextframe/)، مع الحفاظ على أي تنسيق نصي.

المقتطف البرمجي التالي يستخرج كل النص من الشريحة الأولى في العرض:

```cpp
auto slideIndex = 0;

auto presentation = System::MakeObject<Presentation>(u"demo.pptx");
auto slide = presentation->get_Slide(slideIndex);

auto textFrames = Util::SlideUtil::GetAllTextBoxes(slide);

for (const auto& textFrame : textFrames)
{
    for (const auto& paragraph : textFrame->get_Paragraphs())
    {
        for (const auto& portion : paragraph->get_Portions())
        {
            auto portionText = portion->get_Text();
            Console::WriteLine(portionText);

            auto portionFormat = portion->get_PortionFormat();
            auto fontHeight = portionFormat->get_FontHeight();
            Console::WriteLine(fontHeight);

            auto latinFont = portionFormat->get_LatinFont();
            if (latinFont != nullptr)
            {
                auto fontName = latinFont->get_FontName();
                Console::WriteLine(fontName);
            }
        }
    }
}

presentation->Dispose();
```

## **استخراج النص من عرض تقديمي**

لتمرير النص من كامل العرض التقديمي، استخدم الطريقة الساكنة [GetAllTextFrames](https://reference.aspose.com/slides/ar/cpp/aspose.slides.util/slideutil/getalltextframes/) الموجودة في الفئة [SlideUtil](https://reference.aspose.com/slides/ar/cpp/aspose.slides.util/slideutil/). تقبل هذه الطريقة معاملين:

1. أولاً، كائن من النوع [IPresentation](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ipresentation/) يمثل عرض PowerPoint أو OpenDocument سيتُستخرج منه النص.
2. ثانيًا، قيمة `Boolean` تحدد ما إذا كان يجب تضمين الشرائح الرئيسة عند فحص النص في العرض.

تُعيد الطريقة مصفوفة من الكائنات من النوع [ITextFrame](https://reference.aspose.com/slides/ar/cpp/aspose.slides/itextframe/)، متضمنة معلومات تنسيق النص. الكود أدناه يمرّ عبر النص وتفاصيل التنسيق في العرض، بما في ذلك الشرائح الرئيسة.

```cpp
auto presentation = System::MakeObject<Presentation>(u"demo.pptx");

auto includeMasterSlides = true;
auto textFrames = Util::SlideUtil::GetAllTextFrames(presentation, includeMasterSlides);

for (const auto& textFrame : textFrames)
{
    for (const auto& paragraph : textFrame->get_Paragraphs())
    {
        for (const auto& portion : paragraph->get_Portions())
        {
            auto portionText = portion->get_Text();
            Console::WriteLine(portionText);

            auto portionFormat = portion->get_PortionFormat();
            auto fontHeight = portionFormat->get_FontHeight();
            Console::WriteLine(fontHeight);

            auto latinFont = portionFormat->get_LatinFont();
            if (latinFont != nullptr)
            {
                auto fontName = latinFont->get_FontName();
                Console::WriteLine(fontName);
            }
        }
    }
}

presentation->Dispose();
```

## **استخراج النص المُصنّف والسريع**

توفر الفئة [PresentationFactory](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentationfactory/) أيضًا أساليب لاستخراج كل النص من العروض:

```cpp
System::SharedPtr<IPresentationText> GetPresentationText(System::String file, TextExtractionArrangingMode mode);
System::SharedPtr<IPresentationText> GetPresentationText(System::SharedPtr<System::IO::Stream> stream, TextExtractionArrangingMode mode);
System::SharedPtr<IPresentationText> GetPresentationText(System::SharedPtr<System::IO::Stream> stream, TextExtractionArrangingMode mode, System::SharedPtr<ILoadOptions> options);
```

وسيط التعداد [TextExtractionArrangingMode](https://reference.aspose.com/slides/ar/cpp/aspose.slides/textextractionarrangingmode/) يحدد وضع تنظيم نتيجة استخراج النص ويمكن ضبطه على القيم التالية:
- `Unarranged` - النص الخام دون اعتبار لموقعه على الشريحة.
- `Arranged` - يُرتّب النص بنفس ترتيب ظهوره على الشريحة.

يمكن استخدام وضع **Unarranged** عندما تكون السرعة حرجة؛ فهو أسرع من وضع **Arranged**.

تمثل الواجهة [IPresentationText](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ipresentationtext/) النص الخام المستخرج من العرض. تُعيد طريقتها `get_SlidesText()` مصفوفة من الكائنات من النوع [ISlideText](https://reference.aspose.com/slides/ar/cpp/aspose.slides/islidetext/). كل كائن يمثل النص في الشريحة المقابلة. يحتوي الكائن من النوع [ISlideText](https://reference.aspose.com/slides/ar/cpp/aspose.slides/islidetext/) على الطرق التالية:

- `get_Text()` - النص داخل أشكال الشريحة.
- `get_MasterText()` - النص داخل أشكال الشريحة الرئيسة المرتبطة بهذه الشريحة.
- `get_LayoutText()` - النص داخل أشكال شريحة التخطيط المرتبطة بهذه الشريحة.
- `get_NotesText()` - النص داخل أشكال شريحة الملاحظات المرتبطة بهذه الشريحة.
- `get_CommentsText()` - النص داخل التعليقات المرتبطة بهذه الشريحة.

```cpp
auto presentationPath = u"presentation.ppt";
auto arrangingMode = TextExtractionArrangingMode::Unarranged;
auto presentationText = PresentationFactory::get_Instance()->GetPresentationText(presentationPath, arrangingMode);
auto firstSlideText = presentationText->get_SlidesText()[0];

Console::WriteLine(firstSlideText->get_Text());
Console::WriteLine(firstSlideText->get_LayoutText());
Console::WriteLine(firstSlideText->get_MasterText());
Console::WriteLine(firstSlideText->get_NotesText());
Console::WriteLine(firstSlideText->get_CommentsText());
```

## **الأسئلة الشائعة**

**ما هي سرعة معالجة Aspose.Slides للعروض الكبيرة أثناء استخراج النص؟**

تم تحسين Aspose.Slides للأداء العالي ويمكنه معالجة حتى [العروض الكبيرة](/slides/ar/cpp/open-presentation/)، مما يجعله مناسبًا للسيناريوهات الزمنية الفورية أو المعالجة الضخمة.

**هل يستطيع Aspose.Slides استخراج النص من الجداول والمخططات داخل العروض؟**

نعم. يستطيع Aspose.Slides استخراج النص من العديد من عناصر الشريحة، بما في ذلك الجداول والكائنات المرتبطة بالمخططات، لتتمكن من الوصول إلى المحتوى النصي وتحليله في هياكل العرض الشائعة.

**هل أحتاج إلى ترخيص خاص من Aspose.Slides لاستخراج النص من العروض؟**

يمكنك استخراج النص باستخدام نسخة التجربة المجانية من Aspose.Slides، ولكنها ستخضع لـ[قيود معينة](/slides/ar/cpp/licensing/)، مثل معالجة عدد محدود من الشرائح. للحصول على استخدام غير مقيد ومعالجة عروض أكبر، يُنصح بشراء ترخيص كامل.