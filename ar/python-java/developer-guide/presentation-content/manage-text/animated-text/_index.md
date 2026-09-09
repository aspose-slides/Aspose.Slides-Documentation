---
title: تحريك نص PowerPoint في Python عبر Java
linktitle: نص متحرك
type: docs
weight: 60
url: /ar/python-java/animated-text/
keywords:
- نص متحرك
- تحريك النص
- فقرة متحركة
- تحريك الفقرة
- تأثير التحريك
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Java
- Aspose.Slides
description: "إنشاء نص متحرك ديناميكي في عروض PowerPoint وOpenDocument باستخدام Aspose.Slides للغة Python عبر Java، مع أمثلة شيفرة Python سهلة المتابعة ومُحسّنة."
---
## **نظرة عامة**

تشرح هذه المقالة كيفية العمل مع النص المتحرك في Aspose.Slides عن طريق تطبيق تأثيرات الحركة على فقرات فردية واسترجاع التأثيرات التي تم تعيينها بالفعل للفقرات داخل إطار نصي. تركز على طرق واجهة برمجة التطبيقات المستخدمة لإضافة حركة على مستوى الفقرة وفحص تأثيرات الحركة الحالية للفقرة في العرض التقديمي.

## **إضافة تأثيرات الحركة إلى الفقرات**

تسمح لك طريقة [addEffect](https://reference.aspose.com/slides/ar/python-java/aspose.slides/sequence/#addEffect) في فئة [Sequence](https://reference.aspose.com/slides/ar/python-java/aspose.slides/sequence/) بإضافة تأثيرات الحركة إلى فقرة واحدة. يوضح لك هذا الكود النموذجي كيفية إضافة تأثير حركة إلى فقرة واحدة:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat

presentation = Presentation("Presentation.pptx")
try:
    # حدد الفقرة لإضافة تأثير إليها.
    auto_shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    # أضف تأثير حركة Fly إلى الفقرة المحددة.
    effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().addEffect(paragraph, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick)

    presentation.save("AnimationEffectinParagraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **الحصول على تأثيرات الحركة للفقرات**

قد ترغب في استرجاع تأثيرات الحركة المطبقة على فقرة—مثلاً لتطبيق تلك التأثيرات على فقرة أو شكل آخر.

يمكِّنك Aspose.Slides for Python via Java من الحصول على جميع تأثيرات الحركة المطبقة على الفقرات الموجودة داخل إطار نص (شكل). يوضح لك هذا الكود النموذجي كيفية الحصول على تأثيرات الحركة المطبقة على فقرة:

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

**كيف تختلف تحريكات النص عن انتقالات الشرائح، وهل يمكن دمجهما؟**

تتحكم تحريكات النص في سلوك الكائن مع مرور الوقت داخل الشريحة، بينما تتحكم [الانتقالات](/slides/ar/python-java/slide-transition/) في طريقة تغيير الشرائح. هما مستقلان ويمكن استخدامهما معًا؛ يتم تحديد ترتيب التشغيل عبر المخطط الزمني للتحريكات وإعدادات الانتقال.

**هل يتم الحفاظ على تحريكات النص عند التصدير إلى PDF أو الصور؟**

لا. ملفات PDF والصور النقطية ثابتة، لذا ستظهر حالة واحدة من الشريحة بدون حركة. للحفاظ على الحركة، استخدم التصدير إلى [فيديو](/slides/ar/python-java/convert-powerpoint-to-video/) أو [HTML](/slides/ar/python-java/export-to-html5/).

**هل تعمل تحريكات النص في التخطيطات والماستر الخاص بالشرائح؟**

التأثيرات المطبقة على كائنات التخطيط/الماستر تُورِّث إلى الشرائح، لكن توقيتها وتفاعله مع تحريكات مستوى الشريحة يعتمد على التسلسل النهائي على الشريحة.