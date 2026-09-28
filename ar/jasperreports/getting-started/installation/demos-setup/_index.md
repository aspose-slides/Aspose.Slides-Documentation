---
title: إعداد العروض التوضيحية
type: docs
weight: 70
url: /ar/jasperreports/demos-setup/
description: "إعداد مشاريع العروض التوضيحية من تحميل Aspose.Slides for JasperReports، وتغيير فئة المُصدِّر التي تستخدمها، وبناؤها باستخدام Ant."
---
## **ما هي العروض التوضيحية**

المجلد *samples* في تحميل Aspose.Slides for JasperReports يحتوي على ثمانية مشاريع تجريبية: *charts*، *fonts*، *images*، *landscape*، *shapes*، *subreport*، *text* و *xmldatasource*. هذه عروضا توضيحية قياسية لـ JasperReports، تم تعديلها لإضافة هدف بناء `ppt` الذي يصدر التقرير المملوء إلى PPT. لا يحتوي التحميل على أي عروض تقديمية مُصدَّرة؛ فأنت تنشئها عبر بناء عرض توضيحي.

## **تغيير فئة المُصدّر قبل الإنشاء**

كما هو معبأ، يستخدم كود Java في العروض التوضيحية `com.aspose.slides.jasperreports.JRPptExporter`، وهي فئة لا تحتويها الحزم الحالية، لذا لا تُجمع العروض التوضيحية. في فئة التطبيق للعرض (مثال، *ShapesApp.java* في عرض *shapes*)، استبدل `JRPptExporter` بـ `ASPptExporter`، المُصدّر PPT في نفس الحزمة. يستورد عرض *fonts* الحزمة بالكامل، لذا يتغيّر فقط اسم الفئة في شفرتها.

تستخدم العروض أيضًا فئات JasperReports التي أزيلت في إصدارات لاحقة، مثل `JExcelApiExporter` و `JRExporterParameter.FONT_MAP`. مع التغيير أعلاه، تُجمع العروض كما يلي:

| إصدار JasperReports | العروض التوضيحية التي تُجمع |
| :- | :- |
| 5.5.1 | جميع الثمانية |
| 5.5.2 و 6.4.0 | *charts*، *images*، *landscape*، *shapes* و *xmldatasource* |
| 6.16.0 | *charts* |

## **بناء عرض توضيحي**

كل ملف *build.xml* للعرض يتوقع هيكل مجلد مشروع JasperReports: يَجمع ضد *../../../build/classes* والحزم في *../../../lib*، نسبةً إلى مجلد العرض.

1. انسخ مجلد العرض إلى *demo/samples* في مجلد مشروع JasperReports الخاص بك.  
2. انسخ *aspose.slides.jasperreports.library-xx.x.jar* من المجلد الفرعي *lib* في التحميل الذي يتطابق مع إصدار JasperReports الخاص بك إلى مجلد *lib* في مشروع JasperReports. راجع [Installing Aspose.Slides for JasperReports](/slides/ar/jasperreports/installing-aspose-slides-for-jasperreports/).  
3. ضع ملف jar لإصدار JasperReports الخاص بك والملفات jar التي يعتمد عليها في نفس مجلد *lib*. بخلاف ملفات العرض، يضيف *build.xml* فقط *build/classes* والملفات jar تحت *lib* إلى مسار الفئة، ويحتوي *build/classes* على فئات JasperReports فقط بعد أن تُجمع JasperReports من المصدر.  
4. عروضا *charts*، *subreport* و *text* تقرأ قاعدة بيانات HSQLDB النموذجية لـ JasperReports (`jdbc:hsqldb:hsql://localhost`)، لذا شغّل خادمه أولاً كما هو موضح في *samples/Readme.txt* في التحميل. العروض الأخرى لا تحتاج إلى قاعدة بيانات.  
5. في مجلد العرض، جمع التطبيق، جمع تصميم التقرير، املأه، وصَدِّره إلى PPT:

```bash
ant javac
ant compile
ant fill
ant ppt
```

هدف `ppt` يكتب العرض التقديمي بجوار التقرير المملوء، مسمىً باسم التقرير (مثال، *LandscapeReport.ppt*).

عرضان يحتاجان إلى خطوات إضافية:

- عرض *images* يحمل صورة واحدة من `http://jasperreports.sourceforge.net/jasperreports.png` عند التصدير. هذا العنوان الآن يوجه إلى HTTPS، لذا خطوة `ppt` لا تكتب عرضًا تقديميًا حتى تغير العنوان إلى `https://` في *ImagesReport.jrxml*. مع JasperReports 6.4.0، فشل تصدير تلك الصورة حتى عبر HTTPS.  
- تقرير *xmldatasource* يستخدم خط Arial. على نظام لا يضم Arial، يطبع `ant fill` أن الخط "غير متوفر للـ JVM" ولا يكتب تقريرًا مملوءًا، لذا لا يوجد ما يصدره `ant ppt`. لا يزال البناء يُبلّغ عن النجاح، لذا تحقق من مخرجات كل خطوة.