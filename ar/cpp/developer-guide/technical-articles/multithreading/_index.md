---
title: البرمجة المتعددة الخيوط في Aspose.Slides
type: docs
weight: 200
url: /cpp/multithreading/
keywords:
- PowerPoint
- عرض تقديمي
- البرمجة المتعددة الخيوط
- العمل المتوازي
- تحويل الشرائح
- الشرائح إلى صور
- C++
- Aspose.Slides لـ C++
---

## **مقدمة**

بينما العمل المتوازي مع العروض التقديمية ممكن (بالإضافة إلى تحليل/تحميل/استنساخ) وكل شيء يسير بشكل جيد (في معظم الأوقات)، هناك فرصة صغيرة أن تحصل على نتائج غير صحيحة عندما تستخدم المكتبة في عدة خيوط.

نوصي بشدة بعدم استخدام مثيل واحد من [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) في بيئة متعددة الخيوط لأنه قد يؤدي إلى أخطاء أو فشلات غير متوقعة ليست سهلة الاكتشاف.

ليس آمناً تحميل أو حفظ أو استنساخ مثيل من فئة [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) في عدة خيوط. مثل هذه العمليات **غير** مدعومة. إذا كنت بحاجة إلى إجراء مثل هذه المهام، عليك أن تقوم بعمليات متوازية باستخدام عدة عمليات ذات خيط واحد—ويجب على كل من هذه العمليات استخدام مثيل العرض الخاص بها.

## **تحويل شرائح العرض التقديمي إلى صور بشكل متوازي**

لنقل أننا نريد تحويل جميع الشرائح من عرض تقديمي من PowerPoint إلى صور PNG بشكل متوازي. بما أنه غير آمن استخدام مثيل واحد من `Presentation` في عدة خيوط، نقوم بتقسيم شرائح العرض التقديمي إلى عروض تقديمية منفصلة وتحويل الشرائح إلى صور بشكل متوازي، باستخدام كل عرض تقديمي في خيط منفصل. المثال البرمجي التالي يوضح كيفية القيام بذلك.

```cpp
auto inputFilePath = u"sample.pptx";
auto outputFilePathTemplate = u"slide_{0}.png";
auto imageScale = 2;

auto presentation = MakeObject<Presentation>(inputFilePath);

auto slideCount = presentation->get_Slides()->get_Count();
auto slideSize = presentation->get_SlideSize()->get_Size();

std::vector<std::future<void>> conversionTasks;

for (auto slideIndex = 0; slideIndex < slideCount; slideIndex++) {
    // استخراج الشريحة i في عرض تقديمي منفصل.
    auto slidePresentation = MakeObject<Presentation>();
    slidePresentation->get_SlideSize()->SetSize(slideSize.get_Width(), slideSize.get_Height(), SlideSizeScaleType::DoNotScale);
    slidePresentation->get_Slides()->RemoveAt(0);
    slidePresentation->get_Slides()->AddClone(presentation->get_Slide(slideIndex));

    // تحويل الشريحة إلى صورة في مهمة منفصلة.
    auto slideNumber = slideIndex + 1;
    conversionTasks.push_back(std::async(std::launch::async, [slidePresentation = std::move(slidePresentation), slideNumber, outputFilePathTemplate, imageScale]() {
        SharedPtr<IImage> image = nullptr;
        try {
            auto slide = slidePresentation->get_Slide(0);

            auto image = slide->GetImage(imageScale, imageScale);
            auto imageFilePath = String::Format(outputFilePathTemplate, slideNumber);
            image->Save(imageFilePath, ImageFormat::Png);
        }
        catch (Exception e) {
            if(image != nullptr) image->Dispose();
            slidePresentation->Dispose();
        }
    }));
}

// انتظر حتى تكتمل جميع المهام.
for (auto& task : conversionTasks) {
    task.get();
}

presentation->Dispose();
```