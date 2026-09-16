---
title: صادرات ارائه‌ها به XAML در C++
linktitle: ارائه به XAML
type: docs
weight: 30
url: /fa/cpp/export-to-xaml/
keywords:
- صادرات پاورپوینت
- صادرات OpenDocument
- صادرات ارائه
- تبدیل پاورپوینت
- تبدیل OpenDocument
- تبدیل ارائه
- پاورپوینت به XAML
- OpenDocument به XAML
- ارائه به XAML
- PPT به XAML
- PPTX به XAML
- ODP به XAML
- ذخیره PPT به صورت XAML
- ذخیره PPTX به صورت XAML
- ذخیره ODP به صورت XAML
- صادرات PPT به XAML
- صادرات PPTX به XAML
- صادرات ODP به XAML
- C++
- Aspose.Slides
description: "پاورپوینت و اسلایدهای OpenDocument را به XAML در C++ با استفاده از Aspose.Slides تبدیل کنید — راه‌حلی سریع و بدون نیاز به Office که چیدمان شما را دست‌نخورده نگه می‌دارد."
---
## **بررسی اجمالی**

این مقاله نحوه‌ی صادر کردن ارائه‌های PowerPoint به XAML با استفاده از Aspose.Slides را توضیح می‌دهد. شامل مقدمه‌ای کوتاه درباره XAML است، نحوه‌ی ذخیره‌سازی یک ارائه به XAML با تنظیمات پیش‌فرض را نشان می‌دهد و نحوه‌ی سفارشی‌سازی صادر کردن از طریق [XamlOptions](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export.xaml/xamloptions/)، از جمله صادر کردن اسلایدهای پنهان، را شرح می‌دهد. مقاله همچنین به چند سؤال رایج در مورد فونت‌های جایگزین، سازگاری پشته XAML و رفتار صادرات اسلایدهای پنهان پاسخ می‌دهد.

## **درباره XAML**

XAML یک زبان علامت‌گذاری مبتنی بر XML است که برای توصیف رابط‌های کاربری در چارچوب‌هایی مانند WPF (Windows Presentation Foundation)، UWP (Universal Windows Platform) و Xamarin.Forms استفاده می‌شود.

می‌توانید با یک طراح بصری با فایل‌های XAML کار کنید یا مستقیماً علامت‌گذاری را بنویسید و ویرایش کنید.

## **صادر کردن ارائه‌ها به XAML با گزینه‌های پیش‌فرض**

مثال C++ زیر نشان می‌دهد چگونه یک ارائه را با تنظیمات پیش‌فرض به XAML صادر کنید:

```cpp
#include <DOM/Presentation.h>
#include <Export/Xaml/XamlOptions.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export::Xaml;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");
auto xamlOptions = System::MakeObject<XamlOptions>();
presentation->Save(xamlOptions);
```

به‌طور پیش‌فرض، اسلایدهای صادر شده در یک زیرپوشهٔ `pres` از مسیر کاری فعلی فرآیند، که توسط [Directory::GetCurrentDirectory](https://reference.aspose.com/slides/fa/cpp/system.io/directory/getcurrentdirectory/) برگردانده می‌شود، ذخیره می‌شوند. این پوشه به‌صورت خودکار ایجاد می‌شود و هر تصویری که نیاز باشد نیز در همانجا ذخیره می‌شود.

نام پوشهٔ خروجی از نام فایل منبع بدون پسوند آن گرفته می‌شود. برای `pres.pptx`، فایل‌های خروجی به‌صورت `pres/Slide_1.xaml`، `pres/Slide_2.xaml` و به همین ترتیب نام‌گذاری می‌شوند. حتی اگر مسیر مطلقی به ارائهٔ ورودی بدهید، پوشهٔ خروجی نسبت به مسیر کاری فعلی ساخته می‌شود، نه در کنار فایل ورودی.

## **صادر کردن ارائه‌ها به XAML با گزینه‌های سفارشی**

از اینترفیس [IXamlOptions](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export.xaml/ixamloptions/) برای کنترل نحوهٔ صادرات یک ارائه به XAML توسط Aspose.Slides استفاده کنید.

برای ذخیرهٔ خروجی در مکان سفارشی، یک پیاده‌سازی از [IXamlOutputSaver](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export.xaml/ixamloutputsaver/) بنویسید و یک نمونه از این پیاده‌سازی را به متد [set_OutputSaver](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export.xaml/xamloptions/set_outputsaver/) از [XamlOptions](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export.xaml/xamloptions/) پاس دهید.

برای شامل کردن اسلایدهای پنهان در خروجی XAML، مقدار `true` را به متد [set_ExportHiddenSlides](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export.xaml/xamloptions/set_exporthiddenslides/) پاس دهید، همان‌طور که در مثال C++ زیر نشان داده شده است:

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

## **جمع‌آوری تمام آثار تولیدشدهٔ XAML**

یک صادرات XAML می‌تواند برای هر اسلاید صادرشده یک سند XAML به‌ همراه تصاویر جداگانه و منابع پشتیبانی تولید کند. یک [IXamlOutputSaver](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export.xaml/ixamloutputsaver/) سفارشی را به [XamlOptions::set_OutputSaver](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export.xaml/xamloptions/set_outputsaver/) پاس دهید تا به جای استفاده از ذخیره‌کنندهٔ پیش‌فرض سیستم فایل، این آثار دریافت شوند. صادرات را با فراخوانی overload مخصوص XAML از [Presentation::Save](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/save/) که گزینه‌های XAML را می‌پذیرد، آغاز کنید.

### **درک دورهٔ حیات Callback**

صادرکننده برای هر اثر تولیدشده به‌صورت جداگانه متد [IXamlOutputSaver::Save](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export.xaml/ixamloutputsaver/save/) را فراخوانی می‌کند:

- `path` هویت اثر را مشخص می‌کند و ممکن است شامل مسیرهای نسبی باشد. این اطلاعات را نگه دارید زیرا XAML ممکن است به منابع با مسیرهای نسبی ارجاع دهد.
- `data` شامل بایت‌های اثر است. تصاویر و سایر منابع باینری نباید به‌عنوان متن رمزگشایی شوند.
- ذخیره‌کننده مسئول نگهداری یا حفظ داده‌ها قبل از بازگشت است. مثال‌ها هر آرایه بایت را در حافظهٔ متعلق به برنامه کپی می‌کنند.
- صادرات را فقط زمانی موفق در نظر بگیرید که عملیات ذخیرهٔ ارائه بازگردد و تمام callbackها به‌طور موفقیت‌آمیز تکمیل شوند. خطاهای ذخیره‌سازی را نادیده نگیرید و نوشتن‌های پس‌زمینهٔ بدون نظارت را آغاز نکنید. اگر پایدارسازی بعداً رخ داد، موفقیت کلی را فقط پس از موفقیت آن گام گزارش کنید.

متد [XamlOptions::set_ExportHiddenSlides](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export.xaml/xamloptions/set_exporthiddenslides/) نیز برای ذخیره‌کنندهٔ سفارشی اعمال می‌شود. مقدار پیش‌فرض `false` اسناد XAML اسلایدهای پنهان را حذف می‌کند. تنظیم آن به `true` این اسناد و هر منبع موردنیاز برای صادرات آن‌ها را شامل می‌شود. تعداد منابع به ارائه بستگی دارد؛ فرض کنید برای هر اسلاید یک callback وجود دارد یا ترتیب ثابت callbackها وجود دارد، نادرست است.

### **صادر کردن به حافظه و بازرسی آثار**

این مثال کامل `pres.pptx` را بارگذاری می‌کند، هر اثر را در یک [Dictionary<String, ArrayPtr<uint8_t>>](https://reference.aspose.com/slides/fa/cpp/system.collections.generic/dictionary/) جمع‌آوری می‌کند و نام، نوع و تعداد بایت آن را چاپ می‌کند. نام‌های ارائه‌شده دقیقاً حفظ می‌شوند. نام‌های تکراری باعث شکست جمع‌آوری می‌شود و به‌جای بازنویسی آرام یک اثر، عملیات را متوقف می‌کند.

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

            // فقط XAML را رمزگشایی کنید و فقط وقتی که بررسی متنی لازم است.
            if (isXaml && inspectXamlText)
            {
                auto markup = Encoding::get_UTF8()->GetString(artifact.get_Value());
                Console::WriteLine(markup);
            }
        }
    }
};
```

متد `InMemoryXamlExample::Run` را از برنامهٔ خود فراخوانی کنید. بررسی پسوندها برای بازرسی مفید است؛ تمام آثار، از جمله انواع منابع ناآشنا، را نگه دارید. هنگام ذخیره یا انتقال، بایت‌ها را دست نخورده بگذارید. برای پردازش متنی XAML فقط از [Encoding::GetString](https://reference.aspose.com/slides/fa/cpp/system.text/encoding/getstring/) با رمزگذاری UTF-8 استفاده کنید.

### **بسته‌بندی آثار جمع‌آوری‌شده در یک آرشیو ZIP**

این مثال مستقل آثار صادرات را جمع‌آوری، نام‌هایشان را اعتبارسنجی و بایت‌های اصلی را در یک آرشیو ZIP می‌نویسد. نام آرشیو منحصربه‌فرد، کارهای صادراتی همزمان را از هم جدا می‌کند. ورودی‌های ZIP از اسلش‌های مستقیم استفاده می‌کنند و مسیرهای نسبی را حفظ می‌کنند. نام‌های غیرامن یا نام‌هایی که پس از نرمال‌سازی تداخل دارند، قبل از نوشتن کل بسته را رد می‌کنند.

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

        // ذخیره‌سازی، فهرست ZIP را نهایی می‌کند؛ قبل از گزارش موفقیت، فایل را ببندید.
        Console::WriteLine(u"Saved {0} artifacts to {1}", entries->get_Count(), archivePath);
    }
};
```

متد `ZipXamlExample::Run` را از برنامهٔ خود فراخوانی کنید. این مثال از `Aspose::Zip::ZipFile` در زمان اجراهای C++ برای نوشتن یک آرشیو محلی استفاده می‌کند؛ خود صادرکننده فایل‌های XAML یا تصویر جداگانه‌ای نمی‌نویسد. برای ذخیره‌سازی ریموت، مرحلهٔ نوشتن آرشیو را با آپلود آرایه‌های بایت جمع‌آوری‌شده جایگزین کنید. از یک شناسهٔ کار صادرات به‌همراه نام نسبی کامل اثر به‌عنوان کلید blob استفاده کنید یا شناسهٔ کار، نام نسبی و دادهٔ باینری را در یک ردیف پایگاه‌داده ذخیره کنید. کار را فقط پس از تکمیل تمام آپلودها یا تأیید تراکنش پایگاه‌داده منتشر کنید. در صورت شکست پایدارسازی، خروجی جزئی را پاک کنید.

برای ارائه‌های بزرگ، یک ذخیره‌کنندهٔ سفارشی می‌تواند هر اثر را مستقیماً در ذخیره‌سازی برنامه حفظ کند تا از نگهداری یک نسخهٔ اضافه از کل صادرات در حافظهٔ برنامه جلوگیری شود. صادرکننده همچنان تمام آثار تولیدشده را در حافظه جمع‌آوری می‌کند قبل از فراخوانی ذخیره‌کننده. هر callback را از دید صادرکننده همزمان نگه دارید: فقط پس از پذیرش بایت‌ها توسط مقصد بازگردید و اجازه دهید خطاها به فراخواننده برسند.

### **حفظ نام‌های منابع و بررسی ارجاعات**

- هنگام نیاز مقصد جداکننده‌های مسیر را نرمال کنید، اما مسیرهای نسبی را حفظ کنید. فقط از [Path::GetFileName](https://reference.aspose.com/slides/fa/cpp/system.io/path/getfilename/) استفاده نکنید مگر این‌که مطمئن باشید هر نام تولیدشده یکتا باشد و ارجاعات منابع معتبر بمانند.
- اعتبارسنجی نام خاص مقصد را اعمال کنید. هنگام نوشتن فایل‌های منفرد، مسیرهای ریشه‌ای و بخش‌های پیمایشی را رد کنید، مقصد را با [Path::GetFullPath](https://reference.aspose.com/slides/fa/cpp/system.io/path/getfullpath/) حل کنید و اطمینان حاصل کنید که زیر مسیر هدف صادرات باقی بماند، شامل جداکنندهٔ مسیر در بررسی محصور بودن. از یک پوشهٔ کنترل‌شده توسط برنامه استفاده کنید که لینک‌های نمادین نداشته باشد که ممکن است نوشتن‌ها را به مسیرهای دیگر هدایت کند.
- برای هر کار صادرات یک ذخیره‌کننده و فضای نام ذخیره‌سازی جداگانه استفاده کنید. پس از نرمال‌سازی جداکننده‌ها و با در نظر گرفتن قوانین حساسیت به حروف مقصد، برخوردها را شناسایی کنید.
- قبل از انتشار، هر سند XAML را به‌عنوان XML پارس کنید و ارجاعات منبع مبتنی بر فایل مانند ویژگی‌های `Source` یا `ImageSource` را بررسی کنید. هر URI نسبی را نسبت به پوشهٔ اثر XAML حاوی‌اش حل کنید، نام ذخیرهٔ حاصل را نرمال کنید و تأیید کنید که کلید دیکشنری مربوطه، ورودی ZIP یا شیء ذخیره‌شده وجود دارد. URIهای خارجی و عبارات علامت‌گذاری XAML را از نام‌های فایل نسبی جداگانه بررسی کنید.

برای مثال، اگر `pres/Slide_1.xaml` به `images/image1.png` ارجاع دهد، منبع ذخیره‌شده باید به صورت `pres/images/image1.png` در دسترس باشد. نگهداری فقط `image1.png` این رابطه را می‌شکند. برای ذخیره‌سازی شی، همان ساختار زیرپیشوند کار را حفظ کنید و URLهای این منابع را برای مصرف‌کنندهٔ XAML قابل دسترسی کنید. آرشیو ZIP تکمیل‌شده را باز کنید تا نام ورودی‌ها و بایت‌های منابع را تأیید کنید و اسلایدهای نمونه را در محیط هدف XAML بارگذاری کنید تا اطمینان حاصل شود تصاویر به‌درستی حل می‌شوند.

## **سؤالات متداول**

**چگونه می‌توانم فونت‌های پیش‌بینی‌پذیر داشته باشم اگر فونت اصلی در دستگاه موجود نباشد؟**

از [set_DefaultRegularFont](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/saveoptions/set_defaultregularfont/) در [XamlOptions](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export.xaml/xamloptions/) استفاده کنید — این فونت به‌عنوان فونت جایگزین در طول صادرات وقتی فونت اصلی موجود نباشد، به کار می‌رود. این تضمین نمی‌کند که XAML تولیدشده به‌طور حتمی به فونت جایگزین ارجاع دهد یا اینکه فونت در دستگاه هدف موجود باشد. اطمینان حاصل کنید که فونت‌های ارجاع‌شده توسط XAML در محیطی که نمایش داده می‌شود، موجود باشند.

**آیا XAML صادرشده فقط برای WPF منظور شده است یا می‌تواند در سایر پشته‌های XAML نیز استفاده شود؟**

Aspose.Slides XAML مربوط به WPF را از طریق API عمومی خود صادر می‌کند. سازگاری با سایر پشته‌های XAML مانند UWP و Xamarin.Forms تضمین نشده است. علامت‌گذاری تولیدشده را در محیط هدف خود آزمایش کنید.

**آیا اسلایدهای پنهان پشتیبانی می‌شوند و چگونه می‌توانم جلوگیری کنم که به‌طور پیش‌فرض صادر شوند؟**

به‌طور پیش‌فرض، اسلایدهای پنهان شامل نمی‌شوند. می‌توانید این رفتار را از طریق [set_ExportHiddenSlides](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export.xaml/xamloptions/set_exporthiddenslides/) در [XamlOptions](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export.xaml/xamloptions/) کنترل کنید — اگر نیاز به صادرات آن‌ها ندارید، این گزینه را غیرفعال نگه دارید.