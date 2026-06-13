---
title: چرا خودکارسازی نیست
type: docs
weight: 40
url: /fa/net/why-not-automation/
keywords:
- خودکارسازی
- مایکروسافت آفیس
- مقایسه
- امنیت
- پایداری
- مقیاس‌پذیری
- ویژگی‌ها
- پاورپوینت
- سندباز
- ارائه
- .NET
- C#
- Aspose.Slides
description: "کشف کنید چرا خودکارسازی آفیس برای سرورها و سرویس‌ها خطرناک است و ببینید Aspose.Slides چگونه پردازش ارائه‌های پاورپوینت و سندباز را ایمن‌تر و سریع‌تر می‌کند."
---
## **مقدمه**

دلایل متعددی وجود دارد که اجزای Aspose گزینه‌ای بهتر نسبت به خودکارسازی (Automation) هستند. برخی از دلایل کلیدی عبارتند از:

- امنیت
- پایداری
- مقیاس‌پذیری/سرعت
- قیمت
- ویژگی‌ها

در ادامه توضیح مفصل‌تری از هر نکته کلیدی ارائه شده است.

## **سوالات مهم**

دو سوالی که اغلب در Aspose می‌شنویم:

- آیا محصولات شما برای اجرا نیاز به نصب Microsoft Office دارند؟

پاسخ کوتاه و ساده **نه** است.

اجزای Aspose کاملاً مستقل هستند و با Microsoft Corporation مرتبط، مجاز، حمایت یا تایید نشده‌اند.

- چرا باید به جای Microsoft Office Automation از محصولات Aspose استفاده کنیم؟

اولاً، مزایای زیادی هنگام استفاده از Aspose.Slides دارید](/slides/fa/net/product-overview/).

ثانئاً، خود مایکروسافت به شدت **در مقابل** استفاده از Office Automation در راه‌حل‌های نرم‌افزاری توصیه می‌کند.

## **امنیت**
نقل قول مستقیم از یک مقاله مایکروسافت:

> "Office Applications were never intended for use server-side, and therefore do not take into consideration the security problems that are faced by distributed components. Office does not authenticate incoming requests, and does not protect you from unintentionally running macros, or starting another server that might run macros, from your server-side code. Do not open files that are uploaded to the server from an anonymous Web! Based on the security settings that were last set, the server can run macros under an Administrator or System context with full privileges and compromise your network! In addition, Office uses many client-side components (such as Simple MAPI, WinInet, MSDAIPP) that can cache client authentication information in order to speed up processing. If Office is being automated server-side, one instance may service more than one client, and because authentication information has been cached for that session, it is possible that one client can use the cached credentials of another client, and thereby gain non‑granted access permissions by impersonating other users."

محصولات Aspose بسیار **امن** هستند. اجزای Aspose در همان زمینه کاربری تمام برنامه‌های ASP.NET اجرا می‌شوند (زیر کاربر ASPNET). بنابراین، اجزای Aspose **خطر امنیتی** ایجاد نمی‌کنند. آنها همچنین منابع سیستم حساس را مصرف نمی‌کنند. علاوه بر این، هنگامی که یک اجزای Aspose یک سند را باز می‌کند، ماکروها به‌طور خودکار اجرا نمی‌شوند. اجزای Aspose برای ایجاد، دستکاری و ذخیره فایل‌های Office ساخته شده‌اند.

{{% alert color="primary" %}} 

هیچ‌یک از خطرات مرتبط با بسته Microsoft Office برای اجزای Aspose اعمال نمی‌شود.

{{% /alert %}} 

## **پایداری**
این متن یک نقل قول مستقیم از مقاله مایکروسافت اشاره‌شده قبلی است:

> "Office 2000, Office XP and Office 2003 use Microsoft Windows Installer (MSI) technology to make installation and self-repair easier for an end user. MSI introduces the concept of "install on first use", which allows features to be dynamically installed or configured at runtime (for the system, or more often for a particular user). In a server-side environment this both slows down performance and increases the likelihood that a dialog box may appear that asks for the user to approve the install or provide an appropriate install disk. Although it is designed to increase the resiliency of Office as an end-user product, Office's implementation of MSI capabilities is counterproductive in a server-side environment. Furthermore, the stability of Office in general cannot be assured when run server-side because it has not been designed or tested for this type of use. Using Office as a service component on a network server may reduce the stability of that machine and as a consequence your network as a whole. If you plan to automate Office server-side, attempt to isolate the program to a dedicated computer that cannot affect critical functions, and that can be restarted as needed."

از آنجایی که اجزای Aspose به صورت یک DLL واحد بسته‌بندی شده‌اند، کاربران هرگز نیازی به نصب بخش‌های اضافی برای عملکرد آنها ندارند. اجزای Aspose فقط توسط برنامه‌های .NET استفاده می‌شوند و هیچ بخشی از کد آنها برای انتظار پاسخ انسانی طراحی نشده است.

{{% alert color="primary" %}} 

اجزای Aspose به‌طور کامل تست شده‌اند و ثابت شده است که بسیار پایدار هستند. اجزای Aspose توسط [شرکت‌ها](http://www.aspose.com/Corporate/Aspose/Customerlist.html) مانند **IBM**، **Hilton**، **Reader's Digest**، **Bank of America** و بسیاری از سازمان‌های پیشرو در صنایع مختلف استفاده می‌شود.

{{% /alert %}} 

## **مقیاس‌پذیری/سرعت**
نقل قول مستقیم از یک مقاله مایکروسافت:

> "Server-side components need to be highly reentrant, multi-threaded COM components with minimum overhead and high throughput for multiple clients. Office Applications are in almost all respects the exact opposite. They are non-reentrant, STA-based Automation servers that are designed to provide diverse but resource-intensive functionality for a single client. They offer little scalability as a server-side solution, and have fixed limits to important elements, such as memory, which cannot be changed through configuration. More importantly, they use global resources (such as memory mapped files, global add‑ins or templates, and shared Automation servers), which can limit the number of instances that can run concurrently and lead to race conditions if they are configured in a multi‑client environment. Developers who plan to run more then one instance of any Office Application at the same time need to consider Pooling or Serializing Access to the Office Application for avoiding potential Deadlocks or Data Corruption”.

اجزای Aspose به‌طرز شگفت‌انگیزی مقیاس‌پذیر و با سرعت نور هستند. برنامه‌های Office برای استفاده همزمان توسط صدها یا هزاران کاربر طراحی نشده‌اند، اما اجزای Aspose دقیقاً برای این منظور ساخته شده‌اند. اجزای ما یک راه‌حل واقعی .NET هستند.

{{% alert color="primary" %}} 

عملکرد اجزای Aspose در یک سرور واحد (تأمین یک برنامه) یا در یک فرم وب با تعادل بار (تأمین برنامه‌ای در سطح سازمان) بی‌نقص است.

{{% /alert %}} 

## **قیمت**
هنگام استفاده از Microsoft Office Automation، باید برای هر ماشینی که برنامه را اجرا می‌کند، یک نسخه از Microsoft Office خریداری شود. بسیاری از مواردی که برنامه ممکن است نیاز به ایجاد یا دستکاری یک فایل Office داشته باشد، اما این فرآیند به Microsoft Office نیاز ندارد.

{{% alert color="primary" %}} 

Aspose یک مجوز توزیع بسیار [مقرون به صرفه](https://purchase.aspose.com/) و بدون حق امتیاز ارائه می‌دهد که امکان استقرار به تعداد نامحدودی کاربر را بدون نگرانی‌های لایسنس فراهم می‌کند.

{{% /alert %}} 

هنگام ایجاد برنامه‌های وب، باید به خاطر داشته باشید که اجزای Microsoft Office Automation هم برای سرویس‑ساید قیمت‌گذاری شده‌اند و هم تحت‌مجوز برای این نوع راه‌حل‌ها قرار ندارند. بنابراین، راه‌حل مناسبی برای لایسنس‌گذاری برنامه‌های وب مبتنی بر اجزای Microsoft Office وجود ندارد. در مقابل، Aspose یک راه‌حل بسیار [مقرون به صرفه](https://purchase.aspose.com/) برای برنامه‌های مبتنی بر سرور نیز فراهم می‌کند.

## **ویژگی‌ها**
اجزای Aspose تمام موارد مورد نیاز برای مدیریت فایل‌های Office و حتی بیشتر را فراهم می‌کنند. ما آنها را بر پایه فلسفه کمک به توسعه‌دهندگان برای دستیابی به بهترین نتایج با کمترین تلاش طراحی کرده‌ایم.

{{% alert color="primary" %}} 

بر خلاف Office Automation، اجزای Aspose امکانات قدرتمند و صرفه‌جویی در زمان بسیاری را ارائه می‌دهند.

{{% /alert %}} 

به عنوان مثال، [Aspose.Cells](https://products.aspose.com/cells/net/) به توسعه‌دهندگان امکان وارد کردن داده‌ها از یک **DataTable** یا **DataView** را به‌طور مستقیم به یک فایل Excel می‌دهد. [Aspose.Words](https://products.aspose.com/words/net/) ویژگی مشابهی دارد که به توسعه‌دهندگان اجازه می‌دهد یک سند Word (یعنی Mail Merge) را مستقیم از هر شیء داده‌ای .NET پر کنند. [هر کامپوننت](https://products.aspose.com/total/net/) در خانواده Aspose مجموعه‌ای منحصر به فرد و قدرتمند از ویژگی‌ها را ارائه می‌دهد.

بهترین بخش خرید یک کامپوننت Aspose دسترسی به تیم‌های توسعه ماست. به‌عنوان مثال، اگر از اشیای Office Automation استفاده کنید و به ویژگی‌های خاصی نیاز داشته باشید، احتمال اضافه شدن آن ویژگی‌ها بسیار، بسیار کم است. اما وضعیت با اجزای Aspose متفاوت است.

{{% alert color="primary" %}} 

تیم‌های توسعه ما می‌دانند که اگر ویژگی‌ای وجود داشته باشد که شرکت شما نیاز دارد، احتمال زیادی وجود دارد که شرکت‌های دیگر نیز به همان ویژگی نیاز داشته باشند. اگرچه می‌دانیم نمی‌توانیم همه ویژگی‌های درخواست‌شده را پیاده‌سازی کنیم، اما سعی می‌کنیم تا حد امکان بر اساس بازخورد مشتریان، ویژگی‌های بیشتری اضافه کنیم.

{{% /alert %}} 

تیم‌های ما همیشه ذهن‌باز و انعطاف‌پذیر هستند و این دلیل این است که اجزای Aspose به این قدرت رسیده‌اند.

## **نتیجه‌گیری**
{{% alert color="primary" %}} 

در حالی که این مقاله به برخی از نکات کلیدی که چرا اجزای Aspose انتخاب بهتری نسبت به Office Automation هستند پرداخته است، باید بدانید که مزایای بسیار بیشتری وجود دارد. ما تنها به برخی از مزایای اصلی اشاره کردیم.

علاوه بر این، تمام محصولات و اجزای Aspose یک نسخه ارزیابی بدون ریسک و بدون تعهد [Evaluation Version](https://downloads.aspose.com/slides/fa/net) ارائه می‌دهند. ما شما را تشویق می‌کنیم از این ارزیابی استفاده کنید تا ببینید Aspose چه کاری برای برنامه‌ها یا کسب‌وکار شما می‌تواند انجام دهد.

{{% /alert %}}