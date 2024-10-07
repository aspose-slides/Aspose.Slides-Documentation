---
title: إنشاء رسم بياني في عرض تقديمي باستخدام Microsoft PowerPoint
type: docs
weight: 70
url: /androidjava/create-a-chart-in-a-microsoft-powerpoint-presentation/
---

{{% alert color="primary" %}} 

 الرسوم البيانية هي تمثيلات بصرية للبيانات تُستخدم بشكل واسع في العروض التقديمية. يوضح هذا المقال الكود لإنشاء رسم بياني في Microsoft PowerPoint برمجياً باستخدام [VSTO](/slides/androidjava/create-a-chart-in-a-microsoft-powerpoint-presentation/) و [Aspose.Slides for Android via Java](/slides/androidjava/create-a-chart-in-a-microsoft-powerpoint-presentation/).

{{% /alert %}} 
## **إنشاء رسم بياني**
تصف أمثلة الكود أدناه عملية إضافة رسم بياني بسيط من نوع عمود مجمع ثلاثي الأبعاد باستخدام VSTO. تقوم بإنشاء مثيل للعروض التقديمية، وإضافة رسم بياني افتراضي إليه. ثم تستخدم دفتر عمل Microsoft Excel للوصول إلى بيانات الرسم البياني وتعديلها بالإضافة إلى تعيين خصائص الرسم البياني. أخيرًا، حفظ العرض التقديمي.
### **مثال VSTO**
باستخدام VSTO، يتم تنفيذ الخطوات التالية:

1. إنشاء مثيل لعرض تقديمي باستخدام Microsoft PowerPoint.
1. إضافة شريحة فارغة إلى العرض التقديمي.
1. إضافة رسم بياني من نوع **عمود مجمع ثلاثي الأبعاد** والوصول إليه.
1. إنشاء مثيل جديد لدفتر عمل Microsoft Excel وتحميل بيانات الرسم البياني.
1. الوصول إلى ورقة بيانات الرسم البياني باستخدام مثيل دفتر العمل من ملف العمل.
1. تعيين نطاق الرسم البياني في ورقة العمل وإزالة السلسلتين 2 و 3 من الرسم البياني.
1. تعديل بيانات فئة الرسم البياني في ورقة بيانات الرسم البياني.
1. تعديل بيانات السلسلة 1 في ورقة بيانات الرسم البياني.
1. الآن، الوصول إلى عنوان الرسم البياني وتعيين خصائص الخط ذات الصلة.
1. الوصول إلى محور قيمة الرسم البياني وتعيين الوحدة الأساسية، والوحدات الفرعية، والقيمة القصوى والقيم الدنيا.
1. الوصول إلى عمق الرسم البياني أو محور السلسلة وإزالته كما في هذا المثال، حيث يتم استخدام سلسلة واحدة فقط.
1. الآن، تعيين زوايا دوران الرسم البياني في الاتجاهين X و Y.
1. حفظ العرض التقديمي.
1. إغلاق مثيلات Microsoft Excel و PowerPoint.

**العرض التقديمي الناتج، الذي تم إنشاؤه باستخدام VSTO** 

![todo:image_alt_text](create-a-chart-in-a-microsoft-powerpoint-presentation_1.png)



{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-VSTOChart-VSTOChart.cs" >}}

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-VSTOChart-EnsurePowerPointIsRunning.cs" >}}
### **مثال Aspose.Slides for Android عبر Java**
باستخدام Aspose.Slides for Android عبر Java، يتم تنفيذ الخطوات التالية:

1. إنشاء مثيل لعرض تقديمي باستخدام Microsoft PowerPoint.
1. إضافة شريحة فارغة إلى العرض التقديمي.
1. إضافة رسم بياني من نوع **عمود مجمع ثلاثي الأبعاد** والوصول إليه.
1. الوصول إلى ورقة بيانات الرسم البياني باستخدام مثيل دفتر عمل Microsoft Excel من ملف العمل.
1. إزالة السلسلتين 2 و 3 غير المستخدمتين.
1. الوصول إلى فئات الرسم البياني وتعديل التسميات.
1. الوصول إلى السلسلة 1 وتعديل قيم السلسلة.
1. الآن، الوصول إلى عنوان الرسم البياني وتعيين خصائص الخط.
1. الوصول إلى محور قيمة الرسم البياني وتعيين الوحدة الأساسية، والوحدات الفرعية، والقيمة القصوى والقيم الدنيا.
1. الآن، تعيين زوايا دوران الرسم البياني في الاتجاهين X و Y.
1. حفظ العرض التقديمي بتنسيق PPTX.

**العرض التقديمي الناتج، الذي تم إنشاؤه باستخدام Aspose.Slides** 

![todo:image_alt_text](create-a-chart-in-a-microsoft-powerpoint-presentation_2.png)

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-CreateChart-CreateChart.java" >}}