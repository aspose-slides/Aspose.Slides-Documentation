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
- شیء باینری
- C++
- Aspose.Slides
description: "یاد بگیرید چگونه ارائه‌های PowerPoint و OpenDocument را در C++ باز کنید، رموز عبور باز کردن را ارائه دهید، بارگذاری منابع را کنترل کنید و با Aspose.Slides برای C++ مصرف حافظه را کاهش دهید."
---
## **مقدمه**

[Aspose.Slides for C++](https://products.aspose.com/slides/fa/cpp/) می‌تواند ارائه‌های PowerPoint و OpenDocument را از فایل‌ها و جریان‌ها بارگذاری کند. پس از بارگذاری یک ارائه، می‌توانید ساختار آن را بررسی کنید، اسلایدها را ویرایش کنید، منابع را مدیریت کنید و آن را در قالب اصلی یا قالب پشتیبانی‌شده دیگر ذخیره نمایید.

رفتار بارگذاری می‌تواند از طریق کلاس [LoadOptions](https://reference.aspose.com/slides/fa/cpp/aspose.slides/loadoptions/) سفارشی شود. به عنوان مثال، می‌توانید رمز عبور باز کردن را فراهم کنید، اشیاء باینری بزرگ را خارج از حافظه نگه دارید، منابع خارجی را کنترل کنید یا داده‌های باینری توکار را حذف کنید.

## **باز کردن ارائه‌ها**

برای باز کردن یک ارائه موجود، مسیر فایل آن را به سازنده [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) بدهید. پس از استفاده، ارائه را آزاد کنید تا دستگیره‌های فایل، داده‌های موقت و سایر منابع به‌سرعت آزاد شوند.

مثال زیر در C++ نشان می‌دهد چگونه یک ارائه را باز کنید و تعداد اسلایدهای آن را به دست آورید:

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

## **باز کردن ارائه‌های دارای رمز عبور**

یک رمز عبور باز کردن، محتوای ارائه را رمزگذاری می‌کند. برای بارگذاری کامل ارائه، رمز عبور صحیح را به ‎[LoadOptions::set_Password](https://reference.aspose.com/slides/fa/cpp/aspose.slides/loadoptions/set_password/) بدهید و گزینه‌ها را به سازنده [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) پاس بدهید. بارگذاری در صورت نبودن یا نادرست بودن رمز عبور با شکست مواجه می‌شود.

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

برای تشخیص رمز عبور، اعتبارسنجی و جریان کارهای رمزنگاری، به ‎[Password‑Protect Presentations](/slides/fa/cpp/password-protected-presentation/) مراجعه کنید. اگر یک ارائهٔ رمزگذاری‌شده عمداً با ویژگی‌های عمومی سند ذخیره شده باشد، این ویژگی‌ها بدون نیاز به رمز عبور قابل خواندن‌اند؛ ببینید ‎[Manage Presentation Properties](/slides/fa/cpp/presentation-properties/).

## **باز کردن ارائه‌های بزرگ**

[LoadOptions::get_BlobManagementOptions](https://reference.aspose.com/slides/fa/cpp/aspose.slides/loadoptions/get_blobmanagementoptions/) کنترل می‌کند که Aspose.Slides چطور اشیاء باینری بزرگ مانند تصاویر، صدا و ویدئو را مدیریت کند. می‌توانید فایل منبع را قفل بمانید، اجازه فایل‌های موقت بدهید و مقدار داده BLOB نگه‌داشته‌شده در حافظه را محدود کنید.

کد زیر در C++ بارگذاری یک ارائهٔ بزرگ (به‌عنوان مثال ۲ GB) را نشان می‌دهد:

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

{{% alert color="info" title="توجه" %}}
با `PresentationLockingBehavior::KeepLocked`، فایل منبع تا زمان آزاد شدن شیء `Presentation` قفل می‌ماند. هنگام زنده بودن آن شیء، فایل منبع را جابه‌جا، بازنویسی یا حذف نکنید.

Aspose.Slides ممکن است محتویات یک جریان ورودی را هنگام بارگذاری کپی کند. برای ارائه‌های بزرگ، مسیر فایل عموماً کارآمدتر از یک جریان است. برای گزینه‌های اضافی ذخیره‌سازی و مدیریت حافظه، به ‎[Manage BLOBs](/slides/fa/cpp/manage-blob/) مراجعه کنید.
{{% /alert %}}

## **کنترل منابع خارجی**

[LoadOptions::set_ResourceLoadingCallback](https://reference.aspose.com/slides/fa/cpp/aspose.slides/loadoptions/set_resourceloadingcallback/) یک پیاده‌سازی از ‎[IResourceLoadingCallback](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iresourceloadingcallback/) را می‌پذیرد. این فراخوانی می‌تواند داده‌های جایگزین فراهم کند، یک منبع را تغییر مسیر دهد، از بارگذار پیش‌فرض استفاده کند یا منبع را نادیده بگیرد. این کار زمانی مفید است که ارائه‌ها شامل تصاویر خارجی باشند که باید بر اساس قوانین امنیتی یا ذخیره‌سازی خاص برنامه حل شوند.

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

## **بارگذاری ارائه‌ها بدون اشیاء باینری توکار**

یک ارائه ممکن است شامل داده‌های باینری توکار باشد که برنامه به آن نیاز ندارد یا نمی‌خواهد آن‌ها را نگه دارد. مثال‌ها شامل:

- پروژه‌های VBA، که از طریق ‎[IPresentation::get_VbaProject](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ipresentation/get_vbaproject/) در دسترس هستند؛
- داده‌های OLE توکار، که از طریق ‎[IOleEmbeddedDataInfo::get_EmbeddedFileData](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ioleembeddeddatainfo/get_embeddedfiledata/) در دسترس هستند؛
- داده‌های کنترل ActiveX، که از طریق ‎[IControl::get_ActiveXControlBinary](https://reference.aspose.com/slides/fa/cpp/aspose.slides/icontrol/get_activexcontrolbinary/) در دسترس هستند.

برای حذف این داده‌های باینری هنگام بارگذاری، `true` را به ‎[LoadOptions::set_DeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/fa/cpp/aspose.slides/loadoptions/set_deleteembeddedbinaryobjects/) بدهید. ارائهٔ بارگذاری‌شده را ذخیره کنید تا نتیجهٔ پاک‌سازی‌شده حفظ شود.

این گزینه خطر مواجهه با Payloadهای توکار ناخواسته را کاهش می‌دهد، اما یک سیستم کامل تشخیص بدافزار یا پاک‌سازی محتوا نیست.

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

## **سؤالات متداول**

**چگونه می‌توانم تشخیص دهم که یک فایل خراب است و نمی‌تواند باز شود؟**

Aspose.Slides در هنگام بارگذاری یک استثنای تجزیه یا قالبی می‌اندازد. این شکست را جدا از خطای رمز عبور نادرست مدیریت کنید تا برنامه بتواند علت را به‌دقت گزارش دهد.

**اگر فونت‌های لازم موجود نباشند چه می‌شود؟**

ارائه می‌تواند هنوز بارگذاری شود، اما رندر و خروجی ممکن است فونت‌ها را جایگزین کند. می‌توانید ‎[پیکربندی جایگزینی فونت](/slides/fa/cpp/font-substitution/) یا ‎[ارائه فونت‌های سفارشی](/slides/fa/cpp/custom-font/) را تنظیم کنید تا خروجی پیش‌بینی‌پذیرتر باشد.

**آیا بارگذاری یک ارائه، رسانه‌های توکار آن را نیز بارگذاری می‌کند؟**

صوت و ویدئوی توکار از طریق مدل شیء ارائه در دسترس می‌شوند. منابع خارجی بر اساس رفتار پیکربندی‌شدهٔ بارگذاری منابع حل می‌شوند و ممکن است در صورتی که مکان آن‌ها قابل دسترسی نباشد، در دسترس نباشند.