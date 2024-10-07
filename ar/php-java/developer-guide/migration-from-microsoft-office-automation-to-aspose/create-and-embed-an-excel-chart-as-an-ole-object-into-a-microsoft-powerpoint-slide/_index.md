---
title: إنشاء وإدراج مخطط Excel ككائن OLE في شريحة Microsoft PowerPoint
type: docs
weight: 60
url: /php-java/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/
---

{{% alert color="primary" %}} 

 المخططات هي تمثيلات بصرية لبياناتك وتستخدم على نطاق واسع في شرائح العروض التقديمية. ستظهر لك هذه المقالة الكود لإنشاء وإدراج مخطط Excel ككائن OLE في شريحة PowerPoint برمجياً باستخدام [VSTO](/slides/php-java/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/) و[Aspose.Slides for PHP عبر Java](/slides/php-java/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/).

{{% /alert %}} 
## **إنشاء وإدراج مخطط Excel**
أمثلة الكود أدناه طويلة ومفصلة لأن المهمة التي تصفها معقدة. تقوم بإنشاء دفتر عمل Microsoft Excel، وإنشاء مخطط ثم إنشاء عرض Microsoft PowerPoint الذي ستدرج فيه المخطط. تحتوي كائنات OLE على روابط للمستند الأصلي بحيث يمكن للمستخدم الذي ينقر نقرًا مزدوجًا على الملف المضمن فتح الملف وتطبيقه.
### **مثال VSTO**
باستخدام VSTO، يتم تنفيذ الخطوات التالية:

1. إنشاء مثيل من كائن Microsoft Excel ApplicationClass.
1. إنشاء دفتر عمل جديد يحتوي على ورقة واحدة.
1. إضافة مخطط إلى الورقة.
1. حفظ دفتر العمل.
1. فتح دفتر العمل Excel الذي يحتوي على ورقة العمل مع بيانات المخطط.
1. الحصول على مجموعة ChartObjects للورقة.
1. الحصول على المخطط للنسخ.
1. إنشاء عرض Microsoft PowerPoint.
1. إضافة شريحة فارغة إلى العرض.
1. نسخ المخطط من ورقة العمل Excel إلى الحافظة.
1. لصق المخطط في عرض PowerPoint.
1. وضع المخطط على الشريحة.
1. حفظ العرض.



{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-CreateandEmbedExcelChartAsOLEUsingVSTO-CreateAndEmbedExcelChartAsOLEUsingVSTO.cs" >}}

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-CreateandEmbedExcelChartAsOLEUsingVSTO-SetCellValue.cs" >}}

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-CreateandEmbedExcelChartAsOLEUsingVSTO-CreateNewChartInExcel.cs" >}}

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-CreateandEmbedExcelChartAsOLEUsingVSTO-UseCopyPaste.cs" >}}
### **مثال Aspose.Slides for PHP عبر Java**
باستخدام Aspose.Slides لـ .NET، يتم تنفيذ الخطوات التالية:

1. إنشاء دفتر عمل باستخدام Aspose.Cells لـ Java.
1. إنشاء مخطط Microsoft Excel.
1. ضبط حجم OLE لمخطط Excel.
1. الحصول على صورة للمخطط.
1. إدراج مخطط Excel ككائن OLE داخل عرض PPTX باستخدام Aspose.Slides لـ PHP عبر Java.
1. استبدال صورة الكائن المتغيرة بالصورة التي تم الحصول عليها في الخطوة 3 للتعامل مع مشكلة تغير الكائن.
1. كتابة العرض الناتج إلى القرص بصيغة PPTX.



{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-EmbedChartAsOLEObject-EmbedChartAsOLEObject.java" >}}



{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-EmbedChartAsOLEObject-AddExcelChartInPresentation.java" >}}



{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-EmbedChartAsOLEObject-AddExcelChartInWorkbook.java" >}}