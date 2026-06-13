---
title: نصب SharePoint بر روی سرور RS
type: docs
weight: 40
url: /fa/reportingservices/setting-up-sharepoint-on-the-rs-server/
---
{{% alert color="primary" %}} 

پس، همان کاری که برای SharePoint WFE انجام دادیم را انجام می‌دهیم. اولین گام مرور پیش‌نیازهای نصب و سپس راه‌اندازی نصب SharePoint است.  

برای نصب، گزینه Server Farm و یک نصب کامل را انتخاب می‌کنیم تا با SharePoint Box من مطابقت داشته باشد، زیرا نمی‌خواهیم نصب standalone برای SharePoint داشته باشیم.  

{{% /alert %}} 
### **پیکربندی SharePoint**
در ویزارد پیکربندی SharePoint، می‌خواهیم به یک فارم موجود متصل شویم. 

![todo:image_alt_text](setting-up-sharepoint-on-the-rs-server_1.png)

**شکل 13**: راهنمای پیکربندی SharePoint 

سپس آن را به پایگاه داده **SharePoint_Config** که فارم ما از آن استفاده می‌کند، اشاره می‌کنیم. اگر نمی‌دانید این پایگاه کجا قرار دارد، می‌توانید از طریق Central Admin در **System Settings -> Manage Servers in this farm** پیدا کنید. 

![todo:image_alt_text](setting-up-sharepoint-on-the-rs-server_2.png)

**شکل 14**: راهنمای پیکربندی SharePoint 

![todo:image_alt_text](setting-up-sharepoint-on-the-rs-server_3.png)

**شکل 15**: راهنمای پیکربندی SharePoint 

پس از اتمام ویزارد، در حال حاضر تمام کاری که باید در سرور Report Server انجام دهیم، به پایان رسیده است. وقتی به URL ReportServer برمی‌گردیم، خطای دیگری می‌بینیم، اما این به دلیل این است که هنوز آن را از طریق Central Administrator پیکربندی نکرده‌ایم. 

![todo:image_alt_text](setting-up-sharepoint-on-the-rs-server_4.png)

**شکل 16**: خطای سرور گزارش