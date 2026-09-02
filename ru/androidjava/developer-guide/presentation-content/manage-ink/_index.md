---
title: Управление объектами чернил презентации на Android
linktitle: Управление чернилами
type: docs
weight: 95
url: /ru/androidjava/manage-ink/
keywords:
- чернила
- объект чернил
- след чернил
- управление чернилами
- рисовать чернилами
- рисование
- экспорт чернил
- рендеринг чернил
- скрыть чернила
- IInkOptions
- PowerPoint
- презентация
- Android
- Java
- Aspose.Slides
description: "Управляйте объектами чернил PowerPoint, редактируйте следы и свойства кисти, а также контролируйте отображение чернил при экспорте в PDF, HTML, SVG, TIFF и изображения с помощью Aspose.Slides для Android."
---
## **Введение**

PowerPoint предоставляет функцию «чернила», позволяющую рисовать произвольные штрихи. Чернила можно использовать для выделения других объектов, отображения связей и процессов, а также привлечения внимания к конкретным элементам на слайде.

Aspose.Slides предоставляет типы, необходимые для работы с объектами чернил. Например, интерфейс [IInk](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iink/) представляет объект чернил на слайде.

## **Различия между обычными объектами и объектами чернил**

Объекты на слайде PowerPoint обычно представлены объектами формы. В своей простейшей форме форма представляет собой контейнер, определяющий область самого объекта (его рамку) вместе с такими свойствами, как размер контейнера, форма и фон. Для получения дополнительной информации смотрите [Shape Layout Format](https://docs.aspose.com/slides/ru/androidjava/shape-manipulations/#access-layout-formats-for-shape).

Однако когда PowerPoint обрабатывает объект чернил, он игнорирует все свойства рамки объекта (контейнера), кроме его размеров. Размер области контейнера определяется стандартными методами [IShape.getWidth](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ishape/#getWidth--) и [IShape.getHeight](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ishape/#getHeight--) методов:

![ink_powerpoint1](ink_powerpoint1.png)

## **Следы чернил**

След чернил — это базовый элемент, используемый для записи траектории пера, когда пользователь пишет цифровыми чернилами. След хранит последовательность соединённых точек.

Самая простая форма кодирования указывает координаты X и Y каждой выборочной точки. Когда все соединённые точки отрисовываются, они образуют изображение, подобное следующему:

![ink_powerpoint2](ink_powerpoint2.png)

## **Свойства кисти для рисования**

Кисть используется для рисования линий, соединяющих точки следа чернил. Кисть имеет собственный цвет и размер, представленные методами [IInkBrush.getColor](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iinkbrush/#getColor--) и [IInkBrush.getSize](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iinkbrush/#getSize--) .

### **Установить цвет кисти чернил**

Этот фрагмент кода Java показывает, как установить цвет кисти чернил:

```java
import android.graphics.Color;
import com.aspose.slides.*;

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

### **Установить размер кисти чернил**

Этот фрагмент кода Java показывает, как установить размер кисти чернил:

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation("pres.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IInk ink = (IInk) slide.getShapes().get_Item(0);
    IInkBrush brush = ink.getTraces()[0].getBrush();
    SizeF brushSize = new SizeF(5, 10);
    brush.setSize(brushSize);
} finally {
    presentation.dispose();
}
```

Как правило, ширина и высота кисти не совпадают, поэтому PowerPoint не отображает размер кисти (соответствующий раздел данных серый). Когда ширина и высота кисти совпадают, PowerPoint отображает её размер следующим образом:

![ink_powerpoint3](ink_powerpoint3.png)

Для наглядности увеличим высоту объекта чернил и рассмотрим важные размеры:

![ink_powerpoint4](ink_powerpoint4.png)

Контейнер (рамка) не учитывает размер кистей — он всегда предполагает, что толщина линии равна нулю (см. предыдущее изображение).

Следовательно, чтобы определить видимую область всего объекта чернил, необходимо учитывать размер кисти его следов. Здесь целевой объект (след рукописного текста) масштабирован до размера контейнера (рамки). При изменении размера контейнера размер кисти остаётся постоянным, и наоборот.

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint использует аналогичное поведение для текстовых объектов:

![ink_powerpoint6](ink_powerpoint6.png)

## **Управление отображением чернил при экспорте и рендеринге**

Aspose.Slides предоставляет интерфейс [IInkOptions](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iinkoptions/) , позволяющий управлять тем, как объекты чернил отображаются в экспортируемом или отрендеренном выводе. Вы можете использовать его свойства, чтобы полностью скрыть чернила или изменить способ интерпретации операций маски кисти чернил.

Параметры чернил доступны через параметры экспорта или рендеринга для нескольких типов вывода:

| Вывод | Свойство параметров чернил |
| --- | --- |
| PDF | [PdfOptions.getInkOptions](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/pdfoptions/#getInkOptions--) |
| HTML | [HtmlOptions.getInkOptions](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/htmloptions/#getInkOptions--) |
| SVG | [SVGOptions.getInkOptions](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/svgoptions/#getInkOptions--) |
| TIFF | [TiffOptions.getInkOptions](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/tiffoptions/#getInkOptions--) |
| Изображение слайда | [RenderingOptions.getInkOptions](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/renderingoptions/#getInkOptions--) |

Следующие методы [IInkOptions](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iinkoptions/) предоставляют те же два параметра:

- [IInkOptions.getHideInk](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iinkoptions/#getHideInk--) определяет, включаются ли объекты чернил в вывод. Значение по умолчанию — `false`.
- [IInkOptions.getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iinkoptions/#getInterpretMaskOpAsOpacity--) определяет, интерпретируется ли операция маски как непрозрачность при рендеринге кисти чернил. Значение по умолчанию — `true`; вызовите [IInkOptions.setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iinkoptions/#setInterpretMaskOpAsOpacity-boolean-) с `false`, чтобы вместо этого использовать операцию ROP.

### **Скрыть объекты чернил в выводе PDF**

По умолчанию объекты чернил остаются видимыми при экспорте. Чтобы получить чистый вывод без рукописных аннотаций или другого содержимого чернил, вызовите [IInkOptions.setHideInk](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iinkoptions/#setHideInk-boolean-) с `true`.

Следующий пример на Java экспортирует презентацию в PDF, скрывая все объекты чернил:

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

### **Скрыть объекты чернил при рендеринге слайда как изображения**

Чтобы скрыть объекты чернил при рендеринге слайдов как растровых изображений, настройте [RenderingOptions.getInkOptions](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/renderingoptions/#getInkOptions--) и передайте параметры рендеринга в [ISlide.getImage](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/islide/#getImage-com.aspose.slides.IRenderingOptions-).

Следующий пример на Java рендерит первый слайд как PNG‑изображение без объектов чернил:

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

### **Управление рендерингом маски чернил**

Параметр [IInkOptions.getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iinkoptions/#getInterpretMaskOpAsOpacity--) контролирует, как операции маски интерпретируются при рендеринге кистей чернил. Значение по умолчанию — `true`, что использует непрозрачность. Чтобы вместо этого использовать операцию ROP, вызовите [IInkOptions.setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iinkoptions/#setInterpretMaskOpAsOpacity-boolean-) с `false`.

Следующий пример на Java экспортирует слайд в SVG и использует рендеринг на основе ROP для операций маски чернил:

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;

Presentation presentation = new Presentation("presentation.pptx");
try {
    SVGOptions svgOptions = new SVGOptions();
    svgOptions.getInkOptions().setInterpretMaskOpAsOpacity(false);

    ISlide slide = presentation.getSlides().get_Item(0);
    FileOutputStream stream = new FileOutputStream("slide.svg");
    try {
        slide.writeAsSvg(stream, svgOptions);
    } finally {
        stream.close();
    }
} finally {
    presentation.dispose();
}
```

То же самое настройку можно применить через [TiffOptions.getInkOptions](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/tiffoptions/#getInkOptions--) при экспорте презентации или рендеринге слайда в TIFF.

### **Выберите, скрывать или сохранять чернила**

Когда вам нужна чистая версия аннотированной презентации для распространения без отметок рецензии, вызовите [IInkOptions.setHideInk](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iinkoptions/#setHideInk-boolean-) с `true` во время экспорта.

Оставьте [IInkOptions.getHideInk](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iinkoptions/#getHideInk--) со значением по умолчанию `false`, если аннотации чернил являются частью предполагаемого содержимого, например комментарии рецензии, рукописные заметки, выделения или рисунки, которые должны оставаться видимыми в экспортированном результате. Это позволяет приложениям генерировать отдельные рецензионные и финальные выводы из одной презентации без изменения исходных объектов чернил.

## **Часто задаваемые вопросы**

**Можно ли изменить цвет или размер существующего штриха чернил?**

Да. Получите след через [IInk.getTraces](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iink/#getTraces--), затем измените его [IInkTrace.getBrush](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iinktrace/#getBrush--). Вызовите [IInkBrush.setColor](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iinkbrush/#setColor-java.lang.Integer-) или [IInkBrush.setSize](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iinkbrush/#setSize-com.aspose.slides.android.SizeF-) для изменения кисти.

**Изменяет ли скрытие чернил исходную презентацию?**

Нет. Вызов [IInkOptions.setHideInk](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iinkoptions/#setHideInk-boolean-) влияет только на отрендеренный или экспортированный результат; он не удаляет и не изменяет объекты чернил в исходной презентации.

**Какие форматы экспорта поддерживают параметры чернил?**

Вы можете настроить параметры чернил для PDF, HTML, SVG, TIFF и растровых изображений слайдов через соответствующие параметры экспорта или рендеринга, указанные выше.

## **Дополнительные ресурсы**

* Чтобы узнать о фигурах в целом, смотрите раздел [PowerPoint Shapes](https://docs.aspose.com/slides/ru/androidjava/powerpoint-shapes/).
* Для получения информации об эффективных значениях см. [Shape Effective Properties](https://docs.aspose.com/slides/ru/androidjava/shape-effective-properties/#get-effective-font-height-value).
* Подробности экспорта в PDF см. в статье [Convert PPT and PPTX to PDF](https://docs.aspose.com/slides/ru/androidjava/convert-powerpoint-to-pdf/).
* Подробности экспорта в HTML см. в статье [Convert PowerPoint Presentations to HTML](https://docs.aspose.com/slides/ru/androidjava/convert-powerpoint-to-html/).
* Подробности экспорта в SVG см. в статье [Render Presentation Slides as SVG Images](https://docs.aspose.com/slides/ru/androidjava/render-a-slide-as-an-svg-image/).
* Подробности экспорта в TIFF см. в статье [Convert PowerPoint Presentations to TIFF](https://docs.aspose.com/slides/ru/androidjava/convert-powerpoint-to-tiff/).
* Подробности рендеринга слайдов в изображения см. в статье [Convert Presentation Slides to Images](https://docs.aspose.com/slides/ru/androidjava/convert-slide/).