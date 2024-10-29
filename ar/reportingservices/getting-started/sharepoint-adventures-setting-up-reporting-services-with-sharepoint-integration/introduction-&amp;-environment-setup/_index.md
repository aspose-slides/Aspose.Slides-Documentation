---
title: المقدمة وإعداد البيئة
type: docs
weight: 10
url: /ar/reportingservices/introduction-&amp;-environment-setup/
---

{{% alert color="primary" %}} 

كانت هناك استفسارات في الماضي حول دمج Aspose.Slides مع خدمات التقارير و SharePoint. في هذه المقالة، سنركز على SharePoint 2010. يُفترض أن يكون لديك بالفعل بيئة SharePoint Farm معدة. ستكون الأمثلة التي سنتبعها في هذه المقالة عبارة عن SharePoint Cloud كامل، لكن الخطوات ستكون مشابهة لخادم SharePoint Foundation. قبل أن نبدأ، دعنا نبدأ ببعض الوثائق الرئيسية التي يمكنك استخدامها كمرجع عند القيام بذلك: 

- [نظرة عامة على تكامل خدمات التقارير مع تكنولوجيا SharePoint](https://docs.microsoft.com/en-us/previous-versions/sql/sql-server-2008-r2/bb326358(v=sql.105))  
- [تكوين خدمات التقارير للتكامل مع SharePoint 2010](https://docs.microsoft.com/en-us/previous-versions/sql/)

{{% /alert %}} 
#### **إعداد البيئة**
تشمل الإعدادات التي سنقوم بها **4 خوادم**. يتضمن ذلك **وحدة تحكم المجال**، و **خادم SQL**، و **خادم SharePoint**، وخادم لـ **خدمات التقارير**. يمكنك اختيار أن يكون SharePoint و خدمات التقارير على نفس الجهاز. 