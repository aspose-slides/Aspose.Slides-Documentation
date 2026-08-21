---
title: عملیات ارائه کم‌کد در پایتون
linktitle: API کم‌کد
type: docs
weight: 50
url: /fa/python-net/low-code-presentation-operations/
keywords:
- API ارائه کم‌کد
- تبدیل ارائه
- ادغام ارائه‌ها
- جمع‌آوری اشکال
- فشرده‌سازی ارائه
- حذف اسلایدهای مستر بلااستفاده
- حذف اسلایدهای طرح‌بندی بلااستفاده
- فشرده‌سازی قلم‌های توکار
- PowerPoint
- OpenDocument
- ارائه
- Python
- Aspose.Slides
description: "از API کم‌کد Aspose.Slides در پایتون برای تبدیل و ادغام ارائه‌ها، جمع‌آوری اشکال و کاهش حجم ارائه استفاده کنید."
---
## **بررسی اجمالی**

ماژول [aspose.slides.lowcode](https://reference.aspose.com/slides/fa/python-net/aspose.slides.lowcode/) کلاس‌های کمکی برای عملیات‌های رایج ارائه فراهم می‌کند. این کمکی‌ها جریان‌های کاری مدل شیء که به‌طور مکرر استفاده می‌شوند را در متدهای متمرکز می‌پیچند، بنابراین می‌توانید فایل‌ها را تبدیل یا ترکیب کنید، اشکال را جمع‌آوری کنید و محتوای بلااستفاده را با کد کمتر حذف کنید.

کمکی‌های کم‌کد زمانی بیشترین کاربرد را دارند که عملیات بر روی کل فایل یا ارائه اعمال شود و جریان کاری پیش‌فرض با نیازهای شما مطابقت داشته باشد. هنگامی که به کنترل دقیق بر اسلایدهای منفرد، مسترها، لایه‌ها، اشکال، تنظیمات صادرات یا ارتباطات بین عناصر ارائه نیاز دارید، از مدل شیء کامل [Aspose.Slides object model](https://reference.aspose.com/slides/fa/python-net/aspose.slides/) استفاده کنید.

جدول زیر خلاصه‌ای از کمکی‌های موجود را ارائه می‌دهد:

| Helper | Use it for |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/fa/python-net/aspose.slides.lowcode/convert/) | تبدیل یک ارائه به فرمت دیگر با فراخوانی مستقیم فایل به فایل. |
| [Merger](https://reference.aspose.com/slides/fa/python-net/aspose.slides.lowcode/merger/) | ترکیب فایل‌های کامل ارائه با فرمت یکسان. |
| [Collect](https://reference.aspose.com/slides/fa/python-net/aspose.slides.lowcode/collect/) | استخراج اشکال از کل ارائه برای پردازش یا تجزیه و تحلیل مکرر. |
| [Compress](https://reference.aspose.com/slides/fa/python-net/aspose.slides.lowcode/compress/) | حذف مسترها و لایه‌های بلااستفاده و کاهش داده‌های قلم‌های توکار. |

## **تبدیل یک ارائه**

هنگامی که پسوند فایل خروجی برای انتخاب فرمت صادرات کافی باشد، از [Convert.auto_by_extension](https://reference.aspose.com/slides/fa/python-net/aspose.slides.lowcode/convert/auto_by_extension/) استفاده کنید. این متد ارائه منبع را باز می‌کند، فرمت مورد نیاز را از مسیر خروجی تعیین می‌نماید و نتیجه را می‌نویسد.

```python
import aspose.slides as slides

slides.lowcode.Convert.auto_by_extension("input.pptx", "output.pdf")
```

کلاس [Convert](https://reference.aspose.com/slides/fa/python-net/aspose.slides.lowcode/convert/) همچنین متدهای اختصاصی برای خروجی PDF، SVG، JPEG، PNG و TIFF فراهم می‌آورد. هنگامی که نیاز به بررسی یا تغییر ارائه قبل از صادرات یا پیکربندی گزینه‌ای دارید که توسط کمکی انتخاب‌شده در دسترس نیست، از مدل شیء کامل استفاده کنید. برای جریان‌های کاری و گزینه‌های خاص هر فرمت، به صفحه [تبدیل ارائه](/python-net/convert-presentation/) مراجعه کنید.

## **ادغام ارائه‌ها**

از [Merger.process](https://reference.aspose.com/slides/fa/python-net/aspose.slides.lowcode/merger/process/) برای ترکیب فایل‌های کامل ارائه با یک فراخوانی استفاده کنید. ارائه‌های ورودی باید دارای همان فرمت فایل باشند.

```python
import aspose.slides as slides

input_files = ["part-1.pptx", "part-2.pptx"]
slides.lowcode.Merger.process(input_files, "merged.pptx")
```

این کمکی زمانی مناسب است که تمام اسلایدها باید بدون انتخاب یا نگاشت مجدد به‌صورت فردی به یک نتیجه اضافه شوند. هنگامی که نیاز به ادغام اسلایدهای انتخاب‌شده، اعمال مستر یا لایه مقصد، حفظ بخش‌ها به‌صورت صریح یا سازگار کردن اندازه‌های مختلف اسلاید دارید، از مدل شیء کامل استفاده کنید. برای این سناریوها به صفحه [ادغام ارائه‌ها](/python-net/merge-presentation/) مراجعه کنید.

## **جمع‌آوری اشکال**

هنگامی که به مجموعه‌ای از تمام اشکال موجود در یک ارائه نیاز داشته باشید، از [Collect.shapes](https://reference.aspose.com/slides/fa/python-net/aspose.slides.lowcode/collect/shapes/) استفاده کنید. این مورد زمانی مفید است که همان مجموعه برای فیلتر، شمارش یا پردازش چندباره مورد استفاده قرار گیرد.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    shapes = slides.lowcode.Collect.shapes(presentation)

    for shape in shapes:
        print(f"{shape.name}: {type(shape).__name__}")
```

زمانی که ترتیب پیمایش، خروج زودهنگام، فیلتر قبل از پردازش یا کنترل دقیق والد‑فرزندی مهم باشد، از حلقه‌های جمع‌آوری مستقیم استفاده کنید.

## **فشرده‌سازی محتوای ارائه**

کلاس [Compress](https://reference.aspose.com/slides/fa/python-net/aspose.slides.lowcode/compress/) می‌تواند عناصر ساختاری بلااستفاده را حذف کرده و داده‌های قلم‌های توکار را کاهش دهد:

- [Compress.remove_unused_layout_slides](https://reference.aspose.com/slides/fa/python-net/aspose.slides.lowcode/compress/remove_unused_layout_slides/) اسلایدهای لایه‌ای را که توسط هیچ اسلاید عادی ارجاع داده نمی‌شوند، حذف می‌کند.
- [Compress.remove_unused_master_slides](https://reference.aspose.com/slides/fa/python-net/aspose.slides.lowcode/compress/remove_unused_master_slides/) مسترهای اسلایدی که دیگر استفاده نمی‌شوند را حذف می‌کند.
- [Compress.compress_embedded_fonts](https://reference.aspose.com/slides/fa/python-net/aspose.slides.lowcode/compress/compress_embedded_fonts/) حروف بلااستفاده را از قلم‌های توکار حذف می‌کند.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slides.lowcode.Compress.remove_unused_layout_slides(presentation)
    slides.lowcode.Compress.remove_unused_master_slides(presentation)
    slides.lowcode.Compress.compress_embedded_fonts(presentation)

    presentation.save("compressed.pptx", slides.export.SaveFormat.PPTX)
```

ابتدا لایه‌های بلااستفاده را حذف کنید و سپس مسترهای بلااستفاده، به طوری که مستری که پس از پاک‌سازی لایه‌ها بدون ارجاع می‌ماند نیز حذف شود. اگر ممکن است بعداً به مسترها، لایه‌ها یا داده‌های کامل قلم‌های توکار اصلی نیاز داشته باشید، ارائه بهینه‌شده را در فایلی جدید ذخیره کنید. برای جزئیات بیشتر، به صفحات [اسلاید مستر](/python-net/slide-master/) و [قلم توکار](/python-net/embedded-font/) مراجعه کنید.

## **سوالات متداول**

**چه زمانی باید از API کم‌کد به‌جای مدل شیء کامل استفاده کنم؟**

زمانی که یک عملیات استاندارد بر روی یک فایل یا ارائه کامل اعمال می‌شود و نیازی به کنترل دقیق بر عناصر منفرد ندارد، از کمکی‌های کم‌کد استفاده کنید. هنگامی که لازم است اسلایدهای خاصی را انتخاب کنید، روابط مستر و لایه را کنترل کنید، وضعیت میانی را بررسی کنید یا رفتارهایی را پیکربندی کنید که کمکی آن‌ها را در دسترس قرار نمی‌دهد، از مدل شیء کامل استفاده کنید.

**آیا Merger می‌تواند ارائه‌ها را در فرمت‌های فایل متفاوت ترکیب کند؟**

خیر. متد [Merger.process](https://reference.aspose.com/slides/fa/python-net/aspose.slides.lowcode/merger/process/) نیاز دارد که ارائه‌های ورودی در همان فرمت باشند. ابتدا فایل‌های ورودی را به یک فرمت مشترک تبدیل کنید، برای مثال با استفاده از [Convert.auto_by_extension](https://reference.aspose.com/slides/fa/python-net/aspose.slides.lowcode/convert/auto_by_extension/)، و سپس فایل‌های تبدیل‌شده را ترکیب کنید.

**Collect.shapes چه چیزی را شامل می‌شود؟**

[Collect.shapes](https://reference.aspose.com/slides/fa/python-net/aspose.slides.lowcode/collect/shapes/) اشکال را از ارائه استخراج می‌کند تا بتوان آن‌ها را حفظ، فیلتر، شمارش یا چندین بار پیمایش کرد. زمانی که نیاز به کنترل دقیق بر انواع اسلاید یا اشیاء تو در توی بازدید شده دارید، از حلقه‌های جمع‌آوری مستقیم استفاده کنید.

**آیا Compress همیشه فایل ارائه را کوچک‌تر می‌کند؟**

لزوماً نه. نتیجه بستگی به این دارد که آیا ارائه شامل لایه‌ها یا مسترهای بلااستفاده یا قلم‌های توکار با کاراکترهای بلااستفاده است یا خیر. اگر هیچ‌یک از این موارد وجود نداشته باشد، عملیات‌های مرتبط با [Compress](https://reference.aspose.com/slides/fa/python-net/aspose.slides.lowcode/compress/) ممکن است اندازه فایل را کاهش ندهند.

**آیا تغییرات اعمال‌شده توسط Compress به‌صورت خودکار ذخیره می‌شوند؟**

خیر. این کمکی‌ها بر روی شیء [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) بارگذاری‌شده در حافظه عمل می‌کنند. پس از اجرای [Compress](https://reference.aspose.com/slides/fa/python-net/aspose.slides.lowcode/compress/)، برای نوشتن نتیجه متد [Presentation.save](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/save/) را فرا بخوانید.

## **مقالات مرتبط**

- [تبدیل ارائه](/python-net/convert-presentation/)
- [ادغام ارائه‌ها](/python-net/merge-presentation/)
- [اسلاید مستر](/python-net/slide-master/)
- [مدیریت جعبه متن](/python-net/manage-textbox/)
- [قلم توکار](/python-net/embedded-font/)