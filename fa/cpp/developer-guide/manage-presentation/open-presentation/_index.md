---
title: باز کردن ارائه‌ها در C++
linktitle: باز کردن ارائه
type: docs
weight: 20
url: /fa/cpp/open-presentation/
keywords:
- باز کردن PowerPoint
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
description: "یاد بگیرید چگونه ارائه‌های PowerPoint و OpenDocument را در C++ باز کنید، رمزهای عبور بازکننده را فراهم کنید، بارگذاری منابع را کنترل کنید و با Aspose.Slides برای C++ مصرف حافظه را کاهش دهید."
---
## **مقدمه**

[Aspose.Slides for C++](https://products.aspose.com/slides/fa/cpp/) می‌تواند ارائه‌های PowerPoint و OpenDocument را از فایل‌ها و جریان‌ها بارگذاری کند. پس از بارگذاری یک ارائه، می‌توانید ساختار آن را بررسی کنید، اسلایدها را ویرایش کنید، منابع را مدیریت کنید و آن را در قالب اصلی یا قالب دیگری که پشتیبانی می‌شود ذخیره کنید.

رفتار بارگذاری می‌تواند از طریق کلاس [LoadOptions](https://reference.aspose.com/slides/fa/cpp/aspose.slides/loadoptions/) سفارشی شود. به عنوان مثال، می‌توانید یک رمز عبور بازکننده ارائه دهید، اشیای باینری بزرگ را خارج از حافظه نگه دارید، منابع خارجی را کنترل کنید یا داده‌های باینری جاسازی‌شده را حذف کنید.

## **باز کردن ارائه‌ها**

پس از بارگذاری یک فایل یا جریان، می‌توانید [فرمت اصلی ارائه را تعیین کنید](/slides/fa/cpp/detect-presentation-source-format/) تا انتخاب کنید برنامه شما چگونه آن را پردازش می‌کند.

برای باز کردن یک ارائه موجود، مسیر فایل آن را به سازندهٔ [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) ارسال کنید. پس از استفاده، ارائه را حذف (Dispose) کنید تا دسته‌های فایل، داده‌های موقت و سایر منابع به‌سرعت آزاد شوند.

مثال زیر به زبان C++ نشان می‌دهد چگونه یک ارائه را باز کنید و تعداد اسلایدهای آن را دریافت کنید:

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

Console::WriteLine(u"Slide count: {0}", presentation->get_Slides()->get_Count());

presentation->Dispose();
```

## **باز کردن ارائه‌های محافظت‌شده با رمز عبور**

یک رمز عبور بازکننده محتویات ارائه را رمزنگاری می‌کند. برای بارگذاری کامل ارائه، رمز عبور صحیح را به [LoadOptions::set_Password](https://reference.aspose.com/slides/fa/cpp/aspose.slides/loadoptions/set_password/) پاس بدهید و گزینه‌ها را به سازندهٔ [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) ارسال کنید. اگر رمز عبور موجود نباشد یا نادرست باشد، بارگذاری شکست می‌خورد.

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_Password(u"open_password");

auto presentation = MakeObject<Presentation>(u"encrypted-presentation.pptx", loadOptions);

Console::WriteLine(u"Slide count: {0}", presentation->get_Slides()->get_Count());

presentation->Dispose();
```

برای شناسایی رمز عبور، اعتبارسنجی و جریان‌های کاری رمزنگاری، ببینید [Password-Protect Presentations](/slides/fa/cpp/password-protected-presentation/). اگر یک ارائهٔ رمزگذاری‌شده عمداً با ویژگی‌های عمومی سند ذخیره شده باشد، می‌توانید این ویژگی‌ها را بدون رمز عبور بخوانید؛ رجوع کنید به [Manage Presentation Properties](/slides/fa/cpp/presentation-properties/).

## **باز کردن ارائه‌های بزرگ**

[LoadOptions::get_BlobManagementOptions](https://reference.aspose.com/slides/fa/cpp/aspose.slides/loadoptions/get_blobmanagementoptions/) نحوهٔ مدیریت اشیای باینری بزرگ مثل تصاویر، صدا و ویدیو توسط Aspose.Slides را کنترل می‌کند. می‌توانید فایل منبع را قفل بمانید، فایل‌های موقت را اجازه دهید و میزان داده‌های BLOB نگهداری شده در حافظه را محدود کنید.

کد زیر به زبان C++ نشان می‌دهد چطور یک ارائهٔ بزرگ (به‌عنوان مثال ۲ گیگابایت) را بارگذاری کنید:

```cpp
#include <DOM/ISlide.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <IBlobManagementOptions.h>
#include <PresentationLockingBehavior.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

const String filePath = u"large-presentation.pptx";

auto loadOptions = MakeObject<LoadOptions>();
auto blobOptions = loadOptions->get_BlobManagementOptions();
blobOptions->set_PresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);
blobOptions->set_IsTemporaryFilesAllowed(true);
blobOptions->set_MaxBlobsBytesInMemory(10 * 1024 * 1024);

auto presentation = MakeObject<Presentation>(filePath, loadOptions);

presentation->get_Slide(0)->set_Name(u"Large presentation");
presentation->Save(u"large-presentation-copy.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

{{% alert color="info" title="نکته" %}}
با استفاده از `PresentationLockingBehavior::KeepLocked`، فایل منبع تا زمانی که شیء `Presentation` حذف شود، قفل می‌ماند. تا زمانی که این شیء زنده است، فایل منبع را جابجا، بازنویسی یا حذف نکنید.

Aspose.Slides ممکن است هنگام بارگذاری، محتویات یک جریان ورودی را کپی کند. برای ارائه‌های بزرگ، مسیر فایل به‌طور کلی کارآمدتر از یک جریان است. برای گزینه‌های بیشتر ذخیره‌سازی و مدیریت حافظه، به [Manage BLOBs](/slides/fa/cpp/manage-blob/) مراجعه کنید.
{{% /alert %}}

## **کنترل منابع خارجی**

[LoadOptions::set_ResourceLoadingCallback](https://reference.aspose.com/slides/fa/cpp/aspose.slides/loadoptions/set_resourceloadingcallback/) یک پیاده‌سازی از [IResourceLoadingCallback](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iresourceloadingcallback/) را می‌پذیرد. این callback می‌تواند داده‌های جایگزین ارائه دهد، یک منبع را بازنشانی کند، از لودر پیش‌فرض استفاده کند یا منبع را نادیده بگیرد. این ویژگی زمانی مفید است که ارائه‌ها شامل تصاویر خارجی باشند که باید بر اساس قوانین امنیتی یا ذخیره‌سازی مخصوص برنامه حل شوند.

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <IResourceLoadingArgs.h>
#include <IResourceLoadingCallback.h>
#include <ResourceLoadingAction.h>
#include <system/console.h>
#include <system/io/file.h>
#include <system/string_comparison.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

class ImageLoadingHandler : public IResourceLoadingCallback
{
public:
    ResourceLoadingAction ResourceLoading(SharedPtr<IResourceLoadingArgs> args) override
    {
        auto isJpeg = args->get_OriginalUri().EndsWith(u".jpg", StringComparison::OrdinalIgnoreCase);
        if (!isJpeg || !File::Exists(u"approved-image.jpg"))
        {
            return ResourceLoadingAction::Skip;
        }

        auto imageData = File::ReadAllBytes(u"approved-image.jpg");
        args->SetData(imageData);
        return ResourceLoadingAction::UserProvided;
    }
};

auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_ResourceLoadingCallback(MakeObject<ImageLoadingHandler>());

auto presentation = MakeObject<Presentation>(u"presentation-with-external-images.pptx", loadOptions);
Console::WriteLine(u"Slide count: {0}", presentation->get_Slides()->get_Count());

presentation->Dispose();
```

## **بارگذاری ارائه‌ها بدون اشیای باینری جاسازی‌شده**

یک ارائه ممکن است شامل داده‌های باینری جاسازی‌شده باشد که برنامه نیاز ندارد یا نمی‌خواهد نگه دارد. مثال‌ها عبارتند از:

- پروژه‌های VBA، در دسترس از طریق [IPresentation::get_VbaProject](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ipresentation/get_vbaproject/);
- داده‌های OLE جاسازی‌شده، در دسترس از طریق [IOleEmbeddedDataInfo::get_EmbeddedFileData](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ioleembeddeddatainfo/get_embeddedfiledata/);
- داده‌های کنترل ActiveX، در دسترس از طریق [IControl::get_ActiveXControlBinary](https://reference.aspose.com/slides/fa/cpp/aspose.slides/icontrol/get_activexcontrolbinary/).

مقدار `true` را به [LoadOptions::set_DeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/fa/cpp/aspose.slides/loadoptions/set_deleteembeddedbinaryobjects/) منتقل کنید تا این داده‌های باینری هنگام بارگذاری حذف شوند. برای نگهداری نتیجهٔ تصفیه‌شده، ارائهٔ بارگذاری‌شده را ذخیره کنید.

این گزینه خطر مواجهه با بارهای جاسازی‌شدهٔ ناخواسته را کاهش می‌دهد، اما یک سیستم کامل برای تشخیص بدافزار یا تصفیهٔ محتوا نیست.

```cpp
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_DeleteEmbeddedBinaryObjects(true);

auto presentation = MakeObject<Presentation>(u"presentation-with-embedded-data.pptx", loadOptions);

presentation->Save(u"presentation-without-embedded-data.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

## **سوالات متداول**

**چگونه می‌توانم تشخیص دهم که فایل خراب است و نمی‌توان آن را باز کرد؟**

Aspose.Slides هنگام بارگذاری یک استثنای تجزیه یا قالب‌بندی ایجاد می‌کند. این شکست را جدا از خطای رمز عبور نادرست مدیریت کنید تا برنامه بتواند دلیل را به‌دقت گزارش دهد.

**اگر قلم‌های مورد نیاز موجود نباشند چه می‌شود؟**

ارائه هنوز می‌تواند بارگذاری شود، اما رندرینگ و خروجی ممکن است قلم‌ها را جایگزین کند. می‌توانید [پیکربندی جایگزینی قلم](/slides/fa/cpp/font-substitution/) یا [ارائه قلم‌های سفارشی](/slides/fa/cpp/custom-font/) کنید تا خروجی پیش‌بینی‌پذیرتر باشد.

**آیا بارگذاری یک ارائه، رسانه‌های جاسازی‌شده را نیز بارگذاری می‌کند؟**

صوت و ویدیوهای جاسازی‌شده از طریق مدل شیء ارائه در دسترس می‌شوند. منابع خارجی بر اساس رفتار پیکربندی‌شدهٔ بارگذاری منابع حل می‌شوند و در صورتی که مکان‌های آنها قابل دسترسی نباشد، ممکن است در دسترس نباشند.