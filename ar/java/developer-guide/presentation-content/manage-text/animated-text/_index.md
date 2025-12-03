---
title: تحريك نص PowerPoint في Java
linktitle: نص متحرك
type: docs
weight: 60
url: /ar/java/animated-text/
keywords:
- نص متحرك
- تحريك النص
- فقرة متحركة
- تحريك الفقرة
- تأثير الرسوم المتحركة
- PowerPoint
- OpenDocument
- عرض تقديمي
- Java
- Aspose.Slides
description: "إنشاء نص متحرك ديناميكي في عروض PowerPoint و OpenDocument باستخدام Aspose.Slides for Java، مع أمثلة شفرة Java سهلة المتابعة ومُحسّنة."
---

## **إضافة تأثيرات الرسوم المتحركة إلى الفقرات**

أضفنا طريقة [**addEffect()**](https://reference.aspose.com/slides/java/com.aspose.slides/Sequence#addEffect-com.aspose.slides.IParagraph-int-int-int-) إلى الفئات [**Sequence**](https://reference.aspose.com/slides/java/com.aspose.slides/Sequence) و[**ISequence**](https://reference.aspose.com/slides/java/com.aspose.slides/ISequence). تسمح لك هذه الطريقة بإضافة تأثيرات الرسوم المتحركة إلى فقرة واحدة. يوضح لك هذا المثال البرمجي كيفية إضافة تأثير رسوم متحركة إلى فقرة واحدة:
```java
Presentation presentation = new Presentation("Presentation.pptx");
try {
    // اختر الفقرة لإضافة التأثير
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // أضف تأثير التحليق (Fly) إلى الفقرة المحددة
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().
            addEffect(paragraph, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    presentation.save("AnimationEffectinParagraph.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```


## **الحصول على تأثيرات الرسوم المتحركة للفقرات**

قد ترغب في معرفة تأثيرات الرسوم المتحركة المضافة إلى الفقرة — على سبيل المثال، في سيناريو ما، تريد الحصول على تأثيرات الرسوم المتحركة في فقرة لأنك تخطط لتطبيق تلك التأثيرات على فقرة أو شكل آخر.

تسمح لك Aspose.Slides for Java بالحصول على جميع تأثيرات الرسوم المتحركة المطبقة على الفقرات الموجودة داخل إطار نص (شكل). يوضح لك هذا المثال البرمجي كيفية الحصول على تأثيرات الرسوم المتحركة في فقرة:
```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    ISequence sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();
    IAutoShape autoShape = (IAutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0);

    for (IParagraph paragraph : autoShape.getTextFrame().getParagraphs())
    {
        IEffect[] effects = sequence.getEffectsByParagraph(paragraph);

        if (effects.length > 0)
            System.out.println("Paragraph \"" + paragraph.getText() + "\" has " + effects[0].getType() + " effect.");
    }
} finally {
    pres.dispose();
}
```


## **الأسئلة الشائعة**

**كيف تختلف الرسوم المتحركة للنص عن انتقالات الشرائح، وهل يمكن دمجها؟**

تتحكم الرسوم المتحركة للنص في سلوك الكائن مع مرور الوقت على الشريحة، بينما تتحكم [الانتقالات](/slides/ar/java/slide-transition/) في كيفية تغيير الشرائح. هما منفصلان ويمكن استخدامها معًا؛ يتم تحديد ترتيب التشغيل بواسطة جدول زمني للرسوم المتحركة وإعدادات الانتقال.

**هل يتم الحفاظ على الرسوم المتحركة للنص عند التصدير إلى PDF أو صور؟**

لا. ملفات PDF والصور النقطية ثابتة، لذلك ستظهر حالة واحدة من الشريحة دون حركة. للحفاظ على الحركة، استخدم تصدير [فيديو](/slides/ar/java/convert-powerpoint-to-video/) أو [HTML](/slides/ar/java/export-to-html5/).

**هل تعمل الرسوم المتحركة للنص في القوالب وماستر الشرائح؟**

يتم توريث التأثيرات المطبقة على كائنات القالب/الماستر إلى الشرائح، لكن توقيتها وتفاعلها مع الرسوم المتحركة على مستوى الشريحة يعتمد على التسلسل النهائي في الشريحة.