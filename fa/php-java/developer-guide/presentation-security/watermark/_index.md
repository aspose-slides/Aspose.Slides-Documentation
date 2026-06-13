---
title: افزودن علامت تجاری به ارائه‌ها در PHP
linktitle: علامت تجاری
type: docs
weight: 40
url: /fa/php-java/watermark/
keywords:
- علامت تجاری
- علامت تجاری متنی
- علامت تجاری تصویری
- افزودن علامت تجاری
- تغییر علامت تجاری
- حذف علامت تجاری
- پاک کردن علامت تجاری
- افزودن علامت تجاری به PPT
- افزودن علامت تجاری به PPTX
- افزودن علامت تجاری به ODP
- حذف علامت تجاری از PPT
- حذف علامت تجاری از PPTX
- حذف علامت تجاری از ODP
- پاک کردن علامت تجاری از PPT
- پاک کردن علامت تجاری از PPTX
- پاک کردن علامت تجاری از ODP
- پاورپوینت
- سند باز
- ارائه
- PHP
- Aspose.Slides
description: "مدیریت علامت‌های تجاری متنی و تصویری در ارائه‌های PowerPoint و OpenDocument با PHP برای نشان دادن پیش‌نویس، اطلاعات محرمانه، حق کپی‌رایت و موارد دیگر."
---
## **معرفی**

**یک علامت تجاری** در یک ارائه متن یا تصویری است که بر روی یک اسلاید یا تمام اسلایدهای ارائه قرار می‌گیرد. معمولاً از علامت تجاری برای نشان دادن اینکه ارائه یک پیش‌نویس است (مثلاً علامت تجاری «پیش‌نویس») یا حاوی اطلاعات محرمانه است (مثلاً علامت تجاری «محرمانه») یا مشخص کردن شرکت مالک (مثلاً علامت تجاری «نام شرکت») یا شناسایی نویسنده ارائه استفاده می‌شود. علامت تجاری به جلوگیری از نقض حق‑کپی‌رایت کمک می‌کند زیرا نشان می‌دهد که ارائه نباید کپی شود. علامت‌های تجاری در فرمت‌های ارائه PowerPoint و OpenOffice استفاده می‌شوند. در Aspose.Slides می‌توانید یک علامت تجاری به فرمت‌های PowerPoint PPT، PPTX و OpenOffice ODP اضافه کنید.

در [**Aspose.Slides**](https://products.aspose.com/slides/fa/php-java/)، روش‌های مختلفی برای ایجاد علامت تجاری در اسناد PowerPoint یا OpenOffice و تغییر طراحی و رفتار آن‌ها وجود دارد. جنبه مشترک این است که برای افزودن علامت تجاری متنی، باید از کلاس [TextFrame](https://reference.aspose.com/slides/fa/php-java/aspose.slides/textframe/) استفاده کنید و برای افزودن علامت تجاری تصویری، از کلاس [PictureFrame](https://reference.aspose.com/slides/fa/php-java/aspose.slides/pictureframe/) یا پر کردن یک شکل علامت تجاری با تصویر استفاده کنید. `PictureFrame` کلاس [Shape](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shape/) را پیاده‌سازی می‌کند و به شما اجازه می‌دهد از تمام تنظیمات انعطاف‌پذیر شیء شکل استفاده کنید. از آنجایی که `ITextFrame` یک شکل نیست و تنظیمات آن محدود است، در یک شیء [Shape](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shape/) بسته می‌شود.

دو روش برای اعمال علامت تجاری وجود دارد: بر یک اسلاید واحد یا بر تمام اسلایدهای ارائه. اسلاید مستر برای افزودن علامت تجاری به تمام اسلایدهای ارائه استفاده می‌شود — علامت تجاری به اسلاید مستر اضافه می‌شود، کاملاً در آنجا طراحی می‌شود و به تمام اسلایدها اعمال می‌شود بدون اینکه امکان تغییر علامت تجاری در اسلایدهای منفرد را محدود کند.

علامت تجاری معمولاً به‌عنوان غیرقابل ویرایش توسط سایر کاربران در نظر گرفته می‌شود. برای جلوگیری از ویرایش علامت تجاری (یا بهتر بگوییم شکل والد علامت تجاری) Aspose.Slides قابلیت قفل‌کردن شکل را فراهم می‌کند. یک شکل خاص می‌تواند در اسلاید معمولی یا در اسلاید مستر قفل شود. وقتی شکل علامت تجاری روی اسلاید مستر قفل شود، بر تمام اسلایدهای ارائه نیز قفل می‌ماند.

می‌توانید برای علامت تجاری یک نام تعیین کنید تا در آینده، در صورت نیاز به حذف آن، بتوانید آن را بر اساس نام در لیست اشکال اسلاید پیدا کنید.

می‌توانید علامت تجاری را به هر روش دلخواهی طراحی کنید؛ با این حال معمولاً ویژگی‌های مشترکی مانند تراز وسط، چرخش، موقعیت پیش‌روی و ... در علامت‌های تجاری وجود دارد. در مثال‌های زیر به نحوه استفاده از این ویژگی‌ها می‌پردازیم.

## **علامت تجاری متنی**

### **افزودن یک علامت تجاری متنی به یک اسلاید**

برای افزودن یک علامت تجاری متنی در PPT، PPTX یا ODP، ابتدا می‌توانید یک شکل به اسلاید اضافه کنید، سپس یک قاب متن به این شکل اضافه کنید. قاب متن توسط کلاس [TextFrame](https://reference.aspose.com/slides/fa/php-java/aspose.slides/textframe/) نمایش داده می‌شود. این نوع از [Shape](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shape/) ارث‌بری نمی‌کند، در حالی که [Shape](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shape/) مجموعه وسیعی از ویژگی‌ها برای موقعیت‌یابی انعطاف‌پذیر علامت تجاری دارد. بنابراین، شیء [TextFrame](https://reference.aspose.com/slides/fa/php-java/aspose.slides/textframe/) در یک شیء [AutoShape](https://reference.aspose.com/slides/fa/php-java/aspose.slides/autoshape/) بسته می‌شود. برای افزودن متن علامت تجاری به شکل، از متد [addTextFrame](https://reference.aspose.com/slides/fa/php-java/aspose.slides/autoshape/#addTextFrame) همان‌طور که در زیر نشان داده شده استفاده کنید.

```php
$watermarkText = "CONFIDENTIAL";

$presentation = new Presentation();
$slide = $presentation->getSlides()->get_Item(0);

$watermarkShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
$watermarkFrame = $watermarkShape->addTextFrame($watermarkText);

$presentation->dispose();
```

{{% alert color="primary" title="See also" %}} 
- [How to Use the TextFrame Class](/slides/fa/php-java/text-formatting/)
{{% /alert %}}

### **افزودن یک علامت تجاری متنی به یک ارائه**

اگر می‌خواهید یک علامت تجاری متنی به کل ارائه (یعنی تمام اسلایدها به‌صورت یکجا) اضافه کنید، آن را به [MasterSlide](https://reference.aspose.com/slides/fa/php-java/aspose.slides/masterslide/) اضافه کنید. بقیه منطق همانند افزودن علامت تجاری به یک اسلاید واحد است — یک شیء [AutoShape](https://reference.aspose.com/slides/fa/php-java/aspose.slides/autoshape/) ایجاد کنید و سپس با استفاده از متد [addTextFrame](https://reference.aspose.com/slides/fa/php-java/aspose.slides/autoshape/#addTextFrame) علامت تجاری را به آن اضافه کنید.

```php
$watermarkText = "CONFIDENTIAL";

$presentation = new Presentation();
$masterSlide = $presentation->getMasters()->get_Item(0);

$watermarkShape = $masterSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
$watermarkFrame = $watermarkShape->addTextFrame($watermarkText);

$presentation->dispose();
```

{{% alert color="primary" title="See also" %}} 
- [How to Use the Slide Master](/slides/fa/php-java/slide-master/)
{{% /alert %}}

### **تنظیم شفافیت شکل علامت تجاری**

به‌صورت پیش‌فرض، شکل مستطیل با رنگ پر و خط تنظیم می‌شود. خطوط کد زیر شکل را شفاف می‌کنند.

```php
$watermarkShape->getFillFormat()->setFillType(FillType::NoFill);
$watermarkShape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
```

### **تنظیم فونت برای یک علامت تجاری متنی**

می‌توانید فونت متن علامت تجاری را همان‌طور که در زیر نشان داده شده تغییر دهید.

```php
$textFormat = $watermarkFrame->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat();
$textFormat->setLatinFont(new FontData("Arial"));
$textFormat->setFontHeight(50);
```

### **تنظیم رنگ متن علامت تجاری**

برای تنظیم رنگ متن علامت تجاری از کد زیر استفاده کنید:

```php
$alpha = 150;
$red = 200;
$green = 200;
$blue = 200;
$textColor = new Java("java.awt.Color", $red, $green, $blue, $alpha);

$fillFormat = $watermarkFrame->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat();
$fillFormat->setFillType(FillType::Solid);
$fillFormat->getSolidFillColor()->setColor($textColor);
```

### **مرکزی‌کردن یک علامت تجاری متنی**

می‌توانید علامت تجاری را در وسط اسلاید قرار دهید؛ برای این کار می‌توانید مراحل زیر را انجام دهید:

```php
$slideSize = $presentation->getSlideSize()->getSize();
$slideWidth = java_values($slideSize->getWidth());
$slideHeight = java_values($slideSize->getHeight());

$watermarkWidth = 400;
$watermarkHeight = 40;
$watermarkX = ($slideWidth - $watermarkWidth) / 2;
$watermarkY = ($slideHeight - $watermarkHeight) / 2;

$watermarkShape = $slide->getShapes()->addAutoShape(
        ShapeType::Rectangle, $watermarkX, $watermarkY, $watermarkWidth, $watermarkHeight);

$watermarkFrame = $watermarkShape->addTextFrame($watermarkText);
```

تصویر زیر نتیجه نهایی را نشان می‌دهد.

![The text watermark](text_watermark.png)

## **علامت تجاری تصویری**

### **افزودن یک علامت تجاری تصویری به یک ارائه**

برای افزودن یک علامت تجاری تصویری به اسلایدهای یک ارائه می‌توانید اقدامات زیر را انجام دهید:

```php
$image = Images::fromFile("watermark.png");
$picture = $presentation->getImages()->addImage($image);
$image->dispose();

$watermarkShape->getFillFormat()->setFillType(FillType::Picture);
$watermarkShape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);
$watermarkShape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Stretch);
```

### **قفل کردن یک علامت تجاری برای ویرایش**

اگر نیاز به جلوگیری از ویرایش یک علامت تجاری دارید، از متد [AutoShape.getAutoShapeLock](https://reference.aspose.com/slides/fa/php-java/aspose.slides/autoshape/#getAutoShapeLock) بر روی شکل استفاده کنید. با این ویژگی می‌توانید شکل را از انتخاب، تغییر اندازه، جابجایی، گروه‌بندی با عناصر دیگر، قفل کردن متن برای ویرایش و موارد دیگر محافظت کنید:

```php
// قفل کردن شکل علامت تجاری از تغییر
$watermarkShape->getAutoShapeLock()->setSelectLocked(true);
$watermarkShape->getAutoShapeLock()->setSizeLocked(true);
$watermarkShape->getAutoShapeLock()->setTextLocked(true);
$watermarkShape->getAutoShapeLock()->setPositionLocked(true);
$watermarkShape->getAutoShapeLock()->setGroupingLocked(true);
```

### **بردن یک علامت تجاری به جلو**

در Aspose.Slides می‌توانید ترتیب Z‑shapes را با استفاده از متد [ShapeCollection.reorder](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shapecollection/#reorder) تنظیم کنید. برای این کار، این متد را از لیست اسلایدهای ارائه صدا بزنید و مرجع شکل و عدد ترتیب آن را به متد پاس دهید. به این ترتیب می‌توانید یک شکل را به جلو یا به عقب اسلاید ببرید. این قابلیت به‌خصوص زمانی مفید است که نیاز داشته باشید علامت تجاری را جلوی سایر عناصر ارائه قرار دهید:

```php
$shapeCount = java_values($slide->getShapes()->size());
$slide->getShapes()->reorder($shapeCount - 1, $watermarkShape);
```

### **تنظیم چرخش علامت تجاری**

در ادامه یک مثال کد برای تنظیم چرخش علامت تجاری به گونه‌ای که به صورت قطری در اسلاید قرار گیرد آورده شده است:

```php
$diagonalAngle = atan($slideWidth / $slideHeight) * 180 / M_PI;

$watermarkShape->setRotation($diagonalAngle);
```

### **تعیین نام برای یک علامت تجاری**

Aspose.Slides به شما امکان می‌دهد نام یک شکل را تعیین کنید. با استفاده از نام شکل می‌توانید در آینده به آن دسترسی پیدا کنید تا اصلاح یا حذف کنید. برای تعیین نام شکل علامت تجاری، مقدار آن را به متد [AutoShape.setName](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shape/#setName) اختصاص دهید:

```php
$watermarkShape->setName("watermark");
```

### **حذف یک علامت تجاری**

برای حذف شکل علامت تجاری، از متد [AutoShape.getName](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shape/#getName) برای یافتن آن در اشکال اسلاید استفاده کنید. سپس شکل علامت تجاری را به متد [ShapeCollection.remove](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shapecollection/#remove) پاس دهید:

```php
$slideShapes = $slide->getShapes()->toArray();
foreach ($slideShapes as $shape) {
    if ($shape->getName() === "watermark") {
        $slide->getShapes()->remove($shape);
    }
}
```

## **سوالات متداول**

**علامت تجاری چیست و چرا باید از آن استفاده کنم؟**

علامت تجاری یک پوشش متنی یا تصویری است که بر روی اسلایدها اعمال می‌شود و به حفظ مالکیت فکری، ارتقاء شناخت برند یا جلوگیری از استفاده غیرمجاز از ارائه‌ها کمک می‌کند.

**آیا می‌توانم علامت تجاری را به تمام اسلایدهای یک ارائه اضافه کنم؟**

بله، Aspose.Slides به شما امکان می‌دهد برنامه‌نویسی کنید و یک علامت تجاری را به هر اسلاید از یک ارائه اضافه کنید. می‌توانید در تمام اسلایدها پیمایش کنید و تنظیمات علامت تجاری را به‌صورت جداگانه اعمال کنید.

**چگونه می‌توانم شفافیت علامت تجاری را تنظیم کنم؟**

با تغییر تنظیمات پر ([getFillFormat](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shape/getfillformat/)) شکل می‌توانید شفافیت علامت تجاری را تنظیم کنید. این کار باعث می‌شود علامت تجاری به‌صورت ظریف نمایش داده شود و مزاحم محتوی اسلاید نشود.

**چه فرمت‌های تصویری برای علامت تجاری پشتیبانی می‌شوند؟**

Aspose.Slides فرمت‌های تصویری مختلفی مانند PNG، JPEG، GIF، BMP، SVG و ... را پشتیبانی می‌کند.

**آیا می‌توانم فونت و سبک یک علامت تجاری متنی را سفارشی کنم؟**

بله، می‌توانید هر فونت، اندازه و سبکی را انتخاب کنید تا با طراحی ارائه شما هماهنگ باشد و سازگاری برند را حفظ کند.

**چگونه موقعیت یا جهت‌گیری یک علامت تجاری را تغییر دهم؟**

می‌توانید موقعیت و جهت‌گیری علامت تجاری را به‌صورت برنامه‌ای با تغییر مختصات، اندازه و ویژگی‌های چرخش شکل تنظیم کنید.