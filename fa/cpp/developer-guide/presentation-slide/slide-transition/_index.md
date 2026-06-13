---
title: مدیریت انتقال‌های اسلاید در ارائه‌ها با استفاده از C++
linktitle: انتقال اسلاید
type: docs
weight: 80
url: /fa/cpp/slide-transition/
keywords:
- انتقال اسلاید
- افزودن انتقال اسلاید
- اعمال انتقال اسلاید
- انتقال اسلاید پیشرفته
- انتقال مورف
- نوع انتقال
- اثر انتقال
- PowerPoint
- OpenDocument
- ارائه
- C++
- Aspose.Slides
description: "کشف کنید چگونه می‌توانید انتقال‌های اسلاید را در Aspose.Slides برای C++ سفارشی کنید، با راهنمایی گام به گام برای ارائه‌های PowerPoint و OpenDocument."
---
## **نمای کلی**

این مقاله توضیح می‌دهد که چگونه انتقال‌های اسلاید را در ارائه‌ها با استفاده از Aspose.Slides مدیریت کنید. نشان می‌دهد چگونه انواع انتقال را به اسلایدها اعمال کنید، رفتار انتقال مانند پیشرفت با کلیک یا پس از زمان مشخصی را پیکربندی کنید، پیشرفت خودکار را بررسی و غیرفعال کنید، از انتقال Morph و انواع آن استفاده کنید و گزینه‌های اثر انتقال را تنظیم کنید. مثال‌ها نشان می‌دهند چگونه یک ارائه را بارگذاری یا ایجاد کنید، تنظیمات انتقال اسلایدهای انتخاب‌شده را تغییر دهید و نتیجه را به صورت فایل PPTX ذخیره کنید. مقاله همچنین به سؤالات رایج درباره سرعت انتقال، صداهای انتقال، اعمال یک‌سان انتقال بر روی اسلایدهای متعدد و بررسی انتقال فعلی تنظیم‌شده بر روی یک اسلاید پاسخ می‌دهد.

## **افزودن انتقال اسلاید**
برای ساده‌سازی، ما استفاده از Aspose.Slides برای C++ را برای مدیریت انتقال‌های ساده اسلاید نشان دادیم. توسعه‌دهندگان می‌توانند نه تنها اثرهای انتقال مختلف را بر اسلایدها اعمال کنند، بلکه رفتار این اثرها را نیز سفارشی کنند. برای ایجاد یک اثر انتقال ساده اسلاید، مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.presentation) ایجاد کنید.
1. یک نوع انتقال اسلاید را از میان اثرهای انتقالی که Aspose.Slides برای C++ از طریق enum TransitionType ارائه می‌دهد، بر اسلاید اعمال کنید.
1. فایل ارائهٔ تغییر یافته را بنویسید.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ManageSimpleSlideTransitions-ManageSimpleSlideTransitions.cpp" >}}

## **افزودن انتقال پیشرفته اسلاید**
در بخش پیشین فقط یک اثر انتقال ساده بر اسلاید اعمال کردیم. حال برای بهبود و کنترل بیشتر این اثر ساده، مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.presentation) ایجاد کنید.
1. یک نوع انتقال اسلاید را از میان اثرهای انتقالی که Aspose.Slides برای C++ ارائه می‌دهد، بر اسلاید اعمال کنید.
1. می‌توانید انتقال را به حالت پیشرفت با کلیک، پس از مدت زمان مشخص یا هر دو تنظیم کنید.
1. اگر انتقال اسلاید به حالت پیشرفت با کلیک فعال باشد، فقط هنگام کلیک ماوس پیشرفت می‌کند. علاوه بر این، اگر ویژگی Advance After Time تنظیم شده باشد، انتقال به‌صورت خودکار پس از گذشت زمان مشخص پیشرفت می‌کند.
1. فایل ارائهٔ تغییر یافته را به عنوان یک فایل ارائه بنویسید.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ManagingBetterSlideTransitions-ManagingBetterSlideTransitions.cpp" >}}

## **انتقال Morph**
Aspose.Slides برای C++ اکنون از انتقال Morph پشتیبانی می‌کند. این انتقال جدیدی است که در PowerPoint 2019 معرفی شده است. انتقال Morph به شما امکان می‌دهد حرکت‌ٔ صاف از یک اسلاید به اسلاید بعدی را انیمیشن کنید. این مقاله مفهوم و نحوه استفاده از انتقال Morph را شرح می‌دهد. برای استفاده موثر از انتقال Morph، به دو اسلاید با حداقل یک شیء مشترک نیاز دارید. ساده‌ترین روش این است که اسلاید را کپی کنید و سپس شیء را در اسلاید دوم به مکان دیگری منتقل کنید.

کد زیر نشان می‌دهد چگونه یک کپی از اسلاید حاوی متنی به ارائه اضافه کنید و برای اسلاید دوم انتقال نوع morph تنظیم کنید.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SupportOfMorphTransition-SupportOfMorphTransition.cpp" >}}

## **انواع انتقال Morph**
enum جدید Aspose.Slides.SlideShow.TransitionMorphType اضافه شده است. این enum انواع مختلف انتقال اسلاید Morph را نمایندگی می‌کند.

enum TransitionMorphType دارای سه عضو است:

- ByObject: انتقال Morph بر اساس در نظر گرفتن اشکال به‌عنوان شیءهای غیرقابل تقسیم انجام می‌شود.
- ByWord: انتقال Morph با انتقال متن به صورت کلمه به کلمه، تا حد امکان، انجام می‌شود.
- ByChar: انتقال Morph با انتقال متن به صورت کاراکتر به کاراکتر، تا حد امکان، انجام می‌شود.

کد زیر نشان می‌دهد چگونه انتقال Morph را بر اسلاید تنظیم کنید و نوع Morph را تغییر دهید:

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SetTransitionMorphType-SetTransitionMorphType.cpp" >}}

## **تنظیم اثرهای انتقال**
Aspose.Slides برای C++ از تنظیم اثرهای انتقال مانند از سیاه، از چپ، از راست و غیره پشتیبانی می‌کند. برای تنظیم اثر انتقال، مراحل زیر را دنبال کنید:

- یک نمونه از کلاس Presentation ایجاد کنید.
- مرجع اسلاید را دریافت کنید.
- اثر انتقال را تنظیم کنید.
- ارائه را به صورت فایل PPTX بنویسید.

در مثال زیر، اثرهای انتقال را تنظیم کرده‌ایم.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetTransitionEffects-SetTransitionEffects.cpp" >}}

## **FAQ**

**آیا می‌توانم سرعت پخش انتقال اسلاید را کنترل کنم؟**

بله. سرعت انتقال را با استفاده از تنظیم [TransitionSpeed](https://reference.aspose.com/slides/fa/cpp/aspose.slides.slideshow/transitionspeed/) (مثلاً آهسته/متوسط/سریع) تنظیم کنید.

**آیا می‌توانم صدا را به یک انتقال وصل کنم و آن را به‌صورت حلقه‌ای پخش کنم؟**

بله. می‌توانید صدا را برای انتقال جاسازی کنید و رفتار آن را از طریق تنظیماتی مانند حالت صدا و حلقه (مثلاً [set_Sound](https://reference.aspose.com/slides/fa/cpp/aspose.slides.slideshow/slideshowtransition/set_sound/)، [set_SoundMode](https://reference.aspose.com/slides/fa/cpp/aspose.slides.slideshow/slideshowtransition/set_soundmode/)، [set_SoundLoop](https://reference.aspose.com/slides/fa/cpp/aspose.slides.slideshow/slideshowtransition/set_soundloop/)) و همچنین متادیتاهایی مانند [set_SoundIsBuiltIn](https://reference.aspose.com/slides/fa/cpp/aspose.slides.slideshow/slideshowtransition/set_soundisbuiltin/) و [set_SoundName](https://reference.aspose.com/slides/fa/cpp/aspose.slides.slideshow/slideshowtransition/set_soundname/) تنظیم کنید.

**سریع‌ترین راه برای اعمال یک‌سان همان انتقال بر تمام اسلایدها چیست؟**

نوع انتقال دلخواه را بر تنظیمات انتقال هر اسلاید پیکربندی کنید؛ انتقال‌ها به‌صورت جداگانه برای هر اسلاید ذخیره می‌شوند، بنابراین اعمال یک نوع انتقال یکسان بر همه اسلایدها نتیجهٔ یکسانی می‌دهد.

**چگونه می‌توانم بررسی کنم که در حال حاضر چه انتقالی بر یک اسلاید تنظیم شده است؟**

تنظیمات [transition](https://reference.aspose.com/slides/fa/cpp/aspose.slides/baseslide/get_slideshowtransition/) اسلاید را بررسی کنید و نوع [transition](https://reference.aspose.com/slides/fa/cpp/aspose.slides.slideshow/slideshowtransition/get_type/) آن را بخوانید؛ این مقدار دقیقاً نشان می‌دهد کدام اثر اعمال شده است.