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
- конвертация PowerPoint
- конвертация OpenDocument
- конвертация презентации
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
description: "Конвертируйте слайды PowerPoint и OpenDocument в XAML на JavaScript с помощью Aspose.Slides — быстрое решение без Office, сохраняющее исходную компоновку."
---
## **Обзор**

Эта статья объясняет, как экспортировать презентации PowerPoint в XAML с использованием Aspose.Slides. Она содержит краткое введение в XAML, показывает, как сохранить презентацию в XAML с настройками по умолчанию, и демонстрирует, как настроить экспорт с помощью [XamlOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/), включая экспорт скрытых слайдов. Статья также отвечает на несколько распространенных вопросов, связанных с резервными шрифтами, совместимостью стеков XAML и поведением экспорта скрытых слайдов.

## **О XAML**

XAML — это основанный на XML язык разметки, используемый для описания пользовательских интерфейсов в таких фреймворках, как WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) и Xamarin.Forms.  
Вы можете работать с файлами XAML в визуальном дизайнере или писать и редактировать разметку напрямую.

## **Экспорт презентаций в XAML с параметрами по умолчанию**

Следующий пример JavaScript показывает, как экспортировать презентацию в XAML с настройками по умолчанию:

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

По умолчанию экспортированные слайды сохраняются в подпапку `input` текущего рабочего каталога процесса. Папка создаётся автоматически, и все необходимые изображения также сохраняются там.  
Имя папки вывода берётся из имени исходного файла без расширения. В Aspose.Slides for Node.js via Java 26.8 экспорт `input.pptx` дает вложенный путь вроде `input/input/Slide_1.xaml`. Сохраняйте полные сгенерированные пути при работе с выводом. Вывод по умолчанию относителен к текущему рабочему каталогу, а не обязательно находится рядом с файлом ввода.

## **Экспорт презентаций в XAML с пользовательскими параметрами**

Используйте интерфейс [IXamlOptions](https://reference.aspose.com/slides/java/com.aspose.slides/ixamloptions/) для управления тем, как Aspose.Slides экспортирует презентацию в XAML.  

Чтобы сохранить вывод в пользовательское место, реализуйте [IXamlOutputSaver](https://reference.aspose.com/slides/java/com.aspose.slides/ixamloutputsaver/) и передайте экземпляр реализации в метод [setOutputSaver](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/#setOutputSaver) объекта [XamlOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/).  

Чтобы включить скрытые слайды в вывод XAML, вызовите [setExportHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/#setExportHiddenSlides) со значением `true`, как показано в следующем примере JavaScript:

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

## **Сбор всех сгенерированных артефактов XAML**

Экспорт XAML может создавать документ XAML для каждого экспортированного слайда, а также отдельные изображения и вспомогательные ресурсы. Назначьте пользовательский [IXamlOutputSaver](https://reference.aspose.com/slides/java/com.aspose.slides/ixamloutputsaver/) параметру [XamlOptions.setOutputSaver](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/#setOutputSaver), чтобы получать эти артефакты вместо использования сохраняющего в файловой системе по умолчанию. Запустите экспорт с помощью XAML‑специфичного перегрузка метода [Presentation.save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#save), принимающего параметры XAML.  

В Node.js реализуйте Java‑интерфейс с помощью `java.newProxy` из пакета `java`, используемого Aspose.Slides. Держите прокси доступным до завершения экспорта.

### **Понимание жизненного цикла обратного вызова**

Экспортёр вызывает [IXamlOutputSaver.save](https://reference.aspose.com/slides/java/com.aspose.slides/ixamloutputsaver/#save-java.lang.String-byte:A-) отдельно для каждого сгенерированного артефакта:

- `path` идентифицирует артефакт и может включать относительные каталоги. Сохраняйте эту информацию, так как XAML может ссылаться на ресурсы по относительным путям.  
- `data` содержит байты артефакта. Изображения и другие бинарные ресурсы не должны декодироваться как текст.  
- Сохраняющий объект отвечает за удержание или постоянное сохранение данных до возврата. Примеры копируют каждый массив байтов Java в буфер Node.js, принадлежащий приложению.  
- Считайте экспорт успешным только после того, как операция сохранения презентации вернётся и каждый обратный вызов завершится успешно. Не подавляйте ошибки хранилища и не запускать незаметные фоновые записи. Если сохранение происходит позже, сообщайте об общем успехе только после успешного завершения этого шага.  

[XamlOptions.setExportHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/#setExportHiddenSlides) также применяется к пользовательскому сохраняющему объекту. Значение по умолчанию `false` исключает XAML‑документы скрытых слайдов. Передача `true` включает их и любые ресурсы, необходимые для их экспорта. Количество ресурсов зависит от презентации; не предполагаете один обратный вызов на слайд или фиксированный порядок вызовов.

### **Экспорт в память и проверка артефактов**

Полный пример загружает `input.pptx`, собирает каждый артефакт в JavaScript‑карте имён‑в‑буферы и выводит его имя, тип и количество байтов. Имена сохраняются точно как получены. Дублирующие имена делают коллекцию недействительной вместо тихой перезаписи артефакта. Пример проверяет это перед использованием результатов.

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

        // Декодировать только XAML и только когда требуется текстовый анализ.
        if (isXaml && inspectXamlText) {
            console.log(data.toString("utf8"));
        }
    }
}
```

Проверка расширений полезна для инспекции; сохраняйте все артефакты, включая неизвестные типы ресурсов. Оставляйте байты без изменения при хранении или передаче. Декодируйте в UTF‑8 только XAML, требующий текстовой обработки.

### **Упаковка собранных артефактов в ZIP‑архив**

Этот отдельный пример собирает экспорт, проверяет имена и записывает оригинальные байты в ZIP‑архив с помощью Java‑моста. ZIP собирается в памяти перед сохранением на диск. Уникальное имя архива разделяет одновременные задачи экспорта. Записи ZIP используют прямой слеш и сохраняют относительные каталоги. Небезопасные имена или имена, конфликтующие после нормализации, приводят к отклонению всего пакета до его записи.

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
            const bytes = java.newArray("byte", Array.from(data));
            archive.write(bytes);
            archive.closeEntry();
        }
    } finally {
        archive.close();
    }

    // Закрытие завершает каталог ZIP перед сохранением архива.
    const archiveData = Buffer.from(output.toByteArray());
    try {
        fs.writeFileSync(archivePath, archiveData, { flag: "wx" });
        console.log("Saved " + entries.size + " artifacts to " + archivePath);
    } catch (error) {
        console.error("Archive persistence failed: " + error.message);
    }
}
```

Пример использует [ZipOutputStream](https://docs.oracle.com/javase/8/docs/api/java/util/zip/ZipOutputStream.html) для записи одного локального архива; сам экспортёр не пишет отдельные XAML‑ или файлы изображений. Для удалённого хранилища замените стадию записи архива загрузкой собранных массивов байтов. Используйте идентификатор экспорт‑задачи плюс полный относительный путь артефакта в качестве ключа blob, либо сохраняйте идентификатор задачи, относительное имя и бинарные данные в строке базы данных. Публикуйте задачу только после завершения всех загрузок или фиксации транзакции базы данных. При неудаче сохранения удаляйте частичный вывод.  

Для больших презентаций пользовательский сохраняющий объект может сохранять каждый артефакт непосредственно в хранилище приложения, чтобы избежать удержания полной копии экспорта в памяти. Делайте каждый обратный вызов синхронным с точки зрения экспортёра: возвращайте управление только после того, как получатель принял байты, и позволяйте ошибкам доходить до вызывающего кода.

### **Сохранение имен ресурсов и проверка ссылок**

- Нормализуйте разделители путей, если этого требует место назначения, но сохраняйте относительные каталоги. Не используйте только базовое имя, если только не гарантировано, что каждое сгенерированное имя уникально и ссылки на ресурсы остаются корректными.  
- Применяйте проверку имён, специфичную для места назначения. При записи отдельных файлов отклоняйте абсолютные пути и сегменты перехода, преобразуйте место назначения в абсолютный путь и проверяйте, что он остаётся внутри целевого каталога экспорта, включая разделитель в проверке содержания. Используйте каталог, контролируемый приложением, без символических ссылок, которые могут перенаправлять записи.  
- Используйте отдельный сохраняющий объект и пространство имён хранилища для каждой задачи экспорта. Обнаруживайте коллизии после нормализации разделителей и в соответствии с правилами регистронезависимости места назначения.  
- Перед публикацией разбирайте каждый XAML‑документ как XML и проверяйте его файловые ссылки на ресурсы, такие как атрибуты `Source` или `ImageSource` у изображений. Разрешайте каждый относительный URI относительно каталога содержащего XAML‑артефакта, нормализуйте полученное имя хранилища и подтверждайте, что соответствующий ключ в карте, запись ZIP или объект в хранилище существует. Обрабатывайте внешние URI и XAML‑выражения раздельно от относительных имён файлов.  

Например, если `input/Slide_1.xaml` ссылается на `images/image1.png`, сохранённый ресурс должен быть доступен как `input/images/image1.png`. Хранение только `image1.png` нарушит связь. Для объектного хранилища сохраняйте ту же структуру под префиксом задачи и делайте эти URL‑ы доступными потребителю XAML. Перепроверьте готовый ZIP, чтобы убедиться в правильных именах записей и байтах ресурсов, и загрузите репрезентативные слайды в целевую XAML‑среду, чтобы подтвердить корректность разрешения изображений.

## **Часто задаваемые вопросы**

**Как гарантировать предсказуемый набор шрифтов, если оригинальный шрифт недоступен на машине?**  
Вызовите [setDefaultRegularFont](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveoptions/#setDefaultRegularFont) у [XamlOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/) — это шрифт‑замена, используемый при экспорте при отсутствии оригинального. Это не гарантирует, что сгенерированный XAML будет ссылаться на шрифт‑замену или что шрифт будет доступен на целевой машине. Убедитесь, что шрифты, указанные в XAML, присутствуют в окружении, где он будет отображён.

**Предназначен ли экспортированный XAML только для WPF, или его можно использовать и в других стэках XAML?**  
Aspose.Slides экспортирует WPF‑XAML через публичный API. Совместимость с другими стэками XAML, такими как UWP и Xamarin.Forms, не гарантируется. Проверьте сгенерированную разметку в целевой среде.

**Поддерживаются ли скрытые слайды и как предотвратить их экспорт по умолчанию?**  
По умолчанию скрытые слайды не включаются. Управлять этим можно с помощью [setExportHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/#setExportHiddenSlides) в [XamlOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/) — оставьте параметр выключенным, если экспорт скрытых слайдов не требуется.