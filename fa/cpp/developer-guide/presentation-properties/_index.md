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
- ویژگی‌های داخلی
- ویژگی‌های سفارشی
- ویژگی‌های پیشرفته
- مدیریت ویژگی‌ها
- تغییر ویژگی‌ها
- فراداده سند
- ویرایش فراداده
- زبان تصحیح املایی
- زبان پیش‌فرض
- PowerPoint
- OpenDocument
- ارائه
- C++
- Aspose.Slides
description: "ویژگی‌های ارائه را در Aspose.Slides برای C++ به‌صورت کامل مدیریت کنید و جستجو، برندینگ و جریان کار را در فایل‌های PowerPoint و OpenDocument خود بهینه‌سازی کنید."
---
## **معرفی**

Aspose.Slides دو نوع ویژگی سند را پشتیبانی می‌کند: **Built-in** و **Custom**. هر دو نوع این ویژگی‌ها به راحتی می‌توانند با استفاده از API Aspose.Slides دسترسی و مدیریت شوند.

Aspose.Slides به شما امکان کار با ویژگی‌های سند ارائه را از طریق رابط [IDocumentProperties](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.i_document_properties) می‌دهد. یک نمونه از این رابط توسط متد [Presentation::get_DocumentProperties](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/get_documentproperties/) برگردانده می‌شود. مثال‌های زیر نشان می‌دهند چگونه می‌توان این ویژگی‌ها را خواند، تغییر داد و مدیریت کرد.

{{% alert color="info" %}} 
لطفاً توجه داشته باشید که نمی‌توانید مقدارهایی را برای فیلدهای **Application** و **Producer** تنظیم کنید، زیرا Aspose Ltd. و Aspose.Slides for C++ x.x.x در این فیلدها نمایش داده خواهند شد.
{{% /alert %}} 

## **مدیریت ویژگی‌های ارائه**

Microsoft PowerPoint قابلیتی برای افزودن برخی ویژگی‌ها به فایل‌های ارائه فراهم می‌کند. این ویژگی‌های سند اجازه می‌دهند اطلاعات مفیدی همراه با اسناد (فایل‌های ارائه) ذخیره شود. دو نوع ویژگی سند به شرح زیر وجود دارد:

- ویژگی‌های تعریف شده توسط سیستم (Built-in)
- ویژگی‌های تعریف شده توسط کاربر (Custom)

ویژگی‌های **Built-in** شامل اطلاعات عمومی درباره سند هستند، مانند عنوان سند، نام نویسنده، آمار سند و غیره. ویژگی‌های **Custom** آنهایی هستند که توسط کاربران به صورت جفت‌های **Name/Value** تعریف می‌شوند، که هم نام و هم مقدار توسط کاربر تعیین می‌شود. با استفاده از Aspose.Slides for C++، توسعه‌دهندگان می‌توانند به مقادیر ویژگی‌های داخلی و همچنین ویژگی‌های سفارشی دسترسی داشته و آنها را تغییر دهند. Microsoft PowerPoint 2007 امکان مدیریت ویژگی‌های سند فایل‌های ارائه را فراهم می‌کند. کافی است روی نماد Office کلیک کنید و سپس گزینه **Prepare | Properties | Advanced Properties** منو در Microsoft PowerPoint 2007 را انتخاب کنید. پس از انتخاب گزینه **Advanced Properties**، یک دیالوگ نمایش داده می‌شود که به شما اجازه می‌دهد ویژگی‌های سند فایل PowerPoint را مدیریت کنید. در **Properties Dialog** می‌توانید صفحه‌های تب متعددی مانند **General, Summary, Statistics, Contents and Custom** مشاهده کنید. همه این صفحات تب امکان پیکربندی انواع مختلف اطلاعات مرتبط با فایل‌های PowerPoint را فراهم می‌کنند. تب **Custom** برای مدیریت ویژگی‌های سفارشی فایل‌های PowerPoint استفاده می‌شود.

## **دسترسی به ویژگی‌های Built-in**

این ویژگی‌ها که توسط شیء **IDocumentProperties** نشان داده می‌شوند شامل: **Creator(Author)**، **Description**، **KeyWords**، **Created** (تاریخ ایجاد)، **Modified** (تاریخ تغییر)، **Printed** (آخرین تاریخ چاپ)، **LastModifiedBy**، **Keywords**، **SharedDoc** (آیا بین تولیدکنندگان مختلف به اشتراک گذاشته شده است؟)، **PresentationFormat**، **Subject** و **Title**.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessBuiltinProperties-AccessBuiltinProperties.cpp" >}}

## **تغییر ویژگی‌های Built-in**

تغییر ویژگی‌های داخلی فایل‌های ارائه به همان سادگی دسترسی به آنهاست. به سادگی می‌توانید مقدار متنی را به هر ویژگی مورد نظر اختصاص دهید و مقدار ویژگی تغییر خواهد کرد. در مثال زیر، نشان دادیم چگونه می‌توان ویژگی‌های داخلی سند ارائه را تغییر داد.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-UpdatePresentationProperties-UpdatePresentationProperties.cpp" >}}

## **افزودن ویژگی‌های سفارشی به ارائه**

Aspose.Slides for C++ همچنین به توسعه‌دهندگان اجازه می‌دهد مقادیر سفارشی برای ویژگی‌های سند ارائه اضافه کنند. یک مثال در زیر نشان می‌دهد چگونه می‌توان ویژگی‌های سفارشی را برای یک ارائه تنظیم کرد.

``` cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// نمونه‌سازی کلاس Presentation
auto presentation = System::MakeObject<Presentation>();

// دریافت ویژگی‌های سند
auto documentProperties = presentation->get_DocumentProperties();

// افزودن ویژگی‌های سفارشی
documentProperties->idx_set(u"New Custom", ObjectExt::Box<int32_t>(12));
documentProperties->idx_set(u"My Name", ObjectExt::Box<String>(u"Mudassir"));
documentProperties->idx_set(u"Custom", ObjectExt::Box<int32_t>(124));

// دریافت نام ویژگی در ایندکس مشخص
String getPropertyName = documentProperties->GetCustomPropertyName(2);

// حذف ویژگی انتخاب‌شده
documentProperties->RemoveCustomProperty(getPropertyName);

// ذخیرهٔ ارائه
presentation->Save(u"CustomDocumentProperties_out.pptx", SaveFormat::Pptx);
```

## **دسترسی و تغییر ویژگی‌های سفارشی**

Aspose.Slides for C++ همچنین به توسعه‌دهندگان اجازه می‌دهد به مقادیر ویژگی‌های سفارشی دسترسی پیدا کنند. یک مثال در زیر نشان می‌دهد چگونه می‌توانید به تمام این ویژگی‌های سفارشی برای یک ارائه دسترسی داشته و آنها را تغییر دهید.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessModifyingProperties-AccessModifyingProperties.cpp" >}}

## **تنظیم زبان تصحیح املایی**

Aspose.Slides ویژگی [LanguageId](https://reference.aspose.com/slides/fa/cpp/aspose.slides/baseportionformat/set_languageid/) (که توسط کلاس [PortionFormat](https://reference.aspose.com/slides/fa/cpp/aspose.slides/portionformat/) ارائه می‌شود) را فراهم می‌کند تا بتوانید زبان تصحیح املایی یک سند PowerPoint را تنظیم کنید. زبان تصحیح املایی زبانی است که در آن املا و دستور زبان PowerPoint بررسی می‌شود.

این کد C++ نشان می‌دهد چگونه زبان تصحیح املایی را برای یک PowerPoint تنظیم کنید:

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
// تعیین شناسه زبان تصحیح املایی

newPortion->set_Text(u"1。");
portions->Add(newPortion);
```

## **تنظیم زبان پیش‌فرض**

این کد C++ نشان می‌دهد چگونه زبان پیش‌فرض را برای یک ارائه کامل PowerPoint تنظیم کنید:

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

سعی کنید برنامه آنلاین [**Aspose.Slides Metadata**](https://products.aspose.app/slides/fa/metadata) را امتحان کنید تا ببینید چگونه می‌توان با ویژگی‌های سند از طریق API Aspose.Slides کار کرد:

[![نمایش و ویرایش متادیتای PowerPoint](slides-metadata.png)](https://products.aspose.app/slides/fa/metadata)

## ***سوالات متداول**

### چگونه می‌توان یک ویژگی Built-in را از یک ارائه حذف کرد؟

ویژگی‌های Built-in جزئی اساسی از ارائه هستند و نمی‌توانند به طور کامل حذف شوند. با این حال، می‌توانید مقدار آنها را تغییر دهید یا در صورت امکان توسط ویژگی خاص، آنها را خالی کنید.

### چه می‌شود اگر یک ویژگی سفارشی که قبلاً وجود دارد را اضافه کنم؟

اگر یک ویژگی سفارشی که قبلاً وجود دارد را اضافه کنید، مقدار موجود آن با مقدار جدید جایگزین می‌شود. نیازی به حذف یا بررسی قبلی ویژگی نیست، زیرا Aspose.Slides به‌طور خودکار مقدار ویژگی را به‌روز می‌کند.

### آیا می‌توانم ویژگی‌های ارائه را بدون بارگذاری کامل ارائه دسترسی داشته باشم؟

بله، می‌توانید با استفاده از متد `GetPresentationInfo` از کلاس [PresentationFactory](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentationfactory/) ویژگی‌های ارائه را بدون بارگذاری کامل دریافت کنید. سپس از متد `ReadDocumentProperties` ارائه‌شده توسط اینترفیس [IPresentationInfo](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ipresentationinfo/) برای خواندن کارآمد ویژگی‌ها استفاده کنید، که حافظه را ذخیره کرده و عملکرد را بهبود می‌بخشد.