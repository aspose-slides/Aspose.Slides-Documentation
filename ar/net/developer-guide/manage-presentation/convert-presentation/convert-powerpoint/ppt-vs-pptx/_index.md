---
title: PPT مقابل PPTX
type: docs
weight: 10
url: /net/ppt-vs-pptx/
keywords: "PPT مقابل PPTX, PPT أو PPTX, عرض PowerPoint, تنسيق, C#, Csharp, .NET"
description: "حول تنسيقات عرض PowerPoint. PPT مقابل PPTX. الاختلافات في C# أو .NET"
---


## **ما هو PPT؟**
[**PPT**](https://docs.fileformat.com/presentation/ppt/) هو تنسيق ملف ثنائي، أي أنه من المستحيل عرض محتوياته بدون أدوات خاصة. كانت إصدارات PowerPoint 97-2003 تعمل بتنسيق ملف PPT، لكن القابلية للتوسع فيه محدودة.  
## **ما هو PPTX؟**
[**PPTX**](https://docs.fileformat.com/presentation/pptx/) هو تنسيق ملف تقديم جديد، يعتمد على معيار Office Open XML (ISO 29500:2008-2016، ECMA-376). PPTX هو مجموعة مؤرشفة من ملفات XML ووسائط. تنسيق PPTX قابل للتوسع بسهولة. على سبيل المثال، من السهل إضافة دعم لنوع جديد من المخططات أو نوع جديد من الأشكال، دون تغيير تنسيق PPTX في كل إصدار جديد من PowerPoint. يتم استخدام تنسيق PPTX بدءًا من PowerPoint 2007.

## **PPT مقابل PPTX**
على الرغم من أن PPTX يوفر وظائف أوسع بكثير، إلا أن PPT يظل شائعًا جدًا. الحاجة إلى التحويل من PPT إلى PPTX والعكس بالعكس مطلوبة بشدة.

ومع ذلك، فإن التحويل بين تنسيق PPT القديم وPPTX الجديد هو أكثر التحديات تعقيدًا بين باقي تنسيقات Microsoft Office. على الرغم من أن مواصفة تنسيق PPT مفتوحة، إلا أنه من الصعب العمل بها. يمكن أن ينشئ PowerPoint أجزاء خاصة (MetroBlob) في ملفات PPT لتخزين المعلومات من PPTX التي لا يدعمها تنسيق PPT ولا يمكن عرضها في إصدارات PowerPoint القديمة. يمكن استعادة هذه المعلومات عند تحميل ملف PPT في إصدار PowerPoint حديث أو تحويله إلى تنسيق PPTX.

توفر Aspose.Slides واجهة شائعة للعمل مع جميع تنسيقات العروض التقديمية. يسمح بتحويل من PPT إلى PPTX وPPTX إلى PPT بطريقة بسيطة جدًا. تدعم Aspose.Slides تمامًا التحويل من PPT إلى PPTX كما تدعم أيضًا التحويل من PPTX إلى PPT مع بعض القيود. نوصي باستخدام تنسيق PPTX كلما أمكن ذلك.

{{% alert color="primary" %}} 

تحقق من جودة تحويلات PPT إلى PPTX وPPTX إلى PPT باستخدام تطبيق [**تحويل Aspose.Slides**](https://products.aspose.app/slides/conversion/).

{{% /alert %}} 

```c#
// قم بإنشاء كائن Presentation يمثل ملف PPTX
Presentation pres = new Presentation("PPTtoPPTX.ppt");

// حفظ عرض PPTX بتنسيق PPTX
pres.Save("PPTtoPPTX_out.pptx", SaveFormat.Pptx);
```

{{% alert color="primary" %}} 
اقرأ المزيد عن [**كيفية تحويل العروض التقديمية من PPT إلى PPTX**.](/slides/net/convert-ppt-to-pptx/)
{{% /alert %}} 