---
title: Прерывание длительных операций с презентациями в Node.js
linktitle: Прерывание операций с презентациями
type: docs
weight: 120
url: /ru/nodejs-java/support-for-interruptable-library/
keywords:
- прерываемые операции
- токен прерывания
- токен отмены
- тайм‑аут конвертации
- PowerPoint
- OpenDocument
- Node.js
- JavaScript
- Aspose.Slides
description: "Отмените длительные операции с презентациями в Aspose.Slides для Node.js через Java, установите тайм‑аут конвертации и отслеживайте слайды, экспортированные до отмены."
---
## **Обзор**

Aspose.Slides for Node.js via Java поддерживает отмену при загрузке, сохранении или рендеринге презентации. Вы также можете проверять тот же токен в собственном цикле экспорта, чтобы остановиться перед следующим слайдом и вернуть номера уже сохранённых слайдов.

## **Прервать операцию с презентацией**

Создайте [InterruptionTokenSource](https://reference.aspose.com/slides/nodejs-java/aspose.slides/interruptiontokensource/), получите его токен с помощью [getToken](https://reference.aspose.com/slides/nodejs-java/aspose.slides/interruptiontokensource/#getToken) и передайте его в [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/#setInterruptionToken). Используйте эти параметры при создании [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/). Вызов [interrupt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/interruptiontokensource/#interrupt) у источника запрашивает отмену текущей операции. Aspose.Slides останавливается, когда в следующий раз проверит токен.

### **Установить тайм‑аут конвертации**

Следующий пример даёт 20 секунд на открытие `sample.pptx` и сохранение его как `sample.pdf`. Как конструктор, так и сохранение выполняются асинхронно через Java‑мост, поэтому таймер Node.js может сработать во время любой из операций. Пример проверяет токен после загрузки и снова после сохранения, поскольку вызов библиотеки может вернуть управление после запроса отмены. Он освобождает презентацию, когда операция завершается, и очищает таймер, если конвертация заканчивается раньше. Если отмена происходит во время сохранения, выходной файл может уже существовать и быть неполным.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");
const { promisify } = require("node:util");

async function convertWithTimeout(inputPath, outputPath, format, timeoutMs) {
    const source = new slides.InterruptionTokenSource();
    const options = new slides.LoadOptions();
    const token = source.getToken();
    options.setInterruptionToken(token);
    const createInstance = promisify(java.newInstance.bind(java));
    const timer = setTimeout(() => source.interrupt(), timeoutMs);
    let presentation = null;
    try {
        presentation = await createInstance("com.aspose.slides.Presentation", inputPath, options);
        token.throwIfInterruptionRequested();
        const save = promisify(presentation.saveAsync.bind(presentation));
        await save(outputPath, format);
        token.throwIfInterruptionRequested();
        console.log("Conversion completed");
    } catch (error) {
        if (error.cause?.getClass().getName() !== "com.aspose.slides.exceptions.OperationCanceledException") {
            throw error;
        }
        console.log("Conversion canceled");
    } finally {
        clearTimeout(timer);
        if (presentation) {
            presentation.dispose();
        }
    }
}

convertWithTimeout("sample.pptx", "sample.pdf", slides.SaveFormat.Pdf, 20000).catch(error => {
    console.error(error);
    process.exitCode = 1;
});
```

Чтобы конвертировать в более старый формат PowerPoint с лимитом в 10 секунд, передайте `"sample.ppt"`, `slides.SaveFormat.Ppt` и `10000` в качестве последних трёх аргументов.

## **Остановить перед обработкой следующего слайда**

Используйте [isInterruptionRequested](https://reference.aspose.com/slides/nodejs-java/aspose.slides/interruptiontoken/#isInterruptionRequested) перед каждой экспортной операцией, когда вызывающий может использовать частичный результат. Перегрузка [save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#save) для выбранных слайдов принимает Java‑массив `int[]` номеров слайдов, нумерация начинается с 1. Записывайте каждый номер только после успешного сохранения его PDF.

Запустите пример с презентацией под названием `sample.pptx`, содержащей как минимум два слайда. Чтобы продемонстрировать отмену между экспортами, пример запрашивает её сразу после сохранения первого слайда.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

function exportSlides(path, source) {
    const completed = [];
    const token = source.getToken();
    const options = new slides.LoadOptions();
    options.setInterruptionToken(token);
    const presentation = new slides.Presentation(path, options);
    try {
        const count = presentation.getSlides().size();
        for (let number = 1; number <= count; number++) {
            if (token.isInterruptionRequested()) {
                break;
            }

            console.log("Starting slide " + number);
            const selection = java.newArray("int", [number]);
            try {
                presentation.save("slide-" + number + ".pdf", selection, slides.SaveFormat.Pdf);
            } catch (error) {
                if (error.cause?.getClass().getName() === "com.aspose.slides.exceptions.OperationCanceledException") {
                    break;
                }
                throw error;
            }

            if (token.isInterruptionRequested()) {
                break;
            }
            completed.push(number);
            if (number === 1) {
                source.interrupt();
            }
        }
        return completed;
    } finally {
        presentation.dispose();
    }
}

const source = new slides.InterruptionTokenSource();
const completed = exportSlides("sample.pptx", source);
console.log("Completed: " + JSON.stringify(completed));
```

Пример записывает `slide-1.pdf` и выводит `Starting slide 1`, а затем `Completed: [1]`. Цикл обнаруживает отмену перед началом второго слайда. Если сохранение прерывается, возвращаемый список содержит только ранее успешно экспортированные файлы.

Чтобы позволить вызывающему обработать отмену как ошибку, замените проверку и её `break` в начале цикла на [throwIfInterruptionRequested](https://reference.aspose.com/slides/nodejs-java/aspose.slides/interruptiontoken/#throwIfInterruptionRequested), вызывая `token.throwIfInterruptionRequested()`. Используйте ту же проверку после сохранения и уберите `try`/`catch` вокруг неё. При том же входе первый PDF всё равно будет записан, а вторая итерация бросит исключение до того, как функция вернёт список.

## **FAQ**

**Когда следует запрашивать отмену?**

Запрашивайте отмену, когда истекает срок или приложение больше не нуждается в результате. Загрузка, сохранение и рендеринг могут использовать токен, переданный презентации при её создании.

**В чём разница между источником и токеном?**

Источник позволяет приложению запросить отмену. Токен позволяет Aspose.Slides и вашему коду проверять наличие такого запроса.

**Может ли таймер Node.js прервать синхронное сохранение?**

Синхронное сохранение блокирует JavaScript в вызывающем потоке. Используйте асинхронные вызовы Java‑моста, показанные в примере с тайм‑аутом, чтобы таймер мог запросить отмену во время выполнения сохранения.

**Вступает ли отмена в силу сразу?**

Отмена кооперативна. Запущенная операция останавливается, когда обнаруживает запрос. Операция, уже завершившаяся, сохраняет свой результат.

**Могут ли несколько операций использовать один источник?**

Да. Вызов `interrupt()` запрашивает отмену для каждой операции, использующей токен из этого источника. Создайте отдельный источник для каждой операции, которую нужно отменять независимо.