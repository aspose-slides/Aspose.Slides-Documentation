---
title: نصب
type: docs
weight: 70
url: /fa/python-net/installation/
keywords:
- دانلود Aspose.Slides
- نصب Aspose.Slides
- استفاده از Aspose.Slides
- نصب Aspose.Slides
- pip
- PyPI
- ویندوز
- لینوکس
- macOS
- پایتون
description: "Aspose.Slides برای Python از طریق .NET را از PyPI با pip بر روی ویندوز، لینوکس و macOS نصب کنید و کتابخانه‌های بومی که لینوکس و macOS نیاز دارند نصب کنید."
---
## **بررسی کلی**

این مقاله نحوه نصب Aspose.Slides برای Python از طریق .NET را در ویندوز، لینوکس و macOS توضیح می‌دهد. این بسته در [PyPI](https://pypi.org/project/aspose.slides/) منتشر شده و با pip نصب می‌شود. زمان اجرا (.NET runtime) مورد نیاز در بسته گنجانده شده است، بنابراین نیازی به نصب .NET ندارید. در لینوکس و macOS، این زمان اجرا به کتابخانه‌های بومی نیاز دارد که ممکن است در سیستم عامل گنجانده نشده باشند؛ بخش‌های زیر نام آن‌ها را آورده‌اند.

Aspose.Slides برای Python از طریق .NET از Python 3.5 تا 3.14 پشتیبانی می‌کند. PyPI بسته‌هایی برای ویندوز (32‑بیتی و 64‑بیتی)، لینوکس (x86_64 و ARM64) و macOS (اینتل و Apple silicon) فراهم می‌کند.

## **ویندوز**

در ویندوز، بسته را با pip نصب کنید. کتابخانهٔ دیگری لازم نیست.

```bash
pip install aspose.slides
```

## **لینوکس**

در لینوکس، زمان اجرا .NET که در بسته گنجانده شده به دو کتابخانه نیاز دارد:

- **libgdiplus**، پیاده‌سازی API گرافیکی Windows GDI+. بدون آن، ذخیرهٔ ارائه‌نامه با خطای `The type initializer for 'Gdip' threw an exception` مواجه می‌شود.
- **ICU** (International Components for Unicode). بدون آن، فرآیند Python در اولین فراخوانی Aspose.Slides با پیام `Couldn't find a valid ICU package installed on the system` خاتمه می‌یابد.

در Debian و Ubuntu، هر دو را با apt نصب کنید:

```bash
sudo apt-get update && sudo apt-get install -y libgdiplus libicu76
```

نام بسته ICU شامل نسخهٔ آن است: `libicu76` بسته برای Debian 13 است. در Debian 12، به جای آن `libicu72` و در Ubuntu 24.04، `libicu74` نصب کنید. برای یافتن نام آن در سیستم خود، اجرا کنید:

```bash
apt-cache search --names-only '^libicu[0-9]+$'
```

سپس بسته را داخل یک محیط مجازی نصب کنید. در نسخه‌های فعلی Debian و Ubuntu، Python سیستم اجازهٔ `pip install` خارج از محیط مجازی را نمی‌دهد و با خطای `externally-managed-environment` متوقف می‌شود.

```bash
sudo apt-get install -y python3-venv
python3 -m venv .venv
. .venv/bin/activate
pip install aspose.slides
```

اسکریپت‌های خود را با فعال‌سازی همان محیط مجازی اجرا کنید. اگر از Python‌ای استفاده می‌کنید که توزیع شما مدیریت نمی‌کند، مانند Python موجود در تصویرهای رسمی `python` Docker، می‌توانید بدون محیط مجازی نیز `pip install aspose.slides` را اجرا کنید.

فونت‌های مورد استفاده در ارائه‌نامه‌ها یا جایگزین‌های مناسب آن‌ها باید بر روی سیستم نصب شوند تا هنگام تبدیل اسلایدها به PDF یا تصویر، متن به‌درستی رندر شود.

## **macOS**

نصب روی macOS را هنوز تأیید نکرده‌ایم. در macOS، Aspose.Slides به پیش‌نیازهای زیر نیاز دارد:

- **Python با کتابخانه‌های اشتراکی**، یعنی Python‌ای که با گزینهٔ پیکربندی `--enable-shared` ساخته شده باشد. اگر Python را با [pyenv](https://github.com/pyenv/pyenv#homebrew-in-macos) نصب می‌کنید، هنگام نصب یک نسخهٔ Python متغیر محیطی `PYTHON_CONFIGURE_OPTS` را روی `--enable-shared` تنظیم کنید.
- **کتابخانهٔ libpython در یک مسیر کتابخانهٔ سیستم**. Python نصب‌شده با pyenv کتابخانهٔ libpython خود را، مانند *libpython3.9.dylib*، در *~/.pyenv/versions* نگه می‌دارد؛ یک پیوند نمادین به آن در */usr/local/lib* ایجاد کنید.
- **libgdiplus**، پیاده‌سازی API گرافیکی Windows GDI+. Homebrew این کتابخانه را به صورت بستهٔ `mono-libgdiplus` فراهم می‌کند.

سپس بسته را با pip نصب کنید.

## **بررسی نصب**

برای بررسی نصب، مثال نخست را در [Create Presentations](/slides/fa/python-net/create-presentation/) به نام *hello.py* ذخیره کرده و `python hello.py` را اجرا کنید. این کار فایل *new_presentation.pptx* را در پوشهٔ جاری ذخیره می‌کند.

## **به‌روزرسانی**

برای به‌روزرسانی نصب موجود به آخرین نسخه، این فرمان را در محیطی که بسته را نصب کرده‌اید اجرا کنید:

```bash
pip install --upgrade aspose.slides
```

## **سؤالات رایج**

**آیا می‌توانم Aspose.Slides را در یک محیط مجازی نصب کنم؟**

بله. می‌توانید آن را در هر محیط مجازی Python با pip نصب کنید. کتابخانه‌های بومی که Linux و macOS نیاز دارند بر روی سیستم نصب می‌شوند، نه داخل محیط مجازی.

**آیا می‌توانم Aspose.Slides را در کانتینرهای Docker استفاده کنم؟**

بله. تصویر باید شامل همان کتابخانه‌های بومی همانند یک سیستم Linux باشد — libgdiplus و ICU — و همچنین فونت‌هایی که ارائه‌نامه‌های شما استفاده می‌کنند.

**آیا نسخهٔ رایگان یا محدودیت آزمایشی وجود دارد؟**

بله. بدون لایسنس، Aspose.Slides در حالت ارزیابی اجرا می‌شود: یک واترمارک ارزیابی به هر اسلایدی که ذخیره می‌کند اضافه می‌کند و متن خوانده‌شده از ارائه‌نامه‌ها را کوتاه می‌کند. برای حذف این محدودیت‌ها، یک [license](/slides/fa/python-net/licensing/) معتبر اعمال کنید.