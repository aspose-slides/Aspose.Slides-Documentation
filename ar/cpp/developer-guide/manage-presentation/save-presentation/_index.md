---
title: حفظ العروض التقديمية في C++
linktitle: حفظ العرض التقديمي
type: docs
weight: 80
url: /ar/cpp/save-presentation/
keywords:
- حفظ PowerPoint
- حفظ OpenDocument
- حفظ العرض التقديمي
- حفظ الشريحة
- حفظ PPT
- حفظ PPTX
- حفظ ODP
- العرض التقديمي إلى ملف
- العرض التقديمي إلى تدفق
- نوع عرض مسبق التحديد
- تنسيق Office Open XML الصارم
- وضع Zip64
- تجديد المصغرة
- تقدم الحفظ
- C++
- Aspose.Slides
description: "اكتشف كيفية حفظ العروض التقديمية في C++ باستخدام Aspose.Slides — تصدير إلى PowerPoint أو OpenDocument مع الحفاظ على التخطيطات والخطوط والتأثيرات."
---
## **نظرة عامة**

[Open Presentations in C++](/slides/ar/cpp/open-presentation/) يصف كيفية استخدام فئة [Presentation](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/) لفتح عرض تقديمي. يشرح هذا المقال كيفية إنشاء العروض التقديمية وحفظها. تحتوي فئة [Presentation](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/) على محتويات العرض التقديمي. سواءً كنت تنشئ عرضًا تقديميًا من الصفر أو تعدل عرضًا موجودًا، ستحتاج إلى حفظه عندما تنتهي. باستخدام Aspose.Slides للغة C++، يمكنك حفظه إلى **ملف** أو **دفق**. يشرح هذا المقال الطرق المختلفة لحفظ عرض تقديمي.

## **حفظ العروض التقديمية إلى ملفات**

احفظ عرضًا تقديميًا إلى ملف عن طريق استدعاء طريقة `Save` الخاصة بفئة [Presentation](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/). مرّر اسم الملف وتنسيق الحفظ إلى الطريقة. يوضح المثال التالي كيفية حفظ عرض تقديمي باستخدام Aspose.Slides.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// إنشاء كائن من فئة Presentation الذي يمثل ملف عرض تقديمي.
auto presentation = MakeObject<Presentation>();

// قم ببعض الأعمال هنا...

// حفظ العرض التقديمي إلى ملف.
presentation->Save(u"Output.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

## **حفظ العروض التقديمية إلى تدفقات**

يمكنك حفظ عرض تقديمي إلى تدفق عن طريق تمرير تدفق إخراج إلى طريقة `Save` الخاصة بفئة [Presentation](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/). يمكن كتابة العرض إلى أنواع متعددة من التدفقات. في المثال أدناه، نقوم بإنشاء عرض تقديمي جديد وحفظه إلى تدفق ملف.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file_mode.h>
#include <system/io/file_stream.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

// إنشاء كائن من فئة Presentation الذي يمثل ملف عرض تقديمي.
auto presentation = MakeObject<Presentation>();

auto fileStream = MakeObject<FileStream>(u"Output.pptx", FileMode::Create);

// حفظ العرض التقديمي إلى التدفق.
presentation->Save(fileStream, SaveFormat::Pptx);

presentation->Dispose();
fileStream->Close();
```

## **حفظ العروض التقديمية بنوع عرض محدد مسبقًا**

يتيح لك Aspose.Slides تعيين العرض الأولي الذي يستخدمه PowerPoint عند فتح العرض المولَّد عبر فئة [ViewProperties](https://reference.aspose.com/slides/ar/cpp/aspose.slides/viewproperties/). استخدم طريقة [set_LastView](https://reference.aspose.com/slides/ar/cpp/aspose.slides/viewproperties/set_lastview/) مع قيمة من تعداد [ViewType](https://reference.aspose.com/slides/ar/cpp/aspose.slides/viewtype/).

```cpp
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <ViewType.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();

presentation->get_ViewProperties()->set_LastView(ViewType::SlideMasterView);

presentation->Save(u"SlideMasterView.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **حفظ العروض التقديمية بتنسيق Office Open XML الصارم**

يتيح لك Aspose.Slides حفظ عرض تقديمي بتنسيق Office Open XML الصارم. استخدم فئة [PptxOptions](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/pptxoptions/) وقم بتعيين خاصية التوافق عند الحفظ. إذا قمت بتعيين `Conformance.Iso29500_2008_Strict`، سيتم حفظ الملف الناتج بتنسيق Office Open XML الصارم.

المثال أدناه ينشئ عرضًا تقديميًا ويحفظه بتنسيق Office Open XML الصارم.

```cpp
#include <DOM/Presentation.h>
#include <Export/Conformance.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto options = MakeObject<PptxOptions>();
options->set_Conformance(Conformance::Iso29500_2008_Strict);

// إنشاء كائن من فئة Presentation الذي يمثل ملف عرض تقديمي.
auto presentation = MakeObject<Presentation>();

// حفظ العرض التقديمي بتنسيق Office Open XML الصارم.
presentation->Save(u"StrictOfficeOpenXml.pptx", SaveFormat::Pptx, options);
presentation->Dispose();
```

## **حفظ العروض التقديمية بتنسيق Office Open XML بوضع Zip64**

ملف Office Open XML هو أرشيف ZIP يفرض حدودًا قدرها 4 جيجابايت (2^32 بايت) على الحجم غير المضغوط لأي ملف، والحجم المضغوط لأي ملف، وإجمالي حجم الأرشيف، كما يحد من عدد الملفات في الأرشيف إلى 65 535 (2^16‑1) ملف. توسعات تنسيق ZIP64 ترفع هذه الحدود إلى 2^64.

تتيح طريقة [IPptxOptions::set_Zip64Mode](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/ipptxoptions/set_zip64mode/) لك اختيار متى يتم استخدام توسعات تنسيق ZIP64 عند حفظ ملف Office Open XML.

يمكن استخدام هذه الطريقة مع الأنماط التالية:

- `IfNecessary` يستخدم توسعات تنسيق ZIP64 فقط إذا تجاوز العرض التقديمي الحدود المذكورة أعلاه. هذا هو النمط الافتراضي.
- `Never` لا يستخدم توسعات تنسيق ZIP64 أبدًا.
- `Always` دائمًا يستخدم توسعات تنسيق ZIP64.

يوضح الكود التالي كيفية حفظ عرض تقديمي كملف PPTX مع تمكين توسعات تنسيق ZIP64:

```cpp
#include <DOM/Presentation.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <Export/Zip64Mode.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pptxOptions = MakeObject<PptxOptions>();
pptxOptions->set_Zip64Mode(Zip64Mode::Always);

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

presentation->Save(u"OutputZip64.pptx", SaveFormat::Pptx, pptxOptions);
presentation->Dispose();
```

{{% alert title="NOTE" color="warning" %}}
عند الحفظ باستخدام `Zip64Mode.Never`، يتم إلقاء استثناء [PptxException](https://reference.aspose.com/slides/ar/cpp/aspose.slides/pptxexception/) إذا تعذر حفظ العرض التقديمي بتنسيق ZIP32.
{{% /alert %}}

## **حفظ العروض التقديمية بتنسيق Office Open XML مع مستويات الضغط**

عند العمل مع عروض تقديمية كبيرة، يمكنك ضبط مستوى الضغط لتحقيق توازن بين حجم الملف ووقت المعالجة. بناءً على متطلباتك، قد تفضِّل معالجة أسرع أو ملفات ناتجة أصغر.

يوفر Aspose.Slides طريقة [PptxOptions::set_CompressionLevel](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/pptxoptions/set_compressionlevel/) التي تسمح لك بتحديد مستوى الضغط المستخدم عند حفظ عرض تقديمي بتنسيق Office Open XML.

المستويات التالية للضغط متاحة:

- **None**: لا يُطبق أي ضغط. تُحفظ الملفات كما هي.
- **Level1:** أسرع ضغط مع أقل نسبة ضغط.
- **Level2:** ضغط أسرع مع نسبة ضغط محسنة قليلاً مقارنةً **Level1**.
- **Level3:** يوفر ضغطًا أفضل من **Level2** مع تأثير معتدل على وقت المعالجة.
- **Level4:** يوفر ضغطًا أفضل من **Level3**.
- **Level5:** يوفر ضغطًا محسّنًا مقارنةً **Level4** مع وقت معالجة إضافي.
- **Level6:** ضغط قياسي يقدّم توازنًا جيدًا بين سرعة المعالجة وحجم الملف. هذا هو *مستوى الضغط الافتراضي*.
- **Level7:** يوفر ضغطًا أفضل من **Level6** مع معالجة أبطأ.
- **Level8:** يوفر ضغطًا أفضل من **Level7**.
- **Level9:** أقصى ضغط. ينتج أصغر حجم ملف على حساب أطول زمن معالجة.

يوضح المثال التالي كيفية حفظ عرض تقديمي كملف PPTX *بدون ضغط*:

```cpp
#include <DOM/Presentation.h>
#include <Export/CompressionLevel.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using Aspose::Slides::Export::CompressionLevel;
using Aspose::Slides::Export::PptxOptions;
using Aspose::Slides::Export::SaveFormat;
using Aspose::Slides::Presentation;
using System::MakeObject;

auto pptxOptions = MakeObject<PptxOptions>();
pptxOptions->set_CompressionLevel(CompressionLevel::None);

auto presentation = MakeObject<Presentation>(u"Sample.pptx");
presentation->Save(u"Sample-out.pptx", SaveFormat::Pptx, pptxOptions);
presentation->Dispose();
```

يظهر هذا المثال كيفية حفظ عرض تقديمي كملف PPTX مع *أقصى ضغط*:

```cpp
#include <DOM/Presentation.h>
#include <Export/CompressionLevel.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using Aspose::Slides::Export::CompressionLevel;
using Aspose::Slides::Export::PptxOptions;
using Aspose::Slides::Export::SaveFormat;
using Aspose::Slides::Presentation;
using System::MakeObject;

auto pptxOptions = MakeObject<PptxOptions>();
pptxOptions->set_CompressionLevel(CompressionLevel::Level9);

auto presentation = MakeObject<Presentation>(u"Sample.pptx");
presentation->Save(u"Sample-level9.pptx", SaveFormat::Pptx, pptxOptions);
presentation->Dispose();
```

## **حفظ العروض التقديمية دون تحديث المصغرة**

تتحكم طريقة [PptxOptions::set_RefreshThumbnail](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/pptxoptions/set_refreshthumbnail/) في إنشاء المصغرة عند حفظ عرض تقديمي إلى PPTX:

- إذا تم تعيينها إلى `true`، تتجدد المصغرة أثناء الحفظ. هذا هو الإعداد الافتراضي.
- إذا تم تعيينها إلى `false`، تُحافظ على المصغرة الحالية. إذا لم يكن للعرض مصغرة، لن يتم إنشاء واحدة.

في الكود أدناه، يتم حفظ العرض إلى PPTX دون تجديد المصغرة.

```cpp
#include <DOM/Presentation.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pptxOptions = MakeObject<PptxOptions>();
pptxOptions->set_RefreshThumbnail(false);

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

presentation->Save(u"Output.pptx", SaveFormat::Pptx, pptxOptions);
presentation->Dispose();
```

{{% alert title="Info" color="info" %}}
يساعد هذا الخيار في تقليل الوقت المطلوب لحفظ عرض تقديمي بتنسيق PPTX.
{{% /alert %}}

## **حفظ تحديثات التقدم كنسبة مئوية**

يُستخدم واجهة [IProgressCallback](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iprogresscallback/) عبر طريقة `set_ProgressCallback` التي تكشفها واجهة [ISaveOptions](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/isaveoptions/) والفئة المجردة [SaveOptions](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/saveoptions/). عيّن تنفيذًا لـ [IProgressCallback](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iprogresscallback/) باستخدام `set_ProgressCallback` لتلقي تحديثات تقدم الحفظ كنسبة مئوية.

تُظهر مقاطع الشفرة التالية كيفية استخدام `IProgressCallback`.

```cpp
#include <IProgressCallback.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace System;

class ExportProgressHandler : public IProgressCallback
{
public:
    void Reporting(double progressValue) override
    {
        // استخدم قيمة نسبة التقدم هنا.
        int progress = static_cast<int>(progressValue);

        Console::WriteLine(u"{0}% of the file has been converted.", progress);
    }
};
```
```cpp
#include <DOM/Presentation.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <IProgressCallback.h>
#include <system/console.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// الفئة الخاصة بمتابعة التقدم المعرفة أعلاه.
class ExportProgressHandler : public IProgressCallback
{
public:
    void Reporting(double progressValue) override
    {
        int progress = static_cast<int>(progressValue);

        Console::WriteLine(u"{0}% of the file has been converted.", progress);
    }
};

auto saveOptions = MakeObject<PdfOptions>();
saveOptions->set_ProgressCallback(MakeObject<ExportProgressHandler>());

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

presentation->Save(u"Output.pdf", SaveFormat::Pdf, saveOptions);
presentation->Dispose();
```

{{% alert title="Info" color="info" %}}
قامت Aspose بتطوير تطبيق [مقسم PowerPoint مجاني](https://products.aspose.app/slides/ar/splitter) باستخدام واجهة برمجة التطبيقات الخاصة بها. يتيح لك التطبيق تقسيم عرض تقديمي إلى ملفات متعددة عن طريق حفظ الشرائح المحددة كملفات PPTX أو PPT جديدة.
{{% /alert %}}

## **الأسئلة الشائعة**

**هل يدعم "الحفظ السريع" (الحفظ المتدرج) بحيث تُكتب التغييرات فقط؟**  
لا. كل عملية حفظ تُنشئ الملف الهدف بالكامل؛ لا يُدعم الحفظ المتدرج "السريع".

**هل حفظ نفس كائن Presentation من عدة خيوط آمن من حيث التزامن؟**  
لا. كائن [Presentation](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/) ليس [آمنًا من حيث التزامن](/slides/ar/cpp/multithreading/)؛ احفظه من خيط واحد.

**ماذا يحدث للارتباطات التشعبية والملفات المرتبطة خارجيًا عند الحفظ؟**  
يتم الحفاظ على [الارتباطات التشعبية](/slides/ar/cpp/manage-hyperlinks/). الملفات المرتبطة خارجيًا (مثل الفيديوهات عبر مسارات نسبية) لا تُنسخ تلقائيًا — يجب التأكد من بقاء المسارات المشار إليها متاحة.

**هل يمكنني تعيين/حفظ بيانات تعريف المستند (المؤلف، العنوان، الشركة، التاريخ)؟**  
نعم. تُدعم [خصائص المستند](/slides/ar/cpp/presentation-properties/) القياسية وسيتم كتابتها إلى الملف عند الحفظ.