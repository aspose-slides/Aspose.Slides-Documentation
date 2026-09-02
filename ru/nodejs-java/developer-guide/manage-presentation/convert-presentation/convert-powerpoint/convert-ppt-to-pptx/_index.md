---
title: Конвертировать PPT в PPTX в Node.js
linktitle: PPT в PPTX
type: docs
weight: 20
url: /ru/nodejs-java/convert-ppt-to-pptx/
keywords:
- конвертировать PowerPoint
- конвертировать презентацию
- конвертировать слайд
- конвертировать PPT
- PPT в PPTX
- сохранить PPT как PPTX
- экспортировать PPT в PPTX
- PowerPoint
- презентация
- Node.js
- JavaScript
- Aspose.Slides
description: "Конвертировать устаревшие файлы PPT в PPTX в Node.js с помощью Aspose.Slides. Включает примеры JavaScript для конвертации одного файла и пакетной обработки, обработки ошибок и примечаний о точности."
---
## **Обзор**

PPT — это устаревший бинарный формат PowerPoint, тогда как PPTX — более новый формат Open XML. Aspose.Slides for Node.js via Java может загрузить файл PPT и сохранить его как PPTX без Microsoft PowerPoint. В этой статье показано, как конвертировать один файл или каталог файлов и объясняется, что проверять после конвертации.

## **Конвертировать файл PPT в PPTX**

Загрузите исходный файл с помощью класса [Presentation](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/) , затем вызовите [Presentation.save](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/#save) с аргументом [SaveFormat.Pptx](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/saveformat/) . Блок `finally` освобождает презентацию и её ресурсы.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Загрузить устаревшую PPT презентацию.
let presentation = new aspose.slides.Presentation("presentation.ppt");
try {
    // Сохранить презентацию в формате PPTX.
    presentation.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Расширение файла само по себе не определяет формат вывода; это делает аргумент [SaveFormat.Pptx](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/saveformat/) . Сохраняйте разные пути входного и выходного файлов, если необходимо сохранить оригинальный файл PPT.

## **Конвертировать несколько файлов PPT**

Следующий пример конвертирует каждый файл `.ppt` в одном каталоге. Каждый файл обрабатывается независимо, поэтому ошибка при конвертации одного файла не останавливает остальную часть пакета.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const fs = require("fs");
const path = require("path");

const inputDirectory = "input";
const outputDirectory = "output";
fs.mkdirSync(outputDirectory, { recursive: true });

const inputFiles = fs.readdirSync(inputDirectory, { withFileTypes: true })
    .filter(entry => entry.isFile() && path.extname(entry.name).toLowerCase() === ".ppt")
    .map(entry => entry.name);

for (const fileName of inputFiles) {
    const inputPath = path.join(inputDirectory, fileName);
    const outputFileName = path.basename(fileName, path.extname(fileName)) + ".pptx";
    const outputPath = path.join(outputDirectory, outputFileName);
    let presentation = null;

    try {
        presentation = new aspose.slides.Presentation(inputPath);
        presentation.save(outputPath, aspose.slides.SaveFormat.Pptx);
        console.log("Converted: " + inputPath);
    } catch (error) {
        console.error("Failed: " + inputPath + " (" + error.message + ")");
    } finally {
        if (presentation !== null) {
            presentation.dispose();
        }
    }
}
```

Для производственных задач записывайте полную ошибку в журнал, решайте, можно ли перезаписать существующий выходной файл, и записывайте имена файлов с ошибками в очередь повторных попыток или проверки. Повреждённые файлы, защищённые паролем файлы, открытые без необходимого пароля, недоступные пути и неподдерживаемый контент могут привести к сбою конвертации. См. [Password-Protected Presentations](/slides/ru/nodejs-java/password-protected-presentation/) для загрузки зашифрованных файлов.

## **Точность и устаревшие функции**

Конвертация обычно сохраняет слайды, шаблоны, макеты, текст, фигуры, изображения, таблицы и диаграммы. Однако PPT и PPTX не представляют каждую функцию одинаково. Устаревшая функция, не имеющая эквивалента в PPTX или не поддерживаемая библиотекой, может быть нормализована, опущена или отображена иначе.

Проверьте конвертированный файл, если в нём есть анимации, переходы, внедрённые или связанные объекты OLE, элементы управления ActiveX, встроенные медиа, редкие шрифты или макросы VBA. Обычный файл PPTX не поддерживает макросы, поэтому используйте соответствующий процесс работы с макросами, если VBA должен оставаться доступным. Также убедитесь, что необходимые шрифты и внешние ресурсы присутствуют в среде, где будет открываться или отображаться конвертированная презентация.

Для важных документов откройте сгенерированный PPTX программно и проверьте количество ключевых слайдов и их содержимое, затем сравните его внешний вид и поведение в режиме слайд‑шоу в целевом просмотрщике. Не рассматривайте успешный вызов [Presentation.save](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/#save) как доказательство того, что каждая устаревшая функция имеет точный эквивалент в PPTX.

## **Когда использовать PPTX**

Используйте PPTX, когда презентацию будут редактировать в современных версиях PowerPoint, обмениваться с системами, работающими с пакетами Open XML, или сохранять в формате, который легче исследовать и восстанавливать, чем устаревший бинарный PPT. Сохраняйте оригинальный PPT как архивную или резервную копию, пока конвертированная презентация не пройдет проверку точности.

Если вам нужен вместо этого PDF, HTML, изображения, XPS или другой тип вывода, используйте руководство по конкретному формату в [Convert Presentations to Multiple Formats](/slides/ru/nodejs-java/convert-presentation/), а не предполагайте, что все целевые форматы сохраняют редактируемые функции PowerPoint.

## **Онлайн‑конвертер**

Для отдельного файла или быстрой сравнения вы можете воспользоваться [online PPT to PPTX converter](https://products.aspose.app/slides/ru/conversion/ppt-to-pptx) . Для повторяющихся конвертаций, пакетной обработки или обработки ошибок на уровне приложения используйте API Node.js via Java.

## **Связанные статьи**

- [PPT vs PPTX](/slides/ru/nodejs-java/ppt-vs-pptx/)
- [Save Presentations in Node.js](/slides/ru/nodejs-java/save-presentation/)
- [Supported File Formats](/slides/ru/nodejs-java/supported-file-formats/)
- [Open Presentations in Node.js](/slides/ru/nodejs-java/open-presentation/)

## **FAQ**

**Могу ли я конвертировать PPT в PPTX без установленного Microsoft PowerPoint?**

Да. Aspose.Slides for Node.js via Java загружает и сохраняет файлы презентаций без необходимости в Microsoft PowerPoint.

**Сохранит ли конвертация PPT в PPTX весь контент точно?**

Она сохраняет обычный контент презентации, но точная точность не гарантируется для каждой устаревшей или неподдерживаемой функции. Просмотрите сгенерированный файл, если в нём есть макросы, объекты OLE или ActiveX, медиа, специализированные анимации или редкие шрифты.

**Могу ли я конвертировать защищённый паролем файл PPT?**

Да, если при загрузке файла указать правильный пароль. Отсутствие пароля или неверный пароль приводит к сбою загрузки.

**Должен ли я удалить файл PPT после конвертации?**

Сохраняйте оригинал, пока не проверите PPTX в нужных просмотрщиках и рабочих процессах. Это обеспечивает резервную копию на случай, если устаревшая функция конвертируется иначе.