---
title: مدیریت ویژگی‌های ارائه در C++
linktitle: ویژگی‌های ارائه
type: docs
weight: 70
url: /fa/cpp/presentation-properties/
keywords:
- ویژگی‌های PowerPoint
- ویژگی‌های ارائه
- ویژگی‌های سند
- ویژگی‌های پیش‌فرض
- ویژگی‌های سفارشی
- ویژگی‌های پیشرفته
- مدیریت ویژگی‌ها
- تغییر ویژگی‌ها
- ابرداده سند
- ویرایش ابرداده
- زبان تصحیح
- زبان پیش‌فرض
- PowerPoint
- OpenDocument
- ارائه
- C++
- Aspose.Slides
description: "ویژگی‌های اصلی ارائه را در Aspose.Slides برای C++ مدیریت کنید و جستجو، برندینگ و جریان کار را در فایل‌های PowerPoint و OpenDocument خود بهینه‌سازی کنید."
---
## **معرفی**

Aspose.Slides for C++ پشتیبانی می‌کند از ویژگی‌های سند **درونی** و **سفارشی**. از این ویژگی‌ها برای خواندن و به‌روزرسانی فراداده ارائه، مانند نویسنده، عنوان و مقادیر تعریف‌شده توسط کاربر استفاده کنید.

Aspose.Slides به شما امکان کار با ویژگی‌های سند ارائه را از طریق رابط [IDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/) می‌دهد. یک نمونه از این رابط توسط [IPresentation::get_DocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentation/get_documentproperties/) برگردانده می‌شود. مثال‌های زیر نشان می‌دهند چگونه این ویژگی‌ها را بخوانید، تغییر دهید و مدیریت کنید.

{{% alert color="info" title="Note" %}}
Aspose.Slides هنگام ذخیره ارائه‌ها، متادیتای برنامه و تولیدکننده را مدیریت می‌کند؛ این فیلدها نرم‌افزاری را که خروجی را ایجاد کرده شناسایی می‌کنند.
{{% /alert %}}

## **مدیریت ویژگی‌های ارائه**

ویژگی‌های سند اطلاعات توصیفی را در کنار محتوای ارائه ذخیره می‌کنند. آنها به دو دسته تقسیم می‌شوند:

- **Built-in properties** شامل متادیتای استانداردی مانند عنوان، نویسنده و آمار سند هستند.
- **Custom properties** جفت‌های نام/مقدار تعریف‌شده توسط کاربر را ذخیره می‌کنند.

Aspose.Slides for C++ دسترسی به هر دو دسته را فراهم می‌کند. در PowerPoint، **File → Info → Properties → Advanced Properties** را انتخاب کنید تا متادیتای سند را بررسی کنید. این دیالوگ اطلاعات را در تب‌هایی مثل **Summary**، **Statistics**، **Contents** و **Custom** گروه‌بندی می‌کند. از تب **Custom** برای مدیریت ویژگی‌های تعریف‌شده توسط کاربر استفاده کنید.

## **خواندن ویژگی‌های عمومی از یک ارائه رمزگذاری شده**

یک رمز عبور باز کردن معمولاً هم محتوای ارائه و هم ویژگی‌های سند را محافظت می‌کند. وقتی یک ارائه با عبور `false` به [IProtectionManager::set_EncryptDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/iprotectionmanager/set_encryptdocumentproperties/) رمزگذاری شود، ویژگی‌های سند آن عمومی می‌مانند. سپس برنامه می‌تواند `true` را به [LoadOptions::set_OnlyLoadDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_onlyloaddocumentproperties/) پاس داده و متادیتای عمومی را بدون ارائه رمز عبور باز کردن بخواند.

[LoadOptions::set_OnlyLoadDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_onlyloaddocumentproperties/) تعیین می‌کند که Aspose.Slides چه چیزی را بارگذاری کند؛ این کار رمز‌گشایی نمی‌کند. اگر ویژگی‌ها در رمزگذاری گنجانده شده باشند، بارگذاری آنها بدون رمز عبور شکست می‌خورد. اگر ارائه رمزگذاری نشده باشد، این گزینه نادیده گرفته می‌شود و کل ارائه بارگذاری می‌شود.

مثال به یک ارائه رمزگذاری شده‌ای نیاز دارد که ویژگی‌های سند آن عمومی باقی مانده باشد. حالت بارگذاری با استفاده از [IProtectionManager::get_IsOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/cpp/aspose.slides/iprotectionmanager/get_isonlydocumentpropertiesloaded/) تأیید می‌شود و سپس ویژگی‌های درونی با استفاده از [IPresentation::get_DocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentation/get_documentproperties/) خوانده می‌شوند:

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

در این حالت، محتوای اسلاید بارگذاری نمی‌شود. اسلایدها، استادها، طرح‌بندی‌ها، اشکال، رسانه‌ها و سایر اشیاء ارائه در دسترس نیستند. برنامه‌ها باید همیشه قبل از انجام عملی که نیاز به مدل کامل شیء ارائه دارد، [IProtectionManager::get_IsOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/cpp/aspose.slides/iprotectionmanager/get_isonlydocumentpropertiesloaded/) را بررسی کنند.

{{% alert color="warning" title="Security" %}}
متادیتای عمومی ممکن است نام نویسندگان، عناوین، موضوعات، کلمات کلیدی، اطلاعات شرکت، نظرات و مقادیر سفارشی را فاش کند. ویژگی‌های حساس را همراه با ارائه رمزگذاری کنید. آنها را فقط در زمانی که سیستم‌های ایندکس‌گذاری، طبقه‌بندی، جستجو یا مدیریت سند نیاز خاصی برای دسترسی بدون رمز عبور دارند، عمومی بگذارید.
{{% /alert %}}

## **به‌روزرسانی ویژگی‌های یک ارائه رمزگذاری شده**

برای یک فایل PPTX رمزگذاری‌شده، ارائه‌ای که با عبور `true` به [LoadOptions::set_OnlyLoadDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_onlyloaddocumentproperties/) بارگذاری می‌شود، برای خواندن متادیتای عمومی طراحی شده است. Aspose.Slides نمی‌تواند تغییرات ویژگی‌ها را از آن شیء فقط‑متادیتا ذخیره کند زیرا ویژگی‌های عمومی باید با داده‌های متناظر داخل ارائه رمزگذاری‌شده همگام بمانند. به‌روزرسانی آنها بنابراین به رمز عبور باز کردن صحیح و بارگذاری کامل نیاز دارد.

مثال به یک ارائه PPTX رمزگذاری‌شده با ویژگی‌های سند عمومی و یک رمز عبور باز کردن شناخته‌شده نیاز دارد. با استفاده از [LoadOptions::set_Password](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_password/) ارائه کامل باز می‌شود، ویژگی‌های درونی عمومی به‌روزرسانی می‌شوند و نتیجه ذخیره می‌شود. سپس با استفاده از [IPresentationInfo::get_IsEncrypted](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentationinfo/get_isencrypted/) صحت حفظ رمزگذاری تأیید می‌شود و متادیتای عمومی بدون رمز عبور بازخوانی می‌شود تا مقادیر جدید را بررسی کند:

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

اگر برنامه‌ای اجازهٔ رمز‑گشایی یا بارگذاری محتوای ارائه را نداشته باشد، باید ویژگی‌های عمومی یک فایل PPTX رمزگذاری‌شده را به‌عنوان فقط‑خواندنی در نظر بگیرد.

## **دسترسی به ویژگی‌های درونی**

رابط [IDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/) متادیتای درونی را از طریق متدهای getter تایپ‌شده مانند [get_Author](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/get_author/)، [get_Title](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/get_title/) و [get_CreatedTime](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/get_createdtime/) در دسترس می‌گذارد. این مثال یک ارائه موجود را باز می‌کند و متادیتای ذخیره‌شدهٔ آن را در کنسول چاپ می‌کند. مقادیر بسته به ارائه ورودی متفاوت هستند؛ برخی فیلدها ممکن است خالی باشند.

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

## **تغییر ویژگی‌های درونی**

برای به‌روزرسانی متادیتای درونی، از setter‑های شیء بازگردانده‌شده توسط [IPresentation::get_DocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentation/get_documentproperties/) استفاده کنید. این مثال یک ارائه موجود را باز می‌کند، [set_Author](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/set_author/)، [set_Title](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/set_title/)، [set_Subject](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/set_subject/)، [set_Comments](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/set_comments/) و [set_Manager](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/set_manager/) را فراخوانی می‌کند، سپس ارائه بروز‌شده را با [Presentation::Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/) ذخیره می‌کند. PPTX ذخیره‌شده شامل متادیتای جدید خواهد بود.

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

## **مدیریت پایهٔ پیوندهای هیپرلینک**

[IDocumentProperties::get_HyperlinkBase](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/get_hyperlinkbase/) پایهٔ سطح سند برای پیوندهای نسبی را می‌خواند. این ویژگی زمانی مفید است که یک ارائه و فایل‌های پیوست آن را به مکان دیگری منتقل می‌کنید. این پایه مستقل از [IHyperlink::get_ExternalUrl](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/get_externalurl/) یک پیوند منفرد است: تغییر پایه آدرس‌های ذخیره‌شدهٔ پیوندها را بازنویسی نمی‌کند و مقصدهای مطلق را تغییر نمی‌دهد.

مثال به یک ارائه‌ای نیاز دارد که هم یک پیوند نسبی مانند `target.html` و هم یک پیوند مطلق مانند `https://example.org/absolute.html` داشته باشد. پایهٔ موجود خوانده می‌شود، آدرس پایهٔ جدید با استفاده از [IDocumentProperties::set_HyperlinkBase](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/set_hyperlinkbase/) اختصاص می‌یابد و برای بررسی مقدار، ارائه ذخیره و مجدداً باز می‌شود. سپس پایه با `u""` پاک می‌شود و مقدار خالی در فایلی ذخیره‌شدهٔ جداگانه تأیید می‌شود. آدرس پایهٔ مثال را با مکان فایل‌های پیوست خود جایگزین کنید.

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

دو پیام تأیید باید `True` چاپ کنند. پاک کردن پایه، آدرس‌های پیوندهای منفرد را دست‌نخورده می‌گذارد.

یک پیوند نسبی به `target.pptx` هنگامیکه پایه به پوشهٔ `old` اشاره می‌کرد، `old/target.pptx` را باز می‌کرد. پس از تغییر پایه به پوشهٔ `new`، ذخیره و بازگشایی ارائه، همان پیوند `new/target.pptx` را باز می‌کند. یک پیوند مطلق همان فایل را باز نگه می‌دارد. پیوندهای نسبی خود را در PowerPoint قبل و بعد از جابه‌جایی ارائه یا تغییر پایه تست کنید.

## **افزودن ویژگی‌های سفارشی به ارائه**

ویژگی‌های سفارشی متادیتایی را ذخیره می‌کنند که فیلد درونی معادلی برای آن وجود ندارد. [IDocumentProperties::idx_set](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/idx_set/) به شما امکان می‌دهد مقدار را بر اساس نام ویژگی تعیین کنید. این مثال یک ارائه ایجاد می‌کند، دو مقدار متنی و یک مقدار عددی نسخه را اضافه می‌کند و ارائه را با [Presentation::Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/) ذخیره می‌کند. اختصاص مقدار به یک نام موجود، مقدار آن ویژگی را جایگزین می‌کند.

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

## **دسترسی و اصلاح ویژگی‌های سفارشی**

این مثال یک ارائه حاوی ویژگی‌های سفارشی را باز می‌کند و با استفاده از [get_CountOfCustomProperties](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/get_countofcustomproperties/) روی آنها تکرار می‌نماید. [GetCustomPropertyName](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/getcustompropertyname/) یک شاخص صفر‑مبنا می‌پذیرد و نامی را برمی‌گرداند که توسط [IDocumentProperties::idx_get](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/idx_get/) و [idx_set](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/idx_set/) استفاده می‌شود. مثال هر نام و مقدار اصلی را چاپ می‌کند، هر مقدار را به یک رشته شماره‌دار (بدون در نظر گرفتن نوع اصلی) تبدیل می‌کند و تغییرات را ذخیره می‌کند. اگر ویژگی سفارشی وجود نداشته باشد، حلقه هیچ تغییری ایجاد نمی‌کند.

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

سعی کنید برنامهٔ آنلاین [**مشاهده و ویرایش فراداده پاورپوینت**](https://products.aspose.app/slides/metadata) را امتحان کنید تا ببینید چگونه با استفاده از API Aspose.Slides ویژگی‌های سند را مدیریت می‌کنید:

[![مشاهده و ویرایش فراداده پاورپوینت](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **سوالات متداول**

**چگونه می‌توان یک ویژگی درونی را از یک ارائه حذف کرد؟**

ویژگی‌های درونی جزئی جدایی‌ناپذیر از ارائه هستند و نمی‌توان آنها را به‌طور کامل حذف کرد. با این حال می‌توانید مقدار آنها را تغییر داده یا (در صورت امکان) به مقدار خالی تنظیم کنید.

**اگر ویژگی سفارشی‌ای اضافه کنم که قبلاً وجود داشته باشد، چه می‌شود؟**

در صورتی که ویژگی سفارشی‌ای اضافه کنید که از قبل وجود داشته باشد، مقدار موجود آن با مقدار جدید بازنویسی می‌شود. نیازی به حذف یا بررسی پیش‑از‑این ویژگی نیست، زیرا Aspose.Slides به‌طور خودکار مقدار ویژگی را به‌روزرسانی می‌کند.

**آیا می‌توانم بدون بارگذاری کامل ارائه، به ویژگی‌های ارائه دسترسی پیدا کنم؟**

بله. می‌توانید از [PresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/cpp/aspose.slides/presentationfactory/getpresentationinfo/) سپس [IPresentationInfo::ReadDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/) استفاده کنید تا متادیتای ذخیره‌شدهٔ سند را بدون ایجاد نمونهٔ [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) بخوانید. برای یک مثال کامل گزارش‌گیری و محدودیت‌های خاص فرمت، به [Build a Lightweight Presentation Inventory](/slides/fa/cpp/examine-presentation/) مراجعه کنید.

**آیا می‌توانم ویژگی‌های عمومی یک ارائه رمزگذاری شده را بدون رمز عبور باز کردن آن بخوانم؟**

بله. ارائه باید با عبور `false` به [IProtectionManager::set_EncryptDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/iprotectionmanager/set_encryptdocumentproperties/) رمزگذاری شده باشد و باید با عبور `true` به [LoadOptions::set_OnlyLoadDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_onlyloaddocumentproperties/) بارگذاری شود.

**آیا می‌توانم یک فایل PPTX رمزگذاری‌شده را در حالت فقط‑ویژگی‑سند به‌روزرسانی کنم؟**

نه. داده‌های عمومی و رمزگذاری‌شده باید همگام باشند، بنابراین به‌روزرسانی یک فایل PPTX رمزگذاری‌شده نیاز به بارگذاری کامل ارائه با رمز عبور صحیح دارد.