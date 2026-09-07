---
title: تبدیل ODP به PPTX در پایتون
linktitle: ODP به PPTX
type: docs
weight: 10
url: /fa/python-java/convert-odp-to-pptx/
keywords:
- تبدیل OpenDocument
- تبدیل ارائه
- تبدیل اسلاید
- تبدیل ODP
- OpenDocument به PPTX
- ODP به PPTX
- ذخیره ODP به‌صورت PPTX
- صادر کردن ODP به PPTX
- PowerPoint
- OpenDocument
- ارائه
- Python
- Java
- Aspose.Slides
description: "تبدیل ارائه‌های ODP به PPTX با Aspose.Slides برای پایتون از طریق جاوا. از یک مثال کامل پایتون استفاده کنید بدون نیاز به نصب PowerPoint یا LibreOffice."
---
## **مرور کلی**

این مقاله توضیح می‌دهد چگونه یک ارائه OpenDocument (ODP) را به فرمت PowerPoint (PPTX) با استفاده از Aspose.Slides برای Python از طریق Java تبدیل کنیم.

## **تبدیل ODP به PPTX**

کلاس [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) می‌تواند یک فایل ODP را به‌صورت مستقیم بارگذاری کند. ارائه بارگذاری‌شده را با استفاده از [SaveFormat](https://reference.aspose.com/slides/fa/python-java/aspose.slides/saveformat/) در فرمت PPTX ذخیره کنید.

قبل از اجرای مثال، [دستورالعمل‌های نصب](/slides/fa/python-java/installation/) را دنبال کنید. یک ارائه ODP به نام `AccessOpenDoc.odp` را در پوشه کاری قرار دهید. کد زیر JVM را در صورت لزوم راه‌اندازی می‌کند، فایل ODP را باز می‌کند و به عنوان `AccessOpenDoc_out.pptx` ذخیره می‌نماید.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("AccessOpenDoc.odp")
try:
    # ارائه ODP را در فرمت PPTX ذخیره کنید.
    presentation.save("AccessOpenDoc_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **مثال زنده**

برای مشاهده تبدیل ODP به PPTX با استفاده از Aspose.Slides، برنامه وب [Aspose.Slides Conversion](https://products.aspose.app/slides/fa/conversion/) را امتحان کنید.

## **پرسش‌های متداول**

**آیا برای تبدیل ODP به PPTX نیاز به نصب Microsoft PowerPoint یا LibreOffice دارم؟**

خیر. Aspose.Slides برای Python از طریق Java می‌تواند فایل‌های ارائه را بدون نیاز به هیچ‌یک از این برنامه‌ها بخواند و بنویسد. شما تنها به بسته Python و یک محیط اجرایی Java سازگار نیاز دارید.

**آیا اسلایدهای اصلی، طرح‌بندی‌ها و تم‌ها در طول تبدیل حفظ می‌شوند؟**

Aspose.Slides ساختار و قالب‌بندی ارائه منبع را به PPTX نگاشت می‌کند. با این حال، ODP و PPTX ویژگی‌های متفاوتی دارند، بنابراین برخی عناصر ممکن است پس از تبدیل متفاوت به نظر برسند. قلم‌های مورد نیاز را در دسترس قرار دهید و ارائه‌های دارای قالب‌بندی پیچیده را بررسی کنید. برای ملاحظات سازگاری به [OpenDocument conversion](/slides/fa/python-java/convert-openoffice-odp/) مراجعه کنید.

**آیا می‌توانم فایل‌های ODP با رمز عبور را تبدیل کنم؟**

بله، در صورتی که رمز عبور مورد نیاز برای باز کردن فایل را فراهم کنید. برای جزئیات بارگذاری فایل‌های محافظت‌شده قبل از ذخیره آن‌ها در فرمت دیگری، به [ارائه‌های محافظت‌شده با رمز](/slides/fa/python-java/password-protected-presentation/) مراجعه کنید.

**آیا Aspose.Slides برای سرویس‌های تبدیل مبتنی بر ابر یا REST مناسب است؟**

بله. می‌توانید از Aspose.Slides برای Python از طریق Java در بخش بک‌اند خود همراه با محیط اجرایی Java مورد نیاز استفاده کنید. برای یک API REST، به [Aspose.Slides Cloud](https://products.aspose.cloud/slides/fa/family/) مراجعه کنید.