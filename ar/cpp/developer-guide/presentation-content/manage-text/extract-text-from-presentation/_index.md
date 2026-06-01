---
title: استخراج النص المتقدم من العروض التقديمية في C++
linktitle: استخراج النص
type: docs
weight: 90
url: /ar/cpp/extract-text-from-presentation/
keywords:
  - استخراج النص
  - استخراج النص من شريحة
  - استخراج النص من عرض تقديمي
  - استخراج النص من PowerPoint
  - استخراج النص من OpenDocument
  - استخراج النص من PPT
  - استخراج النص من PPTX
  - استخراج النص من ODP
  - استرداد النص
  - استرداد النص من شريحة
  - استرداد النص من عرض تقديمي
  - استرداد النص من PowerPoint
  - استرداد النص من OpenDocument
  - استرداد النص من PPT
  - استرداد النص من PPTX
  - استرداد النص من ODP
  - PowerPoint
  - OpenDocument
  - عرض تقديمي
  - C++
  - Aspose.Slides
description: "استخراج النص بسرعة من عروض PowerPoint وOpenDocument باستخدام Aspose.Slides for C++. اتبع دليلنا البسيط خطوة بخطوة لتوفير الوقت."
---
## **نظرة عامة**

يُعد استخراج النص من العروض التقديمية مهمة شائعة ولكنها أساسية للمطورين الذين يعملون مع محتوى الشرائح. سواء كنت تتعامل مع ملفات Microsoft PowerPoint بصيغة PPT أو PPTX، أو عروض OpenDocument (ODP)، فإن الوصول إلى البيانات النصية واسترجاعها يمكن أن يكون حاسمًا للتحليل، والأتمتة، والفهرسة، أو أغراض ترحيل المحتوى.

توفر هذه المقالة دليلًا شاملًا حول كيفية استخراج النص بفعالية من صيغ العروض التقديمية المختلفة، بما في ذلك PPT وPPTX وODP، باستخدام Aspose.Slides for C++. ستتعلم كيفية التنقل عبر عناصر العرض التقديمي بصورة منهجية لاسترجاع المحتوى النصي الذي تحتاجه بدقة.

## **استخراج النص من شريحة**

يوفر Aspose.Slides for C++ مساحة الاسم [Aspose.Slides.Util](https://reference.aspose.com/slides/ar/cpp/aspose.slides.util/) التي تتضمن الفئة [SlideUtil](https://reference.aspose.com/slides/ar/cpp/aspose.slides.util/slideutil/). تُقَدِّم هذه الفئة عدة طرق ثابتة مُحمَّلة لاستخراج كل النص من عرض تقديمي أو شريحة. لاستخراج النص من شريحة في عرض تقديمي، استخدم الطريقة [GetAllTextBoxes](https://reference.aspose.com/slides/ar/cpp/aspose.slides.util/slideutil/getalltextboxes/). تقبل هذه الطريقة كمعامل كائن من النوع [IBaseSlide](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ibaseslide/). عند التنفيذ، تقوم الطريقة بمسح الشريحة بالكامل للبحث عن النص وتعيد مصفوفة من الكائنات من النوع [ITextFrame](https://reference.aspose.com/slides/ar/cpp/aspose.slides/itextframe/)، مع الحفاظ على أي تنسيق نصي.

القطعة البرمجية التالية تستخرج كل النص من الشريحة الأولى في العرض التقديمي:

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

لمسح النص من العرض التقديمي بالكامل، استخدم الطريقة الثابتة [GetAllTextFrames](https://reference.aspose.com/slides/ar/cpp/aspose.slides.util/slideutil/getalltextframes/) التي تُقَدِّمها الفئة [SlideUtil](https://reference.aspose.com/slides/ar/cpp/aspose.slides.util/slideutil/). تقبل هذه الطريقة معلمين:

1. أولاً، كائن من النوع [IPresentation](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ipresentation/) يمثل عرض PowerPoint أو OpenDocument سيتم استخراج النص منه.  
2. ثانياً، قيمة `Boolean` تُحدِّد ما إذا كان يجب تضمين الشرائح الرئيسية عند مسح النص من العرض التقديمي.

تُعيد الطريقة مصفوفة من الكائنات من النوع [ITextFrame](https://reference.aspose.com/slides/ar/cpp/aspose.slides/itextframe/)، بما في ذلك معلومات تنسيق النص. الشيفرة أدناه تمسح النص وتفاصيل التنسيق من عرض تقديمي، بما في ذلك الشرائح الرئيسية.

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

## **استخراج النص المصنف والسريع**

توفر الفئة [PresentationFactory](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentationfactory/) أيضًا طرقًا لاستخراج كل النص من العروض التقديمية:

```cpp
System::SharedPtr<IPresentationText> GetPresentationText(System::String file, TextExtractionArrangingMode mode);
System::SharedPtr<IPresentationText> GetPresentationText(System::SharedPtr<System::IO::Stream> stream, TextExtractionArrangingMode mode);
System::SharedPtr<IPresentationText> GetPresentationText(System::SharedPtr<System::IO::Stream> stream, TextExtractionArrangingMode mode, System::SharedPtr<ILoadOptions> options);
```

يُشير معامل التعداد [TextExtractionArrangingMode](https://reference.aspose.com/slides/ar/cpp/aspose.slides/textextractionarrangingmode/) إلى وضع تنظيم نتيجة استخراج النص ويمكن تعيينه إلى القيم التالية:
- `Unarranged` - النص الخام دون مراعاة موقعه على الشريحة.  
- `Arranged` - يتم ترتيب النص بنفس الترتيب الموجود على الشريحة