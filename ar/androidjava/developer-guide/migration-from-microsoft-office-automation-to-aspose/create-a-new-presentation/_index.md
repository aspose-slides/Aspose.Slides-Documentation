---
title: إنشاء عرض تقديمي جديد
type: docs
weight: 10
url: /ar/androidjava/create-a-new-presentation/
---

{{% alert color="primary" %}} 

تم تطوير VSTO لتمكين المطورين من إنشاء تطبيقات يمكن أن تعمل داخل Microsoft Office. يعتمد VSTO على COM ولكنه مُغلف داخل كائن .NET حتى يمكن استخدامه في تطبيقات .NET. يحتاج VSTO إلى دعم إطار عمل .NET بالإضافة إلى وقت تشغيل Microsoft Office CLR. على الرغم من أنه يمكن استخدامه لإنشاء إضافات Microsoft Office، إلا أنه يكاد يكون من المستحيل استخدامه كعنصر في جانب الخادم. كما أن لديه مشكلات نشر خطيرة.

Aspose.Slides لنظام Android عبر Java هو مكون يمكن استخدامه للتلاعب بعروض Microsoft PowerPoint التقديمية، تمامًا مثل VSTO، ولكنه يحتوي على مزايا عدة:

- يحتوي Aspose.Slides على كود مُدار فقط ولا يتطلب تثبيت وقت تشغيل Microsoft Office.
- يمكن استخدامه كمكون في جانب العميل أو كمكون في جانب الخادم.
- النشر سهل لأن Aspose.Slides موجود في ملف jar واحد.

{{% /alert %}} 
## **إنشاء عرض تقديمي**
فيما يلي مثالان برمجيان يوضحان كيفية استخدام VSTO و Aspose.Slides لنظام Android عبر Java لتحقيق نفس الهدف. المثال الأول هو [VSTO](/slides/ar/androidjava/create-a-new-presentation/)؛ [المثال الثاني](/slides/ar/androidjava/create-a-new-presentation/) يستخدم Aspose.Slides.
### **مثال VSTO**
**مخرجات VSTO** 

![todo:image_alt_text](create-a-new-presentation_1.png)

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-AddVSTOPresentation-AddVSTOPresentation.cs" >}}
### **مثال Aspose.Slides لنظام Android عبر Java**
**مخرجات Aspose.Slides** 

![todo:image_alt_text](create-a-new-presentation_2.png)



{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Saving-CreatePresentation-CreatePresentation.java" >}}