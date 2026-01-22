---
title: تحويل PPT إلى PPTX في Java
linktitle: PPT إلى PPTX
type: docs
weight: 20
url: /ar/java/convert-ppt-to-pptx/
keywords:
- تحويل PowerPoint
- تحويل عرض تقديمي
- تحويل شريحة
- تحويل PPT
- PPT إلى PPTX
- حفظ PPT كـ PPTX
- تصدير PPT إلى PPTX
- PowerPoint
- عرض تقديمي
- Java
- Aspose.Slides
description: "تحويل عروض PowerPoint القديمة إلى PPTX الحديثة بسرعة في Java باستخدام Aspose.Slides — دليل واضح، أمثلة شفرة مجانية، دون اعتماد على Microsoft Office."
---

## **نظرة عامة**

تشرح هذه المقالة كيفية تحويل عرض باوربوينت بتنسيق PPT إلى تنسيق PPTX باستخدام جافا ومع تطبيق التحويل عبر الإنترنت من PPT إلى PPTX. الموضوع التالي مغطى.

- تحويل PPT إلى PPTX في جافا

## **تحويل PPT إلى PPTX في جافا**

للحصول على مثال كود جافا لتحويل PPT إلى PPTX، يرجى الاطلاع على القسم أدناه أي [Convert PPT to PPTX](#convert-ppt-to-pptx). يقوم بتحميل ملف PPT وحفظه بتنسيق PPTX. من خلال تحديد تنسيقات حفظ مختلفة، يمكنك أيضًا حفظ ملف PPT بالعديد من التنسيقات الأخرى مثل PDF، XPS، ODP، HTML، إلخ كما نوقش في هذه المقالات.

- [تحويل PPT إلى PDF في جافا](/slides/ar/java/convert-powerpoint-to-pdf/)
- [تحويل PPT إلى XPS في جافا](/slides/ar/java/convert-powerpoint-to-xps/)
- [تحويل PPT إلى HTML في جافا](/slides/ar/java/convert-powerpoint-to-html/)
- [تحويل PPT إلى ODP في جافا](/slides/ar/java/save-presentation/)
- [تحويل PPT إلى PNG في جافا](/slides/ar/java/convert-powerpoint-to-png/)

## **حول تحويل PPT إلى PPTX**

تحويل تنسيق PPT القديم إلى PPTX باستخدام Aspose.Slides API. إذا كنت بحاجة إلى تحويل آلاف عروض PPT إلى تنسيق PPTX، فإن أفضل حل هو القيام بذلك برمجيًا. باستخدام Aspose.Slides API يمكن القيام بذلك ببضع أسطر من الكود فقط. تدعم API توافقًا كاملًا لتحويل عرض PPT إلى PPTX ومن الممكن:

- تحويل البُنى المعقدة للماستر، التخطيطات والشرائح.
- تحويل عرض يحتوي على مخططات.
- تحويل عرض يحتوي على أشكال مجموعة، الأشكال التلقائية (مثل المستطيلات والبيضات)، الأشكال ذات الهندسة المخصصة.
- تحويل عرض يحتوي على أنسجة وأنماط تعبئة الصور للأشكال التلقائية.
- تحويل عرض يحتوي على نائبات، إطارات النص وحاملي النص.

{{% alert color="primary" %}} 

ألق نظرة على تطبيق [**Aspose.Slides PPT to PPTX Conversion**](https://products.aspose.app/slides/conversion/ppt-to-pptx) :

[](https://products.aspose.app/slides/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/conversion/ppt-to-pptx)

تم بناء هذا التطبيق بناءً على [**Aspose.Slides API**](https://products.aspose.com/slides/java/)، لذا قد ترى مثالًا حيًا على قدرات تحويل PPT إلى PPTX الأساسية. تحويل Aspose.Slides هو تطبيق ويب يتيح سحب ملف عرض بتنسيق PPT وتنزيله محولًا إلى PPTX.

اعثر على أمثلة أخرى حية لـ [**Aspose.Slides Conversion**](https://products.aspose.app/slides/conversion/) .

{{% /alert %}} 

## **تحويل PPT إلى PPTX**

يسهل Aspose.Slides for Java الآن للمطورين الوصول إلى PPT باستخدام مثيل الفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) وتحويله إلى التنسيق [PPTX](https://docs.fileformat.com/presentation/pptx/). حاليًا، يدعم تحويلًا جزئيًا من [PPT](https://docs.fileformat.com/presentation/ppt/) إلى PPTX. للحصول على مزيد من التفاصيل حول الميزات المدعومة وغير المدعومة في تحويل PPT إلى PPTX، يرجى الانتقال إلى وثائق هذا الرابط [link](/slides/ar/java/ppt-to-pptx-conversion/).

توفر Aspose.Slides for Java الفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) التي تمثل ملف عرض **PPTX**. يمكن الآن لفئة Presentation أيضًا الوصول إلى **PPT** عبر Presentation عند إنشاء الكائن. يوضح المثال التالي كيفية تحويل عرض PPT إلى عرض PPTX Presentation.
```java
// إنشاء كائن Presentation يمثل ملف PPTX
Presentation pres = new Presentation("Aspose.ppt");
try {
// حفظ عرض PPTX إلى صيغة PPTX
    pres.save("ConvertedAspose.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


|![todo:image_alt_text](http://i.imgur.com/Y9jaUtI.png)|
| :- |
|**الشكل : عرض PPT الأصلي**|

الكود أعلاه يولد عرض PPTX التالي بعد التحويل

|![todo:image_alt_text](http://i.imgur.com/tBXF3nA.png)|
| :- |
|**الشكل: عرض PPTX المُولد بعد التحويل**|

## **الأسئلة الشائعة**

**ما الفرق بين صيغ PPT و PPTX؟**

PPT هو صيغة الملف الثنائي القديمة المستخدمة بواسطة Microsoft PowerPoint، بينما PPTX هو الصيغة القائمة على XML التي تم تقديمها مع Microsoft Office 2007. توفر ملفات PPTX أداءً أفضل، حجم ملف أصغر، وتحسين استعادة البيانات.

**هل يدعم Aspose.Slides التحويل الجماعي لملفات PPT المتعددة إلى PPTX؟**

نعم، يمكنك استخدام Aspose.Slides في حلقة لتحويل ملفات PPT متعددة إلى PPTX برمجيًا، مما يجعله مناسبًا لسيناريوهات التحويل الجماعي.

**هل سيتم الحفاظ على المحتوى والتنسيق بعد التحويل؟**

يحافظ Aspose.Slides على دقة عالية في تحويل العروض. تُحفظ تخطيطات الشرائح، الرسوم المتحركة، الأشكال، المخططات، وعناصر التصميم الأخرى أثناء تحويل PPT إلى PPTX.

**هل يمكنني تحويل صيغ أخرى مثل PDF أو HTML من ملفات PPT؟**

نعم، يدعم Aspose.Slides تحويل ملفات PPT إلى [multiple formats](https://reference.aspose.com/slides/java/com.aspose.slides/saveformat/)، بما في ذلك PDF، XPS، HTML، ODP، وصيغ الصور مثل PNG و JPEG.

**هل من الممكن تحويل PPT إلى PPTX دون تثبيت Microsoft PowerPoint؟**

نعم، Aspose.Slides هو API مستقل ولا يتطلب Microsoft PowerPoint أو أي برنامج طرف ثالث لإجراء التحويل.

**هل يوجد أداة على الإنترنت لتحويل PPT إلى PPTX؟**

نعم، يمكنك استخدام تطبيق الويب المجاني [Aspose.Slides PPT to PPTX Converter](https://products.aspose.app/slides/conversion/ppt-to-pptx) لإجراء التحويل مباشرة في المتصفح دون كتابة أي شفرة.