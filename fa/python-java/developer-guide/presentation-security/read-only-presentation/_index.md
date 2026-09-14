---
title: ذخیره ارائه‌ها در حالت فقط خواندنی با استفاده از Python
linktitle: ارائه فقط خواندنی
type: docs
weight: 30
url: /fa/python-java/read-only-presentation/
keywords:
- فقط خواندنی
- محافظت از ارائه
- جلوگیری از ویرایش
- PowerPoint
- OpenDocument
- ارائه
- Python
- Aspose.Slides
description: "بارگذاری و ذخیره‌سازی فایل‌های PowerPoint (PPT، PPTX) در حالت فقط خواندنی با Aspose.Slides برای Python عبر Java، پیش‌نمایش‌های دقیق اسلایدها را بدون تغییر در ارائه‌های شما فراهم می‌کند."
---
## **معرفی**

در PowerPoint 2019، مایکروسافت تنظیم **Always Open Read-Only** را به عنوان یکی از گزینه‌هایی که کاربران می‌توانند برای حفاظت از ارائه‌های خود استفاده کنند، معرفی کرد. ممکن است بخواهید از این تنظیم Read-Only برای حفاظت از یک ارائه استفاده کنید وقتی که:

- می‌خواهید از ویرایش‌های تصادفی جلوگیری کنید و محتوای ارائه خود را ایمن نگه دارید. 
- می‌خواهید به افراد اطلاع دهید که ارائه‌ای که ارائه کرده‌اید، نسخه نهایی است. 

پس از انتخاب گزینه **Always Open Read-Only** برای یک ارائه، وقتی کاربران آن را باز می‌کنند، توصیه **Read-Only** را می‌بینند و ممکن است پیامی به این شکل مشاهده کنند: *برای جلوگیری از تغییرات تصادفی، نویسنده این فایل را برای باز شدن به صورت فقط‑خواندنی تنظیم کرده است.*

توصیه **Read-Only** یک بازدارنده ساده اما مؤثر است که ویرایش را دلسرد می‌کند زیرا کاربران باید کاری را برای حذف آن انجام دهند پیش از اینکه اجازه ویرایش ارائه را داشته باشند. اگر نمی‌خواهید کاربران تغییراتی در ارائه ایجاد کنند و می‌خواهید این را به‌صورت مؤدبانه به آن‌ها بگویید، توصیه **Read-Only** می‌تواند گزینه خوبی برای شما باشد. 

> اگر یک ارائه با محافظت **Read-Only** در یک برنامه Microsoft PowerPoint قدیمی‌تر باز شود — که از عملکرد تازه معرفی‌شده پشتیبانی نمی‌کند — توصیه **Read-Only** نادیده گرفته می‌شود (ارائه به‌صورت معمولی باز می‌شود).

## **اعمال حالت Read-Only**

Aspose.Slides for Python via Java به شما امکان می‌دهد یک ارائه را به حالت **Read-Only** تنظیم کنید، به این معنی که کاربران (پس از باز کردن ارائه) توصیه **Read-Only** را می‌بینند. این کد نمونه نشان می‌دهد چگونه یک ارائه را به **Read-Only** در Python با استفاده از Aspose.Slides تنظیم کنید:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    presentation.getProtectionManager().setReadOnlyRecommended(True)
    presentation.save("ReadOnlyPresentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}} 

توصیه **Read-Only** به سادگی برای دلسرد کردن ویرایش یا جلوگیری از ایجاد تغییرات تصادفی توسط کاربران در یک ارائه PowerPoint است. اگر فردی با انگیزه—که می‌داند چه کاری انجام می‌دهد—تصمیم بگیرد ارائه شما را ویرایش کند، به راحتی می‌تواند تنظیم Read-Only را حذف کند. اگر به‌طور جدی نیاز به جلوگیری از ویرایش غیرمجاز دارید، بهتر است از [more stringent protections that involve encryption and passwords](/slides/fa/python-java/password-protected-presentation/) استفاده کنید. 

{{% /alert %}} 

## **سوالات متداول**

**چگونه 'Read-Only recommended' با محافظت کامل با رمز عبور متفاوت است؟**  
'Read-Only recommended' فقط یک پیشنهاد برای باز کردن فایل در حالت فقط‑خواندنی نمایش می‌دهد و به‌راحتی می‌توان آن را عبور کرد. [Password protection](/slides/fa/python-java/password-protected-presentation/) در واقع باز کردن یا ویرایش را محدود می‌کند و وقتی به کنترل‌های امنیتی واقعی نیاز دارید، مناسب است.

**آیا می‌توان 'Read-Only recommended' را با نشان‌های آبکی (watermarks) ترکیب کرد تا ویرایش‌ها بیشتر دلسرد شوند؟**  
بله. این توصیه می‌تواند با [watermarks](/slides/fa/python-java/watermark/) به عنوان یک بازدارنده بصری ترکیب شود؛ آن‌ها مکانیزم‌های جداگانه‌ای هستند و به‌خوبی با هم کار می‌کنند.

**آیا یک ماکرو یا ابزار خارجی همچنان می‌تواند فایل را زمانی که توصیه فعال است، تغییر دهد؟**  
بله. این توصیه مانع تغییرات برنامه‌ای نمی‌شود. برای جلوگیری از ویرایش‌های خودکار، از [passwords and encryption](/slides/fa/python-java/password-protected-presentation/) استفاده کنید.

**چگونه 'Read-Only recommended' با روش‌های [isEncrypted](https://reference.aspose.com/slides/fa/python-java/aspose.slides/protectionmanager/#isEncrypted) و [isWriteProtected](https://reference.aspose.com/slides/fa/python-java/aspose.slides/protectionmanager/#isWriteProtected) مرتبط است؟**  
آن‌ها سیگنال‌های متفاوتی هستند. 'Read-Only recommended' یک اعلان نرم و اختیاری است؛ [isWriteProtected](https://reference.aspose.com/slides/fa/python-java/aspose.slides/protectionmanager/#isWriteProtected) و [isEncrypted](https://reference.aspose.com/slides/fa/python-java/aspose.slides/protectionmanager/#isEncrypted) محدودیت‌های واقعی نوشتن یا خواندن را نشان می‌دهند که وابسته به رمز عبور یا رمزنگاری هستند.