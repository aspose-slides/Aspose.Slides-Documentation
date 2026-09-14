---
title: بهینه‌سازی جایگزینی فونت در ارائه‌ها با استفاده از Python از طریق Java
linktitle: جایگزینی فونت
type: docs
weight: 60
url: /fa/python-java/font-replacement/
keywords:
- فونت
- جایگزینی فونت
- جایگزینی فونت
- تغییر فونت
- PowerPoint
- OpenDocument
- ارائه
- Python
- Java
- Aspose.Slides
description: "به‌صورت یکپارچه فونت‌ها را در Aspose.Slides برای Python از طریق Java جایگزین کنید تا تایپوگرافی سازگار در ارائه‌های PowerPoint و OpenDocument تضمین شود."
---
## **بررسی کلی**

Aspose.Slides به شما امکان می‌دهد یک فونت را در تمام ارائه جایگزین فونت دیگری کنید. وقتی یک فونت جایگزین می‌شود، تمام نمونه‌های فونت اصلی به فونت جدید تغییر می‌یابند.

برای انجام جایگزینی فونت، ارائه را بارگذاری کنید، فونت مبدا و فونت جایگزین را تعریف کنید، متد جایگزینی فونت را صدا بزنید و ارائه‌ اصلاح‌شده را به‌صورت فایل PPTX ذخیره کنید. این روش زمانی مفید است که به‌صورت عمدی بخواهید کل ارائه را از یک خانواده فونت به خانواده دیگر منتقل کنید.

## **جایگزینی فونت‌ها**

اگر نظر خود را درباره استفاده از یک فونت تغییر دهید، می‌توانید آن فونت را با فونت دیگری جایگزین کنید. تمام نمونه‌های فونت قدیمی توسط فونت جدید جایگزین خواهند شد. 

Aspose.Slides به شما امکان می‌دهد یک فونت را به این شکل جایگزین کنید:

1. ارائه مربوطه را بارگذاری کنید. 
2. فونتی که قرار است جایگزین شود را بارگذاری کنید. 
3. فونت جدید را بارگذاری کنید. 
4. فونت را جایگزین کنید. 
5. ارائه اصلاح‌شده را به‌صورت فایل PPTX ذخیره کنید.

این کد پایتون جایگزینی فونت را نشان می‌دهد:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, Presentation, SaveFormat

# بارگذاری یک ارائه.
presentation = Presentation("Fonts.pptx")
try:
    # بارگذاری فونت منبع که جایگزین خواهد شد.
    source_font = FontData("Arial")

    # بارگذاری فونت جدید.
    destination_font = FontData("Times New Roman")

    # جایگزینی فونت.
    presentation.getFontsManager().replaceFont(source_font, destination_font)

    # ذخیره‌ی ارائه.
    presentation.save("UpdatedFont_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert title="Note" color="info" %}} 

برای تنظیم قوانینی که تعیین می‌کنند در شرایط خاص چه اتفاقی می‌افتد (مثلاً اگر به یک فونت دسترسی نداشته باشید)، به [جایگزینی فونت](/slides/fa/python-java/font-substitution/) مراجعه کنید. 

{{% /alert %}}

## **سوالات متداول**

**تفاوت بین "font replacement"، "font substitution" و "fallback fonts" چیست؟**

جایگزینی یک تعویض عمدی از یک خانواده به خانواده دیگر در سرتاسر سند است. [Substitution](/slides/fa/python-java/font-substitution/) قانونی است مانند «اگر فونت در دسترس نباشد، از X استفاده کن». [Fallback](/slides/fa/python-java/fallback-font/) برای گلیف‌های گمشده به‌صورت جداگانه اعمال می‌شود وقتی که فونت پایه نصب شده باشد ولی شامل کاراکترهای مورد نیاز نباشد.

**آیا جایگزینی بر اسلایدهای اصلی (master slides)، چیدمان‌ها، یادداشت‌ها و نظرات اعمال می‌شود؟**

بله. جایگزینی بر تمام اشیای ارائه که از فونت اصلی استفاده می‌کنند تأثیر می‌گذارد، از جمله اسلایدهای اصلی و یادداشت‌ها؛ نظرات نیز جزئی از سند هستند و توسط موتور فونت در نظر گرفته می‌شوند.

**آیا فونت داخل اشیای OLE جاسازی‌شده (مثلاً Excel) تغییر خواهد کرد؟**

خیر. [OLE content](/slides/fa/python-java/manage-ole/) توسط برنامه خود کنترل می‌شود. جایگزینی در ارائه داده‌های داخلی OLE را بازفرمت نمی‌کند؛ ممکن است به‌صورت تصویر یا محتوای قابل ویرایش خارجی نمایش داده شود.

**آیا می‌توانم فقط در بخشی از ارائه (بر اساس اسلایدها یا مناطق) یک فونت را جایگزین کنم؟**

جایگزینی هدفمند امکان‌پذیر است اگر فونت را در سطح اشیاء/بخش‌های مورد نیاز تغییر دهید به جای اعمال جایگزینی سراسری بر سرتاسر سند. منطق کلی انتخاب فونت هنگام رندر همچنان ثابت می‌ماند.

**چگونه می‌توانم پیشاپیش مشخص کنم که ارائه از چه فونت‌هایی استفاده می‌کند؟**

از [font manager](https://reference.aspose.com/slides/fa/python-java/aspose.slides/fontsmanager/) ارائه استفاده کنید: این ابزار فهرستی از [families in use](https://reference.aspose.com/slides/fa/python-java/aspose.slides/fontsmanager/#getFonts) و اطلاعاتی درباره [substitutions/"unknown" fonts](https://reference.aspose.com/slides/fa/python-java/aspose.slides/fontsmanager/#getSubstitutions) ارائه می‌دهد که برنامه‌ریزی جایگزینی را آسان می‌کند.

**آیا جایگزینی فونت هنگام تبدیل به PDF/تصاویر کار می‌کند؟**

بله. در زمان خروجی، Aspose.Slides همان [font selection/substitution sequence](/slides/fa/python-java/font-selection-sequence/) را اعمال می‌کند، بنابراین جایگزینی انجام‌شده پیشاپیش در هنگام تبدیل حفظ می‌شود.

**آیا نیاز است فونت هدف را در سیستم نصب کنم یا می‌توانم پوشه‌ای حاوی فونت‌ها را پیوست کنم؟**

نصب الزامی نیست: کتابخانه امکان [loading external fonts](/slides/fa/python-java/custom-font/) را از پوشه‌های کاربر برای استفاده در طول [rendering and export](/slides/fa/python-java/convert-powerpoint/) فراهم می‌کند.

**آیا جایگزینی مشکل «توفو» (مربعات) به‌جای کاراکترها را رفع می‌کند؟**

فقط در صورتی که فونت هدف واقعاً گلیف‌های مورد نیاز را داشته باشد. در غیر این صورت، [configure fallback](/slides/fa/python-java/fallback-font/) را برای پوشش کاراکترهای گمشده تنظیم کنید.