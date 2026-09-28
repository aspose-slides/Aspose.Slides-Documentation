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
- XML‑поток
- .NET
- C#
- Aspose.Slides
description: "Конвертировать презентации PowerPoint и OpenDocument в файлы PowerPoint XML или потоки на C# с помощью Aspose.Slides для .NET."
---
## **Обзор**

Aspose.Slides for .NET может преобразовывать презентации PowerPoint в формат PowerPoint XML Presentation. Вывод в XML полезен, когда нужен текстовый представление для исследования структуры презентации, устранения неполадок в сгенерированных документах, сравнения вывода в автоматических тестах или интеграции с workflow, который работает с XML вместо пакета презентации.

Используйте метод [Presentation.Save](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/save/) с значением `Xml` из перечисления [SaveFormat](https://reference.aspose.com/slides/ru/net/aspose.slides.export/saveformat/). Результат можно записать напрямую в файл или в поток.

{{% alert color="info" title="Note" %}}
`SaveFormat.Xml` создаёт PowerPoint XML Presentation. Он не извлекает отдельные части Office Open XML, хранящиеся внутри пакета PPTX. Если нужны точные части пакета PPTX, такие как `ppt/presentation.xml` или отдельные XML‑файлы слайдов, изучайте сам пакет PPTX.
{{% /alert %}}

## **Преобразование презентации в XML‑файл**

Загрузите исходную презентацию с помощью класса [Presentation](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/) и передайте путь вывода и `SaveFormat.Xml` методу [Presentation.Save](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/save/). Источником может быть любой поддерживаемый формат, например PPT, PPTX или ODP.

Ниже приведён пример, который преобразует презентацию PPTX в XML‑файл:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
presentation.Save("presentation.xml", SaveFormat.Xml);
```

## **Запись XML‑вывода в поток**

Используйте перегрузку метода [Presentation.Save](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/save/) для потока, когда XML должен оставаться в памяти или передаваться другому компоненту, например веб‑службе, поставщику хранилища или XML‑обработчику. В следующем примере результат записывается в [MemoryStream](https://learn.microsoft.com/en-us/dotnet/api/system.io.memorystream?view=net-10.0) и перематывается для последующего чтения:

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

Выбирайте формат вывода в зависимости от того, как будет использоваться результат:

| Формат | Вывод | Типичное применение |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | PowerPoint XML Presentation | Исследование структуры, устранение неполадок, сравнение сгенерированного вывода, интеграция на основе XML |
| PPT (`.ppt`) | Устаревший двоичный файл презентации | Совместимость со старыми workflow PowerPoint |
| PPTX (`.pptx`) | Пакет Office Open XML, содержащий несколько частей | Обычное редактирование PowerPoint и обмен презентациями |
| PDF или TIFF | Страницы фиксированного макета или TIFF‑изображения | Просмотр, печать, архивирование |
| PNG, JPEG или SVG | Отрисованное представление отдельного слайда | Миниатюры, превью, графические ресурсы |
| HTML или HTML5 | Веб‑ориентированный вывод презентации | Просмотр в браузере и публикация в Интернете |

В отличие от PPT и PPTX, вывод в XML предназначен преимущественно для инспекции и работы с данными. В отличие от PDF, TIFF, HTML и форматов изображений слайдов, он представляет данные презентации, а не рендерит слайды как страницы или визуальные активы. Таблица [поддерживаемых форматов файлов](/slides/ru/net/supported-file-formats/) перечисляет все форматы, которые Aspose.Slides может загружать, импортировать, сохранять или рендерить.

## **FAQ**

**Является ли `SaveFormat.Xml` тем же, что сохранение файла PPTX?**

Нет. PPTX — это пакет, содержащий несколько частей Office Open XML, тогда как `SaveFormat.Xml` создаёт файл PowerPoint XML Presentation.

**Можно ли сохранить XML‑вывод, не создавая файл на диске?**

Да. Передайте записываемый поток в [Presentation.Save](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/save/). Например, используйте [MemoryStream](https://learn.microsoft.com/en-us/dotnet/api/system.io.memorystream?view=net-10.0) для обработки в памяти.

**Может ли Aspose.Slides загрузить экспортированный XML‑файл снова?**

Да. Передайте XML‑файл или поток конструктору [Presentation](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/presentation/). Свойство [Presentation.SourceFormat](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/sourceformat/) вернёт `SourceFormat.Xml`. Метод [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/ru/net/aspose.slides/presentationfactory/getpresentationinfo/) возвращает `LoadFormat.Unknown` для этого формата, поэтому не используйте его для определения возможности открытия XML‑файла.

**Преобразует ли XML каждый слайд в страницу или изображение?**

Нет. Преобразование в XML записывает структурированные данные презентации. Для вывода, ориентированного на страницы, используйте PDF или TIFF, а для изображений отдельных слайдов — PNG, JPEG или SVG.