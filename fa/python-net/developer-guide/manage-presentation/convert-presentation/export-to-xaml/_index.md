---
title: استخراج ارائه‌ها به XAML با Python
linktitle: ارائه به XAML
type: docs
weight: 30
url: /fa/python-net/export-to-xaml/
keywords:
- استخراج PowerPoint
- استخراج OpenDocument
- استخراج ارائه
- تبدیل PowerPoint
- تبدیل OpenDocument
- تبدیل ارائه
- PowerPoint به XAML
- OpenDocument به XAML
- ارائه به XAML
- PPT به XAML
- PPTX به XAML
- ODP به XAML
- ذخیره PPT به عنوان XAML
- ذخیره PPTX به عنوان XAML
- ذخیره ODP به عنوان XAML
- استخراج PPT به XAML
- استخراج PPTX به XAML
- استخراج ODP به XAML
- Python
- Aspose.Slides
description: "اسلایدهای PowerPoint و OpenDocument را به XAML با Python و با استفاده از Aspose.Slides تبدیل کنید — راه‌حل سریع و بدون Office که چیدمان شما را دست نخورده نگه می‌دارد."
---
## **مرور کلی**

این مقاله نحوهٔ استخراج ارائه‌های PowerPoint به XAML با استفاده از Aspose.Slides را توضیح می‌دهد. شامل مقدمه‌ای کوتاه دربارهٔ XAML است، نشان می‌دهد چگونه یک ارائه را با تنظیمات پیش‌فرض به XAML ذخیره کنید و چگونگی سفارشی‌سازی استخراج را از طریق [XamlOptions](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export.xaml/xamloptions/) به نمایش می‌گذارد، از جمله استخراج اسلایدهای مخفی. مقاله همچنین به چند سؤال رایج دربارهٔ فونت‌های جایگزین، سازگاری پشتهٔ XAML و رفتار استخراج اسلایدهای مخفی پاسخ می‌دهد.

## **دربارهٔ XAML**

XAML زبانی مبتنی بر XML است که برای توصیف رابط‌های کاربری در چارچوب‌هایی مانند WPF (Windows Presentation Foundation)، UWP (Universal Windows Platform) و Xamarin.Forms استفاده می‌شود.

می‌توانید با یک طراح بصری با فایل‌های XAML کار کنید یا مارکاپ را به‌صورت مستقیم بنویسید و ویرایش کنید.

## **استخراج ارائه‌ها به XAML با گزینه‌های پیش‌فرض**

مثال Python زیر نشان می‌دهد چگونه یک ارائه را با تنظیمات پیش‌فرض به XAML استخراج کنید:

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    xaml_options = slides.export.xaml.XamlOptions()
    presentation.save(xaml_options)
```

به‌صورت پیش‌فرض، اسلایدهای استخراج‑شده در زیرپوشهٔ `pres` مسیر کاری فعلی فرآیند، که توسط [os.getcwd](https://docs.python.org/3/library/os.html#os.getcwd) برگردانده می‌شود، ذخیره می‌شوند. این پوشه به‌صورت خودکار ایجاد می‌شود و هر تصویر مورد نیاز نیز در همان‌جا ذخیره می‌گردد.

نام پوشهٔ خروجی از نام فایل منبع بدون پسوند آن گرفته می‌شود. برای `pres.pptx`، فایل‌های خروجی به‌صورت `pres/Slide_1.xaml`، `pres/Slide_2.xaml` و غیره نام‌گذاری می‌شوند. حتی اگر مسیر مطلقی به ارائهٔ ورودی بدهید، پوشهٔ خروجی نسبت به مسیر کاری فعلی ایجاد می‌شود، نه در کنار فایل ورودی.

## **استخراج ارائه‌ها به XAML با گزینه‌های سفارشی**

از کلاس [XamlOptions](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export.xaml/xamloptions/) برای کنترل نحوهٔ استخراج Aspose.Slides به XAML استفاده کنید.

برای گنجاندن اسلایدهای مخفی در خروجی XAML، ویژگی [export_hidden_slides](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export.xaml/xamloptions/export_hidden_slides/) را برابر `True` قرار دهید، همان‌طور که در مثال Python زیر نشان داده شده است:

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    xaml_options = slides.export.xaml.XamlOptions()
    xaml_options.export_hidden_slides = True
    presentation.save(xaml_options)
```

## **ضبط تمام مصنوعات تولید‑شدهٔ XAML**

یک استخراج XAML می‌تواند برای هر اسلاید استخراج‑شده یک سند XAML به‌همراه تصاویر جداگانه و منابع پشتیبان تولید کند. هنگام ذخیره یا انتقال یک استخراج، همهٔ این فایل‌ها را نگه دارید.

مثال‌های زیر از ذخیره‌کنندهٔ پیش‌فرض فایل‑سیستم در یک پوشهٔ موقت استفاده می‌کنند، سپس فایل‌های تولید‌شده را جمع‌آوری می‌نمایند.

### **درک چرخهٔ حیات استخراج**

- استخراج را با بارگذاری مخصوص XAML متد [Presentation.save](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/save/) که گزینه‌های XAML را می‌پذیرد، آغاز کنید. فایل‌های تولید‌شده را تنها پس از بازگشت موفق این متد بخوانید.
- مسیر نسبی هر اثر را حفظ کنید زیرا XAML ممکن است منابع را با مسیرهای نسبی ارجاع دهد.
- اثرها را به‌عنوان بایت بخوانید. تصاویر و سایر منابع باینری نباید به‌عنوان متن رمزگشایی شوند.
- گزارش موفقیت کلی فقط پس از تکمیل جمع‌آوری و هر عملیات ذخیره‌سازی پس‌ازآن باشد. خطاهای ذخیره‌سازی باید به فراخوانده برسند و در صورت شکست پایداری، خروجی جزئی پاک شود.

[export_hidden_slides](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export.xaml/xamloptions/export_hidden_slides/) در XamlOptions به‌صورت پیش‌فرض `False` است که اسناد XAML اسلایدهای مخفی را حذف می‌کند. تنظیم آن به `True` این اسناد و هر منبع مورد نیاز برای استخراج آن‌ها را شامل می‌شود. تعداد منابع به ارائه بستگی دارد؛ فرض نکنید برای هر اسلاید یک فایل وجود دارد.

{{% alert color="warning" title="Warning" %}}
مثال‌ها به‌صورت موقت مسیر کاری فعلی فرآیند را تغییر می‌دهند که بر تمام رشته‌ها تأثیر می‌گذارد. هر استخراج را در یک فرآیند کارگر جداگانه اجرا کنید یا اطمینان حاصل کنید که در طول استخراج هیچ کار دیگری به مسیر کاری فعلی وابسته نیست. داشتن یک پوشهٔ موقت منحصر به فرد به تنهایی استخراج‌های هم‌زمان در همان فرآیند را ایمن نمی‌کند.
{{% /alert %}}

### **استخراج به حافظه و بررسی مصنوعات**

این مثال کامل `pres.pptx` را بارگذاری می‌کند، به یک پوشهٔ موقت استخراج می‌نماید، هر اثر را در یک دیکشنری از نام‌های نسبی و بایت‌ها جمع‌آوری می‌کند و نام، نوع و تعداد بایت آن را چاپ می‌نماید. ساختار پوشهٔ تولید‌شده را حفظ می‌کند و پس از جمع‌آوری فایل‌های موقت را حذف می‌نماید. مسیر ورودی قبل از تغییر مسیر کاری حل می‌شود.

```python
import os
from pathlib import Path
from tempfile import TemporaryDirectory

import aspose.slides as slides


def collect_xaml_artifacts(source_path, export_hidden_slides):
    source_path = Path(source_path).resolve()
    original_directory = Path.cwd()
    artifacts = {}

    with TemporaryDirectory(prefix="xaml-") as temporary_directory:
        try:
            os.chdir(temporary_directory)
            with slides.Presentation(str(source_path)) as presentation:
                options = slides.export.xaml.XamlOptions()
                options.export_hidden_slides = export_hidden_slides
                presentation.save(options)

            for artifact_path in Path(temporary_directory).rglob("*"):
                if artifact_path.is_file():
                    relative_path = artifact_path.relative_to(temporary_directory)
                    artifacts[relative_path.as_posix()] = artifact_path.read_bytes()
        finally:
            os.chdir(original_directory)

    return artifacts


artifacts = collect_xaml_artifacts("pres.pptx", True)
inspect_xaml_text = False
image_extensions = {".png", ".jpg", ".jpeg", ".gif", ".bmp", ".tif", ".tiff", ".svg"}
for name, data in artifacts.items():
    extension = Path(name).suffix.lower()
    if extension == ".xaml":
        kind = "slide XAML"
    elif extension in image_extensions:
        kind = "image"
    else:
        kind = "supporting resource"
    print(f"{name}: {len(data)} bytes ({kind})")

    # فقط XAML را رمزگشایی کنید و فقط وقتی که نیاز به بازرسی متنی باشد.
    if extension == ".xaml" and inspect_xaml_text:
        print(data.decode("utf-8"))
```

بررسی پسوندها برای بازرسی مفید است؛ همهٔ آثار، از جمله انواع منبع نام‌آشنا را نگه دارید. هنگام ذخیره یا انتقال بایت‌ها را دست نخورده بگذارید. فقط XAMLی که به پردازش متنی نیاز دارد را رمزگشایی کنید. این روش از فضای دیسک موقت و حافظه برای جمع‌آوری استخراج استفاده می‌کند.

### **بسته‌‌بندی آثار جمع‌آوری‌شده در یک آرشیو ZIP**

این مثال مستقل استخراج را جمع‌آوری می‌کند، نام‌ها را اعتبارسنجی می‌کند و بایت‌های اصلی را در یک آرشیو ZIP می‌نویسد. نام آرشیو منحصر به فرد، کارهای استخراج را تفکیک می‌کند. ورودی‌های ZIP از اسلش‌های پیشرو استفاده می‌کنند و دایرکتوری‌های نسبی را حفظ می‌کنند. نام‌های ناامن یا نام‌هایی که پس از نرمال‌سازی برخورد می‌کنند، کل بسته را پیش از نوشتن رد می‌نمایند.

```python
from uuid import uuid4
from zipfile import ZIP_DEFLATED, ZipFile
import os
from pathlib import Path
from tempfile import TemporaryDirectory

import aspose.slides as slides


def collect_xaml_artifacts(source_path, export_hidden_slides):
    source_path = Path(source_path).resolve()
    original_directory = Path.cwd()
    artifacts = {}

    with TemporaryDirectory(prefix="xaml-") as temporary_directory:
        try:
            os.chdir(temporary_directory)
            with slides.Presentation(str(source_path)) as presentation:
                options = slides.export.xaml.XamlOptions()
                options.export_hidden_slides = export_hidden_slides
                presentation.save(options)

            for artifact_path in Path(temporary_directory).rglob("*"):
                if artifact_path.is_file():
                    relative_path = artifact_path.relative_to(temporary_directory)
                    artifacts[relative_path.as_posix()] = artifact_path.read_bytes()
        finally:
            os.chdir(original_directory)

    return artifacts


def package_xaml():
    artifacts = collect_xaml_artifacts("pres.pptx", False)
    entries = {}
    normalized_names = set()
    for name, data in artifacts.items():
        entry_name = name.replace("\\", "/")
        segments = entry_name.split("/")
        unsafe_name = entry_name.startswith("/") or ":" in entry_name
        unsafe_name = unsafe_name or any(not segment.strip() or segment in {".", ".."} for segment in segments)
        normalized_name = entry_name.casefold()
        if unsafe_name or normalized_name in normalized_names:
            print(f"Export rejected: unsafe or duplicate artifact name: {name}")
            return
        normalized_names.add(normalized_name)
        entries[entry_name] = data

    archive_path = Path(f"xaml-{uuid4().hex}.zip")
    with ZipFile(archive_path, "x", compression=ZIP_DEFLATED) as archive:
        for name, data in entries.items():
            archive.writestr(name, data)

    # The ZIP directory has been finalized before reporting success.
    print(f"Saved {len(entries)} artifacts to {archive_path}")


package_xaml()
```

مثال از [ZipFile](https://docs.python.org/3/library/zipfile.html#zipfile.ZipFile) برای نوشتن یک آرشیو محلی پس از جمع‌آوری استخراج موقت استفاده می‌کند. برای ذخیره‌سازی از راه دور، مرحلهٔ نوشتن آرشیو را با بارگذاری بایت‌های جمع‌آوری‌شده جایگزین کنید. از شناسهٔ کار استخراج به‌همراه نام نسبی کامل اثر به‌عنوان کلید شیء استفاده کنید یا شناسهٔ کار، نام نسبی و داده‌های باینری را در ردیف دیتابیس ذخیره کنید. پس از تکمیل تمام بارگذاری‌ها یا تراکنش دیتابیس، کار را منتشر کنید. در صورت شکست پایداری، خروجی جزئی را پاک کنید.

برای ارائه‌های بزرگ، پس از استخراج فایل‌های موقت را یکی‌یکی پردازش کنید به‌جای جمع‌آوری تمام بایت‌ها در یک دیکشنری. این کار از یک کپی حافظه‌ای اضافی از کل استخراج جلوگیری می‌کند، اما نیازهای حافظهٔ استخراج‌کننده را حذف نمی‌کند.

### **حفظ نام‌های منبع و تأیید ارجاعات**

- هنگام نیاز به نرمال‌سازی جداکننده‌های مسیر، آن‌ها را نرمال کنید، اما دایرکتوری‌های نسبی را حفظ کنید. مگر اینکه مطمئن باشید هر نام تولید شده یکتا است و ارجاعات منبع معتبر می‌مانند، فقط نام فایل نهایی را نگه ندارید.
- اعتبارسنجی نام مخصوص مقصد را اعمال کنید. هنگام نوشتن فایل‌های منفرد، مسیرهای مطلق و بخش‌های مرور (traversal) را رد کنید، مقصد را حل کنید و اطمینان حاصل کنید که زیر دایرکتوری مورد نظر استخراج باقی می‌ماند. از دایرکتوری تحت کنترل برنامه بدون پیوندهای نمادین استفاده کنید که ممکن است نوشتار را به مسیر دیگری هدایت کنند.
- برای هر کار استخراج یک فضای نام ذخیره‌سازی جداگانه استفاده کنید. پس از نرمال‌سازی جداکننده‌ها و وفقاً قوانین حساسیت به حروف مقصد، برخوردها را شناسایی کنید.
- پیش از انتشار، هر سند XAML را به‌عنوان XML تجزیه کنید و ارجاعات منبع مبتنی بر فایل آن مانند ویژگی‌های `Source` یا `ImageSource` تصویر را بررسی کنید. هر URI نسبی را نسبت به دایرکتوری اثر XAML حاوی آن حل کنید، نام ذخیره‌سازی حاصل را نرمال کنید و تأیید کنید که کلید دیکشنری مربوطه، ورودی ZIP یا شیء ذخیره‌شده وجود دارد. URIهای خارجی و عبارات مارکاپ XAML را جدا از نام‌های فایل نسبی در نظر بگیرید.

به‌عنوان مثال، اگر `pres/Slide_1.xaml` به `images/image1.png` ارجاع دهد، منبع ذخیره‌شده باید به‌صورت `pres/images/image1.png` در دسترس باشد. نگه داشتن فقط `image1.png` می‌تواند این رابطه را خراب کند. برای ذخیره‌سازی شیء، همان‌چیدمان زیر پیشوند کار را حفظ کنید و اطمینان دهید که URLهای منبع برای مصرف‌کنندهٔ XAML قابل دسترس هستند. ZIP کامل را دوباره باز کنید تا نام ورودی‌ها و بایت‌های منبع را تأیید کنید و اسلایدهای نماینده را در محیط XAML هدف بارگذاری کنید تا اطمینان یابید تصاویر به‌درستی حل می‌شوند.

## **سوالات متداول**

**چگونه می‌توانم فونت‌های پیش‌بینی‌شده را تضمین کنم اگر فونت اصلی روی ماشین موجود نباشد؟**

در [XamlOptions](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export.xaml/xamloptions/) ویژگی [default_regular_font](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export.xaml/xamloptions/default_regular_font/) را تنظیم کنید؛ این فونت به‌عنوان جایگزین در هنگام استخراج استفاده می‌شود وقتی فونت اصلی موجود نباشد. این کار تضمین نمی‌کند که XAML تولید‑شده به‌صورت واضح به فونت جایگزین ارجاع دهد یا اینکه فونت بر روی ماشین هدف موجود باشد. اطمینان حاصل کنید فونت‌های ارجاع‌داده‌شده توسط XAML در محیطی که نمایش داده می‌شود موجود هستند.

**آیا XAML استخراج‑شده فقط برای WPF است یا می‌توان آن را در سایر پشته‌های XAML نیز استفاده کرد؟**

Aspose.Slides XAML برای WPF را از طریق API عمومی خود استخراج می‌کند. سازگاری با سایر پشته‌های XAML مانند UWP و Xamarin.Forms تضمین نشده است. مارکاپ تولیدشده را در محیط هدف خود آزمایش کنید.

**آیا اسلایدهای مخفی پشتیبانی می‌شوند و چطور می‌توان از استخراج پیش‌فرض آن‌ها جلوگیری کرد؟**

به‌صورت پیش‌فرض اسلایدهای مخفی گنجانده نمی‌شوند. می‌توانید این رفتار را از طریق [export_hidden_slides](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export.xaml/xamloptions/export_hidden_slides/) در [XamlOptions](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export.xaml/xamloptions/) کنترل کنید — اگر نیازی به استخراج آن‌ها ندارید، این گزینه را غیرفعال بمانید.