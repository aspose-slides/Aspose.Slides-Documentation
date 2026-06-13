---
title: باز کردن ارائه‌ها در C++
linktitle: باز کردن ارائه
type: docs
weight: 20
url: /fa/cpp/open-presentation/
keywords:
- باز کردن پاورپوینت
- باز کردن OpenDocument
- باز کردن ارائه
- باز کردن PPTX
- باز کردن PPT
- باز کردن ODP
- بارگذاری ارائه
- بارگذاری PPTX
- بارگذاری PPT
- بارگذاری ODP
- ارائه محافظت‌شده
- ارائه بزرگ
- منبع خارجی
- شی باینری
- C++
- Aspose.Slides
description: "به راحتی ارائه‌های PowerPoint (.pptx، .ppt) و OpenDocument (.odp) را با Aspose.Slides برای C++ باز کنید—سرعت بالا، قابل اطمینان و کامل."
---
## **مقدمه**

فراتر از ایجاد ارائه‌های PowerPoint از صفر، Aspose.Slides همچنین به شما امکان باز کردن ارائه‌های موجود را می‌دهد. پس از بارگذاری یک ارائه، می‌توانید اطلاعات آن را بازیابی کنید، محتوای اسلایدها را ویرایش کنید، اسلایدهای جدید اضافه کنید، اسلایدهای موجود را حذف کنید و موارد دیگر.

## **باز کردن ارائه‌ها**

برای باز کردن یک ارائه موجود، یک شی از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) ایجاد کنید و مسیر فایل را به سازندهٔ آن پاس دهید.

مثال زیر به زبان C++ نشان می‌دهد چگونه یک ارائه را باز کنید و تعداد اسلایدهای آن را بدست آورید:

```cpp
// یک شی از کلاس Presentation ایجاد کنید و مسیر فایلی را به سازنده‌اش پاس دهید.
auto presentation = MakeObject<Presentation>(u"Sample.pptx");

// تعداد کل اسلایدهای موجود در ارائه را چاپ کنید.
Console::WriteLine(presentation->get_Slides()->get_Count());

presentation->Dispose();
```

## **باز کردن ارائه‌های دارای رمز عبور**

هنگامی که نیاز به باز کردن یک ارائه دارای رمز عبور دارید، رمز عبور را از طریق متد [set_Password](https://reference.aspose.com/slides/fa/cpp/aspose.slides/loadoptions/set_password/) کلاس [LoadOptions](https://reference.aspose.com/slides/fa/cpp/aspose.slides/loadoptions/) پاس دهید تا آن را رمزگشایی و بارگذاری کنید. کد C++ زیر این عملیات را نشان می‌دهد:

```cpp
auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_Password(u"YOUR_PASSWORD");

auto presentation = MakeObject<Presentation>(u"Sample.pptx", loadOptions);
    
// عملیات روی ارائهٔ رمزگشایی‌شده را انجام دهید.

presentation->Dispose();
```

## **باز کردن ارائه‌های بزرگ**

Aspose.Slides گزینه‌هایی فراهم می‌کند—به‌ویژه متد [get_BlobManagementOptions](https://reference.aspose.com/slides/fa/cpp/aspose.slides/loadoptions/get_blobmanagementoptions/) در کلاس [LoadOptions](https://reference.aspose.com/slides/fa/cpp/aspose.slides/loadoptions/)—تا به شما در بارگذاری ارائه‌های بزرگ کمک کند.

کد C++ زیر بارگذاری یک ارائه بزرگ (به‌عنوان مثال ۲ گیگابایت) را نشان می‌دهد:

```cpp
auto filePath = u"LargePresentation.pptx";

auto loadOptions = MakeObject<LoadOptions>();
// رفتار KeepLocked را انتخاب کنید—فایل ارائه برای طول عمر شی Presentation قفل می‌ماند
// اما نیازی به بارگذاری در حافظه یا کپی شدن به یک فایل موقت ندارد.
loadOptions->get_BlobManagementOptions()->set_PresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);
loadOptions->get_BlobManagementOptions()->set_IsTemporaryFilesAllowed(true);
loadOptions->get_BlobManagementOptions()->set_MaxBlobsBytesInMemory(10 * 1024 * 1024); // ۱۰ مگابایت

auto presentation = MakeObject<Presentation>(filePath, loadOptions);

// ارائه بزرگ بارگذاری شد و می‌تواند استفاده شود، در حالی که مصرف حافظه کم باقی می‌ماند.

// تغییراتی در ارائه اعمال کنید.
presentation->get_Slide(0)->set_Name(u"Large presentation");

// ارائه را در فایلی دیگر ذخیره کنید. در طول این عملیات مصرف حافظه کم می‌ماند.
presentation->Save(u"LargePresentation-copy.pptx", SaveFormat::Pptx);

// این کار را نکنید! یک استثنا I/O پرتاب می‌شود زیرا فایل تا زمانی که شی Presentation پاک شود قفل است.
File::Delete(filePath);

presentation->Dispose();

// در اینجا انجام دادن این کار مشکلی ندارد. فایل منبع دیگر توسط شی Presentation قفل نیست.
File::Delete(filePath);
```

{{% alert color="info" title="Info" %}}
برای دور زدن برخی محدودیت‌ها هنگام کار با جریان‌ها، Aspose.Slides ممکن است محتویات یک جریان را کپی کند. بارگذاری یک ارائه بزرگ از یک جریان باعث کپی شدن ارائه می‌شود و می‌تواند سرعت بارگذاری را کاهش دهد. بنابراین، هنگامی که نیاز به بارگذاری یک ارائه بزرگ دارید، به‌شدت توصیه می‌کنیم از مسیر فایل ارائه به‌جای جریان استفاده کنید.

هنگام ایجاد یک ارائه که شامل اشیای بزرگ (ویدیو، صدا، تصاویر با وضوح بالا و غیره) است، می‌توانید از [BLOB management](/slides/fa/cpp/manage-blob/) برای کاهش مصرف حافظه استفاده کنید.
{{%/alert %}}

## **کنترل منابع خارجی**

Aspose.Slides اینترفیس [IResourceLoadingCallback](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iresourceloadingcallback/) را فراهم می‌کند که به شما امکان مدیریت منابع خارجی را می‌دهد. کد C++ زیر نشان می‌دهد چگونه از اینترفیس `IResourceLoadingCallback` استفاده کنید:

```cpp
class ImageLoadingHandler : public IResourceLoadingCallback
{
public:
    ResourceLoadingAction ResourceLoading(SharedPtr<IResourceLoadingArgs> args) override
    {
        if (args->get_OriginalUri().EndsWith(u".jpg"))
        {
            try
            {
                // یک تصویر جایگزین بارگذاری کنید.
                auto imageData = File::ReadAllBytes(u"aspose-logo.jpg");
                args->SetData(imageData);
                return ResourceLoadingAction::UserProvided;
            }
            catch (Exception&)
            {
                return ResourceLoadingAction::Skip;
            }
        }
        else if (args->get_OriginalUri().EndsWith(u".png"))
        {
            // آدرس URL جایگزین را تنظیم کنید.
            args->set_Uri(u"http://www.google.com/images/logos/ps_logo2.png");
            return ResourceLoadingAction::Default;
        }

        // همهٔ تصاویر دیگر را نادیده بگیرید.
        return ResourceLoadingAction::Skip;
    }
};
```

```cpp
auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_ResourceLoadingCallback(MakeObject<ImageLoadingHandler>());

auto presentation = MakeObject<Presentation>(u"Sample.pptx", loadOptions);
```

## **بارگذاری ارائه‌ها بدون اشیای باینری توکار**

یک ارائه PowerPoint می‌تواند انواع زیر از اشیای باینری توکار را شامل شود:

- پروژه VBA (قابل دسترسی از طریق [IPresentation::get_VbaProject](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ipresentation/get_vbaproject/));
- داده‌های توکار شیء OLE (قابل دسترسی از طریق [IOleEmbeddedDataInfo::get_EmbeddedFileData](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ioleembeddeddatainfo/get_embeddedfiledata/));
- داده‌های باینری کنترل ActiveX (قابل دسترسی از طریق [IControl::get_ActiveXControlBinary](https://reference.aspose.com/slides/fa/cpp/aspose.slides/icontrol/get_activexcontrolbinary/)).

با استفاده از متد [ILoadOptions::set_DeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iloadoptions/set_deleteembeddedbinaryobjects/) می‌توانید یک ارائه را بدون هیچ‌یک از اشیای باینری توکار بارگذاری کنید.

این متد برای حذف محتوای باینری که ممکن است مخرب باشد مفید است. کد C++ زیر نحوه بارگذاری یک ارائه بدون هیچ محتوای باینری توکار را نشان می‌دهد:

```cpp
auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_DeleteEmbeddedBinaryObjects(true);

auto presentation = MakeObject<Presentation>(u"malware.ppt", loadOptions);

// Perform operations on the presentation.

presentation->Dispose();
```

## **پرسش‌های متداول**

**چگونه می‌توانم بفهمم که یک فایل خراب است و نمی‌توان آن را باز کرد؟**

در طول بارگذاری، یک استثنای تجزیه/اعتبارسنجی قالب دریافت خواهید کرد. چنین خطاهایی اغلب به ساختار ZIP نامعتبر یا رکوردهای خراب PowerPoint اشاره می‌کنند.

**اگر فونت‌های مورد نیاز هنگام باز کردن موجود نباشند چه می‌شود؟**

فایل باز می‌شود، اما سپس ممکن است در [rendering/export](/slides/fa/cpp/convert-presentation/) فونت‌ها جایگزین شوند. برای جایگزینی فونت‌ها می‌توانید [Configure font substitutions](/slides/fa/cpp/font-substitution/) یا [add the required fonts](/slides/fa/cpp/custom-font/) را به محیط زمان اجرا اضافه کنید.

**در مورد رسانه‌های توکار (ویدیو/صدا) هنگام باز کردن چه می‌شود؟**

آن‌ها به عنوان منابع ارائه در دسترس قرار می‌گیرند. اگر رسانه‌ها از طریق مسیرهای خارجی ارجاع داده شوند، اطمینان حاصل کنید که این مسیرها در محیط شما قابل دسترسی باشند؛ در غیر این صورت ممکن است در [rendering/export](/slides/fa/cpp/convert-presentation/) رسانه‌ها حذف شوند.