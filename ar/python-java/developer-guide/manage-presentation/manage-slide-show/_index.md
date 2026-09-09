---
title: إدارة عروض الشرائح في Python عبر Java
linktitle: عرض الشرائح
type: docs
weight: 90
url: /ar/python-java/manage-slide-show/
keywords:
- نوع العرض
- مقدم من المتحدث
- مستعرض من قبل فرد
- مستعرض في الكشك
- خيارات العرض
- تكرار مستمر
- عرض دون سرد
- عرض دون رسوم متحركة
- لون القلم
- عرض الشرائح
- عرض مخصص
- تقدم الشرائح
- يدويًا
- باستخدام توقيتات
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Java
- Aspose.Slides
description: "تعلم كيفية إدارة عروض الشرائح في Aspose.Slides لـ Python عبر Java. تحكم في انتقالات الشرائح، التوقيتات والمزيد عبر صيغ PPT و PPTX و ODP بسهولة."
---
## **المقدمة**

تتيح لك خيارات **Set Up Show** في Microsoft PowerPoint اختيار نوع العرض، تمكين التكرار، اختيار الشرائح، والتحكم في طريقة تقدم الشرائح. باستخدام Aspose.Slides for Python عبر Java، يمكنك تكوين هذه الخيارات برمجياً وحفظها في ملف عرض تقديمي.

ترجع طريقة [Presentation.getSlideShowSettings](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/#getSlideShowSettings) كائنًا من [SlideShowSettings](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slideshowsettings/) يتحكم في هذه الخيارات. الأمثلة أدناه تتطلب Aspose.Slides for Python عبر Java وبيئة تشغيل Java المتوافقة. كل مثال يبدأ JVM إذا كان ذلك مطلوبًا ويطلق العرض التقديمي عند الانتهاء.

## **اختيار نوع العرض**

تحدد طريقة [SlideShowSettings.setSlideShowType](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slideshowsettings/#setSlideShowType) نوع عرض الشرائح، ويمكن أن تكون مثالا من الفئات التالية: [PresentedBySpeaker](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentedbyspeaker/)، [BrowsedByIndividual](https://reference.aspose.com/slides/ar/python-java/aspose.slides/browsedbyindividual/)، أو [BrowsedAtKiosk](https://reference.aspose.com/slides/ar/python-java/aspose.slides/browsedatkiosk/). يتيح لك استخدام هذه الطريقة تكييف العرض التقديمي لسيناريوهات استخدام مختلفة، مثل الأكشاك الآلية أو العروض اليدوية.

يقوم مثال الشيفرة أدناه بإنشاء عرض تقديمي جديد ويضبط نوع العرض على "Browsed by an individual" دون عرض شريط التمرير.

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

تحدد طريقة [SlideShowSettings.setLoop](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slideshowsettings/#setLoop) ما إذا كان يجب أن يتكرر عرض الشرائح في حلقة حتى يتم إيقافه يدويًا. هذا مفيد للعرض الآلي الذي يحتاج إلى التشغيل المستمر. تحدد طريقة [SlideShowSettings.setShowNarration](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slideshowsettings/#setShowNarration) ما إذا كان يجب تشغيل السرد الصوتي أثناء عرض الشرائح. وهو مفيد للعرض الآلي الذي يحتوي على إرشادات صوتية للجمهور. تحدد طريقة [SlideShowSettings.setShowAnimation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slideshowsettings/#setShowAnimation) ما إذا كان يجب تشغيل الرسوم المتحركة المضافة إلى كائنات الشرائح. وهذا مفيد لتوفير التأثير البصري الكامل للعرض.

يقوم مثال الشيفرة التالي بإنشاء عرض تقديمي جديد ويجعل عرض الشرائح يتكرر في حلقة.

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

## **اختيار الشرائح للعرض**

تتيح طريقة [SlideShowSettings.setSlides](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slideshowsettings/#setSlides) لك اختيار نطاق من الشرائح ليتم عرضها أثناء العرض التقديمي. هذا مفيد عندما تحتاج إلى عرض جزء فقط من العرض بدلاً من جميع الشرائح. يقوم مثال الشيفرة التالي بإنشاء عرض تقديمي يحتوي على تسع شرائح ويختار الشرائح من 2 إلى 9. النطاق يستخدم أرقام شرائح تبدأ من الواحد.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlidesRange

presentation = Presentation()
try:
    # إنشاء تسع شرائح بحيث يكون النطاق المحدد موجودًا.
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

تتيح طريقة [SlideShowSettings.setUseTimings](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slideshowsettings/#setUseTimings) لك تمكين أو تعطيل استخدام توقيتات محددة مسبقًا لكل شريحة. هذا مفيد لعرض الشرائح تلقائيًا بمدة عرض محددة مسبقًا. يقوم مثال الشيفرة أدناه بإنشاء عرض تقديمي جديد ويعطل استخدام التوقيتات.

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

## **عرض عناصر التحكم في الوسائط**

تحدد طريقة [SlideShowSettings.setShowMediaControls](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slideshowsettings/#setShowMediaControls) ما إذا كان يجب عرض عناصر التحكم في الوسائط (مثل التشغيل، الإيقاف المؤقت، والإيقاف) أثناء عرض الشرائح عندما يتم تشغيل محتوى متعدد الوسائط (مثل الفيديو أو الصوت). هذا مفيد عندما تريد إعطاء المقدم التحكم في تشغيل الوسائط أثناء العرض التقديمي.

يقوم مثال الشيفرة التالي بإنشاء عرض تقديمي جديد ويمكّن عرض عناصر التحكم في الوسائط.

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

**Can I save a presentation so it opens directly in slide show mode?**

نعم. احفظ الملف كـ PPSX أو PPSM؛ هذه الصيغ تُفتح مباشرةً في وضع عرض الشرائح عند فتحها في PowerPoint. في Aspose.Slides، اختر صيغة الحفظ المقابلة [أثناء التصدير](/slides/ar/python-java/save-presentation/).

**Can I exclude individual slides from the show without deleting them from the file?**

نعم. ضع علامة على الشريحة كـ [hidden](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slide/#setHidden). تبقى الشرائح المخفية في العرض التقديمي ولكنها لا تُعرض أثناء عرض الشرائح.

**Can Aspose.Slides play a slide show or control a live presentation on screen?**

لا. يقوم Aspose.Slides بتحرير وتحليل وتحويل ملفات العروض التقديمية؛ أما تشغيل العرض الفعلي فُي يد تطبيق عرض مثل PowerPoint.