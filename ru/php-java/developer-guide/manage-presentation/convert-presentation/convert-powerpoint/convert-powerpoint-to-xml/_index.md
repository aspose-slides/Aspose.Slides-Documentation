---
title: Конвертировать презентации PowerPoint в XML в PHP
linktitle: PowerPoint в XML
type: docs
weight: 145
url: /ru/php-java/convert-powerpoint-to-xml/
keywords:
- конвертировать PowerPoint в XML
- конвертировать презентацию в XML
- PPT в XML
- PPTX в XML
- ODP в XML
- Презентация PowerPoint XML
- SaveFormat.Xml
- сохранить презентацию как XML
- экспортировать презентацию в XML
- XML поток
- PHP
- Aspose.Slides
description: "Конвертировать презентации PowerPoint и OpenDocument в файлы PowerPoint XML или потоки в PHP с помощью Aspose.Slides для PHP через Java."
---
## **Обзор**

Aspose.Slides for PHP via Java может преобразовывать презентации PowerPoint в формат PowerPoint XML Presentation. Вывод в XML полезен, когда требуется текстовое представление для анализа структуры презентации, устранения неполадок в сгенерированных документах, сравнения результатов в автоматических тестах или интеграции с рабочим процессом, который использует XML вместо пакета презентаций.

Используйте метод [Presentation::save](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/) с значением `Xml` из перечисления [SaveFormat](https://reference.aspose.com/slides/ru/php-java/aspose.slides/saveformat/). Вы можете записать результат напрямую в файл или в поток.

{{% alert color="info" title="Note" %}}
`SaveFormat::Xml` создает презентацию PowerPoint XML. Он не извлекает отдельные части Office Open XML, хранящиеся внутри пакета PPTX. Если нужны точные части пакета PPTX, такие как `ppt/presentation.xml` или отдельные XML‑файлы слайдов, следует исследовать сам пакет PPTX.
{{% /alert %}}

## **Преобразование презентации в XML-файл**

Загрузите исходную презентацию с помощью класса [Presentation](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/) и затем передайте путь вывода и `SaveFormat::Xml` в [Presentation::save](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/). Источником может быть любой поддерживаемый формат загрузки, например PPT, PPTX или ODP.

Ниже приведён пример, который преобразует презентацию PPTX в XML‑файл:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$inputPath = __DIR__ . DIRECTORY_SEPARATOR . "presentation.pptx";
$outputPath = __DIR__ . DIRECTORY_SEPARATOR . "presentation.xml";
$presentation = new Presentation($inputPath);
try {
    $presentation->save($outputPath, SaveFormat::Xml);
} finally {
    $presentation->dispose();
}
```

## **Запись XML-вывода в поток**

Используйте перегруженный вариант [Presentation::save](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/), когда XML должен оставаться в памяти или передаваться другому компоненту, например веб‑службе, поставщику хранилища или конвейеру обработки XML. Ниже пример записывает результат в [ByteArrayOutputStream](https://docs.oracle.com/javase/8/docs/api/java/io/ByteArrayOutputStream.html) и получает сформированный XML в виде массива байтов:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$inputPath = __DIR__ . DIRECTORY_SEPARATOR . "presentation.pptx";
$presentation = new Presentation($inputPath);
try {
    $xmlStream = new Java("java.io.ByteArrayOutputStream");
    try {
        $presentation->save($xmlStream, SaveFormat::Xml);
        $xmlBytes = $xmlStream->toByteArray();

        // Передайте $xmlBytes следующему компоненту в рабочем процессе.
    } finally {
        $xmlStream->close();
    }
} finally {
    $presentation->dispose();
}
```

`ByteArrayOutputStream` хранит все сгенерированные данные в памяти, поэтому перед вызовом `toByteArray` не требуется сбрасывать позицию.

## **Сравнение XML с форматами презентаций и экспорта**

Выберите формат вывода в зависимости от того, как будет использоваться результат:

| Формат | Вывод | Типичное использование |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | Презентация PowerPoint XML | Анализ структуры, устранение неполадок, сравнение сгенерированных данных и интеграция на основе XML |
| PPT (`.ppt`) | Устаревший двоичный файл презентации | Совместимость со старыми рабочими процессами PowerPoint |
| PPTX (`.pptx`) | Пакет Office Open XML, содержащий несколько частей | Обычное редактирование PowerPoint и обмен презентациями |
| PDF или TIFF | Страницы фиксированного макета или многостраничное изображение | Просмотр, печать и архивирование |
| PNG, JPEG или SVG | Сформированное представление отдельного слайда | Эскизы, превью и графические ресурсы |
| HTML или HTML5 | Веб‑ориентированный вывод презентации | Просмотр в браузере и публикация в вебе |

В отличие от PPT и PPTX, вывод в XML предназначен в первую очередь для инспекции и рабочих процессов, ориентированных на данные. В отличие от PDF, TIFF, HTML и форматов изображений слайдов, он представляет данные презентации, а не рендерит слайды как страницы или визуальные ресурсы. В таблице [поддерживаемых форматов файлов](/slides/ru/php-java/supported-file-formats/) указано, что PowerPoint XML Presentation доступен только для сохранения, поэтому не используйте его, если рабочий процесс требует загрузки экспортированного файла обратно в Aspose.Slides для дальнейшего редактирования.

## **FAQ**

**Является ли `SaveFormat::Xml` тем же, что сохранение файла PPTX?**

Нет. PPTX — это пакет, содержащий несколько частей Office Open XML, тогда как `SaveFormat::Xml` создаёт файл презентации PowerPoint XML.

**Могу ли я сохранить XML-вывод без создания файла на диске?**

Да. Передайте поток с возможностью записи в [Presentation::save](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/). Например, используйте [ByteArrayOutputStream](https://docs.oracle.com/javase/8/docs/api/java/io/ByteArrayOutputStream.html) для обработки в памяти.

**Может ли Aspose.Slides загрузить экспортированный XML-файл снова?**

Нет. Презентация PowerPoint XML в настоящее время поддерживается только для сохранения, но не для загрузки. Для обратного редактирования используйте PPTX или другой поддерживаемый формат презентации.

**Преобразует ли XML каждый слайд в страницу или изображение?**

Нет. Преобразование в XML записывает структурированные данные презентации. Для вывода страниц используйте PDF или TIFF, а для отдельных изображений слайдов — PNG, JPEG или SVG.