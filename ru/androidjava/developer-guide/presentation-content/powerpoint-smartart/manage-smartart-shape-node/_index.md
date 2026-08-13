---
title: Управление узлами фигур SmartArt в презентациях на Android
linktitle: Узел фигуры SmartArt
type: docs
weight: 30
url: /ru/androidjava/manage-smartart-shape-node/
keywords:
- Узел SmartArt
- дочерний узел
- добавить узел
- позиция узла
- доступ к узлу
- удалить узел
- пользовательская позиция
- вспомогательный узел
- формат заливки
- отрисовка узла
- PowerPoint
- презентация
- Android
- Java
- Aspose.Slides
description: "Управляйте узлами фигур SmartArt в PPT и PPTX с помощью Aspose.Slides для Android. Получайте ясные примеры кода на Java и советы по оптимизации ваших презентаций."
---
## **Обзор**

Графика SmartArt в презентациях PowerPoint организована с помощью узлов, содержащих текст и определяющих структуру диаграммы. Aspose.Slides позволяет программно работать с этими узлами SmartArt: добавлять новые узлы и дочерние узлы, вставлять дочерние узлы в определённую позицию, получать доступ к существующим узлам и считывать их текст, уровень и позицию.

В этой статье объясняется, как управлять узлами фигур SmartArt. Показано, как удалять узлы, работать с дочерними узлами по индексу или позиции, преобразовать вспомогательный узел в обычный, изменять позицию, размер и вращение фигур узлов SmartArt, задавать форматы заливки узлов и генерировать миниатюру узла SmartArt.

## **Добавление узла SmartArt**
Aspose.Slides for Android via Java предоставляет самый простой API для управления фигурами SmartArt самым лёгким способом. Ниже приведён пример кода, который поможет добавить узел и дочерний узел внутри фигуры SmartArt.

1. Создайте экземпляр класса [Презентация](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/Presentation) и загрузите презентацию с фигурой SmartArt.  
2. Получите ссылку на первый слайд, используя его индекс.  
3. Пройдитесь по всем фигурам на первом слайде.  
4. Проверьте, является ли фигура типом [SmartArt](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ISmartArt), и выполните приведение выбранной фигуры к типу [SmartArt](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ISmartArt), если это SmartArt.  
5. [Добавьте новый узел](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ISmartArtNodeCollection#addNode--) в коллекцию [**NodeCollection**](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ISmartArt#getAllNodes--) фигуры SmartArt и задайте текст в TextFrame.  
6. Теперь [добавьте](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ISmartArtNodeCollection#addNode--) [**дочерний узел**](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ISmartArtNode#getChildNodes--) в только что добавленный узел [SmartArt](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ISmartArt) и задайте текст в TextFrame.  
7. Сохраните презентацию.

```java
import com.aspose.slides.*;

// Загрузите нужную презентацию
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try {
    // Пройдитесь по всем фигурам на первом слайде
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

## **Добавление узла SmartArt в определённую позицию**
В следующем примере кода объясняется, как добавить дочерние узлы, принадлежащие соответствующим узлам фигуры SmartArt, в конкретную позицию.

1. Создайте экземпляр класса Презентация.  
2. Получите ссылку на первый слайд, используя его индекс.  
3. Добавьте фигуру SmartArt типа [**StackedList**](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/SmartArtLayoutType#StackedList) на выбранный слайд.  
4. Получите первый узел в добавленной фигуре SmartArt.  
5. Теперь добавьте [**дочерний узел**](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ISmartArtNode#getChildNodes--) для выбранного [**узла**](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/SmartArtNode) в позиции 2 и задайте его текст.  
6. Сохраните презентацию.

```java
import com.aspose.slides.*;

// Создание экземпляра презентации
Presentation pres = new Presentation();
try {
    // Получить слайд презентации
    ISlide slide = pres.getSlides().get_Item(0);

    // Добавить Smart Art IShape
    ISmartArt smart = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);

    // Получение узла SmartArt с индексом 0
    ISmartArtNode node = smart.getAllNodes().get_Item(0);

    // Добавление нового дочернего узла в позицию 2 в родительском узле
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
Следующий пример кода поможет получить доступ к узлам внутри фигуры SmartArt. Обратите внимание, что LayoutType SmartArt выбирается при добавлении фигуры; изменение его позже с помощью **setLayout** перестраивает всю диаграмму, поэтому позиции и размеры узлов, которые вы могли задать, пересчитываются.

1. Создайте экземпляр класса [Презентация](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation) и загрузите презентацию с фигурой SmartArt.  
2. Получите ссылку на первый слайд, используя его индекс.  
3. Пройдитесь по всем фигурам на первом слайде.  
4. Проверьте, является ли фигура типом [SmartArt](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ISmartArt), и выполните приведение выбранной фигуры к типу [SmartArt](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ISmartArt), если это SmartArt.  
5. Пройдитесь по всем [**узлам**](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/SmartArt#getAllNodes--) внутри фигуры SmartArt.  
6. Получите и отобразите информацию, такую как позиция узла SmartArt, уровень и текст.

```java
import com.aspose.slides.*;

// Создать экземпляр класса Presentation
Presentation pres = new Presentation("SmartArtShape.pptx");
try {
    // Получить первый слайд
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Пройтись по всем фигурам на первом слайде
    for (IShape shape : slide.getShapes()) 
    {
        // Проверить, является ли фигура типом SmartArt
        if (shape instanceof ISmartArt) 
        {
            // Привести фигуру к типу SmartArt
            ISmartArt smart = (ISmartArt) shape;
    
            // Пройтись по всем узлам внутри SmartArt
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                // Получение узла SmartArt с индексом i
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

1. Создайте экземпляр класса [Презентация](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation) и загрузите презентацию с фигурой SmartArt.  
2. Получите ссылку на первый слайд, используя его индекс.  
3. Пройдитесь по всем фигурам на первом слайде.  
4. Проверьте, является ли фигура типом [SmartArt](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ISmartArt), и выполните приведение выбранной фигуры к типу [SmartArt](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ISmartArt), если это SmartArt.  
5. Пройдитесь по всем [**узлам**](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/SmartArt#getAllNodes--) внутри фигуры SmartArt.  
6. Для каждого выбранного узла фигуры SmartArt [**Node**](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/SmartArtNode) пройдитесь по всем [**дочерним узлам**](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/SmartArtNode#getChildNodes--) внутри конкретного узла.  
7. Получите и отобразите информацию, такую как позиция [**дочернего узла**](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ISmartArtNode#getChildNodes--) , уровень и текст.

```java
import com.aspose.slides.*;

// Создать экземпляр класса Presentation
Presentation pres = new Presentation("AccessChildNodes.pptx");
try {
    // Получить первый слайд
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Пройтись по всем фигурам на первом слайде
    for (IShape shape : slide.getShapes()) 
    {
        // Проверить, является ли фигура типом SmartArt
        if (shape instanceof ISmartArt) 
        {
            // Привести фигуру к типу SmartArt
            ISmartArt smart = (ISmartArt) shape;
    
            // Пройтись по всем узлам внутри SmartArt
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                // Получение узла SmartArt с индексом i
                SmartArtNode node0 = (SmartArtNode) smart.getAllNodes().get_Item(i);
                
                // Пройтись по дочерним узлам узла SmartArt с индексом i
                for (int j = 0; j < node0.getChildNodes().size(); j++) 
                {
                    // Получение дочернего узла в узле SmartArt
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
В этом примере мы узнаем, как получить доступ к дочерним узлам в определённой позиции, принадлежащим соответствующим узлам фигуры SmartArt.

1. Создайте экземпляр класса [Презентация](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation).  
2. Получите ссылку на первый слайд, используя его индекс.  
3. Добавьте фигуру SmartArt типа [**StackedList**](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/SmartArtLayoutType#StackedList).  
4. Получите добавленную фигуру SmartArt.  
5. Получите узел с индексом 0 для полученной фигуры SmartArt.  
6. Теперь получите [**дочерний узел**](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ISmartArtNode#getChildNodes--) в позиции 1 для выбранного узла SmartArt, используя метод **get_Item()**.  
7. Получите и отобразите информацию, такую как позиция [**дочернего узла**](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ISmartArtNode#getChildNodes--) , уровень и текст.

```java
import com.aspose.slides.*;

// Создать экземпляр презентации
Presentation pres = new Presentation();
try {
    // Получение первого слайда
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Добавление фигуры SmartArt на первый слайд
    ISmartArt smart = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);
    
    // Доступ к узлу SmartArt с индексом 0
    ISmartArtNode node = smart.getAllNodes().get_Item(0);
    
    // Доступ к дочернему узлу в позиции 1 родительского узла
    int position = 1;
    SmartArtNode chNode = (SmartArtNode) ((SmartArtNodeCollection) node.getChildNodes()).get_Item(position);
    
    // Вывод параметров дочернего узла SmartArt
    System.out.print("Text = " + chNode.getTextFrame().getText() + ",  Level = " + chNode.getLevel() + ", Position = " + chNode.getPosition());
} finally {
    if (pres != null) pres.dispose();
}
```

## **Удаление узла SmartArt**
В этом примере мы узнаем, как удалять узлы внутри фигуры SmartArt.

1. Создайте экземпляр класса [Презентация](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation) и загрузите презентацию с фигурой SmartArt.  
2. Получите ссылку на первый слайд, используя его индекс.  
3. Пройдитесь по всем фигурам на первом слайде.  
4. Проверьте, является ли фигура типом [SmartArt](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ISmartArt), и выполните приведение выбранной фигуры к типу [SmartArt](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ISmartArt), если это SmartArt.  
5. Проверьте, содержит ли [SmartArt](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ISmartArt) более 0 узлов.  
6. Выберите узел SmartArt, который нужно удалить.  
7. Теперь удалите выбранный узел с помощью метода [**RemoveNode**](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ISmartArtNodeCollection#removeNode-com.aspose.slides.ISmartArtNode-).  
8. Сохраните презентацию.

```java
import com.aspose.slides.*;

// Загрузите нужную презентацию
Presentation pres = new Presentation("AddSmartArtNode.pptx");
try {
    // Пройдитесь по всем фигурам на первом слайде
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // Проверьте, является ли фигура типом SmartArt
        if (shape instanceof ISmartArt) 
        {
            // Приведите фигуру к типу SmartArt
            ISmartArt smart = (ISmartArt) shape;
    
            if (smart.getAllNodes().size() > 0) 
            {
                // Получение узла SmartArt с индексом 0
                ISmartArtNode node = smart.getAllNodes().get_Item(0);
    
                // Удаление выбранного узла
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

## **Удаление узла SmartArt из определённой позиции**
В этом примере мы узнаем, как удалять узлы внутри фигуры SmartArt в конкретной позиции.

1. Создайте экземпляр класса [Презентация](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation) и загрузите презентацию с фигурой SmartArt.  
2. Получите ссылку на первый слайд, используя его индекс.  
3. Пройдитесь по всем фигурам на первом слайде.  
4. Проверьте, является ли фигура типом [SmartArt](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ISmartArt), и выполните приведение выбранной фигуры к типу [SmartArt](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ISmartArt), если это SmartArt.  
5. Выберите узел фигуры SmartArt с индексом 0.  
6. Теперь проверьте, содержит ли выбранный узел SmartArt более 2 дочерних узлов.  
7. Удалите узел в **позиции 1** с помощью метода [**RemoveNode**](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ISmartArtNodeCollection#removeNode-int-).  
8. Сохраните презентацию.

```java
import com.aspose.slides.*;

// Загрузите нужную презентацию
Presentation pres = new Presentation("AddSmartArtNode.pptx");
try {
    // Пройдитесь по всем фигурам на первом слайде
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // Проверьте, является ли фигура типом SmartArt
        if (shape instanceof SmartArt) 
        {
            // Приведите фигуру к типу SmartArt
            SmartArt smart = (SmartArt) shape;
    
            if (smart.getAllNodes().size() > 0) 
            {
                // Получение узла SmartArt с индексом 0
                ISmartArtNode node = smart.getAllNodes().get_Item(0);
    
                if (node.getChildNodes().size() >= 2) 
                {
                    // Удаление дочернего узла в позиции 1
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

## **Установка пользовательской позиции для дочернего узла в объекте SmartArt**
Теперь Aspose.Slides for Android via Java поддерживает установку свойств [SmartArtShape](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/SmartArtShape) [X](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/IShape#setX-float-) и [Y](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/IShape#setY-float-). Ниже показан фрагмент кода, который демонстрирует, как задать пользовательскую позицию, размер и вращение SmartArtShape; обратите внимание, что добавление новых узлов приводит к пересчёту позиций и размеров всех узлов. Также при пользовательских настройках позиции пользователь может задавать узлы в соответствии с требованиями.

```java
import com.aspose.slides.*;

// Создать экземпляр класса Presentation
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try{
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(20, 20, 600, 500, SmartArtLayoutType.OrganizationChart);

    // Переместить фигуру SmartArt в новую позицию
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

## **Проверка вспомогательного узла**
{{% alert color="info" %}} 

В этой статье мы дальше исследуем возможности фигур SmartArt, добавляемых в слайды презентаций программно с помощью Aspose.Slides for Android via Java.

{{% /alert %}} 

Для наших исследований в разных разделах статьи будет использоваться следующая исходная фигура SmartArt.

|![todo:image_alt_text](https://i.imgur.com/FItwczY.png)|
| :- |
|**Рисунок: Исходная фигура SmartArt на слайде**|

В следующем примере кода мы исследуем, как определить **вспомогательные узлы** в коллекции узлов SmartArt и изменить их.

1. Создайте экземпляр класса [Презентация](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation) и загрузите презентацию с фигурой SmartArt.  
2. Получите ссылку на первый слайд, используя его индекс.  
3. Пройдитесь по всем фигурам на первом слайде.  
4. Проверьте, является ли фигура типом [SmartArt](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ISmartArt), и выполните приведение выбранной фигуры к типу [SmartArt](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ISmartArt), если это SmartArt.  
5. Пройдитесь по всем узлам внутри фигуры SmartArt и проверьте, являются ли они [**вспомогательными узлами**](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/SmartArtNode#isAssistant--).  
6. Измените статус вспомогательного узла на обычный узел.  
7. Сохраните презентацию.

```java
import com.aspose.slides.*;

// Создание экземпляра презентации
Presentation pres = new Presentation("AddNodes.pptx");
try {
    // Пройтись по всем фигурам на первом слайде
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // Проверить, является ли фигура типом SmartArt
        if (shape instanceof ISmartArt) 
        {
            // Привести фигуру к типу SmartArt
            ISmartArt smart = (SmartArt) shape;
    
            // Пройтись по всем узлам фигуры SmartArt
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                ISmartArtNode node = smart.getAllNodes().get_Item(i);
                // Проверить, является ли узел вспомогательным
                if (node.isAssistant()) 
                {
                    // Установить свойство Assistant у узла в false и сделать его обычным узлом
                    node.setAssistant(false);
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
|**Рисунок: Вспомогательные узлы изменены в фигуре SmartArt на слайде**|

## **Установка формата заливки узла**
Aspose.Slides for Android via Java делает возможным добавление пользовательских фигур SmartArt и задание их формата заливки. Эта статья объясняет, как создавать и получать доступ к фигурам SmartArt и задавать их формат заливки с помощью Aspose.Slides for Android via Java.

Пожалуйста, выполните следующие шаги:

1. Создайте экземпляр класса [Презентация](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation).  
2. Получите ссылку на слайд, используя его индекс.  
3. Добавьте фигуру [SmartArt](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ISmartArt), задав её [**LayoutType**](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/SmartArtLayoutType#ClosedChevronProcess).  
4. Задайте [**FillFormat**](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/IShape#getFillFormat--) для узлов фигуры SmartArt.  
5. Запишите изменённую презентацию в файл PPTX.

```java
import com.aspose.slides.*;
import java.awt.Color;

// Создать экземпляр презентации
Presentation pres = new Presentation();
try {
    // Получение слайда
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

## **Генерация миниатюры узла SmartArt**
Разработчики могут создать миниатюру узла SmartArt, выполнив следующие шаги:

1. Создайте экземпляр класса [Презентация](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation).  
2. [Добавьте SmartArt](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ISmartArtNodeCollection#addNode--).  
3. Получите ссылку на узел, используя его индекс.  
4. Получите изображение миниатюры.  
5. Сохраните изображение миниатюры в любом желаемом формате изображения.

```java
import com.aspose.slides.*;

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

### Поддерживается ли анимация SmartArt?

Да. SmartArt рассматривается как обычная фигура, поэтому вы можете [применять стандартные анимации](/slides/ru/androidjava/shape-animation/) (вход, выход, акцент, траектории движения) и настраивать тайминг. При необходимости можно анимировать фигуры внутри узлов SmartArt.

### Как надёжно найти конкретный SmartArt на слайде, если его внутренний ID неизвестен?

Используйте поиск по [альтернативному тексту](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/shape/#getAlternativeText--). Установив отличительный AltText для SmartArt, вы сможете находить его программно без привязки к внутренним идентификаторам.

### Сохранится ли внешний вид SmartArt при конвертации презентации в PDF?

Да. Aspose.Slides рендерит SmartArt с высокой визуальной точностью при [экспорте в PDF](/slides/ru/androidjava/convert-powerpoint-to-pdf/), сохраняя макет, цвета и эффекты.

### Могу ли я извлечь изображение всего SmartArt (для превью или отчётов)?

Да. Вы можете отрисовать фигуру SmartArt в [растровые форматы](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/shape/#getImage-int-float-float-) или в [SVG](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-), получая масштабируемый векторный вывод, подходящий для миниатюр, отчётов или веб‑использования.