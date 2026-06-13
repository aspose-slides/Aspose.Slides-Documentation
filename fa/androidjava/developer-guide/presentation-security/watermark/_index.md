---
title: افزودن واترمارک‌ها به ارائه‌ها در اندروید
linktitle: واترمارک
type: docs
weight: 40
url: /fa/androidjava/watermark/
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
- پاورپوینت
- OpenDocument
- ارائه
- اندروید
- جاوا
- Aspose.Slides
description: "در اندروید با استفاده از جاوا، واترمارک‌های متنی و تصویری را در ارائه‌های PowerPoint و OpenDocument مدیریت کنید تا پیش‌نویس، اطلاعات محرمانه و موارد دیگر را نشان دهند."
---
## **مقدمه**

**یک واترمارک** در یک ارائه، متن یا تصویر علامتی است که بر روی اسلاید یا در تمام اسلایدهای ارائه استفاده می‌شود. معمولاً از واترمارک برای نشان دادن اینکه ارائه یک پیش‌نویس است (مثلاً واترمارک «Draft»)، حاوی اطلاعات محرمانه است (مثلاً واترمارک «Confidential»)، مشخص کردن شرکت صاحب آن (مثلاً واترمارک «Company Name»)، شناسایی نویسنده ارائه و غیره استفاده می‌شود. واترمارک به جلوگیری از نقض حق‌تألیف کمک می‌کند زیرا نشان می‌دهد که نباید ارائه کپی شود. واترمارک‌ها در هر دو قالب ارائه PowerPoint و OpenOffice استفاده می‌شوند. در Aspose.Slides می‌توانید یک واترمارک به فرمت‌های فایل PowerPoint PPT، PPTX و OpenOffice ODP اضافه کنید.

در [**Aspose.Slides**](https://products.aspose.com/slides/fa/android-java/)، روش‌های مختلفی برای ایجاد واترمارک در اسناد PowerPoint یا OpenOffice و تغییر طراحی و رفتار آن‌ها وجود دارد. نکته مشترک این است که برای افزودن واترمارک‌های متنی باید از رابط [ITextFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/itextframe/) استفاده کنید و برای افزودن واترمارک‌های تصویری، از کلاس [PictureFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/pictureframe/) یا پر کردن شکل واترمارک با تصویر استفاده نمایید. `PictureFrame` رابط [IShape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ishape/) را پیاده‌سازی می‌کند و به شما امکان استفاده از تمام تنظیمات انعطاف‌پذیر شیء شکل را می‌دهد. از آنجا که `ITextFrame` یک شکل نیست و تنظیمات آن محدود است، در یک شیء [IShape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ishape/) پیچیده می‌شود.

دو روش برای اعمال واترمارک وجود دارد: روی یک اسلاید منفرد یا روی تمام اسلایدهای ارائه. اسلاید مستر برای اعمال واترمارک به تمام اسلایدهای ارائه استفاده می‌شود — واترمارک به اسلاید مستر اضافه می‌شود، به‌طور کامل در آن طراحی می‌شود و به تمام اسلایدها اعمال می‌شود بدون اینکه مجوز ویرایش واترمارک در اسلایدهای فردی تحت تأثیر قرار گیرد.

به‌طور معمول واترمارک برای ویرایش توسط سایر کاربران غیرقابل دسترس تلقی می‌شود. برای جلوگیری از ویرایش واترمارک (یا بهتر بگوییم شکل والد واترمارک) Aspose.Slides قابلیت قفل‌گذاری بر روی شکل‌ها را ارائه می‌دهد. یک شکل خاص می‌تواند در یک اسلاید عادی یا در اسلاید مستر قفل شود. وقتی شکل واترمارک در اسلاید مستر قفل شود، در تمام اسلایدهای ارائه نیز قفل خواهد بود.

می‌توانید برای واترمارک یک نام تعیین کنید تا در آینده، در صورت نیاز به حذف آن، بتوانید آن را بر اساس نام در شکل‌های اسلاید پیدا کنید.

می‌توانید واترمارک را به هر شکل طراحی کنید؛ با این حال، معمولاً ویژگی‌های مشترکی در واترمارک‌ها وجود دارد، مانند تراز مرکزی، چرخش، موقعیت جلویی و غیره. در مثال‌های زیر نحوه استفاده از این ویژگی‌ها را بررسی خواهیم کرد.

## **واترمارک متنی**

### **افزودن واترمارک متنی به یک اسلاید**

برای افزودن واترمارک متنی در PPT، PPTX یا ODP، ابتدا می‌توانید یک شکل به اسلاید اضافه کنید، سپس یک فریم متنی به این شکل اضافه کنید. فریم متنی توسط رابط [ITextFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/itextframe/) نمایان می‌شود. این نوع از [IShape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ishape/) ارث‌بری نمی‌کند، که مجموعه گسترده‌ای از ویژگی‌ها برای موقعیت‌یابی انعطاف‌پذیر واترمارک دارد. بنابراین، شیء [ITextFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/itextframe/) در یک شیء [IAutoShape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iautoshape/) پیچیده می‌شود. برای افزودن متن واترمارک به شکل، از متد [addTextFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) همان‌طور که در زیر نشان داده شده استفاده کنید.

```java
String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

{{% alert color="primary" title="همچنین" %}} 
- [نحوه استفاده از کلاس TextFrame](/slides/fa/androidjava/text-formatting/)
{{% /alert %}}

### **افزودن واترمارک متنی به یک ارائه**

اگر می‌خواهید یک واترمارک متنی به تمام ارائه (یعنی همه اسلایدها به‌صورت یک‌جا) اضافه کنید، آن را به [MasterSlide](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/masterslide/) اضافه کنید. بقیه منطق همانند افزودن واترمارک به یک اسلاید منفرد است — یک شیء [IAutoShape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iautoshape/) ایجاد کنید و سپس با استفاده از متد [addTextFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) واترمارک را به آن اضافه کنید.

```java
String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
IMasterSlide masterSlide = presentation.getMasters().get_Item(0);

IAutoShape watermarkShape = masterSlide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

{{% alert color="primary" title="همچنین" %}} 
- [نحوه استفاده از اسلاید مستر](/slides/fa/androidjava/slide-master/)
{{% /alert %}}

### **تنظیم شفافیت شکل واترمارک**

به‌طور پیش‌فرض، شکل مستطیلی با رنگ پر و خط استایل می‌شود. خطوط کد زیر، شکل را شفاف می‌کند.

```java
watermarkShape.getFillFormat().setFillType(FillType.NoFill);
watermarkShape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
```

### **تنظیم قلم برای واترمارک متنی**

می‌توانید قلم واترمارک متنی را همان‌طور که در زیر نشان داده شده تغییر دهید.

```java
IPortionFormat textFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat();
textFormat.setLatinFont(new FontData("Arial"));
textFormat.setFontHeight(50);
```

### **تنظیم رنگ متن واترمارک**

برای تنظیم رنگ متن واترمارک، از این کد استفاده کنید:

```java
int alpha = 150, red = 200, green = 200, blue = 200;

IFillFormat fillFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().getFillFormat();
fillFormat.setFillType(FillType.Solid);
fillFormat.getSolidFillColor().setColor(Color.argb(alpha, red, green, blue));
```

### **متمرکز کردن واترمارک متنی**

می‌توانید واترمارک را در یک اسلاید مرکز چین کنید، و برای این کار می‌توانید اقدامات زیر را انجام دهید:

```java
SizeF slideSize = presentation.getSlideSize().getSize();

float watermarkWidth = 400;
float watermarkHeight = 40;
float watermarkX = ((float)slideSize.getWidth() - watermarkWidth) / 2;
float watermarkY = ((float)slideSize.getHeight() - watermarkHeight) / 2;

IAutoShape watermarkShape = slide.getShapes().addAutoShape(
        ShapeType.Rectangle, watermarkX, watermarkY, watermarkWidth, watermarkHeight);

ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);
```

![واترمارک متن](text_watermark.png)

## **واترمارک تصویری**

### **افزودن واترمارک تصویری به یک ارائه**

برای افزودن واترمارک تصویری به اسلاید یک ارائه، می‌توانید مراحل زیر را انجام دهید:

```java
InputStream imageStream = new FileInputStream("watermark.png");
IPPImage image = presentation.getImages().addImage(imageStream);

watermarkShape.getFillFormat().setFillType(FillType.Picture);
watermarkShape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
watermarkShape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
```

### **قفل‌گذاری واترمارک برای جلوگیری از ویرایش**

اگر نیاز به جلوگیری از ویرایش واترمارک دارید، از متد [IAutoShape.getAutoShapeLock](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iautoshape/#getAutoShapeLock--) بر روی شکل استفاده کنید. با این خصوصیت می‌توانید شکل را از انتخاب، تغییر اندازه، تغییر موقعیت، گروه‌بندی با سایر عناصر، قفل کردن متن آن برای ویرایش و موارد دیگر محافظت کنید:

```java
// قفل کردن شکل واترمارک برای جلوگیری از تغییر
watermarkShape.getAutoShapeLock().setSelectLocked(true);
watermarkShape.getAutoShapeLock().setSizeLocked(true);
watermarkShape.getAutoShapeLock().setTextLocked(true);
watermarkShape.getAutoShapeLock().setPositionLocked(true);
watermarkShape.getAutoShapeLock().setGroupingLocked(true);
```

### **آورده کردن واترمارک به جلو**

در Aspose.Slides، ترتیب Z اشکال می‌تواند از طریق متد [IShapeCollection.reorder](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-) تنظیم شود. برای این کار، باید این متد را از لیست اسلایدهای ارائه فراخوانی کرده و مرجع شکل و شماره ترتیب آن را به متد پاس کنید. به این ترتیب می‌توانید یک شکل را به جلو یا به پشت اسلاید منتقل کنید. این ویژگی به‌ویژه وقتی مفید است که نیاز به قرار دادن واترمارک در جلو ارائه داشته باشید:

```java
int shapeCount = slide.getShapes().size();
slide.getShapes().reorder(shapeCount - 1, watermarkShape);
```

### **تنظیم چرخش واترمارک**

در اینجا یک مثال کد برای تنظیم چرخش واترمارک به‌طوری که به صورت قطری در اسلاید قرار گیرد آورده شده است:

```java
double diagonalAngle = Math.atan((slideSize.getHeight() / slideSize.getWidth())) * 180 / Math.PI;

watermarkShape.setRotation((float)diagonalAngle);
```

### **تنظیم نام برای واترمارک**

Aspose.Slides به شما امکان می‌دهد نام یک شکل را تنظیم کنید. با استفاده از نام شکل می‌توانید در آینده به آن دسترسی پیدا کنید تا آن را تغییر یا حذف کنید. برای تنظیم نام شکل واترمارک، آن را به متد [IAutoShape.setName](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ishape/#setName-java.lang.String-) اختصاص دهید:

```java
watermarkShape.setName("watermark");
```

### **حذف واترمارک**

برای حذف شکل واترمارک، از متد [IAutoShape.getName](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ishape/#getName--) برای یافتن آن در شکل‌های اسلاید استفاده کنید. سپس، شکل واترمارک را به متد [IShapeCollection.remove](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) پاس دهید:

```java
IShape[] slideShapes = slide.getShapes().toArray();
for (IShape shape : slideShapes) {
    if ("watermark".equals(shape.getName()))
    {
        slide.getShapes().remove(watermarkShape);
    }
}
```

## **سوالات متداول**

**واترمارک چیست و چرا باید از آن استفاده کنم؟**

واترمارک یک لایه متنی یا تصویری است که بر روی اسلایدها اعمال می‌شود و به محافظت از مالکیت فکری، تقویت شناخت برند یا جلوگیری از استفاده غیرمجاز از ارائه‌ها کمک می‌کند.

**آیا می‌توانم واترمارک را به تمام اسلایدهای یک ارائه اضافه کنم؟**

بله، Aspose.Slides به شما امکان می‌دهد به‌صورت برنامه‌نویسی واترمارک را به هر اسلاید یک ارائه اضافه کنید. می‌توانید از روی تمام اسلایدها حلقه بزنید و تنظیمات واترمارک را به صورت جداگانه اعمال کنید.

**چگونه می‌توانم شفافیت واترمارک را تنظیم کنم؟**

می‌توانید شفافیت واترمارک را با تغییر تنظیمات پر شدن ([getFillFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/shape/#getFillFormat--)) شکل تنظیم کنید. این کار اطمینان می‌دهد که واترمارک به‌صورت ملایم ظاهر شده و محتوی اسلاید را مشغول نمی‌کند.

**چه قالب‌های تصویری برای واترمارک‌ها پشتیبانی می‌شوند؟**

Aspose.Slides قالب‌های تصویری مختلفی مانند PNG، JPEG، GIF، BMP، SVG و غیره را پشتیبانی می‌کند.

**آیا می‌توانم قلم و سبک یک واترمارک متنی را سفارشی کنم؟**

بله، می‌توانید هر قلم، اندازه و سبکی را انتخاب کنید تا با طراحی ارائه شما هماهنگ باشد و سازگاری برند حفظ شود.

**چگونه موقعیت یا جهت واترمارک را تغییر دهم؟**

می‌توانید موقعیت و جهت واترمارک را به‌صورت برنامه‌نویسی با تغییر مختصات، اندازه و خصوصیات چرخش شکل تنظیم کنید.