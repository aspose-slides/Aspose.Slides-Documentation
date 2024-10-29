---
title: Создание или управление узлом формы SmartArt PowerPoint на Java
linktitle: Управление узлом формы SmartArt
type: docs
weight: 30
url: /ru/androidjava/manage-smartart-shape-node/
keywords: smartart powerpoint, узлы smartart, позиция smartart, удалить smartart, добавить узлы smartart, презентация powerpoint, powerpoint java, powerpoint java api
description: Управление узлом smart art и дочерними узлами в презентациях PowerPoint на Java
---

## **Добавление узла SmartArt в презентацию PowerPoint с использованием Java**
Aspose.Slides для Android через Java предоставляет самый простой API для управления фигурами SmartArt самым простым способом. Пример кода ниже поможет добавить узел и дочерний узел внутри фигуры SmartArt.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) и загрузите презентацию с фигурой SmartArt.
1. Получите ссылку на первый слайд, используя его индекс.
1. Пройдите через каждую фигуру на первом слайде.
1. Проверьте, является ли фигура типом [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt), и приведите выбранную фигуру к типу [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt), если это SmartArt.
1. [Добавьте новый узел](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArtNodeCollection#addNode--) в фигуру SmartArt [**NodeCollection**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt#getAllNodes--) и задайте текст в TextFrame.
1. Теперь [добавьте](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArtNodeCollection#addNode--) [**дочерний узел**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArtNode#getChildNodes--) в только что добавленный [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt) узел и задайте текст в TextFrame.
1. Сохраните презентацию.

```java
// Загрузите желаемую презентацию
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try {
    // Пройдите через каждую фигуру на первом слайде
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // Проверьте, является ли фигура типом SmartArt
        if (shape instanceof SmartArt) 
        {
            // Приведите фигуру к типу SmartArt
            SmartArt smart = (SmartArt) shape;
    
            // Добавление нового узла SmartArt
            SmartArtNode TemNode = (SmartArtNode) smart.getAllNodes().addNode();
    
            // Добавление текста
            TemNode.getTextFrame().setText("Тест");
    
            // Добавление нового дочернего узла в родительский узел. Он будет добавлен в конец коллекции
            SmartArtNode newNode = (SmartArtNode) TemNode.getChildNodes().addNode();
    
            // Добавление текста
            newNode.getTextFrame().setText("Новый узел добавлен");
        }
    }
    
    // Сохранение презентации
    pres.save("AddSmartArtNode.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Добавление узла SmartArt в определённой позиции**
В следующем примере кода мы объяснили, как добавить дочерние узлы, принадлежащие соответствующим узлам фигуры SmartArt, в определённой позиции.

1. Создайте экземпляр класса Presentation.
1. Получите ссылку на первый слайд, используя его индекс.
1. Добавьте фигуру SmartArt типа [**StackedList**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArtLayoutType#StackedList) на доступном слайде.
1. Получите доступ к первому узлу в добавленной фигуре SmartArt.
1. Теперь добавьте [**дочерний узел**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArtNode#getChildNodes--) для выбранного [**узла**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArtNode) на позиции 2 и задайте его текст.
1. Сохраните презентацию.

```java
// Создание экземпляра презентации
Presentation pres = new Presentation();
try {
    // Доступ к слайду презентации
    ISlide slide = pres.getSlides().get_Item(0);

    // Добавление фигуры Smart Art IShape
    ISmartArt smart = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);

    // Доступ к узлу SmartArt по индексу 0
    ISmartArtNode node = smart.getAllNodes().get_Item(0);

    // Добавление нового дочернего узла на позиции 2 в родительском узле
    SmartArtNode chNode = (SmartArtNode) ((SmartArtNodeCollection) node.getChildNodes()).addNodeByPosition(2);

    // Добавьте текст
    chNode.getTextFrame().setText("Добавленный образец текста");

    // Сохранение презентации
    pres.save("AddSmartArtNodeByPosition.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Доступ к узлу SmartArt в презентации PowerPoint с использованием Java**
Следующий пример кода поможет получить доступ к узлам внутри фигуры SmartArt. Обратите внимание, что вы не можете изменить LayoutType SmartArt, так как он является доступным только для чтения и устанавливается только при добавлении фигуры SmartArt.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) и загрузите презентацию с фигурой SmartArt.
1. Получите ссылку на первый слайд, используя его индекс.
1. Пройдите через каждую фигуру на первом слайде.
1. Проверьте, является ли фигура типом [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt), и приведите выбранную фигуру к типу [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt), если это SmartArt.
1. Пройдите через все [**узлы**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArt#getAllNodes--) внутри фигуры SmartArt.
1. Получите и отобразите информацию, такую как позиция узла SmartArt, уровень и текст.

```java
// Создание экземпляра класса Presentation
Presentation pres = new Presentation("SmartArtShape.pptx");
try {
    // Получите первый слайд
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Пройдите через каждую фигуру на первом слайде
    for (IShape shape : slide.getShapes()) 
    {
        // Проверьте, является ли фигура типом SmartArt
        if (shape instanceof ISmartArt) 
        {
            // Приведите фигуру к типу SmartArt
            ISmartArt smart = (ISmartArt) shape;
    
            // Пройдите через все узлы внутри SmartArt
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                // Получение узла SmartArt по индексу i
                SmartArtNode node = (SmartArtNode) smart.getAllNodes().get_Item(i);
    
                // Печать параметров узла SmartArt
                System.out.print(node.getTextFrame().getText() + " " + node.getLevel() + " " + node.getPosition());
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Доступ к дочернему узлу SmartArt**
Следующий пример кода поможет получить доступ к дочерним узлам, принадлежащим соответствующим узлам фигуры SmartArt.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) и загрузите презентацию с фигурой SmartArt.
1. Получите ссылку на первый слайд, используя его индекс.
1. Пройдите через каждую фигуру на первом слайде.
1. Проверьте, является ли фигура типом [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt), и приведите выбранную фигуру к типу [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt), если это SmartArt.
1. Пройдите через все [**узлы**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArt#getAllNodes--) внутри фигуры SmartArt.
1. Для каждого выбранного узла SmartArt [**Node**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArtNode) пройдите через все [**дочерние узлы**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArtNode#getChildNodes--) внутри конкретного узла.
1. Получите и отобразите информацию, такую как позиция дочернего узла, уровень и текст.

```java
// Создание экземпляра класса Presentation
Presentation pres = new Presentation("AccessChildNodes.pptx");
try {
    // Получите первый слайд
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Пройдите через каждую фигуру на первом слайде
    for (IShape shape : slide.getShapes()) 
    {
        // Проверьте, является ли фигура типом SmartArt
        if (shape instanceof ISmartArt) 
        {
            // Приведите фигуру к типу SmartArt
            ISmartArt smart = (ISmartArt) shape;
    
            // Пройдите через все узлы внутри SmartArt
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                // Получение узла SmartArt по индексу i
                SmartArtNode node0 = (SmartArtNode) smart.getAllNodes().get_Item(i);
                
                // Пройдите через дочерние узлы в узле SmartArt по индексу i
                for (int j = 0; j < node0.getChildNodes().size(); j++) 
                {
                    // Получение дочернего узла в узле SmartArt
                    SmartArtNode node = (SmartArtNode) node0.getChildNodes().get_Item(j);
    
                    // Печать параметров дочернего узла SmartArt
                    System.out.print("j = " + j + ", Текст = " + node.getTextFrame().getText() + ", Уровень = " + node.getLevel() + ", Позиция = " + node.getPosition());
                }
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Доступ к дочернему узлу SmartArt в определённой позиции**
В этом примере мы научимся получать доступ к дочерним узлам в конкретной позиции, принадлежащим соответствующим узлам фигуры SmartArt.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).
1. Получите ссылку на первый слайд, используя его индекс.
1. Добавьте фигуру SmartArt типа [**StackedList**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArtLayoutType#StackedList).
1. Получите доступ к добавленной фигуре SmartArt.
1. Получите доступ к узлу по индексу 0 для полученной фигуры SmartArt.
1. Теперь получите доступ к [**дочернему узлу**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArtNode#getChildNodes--) на позиции 1 для полученного узла SmartArt, используя метод **get_Item()**.
1. Получите и отобразите информацию, такую как позиция дочернего узла, уровень и текст.

```java
// Создание экземпляра презентации
Presentation pres = new Presentation();
try {
    // Доступ к первому слайду
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Добавление фигуры SmartArt на первом слайде
    ISmartArt smart = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);
    
    // Получение узла SmartArt по индексу 0
    ISmartArtNode node = smart.getAllNodes().get_Item(0);
    
    // Доступ к дочернему узлу на позиции 1 в родительском узле
    int position = 1;
    SmartArtNode chNode = (SmartArtNode) ((SmartArtNodeCollection) node.getChildNodes()).get_Item(position);
    
    // Печать параметров дочернего узла SmartArt
    System.out.print("Текст = " + chNode.getTextFrame().getText() + ", Уровень = " + chNode.getLevel() + ", Позиция = " + chNode.getPosition());
} finally {
    if (pres != null) pres.dispose();
}
```

## **Удаление узла SmartArt в презентации PowerPoint с использованием Java**
В этом примере мы научимся удалять узлы внутри фигуры SmartArt.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) и загрузите презентацию с фигурой SmartArt.
1. Получите ссылку на первый слайд, используя его индекс.
1. Пройдите через каждую фигуру на первом слайде.
1. Проверьте, является ли фигура типом [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt), и приведите выбранную фигуру к типу [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt), если это SmartArt.
1. Проверьте, есть ли у [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt) больше 0 узлов.
1. Выберите узел SmartArt, который нужно удалить.
1. Теперь удалите выбранный узел с помощью метода [**RemoveNode**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArtNodeCollection#removeNode-com.aspose.slides.ISmartArtNode-).
1. Сохраните презентацию.

```java
// Загрузите желаемую презентацию
Presentation pres = new Presentation("AddSmartArtNode.pptx");
try {
    // Пройдите через каждую фигуру на первом слайде
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // Проверьте, является ли фигура типом SmartArt
        if (shape instanceof ISmartArt) 
        {
            // Приведите фигуру к типу SmartArt
            ISmartArt smart = (ISmartArt) shape;
    
            if (smart.getAllNodes().size() > 0) 
            {
                // Получение узла SmartArt по индексу 0
                ISmartArtNode node = smart.getAllNodes().get_Item(0);
    
                // Удаление выбранного узла
                smart.getAllNodes().removeNode(node);
            }
        }
    }
    
    // Сохранение презентации
    pres.save("RemoveSmartArtNode.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Удаление узла SmartArt в определённой позиции**
В этом примере мы научимся удалять узлы внутри фигуры SmartArt на определённой позиции.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) и загрузите презентацию с фигурой SmartArt.
1. Получите ссылку на первый слайд, используя его индекс.
1. Пройдите через каждую фигуру на первом слайде.
1. Проверьте, является ли фигура типом [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt), и приведите выбранную фигуру к типу [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt), если это SmartArt.
1. Выберите узел фигуры SmartArt по индексу 0.
1. Теперь проверьте, есть ли у выбранного узла SmartArt более 2 дочерних узлов.
1. Теперь удалите узел на **позиции 1** с помощью метода [**RemoveNode**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArtNodeCollection#removeNode-int-).
1. Сохраните презентацию.

```java
// Загрузите желаемую презентацию
Presentation pres = new Presentation("AddSmartArtNode.pptx");
try {
    // Пройдите через каждую фигуру на первом слайде
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // Проверьте, является ли фигура типом SmartArt
        if (shape instanceof SmartArt) 
        {
            // Приведите фигуру к типу SmartArt
            SmartArt smart = (SmartArt) shape;
    
            if (smart.getAllNodes().size() > 0) 
            {
                // Получение узла SmartArt по индексу 0
                ISmartArtNode node = smart.getAllNodes().get_Item(0);
    
                if (node.getChildNodes().size() >= 2) 
                {
                    // Удаление дочернего узла на позиции 1
                    (node.getChildNodes()).removeNode(1);
                }
            }
        }
    }
    
    // Сохранение презентации
    pres.save("RemoveSmartArtNodeByPosition.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Установка пользовательской позиции для дочернего узла в SmartArt**
Теперь Aspose.Slides для Android через Java поддерживает установку свойств [SmartArtShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArtShape) [X](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#setX-float-) и [Y](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#setY-float-). Код ниже показывает, как задать пользовательскую позицию SmartArtShape, размер и поворот. Также обратите внимание, что добавление новых узлов вызывает перерасчет позиций и размеров всех узлов. Также с помощью пользовательских настроек позиции пользователи могут настраивать узлы в соответствии с требованиями.

```java
// Создание экземпляра класса Presentation
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try{
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(20, 20, 600, 500, SmartArtLayoutType.OrganizationChart);

    // Перемещение фигуры SmartArt в новую позицию
    ISmartArtNode node = smart.getAllNodes().get_Item(1);
    ISmartArtShape shape = node.getShapes().get_Item(1);
    shape.setX(shape.getX() + shape.getWidth() * 2);
    shape.setY(shape.getY() - shape.getHeight() * 2);

    // Изменение ширины фигур SmartArt
    node = smart.getAllNodes().get_Item(2);
    shape = node.getShapes().get_Item(1);
    shape.setWidth(shape.getWidth() + shape.getWidth() * 2);

    // Изменение высоты фигур SmartArt
    node = smart.getAllNodes().get_Item(3);
    shape = node.getShapes().get_Item(1);
    shape.setHeight(shape.getHeight() + shape.getHeight() * 2);

    // Изменение поворота фигур SmartArt
    node = smart.getAllNodes().get_Item(4);
    shape = node.getShapes().get_Item(1);
    shape.setRotation(90);

    pres.save("SmartArt.pptx", SaveFormat.Pptx);
}finally {
    pres.dispose();
}
```

## **Проверка узла-ассистента**
{{% alert color="primary" %}} 

В этой статье мы дополнительно исследуем функции фигур SmartArt, добавленных в слайды презентации программно с использованием Aspose.Slides для Android через Java.

{{% /alert %}} 

Мы используем следующую исходную фигуру SmartArt для нашего исследования в различных разделах этой статьи.

|![todo:image_alt_text](https://i.imgur.com/FItwczY.png)|
| :- |
|**Рисунок: Исходная фигура SmartArt в слайде**|

В следующем примере кода мы исследуем, как идентифицировать **узлы-ассистенты** в коллекции узлов SmartArt и изменять их.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) и загрузите презентацию с фигурой SmartArt.
1. Получите ссылку на второй слайд, используя его индекс.
1. Пройдите через каждую фигуру на первом слайде.
1. Проверьте, является ли фигура типом [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt), и приведите выбранную фигуру к типу [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt), если это SmartArt.
1. Пройдите через все узлы внутри фигуры SmartArt и проверьте, являются ли они [**узлами-ассистентами**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArtNode#isAssistant--).
1. Измените статус узла-ассистента на нормальный узел.
1. Сохраните презентацию.

```java
// Создание экземпляра презентации
Presentation pres = new Presentation("AddNodes.pptx");
try {
    // Пройдите через каждую фигуру на первом слайде
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // Проверьте, является ли фигура типом SmartArt
        if (shape instanceof ISmartArt) 
        {
            // Приведите фигуру к типу SmartArt
            ISmartArt smart = (SmartArt) shape;
    
            // Пройдите через все узлы фигуры SmartArt
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                ISmartArtNode node = smart.getAllNodes().get_Item(i);
                // Проверьте, является ли узел узлом-ассистентом
                if (node.isAssistant()) 
                {
                    // Установите узел-ассистент на false и сделайте его узлом нормальным
                    node.isAssistant();
                }
            }
        }
    }
    
    // Сохранение презентации
    pres.save("ChangeAssitantNode.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

|![todo:image_alt_text](https://i.imgur.com/qpAl4rN.png)|
| :- |
|**Рисунок: Узлы-ассистенты изменены в фигуре SmartArt внутри слайда**|

## **Установка формата заливки узла**
Aspose.Slides для Android через Java позволяет добавлять настраиваемые фигуры SmartArt и устанавливать их формат заливки. Эта статья объясняет, как создать и получить доступ к фигурам SmartArt и установить их формат заливки с использованием Aspose.Slides для Android через Java.

Пожалуйста, следуйте приведённым ниже шагам:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).
1. Получите ссылку на слайд, используя его индекс.
1. Добавьте фигуру [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt), установив её [**LayoutType**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArtLayoutType#ClosedChevronProcess).
1. Установите [**FillFormat**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#getFillFormat--) для узлов фигуры SmartArt.
1. Запишите изменённую презентацию в файл PPTX.

```java
// Создание экземпляра презентации
Presentation pres = new Presentation();
try {
    // Доступ к слайду
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Добавление фигуры SmartArt и узлов
    ISmartArt chevron = slide.getShapes().addSmartArt(10, 10, 800, 60, SmartArtLayoutType.ClosedChevronProcess);
    ISmartArtNode node = chevron.getAllNodes().addNode();
    node.getTextFrame().setText("Некоторый текст");
    
    // Установка цвета заливки узла
    for (IShape item : node.getShapes()) 
    {
        item.getFillFormat().setFillType(FillType.Solid);
        item.getFillFormat().getSolidFillColor().setColor(Color.RED);
    }
    
    // Сохранение презентации
    pres.save("TestSmart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Создание миниатюры дочернего узла SmartArt**
Разработчики могут создать миниатюру дочернего узла SmartArt, следуя приведённым ниже шагам:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).
1. [Добавьте SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArtNodeCollection#addNode--).
1. Получите ссылку на узел, используя его индекс.
1. Получите изображение миниатюры.
1. Сохраните изображение миниатюры в любом желаемом формате изображения.

```java
// Создание экземпляра класса Presentation, представляющего файл PPTX 
Presentation pres = new Presentation();
try {
    // Добавление SmartArt 
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicCycle);

    // Получение ссылки на узел, используя его индекс  
    ISmartArtNode node = smart.getNodes().get_Item(1);

    // Получение миниатюры
    IImage slideImage = node.getShapes().get_Item(0).getImage();

    // Сохранение миниатюры
    try {
          slideImage.save("SmartArt_ChildNote_Thumbnail.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```