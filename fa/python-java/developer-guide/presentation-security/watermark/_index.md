---
title: "افزودن آب‌نشان به ارائه‌ها در پایتون"
linktitle: "آب‌نشان"
type: docs
weight: 40
url: /fa/python-java/watermark/
keywords:
- "آب‌نشان"
- "آب‌نشان متنی"
- "آب‌نشان تصویری"
- "افزودن آب‌نشان"
- "تغییر آب‌نشان"
- "حذف آب‌نشان"
- "حذف آب‌نشان"
- "افزودن آب‌نشان به PPT"
- "افزودن آب‌نشان به PPTX"
- "افزودن آب‌نشان به ODP"
- "حذف آب‌نشان از PPT"
- "حذف آب‌نشان از PPTX"
- "حذف آب‌نشان از ODP"
- "پاک‌سازی آب‌نشان از PPT"
- "پاک‌سازی آب‌نشان از PPTX"
- "پاک‌سازی آب‌نشان از ODP"
- PowerPoint
- OpenDocument
- "ارائه"
- Python
- Aspose.Slides
description: "مدیریت آب‌نشان‌های متنی و تصویری در ارائه‌های PowerPoint و OpenDocument با استفاده از پایتون برای نشان دادن پیش‌نویس، اطلاعات محرمانه، حق تکثیر و موارد دیگر."
---
## **مقدمه**

**آب‌نشان** در یک ارائه متنی یا تصویری است که بر روی یک اسلاید یا تمام اسلایدهای ارائه اعمال می‌شود. معمولاً از آب‌نشان برای نشان دادن اینکه ارائه یک پیش‌نویس است (مثلاً آب‌نشان "Draft")، اینکه شامل اطلاعات محرمانه است (مثلاً آب‌نشان "Confidential")، برای مشخص کردن شرکت مالك (مثلاً آب‌نشان "Company Name")، برای شناسایی نویسنده ارائه و غیره استفاده می‌شود. آب‌نشان به جلوگیری از تخلفات حق تکثیر کمک می‌کند زیرا نشان می‌دهد که نباید ارائه کپی شود. آب‌نشان‌ها هم در فرمت‌های PowerPoint و هم OpenOffice استفاده می‌شوند. در Aspose.Slides می‌توانید آب‌نشان به فرمت‌های PowerPoint PPT، PPTX و OpenOffice ODP اضافه کنید.

در [Aspose.Slides](https://products.aspose.com/slides/fa/python-java/)، روش‌های مختلفی برای ایجاد آب‌نشان در اسناد PowerPoint یا OpenOffice و تغییر طراحی و رفتار آن‌ها وجود دارد. نکته مشترک این است که برای افزودن آب‌نشان متنی باید از کلاس [TextFrame](https://reference.aspose.com/slides/fa/python-java/aspose.slides/textframe/) استفاده کنید و برای افزودن آب‌نشان تصویری از کلاس [PictureFrame](https://reference.aspose.com/slides/fa/python-java/aspose.slides/pictureframe/) یا پر کردن یک شکل آب‌نشان با تصویر استفاده کنید. کلاس [PictureFrame](https://reference.aspose.com/slides/fa/python-java/aspose.slides/pictureframe/) از کلاس [Shape](https://reference.aspose.com/slides/fa/python-java/aspose.slides/shape/) ارث‌بری می‌کند و به شما امکان استفاده از تمام تنظیمات انعطاف‌پذیر شیء شکل را می‌دهد. از آنجایی که کلاس [TextFrame](https://reference.aspose.com/slides/fa/python-java/aspose.slides/textframe/) یک شکل نیست و تنظیمات آن محدود است، در یک شیء [Shape](https://reference.aspose.com/slides/fa/python-java/aspose.slides/shape/) بسته می‌شود.

دو روش برای اعمال آب‌نشان وجود دارد: بر روی یک اسلاید یا بر روی تمام اسلایدهای ارائه. برای اعمال آب‌نشان به تمام اسلایدها از Slide Master استفاده می‌شود — آب‌نشان به Slide Master اضافه می‌شود، در آنجا به‌طور کامل طراحی می‌شود و به تمام اسلایدها اعمال می‌شود بدون اینکه اجازه ویرایش آب‌نشان در اسلایدهای جداگانه تحت تأثیر قرار گیرد.

معمولاً آب‌نشان برای کاربران دیگر غیرقابل ویرایش در نظر گرفته می‌شود. برای جلوگیری از ویرایش آب‌نشان (یا بهتر بگوییم شکل والد آب‌نشان) Aspose.Slides قابلیت قفل کردن شکل را فراهم می‌کند. یک شکل خاص می‌تواند در یک اسلاید عادی یا در Slide Master قفل شود. وقتی شکل آب‌نشان در Slide Master قفل شود، در تمام اسلایدهای ارائه نیز قفل می‌ماند.

می‌توانید برای آب‌نشان نامی تنظیم کنید تا در آینده، اگر می‌خواهید آن را حذف کنید، بتوانید با نام آن را در اشکال اسلاید پیدا کنید.

می‌توانید آب‌نشان را به هر شکلی طراحی کنید؛ اما معمولاً ویژگی‌های مشترکی در آب‌نشان‌ها وجود دارد، مانند تراز وسط، چرخش، قرارگیری در جلو و غیره. در مثال‌های زیر نحوه استفاده از این ویژگی‌ها را بررسی می‌کنیم.

## **آب‌نشان متنی**

### **افزودن آب‌نشان متنی به یک اسلاید**

برای افزودن آب‌نشان متنی در PPT، PPTX یا ODP، ابتدا می‌توانید یک شکل به اسلاید اضافه کنید، سپس یک فریم متنی به این شکل اضافه کنید. فریم متنی توسط کلاس [TextFrame](https://reference.aspose.com/slides/fa/python-java/aspose.slides/textframe/) نمایان می‌شود. این نوع از کلاس از کلاس [Shape](https://reference.aspose.com/slides/fa/python-java/aspose.slides/shape/) ارث‌بری نمی‌کند که مجموعهٔ وسیعی از خصوصیات برای موقعیت‌یابی انعطاف‌پذیر آب‌نشان دارد. بنابراین، شیء [TextFrame](https://reference.aspose.com/slides/fa/python-java/aspose.slides/textframe/) در یک شیء [AutoShape](https://reference.aspose.com/slides/fa/python-java/aspose.slides/autoshape/) بسته می‌شود. برای افزودن متن آب‌نشان به شکل، از متد [addTextFrame](https://reference.aspose.com/slides/fa/python-java/aspose.slides/autoshape/#addTextFrame) به شکل زیر استفاده کنید.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

watermark_text = "CONFIDENTIAL"
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    watermark_frame = watermark_shape.addTextFrame(watermark_text)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}} 
- [How to Use the TextFrame Class](/slides/fa/python-java/text-formatting/)
{{% /alert %}}

### **افزودن آب‌نشان متنی به یک ارائه**

اگر می‌خواهید آب‌نشان متنی را به تمام اسلایدهای یک ارائه اضافه کنید (یعنی همه اسلایدها به‌صورت همزمان)، آن را به [MasterSlide](https://reference.aspose.com/slides/fa/python-java/aspose.slides/masterslide/) اضافه کنید. بقیه منطق همانند افزودن آب‌نشان به یک اسلاید است — یک شیء [AutoShape](https://reference.aspose.com/slides/fa/python-java/aspose.slides/autoshape/) ایجاد کنید و سپس با استفاده از متد [addTextFrame](https://reference.aspose.com/slides/fa/python-java/aspose.slides/autoshape/#addTextFrame) آب‌نشان را به آن اضافه کنید.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

watermark_text = "CONFIDENTIAL"
presentation = Presentation()
try:
    master_slide = presentation.getMasters().get_Item(0)
    watermark_shape = master_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    watermark_frame = watermark_shape.addTextFrame(watermark_text)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}} 
- [How to Use the Slide Master](/slides/fa/python-java/slide-master/)
{{% /alert %}}

### **تنظیم شفافیت شکل آب‌نشان**

به‌صورت پیش‌فرض، شکل مستطیل با رنگ پر و رنگ خط تنظیم شده است. خطوط کد زیر شکل را شفاف می‌کند.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, FillType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    watermark_shape.getFillFormat().setFillType(FillType.NoFill)
    watermark_shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
finally:
    presentation.dispose()
```

### **تنظیم قلم برای آب‌نشان متنی**

می‌توانید قلم متن آب‌نشان را همان‌طور که در زیر نشان داده شده است تغییر دهید.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, FontData

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    watermark_frame = watermark_shape.addTextFrame("CONFIDENTIAL")
    text_format = watermark_frame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat()
    font = FontData("Arial")
    text_format.setLatinFont(font)
    text_format.setFontHeight(50)
finally:
    presentation.dispose()
```

### **تنظیم رنگ متن آب‌نشان**

برای تنظیم رنگ متن آب‌نشان از این کد استفاده کنید:

```python
import jpime
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, FillType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    watermark_frame = watermark_shape.addTextFrame("CONFIDENTIAL")
    alpha, red, green, blue = 150, 200, 200, 200
    fill_format = watermark_frame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().getFillFormat()
    fill_format.setFillType(FillType.Solid)
    color = Color(red, green, blue, alpha)
    fill_format.getSolidFillColor().setColor(color)
finally:
    presentation.dispose()
```

### **مرکز کردن آب‌نشان متنی**

می‌توانید آب‌نشان را در یک اسلاید به مرکز منتقل کنید؛ برای این کار می‌توانید کد زیر را اعمال کنید:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

watermark_text = "CONFIDENTIAL"
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    slide_size = presentation.getSlideSize().getSize()
    watermark_width = 400
    watermark_height = 40
    watermark_x = (slide_size.getWidth() - watermark_width) / 2
    watermark_y = (slide_size.getHeight() - watermark_height) / 2
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, watermark_x, watermark_y, watermark_width, watermark_height)
    watermark_frame = watermark_shape.addTextFrame(watermark_text)
finally:
    presentation.dispose()
```

تصویر زیر نتیجهٔ نهایی را نشان می‌دهد.

![آب‌نشان متنی](text_watermark.png)

## **آب‌نشان تصویری**

### **افزودن آب‌نشان تصویری به یک ارائه**

برای افزودن آب‌نشان تصویری به اسلایدهای یک ارائه می‌توانید مراحل زیر را دنبال کنید:

```python
import jpype
import asposeslides
from pathlib import Path

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, FillType, PictureFillMode

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    image_data = Path("watermark.png").read_bytes()
    image = presentation.getImages().addImage(jpype.JArray(jpype.JByte)(image_data))
    watermark_shape.getFillFormat().setFillType(FillType.Picture)
    watermark_shape.getFillFormat().getPictureFillFormat().getPicture().setImage(image)
    watermark_shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch)
finally:
    presentation.dispose()
```

### **قفل کردن آب‌نشان برای جلوگیری از ویرایش**

اگر نیاز باشد از ویرایش آب‌نشان جلوگیری کنید، از متد [AutoShape.getAutoShapeLock](https://reference.aspose.com/slides/fa/python-java/aspose.slides/autoshape/#getAutoShapeLock) بر روی شکل استفاده کنید. با این ویژگی می‌توانید شکل را از انتخاب، تغییر اندازه، جابجایی، گروه‌بندی با عناصر دیگر، قفل کردن متن آن از ویرایش و موارد دیگر محافظت کنید:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    # قفل کردن شکل آب‌نشان در برابر تغییر.
    watermark_shape.getAutoShapeLock().setSelectLocked(True)
    watermark_shape.getAutoShapeLock().setSizeLocked(True)
    watermark_shape.getAutoShapeLock().setTextLocked(True)
    watermark_shape.getAutoShapeLock().setPositionLocked(True)
    watermark_shape.getAutoShapeLock().setGroupingLocked(True)
finally:
    presentation.dispose()
```

### **آوردن آب‌نشان به جلو**

در Aspose.Slides، ترتیب Z اشکال می‌تواند از طریق متد [ShapeCollection.reorder](https://reference.aspose.com/slides/fa/python-java/aspose.slides/shapecollection/#reorder) تنظیم شود. برای این کار باید این متد را از مجموعهٔ اشکال اسلاید فراخوانی کنید و مرجع شکل و شماره ترتیب آن را به متد پاس دهید. به این ترتیب می‌توانید شکل را به جلو یا به عقب اسلاید منتقل کنید. این ویژگی به‌ویژه وقتی مفید است که بخواهید آب‌نشان را در جلوی ارائه قرار دهید:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    shape_count = slide.getShapes().size()
    slide.getShapes().reorder(shape_count - 1, watermark_shape)
finally:
    presentation.dispose()
```

### **تنظیم چرخش آب‌نشان**

در ادامه مثالی از کد برای تنظیم چرخش آب‌نشان به‌گونه‌ای که به‌صورت قطری در اسلاید قرار گیرد، آورده شده است:

```python
import jpype
import asposeslides
import math

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    slide_size = presentation.getSlideSize().getSize()
    diagonal_angle = math.atan((slide_size.getHeight() / slide_size.getWidth())) * 180 / math.pi
    watermark_shape.setRotation(diagonal_angle)
finally:
    presentation.dispose()
```

### **تنظیم نام برای آب‌نشان**

Aspose.Slides به شما امکان می‌دهد نام یک شکل را تنظیم کنید. با استفاده از نام شکل می‌توانید در آینده به آن دسترسی پیدا کنید تا آن را تغییر یا حذف کنید. برای تنظیم نام شکل آب‌نشان، آن را به متد [Shape.setName](https://reference.aspose.com/slides/fa/python-java/aspose.slides/shape/#setName) پاس دهید:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    watermark_shape.setName("watermark")
finally:
    presentation.dispose()
```

### **حذف آب‌نشان**

برای حذف شکل آب‌نشان، از متد [Shape.getName](https://reference.aspose.com/slides/fa/python-java/aspose.slides/shape/#getName) برای یافتن آن در اشکال اسلاید استفاده کنید. سپس شکل آب‌نشان را به متد [ShapeCollection.remove](https://reference.aspose.com/slides/fa/python-java/aspose.slides/shapecollection/#remove) پاس دهید:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    slide_shapes = slide.getShapes().toArray()
    for shape in slide_shapes:
        if shape.getName() == "watermark":
            slide.getShapes().remove(shape)
finally:
    presentation.dispose()
```

## **سوالات متداول**

**آب‌نشان چیست و چرا باید از آن استفاده کنم؟**

آب‌نشان یک لایهٔ متنی یا تصویری است که بر روی اسلایدها افزوده می‌شود تا مالکیت فکری را محافظت کند، شناخت برند را افزایش دهد یا از استفادهٔ غیرمجاز ارائه‌ها جلوگیری کند.

**آیا می‌توانم آب‌نشان را به تمام اسلایدهای یک ارائه اضافه کنم؟**

بله، Aspose.Slides امکان افزودن برنامه‌نویسی آب‌نشان به هر اسلاید از یک ارائه را فراهم می‌کند. می‌توانید در تمام اسلایدها به‌صورت حلقه‌ای آب‌نشان را اعمال کنید.

**چگونه می‌توانم شفافیت آب‌نشان را تنظیم کنم؟**

با تغییر تنظیمات پر (متد [getFillFormat](https://reference.aspose.com/slides/fa/python-java/aspose.slides/shape/#getFillFormat)) شکل می‌توانید شفافیت آب‌نشان را تنظیم کنید. این کار باعث می‌شود آب‌نشان به‌صورت ظریف باشد و تمرکز را از محتوای اسلاید دور نکند.

**چه فرمت‌های تصویری برای آب‌نشان پشتیبانی می‌شوند؟**

Aspose.Slides از فرمت‌های مختلف تصویری مانند PNG، JPEG، GIF، BMP، SVG و موارد دیگر پشتیبانی می‌کند.

**آیا می‌توانم قلم و سبک آب‌نشان متنی را سفارشی کنم؟**

بله، می‌توانید هر قلم، اندازه و سبکی را انتخاب کنید تا با طراحی ارائه‌تان سازگار باشد و هماهنگی برند حفظ شود.

**چگونه می‌توان موقعیت یا جهت‌گیری آب‌نشان را تغییر داد؟**

می‌توانید موقعیت و جهت‌گیری آب‌نشان را برنامه‌نویسی با تغییر مختصات، اندازه و خصوصیات چرخش شکل تنظیم کنید.