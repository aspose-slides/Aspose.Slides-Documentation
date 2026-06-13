---
title: پشتیبانی از جاسازی صدا در ارائه
type: docs
weight: 90
url: /fa/reportingservices/support-for-embedding-audio-in-presentation/
---
{{% alert color="primary" %}} 
Microsoft SQL Server Reporting Services توانایی‌های داخلی برای صادر کردن گزارش‌ها با صداهای جاسازی‌شده به ارائه‌های PowerPoint ندارد. Aspose.Slides برای Reporting Services نسخه 4.10 به بعد از جاسازی صدا در ارائه صادرشده پشتیبانی می‌کند. 
{{% /alert %}} 
برای جاسازی صدا در اسلایدها، لطفاً یک جعبه متن با متن زیر به گزارش اضافه کنید: 
``` xml

 <asposeObject type="audio" url="file://c:\MyVideos\intro.wav" playMode="Auto" volume="Loud" cover="file://c:\MyVideos\introCover.jpg"/>

```
این برای نسخه 2008 و بالاتر SQL Server کار می‌کند. این ویژگی فقط برای صادر کردن به فرمت PPTX پشتیبانی می‌شود.