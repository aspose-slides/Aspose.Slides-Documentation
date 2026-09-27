---
title: Создание презентаций в Node.js через .NET
linktitle: Создать презентацию
type: docs
weight: 10
url: /ru/nodejs-net/create-presentation/
keywords:
- создать презентацию
- новая презентация
- создать PowerPoint
- создать PPTX
- добавить текстовое поле
- добавить слайд
- размер слайда
- широкоформатный
- PowerPoint
- презентация
- Node.js
- JavaScript
- Aspose.Slides
description: "Создавайте презентации PowerPoint на JavaScript с помощью Aspose.Slides for Node.js через .NET: добавляйте текстовое поле и слайды, задавайте размер слайда 16:9 и сохраняйте результат в формате PPTX."
---
## **Обзор**

В этой статье показано, как создать презентацию с помощью Aspose.Slides for Node.js via .NET, добавить текстовое поле на первый слайд и сохранить результат в файл PPTX. Также показано, как добавить дополнительные слайды и как переключить презентацию на широкоформатные (16:9) слайды.

Для примеров требуется проект, настроенный согласно инструкции в разделе [Installation](/slides/ru/nodejs-net/installation/). Сохраните каждый пример как файл с расширением `.js` в папке проекта и запустите его из этой папки с помощью `node`, например `node create-presentation.js`.

{{% alert color="info" title="Note" %}}
Aspose.Slides for Node.js via .NET не имеет собственной справки по API. Он отражает API Aspose.Slides for .NET с именами в camelCase, поэтому ссылки на API в этой статье ведут к соответствующим классам и членам в [Aspose.Slides for .NET API reference](https://reference.aspose.com/slides/net/).
{{% /alert %}}

## **Создание презентации с текстовым полем**

Чтобы создать презентацию и разместить текстовое поле на её первом слайде, выполните следующие действия:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/). Новая презентация уже содержит один пустой слайд.  
1. Получите этот слайд из коллекции [slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/slides/). Коллекции в этом пакете читаются методом `get(index)`, индексы начинаются с 0.  
1. Добавьте прямоугольник с помощью метода [addAutoShape](https://reference.aspose.com/slides/net/aspose.slides/shapecollection/addautoshape/) и задайте [text](https://reference.aspose.com/slides/net/aspose.slides/textframe/text/) его [textFrame](https://reference.aspose.com/slides/net/aspose.slides/autoshape/textframe/).  
1. Сохраните презентацию методом [save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) и значением `SaveFormat.Pptx`.  
1. Вызовите `dispose` в блоке `finally`, чтобы освободить .NET‑ресурсы, поддерживающие презентацию.

```javascript
const { Presentation, ShapeType, SaveFormat } = require("aspose.slides.via.net");

const presentation = new Presentation();
try {
    const slide = presentation.slides.get(0);

    // Позиция (x, y) и размер (ширина, высота) указаны в пунктах.
    const textBox = slide.shapes.addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
    textBox.textFrame.text = "Hello, Aspose.Slides!";

    presentation.save("new-presentation.pptx", SaveFormat.Pptx);
    console.log("Saved new-presentation.pptx");
} finally {
    presentation.dispose();
}
```

Скрипт записывает `new-presentation.pptx` в папку проекта. Файл содержит один слайд с заполненным прямоугольником, левый верхний угол которого находится на расстоянии 50 пунктов от левого и верхнего краёв слайда. Прямоугольник имеет ширину 400 пунктов и высоту 100 пунктов, текст в нём центрирован. Один пункт = 1/72 дюйма. Без лицензии Aspose.Slides также добавляет водяной знак оценки к слайду; см. раздел [Licensing](/slides/ru/nodejs-net/licensing/).

## **Добавление слайдов**

Новая презентация содержит один слайд. Чтобы добавить больше, передайте слайд‑макет в метод [addEmptySlide](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/addemptyslide/) коллекции `slides`. Метод [getByType](https://reference.aspose.com/slides/net/aspose.slides/layoutslidecollection/getbytype/) коллекции [layoutSlides](https://reference.aspose.com/slides/net/aspose.slides/presentation/layoutslides/) возвращает первый макет указанного [SlideLayoutType](https://reference.aspose.com/slides/net/aspose.slides/slidelayouttype/).

Следующий пример добавляет два слайда с макетом Blank:

```javascript
const { Presentation, SlideLayoutType, SaveFormat } = require("aspose.slides.via.net");

const presentation = new Presentation();
try {
    const blankLayout = presentation.layoutSlides.getByType(SlideLayoutType.Blank);
    presentation.slides.addEmptySlide(blankLayout);
    presentation.slides.addEmptySlide(blankLayout);

    console.log("Slide count: " + presentation.slides.count);
    presentation.save("three-slides.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Скрипт выводит `Slide count: 3` и записывает `three-slides.pptx`. Новые слайды добавляются после первого и не содержат фигур. Новая презентация всегда имеет макет Blank, но презентация, открытая из файла, может не иметь макета запрошенного типа; в этом случае `getByType` возвращает `null`, поэтому проверьте результат перед дальнейшим использованием.

## **Установка размера слайда**

Новая презентация использует слайды 4:3 размером 720 × 540 пунктов (10 × 7,5 дюйма). Чтобы создать широкоформатные слайды, вызовите метод [setSize](https://reference.aspose.com/slides/net/aspose.slides/slidesize/setsize/) свойства [slideSize](https://reference.aspose.com/slides/net/aspose.slides/presentation/slidesize/) презентации, передав значение [SlideSizeType](https://reference.aspose.com/slides/net/aspose.slides/slidesizetype/) и [SlideSizeScaleType](https://reference.aspose.com/slides/net/aspose.slides/slidesizescaletype/). Тип масштабирования указывает Aspose.Slides, как обращаться с уже существующими на слайдах объектами; `DoNotScale` оставляет их без изменений, что является правильным выбором для презентации без содержимого.

```javascript
const { Presentation, SlideSizeType, SlideSizeScaleType, SaveFormat } = require("aspose.slides.via.net");

const presentation = new Presentation();
try {
    presentation.slideSize.setSize(SlideSizeType.Widescreen, SlideSizeScaleType.DoNotScale);

    const slideSize = presentation.slideSize.size;
    console.log(`Slide size: ${slideSize.width} x ${slideSize.height} points`);

    presentation.save("widescreen.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Скрипт выводит `Slide size: 960 x 540 points`, что соответствует 13,33 × 7,5 дюйма, и записывает `widescreen.pptx`. Значение `SlideSizeType.OnScreen16x9` имеет тот же соотношение сторон 16:9, но меньше: 720 × 405 пунктов.

## **Часто задаваемые вопросы**

**В каких единицах измеряются позиции и размеры?**

В пунктах. Один дюйм = 72 пункта, поэтому слайд 4:3 по умолчанию имеет размеры 720 × 540 пунктов, а широкоформатный слайд 16:9 — 960 × 540 пунктов.

**В какие форматы можно сохранить новую презентацию?**

В любой из форматов, представленных в перечислении [SaveFormat](https://reference.aspose.com/slides/net/aspose.slides.export/saveformat/), например `SaveFormat.Ppt` для PowerPoint 97–2003, `SaveFormat.Odp` для OpenDocument или `SaveFormat.Pdf`. Для вывода в PDF см. раздел [Convert PowerPoint to PDF](/slides/ru/nodejs-net/convert-powerpoint-to-pdf/).

**Почему сохранённая презентация содержит текст «Evaluation only»?**

Без лицензии Aspose.Slides добавляет водяной знак оценки к сохраняемым слайдам. Примените лицензию, как описано в разделе [Licensing](/slides/ru/nodejs-net/licensing/), чтобы убрать его.

**Почему следует вызывать `dispose`?**

Объект `Presentation` опирается на .NET‑объект, который занимает память и другие ресурсы. Вызов `dispose` освобождает их сразу после того, как презентация больше не нужна, а размещение вызова в блоке `finally` гарантирует освобождение ресурсов даже при возникновении ошибки.