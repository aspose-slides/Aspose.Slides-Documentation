---
title: Управление SmartArt
type: docs
weight: 10
url: /ru/java/manage-smartart/
---

## **Получение текста из SmartArt**
Теперь метод TextFrame был добавлен в интерфейс [ISmartArtShape](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtShape) и соответственно в класс [SmartArtShape](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArtShape). Это свойство позволяет получать весь текст из [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt), если он содержит не только текст узлов. Приведенный ниже образец кода поможет вам получить текст из узла SmartArt.

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

## **Изменение типа макета SmartArt**
Чтобы изменить тип макета [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt), пожалуйста, следуйте приведенным ниже шагам:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
- Получите ссылку на слайд, используя его индекс.
- Добавьте [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) BasicBlockList.
- Измените [LayoutType](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt#setLayout-int-) на BasicProcess.
- Запишите презентацию в файл PPTX.
  В приведенном ниже примере мы добавили соединитель между двумя фигурами.

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

## **Проверка скрытого свойства SmartArt**
Обратите внимание: метод [ISmartArtNode.isHidden()](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtNode#isHidden--) возвращает true, если этот узел является скрытым узлом в модели данных. Чтобы проверить скрытое свойство любого узла [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt), пожалуйста, следуйте приведенным ниже шагам:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
- Добавьте [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) RadialCycle.
- Добавьте узел на SmartArt.
- Проверьте свойство [isHidden](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtNode#isHidden--).
- Запишите презентацию в файл PPTX.

В приведенном ниже примере мы добавили соединитель между двумя фигурами.

```java
Presentation pres = new Presentation();
try {
    // Добавить SmartArt BasicProcess 
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);

    // Добавить узел на SmartArt 
    ISmartArtNode node = smart.getAllNodes().addNode();

    // Проверка свойства isHidden
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

## **Получение или установка типа организационной диаграммы**
Методы [ISmartArtNode.getOrganizationChartLayout()](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtNode#getOrganizationChartLayout--), [setOrganizationChartLayout(int)](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtNode#setOrganizationChartLayout-int-) позволяют получить или установить тип организационной диаграммы, связанной с текущим узлом. Чтобы получить или установить тип организационной диаграммы, пожалуйста, следуйте приведенным ниже шагам:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
- Добавьте [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) на слайд.
- Получите или [установите тип организационной диаграммы](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtNode#setOrganizationChartLayout-int-).
- Запишите презентацию в файл PPTX.
  В приведенном ниже примере мы добавили соединитель между двумя фигурами.

```java
Presentation pres = new Presentation();
try {
    // Добавить SmartArt BasicProcess
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);

    // Получить или установить тип организационной диаграммы
    smart.getNodes().get_Item(0).setOrganizationChartLayout(OrganizationChartLayoutType.LeftHanging);

    // Сохранение презентации
    pres.save("OrganizeChartLayoutType_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Создание организационной диаграммы с изображениями**
Aspose.Slides для Java предоставляет простой API для создания организационных диаграмм с изображениями. Чтобы создать диаграмму на слайде:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. Получите ссылку на слайд по индексу.
1. Добавьте диаграмму с данными по умолчанию вместе с желаемым типом (ChartType.PictureOrganizationChart).
1. Запишите измененную презентацию в файл PPTX.

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

## **Получение или установка состояния SmartArt**
Чтобы изменить тип макета [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt), пожалуйста, следуйте приведенным ниже шагам:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. Добавьте [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) на слайд.
1. [Получите](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt#isReversed--) или [установите](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt#setReversed-boolean-) состояние диаграммы SmartArt.
1. Запишите презентацию в файл PPTX.

Следующий код используется для создания диаграммы.

```java
// Создание экземпляра класса Presentation, представляющего файл PPTX
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