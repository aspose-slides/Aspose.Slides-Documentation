---
title: Фон Презентации
type: docs
weight: 20
url: /java/presentation-background/
keywords: "фон PowerPoint, установить фон в Java"
description: "Установите фон в презентации PowerPoint на Java"
---

Сплошные цвета, градиенты и изображения часто используются в качестве фоновых изображений для слайдов. Вы можете установить фон как для **нормального слайда** (один слайд), так и для **мастер-слайда** (несколько слайдов сразу).

<img src="powerpoint-background.png" alt="powerpoint-background"  />

## **Установить сплошной цвет в качестве фона для нормального слайда**

Aspose.Slides позволяет установить сплошной цвет в качестве фона для конкретного слайда в презентации (даже если эта презентация содержит мастер-слайд). Изменение фона затрагивает только выбранный слайд.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Установите перечисление [BackgroundType](https://reference.aspose.com/slides/java/com.aspose.slides/backgroundtype/) для слайда на `OwnBackground`.
3. Установите перечисление [FillType](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) для фона слайда на `Solid`.
4. Используйте свойство [SolidFillColor](https://reference.aspose.com/slides/java/com.aspose.slides/fillformat/#getSolidFillColor--) класса [FillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/fillformat/), чтобы указать сплошной цвет для фона.
5. Сохраните измененную презентацию.

Этот код на Java показывает, как установить сплошной цвет (синий) в качестве фона для нормального слайда:

```java
// Создает экземпляр класса Presentation
Presentation pres = new Presentation("MasterBG.pptx");
try {
    // Устанавливает цвет фона для первого ISlide на синий
    pres.getSlides().get_Item(0).getBackground().setType(BackgroundType.OwnBackground);
    pres.getSlides().get_Item(0).getBackground().getFillFormat().setFillType(FillType.Solid);
    pres.getSlides().get_Item(0).getBackground().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    
    // Записывает презентацию на диск
    pres.save("ContentBG.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Установить сплошной цвет в качестве фона для мастер-слайда**

Aspose.Slides позволяет установить сплошной цвет в качестве фона для мастер-слайда в презентации. Мастер-слайд служит шаблоном, который содержит и контролирует настройки форматирования для всех слайдов. Поэтому, когда вы выбираете сплошной цвет в качестве фона для мастер-слайда, этот новый фон будет использоваться для всех слайдов.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Установите перечисление [BackgroundType](https://reference.aspose.com/slides/java/com.aspose.slides/backgroundtype/) для мастер-слайда (`Masters`) на `OwnBackground`.
3. Установите перечисление [FillType](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) для фона мастер-слайда на `Solid`.
4. Используйте свойство [SolidFillColor](https://reference.aspose.com/slides/java/com.aspose.slides/fillformat/#getSolidFillColor--) класса [FillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/fillformat/), чтобы указать сплошной цвет для фона.
5. Сохраните измененную презентацию.

Этот код на Java показывает, как установить сплошной цвет (лесной зеленый) в качестве фона для мастер-слайда в презентации:

```java
// Создает экземпляр класса Presentation
Presentation pres = new Presentation();
try {
    // Устанавливает цвет фона для мастер ISlide на лесной зеленый
    pres.getMasters().get_Item(0).getBackground().setType(BackgroundType.OwnBackground);
    pres.getMasters().get_Item(0).getBackground().getFillFormat().setFillType(FillType.Solid);
    pres.getMasters().get_Item(0).getBackground().getFillFormat().getSolidFillColor().setColor(Color.GREEN);
    
    // Записывает презентацию на диск
    pres.save("MasterBG.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Установить градиентный цвет в качестве фона для слайда**

Градиент - это графический эффект, основанный на постепенном изменении цвета. Градиентные цвета, используемые в качестве фонов для слайдов, придают презентациям художественный и профессиональный вид. Aspose.Slides позволяет установить градиентный цвет в качестве фона для слайдов в презентациях.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Установите перечисление [BackgroundType](https://reference.aspose.com/slides/java/com.aspose.slides/backgroundtype/) для слайда на `OwnBackground`.
3. Установите перечисление [FillType](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) для фона мастер-слайда на `Gradient`.
4. Используйте свойство [GradientFormat](https://reference.aspose.com/slides/java/com.aspose.slides/fillformat/#getGradientFormat--) класса [FillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/fillformat/), чтобы указать желаемые настройки градиента.
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

## **Установить изображение в качестве фона для слайда**

Помимо сплошных цветов и градиентов, Aspose.Slides также позволяет установить изображения в качестве фона для слайдов в презентациях.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Установите перечисление [BackgroundType](https://reference.aspose.com/slides/java/com.aspose.slides/backgroundtype/) для слайда на `OwnBackground`.
3. Установите перечисление [FillType](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) для фона мастер-слайда на `Picture`.
4. Загрузите изображение, которое вы хотите использовать в качестве фона слайда.
5. Добавьте изображение в коллекцию изображений презентации.
6. Используйте свойство [PictureFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/fillformat/#getPictureFillFormat--) класса [FillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/fillformat/), чтобы установить изображение в качестве фона.
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

### **Изменить прозрачность фонового изображения**

Вы можете захотеть отрегулировать прозрачность фонового изображения слайда, чтобы сделать содержимое слайда более заметным. Этот код на Java показывает, как изменить прозрачность для фонового изображения слайда:

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

## **Получить значение фона слайда**

Aspose.Slides предоставляет интерфейс [IBackgroundEffectiveData](https://reference.aspose.com/slides/java/com.aspose.slides/ibackgroundeffectivedata/), который позволяет получать эффективные значения фонов слайдов. Этот интерфейс содержит информацию об эффективном [FillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ibackgroundeffectivedata/#getFillFormat--) и эффективном [EffectFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ibackgroundeffectivedata/#getEffectFormat--).

Используя свойство [Background](https://reference.aspose.com/slides/java/com.aspose.slides/baseslide/#getBackground--) из класса [BaseSlide](https://reference.aspose.com/slides/java/com.aspose.slides/baseslide/), вы можете получить эффективное значение для фона слайда.

Этот код на Java показывает, как получить эффективное значение фона слайда:

```java
// Создает экземпляр класса Presentation
Presentation pres = new Presentation("SamplePresentation.pptx");
try {
    IBackgroundEffectiveData effBackground = pres.getSlides().get_Item(0).getBackground().getEffective();
    
    if (effBackground.getFillFormat().getFillType() == FillType.Solid)
        System.out.println("Заполнить цвет: " + effBackground.getFillFormat().getSolidFillColor());
    else
        System.out.println("Тип заполнения: " + effBackground.getFillFormat().getFillType());
} finally {
    if (pres != null) pres.dispose();
}
```