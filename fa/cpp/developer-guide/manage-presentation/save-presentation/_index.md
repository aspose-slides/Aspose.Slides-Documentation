---
title: ذخیره ارائه‌ها در C++
linktitle: ذخیره ارائه
type: docs
weight: 80
url: /fa/cpp/save-presentation/
keywords:
- ذخیره PowerPoint
- ذخیره OpenDocument
- ذخیره ارائه
- ذخیره اسلاید
- ذخیره PPT
- ذخیره PPTX
- ذخیره ODP
- ارائه به فایل
- ارائه به جریان
- نوع نمای پیش‌تعریف‌شده
- قالب Strict Office Open XML
- حالت Zip64
- به‌روزرسانی تصویر بند انگشت
- پیشرفت ذخیره‌سازی
- C++
- Aspose.Slides
description: "کشف کنید چگونه می‌توان در C++ با استفاده از Aspose.Slides—به‌صورت PowerPoint یا OpenDocument صادر کنید در حالی که چیدمان‌ها، قلم‌ها و افکت‌ها حفظ می‌شوند."
---
## **مرور کلی**

[Open Presentations in C++](/slides/fa/cpp/open-presentation/) توضیح می‌دهد که چگونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) برای باز کردن یک ارائه استفاده کنید. این مقاله توضیح می‌دهد که چگونه ارائه‌ها را ایجاد و ذخیره کنید. کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) محتوای یک ارائه را شامل می‌شود. چه از ابتدا یک ارائه ایجاد می‌کنید و چه یک ارائه موجود را ویرایش می‌کنید، پس از اتمام می‌خواهید آن را ذخیره کنید. با Aspose.Slides برای C++ می‌توانید به **فایل** یا **جریان** ذخیره کنید. این مقاله روش‌های مختلف ذخیره یک ارائه را توضیح می‌دهد.

## **ذخیره ارائه‌ها در فایل‌ها**

یک ارائه را با فراخوانی متد `Save` کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) به یک فایل ذخیره کنید. نام فایل و قالب ذخیره را به متد پاس دهید. مثال زیر نشان می‌دهد چگونه یک ارائه را با Aspose.Slides ذخیره کنید.

```cpp
// شیء کلاس Presentation را که نمایانگر یک فایل ارائه است، ایجاد کنید.
auto presentation = MakeObject<Presentation>();

// در اینجا کاری انجام دهید...

// ارائه را در یک فایل ذخیره کنید.
presentation->Save(u"Output.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

## **ذخیره ارائه‌ها در جریان‌ها**

می‌توانید یک ارائه را به یک جریان ذخیره کنید با پاس کردن یک جریان خروجی به متد `Save` کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/). یک ارائه می‌تواند به انواع مختلفی از جریان‌ها نوشته شود. در مثال زیر، یک ارائه جدید ایجاد می‌کنیم و آن را به یک جریان فایل ذخیره می‌کنیم.

```cpp
// شیء کلاس Presentation را که نمایانگر یک فایل ارائه است، ایجاد کنید.
auto presentation = MakeObject<Presentation>();

auto fileStream = MakeObject<FileStream>(u"Output.pptx", FileMode::Create);

// ارائه را در جریان ذخیره کنید.
presentation->Save(fileStream, SaveFormat::Pptx);

presentation->Dispose();
fileStream->Close();
```

## **ذخیره ارائه‌ها با نوع نمای پیش‌تعریف‌شده**

Aspose.Slides به شما اجازه می‌دهد نمای اولیه‌ای را که PowerPoint هنگام باز شدن ارائه تولید شده استفاده می‌کند، از طریق کلاس [ViewProperties](https://reference.aspose.com/slides/fa/cpp/aspose.slides/viewproperties/) تنظیم کنید. از متد [set_LastView](https://reference.aspose.com/slides/fa/cpp/aspose.slides/viewproperties/set_lastview/) با مقداری از شناسنامه [ViewType](https://reference.aspose.com/slides/fa/cpp/aspose.slides/viewtype/) استفاده کنید.

```cpp
auto presentation = MakeObject<Presentation>();

presentation->get_ViewProperties()->set_LastView(ViewType::SlideMasterView);

presentation->Save(u"SlideMasterView.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **ذخیره ارائه‌ها در قالب Strict Office Open XML**

Aspose.Slides به شما امکان می‌دهد یک ارائه را در قالب Strict Office Open XML ذخیره کنید. هنگام ذخیره از کلاس [PptxOptions](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/pptxoptions/) استفاده کنید و ویژگی conformance آن را تنظیم کنید. اگر `Conformance.Iso29500_2008_Strict` را تنظیم کنید، فایل خروجی در قالب Strict Office Open XML ذخیره می‌شود.

مثال زیر یک ارائه ایجاد می‌کند و آن را در قالب Strict Office Open XML ذخیره می‌کند.

```cpp
auto options = MakeObject<PptxOptions>();
options->set_Conformance(Conformance::Iso29500_2008_Strict);

// شیء کلاس Presentation را که نمایانگر یک فایل ارائه است، ایجاد کنید.
auto presentation = MakeObject<Presentation>();

// ارائه را در قالب Strict Office Open XML ذخیره کنید.
presentation->Save(u"StrictOfficeOpenXml.pptx", SaveFormat::Pptx, options);
presentation->Dispose();
```

## **ذخیره ارائه‌ها در قالب Office Open XML در حالت Zip64**

یک فایل Office Open XML یک آرشیو ZIP است که محدودیت ۴ گیگابایت (۲^۳۲ بایت) برای اندازهٔ فشرده نشده هر فایل، اندازهٔ فشرده هر فایل و کل حجم آرشیو اعمال می‌کند و همچنین تعداد فایل‌ها را به ۶۵٬۵۳۵ (۲^۱۶‑۱) محدود می‌سازد. افزونه‌های فرمت ZIP64 این محدودیت‌ها را به ۲^۶۴ افزایش می‌دهند.

متد [IPptxOptions::set_Zip64Mode](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/ipptxoptions/set_zip64mode/) به شما امکان می‌دهد هنگام ذخیره یک فایل Office Open XML انتخاب کنید که چه زمانی از افزونه‌های فرمت ZIP64 استفاده شود.

این متد می‌تواند با حالت‌های زیر استفاده شود:

- `IfNecessary` فقط در صورتی که ارائه محدودیت‌های فوق را تجاوز کند از افزونه‌های ZIP64 استفاده می‌کند. این حالت پیش‌فرض است.
- `Never` هرگز از افزونه‌های ZIP64 استفاده نمی‌کند.
- `Always` همیشه از افزونه‌های ZIP64 استفاده می‌کند.

کد زیر نحوه ذخیره یک ارائه به صورت PPTX با فعال بودن افزونه‌های فرمت ZIP64 را نشان می‌دهد:

```cpp
auto pptxOptions = MakeObject<PptxOptions>();
pptxOptions->set_Zip64Mode(Zip64Mode::Always);

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

presentation->Save(u"OutputZip64.pptx", SaveFormat::Pptx, pptxOptions);
presentation->Dispose();
```

{{% alert title="NOTE" color="warning" %}}
زمانی که با `Zip64Mode.Never` ذخیره می‌کنید، اگر ارائه نتواند در قالب ZIP32 ذخیره شود، یک [PptxException](https://reference.aspose.com/slides/fa/cpp/aspose.slides/pptxexception/) پرتاب می‌شود.
{{% /alert %}}

## **ذخیره ارائه‌ها بدون به‌روزرسانی تصویر بند انگشت**

متد [PptxOptions::set_RefreshThumbnail](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/pptxoptions/set_refreshthumbnail/) تولید تصویر بند انگشت را هنگام ذخیره یک ارائه به PPTX کنترل می‌کند:

- اگر به `true` تنظیم شود، تصویر بند انگشت هنگام ذخیره به‌روزرسانی می‌شود. این مقدار پیش‌فرض است.
- اگر به `false` تنظیم شود، تصویر بند انگشت فعلی حفظ می‌شود. اگر ارائه تصویر بند انگشتی نداشته باشد، هیچ تصویر جدیدی تولید نمی‌شود.

در کد زیر، ارائه بدون به‌روزرسانی تصویر بند انگشت به PPTX ذخیره می‌شود.

```cpp
auto pptxOptions = MakeObject<PptxOptions>();
pptxOptions->set_RefreshThumbnail(false);

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

presentation->Save(u"Output.pptx", SaveFormat::Pptx, pptxOptions);
presentation->Dispose();
```

{{% alert title="Info" color="info" %}}
این گزینه به کاهش زمان مورد نیاز برای ذخیره یک ارائه در قالب PPTX کمک می‌کند.
{{% /alert %}}

## **به‌روزرسانی پیشرفت ذخیره به درصد**

رابط [IProgressCallback](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iprogresscallback/) از طریق متد `set_ProgressCallback` که توسط رابط [ISaveOptions](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/isaveoptions/) و کلاس انتزاعی [SaveOptions](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/saveoptions/) ارائه می‌شود، استفاده می‌شود. با `set_ProgressCallback` یک پیاده‌سازی از [IProgressCallback](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iprogresscallback/) را اختصاص دهید تا به‌روزرسانی‌های پیشرفت ذخیره به صورت درصد دریافت کنید.

کدهای زیر نشان می‌دهند چگونه از `IProgressCallback` استفاده شود.

```cpp
class ExportProgressHandler : public IProgressCallback
{
public:
    void Reporting(double progressValue)
    {
        // مقدار درصد پیشرفت را در اینجا استفاده کنید.
        int progress = static_cast<int>(progressValue);

        Console::WriteLine(u"{0}% of the file has been converted.", progress);
    }
};
```
```cpp
auto saveOptions = MakeObject<PdfOptions>();
saveOptions->set_ProgressCallback(MakeObject<ExportProgressHandler>());

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

presentation->Save(u"Output.pdf", SaveFormat::Pdf, saveOptions);
presentation->Dispose();
```

{{% alert title="Info" color="info" %}}
Aspose یک برنامه رایگان [PowerPoint Splitter](https://products.aspose.app/slides/fa/splitter) با استفاده از API خودش توسعه داده است. این برنامه به شما امکان می‌دهد یک ارائه را به چند فایل تقسیم کنید با ذخیره اسلایدهای منتخب به عنوان فایل‌های جدید PPTX یا PPT.
{{% /alert %}}

## **سؤال‌های متداول**

**آیا «ذخیره سریع» (ذخیره افزایشی) پشتیبانی می‌شود به‌طوری که فقط تغییرات نوشته شوند؟**

خیر. هر بار ذخیره، فایل هدف کاملاً جدید ساخته می‌شود؛ ذخیره افزایشی «ذخیره سریع» پشتیبانی نمی‌شود.

**آیا ذخیره یک نمونه Presentation از چندین سطحه (thread) به صورت thread‑safe است؟**

خیر. یک نمونهٔ [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) [thread‑safe نیست](/slides/fa/cpp/multithreading/); آن را فقط از یک سطحه ذخیره کنید.

**چه اتفاقی برای پیوندهای ابرمتنی و فایل‌های لینک شده خارجی هنگام ذخیره می‌افتد؟**

[پیوندهای ابرمتنی](/slides/fa/cpp/manage-hyperlinks/) حفظ می‌شوند. فایل‌های لینک شده خارجی (مانند ویدئوها با مسیرهای نسبی) به‌صورت خودکار کپی نمی‌شوند—اطمینان حاصل کنید مسیرهای مرجع در دسترس باقی بمانند.

**آیا می‌توانم فرادادهٔ سند (نویسنده، عنوان، شرکت، تاریخ) را تنظیم/ذخیره کنم؟**

بله. [خواص استاندارد سند](/slides/fa/cpp/presentation-properties/) پشتیبانی می‌شوند و هنگام ذخیره در فایل نوشته می‌شوند.