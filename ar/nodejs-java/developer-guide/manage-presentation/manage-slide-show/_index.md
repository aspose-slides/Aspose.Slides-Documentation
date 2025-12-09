---
title: إدارة عرض الشرائح
type: docs
weight: 90
url: /ar/nodejs-java/manage-slide-show/
keywords:
- نوع العرض
- مقدم من قبل متحدث
- مستعرض من قبل فرد
- مستعرض في كشك
- خيارات العرض
- تكرار مستمر
- عرض بدون سرد
- عرض بدون تحريك
- لون القلم
- عرض الشرائح
- عرض مخصص
- تقدم الشرائح
- يدوياً
- باستخدام التوقيتات
- PowerPoint
- عرض تقديمي
- Node.js
- JavaScript
- Aspose.Slides for Node.js via Java
description: "إدارة إعدادات عرض الشرائح في عروض PowerPoint التقديمية باستخدام JavaScript"
---

في Microsoft PowerPoint، تعتبر إعدادات **Slide Show** أداة أساسية لإعداد وتقديم العروض التقديمية الاحترافية. واحدة من أهم الميزات في هذا القسم هي **Set Up Show**، التي تتيح لك تخصيص العرض وفقًا لظروف وجماهير محددة، مما يضمن المرونة والراحة. باستخدام هذه الميزة، يمكنك اختيار نوع العرض (مثلاً، مقدَّم من قبل متحدث، مستعرض من قبل فرد، أو مستعرض في كشك)، تمكين أو تعطيل التكرار، اختيار شرائح معينة للعرض، واستخدام التوقيتات. هذه الخطوة في الإعداد حاسمة لجعل عرضك أكثر فاعلية واحترافية.

`getSlideShowSettings` هو طريقة من فئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) التي تُرجع كائنًا من النوع [SlideShowSettings](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowsettings/)، والذي يتيح لك إدارة إعدادات عرض الشرائح في عرض PowerPoint. في هذه المقالة، سنستكشف كيفية استخدام هذه الطريقة لتكوين والتحكم في جوانب مختلفة من إعدادات عرض الشرائح. 

## **Select Show Type**
`SlideShowSettings.setSlideShowType` يحدد نوع عرض الشرائح، والذي يمكن أن يكون مثالًا للصفوف التالية: [PresentedBySpeaker](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentedbyspeaker/), [BrowsedByIndividual](https://reference.aspose.com/slides/nodejs-java/aspose.slides/browsedbyindividual/), أو [BrowsedAtKiosk](https://reference.aspose.com/slides/nodejs-java/aspose.slides/browsedatkiosk/). باستخدام هذه الطريقة يمكنك تعديل العرض لسيناريوهات استخدام مختلفة، مثل الأكشاك المؤتمتة أو العروض اليدوية.

مثال الشيفرة أدناه ينشئ عرضًا تقديميًا جديدًا ويضبط نوع العرض على "Browsed by an individual" دون عرض شريط التمرير.
```js
var presentation = new asposeSlides.Presentation();

var showType = new asposeSlides.BrowsedByIndividual();
showType.setShowScrollbar(false);

presentation.getSlideShowSettings().setSlideShowType(showType);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```


## **Enable Show Options**
`SlideShowSettings.setLoop` يحدد ما إذا كان يجب تكرار عرض الشرائح في حلقة حتى يتم إيقافه يدويًا. هذا مفيد للعروض المؤتمتة التي تحتاج إلى التشغيل المستمر. `SlideShowSettings.setShowNarration` يحدد ما إذا كان يجب تشغيل السرد الصوتي أثناء عرض الشرائح. وهو مفيد للعروض المؤتمتة التي تحتوي على إرشادات صوتية للجمهور. `SlideShowSettings.setShowAnimation` يحدد ما إذا كان يجب تشغيل الرسوم المتحركة المضافة إلى كائنات الشرائح. هذا مفيد لتوفير التأثير البصري الكامل للعرض.

مثال الشيفرة التالي ينشئ عرضًا تقديميًا جديدًا ويجعل عرض الشرائح يتكرر في حلقة.
```js
var presentation = new asposeSlides.Presentation();

presentation.getSlideShowSettings().setLoop(true);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```


## **Select Slides to Show**
طريقة `SlideShowSettings.setSlides` تتيح لك اختيار نطاق من الشرائح ليتم عرضها أثناء العرض التقديمي. هذا مفيد عندما تحتاج إلى إظهار جزء فقط من العرض بدلاً من جميع الشرائح. مثال الشيفرة التالي ينشئ عرضًا تقديميًا جديدًا ويحدد نطاق الشرائح للعرض من الشريحة `2` إلى الشريحة `9`.
```js
var presentation = new asposeSlides.Presentation();

var slideRange = new asposeSlides.SlidesRange();
slideRange.setStart(2);
slideRange.setEnd(9);

presentation.getSlideShowSettings().setSlides(slideRange);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```


## **Use Advance Slides**
طريقة `SlideShowSettings.setUseTimings` تتيح لك تمكين أو تعطيل استخدام توقيتات محددة مسبقًا لكل شريحة. هذا مفيد لعرض الشرائح تلقائيًا وفقًا لمدد عرض محددة مسبقًا. مثال الشيفرة أدناه ينشئ عرضًا تقديميًا جديدًا ويعطل استخدام التوقيتات.
```js
var presentation = new asposeSlides.Presentation();

presentation.getSlideShowSettings().setUseTimings(false);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```


## **Show Media Controls**
طريقة `SlideShowSettings.setShowMediaControls` تحدد ما إذا كان يجب عرض عناصر تحكم الوسائط (مثل التشغيل، الإيقاف المؤقت، والإيقاف) أثناء عرض الشرائح عندما يتم تشغيل محتوى وسائط متعددة (مثل الفيديو أو الصوت). هذا مفيد عندما ترغب في منح المقدم التحكم في تشغيل الوسائط أثناء العرض.

مثال الشيفرة التالي ينشئ عرضًا تقديميًا جديدًا ويفعل عرض عناصر التحكم في الوسائط.
```js
var presentation = new asposeSlides.Presentation();

presentation.getSlideShowSettings().setShowMediaControls(true);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```


## **FAQ**

**Can I save a presentation so it opens directly in slide show mode?**
**هل يمكنني حفظ عرض تقديمي بحيث يفتح مباشرةً في وضع عرض الشرائح؟**
نعم. احفظ الملف بصيغة PPSX أو PPSM؛ هذه الصيغ تُفتح مباشرةً في وضع عرض الشرائح عند فتحها في PowerPoint. في Aspose.Slides، اختر صيغة الحفظ المقابلة [during export](/slides/ar/nodejs-java/save-presentation/).

**Can I exclude individual slides from the show without deleting them from the file?**
**هل يمكنني استبعاد شرائح فردية من العرض دون حذفها من الملف؟**
نعم. ضع علامة على الشريحة كـ [hidden](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/sethidden/). الشرائح المخفية تبقى في العرض التقديمي لكنها لا تُعرض أثناء عرض الشرائح.

**Can Aspose.Slides play a slide show or control a live presentation on screen?**
**هل يمكن لـ Aspose.Slides تشغيل عرض شرائح أو التحكم في عرض مباشر على الشاشة؟**
لا. تقوم Aspose.Slides بتحرير وتحليل وتحويل ملفات العروض التقديمية؛ أما تشغيل العرض الفعلي فيتم عبر تطبيق عارض مثل PowerPoint.