---
title: افزودن واترمارک‌ها به ارائه‌ها در C++
linktitle: واترمارک
type: docs
weight: 40
url: /fa/cpp/watermark/
keywords:
- واترمارک
- واترمارک متنی
- واترمارک تصویری
- افزودن واترمارک
- تغییر واترمارک
- حذف واترمارک
- پاک‌سازی واترمارک
- افزودن واترمارک به PPT
- افزودن واترمارک به PPTX
- افزودن واترمارک به ODP
- حذف واترمارک از PPT
- حذف واترمارک از PPTX
- حذف واترمارک از ODP
- پاک‌سازی واترمارک از PPT
- پاک‌سازی واترمارک از PPTX
- پاک‌سازی واترمارک از ODP
- پاورپوینت
- سند باز
- ارائه
- C++
- Aspose.Slides
description: "مدیریت واترمارک‌های متنی و تصویری در ارائه‌های پاورپوینت و سند باز با C++ برای نشان دادن پیش‌نویس، اطلاعات محرمانه، حق کپی‌رایت و موارد دیگر."
---
## **مقدمه**

**یک واترمارک** در یک ارائه، یک نشان متنی یا تصویری است که بر روی یک اسلاید یا در تمام اسلایدهای ارائه استفاده می‌شود. معمولاً از واترمارک برای نشان دادن اینکه ارائه یک پیش‌نویس است (مثلاً واترمارک «Draft»)، حاوی اطلاعات محرمانه است (مثلاً واترمارک «Confidential»)، برای مشخص کردن شرکت مربوطه (مثلاً واترمارک «Company Name»)، برای شناسایی نویسنده ارائه و غیره استفاده می‌شود. واترمارک با نشان دادن اینکه نسخه‌برداری از ارائه مجاز نیست، به جلوگیری از نقض حقوق کپی‌رایت کمک می‌کند. واترمارک‌ها در فرمت‌های ارائه PowerPoint و OpenOffice به‌کار می‌روند. در Aspose.Slides می‌توانید واترمارک را به فایل‌های PowerPoint PPT، PPTX و OpenOffice ODP اضافه کنید.

در [**Aspose.Slides**](https://products.aspose.com/slides/fa/cpp/)، روش‌های مختلفی برای ایجاد واترمارک در اسناد PowerPoint یا OpenOffice و ویرایش طراحی و رفتار آن‌ها وجود دارد. نکتهٔ مشترک این است که برای افزودن واترمارک متنی باید از رابط [ITextFrame](https://reference.aspose.com/slides/fa/cpp/aspose.slides/itextframe/) استفاده کنید و برای افزودن واترمارک تصویری، از کلاس [PictureFrame](https://reference.aspose.com/slides/fa/cpp/aspose.slides/pictureframe/) یا پر کردن یک شکل واترمارک با تصویر استفاده کنید. `PictureFrame` رابط [IShape](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ishape/) را پیاده‌سازی می‌کند و به شما امکان استفاده از تمام تنظیمات انعطاف‌پذیر شیء شکل را می‌دهد. از آنجایی که `ITextFrame` یک شکل نیست و تنظیمات آن محدود است، در یک شیء [IShape](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ishape/) بسته می‌شود.

دو روش برای اعمال واترمارک وجود دارد: به یک اسلاید واحد یا به تمام اسلایدهای ارائه. برای اعمال واترمارک به تمام اسلایدها از Slide Master استفاده می‌شود — واترمارک به Slide Master اضافه می‌شود، در آنجا به‌طور کامل طراحی می‌شود و به تمام اسلایدها اعمال می‌شود بدون این‌که امکان ویرایش واترمارک در اسلایدهای جداگانه را تحت تأثیر قرار دهد.

واترمارک معمولاً برای ویرایش توسط دیگر کاربران غیرقابل دسترسی در نظر گرفته می‌شود. برای جلوگیری از ویرایش واترمارک (یا بهتر بگوییم شکل والد واترمارک)، Aspose.Slides قابلیت قفل‌کردن شکل را فراهم می‌کند. یک شکل خاص می‌تواند در یک اسلاید عادی یا در Slide Master قفل شود. وقتی شکل واترمارک در Slide Master قفل شود، در تمام اسلایدهای ارائه نیز قفل می‌ماند.

می‌توانید برای واترمارک یک نام تنظیم کنید تا در آینده، در صورت نیاز به حذف آن، بتوانید آن را بر اساس نام در اشکال اسلاید پیدا کنید.

می‌توانید واترمارک را به هر شکلی طراحی کنید؛ اما معمولاً ویژگی‌های مشترکی در واترمارک‌ها وجود دارد، مانند تراز وسط، چرخش، قرارگیری در جلو و غیره. در مثال‌های زیر نحوهٔ استفاده از این ویژگی‌ها را بررسی می‌کنیم.

## **واترمارک متنی**

### **افزودن واترمارک متنی به یک اسلاید**

برای افزودن واترمارک متنی در PPT، PPTX یا ODP، ابتدا می‌توانید یک شکل به اسلاید اضافه کنید، سپس یک فریم متن به این شکل اضافه نمایید. فریم متن توسط رابط [ITextFrame](https://reference.aspose.com/slides/fa/cpp/aspose.slides/itextframe/) نشان داده می‌شود. این نوع از [IShape](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ishape/) ارث‌بندی نمی‌شود، در حالی که مجموعهٔ وسیعی از ویژگی‌های موقعیت‌یابی برای تنظیم انعطاف‌پذیر واترمارک دارد. بنابراین، شیء [ITextFrame](https://reference.aspose.com/slides/fa/cpp/aspose.slides/itextframe/) در یک شیء [IAutoShape](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iautoshape/) بسته می‌شود. برای افزودن متن واترمارک به شکل، از متد [AddTextFrame](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iautoshape/addtextframe/) همان‌طور که در زیر نشان داده شده استفاده کنید.

```cpp
auto watermarkText = u"CONFIDENTIAL";

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
auto watermarkFrame = watermarkShape->AddTextFrame(watermarkText);

presentation->Dispose();
```

{{% alert color="primary" title="همچنین ببینید" %}} 
- [How to Use the TextFrame Class](/slides/fa/cpp/text-formatting/)
{{% /alert %}}

### **افزودن واترمارک متنی به یک ارائه**

اگر می‌خواهید واترمارک متنی را به کل ارائه (یعنی تمام اسلایدها به‌صورت همزمان) اضافه کنید، آن را به [MasterSlide](https://reference.aspose.com/slides/fa/cpp/aspose.slides/masterslide/) اضافه کنید. بقیه منطق مشابه افزودن واترمارک به یک اسلاید است — یک شیء [IAutoShape](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iautoshape/) ایجاد کنید و سپس با استفاده از متد [AddTextFrame](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iautoshape/addtextframe/) واترمارک را به آن اضافه کنید.

```cpp
auto watermarkText = u"CONFIDENTIAL";

auto presentation = MakeObject<Presentation>();
auto masterSlide = presentation->get_Master(0);

auto watermarkShape = masterSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
auto watermarkFrame = watermarkShape->AddTextFrame(watermarkText);

presentation->Dispose();
```

{{% alert color="primary" title="همچنین ببینید" %}} 
- [How to Use the Slide Master](/slides/fa/cpp/slide-master/)
{{% /alert %}}

### **تنظیم شفافیت شکل واترمارک**

به طور پیش‌فرض، شکل مستطیل با رنگ پر و خط تنظیم شده است. خطوط کد زیر شکل را شفاف می‌کند.

```cpp
watermarkShape->get_FillFormat()->set_FillType(FillType::NoFill);
watermarkShape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);
```

### **تنظیم فونت برای واترمارک متنی**

می‌توانید فونت متن واترمارک را همان‌طور که در زیر نشان داده شده تغییر دهید.

```cpp
auto textFormat = watermarkFrame->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat();
textFormat->set_LatinFont(MakeObject<FontData>(u"Arial"));
textFormat->set_FontHeight(50);
```

### **تنظیم رنگ متن واترمارک**

برای تنظیم رنگ متن واترمارک، از این کد استفاده کنید:

```cpp
auto alpha = 150, red = 200, green = 200, blue = 200;

auto fillFormat = watermarkFrame->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat();
fillFormat->set_FillType(FillType::Solid);
fillFormat->get_SolidFillColor()->set_Color(Color::FromArgb(alpha, red, green, blue));
```

### **وسط‌چین کردن واترمارک متنی**

می‌توانید واترمارک را در وسط اسلاید قرار دهید و برای این کار می‌توانید مراحل زیر را انجام دهید:

```cpp
auto slideSize = presentation->get_SlideSize()->get_Size();

auto watermarkWidth = 400;
auto watermarkHeight = 40;
auto watermarkX = (slideSize.get_Width() - watermarkWidth) / 2;
auto watermarkY = (slideSize.get_Height() - watermarkHeight) / 2;

auto watermarkShape = slide->get_Shapes()->AddAutoShape(
    ShapeType::Rectangle, watermarkX, watermarkY, watermarkWidth, watermarkHeight);

auto watermarkFrame = watermarkShape->AddTextFrame(watermarkText);
```

تصویر زیر نتیجهٔ نهایی را نشان می‌دهد.

![واترمارک متنی](text_watermark.png)

## **واترمارک تصویری**

### **افزودن واترمارک تصویری به یک ارائه**

برای افزودن واترمارک تصویری به اسلایدهای یک ارائه، می‌توانید کارهای زیر را انجام دهید:

```cpp
auto imageStream = File::ReadAllBytes(u"watermark.png");
auto image = presentation->get_Images()->AddImage(imageStream);

watermarkShape->get_FillFormat()->set_FillType(FillType::Picture);
watermarkShape->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(image);
watermarkShape->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);
```

## **قفل کردن واترمارک برای ویرایش**

اگر نیاز است از ویرایش واترمارک جلوگیری کنید، از متد [IAutoShape::get_AutoShapeLock](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iautoshape/get_autoshapelock/) بر روی شکل استفاده کنید. با این ویژگی می‌توانید از انتخاب، تغییر اندازه، جابجایی، گروه‌بندی با عناصر دیگر، قفل متن از ویرایش و موارد دیگر برای شکل محافظت کنید:

```cpp
// قفل کردن شکل واترمارک از تغییر
watermarkShape->get_AutoShapeLock()->set_SelectLocked(true);
watermarkShape->get_AutoShapeLock()->SizeLocked(true);
watermarkShape->get_AutoShapeLock()->TextLocked(true);
watermarkShape->get_AutoShapeLock()->PositionLocked(true);
watermarkShape->get_AutoShapeLock()->GroupingLocked(true);
```

## **آوردن واترمارک به جلو**

در Aspose.Slides، ترتیب Z اشکال می‌تواند از طریق متد [IShapeCollection::Reorder](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ishapecollection/reorder/) تنظیم شود. برای این کار باید این متد را از لیست اسلایدهای ارائه صدا بزنید و مرجع شکل و شمارهٔ ترتیب آن را به متد پاس بدهید. به این ترتیب می‌توانید شکلی را به جلو بیاورید یا به عقب بفرستید. این قابلیت به‌ویژه وقتی مفید است که بخواهید واترمارک را در جلوی ارائه قرار دهید:

```cpp
auto shapeCount = slide->get_Shapes()->get_Count();
slide->get_Shapes()->Reorder(shapeCount - 1, watermarkShape);
```

## **تنظیم چرخش واترمارک**

در زیر یک مثال کد برای تنظیم چرخش واترمارک به‌گونه‌ای که به‌صورت قطری بر روی اسلاید قرار گیرد، آورده شده است:

```cpp
auto diagonalAngle = Math::Atan((slideSize.get_Height() / slideSize.get_Width())) * 180 / Math::PI;

watermarkShape->set_Rotation((float)diagonalAngle);
```

## **تخصیص نام برای واترمارک**

Aspose.Slides به شما امکان می‌دهد نام یک شکل را تنظیم کنید. با استفاده از نام شکل می‌توانید در آینده به آن دسترسی پیدا کنید تا آن را ویرایش یا حذف کنید. برای تنظیم نام شکل واترمارک، از متد [IAutoShape::set_Name](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ishape/set_name/) استفاده کنید:

```cpp
watermarkShape->set_Name(u"watermark");
```

## **حذف واترمارک**

برای حذف شکل واترمارک، از متد [IAutoShape::get_Name](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ishape/get_name/) برای یافتن آن در اشکال اسلاید استفاده کنید. سپس شکل واترمارک را به متد [IShapeCollection::Remove](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ishapecollection/remove/) پاس بدهید:

```cpp
auto slideShapes = slide->get_Shapes()->ToArray();
for(auto shape : slideShapes)
{
    if (String::Compare(shape->get_Name(), u"watermark", StringComparison::Ordinal) == 0)
    {
        slide->get_Shapes()->Remove(watermarkShape);
    }
}
```

## **یک مثال زنده**

ممکن است بخواهید ابزارهای آنلاین **Aspose.Slides free** را برای افزودن واترمارک [Add Watermark](https://products.aspose.app/slides/fa/watermark) و [Remove Watermark](https://products.aspose.app/slides/fa/watermark/remove-watermark) بررسی کنید.

![ابزارهای آنلاین برای افزودن و حذف واترمارک‌ها](online_tools.png)

## **پرسش‌های متداول**

**واترمارک چیست و چرا باید از آن استفاده کنم؟**

واترمارک یک لایهٔ متنی یا تصویری است که بر روی اسلایدها اعمال می‌شود و به حفاظت از مالکیت معنوی، ارتقای شناخت برند یا جلوگیری از استفاده غیرمجاز از ارائه‌ها کمک می‌کند.

**آیا می‌توانم واترمارک را به تمام اسلایدهای یک ارائه اضافه کنم؟**

بله، Aspose.Slides به شما امکان می‌دهد برنامه‌نویسی کنید و واترمارک را به هر اسلاید از یک ارائه اضافه کنید. می‌توانید در تمام اسلایدها تکرار کنید و تنظیمات واترمارک را به‌صورت جداگانه اعمال کنید.

**چگونه شفافیت واترمارک را تنظیم کنم؟**

می‌توانید شفافیت واترمارک را با تغییر تنظیمات پر ([FillFormat](https://reference.aspose.com/slides/fa/cpp/aspose.slides/shape/get_fillformat/)) شکل تنظیم کنید. این کار باعث می‌شود واترمارک به‌صورت ظریف باشد و تمرکز را از محتوای اسلاید دور نکند.

**چه فرمت‌های تصویری برای واترمارک پشتیبانی می‌شوند؟**

Aspose.Slides از فرمت‌های تصویری مختلفی مانند PNG، JPEG، GIF، BMP، SVG و غیره پشتیبانی می‌کند.

**آیا می‌توانم فونت و سبک واترمارک متنی را سفارشی کنم؟**

بله، می‌توانید هر فونت، اندازه و سبکی را انتخاب کنید تا با طراحی ارائه شما سازگار باشد و ثبات برند را حفظ کنید.

**چگونه مکان یا جهت‌گیری واترمارک را تغییر دهم؟**

می‌توانید موقعیت و جهت‌گیری واترمارک را برنامه‌نویسی با تغییر مختصات، اندازه و ویژگی‌های چرخش شکل تنظیم کنید.