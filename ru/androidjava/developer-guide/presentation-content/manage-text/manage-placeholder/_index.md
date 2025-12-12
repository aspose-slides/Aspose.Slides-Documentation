---
title: Управление заполняемыми элементами презентации на Android
linktitle: Управление заполняемыми элементами
type: docs
weight: 10
url: /ru/androidjava/manage-placeholder/
keywords:
- заполняемый элемент
- текстовый заполняемый элемент
- заполняемый элемент изображения
- заполняемый элемент диаграммы
- текст подсказки
- PowerPoint
- OpenDocument
- презентация
- Android
- Java
- Aspose.Slides
description: "Легко управлять заполняемыми элементами в Aspose.Slides для Android через Java: заменять текст, настраивать подсказки и задавать прозрачность изображений в PowerPoint и OpenDocument."
---

## **Изменение текста в заполняемом элементе**
Используя [Aspose.Slides для Android через Java](/slides/ru/androidjava/), вы можете находить и изменять заполняемые элементы на слайдах презентаций. Aspose.Slides позволяет вносить изменения в текст заполняемого элемента.

**Требования**: вам нужна презентация, содержащая заполняемый элемент. Такая презентация может быть создана в стандартном приложении Microsoft PowerPoint.

Вот как использовать Aspose.Slides для замены текста в заполняемом элементе этой презентации:

1. Создайте экземпляр класса [`Presentation`](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) и передайте ему презентацию в качестве аргумента.
2. Получите ссылку на слайд по его индексу.
3. Пройдитесь по фигурам, чтобы найти заполняемый элемент.
4. Преобразуйте форму заполняемого элемента к типу [`AutoShape`](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AutoShape) и измените текст с помощью [`TextFrame`](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrame), связанного с [`AutoShape`](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AutoShape).
5. Сохраните изменённую презентацию.

Этот Java‑код демонстрирует, как изменить текст в заполняемом элементе:
```java
// Создает экземпляр класса Presentation
Presentation pres = new Presentation("ReplacingText.pptx");
try {

    // Получает первый слайд
    ISlide sld = pres.getSlides().get_Item(0);

    // Проходит по фигурам, чтобы найти заполняющий элемент
    for (IShape shp : sld.getShapes()) 
    {
        if (shp.getPlaceholder() != null) {
            // Изменяет текст в каждом заполняющем элементе
            ((IAutoShape) shp).getTextFrame().setText("This is Placeholder");
        }
    }

    // Сохраняет презентацию на диск
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Установка текста‑подсказки в заполняемый элемент**
Стандартные и готовые макеты содержат подсказки‑тексты заполняемых элементов, такие как ***Click to add a title*** или ***Click to add a subtitle***. С помощью Aspose.Slides вы можете вставить свои подсказки‑тексты в макеты заполняемых элементов.

Этот Java‑код показывает, как установить текст‑подсказку в заполняемый элемент:
```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);
    for (IShape shape : slide.getSlide().getShapes()) // Итерирует по слайду
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


## **Установка прозрачности изображения в заполняемом элементе**

Aspose.Slides позволяет установить прозрачность фонового изображения в текстовом заполняемом элементе. Регулируя прозрачность картинки в таком кадре, вы можете выделить текст или изображение (в зависимости от цветов текста и картинки).

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

**Что такое базовый заполняемый элемент и чем он отличается от локальной фигуры на слайде?**

Базовый заполняемый элемент — это оригинальная фигура в макете или шаблоне, от которой наследуется фигура слайда — тип, позиция и часть форматирования берутся из неё. Локальная фигура независима; если базового заполняемого элемента нет, наследование не применяется.

**Как обновить все заголовки или подписи во всей презентации без обхода каждого слайда?**

Отредактируйте соответствующий заполняемый элемент в макете или шаблоне. Слайды, основанные на этих макетах/шаблоне, автоматически унаследуют изменения.

**Как управлять стандартными заполняемыми элементами заголовка/нижнего колонтитула — датой и временем, номером слайда и текстом нижнего колонтитула?**

Используйте менеджеры HeaderFooter в соответствующей области (обычные слайды, макеты, шаблон, заметки/раздаточные материалы), чтобы включать или отключать эти заполняемые элементы и задавать их содержимое.