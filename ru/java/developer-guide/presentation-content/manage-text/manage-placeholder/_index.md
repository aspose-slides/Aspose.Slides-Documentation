---
title: Управление заполнителем
type: docs
weight: 10
url: /java/manage-placeholder/
description: Изменение текста в заполнителе на слайдах PowerPoint с использованием Java. Установите текст подсказки в заполнителе на слайдах PowerPoint с использованием Java.
---

## **Изменение текста в заполнителе**
С помощью [Aspose.Slides для Java](/slides/java/) вы можете находить и изменять заполнители на слайдах в презентациях. Aspose.Slides позволяет вносить изменения в текст заполнителя.

**Предварительное условие**: Вам нужна презентация, которая содержит заполнитель. Вы можете создать такую презентацию в стандартном приложении Microsoft PowerPoint.

Вот как использовать Aspose.Slides для замены текста в заполнителе в этой презентации:

1. Инстанцировать класс [`Presentation`](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) и передать презентацию в качестве аргумента.
2. Получить ссылку на слайд через его индекс.
3. Перебирать формы, чтобы найти заполнитель.
4. Привести форму заполнителя к типу [`AutoShape`](https://reference.aspose.com/slides/java/com.aspose.slides/AutoShape) и изменить текст с помощью [`TextFrame`](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrame), связанного с [`AutoShape`](https://reference.aspose.com/slides/java/com.aspose.slides/AutoShape).
5. Сохранить изменённую презентацию.

Этот код на Java показывает, как изменить текст в заполнителе:

```java
// Инстанцирует класс Presentation
Presentation pres = new Presentation("ReplacingText.pptx");
try {

    // Получает доступ к первому слайду
    ISlide sld = pres.getSlides().get_Item(0);

    // Перебирает формы, чтобы найти заполнитель
    for (IShape shp : sld.getShapes()) 
    {
        if (shp.getPlaceholder() != null) {
            // Изменяет текст в каждом заполнителе
            ((IAutoShape) shp).getTextFrame().setText("Это заполнитель");
        }
    }

    // Сохраняет презентацию на диск
    pres.save("output_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Установка текста подсказки в заполнителе**
Стандартные и предварительно созданные макеты содержат текст подсказки для заполнителей, такой как ***Нажмите, чтобы добавить заголовок*** или ***Нажмите, чтобы добавить подзаголовок***. С помощью Aspose.Slides вы можете вставить свой предпочтительный текст подсказки в макеты заполнителей.

Этот код на Java показывает, как установить текст подсказки в заполнителе:

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);
    for (IShape shape : slide.getSlide().getShapes()) // Перебирает слайд
    {
        if (shape.getPlaceholder() != null && shape instanceof AutoShape)
        {
            String text = "";
            if (shape.getPlaceholder().getType() == PlaceholderType.CenteredTitle) // PowerPoint отображает "Нажмите, чтобы добавить заголовок" 
            {
                text = "Добавить заголовок";
            }
            else if (shape.getPlaceholder().getType() == PlaceholderType.Subtitle) // Добавляет подзаголовок
            {
                text = "Добавить подзаголовок";
            }

            ((IAutoShape)shape).getTextFrame().setText(text);
            System.out.println("Заполнитель с текстом: " + text);
        }
    }

    pres.save("Placeholders_PromptText.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Установка прозрачности изображения в заполнителе**

Aspose.Slides позволяет устанавливать прозрачность фона изображения в текстовом заполнителе. Настраивая прозрачность изображения в такой рамке, вы можете выделить текст или изображение (в зависимости от цветов текста и изображения).

Этот код на Java показывает, как установить прозрачность для фона изображения (внутри формы):

```java
Presentation presentation = new Presentation("example.pptx");

IAutoShape shape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

IImageTransformOperationCollection operationCollection = shape.getFillFormat().getPictureFillFormat().getPicture().getImageTransform();
for (int i = 0; i < operationCollection.size(); i++)
{
    if(operationCollection.get_Item(i) instanceof AlphaModulateFixed)
    {
        AlphaModulateFixed alphaModulate = (AlphaModulateFixed)operationCollection.get_Item(i);
        float currentValue = 100 - alphaModulate.getAmount();
        System.out.println("Текущее значение прозрачности: " + currentValue);

        int alphaValue = 40;
        alphaModulate.setAmount(100 - alphaValue);
    }
}

presentation.save("example_out.pptx", SaveFormat.Pptx);
```