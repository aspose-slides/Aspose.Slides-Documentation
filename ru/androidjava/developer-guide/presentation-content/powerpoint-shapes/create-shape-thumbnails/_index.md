---
title: Создание миниатюр фигур презентации на Android
linktitle: Миниатюры фигур
type: docs
weight: 70
url: /ru/androidjava/create-shape-thumbnails/
keywords:
- миниатюра фигуры
- изображение фигуры
- отрисовка фигуры
- визуализация фигуры
- визуальные границы
- границы фигуры
- PowerPoint
- презентация
- Android
- Java
- Aspose.Slides
description: "Создавайте миниатюры фигур высокого качества из слайдов PowerPoint с помощью Aspose.Slides для Android через Java – легко создавайте и экспортируйте миниатюры презентаций."
---
## **Введение**

Aspose.Slides for Android via Java может использоваться для создания файлов презентаций, где каждая страница соответствует слайду. Слайды можно просматривать, открывая файлы презентаций в Microsoft PowerPoint. Однако разработчикам иногда требуется просмотреть изображения фигур отдельно в просмотрщике изображений. В таких случаях Aspose.Slides for Android via Java помогает им генерировать миниатюры фигур слайдов.

В этом материале мы покажем, как генерировать миниатюры слайдов в разных ситуациях:

- Генерация миниатюры фигуры внутри слайда.
- Генерация миниатюры фигуры с пользовательскими размерами.
- Генерация миниатюры фигуры в границах её отображения.

## **Генерация миниатюры фигуры из слайда**
Чтобы сгенерировать миниатюру фигуры из любого слайда с помощью Aspose.Slides for Android via Java, выполните следующее:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation).
1. Получите ссылку на любой слайд по его идентификатору или индексу.
1. [Получите изображение миниатюры фигуры](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/IShape#getImage--) выбранного слайда с масштабом по умолчанию.
1. Сохраните изображение миниатюры в нужном вам формате.

Следующий пример кода показывает, как сгенерировать миниатюру фигуры из слайда:

```java
// Создайте экземпляр класса Presentation, который представляет файл презентации
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // Создайте изображение в полном масштабе
    IImage slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage();
    
    // Сохраните изображение на диск в формате PNG
    try {
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Генерация миниатюры с пользовательским коэффициентом масштабирования**
Чтобы сгенерировать миниатюру фигуры слайда с помощью Aspose.Slides for Android via Java, выполните следующее:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation).
1. Получите ссылку на любой слайд по его идентификатору или индексу.
1. [Получите изображение миниатюры фигуры](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/IShape#getImage-int-float-float-) выбранного слайда с пользовательскими размерами.
1. Сохраните изображение миниатюры в нужном вам формате.

Следующий пример кода показывает, как сгенерировать миниатюру фигуры на основе заданного коэффициента масштабирования:

```java
// Создайте экземпляр класса Presentation, который представляет файл презентации
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // Создайте изображение в полном масштабе
    IImage slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(ShapeThumbnailBounds.Shape, 1, 1);

    // Сохраните изображение на диск в формате PNG
    try {
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Создание миниатюры фигуры на основе границ отображения**
Этот метод создания миниатюр фигур позволяет разработчикам генерировать миниатюру в границах отображения фигуры. Он учитывает все эффекты фигуры. Сгенерированная миниатюра ограничивается границами слайда. Чтобы сгенерировать миниатюру фигуры слайда в пределах её отображения, выполните следующее:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation).
1. Получите ссылку на любой слайд по его идентификатору или индексу.
1. Получите изображение миниатюры выбранного слайда с границами фигуры в качестве отображения.
1. Сохраните изображение миниатюры в нужном вам формате.

Следующий пример кода основан на приведённых шагах:

```java
// Создайте экземпляр класса Presentation, который представляет файл презентации
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // Создайте изображение в полном масштабе
    IImage slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(ShapeThumbnailBounds.Appearance, 1, 1);

    // Сохраните изображение на диск в формате PNG
    try {
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Получение фактических визуальных границ фигуры**

Свойства кадра интерфейса [IShape](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ishape/) — его методы `getX()`, `getY()`, `getWidth()` и `getHeight()` — описывают прямоугольник, хранящийся в модели презентации. Содержимое, которое фактически отрисовывается, может выходить за пределы этого кадра или занимать другой ориентированный прямоугольник. Поворот, контуры, концы стрел, компоновка текста и переполнение, генерируемая геометрия SmartArt и другие эффекты отрисовки могут изменять занимаемую область.

Используйте [Shape.getVisualBounds](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/shape/#getVisualBounds--) для расчёта этой области без создания изображения. Метод возвращает объект [RectF](https://developer.android.com/reference/android/graphics/RectF) в координатах слайда. Возвращаемый прямоугольник не обрезается по границам слайда, поэтому его координаты могут быть отрицательными, если содержимое выходит за начало слайда.

В текущей версии метод [Shape.getVisualBounds](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/shape/#getVisualBounds--) не объявлен в интерфейсе [IShape](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ishape/). Поэтому сохраняйте полученную из коллекции фигур слайда фигуру как значение интерфейса и приводите тип только при вызове метода.

Следующий пример получает и сравнивает границы кадра и визуальные границы:

```java
Presentation presentation = new Presentation("example.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    RectF visualBounds = ((Shape) shape).getVisualBounds();

    float frameLeft = shape.getX();
    float frameTop = shape.getY();
    float frameRight = frameLeft + shape.getWidth();
    float frameBottom = frameTop + shape.getHeight();
    RectF frameBounds = new RectF(frameLeft, frameTop, frameRight, frameBottom);

    System.out.println("Frame bounds: " + frameBounds);
    System.out.println("Visual bounds: " + visualBounds);
} finally {
    presentation.dispose();
}
```

Тот же объект [RectF](https://developer.android.com/reference/android/graphics/RectF) можно использовать для выравнивания соседних фигур по левому, правому, верхнему или нижнему краю; для резервирования достаточного пространства в генерируемой компоновке; или для обнаружения содержимого за пределами разрешённой области. Визуальные границы особенно полезны для SmartArt, текстовых блоков, стрел, изображений, повернутых фигур и групповых фигур, когда сохранённый кадр может не отражать полностью отрисованный результат.

Используйте [Shape.getVisualBounds](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/shape/#getVisualBounds--) когда нужны координаты для компоновки или проверки и не требуется битмап. Используйте [IShape.getImage](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ishape/#getImage--) когда необходимо отрисовать фигуру. С помощью [ShapeThumbnailBounds](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/shapethumbnailbounds/) параметр `ShapeThumbnailBounds.Shape` задаёт размер изображения исходя из границ фигуры, включая параметры контура, тогда как `ShapeThumbnailBounds.Appearance` задаёт размер согласно отображению фигуры и ограничивает результат границами слайда. Напротив, [Shape.getVisualBounds](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/shape/#getVisualBounds--) возвращает только вычисленный прямоугольник и не обрезает его по границам слайда.

## **FAQ**

**Какие форматы изображений можно использовать при сохранении миниатюр фигур?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/imageformat/), а также другие. Фигуры также могут быть [экспортированы как векторный SVG](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) путём сохранения их содержимого в SVG.

**В чём разница между границами Shape и Appearance при рендеринге миниатюры?**

`Shape` использует геометрию фигуры; `Appearance` учитывает [визуальные эффекты](/slides/ru/androidjava/shape-effect/) (тени, свечения и т.д.).

**Что происходит, если фигура помечена как скрытая? Будет ли она всё равно отрисована как миниатюра?**

Скрытая фигура остаётся частью модели и может быть отрисована; флаг скрытия влияет только на отображение в режиме слайдшоу, но не препятствует генерации изображения фигуры.

**Поддерживаются ли групповые фигуры, диаграммы, SmartArt и другие сложные объекты?**

Да. Любой объект, представленный как [Shape](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/shape/) (включая [GroupShape](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/chart/) и [SmartArt](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/smartart/)), может быть сохранён как миниатюра или как SVG.

**Влияют ли системные шрифты на качество миниатюр текстовых фигур?**

Да. Необходимо [предоставить требуемые шрифты](/slides/ru/androidjava/custom-font/) (или [настроить замену шрифтов](/slides/ru/androidjava/font-substitution/)), чтобы избежать нежелательных замен и переполнения текста.