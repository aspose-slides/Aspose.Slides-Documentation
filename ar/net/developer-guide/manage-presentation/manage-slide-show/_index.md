---
title: إدارة عرض الشرائح في .NET
linktitle: عرض الشرائح
type: docs
weight: 90
url: /ar/net/manage-slide-show/
keywords:
- نوع العرض
- مقدم من المتحدث
- مستعرض من قبل فرد
- مستعرض في الكشك
- خيارات العرض
- تكرار مستمر
- عرض بدون تعليق صوتي
- عرض بدون حركة
- لون القلم
- عرض الشرائح
- عرض مخصص
- تقدم الشرائح
- يدويًا
- باستخدام التوقيتات
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "تعلم كيفية إدارة عروض الشرائح في Aspose.Slides لـ .NET. تحكم في انتقالات الشرائح، التوقيتات والمزيد عبر صيغ PPT و PPTX و ODP بسهولة."
---

في Microsoft PowerPoint، تُعَد إعدادات **Slide Show** أداة أساسية لإعداد وتقديم العروض التقديمية المهنية. واحدة من أهم الميزات في هذا القسم هي **Set Up Show**، التي تسمح لك بتكييف العرض التقديمي وفقًا لظروف وجماهير محددة، مما يضمن المرونة والراحة. باستخدام هذه الميزة، يمكنك اختيار نوع العرض (على سبيل المثال، مقدَّم من متحدث، يُستعرض من قبل فرد، أو يُستعرض في كشك)، تمكين أو تعطيل التكرار، اختيار الشرائح المحددة للعرض، واستخدام التوقيتات. هذه الخطوة في الإعداد ضرورية لجعل عرضك أكثر فاعلية ومهنية.

`SlideShowSettings` هي خاصية لفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) من النوع [SlideShowSettings](https://reference.aspose.com/slides/net/aspose.slides/presentation/slideshowsettings/)، والتي تسمح لك بإدارة إعدادات عرض الشرائح في عرض PowerPoint. في هذه المقالة، سنستكشف كيفية استخدام هذه الخاصية لتكوين والتحكم في جوانب مختلفة من إعدادات عرض الشرائح. 

## **حدد نوع العرض**

`SlideShowSettings.SlideShowType` يحدد نوع عرض الشرائح، والذي يمكن أن يكون مثيلًا من الفئات التالية: [PresentedBySpeaker](https://reference.aspose.com/slides/net/aspose.slides/presentedbyspeaker/), [BrowsedByIndividual](https://reference.aspose.com/slides/net/aspose.slides/browsedbyindividual/), أو [BrowsedAtKiosk](https://reference.aspose.com/slides/net/aspose.slides/browsedatkiosk/). يسمح لك استخدام هذه الخاصية بتكييف العرض التقديمي لسيناريوهات استخدام مختلفة، مثل الأكشاك الآلية أو العروض اليدوية.

المثال البرمجي أدناه ينشئ عرضًا تقديميًا جديدًا ويضبط نوع العرض على "Browsed by an individual" دون عرض شريط التمرير.
```cs
using var presentation = new Presentation();

var showType = new BrowsedByIndividual
{
    ShowScrollbar = false
};

presentation.SlideShowSettings.SlideShowType = showType;

presentation.Save("output.pptx", SaveFormat.Pptx);
```


## **تمكين خيارات العرض**

`SlideShowSettings.Loop` يحدد ما إذا كان يجب تكرار عرض الشرائح في حلقة حتى يتم إيقافه يدويًا. هذا مفيد للعروض التقديمية الآلية التي تحتاج إلى تشغيل مستمر. `SlideShowSettings.ShowNarration` يحدد ما إذا كان يجب تشغيل التعليقات الصوتية أثناء عرض الشرائح. وهو مفيد للعروض الآلية التي تحتوي على إرشادات صوتية للجمهور. `SlideShowSettings.ShowAnimation` يحدد ما إذا كان يجب تشغيل الرسوم المتحركة المضافة إلى كائنات الشرائح. هذا مفيد لتوفير التأثير البصري الكامل للعرض.

المثال البرمجي التالي ينشئ عرضًا تقديميًا جديدًا ويجعل عرض الشرائح يتكرر في حلقة.
```cs
using var presentation = new Presentation();

presentation.SlideShowSettings.Loop = true;

presentation.Save("output.pptx", SaveFormat.Pptx);
```


## **حدد الشرائح للعرض**

`SlideShowSettings.Slides` الخاصية تسمح لك باختيار نطاق من الشرائح ليتم عرضها أثناء العرض التقديمي. هذا مفيد عندما تحتاج إلى عرض جزء فقط من العرض بدلاً من كل الشرائح. المثال البرمجي التالي ينشئ عرضًا تقديميًا جديدًا ويحدد نطاق الشرائح للعرض من الشريحة `2` إلى الشريحة `9`.
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

`SlideShowSettings.UseTimings` الخاصية تسمح لك بتمكين أو تعطيل استخدام التوقيتات المحددة مسبقًا لكل شريحة. هذا مفيد لعرض الشرائح تلقائيًا بمدة عرض مسبقة التعريف. المثال البرمجي أدناه ينشئ عرضًا تقديميًا جديدًا ويعطل استخدام التوقيتات.
```cs
using var presentation = new Presentation();

presentation.SlideShowSettings.UseTimings = false;

presentation.Save("output.pptx", SaveFormat.Pptx);
```


## **إظهار عناصر التحكم في الوسائط**

`SlideShowSettings.ShowMediaControls` الخاصية تحدد ما إذا كان يجب عرض عناصر التحكم في الوسائط (مثل تشغيل، إيقاف مؤقت، وإيقاف) أثناء عرض الشرائح عندما يتم تشغيل محتوى وسائط متعددة (مثل الفيديو أو الصوت). هذا مفيد عندما تريد إعطاء المقدم السيطرة على تشغيل الوسائط أثناء العرض.

المثال البرمجي التالي ينشئ عرضًا تقديميًا جديدًا ويمكّن عرض عناصر التحكم في الوسائط.
```cs
using var presentation = new Presentation();

presentation.SlideShowSettings.ShowMediaControls = true;

presentation.Save("output.pptx", SaveFormat.Pptx);
```


## **الأسئلة المتكررة**

**هل يمكنني حفظ عرض تقديمي ليفتح مباشرة في وضع عرض الشرائح؟**

نعم. احفظ الملف كـ PPSX أو PPSM؛ هذه الصيغ تفتح مباشرة في وضع عرض الشرائح عند فتحها في PowerPoint. في Aspose.Slides، اختر تنسيق الحفظ المناسب [during export](/slides/ar/net/save-presentation/).

**هل يمكنني استثناء شرائح فردية من العرض دون حذفها من الملف؟**

نعم. ضع علامة على الشريحة كـ [Hidden](https://reference.aspose.com/slides/net/aspose.slides/slide/hidden/). الشرائح المخفية تبقى في العرض التقديمي لكنها لا تُعرض أثناء عرض الشرائح.

**هل يمكن لـ Aspose.Slides تشغيل عرض شرائح أو التحكم في عرض مباشر على الشاشة؟**

لا. Aspose.Slides تقوم بتحرير، تحليل، وتحويل ملفات العروض التقديمية؛ أما تشغيل العرض الفعلي فعليه أن يتم عبر تطبيق عرض مثل PowerPoint.