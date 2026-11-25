---
title: محدود کردن ویرایش‌های ارائه با قفل‌های شکل در C++
linktitle: محدود کردن ویرایش‌های ارائه
type: docs
weight: 10
url: /fa/cpp/applying-protection-to-presentation/
keywords:
- جلوگیری از ویرایش
- حفاظت در برابر ویرایش
- قفل کردن شکل
- قفل کردن موقعیت
- قفل کردن انتخاب
- قفل کردن تغییر اندازه
- قفل کردن گروه‌بندی
- PowerPoint
- PPTX
- ارائه
- C++
- Aspose.Slides
description: "یاد بگیرید چگونه با Aspose.Slides برای C++ اشکال را در ارائه‌های PPTX قفل و بازقفل کنید تا انتخاب، حرکت، تغییر اندازه و گروه‌بندی محدود شوند."
---
## **پیش‌زمینه**

یک استفاده رایج از Aspose.Slides برای C++ ایجاد، به‌روزرسانی و ذخیره ارائه‌های PowerPoint (PPTX) به عنوان بخشی از یک جریان کار خودکار است. وقتی کاربران این ارائه‌ها را دریافت می‌کنند، محدود کردن تغییرات روی اشکال می‌تواند به حفظ چیدمان و محتوای مورد نظر کمک کند.

این مقاله توضیح می‌دهد که اشکال چگونه در اسلایدها سازماندهی می‌شوند و چگونه می‌توان قفل‌های اشکال را در یک ارائه PPTX اعمال و حذف کرد. این قفل‌ها به شما امکان می‌دهند عملیات ویرایشی خاصی را روی هر شکل محدود کنید.

## **ساختار یک اسلاید**

یک اسلاید ارائه شامل اجزایی مانند اشکال خودکار، جدول‌ها، اشیاء OLE، اشکال گروهی، چارچوب‌های تصویر، چارچوب‌های ویدیو، اتصالات و عناصر دیگر برای ساخت ارائه است. در Aspose.Slides برای C++، هر عنصر روی اسلاید توسط شیئی که رابط [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) را پیاده‌سازی می‌کند یا از کلاسی که از آن ارث می‌برد، نشان داده می‌شود.

انواع مختلف اشکال گزینه‌های قفل‌گذاری متفاوتی ارائه می‌دهند. رابط [IBaseShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseshapelock/) پایه‌ای برای قفل‌های اشکال است. Aspose.Slides برای C++ رابط‌های قفل زیر را ارائه می‌دهد:

- [IAutoShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/) اشکال خودکار را قفل می‌کند.
- [IConnectorLock](https://reference.aspose.com/slides/cpp/aspose.slides/iconnectorlock/) اشکال اتصال را قفل می‌کند.
- [IGraphicalObjectLock](https://reference.aspose.com/slides/cpp/aspose.slides/igraphicalobjectlock/) اشیاء گرافیکی را قفل می‌کند.
- [IGroupShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshapelock/) اشکال گروهی را قفل می‌کند.
- [IPictureFrameLock](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframelock/) چارچوب‌های تصویر را قفل می‌کند.

برای اعمال قفل‌ها بر روی یک [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)، اسلایدهای آن را مرور کرده و قفل‌های مناسب را روی هر شکل پشتیبانی‌شده تنظیم کنید.

## **اعمال و حذف محافظت**

ویرایشگرهای ارائه سازگار از قفل‌های اشکال برای محدود کردن عملیات ویرایشی فردی استفاده می‌کنند. رمزنگاری فایل و محافظت نوشتاری در سطح سند تنظیمات جداگانه‌ای برای [presentation protection settings](/slides/fa/cpp/password-protected-presentation/) دارند.

### **اعمال محافظت بر روی اشکال PPTX**

Aspose.Slides برای C++ رابط [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) را برای کار با اشکال روی یک اسلاید فراهم می‌کند.

در مثال مقدار `true` به متدهای [set_SelectLocked](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/set_selectlocked/)، [set_PositionLocked](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/set_positionlocked/) و [set_SizeLocked](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/set_sizelocked/) برای اشکال خودکار پاس می‌شود و قفل‌های معادل برای اشکال گروهی، اتصالات و چارچوب‌های تصویر اعمال می‌شود. برای اتصالات از [set_PositionMove](https://reference.aspose.com/slides/cpp/aspose.slides/iconnectorlock/set_positionmove/) برای حرکت استفاده می‌شود؛ گروه‌ها نیز از [set_GroupingLocked](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshapelock/set_groupinglocked/) برای محدود کردن گروه‌بندی بهره می‌برند.

مثال یک ارائه PPTX موجود را بارگذاری می‌کند، اشکال موجود در مجموعه اشکال هر اسلاید را بررسی می‌کند و یک کپی با این محدودیت‌ها ذخیره می‌کند. اشکالی که در چهار نوع مدیریت‌شده نیستند تغییر نمی‌کنند. حلقه اشکال فرزند داخل یک گروه را پیمایش نمی‌کند.

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

### **حذف محافظت**

برای حذف قفل یک شکل، مقدار آن را به `false` تنظیم کنید. مثال زیر یک ارائه با قفل‌های اشکال را بارگذاری می‌کند و محدودیت‌های انتخاب، حرکت و تغییر اندازه را با استفاده از [IAutoShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/)، [IGroupShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshapelock/)، [IConnectorLock](https://reference.aspose.com/slides/cpp/aspose.slides/iconnectorlock/) و [IPictureFrameLock](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframelock/) پاک می‌سازد. همچنین [IGroupShapeLock::set_GroupingLocked](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshapelock/set_groupinglocked/) را پاک کرده و یک کپی از ارائه را ذخیره می‌کند. سایر تنظیمات قفل بدون تغییر می‌مانند.

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

یک عکس به نام `photo.jpg` را در پوشه کاری قرار دهید. مثال 12٪ از سمت چپ و 8٪ از سمت راست را برش می‌دهد، سپس با فراخوانی [set_CropLocked](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframelock/set_croplocked/) بر روی قفل چارچوب تصویر، برش را محافظت کرده و از برش بیشتر جلوگیری می‌کند.

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

فایل `PictureLocked.pptx` مقدار قفل برش را به `true` ذخیره می‌کند. در PowerPoint، فرمان **Crop** وقتی عکس انتخاب شده باشد غیرفعال است.

### **نگهداری گروه‌بندی دیاگرام**

مثال یک مستطیل و یک پیکان را گروه‌بندی می‌کند، سپس با فراخوانی [set_UngroupingLocked](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshapelock/set_ungroupinglocked/) بر روی قفل گروه، اجزای دیاگرام را به‌هم متصل نگه می‌دارد. سایر ویرایش‌ها مانند جابه‌جایی گروه یا تغییر پر کردن یک جزء همچنان در دسترس هستند.

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

فایل `DiagramLocked.pptx` مقدار قفل جداسازی را به `true` ذخیره می‌کند. در PowerPoint، فرمان **Ungroup** وقتی تمام دیاگرام انتخاب شده باشد غیرفعال می‌شود.

### **گزارش قفل‌های اشکال موجود**

برای بررسی یک الگو، آن را باز کنید و شیء قفل هر شکل را بخوانید. متد [get_NoLocks](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseshapelock/get_nolocks/) زمانی که همه پرچم‌های شیء `true` باشند `true` و وقتی حداقل یک پرچم فعال باشد `false` برمی‌گرداند. یک گروه و فرزندان آن اشیای قفل جداگانه دارند، بنابراین حتی زمانی که گروه قفل نداشته باشد، باید فرزندان را بررسی کنید.

این مثال حرکت اشکال خودکار، چارچوب‌های تصویر و گروه‌ها، برش برای تصاویر و جداسازی برای گروه‌ها را بررسی می‌کند. پرچم‌هایی که شناسایی می‌کند گزارش می‌دهد و انواع اشکالی که بررسی نمی‌کند را علامت‌گذاری می‌کند.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IAutoShapeLock.h>
#include <DOM/IGroupShape.h>
#include <DOM/IGroupShapeLock.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IPictureFrameLock.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/collections/list.h>
#include <system/console.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
#include <functional>

using namespace Aspose::Slides;
using namespace System;
using namespace System::Collections::Generic;

std::function<void(SharedPtr<IShapeCollection>, int, String)> inspect;
inspect = [&inspect](SharedPtr<IShapeCollection> shapes, int slideNumber, String prefix)
{
    for (auto&& shape : IterateOver(shapes))
    {
        auto path = prefix + shape->get_Name();
        auto label = String::Format(u"Slide {0} | {1} | {2}", slideNumber, path, shape->GetType().get_Name());
        auto flags = MakeObject<List<String>>();
        auto group = AsCast<IGroupShape>(shape);

        if (group)
        {
            auto locks = group->get_GroupShapeLock();
            if (locks->get_UngroupingLocked()) flags->Add(u"UngroupingLocked");
            if (locks->get_PositionLocked()) flags->Add(u"PositionLocked");
        }
        else if (auto picture = AsCast<IPictureFrame>(shape))
        {
            auto locks = picture->get_PictureFrameLock();
            if (locks->get_CropLocked()) flags->Add(u"CropLocked");
            if (locks->get_PositionLocked()) flags->Add(u"PositionLocked");
        }
        else if (auto autoShape = AsCast<IAutoShape>(shape))
        {
            if (autoShape->get_AutoShapeLock()->get_PositionLocked()) flags->Add(u"PositionLocked");
        }
        else
        {
            Console::WriteLine(label + u" | Uninspected");
            continue;
        }

        if (!shape->get_ShapeLock()->get_NoLocks())
        {
            auto restrictions = flags->get_Count() ? String::Join(u", ", flags->ToArray()) : String(u"Active flag not identified");
            Console::WriteLine(label + u" | " + restrictions);
        }

        if (group)
            inspect(group->get_Shapes(), slideNumber, path + u"/");
    }
};

auto presentation = MakeObject<Presentation>(u"Sample.pptx");
for (auto&& slide : IterateOver(presentation->get_Slides()))
{
    inspect(slide->get_Shapes(), slide->get_SlideNumber(), u"");
}
presentation->Dispose();
```

فرض کنید اسلاید 1 از `Sample.pptx` شامل یک گروه به نام `Layout` با قفل جداسازی، عکسی به نام `Photo` داخل آن با قفل برش، و یک مستطیل بدون قفل به نام `Free` باشد. گزارش `Free` را نادیده می‌گیرد و این دو خط را چاپ می‌کند:

```text
Slide 1 | Layout | GroupShape | UngroupingLocked
Slide 1 | Layout/Photo | PictureFrame | CropLocked
```

گزارش پرچم‌های سطح شکل ذخیره‌شده را می‌خواند بدون اینکه آن‌ها را تغییر دهد یا ارائه را ذخیره کند. محافظت نوشتاری در سطح سند تنظیم جداگانه‌ای است و اعمال هر پرچم به ویرایشگر بستگی دارد.

### **نتیجه‌گیری**

Aspose.Slides برای C++ به شما امکان می‌دهد عملیات ویرایشی خاصی را روی اشکال فردی محدود کنید یا همان محدودیت‌ها را بر روی اسلایدهای مختلف اعمال کنید. قفل‌های پشتیبانی‌شده توسط هر نوع شکل را انتخاب کنید و مقادیر آن‌ها را به `false` تنظیم نمایید وقتی نیاز به حذف این محدودیت‌ها دارید.

## **سوالات متداول**

**آیا می‌توانم قفل‌های اشکال و حفاظت با رمز عبور را در همان ارائه ترکیب کنم؟**

بله. قفل‌های اشکال عملیات ویرایشی خاصی را محدود می‌کنند، در حالی که [password protection](/slides/fa/cpp/password-protected-presentation/) می‌تواند باز کردن یا تغییر ارائه را محدود کند. می‌توانید هر دو را در یک فایل استفاده کنید.

**آیا می‌توانم ویرایش را فقط روی اسلایدهای خاصی محدود کنم بدون اینکه بر دیگر اسلایدها تأثیر بگذارد؟**

بله. قفل‌ها را فقط روی اشکال اسلایدهای منتخب اعمال کنید. این کار تنظیمات قفل روی اسلایدهای دیگر را تغییر نمی‌دهد.

**چگونه می‌توانم قفل‌ها را روی اشکال فردی داخل یک گروه اعمال کنم؟**

در مجموعه‌ای که توسط متد [get_Shapes](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshape/get_shapes/) گروه برگردانده شده است پیمایش کنید و قفل‌های مناسب را روی هر شکل فرزند اعمال کنید. این کار را برای هر گروه تو در توی دیگری تکرار کنید، همان‌طور که در مثال گزارش‌گیری آمده است.