---
title: مدیریت خواص ارائه در C++
linktitle: خواص ارائه
type: docs
weight: 70
url: /fa/cpp/presentation-properties/
keywords:
- خواص پاورپوینت
- خواص ارائه
- خواص سند
- خواص پیش‌ساخته
- خواص سفارشی
- خواص پیشرفته
- مدیریت خواص
- تغییر خواص
- فرادادهٔ سند
- ویرایش فراداده
- زبان اصلاح
- زبان پیش‌فرض
- پاورپوینت
- اُپن‌داکیومنت
- ارائه
- C++
- Aspose.Slides
description: "کامل کردن خواص ارائه در Aspose.Slides for C++ و ساده‌سازی جستجو، برندینگ و گردش کار در فایل‌های پاورپوینت و اُپن‌داکیومنت شما."
---
## **مقدمه**

Aspose.Slides for C++ از **خواص پیش‌ساخته** و **خواص سفارشی** سند پشتیبانی می‌کند. از این خواص برای خواندن و به‌روز کردن فرادادهٔ ارائه، مانند نویسنده، عنوان و مقادیر تعریف‌شده توسط کاربر استفاده کنید.

Aspose.Slides به شما اجازه می‌دهد تا از طریق رابط [IDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/) با خواص سند ارائه کار کنید. یک نمونه از این رابط توسط [IPresentation::get_DocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentation/get_documentproperties/) بازگردانده می‌شود. مثال‌های زیر نشان می‌دهند چطور این خواص را بخوانید، اصلاح کنید و مدیریت نمایید.

{{% alert color="info" title="Note" %}}
Aspose.Slides فراخوانی برنامه و تهیه‌کننده را هنگام ذخیرهٔ ارائه‌ها مدیریت می‌کند؛ این فیلدها نرم‌افزاری را که خروجی را تولید کرده است شناسایی می‌کنند.
{{% /alert %}}

## **مدیریت خواص ارائه**

خواص سند اطلاعات توصیفی را در کنار محتوای ارائه ذخیره می‌کنند. آن‌ها به دو دسته تقسیم می‌شوند:

- **خواص پیش‌ساخته** شامل فرادادهٔ استانداردی نظیر عنوان، نویسنده و آمار سند هستند.
- **خواص سفارشی** جفت‌های نام/مقدار تعریف‌شده توسط کاربر را ذخیره می‌کنند.

Aspose.Slides for C++ به هر دو دسته دسترسی فراهم می‌کند. در PowerPoint مسیر **File → Info → Properties → Advanced Properties** را برای بررسی فرادادهٔ سند انتخاب کنید. این دیالوگ اطلاعات را در تب‌های **Summary**، **Statistics**، **Contents** و **Custom** گروه‌بندی می‌کند. از تب **Custom** برای مدیریت خواص تعریف‌شده توسط کاربر استفاده کنید.

## **خواندن خواص عمومی از یک ارائهٔ رمزنگاری‌شده**

یک رمز عبور بازکن معمولاً محتوای ارائه و خواص سند را محافظت می‌کند. هنگامی که یک ارائه با عبور `false` به [IProtectionManager::set_EncryptDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/iprotectionmanager/set_encryptdocumentproperties/) رمزنگاری می‌شود، خواص سند آن عمومی می‌مانند. سپس یک برنامه می‌تواند `true` را به [LoadOptions::set_OnlyLoadDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_onlyloaddocumentproperties/) پاس دهد و فرادادهٔ عمومی را بدون ارائهٔ رمز عبور باز کردن بخواند.

[LoadOptions::set_OnlyLoadDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_onlyloaddocumentproperties/) تعیین می‌کند که Aspose.Slides چه چیزی را بارگذاری کند؛ این متد هیچ چیزی را رمزگشایی نمی‌کند. اگر خواص در رمزنگاری گنجانده شده باشند، بارگذاری آن‌ها بدون رمز عبور با خطا مواجه می‌شود. اگر ارائه رمزنگاری نشده باشد، این گزینه نادیده گرفته می‌شود و کل ارائه بارگذاری می‌شود.

مثال نیاز به یک ارائهٔ رمزنگاری‌شده دارد که خواص سند آن عمومی باقی مانده‌اند. این مثال حالت بارگذاری را از طریق [IProtectionManager::get_IsOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/cpp/aspose.slides/iprotectionmanager/get_isonlydocumentpropertiesloaded/) بررسی می‌کند و سپس خواص پیش‌ساخته را از طریق [IPresentation::get_DocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentation/get_documentproperties/) می‌خواند:

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <DOM/LoadOptions.h>
#include <DOM/IProtectionManager.h>

using namespace Aspose::Slides;

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_OnlyLoadDocumentProperties(true);

auto presentation = System::MakeObject<Presentation>(u"public-properties-encrypted.pptx", loadOptions);

if (presentation->get_ProtectionManager()->get_IsOnlyDocumentPropertiesLoaded())
{
    auto documentProperties = presentation->get_DocumentProperties();

    System::Console::WriteLine(u"Author: {0}", documentProperties->get_Author());
    System::Console::WriteLine(u"Title: {0}", documentProperties->get_Title());
    System::Console::WriteLine(u"Keywords: {0}", documentProperties->get_Keywords());
}
else
{
    System::Console::WriteLine(u"The presentation was not loaded in document-properties-only mode.");
}
```

در این حالت محتوای اسلایدها بارگذاری نمی‌شود. اسلایدها، مسترها، طرح‌بندی‌ها، اشکال، رسانه‌ها و سایر اشیای ارائه در دسترس نیستند. برنامه‌ها باید پیش از انجام عملیاتی که به مدل کامل شیء ارائه نیاز دارد، همیشه [IProtectionManager::get_IsOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/cpp/aspose.slides/iprotectionmanager/get_isonlydocumentpropertiesloaded/) را بررسی کنند.

{{% alert color="warning" title="Security" %}}
فرادادهٔ عمومی ممکن است نام نویسندگان، عناوین، موضوعات، کلیدواژه‌ها، اطلاعات شرکت، نظرات و مقادیر سفارشی را فاش کند. خواص حساس را همراه با ارائه رمزنگاری کنید. این خواص را فقط زمانی عمومی نگه دارید که سیستم‌های ایندکس، طبقه‌بندی، جستجو یا مدیریت سند نیاز خاصی به دسترسی بدون رمز عبور داشته باشند.
{{% /alert %}}

## **به‌روزرسانی خواص یک ارائهٔ رمزنگاری‌شده**

برای یک فایل PPTX رمزنگاری‌شده، ارائه‌ای که با عبور `true` به [LoadOptions::set_OnlyLoadDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_onlyloaddocumentproperties/) بارگذاری می‌شود، صرفاً برای خواندن فرادادهٔ عمومی هدف‌گذاری شده است. Aspose.Slides نمی‌تواند خواص تغییر یافته را از آن شیء «فقط‑مدارک» ذخیره کند، زیرا خواص عمومی باید با دادهٔ متناظر داخل ارائهٔ رمزنگاری‌شده هماهنگ بمانند. به‌روزرسانی آن‌ها بنابراین نیاز به رمز عبور صحیح بازکن و بارگذاری کامل دارد.

مثال نیاز به یک ارائهٔ PPTX رمزنگاری‌شده با خواص سند عمومی و رمز عبور بازکن شناخته‌شده دارد. این مثال ارائهٔ کامل را با [LoadOptions::set_Password](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_password/) باز می‌کند، خواص پیش‌ساختهٔ عمومی را به‌روزرسانی می‌کند و نتیجه را ذخیره می‌نماید. سپس با استفاده از [IPresentationInfo::get_IsEncrypted](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentationinfo/get_isencrypted/) صحت حفظ رمزنگاری را بررسی می‌کند و فرادادهٔ عمومی را بدون رمز عبور دوباره باز می‌کند تا مقادیر جدید را تأیید نماید:

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <DOM/LoadOptions.h>
#include <DOM/IProtectionManager.h>
#include <DOM/PresentationFactory.h>
#include <DOM/IPresentationInfo.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

const System::String inputPath = u"public-properties-encrypted.pptx";
const System::String outputPath = u"updated-public-properties-encrypted.pptx";

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"open_password");

auto presentation = System::MakeObject<Presentation>(inputPath, loadOptions);

auto documentProperties = presentation->get_DocumentProperties();
documentProperties->set_Title(u"Updated Product Roadmap");
documentProperties->set_Keywords(u"roadmap, planning, indexed");

presentation->Save(outputPath, SaveFormat::Pptx);

auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(outputPath);
System::Console::WriteLine(u"The presentation is encrypted: {0}", presentationInfo->get_IsEncrypted());

auto metadataLoadOptions = System::MakeObject<LoadOptions>();
metadataLoadOptions->set_OnlyLoadDocumentProperties(true);

auto metadataPresentation = System::MakeObject<Presentation>(outputPath, metadataLoadOptions);

if (metadataPresentation->get_ProtectionManager()->get_IsOnlyDocumentPropertiesLoaded())
{
    System::Console::WriteLine(u"Title: {0}", metadataPresentation->get_DocumentProperties()->get_Title());
    System::Console::WriteLine(u"Keywords: {0}", metadataPresentation->get_DocumentProperties()->get_Keywords());
}
else
{
    System::Console::WriteLine(u"The presentation was not loaded in document-properties-only mode.");
}
```

اگر برنامه اجازهٔ رمزگشایی یا بارگذاری محتوای ارائه را نداشته باشد، باید خواص عمومی یک فایل PPTX رمزنگاری‌شده را به عنوان حالت فقط‑خواندنی در نظر بگیرد.

## **دسترسی به خواص پیش‌ساخته**

رابط [IDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/) فرادادهٔ پیش‌ساخته را از طریق گترهای تایپی در دسترس می‌گذارد، از جمله [get_Author](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/get_author/)، [get_Title](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/get_title/) و [get_CreatedTime](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/get_createdtime/). این مثال یک ارائهٔ موجود را باز می‌کند و فرادادهٔ ذخیره‌شده را در کنسول چاپ می‌نماید. مقادیر به ارائهٔ ورودی وابسته‌اند؛ برخی فیلدها ممکن است خالی باشند.

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"AccessBuiltInProperties.pptx");

auto documentProperties = presentation->get_DocumentProperties();

System::Console::WriteLine(u"Category: {0}", documentProperties->get_Category());
System::Console::WriteLine(u"Content status: {0}", documentProperties->get_ContentStatus());
System::Console::WriteLine(u"Creation date: {0}", documentProperties->get_CreatedTime());
System::Console::WriteLine(u"Author: {0}", documentProperties->get_Author());
System::Console::WriteLine(u"Comments: {0}", documentProperties->get_Comments());
System::Console::WriteLine(u"Keywords: {0}", documentProperties->get_Keywords());
System::Console::WriteLine(u"Last modified by: {0}", documentProperties->get_LastSavedBy());
System::Console::WriteLine(u"Manager: {0}", documentProperties->get_Manager());
System::Console::WriteLine(u"Modified date: {0}", documentProperties->get_LastSavedTime());
System::Console::WriteLine(u"Presentation format: {0}", documentProperties->get_PresentationFormat());
System::Console::WriteLine(u"Last print date: {0}", documentProperties->get_LastPrinted());
System::Console::WriteLine(u"Is shared between producers: {0}", documentProperties->get_SharedDoc());
System::Console::WriteLine(u"Subject: {0}", documentProperties->get_Subject());
System::Console::WriteLine(u"Title: {0}", documentProperties->get_Title());
```

### **گزارش شمارهٔ بازنگری و زمان ویرایش**

از [GetPresentationInfo](https://reference.aspose.com/slides/cpp/aspose.slides/presentationfactory/getpresentationinfo/) و [ReadDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/) برای خواندن [IDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/) هر فایل بدون بارگذاری اسلایدهای آن برای ویرایش استفاده کنید. این مثال یک ردیف برای هر فایل PPTX در پوشه `presentations` چاپ می‌کند. قالب استاندارد `c` شامل شمارش روزها زمانی است که زمان ویرایش ثبت‌شده به ۲۴ ساعت برسد.

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/IPresentationInfo.h>
#include <DOM/PresentationFactory.h>
#include <system/console.h>
#include <system/io/directory.h>
#include <system/io/path.h>
#include <system/timespan.h>

using namespace Aspose::Slides;
using namespace System::IO;

System::Console::WriteLine(u"File | RevisionNumber | TotalEditingTime");
auto paths = Directory::GetFiles(u"presentations", u"*.pptx");
for (const auto& path : paths)
{
    auto info = PresentationFactory::get_Instance()->GetPresentationInfo(path);
    auto properties = info->ReadDocumentProperties();
    auto fileName = Path::GetFileName(path);
    auto editingTime = properties->get_TotalEditingTime().ToString(u"c");
    System::Console::WriteLine(u"{0} | {1} | {2}", fileName, properties->get_RevisionNumber(), editingTime);
}
```

برای یک ارائه با ۱ روز، ۲ ساعت و ۵ دقیقه زمان ویرایش ثبت‌شده، گزارش به این شکل خواهد بود:

```text
File | RevisionNumber | TotalEditingTime
long.pptx | 17 | 1.02:05:00
```

[get_RevisionNumber](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/get_revisionnumber/) مقدار فراداده‌ای را می‌خواند که برنامه‌ها می‌توانند با [set_RevisionNumber](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/set_revisionnumber/) تغییر دهند. تنها آن مقدار نمی‌تواند تعداد ذخیره‌های ارائه یا تاریخچهٔ نسخهٔ آن را تعیین کند.

[get_TotalEditingTime](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/get_totaleditingtime/) مدت زمان ویرایش ثبت‌شده در فایل را برمی‌گرداند. مقدار `00:00:00` به این معنی است که مدت زمان ذخیره‌شده صفر است؛ ممکن است ارائه همچنان ویرایش شده باشد.

## **تعديل خواص پیش‌ساخته**

برای به‌روزرسانی فرادادهٔ پیش‌ساخته، از متدهای تنظیم‌کننده روی شیء بازگردانده شده توسط [IPresentation::get_DocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentation/get_documentproperties/) استفاده کنید. این مثال یک ارائهٔ موجود را باز می‌کند، [set_Author](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/set_author/)، [set_Title](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/set_title/)، [set_Subject](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/set_subject/)، [set_Comments](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/set_comments/) و [set_Manager](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/set_manager/) را فراخوانی می‌کند و سپس ارائهٔ به‌روزرسانی‌شده را با [Presentation::Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/) ذخیره می‌نماید. فایل PPTX ذخیره‌شده حاوی فرادادهٔ جدید خواهد بود.

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"ModifyBuiltInProperties.pptx");

auto documentProperties = presentation->get_DocumentProperties();

documentProperties->set_Author(u"Aspose.Slides for C++");
documentProperties->set_Title(u"Manage PowerPoint Presentation Properties");
documentProperties->set_Subject(u"Modify Built-in Properties");
documentProperties->set_Comments(u"Aspose description");
documentProperties->set_Manager(u"Aspose manager");

presentation->Save(u"DocumentProperties_output.pptx", SaveFormat::Pptx);
```

## **مدیریت مبنای پیوندهای فراگیر**

[IDocumentProperties::get_HyperlinkBase](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/get_hyperlinkbase/) مبنای سند برای پیوندهای نسبی را می‌خواند. این ویژگی هنگام جابجایی یک ارائه و فایل‌های پیوندی آن به مکان دیگری مفید است. این مقدار متفاوت از [IHyperlink::get_ExternalUrl](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/get_externalurl/) یک پیوند فردی است؛ تغییر مبنا آدرس‌های ذخیره‌شدهٔ پیوندها یا مقصدهای مطلق را بازنویسی نمی‌کند.

مثال نیاز به ارائه‌ای دارد که هم پیوند نسبی‌ای نظیر `target.html` و هم پیوند مطلقی نظیر `https://example.org/absolute.html` داشته باشد. ابتدا مبنای موجود را می‌خواند، سپس با [IDocumentProperties::set_HyperlinkBase](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/set_hyperlinkbase/) یک مبنای جدید اختصاص می‌دهد و پس از ذخیره و بازگشایی ارائه مقدار جدید را بررسی می‌کند. سپس مبنا را با `u""` پاک می‌کند و مقدار خالی را در فایلی جداگانه تأیید می‌نماید. مبنای مثال را با مسیر فایل‌های پیوندی خود جایگزین کنید.

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"hyperlinks.pptx");

System::Console::WriteLine(u"Original base: {0}", presentation->get_DocumentProperties()->get_HyperlinkBase());

const System::String newBase = u"https://example.com/new/";
presentation->get_DocumentProperties()->set_HyperlinkBase(newBase);
presentation->Save(u"hyperlinks-updated.pptx", SaveFormat::Pptx);

auto updatedPresentation = System::MakeObject<Presentation>(u"hyperlinks-updated.pptx");
System::Console::WriteLine(u"Base preserved: {0}", (updatedPresentation->get_DocumentProperties()->get_HyperlinkBase() == newBase));

updatedPresentation->get_DocumentProperties()->set_HyperlinkBase(u"");
updatedPresentation->Save(u"hyperlinks-cleared.pptx", SaveFormat::Pptx);

auto clearedPresentation = System::MakeObject<Presentation>(u"hyperlinks-cleared.pptx");
System::Console::WriteLine(u"Base cleared: {0}", (clearedPresentation->get_DocumentProperties()->get_HyperlinkBase() == u""));
```

دو پیام تأیید باید `True` چاپ کنند. پاک‌کردن مبنا آدرس‌های پیوندهای فردی را دست نخورده باقی می‌گذارد.

یک پیوند نسبی به `target.pptx` هنگام مبنای `old` فایل `old/target.pptx` را باز می‌کرد. پس از تغییر مبنا به پوشه `new`، ذخیره و بازگشایی ارائه، همان پیوند فایل `new/target.pptx` را باز کرد. یک پیوند مطلق بدون تغییر همان فایل را باز می‌کرد. پیوندهای نسبی خود را در PowerPoint پیش و پس از جابجایی ارائه یا تغییر مبنای آن تست کنید.

## **افزودن خواص سفارشی به ارائه**

خواص سفارشی فراداده‌ای را ذخیره می‌کنند که فیلد پیش‌ساخته‌ای معادل ندارند. [IDocumentProperties::idx_set](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/idx_set/) به شما امکان می‌دهد مقدار را با نام خصوصیت اختصاص دهید. این مثال یک ارائه می‌سازد، دو مقدار متنی و یک مقدار عددی نسخه را اضافه می‌کند و سپس ارائه را با [Presentation::Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/) ذخیره می‌نماید. اختصاص مقدار به نامی که از قبل وجود دارد، مقدار آن خصوصیت را جایگزین می‌کند.

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();

auto documentProperties = presentation->get_DocumentProperties();

documentProperties->idx_set(u"Reviewed by", System::ObjectExt::Box<System::String>(u"John Smith"));
documentProperties->idx_set(u"Confidentiality level", System::ObjectExt::Box<System::String>(u"Internal"));
documentProperties->idx_set(u"Document version", System::ObjectExt::Box(2));

presentation->Save(u"CustomDocumentProperties_output.pptx", SaveFormat::Pptx);
```

## **دسترسی و تعديل خواص سفارشی**

این مثال یک ارائه حاوی خواص سفارشی را باز می‌کند و با استفاده از [get_CountOfCustomProperties](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/get_countofcustomproperties/) بر روی آن‌ها حلقه می‌زند. [GetCustomPropertyName](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/getcustompropertyname/) یک اندیس صفر‑پایه می‌گیرد و نامی را برمی‌گرداند که توسط [IDocumentProperties::idx_get](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/idx_get/) و [idx_set](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/idx_set/) استفاده می‌شود. مثال هر نام و مقدار اصلی را چاپ می‌کند، همه مقادیر را با رشته‌ای شماره‌دار، صرف‌نظر از نوع اصلی، جایگزین می‌نماید و تغییرات را ذخیره می‌کند. اگر هیچ خاصیتی سفارشی وجود نداشته باشد، حلقه تغییری ایجاد نمی‌کند.

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"AccessAndModifyProperties.pptx");

auto documentProperties = presentation->get_DocumentProperties();

for (auto i = 0; i < documentProperties->get_CountOfCustomProperties(); i++)
{
    auto propertyName = documentProperties->GetCustomPropertyName(i);
    auto propertyValue = documentProperties->idx_get(propertyName);

    System::Console::WriteLine(u"Custom property name: {0}", propertyName);
    System::Console::WriteLine(u"Custom property value: {0}", propertyValue);

    documentProperties->idx_set(propertyName, System::ObjectExt::Box(System::String::Format(u"New Value {0}", i + 1)));
}

presentation->Save(u"CustomProperties_output.pptx", SaveFormat::Pptx);
```

## **مثال زنده**

سعی کنید برنامهٔ آنلاین [**View & Edit PowerPoint Metadata**](https://products.aspose.app/slides/metadata) را برای مشاهدهٔ نحوه کار با خواص سند با استفاده از API Aspose.Slides امتحان کنید:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **پرسش‌های متداول**

**چگونه می‌توانم یک خاصیت پیش‌ساخته را از یک ارائه حذف کنم؟**

خواص پیش‌ساخته جزئی جدایی‌ناپذیر از ارائه هستند و نمی‌توان آن‌ها را کاملاً حذف کرد. با این حال می‌توانید مقدار آن‌ها را تغییر دهید یا در صورت امکان مقدار خالی قرار دهید.

**اگر یک خاصیت سفارشی که از قبل وجود دارد را اضافه کنم، چه می‌شود؟**

اگر یک خاصیت سفارشی که پیش از این وجود داشته باشد اضافه کنید، مقدار موجود با مقدار جدید بازنویسی می‌شود. نیازی به حذف یا بررسی قبلی خاصیت نیست، زیرا Aspose.Slides به‌صورت خودکار ارزش خاصیت را به‌روز می‌کند.

**آیا می‌توانم به خواص ارائه بدون بارگذاری کامل ارائه دسترسی داشته باشم؟**

بله. از [PresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/cpp/aspose.slides/presentationfactory/getpresentationinfo/) استفاده کنید و سپس [IPresentationInfo::ReadDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/) را برای خواندن فرادادهٔ ذخیره‌شدهٔ سند بدون ایجاد یک نمونهٔ [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) فراخوانی کنید. برای مثال کامل گزارش‌گیری و محدودیت‌های خاص فرمت به مطلب [Build a Lightweight Presentation Inventory](/slides/fa/cpp/examine-presentation/) مراجعه کنید.

**آیا می‌توانم خواص عمومی یک ارائهٔ رمزنگاری‌شده را بدون رمز عبور بازکن بخوانم؟**

بله. ارائه باید با عبور `false` به [IProtectionManager::set_EncryptDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/iprotectionmanager/set_encryptdocumentproperties/) رمزنگاری شده باشد و با عبور `true` به [LoadOptions::set_OnlyLoadDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_onlyloaddocumentproperties/) بارگذاری شود.

**آیا می‌توانم یک فایل PPTX رمزنگاری‌شده را در حالت فقط‑خواص‑سند به‌روزرسانی کنم؟**

خیر. داده‌های عمومی و رمزنگاری‌شده باید سازگار بمانند، بنابراین به‌روزرسانی یک فایل PPTX رمزنگاری‌شده مستلزم بارگذاری کامل ارائه با رمز عبور بازکن صحیح است.