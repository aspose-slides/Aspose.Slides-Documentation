---
title: عمليات العرض منخفضة الشيفرة في C++
linktitle: API منخفضة الشيفرة
type: docs
weight: 50
url: /ar/cpp/low-code-presentation-operations/
keywords:
- API عرض منخفضة الشيفرة
- تحويل العرض
- دمج العروض
- التنقل عبر الشرائح
- التنقل عبر الأشكال
- التنقل عبر النص
- جمع الأشكال
- ضغط العرض
- إزالة القوالب غير المستخدمة
- إزالة التخطيطات غير المستخدمة
- ضغط الخطوط المضمَّنة
- PowerPoint
- OpenDocument
- عرض
- C++
- Aspose.Slides
description: "استخدم واجهة برمجة التطبيقات منخفضة الشيفرة لـ Aspose.Slides في C++ لتحويل ودمج العروض، والتنقل عبر المحتوى، وجمع الأشكال، وتقليل حجم العرض."
---
## **نظرة عامة**

توفر مساحة الأسماء [Aspose::Slides::LowCode](https://reference.aspose.com/slides/ar/cpp/aspose.slides.lowcode/) فئات مساعدة ثابتة للعمليات الشائعة على العروض التقديمية. تقوم هذه المساعدات بلف سير عمل نموذج الكائنات المتكرر في أساليب مركزة، بحيث يمكنك تحويل أو دمج الملفات، معالجة عناصر العرض، جمع الأشكال، وإزالة المحتوى غير المستخدم مع كتابة أقل من الشيفرة.

تكون المساعدات منخفضة الشيفرة مفيدة عندما ينطبق العملية على ملف أو عرض تقديمي كامل ويتطابق سير العمل الافتراضي مع متطلباتك. استخدم نموذج الكائنات الكامل لـ [Aspose.Slides object model](https://reference.aspose.com/slides/ar/cpp/aspose.slides/) عندما تحتاج إلى تحكم دقيق في الشرائح الفردية أو القوالب أو التخطيطات أو الأشكال أو إعدادات التصدير أو العلاقات بين عناصر العرض.

الجدول التالي يلخّص المساعدات المتاحة:

| المساعد | استخدامه لـ |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/ar/cpp/aspose.slides.lowcode/convert/) | تحويل عرض تقديمي إلى تنسيق آخر باستدعاء مباشر من ملف إلى ملف. |
| [Merger](https://reference.aspose.com/slides/ar/cpp/aspose.slides.lowcode/merger/) | دمج ملفات عروض تقديمية كاملة ذات نفس التنسيق. |
| [ForEach](https://reference.aspose.com/slides/ar/cpp/aspose.slides.lowcode/foreach/) | تنفيذ إجراء لكل شريحة أو شكل أو فقرة أو جزء نصي. |
| [Collect](https://reference.aspose.com/slides/ar/cpp/aspose.slides.lowcode/collect/) | استرجاع الأشكال من العرض التقديمي بالكامل للمعالجة المتكررة أو التحليل. |
| [Compress](https://reference.aspose.com/slides/ar/cpp/aspose.slides.lowcode/compress/) | إزالة القوالب والتخطيطات غير المستخدمة وتقليل بيانات الخطوط المضمنة. |

## **تحويل عرض تقديمي**

استخدم [Convert::AutoByExtension](https://reference.aspose.com/slides/ar/cpp/aspose.slides.lowcode/convert/autobyextension/) عندما تكون امتداد ملف الإخراج كافٍ لتحديد تنسيق التصدير. تفتح الطريقة العرض التقديمي المصدر، تحدد التنسيق المطلوب من مسار الإخراج، وتكتب النتيجة.

```cpp
#include <LowCode/Convert.h>

using namespace Aspose::Slides::LowCode;

Convert::AutoByExtension(u"input.pptx", u"output.pdf");
```

فئة [Convert](https://reference.aspose.com/slides/ar/cpp/aspose.slides.lowcode/convert/) توفر أيضًا أساليب مخصصة لإخراج PDF وSVG وJPEG وPNG وTIFF. استخدم نموذج الكائنات الكامل عندما تحتاج إلى فحص أو تعديل العرض قبل التصدير أو تكوين خيار تصدير غير مكشف عنه المساعد المختار. راجع [تحويل العرض](/cpp/convert-presentation/) لسير العمل والخيارات الخاصة بالتنسيق.

## **دمج العروض التقديمية**

استخدم [Merger::Process](https://reference.aspose.com/slides/ar/cpp/aspose.slides.lowcode/merger/process/) لدمج ملفات عروض تقديمية كاملة باستدعاء واحد. يجب أن تكون العروض المدخلة ذات نفس تنسيق الملف.

```cpp
#include <LowCode/Merger.h>
#include <system/array.h>
#include <system/string.h>

using namespace Aspose::Slides::LowCode;

auto inputFiles = System::MakeArray<System::String>({u"part-1.pptx", u"part-2.pptx"});
Merger::Process(inputFiles, u"merged.pptx");
```

المساعد مناسب عندما يجب إلحاق جميع الشرائح بنتيجة واحدة دون اختيار أو إعادة تعيين كل شريحة على حدة. استخدم نموذج الكائنات الكامل عندما تحتاج إلى دمج شرائح مختارة، أو تطبيق قالب أو تخطيط وجهة، أو الحفاظ على الأقسام صراحةً، أو توفيق أحجام الشرائح المختلفة. راجع [دمج العروض](/cpp/merge-presentation/) لتلك السيناريوهات.

## **التكرار عبر عناصر العرض التقديمي**

الفئة [ForEach](https://reference.aspose.com/slides/ar/cpp/aspose.slides.lowcode/foreach/) تستدعي دالة رد نداء لكل نوع مطلوب من عناصر العرض. إنها تتجنب حلقات الجمع المتداخلة وتكون ملائمة للفحص أو تغييرات التنسيق على مستوى العرض بأكمله.

المثال التالي يستخدم [ForEach::Slide](https://reference.aspose.com/slides/ar/cpp/aspose.slides.lowcode/foreach/slide/)، [ForEach::Shape](https://reference.aspose.com/slides/ar/cpp/aspose.slides.lowcode/foreach/shape/)، [ForEach::Paragraph](https://reference.aspose.com/slides/ar/cpp/aspose.slides.lowcode/foreach/paragraph/)، و[ForEach::Portion](https://reference.aspose.com/slides/ar/cpp/aspose.slides.lowcode/foreach/portion/) لفحص العناصر المقابلة:

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

بح默认، يتضمن استعراض الأشكال والنص على مستوى العرض الشرائح العادية وقوالبها وتخطيطاتها. يمكن أن تعالج الإصدارات التي تحتوي على معلمة `includeNotes` أيضًا شرائح الملاحظات. استخدم حلقات الجمع المباشرة عندما يكون ترتيب الاستعراض أو الخروج المبكر أو الترشيح قبل استدعاء رد النداء أو التحكم التفصيلي بين الأبواب والأطفال أمرًا مهمًا.

## **جمع الأشكال**

استخدم [Collect::Shapes](https://reference.aspose.com/slides/ar/cpp/aspose.slides.lowcode/collect/shapes/) عندما تحتاج إلى مجموعة بجميع الأشكال في العرض بدلاً من رد نداء لكل شكل. هذا مفيد عندما سيتم تصفية نفس المجموعة أو عدّها أو معالجتها أكثر من مرة.

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

استخدم [ForEach::Shape](https://reference.aspose.com/slides/ar/cpp/aspose.slides.lowcode/foreach/shape/) بدلاً من ذلك عندما يمكن معالجة كل شكل على الفور ولا تحتاج إلى الاحتفاظ بالنتيجة المجموعة.

## **ضغط محتوى العرض التقديمي**

الفئة [Compress](https://reference.aspose.com/slides/ar/cpp/aspose.slides.lowcode/compress/) يمكنها إزالة العناصر الهيكلية غير المستخدمة وتقليل بيانات الخطوط المضمنة:

- [Compress::RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/ar/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/) يزيل شرائح التخطيط التي لا تشير إليها أي شريحة عادية.
- [Compress::RemoveUnusedMasterSlides](https://reference.aspose.com/slides/ar/cpp/aspose.slides.lowcode/compress/removeunusedmasterslides/) يزيل القوالب التي لم تعد مستخدمة.
- [Compress::CompressEmbeddedFonts](https://reference.aspose.com/slides/ar/cpp/aspose.slides.lowcode/compress/compressembeddedfonts/) يزيل الحروف غير المستخدمة من الخطوط المضمنة.

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

قم بإزالة التخطيطات غير المستخدمة قبل القوالب غير المستخدمة حتى يمكن إزالة القالب الذي يصبح غير مُشار إليه بعد تنظيف التخطيط. احفظ العرض المحسن إلى ملف جديد إذا قد تحتاج القوالب أو التخطيطات أو بيانات الخط المضمنة كاملة لاحقًا. لمزيد من التفاصيل، راجع [Slide Master](/cpp/slide-master/) و[Embedded Font](/cpp/embedded-font/).

## **الأسئلة الشائعة**

**متى يجب عليّ استخدام API منخفض الشيفرة بدلاً من نموذج الكائنات الكامل؟**  
استخدم المساعدات منخفضة الشيفرة عندما تنطبق عملية قياسية على ملف أو عرض تقديمي كامل ولا تتطلب تحكمًا تفصيليًا في العناصر الفردية. استخدم نموذج الكائنات الكامل عندما تحتاج إلى اختيار شرائح محددة، أو التحكم في علاقات القالب والتخطيط، أو فحص الحالة الوسيطة، أو تكوين سلوك لا يكشف عنه المساعد.

**هل يمكن لـ Merger دمج عروض تقديمية بتنسيقات ملفات مختلفة؟**  
لا. يتطلب [Merger::Process](https://reference.aspose.com/slides/ar/cpp/aspose.slides.lowcode/merger/process/) أن تكون العروض المدخلة ذات نفس التنسيق. قم أولاً بتحويل الملفات المدخلة إلى تنسيق موحد، على سبيل المثال باستخدام [Convert::AutoByExtension](https://reference.aspose.com/slides/ar/cpp/aspose.slides.lowcode/convert/autobyextension/)، ثم دمج الملفات المحوّلة.

**هل يعالج ForEach القوالب والتخطيطات وشرائح الملاحظات؟**  
يستعرض [ForEach::Slide](https://reference.aspose.com/slides/ar/cpp/aspose.slides.lowcode/foreach/slide/) الشرائح العادية فقط. تشمل عمليات [ForEach::Shape](https://reference.aspose.com/slides/ar/cpp/aspose.slides.lowcode/foreach/shape/)، [ForEach::Paragraph](https://reference.aspose.com/slides/ar/cpp/aspose.slides.lowcode/foreach/paragraph/)، و[ForEach::Portion](https://reference.aspose.com/slides/ar/cpp/aspose.slides.lowcode/foreach/portion/) القوالب والتخطيطات بشكل افتراضي. استخدم الإصدارات التي تحتوي على `includeNotes` مُعَيَّن إلى `true` لتضمين شرائح الملاحظات.

**ما الفرق بين ForEach::Shape و Collect::Shapes؟**  
استخدم [ForEach::Shape](https://reference.aspose.com/slides/ar/cpp/aspose.slides.lowcode/foreach/shape/) لمعالجة كل شكل فورًا عبر رد نداء. استخدم [Collect::Shapes](https://reference.aspose.com/slides/ar/cpp/aspose.slides.lowcode/collect/shapes/) عندما تحتاج إلى نتيجة قابلة للتعداد يمكن الاحتفاظ بها، ترشيحها، عدّها أو تصفّحها عدة مرات.

**هل يجعل Compress دائمًا ملف العرض أصغر؟**  
ليس بالضرورة. يعتمد النتيجة على ما إذا كان العرض يحتوي على تخطيطات أو قوالب غير مستخدمة أو خطوط مضمنة بها حروف غير مستخدمة. إذا لم تكن أي من هذه العناصر موجودة، قد لا تقلل عمليات [Compress](https://reference.aspose.com/slides/ar/cpp/aspose.slides.lowcode/compress/) حجم الملف.

**هل تُحفظ التغييرات التي يجريها ForEach أو Compress تلقائيًا؟**  
لا. تعمل هذه المساعدات على كائن [Presentation](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/) المحمّل في الذاكرة. بعد تعديل العناصر في رد نداء [ForEach](https://reference.aspose.com/slides/ar/cpp/aspose.slides.lowcode/foreach/) أو تشغيل [Compress](https://reference.aspose.com/slides/ar/cpp/aspose.slides.lowcode/compress/)، استدعِ [Presentation::Save](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/save/) لكتابة النتيجة.

## **مقالات ذات صلة**

- [Convert Presentation](/cpp/convert-presentation/)
- [Merge Presentations](/cpp/merge-presentation/)
- [Slide Master](/cpp/slide-master/)
- [Manage Text Box](/cpp/manage-textbox/)
- [Embedded Font](/cpp/embedded-font/)