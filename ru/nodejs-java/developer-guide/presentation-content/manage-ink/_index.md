---
title: Управление объектами черни в JavaScript
linktitle: Управление чернью
type: docs
weight: 95
url: /ru/nodejs-java/manage-ink/
keywords:
- чернила
- объект черни
- след черни
- управление черни
- рисование черни
- рисование
- экспорт черни
- рендеринг черни
- скрыть чернь
- InkOptions
- PowerPoint
- презентация
- Node.js
- JavaScript
- Aspose.Slides
description: "Управляйте объектами черни PowerPoint, редактируйте следы и свойства кисти, а также контролируйте отображение черни при экспорте в PDF, HTML, SVG, TIFF и изображения с помощью Aspose.Slides для Node.js через Java."
---
## **Введение**

PowerPoint предоставляет функцию черни, позволяющую рисовать произвольные линии. Чернила можно использовать для выделения других объектов, показа соединений и процессов, а также привлечения внимания к конкретным элементам на слайде.

Aspose.Slides предоставляет типы, необходимые для работы с объектами черни. Например, класс [Ink](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/ink/) представляет объект черни на слайде.

## **Различия между обычными объектами и объектами черни**

Объекты на слайде PowerPoint обычно представлены объектами формы. В своей самой простой форме форма — это контейнер, определяющий область самого объекта (его рамку) вместе со свойствами, такими как размер контейнера, форма и фон. Для получения дополнительной информации см. [Shape Layout Format](https://docs.aspose.com/slides/ru/nodejs-java/shape-manipulations/#access-layout-formats-for-shape).

Однако, когда PowerPoint обрабатывает объект черни, он игнорирует все свойства рамки объекта (контейнера), кроме его размера. Размер области контейнера определяется стандартными методами [Shape.getWidth](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/shape/#getWidth--) и [Shape.getHeight](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/shape/#getHeight--) :

![ink_powerpoint1](ink_powerpoint1.png)

## **Следы черни**

След черни — это базовый элемент, используемый для записи траектории пера, когда пользователь пишет цифровые чернила. След хранит последовательность соединённых точек.

Самая простая форма кодирования указывает координаты X и Y каждой примерной точки. При отрисовке всех соединённых точек они образуют изображение, похожее на это:

![ink_powerpoint2](ink_powerpoint2.png)

## **Свойства кисти для рисования**

Кисть используется для рисования линий, соединяющих точки следа черни. Кисть имеет собственный цвет и размер, представленные методами [InkBrush.getColor](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/inkbrush/#getColor--) и [InkBrush.getSize](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/inkbrush/#getSize--) .

### **Установить цвет кисти черни**

Этот JavaScript‑код показывает, как задать цвет кисти черни:

```javascript
const aspose = {
    slides: require("aspose.slides.via.java")
};
const java = require("java");

const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const ink = slide.getShapes().get_Item(0);
    const brush = ink.getTraces()[0].getBrush();
    const red = java.getStaticFieldValue("java.awt.Color", "RED");
    brush.setColor(red);
} finally {
    presentation.dispose();
}
```

### **Установить размер кисти черни**

Этот JavaScript‑код показывает, как задать размер кисти черни:

```javascript
const aspose = {
    slides: require("aspose.slides.via.java")
};
const java = require("java");

const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const ink = slide.getShapes().get_Item(0);
    const brush = ink.getTraces()[0].getBrush();
    const brushSize = java.newInstanceSync("java.awt.Dimension", 5, 10);
    brush.setSize(brushSize);
} finally {
    presentation.dispose();
}
```

Как правило, ширина и высота кисти не совпадают, поэтому PowerPoint не отображает размер кисти (соответствующий раздел данных серый). Когда ширина и высота кисти совпадают, PowerPoint отображает её размер так:

![ink_powerpoint3](ink_powerpoint3.png)

Для наглядности увеличим высоту объекта черни и рассмотрим важные размеры:

![ink_powerpoint4](ink_powerpoint4.png)

Контейнер (рамка) не учитывает размер кистей — он всегда предполагает, что толщина линии равна нулю (см. предыдущее изображение).

Следовательно, чтобы определить видимую область всего объекта черни, необходимо учитывать размер кисти его следов. Здесь целевой объект (след рукописного текста) был масштабирован до размера контейнера (рамки). При изменении размера контейнера размер кисти остаётся постоянным и наоборот.

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint использует аналогичное поведение для текстовых объектов:

![ink_powerpoint6](ink_powerpoint6.png)

## **Управление отображением черни при экспорте и рендеринге**

Aspose.Slides предоставляет класс [InkOptions](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/inkoptions/) для управления тем, как объекты черни отображаются в экспортированном или отрендеренном выводе. С помощью его свойств можно полностью скрыть черни или изменить способ интерпретации операций маски кисти черни.

Параметры черни доступны через параметры экспорта или рендеринга для нескольких типов вывода:

| Вывод | Свойство параметров Ink |
| --- | --- |
| PDF | [`PdfOptions.getInkOptions`](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/pdfoptions/#getInkOptions--) |
| HTML | [`HtmlOptions.getInkOptions`](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/htmloptions/#getInkOptions--) |
| SVG | [`SVGOptions.getInkOptions`](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/svgoptions/#getInkOptions--) |
| TIFF | [`TiffOptions.getInkOptions`](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/tiffoptions/#getInkOptions--) |
| Изображение слайда | [`RenderingOptions.getInkOptions`](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/renderingoptions/#getInkOptions--) |

Следующие методы [InkOptions](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/inkoptions/) предоставляют те же два параметра:

- [InkOptions.getHideInk](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/inkoptions/#getHideInk--) определяет, включаются ли объекты черни в выходные данные. Значение по умолчанию `false`.
- [InkOptions.getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/inkoptions/#getInterpretMaskOpAsOpacity--) определяет, интерпретируется ли операция маски как непрозрачность при рендеринге кисти черни. Значение по умолчанию `true`; вызовите [InkOptions.setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/inkoptions/#setInterpretMaskOpAsOpacity-boolean-) с `false`, чтобы вместо этого использовать операцию ROP.

### **Скрыть объекты черни при выводе PDF**

По умолчанию объекты черни остаются видимыми при экспорте. Чтобы создать чистый вывод без рукописных аннотаций или другого контента черни, вызовите [InkOptions.setHideInk](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/inkoptions/#setHideInk-boolean-) с `true`.

Следующий пример JavaScript экспортирует презентацию в PDF, скрывая все объекты черни:

```javascript
const aspose = {
    slides: require("aspose.slides.via.java")
};

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const pdfOptions = new aspose.slides.PdfOptions();
    pdfOptions.getInkOptions().setHideInk(true);

    presentation.save("presentation_without_ink.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Скрыть объекты черни при рендеринге слайда как изображения**

Чтобы скрыть объекты черни при рендеринге слайдов в виде растровых изображений, настройте [RenderingOptions.getInkOptions](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/renderingoptions/#getInkOptions--) и передайте параметры рендеринга в [Slide.getImage](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/slide/#getImage-aspose.slides.IRenderingOptions-).

Следующий пример JavaScript рендерит первый слайд в PNG‑изображение без объектов черни:

```javascript
const aspose = {
    slides: require("aspose.slides.via.java")
};

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const renderingOptions = new aspose.slides.RenderingOptions();
    renderingOptions.getInkOptions().setHideInk(true);

    const slide = presentation.getSlides().get_Item(0);
    const image = slide.getImage(renderingOptions);
    try {
        image.save("slide_without_ink.png", aspose.slides.ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

### **Управление рендерингом маски черни**

Параметр [InkOptions.getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/inkoptions/#getInterpretMaskOpAsOpacity--) определяет, как операции маски интерпретируются при рендеринге кистей черни. Значение по умолчанию `true`, что использует непрозрачность. Чтобы вместо этого использовать операцию ROP, вызовите [InkOptions.setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/inkoptions/#setInterpretMaskOpAsOpacity-boolean-) с `false`.

Следующий пример JavaScript экспортирует слайд в SVG и использует рендеринг на основе ROP для операций маски черни:

```javascript
const aspose = {
    slides: require("aspose.slides.via.java")
};
const java = require("java");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const svgOptions = new aspose.slides.SVGOptions();
    svgOptions.getInkOptions().setInterpretMaskOpAsOpacity(false);

    const outputStream = java.newInstanceSync("java.io.FileOutputStream", "slide.svg");
    try {
        const slide = presentation.getSlides().get_Item(0);
        slide.writeAsSvg(outputStream, svgOptions);
    } finally {
        outputStream.close();
    }
} finally {
    presentation.dispose();
}
```

То же самое можно применить через [TiffOptions.getInkOptions](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/tiffoptions/#getInkOptions--) при экспорте презентации или рендеринге слайда в TIFF.

### **Выберите, скрывать или сохранять черни**

Когда вам нужна чистая версия аннотированной презентации для распространения без отметок рецензирования, вызовите [InkOptions.setHideInk](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/inkoptions/#setHideInk-boolean-) с `true` во время экспорта.

Оставьте [InkOptions.getHideInk](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/inkoptions/#getHideInk--) со значением по умолчанию `false`, если аннотации черни являются частью задуманного контента, например, комментарии рецензента, рукописные заметки, выделения или рисунки, которые должны оставаться видимыми в экспортированном результате. Это позволяет приложениям генерировать отдельные версии для рецензирования и финального вывода из одной и той же презентации без изменения исходных объектов черни.

## **Часто задаваемые вопросы**

**Можно ли изменить цвет или размер существующего штриха черни?**

Да. Получите след через [Ink.getTraces](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/ink/#getTraces--) и затем измените его [InkTrace.getBrush](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/inktrace/#getBrush--). Вызовите [InkBrush.setColor](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/inkbrush/#setColor-java.awt.Color-) или [InkBrush.setSize](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/inkbrush/#setSize-java.awt.geom.Dimension2D-) для изменения кисти.

**Скрытие черни меняет исходную презентацию?**

Нет. Вызов [InkOptions.setHideInk](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/inkoptions/#setHideInk-boolean-) влияет только на отрендеренный или экспортированный результат; он не удаляет и не изменяет объекты черни в исходной презентации.

**Какие форматы экспорта поддерживают параметры черни?**

Вы можете настроить параметры черни для PDF, HTML, SVG, TIFF и растровых изображений слайдов через соответствующие параметры экспорта или рендеринга, указанные выше.

**Дополнительные материалы**

* Чтобы узнать о фигурах в целом, см. раздел [PowerPoint Shapes](https://docs.aspose.com/slides/ru/nodejs-java/powerpoint-shapes/).
* Для получения более подробной информации о эффективных значениях см. [Shape Effective Properties](https://docs.aspose.com/slides/ru/nodejs-java/shape-effective-properties/#get-effective-font-height-value).
* Подробности экспорта в PDF см. в статье [Convert PPT and PPTX to PDF](https://docs.aspose.com/slides/ru/nodejs-java/convert-powerpoint-to-pdf/).
* Подробности экспорта в HTML см. в статье [Convert PowerPoint Presentations to HTML](https://docs.aspose.com/slides/ru/nodejs-java/convert-powerpoint-to-html/).
* Подробности экспорта в SVG см. в статье [Render Presentation Slides as SVG Images](https://docs.aspose.com/slides/ru/nodejs-java/render-a-slide-as-an-svg-image/).
* Подробности экспорта в TIFF см. в статье [Convert PowerPoint Presentations to TIFF](https://docs.aspose.com/slides/ru/nodejs-java/convert-powerpoint-to-tiff/).
* Подробности рендеринга слайд‑в‑изображение см. в статье [Convert Presentation Slides to Images](https://docs.aspose.com/slides/ru/nodejs-java/convert-slide/).