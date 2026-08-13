---
title: راه‌اندازی دموها
type: docs
weight: 70
url: /fa/jasperreports/demos-setup/
---
تمام دموهای ارائه شده با Aspose.Slides برای JasperReports، دموهای استاندارد تغییر یافته‌اند. بهتر است تمام دموها را به پوشه دموهای JasperReports کپی کنید:
...\jasperreports-x.x.x\demo\samples\

از توالی دستورات استاندارد برای ساخت و استخراج گزارش‌ها استفاده کنید:

- ant javac
- ant compile
- ant fill
- ant ppt

{{% alert color="info" %}} 

لطفاً فراموش نکنید که HSQLDB را همراه با پایگاه داده آزمون اجرا کنید تا گزارش‌ها با داده پر شوند و فایل aspose.slides.jasperreports.library-xx.x.jar را از پوشه \lib\JasperReports X.X.X - X.X.X در بسته aspose-slides-xx.x-jasperreports.zip به مسیر &#60;InstallDir&#62;\lib کپی کنید.

{{% /alert %}} 

اکثر دموها (به‌جز Charts) پیش از این ارائه‌ها را تولید کرده‌اند، بنابراین می‌توانید تمام مراحل “ant” را رد کنید و بلافاصله نتایج را بررسی کنید.