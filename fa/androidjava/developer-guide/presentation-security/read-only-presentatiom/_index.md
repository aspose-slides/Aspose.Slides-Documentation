---
title: ذخیره ارائه‌ها در حالت فقط‌خواندنی در اندروید
linktitle: ارائه فقط‌خواندنی
type: docs
weight: 30
url: /fa/androidjava/read-only-presentation/
keywords:
- فقط‌خواندنی
- محافظت از ارائه
- جلوگیری از ویرایش
- پاورپوینت
- OpenDocument
- ارائه
- اندروید
- جاوا
- Aspose.Slides
description: "فایل‌های PowerPoint (PPT, PPTX) را با Aspose.Slides for Android via Java در حالت فقط‌خواندنی ذخیره کنید و پیش‌نمایش دقیق اسلایدها را بدون تغییر ارائه‌های خود داشته باشید."
---
## **معرفی**

در PowerPoint 2019، مایکروسافت تنظیم **Always Open Read-Only** را به عنوان یکی از گزینه‌هایی که کاربران می‌توانند برای محافظت از ارائه‌های خود استفاده کنند، معرفی کرد. ممکن است بخواهید از این تنظیم فقط‌خواندنی برای محافظت از یک ارائه استفاده کنید زمانی که

- می‌خواهید از ویرایش‌های تصادفی جلوگیری کرده و محتوای ارائه‌تان را ایمن نگه دارید.  
- می‌خواهید به افراد اطلاع دهید که ارائه‌ای که ارائه کرده‌اید نسخه نهایی است.  

پس از انتخاب گزینه **Always Open Read-Only** برای یک ارائه، زمانی که کاربران آن را باز می‌کنند، توصیه **Read-Only** را می‌بینند و ممکن است پیامی به شکل زیر مشاهده کنند: *برای جلوگیری از تغییرات تصادفی، نویسنده این فایل را برای باز شدن به صورت فقط‌خواندنی تنظیم کرده است.*

توصیه **Read-Only** یک بازدارنده ساده اما مؤثر است که از ویرایش جلوگیری می‌کند زیرا کاربران باید کاری انجام دهند تا قبل از ویرایش ارائه، این توصیه را حذف کنند. اگر نمی‌خواهید کاربران به ارائه‌ای تغییر دهند و می‌خواهید به‌صورت مودبانه این موضوع را به آن‌ها اطلاع دهید، توصیه **Read-Only** می‌تواند گزینه مناسبی برای شما باشد.

> اگر یک ارائه با حفاظت **Read-Only** در یک نسخه قدیمی‌تر از Microsoft PowerPoint باز شود — که از عملکرد جدید پشتیبانی نمی‌کند — توصیه **Read-Only** نادیده گرفته می‌شود (ارائه به‌صورت معمولی باز می‌شود).

## **اعمال حالت فقط‌خواندنی**

Aspose.Slides for Android via Java به شما اجازه می‌دهد یک ارائه را به **Read-Only** تنظیم کنید، به این معنی که کاربران (پس از باز کردن ارائه) توصیه **Read-Only** را می‌بینند. این کد نمونه نشان می‌دهد چگونه یک ارائه را به **Read-Only** در جاوا با استفاده از Aspose.Slides تنظیم کنید:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    pres.getProtectionManager().setReadOnlyRecommended(true);
    pres.save("ReadOnlyPresentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="info" %}} 

**Note**: توصیه **Read-Only** صرفاً برای جلوگیری از ویرایش یا متوقف کردن تغییرات تصادفی در یک ارائه PowerPoint است. اگر شخصی با انگیزه— که می‌داند چه کاری انجام می‌دهد— تصمیم به ویرایش ارائه شما بگیرد، می‌تواند به راحتی تنظیم فقط‌خواندنی را حذف کند. اگر به‌طور جدی نیاز به جلوگیری از ویرایش غیرمجاز دارید، بهتر است از [محافظت‌های سخت‌گیرانه‌تر که شامل رمزنگاری و گذرواژه‌ها می‌شود](https://docs.aspose.com/slides/fa/androidjava/password-protected-presentation/) استفاده کنید.

{{% /alert %}} 

## **پرسش‌های متداول**

### 'Read-Only recommended' در مقایسه با حفاظت کامل با گذرواژه چه تفاوتی دارد؟

'Read-Only recommended' فقط یک پیشنهاد برای باز کردن فایل به‌صورت فقط‌خواندنی نمایش می‌دهد و به‌راحتی می‌توان از آن عبور کرد. [Password protection](/slides/fa/androidjava/password-protected-presentation/) در واقع باز کردن یا ویرایش را محدود می‌کند و زمانی مناسب است که به کنترل‌های واقعی امنیتی نیاز داشته باشید.

### آیا می‌توان 'Read-Only recommended' را با واترمارک‌ها ترکیب کرد تا ویرایش بیشتر متوقف شود؟

بله. این توصیه می‌تواند همراه با [watermarks](/slides/fa/androidjava/watermark/) به‌عنوان یک بازدارنده بصری استفاده شود؛ آن‌ها مکانیزم‌های متفاوتی هستند و با هم خوب کار می‌کنند.

### آیا یک ماکرو یا ابزار خارجی همچنان می‌تواند فایل را زمانی که این توصیه فعال است، تغییر دهد؟

بله. این توصیه تغییرات برنامه‌نویسی شده را مسدود نمی‌کند. برای جلوگیری از ویرایش‌های خودکار، از [passwords and encryption](/slides/fa/androidjava/password-protected-presentation/) استفاده کنید.

### 'Read-Only recommended' چگونه با متدهای 'isEncrypted' و 'isWriteProtected' مرتبط است؟

آن‌ها سیگنال‌های متفاوتی هستند. 'Read-Only recommended' یک پیام نرم و اختیاری است؛ [isWriteProtected](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/protectionmanager/#isWriteProtected--) و [isEncrypted](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/protectionmanager/#isEncrypted--) محدودیت‌های واقعی نوشتن یا خواندن را نشان می‌دهند که بر پایه گذرواژه یا رمزنگاری هستند.