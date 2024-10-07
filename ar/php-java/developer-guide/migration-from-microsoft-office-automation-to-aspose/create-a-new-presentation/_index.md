---
title: إنشاء عرض تقديمي جديد
type: docs
weight: 10
url: /php-java/create-a-new-presentation/
---

{{% alert color="primary" %}} 

تم تطوير VSTO لتمكين المطورين من بناء تطبيقات يمكن تشغيلها داخل Microsoft Office. VSTO يعتمد على COM لكنه مغلف داخل كائن .NET حتى يمكن استخدامه في تطبيقات .NET. يحتاج VSTO إلى دعم إطار عمل .NET بالإضافة إلى وقت تشغيل CLR الخاص بـ Microsoft Office. على الرغم من أنه يمكن استخدامه لصنع ملحقات Microsoft Office، إلا أنه من المستحيل تقريباً استخدامه كمكون على جانب الخادم. كما أن لديه مشاكل جدية في النشر.

Aspose.Slides لـ PHP عبر Java هو مكون يمكن استخدامه للتلاعب بعروض Microsoft PowerPoint التقديمية، تماماً مثل VSTO، ولكنه يحتوي على العديد من المزايا:

- تحتوي Aspose.Slides على كود مُدار فقط ولا تتطلب وقت تشغيل Microsoft Office للتثبيت.
- يمكن استخدامها كمكون على جانب العميل أو كمكون على جانب الخادم.
- النشر سهل حيث أن Aspose.Slides محتواة في ملف jar واحد.

{{% /alert %}} 
## **إنشاء عرض تقديمي**
فيما يلي مثالان من الشيفرة يوضحان كيفية استخدام VSTO و Aspose.Slides لـ PHP عبر Java لتحقيق نفس الهدف. المثال الأول هو [VSTO](/slides/php-java/create-a-new-presentation/); [المثال الثاني](/slides/php-java/create-a-new-presentation/) يستخدم Aspose.Slides.
### **مثال VSTO**
**مخرجات VSTO** 

![todo:image_alt_text](create-a-new-presentation_1.png)

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-AddVSTOPresentation-AddVSTOPresentation.cs" >}}
### **مثال Aspose.Slides لـ PHP عبر Java**
**المخرجات من Aspose.Slides** 

![todo:image_alt_text](create-a-new-presentation_2.png)

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Saving-CreatePresentation-CreatePresentation.java" >}}