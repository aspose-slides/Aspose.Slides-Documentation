---
title: مجوزدهی
type: docs
weight: 80
url: /fa/python-java/licensing/
keywords:
- Aspose.Slides
- Python
- Java
- فایل لایسنس
- مجوز موقت
- مجوز متری
- محدودیت‌های ارزیابی
description: "یک لایسنس فایل‑محور، مبتنی بر بایت یا متری را در Aspose.Slides برای Python از طریق Java اعمال کنید و محدودیت‌های ارزیابی را از برنامه‌های خود حذف کنید."
---
## **مروری کلی**

Aspose.Slides for Python via Java می‌تواند در حالت ارزیابی یا با لایسنس اجرا شود. در حالت ارزیابی، یک جعبه متن واترمارک ارزیابی به هر اسلاید از هر ارائه‌ای که ذخیره می‌کند اضافه می‌کند و متنی که کد شما از ارائه‌ها می‌خواند را کوتاه می‌کند. این مقاله توضیح می‌دهد چگونه لایسنس را از فایل یا بایت‌ها اعمال کنید و چگونه لایسنس متری را پیکربندی کنید.

برای گزینه‌های خرید، به [اطلاعات قیمت‌گذاری](https://purchase.aspose.com/pricing/slides/fa/family) مراجعه کنید. برای سؤالات عمومی درباره لایسنس و خرید، به [سیاست‌های خرید و سؤالات متداول](https://purchase.aspose.com/policies) نگاه کنید.

برای محدودیت‌های ارزیابی و نحوه درخواست لایسنس موقت، به [ارزیابی Aspose.Slides](/slides/fa/python-java/evaluate-aspose-slides/) مراجعه کنید. یک لایسنس موقت را به همان روش یک فایل لایسنس خریداری‌شده اعمال کنید.

## **درباره لایسنس**

فایل لایسنس شامل اطلاعاتی نظیر نام محصول، تعداد توسعه‌دهندگان دارای لایسنس و تاریخ انقضای اشتراک است. این فایل یک XML امضای دیجیتال دارد.

{{% alert color="warning" title="Warning" %}}
لایسنس را ویرایش نکنید. حتی یک خط خالی اضافه می‌تواند امضای دیجیتال آن را نامعتبر کند.
{{% /alert %}}

لایسنس را یک‌بار برای هر برنامه یا فرآیند، قبل از ایجاد ارائه‌ها یا انجام سایر عملیات Aspose.Slides اعمال کنید. برای یک فایل لایسنس، از کلاس [License](https://reference.aspose.com/slides/fa/python-java/aspose.slides/license/) استفاده کنید. لایسنس متری به جای فایل لایسنس از یک جفت کلید عمومی و خصوصی استفاده می‌کند.

## **اعمال لایسنس**

مثال‌های زیر فرض می‌کنند Aspose.Slides for Python via Java و پیش‌نیازهای آن نصب شده‌اند. هر مثال یک اسکریپت مستقل است که JVM را شروع می‌کند، API را ایمپورت می‌کند و لایسنس را اعمال می‌نماید. در برنامه خود، پس از اعمال لایسنس عملیات ارائه‌ای خود را انجام دهید و JVM را فقط پس از اتمام تمام کارهای Aspose.Slides خاموش کنید.

### **اعمال لایسنس از فایل**

مسیر فایل لایسنس را به [License.setLicense](https://reference.aspose.com/slides/fa/python-java/aspose.slides/license/#setLicense) بدهید. `Aspose.Slides.lic` را با مسیر فایل لایسنس خود جایگزین کنید.

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
        # عملیات ارائه را در اینجا انجام دهید، قبل از اینکه JVM را خاموش کنید.
    else:
        print("License file not found. Set the path to your license file.")
finally:
    jpype.shutdownJVM()
```

از نام دقیق فایل، به همراه پسوند آن استفاده کنید. برای مثال، اگر فایل با نام `Aspose.Slides.lic.xml` باشد، `.xml` را در مسیر بگنجانید. مسیر مطلق از ابهام دربارهٔ پوشه کاری برنامه جلوگیری می‌کند.

مثال از [License.isLicensed](https://reference.aspose.com/slides/fa/python-java/aspose.slides/license/#isLicensed) برای بررسی اینکه آیا لایسنس اعمال شده است، استفاده می‌کند.

### **اعمال لایسنس از بایت‌ها**

از [License.setLicenseFromBytes](https://reference.aspose.com/slides/fa/python-java/aspose.slides/license/#setLicenseFromBytes) زمانی که لایسنس به صورت بایت‌های پایتون موجود است، استفاده کنید. مثال زیر فایل را در حالت باینری می‌خواند و قبل از اعمال لایسنس آن را می‌بندد.

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
        # عملیات ارائه را در اینجا انجام دهید، قبل از اینکه JVM را خاموش کنید.
    else:
        print("License file not found. Set the path to your license file.")
finally:
    jpype.shutdownJVM()
```

بایت‌های اصلی را دست نخورده نگه دارید. قبل از اعمال لایسنس، محتویات لایسنس را رمزگشایی، فرمت‌بندی یا به هر روش دیگری تغییر ندهید.

## **اعمال لایسنس متری**

لایسنس متری بر اساس استفاده از API به شما هزینه می‌گیرد. پس از دریافت لایسنس متری، کلیدهای عمومی و خصوصی آن را با [Metered.setMeteredKey](https://reference.aspose.com/slides/fa/python-java/aspose.slides/metered/#setMeteredKey) اعمال کنید. شیء [Metered](https://reference.aspose.com/slides/fa/python-java/aspose.slides/metered/) را مقداردهی اولیه کنید و کلیدها را یک‌بار در هنگام شروع برنامه اعمال کنید.

مثال زیر کلیدها را از متغیرهای محیطی `ASPOSE_METERED_PUBLIC_KEY` و `ASPOSE_METERED_PRIVATE_KEY` می‌خواند. قبل از اجرای اسکریپت، هر دو متغیر را تنظیم کنید.

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
        # عملیات ارائه را در اینجا انجام دهید، قبل از اینکه JVM را خاموش کنید.
    else:
        print("Set both metered licensing environment variables before running this example.")
finally:
    jpype.shutdownJVM()
```

{{% alert color="info" title="Note" %}}
لایسنس متری برای اعتبارسنجی کلیدها و گزارش استفاده به اتصال اینترنتی نیاز دارد. کلید خصوصی را از کد منبع و لاگ‌ها دور نگه دارید. برای جزئیات اتصال و صورتحساب به [سؤالات متداول لایسنس متری](https://purchase.aspose.com/faqs/licensing/metered) مراجعه کنید.
{{% /alert %}}

## **سؤالات متداول**

**آیا پس از خرید لایسنس نیاز به نصب بسته متفاوتی دارم؟**

خیر. لایسنس را به همان بسته‌ای که برای ارزیابی استفاده کرده‌اید اعمال کنید.

**آیا باید برای هر ارائه‌ای لایسنس اعمال کنم؟**

خیر. لایسنس را یک‌بار در زمان راه‌اندازی برنامه، قبل از ایجاد یا بارگذاری ارائه‌ها اعمال کنید.

**آیا می‌توانم نام فایل لایسنس را تغییر دهم؟**

بله. نام فایل جدید دقیق را در کد خود استفاده کنید و محتویات فایل را دست نخورده نگه دارید.

**آیا می‌توانم لایسنس موقت را با مثال مبتنی بر بایت استفاده کنم؟**

بله. فایل لایسنس موقت را به عنوان بایت بخوانید و همانند لایسنس خریداری‌شده اعمال کنید.