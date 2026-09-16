---
title: Экспорт презентаций в XAML на JavaScript
linktitle: Презентация в XAML
type: docs
weight: 30
url: /ru/nodejs-java/export-to-xaml/
keywords:
- экспорт PowerPoint
- экспорт OpenDocument
- экспорт презентации
- конвертировать PowerPoint
- конвертировать OpenDocument
- конвертировать презентацию
- PowerPoint в XAML
- OpenDocument в XAML
- презентация в XAML
- PPT в XAML
- PPTX в XAML
- ODP в XAML
- сохранить PPT как XAML
- сохранить PPTX как XAML
- сохранить ODP как XAML
- экспорт PPT в XAML
- экспорт PPTX в XAML
- экспорт ODP в XAML
- Node.js
- JavaScript
- Aspose.Slides
description: "Преобразуйте слайды PowerPoint и OpenDocument в XAML на JavaScript с помощью Aspose.Slides — быстрый, не требующий Office решение, сохраняющее вашу разметку неизменной."
---
## **Обзор**

В этой статье объясняется, как экспортировать презентации PowerPoint в XAML с помощью Aspose.Slides. Она включает краткое введение в XAML, показывает, как сохранить презентацию в XAML с настройками по умолчанию, и демонстрирует, как настроить экспорт с помощью [XamlOptions](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/xamloptions/), включая экспорт скрытых слайдов. Статья также отвечает на несколько часто задаваемых вопросов, связанных с резервными шрифтами, совместимостью стеков XAML и поведением при экспорте скрытых слайдов.

## **О XAML**

XAML — это основанный на XML язык разметки, используемый для описания пользовательских интерфейсов в таких фреймворках, как WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) и Xamarin.Forms.

Вы можете работать с файлами XAML в визуальном дизайнере или писать и редактировать разметку напрямую.

## **Экспорт презентаций в XAML с настройками по умолчанию**

Следующий пример на JavaScript показывает, как экспортировать презентацию в XAML с настройками по умолчанию:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const xamlOptions = new aspose.slides.XamlOptions();
    presentation.save(xamlOptions);
} finally {
    presentation.dispose();
}
```

По умолчанию экспортированные слайды сохраняются в подпапке `input` текущего рабочего каталога процесса. Папка создаётся автоматически, и все необходимые изображения также сохраняются там.

Имя папки вывода берётся из имени исходного файла без расширения. В Aspose.Slides for Node.js via Java 26.8 экспорт `input.pptx` приводит к вложенному пути, например `input/input/Slide_1.xaml`. Сохраняйте полные сгенерированные пути при обработке вывода. Вывод по умолчанию относителен к текущему рабочему каталогу, а не обязательно находится рядом с входным файлом.

## **Экспорт презентаций в XAML с пользовательскими настройками**

Используйте интерфейс [IXamlOptions](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ixamloptions/) для управления тем, как Aspose.Slides экспортирует презентацию в XAML.

Чтобы сохранить вывод в пользовательское место, реализуйте [IXamlOutputSaver](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ixamloutputsaver/) и передайте экземпляр вашей реализации в метод [setOutputSaver](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/xamloptions/#setOutputSaver) объекта [XamlOptions](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/xamloptions/).

Чтобы включить скрытые слайды в вывод XAML, вызовите [setExportHiddenSlides](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/xamloptions/#setExportHiddenSlides) с параметром `true`, как показано в следующем примере на JavaScript:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const xamlOptions = new aspose.slides.XamlOptions();
    xamlOptions.setExportHiddenSlides(true);
    presentation.save(xamlOptions);
} finally {
    presentation.dispose();
}
```

## **Получить все сгенерированные артефакты XAML**

Экспорт XAML может создавать документ XAML для каждого экспортированного слайда, а также отдельные изображения и ресурсные файлы. Назначьте пользовательский [IXamlOutputSaver](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ixamloutputsaver/) в [XamlOptions.setOutputSaver](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/xamloptions/#setOutputSaver), чтобы получать эти артефакты вместо использования сохранения в файловой системе по умолчанию. Запустите экспорт с использованием перегруженного метода XAML‑специфичного [Presentation.save](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/#save) , принимающего параметры XAML.

В Node.js реализуйте Java‑интерфейс с помощью `java.newProxy` из пакета `java`, используемого Aspose.Slides. Держите прокси доступным до завершения экспорта.

### **Понимание жизненного цикла обратных вызовов**

Экспортер вызывает [IXamlOutputSaver.save](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ixamloutputsaver/#save-java.lang.String-byte:A-) отдельно для каждого сгенерированного артефакта:

- `path` идентифицирует артефакт и может включать относительные каталоги. Сохраните эту информацию, поскольку XAML может ссылаться на ресурсы с помощью относительных путей.
- `data` содержит байты артефакта. Изображения и другие бинарные ресурсы не должны декодироваться как текст.
- Сохранитель отвечает за хранение или сохранение данных перед возвратом. В примерах каждый массив байтов Java копируется в буфер Node.js, принадлежащий приложению.
- Считайте экспорт успешным только тогда, когда операция сохранения презентации возвращается и каждый обратный вызов завершён успешно. Не подавляйте ошибки хранения и не запускайте незаметные фоновые записи. Если сохранение происходит позже, сообщайте об общей успешности только после того, как и этот шаг завершится успешно.

[XamlOptions.setExportHiddenSlides](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/xamloptions/#setExportHiddenSlides) также применяется к пользовательскому сохранителю. Значение по умолчанию, `false`, исключает XAML‑документы скрытых слайдов. Передача `true` включает их и любые ресурсы, необходимые для их экспорта. Количество ресурсов зависит от презентации; не предполагайте один обратный вызов на слайд или фиксированный порядок вызовов.

### **Экспорт в память и проверка артефактов**

В этом полном примере загружается `input.pptx`, собираются все артефакты в JavaScript‑отображение имён в буферы и выводятся их имя, тип и количество байт. Имена сохраняются точно так, как переданы. Дублирующиеся имена делают коллекцию недействительной вместо тихой перезаписи артефакта. Пример проверяет это перед использованием результатов.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const artifacts = new Map();
let valid = true;
const saver = java.newProxy("com.aspose.slides.IXamlOutputSaver", {
    save: function(path, data) {
        const name = String(path);
        if (artifacts.has(name)) {
            valid = false;
            console.error("Export rejected: duplicate artifact name: " + name);
            return;
        }
        const retainedData = Buffer.from(data);
        artifacts.set(name, retainedData);
    }
});

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const options = new aspose.slides.XamlOptions();
    options.setOutputSaver(saver);
    options.setExportHiddenSlides(true);
    presentation.save(options);
} finally {
    presentation.dispose();
}

if (!valid) {
    console.error("Export rejected: the artifact collection is invalid.");
} else {
    const inspectXamlText = false;
    for (const [name, data] of artifacts) {
        const isXaml = /\.xaml$/i.test(name);
        const isImage = /\.(png|jpg|jpeg|gif|bmp|tif|tiff|svg)$/i.test(name);
        const kind = isXaml ? "slide XAML" : isImage ? "image" : "supporting resource";
        console.log(name + ": " + data.length + " bytes (" + kind + ")");

        // Декодировать только XAML и только когда требуется текстовый осмотр.
        if (isXaml && inspectXamlText) {
            console.log(data.toString("utf8"));
        }
    }
}
```

Проверка расширений полезна для инспекции; сохраняйте все артефакты, включая незнакомые типы ресурсов. Оставляйте байты без изменений при хранении или передаче. Декодируйте UTF-8 только для XAML, требующего текстовой обработки.

### **Упаковать собранные артефакты в ZIP‑архив**

В этом самостоятельном примере собирается экспорт, проверяются имена и исходные байты записываются в ZIP‑архив с помощью Java‑моста. ZIP собирается в памяти перед сохранением на диск. Уникальное имя архива разделяет одновременно выполняемые задачи экспорта. Записи ZIP используют прямые слеши и сохраняют относительные каталоги. Небезопасные имена или имена, конфликтующие после нормализации, приводят к отклонению всего пакета до его записи.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const artifacts = new Map();
let valid = true;
const saver = java.newProxy("com.aspose.slides.IXamlOutputSaver", {
    save: function(path, data) {
        const name = String(path);
        if (artifacts.has(name)) {
            valid = false;
            console.error("Export rejected: duplicate artifact name: " + name);
            return;
        }
        const retainedData = Buffer.from(data);
        artifacts.set(name, retainedData);
    }
});

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const options = new aspose.slides.XamlOptions();
    options.setOutputSaver(saver);
    options.setExportHiddenSlides(false);
    presentation.save(options);
} finally {
    presentation.dispose();
}

const entries = new Map();
const entryNames = new Set();
for (const [name, data] of artifacts) {
    const entryName = name.replace(/\\/g, "/");
    const segments = entryName.split("/");
    const unsafeName = entryName.startsWith("/") || entryName.includes(":") || segments.some(segment => segment.trim() === "" || segment === "." || segment === "..");
    const comparisonName = entryName.toLowerCase();
    if (unsafeName || entryNames.has(comparisonName)) {
        valid = false;
        console.error("Export rejected: unsafe or duplicate artifact name: " + name);
        break;
    }
    entryNames.add(comparisonName);
    entries.set(entryName, data);
}

if (!valid) {
    console.error("Export rejected: the artifact collection is invalid.");
} else {
    const fs = require("node:fs");
    const crypto = require("node:crypto");
    const archivePath = "xaml-" + crypto.randomUUID() + ".zip";
    const output = java.newInstanceSync("java.io.ByteArrayOutputStream");
    const archive = java.newInstanceSync("java.util.zip.ZipOutputStream", output);
    try {
        for (const [name, data] of entries) {
            const entry = java.newInstanceSync("java.util.zip.ZipEntry", name);
            archive.putNextEntry(entry);
            const signedBytes = Array.from(data, value => value > 127 ? value - 256 : value);
            const bytes = java.newArray("byte", signedBytes);
            archive.write(bytes);
            archive.closeEntry();
        }
    } finally {
        archive.close();
    }

    // Закрытие завершает каталог ZIP перед тем, как архив будет сохранён.
    const archiveData = Buffer.from(output.toByteArray());
    try {
        fs.writeFileSync(archivePath, archiveData, { flag: "wx" });
        console.log("Saved " + entries.size + " artifacts to " + archivePath);
    } catch (error) {
        console.error("Archive persistence failed: " + error.message);
    }
}
```

Пример использует [ZipOutputStream](https://docs.oracle.com/javase/8/docs/api/java/util/zip/ZipOutputStream.html) для записи одного локального архива; сам экспортер не записывает отдельные файлы XAML или изображений. Для удалённого хранилища замените этап записи архива загрузкой собранных массивов байтов. Используйте идентификатор задания экспорта вместе с полным относительным именем артефакта в качестве ключа блоба, либо храните идентификатор задания, относительное имя и бинарные данные в строке базы данных. Публикуйте задание только после завершения всех загрузок или коммита транзакции базы данных. Очистите частичный вывод, если сохранение не удалось.

Для больших презентаций пользовательский сохранитель может сохранять каждый артефакт непосредственно в хранилище приложения, чтобы избежать дополнительной копии всего экспорта в памяти приложения. Делайте каждый обратный вызов синхронным с точки зрения экспортёра: возвращайте управление только после того, как получатель принял байты, и позволяйте ошибкам достигать вызывающего кода.

### **Сохранить имена ресурсов и проверить ссылки**

- Нормализуйте разделители путей, если это требует назначение, но сохраняйте относительные каталоги. Не используйте только базовое имя, если только не известно, что каждое сгенерированное имя уникально и ссылки на ресурсы остаются корректными.
- Применяйте проверку имён, специфичную для места назначения. При записи отдельных файлов отклоняйте абсолютные пути и сегменты перехода, разрешайте место назначения в абсолютный путь и проверяйте, что он остаётся внутри целевого каталога экспорта, включая разделитель каталога в проверке включения. Используйте контролируемый приложением каталог без символических ссылок, которые могут перенаправлять записи.
- Используйте отдельный сохранитель и пространство имён хранилища для каждого задания экспорта. Обнаруживайте коллизии после нормализации разделителей и в соответствии с правилами чувствительности к регистру места назначения.
- Перед публикацией разберите каждый документ XAML как XML и проверьте его файловые ссылки на ресурсы, такие как атрибуты изображения `Source` или `ImageSource`. Разрешите каждый относительный URI относительно каталога содержащего артефакта XAML, нормализуйте полученное имя в хранилище и убедитесь, что соответствующий ключ карты, запись ZIP или сохранённый объект существует. Обрабатывайте внешние URI и XAML‑выражения разметки отдельно от относительных имён файлов.

Например, если `input/Slide_1.xaml` ссылается на `images/image1.png`, сохранённый ресурс должен быть доступен как `input/images/image1.png`. Сохранение лишь `image1.png` нарушит эту связь. Для объектного хранилища сохраняйте ту же структуру под префиксом задания и делайте эти URL‑ы ресурсов доступными для потребителя XAML. Откройте готовый ZIP‑архив, чтобы проверить имена записей и байты ресурсов, и загрузите представительные слайды в целевой XAML‑среде, чтобы убедиться, что изображения корректно разрешаются.

## **FAQ**

**Как гарантировать предсказуемые шрифты, если оригинальный шрифт недоступен на машине?**

Вызовите [setDefaultRegularFont](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/saveoptions/#setDefaultRegularFont) в [XamlOptions](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/xamloptions/) — он используется как резервный шрифт при экспорте, если оригинальный отсутствует. Это не гарантирует, что сгенерированный XAML будет ссылаться на резервный шрифт или что шрифт будет доступен на целевой машине. Убедитесь, что шрифты, указанные в XAML, доступны в среде, где он отображается.

**Предназначен ли экспортированный XAML только для WPF, или его можно использовать и в других стеках XAML?**

Aspose.Slides экспортирует WPF XAML через свой публичный API. Совместимость с другими стеками XAML, такими как UWP и Xamarin.Forms, не гарантируется. Проверьте сгенерированную разметку в целевой среде.

**Поддерживаются ли скрытые слайды и как предотвратить их экспорт по умолчанию?**

По умолчанию скрытые слайды не включаются. Вы можете управлять этим поведением через [setExportHiddenSlides](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/xamloptions/#setExportHiddenSlides) в [XamlOptions](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/xamloptions/) — оставляйте его отключённым, если не требуется экспортировать скрытые слайды.