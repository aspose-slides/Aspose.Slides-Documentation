---
title: افزودن واترمارک به ارائه‌ها در C++
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
- حذف واترمارک
- افزودن واترمارک به PPT
- افزودن واترمارک به PPTX
- افزودن واترمارک به ODP
- حذف واترمارک از PPT
- حذف واترمارک از PPTX
- حذف واترمارک از ODP
- حذف واترمارک از PPT
- حذف واترمارک از PPTX
- حذف واترمارک از ODP
- PowerPoint
- OpenDocument
- ارائه
- C++
- Aspose.Slides
description: "مدیریت واترمارک‌های متنی و تصویری در ارائه‌های PowerPoint و OpenDocument با C++ برای نشان دادن پیش‌نویس، اطلاعات محرمانه، حق کپی‌رایت و موارد دیگر."
---
## **مقدمه**

**یک واترمارک** در یک ارائه متنی یا تصویری است که بر روی یک اسلاید یا تمام اسلایدهای ارائه قرار می‌گیرد. معمولاً برای نشان دادن اینکه ارائه یک پیش‌نویس است (مثلاً واترمارک «پیش‌نویس»)، شامل اطلاعات محرمانه است (مثلاً واترمارک «محرمانه»)، مشخص کردن شرکت مربوطه (مثلاً واترمارک «نام شرکت»)، شناسایی نویسنده ارائه و غیره استفاده می‌شود. واترمارک با نشان دادن این‌که ارائه نباید کپی شود، به جلوگیری از نقض حق کپی‌رایت کمک می‌کند. واترمارک‌ها هم در فرمت‌های PowerPoint و هم OpenOffice کاربرد دارند. در Aspose.Slides می‌توانید واترمارک را به فرمت‌های فایل PowerPoint PPT، PPTX و OpenOffice ODP اضافه کنید.

در [**Aspose.Slides**](https://products.aspose.com/slides/fa/cpp/)، روش‌های متنوعی برای ایجاد واترمارک در اسناد PowerPoint یا OpenOffice و تغییر طراحی و رفتار آن‌ها وجود دارد. نکتهٔ مشترک این است که برای افزودن واترمارک متنی باید از رابط [ITextFrame](https://reference.aspose.com/slides/fa/cpp/aspose.slides/itextframe/) استفاده کنید و برای افزودن واترمارک تصویری از کلاس [PictureFrame](https://reference.aspose.com/slides/fa/cpp/aspose.slides/pictureframe/) یا پر کردن شکل واترمارک با تصویر استفاده کنید. `PictureFrame` رابط [IShape](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ishape/) را پیاده‌سازی می‌کند و به شما امکان استفاده از تمامی تنظیمات انعطاف‌پذیر شیء شکل را می‌دهد. از آنجایی که `ITextFrame` یک شکل نیست و تنظیمات محدودی دارد، در یک شیء [IShape](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ishape/) قرار می‌گیرد.

دو روش برای اعمال واترمارک وجود دارد: بر روی یک اسلاید منفرد یا بر روی تمام اسلایدهای ارائه. برای اعمال واترمارک بر تمام اسلایدها از اسلاید مستر استفاده می‌شود — واترمارک به اسلاید مستر اضافه می‌شود، در آنجا به‌طور کامل طراحی می‌شود و به تمام اسلایدها اعمال می‌شود بدون اینکه امکان ویرایش واترمارک در اسلایدهای جداگانه تحت‌تأثیر قرار گیرد.

عموماً واترمارک برای ویرایش توسط سایر کاربران قابل دسترس نیست. برای جلوگیری از ویرایش واترمارک (یا بهتر بگوییم شکل والد واترمارک) Aspose.Slides قابلیت قفل‌کردن شکل را فراهم می‌کند. یک شکل خاص می‌تواند در یک اسلاید عادی یا در اسلاید مستر قفل شود. وقتی شکل واترمارک در اسلاید مستر قفل شود، بر تمام اسلایدهای ارائه قفل می‌شود.

می‌توانید برای واترمارک نامی تعیین کنید تا در آینده، اگر بخواهید آن را حذف کنید، بتوانید آن را توسط نام در لیست اشکال اسلاید پیدا کنید.

می‌توانید واترمارک را به هر روشی طراحی کنید؛ اما معمولاً ویژگی‌های مشترکی در واترمارک‌ها وجود دارد، مانند تراز وسط، چرخش، موقعیت جلو و غیره. در مثال‌های زیر نحوهٔ استفاده از این ویژگی‌ها را بررسی می‌کنیم.

## **واترمارک متنی**

### **افزودن واترمارک متنی به یک اسلاید**

برای افزودن واترمارک متنی در PPT، PPTX یا ODP ابتدا می‌توانید یک شکل به اسلاید اضافه کنید، سپس یک فریم متنی به این شکل اضافه کنید. فریم متنی توسط رابط [ITextFrame](https://reference.aspose.com/slides/fa/cpp/aspose.slides/itextframe/) نمایان می‌شود. این نوع از [IShape](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ishape/) ارث‌بری نمی‌کند، در حالی که مجموعهٔ وسیعی از خصوصیات برای موقعیت‌دهی انعطاف‌پذیر واترمارک دارد. بنابراین، شیء [ITextFrame](https://reference.aspose.com/slides/fa/cpp/aspose.slides/itextframe/) در یک شیء [IAutoShape](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iautoshape/) محصور می‌شود. برای افزودن متن واترمارک به شکل، از متد [AddTextFrame](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iautoshape/addtextframe/) به‌صورت زیر استفاده کنید.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto watermarkText = u"CONFIDENTIAL";

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
auto watermarkFrame = watermarkShape->AddTextFrame(watermarkText);

presentation->Dispose();
```

{{% alert color="info" title="See also" %}} 
- [چگونه از کلاس TextFrame استفاده کنیم](/slides/fa/cpp/text-formatting/)
{{% /alert %}}

### **افزودن واترمارک متنی به یک ارائه**

اگر می‌خواهید واترمارک متنی را به تمام اسلایدهای یک ارائه (یعنی همه اسلایدها به‌صورت یک‌باره) اضافه کنید، آن را به [MasterSlide](https://reference.aspose.com/slides/fa/cpp/aspose.slides/masterslide/) اضافه کنید. بقیه منطق همانند افزودن واترمارک به یک اسلاید است — یک شیء [IAutoShape](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iautoshape/) ایجاد کنید و سپس با استفاده از متد [AddTextFrame](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iautoshape/addtextframe/) واترمارک را به آن اضافه کنید.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto watermarkText = u"CONFIDENTIAL";

auto presentation = MakeObject<Presentation>();
auto masterSlide = presentation->get_Master(0);

auto watermarkShape = masterSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
auto watermarkFrame = watermarkShape->AddTextFrame(watermarkText);

presentation->Dispose();
```

{{% alert color="info" title="See also" %}} 
- [چگونه از اسلاید مستر استفاده کنیم](/slides/fa/cpp/slide-master/)
{{% /alert %}}

### **تنظیم شفافیت شکل واترمارک**

به صورت پیش‌فرض، شکل مستطیلی با رنگ پر و خط است. خطوط کد زیر شکل را شفاف می‌کند.

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);

watermarkShape->get_FillFormat()->set_FillType(FillType::NoFill);
watermarkShape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);
```

### **تنظیم فونت برای واترمارک متنی**

به‌صورت زیر می‌توانید فونت متن واترمارک را تغییر دهید.

```cpp
#include <DOM/Fonts/FontData.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
auto watermarkFrame = watermarkShape->AddTextFrame(u"CONFIDENTIAL");

auto textFormat = watermarkFrame->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat();
textFormat->set_LatinFont(MakeObject<FontData>(u"Arial"));
textFormat->set_FontHeight(50);
```

### **تنظیم رنگ متن واترمارک**

برای تنظیم رنگ متن واترمارک از کد زیر استفاده کنید:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
auto watermarkFrame = watermarkShape->AddTextFrame(u"CONFIDENTIAL");

auto alpha = 150, red = 200, green = 200, blue = 200;

auto fillFormat = watermarkFrame->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat();
fillFormat->set_FillType(FillType::Solid);
fillFormat->get_SolidFillColor()->set_Color(Color::FromArgb(alpha, red, green, blue));
```

### **وسط‌چین کردن واترمارک متنی**

می‌توانید واترمارک را در وسط اسلاید قرار دهید؛ برای این کار می‌توانید به‌صورت زیر عمل کنید:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <drawing/size_f.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto watermarkText = u"CONFIDENTIAL";

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

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

برای افزودن واترمارک تصویری به اسلایدهای یک ارائه می‌توانید به‌صورت زیر عمل کنید:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFillFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);

auto imageStream = File::ReadAllBytes(u"watermark.png");
auto image = presentation->get_Images()->AddImage(imageStream);

watermarkShape->get_FillFormat()->set_FillType(FillType::Picture);
watermarkShape->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(image);
watermarkShape->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);
```

## **قفل کردن واترمارک از ویرایش**

اگر نیاز به جلوگیری از ویرایش واترمارک دارید، از متد [IAutoShape::get_AutoShapeLock](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iautoshape/get_autoshapelock/) روی شکل استفاده کنید. با این ویژگی می‌توانید از انتخاب، تغییر اندازه، جابه‌جایی، گروه‌بندی با عناصر دیگر، قفل کردن متن از ویرایش و موارد دیگر جلوگیری کنید:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IAutoShapeLock.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);

// قفل کردن شکل واترمارک از تغییر
watermarkShape->get_AutoShapeLock()->set_SelectLocked(true);
watermarkShape->get_AutoShapeLock()->set_SizeLocked(true);
watermarkShape->get_AutoShapeLock()->set_TextLocked(true);
watermarkShape->get_AutoShapeLock()->set_PositionLocked(true);
watermarkShape->get_AutoShapeLock()->set_GroupingLocked(true);
```

## **آوردن واترمارک به جلو**

در Aspose.Slides می‌توانید ترتیب Z اشکال را با متد [IShapeCollection::Reorder](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ishapecollection/reorder/) تنظیم کنید. برای این کار باید این متد را از لیست اسلایدهای ارائه صدا بزنید و مرجع شکل و شمارهٔ ترتیب را به آن پاس کنید. به این ترتیب می‌توانید یک شکل را به جلو یا به عقب اسلاید بکشید. این ویژگی به‌ویژه زمانی مفید است که بخواهید واترمارک را در جلوی ارائه قرار دهید:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);

auto shapeCount = slide->get_Shapes()->get_Count();
slide->get_Shapes()->Reorder(shapeCount - 1, watermarkShape);
```

## **تنظیم چرخش واترمارک**

در زیر مثال کدی برای تنظیم چرخش واترمارک به‌گونه‌ای که به‌صورت مورب بر روی اسلاید قرار گیرد آورده شده است:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <drawing/size_f.h>
#include <system/math.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
auto slideSize = presentation->get_SlideSize()->get_Size();

auto diagonalAngle = Math::Atan((slideSize.get_Height() / slideSize.get_Width())) * 180 / Math::PI;

watermarkShape->set_Rotation((float)diagonalAngle);
```

## **تنظیم نام برای واترمارک**

Aspose.Slides به شما امکان می‌دهد نام یک شکل را تنظیم کنید. با استفاده از نام شکل می‌توانید در آینده به آن دسترسی پیدا کنید تا آن را تغییر یا حذف کنید. برای تنظیم نام شکل واترمارک، مقدار آن را به متد [IAutoShape::set_Name](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ishape/set_name/) اختصاص دهید:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);

watermarkShape->set_Name(u"watermark");
```

## **حذف واترمارک**

برای حذف شکل واترمارک، از متد [IAutoShape::get_Name](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ishape/get_name/) برای یافتن آن در اشکال اسلاید استفاده کنید. سپس شکل واترمارک را به متد [IShapeCollection::Remove](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ishapecollection/remove/) پاس دهید:

```cpp
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/smart_ptr.h>
#include <system/string.h>
#include <system/string_comparison.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"presentation_with_watermark.pptx");
auto slide = presentation->get_Slide(0);

auto slideShapes = slide->get_Shapes()->ToArray();
for(auto shape : slideShapes)
{
    if (String::Compare(shape->get_Name(), u"watermark", StringComparison::Ordinal) == 0)
    {
        slide->get_Shapes()->Remove(shape);
    }
}
```

## **یک مثال زنده**

می‌توانید ابزارهای آنلاین **Aspose.Slides free** برای [افزودن واترمارک](https://products.aspose.app/slides/fa/watermark) و [حذف واترمارک](https://products.aspose.app/slides/fa/watermark/remove-watermark) را امتحان کنید.

![ابزارهای آنلاین برای افزودن و حذف واترمارک](online_tools.png)

## **سوالات متداول**

### واترمارک چیست و چرا باید از آن استفاده کنم؟

واترمارک یک پوشش متنی یا تصویری است که بر روی اسلایدها اعمال می‌شود تا از مالکیت فکری محافظت کند، شناخت برند را افزایش دهد یا از استفاده غیرمجاز ارائه‌ها جلوگیری کند.

### آیا می‌توانم واترمارک را به تمام اسلایدهای یک ارائه اضافه کنم؟

بله، Aspose.Slides به‌صورت برنامه‌نویسی امکان افزودن واترمارک به هر اسلاید از یک ارائه را فراهم می‌کند. می‌توانید از طریق حلقه‌ای بر تمام اسلایدها عبور کنید و تنظیمات واترمارک را به‌صورت جداگانه اعمال کنید.

### چگونه می‌توانم شفافیت واترمارک را تنظیم کنم؟

می‌توانید شفافیت واترمارک را با تغییر تنظیمات پر ([FillFormat](https://reference.aspose.com/slides/fa/cpp/aspose.slides/shape/get_fillformat/)) شکل تنظیم کنید. این کار باعث می‌شود واترمارک به‌صورت ملایمی ظاهر شود و محتوی اسلاید را مختل نکند.

### چه فرمت‌های تصویری برای واترمارک پشتیبانی می‌شوند؟

Aspose.Slides فرمت‌های تصویری مختلفی مانند PNG، JPEG، GIF، BMP، SVG و غیره را پشتیبانی می‌کند.

### آیا می‌توانم فونت و سبک واترمارک متنی را سفارشی کنم؟

بله، می‌توانید هر فونت، اندازه و سبکی را انتخاب کنید تا با طراحی ارائه شما هماهنگ باشد و سازگاری برند را حفظ کند.

### چگونه موقعیت یا جهت‌گیری واترمارک را تغییر دهم؟

می‌توانید موقعیت و جهت‌گیری واترمارک را به‌صورت برنامه‌نویسی با تغییر مختصات، اندازه و ویژگی‌های چرخش شکل تنظیم کنید.