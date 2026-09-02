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
- OpenDocument
- ارائه
- Python
- Aspose.Slides
description: "مدیریت تصویر در PowerPoint و OpenDocument را با Aspose.Slides برای Python از طریق .NET به‌صورت بهینه‌سازی‌شده، عملکرد را بهبود داده و جریان کار شما را خودکار می‌کند."
---
## **مقدمه**

تصاویر ارائه‌ها را جذاب‌تر و جالب‌تر می‌کنند. در مایکروسافت پاورپوینت می‌توانید تصاویر را از یک فایل، اینترنت یا منابع دیگر روی اسلایدها وارد کنید. به‌طور مشابه، Aspose.Slides به شما امکان می‌دهد تا تصاویر را به اسلایدها به چندین روش اضافه کنید.

{{% alert  title="نکته" color="primary" %}}
Aspose مبدل‌های رایگان—[JPEG به PowerPoint](https://products.aspose.app/slides/fa/import/jpg-to-ppt) و [PNG به PowerPoint](https://products.aspose.app/slides/fa/import/png-to-ppt)—را فراهم می‌کند که به شما امکان می‌دهد به سرعت ارائه‌ها را از تصاویر ایجاد کنید.
{{% /alert %}}

{{% alert title="اطلاعات" color="info" %}}
اگر می‌خواهید تصویری را به‌عنوان یک شیء فریم اضافه کنید—به‌ویژه اگر قصد دارید از گزینه‌های قالب‌بندی استاندارد مانند تغییر اندازه یا اعمال افکت‌ها استفاده کنید—به [Add Picture Frames to Presentations with Python](https://docs.aspose.com/slides/fa/python-net/picture-frame/) مراجعه کنید.
{{% /alert %}}

{{% alert title="توجه" color="warning" %}}
شما می‌توانید از عملیات ورودی/خروجی تصویر و ارائه برای تبدیل تصاویر بین قالب‌ها استفاده کنید. این صفحات را ببینید: تبدیل [image to JPG](https://products.aspose.com/slides/fa/python-net/conversion/image-to-jpg/); تبدیل [JPG to image](https://products.aspose.com/slides/fa/python-net/conversion/jpg-to-image/); تبدیل [JPG to PNG](https://products.aspose.com/slides/fa/python-net/conversion/jpg-to-png/); تبدیل [PNG to JPG](https://products.aspose.com/slides/fa/python-net/conversion/png-to-jpg/); تبدیل [PNG to SVG](https://products.aspose.com/slides/fa/python-net/conversion/png-to-svg/); و تبدیل [SVG to PNG](https://products.aspose.com/slides/fa/python-net/conversion/svg-to-png/).
{{% /alert %}}

Aspose.Slides از کار با تصاویر در قالب‌های محبوبی مثل JPEG، PNG، BMP، GIF و سایرین پشتیبانی می‌کند.

## **افزودن تصاویر ذخیره‌شده به‌صورت محلی به اسلایدها**

شما می‌توانید یک یا چند تصویر را از کامپیوتر خود به یک اسلاید در یک ارائه اضافه کنید. مثال زیر به زبان Python نشان می‌دهد چگونه یک تصویر به اسلاید اضافه شود:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)
        slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, image)

    presentation.save("presentation_with_image.pptx", slides.export.SaveFormat.PPTX)
```

## **افزودن تصاویر از وب به اسلایدها**

اگر تصویری که می‌خواهید به اسلاید اضافه کنید در کامپیوتر شما موجود نیست، می‌توانید آن را به‌صورت مستقیم از وب وارد کنید.

مثال زیر به زبان Python نشان می‌دهد چگونه یک تصویر را از یک URL به اسلاید اضافه کنید:

```py
import aspose.slides as slides
from urllib.request import urlopen

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # دریافت بایت‌های خام تصویر.
    with urlopen("[REPLACE WITH URL]") as response:
        image_data = response.read()

    image = presentation.images.add_image(image_data)
    slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, image)

    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

## **افزودن تصاویر به اسلاید مسترها**

اسلاید مستر، اسلاید سطح بالاست که اطلاعات—تم، طرح‌بندی و غیره—را برای تمام اسلایدهای زیرمجموعه خود ذخیره و کنترل می‌کند. وقتی یک تصویر به اسلاید مستر اضافه می‌کنید، آن تصویر بر روی هر اسلایدی که از آن مستر استفاده می‌کند ظاهر می‌شود.

مثال زیر به زبان Python نشان می‌دهد چگونه یک تصویر به اسلاید مستر اضافه شود:

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

## **افزودن تصاویر به‌عنوان پس‌زمینه اسلایدها**

شما می‌توانید از یک تصویر به‌عنوان پس‌زمینه برای یک یا چند اسلاید استفاده کنید. برای جزئیات، به *[Setting Images as Backgrounds for Slides](/slides/fa/python-net/presentation-background/#setting-images-as-background-for-slides)* مراجعه کنید.

## **افزودن SVG به ارائه‌ها**

محتوای SVG می‌تواند با استفاده از کلاس [SvgImage](https://reference.aspose.com/slides/fa/python-net/aspose.slides/svgimage/) به یک ارائه اضافه شود. تصویر SVG حاصل سپس می‌تواند به مجموعه تصاویر ارائه اضافه شود و برای ایجاد یک فریم تصویر استفاده گردد.

مثال زیر به زبان Python یک رشته SVG خودکفا را وارد می‌کند. تمام تصاویر، سبک‌ها و سایر منابع استفاده‌شده توسط این SVG به‌صورت مستقیم در محتوای SVG تعبیه شده‌اند.

```py
import aspose.slides as slides

svg_content = """
<svg xmlns='http://www.w3.org/2000/svg' width='320' height='180'>
    <rect width='320' height='180' fill='#4F81BD'/>
    <circle cx='160' cy='90' r='55' fill='#F2F2F2'/>
</svg>
"""

with slides.Presentation() as presentation:
    svg_image = slides.SvgImage(svg_content)
    image = presentation.images.add_image(svg_image)

    presentation.slides[0].shapes.add_picture_frame(
        slides.ShapeType.RECTANGLE, 20, 20, image.width, image.height, image
    )

    presentation.save("self-contained-svg.pptx", slides.export.SaveFormat.PPTX)
```

## **تبدیل SVG به مجموعه‌ای از اشکال**

Aspose.Slides SVGها را به مجموعه‌ای از اشکال تبدیل می‌کند به‌گونه‌ای مشابه با نحوه پردازش SVG در پاورپوینت.

![PowerPoint Popup Menu](img_01_01.png)

این قابلیت توسط یک overload از متد [add_group_shape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/shapecollection/add_group_shape/) در کلاس [ShapeCollection](https://reference.aspose.com/slides/fa/python-net/aspose.slides/shapecollection/) که یک [SvgImage](https://reference.aspose.com/slides/fa/python-net/aspose.slides/svgimage/) را به‌عنوان اولین آرگومان می‌گیرد، فراهم می‌شود.

کد نمونه زیر نشان می‌دهد چگونه یک فایل SVG را به مجموعه‌ای از اشکال تبدیل کنیم.

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

        # تصویر SVG را به یک گروه از اشکال تبدیل کنید و به اندازه اسلاید مقیاس دهید.
        presentation.slides[0].shapes.add_group_shape(svg_image, 0, 0, slide_size.width, slide_size.height)

        # ارائه را در قالب PPTX ذخیره کنید.
        presentation.save("shapes_from_SVG.pptx", slides.export.SaveFormat.PPTX)
```

## **افزودن تصاویر به‌صورت EMF به اسلایدها**

Aspose.Slides برای Python به شما امکان می‌دهد تا تصاویر Enhanced Metafile (EMF) را به ارائه‌ها وارد کنید.

مثال زیر به زبان Python این را نشان می‌دهد:

```py 
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    with open("image.emf", "rb") as image_stream:
        emf_image = presentation.images.add_image(image_stream)
        slide_size = presentation.slide_size.size
        slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 0, 0, slide_size.width, slide_size.height, emf_image)
    
    presentation.save("presentation_with_EMF.pptx", slides.export.SaveFormat.PPTX)
```

## **جایگزینی تصاویر در مجموعهٔ تصویر‌ها**

Aspose.Slides به شما امکان می‌دهد تا تصاویر ذخیره‌شده در مجموعهٔ تصاویر یک ارائه، از جمله تصاویر استفاده‌شده توسط اشکال اسلاید، را جایگزین کنید. این بخش چندین رویکرد برای به‌روزرسانی تصاویر در مجموعه را توضیح می‌دهد. API روش‌های ساده‌ای برای جایگزینی یک تصویر با داده‌های بایت خام، یک نمونهٔ [IImage](https://reference.aspose.com/slides/fa/python-net/aspose.slides/iimage/)، یا تصویر دیگری که قبلاً در مجموعه وجود دارد، فراهم می‌کند.

مراحل زیر را دنبال کنید:

1. ارائه‌ای که شامل تصاویر است را با استفاده از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) بارگذاری کنید.  
2. تصویر جدیدی را از یک فایل به یک آرایه بایت بارگذاری کنید.  
3. تصویر هدف را با تصویر جدید با استفاده از آرایه بایت جایگزین کنید.  
4. به‌صورت جایگزین، تصویر را به یک شیء [IImage](https://reference.aspose.com/slides/fa/python-net/aspose.slides/iimage/) بارگذاری کنید و تصویر هدف را با آن شیء جایگزین کنید.  
5. یا تصویر هدف را با تصویری که پیشاپیش در مجموعهٔ تصویرهای ارائه وجود دارد، جایگزین کنید.  
6. ارائهٔ اصلاح‌شده را به‌عنوان فایل PPTX ذخیره کنید.

```py
import aspose.slides as slides

def read_all_bytes(file_name):
    with open(file_name, "rb") as stream:
        return stream.read()


# نمونه‌سازی کلاس Presentation که یک فایل ارائه را نمایندگی می‌کند.
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

    # ذخیرهٔ ارائه در یک فایل.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="اطلاعات" color="info" %}}
با مبدل رایگان [Text to GIF](https://products.aspose.app/slides/fa/text-to-gif) از Aspose می‌توانید به‌سادگی متن را انیمیشن کنید و GIFهایی از متن ایجاد کنید.
{{% /alert %}}

## **سوالات متداول**

**آیا وضوح تصویر اصلی پس از درج حفظ می‌شود؟**  
بله. پیکسل‌های منبع حفظ می‌شوند، اما ظاهر نهایی بستگی به این دارد که چگونه [picture](/slides/fa/python-net/picture-frame/) بر روی اسلاید مقیاس‌بندی شده و هر فشرده‌سازی‌ای که هنگام ذخیره اعمال می‌شود.

**بهترین راه برای جایگزینی یک لوگوی یکسان در ده‌ها اسلاید به‌طور همزمان چیست؟**  
لوگو را بر روی اسلاید مستر یا یک طرح‌بندی قرار دهید و آن را در مجموعهٔ تصویرهای ارائه جایگزین کنید—به‌روزرسانی‌ها به تمام عناصری که از آن منبع استفاده می‌کنند، انتشار می‌یابد.

**آیا می‌توان یک SVG وارد‌شده را به اشکال قابل ویرایش تبدیل کرد؟**  
بله. می‌توانید یک SVG را به یک گروه از اشکال تبدیل کنید، پس از آن بخش‌های منفرد قابل ویرایش با ویژگی‌های استاندارد شکل می‌شوند.

**چگونه می‌توانم یک تصویر را به‌عنوان پس‌زمینه برای چندین اسلاید به‌طور همزمان تنظیم کنم؟**  
از گزینه [Assign the image as the background](/slides/fa/python-net/presentation-background/) بر روی اسلاید مستر یا طرح‌بندی مربوطه استفاده کنید؛ هر اسلایدی که از آن مستر/طرح‌بندی استفاده می‌کند، پس‌زمینه را به ارث می‌برد.

**چگونه می‌توانم از بزرگ شدن بیش از حد یک ارائه به‌دلیل تعداد زیاد تصاویر جلوگیری کنم؟**  
از یک منبع تصویر واحد به‌جای تکرار استفاده کنید، رزولوشن‌های معقول انتخاب کنید، هنگام ذخیره فشرده‌سازی اعمال کنید و گرافیک‌های تکراری را در مستر نگه دارید تا در صورت لزوم.