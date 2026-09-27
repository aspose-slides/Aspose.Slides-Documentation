---
title: Управление текстом презентации в Node.js через .NET
linktitle: Управление текстом
type: docs
weight: 50
url: /ru/nodejs-net/manage-text/
keywords:
- текст
- текстовое поле
- добавить текст
- изменить текст
- форматировать текст
- размер шрифта
- полужирный текст
- текстовый кадр
- абзац
- фрагмент
- PowerPoint
- презентация
- Node.js
- JavaScript
- Aspose.Slides
description: "Добавьте текстовое поле на слайд, затем измените его текст, размер шрифта и полужирное начертание в JavaScript с помощью Aspose.Slides for Node.js via .NET."
---
## **Обзор**

В Aspose.Slides текст на слайде принадлежит фигуре. Автофигура, например прямоугольник, имеет текстовый кадр; в текстовом кадре находятся абзацы, а каждый абзац содержит фрагменты — участки текста с одинаковым форматированием. Текст изменяется через текстовый кадр, а шрифт — через формат фрагмента.

В этой статье добавляется текстовое поле на слайд и сохраняется презентация. Затем открывается сохранённый файл и изменяются текст, размер шрифта и полужирное начертание текстового поля.

Для примеров нужен проект, настроенный согласно [Installation](/slides/ru/nodejs-net/installation/). Сохраните каждый пример как файл с расширением `.js` в папке проекта и запустите его из этой папки командой `node`.

{{% alert color="info" title="Note" %}}
Aspose.Slides for Node.js via .NET не имеет собственной справки по API. Он отражает API Aspose.Slides for .NET с именами в camelCase, поэтому ссылки на API в этой статье ведут к соответствующим классам и членам в [Aspose.Slides for .NET API reference](https://reference.aspose.com/slides/ru/net/).
{{% /alert %}}

## **Добавить текстовое поле**

Чтобы добавить текстовое поле, добавьте автофигуру на слайд с помощью метода [addAutoShape](https://reference.aspose.com/slides/ru/net/aspose.slides/shapecollection/addautoshape/) и задайте ей текст методом [addTextFrame](https://reference.aspose.com/slides/ru/net/aspose.slides/autoshape/addtextframe/). В следующем примере к первому слайду новой презентации добавляется прямоугольник и презентация сохраняется как `text-box.pptx`:

```javascript
const { Presentation, ShapeType, SaveFormat } = require("aspose.slides.via.net");

const presentation = new Presentation();
try {
    const slide = presentation.slides.get(0);

    // Позиция (x, y) и размер (ширина, высота) задаются в пунктах.
    const textBox = slide.shapes.addAutoShape(ShapeType.Rectangle, 100, 100, 500, 80);
    textBox.addTextFrame("Quarterly report");

    presentation.save("text-box.pptx", SaveFormat.Pptx);
    console.log("Saved text-box.pptx");
} finally {
    presentation.dispose();
}
```

Слайд в `text-box.pptx` содержит прямоугольник шириной 500 пунктов и высотой 80 пунктов с текстом «Quarterly report» шрифтом и размером по умолчанию. Следующий пример изменяет это текстовое поле.

## **Изменить текст и его форматирование**

В следующем примере открывается `text-box.pptx`, созданный в предыдущем примере, и получает первая фигура на первом слайде. Такие фигуры, как изображения и таблицы, не имеют текстового кадра, поэтому пример проверяет, что фигура является [AutoShape](https://reference.aspose.com/slides/ru/net/aspose.slides/autoshape/) перед тем как использовать её свойство [textFrame](https://reference.aspose.com/slides/ru/net/aspose.slides/autoshape/textframe/). Затем он делает следующее:

1. Заменяет текст через свойство [text](https://reference.aspose.com/slides/ru/net/aspose.slides/textframe/text/) текстового кадра. После этого в текстовом кадре оказывается один абзац с одним фрагментом.
2. Получает этот фрагмент из коллекций [paragraphs](https://reference.aspose.com/slides/ru/net/aspose.slides/textframe/paragraphs/) и [portions](https://reference.aspose.com/slides/ru/net/aspose.slides/paragraph/portions/), а затем читает его [portionFormat](https://reference.aspose.com/slides/ru/net/aspose.slides/portion/portionformat/).
3. Устанавливает [fontHeight](https://reference.aspose.com/slides/ru/net/aspose.slides/baseportionformat/fontheight/), размер шрифта в пунктах, и [fontBold](https://reference.aspose.com/slides/ru/net/aspose.slides/baseportionformat/fontbold/), которому присваивается значение типа [NullableBool](https://reference.aspose.com/slides/ru/net/aspose.slides/nullablebool/).

```javascript
const { Presentation, AutoShape, NullableBool, SaveFormat } = require("aspose.slides.via.net");

const presentation = new Presentation("text-box.pptx");
try {
    const shape = presentation.slides.get(0).shapes.get(0);
    if (shape instanceof AutoShape) {
        const textFrame = shape.textFrame;
        textFrame.text = "Quarterly report: third quarter";

        const portionFormat = textFrame.paragraphs.get(0).portions.get(0).portionFormat;
        portionFormat.fontHeight = 32;
        portionFormat.fontBold = NullableBool.True;

        presentation.save("text-box-updated.pptx", SaveFormat.Pptx);
        console.log("Saved text-box-updated.pptx");
    } else {
        console.log("The first shape on the first slide is not an AutoShape.");
    }
} finally {
    presentation.dispose();
}
```

В `text-box-updated.pptx` текстовое поле отображает «Quarterly report: third quarter» полужирным шрифтом размером 32 пункта. Поскольку новый текст представляет собой один фрагмент, оба свойства форматирования применяются ко всему тексту. Без лицензии каждый сохранённый файл получает водяной знак оценки. Поскольку `text-box.pptx` также был сохранён в режиме оценки, в `text-box-updated.pptx` их два; см. [Evaluate Aspose.Slides](/slides/ru/nodejs-net/evaluate-aspose-slides/).

## **FAQ**

**Почему `fontBold` принимает значение `NullableBool`, а не `true` или `false`?**

Фрагмент может оставить свойство неопределённым и унаследовать его от абзаца, фигуры или макета и мастера слайда. `NullableBool.NotDefined` означает «унаследовать», а `NullableBool.True` и `NullableBool.False` переопределяют унаследованное значение. Присваивание `true` или `false` вызывает ошибку. По той же причине `fontHeight` возвращает `NaN`, когда фрагмент наследует размер шрифта.

**Как изменить цвет текста?**

Задайте заливку формата фрагмента: присвойте `FillType.Solid` свойству `portionFormat.fillFormat.fillType`, а затем задайте цвет, например `"#FF0000"`, свойству `portionFormat.fillFormat.solidFillColor.color`. Добавьте `FillType` в список импортируемых имен из пакета.

**Как отформатировать только часть текста?**

Форматирование относится к фрагментам, поэтому поместите нужную часть текста в отдельный фрагмент. Создайте фрагмент с помощью `Portion.CreatePortionFromText`, добавьте его в абзац методом `add` коллекции `portions` абзаца и затем задайте новый `portionFormat`. Добавьте `Portion` в список импортируемых имен из пакета.

**Почему при чтении текста появляется сообщение «... text has been truncated due to evaluation version limitation»?**

Без лицензии Aspose.Slides возвращает только первые пять символов любого более длинного текста, который вы читаете, например `textFrame.text`, после чего добавляется это предупреждение. Текст, который вы записываете, сохраняется полностью. Примените лицензию, как описано в разделе [Licensing](/slides/ru/nodejs-net/licensing/), чтобы читать полный текст.