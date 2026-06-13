---
title: مدیریت برچسب‌ها و داده‌های سفارشی در ارائه‌ها با Python
linktitle: برچسب‌ها و داده‌های سفارشی
type: docs
weight: 300
url: /fa/python-net/managing-tags-and-custom-data/
keywords:
- ویژگی‌های سند
- برچسب
- داده‌های سفارشی
- افزودن برچسب
- مقادیر جفتی
- پاورپوینت
- ارائه
- Python
- Aspose.Slides
description: "یاد بگیرید چگونه برچسب‌ها و داده‌های سفارشی را در Aspose.Slides برای Python از طریق .NET اضافه، بخوانید، به‌روزرسانی کنید و حذف نمایید، با مثال‌هایی برای ارائه‌های PowerPoint و OpenDocument."
---
## **بررسی کلی**

این مقاله توضیح می‌دهد که Aspose.Slides چگونه با برچسب‌ها و داده‌های سفارشی در ارائه‌های PowerPoint کار می‌کند. به‌طور خلاصه نحوه ذخیره‌سازی داده‌ها در فایل‌های PPTX، وجود داده‌های خاص ارائه به‌صورت برچسب‌ها و بخش‌های XML سفارشی، و توصیف برچسب‌ها به‌عنوان جفت‌های کلید‑مقدار رشته‌ای را شرح می‌دهد.

همچنین نشان می‌دهد چگونه مقادیر برچسب‌ها را بخوانید و چگونه برچسب‌ها را به یک ارائه، یک اسلاید منفرد یا یک شکل اضافه کنید. علاوه بر این، مقاله به وظایف معمول مدیریت برچسب مثل پاک‌سازی تمام برچسب‌ها، حذف یک برچسب بر اساس نام، و دریافت فهرست نام‌های برچسب می‌پردازد.

## **ذخیره‌سازی داده‌ها در فایل‌های ارائه**

فایل‌های PPTX — فایل‌های با پسوند .pptx — در قالب PresentationML ذخیره می‌شوند که بخشی از مشخصات Office Open XML است. فرمت Office Open XML ساختار داده‌های موجود در ارائه‌ها را تعریف می‌کند.

با توجه به اینکه *اسلاید* یکی از عناصر ارائه‌ها است، یک *بخش اسلاید* محتوای یک اسلاید واحد را شامل می‌شود. یک بخش اسلاید می‌تواند روابط صریحی با بخش‌های متعدد داشته باشد—مانند User Defined Tags—که توسط ISO/IEC 29500 تعریف شده‌اند.

داده‌های سفارشی (خاص یک ارائه) یا کاربر می‌توانند به‌صورت برچسب‌ها ([ITagCollection](https://reference.aspose.com/slides/fa/python-net/aspose.slides/itagcollection/)) و بخش‌های CustomXmlParts ([ICustomXmlPartCollection](https://reference.aspose.com/slides/fa/python-net/aspose.slides/icustomxmlpartcollection/)) وجود داشته باشند.

{{% alert color="primary" %}} 
برچسب‌ها در واقع مقادیر جفت کلید‑رشته‌ای هستند. 
{{% /alert %}} 

## **دریافت مقادیر برچسب‌ها**

در اسلایدها، یک برچسب متناظر با ویژگی IDocumentProperties.Keywords است. این کد نمونه نشان می‌دهد چگونه مقدار یک برچسب را با Aspose.Slides برای Python از طریق .NET برای [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) دریافت کنید:

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    print(pres.document_properties.keywords)
```

## **افزودن برچسب‌ها به ارائه‌ها**

Aspose.Slides به شما امکان می‌دهد برچسب‌ها را به ارائه‌ها اضافه کنید. یک برچسب معمولاً شامل دو مورد است:

- نام یک ویژگی سفارشی - `MyTag`
- مقدار ویژگی سفارشی - `My Tag Value`

اگر نیاز دارید برخی ارائه‌ها را بر اساس یک قانون یا ویژگی خاص طبقه‌بندی کنید، افزودن برچسب‌ها می‌تواند مفید باشد. برای مثال، اگر بخواهید تمام ارائه‌های کشورهای آمریکای شمالی را دسته‌بندی کنید، می‌توانید یک برچسب «North American» ایجاد کنید و سپس کشورهای مرتبط (ایالات متحده، مکزیک و کانادا) را به‌عنوان مقادیر انتساب دهید.

این کد نمونه نشان می‌دهد چگونه یک برچسب به یک [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) اضافه کنید با استفاده از Aspose.Slides برای Python از طریق .NET:

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
   tags = pres.custom_data.tags 
   tags.add("MyTag", "My Tag Value")
```

برچسب‌ها همچنین می‌توانند برای [Slide](https://reference.aspose.com/slides/fa/python-net/aspose.slides/slide/) تنظیم شوند:

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    slide = pres.slides[0]
    tags = slide.custom_data.tags
    tags.add("tag", "value")
```

یا برای هر [Shape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/shape/) منفرد:

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    slide = pres.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 50)
    shape.text_frame.text = "My text"
    shape.custom_data.tags.add("tag", "value")
```

### **محدودیت‌ها**

برچسب‌های اضافه شده از طریق مجموعه `custom_data.tags` فقط در داخل فایل PowerPoint ذخیره می‌شوند. آنها **به** ساختار برچسب‌های PDF هنگام خروجی گرفتن به PDF انتقال داده نمی‌شوند. بنابراین یک شناسه سفارشی که به‌عنوان برچسب اختصاص داده شده است، نمی‌تواند از PDF برچسب‌دار بازیابی شود.

**راه حل:** می‌توانید یک شناسه سفارشی را در **متن Alt** (به‌عنوان مثال `shape.alternative_text = "MyId"`) شیء ذخیره کنید. پس از خروجی به PDF، متن Alt ممکن است در ساختار برچسب‌های PDF ظاهر شود.

## **سوالات متداول**

**آیا می‌توانم تمام برچسب‌ها را از یک ارائه، اسلاید یا شکل در یک عملیات حذف کنم؟**

بله. [tag collection](https://reference.aspose.com/slides/fa/python-net/aspose.slides/tagcollection/) از عمل [clear](https://reference.aspose.com/slides/fa/python-net/aspose.slides/tagcollection/clear/) پشتیبانی می‌کند که تمام جفت‌های کلید‑مقدار را یک‌بار حذف می‌نماید.

**چگونه می‌توانم یک برچسب واحد را بر اساس نام آن حذف کنم بدون اینکه کل مجموعه را پیمایش کنم؟**

از عمل [remove(name)](https://reference.aspose.com/slides/fa/python-net/aspose.slides/tagcollection/remove/) بر روی [TagCollection](https://reference.aspose.com/slides/fa/python-net/aspose.slides/tagcollection/) استفاده کنید تا برچسب را بر اساس کلید آن حذف نمایید.

**چگونه می‌توانم فهرست کامل نام‌های برچسب‌ها را برای تجزیه و تحلیل یا فیلترینگ دریافت کنم؟**

از [get_names_of_tags](https://reference.aspose.com/slides/fa/python-net/aspose.slides/tagcollection/get_names_of_tags/) بر روی [tag collection](https://reference.aspose.com/slides/fa/python-net/aspose.slides/tagcollection/) استفاده کنید؛ این متد یک آرایه شامل تمام نام‌های برچسب‌ها بازمی‌گرداند.