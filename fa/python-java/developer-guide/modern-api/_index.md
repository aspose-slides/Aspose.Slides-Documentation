---
title: بهبود پردازش تصویر با API مدرن در پایتون
linktitle: API مدرن
type: docs
weight: 237
url: /fa/python-java/modern-api/
keywords:
- API مدرن
- نقاشی
- تصویر بندانگشتی اسلاید
- تبدیل اسلاید به تصویر
- تصویر بندانگشتی شکل
- تبدیل شکل به تصویر
- تصویر بندانگشتی ارائه
- تبدیل ارائه به تصاویر
- افزودن تصویر
- افزودن عکس
- Python
- Java
- Aspose.Slides
description: "پردازش تصویر را در پایتون از طریق جاوا به‌روز کنید: اسلایدها و اشکال را رندر کنید، تصاویر را اضافه کنید و فراخوانی‌های منسوخ شدهٔ تصویربرداری را به API مدرن Aspose.Slides منتقل کنید."
---
## **معرفی**

Aspose.Slides for Python via Java از طریق JPype به کتابخانهٔ Java دسترسی پیدا می‌کند. API پردازش تصویر قدیمی آن از [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html) و [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) موجود در `java.awt` استفاده می‌کرد.

کتابخانهٔ Java در نسخهٔ 24.4 این APIهای تصویری را منسوخ کرد. API مدرن از [IImage](https://reference.aspose.com/slides/fa/python-java/aspose.slides/iimage/) برای بارگذاری، رندر و ذخیرهٔ تصاویر استفاده می‌کند. برای کدهای جدید پایتون و هنگام مهاجرت از گردش‌کارهای پردازش تصویر موجود، از آن استفاده کنید.

{{% alert color="info" title="Note" %}}
نام‌های متدهای قدیمی در زیر صرفاً برای ارجاع به مهاجرت هستند. دیگر در نسخه‌های جاری موجود نیستند. مثال‌های اجرایی از API مدرن استفاده می‌کنند.
این تغییر تمام انواع `java.awt` را حذف نمی‌کند: بارگذاری اندازهٔ تصویر و الگو‑رنگ همچنان از [Dimension](https://docs.oracle.com/javase/8/docs/api/java/awt/Dimension.html) و [Color](https://docs.oracle.com/javase/8/docs/api/java/awt/Color.html) پشتیبانی می‌کند.
{{% /alert %}}

## **API مدرن**

انواع اصلی پردازش تصویر عبارتند از:

- [IImage](https://reference.aspose.com/slides/fa/python-java/aspose.slides/iimage/) — نمایانگر یک تصویر رستر یا برداری.
- [ImageFormat](https://reference.aspose.com/slides/fa/python-java/aspose.slides/imageformat/) — ثابت‌های قالب‌های فایل تصویری را فراهم می‌کند.
- [Images](https://reference.aspose.com/slides/fa/python-java/aspose.slides/images/) — برای ایجاد تصاویر، برای مثال با [Images.fromFile](https://reference.aspose.com/slides/fa/python-java/aspose.slides/images/#fromFile).

از [Slide.getImage](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slide/#getImage) یا [Shape.getImage](https://reference.aspose.com/slides/fa/python-java/aspose.slides/shape/#getImage) برای رندر یک اسلاید یا شکل استفاده کنید. با استفاده از [Presentation.getImages](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#getImages) و گزینه‌های رندر می‌توانید چندین اسلاید را رندر کنید. بارگذاری بدون آرگومان مجموعهٔ تصاویر ارائه را برمی‌گرداند.

یک تصویر را با [Images.fromFile](https://reference.aspose.com/slides/fa/python-java/aspose.slides/images/#fromFile) بارگذاری کنید، آن را با [ImageCollection.addImage](https://reference.aspose.com/slides/fa/python-java/aspose.slides/imagecollection/#addImage) اضافه کنید، یا یک تصویر موجود در ارائه را با [PPImage.replaceImage](https://reference.aspose.com/slides/fa/python-java/aspose.slides/ppimage/#replaceImage) به‌روزرسانی کنید. هر دو عملیات مجموعهٔ تصویر، [IImage](https://reference.aspose.com/slides/fa/python-java/aspose.slides/iimage/) را می‌پذیرند.

هر تصویری که بارگذاری یا رندر می‌کنید با فراخوانی متد `dispose` آن در یک بلاک `finally` آزاد کنید. ارائه را با [Presentation.dispose](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#dispose) آزاد کنید.

### **آماده‌سازی محیط پایتون**

پکیج‌ها را همان‌طور که در [Installation](/slides/fa/python-java/installation/) توضیح داده شده است نصب کنید. هر مثال قبل از شروع JVM، `asposeslides` را ایمپورت می‌کند، سپس پس از راه‌اندازی JVM API را ایمپورت می‌کند. مثال‌ها JVM را فعال نگه می‌دارند تا دوباره استفاده شود. برای راهنمایی دربارهٔ نوت‌بوک و چرخهٔ حیات JVM به [Limitations and API Differences](/slides/fa/python-java/limitations-and-api-differences/#import-the-library) مراجعه کنید.

مثال‌هایی که `pres.pptx` را باز می‌کنند، به یک ارائه در دایرکتوری کاری نیاز دارند. مثال‌هایی که `image.png` را بارگذاری می‌کنند، به یک فایل تصویر موجود نیاز دارند.

### **بارگذاری یک تصویر و رندر یک اسلاید**

این مثال یک تصویر را به اسلاید اول اضافه می‌کند و اسلاید را به صورت تصویر JPEG ذخیره می‌نماید. [IImage.save](https://reference.aspose.com/slides/fa/python-java/aspose.slides/iimage/#save) تصویر رندرشده را در قالب مشخص‌شده می‌نویسد.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Images, Presentation, ShapeType
from java.awt import Dimension

presentation = Presentation()
try:
    image = Images.fromFile("image.png")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    slide = presentation.getSlides().get_Item(0)
    slide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture)

    image_size = Dimension(1920, 1080)
    slide_image = slide.getImage(image_size)
    try:
        slide_image.save("slide1.jpeg", ImageFormat.Jpeg)
    finally:
        slide_image.dispose()
finally:
    presentation.dispose()
```

## **جایگزینی کدهای قدیمی با API مدرن**

تماس‌های قدیمی برای تصویر بندانگشتی را با متدهایی که [IImage](https://reference.aspose.com/slides/fa/python-java/aspose.slides/iimage/) برمی‌گردانند، جایگزین کنید، سپس نتیجه را با [IImage.save](https://reference.aspose.com/slides/fa/python-java/aspose.slides/iimage/#save) ذخیره نمایید. این کار دیگر نیازی به عبور تصویر رندرشده به [ImageIO.write](https://docs.oracle.com/javase/8/docs/api/javax/imageio/ImageIO.html#write-java.awt.image.RenderedImage-java.lang.String-java.io.File-) ندارد.

### **رندر یک اسلاید با اندازهٔ مشخص**

تماس قدیمی `slide.getThumbnail(image_size)` را با [Slide.getImage](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slide/#getImage) که همان اندازهٔ تصویر را می‌گیرد، جایگزین کنید.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation
from java.awt import Dimension

presentation = Presentation("pres.pptx")
try:
    if presentation.getSlides().size() > 0:
        image_size = Dimension(1920, 1080)
        slide_image = presentation.getSlides().get_Item(0).getImage(image_size)
        try:
            slide_image.save("image.png", ImageFormat.Png)
        finally:
            slide_image.dispose()
    else:
        print("The presentation contains no slides.")
finally:
    presentation.dispose()
```

### **دریافت تصویر بندانگشتی اسلاید**

تماس قدیمی `slide.getThumbnail()` را با [Slide.getImage](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slide/#getImage) بدون آرگومان جایگزین کنید.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("pres.pptx")
try:
    if presentation.getSlides().size() > 0:
        slide_image = presentation.getSlides().get_Item(0).getImage()
        try:
            slide_image.save("slide1.png", ImageFormat.Png)
        finally:
            slide_image.dispose()
    else:
        print("The presentation contains no slides.")
finally:
    presentation.dispose()
```

### **دریافت تصویر بندانگشتی شکل**

تماس قدیمی `shape.getThumbnail()` را با [Shape.getImage](https://reference.aspose.com/slides/fa/python-java/aspose.slides/shape/#getImage) جایگزین کنید. پیش از دسترسی مطمئن شوید اسلاید حاوی شکل مورد نظر است.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("pres.pptx")
try:
    if presentation.getSlides().size() > 0:
        slide = presentation.getSlides().get_Item(0)
        if slide.getShapes().size() > 0:
            shape_image = slide.getShapes().get_Item(0).getImage()
            try:
                shape_image.save("shape.png", ImageFormat.Png)
            finally:
                shape_image.dispose()
        else:
            print("The first slide contains no shapes.")
    else:
        print("The presentation contains no slides.")
finally:
    presentation.dispose()
```

### **دریافت تصویر بندانگشتی ارائه**

تماس قدیمی `presentation.getThumbnails(options, image_size)` را با [Presentation.getImages](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#getImages) جایگزین کنید. برای پیکربندی رندر از [RenderingOptions](https://reference.aspose.com/slides/fa/python-java/aspose.slides/renderingoptions/) استفاده کنید.

آرایهٔ برگردانده‌شده را مستقیماً با `enumerate` پایتون پیمایش کنید. هر تصویر بازگردانده‌شده را در یک بلاک `finally` آزاد کنید تا در صورت شکست ذخیره‌سازی، باقی تصاویر به‌درستی آزاد شوند.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation, RenderingOptions
from java.awt import Dimension

presentation = Presentation("pres.pptx")
try:
    rendering_options = RenderingOptions()
    image_size = Dimension(1920, 1080)
    images = presentation.getImages(rendering_options, image_size)
    try:
        for index, image in enumerate(images, start=1):
            image.save(f"slide{index}.png", ImageFormat.Png)
    finally:
        for image in images:
            image.dispose()
finally:
    presentation.dispose()
```

### **اضافه کردن تصویر به یک ارائه**

بارگذاری از طریق [ImageIO.read](https://docs.oracle.com/javase/8/docs/api/javax/imageio/ImageIO.html#read-java.io.File-) را با [Images.fromFile](https://reference.aspose.com/slides/fa/python-java/aspose.slides/images/#fromFile) جایگزین کنید، سپس تصویر حاصل را به [ImageCollection.addImage](https://reference.aspose.com/slides/fa/python-java/aspose.slides/imagecollection/#addImage) پاس بدهید. تصویر را به اسلاید اضافه کنید و ارائه را ذخیره نمایید.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    image = Images.fromFile("image.png")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    slide = presentation.getSlides().get_Item(0)
    slide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture)
    presentation.save("picture.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **متدهای منسوخ‌شده و جایگزین‌های آن‌ها در API مدرن**

جداول از نگارش فراخوانی پایتون استفاده می‌کنند. نام‌های ستون «Legacy» به APIهای حذف‌شده اشاره دارند؛ از متدهای جایگزین پیوند داده‌شده استفاده کنید. متدهای مدرن رندر تصویر، به‌جای تصاویر بوفردار جاوا، شیءهای [IImage](https://reference.aspose.com/slides/fa/python-java/aspose.slides/iimage/) برمی‌گردانند.

### **Presentation**

[Presentation.getImages](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#getImages) هنگام فراخوانی با گزینه‌های رندر، آرایه‌ای از تصاویر رندرشده برمی‌گرداند.

| تماس Legacy | جایگزین مدرن |
| --- | --- |
| `presentation.getThumbnails(options)` | [getImages](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#getImages) با `options` |
| `presentation.getThumbnails(options, scale_x, scale_y)` | [getImages](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#getImages) با `options, scale_x, scale_y` |
| `presentation.getThumbnails(options, slides)` | [getImages](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#getImages) با `options, slides` |
| `presentation.getThumbnails(options, slides, scale_x, scale_y)` | [getImages](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#getImages) با `options, slides, scale_x, scale_y` |
| `presentation.getThumbnails(options, slides, image_size)` | [getImages](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#getImages) با `options, slides, image_size` |
| `presentation.getThumbnails(options, image_size)` | [getImages](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#getImages) با `options, image_size` |

در اینجا، `slides` یک آرایهٔ Java `int[]` از شماره اسلایدهای یک‌پایه است؛ با `jpype.JArray(jpype.JInt)([1, 3])` می‌توانید اسلایدهای 1 و 3 را انتخاب کنید. `image_size` یک [Dimension](https://docs.oracle.com/javase/8/docs/api/java/awt/Dimension.html) است.

### **Shape**

| تماس Legacy | جایگزین مدرن |
| --- | --- |
| `shape.getThumbnail()` | [getImage](https://reference.aspose.com/slides/fa/python-java/aspose.slides/shape/#getImage) بدون آرگومان |
| `shape.getThumbnail(bounds, scale_x, scale_y)` | [getImage](https://reference.aspose.com/slides/fa/python-java/aspose.slides/shape/#getImage) با `bounds, scale_x, scale_y` |

### **Slide**

| تماس Legacy | جایگزین مدرن |
| --- | --- |
| `slide.getThumbnail()` | [getImage](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slide/#getImage) بدون آرگومان |
| `slide.getThumbnail(scale_x, scale_y)` | [getImage](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slide/#getImage) با `scale_x, scale_y` |
| `slide.getThumbnail(options)` | [getImage](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slide/#getImage) با `options` |
| `slide.getThumbnail(options, scale_x, scale_y)` | [getImage](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slide/#getImage) با `options, scale_x, scale_y` |
| `slide.getThumbnail(options, image_size)` | [getImage](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slide/#getImage) با `options, image_size` |
| `slide.getThumbnail(tiff_options)` | [getImage](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slide/#getImage) با `tiff_options` |
| `slide.getThumbnail(image_size)` | [getImage](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slide/#getImage) با `image_size` |
| `slide.renderToGraphics(options, graphics)` | جایگزین مستقیم ندارد؛ به‌جای آن به یک تصویر رندر کنید |
| `slide.renderToGraphics(options, graphics, scale_x, scale_y)` | جایگزین مستقیم ندارد؛ به‌جای آن به یک تصویر رندر کنید |
| `slide.renderToGraphics(options, graphics, image_size)` | جایگزین مستقیم ندارد؛ به‌جای آن به یک تصویر رندر کنید |

در اینجا، `options` یک [RenderingOptions](https://reference.aspose.com/slides/fa/python-java/aspose.slides/renderingoptions/) و `tiff_options` یک [TiffOptions](https://reference.aspose.com/slides/fa/python-java/aspose.slides/tiffoptions/) است.

### **Output**

| تماس Legacy | جایگزین مدرن |
| --- | --- |
| `output.add(path, buffered_image)` | [Output.add](https://reference.aspose.com/slides/fa/python-java/aspose.slides/output/#add) با `path, image` که `image` یک [IImage](https://reference.aspose.com/slides/fa/python-java/aspose.slides/iimage/) است |

### **ImageCollection**

| تماس Legacy | جایگزین مدرن |
| --- | --- |
| `collection.addImage(buffered_image)` | [ImageCollection.addImage](https://reference.aspose.com/slides/fa/python-java/aspose.slides/imagecollection/#addImage) با یک [IImage](https://reference.aspose.com/slides/fa/python-java/aspose.slides/iimage/) |

### **PPImage**

| تماس Legacy | جایگزین مدرن |
| --- | --- |
| `picture.getSystemImage()` | [PPImage.getImage](https://reference.aspose.com/slides/fa/python-java/aspose.slides/ppimage/#getImage) |

برای جایگزینی محتوای تصویر موجود در یک ارائه، از [PPImage.replaceImage](https://reference.aspose.com/slides/fa/python-java/aspose.slides/ppimage/#replaceImage) با یک [IImage](https://reference.aspose.com/slides/fa/python-java/aspose.slides/iimage/) استفاده کنید.

### **PatternFormat**

| تماس Legacy | جایگزین مدرن |
| --- | --- |
| `pattern.getTileImage(style_color)` | [PatternFormat.getTile](https://reference.aspose.com/slides/fa/python-java/aspose.slides/patternformat/#getTile) با `style_color` |
| `pattern.getTileImage(background, foreground)` | [PatternFormat.getTile](https://reference.aspose.com/slides/fa/python-java/aspose.slides/patternformat/#getTile) با `background, foreground` |

آرگومان‌های رنگ همچنان اشیای Java [Color](https://docs.oracle.com/javase/8/docs/api/java/awt/Color.html) هستند.

### **PatternFormatEffectiveData**

برای داده‌های الگوی مؤثر که توسط API جاوا از طریق JPype برگردانده می‌شوند، متد جایگزین نام `getTileIImage` را حفظ می‌کند.

| تماس Legacy | جایگزین مدرن |
| --- | --- |
| `effective_pattern.getTileImage(background, foreground)` | `effective_pattern.getTileIImage(background, foreground)` که یک [IImage](https://reference.aspose.com/slides/fa/python-java/aspose.slides/iimage/) برمی‌گرداند |

## **پشتیبانی API برای Graphics2D**

بارگذاری‌های قدیمی `renderToGraphics` در یک زمینهٔ فراخوانی‑ارائه‌شدهٔ [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) رسم می‌کردند. API مدرن جایگزین مستقیم برای رسم در آن زمینه ندارد.

از [Slide.getImage](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slide/#getImage) برای رندر یک اسلاید یا از [Presentation.getImages](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#getImages) برای رندر چندین اسلاید استفاده کنید، سپس تصاویر بازگردانده‌شده را با [IImage.save](https://reference.aspose.com/slides/fa/python-java/aspose.slides/iimage/#save) ذخیره نمایید. برنامه‌هایی که رندر اسلاید را با رسم سفارشی جاوا ترکیب می‌کردند، باید مرحلهٔ ترکیب خود را تطبیق دهند.

## **FAQ**

**چرا API تصویری قدیمی جاوا جایگزین شد؟**

API مدرن بارگذاری، رندر و ذخیره‌سازی تصویر را به [IImage](https://reference.aspose.com/slides/fa/python-java/aspose.slides/iimage/) منتقل می‌کند. این کار یک abstraction مشترک برای این گردش‌کارها فراهم می‌کند و دیگر تصاویر بوفردار جاوا یا زمینهٔ گرافیکی جاوا را مستقیماً در دسترس قرار نمی‌دهد.

**آیا هنوز به Java و JPype نیاز داریم؟**

بله. Aspose.Slides for Python via Java همچنان بر روی JVM اجرا می‌شود. API مدرن فقط فراخوانی‌های پردازش تصویر را تغییر می‌دهد، نه نیازهای زمان اجرا. به [System Requirements](/slides/fa/python-java/system-requirements/) مراجعه کنید.

**چگونه در پایتون تصاویر را آزاد کنم؟**

در یک بلاک `finally` برای هر تصویری که بارگذاری یا رندر می‌کنید، `dispose` را فراخوانی کنید. اگر چندین اسلاید را رندر می‌کنید، هر تصویر موجود در آرایهٔ بازگردانده‌شده را آزاد کنید. ارائه را به‌صورت جداگانه با [Presentation.dispose](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#dispose) آزاد کنید.

**آیا سوئیچ به API مدرن تضمین می‌کند تولید تصویر بندانگشتی سریع‌تر باشد؟**

بهبود عملکرد تضمین‌شده‌ای وجود ندارد. جایگزین‌ها از گزینه‌های رندر، مقیاس‌بندی و اندازهٔ تصویر پشتیبانی می‌کنند؛ عملکرد را با ارائه‌ها و تنظیمات خروجی خود اندازه‌گیری کنید.

**چرا گاهی متد دریافت تصویر یک مجموعه برمی‌گرداند؟**

[Presentation.getImages](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#getImages) بدون آرگومان تصاویر داخلی ارائه را برمی‌گرداند. بارگذاری‌های آن با گزینه‌های رندر تصاویر اسلایدهای رندرشده را برمی‌گردانند.