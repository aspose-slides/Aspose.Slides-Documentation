---
title: محافظت از ارائه‌ها با رمز عبور در C++
linktitle: حفاظت از رمز عبور
type: docs
weight: 20
url: /fa/cpp/password-protected-presentation/
keywords:
- ارائه محافظت‌شده با رمز عبور
- رمز عبور بازشدن
- رمزگذاری پاورپوینت
- رمزگشایی پاورپوینت
- اعتبارسنجی رمز عبور ارائه
- بررسی رمز عبور ارائه
- باز کردن ارائهٔ رمزگذاری‌شده
- حذف رمزگذاری
- پاورپوینت
- PPT
- PPTX
- ارائه
- C++
- Aspose.Slides
description: "رمزگذاری، شناسایی، اعتبارسنجی، باز کردن و رمزگشایی ارائه‌های پاورپوینت PPT و PPTX محافظت‌شده با رمز عبور در C++ با Aspose.Slides."
---
## **مرور کلی**

یک رمز عبور بازشدن یک ارائه را رمزگذاری می‌کند. برای بارگذاری و مشاهدهٔ محتوای ارائه، رمز عبور صحیح لازم است، بنابراین این حفاظت محرمانگی را فراهم می‌کند.

رمز عبور بازشدن متفاوت از رمز عبور محافظت نوشتن است. محافظت نوشتن تغییرات را محدود می‌کند اما محتوای ارائه را رمزگذاری نمی‌کند و مانع بارگذاری ارائه نمی‌شود. برای مدیریت رمزهای عبور برای ویرایش ارائه‌ها، به [محافظت نوشتن ارائه‌ها](/slides/fa/cpp/write-protected-presentation/) مراجعه کنید.

جریان‌های کاری زیر برای ارائه‌های PPT و PPTX اعمال می‌شوند. مثال‌ها از هر دو قالب استفاده می‌کنند که رفتار مبتنی بر فایل و مبتنی بر جریان برای آن‌ها مهم است.

## **رمزگذاری یک ارائه با رمز عبور بازشدن**

از [IProtectionManager::Encrypt](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iprotectionmanager/encrypt/) برای اختصاص یک رمز عبور بازشدن استفاده کنید. سپس از [IPresentation::Save](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ipresentation/save/) برای ذخیرهٔ ارائهٔ رمزگذاری‌شده استفاده کنید.

مثال زیر یک ارائهٔ PPTX را رمزگذاری می‌کند:

```cpp
#include <DOM/IProtectionManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->Encrypt(u"open_password");
presentation->Save(u"encrypted-pres.pptx", SaveFormat::Pptx);
```

## **بارگذاری یک ارائهٔ رمزگذاری‌شده**

[LoadOptions::set_Password](https://reference.aspose.com/slides/fa/cpp/aspose.slides/loadoptions/set_password/) را به رمز عبور بازشدن تنظیم کنید و گزینه‌ها را هنگام بارگذاری فایل به [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) پاس بدهید. بارگذاری زمانی که رمز عبور بازشدن لازم است اما رمز ارائه‌شده وجود ندارد یا نادرست است، شکست می‌خورد.

```cpp
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"open_password");

auto presentation = System::MakeObject<Presentation>(u"encrypted-pres.pptx", loadOptions);

// با ارائهٔ رمزگشای شده کار کنید.
```

## **حذف رمزگذاری از یک ارائه**

ارائه را با رمز عبور بازشدن آن بارگذاری کنید، [IProtectionManager::RemoveEncryption](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iprotectionmanager/removeencryption/) را فراخوانی کنید و نتیجه را ذخیره کنید. ارائهٔ ذخیره‌شده سپس می‌تواند بدون رمز عبور بارگذاری شود.

```cpp
#include <DOM/IProtectionManager.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"open_password");

auto presentation = System::MakeObject<Presentation>(u"encrypted-pres.pptx", loadOptions);

presentation->get_ProtectionManager()->RemoveEncryption();
presentation->Save(u"encryption-removed.pptx", SaveFormat::Pptx);
```

## **اعتبارسنجی یک رمز عبور بازشدن قبل از بارگذاری**

از [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) برای دریافت [IPresentationInfo](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ipresentationinfo/) بدون ایجاد یک نمونهٔ کامل از ارائه استفاده کنید. قبل از درخواست یا اعتبارسنجی رمز عبور، [IPresentationInfo::get_IsPasswordProtected](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ipresentationinfo/get_ispasswordprotected/) را بررسی کنید. هنگامی که حفاظت وجود دارد، مقدار ارائه‌شده را با [IPresentationInfo::CheckPassword](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ipresentationinfo/checkpassword/) اعتبارسنجی کنید.

### **جریان کاری مسیر فایل**

مثال زیر یک رمز عبور بازشدن را برای فایل PPTX اعتبارسنجی می‌کند، مقدار اعتبارسنجی‌شده را به [LoadOptions::set_Password](https://reference.aspose.com/slides/fa/cpp/aspose.slides/loadoptions/set_password/) می‌گذارد و سپس ارائهٔ کامل را بارگذاری می‌کند:

```cpp
#include <DOM/IPresentationInfo.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <DOM/PresentationFactory.h>
#include <system/console.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

String filePath = u"protected-presentation.pptx";
String password = u"open_password";
auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(filePath);

if (!presentationInfo->get_IsPasswordProtected())
{
    Console::WriteLine(u"The presentation does not have an opening password.");
}
else if (!presentationInfo->CheckPassword(password))
{
    Console::WriteLine(u"The opening password is incorrect.");
}
else
{
    auto loadOptions = MakeObject<LoadOptions>();
    loadOptions->set_Password(password);
    auto presentation = MakeObject<Presentation>(filePath, loadOptions);

    Console::WriteLine(u"The presentation was validated and loaded successfully.");
}
```

### **جریان کاری جریان**

بارگذاری بیشینهٔ [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) همان جریان کاری را فراهم می‌کند. موقعیت یک جریان قابل جستجو را قبل از بارگذاری ارائهٔ کامل از آن جریان بازنشانی کنید.

مثال زیر از یک فایل PPT استفاده می‌کند:

```cpp
#include <DOM/IPresentationInfo.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <DOM/PresentationFactory.h>
#include <system/console.h>
#include <system/io/file.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

String password = u"open_password";
auto presentationStream = File::OpenRead(u"protected-presentation.ppt");
auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(presentationStream);

if (!presentationInfo->get_IsPasswordProtected())
{
    Console::WriteLine(u"The presentation does not have an opening password.");
}
else if (!presentationInfo->CheckPassword(password))
{
    Console::WriteLine(u"The opening password is incorrect.");
}
else
{
    presentationStream->set_Position(0);

    auto loadOptions = MakeObject<LoadOptions>();
    loadOptions->set_Password(password);
    auto presentation = MakeObject<Presentation>(presentationStream, loadOptions);

    Console::WriteLine(u"The presentation was validated and loaded successfully.");
}
```

### **مقادیر بازگشتی CheckPassword**

[IPresentationInfo::CheckPassword](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ipresentationinfo/checkpassword/) فقط زمانی `true` برمی‌گرداند که ارائهٔ رمز عبور بازشدن داشته باشد و رمز عبور ارائه‌شده صحیح باشد. در هر یک از موارد زیر `false` برمی‌گرداند:

- رمز عبور نادرست است.
- ارائه رمز عبور بازشدن ندارد.
- رمز عبور ارائه‌شده خالی یا null است.

رفتار برای ارائه‌های PPT و PPTX یکسان است.

## **بررسی اینکه آیا یک ارائهٔ بارگذاری‌شده رمزگذاری شده است**

پس از بارگذاری یک ارائه با رمز عبور صحیح، [IProtectionManager::get_IsEncrypted](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iprotectionmanager/get_isencrypted/) را بررسی کنید تا تأیید کنید که ارائهٔ منبع رمزگذاری شده بود. برای تشخیص حفاظت رمز عبور بازشدن قبل از بارگذاری، همان‌طور که در بالا نشان شد، از `IPresentationInfo::get_IsPasswordProtected` استفاده کنید.

```cpp
#include <DOM/IProtectionManager.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_Password(u"open_password");
auto presentation = MakeObject<Presentation>(u"encrypted-pres.pptx", loadOptions);

bool isEncrypted = presentation->get_ProtectionManager()->get_IsEncrypted();
Console::WriteLine(isEncrypted ? u"The presentation is encrypted." : u"The presentation is not encrypted.");
```

## **توصیه‌های امنیتی**

{{% alert color="warning" title="امنیت" %}}
رمزهای عبور بازشدن را لاگ نکنید یا در پیام‌های تشخیص خطا وارد نکنید. از تلاش‌های مکرر غیرضروری برای اعتبارسنجی خودداری کنید، رمزها را فقط به اندازهٔ لازم در حافظه نگه دارید و در صورت بارگذاری فوری ارائه، نتیجهٔ موفق اعتبارسنجی را مجدداً استفاده کنید.
{{% /alert %}}

## **رمزگذاری یک ارائه به صورت آنلاین**

1. برنامه [Aspose.Slides Lock](https://products.aspose.app/slides/fa/lock) را باز کنید.
2. ارائه را انتخاب یا بارگذاری کنید.
3. رمز عبوری برای محافظت از مشاهده وارد کنید.
4. در صورت تمایل، رمز عبور جداگانه‌ای برای محافظت از ویرایش وارد کنید.
5. حفاظت را اعمال کنید و فایل نتیجه را دانلود کنید.

{{% alert color="info" title="همچنین ببینید" %}}
- [محافظت نوشتن ارائه‌ها](/slides/fa/cpp/write-protected-presentation/)
- [امضا دیجیتال در پاورپوینت](/slides/fa/cpp/digital-signature-in-powerpoint/)
{{% /alert %}}

## **سؤالات متداول**

**تفاوت بین رمز عبور بازشدن و رمز عبور محافظت نوشتن چیست؟**

رمز عبور بازشدن ارائه را رمزگذاری می‌کند و برای بارگذاری محتوای آن ضروری است. رمز عبور محافظت نوشتن بدون رمزگذاری محتوا، تنها ویرایش را محدود می‌کند.

**آیا می‌توانم رمز عبور بازشدن را بدون بارگذاری تمام اسلایدها اعتبارسنجی کنم؟**

بله. اطلاعات ارائه را دریافت کنید، بررسی کنید که آیا حفاظتی با رمز عبور بازشدن وجود دارد یا خیر، و قبل از ایجاد یک نمونهٔ کامل از ارائه، رمز عبور را اعتبارسنجی کنید.

**آیا جریان‌های کاری بررسی رمز عبور برای هر دو قالب PPT و PPTX پشتیبانی می‌شوند؟**

بله. تشخیص و اعتبارسنجی رمز عبور بر پایه مسیر فایل و بر پایه جریان برای ارائه‌های PPT و PPTX به‌یک‌سان رفتار می‌کند.