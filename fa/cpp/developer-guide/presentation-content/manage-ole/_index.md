---
title: مدیریت OLE در ارائه‌ها با C++
linktitle: مدیریت OLE
type: docs
weight: 40
url: /fa/cpp/manage-ole/
keywords:
- شیء OLE
- پیوند و جاسازی اشیا
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
- PowerPoint
- ارائه
- C++
- Aspose.Slides
description: "بهینه‌سازی مدیریت اشیاء OLE در فایل‌های PowerPoint و OpenDocument با Aspose.Slides برای C++. به‌صورت یکپارچه OLE را جاسازی، به‌روزرسانی و صادر کنید."
---
## **مقدمه**

{{% alert color="info" title="Note" %}}

OLE (Object Linking & Embedding) یک فناوری مایکروسافت است که امکان قرار دادن داده‌ها و اشیائی که در یک برنامه ایجاد شده‌اند را از طریق لینک یا جاسازی در برنامه دیگری می‌دهد. 

{{% /alert %}} 

یک نمودار ایجاد شده در MS Excel را در نظر بگیرید. سپس این نمودار داخل یک اسلاید PowerPoint قرار می‌گیرد. آن نمودار Excel به عنوان یک شیء OLE در نظر گرفته می‌شود. 

- یک شیء OLE ممکن است به صورت یک آیکون ظاهر شود. در این صورت، وقتی بر روی آیکون دوبار کلیک می‌کنید، نمودار در برنامه مرتبط خود (Excel) باز می‌شود، یا از شما خواسته می‌شود تا برنامه‌ای را برای باز کردن یا ویرایش شیء انتخاب کنید. 
- یک شیء OLE ممکن است محتویات واقعی خود را نمایش دهد، مانند محتویات یک نمودار. در این حالت، نمودار در PowerPoint فعال می‌شود، رابط کاربری نمودار بارگذاری می‌شود و می‌توانید داده‌های نمودار را درون PowerPoint ویرایش کنید.

[Aspose.Slides for C++](https://products.aspose.com/slides/cpp/) به شما امکان می‌دهد تا اشیاء OLE را به اسلایدها به عنوان فریم‌های شیء OLE ([OleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/)) وارد کنید.

## **افزودن فریم‌های شیء OLE به اسلایدها**

فرض کنید که قبلاً یک نمودار در Microsoft Excel ایجاد کرده‌اید و می‌خواهید آن را به عنوان فریم شیء OLE در یک اسلاید با استفاده از Aspose.Slides for C++ جاسازی کنید؛ می‌توانید به این روش انجام دهید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) ایجاد کنید.  
2. مرجع یک اسلاید را از طریق ایندکس آن دریافت کنید.  
3. فایل Excel را به عنوان یک آرایۀ بایت بخوانید.  
4. [OleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/) را به اسلاید اضافه کنید که شامل آرایۀ بایت و سایر اطلاعات درباره شیء OLE است.  
5. ارائهٔ اصلاح‌شده را به عنوان فایل PPTX ذخیره کنید.  

در مثال زیر، یک نمودار از فایل Excel را به عنوان یک [OleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/) به اسلاید اضافه کردیم با استفاده از Aspose.Slides for C++.  
**توجه** داشته باشید که سازندهٔ [OleEmbeddedDataInfo](https://reference.aspose.com/slides/cpp/aspose.slides.dom.ole/oleembeddeddatainfo/) یک پسوند شیء قابل جاسازی را به عنوان پارامتر دوم می‌گیرد. این پسوند به PowerPoint اجازه می‌دهد تا نوع فایل را به‌درستی تفسیر کند و برنامهٔ مناسب برای باز کردن این شیء OLE را انتخاب کند.

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

// Prepare data for the OLE object.
auto fileData = File::ReadAllBytes(u"book.xlsx");
auto dataInfo = MakeObject<OleEmbeddedDataInfo>(fileData, u"xlsx");

// Add the OLE object frame to the slide.
slide->get_Shapes()->AddOleObjectFrame(0, 0, slideSize.get_Width(), slideSize.get_Height(), dataInfo);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

### **افزودن فریم‌های شیء OLE لینک‌شده**

Aspose.Slides for C++ به شما امکان می‌دهد یک [OleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/) بدون جاسازی داده، اما فقط با لینک به فایل اضافه کنید.  
این کد C++ نشان می‌دهد چگونه یک [OleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/) با یک فایل Excel لینک‌شده به یک اسلاید اضافه کنید:

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

// یک فریم شیء OLE را با فایل Excel لینک‌شده اضافه کنید.
slide->get_Shapes()->AddOleObjectFrame(20, 20, 200, 150, u"Excel.Sheet.12", u"book.xlsx");

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **دسترسی به فریم‌های شیء OLE**

اگر یک شیء OLE قبلاً در یک اسلاید جاسازی شده باشد، می‌توانید به راحتی آن را به این روش پیدا یا دسترسی پیدا کنید:

1. با ایجاد یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) یک ارائه شامل شیء OLE جاسازی‌شده بارگذاری کنید.  
2. مرجع اسلاید را با استفاده از ایندکس آن دریافت کنید.  
3. به شکل [OleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/) دسترس پیدا کنید.  
   در مثال ما، PPTX قبلاً ایجاد شده‌ای که فقط یک شکل در اسلاید اول دارد را استفاده کردیم. سپس آن شیء را به‌عنوان [IOleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ioleobjectframe/) *cast* (تبدیل) کردیم. این فریم شیء OLE موردنظر برای دسترسی بود.  
4. پس از دسترسی به فریم شیء OLE، می‌توانید هر عملیاتی روی آن انجام دهید.  

در مثال زیر، یک فریم شیء OLE (یک شیء نمودار Excel که در اسلاید جاسازی شده) و داده‌های فایلی آن دسترسی پیدا می‌شوند.

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

    // دریافت داده‌های فایل جاسازی‌شده.
    auto fileData = oleFrame->get_EmbeddedData()->get_EmbeddedFileData();

    // دریافت پسوند فایل جاسازی‌شده.
    auto fileExtension = oleFrame->get_EmbeddedData()->get_EmbeddedFileExtension();

    // ...
}
```

### **دسترسی به ویژگی‌های فریم شیء OLE لینک‌شده**

Aspose.Slides به شما امکان می‌دهد ویژگی‌های فریم شیء OLE لینک‌شده را دسترسی پیدا کنید.  
این کد C++ نشان می‌دهد چگونه بررسی کنید آیا یک شیء OLE لینک‌شده است و سپس مسیر فایل لینک‌شده را بدست آورید:

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

    // بررسی می‌کند که آیا شیء OLE لینک‌شده است.
    if (oleFrame->get_IsObjectLink())
    {
        // مسیر کامل فایل لینک‌شده را چاپ می‌کند.
        std::wcout << L"OLE object frame is linked to: " << oleFrame->get_LinkPathLong() << std::endl;

        // مسیر نسبی فایل لینک‌شده را در صورت وجود چاپ می‌کند.
        // فقط ارائه‌های PPT می‌توانند مسیر نسبی را شامل شوند.
        if (!String::IsNullOrEmpty(oleFrame->get_LinkPathRelative()))
        {
        }
    }
}
```

## **تغییر داده‌های شیء OLE**

{{% alert color="info" title="Note" %}}

در این بخش، مثال کد زیر از [Aspose.Cells for C++](https://docs.aspose.com/cells/cpp/) استفاده می‌کند.

{{% /alert %}}

اگر یک شیء OLE قبلاً در اسلاید جاسازی شده باشد، می‌توانید به راحتی به آن دسترسی پیدا کنید و داده‌های آن را به این روش تغییر دهید:

1. با ایجاد یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) یک ارائه شامل شیء OLE جاسازی‌شده بارگذاری کنید.  
2. مرجع اسلاید را از طریق ایندکس آن دریافت کنید.  
3. به شکل [OLEObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/) دسترس پیدا کنید.  
   در مثال ما، PPTX قبلاً ایجاد شده‌ای که یک شکل در اسلاید اول دارد را استفاده کردیم. سپس آن شیء را به‌عنوان [IOleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ioleobjectframe/) *cast* (تبدیل) کردیم. این فریم شیء OLE موردنظر برای دسترسی بود.  
4. پس از دسترسی به فریم شیء OLE، می‌توانید هر عملیاتی روی آن انجام دهید.  
5. یک شیء `Workbook` ایجاد کنید و به داده‌های OLE دسترسی پیدا کنید.  
6. `Worksheet` موردنظر را دسترسی پیدا کنید و داده‌ها را اصلاح کنید.  
7. `Workbook` به‌روزشده را در یک جریان (stream) ذخیره کنید.  
8. داده‌های شیء OLE را از جریان تغییر دهید.  

در مثال زیر، یک فریم شیء OLE (یک شیء نمودار Excel که در اسلاید جاسازی شده) دسترسی پیدا می‌کند و داده‌های فایل آن برای به‌روزرسانی داده‌های نمودار اصلاح می‌شوند.

``` cpp
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

// Aspose.Cells برای C++ باید قبل از استفاده از هر یک از انواع آن آغاز شود.
Aspose::Cells::Startup();

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

// Get the first shape as an OLE object frame.
auto oleFrame = AsCast<IOleObjectFrame>(slide->get_Shape(0));

if (oleFrame != nullptr)
{
    auto oleStream = MakeObject<MemoryStream>(oleFrame->get_EmbeddedData()->get_EmbeddedFileData());

    // داده‌های شیء OLE را به‌عنوان یک شیء Workbook بخوانید.
    auto oleArray = oleStream->ToArray();
    std::vector<uint8_t> workbookData(oleArray->data().begin(), oleArray->data().end());
    Aspose::Cells::Workbook workbook(Aspose::Cells::Vector<uint8_t>(workbookData.data(), workbookData.size()));

    // داده‌های کتاب کار را اصلاح کنید.
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

    // داده‌های شیء فریم OLE را تغییر دهید.
    auto newData = MakeObject<OleEmbeddedDataInfo>(newOleStream->ToArray(), oleFrame->get_EmbeddedData()->get_EmbeddedFileExtension());
    oleFrame->SetEmbeddedData(newData);
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);

Aspose::Cells::Cleanup();
```

## **جاسازی انواع دیگر فایل‌ها در اسلایدها**

علاوه بر نمودارهای Excel، Aspose.Slides for C++ به شما امکان می‌دهد انواع دیگر فایل‌ها را در اسلایدها جاسازی کنید. به عنوان مثال، می‌توانید فایل‌های HTML، PDF و ZIP را به عنوان اشیاء وارد کنید. وقتی کاربر بر روی شیء وارد شده دوبار کلیک می‌کند، به‌صورت خودکار در برنامه مرتبط باز می‌شود یا از کاربر خواسته می‌شود تا برنامه مناسب را برای باز کردن آن انتخاب کند.  
این کد C++ نشان می‌دهد چگونه HTML و ZIP را در یک اسلاید جاسازی کنید:

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

## **تنظیم انواع فایل برای اشیاء جاسازی‌شده**

هنگام کار با ارائه‌ها، ممکن است نیاز داشته باشید تا اشیاء OLE قدیمی را با جدید جایگزین کنید یا یک شیء OLE پشتیبانی‌نشده را با یک شیء پشتیبانی‌شده جابجا کنید. Aspose.Slides for C++ به شما امکان می‌دهد نوع فایل برای یک شیء جاسازی‌شده را تنظیم کنید، که به‌روزرسانی داده‌های فریم OLE یا پسوند آن را ممکن می‌سازد.  
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

// تغییر نوع فایل به ZIP.
oleFrame->SetEmbeddedData(MakeObject<OleEmbeddedDataInfo>(fileData, u"zip"));

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **تنظیم تصاویر آیکون و عناوین برای اشیاء جاسازی‌شده**

پس از جاسازی یک شیء OLE، پیش‌نمایشی متشکل از تصویر آیکون به‌صورت خودکار اضافه می‌شود. این پیش‌نمایش همان چیزی است که کاربران قبل از دسترسی یا باز کردن شیء OLE می‌بینند. اگر می‌خواهید از یک تصویر و متن خاص به‌عنوان عناصر پیش‌نمایش استفاده کنید، می‌توانید تصویر آیکون و عنوان را با استفاده از Aspose.Slides برای C++ تنظیم کنید.  
این کد C++ نشان می‌دهد چگونه تصویر آیکون و عنوان را برای یک شیء جاسازی‌شده تنظیم کنید: 

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

// یک تصویر به منابع ارائه اضافه کنید.
auto imageData = File::ReadAllBytes(u"image.png");
auto oleImage = presentation->get_Images()->AddImage(imageData);

// عنوان و تصویر را برای پیش‌نمایش OLE تنظیم کنید.
oleFrame->set_SubstitutePictureTitle(u"My title");
oleFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(oleImage);
oleFrame->set_IsObjectIcon(true);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **جلوگیری از تغییر اندازه و موقعیت فریم شیء OLE**

پس از افزودن یک شیء OLE لینک‌شده به یک اسلاید ارائه، وقتی ارائه را در PowerPoint باز می‌کنید، ممکن است پیغامی ببینید که از شما می‌خواهد لینک‌ها را به‌روز کنید. کلیک بر دکمهٔ "Update Links" ممکن است اندازه و موقعیت فریم شیء OLE را تغییر دهد چون PowerPoint داده‌ها را از شیء OLE لینک‌شده به‌روز می‌کند و پیش‌نمایش شیء را تازه می‌سازد. برای جلوگیری از درخواست PowerPoint برای به‌روزرسانی داده‌های شیء، متد [set_UpdateAutomatic](https://reference.aspose.com/slides/cpp/aspose.slides/ioleobjectframe/set_updateautomatic/) از رابط [IOleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ioleobjectframe/) را با مقدار `false` فراخوانی کنید:

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

Aspose.Slides for C++ به شما امکان می‌دهد فایل‌های جاسازی‌شده در اسلایدها را به‌عنوان اشیاء OLE به این صورت استخراج کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) ایجاد کنید که شامل اشیاء OLE موردنظر برای استخراج باشد.  
2. از طریق تمام اشکال در ارائه حلقه بزنید و به اشکال [OLEObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/) دسترس پیدا کنید.  
3. داده‌های فایل‌های جاسازی‌شده را از فریم‌های شیء OLE دسترسی پیدا کنید و به دیسک بنویسید.  

این کد C++ نشان می‌دهد چگونه فایل‌های جاسازی‌شده در یک اسلاید را به‌عنوان اشیاء OLE استخراج کنید:

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

## **سوالات متداول**

**آیا محتوای OLE در هنگام خروجی گرفتن اسلایدها به PDF/تصاویر رندر می‌شود؟**

آنچه روی اسلاید قابل مشاهده است رندر می‌شود — آیکون/تصویر جایگزین (پیش‌نمایش). محتوای "زنده" OLE در هنگام رندر اجرا نمی‌شود. در صورت نیاز، تصویر پیش‌نمایش خود را تنظیم کنید تا ظاهر موردنظر در PDF خروجی تضمین شود.  
برای حفظ فایل جاسازی‌شده به‌عنوان پیوست PDF، متد [PdfOptions::set_IncludeOleData](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_includeoledata/) را با `true` فراخوانی کنید. این گزینه به‌صورت پیش‌فرض غیرفعال است. برای یک مثال و دستورالعمل‌های بررسی پیوست، به [Preserve Embedded OLE Files as PDF Attachments](/slides/fa/cpp/convert-powerpoint-to-pdf/#preserve-embedded-ole-files-as-pdf-attachments) نگاه کنید.

**چگونه می‌توانم یک شیء OLE را روی اسلاید قفل کنم تا کاربران نتوانند آن را در PowerPoint جابجا/ویرایش کنند؟**

شکل را قفل کنید: Aspose.Slides [قفل‌های سطح شکل](/slides/fa/cpp/applying-protection-to-presentation/) را فراهم می‌کند. این قفل‌گذاری رمزگذاری نیست، اما به‌طور مؤثری از ویرایش‌ها و جابه‌جایی‌های ناخواسته جلوگیری می‌کند.

**چرا یک شیء Excel لینک‌شده هنگام باز کردن ارائه "پرش" می‌کند یا اندازه‌اش تغییر می‌یابد؟**

PowerPoint ممکن است پیش‌نمایش OLE لینک‌شده را تازه کند. برای داشتن ظاهر ثابت، روش‌های [Working Solution for Worksheet Resizing](/slides/fa/cpp/working-solution-for-worksheet-resizing/) را دنبال کنید — یا فریم را به محدوده متناسب کنید، یا محدوده را به فریم ثابت مقیاس‌بندی کنید و تصویر جایگزین مناسب تنظیم کنید.

**آیا مسیرهای نسبی برای اشیاء OLE لینک‌شده در قالب PPTX حفظ می‌شوند؟**

در PPTX اطلاعات "مسیر نسبی" موجود نیست — فقط مسیر کامل ذخیره می‌شود. مسیرهای نسبی در قالب قدیمی PPT یافت می‌شوند. برای قابلیت حمل، استفاده از مسیرهای مطمئن مطلق/URIهای قابل دسترس یا جاسازی را ترجیح دهید.