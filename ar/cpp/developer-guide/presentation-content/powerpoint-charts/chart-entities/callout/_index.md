---
title: إدارة التعليقات التوضيحية في مخططات العروض التقديمية باستخدام C++
linktitle: التعليق التوضيحي
type: docs
url: /ar/cpp/callout/
keywords:
- تعليق توضيحي للمخطط
- استخدام التعليق التوضيحي
- تسمية البيانات
- تنسيق التسميات
- PowerPoint
- عرض تقديمي
- C++
- Aspose.Slides
description: "إنشاء وتنسيق التعليقات التوضيحية في Aspose.Slides للغة C++ باستخدام أمثلة شفرة مختصرة، متوافقة مع PPT وPPTX لأتمتة عمليات سير العمل في العروض التقديمية."
---
## **نظرة عامة**

تشرح هذه المقالة كيفية التعامل مع التعليقات التوضيحية لتسميات بيانات المخطط في Aspose.Slides. توضح كيفية استخدام طريقة `set_ShowLabelAsDataCallout` لعرض التسميات كتعليقات توضيحية، وكيفية تكوين إعدادات التسميات المتعلقة بالتعليقات التوضيحية لمخطط الدونات، وتذكر أن التعليقات التوضيحية ومظهرها يتم الحفاظ عليهما عند تصدير العروض التقديمية إلى صيغ PDF وHTML5 وSVG وصور النقطية.

## **استخدام التعليقات التوضيحية**
تمت إضافة الخاصية الجديدة **ShowLabelAsDataCallout** إلى الفئة **DataLabelFormat** والواجهة **IDataLabelFormat**، والتي تحدد ما إذا كانت تسمية بيانات المخطط المحدد ستُعرض كتعليق توضيحي أو كتسمية بيانات. في المثال الموضح أدناه، قمنا بتعيين التعليقات التوضيحية.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-DisplayChartLabels-DisplayChartLabels.cpp" >}}

## **تعيين تعليق توضيحي لمخطط الدونات**
توفر Aspose.Slides للغة C++ دعمًا لتعيين شكل التعليق التوضيحي لتسميات بيانات السلسلة في مخطط الدونات. يُعطى المثال التالي.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddDoughnutCallout-AddDoughnutCallout.cpp" >}}

## **الأسئلة المتكررة**

**هل يتم الحفاظ على التعليقات التوضيحية عند تحويل عرض تقديمي إلى PDF أو HTML5 أو SVG أو صور؟**

نعم. التعليقات التوضيحية هي جزء من عملية رسم المخطط، لذا عند تصدير العرض إلى [PDF](/slides/ar/cpp/convert-powerpoint-to-pdf/)، [HTML5](/slides/ar/cpp/export-to-html5/), [SVG](/slides/ar/cpp/render-a-slide-as-an-svg-image/), أو [raster images](/slides/ar/cpp/convert-powerpoint-to-png/)، يتم الحفاظ عليها مع تنسيق الشريحة.

**هل تعمل الخطوط المخصصة في التعليقات التوضيحية، وهل يمكن الحفاظ على مظهرها عند التصدير؟**

نعم. تدعم Aspose.Slides [embedding fonts](/slides/ar/cpp/embedded-font/) في العرض وتتحكم في تضمين الخطوط أثناء التصدير مثل [PDF](/slides/ar/cpp/convert-powerpoint-to-pdf/)، مما يضمن أن تبدو التعليقات التوضيحية متطابقة عبر الأنظمة المختلفة.