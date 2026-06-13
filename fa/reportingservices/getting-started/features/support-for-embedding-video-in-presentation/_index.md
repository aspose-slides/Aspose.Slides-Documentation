---
title: پشتیبانی از جاسازی ویدئو در ارائه
type: docs
weight: 80
url: /fa/reportingservices/support-for-embedding-video-in-presentation/
---
{{% alert color="primary" %}} 

Microsoft SQL Server Reporting Services توانایی‌های داخلی برای خروجی‌گیری گزارش‌ها با ویدئوی توکار به ارائه‌های PowerPoint ندارد. Aspose.Slides for Reporting Services نسخه‌های 4.10 به بعد امکان جاسازی ویدئو در داخل ارائه را پشتیبانی می‌کنند. 

{{% /alert %}} 

برای جاسازی ویدئو در اسلایدها، لطفاً یک جعبه متن با متن زیر را به گزارش اضافه کنید: 

``` xml

 <asposeObject type="video" url="file://c:\MyVideos\intro.wmv" playMode="Auto" vlume="Loud" cover="file://c:\MyVideos\introCover.jpg"/>

```


این قابلیت برای نسخه 2008 و بالاتر SQL Server کار می‌کند. این ویژگی فقط برای خروجی PPTX پشتیبانی می‌شود.