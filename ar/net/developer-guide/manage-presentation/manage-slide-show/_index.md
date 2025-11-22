---
title: إدارة عرض الشرائح
type: docs
weight: 90
url: /ar/net/manage-slide-show/
keywords:
- نوع العرض
- مقدم من قبل المتحدث
- متصفح من قبل فرد
- متصفح في كشك
- خيارات العرض
- التكرار المستمر
- العرض بدون سرد
- العرض بدون حركة
- لون القلم
- عرض الشرائح
- عرض مخصص
- تقدم الشرائح
- يدويًا
- باستخدام التوقيتات
- PowerPoint
- عرض تقديمي
- C#
- .NET
- Aspose.Slides لـ .NET
description: "إدارة إعدادات عرض الشرائح في عروض PowerPoint التقديمية باستخدام C#"
---

في Microsoft PowerPoint، تعد إعدادات **Slide Show** أداة أساسية لإعداد وتقديم العروض التقديمية المهنية. إحدى أهم الميزات في هذا القسم هي **Set Up Show**، والتي تسمح لك بتخصيص عرضك وفقًا لظروف وجماهير معينة، مما يضمن المرونة والراحة. باستخدام هذه الميزة، يمكنك اختيار نوع العرض (مثلاً، عرض يقدمه متحدث، أو يتم تصفحه من قبل فرد، أو يتم تصفحه في كشك)، تمكين أو تعطيل الحلقة المتكررة، اختيار شرائح معينة للعرض، واستخدام التوقيتات. هذه الخطوة في الإعداد حاسمة لجعل عرضك أكثر فعالية ومهنية.

`SlideShowSettings` هي خاصية من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)، من النوع [SlideShowSettings](https://reference.aspose.com/slides/net/aspose.slides/presentation/slideshowsettings/)، والتي تسمح لك بإدارة إعدادات عرض الشرائح في عرض PowerPoint. في هذه المقالة، سنستكشف كيفية استخدام هذه الخاصية لتكوين والتحكم في جوانب مختلفة من إعدادات عرض الشرائح. 

## **اختر نوع العرض**

`SlideShowSettings.SlideShowType` يحدد نوع عرض الشرائح، والذي يمكن أن يكون مثيلاً لأحد الفئات التالية: [PresentedBySpeaker](https://reference.aspose.com/slides/net/aspose.slides/presentedbyspeaker/), [BrowsedByIndividual](https://reference.aspose.com/slides/net/aspose.slides/browsedbyindividual/), أو [BrowsedAtKiosk](https://reference.aspose.com/slides/net/aspose.slides/browsedatkiosk/). يتيح لك استخدام هذه الخاصية تكييف العرض لسيناريوهات استخدام مختلفة، مثل الأكشاك الآلية أو العروض اليدوية.

مثال الشيفرة أدناه ينشئ عرضًا تقديميًا جديدًا ويضبط نوع العرض على "Browsed by an individual" دون عرض شريط التمرير.
```cs
using var presentation = new Presentation();

var showType = new BrowsedByIndividual
{
    ShowScrollbar = false
};

presentation.SlideShowSettings.SlideShowType = showType;

presentation.Save("output.pptx", SaveFormat.Pptx);
```


## **تفعيل خيارات العرض**

`SlideShowSettings.Loop` يحدد ما إذا كان يجب تكرار عرض الشرائح في حلقة حتى يتم إيقافه يدويًا. هذا مفيد للعروض التقديمية الآلية التي تحتاج إلى تشغيل مستمر. `SlideShowSettings.ShowNarration` يحدد ما إذا كان يجب تشغيل السرد الصوتي أثناء عرض الشرائح. وهو مفيد للعروض التقديمية الآلية التي تحتوي على توجيه صوتي للجمهور. `SlideShowSettings.ShowAnimation` يحدد ما إذا كان يجب تشغيل الرسوم المتحركة المضافة إلى كائنات الشرائح. هذا مفيد لتوفير التأثير البصري الكامل للعرض.

مثال الشيفرة التالي ينشئ عرضًا تقديميًا جديدًا ويجعل عرض الشرائح يتكرر في حلقة.
```cs
using var presentation = new Presentation();

presentation.SlideShowSettings.Loop = true;

presentation.Save("output.pptx", SaveFormat.Pptx);
```


## **اختر الشرائح للعرض**

خاصية `SlideShowSettings.Slides` تتيح لك اختيار نطاق من الشرائح ليتم عرضها أثناء العرض التقديمي. هذا مفيد عندما تحتاج إلى عرض جزء فقط من العرض بدلاً من جميع الشرائح.

مثال الشيفرة التالي ينشئ عرضًا تقديميًا جديدًا ويضبط نطاق الشرائح للعرض من الشريحة `2` إلى الشريحة `9`.
```cs
using var presentation = new Presentation();

var slideRange = new SlidesRange 
{
    Start = 2,
    End = 9
};

presentation.SlideShowSettings.Slides = slideRange;

presentation.Save("output.pptx", SaveFormat.Pptx);
```


## **استخدام تقدم الشرائح**

خاصية `SlideShowSettings.UseTimings` تتيح لك تمكين أو تعطيل استخدام التوقيتات المحددة مسبقًا لكل شريحة. هذا مفيد لعرض الشرائح تلقائيًا وفقًا لمدة عرض محددة مسبقًا.

مثال الشيفرة أدناه ينشئ عرضًا تقديميًا جديدًا ويعطل استخدام التوقيتات.
```cs
using var presentation = new Presentation();

presentation.SlideShowSettings.UseTimings = false;

presentation.Save("output.pptx", SaveFormat.Pptx);
```


## **إظهار عناصر التحكم في الوسائط**

خاصية `SlideShowSettings.ShowMediaControls` تحدد ما إذا كان يجب عرض عناصر التحكم في الوسائط (مثل التشغيل، الإيقاف المؤقت، وإيقاف) أثناء عرض الشرائح عندما يتم تشغيل محتوى وسائط متعددة (مثل الفيديو أو الصوت). هذا مفيد عندما تريد إعطاء المقدم التحكم في تشغيل الوسائط أثناء العرض.

مثال الشيفرة التالي ينشئ عرضًا تقديميًا جديدًا ويُمكّن عرض عناصر التحكم في الوسائط.
```cs
using var presentation = new Presentation();

presentation.SlideShowSettings.ShowMediaControls = true;

presentation.Save("output.pptx", SaveFormat.Pptx);
```


## **الأسئلة المتكررة**

**هل يمكنني حفظ عرض تقديمي ليفتح مباشرةً في وضع عرض الشرائح؟**

نعم. احفظ الملف كـ PPSX أو PPSM؛ هذه الصيغ تُفتح مباشرةً في وضع عرض الشرائح عند فتحها في PowerPoint. في Aspose.Slides، اختر تنسيق الحفظ المقابل [أثناء التصدير](/slides/ar/net/save-presentation/).

**هل يمكنني استبعاد شرائح فردية من العرض دون حذفها من الملف؟**

نعم. ضع علامة على الشريحة كـ [Hidden](https://reference.aspose.com/slides/net/aspose.slides/slide/hidden/). تبقى الشرائح المخفية في العرض التقديمي لكنها لا تُعرض أثناء عرض الشرائح.

**هل يمكن لـ Aspose.Slides تشغيل عرض شرائح أو التحكم في عرض مباشر على الشاشة؟**

لا. Aspose.Slides تقوم بتحرير وتحليل وتحويل ملفات العرض التقديمي؛ تشغيل العرض الفعلي يتم عبر تطبيق عارض مثل PowerPoint.