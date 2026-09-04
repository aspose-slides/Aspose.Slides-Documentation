---
title: مجوزدهی
type: docs
weight: 80
url: /fa/python-java/licensing/
keywords:
- Aspose.Slides
- پایتون
- جاوا
- فایل لایسنس
- لایسنس موقت
- مجوز متری
- محدودیت‌های ارزیابی
description: "یک لایسنس فایل، مبتنی بر بایت یا متری را در Aspose.Slides برای Python via Java اعمال کنید و محدودیت‌های ارزیابی را از برنامه‌های خود حذف کنید."
---
## **نمای کلی**

Aspose.Slides for Python via Java می‌تواند در حالت ارزیابی یا با لایسنس اجرا شود. این مقاله توضیح می‌دهد چگونه لایسنس را از یک فایل یا بایت‌ها اعمال کنید و چگونگی پیکربندی لایسنس متری را تنظیم کنید.

برای گزینه‌های خرید، به [اطلاعات قیمت‌گذاری](https://purchase.aspose.com/pricing/slides/fa/family) مراجعه کنید. برای سوالات کلی درباره لایسنس و خرید، به [سیاست‌های خرید و سؤالات متداول](https://purchase.aspose.com/policies) نگاه کنید.

برای محدودیت‌های ارزیابی و نحوه درخواست لایسنس موقت، به [ارزیابی Aspose.Slides](/slides/fa/python-java/evaluate-aspose-slides/) مراجعه کنید. لایسنس موقت را به همان روش فایل لایسنس خریداری شده اعمال کنید.

{{% alert color="warning" title="هشدار" %}}
فایل لایسنس را ویرایش نکنید. حتی یک خط خالی اضافه می‌تواند امضای دیجیتال آن را نامعتبر کند.
{{% /alert %}}

لایسنس را یک بار برای هر برنامه یا فرآیند اعمال کنید، قبل از ایجاد ارائه‌ها یا انجام سایر عملیات Aspose.Slides. برای یک فایل لایسنس، از کلاس [License](https://reference.aspose.com/slides/fa/python-java/aspose.slides/license/) استفاده کنید. لایسنس متری از یک جفت کلید عمومی و خصوصی به جای فایل لایسنس استفاده می‌کند.

## **اعمال لایسنس**

مثال‌های زیر فرض می‌کنند که Aspose.Slides for Python via Java و پیش‌نیازهای آن نصب شده‌اند. هر مثال یک اسکریپت مستقل است که JVM را راه‌اندازی می‌کند، API را وارد می‌کند و لایسنس را اعمال می‌نماید. در برنامهٔ خود، پس از اعمال لایسنس عملیات ارائهٔ خود را انجام دهید و JVM را فقط پس از اتمام تمام کارهای Aspose.Slides خاموش کنید.

### **اعمال لایسنس از فایل**

مسیر فایل لایسنس را به ‌[License.setLicense](https://reference.aspose.com/slides/fa/python-java/aspose.slides/license/#setLicense) بدهید. `Aspose.Slides.lic` را با مسیر فایل لایسنس خود جایگزین کنید.

```python
from pathlib import Path

import jpype
import asposeslides

jpype.startJVM()

try:
    from asposeslides.api import License

    license_path = Path("Aspose.Slides.lic")
    if license_path.is_file():
        license = License()
        license.setLicense(str(license_path))
        print("Licensed:", license.isLicensed())
        # در اینجا عملیات ارائه را انجام دهید، قبل از خاموش کردن JVM.
    else:
        print("License file not found. Set the path to your license file.")
finally:
    jpype.shutdownJVM()
```

از نام دقیق فایل، شامل پسوند آن استفاده کنید. برای مثال، اگر فایل نام دارد `Aspose.Slides.lic.xml`، `.xml` را نیز در مسیر بگنجانید. مسیر مطلق از ابهام دربارهٔ پوشهٔ کاری برنامه جلوگیری می‌کند.

مثال از [License.isLicensed](https://reference.aspose.com/slides/fa/python-java/aspose.slides/license/#isLicensed) برای بررسی اینکه لایسنس اعمال شده است یا نه استفاده می‌کند.

### **اعمال لایسنس از بایت‌ها**

از ‌[License.setLicenseFromBytes](https://reference.aspose.com/slides/fa/python-java/aspose.slides/license/#setLicenseFromBytes) وقتی لایسنس به صورت بایت‌های پایتون در دسترس است، استفاده کنید. مثال زیر فایل را در حالت باینری می‌خواند و قبل از اعمال لایسنس آن را می‌بندد.

```python
from pathlib import Path

import jpype
import asposeslides

jpype.startJVM()

try:
    from asposeslides.api import License

    license_path = Path("Aspose.Slides.lic")
    if license_path.is_file():
        with license_path.open("rb") as license_file:
            license_data = license_file.read()

        license = License()
        license.setLicenseFromBytes(license_data)
        print("Licensed:", license.isLicensed())
        # در اینجا عملیات ارائه را انجام دهید، قبل از خاموش کردن JVM.
    else:
        print("License file not found. Set the path to your license file.")
finally:
    jpype.shutdownJVM()
```

بایت‌های اصلی را بدون تغییر نگه دارید. قبل از اعمال لایسنس، محتویات لایسنس را رمزگشایی، بازفرمت یا به هر شکل دیگری تغییر ندهید.

## **اعمال لایسنس متری**

لایسنس متری به‌ازای استفاده از API هزینه‌ای دریافت می‌کند. پس از دریافت یک لایسنس متری، کلیدهای عمومی و خصوصی آن را با ‌[Metered.setMeteredKey](https://reference.aspose.com/slides/fa/python-java/aspose.slides/metered/#setMeteredKey) اعمال کنید. شیء ‌[Metered](https://reference.aspose.com/slides/fa/python-java/aspose.slides/metered/) را مقداردهی اولیه کنید و کلیدها را یک بار در هنگام راه‌اندازی برنامه اعمال نمایید.

مثال زیر کلیدها را از متغیرهای محیطی `ASPOSE_METERED_PUBLIC_KEY` و `ASPOSE_METERED_PRIVATE_KEY` می‌خواند. قبل از اجرای اسکریپت هر دو متغیر را تنظیم کنید.

```python
import os

import jpype
import asposeslides

jpype.startJVM()

try:
    from asposeslides.api import Metered

    public_key = os.environ.get("ASPOSE_METERED_PUBLIC_KEY")
    private_key = os.environ.get("ASPOSE_METERED_PRIVATE_KEY")

    if public_key and private_key:
        metered = Metered()
        metered.setMeteredKey(public_key, private_key)
        # در اینجا عملیات ارائه را انجام دهید، قبل از خاموش کردن JVM.
    else:
        print("Set both metered licensing environment variables before running this example.")
finally:
    jpage.shutdownJVM()
```

{{% alert color="info" title="نکته" %}}
لایسنس متری برای اعتبارسنجی کلیدها و گزارش مصرف به اتصال اینترنتی نیاز دارد. کلید خصوصی را از کد منبع و لاگ‌ها دور نگه دارید. برای جزئیات مربوط به اتصال و صورتحساب، به [سؤالات متداول لایسنس متری](https://purchase.aspose.com/faqs/licensing/metered) مراجعه کنید.
{{% /alert %}}

## **پرسش‌های متداول**

**آیا پس از خرید لایسنس نیاز به نصب بستهٔ دیگری دارم؟**

نه. لایسنس را به همان بسته‌ای که برای ارزیابی استفاده کرده‌اید اعمال کنید.

**آیا باید برای هر ارائه لایسنس را اعمال کنم؟**

نه. لایسنس را یک بار هنگام راه‌اندازی برنامه، پیش از ایجاد یا بارگذاری ارائه‌ها اعمال کنید.

**آیا می‌توانم نام فایل لایسنس را تغییر دهم؟**

بله. نام جدید فایل را دقیقاً در کد خود استفاده کنید و محتوای فایل را دست نخورده نگه دارید.

**آیا می‌توانم لایسنس موقت را با مثال مبتنی بر بایت‌ها استفاده کنم؟**

بله. فایل لایسنس موقت را به عنوان بایت بخوانید و به همان شیوه‌ی لایسنس خریداری شده اعمال کنید.