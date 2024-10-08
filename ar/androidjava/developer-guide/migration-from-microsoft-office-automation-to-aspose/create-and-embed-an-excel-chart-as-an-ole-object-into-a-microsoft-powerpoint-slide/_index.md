---
title: إنشاء وتضمين مخطط إكسل ككائن OLE في شريحة PowerPoint في Microsoft
type: docs
weight: 60
url: /ar/androidjava/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/
---

{{% alert color="primary" %}} 

 المخططات هي تمثيلات بصرية لبياناتك وتستخدم على نطاق واسع في شرائح العروض التقديمية. ستظهر لك هذه المقالة الكود لإنشاء وتضمين مخطط إكسل ككائن OLE في شريحة PowerPoint برمجيًا باستخدام [VSTO](/slides/ar/androidjava/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/) و[Aspose.Slides for Android via Java](/slides/ar/androidjava/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/).

{{% /alert %}} 
## **إنشاء وتضمين مخطط إكسل**
تكون الأمثلة البرمجية التالية طويلة ومفصلة لأن المهمة التي تصفها معقدة. تقوم بإنشاء مصنف Excel، ثم إنشاء مخطط، ومن ثم إنشاء عرض PowerPoint الذي ستقوم بتضمين المخطط فيه. تحتوي كائنات OLE على روابط للمستند الأصلي، لذا فإن المستخدم الذي ينقر مرتين على الملف المضمن سيطلق الملف وتطبيقه.
### **مثال VSTO**
باستخدام VSTO، يتم تنفيذ الخطوات التالية:

1. إنشاء مثيل من كائن Microsoft Excel ApplicationClass.
1. إنشاء مصنف جديد يحتوي على ورقة واحدة.
1. إضافة مخطط إلى الورقة.
1. حفظ المصنف.
1. فتح مصنف Excel الذي يحتوي على ورقة العمل التي تحتوي على بيانات المخطط.
1. الحصول على مجموعة ChartObjects للورقة.
1. الحصول على المخطط للنسخ.
1. إنشاء عرض PowerPoint.
1. إضافة شريحة فارغة إلى العرض.
1. نسخ المخطط من ورقة عمل Excel إلى الحافظة.
1. لصق المخطط في عرض PowerPoint.
1. وضع المخطط على الشريحة.
1. حفظ العرض.



{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-CreateandEmbedExcelChartAsOLEUsingVSTO-CreateAndEmbedExcelChartAsOLEUsingVSTO.cs" >}}

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-CreateandEmbedExcelChartAsOLEUsingVSTO-SetCellValue.cs" >}}

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-CreateandEmbedExcelChartAsOLEUsingVSTO-CreateNewChartInExcel.cs" >}}

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-CreateandEmbedExcelChartAsOLEUsingVSTO-UseCopyPaste.cs" >}}
### **مثال Aspose.Slides for Android via Java**
باستخدام Aspose.Slides لـ .NET، يتم تنفيذ الخطوات التالية:

1. إنشاء مصنف باستخدام Aspose.Cells لـ Java.
1. إنشاء مخطط Microsoft Excel.
1. تعيين حجم OLE لمخطط Excel.
1. الحصول على صورة للمخطط.
1. تضمين مخطط Excel ككائن OLE داخل عرض PPTX باستخدام Aspose.Slides for Android عبر Java.
1. استبدال الصورة المحدثة للكائن بالصورة التي تم الحصول عليها في الخطوة 3 لمعالجة مشكلة تغيير الكائن.
1. كتابة العرض الناتج على القرص بتنسيق PPTX.



{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-EmbedChartAsOLEObject-EmbedChartAsOLEObject.java" >}}



{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-EmbedChartAsOLEObject-AddExcelChartInPresentation.java" >}}



{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-EmbedChartAsOLEObject-AddExcelChartInWorkbook.java" >}}