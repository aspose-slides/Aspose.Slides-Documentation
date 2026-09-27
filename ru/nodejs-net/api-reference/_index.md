---
title: Справка по API
type: docs
weight: 50
url: /ru/nodejs-net/api-reference/
description: "Aspose.Slides for Node.js via .NET документируется справкой по API Aspose.Slides for .NET. Смотрите, как имена классов и членов .NET отображаются в JavaScript."
---
## **Обзор**

Aspose.Slides for Node.js via .NET не имеет собственной справки по API. Пакет экспортирует классы Aspose.Slides for .NET в JavaScript под теми же именами, с именами членов в camelCase, поэтому [справка по API Aspose.Slides for .NET](https://reference.aspose.com/slides/net/) содержит описание его классов, членов и перечислений.

## **Сопоставление имен .NET с JavaScript**

Чтобы использовать член, найденный в справке по API .NET, применяйте следующие правила:

- **Классы и перечисления сохраняют свои .NET‑имена**, как и значения перечислений: `Presentation`, `ShapeType.Rectangle`, `SaveFormat.Pdf`. Импортируйте их из пакета: `const { Presentation, SaveFormat } = require("aspose.slides.via.net");`.
- **Свойства и методы начинаются со строчной буквы.** `Presentation.Slides` становится `presentation.slides`, а `ShapeCollection.AddAutoShape` — `shapes.addAutoShape`. Свойства остаются свойствами: их читают и присваивают без скобок.
- **Элементы коллекций читаются с помощью `get(index)`**, а количество элементов — через `count`: `presentation.slides.get(0)` вместо `presentation.Slides[0]`.
- **Некоторые перегрузки получают отдельные имена.** Например, перегрузка `Slide.GetImage(Size)` имеет название `slide.getImageWithImageSize({ width, height })`. Другие используют один метод с необязательными конечными аргументами: `presentation.save(path, format, options, slides)` охватывает несколько перегрузок `Presentation.Save`, а `new Presentation(null, buffer)` открывает презентацию из `Buffer`. Каждый класс располагается в отдельном файле в папке `lib` пакета (например, `node_modules/aspose.slides.via.net/lib/Slide.js`), где можно посмотреть точные имена.
- **Освобождайте презентации с помощью `dispose`**, когда они больше не нужны; в JavaScript нет оператора `using`.

Пакет не оборачивает каждый член .NET. Если член из справки по API .NET отсутствует в файле класса, он недоступен в JavaScript.

## **Пример**

Следующий скрипт использует указанные выше правила. Каждый комментарий показывает вызов .NET, которому соответствует следующая строка. Он добавляет прямоугольник с текстом на первый слайд, рендерит слайд как PNG‑изображение размером 960 × 540 пикселей и сохраняет презентацию в PDF. Запустите его из папки проекта, где пакет установлен согласно [Установка](/slides/ru/nodejs-net/installation/).

```javascript
const asposeSlides = require("aspose.slides.via.net");
const { Presentation, ShapeType, SaveFormat, ImageFormat } = asposeSlides;

const presentation = new Presentation();
try {
    // .NET: presentation.Slides[0]
    const slide = presentation.slides.get(0);

    // .NET: slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 100)
    const rectangle = slide.shapes.addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);

    // .NET: rectangle.TextFrame.Text = "..."
    rectangle.textFrame.text = "Names follow the .NET API in camelCase.";

    // .NET: slide.GetImage(new Size(960, 540))
    const slideImage = slide.getImageWithImageSize({ width: 960, height: 540 });
    slideImage.save("slide.png", ImageFormat.Png);
    slideImage.dispose();

    // .NET: presentation.Save("slide.pdf", SaveFormat.Pdf)
    presentation.save("slide.pdf", SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

Скрипт записывает `slide.png` и `slide.pdf` в текущую папку. Оба файла отображают прямоугольник с его текстом. Без лицензии они также содержат водяной знак оценки; см. [Лицензирование](/slides/ru/nodejs-net/licensing/).

Для получения подробной информации о используемых здесь членах, смотрите [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/), [ShapeCollection.AddAutoShape](https://reference.aspose.com/slides/net/aspose.slides/shapecollection/addautoshape/), [TextFrame.Text](https://reference.aspose.com/slides/net/aspose.slides/textframe/text/) и [Slide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage/) в справке по API Aspose.Slides for .NET.