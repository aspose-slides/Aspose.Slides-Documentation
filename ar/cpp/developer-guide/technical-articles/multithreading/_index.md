---
title: "العمل المتوازي في Aspose.Slides للغة C++"
linktitle: "تعدد الخيوط"
type: docs
weight: 200
url: /ar/cpp/multithreading/
keywords:
- تعدد الخيوط
- خيوط متعددة
- عمل متوازي
- تحويل الشرائح
- الشرائح إلى صور
- PowerPoint
- OpenDocument
- عرض تقديمي
- C++
- Aspose.Slides
description: "يعزز عمل تعدد الخيوط في Aspose.Slides للغة C++ معالجة PowerPoint وOpenDocument. اكتشف أفضل الممارسات لتدفقات عمل العرض التقديمي الفعّالة."
---

## **المقدمة**

بينما يمكن إجراء عمل متوازي مع العروض التقديمية (إلى جانب التحليل/التحميل/الاستنساخ) وعادةً ما يسير كل شيء على ما يرام (معظم الأوقات)، هناك احتمال صغير أن تحصل على نتائج غير صحيحة عند استخدام المكتبة في عدة خيوط.

نوصي بشدة بعدم استخدام نسخة واحدة من فئة [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) في بيئة متعددة الخيوط لأنها قد تؤدي إلى أخطاء أو فشل غير متوقع يصعب اكتشافه.

ليس من الآمن تحميل أو حفظ أو/و استنساخ نسخة من فئة [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) في عدة خيوط. مثل هذه العمليات غير مدعومة. إذا كنت بحاجة إلى تنفيذ هذه المهام، عليك إجراءها بشكل متوازي باستخدام عدة عمليات أحادية الخيط—ويجب أن تستخدم كل عملية نسخة خاصة بها من العرض التقديمي.

## **تحويل شرائح العرض التقديمي إلى صور بشكل متوازي**

لنفترض أننا نريد تحويل جميع الشرائح من عرض PowerPoint إلى صور PNG بشكل متوازي. نظرًا لعدم أمان استخدام نسخة واحدة من `Presentation` في عدة خيوط، نقسم شرائح العرض إلى عروض تقديمية منفصلة ونحول الشرائح إلى صور بشكل متوازي، مع استخدام كل عرض تقديمي في خيط منفصل. يوضح المثال التالي كيفية القيام بذلك.
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

// انتظر اكتمال جميع المهام.
for (auto& task : conversionTasks) {
    task.get();
}

presentation->Dispose();
```


## **الأسئلة الشائعة**

**هل أحتاج إلى استدعاء إعداد الترخيص في كل خيط؟**

لا. يكفي تنفيذ ذلك مرة واحدة لكل عملية/نطاق تطبيق قبل بدء الخيوط. إذا كان من الممكن استدعاء [license setup](/slides/ar/cpp/licensing/) بشكل متزامن (مثلاً أثناء التهيئة المتأخرة)، فقم بمزامنة هذا الاستدعاء لأن طريقة إعداد الترخيص نفسها ليست آمنة للخيوط.

**هل يمكنني تمرير كائنات `Presentation` أو `Slide` بين الخيوط؟**

تمرير كائنات العرض التقديمي “الحية” بين الخيوط غير موصى به: استخدم نسخ مستقلة لكل خيط أو أنشئ عروض تقديمية/حاويات شرائح منفصلة مسبقًا لكل خيط. يتماشى هذا النهج مع التوصية العامة بعدم مشاركة نسخة عرض تقديمي واحدة عبر الخيوط.

**هل من الآمن إجراء تصدير متوازي إلى صيغ مختلفة (PDF، HTML، صور) بشرط أن يكون لكل خيط نسخة `Presentation` خاصة به؟**

نعم. مع وجود نسخ مستقلة ومسارات إخراج منفصلة، عادةً ما يتم تنفيذ هذه المهام بشكل متوازي بصورة صحيحة؛ تجنب أي كائنات عرض تقديمي مشتركة أو تدفقات I/O مشتركة.

**ماذا يجب أن أفعل بخصوص إعدادات الخطوط العامة (المجلدات، البدائل) في بيئة متعددة الخيوط؟**

قم بتهيئة جميع إعدادات الخطوط العامة قبل بدء الخيوط ولا تغيرها أثناء العمل المتوازي. هذا يلغي حدوث تنافس عند الوصول إلى موارد الخطوط المشتركة.