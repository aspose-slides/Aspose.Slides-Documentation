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
description: "تحويل عروض PPT القديمة إلى PPTX الحديثة بسرعة في Java باستخدام Aspose.Slides — دليل واضح، عينات شفرة مجانية، دون الاعتماد على Microsoft Office."
---

## **نظرة عامة**

يشرح هذا المقال كيفية تحويل عرض PowerPoint بتنسيق PPT إلى تنسيق PPTX باستخدام Java ومع تطبيق التحويل عبر الإنترنت من PPT إلى PPTX. المواضيع التالية مغطاة.

- تحويل PPT إلى PPTX باستخدام Java

## **تحويل PPT إلى PPTX باستخدام Java**

للحصول على عينة كود Java لتحويل PPT إلى PPTX، يرجى الاطلاع على القسم أدناه وهو [Convert PPT to PPTX](#convert-ppt-to-pptx). يقوم فقط بتحميل ملف PPT وحفظه بتنسيق PPTX. من خلال تحديد صيغ حفظ مختلفة، يمكنك أيضًا حفظ ملف PPT إلى العديد من الصيغ الأخرى مثل PDF و XPS و ODP و HTML وغيرها كما هو مذكور في هذه المقالات.

- [تحويل PPT إلى PDF باستخدام Java](https://docs.aspose.com/slides/java/convert-powerpoint-to-pdf/)
- [تحويل PPT إلى XPS باستخدام Java](https://docs.aspose.com/slides/java/convert-powerpoint-to-xps/)
- [تحويل PPT إلى HTML باستخدام Java](https://docs.aspose.com/slides/java/convert-powerpoint-to-html/)
- [تحويل PPT إلى ODP باستخدام Java](https://docs.aspose.com/slides/java/save-presentation/)
- [تحويل PPT إلى صورة باستخدام Java](https://docs.aspose.com/slides/java/convert-powerpoint-to-png/)

## **حول تحويل PPT إلى PPTX**
قم بتحويل تنسيق PPT القديم إلى PPTX باستخدام Aspose.Slides API. إذا كنت بحاجة إلى تحويل آلاف عروض PPT إلى تنسيق PPTX، فإن أفضل حل هو القيام بذلك برمجياً. باستخدام Aspose.Slides API يمكن القيام بذلك ببضع أسطر من الشيفرة فقط. تدعم الواجهة برمجية التطبيقات (API) التوافق الكامل لتحويل عرض PPT إلى PPTX ومن الممكن:

- تحويل الهياكل المعقدة للماستر، التخطيطات والشرائح.
- تحويل العرض الذي يحتوي على مخططات.
- تحويل العرض الذي يحتوي على مجموعات أشكال، الأشكال التلقائية (مثل المستطيلات والقطع الإهليلجية)، الأشكال ذات الهندسة المخصصة.
- تحويل العرض الذي يحتوي على أنماط تعبئة بالصور والملمس للأشكال التلقائية.
- تحويل العرض الذي يحتوي على عناصر نائبة، إطارات نصية وحاملات نص.

{{% alert color="primary" %}} 
ألقِ نظرة على تطبيق [**Aspose.Slides PPT to PPTX Conversion**](https://products.aspose.app/slides/conversion/ppt-to-pptx) :

[](https://products.aspose.app/slides/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/conversion/ppt-to-pptx)

تم بناء هذا التطبيق استنادًا إلى [**Aspose.Slides API**](https://products.aspose.com/slides/java/)، لذا يمكنك رؤية مثال حي على قدرات تحويل PPT إلى PPTX الأساسية. Aspose.Slides Conversion هو تطبيق ويب يتيح سحب ملف عرض بصيغة PPT وتحميله بعد تحويله إلى PPTX.

ابحث عن أمثلة أخرى حية لـ [**Aspose.Slides Conversion**](https://products.aspose.app/slides/conversion/) .
{{% /alert %}} 

## **تحويل PPT إلى PPTX**
يسهل Aspose.Slides for Java الآن للمطورين الوصول إلى PPT باستخدام مثال فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) وتحويله إلى تنسيق [PPTX](https://docs.fileformat.com/presentation/pptx/) المناسب. حاليًا، يدعم التحويل الجزئي من [PPT ](https://docs.fileformat.com/presentation/ppt/) إلى PPTX. لمزيد من التفاصيل حول الميزات المدعومة وغير المدعومة في تحويل PPT إلى PPTX، يرجى الانتقال إلى وثائق هذا [link](/slides/ar/java/ppt-to-pptx-conversion/).

تقدم Aspose.Slides for Java فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) التي تمثل ملف عرض **PPTX**. يمكن الآن للفئة Presentation أيضًا الوصول إلى **PPT** عندما يتم إنشاء الكائن. يوضح المثال التالي كيفية تحويل عرض PPT إلى عرض PPTX.
```java
// إنشاء كائن Presentation يمثل ملف PPTX
Presentation pres = new Presentation("Aspose.ppt");
try {
    // حفظ العرض بصيغة PPTX
    pres.save("ConvertedAspose.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


|![todo:image_alt_text](http://i.imgur.com/Y9jaUtI.png)|
| :- |
|**شكل : عرض PPT المصدر**|

القطعة البرمجية أعلاه أنشأت عرض PPTX التالي بعد التحويل

|![todo:image_alt_text](http://i.imgur.com/tBXF3nA.png)|
| :- |
|**شكل : عرض PPTX المولّد بعد التحويل**|

## **الأسئلة الشائعة**

**ما الفرق بين تنسيقي PPT و PPTX؟**

PPT هو تنسيق الملف الثنائي الأقدم الذي تستخدمه Microsoft PowerPoint، بينما PPTX هو التنسيق القائم على XML الأحدث الذي تم تقديمه مع Microsoft Office 2007. تقدم ملفات PPTX أداءً أفضل، حجم ملف أصغر، وتحسين في استعادة البيانات.

**هل يدعم Aspose.Slides التحويل الجماعي لعدة ملفات PPT إلى PPTX؟**

نعم، يمكنك استخدام Aspose.Slides داخل حلقة لتحويل عدة ملفات PPT إلى PPTX برمجياً، مما يجعله مناسبًا لسيناريوهات التحويل الجماعي.

**هل سيتم الحفاظ على المحتوى والتنسيق بعد التحويل؟**

يحافظ Aspose.Slides على دقة عالية أثناء تحويل العروض. يتم الحفاظ على تخطيطات الشرائح، الرسوم المتحركة، الأشكال، المخططات، والعناصر التصميمية الأخرى أثناء تحويل PPT إلى PPTX.

**هل يمكنني تحويل صيغ أخرى مثل PDF أو HTML من ملفات PPT؟**

نعم، يدعم Aspose.Slides تحويل ملفات PPT إلى [multiple formats](https://reference.aspose.com/slides/java/com.aspose.slides/saveformat/)، بما في ذلك PDF و XPS و HTML و ODP، وصيغ الصور مثل PNG و JPEG.

**هل من الممكن تحويل PPT إلى PPTX دون تثبيت Microsoft PowerPoint؟**

نعم، Aspose.Slides هي واجهة برمجة تطبيقات مستقلة ولا تتطلب Microsoft PowerPoint أو أي برنامج طرف ثالث لإجراء التحويل.

**هل هناك أداة عبر الإنترنت متوفرة لتحويل PPT إلى PPTX؟**

نعم، يمكنك استخدام تطبيق الويب المجاني [Aspose.Slides PPT to PPTX Converter](https://products.aspose.app/slides/conversion/ppt-to-pptx) لإجراء التحويل مباشرةً في متصفحك دون كتابة أي كود.