---
title: مدیریت SmartArt در ارائه‌های PowerPoint با استفاده از C++
linktitle: مدیریت SmartArt
type: docs
weight: 10
url: /fa/cpp/manage-smartart/
keywords:
- SmartArt
- متن SmartArt
- نوع طرح
- ویژگی مخفی
- نمودار سازمانی
- نمودار سازمانی تصویری
- PowerPoint
- ارائه
- C++
- Aspose.Slides
description: "یاد بگیرید چگونه SmartArt PowerPoint را با Aspose.Slides برای C++ بسازید و ویرایش کنید با استفاده از نمونه‌های کد واضح که طراحی اسلاید و خودکارسازی را تسریع می‌کنند."
---
## **نمای کلی**

SmartArt یک نمودار PowerPoint است که از گره‌ها، اشکال گره و یک طرح ساخته شده است. با Aspose.Slides برای C++ می‌توانید SmartArt را ایجاد کنید، متن را از گره‌های آن بخوانید، طرح آن را تغییر دهید، گره‌های مخفی را بررسی کنید، طرح‌های نمودار سازمانی را پیکربندی کنید و نمودارهای سازمانی تصویری ایجاد کنید.

## **دریافت متن از یک شیء SmartArt**

یک گره SmartArt می‌تواند یک یا چند شکل را شامل شود. برای خواندن متن از اشکال گره، از [ISmartArt::get_AllNodes](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/ismartart/get_allnodes/) عبور کنید، سپس [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) بازگردانده شده توسط [ISmartArtShape::get_TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/ismartartshape/get_textframe/) را بخوانید.

این مثال به یک ارائه با حداقل یک اسلاید و یک شیء SmartArt به عنوان اولین شکل در آن اسلاید نیاز دارد. هر قاب متن موجود را در کنسول چاپ می‌کند.

```cpp
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/SmartArt/ISmartArt.h>
#include <DOM/SmartArt/ISmartArtNode.h>
#include <DOM/SmartArt/ISmartArtNodeCollection.h>
#include <DOM/SmartArt/ISmartArtShape.h>
#include <DOM/SmartArt/ISmartArtShapeCollection.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::SmartArt;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

auto smartArt = ExplicitCast<ISmartArt>(slide->get_Shape(0));
for (auto nodeIndex = 0; nodeIndex < smartArt->get_AllNodes()->get_Count(); nodeIndex++)
{
    auto node = smartArt->get_AllNodes()->idx_get(nodeIndex);
    for (auto shapeIndex = 0; shapeIndex < node->get_Shapes()->get_Count(); shapeIndex++)
    {
        auto nodeShape = node->get_Shape(shapeIndex);
        if (nodeShape->get_TextFrame() != nullptr)
        {
            Console::WriteLine(nodeShape->get_TextFrame()->get_Text());
        }
    }
}

presentation->Dispose();
```

## **تغییر نوع طرح یک شیء SmartArt**

طرح SmartArt نحوه ترتیب و اتصال گره‌ها را کنترل می‌کند. مثال زیر یک شیء SmartArt را با مقدار [SmartArtLayoutType](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/smartartlayouttype/) `BasicBlockList` ایجاد می‌کند، آن را به مقدار `BasicProcess` تغییر می‌دهد و ارائه را ذخیره می‌کند. موقعیت و اندازه‌ای که به [IShapeCollection::AddSmartArt](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addsmartart/) می‌رسد بر حسب نقطه اندازه‌گیری می‌شود. برای تغییر طرح از [ISmartArt::set_Layout](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/ismartart/set_layout/) استفاده کنید.

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/SmartArt/ISmartArt.h>
#include <DOM/SmartArt/SmartArtLayoutType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SmartArt;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

auto smartArt = slide->get_Shapes()->AddSmartArt(10.0f, 10.0f, 400.0f, 300.0f, SmartArtLayoutType::BasicBlockList);
smartArt->set_Layout(SmartArtLayoutType::BasicProcess);

presentation->Save(u"ChangeSmartArtLayout.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **بررسی اینکه آیا یک گره SmartArt مخفی است**

[ISmartArtNode::get_IsHidden](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/ismartartnode/get_ishidden/) نشان می‌دهد که آیا گره در مدل داده‌ای SmartArt مخفی است یا نه. گره‌های مخفی می‌توانند در ساختار وجود داشته باشند حتی زمانی که طرح انتخاب شده آن‌ها را به عنوان عناصر نمودار قابل مشاهده نمایش نمی‌دهد.

مثال زیر یک گره به شیء SmartArt که از مقدار [SmartArtLayoutType](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/smartartlayouttype/) `RadialCycle` استفاده می‌کند اضافه می‌کند و وضعیت مخفی بودن گره اضافه شده را بررسی می‌نماید. اگر گره مخفی باشد پیامی چاپ می‌کند و نمودار را ذخیره می‌کند.

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/SmartArt/ISmartArt.h>
#include <DOM/SmartArt/ISmartArtNode.h>
#include <DOM/SmartArt/ISmartArtNodeCollection.h>
#include <DOM/SmartArt/SmartArtLayoutType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SmartArt;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

auto smartArt = slide->get_Shapes()->AddSmartArt(10.0f, 10.0f, 400.0f, 300.0f, SmartArtLayoutType::RadialCycle);
auto node = smartArt->get_AllNodes()->AddNode();
auto isHidden = node->get_IsHidden();

if (isHidden)
{
    Console::WriteLine(u"The node is hidden in the SmartArt data model.");
}

presentation->Save(u"CheckSmartArtHiddenProperty.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **دریافت یا تنظیم طرح نمودار سازمانی**

برای نمودارهای SmartArt که از طرح نمودار سازمانی استفاده می‌کنند، [ISmartArtNode::get_OrganizationChartLayout](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/ismartartnode/get_organizationchartlayout/) و [ISmartArtNode::set_OrganizationChartLayout](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/ismartartnode/set_organizationchartlayout/) نحوه چیدمان گره‌های فرزند زیر یک گره والد را تعریف می‌کنند. به عنوان مثال، می‌توانید گره‌های فرزند را طوری تنظیم کنید که از چپ، راست یا هر دو سمت آویزان شوند، بسته به [OrganizationChartLayoutType](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/organizationchartlayouttype/) انتخاب شده.

مثال زیر یک نمودار سازمانی ایجاد می‌کند و طرح گره اول را به مقدار [OrganizationChartLayoutType](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/organizationchartlayouttype/) `LeftHanging` تنظیم می‌نماید. ایندکس صفر مبنا `0` گره سطح بالای اول را انتخاب می‌کند؛ گره‌های فرزند آن از ترتیب انتخاب شده استفاده می‌کنند. سپس ارائه اصلاح‌شده ذخیره می‌شود.

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/SmartArt/ISmartArt.h>
#include <DOM/SmartArt/ISmartArtNode.h>
#include <DOM/SmartArt/OrganizationChartLayoutType.h>
#include <DOM/SmartArt/SmartArtLayoutType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SmartArt;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

auto smartArt = slide->get_Shapes()->AddSmartArt(10.0f, 10.0f, 400.0f, 300.0f, SmartArtLayoutType::OrganizationChart);
auto rootNode = smartArt->get_Node(0);
rootNode->set_OrganizationChartLayout(OrganizationChartLayoutType::LeftHanging);

presentation->Save(u"OrganizationChartLayout.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **ایجاد نمودار سازمانی تصویری**

نمودار سازمانی تصویری یک طرح SmartArt است که برای نمودارهای سلسله مراتبی شامل جای‌دارهای تصویر طراحی شده است. هنگام افزودن شیء SmartArt به اسلاید از مقدار [SmartArtLayoutType](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/smartartlayouttype/) `PictureOrganizationChart` استفاده کنید. این مثال یک نمودار با جای‌دارهای تصویر ذخیره می‌کند؛ جای‌دارها با تصاویر پر نمی‌شوند.

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/SmartArt/SmartArtLayoutType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SmartArt;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

auto smartArt = slide->get_Shapes()->AddSmartArt(0.0f, 0.0f, 400.0f, 400.0f, SmartArtLayoutType::PictureOrganizationChart);

presentation->Save(u"PictureOrganizationChart.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **تبدیل نمودارهای قدیمی به گروهی از اشکال**

هنگام به‌روزرسانی یک ارائه موجود، ممکن است نیاز داشته باشید نمودار سازمانی که ابتدا در PowerPoint 97–2003 ایجاد شده بود را به‌روز کنید. Aspose.Slides این نمودارهای قدیمی را به عنوان اشیاء [ILegacyDiagram](https://reference.aspose.com/slides/cpp/aspose.slides/ilegacydiagram/) نمایش می‌دهد. برای تبدیل یک نمودار به گروهی از اشکال از [ILegacyDiagram::ConvertToGroupShape](https://reference.aspose.com/slides/cpp/aspose.slides/ilegacydiagram/converttogroupshape/) استفاده کنید تا بتوانید عناصر تصویری جداگانه را ویرایش کنید. برای جزئیات، به [LegacyDiagram API Reference](https://reference.aspose.com/slides/cpp/aspose.slides/legacydiagram/) مراجعه کنید.

تبدیل یک گروه جدید به مجموعه اشکال اضافه می‌کند بدون اینکه نمودار اصلی حذف شود. پس از تبدیل موفق، برای جلوگیری از محتوای تکراری، اصل را با [IShapeCollection::Remove](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/remove/) حذف کنید. قبل از تبدیل، نمودارهای قدیمی را در یک بردار جمع‌آوری کنید تا افزودن و حذف اشکال باعث اختلال در تکرار نشود.

مثال زیر یک ارائه را باز می‌کند، هر اسلاید را جستجو می‌کند، نمودارها را به گروهی از اشکال تبدیل می‌نماید و ارائه به‌روزشده را به صورت PPTX ذخیره می‌کند.

```cpp
#include <DOM/ILegacyDiagram.h>
#include <DOM/IGroupShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <vector>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"legacy-diagrams.ppt");

for (auto slideIndex = 0; slideIndex < presentation->get_Slides()->get_Count(); slideIndex++)
{
    auto slide = presentation->get_Slide(slideIndex);
    std::vector<SharedPtr<ILegacyDiagram>> legacyDiagrams;

    for (auto shapeIndex = 0; shapeIndex < slide->get_Shapes()->get_Count(); shapeIndex++)
    {
        auto shape = slide->get_Shape(shapeIndex);
        if (ObjectExt::Is<ILegacyDiagram>(shape))
        {
            auto legacyDiagram = ExplicitCast<ILegacyDiagram>(shape);
            legacyDiagrams.push_back(legacyDiagram);
        }
    }

    for (auto legacyDiagram : legacyDiagrams)
    {
        auto groupShape = legacyDiagram->ConvertToGroupShape();

        if (groupShape != nullptr)
        {
            slide->get_Shapes()->Remove(legacyDiagram);
        }
    }
}

presentation->Save(u"modernized.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

ارائه ذخیره‌شده شامل گروه‌های قابل ویرایش از اشکال به جای نمودارهای قدیمی تبدیل‌شده است و هیچ نمودار اصلی در کنار آنها باقی نمی‌ماند. PPTX را در PowerPoint باز کنید تا عناصر جداگانه داخل هر گروه، مانند متن، پرکن یا موقعیت آن‌ها را ویرایش کنید.

## **سؤالات متداول**

**آیا SmartArt از انعکاس یا معکوس کردن برای زبان‌های راست به چپ پشتیبانی می‌کند؟**

بله. متد [SmartArt::set_IsReversed](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/smartart/set_isreversed/) جهت نمودار را از چپ به راست به راست به چپ یا برعکس تغییر می‌دهد، زمانی که طرح انتخاب‌شده SmartArt از معکوس شدن پشتیبانی کند.

**چگونه می‌توانم SmartArt را به همان اسلاید یا به ارائه دیگری کپی کنم در حالی که قالب‌بندی حفظ می‌شود؟**

می‌توانید [شکل SmartArt را کلون کنید](/slides/fa/cpp/shape-manipulations/) با [ShapeCollection::AddClone](https://reference.aspose.com/slides/cpp/aspose.slides/shapecollection/addclone/) یا [کلون کل اسلاید](/slides/fa/cpp/clone-slides/) که شامل SmartArt است، انجام دهید. هر دو روش اندازه، موقعیت و قالب‌بندی را حفظ می‌کنند.

**چگونه می‌توانم SmartArt را به یک تصویر رستر برای پیش‌نمایش یا صادرات وب رندر کنم؟**

[اسلاید را رندر کنید](/slides/fa/cpp/convert-powerpoint-to-png/) یا کل ارائه را به PNG یا JPEG. SmartArt به عنوان بخشی از اسلاید رندر می‌شود.

**چگونه می‌توانم یک شیء SmartArt خاص را در یک اسلاید پیدا کنم اگر چندین مورد وجود داشته باشد؟**

یک مقدار متمایز برای [Shape::set_AlternativeText](https://reference.aspose.com/slides/cpp/aspose.slides/shape/set_alternativetext/) یا [Shape::set_Name](https://reference.aspose.com/slides/cpp/aspose.slides/shape/set_name/) روی شکل SmartArt تنظیم کنید، آن مقدار را در [BaseSlide::get_Shapes](https://reference.aspose.com/slides/cpp/aspose.slides/baseslide/get_shapes/) جستجو کنید، سپس بررسی کنید که شکل مطابق یک [ISmartArt](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/ismartart/) باشد.