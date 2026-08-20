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
- تصویر توکار
- تصویر پیوندی
- استخراج تصویر
- تصویر رستر
- تصویر SVG
- برش تصویر
- حذف نواحی برش‌خورده
- فشرده‌سازی تصویر
- StretchOffset
- قالب‌بندی قاب تصویر
- مقیاس نسبی
- افکت تصویر
- نسبت ابعاد
- PowerPoint
- OpenDocument
- ارائه
- C++
- Aspose.Slides
description: "ایجاد، قالب‌بندی، پیوند، برش، استخراج و فشرده‌سازی قاب‌های تصویر در ارائه‌ها با Aspose.Slides برای C++."
---
## **بررسی اجمالی**

قاب تصویر یک شکل اسلاید است که یک تصویر را نمایش می‌دهد. در Aspose.Slides، منبع تصویر و شکلی که آن را نشان می‌دهد به‌صورت اشیای جداگانه هستند: یک [ارائه](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) از طریق [مجموعه تصاویر](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/get_images/) خود منابع تصویر توکار را در اختیار دارد، در حالی که یک [IPictureFrame](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ipictureframe/) موقعیت، اندازه، قالب‌بندی خط، چرخش، برش، افکت‌های تصویر و دیگر تنظیمات سطح قاب را کنترل می‌کند.

این جداسازی زمانی مفید است که یک تصویر بیش از یک بار نمایش داده شود. تصویر را یک بار به ارائه اضافه کنید، شیء [IPPImage](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ippimage/) بازگشتی را نگه دارید و هنگام ایجاد قاب‌های تصویر از همان منبع تصویر استفاده کنید.

قاب‌های تصویر می‌توانند تصاویر رستر مانند PNG یا JPEG و تصاویر برداری SVG را در خود داشته باشند. همچنین می‌توانند به‌جای ذخیره بایت‌های تصویر در ارائه، به تصاویر پیوندی ارجاع دهند. این انتخاب بر قابلیت انتقال، حجم فایل، استخراج و رفتار صادرات تأثیر می‌گذارد، بنابراین پیش از اعمال قالب‌بندی یا بهینه‌سازی، تعیین نحوه ذخیره‌سازی تصویر مفید است.

## **افزودن و قالب‌بندی یک تصویر توکار**

برای یک تصویر توکار، داده‌های تصویر را به ارائه اضافه کنید و یک قاب تصویر با [IShapeCollection::AddPictureFrame](https://reference.aspose.com/slides/fa/cpp/aspose.slides/shapecollection/addpictureframe/) ایجاد کنید. تصویر بخشی از بسته ارائه می‌شود، بنابراین ارائه هنگام انتقال به کامپیوتر دیگر به‌صورت خودکفا باقی می‌ماند.

مثال زیر یک تصویر JPEG اضافه می‌کند، قاب را با ابعاد اصلی تصویر می‌سازد و قالب‌بندی خط و چرخش را اعمال می‌کند:

```cpp
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
#include <IImage.h>
#include <Util/Images.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto sourceImage = Images::FromFile(u"photo.jpg");
auto image = presentation->get_Images()->AddImage(sourceImage);

auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 100, image->get_Width(), image->get_Height(), image);
pictureFrame->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
pictureFrame->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
pictureFrame->get_LineFormat()->set_Width(3.0);
pictureFrame->set_Rotation(15.0f);

presentation->Save(u"picture-frame.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

قاب تصویر هندسه نمایش داده شده را کنترل می‌کند؛ تغییر اندازه قاب ابعاد پیکسل اصلی ذخیره‌شده در منبع تصویر توکار را تغییر نمی‌دهد. این تمایز زمانی مهم می‌شود که بعدها بخواهید تصویر را برش یا فشرده‌سازی کنید.

## **استفاده از مقیاس نسبی**

[IPictureFrame](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ipictureframe/) مقیاس عرض و ارتفاع نسبی برای قاب را در اختیار می‌گذارد. مقدار `1.0` معادل 100٪ از اندازه اصلی تصویر است. مقیاس نسبی زمانی مفید است که یک جریان کاری نیاز داشته باشد نسبت به اندازه منبع تصویر حفظ شود به‌جای محاسبه دستی ابعاد نهایی.

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto sourceImage = Images::FromFile(u"photo.jpg");
auto image = presentation->get_Images()->AddImage(sourceImage);

auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, image);
pictureFrame->set_RelativeScaleWidth(1.35f);
pictureFrame->set_RelativeScaleHeight(0.8f);

presentation->Save(u"relative-scale.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

مقیاس نسبی تنظیمات مقیاس قاب را تغییر می‌دهد؛ تصویر توکار را بازنمونه‌گیری یا فشرده نمی‌کند.

## **تصاویر توکار و پیوندی**

یک تصویر توکار داده‌های تصویر را داخل ارائه ذخیره می‌کند و بنابراین برای قابلیت انتقال و رندر پیش‌بینی‌شده ایمن‌ترین گزینه است. یک تصویر پیوندی مسیر خارجی را از طریق مسیر پیوند [ISlidesPicture](https://reference.aspose.com/slides/fa/cpp/aspose.slides/islidespicture/) ذخیره می‌کند به‌جای تعبیه داده‌های تصویر به همان روش.

تصاویر پیوندی می‌توانند مقدار داده‌های تصویر ذخیره‌شده در PPTX را کاهش دهند، اما یک وابستگی خارجی ایجاد می‌کنند. فایل پیوندی باید برای برنامه‌ای که ارائه را باز یا رندر می‌کند در دسترس باقی بماند. اگر مسیر تغییر کند، فایل جابجا شود یا منبع در دسترس نباشد، تصویر پیوندی ممکن است همان‌طور که انتظار می‌رود نمایش داده نشود. برای ارائه‌هایی که باید ایمیل شوند، بایگانی شوند یا در محیط‌های ایزوله رندر شوند، تصاویر توکار معمولاً قابل اعتمادترند.

### **افزودن یک تصویر پیوندی**

مثال زیر یک قاب تصویر ایجاد می‌کند و آن را به یک فایل تصویر محلی اشاره می‌دهد. این مثال فقط به‌پیوند تصویر می‌پردازد؛ پیوند ویدیو یک جریان کاری رسانه‌ای جداگانه است و عمداً در این مثال ترکیب نشده است.

```cpp
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/io/path.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 320, 180, nullptr);
auto linkPath = Path::GetFullPath(u"linked-image.jpg");
pictureFrame->get_PictureFormat()->get_Picture()->set_LinkPathLong(linkPath);

presentation->Save(u"linked-image.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

از پیوندها زمانی استفاده کنید که مدیریت فایل‌های خارجی هدفمند باشد. از آن‌ها صرفاً به‌عنوان جایگزینی برای فشرده‌سازی استفاده نکنید: یک PPTX کوچک با وابستگی‌های تصویر شکسته معمولاً کمتر مفید است نسبت به یک ارائه بزرگ‌تر خودکفا.

## **استخراج تصاویر از قاب‌های تصویر**

قبل از استخراج یک تصویر از یک ارائه موجود، بررسی کنید که شکل واقعاً یک [IPictureFrame](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ipictureframe/) باشد و شامل یک تصویر توکار باشد. قاب‌های تصویر پیوندی ممکن است بایت‌های تصویری که بتوان به همان شکل استخراج کرد، نداشته باشند.

### **استخراج یک تصویر رستر**

API تصویر مدرن مستقیماً از [IImage](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iimage/) استفاده می‌کند. مثال زیر اولین تصویر رستری توکار روی یک اسلاید را پیدا می‌کند و به‌صورت PNG ذخیره می‌نماید:

```cpp
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

for (auto&& shape : slide->get_Shapes())
{
    if (!ObjectExt::Is<IPictureFrame>(shape))
    {
        continue;
    }

    auto pictureFrame = ExplicitCast<IPictureFrame>(shape);
    auto embeddedImage = pictureFrame->get_PictureFormat()->get_Picture()->get_Image();
    if (embeddedImage == nullptr || embeddedImage->get_SvgImage() != nullptr)
    {
        continue;
    }

    auto rasterImage = embeddedImage->get_Image();
    rasterImage->Save(u"extracted-image.png", ImageFormat::Png);
    break;
}

presentation->Dispose();
```

ذخیره از طریق [IImage](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iimage/) تصویر استخراج‌شده را به قالب خروجی درخواست‌شده تبدیل می‌کند. اگر به بایت‌های رمزنگاری‌شده‌ای که در ارائه ذخیره شده‌اند به‌جای یک فایل رستر تبدیل‌شده نیاز دارید، به‌جای آن از داده‌های دودویی منبع تصویر استفاده کنید.

### **استخراج یک تصویر SVG**

برای یک تصویر SVG، [IPPImage](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ippimage/) یک شیء [ISvgImage](https://reference.aspose.com/slides/fa/cpp/aspose.slides/isvgimage/) را در اختیار می‌گذارد. این امکان را می‌دهد که داده‌های SVG را مستقیماً بازیابی کنید به‌جای رستری‌سازی تصویر ابتدا.

```cpp
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
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

for (auto&& shape : slide->get_Shapes())
{
    if (!ObjectExt::Is<IPictureFrame>(shape))
    {
        continue;
    }

    auto pictureFrame = ExplicitCast<IPictureFrame>(shape);
    auto embeddedImage = pictureFrame->get_PictureFormat()->get_Picture()->get_Image();
    if (embeddedImage == nullptr)
    {
        continue;
    }

    auto svgImage = embeddedImage->get_SvgImage();
    if (svgImage == nullptr)
    {
        continue;
    }

    File::WriteAllBytes(u"extracted-image.svg", svgImage->get_SvgData());
    break;
}

presentation->Dispose();
```

نگه داشتن محتوای SVG به‌عنوان SVG، منبع برداری داخل ارائه را حفظ می‌کند. صادرات به رستر مانند PNG یا JPEG مجبور به رندر آن محتوا به پیکسل است. صادرات اسلاید به PDF یا SVG نیز یک عملیات رندر است، بنابراین گرافیک‌های صادرشده نباید به‌عنوان یک کپی بایت‌به‌بایت از SVG توکار اصلی در نظر گرفته شوند؛ هنگام نیاز به منبع برداری اصلی، از داده‌های [ISvgImage](https://reference.aspose.com/slides/fa/cpp/aspose.slides/isvgimage/) توکار استفاده کنید.

## **برش یک تصویر**

برش تعیین می‌کند که کدام بخش از تصویر داخل قاب قابل مشاهده باشد. مقادیر برش در [IPictureFillFormat](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ipicturefillformat/) به‌صورت درصدی از ابعاد تصویر منبع هستند. برش در ابتدا پیکسل‌های مخفی را از تصویر توکار حذف نمی‌کند؛ تنها ناحیه قابل مشاهده را تغییر می‌دهد.

مثال زیر یک قاب تصویر را به‌صورت ایمن پیدا می‌کند و مقادیر برش را اعمال می‌نماید:

```cpp
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);
SharedPtr<IPictureFrame> pictureFrame;

for (auto&& shape : slide->get_Shapes())
{
    if (ObjectExt::Is<IPictureFrame>(shape))
    {
        pictureFrame = ExplicitCast<IPictureFrame>(shape);
        break;
    }
}

if (pictureFrame != nullptr)
{
    pictureFrame->get_PictureFormat()->set_CropLeft(23.6f);
    pictureFrame->get_PictureFormat()->set_CropRight(21.5f);
    pictureFrame->get_PictureFormat()->set_CropTop(3.0f);
    pictureFrame->get_PictureFormat()->set_CropBottom(31.0f);
    presentation->Save(u"cropped-image.pptx", SaveFormat::Pptx);
}

presentation->Dispose();
```

از آنجا که داده‌های تصویر مخفی هنوز وجود دارند، می‌توان برش را پس از آن تغییر داد بدون از دست دادن پیکسل‌های اصلی. اگر حجم فایل مهم‌تر از قابلیت بازگردانی باشد، نواحی برش‌شده می‌توانند همان‌طور که در بخش بعدی توضیح داده شد، به‌صورت فیزیکی حذف شوند.

## **حذف داده‌های تصویر برش‌خورده**

[IPictureFillFormat::DeletePictureCroppedAreas](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) داده‌های تصویری خارج از مستطیل برش فعلی را حذف می‌کند و منبع تصویر حاصل را برمی‌گرداند. این می‌تواند حجم فایل را کاهش دهد، اما یک بهینه‌سازی مخرب است: پس از ذخیره ارائه، پیکسل‌های حذف‌شده دیگر برای عمل بازبرش در دسترس نیستند.

```cpp
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"cropped-image.pptx");
auto slide = presentation->get_Slide(0);
SharedPtr<IPictureFrame> pictureFrame;

for (auto&& shape : slide->get_Shapes())
{
    if (ObjectExt::Is<IPictureFrame>(shape))
    {
        pictureFrame = ExplicitCast<IPictureFrame>(shape);
        break;
    }
}

if (pictureFrame != nullptr)
{
    auto croppedImage = pictureFrame->get_PictureFormat()->DeletePictureCroppedAreas();
    if (croppedImage != nullptr)
    {
        presentation->Save(u"cropped-data-removed.pptx", SaveFormat::Pptx);
    }
}

presentation->Dispose();
```

این متد ممکن است منبع تصویر جدیدی به ارائه اضافه کند. اگر تصویر اصلی توسط قاب‌های تصویر دیگر نیز استفاده شود، آن قاب‌ها همچنان به منبع موجود خود نیاز دارند، بنابراین حذف نواحی برش‌شده لزوماً تعداد کل تصاویر را کاهش نمی‌دهد. برش محتوای WMF یا EMF با این متد نتیجه برش‌شده را به PNG رستری می‌کند.

## **فشرده‌سازی تصاویر رستر**

[IPictureFillFormat::CompressImage](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ipicturefillformat/compressimage/) وضوح تصویر رستر را نسبت به اندازه‌ای که تصویر نمایش داده می‌شود کم می‌کند. همچنین می‌تواند نواحی برش‌شده را در همان عملیات حذف کند. این متد وقتی تصویر تغییر اندازه یا برش داده شد `true` و وقتی تغییری لازم نباشد `false` برمی‌گرداند.

یک مقدار پیش‌تعریف‌شده [PicturesCompression](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/picturescompression/) را وقتی رزولوشن هدف استاندارد کافی باشد، استفاده کنید:

```cpp
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/PicturesCompression.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);
SharedPtr<IPictureFrame> pictureFrame;

for (auto&& shape : slide->get_Shapes())
{
    if (ObjectExt::Is<IPictureFrame>(shape))
    {
        pictureFrame = ExplicitCast<IPictureFrame>(shape);
        break;
    }
}

if (pictureFrame != nullptr)
{
    auto compressed = pictureFrame->get_PictureFormat()->CompressImage(true, PicturesCompression::Dpi150);
    Console::WriteLine(compressed ? String(u"The image was compressed.") : String(u"No compression was necessary."));
    presentation->Save(u"compressed-image.pptx", SaveFormat::Pptx);
}

presentation->Dispose();
```

به‌جای مقدار enum می‌توانید یک مقدار DPI مثبت سفارشی را هنگام نیاز به هدف خاص پاس دهید.

فشرده‌سازی برای تصاویر رستر در نظر گرفته شده است. محتوای SVG و متافایل توسط این جریان کاری فشرده‌سازی رستر کاهش نمی‌یابد. همچنین به خاطر داشته باشید که وضوح پایین‌تر و نواحی برش‌شده حذف‌شده نمی‌توانند از ارائه بهینه‌شده بازیابی شوند. یک رزولوشن هدف را بر پایه بزرگ‌ترین اندازه‌ای که تصویر واقعاً مشاهده یا صادر خواهد شد، انتخاب کنید نه بر پایه کمترین DPI به‌صورت سراسری.

## **بازرسی افکت‌های تصویر**

افکت‌های تصویر بر روی تصویر استفاده‌شده توسط قاب ذخیره می‌شوند. مجموعه تبدیل تصویر می‌تواند افکت‌هایی مانند مدولاسیون ثابت آلفا برای شفافیت و لومنانس برای روشنایی و کنتراست داشته باشد. مثال زیر به‌صورت ایمن هر دو نوع افکت را از اولین قاب تصویر روی یک اسلاید می‌خواند:

```cpp
#include <DOM/Effects/IAlphaModulateFixed.h>
#include <DOM/Effects/IImageTransformOperationCollection.h>
#include <DOM/Effects/ILuminance.h>
#include <DOM/Effects/ILuminanceEffectiveData.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Effects;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);
SharedPtr<IPictureFrame> pictureFrame;

for (auto&& shape : slide->get_Shapes())
{
    if (ObjectExt::Is<IPictureFrame>(shape))
    {
        pictureFrame = ExplicitCast<IPictureFrame>(shape);
        break;
    }
}

if (pictureFrame != nullptr)
{
    auto imageTransform = pictureFrame->get_PictureFormat()->get_Picture()->get_ImageTransform();

    for (auto&& effect : imageTransform)
    {
        if (ObjectExt::Is<IAlphaModulateFixed>(effect))
        {
            auto alphaModulateFixed = ExplicitCast<IAlphaModulateFixed>(effect);
            auto transparency = 100.0f - alphaModulateFixed->get_Amount();
            Console::WriteLine(String(u"Transparency: ") + transparency);
        }

        if (ObjectExt::Is<ILuminance>(effect))
        {
            auto luminanceEffect = ExplicitCast<ILuminance>(effect);
            auto luminance = luminanceEffect->GetEffective();
            Console::WriteLine(String(u"Brightness: ") + luminance->get_Brightness());
            Console::WriteLine(String(u"Contrast: ") + luminance->get_Contrast());
        }
    }
}

presentation->Dispose();
```

این افکت‌ها نحوه رندر تصویر در قاب را تغییر می‌دهند؛ بایت‌های تصویر توکار اصلی را بازنویسی نمی‌کنند.

## **قفل کردن هندسه قاب تصویر**

تنظیمات [IPictureFrameLock](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ipictureframelock/) تعیین می‌کنند که کدام عملیات ویرایشی برای یک قاب تصویر غیر فعال باشد. به‌عنوان مثال، [قفل نسبت-ابعاد](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ipictureframelock/set_aspectratiolocked/) نسبت‌های شکل را هنگام تغییر اندازه حفظ می‌کند.

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IPictureFrameLock.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto sourceImage = Images::FromFile(u"photo.jpg");
auto image = presentation->get_Images()->AddImage(sourceImage);

auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 100, image->get_Width(), image->get_Height(), image);
pictureFrame->get_PictureFrameLock()->set_AspectRatioLocked(true);

presentation->Save(u"locked-picture-frame.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

قفل به شکل قاب تصویر اعمال می‌شود. این قفل باعث نمی‌شود تصویر منبع بازنمونه‌گیری یا به‌صورت دائمی به همان نسبت ابعاد تبدیل شود.

## **تنظیم مقادیر StretchOffset**

وقتی حالت پر کردن تصویر استretch، مقادیر stretch‑offset در [IPictureFillFormat](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ipicturefillformat/) مستطیل پر کردن را نسبت به جعبه محدودهٔ قاب تصویر تعریف می‌کند. درصدهای مثبت یک حاشیه داخلی از لبه ایجاد می‌کنند، در حالی که درصدهای منفی یک حاشیه خارجی می‌سازند.

این امر متفاوت از برش است. مقادیر برش تعیین می‌کند کدام بخش از تصویر منبع قابل مشاهده باشد؛ در حالی که stretch‑offset مستطیل را که تصویر قابل مشاهده داخل آن کشیده می‌شود، تغییر می‌دهد.

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto sourceImage = Images::FromFile(u"photo.png");
auto image = presentation->get_Images()->AddImage(sourceImage);

auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10, 10, 400, 300, image);
pictureFrame->get_PictureFormat()->set_PictureFillMode(PictureFillMode::Stretch);
pictureFrame->get_PictureFormat()->set_StretchOffsetLeft(12.0f);
pictureFrame->get_PictureFormat()->set_StretchOffsetRight(12.0f);
pictureFrame->get_PictureFormat()->set_StretchOffsetTop(8.0f);
pictureFrame->get_PictureFormat()->set_StretchOffsetBottom(8.0f);

presentation->Save(u"stretch-offsets.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

از stretch‑offset برای جایگذاری پر کردن استفاده کنید. از خصوصیات برش زمانی استفاده کنید که هدف مخفی کردن لبه‌های تصویر منبع باشد.

## **نگهداری، حجم فایل و ملاحظات صادرات**

مبادلات اصلی زمانی آسان‌تر مدیریت می‌شوند که ذخیره‌سازی تصویر و قالب‌بندی قاب تصویر به‌صورت جداگانه در نظر گرفته شوند:

- **تصاویر توکار** ارائه را خودکفا می‌سازند و برای به‌اشتراک‌گذاری و رندر سمت سرور قابل اطمینانترین گزینه‌اند، اما تصاویر رستر بزرگ حجم PPTX و مصرف حافظه را افزایش می‌دهند.
- **تصاویر پیوندی** می‌توانند بسته را کوچک‌تر نگه دارند، اما ارائه به فایل‌های خارجی موجود در مسیرهای ذخیره‌شده وابسته می‌شود.
- **برش** در ابتدا مخرب نیست. پیکسل‌های مخفی تا زمانی که نواحی برش‌شده به‌طور صریح حذف یا در طول فشرده‌سازی حذف نشوند، توکار می‌مانند.
- **فشرده‌سازی** می‌تواند حجم فایل را برای تصاویر رستر بزرگ به‌مرسوم کاهش دهد، اما وضوح منبع را قربانی می‌کند. این کار باید پس از دانستن اندازه نهایی تصویر روی اسلاید انجام شود.
- **تصاویر SVG** باید به‌عنوان SVG باقی بمانند وقتی که حفظ بردار مهم است. SVG توکار را به‌طور مستقیم استخراج کنید وقتی به منبع برداری خود نیاز دارید. صادرات اسلایدهای رستر همیشه اسلاید رندرشده را به پیکسل تبدیل می‌کنند.
- **تصاویر تکراری** باید در صورت امکان از یک منبع [IPPImage](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ippimage/) موجود استفاده کنند به‌جای بارگذاری مکرر همان فایل در جریان کار ارائه.

برای ارائه‌های بزرگ، بهینه‌سازی تصویر معمولاً زمانی مؤثرترین است که به‌صورت انتخابی انجام شود: لوگوها و نمودارها را به‌عنوان محتوای برداری نگه دارید، عکس‌ها را بر حسب اندازه واقعی نمایش‌شان فشرده کنید، پیکسل‌های برش‌خورده را تنها زمانی حذف کنید که بعداً به ویرایش نیاز نباشد و از پیوندهای خارجی تا زمانی که مدیریت وابستگی بخشی از طراحی استقرار باشد، خودداری کنید.

## **پرسش‌های متداول**

**تفاوت بین قاب تصویر و منبع تصویر چیست؟**

یک [IPPImage](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ippimage/) نمایانگر یک منبع تصویر مرتبط با ارائه است. یک [IPictureFrame](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ipictureframe/) یک شکل روی اسلاید است که تصویر را نمایش می‌دهد و هندسه و قالب‌بندی سطح قاب مانند اندازه، چرخش، مقادیر برش، افکت‌ها و قفل‌ها را ذخیره می‌کند.

**آیا باید تصاویر را توکار کنم یا پیوندی؟**

وقتی ارائه باید قابل حمل، بایگانی یا بدون دسترسی به منابع خارجی رندر شود، تصاویر را توکار کنید. فقط وقتی نگهداری فایل‌های تصویر خارج از PPTX هدفمند است و مکان‌های خارجی می‌توانند به‌صورت قابل اعتماد حفظ شوند، از پیوند استفاده کنید.

**آیا برش حجم فایل PPTX را کاهش می‌دهد؟**

خود برش این کار را نمی‌کند. تنظیمات برش عادی بخش‌هایی از تصویر منبع را مخفی می‌کند اما پیکسل‌های زیرین را نگه می‌دارد. برای حذف دائمی این پیکسل‌ها از [IPictureFillFormat::DeletePictureCroppedAreas](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) یا فشرده‌سازی تصویر با حذف نواحی برش‌شده استفاده کنید.

**آیا می‌توانم کیفیت تصویر را پس از فشرده‌سازی بازگردانم؟**

خیر. فشرده‌سازی می‌تواند وضوح رستر ذخیره‌شده را کاهش دهد و حذف نواحی برش‌شده داده‌های تصویر را از بین می‌برد. اگر ویرایش با وضوح بالا بعداً ممکن است لازم شود، تصویر اصلی را خارج از ارائه نگه دارید.

**چگونه باید با تصاویر SVG رفتار کنم؟**

هنگامی که حفظ صحت بردار مهم است، محتوای SVG را به‌عنوان SVG نگه دارید. می‌توانید [ISvgImage](https://reference.aspose.com/slides/fa/cpp/aspose.slides/isvgimage/) توکار را به‌صورت مستقیم استخراج کنید. رندر اسلاید به فرمت رستر مانند PNG یا JPEG، SVG را به پیکسل تبدیل می‌کند.

**چگونه می‌توانم از تبدیل‌های ناامن هنگام خواندن اسلایدهای موجود جلوگیری کنم؟**

قبل از استفاده از اعضای خاص قاب تصویر، نوع شکل را بررسی کنید. ابتدا شکل را با [IPictureFrame](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ipictureframe/) تست کنید، سپس تبدیل زمان اجرا را انجام دهید و نتیجه تبدیل را به یک متغیر محلی اختصاص دهید قبل از دسترسی به اعضای خاص قاب تصویر.