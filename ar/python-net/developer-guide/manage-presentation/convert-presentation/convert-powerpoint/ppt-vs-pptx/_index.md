---
title: PPT مقابل PPTX
type: docs
weight: 10
url: /python-net/ppt-vs-pptx/
keywords: "PPT مقابل PPTX، PPT أو PPTX، عرض PowerPoint، تنسيق، بايثون"
description: "حول تنسيقات عرض PowerPoint. PPT مقابل PPTX. الاختلافات في بايثون"
---

## **ما هو PPT؟**
[**PPT**](https://docs.fileformat.com/presentation/ppt/) هو تنسيق ملف ثنائي، أي أنه من المستحيل عرض محتواه بدون أدوات خاصة. كانت النسخ الأولى من PowerPoint 97-2003 تعمل بتنسيق ملف PPT، ومع ذلك فإن قابلية التوسع فيه محدودة.

## **ما هو PPTX؟**
[**PPTX**](https://docs.fileformat.com/presentation/pptx/) هو تنسيق ملف عرض جديد، يعتمد على معيار Office Open XML (ISO 29500:2008-2016، ECMA-376). PPTX هو مجموعة أرشيفية من ملفات XML ووسائط. تنسيق PPTX سهل التوسيع. على سبيل المثال، من السهل إضافة دعم لنوع مخطط جديد أو نوع شكل، دون تغيير تنسيق PPTX في كل نسخة PowerPoint جديدة. يتم استخدام تنسيق PPTX بدءًا من PowerPoint 2007.

## **PPT مقابل PPTX**
على الرغم من أن PPTX يوفر وظائف أوسع بكثير، لا يزال PPT شائعًا جدًا. تتطلب الحاجة إلى التحويل من PPT إلى PPTX والعكس بشكلٍ كبير.

ومع ذلك، فإن التحويل بين تنسيق PPT القديم وPPTX الجديد هو التحدي الأكثر تعقيدًا بين صيغ Microsoft Office الأخرى. على الرغم من أن مواصفة تنسيق PPT مفتوحة، إلا أنه من الصعب العمل بها. يمكن لـ PowerPoint إنشاء أجزاء خاصة (MetroBlob) في ملفات PPT لتخزين معلومات من PPTX التي لا يدعمها تنسيق PPT ولا يمكن عرضها في نسخ PowerPoint القديمة. يمكن استعادة هذه المعلومات عند تحميل ملف PPT في نسخة PowerPoint الحديثة أو تحويله إلى تنسيق PPTX.

توفر Aspose.Slides واجهة شائعة للعمل مع جميع تنسيقات العروض. يسمح بتحويل PPT إلى PPTX وPPTX إلى PPT بطريقة بسيطة جدًا. تدعم Aspose.Slides تمامًا التحويل من PPT إلى PPTX وتدعم أيضًا التحويل من PPTX إلى PPT مع بعض القيود. نوصي باستخدام تنسيق PPTX كلما كان ذلك ممكنًا.

{{% alert color="primary" %}} 

تحقق من جودة التحويلات من PPT إلى PPTX ومن PPTX إلى PPT باستخدام تطبيق التحويل عبر الإنترنت [**Aspose.Slides Conversion app**](https://products.aspose.app/slides/conversion/).

{{% /alert %}} 

```py
import aspose.slides as slides

# Instantiate a Presentation object that represents a PPTX file
pres = slides.Presentation("PPTtoPPTX.ppt")

# Saving the PPTX presentation to PPTX format
pres.save("PPTtoPPTX_out.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="primary" %}} 
اقرأ المزيد [**كيفية تحويل العروض التقديمية من PPT إلى PPTX**.](/slides/python-net/convert-ppt-to-pptx/)
{{% /alert %}} 