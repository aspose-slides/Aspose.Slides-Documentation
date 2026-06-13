---
title: سازگاری با PyInstaller و cx_Freeze
linktitle: سازگاری با PyInstaller
type: docs
weight: 122
url: /fa/python-net/compatibility-with-pyinstaller/
keywords:
  - سازگاری
  - PyInstaller
  - cx_Freeze
  - Python
  - Aspose.Slides
description: "پکیج Aspose.Slides برای Python از طریق .NET را با PyInstaller باندل کنید. این راهنما را دنبال کنید تا برنامه خود را به‌صورت یک فایل اجرایی مستقل بسته‌بندی، پیکربندی و مشکلات آن را رفع کنید."
---
## **Introduction**

افزونه‌های Aspose.Slides for Python via .NET، افزونه‌های استاندارد C پایتون هستند، بنابراین می‌توانند به عنوان وابستگی‌های برنامه با ابزارهایی مانند PyInstaller و cx_Freeze (یا مشابه) فریز شوند. این امکان را به شما می‌دهد تا فایل‌های اجرایی از اسکریپت‌های پایتون خود بسازید. چنین ابزارهایی «فریزر» نامیده می‌شوند زیرا کد شما و وابستگی‌های آن را در یک فایل توزیعی واحد بسته‌بندی می‌کنند که بر روی ماشین‌های دیگر بدون نیاز به نصب پایتون یا کتابخانه‌های اضافه اجرا می‌شود. این روش توزیع برنامه‌های پایتون شما را ساده می‌کند.

فریز کردن یک افزونه Aspose.Slides for Python via .NET به عنوان وابستگی در مثال زیر با یک برنامه ساده که از Aspose.Slides استفاده می‌کند، نشان داده شده است.

## **PyInstaller**

به طور کلی، هنگام بسته‌بندی برنامه‌ای که به یک افزونه Aspose.Slides for Python via .NET وابسته است، نیازی به تنظیمات خاصی نیست. وقتی برنامه افزونه را به طوری که برای PyInstaller قابل مشاهده باشد وارد می‌کند، افزونه همراه با برنامه بسته‌بندی می‌شود. چون Aspose.Slides for Python via .NET شامل هوک‌های PyInstaller است، وابستگی‌های آن به‌صورت خودکار شناسایی و در بسته کپی می‌شوند.

slide_app.py:
```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    slide.shapes.add_auto_shape(slides.ShapeType.LINE, 50.0, 150.0, 300.0, 0.0)
    presentation.save("NewPresentation.pptx", slides.export.SaveFormat.PPTX)
```

```bash
$ pyinstaller slide_app.py
```

با این حال، گاهی اوقات PyInstaller ممکن است واردات پنهان—ماژول‌هایی که به‌صورت دینامیک یا به‌صورت غیر مستقیم توسط کد شما وارد می‌شوند—را از دست بدهد. برای افزودن یک واردات پنهان، از گزینه‌های PyInstaller استفاده کنید. وابستگی‌های افزونه در هوک‌های PyInstaller که همراه با Aspose.Slides for Python via .NET ارائه می‌شوند، مشخص شده‌اند.

slide_app.spec:
```
a = Analysis(
    ['slide_app.py'],
    ...
    hiddenimports=['aspose.slides']
)
```

```bash
$ pyinstaller slide_app.spec
```

## **cx_Freeze**

برای فریز کردن یک برنامه با cx_Freeze، آن را طوری تنظیم کنید که بسته ریشه‌ای افزونه Aspose.Slides for Python via .NET که استفاده می‌کنید را شامل شود. این کار تضمین می‌کند که افزونه و تمام ماژول‌های وابسته به آن در زمان ساخت کنار برنامه شما کپی شوند.

### **Using the cxfreeze Script**

```bash
$ cxfreeze slide_app.py --packages=aspose
```

### **Using the Setup Script**

setup.py:
```
executables = [Executable('slide_app.py')]

options = {
    'build_exe': {
        'packages': ['aspose'],
    }
}

setup(...
    options=options,
    executables=executables)
```

```bash
$ python setup.py build_exe
```

## **FAQ**

**Do I need Microsoft PowerPoint or .NET installed on the user’s machine?**

نه، نیاز به PowerPoint نیست. Aspose.Slides یک موتور خودکفا است؛ بسته پایتون همه چیز مورد نیاز را به‌عنوان یک افزونه برای CPython ارسال می‌کند. کاربر نیازی به نصب جداگانه .NET ندارد.

**How should I properly attach the license to a frozen application?**

می‌توانید فایل XML لایسنس را در کنار فایل اجرایی ذخیره کنید یا به‌عنوان منبعی جاسازی کنید و قبل از اولین فراخوانی API از مسیر قابل دسترسی آن بارگذاری کنید. مهم: محتوای XML را تغییر ندهید (حتی شکست خط نیز نباید تغییر کند).

**What should I do if fonts render differently after the build compared to development?**

اطمینان حاصل کنید قلم‌هایی که استفاده می‌کنید در محیط هدف (بسته‌بندی‌شده یا نصب‌شده در سیستم) موجود هستند و مسیرهای آن‌ها در زمان اجرا به‌درستی حل می‌شوند؛ رفتار قلم به‌ویژه در لینوکس حساسیّت بالایی دارد.