---
title: عملیات ارائه با کد کم در پایتون
linktitle: API کد کم
type: docs
weight: 50
url: /fa/python-net/low-code-presentation-operations/
keywords:
- API ارائه کد کم
- تبدیل ارائه
- ادغام ارائه‌ها
- جمع‌آوری اشکال
- فشرده‌سازی ارائه
- حذف اسلایدهای مستر استفاده‌نشده
- حذف اسلایدهای چیدمان استفاده‌نشده
- فشرده‌سازی فونت‌های جاسازی‌شده
- PowerPoint
- OpenDocument
- ارائه
- Python
- Aspose.Slides
description: "از API کد کم Aspose.Slides در پایتون برای تبدیل و ادغام ارائه‌ها، جمع‌آوری اشکال و کاهش اندازهٔ ارائه استفاده کنید."
---
## **نمای کلی**

ماژول [aspose.slides.lowcode](https://reference.aspose.com/slides/fa/python-net/aspose.slides.lowcode/) کلاس‌های کمکی برای عملیات معمول ارائه فراهم می‌کند. این کمکی‌ها گردش کارهای مدل شیء که به‌طور مکرر استفاده می‌شوند را در روش‌های متمرکز می‌پیچند، بنابراین می‌توانید فایل‌ها را تبدیل یا ادغام کنید، اشکال را جمع‌آوری کنید و محتوای استفاده‌نشده را با کد کمتر حذف کنید.

کمک‌کنندگان کم‌کد زمانی مفیدترین هستند که عملیات بر روی یک فایل یا پرزنتیشن کامل اعمال می‌شود و گردش کار پیش‌فرض با نیازهای شما سازگار است. از مدل شیء کامل [Aspose.Slides](https://reference.aspose.com/slides/fa/python-net/aspose.slides/) استفاده کنید هنگامی که به کنترل دقیق روی اسلایدهای تک‌تک، مسترها، چیدمان‌ها، اشکال، تنظیمات خروجی یا روابط بین عناصر پرزنتیشن نیاز دارید.

جدول زیر خلاصه‌ای از کمک‌کنندگان موجود را ارائه می‌دهد:

| کمک‌کننده | موارد استفاده |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/fa/python-net/aspose.slides.lowcode/convert/) | تبدیل یک پرزنتیشن به فرمت دیگر با فراخوانی مستقیم فایل‑به‑فایل. |
| [Merger](https://reference.aspose.com/slides/fa/python-net/aspose.slides.lowcode/merger/) | ترکیب فایل‌های پرزنتیشن کامل با همان فرمت. |
| [Collect](https://reference.aspose.com/slides/fa/python-net/aspose.slides.lowcode/collect/) | دریافت اشکال از کل پرزنتیشن برای پردازش یا تحلیل مکرر. |
| [Compress](https://reference.aspose.com/slides/fa/python-net/aspose.slides.lowcode/compress/) | حذف مسترها و چیدمان‌های استفاده‌نشده و کاهش داده‌های فونت‌های جاسازی‌شده. |

## **تبدیل یک پرزنتیشن**

از [Convert.auto_by_extension](https://reference.aspose.com/slides/fa/python-net/aspose.slides.lowcode/convert/auto_by_extension/) زمانی استفاده کنید که پسوند فایل خروجی برای انتخاب فرمت خروجی کافی باشد. این متد پرزنتیشن منبع را باز می‌کند، فرمت مورد نیاز را از مسیر خروجی تعیین می‌نماید و نتیجه را می‌نویسد.

```python
import aspose.slides as slides

slides.lowcode.Convert.auto_by_extension("input.pptx", "output.pdf")
```

کلاس [Convert](https://reference.aspose.com/slides/fa/python-net/aspose.slides.lowcode/convert/) همچنین روش‌های اختصاصی برای خروجی PDF، SVG، JPEG، PNG و TIFF فراهم می‌کند. هنگامی که نیاز به بررسی یا اصلاح پرزنتیشن قبل از خروجی یا پیکربندی گزینه‌ای خروجی دارید که توسط کمک‌کننده انتخاب شده نشان داده نمی‌شود، از مدل شیء کامل استفاده کنید. برای گردش کارها و گزینه‌های خاص فرمت، ‌به [Convert Presentation](/slides/fa/python-net/convert-presentation/) مراجعه کنید.

## **ادغام پرزنتیشن‌ها**

از [Merger.process](https://reference.aspose.com/slides/fa/python-net/aspose.slides.lowcode/merger/process/) برای ترکیب فایل‌های پرزنتیشن کامل با یک فراخوانی استفاده کنید. پرزنتیشن‌های ورودی باید همان فرمت فایل را داشته باشند.

```python
import aspose.slides as slides

input_files = ["part-1.pptx", "part-2.pptx"]
slides.lowcode.Merger.process(input_files, "merged.pptx")
```

این کمک‌کننده زمانی مناسب است که تمام اسلایدها باید بدون انتخاب یا بازنگری جداگانه به یک نتیجه اضافه شوند. هنگامی که نیاز به ادغام اسلایدهای منتخب، اعمال مستر یا چیدمان مقصد، حفظ بخش‌ها به‌صورت صریح یا سازگاری اندازه‌های مختلف اسلاید دارید، از مدل شیء کامل استفاده کنید. برای این سناریوها به [Merge Presentations](/slides/fa/python-net/merge-presentation/) مراجعه کنید.

## **جمع‌آوری اشکال**

از [Collect.shapes](https://reference.aspose.com/slides/fa/python-net/aspose.slides.lowcode/collect/shapes/) زمانی استفاده کنید که به مجموعه‌ای از تمام اشکال یک پرزنتیشن نیاز دارید. این کار زمانی مفید است که همان مجموعه چندین بار فیلتر، شمارش یا پردازش شود.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    shapes = slides.lowcode.Collect.shapes(presentation)

    for shape in shapes:
        print(f"{shape.name}: {type(shape).__name__}")
```

از حلقه‌های جمع‌آوری مستقیم استفاده کنید وقتی ترتیب پیمایش، خروج زودهنگام، فیلتر قبل از پردازش یا کنترل دقیق والد‑فرزندی اهمیت دارد.

## **فشرده‌سازی محتوای پرزنتیشن**

کلاس [Compress](https://reference.aspose.com/slides/fa/python-net/aspose.slides.lowcode/compress/) می‌تواند عناصر ساختاری استفاده‌نشده را حذف کرده و داده‌های فونت جاسازی‌شده را کاهش دهد:

- [Compress.remove_unused_layout_slides](https://reference.aspose.com/slides/fa/python-net/aspose.slides.lowcode/compress/remove_unused_layout_slides/) چیدمان‌های اسلایدی را که هیچ اسلاید نرمالی به آن‌ها ارجاع نمی‌دهد، حذف می‌کند.
- [Compress.remove_unused_master_slides](https://reference.aspose.com/slides/fa/python-net/aspose.slides.lowcode/compress/remove_unused_master_slides/) مسترهای استفاده‌نشده را حذف می‌کند.
- [Compress.compress_embedded_fonts](https://reference.aspose.com/slides/fa/python-net/aspose.slides.lowcode/compress/compress_embedded_fonts/) حروف استفاده‌نشده را از فونت‌های جاسازی‌شده حذف می‌کند.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slides.lowcode.Compress.remove_unused_layout_slides(presentation)
    slides.lowcode.Compress.remove_unused_master_slides(presentation)
    slides.lowcode.Compress.compress_embedded_fonts(presentation)

    presentation.save("compressed.pptx", slides.export.SaveFormat.PPTX)
```

چیدمان‌های استفاده‌نشده را قبل از مسترهای استفاده‌نشده حذف کنید تا مستری که پس از پاک‌سازی چیدمان‌ها دیگر ارجاع داده نمی‌شود نیز حذف شود. اگر ممکن است بعدها به مسترها، چیدمان‌ها یا داده‌های کامل فونت‌های جاسازی‌شده اصلی نیاز داشته باشید، پرزنتیشن بهینه‌شده را در فایل جدیدی ذخیره کنید. برای جزئیات بیشتر، به [Slide Master](/slides/fa/python-net/slide-master/) و [Embedded Font](/slides/fa/python-net/embedded-font/) مراجعه کنید.

## **سوالات متداول**

**چه زمانی باید از API کم‌کد به‌جای مدل شیء کامل استفاده کنم؟**

وقتی یک عملیات استاندارد بر روی یک فایل یا پرزنتیشن کامل اعمال می‌شود و نیازی به کنترل دقیق بر روی عناصر تک‌تک نیست، از کمک‌کنندگان کم‌کد استفاده کنید. وقتی باید اسلایدهای خاصی را انتخاب کنید، روابط مستر و چیدمان را کنترل کنید، وضعیت میانی را بررسی کنید یا رفتارهایی را پیکربندی کنید که کمک‌کننده نمایش نمی‌دهد، از مدل شیء کامل استفاده کنید.

**آیا Merger می‌تواند پرزنتیشن‌ها را در فرمت‌های فایل متفاوت ترکیب کند؟**

خیر. [Merger.process](https://reference.aspose.com/slides/fa/python-net/aspose.slides.lowcode/merger/process/) نیاز دارد که پرزنتیشن‌های ورودی در یک فرمت باشند. ابتدا فایل‌های ورودی را به یک فرمت مشترک تبدیل کنید، به‌عنوان مثال با [Convert.auto_by_extension](https://reference.aspose.com/slides/fa/python-net/aspose.slides.lowcode/convert/auto_by_extension/)، و سپس فایل‌های تبدیل‌شده را ترکیب کنید.

**Collect.shapes چه چیزی را شامل می‌شود؟**

[Collect.shapes](https://reference.aspose.com/slides/fa/python-net/aspose.slides.lowcode/collect/shapes/) اشکال را از پرزنتیشن استخراج می‌کند تا بتوانند نگهداری، فیلتر، شمارش یا پیمایش چندبار شوند. وقتی نیاز به کنترل دقیق بر روی نوع اسلایدها یا اشیای تو در توی بازدید شده دارید، از حلقه‌های جمع‌آوری مستقیم استفاده کنید.

**آیا Compress همیشه اندازه فایل پرزنتیشن را کوچکتر می‌کند؟**

لزومی نیست. نتیجه به این بستگی دارد که آیا پرزنتیشن شامل چیدمان‌های استفاده‌نشده، مسترهای استفاده‌نشده یا فونت‌های جاسازی‌شده با حروف استفاده‌نشده باشد یا خیر. اگر هیچ‌کدام از این موارد موجود نباشد، عملیات مربوط به [Compress](https://reference.aspose.com/slides/fa/python-net/aspose.slides.lowcode/compress/) ممکن است اندازه فایل را کاهش ندهد.

**آیا تغییرات ایجاد شده توسط Compress به‌صورت خودکار ذخیره می‌شوند؟**

خیر. این کمک‌کنندگان بر روی شیء [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) بارگذاری‌شده در حافظه کار می‌کنند. پس از اجرای [Compress](https://reference.aspose.com/slides/fa/python-net/aspose.slides.lowcode/compress/)، برای نوشتن نتیجه باید [Presentation.save](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/save/) را فراخوانی کنید.

## **مقالات مرتبط**

- [تبدیل پرزنتیشن](/slides/fa/python-net/convert-presentation/)
- [ادغام پرزنتیشن‌ها](/slides/fa/python-net/merge-presentation/)
- [مستر اسلاید](/slides/fa/python-net/slide-master/)
- [مدیریت جعبه متن](/slides/fa/python-net/manage-textbox/)
- [فونت جاسازی‌شده](/slides/fa/python-net/embedded-font/)