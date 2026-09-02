---
title: "Преобразовать презентации PowerPoint в XML в JavaScript"
linktitle: "PowerPoint в XML"
type: docs
weight: 145
url: /ru/nodejs-java/convert-powerpoint-to-xml/
keywords:
- "конвертировать PowerPoint в XML"
- "конвертировать презентацию в XML"
- "PPT в XML"
- "PPTX в XML"
- "ODP в XML"
- "PowerPoint XML Presentation"
- "SaveFormat.Xml"
- "сохранить презентацию как XML"
- "экспортировать презентацию в XML"
- "XML поток"
- "Node.js"
- "JavaScript"
- "Aspose.Slides"
description: "Преобразуйте презентации PowerPoint и OpenDocument в файлы или потоки PowerPoint XML в JavaScript с помощью Aspose.Slides for Node.js via Java."
---
## **Обзор**

Aspose.Slides for Node.js via Java может преобразовывать презентации PowerPoint в формат PowerPoint XML Presentation. Вывод в XML полезен, когда нужен текстовый представление для изучения структуры презентации, отладки сгенерированных документов, сравнения результатов в автоматических тестах или интеграции с рабочим процессом, который использует XML вместо пакета презентации.

Используйте метод [Presentation.save](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/#save) со значением `Xml` из перечисления [SaveFormat](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/saveformat/). Вы можете записать результат непосредственно в файл или в поток.

{{% alert color="info" title="Примечание" %}}
`SaveFormat.Xml` создаёт PowerPoint XML Presentation. Он не извлекает отдельные части Office Open XML, хранящиеся внутри пакета PPTX. Если нужны точные части пакета PPTX, такие как `ppt/presentation.xml` или отдельные XML‑файлы слайдов, изучайте сам пакет PPTX.
{{% /alert %}}

## **Преобразовать презентацию в XML‑файл**

Загрузите исходную презентацию с помощью класса [Presentation](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/) и затем передайте путь вывода и `SaveFormat.Xml` в метод [Presentation.save](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/#save). Источник может быть в любом поддерживаемом формате загрузки, например PPT, PPTX или ODP.

Ниже приведён пример, который преобразует презентацию PPTX в XML‑файл:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    presentation.save("presentation.xml", aspose.slides.SaveFormat.Xml);
} finally {
    presentation.dispose();
}
```

## **Записать XML‑вывод в поток**

Используйте перегрузку метода [Presentation.save](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/#save), принимающую поток, когда XML должен оставаться в памяти или передаваться другому компоненту, например веб‑службе, провайдеру хранилища или XML‑конвейеру обработки. В следующем примере результат записывается в Java `ByteArrayOutputStream`, а затем копируется в Node.js `Buffer`:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const xmlStream = java.newInstanceSync("java.io.ByteArrayOutputStream");
    try {
        presentation.save(xmlStream, aspose.slides.SaveFormat.Xml);

        const xmlBuffer = Buffer.from(xmlStream.toByteArray());
        console.log(`XML size: ${xmlBuffer.length} bytes`);

        // Передайте xmlBuffer следующему компоненту в рабочем процессе.
    } finally {
        xmlStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **Сравнение XML с форматами презентаций и экспорта**

Выбирайте формат вывода в зависимости от того, как будет использоваться результат:

| Формат | Вывод | Типичное использование |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | PowerPoint XML Presentation | Анализ структуры, отладка, сравнение сгенерированного вывода и интеграция на основе XML |
| PPT (`.ppt`) | Устаревший бинарный файл презентации | Совместимость со старыми процессами PowerPoint |
| PPTX (`.pptx`) | Пакет Office Open XML, содержащий несколько частей | Обычное редактирование и обмен презентациями PowerPoint |
| PDF или TIFF | Фиксированные страницы или многостраничное изображение | Просмотр, печать и архивирование |
| PNG, JPEG или SVG | Визуальное представление отдельного слайда | Миниатюры, предварительные просмотры и графические ресурсы |
| HTML или HTML5 | Веб‑ориентированный вывод презентации | Просмотр в браузере и публикация в сети |

В отличие от PPT и PPTX, вывод XML предназначен в первую очередь для инспекции и работы с данными. В отличие от PDF, TIFF, HTML и форматов изображений слайдов, он представляет данные презентации, а не рендерит слайды в виде страниц или визуальных ресурсов. Таблица [поддерживаемых форматов файлов](/slides/ru/nodejs-java/supported-file-formats/) указывает, что PowerPoint XML Presentation доступен только для сохранения, поэтому не используйте его, если рабочий процесс требует загрузки экспортированного файла обратно в Aspose.Slides для дальнейшего редактирования.

## **Часто задаваемые вопросы**

**Является ли `SaveFormat.Xml` тем же, что сохранение файла PPTX?**

Нет. PPTX — это пакет, содержащий несколько частей Office Open XML, тогда как `SaveFormat.Xml` создаёт файл PowerPoint XML Presentation.

**Можно ли сохранить XML‑вывод без создания файла на диске?**

Да. Передайте записываемый поток в метод [Presentation.save](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/#save). Например, используйте Java `ByteArrayOutputStream` и скопируйте его данные в Node.js `Buffer` для обработки в памяти.

**Может ли Aspose.Slides загрузить экспортированный XML‑файл снова?**

Нет. PowerPoint XML Presentation в настоящее время поддерживается только для сохранения, но не для загрузки. Для обратного редактирования используйте PPTX или иной поддерживаемый формат презентации.

**Преобразует ли конвертация в XML каждый слайд в страницу или изображение?**

Нет. Конвертация в XML записывает структурированные данные презентации. Для вывода, ориентированного на страницы, используйте PDF или TIFF, а для изображений отдельных слайдов — PNG, JPEG или SVG.