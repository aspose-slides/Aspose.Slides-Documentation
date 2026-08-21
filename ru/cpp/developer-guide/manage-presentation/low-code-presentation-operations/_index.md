---
title: Операции low-code с презентациями на C++
linktitle: Low-code API
type: docs
weight: 50
url: /ru/cpp/low-code-presentation-operations/
keywords:
- low-code API презентаций
- конвертация презентации
- объединение презентаций
- перебор слайдов
- перебор фигур
- перебор текста
- сбор фигур
- сжатие презентации
- удалить неиспользуемые мастер-слайды
- удалить неиспользуемые компоновочные слайды
- сжатие встроенных шрифтов
- PowerPoint
- OpenDocument
- презентация
- C++
- Aspose.Slides
description: "Используйте low-code API Aspose.Slides на C++ для конвертации и объединения презентаций, перебора содержимого, сбора фигур и уменьшения размера презентации."
---
## **Обзор**

Пространство имён [Aspose::Slides::LowCode](https://reference.aspose.com/slides/ru/cpp/aspose.slides.lowcode/) предоставляет статические вспомогательные классы для типовых операций с презентациями. Эти помощники инкапсулируют часто используемые сценарии работы с объектной моделью в отдельные методы, позволяя конвертировать или объединять файлы, обрабатывать элементы презентации, собирать фигуры и удалять неиспользуемый контент с меньшим количеством кода.

Вспомогательные средства low‑code особенно полезны, когда операция применяется ко всему файлу или презентации и стандартный рабочий процесс удовлетворяет требованиям. Используйте полную [модель объектов Aspose.Slides](https://reference.aspose.com/slides/ru/cpp/aspose.slides/) при необходимости тонкой настройки отдельных слайдов, шаблонов, компоновок, фигур, параметров экспорта или взаимоотношений между элементами презентации.

Ниже приведена таблица с доступными помощниками:

| Помощник | Для чего использовать |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/ru/cpp/aspose.slides.lowcode/convert/) | Конвертирование презентации в другой формат посредством прямого вызова file‑to‑file. |
| [Merger](https://reference.aspose.com/slides/ru/cpp/aspose.slides.lowcode/merger/) | Объединение полных файлов презентаций одинакового формата. |
| [ForEach](https://reference.aspose.com/slides/ru/cpp/aspose.slides.lowcode/foreach/) | Выполнение действия для каждого слайда, фигуры, абзаца или части текста. |
| [Collect](https://reference.aspose.com/slides/ru/cpp/aspose.slides.lowcode/collect/) | Получение фигур из всей презентации для повторной обработки или анализа. |
| [Compress](https://reference.aspose.com/slides/ru/cpp/aspose.slides.lowcode/compress/) | Удаление неиспользуемых шаблонов и компоновок и сокращение встроенных шрифтов. |

## **Конвертировать презентацию**

Используйте [Convert::AutoByExtension](https://reference.aspose.com/slides/ru/cpp/aspose.slides.lowcode/convert/autobyextension/) когда достаточно указать расширение выходного файла для выбора формата экспорта. Метод открывает исходную презентацию, определяет требуемый формат по пути вывода и записывает результат.

```cpp
#include <LowCode/Convert.h>

using namespace Aspose::Slides::LowCode;

Convert::AutoByExtension(u"input.pptx", u"output.pdf");
```

Класс [Convert](https://reference.aspose.com/slides/ru/cpp/aspose.slides.lowcode/convert/) также предоставляет отдельные методы для вывода в PDF, SVG, JPEG, PNG и TIFF. Используйте полную модель объектов, если нужно изучить или изменить презентацию перед экспортом либо задать параметры экспорта, не доступные через выбранный помощник. См. [Convert Presentation](/cpp/convert-presentation/) для рабочих процессов и опций, зависящих от формата.

## **Объединять презентации**

Для объединения полных файлов презентаций одним вызовом используйте [Merger::Process](https://reference.aspose.com/slides/ru/cpp/aspose.slides.lowcode/merger/process/). Входные презентации должны иметь одинаковый файловый формат.

```cpp
#include <LowCode/Merger.h>
#include <system/array.h>
#include <system/string.h>

using namespace Aspose::Slides::LowCode;

auto inputFiles = System::MakeArray<System::String>({u"part-1.pptx", u"part-2.pptx"});
Merger::Process(inputFiles, u"merged.pptx");
```

Этот помощник подходит, когда все слайды должны быть добавлены к единому результату без индивидуального выбора или переопределения. Используйте полную модель объектов, если нужно объединять выбранные слайды, применять целевой шаблон или компоновку, явно сохранять секции или согласовать разные размеры слайдов. См. [Merge Presentations](/cpp/merge-presentation/) для таких сценариев.

## **Итерировать элементы презентации**

Класс [ForEach](https://reference.aspose.com/slides/ru/cpp/aspose.slides.lowcode/foreach/) вызывает обратный вызов для каждого запрошенного типа элементов презентации. Это избавляет от вложенных циклов перебора и удобно для осмотра или изменения формата по всей презентации.

В следующем примере используются [ForEach::Slide](https://reference.aspose.com/slides/ru/cpp/aspose.slides.lowcode/foreach/slide/), [ForEach::Shape](https://reference.aspose.com/slides/ru/cpp/aspose.slides.lowcode/foreach/shape/), [ForEach::Paragraph](https://reference.aspose.com/slides/ru/cpp/aspose.slides.lowcode/foreach/paragraph/) и [ForEach::Portion](https://reference.aspose.com/slides/ru/cpp/aspose.slides.lowcode/foreach/portion/) для инспекции соответствующих элементов:

```cpp
#include <DOM/BaseSlide.h>
#include <DOM/Paragraph.h>
#include <DOM/Portion.h>
#include <DOM/Presentation.h>
#include <DOM/Shape.h>
#include <DOM/Slide.h>
#include <LowCode/ForEach.h>
#include <system/console.h>
#include <system/shared_ptr.h>
#include <functional>

using namespace Aspose::Slides;
using namespace Aspose::Slides::LowCode;

auto presentation = System::MakeObject<Presentation>(u"input.pptx");

auto slideCallback = std::function<void(System::SharedPtr<Slide>, int32_t)>([](System::SharedPtr<Slide> slide, int32_t index)
{
    System::Console::WriteLine(u"Slide {0}: {1} shapes", index, slide->get_Shapes()->get_Count());
});
ForEach::Slide(presentation, slideCallback);

auto shapeCallback = std::function<void(System::SharedPtr<Shape>, System::SharedPtr<BaseSlide>, int32_t)>([](System::SharedPtr<Shape> shape, System::SharedPtr<BaseSlide> slide, int32_t index)
{
    System::Console::WriteLine(u"Shape {0}: {1}", index, shape->get_Name());
});
ForEach::Shape(presentation, shapeCallback);

auto paragraphCallback = std::function<void(System::SharedPtr<Paragraph>, System::SharedPtr<BaseSlide>, int32_t)>([](System::SharedPtr<Paragraph> paragraph, System::SharedPtr<BaseSlide> slide, int32_t index)
{
    System::Console::WriteLine(u"Paragraph {0}: {1}", index, paragraph->get_Text());
});
ForEach::Paragraph(presentation, paragraphCallback);

auto portionCallback = std::function<void(System::SharedPtr<Portion>, System::SharedPtr<Paragraph>, System::SharedPtr<BaseSlide>, int32_t)>([](System::SharedPtr<Portion> portion, System::SharedPtr<Paragraph> paragraph, System::SharedPtr<BaseSlide> slide, int32_t index)
{
    System::Console::WriteLine(u"Portion {0}: {1}", index, portion->get_Text());
});
ForEach::Portion(presentation, portionCallback);
```

По умолчанию обход фигур и текста по всей презентации включает обычные, шаблонные и компоновочные слайды. Перегрузки с параметром `includeNotes` могут также обрабатывать слайды заметок. Используйте прямые циклы перебора, когда важен порядок обхода, ранний выход, фильтрация до вызова обратного вызова или детальное управление иерархией родитель‑дитя.

## **Собирать фигуры**

Применяйте [Collect::Shapes](https://reference.aspose.com/slides/ru/cpp/aspose.slides.lowcode/collect/shapes/) когда требуется собрать все фигуры презентации в одну коллекцию, а не обрабатывать их по отдельности через обратный вызов. Это удобно, если один и тот же набор фигур будет фильтроваться, подсчитываться или обрабатываться несколько раз.

```cpp
#include <DOM/Presentation.h>
#include <DOM/Shape.h>
#include <LowCode/Collect.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::LowCode;

auto presentation = System::MakeObject<Presentation>(u"input.pptx");
auto shapes = Collect::Shapes(presentation);

for (const auto& shape : shapes)
{
    System::Console::WriteLine(shape->get_Name());
}
```

Используйте [ForEach::Shape](https://reference.aspose.com/slides/ru/cpp/aspose.slides.lowcode/foreach/shape/) вместо этого, когда каждую фигуру можно обработать сразу и нет необходимости сохранять собранный результат.

## **Сжимать содержимое презентации**

Класс [Compress](https://reference.aspose.com/slides/ru/cpp/aspose.slides.lowcode/compress/) может удалять неиспользуемые структурные элементы и уменьшать объём встроенных шрифтов:

- [Compress::RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/ru/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/) удаляет компоновочные слайды, на которые не ссылается ни один обычный слайд.
- [Compress::RemoveUnusedMasterSlides](https://reference.aspose.com/slides/ru/cpp/aspose.slides.lowcode/compress/removeunusedmasterslides/) удаляет шаблонные слайды, которые больше не используются.
- [Compress::CompressEmbeddedFonts](https://reference.aspose.com/slides/ru/cpp/aspose.slides.lowcode/compress/compressembeddedfonts/) удаляет неиспользуемые символы из встроенных шрифтов.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <LowCode/Compress.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::LowCode;

auto presentation = System::MakeObject<Presentation>(u"input.pptx");

Compress::RemoveUnusedLayoutSlides(presentation);
Compress::RemoveUnusedMasterSlides(presentation);
Compress::CompressEmbeddedFonts(presentation);

presentation->Save(u"compressed.pptx", SaveFormat::Pptx);
```

Сначала удаляйте неиспользуемые компоновки, а затем неиспользуемые шаблоны, чтобы шаблон, ставший ненужным после очистки компоновок, также был удалён. Сохраните оптимизированную презентацию в новый файл, если позже могут потребоваться оригинальные шаблоны, компоновки или полные данные встроенных шрифтов. Подробнее см. [Slide Master](/cpp/slide-master/) и [Embedded Font](/cpp/embedded-font/).

## **FAQ**

**Когда следует использовать low‑code API вместо полной модели объектов?**

Применяйте low‑code помощники, когда стандартная операция охватывает весь файл или презентацию и не требует детального контроля над отдельными элементами. Используйте полную модель объектов, если необходимо выбрать отдельные слайды, управлять связями шаблонов и компоновок, просматривать промежуточное состояние или задавать поведение, не поддерживаемое помощником.

**Может ли Merger объединять презентации разных форматов?**

Нет. [Merger::Process](https://reference.aspose.com/slides/ru/cpp/aspose.slides.lowcode/merger/process/) требует, чтобы входные презентации имели одинаковый формат. Сначала преобразуйте файлы в общий формат, например с помощью [Convert::AutoByExtension](https://reference.aspose.com/slides/ru/cpp/aspose.slides.lowcode/convert/autobyextension/), а затем объедините полученные файлы.

**Обрабатывает ли ForEach шаблонные, компоновочные и слайды заметок?**

[ForEach::Slide](https://reference.aspose.com/slides/ru/cpp/aspose.slides.lowcode/foreach/slide/) перебирает обычные слайды презентации. Операции [ForEach::Shape](https://reference.aspose.com/slides/ru/cpp/aspose.slides.lowcode/foreach/shape/), [ForEach::Paragraph](https://reference.aspose.com/slides/ru/cpp/aspose.slides.lowcode/foreach/paragraph/) и [ForEach::Portion](https://reference.aspose.com/slides/ru/cpp/aspose.slides.lowcode/foreach/portion/) по умолчанию включают обычные, шаблонные и компоновочные слайды. Используйте их перегрузки с параметром `includeNotes` = `true`, чтобы включить слайды заметок.

**В чём разница между ForEach::Shape и Collect::Shapes?**

[ForEach::Shape](https://reference.aspose.com/slides/ru/cpp/aspose.slides.lowcode/foreach/shape/) обрабатывает каждую фигуру сразу через обратный вызов. [Collect::Shapes](https://reference.aspose.com/slides/ru/cpp/aspose.slides.lowcode/collect/shapes/) возвращает перечислимый результат, который можно сохранять, фильтровать, подсчитывать или обходить несколько раз.

**Всегда ли Compress делает файл презентации меньше?**

Не обязательно. Результат зависит от наличия в презентации неиспользуемых компоновок, шаблонов или встроенных шрифтов с неиспользуемыми символами. Если такие элементы отсутствуют, соответствующие операции [Compress](https://reference.aspose.com/slides/ru/cpp/aspose.slides.lowcode/compress/) могут не уменьшить размер файла.

**Сохраняются ли изменения, внесённые ForEach или Compress, автоматически?**

Нет. Эти помощники работают с загруженным объектом [Presentation](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/) в памяти. После изменения элементов в обратном вызове [ForEach](https://reference.aspose.com/slides/ru/cpp/aspose.slides.lowcode/foreach/) или выполнения [Compress](https://reference.aspose.com/slides/ru/cpp/aspose.slides.lowcode/compress/) вызовите [Presentation::Save](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/save/), чтобы записать результат.

## **Связанные статьи**

- [Convert Presentation](/cpp/convert-presentation/)
- [Merge Presentations](/cpp/merge-presentation/)
- [Slide Master](/cpp/slide-master/)
- [Manage Text Box](/cpp/manage-textbox/)
- [Embedded Font](/cpp/embedded-font/)