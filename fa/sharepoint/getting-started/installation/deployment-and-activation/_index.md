---
title: استقرار و فعال‌سازی
type: docs
weight: 20
url: /fa/sharepoint/deployment-and-activation/
description: "اینکه راه‌حل Aspose.Slides برای SharePoint هنگام استقرار چه چیزی را بر روی فارم نصب می‌کند و ویژگی مجموعه‌سایت آن هنگام فعال‌سازی چه مواردی اضافه می‌کند."
---
## **استقرار**

در طول استقرار، راه‌حل Aspose.Slides برای SharePoint:

- نسخه اسمبلی آن را در حافظه کش کلی (Global Assembly Cache) نصب می‌کند و ورودی‌های SafeControl را به فایل **web.config** اضافه می‌نماید. در SharePoint 2010 و نسخه‌های بعدی، این فایل *Aspose.Slides.SharePoint2010.dll*، *Aspose.Slides.SharePoint2013.dll* یا *Aspose.Slides.SharePoint2016.dll* است (بسته SharePoint 2019 نیز *Aspose.Slides.SharePoint2016.dll* را نصب می‌کند). در SharePoint 2007، آن *Aspose.Slides.SharePointUI.dll* به‌همراه *Aspose.Slides.SharePoint.Deployment.dll* است.
- صفحه تبدیل و تصاویر و سایر فایل‌های پشتیبانی را به پوشه‌های نصب SharePoint کپی می‌کند.
- ویژگی (feature) را نصب کرده و آن را برای فعال‌سازی در مجموعه‌های سایت در دسترس می‌سازد.

## **فعال‌سازی**

Aspose.Slides برای SharePoint به‌صورت یک ویژگی (feature) مجموعه‌سایت بسته‌بندی شده و می‌تواند در مجموعه‌های سایت فعال یا غیرفعال شود. هنگام فعال‌سازی در یک مجموعه‌سایت، این ویژگی موارد زیر را اضافه می‌کند:

- در SharePoint 2010 و نسخه‌های بعدی:
  - مورد **Convert via Aspose.Slides** را به منوی اسناد در کتابخانه‌های سند اضافه می‌کند؛
  - تب نوار **Aspose Tools** همراه با دکمه **Convert Slides** را اضافه می‌کند که اسناد انتخاب‌شده را تبدیل می‌نماید؛
  - مورد **View Slides** را به منوی فایل‌های PPT، PPTX، PPS و PPSX اضافه می‌کند.
- در SharePoint 2007:
  - مورد **Convert with Aspose.Slides** را به منوی اسناد در کتابخانه‌های سند اضافه می‌کند؛
  - مورد **Convert All with Aspose.Slides** را به منوی **Actions** کتابخانه‌های سند اضافه می‌کند.

در SharePoint 2007، فعال‌سازی همچنین تغییراتی در دایرکتوری مجازی برنامه وب والد مجموعه‌سایت ایجاد می‌کند. این کار:
- صفحه تنظیمات تبدیل را به فایل نقشه سایت (sitemap) اضافه می‌کند.
- فایل‌های منبع لازم را به پوشه App_GlobalResources در دایرکتوری مجازی کپی می‌کند.

برنامه نصب ویژگی را در مجموعه‌های سایتی که در حین [نصب](/slides/fa/sharepoint/installing-aspose-slides-for-sharepoint/) انتخاب می‌کنید، فعال می‌سازد.