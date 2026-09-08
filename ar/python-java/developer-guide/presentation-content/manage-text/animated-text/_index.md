---
title: "تحريك نص PowerPoint في Python عبر Java"
linktitle: "نص متحرك"
type: docs
weight: 60
url: /ar/python-java/animated-text/
keywords:
- "نص متحرك"
- "تحريك النص"
- "فقرة متحركة"
- "تحريك الفقرة"
- "تأثير الحركة"
- "PowerPoint"
- "OpenDocument"
- "عرض تقديمي"
- "Python"
- "Java"
- "Aspose.Slides"
description: "إنشاء نص متحرك ديناميكي في عروض PowerPoint وOpenDocument باستخدام Aspose.Slides للـ Python عبر Java، مع أمثلة شفرة Python سهلة المتابعة ومُحسّنة."
---
## **نظرة عامة**

تشرح هذه المقالة كيفية التعامل مع النص المتحرك في Aspose.Slides عن طريق تطبيق تأثيرات الحركة على فقرات فردية واسترجاع التأثيرات المعينة بالفعل للفقرات داخل إطار نص. تركّز على طرق API المستخدمة لإضافة حركة على مستوى الفقرة وفحص تأثيرات الحركة الحالية للفقرة في العرض التقديمي.

## **إضافة تأثيرات الحركة إلى الفقرات**

تتيح لك طريقة [addEffect](https://reference.aspose.com/slides/ar/python-java/aspose.slides/sequence/#addEffect) من فئة [Sequence](https://reference.aspose.com/slides/ar/python-java/aspose.slides/sequence/) إضافة تأثيرات الحركة إلى فقرة واحدة. يوضح لك هذا المثال كيفية إضافة تأثير حركة إلى فقرة واحدة:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat

presentation = Presentation("Presentation.pptx")
try:
    # اختر الفقرة لإضافة تأثير إليها.
    auto_shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    # أضف تأثير حركة Fly إلى الفقرة المحددة.
    effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().addEffect(paragraph, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick)

    presentation.save("AnimationEffectinParagraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **الحصول على تأثيرات الحركة للفقرة**

قد تحتاج إلى معرفة تأثيرات الحركة المضافة إلى فقرة—على سبيل المثال، قد ترغب في الحصول على تأثيرات الحركة في فقرة لأنك تخطط لتطبيق هذه التأثيرات على فقرة أو شكل آخر.

يتيح لك Aspose.Slides for Python عبر Java الحصول على جميع تأثيرات الحركة المطبقة على الفقرات الموجودة داخل إطار نص (شكل). يوضح لك هذا المثال كيفية الحصول على تأثيرات الحركة في فقرة:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("Presentation.pptx")
try:
    sequence = presentation.getSlides().get_Item(0).getTimeline().getMainSequence()
    auto_shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)

    for paragraph in auto_shape.getTextFrame().getParagraphs():
        effects = sequence.getEffectsByParagraph(paragraph)

        if len(effects) > 0:
            print(f'Paragraph "{paragraph.getText()}" has {effects[0].getType()} effect.')
finally:
    presentation.dispose()
```

## **الأسئلة الشائعة**

**كيف تختلف تحريك النصوص عن انتقالات الشرائح، وهل يمكن دمجهما؟**
تحكم تحريكات النص سلوك الكائن مع مرور الوقت على الشريحة، بينما تتحكم [transitions](/slides/ar/python-java/slide-transition/) في طريقة انتقال الشرائح. هما مستقلان ويمكن استخدامهما معًا؛ يتم تحديد ترتيب التشغيل وفقًا للجدول الزمني للرسوم المتحركة وإعدادات الانتقال.

**هل يتم الحفاظ على تحريكات النص عند التصدير إلى PDF أو الصور؟**
لا. ملفات PDF والصور النقطية ثابتة، لذا سترى حالة واحدة للشفافة دون حركة. للحفاظ على الحركة، استخدم تصدير [video](/slides/ar/python-java/convert-powerpoint-to-video/) أو [HTML](/slides/ar/python-java/export-to-html5/).

**هل تعمل تحريكات النص في التخطيطات والماستر؟**
يتم وراثة التأثيرات المطبقة على كائنات التخطيط/الرئيسية من قبل الشرائح، لكن توقيتها وتفاعلها مع تحريكات مستوى الشريحة يعتمد على التسلسل النهائي على الشريحة.