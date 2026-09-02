---
title: Конвертировать презентации PowerPoint в XML в .NET
linktitle: PowerPoint в XML
type: docs
weight: 145
url: /ru/net/convert-powerpoint-to-xml/
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
- поток XML
- .NET
- C#
- Aspose.Slides
description: "Конвертировать презентации PowerPoint и OpenDocument в файлы PowerPoint XML или потоки на C# с помощью Aspose.Slides для .NET."
---
## **Обзор**

Aspose.Slides for .NET может конвертировать презентации PowerPoint в формат PowerPoint XML Presentation. Вывод в формате XML полезен, когда вам требуется текстовое представление для просмотра структуры презентации, устранения неполадок сгенерированных документов, сравнения результатов в автоматических тестах или интеграции с рабочим процессом, который использует XML вместо пакета презентации.

Используйте метод [Presentation.Save](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/save/) с значением `Xml` из перечисления [SaveFormat](https://reference.aspose.com/slides/ru/net/aspose.slides.export/saveformat/). Вы можете записать результат напрямую в файл или в поток.

{{% alert color="info" title="Примечание" %}}
`SaveFormat.Xml` создаёт PowerPoint XML Presentation. Он не извлекает отдельные части Office Open XML, хранящиеся в пакете PPTX. Если вам нужны точные части пакета PPTX, такие как `ppt/presentation.xml` или отдельные XML‑файлы слайдов, изучайте сам пакет PPTX.
{{% /alert %}}

## **Конвертировать презентацию в XML‑файл**

Загрузите исходную презентацию с помощью класса [Presentation](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/) и затем передайте путь вывода и `SaveFormat.Xml` в [Presentation.Save](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/save/). Источник может быть в любом поддерживаемом формате загрузки, например PPT, PPTX или ODP.

Следующий пример конвертирует презентацию PPTX в XML‑файл:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
presentation.Save("presentation.xml", SaveFormat.Xml);
```

## **Записать вывод XML в поток**

Используйте перегрузку метода [Presentation.Save](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/save/) для записи в поток, когда XML должен оставаться в памяти или быть передан другому компоненту, например веб‑службе, поставщику хранилища или конвейеру обработки XML. В следующем примере результат записывается в [MemoryStream](https://learn.microsoft.com/en-us/dotnet/api/system.io.memorystream) и переходит в начало для последующего чтения:

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
using var xmlStream = new MemoryStream();

presentation.Save(xmlStream, SaveFormat.Xml);
xmlStream.Position = 0;

// Передайте xmlStream следующему компоненту в рабочем процессе.
```

## **Сравнение XML с форматами презентаций и экспорта**

Выберите формат вывода в зависимости от того, как будет использоваться результат:

| Формат | Вывод | Типичное использование |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | Презентация PowerPoint XML | Просмотр структуры, устранение неполадок, сравнение сгенерированного вывода и интеграция на основе XML |
| PPT (`.ppt`) | Устаревший двоичный файл презентации | Совместимость со старыми рабочими процессами PowerPoint |
| PPTX (`.pptx`) | Пакет Office Open XML, содержащий несколько частей | Обычное редактирование PowerPoint и обмен презентациями |
| PDF или TIFF | Страницы фиксированного макета или многократное изображение | Просмотр, печать и архивирование |
| PNG, JPEG или SVG | Визуальное представление отдельного слайда | Эскизы, предварительный просмотр и графические ресурсы |
| HTML или HTML5 | Веб‑ориентированный вывод презентации | Просмотр в браузере и публикация в веб |

В отличие от PPT и PPTX, вывод XML предназначен в первую очередь для инспекции и данных‑ориентированных рабочих процессов. В отличие от PDF, TIFF, HTML и форматов изображений слайдов, он представляет данные презентации, а не рендерит слайды как страницы или визуальные ресурсы. Таблица [поддерживаемых форматов файлов](/slides/ru/net/supported-file-formats/) указывает PowerPoint XML Presentation как формат только для сохранения, поэтому не используйте его, если рабочий процесс требует загрузки экспортированного файла обратно в Aspose.Slides для дальнейшего редактирования.

## **FAQ**

**Является ли `SaveFormat.Xml` тем же, что сохранение файла PPTX?**

Нет. PPTX — это пакет, содержащий несколько частей Office Open XML, тогда как `SaveFormat.Xml` создаёт файл PowerPoint XML Presentation.

**Можно ли сохранить вывод XML без создания файла на диске?**

Да. Передайте поток для записи в [Presentation.Save](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/save/). Например, используйте [MemoryStream](https://learn.microsoft.com/en-us/dotnet/api/system.io.memorystream) для обработки в памяти.

**Можно ли загрузить экспортированный XML‑файл обратно в Aspose.Slides?**

Нет. PowerPoint XML Presentation в текущий момент поддерживается только для сохранения, но не для загрузки. Используйте PPTX или другой поддерживаемый формат презентации, если требуется обратное редактирование.

**Конвертирует ли XML каждый слайд в страницу или изображение?**

Нет. Конвертация в XML записывает структурированные данные презентации. Для вывода в виде страниц используйте PDF или TIFF, а для отдельных изображений слайдов — PNG, JPEG или SVG.