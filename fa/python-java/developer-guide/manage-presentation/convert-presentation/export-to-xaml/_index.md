---
title: صدور ارائه‌ها به XAML در Python از طریق Java
linktitle: ارائه به XAML
type: docs
weight: 30
url: /fa/python-java/export-to-xaml/
keywords:
- صادرات PowerPoint
- صادرات OpenDocument
- صادرات ارائه
- تبدیل PowerPoint
- تبدیل OpenDocument
- تبدیل ارائه
- PowerPoint به XAML
- OpenDocument به XAML
- ارائه به XAML
- PPT به XAML
- PPTX به XAML
- ODP به XAML
- ذخیره PPT به صورت XAML
- ذخیره PPTX به صورت XAML
- ذخیره ODP به صورت XAML
- صادرات PPT به XAML
- صادرات PPTX به XAML
- صادرات ODP به XAML
- پایتون
- جاوا
- Aspose.Slides
description: ارائه‌های PowerPoint و OpenDocument را با Aspose.Slides برای Python از طریق Java به XAML صادر کنید. از گزینه‌های پیش‌فرض استفاده کنید یا اسلایدهای مخفی را شامل کنید.
---
## **نمای کلی**

این مقاله توضیح می‌دهد چگونه ارائه‌های PowerPoint را به XAML با استفاده از Aspose.Slides برای Python از طریق Java صادر کنید. شامل مقدمه‌ای کوتاه درباره XAML است، نشان می‌دهد چگونه یک ارائه را با تنظیمات پیش‌فرض به XAML ذخیره کنید و نحوه سفارشی‌سازی خروجی را از طریق [XamlOptions](https://reference.aspose.com/slides/fa/python-java/aspose.slides/xamloptions/)، از جمله صادر کردن اسلایدهای مخفی، نشان می‌دهد. مقاله همچنین به برخی سؤالات رایج درباره قلم‌های جایگزین، سازگاری پشته XAML و رفتار صدور اسلایدهای مخفی پاسخ می‌دهد.

نمونه‌ها نیاز به Aspose.Slides برای Python از طریق Java و یک زمان‌اجرای Java سازگار دارند. فایل `pres.pptx` را در پوشه کاری فعلی قرار دهید. هر نمونه فقط در صورتی JVM را راه‌اندازی می‌کند که پیش از آن در حال اجرا نباشد.

## **درباره XAML**

XAML زبانی مبتنی بر XML است که برای توصیف رابط‌های کاربری در چارچوب‌هایی مانند WPF (Windows Presentation Foundation)، UWP (Universal Windows Platform) و Xamarin.Forms استفاده می‌شود.

می‌توانید با فایل‌های XAML در یک طراح بصری کار کنید یا مستقیماً علامت‌گذاری را بنویسید و ویرایش کنید.

## **صادرات ارائه‌ها به XAML با گزینه‌های پیش‌فرض**

مثال پایتون زیر نشان می‌دهد چگونه یک ارائه را با تنظیمات پیش‌فرض به XAML صادر کنید:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, XamlOptions

presentation = Presentation("pres.pptx")
try:
    xaml_options = XamlOptions()
    presentation.save(xaml_options)
finally:
    presentation.dispose()
```

به طور پیش‌فرض، اسلایدهای صادر شده در زیرپوشه‌ای به نام `pres` در پوشه کاری فعلی فرآیند ذخیره می‌شوند. این پوشه به‌صورت خودکار ساخته می‌شود و هر تصویر مورد نیاز نیز در همانجا ذخیره می‌شود.

نام پوشه خروجی از نام فایل منبع بدون پسوند گرفته می‌شود. برای `pres.pptx`، فایل‌های خروجی به شکل `pres/Slide_1.xaml`، `pres/Slide_2.xaml` و به همین ترتیب نامگذاری می‌شوند. حتی اگر مسیر مطلقی به ارائه ورودی بدهید، پوشه خروجی نسبت به پوشه کاری فعلی ایجاد می‌شود، نه در کنار فایل ورودی.

## **صادرات ارائه‌ها به XAML با گزینه‌های سفارشی**

از کلاس [XamlOptions](https://reference.aspose.com/slides/fa/python-java/aspose.slides/xamloptions/) برای کنترل نحوهٔ صادرات Aspose.Slides یک ارائه به XAML استفاده کنید.

برای ذخیره خروجی در مکان دلخواه، `IXamlOutputSaver` را پیاده‌سازی کنید و یک نمونه از پیاده‌سازی خود را به متد [setOutputSaver](https://reference.aspose.com/slides/fa/python-java/aspose.slides/xamloptions/#setOutputSaver) از [XamlOptions](https://reference.aspose.com/slides/fa/python-java/aspose.slides/xamloptions/) پاس دهید.

برای گنجاندن اسلایدهای مخفی در خروجی XAML، `True` را به متد [setExportHiddenSlides](https://reference.aspose.com/slides/fa/python-java/aspose.slides/xamloptions/#setExportHiddenSlides) پاس دهید، همان‌طور که در مثال پایتون زیر نشان داده شده است:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, XamlOptions

presentation = Presentation("pres.pptx")
try:
    xaml_options = XamlOptions()
    xaml_options.setExportHiddenSlides(True)
    presentation.save(xaml_options)
finally:
    presentation.dispose()
```

## **ثبت تمام آرتیفکت‌های تولید شده XAML**

صادر کردن XAML می‌تواند برای هر اسلاید صادر شده یک سند XAML به‌همراه تصاویر جداگانه و منابع پشتیبانی تولید کند. یک `IXamlOutputSaver` سفارشی را به `[XamlOptions.setOutputSaver](https://reference.aspose.com/slides/fa/python-java/aspose.slides/xamloptions/#setOutputSaver)` اختصاص دهید تا این آرتیفکت‌ها را به‌جای استفاده از ذخیره‌کنندهٔ پیش‌فرض فایل‌سیستم دریافت کنید. صادرات را با overload مخصوص XAML از متد `[Presentation.save](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#save)` که گزینه‌های XAML را می‌پذیرد، آغاز کنید.

در پایتون، از `jpype.JProxy` برای پیاده‌سازی اینترفیس جاوا `IXamlOutputSaver` استفاده کنید. مسیر callback را به `str` تبدیل کنید و آرایهٔ بایتی جاوا را قبل از بازگرداندن به `bytes` پایتون کپی کنید، همان‌طور که در زیر نشان داده شده است.

### **درک چرخهٔ حیات Callback**

صادرکننده برای هر آرتیفکت تولید شده متد `IXamlOutputSaver.save` را به‌طور جداگانه فراخوانی می‌کند:

- `path` آرتیفکت را شناسایی می‌کند و ممکن است شامل پوشه‌های نسبی باشد. این اطلاعات را حفظ کنید زیرا XAML ممکن است منابع را با مسیرهای نسبی ارجاع دهد.
- `data` شامل بایت‌های آرتیفکت است. تصاویر و سایر منابع باینری نباید به‌صورت متن رمزگشایی شوند.
- ذخیره‌کننده مسئول حفظ یا پایدارسازی داده قبل از بازگشت است. نمونه‌ها هر آرایهٔ بایتی را در حافظهٔ متعلق به برنامه کپی می‌کنند.
- صادرات فقط زمانی موفق تلقی می‌شود که عملیات ذخیرهٔ ارائه بازگردد و هر callback به‌صورت موفقیت‌آمیز پایان یابد. خطاهای ذخیره‌سازی را نادیده نگیرید و نوشتن پس‌زمینهٔ بدون نظارت را شروع نکنید. اگر پایدارسازی بعداً انجام شد، موفقیت کلی تنها پس از موفقیت آن گام گزارش شود.

`[XamlOptions.setExportHiddenSlides](https://reference.aspose.com/slides/fa/python-java/aspose.slides/xamloptions/#setExportHiddenSlides)` نیز برای ذخیره‌کنندهٔ سفارشی اعمال می‌شود. تنظیم پیش‌فرض `False` اسناد XAML اسلایدهای مخفی را حذف می‌کند. پاس کردن `True` آن‌ها و هر منبع مورد نیاز برای صادراتشان را شامل می‌شود. تعداد منابع به ارائه بستگی دارد؛ فرض نکنید یک callback برای هر اسلاید یا ترتیب ثابت callback وجود دارد.

### **صادرات به حافظه و بررسی آرتیفکت‌ها**

این مثال کامل `pres.pptx` را بارگذاری می‌کند، هر آرتیفکت را در یک دیکشنری پایتون از نام‌ها و مقادیر `bytes` غیرقابل تغییر جمع‌آوری می‌کند و نام، نوع و تعداد بایت آن را چاپ می‌کند. نام‌های ارائه‌شده دقیقاً حفظ می‌شوند. نام‌های تکراری مجموعه را نامعتبر می‌سازند به‌جای اینکه به‌ساکن‌گی آرتیفکت بنویسند. مثال قبل از استفاده از نتایج این موضوع را بررسی می‌کند.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, XamlOptions

class MemoryXamlSaver:
    def __init__(self):
        self.artifacts = {}
        self.valid = True

    def save(self, path, data):
        name = str(path)
        if name in self.artifacts:
            self.valid = False
            print(f"Export rejected: duplicate artifact name: {name}")
            return
        self.artifacts[name] = bytes(data)

def main():

    saver = MemoryXamlSaver()
    output_saver = jpype.JProxy("com.aspose.slides.IXamlOutputSaver", inst=saver)
    presentation = Presentation("pres.pptx")
    try:
        options = XamlOptions()
        options.setOutputSaver(output_saver)
        options.setExportHiddenSlides(True)
        presentation.save(options)
    finally:
        presentation.dispose()

    if not saver.valid:
        print("Export rejected: the artifact collection is invalid.")
        return

    inspect_xaml_text = False
    image_extensions = (".png", ".jpg", ".jpeg", ".gif", ".bmp", ".tif", ".tiff", ".svg")
    for name, data in saver.artifacts.items():
        lower_name = name.lower()
        is_xaml = lower_name.endswith(".xaml")
        is_image = lower_name.endswith(image_extensions)
        kind = "slide XAML" if is_xaml else "image" if is_image else "supporting resource"
        print(f"{name}: {len(data)} bytes ({kind})")

        # فقط XAML را رمزگشایی کنید و تنها زمانی که نیاز به بازرسی متنی باشد.
        if is_xaml and inspect_xaml_text:
            markup = data.decode("utf-8")
            print(markup)


main()
```

بررسی پسوندها برای بازرسی مفید است؛ تمام آرتیفکت‌ها، از جمله انواع منابع ناشناخته، حفظ شوند. هنگام ذخیره یا انتقال بایت‌ها آن‌ها را دست‌نخورده باقی بگذارید. برای XAML که نیاز به پردازش متنی دارد، فقط از `bytes.decode` با UTF-8 استفاده کنید.

### **بسته‌بندی آرتیفکت‌های جمع‌آوری‌شده در یک آرشیو ZIP**

این مثال مستقل صادرات را جمع‌آوری، نام‌ها را اعتبارسنجی و بایت‌های اصلی را در یک آرشیو ZIP می‌نویسد. نام آرشیو منحصر به فرد، کارهای صادراتی همزمان را جدا می‌کند. ورودی‌های ZIP از اسلش‌های مستقیم استفاده می‌کنند و پوشه‌های نسبی را حفظ می‌کنند. نام‌های ناایمن یا نام‌هایی که پس از نرمال‌سازی تداخل دارند، قبل از نوشتن کل بسته را رد می‌کنند.

```python
from uuid import uuid4
from zipfile import ZipFile

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, XamlOptions

class MemoryXamlSaver:
    def __init__(self):
        self.artifacts = {}
        self.valid = True

    def save(self, path, data):
        name = str(path)
        if name in self.artifacts:
            self.valid = False
            print(f"Export rejected: duplicate artifact name: {name}")
            return
        self.artifacts[name] = bytes(data)

def main():

    saver = MemoryXamlSaver()
    output_saver = jpype.JProxy("com.aspose.slides.IXamlOutputSaver", inst=saver)
    presentation = Presentation("pres.pptx")
    try:
        options = XamlOptions()
        options.setOutputSaver(output_saver)
        options.setExportHiddenSlides(False)
        presentation.save(options)
    finally:
        presentation.dispose()

    if not saver.valid:
        print("Export rejected: the artifact collection is invalid.")
        return

    entries = {}
    entry_names = set()
    for name, data in saver.artifacts.items():
        entry_name = name.replace("\\", "/")
        segments = entry_name.split("/")
        unsafe_name = entry_name.startswith("/") or ":" in entry_name or "\x00" in entry_name
        unsafe_name |= any(not segment.strip() or segment in (".", "..") for segment in segments)
        normalized_name = entry_name.casefold()
        if unsafe_name or normalized_name in entry_names:
            print(f"Export rejected: unsafe or duplicate artifact name: {name}")
            return
        entry_names.add(normalized_name)
        entries[entry_name] = data

    job_id = uuid4()
    archive_path = f"xaml-{job_id}.zip"
    try:
        with ZipFile(archive_path, mode="x") as archive:
            for name, data in entries.items():
                archive.writestr(name, data)

        # بستن، فهرست ZIP را پیش از گزارش موفقیت نهایی نهایی می‌کند.
        print(f"Saved {len(entries)} artifacts to {archive_path}")
    except OSError as exception:
        print(f"Archive persistence failed: {exception}")


main()
```

مثال از `zipfile.ZipFile` پایتون برای نوشتن یک آرشیو محلی استفاده می‌کند؛ خود صادرکننده فایل‌های XAML یا تصویر جداگانه‌ای نمی‌نویسد. برای ذخیره‌سازی از راه دور، مرحلهٔ نوشتن آرشیو را با بارگذاری آرایه‌های بایتی جمع‌آوری‌شده جایگزین کنید. از یک شناسهٔ کار‑صادرات به‌علاوه نام نسبی کامل آرتیفکت به‌عنوان کلید blob استفاده کنید یا شناسهٔ کار، نام نسبی و داده باینری را در یک ردیف دیتابیس ذخیره کنید. پس از تکمیل همه بارگذاری‌ها یا Commit تراکنش دیتابیس، کار را منتشر کنید. در صورت شکست پایدارسازی، خروجی جزئی را پاک کنید.

برای ارائه‌های بزرگ، یک ذخیره‌کنندهٔ سفارشی می‌تواند هر آرتیفکت را مستقیماً در ذخیره‌سازی برنامه پایدار کند تا نیازی به نگهداری یک نسخهٔ اضافی از کل صادرات در حافظه برنامه نباشد. هر callback را از دید صادرکننده به‌صورت همگام حفظ کنید: فقط پس از این‌که مقصد بایت‌ها را پذیرفت بازگردید و اجازه دهید خطاها به فراخواننده برسند.

### **حفظ نام‌های منابع و تأیید ارجاعات**

- جداکننده‌های مسیر را هنگام نیاز مقصد نرمال کنید، اما پوشه‌های نسبی را حفظ کنید. مگر اینکه مطمئن باشید هر نام تولید شده یکتا است و ارجاعات منابع معتبر می‌مانند، از `pathlib.Path.name` به‌تنهایی استفاده نکنید.
- اعتبارسنجی نام بر اساس مقصد اعمال کنید. هنگام نوشتن فایل‌های منفصل، مسیرهای ریشه‌ای و بخش‌های پیمایش را رد کنید، مقصد را با `pathlib.Path.resolve` حل کنید و اطمینان حاصل کنید که زیر پوشهٔ هدف صادرات باقی می‌ماند، شامل جداکنندهٔ مسیر در بررسی containment. از یک پوشهٔ تحت کنترل برنامه بدون لینک‌های نمادین که ممکن است نوشتن را بازجهت‌دهی کنند استفاده کنید.
- برای هر کار صادرات یک ذخیره‌کننده و فضای نام ذخیره‌سازی جداگانه استفاده کنید. پس از نرمال‌سازی جداکننده‌ها و براساس قوانین حساسیت به حروف مقصد، تداخل‌ها را شناسایی کنید.
- پیش از انتشار، هر سند XAML را به‌عنوان XML تجزیه کنید و ارجاعات منابع مبتنی بر فایل مانند خصوصیات `Source` یا `ImageSource` تصویر را بررسی کنید. هر URI نسبی را نسبت به پوشهٔ آرتیفکت XAML حاوی آن حل کنید، نام ذخیرهٔ حاصل را نرمال کنید و تأیید کنید که کلید نقشهٔ مربوطه، ورودی ZIP یا شیء ذخیره‌شده وجود دارد. URI‌های خارجی و عبارات علامت‌گذاری XAML را جدا از نام‌های فایل نسبی در نظر بگیرید.

به‌عنوان مثال، اگر `pres/Slide_1.xaml` به `images/image1.png` ارجاع دهد، منبع ذخیره‌شده باید به‌صورت `pres/images/image1.png` در دسترس باشد. نگهداری فقط `image1.png` آن رابطه را می‌شکند. برای ذخیره‌سازی شیء، همان ساختار زیر پیشوند کار را حفظ کنید و آن URLهای منابع را برای مصرف‌کنندهٔ XAML قابل دسترسی کنید. ZIP کامل‌شده را باز کنید تا نام‌های ورودی و بایت‌های منابع را تأیید کنید و اسلایدهای نماینده را در محیط هدف XAML بارگذاری کنید تا تأیید شود که تصاویر به‌درستی حل می‌شوند.

## **سوالات متداول**

**چگونه می‌توانم اطمینان حاصل کنم که قلم‌ها پیش‌بینی‌پذیر هستند اگر قلم اصلی روی ماشین موجود نباشد؟**

در `[XamlOptions](https://reference.aspose.com/slides/fa/python-java/aspose.slides/xamloptions/)` متد `[setDefaultRegularFont](https://reference.aspose.com/slides/fa/python-java/aspose.slides/saveoptions/#setDefaultRegularFont)` را فراخوانی کنید — این قلم به عنوان قلم جایگزین هنگام صادرات استفاده می‌شود وقتی قلم اصلی موجود نباشد. این تضمین نمی‌کند که XAML تولیدی قلم جایگزین را ارجاع دهد یا قلم روی ماشین هدف موجود باشد. اطمینان حاصل کنید که قلم‌های ارجاع شده در محیطی که XAML نمایش داده می‌شود، موجود باشند.

**آیا XAML صادر شده فقط برای WPF منظور شده یا می‌تواند در سایر پشته‌های XAML نیز استفاده شود؟**

Aspose.Slides XAML WPF را از طریق API عمومی خود صادر می‌کند. سازگاری با سایر پشته‌های XAML مانند UWP و Xamarin.Forms تضمین نشده است. markup تولید شده را در محیط هدف خود تست کنید.

**آیا اسلایدهای مخفی پشتیبانی می‌شوند و چگونه می‌توانم از صادرات پیش‌فرض آن‌ها جلوگیری کنم؟**

به‌طور پیش‌فرض اسلایدهای مخفی گنجانده نمی‌شوند. می‌توانید این رفتار را از طریق `[setExportHiddenSlides](https://reference.aspose.com/slides/fa/python-java/aspose.slides/xamloptions/#setExportHiddenSlides)` در `[XamlOptions](https://reference.aspose.com/slides/fa/python-java/aspose.slides/xamloptions/)` کنترل کنید — اگر نیازی به صادرات آن‌ها ندارید، این گزینه را غیرفعال نگه دارید.