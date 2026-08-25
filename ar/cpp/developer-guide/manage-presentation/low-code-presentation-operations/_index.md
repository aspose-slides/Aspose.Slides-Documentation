---
title: عمليات العرض التقديمي منخفضة الكود في C++
linktitle: واجهة برمجة التطبيقات منخفضة الكود
type: docs
weight: 50
url: /ar/cpp/low-code-presentation-operations/
keywords:
- واجهة برمجة تطبيقات العرض التقديمي منخفضة الكود
- تحويل العرض التقديمي
- دمج العروض التقديمية
- التنقل عبر الشرائح
- التنقل عبر الأشكال
- التنقل عبر النص
- جمع الأشكال
- ضغط العرض التقديمي
- إزالة الشرائح الأساسية غير المستخدمة
- إزالة شرائح التخطيط غير المستخدمة
- ضغط الخطوط المضمنة
- PowerPoint
- OpenDocument
- عرض تقديمي
- C++
- Aspose.Slides
description: "استخدم واجهة برمجة التطبيقات منخفضة الكود لـ Aspose.Slides في C++ لتحويل ودمج العروض التقديمية، والتنقل عبر المحتوى، وجمع الأشكال، وتقليل حجم العرض التقديمي."
---
## **نظرة عامة**

توفر مساحة الاسم Aspose::Slides::LowCode فئات مساعدة ثابتة للعمليات الشائعة على العروض التقديمية. تُغلف هذه الفئات مسارات النموذج الكائني المتكررة في أساليب مركزة، بحيث يمكنك تحويل أو دمج الملفات، ومعالجة عناصر العرض، جمع الأشكال، وإزالة المحتوى غير المستخدم باستخدام كود أقل.

تكون الفئات المساعدة منخفضة الكود أكثر فائدة عندما ينطبق العملية على ملف أو عرض تقديمي كامل ويتطابق سير العمل الافتراضي مع متطلباتك. استخدم نموذج الكائن الكامل Aspose.Slides عندما تحتاج إلى تحكم دقيق في الشرائح الفردية، القوالب الأساسية، التخطيطات، الأشكال، إعدادات التصدير، أو العلاقات بين عناصر العرض.

الجدول التالي يلخص الفئات المساعدة المتاحة:

| المساعد | استخدامه لـ |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/ar/cpp/aspose.slides.lowcode/convert/) | تحويل عرض تقديمي إلى تنسيق آخر باستخدام استدعاء مباشر من ملف إلى ملف. |
| [Merger](https://reference.aspose.com/slides/ar/cpp/aspose.slides.lowcode/merger/) | دمج ملفات عرض تقديمية كاملة من نفس التنسيق. |
| [ForEach](https://reference.aspose.com/slides/ar/cpp/aspose.slides.lowcode/foreach/) | تنفيذ إجراء لكل شريحة أو شكل أو فقرة أو جزء نصي. |
| [Collect](https://reference.aspose.com/slides/ar/cpp/aspose.slides.lowcode/collect/) | استخراج الأشكال من العرض التقديمي بالكامل لمعالجة أو تحليل متكرر. |
| [Compress](https://reference.aspose.com/slides/ar/cpp/aspose.slides.lowcode/compress/) | إزالة القوالب الأساسية والتخطيطات غير المستخدمة وتقليل بيانات الخطوط المضمنة. |

## **تحويل عرض تقديمي**

استخدم Convert::AutoByExtension عندما يكون امتداد ملف الإخراج كافياً لتحديد تنسيق التصدير. يفتح الأسلوب العرض التقديمي المصدر، يحدد التنسيق المطلوب من مسار الإخراج، ثم يكتب النتيجة.

```cpp
#include <LowCode/Convert.h>

using namespace Aspose::Slides::LowCode;

Convert::AutoByExtension(u"input.pptx", u"output.pdf");
```

توفر فئة Convert أيضًا أساليب مخصصة لإخراج PDF وSVG وJPEG وPNG وTIFF. استخدم النموذج الكائن الكامل عندما تحتاج إلى فحص أو تعديل العرض التقديمي قبل التصدير أو تكوين خيار تصدير غير متاح في الفئة المساعدة المحددة. راجع [Convert Presentation](/slides/ar/cpp/convert-presentation/) للمسارات والخيارات الخاصة بكل تنسيق.

## **دمج العروض التقديمية**

استخدم Merger::Process لدمج ملفات عرض تقديمية كاملة باستخدام استدعاء واحد. يجب أن تكون ملفات العرض المدخلة ذات نفس تنسيق الملف.

```cpp
#include <LowCode/Merger.h>
#include <system/array.h>
#include <system/string.h>

using namespace Aspose::Slides::LowCode;

auto inputFiles = System::MakeArray<System::String>({u"part-1.pptx", u"part-2.pptx"});
Merger::Process(inputFiles, u"merged.pptx");
```

الفئة المساعدة مناسبة عندما يجب إلحاق جميع الشرائح بنتيجة واحدة دون اختيارها أو إعادة تعيينها بشكل فردي. استخدم النموذج الكائن الكامل عندما تحتاج إلى دمج شرائح مختارة، تطبيق قالب أساسي أو تخطيط وجهة، الحفاظ على الأقسام صراحةً، أو توحيد أحجام الشرائح المختلفة. راجع [Merge Presentations](/slides/ar/cpp/merge-presentation/) لتلك السيناريوهات.

## **التنقل عبر عناصر العرض التقديمي**

تستدعي فئة ForEach ردًا للنداء لكل نوع مطلوب من عناصر العرض التقديمي. إنها تتجنب الحلقات المتداخلة للمجموعات وتكون ملائمة لتفتيش أو تغييرات تنسيق على مستوى العرض بأكمله.

المثال التالي يستخدم ForEach::Slide وForEach::Shape وForEach::Paragraph وForEach::Portion لتفحص العناصر المقابلة:

```cpp
#include <DOM/BaseSlide.h>
#include <DOM/Paragraph.h>
#include <DOM/Portion.h>
#include <DOM/Presentation.h>
#include <DOM/Shape.h>
#include <DOM/Slide.h>
#include <LowCode/ForEach.h>
#include <system/console.h>
#include <system/shared_ptr.h>
#include <functional>

using namespace Aspose::Slides;
using namespace Aspose::Slides::LowCode;

auto presentation = System::MakeObject<Presentation>(u"input.pptx");

auto slideCallback = std::function<void(System::SharedPtr<Slide>, int32_t)>([](System::SharedPtr<Slide> slide, int32_t index)
{
    System::Console::WriteLine(u"Slide {0}: {1} shapes", index, slide->get_Shapes()->get_Count());
});
ForEach::Slide(presentation, slideCallback);

auto shapeCallback = std::function<void(System::SharedPtr<Shape>, System::SharedPtr<BaseSlide>, int32_t)>([](System::SharedPtr<Shape> shape, System::SharedPtr<BaseSlide> slide, int32_t index)
{
    System::Console::WriteLine(u"Shape {0}: {1}", index, shape->get_Name());
});
ForEach::Shape(presentation, shapeCallback);

auto paragraphCallback = std::function<void(System::SharedPtr<Paragraph>, System::SharedPtr<BaseSlide>, int32_t)>([](System::SharedPtr<Paragraph> paragraph, System::SharedPtr<BaseSlide> slide, int32_t index)
{
    System::Console::WriteLine(u"Paragraph {0}: {1}", index, paragraph->get_Text());
});
ForEach::Paragraph(presentation, paragraphCallback);

auto portionCallback = std::function<void(System::SharedPtr<Portion>, System::SharedPtr<Paragraph>, System::SharedPtr<BaseSlide>, int32_t)>([](System::SharedPtr<Portion> portion, System::SharedPtr<Paragraph> paragraph, System::SharedPtr<BaseSlide> slide, int32_t index)
{
    System::Console::WriteLine(u"Portion {0}: {1}", index, portion->get_Text());
});
ForEach::Portion(presentation, portionCallback);
```

بشكل افتراضي، تشمل عملية استعراض الأشكال والنص على مستوى العرض الشرائح العادية، الأساسية، وتخطيطية. النسخ التي تستقبل معلمة `includeNotes` يمكنها أيضًا معالجة شرائح الملاحظات. استخدم حلقات مجموعة مباشرة عندما تكون ترتيب الاستعراض، الخروج المبكر، التصفية قبل استدعاء رد النداء، أو التحكم التفصيلي بين الأصل والابن أمرًا مهمًا.

## **جمع الأشكال**

استخدم Collect::Shapes عندما تحتاج إلى مجموعة تحتوي على جميع الأشكال في عرض تقديمي بدلاً من رد النداء لكل شكل. يكون ذلك مفيدًا عندما سيتم تصفية المجموعة نفسها أو عدها أو معالجتها أكثر من مرة.

```cpp
#include <DOM/Presentation.h>
#include <DOM/Shape.h>
#include <LowCode/Collect.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::LowCode;

auto presentation = System::MakeObject<Presentation>(u"input.pptx");
auto shapes = Collect::Shapes(presentation);

for (const auto& shape : shapes)
{
    System::Console::WriteLine(shape->get_Name());
}
```

استخدم ForEach::Shape بدلاً من ذلك عندما يمكن معالجة كل شكل فورًا ولا تحتاج إلى الاحتفاظ بالنتيجة المجمعة.

## **ضغط محتوى العرض التقديمي**

يمكن لفئة Compress إزالة العناصر الهيكلية غير المستخدمة وتقليل بيانات الخطوط المضمنة:

- Compress::RemoveUnusedLayoutSlides يزيل شرائح التخطيط التي لا تشير إليها أي شريحة عادية.
- Compress::RemoveUnusedMasterSlides يزيل الشرائح الأساسية التي لم تعد مستخدمة.
- Compress::CompressEmbeddedFonts يزيل الأحرف غير المستخدمة من الخطوط المضمنة.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <LowCode/Compress.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::LowCode;

auto presentation = System::MakeObject<Presentation>(u"input.pptx");

Compress::RemoveUnusedLayoutSlides(presentation);
Compress::RemoveUnusedMasterSlides(presentation);
Compress::CompressEmbeddedFonts(presentation);

presentation->Save(u"compressed.pptx", SaveFormat::Pptx);
```

قم بإزالة التخطيطات غير المستخدمة قبل القوالب الأساسية غير المستخدمة بحيث يمكن أيضًا إزالة قالب أساسي يصبح غير مشار إليه بعد تنظيف التخطيطات. احفظ العرض التقديمي المُحسّن في ملف جديد إذا كنت قد تحتاج إلى القوالب الأساسية الأصلية أو التخطيطات أو بيانات الخط المضمنة الكاملة لاحقًا. للحصول على مزيد من التفاصيل، راجع [Slide Master](/slides/ar/cpp/slide-master/) و[Embedded Font](/slides/ar/cpp/embedded-font/).

## **الأسئلة الشائعة**

**متى يجب استخدام واجهة برمجة التطبيقات منخفضة الكود بدلاً من نموذج الكائن الكامل؟**

استخدم الفئات المساعدة منخفضة الكود عندما تنطبق عملية قياسية على ملف أو عرض تقديمي كامل ولا تتطلب تحكمًا مفصلاً في العناصر الفردية. استخدم نموذج الكائن الكامل عندما تحتاج إلى اختيار شرائح محددة، التحكم في علاقات القالب الأساسي والتخطيط، فحص الحالة الوسيطة، أو تكوين سلوك لا توفره الفئة المساعدة.

**هل يمكن أن يجمع Merger عروضاً تقديمية بصيغ ملفات مختلفة؟**

لا. يتطلب Merger::Process أن تكون عروض الإدخال بنفس تنسيق الملف. قم بتحويل ملفات الإدخال إلى تنسيق موحد أولاً، على سبيل المثال باستخدام Convert::AutoByExtension، ثم دمج الملفات المحوّلة.

**هل يعالج ForEach الشرائح الأساسية، التخطيطية، وملاحظات الشرائح؟**

يقوم ForEach::Slide بالتنقل عبر الشرائح العادية في العرض التقديمي. تشمل عمليات ForEach::Shape وForEach::Paragraph وForEach::Portion على مستوى العرض الشرائح العادية، الأساسية، والتخطيطية بشكل افتراضي. استخدم النسخ التي تستقبل `includeNotes` مع تعيينه إلى `true` لتضمين شرائح الملاحظات.

**ما الفرق بين ForEach::Shape وCollect::Shapes؟**

استخدم ForEach::Shape لمعالجة كل شكل فورًا عبر رد النداء. استخدم Collect::Shapes عندما تحتاج إلى نتيجة قابلة للتعداد يمكن الاحتفاظ بها، تصفيتها، عدها أو استعراضها عدة مرات.

**هل يجعل Compress الملف الأصغر دائمًا؟**

ليس بالضرورة. تعتمد النتيجة على ما إذا كان العرض يحتوي على تخطيطات غير مستخدمة، قوالب أساسية غير مستخدمة، أو خطوط مضمّنة بأحرف غير مستخدمة. إذا لم توجد أيًا من هذه العناصر، فقد لا تقلل عمليات Compress المقابلة حجم الملف.

**هل يتم حفظ التغييرات التي يجريها ForEach أو Compress تلقائيًا؟**

لا. تعمل هذه الفئات المساعدة على كائن Presentation المحمّل في الذاكرة. بعد تعديل العناصر في رد نداء ForEach أو تشغيل Compress، استدعِ Presentation::Save لكتابة النتيجة.

## **مقالات ذات صلة**

- [Convert Presentation](/slides/ar/cpp/convert-presentation/)
- [Merge Presentations](/slides/ar/cpp/merge-presentation/)
- [Slide Master](/slides/ar/cpp/slide-master/)
- [Manage Text Box](/slides/ar/cpp/manage-textbox/)
- [Embedded Font](/slides/ar/cpp/embedded-font/)