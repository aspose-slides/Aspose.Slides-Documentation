---
title: إدارة عرض الشرائح على Android
linktitle: عرض الشرائح
type: docs
weight: 90
url: /ar/androidjava/manage-slide-show/
keywords:
- نوع العرض
- مقدَّم من قبل المتحدث
- مستعرض من قبل فرد
- مستعرض في الكشك
- خيارات العرض
- تكرار مستمر
- عرض دون التعليق الصوتي
- عرض دون الحركة
- لون القلم
- عرض الشرائح
- عرض مخصص
- تقدم الشرائح
- يدويًا
- استخدام التوقيتات
- PowerPoint
- OpenDocument
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "تعلم كيفية إدارة عروض الشرائح في Aspose.Slides لنظام Android عبر Java. تحكم في انتقالات الشرائح، التوقيتات وأكثر عبر صيغ PPT و PPTX و ODP بسهولة."
---

في Microsoft PowerPoint، تُعَدُّ إعدادات **عرض الشرائح** أداةً أساسيةً لإعداد وتقديم العروض المهنية. من أهم الميزات في هذا القسم هي **Set Up Show**، التي تتيح لك تعديل العرض وفقًا لظروف وجماهير محددة، مما يضمن المرونة والراحة. باستخدام هذه الميزة، يمكنك اختيار نوع العرض (مثل: مقدَّم من قبل المتحدث، يتم تصفحه من قبل فرد، أو يتم تصفحه في كشك)، تمكين أو تعطيل التكرار، اختيار شرائح معينة للعرض، واستخدام التوقيتات. تُعَدُّ هذه الخطوة في الإعداد حيوية لجعل عرضك أكثر فاعلية واحترافية.

`getSlideShowSettings` هي طريقة من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) تُعيد كائنًا من النوع [SlideShowSettings](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slideshowsettings/)، والذي يتيح لك إدارة إعدادات عرض الشرائح في عرض PowerPoint. في هذه المقالة، سنستكشف كيفية استخدام هذه الطريقة لضبط والتحكم في جوانب مختلفة من إعدادات عرض الشرائح.

## **Select Show Type**

`SlideShowSettings.setSlideShowType` تُحدِّد نوع عرض الشرائح، والتي يمكن أن تكون نسخةً من الفئات التالية: [PresentedBySpeaker](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentedbyspeaker/)، [BrowsedByIndividual](https://reference.aspose.com/slides/androidjava/com.aspose.slides/browsedbyindividual/)، أو [BrowsedAtKiosk](https://reference.aspose.com/slides/androidjava/com.aspose.slides/browsedatkiosk/). يتيح لك استخدام هذه الطريقة تعديل العرض لسيناريوهات استخدام مختلفة، مثل الأكشاك الآلية أو العروض اليدوية.

المثال البرمجي أدناه يُنشئ عرضًا جديدًا ويضبط نوع العرض إلى "تصفُّح من قبل فرد" دون عرض شريط التمرير.
```java
Presentation presentation = new Presentation();

BrowsedByIndividual showType = new BrowsedByIndividual();
showType.setShowScrollbar(false);

presentation.getSlideShowSettings().setSlideShowType(showType);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```


## **Enable Show Options**

`SlideShowSettings.setLoop` تحدد ما إذا كان عرض الشرائح يجب أن يتكرر في حلقة حتى يتم إيقافه يدويًا. هذا مفيد للعروض الآلية التي تحتاج إلى التشغيل المستمر. `SlideShowSettings.setShowNarration` تحدد ما إذا كان يجب تشغيل التعليقات الصوتية أثناء عرض الشرائح. وهو مفيد للعروض الآلية التي تحتوي على إرشادات صوتية للجمهور. `SlideShowSettings.setShowAnimation` تحدد ما إذا كان يجب تشغيل الرسوم المتحركة المضافة إلى كائنات الشرائح. وهذا مفيد لتقديم التأثير البصري الكامل للعرض.

المثال البرمجي التالي يُنشئ عرضًا جديدًا ويجعل عرض الشرائح يتكرر.
```java
Presentation presentation = new Presentation();

presentation.getSlideShowSettings().setLoop(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```


## **Select Slides to Show**

طريقة `SlideShowSettings.setSlides` تتيح لك اختيار نطاق من الشرائح لتُعرض خلال العرض. هذا مفيد عندما تحتاج إلى إظهار جزء فقط من العرض بدلاً من جميع الشرائح. المثال البرمجي أدناه يُنشئ عرضًا جديدًا ويضبط نطاق الشرائح للعرض من الشريحة `2` إلى الشريحة `9`.
```java
Presentation presentation = new Presentation();

SlidesRange slideRange = new SlidesRange();
slideRange.setStart(2);
slideRange.setEnd(9);

presentation.getSlideShowSettings().setSlides(slideRange);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```


## **Use Advance Slides**

طريقة `SlideShowSettings.setUseTimings` تتيح لك تمكين أو تعطيل استخدام توقيتات مسبقة لكل شريحة. هذا مفيد لعرض الشرائح تلقائيًا وفقًا لمدة عرض محددة مسبقًا. المثال البرمجي أدناه يُنشئ عرضًا جديدًا ويعطل استخدام التوقيتات.
```java
Presentation presentation = new Presentation();

presentation.getSlideShowSettings().setUseTimings(false);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```


## **Show Media Controls**

طريقة `SlideShowSettings.setShowMediaControls` تحدد ما إذا كان يجب عرض عناصر تحكم الوسائط (مثل تشغيل، إيقاف مؤقت، وإيقاف) أثناء عرض الشرائح عندما يتم تشغيل محتوى متعدد الوسائط (مثل الفيديو أو الصوت). هذا مفيد عندما تريد إعطاء المقدم السيطرة على تشغيل الوسائط أثناء العرض.

المثال البرمجي التالي يُنشئ عرضًا جديدًا ويمكّن عرض عناصر تحكم الوسائط.
```java
Presentation presentation = new Presentation();

presentation.getSlideShowSettings().setShowMediaControls(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```


## **FAQ**

**هل يمكنني حفظ العرض بحيث يفتح مباشرةً في وضع عرض الشرائح؟**

نعم. احفظ الملف كـ PPSX أو PPSM؛ هذه الصيغ تُشغل مباشرةً في وضع عرض الشرائح عند فتحها في PowerPoint. في Aspose.Slides، اختر صيغة الحفظ المقابلة [أثناء التصدير](/slides/ar/androidjava/save-presentation/).

**هل يمكنني استبعاد شرائح فردية من العرض دون حذفها من الملف؟**

نعم. ضع علامة على الشريحة كـ [hidden](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slide/#setHidden-boolean-). تبقى الشرائح المخفية في العرض ولكن لا تُعرض أثناء عرض الشرائح.

**هل يمكن لـ Aspose.Slides تشغيل عرض شرائح أو التحكم في عرض مباشر على الشاشة؟**

لا. Aspose.Slides تقوم بتحرير، تحليل، وتحويل ملفات العرض؛ التشغيل الفعلي يتم بواسطة تطبيق عارض مثل PowerPoint.