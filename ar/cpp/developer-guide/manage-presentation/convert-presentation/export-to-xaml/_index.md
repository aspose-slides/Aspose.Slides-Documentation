---
title: "تصدير العروض التقديمية إلى XAML في C++"
linktitle: "العرض التقديمي إلى XAML"
type: docs
weight: 30
url: /ar/cpp/export-to-xaml/
keywords:
- تصدير PowerPoint
- تصدير OpenDocument
- تصدير العرض التقديمي
- تحويل PowerPoint
- تحويل OpenDocument
- تحويل العرض التقديمي
- PowerPoint إلى XAML
- OpenDocument إلى XAML
- العرض التقديمي إلى XAML
- PPT إلى XAML
- PPTX إلى XAML
- ODP إلى XAML
- حفظ PPT كـ XAML
- حفظ PPTX كـ XAML
- حفظ ODP كـ XAML
- تصدير PPT إلى XAML
- تصدير PPTX إلى XAML
- تصدير ODP إلى XAML
- C++
- Aspose.Slides
description: "تحويل شرائح PowerPoint و OpenDocument إلى XAML في C++ باستخدام Aspose.Slides — حل سريع وخالٍ من Office يحافظ على تخطيطك دون تغيير."
---
## **نظرة عامة**

تشرح هذه المقالة كيفية تصدير عروض PowerPoint إلى XAML باستخدام Aspose.Slides. تتضمن مقدمة مختصرة عن XAML، وتوضح كيفية حفظ عرض تقديمي كـ XAML باستخدام الإعدادات الافتراضية، وتظهر كيفية تخصيص عملية التصدير عبر [XamlOptions](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export.xaml/xamloptions/)، بما في ذلك تصدير الشرائح المخفية. كما تجيب المقالة على بعض الأسئلة الشائعة المتعلقة بخطوط الاستبدال، توافق مجموعة XAML، وسلوك تصدير الشرائح المخفية.

## **حول XAML**

XAML هي لغة توصيف مبنية على XML تُستخدم لوصف واجهات المستخدم في أطر العمل مثل WPF (Windows Presentation Foundation) وUWP (Universal Windows Platform) وXamarin.Forms.

يمكنك العمل مع ملفات XAML في مصمم بصري أو كتابة وتحرير العلامات مباشرة.

## **تصدير العروض إلى XAML باستخدام الخيارات الافتراضية**

يظهر المثال التالي بلغة C++ كيفية تصدير عرض تقديمي إلى XAML باستخدام الإعدادات الافتراضية:

```cpp
#include <DOM/Presentation.h>
#include <Export/Xaml/XamlOptions.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export::Xaml;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");
auto xamlOptions = System::MakeObject<XamlOptions>();
presentation->Save(xamlOptions);
```

بشكل افتراضي، يتم حفظ الشرائح المصدرة في مجلد فرعي `pres` داخل دليل العمل الحالي للعملية، كما تُرجع الدالة [Directory::GetCurrentDirectory](https://reference.aspose.com/slides/ar/cpp/system.io/directory/getcurrentdirectory/). يتم إنشاء المجلد تلقائيًا، وتُحفظ أي صور مطلوبة فيه أيضًا.

يُؤخذ اسم مجلد الإخراج من اسم ملف المصدر دون امتداداته. بالنسبة للملف `pres.pptx`، تُسمّى ملفات الإخراج `pres/Slide_1.xaml` و`pres/Slide_2.xaml` وهكذا. حتى إذا مررت مسارًا مطلقًا للعرض التقديمي المصدر، يتم إنشاء مجلد الإخراج نسبةً إلى دليل العمل الحالي، وليس بجوار ملف الإدخال.

## **تصدير العروض إلى XAML باستخدام خيارات مخصصة**

استخدم الواجهة [IXamlOptions](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export.xaml/ixamloptions/) للتحكم في طريقة تصدير Aspose.Slides لعرض تقديمي إلى XAML.

لحفظ الإخراج في موقع مخصص، نفّذ [IXamlOutputSaver](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export.xaml/ixamloutputsaver/) ومرّر مثيل تنفيذك إلى طريقة [set_OutputSaver](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export.xaml/xamloptions/set_outputsaver/) الخاصة بـ [XamlOptions](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export.xaml/xamloptions/).

لضم الشرائح المخفية إلى إخراج XAML، مرّر القيمة `true` إلى طريقة [set_ExportHiddenSlides](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export.xaml/xamloptions/set_exporthiddenslides/)، كما هو موضح في المثال التالي بلغة C++:

```cpp
#include <DOM/Presentation.h>
#include <Export/Xaml/XamlOptions.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export::Xaml;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");
auto xamlOptions = System::MakeObject<XamlOptions>();
xamlOptions->set_ExportHiddenSlides(true);
presentation->Save(xamlOptions);
```

## **التقاط جميع الكائنات المولدة لـ XAML**

يمكن لتصدير XAML أن ينتج مستند XAML لكل شريحة مُصدرة بالإضافة إلى صور وموارد داعمة منفصلة. مرّر [IXamlOutputSaver](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export.xaml/ixamloutputsaver/) مخصص إلى [XamlOptions::set_OutputSaver](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export.xaml/xamloptions/set_outputsaver/) لاستقبال هذه الكائنات بدلاً من استخدام الحفظ الافتراضي على نظام الملفات. ابدأ عملية التصدير باستخدام التحميل الزائد لـ [Presentation::Save](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/save/) الذي يقبل خيارات XAML.

### **فهم دورة حياة الاستدعاء الراجع**

يستدعي المصدّر [IXamlOutputSaver::Save](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export.xaml/ixamloutputsaver/save/) بصورة منفصلة لكل كائن مُولَّد:

- `path` يحدد الكائن وقد يحتوي على دلائل نسبية. احتفظ بهذه المعلومة لأن XAML قد يشير إلى موارد باستخدام مسارات نسبية.
- `data` يحتوي على بايتات الكائن. يجب عدم فك ترميز الصور وغيرها من الموارد الثنائية كنص.
- المسؤول عن الحفظ هو المسؤول عن الاحتفاظ بالبيانات أو حفظها قبل الإرجاع. تُظهر الأمثلة نسخ كل مصفوفة بايت إلى الذاكرة الخاصة بالتطبيق.
- اعتبر عملية التصدير ناجحة فقط عندما تعود عملية حفظ العرض وتكمل جميع الاستدعاءات الراجعة بنجاح. لا تتجاهل أخطاء التخزين ولا تبدأ عمليات كتابة خلفية غير مراقبة. إذا حدث الإتقان بعد ذلك، أبلغ عن النجاح العام فقط بعد نجاح تلك الخطوة أيضًا.

تطبق [XamlOptions::set_ExportHiddenSlides](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export.xaml/xamloptions/set_exporthiddenslides/) أيضًا على الحفظ المخصص. الإعداد الافتراضي `false` يستبعد مستندات XAML للشرائح المخفية. ضبطه على `true` يدرجها وأي موارد مطلوبة لتصديرها. عدد الموارد يعتمد على العرض التقديمي؛ لا تفترض استدعاءً واحدًا لكل شريحة أو ترتيبًا ثابتًا للاستدعاءات.

### **التصدير إلى الذاكرة وفحص الكائنات**

يحمّل هذا المثال الكامل الملف `pres.pptx`، يجمع كل كائن في [Dictionary<String, ArrayPtr<uint8_t>>](https://reference.aspose.com/slides/ar/cpp/system.collections.generic/dictionary/)، ويطبع اسمه ونوعه وعدد بايتاته. يحافظ على الأسماء المقدَّمة كما هي. تتسبب الأسماء المكررة في فشل التجميع بدلاً من الكتابة فوق الكائن بصمت.

```cpp
#include <DOM/Presentation.h>
#include <Export/Xaml/IXamlOutputSaver.h>
#include <Export/Xaml/XamlOptions.h>
#include <system/array.h>
#include <system/collections/dictionary.h>
#include <system/console.h>
#include <system/string_comparer.h>
#include <system/io/path.h>
#include <system/text/encoding.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export::Xaml;
using namespace System;
using namespace System::Collections::Generic;
using namespace System::IO;
using namespace System::Text;

class InMemoryXamlExample
{
    class MemoryXamlSaver : public IXamlOutputSaver
    {
    public:
        using ArtifactDictionary = Dictionary<String, ArrayPtr<uint8_t>>;
        SharedPtr<ArtifactDictionary> Artifacts = MakeObject<ArtifactDictionary>(StringComparer::get_Ordinal());

        void Save(String path, ArrayPtr<uint8_t> data) override
        {
            auto retainedData = data->Clone();
            Artifacts->Add(path, retainedData);
        }
    };

public:
    static void Run()
    {
        auto saver = MakeObject<MemoryXamlSaver>();
        auto presentation = MakeObject<Presentation>(u"pres.pptx");
        auto options = MakeObject<XamlOptions>();
        options->set_OutputSaver(saver);
        options->set_ExportHiddenSlides(true);
        presentation->Save(options);

        auto inspectXamlText = false;
        for (const auto& artifact : saver->Artifacts)
        {
            auto extension = Path::GetExtension(artifact.get_Key()).ToLowerInvariant();
            auto isXaml = extension == u".xaml";
            auto isImage = extension == u".png" || extension == u".jpg" || extension == u".jpeg" || extension == u".gif" || extension == u".bmp" || extension == u".tif" || extension == u".tiff" || extension == u".svg";
            String kind = isXaml ? u"slide XAML" : isImage ? u"image" : u"supporting resource";
            Console::WriteLine(u"{0}: {1} bytes ({2})", artifact.get_Key(), artifact.get_Value()->get_Length(), kind);

            // فك ترميز XAML فقط، وفقط عندما تكون فحص النصوص مطلوبًا.
            if (isXaml && inspectXamlText)
            {
                auto markup = Encoding::get_UTF8()->GetString(artifact.get_Value());
                Console::WriteLine(markup);
            }
        }
    }
};
```

استدعِ `InMemoryXamlExample::Run` من تطبيقك. فحوصات الامتداد مفيدة للفحص؛ احتفظ بجميع الكائنات، بما في ذلك أنواع الموارد غير المألوفة. اترك البايتات دون تعديل عند التخزين أو النقل. استخدم [Encoding::GetString](https://reference.aspose.com/slides/ar/cpp/system.text/encoding/getstring/) مع ترميز UTF-8 فقط لملفات XAML التي تحتاج إلى معالجة نصية.

### **حزم الكائنات المجمعة في أرشيف ZIP**

هذا المثال المستقل يجمع التصدير، يتحقق من أسمائه، ويكتب البايتات الأصلية في أرشيف ZIP. يميّز اسم الأرشيف الفريد بين وظائف التصدير المتزامنة. تستخدم إدخالات ZIP الشرط المائل للأمام وتحتفظ بالدلائل النسبية. يتم رفض الأسماء غير الآمنة أو المتصادمة بعد التطبيع قبل كتابة الحزمة بالكامل.

```cpp
#include <DOM/Presentation.h>
#include <Export/Xaml/IXamlOutputSaver.h>
#include <Export/Xaml/XamlOptions.h>
#include <system/array.h>
#include <system/collections/dictionary.h>
#include <system/console.h>
#include <system/string_comparer.h>
#include <system/guid.h>
#include <system/io/file_access.h>
#include <system/io/file_mode.h>
#include <system/io/file_stream.h>
#include <system/io/path.h>
#include <zip/zip_file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export::Xaml;
using namespace System;
using namespace System::Collections::Generic;
using namespace System::IO;
using namespace Aspose::Zip;

class ZipXamlExample
{
    class CollectedXamlSaver : public IXamlOutputSaver
    {
    public:
        using ArtifactDictionary = Dictionary<String, ArrayPtr<uint8_t>>;
        SharedPtr<ArtifactDictionary> Artifacts = MakeObject<ArtifactDictionary>(StringComparer::get_Ordinal());

        void Save(String path, ArrayPtr<uint8_t> data) override
        {
            auto retainedData = data->Clone();
            Artifacts->Add(path, retainedData);
        }
    };

public:
    static void Run()
    {
        auto saver = MakeObject<CollectedXamlSaver>();
        auto presentation = MakeObject<Presentation>(u"pres.pptx");
        auto options = MakeObject<XamlOptions>();
        options->set_OutputSaver(saver);
        options->set_ExportHiddenSlides(false);
        presentation->Save(options);

        auto entries = MakeObject<Dictionary<String, ArrayPtr<uint8_t>>>(StringComparer::get_OrdinalIgnoreCase());
        for (const auto& artifact : saver->Artifacts)
        {
            auto entryName = artifact.get_Key().Replace(u'\\', u'/');
            auto segments = entryName.Split(u'/');
            auto unsafeName = entryName.StartsWith(u"/", StringComparison::Ordinal) || entryName.Contains(u":");
            for (const auto& segment : segments)
            {
                unsafeName |= String::IsNullOrWhiteSpace(segment) || segment == u"." || segment == u"..";
            }

            if (unsafeName || entries->ContainsKey(entryName))
            {
                Console::WriteLine(u"Export rejected: unsafe or duplicate artifact name: {0}", artifact.get_Key());
                return;
            }
            entries->Add(entryName, artifact.get_Value());
        }

        auto jobId = Guid::NewGuid();
        auto archivePath = u"xaml-" + jobId.ToString(u"N") + u".zip";
        auto archive = MakeObject<ZipFile>();
        for (const auto& artifact : entries)
        {
            auto fileName = Path::GetFileName(artifact.get_Key());
            auto directoryName = Path::GetDirectoryName(artifact.get_Key()).Replace(u'\\', u'/');
            archive->AddEntry(fileName, directoryName, artifact.get_Value());
        }

        auto output = MakeObject<FileStream>(archivePath, FileMode::CreateNew, FileAccess::Write);
        archive->Save(output);
        output->Close();
        archive->Dispose();

        // يقوم Save بإنهاء دليل ZIP؛ أغلق الملف قبل الإبلاغ عن النجاح.
        Console::WriteLine(u"Saved {0} artifacts to {1}", entries->get_Count(), archivePath);
    }
};
```

استدعِ `ZipXamlExample::Run` من تطبيقك. يستخدم المثال `Aspose::Zip::ZipFile` من بيئة تشغيل C++ لكتابة أرشيف محلي واحد؛ المصدّر نفسه لا يكتب ملفات XAML أو صور منفصلة. للتخزين عن بُعد، استبدل مرحلة كتابة الأرشيف بعمليات تحميل لمجموعات البايتات المجمعة. استخدم معرف مهمة التصدير مع الاسم النسبي الكامل للكائن كمفتاح كتلة، أو احفظ معرف المهمة والاسم النسبي والبيانات الثنائية في صف قاعدة بيانات. انشر المهمة فقط بعد إكمال جميع عمليات التحميل أو التزام معاملة قاعدة البيانات. نظّف المخرجات الجزئية إذا فشل التخزين.

للعروض الكبيرة، يمكن للحفظ المخصص أن يُخزّن كل كائن مباشرةً في تخزين التطبيق لتجنب الاحتفاظ بنسخة إضافية من كامل التصدير في ذاكرة التطبيق. لا يزال المصدّر يجمع جميع الكائنات المولدة في الذاكرة قبل استدعاء الحفظ. احتفظ بكل استدعاء متزامنًا من منظور المصدّر: أرجع فقط بعد قبول الوجهة للبايتات، ودع الفشل يصل إلى المستدعي.

### **الحفاظ على أسماء الموارد والتحقق من المرجعيات**

- طوّع فواصل المسار عند الحاجة في الوجهة، لكن حافظ على الدلائل النسبية. لا تستخدم [Path::GetFileName](https://reference.aspose.com/slides/ar/cpp/system.io/path/getfilename/) إلا إذا كنت متأكدًا من تفرُّد كل اسم مولَّد وصحة مراجع الموارد.
- طبّق تحققًا من الأسماء حسب الوجهة. عند كتابة ملفات منفصلة، رفض المسارات المطلقة وقطاعات التنقل، حل الوجهة باستخدام [Path::GetFullPath](https://reference.aspose.com/slides/ar/cpp/system.io/path/getfullpath/)، وتأكد من بقاءها ضمن دليل التصدير المستهدف، بما في ذلك فاصل الدليل في فحص الاحتواء. استخدم دليلًا يتحكم فيه التطبيق دون روابط رمزية قد تعيد توجيه الكتابة.
- استخدم حافظة تخزين ومجال أسماء منفصل لكل مهمة تصدير. اكتشف التصادمات بعد تطبيع الفواصل ووفقًا لقواعد حساسية الحالة للوجهة.
- قبل النشر، حلل كل مستند XAML كـ XML وتفقد مراجع الموارد القائمة على الملفات، مثل سمة `Source` أو `ImageSource` للصور. حل كل URI نسبي مقابل دليل الكائن XAML الحامل، طوّع اسم التخزين الناتج، وتأكد من وجود المفتاح المقابل في القاموس أو إدخال ZIP أو الكائن المخزَّن. عالج عناوين URL الخارجية وتعبيرات XAML markup بشكل منفصل عن أسماء الملفات النسبية.

على سبيل المثال، إذا كان `pres/Slide_1.xaml` يشير إلى `images/image1.png`، يجب أن يكون المورد المخزن متاحًا كـ `pres/images/image1.png`. الاحتفاظ فقط بـ `image1.png` سيكسر هذا الارتباط. بالنسبة لتخزين الكائنات، حافظ على نفس الهيكل تحت بادئة المهمة واجعل عناوين URL للموارد تلك متاحة لمستهلك XAML. أعد فتح ملف ZIP المكتمل للتحقق من أسماء الإدخالات وبايتات الموارد، وحمِّل شرائح نمطية في بيئة XAML المستهدفة لتؤكد أن الصور تُحل correctamente.

## **الأسئلة الشائعة**

**كيف يمكنني ضمان خطوط متوقعة إذا لم يكن الخط الأصلي متاحًا على الجهاز؟**

استخدم [set_DefaultRegularFont](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/saveoptions/set_defaultregularfont/) في [XamlOptions](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export.xaml/xamloptions/) — يُستَخدم كخط احتياطي أثناء التصدير عندما يكون الخط الأصلي مفقودًا. هذا لا يضمن أن XAML المُولَّد سيشير إلى الخط الاحتياطي أو أن الخط متاح على الجهاز الهدف. تأكد من توفر الخطوط المشار إليها في XAML في البيئة التي يتم عرضها فيها.

**هل XAML المُصدَّر مخصص فقط لـ WPF أم يمكن استخدامه مع مجموعات XAML أخرى أيضًا؟**

تقوم Aspose.Slides بتصدير XAML لـ WPF عبر API العامة لها. لا يُضمن التوافق مع مجموعات XAML أخرى مثل UWP وXamarin.Forms. اختبر العلامات المُولَّدة في البيئة الهدف الخاصة بك.

**هل تُدعم الشرائح المخفية، وكيف يمكن منع تصديرها افتراضيًا؟**

افتراضياً لا تُضمن الشرائح المخفية. يمكنك التحكم في هذا السلوك عبر [set_ExportHiddenSlides](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export.xaml/xamloptions/set_exporthiddenslides/) في [XamlOptions](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export.xaml/xamloptions/) — أبقِه معطَّلًا إذا لم تكن بحاجة لتصديرها.