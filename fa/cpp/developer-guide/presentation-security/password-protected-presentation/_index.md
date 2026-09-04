---
title: محافظت از ارائه‌ها با رمز عبور در C++
linktitle: محافظت با رمز عبور
type: docs
weight: 20
url: /fa/cpp/password-protected-presentation/
keywords:
- ارائهٔ محافظت‌شده با رمز عبور
- رمز عبور بازگشایی
- رمزنگاری PowerPoint
- رمزگشایی PowerPoint
- اعتبارسنجی رمز عبور ارائه
- بررسی رمز عبور ارائه
- باز کردن ارائهٔ رمزنگاری‌شده
- حذف رمزنگاری
- PowerPoint
- PPT
- PPTX
- ارائه
- C++
- Aspose.Slides
description: "رمزنگاری، شناسایی، اعتبارسنجی، باز کردن و رمزگشایی ارائه‌های PowerPoint PPT و PPTX محافظت‌شده با رمز عبور در C++ با Aspose.Slides."
---
## **بررسی کلی**

یک رمز عبور بازگشایی یک ارائه را رمزنگاری می‌کند. برای بارگذاری و مشاهده محتوای ارائه، رمز عبور صحیح ضروری است، بنابراین این حفاظت محرمانگی را فراهم می‌کند.

رمز عبور بازگشایی متفاوت از رمز عبور محافظت‌نوشتن است. محافظت‌نوشتن فقط اصلاح را محدود می‌کند ولی محتوا را رمزنگاری نمی‌کند و ارائه را از بارگذاری باز نمی‌دارد. برای مدیریت رمزهای عبور برای اصلاح ارائه‌ها، به [Write‑Protect Presentations](/slides/fa/cpp/write-protected-presentation/) رجوع کنید.

جریان‌های کاری زیر برای هر دو نوع ارائه PPT و PPTX معتبر هستند. مثال‌ها از هر دو فرمت استفاده می‌کنند هنگامی که رفتار مبتنی بر فایل و جریان مهم باشد.

## **رمزنگاری یک ارائه با رمز عبور بازگشایی**

از [IProtectionManager::Encrypt](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iprotectionmanager/encrypt/) برای اختصاص یک رمز عبور بازگشایی استفاده کنید. سپس از [IPresentation::Save](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ipresentation/save/) برای ذخیرهٔ ارائهٔ رمزنگاری‌شده استفاده کنید.

مثال زیر یک ارائه PPTX را رمزنگاری می‌کند:

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

## **حفظ عمومی ویژگی‌های سند**

به‌صورت پیش‌فرض، Aspose.Slides ویژگی‌های سند را در رمزنگاری ارائه گنجانده است. متد [IProtectionManager::set_EncryptDocumentProperties](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iprotectionmanager/set_encryptdocumentproperties/) این رفتار را به‌صورت مستقل از رمزنگاری محتوای اسلاید کنترل می‌کند. قبل از فراخوانی [IProtectionManager::Encrypt](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iprotectionmanager/encrypt/) مقدار `false` را به این متد بدهید وقتی سامانهٔ ایندکس‌گذاری، طبقه‌بندی، جستجو یا مدیریت‑سند باید متادیتا را بدون رمز عبور بازگشایی بخواند.

مثال زیر یک ارائه PPTX رمزنگاری شده ایجاد می‌کند در حالی که ویژگی‌های سند داخلی آن عمومی باقی می‌مانند:

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/IProtectionManager.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto properties = presentation->get_DocumentProperties();
properties->set_Author(u"Contoso Knowledge Management");
properties->set_Title(u"Quarterly Product Roadmap");
properties->set_Keywords(u"roadmap, planning, internal");

presentation->get_Slide(0)->set_Name(u"Encrypted presentation content");
presentation->get_ProtectionManager()->set_EncryptDocumentProperties(false);
presentation->get_ProtectionManager()->Encrypt(u"open_password");
presentation->Save(u"public-properties-encrypted.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

دادن مقدار `false` به `set_EncryptDocumentProperties` اسلایدها، مسترها، طرح‌بندی‌ها، اشکال، رسانه یا سایر محتوای ارائه را عمومی نمی‌کند. این فقط بر ویژگی‌های سند اثر می‌گذارد. برای خواندن آن ویژگی‌ها بدون بارگذاری محتوای رمزنگاری‌شده، به [Manage Presentation Properties](/slides/fa/cpp/presentation-properties/) مراجعه کنید.

## **بارگذاری یک ارائه رمزنگاری‌شده**

[LoadOptions::set_Password](https://reference.aspose.com/slides/fa/cpp/aspose.slides/loadoptions/set_password/) را به رمز عبور بازگشایی تنظیم کنید و گزینه‌ها را هنگام بارگذاری فایل به سازندهٔ [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) پاس دهید. اگر رمز عبور بازگشایی لازم باشد اما رمز ارائه نشده یا اشتباه باشد، بارگذاری شکست می‌خورد.

```cpp
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"open_password");

auto presentation = System::MakeObject<Presentation>(u"encrypted-pres.pptx", loadOptions);

// کار با ارائهٔ رمزگشایی‌شده.
```

## **حذف رمزنگاری از یک ارائه**

ارائه را همراه با رمز عبور بازگشایی بارگذاری کنید، [IProtectionManager::RemoveEncryption](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iprotectionmanager/removeencryption/) را فراخوانی کنید و نتیجه را ذخیره کنید. ارائهٔ ذخیره‌شده سپس می‌تواند بدون رمز عبور بارگذاری شود.

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

## **اعتبارسنجی یک رمز عبور بازگشایی قبل از بارگذاری**

از [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) برای به‌دست آوردن [IPresentationInfo](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ipresentationinfo/) بدون ایجاد یک نمونهٔ کامل ارائه استفاده کنید. پیش از درخواست یا اعتبارسنجی رمز عبور، [IPresentationInfo::get_IsPasswordProtected](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ipresentationinfo/get_ispasswordprotected/) را بررسی کنید. وقتی حفاظت وجود داشته باشد، مقدار ارائه‌شده را با [IPresentationInfo::CheckPassword](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ipresentationinfo/checkpassword/) اعتبارسنجی کنید.

### **جریان کاری مسیر فایل**

مثال زیر رمز عبور بازگشایی یک فایل PPTX را اعتبارسنجی می‌کند، مقدار اعتبارسنجی‌شده را به [LoadOptions::set_Password](https://reference.aspose.com/slides/fa/cpp/aspose.slides/loadoptions/set_password/) می‌سپارد و سپس ارائهٔ کامل را بارگذاری می‌کند:

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

بارگذاری بیشینهٔ [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) همان جریان کاری را فراهم می‌کند. قبل از بارگذاری ارائهٔ کامل از آن جریان، موقعیت یک جریان قابل جست‌وجو را بازنشانی کنید.

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

[IPresentationInfo::CheckPassword](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ipresentationinfo/checkpassword/) فقط زمانی `true` برمی‌گرداند که ارائه دارای رمز عبور بازگشایی باشد و رمز ارائه‌شده صحیح باشد. در هر یک از موارد زیر `false` برمی‌گرداند:

- رمز عبور نادرست است.
- ارائه رمز عبور بازگشایی ندارد.
- رمز عبور ارائه‌شده خالی یا `null` است.

رفتار برای ارائه‌های PPT و PPTX یکسان است.

## **بررسی اینکه آیا یک ارائه بارگذاری‌شده رمزنگاری شده است**

پس از بارگذاری یک ارائه با رمز عبور صحیح، [IProtectionManager::get_IsEncrypted](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iprotectionmanager/get_isencrypted/) را بررسی کنید تا تأیید شود که ارائهٔ مبدأ رمزنگاری شده بوده است. برای تشخیص محافظت با رمز عبور بازگشایی قبل از بارگذاری، همان‌طور که در بالا نشان داده شد از `IPresentationInfo::get_IsPasswordProtected` استفاده کنید.

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

{{% alert color="warning" title="Security" %}}
رمزهای عبور بازگشایی را در لاگ‌ها یا پیام‌های تشخیصی ثبت نکنید. از تلاش‌های مکرر و غیرضروری برای اعتبارسنجی جلوگیری کنید، رمزها را تنها به‌مقدار نیاز در حافظه نگه دارید و در صورتی که بلافاصله پس از اعتبارسنجی موفق، ارائه را بارگذاری می‌کنید، نتیجه‌ی اعتبارسنجی را دوباره استفاده کنید.

ویژگی‌های عمومی سند ممکن است نام نویسنده، عنوان، موضوع، کلمات کلیدی، اطلاعات شرکت، نظرات و مقادیر سفارشی را حتی زمانی که محتوای ارائه رمزنگاری شده است، فاش کنند. متادیتای حساس را همراه با ارائه رمزنگاری کنید. گذاشتن ویژگی‌ها به‌صورت عمومی باید تصمیم صریحی باشد که فقط زمانی اتخاذ می‌شود که سیستم‌ها برای ایندکس‌گذاری، طبقه‌بندی، جستجو یا مدیریت فایل بدون رمز عبور بازگشایی نیاز داشته باشند.
{{% /alert %}}

## **رمزگذاری یک ارائه به‌صورت آنلاین**

1. برنامه [Aspose.Slides Lock](https://products.aspose.app/slides/fa/lock) را باز کنید.
1. ارائه را انتخاب یا بارگذاری کنید.
1. برای محافظت از نمایش، یک رمز عبور وارد کنید.
1. در صورت تمایل، رمز عبور جداگانه‌ای برای محافظت از ویرایش وارد کنید.
1. محافظت را اعمال کنید و فایل حاصل را دانلود کنید.

{{% alert color="info" title="See also" %}}
- [Write‑Protect Presentations](/slides/fa/cpp/write-protected-presentation/)
- [Digital Signature in PowerPoint](/slides/fa/cpp/digital-signature-in-powerpoint/)
{{% /alert %}}

## **پرسش‌های متداول**

**تفاوت بین رمز عبور بازگشایی و رمز عبور محافظت‌نوشتن چیست؟**

رمز عبور بازگشایی ارائه را رمزنگاری می‌کند و برای بارگذاری محتوا ضروری است. رمز عبور محافظت‌نوشتن تنها اصلاح را محدود می‌کند بدون اینکه محتوا را رمزنگاری کند.

**آیا می‌توان رمز عبور بازگشایی را بدون بارگذاری تمام اسلایدها اعتبارسنجی کرد؟**

بله. اطلاعات ارائه را به‌دست آورید، بررسی کنید آیا محافظت با رمز عبور بازگشایی وجود دارد یا نه، و قبل از ایجاد یک نمونهٔ کامل ارائه، رمز عبور را اعتبارسنجی کنید.

**آیا برنامه می‌تواند متادیتا را بدون رمز عبور بازگشایی بخواند؟**

بله، اما تنها زمانی که ارائه با `set_EncryptDocumentProperties(false)` رمزنگاری شده باشد. سپس برنامه باید از حالت بارگذاری فقط‑ویژگی‑سند که در [Manage Presentation Properties](/slides/fa/cpp/presentation-properties/) توضیح داده شده استفاده کند.

**آیا جریان‌های کاری بررسی رمز عبور برای هر دو فرمت PPT و PPTX پشتیبانی می‌شود؟**

بله. تشخیص و اعتبارسنجی رمز عبور بر پایهٔ مسیر فایل و مسیر جریان برای هر دو نوع ارائه به‌صورت یکسان عمل می‌کند.