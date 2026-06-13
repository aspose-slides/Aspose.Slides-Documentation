---
title: مدیریت گرافیک‌های SmartArt در ارائه‌ها با استفاده از C++
linktitle: گرافیک‌های SmartArt
type: docs
weight: 20
url: /fa/cpp/manage-smartart-shape/
keywords:
- شیء SmartArt
- گرافیک SmartArt
- سبک SmartArt
- رنگ SmartArt
- ایجاد SmartArt
- افزودن SmartArt
- ویرایش SmartArt
- تغییر SmartArt
- دسترسی به SmartArt
- نوع طرح SmartArt
- PowerPoint
- ارائه
- C++
- Aspose.Slides
description: "ایجاد، ویرایش و استایل‌دهی گرافیک‌های SmartArt در PowerPoint را در C++ با استفاده از Aspose.Slides به‌صورت خودکار انجام دهید، با مثال‌های کد مختصر و راهنمایی‌های متمرکز بر عملکرد."
---
## **بررسی کلی**

Aspose.Slides به شما امکان می‌دهد گرافیک‌های SmartArt را به صورت برنامه‌نویسی در ارائه‌های PowerPoint ایجاد و مدیریت کنید. این مقاله توضیح می‌دهد چگونه یک شکل SmartArt را به یک اسلاید اضافه کنید، به شکل‌های SmartArt موجود دسترسی پیدا کنید، SmartArt را بر اساس نوع طرح خاصی پیدا کنید و ظاهر بصری آن را با تغییر سبک یا سبک رنگی SmartArt به‌روزرسانی کنید.

مثال‌ها نشان می‌دهند چگونه از طریق مجموعه اشکال اسلاید ارائه با اشکال SmartArt کار کنید، بررسی کنید آیا یک شکل SmartArt است و سپس ویژگی‌های آن را تغییر یا بازرسی کنید.

## **ایجاد یک شکل SmartArt**
Aspose.Slides برای C++ حالا امکان افزودن اشکال سفارشی SmartArt به اسلایدها را از ابتدا فراهم می‌کند. Aspose.Slides برای C++ ساده‌ترین API را برای ساخت اشکال SmartArt به آسان‌ترین شکل ارائه داده است. برای ایجاد یک شکل SmartArt در اسلاید، مراحل زیر را دنبال کنید:

- یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) را ایجاد کنید.
- مرجع یک اسلاید را با استفاده از شاخص آن دریافت کنید.
- یک شکل SmartArt را با تنظیم LayoutType اضافه کنید.
- ارائهٔ تغییر یافته را به صورت فایل PPTX ذخیره کنید.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CreateSmartArtShape-CreateSmartArtShape.cpp" >}}

## **دسترسی به یک شکل SmartArt در یک اسلاید**
کد زیر برای دسترسی به اشکال SmartArt که در اسلاید ارائه اضافه شده‌اند، استفاده می‌شود. در کد نمونه ما از هر شکل داخل اسلاید عبور می‌کنیم و بررسی می‌کنیم آیا یک شکل SmartArt است یا نه. اگر شکل از نوع SmartArt باشد، آن را به نمونهٔ SmartArt تبدیل می‌کنیم.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessSmartArtShape-AccessSmartArtShape.cpp" >}}

## **دسترسی به یک شکل SmartArt با نوع طرح خاص**
کد نمونه زیر به شما کمک می‌کند تا به شکل SmartArt با LayoutType خاصی دسترسی پیدا کنید. لطفاً توجه داشته باشید که نمی‌توانید LayoutType یک SmartArt را تغییر دهید زیرا این ویژگی فقط در زمان افزودن شکل SmartArt تعیین می‌شود.

- یک نمونه از کلاس `Presentation` را ایجاد کنید و ارائه‌ای که شامل شکل SmartArt است را بارگذاری کنید.
- مرجع اولین اسلاید را با استفاده از شاخص آن دریافت کنید.
- در هر شکل داخل اولین اسلاید پیمایش کنید.
- بررسی کنید آیا شکل از نوع SmartArt است و در صورت بودن، آن را به SmartArt تبدیل کنید.
- شکل SmartArt با LayoutType خاص را پیدا کنید و پس از آن عملیات مورد نیاز را انجام دهید.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessSmartArtParticularLayout-AccessSmartArtParticularLayout.cpp" >}}

## **تغییر سبک یک شکل SmartArt**
کد نمونه زیر به شما کمک می‌کند تا به شکل SmartArt با LayoutType خاص دسترسی پیدا کنید.

- یک نمونه از کلاس `Presentation` را ایجاد کنید و ارائه‌ای که شامل شکل SmartArt است را بارگذاری کنید.
- مرجع اولین اسلاید را با استفاده از شاخص آن دریافت کنید.
- در هر شکل داخل اولین اسلاید پیمایش کنید.
- بررسی کنید آیا شکل از نوع SmartArt است و در صورت بودن، آن را به SmartArt تبدیل کنید.
- شکل SmartArt با Style خاص را پیدا کنید.
- Style جدید را برای شکل SmartArt تنظیم کنید.
- ارائه را ذخیره کنید.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChangSmartArtShapeStyle-ChangSmartArtShapeStyle.cpp" >}}

## **تغییر سبک رنگی یک شکل SmartArt**
در این مثال، نحوه تغییر سبک رنگی برای هر شکل SmartArt را می‌آموزیم. کد نمونه زیر به شکل SmartArt با سبک رنگی خاص دسترسی پیدا می‌کند و سبک آن را تغییر می‌دهد.

- یک نمونه از کلاس `Presentation` را ایجاد کنید و ارائه‌ای که شامل شکل SmartArt است را بارگذاری کنید.
- مرجع اولین اسلاید را با استفاده از شاخص آن دریافت کنید.
- در هر شکل داخل اولین اسلاید پیمایش کنید.
- بررسی کنید آیا شکل از نوع SmartArt است و در صورت بودن، آن را به SmartArt تبدیل کنید.
- شکل SmartArt با Color Style خاص را پیدا کنید.
- Color Style جدید را برای شکل SmartArt تنظیم کنید.
- ارائه را ذخیره کنید.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChangeSmartArtShapeColorStyle-ChangeSmartArtShapeColorStyle.cpp" >}}

## **سوالات متداول**

**آیا می‌توانم SmartArt را به عنوان یک شیء واحد انیمیشن‌دار کنم؟**

بله. SmartArt یک شکل است، بنابراین می‌توانید همانند سایر اشکال، [انیمیشن‌های استاندارد](/slides/fa/cpp/powerpoint-animation/) را از طریق API انیمیشن‌ها (ورودی، خروجی، تأکید، مسیرهای حرکتی) اعمال کنید.

**اگر شناسه داخلی یک SmartArt را ندانم، چگونه می‌توانم آن را در یک اسلاید پیدا کنم؟**

متن جایگزین (AltText) را تنظیم کرده و سپس براساس آن مقدار جستجو کنید—این روش پیشنهادی برای یافتن شکل هدف است.

**آیا می‌توانم SmartArt را با اشکال دیگر گروه‌بندی کنم؟**

بله. می‌توانید SmartArt را با اشکال دیگر (تصاویر، جدول‌ها و غیره) گروه‌بندی کنید و سپس [گروه را دست‌کاری](/slides/fa/cpp/group/) کنید.

**چگونه می‌توانم تصویر یک SmartArt خاص را بگیرم (مثلاً برای پیش‌نمایش یا گزارش)؟**

یک تصویر/تصویر کوچک از شکل صادر کنید؛ کتابخانه می‌تواند [اشکال فردی](/slides/fa/cpp/create-shape-thumbnails/) را به فایل‌های رستری (PNG/JPG/TIFF) رندر کند.

**آیا ظاهر SmartArt هنگام تبدیل کل ارائه به PDF حفظ می‌شود؟**

بله. موتور رندرینگ برای [صادرات PDF](/slides/fa/cpp/convert-powerpoint-to-pdf/) با دقت بالا هدف‌گذاری شده است و گزینه‌های متنوعی برای کیفیت و سازگاری ارائه می‌دهد.