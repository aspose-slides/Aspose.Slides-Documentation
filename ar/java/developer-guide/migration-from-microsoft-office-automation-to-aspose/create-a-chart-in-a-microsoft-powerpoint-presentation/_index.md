---
title: إنشاء مخطط في عرض تقديمي من Microsoft PowerPoint
type: docs
weight: 70
url: /ar/java/create-a-chart-in-a-microsoft-powerpoint-presentation/
---

{{% alert color="primary" %}} 

 المخططات هي تمثيلات مرئية للبيانات تستخدم على نطاق واسع في العروض التقديمية. يوضح هذا المقال الشيفرة اللازمة لإنشاء مخطط في Microsoft PowerPoint برمجياً باستخدام [VSTO](/slides/ar/java/create-a-chart-in-a-microsoft-powerpoint-presentation/) و [Aspose.Slides for Java](/slides/ar/java/create-a-chart-in-a-microsoft-powerpoint-presentation/).

{{% /alert %}} 
## **إنشاء مخطط**
تصف أمثلة الشيفرة أدناه عملية إضافة مخطط أعمدة متراصة ثلاثية الأبعاد بسيطة باستخدام VSTO. تقوم بإنشاء مثيل عرض تقديمي، وإضافة مخطط افتراضي إليه. ثم تستخدم مصنف Microsoft Excel للوصول إلى بيانات المخطط وتعديلها بالإضافة إلى تعيين خصائص المخطط. وأخيرًا، حفظ العرض التقديمي.
### **مثال VSTO**
باستخدام VSTO، يتم تنفيذ الخطوات التالية:

1. إنشاء مثيل عرض تقديمي من Microsoft PowerPoint.
1. إضافة شريحة فارغة إلى العرض التقديمي.
1. إضافة مخطط **أعمدة متراصة ثلاثية الأبعاد** والوصول إليه.
1. إنشاء مثيل جديد لمصنف Microsoft Excel وتحميل بيانات المخطط.
1. الوصول إلى ورقة بيانات المخطط باستخدام مثيل مصنف Microsoft Excel.
1. تعيين نطاق المخطط في ورقة العمل وإزالة السلسلتين 2 و 3 من المخطط.
1. تعديل بيانات الفئات في ورقة بيانات المخطط.
1. تعديل بيانات السلسلة 1 في ورقة بيانات المخطط.
1. الآن، الوصول إلى عنوان المخطط وتعيين خصائص خط الكتابة.
1. الوصول إلى محور قيمة المخطط وتعيين الوحدة الرئيسية، الوحدات الثانوية، القيمة القصوى والقيم الدنيا.
1. الوصول إلى عمق المخطط أو محور السلاسل وإزالته كما في هذا المثال، حيث يتم استخدام سلسلة واحدة فقط.
1. الآن، تعيين زوايا دوران المخطط في الاتجاهين X و Y.
1. حفظ العرض التقديمي.
1. إغلاق مثيلات Microsoft Excel و PowerPoint.

**العرض التقديمي الناتج، الذي تم إنشاؤه باستخدام VSTO** 

![todo:image_alt_text](create-a-chart-in-a-microsoft-powerpoint-presentation_1.png)



{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-VSTOChart-VSTOChart.cs" >}}

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-VSTOChart-EnsurePowerPointIsRunning.cs" >}}
### **مثال Aspose.Slides for Java**
باستخدام Aspose.Slides for Java، يتم تنفيذ الخطوات التالية:

1. إنشاء مثيل عرض تقديمي من Microsoft PowerPoint.
1. إضافة شريحة فارغة إلى العرض التقديمي.
1. إضافة مخطط **أعمدة متراصة ثلاثية الأبعاد** والوصول إليه.
1. الوصول إلى ورقة بيانات المخطط باستخدام مثيل مصنف Microsoft Excel.
1. إزالة السلسلتين 2 و 3 غير المستخدمتين.
1. الوصول إلى فئات المخطط وتعديل التسميات.
1. الوصول إلى السلسلة 1 وتعديل قيم السلسلة.
1. الآن، الوصول إلى عنوان المخطط وتعيين خصائص الخط.
1. الوصول إلى محور قيمة المخطط وتعيين الوحدة الرئيسية، الوحدات الثانوية، القيمة القصوى والقيم الدنيا.
1. الآن، تعيين زوايا دوران المخطط في الاتجاهين X و Y.
1. حفظ العرض التقديمي بتنسيق PPTX.

**العرض التقديمي الناتج، الذي تم إنشاؤه باستخدام Aspose.Slides** 

![todo:image_alt_text](create-a-chart-in-a-microsoft-powerpoint-presentation_2.png)

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-CreateChart-CreateChart.java" >}}