---
title: إنشاء عرض تقديمي جديد
type: docs
weight: 10
url: /ar/java/create-a-new-presentation/
---

{{% alert color="primary" %}} 

تم تطوير VSTO لتمكين المطورين من بناء التطبيقات التي يمكن تشغيلها داخل Microsoft Office. يعتمد VSTO على COM ولكنه مغلف داخل كائن .NET بحيث يمكن استخدامه في تطبيقات .NET. يحتاج VSTO إلى دعم إطار عمل .NET بالإضافة إلى وقت تشغيل CLR الخاص بـMicrosoft Office. على الرغم من أنه يمكن استخدامه لإنشاء إضافات Microsoft Office، إلا أنه يكاد يكون من المستحيل استخدامه كمكون على جانب الخادم. كما أن لديه مشاكل نشر خطيرة.

Aspose.Slides لـ Java هو مكون يمكن استخدامه للتلاعب بعروض Microsoft PowerPoint التقديمية، تمامًا مثل VSTO، ولكنه يحتوي على عدة مزايا:

- يحتوي Aspose.Slides على كود مُدار فقط ولا يتطلب تثبيت وقت تشغيل Microsoft Office.
- يمكن استخدامه كمكون على جانب العميل أو كمكون على جانب الخادم.
- النشر سهل حيث يتم احتواء Aspose.Slides في ملف jar واحد.

{{% /alert %}} 
## **إنشاء عرض تقديمي**
فيما يلي مثالان من التعليمات البرمجية توضحان كيفية استخدام VSTO و Aspose.Slides لـ Java لتحقيق نفس الهدف. المثال الأول هو [VSTO](/slides/ar/java/create-a-new-presentation/)؛ [المثال الثاني](/slides/ar/java/create-a-new-presentation/) يستخدم Aspose.Slides.
### **مثال VSTO**
**مخرجات VSTO** 

![todo:image_alt_text](create-a-new-presentation_1.png)

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-AddVSTOPresentation-AddVSTOPresentation.cs" >}}
### **مثال Aspose.Slides لـ Java**
**المخرجات من Aspose.Slides** 

![todo:image_alt_text](create-a-new-presentation_2.png)

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Saving-CreatePresentation-CreatePresentation.java" >}}