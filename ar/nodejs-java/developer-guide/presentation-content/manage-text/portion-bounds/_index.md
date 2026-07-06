---
title: الحصول على حدود جزء النص من العروض التقديمية في JavaScript
linktitle: حدود الجزء
type: docs
weight: 47
url: /ar/nodejs-java/portion-bounds/
keywords:
- حدود جزء النص
- جزء النص
- جزء النص
- إحداثيات النص
- موضع النص
- PowerPoint
- عرض تقديمي
- Node.js
- JavaScript
- Aspose.Slides
description: "تعلم كيفية استرجاع حدود جزء النص في عروض PowerPoint التقديمية باستخدام Aspose.Slides لـ Node.js عبر Java."
---
## **نظرة عامة**

يمثل جزء النص شظية محددة من النص داخل فقرة ويتيح لك العمل مع هذه الشظية بشكل مستقل عن المحتوى المجاور. في Aspose.Slides، يمكن استخدام الأجزاء عندما تحتاج إلى استرجاع حدود شظية النص، تطبيق تنسيق على جزء من الفقرة فقط، أو التحكم في سلوك النص بمستوى أكثر تفصيلاً.

توضح هذه المقالة كيفية الحصول على المستطيل المحيط بالجزء باستخدام [Portion.getRect](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/portion/getrect/). كما توضح كيفية الحصول على إحداثيات بداية الجزء باستخدام [Portion.getCoordinates](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/portion/getcoordinates/). بالإضافة إلى ذلك، تسلط الضوء على سيناريوهات شائعة تتعلق بالأجزاء، مثل تطبيق ارتباط تشعبي على شظية نص واحدة، فهم كيفية حل التنسيق عبر الجزء والفقرة وإطار النص والموضوع، ومعالجة الحالات التي يكون فيها الخط المحدد غير متوفر.

## **الحصول على حدود جزء النص**

استخدم [Portion.getRect](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/portion/getrect/) لاسترجاع المستطيل المحيط بجزء النص:

```javascript
const presentation = new aspose.slides.Presentation("Shapes.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().get_Item(0);
    const paragraphs = shape.getTextFrame().getParagraphs();

    for (let paragraphIndex = 0; paragraphIndex < paragraphs.getCount(); paragraphIndex++) {
        const paragraph = paragraphs.get_Item(paragraphIndex);
        const portions = paragraph.getPortions();

        for (let portionIndex = 0; portionIndex < portions.getCount(); portionIndex++) {
            const portion = portions.get_Item(portionIndex);
            const rectangle = portion.getRect();
            console.log("X = " + rectangle.x + "; Y = " + rectangle.y + "; Width = " + rectangle.width + "; Height = " + rectangle.height);
        }
    }
} finally {
    presentation.dispose();
}
```

## **الحصول على إحداثيات جزء النص**

استخدم [Portion.getCoordinates](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/portion/getcoordinates/) لاسترجاع إحداثيات بداية جزء النص:

```javascript
const presentation = new aspose.slides.Presentation("Shapes.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().get_Item(0);
    const paragraphs = shape.getTextFrame().getParagraphs();

    for (let paragraphIndex = 0; paragraphIndex < paragraphs.getCount(); paragraphIndex++) {
        const paragraph = paragraphs.get_Item(paragraphIndex);
        const portions = paragraph.getPortions();

        for (let portionIndex = 0; portionIndex < portions.getCount(); portionIndex++) {
            const portion = portions.get_Item(portionIndex);
            const point = portion.getCoordinates();
            console.log("X = " + point.x + "; Y = " + point.y);
        }
    }
} finally {
    presentation.dispose();
}
```

## **الأسئلة الشائعة**

**هل يمكنني تطبيق ارتباط تشعبي على جزء فقط من النص داخل فقرة واحدة؟**

نعم، يمكنك [تعيين ارتباط تشعبي](/slides/ar/nodejs-java/manage-hyperlinks/) لجزء فردي؛ سيصبح هذا الجزء فقط قابلًا للنقر، وليس الفقرة بأكملها.

**كيف يعمل وراثة النمط: ماذا يتجاوز الجزء، وماذا يُستمد من الفقرة أو إطار النص؟**

لخصائص المستوى الخاص بالجزء أعلى أولوية. إذا لم تُحدَّد خاصية على [Portion](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/portion/)، فإن Aspose.Slides يأخذها من [Paragraph](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/paragraph/). وإذا لم تُحدَّد هناك أيضًا، يستخدم Aspose.Slides نمط [TextFrame](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/textframe/) أو [theme](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/theme/).

**ماذا يحدث إذا كان الخط المحدد للجزء غير موجود على الجهاز أو الخادم المستهدف؟**

تُطبق [قواعد استبدال الخط](/slides/ar/nodejs-java/font-selection-sequence/). قد يتغير تدفق النص: يمكن أن تتغير المقاييس، والكسرة، والعرض، مما يؤثر على التموضع الدقيق.

**هل يمكنني ضبط شفافية تعبئة النص أو تدرج لوني خاص بالجزء بشكل مستقل عن باقي الفقرة؟**

نعم، يمكن أن تختلف لون النص، والتعبئة، والشفافية على مستوى [Portion](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/portion/) عن الأجزاء المجاورة.