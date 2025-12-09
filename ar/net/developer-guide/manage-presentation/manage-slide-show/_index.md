---
title: إدارة عرض الشرائح في .NET
linktitle: عرض الشرائح
type: docs
weight: 90
url: /ar/net/manage-slide-show/
keywords:
- نوع العرض
- مقدم من المتحدث
- متصفح من قبل فرد
- متصفح في كشك
- خيارات العرض
- تكرار مستمر
- عرض بدون سرد
- عرض بدون رسوم متحركة
- لون القلم
- عرض الشرائح
- عرض مخصص
- تقديم الشرائح
- يدوياً
- باستخدام التوقيتات
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "تعلم كيفية إدارة عروض الشرائح في Aspose.Slides لـ .NET. سيطر على انتقالات الشرائح، التوقيتات والمزيد عبر صيغ PPT و PPTX و ODP بسهولة."
---

في Microsoft PowerPoint ، تُعد إعدادات **عرض الشرائح** أداة أساسية لتحضير وتقديم عروض تقديمية احترافية. واحدة من أهم الميزات في هذا القسم هي **إعداد العرض**، التي تتيح لك تخصيص العرض وفقاً لظروف وجماهير محددة، مما يضمن المرونة والراحة. باستخدام هذه الميزة، يمكنك اختيار نوع العرض (مثل تقديمه من قبل متحدث، تصفحه من قبل فرد، أو تصفحه في كشك)، تمكين أو تعطيل التكرار، اختيار شرائح محددة للعرض، واستخدام التوقيتات. هذه الخطوة في الإعداد ضرورية لجعل عرضك أكثر فاعلية واحترافية.

`SlideShowSettings` هي خاصية من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) من النوع [SlideShowSettings](https://reference.aspose.com/slides/net/aspose.slides/presentation/slideshowsettings/)، والتي تتيح لك إدارة إعدادات عرض الشرائح في عرض PowerPoint. في هذه المقالة، سوف نستكشف كيفية استخدام هذه الخاصية لتكوين والتحكم في جوانب مختلفة من إعدادات عرض الشرائح. 

## **اختيار نوع العرض**

`SlideShowSettings.SlideShowType` يحدد نوع عرض الشرائح، والذي يمكن أن يكون مثالاً على إحدى الفئات التالية: [PresentedBySpeaker](https://reference.aspose.com/slides/net/aspose.slides/presentedbyspeaker/), [BrowsedByIndividual](https://reference.aspose.com/slides/net/aspose.slides/browsedbyindividual/), أو [BrowsedAtKiosk](https://reference.aspose.com/slides/net/aspose.slides/browsedatkiosk/). باستخدام هذه الخاصية يمكنك تعديل العرض لسيناريوهات استخدام مختلفة، مثل الأكشاك الآلية أو العروض اليدوية.

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

`SlideShowSettings.Loop` يحدد ما إذا كان عرض الشرائح يجب أن يتكرر في حلقة حتى يتم إيقافه يدوياً. هذا مفيد للعرض التلقائي الذي يحتاج إلى التشغيل المستمر. `SlideShowSettings.ShowNarration` يحدد ما إذا كان يجب تشغيل السرد الصوتي خلال عرض الشرائح. يكون ذلك مفيداً للعرض التلقائي الذي يحتوي على إرشادات صوتية للجمهور. `SlideShowSettings.ShowAnimation` يحدد ما إذا كانت الرسوم المتحركة المضافة إلى كائنات الشرائح يجب أن تُشغَل. هذا مفيد لتقديم التأثير البصري الكامل للعرض.

```cs
using var presentation = new Presentation();

presentation.SlideShowSettings.Loop = true;

presentation.Save("output.pptx", SaveFormat.Pptx);
```


## **اختيار الشرائح للعرض**

خاصية `SlideShowSettings.Slides` تسمح لك باختيار نطاق من الشرائح ليتم عرضها خلال العرض. يكون ذلك مفيداً عندما تحتاج إلى عرض جزء فقط من العرض بدلاً من جميع الشرائح. المثال البرمجي التالي ينشئ عرضاً تقديمياً جديداً ويحدد نطاق الشرائح للعرض من الشريحة `2` إلى الشريحة `9`.

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


## **استخدام توقيتات الشرائح**

خاصية `SlideShowSettings.UseTimings` تسمح لك بتمكين أو تعطيل استخدام توقيتات مسبقة الإعداد لكل شريحة. هذا مفيد لعرض الشرائح تلقائياً بمدة عرض محددة سلفاً. المثال البرمجي أدناه ينشئ عرضاً تقديمياً جديداً ويعطل استخدام التوقيتات.

```cs
using var presentation = new Presentation();

presentation.SlideShowSettings.UseTimings = false;

presentation.Save("output.pptx", SaveFormat.Pptx);
```


## **إظهار عناصر تحكم الوسائط**

خاصية `SlideShowSettings.ShowMediaControls` تحدد ما إذا كانت عناصر تحكم الوسائط (مثل التشغيل، الإيقاف المؤقت، والإيقاف) يجب أن تُعرض أثناء عرض الشرائح عندما يتم تشغيل محتوى وسائط متعددة (مثل الفيديو أو الصوت). يكون ذلك مفيداً عندما تريد إعطاء المقدم تحكمًا في تشغيل الوسائط خلال العرض.

```cs
using var presentation = new Presentation();

presentation.SlideShowSettings.ShowMediaControls = true;

presentation.Save("output.pptx", SaveFormat.Pptx);
```


## **الأسئلة الشائعة**

**هل يمكنني حفظ عرض تقديمي بحيث يفتح مباشرة في وضع عرض الشرائح؟**

نعم. احفظ الملف بصيغة PPSX أو PPSM؛ هذه الصيغ تفتح مباشرة في وضع عرض الشرائح عند فتحها في PowerPoint. في Aspose.Slides، اختر صيغة الحفظ المقابلة [أثناء التصدير](/slides/ar/net/save-presentation/).

**هل يمكنني استبعاد شرائح فردية من العرض دون حذفها من الملف؟**

نعم. ضع علامة على الشريحة كـ [Hidden](https://reference.aspose.com/slides/net/aspose.slides/slide/hidden/). تظل الشرائح المخفية في العرض التقديمي لكنها لا تُعرض أثناء عرض الشرائح.

**هل يمكن لـ Aspose.Slides تشغيل عرض شرائح أو التحكم في عرض مباشر على الشاشة؟**

لا. Aspose.Slides يقوم بتعديل، تحليل، وتحويل ملفات العروض التقديمية؛ تشغيل العرض الفعلي يتم عبر تطبيق عارض مثل PowerPoint.