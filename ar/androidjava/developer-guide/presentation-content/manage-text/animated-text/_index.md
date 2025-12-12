---
title: تحريك نص PowerPoint على Android
linktitle: نص متحرك
type: docs
weight: 60
url: /ar/androidjava/animated-text/
keywords:
- نص متحرك
- رسوم متحركة للنص
- فقرة متحركة
- رسوم متحركة للفقرة
- تأثير الرسوم المتحركة
- PowerPoint
- OpenDocument
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "إنشاء نص متحرك ديناميكي في عروض PowerPoint و OpenDocument باستخدام Aspose.Slides لنظام Android، مع أمثلة شفرة Java سهلة المتابعة ومُحسّنة."
---

## **إضافة تأثيرات الرسوم المتحركة إلى الفقرات**

قمنا بإضافة الطريقة [**addEffect()**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Sequence#addEffect-com.aspose.slides.IParagraph-int-int-int-) إلى الفئتين [**Sequence**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Sequence) و[**ISequence**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISequence). تُتيح لك هذه الطريقة إضافة تأثيرات الرسوم المتحركة إلى فقرة واحدة. يُظهر لك هذا المثال البرمجي كيفية إضافة تأثير رسوم متحركة إلى فقرة واحدة:
```java
Presentation presentation = new Presentation("Presentation.pptx");
try {
    // اختيار الفقرة لإضافة تأثير
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // إضافة تأثير طيران للفقرة المحددة
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().
            addEffect(paragraph, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    presentation.save("AnimationEffectinParagraph.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```


## **الحصول على تأثيرات الرسوم المتحركة للفقرات**

قد تحتاج إلى معرفة تأثيرات الرسوم المتحركة المضافة إلى فقرة ما — على سبيل المثال، في أحد السيناريوهات، تريد الحصول على تأثيرات الرسوم المتحركة في فقرة لأنك تخطط لتطبيق تلك التأثيرات على فقرة أو شكل آخر.

يتيح لك Aspose.Slides لنظام Android عبر Java الحصول على جميع تأثيرات الرسوم المتحركة المطبقة على الفقرات الموجودة داخل إطار نص (شكل). يُظهر لك هذا المثال البرمجي كيفية الحصول على تأثيرات الرسوم المتحركة في فقرة:
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

**كيف تختلف الرسوم المتحركة للنص عن انتقالات الشرائح، وهل يمكن دمجهما؟**

تتحكم الرسوم المتحركة للنص في سلوك الكائن بمرور الوقت على الشريحة، بينما [الانتقالات](/slides/ar/androidjava/slide-transition/) تتحكم في كيفية تغيير الشرائح. إنهما مستقلان ويمكن استخدامهما معًا؛ يتم تحديد ترتيب التشغيل بواسطة خط الزمن للرسوم المتحركة وإعدادات الانتقال.

**هل يتم الحفاظ على الرسوم المتحركة للنص عند التصدير إلى PDF أو الصور؟**

لا. ملفات PDF والصور النقطية ثابتة، لذا ستظهر حالة واحدة فقط من الشريحة دون حركة. للحفاظ على الحركة، استخدم تصدير إلى [فيديو](/slides/ar/androidjava/convert-powerpoint-to-video/) أو [HTML](/slides/ar/androidjava/export-to-html5/).

**هل تعمل الرسوم المتحركة للنص في التخطيطات وماستر الشريحة؟**

التأثيرات المطبقة على كائنات التخطيط/الماستر تُورّث إلى الشرائح، لكن توقيتها وتفاعلها مع الرسوم المتحركة على مستوى الشريحة يعتمد على التسلسل النهائي في الشريحة.