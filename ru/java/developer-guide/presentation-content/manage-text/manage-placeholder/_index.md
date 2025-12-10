---
title: Управление заполнителями презентаций в Java
linktitle: Управление заполнителями
type: docs
weight: 10
url: /ru/java/manage-placeholder/
keywords:
- заполнитель
- текстовый заполнитель
- заполнитель изображения
- заполнитель диаграммы
- подсказочный текст
- PowerPoint
- OpenDocument
- презентация
- Java
- Aspose.Slides
description: "Легко управлять заполнителями в Aspose.Slides для Java: заменять текст, настраивать подсказки и задавать прозрачность изображений в PowerPoint и OpenDocument."
---

## **Изменить текст в заполнителе**
Используя [Aspose.Slides for Java](/slides/ru/java/), вы можете находить и изменять заполнители на слайдах в презентациях. Aspose.Slides позволяет вносить изменения в текст заполнителя.

**Требование**: вам нужна презентация, содержащая заполнитель. Вы можете создать такую презентацию в стандартном приложении Microsoft PowerPoint.

Так вы используете Aspose.Slides для замены текста в заполнителе в этой презентации:

1. Создайте экземпляр класса [`Presentation`](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) и передайте в него презентацию в качестве аргумента.  
2. Получите ссылку на слайд по его индексу.  
3. Пройдитесь по всем фигурам, чтобы найти заполнитель.  
4. Приведите форму заполнителя к типу [`AutoShape`](https://reference.aspose.com/slides/java/com.aspose.slides/AutoShape) и измените текст с помощью [`TextFrame`](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrame), связанным с [`AutoShape`](https://reference.aspose.com/slides/java/com.aspose.slides/AutoShape).  
5. Сохраните изменённую презентацию.

Этот Java‑код показывает, как изменить текст в заполнителе:
```java
// Создает экземпляр класса Presentation
Presentation pres = new Presentation("ReplacingText.pptx");
try {

    // Получает первый слайд
    ISlide sld = pres.getSlides().get_Item(0);

    // Проходит по фигурам, чтобы найти заполнитель
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


## **Установить подсказочный текст в заполнителе**
Стандартные и готовые шаблоны содержат подсказочные тексты заполнителей, такие как ***Click to add a title*** или ***Click to add a subtitle***. С помощью Aspose.Slides вы можете вставлять свои собственные подсказочные тексты в шаблоны заполнителей.

Этот Java‑код показывает, как установить подсказочный текст в заполнителе:
```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);
    for (IShape shape : slide.getSlide().getShapes()) // Перебирает слайд
    {
        if (shape.getPlaceholder() != null && shape instanceof AutoShape)
        {
            String text = "";
            if (shape.getPlaceholder().getType() == PlaceholderType.CenteredTitle) // PowerPoint отображает "Click to add title"
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


## **Установить прозрачность изображения в заполнителе**
Aspose.Slides позволяет установить прозрачность фонового изображения в текстовом заполнителе. Регулируя прозрачность картинки в такой рамке, вы можете выделять текст или изображение (в зависимости от цветов текста и картинки).

Этот Java‑код показывает, как установить прозрачность фоновой картинки (внутри фигуры):
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

**Что такое базовый заполнитель и чем он отличается от локальной фигуры на слайде?**

Базовый заполнитель — это оригинальная форма в макете или мастере, от которой наследуется форма слайда: тип, позиция и часть форматирования берутся из него. Локальная фигура независима; если базового заполнителя нет, наследование не применяется.

**Как можно обновить все заголовки или подписи во всей презентации без итерации по каждому слайду?**

Отредактируйте соответствующий заполнитель в макете или мастере. Слайды, основанные на этих макетах/мастере, автоматически унаследуют изменение.

**Как управлять стандартными заполнителями верхнего/нижнего колонтитула — датой и временем, номером слайда и текстом нижнего колонтитула?**

Используйте менеджеры HeaderFooter в соответствующей области (обычные слайды, макеты, мастер, заметки/раздаточные материалы), чтобы включать или отключать эти заполнители и задавать их содержимое.