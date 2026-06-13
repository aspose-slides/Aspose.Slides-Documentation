---
title: سفارشی‌سازی جداول داده‌های نمودار در ارائه‌ها با استفاده از C++
linktitle: جدول داده
type: docs
url: /fa/cpp/chart-data-table/
keywords:
- داده‌های نمودار
- جدول داده
- ویژگی‌های قلم
- PowerPoint
- ارائه
- C++
- Aspose.Slides
description: "جداول داده‌های نمودار را در C++ برای فایل‌های PPT و PPTX با Aspose.Slides سفارشی کنید تا کارایی و جذابیت ارائه‌ها را افزایش دهید."
---
## **بررسی کلی**

این مقاله توضیح می‌دهد چگونه با جداول داده‌های نمودار در Aspose.Slides کار کنید. این مقاله نشان می‌دهد چگونه یک جدول داده برای یک نمودار نمایش داده شود و قالب‌بندی متن آن را با تنظیم ویژگی‌های قلم مانند حالت بولد و ارتفاع قلم سفارشی کنید. نمونه کد بارگذاری یک ارائه، افزودن یک نمودار، فعال‌سازی جدول داده‌های نمودار، اعمال تنظیمات قلم و ذخیره ارائه به‌روز شده را نشان می‌دهد.

## **تنظیم ویژگی‌های قلم برای جدول داده‌های نمودار**
Aspose.Slides برای C++ امکان تغییر ویژگی‌های قلم برای جدول داده‌های نمودار را فراهم می‌کند.

1. شیء کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.presentation) را نمونه‌سازی کنید.
2. نموداری را در اسلاید اضافه کنید.
3. جدول نمودار را تنظیم کنید.
4. ارتفاع قلم را تنظیم کنید.
5. ارائه اصلاح‌شده را ذخیره کنید.

مثال نمونه زیر آورده شده است.
``` cpp
auto pres = System::MakeObject<Presentation>(u"test.pptx");
    
auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f);

chart->set_HasDataTable(true);

chart->get_ChartDataTable()->get_TextFormat()->get_PortionFormat()->set_FontBold(NullableBool::True);
chart->get_ChartDataTable()->get_TextFormat()->get_PortionFormat()->set_FontHeight(20.0f);

pres->Save(u"output.pptx", SaveFormat::Pptx);
```

## **پرسش‌های متداول**

**آیا می‌توانم کلیدهای کوچک افسانه را کنار مقادیر در جدول داده‌های نمودار نمایش دهم؟**
بله. جدول داده‌ها از [کلیدهای افسانه](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/datatable/set_showlegendkey/) پشتیبانی می‌کند و می‌توانید آنها را روشن یا خاموش کنید.

**آیا جدول داده‌ها هنگام خروجی گرفتن ارائه به PDF، HTML یا تصاویر حفظ می‌شود؟**
بله. Aspose.Slides نمودار را به عنوان بخشی از اسلاید رندر می‌کند، بنابراین [PDF](/slides/fa/cpp/convert-powerpoint-to-pdf/)/[HTML](/slides/fa/cpp/convert-powerpoint-to-html/)/[image](/slides/fa/cpp/convert-powerpoint-to-png/) صادر شده شامل نمودار همراه با جدول داده آن می‌شود.

**آیا جداول داده برای نمودارهایی که از فایل الگو بارگذاری می‌شوند پشتیبانی می‌شوند؟**
بله. برای هر نموداری که از یک ارائه یا الگوی موجود بارگذاری شده است، می‌توانید با استفاده از ویژگی‌های نمودار بررسی و تغییر دهید که آیا جدول داده [نمایش داده می‌شود](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/chart/set_hasdatatable/) یا نه.

**چگونه می‌توانم به سرعت پیدا کنم کدام نمودارها در یک فایل جدول داده فعال دارند؟**
ویژگی هر نمودار که نشان می‌دهد جدول داده [نمایش داده می‌شود](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/chart/get_hasdatatable/) را بررسی کنید و از طریق اسلایدها مرور کنید تا نمودارهایی که این ویژگی فعال است شناسایی شوند.