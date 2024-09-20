---
title: Управление формой SmartArt
type: docs
weight: 20
url: /java/manage-smartart-shape/
---


## **Создание формы SmartArt**
Aspose.Slides для Java предоставляет API для создания форм SmartArt. Чтобы создать форму SmartArt на слайде, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Получите ссылку на слайд, используя его индекс.
3. [Добавьте форму SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) установив для неё [LayoutType](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArtLayoutType).
4. Сохраните изменённую презентацию в файл PPTX.

```java
// Создание экземпляра класса Presentation
Presentation pres = new Presentation();
try {
    // Получение первого слайда
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Добавление формы Smart Art
    ISmartArt smart = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.BasicBlockList);
    
    // Сохранение презентации
    pres.save("SimpleSmartArt.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**Рисунок: форма SmartArt добавлена на слайд**|

## **Доступ к форме SmartArt на слайде**
Следующий код будет использоваться для доступа к формам SmartArt, добавленным на слайде презентации. В образце кода мы пройдём через каждую форму внутри слайда и проверим, является ли она [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt) формой. Если форма является типом SmartArt, то мы приведём её к экземпляру [**SmartArt**](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt).

```java
// Загрузка необходимой презентации
Presentation pres = new Presentation("AccessSmartArtShape.pptx");
try {
    // Проход по каждой форме внутри первого слайда
    for (IShape shape : pres.getSlides().get_Item(0).getShapes())
    {
        // Проверка, является ли форма типом SmartArt
        if (shape instanceof ISmartArt)
        {
            // Приведение формы к SmartArtEx
            ISmartArt smart = (ISmartArt)shape;
            System.out.println("Название формы:" + smart.getName());
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Доступ к форме SmartArt с определённым типом макета**
Следующий образец кода поможет получить доступ к форме [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt) с определённым типом макета. Обратите внимание, что вы не можете изменить тип макета формы SmartArt, так как он является только для чтения и устанавливается только при добавлении формы [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt).

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) и загрузите презентацию с формой SmartArt.
2. Получите ссылку на первый слайд, используя его индекс.
3. Проходите через каждую форму внутри первого слайда.
4. Проверьте, является ли форма типом [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt) и приведите выбранную форму к SmartArt, если это SmartArt.
5. Проверьте форму SmartArt с определённым типом макета и выполните всё необходимое впоследствии.

```java
Presentation pres = new Presentation("AccessSmartArtShape.pptx");
try {
    // Проход по каждой форме внутри первого слайда
    for (IShape shape : pres.getSlides().get_Item(0).getShapes())
    {
        // Проверка, является ли форма типом SmartArt
        if (shape instanceof ISmartArt)
        {
            // Приведение формы к SmartArtEx
            ISmartArt smart = (ISmartArt) shape;

            // Проверка макета SmartArt
            if (smart.getLayout() == SmartArtLayoutType.BasicBlockList)
            {
                System.out.println("Выполните какое-нибудь действие здесь....");
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Изменение стиля формы SmartArt**
В этом примере мы узнаем, как изменить быстрый стиль для любой формы SmartArt.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) и загрузите презентацию с формой SmartArt.
2. Получите ссылку на первый слайд, используя его индекс.
3. Проходите через каждую форму внутри первого слайда.
4. Проверьте, является ли форма типом [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt) и приведите выбранную форму к SmartArt, если это SmartArt.
5. Найдите форму SmartArt с определённым стилем.
6. Установите новый стиль для формы SmartArt.
7. Сохраните презентацию.

```java
// Создание экземпляра класса Presentation
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try {
    // Получение первого слайда
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Проход по каждой форме внутри первого слайда
    for (IShape shape : slide.getShapes()) 
    {
        // Проверка, является ли форма типом SmartArt
        if (shape instanceof ISmartArt) 
        {
            // Приведение формы к SmartArtEx
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
|**Рисунок: форма SmartArt с изменённым стилем**|

## **Изменение цветового стиля формы SmartArt**
В этом примере мы узнаем, как изменить цветовой стиль для любой формы SmartArt. В приведённом ниже образце кода будет доступ к форме SmartArt с определённым цветовым стилем и будет изменён его стиль.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) и загрузите презентацию с формой SmartArt.
2. Получите ссылку на первый слайд, используя его индекс.
3. Проходите через каждую форму внутри первого слайда.
4. Проверьте, является ли форма типом [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt) и приведите выбранную форму к SmartArt, если это SmartArt.
5. Найдите форму SmartArt с определённым цветовым стилем.
6. Установите новый цветовой стиль для формы SmartArt.
7. Сохраните презентацию.

```java
// Создание экземпляра класса Presentation
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try {
    // Получение первого слайда
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Проход по каждой форме внутри первого слайда
    for (IShape shape : slide.getShapes()) 
    {
        // Проверка, является ли форма типом SmartArt
        if (shape instanceof ISmartArt) 
        {
            // Приведение формы к SmartArtEx
            ISmartArt smart = (ISmartArt) shape;
    
            // Проверка цветового типа SmartArt
            if (smart.getColorStyle() == SmartArtColorType.ColoredFillAccent1) {
                // Изменение цветового типа SmartArt
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
|**Рисунок: форма SmartArt с изменённым цветовым стилем**|