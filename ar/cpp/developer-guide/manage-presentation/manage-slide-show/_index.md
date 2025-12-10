---
title: إدارة عرض الشرائح في C++
linktitle: عرض الشرائح
type: docs
weight: 90
url: /ar/cpp/manage-slide-show/
keywords:
- نوع العرض
- مقدم من قبل المتحدث
- تصفح بواسطة فرد
- تصفح في الكشك
- خيارات العرض
- تكرار مستمر
- عرض بدون سرد
- عرض بدون رسوم متحركة
- لون القلم
- عرض الشرائح
- عرض مخصص
- تقدم الشرائح
- يدويًا
- باستخدام التوقيتات
- PowerPoint
- OpenDocument
- عرض تقديمي
- C++
- Aspose.Slides
description: "تعلم كيفية إدارة عروض الشرائح في Aspose.Slides للغة C++. تحكم في انتقالات الشرائح، التوقيتات وأكثر عبر صيغ PPT و PPTX و ODP بسهولة."
---

في Microsoft PowerPoint، تُعد إعدادات **Slide Show** أداة رئيسية لتحضير وتقديم العروض التقديمية الاحترافية. واحدة من أهم الميزات في هذا القسم هي **Set Up Show**، التي تتيح لك تخصيص عرضك حسب الظروف والجمهور المحدد، مما يضمن مرونة وسهولة. باستخدام هذه الميزة، يمكنك اختيار نوع العرض (مثل تقديمه بواسطة متحدث، أو تصفحه بواسطة فرد، أو تصفحه في كشك)، تمكين أو تعطيل التكرار، اختيار شرائح محددة للعرض، واستخدام التوقيتات. هذه الخطوة في التحضير حاسمة لجعل عرضك أكثر فاعلية واحترافية.

`get_SlideShowSettings` هي طريقة من الفئة [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) التي تُعيد كائن من النوع [SlideShowSettings](https://reference.aspose.com/slides/cpp/aspose.slides/slideshowsettings/)، والذي يتيح لك إدارة إعدادات عرض الشرائح في عرض PowerPoint. في هذه المقالة، سنستكشف كيفية استخدام هذه الطريقة لتكوين والتحكم في جوانب مختلفة من إعدادات عرض الشرائح. 

## **اختر نوع العرض**

`SlideShowSettings.set_SlideShowType` يحدد نوع عرض الشرائح، والذي يمكن أن يكون نسخة من الفئات التالية: [PresentedBySpeaker](https://reference.aspose.com/slides/cpp/aspose.slides/presentedbyspeaker/), [BrowsedByIndividual](https://reference.aspose.com/slides/cpp/aspose.slides/browsedbyindividual/), أو [BrowsedAtKiosk](https://reference.aspose.com/slides/cpp/aspose.slides/browsedatkiosk/). استخدام هذه الطريقة يتيح لك تكييف العرض لسيناريوهات استخدام مختلفة، مثل الأكشاك الآلية أو العروض اليدوية.

مثال الشيفرة أدناه ينشئ عرضًا تقديميًا جديدًا ويضبط نوع العرض إلى "Browsed by an individual" دون عرض شريط التمرير.
```cpp
auto presentation = MakeObject<Presentation>();

auto showType = MakeObject<BrowsedByIndividual>();
showType->set_ShowScrollbar(false);

presentation->get_SlideShowSettings()->set_SlideShowType(showType);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


## **تمكين خيارات العرض**

`SlideShowSettings.set_Loop` يحدد ما إذا كان عرض الشرائح يجب أن يتكرر في حلقة حتى يتم إيقافه يدويًا. هذا مفيد للعروض التلقائية التي تحتاج إلى التشغيل المستمر. `SlideShowSettings.set_ShowNarration` يحدد ما إذا كان يجب تشغيل السرد الصوتي أثناء عرض الشرائح. إنه مفيد للعروض التلقائية التي تحتوي على إرشادات صوتية للجمهور. `SlideShowSettings.set_ShowAnimation` يحدد ما إذا كان يجب تشغيل الرسوم المتحركة المضافة إلى كائنات الشرائح. هذا مفيد لتوفير التأثير البصري الكامل للعرض.

مثال الشيفرة التالي ينشئ عرضًا تقديميًا جديدًا ويجعل عرض الشرائح يتكرر.
```cpp
auto presentation = MakeObject<Presentation>();

presentation->get_SlideShowSettings()->set_Loop(true);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


## **اختر الشرائح للعرض**

طريقة `SlideShowSettings.set_Slides` تتيح لك اختيار نطاق من الشرائح ليتم عرضها أثناء العرض التقديمي. هذا مفيد عندما تحتاج إلى عرض جزء فقط من العرض بدلاً من جميع الشرائح. مثال الشيفرة التالي ينشئ عرضًا تقديميًا جديدًا ويضبط نطاق الشرائح للعرض من الشريحة `2` إلى الشريحة `9`.
```cpp
auto presentation = MakeObject<Presentation>();

auto slideRange = MakeObject<SlidesRange>();
slideRange->set_Start(2);
slideRange->set_End(9);

presentation->get_SlideShowSettings()->set_Slides(slideRange);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


## **استخدام تقدم الشرائح**

طريقة `SlideShowSettings.set_UseTimings` تتيح لك تمكين أو تعطيل استخدام التوقيتات المحددة مسبقًا لكل شريحة. هذا مفيد لعرض الشرائح تلقائيًا وفقًا لمدة عرض محددة مسبقًا. مثال الشيفرة أدناه ينشئ عرضًا تقديميًا جديدًا ويعطل استخدام التوقيتات.
```cpp
auto presentation = MakeObject<Presentation>();

presentation->get_SlideShowSettings()->set_UseTimings(false);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


## **إظهار عناصر التحكم في الوسائط**

طريقة `SlideShowSettings.set_ShowMediaControls` تحدد ما إذا كان يجب عرض عناصر التحكم في الوسائط (مثل تشغيل، إيقاف مؤقت، وإيقاف) أثناء عرض الشرائح عندما يتم تشغيل محتوى وسائط متعددة (مثل الفيديو أو الصوت). هذا مفيد عندما تريد إعطاء المقدم القدرة على التحكم في تشغيل الوسائط أثناء العرض.

مثال الشيفرة التالي ينشئ عرضًا تقديميًا جديدًا ويمكّن عرض عناصر التحكم في الوسائط.
```cpp
auto presentation = MakeObject<Presentation>();

presentation->get_SlideShowSettings()->set_ShowMediaControls(true);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


## **الأسئلة المتكررة**

**هل يمكنني حفظ عرض تقديمي حتى يفتح مباشرةً في وضع عرض الشرائح؟**

نعم. احفظ الملف كـ PPSX أو PPSM؛ هذه الصيغ تُفتح مباشرةً في عرض الشرائح عند فتحها في PowerPoint. في Aspose.Slides، اختر صيغة الحفظ المقابلة [أثناء التصدير](/slides/ar/cpp/save-presentation/).

**هل يمكنني استبعاد شرائح فردية من العرض دون حذفها من الملف؟**

نعم. ضع علامة على الشريحة كـ [hidden](https://reference.aspose.com/slides/cpp/aspose.slides/slide/set_hidden/). الشرائح المخفية تظل في العرض التقديمي لكنها لا تُعرض أثناء عرض الشرائح.

**هل يمكن لـ Aspose.Slides تشغيل عرض شرائح أو التحكم في عرض تقديمي مباشر على الشاشة؟**

لا. Aspose.Slides يحرر، يحلل، ويحويل ملفات العروض التقديمية؛ تشغيل العرض الفعلي يتم بواسطة تطبيق عارض مثل PowerPoint.