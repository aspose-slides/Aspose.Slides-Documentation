---
title: تبدیل اسلایدهای ارائه به تصاویر در C++
linktitle: اسلاید به تصویر
type: docs
weight: 41
url: /fa/cpp/convert-slide/
keywords: 
- تبدیل اسلاید
- صدور اسلاید
- اسلاید به تصویر
- ذخیره اسلاید به عنوان تصویر
- اسلاید به EMF
- اسلاید به PNG
- اسلاید به JPEG
- اسلاید به بیت‌مپ
- اسلاید به TIFF
- PowerPoint
- OpenDocument
- ارائه
- C++
- Aspose.Slides
description: "اسلایدها را از ارائه‌های PPT، PPTX و ODP به فرمت‌های PNG، JPEG، GIF، TIFF، EMF و سایر فرمت‌های تصویری در C++ با Aspose.Slides برای C++ تبدیل کنید."
---
## **مقدمه**

Aspose.Slides برای C++ می‌تواند اسلایدهای جداگانه از ارائه‌های PowerPoint و OpenDocument را به صورت PNG، JPEG، GIF، TIFF و سایر فرمت‌های تصویری رندر کند.

برای تبدیل یک اسلاید به تصویر، مراحل زیر را دنبال کنید:

1. ارائه را با کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) بارگذاری کنید.
2. اسلایدی که می‌خواهید رندر کنید را انتخاب کنید.
3. در صورت نیاز، رندرینگ را با کلاس‌های [RenderingOptions](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/renderingoptions/) یا [TiffOptions](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/tiffoptions/) پیکربندی کنید.
4. متد [ISlide::GetImage](https://reference.aspose.com/slides/fa/cpp/aspose.slides/islide/getimage/) را فراخوانی کنید. این متد یک شیء [IImage](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iimage/) را باز می‌گرداند.
5. متد [IImage::Save](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iimage/save/) را صدا بزنید و فرمت خروجی را با مقدار [ImageFormat](https://reference.aspose.com/slides/fa/cpp/aspose.slides/imageformat/) مشخص کنید.

## **تبدیل یک اسلاید به تصویر PNG**

ساده‌ترین تبدیل با استفاده از تنظیمات پیش‌فرض رندرینگ انجام می‌شود. شیء [IImage](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iimage/) حاصل می‌تواند در حافظه پردازش شود یا در فایلی ذخیره گردد.

مثال زیر اسلاید اول را رندر کرده و به عنوان تصویر PNG ذخیره می‌کند:

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");
auto slide = presentation->get_Slide(0);

auto image = slide->GetImage();
image->Save(u"Slide_0.png", ImageFormat::Png);

image->Dispose();
presentation->Dispose();
```

## **تبدیل اسلایدها به تصاویر با اندازه‌های سفارشی**

از بارگذاری [ISlide::GetImage](https://reference.aspose.com/slides/fa/cpp/aspose.slides/islide/getimage/) که یک مقدار [Size](https://reference.aspose.com/slides/fa/cpp/system.drawing/size/) می‌پذیرد استفاده کنید تا اسلاید را با ابعاد پیکسل دقیق رندر کنید.

مثال زیر تصویری JPEG با ابعاد ۱۸۲۰ × ۱۰۴۰ پیکسل ایجاد می‌کند:

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <drawing/size.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::Drawing;

Size imageSize(1820, 1040);

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");
auto slide = presentation->get_Slide(0);

auto image = slide->GetImage(imageSize);
image->Save(u"Slide_0.jpg", ImageFormat::Jpeg);

image->Dispose();
presentation->Dispose();
```

## **تبدیل اسلایدها با یادداشت‌ها و نظرات به تصاویر**

به طور پیش‌فرض، تصاویر اسلاید شامل یادداشت‌ها یا نظرات نیستند. برای کنترل مکان نمایش یادداشت‌ها و نظرات، یک شیء [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/notescommentslayoutingoptions/) را به متد [RenderingOptions::set_SlidesLayoutOptions](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/renderingoptions/set_slideslayoutoptions/) اختصاص دهید.

مثال زیر یادداشت‌های کوتاه‌شده را زیر اسلاید و نظرات را به سمت راست آن قرار می‌دهد:

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/CommentsPositions.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/NotesPositions.h>
#include <Export/RenderingOptions.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

float scaleX = 2.0f;
float scaleY = scaleX;

auto layoutOptions = MakeObject<NotesCommentsLayoutingOptions>();
layoutOptions->set_NotesPosition(NotesPositions::BottomTruncated);
layoutOptions->set_CommentsPosition(CommentsPositions::Right);
layoutOptions->set_CommentsAreaWidth(500);
layoutOptions->set_CommentsAreaColor(Color::get_AntiqueWhite());

auto renderingOptions = MakeObject<RenderingOptions>();
renderingOptions->set_SlidesLayoutOptions(layoutOptions);

auto presentation = MakeObject<Presentation>(u"Presentation_with_notes_and_comments.pptx");
auto slide = presentation->get_Slide(0);

auto image = slide->GetImage(renderingOptions, scaleX, scaleY);
image->Save(u"Image_with_notes_and_comments_0.gif", ImageFormat::Gif);

image->Dispose();
presentation->Dispose();
```

{{% alert title="Warning" color="warning" %}}
برای تبدیل اسلاید به تصویر، متد [NotesCommentsLayoutingOptions::set_NotesPosition](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/notescommentslayoutingoptions/set_notesposition/) را به [BottomFull](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/notespositions/) تنظیم نکنید. یادداشت‌ها ممکن است متن بیشتری نسبت به اندازه ثابت تصویر داشته باشند. به جای آن از [BottomTruncated](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/notespositions/) استفاده کنید.
{{% /alert %}}

## **تبدیل اسلایدها به تصاویر با استفاده از گزینه‌های TIFF**

کلاس [TiffOptions](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/tiffoptions/) به شما اجازه می‌دهد تا اندازه، وضوح و سایر خصوصیات تصویر TIFF رندر شده را کنترل کنید.

مثال زیر اسلاید اول را به عنوان تصویر TIFF با ابعاد ۲۱۶۰ × ۲۸۸۰ پیکسل و ۳۰۰ DPI رندر می‌کند:

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/TiffOptions.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <drawing/size.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto tiffOptions = MakeObject<TiffOptions>();
tiffOptions->set_ImageSize(Size(2160, 2880));
tiffOptions->set_DpiX(300);
tiffOptions->set_DpiY(300);

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

auto image = slide->GetImage(tiffOptions);
image->Save(u"output.tiff", ImageFormat::Tiff);

image->Dispose();
presentation->Dispose();
```

## **تبدیل تمام اسلایدها به تصاویر**

از مجموعه اسلایدها عبور کنید تا تمام ارائه را به سری‌ای از تصاویر تبدیل کنید. اسلایدهای مخفی نیز گنجانده می‌شوند مگر اینکه به‌صورت صریح از آن‌ها عبور نکنید.

مثال زیر هر اسلاید را به عنوان تصویر JPEG با ضریب مقیاس افقی و عمودی برابر ۲ رندر می‌کند:

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/smart_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

float scaleX = 2.0f;
float scaleY = scaleX;

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

int32_t slideCount = presentation->get_Slides()->get_Count();
for (int32_t index = 0; index < slideCount; index++)
{
    auto slide = presentation->get_Slide(index);
    auto image = slide->GetImage(scaleX, scaleY);
    image->Save(String::Format(u"Slide_{0}.jpg", index), ImageFormat::Jpeg);
    image->Dispose();
}

presentation->Dispose();
```

## **ایجاد خروجی Enhanced Metafile**

Enhanced Metafile (EMF) زمانی مفید است که نیاز به تبادل گرافیک‌های مبتنی بر بردار با Microsoft Office یا سایر برنامه‌های ویندوزی که از متافایل‌های ویندوز پشتیبانی می‌کنند، باشد. برخلاف تصویر پیکسلی، یک EMF می‌تواند عملیات رسم برداری را حفظ کند که بدون از دست دادن وضوح بتواند مقیاس‌بندی شود. با این حال، EMF عمدتاً یک فرمت سازگاری برای برنامه‌های دارای پشتیبانی از متافایل ویندوز است و نه یک فرمت تبادل عمومی. علاوه بر این، محتویات پیچیده اسلاید مانند تصاویر بیت‌مپ و برخی افکت‌ها ممکن است به‌صورت عناصر رستری داخل کانتینر متافایل برداری ذخیره شوند.

### **خروجی یک اسلاید به EMF**

متد [ISlide::WriteAsEmf](https://reference.aspose.com/slides/fa/cpp/aspose.slides/islide/writeasemf/) یک [ISlide](https://reference.aspose.com/slides/fa/cpp/aspose.slides/islide/) را به یک استریم هدف در فرمت EMF می‌نویسد. مثال زیر یک ارائه را بارگذاری می‌کند، اسلاید اول را انتخاب می‌کند و آن را به یک استریم فایل EMF می‌نویسد:

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");
auto slide = presentation->get_Slide(0);

auto emfStream = File::Create(u"Slide_0.emf");
slide->WriteAsEmf(emfStream);

emfStream->Close();
presentation->Dispose();
```

صاحبان استریم باید استریم عبوری به [ISlide::WriteAsEmf](https://reference.aspose.com/slides/fa/cpp/aspose.slides/islide/writeasemf/) را پس از استفاده بسته یا از بین ببرند. Aspose.Slides در موقعیت جاری استریم می‌نویسد و استریم را باز می‌گذارد.

### **تبدیل یک تصویر SVG به EMF و افزودن آن به یک ارائه**

از [ISvgImage::WriteAsEmf](https://reference.aspose.com/slides/fa/cpp/aspose.slides/isvgimage/writeasemf/) برای تبدیل محتویات SVG به EMF استفاده کنید. بایت‌های حاصل می‌توانند از طریق [IImageCollection::AddImage](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iimagecollection/addimage/) به ارائه اضافه شوند و با [IShapeCollection::AddPictureFrame](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ishapecollection/addpictureframe/) بر روی اسلاید قرار گیرند.

مثال زیر یک [SvgImage](https://reference.aspose.com/slides/fa/cpp/aspose.slides/svgimage/) را از کد SVG می‌سازد، آن را به یک EMF در حافظه تبدیل می‌کند، متافایل را بر روی اسلاید اول وارد می‌کند و ارائه را ذخیره می‌نماید:

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SvgImage.h>
#include <Export/SaveFormat.h>
#include <system/io/memory_stream.h>
#include <system/smart_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

String svgContent = u"<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"200\" height=\"100\"><rect width=\"200\" height=\"100\" fill=\"#4472C4\"/></svg>";
auto svgImage = MakeObject<SvgImage>(svgContent);

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto emfStream = MakeObject<MemoryStream>();
svgImage->WriteAsEmf(emfStream);

auto emfData = emfStream->ToArray();
auto image = presentation->get_Images()->AddImage(emfData);
slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 20, 20, 200, 100, image);

presentation->Save(u"Presentation_with_emf.pptx", SaveFormat::Pptx);

emfStream->Close();
presentation->Dispose();
```

[ISvgImage::WriteAsEmf](https://reference.aspose.com/slides/fa/cpp/aspose.slides/isvgimage/writeasemf/) مالکیت استریم مقصد را بر عهده نمی‌گیرد. پس از نوشتن، موقعیت استریم در انتهای داده‌های تولید شده قرار می‌گیرد. مثال با فراخوانی [MemoryStream::ToArray](https://reference.aspose.com/slides/fa/cpp/system.io/memorystream/toarray/) تمام بافر را دریافت می‌کند، صرف‌نظر از موقعیت جاری استریم، سپس آن آرایه بایتی را به [IImageCollection::AddImage](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iimagecollection/addimage/) می‌سپارد. استریم را تا زمانی که مصرف‌کننده آن را کامل خوانده است باز نگه دارید و پس از آن آن را ببندید.

تولید EMF در سیستم‌عامل‌های پشتیبانی‌شده توسط Aspose.Slides برای C++ قابل دسترس است، اما رندرینگ ممکن است بسته به پلتفرم و در دسترس نبودن فونت‌ها یا وابستگی‌های گرافیکی بومی متفاوت باشد. فونت‌های مورد استفاده در محتویات منبع را نصب کنید یا جایگزین‌های مناسب را پیکربندی کنید، الزامات [پلتفرم](/slides/fa/cpp/system-requirements/) را برای Aspose.Slides برای C++ دنبال کنید و نتیجه را در برنامه هدف مصرف‌کننده EMF اعتبارسنجی کنید. برنامه‌های Linux و macOS اغلب پشتیبانی محدود یا ناسازگاری در نمایش و ویرایش متافایل‌های ویندوز دارند.

## **رندر رنگ ایموجی**

{{% alert title="Note" color="info" %}}
برای رندر صحیح ایموجی‌های رنگی هنگام تبدیل اسلایدهای ارائه به تصاویر، فونت‌های ایموجی مورد استفاده در ارائه باید بر روی سیستمی که تبدیل را انجام می‌دهد نصب و در دسترس باشد. برای مثال، اگر ارائه از **Segoe UI Emoji** استفاده کند و این فونت موجود نباشد، ایموجی‌ها ممکن است به صورت تک‌رنگ در تصاویر خروجی ظاهر شوند.
{{% /alert %}}

## **سؤالات متداول**

**آیا Aspose.Slides از رندر اسلایدها با انیمیشن‌ها پشتیبانی می‌کند؟**

خیر. متد [ISlide::GetImage](https://reference.aspose.com/slides/fa/cpp/aspose.slides/islide/getimage/) تصویر ثابتی از اسلاید تولید می‌کند و انیمیشن‌ها را صادر نمی‌کند.

**آیا می‌توان اسلایدهای مخفی را به عنوان تصویر استخراج کرد؟**

بله. اسلایدهای مخفی می‌توانند همانند اسلایدهای معمولی رندر شوند. آن‌ها را در حلقه پردازشی گنجانده کنید، همان‌گونه که در مثال بالا نشان داده شده است.

**آیا سایه‌ها و سایر افکت‌ها در تصاویر اسلاید حفظ می‌شوند؟**

بله. Aspose.Slides سایه‌ها، شفافیت و سایر افکت‌های گرافیکی پشتیبانی‌شده را در تصاویر اسلاید رندر می‌کند.