---
title: Управление SmartArt
type: docs
weight: 10
url: /ru/nodejs-java/manage-smartart/
---

## **Получить текст из SmartArt**
Теперь метод TextFrame был добавлен в класс [SmartArtShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtShape) и класс [SmartArtShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtShape) соответственно. Это свойство позволяет вам получить весь текст из [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt), если он содержит не только текст узлов. Следующий пример кода поможет вам получить текст из узла SmartArt.
```javascript
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    var slide = pres.getSlides().get_Item(0);
    var smartArt = slide.getShapes().get_Item(0);
    var smartArtNodes = smartArt.getAllNodes();
    
    for (let i = 0; i < smartArtNodes.size(); i++) {
        const smartArtNode = smartArtNodes.get_Item(i);
        for (let j = 0; j < smartArtNode.getShapes().size(); j++) {
            const nodeShape = smartArtNode.getShapes().get_Item(j);
            if (nodeShape.getTextFrame() != null) {
                console.log(nodeShape.getTextFrame().getText());
            }
        }
    }
    
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Изменить тип макета SmartArt**
Чтобы изменить тип макета [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt). Выполните следующие шаги:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
- Получите ссылку на слайд, используя его индекс.
- Добавьте [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#addSmartArt-float-float-float-float-int-) BasicBlockList.
- Измените [LayoutType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt#setLayout-int-) на BasicProcess.
- Сохраните презентацию в файл PPTX.
  В приведенном ниже примере мы добавили соединитель между двумя фигурами.
```javascript
var pres = new aspose.slides.Presentation();
try {
    // Добавить SmartArt BasicProcess
    var smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, aspose.slides.SmartArtLayoutType.BasicBlockList);
    // Сменить LayoutType на BasicProcess
    smart.setLayout(aspose.slides.SmartArtLayoutType.BasicProcess);
    // Сохранение презентации
    pres.save("ChangeSmartArtLayout_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Проверка свойства Hidden у SmartArt**
Обратите внимание: метод [SmartArtNode.isHidden()]((https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtNode#isHidden--)) возвращает true, если данный узел является скрытым в модели данных. Чтобы проверить свойство hidden у любого узла [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt). Выполните следующие действия:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
- Добавьте [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#addSmartArt-float-float-float-float-int-) RadialCycle.
- Добавьте узел к SmartArt.
- Проверьте свойство [isHidden](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtNode#isHidden--) .
- Сохраните презентацию в файл PPTX.

В приведенном ниже примере мы добавили соединитель между двумя фигурами.
```javascript
var pres = new aspose.slides.Presentation();
try {
    // Добавить SmartArt BasicProcess
    var smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, aspose.slides.SmartArtLayoutType.RadialCycle);
    // Добавить узел в SmartArt
    var node = smart.getAllNodes().addNode();
    // Проверить свойство isHidden
    var hidden = node.isHidden();// Возвращает true
    if (hidden) {
        // Выполнить некоторые действия или уведомления
    }
    // Сохранение презентации
    pres.save("CheckSmartArtHiddenProperty_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Получить или задать тип организационной схемы**
Методы [SmartArtNode.getOrganizationChartLayout()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtNode#getOrganizationChartLayout--) , [setOrganizationChartLayout(int)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtNode#setOrganizationChartLayout-int-) позволяют получить или задать тип организационной схемы, связанный с текущим узлом. Чтобы получить или задать тип организационной схемы, выполните следующие шаги:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
- Добавьте [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#addSmartArt-float-float-float-float-int-) на слайд.
- Получите или [задать тип организационной схемы](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtNode#setOrganizationChartLayout-int-).
- Сохраните презентацию в файл PPTX.
  В приведенном ниже примере мы добавили соединитель между двумя фигурами.
```javascript
var pres = new aspose.slides.Presentation();
try {
    // Добавить SmartArt BasicProcess
    var smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, aspose.slides.SmartArtLayoutType.OrganizationChart);
    // Получить или задать тип организационной схемы
    smart.getNodes().get_Item(0).setOrganizationChartLayout(aspose.slides.OrganizationChartLayoutType.LeftHanging);
    // Сохранение презентации
    pres.save("OrganizeChartLayoutType_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Создать Picture Organization Chart**
Aspose.Slides for Node.js via Java предоставляет простой API для создания PictureOrganization диаграмм простым способом. Чтобы создать диаграмму на слайде:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
1. Получите ссылку на слайд по его индексу.
1. Добавьте диаграмму с данными по умолчанию и нужным типом (ChartType.PictureOrganizationChart).
1. Запишите изменённую презентацию в файл PPTX

Следующий код используется для создания диаграммы.
```javascript
var pres = new aspose.slides.Presentation("test.pptx");
try {
    var smartArt = pres.getSlides().get_Item(0).getShapes().addSmartArt(0, 0, 400, 400, aspose.slides.SmartArtLayoutType.PictureOrganizationChart);
    pres.save("OrganizationChart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Получить или задать состояние SmartArt**
Чтобы изменить тип макета [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt). Выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
1. Добавьте [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#addSmartArt-float-float-float-float-int-) на слайд.
1. [Получить](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt#isReversed--) или [задать](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt#setReversed-boolean-) состояние диаграммы SmartArt.
1. Сохраните презентацию в файл PPTX.

Следующий код используется для создания диаграммы.
```javascript
// Создать экземпляр класса Presentation, представляющего файл PPTX
var pres = new aspose.slides.Presentation();
try {
    // Добавить SmartArt BasicProcess
    var smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, aspose.slides.SmartArtLayoutType.BasicProcess);
    // Получить или задать состояние диаграммы SmartArt
    smart.setReversed(true);
    var flag = smart.isReversed();
    // Сохранение презентации
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**Поддерживает ли SmartArt зеркальное отображение/реверсирование для RTL‑языков?**

Да. Метод [setReversed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartart/setreversed/) переключает направление диаграммы (LTR/RTL), если выбранный тип SmartArt поддерживает реверс.

**Как скопировать SmartArt на тот же слайд или в другую презентацию, сохранив форматирование?**

Вы можете [клонировать форму SmartArt](/slides/ru/nodejs-java/shape-manipulations/) через коллекцию фигур ([ShapeCollection.addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addclone/)) или [клонировать весь слайд](/slides/ru/nodejs-java/clone-slides/) с этой фигурой. Оба подхода сохраняют размер, позицию и стили.

**Как отрендерить SmartArt в растровое изображение для предварительного просмотра или веб‑экспорта?**

[Отрендерите слайд](/slides/ru/nodejs-java/convert-powerpoint-to-png/) (или всю презентацию) в PNG/JPEG через API, конвертирующий слайды/презентации в изображения — SmartArt будет отрисован как часть слайда.

**Как программно выбрать конкретный SmartArt на слайде, если их несколько?**

Обычно используют [альтернативный текст]((https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/setalternativetext/)) (Alt Text) или [setName](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/setname/) и затем ищут фигуру по этому атрибуту с помощью [Slide.getShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseslide/#getShapes), после чего проверяют тип, чтобы убедиться, что это [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartart/). Документация описывает типичные техники поиска и работы с фигурами.