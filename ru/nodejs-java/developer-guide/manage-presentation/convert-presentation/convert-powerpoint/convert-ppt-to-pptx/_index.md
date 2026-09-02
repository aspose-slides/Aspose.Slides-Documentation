---
title: Конвертировать PPT в PPTX в Node.js
linktitle: PPT в PPTX
type: docs
weight: 20
url: /ru/nodejs-java/convert-ppt-to-pptx/
keywords:
- преобразовать PowerPoint
- преобразовать презентацию
- преобразовать слайд
- преобразовать PPT
- PPT в PPTX
- сохранить PPT как PPTX
- экспортировать PPT в PPTX
- PowerPoint
- презентация
- Node.js
- JavaScript
- Aspose.Slides
description: "Конвертировать устаревшие файлы PPT в PPTX в Node.js с помощью Aspose.Slides. Включает примеры JavaScript для конвертации одного файла и пакетной обработки, обработки ошибок и замечаний о точности."
---
## **Обзор**

PPT — это устаревший двоичный формат PowerPoint, тогда как PPTX — более новый формат Open XML. Aspose.Slides for Node.js via Java может загрузить файл PPT и сохранить его как PPTX без Microsoft PowerPoint. В этой статье показано, как конвертировать один файл или каталог файлов и объясняется, что нужно проверить после конвертации.

## **Конвертировать файл PPT в PPTX**

Загрузите исходный файл с помощью класса [Presentation](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/), затем вызовите [Presentation.save](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/#save) с [SaveFormat.Pptx](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/saveformat/). Блок `finally` освобождает презентацию и освобождает её ресурсы.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Загрузить устаревшую PPT-презентацию.
let presentation = new aspose.slides.Presentation("presentation.ppt");
try {
    // Сохранить презентацию в формате PPTX.
    presentation.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Расширение файла само по себе не определяет формат вывода; этим параметром управляет аргумент [SaveFormat.Pptx](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/saveformat/). Держите пути ввода и вывода различными, если необходимо сохранить оригинальный файл PPT.

## **Конвертировать несколько файлов PPT**

Следующий пример конвертирует каждый файл `.ppt` в одном каталоге. Каждый файл обрабатывается независимо, поэтому неудачная конверсия одного файла не останавливает остальную часть пакета.

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

Для производственных задач регистрируйте полную ошибку, решайте, можно ли перезаписать существующий файл вывода, и записывайте имена файлов с ошибками в очередь повторной попытки или проверки. Повреждённые файлы, защищённые паролем файлы, открытые без требуемого пароля, недоступные пути и неподдерживаемый контент могут привести к сбою конверсии. См. [Password-Protected Presentations](/nodejs-java/password-protected-presentation/) для загрузки зашифрованных файлов.

## **Точность и устаревшие функции**

Конверсия обычно сохраняет слайды, мастера, макеты, текст, фигуры, изображения, таблицы и диаграммы. Однако PPT и PPTX не представляют каждую функцию одинаково. Устаревшая функция, которой нет эквивалента в PPTX или которая не поддерживается библиотекой, может быть нормализована, опущена или отображена иначе.

Проверьте сконвертированный файл, если он содержит анимацию, переходы, встроенные или связанные OLE‑объекты, элементы управления ActiveX, встроенные медиа, редкие шрифты или макросы VBA. Обычный файл PPTX не поддерживает макросы, поэтому используйте соответствующий workflow с поддержкой макросов, когда VBA должен оставаться доступным. Также убедитесь, что необходимые шрифты и внешние ресурсы присутствуют в среде, где будет открываться или рендериться конвертированная презентация.

Для важных документов программно откройте сгенерированный PPTX и проверьте количество и содержимое ключевых слайдов, затем сравните его внешний вид и поведение в режиме слайд‑шоу в целевом просмотрщике. Не рассматривайте успешный вызов [Presentation.save](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/#save) как доказательство того, что каждая устаревшая функция имеет точный аналог в PPTX.

## **Когда использовать PPTX**

Используйте PPTX, когда презентацию будут редактировать в современных версиях PowerPoint, обмениваться с системами, работающими с пакетами Open XML, или хранить в формате, который проще анализировать и восстанавливать, чем устаревший бинарный PPT. Сохраняйте оригинальный PPT как архивную или резервную копию, пока конвертированная презентация не пройдет проверки точности.

Если вместо этого нужен PDF, HTML, изображения, XPS или иной тип вывода, используйте рекомендацию для конкретного формата в [Convert Presentations to Multiple Formats](/nodejs-java/convert-presentation/), а не полагайтесь на то, что все цели сохраняют редактируемые функции PowerPoint.

## **Онлайн‑конвертер**

Для отдельного файла или быстрой проверки вы можете воспользоваться [online PPT to PPTX converter](https://products.aspose.app/slides/ru/conversion/ppt-to-pptx). Для повторяющихся конверсий, пакетной обработки или обработки ошибок на уровне приложения используйте API Node.js via Java.

## **Связанные статьи**

- [PPT против PPTX](/nodejs-java/ppt-vs-pptx/)
- [Сохранение презентаций в Node.js](/nodejs-java/save-presentation/)
- [Поддерживаемые форматы файлов](/nodejs-java/supported-file-formats/)
- [Открытие презентаций в Node.js](/nodejs-java/open-presentation/)

## **Часто задаваемые вопросы**

**Могу ли я конвертировать PPT в PPTX без установленного Microsoft PowerPoint?**

Да. Aspose.Slides for Node.js via Java загружает и сохраняет файлы презентаций без необходимости установки Microsoft PowerPoint.

**Сохранит ли конверсия PPT в PPTX весь контент точно?**

Она сохраняет обычный контент презентации, но точная точность не гарантируется для каждой устаревшей или неподдерживаемой функции. Проверьте сгенерированный файл, если в нём есть макросы, OLE‑ или ActiveX‑объекты, медиа, специализированные анимации или редкие шрифты.

**Могу ли я конвертировать защищённый паролем файл PPT?**

Да, если вы укажете правильный пароль при загрузке файла. Отсутствие пароля или неверный пароль приводит к ошибке загрузки.

**Стоит ли удалять файл PPT после конверсии?**

Сохраняйте оригинал, пока не убедитесь, что PPTX прошёл проверку в нужных просмотрщиках и рабочих процессах. Это обеспечивает резервную копию на случай, если устаревшая функция конвертировалась иначе.