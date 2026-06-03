---
title: نظرة عامة على المنتج
type: docs
weight: 10
url: /ar/jasperreports/product-overview/
---
![Aspose.Slides لـ JasperReports](product-overview_1.png)

## **مرحبًا بك في Aspose.Slides لـ JasperReports!**

Aspose.Slides for JasperReports هي مكتبة صُممت وطُورت خصيصًا للمطورين الذين بحاجة إلى تصدير التقارير بسهولة من JasperReports إلى صيغ Microsoft PowerPoint Presentation (PPT) و Microsoft PowerPoint Show (PPS) في تطبيقاتهم Java. جميع ميزات التقرير تُحوّل بأعلى درجة من الدقة إلى عروض Microsoft PowerPoint. Aspose.Slides for JasperReports تدعم JasperReports 5+.

## **وصف المنتج**
JasperReports و JasperServer لا تمتلكان قدرات مدمجة لتصدير التقارير كعروض Microsoft PowerPoint، لكن Aspose.Slides for JasperReports يمنحك إمكانية تصدير بصيغتين إضافيتين: 

- PPT – عرض PowerPoint عبر Aspose.Slides
- PPS – عرض PowerPoint Show عبر Aspose.Slides
- PPTX – عرض PowerPoint عبر Aspose.Slides
- PPSX – عرض PowerPoint Show عبر Aspose.Slides

Aspose.Slides for JasperReports يستخدم داخليًا مكتبات Java النقية 100% الخاصة بنا، Aspose.Slides for Java و Aspose.Metafiles for Java، وهي مكتبات عالمية المستوى لمعالجة العروض التقديمية من جانب الخادم والملفات الفوقية.

Aspose.Slides for JasperReports يجعل من الممكن تصدير أي تقرير إلى صيغة PPT أو PPS.

### **مثال على الناتج**
الفئة ASPptExporter تمتد من الفئة ASAbstractExporter لتتمكن من استخدامها بنفس طريقة أي مُصدّر قياسي آخر. تُظهر هذه العينة القصيرة الكود النموذجي وصورة شاشة لتقرير يُعرض في MS PowerPoint. يمكن العثور على أمثلة مفصلة في التقارير التجريبية المقدمة. 

``` java
File sourceFile = new File(fileName); 
JasperPrint jasperPrint = (JasperPrint)JRLoader.loadObject(sourceFile);
File destFile = new File(sourceFile.getParent(), jasperPrint.getName() + ".ppt");
ASPptExporter exporter = new ASPptExporter();
exporter.setParameter(JRExporterParameter.JASPER_PRINT, jasperPrint);
exporter.setParameter(JRExporterParameter.OUTPUT_FILE_NAME, destFile.toString());
exporter.exportReport();
```

**العرض التقديمي المولّد باستخدام عرض تجريبي JasperReports xmldatasource** 

![العرض التقديمي المولّد باستخدام JasperReports](product-overview_2.png)