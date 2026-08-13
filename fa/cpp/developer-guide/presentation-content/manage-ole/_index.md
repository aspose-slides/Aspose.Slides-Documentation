---
title: مدیریت OLE در ارائه‌ها با استفاده از C++
linktitle: مدیریت OLE
type: docs
weight: 40
url: /fa/cpp/manage-ole/
keywords:
- شیء OLE
- اتصال و جاسازی شیء
- افزودن OLE
- جاسازی OLE
- افزودن شیء
- جاسازی شیء
- افزودن فایل
- جاسازی فایل
- شیء لینک‌شده
- فایل لینک‌شده
- تغییر OLE
- آیکون OLE
- عنوان OLE
- استخراج OLE
- استخراج شیء
- استخراج فایل
- پاورپوینت
- ارائه
- C++
- Aspose.Slides
description: "بهینه‌سازی مدیریت اشیای OLE در فایل‌های PowerPoint و OpenDocument با Aspose.Slides برای C++. جاسازی، به‌روزرسانی و استخراج محتویات OLE به‌صورت یکپارچه."
---
## **معرفی**

{{% alert title="Info" color="info" %}}
OLE (Object Linking & Embedding) یک فناوری مایکروسافت است که اجازه می‌دهد داده‌ها و اشیائی که در یک برنامه ایجاد شده‌اند، از طریق لینک یا جاسازی در برنامه دیگر قرار گیرند. 
{{% /alert %}} 

در نظر بگیرید یک نمودار در MS Excel ساخته شده باشد. سپس این نمودار داخل یک اسلاید PowerPoint قرار می‌گیرد. آن نمودار Excel به‌عنوان یک شیء OLE در نظر گرفته می‌شود. 

- یک شیء OLE ممکن است به‌صورت یک آیکن نمایش داده شود. در این حالت، با دوبار کلیک بر روی آیکن، نمودار در برنامه مرتبط (Excel) باز می‌شود یا از شما خواسته می‌شود برنامه‌ای برای باز یا ویرایش شیء انتخاب کنید. 
- یک شیء OLE می‌تواند محتوای واقعی خود را نمایش دهد، مانند محتوای یک نمودار. در این حالت، نمودار در PowerPoint فعال می‌شود، رابط نمودار بارگذاری می‌شود و می‌توانید داده‌های نمودار را مستقیماً در PowerPoint اصلاح کنید. 

[Aspose.Slides برای C++](https://products.aspose.com/slides/fa/cpp/) به شما امکان می‌دهد اشیای OLE را به‌عنوان قاب‌های شیء OLE ([OleObjectFrame](https://reference.aspose.com/slides/fa/cpp/aspose.slides/oleobjectframe/)) در اسلایدها وارد کنید. 

## **افزودن قاب‌های OLE Object به اسلایدها**

فرض کنید پیشتر یک نمودار در Microsoft Excel ساخته‌اید و می‌خواهید آن را به‌عنوان یک قاب شیء OLE در یک اسلاید قرار دهید با استفاده از Aspose.Slides برای C++. می‌توانید به این شکل عمل کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.presentation) ایجاد کنید.  
2. مرجع اسلاید را از طریق ایندکس آن دریافت کنید.  
3. فایل Excel را به‌صورت آرایه بایتی بخوانید.  
4. [OleObjectFrame](https://reference.aspose.com/slides/fa/cpp/aspose.slides/oleobjectframe/) را به اسلاید اضافه کنید، همراه با آرایه بایتی و سایر اطلاعات مربوط به شیء OLE.  
5. ارائهٔ اصلاح‌شده را به‌صورت فایل PPTX ذخیره کنید.  

در مثال زیر، یک نمودار از یک فایل Excel را به‌عنوان [OleObjectFrame](https://reference.aspose.com/slides/fa/cpp/aspose.slides/oleobjectframe/) به اسلاید اضافه کردیم با استفاده از Aspose.Slides برای C++.  
**Note** سازندهٔ [OleEmbeddedDataInfo](https://reference.aspose.com/slides/fa/cpp/aspose.slides.dom.ole/oleembeddeddatainfo/) یک پسوند شیء جاسازی‌شده را به‌عنوان پارامتر دوم می‌گیرد. این پسوند به PowerPoint اجازه می‌دهد نوع فایل را به‌درستی تفسیر کرده و برنامهٔ مناسب برای باز کردن این شیء OLE را انتخاب کند.  

``` cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Ole/OleEmbeddedDataInfo.h>
#include <drawing/size_f.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::DOM::Ole;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slideSize = presentation->get_SlideSize()->get_Size();
auto slide = presentation->get_Slide(0);

// داده‌ها را برای شیء OLE آماده کنید.
auto fileData = File::ReadAllBytes(u"book.xlsx");
auto dataInfo = MakeObject<OleEmbeddedDataInfo>(fileData, u"xlsx");

// Add the OLE object frame to the slide.
slide->get_Shapes()->AddOleObjectFrame(0, 0, slideSize.get_Width(), slideSize.get_Height(), dataInfo);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

### **افزودن قاب‌های OLE Object لینک‌شده**

Aspose.Slides برای C++ به شما امکان می‌دهد یک [OleObjectFrame](https://reference.aspose.com/slides/fa/cpp/aspose.slides/oleobjectframe/) بدون جاسازی داده، تنها با یک لینک به فایل اضافه کنید.  

این کد C++ نشان می‌دهد چگونه یک [OleObjectFrame](https://reference.aspose.com/slides/fa/cpp/aspose.slides/oleobjectframe/) با یک فایل Excel لینک‌شده به اسلاید اضافه کنید:  

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

// یک قاب شیء OLE با فایل Excel لینک‌شده اضافه کنید.
slide->get_Shapes()->AddOleObjectFrame(20, 20, 200, 150, u"Excel.Sheet.12", u"book.xlsx");

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **دسترسی به قاب‌های OLE Object**

اگر یک شیء OLE از پیش در اسلاید جاسازی شده باشد، می‌توانید به راحتی آن را پیدا یا دسترسی پیدا کنید به این صورت:  

1. ارائه‌ای که شامل شیء OLE جاسازی‌شده است را با ایجاد یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.presentation) بارگذاری کنید.  
2. مرجع اسلاید را با استفاده از ایندکس آن دریافت کنید.  
3. شکل [OleObjectFrame](https://reference.aspose.com/slides/fa/cpp/aspose.slides/oleobjectframe/) را دسترسی پیدا کنید. در مثال ما، PPTX قبلی که فقط یک شکل در اسلاید اول دارد استفاده شد. سپس آن شیء را به‌صورت [IOleObjectFrame](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ioleobjectframe/) *cast* کردیم. این همان قاب OLE موردنظر برای دسترسی بود.  
4. پس از دسترسی به قاب شیء OLE، می‌توانید هر عملیاتی را روی آن انجام دهید.  

در مثال زیر، یک قاب شیء OLE (یک شیء نمودار Excel جاسازی‌شده در اسلاید) و دادهٔ فایل آن دسترسی پیدا می‌شوند.  

``` cpp
#include <DOM/IOleEmbeddedDataInfo.h>
#include <DOM/IOleObjectFrame.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shape(0);

if (ObjectExt::Is<IOleObjectFrame>(shape))
{ 
    auto oleFrame = ExplicitCast<IOleObjectFrame>(shape);

    // داده‌های فایل جاسازی‌شده را دریافت کنید.
    auto fileData = oleFrame->get_EmbeddedData()->get_EmbeddedFileData();

    // پسوند فایل جاسازی‌شده را دریافت کنید.
    auto fileExtension = oleFrame->get_EmbeddedData()->get_EmbeddedFileExtension();

    // ...
}
```

### **دسترسی به خصوصیات قاب OLE Object لینک‌شده**

Aspose.Slides به شما امکان می‌دهد به خصوصیات قاب شیء OLE لینک‌شده دسترسی پیدا کنید.  

این کد C++ نشان می‌دهد چگونه بررسی کنید آیا یک شیء OLE لینک‌شده است و سپس مسیر فایل لینک‌شده را دریافت کنید:  

```cpp
#include <DOM/IOleObjectFrame.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/object_ext.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.ppt");
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shape(0);

if (ObjectExt::Is<IOleObjectFrame>(shape))
{
    auto oleFrame = ExplicitCast<IOleObjectFrame>(shape);

    // بررسی کنید آیا شیء OLE لینک‌شده است.
    if (oleFrame->get_IsObjectLink())
    {
        // مسیر کامل فایل لینک‌شده را چاپ کنید.
        std::wcout << L"OLE object frame is linked to: " << oleFrame->get_LinkPathLong() << std::endl;

        // اگر موجود باشد، مسیر نسبی فایل لینک‌شده را چاپ کنید.
        // فقط ارائه‌های PPT می‌توانند مسیر نسبی را شامل شوند.
        if (!String::IsNullOrEmpty(oleFrame->get_LinkPathRelative()))
        {
```

## **تغییر دادهٔ شیء OLE**

{{% alert color="info" %}} 
در این بخش، مثال کد زیر از [Aspose.Cells برای C++](/cells/cpp/) استفاده می‌کند. 
{{% /alert %}}

اگر یک شیء OLE از پیش در اسلاید جاسازی شده باشد، می‌توانید به راحتی آن شیء را دسترسی پیدا کنید و داده‌های آن را به این شکل اصلاح کنید:  

1. ارائه‌ای که شامل شیء OLE جاسازی‌شده است را با ایجاد یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.presentation) بارگذاری کنید.  
2. مرجع اسلاید را از طریق ایندکس آن دریافت کنید.  
3. شکل [OLEObjectFrame](https://reference.aspose.com/slides/fa/cpp/aspose.slides/oleobjectframe/) را دسترسی پیدا کنید. در مثال ما، PPTX قبلی که یک شکل در اسلاید اول دارد استفاده شد. سپس آن شیء را به‌صورت [IOleObjectFrame](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ioleobjectframe/) *cast* کردیم. این همان قاب OLE موردنظر برای دسترسی بود.  
4. پس از دسترسی به قاب شیء OLE، می‌توانید هر عملیاتی را روی آن انجام دهید.  
5. یک شیء `Workbook` ایجاد کنید و به دادهٔ OLE دسترسی پیدا کنید.  
6. `Worksheet` موردنظر را دسترسی پیدا کنید و داده‌ها را اصلاح کنید.  
7. `Workbook` به‌روزشده را در یک جریان (stream) ذخیره کنید.  
8. دادهٔ شیء OLE را از جریان تغییر دهید.  

در مثال زیر، یک قاب شیء OLE (یک شیء نمودار Excel جاسازی‌شده در اسلاید) دسترسی پیدا می‌شود و دادهٔ فایل آن برای به‌روزرسانی داده‌های نمودار تغییر می‌کند.  

```cpp
#include <DOM/IOleObjectFrame.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Ole/OleEmbeddedDataInfo.h>
#include <system/io/memory_stream.h>
#include <system/smart_ptr.h>
#include "Aspose.Cells/Cell.h"
#include "Aspose.Cells/Cells.h"
#include "Aspose.Cells/Initializer.h"
#include "Aspose.Cells/OoxmlSaveOptions.h"
#include "Aspose.Cells/SaveFormat.h"
#include "Aspose.Cells/U16String.h"
#include "Aspose.Cells/Vector.h"
#include "Aspose.Cells/Workbook.h"
#include "Aspose.Cells/Worksheet.h"
#include "Aspose.Cells/WorksheetCollection.h"
using namespace Aspose::Slides;
using namespace Aspose::Slides::DOM::Ole;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

// Aspose.Cells برای C++ باید قبل از استفاده از هر یک از انواع آن راه‌اندازی شود.
Aspose::Cells::Startup();

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

// دریافت اولین شکل به‌عنوان یک قاب شیء OLE.
auto oleFrame = AsCast<IOleObjectFrame>(slide->get_Shape(0));

if (oleFrame != nullptr)
{
    auto oleStream = MakeObject<MemoryStream>(oleFrame->get_EmbeddedData()->get_EmbeddedFileData());

    // دادهٔ شیء OLE را به‌عنوان یک شیء Workbook بخوانید.
    auto oleArray = oleStream->ToArray();
    std::vector<uint8_t> workbookData(oleArray->data().begin(), oleArray->data().end());
    Aspose::Cells::Workbook workbook(Aspose::Cells::Vector<uint8_t>(workbookData.data(), workbookData.size()));

    // داده‌های Workbook را اصلاح کنید.
    auto worksheet = workbook.GetWorksheets().Get(0);
    worksheet.GetCells().Get(0, 4).PutValue(Aspose::Cells::U16String("E"));
    worksheet.GetCells().Get(1, 4).PutValue(12);
    worksheet.GetCells().Get(2, 4).PutValue(14);
    worksheet.GetCells().Get(3, 4).PutValue(15);

    Aspose::Cells::OoxmlSaveOptions fileOptions(Aspose::Cells::SaveFormat::Xlsx);
    auto newWorkbookData = workbook.Save(fileOptions);

    auto newOleStream = MakeObject<MemoryStream>();
    newOleStream->Write(
        MakeArray<uint8_t>(std::vector<uint8_t>(newWorkbookData.GetData(), newWorkbookData.GetData() + newWorkbookData.GetLength())),
        0, newWorkbookData.GetLength());

    // دادهٔ شیء قاب OLE را تغییر دهید.
    auto newData = MakeObject<OleEmbeddedDataInfo>(newOleStream->ToArray(), oleFrame->get_EmbeddedData()->get_EmbeddedFileExtension());
    oleFrame->SetEmbeddedData(newData);
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);

Aspose::Cells::Cleanup();
```

## **جاسازی انواع فایل‌های دیگر در اسلایدها**

علاوه بر نمودارهای Excel، Aspose.Slides برای C++ به شما اجازه می‌دهد انواع دیگر فایل‌ها را به‌صورت اشیاء در اسلایدها جاسازی کنید. به‌عنوان مثال می‌توانید فایل‌های HTML، PDF و ZIP را به‌عنوان اشیاء وارد کنید. وقتی کاربر روی شیء وارد شده دوبار کلیک می‌کند، به‌صورت خودکار در برنامه مرتبط باز می‌شود یا از کاربر درخواست می‌شود برنامهٔ مناسب برای باز کردن آن را انتخاب کند.  

این کد C++ نشان می‌دهد چگونه HTML و ZIP را به یک اسلاید جاسازی کنید:  

``` cpp
#include <DOM/IOleObjectFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Ole/OleEmbeddedDataInfo.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::DOM::Ole;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto htmlData = File::ReadAllBytes(u"sample.html");
auto htmlDataInfo = MakeObject<OleEmbeddedDataInfo>(htmlData, u"html");
auto htmlOleFrame = slide->get_Shapes()->AddOleObjectFrame(150, 120, 50, 50, htmlDataInfo);
htmlOleFrame->set_IsObjectIcon(true);

auto zipData = File::ReadAllBytes(u"sample.zip");
auto zipDataInfo = MakeObject<OleEmbeddedDataInfo>(zipData, u"zip");
auto zipOleFrame = slide->get_Shapes()->AddOleObjectFrame(150, 220, 50, 50, zipDataInfo);
zipOleFrame->set_IsObjectIcon(true);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **تنظیم نوع فایل برای اشیاء جاسازی‌شده**

هنگام کار با ارائه‌ها ممکن است نیاز داشته باشید اشیاء OLE قدیمی را با اشیاء جدید جایگزین کنید یا یک شیء OLE پشتیبانی‌نشده را با یک شیء پشتیبانی‌شده عوض کنید. Aspose.Slides برای C++ به شما امکان می‌دهد نوع فایل برای یک شیء جاسازی‌شده تنظیم کنید تا بتوانید دادهٔ قاب OLE یا پسوند آن را به‌روزرسانی کنید.  

این کد C++ نشان می‌دهد چگونه نوع فایل برای یک شیء OLE جاسازی‌شده به `zip` تنظیم شود:  

``` cpp
#include <DOM/IOleObjectFrame.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Ole/OleEmbeddedDataInfo.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::DOM::Ole;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);
auto oleFrame = ExplicitCast<IOleObjectFrame>(slide->get_Shape(0));

auto fileExtension = oleFrame->get_EmbeddedData()->get_EmbeddedFileExtension();
auto fileData = oleFrame->get_EmbeddedData()->get_EmbeddedFileData();

std::wcout << L"Current embedded file extension is: " << fileExtension << std::endl;

// نوع فایل را به ZIP تغییر دهید.
oleFrame->SetEmbeddedData(MakeObject<OleEmbeddedDataInfo>(fileData, u"zip"));

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **تنظیم تصویر آیکن و عنوان برای اشیاء جاسازی‌شده**

پس از جاسازی یک شیء OLE، یک پیش‌نمایش شامل تصویر آیکن به‌صورت خودکار اضافه می‌شود. این پیش‌نمایش همان چیزی است که کاربران قبل از دسترسی یا باز کردن شیء OLE می‌بینند. اگر می‌خواهید از تصویر و متن خاصی به‌عنوان عناصر پیش‌نمایش استفاده کنید، می‌توانید تصویر آیکن و عنوان را با Aspose.Slides برای C++ تنظیم کنید.  

این کد C++ نشان می‌دهد چگونه تصویر آیکن و عنوان برای یک شیء جاسازی‌شده تنظیم شود:  

``` cpp
#include <DOM/IImageCollection.h>
#include <DOM/IOleObjectFrame.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);
auto oleFrame = ExplicitCast<IOleObjectFrame>(slide->get_Shape(0));

// Add an image to the presentation resources.
auto imageData = File::ReadAllBytes(u"image.png");
auto oleImage = presentation->get_Images()->AddImage(imageData);

// Set a title and the image for the OLE preview.
oleFrame->set_SubstitutePictureTitle(u"My title");
oleFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(oleImage);
oleFrame->set_IsObjectIcon(true);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **جلوگیری از تغییر اندازه و موقعیت‌گیری خودکار قاب OLE Object**

پس از افزودن یک شیء OLE لینک‌شده به اسلاید ارائه، زمانی که ارائه را در PowerPoint باز می‌کنید ممکن است پیامی مبنی بر به‌روزرسانی لینک‌ها مشاهده کنید. کلیک بر دکمه «Update Links» ممکن است اندازه و موقعیت قاب شیء OLE را تغییر دهد زیرا PowerPoint داده‌ها را از شیء OLE لینک‌شده به‌روز می‌کند و پیش‌نمایش شیء را تازه می‌کند. برای جلوگیری از این درخواست به‌روزرسانی دادهٔ شیء، متد `set_UpdateAutomatic` رابط [IOleObjectFrame](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ioleobjectframe/) را روی `false` تنظیم کنید:  

```cpp
#include <DOM/IOleObjectFrame.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);
auto oleFrame = ExplicitCast<IOleObjectFrame>(slide->get_Shape(0));

oleFrame->set_UpdateAutomatic(false);
```

## **استخراج فایل‌های جاسازی‌شده**

Aspose.Slides برای C++ به شما اجازه می‌دهد فایل‌های جاسازی‌شده در اسلایدها به‌صورت اشیاء OLE را به این شکل استخراج کنید:  

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.presentation) ایجاد کنید که شامل اشیاء OLE موردنظر برای استخراج باشد.  
2. تمام شکل‌ها در ارائه را مرور کنید و به شکل‌های [OLEObjectFrame](https://reference.aspose.com/slides/fa/cpp/aspose.slides/oleobjectframe/) دسترسی پیدا کنید.  
3. داده‌های فایل‌های جاسازی‌شده را از قاب‌های OLE Object استخراج کرده و بر روی دیسک ذخیره کنید.  

این کد C++ نشان می‌دهد چگونه فایل‌های جاسازی‌شده در یک اسلاید به‌صورت اشیاء OLE استخراج شوند:  

``` cpp
#include <DOM/IOleEmbeddedDataInfo.h>
#include <DOM/IOleObjectFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/io/file.h>
#include <system/object_ext.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

for (int index = 0; index < slide->get_Shapes()->get_Count(); index++)
{
    auto shape = slide->get_Shape(index);

    if (ObjectExt::Is<IOleObjectFrame>(shape))
    { 
        auto oleFrame = ExplicitCast<IOleObjectFrame>(shape);

        auto fileData = oleFrame->get_EmbeddedData()->get_EmbeddedFileData();
        auto fileExtension = oleFrame->get_EmbeddedData()->get_EmbeddedFileExtension();

        auto fileName = String::Format(u"OLE_object_{0}{1}", index, fileExtension);
        File::WriteAllBytes(fileName, fileData);
    }
}

presentation->Dispose();
```

## **پرسش‌های متداول**

### آیا محتوای OLE هنگام صادرات اسلایدها به PDF/تصاویر رندر می‌شود؟

آنچه در اسلاید قابل مشاهده است رندر می‌شود — تصویر آیکن/جایگزین (پیش‌نمایش). محتوای «زنده» OLE در زمان رندر اجرا نمی‌شود. در صورت نیاز می‌توانید تصویر پیش‌نمایش خود را تنظیم کنید تا ظاهر موردنظر در PDF خروجی تضمین شود.  

### چگونه می‌توان یک شیء OLE را در اسلاید قفل کرد تا کاربران نتوانند آن را در PowerPoint حرکت یا ویرایش کنند؟

شکل را قفل کنید: Aspose.Slides قفل‌های سطح شکل [/slides/fa/cpp/applying-protection-to-presentation/] را فراهم می‌کند. این قفل‌ها رمزگذاری نیستند، اما به‌طور مؤثری از ویرایش‌های ناخواسته و جابجایی جلوگیری می‌کنند.  

### چرا یک شیء Excel لینک‌شده هنگام باز کردن ارائه «پرش» می‌کند یا اندازه‌اش تغییر می‌یابد؟

PowerPoint ممکن است پیش‌نمایش OLE لینک‌شده را تازه کند. برای داشتن ظاهری ثابت، روش‌های پیشنهادی «Working Solution for Worksheet Resizing» [/slides/fa/cpp/working-solution-for-worksheet-resizing/] را دنبال کنید — یا قاب را به محدوده منطبق کنید، یا محدوده را به یک قاب ثابت مقیاس‌گذاری کنید و تصویر جایگزین مناسب تنظیم کنید.  

### آیا مسیرهای نسبی برای شیءهای OLE لینک‌شده در قالب PPTX حفظ می‌شوند؟

در PPTX اطلاعات «مسیر نسبی» موجود نیست — فقط مسیر کامل ذخیره می‌شود. مسیرهای نسبی در قالب قدیمی PPT یافت می‌شوند. برای قابلیت حمل، بهتر است از مسیرهای مطلق قابل اطمینان/URIهای در دسترس یا روش جاسازی استفاده کنید.