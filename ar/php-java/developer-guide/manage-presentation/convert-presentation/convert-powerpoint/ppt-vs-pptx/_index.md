---
title: PPT مقابل PPTX
type: docs
weight: 10
url: /ar/php-java/ppt-vs-pptx/
keywords: "PPT مقابل PPTX"
description: "اقرأ عن الفرق بين PPT و PPTX في Aspose.Slides."
---

## **ما هو PPT؟**
[**PPT**](https://docs.fileformat.com/presentation/ppt/) هو تنسيق ملف ثنائي، أي أنه من المستحيل عرض محتواه بدون أدوات خاصة. كانت النسخ الأولى من PowerPoint 97-2003 تعمل مع تنسيق ملف PPT، ومع ذلك، فإن إمكانية التوسع فيه محدودة.
## **ما هو PPTX؟**
[**PPTX**](https://docs.fileformat.com/presentation/pptx/) هو تنسيق جديد لملف العرض التقديمي، يعتمد على معيار Office Open XML (ISO 29500:2008-2016، ECMA-376). يعد تنسيق PPTX مجموعة مؤرشفة من ملفات XML ووسائط. تنسيق PPTX قابل للتوسع بسهولة. على سبيل المثال، من السهل إضافة دعم لنوع مخطط جديد أو نوع شكل، دون تغيير تنسيق PPTX في كل إصدار جديد من PowerPoint. يتم استخدام تنسيق PPTX بدءًا من PowerPoint 2007.
## **PPT مقابل PPTX**
على الرغم من أن PPTX يوفر وظائف أوسع بكثير، إلا أن PPT لا يزال شائعًا. الطلب على تحويل من PPT إلى PPTX والعكس صحيح مرتفع جدًا.

ومع ذلك، فإن التحويل بين تنسيق PPT القديم و PPTX الجديد هو التحدي الأكثر تعقيدًا بين تنسيقات Microsoft Office الأخرى. على الرغم من أن مواصفة تنسيق PPT مفتوحة، إلا أنه من الصعب العمل بها. يمكن أن ينشئ PowerPoint أجزاء خاصة (MetroBlob) في ملفات PPT لتخزين معلومات من PPTX غير المدعومة من تنسيق PPT ولا يمكن عرضها في النسخ القديمة من PowerPoint. يمكن استعادة هذه المعلومات عند تحميل ملف PPT في إصدار PowerPoint حديث أو تحويله إلى تنسيق PPTX.

تقدم Aspose.Slides واجهة شائعة للعمل مع جميع تنسيقات العرض التقديمي. يسمح بالتحويل من PPT إلى PPTX ومن PPTX إلى PPT بطريقة بسيطة جدًا. تدعم Aspose.Slides تمامًا التحويل من PPT إلى PPTX وتدعم أيضًا التحويل من PPTX إلى PPT مع بعض القيود. نوصي باستخدام تنسيق PPTX كلما كان ذلك ممكنًا.

{{% alert color="primary" %}} 

تحقق من جودة تحويل PPT إلى PPTX ومن PPTX إلى PPT مع تطبيق التحويل عبر الإنترنت [**Aspose.Slides Conversion app**](https://products.aspose.app/slides/conversion/).

{{% /alert %}} 

```php
  # إنشاء كائن Presentation يمثل ملف PPT
  $pres = new Presentation("PPTtoPPTX.ppt");
  try {
    # حفظ عرض PPT إلى تنسيق PPTX
    $pres->save("PPTtoPPTX_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="primary" %}} 
اقرأ المزيد [**كيفية تحويل العروض التقديمية من PPT إلى PPTX**.](/slides/ar/php-java/convert-ppt-to-pptx/)
{{% /alert %}} 