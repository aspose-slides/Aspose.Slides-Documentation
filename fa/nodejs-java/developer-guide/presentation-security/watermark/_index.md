---
title: افزودن واترمارک به ارائه‌ها در JavaScript
linktitle: واترمارک
type: docs
weight: 40
url: /fa/nodejs-java/watermark/
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
- PowerPoint
- OpenDocument
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "در Node.js، واترمارک‌های متنی و تصویری را در ارائه‌های PowerPoint و OpenDocument مدیریت کنید تا پیش‌نویس، اطلاعات محرمانه، حق کپی‌رایت و موارد دیگر را نشان دهند."
---
## **مقدمه**

**یک واترمارک** در یک ارائه متنی یا تصویری است که بر روی یک اسلاید یا تمام اسلایدهای ارائه قرار می‌گیرد. معمولاً یک واترمارک برای نشان دادن این که ارائه یک پیش‌نویس است (مثلاً واترمارک «پیش‌نویس»)، حاوی اطلاعات محرمانه است (مثلاً واترمارک «محرمانه»)، مشخص کردن شرکت صاحب ارائه (مثلاً واترمارک «نام شرکت»)، شناسایی نویسنده ارائه و غیره استفاده می‌شود. واترمارک به جلوگیری از نقض حق‌کپی‌رایت کمک می‌کند، زیرا نشان می‌دهد که ارائه نباید کپی شود. واترمارک‌ها هم در فرمت‌های PowerPoint و هم OpenOffice استفاده می‌شوند. در Aspose.Slides می‌توانید واترمارک را به فایل‌های PowerPoint PPT، PPTX و OpenOffice ODP اضافه کنید.

در [**Aspose.Slides**](https://products.aspose.com/slides/fa/nodejs-java/)، روش‌های مختلفی برای ایجاد واترمارک در اسناد PowerPoint یا OpenOffice و تغییر طراحی و رفتار آن وجود دارد. نکته مشترک این است که برای افزودن واترمارک متنی، باید از نوع [TextFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textframe/) استفاده کنید و برای افزودن واترمارک تصویری، از کلاس [PictureFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/pictureframe/) یا پر کردن یک شکل واترمارک با تصویر استفاده کنید. `PictureFrame` پیاده‌سازی نوع [Shape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/shape/) است و به شما امکان استفاده از تمام تنظیمات انعطاف‌پذیر شیء شکل را می‌دهد. از آنجا که `TextFrame` یک شکل نیست و تنظیماتش محدود است، داخل یک شیء [Shape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/shape/) بسته می‌شود.

دو روش برای اعمال واترمارک وجود دارد: بر روی یک اسلاید تنها یا بر روی تمام اسلایدهای ارائه. برای اعمال واترمارک بر روی تمام اسلایدها از Slide Master استفاده می‌شود — واترمارک به Slide Master اضافه می‌شود، در آنجا به‌صورت کامل طراحی می‌شود و به تمام اسلایدها اعمال می‌شود بدون اینکه امکان ویرایش واترمارک در اسلایدهای جداگانه تحت‌تاثیر قرار گیرد.

معمولاً واترمارک برای کاربران دیگر غیرقابل ویرایش در نظر گرفته می‌شود. برای جلوگیری از ویرایش واترمارک (یا بهتر بگوییم شکل والد واترمارک) Aspose.Slides قابلیت قفل‌گذاری بر شکل را فراهم می‌کند. می‌توانید یک شکل خاص را در یک اسلاید عادی یا در Slide Master قفل کنید. وقتی شکل واترمارک در Slide Master قفل شود، در تمام اسلایدهای ارائه قفل خواهد بود.

می‌توانید برای واترمارک یک نام تعیین کنید تا در آینده، اگر بخواهید آن را حذف کنید، به‌راحتی با نام در لیست شکل‌های اسلاید پیدا کنید.

می‌توانید واترمارک را به هر شکلی طراحی کنید؛ اما معمولاً ویژگی‌های مشترکی مانند تراز وسط، چرخش، موقعیت جلو و غیره وجود دارد. در مثال‌های زیر به چگونگی استفاده از این ویژگی‌ها می‌پردازیم.

## **واترمارک متنی**

### **افزودن واترمارک متنی به اسلاید**

برای افزودن واترمارک متنی در PPT، PPTX یا ODP، ابتدا می‌توانید یک شکل به اسلاید اضافه کنید، سپس یک فریم متن به این شکل اضافه کنید. فریم متن توسط نوع [**TextFrame**](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/TextFrame) نمایندگی می‌شود. این نوع از [Shape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Shape) ارث‌بری نمی‌کند، به‌طوری که مجموعه گسترده‌ای از ویژگی‌های موقعیت‌یابی برای تنظیم انعطاف‌پذیر واترمارک در اختیار ندارد. بنابراین، شیء [TextFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/TextFrame) داخل یک شیء [AutoShape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/AutoShape) بسته می‌شود. برای افزودن متن واترمارک به شکل، از متد [**addTextFrame**](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/AutoShape#addTextFrame-java.lang.String-) با متن واترمارک به‌عنوان پارامتر استفاده کنید:

```javascript
const watermarkText = "CONFIDENTIAL";

let presentation = new aspose.slides.Presentation();
let slide = presentation.getSlides().get_Item(0);

let watermarkShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 400, 40);
let watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

{{% alert color="primary" title="همچنین ببینید" %}} 
- نحوه استفاده از [TextFrame](/slides/fa/nodejs-java/text-formatting/).
{{% /alert %}}

### **افزودن واترمارک متنی به کل ارائه**

اگر می‌خواهید یک واترمارک متنی به تمام اسلایدهای ارائه (یعنی همه اسلایدها به‌صورت همزمان) اضافه کنید، آن را به [**MasterSlide**](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/MasterSlide) اضافه کنید. بقیه منطق همانند افزودن واترمارک به یک اسلاید است — یک شیء [AutoShape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/AutoShape) ایجاد کنید و سپس با استفاده از متد [**addTextFrame**](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/AutoShape#addTextFrame-java.lang.String-) واترمارک را به آن اضافه کنید:

```javascript
const watermarkText = "CONFIDENTIAL";

let presentation = new aspose.slides.Presentation();
let masterSlide = presentation.getMasters().get_Item(0);

let watermarkShape = masterSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 400, 40);
let watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

{{% alert color="primary" title="همچنین ببینید" %}} 
- [نحوه استفاده از ](/slides/fa/nodejs-java/slide-master/)[Slide Master](/slides/fa/nodejs-java/slide-master/)
{{% /alert %}}

### **تنظیم شفافیت شکل واترمارک**

به‌طور پیش‌فرض، شکل مستطیلی با رنگ‌های پر و خط استایل‌دار می‌شود. خطوط کد زیر شکل را شفاف می‌کند.

```javascript
watermarkShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
watermarkShape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
```

### **تنظیم قلم برای واترمارک متنی**

می‌توانید قلم واترمارک متنی را همان‌طور که در زیر نشان داده شده است، تغییر دهید.

```javascript
let textFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat();
textFormat.setLatinFont(new aspose.slides.FontData("Arial"));
textFormat.setFontHeight(50);
```

### **تنظیم رنگ متن واترمارک**

برای تنظیم رنگ متن واترمارک از این کد استفاده کنید:

```java
let alpha = 150;
let red = 200;
let green = 200;
let blue = 200;

let fillFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().getFillFormat();
fillFormat.setFillType(java.newByte(aspose.slides.FillType.Solid));
fillFormat.getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", red, green, blue, alpha));
```

### **مرکز کردن واترمارک متنی**
برای مرکز کردن واترمارک روی اسلاید می‌توانید کارهای زیر را انجام دهید:

```javascript
const watermarkWidth = 400;
const watermarkHeight = 40;
const watermarkX = (slideSize.getWidth() - watermarkWidth) / 2;
const watermarkY = (slideSize.getHeight() - watermarkHeight) / 2;

let watermarkShape = masterSlide.getShapes().addAutoShape(
        aspose.slides.ShapeType.Rectangle, watermarkX, watermarkY, watermarkWidth, watermarkHeight);
        
let watermarkFrame = watermarkShape.addTextFrame(watermarkText);
```

تصویر زیر نتیجه نهایی را نشان می‌دهد.

![متن واترمارک](text_watermark.png)

## **واترمارک تصویری**

### **افزودن واترمارک تصویری به یک ارائه**

برای افزودن واترمارک تصویری به تمام اسلایدهای ارائه، می‌توانید مراحل زیر را انجام دهید:

```javascript
let watermarkImage = aspose.slides.Images.fromFile("watermark.png");
let image = presentation.getImages().addImage(watermarkImage);

// ...

watermarkShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));
watermarkShape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
watermarkShape.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);
```

### **قفل‌گذاری واترمارک برای جلوگیری از ویرایش**

اگر لازم است از ویرایش واترمارک جلوگیری کنید، از متد [**AutoShape.getShapeLock**](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/AutoShape#getShapeLock--) بر روی شکل استفاده کنید. با این ویژگی می‌توانید شکل را از انتخاب، تغییر اندازه، جابجایی، گروه‌بندی با عناصر دیگر، قفل متن از ویرایش و موارد دیگر محافظت کنید:

```javascript
// قفل کردن شکل واترمارک از ویرایش
watermarkShape.getShapeLock().setSelectLocked(true);
watermarkShape.getShapeLock().setSizeLocked(true);
watermarkShape.getShapeLock().setTextLocked(true);
watermarkShape.getShapeLock().setPositionLocked(true);
watermarkShape.getShapeLock().setGroupingLocked(true);
```

### **آوردن واترمارک به جلو**

در Aspose.Slides، ترتیب Z-shapes می‌تواند از طریق متد [**SlideCollection.reorder**](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/SlideCollection#reorder-int-aspose.slides.ISlide...-) تنظیم شود. برای این کار، باید این متد را از لیست اسلایدهای ارائه صدا بزنید و مرجع شکل و شماره ترتیب آن را به متد پاس دهید. به این‌صورت می‌توانید یک شکل را به جلو یا به عقب اسلاید منتقل کنید. این قابلیت به‌ویژه وقتی مفید است که می‌خواهید واترمارک را جلوی محتوا قرار دهید:

```javascript
let shapeCount = slide.getShapes().size();
slide.getShapes().reorder(shapeCount - 1, watermarkShape);
```

### **تنظیم چرخش واترمارک**

در اینجا یک مثال کد برای تنظیم چرخش واترمارک به‌طوری که به‌صورت مورب بر روی اسلاید قرار گیرد، آورده شده است:

```javascript
const diagonalAngle = Math.atan(slideSize.getHeight() / slideSize.getWidth()) * 180 / Math.PI;

watermarkShape.setRotation(diagonalAngle);
```

### **تنظیم نام برای یک واترمارک**

Aspose.Slides به شما امکان می‌دهد نام یک شکل را تنظیم کنید. با استفاده از نام شکل می‌توانید در آینده به راحتی به آن دسترسی داشته و یا آن را حذف کنید. برای تنظیم نام شکل واترمارک، از متد [**AutoShape.getName**](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Shape#getName--) استفاده کنید:

```javascript
watermarkShape.setName("watermark");
```

### **حذف یک واترمارک**

برای حذف شکل واترمارک، از متد [AutoShape.getName](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Shape#getName--) برای یافتن آن در لیست شکل‌های اسلاید استفاده کنید. سپس شکل واترمارک را به متد [**ShapeCollection.remove**](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/ShapeCollection#remove-aspose.slides.IShape-) پاس دهید:

```javascript
for (var i = 0; i < slide.getShapes().size(); i++) {
    var shape = slide.getShapes().get_Item(i);
    if ("watermark" == shape.getName()) {
        slide.getShapes().remove(watermarkShape);
    }
}
```

## **سؤالات متداول**

**واترمارک چیست و چرا باید از آن استفاده کنم؟**

یک واترمارک یک پوشش متنی یا تصویری است که بر روی اسلایدها اعمال می‌شود و به حفاظت از مالکیت فکری، ارتقای شناخت برند یا جلوگیری از استفاده غیرمجاز از ارائه‌ها کمک می‌کند.

**آیا می‌توانم واترمارک را به همه اسلایدهای یک ارائه اضافه کنم؟**

بله، Aspose.Slides به شما امکان می‌دهد واترمارک را به هر اسلایدی از ارائه اضافه کنید. می‌توانید روی تمام اسلایدها پیمایش کنید و تنظیمات واترمارک را به‌صورت جداگانه اعمال کنید.

**چگونه می‌توانم شفافیت واترمارک را تنظیم کنم؟**

با تغییر تنظیمات [fill](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/shape/getfillformat/) شکل می‌توانید شفافیت واترمارک را تنظیم کنید. این کار باعث می‌شود واترمارک به‌صورت ظریف باشد و تمرکز بر محتوا را مختل نکند.

**کدام فرمت‌های تصویری برای واترمارک پشتیبانی می‌شوند؟**

Aspose.Slides از قالب‌های تصویری مختلفی مانند PNG، JPEG، GIF، BMP، SVG و موارد دیگر پشتیبانی می‌کند.

**آیا می‌توانم قلم و سبک یک واترمارک متنی را سفارشی کنم؟**

بله، می‌توانید هر قلم، اندازه و سبک دلخواهی را برای هماهنگی با طراحی ارائه و حفظ ثبات برند انتخاب کنید.

**چگونه موقعیت یا جهت واترمارک را تغییر دهم؟**

می‌توانید موقعیت و جهت واترمارک را با تغییر مختصات، اندازه و ویژگی‌های چرخش شکل تنظیم کنید.