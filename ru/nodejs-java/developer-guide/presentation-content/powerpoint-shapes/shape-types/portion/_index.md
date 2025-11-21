---
title: Фрагмент
type: docs
weight: 70
url: /ru/nodejs-java/portion/
---

## **Получить координаты позиции Portion**
Метод [**getCoordinates()**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Portion#getCoordinates--) был добавлен в класс [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portion/), который позволяет получать координаты начала части.
```javascript
// Создать экземпляр класса Presentation, представляющего PPTX
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    // Перестраивание контекста презентации
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


## **FAQ**

**Можно ли применить гиперссылку только к части текста в одном абзаце?**

Да, вы можете [assign a hyperlink](/slides/ru/nodejs-java/manage-hyperlinks/) к отдельной части; только этот фрагмент будет кликабельным, а не весь абзац.

**Как работает наследование стилей: что переопределяет Portion и что берётся из Paragraph/TextFrame?**

Свойства уровня Portion имеют высший приоритет. Если свойство не задано для [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portion/), движок берёт его из [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/); если и там не задано, — из [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) или стиля [theme](https://reference.aspose.com/slides/nodejs-java/aspose.slides/theme/).

**Что происходит, если шрифт, указанный для Portion, отсутствует на целевой машине/сервере?**

Применяются [Font substitution rules](/slides/ru/nodejs-java/font-selection-sequence/). Текст может перераспределиться: могут измениться метрики, переносы и ширина, что важно для точного позиционирования.

**Можно ли задать прозрачность или градиент заливки текста только для Portion, независимо от остального абзаца?**

Да, цвет текста, заливка и прозрачность на уровне [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portion/) могут отличаться от соседних фрагментов.