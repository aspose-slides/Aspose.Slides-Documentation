---
title: چرا خودکارسازی نیست
type: docs
weight: 170
url: /fa/java/why-not-automation/
keywords:
- خودکارسازی
- مایکروسافت آفیس
- مقایسه
- امنیت
- پایداری
- قابلیت مقیاس‌پذیری
- ویژگی‌ها
- پاورپوینت
- اُپن‌داکیومنت
- ارائه
- جاوا
- Aspose.Slides
description: "کشف کنید چرا خودکارسازی Office برای سرورها و سرویس‌ها خطرناک است و ببینید چگونه Aspose.Slides پردازش ارائه‌های پاورپوینت و اُپن‌داکیومنت را با امنیت بیشتر و سرعت بالاتر ارائه می‌دهد."
---
## **مقدمه**

دلایل متعددی وجود دارد که اجزای Aspose جایگزین بهتری نسبت به خودکارسازی هستند. برخی از دلایل کلیدی عبارتند از:

- امنیت
- پایداری
- قابلیت مقیاس‌پذیری/سرعت
- قیمت
- ویژگی‌ها

در ادامه توضیح مفصل‌تری از هر نکته کلیدی ارائه شده است.

## **سؤالات مهم**

دو سؤال وجود دارد که ما در Aspose اغلب می‌شنویم:

- آیا محصولات شما برای اجرا نیاز به نصب Microsoft Office دارند؟

پاسخ کوتاه و ساده **NO** است.

اجزای Aspose کاملاً مستقل هستند و هیچ‌گونه ارتباط، مجوز، حمایت یا تأیید دیگری از سوی شرکت Microsoft ندارند.

- چرا باید به جای خودکارسازی Microsoft Office از محصولات Aspose استفاده کنیم؟

اولاً، بسیاری از [مزایایی که هنگام استفاده از Aspose.Slides دریافت می‌کنید](/slides/fa/java/product-overview/) وجود دارد.

ثانیاً، خود مایکروسافت به شدت **advises against** استفاده از خودکارسازی Office در راه‌حل‌های نرم‌افزاری.

## **امنیت**

متن زیر یک نقل قول مستقیم از یک مقاله مایکروسافت است:

*"Office Applications were never intended for use server-side, and therefore do not take into consideration the security problems that are faced by distributed components. Office does not authenticate incoming requests, and does not protect you from unintentionally running macros, or starting another server that might run macros, from your server-side code. Do not open files that are uploaded to the server from an anonymous Web! Based on the security settings that were last set, the server can run macros under an Administrator or System context with full privileges and compromise your network! In addition, Office uses many client-side components (such as Simple MAPI, WinInet, MSDAIPP) that can cache client authentication information in order to speed up processing. If Office is being automated server-side, one instance may service more than one client, and because authentication information has been cached for that session, it is possible that one client can use the cached credentials of another client, and thereby gain non-granted access permissions by impersonating other users."*

محصولات Aspose بسیار امن هستند. اجزای Aspose خطر احتمالی برای منابع حیاتی سیستم ایجاد نمی‌کنند. علاوه بر این، هنگامی که یک سند توسط یک جزء Aspose باز می‌شود، ماکروها به‌صورت خودکار اجرا نمی‌شوند. اجزای Aspose با هدف ایجاد، دستکاری و ذخیره‌سازی فایل‌های Office ساخته شده‌اند. هیچ‌یک از خطرات مرتبط با بسته Microsoft Office به طور ذاتی در اجزای Aspose وجود ندارد.

## **پایداری**

متن زیر یک نقل قول مستقیم از یک مقاله مایکروسافت است:

*"Office 2000, Office XP and Office 2003 use Microsoft Windows Installer (MSI) technology to make installation and self-repair easier for an end user. MSI introduces the concept of "install on first use", which allows features to be dynamically installed or configured at runtime (for the system, or more often for a particular user). In a server-side environment this both slows down performance and increases the likelihood that a dialog box may appear that asks for the user to approve the install or provide an appropriate install disk. Although it is designed to increase the resiliency of Office as an end-user product, Office's implementation of MSI capabilities is counterproductive in a server-side environment. Furthermore, the stability of Office in general cannot be assured when run server-side because it has not been designed or tested for this type of use. Using Office as a service component on a network server may reduce the stability of that machine and as a consequence your network as a whole. If you plan to automate Office server-side, attempt to isolate the program to a dedicated computer that cannot affect critical functions, and that can be restarted as needed."*

اجزای Aspose به‌طور کامل تست شده‌اند و بسیار پایدار هستند. اجزای Aspose توسط [شرکت‌ها](https://about.aspose.com/customers/) مانند **Bank of America** و بسیاری دیگر استفاده می‌شوند.

## **قابلیت مقیاس‌پذیری/سرعت**

متن زیر یک نقل قول مستقیم از یک مقاله مایکروسافت است:

*"Server-side components need to be highly reentrant, multi-threaded COM components with minimum overhead and high throughput for multiple clients. Office Applications are in almost all respects the exact opposite. They are non-reentrant, STA-based Automation servers that are designed to provide diverse but resource-intensive functionality for a single client. They offer little scalability as a server-side solution, and have fixed limits to important elements, such as memory, which cannot be changed through configuration. More importantly, they use global resources (such as memory mapped files, global add-ins or templates, and shared Automation servers), which can limit the number of instances that can run concurrently and lead to race conditions if they are configured in a multi-client environment. Developers who plan to run more than one instance of any Office Application at the same time need to consider* ***Pooling*** *or* ***Serializing Access*** *to the Office Application for avoiding potential* ***Deadlocks*** *or* ***Data Corruption*** *.*"

اجزای Aspose بسیار مقیاس‌پذیر و فوق‌العاده سریع هستند. برنامه‌های Office برای استفاده همزمان توسط صدها یا هزاران کاربر طراحی نشده‌اند، اما اجزای Aspose دقیقاً برای این منظور ساخته شده‌اند. اجزای ما بدون مشکل بر روی یک سرور واحد، یک برنامه تک‌سرور یا یک فارم وب‌سرورهای متعادل‌شده که یک برنامه سازمانی را پشتیبانی می‌کند، اجرا می‌شوند.

## **قیمت**

زمانی که یک برنامه از خودکارسازی Microsoft Office استفاده می‌کند، باید یک نسخه از Microsoft Office برای هر ماشینی که برنامه را اجرا می‌کند خریداری شود. موارد بسیاری وجود دارد که یک برنامه نیاز به ایجاد یا دستکاری یک فایل Office دارد اما نیازی به داشتن Microsoft Office برای کاربر نیست. Aspose یک **مجوز توزیع رایگان و هزینه‌موثر** (https://purchase.aspose.com/) ارائه می‌دهد که امکان استقرار برای تعداد نامحدود کاربر بدون نگرانی‌های مجوز را فراهم می‌کند.

هنگام ایجاد برنامه‌های وب، مهم است بدانید که اجزای خودکارسازی Microsoft Office برای راه‌حل‌های سمت سرور قیمت‌گذاری یا مجوزی ندارند؛ به همین دلیل هیچ راه‌حل مجوزی مناسبی برای استقرار برنامه‌های وب که از این اجزا استفاده می‌کنند وجود ندارد. Aspose یک راه‌حل هزینه‌موثر برای برنامه‌های سمت سرور نیز ارائه می‌دهد.

## **ویژگی‌ها**

اجزای Aspose همه آنچه برای مدیریت فایل‌های Office لازم است را به‌علاوه امکانات بیشتری فراهم می‌کنند. آن‌ها با فلسفه‌ای طراحی شده‌اند که به توسعه‌دهندگان اجازه می‌دهد با کمترین تلاش بیشترین نتایج را به‌دست آورند. بر خلاف خودکارسازی Office، اجزای Aspose توابع قدرتمند و زمان‌ذریعی ارائه می‌دهند. به‌عنوان مثال، [Aspose.Cells](https://products.aspose.com/cells/java/) به توسعه‌دهندگان امکان وارد کردن داده‌ها از یک **DataTable** یا **DataView** مستقیم به یک فایل Excel را می‌دهد. [Aspose.Words](https://products.aspose.com/words/java/) ویژگی مشابهی دارد که به توسعه‌دهندگان اجازه می‌دهد یک سند Word (یعنی Mail Merge) را پر کنند. [هر جزء](https://products.aspose.com/total/java/) در خانواده Aspose مجموعه خاص و قدرتمندی از ویژگی‌ها را ارائه می‌دهد.

بهترین بخش خرید یک جزء Aspose (یا سوئیت‌هایی مانند [Aspose.Total](https://products.aspose.com/total/java/)) دسترسی به تیم‌های توسعه ماست. تیم‌های توسعه ما متوجه هستند که اگر ویژگی‌ای وجود داشته باشد که شرکت شما به آن نیاز دارد، احتمالاً شرکت‌های دیگری نیز به آن نیاز دارند. اگرچه هر درخواست ویژگی‌ای نمی‌تواند افزوده شود، تیم‌های ما سعی می‌کنند در ارائه کمک بسیار بازاندیش و انعطاف‌پذیر باشند. این طرز تفکر است که به اجزای Aspose کمک کرده تا آن‌قدر قدرتمند شوند. اگر ویژگی‌های بیشتری از اشیاء خودکارسازی Office نیاز داشته باشید، احتمال افزودن آن‌ها بسیار بسیار کم است.

## **نتیجه‌گیری**
{{% alert color="info" title="Note" %}}

در حالی که این مقاله بسیاری از نکات کلیدی که چرا اجزای Aspose انتخاب بهتری نسبت به خودکارسازی Office هستند را پوشش داد، نکات بسیار بیشتری نیز وجود دارد. این مقاله عمدتاً به مهم‌ترین نکات پرداخته است. تمام اجزای مختلف Aspose یک نسخه ارزیابی بدون ریسک و بدون تعهد [Evaluation Version](https://releases.aspose.com/slides/fa/java/) ارائه می‌دهند. ما شما را تشویق می‌کنیم تا از این نسخه ارزیابی استفاده کنید تا بهتر متوجه شوید Aspose می‌تواند برای برنامه‌های شما چه کاری انجام دهد.

{{% /alert %}}