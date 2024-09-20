---
title: Управление формой SmartArt
type: docs
weight: 20
url: /androidjava/manage-smartart-shape/
---


## **Создать форму SmartArt**
Aspose.Slides для Android на Java предоставляет API для создания форм SmartArt. Чтобы создать форму SmartArt на слайде, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. Получите ссылку на слайд, используя его индекс.
1. [Добавьте форму SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-), установив [LayoutType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArtLayoutType).
1. Сохраните измененную презентацию как файл PPTX.

```java
// Создать экземпляр класса Presentation
Presentation pres = new Presentation();
try {
    // Получить первый слайд
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Добавить форму Smart Art
    ISmartArt smart = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.BasicBlockList);
    
    // Сохранение презентации
    pres.save("SimpleSmartArt.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**Рисунок: Форма SmartArt добавлена на слайд**|

## **Доступ к форме SmartArt на слайде**
Следующий код будет использоваться для доступа к формам SmartArt, добавленным на слайд презентации. В примере кода мы пройдем через каждую форму внутри слайда и проверим, является ли она формой [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArt). Если форма является типом SmartArt, то мы приведем ее к экземпляру [**SmartArt**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArt).

```java
// Загрузить нужную презентацию
Presentation pres = new Presentation("AccessSmartArtShape.pptx");
try {
    // Пройти через каждую форму внутри первого слайда
    for (IShape shape : pres.getSlides().get_Item(0).getShapes())
    {
        // Проверить, является ли форма типом SmartArt
        if (shape instanceof ISmartArt)
        {
            // Привести форму к SmartArtEx
            ISmartArt smart = (ISmartArt)shape;
            System.out.println("Имя формы:" + smart.getName());
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Доступ к форме SmartArt с определенным типом компоновки**
Следующий пример кода поможет получить доступ к форме [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArt) с определенным типом компоновки. Пожалуйста, учтите, что вы не можете изменить тип компоновки SmartArt, так как он является только для чтения и устанавливается только при добавлении формы [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArt).

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) и загрузите презентацию с формой SmartArt.
1. Получите ссылку на первый слайд, используя его индекс.
1. Пройдите через каждую форму внутри первого слайда.
1. Проверьте, является ли форма типом [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArt) и приведите выбранную форму к SmartArt, если это SmartArt.
1. Проверьте форму SmartArt с определенным типом компоновки и выполните необходимые действия.

```java
Presentation pres = new Presentation("AccessSmartArtShape.pptx");
try {
    // Пройти через каждую форму внутри первого слайда
    for (IShape shape : pres.getSlides().get_Item(0).getShapes())
    {
        // Проверить, является ли форма типом SmartArt
        if (shape instanceof ISmartArt)
        {
            // Привести форму к SmartArtEx
            ISmartArt smart = (ISmartArt) shape;

            // Проверка компоновки SmartArt
            if (smart.getLayout() == SmartArtLayoutType.BasicBlockList)
            {
                System.out.println("Выполнить какое-то действие здесь....");
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Изменить стиль формы SmartArt**
В этом примере мы научимся изменять быстрый стиль для любой формы SmartArt.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) и загрузите презентацию с формой SmartArt.
1. Получите ссылку на первый слайд, используя его индекс.
1. Пройдите через каждую форму внутри первого слайда.
1. Проверьте, является ли форма типом [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArt) и приведите выбранную форму к SmartArt, если это SmartArt.
1. Найдите форму SmartArt с определенным стилем.
1. Установите новый стиль для формы SmartArt.
1. Сохраните презентацию.

```java
// Создать экземпляр класса Presentation
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try {
    // Получить первый слайд
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Пройти через каждую форму внутри первого слайда
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
|**Рисунок: Форма SmartArt со измененным стилем**|

## **Изменить цветовой стиль формы SmartArt**
В этом примере мы научимся изменять цветовой стиль для любой формы SmartArt. В следующем примере кода будет получена форма SmartArt с определенным цветовым стилем, и ее стиль будет изменен.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) и загрузите презентацию с формой SmartArt.
1. Получите ссылку на первый слайд, используя его индекс.
1. Пройдите через каждую форму внутри первого слайда.
1. Проверьте, является ли форма типом [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArt) и приведите выбранную форму к SmartArt, если это SmartArt.
1. Найдите форму SmartArt с определенным цветовым стилем.
1. Установите новый цветовой стиль для формы SmartArt.
1. Сохраните презентацию.

```java
// Создать экземпляр класса Presentation
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try {
    // Получить первый слайд
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Пройти через каждую форму внутри первого слайда
    for (IShape shape : slide.getShapes()) 
    {
        // Проверить, является ли форма типом SmartArt
        if (shape instanceof ISmartArt) 
        {
            // Привести форму к SmartArtEx
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
|**Рисунок: Форма SmartArt со измененным цветовым стилем**|