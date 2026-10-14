---
title: Преобразовать слайды PowerPoint в PNG на Java
linktitle: PowerPoint в PNG
type: docs
weight: 30
url: /ru/java/convert-powerpoint-to-png/
keywords:
- конвертировать PowerPoint
- конвертировать презентацию
- конвертировать слайд
- конвертировать PPT
- конвертировать PPTX
- PowerPoint в PNG
- презентация в PNG
- слайд в PNG
- PPT в PNG
- PPTX в PNG
- сохранить PPT как PNG
- сохранить PPTX как PNG
- экспортировать PPT в PNG
- экспортировать PPTX в PNG
- Java
- Aspose.Slides
description: "Конвертировать презентации PowerPoint в высококачественные PNG‑изображения быстро с помощью Aspose.Slides for Java, обеспечивая точные, автоматические результаты."
---
## **Обзор**

В этой статье объясняется, как преобразовать слайды презентаций в PNG‑изображения с помощью Aspose.Slides for Java. Вы можете загружать презентации в форматах PPT, PPTX и ODP, рендерить каждый слайд и сохранять его как отдельное PNG‑изображение.

Приведённые ниже примеры демонстрируют рендеринг с масштабом по умолчанию, увеличение масштаба, указание выходных размеров в пикселях и выбор стиля рендеринга градиента.

## **Преобразовать PowerPoint в PNG**

Загрузите презентацию с помощью класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) и получите доступ к её слайдам через коллекцию [Presentation.getSlides](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getSlides--) . Пример рендерит каждый слайд с помощью [ISlide.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#getImage--) без параметров, создавая миниатюру. Затем вызывается [IImage.save](https://reference.aspose.com/slides/java/com.aspose.slides/iimage/#save-java.lang.String-int-) с [ImageFormat.Png](https://reference.aspose.com/slides/java/com.aspose.slides/imageformat/#Png) для сохранения каждого отрисованного слайда в виде PNG‑изображения.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    int slideCount = presentation.getSlides().size();
    for (int index = 0; index < slideCount; index++) {
        ISlide slide = presentation.getSlides().get_Item(index);
        IImage image = slide.getImage();
        try {
            image.save("slide_" + index + ".png", ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Перегрузка [ISlide.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#getImage--) без параметров рендерит с масштабом 0.2. Например, слайд размером 720 × 540 пунктов создаёт миниатюру 144 × 108 пикселей. Чтобы управлять выходными размерами, используйте перегрузки с коэффициентами масштабирования или явным размером изображения, показанным ниже.
{{% /alert %}}

## **Преобразовать PowerPoint в PNG с пользовательскими размерами**

Передайте горизонтальные и вертикальные коэффициенты масштабирования в [ISlide.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#getImage-float-float-), чтобы управлять размерами отрисовки. В этом примере оба коэффициента равны 2, поэтому слайд размером 720 × 540 пунктов создаёт изображение 1440 × 1080 пикселей. Равные коэффициенты сохраняют пропорции слайда. Каждое изображение сохраняется в формате PNG с помощью [IImage.save](https://reference.aspose.com/slides/java/com.aspose.slides/iimage/#save-java.lang.String-int-).

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    float scaleX = 2f;
    float scaleY = scaleX;

    int slideCount = presentation.getSlides().size();
    for (int index = 0; index < slideCount; index++) {
        ISlide slide = presentation.getSlides().get_Item(index);
        IImage image = slide.getImage(scaleX, scaleY);
        try {
            image.save("slide_" + index + ".png", ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **Преобразовать PowerPoint в PNG с пользовательским размером**

Чтобы указать выходные размеры в пикселях, передайте объект размера в [ISlide.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#getImage-java.awt.Dimension-) вместо коэффициентов масштабирования. Этот пример отрисовывает каждый слайд в размере 960 × 720 пикселей и сохраняет результат с помощью [IImage.save](https://reference.aspose.com/slides/java/com.aspose.slides/iimage/#save-java.lang.String-int-). Выбирайте размеры, соответствующие пропорциям слайда, чтобы избежать растягивания изображения.

```java
import com.aspose.slides.*;
import java.awt.Dimension;

Presentation presentation = new Presentation("presentation.pptx");
try {
    Dimension imageSize = new Dimension(960, 720);

    int slideCount = presentation.getSlides().size();
    for (int index = 0; index < slideCount; index++) {
        ISlide slide = presentation.getSlides().get_Item(index);
        IImage image = slide.getImage(imageSize);
        try {
            image.save("slide_" + index + ".png", ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **Выбрать стиль рендеринга градиента**

Предположим, что слайд содержит градиентные заливки, но переходы в экспортированном PNG выглядят светлее или иначе, чем в PowerPoint. Вы можете использовать метод [SaveOptions.setGradientStyle](https://reference.aspose.com/slides/java/com.aspose.slides/saveoptions/#setGradientStyle-int-), унаследованный от [RenderingOptions](https://reference.aspose.com/slides/java/com.aspose.slides/renderingoptions/), чтобы выбрать способ рендеринга градиентов.

Скачайте [gradient-styles.pptx](gradient-styles.pptx) и поместите его в рабочий каталог приложения. Первый слайд содержит два линейных градиента: от цианового к оранжевому вверху и от синего к жёлтому внизу. Каждый градиент имеет две стоп‑точки: 0 % и 100 %.

Следующий пример загружает эту презентацию и рендерит первый слайд в обоих режимах с помощью [ISlide.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#getImage-com.aspose.slides.IRenderingOptions-float-float-).

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("gradient-styles.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int[] gradientStyles = { GradientStyle.Default, GradientStyle.PowerPointUI };
    for (int style : gradientStyles) {
        RenderingOptions options = new RenderingOptions();
        options.setGradientStyle(style);

        String styleName = style == GradientStyle.Default ? "Default" : "PowerPointUI";
        IImage image = slide.getImage(options, 1f, 1f);
        try {
            image.save("gradient-" + styleName + ".png", ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

Ниже изображения показывают вывод одного и того же слайда, с обоими градиентами на каждом изображении:

| Default | PowerPointUI |
| --- | --- |
| ![Градиенты от цианового к оранжевому и от синего к жёлтому, отрендеренные с Default](gradient-Default.png) | ![Те же градиенты, отрендеренные с PowerPointUI](gradient-PowerPointUI.png) |

В этом примере `Default` создаёт более светлые промежуточные цвета, тогда как `PowerPointUI` — более тёмные. Разница зависит от цветов и точек остановки в градиенте.

Выберите `Default`, если стандартный вывод Aspose.Slides подходит вам. Попробуйте `PowerPointUI`, если ваша цель — соответствие внешнему виду в PowerPoint. Сравните оба вывода с ожидаемым результатом; ни один режим не является универсально лучшим.

## **FAQ**

**Как экспортировать конкретную форму, например диаграмму или изображение, вместо всего слайда?**  
Aspose.Slides поддерживает [создание миниатюр для отдельных фигур](/slides/ru/java/create-shape-thumbnails/), позволяя отрисовать форму как PNG‑изображение.

**Поддерживается ли параллельное преобразование на сервере?**  
Да. Используйте отдельный экземпляр презентации для каждого потока или процесса; [не делите один экземпляр между потоками](/slides/ru/java/multithreading/).

**Каковы ограничения оценочной версии при экспорте в PNG?**  
Режим оценки добавляет водяной знак к экспортируемым изображениям и применяет [другие ограничения](/slides/ru/java/licensing/), пока лицензия не будет применена.