---
title: Сохранение презентаций в JavaScript
linktitle: Сохранить презентацию
type: docs
weight: 80
url: /ru/nodejs-java/save-presentation/
keywords:
- сохранить PowerPoint
- сохранить OpenDocument
- сохранить презентацию
- сохранить слайд
- сохранить PPT
- сохранить PPTX
- сохранить ODP
- презентация в файл
- презентация в поток
- предопределённый тип представления
- Строгий формат Office Open XML
- режим Zip64
- обновление миниатюры
- прогресс сохранения
- Node.js
- JavaScript
- Aspose.Slides
description: "Сохраните презентации PowerPoint и OpenDocument в файлы или потоки на JavaScript с помощью Aspose.Slides и настройте вывод PPTX и отображение прогресса."
---
## **Обзор**

После того как вы создаете презентацию или [open an existing one](/slides/ru/nodejs-java/open-presentation/), используйте метод [Presentation.save](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/#save) для записи результата. Aspose.Slides for Node.js via Java может сохранять презентацию в файл или поток в форматах PowerPoint, OpenDocument, PDF и других. В следующих разделах рассматриваются стандартные операции сохранения и параметры, доступные для вывода PPTX.

## **Сохранение презентаций в файлы**

Чтобы сохранить презентацию в файл, передайте путь вывода и значение [SaveFormat](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/saveformat/) в метод [Presentation.save](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/#save). Значение формата определяет тип файла, который создает Aspose.Slides.

Следующий пример создает презентацию и сохраняет её как файл PPTX:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    // Добавьте или измените содержимое презентации здесь.

    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Сохранение презентаций в их исходном формате**

Для примеров обнаружения формата файлов и потоков, поведения вновь созданных презентаций и различий между исходным и выходным форматами см. [Determine the Original Presentation Format](/slides/ru/nodejs-java/detect-presentation-source-format/).

В приложении пакетной обработки входной формат может быть неизвестен заранее. После загрузки файла прочитайте его исходный формат с помощью метода [Presentation.getSourceFormat](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/#getSourceFormat). Передайте полученное значение [SourceFormat](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/sourceformat/) в [SlideUtil.toSaveFormat](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/slideutil/#toSaveFormat), чтобы получить соответствующее значение [SaveFormat](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/saveformat/), после чего используйте [Presentation.save](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/#save) для записи измененной презентации.

Следующий полный пример обрабатывает каждый файл во входном каталоге, обновляет его заголовок и сохраняет его в выходном каталоге в том же формате, из которого он был загружен:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const fs = require("fs");
const path = require("path");

const inputDirectory = "Input";
const outputDirectory = "Output";

if (!fs.existsSync(inputDirectory)) {
    console.error("The input directory does not exist.");
} else {
    fs.mkdirSync(outputDirectory, { recursive: true });

    const inputFiles = fs.readdirSync(inputDirectory, { withFileTypes: true })
        .filter((entry) => entry.isFile());

    for (const inputFile of inputFiles) {
        const inputPath = path.join(inputDirectory, inputFile.name);
        try {
            const presentation = new aspose.slides.Presentation(inputPath);
            try {
                const saveFormat = aspose.slides.SlideUtil.toSaveFormat(presentation.getSourceFormat());
                presentation.getDocumentProperties().setTitle("Processed by the batch application");

                const outputPath = path.join(outputDirectory, inputFile.name);
                presentation.save(outputPath, saveFormat);
            } finally {
                presentation.dispose();
            }
        } catch (error) {
            console.error(`Cannot process '${inputPath}': ${error.message}`);
        }
    }
}
```

[SlideUtil.toSaveFormat](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/slideutil/#toSaveFormat) отображает PPT, PPTX, ODP, PPTM, PPSX, PPSM, POTX, POTM, PPS, POT, OTP, FODP и PowerPoint XML в их соответствующие форматы сохранения презентаций. Он отображает только форматы источника презентации; он не предназначен для выбора форматов экспорта, таких как PDF, HTML, TIFF или изображения. Передача неподдерживаемого или недействительного значения [SourceFormat](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/sourceformat/) приводит к ошибке.

Унаследованные файлы PPT, PPS и POT используют один и тот же двоичный контейнер. Когда такая презентация загружается из потока без расширения файла, файл PPS или POT может быть определён как PPT. Если требуется сохранение этих устаревших подтипов, сохраните оригинальное имя файла или метаданные формата отдельно и используйте их при выборе имени выходного файла и формата.

## **Сохранение презентаций в потоки**

Чтобы записать презентацию без указания конечного пути к файлу, передайте записываемый поток и значение [SaveFormat](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/saveformat/) в метод [Presentation.save](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/#save). Этот подход полезен, когда вывод должен быть возвращён из веб‑сервиса, сохранён в базе данных или обработан в памяти.

Следующий пример сохраняет новую презентацию в файловый поток:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const outputStream = java.newInstanceSync("java.io.FileOutputStream", "output.pptx");
    try {
        presentation.save(outputStream, aspose.slides.SaveFormat.Pptx);
    } finally {
        outputStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **Сохранение презентаций с предопределенным типом представления**

Вы можете указать представление, в котором PowerPoint изначально откроет сохранённую презентацию. Используйте метод [ViewProperties.setLastView](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/viewproperties/#setLastView) с значением [ViewType](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/viewtype/) перед сохранением.

Следующий пример настраивает представление Slide Master как начальное представление:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    presentation.getViewProperties().setLastView(aspose.slides.ViewType.SlideMasterView);
    presentation.save("slide-master-view.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Сохранение презентаций в строгом формате Office Open XML**

Чтобы создать файл PPTX, соответствующий строгому профилю Office Open XML, создайте экземпляр [PptxOptions](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/pptxoptions/) и используйте его метод [setConformance](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/pptxoptions/#setConformance) со значением [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/conformance/#Iso29500_2008_Strict). Затем передайте параметры в метод [Presentation.save](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/#save).

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const options = new aspose.slides.PptxOptions();
options.setConformance(aspose.slides.Conformance.Iso29500_2008_Strict);

const presentation = new aspose.slides.Presentation();
try {
    presentation.save("strict-office-open-xml.pptx", aspose.slides.SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

## **Сохранение презентаций в формате Office Open XML в режиме Zip64**

Стандартный ZIP‑архив ограничивает сжатый и несжатый размер каждой записи, общий размер архива и количество записей. Поскольку файл PPTX является ZIP‑архивом, очень большая презентация может превысить эти ограничения. Расширения ZIP64 повышают соответствующие ограничения по размеру и количеству записей.

Используйте метод [PptxOptions.setZip64Mode](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/pptxoptions/#setZip64Mode) для управления тем, будет ли Aspose.Slides записывать расширения ZIP64:

- [IfNecessary](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/zip64mode/#IfNecessary) использует ZIP64 только когда презентация превышает стандартные ограничения ZIP. Это режим по умолчанию.
- [Never](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/zip64mode/#Never) отключает расширения ZIP64.
- [Always](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/zip64mode/#Always) всегда записывает расширения ZIP64.

Следующий пример всегда включает расширения ZIP64 для выходной презентации:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const options = new aspose.slides.PptxOptions();
    options.setZip64Mode(aspose.slides.Zip64Mode.Always);

    presentation.save("output-zip64.pptx", aspose.slides.SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

{{% alert color="warning" title="Warning" %}}
Если используется [Zip64Mode.Never](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/zip64mode/#Never) и презентация не помещается в стандартные лимиты ZIP, операция сохранения бросает [PptxException](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/pptxexception/).
{{% /alert %}}

## **Сохранение презентаций в формате Office Open XML с уровнями сжатия**

Для вывода PPTX вы можете балансировать скорость сохранения и размер файла, используя метод [PptxOptions.setCompressionLevel](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/pptxoptions/#setCompressionLevel). Класс [CompressionLevel](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/compressionlevel/) предоставляет следующие значения:

- [None](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/compressionlevel/#None) сохраняет данные без сжатия.
- [Level1](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/compressionlevel/#Level1) обеспечивает самое быстрое сжатие и наибольший размер сжатого вывода.
- [Level2](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/compressionlevel/#Level2)‑[Level5](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/compressionlevel/#Level5) постепенно отдают предпочтение меньшему выводу за счёт скорости сохранения.
- [Level6](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/compressionlevel/#Level6) балансирует скорость сохранения и размер файла. Это уровень по умолчанию.
- [Level7](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/compressionlevel/#Level7) и [Level8](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/compressionlevel/#Level8) ещё более отдают предпочтение меньшему выводу за счёт скорости сохранения.
- [Level9](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/compressionlevel/#Level9) обеспечивает самое сильное сжатие и требует наибольшее время обработки.

Следующий пример сохраняет презентацию без сжатия:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const options = new aspose.slides.PptxOptions();
    options.setCompressionLevel(aspose.slides.CompressionLevel.None);

    presentation.save("output-no-compression.pptx", aspose.slides.SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

Следующий пример использует максимальный уровень сжатия:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const options = new aspose.slides.PptxOptions();
    options.setCompressionLevel(aspose.slides.CompressionLevel.Level9);

    presentation.save("output-maximum-compression.pptx", aspose.slides.SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

## **Сохранение презентаций без обновления миниатюры**

Когда презентация сохраняется как PPTX, метод [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/pptxoptions/#setRefreshThumbnail) управляет её миниатюрой документа:

- `true` регенерирует миниатюру во время операции сохранения. Это значение по умолчанию.
- `false` сохраняет существующую миниатюру. Если у презентации нет миниатюры, Aspose.Slides не создаёт её.

Следующий пример сохраняет презентацию без обновления её миниатюры:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const options = new aspose.slides.PptxOptions();
    options.setRefreshThumbnail(false);

    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Отключение обновления миниатюры может сократить время, необходимое для сохранения файла PPTX.
{{% /alert %}}

## **Сохранение прогресса в процентах**

Чтобы отслеживать процесс сохранения, реализуйте интерфейс [IProgressCallback](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iprogresscallback/) с помощью Java‑прокси и передайте реализацию в метод [SaveOptions.setProgressCallback](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/saveoptions/#setProgressCallback). Aspose.Slides затем вызывает метод [IProgressCallback.reporting](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iprogresscallback/#reporting-double-) с значениями прогресса во время экспорта.

Следующий пример выводит прогресс экспорта PDF в консоль:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const exportProgressHandler = java.newProxy("com.aspose.slides.IProgressCallback", {
    reporting: function(progressValue) {
        const progress = Math.floor(progressValue);
        console.log(`${progress}% of the file has been converted.`);
    }
});

const options = new aspose.slides.PdfOptions();
options.setProgressCallback(exportProgressHandler);

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    presentation.save("output.pdf", aspose.slides.SaveFormat.Pdf, options);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Aspose предоставляет бесплатный [PowerPoint Splitter](https://products.aspose.app/slides/ru/splitter), построенный на API Aspose.Slides. Он сохраняет выбранные слайды из презентации в отдельные файлы PPT или PPTX.
{{% /alert %}}

## **FAQ**

**Поддерживает ли Aspose.Slides инкрементное или «быстрое сохранение»?**

Нет. Каждая операция сохранения записывает полный выходной файл, а не только изменённые части.

**Могут ли несколько потоков сохранять один и тот же объект Presentation?**

Нет. Экземпляр [Presentation](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/) **не является потокобезопасным** (/slides/ru/nodejs-java/multithreading/). Доступ и сохранение каждого экземпляра должно происходить только из одного потока одновременно.

**Что происходит с гиперссылками и внешними связанными файлами при сохранении презентации?**

[Hyperlinks](/slides/ru/nodejs-java/manage-hyperlinks/) остаются в презентации. Aspose.Slides не копирует внешние связанные файлы, поэтому сохранённая презентация должна по‑прежнему иметь доступ к их местоположениям.

**Могу ли я сохранить метаданные документа, такие как автор, название, компания и дата создания?**

Да. Установите соответствующие [document properties](/slides/ru/nodejs-java/presentation-properties/) перед сохранением, и Aspose.Slides запишет их в выходной файл.