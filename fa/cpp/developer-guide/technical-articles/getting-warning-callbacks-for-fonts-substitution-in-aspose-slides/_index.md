---
title: دریافت بازخوردهای هشدار برای جایگزینی قلم
type: docs
weight: 70
url: /fa/cpp/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
keywords:
- بازخورد هشدار
- جایگزینی قلم
- فرآیند رندرینگ
- PowerPoint
- OpenDocument
- ارائه
- C++
- Aspose.Slides
description: "یاد بگیرید چگونه بازخوردهای هشدار برای جایگزینی قلم در Aspose.Slides برای C++ دریافت کنید و ارائه‌های PowerPoint و OpenDocument را به‌دقت نمایش دهید."
---
## **معرفی**

Aspose.Slides برای C++ به شما امکان دریافت بازخوردهای هشدار برای جایگزینی قلم را می‌دهد وقتی قلم مورد نیاز در زمان رندرینگ بر روی دستگاه موجود نیست. این بازخوردها به تشخیص مشکلات مربوط به قلم‌های گم‌شده یا غیرقابل دسترس کمک می‌کند.

## **فعال‌سازی بازخوردهای هشدار**

Aspose.Slides برای C++ APIهای ساده‌ای برای دریافت بازخوردهای هشدار هنگام رندر اسلایدهای ارائه فراهم می‌کند. برای پیکربندی بازخوردهای هشدار این مراحل را دنبال کنید:

1. یک کلاس بازخورد سفارشی ایجاد کنید که رابط [IWarningCallback](https://reference.aspose.com/slides/fa/cpp/aspose.slides.warnings/iwarningcallback/) را برای پردازش هشدارها پیاده‌سازی می‌کند.
2. بازخورد هشدار را با استفاده از کلاس‌های گزینه مانند [RenderingOptions](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/renderingoptions/), [PdfOptions](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/htmloptions/) و سایرین تنظیم کنید.
3. یک ارائه را بارگذاری کنید که از قلمی استفاده می‌کند که بر روی دستگاه هدف موجود نیست.
4. یک تصویر بندانگشتی اسلاید تولید کنید یا ارائه را صادرات کنید تا اثر را مشاهده کنید.

**کلاس بازخورد سفارشی هشدار:**

```cpp
#include <Warnings/IWarningCallback.h>

class FontWarningHandler : public IWarningCallback
{
public:
    ReturnAction Warning(SharedPtr<IWarningInfo> warning) override;
};

ReturnAction FontWarningHandler::Warning(SharedPtr<IWarningInfo> warning)
{
    if (warning->get_WarningType() == WarningType::DataLoss)
    {
        Console::WriteLine(warning->get_Description());
    }

    return ReturnAction::Continue;
}

// خروجی مثال:
//
// قلم از XYZ به {Calibri,Cambria Math,MS Gothic,Gulim,Arial Unicode,SimSun,Segoe UI Symbol}}
```

**تولید تصویر بندانگشتی اسلاید:**

```cpp
// تنظیم یک بازخورد هشدار برای پردازش هشدارهای مرتبط با قلم هنگام رندر اسلاید.
auto options = MakeObject<RenderingOptions>();
options->set_WarningCallback(MakeObject<FontWarningHandler>());

// بارگذاری ارائه از مسیر فایل مشخص شده.
auto presentation = MakeObject<Presentation>(u"sample.pptx");
    
// تولید تصویر بندانگشتی برای هر اسلاید در ارائه.
for(auto&& slide : presentation->get_Slides())
{
    // دریافت تصویر بندانگشتی اسلاید با استفاده از گزینه‌های رندرینگ مشخص شده.
    auto image = slide->GetImage(options);
    // ...

    image->Dispose();
}

presentation->Dispose();
```

**صادرات به فرمت PDF:**

```cpp
// تنظیم یک بازخورد هشدار برای پردازش هشدارهای مرتبط با قلم هنگام خروجی PDF.
auto options = MakeObject<PdfOptions>();
options->set_WarningCallback(MakeObject<FontWarningHandler>());

// بارگذاری ارائه از مسیر فایل مشخص شده.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// خروجی ارائه به صورت PDF.
auto stream = MakeObject<MemoryStream>();
presentation->Save(stream, SaveFormat::Pdf, options);
// ...

stream->Dispose();
presentation->Dispose();
```

**صادرات به فرمت HTML:**

```cpp
// تنظیم یک بازخورد هشدار برای پردازش هشدارهای مرتبط با قلم هنگام خروجی HTML.
auto options = MakeObject<HtmlOptions>();
options->set_WarningCallback(MakeObject<FontWarningHandler>());

// بارگذاری ارائه از مسیر فایل مشخص شده.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// خروجی ارائه به فرمت HTML.
auto stream = MakeObject<MemoryStream>();
presentation->Save(stream, SaveFormat::Html, options);
// ...

stream->Dispose();
presentation->Dispose();
```