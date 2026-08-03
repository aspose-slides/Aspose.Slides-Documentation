---
title: Создание миниатюр фигур презентаций в Java
linktitle: Миниатюры фигур
type: docs
weight: 70
url: /ru/java/create-shape-thumbnails/
keywords:
- миниатюра фигуры
- изображение фигуры
- рендеринг фигуры
- визуализация фигуры
- визуальные границы
- границы фигуры
- PowerPoint
- презентация
- Java
- Aspose.Slides
description: "Создавайте высококачественные миниатюры фигур из слайдов PowerPoint с помощью Aspose.Slides for Java — легко создавайте и экспортируйте миниатюры презентаций."
---
## **Введение**

Aspose.Slides for Java можно использовать для создания файлов презентаций, в которых каждая страница соответствует слайду. Слайды можно просматривать, открывая файлы презентаций в Microsoft PowerPoint. Однако разработчикам иногда требуется просматривать изображения фигур отдельно в просмоторщике изображений. В таких случаях Aspose.Slides for Java помогает генерировать миниатюры фигур слайдов.

В этой статье описано, как создавать миниатюры слайдов различными способами:

- Создание миниатюры фигуры внутри слайда.  
- Создание миниатюры фигуры для формы слайда с пользовательскими размерами.  
- Создание миниатюры фигуры в границах внешнего вида фигуры.

## **Создать миниатюру фигуры из слайда**
Чтобы создать миниатюру фигуры из любого слайда с помощью Aspose.Slides for Java, выполните следующее:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/).  
2. Получите ссылку на любой слайд, используя его ID или индекс.  
3. [Получить изображение миниатюры фигуры](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ishape/#getImage--) указанного слайда в масштабе по умолчанию.  
4. Сохраните изображение миниатюры в предпочтимом формате изображения.

Этот пример кода показывает, как создать миниатюру фигуры из слайда:

```java
// Создайте экземпляр класса Presentation, который представляет файл презентации
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // Создать изображение в полном масштабе
    IImage slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage();
    
    // Сохранить изображение на диск в формате PNG
    try {
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Создать миниатюру с пользовательским коэффициентом масштабирования**
Чтобы создать миниатюру фигуры слайда с пользовательским коэффициентом масштабирования в Aspose.Slides for Java, выполните следующее:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/).  
2. Получите ссылку на любой слайд, используя его ID или индекс.  
3. [Получить изображение миниатюры фигуры с пользовательскими размерами](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ishape/#getImage-int-float-float-) указанного слайда.  
4. Сохраните изображение миниатюры в предпочтимом формате изображения.

Этот пример кода показывает, как создать миниатюру фигуры на основе заданного коэффициента масштабирования:

```java
// Создайте экземпляр класса Presentation, который представляет файл презентации
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // Создать изображение в полном масштабе
    IImage slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(ShapeThumbnailBounds.Shape, 1, 1);

    // Сохранить изображение на диск в формате PNG
    try {
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Создать миниатюру внешнего вида фигуры на основе границ**
Этот метод создания миниатюр фигур позволяет разработчикам генерировать миниатюру в границах внешнего вида фигуры. Он учитывает все эффекты фигуры. Сгенерированная миниатюра ограничена границами слайда. Чтобы создать миниатюру фигуры слайда в границах её внешнего вида, выполните следующее:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/).  
2. Получите ссылку на любой слайд, используя его ID или индекс.  
3. Получите изображение миниатюры указанного слайда с границами фигуры как внешнее отображение.  
4. Сохраните изображение миниатюры в предпочтимом формате изображения.

Этот пример кода основан на приведённых выше шагах:

```java
// Создайте экземпляр класса Presentation, который представляет файл презентации
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // Создать изображение в полном масштабе
    IImage slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(ShapeThumbnailBounds.Appearance, 1, 1);

    // Сохранить изображение на диск в формате PNG
    try {
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Получить реальные визуальные границы фигуры**

Свойства кадра интерфейса [IShape](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ishape/) — его методы `getX()`, `getY()`, `getWidth()` и `getHeight()` — описивают прямоугольник, хранящийся в модели презентации. Фактическое отрисовываемое содержимое может выходить за пределы этого кадра или занимать иной прямоугольник, выровненный по осям. Повороты, обводки, концы стрел, компоновка и переполнение текста, генерируемая геометрия SmartArt и другие эффекты отрисовки могут изменять занимаемую площадь.

Используйте [Shape.getVisualBounds](https://reference.aspose.com/slides/ru/java/com.aspose.slides/shape/#getVisualBounds--) для расчёта этой площади без создания изображения. Метод возвращает объект [Rectangle2D.Float](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/Rectangle2D.Float.html) в координатах слайда. Возвращаемый прямоугольник не обрезается до границ слайда, поэтому его координаты могут быть отрицательными, если содержимое выходит за пределы начала слайда.

[Shape.getVisualBounds](https://reference.aspose.com/slides/ru/java/com.aspose.slides/shape/#getVisualBounds--) в текущей версии не объявлен в интерфейсе [IShape](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ishape/). Поэтому храните полученную из коллекции фигур слайда фигуру как значение интерфейса и приводите её к типу только при вызове метода.

Ниже приведён пример, получающий и сравнивающий кадр и визуальные границы:

```java
Presentation presentation = new Presentation("example.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    Rectangle2D.Float visualBounds = ((Shape) shape).getVisualBounds();

    Rectangle2D.Float frameBounds = new Rectangle2D.Float(
        shape.getX(), shape.getY(), shape.getWidth(), shape.getHeight());

    System.out.println("Frame bounds: " + frameBounds);
    System.out.println("Visual bounds: " + visualBounds);
} finally {
    presentation.dispose();
}
```

Тот же объект [Rectangle2D.Float](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/Rectangle2D.Float.html) можно использовать для выравнивания соседних фигур по её левой, правой, верхней или нижней стороне; для резервирования достаточного пространства в генерируемой компоновке; либо для обнаружения содержимого за пределами разрешённой области. Визуальные границы особенно полезны для SmartArt, текстовых полей, стрел, изображений, повёрнутых фигур и групповых фигур, где сохранённый кадр может не отражать полного результата отрисовки.

Используйте [Shape.getVisualBounds](https://reference.aspose.com/slides/ru/java/com.aspose.slides/shape/#getVisualBounds--), когда нужны координаты для компоновки или проверки и нет необходимости в bitmap‑изображении. Используйте [IShape.getImage](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ishape/#getImage--) когда требуется отрисовать фигуру. С помощью [ShapeThumbnailBounds](https://reference.aspose.com/slides/ru/java/com.aspose.slides/shapethumbnailbounds/) параметр `ShapeThumbnailBounds.Shape` задаёт размер изображения из границ фигуры, включая настройки обводки, тогда как `ShapeThumbnailBounds.Appearance` задаёт размер из внешнего вида фигуры и ограничивает результат границами слайда. В отличие от этого, [Shape.getVisualBounds](https://reference.aspose.com/slides/ru/java/com.aspose.slides/shape/#getVisualBounds--) возвращает только вычисленный прямоугольник и не обрезает его до границ слайда.

## **FAQ**

**Какие форматы изображений можно использовать при сохранении миниатюр фигур?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/ru/java/com.aspose.slides/imageformat/), а также другие. Фигуры также могут быть [экспортированы как векторный SVG](https://reference.aspose.com/slides/ru/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) путём сохранения содержимого фигуры в виде SVG.

**В чем разница между границами Shape и Appearance при рендеринге миниатюры?**

`Shape` использует геометрию фигуры; `Appearance` учитывает [визуальные эффекты](/slides/ru/java/shape-effect/) (тени, свечения и т.д.).

**Что происходит, если фигура помечена как скрытая? Будет ли она всё равно отрисована как миниатюра?**

Скрытая фигура остаётся частью модели и может быть отрисована; флаг скрытия влияет лишь на отображение в режиме слайд‑шоу и не препятствует генерации изображения фигуры.

**Поддерживаются ли групповые фигуры, диаграммы, SmartArt и другие сложные объекты?**

Да. Любой объект, представляемый как [Shape](https://reference.aspose.com/slides/ru/java/com.aspose.slides/shape/) (включая [GroupShape](https://reference.aspose.com/slides/ru/java/com.aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/ru/java/com.aspose.slides/chart/) и [SmartArt](https://reference.aspose.com/slides/ru/java/com.aspose.slides/smartart/)), может быть сохранён в виде миниатюры или SVG.

**Влияют ли системно установленные шрифты на качество миниатюр текстовых фигур?**

Да. Необходимо [предоставить требуемые шрифты](/slides/ru/java/custom-font/) (или [настроить подстановку шрифтов](/slides/ru/java/font-substitution/)), чтобы избежать нежелательных замен и искажений текста.