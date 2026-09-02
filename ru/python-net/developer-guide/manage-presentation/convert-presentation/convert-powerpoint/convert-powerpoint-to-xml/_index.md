---
title: Конвертировать презентации PowerPoint в XML на Python
linktitle: PowerPoint в XML
type: docs
weight: 145
url: /ru/python-net/convert-powerpoint-to-xml/
keywords:
- конвертировать PowerPoint в XML
- конвертировать презентацию в XML
- PPT в XML
- PPTX в XML
- ODP в XML
- PowerPoint XML Presentation
- SaveFormat.XML
- сохранить презентацию как XML
- экспортировать презентацию в XML
- XML поток
- Python
- Aspose.Slides
description: "Конвертировать презентации PowerPoint и OpenDocument в файлы PowerPoint XML или потоки на Python с помощью Aspose.Slides."
---
## **Обзор**

Aspose.Slides for Python via .NET может конвертировать презентации PowerPoint в формат PowerPoint XML Presentation. Вывод в XML полезен, когда требуется текстовое представление для инспекции структуры презентации, отладки сгенерированных документов, сравнения вывода в автоматических тестах или интеграции с рабочим процессом, который потребляет XML вместо пакета презентации.

Используйте метод [Presentation.save](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/save/) с значением `XML` из перечисления [SaveFormat](https://reference.aspose.com/slides/ru/python-net/aspose.slides.export/saveformat/). Результат можно записать непосредственно в файл или в поток.

{{% alert color="info" title="Note" %}}

`SaveFormat.XML` создает PowerPoint XML Presentation. Он не извлекает отдельные части Office Open XML, хранящиеся внутри пакета PPTX. Если вам нужны точные части пакета PPTX, такие как `ppt/presentation.xml` или отдельные XML‑файлы слайда, изучите сам пакет PPTX.

{{% /alert %}}

## **Преобразовать презентацию в XML‑файл**

Загрузите исходную презентацию с помощью класса [Presentation](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/), а затем передайте путь вывода и `SaveFormat.XML` в [Presentation.save](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/save/). Источник может быть в любом поддерживаемом формате загрузки, например PPT, PPTX или ODP.

Следующий пример преобразует презентацию PPTX в XML‑файл:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.xml", slides.export.SaveFormat.XML)
```

## **Записать вывод XML в поток**

Используйте перегрузку [Presentation.save](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/save/) для записи в поток, когда XML должен оставаться в памяти или передаваться другому компоненту, например веб‑службе, поставщику хранилища или конвейеру обработки XML. Следующий пример записывает результат в поток [BytesIO](https://docs.python.org/3/library/io.html#io.BytesIO) и перематывает его для последующего чтения:

```py
from io import BytesIO

import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    xml_stream = BytesIO()
    presentation.save(xml_stream, slides.export.SaveFormat.XML)
    xml_stream.seek(0)

    # Передайте xml_stream следующему компоненту в рабочем процессе.
```

## **Сравнение XML с форматами презентаций и экспорта**

Выберите формат вывода в зависимости от способа использования результата:

| Format | Output | Typical use |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | Презентация PowerPoint XML | Инспекция структуры, отладка, сравнение сгенерированного вывода и интеграция на основе XML |
| PPT (`.ppt`) | Устаревший бинарный файл презентации | Совместимость со старыми рабочими процессами PowerPoint |
| PPTX (`.pptx`) | Пакет Office Open XML, содержащий несколько частей | Обычное редактирование PowerPoint и обмен презентациями |
| PDF or TIFF | Фиксированные страницы или многократное изображение | Просмотр, печать и архивирование |
| PNG, JPEG, or SVG | Отображение отдельного слайда | Эскизы, превью и графические ресурсы |
| HTML or HTML5 | Веб‑ориентированный вывод презентации | Просмотр в браузере и публикация в интернете |

В отличие от PPT и PPTX, вывод в XML в первую очередь предназначен для инспекции и рабочих процессов, ориентированных на данные. В отличие от PDF, TIFF, HTML и форматов изображений слайдов, он представляет данные презентации, а не рендерит слайды как страницы или визуальные ресурсы. В таблице [поддерживаемые форматы файлов](/slides/ru/python-net/supported-file-formats/) формат PowerPoint XML Presentation указан как только для сохранения, поэтому не используйте его, если рабочий процесс требует загрузки экспортированного файла обратно в Aspose.Slides для дальнейшего редактирования.

## **Часто задаваемые вопросы**

**Является ли `SaveFormat.XML` тем же, что сохранение файла PPTX?**

Нет. PPTX — это пакет, содержащий несколько частей Office Open XML, тогда как `SaveFormat.XML` создает файл PowerPoint XML Presentation.

**Могу ли я сохранить вывод XML без создания файла на диске?**

Да. Передайте поток для записи в [Presentation.save](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/save/). Например, используйте поток [BytesIO](https://docs.python.org/3/library/io.html#io.BytesIO) для обработки в памяти.

**Может ли Aspose.Slides загружать экспортированный XML‑файл повторно?**

Нет. PowerPoint XML Presentation в настоящее время поддерживается только для сохранения, но не для загрузки. Используйте PPTX или другой поддерживаемый формат презентации, если требуется круговая редактирование.

**Конвертирует ли XML каждый слайд в страницу или изображение?**

Нет. Конверсия в XML записывает структурированные данные презентации. Для вывода, ориентированного на страницы, используйте PDF или TIFF, а для отдельных изображений слайдов — PNG, JPEG и SVG.