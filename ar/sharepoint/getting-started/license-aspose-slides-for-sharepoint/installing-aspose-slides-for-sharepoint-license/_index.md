---
title: تثبيت ترخيص Aspose.Slides لـ SharePoint
type: docs
weight: 10
url: /ar/sharepoint/installing-aspose-slides-for-sharepoint-license/
description: "ثبت ترخيص Aspose.Slides لـ SharePoint على مجموعة خوادم SharePoint: أضف حل الترخيص إلى مخزن الحلول، وانشره، وتحقق من أن الملفات المحوّلة لم تعد تحمل علامة مائية للتقييم."
---
{{% alert color="info" title="ملاحظة" %}}

بمجرد رضاك عن تقييمك، يمكنك [شراء ترخيص](https://purchase.aspose.com/pricing/slides/sharepoint/). قبل الشراء، تأكد من فهمك وموافقتك على شروط اشتراك الترخيص. يتم إرسال الترخيص إليك عبر البريد الإلكتروني عندما يتم دفع الطلب.

الترخيص هو ملف أرشيف ZIP يحتوي على حزمة حل SharePoint عادية. يحتوي الأرشيف على:

- Aspose.Slides.SharePoint.License.wsp – ملف حزمة حل SharePoint. تم حزم الترخيص كحل SharePoint لتسهيل النشر والسحب عبر مجموعة الخوادم.
- readme.txt – تعليمات تثبيت الترخيص.

{{% /alert %}}

## **نشر الترخيص**

يتم تثبيت الترخيص من وحدة تحكم الخادم عبر **stsadm.exe**.

{{% alert color="info" title="ملاحظة" %}}

تم حذف المسارات في القسم التالي لتوضيح الأمر.

{{% /alert %}}

اتبع الخطوات التالية لنشر ترخيص Aspose.Slides لـ SharePoint:

1. تشغيل stsadm لإضافة الحل إلى مخزن حلول SharePoint:

   ```bat
   Stsadm.exe -o addsolution -filename Aspose.Slides.SharePoint.License.wsp
```

2. نشر الحل إلى جميع الخوادم في المجموعة:

   ```bat
   Stsadm.exe -o deploysolution -name Aspose.Slides.SharePoint.License.wsp -immediate -force
   ```

3. تنفيذ وظائف المؤقت الإدارية لإكمال النشر فورًا:

   ```bat
   Stsadm.exe -o execadmsvcjobs
   ```

تستقبل العملية `addsolution` مسار ملف الحل في `-filename`؛ وتستقبل العملية `deploysolution` اسم الحل الموجود بالفعل في مخزن الحلول في `-name`.

{{% alert color="info" title="ملاحظة" %}}

ستظهر لك تحذير عند تشغيل خطوة النشر إذا لم تكن خدمة إدارة SharePoint قيد التشغيل. يعتمد **stsadm.exe** على هذه الخدمة وخدمة مؤقت SharePoint لتكرار بيانات الحل عبر المجموعة. إذا لم تكن هذه الخدمات قيد التشغيل في مجموعة الخوادم الخاصة بك، قد تحتاج إلى نشر الترخيص على كل خادم.

{{% /alert %}}

{{% alert color="info" title="ملاحظة" %}}

في SharePoint 2010 وما بعده، تتطابق أوامر PowerShell لإدارة SharePoint `Add-SPSolution` و `Install-SPSolution` و `Start-SPAdminJob` مع عمليات `addsolution` و `deploysolution` و `execadmsvcjobs`. راجع [Stsadm to Microsoft PowerShell mapping in SharePoint Server](https://learn.microsoft.com/en-us/sharepoint/technical-reference/stsadm-to-microsoft-powershell-mapping).

{{% /alert %}}

## **اختبار الترخيص**

لاختبار أن الترخيص تم تثبيته بشكل صحيح، قم بتحويل أي عرض تقديمي إلى تنسيق جديد. إذا لم يظهر علامة مائية للتقييم في الملف المحول، فإن الترخيص فعال.