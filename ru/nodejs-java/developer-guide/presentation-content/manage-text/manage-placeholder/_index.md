---
title: Управление заполнителем
type: docs
weight: 10
url: /ru/nodejs-java/manage-placeholder/
description: Изменение текста в заполнителе в слайдах PowerPoint с помощью JavaScript. Установка подсказочного текста в заполнителе в слайдах PowerPoint с помощью JavaScript.
---

## **Изменить текст в заполнителе**

Используя [Aspose.Slides for Node.js via Java](/slides/ru/nodejs-java/), вы можете находить и изменять заполнители на слайдах презентаций. Aspose.Slides позволяет вносить изменения в текст заполнителя.

**Требования**: Вам нужна презентация, содержащая заполнитель. Вы можете создать такую презентацию в стандартном приложении Microsoft PowerPoint.

Вот как использовать Aspose.Slides для замены текста в заполнителе в этой презентации:

1. Создайте экземпляр класса [`Presentation`](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) и передайте в него презентацию в качестве аргумента.
2. Получите ссылку на слайд по его индексу.
3. Пройдитесь по фигурам, чтобы найти заполнитель.
4. Приведите форму заполнителя к типу [`AutoShape`](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape) и измените текст, используя [`TextFrame`](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame), связанный с [`AutoShape`](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape).
5. Сохраните изменённую презентацию.

```javascript
// Создаёт экземпляр класса Presentation
var pres = new aspose.slides.Presentation("ReplacingText.pptx");
try {
    // Получает первый слайд
    var sld = pres.getSlides().get_Item(0);
    // Перебирает фигуры, чтобы найти заполнитель
    for (let i = 0; i < sld.getShapes().size(); i++) {
        let shp = sld.getShapes().get_Item(i);
        if (shp.getPlaceholder() != null) {
            // Изменяет текст в каждом заполнителе
            shp.getTextFrame().setText("This is Placeholder");
        }
    }
    // Сохраняет презентацию на диск
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Установить подсказочный текст в заполнитель**

Стандартные и готовые макеты содержат подсказочные тексты заполнителей, такие как ***Нажмите, чтобы добавить заголовок*** или ***Нажмите, чтобы добавить подзаголовок***. С помощью Aspose.Slides вы можете вставлять свои собственные подсказочные тексты в макеты заполнителей.

Этот JavaScript‑код показывает, как установить подсказочный текст в заполнитель:
```javascript
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    var slide = pres.getSlides().get_Item(0);
    // Перебирает слайд
    for (let i = 0; i < slide.getSlide().getShapes().size(); i++) {
        let shape = slide.getSlide().getShapes().get_Item(i);
        if ((shape.getPlaceholder() != null) && (java.instanceOf(shape, "com.aspose.slides.AutoShape"))) {
            var text = "";
            // PowerPoint отображает "Нажмите, чтобы добавить заголовок"
            if (shape.getPlaceholder().getType() == aspose.slides.PlaceholderType.CenteredTitle) {
                text = "Add Title";
            } else // Добавляет подзаголовок
            if (shape.getPlaceholder().getType() == aspose.slides.PlaceholderType.Subtitle) {
                text = "Add Subtitle";
            }
            shape.getTextFrame().setText(text);
            console.log("Placeholder with text: " + text);
        }
    }
    pres.save("Placeholders_PromptText.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Установить прозрачность изображения заполнителя**

Aspose.Slides позволяет задать прозрачность фонового изображения в текстовом заполнителе. Регулируя прозрачность картинки в таком кадре, вы можете выделить текст или изображение (в зависимости от цветов текста и картинки).

Этот JavaScript‑код демонстрирует, как установить прозрачность фонового изображения (внутри фигуры):
```javascript
var presentation = new aspose.slides.Presentation("example.pptx");
var shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
var operationCollection = shape.getFillFormat().getPictureFillFormat().getPicture().getImageTransform();
for (var i = 0; i < operationCollection.size(); i++) {
    if (java.instanceOf(operationCollection.get_Item(i), "com.aspose.slides.AlphaModulateFixed")) {
        var alphaModulate = operationCollection.get_Item(i);
        var currentValue = 100 - alphaModulate.getAmount();
        console.log("Current transparency value: " + currentValue);
        var alphaValue = 40;
        alphaModulate.setAmount(100 - alphaValue);
    }
}
presentation.save("example_out.pptx", aspose.slides.SaveFormat.Pptx);
```


## **Часто задаваемые вопросы**

**Что такое базовый заполнитель и чем он отличается от локальной фигуры на слайде?**

Базовый заполнитель — это исходная форма в макете или образце, от которой наследуется форма слайда: тип, положение и часть форматирования берутся из неё. Локальная фигура независима; если базового заполнителя нет, наследование не применяется.

**Как обновить все заголовки или подписи во всей презентации без обхода каждого слайда?**

Отредактируйте соответствующий заполнитель в макете или образце. Слайды, основанные на этих макетах/образце, автоматически унаследуют изменения.

**Как управлять стандартными заполнителями верхнего/нижнего колонтитула — датой и временем, номером слайда и текстом колонтитула?**

Используйте менеджеры HeaderFooter в нужной области (обычные слайды, макеты, образец, заметки/раздаточные материалы), чтобы включать или отключать эти заполнители и задавать их содержимое.