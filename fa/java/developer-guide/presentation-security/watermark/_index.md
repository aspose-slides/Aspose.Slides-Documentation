---
title: افزودن واترمارک به ارائه‌ها در جاوا
linktitle: واترمارک
type: docs
weight: 40
url: /fa/java/watermark/
keywords:
- واترمارک
- واترمارک متنی
- واترمارک تصویری
- افزودن واترمارک
- تغییر واترمارک
- حذف واترمارک
- پاک کردن واترمارک
- افزودن واترمارک به PPT
- افزودن واترمارک به PPTX
- افزودن واترمارک به ODP
- حذف واترمارک از PPT
- حذف واترمارک از PPTX
- حذف واترمارک از ODP
- پاک کردن واترمارک از PPT
- پاک کردن واترمارک از PPTX
- پاک کردن واترمارک از ODP
- پاورپوینت
- OpenDocument
- ارائه
- جاوا
- Aspose.Slides
description: "مدیریت واترمارک‌های متنی و تصویری در ارائه‌های PowerPoint و OpenDocument با استفاده از جاوا برای نشان دادن پیش‌نویس، اطلاعات محرمانه، حق تکثیر و موارد دیگر."
---
## **مقدمه**

**یک واترمارک** در یک ارائه متنی یا تصویری است که بر روی یک اسلاید یا در تمام اسلایدهای ارائه استفاده می‌شود. معمولاً واترمارک برای نشان دادن اینکه ارائه یک پیش‌نویس است (مثلاً واترمارک «Draft»)، حاوی اطلاعات محرمانه است (مثلاً واترمارک «Confidential»)، مشخص کردن شرکت مربوطه (مثلاً واترمارک «Company Name»)، شناسایی نویسنده ارائه و غیره به کار می‌رود. واترمارک به جلوگیری از نقض حق تکثیر کمک می‌کند زیرا نشان می‌دهد که ارائه نباید کپی شود. واترمارک‌ها در فرمت‌های PowerPoint و OpenOffice استفاده می‌شوند. در Aspose.Slides می‌توانید واترمارک را به فرمت‌های PPT، PPTX و ODP اضافه کنید.

در [**Aspose.Slides**](https://products.aspose.com/slides/fa/java/)، روش‌های متنوعی برای ایجاد واترمارک در اسناد PowerPoint یا OpenOffice و تغییر طراحی و رفتار آن‌ها وجود دارد. نکتهٔ مشترک این است که برای افزودن واترمارک متنی باید از رابط [ITextFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/itextframe/) استفاده کنید و برای افزودن واترمارک تصویری، از کلاس [PictureFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/pictureframe/) یا پر کردن شکل واترمارک با تصویر استفاده کنید. `PictureFrame` رابط [IShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ishape/) را پیاده‌سازی می‌کند و به شما اجازه می‌دهد از تمام تنظیمات انعطاف‌پذیر شیء شکل استفاده کنید. از آنجا که `ITextFrame` یک شکل نیست و تنظیمات آن محدود است، در یک شیء [IShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ishape/) پیچیده می‌شود.

دو روش برای اعمال واترمارک وجود دارد: به یک اسلاید واحد یا به تمام اسلایدهای ارائه. از Slide Master برای افزودن واترمارک به تمام اسلایدهای ارائه استفاده می‌شود — واترمارک به Slide Master اضافه می‌شود، در آنجا به‌طور کامل طراحی می‌شود و به تمام اسلایدها اعمال می‌شود بدون اینکه امکان ویرایش واترمارک در اسلایدهای جداگانه تحت تأثیر قرار گیرد.

معمولاً واترمارک به‌عنوان غیرقابل ویرایش برای سایر کاربران در نظر گرفته می‌شود. برای جلوگیری از ویرایش واترمارک (یا به‌عبارت دیگر شکل والد واترمارک)، Aspose.Slides قابلیت قفل‌کردن شکل را فراهم می‌کند. یک شکل خاص می‌تواند در یک اسلاید عادی یا در Slide Master قفل شود. وقتی شکل واترمارک در Slide Master قفل شود، در تمام اسلایدهای ارائه نیز قفل می‌شود.

می‌توانید برای واترمارک یک نام تنظیم کنید تا در آینده، اگر می‌خواهید آن را حذف کنید، بتوانید بر اساس نام آن را در اشکال اسلاید پیدا کنید.

می‌توانید واترمارک را به هر شکلی طراحی کنید؛ اما معمولاً ویژگی‌های مشترکی مانند تراز وسط، چرخش، موقعیت جلو و غیره در واترمارک‌ها وجود دارد. در مثال‌های زیر به نحوه استفاده از این ویژگی‌ها می‌پردازیم.

## **واترمارک متنی**

### **افزودن واترمارک متنی به یک اسلاید**

برای افزودن واترمارک متنی در PPT، PPTX یا ODP ابتدا می‌توانید یک شکل به اسلاید اضافه کنید، سپس یک فریم متنی به این شکل اضافه کنید. فریم متنی توسط رابط [ITextFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/itextframe/) نمایندگی می‌شود. این نوع از [IShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ishape/) ارث‌برداری نمی‌کند، در حالی که [IShape] مجموعهٔ گسترده‌ای از ویژگی‌ها برای موقعیت‌یابی انعطاف‌پذیر واترمارک دارد. بنابراین، شیء [ITextFrame] در یک شیء [IAutoShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iautoshape/) پیچیده می‌شود. برای افزودن متن واترمارک به شکل، از متد [addTextFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) همان‌طور که در زیر نشان داده شده استفاده کنید.

```java
import com.aspose.slides.*;

String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

{{% alert color="info" title="See also" %}} 
- [چگونه از کلاس TextFrame استفاده کنیم](/slides/fa/java/text-formatting/)
{{% /alert %}}

### **افزودن واترمارک متنی به یک ارائه**

اگر می‌خواهید واترمارک متنی را به کل ارائه (یعنی تمام اسلایدها به‌صورت همزمان) اضافه کنید، آن را به [MasterSlide](https://reference.aspose.com/slides/fa/java/com.aspose.slides/masterslide/) اضافه کنید. بقیه منطق مشابه افزودن واترمارک به یک اسلاید است — یک شیء [IAutoShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iautoshape/) ایجاد کنید و سپس با استفاده از متد [addTextFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) واترمارک را به آن اضافه کنید.

```java
import com.aspose.slides.*;

String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
IMasterSlide masterSlide = presentation.getMasters().get_Item(0);

IAutoShape watermarkShape = masterSlide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

{{% alert color="info" title="See also" %}} 
- [چگونه از Slide Master استفاده کنیم](/slides/fa/java/slide-master/)
{{% /alert %}}

### **تنظیم شفافیت شکل واترمارک**

به‌صورت پیش‌فرض، شکل مستطیل با رنگ پر و خط سبک‌دار شده است. خطوط کد زیر شکل را شفاف می‌کنند.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);
IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

watermarkShape.getFillFormat().setFillType(FillType.NoFill);
watermarkShape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

presentation.dispose();
```

### **تنظیم قلم برای واترمارک متنی**

می‌توانید قلم واترمارک متنی را همان‌طور که در زیر نشان داده شده تغییر دهید.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);
IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame("CONFIDENTIAL");

IPortionFormat textFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat();
textFormat.setLatinFont(new FontData("Arial"));
textFormat.setFontHeight(50);

presentation.dispose();
```

### **تنظیم رنگ متن واترمارک**

برای تنظیم رنگ متن واترمارک از کد زیر استفاده کنید:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);
IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame("CONFIDENTIAL");

int alpha = 150, red = 200, green = 200, blue = 200;

IFillFormat fillFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().getFillFormat();
fillFormat.setFillType(FillType.Solid);
fillFormat.getSolidFillColor().setColor(new Color(red, green, blue, alpha));

presentation.dispose();
```

### **مرکزکردن واترمارک متنی**

امکان مرکز کردن واترمارک روی اسلاید وجود دارد و برای این کار می‌توانید به صورت زیر عمل کنید:

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

Dimension2D slideSize = presentation.getSlideSize().getSize();

float watermarkWidth = 400;
float watermarkHeight = 40;
float watermarkX = ((float)slideSize.getWidth() - watermarkWidth) / 2;
float watermarkY = ((float)slideSize.getHeight() - watermarkHeight) / 2;

IAutoShape watermarkShape = slide.getShapes().addAutoShape(
        ShapeType.Rectangle, watermarkX, watermarkY, watermarkWidth, watermarkHeight);

ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

تصویر زیر نتیجهٔ نهایی را نشان می‌دهد.

![واترمارک متنی](text_watermark.png)

## **واترمارک تصویری**

### **افزودن واترمارک تصویری به یک ارائه**

برای افزودن واترمارک تصویری به یک اسلاید ارائه می‌توانید به صورت زیر عمل کنید:

```java
import com.aspose.slides.*;
import java.io.FileInputStream;
import java.io.InputStream;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);
IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

InputStream imageStream = new FileInputStream("watermark.png");
IPPImage image = presentation.getImages().addImage(imageStream);

watermarkShape.getFillFormat().setFillType(FillType.Picture);
watermarkShape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
watermarkShape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

presentation.dispose();
```

### **قفل کردن واترمارک از ویرایش**

اگر نیاز به جلوگیری از ویرایش واترمارک دارید، از متد [IAutoShape.getAutoShapeLock](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iautoshape/#getAutoShapeLock--) بر روی شکل استفاده کنید. با این ویژگی می‌توانید از انتخاب، تغییر اندازه، جابجایی، گروه‌بندی با عناصر دیگر، قفل کردن متن از ویرایش و موارد دیگر محافظت کنید:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);
IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

// قفل کردن شکل واترمارک از ویرایش
watermarkShape.getAutoShapeLock().setSelectLocked(true);
watermarkShape.getAutoShapeLock().setSizeLocked(true);
watermarkShape.getAutoShapeLock().setTextLocked(true);
watermarkShape.getAutoShapeLock().setPositionLocked(true);
watermarkShape.getAutoShapeLock().setGroupingLocked(true);

presentation.dispose();
```

### **آوردن واترمارک به جلو**

در Aspose.Slides می‌توان ترتیب Z اشکال را از طریق متد [IShapeCollection.reorder](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-) تنظیم کرد. برای این کار کافی است این متد را از لیست اسلایدهای ارائه فراخوانی کنید و مرجع شکل و شماره ترتیب آن را به متد پاس دهید. به این ترتیب می‌توانید شکلی را به جلو یا به عقب اسلاید منتقل کنید. این قابلیت به‌خصوص زمانی مفید است که نیاز داشته باشید واترمارک را در جلوی دیگر محتواها قرار دهید:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);
IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

int shapeCount = slide.getShapes().size();
slide.getShapes().reorder(shapeCount - 1, watermarkShape);

presentation.dispose();
```

### **تنظیم چرخش واترمارک**

در ادامه نمونه کدی برای تنظیم چرخش واترمارک به‌طوری که به صورت قطری در سراسر اسلاید قرار گیرد آورده شده است:

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);
IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

Dimension2D slideSize = presentation.getSlideSize().getSize();

double diagonalAngle = Math.atan((slideSize.getHeight() / slideSize.getWidth())) * 180 / Math.PI;

watermarkShape.setRotation((float)diagonalAngle);

presentation.dispose();
```

### **تعیین نام برای یک واترمارک**

Aspose.Slides به شما امکان می‌دهد نام یک شکل را تنظیم کنید. با استفاده از نام شکل می‌توانید در آینده به‌راحتی آن را برای ویرایش یا حذف پیدا کنید. برای تنظیم نام شکل واترمارک، آن را به متد [IAutoShape.setName](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ishape/#setName-java.lang.String-) پاس دهید:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);
IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

watermarkShape.setName("watermark");

presentation.dispose();
```

### **حذف یک واترمارک**

برای حذف شکل واترمارک، از متد [IAutoShape.getName](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ishape/#getName--) برای یافتن آن در اشکال اسلاید استفاده کنید. سپس شکل واترمارک را به متد [IShapeCollection.remove](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) پاس دهید:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");

ISlide slide = presentation.getSlides().get_Item(0);

IShape[] slideShapes = slide.getShapes().toArray();
for (IShape shape : slideShapes) {
    if ("watermark".equals(shape.getName()))
    {
        slide.getShapes().remove(shape);
    }
}

presentation.dispose();
```

## **پرسش‌های متداول**

### واترمارک چیست و چرا باید از آن استفاده کنم؟

واترمارک یک لایهٔ متنی یا تصویری است که بر روی اسلایدها اعمال می‌شود و به محافظت از مالکیت فکری، ارتقاء شناخت برند یا جلوگیری از استفادهٔ غیرمجاز از ارائه‌ها کمک می‌کند.

### آیا می‌توانم واترمارک را به تمام اسلایدهای یک ارائه اضافه کنم؟

بله، Aspose.Slides امکان افزودن برنامه‌نویسی‌شده واترمارک به هر اسلاید از یک ارائه را فراهم می‌کند. می‌توانید به‌صورت حلقه‌ای تمام اسلایدها را پیمایش کنید و تنظیمات واترمارک را به‌صورت جداگانه اعمال کنید.

### چگونه می‌توانم شفافیت واترمارک را تنظیم کنم؟

با تغییر تنظیمات پر (مانند متد [getFillFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/shape/#getFillFormat--)) شکل می‌توانید شفافیت واترمارک را تنظیم کنید. این کار باعث می‌شود واترمارک به‌صورت ملایم ظاهر شود و تمرکز مخاطب را از محتوای اسلاید منحرف نکند.

### چه فرمت‌های تصویری برای واترمارک پشتیبانی می‌شوند؟

Aspose.Slides از فرمت‌های مختلف تصویری مانند PNG، JPEG، GIF، BMP، SVG و غیره پشتیبانی می‌کند.

### آیا می‌توانم قلم و سبک واترمارک متنی را سفارشی کنم؟

بله، می‌توانید هر قلم، اندازه و استایلی را انتخاب کنید تا با طراحی ارائه‌تان هماهنگ باشد و یکپارچگی برند را حفظ کنید.

### چگونه می‌توانم موقعیت یا جهت واترمارک را تغییر دهم؟

می‌توانید با برنامه‌نویسی موقعیت و جهت واترمارک را با تغییر مختصات، اندازه و ویژگی‌های چرخش شکل تنظیم کنید.