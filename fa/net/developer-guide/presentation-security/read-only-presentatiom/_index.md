---
title: ذخیره‌سازی ارائه‌ها در حالت فقط‑خواندنی در .NET
linktitle: ارائه فقط‑خواندنی
type: docs
weight: 30
url: /fa/net/read-only-presentation/
keywords:
- فقط‑خواندنی
- محافظت از ارائه
- جلوگیری از ویرایش
- PowerPoint
- OpenDocument
- ارائه
- .NET
- C#
- Aspose.Slides
description: "بارگذاری و ذخیرهٔ فایل‌های PowerPoint (PPT، PPTX) در حالت فقط‑خواندنی با Aspose.Slides برای .NET، پیش‌نمایش‌های دقیق اسلایدها را بدون تغییر در ارائه‌های شما فراهم می‌کند."
---
## **مقدمه**

در PowerPoint 2019، مایکروسافت تنظیم **Always Open Read-Only** را به‌عنوان یکی از گزینه‌هایی که کاربران می‌توانند برای محافظت از ارائه‌های خود استفاده کنند، معرفی کرد. ممکن است بخواهید از این تنظیم فقط‑خواندنی برای محافظت از یک ارائه استفاده کنید وقتی

- می‌خواهید ویرایش‌های ناخواسته را جلوگیری کنید و محتوای ارائه‌تان را ایمن نگه دارید. 
- می‌خواهید افراد را مطلع کنید که ارائه‌ای که ارائه داده‌اید نسخه نهایی است. 

بعد از اینکه گزینه **Always Open Read-Only** را برای یک ارائه انتخاب کردید، وقتی کاربران ارائه را باز می‌کنند، توصیهٔ **Read-Only** را می‌بینند و ممکن است پیامی به شکل زیر را مشاهده کنند: *To prevent accidental changes, the author has set this file to open as read-only.*

توصیهٔ Read-Only یک بازدارندهٔ ساده اما مؤثر است که ویرایش را دلسرد می‌کند زیرا کاربران باید کاری انجام دهند تا آن را حذف کنند قبل از این که بتوانند ارائه را ویرایش کنند. اگر نمی‌خواهید کاربران تغییراتی در ارائه ایجاد کنند و می‌خواهید این موضوع را به‑صورت مؤدبانه به آن‌ها اطلاع دهید، توصیهٔ Read-Only می‌تواند گزینهٔ مناسبی برای شما باشد.

> اگر یک ارائه با حفاظت **Read-Only** در یک برنامهٔ Microsoft PowerPoint قدیمی‌تر باز شود — که از عملکرد جدید معرفی‌شده پشتیبانی نمی‌کند — توصیهٔ **Read-Only** نادیده گرفته می‌شود (ارائه به‌صورت معمولی باز می‌شود).

## **اعمال حالت فقط‑خواندنی**

Aspose.Slides برای .NET به شما امکان می‌دهد یک ارائه را به حالت **Read-Only** تنظیم کنید، به این معنا که کاربران (پس از باز کردن ارائه) توصیهٔ **Read-Only** را می‌بینند. این کد نمونه نشان می‌دهد چگونه یک ارائه را به **Read-Only** در C# با استفاده از Aspose.Slides تنظیم کنید:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    pres.ProtectionManager.ReadOnlyRecommended = true;
    pres.Save("ReadOnlyPresentation.pptx", SaveFormat.Pptx);
}
```

{{% alert color="info" %}} 

**Note**: توصیهٔ **Read-Only** صرفاً برای دلسرد کردن ویرایش یا جلوگیری از تغییرات ناخواسته کاربران در یک ارائهٔ PowerPoint است. اگر شخصی مصمم—که می‌داند چه کار می‌کند—تصمیم بگیرد ارائه شما را ویرایش کند، به راحتی می‌تواند تنظیمات فقط‑خواندنی را حذف کند. اگر به‌طور جدی نیاز به جلوگیری از ویرایش غیرمجاز دارید، بهتر است از [more stringent protections that involve encryptions and passwords](https://docs.aspose.com/slides/fa/net/password-protected-presentation/) استفاده کنید. 

{{% /alert %}} 

## **سوالات متداول**

### تفاوت «Read-Only recommended» با حفاظت کامل با رمز عبور چیست؟

«Read-Only recommended» فقط یک پیشنهاد برای باز کردن فایل در حالت فقط‑خواندنی نمایش می‌دهد و به‌راحتی می‌توان از آن عبور کرد. [Password protection](/slides/fa/net/password-protected-presentation/) در واقع باز کردن یا ویرایش را محدود می‌کند و زمانی مناسب است که به کنترل‌های امنیتی واقعی نیاز دارید.

### آیا می‌توان «Read-Only recommended» را با واترمارک‌ها ترکیب کرد تا ویرایش‌ها بیشتر دلسرد شوند؟

بله. این توصیه می‌تواند همراه با [watermarks](/slides/fa/net/watermark/) به‌عنوان یک بازدارندهٔ بصری ترکیب شود؛ آن‌ها مکانیزم‌های جداگانه‌ای هستند و به‌خوبی با هم کار می‌کنند.

### آیا یک ماکرو یا ابزار خارجی همچنان می‌تواند فایل را هنگام فعال بودن توصیه تغییر دهد؟

بله. این توصیه تغییرات برنامه‌ای را مسدود نمی‌کند. برای جلوگیری از ویرایش‌های خودکار، از [passwords and encryption](/slides/fa/net/password-protected-presentation/) استفاده کنید.

### «Read-Only recommended» چگونه به پرچم‌های «IsEncrypted» و «IsWriteProtected» مرتبط است؟

آن‌ها سیگنال‌های متفاوتی هستند. «Read-Only recommended» یک اعلان نرم و اختیاری است؛ [IsWriteProtected](https://reference.aspose.com/slides/fa/net/aspose.slides/protectionmanager/iswriteprotected/) و [IsEncrypted](https://reference.aspose.com/slides/fa/net/aspose.slides/protectionmanager/isencrypted/) محدودیت‌های واقعی نوشتن یا خواندن را نشان می‌دهند که به رمزهای عبور یا رمزنگاری وابسته هستند.