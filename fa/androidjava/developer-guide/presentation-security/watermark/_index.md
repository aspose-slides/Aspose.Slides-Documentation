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
- PowerPoint
- OpenDocument
- ارائه
- Android
- Java
- Aspose.Slides
description: "مدیریت واترمارک‌های متنی و تصویری در ارائه‌های PowerPoint و OpenDocument بر روی اندروید با Java برای نشان‌دادن پیش‌نویس، اطلاعات محرمانه و موارد دیگر."
---
## **معرفی**

**یک واترمارک** در یک ارائه متن یا تصویرمیکانی است که بر روی یک اسلاید یا تمام اسلایدهای ارائه استفاده می‌شود. معمولاً از واترمارک برای نشان دادن اینکه ارائه پیش‌نویس است (مثلاً واترمارک «Draft»)، که شامل اطلاعات محرمانه است (مثلاً واترمارک «Confidential»)، برای تعیین شرکت متعلق به آن (مثلاً واترمارک «Company Name»)، برای شناسایی نویسنده ارائه و غیره استفاده می‌شود. یک واترمارک به جلوگیری از نقض حق‌نشر کمک می‌کند زیرا نشان می‌دهد که ارائه نباید کپی شود. واترمارک‌ها در فرمت‌های ارائه PowerPoint و OpenOffice استفاده می‌شوند. در Aspose.Slides می‌توانید واترمارک را به فرمت‌های فایل PowerPoint PPT، PPTX و OpenOffice ODP اضافه کنید.

در [**Aspose.Slides**](https://products.aspose.com/slides/fa/android-java/) روش‌های مختلفی برای ایجاد واترمارک در اسناد PowerPoint یا OpenOffice و تغییر طراحی و رفتار آن وجود دارد. نکته مشترک این است که برای افزودن واترمارک‌های متنی باید از رابط [ITextFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/itextframe/) استفاده کنید و برای افزودن واترمارک‌های تصویری، از کلاس [PictureFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/pictureframe/) یا پر کردن یک شکل واترمارک با تصویر استفاده کنید. `PictureFrame` رابط [IShape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ishape/) را پیاده‌سازی می‌کند و به شما امکان استفاده از تمام تنظیمات انعطاف‌پذیر شیء شکل را می‌دهد. از آنجایی که `ITextFrame` یک شکل نیست و تنظیمات آن محدود است، در یک شیء [IShape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ishape/) بسته می‌شود.

دو روش برای اعمال واترمارک وجود دارد: به یک اسلاید واحد یا به تمام اسلایدهای ارائه. برای افزودن واترمارک به تمام اسلایدهای ارائه از اسلاید مستر استفاده می‌شود — واترمارک به اسلاید مستر اضافه می‌شود، در آنجا به‌طور کامل طراحی می‌شود و بدون تأثیر بر قابلیت ویرایش واترمارک در اسلایدهای جداگانه به تمام اسلایدها اعمال می‌گردد.

واترمارک معمولاً برای ویرایش توسط سایر کاربران در دسترس نیست. برای جلوگیری از ویرایش واترمارک (یا بهتر بگوییم شکل والد واترمارک) Aspose.Slides قابلیت قفل‌کردن شکل را فراهم می‌کند. یک شکل خاص می‌تواند در یک اسلاید معمولی یا در اسلاید مستر قفل شود. وقتی شکل واترمارک در اسلاید مستر قفل شود، در تمام اسلایدهای ارائه نیز قفل می‌ماند.

می‌توانید برای واترمارک نامی تعیین کنید تا در آینده در صورت نیاز به حذف، آن را بر اساس نام در لیست اشکال اسلاید پیدا کنید.

شما می‌توانید واترمارک را به هر شکلی طراحی کنید؛ با این حال معمولاً ویژگی‌های مشترکی مانند ترازبندی مرکز، چرخش، موقعیت جلو و غیره در واترمارک‌ها وجود دارد. در مثال‌های زیر به چگونگی استفاده از این ویژگی‌ها می‌پردازیم.

## **واترمارک متنی**

### **افزودن واترمارک متنی به اسلاید**

برای افزودن واترمارک متنی در PPT، PPTX یا ODP ابتدا می‌توانید یک شکل به اسلاید اضافه کنید، سپس یک قاب متن به این شکل افزوده شود. قاب متن توسط رابط [ITextFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/itextframe/) نمایندگی می‌شود. این نوع از [IShape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ishape/) ارث‌بردار نیست و مجموعه وسیعی از ویژگی‌های موقعیت‌یابی انعطاف‌پذیر را فراهم نمی‌کند. بنابراین شیء [ITextFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/itextframe/) در یک شیء [IAutoShape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iautoshape/) بسته می‌شود. برای افزودن متن واترمارک به شکل، از متد [addTextFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) همان‌طور که در زیر نشان داده شده استفاده کنید.

```java
import com.aspose.slides.*;

String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

{{% alert color="info" title="همچنین ببینید" %}} 
- [نحوه استفاده از کلاس TextFrame](/slides/fa/androidjava/text-formatting/)
{{% /alert %}}

### **افزودن واترمارک متنی به یک ارائه**

اگر می‌خواهید واترمارک متنی را به کل ارائه (یعنی تمام اسلایدها به‌صورت همزمان) اضافه کنید، آن را به [MasterSlide](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/masterslide/) اضافه کنید. بقیه منطق مشابه افزودن واترمارک به یک اسلاید است — یک شیء [IAutoShape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iautoshape/) ایجاد کنید و سپس با استفاده از متد [addTextFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) واترمارک را به آن اضافه کنید.

```java
import com.aspose.slides.*;

String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
IMasterSlide masterSlide = presentation.getMasters().get_Item(0);

IAutoShape watermarkShape = masterSlide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

{{% alert color="info" title="همچنین ببینید" %}} 
- [نحوه استفاده از اسلاید مستر](/slides/fa/androidjava/slide-master/)
{{% /alert %}}

### **تنظیم شفافیت شکل واترمارک**

به‌صورت پیش‌فرض شکل مستطیل با رنگ پر و خط است. خطوط کد زیر شکل را شفاف می‌کند.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

    watermarkShape.getFillFormat().setFillType(FillType.NoFill);
    watermarkShape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
} finally {
    presentation.dispose();
}
```

### **تنظیم فونت برای واترمارک متنی**

می‌توانید فونت متن واترمارک را همان‌طور که در زیر نشان داده شده تغییر دهید.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
    ITextFrame watermarkFrame = watermarkShape.addTextFrame("CONFIDENTIAL");

    IPortionFormat textFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat();
    textFormat.setLatinFont(new FontData("Arial"));
    textFormat.setFontHeight(50);
} finally {
    presentation.dispose();
}
```

### **تنظیم رنگ متن واترمارک**

برای تنظیم رنگ متن واترمارک از کد زیر استفاده کنید:

```java
import com.aspose.slides.*;
import java.awt.Color;

int alpha = 150, red = 200, green = 200, blue = 200;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
    ITextFrame watermarkFrame = watermarkShape.addTextFrame("CONFIDENTIAL");

    IFillFormat fillFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().getFillFormat();
    fillFormat.setFillType(FillType.Solid);
    fillFormat.getSolidFillColor().setColor(new Color(red, green, blue, alpha));
} finally {
    presentation.dispose();
}
```

### **ترازبندی مرکز واترمارک متنی**

می‌توانید واترمارک را در وسط اسلاید قرار دهید؛ برای این کار می‌توانید به صورت زیر عمل کنید:

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    Dimension2D slideSize = presentation.getSlideSize().getSize();

    float watermarkWidth = 400;
    float watermarkHeight = 40;
    float watermarkX = ((float)slideSize.getWidth() - watermarkWidth) / 2;
    float watermarkY = ((float)slideSize.getHeight() - watermarkHeight) / 2;

    IAutoShape watermarkShape = slide.getShapes().addAutoShape(
            ShapeType.Rectangle, watermarkX, watermarkY, watermarkWidth, watermarkHeight);

    ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);
} finally {
    presentation.dispose();
}
```

تصویر زیر نتایج نهایی را نشان می‌دهد.

![واترمارک متنی](text_watermark.png)

## **واترمارک تصویری**

### **افزودن واترمارک تصویری به یک ارائه**

برای افزودن واترمارک تصویری به اسلاید یک ارائه می‌توانید به صورت زیر عمل کنید:

```java
import com.aspose.slides.*;
import java.io.FileInputStream;
import java.io.InputStream;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

    InputStream imageStream = new FileInputStream("watermark.png");
    IPPImage image = presentation.getImages().addImage(imageStream);

    watermarkShape.getFillFormat().setFillType(FillType.Picture);
    watermarkShape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
    watermarkShape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
} finally {
    presentation.dispose();
}
```

### **قفل کردن واترمارک برای جلوگیری از ویرایش**

اگر نیاز به جلوگیری از ویرایش واترمارک دارید، از متد [IAutoShape.getAutoShapeLock](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iautoshape/#getAutoShapeLock--) بر روی شکل استفاده کنید. با این ویژگی می‌توانید شکل را از انتخاب، تغییر اندازه، جابجایی، گروه‌بندی با عناصر دیگر، قفل کردن متن از ویرایش و موارد دیگر محافظت کنید:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

    // قفل کردن شکل واترمارک برای جلوگیری از تغییر
    watermarkShape.getAutoShapeLock().setSelectLocked(true);
    watermarkShape.getAutoShapeLock().setSizeLocked(true);
    watermarkShape.getAutoShapeLock().setTextLocked(true);
    watermarkShape.getAutoShapeLock().setPositionLocked(true);
    watermarkShape.getAutoShapeLock().setGroupingLocked(true);
} finally {
    presentation.dispose();
}
```

### **آوردن واترمارک به جلو**

در Aspose.Slides، ترتیب Z اشکال می‌تواند با متد [IShapeCollection.reorder](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-) تنظیم شود. برای این کار باید این متد را از لیست اسلایدهای ارائه فراخوانی کنید و مرجع شکل و شماره ترتیب آن را به متد پاس بدهید. به این ترتیب می‌توانید شکل را به جلو یا به پشت اسلاید بکشید. این ویژگی به‌خصوص زمانی مفید است که بخواهید واترمارک را در جلوی ارائه قرار دهید:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

    int shapeCount = slide.getShapes().size();
    slide.getShapes().reorder(shapeCount - 1, watermarkShape);
} finally {
    presentation.dispose();
}
```

### **تنظیم چرخش واترمارک**

در ادامه نمونه کدی برای تنظیم چرخش واترمارک به طوری که به صورت مورب بر روی اسلاید قرار گیرد آمده است:

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
    Dimension2D slideSize = presentation.getSlideSize().getSize();

    double diagonalAngle = Math.atan((slideSize.getHeight() / slideSize.getWidth())) * 180 / Math.PI;

    watermarkShape.setRotation((float)diagonalAngle);
} finally {
    presentation.dispose();
}
```

### **تنظیم نام برای واترمارک**

Aspose.Slides به شما امکان می‌دهد نام یک شکل را تعیین کنید. با استفاده از نام شکل می‌توانید در آینده به آن دسترسی داشته باشید تا آن را اصلاح یا حذف کنید. برای تنظیم نام شکل واترمارک، آن را به متد [IAutoShape.setName](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ishape/#setName-java.lang.String-) اختصاص دهید:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

    watermarkShape.setName("watermark");
} finally {
    presentation.dispose();
}
```

### **حذف واترمارک**

برای حذف شکل واترمارک، از متد [IAutoShape.getName](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ishape/#getName--) برای یافتن آن در اشکال اسلاید استفاده کنید. سپس شکل واترمارک را به متد [IShapeCollection.remove](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) پاس بدهید:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("watermarked.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape[] slideShapes = slide.getShapes().toArray();
    for (IShape shape : slideShapes) {
        if ("watermark".equals(shape.getName()))
        {
            slide.getShapes().remove(shape);
        }
    }
} finally {
    presentation.dispose();
}
```

## **سوالات متداول**

### واترمارک چیست و چرا باید از آن استفاده کنم؟

واترمارک یک پوشش متنی یا تصویری است که بر روی اسلایدها اعمال می‌شود و به محافظت از مالکیت فکری، تقویت شناخت برند یا جلوگیری از استفاده غیرمجاز از ارائه‌ها کمک می‌کند.

### آیا می‌توانم واترمارک را به تمام اسلایدهای یک ارائه اضافه کنم؟

بله، Aspose.Slides به شما امکان می‌دهد برنامه‌نویسی کنید و واترمارک را به هر اسلاید از یک ارائه اضافه کنید. می‌توانید به تمام اسلایدها پیمایش کنید و تنظیمات واترمارک را به صورت جداگانه اعمال کنید.

### چگونه می‌توانم شفافیت واترمارک را تنظیم کنم؟

می‌توانید شفافیت واترمارک را با تغییر تنظیمات پر ([getFillFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/shape/#getFillFormat--)) شکل تنظیم کنید. این کار اطمینان می‌دهد که واترمارک به‌صورت ظریف باقی می‌ماند و مزاحم محتوای اسلاید نمی‌شود.

### چه فرمت‌های تصویری برای واترمارک پشتیبانی می‌شوند؟

Aspose.Slides فرمت‌های تصویری متنوعی مانند PNG، JPEG، GIF، BMP، SVG و موارد دیگر را پشتیبانی می‌کند.

### آیا می‌توانم قلم و سبک واترمارک متنی را سفارشی کنم؟

بله، می‌توانید هر قلم، اندازه و سبکی را انتخاب کنید تا با طراحی ارائه شما هماهنگ باشد و سازگاری برند را حفظ کند.

### چگونه می‌توانم موقعیت یا جهت واترمارک را تغییر دهم؟

می‌توانید موقعیت و جهت واترمارک را با برنامه‌نویسی از طریق اصلاح مختصات، اندازه و خصوصیات چرخش شکل تنظیم کنید.