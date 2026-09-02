---
title: Получить и обновить информацию о презентации на JavaScript
linktitle: Информация о презентации
type: docs
weight: 30
url: /ru/nodejs-java/examine-presentation/
keywords:
- формат презентации
- свойства презентации
- свойства документа
- получить свойства
- чтение свойств
- изменение свойств
- модификация свойств
- обновление свойств
- анализ PPTX
- анализ PPT
- анализ ODP
- PowerPoint
- OpenDocument
- презентация
- Node.js
- JavaScript
- Aspose.Slides
description: "Изучайте слайды, структуру и метаданные в презентациях PowerPoint и OpenDocument с помощью JavaScript для более быстрых инсайтов и умных аудитов контента."
---
## **Обзор**

Aspose.Slides может определить формат презентации и считать метаданные документа без создания полной модели объекта презентации. Это полезно, когда необходимо классифицировать файлы, собрать инвентарь или проверить свойства до принятия решения о загрузке и обработке содержимого презентации.

В этой статье демонстрируется лёгкая проверка с помощью [PresentationFactory](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentationfactory/) и [PresentationInfo](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentationinfo/), а также целевые обновления через [DocumentProperties](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/documentproperties/).

## **Проверка формата презентации**

Используйте [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentationfactory/getpresentationinfo/) для инспекции файла без создания экземпляра [Presentation](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/). Метод [PresentationInfo.getLoadFormat](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentationinfo/getloadformat/) сообщает обнаруженный формат, например PPTX, PPT или ODP.

```javascript
const aspose = require("aspose.slides.via.java");

const fileNames = ["pres.pptx", "pres.ppt", "pres.odp"];

for (const fileName of fileNames) {
    const presentationInfo = aspose.PresentationFactory.getInstance().getPresentationInfo(fileName);
    const loadFormat = presentationInfo.getLoadFormat();
    let formatName = `Other (${loadFormat})`;

    if (loadFormat === aspose.LoadFormat.Pptx) {
        formatName = "PPTX";
    } else if (loadFormat === aspose.LoadFormat.Ppt) {
        formatName = "PPT";
    } else if (loadFormat === aspose.LoadFormat.Odp) {
        formatName = "ODP";
    }

    console.log(`${fileName}: ${formatName}`);
}
```

## **Создание лёгкого инвентаря презентаций**

При обработке большого количества файлов презентаций может потребоваться компактный инвентарь для проверки, индексирования или системы управления документами. В этом случае используйте [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentationfactory/getpresentationinfo/) для получения объекта [PresentationInfo](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentationinfo/), а затем вызовите [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentationinfo/readdocumentproperties/) для чтения метаданных документа. Такой подход не создаёт экземпляр [Presentation](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/) и не требует обхода полной модели объекта презентации.

Расширенные свойства, предоставляемые [DocumentProperties](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/documentproperties/), дают следующие значения инвентаря:

| Метод | Значение инвентаря |
| --- | --- |
| [getSlides](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/documentproperties/#getSlides) | Общее количество слайдов. |
| [getHiddenSlides](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/documentproperties/#getHiddenSlides) | Количество скрытых слайдов. |
| [getNotes](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/documentproperties/#getNotes) | Количество слайдов, содержащих заметки. |
| [getParagraphs](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/documentproperties/#getParagraphs) | Общее количество абзацев, если доступно. |
| [getWords](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/documentproperties/#getWords) | Общее количество слов. |
| [getMultimediaClips](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/documentproperties/#getMultimediaClips) | Общее количество аудио‑ и видеоклипов. |

Ниже приведён пример, который считывает эти значения без создания объекта [Presentation](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/) и выводит компактный инвентарь. Он также сочетает [DocumentProperties.getHeadingPairs](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/documentproperties/#getHeadingPairs) с [DocumentProperties.getTitlesOfParts](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/documentproperties/#getTitlesOfParts) для отображения групп содержимого, таких как шрифты, темы и заголовки слайдов.

```javascript
const path = require("path");
const aspose = require("aspose.slides.via.java");

const filePath = "sample.pptx";
const presentationInfo = aspose.PresentationFactory.getInstance().getPresentationInfo(filePath);
const documentProperties = presentationInfo.readDocumentProperties();

const loadFormat = presentationInfo.getLoadFormat();
let formatName = `Other (${loadFormat})`;

if (loadFormat === aspose.LoadFormat.Pptx) {
    formatName = "PPTX";
} else if (loadFormat === aspose.LoadFormat.Ppt) {
    formatName = "PPT";
} else if (loadFormat === aspose.LoadFormat.Odp) {
    formatName = "ODP";
}

console.log(`File: ${path.basename(filePath)}`);
console.log(`Format: ${formatName}`);
console.log(`Title: ${documentProperties.getTitle()}`);
console.log(`Author: ${documentProperties.getAuthor()}`);
console.log("Statistics:");
console.log(`  Slides: ${documentProperties.getSlides()}`);
console.log(`  Hidden slides: ${documentProperties.getHiddenSlides()}`);
console.log(`  Slides with notes: ${documentProperties.getNotes()}`);
console.log(`  Paragraphs: ${documentProperties.getParagraphs()}`);
console.log(`  Words: ${documentProperties.getWords()}`);
console.log(`  Multimedia clips: ${documentProperties.getMultimediaClips()}`);

const headingPairs = documentProperties.getHeadingPairs() || [];
const titlesOfParts = documentProperties.getTitlesOfParts() || [];
let partIndex = 0;

if (headingPairs.length === 0 || titlesOfParts.length === 0) {
    console.log("Content groups: not available");
} else {
    console.log("Content groups:");

    for (const headingPair of headingPairs) {
        const partCount = headingPair.getCount();
        console.log(`  ${headingPair.getName()} (${partCount})`);

        for (let partOffset = 0; partOffset < partCount && partIndex < titlesOfParts.length; partOffset++) {
            console.log(`    - ${titlesOfParts[partIndex]}`);
            partIndex++;
        }
    }

    if (partIndex < titlesOfParts.length) {
        console.log("  Other parts:");

        while (partIndex < titlesOfParts.length) {
            console.log(`    - ${titlesOfParts[partIndex]}`);
            partIndex++;
        }
    }
}
```

Каждый [HeadingPair](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/headingpair/) предоставляет имя группы через [HeadingPair.getName](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/headingpair/#getName) и количество элементов в этой группе через [HeadingPair.getCount](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/headingpair/#getCount). [DocumentProperties.getTitlesOfParts](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/documentproperties/#getTitlesOfParts) возвращает плоский упорядоченный массив, поэтому потребляйте число последовательных заголовков, указанных каждой парой заголовков.

### **Хранимые метаданные и ограничения формата**

Свойства инвентаря, возвращаемые [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentationinfo/readdocumentproperties/), отражают метаданные, доступные в исходном документе. Aspose.Slides не загружает и не обходит модель объекта презентации для пересчёта этих значений при данном вызове. Отсутствующие свойства представлены значениями по умолчанию, а сохранённые значения могут быть устаревшими, если приложение, последним сохранившее файл, не обновило свойства документа.

- **PPTX:** Формат предоставляет расширенные свойства документа для счётчиков слайдов, заметок, скрытых слайдов, абзацев, слов и мультимедиа, а также пары заголовков и названия частей. Доступность зависит от того, какие свойства были записаны создателем документа.
- **PPT:** Бинарный формат может хранить соответствующие свойства‑резюме документа. Если свойство отсутствует или не было обновлено создателем документа, Aspose.Slides возвращает его сохранённое или значение по умолчанию, а не вычисляет его из слайдов.
- **ODP:** Метаданные OpenDocument предоставляют общую статистику документа, такую как количество страниц, абзацев и слов, но эти значения не сопоставляются со всеми расширенными свойствами PowerPoint. Метаданные скрытых слайдов, заметок, мультимедиа, пар заголовков и названий частей могут быть недоступны, и свойства инвентаря могут возвращать значения по умолчанию. Не рассматривайте нулевое значение или пустой массив как окончательное доказательство отсутствия соответствующего содержимого.

Используйте лёгкий подход к метаданным для инвентарей и предварительных проверок. Загружайте презентацию и проверяйте её живую модель объектов, когда результат должен отражать изменения в памяти или когда требуется подтвердить фактическое содержимое презентации.

## **Обновление свойств презентации**

Свойства, возвращаемые [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentationinfo/readdocumentproperties/), также могут быть изменены без создания экземпляра [Presentation](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/). Примените изменения с помощью [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentationinfo/updatedocumentproperties/), а затем запишите связанную презентацию через [PresentationInfo.writeBindedPresentation](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentationinfo/writebindedpresentation/).

На следующем изображении показаны исходные свойства документа.

![Original document properties of the PowerPoint presentation](input_properties.png)

Следующий пример меняет заголовок и время последнего сохранения и записывает результат в новый файл:

```javascript
const aspose = require("aspose.slides.via.java");
const java = require("java");

const sourceFile = "sample.pptx";
const outputFile = "sample_with_updated_properties.pptx";
const presentationInfo = aspose.PresentationFactory.getInstance().getPresentationInfo(sourceFile);
const documentProperties = presentationInfo.readDocumentProperties();

documentProperties.setTitle("Quarterly sales report");
documentProperties.setLastSavedTime(java.newInstanceSync("java.util.Date"));

presentationInfo.updateDocumentProperties(documentProperties);
const outputStream = java.newInstanceSync("java.io.FileOutputStream", outputFile);
try {
    presentationInfo.writeBindedPresentation(outputStream);
} finally {
    outputStream.close();
}
```

На следующем изображении показаны обновлённые свойства документа.

![Changed document properties of the PowerPoint presentation](output_properties.png)

## **Полезные ссылки**

Для сопутствующих проверок безопасности и настроек защиты см. следующие статьи:

- [Password-Protect Presentations](/slides/ru/nodejs-java/password-protected-presentation/)
- [Write-Protect Presentations](/slides/ru/nodejs-java/write-protected-presentation/)

## **Часто задаваемые вопросы**

**Как проверить, встроены ли шрифты и какие именно?**

Загрузите презентацию и используйте [Presentation.getFontsManager](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/getfontsmanager/). Вызовите [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/fontsmanager/getembeddedfonts/) для получения встроенных шрифтов и [FontsManager.getFonts](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/fontsmanager/getfonts/) для получения шрифтов, используемых в презентации. Сравните оба результата, чтобы найти шрифты, необходимые для рендеринга, но не встроенные.

**Как быстро определить, есть ли скрытые слайды и сколько их?**

Если хранимые метаданные документа достаточны, прочитайте [DocumentProperties.getHiddenSlides](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/documentproperties/#getHiddenSlides) через [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentationfactory/getpresentationinfo/) и [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentationinfo/readdocumentproperties/). Это подходит для лёгкого инвентаря. Если презентация была изменена в памяти, хранимые метаданные могут отсутствовать или быть устаревшими; в этом случае переберите [Presentation.getSlides](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/getslides/) и проверьте метод [Slide.getHidden](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/slide/gethidden/) каждого слайда.

**Можно ли обнаружить, используется ли пользовательский размер и ориентация слайдов, и отличаются ли они от значений по умолчанию?**

Да. Загрузите презентацию и вызовите [Presentation.getSlideSize](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/getslidesize/). Используйте [SlideSize.getType](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/slidesize/gettype/), [SlideSize.getSize](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/slidesize/getsize/) и [SlideSize.getOrientation](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/slidesize/getorientation/) для сравнения текущих настроек с ожидаемыми предустановками и размерами.

**Есть ли быстрый способ увидеть, ссылаются ли диаграммы на внешние источники данных?**

Да. Найдите каждую [Chart](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/chart/) и вызовите [ChartData.getDataSourceType](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/chartdata/getdatasourcetype/). Для внешней книги вызовите [ChartData.getExternalWorkbookPath](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/). Тип источника данных и путь указывают на внешнюю ссылку, однако проверка доступности цели требует отдельной проверки ресурсов.

**Как оценить «тяжёлые» слайды, которые могут замедлять рендеринг или экспорт в PDF?**

Нет единого свойства сложности. Переберите [Presentation.getSlides](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/getslides/) и коллекцию [BaseSlide.getShapes](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/baseslide/#getShapes) каждого слайда. Используйте количество фигур и наличие больших изображений, эффектов, анимаций или мультимедиа как сигналы, и измерьте репрезентативный рендеринг или экспорт, прежде чем считать слайд подтверждённым узким местом производительности.