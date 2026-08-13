---
title: تغییر اندازه اشکال در اسلایدهای ارائه
type: docs
weight: 100
url: /fa/cpp/re-sizing-shapes-on-slide/
keywords:
- تغییر اندازه شکل
- تغییر اندازه شکل
- PowerPoint
- OpenDocument
- ارائه
- C++
- Aspose.Slides
description: "به راحتی اشکال را در اسلایدهای PowerPoint و OpenDocument با Aspose.Slides برای C++ تغییر اندازه دهید—تنظیمات چیدمان اسلایدها را خودکار کنید و بهره‌وری را افزایش دهید."
---
## **نگاهی کلی**

یکی از سوالات رایج مشتریان Aspose.Slides برای C++ این است که چگونه اشکال را تغییر اندازه دهند به طوری که وقتی اندازه اسلاید تغییر می‌کند، داده‌ها بریده نشوند. این مقاله فنی کوتاه نشان می‌دهد که چگونه این کار را انجام دهید.

## **تغییر اندازه اشکال**

برای جلوگیری از به‌هم‌ریختگی اشکال هنگام تغییر اندازه اسلاید، موقعیت و ابعاد هر شکل را به‌روزرسانی کنید تا با طرح جدید اسلاید مطابقت داشته باشد.

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

// بارگذاری فایل ارائه.
auto presentation = MakeObject<Presentation>(u"sample.ppt");

// دریافت اندازه اولیه اسلاید.
float currentHeight = presentation->get_SlideSize()->get_Size().get_Height();
float currentWidth = presentation->get_SlideSize()->get_Size().get_Width();

// تغییر اندازه اسلاید بدون مقیاس‌بندی اشکال موجود.
presentation->get_SlideSize()->SetSize(SlideSizeType::A4Paper, SlideSizeScaleType::DoNotScale);

// دریافت اندازه جدید اسلاید.
float newHeight = presentation->get_SlideSize()->get_Size().get_Height();
float newWidth = presentation->get_SlideSize()->get_Size().get_Width();

float heightRatio = newHeight / currentHeight;
float widthRatio = newWidth / currentWidth;

// تغییر اندازه و موقعیت اشکال در هر اسلاید.
for (auto&& slide : presentation->get_Slides())
{
    for (auto&& shape : slide->get_Shapes())
    {
        // مقیاس‌بندی اندازه شکل.
        shape->set_Height(shape->get_Height() * heightRatio);
        shape->set_Width(shape->get_Width() * widthRatio);

        // مقیاس‌بندی موقعیت شکل.
        shape->set_Y(shape->get_Y() * heightRatio);
        shape->set_X(shape->get_X() * widthRatio);
    }
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

{{% alert color="info" %}} 
اگر یک اسلاید شامل جدول باشد، کد بالا به‌درستی کار نخواهد کرد. در این صورت، هر سلول در جدول باید تغییر اندازه داده شود.
{{% /alert %}} 

از کد زیر در سمت خود برای تغییر اندازه اسلایدهایی که شامل جدول هستند استفاده کنید. برای جداول، تنظیم عرض یا ارتفاع یک مورد خاص است: باید ارتفاع ردیف‌های جداگانه و عرض ستون‌ها را برای تغییر اندازه کلی جدول تنظیم کنید.

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
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

// دریافت اندازه اولیه اسلاید.
float currentHeight = presentation->get_SlideSize()->get_Size().get_Height();
float currentWidth = presentation->get_SlideSize()->get_Size().get_Width();

// تغییر اندازه اسلاید بدون مقیاس‌گذاری اشکال موجود.
presentation->get_SlideSize()->SetSize(SlideSizeType::A4Paper, SlideSizeScaleType::DoNotScale);
//presentation.SlideSize.Orientation = SlideOrienation.Portrait;

// دریافت اندازه جدید اسلاید.
float newHeight = presentation->get_SlideSize()->get_Size().get_Height();
float newWidth = presentation->get_SlideSize()->get_Size().get_Width();

float heightRatio = newHeight / currentHeight;
float widthRatio = newWidth / currentWidth;

for (auto&& master : presentation->get_Masters())
{
    for (auto&& shape : master->get_Shapes())
    {
        // مقیاس‌بندی اندازه شکل.
        shape->set_Height(shape->get_Height() * heightRatio);
        shape->set_Width(shape->get_Width() * widthRatio);

        // مقیاس‌بندی موقعیت شکل.
        shape->set_Y(shape->get_Y() * heightRatio);
        shape->set_X(shape->get_X() * widthRatio);
    }

    for (auto&& layoutSlide : master->get_LayoutSlides())
    {
        for (auto&& shape : layoutSlide->get_Shapes())
        {
            // مقیاس‌بندی اندازه شکل.
            shape->set_Height(shape->get_Height() * heightRatio);
            shape->set_Width(shape->get_Width() * widthRatio);

            // مقیاس‌بندی موقعیت شکل.
            shape->set_Y(shape->get_Y() * heightRatio);
            shape->set_X(shape->get_X() * widthRatio);
        }
    }
}

for (auto&& slide : presentation->get_Slides())
{
    for (auto&& shape : slide->get_Shapes())
    {
        // مقیاس‌بندی اندازه شکل.
        shape->set_Height(shape->get_Height() * heightRatio);
        shape->set_Width(shape->get_Width() * widthRatio);

        // مقیاس‌بندی موقعیت شکل.
        shape->set_Y(shape->get_Y() * heightRatio);
        shape->set_X(shape->get_X() * widthRatio);

        if (ObjectExt::Is<ITable>(shape))
        {
            SharedPtr<ITable> table = ExplicitCast<ITable>(shape);
            for (auto&& row : table->get_Rows())
            {
                row->set_MinimalHeight(row->get_MinimalHeight() * heightRatio);
            }
            for (auto&& column : table->get_Columns())
            {
                column->set_Width(column->get_Width() * widthRatio);
            }
        }
    }
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **سوالات متداول**

### چرا پس از تغییر اندازه اسلاید، اشکال کشیده یا بریده می‌شوند؟

هنگام تغییر اندازه اسلاید، اگر مقیاس به‌صراحت تغییر نکند، اشکال موقعیت و اندازه اصلی خود را حفظ می‌کنند. این می‌تواند منجر به برش محتوا یا به‌هم‌ریختگی اشکال شود.

### آیا کد ارائه‌شده برای تمام انواع اشکال کار می‌کند؟

مثال پایه برای اکثر انواع اشکال (جعبه‌های متن، تصاویر، نمودارها و غیره) کار می‌کند. اما برای جداول، باید ردیف‌ها و ستون‌ها را جداگانه مدیریت کنید، زیرا ارتفاع و عرض جدول توسط ابعاد سلول‌های منفرد تعیین می‌شود.

### چگونه جداول را هنگام تغییر اندازه اسلاید تغییر اندازه دهم؟

باید در تمام ردیف‌ها و ستون‌های جدول مرور کنید و ارتفاع و عرض آن‌ها را به‌صورت نسبی تنظیم کنید، همان‌طور که در مثال دوم کد نشان داده شده است.

### آیا این تغییر اندازه برای اسلایدهای اصلی و اسلایدهای طرح‌بندی نیز اعمال می‌شود؟

بلی، اما باید همچنین در [اسلایدهای اصلی](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/get_masters/) و [اسلایدهای طرح‌بندی](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/get_layoutslides/) مرور کنید و منطق مقیاس‌گذاری مشابه را بر روی اشکال آن‌ها اعمال کنید تا از انسجام در سراسر ارائه اطمینان حاصل شود.

### آیا می‌توانم جهت اسلاید (پرتره/لند اسکیپ) را همراه با تغییر اندازه تغییر دهم؟

بلی. می‌توانید از [presentation->get_SlideSize()->set_Orientation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/islidesize/set_orientation/) برای تغییر جهت استفاده کنید. اطمینان حاصل کنید که منطق مقیاس‌گذاری را به‌موقع تنظیم کنید تا طرح حفظ شود.

### آیا محدودیتی برای اندازه اسلایدی که می‌توانم تنظیم کنم وجود دارد؟

Aspose.Slides از اندازه‌های سفارشی پشتیبانی می‌کند، اما اندازه‌های بسیار بزرگ ممکن است بر عملکرد یا سازگاری با برخی نسخه‌های PowerPoint تأثیر بگذارند.

### چگونه می‌توانم از کشیده شدن اشکال با نسبت ثابت جلوگیری کنم؟

می‌توانید قبل از مقیاس‌گذاری، متد `get_AspectRatioLocked` اشکال را بررسی کنید. اگر قفل باشد، به جای مقیاس‌گذاری جداگانه، عرض یا ارتفاع را به‌صورت نسبی تنظیم کنید.