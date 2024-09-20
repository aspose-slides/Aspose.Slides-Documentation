---
title: Управление SmartArt
type: docs
weight: 10
url: /androidjava/manage-smartart/
---

## **Получить текст из SmartArt**
Теперь метод TextFrame был добавлен в интерфейс [ISmartArtShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArtShape) и класс [SmartArtShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArtShape) соответственно. Это свойство позволяет вам получить весь текст из [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArt), если у него есть не только текст узлов. Приведённый ниже пример кода поможет вам получить текст из узла SmartArt.

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

## **Изменить тип макета SmartArt**
Чтобы изменить тип макета [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArt), выполните следующие шаги:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
- Получите ссылку на слайд, используя его индекс.
- Добавьте [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) BasicBlockList.
- Измените [LayoutType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt#setLayout-int-) на BasicProcess.
- Запишите презентацию в файл PPTX.
  В приведённом ниже примере мы добавили соединитель между двумя фигурами.

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

## **Проверить скрытое свойство SmartArt**
Обратите внимание: метод [ISmartArtNode.isHidden()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArtNode#isHidden--) возвращает true, если этот узел является скрытым узлом в модели данных. Чтобы проверить скрытое свойство любого узла [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArt), выполните следующие шаги:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
- Добавьте [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) RadialCycle.
- Добавьте узел на SmartArt.
- Проверьте свойство [isHidden](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArtNode#isHidden--).
- Запишите презентацию в файл PPTX.

В приведённом ниже примере мы добавили соединитель между двумя фигурами.

```java
Presentation pres = new Presentation();
try {
    // Добавить SmartArt BasicProcess 
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);

    // Добавить узел на SmartArt 
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

## **Получить или установить тип организационной диаграммы**
Методы [ISmartArtNode.getOrganizationChartLayout()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArtNode#getOrganizationChartLayout--), [setOrganizationChartLayout(int)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArtNode#setOrganizationChartLayout-int-) позволяют получить или установить тип организационной диаграммы, связанный с текущим узлом. Чтобы получить или установить тип организационной диаграммы, выполните следующие шаги:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
- Добавьте [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) на слайд.
- Получите или [установите тип организационной диаграммы](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArtNode#setOrganizationChartLayout-int-).
- Запишите презентацию в файл PPTX.
  В приведённом ниже примере мы добавили соединитель между двумя фигурами.

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

## **Создать организационную диаграмму с изображением**
Aspose.Slides для Android через Java предоставляет простой API для создания и организационных диаграмм с изображениями. Чтобы создать диаграмму на слайде:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Получите ссылку на слайд по его индексу.
3. Добавьте диаграмму с данными по умолчанию с желаемым типом (ChartType.PictureOrganizationChart).
4. Запишите изменённую презентацию в файл PPTX.

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
Чтобы изменить тип макета [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArt), выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Добавьте [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) на слайд.
3. [Получите](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt#isReversed--) или [установите](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt#setReversed-boolean-) состояние диаграммы SmartArt.
4. Запишите презентацию в файл PPTX.

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