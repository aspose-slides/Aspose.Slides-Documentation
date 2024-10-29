---
title: نظرة عامة على المنتج
type: docs
weight: 10
url: /ar/jasperreports/product-overview/
---

{{% alert color="primary" %}} 

![todo:image_alt_text](product-overview_1.png)

## **مرحبًا بكم في توثيق Aspose.Slides لـ JasperReports!**
Aspose.Slides لـ JasperReports هي مكتبة مصممة خصيصًا ومطورة للمطورين الذين يحتاجون إلى تصدير التقارير بسهولة من JasperReports إلى تنسيقات Microsoft PowerPoint Presentation (PPT) و Microsoft PowerPoint Show (PPS) في تطبيقاتهم المكتوبة بلغة Java. يتم تحويل جميع ميزات التقرير بأعلى درجة من الدقة إلى عروض Microsoft PowerPoint التقديمية. تدعم Aspose.Slides لـ JasperReports إصدار JasperReports 5 وما فوق.

{{% /alert %}} 

## **وصف المنتج**
ليس لدى JasperReports و JasperServer قدرات مدمجة لتصدير التقارير كعروض تقديمية من Microsoft PowerPoint، ولكن Aspose.Slides لـ JasperReports، يمنحك الوصول إلى تنسيقات تصدير إضافية:

- PPT – عرض PowerPoint عبر Aspose.Slides
- PPS - عرض PowerPoint عبر Aspose.Slides
- PPTX – عرض PowerPoint عبر Aspose.Slides
- PPSX - عرض PowerPoint عبر Aspose.Slides

تستخدم Aspose.Slides لـ JasperReports داخليًا مكتباتنا النقية 100% بلغة Java، Aspose.Slides لـ Java و Aspose.Metafiles لـ Java، وهي مكتبات عالمية المستوى لمعالجة العروض التقديمية في الجانب الخادم وملفات التعريف.

تجعل Aspose.Slides لـ JasperReports من الممكن تصدير أي تقرير بصيغة PPT أو PPS.

### **مثال على المخرجات**
تقوم فئة ASPptExporter بتمديد فئة ASAbstractExporter حتى يمكن استخدامها بنفس طريقة استخدام أي من المصدرين القياسيين الآخرين. يعرض هذا المثال القصير كودًا نموذجيًا ولقطة شاشة لتقرير تم عرضه في MS PowerPoint. يمكن العثور على أمثلة مفصلة في التقارير التجريبية المقدمة.

``` java
File sourceFile = new File(fileName); 
JasperPrint jasperPrint = (JasperPrint)JRLoader.loadObject(sourceFile);
File destFile = new File(sourceFile.getParent(), jasperPrint.getName() + ".ppt");
ASPptExporter exporter = new ASPptExporter();
exporter.setParameter(JRExporterParameter.JASPER_PRINT, jasperPrint);
exporter.setParameter(JRExporterParameter.OUTPUT_FILE_NAME, destFile.toString());
exporter.exportReport();
```

**عرض تقديمي تم إنشاؤه باستخدام عرض البيانات xmldatasource من JasperReports** 

![todo:image_alt_text](product-overview_2.png)