---
title: نظرة عامة على المنتج
type: docs
weight: 10
url: /ar/jasperreports/product-overview/
description: "تعرف على ما تقوم به Aspose.Slides for JasperReports، وإصدارات JasperReports التي يدعمها وتنسيقات الإخراج المتاحة، وما الغرض من ملفي jar الاثنين."
---
![Aspose.Slides لتقارير Jasper](product-overview_1.png)

## **وصف المنتج**

Aspose.Slides for JasperReports يصدر التقارير من JasperReports إلى عروض PowerPoint، في تطبيقات Java وفي JasperReports Server، دون الحاجة إلى Microsoft PowerPoint. يدعم JasperReports من الإصدار 3.7.2 إلى 6.16.0، مع ملف jar منفصل لكل نطاق إصدارات — راجع [تثبيت Aspose.Slides for JasperReports](/slides/ar/jasperreports/installing-aspose-slides-for-jasperreports/).

يصدر تقريرًا مملوءًا إلى أربعة تنسيقات، شريحة أو صفحة واحدة لكل صفحة تقرير:

- PPT – عرض PowerPoint 97–2003
- PPTX – عرض PowerPoint (Office Open XML)
- PDF
- HTML

المنتج يتكون من جزأين:

- jar المكتبة يضيف المصدرين `ASPptExporter`، `ASPptxExporter`، `ASPdfExporter` و `ASHtmlExporter` إلى مكتبة JasperReports.
- jar الخادم يوفر إجراءات تصدير لنفس الأربعة تنسيقات، والتي تقوم بتسجيلها في JasperReports Server — راجع [التكامل مع JasperServer](/slides/ar/jasperreports/integration-with-jasperserver/).

### **مثال على الإخراج**

المصدرون يمددون فئات المصدر الخاصة بـ JasperReports ويُستخدمون بنفس الطريقة: تمرير التقرير المملوء وملف الإخراج، ثم استدعاء `exportReport`. لبرنامج كامل يملأ تقريرًا ويصدره إلى PPTX، راجع [أول عملية تصدير لك](/slides/ar/jasperreports/#your-first-export)؛ لجميع التنسيقات الأربعة، راجع [تصدير PPT و PPTX و PDF و HTML](/slides/ar/jasperreports/ppt-pptx-pdf-and-html-export/).

![تقرير تم تصديره إلى عرض تقديمي بدون ترخيص، مع علامة مائية للتقييم في وسط الشريحة](product-overview_2.png)