---
title: راه حل عملی برای تغییر اندازه نمودار در PPTX
type: docs
weight: 60
url: /fa/cpp/working-solution-for-chart-resizing-in-pptx/
keywords:
- تغییر اندازه نمودار
- نمودار Excel
- شیء OLE
- جاسازی نمودار
- PowerPoint
- OpenDocument
- ارائه
- C++
- Aspose.Slides
description: "رفع تغییر اندازه ناخواستهٔ نمودار در PPTX هنگام استفاده از اشیاء OLE Excel جاسازی‌شده با Aspose.Slides for C++. دو روش با کد برای حفظ سایزهای سازگار را بیاموزید."
---
## **پس‌زمینه**

در مشاهده‌ها مشخص شده است که نمودارهای Excel که به عنوان اشیاء OLE در یک ارائه PowerPoint از طریق اجزای Aspose جاسازی می‌شوند، پس از اولین فعال‌سازی به مقیاسی نامشخص تغییر اندازه می‌دهند. این رفتار باعث ایجاد تفاوت بصری مشهودی بین حالت قبل و بعد از فعال‌سازی نمودار در ارائه می‌شود. تیم Aspose این مشکل را به‌تفصیل بررسی کرده و راه‌حلی پیدا کرده است. این مقاله علل مشکل و اصلاح مربوطه را شرح می‌دهد.

در [مقالهٔ قبلی](/slides/fa/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)، ما نحوهٔ ایجاد یک نمودار Excel با Aspose.Cells for C++ و جاسازی آن در یک ارائه PowerPoint با استفاده از Aspose.Slides for C++ را توضیح دادیم. برای رفع [مشکل پیش‌نمایش شیء](/slides/fa/cpp/object-preview-issue-when-adding-oleobjectframe/)، تصویر نمودار را به قاب شیء OLE اختصاص دادیم. در ارائه خروجی، وقتی روی قاب شیء OLE که تصویر نمودار را نشان می‌دهد دوبار کلیک می‌کنید، نمودار Excel فعال می‌شود. کاربران نهایی می‌توانند تغییرات دلخواه خود را در کتاب‌کار Excel زیرین اعمال کرده و سپس با کلیک کردن خارج از کتاب‌کار فعال شده به اسلاید مربوطه بازگردند. هنگام بازگشت کاربر به اسلاید، اندازهٔ قاب شیء OLE تغییر می‌کند و ضریب تغییر اندازه بسته به اندازهٔ اولیهٔ هر دو قاب شیء OLE و کتاب‌کار Excel جاسازی‌شده متفاوت است.

## **دلیل تغییر اندازه**

به دلیل این‌که کتاب‌کار Excel اندازهٔ پنجرهٔ مخصوص به خود را دارد، سعی می‌کند اندازهٔ اصلی خود را در اولین فعال‌سازی حفظ کند. اما قاب شیء OLE اندازهٔ خاص خود را دارد. بر اساس گفته مایکروسافت، هنگامی که کتاب‌کار Excel فعال می‌شود، Excel و PowerPoint اندازه را مذاکره می‌کنند و نسبت‌های صحیح را به‌عنوان بخشی از فرایند جاسازی نگه می‌دارند. بسته به تفاوت بین اندازهٔ پنجرهٔ Excel و اندازه یا موقعیت قاب شیء OLE، تغییر اندازه رخ می‌دهد.

## **راه‌حل عملی**

دو سناریوی ممکن برای ایجاد ارائه‌های PowerPoint با Aspose.Slides for C++ وجود دارد.

**سناریو 1:** ایجاد ارائه بر پایهٔ یک قالب موجود.

**سناریو 2:** ایجاد ارائه از ابتدا.

راه‌حلی که در اینجا ارائه می‌کنیم برای هر دو سناریو اعمال می‌شود. پایهٔ تمام روش‌های حل همان است: **اندازهٔ پنجرهٔ شیء OLE جاسازی‌شده باید با قاب شیء OLE در اسلاید PowerPoint تطابق داشته باشد**. اکنون دو رویکرد به این حل را بررسی می‌کنیم.

## **رویکرد اول**

در این رویکرد، می‌آموزیم چگونه اندازهٔ پنجرهٔ کتاب‌کار Excel جاسازی‌شده را تنظیم کنیم تا با اندازهٔ قاب شیء OLE در اسلاید PowerPoint منطبق شود.

**سناریو 1**

فرض کنید یک قالب تعریف کرده‌ایم و می‌خواهیم ارائه‌هایی بر پایهٔ آن ایجاد کنیم. فرض کنید در قالب یک Shape‌ با ایندکس 2 وجود دارد که می‌خواهیم یک قاب OLE حاوی کتاب‌کار Excel جاسازی‌شده در آن قرار دهیم. در این سناریو، اندازهٔ قاب شیء OLE از پیش تعریف شده است—که با اندازهٔ Shape‌ با ایندکس 2 در قالب منطبق است. تنها کاری که باید انجام دهیم این است که اندازهٔ پنجرهٔ کتاب‌کار را برابر با اندازهٔ آن Shape تنظیم کنیم. قطعه کد زیر این منظور را انجام می‌دهد:

```cpp
System::SharedPtr<System::IO::MemoryStream> ToSlidesMemoryStream(intrusive_ptr<Aspose::Cells::Systems::IO::MemoryStream> inputStream)
{
    auto outputBuffer = System::MakeArray<uint8_t>(inputStream->GetLength(), inputStream->GetBuffer()->ArrayPoint());
    auto outputStream = System::MakeObject<System::IO::MemoryStream>(outputBuffer);

    return outputStream;
}
```

```cpp
// اندازه نمودار را با یک پنجره تعریف کنید.
chart->SetSizeWithWindow(true);

auto shape = slide->get_Shape(2);

// عرض پنجره کتاب‌کار را به اینچ تنظیم کنید (به‌وسیله ۷۲ تقسیم می‌شود زیرا PowerPoint از ۷۲ پیکسل در هر اینچ استفاده می‌کند).
workbook->GetISettings()->SetWindowWidthInch(shape->get_Width() / 72.f);

// ارتفاع پنجره کتاب‌کار را به اینچ تنظیم کنید.
workbook->GetISettings()->SetWindowHeightInch(shape->get_Height() / 72.f);

// کتاب‌کار را به یک حافظه موقت ذخیره کنید.
System::SharedPtr<System::IO::MemoryStream> workbookStream = ToSlidesMemoryStream3(workbook->SaveToStream());

System::SharedPtr<IOleEmbeddedDataInfo> dataInfo = System::MakeObject<OleEmbeddedDataInfo>(workbookStream->ToArray(), u"xls");

// یک قاب شیء OLE با داده‌های Excel جاسازی‌شده ایجاد کنید.
System::SharedPtr<IOleObjectFrame> oleFrame = slide->get_Shapes()->AddOleObjectFrame(
    shape->get_X(), 
    shape->get_Y(), 
    shape->get_Width(), 
    shape->get_Height(),
    dataInfo);
```

**سناریو 2**

فرض کنید می‌خواهیم یک ارائه از ابتدا ایجاد کنیم و یک قاب OLE با هر اندازه‌ای که می‌خواهیم شامل کتاب‌کار Excel جاسازی‌شده داشته باشیم. در قطعه کد زیر، یک قاب OLE با ارتفاع 4 اینچ و عرض 9.5 اینچ در موقعیت x = 0.5 اینچ و y = 1 اینچ روی اسلاید ایجاد می‌کنیم. سپس پنجرهٔ کتاب‌کار Excel را به همان اندازه—ارتفاع 4 اینچ و عرض 9.5 اینچ—تنظیم می‌کنیم.

```cpp
// ارتفاع مطلوب ما.
int32_t desiredHeight = 288; // 4 اینچ (4 * 72)

// عرض مطلوب ما.
int32_t desiredWidth = 684; // 9.5 اینچ (9.5 * 72)

// اندازه نمودار را با یک پنجره تعریف کنید. 
chart->SetSizeWithWindow(true);

// پنجره عرض کتاب‌کار را به اینچ تنظیم کنید.
workbook->GetISettings()->SetWindowWidthInch(desiredWidth / 72.f);

// پنجره ارتفاع کتاب‌کار را به اینچ تنظیم کنید.
workbook->GetISettings()->SetWindowHeightInch(desiredHeight / 72.f);

// کتاب‌کار را به یک جریان حافظه ذخیره کنید.
System::SharedPtr<System::IO::MemoryStream> workbookStream = ToSlidesMemoryStream(workbook->SaveToStream());

System::SharedPtr<IOleEmbeddedDataInfo> dataInfo = System::MakeObject<OleEmbeddedDataInfo>(workbookStream->ToArray(), u"xls");

// یک قاب شیء OLE با داده‌های Excel جاسازی‌شده ایجاد کنید.
System::SharedPtr<IOleObjectFrame> oleFrame = slide->get_Shapes()->AddOleObjectFrame(
    36.0f,
    72.0f, 
    desiredWidth, 
    desiredHeight,
    dataInfo);
```

## **رویکرد دوم**

در این رویکرد، می‌آموزیم چگونه اندازهٔ نمودار در کتاب‌کار Excel جاسازی‌شده را تنظیم کنیم تا با اندازهٔ قاب شیء OLE در اسلاید PowerPoint مطابقت داشته باشد. این رویکرد زمانی مفید است که اندازهٔ نمودار از پیش مشخص باشد و هرگز تغییر نکند.

**سناریو 1**

فرض کنید یک قالب تعریف کرده‌ایم و می‌خواهیم ارائه‌هایی بر پایهٔ آن ایجاد کنیم. فرض کنید در قالب یک Shape‌ با ایندکس 2 وجود دارد که قصد داریم یک قاب OLE حاوی کتاب‌کار Excel جاسازی‌شده در آن قرار دهیم. در این سناریو، اندازهٔ قاب OLE از پیش تعریف شده است—که با اندازهٔ Shape‌ با ایندکس 2 منطبق است. تنها کاری که باید انجام دهیم این است که اندازهٔ نمودار در کتاب‌کار را برابر با اندازهٔ آن Shape تنظیم کنیم. قطعه کد زیر این کار را انجام می‌دهد:

```cpp
// اندازه نمودار را بدون پنجره تعریف کنید. 
chart->SetSizeWithWindow(false);

auto shape = slide->get_Shape(2);

// عرض نمودار را برحسب پیکسل تنظیم کنید (در 96 ضرب کنید زیرا Excel از 96 پیکسل در هر اینچ استفاده می‌کند).    
chart->GetIChartObject()->SetWidth((int32_t)(shape->get_Width() / 72.f * 96.f));

// ارتفاع نمودار را برحسب پیکسل تنظیم کنید.
chart->GetIChartObject()->SetHeight((int32_t)(shape->get_Height() / 72.f) * 96.f);

// اندازه چاپ نمودار را تعریف کنید.
chart->SetPrintSize(Aspose::Cells::PrintSizeType::PrintSizeType_Custom);

// کتاب‌کار را به یک جریان حافظه ذخیره کنید.
System::SharedPtr<System::IO::MemoryStream> workbookStream = ToSlidesMemoryStream(workbook->SaveToStream());

System::SharedPtr<IOleEmbeddedDataInfo> dataInfo = System::MakeObject<OleEmbeddedDataInfo>(workbookStream->ToArray(), u"xls");

// یک قاب شیء OLE با داده‌های Excel جاسازی‌شده ایجاد کنید.
System::SharedPtr<IOleObjectFrame> oleFrame = slide->get_Shapes()->AddOleObjectFrame(
    shape->get_X(), 
    shape->get_Y(), 
    shape->get_Width(),
    shape->get_Height(),
    dataInfo);
```

**سناریو 2**

فرض کنید می‌خواهیم یک ارائه از ابتدا ایجاد کنیم و یک قاب OLE با هر اندازه‌ای که می‌خواهیم شامل کتاب‌کار Excel جاسازی‌شده داشته باشیم. در قطعه کد زیر، یک قاب OLE با ارتفاع 4 اینچ و عرض 9.5 اینچ در موقعیت x = 0.5 اینچ و y = 1 اینچ روی اسلاید ایجاد می‌کنیم. همچنین اندازهٔ نمودار متناظر را به همان ابعاد تنظیم می‌کنیم: ارتفاع 4 اینچ و عرض 9.5 اینچ.

```cpp
// ارتفاع مورد نظر ما.
int32_t desiredHeight = 288; // 4 اینچ (4 * 576)

// عرض مورد نظر ما.
int32_t desiredWidth = 684; // 9.5 اینچ (9.5 * 576)

// اندازه نمودار را بدون پنجره تعریف کنید. 
chart->SetSizeWithWindow(false);

// عرض نمودار را به پیکسل تنظیم کنید.    
chart->GetIChartObject()->SetWidth((int32_t)((desiredWidth / 72.f) * 96.f));

// ارتفاع نمودار را به پیکسل تنظیم کنید.
chart->GetIChartObject()->SetHeight((int32_t)((desiredHeight / 72.f) * 96.f));

// کتاب‌کار را به یک جریان حافظه ذخیره کنید.
System::SharedPtr<System::IO::MemoryStream> workbookStream = ToSlidesMemoryStream(workbook->SaveToStream());

System::SharedPtr<IOleEmbeddedDataInfo> dataInfo = System::MakeObject<OleEmbeddedDataInfo>(workbookStream->ToArray(), u"xls");

// یک قاب شیء OLE با داده‌های Excel جاسازی‌شده ایجاد کنید.
System::SharedPtr<IOleObjectFrame> oleFrame = slide->get_Shapes()->AddOleObjectFrame(
    36.0f, 
    72.0f, 
    desiredWidth, 
    desiredHeight,
    dataInfo);
```

## **نتیجه‌گیری**

دو رویکرد برای رفع مشکل تغییر اندازهٔ نمودار وجود دارد. انتخاب رویکرد بستگی به نیازها و مورد استفاده دارد. هر دو رویکرد به همان شیوه کار می‌کنند چه ارائه‌ها از قالب ساخته شوند و چه از ابتدا. همچنین در این راه‌حل هیچ محدودیتی برای اندازهٔ قاب شیء OLE وجود ندارد.

## **سوالات متداول**

**چرا پس از فعال‌سازی نمودار Excel جاسازی‌شده در PowerPoint اندازه‌اش تغییر می‌کند؟**

این به این دلیل است که Excel سعی می‌کند اندازهٔ پنجرهٔ اصلی خود را در اولین فعال‌سازی بازیابی کند، در حالی که قاب شیء OLE در PowerPoint ابعاد خاص خود را دارد. PowerPoint و Excel اندازه را مذاکره می‌کنند تا نسبت ابعاد حفظ شود و این می‌تواند منجر به تغییر اندازه شود.

**آیا می‌توان این مشکل تغییر اندازه را به‌طور کامل جلوگیری کرد؟**

بله. با منطبق کردن اندازهٔ پنجرهٔ کتاب‌کار Excel یا اندازهٔ نمودار با اندازهٔ قاب شیء OLE قبل از جاسازی، می‌توانید اندازهٔ نمودارها را ثابت نگه دارید.

**کدام رویکرد را باید انتخاب کنم، تنظیم اندازهٔ پنجرهٔ کتاب‌کار یا تنظیم اندازهٔ نمودار؟**

از **رویکرد 1 (اندازهٔ پنجره)** استفاده کنید اگر می‌خواهید نسبت ابعاد کتاب‌کار حفظ شود و احتمالاً بعداً امکان تغییر اندازه وجود داشته باشد.
از **رویکرد 2 (اندازهٔ نمودار)** استفاده کنید اگر ابعاد نمودار ثابت هستند و پس از جاسازی تغییر نمی‌کنند.

**آیا این روش‌ها برای هر دو نوع ارائه—بر پایهٔ قالب و جدید—عمل می‌کنند؟**

بله. هر دو رویکرد برای ارائه‌های ساخته‌شده از قالب و از ابتدا به‌یکسان کار می‌کنند.

**آیا محدودیتی برای اندازهٔ قاب شیء OLE وجود دارد؟**

خیر. می‌توانید قاب OLE را به هر اندازه‌ای تنظیم کنید به شرط آنکه به‌درستی نسبت به اندازهٔ کتاب‌کار یا نمودار مقیاس‌بندی شود.

**آیا می‌توان از این روش‌ها برای نمودارهای ساخته‌شده در برنامه‌های صفحه‌گسترده دیگر استفاده کرد؟**

نمونه‌ها برای نمودارهای Excel ساخته‌شده با Aspose.Cells طراحی شده‌اند، اما اصول به‌کار رفته برای برنامه‌های صفحه‌گسترده سازگار با OLE که گزینه‌های مشابهی برای تنظیم اندازه دارند، نیز قابل اعمال هستند.

## **بخش‌های مرتبط**

- [Create Excel Charts and Embed Them as OLE Objects in Presentations](/slides/fa/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)