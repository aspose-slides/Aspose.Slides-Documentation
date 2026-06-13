---
title: مدیریت کنترل‌های ActiveX در ارائه‌ها با استفاده از C++
linktitle: ActiveX
type: docs
weight: 80
url: /fa/cpp/activex/
keywords:
- ActiveX
- کنترل ActiveX
- مدیریت ActiveX
- افزودن ActiveX
- ویرایش ActiveX
- پخش‌کننده رسانه
- PowerPoint
- ارائه
- C++
- Aspose.Slides
description: "یاد بگیرید چگونه Aspose.Slides برای C++ از ActiveX برای خودکارسازی و بهبود ارائه‌های PowerPoint استفاده می‌کند و به توسعه‌دهندگان کنترل قدرتمندی بر اسلایدها می‌دهد."
---
## **مقدمه**

کنترل‌های ActiveX در ارائه‌ها استفاده می‌شوند. Aspose.Slides برای C++ به شما امکان مدیریت کنترل‌های ActiveX را می‌دهد، اما مدیریت آن‌ها کمی دشوارتر و متفاوت از اشکال معمول ارائه است. از نسخه 18.1 Aspose.Slides برای C++، این مؤلفه از مدیریت کنترل‌های ActiveX پشتیبانی می‌کند. در حال حاضر می‌توانید به کنترل‌های ActiveX اضافه شده در ارائه خود دسترسی پیدا کنید و با استفاده از ویژگی‌های مختلف آن‌ها را ویرایش یا حذف کنید. به یاد داشته باشید، کنترل‌های ActiveX شکل نیستند و جزئی از IShapeCollection ارائه نیستند، بلکه در IControlCollection جداگانه قرار دارند. این مقاله نشان می‌دهد چگونه با آن‌ها کار کنید.

## **ویرایش یک کنترل ActiveX**
برای مدیریت یک کنترل ساده ActiveX مانند جعبه متن و دکمه ساده روی اسلاید:

1. یک نمونه از کلاس Presentation ایجاد کنید و ارائه‌ای که شامل کنترل‌های ActiveX است بارگذاری کنید.  
2. با استفاده از ایندکس، مرجع اسلاید را دریافت کنید.  
3. با دسترسی به IControlCollection، به کنترل‌های ActiveX در اسلاید دسترسی پیدا کنید.  
4. با استفاده از شیء ControlEx، به کنترل ActiveX TextBox1 دسترسی پیدا کنید.  
5. ویژگی‌های مختلف کنترل ActiveX TextBox1 شامل متن، قلم، ارتفاع قلم و موقعیت فریم را تغییر دهید.  
6. کنترل دسترسی دوم به نام CommandButton1 را دسترسی پیدا کنید.  
7. متن دکمه، قلم و موقعیت آن را تغییر دهید.  
8. موقعیت فریم‌های کنترل‌های ActiveX را جابجا کنید.  
9. ارائه ویرایش‌شده را در یک فایل PPTX ذخیره کنید.

قطعه کد زیر کنترل‌های ActiveX را در اسلایدهای ارائه به همان شکلی که در زیر نشان داده شده است به‌روز می‌کند.

``` cpp
// دسترسی به ارائه با  کنترل‌های ActiveX
auto presentation = System::MakeObject<Presentation>(u"ActiveX.pptm");

// دسترسی به اولین اسلاید در ارائه
auto slide = presentation->get_Slides()->idx_get(0);

// تغییر متن TextBox
auto control = slide->get_Controls()->idx_get(0);

if (control->get_Name() == u"TextBox1" && control->get_Properties() != nullptr)
{
    String newText = u"Changed text";
    control->get_Properties()->idx_set(u"Value", newText);

    // تغییر تصویر جایگزین. PowerPoint این تصویر را در هنگام فعال‌سازی ActiveX جایگزین می‌کند، بنابراین گاهی اوقات می‌توانید تصویر را بدون تغییر بگذارید.
    auto image = System::MakeObject<Bitmap>((int32_t)control->get_Frame()->get_Width(), (int32_t)control->get_Frame()->get_Height());
    auto graphics = Graphics::FromImage(image);
    auto brush = System::MakeObject<SolidBrush>(Color::FromKnownColor(KnownColor::Window));
    graphics->FillRectangle(brush, 0, 0, image->get_Width(), image->get_Height());

    auto font = System::MakeObject<Font>(control->get_Properties()->idx_get(u"FontName"), 14.0f);
    brush = System::MakeObject<SolidBrush>(Color::FromKnownColor(KnownColor::WindowText));
    graphics->DrawString(newText, font, brush, 10.0f, 4.0f);

    auto pen = System::MakeObject<Pen>(Color::FromKnownColor(KnownColor::ControlDark), 1.0f);
    graphics->DrawLines(pen, System::MakeArray<Point>({ System::Drawing::Point(0, image->get_Height() - 1), Point(0, 0), System::Drawing::Point(image->get_Width() - 1, 0) }));

    pen = System::MakeObject<Pen>(Color::FromKnownColor(KnownColor::ControlDarkDark), 1.0f);

    graphics->DrawLines(pen, System::MakeArray<Point>({ System::Drawing::Point(1, image->get_Height() - 2), Point(1, 1), System::Drawing::Point(image->get_Width() - 2, 1) }));

    pen = System::MakeObject<Pen>(Color::FromKnownColor(KnownColor::ControlLight), 1.0f);
    graphics->DrawLines(pen, System::MakeArray<Point>({ System::Drawing::Point(1, image->get_Height() - 1), System::Drawing::Point(image->get_Width() - 1, image->get_Height() - 1), System::Drawing::Point(image->get_Width() - 1, 1) }));

    pen = System::MakeObject<Pen>(Color::FromKnownColor(KnownColor::ControlLightLight), 1.0f);
    graphics->DrawLines(pen, System::MakeArray<Point>({ System::Drawing::Point(0, image->get_Height()), System::Drawing::Point(image->get_Width(), image->get_Height()), System::Drawing::Point(image->get_Width(), 0) }));

    System::SharedPtr<System::IO::MemoryStream> ms = System::MakeObject<System::IO::MemoryStream>();
    image->Save(ms, System::Drawing::Imaging::ImageFormat::get_Png());
    ms->Seek(0, System::IO::SeekOrigin::Begin);
    control->get_SubstitutePictureFormat()->get_Picture()->set_Image(presentation->get_Images()->AddImage(ms));
}

// تغییر عنوان دکمه
control = slide->get_Controls()->idx_get(1);

if (control->get_Name() == u"CommandButton1" && control->get_Properties() != nullptr)
{
    String newCaption = u"MessageBox";
    control->get_Properties()->idx_set(u"Caption", newCaption);

    // تغییر جایگزین
    auto image = System::MakeObject<Bitmap>((int32_t)control->get_Frame()->get_Width(), (int32_t)control->get_Frame()->get_Height());
    auto graphics = Graphics::FromImage(image);
    auto brush = System::MakeObject<SolidBrush>(Color::FromKnownColor(KnownColor::Control));
    graphics->FillRectangle(brush, 0, 0, image->get_Width(), image->get_Height());

    auto font = System::MakeObject<Font>(control->get_Properties()->idx_get(u"FontName"), 14.0f);
    brush = System::MakeObject<SolidBrush>(Color::FromKnownColor(KnownColor::WindowText));
    SizeF textSize = graphics->MeasureString(newCaption, font, std::numeric_limits<int32_t>::max());
    graphics->DrawString(newCaption, font, brush, (image->get_Width() - textSize.get_Width()) / 2, (image->get_Height() - textSize.get_Height()) / 2);

    auto pen = System::MakeObject<Pen>(Color::FromKnownColor(KnownColor::ControlLightLight), 1.0f);
    graphics->DrawLines(pen, System::MakeArray<Point>({ System::Drawing::Point(0, image->get_Height() - 1), Point(0, 0), System::Drawing::Point(image->get_Width() - 1, 0) }));

    pen = System::MakeObject<Pen>(Color::FromKnownColor(KnownColor::ControlLight), 1.0f);
    graphics->DrawLines(pen, System::MakeArray<Point>({ System::Drawing::Point(1, image->get_Height() - 2), Point(1, 1), System::Drawing::Point(image->get_Width() - 2, 1) }));

    pen = System::MakeObject<Pen>(Color::FromKnownColor(KnownColor::ControlDark), 1.0f);
    graphics->DrawLines(pen, System::MakeArray<Point>({ System::Drawing::Point(1, image->get_Height() - 1), System::Drawing::Point(image->get_Width() - 1, image->get_Height() - 1), System::Drawing::Point(image->get_Width() - 1, 1) }));

    pen = System::MakeObject<Pen>(Color::FromKnownColor(KnownColor::ControlDarkDark), 1.0f);
    graphics->DrawLines(pen, System::MakeArray<Point>({ System::Drawing::Point(0, image->get_Height()), System::Drawing::Point(image->get_Width(), image->get_Height()), System::Drawing::Point(image->get_Width(), 0) }));

    System::SharedPtr<System::IO::MemoryStream> ms = System::MakeObject<System::IO::MemoryStream>();
    image->Save(ms, System::Drawing::Imaging::ImageFormat::get_Png());
    ms->Seek(0, System::IO::SeekOrigin::Begin);
    control->get_SubstitutePictureFormat()->get_Picture()->set_Image(presentation->get_Images()->AddImage(ms));
}

// جابه‌جایی فریم‌های ActiveX به میزان 100 نقطه پایین
for (const auto& ctl : System::IterateOver<Control>(slide->get_Controls()))
{
    SharedPtr<IShapeFrame> frame = control->get_Frame();
    control->set_Frame(System::MakeObject<ShapeFrame>(frame->get_X(), frame->get_Y() + 100, frame->get_Width(), frame->get_Height(), frame->get_FlipH(), frame->get_FlipV(), frame->get_Rotation()));
}

// ذخیره ارائه با کنترل‌های ActiveX ویرایش‌شده
presentation->Save(u"withActiveX-edited_out.pptm", SaveFormat::Pptm);

// حالا حذف کنترل‌ها
slide->get_Controls()->Clear();

// ذخیره ارائه با کنترل‌های ActiveX پاک‌شده
presentation->Save(u"withActiveX.cleared_out.pptm", SaveFormat::Pptm);
```

## **افزودن یک کنترل ActiveX پخش‌کننده رسانه**
کنترل‌های ActiveX در ارائه‌ها استفاده می‌شوند. Aspose.Slides برای C++ به شما امکان افزودن و مدیریت کنترل‌های ActiveX را می‌دهد، اما مدیریت آن‌ها کمی دشوارتر و متفاوت از اشکال معمول ارائه است. از نسخه 18.1 Aspose.Slides برای C++، پشتیبانی از افزودن کنترل ActiveX پخش‌کننده رسانه به Aspose.Slides اضافه شده است. به یاد داشته باشید، کنترل‌های ActiveX شکل نیستند و جزئی از IShapeCollection ارائه نیستند، بلکه در IControlExCollection جداگانه قرار دارند. این مقاله نشان می‌دهد چگونه با آن‌ها کار کنید. برای مدیریت یک کنترل ActiveX پخش‌کننده رسانه، مراحل زیر را انجام دهید:

1. یک نمونه از کلاس Presentation ایجاد کنید و ارائه نمونه‌ای که شامل کنترل‌های ActiveX پخش‌کننده رسانه است بارگذاری کنید.  
2. یک نمونه از کلاس Presentation هدف ایجاد کنید و یک ارائه خالی تولید کنید.  
3. اسلاید حاوی کنترل ActiveX پخش‌کننده رسانه را از ارائه قالب به ارائه هدف کپی کنید.  
4. به اسلاید کپی‌شده در ارائه هدف دسترسی پیدا کنید.  
5. با دسترسی به IControlCollection، به کنترل‌های ActiveX در اسلاید دسترسی پیدا کنید.  
6. به کنترل ActiveX پخش‌کننده رسانه دسترسی پیدا کنید و مسیر ویدیو را با استفاده از ویژگی‌های آن تنظیم کنید.  
7. ارائه را در یک فایل PPTX ذخیره کنید.

``` cpp
// نمونه‌سازی کلاس Presentation که فایل PPTX را نمایندگی می‌کند
auto presentation = System::MakeObject<Presentation>(u"template.pptx");

// ایجاد یک نمونه ارائه خالی
auto newPresentation = System::MakeObject<Presentation>();

// حذف اسلاید پیش‌فرض
newPresentation->get_Slides()->RemoveAt(0);

// کپی‌برداری اسلاید همراه با کنترل ActiveX پخش‌کننده رسانه
newPresentation->get_Slides()->InsertClone(0, presentation->get_Slides()->idx_get(0));

// دسترسی به کنترل ActiveX پخش‌کننده رسانه و تنظیم مسیر ویدیو
newPresentation->get_Slides()->idx_get(0)->get_Controls()->idx_get(0)->get_Properties()->idx_set(u"URL", u"Wildlife.mp4");

// ذخیره‌سازی ارائه
newPresentation->Save(u"LinkingVideoActiveXControl_out.pptx", SaveFormat::Pptx);
```

## **سؤالات متداول**

**آیا Aspose.Slides کنترل‌های ActiveX را هنگام خواندن و ذخیره مجدد حفظ می‌کند اگر نتوان آنها را در زمان اجرا C++ اجرا کرد؟**

بله. Aspose.Slides آنها را به‌عنوان بخشی از ارائه در نظر می‌گیرد و می‌تواند ویژگی‌ها و فریم‌های آنها را خوانده/ویرایش کند؛ اجرای خود کنترل‌ها برای حفظ آنها ضروری نیست.

**کنترل‌های ActiveX چگونه با شیءهای OLE در یک ارائه متفاوت هستند؟**

کنترل‌های ActiveX کنترل‌های مدیریتی تعاملی (دکمه‌ها، جعبه‌های متن، پخش‌کننده رسانه) هستند، در حالی که [OLE](/slides/fa/cpp/manage-ole/) به اشیاء برنامه‌نویسی تعبیه‌شده (مثلاً یک صفحه‌کاری Excel) اشاره دارد. آنها به‌صورت متفاوت ذخیره و مدیریت می‌شوند و مدل ویژگی‌های متفاوتی دارند.

**آیا رویدادهای ActiveX و ماکروهای VBA در صورتی که فایل توسط Aspose.Slides اصلاح شده باشد کار می‌کنند؟**

Aspose.Slides نشانه‌گذاری و متادیتای موجود را حفظ می‌کند؛ با این حال، رویدادها و ماکروها فقط در PowerPoint روی ویندوز و زمانی که امنیت اجازه دهد اجرا می‌شوند. این کتابخانه VBA را اجرا نمی‌کند.