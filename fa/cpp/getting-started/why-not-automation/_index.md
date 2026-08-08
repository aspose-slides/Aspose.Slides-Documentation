---
title: چرا خودکارسازی؟
type: docs
weight: 50
url: /fa/cpp/why-not-automation/
keywords:
- خودکارسازی
- مایکروسافت آفیس
- مقایسه
- امنیت
- پایداری
- قابلیت مقیاس‌پذیری
- ویژگی‌ها
- پاورپوینت
- OpenDocument
- ارائه
- C++
- Aspose.Slides
description: "کشف کنید چرا خودکارسازی Office برای سرورها و سرویس‌ها خطرناک است و ببینید چگونه Aspose.Slides پردازش ارائه‌ها را برای PowerPoint و OpenDocument به‌صورت ایمن‌تر و سریع‌تر ارائه می‌دهد."
---
## **مقدمه**

چندین دلیل وجود دارد که اجزای Aspose گزینه بهتری نسبت به خودکارسازی هستند. برخی از دلایل کلیدی عبارتند از:

- امنیت
- پایداری
- مقیاس‌پذیری/سرعت
- قیمت
- ویژگی‌ها

در زیر توضیحی دقیق‌تر از هر نکته کلیدی آمده است.

## **سوالات مهم**
- چرا اجزای Aspose گزینه بسیار بهتری نسبت به خودکارسازی Microsoft Office هستند؟

دو سؤال وجود دارد که ما در Aspose بیشترین بار می‌شنویم :

- آیا محصولات شما برای اجرا نیاز به نصب Microsoft Office دارند؟

پاسخ کوتاه و ساده **NO** است. Aspose و اجزای Aspose کاملاً مستقل هستند و هیچ‌گونه ارتباط، مجوز، حمایت یا تأیید از سوی شرکت Microsoft ندارند.

- چرا باید به جای استفاده از خودکارسازی Microsoft Office، از محصولات Aspose استفاده کنیم؟

کوتاه‌ترین پاسخی که می‌توانیم بدهیم این است که دلایل زیادی وجود دارد که مهم‌ترین آن این است که *Microsoft خودش به شدت توصیه می‌کند که از خودکارسازی Office در راه‌حل‌های نرم‌افزاری خودداری شود: [مقاله Microsoft*

## **امنیت**
در ادامه نقل قول مستقیمی از مقالهٔ Microsoft که در بالا اشاره شد، آمده است:

*"Office Applications were never intended for use server-side, and therefore do not take into consideration the security problems that are faced by distributed components. Office does not authenticate incoming requests, and does not protect you from unintentionally running macros, or starting another server that might run macros, from your server-side code. Do not open files that are uploaded to the server from an anonymous Web! Based on the security settings that were last set, the server can run macros under an Administrator or System context with full privileges and compromise your network! In addition, Office uses many client-side components (such as Simple MAPI, WinInet, MSDAIPP) that can cache client authentication information in order to speed up processing. If Office is being automated server-side, one instance may service more than one client, and because authentication information has been cached for that session, it is possible that one client can use the cached credentials of another client, and thereby gain non-granted access permissions by impersonating other users."*

محصولات Aspose بسیار امن هستند. بنابراین، اجزای Aspose خطر بالقوه‌ای برای منابع حیاتی سیستم ایجاد نمی‌کنند. علاوه بر این، هنگامی که یک سند توسط یک جزء Aspose باز می‌شود، ماکروها به‌صورت خودکار اجرا نمی‌شوند. اجزای Aspose با هدف امکان‌دادن به توسعه‌دهندگان برای ایجاد، دستکاری و ذخیرهٔ فایل‌های Office ساخته شده‌اند. هیچ‌یک از خطرات مرتبط با بستهٔ Microsoft Office به صورت ذاتی در اجزای Aspose وجود ندارد.

## **پایداری**
در ادامه نقل قول مستقیمی از مقالهٔ Microsoft که در بالا اشاره شد، آمده است:

*"Office 2000, Office XP and Office 2003 use Microsoft Windows Installer (MSI) technology to make installation and self-repair easier for an end user. MSI introduces the concept of "install on first use", which allows features to be dynamically installed or configured at runtime (for the system, or more often for a particular user). In a server-side environment this both slows down performance and increases the likelihood that a dialog box may appear that asks for the user to approve the install or provide an appropriate install disk. Although it is designed to increase the resiliency of Office as an end-user product, Office's implementation of MSI capabilities is counterproductive in a server-side environment. Furthermore, the stability of Office in general cannot be assured when run server-side because it has not been designed or tested for this type of use. Using Office as a service component on a network server may reduce the stability of that machine and as a consequence your network as a whole. If you plan to automate Office server-side, attempt to isolate the program to a dedicated computer that cannot affect critical functions, and that can be restarted as needed."*

از آنجا که اجزای Aspose در یک DLL واحد بسته‌بندی می‌شوند، هیچ‌گاه نیازی به نصب قطعات یا بخش‌های اضافی برای عملکرد آنها نخواهد بود. اجزای Aspose فقط توسط برنامه‌های C++ مورد استفاده قرار می‌گیرند و هیچ بخشی از کد این اجزا برای انتظار بر پاسخ انسانی طراحی نشده است. اجزای Aspose به‌طور کامل تست شده‌اند و بسیار پایدار هستند. اجزای Aspose توسط [شرکت‌ها](https://about.aspose.com/customers) مانند **IBM**, **Hilton**, **Reader's Digest**, **Bank of America** و بسیاری دیگر استفاده می‌شود.

## **مقیاس‌پذیری/سرعت**
در ادامه نقل قول مستقیمی از مقالهٔ Microsoft که در بالا اشاره شد، آمده است:

*"Server-side components need to be highly reentrant, multi-threaded COM components with minimum overhead and high throughput for multiple clients. Office Applications are in almost all respects the exact opposite. They are non-reentrant, STA-based Automation servers that are designed to provide diverse but resource-intensive functionality for a single client. They offer little scalability as a server-side solution, and have fixed limits to important elements, such as memory, which cannot be changed through configuration. More importantly, they use global resources (such as memory mapped files, global add-ins or templates, and shared Automation servers), which can limit the number of instances that can run concurrently and lead to race conditions if they are configured in a multi-client environment. Developers who plan to run more then one instance of any Office Application at the same time need to consider Pooling or Serializing Access to the Office Application for avoiding potential Deadlocks or Data Corruption”.*"

اجزای Aspose به‌طور گسترده مقیاس‌پذیر و فوق‌العاده سریع هستند. برنامه‌های Office برای استفاده همزمان توسط صدها و هزاران کاربر طراحی نشده‌اند، اما اجزای Aspose دقیقاً برای همین منظور ساخته شده‌اند. اجزای ما یک راه‌حل واقعی C++ هستند و چه بر روی یک سرور واحد، چه در یک برنامهٔ تک‌کاربردی یا چه در یک فرم وب متعادل‌شده برای یک برنامه سازمانی به‌رویکردی بدون نقص ارائه می‌دهند.

## **قیمت**
هنگامی که یک برنامه از خودکارسازی Microsoft Office استفاده می‌کند، برای هر ماشینی که برنامه را اجرا می‌کند باید یک نسخهٔ Microsoft Office خریداری شود. موارد بسیاری وجود دارد که برنامه‌ای نیاز به ایجاد یا دستکاری فایل‌های Office دارد اما نیازی به داشتن Microsoft Office برای کاربر نیست. Aspose یک مجوز [Cost Effective](https://purchase.aspose.com/) و بدون حق امتیاز ارائه می‌دهد که امکان استقرار به‌صورت نامحدود برای تعداد کاربران بدون نگرانی‌های лицензионные را فراهم می‌کند. هنگام ایجاد برنامه‌های وب مهم است بدانید که اجزای خودکارسازی Microsoft Office برای راه‌حل‌های سمت سرور قیمت‌گذاری یا مجوزی ندارند؛ بنابراین، راه‌حل مجاز و مناسبی برای استقرار برنامه‌های وبی که از این اجزا استفاده می‌کنند وجود ندارد. Aspose یک راه‌حل [Cost Effective](https://purchase.aspose.com/) برای برنامه‌های سمت سرور نیز ارائه می‌دهد.

## **ویژگی‌ها**
اجزای Aspose همهٔ آنچه برای مدیریت فایل‌های Office لازم است را به‌همراه امکانات بیشتر فراهم می‌کنند. آنها با فلسفهٔ این طراحی شده‌اند که توسعه‌دهندگان بتوانند بیشترین نتیجه را با کمترین تلاش به‌دست آورند. برخلاف خودکارسازی Office، اجزای Aspose توابع قدرتمند و زمان‌ذرباری ارائه می‌دهند. به‌عنوان مثال، [Aspose.Cells](https://products.aspose.com/cells/cpp/) به توسعه‌دهندگان امکان وارد کردن داده‌ها از یک **DataTable** یا **DataView** مستقیماً به یک فایل Excel را می‌دهد. [Aspose.Words](https://products.aspose.com/words/net/) یک ویژگی مشابه ارائه می‌کند که به توسعه‌دهندگان اجازه می‌دهد یک سند Word (یعنی Mail Merge) را مستقیماً از هر شیء دادهٔ C++ پر کنند. [Every Component](https://products.aspose.com/total/cpp/) در خانوادهٔ Aspose مجموعهٔ منحصر به فرد و قدرتمند خود را دارد. بهترین بخش خرید یک جز Aspose دسترسی به تیم‌های توسعهٔ ماست. تیم‌های ما درک می‌کنند که اگر ویژگی‌ای مورد نیاز شرکت شما باشد، احتمال دارد شرکت‌های دیگر نیز به آن نیاز داشته باشند. اگرچه نمی‌توان هر درخواست ویژگی را افزود، تیم‌های ما سعی می‌کنند بسیار انعطاف‌پذیر و باز ذهن باشند. این رویکرد باعث شده است که اجزای Aspose به‌قدری قدرتمند شوند که هستند. اگر ویژگی‌های بیشتری از اشیاء خودکارسازی Office نیاز داشته باشید، احتمال افزودن آن‌ها بسیار بسیار کم است.

## **نتیجه‌گیری**
{{% alert color="primary" %}} 

در حالی که این مقاله بسیاری از نکات کلیدی که چرا اجزای Aspose گزینهٔ بهتری نسبت به خودکارسازی Office هستند را پوشش داد، نکات بسیار بیشتری نیز وجود دارد. این مقاله عمدتاً به مهم‌ترین نکات پرداخته است. همهٔ اجزای مختلف Aspose نسخهٔ ارزیابی رایگان و بدون تعهد [Evaluation Version](https://downloads.aspose.com/slides/fa/cpp) ارائه می‌دهند. ما شما را تشویق می‌کنیم تا از آن [Evaluation](https://downloads.aspose.com/slides/fa/cpp) استفاده کنید تا بهتر ببینید Aspose چه کاری می‌تواند برای برنامه‌های شما انجام دهد.
{{% /alert %}}