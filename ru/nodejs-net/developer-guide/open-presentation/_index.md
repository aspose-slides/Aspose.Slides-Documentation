---
title: Открытие презентаций в Node.js через .NET
linktitle: Открыть презентацию
type: docs
weight: 20
url: /ru/nodejs-net/open-presentation/
keywords:
- открыть презентацию
- открыть PowerPoint
- открыть PPTX
- открыть PPT
- открыть ODP
- загрузить презентацию
- презентация из Buffer
- количество слайдов
- конвертировать презентацию
- PowerPoint
- OpenDocument
- презентация
- Node.js
- JavaScript
- Aspose.Slides
description: "Откройте PPTX, PPT и ODP презентации в JavaScript с помощью Aspose.Slides для Node.js через .NET: загрузите из пути к файлу или Buffer, прочитайте количество слайдов и сохраните в другом формате."
---
## **Обзор**

Aspose.Slides for Node.js via .NET открывает презентации PowerPoint и OpenDocument, такие как файлы PPTX, PPT и ODP, из пути к файлу или из `Buffer` Node.js. В этой статье показаны оба способа, читается количество слайдов и сохраняется открытая презентация в другом формате.

Примеры ожидают презентацию с именем `sample.pptx` в папке проекта, которую вы настроили в [Установка](/slides/ru/nodejs-net/installation/). Подойдёт любая презентация PowerPoint. Сохраните каждый пример как файл `.js` в папке проекта и запустите его из этой папки с помощью `node`.

{{% alert color="info" title="Note" %}}
Aspose.Slides for Node.js via .NET не имеет собственной справочной документации API. Он отражает API Aspose.Slides для .NET с camelCase‑именами, поэтому ссылки API в этой статье ведут к соответствующим классам и членам в [справочник API Aspose.Slides для .NET](https://reference.aspose.com/slides/ru/net/).
{{% /alert %}}

## **Открытие презентации из файла**

Чтобы открыть презентацию, передайте её путь конструктору [Presentation](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/presentation/). Aspose.Slides определяет формат по содержимому файла, а не по расширению, поэтому тот же код открывает файлы PPTX, PPT и ODP. Относительный путь разрешается относительно текущего рабочего каталога, которым является папка проекта, когда вы запускаете скрипт из неё.

```javascript
const { Presentation } = require("aspose.slides.via.net");

const presentation = new Presentation("sample.pptx");
try {
    console.log("Slide count: " + presentation.slides.count);
} finally {
    presentation.dispose();
}
```

Скрипт выводит количество слайдов в `sample.pptx`, например `Slide count: 9`. Свойство `count` коллекции [slides](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/slides/ru/) включает скрытые слайды. Вызывайте `dispose` в блоке `finally`, как показано, чтобы ресурсы .NET, связанные с презентацией, освобождались даже в случае ошибки кода.

## **Открытие презентации из Buffer**

Когда презентация поступает из базы данных, HTTP‑загрузки или другого источника, предоставляющего байты вместо пути к файлу, передайте `Buffer` Node.js вторым аргументом конструктора и `null` первым. В следующем примере `sample.pptx` читается в буфер, имитируя такой источник:

```javascript
const fs = require("fs");
const { Presentation } = require("aspose.slides.via.net");

const presentationData = fs.readFileSync("sample.pptx");

const presentation = new Presentation(null, presentationData);
try {
    console.log("Slide count: " + presentation.slides.count);
} finally {
    presentation.dispose();
}
```

Скрипт выводит то же количество слайдов, что и в предыдущем примере. Второй аргумент должен быть `Buffer`. Для любого другого типа, например `Uint8Array`, конструктор не выдаёт ошибку; вместо этого создаётся новая презентация с одним пустым слайдом. Сначала преобразуйте другие бинарные типы с помощью `Buffer.from`.

## **Сохранение презентации в другом формате**

Чтобы конвертировать презентацию в другой формат презентации, откройте её и сохраните с другим значением [SaveFormat](https://reference.aspose.com/slides/ru/net/aspose.slides.export/saveformat/). В следующем примере выводится формат, определённый Aspose.Slides, который возвращает свойство [sourceFormat](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/sourceformat/), и презентация сохраняется как OpenDocument презентация:

```javascript
const { Presentation, SaveFormat } = require("aspose.slides.via.net");

const presentation = new Presentation("sample.pptx");
try {
    console.log("Source format: " + presentation.sourceFormat);
    presentation.save("sample.odp", SaveFormat.Odp);
} finally {
    presentation.dispose();
}
```

Скрипт выводит `Source format: Pptx` и записывает `sample.odp`, содержащий те же слайды. `sourceFormat` возвращает `Ppt`, `Pptx` или `Odp`. Чтобы вместо этого сохранить в PDF или в виде изображений, см. [Конвертировать PowerPoint в PDF](/slides/ru/nodejs-net/convert-powerpoint-to-pdf/) и [Конвертировать слайды в изображения](/slides/ru/nodejs-net/convert-slide/).

## **FAQ**

**Как открыть презентацию, защищённую паролем?**

Создайте объект [LoadOptions](https://reference.aspose.com/slides/ru/net/aspose.slides/loadoptions/), задайте его свойство [password](https://reference.aspose.com/slides/ru/net/aspose.slides/loadoptions/password/) и передайте объект третьим аргументом конструктора: `new Presentation("protected.pptx", null, loadOptions)`. Без правильного пароля конструктор выбрасывает ошибку.

**Почему конструктор бросает `Error` с пустым сообщением?**

Когда конструктор `Presentation` в .NET не удаётся, например из‑за отсутствующего файла, неверного формата презентации или требуемого другого пароля, JavaScript получает `Error` с пустым сообщением. Прежде чем открывать файл, проверьте, что он существует относительно рабочего каталога, например с помощью `fs.existsSync`.

**Какие форматы я могу открыть?**

Форматы презентаций PowerPoint и OpenDocument, включая PPT, PPTX, PPS, POT, POTX, PPTM, ODP, OTP и FODP.