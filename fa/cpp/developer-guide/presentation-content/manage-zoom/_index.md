---
title: مدیریت Zoom ارائه در C++
linktitle: مدیریت Zoom
type: docs
weight: 60
url: /fa/cpp/manage-zoom/
keywords:
- زوم
- فریم زوم
- زوم اسلاید
- زوم بخش
- زوم خلاصه
- افزودن زوم
- پاورپوینت
- ارائه
- C++
- Aspose.Slides
description: "ایجاد و سفارشی‌سازی Zoom با Aspose.Slides برای C++ — پرش بین بخش‌ها، افزودن تصویر بندانگشتی و انتقال‌ها در ارائه‌های PPT، PPTX و ODP."
---
## **معرفی**

Zoomها در PowerPoint به شما اجازه می‌دهند بین اسلایدها، بخش‌ها و قسمت‌های خاص یک ارائه جابجا شوید. هنگام ارائه، این قابلیت برای ناوبری سریع در محتوا می‌تواند بسیار مفید باشد. 

![overview_image](Overview.png)

* برای خلاصه‌کردن کل ارائه در یک اسلاید، از [Summary Zoom](#Summary-Zoom) استفاده کنید.
* برای نمایش فقط اسلایدهای انتخاب شده، از [Slide Zoom](#Slide-Zoom) استفاده کنید.
* برای نمایش فقط یک بخش، از [Section Zoom](#Section-Zoom) استفاده کنید.

## **Zoom اسلاید**
Zoom اسلاید می‌تواند ارائه شما را پویاتر کند و امکان ناوبری آزاد بین اسلایدها را به هر ترتیبی که می‌خواهید بدون قطع جریان ارائه فراهم می‌آورد. Zoom اسلاید برای ارائه‌های کوتاه بدون بخش‌های متعدد عالی است، اما می‌توانید آن را در سناریوهای مختلف ارائه نیز به کار ببرید.

Zoom اسلاید به شما کمک می‌کند تا به چندین قطعه اطلاعات وارد شوید در حالی که احساس می‌کنید در یک بوم واحد هستید. 

![overview_image](slidezoomsel.png)

برای اشیای zoom اسلاید، Aspose.Slides ارائه می‌دهد enumeration [ZoomImageType](https://reference.aspose.com/slides/fa/cpp/aspose.slides/zoomimagetype/)، interface [IZoomFrame](https://reference.aspose.com/slides/fa/cpp/aspose.slides/izoomframe/) و برخی متدها تحت interface [IShapeCollection](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ishapecollection/).

### **Create Zoom Frames**
می‌توانید یک فریم زوم را به اسلاید این‌گونه اضافه کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) ایجاد کنید.
2. اسلایدهای جدیدی ایجاد کنید که قصد دارید فریم‌های زوم را به آن‌ها لینک کنید. 
3. متن شناسایی و پس‌زمینه‌ای به اسلایدهای ایجاد شده اضافه کنید.
4. فریم‌های زوم (حاوی ارجاع به اسلایدهای ایجاد شده) را به اسلاید اول اضافه کنید.
5. ارائهٔ اصلاح‌شده را به عنوان فایل PPTX ذخیره کنید.

این کد C++ نشان می‌دهد چگونه یک فریم زوم را بر روی اسلاید ایجاد کنید:

``` cpp 
void SetSlideBackground(SharedPtr<ISlide> slide, Color color)
{
    slide->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
    slide->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(color);
    slide->get_Background()->set_Type(BackgroundType::OwnBackground);
}
```

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

// Adds new slides to the presentation
auto slide2 = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
auto slide3 = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());

// Creates a background for the second slide
SetSlideBackground(slide2, Color::get_Cyan());

// Creates a text box for the second slide
auto autoshape = slide2->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 200.0f, 500.0f, 200.0f);
autoshape->get_TextFrame()->set_Text(u"Second Slide");

// Creates a background for the third slide
SetSlideBackground(slide3, Color::get_DarkKhaki());

// Create a text box for the third slide
autoshape = slide3->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 200.0f, 500.0f, 200.0f);
autoshape->get_TextFrame()->set_Text(u"Trird Slide");

// Adds ZoomFrame objects
slide0->get_Shapes()->AddZoomFrame(20.0f, 20.0f, 250.0f, 200.0f, slide2);
slide0->get_Shapes()->AddZoomFrame(200.0f, 250.0f, 250.0f, 200.0f, slide3);

// Saves the presentation
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```

### **Create Zoom Frames with Custom Images**
با Aspose.Slides برای C++ می‌توانید یک فریم زوم با تصویر پیش‌نمایش اسلاید متفاوت این‌گونه ایجاد کنید: 
1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) ایجاد کنید.
2. اسلاید جدیدی ایجاد کنید که قصد دارید فریم زوم را به آن لینک کنید. 
3. متن شناسایی و پس‌زمینه‌ای به اسلاید اضافه کنید.
4. یک شیء [IPPImage](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ippimage/) با افزودن تصویری به مجموعه Images مرتبط با شیء [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) ایجاد کنید که برای پر کردن فریم استفاده خواهد شد.
5. فریم‌های زوم (حاوی ارجاع به اسلاید ایجاد شده) را به اسلاید اول اضافه کنید.
6. ارائهٔ اصلاح‌شده را به عنوان فایل PPTX ذخیره کنید.

این کد C++ نشان می‌دهد چگونه یک فریم زوم با تصویر متفاوت ایجاد کنید:

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//یک اسلاید جدید به ارائه اضافه می‌کند
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());

// یک پس‌زمینه برای اسلاید دوم ایجاد می‌کند
SetSlideBackground(slide, Color::get_Cyan());

// یک جعبه متن برای اسلاید سوم ایجاد می‌کند
auto autoshape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 200.0f, 500.0f, 200.0f);
autoshape->get_TextFrame()->set_Text(u"Second Slide");

// یک تصویر جدید برای شیء زوم ایجاد می‌کند
auto image = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));

// یک شیء ZoomFrame را اضافه می‌کند
slide0->get_Shapes()->AddZoomFrame(20.0f, 20.0f, 300.0f, 200.0f, slide, image);

// ارائه را ذخیره می‌کند
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```

### **Format Zoom Frames**
در بخش‌های قبلی، نحوهٔ ایجاد فریم‌های زوم ساده را نشان دادیم. برای ایجاد فریم‌های زوم پیچیده‌تر، باید قالب‌بندی یک فریم ساده را تغییر دهید. گزینه‌های قالب‌بندی متعددی می‌توانید بر روی فریم زوم اعمال کنید. 

می‌توانید قالب‌بندی فریم زوم را بر روی اسلاید این‌گونه کنترل کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) ایجاد کنید.
2. اسلایدهای جدیدی ایجاد کنید که قصد دارید فریم زوم را به آن‌ها لینک کنید. 
3. متن شناسایی و پس‌زمینه‌ای به اسلایدهای ایجاد شده اضافه کنید.
4. فریم‌های زوم (حاوی ارجاع به اسلایدهای ایجاد شده) را به اسلاید اول اضافه کنید.
5. یک شیء [IPPImage](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ippimage/) با افزودن تصویری به مجموعه Images مرتبط با شیء [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) ایجاد کنید که برای پر کردن فریم استفاده خواهد شد.
6. تصویر سفارشی را برای اولین شیء فریم زوم تنظیم کنید.
7. قالب خط را برای شیء دوم فریم زوم تغییر دهید.
8. پس‌زمینه تصویر شیء دوم فریم زوم را حذف کنید.
5. ارائهٔ اصلاح‌شده را به عنوان فایل PPTX ذخیره کنید.

این کد C++ نشان می‌دهد چگونه قالب‌بندی یک فریم زوم را بر روی اسلاید تغییر دهید: 

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide1 = pres->get_Slides()->idx_get(0);
// اسلایدهای جدید را به ارائه اضافه می‌کند
auto slide2 = pres->get_Slides()->AddEmptySlide(slide1->get_LayoutSlide());
auto slide3 = pres->get_Slides()->AddEmptySlide(slide1->get_LayoutSlide());

// یک پس‌زمینه برای اسلاید دوم ایجاد می‌کند
SetSlideBackground(slide2, Color::get_Cyan());

// یک جعبه متن برای اسلاید دوم ایجاد می‌کند
auto autoshape = slide2->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 200.0f, 500.0f, 200.0f);
autoshape->get_TextFrame()->set_Text(u"Second Slide");

// یک پس‌زمینه برای اسلاید سوم ایجاد می‌کند
SetSlideBackground(slide3, Color::get_DarkKhaki());

// یک جعبه متن برای اسلاید سوم ایجاد می‌کند
autoshape = slide3->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 200.0f, 500.0f, 200.0f);
autoshape->get_TextFrame()->set_Text(u"Trird Slide");

// فریم‌های Zoom را اضافه می‌کند
auto zoomFrame1 = slide1->get_Shapes()->AddZoomFrame(20.0f, 20.0f, 250.0f, 200.0f, slide2);
auto zoomFrame2 = slide1->get_Shapes()->AddZoomFrame(200.0f, 250.0f, 250.0f, 200.0f, slide3);

// یک تصویر جدید برای شیء زوم ایجاد می‌کند
auto image = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));
// تصویر سفارشی را برای شیء zoomFrame1 تنظیم می‌کند
zoomFrame1->set_Image(image);

// قالب فریم زوم را برای شیء zoomFrame2 تنظیم می‌کند
zoomFrame2->get_LineFormat()->set_Width(5);
zoomFrame2->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
zoomFrame2->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_HotPink());
zoomFrame2->get_LineFormat()->set_DashStyle(LineDashStyle::DashDot);

// تنظیم برای عدم نمایش پس‌زمینه برای شیء zoomFrame2
zoomFrame2->set_ShowBackground(false);

// ارائه را ذخیره می‌کند
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```

## **Zoom بخش**
Zoom بخش یک لینک به یک بخش در ارائهٔ شما است. می‌توانید از Zoom بخش برای بازگشت به بخش‌هایی که می‌خواهید به شدت برجسته کنید استفاده کنید. یا می‌توانید از آن برای نشان دادن نحوهٔ اتصال قسمت‌های مختلف ارائه استفاده کنید. 

![overview_image](seczoomsel.png)

برای اشیای zoom بخش، Aspose.Slides ارائه می‌دهد interface [ISectionZoomFrame](https://reference.aspose.com/slides/fa/cpp/aspose.slides/isectionzoomframe/) و برخی متدها تحت interface [IShapeCollection](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ishapecollection/).

### **Create Section Zoom Frames**
می‌توانید یک فریم zoom بخش را به اسلاید این‌گونه اضافه کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) ایجاد کنید.
2. یک اسلاید جدید ایجاد کنید. 
3. پس‌زمینه شناسایی به اسلاید ایجاد شده اضافه کنید.
4. یک بخش جدید ایجاد کنید که قصد دارید فریم زوم را به آن لینک کنید. 
5. یک فریم zoom بخش (حاوی ارجاع به بخش ایجاد شده) را به اسلاید اول اضافه کنید.
6. ارائهٔ اصلاح‌شده را به عنوان فایل PPTX ذخیره کنید.

این کد C++ نشان می‌دهد چگونه یک فریم زوم را بر روی اسلاید ایجاد کنید:

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

// یک اسلاید جدید به ارائه اضافه می‌کند
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_YellowGreen());

// یک بخش جدید به ارائه اضافه می‌کند
pres->get_Sections()->AddSection(u"Section 1", slide);

// یک شیء SectionZoomFrame اضافه می‌کند
auto sectionZoomFrame = slide0->get_Shapes()->AddSectionZoomFrame(20.0f, 20.0f, 300.0f, 200.0f, pres->get_Sections()->idx_get(1));

// ارائه را ذخیره می‌کند
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```
### **Create Section Zoom Frames with Custom Images**
با استفاده از Aspose.Slides برای C++، می‌توانید یک فریم zoom بخش با تصویر پیش‌نمایش اسلاید متفاوت این‌گونه ایجاد کنید: 

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) ایجاد کنید.
2. یک اسلاید جدید ایجاد کنید.
3. پس‌زمینه شناسایی به اسلاید ایجاد شده اضافه کنید.
4. یک بخش جدید ایجاد کنید که قصد دارید فریم زوم را به آن لینک کنید. 
5. یک شیء [IPPImage](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ippimage/) با افزودن تصویری به مجموعه Images مرتبط با شیء [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) ایجاد کنید که برای پر کردن فریم استفاده خواهد شد.
5. یک فریم zoom بخش (حاوی ارجاع به بخش ایجاد شده) را به اسلاید اول اضافه کنید.
6. ارائهٔ اصلاح‌شده را به عنوان فایل PPTX ذخیره کنید.

این کد C++ نشان می‌دهد چگونه یک فریم زوم با تصویر متفاوت ایجاد کنید:

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//یک اسلاید جدید به ارائه اضافه می‌کند
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_YellowGreen());

// یک بخش جدید به ارائه اضافه می‌کند
pres->get_Sections()->AddSection(u"Section 1", slide);

// یک تصویر جدید برای شیء زوم ایجاد می‌کند
auto image = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));

// شیء SectionZoomFrame اضافه می‌کند
auto sectionZoomFrame = slide0->get_Shapes()->AddSectionZoomFrame(20.0f, 20.0f, 300.0f, 200.0f, pres->get_Sections()->idx_get(1), image);

// ارائه را ذخیره می‌کند
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```

### **Format Section Zoom Frames**
برای ایجاد فریم‌های zoom بخش پیچیده‌تر، باید قالب‌بندی یک فریم ساده را تغییر دهید. گزینه‌های قالب‌بندی متعددی می‌توانید بر روی فریم zoom بخش اعمال کنید. 

می‌توانید قالب‌بندی فریم zoom بخش را بر روی اسلاید این‌گونه کنترل کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) ایجاد کنید.
2. یک اسلاید جدید ایجاد کنید.
3. پس‌زمینه شناسایی به اسلاید ایجاد شده اضافه کنید.
4. یک بخش جدید ایجاد کنید که قصد دارید فریم زوم را به آن لینک کنید. 
5. فریم zoom بخش (حاوی ارجاع به بخش ایجاد شده) را به اسلاید اول اضافه کنید.
6. اندازه و موقعیت شیء zoom بخش ایجاد شده را تغییر دهید.
7. یک شیء [IPPImage](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ippimage/) با افزودن تصویری به مجموعه Images مرتبط با شیء [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) ایجاد کنید که برای پر کردن فریم استفاده خواهد شد.
8. تصویر سفارشی را برای شیء فریم zoom بخش ایجاد شده تنظیم کنید.
9. قابلیت *بازگشت به اسلاید اصلی از بخش لینک‌شده* را فعال کنید. 
10. پس‌زمینه تصویر شیء فریم zoom بخش را حذف کنید.
11. قالب خط را برای شیء دوم فریم زوم تغییر دهید.
12. مدت زمان انتقال را تغییر دهید.
13. ارائهٔ اصلاح‌شده را به عنوان فایل PPTX ذخیره کنید.

این کد C++ نشان می‌دهد چگونه قالب‌بندی فریم zoom بخش را تغییر دهید:

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//یک اسلاید جدید به ارائه اضافه می‌کند
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_YellowGreen());

// یک بخش جدید به ارائه اضافه می‌کند
pres->get_Sections()->AddSection(u"Section 1", slide);

// یک شیء SectionZoomFrame اضافه می‌کند
auto sectionZoomFrame = slide0->get_Shapes()->AddSectionZoomFrame(20.0f, 20.0f, 300.0f, 200.0f, pres->get_Sections()->idx_get(1));

// قالب‌بندی برای SectionZoomFrame
sectionZoomFrame->set_X(100.0f);
sectionZoomFrame->set_Y(300.0f);
sectionZoomFrame->set_Width(100.0f);
sectionZoomFrame->set_Height(75.0f);

auto image = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));
sectionZoomFrame->set_Image(image);

sectionZoomFrame->set_ReturnToParent(true);
sectionZoomFrame->set_ShowBackground(false);

auto sectionZoomLineFormat = sectionZoomFrame->get_LineFormat();
sectionZoomLineFormat->get_FillFormat()->set_FillType(FillType::Solid);
sectionZoomLineFormat->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Brown());
sectionZoomLineFormat->set_DashStyle(LineDashStyle::DashDot);
sectionZoomLineFormat->set_Width(2.5f);

sectionZoomFrame->set_TransitionDuration(1.5f);

// ارائه را ذخیره می‌کند
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```

## **Zoom خلاصه**
Zoom خلاصه شبیه یک صفحه فرود است که تمام قطعات ارائهٔ شما یک‌جا نمایش داده می‌شوند. هنگام ارائه، می‌توانید از zoom برای رفتن از یک مکان به مکان دیگر در هر ترتیبی که می‌خواهید استفاده کنید. می‌توانید خلاق باشید، جلو بپرید یا بخش‌هایی از اسلایدشو را بدون قطع جریان ارائه مرور کنید.

![overview_image](sumzoomsel.png)

برای اشیای zoom خلاصه، Aspose.Slides ارائه می‌دهد interfaceهای [ISummaryZoomFrame](https://reference.aspose.com/slides/fa/cpp/aspose.slides/isummaryzoomframe/)، [ISummaryZoomSection](https://reference.aspose.com/slides/fa/cpp/aspose.slides/isummaryzoomsection/)، و [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/fa/cpp/aspose.slides/isummaryzoomsectioncollection/) و برخی متدها تحت interface [IShapeCollection](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ishapecollection/).

### **Create Summary Zoom**
می‌توانید یک فریم zoom خلاصه را به اسلاید این‌گونه اضافه کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) ایجاد کنید.
2. اسلایدهای جدید با پس‌زمینه شناسایی و بخش‌های جدید برای اسلایدهای ایجاد شده ایجاد کنید.
3. فریم zoom خلاصه را به اسلاید اول اضافه کنید.
4. ارائهٔ اصلاح‌شده را به عنوان فایل PPTX ذخیره کنید.

این کد C++ نشان می‌دهد چگونه یک فریم zoom خلاصه را بر روی اسلاید ایجاد کنید:

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

// یک اسلاید جدید به ارائه اضافه می‌کند
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Brown());

// یک بخش جدید به ارائه اضافه می‌کند
pres->get_Sections()->AddSection(u"Section 1", slide);

// یک اسلاید جدید به ارائه اضافه می‌کند
slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Aqua());

// یک بخش جدید به ارائه اضافه می‌کند
pres->get_Sections()->AddSection(u"Section 2", slide);

// یک اسلاید جدید به ارائه اضافه می‌کند
slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Chartreuse());

// یک بخش جدید به ارائه اضافه می‌کند
pres->get_Sections()->AddSection(u"Section 3", slide);

// یک اسلاید جدید به ارائه اضافه می‌کند
slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_DarkGreen());

// یک بخش جدید به ارائه اضافه می‌کند
pres->get_Sections()->AddSection(u"Section 4", slide);

// یک شیء SummaryZoomFrame اضافه می‌کند
auto summaryZoomFrame = slide0->get_Shapes()->AddSummaryZoomFrame(150.0f, 50.0f, 300.0f, 200.0f);

// ارائه را ذخیره می‌کند
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```

### **Add and Remove a Summary Zoom Section**
تمام بخش‌ها در یک فریم zoom خلاصه توسط اشیای [ISummaryZoomSection](https://reference.aspose.com/slides/fa/cpp/aspose.slides/isummaryzoomsection/) نمایش داده می‌شوند که در شیء [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/fa/cpp/aspose.slides/isummaryzoomsectioncollection/) ذخیره می‌شوند. می‌توانید یک بخش zoom خلاصه را از طریق interface [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/fa/cpp/aspose.slides/isummaryzoomsectioncollection/) این‌گونه اضافه یا حذف کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) ایجاد کنید.
2. اسلایدهای جدید با پس‌زمینه شناسایی و بخش‌های جدید برای اسلایدهای ایجاد شده ایجاد کنید.
3. فریم zoom خلاصه را به اسلاید اول اضافه کنید.
4. اسلاید و بخش جدیدی به ارائه اضافه کنید.
5. بخش ایجاد شده را به فریم zoom خلاصه اضافه کنید.
6. اولین بخش را از فریم zoom خلاصه حذف کنید.
7. ارائهٔ اصلاح‌شده را به عنوان فایل PPTX ذخیره کنید.

این کد C++ نشان می‌دهد چگونه بخش‌ها را در یک فریم zoom خلاصه اضافه و حذف کنید:

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//یک اسلاید جدید به ارائه اضافه می‌کند
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Brown());

// یک بخش جدید به ارائه اضافه می‌کند
pres->get_Sections()->AddSection(u"Section 1", slide);

//یک اسلاید جدید به ارائه اضافه می‌کند
slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Aqua());

// یک بخش جدید به ارائه اضافه می‌کند
pres->get_Sections()->AddSection(u"Section 2", slide);

// یک شیء SummaryZoomFrame اضافه می‌کند
auto summaryZoomFrame = slide0->get_Shapes()->AddSummaryZoomFrame(150.0f, 50.0f, 300.0f, 200.0f);

//یک اسلاید جدید به ارائه اضافه می‌کند
slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Chartreuse());

// یک بخش جدید به ارائه اضافه می‌کند
auto section3 = pres->get_Sections()->AddSection(u"Section 3", slide);

// یک بخش به Summary Zoom اضافه می‌کند
summaryZoomFrame->get_SummaryZoomCollection()->AddSummaryZoomSection(section3);

// یک بخش را از Summary Zoom حذف می‌کند
summaryZoomFrame->get_SummaryZoomCollection()->RemoveSummaryZoomSection(pres->get_Sections()->idx_get(1));

// ارائه را ذخیره می‌کند
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```

### **Format Summary Zoom Sections**
برای ایجاد اشیای بخش zoom خلاصهٔ پیچیده‌تر، باید قالب‌بندی یک فریم ساده را تغییر دهید. گزینه‌های قالب‌بندی متعددی می‌توانید بر روی شیء بخش zoom خلاصه اعمال کنید. 

می‌توانید قالب‌بندی یک شیء بخش zoom خلاصه در یک فریم zoom خلاصه را این‌گونه کنترل کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) ایجاد کنید.
2. اسلایدهای جدید با پس‌زمینه شناسایی و بخش‌های جدید برای اسلایدهای ایجاد شده ایجاد کنید.
3. فریم zoom خلاصه را به اسلاید اول اضافه کنید.
4. یک شیء بخش zoom خلاصه برای اولین شیء از `ISummaryZoomSectionCollection` دریافت کنید.
7. یک شیء [IPPImage](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ippimage/) با افزودن تصویری به مجموعه images مرتبط با شیء [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) ایجاد کنید که برای پر کردن فریم استفاده خواهد شد.
8. تصویر سفارشی را برای شیء فریم zoom بخش ایجاد شده تنظیم کنید.
9. قابلیت *بازگشت به اسلاید اصلی از بخش لینک‌شده* را فعال کنید. 
11. قالب خط را برای شیء دوم فریم زوم تغییر دهید.
12. مدت زمان انتقال را تغییر دهید.
13. ارائهٔ اصلاح‌شده را به عنوان فایل PPTX ذخیره کنید.

این کد C++ نشان می‌دهد چگونه قالب‌بندی یک شیء بخش zoom خلاصه را تغییر دهید:

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//یک اسلاید جدید به ارائه اضافه می‌کند
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Brown());

// یک بخش جدید به ارائه اضافه می‌کند
pres->get_Sections()->AddSection(u"Section 1", slide);

//Adds a new slide to the presentation
slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Aqua());

// یک بخش جدید به ارائه اضافه می‌کند
pres->get_Sections()->AddSection(u"Section 2", slide);

// یک شیء SummaryZoomFrame اضافه می‌کند
auto summaryZoomFrame = slide0->get_Shapes()->AddSummaryZoomFrame(150.0f, 50.0f, 300.0f, 200.0f);

// دریافت اولین شیء SummaryZoomSection
auto summarySection = summaryZoomFrame->get_SummaryZoomCollection()->idx_get(0);

// قالب‌بندی برای شیء SummaryZoomSection
auto image = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));
summarySection->set_Image(image);

summarySection->set_ReturnToParent(false);

summarySection->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
summarySection->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
summarySection->get_LineFormat()->set_DashStyle(LineDashStyle::DashDot);
summarySection->get_LineFormat()->set_Width(1.5f);

summarySection->set_TransitionDuration(1.5f);

// ارائه را ذخیره می‌کند
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```

## **FAQ**

**آیا می‌توانم پس از نمایش هدف، به اسلاید «والد» بازگردم؟**

بله. متد `set_ReturnToParent` در [Zoom frame](https://reference.aspose.com/slides/fa/cpp/aspose.slides/zoomframe/) یا [section](https://reference.aspose.com/slides/fa/cpp/aspose.slides/sectionzoomframe/) این امکان را فراهم می‌کند که بیننده پس از بازدید از محتوای هدف به اسلاید مبدأ بازگردد.

**آیا می‌توانم «سرعت» یا مدت زمان انتقال Zoom را تنظیم کنم؟**

بله. Zoom از تنظیم مدت زمان انتقال پشتیبانی می‌کند تا بتوانید کنترل کنید انیمیشن پرش چقدر طول می‌کشد.

**آیا محدودیتی برای تعداد اشیای Zoom در یک ارائه وجود دارد؟**

محدودیت سخت‌گیرانه‌ای در API مستند نشده است. محدودیت‌های عملی به پیچیدگی کلی ارائه و عملکرد دستگاه مشاهده‌کننده بستگی دارد. می‌توانید فریم‌های Zoom زیادی اضافه کنید، اما به اندازه فایل و زمان رندرینگ توجه داشته باشید.