---
title: Конвертировать PPT в PPTX на C++
linktitle: PPT в PPTX
type: docs
weight: 20
url: /ru/cpp/convert-ppt-to-pptx/
keywords:
- конвертировать PowerPoint
- конвертировать презентацию
- конвертировать слайд
- конвертировать PPT
- PPT в PPTX
- сохранить PPT как PPTX
- экспортировать PPT в PPTX
- PowerPoint
- презентация
- C++
- Aspose.Slides
description: "Конвертировать устаревшие файлы PPT в PPTX на C++ с помощью Aspose.Slides. Включает примеры на C++ для конвертации одного файла и пакетной обработки, обработки ошибок и примечаний о точности."
---
## **Обзор**

PPT — это устаревший двоичный формат PowerPoint, а PPTX — более новый формат Open XML. Aspose.Slides для C++ может загрузить файл PPT и сохранить его как PPTX без Microsoft PowerPoint. В этой статье показано, как конвертировать один файл или каталог файлов и что следует проверить после конвертации.

## **Конвертация файла PPT в PPTX**

Загрузите исходный файл с помощью класса [Presentation](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/) , затем вызовите [Presentation::Save](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/save/) с аргументом [SaveFormat::Pptx](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export/saveformat/) . Освободите объект презентации, когда он больше не нужен, чтобы высвободить его ресурсы.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

// Load the legacy PPT presentation.
auto presentation = System::MakeObject<Presentation>(u"presentation.ppt");

// Save the presentation in PPTX format.
presentation->Save(u"presentation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Расширение файла само по себе не определяет формат вывода; это делает аргумент [SaveFormat::Pptx](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export/saveformat/) . Держите пути входного и выходного файлов разными, если необходимо сохранить оригинальный файл PPT.

## **Конвертация нескольких файлов PPT**

Следующий пример конвертирует каждый файл `.ppt` в указанном каталоге. Каждый файл обрабатывается независимо, поэтому ошибка при конвертации одного файла не останавливает остальную часть пакета.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/exception.h>
#include <system/io/directory.h>
#include <system/io/path.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

String inputDirectory = u"input";
String outputDirectory = u"output";
Directory::CreateDirectory_(outputDirectory);

auto inputPaths = Directory::GetFiles(inputDirectory, u"*.ppt", SearchOption::TopDirectoryOnly);
for (const auto& inputPath : inputPaths)
{
    auto outputFileName = Path::GetFileNameWithoutExtension(inputPath) + u".pptx";
    auto outputPath = Path::Combine(outputDirectory, outputFileName);

    try
    {
        auto presentation = MakeObject<Presentation>(inputPath);
        presentation->Save(outputPath, SaveFormat::Pptx);
        presentation->Dispose();
        Console::WriteLine(String::Format(u"Converted: {0}", inputPath));
    }
    catch (Exception& exception)
    {
        Console::get_Error()->WriteLine(String::Format(u"Failed: {0} ({1})", inputPath, exception->get_Message()));
    }
}
```

Для производственных нагрузок регистрируйте полное исключение, решайте, можно ли перезаписать существующий выходной файл, и записывайте имена файлов с ошибками в очередь повторной обработки или проверки. Повреждённые файлы, файлы, защищённые паролем и открытые без пароля, недоступные пути и неподдерживаемый контент могут привести к сбою конвертации. См. раздел [Password-Protected Presentations](/slides/ru/cpp/password-protected-presentation/) для загрузки зашифрованных файлов.

## **Точность и устаревшие возможности**

Обычно конвертация сохраняет слайды, мастера, макеты, текст, формы, изображения, таблицы и диаграммы. Однако PPT и PPTX не представляют каждую возможность одинаково. Устаревшая функция, не имеющая эквивалента в PPTX или не поддерживаемая библиотекой, может быть нормализована, опущена или отображена иначе.

Проверяйте сконвертированный файл, если в нём есть анимации, переходы, встроенные или связанные OLE‑объекты, элементы управления ActiveX, встроенные медиа‑файлы, редкие шрифты или VBA‑макросы. Обычный файл PPTX не является форматом, поддерживающим макросы, поэтому используйте соответствующий workflow с поддержкой макросов, если VBA‑код должен оставаться доступным. Также убедитесь, что необходимые шрифты и внешние ресурсы присутствуют в среде, где будет открываться или отображаться презентация.

Для важных документов откройте созданный PPTX программно и проверьте ключевые количества слайдов и содержимое, затем сравните внешний вид и поведение слайд‑шоу в целевом просмотрщике. Не рассматривайте успешный вызов [Presentation::Save](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/save/) как доказательство того, что каждая устаревшая функция имеет точный эквивалент в PPTX.

## **Когда использовать PPTX**

Используйте PPTX, когда презентацию будут редактировать в современных версиях PowerPoint, обмениваться с системами, работающими с пакетами Open XML, или хранить в формате, который проще исследовать и восстанавливать, чем устаревший двоичный PPT. Сохраняйте оригинальный PPT как архивную или резервную копию, пока конвертированная презентация не пройдёт проверки точности.

Если вместо этого вам нужен PDF, HTML, изображения, XPS или другой тип вывода, используйте рекомендации по конкретному формату в разделе [Convert Presentations to Multiple Formats](/slides/ru/cpp/convert-presentation/) вместо предположения, что все целевые форматы сохраняют редактируемые возможности PowerPoint.

## **Онлайн‑конвертер**

Для единичного файла или быстрой проверки можно воспользоваться [online PPT to PPTX converter](https://products.aspose.app/slides/ru/conversion/ppt-to-pptx) . Для повторяющихся конвертаций, пакетной обработки или обработки ошибок на уровне приложения используйте C++ API.

## **Смежные статьи**

- [Save Presentations in C++](/slides/ru/cpp/save-presentation/)
- [Supported File Formats](/slides/ru/cpp/supported-file-formats/)
- [Open Presentations in C++](/slides/ru/cpp/open-presentation/)

## **FAQ**

**Могу ли я конвертировать PPT в PPTX без установленного Microsoft PowerPoint?**

Да. Aspose.Slides для C++ загружает и сохраняет файлы презентаций без необходимости установки Microsoft PowerPoint.

**Сохранит ли конвертация PPT в PPTX всё содержимое точно?**

Она сохраняет обычное содержимое презентаций, но точная точность не гарантируется для каждой устаревшей или неподдерживаемой функции. Проверьте сгенерированный файл, если в нём есть макросы, OLE‑ или ActiveX‑объекты, медиа, специальные анимации или редкие шрифты.

**Могу ли я конвертировать защищённый паролем файл PPT?**

Да, если при загрузке файла указать правильный пароль. Отсутствие пароля или неправильный пароль приводят к сбою операции загрузки.

**Следует ли удалять файл PPT после конвертации?**

Сохраняйте оригинальный файл, пока не убедитесь, что PPTX работает в нужных просмотрщиках и рабочих процессах. Это обеспечит резервную копию на случай, если устаревшая функция будет конвертирована иначе.