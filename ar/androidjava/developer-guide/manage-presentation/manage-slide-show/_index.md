---
title: إدارة العرض المتحرك على Android
linktitle: العرض المتحرك
type: docs
weight: 90
url: /ar/androidjava/manage-slide-show/
keywords:
- نوع العرض
- مُقدَّم من المتحدث
- متصفح من قبل فرد
- متصفح في كشك
- خيارات العرض
- تكرار مستمر
- عرض بدون رواية
- عرض بدون رسوم متحركة
- لون القلم
- عرض الشرائح
- عرض مخصص
- تقديم الشرائح
- يدويًا
- استخدام التوقيتات
- PowerPoint
- OpenDocument
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "تعلم كيفية إدارة العروض المتحركة في Aspose.Slides لنظام Android عبر Java. سيطر على انتقالات الشرائح، التوقيتات والمزيد عبر صيغ PPT و PPTX و ODP بسهولة."
---

في Microsoft PowerPoint، تُعَدُّ إعدادات **العرض المتحرك** أداة أساسية لإعداد وتقديم عروض احترافية. إحدى أهم الميزات في هذا القسم هي **إعداد العرض**، التي تتيح لك تخصيص عرضك وفقًا لظروف وجمهور معينين، مما يضمن المرونة والراحة. باستخدام هذه الميزة، يمكنك اختيار نوع العرض (مثل تقديمه بواسطة متحدث، أو تصفحه من قبل فرد، أو تصفحه في كشك)، وتمكين أو تعطيل التكرار، واختيار شرائح معينة للعرض، واستخدام توقيتات. هذه الخطوة في الإعداد ضرورية لجعل عرضك أكثر فعالية واحترافية.

`getSlideShowSettings` هي طريقة من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) تُرجِع كائنًا من النوع [SlideShowSettings](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slideshowsettings/)، والذي يتيح لك إدارة إعدادات العرض المتحرك في عرض PowerPoint. في هذه المقالة، سنستكشف كيفية استخدام هذه الطريقة لتكوين والتحكم في جوانب مختلفة من إعدادات العرض المتحرك.

## **تحديد نوع العرض**

`SlideShowSettings.setSlideShowType` يحدد نوع العرض المتحرك، والذي يمكن أن يكون مثالًا من الفئات التالية: [PresentedBySpeaker](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentedbyspeaker/)، [BrowsedByIndividual](https://reference.aspose.com/slides/androidjava/com.aspose.slides/browsedbyindividual/)، أو [BrowsedAtKiosk](https://reference.aspose.com/slides/androidjava/com.aspose.slides/browsedatkiosk/). استخدام هذه الطريقة يتيح لك تعديل العرض لتناسب سيناريوهات الاستخدام المختلفة، مثل الأكشاك الآلية أو العروض اليدوية.

المثال البرمجي أدناه ينشئ عرضًا جديدًا ويضبط نوع العرض على "تصفحه فرديًا" دون عرض شريط التمرير.
```java
Presentation presentation = new Presentation();

BrowsedByIndividual showType = new BrowsedByIndividual();
showType.setShowScrollbar(false);

presentation.getSlideShowSettings().setSlideShowType(showType);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```


## **تمكين خيارات العرض**

`SlideShowSettings.setLoop` يحدد ما إذا كان يجب أن يتكرر العرض المتحرك في حلقة حتى يتم إيقافه يدويًا. هذا مفيد للعروض الآلية التي تحتاج إلى التشغيل المستمر. `SlideShowSettings.setShowNarration` يحدد ما إذا كان يجب تشغيل السرد الصوتي أثناء العرض المتحرك. وهو مفيد للعروض الآلية التي تحتوي على إرشاد صوتي للجمهور. `SlideShowSettings.setShowAnimation` يحدد ما إذا كان يجب تشغيل الرسوم المتحركة المضافة إلى كائنات الشرائح. وهذا مفيد لتوفير التأثير البصري الكامل للعرض.

المثال البرمجي التالي ينشئ عرضًا جديدًا ويجعل العرض المتحرك يتكرر.
```java
Presentation presentation = new Presentation();

presentation.getSlideShowSettings().setLoop(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```


## **تحديد الشرائح للعرض**

طريقة `SlideShowSettings.setSlides` تتيح لك اختيار نطاق من الشرائح ليتم عرضها أثناء العرض. هذا مفيد عندما تحتاج إلى عرض جزء فقط من العرض بدلاً من جميع الشرائح. المثال البرمجي التالي ينشئ عرضًا جديدًا ويضبط نطاق الشرائح للعرض من الشريحة `2` إلى الشريحة `9`.
```java
Presentation presentation = new Presentation();

SlidesRange slideRange = new SlidesRange();
slideRange.setStart(2);
slideRange.setEnd(9);

presentation.getSlideShowSettings().setSlides(slideRange);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```


## **استخدام توقيتات الشرائح**

طريقة `SlideShowSettings.setUseTimings` تتيح لك تمكين أو تعطيل استخدام توقيتات محددة مسبقًا لكل شريحة. هذا مفيد لعرض الشرائح تلقائيًا بمدة عرض محددة مسبقًا. المثال البرمجي أدناه ينشئ عرضًا جديدًا ويعطل استخدام التوقيتات.
```java
Presentation presentation = new Presentation();

presentation.getSlideShowSettings().setUseTimings(false);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```


## **إظهار عناصر تحكم الوسائط**

طريقة `SlideShowSettings.setShowMediaControls` تحدد ما إذا كان ينبغي عرض عناصر تحكم الوسائط (مثل التشغيل، الإيقاف المؤقت، والإيقاف) أثناء العرض المتحرك عندما يتم تشغيل محتوى وسائط متعددة (مثل الفيديو أو الصوت). هذا مفيد عندما تريد تقديم تحكم للمقدم على تشغيل الوسائط أثناء العرض.

المثال البرمجي التالي ينشئ عرضًا جديدًا ويُمكّن عرض عناصر تحكم الوسائط.
```java
Presentation presentation = new Presentation();

presentation.getSlideShowSettings().setShowMediaControls(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```


## **الأسئلة المتكررة**

**هل يمكنني حفظ عرض تقديمي بحيث يفتح مباشرةً في وضع العرض المتحرك؟**

نعم. احفظ الملف كـ PPSX أو PPSM؛ هذه الصيغ تُشغَل مباشرةً في وضع العرض المتحرك عند فتحها في PowerPoint. في Aspose.Slides، اختر صيغة الحفظ المناسبة [أثناء التصدير](/slides/ar/androidjava/save-presentation/).

**هل يمكنني استبعاد شرائح فردية من العرض دون حذفها من الملف؟**

نعم. ضع علامة على الشريحة كـ [hidden](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slide/#setHidden-boolean-). الشرائح المخفيّة تبقى في العرض ولكن لا تُعرض أثناء العرض المتحرك.

**هل يمكن لـ Aspose.Slides تشغيل عرض متحرك أو التحكم في عرض تقديمي مباشر على الشاشة؟**

لا. Aspose.Slides يقوم بتحرير وتحليل وتحويل ملفات العروض؛ تشغيل العرض الفعلي يتم عبر تطبيق عارض مثل PowerPoint.