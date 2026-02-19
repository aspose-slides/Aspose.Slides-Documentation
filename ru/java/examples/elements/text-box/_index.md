---
title: Текстовое поле
type: docs
weight: 40
url: /ru/java/examples/elements/text-box/
keywords:
- пример кода
- текстовое поле
- PowerPoint
- OpenDocument
- презентация
- Java
- Aspose.Slides
description: "Работайте с текстовыми полями в Aspose.Slides для Java: добавляйте, форматируйте, выравнивайте, переносите, автоматически подгоняйте и стилизуйте текст с помощью Java для презентаций PPT, PPTX и ODP."
---
В Aspose.Slides **текстовое поле** представляется как `AutoShape`. Практически любая фигура может содержать текст, но типичное текстовое поле не имеет заливки и границы и отображает только текст.

Это руководство объясняет, как программно добавлять, получать доступ к и удалять текстовые поля.

## **Добавить текстовое поле**

Текстовое поле — это просто `AutoShape` без заливки и границы и с некоторым форматированным текстом. Ниже показано, как его создать:

```java
public static void addTextBox() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Создайте прямоугольную фигуру (по умолчанию заполнена с границей и без текста).
        IAutoShape textBox = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 75, 150, 100);

        // Уберите заливку и границу, чтобы выглядеть как типичное текстовое поле.
        textBox.getFillFormat().setFillType(FillType.NoFill);
        textBox.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

        // Установите форматирование текста.
        IParagraph paragraph = textBox.getTextFrame().getParagraphs().get_Item(0);
        IPortionFormat textFormat = paragraph.getParagraphFormat().getDefaultPortionFormat();
        textFormat.getFillFormat().setFillType(FillType.Solid);
        textFormat.getFillFormat().getSolidFillColor().setColor(Color.BLACK);

        // Назначьте фактическое текстовое содержимое.
        textBox.getTextFrame().setText("Some text...");
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **Примечание:** Любой `AutoShape`, содержащий непустой `TextFrame`, может функционировать как текстовое поле.

## **Получить доступ к текстовым полям по содержимому**

Чтобы найти все текстовые поля, содержащие определённое ключевое слово (например, "Slide"), пройдите по фигурам и проверьте их текст:

```java
public static void accessTextBox() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        for (IShape shape : slide.getShapes()) {
            // Только AutoShape могут содержать редактируемый текст.
            if (shape instanceof IAutoShape) {
                IAutoShape autoShape = (IAutoShape) shape;
                if (autoShape.getTextFrame().getText().contains("Slide")) {
                    // Выполните нужные действия с соответствующим текстовым полем.
                }
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Удалить текстовые поля по содержимому**

В этом примере находятся и удаляются все текстовые поля на первом слайде, содержащие определённое ключевое слово:

```java
public static void removeTextBox() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        List<IShape> shapesToRemove = new ArrayList<IShape>();
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IAutoShape) {
                IAutoShape autoShape = (IAutoShape) shape;
                if (autoShape.getTextFrame().getText().contains("Slide")) {
                    shapesToRemove.add(shape);
                }
            }
        }

        for (IShape shape : shapesToRemove) {
            slide.getShapes().remove(shape);
        }
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **Совет:** Всегда создавайте копию коллекции фигур перед её изменением во время итерации, чтобы избежать ошибок модификации коллекции.