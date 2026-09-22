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
- نوع عرض مسبق التعريف
- صيغة Office Open XML الصارمة
- وضع Zip64
- تحديث الصورة المصغرة
- تقدم الحفظ
- C++
- Aspose.Slides
description: "حفظ عروض PowerPoint و OpenDocument إلى ملفات أو تدفقات في C++ باستخدام Aspose.Slides، وتكوين إخراج PPTX وتقرير التقدم."
---
## **نظرة عامة**

بعد إنشاء عرض تقديمي أو [فتح عرض تقديمي موجود](/slides/ar/cpp/open-presentation/)، استخدم الطريقة [Presentation::Save](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/save/) لكتابة النتيجة. يمكن لـ Aspose.Slides for C++ حفظ عرض تقديمي إلى ملف أو تدفق في صيغ PowerPoint و OpenDocument و PDF وغيرها. تغطي الأقسام التالية عمليات الحفظ القياسية والخيارات المتاحة لإخراج PPTX.

## **حفظ العروض التقديمية إلى ملفات**

لحفظ عرض تقديمي إلى ملف، مرّر مسار الإخراج وقيمة [SaveFormat](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/saveformat/) إلى طريقة [Presentation::Save](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/save/). تحدد قيمة الصيغة نوع الملف الذي ينشئه Aspose.Slides.

المثال التالي ينشئ عرضًا تقديميًا ويحفظه كملف PPTX:

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();

// إضافة أو تعديل محتوى العرض التقديمي هنا.

presentation->Save(u"Output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **حفظ العروض التقديمية بصيغتها الأصلية**

لأمثلة اكتشاف الملفات والتدفقات، سلوك العروض التي تم إنشاؤها حديثًا، والتمييز بين صيغ المصدر والإخراج، راجع [Determine the Original Presentation Format](/slides/ar/cpp/detect-presentation-source-format/).

في تطبيق معالجة دفعات، قد لا تكون صيغة الإدخال معروفة مسبقًا. بعد تحميل ملف، اقرأ صيغته الأصلية باستخدام [IPresentation::get_SourceFormat](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ipresentation/get_sourceformat/). مرّر قيمة [SourceFormat](https://reference.aspose.com/slides/ar/cpp/aspose.slides/sourceformat/) الناتجة إلى [SlideUtil::ToSaveFormat](https://reference.aspose.com/slides/ar/cpp/aspose.slides.util/slideutil/tosaveformat/) للحصول على قيمة [SaveFormat](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/saveformat/) المقابلة، ثم استخدم [Presentation::Save](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/save/) لكتابة العرض المعدل.

المثال الكامل التالي يعالج كل ملف في دليل إدخال، يحدّث عنوانه، ويحفظه إلى دليل إخراج بالصغة التي تم تحميله منها:

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Util/SlideUtil.h>
#include <system/console.h>
#include <system/exception.h>
#include <system/io/directory.h>
#include <system/io/path.h>
#include <system/smart_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::Util;
using namespace System;
using namespace System::IO;

String inputDirectory = u"Input";
String outputDirectory = u"Output";

Directory::CreateDirectory_(outputDirectory);

auto inputPaths = Directory::GetFiles(inputDirectory);
for (const auto& inputPath : inputPaths)
{
    try
    {
        auto presentation = MakeObject<Presentation>(inputPath);

        auto sourceFormat = presentation->get_SourceFormat();
        auto saveFormat = SlideUtil::ToSaveFormat(sourceFormat);

        presentation->get_DocumentProperties()->set_Title(u"Processed by the batch application");

        auto outputPath = Path::Combine(outputDirectory, Path::GetFileName(inputPath));
        presentation->Save(outputPath, saveFormat);
        presentation->Dispose();
    }
    catch (ArgumentException& exception)
    {
        Console::get_Error()->WriteLine(String::Format(u"Cannot map the source format of '{0}': {1}", inputPath, exception->get_Message()));
    }
    catch (Exception& exception)
    {
        Console::get_Error()->WriteLine(String::Format(u"Cannot process '{0}': {1}", inputPath, exception->get_Message()));
    }
}
```

[SlideUtil::ToSaveFormat](https://reference.aspose.com/slides/ar/cpp/aspose.slides.util/slideutil/tosaveformat/) يطابق PPT و PPTX و ODP و PPTM و PPSX و PPSM و POTX و POTM و PPS و POT و OTP و FODP و PowerPoint XML إلى صيغ حفظ العروض التقديمية المقابلة. يطابق صيغ مصدر العروض فقط؛ لا يُقصد به اختيار صيغ تصدير مثل PDF أو HTML أو TIFF أو الصور. تمرير قيمة [SourceFormat](https://reference.aspose.com/slides/ar/cpp/aspose.slides/sourceformat/) غير مدعومة أو غير صالحة ينتج عنه [ArgumentException](https://reference.aspose.com/slides/ar/cpp/system/argumentexception/).

ملفات PPT و PPS و POT القديمة تستخدم نفس الحاوية الثنائية. عندما يتم تحميل مثل هذا العرض من تدفق بدون امتداد ملف، قد يتم التعرف على ملف PPS أو POT على أنه PPT. إذا كان الحفاظ على هذه الأنواع الفرعية القديمة مطلوبًا، احتفظ باسم الملف الأصلي أو بيانات التعريف الخاصة بالصيغ منفصلًا واستخدمها عند اختيار اسم الملف وصيغته للإخراج.

## **حفظ العروض التقديمية إلى تدفقات**

للكتابة إلى عرض تقديمي دون الاعتماد على مسار ملف نهائي، مرّر [Stream](https://reference.aspose.com/slides/ar/cpp/system.io/stream/) قابل للكتابة وقيمة [SaveFormat](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/saveformat/) إلى طريقة [Presentation::Save](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/save/). هذا الأسلوب مفيد عندما يجب إرجاع الإخراج من خدمة ويب، أو تخزينه في قاعدة بيانات، أو معالجته في الذاكرة.

المثال التالي يحفظ عرضًا تقديميًا جديدًا إلى تدفق ملف:

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

auto presentation = MakeObject<Presentation>();
auto outputStream = MakeObject<FileStream>(u"Output.pptx", FileMode::Create);

presentation->Save(outputStream, SaveFormat::Pptx);

outputStream->Close();
presentation->Dispose();
```

## **حفظ العروض التقديمية بنوع عرض محدد مسبقًا**

يمكنك تحديد العرض الذي يفتح فيه PowerPoint العرض المحفوظ أولًا. استدعِ [ViewProperties::set_LastView](https://reference.aspose.com/slides/ar/cpp/aspose.slides/viewproperties/set_lastview/) مع قيمة [ViewType](https://reference.aspose.com/slides/ar/cpp/aspose.slides/viewtype/) قبل الحفظ.

المثال التالي يضبط عرض "Slide Master" كالعرض الأولي:

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

## **حفظ العروض التقديمية وفق صيغة Office Open XML الصارمة**

لإنشاء ملف PPTX يتوافق مع ملف التعريف الصارم لـ Office Open XML، أنشئ كائنًا من [PptxOptions](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/pptxoptions/) واستدعِ [PptxOptions::set_Conformance](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/pptxoptions/set_conformance/) مع `Conformance::Iso29500_2008_Strict`. ثم مرّر الخيارات إلى طريقة [Presentation::Save](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/save/).

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

auto presentation = MakeObject<Presentation>();

presentation->Save(u"StrictOfficeOpenXml.pptx", SaveFormat::Pptx, options);
presentation->Dispose();
```

## **حفظ العروض التقديمية بصيغة Office Open XML في وضع Zip64**

يحدّ أرشيف ZIP القياسي من حجم كل إدخال مضغوط وغير مضغوط، وحجم الأرشيف الكلي، وعدد الإدخالات. بما أن ملف PPTX هو أرشيف ZIP، قد يتجاوز عرض تقديمي كبير جدًا هذه الحدود. امتدادات ZIP64 ترفع الحدود المطبقة على الحجم والعدد.

استخدم [PptxOptions::set_Zip64Mode](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/pptxoptions/set_zip64mode/) للتحكم فيما إذا كان Aspose.Slides يكتب امتدادات ZIP64:

- `IfNecessary` يستخدم ZIP64 فقط عندما يتجاوز العرض حدود ZIP القياسية. هذا هو الوضع الافتراضي.
- `Never` يعطل امتدادات ZIP64.
- `Always` يكتب امتدادات ZIP64 دائمًا.

المثال التالي يفعّل دائمًا امتدادات ZIP64 للعرض الناتج:

```cpp
#include <DOM/Presentation.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <Export/Zip64Mode.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

auto options = MakeObject<PptxOptions>();
options->set_Zip64Mode(Zip64Mode::Always);

presentation->Save(u"OutputZip64.pptx", SaveFormat::Pptx, options);
presentation->Dispose();
```

{{% alert color="warning" title="Warning" %}}
إذا تم تعيين `Zip64Mode` إلى `Never` ولم يتمكن العرض من التناسب مع حدود ZIP القياسية، فإن عملية الحفظ تُطلق استثناءً من نوع [PptxException](https://reference.aspose.com/slides/ar/cpp/aspose.slides/pptxexception/).
{{% /alert %}}

## **حفظ العروض التقديمية بصيغة Office Open XML مع مستويات الضغط**

لإخراج PPTX، يمكنك موازنة سرعة الحفظ مقابل حجم الملف من خلال استدعاء [PptxOptions::set_CompressionLevel](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/pptxoptions/set_compressionlevel/). تُوفر تعداد [CompressionLevel](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/compressionlevel/) القيم التالية:

- `None` يخزن البيانات دون ضغط.
- `Level1` يوفر أسرع ضغط وأكبر حجم مضغوط.
- `Level2` إلى `Level5` يفضّلان تدريجيًا مخرجات أصغر على حساب سرعة الحفظ.
- `Level6` يوازن بين سرعة الحفظ وحجم الملف. هذا هو المستوى الافتراضي.
- `Level7` و `Level8` يفضّلان مخرجات أصغر أكثر على حساب سرعة الحفظ.
- `Level9` يوفر أقوى ضغط ويتطلب أطول زمن معالجة.

المثال التالي يحفظ عرضًا تقديميًا بدون ضغط:

```cpp
#include <DOM/Presentation.h>
#include <Export/CompressionLevel.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

auto options = MakeObject<PptxOptions>();
options->set_CompressionLevel(CompressionLevel::None);

presentation->Save(u"OutputNoCompression.pptx", SaveFormat::Pptx, options);
presentation->Dispose();
```

المثال التالي يستخدم أعلى مستوى ضغط:

```cpp
#include <DOM/Presentation.h>
#include <Export/CompressionLevel.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

auto options = MakeObject<PptxOptions>();
options->set_CompressionLevel(CompressionLevel::Level9);

presentation->Save(u"OutputMaximumCompression.pptx", SaveFormat::Pptx, options);
presentation->Dispose();
```

## **حفظ العروض التقديمية دون تحديث الصورة المصغرة**

عند حفظ عرض تقديمي كملف PPTX، يتحكم [PptxOptions::set_RefreshThumbnail](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/pptxoptions/set_refreshthumbnail/) في الصورة المصغرة للوثيقة:

- `true` يُعيد توليد الصورة المصغرة أثناء عملية الحفظ. هذه هي القيمة الافتراضية.
- `false` يحافظ على الصورة المصغرة الحالية. إذا لم يكن للعرض صورة مصغرة، لا ينشئ Aspose.Slides واحدة.

المثال التالي يحفظ عرضًا تقديميًا دون تحديث صورته المصغرة:

```cpp
#include <DOM/Presentation.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

auto options = MakeObject<PptxOptions>();
options->set_RefreshThumbnail(false);

presentation->Save(u"Output.pptx", SaveFormat::Pptx, options);
presentation->Dispose();
```

{{% alert color="info" title="Note" %}}
تعطيل تحديث الصورة المصغرة يمكن أن يقلل الوقت المطلوب لحفظ ملف PPTX.
{{% /alert %}}

## **حفظ تحديثات التقدم بالنسبة المئوية**

لمراقبة عملية الحفظ، نفّذ واجهة [IProgressCallback](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iprogresscallback/) ومرّر التنفيذ إلى [ISaveOptions::set_ProgressCallback](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/isaveoptions/set_progresscallback/). ثم يستدعي Aspose.Slides [IProgressCallback::Reporting](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iprogresscallback/reporting/) بقيم التقدم أثناء التصدير.

المثال التالي يبلّغ عن تقدم تصدير PDF إلى وحدة التحكم:

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

class ExportProgressHandler : public IProgressCallback
{
public:
    void Reporting(double progressValue) override
    {
        int progress = static_cast<int>(progressValue);
        Console::WriteLine(u"{0}% of the file has been converted.", progress);
    }
};

auto options = MakeObject<PdfOptions>();
options->set_ProgressCallback(MakeObject<ExportProgressHandler>());

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

presentation->Save(u"Output.pdf", SaveFormat::Pdf, options);
presentation->Dispose();
```

{{% alert color="info" title="Note" %}}
توفر Aspose أداة مجانية تسمى [PowerPoint Splitter](https://products.aspose.app/slides/ar/splitter) مبنية على Aspose.Slides API. تقوم الأداة بحفظ الشرائح المحددة من عرض تقديمي كملفات PPT أو PPTX منفصلة.
{{% /alert %}}

## **الأسئلة المتكررة**

**هل يدعم Aspose.Slides الحفظ المتزايد أو “الحفظ السريع”?**

لا. كل عملية حفظ تكتب ملف إخراج كامل بدلاً من تحديث الأجزاء التي تغيرت فقط.

**هل يمكن لعدة خيوط حفظ نفس كائن Presentation؟**

لا. كائن [Presentation](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/) [ليس آمناً للخلية المتعددة](/slides/ar/cpp/multithreading/). يجب الوصول إلى كل كائن وحفظه من خيط واحد فقط في كل مرة.

**ماذا يحدث للروابط التشعبية والملفات المرتبطة خارجيًا عندما أحفظ عرضًا تقديميًا؟**

تبقى [الروابط التشعبية](/slides/ar/cpp/manage-hyperlinks/) في العرض. لا يقوم Aspose.Slides بنسخ الملفات المرتبطة خارجيًا، لذا يجب أن يظل العرض المحفوظ قادرًا على الوصول إلى مواقعها.

**هل يمكنني حفظ بيانات تعريف المستند مثل المؤلف والعنوان والشركة وتاريخ الإنشاء؟**

نعم. عيّن [خصائص المستند](/slides/ar/cpp/presentation-properties/) المناسبة قبل الحفظ، وسيكتب Aspose.Slides هذه البيانات إلى ملف الإخراج.