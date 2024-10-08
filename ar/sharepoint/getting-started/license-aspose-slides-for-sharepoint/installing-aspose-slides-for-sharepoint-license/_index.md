---
title: تثبيت ترخيص Aspose.Slides لـ SharePoint
type: docs
weight: 10
url: /ar/sharepoint/installing-aspose-slides-for-sharepoint-license/
---

{{% alert color="primary" %}} 

بمجرد أن تكون راضيًا عن تقييمك، يمكنك [شراء ترخيص](https://purchase.aspose.com/buy). قبل الشراء، تأكد من أنك تفهم وتوافق على شروط اشتراك الترخيص. سيتم إرسال الترخيص إليك عبر البريد الإلكتروني عند سداد الطلب.

التراخيص عبارة عن أرشيف ZIP يحتوي على حزمة حل SharePoint العادية. يحتوي الأرشيف على:

- Aspose.Slides.SharePoint.License.wsp – ملف حزمة حل SharePoint. تم تعبئة التراخيص كحزمة حل SharePoint لتسهيل النشر والسحب عبر مزرعة الخادم.
- readme.txt – تعليمات تثبيت الترخيص.

{{% /alert %}} 
## **نشر الترخيص**
يتم تثبيت الترخيص من وحدة تحكم الخادم عبر **stsadm.exe**.

{{% alert color="primary" %}} 

تم حذف المسارات في القسم التالي لأغراض التوضيح.

{{% /alert %}} 

نفذ الخطوات التالية لنشر ترخيص Aspose.Slides لـ SharePoint:

1. قم بتشغيل stsadm لإضافة الحل إلى متجر حلول SharePoint: 

``` xml

 Stsadm.exe -o deploysolution -name Aspose.Slides.SharePoint.License.wsp

```

2. نشر الحل إلى جميع الخوادم في المزرعة: 

``` xml

 Stsadm.exe -o deploysolution -name Aspose.Slides.SharePoint.License.wsp -immediate -force

```

3. قم بتنفيذ مهام المؤقت الإدارية لإتمام النشر على الفور: 

``` xml

 Stsadm.exe -o execadmsvcjobs

```

{{% alert color="primary" %}} 

ستحصل على تحذير عند تشغيل خطوة النشر إذا لم يكن خدمة إدارة Windows SharePoint Services قيد التشغيل. يعتمد **stsadm.exe** على هذه الخدمة وخدمة مؤقت Windows SharePoint لنسخ بيانات الحل عبر المزرعة. إذا لم تكن هذه الخدمات قيد التشغيل على مزرعة خوادمك، قد تحتاج إلى نشر الترخيص على كل خادم.

{{% /alert %}} 
## **اختبار الترخيص**
لاختبار ما إذا تم تثبيت الترخيص بشكل صحيح، قم بتحويل أي مستند إلى تنسيق جديد. إذا لم يكن هناك علامة مائية للتقييم في المستند، فإن الترخيص قد تم تفعيله بنجاح.