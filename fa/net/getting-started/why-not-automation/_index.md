---
title: چرا خودکارسازی نیست
type: docs
weight: 40
url: /fa/net/why-not-automation/
keywords:
- اتوماسیون
- مایکروسافت آفیس
- مقایسه
- امنیت
- پایداری
- مقیاس‌پذیری
- ویژگی‌ها
- پاورپوینت
- OpenDocument
- ارائه
- .NET
- C#
- Aspose.Slides
description: "کشف کنید چرا خودکارسازی آفیس برای سرورها و سرویس‌ها خطرناک است و ببینید چگونه Aspose.Slides پردازش ارائه‌های پاورپوینت و OpenDocument را ایمن‌تر و سریع‌تر ارائه می‌دهد."
---
## **مقدمه**

چندین دلیل وجود دارد که اجزای Aspose گزینه بهتری نسبت به خودکارسازی هستند. برخی از دلایل کلیدی عبارتند از:

- امنیت
- پایداری
- مقیاس‌پذیری/سرعت
- قیمت
- ویژگی‌ها

در زیر توضیحی دقیق‌تر درباره هر نکته کلیدی ارائه شده است.

## **سؤال‌های مهم**

دو سؤال وجود دارد که ما در Aspose اغلب می‌شنویم:

- آیا محصولات شما برای اجرا نیاز به نصب Microsoft Office دارند؟

پاسخ کوتاه و ساده **خیر** است.

اجزای Aspose کاملاً مستقل هستند و با Microsoft Corporation مرتبط، مجوز، حمایت یا تأیید دیگری ندارند.

- چرا باید به جای خودکارسازی Microsoft Office از محصولات Aspose استفاده کنیم؟

اول، [مزایای که هنگام استفاده از Aspose.Slides دریافت می‌کنید](/slides/fa/net/product-overview/).

دوم، خود مایکروسافت قویاً **توصیه می‌کند** از استفاده برنامه‌های نرم‌افزاری برای خودکارسازی Office خودداری کنید.

## **امنیت**
متن زیر یک نقل قول مستقیم از یک مقاله مایکروسافت است: 

> "Office Applications were never intended for use server-side, and therefore do not take into consideration the security problems that are faced by distributed components. Office does not authenticate incoming requests, and does not protect you from unintentionally running macros, or starting another server that might run macros, from your server-side code. Do not open files that are uploaded to the server from an anonymous Web! Based on the security settings that were last set, the server can run macros under an Administrator or System context with full privileges and compromise your network! In addition, Office uses many client-side components (such as Simple MAPI, WinInet, MSDAIPP) that can cache client authentication information in order to speed up processing. If Office is being automated server-side, one instance may service more than one client, and because authentication information has been cached for that session, it is possible that one client can use the cached credentials of another client, and thereby gain non-granted access permissions by impersonating other users."

محصولات Aspose بسیار **امن** هستند. اجزای Aspose در همان زمینه کاربری که تمام برنامه‌های ASP.NET اجرا می‌شوند (تحت کاربر ASPNET) اجرا می‌شوند. بنابراین، اجزای Aspose **خطر امنیتی** ندارند. آنها همچنین منابع سیستمی حیاتی را مصرف نمی‌کنند. علاوه بر این، هنگامی که یک جزء Aspose یک سند را باز می‌کند، ماکروها به طور خودکار اجرا نمی‌شوند. اجزای Aspose برای این ساخته شده‌اند که به توسعه‌دهندگان امکان ایجاد، دستکاری و ذخیره فایل‌های Office را بدهند.

{{% alert color="info" %}} 
هیچ‌یک از خطرات مرتبط با بسته Microsoft Office برای اجزای Aspose اعمال نمی‌شود.
{{% /alert %}} 

## **پایداری**
این متن یک نقل قول مستقیم از مقاله مایکروسافت مورد اشاره قبلی است: 

> "Office 2000, Office XP and Office 2003 use Microsoft Windows Installer (MSI) technology to make installation and self-repair easier for an end user. MSI introduces the concept of "install on first use", which allows features to be dynamically installed or configured at runtime (for the system, or more often for a particular user). In a server-side environment this both slows down performance and increases the likelihood that a dialog box may appear that asks for the user to approve the install or provide an appropriate install disk. Although it is designed to increase the resiliency of Office as an end-user product, Office's implementation of MSI capabilities is counterproductive in a server-side environment. Furthermore, the stability of Office in general cannot be assured when run server-side because it has not been designed or tested for this type of use. Using Office as a service component on a network server may reduce the stability of that machine and as a consequence your network as a whole. If you plan to automate Office server-side, attempt to isolate the program to a dedicated computer that cannot affect critical functions, and that can be restarted as needed."

از آنجا که اجزای Aspose به صورت یک DLL تک بسته‌بندی شده‌اند، کاربران هرگز نیازی به نصب بخش‌ها یا قطعات اضافی برای عملکرد آن ندارند. اجزای Aspose فقط توسط برنامه‌های .NET مورد استفاده قرار می‌گیرند و هیچ بخشی از کد این اجزا برای انتظار برای پاسخ انسانی طراحی نشده است.

{{% alert color="info" %}} 
اجزای Aspose به‌طور کامل تست شده‌اند و بسیار پایدار هستند. اجزای Aspose توسط [شرکت‌ها](http://www.aspose.com/Corporate/Aspose/Customerlist.html) مانند **IBM**, **Hilton**, **Reader's Digest**, **Bank of America** و بسیاری از سازمان‌های پیشرو در صنایع و حوزه‌های مختلف استفاده می‌شود.
{{% /alert %}} 

## **مقیاس‌پذیری/سرعت**
متن زیر یک نقل قول مستقیم از یک مقاله مایکروسافت است: 

> "Server-side components need to be highly reentrant, multi-threaded COM components with minimum overhead and high throughput for multiple clients. Office Applications are in almost all respects the exact opposite. They are non-reentrant, STA-based Automation servers that are designed to provide diverse but resource-intensive functionality for a single client. They offer little scalability as a server-side solution, and have fixed limits to important elements, such as memory, which cannot be changed through configuration. More importantly, they use global resources (such as memory mapped files, global add-ins or templates, and shared Automation servers), which can limit the number of instances that can run concurrently and lead to race conditions if they are configured in a multi-client environment. Developers who plan to run more then one instance of any Office Application at the same time need to consider Pooling or Serializing Access to the Office Application for avoiding potential Deadlocks or Data Corruption”.

اجزای Aspose به‌طور باورنکردنی مقیاس‌پذیر و فوق‌العاده سریع هستند. برنامه‌های Office برای استفاده همزمان توسط صدها یا هزاران کاربر طراحی نشده‌اند، اما اجزای Aspose دقیقاً برای این منظور ساخته شده‌اند. اجزای ما یک راه‌حل واقعی .NET هستند.

{{% alert color="info" %}} 
عملکرد اجزای Aspose در یک سرور تک (پشتیبانی از یک برنامه) یا در یک فرم وب با تعادل بار (پشتیبانی از برنامه‌ای در سرتاسر سازمان) بدون نقص است.
{{% /alert %}} 

## **قیمت**
هنگامی که یک برنامه از خودکارسازی Microsoft Office استفاده می‌کند، باید یک نسخه از Microsoft Office برای هر دستگاهی که برنامه را اجرا می‌کند خریداری شود. بسیاری از مواردی که یک برنامه ممکن است نیاز داشته باشد تا یک فایل Office را ایجاد یا دستکاری کند، اما این فرآیند نیازی به Microsoft Office ندارد.

{{% alert color="info" %}} 
Aspose یک مجوز توزیع بسیار [ارزش‌صرفه](https://purchase.aspose.com/) و بدون حق امتیاز ارائه می‌دهد که امکان استقرار به تعداد نامحدود کاربران را بدون نگرانی از مجوزها فراهم می‌کند.
{{% /alert %}} 

در هنگام ایجاد برنامه‌های وب، باید به یاد داشته باشید که اجزای خودکارسازی Microsoft Office نه قیمت‌گذاری شده‌اند و نه برای راه‌حل‌های سمت سرور مجوز دارند. بنابراین، هیچ راه‌حل مجوزی مناسبی برای استقرار برنامه‌های وبی که از اجزای Microsoft Office استفاده می‌کنند وجود ندارد. از طرف دیگر، Aspose یک راه‌حل بسیار [ارزش‌صرفه](https://purchase.aspose.com/) برای برنامه‌های مبتنی بر سرور نیز فراهم می‌کند.

## **ویژگی‌ها**
اجزای Aspose همه چیز مورد نیاز برای مدیریت فایل‌های Office و حتی بیشتر را فراهم می‌کنند. ما آنها را بر پایه فلسفه کمک به توسعه‌دهندگان برای دستیابی به بهترین نتایج با کمترین هزینه زمان طراحی کرده‌ایم.

{{% alert color="info" %}} 
بر خلاف خودکارسازی Office، اجزای Aspose بسیاری از توابع قدرتمند و صرفه‌جویی‌کننده زمان را ارائه می‌دهند.
{{% /alert %}} 

به عنوان مثال، Aspose.Cells به توسعه‌دهندگان امکان وارد کردن داده‌ها از یک **DataTable** یا **DataView** را به‌طور مستقیم به یک فایل Excel می‌دهد. Aspose.Words ویژگی مشابهی دارد که به توسعه‌دهندگان امکان پر کردن یک سند Word (یعنی ادغام نامه) را به‌صورت مستقیم از هر شیء داده‌ای .NET می‌دهد. هر [جزء](https://products.aspose.com/total/net/) در خانواده Aspose مجموعه خاص و قدرتمند خود را دارد.

بهترین بخش خرید یک جزء Aspose دسترسی به تیم‌های توسعه ما است. برای مثال، اگر از اشیاء خودکارسازی Office استفاده کنید و به ویژگی‌های خاصی نیاز داشته باشید، احتمال افزودن آن ویژگی‌ها بسیار، بسیار کم است. اما با اجزای Aspose وضعیت متفاوت است.

{{% alert color="info" %}} 
تیم‌های توسعه ما درک می‌کنند که اگر ویژگی‌ای وجود داشته باشد که شرکت شما به آن نیاز دارد، احتمالاً شرکت‌های دیگر نیز به همان ویژگی نیاز دارند. اگرچه می‌دانیم نمی‌توانیم همه ویژگی‌های درخواست‌شده را پیاده‌سازی کنیم، اما سعی می‌کنیم تا جایی که ممکن است بر پایه بازخورد مشتریان، ویژگی‌های بیشتری اضافه کنیم.
{{% /alert %}} 

تیم‌های ما همیشه با ذهن باز و انعطاف‌پذیر هستند و این دلیل آن است که اجزای Aspose تا به امروز این‌قدر قدرتمند شده‌اند.

## **نتیجه‌گیری**
{{% alert color="info" %}} 
اگرچه این مقاله برخی از نکات کلیدی که چرا اجزای Aspose انتخاب بهتری نسبت به خودکارسازی Office هستند را پوشش داد، باید درک کنید که مزایای بسیار، بسیار بیشتری وجود دارد. ما فقط به برخی از مزایای اصلی اشاره کردیم.

علاوه بر این، تمام محصولات و اجزای Aspose یک نسخه ارزیابی رایگان و بدون تعهد [Evaluation Version](https://downloads.aspose.com/slides/fa/net) ارائه می‌دهند. ما شما را تشویق می‌کنیم تا از این نسخه ارزیابی استفاده کنید و ببینید Aspose چه کاری می‌تواند برای برنامه‌ها یا کسب‌وکار شما انجام دهد.
{{% /alert %}}