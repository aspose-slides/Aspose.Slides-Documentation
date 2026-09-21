---
title: مدیریت فیلدهای متن در ارائه‌های PowerPoint با C++
linktitle: فیلدهای متن
type: docs
weight: 52
url: /fa/cpp/text-fields/
keywords:
- فیلد متن
- متن خودکار
- شماره اسلاید
- تاریخ و زمان
- سرصفحه
- پاورقی
- قسمت متن
- PowerPoint
- PPT
- PPTX
- C++
- Aspose.Slides
description: "ایجاد، بررسی، تغییر و حذف فیلدهای متن در ارائه‌های PowerPoint با Aspose.Slides برای C++. حفظ قالب‌بندی و بررسی فایل‌های ذخیره‌شده PPTX و PPT."
---
## **بررسی کلی**

یک پاراگراف متن از قسمت‌ها تشکیل شده است. یک [IPortion](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iportion/) معمولی شامل متن صریح است؛ یک قسمت فیلد همچنین یک [IField](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ifield/) دارد که نوع آن مقدار به‌روزرسانی خودکار مانند شماره اسلاید یا تاریخ را شناسایی می‌کند. دو قسمت می‌توانند همان کاراکترها را نمایش دهند در حالی که فقط یکی شامل فیلد است.

از [IPortion::get_Field](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iportion/get_field/) برای تشخیص آنها استفاده کنید: برای متن معمولی `nullptr` برمی‌گرداند. [IPortion::AddField](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iportion/addfield/) یک قسمت موجود را به فیلد تبدیل می‌کند. برای اینکه تبدیل مقدار باعث جایگزینی برچسب نشود، برچسب و مقدار پویا را در قسمت‌های جداگانه نگه دارید.

این راهنما فیلدهای داخل متن، قالب‌بندی آنها و ذخیره‌سازی در PPTX و PPT را پوشش می‌دهد. برای فریم‌های متن و پاراگراف‌ها، به [Manage Text](/slides/fa/cpp/manage-text/) مراجعه کنید.

## **ایجاد فیلد شماره اسلاید**

مثال زیر یک کادر متن شامل برچسب صریح `Slide ` به‌همراه یک شماره به‌روزرسانی خودکار ایجاد می‌کند. قبل از افزودن فیلد، اندازه، وزن و رنگ شماره تنظیم می‌شود، سپس ارائه‌ی ذخیره‌شده باز دوباره می‌شود و نوع فیلد، متن و قالب‌بندی آن بررسی می‌شود. هیچ فایل ورودی‌ای لازم نیست.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/ShapeType.h>
#include <DOM/ITextFrame.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortionCollection.h>
#include <DOM/Portion.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IColorFormat.h>
#include <DOM/FillType.h>
#include <DOM/NullableBool.h>
#include <DOM/IField.h>
#include <DOM/IFieldType.h>
#include <DOM/FieldType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40, 40, 240, 50);
shape->AddTextFrame(u"Slide ");
auto paragraph = shape->get_TextFrame()->get_Paragraph(0);

auto numberPortion = System::MakeObject<Portion>();
numberPortion->get_PortionFormat()->set_FontHeight(24);
numberPortion->get_PortionFormat()->set_FontBold(NullableBool::True);
numberPortion->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
numberPortion->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_DarkBlue());
paragraph->get_Portions()->Add(numberPortion);
numberPortion->AddField(FieldType::get_SlideNumber());

presentation->Save(u"slide_number.pptx", SaveFormat::Pptx);
presentation->Dispose();

auto reopened = System::MakeObject<Presentation>(u"slide_number.pptx");
auto savedShape = System::ExplicitCast<IAutoShape>(reopened->get_Slide(0)->get_Shape(0));
auto savedNumber = savedShape->get_TextFrame()->get_Paragraph(0)->get_Portion(1);
auto field = savedNumber->get_Field();
auto hasNumberField = field != nullptr && field->get_Type()->get_InternalString() == FieldType::get_SlideNumber()->get_InternalString();
auto format = savedNumber->get_PortionFormat();
auto formattingPreserved = format->get_FontHeight() == 24 && format->get_FontBold() == NullableBool::True;
formattingPreserved &= format->get_FillFormat()->get_SolidFillColor()->get_Color().ToArgb() == System::Drawing::Color::get_DarkBlue().ToArgb();

System::Console::WriteLine(u"Text: {0}", savedShape->get_TextFrame()->get_Text());
System::Console::WriteLine(u"Slide number field: {0}", hasNumberField);
System::Console::WriteLine(u"Formatting preserved: {0}", formattingPreserved);
reopened->Dispose();
```

ارائه جدید با شماره اسلاید ۱ شروع می‌شود، بنابراین متن مورد انتظار `Slide 1` است و هر دو بررسی باید `True` چاپ کنند. شماره پس از باز دوباره شدن همچنان یک فیلد باقی می‌ماند؛ یک مقدار صریح `1` نیست. تبدیل و ایندکس‌های بررسی به شکل و قسمت‌های ایجاد شده توسط این مثال ارجاع می‌دهند.

## **انتخاب نوع فیلد**

[FieldType](https://reference.aspose.com/slides/fa/cpp/aspose.slides/fieldtype/) پیاده‌سازی [IFieldType](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ifieldtype/) است و مقادیر پیش‌تعریف‌شده زیر را فراهم می‌کند. مقدار مناسب را به [AddField](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iportion/addfield/) پاس دهید.

| دسترسی‌کننده | هدف |
|---|---|
| [get_SlideNumber](https://reference.aspose.com/slides/fa/cpp/aspose.slides/fieldtype/get_slidenumber/) | شماره اسلاید فعلی. |
| [get_DateTime](https://reference.aspose.com/slides/fa/cpp/aspose.slides/fieldtype/get_datetime/) | تاریخ/زمان در قالب پیش‌فرض برنامهٔ رندرینگ. |
| [get_DateTime1](https://reference.aspose.com/slides/fa/cpp/aspose.slides/fieldtype/get_datetime1/)–[get_DateTime9](https://reference.aspose.com/slides/fa/cpp/aspose.slides/fieldtype/get_datetime9/) | قالب‌های پیش‌تعریف‌شدهٔ تاریخ یا ترکیب تاریخ/زمان. |
| [get_DateTime10](https://reference.aspose.com/slides/fa/cpp/aspose.slides/fieldtype/get_datetime10/)–[get_DateTime13](https://reference.aspose.com/slides/fa/cpp/aspose.slides/fieldtype/get_datetime13/) | قالب‌های پیش‌تعریف‌شدهٔ زمان، با گزینه‌های ثانیه و ساعت ۱۲‑ساعته. |
| [get_Header](https://reference.aspose.com/slides/fa/cpp/aspose.slides/fieldtype/get_header/) | فیلد سرصفحه؛ محدودیت‌های جایگزین‌کننده و قالب زیر را ببینید. |
| [get_Footer](https://reference.aspose.com/slides/fa/cpp/aspose.slides/fieldtype/get_footer/) | فیلد پاورقی. |

به عنوان مثال، [get_DateTime3](https://reference.aspose.com/slides/fa/cpp/aspose.slides/fieldtype/get_datetime3/) روز، نام کامل ماه و سال را به زبان انگلیسی ارائه می‌دهد. این‌ها قالب‌های فیلد پیش‌تعریف‌شده هستند، نه رشته‌های قالب تاریخ دلخواه. زبان قسمت، که با [IBasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ibaseportionformat/set_languageid/) تنظیم می‌شود، و برنامهٔ پردازش ارائه می‌توانند نتیجهٔ نمایش‌داده‌شده را تحت تأثیر قرار دهند.

## **ایجاد فیلد از رشته داخلی**

بارگذاری رشته‌ای [AddField](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iportion/addfield/) شناسهٔ فیلد داخلی را می‌پذیرد. زمانیکه نیاز به حفظ شناسه‌ای دارید که توسط برنامهٔ دیگری فراهم شده و مقدار پیش‌تعریف‌شده‌ای ندارد، از این روش استفاده کنید. می‌توانید یک [FieldType](https://reference.aspose.com/slides/fa/cpp/aspose.slides/fieldtype/fieldtype/) نیز از این شناسه بسازید. [IFieldType::get_InternalString](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ifieldtype/get_internalstring/) این شناسه را برای بازرسی در دسترس می‌گذارد.

این مثال فیلد `custom-report-id` مخصوص برنامه را با متن پیش‌فرض `Report-042` ذخیره می‌کند. هیچ فایل ورودی‌ای لازم نیست. این شناسه محاسبه‌ای ثبت نمی‌کند: Aspose.Slides شناسه‌های گزارش را برای نوع ناشناخته تولید نمی‌کند. برنامه‌ای که این شناسه را می‌فهمد باید معنای آن را فراهم کرده و مقدار را به‌روزرسانی کند.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/ShapeType.h>
#include <DOM/ITextFrame.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IField.h>
#include <DOM/IFieldType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto shape = presentation->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40, 40, 300, 50);
shape->AddTextFrame(u"Report-042");
auto portion = shape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
portion->AddField(u"custom-report-id");
presentation->Save(u"custom_field.pptx", SaveFormat::Pptx);
presentation->Dispose();

auto reopened = System::MakeObject<Presentation>(u"custom_field.pptx");
auto savedShape = System::ExplicitCast<IAutoShape>(reopened->get_Slide(0)->get_Shape(0));
auto savedPortion = savedShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
auto field = savedPortion->get_Field();
auto typeName = field != nullptr ? field->get_Type()->get_InternalString() : u"ordinary text";
System::Console::WriteLine(u"Type: {0}", typeName);
System::Console::WriteLine(u"Text: {0}", savedPortion->get_Text());
reopened->Dispose();
```

پس از این بازگشت PPTX، نوع مورد انتظار `custom-report-id` و متن مورد انتظار `Report-042` است. ارسال رشته‌ای مانند `yyyy-MM-dd` یک نوع فیلد را نام‌گذاری می‌کند؛ قالب تاریخ سفارشی پیکربندی نمی‌کند. برای تاریخ ثابت با قالب دلخواه، از متن معمولی استفاده کنید.

## **بازرسی، تغییر و حذف فیلدهای تاریخ/زمان**

نوع فیلد موجود را از طریق [IField::get_Type](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ifield/get_type/) بخوانید و از طریق [IField::set_Type](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ifield/set_type/) تغییر دهید. قبل از دسترسی به نوع، وجود فیلد را بررسی کنید. برای متوقف کردن به‌روزرسانی خودکار، [IPortion::RemoveField](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iportion/removefield/) را صدا بزنید. این عمل قسمت و متن فعلی آن را نگه می‌دارد و فقط ارتباط فیلد را حذف می‌کند. اگر به مقدار ثابت خاصی نیاز دارید، پس از حذف فیلد آن متن را اختصاص دهید.

برای تنظیمات API مرتبط با پردازش فیلدهای تاریخ/زمان، به [Presentation::set_CurrentDateTime](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/set_currentdatetime/) مراجعه کنید. مثال زیر از تاریخ تصویب صریح هنگام تبدیل فیلد به متن معمولی استفاده می‌کند.

فایل [sample.pptx](sample.pptx) را دانلود کرده و در پوشهٔ کاری قرار دهید. این فایل دو شکل متنی نام‌دار `UpdatedAt` و `ApprovedDate` دارد که هر کدام دارای فیلد تاریخ/زمان هستند، به‌علاوه برچسب‌های متن معمولی. مثال زیر شکل‌های متنی سطح بالای اسلایدهای عادی را پیمایش می‌کند. فیلدهای تاریخ/زمان را به قالب تاریخ طولانی تبدیل می‌کند و ایتالیک می‌سازد، در حالی که قالب‌بندی‌های دیگر را حفظ می‌کند. تنها فیلدهای `ApprovedDate` به متن ثابت تبدیل می‌شوند.

شناسه‌های داخلی از پیش ساختهٔ `datetime` تا `datetime13` شناخته می‌شوند. گروه‌ها، جدول‌ها، یادداشت‌ها، طرح‌ها و مسترها نیاز به پیمایش کانتینرهای متن خود دارند و خارج از دامنهٔ این مثال هستند.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/ITextFrame.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/NullableBool.h>
#include <DOM/IField.h>
#include <DOM/IFieldType.h>
#include <DOM/FieldType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/date_time.h>
#include <system/globalization/culture_info.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto approvalDate = System::DateTime(2030, 4, 5);
auto culture = System::Globalization::CultureInfo::GetCultureInfo(u"en-US");

for (auto slide : presentation->get_Slides())
{
    for (auto shape : slide->get_Shapes())
    {
        auto textShape = System::DynamicCast<IAutoShape>(shape);
        if (textShape == nullptr || textShape->get_TextFrame() == nullptr)
            continue;

        for (auto paragraph : textShape->get_TextFrame()->get_Paragraphs())
        {
            for (auto portion : paragraph->get_Portions())
            {
                auto field = portion->get_Field();
                if (field == nullptr)
                    continue;

                auto typeName = field->get_Type()->get_InternalString();
                auto isDateTime = typeName == u"datetime";
                for (auto formatNumber = 1; formatNumber <= 13; ++formatNumber)
                {
                    auto identifier = System::String::Format(u"datetime{0}", formatNumber);
                    isDateTime |= typeName == identifier;
                }
                if (!isDateTime)
                    continue;

                field->set_Type(FieldType::get_DateTime3());
                portion->get_PortionFormat()->set_LanguageId(u"en-US");
                portion->get_PortionFormat()->set_FontItalic(NullableBool::True);

                if (textShape->get_Name() == u"ApprovedDate")
                {
                    portion->RemoveField();
                    auto fixedDate = approvalDate.ToString(u"dd MMMM yyyy", culture);
                    portion->set_Text(fixedDate);
                }
            }
        }
    }
}

presentation->Save(u"updated_dates.pptx", SaveFormat::Pptx);
presentation->Dispose();

auto reopened = System::MakeObject<Presentation>(u"updated_dates.pptx");
for (auto shape : reopened->get_Slide(0)->get_Shapes())
{
    auto textShape = System::DynamicCast<IAutoShape>(shape);
    if (textShape == nullptr || textShape->get_TextFrame() == nullptr)
        continue;
    if (textShape->get_Name() != u"UpdatedAt" && textShape->get_Name() != u"ApprovedDate")
        continue;

    auto portion = textShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
    auto field = portion->get_Field();
    auto typeName = field != nullptr ? field->get_Type()->get_InternalString() : u"ordinary text";
    System::Console::WriteLine(u"{0}: {1}; {2}", textShape->get_Name(), typeName, portion->get_Text());
    auto isItalic = portion->get_PortionFormat()->get_FontItalic() == NullableBool::True;
    System::Console::WriteLine(u"Italic: {0}", isItalic);
}
reopened->Dispose();
```

پس از باز کردن دوباره، `UpdatedAt` باید نوع `datetime3` داشته باشد و پویا بماند. `ApprovedDate` نباید فیلدی داشته باشد و باید متن `05 April 2030` را شامل شود. هر دو قسمت تاریخ ایتالیک هستند و اندازهٔ فونت اصلی، حالت بولد و رنگ آنها دست نخورده می‌ماند. برچسب‌های متن معمولی تغییر نمی‌کنند. اعتبارسنجی اولین قسمت از دو شکل شناخته‌شده در نمونهٔ ارائه‌شده را می‌خواند.

## **حفظ قالب‌بندی متن**

هنگام افزودن فیلد، تغییر نوع آن یا حذف، با قسمت موجود کار کنید. این عملیات قالب‌بندی آن قسمت را حفظ می‌کند. از [IPortion::get_PortionFormat](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iportion/get_portionformat/) برای تغییر فقط ویژگی‌های مورد نیاز استفاده کنید، همان‌طور که مثال‌ها برای رنگ یا ایتالیک انجام می‌دهند.

از بازسازی کامل یک فریم متن فقط برای به‌روزرسانی یک فیلد خودداری کنید: این کار می‌تواند مرزهای قسمت‌های اصلی و قالب‌بندی‌های منفرد آنها را از دست بدهد. همچنین قالب‌بندی صریح تنظیم‌شده را از قالب‌بندی به‌دست‌آمده از پاراگراف، طرح یا تم متمایز کنید. برای گزینه‌های گسترده‌تر قالب‌بندی به [Text Formatting](/slides/fa/cpp/text-formatting/) مراجعه کنید.

## **فیلدها و جایگزین‌کننده‌های سرصفحه/پاورقی**

فیلد بخشی از یک قسمت متن است. یک جایگزین‌کننده، شکلی با نقش ارائه مانند پاورقی یا شماره اسلاید است. افزودن فیلد به یک کادر متن معمولی، آن شکل را به جایگزین‌کننده تبدیل نمی‌کند.

مدیران سرصفحه/پاورقی متن جایگزین‌کننده و نمایش آن را در اسلایدها، طرح‌ها و مسترها کنترل می‌کنند، از جمله انتشار به اسلایدهای وابسته. بنابراین یک فیلد عددی در یک کادر متن سفارشی حتی وقتی از جایگزین‌کنندهٔ شماره اسلاید استفاده نمی‌کنید، می‌تواند مفید باشد. برعکس، تغییر نمایش جایگزین‌کننده فیلدی را از کادر متنی نامرتبط حذف نمی‌کند.

انواع پیش‌تعریف‌شدهٔ سرصفحه و پاورقی، جایگزین‌کننده‌های مربوطه را ایجاد یا محتوای آنها را فراهم نمی‌کنند. به‌ویژه، یک اسلاید PowerPoint معمولی جایگزین‌کنندهٔ سرصفحه ندارد؛ سرصفحه‌ها متعلق به صفحات یادداشت و برگردان‌ها هستند. فرض نکنید فیلد سرصفحه یا پاورقی در یک شکل دلخواه به‌طور خودکار متن پیکربندی‌شده از طریق مدیر جایگزین‌کننده را دریافت می‌کند. برای این کار جریان کاری را در [Presentation Headers and Footers](/slides/fa/cpp/presentation-header-and-footer/) ببینید.

## **محدودیت‌های PPTX و PPT**

پس از ذخیره و باز کردن دوباره، هم نوع فیلد و هم متن حاصل آن را بررسی کنید. حفظ شناسه ثابت نمی‌کند که برنامه می‌تواند مقدار را محاسبه یا نمایش دهد.

| قالب | رفتار فیلد و محدودیت‌ها |
|---|---|
| PPTX | شناسه‌های فیلد داخلی را همراه با متن فیلد ذخیره می‌کند. برای بررسی انواع پیش‌تعریف‌شده و شناسه‌های سفارشی پس از ذخیره و باز کردن، از مثال‌های بالا استفاده کنید. یک نوع سفارشی ناشناخته منطق محاسبه خودکار دریافت نمی‌کند. برنامهٔ دیگر ممکن است شناسه‌های پشتیبانی‌نشده را به‌صورت متفاوتی رفتار کند. |
| PPT | از نمایش‌های قدیمی فیلد استفاده می‌کند و سازگاری محدودتری دارد. فیلدهای شماره اسلاید و تاریخ/زمان پیش‌تعریف‌شده دارای نمایش‌های قدیمی هستند. فیلدهای سفارشی یا فیلدهای سرصفحه در یک کادر متن معمولی می‌توانند متن `*` تولید کنند. به متن قابل نمایش فیلدهای سفارشی یا زمینه‌های پشتیبانی‌نشده اطمینان نداشته باشید. |

برای خروجی ثابت و قابل‌حمل، فیلدهای پشتیبانی‌نشده را به متن عادی تبدیل کنید و مقدار موردنظر را به‌صورت صریح قبل از ذخیره اختصاص دهید. این کار متن انتخابی را حفظ می‌کند ولی به‌روزرسانی خودکار را متوقف می‌سازد. همچنین برنامه هدف را تست کنید وقتی بازمحاسبهٔ فیلد بخشی از جریان کاری شماست.

## **سوالات متداول**

**چگونه می‌توانم تشخیص دهم که عدد یا تاریخ نمایش داده‌شده یک فیلد است؟**

[IPortion::get_Field](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iportion/get_field/) را بررسی کنید. مقدار غیر‑null نشان‌دهنده فیلد است؛ متن نمایش داده‌شده به تنهایی نمی‌تواند تشخیص دهد.

**آیا حذف فیلد متن یا قالب‌بندی آن را حذف می‌کند؟**

خیر. [RemoveField](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iportion/removefield/) قسمت موجود را به متن عادی تبدیل می‌کند. اگر به مقدار خاصی نیاز دارید، پس از آن مقدار صریح را اختصاص دهید.

**آیا یک رشته داخلی می‌تواند قالب تاریخ یا فرمول جدیدی تعریف کند؟**

خیر. این رشته فقط نوع فیلد را شناسایی می‌کند. یک شناسه ناشناخته ارزیاب یا الگوی قالب تاریخ ارائه نمی‌دهد. از یک نوع پیش‌تعریف‌شدهٔ پشتیبانی‌شده استفاده کنید یا مقدار را به‌عنوان متن معمولی قالب‌بندی کنید.

**چرا پس از ذخیره‌سازی باید ارائه را دوباره بررسی کرد؟**

شناسه فیلد، متن محاسبه‌شده و قالب‌بندی مواردی جداگانه برای تأیید هستند. تبدیل قالب می‌تواند نتیجهٔ قابل مشاهده را تغییر دهد حتی وقتی شناسه فیلد هنوز موجود است.