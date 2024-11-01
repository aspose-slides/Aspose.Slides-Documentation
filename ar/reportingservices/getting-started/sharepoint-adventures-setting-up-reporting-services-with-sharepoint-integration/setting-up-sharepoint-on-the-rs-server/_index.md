---
title: إعداد SharePoint على خادم RS
type: docs
weight: 40
url: /ar/reportingservices/setting-up-sharepoint-on-the-rs-server/
---

{{% alert color="primary" %}} 

لذا، نحتاج إلى القيام بما قمنا به من أجل WFE الخاص بشير بوينت. أول شيء هو المرور بعملية تثبيت المتطلبات الأساسية وبعد ذلك بدء إعداد SharePoint. 

بالنسبة للإعداد، نختار Server Farm وتثبيت كامل يتناسب مع صندوق SharePoint الخاص بي، حيث أننا لا نريد تثبيت مستقل لـ SharePoint. 

{{% /alert %}} 
### **إعداد SharePoint**
في معالج إعداد SharePoint، نريد الاتصال بمزرعة موجودة. 

![todo:image_alt_text](setting-up-sharepoint-on-the-rs-server_1.png)

**الشكل 13**: معالج إعداد SharePoint 

سنشير بعد ذلك إلى قاعدة بيانات **SharePoint_Config** التي تستخدمها مزرعتنا. إذا كنت لا تعرف أين تقع هذه، يمكنك اكتشاف ذلك من خلال Central Admin عبر **إعدادات النظام -> إدارة الخوادم في هذه المزرعة.** 

![todo:image_alt_text](setting-up-sharepoint-on-the-rs-server_2.png)

**الشكل 14**: معالج إعداد SharePoint 

![todo:image_alt_text](setting-up-sharepoint-on-the-rs-server_3.png)

**الشكل 15**: معالج إعداد SharePoint 

بمجرد انتهاء المعالج، هذا كل ما نحتاج إلى القيام به على صندوق Report Server في الوقت الحالي. عند العودة إلى عنوان URL الخاص بـ ReportServer، سنرى خطأ آخر، ولكن ذلك لأننا لم نقم بتكوينه من خلال المسؤول المركزي. 

![todo:image_alt_text](setting-up-sharepoint-on-the-rs-server_4.png)

**الشكل 16**: خطأ خادم التقرير