---
title: Получить границы текстовой части из презентаций в JavaScript
linktitle: Границы части
type: docs
weight: 47
url: /ru/nodejs-java/portion-bounds/
keywords:
- границы текстовой части
- текстовая часть
- часть текста
- координаты текста
- позиция текста
- PowerPoint
- презентация
- Node.js
- JavaScript
- Aspose.Slides
description: "Узнайте, как получить границы текстовой части в презентациях PowerPoint с помощью Aspose.Slides для Node.js через Java."
---
## **Обзор**

Текстовая часть представляет собой конкретный фрагмент текста внутри абзаца и позволяет работать с этим фрагментом независимо от окружающего содержимого. В Aspose.Slides части можно использовать, когда необходимо получить границы текстового фрагмента, применить форматирование только к части абзаца или управлять поведением текста на более детальном уровне.

В этой статье показано, как получить ограничивающий прямоугольник части, используя [Portion.getRect](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/portion/getrect/). Также показано, как получить координаты начала части, используя [Portion.getCoordinates](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/portion/getcoordinates/). Кроме того, в статье рассмотрены распространённые сценарии, связанные с частями, такие как применение гиперссылки к отдельному текстовому фрагменту, понимание того, как форматирование разрешается через часть, абзац, текстовый фрейм и наследование темы, а также обработка случаев, когда указанный шрифт недоступен.

## **Получить границы текстовой части**

Используйте [Portion.getRect](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/portion/getrect/) для получения ограничивающего прямоугольника текстовой части:

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

## **Получить координаты текстовой части**

Используйте [Portion.getCoordinates](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/portion/getcoordinates/) для получения координат начала текстовой части:

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

## **Вопросы и ответы**

**Могу ли я применить гиперссылку только к части текста в одном абзаце?**

Да, вы можете [назначить гиперссылку](/slides/ru/nodejs-java/manage-hyperlinks/) отдельной части; только этот фрагмент будет кликабельным, а не весь абзац.

**Как работает наследование стилей: что переопределяет часть, а что берётся из абзаца или текстового фрейма?**

Свойства уровня Portion имеют высший приоритет. Если свойство не задано у [Portion](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/portion/), Aspose.Slides берёт его из [Paragraph](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/paragraph/). Если оно не задано и там, Aspose.Slides использует стиль [TextFrame](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/textframe/) или [theme](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/theme/).

**Что происходит, если указанный для части шрифт отсутствует на целевом компьютере или сервере?**

[Правила замены шрифтов](/slides/ru/nodejs-java/font-selection-sequence/) применяются. Текст может перераспределиться: метрики, переносы и ширина могут измениться, что важно для точного позиционирования.

**Могу ли я задать прозрачность заливки текста или градиент для конкретной части независимо от остального абзаца?**

Да, цвет текста, заливка и прозрачность на уровне [Portion](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/portion/) могут отличаться от соседних фрагментов.