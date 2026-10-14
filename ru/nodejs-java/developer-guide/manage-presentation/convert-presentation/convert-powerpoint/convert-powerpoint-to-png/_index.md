---
title: Преобразование слайдов PowerPoint в PNG на JavaScript
linktitle: PowerPoint в PNG
type: docs
weight: 30
url: /ru/nodejs-java/convert-powerpoint-to-png/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Быстро конвертируйте презентации PowerPoint в высококачественные PNG‑изображения на JavaScript с помощью Aspose.Slides for Node.js, обеспечивая точные и автоматизированные результаты."
---
## **Обзор**

В этой статье объясняется, как преобразовать слайды презентаций в изображения PNG с помощью Aspose.Slides for Node.js via Java. Вы можете загружать презентации в форматах, таких как PPT, PPTX и ODP, отрисовывать каждый слайд и сохранять его как отдельное изображение PNG.

Приведённые ниже примеры демонстрируют рендеринг с масштабом по умолчанию, увеличение масштаба, указание размеров вывода в пикселях и выбор стиля рендеринга градиента.

## **Преобразование PowerPoint в PNG**

Загрузите презентацию с помощью класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) и получите доступ к её слайдам через коллекцию [Presentation.getSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getSlides). В примере каждый слайд рендерится с помощью [Slide.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/#getImage) без параметров для создания миниатюры. Затем вызывается [IImage.save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/iimage/#save) с [ImageFormat.Png](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imageformat/#Png) для сохранения каждого отрисованного слайда в виде изображения PNG.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let slideCount = presentation.getSlides().size();
    for (let index = 0; index < slideCount; index++) {
        let slide = presentation.getSlides().get_Item(index);
        let image = slide.getImage();
        try {
            image.save("slide_" + index + ".png", aspose.slides.ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Перегрузка [Slide.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/#getImage) без параметров рендерит с масштабом 0.2. Например, слайд размером 720 × 540 пунктов дает миниатюру 144 × 108 пикселей. Чтобы управлять размерами вывода, используйте перегрузки с коэффициентами масштабирования или явно указанным размером изображения, показанным ниже.
{{% /alert %}}

## **Преобразование PowerPoint в PNG с пользовательскими размерами**

Передайте горизонтальные и вертикальные коэффициенты масштабирования в [Slide.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/#getImage), чтобы контролировать отрисованные размеры. В этом примере оба коэффициента равны 2, поэтому слайд размером 720 × 540 пунктов даёт изображение 1440 × 1080 пикселей. Равные коэффициенты сохраняют соотношение сторон слайда. Каждое изображение сохраняется в формате PNG с помощью [IImage.save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/iimage/#save).
```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let scaleX = 2.0;
    let scaleY = scaleX;

    let slideCount = presentation.getSlides().size();
    for (let index = 0; index < slideCount; index++) {
        let slide = presentation.getSlides().get_Item(index);
        let image = slide.getImage(scaleX, scaleY);
        try {
            image.save("slide_" + index + ".png", aspose.slides.ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **Преобразование PowerPoint в PNG с пользовательским размером**

Чтобы задать размеры вывода в пикселях, передайте размер в [Slide.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/#getImage) вместо коэффициентов масштабирования. В этом примере каждый слайд рендерится с размерами 960 × 720 пикселей и результат сохраняется с помощью [IImage.save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/iimage/#save). Выберите размеры, соответствующие соотношению сторон слайда, чтобы избежать искажения изображения.
```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let imageSize = java.newInstanceSync("java.awt.Dimension", 960, 720);

    let slideCount = presentation.getSlides().size();
    for (let index = 0; index < slideCount; index++) {
        let slide = presentation.getSlides().get_Item(index);
        let image = slide.getImage(imageSize);
        try {
            image.save("slide_" + index + ".png", aspose.slides.ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **Выбор стиля рендеринга градиента**

Предположим, что слайд содержит градиентные заливки, но переходы в экспортированном PNG выглядят светлее или иначе отличаются от того, что вы видите в PowerPoint. Вы можете использовать метод [SaveOptions.setGradientStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveoptions/#setGradientStyle), унаследованный от [RenderingOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/renderingoptions/), чтобы выбрать способ рендеринга градиентов.

Скачайте [gradient-styles.pptx](gradient-styles.pptx) и поместите его в рабочий каталог приложения. Его первый слайд содержит два линейных градиента: от голубого к оранжевому вверху и от синего к жёлтому внизу. Каждый градиент имеет две остановки — на 0 % и 100 %.

Следующий пример загружает эту презентацию и рендерит один и тот же первый слайд в обоих режимах с помощью [Slide.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/#getImage).
```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("gradient-styles.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);

    let gradientStyles = [aspose.slides.GradientStyle.Default, aspose.slides.GradientStyle.PowerPointUI];
    for (let style of gradientStyles) {
        let options = new aspose.slides.RenderingOptions();
        options.setGradientStyle(style);

        let styleName = style == aspose.slides.GradientStyle.Default ? "Default" : "PowerPointUI";
        let image = slide.getImage(options, 1.0, 1.0);
        try {
            image.save("gradient-" + styleName + ".png", aspose.slides.ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

Ниже приведённые изображения показывают результат одного и того же слайда, с обоими градиентами на каждом изображении:

| Default | PowerPointUI |
| --- | --- |
| ![Градиенты от голубого к оранжевому и от синего к жёлтому, отрендеренные с Default](gradient-Default.png) | ![Те же градиенты, отрендеренные с PowerPointUI](gradient-PowerPointUI.png) |

В этом примере `Default` дает более светлые промежуточные цвета, тогда как `PowerPointUI` – более тёмные промежуточные цвета. Разница зависит от цветов и остановок в градиенте.

Выбирайте `Default`, если стандартный вывод Aspose.Slides вас устраивает. Попробуйте `PowerPointUI`, когда приоритетом является соответствие внешнему виду в PowerPoint. Сравните оба вывода с ожидаемым результатом; ни один режим не является универсально предпочтительным.

## **FAQ**

**Как экспортировать конкретную форму, например диаграмму или изображение, вместо всего слайда?**

Aspose.Slides поддерживает [создание миниатюр для отдельных фигур](/slides/ru/nodejs-java/create-shape-thumbnails/), что позволяет рендерить форму как PNG‑изображение.

**Поддерживается ли параллельное преобразование на сервере?**

Да. Используйте отдельный экземпляр презентации для каждого потока или процесса; [не делитесь одним экземпляром между потоками](/slides/ru/nodejs-java/multithreading/).

**Каковы ограничения оценочной версии при экспорте в PNG?**

В режиме оценки к выводимым изображениям добавляется водяной знак и применяются [другие ограничения](/slides/ru/nodejs-java/licensing/), пока не будет применена лицензия.