---
title: بهینه‌سازی مدیریت تصاویر در ارائه‌ها با استفاده از C++
linktitle: مدیریت تصاویر
type: docs
weight: 10
url: /fa/cpp/image/
keywords:
- افزودن تصویر
- افزودن عکس
- جایگزینی تصویر
- مجموعه تصویر
- قاب تصویر
- تصویر پیوندی
- پس‌زمینه
- افزودن PNG
- افزودن JPG
- افزودن SVG
- تبدیل SVG به اشکال
- منابع خارجی SVG
- PowerPoint
- OpenDocument
- ارائه
- C++
- Aspose.Slides
description: "یاد بگیرید چگونه تصاویر رستری و SVG را در ارائه‌های PowerPoint و OpenDocument با استفاده از Aspose.Slides برای C++ اضافه، دوباره استفاده، پیوند، جایگزین و مدیریت کنید."
---
## **مقدمه**

Aspose.Slides for C++ روش‌های متعددی برای کار با تصاویر ارائه می‌دهد و هر یک برای هدفی متفاوت استفاده می‌شوند. می‌توانید یک تصویر را در ارائه ذخیره کنید، در یک قاب تصویر نمایش دهید، به عنوان پس‌زمینه اسلاید استفاده کنید، به تصویر خارجی پیوند بدهید، منبع تصویر مشترک را جایگزین کنید یا محتوای SVG را به اشکال قابل ویرایش تبدیل کنید.

این مقاله بر منابع تصویر و نحوه استفاده آنها در سراسر یک ارائه متمرکز است. برای برش، شفافیت، افکت‌ها، کشیده شدن و سایر قالب‌بندی‌های اعمال‌شده به یک قاب تصویر منفرد، به [قاب تصویر](/slides/fa/cpp/picture-frame/) مراجعه کنید.

## **درک مدل تصویر**

مفاهیم API زیر به‌هم مرتبط هستند اما قابل تعویض نیستند:

- [مجموعه تصویر ارائه](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iimagecollection/) منابع تصویری را که توسط ارائه استفاده می‌شوند ذخیره می‌کند. برای افزودن داده تصویر و دریافت یک منبع [IPPImage](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ippimage/) از [IImageCollection::AddImage](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iimagecollection/addimage/) استفاده کنید.
- یک [قاب تصویر](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ipictureframe/) شکلی است که تصویر را روی اسلاید، طرحواره یا مستر نمایش می‌دهد. برای قرار دادن یک منبع تصویر روی اسلاید از [IShapeCollection::AddPictureFrame](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ishapecollection/addpictureframe/) استفاده کنید.
- پس‌زمینه اسلاید از تصویر به‌عنوان بخشی از پرکردن اسلاید استفاده می‌کند نه به‌عنوان یک شکل. بنابراین رفتار آن مشابه قاب تصویر نیست.
- [IPPImage::ReplaceImage](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ippimage/replaceimage/) یک منبع تصویر را جایگزین می‌کند. اگر چندین عنصر ارائه از آن منبع استفاده کنند، همه از جایگزین استفاده می‌کنند.
- تبدیل SVG به اشکال، اشکال قابل ویرایش اسلاید ایجاد می‌کند. پس از تبدیل، محتوا دیگر به‌عنوان یک منبع تصویر واحد مدیریت نمی‌شود.

یک جریان کاری معمولی به این شکل است: داده تصویر را به مجموعه تصویر اضافه کنید، یک [IPPImage](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ippimage/) دریافت کنید و سپس از آن منبع در یک یا چند قاب تصویر یا پرکردن استفاده کنید.

## **افزودن تصویر توکار**

برای درج یک تصویر محلی، فایل را بخوانید، داده‌های آن را به مجموعه تصویر اضافه کنید و یک قاب تصویر بسازید که از منبع [IPPImage](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ippimage/) بازگردانده‌شده استفاده می‌کند.

```cpp
#include <DOM/IImageCollection.h>
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

auto imageData = File::ReadAllBytes(u"photo.png");
auto image = presentation->get_Images()->AddImage(imageData);

auto slide = presentation->get_Slide(0);
slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 20.0f, 20.0f, 320.0f, 180.0f, image);

presentation->Save(u"presentation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

تصویری که به این روش اضافه می‌شود در ارائه توکار است، بنابراین فایل نهایی به در دسترس بودن فایل تصویر اصلی وابسته نیست.

### **افزودن تصویر از وب**

زمانی که تصویر از طریق HTTP یا HTTPS در دسترس باشد، بایت‌های آن را بارگیری کنید، به مجموعه تصویر ارائه اضافه کنید و از منبع تصویر بازگردانده‌شده به همان شیوهٔ تصویر محلی استفاده کنید.

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <net/web_client.h>
#include <system/uri.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Net;

auto imageUri = MakeObject<Uri>(u"https://example.com/image.png");
auto webClient = MakeObject<WebClient>();
auto imageData = webClient->DownloadData(imageUri);

auto presentation = MakeObject<Presentation>();

auto image = presentation->get_Images()->AddImage(imageData);
auto slide = presentation->get_Slide(0);
slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 20.0f, 20.0f, 320.0f, 180.0f, image);

presentation->Save(u"presentation-from-web.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

آدرس‌های URL دوردست، اندازهٔ پاسخ و نوع محتوا را هنگام عدم اعتماد به منبع اعتبارسنجی کنید. در برنامه‌هایی که پیشاپیش از یک سرویس‌گیرنده HTTP دیگر استفاده می‌کنند، می‌توانید تصویر را با آن سرویس‌گیرنده بارگیری کنید و بایت‌ها یا جریان حاصل را به [IImageCollection::AddImage](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iimagecollection/addimage/) پاس دهید.

## **استفاده مجدد از تصاویر در اسلایدها**

اگر یک تصویر بیش از یک بار مورد نیاز است، آن را یک‌بار به ارائه اضافه کنید و هنگام ایجاد قاب‌های تصویر اضافی از [IPPImage](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ippimage/) بازگردانده‌شده استفاده کنید. این کار از بارگذاری مکرر داده‌های منبع جلوگیری می‌کند و رابطهٔ بین منبع تصویر مشترک و استفاده‌های آن را واضح می‌کند.

برای گرافیک‌هایی که باید به‌صورت خودکار در اسلایدهای متعدد ظاهر شوند، مانند لوگوی شرکت، قرار دادن قاب تصویر در یک [مستر اسلاید](/slides/fa/cpp/slide-master/) یا طرحواره به جای افزودن شکل معادل به هر اسلاید را در نظر بگیرید.

## **استفاده از تصویر به عنوان پس‌زمینه اسلاید**

یک تصویر پس‌زمینه به پرکردن اسلاید اختصاص می‌یابد؛ به‌عنوان یک شکل قاب تصویر اضافه نمی‌شود. این مورد زمانی مفید است که تصویر باید پس‌زمینه اسلاید را پوشش دهد و نباید به‌عنوان یک شیء اسلاید معمولی دست‌کاری شود.

```cpp
#include <DOM/BackgroundType.h>
#include <DOM/FillType.h>
#include <DOM/IBackground.h>
#include <DOM/IFillFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto imageData = File::ReadAllBytes(u"background.jpg");
auto image = presentation->get_Images()->AddImage(imageData);

slide->get_Background()->set_Type(BackgroundType::OwnBackground);
slide->get_Background()->get_FillFormat()->set_FillType(FillType::Picture);
slide->get_Background()->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);
slide->get_Background()->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(image);

presentation->Save(u"background-image.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

برای گزینه‌های پس‌زمینه بیشتر، شامل پس‌زمینه‌های مستر و طرحواره، به [پس‌زمینهٔ ارائه](/slides/fa/cpp/presentation-background/) مراجعه کنید.

## **تصاویر توکار و تصاویر پیوند داده شده**

تصاویر توکار و پیوند داده شده تبادلات متفاوتی از نظر قابل حمل بودن و حجم فایل دارند:

- **تصویر توکار:** داده تصویر داخل ارائه ذخیره می‌شود. ارائه خودکفا است، اما حجم فایل شامل داده‌های تصویر می‌شود.
- **تصویر پیوندی:** ارائه مسیر یا URL تصویر خارجی را ذخیره می‌کند. این می‌تواند حجم ارائه را کاهش دهد، اما منبع خارجی باید هنگام باز یا رندر شدن ارائه در دسترس باقی بماند.

یک تصویر پیوندی می‌تواند از طریق [ISlidesPicture::set_LinkPathLong](https://reference.aspose.com/slides/fa/cpp/aspose.slides/islidespicture/set_linkpathlong/) به‌جای توکار کردن داده تصویر، مسیر یا URL خارجی را تنظیم کند.

```cpp
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 20.0f, 20.0f, 320.0f, 180.0f, nullptr);
pictureFrame->get_PictureFormat()->get_Picture()->set_LinkPathLong(u"https://example.com/image.png");

presentation->Save(u"linked-image.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

از تصاویر پیوندی فقط زمانی استفاده کنید که محیط استقرار بتواند به‌صورت قابل اطمینان به منبع خارجی دسترسی داشته باشد. برای ارائه‌هایی که باید به‌صورت آفلاین کار کنند یا بین سیستم‌ها جابجا شوند، تصاویر توکار معمولاً امن‌تر هستند.

## **کار با تصاویر SVG**

SVG یک فرمت برداری است، بنابراین برای آیکون‌ها، نمودارها و سایر گرافیک‌هایی که باید بدون از دست دادن جزئیات مقیاس شوند، مفید است. Aspose.Slides هم به‌عنوان منبع تصویر و هم به‌عنوان منبعی برای اشکال قابل ویرایش اسلاید از SVG پشتیبانی می‌کند.

### **افزودن SVG به عنوان تصویر**

یک [SvgImage](https://reference.aspose.com/slides/fa/cpp/aspose.slides/svgimage/) ایجاد کنید، آن را به مجموعه تصویر اضافه کنید و منبع تصویر حاصل را در یک قاب تصویر قرار دهید.

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SvgImage.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto svgContent = File::ReadAllText(u"icon.svg");
auto svgImage = MakeObject<SvgImage>(svgContent);

auto presentation = MakeObject<Presentation>();

auto image = presentation->get_Images()->AddImage(svgImage);
auto slide = presentation->get_Slide(0);
slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 20.0f, 20.0f, 200.0f, 200.0f, image);

presentation->Save(u"svg-image.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

### **فایل‌های SVG با منابع خارجی**

یک SVG می‌تواند به تصاویر، سبک‌نامه‌ها یا قلم‌های خارجی ارجاع دهد. برای این موارد، [SvgImage](https://reference.aspose.com/slides/fa/cpp/aspose.slides/svgimage/) سازندهایی دارد که یک [IExternalResourceResolver](https://reference.aspose.com/slides/fa/cpp/aspose.slides.import/iexternalresourceresolver/) و یک URI پایه می‌پذیرند. این حل‌کننده می‌تواند URI نسبی را به یک URI مطلق مجاز نگاشت کند و برای منبع درخواست‌شده یک جریان برگرداند.

حل‌کننده منابع خارجی را در طول پردازش SVG توسط Aspose.Slides در دسترس می‌گذارد، اما SVG را به یک سند خودکفا بازنویسی نمی‌کند. اگر SVG باید قابل حمل بماند، منابع مورد نیاز آن را داخل SVG خود توکار کنید، برای مثال با استفاده از URIهای `data:` برای تصاویر پیوندی.

هنگامی که فایل‌های SVG از منابع غیرقابل اعتماد می‌آیند، طرح‌ها، مکان‌های فایل و میزبان‌هایی که حل‌کننده می‌تواند به آنها دسترسی داشته باشد را محدود کنید. حل‌کننده‌های شبکه باید همچنین زمان‑به‑انتهاء، محدودیت‌های اندازه پاسخ و اعتبارسنجی محتوا را اعمال کنند.

### **تبدیل SVG به اشکال قابل ویرایش**

Aspose.Slides می‌تواند یک SVG را به گروهی از اشکال قابل ویرایش اسلاید تبدیل کند، مشابه فرمان متناظر PowerPoint.

![PowerPoint Popup Menu](img_01_01.png)

از overload [IShapeCollection::AddGroupShape](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ishapecollection/addgroupshape/) که یک [ISvgImage](https://reference.aspose.com/slides/fa/cpp/aspose.slides/isvgimage/) می‌پذیرد برای انجام تبدیل استفاده کنید.

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SvgImage.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto svgContent = File::ReadAllText(u"diagram.svg");
auto svgImage = MakeObject<SvgImage>(svgContent);

auto presentation = MakeObject<Presentation>();

auto slideSize = presentation->get_SlideSize()->get_Size();
auto slide = presentation->get_Slide(0);
slide->get_Shapes()->AddGroupShape(svgImage, 0.0f, 0.0f, slideSize.get_Width(), slideSize.get_Height());

presentation->Save(u"editable-svg-shapes.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

از تبدیل SVG به اشکال زمانی استفاده کنید که عناصر برداری منفرد نیاز به ویرایش به‌عنوان اشکال PowerPoint داشته باشند. اگر فقط نیاز به نمایش SVG دارید، نگه‌داشتن آن به‌صورت تصویر ساده‌تر است و از ایجاد تعداد زیادی شکل جداگانه جلوگیری می‌کند.

## **جایگزین کردن یک منبع تصویر موجود**

از [IPPImage::ReplaceImage](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ippimage/replaceimage/) زمانی استفاده کنید که بخواهید یک منبع تصویر موجود را جایگزین کنید. این کار به‌ویژه برای گرافیک‌های مشترک مانند لوگوها مفید است.

```cpp
#include <DOM/IPPImage.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"input.pptx");

auto imageToReplace = presentation->get_Image(0);
auto imageData = File::ReadAllBytes(u"new-logo.png");
imageToReplace->ReplaceImage(imageData);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

اگر چندین قاب تصویر، پس‌زمینه، مستر یا طرحواره از یک منبع تصویر استفاده می‌کنند، جایگزینی آن منبع تمام استفاده‌ها را به‌روزرسانی می‌کند. اگر فقط یک قاب تصویر باید تغییر کند، به‌جای جایگزینی منبع مشترک تصویر دیگری را به آن قاب اختصاص دهید.

[IPPImage::ReplaceImage](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ippimage/replaceimage/) همچنین overloadهایی دارد که یک [IImage](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iimage/) یا یک [IPPImage](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ippimage/) دیگر می‌پذیرند.

## **راهنمای عملی مدیریت تصویر**

### **کنترل اندازه ارائه**

تصاویر رستری بزرگ می‌توانند اندازهٔ ارائه را به‌طور غیرضروری بزرگ کنند. از تصاویر منبع با ابعاد متناسب با اندازهٔ نمایش موردنظر استفاده کنید، در صورت امکان از منابع تصویر مشترک استفاده مجدد کنید و از توکار کردن نسخه‌های تکراری یک گرافیک با وضوح کامل خودداری کنید.

برای تصاویر رستری که از قبل در قاب‌های تصویر قرار گرفته‌اند، می‌توانید با [IPictureFillFormat::CompressImage](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ipicturefillformat/compressimage/) داده تصویر را بر اساس وضوح انتخابی و تنظیمات برش کاهش دهید. این پردازش مربوط به قاب تصویر است نه مدیریت مجموعه تصویر، بنابراین برای عملیات قالب‌بندی مرتبط به [قاب تصویر](/slides/fa/cpp/picture-frame/) مراجعه کنید.

### **انتخاب بین محتوای توکار و پیوند داده شده**

توکار کردن ارائه را قابل حمل می‌کند زیرا تمام داده‌های تصویر موردنیاز همراه فایل می‌آید. پیوند دادن می‌تواند اندازهٔ فایل را کاهش دهد، اما وابستگی خارجی ایجاد می‌کند. تنها زمانی از پیوند استفاده کنید که این وابستگی قابل قبول و پایدار باشد.

### **استفاده مجدد از برند مشترک**

برای لوگوها، واترمارک‌ها یا گرافیک‌های تزئینی تکراری، از یک منبع تصویر استفاده کنید و آن را دوباره به کار ببرید. اگر گرافیک جزو طراحی ارائه باشد نه محتوای اسلاید، آن را بر روی یک مستر یا طرحواره قرار دهید تا توسط اسلایدهای مربوط به‌طور خودکار به ارث برسد.

### **نگه داشتن منابع SVG قابل جابجایی**

یک SVG خودکفا جابه‌جایی و رندر ثابت‌تری دارد نسبت به SVGی که به فایل‌ها یا منابع شبکه‌ای خارجی وابسته است. در صورت امکان، پیش از وارد کردن SVG، منابع موردنیاز را توکار کنید. تبدیل SVG به اشکال فقط زمانی انجام شود که عناصر برداری منفرد نیاز به ویرایش داشته باشند.

### **استفاده از API تصویر Aspose.Slides**

برای جریان‌های کاری تصویر در C++، وقتی به یک شیء تصویر نیاز دارید از API‌های Aspose.Slides [IImage](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iimage/) و [Images](https://reference.aspose.com/slides/fa/cpp/aspose.slides/images/) استفاده کنید و وقتی نیاز به ثبت داده تصویر به‌عنوان منبع ارائه دارید از [IImageCollection::AddImage](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iimagecollection/addimage/) بهره ببرید. overloadهای مجموعه همچنین از آرایه‌های بایت و جریان‌ها پشتیبانی می‌کنند که هنگام دریافت داده تصویر از فایل‌ها، مشتریان شبکه، پایگاه‌های داده یا کتابخانه‌های دیگر مفید است.

تولید محتوای EMF از صفحات گسترده یا محصول دیگر یک جریان کاری ادغام جداگانه است و در دامنهٔ این مقاله قرار نمی‌گیرد. اگر یک فایل WMF یا EMF موجود فقط نیاز به درج در ارائه داشته باشد، داده‌های آن را به یک overload مناسب [IImageCollection::AddImage] پاس دهید بدون اینکه وابستگی محصول دوم را به جریان کاری مدیریت تصویر اضافه کنید.

## **پرسش‌های متداول**

**تفاوت مجموعه تصویر و قاب تصویر چیست؟**

مجموعه تصویر منابع تصویر قابل استفاده مجدد را ذخیره می‌کند. یک قاب تصویر شکل اسلایدی است که یکی از آن منابع را نمایش می‌دهد و قالب‌بندی خاصی مانند برش و افکت‌ها را فراهم می‌کند.

**بهترین راه برای جایگزین کردن لوگوی یکسان در همه‌جا چیست؟**

اگر لوگو قبلاً به‌عنوان یک منبع تصویر مشترک ذخیره شده باشد، آن منبع را با [IPPImage::ReplaceImage](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ippimage/replaceimage/) جایگزین کنید. برای برندینگ سراسری ارائه، قرار دادن لوگو بر روی یک مستر یا طرحواره نیز می‌تواند از تکرار محتوای اسلایدها جلوگیری کند.

**چرا یک تصویر پیوندی در رایانه دیگر ناپدید می‌شود؟**

یک تصویر پیوندی به فایل یا URL خارجی خود وابسته است. اگر آن منبع از رایانهٔ دیگر قابل دسترسی نباشد، تصویر پیوندی قابل مشاهده نخواهد بود. وقتی ارائه باید خودکفا باشد، تصویر را توکار کنید.

**آیا یک SVG درج‌شده می‌تواند به‌عنوان اشکال PowerPoint ویرایش شود؟**

بله. SVG را با استفاده از [IShapeCollection::AddGroupShape](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ishapecollection/addgroupshape/) تبدیل کنید؛ گروه حاصل شامل اشکال اسلاید قابل ویرایش به‌جای یک تصویر SVG است.

**چگونه می‌توانم ارائه‌هایی با تصاویر زیاد را کوچک نگه دارم؟**

از منابع تصویر مشترک استفاده مجدد کنید، از منابع رستری بزرگ غیرضروری خودداری کنید، در مواقع مناسب تصاویر رستری مناسب را فشرده کنید، برندهای تکراری را بر روی مستر یا طرحواره نگه دارید و فقط وقتی وابستگی خارجی قابل قبول است، از تصاویر پیوندی استفاده کنید.