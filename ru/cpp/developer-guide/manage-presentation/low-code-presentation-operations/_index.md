---
title: Операции над презентациями с низким уровнем кода в C++
linktitle: API с низким уровнем кода
type: docs
weight: 50
url: /ru/cpp/low-code-presentation-operations/
keywords:
- API презентаций с низким уровнем кода
- конвертировать презентацию
- объединять презентации
- итерация по слайдам
- итерация по фигурам
- итерация по тексту
- собирать фигуры
- сжимать презентацию
- удалить неиспользуемые мастер-слайды
- удалить неиспользуемые слайды-раскладки
- сжать встроенные шрифты
- PowerPoint
- OpenDocument
- презентация
- C++
- Aspose.Slides
description: "Используйте low-code API Aspose.Slides в C++ для конвертации и объединения презентаций, итерации по содержимому, сбора фигур и уменьшения размера презентации."
---
## **Обзор**

Пространство имён Aspose::Slides::LowCode предоставляет статические вспомогательные классы для общих операций с презентациями. Эти помощники инкапсулируют часто используемые рабочие потоки объектной модели в специализированных методах, позволяя конвертировать или объединять файлы, обрабатывать элементы презентации, собирать фигуры и удалять неиспользуемый контент с меньшим количеством кода.

Вспомогательные средства low-code наиболее полезны, когда операция применяется к целому файлу или презентации и стандартный рабочий процесс соответствует вашим требованиям. Используйте полностью объектную модель Aspose.Slides, когда требуется тонкий контроль над отдельными слайдами, шаблонами, раскладками, фигурами, параметрами экспорта или взаимосвязями элементов презентации.

В следующей таблице приведено резюме доступных помощников:

| Помощник | Для чего используется |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/ru/cpp/aspose.slides.lowcode/convert/) | Преобразование презентации в другой формат с помощью прямого вызова file-to-file. |
| [Merger](https://reference.aspose.com/slides/ru/cpp/aspose.slides.lowcode/merger/) | Объединение полных файлов презентаций одинакового формата. |
| [ForEach](https://reference.aspose.com/slides/ru/cpp/aspose.slides.lowcode/foreach/) | Выполнение действия для каждого слайда, фигуры, абзаца или части текста. |
| [Collect](https://reference.aspose.com/slides/ru/cpp/aspose.slides.lowcode/collect/) | Извлечение фигур из всей презентации для повторной обработки или анализа. |
| [Compress](https://reference.aspose.com/slides/ru/cpp/aspose.slides.lowcode/compress/) | Удаление неиспользуемых шаблонов и раскладок и сокращение данных встроенных шрифтов. |

## **Конвертировать презентацию**

Используйте Convert::AutoByExtension, когда расширение выходного файла достаточно для выбора формата экспорта. Метод открывает исходную презентацию, определяет требуемый формат по пути вывода и записывает результат.

```cpp
#include <LowCode/Convert.h>

using namespace Aspose::Slides::LowCode;

Convert::AutoByExtension(u"input.pptx", u"output.pdf");
```

Класс Convert также предоставляет специализированные методы для вывода в PDF, SVG, JPEG, PNG и TIFF. Используйте полную объектную модель, когда необходимо просмотреть или изменить презентацию перед экспортом или настроить параметр экспорта, не предоставляемый выбранным помощником. Смотрите [Convert Presentation](/slides/ru/cpp/convert-presentation/) для рабочих процессов и параметров, специфичных для форматов.

## **Объединить презентации**

Используйте Merger::Process для объединения полных файлов презентаций одним вызовом. Входные презентации должны иметь одинаковый формат файла.

```cpp
#include <LowCode/Merger.h>
#include <system/array.h>
#include <system/string.h>

using namespace Aspose::Slides::LowCode;

auto inputFiles = System::MakeArray<System::String>({u"part-1.pptx", u"part-2.pptx"});
Merger::Process(inputFiles, u"merged.pptx");
```

Этот помощник подходит, когда все слайды должны быть добавлены к одному результату без отдельного выбора или переименования. Используйте полную объектную модель, когда необходимо объединять выбранные слайды, применять целевой шаблон или раскладку, явно сохранять секции или согласовывать разные размеры слайдов. Смотрите [Merge Presentations](/slides/ru/cpp/merge-presentation/) для этих сценариев.

## **Итерировать элементы презентации**

Класс ForEach вызывает обратный вызов для каждого запрошенного типа элемента презентации. Он избавляет от вложенных циклов коллекций и удобен для инспекции или изменения форматирования по всей презентации.

Следующий пример использует ForEach::Slide, ForEach::Shape, ForEach::Paragraph и ForEach::Portion для инспекции соответствующих элементов:

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

По умолчанию обход фигур и текста по всей презентации включает обычные, шаблонные и раскладочные слайды. Перегрузки с параметром `includeNotes` могут также обрабатывать слайды заметок. Используйте прямые циклы коллекций, когда важен порядок обхода, ранний выход, фильтрация до вызова обратного вызова или детальное управление родитель‑дочерней иерархией.

## **Собирать фигуры**

Используйте Collect::Shapes, когда нужна коллекция всех фигур в презентации, а не обратный вызов для каждой фигуры. Это полезно, когда один и тот же набор будет фильтроваться, подсчитываться или обрабатываться более одного раза.

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

Используйте ForEach::Shape вместо этого, когда каждую фигуру можно обработать сразу и нет необходимости сохранять полученный результат.

## **Сжать содержание презентации**

Класс Compress может удалять неиспользуемые структурные элементы и сокращать данные встроенных шрифтов:

- [Compress::RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/ru/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/) удаляет раскладочные слайды, на которые не ссылаются обычные слайды.
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

Сначала удаляйте неиспользуемые раскладки, а затем неиспользуемые шаблоны, чтобы шаблон, ставший неиспользуемым после очистки раскладок, также был удалён. Сохраните оптимизированную презентацию в новый файл, если позже может потребоваться исходные шаблоны, раскладки или полные данные встроенных шрифтов. Для более подробной информации смотрите [Slide Master](/slides/ru/cpp/slide-master/) и [Embedded Font](/slides/ru/cpp/embedded-font/).

## **FAQ**

**Когда следует использовать low-code API вместо полной объектной модели?**

Используйте low-code‑помощники, когда стандартная операция применяется к полной файл или презентации и не требует детального контроля над отдельными элементами. Применяйте полную объектную модель, когда нужно выбрать конкретные слайды, управлять связями шаблонов и раскладок, проверять промежуточное состояние или настраивать поведение, которое помощник не раскрывает.

**Может ли Merger объединять презентации в разных форматах файлов?**

Нет. Merger::Process требует, чтобы входные презентации имели один и тот же формат. Сначала преобразуйте входные файлы в общий формат, например с помощью Convert::AutoByExtension, а затем объедините преобразованные файлы.

**Обрабатывает ли ForEach шаблонные, раскладочные и слайды заметок?**

ForEach::Slide итерирует обычные слайды презентации. ForEach::Shape, ForEach::Paragraph и ForEach::Portion по умолчанию включают обычные, шаблонные и раскладочные слайды. Их перегрузки с `includeNotes` = true позволяют включать слайды заметок.

**В чём разница между ForEach::Shape и Collect::Shapes?**

Используйте ForEach::Shape для немедленной обработки каждой фигуры через обратный вызов. Применяйте Collect::Shapes, когда нужен сохраняемый перечислимый результат, который можно затем фильтровать, подсчитывать или обходить многократно.

**Всегда ли Compress делает файл презентации меньше?**

Не обязательно. Размер зависит от наличия неиспользуемых раскладок, шаблонов или встроенных шрифтов с неиспользуемыми символами. Если такие элементы отсутствуют, соответствующие операции Compress могут не уменьшить размер файла.

**Сохраняются ли изменения, сделанные ForEach или Compress, автоматически?**

Нет. Эти помощники работают с загруженным объектом Presentation в памяти. После изменения элементов в обратном вызове ForEach или после выполнения Compress вызовите Presentation::Save, чтобы записать результат.

## **Связанные статьи**

- [Конвертировать презентацию](/slides/ru/cpp/convert-presentation/)
- [Объединить презентации](/slides/ru/cpp/merge-presentation/)
- [Slide Master](/slides/ru/cpp/slide-master/)
- [Manage Text Box](/slides/ru/cpp/manage-textbox/)
- [Embedded Font](/slides/ru/cpp/embedded-font/)