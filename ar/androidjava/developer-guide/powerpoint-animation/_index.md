---
title: تحسين عروض PowerPoint التقديمية مع الرسوم المتحركة على Android
linktitle: رسوم متحركة PowerPoint
type: docs
weight: 150
url: /ar/androidjava/powerpoint-animation/
keywords:
- إضافة رسوم متحركة
- تحديث الرسوم المتحركة
- تغيير الرسوم المتحركة
- إزالة الرسوم المتحركة
- إدارة الرسوم المتحركة
- التحكم في الرسوم المتحركة
- تأثير الرسوم المتحركة
- رسوم متحركة PowerPoint
- الجدول الزمني للرسوم المتحركة
- رسوم متحركة تفاعلية
- رسوم متحركة مخصصة
- رسوم متحركة للأشكال
- مخطط متحرك
- نص متحرك
- شكل متحرك
- كائن OLE متحرك
- صورة متحركة
- جدول متحرك
- PowerPoint
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "استكشف إمكانات Aspose.Slides لنظام Android عبر Java في معالجة رسوم متحركة PowerPoint. يسلط هذا الاستعراض العام الضوء على الميزات الرئيسية."
---
## **المقدمة**

بما أن العروض التقديمية تهدف إلى عرض شيء ما، فإن المظهر البصري والسلوك التفاعلي لها يُؤخذ دائمًا بعين الاعتبار أثناء الإنشاء.

**PowerPoint animation** يلعب دورًا مهمًا في جعل العرض التقديمي جذابًا وملفتًا للانتباه للمشاهدين. يوفر Aspose.Slides مجموعة واسعة من الخيارات لإضافة الرسوم المتحركة إلى عروض PowerPoint:

- تطبيق أنواع مختلفة من تأثيرات PowerPoint animation على الأشكال، المخططات، الجداول، كائنات OLE، وعناصر العرض الأخرى.
- استخدام تأثيرات PowerPoint animation متعددة على شكل واحد.
- الاستفادة من جدول زمني للرسوم المتحركة للتحكم في تأثيرات الرسوم المتحركة.
- إنشاء رسوم متحركة مخصصة.

في Aspose.Slides، يمكن تطبيق تأثيرات رسوم متحركة مختلفة على الأشكال. نظرًا لأن كل عنصر على الشريحة، بما في ذلك النصوص، الصور، كائنات OLE، والجداول، يُعتبر شكلًا، يمكن تطبيق تأثيرات الرسوم المتحركة على أي عنصر في الشريحة.

## **Animation Effects**
يدعم Aspose.Slides **أكثر من 150 تأثيرًا للرسوم المتحركة**، بما في ذلك التأثيرات الأساسية مثل Bounce و PathFootball و Zoom، والتأثيرات الخاصة مثل OLEObjectShow و OLEObjectOpen. يمكنك العثور على القائمة الكاملة في فئة [EffectType](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/effecttype/).

بالإضافة إلى ذلك، يمكن استخدام هذه التأثيرات مع السلوكيات التالية:

- [ColorEffect](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ColorEffect)
- [CommandEffect](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/CommandEffect)
- [FilterEffect](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/FilterEffect)
- [MotionEffect](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/MotionEffect)
- [PropertyEffect](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/PropertyEffect)
- [RotationEffect](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/RotationEffect)
- [ScaleEffect](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ScaleEffect)
- [SetEffect](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/SetEffect)

## **Custom Animation**

للأمثلة الكاملة بلغة Java التي تنشئ وتفحص وتُعدل السلوكيات ومسارات الحركة القابلة للتحرير، راجع [Custom Animation](/slides/ar/java/custom-animation/).

يمكنك إنشاء **رسوم متحركة مخصصة** خاصة بك في Aspose.Slides. يتم ذلك بدمج عدة سلوكيات في رسم متحرك مخصص جديد.

[Behavior](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/behavior/) هو وحدة بناء لتأثير الرسوم المتحركة في PowerPoint. قم بدمج السلوكيات لتخصيص تأثير، أو أضف سلوكًا لتوسيع تأثير مُعرّف مسبقًا. يتم تكوين التكرار من خلال إعدادات التوقيت بدلاً من سلوك التكرار المنفصل.

[Animation Point](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/point/) هو نقطة يُطبق عندها السلوك.

## **Animation Time Line**
[Sequence](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/sequence/) هي مجموعة من تأثيرات الرسوم المتحركة التي يمكن أن تستهدف أشكالًا مختلفة.

[Timeline](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/animationtimeline/) هي مجموعة من السلاسل المستخدمة في شريحة معينة. إنه محرك رسوم متحركة تم تقديمه في PowerPoint 2002. في الإصدارات السابقة من PowerPoint، كان إضافة تأثيرات الرسوم المتحركة إلى العروض صعبًا ولا يمكن تحقيقه إلا عبر حلول بديلة مختلفة. يوفر الجدول الزمني نموذج كائن أوضح للرسوم المتحركة في PowerPoint. يمكن أن تحتوي الشريحة على جدول زمني للرسوم المتحركة واحد فقط.

## **Interactive Animation**
[Trigger](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/effecttriggertype/) يتيح لك تعريف إجراءات المستخدم، مثل نقرة زر، التي تبدأ رسمًا متحركًا معينًا.

## **Shape Animation**
يسمح Aspose.Slides لك بتطبيق الرسوم المتحركة على الأشكال، والتي يمكن أن تشمل النصوص، المستطيلات، الخطوط، الإطارات، كائنات OLE، والمزيد.

{{% alert color="info" title="Note" %}}
Read more [**About Shape Animation**](/slides/ar/androidjava/shape-animation/).
{{% /alert %}}

## **Animated Charts**
لإنشاء مخططات متحركة، يجب استخدام نفس الفئات الخاصة بالأشكال. ومع ذلك، يمكن تطبيق رسوم متحركة PowerPoint فقط على فئات المخطط أو سلاسل المخطط. يمكنك أيضًا تطبيق تأثيرات الرسوم المتحركة على عنصر فئة أو عنصر سلسلة.

{{% alert color="info" title="Note" %}}
Read more [**About Animated Charts**](/slides/ar/androidjava/animated-charts/).
{{% /alert %}}

## **Animated Text**
بالإضافة إلى تحريك النص، يمكنك تطبيق الرسوم المتحركة على الفقرة.

{{% alert color="info" title="Note" %}}
Read more [**About Animated Text**](/slides/ar/androidjava/animated-text/).
{{% /alert %}}

## **FAQ**

**Will animations be preserved when exporting to PDF?**

لا. PDF هو تنسيق ثابت، لذلك لا تُشغل الرسوم المتحركة و[slide transitions](/slides/ar/androidjava/slide-transition/). إذا كنت تحتاج إلى حركة، صدِّر إلى [HTML5](/slides/ar/androidjava/export-to-html5/)، [animated GIF](/slides/ar/androidjava/convert-powerpoint-to-animated-gif/)، أو [video](/slides/ar/androidjava/convert-powerpoint-to-video/) بدلاً من ذلك.

**Can I turn an animated presentation into a video and control the frame rate and frame size?**

نعم. يمكنك [render the presentation as frames](/slides/ar/androidjava/convert-powerpoint-to-video/) وترميزها إلى فيديو (على سبيل المثال عبر ffmpeg)، مع اختيار عدد الإطارات في الثانية والدقة. تُشغل الرسوم المتحركة وانتقالات الشرائح أثناء عملية التصيير.

**Will animations remain intact when working with ODP (not just PPTX)?**

يتم دعم PPT وPPTX وODP لل[reading](/slides/ar/androidjava/open-presentation/) و[writing](/slides/ar/androidjava/save-presentation/)، لكن ذلك لا يضمن الحفاظ على الرسوم المتحركة. قد تُفقد بيانات الرسوم المتحركة المخصصة عند التحويل إلى ODP. راجع [Custom Animation for Java](/slides/ar/java/custom-animation/) للحصول على أمثلة وإرشادات حول التحقق من توافق الصيغة.