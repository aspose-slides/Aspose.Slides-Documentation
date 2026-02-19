---
title: Гиперссылка
type: docs
weight: 130
url: /ru/androidjava/examples/elements/hyperlink/
keywords:
- пример кода
- гиперссылка
- PowerPoint
- OpenDocument
- презентация
- Android
- Java
- Aspose.Slides
description: "Добавляйте и управляйте гиперссылками в Aspose.Slides for Android: связывайте текст, фигуры и изображения, задавайте цели и действия для PPT, PPTX и ODP с примерами на Java."
---
Эта статья демонстрирует добавление, получение доступа, удаление и обновление гиперссылок на фигурах с использованием **Aspose.Slides for Android via Java**.

## **Добавить гиперссылку**
Создайте прямоугольную фигуру с гиперссылкой, указывающей на внешний веб-сайт.

```java
static void addHyperlink() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
        shape.getTextFrame().setText("Aspose");

        IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
        IPortion textPortion = paragraph.getPortions().get_Item(0);
        textPortion.getPortionFormat().setHyperlinkClick(new Hyperlink("https://www.aspose.com"));
    } finally {
        presentation.dispose();
    }
}
```

## **Получить гиперссылку**
Прочитайте информацию о гиперссылке из текстовой части фигуры.

```java
static void accessHyperlink() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
        shape.getTextFrame().setText("Aspose");

        IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
        IPortion textPortion = paragraph.getPortions().get_Item(0);
        textPortion.getPortionFormat().setHyperlinkClick(new Hyperlink("https://www.aspose.com"));

        IHyperlink hyperlink = textPortion.getPortionFormat().getHyperlinkClick();
    } finally {
        presentation.dispose();
    }
}
```

## **Удалить гиперссылку**
Очистите гиперссылку из текста фигуры.

```java
static void removeHyperlink() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
        shape.getTextFrame().setText("Aspose");

        IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
        IPortion textPortion = paragraph.getPortions().get_Item(0);
        textPortion.getPortionFormat().setHyperlinkClick(new Hyperlink("https://www.aspose.com"));

        textPortion.getPortionFormat().setHyperlinkClick(null);
    } finally {
        presentation.dispose();
    }
}
```

## **Обновить гиперссылку**
Измените назначение существующей гиперссылки. Используйте `HyperlinkManager` для изменения текста, уже содержащего гиперссылку, что имитирует безопасное обновление гиперссылок в PowerPoint.

```java
static void updateHyperlink() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
        shape.getTextFrame().setText("Aspose");

        IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
        IPortion textPortion = paragraph.getPortions().get_Item(0);
        textPortion.getPortionFormat().setHyperlinkClick(new Hyperlink("https://old.example.com"));

        // Изменение гиперссылки внутри существующего текста должно выполняться через
        // HyperlinkManager, а не прямую установку свойства.
        // Это имитирует безопасное обновление гиперссылок в PowerPoint.
        textPortion.getPortionFormat().getHyperlinkManager().setExternalHyperlinkClick("https://new.example.com");
    } finally {
        presentation.dispose();
    }
}
```