---
title: تحويل PPT إلى PPTX في جافا
linktitle: تحويل PPT إلى PPTX
type: docs
weight: 20
url: /androidjava/convert-ppt-to-pptx/
keywords: "Java تحويل PPT إلى PPTX, PowerPoint PPT إلى PPTX في جافا"
description: "تحويل PowerPoint PPT إلى PPTX في جافا."
---

## **نظرة عامة**

توضح هذه المقالة كيفية تحويل عرض PowerPoint بتنسيق PPT إلى تنسيق PPTX باستخدام جافا ومن خلال تطبيق تحويل PPT إلى PPTX عبر الإنترنت. الموضوع التالي مشمول.

- تحويل PPT إلى PPTX في جافا

## **تحويل PPT إلى PPTX في جافا**

للحصول على شفرة جافا نموذجية لتحويل PPT إلى PPTX، يرجى مراجعة القسم أدناه أي [تحويل PPT إلى PPTX](#convert-ppt-to-pptx). يقوم هذا البرنامج ببساطة بتحميل ملف PPT وحفظه بتنسيق PPTX. من خلال تحديد تنسيقات حفظ مختلفة، يمكنك أيضًا حفظ ملف PPT بعدة تنسيقات أخرى مثل PDF و XPS و ODP و HTML وما إلى ذلك كما هو موضح في هذه المقالات.

- [Java تحويل PPT إلى PDF](https://docs.aspose.com/slides/androidjava/convert-powerpoint-to-pdf/)
- [Java تحويل PPT إلى XPS](https://docs.aspose.com/slides/androidjava/convert-powerpoint-to-xps/)
- [Java تحويل PPT إلى HTML](https://docs.aspose.com/slides/androidjava/convert-powerpoint-to-html/)
- [Java تحويل PPT إلى ODP](https://docs.aspose.com/slides/androidjava/save-presentation/)
- [Java تحويل PPT إلى صورة](https://docs.aspose.com/slides/androidjava/convert-powerpoint-to-png/)

## **حول تحويل PPT إلى PPTX**
تحويل تنسيق PPT القديم إلى PPTX باستخدام Aspose.Slides API. إذا كنت بحاجة إلى تحويل آلاف العروض التقديمية بتنسيق PPT إلى تنسيق PPTX، فإن أفضل حل هو القيام بذلك برمجيًا. مع Aspose.Slides API، من الممكن القيام بذلك في عدد قليل من أسطر الشفرات. تدعم API التوافق الكامل لتحويل عرض PPT إلى PPTX ومن الممكن:

- تحويل الهياكل المعقدة لماستر، وتخطيطات، وشرائح.
- تحويل العروض التقديمية مع الرسوم البيانية.
- تحويل العروض التقديمية مع الأشكال الجماعية، والأشكال التلقائية (مثل المستطيلات والدوائر)، والأشكال ذات الهندسة المخصصة.
- تحويل العروض التقديمية، التي تحتوي على أنماط ملء بالنسيج والصور للأشكال التلقائية.
- تحويل العروض التقديمية التي تحتوي على عناصر نائبة، وإطارات نصية، وحوامل نصية.

{{% alert color="primary" %}} 

تصفح [**تحويل PPT إلى PPTX باستخدام Aspose.Slides**](https://products.aspose.app/slides/conversion/ppt-to-pptx) التطبيق:

[](https://products.aspose.app/slides/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/conversion/ppt-to-pptx)

هذا التطبيق تم بناؤه بناءً على [**Aspose.Slides API**](https://products.aspose.com/slides/androidjava/)، لذا يمكنك رؤية مثال حي عن القدرات الأساسية لتحويل PPT إلى PPTX. تحويل Aspose.Slides هو تطبيق ويب، يتيح لك إسقاط ملف العرض بتنسيق PPT وتحميله محولًا إلى PPTX.

ابحث عن أمثلة تحويل أخرى حية [**Aspose.Slides**](https://products.aspose.app/slides/conversion/).
{{% /alert %}} 

## **تحويل PPT إلى PPTX**
تسهل Aspose.Slides للتطبيقات التي تعمل على أندرويد عبر جافا الآن للمطورين الوصول إلى PPT باستخدام مثيل [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) class وتحويله إلى تنسيق [PPTX](https://docs.fileformat.com/presentation/pptx/). حاليًا، يدعم التحويل الجزئي من [PPT ](https://docs.fileformat.com/presentation/ppt/)إلى PPTX. لمزيد من التفاصيل حول الميزات المدعومة وغير المدعومة في تحويل PPT إلى PPTX، يرجى المتابعة إلى هذه الوثيقة [الرابط](/slides/androidjava/ppt-to-pptx-conversion/).

تقدم Aspose.Slides للتطبيقات التي تعمل على أندرويد عبر جافا فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) التي تمثل ملف عرض تقديمي **PPTX**. يمكن لفئة Presentation الآن أيضًا الوصول إلى **PPT** من خلال Presentation عند إنشاء الكائن. يُظهر المثال التالي كيفية تحويل عرض تقديمي بتنسيق PPT إلى عرض تقديمي بتنسيق PPTX.

```java
// إنشاء كائن Presentation الذي يمثل ملف PPTX
Presentation pres = new Presentation("Aspose.ppt");
try {
// حفظ العرض التقديمي PPTX بتنسيق PPTX
    pres.save("ConvertedAspose.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

|![todo:image_alt_text](http://i.imgur.com/Y9jaUtI.png)|
| :- |
|**الشكل: عرض PPT المصدر**|

قامت شيفرة الكود أعلاه بإنشاء عرض PPTX التالي بعد التحويل

|![todo:image_alt_text](http://i.imgur.com/tBXF3nA.png)|
| :- |
|**الشكل: عرض PPTX الناتج بعد التحويل**|