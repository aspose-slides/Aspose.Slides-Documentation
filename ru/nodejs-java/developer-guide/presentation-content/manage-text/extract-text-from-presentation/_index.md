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
- получение текста
- получение текста со слайда
- получение текста из презентации
- получение текста из PowerPoint
- получение текста из OpenDocument
- получение текста из PPT
- получение текста из PPTX
- получение текста из ODP
- PowerPoint
- OpenDocument
- презентация
- Node.js
- JavaScript
- Aspose.Slides
description: "Быстро извлекайте текст из презентаций PowerPoint и OpenDocument с помощью Aspose.Slides for Node.js via Java. Следуйте нашему простому пошаговому руководству, чтобы сэкономить время."
---
## **Обзор**

Извлечение текста из презентаций — распространённая, но при этом важная задача для разработчиков, работающих с содержимым слайдов. Независимо от того, имеете ли вы дело с файлами Microsoft PowerPoint в формате PPT или PPTX, или с презентациями OpenDocument (ODP), доступ к текстовым данным и их получение могут быть критически важными для анализа, автоматизации, индексации или миграции контента.

В этой статье представлен подробный руководст­венный материал о том, как эффективно извлекать текст из различных форматов презентаций, включая PPT, PPTX и ODP, с помощью Aspose.Slides for Node.js via Java. Вы узнаете, как систематически переб‑рать элементы презентации, чтобы точно получить нужный текстовый контент.

## **Извлечение текста со слайда**

Aspose.Slides for Node.js via Java предоставляет класс [SlideUtil](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/slideutil/). Этот класс содержит несколько перегруженных статических методов для извлечения всего текста из презентации или слайда. Чтобы извлечь текст со слайда в презентации, используйте метод [getAllTextBoxes](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/slideutil/#getAllTextBoxes-aspose.slides.IBaseSlide-) . Этот метод принимает объект слайда в качестве параметра. При выполнении метод сканирует весь слайд в поиске текста и возвращает массив объектов [TextFrame](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/textframe/), сохраняя любую форматировку текста.

Следующий фрагмент кода извлекает весь текст с первого слайда презентации:

```javascript
const slideIndex = 0;

const presentation = new aspose.slides.Presentation("demo.pptx");
try {
    const slide = presentation.getSlides().get_Item(slideIndex);

    const textFrames = aspose.slides.SlideUtil.getAllTextBoxes(slide);

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

## **Извлечение текста из презентации**

Чтобы просканировать текст во всей презентации, используйте статический метод [getAllTextFrames](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/slideutil/#getAllTextFrames-aspose.slides.IPresentation-boolean-) класса [SlideUtil](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/slideutil/). Он принимает два параметра:

1. Сначала объект [Presentation](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/), представляющий презентацию PowerPoint или OpenDocument, из которой будет извлекаться текст.
1. Затем значение `boolean`, указывающее, следует ли включать мастер‑слайды при сканировании текста презентации.

Метод возвращает массив объектов [TextFrame](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/textframe/), включающий информацию о форматировании текста. Приведённый ниже код сканирует текст и детали форматирования из презентации, включая мастер‑слайды.

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

Аргумент перечисления [TextExtractionArrangingMode](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/textextractionarrangingmode/) определяет режим организации результата извлечения текста и может быть установлен в одно из следующих значений:
- `Unarranged` — необработанный текст без учёта его положения на слайде.
- `Arranged` — текст упорядочен в том же порядке, что и на слайде.

Неупорядоченный режим можно использовать, когда важна скорость; он работает быстрее, чем упорядоченный режим.

[PresentationText](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentationtext/) представляет собой необработанный текст, извлечённый из презентации. Его метод `getSlidesText` возвращает массив объектов, каждый из которых представляет текст соответствующего слайда. Каждый объект текста слайда имеет следующие методы:

- Метод `getText` возвращает текст внутри фигур слайда.
- Метод `getMasterText` возвращает текст внутри фигур мастер‑слайда, связанных с этим слайдом.
- Метод `getLayoutText` возвращает текст внутри фигур шаблона слайда, связанных с этим слайдом.
- Метод `getNotesText` возвращает текст внутри фигур слайда заметок, связанных с этим слайдом.
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

**Насколько быстро Aspose.Slides обрабатывает крупные презентации при извлечении текста?**

Aspose.Slides оптимизирован для высокой производительности и может обрабатывать даже [крупные презентации](/slides/ru/nodejs-java/open-presentation/), что делает его подходящим для сценариев реального времени или массовой обработки.

**Может ли Aspose.Slides извлекать текст из таблиц и диаграмм в презентациях?**

Да. Aspose.Slides может извлекать текст из множества элементов слайда, включая таблицы и объекты, связанные с диаграммами, поэтому вы сможете получать и анализировать текстовое содержимое в типичных структурах презентаций.

**Нужна ли специальная лицензия Aspose.Slides для извлечения текста из презентаций?**

Текст можно извлекать с помощью бесплатной пробной версии Aspose.Slides, однако она имеет [определённые ограничения](/slides/ru/nodejs-java/licensing/), например, обработку только ограниченного количества слайдов. Для неограниченного использования и работы с более крупными презентациями рекомендуется приобрести полную лицензию.