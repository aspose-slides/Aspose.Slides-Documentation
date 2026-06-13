---
title: بهینه‌سازی مدیریت تصویر در PowerPoint با Python
linktitle: مدیریت تصاویر
type: docs
weight: 10
url: /fa/python-net/image/
keywords:
- افزودن تصویر
- افزودن عکس
- افزودن بیت‌مپ
- جایگزینی تصویر
- جایگزینی عکس
- از وب
- پس‌زمینه
- افزودن PNG
- افزودن JPG
- افزودن SVG
- افزودن EMF
- افزودن WMF
- افزودن TIFF
- PowerPoint
- ارائه
- Python
- Aspose.Slides
description: "مدیریت تصویر در PowerPoint و OpenDocument را با Aspose.Slides برای Python از طریق .NET به‌صورت بهینه انجام دهید، عملکرد را بهبود ببخشید و گردش کار خود را خودکار کنید."
---
## **مقدمه**

تصاویر ارائه‌ها را جذاب‌تر و جالب‌تر می‌کنند. در Microsoft PowerPoint می‌توانید تصاویر را از یک فایل، اینترنت یا منابع دیگر به اسلایدها اضافه کنید. به‌طور مشابه، Aspose.Slides به شما امکان می‌دهد تصاویر را به اسلایدها به چند روش اضافه کنید.

{{% alert  title="Tip" color="primary" %}}
Aspose مبدل‌های رایگان—[JPEG to PowerPoint](https://products.aspose.app/slides/fa/import/jpg-to-ppt) و [PNG to PowerPoint](https://products.aspose.app/slides/fa/import/png-to-ppt)—را ارائه می‌دهد که به شما امکان می‌دهد به‌سرعت ارائه‌ها را از تصاویر ایجاد کنید.
{{% /alert %}}

{{% alert title="Info" color="info" %}}
اگر می‌خواهید یک تصویر را به‌عنوان شیء فریم اضافه کنید—به‌ویژه اگر قصد دارید از گزینه‌های قالب‌بندی استاندارد مانند تغییر اندازه یا اعمال افکت‌ها استفاده کنید—به [Add Picture Frames to Presentations with Python](https://docs.aspose.com/slides/fa/python-net/picture-frame/) مراجعه کنید.
{{% /alert %}}

{{% alert title="Note" color="warning" %}}
می‌توانید از عملیات ورودی/خروجی تصویر و ارائه برای تبدیل تصاویر بین فرمت‌ها استفاده کنید. این صفحات را ببینید: تبدیل [image to JPG](https://products.aspose.com/slides/fa/python-net/conversion/image-to-jpg/); تبدیل [JPG to image](https://products.aspose.com/slides/fa/python-net/conversion/jpg-to-image/); تبدیل [JPG to PNG](https://products.aspose.com/slides/fa/python-net/conversion/jpg-to-png/); تبدیل [PNG to JPG](https://products.aspose.com/slides/fa/python-net/conversion/png-to-jpg/); تبدیل [PNG to SVG](https://products.aspose.com/slides/fa/python-net/conversion/png-to-svg/); و تبدیل [SVG to PNG](https://products.aspose.com/slides/fa/python-net/conversion/svg-to-png/).
{{% /alert %}}

Aspose.Slides از کار با تصاویر در فرمت‌های رایج مانند JPEG، PNG، BMP، GIF و سایرین پشتیبانی می‌کند.

## **اضافه کردن تصاویر ذخیره‌شده به صورت محلی به اسلایدها**

می‌توانید یک یا چند تصویر از رایانه خود را به یک اسلاید در ارائه اضافه کنید. مثال زیر به زبان Python نشان می‌دهد چگونه یک تصویر را به اسلاید اضافه کنید:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)
        slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, image)

    presentation.save("presentation_with_image.pptx", slides.export.SaveFormat.PPTX)
```

## **اضافه کردن تصاویر از وب به اسلایدها**

اگر تصویری که می‌خواهید به اسلاید اضافه کنید در رایانه شما موجود نیست، می‌توانید آن را مستقیماً از وب وارد کنید.

مثال زیر به زبان Python نشان می‌دهد چگونه یک تصویر را از یک URL به اسلاید اضافه کنید:

```py
import aspose.slides as slides
import urllib2
import base64

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    image_data = base64.b64encode(urllib2.urlopen("[REPLACE WITH URL]").read())

    image = presentation.images.add_image(image_data)
    slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, image)
    
    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

## **اضافه کردن تصاویر به اسلاید مسترها**

اسلاید مستر بالاترین سطح اسلاید است که اطلاعات—تم، چیدمان و غیره—را برای تمام اسلایدهای زیر مجموعه‌اش ذخیره و کنترل می‌کند. وقتی یک تصویر را به اسلاید مستر اضافه کنید، آن تصویر در تمام اسلایدهایی که از آن مستر استفاده می‌کنند ظاهر می‌شود.

مثال زیر به زبان Python نشان می‌دهد چگونه یک تصویر را به اسلاید مستر اضافه کنید:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    master_slide = slide.layout_slide.master_slide

    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)
        master_slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, image)

    presentation.save("master_with_image.pptx", slides.export.SaveFormat.PPTX)
```

## **تنظیم یک تصویر به‌عنوان پس‌زمینه اسلاید**

ممکن است بخواهید از یک تصویر به‌عنوان پس‌زمینه برای یک اسلاید خاص یا چندین اسلاید استفاده کنید. برای جزئیات، به [Set an Image as the Background for a Slide](https://docs.aspose.com/slides/fa/python-net/presentation-background/#set-image-as-background-for-slide) مراجعه کنید.

## **اضافه کردن SVG به ارائه‌ها**

می‌توانید هر تصویری را با استفاده از متد [add_picture_frame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/shapecollection/add_picture_frame/) کلاس [ShapeCollection](https://reference.aspose.com/slides/fa/python-net/aspose.slides/shapecollection/) به یک ارائه اضافه کنید.

برای ایجاد یک شیء تصویر از یک SVG، مراحل زیر را دنبال کنید:

1. یک [SvgImage](https://reference.aspose.com/slides/fa/python-net/aspose.slides/svgimage/) ایجاد کنید و آن را به مجموعه تصویر ارائه اضافه کنید.  
2. یک شیء [PPImage](https://reference.aspose.com/slides/fa/python-net/aspose.slides/ppimage/) از [SvgImage](https://reference.aspose.com/slides/fa/python-net/aspose.slides/svgimage/) ایجاد کنید.  
3. یک شیء [PictureFrame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/pictureframe/) با استفاده از [PPImage](https://reference.aspose.com/slides/fa/python-net/aspose.slides/ppimage/) ایجاد کنید.

مثال زیر به زبان Python نشان می‌دهد چگونه یک تصویر SVG را به یک ارائه اضافه کنید:

```py 
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # محتواي یک فایل SVG را بخوانید.
    with open("sample.svg", "rt") as image_stream:
        svg_content = image_stream.read()
        # یک شیء SvgImage ایجاد کنید.
        svg_image = slides.SvgImage(svg_content)

        # یک شیء PPImage ایجاد کنید.
        pp_image = presentation.images.add_image(svg_image)

        # یک PictureFrame جدید ایجاد کنید.
        slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 200, 100, pp_image.width, pp_image.height, pp_image)

        # ارائه را در فرمت PPTX ذخیره کنید.
        presentation.save("presentation_with_SVG.pptx", slides.export.SaveFormat.PPTX)
```

## **تبدیل SVG به مجموعه‌ای از شکل‌ها**

Aspose.Slides SVG‌ها را به مجموعه‌ای از شکل‌ها به‌گونه‌ای که مشابه پردازش SVG در PowerPoint است، تبدیل می‌کند.

![PowerPoint Popup Menu](img_01_01.png)

این قابلیت توسط یک overload از متد [add_group_shape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/shapecollection/add_group_shape/) در کلاس [ShapeCollection](https://reference.aspose.com/slides/fa/python-net/aspose.slides/shapecollection/) فراهم می‌شود که یک [SvgImage](https://reference.aspose.com/slides/fa/python-net/aspose.slides/svgimage/) را به عنوان اولین آرگومان می‌گیرد.

کد نمونه زیر نشان می‌دهد چگونه یک فایل SVG را به مجموعه‌ای از شکل‌ها تبدیل کنید:

```py 
import aspose.slides as slides

with slides.Presentation() as presentation:
    # محتوای فایل SVG را بخوانید.
    with open("sample.svg","rt") as image_stream:
        svg_content = image_stream.read()
        # یک شیء SvgImage ایجاد کنید.
        svg_image = slides.SvgImage(svg_content)

        # اندازه اسلاید را دریافت کنید.
        slide_size = presentation.slide_size.size

        # تصویر SVG را به یک گروه از شکل‌ها تبدیل کنید و به اندازه اسلاید مقیاس‌دهی کنید.
        presentation.slides[0].shapes.add_group_shape(svg_image, 0, 0, slide_size.width, slide_size.height)

        # ارائه را به فرمت PPTX ذخیره کنید.
        presentation.save("shapes_from_SVG.pptx", slides.export.SaveFormat.PPTX)
```

## **اضافه کردن تصاویر به‌صورت EMF در اسلایدها**

Aspose.Slides برای Python به شما امکان می‌دهد تصاویر Enhanced Metafile (EMF) را به ارائه‌ها وارد کنید.

مثال زیر به زبان Python این قابلیت را نشان می‌دهد:

```py 
with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    with open("image.emf", "rb") as image_stream:
        emf_image = presentation.images.add_image(image_stream)
        slide_size = presentation.slide_size.size
        slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 0, 0, slide_size.width, slide_size.height, emf_image)
    
    presentation.save("presentation_with_EMF.pptx", slides.export.SaveFormat.PPTX)
```

## **جایگزینی تصاویر در مجموعه تصویر**

Aspose.Slides به شما اجازه می‌دهد تصاویر ذخیره‌شده در مجموعه تصویر یک ارائه، از جمله آن‌هایی که توسط شکل‌های اسلاید استفاده می‌شوند، را جایگزین کنید. این بخش چند روش برای به‌روزرسانی تصاویر در مجموعه را تشریح می‌کند. API روش‌های ساده‌ای برای جایگزینی یک تصویر با داده‌های بایتی خام، یک نمونه [IImage](https://reference.aspose.com/slides/fa/python-net/aspose.slides/iimage/) یا تصویر دیگری که قبلاً در مجموعه وجود دارد، فراهم می‌کند.

این مراحل را دنبال کنید:

1. ارائه‌ای که شامل تصاویر است را با استفاده از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) بارگذاری کنید.  
2. یک تصویر جدید را از یک فایل به یک آرایه بایت بارگذاری کنید.  
3. تصویر هدف را با تصویر جدید با استفاده از آرایه بایت جایگزین کنید.  
4. به‌جای آن، تصویر را به یک شیء [IImage](https://reference.aspose.com/slides/fa/python-net/aspose.slides/iimage/) بارگذاری کنید و تصویر هدف را با آن شیء جایگزین کنید.  
5. یا تصویر هدف را با تصویری که از پیش در مجموعه تصویر ارائه وجود دارد، جایگزین کنید.  
6. ارائه اصلاح‌شده را به‌عنوان فایل PPTX ذخیره کنید.

```py
def read_all_bytes(file_name):
    with open(file_name, "rb") as stream:
        return stream.read()


# نمونه‌سازی کلاس Presentation که نمایانگر یک فایل ارائه است.
with slides.Presentation("sample.pptx") as presentation:

    # روش اول.
    image_data = read_all_bytes("image0.jpeg")
    old_image = presentation.images[0]
    old_image.replace_image(image_data)

    # روش دوم.
    new_image = slides.Images.from_file("image1.jpeg")
    old_image = presentation.images[1]
    old_image.replace_image(new_image)

    # روش سوم.
    old_image = presentation.images[2]
    old_image.replace_image(presentation.images[3])

    # ارائه را در یک فایل ذخیره کنید.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="Info" color="info" %}}
با مبدل رایگان [Text to GIF](https://products.aspose.app/slides/fa/text-to-gif) از Aspose می‌توانید به‌راحتی متن را متحرک کنید و GIFهایی از متن بسازید.
{{% /alert %}}

## **سوالات متداول**

**آیا وضوح تصویر اصلی پس از درج دست نخورده می‌ماند؟**  
بله. پیکسل‌های منبع حفظ می‌شوند، اما ظاهر نهایی بستگی به این دارد که تصویر ([picture](/slides/fa/python-net/picture-frame/)) چگونه در اسلاید مقیاس‌بندی شود و چه فشرده‌سازی در زمان ذخیره اعمال شود.

**بهترین راه برای جایگزینی همان لوگو در ده‌ها اسلاید به‌صورت همزمان چیست؟**  
لوگو را بر روی اسلاید مستر یا یک چیدمان قرار دهید و آن را در مجموعه تصویر ارائه جایگزین کنید—به‌روزرسانی‌ها به تمام عناصری که از این منبع استفاده می‌کنند، منتشر می‌شود.

**آیا می‌توان SVG وارد‌شده را به شکل‌های قابل ویرایش تبدیل کرد؟**  
بله. می‌توانید یک SVG را به یک گروه از شکل‌ها تبدیل کنید؛ پس از آن بخش‌های فردی قابل ویرایش با خصوصیات استاندارد شکل می‌شوند.

**چگونه می‌توانم یک تصویر را به‌عنوان پس‌زمینه برای چندین اسلاید به‌صورت همزمان تنظیم کنم؟**  
[Assign the image as the background](/slides/fa/python-net/presentation-background/) را بر روی اسلاید مستر یا چیدمان مربوطه اعمال کنید—هر اسلایدی که از آن مستر/چیدمان استفاده می‌کند، پس‌زمینه را به ارث می‌برد.

**چگونه می‌توانم از بزرگ شدن بیش از حد حجم ارائه به‌دلیل تعداد زیاد تصاویر جلوگیری کنم؟**  
به‌جای تکرار تصویر، از یک منبع تصویر واحد استفاده کنید، رزولوشن‌های معقول انتخاب کنید، هنگام ذخیره فشرده‌سازی اعمال کنید و گرافیک‌های تکراری را در مستر نگهداری کنید.