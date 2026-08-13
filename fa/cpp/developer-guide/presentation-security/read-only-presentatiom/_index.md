---
title: ذخیرهٔ ارائه‌ها در حالت فقط‑خواندنی با C++
linktitle: ارائه فقط‑خواندنی
type: docs
weight: 30
url: /fa/cpp/read-only-presentation/
keywords:
- فقط‑خواندنی
- حفاظت از ارائه
- جلوگیری از ویرایش
- PowerPoint
- OpenDocument
- ارائه
- C++
- Aspose.Slides
description: "فایل‌های PowerPoint (PPT، PPTX) را در حالت فقط‑خواندنی با Aspose.Slides برای C++ بارگذاری و ذخیره کنید، پیش‌نمایش‌های دقیق اسلاید را بدون تغییر ارائه‌های شما فراهم می‌کند."
---
## **معرفی**

در PowerPoint 2019، مایکروسافت تنظیم **Always Open Read-Only** را به عنوان یکی از گزینه‌هایی که کاربران می‌توانند برای حفاظت از ارائه‌های خود استفاده کنند، معرفی کرد. ممکن است بخواهید از این تنظیم Read-Only برای حفاظت از یک ارائه استفاده کنید وقتی که

- می‌خواهید از ویرایش‌های ناخواسته جلوگیری کنید و محتوای ارائه خود را ایمن نگه دارید.  
- می‌خواهید به افراد اطلاع دهید که ارائه‌ای که ارائه می‌کنید نسخه نهایی است.  

پس از اینکه گزینه **Always Open Read-Only** را برای یک ارائه انتخاب کردید، وقتی کاربران آن را باز می‌کنند، توصیه **Read-Only** را می‌بینند و ممکن است پیامی به این شکل مشاهده کنند: *برای جلوگیری از تغییرات ناخواسته، نویسنده این فایل را برای باز شدن به صورت فقط‑خواندنی تنظیم کرده است.*

توصیه Read-Only یک مانع ساده اما مؤثر است که از ویرایش جلوگیری می‌کند، زیرا کاربران باید کاری انجام دهند تا قبل از اجازه ویرایش، این توصیه را حذف کنند. اگر نمی‌خواهید کاربران تغییراتی در ارائه ایجاد کنند و می‌خواهید این موضوع را به شکل مودبانه‌ای به آن‌ها بگویید، توصیه Read-Only می‌تواند گزینه‌ی مناسبی برای شما باشد.  

> اگر ارائه‌ای با حفاظت **Read-Only** در یک نسخهٔ قدیمی‌تری از Microsoft PowerPoint باز شود — که از این قابلیت جدید پشتیبانی نمی‌کند — توصیه **Read-Only** نادیده گرفته می‌شود (ارائه به‌طور معمول باز می‌شود).

## **اعمال حالت Read-Only**

Aspose.Slides for C++ به شما امکان می‌دهد یک ارائه را به **Read-Only** تنظیم کنید، به این معنی که کاربران (پس از باز کردن ارائه) توصیه **Read-Only** را می‌بینند. این کد نمونه نشان می‌دهد چگونه یک ارائه را به **Read-Only** در C++ با استفاده از Aspose.Slides تنظیم کنید:

``` cpp
#include <DOM/IProtectionManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>();
pres->get_ProtectionManager()->set_ReadOnlyRecommended(true);
pres->Save(u"ReadOnlyPresentation.pptx", SaveFormat::Pptx);
```

{{% alert color="info" %}} 

**توجه**: توصیه **Read-Only** صرفاً برای جلوگیری از ویرایش یا توقف تغییرات ناخواسته در یک ارائه PowerPoint طراحی شده است. اگر شخصی با انگیزه—که می‌داند چه کار می‌کند—تصمیم بگیرد ارائه شما را ویرایش کند، می‌تواند به راحتی تنظیم Read-Only را حذف کند. اگر به‌طور جدی نیاز به جلوگیری از ویرایش‌های غیرمجاز دارید، بهتر است از [حفاظت‌های سخت‌گیرانه‌تری که شامل رمزگذاری و گذرواژه هستند](https://docs.aspose.com/slides/fa/cpp/password-protected-presentation/) استفاده کنید. 

{{% /alert %}} 

## **سوالات متداول**

### «Read-Only recommended» چطور با حفاظت کامل با گذرواژه متفاوت است؟

«Read-Only recommended» فقط یک پیشنهاد برای باز کردن فایل در حالت فقط‑خواندنی نمایش می‌دهد و به‌ساده‌ای می‌توان از آن عبور کرد. [حفاظت با گذرواژه](/slides/fa/cpp/password-protected-presentation/) در واقع باز کردن یا ویرایش را محدود می‌کند و زمانی مناسب است که به کنترل‌های امنیتی واقعی نیاز داشته باشید.

### آیا می‌توان «Read-Only recommended» را با علامت‌های آبنشانی ترکیب کرد تا ویرایش‌ها بیشتر بازدارده شوند؟

بله. این توصیه می‌تواند همراه با [watermarks](/slides/fa/cpp/watermark/) به‌عنوان یک مانع بصری استفاده شود؛ آن‌ها مکانیزم‌های جداگانه‌ای هستند و به‌خوبی با یکدیگر کار می‌کنند.

### آیا یک ماکرو یا ابزار خارجی همچنان می‌تواند فایل را وقتی توصیه فعال است، تغییر دهد؟

بله. این توصیه برنامه‌نویسی تغییرات را مسدود نمی‌کند. برای جلوگیری از ویرایش‌های خودکار، از [گذرواژه‌ها و رمزگذاری](/slides/fa/cpp/password-protected-presentation/) استفاده کنید.

### «Read-Only recommended» چگونه با پرچم‌های «is encrypted» و «is write protected» مرتبط است؟

آن‌ها سیگنال‌های متفاوتی هستند. «Read-Only recommended» یک درخواست نرم و اختیاری است؛ [get_IsWriteProtected](https://reference.aspose.com/slides/fa/cpp/aspose.slides/protectionmanager/get_iswriteprotected/) و [get_IsEncrypted](https://reference.aspose.com/slides/fa/cpp/aspose.slides/protectionmanager/get_isencrypted/) محدودیت‌های واقعی نوشتن یا خواندن را نشان می‌دهند که به گذرواژه یا رمزگذاری وابسته هستند.