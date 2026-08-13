---
title: مدیریت قاب‌های تصویر در ارائه‌ها با C++
linktitle: قاب تصویر
type: docs
weight: 10
url: /fa/cpp/picture-frame/
keywords:
- قاب تصویر
- افزودن قاب تصویر
- ایجاد قاب تصویر
- افزودن تصویر
- ساخت تصویر
- استخراج تصویر
- تصویر رستر
- تصویر برداری
- برش تصویر
- ناحیه برش‌خورده
- ویژگی StretchOff
- قالب‌بندی قاب تصویر
- ویژگی‌های قاب تصویر
- مقیاس نسبی
- اثر تصویر
- نسبت عرض به ارتفاع
- شفافیت تصویر
- PowerPoint
- OpenDocument
- ارائه
- C++
- Aspose.Slides
description: "قاب‌های تصویر را به ارائه‌های PowerPoint و OpenDocument با Aspose.Slides برای C++ اضافه کنید. جریان کار خود را بهبود بخشید و طراحی اسلایدها را ارتقا دهید."
---
## **مقدمه**

قاب تصویر یک شکل است که شامل یک تصویر است—مانند یک تصویر در یک قاب. 

می‌توانید یک تصویر را از طریق یک قاب تصویر به اسلاید اضافه کنید. به این ترتیب، می‌توانید تصویر را با قالب‌بندی قاب تصویر فرمت دهید.

{{% alert  title="Tip" color="info" %}} 

Aspose مبدل‌های رایگان—[JPEG به PowerPoint](https://products.aspose.app/slides/fa/import/jpg-to-ppt) و [PNG به PowerPoint](https://products.aspose.app/slides/fa/import/png-to-ppt)—را فراهم می‌کند که به افراد امکان می‌دهد به‌سرعت از تصاویر ارائه‌ها را ایجاد کنند. 

{{% /alert %}} 

## **ایجاد یک قاب تصویر**

1. یک نمونه از [کلاس Presentation](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.presentation) ایجاد کنید.  
2. مرجع یک اسلاید را از طریق ایندکس آن دریافت کنید.  
3. یک شیء [IPPImage](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.i_p_p_image) را با افزودن یک تصویر به [IImagescollection](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.i_image_collection) مرتبط با شیء ارائه ایجاد کنید که برای پر کردن شکل استفاده می‌شود.  
4. عرض و ارتفاع تصویر را مشخص کنید.  
5. یک [PictureFrame](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.picture_frame) بر اساس عرض و ارتفاع تصویر با استفاده از متد `AddPictureFrame` که توسط شیء شکل مرتبط با اسلاید مرجع ارائه می‌شود، ایجاد کنید.  
6. قاب تصویر (شامل تصویر) را به اسلاید اضافه کنید.  
7. ارائه‌ی تغییر یافته را به‌صورت فایل PPTX ذخیره کنید.

این کد C++ نشان می‌دهد که چگونه یک قاب تصویر ایجاد کنید:

```c++
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <Util/Images.h>
#include <drawing/color.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

// مسیر پوشه اسناد.
const String outPath = u"../out/PictureFrameFormatting_out.pptx";
const String filePath = u"../templates/Tulips.jpg";

// ارائهٔ موردنظر را بارگذاری می‌کند
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// به اسلاید اول دسترسی می‌یابد
SharedPtr<ISlide> slide = pres->get_Slide(0);

// تصویری که به مجموعه تصاویر ارائه اضافه خواهد شد را بارگذاری می‌کند
// تصویر را دریافت می‌کند
auto image = Images::FromFile(filePath);

// Adds an image to presentation's images collection
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(image);

// Adds a picture frame to the slide
SharedPtr<IPictureFrame> pf = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, imgx);

// Sets relative scale width and height
pf->set_RelativeScaleHeight(0.8);
pf->set_RelativeScaleWidth(1.35);
// Applies some formatting to PictureFrame
pf->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
pf->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
pf->get_LineFormat()->set_Width ( 20);
pf->set_Rotation( 45);

//Writes the PPTX file to disk
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

{{% alert color="warning" %}} 

قاب‌های تصویر به شما امکان می‌دهند به‌سرعت اسلایدهای ارائه بر پایه تصاویر ایجاد کنید. وقتی قاب تصویر را با گزینه‌های ذخیره Aspose.Slides ترکیب می‌کنید، می‌توانید عملیات ورودی/خروجی را برای تبدیل تصاویر از یک قالب به قالب دیگر دستکاری کنید. شاید بخواهید این صفحات را مشاهده کنید: تبدیل [image به JPG](https://products.aspose.com/slides/fa/cpp/conversion/image-to-jpg/); تبدیل [JPG به image](https://products.aspose.com/slides/fa/cpp/conversion/jpg-to-image/); تبدیل [JPG به PNG](https://products.aspose.com/slides/fa/cpp/conversion/jpg-to-png/)، تبدیل [PNG به JPG](https://products.aspose.com/slides/fa/cpp/conversion/png-to-jpg/); تبدیل [PNG به SVG](https://products.aspose.com/slides/fa/cpp/conversion/png-to-svg/)، تبدیل [SVG به PNG](https://products.aspose.com/slides/fa/cpp/conversion/svg-to-png/). 

{{% /alert %}}

## **ایجاد یک قاب تصویر با مقیاس نسبی**

با تغییر مقیاس نسبی یک تصویر، می‌توانید یک قاب تصویر پیچیده‌تر ایجاد کنید. 

1. یک نمونه از [کلاس Presentation](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.presentation) ایجاد کنید.  
2. مرجع یک اسلاید را از طریق ایندکس آن دریافت کنید.  
3. یک تصویر را به مجموعه تصاویر ارائه اضافه کنید.  
4. یک شیء [IPPImage](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.i_p_p_image) را با افزودن یک تصویر به [IImagescollection](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.i_image_collection) مرتبط با شیء ارائه ایجاد کنید که برای پر کردن شکل استفاده می‌شود.  
5. عرض و ارتفاع نسبی تصویر را در قاب تصویر مشخص کنید.  
6. ارائه‌ی تغییر یافته را به‌صورت فایل PPTX ذخیره کنید.

این کد C++ نشان می‌دهد که چگونه یک قاب تصویر با مقیاس نسبی ایجاد کنید:

```c++
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <Util/Images.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// مسیر پوشه اسناد.
const String outPath = u"../out/AddRelativeScaleHeightPictureFrame_out.pptx";
const String filePath = u"../templates/Tulips.jpg";

// ارائهٔ موردنظر را بارگذاری می‌کند
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// به اسلاید اول دسترسی می‌یابد
SharedPtr<ISlide> slide = pres->get_Slide(0);

// تصویری که به مجموعه تصاویر ارائه اضافه خواهد شد را بارگذاری می‌کند
// تصویر را دریافت می‌کند
auto image = Images::FromFile(filePath);

// یک تصویر را به مجموعه تصاویر ارائه اضافه می‌کند
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(image);

// یک قاب تصویر به اسلاید اضافه می‌کند
SharedPtr<IPictureFrame> pf = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, imgx);

// عرض و ارتفاع مقیاس نسبی را تنظیم می‌کند
pf->set_RelativeScaleHeight (0.8);
pf->set_RelativeScaleWidth(1.35);

// فایل PPTX را روی دیسک ذخیره می‌کند
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **استخراج تصاویر رستر از قاب‌های تصویر**

می‌توانید تصاویر رستر را از اشیاء [PictureFrame](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.picture_frame) استخراج کرده و در قالب‌های PNG، JPG و سایر فرمت‌ها ذخیره کنید. مثال کد پایین نشان می‌دهد چگونه یک تصویر را از سند «sample.pptx» استخراج و در قالب PNG ذخیره کنید.

```c++
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto firstSlide = presentation->get_Slide(0);
auto firstShape = firstSlide->get_Shape(0);

if (ObjectExt::Is<IPictureFrame>(firstShape))
{
    auto pictureFrame = ExplicitCast<IPictureFrame>(firstShape);
    auto image = pictureFrame->get_PictureFormat()->get_Picture()->get_Image()->get_Image();

    image->Save(u"slide_1_shape_1.png", ImageFormat::Png);
}

presentation->Dispose();
```

## **استخراج تصاویر SVG از قاب‌های تصویر**

وقتی یک ارائه شامل گرافیک‌های SVG باشد که داخل اشکال [PictureFrame](https://reference.aspose.com/slides/fa/cpp/aspose.slides/pictureframe/) قرار گرفته‌اند، Aspose.Slides برای C++ به شما امکان می‌دهد تصاویر برداری اصلی را با دقت کامل بازیابی کنید. با پیمایش مجموعه اشکال اسلاید، می‌توانید هر [PictureFrame](https://reference.aspose.com/slides/fa/cpp/aspose.slides/pictureframe/) را شناسایی کنید، بررسی کنید آیا [IPPImage](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ippimage/) زیرین محتویات SVG دارد یا نه، و سپس آن تصویر را در دیسک یا یک جریان به فرمت بومی SVG ذخیره کنید.

کد زیر نشان می‌دهد چگونه یک تصویر SVG را از یک قاب تصویر استخراج کنید:

```cpp
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/ISvgImage.h>
#include <DOM/Presentation.h>
#include <system/io/file.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shape(0);

if (ObjectExt::Is<IPictureFrame>(shape))
{
    auto pictureFrame = ExplicitCast<IPictureFrame>(shape);
    auto svgImage = pictureFrame->get_PictureFormat()->get_Picture()->get_Image()->get_SvgImage();
    if (svgImage != nullptr)
    {
        File::WriteAllText(u"output.svg", svgImage->get_SvgContent());
    }
}

presentation->Dispose();
```

## **دریافت شفافیت تصویر**

Aspose.Slides به شما اجازه می‌دهد اثر شفافیتی که بر روی تصویر اعمال شده است را دریافت کنید. این کد C++ این عملیات را نشان می‌دهد:

```c++
#include <DOM/Effects/IAlphaModulateFixed.h>
#include <DOM/Effects/IImageTransformOperationCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Effects;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"Test.pptx");
auto pictureFrame = System::ExplicitCast<IPictureFrame>(presentation->get_Slide(0)->get_Shape(0));
auto imageTransform = pictureFrame->get_PictureFormat()->get_Picture()->get_ImageTransform();
for (auto&& effect : imageTransform)
{
    if (System::ObjectExt::Is<IAlphaModulateFixed>(effect))
    {
        float transparencyValue = 100.0f - (System::ExplicitCast<IAlphaModulateFixed>(effect))->get_Amount();
        System::Console::WriteLine(System::String(u"Picture transparency: ") + transparencyValue);
    }
}
```

{{% alert color="info" %}} 
تمام اثرات اعمال‌شده بر روی تصاویر می‌توانند در [Aspose::Slides::Effects](https://reference.aspose.com/slides/fa/cpp/aspose.slides.effects/) یافت شوند. 
{{% /alert %}}

## **دریافت روشنایی و کنتراست تصویر**

Aspose.Slides به شما اجازه می‌دهد روشنایی و کنتراست تصویر را دریافت کنید. اینترفیس [ILuminance](https://reference.aspose.com/slides/fa/cpp/aspose.slides.effects/iluminance/) این اثر تبدیل تصویر را نمایان می‌کند.

این کد C++ نشان می‌دهد چگونه تنظیمات روشنایی و کنتراست را از یک قاب تصویر دریافت کنید:

```c++
#include <DOM/Effects/IImageTransformOperationCollection.h>
#include <DOM/Effects/ILuminance.h>
#include <DOM/Effects/ILuminanceEffectiveData.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Effects;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shape(0);
auto pictureFrame = System::ExplicitCast<IPictureFrame>(shape);

auto imageTransform = pictureFrame->get_PictureFormat()->get_Picture()->get_ImageTransform();
for (auto&& effect : imageTransform)
{
    if (System::ObjectExt::Is<ILuminance>(effect))
    {
        auto luminance = System::ExplicitCast<ILuminance>(effect)->GetEffective();
        auto brightness = luminance->get_Brightness();
        auto contrast = luminance->get_Contrast();

        Console::WriteLine(System::String(u"Brightness: ") + brightness);
        Console::WriteLine(System::String(u"Contrast: ") + contrast);
    }
}

presentation->Dispose();
```

## **قاب تصویر فرمت‌بندی**

Aspose.Slides گزینه‌های فرمت‌بندی بسیاری را که می‌توان بر روی یک قاب تصویر اعمال کرد، فراهم می‌کند. با استفاده از این گزینه‌ها می‌توانید قاب تصویر را طوری تغییر دهید که با نیازهای خاص مطابقت داشته باشد.

1. یک نمونه از [کلاس Presentation](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.presentation) ایجاد کنید.  
2. مرجع یک اسلاید را از طریق ایندکس آن دریافت کنید.  
3. یک شیء [IPPImage](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.i_p_p_image) را با افزودن یک تصویر به [IImagescollection](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.i_image_collection) مرتبط با شیء ارائه ایجاد کنید که برای پر کردن شکل استفاده می‌شود.  
4. عرض و ارتفاع تصویر را مشخص کنید.  
5. یک `PictureFrame` بر اساس عرض و ارتفاع تصویر با استفاده از متد [AddPictureFrame](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.i_shape_collection#ab55ae8c24dd32665637725a26ca1c1a9) که توسط شیء [IShapes](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.i_shape_collection) مرتبط با اسلاید مرجع ارائه می‌شود، ایجاد کنید.  
6. قاب تصویر (شامل تصویر) را به اسلاید اضافه کنید.  
7. رنگ خط قاب تصویر را تنظیم کنید.  
8. عرض خط قاب تصویر را تنظیم کنید.  
9. قاب تصویر را با مقدار مثبت یا منفی چرخاندن کنید.  
   * مقدار مثبت تصویر را به‌صورت ساعتگرد می‌چرخاند.  
   * مقدار منفی تصویر را به‌صورت پادساعتگرد می‌چرخاند.  
10. قاب تصویر (شامل تصویر) را به اسلاید اضافه کنید.  
11. ارائه‌ی تغییر یافته را به‌صورت فایل PPTX ذخیره کنید.

این کد C++ فرآیند فرمت‌بندی قاب تصویر را نشان می‌دهد:

```c++
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <Util/Images.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// مسیر پوشه اسناد.
const String outPath = u"../out/AddRelativeScaleHeightPictureFrame_out.pptx";
const String filePath = u"../templates/Tulips.jpg";

// ارائهٔ موردنظر را بارگذاری می‌کند
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// به اسلاید اول دسترسی می‌یابد
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// تصویری که به مجموعه تصاویر ارائه اضافه خواهد شد را بارگذاری می‌کند
// تصویر را دریافت می‌کند
auto image = Images::FromFile(filePath);

// یک تصویر را به مجموعه تصاویر ارائه اضافه می‌کند
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(image);

// یک قاب تصویر به اسلاید اضافه می‌کند
SharedPtr<IPictureFrame> pf = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, imgx);

// عرض و ارتفاع مقیاس نسبی را تنظیم می‌کند
pf->set_RelativeScaleHeight (0.8);
pf->set_RelativeScaleWidth(1.35);

// فایل PPTX را روی دیسک ذخیره می‌کند
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

{{% alert title="Tip" color="info" %}}

Aspose به‌تازگی یک [سازنده کلاژ رایگان](https://products.aspose.app/slides/fa/collage) توسعه داده است. اگر نیاز داشته باشید که تصاویر JPG/JPEG یا PNG را ترکیب کنید، یا گریدهایی از عکس‌ها بسازید، می‌توانید از این سرویس استفاده کنید. 
{{% /alert %}}

## **افزودن تصویر به‌عنوان لینک**

برای جلوگیری از بزرگ شدن اندازه ارائه، می‌توانید به‌جای جاسازی مستقیم فایل‌ها، تصاویر (یا ویدیوها) را از طریق لینک اضافه کنید. این کد C++ نشان می‌دهد چگونه یک تصویر و ویدیو را به یک جایگذاری اضافه کنید:

```cpp
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IPlaceholder.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/IVideoFrame.h>
#include <DOM/PlaceholderType.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/collections/list.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"input.pptx");
auto shapesToRemove = System::MakeObject<System::Collections::Generic::List<System::SharedPtr<IShape>>>();
auto shapes = presentation->get_Slides()->idx_get(0)->get_Shapes();

for (auto& autoShape : shapes)
{
    if (autoShape->get_Placeholder() == nullptr)
        continue;

    switch (autoShape->get_Placeholder()->get_Type())
    {
        case Aspose::Slides::PlaceholderType::Picture:
        {
            auto pictureFrame = shapes->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, autoShape->get_X(), autoShape->get_Y(), autoShape->get_Width(), autoShape->get_Height(), nullptr);
            pictureFrame->get_PictureFormat()->get_Picture()->set_LinkPathLong(u"https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg");
            shapesToRemove->Add(autoShape);
            break;
        }

        case Aspose::Slides::PlaceholderType::Media:
        {
            auto videoFrame = shapes->AddVideoFrame(autoShape->get_X(), autoShape->get_Y(), autoShape->get_Width(), autoShape->get_Height(), u"");
            videoFrame->get_PictureFormat()->get_Picture()->set_LinkPathLong(u"https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg");
            videoFrame->set_LinkPathLong(u"https://youtu.be/t_1LYZ102RA");
            shapesToRemove->Add(autoShape);
            break;
        }
    }
}

for (auto& shape : shapesToRemove)
{
    shapes->Remove(shape);
}

presentation->Save(u"output.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **برش تصاویر**

این کد C++ نشان می‌دهد چگونه یک تصویر موجود بر روی اسلاید را برش دهید: 

``` CPP
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <Util/Images.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
// یک شیء تصویر جدید ایجاد می‌کند
auto newImage = presentation->get_Images()->AddImage(Images::FromFile(u"image.png"));

// یک PictureFrame به یک اسلاید اضافه می‌کند
auto picFrame = presentation->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, 100.0f, 100.0f, 420.0f, 250.0f, newImage);

// تصویر را برش می‌دهد (مقدارهای درصدی)
picFrame->get_PictureFormat()->set_CropLeft(23.6f);
picFrame->get_PictureFormat()->set_CropRight(21.5f);
picFrame->get_PictureFormat()->set_CropTop(3.0f);
picFrame->get_PictureFormat()->set_CropBottom(31.0f);

// نتیجه را ذخیره می‌کند
presentation->Save(u"cropped.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **حذف نواحی برش‌خورده تصویر**

اگر می‌خواهید نواحی برش‌خورده‌ای که در یک قاب تصویر وجود دارد را حذف کنید، می‌توانید از متد [IPictureFillFormat::DeletePictureCroppedAreas()](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) استفاده کنید. این متد تصویر برش‌خورده یا تصویر اصلی را اگر برش لازم نباشد، برمی‌گرداند.

این کد C++ این عملیات را نشان می‌دهد: 

```c++
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>(u"PictureFrameCrop.pptx");
System::SharedPtr<ISlide> slide = presentation->get_Slide(0);

// PictureFrame را از اولین اسلاید دریافت می‌کند
System::SharedPtr<IPictureFrame> picFrame = System::AsCast<IPictureFrame>(slide->get_Shape(0));

// نواحی برش‌خورده تصویر PictureFrame را حذف می‌کند و تصویر برش‌خورده را برمی‌گرداند
System::SharedPtr<IPPImage> croppedImage = picFrame->get_PictureFormat()->DeletePictureCroppedAreas();

// نتیجه را ذخیره می‌کند
presentation->Save(u"PictureFrameDeleteCroppedAreas.pptx", SaveFormat::Pptx);
```

{{% alert title="NOTE" color="warning" %}} 

متد [IPictureFillFormat::DeletePictureCroppedAreas()](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) تصویر برش‌خورده را به مجموعه تصاویر ارائه اضافه می‌کند. اگر تصویر فقط در [PictureFrame](https://reference.aspose.com/slides/fa/cpp/aspose.slides/pictureframe/) پردازش‌شده مورد استفاده باشد، این تنظیم می‌تواند اندازه ارائه را کاهش دهد؛ در غیر این صورت، تعداد تصاویر در ارائه نهایی افزایش می‌یابد.

این متد در عملیات برش، فایل‌های متا‌فایل WMF/EMF را به تصویر PNG رستر تبدیل می‌کند. 

{{% /alert %}}

## **فشرده‌سازی تصاویر**

می‌توانید یک تصویر در ارائه را با استفاده از متد [IPictureFillFormat::CompressImage()](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ipicturefillformat/compressimage/) فشرده کنید. این متد با کاهش اندازه تصویر بر اساس اندازه شکل و وضوح‌دادۀ مشخص‌شده، و با امکان حذف نواحی برش‌خورده، تصویر را فشرده می‌سازد.

این کار مشابه ویژگی **فرمت تصویر → فشرده‌سازی تصاویر → وضوح** در PowerPoint عمل می‌کند.

مثال‌های زیر نشان می‌دهند چگونه می‌توانید با تعیین وضوح هدف و به‌صورت اختیاری حذف نواحی برش‌خورده، یک تصویر را در ارائه فشرده کنید:

```c++
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/PicturesCompression.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"demo.pptx");
auto slide = presentation->get_Slide(0);
auto pictureFrame = System::AsCast<IPictureFrame>(slide->get_Shape(0));

// تصویر را با وضوح هدف 150 DPI (وضوح وب) فشرده کنید و نواحی برش‌خورده را حذف کنید.
bool result = pictureFrame->get_PictureFormat()->CompressImage(true, PicturesCompression::Dpi150);

// نتیجه فشرده‌سازی را بررسی کنید.
if (result)
{
    System::Console::WriteLine(u"Image successfully compressed.");
}
else
{
    System::Console::WriteLine(u"Image compression failed or no changes were necessary.");
}

presentation->Save(u"CompressedImage.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

یا به‌صورت مستقیم با مقدار DPI سفارشی:

```c++
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"demo.pptx");
auto slide = presentation->get_Slide(0);
auto pictureFrame = System::AsCast<IPictureFrame>(slide->get_Shape(0));

// تصویر را به 150 DPI (وضوح وب) فشرده کنید و نواحی برش‌خورده را حذف کنید.
pictureFrame->get_PictureFormat()->CompressImage(true, 150.0f);

presentation->Save(u"CompressedImage.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

{{% alert title="NOTE" color="warning" %}}

متد تصویر را بر اساس اندازه شکل و DPI ارائه‌شده به وضوح پایین‌تری تبدیل می‌کند. نواحی برش‌خورده نیز می‌توانند برای بهینه‌سازی حجم فایل حذف شوند. اگر تصویر یک متا‌فایل (WMF/EMF) یا SVG باشد، فشرده‌سازی اعمال نمی‌شود. همچنین کیفیت JPEG بسته به وضوح حفظ یا کمی کاهش می‌یابد، مشابه نحوه‌ی پردازش PowerPoint برای JPEG‌های با وضوح بالا. 

{{% /alert %}}

## **قفل نسبت عرض‑به‑ارتفاع**

اگر می‌خواهید شکلی که حاوی تصویر است حتی پس از تغییر ابعاد تصویر، نسبت عرض‑به‑ارتفاع خود را حفظ کند، می‌توانید از متد [set_AspectRatioLocked()](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ipictureframelock/set_aspectratiolocked/) برای تنظیم گزینه *Lock Aspect Ratio* استفاده کنید. 

این کد C++ نشان می‌دهد چگونه نسبت عرض‑به‑ارتفاع یک شکل را قفل کنید:

```c++
#include <DOM/IGlobalLayoutSlideCollection.h>
#include <DOM/IImageCollection.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IPictureFrameLock.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideLayoutType.h>
#include <IImage.h>
#include <Util/Images.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;

System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

System::SharedPtr<ILayoutSlide> layout = pres->get_LayoutSlides()->GetByType(SlideLayoutType::Custom);
System::SharedPtr<ISlide> emptySlide = pres->get_Slides()->AddEmptySlide(layout);

System::SharedPtr<IImage> image = Images::FromFile(u"image.png");
System::SharedPtr<IPPImage> presImage = pres->get_Images()->AddImage(image);

System::SharedPtr<IPictureFrame> pictureFrame = emptySlide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50.0f, 150.0f, static_cast<float>(presImage->get_Width()), static_cast<float>(presImage->get_Height()), presImage);

// تنظیم شکل برای حفظ نسبت عرض به ارتفاع هنگام تغییر اندازه
pictureFrame->get_PictureFrameLock()->set_AspectRatioLocked(true);
```

{{% alert title="NOTE" color="warning" %}} 

این تنظیم *Lock Aspect Ratio* فقط نسبت عرض‑به‑ارتفاع شکل را حفظ می‌کند و نه تصویر موجود در داخل آن. 

{{% /alert %}}

## **استفاده از ویژگی StretchOff**

با استفاده از ویژگی‌های [StretchOffsetLeft](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.picture_fill_format#ad730bf8db88f47979d84643eb30d1471)، [StretchOffsetTop](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.picture_fill_format#aa512e1f022e9c7ff83e9c51ba100709a)، [StretchOffsetRight](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.picture_fill_format#ac3597692f9b7e3327d0f4a4169a53127) و [StretchOffsetBottom](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.picture_fill_format#a72acf6945f372a5729c0b760f4a5dc39) از رابط [IPictureFillFormat](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.i_picture_fill_format) و کلاس [PictureFillFormat](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.picture_fill_format)، می‌توانید یک مستطیل پر کردن مشخص کنید. 

هنگامی که کشش تصویر مشخص می‌شود، مستطیل منبع به‌صورت مقیاس‌دار برای متناسب شدن با مستطیل پر کردن تعریف‌شده تنظیم می‌شود. هر لبه از مستطیل پر کردن توسط درصدی از لبهٔ متناظر جعبه مرزی شکل تعریف می‌شود. درصد مثبت یک تورن را نشان می‌دهد و درصد منفی یک گسترش را.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.presentation) ایجاد کنید.  
2. مرجع یک اسلاید را از طریق ایندکس آن دریافت کنید.  
3. یک مستطیل `AutoShape` اضافه کنید.  
4. یک تصویر ایجاد کنید.  
5. نوع پر کردن شکل را تنظیم کنید.  
6. حالت پر کردن تصویر شکل را تنظیم کنید.  
7. یک تصویر برای پر کردن شکل اضافه کنید.  
8. افست‌های تصویر را از لبهٔ متناظر جعبه مرزی شکل مشخص کنید.  
9. ارائه‌ی تغییر یافته را به‌صورت فایل PPTX ذخیره کنید.

این کد C++ نشان می‌دهد که چگونه از ویژگی StretchOff استفاده شود:

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <Util/Images.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>();
auto ppImage = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));
auto slide = pres->get_Slide(0);
auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 400.0f, 400.0f, ppImage);

// تصویر را از هر طرف در بدنه شکل کشیده می‌کند
auto pictureFormat = pictureFrame->get_PictureFormat();
pictureFormat->set_PictureFillMode(PictureFillMode::Stretch);
pictureFormat->set_StretchOffsetLeft(24.0f);
pictureFormat->set_StretchOffsetRight(24.0f);
pictureFormat->set_StretchOffsetTop(24.0f);
pictureFormat->set_StretchOffsetBottom(24.0f);

pres->Save(u"imageStretch.pptx", SaveFormat::Pptx);
```

## **سؤالات متداول**

### چگونه می‌توانم بفهمم کدام فرمت‌های تصویر برای PictureFrame پشتیبانی می‌شوند؟

Aspose.Slides هر دو نوع تصویر رستر (PNG، JPEG، BMP، GIF و غیره) و تصویر برداری (مانند SVG) را از طریق شیء تصویر اختصاص‌یافته به یک [PictureFrame](https://reference.aspose.com/slides/fa/cpp/aspose.slides/pictureframe/) پشتیبانی می‌کند. لیست فرمت‌های پشتیبانی‌شده معمولاً با قابلیت‌های موتور تبدیل اسلاید و تصویر همپوشانی دارد.

### افزودن ده‌ها تصویر بزرگ چه تأثیری بر حجم و عملکرد فایل PPTX دارد؟

جاسازی تصاویر بزرگ حجم فایل و مصرف حافظه را افزایش می‌دهد؛ لینک کردن تصاویر به حفظ حجم ارائه کمک می‌کند اما نیاز دارد که فایل‌های خارجی در دسترس باقی بمانند. Aspose.Slides امکان افزودن تصاویر به‌صورت لینک را برای کاهش حجم فایل فراهم می‌کند.

### چگونه می‌توانم یک شیء تصویر را از جابه‌جایی/تغییر اندازهٔ ناخواسته قفل کنم؟

از [قفل‌های شکل](https://reference.aspose.com/slides/fa/cpp/aspose.slides/pictureframe/get_pictureframelock/) برای یک [PictureFrame](https://reference.aspose.com/slides/fa/cpp/aspose.slides/pictureframe/) استفاده کنید (به عنوان مثال، غیرفعال کردن جابه‌جایی یا تغییر اندازه). مکانیزم قفل‌گذاری برای اشکال در مقالهٔ جداگانهٔ [محافظت از ارائه](/slides/fa/cpp/applying-protection-to-presentation/) توضیح داده شده و برای انواع مختلف اشکال، از جمله [PictureFrame](https://reference.aspose.com/slides/fa/cpp/aspose.slides/pictureframe/) پشتیبانی می‌شود.

### آیا در هنگام خروجی به PDF/تصاویر، دقت برداری SVG حفظ می‌شود؟

Aspose.Slides امکان استخراج SVG از یک [PictureFrame](https://reference.aspose.com/slides/fa/cpp/aspose.slides/pictureframe/) را به‌عنوان بردار اصلی فراهم می‌کند. هنگام خروجی به PDF یا فرمت‌های رستر (/slides/fa/cpp/convert-powerpoint-to-png/)، نتیجه ممکن است بر اساس تنظیمات خروجی رستر شود؛ اما این حقیقت که SVG اصلی به‌عنوان بردار ذخیره شده است، توسط رفتار استخراج تأیید می‌شود.