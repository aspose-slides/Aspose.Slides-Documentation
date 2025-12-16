---
title: Управление графикой SmartArt в презентациях на Android
linktitle: Графика SmartArt
type: docs
weight: 20
url: /ru/androidjava/manage-smartart-shape/
keywords:
- объект SmartArt
- графика SmartArt
- стиль SmartArt
- цвет SmartArt
- создание SmartArt
- добавление SmartArt
- редактирование SmartArt
- изменение SmartArt
- доступ к SmartArt
- тип раскладки SmartArt
- PowerPoint
- презентация
- Android
- Java
- Aspose.Slides
description: "Автоматизируйте создание, редактирование и стилизацию SmartArt в PowerPoint с помощью Aspose.Slides для Android, включая лаконичные примеры кода на Java и рекомендации, ориентированные на производительность."
---

## **Создать SmartArt форму**
Aspose.Slides for Android via Java предоставляет API для создания SmartArt форм. Чтобы создать SmartArt форму на слайде, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Получите ссылку на слайд, используя его индекс.
3. [Добавить SmartArt форму](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) установив её [LayoutType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArtLayoutType).
4. Сохраните изменённую презентацию как файл PPTX.
```java
// Создать экземпляр класса Presentation
Presentation pres = new Presentation();
try {
    // Получить первый слайд
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Добавить форму SmartArt
    ISmartArt smart = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.BasicBlockList);
    
    // Сохранение презентации
    pres.save("SimpleSmartArt.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**Рисунок: SmartArt форма, добавленная на слайд**|

## **Доступ к SmartArt форме на слайде**
В следующем коде будет продемонстрирован доступ к SmartArt формам, добавленным в слайд презентации. В примере кода мы будем проходить по всем формам внутри слайда и проверять, является ли она формой [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArt). Если форма относится к типу SmartArt, мы приведём её к экземпляру [**SmartArt**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArt).
```java
// Загрузить нужную презентацию
Presentation pres = new Presentation("AccessSmartArtShape.pptx");
try {
    // Пройтись по всем фигурам внутри первого слайда
    for (IShape shape : pres.getSlides().get_Item(0).getShapes())
    {
        // Проверить, является ли фигура типом SmartArt
        if (shape instanceof ISmartArt)
        {
            // Привести тип фигуры к SmartArtEx
            ISmartArt smart = (ISmartArt)shape;
            System.out.println("Shape Name:" + smart.getName());
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```


## **Доступ к SmartArt форме с определённым типом LayoutType**
В следующем примере кода показан доступ к форме [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArt) с конкретным LayoutType. Обратите внимание, что изменить LayoutType SmartArt нельзя — он только для чтения и задаётся при добавлении формы [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArt).

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) и загрузите презентацию с SmartArt формой.
2. Получите ссылку на первый слайд, используя его индекс.
3. Пройдитесь по всем формам внутри первого слайда.
4. Проверьте, относится ли форма к типу [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArt), и при необходимости приведите её к SmartArt.
5. Проверьте SmartArt форму с конкретным LayoutType и выполните требуемые действия.
```java
Presentation pres = new Presentation("AccessSmartArtShape.pptx");
try {
    // Пройтись по всем фигурам внутри первого слайда
    for (IShape shape : pres.getSlides().get_Item(0).getShapes())
    {
        // Проверить, является ли фигура типом SmartArt
        if (shape instanceof ISmartArt)
        {
            // Привести тип фигуры к SmartArtEx
            ISmartArt smart = (ISmartArt) shape;

            // Проверка макета SmartArt
            if (smart.getLayout() == SmartArtLayoutType.BasicBlockList)
            {
                System.out.println("Do some thing here....");
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```


## **Изменить стиль SmartArt формы**
В этом примере мы научимся менять быстрый стиль любой SmartArt формы.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) и загрузите презентацию с SmartArt формой.
2. Получите ссылку на первый слайд, используя его индекс.
3. Пройдитесь по всем формам внутри первого слайда.
4. Проверьте, относится ли форма к типу [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArt), и при необходимости приведите её к SmartArt.
5. Найдите SmartArt форму с конкретным стилем.
6. Установите новый стиль для SmartArt формы.
7. Сохраните презентацию.
```java
// Создать экземпляр класса Presentation
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try {
    // Получить первый слайд
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Пройтись по всем фигурам внутри первого слайда
    for (IShape shape : slide.getShapes()) 
    {
        // Проверить, является ли фигура типом SmartArt
        if (shape instanceof ISmartArt) 
        {
            // Привести тип фигуры к SmartArtEx
            ISmartArt smart = (ISmartArt) shape;
    
            // Проверка стиля SmartArt
            if (smart.getQuickStyle() == SmartArtQuickStyleType.SimpleFill) {
                // Изменение стиля SmartArt
                smart.setQuickStyle(SmartArtQuickStyleType.Cartoon);
            }
        }
    }
    // Сохранение презентации
    pres.save("ChangeSmartArtStyle.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**Рисунок: SmartArt форма с изменённым стилем**|

## **Изменить цветовой стиль SmartArt формы**
В этом примере мы научимся менять цветовой стиль любой SmartArt формы. В следующем примере кода будет продемонстрирован доступ к SmartArt форме с определённым цветовым стилем и изменение этого стиля.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) и загрузите презентацию с SmartArt формой.
2. Получите ссылку на первый слайд, используя его индекс.
3. Пройдитесь по всем формам внутри первого слайда.
4. Проверьте, относится ли форма к типу [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArt), и при необходимости приведите её к SmartArt.
5. Найдите SmartArt форму с конкретным цветовым стилем.
6. Установите новый цветовой стиль для SmartArt формы.
7. Сохраните презентацию.
```java
// Создать экземпляр класса Presentation
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try {
    // Получить первый слайд
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Пройтись по всем фигурам внутри первого слайда
    for (IShape shape : slide.getShapes()) 
    {
        // Проверить, является ли фигура типом SmartArt
        if (shape instanceof ISmartArt) 
        {
            // Привести тип фигуры к SmartArtEx
            ISmartArt smart = (ISmartArt) shape;
    
            // Проверка цвета SmartArt
            if (smart.getColorStyle() == SmartArtColorType.ColoredFillAccent1) {
                // Изменение цвета SmartArt
                smart.setColorStyle(SmartArtColorType.ColorfulAccentColors);
            }
        }
    }
    // Сохранение презентации
    pres.save("ChangeSmartArtColorStyle.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


|![todo:image_alt_text](https://i.imgur.com/v2Hwocs.png)|
| :- |
|**Рисунок: SmartArt форма с изменённым цветовым стилем**|

## **FAQ**

**Можно ли анимировать SmartArt как один объект?**

Да. SmartArt – это форма, поэтому вы можете применять [standard animations](/slides/ru/androidjava/powerpoint-animation/) через API анимаций (вход, выход, акцент, траектории движения) так же, как и для остальных форм.

**Как найти конкретный SmartArt на слайде, если неизвестен его внутренний ID?**

Установите и используйте альтернативный текст (AltText) и ищите форму по этому значению — это рекомендованный способ определения нужной формы.

**Можно ли объединять SmartArt с другими формами?**

Да. Вы можете группировать SmartArt с другими формами (изображения, таблицы и т.д.), а затем [manipulate the group](/slides/ru/androidjava/group/).

**Как получить изображение конкретного SmartArt (например, для предпросмотра или отчёта)?**

Экспортируйте миниатюру/изображение формы; библиотека может [render individual shapes](/slides/ru/androidjava/create-shape-thumbnails/) в растровые файлы (PNG/JPG/TIFF).

**Сохранится ли внешний вид SmartArt при конвертации всей презентации в PDF?**

Да. Рендеринговый движок обеспечивает высокую точность при [PDF export](/slides/ru/androidjava/convert-powerpoint-to-pdf/), предлагая широкий набор параметров качества и совместимости.