---
title: پیش‌نیازهای نصب
type: docs
weight: 20
url: /fa/reportingservices/installation-prerequisites/
---
{{% alert color="primary" %}} 
قبل از ادامه نصب، پیش‌نیازهای زیر باید برآورده شوند. 
{{% /alert %}} 
## **Reporting Services Add-In for SharePoint**
**Reporting Services Add-In for SharePoint** یکی از اجزای کلیدی برای عملکرد صحیح یکپارچه‌سازی است. این افزونه باید بر روی هر یک از **Web Front Ends (WFE)** موجود در فارم SharePoint شما و به همراه سرور Central Admin نصب شود. یکی از تغییرات جدید در SQL 2008 R2 و SharePoint 2010 این است که افزونه 2008 R2 اکنون پیش‌نیاز نصب SharePoint است. این بدان معناست که هنگام نصب SharePoint، افزونه RS به‌صورت خودکار نصب می‌شود. این مورد در شکل زیر نشان داده و برجسته شده است. این در واقع بسیاری از مشکلاتی را که در نصب Add‑In برای SP 2007 و RS 2008 مشاهده می‌کردیم، رفع می‌کند. 

![todo:image_alt_text](installation-prerequisites_1.png)

**شکل 1**: Reporting Services Add‑In for SharePoint 
## **SharePoint Authentication**
قبل از ورود به بخش‌های یکپارچه‌سازی RS، یک نکته مهم که باید به آن توجه شود این است که سایت (**Site**) خود را در فارم SharePoint چگونه تنظیم می‌کنید. به‌طور خاص، نحوه پیکربندی احراز هویت برای سایت؛ آیا **Classic** خواهد بود یا **Claims**. این انتخاب در ابتدا اهمیت دارد. من معتقدم پس از انجام این تنظیم، نمی‌توانید به‌سادگی آن را تغییر دهید. اگر بتوانید تغییر دهید، فرآیند ساده‌ای نخواهد بود. 

{{% alert color="primary" %}} 

Reporting Services 2008 R2 از Claims پشتیبانی نمی‌کند 
{{% /alert %}} 

حتی اگر سایت SharePoint خود را برای استفاده از **Claims** تنظیم کنید، خود Reporting Services از Claims آگاه نیست. این امر بر نحوه کارکرد احراز هویت با Reporting Services تأثیر می‌گذارد. پس تفاوت از دید Reporting Services چیست؟ این به این بستگی دارد که آیا می‌خواهید اعتبارنامه‌های کاربر را به منبع داده انتقال دهید یا نه. 

***Classic*** ‑ می‌توان از Kerberos استفاده کرد و اعتبارنامه‌های کاربر را به منبع داده پشت‌صحنه انتقال داد (برای این کار باید از Kerberos استفاده کنید). 

***Claims*** ‑ یک توکن Claims استفاده می‌شود نه توکن ویندوز. RS در این سناریو همیشه از Trusted Authentication استفاده می‌کند و فقط به توکن SPUser دسترسی دارد. باید اعتبارنامه‌های خود را در منبع داده ذخیره کنید. 

در حال حاضر، می‌خواهیم فقط به تنظیم RS بپردازیم. در این مرحله SharePoint بر روی SharePoint Box نصب شده و با یک **Classic Auth Site** بر روی **port 80** پیکربندی شده است. علاوه بر این، بر روی سرور RS فقط **Reporting Services** نصب شده و دیگر کاری انجام نشده است.