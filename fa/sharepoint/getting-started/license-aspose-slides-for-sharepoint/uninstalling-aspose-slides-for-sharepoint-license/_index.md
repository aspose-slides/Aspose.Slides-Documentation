---
title: حذف لایسنس Aspose.Slides برای SharePoint
type: docs
weight: 20
url: /fa/sharepoint/uninstalling-aspose-slides-for-sharepoint-license/
---
برای حذف لایسنس، لطفاً مراحل زیر را از کنسول سرور استفاده کنید. 

1. راه‌حل لایسنس را از فارم پس بگیرید: 

``` xml

 stsadm.exe -o retractsolution -name Aspose.Slides.SharePoint.License.wsp -immediate

```

2. کارهای زمان‌ساز مدیریتی را برای تکمیل بازپس‌گیری بلافاصله اجرا کنید: 

``` xml

 stsadm.exe -o execadmsvcjobs

```

3. صبر کنید تا بازپس‌گیری تکمیل شود. می‌توانید از Central Administration استفاده کنید تا بررسی کنید آیا بازپس‌گیری تحت **Central Administration**، سپس **Operations** و **Solution Management** تکمیل شده است.
4. راه‌حل را از فروشگاه راه‌حل‌های SharePoint حذف کنید: 

``` xml

 stsadm.exe -o deletesolution -name Aspose.Slides.SharePoint.License.wsp

```