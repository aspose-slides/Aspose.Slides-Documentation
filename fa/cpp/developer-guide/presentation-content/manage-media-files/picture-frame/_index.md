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
- تصویر رستر
- تصویر برداری
- برش تصویر
- منطقه برش خورده
- ویژگی StretchOff
- قالب‌بندی قاب تصویر
- ویژگی‌های قاب تصویر
- مقیاس نسبی
- اثر تصویر
- نسبت ابعاد
- شفافیت تصویر
- پاورپوینت
- OpenDocument
- ارائه
- C++
- Aspose.Slides
description: "قاب‌های تصویر را به ارائه‌های پاورپوینت و OpenDocument با Aspose.Slides برای C++ اضافه کنید. جریان کاری خود را بهبود بخشید و طرح اسلایدها را ارتقاء دهید."
---
## **مقدمه**

قاب تصویر یک شکل است که حاوی یک تصویر می‌باشد — مشابه یک تصویر درون یک قاب.  

می‌توانید یک تصویر را از طریق یک قاب تصویر به اسلاید اضافه کنید. به این ترتیب می‌توانید تصویر را با قالب‌بندی قاب تصویر قالب‌بندی کنید.

{{% alert  title="Tip" color="primary" %}} 
Aspose مبدل‌های رایگان—[JPEG به PowerPoint](https://products.aspose.app/slides/fa/import/jpg-to-ppt) و [PNG به PowerPoint](https://products.aspose.app/slides/fa/import/png-to-ppt)—را فراهم می‌کند که به افراد امکان می‌دهد ارائه‌ها را به‌سرعت از تصاویر ایجاد کنند. 
{{% /alert %}} 

## **ایجاد یک قاب تصویر**

1. یک نمونه از [کلاس Presentation](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.presentation) ایجاد کنید.  
2. مرجع یک اسلاید را از طریق اندیس آن دریافت کنید.  
3. یک شیء [IPPImage](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.i_p_p_image) ایجاد کنید با افزودن یک تصویر به [IImagescollection](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.i_image_collection) مرتبط با شیء ارائه که برای پر کردن شکل استفاده خواهد شد.  
4. عرض و ارتفاع تصویر را مشخص کنید.  
5. یک [PictureFrame](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.picture_frame) بر اساس عرض و ارتفاع تصویر از طریق متد `AddPictureFrame` که توسط شیء شکل مرتبط با اسلاید مرجع ارائه می‌شود، ایجاد کنید.  
6. قاب تصویر (که شامل تصویر است) را به اسلاید اضافه کنید.  
7. ارائه‌ی اصلاح‌شده را به‌عنوان فایل PPTX بنویسید.  

این کد C++ نحوه ایجاد یک قاب تصویر را نشان می‌دهد:  

```c++
// مسیر به پوشهٔ اسناد.
const String outPath = u"../out/PictureFrameFormatting_out.pptx";
const String filePath = u"../templates/Tulips.jpg";

// بارگذاری ارائهٔ موردنظر
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// دسترسی به اولین اسلاید
SharedPtr<ISlide> slide = pres->get_Slide(0);

// تصویر را بارگذاری می‌کند که به مجموعهٔ تصاویر ارائه اضافه خواهد شد
// دریافت تصویر
auto image = Images::FromFile(filePath);

// یک تصویر را به مجموعهٔ تصاویر ارائه اضافه می‌کند
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(image);

// یک قاب تصویر به اسلاید اضافه می‌کند
SharedPtr<IPictureFrame> pf = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, imgx);

// عرض و ارتفاع مقیاس نسبی را تنظیم می‌کند
pf->set_RelativeScaleHeight(0.8);
pf->set_RelativeScaleWidth(1.35);
// برخی قالب‌بندی‌ها را بر روی PictureFrame اعمال می‌کند
pf->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
pf->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
pf->get_LineFormat()->set_Width ( 20);
pf->set_Rotation( 45);

// فایل PPTX را روی دیسک می‌نویسد
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

{{% alert color="warning" %}} 
قاب‌های تصویر به شما امکان می‌دهند به سرعت اسلایدهای ارائه بر پایه تصاویر ایجاد کنید. زمانی که قاب تصویر را با گزینه‌های ذخیره Aspose.Slides ترکیب می‌کنید، می‌توانید عملیات ورودی/خروجی را برای تبدیل تصاویر از یک فرمت به فرمت دیگر مدیریت کنید. ممکن است بخواهید این صفحات را ببینید: تبدیل [image به JPG](https://products.aspose.com/slides/fa/cpp/conversion/image-to-jpg/); تبدیل [JPG به image](https://products.aspose.com/slides/fa/cpp/conversion/jpg-to-image/); تبدیل [JPG به PNG](https://products.aspose.com/slides/fa/cpp/conversion/jpg-to-png/)، تبدیل [PNG به JPG](https://products.aspose.com/slides/fa/cpp/conversion/png-to-jpg/); تبدیل [PNG به SVG](https://products.aspose.com/slides/fa/cpp/conversion/png-to-svg/)، تبدیل [SVG به PNG](https://products.aspose.com/slides/fa/cpp/conversion/svg-to-png/). 
{{% /alert %}}

## **ایجاد یک قاب تصویر با مقیاس نسبی**

با تغییر مقیاس نسبی تصویر، می‌توانید یک قاب تصویر پیچیده‌تر ایجاد کنید.  

1. یک نمونه از [کلاس Presentation](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.presentation) ایجاد کنید.  
2. مرجع یک اسلاید را از طریق اندیس آن دریافت کنید.  
3. یک تصویر را به مجموعه‌ی تصاویر ارائه اضافه کنید.  
4. یک شیء [IPPImage](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.i_p_p_image) ایجاد کنید با افزودن یک تصویر به [IImagescollection](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.i_image_collection) مرتبط با شیء ارائه که برای پر کردن شکل استفاده خواهد شد.  
5. عرض و ارتفاع نسبی تصویر را در قاب تصویر مشخص کنید.  
6. ارائه‌ی اصلاح‌شده را به‌عنوان فایل PPTX بنویسید.  

این کد C++ نشان می‌دهد چگونه یک قاب تصویر با مقیاس نسبی ایجاد کنید:  

```c++
// مسیر به پوشهٔ اسناد.
const String outPath = u"../out/AddRelativeScaleHeightPictureFrame_out.pptx";
const String filePath = u"../templates/Tulips.jpg";

// ارائهٔ موردنظر را بارگذاری می‌کند
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// به اولین اسلاید دسترسی پیدا می‌کند
SharedPtr<ISlide> slide = pres->get_Slide(0);

// تصویری را که باید به مجموعهٔ تصاویر ارائه اضافه شود بارگذاری می‌کند
// تصویر را دریافت می‌کند
auto image = Images::FromFile(filePath);

// یک تصویر را به مجموعهٔ تصاویر ارائه اضافه می‌کند
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(image);

// یک قاب تصویر به اسلاید اضافه می‌کند
SharedPtr<IPictureFrame> pf = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, imgx);

// عرض و ارتفاع مقیاس نسبی را تنظیم می‌کند
pf->set_RelativeScaleHeight (0.8);
pf->set_RelativeScaleWidth(1.35);

// فایل PPTX را روی دیسک می‌نویسد
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **استخراج تصاویر رستر از قاب‌های تصویر**

می‌توانید تصاویر رستر را از اشیاء [PictureFrame](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.picture_frame) استخراج کنید و در فرمت‌های PNG، JPG و سایر فرمت‌ها ذخیره کنید. مثال کد زیر نشان می‌دهد چگونه یک تصویر را از سند «sample.pptx» استخراج و در فرمت PNG ذخیره کنید.  

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

هنگامی که یک ارائه دارای گرافیک‌های SVG باشد که درون اشکال [PictureFrame](https://reference.aspose.com/slides/fa/cpp/aspose.slides/pictureframe/) قرار گرفته‌اند، Aspose.Slides برای C++ به شما امکان می‌دهد تصاویر برداری اصلی را با تمام دقت بازیابی کنید. با پیمایش مجموعه‌ی اشکال اسلاید، می‌توانید هر [PictureFrame] را شناسایی کنید، بررسی کنید که آیا [IPPImage] زیرین شامل محتوای SVG است یا نه، و سپس آن تصویر را به‌صورت بومی در فرمت SVG روی دیسک یا یک جریان ذخیره کنید.  

مثال کد زیر نشان می‌دهد چگونه یک تصویر SVG را از یک قاب تصویر استخراج کنید:  

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

## **دست‌یابی به شفافیت تصویر**

Aspose.Slides به شما امکان می‌دهد اثر شفافیت اعمال‌شده به یک تصویر را دریافت کنید. این کد C++ عملیات را نشان می‌دهد:  

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
تمام اثرات اعمال‌شده به تصاویر می‌توانند در [Aspose::Slides::Effects](https://reference.aspose.com/slides/fa/cpp/aspose.slides.effects/) یافت شوند. 
{{% /alert %}}

## **قالب‌بندی قاب تصویر**

Aspose.Slides گزینه‌های قالب‌بندی متعددی را که می‌توانند بر روی یک قاب تصویر اعمال شوند ارائه می‌دهد. با استفاده از این گزینه‌ها، می‌توانید یک قاب تصویر را طوری تغییر دهید که با نیازهای خاصی مطابقت داشته باشد.  

1. یک نمونه از [کلاس Presentation](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.presentation) ایجاد کنید.  
2. مرجع یک اسلاید را از طریق اندیس آن دریافت کنید.  
3. یک شیء [IPPImage](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.i_p_p_image) ایجاد کنید با افزودن یک تصویر به [IImagescollection](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.i_image_collection) مرتبط با شیء ارائه که برای پر کردن شکل استفاده خواهد شد.  
4. عرض و ارتفاع تصویر را مشخص کنید.  
5. یک `PictureFrame` بر اساس عرض و ارتفاع تصویر از طریق متد [AddPictureFrame](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.i_shape_collection#ab55ae8c24dd32665637725a26ca1c1a9) که توسط شیء [IShapes](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.i_shape_collection) مرتبط با اسلاید مرجع ارائه می‌شود، ایجاد کنید.  
6. قاب تصویر (که شامل تصویر است) را به اسلاید اضافه کنید.  
7. رنگ خط قاب تصویر را تنظیم کنید.  
8. عرض خط قاب تصویر را تنظیم کنید.  
9. قاب تصویر را با دادن مقدار مثبت یا منفی چرخانده کنید.  
   * یک مقدار مثبت تصویر را به جهت ساعت‌گرد می‌چرخاند.  
   * یک مقدار منفی تصویر را به جهت پادساعت‌گرد می‌چرخاند.  
10. قاب تصویر (که شامل تصویر است) را به اسلاید اضافه کنید.  
11. ارائه‌ی اصلاح‌شده را به‌عنوان فایل PPTX بنویسید.  

این کد C++ فرآیند قالب‌بندی قاب تصویر را نشان می‌دهد:  

```c++
// مسیر به پوشهٔ اسناد.
const String outPath = u"../out/AddRelativeScaleHeightPictureFrame_out.pptx";
const String filePath = u"../templates/Tulips.jpg";

// ارائهٔ موردنظر را بارگذاری می‌کند
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// به اولین اسلاید دسترسی می‌یابد
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// تصویری را که باید به مجموعهٔ تصاویر ارائه اضافه شود بارگذاری می‌کند
// تصویر را دریافت می‌کند
auto image = Images::FromFile(filePath);

// یک تصویر را به مجموعهٔ تصاویر ارائه اضافه می‌کند
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(image);

// یک قاب تصویر به اسلاید اضافه می‌کند
SharedPtr<IPictureFrame> pf = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, imgx);

// عرض و ارتفاع مقیاس نسبی را تنظیم می‌کند
pf->set_RelativeScaleHeight (0.8);
pf->set_RelativeScaleWidth(1.35);

// فایل PPTX را روی دیسک می‌نویسد
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

{{% alert title="Tip" color="primary" %}} 
Aspose به‌تازگی یک [ابزار ساخت کلاژ رایگان](https://products.aspose.app/slides/fa/collage) توسعه داده است. اگر نیاز به [ادغام JPG/JPEG](https://products.aspose.app/slides/fa/collage/jpg) یا تصاویر PNG دارید، یا می‌خواهید [شبکه‌ای از عکس‌ها ایجاد کنید](https://products.aspose.app/slides/fa/collage/photo-grid)، می‌توانید از این سرویس استفاده کنید. 
{{% /alert %}}

## **افزودن تصویر به‌عنوان لینک**

برای جلوگیری از بزرگ شدن حجم ارائه، می‌توانید تصاویر (یا ویدیوها) را از طریق لینک اضافه کنید به‌جای تعبیه مستقیم فایل‌ها در ارائه. این کد C++ نشان می‌دهد چگونه یک تصویر و یک ویدیو را به یک نگهدارنده (placeholder) اضافه کنید:  

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

## **قاب‌بندی تصاویر**

این کد C++ نشان می‌دهد چگونه یک تصویر موجود در اسلاید را برش دهید:  

``` CPP
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;
    
auto presentation = System::MakeObject<Presentation>();
// یک شیء تصویر جدید ایجاد می‌کند
auto newImage = presentation->get_Images()->AddImage(Images::FromFile(imagePath));

// یک قاب تصویر به اسلاید اضافه می‌کند
auto picFrame = presentation->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, 100.0f, 100.0f, 420.0f, 250.0f, newImage);

// تصویر را برش می‌دهد (مقادیر درصدی)
picFrame->get_PictureFormat()->set_CropLeft(23.6f);
picFrame->get_PictureFormat()->set_CropRight(21.5f);
picFrame->get_PictureFormat()->set_CropTop(3.0f);
picFrame->get_PictureFormat()->set_CropBottom(31.0f);

// نتیجه را ذخیره می‌کند
presentation->Save(outPptxFile, Aspose::Slides::Export::SaveFormat::Pptx);

```

## **حذف نواحی برش‌خورده یک تصویر**

اگر بخواهید نواحی برش‌خورده یک تصویر موجود در یک قاب را حذف کنید، می‌توانید از روش [IPictureFillFormat::DeletePictureCroppedAreas()](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) استفاده کنید. این روش تصویر برش‌خورده یا تصویر اصلی را باز می‌گرداند اگر برش لازم نباشد.  

این کد C++ عملیات را نشان می‌دهد:  

```c++
System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>(u"PictureFrameCrop.pptx");
System::SharedPtr<ISlide> slide = presentation->get_Slide(0);

// دریافت PictureFrame از اولین اسلاید
System::SharedPtr<IPictureFrame> picFrame = System::AsCast<IPictureFrame>(slide->get_Shape(0));

// حذف نواحی برش‌خورده تصویر PictureFrame و برگرداندن تصویر برش‌خورده
System::SharedPtr<IPPImage> croppedImage = picFrame->get_PictureFormat()->DeletePictureCroppedAreas();

// ذخیرهٔ نتیجه
presentation->Save(u"PictureFrameDeleteCroppedAreas.pptx", SaveFormat::Pptx);
```

{{% alert title="NOTE" color="warning" %}} 
متد [IPictureFillFormat::DeletePictureCroppedAreas()](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) تصویر برش‌خورده را به مجموعه‌ی تصاویر ارائه اضافه می‌کند. اگر تصویر فقط در [PictureFrame] پردازش‌شده استفاده شود، این تنظیم می‌تواند حجم ارائه را کاهش دهد. در غیر این صورت، تعداد تصاویر در ارائه نهایی افزایش می‌یابد.  

این روش فایل‌های متا‌فایل WMF/EMF را در عملیات برش به تصویر رستر PNG تبدیل می‌کند. 
{{% /alert %}}

## **فشرده‌سازی تصاویر**

می‌توانید یک تصویر در یک ارائه را با استفاده از متد [IPictureFillFormat::CompressImage()](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ipicturefillformat/compressimage/) فشرده کنید. این متد تصویر را با کاهش اندازه بر اساس اندازه شکل و وضوح مشخص‌شده فشرده می‌کند، با امکان حذف نواحی برش‌خورده.  

این روش اندازه و وضوح تصویر را مشابه ویژگی **Picture Format -> Compress Pictures -> Resolution** در PowerPoint تنظیم می‌کند.  

مثال‌های C++ زیر نشان می‌دهند چگونه یک تصویر در یک ارائه را با تعیین وضوح هدف و به‌صورت اختیاری حذف نواحی برش‌خورده فشرده کنید:  

```c++
auto presentation = System::MakeObject<Presentation>(u"demo.pptx");
auto slide = presentation->get_Slide(0);
auto pictureFrame = System::AsCast<IPictureFrame>(slide->get_Shape(0));

// تصویر را با وضوح هدف 150 DPI (وضوح وب) فشرده می‌کند و نواحی برش‌خورده را حذف می‌نماید.
bool result = pictureFrame->get_PictureFormat()->CompressImage(true, PicturesCompression::Dpi150);

// نتیجهٔ فشرده‌سازی را بررسی می‌کند.
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

یا به‌صورت مستقیم از مقدار DPI سفارشی استفاده کنید:  

```c++
auto presentation = System::MakeObject<Presentation>(u"demo.pptx");
auto slide = presentation->get_Slide(0);
auto pictureFrame = System::AsCast<IPictureFrame>(slide->get_Shape(0));

// تصویر را به 150 DPI (وضوح وب) فشرده می‌کند و نواحی برش‌خورده را حذف می‌نماید.
pictureFrame->get_PictureFormat()->CompressImage(true, 150.0f);

presentation->Save(u"CompressedImage.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

{{% alert title="NOTE" color="warning" %}} 
این متد تصویر را به وضوح پایین‌تری بر اساس اندازه شکل و DPI ارائه‌شده تبدیل می‌کند. نواحی برش‌خورده نیز می‌توانند برای بهینه‌سازی حجم فایل حذف شوند. اگر تصویر یک متا‌فایل (WMF/EMF) یا SVG باشد، فشرده‌سازی اعمال نخواهد شد. همچنین، کیفیت JPEG بر اساس وضوح حفظ یا کمی کاهش می‌یابد، مشابه نحوه‌ی مدیریت PowerPoint برای JPEGهای با وضوح بالا. 
{{% /alert %}}

## **قفل کردن نسبت ابعاد**

اگر می‌خواهید یک شکل حاوی تصویر نسبت ابعاد خود را حتی پس از تغییر ابعاد تصویر حفظ کند، می‌توانید از متد [set_AspectRatioLocked()](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ipictureframelock/set_aspectratiolocked/) برای تنظیم گزینه *Lock Aspect Ratio* استفاده کنید.  

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
این تنظیم *Lock Aspect Ratio* فقط نسبت ابعاد شکل را حفظ می‌کند و نه تصویری که داخل آن است. 
{{% /alert %}}

## **استفاده از ویژگی StretchOff**

با استفاده از ویژگی‌های [StretchOffsetLeft](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.picture_fill_format#ad730bf8db88f47979d84643eb30d1471), [StretchOffsetTop](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.picture_fill_format#aa512e1f022e9c7ff83e9c51ba100709a), [StretchOffsetRight](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.picture_fill_format#ac3597692f9b7e3327d0f4a4169a53127) و [StretchOffsetBottom](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.picture_fill_format#a72acf6945f372a5729c0b760f4a5dc39) از رابط [IPictureFillFormat](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.i_picture_fill_format) و کلاس [PictureFillFormat](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.picture_fill_format) می‌توانید یک مستطیل پرکننده را مشخص کنید.  

هنگامی که کشیدگی تصویر مشخص شود، یک مستطیل منبع به منظور مطابقت با مستطیل پرکننده تعیین‌شده مقیاس‌بندی می‌شود. هر لبه‌ای از مستطیل پرکننده توسط یک درصد افست نسبت به لبهٔ متناظر جعبهٔ مرزی شکل تعریف می‌شود. یک درصد مثبت یک تورفتگی (inset) را نشان می‌دهد. یک درصد منفی یک برون‌رفت (outset) را نشان می‌دهد.  

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.presentation) ایجاد کنید.  
2. مرجع یک اسلاید را از طریق اندیس آن دریافت کنید.  
3. یک مستطیل `AutoShape` اضافه کنید.  
4. یک تصویر ایجاد کنید.  
5. نوع پرکردن شکل را تنظیم کنید.  
6. حالت پرکردن تصویر شکل را تنظیم کنید.  
7. یک تصویر تنظیم‌شده برای پر کردن شکل اضافه کنید.  
8. افست‌های تصویر را نسبت به لبهٔ متناظر جعبهٔ مرزی شکل مشخص کنید.  
9. ارائه‌ی اصلاح‌شده را به‌عنوان فایل PPTX بنویسید.  

این کد C++ فرآیندی را نشان می‌دهد که در آن از ویژگی StretchOff استفاده می‌شود:  

``` cpp
auto pres = System::MakeObject<Presentation>();
auto ppImage = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));
auto slide = pres->get_Slide(0);
auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 400.0f, 400.0f, ppImage);

// تنظیم کشش تصویر از هر طرف در بدنه شکل
auto pictureFormat = pictureFrame->get_PictureFormat();
pictureFormat->set_PictureFillMode(PictureFillMode::Stretch);
pictureFormat->set_StretchOffsetLeft(24.0f);
pictureFormat->set_StretchOffsetRight(24.0f);
pictureFormat->set_StretchOffsetTop(24.0f);
pictureFormat->set_StretchOffsetBottom(24.0f);

pres->Save(u"imageStretch.pptx", SaveFormat::Pptx);
```

## **سوالات متداول**

**چگونه می‌توانم بفهمم کدام فرمت‌های تصویر برای PictureFrame پشتیبانی می‌شود؟**  
Aspose.Slides هم تصاویر رستر (PNG، JPEG، BMP، GIF و غیره) و هم تصاویر برداری (مثلاً SVG) را از طریق شیء تصویری که به یک [PictureFrame](https://reference.aspose.com/slides/fa/cpp/aspose.slides/pictureframe/) اختصاص داده می‌شود، پشتیبانی می‌کند. فهرست فرمت‌های پشتیبانی‌شده معمولاً با قابلیت‌های موتور تبدیل اسلاید و تصویر هم‌پوشانی دارد.

**افزودن ده‌ها تصویر بزرگ چگونه بر حجم و عملکرد PPTX تأثیر می‌گذارد؟**  
درج مستقیم تصاویر بزرگ حجم فایل و مصرف حافظه را افزایش می‌دهد؛ لینک دادن به تصاویر به کاهش حجم ارائه کمک می‌کند اما نیاز دارد فایل‌های خارجی در دسترس بمانند. Aspose.Slides امکان افزودن تصاویر به‌صورت لینک را برای کاهش حجم فایل فراهم می‌کند.

**چگونه می‌توانم یک شیء تصویر را از جابه‌جایی/تغییر اندازه تصادفی قفل کنم؟**  
از [قفل‌های شکل](https://reference.aspose.com/slides/fa/cpp/aspose.slides/pictureframe/get_pictureframelock/) برای یک [PictureFrame](https://reference.aspose.com/slides/fa/cpp/aspose.slides/pictureframe/) استفاده کنید (به‌عنوان مثال، غیرفعال کردن جابه‌جایی یا تغییر اندازه). مکانیزم قفل‌گذاری برای اشکال در یک مقاله‌ی جداگانه‌ی [حفاظت](/slides/fa/cpp/applying-protection-to-presentation/) توضیح داده شده است و برای انواع مختلف اشکال، از جمله [PictureFrame](https://reference.aspose.com/slides/fa/cpp/aspose.slides/pictureframe/) پشتیبانی می‌شود.

**آیا دقت برداری SVG هنگام صادرات ارائه به PDF/تصاویر حفظ می‌شود؟**  
Aspose.Slides امکان استخراج یک SVG از یک [PictureFrame](https://reference.aspose.com/slides/fa/cpp/aspose.slides/pictureframe/) را به‌عنوان بردار اصلی فراهم می‌کند. هنگام [صادرات به PDF](/slides/fa/cpp/convert-powerpoint-to-pdf/) یا [فرمت‌های رستر](/slides/fa/cpp/convert-powerpoint-to-png/)، نتیجه ممکن است بسته به تنظیمات صادرات به رستر تبدیل شود؛ این که SVG اصلی به‌صورت بردار ذخیره شده است توسط رفتار استخراج تأیید می‌شود.