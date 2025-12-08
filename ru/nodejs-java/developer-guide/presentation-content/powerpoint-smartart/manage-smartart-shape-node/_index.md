---
title: Создание или управление узлом формы SmartArt в PowerPoint на JavaScript
linktitle: Управление узлом формы SmartArt
type: docs
weight: 30
url: /ru/nodejs-java/manage-smartart-shape-node/
keywords: узлы smartart, позиция smartart, удалить smartart, добавление узлов smartart, презентация PowerPoint, PowerPoint Java, API JavaScript для PowerPoint
description: Управление узлом smartart и дочерними узлами в презентациях PowerPoint на JavaScript
---

## **Добавление узла SmartArt в презентацию PowerPoint с помощью JavaScript**
Aspose.Slides for Node.js via Java предоставил самый простой API для управления фигурами SmartArt самым удобным способом. Приведенный ниже пример кода поможет добавить узел и дочерний узел в фигуру SmartArt.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) и загрузите презентацию с фигурой SmartArt.
1. Получите ссылку на первый слайд, используя его индекс.
1. Пройдитесь по всем фигурам внутри первого слайда.
1. Проверьте, является ли фигура типом [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt) и приведите выбранную фигуру к типу [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt), если это SmartArt.
1. [Добавьте новый узел](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtNodeCollection#addNode--) в фигуру SmartArt [**NodeCollection**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt#getAllNodes--) и задайте текст в TextFrame.
1. Теперь, [добавьте](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtNodeCollection#addNode--) [**дочерний узел**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtNode#getChildNodes--) в недавно добавленный узел [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt) и задайте текст в TextFrame.
1. Сохраните презентацию.
```javascript
// Загрузить нужную презентацию
var pres = new aspose.slides.Presentation("SimpleSmartArt.pptx");
try {
    // Пройти по всем фигурам на первом слайде
    for (let i = 0; i < pres.getSlides().get_Item(0).getShapes().size(); i++) {
        let shape = pres.getSlides().get_Item(0).getShapes().get_Item(i);
        // Проверить, является ли фигура типом SmartArt
        if (java.instanceOf(shape, "com.aspose.slides.SmartArt")) {
            // Привести тип фигуры к SmartArt
            var smart = shape;
            // Добавление нового узла SmartArt
            var TemNode = smart.getAllNodes().addNode();
            // Добавление текста
            TemNode.getTextFrame().setText("Test");
            // Добавление нового дочернего узла в родительском узле. Он будет добавлен в конец коллекции
            var newNode = TemNode.getChildNodes().addNode();
            // Добавление текста
            newNode.getTextFrame().setText("New Node Added");
        }
    }
    // Сохранение презентации
    pres.save("AddSmartArtNode.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Добавление узла SmartArt в определённой позиции**
В следующем примере кода мы объяснили, как добавить дочерние узлы, принадлежащие соответствующим узлам фигуры SmartArt, в определённой позиции.

1. Создайте экземпляр класса Presentation.
1. Получите ссылку на первый слайд, используя его индекс.
1. Добавьте в выбранный слайд фигуру [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt) типа [**StackedList**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtLayoutType#StackedList).
1. Получите доступ к первому узлу добавленной фигуры SmartArt.
1. Теперь добавьте [**дочерний узел**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtNode#getChildNodes--) для выбранного [**узла**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtNode) в позиции 2 и задайте его текст.
1. Сохраните презентацию
```javascript
// Создание экземпляра презентации
var pres = new aspose.slides.Presentation();
try {
    // Получение слайда презентации
    var slide = pres.getSlides().get_Item(0);
    // Добавление Smart Art IShape
    var smart = slide.getShapes().addSmartArt(0, 0, 400, 400, aspose.slides.SmartArtLayoutType.StackedList);
    // Доступ к узлу SmartArt по индексу 0
    var node = smart.getAllNodes().get_Item(0);
    // Добавление нового дочернего узла на позицию 2 в родительском узле
    var chNode = node.getChildNodes().addNodeByPosition(2);
    // Добавить текст
    chNode.getTextFrame().setText("Sample Text Added");
    // Сохранить презентацию
    pres.save("AddSmartArtNodeByPosition.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Доступ к узлу SmartArt в презентации PowerPoint с помощью JavaScript**
В следующем примере кода будет продемонстрировано, как получить доступ к узлам внутри фигуры SmartArt. Обратите внимание, что тип LayoutType у SmartArt только для чтения и задаётся только при добавлении фигуры SmartArt.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) и загрузите презентацию с фигурой SmartArt.
1. Получите ссылку на первый слайд, используя его индекс.
1. Пройдитесь по всем фигурам внутри первого слайда.
1. Проверьте, является ли фигура типом [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt) и приведите выбранную фигуру к типу [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt), если это SmartArt.
1. Пройдитесь по всем [**узлам**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt#getAllNodes--) внутри фигуры SmartArt.
1. Получите и отобразите информацию, такую как позиция узла SmartArt, уровень и текст.
```javascript
// Создание экземпляра класса Presentation
var pres = new aspose.slides.Presentation("SmartArtShape.pptx");
try {
    // Получить первый слайд
    var slide = pres.getSlides().get_Item(0);
    // Обойти каждую фигуру на первом слайде
    for (let i = 0; i < slide.getShapes().size(); i++) {
        let shape = slide.getShapes().get_Item(i);
        // Проверить, является ли фигура типом SmartArt
        if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
            // Привести тип фигуры к SmartArt
            var smart = shape;
            // Обойти все узлы внутри SmartArt
            for (var j = 0; j < smart.getAllNodes().size(); j++) {
                // Доступ к узлу SmartArt по индексу i
                var node = smart.getAllNodes().get_Item(j);
                // Вывод параметров узла SmartArt
                console.log(node.getTextFrame().getText() + " " + node.getLevel() + " " + node.getPosition());
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Доступ к дочернему узлу SmartArt**
В следующем примере кода будет продемонстрировано, как получить доступ к дочерним узлам, принадлежащим соответствующим узлам фигуры SmartArt.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) и загрузите презентацию с фигурой SmartArt.
1. Получите ссылку на первый слайд, используя его индекс.
1. Пройдитесь по всем фигурам внутри первого слайда.
1. Проверьте, является ли фигура типом [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt) и приведите выбранную фигуру к типу [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt), если это SmartArt.
1. Пройдитесь по всем [**узлам**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt#getAllNodes--) внутри фигуры SmartArt.
1. Для каждого выбранного узла [**Node**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtNode) пройдитесь по всем [**дочерним узлам**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtNode#getChildNodes--) внутри него.
1. Получите и отобразите информацию, такую как позиция [**дочернего узла**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtNode#getChildNodes--) , уровень и текст.
```javascript
// Создание экземпляра класса Presentation
var pres = new aspose.slides.Presentation("AccessChildNodes.pptx");
try {
    // Получить первый слайд
    var slide = pres.getSlides().get_Item(0);
    // Пройти по всем фигурам внутри первого слайда
    for (let s = 0; s < slide.getShapes().size(); s++) {
        let shape = slide.getShapes().get_Item(s);
        // Проверить, является ли фигура типом SmartArt
        if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
            // Привести тип фигуры к SmartArt
            var smart = shape;
            // Пройти по всем узлам внутри SmartArt
            for (var i = 0; i < smart.getAllNodes().size(); i++) {
                // Доступ к узлу SmartArt по индексу i
                var node0 = smart.getAllNodes().get_Item(i);
                // Обход дочерних узлов в узле SmartArt по индексу i
                for (var j = 0; j < node0.getChildNodes().size(); j++) {
                    // Доступ к дочернему узлу в узле SmartArt
                    var node = node0.getChildNodes().get_Item(j);
                    // Вывод параметров дочернего узла SmartArt
                    console.log("j = " + j + ", Text = " + node.getTextFrame().getText() + ",  Level = " + node.getLevel() + ", Position = " + node.getPosition());
                }
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Доступ к дочернему узлу SmartArt в определённой позиции**
В этом примере мы научимся получать доступ к дочерним узлам в конкретных позициях, принадлежащих соответствующим узлам фигуры SmartArt.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation).
1. Получите ссылку на первый слайд, используя его индекс.
1. Добавьте в слайд фигуру SmartArt типа [**StackedList**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtLayoutType#StackedList).
1. Получите доступ к добавленной фигуре SmartArt.
1. Получите узел с индексом 0 в этой фигуре.
1. Теперь получите [**дочерний узел**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtNode#getChildNodes--) в позиции 1 для выбранного узла SmartArt, используя метод **get_Item()**.
1. Получите и отобразите информацию, такую как позиция [**дочернего узла**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtNode#getChildNodes--) , уровень и текст.
```javascript
// Создание экземпляра презентации
var pres = new aspose.slides.Presentation();
try {
    // Получить первый слайд
    var slide = pres.getSlides().get_Item(0);
    // Добавление фигуры SmartArt на первый слайд
    var smart = slide.getShapes().addSmartArt(0, 0, 400, 400, aspose.slides.SmartArtLayoutType.StackedList);
    // Доступ к узлу SmartArt по индексу 0
    var node = smart.getAllNodes().get_Item(0);
    // Получение дочернего узла в родительском узле на позиции 1
    var position = 1;
    var chNode = node.getChildNodes().get_Item(position);
    // Вывод параметров дочернего узла SmartArt
    console.log("Text = " + chNode.getTextFrame().getText() + ",  Level = " + chNode.getLevel() + ", Position = " + chNode.getPosition());
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Удаление узла SmartArt в презентации PowerPoint с помощью JavaScript**
В этом примере мы научимся удалять узлы внутри фигуры SmartArt.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) и загрузите презентацию с фигурой SmartArt.
1. Получите ссылку на первый слайд, используя его индекс.
1. Пройдитесь по всем фигурам внутри первого слайда.
1. Проверьте, является ли фигура типом [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt) и приведите выбранную фигуру к типу [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt), если это SmartArt.
1. Проверьте, содержит ли SmartArt более 0 узлов.
1. Выберите узел SmartArt, который необходимо удалить.
1. Теперь удалите выбранный узел с помощью метода [**RemoveNode**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtNodeCollection#removeNode-aspose.slides.ISmartArtNode-).
1. Сохраните презентацию.
```javascript
// Загрузить нужную презентацию
var pres = new aspose.slides.Presentation("AddSmartArtNode.pptx");
try {
    // Пройти по всем фигурам на первом слайде
    for (let i = 0; i < pres.getSlides().get_Item(0).getShapes().size(); i++) {
        let shape = pres.getSlides().get_Item(0).getShapes().get_Item(i);
        // Проверить, является ли фигура типом SmartArt
        if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
            // Привести тип фигуры к SmartArt
            var smart = shape;
            if (smart.getAllNodes().size() > 0) {
                // Доступ к узлу SmartArt по индексу 0
                var node = smart.getAllNodes().get_Item(0);
                // Удаление выбранного узла
                smart.getAllNodes().removeNode(node);
            }
        }
    }
    // Сохранить презентацию
    pres.save("RemoveSmartArtNode.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Удаление узла SmartArt в определённой позиции**
В этом примере мы научимся удалять узлы внутри фигуры SmartArt в конкретной позиции.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) и загрузите презентацию с фигурой SmartArt.
1. Получите ссылку на первый слайд, используя его индекс.
1. Пройдитесь по всем фигурам внутри первого слайда.
1. Проверьте, является ли фигура типом [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt) и приведите выбранную фигуру к типу [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt), если это SmartArt.
1. Выберите узел фигуры SmartArt с индексом 0.
1. Теперь проверьте, содержит ли выбранный узел SmartArt более 2 дочерних узла.
1. Теперь удалите узел в **позиции 1** с помощью метода [**RemoveNode**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtNodeCollection#removeNode-int-).
1. Сохраните презентацию.
```javascript
// Загрузить нужную презентацию
var pres = new aspose.slides.Presentation("AddSmartArtNode.pptx");
try {
    // Пройти по всем фигурам на первом слайде
    for (let i = 0; i < pres.getSlides().get_Item(0).getShapes().size(); i++) {
        let shape = pres.getSlides().get_Item(0).getShapes().get_Item(i);
        // Проверить, является ли фигура типом SmartArt
        if (java.instanceOf(shape, "com.aspose.slides.SmartArt")) {
            // Привести тип фигуры к SmartArt
            var smart = shape;
            if (smart.getAllNodes().size() > 0) {
                // Доступ к узлу SmartArt по индексу 0
                var node = smart.getAllNodes().get_Item(0);
                if (node.getChildNodes().size() >= 2) {
                    // Удаление дочернего узла на позиции 1
                    node.getChildNodes().removeNode(1);
                }
            }
        }
    }
    // Сохранить презентацию
    pres.save("RemoveSmartArtNodeByPosition.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Установка пользовательской позиции для дочернего узла в SmartArt**
Теперь Aspose.Slides for Node.js via Java поддерживает установку свойств [SmartArtShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtShape) [X](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#setX-float-) и [Y](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#setY-float-). Ниже показан фрагмент кода, который задаёт пользовательскую позицию, размер и вращение SmartArtShape; обратите внимание, что добавление новых узлов приводит к пересчету позиций и размеров всех узлов. При пользовательских настройках позиции пользователь может разместить узлы согласно требованиям.
```javascript
// Создание экземпляра класса Presentation
var pres = new aspose.slides.Presentation("SimpleSmartArt.pptx");
try {
    var smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(20, 20, 600, 500, aspose.slides.SmartArtLayoutType.OrganizationChart);
    // Переместить фигуру SmartArt в новое положение
    var node = smart.getAllNodes().get_Item(1);
    var shape = node.getShapes().get_Item(1);
    shape.setX(shape.getX() + (shape.getWidth() * 2));
    shape.setY(shape.getY() - (shape.getHeight() * 2));
    // Изменить ширины фигуры SmartArt
    node = smart.getAllNodes().get_Item(2);
    shape = node.getShapes().get_Item(1);
    shape.setWidth(shape.getWidth() + (shape.getWidth() * 2));
    // Изменить высоту фигуры SmartArt
    node = smart.getAllNodes().get_Item(3);
    shape = node.getShapes().get_Item(1);
    shape.setHeight(shape.getHeight() + (shape.getHeight() * 2));
    // Изменить поворот фигуры SmartArt
    node = smart.getAllNodes().get_Item(4);
    shape = node.getShapes().get_Item(1);
    shape.setRotation(90);
    pres.save("SmartArt.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


## **Проверка узла‑помощника**
{{% alert color="primary" %}} 

В этой статье мы подробнее изучим возможности фигур SmartArt, добавленных в слайды презентаций программно с помощью Aspose.Slides for Node.js via Java.

{{% /alert %}} 

Мы будем использовать следующую исходную фигуру SmartArt для наших исследований в разных разделах этой статьи.

|![todo:image_alt_text](https://i.imgur.com/FItwczY.png)|
| :- |
|**Рисунок: Исходная фигура SmartArt в слайде**|

В следующем примере кода мы изучим, как определить **узлы‑помощники** в коллекции узлов SmartArt и изменить их.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) и загрузите презентацию с фигурой SmartArt.
1. Получите ссылку на второй слайд, используя его индекс.
1. Пройдитесь по всем фигурам внутри первого слайда.
1. Проверьте, является ли фигура типом [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt) и приведите выбранную фигуру к типу [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt), если это SmartArt.
1. Пройдитесь по всем узлам внутри фигуры SmartArt и проверьте, являются ли они [**узлами‑помощниками**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtNode#isAssistant--).
1. Измените статус узла‑помощника на обычный узел.
1. Сохраните презентацию.
```javascript
// Создание экземпляра презентации
var pres = new aspose.slides.Presentation("AddNodes.pptx");
try {
    // Обход всех фигур на первом слайде
    for (let i = 0; i < pres.getSlides().get_Item(0).getShapes().size(); i++) {
        let shape = pres.getSlides().get_Item(0).getShapes().get_Item(i);
        // Проверить, является ли фигура типом SmartArt
        if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
            // Привести тип фигуры к SmartArt
            var smart = shape;
            // Обход всех узлов фигуры SmartArt
            for (var j = 0; j < smart.getAllNodes().size(); j++) {
                var node = smart.getAllNodes().get_Item(j);
                // Проверить, является ли узел помощником
                if (node.isAssistant()) {
                    // Установить свойство Assistant узла в false и сделать его обычным узлом
                    node.isAssistant();
                }
            }
        }
    }
    // Сохранить презентацию
    pres.save("ChangeAssitantNode.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


|![todo:image_alt_text](https://i.imgur.com/qpAl4rN.png)|
| :- |
|**Рисунок: Узлы‑помощники изменены в фигуре SmartArt внутри слайда**|

## **Установка формата заливки узла**
Aspose.Slides for Node.js via Java позволяет добавлять пользовательские фигуры SmartArt и задавать их формат заливки. В этой статье объясняется, как создавать и получать доступ к фигурам SmartArt и задавать их формат заливки с помощью Aspose.Slides for Node.js via Java.

Пожалуйста, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation).
1. Получите ссылку на слайд, используя его индекс.
1. Добавьте фигуру [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt), задав её [**LayoutType**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtLayoutType#ClosedChevronProcess).
1. Задайте [**FillFormat**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#getFillFormat--) для узлов фигуры SmartArt.
1. Запишите изменённую презентацию в файл PPTX.
```javascript
// Создание экземпляра презентации
var pres = new aspose.slides.Presentation();
try {
    // Получение слайда
    var slide = pres.getSlides().get_Item(0);
    // Добавление фигуры SmartArt и узлов
    var chevron = slide.getShapes().addSmartArt(10, 10, 800, 60, aspose.slides.SmartArtLayoutType.ClosedChevronProcess);
    var node = chevron.getAllNodes().addNode();
    node.getTextFrame().setText("Some text");
    // Установка цвета заливки узла
    for (let i = 0; i < node.getShapes().size(); i++) {
        let item = node.getShapes().get_Item(i);
        item.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        item.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    }
    // Сохранение презентации
    pres.save("TestSmart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Создание миниатюры дочернего узла SmartArt**
Разработчики могут создать миниатюру дочернего узла SmartArt, выполнив следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation).
1. [Добавьте SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtNodeCollection#addNode--).
1. Получите ссылку на узел, используя его индекс.
1. Получите изображение миниатюры.
1. Сохраните изображение миниатюры в любом нужном формате.
```javascript
// Создание экземпляра класса Presentation, представляющего файл PPTX
var pres = new aspose.slides.Presentation();
try {
    // Добавить SmartArt
    var smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, aspose.slides.SmartArtLayoutType.BasicCycle);
    // Получить ссылку на узел, используя его индекс
    var node = smart.getNodes().get_Item(1);
    // Получить миниатюру
    var slideImage = node.getShapes().get_Item(0).getImage();
    // Сохранить миниатюру
    try {
        slideImage.save("SmartArt_ChildNote_Thumbnail.png", aspose.slides.ImageFormat.Png);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**Поддерживается ли анимация SmartArt?**

Да. SmartArt рассматривается как обычная фигура, поэтому вы можете [применять стандартные анимации](/slides/ru/nodejs-java/shape-animation/) (вход, выход, акцент, пути движения) и настраивать их параметры. При необходимости можно анимировать также фигуры внутри узлов SmartArt.

**Как надёжно найти конкретный SmartArt на слайде, если его внутренний идентификатор неизвестен?**

Назначьте и ищите по [альтернативному тексту](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/getalternativetext/). Установка отличительного AltText у SmartArt позволяет находить его без обращения к внутренним идентификаторам.

**Сохранится ли внешний вид SmartArt при конвертации презентации в PDF?**

Да. Aspose.Slides рендерит SmartArt с высокой точностью при [экспорте в PDF](/slides/ru/nodejs-java/convert-powerpoint-to-pdf/), сохраняю‑я макет, цвета и эффекты.

**Можно ли извлечь изображение всего SmartArt (для превью или отчётов)?**

Да. Вы можете отрисовать фигуру SmartArt в [растровые форматы](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getImage) или в [SVG](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/writeassvg/) для масштабируемого векторного вывода, что удобно для миниатюр, отчётов или веб‑использования.