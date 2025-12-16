---
title: Управление узлами фигур SmartArt в презентациях на Android
linktitle: Узел фигуры SmartArt
type: docs
weight: 30
url: /ru/androidjava/manage-smartart-shape-node/
keywords:
- Узел SmartArt
- Дочерний узел
- Добавить узел
- Позиция узла
- Доступ к узлу
- Удалить узел
- Пользовательская позиция
- Узел-ассистент
- Формат заполнения
- Отрисовка узла
- PowerPoint
- Презентация
- Android
- Java
- Aspose.Slides
description: "Управляйте узлами фигур SmartArt в PPT и PPTX с помощью Aspose.Slides для Android. Получите понятные примеры кода на Java и советы для оптимизации ваших презентаций."
---

## **Добавить узел SmartArt**
Aspose.Slides for Android via Java предоставляет самый простой API для управления фигурами SmartArt самым лёгким способом. Ниже приведён пример кода, который поможет добавить узел и дочерний узел внутри фигуры SmartArt.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) и загрузите презентацию с фигурой SmartArt.  
2. Получите ссылку на первый слайд, используя его индекс.  
3. Пройдитесь по каждой фигуре на первом слайде.  
4. Проверьте, является ли фигура типом [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt) и приведите выбранную фигуру к типу [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt), если это SmartArt.  
5. [Добавить новый узел](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArtNodeCollection#addNode--) в коллекцию узлов фигуры SmartArt **NodeCollection** (https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt#getAllNodes--) и задайте текст в TextFrame.  
6. Теперь [добавьте](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArtNodeCollection#addNode--) **дочерний узел** (https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArtNode#getChildNodes--) в только что добавленный узел SmartArt и задайте текст в TextFrame.  
7. Сохраните презентацию.  
```java
// Загрузите нужную презентацию
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try {
    // Обойдите каждую фигуру на первом слайде
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
В следующем примере кода показано, как добавить дочерние узлы, принадлежащие соответствующим узлам фигуры SmartArt, в конкретную позицию.

1. Создайте экземпляр класса Presentation.  
2. Получите ссылку на первый слайд, используя его индекс.  
3. Добавьте фигуру [**StackedList**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArtLayoutType#StackedList) типа SmartArt на выбранный слайд.  
4. Получите первый узел в добавленной фигуре SmartArt.  
5. Теперь добавьте **дочерний узел** (https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArtNode#getChildNodes--) для выбранного **узла** (https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArtNode) в позиции 2 и задайте его текст.  
6. Сохраните презентацию.  
```java
// Создание экземпляра презентации
Presentation pres = new Presentation();
try {
    // Доступ к слайду презентации
    ISlide slide = pres.getSlides().get_Item(0);

    // Добавление Smart Art IShape
    ISmartArt smart = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);

    // Доступ к узлу SmartArt по индексу 0
    ISmartArtNode node = smart.getAllNodes().get_Item(0);

    // Добавление нового дочернего узла на позицию 2 в родительском узле
    SmartArtNode chNode = (SmartArtNode) ((SmartArtNodeCollection) node.getChildNodes()).addNodeByPosition(2);

    // Добавить текст
    chNode.getTextFrame().setText("Sample Text Added");

    // Сохранение презентации
    pres.save("AddSmartArtNodeByPosition.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Доступ к узлу SmartArt**
Следующий пример кода поможет получить доступ к узлам внутри фигуры SmartArt. Обратите внимание, что изменить LayoutType SmartArt нельзя, так как он только для чтения и задаётся лишь при добавлении фигуры SmartArt.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) и загрузите презентацию с фигурой SmartArt.  
2. Получите ссылку на первый слайд, используя его индекс.  
3. Пройдитесь по каждой фигуре на первом слайде.  
4. Проверьте, является ли фигура типом [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt) и приведите выбранную фигуру к типу [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt), если это SmartArt.  
5. Пройдитесь по всем **узлам** (https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArt#getAllNodes--) внутри фигуры SmartArt.  
6. Доступ и вывод информации, такой как позиция узла SmartArt, уровень и текст.  
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
            // Привести фигуру к типу SmartArt
            ISmartArt smart = (ISmartArt) shape;
    
            // Обойти все узлы внутри SmartArt
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                // Доступ к узлу SmartArt с индексом i
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
Следующий пример кода поможет получить доступ к дочерним узлам, принадлежащим соответствующим узлам фигуры SmartArt.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) и загрузите презентацию с фигурой SmartArt.  
2. Получите ссылку на первый слайд, используя его индекс.  
3. Пройдитесь по каждой фигуре на первом слайде.  
4. Проверьте, является ли фигура типом [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt) и приведите выбранную фигуру к типу [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt), если это SmartArt.  
5. Пройдитесь по всем **узлам** (https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArt#getAllNodes--) внутри фигуры SmartArt.  
6. Для каждого выбранного **узла** (https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArtNode) пройдитесь по всем **дочерним узлам** (https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArtNode#getChildNodes--) внутри конкретного узла.  
7. Доступ и вывод информации, такой как позиция **дочернего узла** (https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArtNode#getChildNodes--), уровень и текст.  
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
            // Привести фигуру к типу SmartArt
            ISmartArt smart = (ISmartArt) shape;
    
            // Обойти все узлы внутри SmartArt
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                // Доступ к узлу SmartArt с индексом i
                SmartArtNode node0 = (SmartArtNode) smart.getAllNodes().get_Item(i);
                
                // Обход дочерних узлов в узле SmartArt с индексом i
                for (int j = 0; j < node0.getChildNodes().size(); j++) 
                {
                    // Доступ к дочернему узлу в узле SmartArt
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
В этом примере мы научимся получать доступ к дочерним узлам в конкретных позициях, принадлежащим соответствующим узлам фигуры SmartArt.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).  
2. Получите ссылку на первый слайд, используя его индекс.  
3. Добавьте фигуру типа [**StackedList**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArtLayoutType#StackedList) SmartArt.  
4. Доступ к добавленной фигуре SmartArt.  
5. Доступ к узлу с индексом 0 в полученной фигуре SmartArt.  
6. Теперь доступ к **дочернему узлу** (https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArtNode#getChildNodes--) в позиции 1 для выбранного узла SmartArt с помощью метода **get_Item()**.  
7. Доступ и вывод информации, такой как позиция **дочернего узла** (https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArtNode#getChildNodes--), уровень и текст.  
```java
// Создать экземпляр презентации
Presentation pres = new Presentation();
try {
    // Доступ к первому слайду
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Добавление SmartArt формы в первый слайд
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

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) и загрузите презентацию с фигурой SmartArt.  
2. Получите ссылку на первый слайд, используя его индекс.  
3. Пройдитесь по каждой фигуре на первом слайде.  
4. Проверьте, является ли фигура типом [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt) и приведите выбранную фигуру к типу [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt), если это SmartArt.  
5. Проверьте, содержит ли SmartArt более 0 узлов.  
6. Выберите узел SmartArt, который нужно удалить.  
7. Теперь удалите выбранный узел с помощью метода [**RemoveNode**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArtNodeCollection#removeNode-com.aspose.slides.ISmartArtNode-).  
8. Сохраните презентацию.  
```java
// Загрузить нужную презентацию
Presentation pres = new Presentation("AddSmartArtNode.pptx");
try {
    // Обойти каждую фигуру на первом слайде
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // Проверить, является ли фигура типом SmartArt
        if (shape instanceof ISmartArt) 
        {
            // Привести фигуру к типу SmartArt
            ISmartArt smart = (ISmartArt) shape;
    
            if (smart.getAllNodes().size() > 0) 
            {
                // Доступ к узлу SmartArt с индексом 0
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

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) и загрузите презентацию с фигурой SmartArt.  
2. Получите ссылку на первый слайд, используя его индекс.  
3. Пройдитесь по каждой фигуре на первом слайде.  
4. Проверьте, является ли фигура типом [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt) и приведите выбранную фигуру к типу [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt), если это SmartArt.  
5. Выберите узел фигуры SmartArt с индексом 0.  
6. Теперь проверьте, содержит ли выбранный узел SmartArt более 2 дочерних узла.  
7. Теперь удалите узел в **позиции 1** с помощью метода [**RemoveNode**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArtNodeCollection#removeNode-int-).  
8. Сохраните презентацию.  
```java
// Загрузить нужную презентацию
Presentation pres = new Presentation("AddSmartArtNode.pptx");
try {
    // Обойти каждую фигуру на первом слайде
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // Проверить, является ли фигура типом SmartArt
        if (shape instanceof SmartArt) 
        {
            // Привести фигуру к типу SmartArt
            SmartArt smart = (SmartArt) shape;
    
            if (smart.getAllNodes().size() > 0) 
            {
                // Доступ к узлу SmartArt с индексом 0
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
Теперь Aspose.Slides for Android via Java поддерживает установку свойств [SmartArtShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArtShape) **X** (https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#setX-float-) и **Y** (https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#setY-float-). Ниже показан фрагмент кода, который задаёт пользовательскую позицию, размер и поворот SmartArtShape; также обратите внимание, что добавление новых узлов приводит к перерасчёту позиций и размеров всех узлов. С пользовательскими настройками позиции пользователь может размещать узлы согласно требованиям.  
```java
// Создать экземпляр класса Presentation
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try{
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(20, 20, 600, 500, SmartArtLayoutType.OrganizationChart);

    // Переместить форму SmartArt в новую позицию
    ISmartArtNode node = smart.getAllNodes().get_Item(1);
    ISmartArtShape shape = node.getShapes().get_Item(1);
    shape.setX(shape.getX() + shape.getWidth() * 2);
    shape.setY(shape.getY() - shape.getHeight() * 2);

    // Изменить ширину формы SmartArt
    node = smart.getAllNodes().get_Item(2);
    shape = node.getShapes().get_Item(1);
    shape.setWidth(shape.getWidth() + shape.getWidth() * 2);

    // Изменить высоту формы SmartArt
    node = smart.getAllNodes().get_Item(3);
    shape = node.getShapes().get_Item(1);
    shape.setHeight(shape.getHeight() + shape.getHeight() * 2);

    // Изменить поворот формы SmartArt
    node = smart.getAllNodes().get_Item(4);
    shape = node.getShapes().get_Item(1);
    shape.setRotation(90);

    pres.save("SmartArt.pptx", SaveFormat.Pptx);
}finally {
    pres.dispose();
}
```


## **Проверка узла‑ассистента**
{{% alert color="primary" %}} 

В этой статье мы подробнее рассмотрим возможности фигур SmartArt, добавляемых в слайды презентаций программно с помощью Aspose.Slides for Android via Java.

{{% /alert %}} 

Для исследования в различных разделах статьи мы будем использовать следующую исходную фигуру SmartArt.

|![todo:image_alt_text](https://i.imgur.com/FItwczY.png)|
| :- |
|**Рисунок: Исходная фигура SmartArt в слайде**|

В следующем примере кода мы исследуем, как определить **узлы‑ассистенты** в коллекции узлов SmartArt и изменить их.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) и загрузите презентацию с фигурой SmartArt.  
2. Получите ссылку на второй слайд, используя его индекс.  
3. Пройдитесь по каждой фигуре внутри первого слайда.  
4. Проверьте, является ли фигура типом [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt) и приведите выбранную фигуру к типу [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt), если это SmartArt.  
5. Пройдитесь по всем узлам внутри фигуры SmartArt и проверьте, являются ли они [**узлами‑ассистентами**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArtNode#isAssistant--).  
6. Измените статус узла‑ассистента на обычный узел.  
7. Сохраните презентацию.  
```java
// Создание экземпляра презентации
Presentation pres = new Presentation("AddNodes.pptx");
try {
    // Обход каждой фигуры на первом слайде
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // Проверка, является ли фигура типом SmartArt
        if (shape instanceof ISmartArt) 
        {
            // Приведение фигуры к типу SmartArt
            ISmartArt smart = (SmartArt) shape;
    
            // Обход всех узлов фигуры SmartArt
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                ISmartArtNode node = smart.getAllNodes().get_Item(i);
                // Проверка, является ли узел помощником
                if (node.isAssistant()) 
                {
                    // Установка свойства Assistant у узла в false, делаем его обычным узлом
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
|**Рисунок: Узлы‑ассистенты изменены в фигуре SmartArt внутри слайда**|

## **Установить формат заполнения узла**
Aspose.Slides for Android via Java позволяет добавлять пользовательские фигуры SmartArt и задавать им формат заполнения. В этой статье объясняется, как создавать и получать доступ к фигурам SmartArt и задавать им формат заполнения с помощью Aspose.Slides for Android via Java.

Пожалуйста, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).  
2. Получите ссылку на слайд, используя его индекс.  
3. Добавьте фигуру [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt), задав её [**LayoutType**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArtLayoutType#ClosedChevronProcess).  
4. Задайте [**FillFormat**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#getFillFormat--) для узлов фигуры SmartArt.  
5. Сохраните изменённую презентацию в виде файла PPTX.  
```java
// Создать экземпляр презентации
Presentation pres = new Presentation();
try {
    // Доступ к слайду
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Добавление SmartArt формы и узлов
    ISmartArt chevron = slide.getShapes().addSmartArt(10, 10, 800, 60, SmartArtLayoutType.ClosedChevronProcess);
    ISmartArtNode node = chevron.getAllNodes().addNode();
    node.getTextFrame().setText("Some text");
    
    // Установка цвета заполнения узла
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


## **Создать миниатюру дочернего узла SmartArt**
Разработчики могут создать миниатюру дочернего узла SmartArt, выполнив следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).  
2. [Добавьте SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArtNodeCollection#addNode--).  
3. Получите ссылку на узел, используя его индекс.  
4. Получите изображение миниатюры.  
5. Сохраните изображение миниатюры в любом нужном формате.  
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

Да. SmartArt рассматривается как обычная фигура, поэтому вы можете [применять стандартные анимации](/slides/ru/androidjava/shape-animation/) (вход, выход, акцент, траектории движения) и настраивать тайминг. При необходимости можно анимировать фигуры внутри узлов SmartArt.

**Как надёжно найти конкретный SmartArt на слайде, если его внутренний ID неизвестен?**

Назначьте и ищите по [альтернативному тексту](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getAlternativeText--). Установка уникального AltText у SmartArt позволяет программно находить его без использования внутренних идентификаторов.

**Сохранится ли внешний вид SmartArt при конвертации презентации в PDF?**

Да. Aspose.Slides визуализирует SmartArt с высокой точностью при [экспорте в PDF](/slides/ru/androidjava/convert-powerpoint-to-pdf/), сохраняя макет, цвета и эффекты.

**Можно ли извлечь изображение всего SmartArt (для превью или отчётов)?**

Да. Вы можете отрисовать фигуру SmartArt в [растровый формат](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getImage-int-float-float-) или в [SVG](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-), что подходит для миниатюр, отчётов или веб‑использования.