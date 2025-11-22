---
title: جزء
type: docs
weight: 70
url: /ar/nodejs-java/portion/
---

## **الحصول على إحداثيات موضع الجزء**
[**getCoordinates()**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Portion#getCoordinates--) تم إضافة الطريقة إلى صنف [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portion/) الذي يسمح باسترجاع إحداثيات بداية الجزء.
```javascript
// إنشاء فئة Prseetation التي تمثل ملف PPTX
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    // إعادة تشكيل سياق العرض التقديمي
    var shape = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var textFrame = shape.getTextFrame();
    for (let i = 0; i < textFrame.getParagraphs().getCount(); i++) {
        const paragraph = textFrame.getParagraphs().get_Item(i);
        for (let j = 0; j < paragraph.getPortions().getCount(); j++) {
            const portion = paragraph.getPortions().get_Item(j);
            var point = portion.getCoordinates();
            console.log("X: " + point.x + " Y: " + point.y);
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **الأسئلة المتكررة**

**هل يمكنني تطبيق ارتباط تشعبي على جزء فقط من النص داخل فقرة واحدة؟**

نعم، يمكنك [تعيين ارتباط تشعبي](/slides/ar/nodejs-java/manage-hyperlinks/) لجزء منفرد؛ سيكون فقط هذا الجزء القابل للنقر، وليس الفقرة بأكملها.

**كيف يعمل وراثة الأنماط: ما الذي يتجاوزه الجزء، وما الذي يُستمد من الفقرة/إطار النص؟**

تملك خصائص المستوى الجزء أولوية أعلى. إذا لم يتم تعيين خاصية على الـ[Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portion/)، فإن المحرك يأخذها من الـ[Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/); إذا لم تُحدد هناك أيضًا، فإنه يحصل عليها من الـ[TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) أو نمط الـ[theme](https://reference.aspose.com/slides/nodejs-java/aspose.slides/theme/).

**ماذا يحدث إذا كان الخط المحدد للجزء غير موجود على الجهاز/الخادم المستهدف؟**

[قواعد استبدال الخطوط](/slides/ar/nodejs-java/font-selection-sequence/) تُطبق. قد يتدفق النص مجددًا: قد تتغير المقاييس، والقطع، والعرض، وهو ما يؤثر على الدقة في التموضع.

**هل يمكنني ضبط شفافية تعبئة النص أو تدرج لوني خاص بالجزء بشكل مستقل عن باقي الفقرة؟**

نعم، يمكن أن يختلف لون النص، والتعبئة، والشفافية على مستوى الـ[Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portion/) عن القطع المجاورة.