---
title: Управление объектами чернил в презентации на Java
linktitle: Управление чернилами
type: docs
weight: 95
url: /ru/java/manage-ink/
keywords:
  - чернила
  - объект чернил
  - трасса чернил
  - управление чернилами
  - рисование чернил
  - рисование
  - экспорт чернил
  - визуализация чернил
  - скрыть чернила
  - IInkOptions
  - PowerPoint
  - презентация
  - Java
  - Aspose.Slides
description: "Управляйте объектами чернил PowerPoint, редактируйте трассы и свойства кисти, а также контролируйте отображение чернил при экспорте в PDF, HTML, SVG, TIFF и изображения с помощью Aspose.Slides для Java."
---
## **Введение**

PowerPoint предоставляет функцию чернил, позволяющую рисовать свободные штрихи. Чернила можно использовать для выделения других объектов, отображения связей и процессов, а также привлечения внимания к определённым элементам на слайде.

Aspose.Slides предоставляет типы, необходимые для работы с объектами чернил. Например, интерфейс [IInk](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iink/) представляет объект чернил на слайде.

## **Различия между обычными объектами и объектами чернил**

Объекты на слайде PowerPoint обычно представлены объектами фигур. В самой простой форме фигура — это контейнер, определяющий область самого объекта (его рамку) вместе с такими свойствами, как размер контейнера, форма и фон. Для получения дополнительной информации см. [Shape Layout Format](https://docs.aspose.com/slides/ru/java/shape-manipulations/#access-layout-formats-for-shape).

Однако когда PowerPoint обрабатывает объект чернил, он игнорирует все свойства рамки объекта (контейнера), кроме его размера. Размер области контейнера определяется стандартными методами [IShape.getWidth](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ishape/#getWidth--) и [IShape.getHeight](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ishape/#getHeight--) :

![ink_powerpoint1](ink_powerpoint1.png)

## **Трассы чернил**

Трасса чернил — это базовый элемент, используемый для записи траектории пера, когда пользователь пишет цифровые чернила. Трасса хранит последовательность соединённых точек.

Самая простая форма кодирования указывает координаты X и Y каждой точки выборки. Когда все соединённые точки отрисовываются, они образуют изображение, похожее на это:

![ink_powerpoint2](ink_powerpoint2.png)

## **Свойства кисти для рисования**

Кисть используется для рисования линий, соединяющих точки трассы чернил. Кисть имеет собственный цвет и размер, представленные методами [IInkBrush.getColor](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iinkbrush/#getColor--) и [IInkBrush.getSize](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iinkbrush/#getSize--) .

### **Установка цвета кисти чернил**

Этот код Java показывает, как установить цвет кисти чернил:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation("pres.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IInk ink = (IInk) slide.getShapes().get_Item(0);
    IInkBrush brush = ink.getTraces()[0].getBrush();
    brush.setColor(Color.RED);
} finally {
    presentation.dispose();
}
```

### **Установка размера кисти чернил**

Этот код Java показывает, как установить размер кисти чернил:

```java
import com.aspose.slides.*;
import java.awt.Dimension;

Presentation presentation = new Presentation("pres.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IInk ink = (IInk) slide.getShapes().get_Item(0);
    IInkBrush brush = ink.getTraces()[0].getBrush();
    Dimension brushSize = new Dimension(5, 10);
    brush.setSize(brushSize);
} finally {
    presentation.dispose();
}
```

Как правило, ширина и высота кисти не совпадают, поэтому PowerPoint не отображает размер кисти (соответствующий раздел данных серый). Когда ширина и высота кисти совпадают, PowerPoint отображает её размер так:

![ink_powerpoint3](ink_powerpoint3.png)

Для наглядности увеличим высоту объекта чернил и рассмотрим важные размеры:

![ink_powerpoint4](ink_powerpoint4.png)

Контейнер (рамка) не учитывает размер кистей — он всегда предполагает, что толщина линии равна нулю (см. предыдущее изображение).

Следовательно, чтобы определить видимую область всего объекта чернил, необходимо учитывать размер кисти его трасс. Здесь целевой объект (трасса рукописного текста) был масштабирован до размеров контейнера (рамки). Когда размер контейнера меняется, размер кисти остаётся постоянным, и наоборот.

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint использует аналогичное поведение для текстовых объектов:

![ink_powerpoint6](ink_powerpoint6.png)

## **Управление отображением чернил при экспорте и визуализации**

Aspose.Slides предоставляет интерфейс [IInkOptions](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iinkoptions/) для контроля того, как объекты чернил появляются в экспортированном или визуализированном выводе. С его свойствами можно полностью скрыть чернила или изменить способ интерпретации операций маски кисти чернил.

Параметры чернил доступны через параметры экспорта или визуализации для нескольких типов вывода:

| Вывод | Свойство параметров чернил |
| --- | --- |
| PDF | [`PdfOptions.getInkOptions`](https://reference.aspose.com/slides/ru/java/com.aspose.slides/pdfoptions/#getInkOptions--) |
| HTML | [`HtmlOptions.getInkOptions`](https://reference.aspose.com/slides/ru/java/com.aspose.slides/htmloptions/#getInkOptions--) |
| SVG | [`SVGOptions.getInkOptions`](https://reference.aspose.com/slides/ru/java/com.aspose.slides/svgoptions/#getInkOptions--) |
| TIFF | [`TiffOptions.getInkOptions`](https://reference.aspose.com/slides/ru/java/com.aspose.slides/tiffoptions/#getInkOptions--) |
| Slide image | [`RenderingOptions.getInkOptions`](https://reference.aspose.com/slides/ru/java/com.aspose.slides/renderingoptions/#getInkOptions--) |

Следующие методы [IInkOptions](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iinkoptions/) раскрывают те же два параметра:

- [IInkOptions.getHideInk](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iinkoptions/#getHideInk--) определяет, включаются ли объекты чернил в вывод. Значение по умолчанию `false`.
- [IInkOptions.getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iinkoptions/#getInterpretMaskOpAsOpacity--) определяет, интерпретируется ли операция маски как непрозрачность при визуализации кисти чернил. Значение по умолчанию `true`; вызовите [IInkOptions.setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iinkoptions/#setInterpretMaskOpAsOpacity-boolean-) с `false`, чтобы использовать операцию ROP вместо неё.

### **Скрыть объекты чернил в PDF‑выводе**

По умолчанию объекты чернил остаются видимыми при экспорте. Чтобы получить чистый вывод без рукописных аннотаций или другого содержимого чернил, вызовите [IInkOptions.setHideInk](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iinkoptions/#setHideInk-boolean-) с `true`.

Следующий пример Java экспортирует презентацию в PDF, скрывая все объекты чернил:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.getInkOptions().setHideInk(true);

    presentation.save("presentation_without_ink.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Скрыть объекты чернил при визуализации слайда как изображения**

Чтобы скрыть объекты чернил при визуализации слайдов в виде растровых изображений, настройте [RenderingOptions.getInkOptions](https://reference.aspose.com/slides/ru/java/com.aspose.slides/renderingoptions/#getInkOptions--) и передайте параметры визуализации в [ISlide.getImage](https://reference.aspose.com/slides/ru/java/com.aspose.slides/islide/#getImage-com.aspose.slides.IRenderingOptions-).

Следующий пример Java визуализирует первый слайд как PNG‑изображение без объектов чернил:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    RenderingOptions renderingOptions = new RenderingOptions();
    renderingOptions.getInkOptions().setHideInk(true);

    ISlide slide = presentation.getSlides().get_Item(0);
    IImage image = slide.getImage(renderingOptions);
    try {
        image.save("slide_without_ink.png", ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

### **Управление визуализацией маски чернил**

Настройка [IInkOptions.getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iinkoptions/#getInterpretMaskOpAsOpacity--) определяет, как операции маски интерпретируются при визуализации кистей чернил. Значение по умолчанию `true`, что использует непрозрачность. Чтобы вместо этого использовать операцию ROP, вызовите [IInkOptions.setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iinkoptions/#setInterpretMaskOpAsOpacity-boolean-) с `false`.

Следующий пример Java экспортирует слайд в SVG и использует визуализацию на основе ROP для операций маски чернил:

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;
import java.io.IOException;

Presentation presentation = new Presentation("presentation.pptx");
try {
    SVGOptions svgOptions = new SVGOptions();
    svgOptions.getInkOptions().setInterpretMaskOpAsOpacity(false);

    FileOutputStream stream = new FileOutputStream("slide.svg");
    ISlide slide = presentation.getSlides().get_Item(0);
    slide.writeAsSvg(stream, svgOptions);
} finally {
    presentation.dispose();
}
```

То же самое настройка может быть применена через [TiffOptions.getInkOptions](https://reference.aspose.com/slides/ru/java/com.aspose.slides/tiffoptions/#getInkOptions--) при экспорте презентации или визуализации слайда в TIFF.

### **Выберите, скрывать или сохранять чернила**

Когда вам нужна чистая версия аннотированной презентации для распространения без отметок рецензирования, вызовите [IInkOptions.setHideInk](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iinkoptions/#setHideInk-boolean-) с `true` во время экспорта.

Оставьте [IInkOptions.getHideInk](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iinkoptions/#getHideInk--) со значением по умолчанию `false`, когда аннотации чернил являются частью ожидаемого содержимого, например, комментарии рецензентов, рукописные заметки, выделения или рисунки, которые должны оставаться видимыми в экспортированном результате. Это позволяет приложениям генерировать отдельные рецензионные и финальные выводы из одной и той же презентации без изменения исходных объектов чернил.

## **Часто задаваемые вопросы**

**Можно ли изменить цвет или размер существующего штриха чернил?**

Да. Получите трассу через [IInk.getTraces](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iink/#getTraces--), затем измените её [IInkTrace.getBrush](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iinktrace/#getBrush--). Вызовите [IInkBrush.setColor](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iinkbrush/#setColor-java.awt.Color-) или [IInkBrush.setSize](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iinkbrush/#setSize-java.awt.geom.Dimension2D-) для изменения кисти.

**Скрытие чернил изменяет исходную презентацию?**

Нет. Вызов [IInkOptions.setHideInk](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iinkoptions/#setHideInk-boolean-) влияет только на визуализированный или экспортированный результат; он не удаляет и не изменяет объекты чернил в исходной презентации.

**Какие форматы экспорта поддерживают параметры чернил?**

Вы можете настроить параметры чернил для PDF, HTML, SVG, TIFF и растровых изображений слайдов через соответствующие параметры экспорта или визуализации, показанные выше.

**Дополнительные материалы**

* Чтобы узнать о фигурах в целом, см. раздел [PowerPoint Shapes](https://docs.aspose.com/slides/ru/java/powerpoint-shapes/).
* Для получения информации об эффективных значениях см. [Shape Effective Properties](https://docs.aspose.com/slides/ru/java/shape-effective-properties/#get-effective-font-height-value).
* Подробности экспорта в PDF см. [Convert PPT and PPTX to PDF](https://docs.aspose.com/slides/ru/java/convert-powerpoint-to-pdf/).
* Подробности экспорта в HTML см. [Convert PowerPoint Presentations to HTML](https://docs.aspose.com/slides/ru/java/convert-powerpoint-to-html/).
* Подробности экспорта в SVG см. [Render Presentation Slides as SVG Images](https://docs.aspose.com/slides/ru/java/render-a-slide-as-an-svg-image/).
* Подробности экспорта в TIFF см. [Convert PowerPoint Presentations to TIFF](https://docs.aspose.com/slides/ru/java/convert-powerpoint-to-tiff/).
* Подробности визуализации слайда в изображение см. [Convert Presentation Slides to Images](https://docs.aspose.com/slides/ru/java/convert-slide/).