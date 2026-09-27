---
title: إنشاء عروض تقديمية في C++
linktitle: إنشاء عرض تقديمي
type: docs
weight: 10
url: /ar/cpp/create-presentation/
keywords:
- إنشاء عرض تقديمي
- عرض تقديمي جديد
- إنشاء PPT
- PPT جديد
- إنشاء PPTX
- PPTX جديد
- إنشاء ODP
- ODP جديد
- PowerPoint
- OpenDocument
- عرض تقديمي
- C++
- Aspose.Slides
description: "إنشاء عروض تقديمية في C++ باستخدام Aspose.Slides—إنشاء ملفات PPT و PPTX و ODP، والاستفادة من دعم OpenDocument، وحفظها برمجياً للحصول على نتائج موثوقة."
---
## **نظرة عامة**

هذه المقالة توضح كيفية إنشاء عرض تقديمي باستخدام Aspose.Slides، وإضافة صندوق نص إلى الشريحة الأولى، وحفظ النتيجة كملف. تتضمن أسئلة شائعة قصيرة في النهاية تغطي الأسئلة المتكررة حول الصيغ، القوالب، حجم الشريحة، الوحدات، استهلاك الذاكرة، الخيوط، الترخيص، التوقيعات الرقمية، ودعم VBA.

قبل البدء، أضف Aspose.Slides إلى مشروعك: من NuGet في مشروع Visual Studio على نظام Windows، أو من حزمة ZIP مع CMake على Linux. راجع [التثبيت](/slides/ar/cpp/installation/).

## **إنشاء عرض تقديمي PowerPoint**

لإنشاء عرض تقديمي ووضع صندوق نص على الشريحة الأولى، اتبع الخطوات التالية:

1. إنشئ مثيلًا لفئة [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/). يحتوي العرض التقديمي الجديد على شريحة فارغة واحدة.
2. احصل على تلك الشريحة باستخدام الطريقة [Presentation::get_Slide](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_slide/) ومؤشرها 0.
3. أضف مستطيلًا باستخدام الطريقة [IShapeCollection::AddAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addautoshape/)، وقم بتعيين نصه باستخدام الطريقة [ITextFrame::set_Text](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/set_text/).
4. احفظ العرض التقديمي كملف PPTX باستخدام الطريقة [Presentation::Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/).

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/ITextFrame.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

int main()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);
    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 400, 100);
    shape->get_TextFrame()->set_Text(u"Hello, Aspose.Slides!");
    presentation->Save(u"hello.pptx", SaveFormat::Pptx);
    presentation->Dispose();
    return 0;
}
```

زاوية المستطيل العلوية اليسرى يبعد 50 نقطة عن الحافة اليسرى و50 نقطة عن الحافة العلوية للشريحة، وعرض المستطيل 400 نقطة وارتفاعه 100 نقطة. يحفظ البرنامج الملف *hello.pptx* في دليل العمل الخاص به، مع شريحة واحدة تحتوي على المستطيل ونصه. بدون ترخيص، تضيف Aspose.Slides أيضًا علامة مائية تقييم إلى كل شريحة يتم حفظها؛ راجع [الترخيص](/slides/ar/cpp/licensing/).

## **الأسئلة الشائعة**

### ما الصيغ التي يمكنني حفظ عرض تقديمي جديد بها؟

يمكنك الحفظ إلى [PPTX, PPT, و ODP](/slides/ar/cpp/save-presentation/)، وتصدير إلى [PDF](/slides/ar/cpp/convert-powerpoint-to-pdf/)، [XPS](/slides/ar/cpp/convert-powerpoint-to-xps/), [HTML](/slides/ar/cpp/convert-powerpoint-to-html/), [SVG](/slides/ar/cpp/render-a-slide-as-an-svg-image/), و[images](/slides/ar/cpp/convert-powerpoint-to-png/)، وغيرها.

### هل يمكنني البدء من قالب (POTX/POTM) وحفظه كـ PPTX عادي؟

نعم. حمّل القالب واحفظه بالتنسيق المطلوب؛ الصيغ مثل POTX/POTM/PPTM وغيرها [مُدعَمة](/slides/ar/cpp/supported-file-formats/).

### كيف يمكنني التحكم في حجم الشريحة/نسبة الأبعاد عند إنشاء عرض تقديمي؟

قم بتعيين [حجم الشريحة](/slides/ar/cpp/slide-size/) (بما في ذلك القوالب المسبقة مثل 4:3 و16:9 أو الأبعاد المخصصة) واختر كيفية تحجيم المحتوى.

### بأيه الوحدات يتم قياس الأحجام والإحداثيات؟

بالنقاط: 1 بوصة تساوي 72 وحدة.

### كيف أتعامل مع عروض تقديمية كبيرة جدًا (مع الكثير من ملفات الوسائط) لتقليل استخدام الذاكرة؟

استخدم [استراتيجيات إدارة BLOB](/slides/ar/cpp/manage-blob/)، وحدّ من التخزين في الذاكرة عن طريق الاستفادة من الملفات المؤقتة، وفضّل سير العمل القائم على الملفات بدلاً من التدفقات داخل الذاكرة فقط.

### هل يمكنني إنشاء/حفظ العروض التقديمية بشكل متوازي؟

لا يمكنك العمل على نفس [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) من [عدة خيوط](/slides/ar/cpp/multithreading/). شغّل مثيلات منفصلة ومعزولة لكل خيط أو عملية.

### كيف يمكنني إزالة علامة المائية التجريبية والقيود؟

[تطبيق ترخيص](/slides/ar/cpp/licensing/) مرة واحدة لكل عملية. يجب أن يبقى ملف XML الخاص بالترخيص غير معدل، ويجب مزامنة إعداد الترخيص إذا كانت هناك عدة خيوط مشاركة.

### هل يمكنني توقيع PPTX الذي أنشأته رقميًا؟

نعم. [التوقيعات الرقمية](/slides/ar/cpp/digital-signature-in-powerpoint/) (الإضافة والتحقق) مدعومة للعروض التقديمية.

### هل يتم دعم الماكروز (VBA) في العروض التي تم إنشاؤها؟

نعم. يمكنك [إنشاء/تحرير مشاريع VBA](/slides/ar/cpp/presentation-via-vba/) وحفظ ملفات تمكين الماكرو مثل PPTM/PPSM.