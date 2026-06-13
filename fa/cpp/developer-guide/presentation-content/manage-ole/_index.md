---
title: مدیریت OLE در ارائه‌ها با استفاده از C++
linktitle: مدیریت OLE
type: docs
weight: 40
url: /fa/cpp/manage-ole/
keywords:
- شیء OLE
- پیوند و تعبیه شیء
- افزودن OLE
- تعبیه OLE
- افزودن شیء
- تعبیه شیء
- افزودن فایل
- تعبیه فایل
- شیء لینک‌دار
- فایل لینک‌دار
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
description: "بهینه‌سازی مدیریت اشیاء OLE در فایل‌های PowerPoint و OpenDocument با Aspose.Slides برای C++. ارائه، به‌روزرسانی و صادرات محتوای OLE را به‌سراسر انجام دهید."
---
## **مقدمه**

{{% alert title="اطلاعات" color="info" %}}

OLE (Object Linking & Embedding) یک فناوری مایکروسافت است که امکان قرار دادن داده‌ها و اشیائی که در یک برنامه ایجاد شده‌اند را از طریق لینک کردن یا تعبیه در برنامه‌ای دیگر فراهم می‌کند. 

{{% /alert %}} 

تصور کنید نموداری در MS Excel ساخته شده است. سپس این نمودار داخل یک اسلاید PowerPoint قرار می‌گیرد. آن نمودار Excel یک شیء OLE محسوب می‌شود. 

- یک شیء OLE ممکن است به‌صورت آیکون نمایش داده شود. در این حالت، هنگام دابل‑کلیک روی آیکون، نمودار در برنامه مرتبط (Excel) باز می‌شود یا از شما خواسته می‌شود برنامه‌ای برای باز یا ویرایش شیء انتخاب کنید. 
- یک شیء OLE می‌تواند محتوای واقعی خود را نمایش دهد، مانند محتوای یک نمودار. در این حالت، نمودار در PowerPoint فعال می‌شود، رابط کاربری نمودار بارگذاری می‌شود و می‌توانید داده‌های نمودار را از داخل PowerPoint اصلاح کنید.

[Aspose.Slides for C++](https://products.aspose.com/slides/fa/cpp/) به شما امکان می‌دهد اشیاء OLE را به صورت فریم‌های شیء OLE ([OleObjectFrame](https://reference.aspose.com/slides/fa/cpp/aspose.slides/oleobjectframe/)) به اسلایدها اضافه کنید.

## **اضافه کردن فریم‌های شیء OLE به اسلایدها**

فرض کنید یک نمودار در Microsoft Excel ساخته‌اید و می‌خواهید آن را به‌عنوان فریم شیء OLE در یک اسلاید تعبیه کنید با استفاده از Aspose.Slides for C++. می‌توانید به‌صورت زیر عمل کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.presentation) ایجاد کنید.  
2. مرجع اسلاید را از طریق اندیس آن دریافت کنید.  
3. فایل Excel را به‌صورت آرایه بایت بخوانید.  
4. فریم [OleObjectFrame](https://reference.aspose.com/slides/fa/cpp/aspose.slides/oleobjectframe/) را به اسلاید اضافه کنید، همراه با آرایه بایت و سایر اطلاعات درباره شیء OLE.  
5. ارائه اصلاح شده را به‌صورت فایل PPTX ذخیره کنید.  

در مثال زیر، یک نمودار از فایل Excel را به‌عنوان یک [OleObjectFrame](https://reference.aspose.com/slides/fa/cpp/aspose.slides/oleobjectframe/) به اسلاید اضافه کردیم با استفاده از Aspose.Slides for C++.  
**توجه** داشته باشید سازنده [OleEmbeddedDataInfo](https://reference.aspose.com/slides/fa/cpp/aspose.slides.dom.ole/oleembeddeddatainfo/) یک پسوند شیء قابل تعبیه را به‌عنوان پارامتر دوم می‌گیرد. این پسوند به PowerPoint امکان می‌دهد نوع فایل را به‌درستی تفسیر کرده و برنامه مناسب برای باز کردن این شیء OLE را انتخاب کند.

``` cpp
auto presentation = MakeObject<Presentation>();
auto slideSize = presentation->get_SlideSize()->get_Size();
auto slide = presentation->get_Slide(0);

// داده‌های مورد نیاز برای شیء OLE را آماده کنید.
auto fileData = File::ReadAllBytes(u"book.xlsx");
auto dataInfo = MakeObject<OleEmbeddedDataInfo>(fileData, u"xlsx");

// Add the OLE object frame to the slide.
slide->get_Shapes()->AddOleObjectFrame(0, 0, slideSize.get_Width(), slideSize.get_Height(), dataInfo);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

### **اضافه کردن فریم‌های شیء OLE لینک‌دار**

Aspose.Slides for C++ به شما امکان می‌دهد یک [OleObjectFrame](https://reference.aspose.com/slides/fa/cpp/aspose.slides/oleobjectframe/) بدون تعبیه داده‌ها اما فقط با لینک به فایل اضافه کنید.

کد C++ زیر نشان می‌دهد چگونه یک [OleObjectFrame](https://reference.aspose.com/slides/fa/cpp/aspose.slides/oleobjectframe/) با فایل Excel لینک‌دار به اسلاید اضافه شود:

```cpp
auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

// یک فریم شیء OLE با فایل Excel لینک‌دار اضافه کنید.
slide->get_Shapes()->AddOleObjectFrame(20, 20, 200, 150, u"Excel.Sheet.12", u"book.xlsx");

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **دسترسی به فریم‌های شیء OLE**

اگر یک شیء OLE قبلاً در اسلاید تعبیه شده باشد، می‌توانید به‌ راحتی آن را پیدا یا دسترسی پیدا کنید:

1. یک ارائه شامل شیء OLE تعبیه‌شده را با ایجاد یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.presentation) بارگذاری کنید.  
2. مرجع اسلاید را با استفاده از اندیس آن به‌دست آورید.  
3. شکل [OleObjectFrame](https://reference.aspose.com/slides/fa/cpp/aspose.slides/oleobjectframe/) را دسترسی پیدا کنید.  
   در مثال ما، PPTX قبلی که فقط یک شکل در اولین اسلاید دارد استفاده می‌شود. سپس آن شیء را به‌صورت یک [IOleObjectFrame](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ioleobjectframe/) *cast* می‌کنیم. این همان فریم شیء OLE مورد نظر برای دسترسی بود.  
4. پس از دسترسی به فریم شیء OLE، می‌توانید هر عملیاتی روی آن انجام دهید.  

در مثال زیر، یک فریم شیء OLE (یک شیء نمودار Excel تعبیه‌شده در اسلاید) و داده‌های فایل آن دسترسی پیدا می‌شوند.

``` cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shape(0);

if (ObjectExt::Is<IOleObjectFrame>(shape))
{ 
    auto oleFrame = ExplicitCast<IOleObjectFrame>(shape);

    // داده‌های فایل تعبیه‌شده را دریافت کنید.
    auto fileData = oleFrame->get_EmbeddedData()->get_EmbeddedFileData();

    // پسوند فایل تعبیه‌شده را دریافت کنید.
    auto fileExtension = oleFrame->get_EmbeddedData()->get_EmbeddedFileExtension();

    // ...
}
```

### **دسترسی به ویژگی‌های فریم شیء OLE لینک‌دار**

Aspose.Slides به شما امکان می‌دهد ویژگی‌های فریم شیء OLE لینک‌دار را دسترسی پیدا کنید.

این کد C++ نشان می‌دهد چگونه بررسی کنید آیا یک شیء OLE لینک‌دار است و سپس مسیر فایل لینک‌شده را دریافت کنید:

```cpp
auto presentation = MakeObject<Presentation>(u"sample.ppt");
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shape(0);

if (ObjectExt::Is<IOleObjectFrame>(shape))
{
    auto oleFrame = ExplicitCast<IOleObjectFrame>(shape);

    // بررسی کنید آیا شیء OLE لینک‌دار است.
    if (oleFrame->get_IsObjectLink())
    {
        // مسیر کامل فایل لینک‌دار را چاپ کنید.
        std::wcout << L"OLE object frame is linked to: " << oleFrame->get_LinkPathLong() << std::endl;

        // اگر موجود باشد، مسیر نسبی فایل لینک‌دار را چاپ کنید.
        // فقط ارائه‌های PPT می‌توانند مسیر نسبی را داشته باشند.
        if (!String::IsNullOrEmpty(oleFrame->get_LinkPathRelative()))
        {
            std::wcout << L"OLE object frame relative path: " << oleFrame->get_LinkPathRelative() << std::endl;
        }
    }
}
```

## **تغییر داده‌های شیء OLE**

{{% alert color="primary" %}} 

در این بخش، مثال کد زیر از [Aspose.Cells for C++](/cells/cpp/) استفاده می‌کند.

{{% /alert %}}

اگر یک شیء OLE قبلاً در اسلاید تعبیه شده باشد، می‌توانید به‌ راحتی آن را دسترسی پیدا کنید و داده‌های آن را به‌این صورت اصلاح کنید:

1. یک ارائه شامل شیء OLE تعبیه‌شده را با ایجاد یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.presentation) بارگذاری کنید.  
2. مرجع اسلاید را از طریق اندیس آن به‌دست آورید.  
3. شکل [OLEObjectFrame](https://reference.aspose.com/slides/fa/cpp/aspose.slides/oleobjectframe/) را دسترسی پیدا کنید.  
   در مثال ما، PPTX قبلی که یک شکل در اولین اسلاید دارد استفاده می‌شود. سپس آن شیء را به‌صورت یک [IOleObjectFrame](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ioleobjectframe/) *cast* می‌کنیم. این همان فریم شیء OLE مورد نظر برای دسترسی بود.  
4. پس از دسترسی به فریم شیء OLE، می‌توانید هر عملیاتی روی آن انجام دهید.  
5. یک شیء `Workbook` ایجاد کنید و به داده‌های OLE دسترسی پیدا کنید.  
6. `Worksheet` مورد نظر را دسترسی پیدا کنید و داده‌ها را اصلاح کنید.  
7. `Workbook` به‌روزشده را در یک استریم ذخیره کنید.  
8. داده‌های شیء OLE را از استریم تغییر دهید.  

در مثال زیر، یک فریم شیء OLE (یک شیء نمودار Excel تعبیه‌شده در اسلاید) دسترسی پیدا می‌شود و داده‌های فایل آن برای به‌روزرسانی داده‌های نمودار اصلاح می‌شود.

``` cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

// اولین شکل را به‌عنوان فریم شیء OLE دریافت کنید.
auto oleFrame = AsCast<IOleObjectFrame>(slide->get_Shape(0));

if (oleFrame != nullptr)
{
    auto oleStream = MakeObject<MemoryStream>(oleFrame->get_EmbeddedData()->get_EmbeddedFileData());

    // داده‌های شیء OLE را به‌عنوان شیء Workbook بخوانید.
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

    // داده‌های شیء فریم OLE را تغییر دهید.
    auto newData = MakeObject<OleEmbeddedDataInfo>(newOleStream->ToArray(), oleFrame->get_EmbeddedData()->get_EmbeddedFileExtension());
    oleFrame->SetEmbeddedData(newData);
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);
```

## **تعبیه انواع فایل‌های دیگر در اسلایدها**

به‌جز نمودارهای Excel، Aspose.Slides for C++ به شما امکان می‌دهد انواع دیگری از فایل‌ها را به اسلایدها تعبیه کنید. برای مثال می‌توانید فایل‌های HTML، PDF و ZIP را به‌عنوان اشیاء وارد کنید. وقتی کاربر روی شیء وارد‌شده دابل‑کلیک می‌کند، به‌صورت خودکار در برنامه مربوطه باز می‌شود یا از کاربر خواسته می‌شود برنامه مناسب برای باز کردن آن را انتخاب کند.

این کد C++ نشان می‌دهد چگونه HTML و ZIP را در یک اسلاید تعبیه کنید:

``` cpp
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

## **تنظیم نوع فایل برای اشیای تعبیه‌شده**

هنگام کار با ارائه‌ها، ممکن است نیاز داشته باشید اشیای OLE قدیمی را با اشیای جدید جایگزین کنید یا یک شیء OLE پشتیبانی‌نشده را با یک شیء پشتیبانی‌شده عوض کنید. Aspose.Slides for C++ به شما امکان می‌دهد نوع فایل برای یک شیء تعبیه‌شده تنظیم کنید، به‌طوری که بتوانید داده‌های فریم OLE یا پسوند آن را به‌روز کنید.

این کد C++ نشان می‌دهد چگونه نوع فایل برای یک شیء OLE تعبیه‌شده را به `zip` تنظیم کنید:

``` cpp
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

## **تنظیم تصویر آیکون و عنوان برای اشیای تعبیه‌شده**

پس از تعبیه یک شیء OLE، پیش‌نمایشی شامل تصویر آیکون به‌صورت خودکار اضافه می‌شود. این پیش‌نمایش همان چیزی است که کاربران پیش از دسترسی یا باز کردن شیء OLE می‌بینند. اگر می‌خواهید از تصویر و متن خاصی به‌عنوان عناصر پیش‌نمایش استفاده کنید، می‌توانید تصویر آیکون و عنوان را با Aspose.Slides for C++ تنظیم کنید.

این کد C++ نشان می‌دهد چگونه تصویر آیکون و عنوان را برای یک شیء تعبیه‌شده تنظیم کنید:

``` cpp
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

پس از افزودن یک شیء OLE لینک‌دار به اسلاید ارائه، وقتی ارائه را در PowerPoint باز می‌کنید، ممکن است پیامی مبنی بر به‌روزرسانی لینک‌ها مشاهده کنید. کلیک بر دکمه «Update Links» ممکن است اندازه و موقعیت فریم شیء OLE را تغییر دهد زیرا PowerPoint داده‌ها را از شیء OLE لینک‌دار به‌روز کرده و پیش‌نمایش شیء را تازه می‌کند. برای جلوگیری از درخواست PowerPoint برای به‌روزرسانی داده‌های شیء، متد `set_UpdateAutomatic` رابط [IOleObjectFrame](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ioleobjectframe/) را به `false` تنظیم کنید:

```cpp
oleFrame->set_UpdateAutomatic(false);
```

## **استخراج فایل‌های تعبیه‌شده**

Aspose.Slides for C++ به شما امکان می‌دهد فایل‌های تعبیه‌شده در اسلایدها به‌عنوان اشیای OLE را به‌این صورت استخراج کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.presentation) ایجاد کنید که شامل اشیای OLE مورد نظر برای استخراج باشد.  
2. تمام اشکال موجود در ارائه را مرور کنید و به اشکال [OLEObjectFrame](https://reference.aspose.com/slides/fa/cpp/aspose.slides/oleobjectframe/) دسترسی پیدا کنید.  
3. داده‌های فایل‌های تعبیه‌شده را از فریم‌های شیء OLE استخراج کرده و بر روی دیسک بنویسید.  

این کد C++ نشان می‌دهد چگونه فایل‌های تعبیه‌شده در یک اسلاید به‌عنوان اشیای OLE استخراج شوند:

``` cpp
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

**آیا محتوای OLE هنگام خروجی گرفتن اسلایدها به PDF/تصاویر رندر می‌شود؟**

آنچه بر روی اسلاید قابل مشاهده است رندر می‌شود — یعنی آیکون/تصویر جایگزین (پیشنمایش). محتوای «زنده» OLE در هنگام رندر اجرا نمی‌شود. در صورت نیاز، تصویر پیش‌نمایش خود را تنظیم کنید تا ظاهر مورد انتظار در PDF خروجی حفظ شود.

**چگونه می‌توان یک شیء OLE را در اسلاید قفل کرد تا کاربران نتوانند آن را در PowerPoint حرکت یا ویرایش کنند؟**

شکل را قفل کنید: Aspose.Slides قابلیت [قفل‌های سطح شکل](/slides/fa/cpp/applying-protection-to-presentation/) را فراهم می‌کند. این قفل‌گذاری رمزنگاری نیست، اما به‌طور مؤثر از ویرایش‌ها و جابجایی‌های تصادفی جلوگیری می‌کند.

**چرا یک شیء Excel لینک‌دار «پرش» می‌کند یا اندازه‌اش تغییر می‌دهد وقتی ارائه را باز می‌کنم؟**

PowerPoint ممکن است پیش‌نمایش OLE لینک‌دار را تازه کند. برای داشتن ظاهر ثابت، دستورالعمل‌های [راه‌حل کارآمد برای تغییر اندازه شیت‌گذاری](/slides/fa/cpp/working-solution-for-worksheet-resizing/) را دنبال کنید — یا فریم را با محدوده منطبق کنید، یا محدوده را به فریم ثابت مقیاس دهید و تصویر جایگزین مناسب تعیین کنید.

**آیا مسیرهای نسبی برای اشیای OLE لینک‌دار در قالب PPTX حفظ می‌شوند؟**

در PPTX، اطلاعات «مسیر نسبی» موجود نیست — فقط مسیر کامل ذخیره می‌شود. مسیرهای نسبی در فرمت قدیمی PPT یافت می‌شوند. برای قابلیت حمل، مسیرهای مطلق قابل‌اعتماد/URIهای قابل دسترس یا تعبیه را ترجیح دهید.