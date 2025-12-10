---
title: Управление графикой SmartArt в презентациях с помощью Java
linktitle: Графика SmartArt
type: docs
weight: 20
url: /ru/java/manage-smartart-shape/
keywords:
- Объект SmartArt
- Графика SmartArt
- Стиль SmartArt
- Цвет SmartArt
- Создание SmartArt
- Добавление SmartArt
- Редактирование SmartArt
- Изменение SmartArt
- Доступ к SmartArt
- Тип макета SmartArt
- PowerPoint
- презентация
- Java
- Aspose.Slides
description: "Автоматизируйте создание, редактирование и стилизацию SmartArt в PowerPoint на Java с помощью Aspose.Slides, предоставляя короткие примеры кода и рекомендации, ориентированные на производительность."
---

## **Создание SmartArt-формы**
Aspose.Slides for Java предоставил API для создания SmartArt-форм. Чтобы создать SmartArt-форму на слайде, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Получите ссылку на слайд, используя его индекс.
3. [Добавить SmartArt форму](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) — установив ей [LayoutType](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArtLayoutType).
4. Сохраните изменённую презентацию в файл PPTX.
```java
// Создание экземпляра класса Presentation
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
|**Рисунок: SmartArt-форма, добавленная на слайд**|

## **Доступ к SmartArt-форме на слайде**
В следующем коде будет показано, как получить доступ к SmartArt-формам, добавленным в слайд презентации. В примере кода мы будем обходить каждую форму на слайде и проверять, является ли она формой [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt). Если форма относится к типу SmartArt, мы приведём её к экземпляру [**SmartArt**](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt).
```java
// Загрузить нужную презентацию
Presentation pres = new Presentation("AccessSmartArtShape.pptx");
try {
    // Пройтись по всем формам на первом слайде
    for (IShape shape : pres.getSlides().get_Item(0).getShapes())
    {
        // Проверить, является ли форма типом SmartArt
        if (shape instanceof ISmartArt)
        {
            // Привести форму к SmartArtEx
            ISmartArt smart = (ISmartArt)shape;
            System.out.println("Shape Name:" + smart.getName());
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```


## **Доступ к SmartArt-форме с определённым типом LayoutType**
Следующий пример кода поможет получить доступ к форме [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt) с определённым LayoutType. Обратите внимание, что изменить LayoutType SmartArt невозможно, так как он доступен только для чтения и устанавливается только при добавлении формы [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt).

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) и загрузите презентацию с SmartArt-формой.
2. Получите ссылку на первый слайд, используя его индекс.
3. Пройдитесь по всем формам на первом слайде.
4. Проверьте, относится ли форма к типу [SmartArt]; если да, приведите выбранную форму к SmartArt.
5. Проверьте форму SmartArt с определённым LayoutType и выполните необходимые действия.
```java
Presentation pres = new Presentation("AccessSmartArtShape.pptx");
try {
    // Пройтись по всем формам на первом слайде
    for (IShape shape : pres.getSlides().get_Item(0).getShapes())
    {
        // Проверить, является ли форма типом SmartArt
        if (shape instanceof ISmartArt)
        {
            // Привести форму к SmartArtEx
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


## **Изменение стиля SmartArt-формы**
В этом примере мы научимся изменять быстрый стиль любой SmartArt-формы.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) и загрузите презентацию с SmartArt-формой.
2. Получите ссылку на первый слайд, используя его индекс.
3. Пройдитесь по всем формам на первом слайде.
4. Проверьте, относится ли форма к типу [SmartArt]; если да, приведите выбранную форму к SmartArt.
5. Найдите SmartArt-форму с определённым Style.
6. Установите новый Style для SmartArt-формы.
7. Сохраните презентацию.
```java
// Создать экземпляр класса Presentation
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try {
    // Получить первый слайд
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Пройтись по всем формам внутри первого слайда
    for (IShape shape : slide.getShapes()) 
    {
        // Проверить, является ли форма типом SmartArt
        if (shape instanceof ISmartArt) 
        {
            // Привести форму к SmartArtEx
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
|**Рисунок: SmartArt-форма с изменённым стилем**|

## **Изменение цветового стиля SmartArt-формы**
В этом примере мы научимся изменять цветовой стиль любой SmartArt-формы. В следующем примере кода будет показано, как получить доступ к SmartArt-форме с определённым цветовым стилем и изменить его.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) и загрузите презентацию с SmartArt-формой.
2. Получите ссылку на первый слайд, используя его индекс.
3. Пройдитесь по всем формам на первом слайде.
4. Проверьте, относится ли форма к типу [SmartArt]; если да, приведите выбранную форму к SmartArt.
5. Найдите SmartArt-форму с определённым Color Style.
6. Установите новый Color Style для SmartArt-формы.
7. Сохраните презентацию.
```java
// Создать экземпляр класса Presentation
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try {
    // Получить первый слайд
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Пройтись по всем формам внутри первого слайда
    for (IShape shape : slide.getShapes()) 
    {
        // Проверить, является ли форма типом SmartArt
        if (shape instanceof ISmartArt) 
        {
            // Привести форму к SmartArtEx
            ISmartArt smart = (ISmartArt) shape;
    
            // Проверка типа цвета SmartArt
            if (smart.getColorStyle() == SmartArtColorType.ColoredFillAccent1) {
                // Изменение типа цвета SmartArt
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
|**Рисунок: SmartArt-форма с изменённым цветовым стилем**|

## **FAQ**

**Можно ли анимировать SmartArt как единый объект?**

Да. SmartArt является фигурой, поэтому вы можете применять [стандартные анимации](/slides/ru/java/powerpoint-animation/) через API анимаций (вход, выход, акцент, пути движения), как и для других фигур.

**Как найти конкретный SmartArt на слайде, если я не знаю его внутренний идентификатор?**

Установите и используйте альтернативный текст (AltText) и ищите форму по этому значению — это рекомендуемый способ найти нужную форму.

**Можно ли группировать SmartArt с другими фигурами?**

Да. Вы можете группировать SmartArt с другими фигурами (изображениями, таблицами и т.д.), а затем [манипулировать группой](/slides/ru/java/group/).

**Как получить изображение конкретного SmartArt (например, для превью или отчёта)?**

Экспортируйте миниатюру/изображение формы; библиотека может [рендерить отдельные формы](/slides/ru/java/create-shape-thumbnails/) в растровые файлы (PNG/JPG/TIFF).

**Сохранится ли внешний вид SmartArt при конвертации всей презентации в PDF?**

Да. Рендеринг‑движок обеспечивает высокую точность при [экспорте в PDF](/slides/ru/java/convert-powerpoint-to-pdf/), предлагая различные варианты качества и совместимости.