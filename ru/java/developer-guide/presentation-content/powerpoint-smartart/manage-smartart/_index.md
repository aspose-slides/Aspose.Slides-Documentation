---
title: Управление SmartArt в презентациях PowerPoint с помощью Java
linktitle: Управление SmartArt
type: docs
weight: 10
url: /ru/java/manage-smartart/
keywords:
- SmartArt
- Текст SmartArt
- Тип компоновки
- Свойство скрытия
- Организационная диаграмма
- Диаграмма Picture Organization
- PowerPoint
- Презентация
- Java
- Aspose.Slides
description: "Узнайте, как создавать и редактировать SmartArt в PowerPoint с помощью Aspose.Slides for Java, используя понятные примеры кода, ускоряющие дизайн слайдов и автоматизацию."
---

## **Получить текст из объекта SmartArt**
Теперь метод TextFrame добавлен в интерфейс [ISmartArtShape](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtShape) и класс [SmartArtShape](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArtShape) соответственно. Это свойство позволяет получить весь текст из [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt), если он содержит не только текст узлов. Следующий пример кода поможет вам получить текст из узла SmartArt.
```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);
    ISmartArt smartArt = (ISmartArt)slide.getShapes().get_Item(0);

    ISmartArtNodeCollection smartArtNodes = smartArt.getAllNodes();
    for (ISmartArtNode smartArtNode : smartArtNodes)
    {
        for (ISmartArtShape nodeShape : smartArtNode.getShapes())
        {
            if (nodeShape.getTextFrame() != null)
                System.out.println(nodeShape.getTextFrame().getText());
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```


## **Изменить тип компоновки объекта SmartArt**
Чтобы изменить тип компоновки [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt). Выполните следующие действия:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
- Получите ссылку на слайд, используя его индекс.
- Добавьте [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) BasicBlockList.
- Измените [LayoutType](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt#setLayout-int-) на BasicProcess.
- Сохраните презентацию в файл PPTX. В приведённом ниже примере мы добавили соединитель между двумя фигурами.
```java
Presentation pres = new Presentation();
try {
    // Добавить SmartArt BasicProcess
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

    // Изменить LayoutType на BasicProcess
    smart.setLayout(SmartArtLayoutType.BasicProcess);

    // Сохранение презентации
    pres.save("ChangeSmartArtLayout_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Проверить свойство Visibility объекта SmartArt**
Обратите внимание: метод [ISmartArtNode.isHidden()](https://reference.aspose.com/slides/java/com.aspose.slides/ismartartnode/#isHidden--) возвращает true, если данный узел скрыт в модели данных. Чтобы проверить свойство скрытности любого узла [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt). Выполните следующие действия:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
- Добавьте [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) RadialCycle.
- Добавьте узел в SmartArt.
- Проверьте свойство [visibility](https://reference.aspose.com/slides/java/com.aspose.slides/ismartartnode/#isHidden--).
- Сохраните презентацию в файл PPTX. В приведённом ниже примере мы добавили соединитель между двумя фигурами.
```java
Presentation pres = new Presentation();
try {
    // Добавить SmartArt BasicProcess 
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);

    // Добавить узел в SmartArt 
    ISmartArtNode node = smart.getAllNodes().addNode();

    // Проверить свойство isHidden
    boolean hidden = node.isHidden(); // Возвращает true

    if (hidden)
    {
        // Выполнить некоторые действия или уведомления
    }
    // Сохранение презентации
    pres.save("CheckSmartArtHiddenProperty_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Получить или установить тип организационной схемы**
Методы [ISmartArtNode.getOrganizationChartLayout()](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtNode#getOrganizationChartLayout--) , [setOrganizationChartLayout(int)](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtNode#setOrganizationChartLayout-int-) позволяют получить или установить тип организационной схемы, связанный с текущим узлом. Чтобы получить или установить тип организационной схемы, выполните следующие действия:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
- Добавьте [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) на слайд.
- Получите или [установите тип организационной схемы](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtNode#setOrganizationChartLayout-int-).
- Сохраните презентацию в файл PPTX. В приведённом ниже примере мы добавили соединитель между двумя фигурами.
```java
Presentation pres = new Presentation();
try {
    // Добавить SmartArt BasicProcess
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);

    // Получить или установить тип организационной схемы
    smart.getNodes().get_Item(0).setOrganizationChartLayout(OrganizationChartLayoutType.LeftHanging);

    // Сохранение презентации
    pres.save("OrganizeChartLayoutType_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Создать схему Picture Organization**
Aspose.Slides for Java предоставляет простой API для создания диаграмм PictureOrganization. Чтобы создать диаграмму на слайде:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. Получите ссылку на слайд по его индексу.
1. Добавьте диаграмму с данными по умолчанию и нужным типом (ChartType.PictureOrganizationChart).
1. Сохраните изменённую презентацию в файл PPTX

Следующий код используется для создания диаграммы.
```java
Presentation pres = new Presentation("test.pptx");
try {
    ISmartArt smartArt = pres.getSlides().get_Item(0).getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.PictureOrganizationChart);
    pres.save("OrganizationChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Получить или установить состояние SmartArt**
Чтобы изменить тип компоновки [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt). Выполните следующие действия:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. Добавьте [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) на слайд.
1. [Получите](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt#isReversed--) или [установите](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt#setReversed-boolean-) состояние диаграммы SmartArt.
1. Сохраните презентацию в файл PPTX.

Следующий код используется для создания диаграммы.
```java
// Создать экземпляр класса Presentation, представляющего файл PPTX
Presentation pres = new Presentation();
try {
    // Добавить SmartArt BasicProcess
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicProcess);
    
    // Получить или установить состояние диаграммы SmartArt
    smart.setReversed(true);
    boolean flag = smart.isReversed();
    
    // Сохранение презентации
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**Поддерживает ли SmartArt зеркальное отображение/реверс для RTL-языков?**

Да. Метод [setReversed](https://reference.aspose.com/slides/java/com.aspose.slides/smartart/#setReversed-boolean-) переключает направление диаграммы (LTR/RTL), если выбранный тип SmartArt поддерживает реверс.

**Как скопировать SmartArt на тот же слайд или в другую презентацию, сохранив форматирование?**

Вы можете [клонировать форму SmartArt](/slides/ru/java/shape-manipulations/) через коллекцию форм ([ShapeCollection.addClone](https://reference.aspose.com/slides/java/com.aspose.slides/shapecollection/#addClone-com.aspose.slides.IShape-float-float-float-float-)) или [клонировать весь слайд](/slides/ru/java/clone-slides/) содержащий эту форму. Оба подхода сохраняют размер, позицию и стили.

**Как отрендерить SmartArt в растровое изображение для предварительного просмотра или веб-экспорта?**

[Отрендерьте слайд](/slides/ru/java/convert-powerpoint-to-png/) (или всю презентацию) в PNG/JPEG через API, преобразующее слайды/презентации в изображения — SmartArt будет отрисован как часть слайда.

**Как программно выбрать конкретный SmartArt на слайде, если их несколько?**

Обычно используют [альтернативный текст](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getAlternativeText--) (Alt Text) или [имя](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getName--) и ищут форму по этому атрибуту в пределах [форм слайда](https://reference.aspose.com/slides/java/com.aspose.slides/baseslide/#getShapes--), затем проверяют тип, чтобы убедиться, что это [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/smartart/). Документация описывает типичные техники поиска и работы с формами.