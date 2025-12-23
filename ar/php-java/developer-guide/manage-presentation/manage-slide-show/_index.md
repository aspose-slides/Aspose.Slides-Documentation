---
title: إدارة عرض الشرائح في PHP
linktitle: عرض الشرائح
type: docs
weight: 90
url: /ar/php-java/manage-slide-show/
keywords:
- نوع العرض
- مقدم من المتحدث
- متصفح من قبل فرد
- متصفح في كشك
- خيارات العرض
- التكرار المستمر
- عرض بدون سرد
- عرض بدون رسوم متحركة
- لون القلم
- عرض الشرائح
- عرض مخصص
- تقدم الشرائح
- يدوياً
- استخدام التوقيتات
- PowerPoint
- OpenDocument
- عرض تقديمي
- PHP
- Aspose.Slides
description: "تعرّف على كيفية إدارة عرض الشرائح في Aspose.Slides لـ PHP عبر Java. تحكم في انتقالات الشرائح، التوقيتات والمزيد عبر صيغ PPT و PPTX و ODP بسهولة."
---


في Microsoft PowerPoint، تُعد إعدادات **عرض الشرائح** أداة أساسية لتحضير وتقديم العروض التقديمية الاحترافية. إحدى أهم الميزات في هذا القسم هي **Set Up Show**، التي تتيح لك تخصيص عرضك وفقاً لظروف وجماهير معينة، مما يضمن المرونة والراحة. باستخدام هذه الميزة، يمكنك اختيار نوع العرض (مثل تقديمه بواسطة متحدث، أو تصفحه من قبل فرد، أو تصفحه في كشك)، وتمكين أو تعطيل التكرار، واختيار شرائح محددة للعرض، واستخدام التوقيتات. هذه الخطوة في الإعداد ضرورية لجعل عرضك أكثر فاعلية ومهنية.

`getSlideShowSettings` هي طريقة من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) التي تُعيد كائنًا من النوع [SlideShowSettings](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowsettings/)، والذي يتيح لك إدارة إعدادات عرض الشرائح في عرض PowerPoint. في هذا المقال، سنستكشف كيفية استخدام هذه الطريقة لتكوين والتحكم في جوانب مختلفة من إعدادات عرض الشرائح. 

## **اختر نوع العرض**

`SlideShowSettings->setSlideShowType` يحدد نوع عرض الشرائح، والذي يمكن أن يكون نسخة من الفئات التالية: [PresentedBySpeaker](https://reference.aspose.com/slides/php-java/aspose.slides/presentedbyspeaker/)، [BrowsedByIndividual](https://reference.aspose.com/slides/php-java/aspose.slides/browsedbyindividual/)، أو [BrowsedAtKiosk](https://reference.aspose.com/slides/php-java/aspose.slides/browsedatkiosk/). يتيح لك استخدام هذه الطريقة تكييف العرض لسيناريوهات استخدام مختلفة، مثل الكشكات الآلية أو العروض اليدوية.

مثال الشيفرة أدناه ينشئ عرضًا تقديميًا جديدًا ويضبط نوع العرض إلى "Browsed by an individual" دون عرض شريط التمرير.
```php
$presentation = new Presentation();

$showType = new BrowsedByIndividual();
$showType->setShowScrollbar(false);

$presentation->getSlideShowSettings()->setSlideShowType($showType);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```


## **تمكين خيارات العرض**

`SlideShowSettings->setLoop` يحدد ما إذا كان يجب تكرار عرض الشرائح في حلقة حتى يتم إيقافه يدويًا. هذا مفيد للعروض الآلية التي تحتاج إلى التشغيل المستمر. `SlideShowSettings->setShowNarration` يحدد ما إذا كان يجب تشغيل السرد الصوتي أثناء عرض الشرائح. وهو مفيد للعروض الآلية التي تحتوي على إرشادات صوتية للجمهور. `SlideShowSettings->setShowAnimation` يحدد ما إذا كان يجب تشغيل الرسوم المتحركة المضافة إلى كائنات الشرائح. وهذا مفيد لتوفير التأثير البصري الكامل للعرض.

مثال الشيفرة التالي ينشئ عرضًا تقديميًا جديدًا ويجعل عرض الشرائح يتكرر.
```php
$presentation = new Presentation();

$presentation->getSlideShowSettings()->setLoop(true);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```


## **اختر الشرائح للعرض**

طريقة `SlideShowSettings->setSlides` تتيح لك تحديد نطاق من الشرائح ليتم عرضها أثناء العرض التقديمي. هذا مفيد عندما تحتاج إلى عرض جزء فقط من العرض بدلاً من جميع الشرائح. مثال الشيفرة التالي ينشئ عرضًا تقديميًا جديدًا ويضبط نطاق الشرائح للعرض من الشريحة `2` إلى الشريحة `9`.
```php
$presentation = new Presentation();

$slideRange = new SlidesRange();
$slideRange->setStart(2);
$slideRange->setEnd(9);

$presentation->getSlideShowSettings()->setSlides($slideRange);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```


## **استخدام توقيت الشرائح**

طريقة `SlideShowSettings->setUseTimings` تتيح لك تمكين أو تعطيل استخدام التوقيتات المحددة مسبقًا لكل شريحة. هذا مفيد لعرض الشرائح تلقائيًا مع فترة عرض محددة مسبقًا. مثال الشيفرة أدناه ينشئ عرضًا تقديميًا جديدًا ويعطل استخدام التوقيتات.
```php
$presentation = new Presentation();

$presentation->getSlideShowSettings()->setUseTimings(false);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```


## **عرض عناصر التحكم في الوسائط**

طريقة `SlideShowSettings->setShowMediaControls` تحدد ما إذا كان يجب عرض عناصر التحكم في الوسائط (مثل التشغيل، الإيقاف المؤقت، والإيقاف) أثناء عرض الشرائح عندما يتم تشغيل محتوى وسائط متعددة (مثل الفيديو أو الصوت). هذا مفيد عندما ترغب في إعطاء المقدم تحكمًا في تشغيل الوسائط أثناء العرض.

مثال الشيفرة التالي ينشئ عرضًا تقديميًا جديدًا ويُفعِّل عرض عناصر التحكم في الوسائط.
```php
$presentation = new Presentation();

$presentation->getSlideShowSettings()->setShowMediaControls(true);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```


## **الأسئلة المتكررة**

**هل يمكنني حفظ عرض تقديمي بحيث يفتح مباشرةً في وضع عرض الشرائح؟**

نعم. احفظ الملف كـ PPSX أو PPSM؛ هذه الصيغ تُشغَل مباشرةً في وضع عرض الشرائح عند فتحها في PowerPoint. في Aspose.Slides، اختر صيغة الحفظ المقابلة [during export](/slides/ar/php-java/save-presentation/).

**هل يمكنني استبعاد شرائح فردية من العرض دون حذفها من الملف؟**

نعم. قم بوضع علامة على الشريحة كـ [hidden](https://reference.aspose.com/slides/php-java/aspose.slides/slide/sethidden/). تظل الشرائح المخفية في العرض التقديمي لكنها لا تُعرض أثناء عرض الشرائح.

**هل يمكن لـ Aspose.Slides تشغيل عرض شرائح أو التحكم في عرض حي على الشاشة؟**

لا. Aspose.Slides تقوم بتعديل وتحليل وتحويل ملفات العروض التقديمية؛ عملية التشغيل الفعلية يتم التعامل معها بواسطة تطبيق عارض مثل PowerPoint.