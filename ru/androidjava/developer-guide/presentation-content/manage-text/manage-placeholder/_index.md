---
title: Управление заполнителями презентации на Android
linktitle: Управление заполнителями
type: docs
weight: 10
url: /ru/androidjava/manage-placeholder/
keywords:
- заполнитель
- текстовый заполнитель
- заполнитель изображения
- заполнитель диаграммы
- текст подсказки
- PowerPoint
- OpenDocument
- презентация
- Android
- Java
- Aspose.Slides
description: "Без труда управлять заполнителями в Aspose.Slides для Android через Java: заменять текст, настраивать подсказки и задавать прозрачность изображений в PowerPoint и OpenDocument."
---

## **Изменить текст в заполнителе**
Using [Aspose.Slides for Android via Java](/slides/ru/androidjava/), you can find and modify placeholders on slides in presentations. Aspose.Slides allows you to make changes to the text in a placeholder.

**Prerequisite**: Вам нужна презентация, содержащая заполнитель. Вы можете создать такую презентацию в стандартном приложении Microsoft PowerPoint.

Вот как вы используете Aspose.Slides для замены текста в заполнителе в этой презентации:

1. Создайте экземпляр класса [`Presentation`](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) и передайте в него презентацию в качестве аргумента.
2. Получите ссылку на слайд по его индексу.
3. Пройдитесь по коллекции фигур, чтобы найти заполнитель.
4. Преобразуйте форму заполнителя к типу [`AutoShape`](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AutoShape) и измените текст с помощью [`TextFrame`](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrame), связанного с [`AutoShape`](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AutoShape).
5. Сохраните изменённую презентацию.

Этот код Java показывает, как изменить текст в заполнителе:
```java
// Создает экземпляр класса Presentation
Presentation pres = new Presentation("ReplacingText.pptx");
try {

    // Получает первый слайд
    ISlide sld = pres.getSlides().get_Item(0);

    // Итерирует по фигурам, чтобы найти заполнитель
    for (IShape shp : sld.getShapes()) 
    {
        if (shp.getPlaceholder() != null) {
            // Изменяет текст в каждом заполнителе
            ((IAutoShape) shp).getTextFrame().setText("This is Placeholder");
        }
    }

    // Сохраняет презентацию на диск
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Установить текст подсказки в заполнителе**
Standard and pre-built layouts contain placeholder prompt texts such as ***Click to add a title*** or ***Click to add a subtitle***. Using Aspose.Slides, you can insert your preferred prompt texts into placeholder layouts.

Этот код Java показывает, как задать текст подсказки в заполнителе:
```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);
    for (IShape shape : slide.getSlide().getShapes()) // Итерирует по слайду
    {
        if (shape.getPlaceholder() != null && shape instanceof AutoShape)
        {
            String text = "";
            if (shape.getPlaceholder().getType() == PlaceholderType.CenteredTitle) // PowerPoint отображает "Нажмите, чтобы добавить заголовок" 
            {
                text = "Add Title";
            }
            else if (shape.getPlaceholder().getType() == PlaceholderType.Subtitle) // Добавляет подзаголовок
            {
                text = "Add Subtitle";
            }

            ((IAutoShape)shape).getTextFrame().setText(text);
            System.out.println("Placeholder with text: " + text);
        }
    }

    pres.save("Placeholders_PromptText.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Установить прозрачность изображения заполнителя**
Aspose.Slides позволяет задавать прозрачность фонового изображения в текстовом заполнителе. Регулируя прозрачность изображения в таком кадре, вы можете выделить текст или изображение (в зависимости от цветов текста и изображения).

Этот код Java показывает, как установить прозрачность фонового изображения (внутри фигуры):
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
        System.out.println("Current transparency value: " + currentValue);

        int alphaValue = 40;
        alphaModulate.setAmount(100 - alphaValue);
    }
}

presentation.save("example_out.pptx", SaveFormat.Pptx);
```


## **FAQ**

**Что такое базовый заполнитель и чем он отличается от локальной формы на слайде?**

Базовый заполнитель — это исходная форма на макете или мастере, от которой наследуется форма слайда — тип, позиция и часть форматирования берутся из неё. Локальная форма независима; если базового заполнителя нет, наследование не применяется.

**Как обновить все заголовки или подписи во всей презентации без перебора каждого слайда?**

Отредактируйте соответствующий заполнитель на макете или мастере. Слайды, построенные на этих макетах/мастере, автоматически наследуют изменение.

**Как управлять стандартными заполнителями верхнего/нижнего колонтитула — датой и временем, номером слайда и текстом колонтитула?**

Используйте менеджеры HeaderFooter в соответствующей области (обычные слайды, макеты, мастер, примечания/раздаточные материалы), чтобы включать или отключать эти заполнители и задавать их содержимое.