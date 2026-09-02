---
title: Конвертировать презентации PowerPoint в Markdown на JavaScript
linktitle: PowerPoint в Markdown
type: docs
weight: 140
url: /ru/nodejs-java/convert-powerpoint-to-markdown/
keywords:
- конвертировать PowerPoint
- конвертировать презентацию
- конвертировать слайд
- конвертировать PPT
- конвертировать PPTX
- PowerPoint в MD
- презентация в MD
- слайд в MD
- PPT в MD
- PPTX в MD
- сохранить PowerPoint как Markdown
- сохранить презентацию как Markdown
- сохранить слайд как Markdown
- сохранить PPT как MD
- сохранить PPTX как MD
- экспортировать PPT в MD
- экспортировать PPTX в MD
- экспорт изображений в Markdown
- ссылки на изображения CDN
- PowerPoint
- презентация
- Markdown
- Node.js
- JavaScript
- Aspose.Slides
description: "Конвертировать презентации PPT и PPTX в Markdown на JavaScript и контролировать, где сохраняются и как ссылаются экспортированные растровые, метафайловые и SVG‑изображения."
---
## **Обзор**

Aspose.Slides for Node.js via Java может конвертировать презентации PPT и PPTX в Markdown для документации, статических сайтов, миграции контента и рабочих процессов контроля версий. Вы можете выбрать вариант Markdown, контролировать способ рендеринга содержимого слайдов и решать, где сохранять экспортируемые изображения и как генерировать ссылки в Markdown.

По умолчанию экспорт в Markdown использует только текстовый вывод. Чтобы экспортировать визуальное содержимое, задайте тип экспорта методом [MarkdownSaveOptions.setExportType](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/markdownsaveoptions/) со значением `Sequential` или `Visual` из перечисления [MarkdownExportType](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/markdownexporttype/). `Sequential` рендерит элементы слайда по отдельности и в порядке их следования, тогда как `Visual` сохраняет сгруппированные элементы вместе, чтобы сохранить их визуальные взаимоотношения. Значение `TextOnly` не генерирует ресурсы изображений, поэтому обратные вызовы сохранения изображений не вызываются в этом режиме.

## **Преобразование презентации в Markdown**

Загрузите исходный файл с помощью класса [Presentation](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/) и затем вызовите метод [Presentation.save](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/) с параметром `Md` из перечисления [SaveFormat](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/saveformat/).

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    presentation.save("presentation.md", aspose.slides.SaveFormat.Md);
} finally {
    presentation.dispose();
}
```

## **Выбор варианта Markdown**

Метод [MarkdownSaveOptions.setFlavor](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/markdownsaveoptions/) управляет спецификацией Markdown, используемой для вывода. Перечисление [Flavor](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/flavor/) включает CommonMark, GitHub Flavored Markdown и другие поддерживаемые варианты.

Следующий пример экспортирует презентацию в формате CommonMark:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    var options = new aspose.slides.MarkdownSaveOptions();
    options.setFlavor(aspose.slides.Flavor.CommonMark);

    presentation.save("presentation.md", aspose.slides.SaveFormat.Md, options);
} finally {
    presentation.dispose();
}
```

## **Экспорт изображений с использованием поведения по умолчанию для локального сохранения**

Класс [MarkdownSaveOptions](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/markdownsaveoptions/) предоставляет два метода для настройки локального сохранения изображений:

- [setBasePath](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/markdownsaveoptions/) задает базовый каталог для документа Markdown и его ресурсов.
- [setImagesSaveFolderName](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/markdownsaveoptions/) задает подпапку для изображений. Значение по умолчанию — `Images`.

Следующий пример рендерит визуальное содержимое, сохраняет изображения в `output/assets` и создает относительные ссылки на изображения в документе Markdown:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const fs = require("fs");
const path = require("path");

const outputDirectory = "output";
fs.mkdirSync(outputDirectory, { recursive: true });

var presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    var options = new aspose.slides.MarkdownSaveOptions();
    options.setExportType(aspose.slides.MarkdownExportType.Visual);
    options.setBasePath(outputDirectory);
    options.setImagesSaveFolderName("assets");

    const markdownPath = path.join(outputDirectory, "presentation.md");
    presentation.save(markdownPath, aspose.slides.SaveFormat.Md, options);
} finally {
    presentation.dispose();
}
```

Это поведение также используется как резервный вариант, когда пользовательский обработчик сохранения изображений возвращает `false`.

## **Настройка сохранения изображений и ссылок Markdown**

Используйте метод [MarkdownSaveOptions.setImageSaving](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/markdownsaveoptions/) для регистрации обратного вызова для несвязанного SVG‑битмапа и ресурсов метафайлов, генерируемых при экспорте в Markdown. Его обратный вызов `MarkdownImageSavingHandler` получает объект [IImage](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/iimage/), значение [ImageFormat](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/imageformat/) и сгенерированную ссылку Markdown в виде массива из одного элемента. Сохраните или загрузите изображение в указанном формате и замените `link[0]` ссылкой, которая должна появиться в выводе Markdown.

Ресурсы, генерируемые в формате SVG, обрабатываются отдельно. Зарегистрируйте обратный вызов с помощью метода [MarkdownSaveOptions.setSvgImageSaving](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/markdownsaveoptions/). Его обратный вызов `MarkdownSvgImageSavingHandler` получает объект `ISvgImage` и массив `link` из одного элемента. У SVG нет аргумента `ImageFormat`; вместо этого запишите или загрузите его XML‑данные, полученные методом `ISvgImage.getSvgData`. В зависимости от режима экспорта и визуального группирования SVG в исходной презентации может быть растеризован или объединён с другим содержимым; полученный нерисованный ресурс затем передаётся в обратный вызов сохранения изображения. Регистрируйте оба обратных вызова, когда каждый экспортируемый визуальный ресурс требует пользовательской обработки.

В Node.js реализации этих интерфейсов обратных вызовов создаются с помощью `java.newProxy`.

Возврат значения из обработчика определяет, кто обрабатывает изображение:

- Верните `true`, если обработчик сохранил, загрузил, преобразовал или иначе обработал изображение и присвоил допустимое значение `link[0]`. Aspose.Slides запишет это значение в документ Markdown и не будет выполнять сохранение по умолчанию.
- Верните `false`, чтобы позволить Aspose.Slides сохранить изображение локально и сгенерировать ссылку в соответствии со значениями, установленными в [MarkdownSaveOptions.setBasePath](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/markdownsaveoptions/) и [MarkdownSaveOptions.setImagesSaveFolderName](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/markdownsaveoptions/).

{{% alert color="warning" title="Important" %}}
Обработчик, который возвращает `true`, берёт на себя ответственность за изображение. Если он возвращает `true` без назначения корректной, непустой ссылки, экспорт завершится с `InvalidOperationException`.
{{% /alert %}}

### **Сохранение изображений в каталог CDN‑origin и использование внешних URL**

В следующем примере `cdn-origin/presentations/quarterly-report` рассматривается как смонтированный или синхронизированный каталог CDN‑origin. Каждый обработчик извлекает сгенерированное имя файла, сохраняет изображение в этот пользовательский каталог и заменяет локальную ссылку на публичный URL CDN. Сам пример не выполняет сетевую загрузку: URL становится действительным только после монтирования каталога как CDN‑origin или публикации его файлов в CDN. Для объектного хранилища замените запись в файловой системе на операцию загрузки SDK хранилища и присвойте `link[0]` только после успешной загрузки.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");
const fs = require("fs");
const path = require("path");

const outputDirectory = "output";
const publicBaseUrl = "https://cdn.example.com/presentations/quarterly-report";
const storageDirectory = path.join("cdn-origin", "presentations", "quarterly-report");
fs.mkdirSync(outputDirectory, { recursive: true });
fs.mkdirSync(storageDirectory, { recursive: true });

const getFileNameFromLink = generatedLink => {
    const urlCompatibleLink = String(generatedLink).replace(/\\/g, "/");
    return path.posix.basename(urlCompatibleLink);
};
const buildPublicUrl = fileName => publicBaseUrl + "/" + encodeURIComponent(fileName);

const imageSavingHandler = java.newProxy("com.aspose.slides.MarkdownSaveOptions$MarkdownImageSavingHandler", {
    invoke: function(image, format, link) {
        if (image.getWidth() < 128 || image.getHeight() < 128) {
            return false;
        }

        const fileName = getFileNameFromLink(link[0]);
        const storagePath = path.join(storageDirectory, fileName);
        image.save(storagePath, format);
        link[0] = buildPublicUrl(fileName);
        return true;
    }
});

const svgImageSavingHandler = java.newProxy("com.aspose.slides.MarkdownSaveOptions$MarkdownSvgImageSavingHandler", {
    invoke: function(svgImage, link) {
        const fileName = getFileNameFromLink(link[0]);
        const storagePath = path.join(storageDirectory, fileName);
        fs.writeFileSync(storagePath, svgImage.getSvgData());
        link[0] = buildPublicUrl(fileName);
        return true;
    }
});

var presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    var options = new aspose.slides.MarkdownSaveOptions();
    options.setExportType(aspose.slides.MarkdownExportType.Visual);
    options.setBasePath(outputDirectory);
    options.setImagesSaveFolderName("fallback-images");
    options.setImageSaving(imageSavingHandler);
    options.setSvgImageSaving(svgImageSavingHandler);

    const markdownPath = path.join(outputDirectory, "presentation.md");
    presentation.save(markdownPath, aspose.slides.SaveFormat.Md, options);
} finally {
    presentation.dispose();
}
```

Обработчик битмапа намеренно возвращает `false` для изображений размером менее 128 × 128 пикселей, поэтому Aspose.Slides сохраняет такие изображения в `output/fallback-images` используя поведение по умолчанию. Более крупные битмапы, метафайлы и SVG‑ресурсы обрабатываются пользовательским кодом. Например, локальная ссылка `fallback-images/image1.png` превращается в `https://cdn.example.com/presentations/quarterly-report/image1.png`. Обработчики используют пути операционной системы только при записи файлов; ссылки в Markdown используют прямые слеши и URL‑экранированные имена файлов. Применяйте то же правило при построении относительных ссылок: используйте `/`, а не разделитель, характерный для платформы.

## **FAQ**

**Можно ли одним обработчиком обрабатывать как растровые изображения, так и SVG?**

Нет. Используйте [MarkdownSaveOptions.setImageSaving](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/markdownsaveoptions/) для битмапов и метафайлов и [MarkdownSaveOptions.setSvgImageSaving](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/markdownsaveoptions/) для ресурсов SVG. Первый предоставляет объект [IImage](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/iimage/) и значение [ImageFormat](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/imageformat/); второй — объект `ISvgImage`, данные которого можно прочитать через `ISvgImage.getSvgData`. SVG‑источник, растеризованный во время экспорта, обрабатывается обработчиком сохранения изображения.

**Что происходит, когда обработчик сохранения изображения возвращает `false`?**

Aspose.Slides использует своё поведение по умолчанию для локального сохранения. Расположение изображения и сгенерированная ссылка управляются значениями, установленными в [MarkdownSaveOptions.setBasePath](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/markdownsaveoptions/) и [MarkdownSaveOptions.setImagesSaveFolderName](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/markdownsaveoptions/).

**Может ли обработчик предоставить URL без локального сохранения изображения?**

Да. Обработчик может загрузить изображение в объектное хранилище или передать его в другой сервис, присвоить полученный URL `link[0]` и вернуть `true`. Обработчик обязан выполнить всю обработку сам; возврат `true` отключает сохранение по умолчанию.

**Почему экспорт Markdown бросает `InvalidOperationException` из обработчика?**

Это происходит, когда обработчик возвращает `true`, но не предоставляет корректную ссылку. Присвойте `link[0]` относительный путь или внешний URL, который должен быть записан в Markdown, перед возвратом `true`.

**Какой разделитель пути должны использовать ссылки на изображения?**

В ссылках Markdown и URL используйте прямые слеши. `path.join` применяйте только для построения путей файловой системы, а Markdown‑ссылку формируйте отдельно.

**Сохраняются ли гиперссылки при экспорте в Markdown?**

Да. Текстовые [гиперссылки](/slides/ru/nodejs-java/manage-hyperlinks/) сохраняются как обычные ссылки Markdown. [Переходы](/slides/ru/nodejs-java/slide-transition/) и [анимации](/slides/ru/nodejs-java/powerpoint-animation/) слайдов не конвертируются.

**Можно ли конвертировать презентации в Markdown параллельно?**

Можно обрабатывать разные файлы презентаций параллельно, но не используйте один и тот же экземпляр [Presentation](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/) в нескольких потоках. Следуйте [рекомендациям по многопоточности](/slides/ru/nodejs-java/multithreading/) и создавайте отдельный экземпляр для каждого файла.