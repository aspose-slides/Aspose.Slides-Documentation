---
title: Преобразовать слайды PowerPoint в PNG на Android
linktitle: PowerPoint в PNG
type: docs
weight: 30
url: /ru/androidjava/convert-powerpoint-to-png/
keywords:
- конвертировать PowerPoint
- конвертировать презентацию
- конвертировать слайд
- конвертировать PPT
- конвертировать PPTX
- PowerPoint в PNG
- презентацию в PNG
- слайд в PNG
- PPT в PNG
- PPTX в PNG
- сохранить PPT как PNG
- сохранить PPTX как PNG
- экспортировать PPT в PNG
- экспортировать PPTX в PNG
- Android
- Java
- Aspose.Slides
description: "Быстро преобразуйте презентации PowerPoint в высококачественные PNG‑изображения с помощью Aspose.Slides для Android через Java, обеспечивая точные, автоматизированные результаты."
---
## **Обзор**

В этой статье объясняется, как преобразовать слайды презентации в изображения PNG с помощью Aspose.Slides для Android через Java. Вы можете загружать презентации в форматах, таких как PPT, PPTX и ODP, рендерить каждый слайд и сохранять его как отдельное изображение PNG.

Приведённые ниже примеры демонстрируют рендеринг с масштабом по умолчанию, увеличение масштаба, указание размеров вывода в пикселях и выбор стиля рендеринга градиента.

## **Конвертировать PowerPoint в PNG**

Загрузите презентацию с помощью класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) и получите доступ к её слайдам через коллекцию [Presentation.getSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getSlides--). Пример рендерит каждый слайд с помощью [ISlide.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#getImage--) без параметров для создания миниатюры. Затем вызывается [IImage.save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) с [ImageFormat.Png](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imageformat/#Png) для сохранения каждого отрендеренного слайда в виде изображения PNG.

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
Параметрический перегрузка [ISlide.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#getImage--) рендерит с масштабом 0.2. Например, слайд размером 720 × 540 пунктов создаёт миниатюру 144 × 108 пикселей. Чтобы управлять размерами вывода, используйте перегрузки с коэффициентами масштаба или явно указанным размером изображения, показанными ниже.
{{% /alert %}}

## **Конвертировать PowerPoint в PNG с пользовательскими размерами**

Передайте горизонтальные и вертикальные коэффициенты масштаба в [ISlide.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#getImage-float-float-) для управления размерами рендеринга. В этом примере оба коэффициента равны 2, поэтому слайд размером 720 × 540 пунктов создаёт изображение 1440 × 1080 пикселей. Одинаковые коэффициенты сохраняют соотношение сторон слайда. Каждое изображение сохраняется в формате PNG с помощью [IImage.save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-).

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

## **Конвертировать PowerPoint в PNG с пользовательским размером**

Чтобы указать размеры вывода в пикселях, передайте размер в [ISlide.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#getImage-com.aspose.slides.android.Size-) вместо коэффициентов масштаба. Этот пример рендерит каждый слайд с разрешением 960 × 720 пикселей и сохраняет результат с помощью [IImage.save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-). Выбирайте размеры, соответствующие соотношению сторон слайда, чтобы избежать растягивания изображения.

```java
import com.aspose.slides.*;
import com.aspose.slides.android.Size;

Presentation presentation = new Presentation("presentation.pptx");
try {
    Size imageSize = new Size(960, 720);

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

Предположим, что слайд содержит градиентные заливки, но переходы в экспортированном PNG выглядят светлее или иначе, чем в PowerPoint. Вы можете использовать метод [SaveOptions.setGradientStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveoptions/#setGradientStyle-int-), унаследованный от [RenderingOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/renderingoptions/), чтобы выбрать способ рендеринга градиентов.

Скачайте [gradient-styles.pptx](gradient-styles.pptx) и разместите его в рабочем каталоге приложения. Его первый слайд содержит два линейных градиента: от голубого к оранжевому вверху и от синего к жёлтому внизу. Каждый градиент имеет две точки остановки — на 0% и 100%.

Следующий пример загружает эту презентацию и рендерит первый слайд в обоих режимах с помощью [ISlide.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#getImage-com.aspose.slides.IRenderingOptions-float-float-).

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

Изображения ниже показывают вывод того же слайда, с обоими градиентами на каждом изображении:

| Default | PowerPointUI |
| --- | --- |
| ![Градиенты от голубого к оранжевому и от синего к желтому, отрендеренные в режиме Default](gradient-Default.png) | ![Те же градиенты, отрендеренные в режиме PowerPointUI](gradient-PowerPointUI.png) |

В этом примере `Default` создает более светлые промежуточные цвета, тогда как `PowerPointUI` — более темные промежуточные цвета. Разница зависит от цветов и точек остановки в градиенте.

Выбирайте `Default`, когда стандартный вывод Aspose.Slides устраивает вас. Попробуйте `PowerPointUI`, если приоритетом является соответствие внешнему виду в PowerPoint. Сравните оба результата с желаемым результатом; ни один режим не является универсально предпочтительным.

## **Часто задаваемые вопросы**

**Как экспортировать конкретную форму, например диаграмму или изображение, вместо всего слайда?**

Aspose.Slides поддерживает [создание миниатюр отдельных фигур](/slides/ru/androidjava/create-shape-thumbnails/), позволяя рендерить фигуру в виде изображения PNG.

**Поддерживается ли параллельное преобразование на сервере?**

Да. Используйте отдельный экземпляр презентации для каждого потока или процесса; [не делитесь одним экземпляром между потоками](/slides/ru/androidjava/multithreading/).

**Каковы ограничения оценочной версии при экспорте в PNG?**

Режим оценки добавляет водяной знак к выводимым изображениям и применяет [другие ограничения](/slides/ru/androidjava/licensing/), пока лицензия не будет применена.