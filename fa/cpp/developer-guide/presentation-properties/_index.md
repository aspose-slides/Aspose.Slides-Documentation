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
- متادیتای سند
- ویرایش متادیتا
- زبان تصحیح
- زبان پیش‌فرض
- PowerPoint
- OpenDocument
- ارائه
- C++
- Aspose.Slides
description: "ویژگی‌های ارائه را در Aspose.Slides برای C++ به‌طور کامل مدیریت کنید و جستجو، برندینگ و جریان کار را در فایل‌های PowerPoint و OpenDocument خود بهینه کنید."
---
## **مقدمه**

Aspose.Slides دو نوع ویژگی سند را پشتیبانی می‌کند: **Built-in** و **Custom**. هر دو نوع ویژگی به راحتی می‌توانند با استفاده از API Aspose.Slides دسترسی و مدیریت شوند.

Aspose.Slides به شما امکان کار با ویژگی‌های سند ارائه را از طریق واسط [IDocumentProperties](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.i_document_properties) می‌دهد. یک نمونه از این واسط توسط متد [Presentation::get_DocumentProperties](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/get_documentproperties/) برگردانده می‌شود. مثال‌های زیر نشان می‌دهند چگونه این ویژگی‌ها را بخوانید، تغییر دهید و مدیریت کنید.

{{% alert color="primary" %}} 

لطفاً توجه داشته باشید که نمی‌توانید مقادیر فیلدهای **Application** و **Producer** را تنظیم کنید، زیرا Aspose Ltd. و Aspose.Slides for C++ x.x.x در این فیلدها نمایش داده می‌شوند.

{{% /alert %}} 

## **مدیریت خصوصیات ارائه**

Microsoft PowerPoint قابلیت افزودن برخی ویژگی‌ها به فایل‌های ارائه را فراهم می‌کند. این ویژگی‌های سند امکان ذخیره‌سازی اطلاعات مفید همراه با سند (فایل‌های ارائه) را می‌دهند. دو نوع ویژگی سند وجود دارد:

- خصوصیات تعریف‌شده توسط سیستم (Built-in) Properties
- خصوصیات تعریف‌شده توسط کاربر (Custom) Properties

ویژگی‌های **Built-in** شامل اطلاعات کلی درباره سند نظیر عنوان سند، نام نویسنده، آمارهای سند و غیره هستند. ویژگی‌های **Custom** آن دسته از ویژگی‌هایی هستند که توسط کاربران به صورت جفت **نام/مقدار** تعریف می‌شوند، به‌طوری که هر دو نام و مقدار توسط کاربر تعیین می‌شود. با استفاده از Aspose.Slides for C++، توسعه‌دهندگان می‌توانند به مقادیر ویژگی‌های داخلی و همچنین ویژگی‌های سفارشی دسترسی و آن‌ها را تغییر دهند. Microsoft PowerPoint 2007 امکان مدیریت ویژگی‌های سند فایل‌های ارائه را فراهم می‌کند. کافی است بر روی نماد Office کلیک کنید و سپس منوی **Prepare | Properties | Advanced Properties** را در Microsoft PowerPoint 2007 انتخاب کنید. پس از انتخاب گزینه **Advanced Properties**، یک گفت‌وگو ظاهر می‌شود که به شما اجازه می‌دهد ویژگی‌های سند فایل PowerPoint را مدیریت کنید. در **Properties Dialog** می‌توانید ببینید که صفحات تب متعددی مانند **General, Summary, Statistics, Contents and Custom** وجود دارند. تمام این تب‌ها امکان تنظیم انواع مختلف اطلاعات مرتبط با فایل‌های PowerPoint را می‌دهند. تب **Custom** برای مدیریت ویژگی‌های سفارشی فایل‌های PowerPoint به کار می‌رود.

## **دسترسی به ویژگی‌های Built-in**

این ویژگی‌ها که توسط شیء **IDocumentProperties** در دسترس هستند شامل: **Creator(Author)**، **Description**، **KeyWords**، **Created** (تاریخ ایجاد)، **Modified** (تاریخ اصلاح)، **Printed** (تاریخ آخرین چاپ)، **LastModifiedBy**، **Keywords**، **SharedDoc** (آیا بین تولیدکنندگان مختلف به اشتراک گذاشته شده است؟)، **PresentationFormat**، **Subject** و **Title** می‌شوند.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessBuiltinProperties-AccessBuiltinProperties.cpp" >}}

## **تغییر ویژگی‌های Built-in**

تغییر ویژگی‌های داخلی فایل‌های ارائه به همان سادگی دسترسی به آن‌هاست. می‌توانید به سادگی یک مقدار رشته‌ای به هر ویژگی دلخواه اختصاص دهید و مقدار ویژگی تغییر خواهد کرد. در مثال زیر نشان دادیم چگونه می‌توان ویژگی‌های داخلی سند یک فایل ارائه را تغییر داد.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-UpdatePresentationProperties-UpdatePresentationProperties.cpp" >}}

## **افزودن ویژگی‌های سفارشی به ارائه**

Aspose.Slides for C++ همچنین به توسعه‌دهندگان امکان افزودن مقادیر سفارشی به ویژگی‌های سند ارائه را می‌دهد. مثالی در زیر نشان می‌دهد چگونه می‌توان ویژگی‌های سفارشی را برای یک ارائه تنظیم کرد.

``` cpp
// ایجاد شیء کلاس Presentation
// دریافت ویژگی‌های سند
// افزودن ویژگی‌های سفارشی
// دریافت نام ویژگی در ایندکس مشخص
// حذف ویژگی انتخاب‌شده
// ذخیره ارائه
auto presentation = System::MakeObject<Presentation>();

// Getting Document Properties
auto documentProperties = presentation->get_DocumentProperties();

// Adding Custom properties
documentProperties->idx_set(u"New Custom", ObjectExt::Box<int32_t>(12));
documentProperties->idx_set(u"My Name", ObjectExt::Box<String>(u"Mudassir"));
documentProperties->idx_set(u"Custom", ObjectExt::Box<int32_t>(124));

// Getting property name at particular index
String getPropertyName = documentProperties->GetCustomPropertyName(2);

// Removing selected property
documentProperties->RemoveCustomProperty(getPropertyName);

// Saving presentation
presentation->Save(u"CustomDocumentProperties_out.pptx", SaveFormat::Pptx);
```

## **دسترسی و تغییر ویژگی‌های سفارشی**

Aspose.Slides for C++ به توسعه‌دهندگان اجازه می‌دهد مقادیر ویژگی‌های سفارشی را دسترسی و تغییر دهند. مثالی در زیر نشان می‌دهد چگونه می‌توانید همه این ویژگی‌های سفارشی را برای یک ارائه دسترسی و تغییر دهید.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessModifyingProperties-AccessModifyingProperties.cpp" >}}

## **تنظیم زبان تصحیح**

Aspose.Slides ویژگی [LanguageId](https://reference.aspose.com/slides/fa/cpp/aspose.slides/baseportionformat/set_languageid/) (که توسط کلاس [PortionFormat](https://reference.aspose.com/slides/fa/cpp/aspose.slides/portionformat/) باز می‌شود) را فراهم می‌کند تا بتوانید زبان تصحیح املایی را برای یک سند PowerPoint تنظیم کنید. زبان تصحیح زبانی است که املاء و دستور زبان در PowerPoint برای آن بررسی می‌شود.

این کد C++ نشان می‌دهد چگونه زبان تصحیح را برای یک PowerPoint تنظیم کنید:

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(pptxFileName);
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
// set the Id of a proofing language

newPortion->set_Text(u"1。");
portions->Add(newPortion);
```

## **تنظیم زبان پیش‌فرض**

این کد C++ نشان می‌دهد چگونه زبان پیش‌فرض را برای یک ارائه کامل PowerPoint تنظیم کنید:

```c++
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

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/fa/metadata)

## ***سؤالات متداول**

**چگونه می‌توان یک ویژگی داخلی را از یک ارائه حذف کرد؟**

ویژگی‌های داخلی جزئی جدایی‌ناپذیر از ارائه هستند و نمی‌توان آن‌ها را کاملاً حذف کرد. اما می‌توانید مقادیر آن‌ها را تغییر دهید یا در صورت مجاز بودن، آن‌ها را خالی کنید.

**اگر ویژگی سفارشی‌ای که از قبل وجود دارد را اضافه کنم چه اتفاقی می‌افتد؟**

اگر ویژگی سفارشی‌ای که از قبل وجود دارد را اضافه کنید، مقدار موجود آن با مقدار جدید جایگزین می‌شود. نیازی به حذف یا بررسی پیش از افزودن آن نیست، زیرا Aspose.Slides به‌صورت خودکار مقدار ویژگی را به‌روزرسانی می‌کند.

**آیا می‌توانم ویژگی‌های ارائه را بدون بارگذاری کامل ارائه دسترسی داشته باشم؟**

بله، می‌توانید بدون بارگذاری کامل ارائه، ویژگی‌های ارائه را با استفاده از متد `GetPresentationInfo` از کلاس [PresentationFactory](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentationfactory/) دسترسی پیدا کنید. سپس با استفاده از متد `ReadDocumentProperties` ارائه‌شده توسط واسط [IPresentationInfo](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ipresentationinfo/) ویژگی‌ها را به‌صورت کارآمد بخوانید و حافظه و عملکرد را بهبود ببخشید.