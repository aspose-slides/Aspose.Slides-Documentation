---
title: صيغ الملفات المدعومة
type: docs
weight: 20
url: /ar/jasperreports/supported-file-formats/
description: "انظر ما الذي تستقبله Aspose.Slides for JasperReports كإدخال وتنسيقات الملفات التي تصدر التقارير إليها."
---
## **الإدخال**

يصدر Aspose.Slides for JasperReports التقارير؛ ولا يقوم بتحويل العروض التقديمية الموجودة. يقوم المُصدِّرات بأخذ تقرير JasperReports مُعبَّأ (`JasperPrint`)، مثل نتيجة `JasperFillManager` أو تقرير مُعبَّأ تم تحميله من ملف *.jrprint*.

## **تنسيقات الإخراج**

القائمة التالية تُظهر التنسيقات التي يصدرها Aspose.Slides for JasperReports لتقرير، وفئة المُصدِّر التي تكتب كل واحدة منها.

|**التنسيق**|**الوصف**|**المُصدِّر**|
| :- | :- | :- |
|[PPT](https://docs.fileformat.com/presentation/ppt/)|عرض PowerPoint 97–2003؛ شريحة واحدة لكل صفحة من التقرير|`ASPptExporter`|
|[PPTX](https://docs.fileformat.com/presentation/pptx/)|عرض PowerPoint (Office Open XML)؛ شريحة واحدة لكل صفحة من التقرير|`ASPptxExporter`|
|[PDF](https://docs.fileformat.com/pdf/)|تنسيق PDF القابل للنقل؛ صفحة PDF واحدة لكل صفحة من التقرير|`ASPdfExporter`|
|[HTML](https://docs.fileformat.com/web/html/)|ملف HTML واحد مع صورة SVG واحدة لكل صفحة من التقرير|`ASHtmlExporter`|

لا يوجد مُصدِّر لتنسيقات عرض الشرائح PPS و PPSX. إعطاء تصدير PPTX اسم ملف *.ppsx* لا يزال ينتج عرض PowerPoint بصيغة PPTX، وليس عرض شرائح. لرؤية كيفية استخدام كل مُصدِّر، راجع [تصدير PPT و PPTX و PDF و HTML](/slides/ar/jasperreports/ppt-pptx-pdf-and-html-export/).