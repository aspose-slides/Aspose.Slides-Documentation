---
title: تغيير حجم صفحة الملاحظات والاتجاه في C++
linktitle: حجم صفحة الملاحظات
type: docs
weight: 10
url: /ar/cpp/notes-size/
keywords:
- حجم صفحة الملاحظات
- اتجاه الملاحظات
- ملاحظات أفقية
- ملاحظات عمودية
- حجم النشرة
- PowerPoint
- عرض تقديمي
- PPT
- PPTX
- C++
- Aspose.Slides
description: "قراءة وتغيير أبعاد صفحة الملاحظات في Aspose.Slides لـ C++، تغيير الاتجاه، التحقق من الأحجام المحفوظة، وتصدير الملاحظات أو النشرات إلى PDF وصور."
---
## **نظرة عامة**

استخدم [Presentation::get_NotesSize](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/get_notessize/) للوصول إلى إعدادات صفحة الملاحظات في العرض التقديمي. تُعيد كائنًا من نوع [INotesSize](https://reference.aspose.com/slides/ar/cpp/aspose.slides/inotessize/) يحتوي على طريقة [set_Size](https://reference.aspose.com/slides/ar/cpp/aspose.slides/inotessize/set_size/) التي تحدد الأبعاد. على الرغم من أنه لا يمكن استبدال كائن إعدادات الملاحظات، يمكنك تغيير حجمه.

يتم تحديد العرض والارتفاع بوحدات **النقاط**، بحيث يوجد 72 نقطة لكل بوصة. على سبيل المثال، 900 × 600 نقطة يساوي 12.5 × 8⅓ بوصة. تُطبق هذه الإعدادات على العرض التقديمي ككل، وليس على ملاحظات شريحة واحدة.

| الإعداد | الغرض |
| --- | --- |
| [Presentation::get_NotesSize](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/get_notessize/) | يتحكم في أبعاد صفحة الملاحظات وأبعاد الصفحة المستخدمة لتصدير النشرات. |
| [Presentation::get_SlideSize](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/get_slidesize/) | يتحكم في أبعاد شرائح العرض التقديمي العادية عبر [ISlideSize](https://reference.aspose.com/slides/ar/cpp/aspose.slides/islidesize/). |

تغيير أي من الإعدادين لا يغير الآخر تلقائيًا. تغيير اتجاه صفحة الملاحظات لا يدير الشرائح العادية أيضًا. راجع [Slide Size](/slides/ar/cpp/slide-size/) لتغيير حجم الشرائح العادية.

تستخدم الأمثلة أدناه ملف `sample.pptx` موجود مسبقًا. بالنسبة لأمثلة التصدير، استخدم عرضًا تقديميًا يحتوي على شريحة واحدة على الأقل تحتوي على ملاحظات المتحدث. يمكن تشغيل كل مثال بشكل مستقل.

## **قراءة حجم صفحة الملاحظات والاتجاه**

اقرأ العرض والارتفاع وقارنهما لتحديد الاتجاه: الصفحة الأعرض تكون أفقية، والصفحة الأطول تكون عمودية، والأبعاد المتساوية تصف صفحة مربعة. يطبع هذا المثال الأبعاد الفعلية بالنقاط، دون افتراض حجم ورق قياسي.

```cpp
#include <DOM/Presentation.h>
#include <DOM/INotesSize.h>
#include <drawing/size_f.h>
#include <system/console.h>
#include <system/smart_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto size = presentation->get_NotesSize()->get_Size();
auto orientation = String(u"Square");

if (size.get_Width() > size.get_Height())
    orientation = u"Landscape";
else if (size.get_Width() < size.get_Height())
    orientation = u"Portrait";

Console::WriteLine(u"Notes page: {0} x {1} points", size.get_Width(), size.get_Height());
Console::WriteLine(u"Orientation: {0}", orientation);
```

## **التبديل إلى أفقية دون تغيير حجم الورق**

لتغيير الاتجاه فقط، قم بتبديل العرض والارتفاع الحاليين. هذا يحافظ على أطوال الجانبين، بما في ذلك تلك الخاصة بحجم ورق مخصص. الشرط أدناه يمنع تحويل صفحة أفقية بالفعل إلى عمودية ويترك الصفحة المربعة بدون تغيير.

```cpp
#include <DOM/Presentation.h>
#include <DOM/INotesSize.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto size = presentation->get_NotesSize()->get_Size();

if (size.get_Width() < size.get_Height())
    presentation->get_NotesSize()->set_Size(SizeF(size.get_Height(), size.get_Width()));

presentation->Save(u"landscape-notes.pptx", SaveFormat::Pptx);
```

لاتجاه عمودي، استخدم نفس التعيين عندما `size.get_Width() > size.get_Height()`. لا تستبدل أبعاد A4 أو Letter ما لم ترغب أيضًا في تغيير حجم الورق.

## **تعيين والتحقق من حجم صفحة ملاحظات مخصص**

عين كلا البعدين معًا، ثم استخدم [Presentation::Save](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/save/) لكتابة العرض التقديمي. يحدد هذا المثال صفحة أفقية بحجم 900 × 600 نقطة، يحفظها كملف PPTX، ثم يفتح الملف المحفوظ مرة أخرى للتحقق من القيم المحفوظة. يسمح المقارنة بحد tolerances قدره 0.01 نقطة للقيم العشرية؛ وهذا ليس ضمانًا للدقة في كل تنسيق ملف.

```cpp
#include <DOM/Presentation.h>
#include <DOM/INotesSize.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>
#include <system/console.h>
#include <system/smart_ptr.h>
#include <cmath>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto expectedSize = SizeF(900, 600);
presentation->get_NotesSize()->set_Size(expectedSize);
presentation->Save(u"custom-notes.pptx", SaveFormat::Pptx);

auto reopened = MakeObject<Presentation>(u"custom-notes.pptx");
auto actualSize = reopened->get_NotesSize()->get_Size();
auto widthMatches = std::abs(actualSize.get_Width() - expectedSize.get_Width()) < 0.01f;
auto heightMatches = std::abs(actualSize.get_Height() - expectedSize.get_Height()) < 0.01f;
auto preserved = widthMatches && heightMatches;

Console::WriteLine(u"Stored notes page: {0} x {1} points", actualSize.get_Width(), actualSize.get_Height());
Console::WriteLine(u"Size preserved: {0}", preserved);
```

النتيجة المتوقعة هي `900 x 600 points` و `Size preserved: True`. فحص عرض تقديمي مفتوح حديثًا يتحقق من الملف المحفوظ، وليس فقط الإعدادات في الذاكرة.

## **تصدير الملاحظات والنشرات**

تحدد أبعاد الصفحة المنطقة المتاحة للملاحظات أو تخطيطات النشرات. هذه الأبعاد لا تُفعّل تلك التخطيطات بمفردها: يجب أيضًا تكوين خيارات التصدير. يظل تصدير الشرائح العادية يستخدم أبعاد الشريحة.

### **تصدير الملاحظات إلى PDF و PNG**

قم بتعيين [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/notescommentslayoutingoptions/) إلى [PdfOptions::set_SlidesLayoutOptions](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/pdfoptions/set_slideslayoutoptions/) لتضمين الملاحظات في ملف PDF. ي render هذا المثال أيضًا الشريحة الأولى مع الملاحظات إلى PNG باستخدام [Slide::GetImage](https://reference.aspose.com/slides/ar/cpp/aspose.slides/slide/getimage/) و [RenderingOptions](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/renderingoptions/).

وضع [BottomTruncated](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/notespositions/) يحافظ على الملاحظات في صفحة واحدة؛ يمكن قطع الملاحظات التي لا تتسع. يستخدم PDF صفحات بحجم 900 × 600 نقطة. عند مقياس الصورة 1 × 1 المستخدم أدناه، تكون PNG بحجم 900 × 600 بكسل. النقاط تصف هندسة الصفحة؛ البكسلات تصف الناتج النقطي، الذي تعتمد أبعاده أيضًا على مقياس العرض.

```cpp
#include <DOM/Presentation.h>
#include <DOM/INotesSize.h>
#include <DOM/ISlide.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/NotesPositions.h>
#include <Export/PdfOptions.h>
#include <Export/RenderingOptions.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <drawing/size_f.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
presentation->get_NotesSize()->set_Size(SizeF(900, 600));

auto layout = MakeObject<NotesCommentsLayoutingOptions>();
layout->set_NotesPosition(NotesPositions::BottomTruncated);

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(layout);

presentation->Save(u"notes.pdf", SaveFormat::Pdf, pdfOptions);

auto renderingOptions = MakeObject<RenderingOptions>();
renderingOptions->set_SlidesLayoutOptions(layout);

auto image = presentation->get_Slide(0)->GetImage(renderingOptions, 1.0f, 1.0f);
image->Save(u"first-slide-notes.png", ImageFormat::Png);
image->Dispose();
```

لتصدير PDF مع ملاحظات طويلة، يسمح [BottomFull](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/notespositions/) بصفحات إضافية حسب الحاجة. لا تستخدم هذا الوضع مع نداء صورة شريحة واحدة أعلاه، لأنه لا يدعمه. بعد تغيير الحجم، تحقق من المخرجات للبحث عن ملاحظات مقصوصة وموقع كائنات notes-master الموجودة؛ لا ينبغي اعتبار تغيير أبعاد الصفحة وحده ضمانًا لتناسب كل المحتوى. راجع [Convert PowerPoint to PDF with Notes](/slides/ar/cpp/convert-powerpoint-to-pdf-with-notes/) لمزيد من المعلومات حول تصدير الملاحظات.

### **تصدير النشرات إلى PDF**

استخدم [HandoutLayoutingOptions](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/handoutlayoutingoptions/) لعرض عدة مصغرات شرائح على صفحة واحدة. يحدد المثال التالي صفحة بحجم 900 × 600 نقطة ويستخدم [HandoutType::Handouts4Horizontal](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/handouttype/) لترتيب ما يصل إلى أربع شرائح لكل صفحة. يحدد الإعداد الأفقي ترتيب الشرائح؛ ويأتي اتجاه الصفحة من عرضه وارتفاعه.

```cpp
#include <DOM/Presentation.h>
#include <DOM/INotesSize.h>
#include <Export/HandoutLayoutingOptions.h>
#include <Export/HandoutType.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
presentation->get_NotesSize()->set_Size(SizeF(900, 600));

auto layout = MakeObject<HandoutLayoutingOptions>();
layout->set_Handout(HandoutType::Handouts4Horizontal);

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(layout);

presentation->Save(u"handouts.pdf", SaveFormat::Pdf, pdfOptions);
```

تغيير حجم الصفحة يغيّر المنطقة المتاحة لشبكة النشرات دون تغيير أبعاد الشرائح المصدرية. للحصول على صور النشرات، استخدم [Presentation::GetImages](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/getimages/) مع تخطيط النشرة، بدلاً من طريقة صورة شريحة فردية. في Aspose.Slides، يستخدم تصيير النشرات على مستوى العرض التقديمي أبعاد صفحة الملاحظات، بينما نداء صورة شريحة فردية لا ينتج صفحة النشرة. راجع [Handout Mode](/slides/ar/cpp/convert-powerpoint-in-handout-mode/) لخيارات التخطيط.

## **حجم الصفحة في العارضات، والتصدير، والطباعة**

احتفظ بأحجام العرض التقديمي المخزّن، وحجم الصفحة المصدّر، وحجم الورق المطبوع بشكل منفصل:

- **عارضات العروض التقديمية:** يمكن للعارض عرض أو طباعة الملاحظات باستخدام قواعد التخطيط الخاصة به. إذا حفظ تطبيق آخر الملف، أعد فتحه وتحقق من الأبعاد مرة أخرى؛ قد تقوم عملية تحويل صيغ ذلك التطبيق بتطبيعها.
- **تنسيقات التصدير:** تستخدم أمثلة PDF للملاحظات والنشرات أعلاه أبعاد الصفحة المكوّنة. تستخدم الصور النقطية أبعاد بكسل صحيحة ومقياس عرض، لذا قد تُقرب القيم العشرية للنقاط في ناتج الصورة. لا يطبق تصدير الشرائح العادية حجم صفحة الملاحظات.
- **سواقات الطباعة:** يمكن لاختيار الورق، والدوران التلقائي، وإعدادات الملائمة للصفحة أن تغير النتيجة الفعلية دون تعديل الأبعاد المخزّنة في العرض التقديمي أو ملف PDF. للحصول على حجم ورق محدد، طابق إعدادات الطابعة وتحقق من معاينة الطباعة.

## **الأسئلة الشائعة**

**هل يمكنني ضبط حجم الملاحظات لشريحة واحدة فقط؟**

حجم صفحة الملاحظات هو إعداد على مستوى العرض التقديمي. يمكن للشرائح الفردية أن تحتوي على محتوى ملاحظات مختلف، لكن هذه الخاصية لا توفر حجم صفحة منفصل لكل شريحة.

**لماذا لم يغيّر تغيير اتجاه الملاحظات شرائحي؟**

صفحات الملاحظات والشرائح العادية لها أبعاد مستقلة. استخدم إعدادات حجم الشريحة العادية عندما تريد تغيير حجم الشرائح نفسها.

**لماذا يكون للنتيجة المحفوظة أو المطبوعة حجم مختلف؟**

أولاً أعد فتح العرض التقديمي المحفوظ وقارن أبعاد الملاحظات. إذا تغيرت، تحقق مما إذا كان حفظ أو تحويل الملف في تطبيق آخر قد غيّر إعدادات الصفحة. إذا لم يحدث ذلك، تحقق من تخطيط التصدير، مقياس الصورة، إعدادات العارض، واختيار ورق الطابعة.