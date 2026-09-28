---
title: تثبيت Aspose.Slides for SharePoint
type: docs
weight: 10
url: /ar/sharepoint/installing-aspose-slides-for-sharepoint/
description: "تثبيت Aspose.Slides for SharePoint على مجموعة SharePoint: اختر برنامج الإعداد لإصدار SharePoint الخاص بك، نفّذ فحص النظام، وانشر الحل وفَعِّلُه."
---
## **محتويات الحزمة**

Aspose.Slides for SharePoint يتم تنزيله من [صفحة التنزيل](https://releases.aspose.com/slides/sharepoint/) كملف ZIP. يحتوي الأرشيف على حزمة حل SharePoint (WSP) واحدة وبرنامج إعداد واحد لكل إصدار من إصدارات SharePoint المدعومة:

| إصدار SharePoint | برنامج الإعداد | حزمة الحل |
| :- | :- | :- |
| SharePoint 2007 | Setup2007.exe | Aspose.Slides.SharePoint2007.wsp |
| SharePoint 2010 | Setup2010.exe | Aspose.Slides.SharePoint2010.wsp |
| SharePoint Server 2013 | Setup2013.exe | Aspose.Slides.SharePoint2013.wsp |
| SharePoint Server 2016 | Setup2016.exe | Aspose.Slides.SharePoint2016.wsp |
| SharePoint Server 2019 | Setup2019.exe | Aspose.Slides.SharePoint2019.wsp |

لكل برنامج إعداد ملف تكوين بجواره (مثال، *Setup2019.exe.config*) يحدد اسم حزمة الحل التي يتم تثبيتها. يحتوي مجلد *License* على ارتباط باتفاقية ترخيص المستخدم النهائي وإشعارات تراخيص الجهات الخارجية.

Aspose.Slides for SharePoint يتم حزمته كحل SharePoint، تقوم SharePoint بنشره عبر مجموعة الخوادم. ثم يتم تفعيل أو إلغاء تفعيل ميزته لكل مجموعة مواقع.

## **عملية التثبيت**

قبل التثبيت، يقوم برنامج الإعداد بتنفيذ فحص نظام. يتحقق مما يلي:

- تم تثبيت SharePoint على الخادم.
- للمستخدم الحالي صلاحية تثبيت ونشر حلول SharePoint.
- تم تشغيل خدمة إدارة SharePoint.
- تم تشغيل خدمة مؤقت SharePoint.
- حزمة الحل المذكورة في ملف التكوين موجودة.

تحتاج إلى خدمات الإدارة والمؤقت لأن بعض إجراءات الإعداد تُنفّذ كمهام مؤقت تُرسل الحل إلى جميع الخوادم في المجموعة.

### **تشغيل التثبيت**

لتثبيت Aspose.Slides for SharePoint:

1. قم بفك ضغط ملف ZIP إلى قرص محلي على خادم في مجموعة SharePoint.
2. شغّل برنامج الإعداد الذي يتطابق مع إصدار SharePoint الخاص بك (انظر الجدول أعلاه) واتبع التعليمات على الشاشة. يقوم برنامج الإعداد:
   1. ينفّذ فحص النظام. لا يتابع الإعداد إذا فشل أي فحص.

      **تنفيذ فحص النظام**

      ![شاشة فحص النظام لبرنامج الإعداد](installing-aspose-slides-for-sharepoint_1.png)

   2. يعرض اتفاقية ترخيص المستخدم النهائي. يجب عليك قبولها للمتابعة.

      **اتفاقية الترخيص**

      ![شاشة اتفاقية الترخيص لبرنامج الإعداد](installing-aspose-slides-for-sharepoint_2.png)

   3. يعرض أهداف النشر. حدّد تطبيقات الويب ومجموعات المواقع لتفعيل الميزة لها.

      **اختيار أهداف النشر**

      ![شاشة أهداف نشر مجموعة المواقع لبرنامج الإعداد](installing-aspose-slides-for-sharepoint_3.png)

   4. ينشر الحل إلى المجموعة.

      **تقدم التثبيت**

      ![شاشة تقدم التثبيت لبرنامج الإعداد](installing-aspose-slides-for-sharepoint_4.png)

   5. يفعّل Aspose.Slides for SharePoint على مجموعات المواقع المحددة.
   6. يعرض تطبيقات الويب ومجموعات المواقع التي تم نشر الحل وتفعيله فيها.

      **التثبيت الناجح**

      ![شاشة اكتمال التثبيت لبرنامج الإعداد](installing-aspose-slides-for-sharepoint_5.png)

{{% alert color="info" title="Note" %}}
تم أخذ لقطات الشاشة على SharePoint 2007. تمر برامج الإعداد للإصدارات الأحدث عبر نفس الشاشات.
{{% /alert %}}

إذا كان نفس إصدار Aspose.Slides for SharePoint مثبتًا بالفعل، يوفر برنامج الإعداد خيار الإصلاح أو الإزالة. إذا كان إصدار آخر مثبتًا، يوفر خيار الترقية أو الإزالة.

بعد التثبيت، يظهر عنصر **Convert via Aspose.Slides** في قائمة الملفات في مكتبات المستندات لمجموعات المواقع المحددة (في SharePoint 2007، **Convert with Aspose.Slides**). لتحويل أول عرض تقديمي، راجع [Converting Microsoft PowerPoint Documents into Other Formats](/slides/ar/sharepoint/converting-microsoft-powerpoint-documents-into-other-formats/). ما يضيفه الحل إلى المجموعة موصوف في [Deployment and Activation](/slides/ar/sharepoint/deployment-and-activation/).

## **الأسئلة المتكررة**

**أي برنامج إعداد يجب تشغيله؟**

ذلك الذي يتطابق اسمه مع إصدار SharePoint الخاص بك. على سبيل المثال، شغّل *Setup2016.exe* على مجموعة SharePoint Server 2016. كل برنامج إعداد يثبت حزمة الحل الخاصة به فقط.

**هل أحتاج إلى تنزيل منفصل للإصدار المرخص؟**

لا. الحزمة نفسها تعمل في وضع التقييم حتى تقوم بتثبيت حل الترخيص؛ راجع [Installing Aspose.Slides for SharePoint License](/slides/ar/sharepoint/installing-aspose-slides-for-sharepoint-license/).

**كيف يمكنني إزالة المنتج؟**

شغّل نفس برنامج الإعداد مرة أخرى واختر **Remove**؛ راجع [Uninstalling Aspose.Slides for SharePoint](/slides/ar/sharepoint/uninstalling-aspose-slides-for-sharepoint/).