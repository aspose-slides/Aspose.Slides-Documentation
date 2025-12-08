---
title: إدارة عرض الشرائح في Python
linktitle: عرض الشرائح
type: docs
weight: 90
url: /ar/python-net/manage-slide-show/
keywords:
- نوع العرض
- مقدم من المتحدث
- مستعرض من قبل فرد
- مستعرض في كشك
- خيارات العرض
- تكرار مستمر
- عرض بدون تعليق صوتي
- عرض بدون رسوم متحركة
- لون القلم
- عرض الشرائح
- عرض مخصص
- تقدم الشرائح
- يدويًا
- باستخدام التوقيتات
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "تعلم كيفية إدارة عروض الشرائح في Aspose.Slides للـ Python عبر .NET. سيطر على انتقالات الشرائح، التوقيتات، والمزيد عبر صيغ PPT، PPTX و ODP بسهولة."
---

في مايكروسوفت بوربوينت، تُعد إعدادات **Slide Show** أداة أساسية لإعداد وتقديم العروض التقديمية المهنية. واحدة من أهم الميزات في هذا القسم هي **Set Up Show**، التي تتيح لك تخصيص العرض التقديمي وفقًا لظروف وجماهير معينة، مما يضمن المرونة والراحة. باستخدام هذه الميزة، يمكنك اختيار نوع العرض (مثل تقديمه بواسطة متحدث، أو استعراضه من قبل فرد، أو استعراضه في كشك)، تمكين أو تعطيل التكرار، اختيار شرائح محددة للعرض، واستخدام التوقيتات. هذه الخطوة في الإعداد ضرورية لجعل عرضك أكثر فاعلية ومهنية.

`slide_show_settings` هي خاصية من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) من النوع [SlideShowSettings](https://reference.aspose.com/slides/python-net/aspose.slides/slideshowsettings/)، والتي تتيح لك إدارة إعدادات عرض الشرائح في عرض بوربوينت. في هذه المقالة، سنستكشف كيفية استخدام هذه الخاصية لتكوين والتحكم في جوانب مختلفة من إعدادات عرض الشرائح. 

## **اختيار نوع العرض**

`SlideShowSettings.slide_show_type` يحدد نوع عرض الشرائح، والذي يمكن أن يكون نسخة من الفئات التالية: [PresentedBySpeaker](https://reference.aspose.com/slides/python-net/aspose.slides/presentedbyspeaker/)، [BrowsedByIndividual](https://reference.aspose.com/slides/python-net/aspose.slides/browsedbyindividual/)، أو [BrowsedAtKiosk](https://reference.aspose.com/slides/python-net/aspose.slides/browsedatkiosk/). باستخدام هذه الخاصية يمكنك تعديل العرض لسيناريوهات استخدام مختلفة، مثل الأكشاك الآلية أو العروض اليدوية.

مثال الشيفرة أدناه ينشئ عرضًا تقديميًا جديدًا ويضبط نوع العرض إلى "Browsed by an individual" دون عرض شريط التمرير.
```py
with slides.Presentation() as presentation:

    show_type = slides.BrowsedByIndividual()
    show_type.show_scrollbar = False

    presentation.slide_show_settings.slide_show_type = show_type

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **تفعيل خيارات العرض**

`SlideShowSettings.loop` يحدد ما إذا كان عرض الشرائح يجب أن يتكرر في حلقة حتى يتم إيقافه يدويًا. هذا مفيد للعروض الآلية التي تحتاج إلى التشغيل باستمرار. `SlideShowSettings.show_narration` يحدد ما إذا كان يجب تشغيل التعليقات الصوتية خلال عرض الشرائح. وهو مفيد للعروض الآلية التي تحتوي على إرشادات صوتية للجمهور. `SlideShowSettings.show_animation` يحدد ما إذا كان يجب تشغيل الرسوم المتحركة المضافة إلى كائنات الشرائح. هذا مفيد لتوفير التأثير البصري الكامل للعرض.

مثال الشيفرة التالي ينشئ عرضًا تقديميًا جديدًا ويجعل عرض الشرائح يتكرر.
```py
with slides.Presentation() as presentation:

    presentation.slide_show_settings.loop = True

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **اختيار الشرائح للعرض**

`SlideShowSettings.slides` الخاصية تتيح لك اختيار نطاق من الشرائح ليتم عرضها أثناء العرض التقديمي. هذا مفيد عندما تحتاج إلى عرض جزء فقط من العرض بدلاً من جميع الشرائح. مثال الشيفرة التالي ينشئ عرضًا تقديميًا جديدًا ويحدد نطاق الشرائح للعرض من الشريحة `2` إلى الشريحة `9`.
```py
with slides.Presentation() as presentation:
    
    slide_range = slides.SlidesRange()
    slide_range.start = 2
    slide_range.end = 9

    presentation.slide_show_settings.slides = slide_range

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **استخدام تقدم الشرائح**

`SlideShowSettings.use_timings` الخاصية تسمح لك بتمكين أو تعطيل استخدام التوقيتات المحددة مسبقًا لكل شريحة. هذا مفيد لعرض الشرائح تلقائيًا بمدة عرض محددة مسبقًا. مثال الشيفرة أدناه ينشئ عرضًا تقديميًا جديدًا ويعطل استخدام التوقيتات.
```py
with slides.Presentation() as presentation:

    presentation.slide_show_settings.use_timings = False

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **عرض أدوات التحكم في الوسائط**

`SlideShowSettings.show_media_controls` الخاصية تحدد ما إذا كان يجب عرض أدوات التحكم في الوسائط (مثل التشغيل، الإيقاف المؤقت، والإيقاف) أثناء عرض الشرائح عندما يتم تشغيل محتوى متعدد الوسائط (مثل الفيديو أو الصوت). هذا مفيد عندما تريد إعطاء المقدم القدرة على التحكم في تشغيل الوسائط خلال العرض.

مثال الشيفرة التالي ينشئ عرضًا تقديميًا جديدًا ويفعل عرض أدوات التحكم في الوسائط.
```py
with slides.Presentation() as presentation:

    presentation.slide_show_settings.show_media_controls = True

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **الأسئلة الشائعة**

**هل يمكنني حفظ عرض تقديمي بحيث يفتح مباشرةً في وضع عرض الشرائح؟**

نعم. احفظ الملف بصيغة PPSX أو PPSM؛ هذه الصيغ تفتح مباشرة في وضع عرض الشرائح عند فتحها في PowerPoint. في Aspose.Slides، اختر صيغة الحفظ المقابلة [أثناء التصدير](/slides/ar/python-net/save-presentation/).

**هل يمكنني استبعاد شرائح فردية من العرض دون حذفها من الملف؟**

نعم. ضع علامة على الشريحة كـ [hidden](https://reference.aspose.com/slides/python-net/aspose.slides/slide/hidden/). الشرائح المخفية تظل في العرض التقديمي لكنها لا تُعرض أثناء عرض الشرائح.

**هل يمكن لـ Aspose.Slides تشغيل عرض شرائح أو التحكم في عرض مباشر على الشاشة؟**

لا. Aspose.Slides يحرر، يحلل، ويحول ملفات العروض التقديمية؛ تشغيل العرض الفعلي يتم بواسطة تطبيق عارض مثل PowerPoint.