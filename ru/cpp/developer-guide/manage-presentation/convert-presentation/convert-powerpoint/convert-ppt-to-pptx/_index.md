---
title: Конвертировать PPT в PPTX в C++
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
description: "Конвертировать устаревшие файлы PPT в PPTX в C++ с помощью Aspose.Slides. Включает примеры C++ для конвертации одного файла и пакетной обработки, обработки ошибок и примечаний о точности."
---
## **Обзор**

PPT — это наследуемый бинарный формат PowerPoint, в то время как PPTX — более новый формат Open XML. Aspose.Slides for C++ может загрузить файл PPT и сохранить его как PPTX без Microsoft PowerPoint. Эта статья показывает, как конвертировать один файл или каталог файлов и объясняет, что проверять после конвертации.

## **Конвертировать файл PPT в PPTX**

Загрузите исходный файл с помощью класса [Presentation](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/), затем вызовите [Presentation::Save](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/save/) с параметром [SaveFormat::Pptx](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export/saveformat/). Освободите объект презентации, когда он больше не требуется, чтобы освободить его ресурсы.

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

Расширение файла само по себе не определяет формат вывода; это делает аргумент [SaveFormat::Pptx](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export/saveformat/). Держите пути входного и выходного файлов разными, если необходимо сохранить оригинальный файл PPT.

## **Конвертировать несколько файлов PPT**

Следующий пример конвертирует каждый файл `.ppt` в одном каталоге. Каждый файл обрабатывается независимо, поэтому одна неудачная конверсия не останавливает остальную партию.

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

Для производственных задач регистрируйте полное исключение, решайте, можно ли перезаписать существующий выходной файл, и записывайте имена неудавшихся файлов в очередь повторной попытки или проверки. Повреждённые файлы, файлы, защищённые паролем, открытые без необходимого пароля, недоступные пути и неподдерживаемый контент могут привести к сбою конвертации. См. [Password-Protected Presentations](/cpp/password-protected-presentation/) для загрузки зашифрованных файлов.

## **Точность и наследуемые функции**

Конверсия обычно сохраняет слайды, шаблоны, макеты, текст, фигуры, изображения, таблицы и диаграммы. Однако PPT и PPTX не представляют каждую функцию одинаково. Наследуемая функция, не имеющая аналога в PPTX или не поддерживаемая библиотекой, может быть нормализована, опущена или отображена иначе.

Проверьте сконвертированный файл, если он содержит анимацию, переходы, встроенные или связанные OLE‑объекты, элементы управления ActiveX, встроенные медиа, редкие шрифты или VBA‑макросы. Обычный файл PPTX не поддерживает макросы, поэтому используйте подходный рабочий процесс с поддержкой макросов, когда VBA должен оставаться доступным. Также убедитесь, что требуемые шрифты и внешние ресурсы присутствуют в среде, где будет открываться или рендериться сконвертированная презентация.

Для важных документов откройте сгенерированный PPTX программно и проверьте количество ключевых слайдов и содержание, затем сравните его внешний вид и поведение слайд‑шоу в целевом просмотрщике. Не рассматривайте успешный вызов [Presentation::Save](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/save/) как доказательство того, что каждая наследуемая функция имеет точный эквивалент в PPTX.

## **Когда использовать PPTX**

Используйте PPTX, когда презентация будет редактироваться в текущих версиях PowerPoint, передаваться системам, работающим с пакетами Open XML, или храниться в формате, который проще исследовать и восстанавливать, чем наследуемый бинарный PPT. Сохраняйте оригинальный PPT как архивную или резервную копию, пока конвертированная презентация не пройдет ваши проверки точности.

Если вам нужен PDF, HTML, изображения, XPS или другой тип вывода, используйте руководство по конкретному формату в [Convert Presentations to Multiple Formats](/cpp/convert-presentation/), а не предполагаете, что все цели сохраняют редактируемые функции PowerPoint.

## **Онлайн‑конвертер**

Для отдельного файла или быстрой проверки вы можете воспользоваться [online PPT to PPTX converter](https://products.aspose.app/slides/ru/conversion/ppt-to-pptx). Для повторяющихся конвертаций, пакетной обработки или обработки ошибок на уровне приложения используйте C++ API.

## **Связанные статьи**

- [Сохранить презентации в C++](/cpp/save-presentation/)
- [Поддерживаемые форматы файлов](/cpp/supported-file-formats/)
- [Открыть презентации в C++](/cpp/open-presentation/)

## **Вопросы и ответы**

**Можно ли конвертировать PPT в PPTX без установленного Microsoft PowerPoint?**

Да. Aspose.Slides for C++ загружает и сохраняет файлы презентаций без необходимости установки Microsoft PowerPoint.

**Сохранит ли конверсия PPT в PPTX весь контент точно?**

Она сохраняет общие элементы презентации, но точная точность не гарантируется для каждой наследуемой или неподдерживаемой функции. Проверьте сгенерированный файл, если он содержит макросы, объекты OLE или ActiveX, медиа, специализированные анимации или редкие шрифты.

**Можно ли конвертировать защищённый паролем файл PPT?**

Да, если вы предоставите правильный пароль при загрузке файла. Отсутствие пароля или неправильный пароль приводит к сбою операции загрузки.

**Стоит ли удалять файл PPT после конвертации?**

Сохраняйте оригинал, пока не проверите PPTX в нужных вам просмотрщиках и рабочих процессах. Это обеспечивает резервную копию на случай, если наследуемая функция конвертируется по‑другому.