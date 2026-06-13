---
title: "نیازمندی‌های سیستم"
type: docs
weight: 60
url: /fa/python-net/system-requirements/
keywords:
- "نیازمندی‌های سیستم"
- "سیستم‌عامل"
- "نصب"
- "وابستگی‌ها"
- "ویندوز"
- "لینوکس"
- "macOS"
- "PowerPoint"
- "OpenDocument"
- "ارائه"
- "پایتون"
- "Aspose.Slides"
description: "نیازمندی‌های سیستم Aspose.Slides برای Python از طریق .NET را کشف کنید. اطمینان حاصل کنید که پشتیبانی یکپارچه از PowerPoint و OpenDocument در ویندوز، لینوکس و macOS فراهم باشد."
---
## **مقدمه**

Aspose.Slides for Python via .NET نیازی به نصب هیچ محصول شخص ثالثی مانند Microsoft PowerPoint ندارد. Aspose.Slides یک موتور برای ایجاد، ویرایش، تبدیل و رندر اسناد در قالب‌های مختلف است، از جمله قالب‌های ارائه Microsoft PowerPoint.

## **سیستم‌عامل‌های پشتیبانی‌شده**

Aspose.Slides for Python از Windows (32 bit و 64 bit)، macOS و Linux 64 bit در سیستم‌هایی که Python 3.5 یا بالاتر نصب شده است، پشتیبانی می‌کند.

<table>  
    <tr>
        <td style="font-weight: bold; width:400px">سیستم‌عامل</td>
        <td style="font-weight: bold; width:400px">نسخه‌ها</td>
    </tr>
    <tr>
        <td>Microsoft Windows</td>
        <td>
            <ul>
                <li>Windows 2003 Server</li>
                <li>Windows 2008 Server</li>
                <li>Windows 2012 Server</li>
                <li>Windows 2012 R2 Server</li>
                <li>Windows 2016 Server</li>
                <li>Windows 2019 Server</li>
                <li>Windows XP</li>
                <li>Windows Vista</li>
                <li>Windows 7</li>
                <li>Windows 8, 8.1</li>
                <li>Windows 10</li>
                <li>Windows 11</li>
            </ul>
        </td>
    </tr>
    <tr>
        <td>Linux</td>
        <td>
            <ul>
                <li>Ubuntu</li>
                <li>OpenSUSE</li>
                <li>CentOS</li>
                <li>و دیگران</li>
            </ul>
        </td>
    </tr>
    <tr>
        <td>macOS</td>
        <td>
            <ul>
                <li>12 "Monterey"</li>
            </ul>
        </td>
    </tr>
</table>

## **نیازمندی‌های سیستم برای پلتفرم‌های هدف Linux و macOS**

- کتابخانه‌های زمان اجرای GCC 6 (یا بالاتر).  
- [libgdiplus](https://github.com/mono/libgdiplus)، یک پیاده‌سازی متن باز از API GDI+.  
- وابستگی‌های .NET Core Runtime. نصب خود .NET Core Runtime ضروری نیست.  
- برای Python 3.5–3.7: ساخت `pymalloc` پایتون مورد نیاز است. گزینه ساخت `--with-pymalloc` به طور پیش‌فرض فعال است. معمولاً، ساخت `pymalloc` پایتون با پسوند `m` در نام فایل مشخص می‌شود.  
- کتابخانه مشترک `libpython`. گزینه ساخت Python `--enable-shared` به طور پیش‌فرض غیرفعال است و برخی توزیع‌های پایتون کتابخانه مشترک `libpython` را شامل نمی‌شوند. در برخی پلتفرم‌های Linux می‌توانید کتابخانه مشترک `libpython` را با استفاده از مدیر بسته نصب کنید (به عنوان مثال `sudo apt-get install libpython3.7`). یک مشکل رایج این است که کتابخانه `libpython` در مسیری غیر استاندارد برای کتابخانه‌های مشترک نصب شده است. می‌توانید این مشکل را با استفاده از گزینه‌های ساخت پایتون برای تنظیم مسیرهای کتابخانه جایگزین یا با ایجاد لینک نمادین به فایل کتابخانه `libpython` در مسیر استاندارد کتابخانه‌های مشترک سیستم برطرف کنید. به طور معمول، نام فایل کتابخانه مشترک `libpython` به شکل `libpythonX.Ym.so.1.0` برای Python 3.5–3.7 یا `libpythonX.Y.so.1.0` برای Python 3.8 یا بالاتر است (به عنوان مثال `libpython3.7m.so.1.0`، `libpython3.9.so.1.0`).

## **پرسش‌های متداول**

**آیا برای تبدیل‌ها و رندرینگ به Microsoft PowerPoint نیاز است تا نصب شود؟**

خیر، PowerPoint لازم نیست؛ Aspose.Slides یک موتور مستقل برای [ایجاد](/slides/fa/python-net/create-presentation/)، ویرایش، [تبدیل](/slides/fa/python-net/convert-presentation/)، و [رندر](/slides/fa/python-net/convert-powerpoint-to-png/) ارائه‌ها است.

**آیا نسخه خاصی از .NET (Core/5+/6+) بر روی دستگاه لازم است؟**

نصب خود .NET Runtime لازم نیست، اما وابستگی‌های آن باید بر روی Linux/macOS موجود باشد. این بدین معنی است که سیستم باید بسته‌هایی که معمولاً به عنوان وابستگی‌های .NET نصب می‌شوند را داشته باشد، بدون اینکه Runtime را به طور کامل نصب کنید.

**کدام فونت‌ها برای رندر صحیح لازم هستند؟**

در عمل، فونت‌های استفاده شده در ارائه یا [جایگزین‌های](/slides/fa/python-net/font-substitution/) مناسب باید موجود باشند. برای اطمینان از رندر یکنواخت بر روی Linux/macOS، توصیه می‌شود بسته‌های فونت رایج نصب شوند.

**چرا یک فونت سفارشی به عنوان جایگزین یا متن گمشده در Linux رندر می‌شود؟**

اگر فایل فونت ورودی دارای ورودی‌های جدول نام ناسازگار یا خراب باشد، استک تطبیق فونت Linux (FreeType/fontconfig) ممکن است رکورد نامعتبری را انتخاب کند که منجر به عدم شناسایی فونت می‌شود. استفاده از نسخه‌ای از فونت با رکوردهای جدول نام اصلاح‌شده یا نصب یک جایگزین سازگار این مشکل را برطرف می‌کند.