---
title: إنشاء وتضمين مخطط Excel ككائن OLE في شريحة Microsoft PowerPoint
type: docs
weight: 60
url: /ar/java/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/
---

{{% alert color="primary" %}} 

 المخططات هي تمثيلات بصرية لبياناتك وتستخدم بشكل واسع في شرائح العروض التقديمية. ستوضح لك هذه المقالة الكود لإنشاء وتضمين مخطط Excel ككائن OLE في شريحة PowerPoint برمجياً باستخدام [VSTO](/slides/ar/java/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/) و [Aspose.Slides for Java](/slides/ar/java/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/).

{{% /alert %}} 
## **إنشاء وتضمين مخطط Excel**
أمثلة الشفرات أدناه طويلة ومفصلة لأن المهمة التي تصفها معقدة. تقوم بإنشاء مصنف Microsoft Excel، وإنشاء مخطط ثم إنشاء عرض تقديمي Microsoft PowerPoint الذي ستقوم بتضمين المخطط فيه. تحتوي كائنات OLE على روابط للمستند الأصلي بحيث يقوم المستخدم الذي ينقر نقرًا مزدوجًا على الملف المضمن بتشغيل الملف وتطبيقه.
### **مثال VSTO**
باستخدام VSTO، يتم تنفيذ الخطوات التالية:

1. إنشاء مثيل لكائن Microsoft Excel ApplicationClass.
1. إنشاء مصنف جديد يحتوي على ورقة واحدة.
1. إضافة مخطط إلى الورقة.
1. حفظ المصنف.
1. فتح مصنف Excel الذي يحتوي على ورقة العمل بمخطط البيانات.
1. الحصول على مجموعة ChartObjects للورقة.
1. الحصول على المخطط للتكرار.
1. إنشاء عرض تقديمي Microsoft PowerPoint.
1. إضافة شريحة فارغة إلى العرض التقديمي.
1. نسخ المخطط من ورقة Excel إلى حافظة النظام.
1. لصق المخطط في عرض PowerPoint.
1. وضع المخطط على الشريحة.
1. حفظ العرض التقديمي.



{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-CreateandEmbedExcelChartAsOLEUsingVSTO-CreateAndEmbedExcelChartAsOLEUsingVSTO.cs" >}}

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-CreateandEmbedExcelChartAsOLEUsingVSTO-SetCellValue.cs" >}}

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-CreateandEmbedExcelChartAsOLEUsingVSTO-CreateNewChartInExcel.cs" >}}

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-CreateandEmbedExcelChartAsOLEUsingVSTO-UseCopyPaste.cs" >}}
### **مثال Aspose.Slides for Java**
باستخدام Aspose.Slides لـ .NET، يتم تنفيذ الخطوات التالية:

1. إنشاء مصنف باستخدام Aspose.Cells لـ Java.
1. إنشاء مخطط Microsoft Excel.
1. تعيين حجم OLE لمخطط Excel.
1. الحصول على صورة للمخطط.
1. تضمين مخطط Excel ككائن OLE داخل عرض تقديمي PPTX باستخدام Aspose.Slides لـ Java.
1. استبدال الصورة المتغيرة للكائن بالصورة التي تم الحصول عليها في الخطوة 3 لمعالجة مشكلة تغيير الكائن.
1. كتابة العرض التقديمي الناتج إلى القرص بتنسيق PPTX.



{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-EmbedChartAsOLEObject-EmbedChartAsOLEObject.java" >}}



{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-EmbedChartAsOLEObject-AddExcelChartInPresentation.java" >}}



{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-EmbedChartAsOLEObject-AddExcelChartInWorkbook.java" >}}