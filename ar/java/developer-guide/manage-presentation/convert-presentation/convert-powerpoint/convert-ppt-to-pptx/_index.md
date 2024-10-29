---
title: تحويل PPT إلى PPTX في Java
linktitle: تحويل PPT إلى PPTX
type: docs
weight: 20
url: /ar/java/convert-ppt-to-pptx/
keywords: "Java تحويل PPT إلى PPTX, PowerPoint PPT إلى PPTX في Java"
description: "تحويل PowerPoint PPT إلى PPTX في Java."
---

## **نظرة عامة**

تشرح هذه المقالة كيفية تحويل عرض PowerPoint بصيغة PPT إلى صيغة PPTX باستخدام Java ومن خلال تطبيق تحويل PPT إلى PPTX عبر الإنترنت. الموضوع التالي مُغطى.

- تحويل PPT إلى PPTX في Java

## **Java تحويل PPT إلى PPTX**

للحصول على رمز Java عينة لتحويل PPT إلى PPTX، يرجى الاطلاع على القسم أدناه أي [تحويل PPT إلى PPTX](#convert-ppt-to-pptx). إنه يحمل ملف PPT فقط ويحفظه بصيغة PPTX. من خلال تحديد تنسيقات حفظ مختلفة، يمكنك أيضًا حفظ ملف PPT إلى العديد من التنسيقات الأخرى مثل PDF وXPS وODP وHTML وما إلى ذلك، كما تم مناقشته في هذه المقالات.

- [Java تحويل PPT إلى PDF](https://docs.aspose.com/slides/java/convert-powerpoint-to-pdf/)
- [Java تحويل PPT إلى XPS](https://docs.aspose.com/slides/java/convert-powerpoint-to-xps/)
- [Java تحويل PPT إلى HTML](https://docs.aspose.com/slides/java/convert-powerpoint-to-html/)
- [Java تحويل PPT إلى ODP](https://docs.aspose.com/slides/java/save-presentation/)
- [Java تحويل PPT إلى صورة](https://docs.aspose.com/slides/java/convert-powerpoint-to-png/)

## **حول تحويل PPT إلى PPTX**
تحويل صيغة PPT القديمة إلى PPTX باستخدام واجهة برمجة التطبيقات Aspose.Slides. إذا كنت بحاجة إلى تحويل آلاف عروض PPT إلى صيغة PPTX، فإن أفضل حل هو القيام بذلك برمجيًا. مع واجهة برمجة التطبيقات Aspose.Slides، من الممكن القيام بذلك فقط في عدة أسطر من التعليمات البرمجية. تدعم واجهة برمجة التطبيقات التوافق الكامل لتحويل عرض PPT إلى PPTX ومن الممكن:

- تحويل الهياكل المعقدة من الماسترات والتخطيطات والشرائح.
- تحويل العرض الذي يحتوي على المخططات.
- تحويل العرض الذي يحتوي على أشكال جماعية، وأشكال تلقائية (مثل المستطيلات والدوائر)، وأشكال ذات هندسة مخصصة.
- تحويل العرض الذي يحتوي على أنماط تعبئة بالملمس والصور للأشكال التلقائية.
- تحويل العرض الذي يحتوي على عناصر نائب، وإطارات نص، وحوامل نص.

{{% alert color="primary" %}} 

انظر إلى تطبيق [**تحويل Aspose.Slides PPT إلى PPTX**](https://products.aspose.app/slides/conversion/ppt-to-pptx):

[](https://products.aspose.app/slides/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/conversion/ppt-to-pptx)

تم بناء هذا التطبيق استنادًا إلى [**واجهة برمجة التطبيقات Aspose.Slides**](https://products.aspose.com/slides/java/)، لذا يمكنك رؤية مثال حي على القدرات الأساسية لتحويل PPT إلى PPTX. تحويل Aspose.Slides هو تطبيق ويب، والذي يسمح بسحب ملف العرض بصيغة PPT وتحميله بعد تحويله إلى PPTX.

ابحث عن أمثلة أخرى حية على [**تحويل Aspose.Slides**](https://products.aspose.app/slides/conversion/).
{{% /alert %}} 

## **تحويل PPT إلى PPTX**
تُسهل Aspose.Slides لـ Java الآن للمطورين الوصول إلى PPT باستخدام مثيل [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) وتحويله إلى صيغة [PPTX](https://docs.fileformat.com/presentation/pptx/). حاليًا، تدعم التحويل الجزئي من [PPT](https://docs.fileformat.com/presentation/ppt/) إلى PPTX. لمزيد من التفاصيل حول الميزات المدعومة وغير المدعومة في تحويل PPT إلى PPTX، يرجى الانتقال إلى وثائق [الرابط](/slides/ar/java/ppt-to-pptx-conversion/).

تقدم Aspose.Slides لـ Java فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) التي تمثل ملف عرض **PPTX**. يمكن الآن أيضًا الوصول إلى **PPT** عبر Presentation عند إنشاء الكائن. يُظهر المثال التالي كيفية تحويل عرض PPT إلى عرض PPTX.

```java
// قم بإنشاء كائن Presentation يمثل ملف PPTX
Presentation pres = new Presentation("Aspose.ppt");
try {
// حفظ عرض PPTX بصيغة PPTX
    pres.save("ConvertedAspose.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

|![todo:image_alt_text](http://i.imgur.com/Y9jaUtI.png)|
| :- |
|**الشكل: عرض PPT المصدر**|

أنشأ مقتطف الشيفرة أعلاه عرض PPTX التالي بعد التحويل

|![todo:image_alt_text](http://i.imgur.com/tBXF3nA.png)|
| :- |
|**الشكل: عرض PPTX المنتج بعد التحويل**|