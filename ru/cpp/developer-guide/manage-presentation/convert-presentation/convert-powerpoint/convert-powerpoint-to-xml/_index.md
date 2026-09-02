---
title: Преобразование презентаций PowerPoint в XML на C++
linktitle: PowerPoint в XML
type: docs
weight: 145
url: /ru/cpp/convert-powerpoint-to-xml/
keywords:
- конвертировать PowerPoint в XML
- конвертировать презентацию в XML
- PPT в XML
- PPTX в XML
- ODP в XML
- Презентация PowerPoint XML
- SaveFormat::Xml
- сохранить презентацию как XML
- экспортировать презентацию в XML
- XML поток
- C++
- Aspose.Slides
description: "Преобразуйте презентации PowerPoint и OpenDocument в файлы или потоки PowerPoint XML на C++ с помощью Aspose.Slides для C++."
---
## **Обзор**

Aspose.Slides for C++ может преобразовывать презентации PowerPoint в формат PowerPoint XML Presentation. Вывод в XML полезен, когда нужен текстовый представление для анализа структуры презентации, устранения неполадок в сгенерированных документах, сравнения результатов в автоматических тестах или интеграции с рабочим процессом, который использует XML вместо пакета презентации.

Используйте метод [Presentation::Save](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/save/) с значением `Xml` из перечисления [SaveFormat](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export/saveformat/). Вы можете записать результат непосредственно в файл или в поток.

{{% alert color="info" title="Примечание" %}}

`SaveFormat::Xml` создаёт PowerPoint XML Presentation. Он не извлекает отдельные части Office Open XML, хранящиеся внутри пакета PPTX. Если нужныexact части пакета PPTX, такие как `ppt/presentation.xml` или отдельные XML‑файлы слайдов, просмотрите сам пакет PPTX.

{{% /alert %}}

## **Преобразовать презентацию в XML‑файл**

Загрузите исходную презентацию с помощью класса [Presentation](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/) и затем передайте путь вывода и `SaveFormat::Xml` в [Presentation::Save](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/save/). Источником может быть любой поддерживаемый формат загрузки, например PPT, PPTX или ODP.

Следующий пример преобразует презентацию PPTX в XML‑файл:

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
presentation->Save(u"presentation.xml", SaveFormat::Xml);
presentation->Dispose();
```

## **Записать XML‑вывод в поток**

Используйте перегрузку метода [Presentation::Save](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/save/) для записи в поток, когда XML должен оставаться в памяти или передаваться другому компоненту, например веб‑службе, поставщику хранилища или XML‑конвейеру обработки. Следующий пример записывает результат в [MemoryStream](https://reference.aspose.com/slides/ru/cpp/system.io/memorystream/) и переходит к началу для последующего чтения:

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/memory_stream.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::IO;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto xmlStream = System::MakeObject<MemoryStream>();

presentation->Save(xmlStream, SaveFormat::Xml);
xmlStream->set_Position(0);
presentation->Dispose();

// Передайте xmlStream следующему компоненту в рабочем процессе.
```

## **Сравнение XML с форматами презентаций и экспорта**

Выберите формат вывода в зависимости от того, как будет использоваться результат:

| Формат | Вывод | Обычное использование |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | PowerPoint XML Presentation | Анализ структуры, устранение неполадок, сравнение сгенерированного вывода и интеграция на основе XML |
| PPT (`.ppt`) | Устаревший двоичный файл презентации | Совместимость со старыми рабочими процессами PowerPoint |
| PPTX (`.pptx`) | Пакет Office Open XML, содержащий несколько частей | Обычное редактирование PowerPoint и обмен презентациями |
| PDF или TIFF | Фиксированные страницы или многостраничное изображение | Просмотр, печать и архивирование |
| PNG, JPEG или SVG | Отрисованное представление отдельного слайда | Миниатюры, предварительные просмотры и графические ресурсы |
| HTML или HTML5 | Веб‑ориентированный вывод презентации | Просмотр в браузере и публикация в интернете |

В отличие от PPT и PPTX, вывод в XML предназначен в первую очередь для анализа и рабочих процессов, ориентированных на данные. В отличие от PDF, TIFF, HTML и форматов изображений слайдов, он представляет данные презентации, а не рендерит слайды как страницы или визуальные ресурсы. Таблица [поддерживаемых форматов файлов](/slides/ru/cpp/supported-file-formats/) перечисляет PowerPoint XML Presentation как формат только для сохранения, поэтому не используйте его, когда рабочий процесс требует загрузки экспортированного файла обратно в Aspose.Slides для дальнейшего редактирования.

## **FAQ**

**`SaveFormat::Xml` то же самое, что сохранение файла PPTX?**

Нет. PPTX — это пакет, содержащий несколько частей Office Open XML, тогда как `SaveFormat::Xml` создаёт файл PowerPoint XML Presentation.

**Можно ли сохранить XML‑вывод без создания файла на диске?**

Да. Передайте записываемый поток в [Presentation::Save](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/save/). Например, используйте [MemoryStream](https://reference.aspose.com/slides/ru/cpp/system.io/memorystream/) для обработки в памяти.

**Может ли Aspose.Slides загрузить экспортированный XML‑файл снова?**

Нет. PowerPoint XML Presentation в текущий момент поддерживается только для сохранения, но не для загрузки. Для обратного редактирования используйте PPTX или другой поддерживаемый формат презентации.

**Преобразует ли XML‑конверсия каждый слайд в страницу или изображение?**

Нет. Преобразование в XML записывает структурированные данные презентации. Для вывода, ориентированного на страницы, используйте PDF или TIFF, а для изображений отдельных слайдов — PNG, JPEG или SVG.