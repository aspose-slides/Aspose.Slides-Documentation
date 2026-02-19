---
title: Гиперссылка
type: docs
weight: 130
url: /ru/nodejs-java/examples/elements/hyperlink/
keywords:
- пример кода
- гиперссылка
- PowerPoint
- OpenDocument
- презентация
- Node.js
- JavaScript
- Aspose.Slides
description: "Добавление и управление гиперссылками в Aspose.Slides for Node.js: связывание текста, фигур и изображений, установка целей и действий для PPT, PPTX и ODP с примерами."
---
Эта статья демонстрирует добавление, чтение, удаление и обновление гиперссылок на фигурах с использованием **Aspose.Slides for Node.js via Java**.

## **Add a Hyperlink**

Создайте прямоугольную фигуру с гиперссылкой, указывающей на внешний веб‑сайт.

```js
function addHyperlink() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 50);
        shape.getTextFrame().setText("Aspose");

        let paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
        let textPortion = paragraph.getPortions().get_Item(0);

        let hyperlink = new aspose.slides.Hyperlink("https://www.aspose.com");
        textPortion.getPortionFormat().setHyperlinkClick(hyperlink);

        presentation.save("hyperlink.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Access a Hyperlink**

Прочитайте гиперссылку из текстовой части фигуры.

```js
function accessHyperlink() {
    let presentation = new aspose.slides.Presentation("hyperlink.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Предполагая, что первая фигура содержит текст с гиперссылкой.
        let shape = slide.getShapes().get_Item(0);

        let paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
        let textPortion = paragraph.getPortions().get_Item(0);

        let hyperlink = textPortion.getPortionFormat().getHyperlinkClick();
    } finally {
        presentation.dispose();
    }
}
```

## **Remove a Hyperlink**

Очистите гиперссылку из текста фигуры.

```js
function removeHyperlink() {
    let presentation = new aspose.slides.Presentation("hyperlink.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Предполагая, что первая фигура содержит текст с гиперссылкой.
        let shape = slide.getShapes().get_Item(0);

        let paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
        let textPortion = paragraph.getPortions().get_Item(0);

        textPortion.getPortionFormat().setHyperlinkClick(null);

        presentation.save("hyperlink_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Update a Hyperlink**

Измените назначение существующей гиперссылки. Используйте `HyperlinkManager` для изменения текста, который уже содержит гиперссылку, что имитирует безопасное обновление гиперссылок в PowerPoint.

```js
function updateHyperlink() {
    let presentation = new aspose.slides.Presentation("hyperlink.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Предполагая, что первая фигура содержит текст с гиперссылкой.
        let shape = slide.getShapes().get_Item(0);

        let paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
        let textPortion = paragraph.getPortions().get_Item(0);

        // Изменение гиперссылки в существующем тексте должно выполняться через
        // HyperlinkManager, а не путем прямой установки свойства.
        // Это имитирует безопасное обновление гиперссылок в PowerPoint.
        textPortion.getPortionFormat().getHyperlinkManager().setExternalHyperlinkClick("https://new.example.com");

        presentation.save("hyperlink_updated.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```