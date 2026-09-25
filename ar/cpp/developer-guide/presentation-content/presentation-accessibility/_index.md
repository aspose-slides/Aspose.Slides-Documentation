---
title: إدارة إمكانية وصول العرض التقديمي في C++
linktitle: إمكانية وصول العرض التقديمي
type: docs
weight: 30
url: /ar/cpp/presentation-accessibility/
keywords:
- إمكانية وصول العرض التقديمي
- نص بديل
- عنوان النص البديل
- وصف النص البديل
- وضع علامة كزخرفة
- PowerPoint
- OpenDocument
- عرض تقديمي
- C++
- Aspose.Slides
description: "أتمتة فحوصات إمكانية وصول العرض التقديمي في ملفات PPT و PPTX و ODP باستخدام Aspose.Slides for C++ — تحسين تجربة قارئ الشاشة وتعزيز الامتثال."
---
## **مقدمة**

يساعد النص البديل الأشخاص الذين يستخدمون تقنيات المساعدة على فهم معنى الصور والمخططات وغيرها من الأشكال المعلوماتية. يوضح هذا المقال كيفية قراءة وتحديث عناوين النص البديل ووصفه باستخدام Aspose.Slides for C++، والتمييز بين أوصاف إمكانية الوصول وأسماء الأشكال المستخدمة في الكود، والتحقق مما إذا كانت الشكل م marked كزخرفة.

تدعم هذه الميزات إمكانية الوصول إلى العرض التقديمي، ولكن لا تضمن ذلك. يجب أيضاً مراجعة ترتيب القراءة، وتباين اللون، وقابلية قراءة النص، ومتطلبات إمكانية الوصول الأخرى.

## **إدارة عناوين النص البديل والوصف**

استخدم النص البديل لشرح معنى الصور والمخططات وغيرها من الأشكال المعلوماتية للأشخاص الذين لا يستطيعون رؤيتها. الخدمات التالية تخدم أغراضًا مختلفة:

| الخاصية أو المحتوى | الغرض |
| --- | --- |
| [AlternativeTextTitle](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ishape/get_alternativetexttitle/) | عنوان قصير للوصف البديل. |
| [AlternativeText](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ishape/get_alternativetext/) | وصف ذو معنى لمحتوى الشكل أو الغرض منه في سياق الشريحة. |
| [Name](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ishape/get_name/) | اسم الشكل الذي يمكن للكود استخدامه للعثور على شكل معين في العرض التقديمي. |
| النص الظاهر | المحتوى المعروض على الشريحة، مثل نص الشكل أو عنوان المخطط والتسميات. تحديث النص البديل لا يغيّر هذا المحتوى. |

عند إعادة استخدام عرض تقديمي كقالب، قد يجد الكود شكلًا بواسطة [Name](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ishape/get_name/) قبل تحديثه. هذا الاسم يخدم غرضًا مختلفًا عن النص البديل، الذي يشرح ما ينقله العنصر البصري للقارئ. يتيح البحث بالاسم للمؤلفين تحسين أو ترجمة الأوصاف دون تغيير طريقة العثور على الشكل في الكود. يمكن تعديل الأسماء ولا يُضمن أن تكون فريدة، لذا تحقق من أن الاسم يطابق الشكل المقصود؛ راجع [Identify and Find Shapes](/slides/ar/cpp/shape-manipulations/#identify-and-find-shapes).

المثال التالي يتطلّب وجود `input.pptx` يحتوي على صورة لمدخل مكتب كأول شكل في الشريحة الأولى. يجب ألا تكون الصورة محددة كزخرفة. يقرأ المثال ويطبع عنوان النص البديل الحالي ووصفه، ثم يحدّث القيمتين ويحفظ العرض التقديمي باسم `output.pptx`. عدّل النص ليتناسب مع الصورة الفعلية والمعلومات التي تنقلها.

```cpp
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

Console::WriteLine(u"Alternative text title: {0}", shape->get_AlternativeTextTitle());
Console::WriteLine(u"Alternative text description: {0}", shape->get_AlternativeText());

shape->set_AlternativeTextTitle(u"Office entrance");
shape->set_AlternativeText(u"The office entrance has a wheelchair ramp to the right of the steps.");

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

إضافة النص البديل وحدها لا تضمن إمكانية وصول العرض التقديمي أو الامتثال لمعايير إمكانية الوصول. راجع الأوصاف لضمان الدقة والملاءمة، وتحقق أيضًا من ترتيب القراءة، وتباين اللون، والنص القابل للقراءة، والمتطلبات الأخرى. لا ينبغي وضع علامة الزخرفة على العناصر البصرية المعلوماتية؛ القسم التالي يوضح كيفية قراءة [IsDecorative](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ishape/get_isdecorative/).

## **وضع علامة كزخرفة**

تضع علامة "كزخرفة" العناصر البصرية الزينة فقط لتتخطّى قرّاءات القارئ screen readers، ما يقلل الضوضاء ويحافظ على التركيز على المحتوى المعنى. يُطبق ذلك على الخلفيات والزخارف والفواصل—ولا يُطبق أبدًا على المخططات أو الأيقونات أو الصور التي تنقل معلومات. تُظهر Aspose.Slides هذه العلامة للكشف والتحقق، مما يتيح فحص إمكانية الوصول الآلي والتنظيف.

![علامة كزخرفة](mark_as_decorative.png)

يعرض الكود التالي كيفية تحديد ما إذا كان الشكل محددًا كزخرفة.

```cpp
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

auto shape = presentation->get_Slide(0)->get_Shape(0);
Console::WriteLine(u"Is shape decorative: {0}", shape->get_IsDecorative());

presentation->Dispose();
```

## **الأسئلة الشائعة**

**ماذا يجب أن أضع في عنوان النص البديل والوصف؟**

استخدم عنوانًا قصيرًا لتحديد الموضوع ووصفًا لشرح المعلومات التي ينقلها العنصر البصري في سياق الشريحة. بالنسبة لمخطط، صف الاتجاه أو المقارنة ذات الصلة بدلاً من الاكتفاء بقول "مخطط".

**هل يجب استخدام النص البديل لتحديد موقع الأشكال في القالب؟**

يفضل العثور على الشكل عبر [Name](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ishape/get_name/) والتحقق من أنه الشكل المتوقع. قد يُعدل أو يُترجم النص البديل، ما قد يكسّر الكود الذي يبحث عن وصف دقيق؛ راجع [Identify and Find Shapes](/slides/ar/cpp/shape-manipulations/).

**متى يجب وضع علامة كزخرفة على الشكل؟**

استخدم علم الزخرفة للرسومات التي لا تضيف معلومات، مثل الزخارف الزينة. الصور والمخططات التي تنقل معنى تحتاج إلى وصف مناسب بدلاً من ذلك.

**هل يجعل إضافة النص البديل العرض التقديمي م accessible بالكامل؟**

لا. يعالج النص البديل جزءًا فقط من إمكانية الوصول. راجع أيضًا ترتيب القراءة، وتباين اللون، وقابلية قراءة النص، والمتطلبات الأخرى ذات الصلة؛ ضبط هذه الخصائص وحده لا يحقق الامتثال.