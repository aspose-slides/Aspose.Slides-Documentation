---
title: محافظت نوشتن ارائه‌ها در C++
linktitle: محافظت نوشتن
type: docs
weight: 25
url: /fa/cpp/write-protected-presentation/
keywords:
- محافظت نوشتن
- محافظت نوشتن پاورپوینت
- رمز عبور برای تغییر
- محدود کردن ویرایش ارائه
- حذف محافظت نوشتن
- اعتبارسنجی رمز عبور تغییر
- پاورپوینت
- ارائه
- C++
- Aspose.Slides
description: "تنظیم، شناسایی، اعتبارسنجی و حذف رمزهای محافظت نوشتن در ارائه‌های PowerPoint PPT و PPTX با استفاده از Aspose.Slides برای C++."
---
## **مقدمه**

رمز عبور محافظت از نوشتن، تغییر یک ارائه را محدود می‌کند اما محتویات آن را رمزنگاری نمی‌کند. کاربران می‌توانند یک ارائه محافظت‌شده از نوشتن را بدون رمز عبور بارگذاری و مشاهده کنند. بسته به برنامه، ممکن است بتوانند محتوا را ویرایش کرده و تحت نامی دیگر ذخیره کنند، بنابراین محافظت از نوشتن نباید به عنوان یک مکانیزم محرمانگی در نظر گرفته شود.

یک رمز عبور باز کردن هدف متفاوتی دارد: ارائه را رمزنگاری می‌کند و برای بارگذاری محتوا نیاز است. برای رمزنگاری یک ارائه یا اعتبارسنجی رمز عبور باز کردن، به [محافظت با رمز عبور از ارائه‌ها](/slides/fa/cpp/password-protected-presentation/) مراجعه کنید.

جریان‌های کاری در این مقاله برای هر دو نوع ارائه PPT و PPTX اعمال می‌شود. مثال‌ها از فایل‌های PPTX استفاده می‌کنند؛ هنگام ذخیره به PPT، از پسوند `.ppt` و قالب ذخیره‌سازی PPT مربوطه استفاده کنید.

## **تنظیم محافظت نوشتن برای یک ارائه**

از [IProtectionManager::SetWriteProtection](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iprotectionmanager/setwriteprotection/) برای اختصاص یک رمز عبور برای تغییر یک ارائه استفاده کنید. ذخیره‌سازی ارائه، تنظیم محافظت را حفظ می‌کند.

مثال زیر محافظت نوشتن را برای یک ارائه PPTX تنظیم می‌کند:

```cpp
#include <DOM/IProtectionManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->SetWriteProtection(u"modify_password");
presentation->Save(u"write-protected-pres.pptx", SaveFormat::Pptx);
```

## **بارگیری یک ارائه محافظت‌شده از نوشتن**

از آنجا که محافظت نوشتن محتوا را رمزنگاری نمی‌کند، برای بارگذاری ارائه نیازی به رمز عبور نیست. رمز عبور فقط زمانی که اعتبارسنجی مجوز تغییر ارائه محافظت‌شده انجام می‌شود، مورد نیاز است.

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"write-protected-pres.pptx");

Console::WriteLine(u"Slide count: {0}", presentation->get_Slides()->get_Count());
```

رمز عبور محافظت نوشتن را به [LoadOptions::set_Password](https://reference.aspose.com/slides/fa/cpp/aspose.slides/loadoptions/set_password/) پاس ندهید. این ویژگی یک رمز عبور باز کردن برای محتوای رمزنگاری‌شده می‌پذیرد. اگر یک ارائه هر دو نوع محافظت را داشته باشد، رمز عبور باز کردن را برای بارگذاری ارائه ارائه دهید و رمز عبور محافظت نوشتن را به‌طور جداگانه مدیریت کنید.

## **حذف محافظت نوشتن از یک ارائه**

از [IProtectionManager::RemoveWriteProtection](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iprotectionmanager/removewriteprotection/) برای حذف محدودیت تغییر استفاده کنید، سپس ارائه را ذخیره کنید.

```cpp
#include <DOM/IProtectionManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"write-protected-pres.pptx");

presentation->get_ProtectionManager()->RemoveWriteProtection();
presentation->Save(u"write-protection-removed.pptx", SaveFormat::Pptx);
```

## **بررسی اینکه آیا یک ارائه محافظت نوشتن دارد یا نه**

برای بررسی یک فایل بدون ایجاد یک نمونه کامل از [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/)، [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) را فراخوانی کنید و [IPresentationInfo::get_IsWriteProtected](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ipresentationinfo/get_iswriteprotected/) را بررسی کنید. این ویژگی از [NullableBool](https://reference.aspose.com/slides/fa/cpp/aspose.slides/nullablebool/) استفاده می‌کند و هنگام یافتن محافظت نوشتن مقدار `NullableBool::True` را برمی‌گرداند.

```cpp
#include <DOM/IPresentationInfo.h>
#include <DOM/NullableBool.h>
#include <DOM/PresentationFactory.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(u"write-protected-pres.pptx");

if (presentationInfo->get_IsWriteProtected() == NullableBool::True)
{
    Console::WriteLine(u"The presentation is write protected.");
}
else
{
    Console::WriteLine(u"Write protection was not detected.");
}
```

بارگذاری جریان‌وار از [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) همان اطلاعات را برای ارائه‌ای که به‌صورت جریان (stream) فراهم می‌شود، ارائه می‌دهد.

## **اعتبارسنجی رمز عبور محافظت نوشتن**

از [IPresentationInfo::CheckWriteProtection](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ipresentationinfo/checkwriteprotection/) برای اعتبارسنجی رمز عبور تغییر بدون بارگذاری کامل ارائه استفاده کنید. ابتدا [IPresentationInfo::get_IsWriteProtected](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ipresentationinfo/get_iswriteprotected/) را بررسی کنید تا برنامه فقط زمانی که محافظت نوشتن موجود است، درخواست یا اعتبارسنجی رمز عبور را انجام دهد.

```cpp
#include <DOM/IPresentationInfo.h>
#include <DOM/NullableBool.h>
#include <DOM/PresentationFactory.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(u"write-protected-pres.pptx");

if (presentationInfo->get_IsWriteProtected() != NullableBool::True)
{
    Console::WriteLine(u"The presentation is not write protected.");
}
else if (presentationInfo->CheckWriteProtection(u"modify_password"))
{
    Console::WriteLine(u"The write-protection password is correct.");
}
else
{
    Console::WriteLine(u"The write-protection password is incorrect.");
}
```

[IPresentationInfo::CheckWriteProtection](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ipresentationinfo/checkwriteprotection/) فقط رمز عبور محافظت نوشتن را اعتبارسنجی می‌کند. این روش رمز عبور باز کردن را اعتبارسنجی نمی‌کند و تعیین نمی‌کند که آیا محتوای رمزنگاری‌شده می‌تواند بارگذاری شود یا نه. در مقابل، [IPresentationInfo::CheckPassword](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ipresentationinfo/checkpassword/) فقط یک رمز عبور باز کردن را اعتبارسنجی می‌کند. اگر یک ارائه کامل قبلاً بارگذاری شده باشد، [IProtectionManager::CheckWriteProtection](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iprotectionmanager/checkwriteprotection/) بررسی معادل محافظت نوشتن را از طریق مدیر محافظت خود ارائه می‌دهد.

در برنامه‌های تولیدی، رمزهای عبور را لاگ نکنید و در پیام‌های تشخیصی وارد نکنید. از تلاش‌های تکراری و غیرضروری برای اعتبارسنجی جلوگیری کنید و رمزهای عبور را در حافظه تنها به مدت لازم نگه دارید.

{{% alert color="info" title="همچنین ببینید" %}}
- [محافظت با رمز عبور از ارائه‌ها](/slides/fa/cpp/password-protected-presentation/)
- [ارائه‌های فقط-خواندنی](/slides/fa/cpp/read-only-presentation/)
- [امضای دیجیتال در پاورپوینت](/slides/fa/cpp/digital-signature-in-powerpoint/)
{{% /alert %}}

## **سوالات متداول**

**آیا محافظت نوشتن یک ارائه را رمزنگاری می‌کند؟**
خیر. این ویژگی فقط تغییرات را محدود می‌کند اما محتوای ارائه برای بارگذاری و نمایش در دسترس باقی می‌ماند.

**آیا رمز عبور محافظت نوشتن برای باز کردن یک ارائه ضروری است؟**
خیر. فقط یک رمز عبور باز کردن برای بارگذاری محتوای رمزنگاری‌شده ارائه لازم است.

**آیا یک ارائه می‌تواند همزمان یک رمز عبور باز کردن و یک رمز عبور محافظت نوشتن داشته باشد؟**
بله. رمز عبور باز کردن را از طریق گزینه‌های بارگذاری برای باز کردن ارائه رمزنگاری‌شده فراهم کنید و رمز عبور محافظت نوشتن را به‌ طور جداگانه هنگام نیاز به مجوز تغییر اعتبارسنجی نمایید.