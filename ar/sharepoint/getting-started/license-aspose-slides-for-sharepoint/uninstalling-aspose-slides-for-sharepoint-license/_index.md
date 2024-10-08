---
title: إلغاء تثبيت ترخيص Aspose.Slides لـ SharePoint
type: docs
weight: 20
url: /ar/sharepoint/uninstalling-aspose-slides-for-sharepoint-license/
---

لإلغاء تثبيت الترخيص، يرجى استخدام الخطوات التالية من وحدة التحكم الخاصة بالخادم.

1. سحب حل الترخيص من المزرعة:

``` xml

 stsadm.exe -o retractsolution -name Aspose.Slides.SharePoint.License.wsp -immediate

```

2. تنفيذ وظائف المؤقت الإدارية لإكمال السحب على الفور:

``` xml

 stsadm.exe -o execadmsvcjobs

```

3. انتظر حتى يكتمل السحب. يمكنك استخدام الإدارة المركزية للتحقق مما إذا كان السحب قد اكتمل تحت **الإدارة المركزية**، ثم **العمليات** و**إدارة الحلول**.
4. إزالة الحل من متجر حلول SharePoint:

``` xml

 stsadm.exe -o deletesolution -name Aspose.Slides.SharePoint.License.wsp

```