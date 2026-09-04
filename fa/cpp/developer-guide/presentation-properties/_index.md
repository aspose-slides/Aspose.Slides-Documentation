---
title: "مدیریت ویژگی‌های ارائه در C++"
linktitle: "ویژگی‌های ارائه"
type: docs
weight: 70
url: /fa/cpp/presentation-properties/
keywords:
- "ویژگی‌های پاورپوینت"
- "ویژگی‌های ارائه"
- "ویژگی‌های سند"
- "ویژگی‌های داخلی"
- "ویژگی‌های سفارشی"
- "ویژگی‌های پیشرفته"
- "مدیریت ویژگی‌ها"
- "تغییر ویژگی‌ها"
- "متادیتای سند"
- "ویرایش متادیتا"
- "زبان اصلاح‌گری"
- "زبان پیش‌فرض"
- "پاورپوینت"
- "OpenDocument"
- "ارائه"
- "C++"
- "Aspose.Slides"
description: "ویژگی‌های ارائه را در Aspose.Slides برای C++ به‌صورت جامع مدیریت کنید و جستجو، برندینگ و جریان کار را در فایل‌های پاورپوینت و OpenDocument خود بهینه‌سازی کنید."
---
## **معرفی**

Aspose.Slides دو نوع ویژگی سند را پشتیبانی می‌کند: **Built-in** و **Custom**. هر دو این نوع ویژگی‌ها به راحتی می‌توانند با استفاده از API Aspose.Slides دسترسی و مدیریت شوند.

Aspose.Slides به شما اجازه می‌دهد با ویژگی‌های سند ارائه از طریق رابط [IDocumentProperties](https://reference.aspose.com/slides/fa/cpp/aspose.slides/idocumentproperties/) کار کنید. یک نمونه از این رابط توسط [IPresentation::get_DocumentProperties](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ipresentation/get_documentproperties/) بازگردانده می‌شود. مثال‌های زیر نشان می‌دهند چگونه این ویژگی‌ها را بخوانید، تغییر دهید و مدیریت کنید.

{{% alert color="info" title="Note" %}}
لطفاً توجه داشته باشید که شما نمی‌توانید مقادیر را برای فیلدهای **Application** و **Producer** تنظیم کنید، زیرا Aspose Ltd. و Aspose.Slides for C++ x.x.x در این فیلدها نمایش داده خواهند شد.
{{% /alert %}}

## **مدیریت ویژگی‌های ارائه**

Microsoft PowerPoint ویژگی‌ای را برای افزودن برخی ویژگی‌ها به فایل‌های ارائه فراهم می‌کند. این ویژگی‌های سند اجازه می‌دهند اطلاعات مفیدی همراه با اسناد (فایل‌های ارائه) ذخیره شود. دو نوع ویژگی سند به شرح زیر وجود دارد

- ویژگی‌های تعریف‌شده توسط سیستم (Built-in)
- ویژگی‌های تعریف‌شده توسط کاربر (Custom)

**Built-in** ویژگی‌ها شامل اطلاعات کلی درباره سند مانند عنوان سند، نام نویسنده، آمار سند و غیره هستند. **Custom** ویژگی‌ها مواردی هستند که توسط کاربران به صورت جفت **Name/Value** تعریف می‌شوند، جایی که هم نام و هم مقدار توسط کاربر تعریف می‌شود. با استفاده از Aspose.Slides برای C++، توسعه‌دهندگان می‌توانند مقادیر ویژگی‌های Built-in و همچنین ویژگی‌های Custom را دسترسی و تغییر دهند. Microsoft PowerPoint 2007 امکان مدیریت ویژگی‌های سند فایل‌های ارائه را فراهم می‌کند. تنها کافی است بر روی نماد Office کلیک کنید و سپس گزینه **Prepare | Properties | Advanced Properties** را در Microsoft PowerPoint 2007 انتخاب کنید. پس از انتخاب گزینه **Advanced Properties**، دیالوگی ظاهر می‌شود که به شما اجازه می‌دهد ویژگی‌های سند فایل PowerPoint را مدیریت کنید. در **Properties Dialog**، می‌توانید ببینید که چندین برگه مانند **General, Summary, Statistics, Contents and Custom** وجود دارد. تمام این برگه‌ها امکان پیکربندی انواع مختلف اطلاعات مرتبط با فایل‌های PowerPoint را فراهم می‌آورند. برگه **Custom** برای مدیریت ویژگی‌های سفارشی فایل‌های PowerPoint استفاده می‌شود.

## **خواندن ویژگی‌های عمومی از ارائه رمزگذاری‌شده**

یک رمز عبور باز کردن معمولاً محتوای ارائه و ویژگی‌های سند را محافظت می‌کند. هنگامی که یک ارائه با عبور `false` به [IProtectionManager::set_EncryptDocumentProperties](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iprotectionmanager/set_encryptdocumentproperties/) رمزگذاری می‌شود، ویژگی‌های سند آن همچنان عمومی باقی می‌مانند. سپس یک برنامه می‌تواند با عبور `true` به [LoadOptions::set_OnlyLoadDocumentProperties](https://reference.aspose.com/slides/fa/cpp/aspose.slides/loadoptions/set_onlyloaddocumentproperties/) متادیتای عمومی را بدون ارائه رمز عبور باز کردن بخواند.

`set_OnlyLoadDocumentProperties` تعیین می‌کند Aspose.Slides چه چیزی را بارگذاری کند؛ هیچ چیزی را رمزگشائی نمی‌کند. اگر ویژگی‌ها در رمزگذاری گنجانده شده باشند، بارگذاری آن‌ها بدون رمز عبور شکست می‌خورد. اگر ارائه رمزگذاری نشده باشد، این گزینه نادیده گرفته می‌شود و ارائه کامل بارگذاری می‌شود.

مثال زیر حالت بارگذاری را از طریق [IProtectionManager::get_IsOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iprotectionmanager/get_isonlydocumentpropertiesloaded/) بررسی می‌کند و سپس ویژگی‌های Built-in را از طریق [IPresentation::get_DocumentProperties](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ipresentation/get_documentproperties/) می‌خواند:

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/IProtectionManager.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_OnlyLoadDocumentProperties(true);

auto presentation = MakeObject<Presentation>(u"public-properties-encrypted.pptx", loadOptions);

if (presentation->get_ProtectionManager()->get_IsOnlyDocumentPropertiesLoaded())
{
    auto properties = presentation->get_DocumentProperties();

    Console::WriteLine(u"Author: " + properties->get_Author());
    Console::WriteLine(u"Title: " + properties->get_Title());
    Console::WriteLine(u"Keywords: " + properties->get_Keywords());
}
else
{
    Console::WriteLine(u"The presentation was not loaded in document-properties-only mode.");
}

presentation->Dispose();
```

در این حالت، محتوای اسلایدها بارگذاری نمی‌شود. اسلایدها، ماسترها، چیدمان‌ها، شکل‌ها، رسانه‌ها و سایر اشیای ارائه در دسترس نیستند. برنامه‌ها باید همیشه قبل از انجام عملی که به مدل کامل شیء ارائه نیاز دارد، `get_IsOnlyDocumentPropertiesLoaded` را بررسی کنند.

{{% alert color="warning" title="Warning" %}}
متادیتای عمومی ممکن است نام‌های نویسندگان، عناوین، موضوعات، کلمات کلیدی، اطلاعات شرکت، نظرات و مقادیر سفارشی را فاش کند. ویژگی‌های حساس را همراه با ارائه رمزگذاری کنید. تنها زمانی که سیستم‌های ایندکس‌سازی، طبقه‌بندی، جستجو یا مدیریت اسناد نیاز خاصی به دسترسی بدون رمز عبور دارند، آن‌ها را عمومی بگذارید.
{{% /alert %}}

## **به‌روزرسانی ویژگی‌های یک ارائه رمزگذاری‌شده**

برای یک فایل PPTX رمزگذاری‌شده، ارائه‌ای که پس از فراخوانی `set_OnlyLoadDocumentProperties(true)` بارگذاری می‌شود، برای خواندن متادیتای عمومی در نظر گرفته شده است. Aspose.Slides نمی‌تواند ویژگی‌های تغییر یافته را از آن شیء فقط‑متادیتایی ذخیره کند زیرا ویژگی‌های عمومی باید با داده‌های مرتبط درون ارائه رمزگذاری‌شده سازگار باقی بمانند. بنابراین به‌روزرسانی آن‌ها نیاز به رمز عبور صحیح باز کردن و یک بارگذاری کامل دارد.

مثال زیر ارائه را با استفاده از [LoadOptions::set_Password](https://reference.aspose.com/slides/fa/cpp/aspose.slides/loadoptions/set_password/) باز می‌کند، ویژگی‌های Built-in عمومی را به‌روزرسانی می‌کند و نتیجه را ذخیره می‌نماید. سپس با استفاده از [IPresentationInfo::get_IsEncrypted](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ipresentationinfo/get_isencrypted/) بررسی می‌کند که رمزگذاری حفظ شده است و متادیتای عمومی را بدون رمز عبور دوباره باز می‌کند تا مقادیر جدید را تأیید کند:

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/IPresentationInfo.h>
#include <DOM/IProtectionManager.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <DOM/PresentationFactory.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

const String inputPath = u"public-properties-encrypted.pptx";
const String outputPath = u"updated-public-properties-encrypted.pptx";

{
    auto loadOptions = MakeObject<LoadOptions>();
    loadOptions->set_Password(u"open_password");

    auto presentation = MakeObject<Presentation>(inputPath, loadOptions);
    presentation->get_DocumentProperties()->set_Title(u"Updated Product Roadmap");
    presentation->get_DocumentProperties()->set_Keywords(u"roadmap, planning, indexed");
    presentation->Save(outputPath, SaveFormat::Pptx);
    presentation->Dispose();
}

auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(outputPath);
Console::WriteLine(presentationInfo->get_IsEncrypted() ? u"The presentation is encrypted." : u"The presentation is not encrypted.");

auto metadataLoadOptions = MakeObject<LoadOptions>();
metadataLoadOptions->set_OnlyLoadDocumentProperties(true);

auto metadataPresentation = MakeObject<Presentation>(outputPath, metadataLoadOptions);

if (metadataPresentation->get_ProtectionManager()->get_IsOnlyDocumentPropertiesLoaded())
{
    Console::WriteLine(u"Title: " + metadataPresentation->get_DocumentProperties()->get_Title());
    Console::WriteLine(u"Keywords: " + metadataPresentation->get_DocumentProperties()->get_Keywords());
}
else
{
    Console::WriteLine(u"The presentation was not loaded in document-properties-only mode.");
}

metadataPresentation->Dispose();
```

اگر یک برنامه اجازه‌ی رمزگشایی یا بارگذاری محتوای ارائه را نداشته باشد، باید ویژگی‌های عمومی یک فایل PPTX رمزگذاری‌شده را به‌عنوان فقط‑خواندنی در نظر بگیرد.

## **دسترسی به ویژگی‌های Built-in**

این ویژگی‌ها که توسط شیء **IDocumentProperties** افشا می‌شوند شامل: **Creator(Author)**، **Description**، **KeyWords**، **Created** (تاریخ ایجاد)، **Modified** (تاریخ تغییر)، **Printed** (آخرین تاریخ چاپ)، **LastModifiedBy**، **Keywords**، **SharedDoc** (آیا بین تولیدکنندگان مختلف به اشتراک گذاشته شده است؟)، **PresentationFormat**، **Subject** و **Title** می‌باشند.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessBuiltinProperties-AccessBuiltinProperties.cpp" >}}

## **تغییر ویژگی‌های Built-in**

تغییر ویژگی‌های Built-in فایل‌های ارائه به آسانی دسترسی به آن‌هاست. می‌توانید به سادگی یک مقدار رشته‌ای به هر ویژگی موردنظر اختصاص دهید و مقدار ویژگی تغییر خواهد کرد. در مثال زیر نشان دادیم که چگونه می‌توانیم ویژگی‌های سند Built-in ارائه را تغییر دهیم.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-UpdatePresentationProperties-UpdatePresentationProperties.cpp" >}}

## **افزودن ویژگی‌های سفارشی به ارائه**

Aspose.Slides برای C++ همچنین به توسعه‌دهندگان اجازه می‌دهد مقادیر سفارشی برای ویژگی‌های سند ارائه اضافه کنند. مثالی در زیر نشان می‌دهد چگونه ویژگی‌های سفارشی برای یک ارائه تنظیم شوند.

``` cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// ایجاد یک نمونه از کلاس Presentation
auto presentation = System::MakeObject<Presentation>();

// دریافت ویژگی‌های سند
auto documentProperties = presentation->get_DocumentProperties();

// افزودن ویژگی‌های سفارشی
documentProperties->idx_set(u"New Custom", ObjectExt::Box<int32_t>(12));
documentProperties->idx_set(u"My Name", ObjectExt::Box<String>(u"Mudassir"));
documentProperties->idx_set(u"Custom", ObjectExt::Box<int32_t>(124));

// دریافت نام ویژگی در اندیس مشخص
String getPropertyName = documentProperties->GetCustomPropertyName(2);

// حذف ویژگی انتخاب‌شده
documentProperties->RemoveCustomProperty(getPropertyName);

// ذخیره ارائه
presentation->Save(u"CustomDocumentProperties_out.pptx", SaveFormat::Pptx);
```

## **دسترسی و تغییر ویژگی‌های سفارشی**

Aspose.Slides برای C++ همچنین به توسعه‌دهندگان امکان دسترسی به مقادیر ویژگی‌های سفارشی را می‌دهد. مثالی در زیر نشان می‌دهد چگونه می‌توانید به تمام این ویژگی‌های سفارشی برای یک ارائه دسترسی داشته باشید و آن‌ها را تغییر دهید.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessModifyingProperties-AccessModifyingProperties.cpp" >}}

## **تنظیم زبان اصلاح‌گری**

Aspose.Slides خصوصیت [LanguageId](https://reference.aspose.com/slides/fa/cpp/aspose.slides/baseportionformat/set_languageid/) (که توسط کلاس [PortionFormat](https://reference.aspose.com/slides/fa/cpp/aspose.slides/portionformat/) افشا می‌شود) را فراهم می‌کند تا به شما امکان تنظیم زبان اصلاح‌گری برای یک سند PowerPoint را بدهد. زبان اصلاح‌گری زبانی است که املا و گرامر در PowerPoint برای آن بررسی می‌شود.

این کد C++ نشان می‌دهد چگونه زبان اصلاح‌گری را برای یک PowerPoint تنظیم کنید:

```c++
#include <DOM/AutoShape.h>
#include <DOM/Fonts/FontData.h>
#include <DOM/IFontData.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Portion.h>
#include <DOM/Presentation.h>
using namespace Aspose::Slides;

System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"sample.pptx");
System::SharedPtr<AutoShape> autoShape = System::ExplicitCast<AutoShape>(pres->get_Slide(0)->get_Shape(0));

System::SharedPtr<IParagraph> paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
System::SharedPtr<IPortionCollection> portions = paragraph->get_Portions();
portions->Clear();

System::SharedPtr<Portion> newPortion = System::MakeObject<Portion>();

System::SharedPtr<IFontData> font = System::MakeObject<FontData>(u"SimSun");
System::SharedPtr<IPortionFormat> portionFormat = newPortion->get_PortionFormat();
portionFormat->set_ComplexScriptFont(font);
portionFormat->set_EastAsianFont(font);
portionFormat->set_LatinFont(font);

portionFormat->set_LanguageId(u"zh-CN");
// تنظیم شناسه زبان اصلاح‌گری

newPortion->set_Text(u"1。");
portions->Add(newPortion);
```

## **تنظیم زبان پیش‌فرض**

این کد C++ نشان می‌دهد چگونه زبان پیش‌فرض را برای کل یک ارائه PowerPoint تنظیم کنید:

```c++
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/console.h>
using namespace Aspose::Slides;

System::SharedPtr<LoadOptions> loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_DefaultTextLanguage(u"en-US");

System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(loadOptions);

// یک شکل مستطیل جدید با متن اضافه می‌کند
System::SharedPtr<IAutoShape> shp = pres->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 150.0f, 50.0f);
System::SharedPtr<ITextFrame> textFrame = shp->get_TextFrame();
textFrame->set_Text(u"New Text");

// زبان اولین بخش را بررسی می‌کند
System::Console::WriteLine(textFrame->get_Paragraph(0)->get_Portion(0)->get_PortionFormat()->get_LanguageId());
```

## **مثال زنده**

سعی کنید برنامه آنلاین [**Aspose.Slides Metadata**](https://products.aspose.app/slides/fa/metadata) را امتحان کنید تا ببینید چگونه با ویژگی‌های سند از طریق API Aspose.Slides کار می‌کند:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/fa/metadata)

## **پرسش‌های متداول**

**چگونه می‌توانم یک ویژگی Built-in را از یک ارائه حذف کنم؟**

ویژگی‌های Built-in جزئی جدایی‌ناپذیر از ارائه هستند و نمی‌توان آن‌ها را به‌طور کامل حذف کرد. با این حال، می‌توانید مقادیر آن‌ها را تغییر دهید یا در صورت امکان ویژگی را به مقدار خالی تنظیم کنید.

**چه اتفاقی می‌افتد اگر یک ویژگی سفارشی که قبلاً وجود دارد را اضافه کنم؟**

اگر یک ویژگی سفارشی که از قبل وجود دارد را اضافه کنید، مقدار موجود آن با مقدار جدید جایگزین می‌شود. نیازی به حذف یا بررسی پیش‌ازبه ویژگی نیست، زیرا Aspose.Slides به‌صورت خودکار مقدار ویژگی را به‌روزرسانی می‌کند.

**آیا می‌توانم بدون بارگذاری کامل ارائه به ویژگی‌های ارائه دسترسی پیدا کنم؟**

بله. از [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) و سپس [IPresentationInfo::ReadDocumentProperties](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/) استفاده کنید تا متادیتای ذخیره‌شده سند را بدون ایجاد یک نمونه [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) بخوانید. برای مثال کامل گزارش‌گیری و محدودیت‌های خاص قالب، به [Build a Lightweight Presentation Inventory](/slides/fa/cpp/examine-presentation/) مراجعه کنید.

**آیا می‌توانم ویژگی‌های عمومی یک ارائه رمزگذاری‌شده را بدون رمز عبور باز کردن آن بخوانم؟**

بله. ارائه باید با عبور `false` به `set_EncryptDocumentProperties` رمزگذاری شده باشد و با عبور `true` به `set_OnlyLoadDocumentProperties` بارگذاری شده باشد.

**آیا می‌توانم یک فایل PPTX رمزگذاری‌شده را در حالت فقط‑ویژگی‌های‑سند به‌روزرسانی کنم؟**

خیر. داده‌های ویژگی عمومی و رمزگذاری‌شده باید سازگار باقی بمانند، بنابراین به‌روزرسانی یک فایل PPTX رمزگذاری‌شده نیازمند بارگذاری کامل ارائه با رمز عبور صحیح است.