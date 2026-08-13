---
title: تحويل PPT إلى PPTX في Java
linktitle: PPT إلى PPTX
type: docs
weight: 20
url: /ar/java/convert-ppt-to-pptx/
keywords:
- تحويل PowerPoint
- تحويل العرض التقديمي
- تحويل الشريحة
- تحويل PPT
- PPT إلى PPTX
- حفظ PPT بصيغة PPTX
- تصدير PPT إلى PPTX
- PowerPoint
- العرض التقديمي
- Java
- Aspose.Slides
description: "حول عروض PPT القديمة إلى PPTX الحديثة بسرعة في Java باستخدام Aspose.Slides — دليل واضح، عينات كود مجانية، بدون اعتماد على Microsoft Office."
---
## **نظرة عامة**

توضح هذه المقالة كيفية تحويل عرض PowerPoint بصيغة PPT إلى صيغة PPTX باستخدام Java وتطبيق التحويل عبر الإنترنت من PPT إلى PPTX. الموضوع التالي مغطى.

- تحويل PPT إلى PPTX باستخدام Java

## **تحويل PPT إلى PPTX باستخدام Java**

للحصول على عينة كود Java لتحويل PPT إلى PPTX، يرجى الاطلاع على القسم أدناه أي [Convert PPT to PPTX](#convert-ppt-to-pptx). يقوم بتحميل ملف PPT وحفظه بصيغة PPTX. عن طريق تحديد صيغ حفظ مختلفة، يمكنك أيضًا حفظ ملف PPT إلى العديد من الصيغ الأخرى مثل PDF و XPS و ODP و HTML وغيرها كما نوقش في هذه المقالات.

- [تحويل PPT إلى PDF باستخدام Java](/slides/ar/java/convert-powerpoint-to-pdf/)
- [تحويل PPT إلى XPS باستخدام Java](/slides/ar/java/convert-powerpoint-to-xps/)
- [تحويل PPT إلى HTML باستخدام Java](/slides/ar/java/convert-powerpoint-to-html/)
- [تحويل PPT إلى ODP باستخدام Java](/slides/ar/java/save-presentation/)
- [تحويل PPT إلى PNG باستخدام Java](/slides/ar/java/convert-powerpoint-to-png/)

## **حول تحويل PPT إلى PPTX**

تحويل صيغة PPT القديمة إلى PPTX باستخدام Aspose.Slides API. إذا كنت بحاجة إلى تحويل آلاف العروض التقديمية من PPT إلى صيغة PPTX، فإن أفضل حل هو القيام بذلك برمجياً. باستخدام Aspose.Slides API يمكن القيام بذلك ببضع أسطر من الشيفرة. تدعم الواجهة البرمجية التوافق الكامل لتحويل عرض PPT إلى PPTX ويمكنك:

- تحويل البُنى المعقدة للماسترات، التخطيطات والشرائح.
- تحويل العرض الذي يحتوي على مخططات.
- تحويل العرض الذي يحتوي على مجموعات الأشكال، الأشكال التلقائية (مثل المستطيلات والبيضاوات)، الأشكال ذات الهندسة المخصصة.
- تحويل العرض الذي يحتوي على أنماط تعبئة القوام والصور للأشكال التلقائية.
- تحويل العرض الذي يحتوي على نُسخ احتياطية، إطارات النص وحاملي النص.

{{% alert color="info" %}} 

ألقِ نظرة على تطبيق [**Aspose.Slides PPT to PPTX Conversion**](https://products.aspose.app/slides/ar/conversion/ppt-to-pptx) :

[]((https://products.aspose.app/slides/ar/conversion/ppt-to-pptx))

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/ar/conversion/ppt-to-pptx)

تم بناء هذا التطبيق بناءً على [**Aspose.Slides API**](https://products.aspose.com/slides/ar/java/)، لذلك يمكنك مشاهدة مثال حي لقدرات تحويل PPT إلى PPTX الأساسية. Aspose.Slides Conversion هو تطبيق ويب يتيح إسقاط ملف عرض بصيغة PPT وتحميله بعد تحويله إلى PPTX.

اعثر على أمثلة حية أخرى لـ [**Aspose.Slides Conversion**](https://products.aspose.app/slides/ar/conversion/) .
{{% /alert %}} 

## **تحويل PPT إلى PPTX**

تمكن Aspose.Slides for Java الآن المطورين من الوصول إلى ملفات PPT باستخدام مثيل الفئة [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation) وتحويلها إلى الصيغة المناسبة [PPTX](https://docs.fileformat.com/presentation/pptx/). حاليًا، يدعم التحويل الجزئي من [PPT ](https://docs.fileformat.com/presentation/ppt/) إلى PPTX. لمزيد من التفاصيل حول الميزات المدعومة وغير المدعومة في تحويل PPT إلى PPTX، يرجى الانتقال إلى وثائق [الرابط](/slides/ar/java/ppt-to-pptx-conversion/).

Aspose.Slides for Java يقدم الفئة [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation) التي تمثل ملف عرض **PPTX**. يمكن الآن للفئة Presentation أيضاً الوصول إلى **PPT** عند إنشاء الكائن. المثال التالي يوضح كيفية تحويل عرض PPT إلى عرض PPTX.

```java
import com.aspose.slides.*;

// إنشاء كائن Presentation يمثل ملف PPT
Presentation pres = new Presentation("Aspose.ppt");
try {
// حفظ عرض PPT بصيغة PPTX
    pres.save("ConvertedAspose.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

|![todo:image_alt_text](http://i.imgur.com/Y9jaUtI.png)|
| :- |
|**الشكل : عرض PPT الأصلي**|

الكود أعلاه ينتج ملف عرض PPTX التالي بعد التحويل

|![todo:image_alt_text](http://i.imgur.com/tBXF3nA.png)|
| :- |
|**الشكل: عرض PPTX المُولد بعد التحويل**|

## **الأسئلة الشائعة**

### ما هو الفرق بين صيغ PPT و PPTX؟

PPT هو صيغة الملف الثنائي القديمة المستخدمة من قبل Microsoft PowerPoint، بينما PPTX هو الصيغة المستندة إلى XML التي تم تقديمها مع Microsoft Office 2007. ملفات PPTX تقدم أداءً أفضل، حجم ملف أصغر، وتحسينات في استعادة البيانات.

### هل يدعم Aspose.Slides التحويل الدفعي لعدة ملفات PPT إلى PPTX؟

نعم، يمكنك استخدام Aspose.Slides داخل حلقة لتحويل عدة ملفات PPT إلى PPTX برمجياً، مما يجعلها مناسبة لسيناريوهات التحويل الدفعي.

### هل سيتم الحفاظ على المحتوى والتنسيق بعد التحويل؟

يحافظ Aspose.Slides على دقة عالية في تحويل العروض. يتم الحفاظ على تخطيطات الشرائح، الرسوم المتحركة، الأشكال، المخططات، وعناصر التصميم الأخرى أثناء تحويل PPT إلى PPTX.

### هل يمكنني تحويل صيغ أخرى مثل PDF أو HTML من ملفات PPT؟

نعم، يدعم Aspose.Slides تحويل ملفات PPT إلى [multiple formats](https://reference.aspose.com/slides/ar/java/com.aspose.slides/saveformat/)، بما في ذلك PDF و XPS و HTML و ODP وصيغ الصور مثل PNG و JPEG.

### هل يمكن تحويل PPT إلى PPTX دون تثبيت Microsoft PowerPoint؟

نعم، Aspose.Slides هو API مستقل لا يتطلب Microsoft PowerPoint أو أي برنامج تابع لجهات خارجية لإجراء التحويل.

### هل توجد أداة عبر الإنترنت متاحة لتحويل PPT إلى PPTX؟

نعم، يمكنك استخدام تطبيق الويب المجاني [Aspose.Slides PPT to PPTX Converter](https://products.aspose.app/slides/ar/conversion/ppt-to-pptx) لإجراء التحويل مباشرةً في متصفحك دون كتابة أي كود.