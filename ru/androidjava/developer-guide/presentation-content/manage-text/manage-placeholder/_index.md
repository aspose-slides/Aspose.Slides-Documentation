---
title: Управление заполнительным текстом
type: docs
weight: 10
url: /androidjava/manage-placeholder/
description: Измените текст в заполнительном контейнере на слайдах PowerPoint с помощью Java. Установите текст подсказки в заполнительном контейнере на слайдах PowerPoint с помощью Java.
---

## **Изменить текст в заполнителе**
С помощью [Aspose.Slides для Android на Java](/slides/androidjava/) вы можете находить и модифицировать заполнители на слайдах в презентациях. Aspose.Slides позволяет вам вносить изменения в текст запятых.

**Предварительные условия**: Вам нужна презентация, содержащая заполнитель. Вы можете создать такую презентацию в стандартном приложении Microsoft PowerPoint.

Вот как вы можете использовать Aspose.Slides для замены текста в заполнителе в этой презентации:

1. Создайте экземпляр класса [`Presentation`](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) и передайте презентацию в качестве аргумента.
2. Получите ссылку на слайд через его индекс.
3. Переберите фигуры, чтобы найти заполнитель.
4. Приведите фигуру заполнителя к типу [`AutoShape`](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AutoShape) и измените текст с помощью [`TextFrame`](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrame), связанным с [`AutoShape`](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AutoShape).
5. Сохраните измененную презентацию.

Этот код на Java показывает, как изменить текст в заполнителе:

```java
// Создает экземпляр класса Presentation
Presentation pres = new Presentation("ReplacingText.pptx");
try {

    // Получает первый слайд
    ISlide sld = pres.getSlides().get_Item(0);

    // Перебирает фигуры, чтобы найти заполнитель
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

## **Установить текст подсказки в заполнитель**
Стандартные и предустановленные макеты содержат текст подсказок заполнителей, такие как ***Нажмите, чтобы добавить заголовок*** или ***Нажмите, чтобы добавить подзаголовок***. С помощью Aspose.Slides вы можете вставить предпочитаемые вами тексты подсказок в макеты заполнителей.

Этот код на Java показывает, как установить текст подсказки в заполнитель:

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

## **Установить прозрачность изображения заполнителя**

Aspose.Slides позволяет вам установить прозрачность фонового изображения в текстовом заполнителе. Регулируя прозрачность изображения в таком фрейме, вы можете подчеркнуть текст или изображение (в зависимости от цветов текста и изображения).

Этот код на Java показывает, как установить прозрачность для фонового изображения (внутри фигуры):

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