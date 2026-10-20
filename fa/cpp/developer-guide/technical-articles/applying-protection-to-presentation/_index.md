---
title: محدود کردن ویرایش‌های ارائه با قفل‌گذاری شکل‌ها در C++
linktitle: محدود کردن ویرایش‌های ارائه
type: docs
weight: 10
url: /fa/cpp/applying-protection-to-presentation/
keywords:
- جلوگیری از ویرایش
- حفاظت در برابر ویرایش
- قفل شکل
- قفل موقعیت
- قفل انتخاب
- قفل تغییر اندازه
- قفل گروه‌بندی
- PowerPoint
- PPTX
- ارائه
- C++
- Aspose.Slides
description: "یاد بگیرید چگونه شکل‌ها را در ارائه‌های PPTX با Aspose.Slides برای C++ قفل و بازقفل کنید تا انتخاب، جابه‌جایی، تغییر اندازه و گروه‌بندی را محدود کنید."
---
## **پیش‌زمینه**

یک استفاده رایج از Aspose.Slides برای C++ ایجاد، به‌روزرسانی و ذخیره ارائه‌های PowerPoint (PPTX) به عنوان بخشی از یک جریان کاری خودکار است. وقتی کاربران این ارائه‌ها را دریافت می‌کنند، محدود کردن تغییرات شکل‌ها می‌تواند به حفظ طرح و محتوای مورد نظر کمک کند.

این مقاله توضیح می‌دهد که شکل‌ها چگونه در اسلایدها سازماندهی می‌شوند و چگونه می‌توانید قفل‌های شکل را در یک ارائه PPTX اعمال و حذف کنید. این قفل‌ها به شما اجازه می‌دهند عملیات ویرایشی خاصی را روی هر شکل به‌صورت جداگانه محدود کنید.

## **ترکیب اسلاید**

یک اسلاید ارائه از اجزایی مانند اشکال خودکار، جداول، اشیای OLE، اشکال گروه‌بندی‌شده، فریم‌های تصویر، فریم‌های ویدئو، اتصال‌دهنده‌ها و سایر عناصر مورد استفاده برای ساخت یک ارائه تشکیل شده است. در Aspose.Slides برای C++، هر عنصر در یک اسلاید با شیئی نمایان می‌شود که رابط [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) را پیاده‌سازی می‌کند یا از کلاسی که این رابط را ارث‌بری کرده است، مشتق شده است.

انواع مختلف شکل‌ها گزینه‌های قفل‌گذاری متفاوتی ارائه می‌دهند. رابط [IBaseShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseshapelock/) رابط پایه برای قفل‌های شکل است. Aspose.Slides برای C++ رابط‌های قفل زیر را فراهم می‌کند:

- [IAutoShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/) قفل‌گذاری بر اشکال خودکار.
- [IConnectorLock](https://reference.aspose.com/slides/cpp/aspose.slides/iconnectorlock/) قفل‌گذاری بر اشکال اتصال‌دهنده.
- [IGraphicalObjectLock](https://reference.aspose.com/slides/cpp/aspose.slides/igraphicalobjectlock/) قفل‌گذاری بر اشیای گرافیکی.
- [IGroupShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshapelock/) قفل‌گذاری بر اشکال گروهی.
- [IPictureFrameLock](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframelock/) قفل‌گذاری بر فریم‌های تصویر.

برای اعمال قفل‌ها به یک [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)، اسلایدهای آن را پیمایش کنید و قفل‌های مناسب را بر هر شکل پشتیبانی‌شده تنظیم کنید.

## **اعمال و حذف حفاظت**

قفل‌های شکل عملیات‌هایی مانند انتخاب، جابه‌جایی و تغییر اندازه شکل‌ها را محدود می‌کنند. آنها کل ارائه را غیرقابل ویرایش نمی‌سازند.

### **اعمال حفاظت بر اشکال PPTX**

Aspose.Slides برای C++ رابط [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) را برای کار با شکل‌ها در یک اسلاید فراهم می‌کند.

در مثال مقدار `true` به متدهای [set_SelectLocked](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/set_selectlocked/)، [set_PositionLocked](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/set_positionlocked/) و [set_SizeLocked](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/set_sizelocked/) برای اشکال خودکار ارسال می‌شود، با قفل‌های معادل برای اشکال گروهی، اتصال‌دهنده‌ها و فریم‌های تصویر. برای جابه‌جایی، اتصال‌دهنده‌ها از [set_PositionMove](https://reference.aspose.com/slides/cpp/aspose.slides/iconnectorlock/set_positionmove/) استفاده می‌کنند؛ گروه‌ها همچنین از [set_GroupingLocked](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshapelock/set_groupinglocked/) برای محدود کردن گروه‌بندی استفاده می‌کنند.

مثال یک ارائه PPTX موجود را بارگذاری می‌کند، شکل‌های موجود در مجموعهٔ شکل‌های هر اسلاید را بررسی می‌کند و یک کپی با این محدودیت‌ها ذخیره می‌نماید. شکل‌هایی که جزو چهار نوع پشتیبانی‌شده نیستند بدون تغییر باقی می‌مانند. حلقهٔ پیمایش اشکال فرزند داخل یک گروه را در نظر نمی‌گیرد.

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

برای حذف یک قفل شکل، مقدار آن را به `false` تنظیم کنید. مثال زیر یک ارائه با قفل‌های شکل را بارگذاری می‌کند و محدودیت‌های انتخاب، جابه‌جایی و تغییر اندازه را از طریق [IAutoShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/)، [IGroupShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshapelock/)، [IConnectorLock](https://reference.aspose.com/slides/cpp/aspose.slides/iconnectorlock/) و [IPictureFrameLock](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframelock/) پاک می‌سازد. همچنین [IGroupShapeLock::set_GroupingLocked](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshapelock/set_groupinglocked/) را پاک کرده و یک کپی از ارائه را ذخیره می‌کند. سایر تنظیمات قفل بدون تغییر باقی می‌مانند.

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

### **نتیجه‌گیری**

Aspose.Slides برای C++ به شما امکان می‌دهد عملیات‌های ویرایشی خاص را بر شکل‌های فردی محدود کنید یا همان محدودیت‌ها را بر روی اسلایدهای متعدد اعمال کنید. قفل‌های پشتیبانی‌شده توسط هر نوع شکل را انتخاب کنید و مقادیر آن‌ها را به `false` تنظیم کنید زمانی که نیاز به حذف این محدودیت‌ها دارید.

## **پرسش‌های متداول**

**آیا می‌توانم قفل‌های شکل و حفاظت با رمز عبور را در یک ارائه ترکیب کنم؟**

بله. قفل‌های شکل عملیات‌های ویرایشی خاص را محدود می‌کنند، در حالی که [password protection](/slides/fa/cpp/password-protected-presentation/) می‌تواند باز کردن یا تغییر ارائه را محدود کند. می‌توانید هر دو را در یک فایل استفاده کنید.

**آیا می‌توانم ویرایش را بر اسلایدهای خاص محدود کنم بدون اینکه بر دیگران تأثیر بگذارد؟**

بله. قفل‌ها را فقط بر شکل‌های اسلایدهای منتخب اعمال کنید. این کار تنظیمات قفل را در اسلایدهای دیگر تغییر نمی‌دهد.

**چگونه می‌توانم قفل‌ها را بر اشکال فردی داخل یک گروه اعمال کنم؟**

از مجموعه‌ای که توسط متد [get_Shapes](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshape/get_shapes/) گروه برگردانده می‌شود، پیمایش کنید و قفل‌های مناسب را بر هر شکل فرزند اعمال کنید. این کار را برای هر گروه تو در تو تکرار کنید. مثال‌های بالا فقط مجموعهٔ شکل‌های اسلاید را پردازش می‌کنند، لذا قفل‌ها را بر اعضای فردی گروه تنظیم نمی‌کنند.