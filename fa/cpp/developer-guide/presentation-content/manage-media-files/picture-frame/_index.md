---
title: مدیریت قاب‌های تصویر در ارائه‌ها با استفاده از C++
linktitle: قاب تصویر
type: docs
weight: 10
url: /fa/cpp/picture-frame/
keywords:
- قاب تصویر
- افزودن قاب تصویر
- ایجاد قاب تصویر
- افزودن تصویر
- ایجاد تصویر
- استخراج تصویر
- تصویر رستری
- تصویر برداری
- برش تصویر
- ناحیه برش‌خورده
- ویژگی StretchOff
- قالب‌بندی قاب تصویر
- ویژگی‌های قاب تصویر
- مقیاس نسبی
- اثر تصویر
- نسبت تصویر
- شفافیت تصویر
- PowerPoint
- OpenDocument
- ارائه
- C++
- Aspose.Slides
description: "قاب‌های تصویر را به ارائه‌های PowerPoint و OpenDocument با Aspose.Slides برای C++ اضافه کنید. جریان کار خود را بهینه‌سازی کنید و طراحی اسلایدها را ارتقا دهید."
---
## **معرفی**

قاب تصویر یک شکل است که دارای یک تصویر می‌باشد—مانند یک تصویر در داخل یک قاب. 

می‌توانید یک تصویر را از طریق یک قاب تصویر به اسلاید اضافه کنید. به این ترتیب می‌توانید تصویر را با قالب‌بندی قاب تصویر فرمت کنید.

{{% alert  title="Tip" color="primary" %}} 

Aspose مبدل‌های رایگان—[JPEG به PowerPoint](https://products.aspose.app/slides/fa/import/jpg-to-ppt) و [PNG به PowerPoint](https://products.aspose.app/slides/fa/import/png-to-ppt)—را ارائه می‌دهد که به افراد امکان می‌دهد به سرعت از تصاویر ارائه‌ها را ایجاد کنند. 

{{% /alert %}} 

## **ایجاد یک قاب تصویر**

1. یک نمونه از [Presentation class](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.presentation) ایجاد کنید.  
2. از طریق ایندکس، مرجع یک اسلاید را دریافت کنید.  
3. با افزودن یک تصویر به [IImagescollection](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.i_image_collection) که به شیء presentation مرتبط است و برای پر کردن شکل استفاده می‌شود، یک شیء [IPPImage](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.i_p_p_image) ایجاد کنید.  
4. عرض و ارتفاع تصویر را مشخص کنید.  
5. با استفاده از متد `AddPictureFrame` که توسط شیء shape مرتبط با اسلاید مرجع ارائه می‌شود، یک [PictureFrame](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.picture_frame) بر اساس عرض و ارتفاع تصویر ایجاد کنید.  
6. قاب تصویر (شامل تصویر) را به اسلاید اضافه کنید.  
7. ارائه‌ی تغییر یافته را به صورت فایل PPTX ذخیره کنید.  

```c++
// مسیر پوشه اسناد.
const String outPath = u"../out/PictureFrameFormatting_out.pptx";
const String filePath = u"../templates/Tulips.jpg";

// بارگذاری ارائه مورد نظر
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// دسترسی به اولین اسلاید
SharedPtr<ISlide> slide = pres->get_Slide(0);

// بارگذاری تصویری که به مجموعه تصاویر ارائه اضافه خواهد شد
// دریافت تصویر
auto image = Images::FromFile(filePath);

// افزودن تصویر به مجموعه تصاویر ارائه
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(image);

// افزودن یک قاب تصویر به اسلاید
SharedPtr<IPictureFrame> pf = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, imgx);

// تنظیم مقیاس نسبی عرض و ارتفاع
pf->set_RelativeScaleHeight(0.8);
pf->set_RelativeScaleWidth(1.35);
// اعمال برخی قالب‌بندی‌ها بر روی قاب تصویر
pf->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
pf->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
pf->get_LineFormat()->set_Width ( 20);
pf->set_Rotation( 45);

// نوشتن فایل PPTX بر روی دیسک
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

{{% alert color="warning" %}} 

قاب‌های تصویر به شما امکان می‌دهند به سرعت اسلایدهای ارائه‌ای مبتنی بر تصاویر ایجاد کنید. هنگامی که قاب تصویر را با گزینه‌های ذخیره Aspose.Slides ترکیب می‌کنید، می‌توانید عملیات ورودی/خروجی را برای تبدیل تصاویر از یک فرمت به فرمت دیگر مدیریت کنید. ممکن است بخواهید این صفحات را ببینید: تبدیل [image به JPG](https://products.aspose.com/slides/fa/cpp/conversion/image-to-jpg/); تبدیل [JPG به image](https://products.aspose.com/slides/fa/cpp/conversion/jpg-to-image/); تبدیل [JPG به PNG](https://products.aspose.com/slides/fa/cpp/conversion/jpg-to-png/), تبدیل [PNG به JPG](https://products.aspose.com/slides/fa/cpp/conversion/png-to-jpg/); تبدیل [PNG به SVG](https://products.aspose.com/slides/fa/cpp/conversion/png-to-svg/), تبدیل [SVG به PNG](https://products.aspose.com/slides/fa/cpp/conversion/svg-to-png/).  

{{% /alert %}}

## **ایجاد یک قاب تصویر با مقیاس نسبی**

با تغییر مقیاس نسبی یک تصویر، می‌توانید یک قاب تصویر پیچیده‌تر ایجاد کنید. 

1. یک نمونه از [Presentation class](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.presentation) ایجاد کنید.  
2. از طریق ایندکس، مرجع یک اسلاید را دریافت کنید.  
3. یک تصویر را به مجموعه تصاویر ارائه اضافه کنید.  
4. با افزودن یک تصویر به [IImagescollection](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.i_image_collection) که به شیء presentation مرتبط است و برای پر کردن شکل استفاده می‌شود، یک شیء [IPPImage](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.i_p_p_image) ایجاد کنید.  
5. عرض و ارتفاع نسبی تصویر را در قاب تصویر مشخص کنید.  
6. ارائه‌ی تغییر یافته را به صورت فایل PPTX ذخیره کنید.  

```c++
// مسیر پوشه اسناد.
const String outPath = u"../out/AddRelativeScaleHeightPictureFrame_out.pptx";
const String filePath = u"../templates/Tulips.jpg";

// بارگذاری ارائه مورد نظر
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// دسترسی به اولین اسلاید
SharedPtr<ISlide> slide = pres->get_Slide(0);

// بارگذاری تصویر برای افزودن به مجموعه تصاویر ارائه
// دریافت تصویر
auto image = Images::FromFile(filePath);

// افزودن تصویر به مجموعه تصاویر ارائه
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(image);

// افزودن یک قاب تصویر به اسلاید
SharedPtr<IPictureFrame> pf = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, imgx);

// تنظیم مقیاس نسبی عرض و ارتفاع
pf->set_RelativeScaleHeight (0.8);
pf->set_RelativeScaleWidth(1.35);

// نوشتن فایل PPTX بر روی دیسک
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **استخراج تصاویر رستری از قاب‌های تصویر**

می‌توانید تصاویر رستری را از اشیاء [PictureFrame](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.picture_frame) استخراج کرده و در قالب‌های PNG، JPG و سایر فرمت‌ها ذخیره کنید. مثال کد زیر نشان می‌دهد چگونه یک تصویر را از سند "sample.pptx" استخراج کرده و در قالب PNG ذخیره کنید.  

```c++
auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto firstSlide = presentation->get_Slide(0);
auto firstShape = firstSlide->get_Shape(0);
    
if (ObjectExt::Is<IPictureFrame>(firstShape))
{
    auto pictureFrame = ExplicitCast<IPictureFrame>(firstShape);
    auto image = pictureFrame->get_PictureFormat()->get_Picture()->get_Image()->get_SystemImage();

    image->Save(u"slide_1_shape_1.png", ImageFormat::get_Png());
}

presentation->Dispose();
```

## **استخراج تصاویر SVG از قاب‌های تصویر**

هنگامی که یک ارائه شامل گرافیک‌های SVG داخل اشکال [PictureFrame](https://reference.aspose.com/slides/fa/cpp/aspose.slides/pictureframe/) باشد، Aspose.Slides برای C++ به شما امکان می‌دهد تصویرهای برداری اصلی را با کیفیت کامل بازیابی کنید. با پیمایش مجموعه اشکال اسلاید، می‌توانید هر [PictureFrame](https://reference.aspose.com/slides/fa/cpp/aspose.slides/pictureframe/) را شناسایی کنید، بررسی کنید آیا [IPPImage](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ippimage/) زیرین محتویات SVG دارد یا نه، و سپس آن تصویر را به صورت فایل یا جریان در قالب SVG بومی ذخیره کنید.  

```cpp
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

## **دریافت شفافیت یک تصویر**

Aspose.Slides به شما امکان می‌دهد اثر شفافیتی که بر روی یک تصویر اعمال شده است را دریافت کنید. این کد C++ عمل را نشان می‌دهد:  

```c++
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

{{% alert color="primary" %}} 
تمام اثرات اعمال شده به تصاویر را می‌توانید در [Aspose::Slides::Effects](https://reference.aspose.com/slides/fa/cpp/aspose.slides.effects/) پیدا کنید. 
{{% /alert %}}

## **دریافت روشنایی و کنتراست یک تصویر**

Aspose.Slides به شما امکان می‌دهد اثر روشنایی و کنتراست اعمال شده به یک تصویر را دریافت کنید. رابط [ILuminance](https://reference.aspose.com/slides/fa/cpp/aspose.slides.effects/iluminance/) این اثر تبدیل تصویر را نشان می‌دهد.  

این کد C++ نشان می‌دهد چگونه تنظیمات روشنایی و کنتراست را از یک قاب تصویر دریافت کنید:  

```c++
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

## **قاب‌بندی تصویر**

Aspose.Slides گزینه‌های قالب‌بندی متعددی را ارائه می‌دهد که می‌توانند بر روی یک قاب تصویر اعمال شوند. با استفاده از این گزینه‌ها می‌توانید قاب تصویر را به گونه‌ای تغییر دهید که با نیازمندی‌های خاص مطابقت داشته باشد.  

1. یک نمونه از [Presentation class](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.presentation) ایجاد کنید.  
2. از طریق ایندکس، مرجع یک اسلاید را دریافت کنید.  
3. با افزودن یک تصویر به [IImagescollection](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.i_image_collection) که به شیء presentation مرتبط است و برای پر کردن شکل استفاده می‌شود، یک شیء [IPPImage](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.i_p_p_image) ایجاد کنید.  
4. عرض و ارتفاع تصویر را مشخص کنید.  
5. با استفاده از متد `AddPictureFrame` که توسط شیء [IShapes](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.i_shape_collection) مرتبط با اسلاید مرجع ارائه می‌شود، یک `PictureFrame` بر اساس عرض و ارتفاع تصویر ایجاد کنید.  
6. قاب تصویر (شامل تصویر) را به اسلاید اضافه کنید.  
7. رنگ خط قاب تصویر را تنظیم کنید.  
8. عرض خط قاب تصویر را تنظیم کنید.  
9. قاب تصویر را با مقدار مثبت یا منفی چرخش دهید.  
   * مقدار مثبت تصویر را به صورت ساعتگرد می‌چرخاند.  
   * مقدار منفی تصویر را به صورت پادساعتگرد می‌چرخاند.  
10. قاب تصویر (شامل تصویر) را به اسلاید اضافه کنید.  
11. ارائه‌ی تغییر یافته را به صورت فایل PPTX ذخیره کنید.  

```c++
// مسیر پوشه اسناد.
const String outPath = u"../out/AddRelativeScaleHeightPictureFrame_out.pptx";
const String filePath = u"../templates/Tulips.jpg";

// بارگذاری ارائه مورد نظر
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// دسترسی به اولین اسلاید
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// بارگذاری تصویر برای افزودن به مجموعه تصاویر ارائه
// دریافت تصویر
auto image = Images::FromFile(filePath);

// افزودن تصویر به مجموعه تصاویر ارائه
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(image);

// افزودن یک قاب تصویر به اسلاید
SharedPtr<IPictureFrame> pf = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, imgx);

// تنظیم مقیاس نسبی عرض و ارتفاع
pf->set_RelativeScaleHeight (0.8);
pf->set_RelativeScaleWidth(1.35);

//فایل PPTX را بر روی دیسک می‌نویسد
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

{{% alert title="Tip" color="primary" %}}

Aspose اخیراً یک [Collage Maker رایگان](https://products.aspose.app/slides/fa/collage) توسعه داده است. اگر ever نیاز به [ادغام JPG/JPEG](https://products.aspose.app/slides/fa/collage/jpg) یا تصاویر PNG، یا [ایجاد شبکه‌های تصویری از عکس‌ها](https://products.aspose.app/slides/fa/collage/photo-grid) دارید، می‌توانید از این سرویس استفاده کنید. 
{{% /alert %}}

## **افزودن تصویر به‌عنوان لینک**

برای جلوگیری از بزرگ شدن اندازه ارائه، می‌توانید به جای تعبیه مستقیم فایل‌ها، تصاویر (یا ویدئوها) را از طریق لینک‌ها اضافه کنید. این کد C++ نشان می‌دهد چگونه یک تصویر و ویدئو را به یک placeholder اضافه کنید:  

```cpp
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

این کد C++ نشان می‌دهد چگونه یک تصویر موجود در اسلاید را برش دهید:  

```cpp
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;
    
auto presentation = System::MakeObject<Presentation>();
// ایجاد شیء تصویر جدید
auto newImage = presentation->get_Images()->AddImage(Images::FromFile(imagePath));

// افزودن یک PictureFrame به اسلاید
auto picFrame = presentation->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, 100.0f, 100.0f, 420.0f, 250.0f, newImage);

// برش تصویر (مقادیر درصدی)
picFrame->get_PictureFormat()->set_CropLeft(23.6f);
picFrame->get_PictureFormat()->set_CropRight(21.5f);
picFrame->get_PictureFormat()->set_CropTop(3.0f);
picFrame->get_PictureFormat()->set_CropBottom(31.0f);

// ذخیره نتیجه
presentation->Save(outPptxFile, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **حذف نواحی برش‌خورده یک تصویر**

اگر بخواهید نواحی برش‌خورده یک تصویر موجود در قاب را حذف کنید، می‌توانید از متد [IPictureFillFormat::DeletePictureCroppedAreas()](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) استفاده کنید. این متد تصویر برش‌خورده یا تصویر اصلی را در صورتی که نیاز به برش نباشد برمی‌گرداند.  

```c++
System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>(u"PictureFrameCrop.pptx");
System::SharedPtr<ISlide> slide = presentation->get_Slide(0);

// Gets the PictureFrame from the first slide
System::SharedPtr<IPictureFrame> picFrame = System::AsCast<IPictureFrame>(slide->get_Shape(0));

// Deletes cropped areas of the PictureFrame image and returns the cropped image
System::SharedPtr<IPPImage> croppedImage = picFrame->get_PictureFormat()->DeletePictureCroppedAreas();

// Saves the result
presentation->Save(u"PictureFrameDeleteCroppedAreas.pptx", SaveFormat::Pptx);
```

{{% alert title="NOTE" color="warning" %}} 

متد [IPictureFillFormat::DeletePictureCroppedAreas()](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) تصویر برش‌خورده را به مجموعه تصاویر ارائه اضافه می‌کند. اگر تصویر فقط در [PictureFrame](https://reference.aspose.com/slides/fa/cpp/aspose.slides/pictureframe/) پردازش‌شده استفاده شود، این تنظیم می‌تواند اندازه ارائه را کاهش دهد؛ در غیر این صورت تعداد تصاویر در ارائه نهایی افزایش خواهد یافت.  

این متد در عملیات برش فایل‌های متا‌فایل WMF/EMF را به تصویر PNG رستری تبدیل می‌کند. 
{{% /alert %}}

## **فشرده‌سازی تصاویر**

می‌توانید با استفاده از متد [IPictureFillFormat::CompressImage()](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ipicturefillformat/compressimage/) یک تصویر را در یک ارائه فشرده کنید. این متد تصویر را با کاهش اندازه بر اساس اندازه شکل و وضوح مشخص‌شده فشرده می‌کند و امکان حذف نواحی برش‌خورده را فراهم می‌سازد.  

این کار اندازه و وضوح تصویر را مشابه ویژگی **Picture Format -> Compress Pictures -> Resolution** در PowerPoint تنظیم می‌کند.  

مثال‌های C++ زیر نشان می‌دهند چگونه می‌توان با تعیین یک وضوح هدف و به‌صورت اختیاری حذف نواحی برش‌خورده، یک تصویر را در ارائه فشرده کرد:  

```c++
auto presentation = System::MakeObject<Presentation>(u"demo.pptx");
auto slide = presentation->get_Slide(0);
auto pictureFrame = System::AsCast<IPictureFrame>(slide->get_Shape(0));

// تصویر را با وضوح هدف 150 DPI (وضوح وب) فشرده کنید و نواحی برش‌خورده را حذف کنید.
bool result = pictureFrame->get_PictureFormat()->CompressImage(true, PicturesCompression::Dpi150);

// بررسی نتیجه فشرده‌سازی.
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
auto presentation = System::MakeObject<Presentation>(u"demo.pptx");
auto slide = presentation->get_Slide(0);
auto pictureFrame = System::AsCast<IPictureFrame>(slide->get_Shape(0));

// تصویر را به 150 DPI (وضوح وب) فشرده کنید و نواحی برش‌خورده را حذف کنید.
pictureFrame->get_PictureFormat()->CompressImage(true, 150.0f);

presentation->Save(u"CompressedImage.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

{{% alert title="NOTE" color="warning" %}} 

متد تصویر را به وضوح پایین‌تر بر اساس اندازه شکل و DPI ارائه‌شده تبدیل می‌کند. نواحی برش‌خورده نیز می‌توانند برای بهینه‌سازی حجم فایل حذف شوند.  
اگر تصویر یک متا‌فایل (WMF/EMF) یا SVG باشد، فشرده‌سازی اعمال نمی‌شود. همچنین کیفیت JPEG بر اساس وضوح حفظ یا کمی کاهش می‌یابد، مشابه رفتار PowerPoint با JPEGهای با وضوح بالا. 
{{% /alert %}}

## **قفل نسبت ابعاد**

اگر می‌خواهید شکلی که حاوی تصویر است حتی پس از تغییر ابعاد تصویر، نسبت ابعاد خود را حفظ کند، می‌توانید از متد [set_AspectRatioLocked()](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ipictureframelock/set_aspectratiolocked/) برای تنظیم گزینه *Lock Aspect Ratio* استفاده کنید.  

این کد C++ نشان می‌دهد چگونه نسبت ابعاد یک شکل را قفل کنید:  

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

System::SharedPtr<ILayoutSlide> layout = pres->get_LayoutSlides()->GetByType(SlideLayoutType::Custom);
System::SharedPtr<ISlide> emptySlide = pres->get_Slides()->AddEmptySlide(layout);

System::SharedPtr<IImage> image = Images::FromFile(u"image.png");
System::SharedPtr<IPPImage> presImage = pres->get_Images()->AddImage(image);

System::SharedPtr<IPictureFrame> pictureFrame = emptySlide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50.0f, 150.0f, static_cast<float>(presImage->get_Width()), static_cast<float>(presImage->get_Height()), presImage);

// set shape to have to preserve aspect ratio on resizing
pictureFrame->get_PictureFrameLock()->set_AspectRatioLocked(true);
```

{{% alert title="NOTE" color="warning" %}} 

این تنظیم *Lock Aspect Ratio* فقط نسبت ابعاد شکل را حفظ می‌کند و نه تصویر داخل آن. 
{{% /alert %}}

## **استفاده از ویژگی StretchOff**

با استفاده از ویژگی‌های [StretchOffsetLeft](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.picture_fill_format#ad730bf8db88f47979d84643eb30d1471)، [StretchOffsetTop](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.picture_fill_format#aa512e1f022e9c7ff83e9c51ba100709a)، [StretchOffsetRight](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.picture_fill_format#ac3597692f9b7e3327d0f4a4169a53127) و [StretchOffsetBottom](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.picture_fill_format#a72acf6945f372a5729c0b760f4a5dc39) از رابط [IPictureFillFormat](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.i_picture_fill_format) و کلاس [PictureFillFormat](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.picture_fill_format)، می‌توانید یک مستطیل پرکننده تعیین کنید.  

هنگامی که کشش تصویر مشخص شود، یک مستطیل منبع به‌صورت مقیاس‌دار برای پر کردن مستطیل پرکننده تعیین‌شده تنظیم می‌شود. هر لبه از مستطیل پرکننده با یک افست درصدی نسبت به لبه‌ متقابل جعبه مرزی شکل تعریف می‌شود. یک درصد مثبت نشان‌دهندهٔ درونی شدن (inset) است؛ یک درصد منفی نشان‌دهندهٔ بیرون‌زدگی (outset).  

1. یک نمونه از [Presentation](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.presentation) ایجاد کنید.  
2. از طریق ایندکس، مرجع یک اسلاید را دریافت کنید.  
3. یک مستطیل `AutoShape` اضافه کنید.  
4. یک تصویر ایجاد کنید.  
5. نوع پر کردن شکل را تنظیم کنید.  
6. حالت پر کردن تصویر شکل را تنظیم کنید.  
7. یک تصویر تنظیم‌شده برای پر کردن شکل اضافه کنید.  
8. افست‌های تصویر را نسبت به لبه‌های متناظر جعبه مرزی شکل مشخص کنید.  
9. ارائه‌ی تغییر یافته را به صورت فایل PPTX ذخیره کنید.  

این کد C++ نشان می‌دهد چگونه از ویژگی StretchOff استفاده شود:  

```cpp
auto pres = System::MakeObject<Presentation>();
auto ppImage = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));
auto slide = pres->get_Slide(0);
auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 400.0f, 400.0f, ppImage);

// تنظیم تصویر کشیده شده از هر سمت در بدنه شکل
auto pictureFormat = pictureFrame->get_PictureFormat();
pictureFormat->set_PictureFillMode(PictureFillMode::Stretch);
pictureFormat->set_StretchOffsetLeft(24.0f);
pictureFormat->set_StretchOffsetRight(24.0f);
pictureFormat->set_StretchOffsetTop(24.0f);
pictureFormat->set_StretchOffsetBottom(24.0f);

pres->Save(u"imageStretch.pptx", SaveFormat::Pptx);
```

## **FAQ**

**چگونه می‌توانم بفهمم که کدام فرمت‌های تصویر برای PictureFrame پشتیبانی می‌شوند؟**  

Aspose.Slides هم تصاویر رستری (PNG، JPEG، BMP، GIF و غیره) و هم تصاویر برداری (مثلاً SVG) را از طریق شیء تصویر که به یک [PictureFrame](https://reference.aspose.com/slides/fa/cpp/aspose.slides/pictureframe/) اختصاص یافته پشتیبانی می‌کند. فهرست فرمت‌های پشتیبانی‌شده عموماً با قابلیت‌های موتور تبدیل اسلاید و تصویر همپوشانی دارد.

**افزودن ده‌ها تصویر بزرگ چه تأثیری بر اندازه و عملکرد PPTX دارد؟**  

تعبیه (embed) تصاویر بزرگ حجم فایل و استفاده از حافظه را افزایش می‌دهد؛ لینک کردن تصاویر به کاهش حجم ارائه کمک می‌کند اما نیاز دارد فایل‌های خارجی در دسترس بمانند. Aspose.Slides امکان افزودن تصاویر به‌صورت لینک را برای کاهش حجم فایل فراهم می‌کند.

**چگونه می‌توانم شیء تصویر را از حرکت/تغییر اندازه تصادفی قفل کنم؟**  

از [قفل‌های شکل](https://reference.aspose.com/slides/fa/cpp/aspose.slides/pictureframe/get_pictureframelock/) برای یک [PictureFrame](https://reference.aspose.com/slides/fa/cpp/aspose.slides/pictureframe/) استفاده کنید (مثلاً غیرفعال کردن حرکت یا تغییر اندازه). مکانیزم قفل‌گذاری برای اشکال در مقالهٔ محافظت جداگانه توضیح داده شده و برای انواع مختلف شکل‌ها، از جمله [PictureFrame](https://reference.aspose.com/slides/fa/cpp/aspose.slides/pictureframe/) پشتیبانی می‌شود.

**آیا صحت برداری SVG هنگام خروجی گرفتن ارائه به PDF/تصاویر حفظ می‌شود؟**  

Aspose.Slides امکان استخراج SVG از یک [PictureFrame](https://reference.aspose.com/slides/fa/cpp/aspose.slides/pictureframe/) را به‌عنوان بردار اصلی فراهم می‌کند. هنگام خروجی به PDF یا فرمت‌های رستری، نتیجه ممکن است بر اساس تنظیمات خروجی رستر شود؛ اما نگهداری SVG به‌عنوان بردار در رفتار استخراج تأیید می‌شود.