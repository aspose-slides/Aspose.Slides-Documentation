---
title: "مدیریت فریم‌های تصویر در ارائه‌ها با استفاده از C++"
linktitle: "فریم تصویر"
type: docs
weight: 10
url: /fa/cpp/picture-frame/
keywords:
- "فریم تصویر"
- "افزودن فریم تصویر"
- "ایجاد فریم تصویر"
- "تصویر جاسازی‌شده"
- "تصویر لینک‌شده"
- "استخراج تصویر"
- "تصویر رستر"
- "تصویر SVG"
- "برش تصویر"
- "حذف نواحی برش‌خورده"
- "فشرده‌سازی تصویر"
- "StretchOffset"
- "قالب‌بندی فریم تصویر"
- "مقیاس نسبی"
- "افکت تصویر"
- "نسبت طول‑عرض"
- "PowerPoint"
- "OpenDocument"
- "ارائه"
- "C++"
- "Aspose.Slides"
description: "ایجاد، قالب‌بندی، لینک‌دادن، برش، استخراج و فشرده‌سازی فریم‌های تصویر در ارائه‌ها با Aspose.Slides برای C++."
---
## **نمای کلی**

یک فریم تصویر (Picture Frame) یک شکل اسلاید است که تصویر را نمایش می‌دهد. در Aspose.Slides، منبع تصویر و شکلی که آن را نمایش می‌دهد اشیای جداگانه‌ای هستند: یک [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) منابع تصویر جاسازی‑شده را از طریق [image collection](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/get_images/) خود مدیریت می‌کند، در حالی که یک [IPictureFrame](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ipictureframe/) موقعیت، اندازه، قالب‌بندی خط، چرخش، برش، افکت‌های تصویری و دیگر تنظیمات سطح فریم را کنترل می‌کند.

این جداسازی زمانی مفید است که همان تصویر بیش از یک بار نمایش داده شود. تصویر را یک بار به ارائه اضافه کنید، شیء [IPPImage](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ippimage/) بازگردانده‌شده را نگه دارید و هنگام ایجاد فریم‌های تصویری از آن منبع تصویر استفاده کنید.

فریم‌های تصویری می‌توانند تصاویر رستر مانند PNG یا JPEG و همچنین تصاویر برداری SVG را در بر بگیرند. همچنین می‌توانند به تصاویر لینک‌شده ارجاع دهند به‌جای این‌که بایت‌های تصویر را در ارائه ذخیره کنند. انتخاب این گزینه بر قابلیت حمل، حجم فایل، استخراج و رفتار خروجی تأثیر می‌گذارد، بنابراین پیش از اعمال قالب‌بندی یا بهینه‌سازی تصمیم‌گیری درباره نحوه ذخیره‌سازی تصویر اهمیت دارد.

## **افزودن و قالب‌بندی تصویر جاسازی‌شده**

برای یک تصویر جاسازی‌شده، داده‌های تصویر را به ارائه اضافه کنید و یک فریم تصویری با [IShapeCollection::AddPictureFrame](https://reference.aspose.com/slides/fa/cpp/aspose.slides/shapecollection/addpictureframe/) بسازید. تصویر بخشی از بسته ارائه می‌شود، بنابراین ارائه هنگام انتقال به رایانهٔ دیگری خودکفا می‌ماند.

مثال زیر یک تصویر JPEG اضافه می‌کند، فریمی با ابعاد اصلی تصویر ایجاد می‌کند و قالب‌بندی خط و چرخش را اعمال می‌نماید:

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

فریم تصویری هندسهٔ نمایش‌داده‌شده را کنترل می‌کند؛ تغییر اندازه فریم ابعاد پیکسل اصلی ذخیره‌شده در منبع تصویر جاسازی‌شده را تغییر نمی‌دهد. این تمایز هنگام برش یا فشرده‌سازی تصویر بعدها مهم می‌شود.

## **استفاده از مقیاس نسبی**

[IPictureFrame](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ipictureframe/) مقیاس‌گذاری عرض و ارتفاع نسبی برای فریم را فراهم می‌کند. مقدار `1.0` برابر با 100٪ اندازهٔ تصویر اصلی است. مقیاس نسبی زمانی مفید است که یک جریان کاری نیاز داشته باشد نسبت به اندازهٔ منبع تصویر حفظ شود به‌جای محاسبهٔ ابعاد نهایی به‌صورت دستی.

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

مقیاس نسبی تنظیمات مقیاس فریم را تغییر می‌دهد؛ تصویر جاسازی‌شده را بازنمونه‌گیری یا فشرده نمی‌کند.

## **تصاویر جاسازی‌شده و لینک‌شده**

یک تصویر جاسازی‌شده داده‌های تصویر را داخل ارائه ذخیره می‌کند و بنابراین ایمن‌ترین گزینه برای قابلیت حمل و رندر پیش‌بینی‌شده است. یک تصویر لینک‌شده مسیر خارجی را از طریق ویژگی لینک [ISlidesPicture](https://reference.aspose.com/slides/fa/cpp/aspose.slides/islidespicture/) ذخیره می‌کند به‌جای جاسازی داده‌ها.

تصاویر لینک‌شده می‌توانند میزان دادهٔ تصویر ذخیره‌شده در PPTX را کاهش دهند، اما وابستگی خارجی ایجاد می‌کنند. فایل لینک‌شده باید برای برنامه‌ای که ارائه را باز یا رندر می‌کند در دسترس بماند. اگر مسیر تغییر کند، فایل منتقل شود یا منبع در دسترس نباشد، تصویر لینک‌شده ممکن است همان‌طور که انتظار می‌رود نمایش داده نشود. برای ارائه‌هایی که باید ایمیل شوند، بایگانی شوند یا در محیط‌های ایزوله رندر شوند، تصاویر جاسازی‌شده معمولاً قابل اعتمادتر هستند.

### **افزودن تصویر لینک‌شده**

مثال زیر یک فریم تصویری ایجاد می‌کند و آن را به یک فایل تصویری محلی ارجاع می‌دهد. این مثال فقط به لینک‌دادن تصویر می‌پردازد؛ لینک‌دادن ویدیو یک جریان کاری رسانه‌ای جداگانه است و به‌صورت عمدی در این مثال ترکیب نشده است.

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

از لینک‌ها زمانی استفاده کنید که مدیریت فایل خارجی به‌طور عمدی انجام می‌شود. از آنها صرفاً به‌عنوان جایگزینی برای فشرده‌سازی استفاده نکنید: یک PPTX کوچک با وابستگی‌های تصویر خراب معمولاً کمتر مفید است نسبت به یک ارائهٔ بزرگتر خودکفا.

## **استخراج تصاویر از فریم‌های تصویری**

پیش از استخراج تصویر از یک ارائه موجود، بررسی کنید که شکل واقعاً یک [IPictureFrame](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ipictureframe/) است و حاوی تصویر جاسازی‌شده می‌باشد. فریم‌های تصویری لینک‌شده ممکن است بایت‌های تصویری نداشته باشند که به همان روش استخراج شوند.

### **استخراج یک تصویر رستر**

API تصویر مدرن به‌صورت مستقیم از [IImage](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iimage/) استفاده می‌کند. مثال زیر اولین تصویر رستر جاسازی‌شده را در یک اسلاید پیدا می‌کند و به‌صورت PNG ذخیره می‌نماید:

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

ذخیره‌سازی از طریق [IImage](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iimage/) تصویر استخراج‌شده را به فرمت خروجی درخواستی تبدیل می‌کند. اگر به بایت‌های رمزگذاری‌شدهٔ ذخیره‌شده در ارائه نیاز داشته باشید نه به یک فایل رستر تبدیل‌شده، به‌جای آن از داده‌های باینری منبع تصویر استفاده کنید.

### **استخراج یک تصویر SVG**

برای یک تصویر SVG، شیء [IPPImage](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ippimage/) یک شیء [ISvgImage](https://reference.aspose.com/slides/fa/cpp/aspose.slides/isvgimage/) را در اختیار می‌گذارد. این امکان را می‌دهد که داده‌های SVG را به‌صورت مستقیم دریافت کنید به‌جای اینکه ابتدا تصویر را رستر کنید.

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

نگه‌داشتن محتوای SVG به‌عنوان SVG، منبع برداری داخل ارائه را حفظ می‌کند. خروجی‌های رستری مانند PNG یا JPEG مجبورند آن محتوا را به پیکسل تبدیل کنند. خروجی اسلاید به PDF یا SVG نیز یک عملیات رندر است، بنابراین گرافیک‌های خروجی نباید به‌عنوان یک کپی بایت‑به‑بایت از SVG جاسازی‌شده در نظر گرفته شوند؛ هنگامی که به منبع برداری اصلی نیاز باشد، از دادهٔ [ISvgImage](https://reference.aspose.com/slides/fa/cpp/aspose.slides/isvgimage/) جاسازی‌شده استفاده کنید.

## **برش تصویر**

برش تعیین می‌کند که کدام بخش تصویر داخل فریم قابل مشاهده است. مقادیر برش در [IPictureFillFormat](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ipicturefillformat/) درصدی از ابعاد تصویر منبع هستند. برش اولیه بایت‌های مخفی را از تصویر جاسازی‌شده حذف نمی‌کند؛ فقط منطقهٔ قابل مشاهده را تغییر می‌دهد.

مثال زیر فریم تصویری را به‌طور ایمن پیدا می‌کند و مقادیر برش را اعمال می‌نماید:

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

از آنجایی که دادهٔ تصویر مخفی هنوز حضور دارد، می‌توان برش را بعدها بدون از دست دادن پیکسل‌های اصلی تغییر داد. اگر حجم فایل مهم‌تر از قابلیت بازگردانی باشد، می‌توان نواحی برش خورده را همان‌طور که در بخش بعدی توضیح داده شده فیزیکی حذف کرد.

## **حذف دادهٔ تصویر برش‑خورده**

[IPictureFillFormat::DeletePictureCroppedAreas](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) دادهٔ تصویری خارج از مستطیل برش جاری را حذف می‌کند و منبع تصویر حاصل را برمی‌گرداند. این می‌تواند حجم فایل را کاهش دهد، اما یک بهینه‌سازی مخرب است: پس از ذخیرهٔ ارائه، پیکسل‌های حذف‌شده دیگر برای عملیات باز‑برش در دسترس نیستند.

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

این متد ممکن است منبع تصویر جدیدی به ارائه اضافه کند. اگر تصویر اصلی توسط فریم‌های تصویری دیگر نیز استفاده شود، آن فریم‌ها همچنان به منبع موجود خود نیاز دارند، بنابراین حذف نواحی برش‌خورده لزوماً تعداد کل تصاویر را کاهش نمی‌دهد. برش محتواهای WMF یا EMF با این متد نتیجهٔ برش را به PNG رستر می‌کند.

## **فشرده‌سازی تصاویر رستر**

[IPictureFillFormat::CompressImage](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ipicturefillformat/compressimage/) وضوح تصویر رستر را نسبت به اندازه‌ای که تصویر در آن نمایش داده می‌شود کاهش می‌دهد. همچنین می‌تواند نواحی برش‌خورده را در همان عملیات حذف کند. این متد وقتی تصویر تغییر اندازه یا برش داده شد `true` و وقتی تغییری لازم نباشد `false` برمی‌گرداند.

زمانی که یک وضوح هدف استاندارد کافی است، می‌توانید از مقدار پیش‌تعریف‌شدهٔ [PicturesCompression](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/picturescompression/) استفاده کنید:

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

در صورتی که هدف خاصی نیاز باشد می‌توانید به‌جای مقدار enum، یک مقدار DPI مثبت سفارشی ارائه دهید.

فشرده‌سازی برای تصاویر رستر در نظر گرفته شده است. محتویات SVG و متافایل توسط این جریان کاری فشرده‌سازی رستر کاهش نمی‌یابد. همچنین به یاد داشته باشید که وضوح پایین‌تر و نواحی برش‌خورده حذف‌شده قابل بازیابی از ارائه بهینه‌شده نیستند. وضوح هدف را بر پایهٔ بزرگ‌ترین اندازه‌ای که تصویر در واقع مشاهده یا خروجی می‌شود انتخاب کنید نه این‌که به‌صورت سراسری کم‌ترین DPI را اعمال کنید.

## **مدیریت افکت‌های تبدیل تصویر**

برای یک جریان کاری کامل شامل روشنایی، کنتراست، تبدیلات رنگ، تاری، افکت‌های آلفا، زنجیره‌های ترتیبی، بازبینی، حذف و تأیید دورگرد، به [Image Transform Effects](/slides/fa/cpp/image-transform-effects/) مراجعه کنید.

## **قفل‌کردن هندسهٔ فریم تصویر**

تنظیمات [IPictureFrameLock](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ipictureframelock/) تعیین می‌کند که کدام عملیات‌های ویرایشی برای فریم تصویر غیرفعال باشند. به‌عنوان مثال، [قفل نسبت طول‑عرض](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ipictureframelock/set_aspectratiolocked/) هنگام تغییر اندازه، تناسبات شکل را حفظ می‌کند.

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

قفل بر روی شکل فریم تصویر اعمال می‌شود. این قفل منبع تصویر را به‌صورت بازنمونه‌گیری یا تغییر دائمی به همان نسبت طول‑عرض مجبور نمی‌کند.

## **تنظیم مقادیر StretchOffset**

زمانی که حالت پر کردن تصویر به صورت کشیده (stretch) باشد، مقادیر stretch‑offset در [IPictureFillFormat](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ipicturefillformat/) مستطیل پر کردن را نسبت به جعبه مرزی فریم تصویر تعریف می‌کند. درصدهای مثبت یک حاشیهٔ داخلی از لبه ایجاد می‌کنند، در حالی که درصدهای منفی یک حاشیهٔ خارجی ایجاد می‌نمایند.

این متفاوت از برش است. مقادیر برش تعیین می‌کنند کدام بخش تصویر منبع قابل مشاهده است؛ مقادیر stretch‑offset مستطیلی را که پر کردن تصویر در آن کشیده می‌شود تغییر می‌دهند.

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

از stretch‑offset برای جایگذاری پر کردن استفاده کنید. هنگامی که هدف مخفی‌سازی لبه‌های تصویر منبع است، از ویژگی‌های برش استفاده کنید.

## **نگهداری، حجم ملف و ملاحظات خروجی**

معاملهٔ اصلی زمانی ساده‌تر می‌شود که ذخیره‌سازی تصویر و قالب‌بندی فریم‑تصویر جداگانه برخوردار باشند:

- **تصاویر جاسازی‌شده** ارائه را خودکفا می‌سازند و برای به‌اشتراک‌گذاری و رندر سمت سرور قابل اعتمادترین گزینه‌اند، اما تصاویر رستر بزرگ حجم PPTX و مصرف حافظه را افزایش می‌دهند.
- **تصاویر لینک‌شده** می‌توانند بستهٔ پرونده را کوچکتر نگه دارند، اما ارائه به فایل‌های خارجی در مسیرهای ذخیره‌شده وابسته می‌شود.
- **برش** در ابتدا مخرب نیست. پیکسل‌های مخفی تا زمان حذف صریح نواحی برش یا حذف در هنگام فشرده‌سازی همچنان جاسازی می‌شوند.
- **فشرده‌سازی** می‌تواند حجم فایل را به‌طور قابل توجهی برای تصاویر رستر بزرگ کاهش دهد، اما وضوح منبع را از دست می‌دهد. این باید پس از دانستن اندازهٔ نهایی روی اسلاید اعمال شود.
- **تصاویر SVG** باید به‌عنوان SVG باقی بمانند زمانی که حفظ وکتور مهم است. هنگام نیاز به منبع وکتور، SVG جاسازی‌شده را مستقیماً استخراج کنید. خروجی‌های اسلاید رستری همیشه اسلاید رندرشده را به پیکسل تبدیل می‌کنند.
- **تصاویر تکراری** در صورت امکان باید از یک منبع [IPPImage](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ippimage/) موجود استفاده کنند به‌جای بارگذاری مکرر یک فایل همانند در جریان کاری ارائه.

برای ارائه‌های بزرگ، بهینه‌سازی تصویر معمولاً وقتی مؤثر است که به‌صورت انتخابی انجام شود: لوگوها و نمودارها را به‌عنوان محتوا وکتور نگه دارید، عکس‌ها را بر اساس اندازهٔ نمایش واقعی فشرده کنید، پیکسل‌های برش‌خورده را تنها زمانی حذف کنید که ویرایش بعدی لازم نباشد و از لینک‌های خارجی فقط وقتی استفاده کنید که مدیریت وابستگی بخشی از طراحی استقرار باشد.

## **پرسش‌های متداول**

**تفاوت بین فریم تصویر و منبع تصویر چیست؟**

یک [IPPImage](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ippimage/) نمایانگر منبع تصویر مرتبط با ارائه است. یک [IPictureFrame](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ipictureframe/) شکلی روی اسلاید است که تصویر را نمایش می‌دهد و هندسه و قالب‌بندی سطح فریم مانند اندازه، چرخش، مقادیر برش، افکت‌ها و قفل‌ها را ذخیره می‌کند.

**آیا باید تصویر را جاسازی کنم یا لینک کنم؟**

تصاویر را زمانی جاسازی کنید که ارائه باید قابل حمل، بایگانی یا بدون دسترسی به منابع خارجی رندر شود. تنها زمانی تصاویر را لینک کنید که نگهداری فایل‌های تصویر خارج از PPTX به‌طور عمدی انجام می‌شود و مکان‌های خارجی می‌توانند به‌صورت قابل اطمینان مدیریت شوند.

**آیا برش حجم فایل PPTX را کاهش می‌دهد؟**

خستین به‌خود کار نمی‌کند. تنظیمات برش معمولی بخش‌هایی از تصویر منبع را مخفی می‌کند اما پیکسل‌های زیرین را نگه می‌دارد. برای حذف دائمی پیکسل‌ها می‌توانید از [IPictureFillFormat::DeletePictureCroppedAreas](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) یا فشرده‌سازی تصویر با حذف نواحی برش استفاده کنید.

**آیا می‌توان پس از فشرده‌سازی کیفیت تصویر را بازگرداند؟**

خیر. فشرده‌سازی می‌تواند وضوح رستر ذخیره‌شده را کاهش دهد و حذف نواحی برش داده‌ها را از بین می‌برد. اگر ویرایش با وضوح بالا بعداً ممکن است لازم شود، تصویر اصلی را خارج از ارائه حفظ کنید.

**تصاویر SVG چگونه مدیریت شوند؟**

هنگامی که صحت وکتور مهم است، محتوای SVG را به‌عنوان SVG نگه دارید. می‌توان دادهٔ [ISvgImage](https://reference.aspose.com/slides/fa/cpp/aspose.slides/isvgimage/) جاسازی‌شده را مستقیماً استخراج کرد. رندر اسلاید به فرمت رستری مانند PNG یا JPEG، SVG را به پیکسل تبدیل می‌کند.

**چگونه می‌توان از تبدیل‌های ناامن هنگام خواندن اسلایدهای موجود اجتناب کرد؟**

قبل از استفاده از اعضای مخصوص فریم تصویر، نوع شکل را بررسی کنید. با [IPictureFrame](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ipictureframe/) شکل را تست کنید قبل از اعمال تبدیل در زمان اجرا و نتیجهٔ تبدیل را به یک متغیر محلی اختصاص دهید تا به اعضای خاص فریم تصویر دسترسی داشته باشید.