---
title: إدارة عروض الشرائح في Python عبر Java
linktitle: عرض الشرائح
type: docs
weight: 90
url: /ar/python-java/manage-slide-show/
keywords:
- نوع العرض
- مقدم من قبل المتحدث
- تم التصفح من قبل فرد
- تم التصفح عند الكشك
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
- Python
- Java
- Aspose.Slides
description: "تعلم كيفية إدارة عروض الشرائح في Aspose.Slides لـ Python عبر Java. تحكم في انتقالات الشرائح، التوقيتات والمزيد عبر صيغ PPT و PPTX و ODP بسهولة."
---
## **مقدمة**

تتيح لك خيارات **Set Up Show** في Microsoft PowerPoint اختيار نوع العرض، وتمكين التكرار، وتحديد الشرائح، والتحكم في طريقة تقدم الشرائح. باستخدام Aspose.Slides للغة Python عبر Java، يمكنك تكوين هذه الخيارات برمجيًا وحفظها في ملف عرض تقديمي.

طُرِ [Presentation.getSlideShowSettings](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/#getSlideShowSettings) تُعيد كائنًا من نوع [SlideShowSettings](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slideshowsettings/) الذي يتحكم في هذه الخيارات. الأمثلة أدناه تتطلب Aspose.Slides للغة Python عبر Java وبيئة تشغيل Java متوافقة. كل مثال يبدأ JVM إذا لزم الأمر ويُطلق العرض التقديمي عند الانتهاء.

## **تحديد نوع العرض**

[SlideShowSettings.setSlideShowType](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slideshowsettings/#setSlideShowType) يُعرِّف نوع عرض الشرائح، ويمكن أن يكون مثالًا لأحد الفئات التالية: [PresentedBySpeaker](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentedbyspeaker/)، [BrowsedByIndividual](https://reference.aspose.com/slides/ar/python-java/aspose.slides/browsedbyindividual/)، أو [BrowsedAtKiosk](https://reference.aspose.com/slides/ar/python-java/aspose.slides/browsedatkiosk/). استخدام هذه الطريقة يتيح لك تعديل العرض ليتناسب مع سيناريوهات استخدام مختلفة، مثل الأكشاك الآلية أو العروض اليدوية.

المثال البرمجي أدناه ينشئ عرضًا تقديميًا جديدًا ويضبط نوع العرض على "Browsed by an individual" دون عرض شريط التمرير.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, BrowsedByIndividual

presentation = Presentation()
try:
    show_type = BrowsedByIndividual()
    show_type.setShowScrollbar(False)
    presentation.getSlideShowSettings().setSlideShowType(show_type)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **تمكين خيارات العرض**

[SlideShowSettings.setLoop](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slideshowsettings/#setLoop) يحدِّد ما إذا كان عرض الشرائح يجب أن يتكرر في حلقة حتى يتم إيقافه يدويًا. هذا مفيد للعروض الآلية التي تحتاج إلى التشغيل المستمر. [SlideShowSettings.setShowNarration](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slideshowsettings/#setShowNarration) يحدِّد ما إذا كان يجب تشغيل السرد الصوتي أثناء عرض الشرائح. وهو مفيد للعروض التي تتضمن إرشادات صوتية للجمهور. [SlideShowSettings.setShowAnimation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slideshowsettings/#setShowAnimation) يحدِّد ما إذا كان يجب تشغيل الرسوم المتحركة المضافة إلى كائنات الشرائح. وهذا يُثْري العرض بالتأثير البصري الكامل.

الكود التالي يُنشئ عرضًا تقديميًا جديدًا ويجعل عرض الشرائح يدور بصورة متكررة.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    presentation.getSlideShowSettings().setLoop(True)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **تحديد الشرائح للعرض**

[SlideShowSettings.setSlides](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slideshowsettings/#setSlides) يتيح لك اختيار نطاق من الشرائح ليُعرض أثناء العرض التقديمي. هذا مفيد عندما تحتاج إلى إظهار جزء فقط من العرض بدلاً من جميع الشرائح. المثال البرمجي التالي يُنشئ عرضًا يحتوي على تسع شرائح ويختار الشرائح من 2 إلى 9. النطاق يستخدم أرقام شرائح تبدأ من الواحد.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlidesRange

presentation = Presentation()
try:
    # إنشاء تسع شرائح حتى يكون النطاق المحدد موجودًا.
    first_slide = presentation.getSlides().get_Item(0)
    for _ in range(8):
        presentation.getSlides().addClone(first_slide)

    slide_range = SlidesRange()
    slide_range.setStart(2)
    slide_range.setEnd(9)
    presentation.getSlideShowSettings().setSlides(slide_range)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **التحكم في تقدم الشرائح**

[SlideShowSettings.setUseTimings](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slideshowsettings/#setUseTimings) يتيح لك تمكين أو تعطيل استخدام توقيتات محددة مسبقًا لكل شريحة. هذا مفيد لعرض الشرائح تلقائيًا وفقًا لمدة عرض مُحددة مسبقًا. الكود التالي يُنشئ عرضًا تقديميًا جديدًا ويعطّل استخدام التوقيتات.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    presentation.getSlideShowSettings().setUseTimings(False)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **إظهار أدوات التحكم في الوسائط**

[SlideShowSettings.setShowMediaControls](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slideshowsettings/#setShowMediaControls) يحدد ما إذا كان ينبغي عرض أدوات التحكم في الوسائط (مثل التشغيل، الإيقاف المؤقت، والإيقاف) أثناء عرض الشرائح عندما يُشغَّل محتوى وسائط متعددة (مثل الفيديو أو الصوت). هذا مفيد عندما تريد إعطاء المُقدِّم القدرة على التحكم في تشغيل الوسائط أثناء العرض.

الكود التالي يُنشئ عرضًا تقديميًا جديدًا ويُفعِّل إظهار أدوات التحكم في الوسائط.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    presentation.getSlideShowSettings().setShowMediaControls(True)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **الأسئلة الشائعة**

**هل يمكنني حفظ عرض تقديمي بحيث يفتح مباشرةً في وضع العرض؟**

نعم. احفظ الملف بامتداد PPSX أو PPSM؛ هذه الصيغ تُفتح مباشرةً في وضع العرض عند فتحها في PowerPoint. في Aspose.Slides، اختر صيغة الحفظ المقابلة [أثناء التصدير](/slides/ar/python-java/save-presentation/).

**هل يمكنني استبعاد شرائح فردية من العرض دون حذفها من الملف؟**

نعم. ضع علامة على الشريحة كـ [mخفي](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slide/#setHidden). تظل الشرائح المخفية في العرض التقديمي ولكن لا يتم عرضها أثناء العرض.

**هل يمكن لـ Aspose.Slides تشغيل عرض تقديمي أو التحكم في عرض مباشر على الشاشة؟**

لا. Aspose.Slides يقوم بتحرير وتحليل وتحويل ملفات العرض التقديمي؛ يتم تشغيل العرض الفعلي بواسطة تطبيق عارض مثل PowerPoint.