---
title: Продвинутое извлечение текста из презентаций на JavaScript
linktitle: Извлечение текста
type: docs
weight: 90
url: /ru/nodejs-java/extract-text-from-presentation/
keywords:
- извлечение текста
- извлечение текста со слайда
- извлечение текста из презентации
- извлечение текста из PowerPoint
- извлечение текста из OpenDocument
- извлечение текста из PPT
- извлечение текста из PPTX
- извлечение текста из ODP
- получить текст
- получить текст со слайда
- получить текст из презентации
- получить текст из PowerPoint
- получить текст из OpenDocument
- получить текст из PPT
- получить текст из PPTX
- получить текст из ODP
- PowerPoint
- OpenDocument
- презентация
- Node.js
- JavaScript
- Aspose.Slides
description: "Быстро извлекайте текст из презентаций PowerPoint и OpenDocument с помощью Aspose.Slides for Node.js via Java. Следуйте нашему простому пошаговому руководству, чтобы сэкономить время."
---
## **Обзор**

Извлечение текста из презентаций — распространённая, но при этом важная задача для разработчиков, работающих с содержимым слайдов. Независимо от того, имеете ли вы дело с файлами Microsoft PowerPoint в форматах PPT или PPTX, или с презентациями OpenDocument (ODP), доступ к текстовым данным может быть критически важным для анализа, автоматизации, индексации или миграции контента.

В этой статье представлен подробный практический гид по эффективному извлечению текста из различных форматов презентаций, включая PPT, PPTX и ODP, с помощью Aspose.Slides for Node.js via Java. Вы узнаете, как систематически обходить элементы презентации, чтобы точно получить нужный текстовый контент.

## **Извлечение текста со слайда**

Aspose.Slides for Node.js via Java предоставляет класс [SlideUtil](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/slideutil/). Этот класс содержит несколько перегруженных статических методов для извлечения всего текста из презентации или слайда. Чтобы извлечить текст со слайда в презентации, используйте метод [getAllTextBoxes](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/slideutil/#getAllTextBoxes-aspose.slides.IBaseSlide-) . Этот метод принимает объект слайда в качестве параметра. При выполнении метод сканирует весь слайд в поиске текста и возвращает массив объектов [TextFrame](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/textframe/), сохраняющих любое форматирование текста.

Следующий фрагмент кода извлекает весь текст с первого слайда презентации:



## **Извлечение текста из презентации**

Чтобы просканировать текст во всей презентации, используйте статический метод [getAllTextFrames](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/slideutil/#getAllTextFrames-aspose.slides.IPresentation-boolean-) класса [SlideUtil](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/slideutil/). Он принимает два параметра:

1. Во‑first, объект [Presentation](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/) , представляющий файл PowerPoint или OpenDocument, из которого будет извлекаться текст.  
2. Во‑second, значение `boolean`, указывающее, следует ли включать мастер‑слайды при сканировании текста презентации.

Метод возвращает массив объектов [TextFrame](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/textframe/), включающих информацию о форматировании текста. Приведённый ниже код сканирует текст и детали форматирования из презентации, включая мастер‑слайды.

```javascript
const presentation = new aspose.slides.Presentation("demo.pptx");
try {
    const includeMasterSlides = true;
    const textFrames = aspose.slides.SlideUtil.getAllTextFrames(presentation, includeMasterSlides);

    for (let textFrameIndex = 0; textFrameIndex < textFrames.length; textFrameIndex++) {
        const textFrame = textFrames[textFrameIndex];

        const paragraphs = textFrame.getParagraphs();
        const paragraphCount = paragraphs.getCount();
        for (let paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++) {
            const paragraph = paragraphs.get_Item(paragraphIndex);

            const portions = paragraph.getPortions();
            const portionCount = portions.getCount();
            for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
                const portion = portions.get_Item(portionIndex);

                const portionText = portion.getText();
                console.log(portionText);

                const portionFormat = portion.getPortionFormat();
                const fontHeight = portionFormat.getFontHeight();
                console.log(fontHeight);

                const latinFont = portionFormat.getLatinFont();
                if (latinFont !== null) {
                    const fontName = latinFont.getFontName();
                    console.log(fontName);
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Категоризованное и быстрое извлечение текста**

Класс [PresentationFactory](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentationfactory/) также предоставляет методы для извлечения всего текста из презентаций:

```javascript
PresentationText getPresentationText(String file, int mode);
PresentationText getPresentationText(InputStream stream, int mode);
PresentationText getPresentationText(InputStream stream, int mode, LoadOptions options);
```

Аргумент‑перечисление [TextExtractionArrangingMode](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/textextractionarrangingmode/) указывает режим организации результата извлечения текста и может принимать следующие значения:
- `Unarranged` – Неотформатированный текст без учёта его положения на слайде.  
- `Arranged` – Текст упорядочен в том же порядке, что и на слайде.

Неотформатированный режим можно использовать, когда важна скорость; он быстрее, чем упорядоченный режим.

[PresentationText](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentationtext/) представляет собой сырой текст, извлечённый из презентации. Его метод `getSlidesText` возвращает массив объектов, каждый из которых представляет текст соответствующего слайда. У каждого объекта текста слайда есть следующие методы:

- Метод `getText` возвращает текст внутри фигур слайда.  
- Метод `getMasterText` возвращает текст внутри фигур мастер‑слайда, связанного с этим слайдом.  
- Метод `getLayoutText` возвращает текст внутри фигур макета слайда, связанного с этим слайдом.  
- Метод `getNotesText` возвращает текст внутри фигур слайда заметок, связанного с этим слайдом.  
- Метод `getCommentsText` возвращает текст внутри комментариев, связанных с этим слайдом.

```javascript
const presentationPath = "presentation.ppt";
const arrangingMode = aspose.slides.TextExtractionArrangingMode.Unarranged;
const presentationText = aspose.slides.PresentationFactory.getInstance().getPresentationText(presentationPath, arrangingMode);
const firstSlideText = presentationText.getSlidesText()[0];

console.log(firstSlideText.getText());
console.log(firstSlideText.getLayoutText());
console.log(firstSlideText.getMasterText());
console.log(firstSlideText.getNotesText());
console.log(firstSlideText.getCommentsText());
```

## **FAQ**

**Насколько быстро Aspose.Slides обрабатывает большие презентации при извлечении текста?**

Aspose.Slides оптимизирован для высокой производительности и способен обрабатывать даже [большие презентации](/slides/ru/nodejs-java/open-presentation/), что делает его подходящим для сценариев реального времени или массовой обработки.

**Может ли Aspose.Slides извлекать текст из таблиц и диаграмм в презентациях?**

Да. Aspose.Slides может извлекать текст из множества элементов слайдов, включая таблицы и объекты, связанные с диаграммами, что позволяет получать и анализировать текстовое содержание в типовых структурах презентаций.

**Нужна ли специальная лицензия Aspose.Slides для извлечения текста из презентаций?**

Вы можете