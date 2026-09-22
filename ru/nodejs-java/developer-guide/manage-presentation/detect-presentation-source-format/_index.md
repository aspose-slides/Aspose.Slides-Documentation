---
title: Определить исходный формат презентации в Node.js
linktitle: Исходный формат
type: docs
weight: 35
url: /ru/nodejs-java/detect-presentation-source-format/
keywords:
- исходный формат
- определить формат презентации
- PowerPoint
- OpenDocument
- презентация
- PPT
- PPTX
- Node.js
- JavaScript
- Aspose.Slides
description: "Прочитайте исходный формат загруженной презентации в Node.js с помощью Aspose.Slides for Node.js via Java, сравните API обнаружения и обработайте файлы, потоки и устаревшие форматы."
---
## **Обзор**

После загрузки презентации вызовите метод [Presentation.getSourceFormat](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/#getSourceFormat), чтобы определить её исходный формат. Используйте его, когда дальнейшая обработка зависит от формата, из которого был загружен текущий экземпляр.

Исходный формат отличается от [SaveFormat](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/saveformat/) выбранного для выходного файла. Сохранение в другой формат не изменяет исходный формат существующего экземпляра.

## **Чтение исходного формата файла**

Для этого примера требуется существующий файл `sample.pptx`. Он загружает файл и выбирает политику обработки приложения, используя [Presentation.getSourceFormat](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/#getSourceFormat), а не имя файла. Измените путь входного файла, чтобы попробовать другие форматы. Пример выводит выбранную политику; замените сообщения своей логикой приложения.

```javascript
const aspose = require("aspose.slides.via.java");

const presentation = new aspose.Presentation("sample.pptx");
try {
    switch (presentation.getSourceFormat()) {
        case aspose.SourceFormat.Ppt:
        case aspose.SourceFormat.Pps:
        case aspose.SourceFormat.Pot:
            console.log("Use the legacy PowerPoint processing policy.");
            break;
        case aspose.SourceFormat.Pptx:
            console.log("Use the standard PPTX processing policy.");
            break;
        default:
            console.log("Use the general policy for source format " + presentation.getSourceFormat() + ".");
            break;
    }
} finally {
    presentation.dispose();
}
```

## **Определение поддерживаемых значений**

Класс [SourceFormat](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/sourceformat/) определяет целочисленные константы, которые различают следующие форматы презентаций. Приведённые ниже расширения являются общепринятыми, а не восстановлением оригинального имени файла.

| SourceFormat value | Extension | Format |
| --- | --- | --- |
| `Ppt` | `.ppt` | Презентация PowerPoint 97–2003 |
| `Pptx` | `.pptx` | Презентация Office Open XML |
| `Pptm` | `.pptm` | Презентация Office Open XML с макросами |
| `Pps` | `.pps` | Слайд-шоу PowerPoint 97–2003 |
| `Ppsx` | `.ppsx` | Слайд-шоу Office Open XML |
| `Ppsm` | `.ppsm` | Слайд-шоу Office Open XML с макросами |
| `Pot` | `.pot` | Шаблон PowerPoint 97–2003 |
| `Potx` | `.potx` | Шаблон Office Open XML |
| `Potm` | `.potm` | Шаблон Office Open XML с макросами |
| `Odp` | `.odp` | Презентация OpenDocument |
| `Otp` | `.otp` | Шаблон презентации OpenDocument |
| `Fodp` | `.fodp` | Презентация Flat XML ODF |
| `Xml` | `.xml` | Презентация PowerPoint XML |

## **Чтение исходного формата из потока**

Для этого примера требуется существующий файл `sample.pps`. Чтение его байтов в поток памяти имитирует ввод, полученный без имени файла, например, значение из базы данных или загруженный массив байтов. Конструктор [Presentation](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/) принимает только поток.

```javascript
const aspose = require("aspose.slides.via.java");
const java = require("java");
const fs = require("fs");

const buffer = fs.readFileSync("sample.pps");
const bytes = java.newArray("byte", Array.from(buffer));
const stream = java.newInstanceSync("java.io.ByteArrayInputStream", bytes);
try {
    const presentation = new aspose.Presentation(stream);
    try {
        console.log("Source format: " + presentation.getSourceFormat());
    } finally {
        presentation.dispose();
    }
} finally {
    stream.close();
}
```

PPT, PPS и POT используют один и тот же базовый бинарный формат. При загрузке по пути к файлу расширение может помочь различить слайд-шоу или шаблон. Без имени файла древнее содержимое PPS и POT может быть определено как `SourceFormat.Ppt`; пример PPS выше выводит целочисленное значение `SourceFormat.Ppt`.

Если вашему приложению необходимо сохранять различие, храните оригинальное имя файла или метаданные подтипа отдельно. Расширение может служить полезной подсказкой для этих устаревших подтипов, но не должно быть единственной основой для определения произвольного содержимого презентации.

## **Сравнение обнаружения до и после загрузки**

Используйте [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentationfactory/#getPresentationInfo) и [PresentationInfo.getLoadFormat](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentationinfo/#getLoadFormat), когда необходимо проанализировать файл до загрузки полной модели объектов презентации. Используйте [Presentation.getSourceFormat](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/#getSourceFormat), когда экземпляр уже существует.

Для этого примера требуется `sample.pptx`; он выводит целочисленные значения `LoadFormat.Pptx` и `SourceFormat.Pptx` соответственно. В продакшн‑среде выбирайте API, соответствующее вашему этапу обработки; уже загруженная презентация не требует повторной проверки только для получения её исходного формата.

```javascript
const aspose = require("aspose.slides.via.java");

const path = "sample.pptx";
const information = aspose.PresentationFactory.getInstance().getPresentationInfo(path);
console.log("Before loading: " + information.getLoadFormat());

const presentation = new aspose.Presentation(path);
try {
    console.log("After loading: " + presentation.getSourceFormat());
} finally {
    presentation.dispose();
}
```

Результаты используют константы из разных классов: [LoadFormat](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/loadformat/) и [SourceFormat](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/sourceformat/). Не сравнивайте их числовые значения и не предполагайте, что каждый формат имеет одинаковые результаты обнаружения. PowerPoint XML может быть определён как `LoadFormat.Unknown` до загрузки и как `SourceFormat.Xml` после загрузки.

## **Разделение исходного и выходного форматов**

Для этого примера требуется `sample.pptx` и создаётся файл `converted.odp`. Он выводит целочисленное значение `SourceFormat.Pptx` как до, так и после сохранения исходного экземпляра. Только новый экземпляр, загруженный из ODP‑вывода, сообщает `Odp`.

```javascript
const aspose = require("aspose.slides.via.java");

const presentation = new aspose.Presentation("sample.pptx");
try {
    console.log("Before saving: " + presentation.getSourceFormat());

    presentation.save("converted.odp", aspose.SaveFormat.Odp);
    console.log("After saving: " + presentation.getSourceFormat());

    const reopened = new aspose.Presentation("converted.odp");
    try {
        console.log("Reopened output: " + reopened.getSourceFormat());
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

Презентация, созданная с нуля via `new Presentation()`, сообщает `SourceFormat.Pptx`. У неё нет входного файла: это значение по умолчанию для только что созданного экземпляра, а не свидетельство того, что был загружен файл PPTX. При необходимости различать создание и загрузку отслеживайте этот факт отдельно в приложении.

## **Отображение исходного формата в расширение**

Следующий пример требует `sample.pptx`. Он сопоставляет каждое из текущих поддерживаемых значений [SourceFormat](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/sourceformat/) с обычным расширением без разбора имени входного файла. Запасной вариант предотвращает бесшумное присваивание расширения нераспознанному значению.

```javascript
const aspose = require("aspose.slides.via.java");

const presentation = new aspose.Presentation("sample.pptx");
try {
    let extension;
    switch (presentation.getSourceFormat()) {
        case aspose.SourceFormat.Ppt:
            extension = ".ppt";
            break;
        case aspose.SourceFormat.Pptx:
            extension = ".pptx";
            break;
        case aspose.SourceFormat.Pptm:
            extension = ".pptm";
            break;
        case aspose.SourceFormat.Pps:
            extension = ".pps";
            break;
        case aspose.SourceFormat.Ppsx:
            extension = ".ppsx";
            break;
        case aspose.SourceFormat.Ppsm:
            extension = ".ppsm";
            break;
        case aspose.SourceFormat.Pot:
            extension = ".pot";
            break;
        case aspose.SourceFormat.Potx:
            extension = ".potx";
            break;
        case aspose.SourceFormat.Potm:
            extension = ".potm";
            break;
        case aspose.SourceFormat.Odp:
            extension = ".odp";
            break;
        case aspose.SourceFormat.Otp:
            extension = ".otp";
            break;
        case aspose.SourceFormat.Fodp:
            extension = ".fodp";
            break;
        case aspose.SourceFormat.Xml:
            extension = ".xml";
            break;
        default:
            extension = null;
            break;
    }

    console.log(extension != null ? extension : "No extension mapping is available.");
} finally {
    presentation.dispose();
}
```

Это сопоставление не преобразует файл и не восстанавливает устаревший подтип PPS/POT, утерянный при загрузке из потока. Для реального сохранения явно выбирайте [SaveFormat](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/saveformat/) либо используйте конвертацию, показанную в разделе [Save Presentations in Their Original Format](/slides/ru/nodejs-java/save-presentation/#save-presentations-in-their-original-format).

## **Проверка форматов сохранением и повторным открытием**

Этот автономный пример создаёт презентацию и записывает три файла в рабочий каталог, перезаписывая файлы с теми же именами. Он повторно открывает каждый вывод как по пути, так и через поток памяти. Для PPTX и ODP оба способа сообщают сохранённый формат. Для PPS загрузка по пути сообщает `Pps`, а загрузка тех же байтов без имени файла — `Ppt`.

```javascript
const aspose = require("aspose.slides.via.java");
const java = require("java");
const fs = require("fs");

const presentation = new aspose.Presentation();
try {
    const formats = [aspose.SaveFormat.Pptx, aspose.SaveFormat.Odp, aspose.SaveFormat.Pps];
    const extensions = ["pptx", "odp", "pps"];

    for (let i = 0; i < formats.length; i++) {
        const path = "roundtrip." + extensions[i];
        presentation.save(path, formats[i]);

        const fromFile = new aspose.Presentation(path);
        try {
            const buffer = fs.readFileSync(path);
            const bytes = java.newArray("byte", Array.from(buffer));
            const stream = java.newInstanceSync("java.io.ByteArrayInputStream", bytes);
            try {
                const fromStream = new aspose.Presentation(stream);
                try {
                    console.log(extensions[i] + ": file=" + fromFile.getSourceFormat() + ", stream=" + fromStream.getSourceFormat());
                } finally {
                    fromStream.dispose();
                }
            } finally {
                stream.close();
            }
        } finally {
            fromFile.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

В следующей таблице суммировано определение исходного формата для презентаций с совпадающими расширениями. Имена обозначают константы; примеры JavaScript выводят их целочисленные значения:

| Сохранённый формат | SourceFormat по пути к файлу | SourceFormat из безымянного потока |
| --- | --- | --- |
| PPT | `Ppt` | `Ppt` |
| PPTX, PPTM | `Pptx`, `Pptm` соответственно | То же, что и путь к файлу |
| PPS | `Pps` | `Ppt` |
| PPSX, PPSM | `Ppsx`, `Ppsm` соответственно | То же, что и путь к файлу |
| POT | `Pot` | `Ppt` |
| POTX, POTM | `Potx`, `Potm` соответственно | То же, что и путь к файлу |
| ODP, OTP | `Odp`, `Otp` соответственно | То же, что и путь к файлу |
| FODP | `Fodp` | `Fodp` |
| PowerPoint XML | `Xml` | `Xml` |

Содержимое PPS/POT определяется как `Ppt` для безымянных потоков. Таблица описывает определение формата, а не сохранение всех характеристик презентации при конвертации.

## **Вопросы и ответы**

**Сохраняет ли сохранение в ODP изменение исходного формата презентации, загруженной из PPTX?**

Нет. Существующий экземпляр по‑прежнему сообщает `Pptx`. Экземпляр, загруженный из сохранённого файла ODP, сообщает `Odp`.

**Может ли поток всегда различать устаревшую презентацию, слайд‑шоу и шаблон?**

Нет. PPT, PPS и POT используют один и тот же бинарный формат. Храните имя файла или метаданные подтипа отдельно, если требуется различие.

**Какой API следует использовать, если презентация уже загружена?**

Вызовите [Presentation.getSourceFormat](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/#getSourceFormat). Используйте [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentationfactory/#getPresentationInfo) для проверки перед загрузкой.