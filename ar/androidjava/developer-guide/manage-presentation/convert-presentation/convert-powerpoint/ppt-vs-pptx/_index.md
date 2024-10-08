---
title: PPT مقابل PPTX
type: docs
weight: 10
url: /ar/androidjava/ppt-vs-pptx/
keywords: "PPT مقابل PPTX"
description: "اقرأ عن اختلافات PPT مقابل PPTX في Aspose.Slides."
---

## **ما هو PPT؟**
[**PPT**](https://docs.fileformat.com/presentation/ppt/) هو تنسيق ملف ثنائي، أي أنه من المستحيل عرض محتواه بدون أدوات خاصة. كانت الإصدارات الأولى من PowerPoint 97-2003 تعمل مع تنسيق ملف PPT، ومع ذلك فإن قابليته للتوسع محدودة.
## **ما هو PPTX؟**
[**PPTX**](https://docs.fileformat.com/presentation/pptx/) هو تنسيق ملف تقديم جديد، يعتمد على معيار Office Open XML (ISO 29500:2008-2016، ECMA-376). PPTX هو مجموعة مؤرشفة من ملفات XML ووسائط. تنسيق PPTX قابل للتوسع بسهولة. على سبيل المثال، من السهل إضافة دعم لنوع مخطط جديد أو نوع شكل، دون تغيير تنسيق PPTX في كل إصدار جديد من PowerPoint. يتم استخدام تنسيق PPTX بدءًا من PowerPoint 2007.
## **PPT مقابل PPTX**
على الرغم من أن PPTX يوفر وظيفة أوسع بكثير، إلا أن PPT لا يزال شائعًا. الحاجة إلى التحويل من PPT إلى PPTX والعكس صحيح مطلوبة بشدة.

ومع ذلك، فإن التحويل بين تنسيق PPT القديم وPPTX الجديد هو أكثر التحديات تعقيدًا بين تنسيقات Microsoft Office الأخرى. على الرغم من أن مواصفات تنسيق PPT مفتوحة، إلا أنه من الصعب العمل معها. يمكن لـ PowerPoint إنشاء أجزاء خاصة (MetroBlob) في ملفات PPT لتخزين المعلومات من PPTX التي لا يدعمها تنسيق PPT ولا يمكن عرضها في إصدارات PowerPoint القديمة. يمكن استرداد هذه المعلومات عند تحميل ملف PPT في إصدار حديث من PowerPoint أو تحويله إلى تنسيق PPTX.

توفر Aspose.Slides واجهة مشتركة للعمل مع جميع تنسيقات العروض التقديمية. يسمح بالتحويل من PPT إلى PPTX ومن PPTX إلى PPT بطريقة بسيطة جدًا. تدعم Aspose.Slides بالكامل التحويل من PPT إلى PPTX كما تدعم أيضًا التحويل من PPTX إلى PPT مع بعض القيود. نوصي باستخدام تنسيق PPTX حيثما أمكن ذلك.

{{% alert color="primary" %}} 

تحقق من جودة التحويل من PPT إلى PPTX ومن PPTX إلى PPT مع تطبيق [**تحويل Aspose.Slides**](https://products.aspose.app/slides/conversion/).

{{% /alert %}} 

```java
// إنشاء كائن Presentation يمثل ملف PPT
Presentation pres = new Presentation("PPTtoPPTX.ppt");
try {
// حفظ عرض PPT إلى تنسيق PPTX
    pres.save("PPTtoPPTX_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="primary" %}} 
اقرأ المزيد [**كيفية تحويل العروض التقديمية من PPT إلى PPTX**.](/slides/ar/androidjava/convert-ppt-to-pptx/)
{{% /alert %}} 