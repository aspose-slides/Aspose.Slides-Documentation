---
title: سفارشی‌سازی جداول داده چارت در ارائه‌ها با C++
linktitle: جدول داده
type: docs
url: /fa/cpp/chart-data-table/
keywords:
- داده چارت
- جدول داده
- ویژگی‌های قلم
- PowerPoint
- ارائه
- C++
- Aspose.Slides
description: "جداول داده چارت را در C++ برای PPT و PPTX با Aspose.Slides سفارشی‌سازی کنید تا کارایی و جذابیت ارائه‌ها را افزایش دهید."
---
## **بررسی کلی**

این مقاله نحوه کار با جداول داده‌ چارت در Aspose.Slides را توضیح می‌دهد. این مقاله نشان می‌دهد چگونه یک جدول داده برای یک چارت نمایش داده شود و قالب‌بندی متن آن را با تنظیم ویژگی‌های قلم مانند سبک بولد و ارتفاع قلم سفارشی‌سازی کنید. نمونه نشان می‌دهد چگونه یک ارائه بارگذاری شود، یک چارت اضافه شود، جدول داده چارت فعال شود، تنظیمات قلم اعمال شود و ارائه به‌روزرسانی شده ذخیره شود.

## **تنظیم ویژگی‌های قلم برای جدول داده چارت**
Aspose.Slides برای C++ امکان تغییر ویژگی‌های قلم برای جدول داده یک چارت را فراهم می‌کند.

1. یک شیء از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.presentation) را ایجاد کنید.
1. یک چارت به اسلاید اضافه کنید.
1. جدول چارت را تنظیم کنید.
1. ارتفاع قلم را تنظیم کنید.
1. ارائه تغییر یافته را ذخیره کنید.

نمونه کد زیر ارائه شده است.

``` cpp
auto pres = System::MakeObject<Presentation>(u"test.pptx");
    
auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f);

chart->set_HasDataTable(true);

chart->get_ChartDataTable()->get_TextFormat()->get_PortionFormat()->set_FontBold(NullableBool::True);
chart->get_ChartDataTable()->get_TextFormat()->get_PortionFormat()->set_FontHeight(20.0f);

pres->Save(u"output.pptx", SaveFormat::Pptx);
```

## **پرسش‌های متداول**

**آیا می‌توانم کلیدهای کوچک افسانه را در کنار مقادیر در جدول داده چارت نشان دهم؟**

بله. جدول داده از [کلیدهای افسانه](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/datatable/set_showlegendkey/) پشتیبانی می‌کند و می‌توانید آنها را فعال یا غیرفعال کنید.

**آیا جدول داده هنگام صادرات ارائه به PDF، HTML یا تصویر حفظ می‌شود؟**

بله. Aspose.Slides چارت را به‌عنوان بخشی از اسلاید رندر می‌کند، بنابراین [PDF](/slides/fa/cpp/convert-powerpoint-to-pdf/)/[HTML](/slides/fa/cpp/convert-powerpoint-to-html/)/[image](/slides/fa/cpp/convert-powerpoint-to-png/) خروجی شامل چارت به همراه جدول داده آن است.

**آیا جداول داده برای چارت‌هایی که از یک فایل قالب بارگذاری می‌شوند پشتیبانی می‌شود؟**

بله. برای هر چارتی که از یک ارائه یا قالب موجود بارگذاری می‌شود، می‌توانید با استفاده از ویژگی‌های چارت، بررسی و تغییر دهید که آیا جدول داده [نمایش داده می‌شود](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/chart/set_hasdatatable/) یا نه.

**چگونه می‌توانم به‌سرعت تشخیص دهم کدام چارت‌ها در یک فایل جدول داده فعال دارند؟**

ویژگی هر چارت که نشان می‌دهد آیا جدول داده [نمایش داده می‌شود](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/chart/get_hasdatatable/) را بررسی کنید و اسلایدها را مرور کنید تا چارت‌هایی که این ویژگی فعال است شناسایی شوند.