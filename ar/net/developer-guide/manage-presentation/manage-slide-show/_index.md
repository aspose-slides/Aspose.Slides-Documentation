---
title: إدارة عرض الشرائح في .NET
linktitle: عرض الشرائح
type: docs
weight: 90
url: /ar/net/manage-slide-show/
keywords:
- نوع العرض
- مقدم من المتحدث
- مستعرض بواسطة فرد
- مستعرض في كشك
- خيارات العرض
- تكرار مستمر
- عرض بدون سرده
- عرض بدون الرسوم المتحركة
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
description: "تعلم كيفية إدارة عروض الشرائح في Aspose.Slides لـ .NET. تحكم في انتقالات الشرائح، التوقيتات والمزيد عبر صيغ PPT، PPTX و ODP بسهولة."
---

في Microsoft PowerPoint، تُعد إعدادات **Slide Show** أداة أساسية لتحضير وتقديم العروض التقديمية المهنية. واحدة من أهم الميزات في هذا القسم هي **Set Up Show**، التي تتيح لك تخصيص عرضك لظروف وجماهير معينة، مما يضمن المرونة والسهولة. باستخدام هذه الميزة، يمكنك اختيار نوع العرض (مثل تقديمه بواسطة متحدث، أو استعراضه من قِبل فرد، أو استعراضه في كشك)، تمكين أو تعطيل الحلقات، اختيار شرائح معينة للعرض، واستخدام التوقيتات. هذه الخطوة في التحضير حيوية لجعل عرضك أكثر فعالية واحترافية.

`SlideShowSettings` هي خاصية من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) من النوع [SlideShowSettings](https://reference.aspose.com/slides/net/aspose.slides/presentation/slideshowsettings/)، والتي تسمح لك بإدارة إعدادات العرض داخل عرض PowerPoint. في هذه المقالة، سنستعرض كيفية استخدام هذه الخاصية لتكوين والتحكم في جوانب مختلفة من إعدادات العرض.

## **اختر نوع العرض**

`SlideShowSettings.SlideShowType` يحدد نوع العرض، ويمكن أن يكون مثالاً من الفئات التالية: [PresentedBySpeaker](https://reference.aspose.com/slides/net/aspose.slides/presentedbyspeaker/)، [BrowsedByIndividual](https://reference.aspose.com/slides/net/aspose.slides/browsedbyindividual/)، أو [BrowsedAtKiosk](https://reference.aspose.com/slides/net/aspose.slides/browsedatkiosk/). يتيح لك استخدام هذه الخاصية تكييف العرض لسيناريوهات استخدام مختلفة، مثل الأكشاك الآلية أو العروض اليدوية.

مثال الشيفرة أدناه ينشئ عرضاً تقديمياً جديداً ويضبط نوع العرض إلى "استعراض من قِبل فرد" دون عرض شريط التمرير.
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

`SlideShowSettings.Loop` يحدد ما إذا كان يجب تكرار العرض في حلقة حتى يتم إيقافه يدوياً. هذا مفيد للعروض الآلية التي تحتاج إلى تشغيل مستمر. `SlideShowSettings.ShowNarration` يحدد ما إذا كان يجب تشغيل السرد الصوتي أثناء العرض. وهو مفيد للعروض الآلية التي تحتوي على توجيه صوتي للجمهور. `SlideShowSettings.ShowAnimation` يحدد ما إذا كان يجب تشغيل الرسوم المتحركة المضافة إلى عناصر الشرائح. وهذا مفيد لتوفير التأثير البصري الكامل للعرض.

مثال الشيفرة التالي ينشئ عرضاً تقديمياً جديداً ويجعل العرض يتكرر في حلقة.
```cs
using var presentation = new Presentation();

presentation.SlideShowSettings.Loop = true;

presentation.Save("output.pptx", SaveFormat.Pptx);
```


## **اختر الشرائح التي سيتم عرضها**

خاصية `SlideShowSettings.Slides` تسمح لك باختيار نطاق من الشرائح ليتم عرضها أثناء العرض. هذا مفيد عندما تحتاج إلى عرض جزء فقط من العرض بدلاً من جميع الشرائح. مثال الشيفرة التالي ينشئ عرضاً تقديمياً جديداً ويحدد نطاق الشرائح للعرض من الشريحة `2` إلى الشريحة `9`.
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

خاصية `SlideShowSettings.UseTimings` تسمح لك بتمكين أو تعطيل استخدام التوقيتات المحددة مسبقاً لكل شريحة. هذا مفيد لتشغيل الشرائح تلقائياً بمدة عرض معرفة مسبقاً. مثال الشيفرة أدناه ينشئ عرضاً تقديمياً جديداً ويعطل استخدام التوقيتات.
```cs
using var presentation = new Presentation();

presentation.SlideShowSettings.UseTimings = false;

presentation.Save("output.pptx", SaveFormat.Pptx);
```


## **إظهار عناصر التحكم في الوسائط**

خاصية `SlideShowSettings.ShowMediaControls` تحدد ما إذا كان يجب إظهار عناصر التحكم في الوسائط (مثل التشغيل، الإيقاف المؤقت، والإيقاف) أثناء العرض عندما يتم تشغيل محتوى متعدد الوسائط (مثل الفيديو أو الصوت). هذا مفيد عندما ترغب في إعطاء المقدم تحكمًا في تشغيل الوسائط خلال العرض.

مثال الشيفرة التالي ينشئ عرضاً تقديمياً جديداً ويُمكّن إظهار عناصر التحكم في الوسائط.
```cs
using var presentation = new Presentation();

presentation.SlideShowSettings.ShowMediaControls = true;

presentation.Save("output.pptx", SaveFormat.Pptx);
```


## **الأسئلة الشائعة**

**هل يمكنني حفظ عرض تقديمي بحيث يفتح مباشرةً في وضع العرض؟**

نعم. احفظ الملف بصيغة PPSX أو PPSM؛ هذه الصيغ تُطلق مباشرةً في وضع العرض عند فتحها في PowerPoint. في Aspose.Slides، اختر صيغة الحفظ المناسبة [أثناء التصدير](/slides/ar/net/save-presentation/).

**هل يمكنني استبعاد شرائح فردية من العرض دون حذفها من الملف؟**

نعم. ضع علامة على الشريحة كـ [Hidden](https://reference.aspose.com/slides/net/aspose.slides/slide/hidden/). الشرائح المخفية تظل في العرض لكنها لا تُعرض أثناء العرض.

**هل يمكن لـ Aspose.Slides تشغيل عرض تقديمي أو التحكم في عرض مباشر على الشاشة؟**

لا. Aspose.Slides يحرر، يحلّل، ويحوّل ملفات العروض التقديمية؛ يتم تشغيل العرض الفعلي بواسطة تطبيق عرض مثل PowerPoint.