---
title: مدیریت ویژگی‌های ارائه در C++
linktitle: ویژگی‌های ارائه
type: docs
weight: 70
url: /fa/cpp/presentation-properties/
keywords:
- ویژگی‌های پاورپوینت
- ویژگی‌های ارائه
- ویژگی‌های سند
- ویژگی‌های داخلی
- ویژگی‌های سفارشی
- ویژگی‌های پیشرفته
- مدیریت ویژگی‌ها
- تغییر ویژگی‌ها
- فراداده سند
- ویرایش فراداده
- زبان تصحیح املایی
- زبان پیش‌فرض
- پاورپوینت
- OpenDocument
- ارائه
- C++
- Aspose.Slides
description: "ویژگی‌های ارائه را در Aspose.Slides برای C++ به‌صورت کامل مدیریت کنید و جستجو، برندینگ و گردش کار را در فایل‌های پاورپوینت و OpenDocument خود بهینه کنید."
---
## **مقدمه**

Aspose.Slides دو نوع ویژگی سند را پشتیبانی می‌کند: **Built-in** و **Custom**. هر دو نوع ویژگی به راحتی می‌توانند از طریق API Aspose.Slides دسترسی و مدیریت شوند.

Aspose.Slides به شما امکان می‌دهد تا با ویژگی‌های سند ارائه از طریق اینترفیس [IDocumentProperties](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.i_document_properties) کار کنید. نمونه‌ای از این اینترفیس توسط متد [Presentation::get_DocumentProperties](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/get_documentproperties/) بازگردانده می‌شود. مثال‌های زیر نشان می‌دهند چگونه این ویژگی‌ها را بخوانید، تغییر دهید و مدیریت کنید.

{{% alert color="info" title="Note" %}}
لطفاً توجه داشته باشید که نمی‌توانید مقادیر را برای فیلدهای **Application** و **Producer** تنظیم کنید، زیرا Aspose Ltd. و Aspose.Slides for C++ x.x.x در مقابل این فیلدها نمایش داده خواهند شد.
{{% /alert %}} 

## **مدیریت ویژگی‌های ارائه**

Microsoft PowerPoint ویژگی‌ای برای افزودن برخی ویژگی‌ها به فایل‌های ارائه فراهم می‌کند. این ویژگی‌های سند امکان ذخیره اطلاعات مفید همراه با اسناد (فایل‌های ارائه) را فراهم می‌آورند. دو نوع ویژگی سند وجود دارد:

- ویژگی‌های تعریف‌شده توسط سیستم (Built-in)
- ویژگی‌های تعریف‌شده توسط کاربر (Custom)

**Built-in** ویژگی‌ها اطلاعات کلی درباره سند مانند عنوان سند، نام نویسنده، آمار سند و غیره را شامل می‌شوند. **Custom** ویژگی‌ها آنهایی هستند که توسط کاربران به‌عنوان جفت **Name/Value** تعریف می‌شوند، که هر دو نام و مقدار توسط کاربر تعیین می‌شود. با استفاده از Aspose.Slides for C++، توسعه‌دهندگان می‌توانند مقادیر ویژگی‌های داخلی و همچنین ویژگی‌های سفارشی را دسترسی و تغییر دهند. Microsoft PowerPoint 2007 امکان مدیریت ویژگی‌های سند فایل‌های ارائه را فراهم می‌کند. تمام کاری که باید انجام دهید این است که نماد Office را کلیک کنید و سپس منوی **Prepare | Properties | Advanced Properties** را انتخاب کنید. پس از انتخاب **Advanced Properties**، یک دیالوگ ظاهر می‌شود که به شما اجازه می‌دهد ویژگی‌های سند فایل PowerPoint را مدیریت کنید. در **Properties Dialog** می‌توانید ببینید که بسیاری از تب‌ها مانند **General, Summary, Statistics, Contents and Custom** وجود دارند. همه این تب‌ها امکان پیکربندی انواع مختلف اطلاعات مرتبط با فایل‌های PowerPoint را می‌دهند. تب **Custom** برای مدیریت ویژگی‌های سفارشی فایل‌های PowerPoint استفاده می‌شود.

## **دسترسی به ویژگی‌های Built-in**

این ویژگی‌ها که توسط شیء **IDocumentProperties** در دسترس قرار می‌گیرند شامل: **Creator(Author)**، **Description**، **KeyWords**، **Created** (تاریخ ایجاد)، **Modified** (تاریخ تغییر)، **Printed** (تاریخ آخرین چاپ)، **LastModifiedBy**، **Keywords**، **SharedDoc** (آیا بین تولیدکنندگان مختلف به اشتراک گذاشته شده است؟)، **PresentationFormat**، **Subject** و **Title** هستند.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessBuiltinProperties-AccessBuiltinProperties.cpp" >}}

## **تغییر ویژگی‌های Built-in**

تغییر ویژگی‌های داخلی فایل‌های ارائه به آسانی دسترسی به آن‌ها است. می‌توانید به سادگی یک مقدار رشته‌ای را به هر ویژگی مورد نظر اختصاص دهید و مقدار ویژگی تغییر خواهد کرد. در مثال زیر نشان دادیم که چگونه می‌توان ویژگی‌های داخلی سند یک فایل ارائه را تغییر داد.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-UpdatePresentationProperties-UpdatePresentationProperties.cpp" >}}

## **افزودن ویژگی‌های سفارشی به ارائه**

Aspose.Slides for C++ همچنین به توسعه‌دهندگان اجازه می‌دهد مقادیر سفارشی را برای ویژگی‌های سند ارائه اضافه کنند. مثال زیر نشان می‌دهد چگونه ویژگی‌های سفارشی را برای یک ارائه تنظیم کنیم.

``` cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// ایجاد نمونه از کلاس Presentation
auto presentation = System::MakeObject<Presentation>();

// دریافت ویژگی‌های سند
auto documentProperties = presentation->get_DocumentProperties();

// اضافه کردن ویژگی‌های سفارشی
documentProperties->idx_set(u"New Custom", ObjectExt::Box<int32_t>(12));
documentProperties->idx_set(u"My Name", ObjectExt::Box<String>(u"Mudassir"));
documentProperties->idx_set(u"Custom", ObjectExt::Box<int32_t>(124));

// دریافت نام ویژگی در فهرست خاص
String getPropertyName = documentProperties->GetCustomPropertyName(2);

// حذف ویژگی انتخاب شده
documentProperties->RemoveCustomProperty(getPropertyName);

// ذخیره‌سازی ارائه
presentation->Save(u"CustomDocumentProperties_out.pptx", SaveFormat::Pptx);
```

## **دسترسی و تغییر ویژگی‌های سفارشی**

Aspose.Slides for C++ همچنین به توسعه‌دهندگان اجازه می‌دهد مقادیر ویژگی‌های سفارشی را دسترسی داشته باشند. مثال زیر نشان می‌دهد چگونه می‌توانید تمام این ویژگی‌های سفارشی را برای یک ارائه دسترسی و تغییر دهید.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessModifyingProperties-AccessModifyingProperties.cpp" >}}

## **تنظیم زبان تصحیح املایی**

Aspose.Slides ویژگی [LanguageId](https://reference.aspose.com/slides/fa/cpp/aspose.slides/baseportionformat/set_languageid/) (که توسط کلاس [PortionFormat](https://reference.aspose.com/slides/fa/cpp/aspose.slides/portionformat/) در دسترس قرار می‌گیرد) را فراهم می‌کند تا به شما امکان تنظیم زبان بررسی املایی برای یک سند PowerPoint را بدهد. زبان بررسی املایی زبانی است که املا و گرامر در PowerPoint برای آن بررسی می‌شود.

این کد C++ نشان می‌دهد چگونه زبان بررسی املایی برای یک PowerPoint تنظیم شود:

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
// تنظیم شناسه یک زبان تصحیح املایی

newPortion->set_Text(u"1。");
portions->Add(newPortion);
```

## **تنظیم زبان پیش‌فرض**

این کد C++ نشان می‌دهد چگونه زبان پیش‌فرض برای یک ارائه کامل PowerPoint تنظیم شود:

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

// یک شکل مستطیلی جدید با متن اضافه می‌کند
System::SharedPtr<IAutoShape> shp = pres->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 150.0f, 50.0f);
System::SharedPtr<ITextFrame> textFrame = shp->get_TextFrame();
textFrame->set_Text(u"New Text");

// زبان اولین بخش را بررسی می‌کند
System::Console::WriteLine(textFrame->get_Paragraph(0)->get_Portion(0)->get_PortionFormat()->get_LanguageId());
```

## **مثال زنده**

سعی کنید برنامه آنلاین [**Aspose.Slides Metadata**](https://products.aspose.app/slides/fa/metadata) را امتحان کنید تا ببینید چگونه می‌توانید با ویژگی‌های سند از طریق API Aspose.Slides کار کنید:

[![مشاهده و ویرایش متادیتا PowerPoint](slides-metadata.png)](https://products.aspose.app/slides/fa/metadata)

## **سوالات متداول**

**چگونه می‌توان یک ویژگی Built-in را از یک ارائه حذف کرد؟**

ویژگی‌های Built-in جزء جدایی‌ناپذیر ارائه هستند و نمی‌توان آن‌ها را به‌طور کامل حذف کرد. با این حال، می‌توانید مقادیر آن‌ها را تغییر دهید یا در صورت امکان به مقدار خالی تنظیم کنید.

**اگر یک ویژگی سفارشی که قبلاً وجود دارد را اضافه کنم چه می‌شود؟**

اگر یک ویژگی سفارشی که قبلاً وجود دارد را اضافه کنید، مقدار موجود آن با مقدار جدید بازنویسی می‌شود. نیازی به حذف یا بررسی پیش از اضافه کردن نیست، زیرا Aspose.Slides به‌طور خودکار مقدار ویژگی را به‌روزرسانی می‌کند.

**آیا می‌توان ویژگی‌های ارائه را بدون بارگذاری کامل ارائه دسترسی پیدا کرد؟**

بله. از [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) استفاده کنید و سپس [IPresentationInfo::ReadDocumentProperties](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/) را برای خواندن متادیتاهای ذخیره‌شده سند بدون ایجاد یک نمونه [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) فراخوانی کنید. برای مثال کامل گزارش‌گیری و محدودیت‌های خاص قالب به بخش [Build a Lightweight Presentation Inventory](/slides/fa/cpp/examine-presentation/) مراجعه کنید.