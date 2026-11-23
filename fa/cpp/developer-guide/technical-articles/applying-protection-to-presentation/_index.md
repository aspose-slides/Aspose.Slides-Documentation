---
title: محدود کردن ویرایش‌های ارائه با قفل‌های شکل در C++
linktitle: محدود کردن ویرایت‌های ارائه
type: docs
weight: 10
url: /fa/cpp/applying-protection-to-presentation/
keywords:
- جلوگیری از ویرایت
- محافظت در برابر ویرایت
- قفل کردن شکل
- قفل موقعیت
- قفل انتخاب
- قفل تغییر اندازه
- قفل گروه‌بندی
- PowerPoint
- PPTX
- ارائه
- C++
- Aspose.Slides
description: "یاد بگیرید چگونه اشکال را در ارائه‌های PPTX با Aspose.Slides برای C++ قفل و آزاد کنید تا انتخاب، جابجایی، تغییر اندازه و گروه‌بندی را محدود کنید."
---
## **پیش‌زمینه**

یک استفاده رایج از Aspose.Slides for C++ ایجاد، به‌روزرسانی و ذخیرهٔ ارائه‌های PowerPoint (PPTX) به عنوان بخشی از یک جریان کار خودکار است. هنگامی که کاربران این ارائه‌ها را دریافت می‌کنند، محدود کردن تغییرات در اشکال می‌تواند به حفظ چینش و محتوای مورد نظر کمک کند.

این مقاله توضیح می‌دهد که چگونه اشکال روی اسلایدها سازماندهی می‌شوند و چگونه قفل‌های اشکال را در یک ارائه PPTX اعمال و حذف کنید. این قفل‌ها به شما امکان می‌دهند عملیات ویرایشی خاصی را روی اشکال منفرد محدود کنید.

## **ترکیب یک اسلاید**

یک اسلاید ارائه از اجزائی مانند اشکال خودکار، جداول، اشیای OLE، اشکال گروه‌بندی‌شده، قاب‌های تصویر، قاب‌های ویدئو, اتصال‌ها و سایر عناصر استفاده‌شده برای ساخت یک ارائه تشکیل شده است. در Aspose.Slides for C++، هر عنصر روی یک اسلاید توسط شیئی نمایان می‌شود که رابط [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) را پیاده‌سازی می‌کند یا از کلاسی که این رابط را ارث می‌برد، مشتق شده است.

انواع مختلف اشکال گزینه‌های قفل‌گذاری متفاوتی را ارائه می‌دهند. رابط [IBaseShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseshapelock/) رابط پایه برای قفل‌های اشکال است. Aspose.Slides for C++ رابط‌های قفل زیر را فراهم می‌کند:

- [IAutoShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/) اشکال خودکار را قفل می‌کند.
- [IConnectorLock](https://reference.aspose.com/slides/cpp/aspose.slides/iconnectorlock/) اشکال کانکتور را قفل می‌کند.
- [IGraphicalObjectLock](https://reference.aspose.com/slides/cpp/aspose.slides/igraphicalobjectlock/) اشیای گرافیکی را قفل می‌کند.
- [IGroupShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshapelock/) اشکال گروهی را قفل می‌کند.
- [IPictureFrameLock](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframelock/) قاب‌های تصویر را قفل می‌کند.

برای اعمال قفل‌ها بر روی یک [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)، اسلایدهای آن را پیمایش کنید و قفل‌های مناسب را روی هر شکل پشتیبانی‌شده تنظیم کنید.

## **اعمال و حذف حفاظت**

ویرایشگرهای ارائه سازگار از قفل‌های اشکال برای محدود کردن عملیات ویرایشی جداگانه استفاده می‌کنند. رمزنگاری فایل و حفاظت نوشتاری سطح سند تنظیمات جداگانه‌ای تحت عنوان [تنظیمات حفاظت ارائه](/slides/fa/cpp/password-protected-presentation/) دارند.

### **اعمال حفاظت بر روی اشکال PPTX**

Aspose.Slides for C++ رابط [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) را برای کار با اشکال روی یک اسلاید فراهم می‌کند.

در مثال مقدار `true` به متدهای [set_SelectLocked](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/set_selectlocked/), [set_PositionLocked](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/set_positionlocked/), و [set_SizeLocked](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/set_sizelocked/) برای اشکال خودکار ارسال می‌شود، به‌طوری‌که قفل‌های معادل برای اشکال گروهی, کانکتورها و قاب‌های تصویر نیز اعمال می‌شوند. کانکتورها برای جابجایی از [set_PositionMove](https://reference.aspose.com/slides/cpp/aspose.slides/iconnectorlock/set_positionmove/) استفاده می‌کنند؛ گروه‌ها نیز از [set_GroupingLocked](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshapelock/set_groupinglocked/) برای محدود کردن گروه‌بندی استفاده می‌کنند.

مثال یک ارائه PPTX موجود را بارگذاری می‌کند، اشکال هر مجموعهٔ اشکال اسلاید را بررسی می‌کند و یک نسخه با این محدودیت‌ها ذخیره می‌کند. اشکالی که جزو چهار نوع پردازش شده نیستند بدون تغییر می‌مانند. این حلقه اشکال فرزندی داخل یک گروه را پیمایش نمی‌کند.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IAutoShapeLock.h>
#include <DOM/IConnector.h>
#include <DOM/IConnectorLock.h>
#include <DOM/IGroupShape.h>
#include <DOM/IGroupShapeLock.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IPictureFrameLock.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

for (auto&& slide : System::IterateOver(presentation->get_Slides()))
{
    for (auto&& shape : System::IterateOver(slide->get_Shapes()))
    {
        if (ObjectExt::Is<IAutoShape>(shape))
        {
            auto autoShape = ExplicitCast<IAutoShape>(shape);
            auto autoShapeLock = ExplicitCast<IAutoShapeLock>(autoShape->get_ShapeLock());

            autoShapeLock->set_PositionLocked(true);
            autoShapeLock->set_SelectLocked(true);
            autoShapeLock->set_SizeLocked(true);
        }
        else if (ObjectExt::Is<IGroupShape>(shape))
        {
            auto groupShape = ExplicitCast<IGroupShape>(shape);
            auto groupShapeLock = ExplicitCast<IGroupShapeLock>(groupShape->get_ShapeLock());

            groupShapeLock->set_GroupingLocked(true);
            groupShapeLock->set_PositionLocked(true);
            groupShapeLock->set_SelectLocked(true);
            groupShapeLock->set_SizeLocked(true);
        }
        else if (ObjectExt::Is<IConnector>(shape))
        {
            auto connectorShape = ExplicitCast<IConnector>(shape);
            auto connectorShapeLock = ExplicitCast<IConnectorLock>(connectorShape->get_ShapeLock());

            connectorShapeLock->set_PositionMove(true);
            connectorShapeLock->set_SelectLocked(true);
            connectorShapeLock->set_SizeLocked(true);
        }
        else if (ObjectExt::Is<IPictureFrame>(shape))
        {
            auto pictureFrame = ExplicitCast<IPictureFrame>(shape);
            auto pictureFrameLock = ExplicitCast<IPictureFrameLock>(pictureFrame->get_ShapeLock());

            pictureFrameLock->set_PositionLocked(true);
            pictureFrameLock->set_SelectLocked(true);
            pictureFrameLock->set_SizeLocked(true);
        }
    }
}

presentation->Save(u"ProtectedSample.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

### **حذف حفاظت**

برای حذف یک قفل شکل، مقدار آن را به `false` تنظیم کنید. مثال زیر یک ارائه با قفل‌های شکل را بارگذاری می‌کند و محدودیت‌های انتخاب، جابجایی و تغییر اندازه را از طریق [IAutoShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/), [IGroupShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshapelock/), [IConnectorLock](https://reference.aspose.com/slides/cpp/aspose.slides/iconnectorlock/), و [IPictureFrameLock](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframelock/) پاک می‌سازد. همچنین [IGroupShapeLock::set_GroupingLocked](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshapelock/set_groupinglocked/) را پاک می‌کند و یک نسخه از ارائه را ذخیره می‌نماید. تنظیمات قفل دیگر بدون تغییر می‌مانند.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IAutoShapeLock.h>
#include <DOM/IConnector.h>
#include <DOM/IConnectorLock.h>
#include <DOM/IGroupShape.h>
#include <DOM/IGroupShapeLock.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IPictureFrameLock.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"ProtectedSample.pptx");

for (auto&& slide : System::IterateOver(presentation->get_Slides()))
{
    for (auto&& shape : System::IterateOver(slide->get_Shapes()))
    {
        if (ObjectExt::Is<IAutoShape>(shape))
        {
            auto autoShape = ExplicitCast<IAutoShape>(shape);
            auto autoShapeLock = ExplicitCast<IAutoShapeLock>(autoShape->get_ShapeLock());

            autoShapeLock->set_PositionLocked(false);
            autoShapeLock->set_SelectLocked(false);
            autoShapeLock->set_SizeLocked(false);
        }
        else if (ObjectExt::Is<IGroupShape>(shape))
        {
            auto groupShape = ExplicitCast<IGroupShape>(shape);
            auto groupShapeLock = ExplicitCast<IGroupShapeLock>(groupShape->get_ShapeLock());

            groupShapeLock->set_GroupingLocked(false);
            groupShapeLock->set_PositionLocked(false);
            groupShapeLock->set_SelectLocked(false);
            groupShapeLock->set_SizeLocked(false);
        }
        else if (ObjectExt::Is<IConnector>(shape))
        {
            auto connectorShape = ExplicitCast<IConnector>(shape);
            auto connectorShapeLock = ExplicitCast<IConnectorLock>(connectorShape->get_ShapeLock());

            connectorShapeLock->set_PositionMove(false);
            connectorShapeLock->set_SelectLocked(false);
            connectorShapeLock->set_SizeLocked(false);
        }
        else if (ObjectExt::Is<IPictureFrame>(shape))
        {
            auto pictureFrame = ExplicitCast<IPictureFrame>(shape);
            auto pictureFrameLock = ExplicitCast<IPictureFrameLock>(pictureFrame->get_ShapeLock());

            pictureFrameLock->set_PositionLocked(false);
            pictureFrameLock->set_SelectLocked(false);
            pictureFrameLock->set_SizeLocked(false);
        }
    }
}

presentation->Save(u"RemovedProtectionSample.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

### **حفظ برش تصویر**

یک تصویر با نام `photo.jpg` را در پوشهٔ کاری قرار دهید. مثال ۱۲٪ از سمت چپ و ۸٪ از سمت راست را برش می‌دهد، سپس متد [set_CropLocked](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframelock/set_croplocked/) را بر روی قفل قاب تصویر فراخوانی می‌کند تا برش حفظ شود و برش‌های بعدی محدود شوند.

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IPictureFrameLock.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto shapes = presentation->get_Slide(0)->get_Shapes();

auto photoBytes = File::ReadAllBytes(u"photo.jpg");
auto photo = presentation->get_Images()->AddImage(photoBytes);

auto pictureFrame = shapes->AddPictureFrame(ShapeType::Rectangle, 20, 30, 270, 160, photo);
auto pictureFormat = pictureFrame->get_PictureFormat();
pictureFormat->set_CropLeft(12);
pictureFormat->set_CropRight(8);

auto pictureFrameLock = pictureFrame->get_PictureFrameLock();
pictureFrameLock->set_AspectRatioLocked(false);
pictureFrameLock->set_CropLocked(true);

presentation->Save(u"PictureLocked.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

`PictureLocked.pptx` قفل برش را به مقدار `true` ذخیره می‌کند. در PowerPoint، فرمان **Crop** هنگام انتخاب تصویر غیرفعال است.

### **نگهداری گروه‌بندی نمودار**

مثال یک مستطیل و یک پیکان را گروه می‌کند، سپس متد [set_UngroupingLocked](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshapelock/set_ungroupinglocked/) را بر روی قفل گروه فراخوانی می‌کند تا اجزای نمودار با هم باقی بمانند. ویرایش‌های دیگر، مانند جابجایی گروه یا تغییر رنگ پرکردن یک جزء، همچنان قابل استفاده هستند.

```cpp
#include <DOM/IGroupShape.h>
#include <DOM/IGroupShapeLock.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto shapes = presentation->get_Slide(0)->get_Shapes();

auto groupShape = shapes->AddGroupShape();
auto groupShapes = groupShape->get_Shapes();
groupShapes->AddAutoShape(ShapeType::Rectangle, 100, 70, 90, 50);
groupShapes->AddAutoShape(ShapeType::RightArrow, 190, 80, 60, 30);
groupShape->get_GroupShapeLock()->set_UngroupingLocked(true);

presentation->Save(u"DiagramLocked.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

`DiagramLocked.pptx` قفل جداسازی را به مقدار `true` ذخیره می‌کند. در PowerPoint، فرمان **Ungroup** هنگام انتخاب تمام نمودار غیرفعال است.

### **نتیجه‌گیری**

Aspose.Slides for C++ به شما امکان می‌دهد عملیات ویرایشی خاصی را روی اشکال منفرد محدود کنید یا همان محدودیت‌ها را بر روی اسلایدهای مختلف اعمال کنید. قفل‌های پشتیبانی‌شده توسط هر نوع شکل را انتخاب کنید و مقادیر آن‌ها را به `false` تنظیم کنید هنگامی که نیاز به حذف این محدودیت‌ها دارید.

## **سوالات متداول**

**آیا می‌توانم قفل‌های شکل و حفاظت با رمز عبور را در یک ارائه ترکیب کنم؟**

بله. قفل‌های شکل عملیات ویرایشی خاصی را محدود می‌کنند، در حالی که [حفاظت با رمز عبور](/slides/fa/cpp/password-protected-presentation/) می‌تواند باز کردن یا ویرایش ارائه را محدود کند. می‌توانید هر دو را در یک فایل استفاده کنید.

**آیا می‌توانم ویرایش را بر روی اسلایدهای خاص محدود کنم بدون اینکه بر سایر اسلایدها تأثیر بگذارد؟**

بله. قفل‌ها را فقط بر روی اشکال اسلایدهای انتخابی اعمال کنید. این کار تنظیمات قفل را بر روی اسلایدهای دیگر تغییر نمی‌دهد.

**چگونه می‌توانم قفل‌ها را بر روی اشکال منفرد داخل یک گروه اعمال کنم؟**

از مجموعه‌ای که توسط متد [get_Shapes](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshape/get_shapes/) گروه برگردانده می‌شود عبور کنید و قفل‌های مناسب را بر هر شکل فرزند اعمال کنید. این کار را برای هر گروه تو در تو تکرار کنید. مثال‌های فوق تنها مجموعهٔ اشکال اسلاید را پردازش می‌کنند، بنابراین قفل‌ها را بر روی اعضای منفرد گروه تنظیم نمی‌کنند.