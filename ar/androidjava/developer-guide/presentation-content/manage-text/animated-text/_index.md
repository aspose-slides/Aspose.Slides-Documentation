---
title: تحريك نص PowerPoint على Android
linktitle: نص متحرك
type: docs
weight: 60
url: /ar/androidjava/animated-text/
keywords:
- نص متحرك
- تحريك النص
- فقرة متحركة
- تحريك الفقرة
- تأثير التحريك
- PowerPoint
- OpenDocument
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "إنشاء نص متحرك ديناميكي في عروض PowerPoint وOpenDocument التقديمية باستخدام Aspose.Slides لنظام Android، مع أمثلة شفرة Java محسّنة وسهلة المتابعة."
---

## **إضافة تأثيرات الرسوم المتحركة إلى الفقرات**

لقد أضفنا طريقة [**addEffect()**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Sequence#addEffect-com.aspose.slides.IParagraph-int-int-int-) إلى الفئات [**Sequence**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Sequence) و[**ISequence**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISequence). تتيح لك هذه الطريقة إضافة تأثيرات الرسوم المتحركة إلى فقرة واحدة. يظهر لك رمز العينة هذا كيفية إضافة تأثير رسوم متحركة إلى فقرة واحدة:
```java
Presentation presentation = new Presentation("Presentation.pptx");
try {
    // اختيار الفقرة لإضافة التأثير
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // إضافة تأثير Fly إلى الفقرة المحددة
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().
            addEffect(paragraph, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    presentation.save("AnimationEffectinParagraph.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```


## **الحصول على تأثيرات الرسوم المتحركة للفقرات**

قد تقرر معرفة تأثيرات الرسوم المتحركة المضافة إلى فقرة—على سبيل المثال، في سيناريو معين، قد ترغب في الحصول على تأثيرات الرسوم المتحركة في فقرة لأنك تخطط لتطبيق تلك التأثيرات على فقرة أو شكل آخر.

تتيح لك Aspose.Slides for Android عبر Java الحصول على جميع تأثيرات الرسوم المتحركة المطبقة على الفقرات الموجودة داخل إطار نص (شكل). يظهر لك رمز العينة هذا كيفية الحصول على تأثيرات الرسوم المتحركة في فقرة:
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


## **الأسئلة المتكررة**

**كيف تختلف الرسوم المتحركة للنص عن انتقالات الشرائح، وهل يمكن دمجهما؟**

تتحكم الرسوم المتحركة للنص في سلوك الكائن مع مرور الوقت على الشريحة، بينما [transitions](/slides/ar/androidjava/slide-transition/) تتحكم في كيفية تغير الشرائح. إنهما مستقلان ويمكن استخدامهما معًا؛ يتم تحديد ترتيب التشغيل بواسطة جدول زمني للرسوم المتحركة وإعدادات الانتقال.

**هل تُحافظ على الرسوم المتحركة للنص عند التصدير إلى PDF أو الصور؟**

لا. ملفات PDF والصور النقطية ثابتة، لذا سترى حالة واحدة للشرائح بدون حركة. للحفاظ على الحركة، استخدم تصدير [video](/slides/ar/androidjava/convert-powerpoint-to-video/) أو [HTML](/slides/ar/androidjava/export-to-html5/).

**هل تعمل الرسوم المتحركة للنص في التخطيطات وسطح الشريحة الرئيسي؟**

التأثيرات المطبقة على كائنات التخطيط/الماستر تُورّث إلى الشرائح، لكن توقيتها وتفاعلها مع الرسوم المتحركة على مستوى الشريحة يعتمد على التسلسل النهائي في الشريحة.