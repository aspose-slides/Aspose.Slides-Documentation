---
title: ویرایش اسناد PDF در Python از طریق Java
linktitle: ویرایش PDF
type: docs
weight: 65
url: /fa/python-java/edit-pdf/
keywords:
- ویرایش PDF
- جایگزینی متن PDF
- PDF به PPTX
- PPTX به PDF
- پایتون
- جاوا
- Aspose.Slides
description: "اسناد PDF را در Python از طریق Java با وارد کردن آن‌ها به Aspose.Slides، جایگزینی متن و ذخیرهٔ ارائهٔ اصلاح‌شده به فرمت PDF ویرایش کنید."
---
## **بررسی کلی**

Aspose.Slides برای Python از طریق Java به شما امکان می‌دهد محتوای PDF را با وارد کردن صفحات آن به‌عنوان اسلاید، ویرایش ارائه و سپس صادر کردن آن به PDF، ویرایش کنید. این مقاله یک جایگزینی ساده متن را نشان می‌دهد. ارائه در حافظه باقی می‌ماند، بنابراین ذخیره‌سازی فایل PPTX میانی اختیاری است.

## **جایگزینی متن در PDF**

از [addFromPdf](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slidecollection/#addFromPdf) برای وارد کردن صفحات، [replaceText](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#replaceText) برای به‌روزرسانی متن، و [save](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#save) برای صادرات نتیجه استفاده کنید.

مثال زیر انتظار دارد فایل `input.pdf` پس از وارد کردن شامل کلمهٔ «Draft» به‌صورت متن قابل ویرایش باشد. این کلمه را با «Final» جایگزین می‌کند و در فایل `edited.pdf` می‌نویسد. پاک‌سازی اسلاید اولیه قبل از وارد کردن از ایجاد صفحهٔ خالی اضافی در خروجی جلوگیری می‌کند. جستجو فقط کلمات کامل با حساسیت به حروف را تطبیق می‌دهد؛ `None` به این معناست که نیازی به فراخوانی نتیجه نیست.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TextSearchOptions

presentation = Presentation()
try:
    presentation.getSlides().removeAt(0)

    presentation.getSlides().addFromPdf("input.pdf")

    search_options = TextSearchOptions()
    search_options.setWholeWordsOnly(True)
    search_options.setCaseSensitive(True)
    presentation.replaceText("Draft", "Final", search_options, None)

    presentation.save("edited.pdf", SaveFormat.Pdf)
finally:
    presentation.dispose()
```

برای گزینه‌های بیشتر، به [جستجو و جایگزینی متن](/slides/fa/python-java/search-and-replace-text/) و [تبدیل PowerPoint به PDF](/slides/fa/python-java/convert-powerpoint-to-pdf/) مراجعه کنید.

{{% alert color="info" title="Note" %}}
جایگزینی متن بر روی متن وارد شده اعمال می‌شود، نه متن داخل تصاویر اسکن‌شده. تبدیل ممکن است بر چیدمان و قالب‌بندی تأثیر بگذارد، بنابراین خروجی را بررسی کنید، به‌خصوص زمانی که متن جایگزین طولانی‌تر از متن اصلی باشد.
{{% /alert %}}

## **پرسش‌های متداول**

**آیا قبل از صادرات PDF نیاز به ذخیرهٔ فایل PPTX دارم؟**

خیر. می‌توانید همان ارائه را در حافظه ویرایش و صادر کنید. فقط در صورتی که می‌خواهید ادامهٔ ویرایش را در PowerPoint داشته باشید، یک نسخهٔ PPTX ذخیره کنید؛ به [ذخیرهٔ ارائه‌ها](/slides/fa/python-java/save-presentation/) مراجعه کنید.

**چرا ممکن است برخی متن‌ها بدون تغییر بمانند؟**

مثال کلمهٔ کامل «Draft» را با حساسیت دقیق به حروف تطبیق می‌دهد. متنی که به‌صورت تصویر وارد شده یا در فریم‌های متنی جداگانه تقسیم شده باشد، لزوماً با جستجو مطابقت نخواهد داشت. محتوای وارد شده را بررسی کنید و جستجو را برای سند خود تنظیم کنید.