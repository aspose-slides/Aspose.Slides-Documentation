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
- ویندوز
- macOS
- پایتون
description: "یاد بگیرید چگونه به سرعت Aspose.Slides برای Python از طریق .NET را نصب کنید. راهنمای گام به گام، نیازمندی‌های سیستم، و نمونه کد — امروز با ارائه‌های PowerPoint کار کنید!"
---
## **بررسی کلی**

پکیج Aspose.Slides for Python via .NET همراه با تمام کتابخانه‌های ضروری .NET ارائه می‌شود، به این معنی که نیازی به نصب جداگانه .NET نیست. این امر فرایند راه‌اندازی را ساده می‌کند و به توسعه‌دهندگان اجازه می‌دهد فوراً با ارائه‌ها کار کنند. با این حال، مهم است که توجه داشته باشید بسته به سیستم‌عامل یا محیط شما، ممکن است هنوز نیاز به نصب برخی وابستگی‌های خاص پلتفرم داشته باشید که .NET به آنها نیاز دارد. علاوه بر این، برای اطمینان از سازگاری کامل و عملکرد صحیح پکیج، برخی نیازمندی‌های سیستم باید برآورده شوند.

## **ویندوز**

**نیازمندی‌های سیستم**

اطمینان حاصل کنید که مشخصات ماشین شما حداقل یا بالاتر از [system requirements](/slides/fa/python-net/system-requirements/) باشد.

### **نصب Aspose.Slides**

`pip` آسان‌ترین راه برای دانلود و نصب [Aspose.Slides for Python via .NET](https://pypi.org/project/aspose-slides/) در ویندوز است.

برای نصب Aspose.Slides، فرمان زیر را اجرا کنید:

```sh
pip install aspose-slides
```

**استفاده از Aspose.Slides**

نصب Aspose.Slides خود را با اجرای کد زیر برای ایجاد یک ارائه PowerPoint تست کنید:

```python
# وارد کردن ماژول Aspose.Slides برای Python از طریق .NET.
import aspose.slides as slides

# ایجاد یک شی از کلاس Presentation که نمایانگر یک فایل ارائه است.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    slide.shapes.add_auto_shape(slides.ShapeType.LINE, 20, 20, 300, 200)
    presentation.save("NewPresentation.pptx", slides.export.SaveFormat.PPTX)
```

## **macOS**

**نیازمندی‌های سیستم**

اطمینان حاصل کنید که مشخصات ماشین شما حداقل یا بالاتر از [system requirements](/slides/fa/python-net/system-requirements/) باشد.

### **پیش‌نیازها**

**Python با کتابخانه‌های مشترک**

روش‌های متعددی برای نصب Python در macOS وجود دارد، اما ما قویاً توصیه می‌کنیم از [pyenv tool](https://github.com/pyenv/pyenv#homebrew-in-macos) استفاده کنید.

پس از نصب و پیکربندی **pyenv**، Python را با کتابخانه‌های مشترک با اجرای دستورات زیر در برنامه Terminal نصب کنید:

1. نصب Python:

```sh
env PYTHON_CONFIGURE_OPTS="--enable-shared" pyenv install --verbose 3.9.13
```

2. تنظیم به عنوان نسخه سراسری Python:

```sh
pyenv global 3.9.13
```

3. تنظیم به عنوان نسخه Python مختص شل:

```sh
pyenv shell 3.9.13
```

4. ایجاد یک لینک نمادین برای کتابخانه libpython در یک پوشه کتابخانه سیستم:

```sh
ln -s /Users/<username>/.pyenv/versions/3.9.13/lib/libpython3.9.dylib /usr/local/lib/libpython3.9.dylib
```

توجه: Python 3.5 یا بالاتر مورد نیاز است. در این مثال از نسخه 3.9.13 استفاده شده است.

**نصب کتابخانه libgdiplus**

کتابخانه **libgdiplus** پیاده‌سازی GDI+ ویندوز برای macOS و Linux است که .NET برای عملکرد گرافیکی روی این پلتفرم‌ها به آن وابسته است.
برای نصب این کتابخانه بر روی macOS، فرمان زیر را اجرا کنید:

```sh
brew install mono-libgdiplus
```

### **نصب Aspose.Slides**

`pip` آسان‌ترین راه برای دانلود و نصب [Aspose.Slides for Python via .NET](https://pypi.org/project/aspose-slides/) در macOS است.

برای نصب Aspose.Slides، فرمان زیر را اجرا کنید:

```sh
pip install aspose-slides
```

**استفاده از Aspose.Slides**

نصب Aspose.Slides خود را با اجرای کد زیر برای ایجاد یک ارائه PowerPoint تست کنید:

```python
# وارد کردن ماژول Aspose.Slides برای Python از طریق .NET.
import aspose.slides as slides

# ایجاد شیء از کلاس Presentation که نمایانگر یک فایل ارائه است.
with slides.Presentation() as presentation:    
    slide = presentation.slides[0]
    slide.shapes.add_auto_shape(slides.ShapeType.LINE, 20, 20, 300, 200)
    presentation.save("NewPresentation.pptx", slides.export.SaveFormat.PPTX)
```

## **پرسش‌های متداول**

**آیا می‌توانم Aspose.Slides را در یک محیط مجازی نصب کنم؟**

بله، می‌توانید آن را در هر محیط مجازی Python با استفاده از `pip` نصب کنید. فقط مطمئن شوید که محیط به وابستگی‌های بومی مورد نیاز بسته به سیستم‌عامل شما دسترسی دارد.

**آیا می‌توانم Aspose.Slides را در کانتینرهای Docker استفاده کنم؟**

بله، اما باید اطمینان حاصل کنید که تصویر Docker شما شامل کتابخانه‌های بومی مورد نیاز (**libgdiplus**، بسته‌های فونت و غیره) و نسخه صحیح Python باشد.

**آیا نسخه رایگان یا محدودیت آزمایشی وجود دارد؟**

بله، به طور پیش‌فرض Aspose.Slides در حالت ارزیابی اجرا می‌شود که واترمارک اضافه می‌کند و ممکن است محدودیت‌های دیگری داشته باشد. برای حذف این محدودیت‌ها باید یک [license](/slides/fa/python-net/licensing/) معتبر اعمال کنید.