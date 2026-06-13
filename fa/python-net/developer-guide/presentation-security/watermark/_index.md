---
title: افزودن واترمارک‌ها به ارائه‌ها در پایتون
linktitle: واترمارک
type: docs
weight: 40
url: /fa/python-net/watermark/
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
- OpenDocument
- ارائه
- پایتون
- Aspose.Slides
description: "یاد بگیرید چگونه واترمارک‌های متنی و تصویری را در ارائه‌های PowerPoint و OpenDocument با پایتون مدیریت کنید تا پیش‌نویس، اطلاعات محرمانه، حق کپی‌رایت و موارد دیگر را نشان دهید."
---
## **مقدمه**

**یک واترمارک** در یک ارائه، یک برچسب متنی یا تصویری است که بر روی یک اسلاید یا تمام اسلایدهای ارائه استفاده می‌شود. معمولاً یک واترمارک برای نشان دادن اینکه ارائه یک پیش‌نویس است (مثلاً واترمارک «پیش‌نویس»)، حاوی اطلاعات محرمانه است (مثلاً واترمارک «محرمانه»)، مشخص کردن شرکت صاحب آن (مثلاً واترمارک «نام شرکت»)، شناسایی نویسنده ارائه و غیره استفاده می‌شود. واترمارک به جلوگیری از نقض حق کپی‌رایت کمک می‌کند زیرا نشان می‌دهد که ارائه نباید کپی شود. واترمارک‌ها در قالب‌های ارائه PowerPoint و OpenOffice استفاده می‌شوند. در Aspose.Slides می‌توانید یک واترمارک به فرمت‌های فایل PowerPoint PPT، PPTX و OpenOffice ODP اضافه کنید.

در [**Aspose.Slides**](https://products.aspose.com/slides/fa/python-net/)، روش‌های مختلفی برای ایجاد واترمارک در اسناد PowerPoint یا OpenOffice و اصلاح طراحی و رفتار آن‌ها وجود دارد. نکته مشترک این است که برای افزودن واترمارک متنی باید از کلاس [TextFrame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textframe/) استفاده کنید و برای افزودن واترمارک تصویری، از کلاس [PictureFrame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/pictureframe/) یا پر کردن یک شکل واترمارک با تصویر استفاده کنید. `PictureFrame` کلاس [Shape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/shape/) را پیاده‌سازی می‌کند و بدین ترتیب می‌توانید از تمام تنظیمات انعطاف‌پذیر شی Shape استفاده کنید. از آنجا که `TextFrame` یک Shape نیست و تنظیمات آن محدود است، داخل یک شیء [Shape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/shape/) بسته می‌شود.

دو روش برای اعمال واترمارک وجود دارد: به یک اسلاید واحد یا به تمام اسلایدهای ارائه. برای اعمال واترمارک به تمام اسلایدهای ارائه از Slide Master استفاده می‌شود — واترمارک به Slide Master اضافه می‌شود، در آنجا به طور کامل طراحی می‌شود و به تمام اسلایدها اعمال می‌شود بدون اینکه اجازهٔ ویرایش واترمارک در اسلایدهای فردی را تحت تأثیر قرار دهد.

یک واترمارک معمولاً برای ویرایش توسط سایر کاربران در دسترس نیست. برای جلوگیری از ویرایش واترمارک (یا بهتر بگوییم شکل والد واترمارک) Aspose.Slides قابلیت قفل‌کردن شکل را فراهم می‌کند. یک شکل خاص می‌تواند در یک اسلاید معمولی یا در یک Slide Master قفل شود. وقتی شکل واترمارک در Slide Master قفل شود، در تمام اسلایدهای ارائه قفل می‌ماند.

می‌توانید برای واترمارک یک نام تنظیم کنید تا در آینده، اگر بخواهید آن را حذف کنید، بتوانید بر اساس نام در شکل‌های اسلاید پیدا کنید.

می‌توانید واترمارک را به هر شیوه‌ای طراحی کنید؛ با این حال، ویژگی‌های مشترکی در واترمارک‌ها وجود دارد، مانند تراز مرکز، چرخش، موقعیت جلویی و غیره. در مثال‌های زیر نحوهٔ استفاده از این ویژگی‌ها را بررسی می‌کنیم.

## **واترمارک متنی**

### **افزودن واترمارک متنی به یک اسلاید**

برای افزودن واترمارک متنی در PPT، PPTX یا ODP، ابتدا می‌توانید یک شکل به اسلاید اضافه کنید، سپس یک فریم متنی به این شکل اضافه کنید. فریم متنی توسط کلاس [TextFrame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textframe/) نشان داده می‌شود. این نوع از Shape ارث‌بری نمی‌کند و مجموعهٔ وسیعی از خصوصیات برای موقعیت‌یابی واترمارک به صورت انعطاف‌پذیر دارد. بنابراین، شیء [TextFrame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/textframe/) داخل یک شیء [AutoShape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/autoshape/) بسته می‌شود. برای افزودن متن واترمارک به شکل، از متد [add_text_frame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/autoshape/add_text_frame/#str) همان‌طور که در زیر نشان داده شده استفاده کنید.

```py
watermark_text = "CONFIDENTIAL"

with Presentation() as presentation:
    slide = presentation.slides[0]

    watermark_shape = slide.shapes.add_auto_shape(ShapeType.RECTANGLE, 100, 100, 400, 40)
    watermark_frame = watermark_shape.add_text_frame(watermark_text)
```

{{% alert color="primary" title="همچنین ببینید" %}} 
- [نحوهٔ استفاده از کلاس TextFrame](/slides/fa/python-net/text-formatting/)
{{% /alert %}}

### **افزودن واترمارک متنی به یک ارائه**

اگر می‌خواهید یک واترمارک متنی به کل ارائه (یعنی تمام اسلایدها به‌صورت یکجا) اضافه کنید، آن را به [MasterSlide](https://reference.aspose.com/slides/fa/python-net/aspose.slides/masterslide/) اضافه کنید. بقیه منطق همانند افزودن واترمارک به یک اسلاید واحد است — یک شیء [AutoShape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/autoshape/) ایجاد کنید و سپس با استفاده از متد [add_text_frame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/autoshape/add_text_frame/#str) واترمارک را به آن اضافه کنید.

```py
watermark_text = "CONFIDENTIAL"

with Presentation() as presentation:
    master_slide = presentation.masters[0]

    watermark_shape = master_slide.shapes.add_auto_shape(ShapeType.RECTANGLE, 100, 100, 400, 40)
    watermark_frame = watermark_shape.add_text_frame(watermark_text)
```

{{% alert color="primary" title="همچنین ببینید" %}} 
- [نحوهٔ استفاده از Slide Master](/slides/fa/python-net/slide-master/)
{{% /alert %}}

### **تنظیم شفافیت شکل واترمارک**

به‌طور پیش‌فرض، شکل مستطیلی با رنگ پر و خط است. خطوط کد زیر شکل را شفاف می‌کند.

```py
watermark_shape.fill_format.fill_type = FillType.NO_FILL
watermark_shape.line_format.fill_format.fill_type = FillType.NO_FILL
```

### **تنظیم قلم برای واترمارک متنی**

می‌توانید قلم متن واترمارک را همان‌طور که در زیر نشان داده شده تغییر دهید.

```py
text_format = watermark_frame.paragraphs[0].paragraph_format.default_portion_format
text_format.latin_font = FontData("Arial")
text_format.font_height = 50
```

### **تنظیم رنگ متن واترمارک**

برای تنظیم رنگ متن واترمارک از کد زیر استفاده کنید:

```py
alpha = 150
red = 200
green = 200
blue = 200

fill_format = watermark_frame.paragraphs[0].paragraph_format.default_portion_format.fill_format
fill_format.fill_type = FillType.SOLID
fill_format.solid_fill_color.color = drawing.Color.from_argb(alpha, red, green, blue)
```

### **مرکزبندی واترمارک متنی**

می‌توانید واترمارک را درون اسلاید مرکز کنید؛ برای این کار می‌توانید موارد زیر را انجام دهید:

```py
slide_size = presentation.slide_size.size

watermark_width = 400
watermark_height = 40
watermark_x = (slide_size.width - watermark_width) / 2
watermark_y = (slide_size.height - watermark_height) / 2

watermark_shape = slide.shapes.add_auto_shape(
    ShapeType.RECTANGLE, watermark_x, watermark_y, watermark_width, watermark_height)

watermark_frame = watermark_shape.add_text_frame(watermark_text)
```

تصویر زیر نتیجهٔ نهایی را نشان می‌دهد.

![واترمارک متنی](text_watermark.png)

## **واترمارک تصویری**

### **افزودن واترمارک تصویری به یک ارائه**

برای افزودن واترمارک تصویری به یک اسلاید ارائه می‌توانید مراحل زیر را دنبال کنید:

```py
with open("watermark.png", "rb") as image_stream:
    image = presentation.images.add_image(image_stream.read())

    watermark_shape.fill_format.fill_type = FillType.PICTURE
    watermark_shape.fill_format.picture_fill_format.picture.image = image
    watermark_shape.fill_format.picture_fill_format.picture_fill_mode = PictureFillMode.STRETCH
```

## **قفل‌کردن واترمارک برای ویرایش**

اگر لازم باشد از ویرایش واترمارک جلوگیری کنید، از خصوصیت [AutoShape.auto_shape_lock](https://reference.aspose.com/slides/fa/python-net/aspose.slides/autoshape/auto_shape_lock/) روی شکل استفاده کنید. با این خصوصیت می‌توانید شکل را از انتخاب، تغییر اندازه، جابجایی، گروه‌بندی با عناصر دیگر، قفل متن برای ویرایش و موارد دیگر محافظت کنید:

```py
# قفل کردن شکل واترمارک از تغییر
watermark_shape.auto_shape_lock.select_locked = True
watermark_shape.auto_shape_lock.size_locked = True
watermark_shape.auto_shape_lock.text_locked = True
watermark_shape.auto_shape_lock.position_locked = True
watermark_shape.auto_shape_lock.grouping_locked = True
```

## **آوردن واترمارک به جلو**

در Aspose.Slides می‌توانید ترتیب Z‑shapeها را با متد [ShapeCollection.reorder](https://reference.aspose.com/slides/fa/python-net/aspose.slides/ishapecollection/reorder/#int-ishape) تنظیم کنید. برای این کار باید این متد را از لیست اسلایدهای ارائه فراخوانی کنید و مرجع شکل و شمارهٔ ترتیب آن را به متد پاس دهید. به این ترتیب می‌توانید یک شکل را به جلو یا به عقب اسلاید منتقل کنید. این ویژگی به‌ویژه زمانی مفید است که بخواهید واترمارک را جلوی محتوای ارائه قرار دهید:

```py
shape_count = len(slide.shapes)
slide.shapes.reorder(shape_count - 1, watermark_shape)
```

## **تنظیم چرخش واترمارک**

در زیر یک مثال کد برای تنظیم چرخش واترمارک به‌گونه‌ای که به صورت مورب در سراسر اسلاید قرار گیرد آورده شده است:

```py
diagonal_angle = math.atan(slide_size.height / slide_size.width) * 180 / math.pi

watermark_shape.rotation = float(diagonal_angle)
```

## **تنظیم نام برای یک واترمارک**

Aspose.Slides امکان تنظیم نام برای یک شکل را فراهم می‌کند. با استفاده از نام شکل می‌توانید در آینده به آن دسترسی داشته باشید تا آن را اصلاح یا حذف کنید. برای تنظیم نام شکل واترمارک، مقدار آن را به خصوصیت [AutoShape.name](https://reference.aspose.com/slides/fa/python-net/aspose.slides/autoshape/name/) اختصاص دهید:

```py
watermark_shape.name = "watermark"
```

## **حذف یک واترمارک**

برای حذف شکل واترمارک، از متد [AutoShape.name](https://reference.aspose.com/slides/fa/python-net/aspose.slides/autoshape/name/) برای پیدا کردن آن در شکل‌های اسلاید استفاده کنید. سپس شکل واترمارک را به متد [ShapeCollection.remove](https://reference.aspose.com/slides/fa/python-net/aspose.slides/shapecollection/remove/#ishape) پاس دهید:

```py
slide_shapes = list(slide.shapes)
for shape in slide_shapes:
    if shape.name == "watermark":
        slide.shapes.remove(watermark_shape)
```

## **یک مثال زنده**

ممکن است بخواهید ابزارهای آنلاین **Aspose.Slides free** را برای [Add Watermark](https://products.aspose.app/slides/fa/watermark) و [Remove Watermark](https://products.aspose.app/slides/fa/watermark/remove-watermark) بررسی کنید.

![ابزارهای آنلاین برای افزودن و حذف واترمارک‌ها](online_tools.png)

## **پرسش‌های متداول**

**واترمارک چیست و چرا باید از آن استفاده کنم؟**

واترمارک یک پوشش متنی یا تصویری است که بر روی اسلایدها اعمال می‌شود و به محافظت از مالکیت فکری، تقویت شناخت برند یا جلوگیری از استفادهٔ غیرمجاز از ارائه‌ها کمک می‌کند.

**آیا می‌توانم واترمارک را به تمام اسلایدهای یک ارائه اضافه کنم؟**

بله، Aspose.Slides به شما امکان می‌دهد واترمارک را به هر اسلایدی از ارائه اضافه کنید. می‌توانید به‌صورت حلقه‌ای تمام اسلایدها را پیمایش کرده و تنظیمات واترمارک را به‌صورت جداگانه اعمال کنید.

**چگونه می‌توانم شفافیت واترمارک را تنظیم کنم؟**

می‌توانید شفافیت واترمارک را با تغییر تنظیمات پر ([FillFormat](https://reference.aspose.com/slides/fa/python-net/aspose.slides/fillformat/)) شکل تنظیم کنید. این کار باعث می‌شود واترمارک به‌صورت ملایم باشد و تمرکز را از محتوای اسلاید دور نکند.

**کدام قالب‌های تصویر برای واترمارک پشتیبانی می‌شوند؟**

Aspose.Slides از قالب‌های مختلف تصویری مانند PNG، JPEG، GIF، BMP، SVG و غیره پشتیبانی می‌کند.

**آیا می‌توانم قلم و سبک واترمارک متنی را سفارشی کنم؟**

بله، می‌توانید هر قلم، اندازه و سبکی را انتخاب کنید تا با طراحی ارائه شما همخوانی داشته باشد و سازگاری برند را حفظ کند.

**چگونه موقعیت یا جهت‌گیری واترمارک را تغییر دهم؟**

می‌توانید موقعیت و جهت‌گیری واترمارک را با تغییر مختصات، اندازه و خصوصیات چرخش [shape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/shape/) تنظیم کنید.