---
title: Управление узлами SmartArt в презентациях с использованием Java
linktitle: Узел фигуры SmartArt
type: docs
weight: 30
url: /ru/java/manage-smartart-shape-node/
keywords:
- Узел SmartArt
- дочерний узел
- добавить узел
- позиция узла
- доступ к узлу
- удалить узел
- пользовательская позиция
- узел‑помощник
- формат заливки
- отрисовка узла
- PowerPoint
- презентация
- Java
- Aspose.Slides
description: "Управляйте узлами фигур SmartArt в PPT и PPTX с помощью Aspose.Slides for Java. Получите четкие примеры кода и советы для оптимизации ваших презентаций."
---

## **Добавить узел SmartArt**
Aspose.Slides for Java предоставляет самый простой API для управления фигурами SmartArt самым простым способом. Приведённый пример кода поможет добавить узел и дочерний узел внутри фигуры SmartArt.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) и загрузите презентацию с фигурой SmartArt.
1. Получите ссылку на первый слайд, используя его индекс.
1. Пройдитесь по каждой фигуре на первом слайде.
1. Проверьте, является ли фигура типом [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt) и выполните приведение выбранной фигуры к типу [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt), если это SmartArt.
1. [Add a new Node](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtNodeCollection#addNode--) в фигуру SmartArt [**NodeCollection**](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt#getAllNodes--) и задайте текст в TextFrame.
1. Теперь [Add](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtNodeCollection#addNode--) [**Child Node**](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtNode#getChildNodes--) в только что добавленный [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt) узел и задайте текст в TextFrame.
1. Сохраните презентацию.
```java
// Загрузить требуемую презентацию
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try {
    // Пройти по каждой фигуре на первом слайде
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // Проверить, является ли фигура типом SmartArt
        if (shape instanceof SmartArt) 
        {
            // Привести тип фигуры к SmartArt
            SmartArt smart = (SmartArt) shape;
    
            // Добавление нового узла SmartArt
            SmartArtNode TemNode = (SmartArtNode) smart.getAllNodes().addNode();
    
            // Добавление текста
            TemNode.getTextFrame().setText("Test");
    
            // Добавление нового дочернего узла в родительский узел. Он будет добавлен в конец коллекции
            SmartArtNode newNode = (SmartArtNode) TemNode.getChildNodes().addNode();
    
            // Добавление текста
            newNode.getTextFrame().setText("New Node Added");
        }
    }
    
    // Сохранение презентации
    pres.save("AddSmartArtNode.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Добавить узел SmartArt в определённой позиции**
В следующем примере кода мы объясняем, как добавить дочерние узлы, принадлежащие соответствующим узлам фигуры SmartArt, в определённой позиции.

1. Создайте экземпляр класса Presentation.
1. Получите ссылку на первый слайд, используя его индекс.
1. Добавьте в доступный слайд тип фигуры [**StackedList**](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArtLayoutType#StackedList) [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt).
1. Получите доступ к первому узлу в добавленной фигуре SmartArt.
1. Теперь добавьте [**Child Node**](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtNode#getChildNodes--) для выбранного [**Node**](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArtNode) на позиции 2 и задайте его текст.
1. Сохраните презентацию.
```java
// Создание экземпляра презентации
Presentation pres = new Presentation();
try {
    // Доступ к слайду презентации
    ISlide slide = pres.getSlides().get_Item(0);

    // Добавить Smart Art IShape
    ISmartArt smart = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);

    // Доступ к узлу SmartArt по индексу 0
    ISmartArtNode node = smart.getAllNodes().get_Item(0);

    // Добавление нового дочернего узла в позицию 2 родительского узла
    SmartArtNode chNode = (SmartArtNode) ((SmartArtNodeCollection) node.getChildNodes()).addNodeByPosition(2);

    // Добавить текст
    chNode.getTextFrame().setText("Sample Text Added");

    // Сохранить презентацию
    pres.save("AddSmartArtNodeByPosition.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Доступ к узлу SmartArt**
Приведённый пример кода поможет получить доступ к узлам внутри фигуры SmartArt. Обратите внимание, что вы не можете изменить LayoutType SmartArt, так как он доступен только для чтения и задаётся только при добавлении фигуры SmartArt.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) и загрузите презентацию с фигурой SmartArt.
1. Получите ссылку на первый слайд, используя его индекс.
1. Пройдитесь по каждой фигуре на первом слайде.
1. Проверьте, является ли фигура типом [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt) и выполните приведение выбранной фигуры к типу [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt), если это SmartArt.
1. Пройдитесь по всем [**Nodes**](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt#getAllNodes--) внутри фигуры SmartArt.
1. Получите и отобразите информацию, такую как позиция узла SmartArt, уровень и текст.
```java
// Создать экземпляр класса Presentation
Presentation pres = new Presentation("SmartArtShape.pptx");
try {
    // Получить первый слайд
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Обойти все фигуры на первом слайде
    for (IShape shape : slide.getShapes()) 
    {
        // Проверить, является ли фигура типом SmartArt
        if (shape instanceof ISmartArt) 
        {
            // Привести тип фигуры к SmartArt
            ISmartArt smart = (ISmartArt) shape;
    
            // Обойти все узлы внутри SmartArt
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                // Получить узел SmartArt с индексом i
                SmartArtNode node = (SmartArtNode) smart.getAllNodes().get_Item(i);
    
                // Вывод параметров узла SmartArt
                System.out.print(node.getTextFrame().getText() + " " + node.getLevel() + " " + node.getPosition());
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```


## **Доступ к дочернему узлу SmartArt**
Приведённый пример кода поможет получить доступ к дочерним узлам, принадлежащим соответствующим узлам фигуры SmartArt.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) и загрузите презентацию с фигурой SmartArt.
1. Получите ссылку на первый слайд, используя его индекс.
1. Пройдитесь по каждой фигуре на первом слайде.
1. Проверьте, является ли фигура типом [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt) и выполните приведение выбранной фигуры к типу [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt), если это SmartArt.
1. Пройдитесь по всем [**Nodes**](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt#getAllNodes--) внутри фигуры SmartArt.
1. Для каждого выбранного узла фигуры SmartArt [**Node**](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArtNode) пройдитесь по всем [**Child Nodes**](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArtNode#getChildNodes--) внутри конкретного узла.
1. Получите и отобразите информацию, такую как позиция [**Child Node**](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtNode#getChildNodes--) , уровень и текст.
```java
// Создать экземпляр класса Presentation
Presentation pres = new Presentation("AccessChildNodes.pptx");
try {
    // Получить первый слайд
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Обойти все фигуры на первом слайде
    for (IShape shape : slide.getShapes()) 
    {
        // Проверить, является ли фигура типом SmartArt
        if (shape instanceof ISmartArt) 
        {
            // Привести тип фигуры к SmartArt
            ISmartArt smart = (ISmartArt) shape;
    
            // Обойти все узлы внутри SmartArt
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                // Получить узел SmartArt с индексом i
                SmartArtNode node0 = (SmartArtNode) smart.getAllNodes().get_Item(i);
                
                // Обойти дочерние узлы в узле SmartArt с индексом i
                for (int j = 0; j < node0.getChildNodes().size(); j++) 
                {
                    // Получить дочерний узел в узле SmartArt
                    SmartArtNode node = (SmartArtNode) node0.getChildNodes().get_Item(j);
    
                    // Вывод параметров дочернего узла SmartArt
                    System.out.print("j = " + j + ", Text = " + node.getTextFrame().getText() + ",  Level = " + node.getLevel() + ", Position = " + node.getPosition());
                }
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```


## **Доступ к дочернему узлу SmartArt в определённой позиции**
В этом примере мы научимся получать доступ к дочерним узлам в определённой позиции, принадлежащим соответствующим узлам фигуры SmartArt.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) .
1. Получите ссылку на первый слайд, используя его индекс.
1. Добавьте в слайд фигуру типа [**StackedList**](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArtLayoutType#StackedList) SmartArt.
1. Получите доступ к добавленной фигуре SmartArt.
1. Получите узел с индексом 0 в полученной фигуре SmartArt.
1. Теперь получите [**Child Node**](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtNode#getChildNodes--) на позиции 1 для выбранного узла SmartArt, используя метод **get_Item()**.
1. Получите и отобразите информацию, такую как позиция [**Child Node**](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtNode#getChildNodes--) , уровень и текст.
```java
// Создать экземпляр презентации
Presentation pres = new Presentation();
try {
    // Доступ к первому слайду
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Добавление фигуры SmartArt на первый слайд
    ISmartArt smart = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);
    
    // Доступ к узлу SmartArt с индексом 0
    ISmartArtNode node = smart.getAllNodes().get_Item(0);
    
    // Доступ к дочернему узлу на позиции 1 в родительском узле
    int position = 1;
    SmartArtNode chNode = (SmartArtNode) ((SmartArtNodeCollection) node.getChildNodes()).get_Item(position);
    
    // Вывод параметров дочернего узла SmartArt
    System.out.print("Text = " + chNode.getTextFrame().getText() + ",  Level = " + chNode.getLevel() + ", Position = " + chNode.getPosition());
} finally {
    if (pres != null) pres.dispose();
}
```


## **Удалить узел SmartArt**
В этом примере мы научимся удалять узлы внутри фигуры SmartArt.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) и загрузите презентацию с фигурой SmartArt.
1. Получите ссылку на первый слайд, используя его индекс.
1. Пройдитесь по каждой фигуре на первом слайде.
1. Проверьте, является ли фигура типом [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt) и выполните приведение выбранной фигуры к типу [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/ISSmartArt) если это SmartArt.
1. Проверьте, содержит ли [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt) более 0 узлов.
1. Выберите узел SmartArt, который необходимо удалить.
1. Теперь удалите выбранный узел, используя метод [**RemoveNode**](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtNodeCollection#removeNode-com.aspose.slides.ISmartArtNode-) .
1. Сохраните презентацию.
```java
// Загрузить нужную презентацию
Presentation pres = new Presentation("AddSmartArtNode.pptx");
try {
    // Пройти по каждой фигуре на первом слайде
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // Проверить, является ли фигура типом SmartArt
        if (shape instanceof ISmartArt) 
        {
            // Привести тип фигуры к SmartArt
            ISmartArt smart = (ISmartArt) shape;
    
            if (smart.getAllNodes().size() > 0) 
            {
                // Получить узел SmartArt с индексом 0
                ISmartArtNode node = smart.getAllNodes().get_Item(0);
    
                // Удалить выбранный узел
                smart.getAllNodes().removeNode(node);
            }
        }
    }
    
    // Сохранить презентацию
    pres.save("RemoveSmartArtNode.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Удалить узел SmartArt из определённой позиции**
В этом примере мы научимся удалять узлы внутри фигуры SmartArt в конкретной позиции.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) и загрузите презентацию с фигурой SmartArt.
1. Получите ссылку на первый слайд, используя его индекс.
1. Пройдитесь по каждой фигуре на первом слайде.
1. Проверьте, является ли фигура типом [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt) и выполните приведение выбранной фигуры к типу [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/ISSmartArt) если это SmartArt.
1. Выберите узел фигуры SmartArt с индексом 0.
1. Теперь проверьте, имеет ли выбранный узел SmartArt более 2 дочерних узла.
1. Теперь удалите узел на **Position 1** с помощью метода [**RemoveNode**](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtNodeCollection#removeNode-int-) .
1. Сохраните презентацию.
```java
// Загрузить нужную презентацию
Presentation pres = new Presentation("AddSmartArtNode.pptx");
try {
    // Пройти по каждой фигуре на первом слайде
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // Проверить, является ли фигура типом SmartArt
        if (shape instanceof SmartArt) 
        {
            // Привести тип фигуры к SmartArt
            SmartArt smart = (SmartArt) shape;
    
            if (smart.getAllNodes().size() > 0) 
            {
                // Получить узел SmartArt с индексом 0
                ISmartArtNode node = smart.getAllNodes().get_Item(0);
    
                if (node.getChildNodes().size() >= 2) 
                {
                    // Удалить дочерний узел на позиции 1
                    (node.getChildNodes()).removeNode(1);
                }
            }
        }
    }
    
    // Сохранить презентацию
    pres.save("RemoveSmartArtNodeByPosition.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Установить пользовательскую позицию для дочернего узла в объекте SmartArt**
Теперь Aspose.Slides for Java поддерживает установку свойств [SmartArtShape](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArtShape) [X](https://reference.aspose.com/slides/java/com.aspose.slides/IShape#setX-float-) и [Y](https://reference.aspose.com/slides/java/com.aspose.slides/IShape#setY-float-). Пример кода ниже показывает, как установить пользовательскую позицию, размер и поворот SmartArtShape; также обратите внимание, что добавление новых узлов вызывает перерасчёт позиций и размеров всех узлов. При пользовательских настройках позиции пользователь может задавать узлы согласно требованиям.
```java
// Создать экземпляр класса Presentation
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try{
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(20, 20, 600, 500, SmartArtLayoutType.OrganizationChart);

    // Переместить фигуру SmartArt в новое положение
    ISmartArtNode node = smart.getAllNodes().get_Item(1);
    ISmartArtShape shape = node.getShapes().get_Item(1);
    shape.setX(shape.getX() + shape.getWidth() * 2);
    shape.setY(shape.getY() - shape.getHeight() * 2);

    // Изменить ширину фигуры SmartArt
    node = smart.getAllNodes().get_Item(2);
    shape = node.getShapes().get_Item(1);
    shape.setWidth(shape.getWidth() + shape.getWidth() * 2);

    // Изменить высоту фигуры SmartArt
    node = smart.getAllNodes().get_Item(3);
    shape = node.getShapes().get_Item(1);
    shape.setHeight(shape.getHeight() + shape.getHeight() * 2);

    // Изменить вращение фигуры SmartArt
    node = smart.getAllNodes().get_Item(4);
    shape = node.getShapes().get_Item(1);
    shape.setRotation(90);

    pres.save("SmartArt.pptx", SaveFormat.Pptx);
}finally {
    pres.dispose();
}
```


## **Проверка узла‑помощника**
{{% alert color="primary" %}} 

В этой статье мы более подробно изучим возможности фигур SmartArt, добавленных в слайды презентаций программно с помощью Aspose.Slides for Java.

{{% /alert %}} 

Мы будем использовать следующую исходную фигуру SmartArt для наших исследований в различных разделах этой статьи.

|![todo:image_alt_text](https://i.imgur.com/FItwczY.png)|
| :- |
|**Figure: Source SmartArt shape in slide**|

В следующем примере кода мы исследуем, как определить **Assistant Nodes** в коллекции узлов SmartArt и изменить их.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) и загрузите презентацию с фигурой SmartArt.
1. Получите ссылку на второй слайд, используя его индекс.
1. Пройдитесь по каждой фигуре внутри первого слайда.
1. Проверьте, является ли фигура типом [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt) и выполните приведение выбранной фигуры к типу [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt) если это SmartArt.
1. Пройдитесь по всем узлам внутри фигуры SmartArt и проверьте, являются ли они [**Assistant Nodes**](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArtNode#isAssistant--) .
1. Измените статус узла‑помощника на обычный узел.
1. Сохраните презентацию.
```java
// Создание экземпляра презентации
Presentation pres = new Presentation("AddNodes.pptx");
try {
    // Обойти каждую фигуру на первом слайде
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // Проверить, является ли фигура типом SmartArt
        if (shape instanceof ISmartArt) 
        {
            // Привести тип фигуры к SmartArt
            ISmartArt smart = (SmartArt) shape;
    
            // Обход всех узлов фигуры SmartArt
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                ISmartArtNode node = smart.getAllNodes().get_Item(i);
                // Проверить, является ли узел узлом‑помощником
                if (node.isAssistant()) 
                {
                    // Установить узел‑помощник в false и сделать его обычным узлом
                    node.isAssistant();
                }
            }
        }
    }
    
    // Сохранить презентацию
    pres.save("ChangeAssitantNode.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


|![todo:image_alt_text](https://i.imgur.com/qpAl4rN.png)|
| :- |
|**Figure: Assistant Nodes Changed in SmartArt shape inside slide**|

## **Установить формат заливки узла**
Aspose.Slides for Java позволяет добавлять пользовательские фигуры SmartArt и задавать их формат заливки. Эта статья объясняет, как создавать и получать доступ к фигурам SmartArt и задавать их формат заливки с помощью Aspose.Slides for Java.

Пожалуйста, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) .
1. Получите ссылку на слайд, используя его индекс.
1. Добавьте фигуру [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt), задав её [**LayoutType**](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArtLayoutType#ClosedChevronProcess) .
1. Установите [**FillFormat**](https://reference.aspose.com/slides/java/com.aspose.slides/IShape#getFillFormat--) для узлов фигуры SmartArt.
1. Запишите изменённую презентацию в файл PPTX.
```java
// Создать экземпляр презентации
Presentation pres = new Presentation();
try {
    // Доступ к слайду
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Добавление фигуры SmartArt и узлов
    ISmartArt chevron = slide.getShapes().addSmartArt(10, 10, 800, 60, SmartArtLayoutType.ClosedChevronProcess);
    ISmartArtNode node = chevron.getAllNodes().addNode();
    node.getTextFrame().setText("Some text");
    
    // Установка цвета заливки узла
    for (IShape item : node.getShapes()) 
    {
        item.getFillFormat().setFillType(FillType.Solid);
        item.getFillFormat().getSolidFillColor().setColor(Color.RED);
    }
    
    // Сохранить презентацию
    pres.save("TestSmart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Создать миниатюру дочернего узла SmartArt**
Разработчики могут создать миниатюру дочернего узла SmartArt, выполнив следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) .
1. [Add SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtNodeCollection#addNode--) .
1. Получите ссылку на узел, используя его индекс.
1. Получите изображение‑миниатюру.
1. Сохраните изображение‑миниатюру в любом желаемом формате изображения.
```java
// Создать экземпляр класса Presentation, представляющего файл PPTX
Presentation pres = new Presentation();
try {
    // Добавить SmartArt
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicCycle);

    // Получить ссылку на узел, используя его индекс
    ISmartArtNode node = smart.getNodes().get_Item(1);

    // Получить миниатюру
    IImage slideImage = node.getShapes().get_Item(0).getImage();

    // Сохранить миниатюру
    try {
          slideImage.save("SmartArt_ChildNote_Thumbnail.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**Поддерживается ли анимация SmartArt?**

Да. SmartArt рассматривается как обычная фигура, поэтому вы можете [apply standard animations](/slides/ru/java/shape-animation/) (вход, выход, подчёркивание, траектории движения) и настроить тайминг. При необходимости можно анимировать фигуры внутри узлов SmartArt.

**Как надёжно найти конкретный SmartArt на слайде, если его внутренний ID неизвестен?**

Назначьте и ищите по [alternative text](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getAlternativeText--) . Установка отличительного AltText у SmartArt позволяет находить его программно без зависимости от внутренних идентификаторов.

**Сохранится ли внешний вид SmartArt при конвертации презентации в PDF?**

Да. Aspose.Slides рендерит SmartArt с высокой визуальной точностью при [PDF export](/slides/ru/java/convert-powerpoint-to-pdf/), сохраняя макет, цвета и эффекты.

**Можно ли извлечь изображение всего SmartArt (для превью или отчётов)?**

Да. Вы можете рендерить фигуру SmartArt в [raster formats](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getImage-int-float-float-) или в [SVG](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) для масштабируемого векторного вывода, что подходит для миниатюр, отчётов или веб‑использования.