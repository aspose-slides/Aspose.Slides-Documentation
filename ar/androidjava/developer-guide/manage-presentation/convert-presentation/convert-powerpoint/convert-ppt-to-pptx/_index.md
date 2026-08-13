---
title: تحويل PPT إلى PPTX على Android
linktitle: PPT إلى PPTX
type: docs
weight: 20
url: /ar/androidjava/convert-ppt-to-pptx/
keywords:
- تحويل PowerPoint
- تحويل العرض التقديمي
- تحويل الشريحة
- تحويل PPT
- PPT إلى PPTX
- حفظ PPT كـ PPTX
- تصدير PPT إلى PPTX
- PowerPoint
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "تحويل عروض PPT القديمة إلى PPTX الحديثة بسرعة باستخدام Java و Aspose.Slides لنظام Android — دليل واضح، أمثلة شفرة مجانية، بدون اعتماد على Microsoft Office."
---
## **نظرة عامة**

تشرح هذه المقالة كيفية تحويل عرض PowerPoint بتنسيق PPT إلى تنسيق PPTX باستخدام Java ومع تطبيق تحويل PPT إلى PPTX عبر الإنترنت. يتم تغطية الموضوع التالي.

- تحويل PPT إلى PPTX باستخدام Java

## **تحويل PPT إلى PPTX على Android**

للحصول على عينة كود Java لتحويل PPT إلى PPTX، يرجى الاطلاع على القسم أدناه أي [Convert PPT to PPTX](#convert-ppt-to-pptx). يقوم بتحميل ملف PPT وحفظه بتنسيق PPTX. من خلال تحديد تنسيقات حفظ مختلفة، يمكنك أيضًا حفظ ملف PPT إلى تنسيقات أخرى مثل PDF، XPS، ODP، HTML وغيرها كما نوقش في هذه المقالات.

- [تحويل PPT إلى PDF على Android](/slides/ar/androidjava/convert-powerpoint-to-pdf/)
- [تحويل PPT إلى XPS على Android](/slides/ar/androidjava/convert-powerpoint-to-xps/)
- [تحويل PPT إلى HTML على Android](/slides/ar/androidjava/convert-powerpoint-to-html/)
- [تحويل PPT إلى ODP على Android](/slides/ar/androidjava/save-presentation/)
- [تحويل PPT إلى PNG على Android](/slides/ar/androidjava/convert-powerpoint-to-png/)

## **حول تحويل PPT إلى PPTX**

قم بتحويل تنسيق PPT القديم إلى PPTX باستخدام Aspose.Slides API. إذا كنت تحتاج إلى تحويل آلاف عروض PPT إلى تنسيق PPTX، فإن أفضل حل هو القيام بذلك برمجيًا. باستخدام Aspose.Slides API يمكن القيام بذلك ببضع أسطر من الكود فقط. يدعم الـ API توافقًا كاملاً لتحويل عرض PPT إلى PPTX ومن الممكن:

- تحويل الهياكل المعقدة للماستر، التخطيطات والشرائح.
- تحويل عرض يحتوي على مخططات.
- تحويل عرض يحتوي على أشكال مجموعة، أشكال تلقائية (مثل المستطيلات والبيضات)، أشكال ذات هندسة مخصصة.
- تحويل عرض يحتوي على نسيج وصور كأنماط تعبئة للأشكال التلقائية.
- تحويل عرض يحتوي على نائبات، إطارات نصية وحاملات نص.

{{% alert color="info" %}} 

ألقِ نظرة على تطبيق [**Aspose.Slides PPT to PPTX Conversion**](https://products.aspose.app/slides/ar/conversion/ppt-to-pptx) :

[](https://products.aspose.app/slides/ar/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/ar/conversion/ppt-to-pptx)

تم بناء هذا التطبيق استنادًا إلى [**Aspose.Slides API**](https://products.aspose.com/slides/ar/androidjava/)، بحيث يمكنك رؤية مثال حي على قدرات تحويل PPT إلى PPTX الأساسية. Aspose.Slides Conversion هو تطبيق ويب يتيح سحب ملف عرض بتنسيق PPT وإمكان تنزيله بعد تحويله إلى PPTX.

ابحث عن أمثلة أخرى حية لـ [**Aspose.Slides Conversion**](https://products.aspose.app/slides/ar/conversion/) .

{{% /alert %}} 

## **تحويل PPT إلى PPTX**

Aspose.Slides لنظام Android عبر Java يسهل الآن على المطورين الوصول إلى PPT باستخدام فئة [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation) وتحويلها إلى تنسيق [PPTX](https://docs.fileformat.com/presentation/pptx/). حاليًا، يدعم تحويلًا جزئيًا من [PPT ](https://docs.fileformat.com/presentation/ppt/)to PPTX.

Aspose.Slides لنظام Android عبر Java توفر فئة [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation) التي تمثل ملف عرض **PPTX**. يمكن الآن لفئة Presentation أيضًا الوصول إلى **PPT** عبر Presentation عند إنشاء الكائن. يوضح المثال التالي كيفية تحويل عرض PPT إلى عرض PPTX.

```java
import com.aspose.slides.*;

// إنشاء كائن Presentation يمثل ملف PPT
Presentation pres = new Presentation("Aspose.ppt");
try {
// حفظ عرض PPT بتنسيق PPTX
    pres.save("ConvertedAspose.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

|![todo:image_alt_text](http://i.imgur.com/Y9jaUtI.png)|
| :- |
|**الشكل : عرض PPT المصدر**|

الكود أعلاه يولد عرض PPTX التالي بعد التحويل

|![todo:image_alt_text](http://i.imgur.com/tBXF3nA.png)|
| :- |
|**الشكل: عرض PPTX المُولد بعد التحويل**|

## **الأسئلة المتكررة**

### ما الفرق بين تنسيقي PPT و PPTX؟

PPT هو تنسيق الملف الثنائي القديم الذي يستخدمه Microsoft PowerPoint، بينما PPTX هو التنسيق القائم على XML الأحدث الذي تم تقديمه مع Microsoft Office 2007. ملفات PPTX توفر أداءً أفضل، حجم ملف أصغر، وتحسنًا في استعادة البيانات.

### هل يدعم Aspose.Slides التحويل الجماعي لعدة ملفات PPT إلى PPTX؟

نعم، يمكنك استخدام Aspose.Slides داخل حلقة لتحويل عدة ملفات PPT إلى PPTX برمجيًا، مما يجعلها مناسبة لسيناريوهات التحويل الجماعي.

### هل سيتم الحفاظ على المحتوى والتنسيق بعد التحويل؟

يحافظ Aspose.Slides على دقة عالية عند تحويل العروض. تُحافظ تخطيطات الشرائح، الرسوم المتحركة، الأشكال، المخططات، وغيرها من عناصر التصميم أثناء تحويل PPT إلى PPTX.

### هل يمكنني تحويل صيغ أخرى مثل PDF أو HTML من ملفات PPT؟

نعم، يدعم Aspose.Slides تحويل ملفات PPT إلى [multiple formats](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/saveformat/)، بما في ذلك PDF، XPS، HTML، ODP، وصيغ الصور مثل PNG و JPEG.

### هل يمكن تحويل PPT إلى PPTX دون تثبيت Microsoft PowerPoint؟

نعم، Aspose.Slides هو API مستقل ولا يتطلب Microsoft PowerPoint أو أي برنامج طرف ثالث لإجراء التحويل.

### هل يوجد أداة عبر الإنترنت متاحة لتحويل PPT إلى PPTX؟

نعم، يمكنك استخدام تطبيق الويب المجاني [Aspose.Slides PPT to PPTX Converter](https://products.aspose.app/slides/ar/conversion/ppt-to-pptx) لإجراء التحويل مباشرةً في المتصفح دون كتابة أي كود.