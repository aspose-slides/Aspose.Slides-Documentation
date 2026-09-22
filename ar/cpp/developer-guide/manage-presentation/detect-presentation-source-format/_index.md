---
title: تحديد تنسيق العرض التقديمي الأصلي في C++
linktitle: تنسيق المصدر
type: docs
weight: 35
url: /ar/cpp/detect-presentation-source-format/
keywords:
- تنسيق المصدر
- كشف تنسيق العرض التقديمي
- PowerPoint
- OpenDocument
- عرض تقديمي
- PPT
- PPTX
- C++
- Aspose.Slides
description: "قراءة التنسيق الأصلي للعرض التقديمي المحمَّل في C++ باستخدام Aspose.Slides for C++، ومقارنة واجهات برمجة التطبيقات الخاصة بالكشف، ومعالجة الملفات، والتدفقات، وتنسيقات الإصدارات القديمة."
---
## **نظرة عامة**

بعد تحميل عرض تقديمي، استدعِ [Presentation::get_SourceFormat](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/get_sourceformat/) لتحديد تنسيقه الأصلي. الطريقة متاحة أيضًا عبر [IPresentation::get_SourceFormat](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ipresentation/get_sourceformat/). استخدمها عندما يعتمد المعالجة اللاحقة على التنسيق الذي تم تحميل النسخة الحالية منه.

تنسيق المصدر مختلف عن [SaveFormat](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/saveformat/) المختار لملف الإخراج. حفظ الملف بتنسيق آخر لا يغيّر تنسيق المصدر للنسخة الحالية.

## **قراءة تنسيق المصدر لملف**

يتطلب هذا المثال وجود ملف `sample.pptx` موجود. يقوم بتحميل الملف ويختار سياسة معالجة التطبيق باستخدام [Presentation::get_SourceFormat](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/get_sourceformat/)، بدلاً من اسم الملف. غيّر مسار الإدخال لتجربة تنسيقات أخرى. يطبع المثال السياسة المختارة؛ استبدل الرسائل بمنطق تطبيقك.

```cpp
#include <DOM/Presentation.h>
#include <DOM/SourceFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

switch (presentation->get_SourceFormat())
{
    case SourceFormat::Ppt:
    case SourceFormat::Pps:
    case SourceFormat::Pot:
        Console::WriteLine(u"Use the legacy PowerPoint processing policy.");
        break;
    case SourceFormat::Pptx:
        Console::WriteLine(u"Use the standard PPTX processing policy.");
        break;
    default:
        Console::WriteLine(String::Format(u"Use the general policy for {0}.", ObjectExt::ToString(presentation->get_SourceFormat())));
        break;
}
```

## **التعرف على القيم المدعومة**

تعددية [SourceFormat](https://reference.aspose.com/slides/ar/cpp/aspose.slides/sourceformat/) تميز التنسيقات التالية للعروض التقديمية. الامتدادات أدناه هي امتدادات شائعة، ليست إعادة بناء لاسم الملف الأصلي.

| قيمة SourceFormat | الامتداد | التنسيق |
| --- | --- | --- |
| `Ppt` | `.ppt` | عرض تقديمي PowerPoint 97–2003 |
| `Pptx` | `.pptx` | عرض تقديمي Office Open XML |
| `Pptm` | `.pptm` | عرض تقديمي Office Open XML مع تمكين الماكرو |
| `Pps` | `.pps` | عرض شرائح PowerPoint 97–2003 |
| `Ppsx` | `.ppsx` | عرض شرائح Office Open XML |
| `Ppsm` | `.ppsm` | عرض شرائح Office Open XML مع تمكين الماكرو |
| `Pot` | `.pot` | قالب PowerPoint 97–2003 |
| `Potx` | `.potx` | قالب Office Open XML |
| `Potm` | `.potm` | قالب Office Open XML مع تمكين الماكرو |
| `Odp` | `.odp` | عرض تقديمي OpenDocument |
| `Otp` | `.otp` | قالب عرض تقديمي OpenDocument |
| `Fodp` | `.fodp` | عرض تقديمي Flat XML ODF |
| `Xml` | `.xml` | عرض تقديمي PowerPoint XML |

## **قراءة تنسيق المصدر لتدفق**

يتطلب هذا المثال وجود ملف `sample.pps` موجود. قراءة بايتاته إلى تدفق ذاكرة يحاكي إدخالًا استُلم بدون اسم ملف، مثل قيمة في قاعدة بيانات أو مصفوفة بايتات مرفوعة. يُستقبل مُنشئ [Presentation](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/) التدفق فقط.

```cpp
#include <DOM/Presentation.h>
#include <DOM/SourceFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>
#include <system/io/file.h>
#include <system/io/memory_stream.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto bytes = File::ReadAllBytes(u"sample.pps");
auto stream = MakeObject<MemoryStream>(bytes);
auto presentation = MakeObject<Presentation>(stream);

Console::WriteLine(String::Format(u"Source format: {0}", ObjectExt::ToString(presentation->get_SourceFormat())));
```

تستخدم PPT و PPS و POT نفس التنسيق الثنائي الأساسي. عند التحميل عبر مسار ملف، يمكن للامتداد أن يساعد في تمييز عرض الشرائح أو القالب. بدون اسم ملف، قد يُبلّغ محتوى PPS أو POT القديم كـ `SourceFormat::Ppt`؛ المثال السابق للـ PPS يُظهر `Ppt`.

إذا كان تطبيقك بحاجة للحفاظ على التمييز، احتفظ باسم الملف الأصلي أو ببيانات التعريف الفرعية منفصلًا. يُعد الامتداد تلميحًا مفيدًا لهذه الأنواع الفرعية القديمة، لكنه لا ينبغي أن يكون الأساس الوحيد لتحديد محتوى عرض تقديمي عشوائي.

## **مقارنة الكشف قبل وبعد التحميل**

استخدم [PresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentationfactory/getpresentationinfo/) و [IPresentationInfo::get_LoadFormat](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ipresentationinfo/get_loadformat/) عندما تحتاج إلى فحص ملف قبل تحميل نموذج كائن العرض التقديمي بالكامل. استخدم [Presentation::get_SourceFormat](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/get_sourceformat/) عندما تكون النسخة موجودة بالفعل.

يتطلب هذا المثال وجود `sample.pptx` ويطبع `Pptx` لكلا الفحصين. في الإنتاج، اختر واجهة برمجة التطبيقات المناسبة لمرحلة المعالجة؛ العرض التقديمي المحمّل لا يحتاج إلى فحص ثانٍ فقط للحصول على تنسيق المصدر.

```cpp
#include <DOM/Presentation.h>
#include <DOM/SourceFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>
#include <DOM/PresentationFactory.h>
#include <DOM/IPresentationInfo.h>
#include <LoadFormat.h>

using namespace Aspose::Slides;
using namespace System;

auto path = String(u"sample.pptx");
auto information = PresentationFactory::get_Instance()->GetPresentationInfo(path);
Console::WriteLine(String::Format(u"Before loading: {0}", ObjectExt::ToString(information->get_LoadFormat())));

auto presentation = MakeObject<Presentation>(path);
Console::WriteLine(String::Format(u"After loading: {0}", ObjectExt::ToString(presentation->get_SourceFormat())));
```

النتائج لها أنواع تعددية مختلفة: [LoadFormat](https://reference.aspose.com/slides/ar/cpp/aspose.slides/loadformat/) و [SourceFormat](https://reference.aspose.com/slides/ar/cpp/aspose.slides/sourceformat/). لا تقارنها بتحويل القيم الرقمية أو افتراض أن كل تنسيق له نتائج كشف متطابقة. قد يُبلّغ PowerPoint XML كـ `LoadFormat::Unknown` قبل التحميل و`SourceFormat::Xml` بعد التحميل.

## **الحفاظ على تنسيقات المصدر والإخراج منفصلة**

يتطلب هذا المثال وجود `sample.pptx` ويكتب `converted.odp`. يطبع `Pptx` قبل وبعد حفظ النسخة الأصلية. فقط النسخة الجديدة المحمّلة من إخراج ODP تُظهر `Odp`.

```cpp
#include <DOM/Presentation.h>
#include <DOM/SourceFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace System;
using namespace Aspose::Slides::Export;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
Console::WriteLine(String::Format(u"Before saving: {0}", ObjectExt::ToString(presentation->get_SourceFormat())));

presentation->Save(u"converted.odp", SaveFormat::Odp);
Console::WriteLine(String::Format(u"After saving: {0}", ObjectExt::ToString(presentation->get_SourceFormat())));

auto reopened = MakeObject<Presentation>(u"converted.odp");
Console::WriteLine(String::Format(u"Reopened output: {0}", ObjectExt::ToString(reopened->get_SourceFormat())));
```

العرض التقديمي المُنشأ من الصفر بـ `MakeObject<Presentation>()` يُبلغ عن `SourceFormat::Pptx`. لا يمتلك ملف إدخال: هذه هي القيمة الافتراضية لنسخة تم إنشاؤها حديثًا، وليس دليلًا على تحميل ملف PPTX. تتبع ما إذا كان تطبيقك قد أنشأ أو حمّل النسخة بشكل منفصل إذا كان هذا التفريق مهمًا.

## **تحويل تنسيق المصدر إلى امتداد**

يتطلب المثال التالي وجود `sample.pptx`. يطابق كل قيمة [SourceFormat](https://reference.aspose.com/slides/ar/cpp/aspose.slides/sourceformat/) مدعومة حاليًا بامتداد شائع، بدون تحليل اسم الملف المدخل. يُجنب التراجع إسناد امتداد صامت لقيمة غير معروفة.

```cpp
#include <DOM/Presentation.h>
#include <DOM/SourceFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto extension = String::Empty;
switch (presentation->get_SourceFormat())
{
    case SourceFormat::Ppt:
        extension = u".ppt";
        break;
    case SourceFormat::Pptx:
        extension = u".pptx";
        break;
    case SourceFormat::Pptm:
        extension = u".pptm";
        break;
    case SourceFormat::Pps:
        extension = u".pps";
        break;
    case SourceFormat::Ppsx:
        extension = u".ppsx";
        break;
    case SourceFormat::Ppsm:
        extension = u".ppsm";
        break;
    case SourceFormat::Pot:
        extension = u".pot";
        break;
    case SourceFormat::Potx:
        extension = u".potx";
        break;
    case SourceFormat::Potm:
        extension = u".potm";
        break;
    case SourceFormat::Odp:
        extension = u".odp";
        break;
    case SourceFormat::Otp:
        extension = u".otp";
        break;
    case SourceFormat::Fodp:
        extension = u".fodp";
        break;
    case SourceFormat::Xml:
        extension = u".xml";
        break;
    default:
        break;
}

Console::WriteLine(extension.IsEmpty() ? u"No extension mapping is available." : extension);
```

هذا التطابق لا يُحوِّل ملفًا ولا يُستعيد نوع PPS/POT فرعي مفقود أثناء تحميل التدفق. للحفظ الفعلي، حدّد [SaveFormat](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/saveformat/) صراحةً، أو استخدم التحويل الموضح في [Save Presentations in Their Original Format](/slides/ar/cpp/save-presentation/#save-presentations-in-their-original-format).

## **التحقق من التنسيقات عبر الحفظ وإعادة الفتح**

هذا المثال المستقل يُنشئ عرضًا تقديميًا ويكتب ثلاثة ملفات في دليل العمل، مستبدلاً الملفات التي تحمل نفس الأسماء. يعيد فتح كل مخرج إما عبر المسار أو عبر تدفق ذاكرة. بالنسبة إلى PPTX و ODP، كلا المسارين يُبلّغان عن التنسيق المحفوظ. بالنسبة إلى PPS، يُظهر التحميل عبر المسار `Pps`، بينما يُظهر تحميل نفس البايتات بدون اسم ملف `Ppt`.

```cpp
#include <DOM/Presentation.h>
#include <DOM/SourceFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/io/file.h>
#include <system/io/memory_stream.h>

using namespace Aspose::Slides;
using namespace System;
using namespace Aspose::Slides::Export;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto formats = MakeArray<SaveFormat>({SaveFormat::Pptx, SaveFormat::Odp, SaveFormat::Pps});

for (auto format : formats)
{
    auto formatName = ObjectExt::ToString(format);
    auto path = String::Format(u"roundtrip.{0}", formatName.ToLowerInvariant());
    presentation->Save(path, format);

    auto fromFile = MakeObject<Presentation>(path);
    auto bytes = File::ReadAllBytes(path);
    auto stream = MakeObject<MemoryStream>(bytes);
    auto fromStream = MakeObject<Presentation>(stream);

    Console::WriteLine(String::Format(u"{0}: file={1}, stream={2}", formatName, ObjectExt::ToString(fromFile->get_SourceFormat()), ObjectExt::ToString(fromStream->get_SourceFormat())));
}
```

الجدول التالي يلخّص تعريف تنسيق المصدر للعروض التي لها امتدادات مطابقة:

| التنسيق المحفوظ | SourceFormat من مسار ملف | SourceFormat من تدفق بلا اسم |
| --- | --- | --- |
| PPT | `Ppt` | `Ppt` |
| PPTX, PPTM | `Pptx`, `Pptm` على التوالي | نفس مسار الملف |
| PPS | `Pps` | `Ppt` |
| PPSX, PPSM | `Ppsx`, `Ppsm` على التوالي | نفس مسار الملف |
| POT | `Pot` | `Ppt` |
| POTX, POTM | `Potx`, `Potm` على التوالي | نفس مسار الملف |
| ODP, OTP | `Odp`, `Otp` على التوالي | نفس مسار الملف |
| FODP | `Fodp` | `Fodp` |
| PowerPoint XML | `Xml` | `Xml` |

يُعاد توحيد محتوى PPS/POT القديم إلى `Ppt` للتدفقات بلا اسم. يصف الجدول تعريف التنسيق، وليس الحفاظ على كل ميزات العرض خلال التحويل.

## **الأسئلة المتكررة**

**هل تغيير حفظ ملف إلى ODP يغيّر تنسيق المصدر لعرض تم تحميله من PPTX؟**  
لا. النسخة الحالية لا تزال تُظهر `Pptx`. النسخة التي تم تحميلها من ملف ODP المحفوظ تُظهر `Odp`.

**هل يمكن للتدفق دائمًا أن يميز بين عرض تقديمي قديم وعرض شرائح وقالب؟**  
لا. تشترك PPT و PPS و POT في نفس التنسيق الثنائي. احتفظ باسم الملف أو بيانات التعريف الفرعية بشكل منفصل عندما يكون هذا التمييز مطلوبًا.

**أي واجهة برمجة تطبيقات يجب أن أستخدمها إذا كان العرض التقديمي مُحمَّلاً بالفعل؟**  
اقرأ [Presentation::get_SourceFormat](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/get_sourceformat/). استخدم [PresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentationfactory/getpresentationinfo/) للفحص قبل التحميل.