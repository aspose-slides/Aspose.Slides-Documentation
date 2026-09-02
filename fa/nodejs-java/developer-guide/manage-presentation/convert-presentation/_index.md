---
title: تبدیل ارائه‌ها به چندین فرمت در JavaScript
linktitle: تبدیل ارائه
type: docs
weight: 70
url: /fa/nodejs-java/convert-presentation/
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
- Node.js
- JavaScript
- Aspose.Slides
description: تبدیل ارائه‌های PowerPoint و OpenDocument به PPTX، PDF، HTML، تصاویر، XPS، TIFF و موارد دیگر با Aspose.Slides برای Node.js via Java.
---
## **نمای کلی**

Aspose.Slides for Node.js via Java می‌تواند ارائه‌های PowerPoint و OpenDocument را بارگذاری کرده و بدون نیاز به Microsoft PowerPoint، OpenOffice یا LibreOffice، آن‌ها را در بسیاری از فرمت‌های دیگر ذخیره یا رندر کند. می‌توانید فایل‌های PPT قدیمی را به PPTX مدرن تبدیل کنید، ارائه‌ها را به اسناد با طرح ثابت مانند PDF و XPS صادر کنید، اسلایدها را به‌صورت HTML منتشر کنید یا اسلایدها را به‌عنوان فایل‌های تصویر برای پیش‌نمایش، تصویر بندانگشتی و آرشیو رندر کنید.

اکثر تبدیل‌های سند از یک جریان کاری کلی مشابه استفاده می‌کنند: بارگذاری فایل منبع، انتخاب فرمت خروجی مورد نیاز و در صورت لزوم اعمال گزینه‌های مرتبط با فرمت. برای فرمت‌های تصویری، هر اسلاید به‌صورت جداگانه رندر شده و سپس به‌عنوان تصویر رستر یا وکتور ذخیره می‌شود. مقالات اختصاصی پیوند داده شده در زیر جزئیات پیاده‌سازی هر مورد را ارائه می‌دهند.

## **انتخاب یک سناریوی تبدیل**

از مقالات زیر برای مثال‌های کامل JavaScript و گزینه‌های مخصوص هر فرمت استفاده کنید.

| سناریو | زمانی که نیاز دارید | مقاله |
| --- | --- | --- |
| PPT/PPTX/ODP به PPTX | مدرن‌سازی فایل‌های PPT قدیمی، نرمال‌سازی فایل‌های PPTX موجود، یا تبدیل ارائه‌های OpenDocument به PowerPoint PPTX. | [تبدیل PPT به PPTX](/slides/fa/nodejs-java/convert-ppt-to-pptx/), [تبدیل ODP به PPTX](/slides/fa/nodejs-java/convert-odp-to-pptx/), [ذخیره ارائه‌ها](/slides/fa/nodejs-java/save-presentation/) |
| PPTX به PPT | ذخیره یک ارائه PowerPoint مدرن به فرمت باینری قدیمی PPT برای سازگاری با گردش‌کارهای قدیمی. | [تبدیل PPTX به PPT](/slides/fa/nodejs-java/convert-pptx-to-ppt/) |
| PPT/PPTX/ODP به PDF | ایجاد اسناد قابل حمل، جستجوپذیر و با طرح ثابت برای اشتراک‌گذاری، چاپ یا آرشیو. | [تبدیل PowerPoint به PDF](/slides/fa/nodejs-java/convert-powerpoint-to-pdf/) |
| PPT/PPTX/ODP به PDF با یادداشت‌ها | استخراج یادداشت‌های سخنران همراه با محتوای اسلاید. | [تبدیل PowerPoint به PDF با یادداشت‌ها](/slides/fa/nodejs-java/convert-powerpoint-to-pdf-with-notes/) |
| PPT/PPTX/ODP به HTML | انتشار ارائه‌ها به صورت صفحات HTML و کنترل تصاویر، قلم‌ها، یادداشت‌ها و گزینه‌های طرح واکنش‌گرا. | [تبدیل PowerPoint به HTML](/slides/fa/nodejs-java/convert-powerpoint-to-html/) |
| PPT/PPTX/ODP به HTML5 | استخراج اسلایدها به HTML5 برای مشاهده در مرورگر با حفظ قالب‌بندی و تعامل. | [تبدیل ارائه‌ها به HTML5](/slides/fa/nodejs-java/export-to-html5/) |
| PPT/PPTX/ODP به PNG | رندر هر اسلاید به تصویر PNG برای پیش‌نمایش، تصویر بندانگشتی یا خروجی وب. | [تبدیل PowerPoint به PNG](/slides/fa/nodejs-java/convert-powerpoint-to-png/) |
| PPT/PPTX/ODP به JPG | رندر اسلایدها به تصاویر JPG و کنترل ابعاد و کیفیت تصویر. | [تبدیل PowerPoint به JPG](/slides/fa/nodejs-java/convert-powerpoint-to-jpg/) |
| اسلاید به SVG | استخراج اسلایدهای فردی به عنوان گرافیک‌های برداری مقیاس‌پذیر. | [رندر اسلاید به SVG](/slides/fa/nodejs-java/render-a-slide-as-an-svg-image/) |
| PPT/PPTX/ODP به XPS | تولید اسناد XPS با طرح ثابت. | [تبدیل PowerPoint به XPS](/slides/fa/nodejs-java/convert-powerpoint-to-xps/) |
| PPT/PPTX/ODP به TIFF | ذخیره یک ارائه به عنوان فایل TIFF چندصفحه‌ای برای چاپ، اسکن، فکس یا گردش‌کارهای آرشیوی. | [تبدیل PowerPoint به TIFF](/slides/fa/nodejs-java/convert-powerpoint-to-tiff/) |
| PPT/PPTX/ODP به TIFF با یادداشت‌ها | ذخیره اسلایدها همراه با یادداشت‌های سخنران به TIFF. | [تبدیل PowerPoint به TIFF با یادداشت‌ها](/slides/fa/nodejs-java/convert-powerpoint-to-tiff-with-notes/) |
| PPT/PPTX به Markdown | استخراج محتوای ارائه به Markdown برای مستندسازی و گردش‌کارهای متنی. | [تبدیل PowerPoint به Markdown](/slides/fa/nodejs-java/convert-powerpoint-to-markdown/) |
| PPT/PPTX/ODP به XML | ایجاد یک ارائه PowerPoint XML مبتنی بر متن برای بازرسی، مقایسه، عیب‌یابی یا گردش‌کارهای مبتنی بر XML. | [تبدیل PowerPoint به XML](/slides/fa/nodejs-java/convert-powerpoint-to-xml/) |
| PPT/PPTX به GIF متحرک | ایجاد یک GIF متحرک از اسلایدها. | [تبدیل PowerPoint به GIF متحرک](/slides/fa/nodejs-java/convert-powerpoint-to-animated-gif/) |
| PPT/PPTX به ویدیو | ساخت یک گردش‌کار صادرات ویدیو از اسلایدهای ارائه. | [تبدیل PowerPoint به ویدیو](/slides/fa/nodejs-java/convert-powerpoint-to-video/) |
| ارائه به XAML | استخراج اسلایدها به XAML برای سناریوهای UI در JavaScript یا Java. | [صادرات ارائه‌ها به XAML](/slides/fa/nodejs-java/export-to-xaml/) |

برای لیست گسترده‌تر فرمت‌های ورودی و خروجی، به [فرمت‌های فایل پشتیبانی‌شده](/slides/fa/nodejs-java/supported-file-formats/) مراجعه کنید.

## **تبدیل PowerPoint و OpenDocument**

Aspose.Slides for Node.js via Java از تبدیل بین فرمت‌های ارائه‌ای پرکاربرد مانند PPT، PPTX، PPS، PPSX، POT، POTX و ODP پشتیبانی می‌کند. همان API تبدیل برای فایل‌های PowerPoint و OpenDocument استفاده می‌شود، بنابراین یک گردش‌کار که یک فایل PPTX را به PDF ذخیره می‌کند، معمولاً می‌تواند با تغییر فقط فایل ورودی به ODP اعمال شود.

در زمان تبدیل فایل‌های ODP، به یاد داشته باشید که برنامه‌های PowerPoint و OpenDocument هر ویژگی چیدمان و قالب‌بندی را دقیقاً به‌طور یکسان پشتیبانی نمی‌کنند. اگر فایلی ODP در LibreOffice یا OpenOffice Impress ایجاد شده باشد، خروجی را بررسی کنید و از گزینه‌های توضیح داده شده در [تبدیل ارائه‌های OpenDocument](/slides/fa/nodejs-java/convert-openoffice-odp/) هنگام نیاز به راهنمایی‌های خاص فرمت استفاده کنید.

## **تبدیل PPT به PPTX**

PPT فرمت باینری قدیمی PowerPoint است، در حالی که PPTX فرمت مدرن Office Open XML می‌باشد. Aspose.Slides for Node.js via Java تبدیل دقیق PPT به PPTX را با حفظ ساختارهای پیچیده ارائه مانند مسترها، لایه‌ها، اسلایدها، نمودارها، اشکال گروهی، مکان‌گیرها، فریم‌های متنی، بافت‌ها و پرکننده‌های تصویر پشتیبانی می‌کند.

برای جزئیات بیشتر، به [تبدیل PPT به PPTX](/slides/fa/nodejs-java/convert-ppt-to-pptx/) و [PPT در مقابل PPTX](/slides/fa/nodejs-java/ppt-vs-pptx/) مراجعه کنید.

## **صادرات با طرح ثابت**

PDF، XPS و TIFF هنگامی مفید هستند که خروجی باید در همه دستگاه‌ها یک‌گونه به‌نظر برسد و به‌عنوان یک ارائه ویرایش‌پذیر نباشد. مقالات اختصاصی PDF، XPS و TIFF توضیح می‌دهند چگونه تطبیق، اسلایدهای پنهان، یادداشت‌ها، کیفیت تصویر، فشرده‌سازی، فرمت پیکسل و اندازه خروجی را کنترل کنید.

## **صادرات HTML و تصویر**

صادرات HTML و HTML5 برای نمایش در مرورگر، انتشار وب و اشتراک‌گذاری سبک مناسب است. صادرات تصویر زمانی مفید است که هر اسلاید باید به‌عنوان یک پیش‌نمایش، تصویر بندانگشتی یا دارایی رستری جداگانه درآید. برای راهنمایی‌های خاص فرمت، به مقالات PNG، JPG و SVG مراجعه کنید.

## **سوالات متداول**

**آیا برای تبدیل ارائه‌ها به Microsoft PowerPoint نیاز دارم؟**

نه. Aspose.Slides for Node.js via Java یک کتابخانه مستقل است و نیازی به Microsoft PowerPoint یا خودکارسازی Office ندارد.

**آیا می‌توانم به‌صورت دسته‌ای بسیاری از ارائه‌ها را تبدیل کنم؟**

بله. هر ارائه را بارگذاری کنید، به فرمت مورد نیاز ذخیره کنید و پس از پردازش شی ارائه را آزاد کنید. برای پردازش موازی، از نمونه‌های جداگانه ارائه استفاده کنید و راهنمایی‌های [چندریسمانی](/slides/fa/nodejs-java/multithreading/) را دنبال کنید.

**آیا می‌توانم فقط اسلایدهای انتخابی را صادر کنم؟**

بله. چندین روش صادرات امکان عبور ایندکس‌های اسلاید یا رندر اسلایدهای منفرد را بسته به فرمت خروجی فراهم می‌کنند. مقاله اختصاصی برای فرمت هدف را ببینید.

**آیا می‌توانم اسلایدهای پنهان را هنگام صادرات به PDF یا XPS شامل کنم؟**

بله. از تنظیمات صادرات اسلایدهای پنهان که در مقالات [PDF](/slides/fa/nodejs-java/convert-powerpoint-to-pdf/) و [XPS](/slides/fa/nodejs-java/convert-powerpoint-to-xps/) توضیح داده شده‌اند استفاده کنید.

**آیا می‌توانم خروجی PDF/A ایجاد کنم؟**

بله. تنظیمات تطبیق PDF برای صادرات PDF در دسترس هستند. برای جزئیات به [تبدیل PowerPoint به PDF](/slides/fa/nodejs-java/convert-powerpoint-to-pdf/) مراجعه کنید.

**فونت‌ها هنگام تبدیل چگونه مدیریت می‌شوند؟**

Aspose.Slides می‌تواند از فونت‌های داخلی، بازگشت به فونت پیش‌فرض و تنظیمات جایگزینی فونت استفاده کند. به مقالات [فونت داخلی](/slides/fa/nodejs-java/embedded-font/)، [فونت بازگشتی](/slides/fa/nodejs-java/fallback-font/) و [جایگزینی فونت](/slides/fa/nodejs-java/font-substitution/) نگاه کنید.