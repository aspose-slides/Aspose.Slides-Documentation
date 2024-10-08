---
title: PPT مقابل PPTX
type: docs
weight: 10
url: /ar/java/ppt-vs-pptx/
keywords: "PPT مقابل PPTX"
description: "اقرأ عن الاختلافات بين PPT و PPTX في Aspose.Slides."
---

## **ما هو PPT؟**
[**PPT**](https://docs.fileformat.com/presentation/ppt/) هو تنسيق ملف ثنائي، أي أنه من المستحيل عرض محتوياته دون أدوات خاصة. كانت النسخ الأولى من PowerPoint 97-2003 تعمل بتنسيق ملفات PPT، ومع ذلك فإن قابلية توسيعه محدودة.

## **ما هو PPTX؟**
[**PPTX**](https://docs.fileformat.com/presentation/pptx/) هو تنسيق ملف عرض جديد، يعتمد على معيار Office Open XML (ISO 29500:2008-2016، ECMA-376). PPTX هو مجموعة مؤرشفة من ملفات XML ووسائط. تنسيق PPTX سهل القابلية للتوسيع. على سبيل المثال، من السهل إضافة دعم لنوع جديد من الرسوم البيانية أو نوع جديد من الأشكال، دون تغيير تنسيق PPTX في كل نسخة جديدة من PowerPoint. يتم استخدام تنسيق PPTX بدءًا من PowerPoint 2007.

## **PPT مقابل PPTX**
على الرغم من أن PPTX يوفر وظائف أوسع بكثير، إلا أن PPT لا يزال يحظى بشعبية كبيرة. الطلب على التحويل من PPT إلى PPTX والعكس صحيح مرتفع جداً.

ومع ذلك، فإن التحويل بين تنسيق PPT القديم وPPTX الجديد هو التحدي الأكثر تعقيدًا بين تنسيقات Microsoft Office الأخرى. على الرغم من أن مواصفات تنسيق PPT مفتوحة، إلا أنه من الصعب العمل بها. يمكن لـ PowerPoint إنشاء أجزاء خاصة (MetroBlob) في ملفات PPT لتخزين المعلومات من PPTX التي لا يدعمها تنسيق PPT ولا يمكن عرضها في النسخ القديمة من PowerPoint. يمكن استعادة هذه المعلومات عند تحميل ملف PPT في نسخة حديثة من PowerPoint أو تحويله إلى تنسيق PPTX.

توفر Aspose.Slides واجهة عامة للعمل مع جميع تنسيقات العروض. يسمح بالتحويل من PPT إلى PPTX ومن PPTX إلى PPT بطريقة بسيطة جداً. تدعم Aspose.Slides بالكامل تحويل من PPT إلى PPTX كما تدعم أيضًا تحويل من PPTX إلى PPT مع بعض القيود. نوصي باستخدام تنسيق PPTX حيثما أمكن.

{{% alert color="primary" %}}

تحقق من جودة التحويلات من PPT إلى PPTX ومن PPTX إلى PPT عبر الإنترنت باستخدام [**تطبيق تحويل Aspose.Slides**](https://products.aspose.app/slides/conversion/).

{{% /alert %}}

```java
// أنشئ كائن Presentation يمثل ملف PPT
Presentation pres = new Presentation("PPTtoPPTX.ppt");
try {
// حفظ عرض PPT بصيغة PPTX
    pres.save("PPTtoPPTX_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="primary" %}} 
اقرأ المزيد [**كيف تحول العروض من PPT إلى PPTX**.](/slides/ar/java/convert-ppt-to-pptx/)
{{% /alert %}} 