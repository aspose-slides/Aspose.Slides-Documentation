---
title: نص متحرك
type: docs
weight: 60
url: /ar/nodejs-java/animated-text/
keywords: "نص متحرك في PowerPoint"
description: "نص متحرك في PowerPoint باستخدام Java"
---

## **إضافة تأثيرات الحركة إلى الفقرات**

قمنا بإضافة طريقة [**addEffect()**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Sequence#addEffect-aspose.slides.IParagraph-int-int-int-) إلى فئتي [**Sequence**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Sequence) و [**Sequence**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Sequence). تسمح لك هذه الطريقة بإضافة تأثيرات الحركة إلى فقرة واحدة. يُظهر لك هذا الكود المثال كيفية إضافة تأثير حركة إلى فقرة واحدة:
```javascript
var presentation = new aspose.slides.Presentation("Presentation.pptx");
try {
    // حدد الفقرة لإضافة التأثير
    var autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    var paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    // إضافة تأثير تحريك Fly إلى الفقرة المحددة
    var effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().addEffect(paragraph, aspose.slides.EffectType.Fly, aspose.slides.EffectSubtype.Left, aspose.slides.EffectTriggerType.OnClick);
    presentation.save("AnimationEffectinParagraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```


## **الحصول على تأثيرات الحركة في الفقرات**

قد تقرّر معرفة تأثيرات الحركة المضافة إلى فقرة — على سبيل المثال، في سيناريو تريد فيه الحصول على تأثيرات الحركة في فقرة لأنك تخطط لتطبيق هذه التأثيرات على فقرة أو شكل آخر.

يتيح Aspose.Slides for Node.js via Java لك الحصول على جميع تأثيرات الحركة المطبقة على الفقرات الموجودة داخل إطار نص (شكل). يُظهر لك هذا الكود المثال كيفية الحصول على تأثيرات الحركة في فقرة:
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();
    var autoShape = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    for (let i = 0; i < autoShape.getTextFrame().getParagraphs().getCount(); i++) {
        let paragraph = autoShape.getTextFrame().getParagraphs().get_Item(i);
        var effects = sequence.getEffectsByParagraph(paragraph);
        if (effects.length > 0) {
            console.log("Paragraph \"" + paragraph.getText() + "\" has " + effects[0].getType() + " effect.");
        }
    }
} finally {
    pres.dispose();
}
```


## **الأسئلة الشائعة**

**كيف تختلف تحريكات النص عن انتقالات الشرائح، وهل يمكن دمجهما؟**

تتحكم تحريكات النص في سلوك الكائن بمرور الوقت على الشريحة، بينما [الانتقالات](/slides/ar/nodejs-java/slide-transition/) تتحكم في كيفية تغيير الشرائح. هما مستقلان ويمكن استخدامهما معًا؛ يتم تنظيم ترتيب التشغيل بواسطة جدول زمني التحريك وإعدادات الانتقال.

**هل تُحفظ تحريكات النص عند التصدير إلى PDF أو الصور؟**

لا. ملفات PDF والصور النقطية ثابتة، لذا سترى حالة واحدة من الشريحة بدون حركة. للحفاظ على الحركة، استخدم تصدير [فيديو](/slides/ar/nodejs-java/convert-powerpoint-to-video/) أو [HTML](/slides/ar/nodejs-java/export-to-html5/).

**هل تعمل تحريكات النص في التخطيطات والماستر؟**

التأثيرات المطبقة على كائنات التخطيط/الماستر تُورّث إلى الشرائح، لكن توقيتها وتفاعلها مع تحريكات مستوى الشريحة يعتمد على التسلسل النهائي على الشريحة.