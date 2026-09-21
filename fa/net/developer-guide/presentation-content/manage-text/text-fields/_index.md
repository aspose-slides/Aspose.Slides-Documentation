---
title: مدیریت فیلدهای متنی در ارائه‌های پاورپوینت با .NET
linktitle: فیلدهای متن
type: docs
weight: 52
url: /fa/net/text-fields/
keywords:
- فیلد متنی
- متن خودکار
- شماره اسلاید
- تاریخ و زمان
- سرصفحه
- پاورقی
- بخش متنی
- پاورپوینت
- PPT
- PPTX
- C#
- Aspose.Slides
description: "ایجاد، بازرسی، تغییر و حذف فیلدهای متنی در ارائه‌های پاورپوینت با Aspose.Slides برای .NET. حفظ قالب‌بندی و تأیید فایل‌های ذخیره‌شده PPTX و PPT."
---
## **نمای کلی**

یک پاراگراف متنی شامل بخش‌هایی است. یک [IPortion](https://reference.aspose.com/slides/fa/net/aspose.slides/iportion/) معمولی شامل متن اصلی است؛ یک بخش فیلد همچنین دارای یک [IField](https://reference.aspose.com/slides/fa/net/aspose.slides/ifield/) است که نوع آن یک مقدار به‌صورت خودکار به‌روز شده را شناسایی می‌کند، مانند شماره اسلاید یا تاریخ. دو بخش می‌توانند همان کاراکترها را نمایش دهند در حالی که فقط یکی شامل فیلد است.

از [IPortion.Field](https://reference.aspose.com/slides/fa/net/aspose.slides/iportion/field/) برای تشخیص آنها استفاده کنید: برای متن معمولی مقدار `null` است. [IPortion.AddField](https://reference.aspose.com/slides/fa/net/aspose.slides/iportion/addfield/) یک بخش موجود را به فیلد تبدیل می‌کند. برچسب و مقدار پویا را در بخش‌های جداگانه نگه دارید تا تبدیل مقدار باعث جایگزینی برچسب نشود.

این راهنما فیلدها را در داخل متن، قالب‌بندی آن‌ها و ذخیره‌سازی در PPTX و PPT پوشش می‌دهد. برای فریم‌های متنی و پاراگراف‌ها، به [Manage Text](/slides/fa/net/manage-text/) مراجعه کنید.

## **ایجاد فیلد شماره اسلاید**

مثال کامل زیر یک جعبه متن حاوی برچسب متنی `Slide ` به‌همراه یک شماره که به‌صورت خودکار به‌روز می‌شود، ایجاد می‌کند. قبل از اضافه کردن فیلد، اندازه، وزن و رنگ عدد را تنظیم می‌کند، سپس ارائه ذخیره‌شده را دوباره باز می‌کند و نوع فیلد، متن و قالب‌بندی را بررسی می‌کند. فایل ورودی نیازی نیست.

```cs
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 240, 50);
shape.AddTextFrame("Slide ");
var paragraph = shape.TextFrame.Paragraphs[0];

var numberPortion = new Portion();
numberPortion.PortionFormat.FontHeight = 24;
numberPortion.PortionFormat.FontBold = NullableBool.True;
numberPortion.PortionFormat.FillFormat.FillType = FillType.Solid;
numberPortion.PortionFormat.FillFormat.SolidFillColor.Color = Color.DarkBlue;
paragraph.Portions.Add(numberPortion);
numberPortion.AddField(FieldType.SlideNumber);

presentation.Save("slide_number.pptx", SaveFormat.Pptx);

using var reopened = new Presentation("slide_number.pptx");
var savedShape = (IAutoShape)reopened.Slides[0].Shapes[0];
var savedNumber = savedShape.TextFrame.Paragraphs[0].Portions[1];
var hasNumberField = savedNumber.Field?.Type.InternalString == FieldType.SlideNumber.InternalString;
var format = savedNumber.PortionFormat;
var formattingPreserved = format.FontHeight == 24 && format.FontBold == NullableBool.True;
formattingPreserved &= format.FillFormat.SolidFillColor.Color.ToArgb() == Color.DarkBlue.ToArgb();

Console.WriteLine($"Text: {savedShape.TextFrame.Text}");
Console.WriteLine($"Slide number field: {hasNumberField}");
Console.WriteLine($"Formatting preserved: {formattingPreserved}");
```

ارائه جدید با شماره اسلاید 1 شروع می‌شود، بنابراین متن `Slide 1` است و هر دو بررسی مقدار `True` را چاپ می‌کنند. عدد پس از بازگشایی همچنان یک فیلد باقی می‌ماند؛ این یک `1` متنی نیست. تبدیل‌ها و ایندکس‌های موجود در تأیید به شکل و بخش‌های ایجادشده توسط این مثال اشاره دارند.

## **انتخاب نوع فیلد**

[FieldType](https://reference.aspose.com/slides/fa/net/aspose.slides/fieldtype/) پیاده‌سازی [IFieldType](https://reference.aspose.com/slides/fa/net/aspose.slides/ifieldtype/) است و مقادیر پیش‌تعریف‌شده زیر را ارائه می‌دهد. مقدار مناسب را به [AddField](https://reference.aspose.com/slides/fa/net/aspose.slides/iportion/addfield/) بدهید.

| مقدار | هدف |
|---|---|
| [SlideNumber](https://reference.aspose.com/slides/fa/net/aspose.slides/fieldtype/slidenumber/) | شماره اسلاید فعلی. |
| [DateTime](https://reference.aspose.com/slides/fa/net/aspose.slides/fieldtype/datetime/) | تاریخ/زمان به فرمت پیش‌فرض برنامه‌ی رندر کننده. |
| [DateTime1](https://reference.aspose.com/slides/fa/net/aspose.slides/fieldtype/datetime1/)–[DateTime9](https://reference.aspose.com/slides/fa/net/aspose.slides/fieldtype/datetime9/) | فرمت‌های پیش‌تعریف‌شده تاریخ یا ترکیب تاریخ/زمان. |
| [DateTime10](https://reference.aspose.com/slides/fa/net/aspose.slides/fieldtype/datetime10/)–[DateTime13](https://reference.aspose.com/slides/fa/net/aspose.slides/fieldtype/datetime13/) | فرمت‌های پیش‌تعریف‌شده زمان، با گزینه‌های ثانیه و ساعت 12 ساعته. |
| [Header](https://reference.aspose.com/slides/fa/net/aspose.slides/fieldtype/header/) | فیلد سرصفحه؛ به محدودیت‌های جای‌دار و قالب زیر مراجعه کنید. |
| [Footer](https://reference.aspose.com/slides/fa/net/aspose.slides/fieldtype/footer/) | فیلد پاورقی. |

به عنوان مثال، [DateTime3](https://reference.aspose.com/slides/fa/net/aspose.slides/fieldtype/datetime3/) روز، نام کامل ماه و سال را به زبان انگلیسی نشان می‌دهد. این‌ها فرمت‌های فیلد پیش‌تعریف‌شده‌اند، نه رشته‌های فرمت‌ تاریخ دلخواه .NET. [LanguageId](https://reference.aspose.com/slides/fa/net/aspose.slides/ibaseportionformat/languageid/) بخش و برنامه‌ای که ارائه را پردازش می‌کند می‌توانند نتیجهٔ نمایش داده‌شده را تحت تأثیر قرار دهند.

## **ایجاد فیلد از یک رشته داخلی**

بارگذاری رشته‌ای [AddField](https://reference.aspose.com/slides/fa/net/aspose.slides/iportion/addfield/) یک شناسه فیلد داخلی می‌پذیرد. وقتی می‌خواهید شناسه‌ای را که برنامهٔ دیگری فراهم کرده حفظ کنید و مقدار پیش‌تعریف‌شده‌ای برای آن وجود ندارد، از این روش استفاده کنید. همچنین می‌توانید یک [FieldType](https://reference.aspose.com/slides/fa/net/aspose.slides/fieldtype/fieldtype/) از این شناسه بسازید. [IFieldType.InternalString](https://reference.aspose.com/slides/fa/net/aspose.slides/ifieldtype/internalstring/) آن شناسه را برای بازرسی در دسترس می‌گذارد.

این مثال یک فیلد `custom-report-id` خاص برنامه را با متن جایگزین `Report-042` ذخیره می‌کند. شناسه محاسبه‌ای را ثبت نمی‌کند: Aspose.Slides شناسه‌های گزارش برای نوع ناشناخته تولید نمی‌کند. برنامه‌ای که این شناسه را می‌فهمد باید معنی آن را فراهم کرده و مقدارش را به‌روزرسانی کند.

```cs
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 300, 50);
shape.AddTextFrame("Report-042");
var portion = shape.TextFrame.Paragraphs[0].Portions[0];
portion.AddField("custom-report-id");

presentation.Save("custom_field.pptx", SaveFormat.Pptx);

using var reopened = new Presentation("custom_field.pptx");
var savedShape = (IAutoShape)reopened.Slides[0].Shapes[0];
var savedPortion = savedShape.TextFrame.Paragraphs[0].Portions[0];
Console.WriteLine($"Type: {savedPortion.Field?.Type.InternalString}");
Console.WriteLine($"Text: {savedPortion.Text}");
```

پس از این دور سفر PPTX، نوع `custom-report-id` و متن `Report-042` باقی می‌مانند. ارسال رشته‌ای مانند `yyyy-MM-dd` یک نوع فیلد را نام‌گذاری می‌کند؛ آن یک قالب تاریخ سفارشی پیکربندی نمی‌کند. برای تاریخ ثابت در قالب دلخواه، از متن معمولی استفاده کنید.

## **بازرسی، تغییر و حذف فیلدهای تاریخ/زمان**

یک فیلد موجود را از طریق [IField.Type](https://reference.aspose.com/slides/fa/net/aspose.slides/ifield/type/) بخوانید و تغییر دهید. قبل از دسترسی به نوع فیلد، وجود آن را بررسی کنید. برای متوقف کردن به‑روزرسانی‌های خودکار، [IPortion.RemoveField](https://reference.aspose.com/slides/fa/net/aspose.slides/iportion/removefield/) را فراخوانی کنید. این کار بخش و متن فعلی آن را حفظ می‌کند در حالی که ارتباط فیلد را حذف می‌نماید. اگر به مقدار ثابت خاصی نیاز دارید، پس از حذف فیلد آن متن را اختصاص دهید.

برای تنظیمات API مرتبط با پردازش فیلد تاریخ/زمان، به [Presentation.CurrentDateTime](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/currentdatetime/) مراجعه کنید. مثال زیر از یک تاریخ تأیید صریح هنگام تبدیل فیلد به متن معمولی استفاده می‌کند.

فایل [sample.pptx](sample.pptx) را دانلود کنید و در پوشهٔ کاری قرار دهید. این فایل دو شکل متن‌دار نام‌دار `UpdatedAt` و `ApprovedDate` دارد که هر کدام فیلد تاریخ/زمان دارند، به‌اضافه برچسب‌های متن معمولی. مثال زیر به شکل‌های متنی سطح‑بالا در اسلایدهای عادی می‌پردازد. فیلدهای تاریخ/زمان را به قالب تاریخ طولانی تبدیل می‌کند و ایتالیک می‌سازد، در حالی که قالب‌بندی‌های دیگرشان حفظ می‌شود. فقط فیلدهای موجود در `ApprovedDate` به متن ثابت تبدیل می‌شوند.

شناسه‌های داخلی پیش‌ساخته `datetime` و `datetime1` تا `datetime13` شناسایی می‌شوند. گروه‌ها، جداول، یادداشت‌ها، چیدمان‌ها و مستندات اصلی نیاز به پیمایش کانتینرهای متنی خود دارند و در محدودهٔ این مثال نیستند.

```cs
using System;
using System.Globalization;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var approvalDate = new DateTime(2030, 4, 5);
var culture = CultureInfo.GetCultureInfo("en-US");

foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
    {
        if (shape is not IAutoShape textShape || textShape.TextFrame == null)
            continue;

        foreach (var paragraph in textShape.TextFrame.Paragraphs)
        {
            foreach (var portion in paragraph.Portions)
            {
                var field = portion.Field;
                if (field == null)
                    continue;

                var typeName = field.Type.InternalString;
                var isDateTime = typeName == "datetime";
                if (typeName.StartsWith("datetime", StringComparison.Ordinal))
                {
                    var hasFormatNumber = int.TryParse(typeName.Substring(8), out var formatNumber);
                    isDateTime |= hasFormatNumber && formatNumber >= 1 && formatNumber <= 13;
                }
                if (!isDateTime)
                    continue;

                field.Type = FieldType.DateTime3;
                portion.PortionFormat.LanguageId = "en-US";
                portion.PortionFormat.FontItalic = NullableBool.True;

                if (textShape.Name == "ApprovedDate")
                {
                    portion.RemoveField();
                    portion.Text = approvalDate.ToString("dd MMMM yyyy", culture);
                }
            }
        }
    }
}

presentation.Save("updated_dates.pptx", SaveFormat.Pptx);

using var reopened = new Presentation("updated_dates.pptx");
foreach (var shape in reopened.Slides[0].Shapes)
{
    if (shape is not IAutoShape textShape || textShape.TextFrame == null)
        continue;
    if (textShape.Name != "UpdatedAt" && textShape.Name != "ApprovedDate")
        continue;

    var portion = textShape.TextFrame.Paragraphs[0].Portions[0];
    var typeName = portion.Field?.Type.InternalString ?? "ordinary text";
    Console.WriteLine($"{textShape.Name}: {typeName}; {portion.Text}");
    Console.WriteLine($"Italic: {portion.PortionFormat.FontItalic}");
}
```

پس از بازگشایی، `UpdatedAt` نوع `datetime3` دارد و پویا می‌ماند. `ApprovedDate` فیلدی ندارد و شامل `05 April 2030` است. هر دو بخش تاریخ ایتالیک هستند و اندازهٔ قلم اصلی، تنظیم بولد و رنگ آنها دست‌نخورده می‌ماند. برچسب‌های متن معمولی تغییر نمی‌کنند. تأییدیهٔ اولین بخش دو شکل شناخته‌شده در نمونهٔ ارائه‌شده را می‌خواند.

## **حفظ قالب‌بندی متن**

هنگام افزودن فیلد، تغییر نوع آن یا حذف، با بخش موجود کار کنید. این عملیات قالب‌بندی آن بخش را حفظ می‌کند. برای تغییر تنها ویژگی‌های مورد نیاز از [IPortion.PortionFormat](https://reference.aspose.com/slides/fa/net/aspose.slides/iportion/portionformat/) استفاده کنید، همان‌طور که مثال‌ها برای رنگ یا ایتالیک انجام می‌دهند.

از بازسازی کل فریم متن فقط برای به‌روزرسانی یک فیلد خودداری کنید؛ این کار می‌تواند مرزهای بخش‌های اصلی و قالب‌بندی‌های فردی آنها را از دست بدهد. همچنین قالب‌بندی تنظیم‌شده به‌صورت صریح را از قالب‌بندی ارث‌برده از پاراگراف، چیدمان یا تم متمایز کنید. برای گزینه‌های گسترده‌تر قالب‌بندی به [Text Formatting](/slides/fa/net/text-formatting/) مراجعه کنید.

## **فیلدها و جای‌دارهای سرصفحه/پاورقی**

یک فیلد بخشی از یک بخش متنی است. یک جای‌دار شکل با نقش ارائه‌ای است، مانند پاورقی یا شماره اسلاید. افزودن فیلد به یک جعبه متن معمولی، آن شکل را به جای‌دار تبدیل نمی‌کند.

مدیران سرصفحه/پاورقی متن جای‌دار و قابلیت مشاهده را در اسلایدها، چیدمان‌ها و مستندات اصلی کنترل می‌کنند، از جمله انتشار به اسلایدهای وابسته. بنابراین یک فیلد شماره در یک جعبه متن سفارشی می‌تواند حتی زمانی که از جای‌دار شماره اسلاید استفاده نمی‌کنید، مفید باشد. بالعکس، تغییر قابلیت مشاهدهٔ جای‌دار فیلدی را از یک جعبه متن نامرتبط حذف نمی‌کند.

انواع پیش‌تعریف‌شده سرصفحه و پاورقی، جای‌دارهای متناظر را ایجاد یا محتوای آنها را فراهم نمی‌کنند. به‌ویژه، یک اسلاید عادی PowerPoint جای‌دار سرصفحه‌ای ندارد؛ سرصفحه‌ها به صفحات یادداشت و جزوه‌ها تعلق دارند. فرض نکنید فیلد سرصفحه یا پاورقی در یک شکل دلخواه به‌صورت خودکار متنی که از طریق مدیر جای‌دار تنظیم شده است، دریافت می‌کند. برای این جریان کاری، به [Presentation Headers and Footers](/slides/fa/net/presentation-header-and-footer/) مراجعه کنید.

## **محدودیت‌های PPTX و PPT**

بعد از ذخیره و بازگشایی، هم نوع فیلد و هم متن حاصل را بررسی کنید. حفظ یک شناسه اثبات نمی‌کند برنامه می‌تواند مقدار آن را محاسبه یا نمایش دهد.

| قالب | رفتار فیلد و محدودیت‌ها |
|---|---|
| PPTX | شناسه‌های فیلد داخلی را همراه با متن فیلد ذخیره می‌کند. در بررسی‌های دور‑دور، انواع پیش‌تعریف‌شده و شناسهٔ سفارشی استفاده‌شده در مثال بالا پس از ذخیره و بازگشایی باقی مانده‌اند. نوع سفارشی ناشناخته متن جایگزین خود را نگه داشته؛ منطق محاسبه خودکار به‌دست نیامده است. برنامهٔ دیگری ممکن است شناسه‌های پشتیبانی‌نشده را به‌صورت متفاوتی پردازش کند. |
| PPT | از نمایش‌های قدیمی فیلد استفاده می‌کند و سازگاری محدودی دارد. در بررسی‌های دور‑دور، فیلدهای شماره اسلاید و تاریخ/زمان پیش‌تعریف‌شده پس از ذخیره و بازگشایی حفظ شده‌اند. یک فیلد سفارشی در جعبه متن اسلاید عادی پس از بازگشایی شناسه خود را داشته اما متن `*` دارد؛ فیلد سرصفحه در همان زمینه نیز `*` تولید می‌کند. به متن قابل مشاهدهٔ فیلدهای سفارشی یا زمینه‌های پشتیبانی‌نشده اعتماد نکنید. |

برای خروجی ثابت و قابل حمل، فیلدهای پشتیبانی‌نشده را به متن معمولی تبدیل کنید و مقدار موردنظرتان را قبل از ذخیره به‌صورت صریح اختصاص دهید. این کار متن انتخابی را حفظ می‌کند اما به‌روزرسانی خودکار را عمداً متوقف می‌کند. همچنین برنامه هدف را هنگام استفاده از بازنگری فیلد خود آزمایش کنید.

## **سوالات متداول**

**چگونه می‌توانم تشخیص دهم که عدد یا تاریخ نمایش داده‌شده یک فیلد است؟**

[IPortion.Field](https://reference.aspose.com/slides/fa/net/aspose.slides/iportion/field/) را بررسی کنید. مقدار غیر‑null نشان‌دهنده فیلد است؛ متن نمایش‌داده‌شده به‌تنهایی نمی‌تواند این را نشان دهد.

**آیا حذف فیلد، متن یا قالب‌بندی آن را حذف می‌کند؟**

خیر. [RemoveField](https://reference.aspose.com/slides/fa/net/aspose.slides/iportion/removefield/) بخش موجود را به متن عادی تبدیل می‌کند. اگر به مقدار ثابت خاصی نیاز دارید، پس از حذف فیلد مقدار صریح را اختصاص دهید.

**آیا یک رشته داخلی می‌تواند قالب تاریخ یا فرمول جدیدی تعریف کند؟**

خیر. این رشته فقط نوع فیلد را شناسایی می‌کند. یک شناسهٔ ناشناخته ارزیاب یا الگوی فرمت تاریخ .NET ارائه نمی‌دهد. از یک نوع پیش‌تعریف‌شده پشتیبانی‌شده استفاده کنید یا مقدار را به‌صورت متن معمولی قالب‌بندی کنید.

**چرا پس از ذخیره‌سازی باید ارائه را دوباره بررسی کنیم؟**

شناسه‌های فیلد، متن محاسبه‌شده و قالب‌بندی موارد جداگانه‌ای برای تأیید هستند. تبدیل قالب می‌تواند نتیجهٔ قابل مشاهده را تغییر دهد حتی وقتی شناسهٔ فیلد هنوز موجود است.