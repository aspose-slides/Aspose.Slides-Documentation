---
title: Фон для Презентации
type: docs
weight: 20
url: /ru/androidjava/presentation-background/
keywords: "Фон PowerPoint, установить фон в Java"
description: "Установить фон в презентации PowerPoint на Java"
---

Сплошные цвета, градиенты и изображения часто используются в качестве фонов для слайдов. Вы можете установить фон как для **нормального слайда** (одинарный слайд), так и для **мастер-слайда** (несколько слайдов одновременно).

<img src="powerpoint-background.png" alt="powerpoint-background"  />

## **Установка Сплошного Цвета в качестве Фона для Нормального Слайда**

Aspose.Slides позволяет устанавливать сплошной цвет в качестве фона для конкретного слайда в презентации (даже если в этой презентации есть мастер-слайд). Изменение фона затрагивает только выбранный слайд.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Установите перечисление [BackgroundType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/backgroundtype/) для слайда на `OwnBackground`.
3. Установите перечисление [FillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) для фона слайда на `Solid`.
4. Используйте свойство [SolidFillColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fillformat/#getSolidFillColor--) класса [FillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fillformat/), чтобы задать сплошной цвет для фона.
5. Сохраните измененную презентацию.

Этот код на Java показывает, как установить сплошной цвет (синий) в качестве фона для нормального слайда:

```java
// Создает экземпляр класса Presentation
Presentation pres = new Presentation("MasterBG.pptx");
try {
    // Устанавливает цвет фона для первого слайда на Синий
    pres.getSlides().get_Item(0).getBackground().setType(BackgroundType.OwnBackground);
    pres.getSlides().get_Item(0).getBackground().getFillFormat().setFillType(FillType.Solid);
    pres.getSlides().get_Item(0).getBackground().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    
    // Записывает презентацию на диск
    pres.save("ContentBG.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Установка Сплошного Цвета в качестве Фона для Мастер-Слайда**

Aspose.Slides позволяет устанавливать сплошной цвет в качестве фона для мастер-слайда в презентации. Мастер-слайд действует как шаблон, который содержит и управляет настройками форматирования для всех слайдов. Поэтому, когда вы выбираете сплошной цвет в качестве фона для мастер-слайда, этот новый фон будет использован для всех слайдов.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Установите перечисление [BackgroundType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/backgroundtype/) для мастер-слайда (`Masters`) на `OwnBackground`.
3. Установите перечисление [FillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) для фона мастер-слайда на `Solid`.
4. Используйте свойство [SolidFillColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fillformat/#getSolidFillColor--) класса [FillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fillformat/), чтобы задать сплошной цвет для фона.
5. Сохраните измененную презентацию.

Этот код на Java показывает, как установить сплошной цвет (лесной зеленый) в качестве фона для мастер-слайда в презентации:

```java
// Создает экземпляр класса Presentation
Presentation pres = new Presentation();
try {
    // Устанавливает цвет фона для Мастера слайда на Лесной Зеленый
    pres.getMasters().get_Item(0).getBackground().setType(BackgroundType.OwnBackground);
    pres.getMasters().get_Item(0).getBackground().getFillFormat().setFillType(FillType.Solid);
    pres.getMasters().get_Item(0).getBackground().getFillFormat().getSolidFillColor().setColor(Color.GREEN);
    
    // Записывает презентацию на диск
    pres.save("MasterBG.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Установка Градиентного Цвета в качестве Фона для Слайда**

Градиент — это графический эффект, основанный на плавном изменении цвета. Градиентные цвета, используемые в качестве фонов для слайдов, делают презентации более художественными и профессиональными. Aspose.Slides позволяет устанавливать градиентный цвет в качестве фона для слайдов в презентациях.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Установите перечисление [BackgroundType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/backgroundtype/) для слайда на `OwnBackground`.
3. Установите перечисление [FillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) для фона мастер-слайда на `Gradient`.
4. Используйте свойство [GradientFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fillformat/#getGradientFormat--) класса [FillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fillformat/), чтобы задать желаемые настройки градиента.
5. Сохраните измененную презентацию.

Этот код на Java показывает, как установить градиентный цвет в качестве фона для слайда:

```java
// Создает экземпляр класса Presentation
Presentation pres = new Presentation("MasterBG.pptx");
try {
    // Применяет градиентный эффект к фону
    pres.getSlides().get_Item(0).getBackground().setType(BackgroundType.OwnBackground);
    pres.getSlides().get_Item(0).getBackground().getFillFormat().setFillType(FillType.Gradient);
    pres.getSlides().get_Item(0).getBackground().getFillFormat().getGradientFormat().setTileFlip(TileFlip.FlipBoth);
    
    // Записывает презентацию на диск
    pres.save("ContentBG_Grad.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Установка Изображения в качестве Фона для Слайда**

Кроме сплошных и градиентных цветов, Aspose.Slides также позволяет устанавливать изображения в качестве фона для слайдов в презентациях.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Установите перечисление [BackgroundType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/backgroundtype/) для слайда на `OwnBackground`.
3. Установите перечисление [FillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) для фона мастер-слайда на `Picture`.
4. Загрузите изображение, которое вы хотите использовать в качестве фона слайда.
5. Добавьте изображение в коллекцию изображений презентации.
6. Используйте свойство [PictureFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fillformat/#getPictureFillFormat--) класса [FillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fillformat/), чтобы установить изображение в качестве фона.
7. Сохраните измененную презентацию.

Этот код на Java показывает, как установить изображение в качестве фона для слайда:

```java
// Создает экземпляр класса Presentation
Presentation pres = new Presentation();
try {
    // Устанавливает условия для фонового изображения
    pres.getSlides().get_Item(0).getBackground().setType(BackgroundType.OwnBackground);
    pres.getSlides().get_Item(0).getBackground().getFillFormat().setFillType(FillType.Picture);
    pres.getSlides().get_Item(0).getBackground().getFillFormat().getPictureFillFormat()
            .setPictureFillMode(PictureFillMode.Stretch);
    
    // Загружает изображение
    IPPImage imgx;
    IImage image = Images.fromFile("Desert.jpg");
    try {
        imgx = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }
    // Добавляет изображение в коллекцию изображений презентации
    pres.getSlides().get_Item(0).getBackground().getFillFormat().getPictureFillFormat().getPicture().setImage(imgx);
    
    // Записывает презентацию на диск
    pres.save("ContentBG_Img.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

### **Изменение Прозрачности Фонового Изображения**

Вы можете настроить прозрачность фонового изображения слайда, чтобы сделать содержимое слайда более заметным. Этот код на Java показывает, как изменить прозрачность для фонового изображения слайда:

```java
int transparencyValue = 30; // например

// Получает коллекцию операций трансформации изображения
IImageTransformOperationCollection imageTransform = slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().getImageTransform();

// Находит эффект прозрачности с фиксированным процентом.
AlphaModulateFixed transparencyOperation = null;
for (IImageTransformOperation operation : imageTransform)
{
    if (operation instanceof AlphaModulateFixed)
    {
        transparencyOperation = (AlphaModulateFixed)operation;
        break;
    }
}

// Устанавливает новое значение прозрачности.
if (transparencyOperation == null)
{
    imageTransform.addAlphaModulateFixedEffect(100 - transparencyValue);
}
else
{
    transparencyOperation.setAmount(100 - transparencyValue);
}
```

## **Получение Значения Фона Слайда**

Aspose.Slides предоставляет интерфейс [IBackgroundEffectiveData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibackgroundeffectivedata/), который позволяет получать эффективные значения фонов слайдов. Этот интерфейс содержит информацию об эффективном [FillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibackgroundeffectivedata/#getFillFormat--) и эффективном [EffectFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibackgroundeffectivedata/#getEffectFormat--).

Используя свойство [Background](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseslide/#getBackground--) из класса [BaseSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseslide/), вы можете получить эффективное значение для фона слайда.

Этот код на Java показывает, как получить эффективное значение фона слайда:

```java
// Создает экземпляр класса Presentation
Presentation pres = new Presentation("SamplePresentation.pptx");
try {
    IBackgroundEffectiveData effBackground = pres.getSlides().get_Item(0).getBackground().getEffective();
    
    if (effBackground.getFillFormat().getFillType() == FillType.Solid)
        System.out.println("Цвет заливки: " + effBackground.getFillFormat().getSolidFillColor());
    else
        System.out.println("Тип заливки: " + effBackground.getFillFormat().getFillType());
} finally {
    if (pres != null) pres.dispose();
}
```