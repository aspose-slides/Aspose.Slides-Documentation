---
title: تبدیل ارائه‌ها به فرمت‌های متعدد در C++
linktitle: تبدیل ارائه
type: docs
weight: 70
url: /fa/cpp/convert-presentation/
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
- C++
- Aspose.Slides
description: "تبدیل ارائه‌های PowerPoint و OpenDocument به PPTX، PDF، HTML، تصاویر، XPS، TIFF و موارد دیگر با Aspose.Slides برای C++."
---
## **بررسی کلی**

Aspose.Slides برای C++ می‌تواند ارائه‌های PowerPoint و OpenDocument را بارگذاری کرده و بدون نیاز به Microsoft PowerPoint، OpenOffice یا LibreOffice، آن‌ها را به بسیاری از فرمت‌های دیگر ذخیره یا رندر کند. می‌توانید فایل‌های PPT قدیمی را به PPTX مدرن تبدیل کنید، ارائه‌ها را به اسناد ثابت‑چیدمان مانند PDF و XPS صادر کنید، اسلایدها را به صورت HTML منتشر کنید، یا اسلایدها را به فایل‌های تصویری برای پیش‌نمایش، تصویر بندانگشتی و آرشیو رندر کنید.

اکثریت تبدیلات سند از یک جریان کاری کلی استفاده می‌کنند: بارگذاری فایل منبع، انتخاب فرمت خروجی مورد نیاز و اعمال گزینه‌های مخصوص فرمت در صورت نیاز. برای فرمت‌های تصویری، هر اسلاید به‌صورت جداگانه رندر شده و سپس به عنوان تصویر رستر یا وکتور ذخیره می‌شود. مقالات اختصاصی زیر جزئیات پیاده‌سازی هر حالت را ارائه می‌دهند.

## **یک سناریوی تبدیل را انتخاب کنید**

از مقالات زیر برای مثال‌های کامل C++ و گزینه‌های مخصوص فرمت استفاده کنید.

| سناریو | زمانی که نیاز دارید | مقاله |
| --- | --- | --- |
| PPT/PPTX/ODP به PPTX | به‌روز رسانی فایل‌های PPT قدیمی، نرمال‌سازی فایل‌های PPTX موجود، یا تبدیل ارائه‌های OpenDocument به PowerPoint PPTX. | [تبدیل PPT به PPTX](/slides/fa/cpp/convert-ppt-to-pptx/), [تبدیل ODP به PPTX](/slides/fa/cpp/convert-odp-to-pptx/), [ذخیره ارائه‌ها](/slides/fa/cpp/save-presentation/) |
| PPTX به PPT | ذخیره یک ارائه مدرن PowerPoint در فرمت باینری قدیمی PPT برای سازگاری با گردش کارهای قبلی. | [تبدیل PPTX به PPT](/slides/fa/cpp/convert-pptx-to-ppt/) |
| PPT/PPTX/ODP به PDF | ایجاد اسناد قابل حمل، قابل جستجو و ثابت‑چیدمان برای اشتراک‌گذاری، چاپ یا آرشیو. | [تبدیل PowerPoint به PDF](/slides/fa/cpp/convert-powerpoint-to-pdf/) |
| PPT/PPTX/ODP به PDF با یادداشت‌ها | استخراج یادداشت‌های سخنران همراه با محتوای اسلاید. | [تبدیل PowerPoint به PDF با یادداشت‌ها](/slides/fa/cpp/convert-powerpoint-to-pdf-with-notes/) |
| PPT/PPTX/ODP به HTML | انتشار ارائه‌ها به صورت صفحات HTML و کنترل تصاویر، قلم‌ها، یادداشت‌ها و گزینه‌های چیدمان واکنش‌گرا. | [تبدیل PowerPoint به HTML](/slides/fa/cpp/convert-powerpoint-to-html/) |
| PPT/PPTX/ODP به HTML5 | استخراج اسلایدها به HTML5 برای مشاهده در مرورگر با حفظ قالب‌بندی و تعامل. | [تبدیل ارائه‌ها به HTML5](/slides/fa/cpp/export-to-html5/) |
| PPT/PPTX/ODP به PNG | رندر هر اسلاید به تصویر PNG برای پیش‌نمایش، تصویر بندانگشتی یا خروجی وب. | [تبدیل PowerPoint به PNG](/slides/fa/cpp/convert-powerpoint-to-png/) |
| PPT/PPTX/ODP به JPG | رندر اسلایدها به تصاویر JPG و کنترل ابعاد و کیفیت تصویر. | [تبدیل PowerPoint به JPG](/slides/fa/cpp/convert-powerpoint-to-jpg/) |
| اسلاید به SVG | خروجی اسلایدهای منفرد به عنوان گرافیک‌های برداری مقیاس‌پذیر. | [رندر اسلاید به SVG](/slides/fa/cpp/render-a-slide-as-an-svg-image/) |
| PPT/PPTX/ODP به XPS | تولید اسناد ثابت‑چیدمان XPS. | [تبدیل PowerPoint به XPS](/slides/fa/cpp/convert-powerpoint-to-xps/) |
| PPT/PPTX/ODP به TIFF | ذخیره یک ارائه به صورت فایل چندصفحه‌ای TIFF برای چاپ، اسکن، فکس یا گردش کارهای آرشیوی. | [تبدیل PowerPoint به TIFF](/slides/fa/cpp/convert-powerpoint-to-tiff/) |
| PPT/PPTX/ODP به TIFF با یادداشت‌ها | ذخیره اسلایدها با یادداشت‌های سخنران در قالب TIFF. | [تبدیل PowerPoint به TIFF با یادداشت‌ها](/slides/fa/cpp/convert-powerpoint-to-tiff-with-notes/) |
| PPT/PPTX به Word | تبدیل اسلایدها به سند Word زمانی که خروجی به‑صورت سند متنی نیاز است. | [تبدیل PowerPoint به Word](/slides/fa/cpp/convert-powerpoint-to-word/) |
| PPT/PPTX به Markdown | استخراج محتوای ارائه به Markdown برای مستندسازی و گردش کارهای متنی. | [تبدیل PowerPoint به Markdown](/slides/fa/cpp/convert-powerpoint-to-markdown/) |
| PPT/PPTX به GIF متحرک | ایجاد GIF متحرک از اسلایدها. | [تبدیل PowerPoint به GIF متحرک](/slides/fa/cpp/convert-powerpoint-to-animated-gif/) |
| PPT/PPTX به ویدئو | ساخت گردش کار خروجی ویدئویی از اسلایدهای ارائه. | [تبدیل PowerPoint به ویدئو](/slides/fa/cpp/convert-powerpoint-to-video/) |
| ارائه به XAML | خروجی اسلایدها به XAML برای سناریوهای UI در C++. | [صادر کردن ارائه‌ها به XAML](/slides/fa/cpp/export-to-xaml/) |

برای فهرست گسترده‌تری از فرمت‌های ورودی و خروجی، ببینید [فرمت‌های فایل پشتیبانی‌شده](/slides/fa/cpp/supported-file-formats/).

## **تبدیل PowerPoint و OpenDocument**

Aspose.Slides برای C++ از تبدیل بین فرمت‌های ارائه متداول مانند PPT، PPTX، PPS، PPSX، POT، POTX و ODP پشتیبانی می‌کند. همان API تبدیل برای فایل‌های PowerPoint و OpenDocument استفاده می‌شود، به‌طوری که یک گردش کار که یک فایل PPTX را به PDF ذخیره می‌کند، معمولاً با تغییر فقط فایل ورودی می‌تواند برای ODP نیز به کار رود.

هنگام تبدیل فایل‌های ODP به خاطر داشته باشید که برنامه‌های PowerPoint و OpenDocument هر کدام همهٔ چیدمان‌ها و ویژگی‌های قالب‌بندی را به‌صورت یکسان پشتیبانی نمی‌کنند. اگر فایلی ODP در LibreOffice یا OpenOffice Impress ایجاد شده است، خروجی را مرور کنید و هنگام نیاز به راهنمایی مخصوص فرمت، از گزینه‌های توضیح داده‌شده در [تبدیل ارائه‌های OpenDocument](/slides/fa/cpp/convert-openoffice-odp/) استفاده کنید.

## **تبدیل PPT به PPTX**

PPT فرمت باینری قدیمی PowerPoint است، در حالی که PPTX فرمت مدرن Office Open XML است. Aspose.Slides برای C++ تبدیل PPT به PPTX با دقت بالا را پشتیبانی می‌کند و ساختارهای پیچیدهٔ ارائه مانند مسترها، چیدمان‌ها، اسلایدها، نمودارها، اشکال گروهی، فضاهای نگهدارنده، فریم‌های متنی، بافت‌ها و پرکننده‌های تصویر را حفظ می‌کند.

برای جزئیات بیشتر، ببینید [تبدیل PPT به PPTX](/slides/fa/cpp/convert-ppt-to-pptx/).

## **خروجی ثابت‑چیدمان**

PDF، XPS و TIFF زمانی مفید هستند که خروجی باید در همهٔ دستگاه‌ها یک‌گونه به‌نظر برسد و به‌عنوان ارائه ویرایش نشود. مقالات اختصاصی PDF، XPS و TIFF نحوه کنترل سازگاری، اسلایدهای مخفی، یادداشت‌ها، کیفیت تصویر، فشرده‌سازی، فرمت پیکسل و اندازهٔ خروجی را شرح می‌دهند.

## **خروجی HTML و تصویر**

خروجی HTML و HTML5 برای مشاهده در مرورگر، انتشار وب و اشتراک‌گذاری سبک مفید هستند. خروجی تصویر زمانی کاربرد دارد که هر اسلاید باید به‌صورت پیش‌نمایش، تصویر بندانگشتی یا دارایی رستری جداگانه باشد. برای راهنمایی‌های رندر مخصوص فرمت، از مقالات PNG، JPG و SVG استفاده کنید.

## **سوالات متداول**

**آیا برای تبدیل ارائه‌ها به Microsoft PowerPoint نیاز دارم؟**

نه. Aspose.Slides برای C++ یک کتابخانهٔ مستقل است و نیازی به Microsoft PowerPoint یا خودکارسازی Office ندارد.

**آیا می‌توانم به‌صورت دسته‌ای بسیاری از ارائه‌ها را تبدیل کنم؟**

بله. هر ارائه را بارگذاری کنید، به فرمت مورد نیاز ذخیره کنید و پس از پردازش شیٔ ارائه را آزاد کنید. برای پردازش موازی، از نمونه‌های جداگانهٔ ارائه استفاده کنید و راهنمایی‌های [چندنخی](/slides/fa/cpp/multithreading/) را دنبال کنید.

**آیا می‌توانم فقط اسلایدهای انتخابی را استخراج کنم؟**

بله. چندین روش خروجی اجازه می‌دهند ایندکس‌های اسلاید را پاس کنید یا اسلایدهای منفرد را رندر کنید، بسته به فرمت خروجی. مقالهٔ اختصاصی برای فرمت هدف را ببینید.

**آیا می‌توانم اسلایدهای مخفی را هنگام خروجی به PDF یا XPS شامل کنم؟**

بله. از تنظیمات خروجی اسلایدهای مخفی توضیح داده‌شده در مقالات [PDF](/slides/fa/cpp/convert-powerpoint-to-pdf/) و [XPS](/slides/fa/cpp/convert-powerpoint-to-xps/) استفاده کنید.

**آیا می‌توانم خروجی PDF/A تولید کنم؟**

بله. تنظیمات سازگاری PDF برای خروجی PDF موجود است. برای جزئیات بیشتر، ببینید [تبدیل PowerPoint به PDF](/slides/fa/cpp/convert-powerpoint-to-pdf/).

**فونت‌ها در هنگام تبدیل چگونه مدیریت می‌شوند؟**

Aspose.Slides می‌تواند از فونت‌های توکار، بازگشت فونت و تنظیمات جایگزینی فونت استفاده کند. به مقالات [فونت توکار](/slides/fa/cpp/embedded-font/)، [فونت بازگشتی](/slides/fa/cpp/fallback-font/) و [جایگزینی فونت](/slides/fa/cpp/font-substitution/) مراجعه کنید.