---
title: "تغییر اندازه اشکال در اسلایدهای ارائه با C++"
type: docs
weight: 130
url: /fa/cpp/resizing-shapes-on-slide/
aliases:
  - /cpp/re-sizing-shapes-on-slide/
  - /fa/cpp/re-sizing-shapes-on-slide/
keywords:
- "تغییر اندازه شکل"
- "تغییر سایز شکل"
- PowerPoint
- OpenDocument
- presentation
- C++
- Aspose.Slides
description: "به‌راحتی اشکال را در اسلایدهای PowerPoint و OpenDocument با Aspose.Slides برای C++ تغییر اندازه دهید—تنظیم خودکار چیدمان اسلاید و افزایش بهره‌وری."
---
## **مرور کلی**

زمانی که اندازه اسلاید یک ارائه را تغییر می‌دهید، ممکن است نیاز به تغییر اندازه و جابجایی اشکال آن داشته باشید تا با ابعاد جدید مطابقت پیدا کنند. این مقاله نشان می‌دهد چگونه اشکال را به‌صورت دستی مقیاس‌بندی کنید و چطور جدول‌ها را در اسلایدها، ماسترها و لایه‌ها مدیریت کنید.

## **تغییر اندازه اشکال**

برای حفظ موقعیت و اندازه نسبی هر شکل، مختصات افقی و عرض آن را در نسبت عرض اسلاید جدید به عرض اصلی ضرب کنید. نسبت ارتفاع مربوطه را بر روی مختصات عمودی و ارتفاع آن اعمال کنید.

مثال اول یک ارائه را که اسلایدهای آن شامل جدول نیستند بارگذاری می‌کند، اندازه اسلاید را به A4 تغییر می‌دهد و نتیجه را ذخیره می‌کند. این مثال از [SlideSize::SetSize](https://reference.aspose.com/slides/cpp/aspose.slides/slidesize/setsize/) همراه با [SlideSizeScaleType::DoNotScale](https://reference.aspose.com/slides/cpp/aspose.slides/slidesizescaletype/) استفاده می‌کند تا حلقه بعدی مقیاس‌بندی را کنترل کند. نسبت‌ها بدون واحد هستند؛ موقعیت و ابعاد اشکال بر حسب پوینت اندازه‌گیری می‌شوند. نسبت‌های متفاوت عرض و ارتفاع می‌توانند اشکال را کشیده یا فشرده کنند و تغییر ابعاد یک شکل اندازهٔ قلم آن را مقیاس‌بندی نمی‌کند.

```cpp
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <DOM/SlideSizeType.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

// محاسبه عوامل مقیاس افقی و عمودی مستقل.
auto originalSize = presentation->get_SlideSize()->get_Size();
presentation->get_SlideSize()->SetSize(SlideSizeType::A4Paper, SlideSizeScaleType::DoNotScale);
auto targetSize = presentation->get_SlideSize()->get_Size();
auto widthRatio = targetSize.get_Width() / originalSize.get_Width();
auto heightRatio = targetSize.get_Height() / originalSize.get_Height();

for (auto&& slide : presentation->get_Slides())
{
    for (auto&& shape : slide->get_Shapes())
    {
        shape->set_Width(shape->get_Width() * widthRatio);
        shape->set_Height(shape->get_Height() * heightRatio);
        shape->set_X(shape->get_X() * widthRatio);
        shape->set_Y(shape->get_Y() * heightRatio);
    }
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

{{% alert color="info" title="Note" %}}
جدول‌ها به‌صورت جداگانه باید مدیریت شوند: عرض ستون‌ها و ارتفاع ردیف‌ها را مقیاس‌بندی کنید به جای اختصاص عرض و ارتفاع کلی جدول. ارتفاع ردیف‌ها ممکن است بزرگ‌تر از مقدار درخواست‌شده باقی بماند اگر محتوای سلول به فضای بیشتری نیاز داشته باشد.
{{% /alert %}}

مثال دوم از جدول‌ها پشتیبانی می‌کند و اشکال را در ماسترها و لایه‌ها و همچنین اسلایدهای منفرد قبل از ذخیرهٔ ارائهٔ تغییر اندازه‌ یافته پردازش می‌نماید. کمک‌کنندهٔ آن هر [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) را با مقیاس‌بندی [IColumn::set_Width](https://reference.aspose.com/slides/cpp/aspose.slides/icolumn/set_width/) و [IRow::set_MinimalHeight](https://reference.aspose.com/slides/cpp/aspose.slides/irow/set_minimalheight/) مدیریت می‌کند. سپس موقعیت جدول را بدون مقیاس‌بندی مجزا از ابعاد کلی آن مقیاس می‌دهد.

```cpp
#include <DOM/ILayoutSlide.h>
#include <DOM/ILayoutSlideCollection.h>
#include <DOM/IMasterLayoutSlideCollection.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IMasterSlideCollection.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <DOM/SlideSizeType.h>
#include <DOM/Table/IColumn.h>
#include <DOM/Table/IColumnCollection.h>
#include <DOM/Table/IRow.h>
#include <DOM/Table/IRowCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

// محاسبه عوامل مقیاس افقی و عمودی مستقل.
auto originalSize = presentation->get_SlideSize()->get_Size();
presentation->get_SlideSize()->SetSize(SlideSizeType::A4Paper, SlideSizeScaleType::DoNotScale);
auto targetSize = presentation->get_SlideSize()->get_Size();
auto widthRatio = targetSize.get_Width() / originalSize.get_Width();
auto heightRatio = targetSize.get_Height() / originalSize.get_Height();

auto resizeShapes = [](SharedPtr<IShapeCollection> shapes, float widthRatio, float heightRatio)
{
    for (auto&& shape : shapes)
    {
        if (ObjectExt::Is<ITable>(shape))
        {
            auto table = ExplicitCast<ITable>(shape);
            // ابعاد جدول توسط عرض ستون‌ها و ارتفاع ردیف‌ها کنترل می‌شود.
            for (auto&& column : table->get_Columns())
            {
                column->set_Width(column->get_Width() * widthRatio);
            }

            for (auto&& row : table->get_Rows())
            {
                row->set_MinimalHeight(row->get_MinimalHeight() * heightRatio);
            }
        }
        else
        {
            shape->set_Width(shape->get_Width() * widthRatio);
            shape->set_Height(shape->get_Height() * heightRatio);
        }

        shape->set_X(shape->get_X() * widthRatio);
        shape->set_Y(shape->get_Y() * heightRatio);
    }
};

// تغییر اندازه اشکال تعریف‌شده در ماسترها و لایه‌ها و همچنین اسلایدهای منفرد.
for (auto&& master : presentation->get_Masters())
{
    resizeShapes(master->get_Shapes(), widthRatio, heightRatio);

    for (auto&& layoutSlide : master->get_LayoutSlides())
    {
        resizeShapes(layoutSlide->get_Shapes(), widthRatio, heightRatio);
    }
}

for (auto&& slide : presentation->get_Slides())
{
    resizeShapes(slide->get_Shapes(), widthRatio, heightRatio);
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **سوالات متداول**

**چرا پس از تغییر اندازه اسلاید اشکال کشیده یا قطع می‌شوند؟**

اگر اندازه اسلاید را بدون مقیاس‌بندی اشکال تغییر دهید، آن‌ها موقعیت و ابعاد اصلی خود را حفظ می‌کنند و ممکن است خارج از اسلاید گسترش یابند. مقیاس‌بندی عرض و ارتفاع با نسبت‌های متفاوت نیز می‌تواند اشکال را کشیده کند.

**آیا کد ارائه شده برای تمام انواع اشکال کار می‌کند؟**

مثال اول مرزهای شکل را به‌صورت مستقیم تغییر می‌دهد و برای اسلایدهایی بدون جدول در نظر گرفته شده است. مثال دوم جدول‌ها را به‌صورت جداگانه مدیریت می‌کند. چیدمان حاصل را بررسی کنید، به‌ویژه متن و جدول‌ها، زیرا این مثال‌ها اندازهٔ قلم را مقیاس‌بندی نمی‌کنند و محتوای جدول می‌تواند ارتفاع ردیف‌ها را محدود کند.

**چگونه هنگام تغییر اندازه اسلاید، جدول‌ها را نیز تغییر اندازه دهم؟**

عرض ستون‌ها را با نسبت عرض و حداقل ارتفاع ردیف‌ها را با نسبت ارتفاع مقیاس‌بندی کنید، سپس موقعیت جدول را مقیاس دهید، همان‌طور که در مثال دوم نشان داده شده است.

**آیا این تغییر اندازه برای اسلایدهای ماستر و لایهٔ اسلاید کار می‌کند؟**

بله. مثال دوم از طریق [Presentation::get_Masters](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_masters/) و هر [IMasterSlide::get_LayoutSlides](https://reference.aspose.com/slides/cpp/aspose.slides/imasterslide/get_layoutslides/) ماستر پیمایش می‌کند و همان منطق تغییر اندازه را بر روی اشکال آنها اعمال می‌کند.

**آیا می‌توانم جهت اسلاید (پرتره/لنداسکیپ) را همراه با تغییر اندازه تغییر دهم؟**

بله. پس از تغییر اندازه اسلاید و قبل از خواندن ابعاد هدف، [SlideSize::set_Orientation](https://reference.aspose.com/slides/cpp/aspose.slides/slidesize/set_orientation/) را تنظیم کنید تا عوامل مقیاس جهت نهایی را منعکس کنند.

**آیا محدودیتی برای اندازهٔ اسلاید که می‌توانم تنظیم کنم وجود دارد؟**

می‌توانید ابعاد سفارشی اسلاید را با استفاده از [SlideSize::SetSize](https://reference.aspose.com/slides/cpp/aspose.slides/slidesize/setsize/) مشخص کنید. ابعاد پشتیبانی‌شده همچنین به قالب ارائه و برنامه‌ای که برای باز کردن فایل استفاده می‌شود بستگی دارد.

**چگونه می‌توانم از کشیده شدن اشکالی که نسبت ابعاد ثابت دارند جلوگیری کنم؟**

از همان عامل مقیاس برای عرض و ارتفاع استفاده کنید. برای سازگار کردن چیدمان اصلی با ابعاد جدید اسلاید، نسبت کوچک‌تر بین عرض و ارتفاع را برای هر دو بُعد و موقعیت‌ها به کار ببرید. این کار نسبت‌ها را حفظ می‌کند اما ممکن است فضای نامستخدمی در یک سمت باقی بگذارد.