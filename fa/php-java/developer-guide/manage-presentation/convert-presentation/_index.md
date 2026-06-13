---
title: تبدیل ارائه‌ها به فرمت‌های متعدد در PHP
linktitle: تبدیل ارائه
type: docs
weight: 70
url: /fa/php-java/convert-presentation/
keywords:
- تبدیل ارائه
- صادرات ارائه
- PPT به PPTX
- PPTX به PPT
- ODP به PPTX
- PPT به PDF
- PPTX به PDF
- ODP به PDF
- PPT به HTML
- PPTX به HTML
- ODP به HTML
- PPT به PNG
- PPTX به PNG
- ODP به PNG
- PPTX به JPG
- ODP به JPG
- PPT به XPS
- PPTX به XPS
- ODP به XPS
- PPT به TIFF
- PPTX به TIFF
- ODP به TIFF
- PowerPoint
- OpenDocument
- PHP
- Aspose.Slides
description: "با Aspose.Slides برای PHP از طریق Java، ارائه‌های PowerPoint و OpenDocument را به PPTX، PDF، HTML، تصاویر، XPS، TIFF و موارد دیگر تبدیل کنید."
---
## **نگاه کلی**

Aspose.Slides برای PHP از طریق Java می‌تواند ارائه‌های PowerPoint و OpenDocument را بارگذاری کرده و بدون نیاز به Microsoft PowerPoint، OpenOffice یا LibreOffice، آنها را در بسیاری از فرمت‌های دیگر ذخیره یا رندر کند. می‌توانید فایل‌های PPT قدیمی را به PPTX مدرن تبدیل کنید، ارائه‌ها را به اسناد ثابت‑چیدمان مانند PDF و XPS صادر کنید، اسلایدها را به صورت HTML منتشر کنید یا اسلایدها را به صورت فایل‌های تصویری برای پیش‌نمایش، تصویر بندانگشتی و آرشیو رندر کنید.

اکثر تبدیل‌های سند از یک گردش کار کلی یکسان استفاده می‌کنند: بارگذاری فایل منبع، انتخاب فرمت خروجی مورد نیاز و اعمال گزینه‌های خاص فرمت در صورت نیاز. برای فرمت‌های تصویری، هر اسلاید به‌صورت جداگانه رندر شده و سپس به‌عنوان تصویر شطرنجی یا برداری ذخیره می‌شود. مقالات اختصاصی که در زیر لینک شده‌اند جزئیات پیاده‌سازی برای هر مورد را ارائه می‌دهند.

## **انتخاب سناریوی تبدیل**

از مقالات زیر برای مثال‌های کامل PHP و گزینه‌های خاص فرمت استفاده کنید.

| سناریو | زمانی استفاده می‌کنید که نیاز دارید به | مقاله |
| --- | --- | --- |
| PPT/PPTX/ODP to PPTX | به‌روز رسانی فایل‌های PPT قدیمی، نرمال‌سازی فایل‌های PPTX موجود یا تبدیل ارائه‌های OpenDocument به PowerPoint PPTX. | [تبدیل PPT به PPTX](/slides/fa/php-java/convert-ppt-to-pptx/), [تبدیل ODP به PPTX](/slides/fa/php-java/convert-odp-to-pptx/), [ذخیره ارائه‌ها](/slides/fa/php-java/save-presentation/) |
| PPTX to PPT | ذخیره یک ارائه PowerPoint مدرن به فرمت باینری قدیمی PPT برای سازگاری با جریان‌های کاری قدیمی. | [تبدیل PPTX به PPT](/slides/fa/php-java/convert-pptx-to-ppt/) |
| PPT/PPTX/ODP to PDF | ایجاد اسناد قابل حمل، قابل جستجو و ثابت‑چیدمان برای به اشتراک‌گذاری، چاپ یا آرشیو. | [تبدیل PowerPoint به PDF](/slides/fa/php-java/convert-powerpoint-to-pdf/) |
| PPT/PPTX/ODP to PDF with notes | صادرات یادداشت‌های گفتارکننده همراه با محتوای اسلاید. | [تبدیل PowerPoint به PDF با یادداشت‌ها](/slides/fa/php-java/convert-powerpoint-to-pdf-with-notes/) |
| PPT/PPTX/ODP to HTML | انتشار ارائه‌ها به عنوان صفحات HTML و کنترل تصاویر، فونت‌ها، یادداشت‌ها و گزینه‌های چیدمان واکنش‌گرها. | [تبدیل PowerPoint به HTML](/slides/fa/php-java/convert-powerpoint-to-html/) |
| PPT/PPTX/ODP to HTML5 | صادرات اسلایدها به HTML5 برای نمایش در مرورگر با حفظ فرمت‌بندی و تعامل. | [تبدیل ارائه‌ها به HTML5](/slides/fa/php-java/export-to-html5/) |
| PPT/PPTX/ODP to PNG | رندر هر اسلاید به تصویر PNG برای پیش‌نمایش، تصویر بندانگشتی یا خروجی وب. | [تبدیل PowerPoint به PNG](/slides/fa/php-java/convert-powerpoint-to-png/) |
| PPT/PPTX/ODP to JPG | رندر اسلایدها به تصاویر JPG و کنترل ابعاد و کیفیت تصویر. | [تبدیل PowerPoint به JPG](/slides/fa/php-java/convert-powerpoint-to-jpg/) |
| Slide to SVG | صادرات اسلایدهای تک‌تکه به صورت گرافیک برداری مقیاس‌پذیر. | [رندر اسلاید به SVG](/slides/fa/php-java/render-a-slide-as-an-svg-image/) |
| PPT/PPTX/ODP to XPS | تولید اسناد XPS ثابت‑چیدمان. | [تبدیل PowerPoint به XPS](/slides/fa/php-java/convert-powerpoint-to-xps/) |
| PPT/PPTX/ODP to TIFF | ذخیره یک ارائه به عنوان فایل چندصفحه‌ای TIFF برای چاپ، اسکن، فکس یا جریان‌های کاری آرشیوی. | [تبدیل PowerPoint به TIFF](/slides/fa/php-java/convert-powerpoint-to-tiff/) |
| PPT/PPTX/ODP to TIFF with notes | ذخیره اسلایدها همراه با یادداشت‌های گفتارکننده به TIFF. | [تبدیل PowerPoint به TIFF با یادداشت‌ها](/slides/fa/php-java/convert-powerpoint-to-tiff-with-notes/) |
| PPT/PPTX to Markdown | استخراج محتوای ارائه به Markdown برای مستندسازی و گردش‌های کاری متکی بر متن. | [تبدیل PowerPoint به Markdown](/slides/fa/php-java/convert-powerpoint-to-markdown/) |
| PPT/PPTX to animated GIF | ایجاد GIF متحرک از اسلایدها. | [تبدیل PowerPoint به GIF متحرک](/slides/fa/php-java/convert-powerpoint-to-animated-gif/) |
| PPT/PPTX to video | ساختن گردش کار صادرات به ویدئو از اسلایدهای ارائه. | [تبدیل PowerPoint به ویدئو](/slides/fa/php-java/convert-powerpoint-to-video/) |
| Presentation to XAML | صادرات اسلایدها به XAML برای سناریوهای UI در PHP یا Java. | [صادرات ارائه‌ها به XAML](/slides/fa/php-java/export-to-xaml/) |

برای لیست گسترده‌تری از فرمت‌های ورودی و خروجی، به [قالب‌های فایل پشتیبانی‌شده](/slides/fa/php-java/supported-file-formats/) مراجعه کنید.

## **تبدیل PowerPoint و OpenDocument**

Aspose.Slides برای PHP از طریق Java از تبدیل فرمت‌های ارائه متداول مانند PPT، PPTX، PPS، PPSX، POT، POTX و ODP پشتیبانی می‌کند. همان API تبدیل برای فایل‌های PowerPoint و OpenDocument استفاده می‌شود، بنابراین گردش کاری که یک فایل PPTX را به PDF ذخیره می‌کند معمولاً می‌تواند با تغییر تنها فایل ورودی، بر روی فایل ODP نیز اعمال شود.

در هنگام تبدیل فایل‌های ODP، به یاد داشته باشید که برنامه‌های PowerPoint و OpenDocument هر ویژگی چیدمان و فرمت‌بندی را به‌صورت یکسان پشتیبانی نمی‌کنند. اگر یک فایل ODP در LibreOffice یا OpenOffice Impress ساخته شده باشد، خروجی را بررسی کنید و از گزینه‌های توضیح‌شده در [تبدیل ارائه‌های OpenDocument](/slides/fa/php-java/convert-openoffice-odp/) استفاده کنید وقتی که نیاز به راهنمایی خاص فرمت دارید.

## **تبدیل PPT به PPTX**

PPT فرمت باینری قدیمی PowerPoint است، در حالی که PPTX فرمت مدرن Office Open XML است. Aspose.Slides برای PHP از طریق Java از تبدیل دقیق PPT به PPTX پشتیبانی می‌کند و ساختارهای پیچیده ارائه مانند مسترها، چیدمان‌ها، اسلایدها، نمودارها، اشکال گروه‌بندی‌شده، جای‌دارها، فریم‌های متن، بافت‌ها و پرکننده‌های تصویر را حفظ می‌نماید.

برای جزئیات، به [تبدیل PPT به PPTX](/slides/fa/php-java/convert-ppt-to-pptx/) و [PPT در مقابل PPTX](/slides/fa/php-java/ppt-vs-pptx/) مراجعه کنید.

## **صادرات ثابت‑چیدمان**

PDF، XPS و TIFF زمانی مفید هستند که خروجی باید در تمام دستگاه‌ها به‌یک صورت به‌نظر برسد و نباید به‌عنوان یک ارائه ویرایش شود. مقالات اختصاصی PDF، XPS و TIFF توضیح می‌دهند چگونه انطباق، اسلایدهای مخفی، یادداشت‌ها، کیفیت تصویر، فشرده‌سازی، فرمت پیکسل و اندازه خروجی را کنترل کنید.

## **صادرات HTML و تصویر**

صادرات HTML و HTML5 برای مشاهده در مرورگر، انتشار وب و اشتراک‌گذاری سبک مفید هستند. صادرات تصویر زمانی مفید است که هر اسلاید باید به‌صورت پیش‌نمایش، تصویر بندانگشتی یا دارایی شطرنجی جداگانه تبدیل شود. برای راهنمایی خاص فرمت، از مقالات PNG، JPG و SVG استفاده کنید.

## **سؤالات متداول**

**آیا برای تبدیل ارائه‌ها به Microsoft PowerPoint نیاز دارم؟**

خیر. Aspose.Slides برای PHP از طریق Java یک کتابخانه مستقل است و نیازی به Microsoft PowerPoint یا خودکارسازی Office ندارد.

**آیا می‌توانم تعداد زیادی ارائه را به صورت دسته‌ای تبدیل کنم؟**

بله. هر ارائه را بارگذاری کنید، به فرمت مورد نیاز ذخیره کنید و پس از پردازش شی ارائه را آزاد کنید. برای پردازش موازی، از نمونه‌های جداگانه ارائه استفاده کنید و راهنمایی [پردازش همزمان](/slides/fa/php-java/multithreading/) را دنبال کنید.

**آیا می‌توانم فقط اسلایدهای انتخاب‌شده را صادر کنم؟**

بله. چندین روش صادرات اجازه می‌دهند اندیس‌های اسلاید را پاس بدهید یا اسلایدهای تکی را رندر کنید، بسته به فرمت خروجی. مقاله اختصاصی برای فرمت موردنظر را ببینید.

**آیا می‌توانم اسلایدهای مخفی را هنگام صادرات به PDF یا XPS شامل کنم؟**

بله. از تنظیمات صادرات اسلایدهای مخفی که در مقالات تبدیل [PDF](/slides/fa/php-java/convert-powerpoint-to-pdf/) و [XPS](/slides/fa/php-java/convert-powerpoint-to-xps/) توضیح داده شده‌اند استفاده کنید.

**آیا می‌توانم خروجی PDF/A ایجاد کنم؟**

بله. تنظیمات انطباق PDF برای صادرات PDF موجود است. برای جزئیات، به [تبدیل PowerPoint به PDF](/slides/fa/php-java/convert-powerpoint-to-pdf/) مراجعه کنید.

**فونت‌ها در هنگام تبدیل چگونه مدیریت می‌شوند؟**

Aspose.Slides می‌تواند از فونت‌های جاسازی شده، فونت پشتیبان و تنظیمات جایگزینی فونت استفاده کند. به [فونت جاسازی شده](/slides/fa/php-java/embedded-font/)، [فونت پشتیبان](/slides/fa/php-java/fallback-font/) و [جایگزینی فونت](/slides/fa/php-java/font-substitution/) مراجعه کنید.