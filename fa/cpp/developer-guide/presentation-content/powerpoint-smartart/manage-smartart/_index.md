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
description: "یاد بگیرید چگونه SmartArt PowerPoint را با Aspose.Slides برای C++ بسازید و ویرایش کنید با نمونه‌های کد واضح که طراحی اسلاید و خودکارسازی را تسریع می‌کند."
---
## **نمای کلی**

SmartArt یک نمودار PowerPoint است که از گره‌ها، شکل‌های گره و یک طرح تشکیل شده است. با Aspose.Slides برای C++ می‌توانید SmartArt را ایجاد کنید، متن را از گره‌های آن بخوانید، طرح آن را تغییر دهید، گره‌های مخفی را بررسی کنید، طرح‌های نمودار سازمانی را پیکربندی کنید و نمودارهای سازمانی تصویری ایجاد کنید.

## **دریافت متن از یک شیء SmartArt**

یک گره SmartArt می‌تواند شامل یک یا چند شکل باشد. برای خواندن متن قابل مشاهده، روی [ISmartArt::get_AllNodes](https://reference.aspose.com/slides/fa/cpp/aspose.slides.smartart/smartart/get_allnodes/) حلقه بزنید، سپس [ITextFrame](https://reference.aspose.com/slides/fa/cpp/aspose.slides/itextframe/) برگردانده‌شده توسط [ISmartArtShape::get_TextFrame](https://reference.aspose.com/slides/fa/cpp/aspose.slides.smartart/smartartshape/get_textframe/) را بخوانید.

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shape(0);

if (System::ObjectExt::Is<ISmartArt>(shape))
{
    auto smartArt = System::ExplicitCast<ISmartArt>(shape);

    for (int nodeIndex = 0; nodeIndex < smartArt->get_AllNodes()->get_Count(); nodeIndex++)
    {
        auto node = smartArt->get_AllNodes()->idx_get(nodeIndex);

        for (int shapeIndex = 0; shapeIndex < node->get_Shapes()->get_Count(); shapeIndex++)
        {
            auto nodeShape = node->get_Shape(shapeIndex);

            if (nodeShape->get_TextFrame() != nullptr)
            {
                System::Console::WriteLine(nodeShape->get_TextFrame()->get_Text());
            }
        }
    }
}

presentation->Dispose();
```

## **تغییر نوع طرح یک شیء SmartArt**

طرح SmartArt تعیین می‌کند گره‌ها چگونه چیدمان و متصل می‌شوند. مثال زیر یک شیء SmartArt با مقدار [SmartArtLayoutType](https://reference.aspose.com/slides/fa/cpp/aspose.slides.smartart/smartartlayouttype/) `BasicBlockList` ایجاد می‌کند، آن را به مقدار `BasicProcess` تغییر می‌دهد و ارائه را ذخیره می‌کند.

```cpp
auto presentation = System::MakeObject<Presentation>();

auto smartArt = presentation->get_Slide(0)->get_Shapes()->AddSmartArt(
    10.0f, 10.0f, 400.0f, 300.0f, SmartArtLayoutType::BasicBlockList);

smartArt->set_Layout(SmartArtLayoutType::BasicProcess);

presentation->Save(u"ChangeSmartArtLayout_out.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **بررسی اینکه آیا یک گره SmartArt مخفی است**

[ISmartArtNode::get_IsHidden](https://reference.aspose.com/slides/fa/cpp/aspose.slides.smartart/smartartnode/get_ishidden/) نشان می‌دهد آیا گره در مدل داده SmartArt مخفی است یا نه. گره‌های مخفی می‌توانند در ساختار حضور داشته باشند حتی زمانی که طرح انتخاب شده آن‌ها را به‌عنوان عناصر نمودار قابل مشاهده نمایش نمی‌دهد.

مثال زیر یک گره به شیء SmartArt که از مقدار [SmartArtLayoutType](https://reference.aspose.com/slides/fa/cpp/aspose.slides.smartart/smartartlayouttype/) `RadialCycle` استفاده می‌کند، اضافه می‌کند و حالت مخفی بودن گره را بررسی می‌کند.

```cpp
auto presentation = System::MakeObject<Presentation>();

auto smartArt = presentation->get_Slide(0)->get_Shapes()->AddSmartArt(
    10.0f, 10.0f, 400.0f, 300.0f, SmartArtLayoutType::RadialCycle);

auto node = smartArt->get_AllNodes()->AddNode();
bool isHidden = node->get_IsHidden();

if (isHidden)
{
    System::Console::WriteLine(u"The node is hidden in the SmartArt data model.");
}

presentation->Save(u"CheckSmartArtHiddenProperty_out.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **دریافت یا تنظیم طرح نمودار سازمانی**

برای نمودارهای SmartArt که از طرح نمودار سازمانی استفاده می‌کنند، [ISmartArtNode::get_OrganizationChartLayout](https://reference.aspose.com/slides/fa/cpp/aspose.slides.smartart/smartartnode/get_organizationchartlayout/) و [ISmartArtNode::set_OrganizationChartLayout](https://reference.aspose.com/slides/fa/cpp/aspose.slides.smartart/smartartnode/set_organizationchartlayout/) تعیین می‌کنند که گره‌های فرزند چگونه زیر گره والد چیده شوند. به‌عنوان مثال می‌توانید گره‌های فرزند را طوری تنظیم کنید که از سمت چپ، راست یا هر دو سمت آویزان شوند، بسته به [OrganizationChartLayoutType](https://reference.aspose.com/slides/fa/cpp/aspose.slides.smartart/organizationchartlayouttype/) انتخاب‌شده.

مثال زیر یک نمودار سازمانی ایجاد می‌کند و طرح گره اول را به مقدار [OrganizationChartLayoutType](https://reference.aspose.com/slides/fa/cpp/aspose.slides.smartart/organizationchartlayouttype/) `LeftHanging` تنظیم می‌کند.

```cpp
auto presentation = System::MakeObject<Presentation>();

auto smartArt = presentation->get_Slide(0)->get_Shapes()->AddSmartArt(
    10.0f, 10.0f, 400.0f, 300.0f, SmartArtLayoutType::OrganizationChart);

auto rootNode = smartArt->get_Node(0);
rootNode->set_OrganizationChartLayout(OrganizationChartLayoutType::LeftHanging);

presentation->Save(u"OrganizationChartLayout_out.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **ایجاد یک نمودار سازمانی تصویری**

نمودار سازمانی تصویری یک طرح SmartArt است که برای نمودارهای سلسله‌مراتبی شامل جای‌گیری تصویر طراحی شده است. هنگام افزودن شیء SmartArt به اسلاید از مقدار [SmartArtLayoutType](https://reference.aspose.com/slides/fa/cpp/aspose.slides.smartart/smartartlayouttype/) `PictureOrganizationChart` استفاده کنید.

```cpp
auto presentation = System::MakeObject<Presentation>();

auto smartArt = presentation->get_Slide(0)->get_Shapes()->AddSmartArt(
    0.0f, 0.0f, 400.0f, 400.0f, SmartArtLayoutType::PictureOrganizationChart);

presentation->Save(u"PictureOrganizationChart_out.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **سوالات متداول**

**آیا SmartArt از آینه‌سازی یا معکوس‌کردن برای زبان‌های راست به چپ پشتیبانی می‌کند؟**

بله. متد [SmartArt::set_IsReversed](https://reference.aspose.com/slides/fa/cpp/aspose.slides.smartart/smartart/set_isreversed/) جهت نمودار را از چپ به راست به راست به چپ یا برعکس تغییر می‌دهد، زمانی که طرح SmartArt انتخاب‌شده از معکوس‌سازی پشتیبانی کند.

**چگونه می‌توانم SmartArt را در همان اسلاید یا در ارائه دیگر کپی کنم و قالب‌بندی آن را حفظ کنم؟**

می‌توانید [شکل SmartArt را کلون کنید](/slides/fa/cpp/shape-manipulations/) با استفاده از [ShapeCollection::AddClone](https://reference.aspose.com/slides/fa/cpp/aspose.slides/shapecollection/addclone/) یا کل اسلایدی که شامل SmartArt است را [کلون کنید](/slides/fa/cpp/clone-slides/). هر دو روش اندازه، موقعیت و قالب‌بندی را حفظ می‌کنند.

**چگونه می‌توانم SmartArt را به تصویر پیکسل برای پیش‌نمایش یا خروجی وب رندر کنم؟**

[اسلاید را رندر کنید](/slides/fa/cpp/convert-powerpoint-to-png/) یا کل ارائه را به PNG یا JPEG. SmartArt به‌عنوان بخشی از اسلاید رندر می‌شود.

**اگر چندین SmartArt روی یک اسلاید وجود داشته باشد، چگونه می‌توانم شیء خاصی را پیدا کنم؟**

یک مقدار متمایز برای [Shape::set_AlternativeText](https://reference.aspose.com/slides/fa/cpp/aspose.slides/shape/set_alternativetext/) یا [Shape::set_Name](https://reference.aspose.com/slides/fa/cpp/aspose.slides/shape/set_name/) روی شکل SmartArt تنظیم کنید، آن مقدار را در [BaseSlide::get_Shapes](https://reference.aspose.com/slides/fa/cpp/aspose.slides/baseslide/get_shapes/) جستجو کنید و سپس بررسی کنید که شکل یافت‌شده یک [ISmartArt](https://reference.aspose.com/slides/fa/cpp/aspose.slides.smartart/ismartart/) است.