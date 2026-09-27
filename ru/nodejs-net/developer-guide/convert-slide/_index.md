---
title: Преобразование слайдов презентации в изображения в Node.js через .NET
linktitle: Слайд в изображение
type: docs
weight: 40
url: /ru/nodejs-net/convert-slide/
keywords:
  - преобразовать слайд
  - слайд в изображение
  - слайд в PNG
  - сохранить слайд как изображение
  - рендерить слайд
  - миниатюра слайда
  - PowerPoint
  - OpenDocument
  - презентация
  - Node.js
  - JavaScript
  - Aspose.Slides
description: "Отображайте слайды из презентаций PPTX, PPT и ODP в виде PNG-изображений в JavaScript с помощью Aspose.Slides for Node.js via .NET, используя коэффициент масштабирования или точный размер в пикселях."
---
## **Обзор**

Aspose.Slides for Node.js via .NET рендерит слайды из презентаций PowerPoint и OpenDocument в виде изображений, например, чтобы показать миниатюры слайдов на веб‑странице. В этой статье показаны два способа выбора размера изображения: коэффициент масштабирования относительно размера слайда и точный размер в пикселях. Оба примера сохраняют файлы PNG.

Примеры ожидают презентацию с именем `sample.pptx` в папке проекта, которую вы настроили в [Installation](/slides/ru/nodejs-net/installation/). Подойдёт любая презентация PowerPoint. Сохраните каждый пример как файл `.js` в папке проекта и запустите его из этой папки командой `node`.

{{% alert color="info" title="Note" %}}
Aspose.Slides for Node.js via .NET не имеет собственной справки по API. Он зеркалирует API Aspose.Slides for .NET с именами в camelCase, поэтому ссылки на API в этой статье ведут к соответствующим классам и членам в [Aspose.Slides for .NET API reference](https://reference.aspose.com/slides/net/).
{{% /alert %}}

Чтобы преобразовать слайд в изображение, выполните следующие шаги:

1. Откройте презентацию с помощью конструктора [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/presentation/).
1. Получите слайд из коллекции [slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/slides/) с помощью `get(index)`. Индексы начинаются с 0.
1. Отрендерите слайд с помощью `getImageWithScale` или `getImageWithImageSize`. В справке по .NET API оба метода являются перегрузками [Slide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage/). Они возвращают объект изображения, соответствующий [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/).
1. Сохраните изображение с помощью его метода [save](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/) и значения [ImageFormat](https://reference.aspose.com/slides/net/aspose.slides/imageformat/), затем вызовите его метод `dispose`.

## **Преобразовать каждый слайд в PNG‑изображение**

`getImageWithScale` принимает горизонтальный и вертикальный коэффициенты масштабирования. При масштабе 1 один пункт слайда становится одним пикселем изображения. В следующем примере каждый слайд рендерится при масштабе 2:

```javascript
const { Presentation, ImageFormat } = require("aspose.slides.via.net");

// Масштаб 1 отображает один пиксель на пункт; 2 удваивает ширину и высоту.
const scaleX = 2;
const scaleY = scaleX;

const presentation = new Presentation("sample.pptx");
try {
    const slideCount = presentation.slides.count;
    for (let index = 0; index < slideCount; index++) {
        const slide = presentation.slides.get(index);
        const image = slide.getImageWithScale(scaleX, scaleY);
        try {
            image.save(`slide_${index + 1}.png`, ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
    console.log(`Saved ${slideCount} images`);
} finally {
    presentation.dispose();
}
```

Скрипт записывает по одному файлу на каждый слайд: `slide_1.png`, `slide_2.png` и так далее, нумеруя их с 1. Для презентации 16:9 со слайдами размером 960 × 540 пунктов каждое изображение будет 1920 × 1080 пикселей. Скрытые слайды тоже рендерятся; чтобы пропустить их, проверьте свойство слайда [hidden](https://reference.aspose.com/slides/net/aspose.slides/slide/hidden/). Каждое изображение освобождается в собственном блоке `finally`, что освобождает его перед рендерингом следующего слайда. Без лицензии изображения также содержат водяной знак оценки; см. [Licensing](/slides/ru/nodejs-net/licensing/).

## **Преобразовать слайд в изображение заданного размера**

`getImageWithImageSize` принимает объект с полями `width` и `height` в пикселях. В следующем примере первый слайд рендерится шириной 1280 пикселей, а высота вычисляется из размера слайда, чтобы изображение сохраняло соотношение сторон слайда:

```javascript
const { Presentation, ImageFormat } = require("aspose.slides.via.net");

const imageWidth = 1280;

const presentation = new Presentation("sample.pptx");
try {
    const slideSize = presentation.slideSize.size;
    const imageHeight = Math.round(imageWidth * slideSize.height / slideSize.width);

    const slide = presentation.slides.get(0);
    const image = slide.getImageWithImageSize({ width: imageWidth, height: imageHeight });
    try {
        image.save("slide_1_1280px.png", ImageFormat.Png);
    } finally {
        image.dispose();
    }
    console.log(`Saved a ${imageWidth} x ${imageHeight} image`);
} finally {
    presentation.dispose();
}
```

Свойство [slideSize.size](https://reference.aspose.com/slides/net/aspose.slides/slidesize/size/) возвращает ширину и высоту слайда в пунктах. Для презентации 16:9 скрипт выводит `Saved a 1280 x 720 image` и пишет файл `slide_1_1280px.png`; для презентации 4:3 изображение будет 1280 × 960 пикселей.

## **FAQ**

**Почему изображение, полученное из `getImage` без аргументов, так мало?**

Без аргументов `getImage` рендерит слайд в 20 % от его размера в пунктах, поэтому слайд 960 × 540 пунктов превращается в изображение 192 × 108 пикселей. Используйте `getImageWithScale` или `getImageWithImageSize`, чтобы выбрать размер.

**Как сохранить JPEG или другие форматы изображений?**

Передайте другое значение `ImageFormat` в метод `save` изображения, например `image.save("slide_1.jpg", ImageFormat.Jpeg)`. Формат берётся из значения `ImageFormat`, а не из расширения файла, поэтому держите их согласованными.

**Почему текст на изображениях выглядит иначе в Linux?**

Aspose.Slides может использовать только шрифты, установленные на машине, которая рендерит слайды. Когда в презентации используется шрифт, которого нет, например Calibri на типичном Linux‑сервере, Aspose.Slides подставляет установленный шрифт, что может изменить вид текста и места переноса строк. Установите шрифты, используемые в ваших презентациях, чтобы получить такие же изображения, как в Windows.

**Почему `getThumbnailWithImageSize` выдаёт TypeError?**

В README пакета использован `getThumbnailWithImageSize`, но в пакете нет методов `getThumbnail`. Используйте вместо этого `getImageWithImageSize`; он принимает тот же аргумент `{ width, height }`.