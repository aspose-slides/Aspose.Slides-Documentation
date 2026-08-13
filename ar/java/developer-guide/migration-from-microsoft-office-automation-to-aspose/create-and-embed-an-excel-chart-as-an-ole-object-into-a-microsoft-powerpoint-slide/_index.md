---
title: إنشاء وتضمين مخططات Excel ككائنات OLE باستخدام VSTO و Aspose.Slides للـ Java
linktitle: إنشاء وتضمين مخططات Excel ككائنات OLE
type: docs
weight: 60
url: /ar/java/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/
keywords:
- إنشاء مخطط
- تضمين مخطط Excel
- كائن OLE
- ترحيل
- VSTO
- أتمتة Office
- PowerPoint
- عرض تقديمي
- Java
- Aspose.Slides
description: قم بالترحيل من أتمتة Microsoft Office إلى Aspose.Slides للـ Java وتضمين مخططات Excel ككائنات OLE في شرائح PowerPoint (PPT، PPTX) باستخدام Java.
---
{{% alert color="info" %}} 
المخططات هي تمثيلات مرئية لبياناتك وتستخدم على نطاق واسع في شرائح العروض التقديمية. ستوضح لك هذه المقالة الشيفرة لإنشاء وتضمين مخطط Excel ككائن OLE في شريحة PowerPoint برمجيًا باستخدام [VSTO](/slides/ar/java/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/) و[Aspose.Slides for Java](/slides/ar/java/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/).
{{% /alert %}} 
## **إنشاء وتضمين مخطط Excel**
الأمثلة البرمجية الاثنين أدناه طويلة ومفصلة لأن المهمة التي تصفها معقدة. تقوم بإنشاء دفتر عمل Microsoft Excel، وإنشاء مخطط ثم إنشاء عرض تقديمي Microsoft PowerPoint ستقوم بتضمين المخطط فيه. تحتوي كائنات OLE على روابط إلى المستند الأصلي بحيث أن المستخدم الذي ينقر مرتين على الملف المضمّن سيطلق الملف وتطبيقه.
### **مثال VSTO**
باستخدام VSTO، يتم تنفيذ الخطوات التالية:
1. إنشاء نسخة من كائن Microsoft Excel ApplicationClass.
1. إنشاء دفتر عمل جديد يحتوي على ورقة واحدة.
1. إضافة مخطط إلى الورقة.
1. حفظ دفتر العمل.
1. فتح دفتر عمل Excel الذي يحتوي على ورقة العمل مع بيانات المخطط.
1. الحصول على مجموعة ChartObjects للورقة.
1. الحصول على المخطط للنسخ.
1. إنشاء عرض تقديمي Microsoft PowerPoint.
1. إضافة شريحة فارغة إلى العرض التقديمي.
1. نسخ المخطط من ورقة عمل Excel إلى الحافظة.
1. لصق المخطط في عرض PowerPoint التقديمي.
1. وضع المخطط على الشريحة.
1. حفظ العرض التقديمي.

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-CreateandEmbedExcelChartAsOLEUsingVSTO-CreateAndEmbedExcelChartAsOLEUsingVSTO.cs" >}}

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-CreateandEmbedExcelChartAsOLEUsingVSTO-SetCellValue.cs" >}}

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-CreateandEmbedExcelChartAsOLEUsingVSTO-CreateNewChartInExcel.cs" >}}

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-CreateandEmbedExcelChartAsOLEUsingVSTO-UseCopyPaste.cs" >}}
### **مثال Aspose.Slides for Java**
باستخدام Aspose.Slides للـ .NET، يتم تنفيذ الخطوات التالية:
1. إنشاء دفتر عمل باستخدام Aspose.Cells for Java.
1. إنشاء مخطط Microsoft Excel.
1. تعيين حجم OLE لمخطط Excel.
1. الحصول على صورة للمخطط.
1. تضمين مخطط Excel ككائن OLE داخل عرض تقديمي PPTX باستخدام Aspose.Slides for Java.
1. استبدال الصورة المتغيّرة للكائن بالصورة التي تم الحصول عليها في الخطوة 3 لمعالجة مشكلة تغير الكائن.
1. كتابة العرض التقديمي الناتج إلى القرص بتنسيق PPTX.

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-EmbedChartAsOLEObject-EmbedChartAsOLEObject.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-EmbedChartAsOLEObject-AddExcelChartInPresentation.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-EmbedChartAsOLEObject-AddExcelChartInWorkbook.java" >}}