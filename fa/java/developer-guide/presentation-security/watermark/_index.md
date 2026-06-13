---
title: افزودن آب‌نشان به ارائه‌ها در Java
linktitle: آب‌نشان
type: docs
weight: 40
url: /fa/java/watermark/
keywords:
- آب‌نشان
- آب‌نشان متنی
- آب‌نشان تصویری
- افزودن آب‌نشان
- تغییر آب‌نشان
- حذف آب‌نشان
- حذف آب‌نشان
- افزودن آب‌نشان به PPT
- افزودن آب‌نشان به PPTX
- افزودن آب‌نشان به ODP
- حذف آب‌نشان از PPT
- حذف آب‌نشان از PPTX
- حذف آب‌نشان از ODP
- حذف آب‌نشان از PPT
- حذف آب‌نشان از PPTX
- حذف آب‌نشان از ODP
- PowerPoint
- OpenDocument
- ارائه
- Java
- Aspose.Slides
description: "آب‌نشانی‌های متنی و تصویری را در ارائه‌های PowerPoint و OpenDocument با استفاده از Java مدیریت کنید تا پیش‌نویس، اطلاعات محرمانه، حق کپی‌رایت و موارد دیگر را نشان دهند."
---
## **معرفی**

**یک آب‌نشان** در یک ارائه متنی یا تصویری است که بر روی یک اسلاید یا تمام اسلایدهای ارائه قرار می‌گیرد. معمولاً برای نشان دادن اینکه ارائه پیش‌نویس است (به عنوان مثال، آب‌نشان «پیش‌نویس»)، حاوی اطلاعات محرمانه است (آب‌نشان «محرمانه»)، تعلق به شرکت خاصی دارد (آب‌نشان «نام شرکت»)، شناسایی نویسنده ارائه و غیره استفاده می‌شود. آب‌نشان به جلوگیری از نقض حق تکثیر کمک می‌کند زیرا نشان می‌دهد که ارائه نباید کپی شود. آب‌نشان‌ها هم در قالب‌های PowerPoint و هم OpenOffice استفاده می‌شوند. در Aspose.Slides می‌توانید آب‌نشان را به فایل‌های PPT، PPTX و ODP اضافه کنید.

در [**Aspose.Slides**](https://products.aspose.com/slides/fa/java/) روش‌های مختلفی برای ایجاد آب‌نشان در اسناد PowerPoint یا OpenOffice و تغییر طراحی و رفتار آن‌ها وجود دارد. جنبه مشترک این است که برای افزودن آب‌نشان متنی باید از رابط [ITextFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/itextframe/) استفاده کنید و برای افزودن آب‌نشان تصویری از کلاس [PictureFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/pictureframe/) یا پر کردن یک شکل آب‌نشان با تصویر استفاده نمایید. `PictureFrame` رابط [IShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ishape/) را پیاده‌سازی می‌کند و به شما امکان استفاده از تنظیمات انعطاف‌پذیر شیء شکل را می‌دهد. از آنجا که `ITextFrame` یک شکل نیست و تنظیمات محدودی دارد، در یک شیء [IShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ishape/) پیچیده می‌شود.

دو روش برای اعمال آب‌نشان وجود دارد: به یک اسلاید واحد یا به تمام اسلایدهای ارائه. اسلاید مستر برای اعمال آب‌نشان به تمام اسلایدها استفاده می‌شود — آب‌نشان به اسلاید مستر اضافه می‌شود، کاملاً در آنجا طراحی می‌شود و به تمام اسلایدها اعمال می‌شود بدون اینکه اجازه ویرایش آب‌نشان در اسلایدهای جداگانه تحت تأثیر قرار گیرد.

آب‌نشان معمولاً برای ویرایش توسط سایر کاربران در دسترس نیست. برای جلوگیری از ویرایش آب‌نشان (یا بهتر بگوییم شکل والد آب‌نشان) Aspose.Slides قابلیت قفل کردن شکل را فراهم می‌کند. یک شکل خاص می‌تواند در اسلاید معمولی یا در اسلاید مستر قفل شود. وقتی شکل آب‌نشان در اسلاید مستر قفل شود، در تمام اسلایدهای ارائه قفل می‌ماند.

می‌توانید نامی برای آب‌نشان تعیین کنید تا در آینده، اگر بخواهید آن را حذف کنید، بتوانید آن را بر پایه نام در لیست اشکال اسلاید پیدا کنید.

آب‌نشان می‌تواند به هر شکلی طراحی شود؛ اما معمولاً ویژگی‌های مشترکی مانند تراز وسط، چرخش، قرارگیری در جلو و غیره دارد. در مثال‌های زیر نحوه استفاده از این ویژگی‌ها را بررسی می‌کنیم.

## **آب‌نشان متنی**

### **افزودن آب‌نشان متنی به یک اسلاید**

برای افزودن آب‌نشان متنی در PPT، PPTX یا ODP، ابتدا می‌توانید یک شکل به اسلاید اضافه کنید، سپس یک فریم متن به این شکل اضافه کنید. فریم متن توسط رابط [ITextFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/itextframe/) نمایندگی می‌شود. این نوع از [IShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ishape/) به ارث نمی‌برد، که مجموعه گسترده‌ای از خصوصیات برای موقعیت‌یابی انعطاف‌پذیر آب‌نشان فراهم می‌کند. لذا شیٔ [ITextFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/itextframe/) در یک شیٔ [IAutoShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iautoshape/) بسته می‌شود. برای افزودن متن آب‌نشان به شکل، از متد [addTextFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) همان‌طور که در زیر نشان داده شده استفاده کنید.

```java
String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

{{% alert color="primary" title="See also" %}} 
- [How to Use the TextFrame Class](/slides/fa/java/text-formatting/)
{{% /alert %}}

### **افزودن آب‌نشان متنی به یک ارائه**

اگر می‌خواهید آب‌نشان متنی را به تمام اسلایدهای ارائه (یعنی همزمان به همه اسلایدها) اضافه کنید، آن را به [MasterSlide](https://reference.aspose.com/slides/fa/java/com.aspose.slides/masterslide/) اضافه کنید. منطق باقی‌مانده همانند افزودن آب‌نشان به یک اسلاید است — ابتدا یک شیٔ [IAutoShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iautoshape/) ایجاد کنید و سپس با استفاده از متد [addTextFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) آب‌نشان را به آن اضافه کنید.

```java
String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
IMasterSlide masterSlide = presentation.getMasters().get_Item(0);

IAutoShape watermarkShape = masterSlide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

{{% alert color="primary" title="See also" %}} 
- [How to Use the Slide Master](/slides/fa/java/slide-master/)
{{% /alert %}}

### **تنظیم شفافیت شکل آب‌نشان**

به طور پیش‌فرض، شکل مستطیل با رنگ پر و خط است. خطوط کد زیر شکل را شفاف می‌کند.

```java
watermarkShape.getFillFormat().setFillType(FillType.NoFill);
watermarkShape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
```

### **تنظیم فونت برای آب‌نشان متنی**

می‌توانید فونت متن آب‌نشان را همان‌طور که در زیر نشان داده شده تغییر دهید.

```java
IPortionFormat textFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat();
textFormat.setLatinFont(new FontData("Arial"));
textFormat.setFontHeight(50);
```

### **تنظیم رنگ متن آب‌نشان**

برای تنظیم رنگ متن آب‌نشان از کد زیر استفاده کنید:

```java
int alpha = 150, red = 200, green = 200, blue = 200;

IFillFormat fillFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().getFillFormat();
fillFormat.setFillType(FillType.Solid);
fillFormat.getSolidFillColor().setColor(new Color(red, green, blue, alpha));
```

### **وسط‌چین کردن آب‌نشان متنی**

امکان وسط‌چین کردن آب‌نشان روی اسلاید وجود دارد و برای این کار می‌توانید اقدامات زیر را انجام دهید:

```java
Dimension2D slideSize = presentation.getSlideSize().getSize();

float watermarkWidth = 400;
float watermarkHeight = 40;
float watermarkX = ((float)slideSize.getWidth() - watermarkWidth) / 2;
float watermarkY = ((float)slideSize.getHeight() - watermarkHeight) / 2;

IAutoShape watermarkShape = slide.getShapes().addAutoShape(
        ShapeType.Rectangle, watermarkX, watermarkY, watermarkWidth, watermarkHeight);

ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);
```

تصویر زیر نتیجه نهایی را نشان می‌دهد.

![آب‌نشان متنی](text_watermark.png)

## **آب‌نشان تصویری**

### **افزودن آب‌نشان تصویری به یک ارائه**

برای افزودن آب‌نشان تصویری به اسلاید یک ارائه می‌توانید مراحل زیر را انجام دهید:

```java
InputStream imageStream = new FileInputStream("watermark.png");
IPPImage image = presentation.getImages().addImage(imageStream);

watermarkShape.getFillFormat().setFillType(FillType.Picture);
watermarkShape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
watermarkShape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
```

### **قفل کردن آب‌نشان برای جلوگیری از ویرایش**

اگر نیاز به جلوگیری از ویرایش آب‌نشان دارید، از متد [IAutoShape.getAutoShapeLock](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iautoshape/#getAutoShapeLock--) بر روی شکل استفاده کنید. با این ویژگی می‌توانید شکل را از انتخاب، تغییر اندازه، جابجایی، گروه‌بندی با عناصر دیگر، قفل کردن متن برای ویرایش و موارد دیگر محافظت کنید:

```java
// قفل کردن شکل آب‌نشان برای جلوگیری از تغییر
watermarkShape.getAutoShapeLock().setSelectLocked(true);
watermarkShape.getAutoShapeLock().setSizeLocked(true);
watermarkShape.getAutoShapeLock().setTextLocked(true);
watermarkShape.getAutoShapeLock().setPositionLocked(true);
watermarkShape.getAutoShapeLock().setGroupingLocked(true);
```

### **آوردن آب‌نشان به جلو**

در Aspose.Slides می‌توانید ترتیب Z اشکال را با استفاده از متد [IShapeCollection.reorder](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-) تنظیم کنید. برای این کار باید این متد را از لیست اسلایدهای ارائه فراخوانی کنید و مرجع شکل و شماره ترتیب آن را به متد پاس دهید. به این ترتیب می‌توانید شکل را به جلو یا به عقب اسلاید منتقل کنید. این امکان به‌ویژه وقتی مفید است که بخواهید آب‌نشان را در جلوی محتوا قرار دهید:

```java
int shapeCount = slide.getShapes().size();
slide.getShapes().reorder(shapeCount - 1, watermarkShape);
```

### **تنظیم چرخش آب‌نشان**

در زیر نمونه کدی برای تنظیم چرخش آب‌نشان به طوری که به صورت مورب بر روی اسلاید قرار گیرد، آورده شده است:

```java
double diagonalAngle = Math.atan((slideSize.getHeight() / slideSize.getWidth())) * 180 / Math.PI;

watermarkShape.setRotation((float)diagonalAngle);
```

### **تنظیم نام برای آب‌نشان**

Aspose.Slides به شما امکان می‌دهد نام یک شکل را تعیین کنید. با استفاده از نام شکل می‌توانید در آینده به آن دسترسی پیدا کنید تا تغییر یا حذف کنید. برای تنظیم نام شکل آب‌نشان، مقدار را به متد [IAutoShape.setName](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ishape/#setName-java.lang.String-) پاس دهید:

```java
watermarkShape.setName("watermark");
```

### **حذف آب‌نشان**

برای حذف شکل آب‌نشان، از متد [IAutoShape.getName](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ishape/#getName--) برای یافتن آن در اشکال اسلاید استفاده کنید. سپس شکل آب‌نشان را به متد [IShapeCollection.remove](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) پاس دهید:

```java
IShape[] slideShapes = slide.getShapes().toArray();
for (IShape shape : slideShapes) {
    if ("watermark".equals(shape.getName()))
    {
        slide.getShapes().remove(watermarkShape);
    }
}
```

## **پرسش‌های رایج**

**آب‌نشان چیست و چرا باید از آن استفاده کنم؟**

آب‌نشان یک پوشش متنی یا تصویری است که بر روی اسلایدها اعمال می‌شود و به محافظت از مالکیت فکری، افزایش شناخت برند یا جلوگیری از استفاده غیرمجاز از ارائه‌ها کمک می‌کند.

**آیا می‌توانم آب‌نشان را به تمام اسلایدهای یک ارائه اضافه کنم؟**

بله، Aspose.Slides به شما امکان می‌دهد برنامه‌نویسی کنید و آب‌نشان را به هر اسلاید از یک ارائه اضافه کنید. می‌توانید از طریق تمام اسلایدها تکرار کنید و تنظیمات آب‌نشان را به‌صورت جداگانه اعمال نمایید.

**چگونه می‌توانم شفافیت آب‌نشان را تنظیم کنم؟**

با تغییر تنظیمات پر (متد [getFillFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/shape/#getFillFormat--)) شکل می‌توانید شفافیت آب‌نشان را تنظیم کنید. این کار باعث می‌شود آب‌نشان به‌صورت ملایم باشد و توجه را از محتوای اسلاید منحرف نکند.

**چه فرمت‌های تصویری برای آب‌نشان پشتیبانی می‌شوند؟**

Aspose.Slides انواع فرمت‌های تصویری مانند PNG، JPEG، GIF، BMP، SVG و غیره را پشتیبانی می‌کند.

**آیا می‌توانم فونت و سبک آب‌نشان متنی را سفارشی کنم؟**

بله، می‌توانید هر فونت، اندازه و سبکی را انتخاب کنید تا با طراحی ارائه شما هماهنگ باشد و برند شما را متناسب سازد.

**چگونه موقعیت یا جهت‌گیری آب‌نشان را تغییر دهم؟**

می‌توانید موقعیت و جهت‌گیری آب‌نشان را به‌صورت برنامه‌نویسی با تغییر مختصات، اندازه و خصوصیات چرخش شکل تنظیم کنید.