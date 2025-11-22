---
title: Группа
type: docs
weight: 40
url: /ru/nodejs-java/group/
---

## **Добавить групповую форму**
Aspose.Slides поддерживает работу с групповыми формами на слайдах. Эта возможность помогает разработчикам создавать более богатые презентации. Aspose.Slides for Node.js via Java поддерживает добавление и доступ к групповым формам. Можно добавлять фигуры в созданную групповую форму, заполняя её, либо получать доступ к любому свойству групповой формы. Чтобы добавить групповую форму на слайд с помощью Aspose.Slides for Node.js via Java:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
1. Получите ссылку на слайд, используя его Index.
1. Добавьте групповую форму на слайд.
1. Добавьте фигуры в созданную групповую форму.
1. Сохраните изменённую презентацию как файл PPTX.

Ниже приведён пример, добавляющий групповую форму на слайд.
```javascript
// Создать экземпляр класса Presentation
var pres = new aspose.slides.Presentation();
try {
    // Получить первый слайд
    var sld = pres.getSlides().get_Item(0);
    // Доступ к коллекции фигур слайдов
    var slideShapes = sld.getShapes();
    // Добавление групповой формы на слайд
    var groupShape = slideShapes.addGroupShape();
    // Добавление фигур внутри добавленной групповой формы
    groupShape.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 300, 100, 100, 100);
    groupShape.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 500, 100, 100, 100);
    groupShape.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 300, 300, 100, 100);
    groupShape.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 500, 300, 100, 100);
    // Добавление рамки групповой формы
    groupShape.setFrame(new aspose.slides.ShapeFrame(100, 300, 500, 40, aspose.slides.NullableBool.False, aspose.slides.NullableBool.False, 0));
    // Записать файл PPTX на диск
    pres.save("GroupShape.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Доступ к свойству AltText**
В этом разделе показаны простые шаги с примерами кода для добавления групповой формы и доступа к свойству AltText групповых форм на слайдах. Чтобы получить AltText групповой формы на слайде с помощью Aspose.Slides for Node.js via Java:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation), представляющего файл PPTX.
1. Получите ссылку на слайд, используя его Index.
1. Доступ к коллекции фигур слайдов.
1. Доступ к групповой форме.
1. Вызовите свойство [getAlternativeText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#getAlternativeText--) .

Ниже приведён пример, получающий альтернативный текст групповой формы.
```javascript
// Создать экземпляр класса Presentation, представляющего файл PPTX
var pres = new aspose.slides.Presentation("AltText.pptx");
try {
    // Получить первый слайд
    var sld = pres.getSlides().get_Item(0);
    for (var i = 0; i < sld.getShapes().size(); i++) {
        // Доступ к коллекции фигур слайдов
        var shape = sld.getShapes().get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.GroupShape")) {
            // Получение групповой формы.
            var grphShape = shape;
            for (var j = 0; j < grphShape.getShapes().size(); j++) {
                var shape2 = grphShape.getShapes().get_Item(j);
                // Доступ к свойству AltText
                console.log(shape2.getAlternativeText());
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**Поддерживается ли вложенное группирование (группа внутри группы)?**

Да. [GroupShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshape/) имеет метод [getParentGroup](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/getparentgroup/), который напрямую указывает на поддержку иерархии (группа может быть дочерней другой группы).

**Как контролировать порядок Z группы относительно других объектов на слайде?**

Используйте метод [getZOrderPosition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/getzorderposition/) класса [GroupShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshape/) для проверки её позиции в стеке отображения.

**Можно ли запретить перемещение/редактирование/разгруппировку?**

Да. Раздел блокировки группы доступен через [GroupShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshape/getgroupshapelock/), который позволяет ограничить операции над объектом.