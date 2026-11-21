---
title: Изменение размеров и ориентации страницы заметок в C++
linktitle: Размер страницы заметок
type: docs
weight: 10
url: /ru/cpp/notes-size/
keywords:
- размер страницы заметок
- ориентация заметок
- альбомные заметки
- портретные заметки
- размер раздаточного материала
- PowerPoint
- презентация
- PPT
- PPTX
- C++
- Aspose.Slides
description: "Чтение и изменение размеров страницы заметок в Aspose.Slides для C++, переключение ориентации, проверка сохранённых размеров и экспорт заметок или раздаточных материалов в PDF и изображения."
---
## **Обзор**

Используйте [Presentation::get_NotesSize](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/get_notessize/) для доступа к настройкам страницы заметок презентации. Он возвращает объект [INotesSize](https://reference.aspose.com/slides/ru/cpp/aspose.slides/inotessize/), метод [set_Size](https://reference.aspose.com/slides/ru/cpp/aspose.slides/inotessize/set_size/) которого задаёт размеры. Хотя объект настроек заметок нельзя заменить, его размер можно изменить.

Ширина и высота задаются в **точках**, по 72 точки на дюйм. Например, 900 × 600 точек — это 12,5 × 8⅓ дюйма. Эти настройки применяются к презентации, а не к отдельным слайдам заметок.

| Настройка | Назначение |
| --- | --- |
| [Presentation::get_NotesSize](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/get_notessize/) | Определяет размеры страницы заметок и размеры страницы, используемые при экспорте раздаточных материалов. |
| [Presentation::get_SlideSize](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/get_slidesize/) | Определяет размеры обычных слайдов презентации через [ISlideSize](https://reference.aspose.com/slides/ru/cpp/aspose.slides/islidesize/). |

Изменение любой из этих настроек не меняет автоматически другую. Изменение ориентации страницы заметок также не вращает обычные слайды. См. [Slide Size](/slides/ru/cpp/slide-size/) для изменения размеров обычных слайдов.

Приведённые ниже примеры используют существующий `sample.pptx`. Для примеров экспорта используйте презентацию, содержащую хотя бы один слайд с примечаниями к докладчику. Каждый пример можно запускать независимо.

## **Считать размеры и ориентацию страницы заметок**

Считайте ширину и высоту и сравните их, чтобы определить ориентацию: более широкая страница — альбомная, более высокая — портретная, равные размеры — квадратная страница. Этот пример выводит фактические размеры в точках, не предполагая стандартный размер бумаги.

```cpp
#include <DOM/Presentation.h>
#include <DOM/INotesSize.h>
#include <drawing/size_f.h>
#include <system/console.h>
#include <system/smart_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto size = presentation->get_NotesSize()->get_Size();
auto orientation = String(u"Square");

if (size.get_Width() > size.get_Height())
    orientation = u"Landscape";
else if (size.get_Width() < size.get_Height())
    orientation = u"Portrait";

Console::WriteLine(u"Notes page: {0} x {1} points", size.get_Width(), size.get_Height());
Console::WriteLine(u"Orientation: {0}", orientation);
```

## **Переключить на альбомную ориентацию без изменения размера бумаги**

Чтобы изменить только ориентацию, поменяйте местами текущие ширину и высоту. Это сохраняет длины обеих сторон, включая пользовательский размер бумаги. Условие ниже предотвращает переключение уже альбомной страницы обратно в портрет и оставляет квадратную страницу без изменений.

```cpp
#include <DOM/Presentation.h>
#include <DOM/INotesSize.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto size = presentation->get_NotesSize()->get_Size();

if (size.get_Width() < size.get_Height())
    presentation->get_NotesSize()->set_Size(SizeF(size.get_Height(), size.get_Width()));

presentation->Save(u"landscape-notes.pptx", SaveFormat::Pptx);
```

Для портретной ориентации используйте такое же присваивание, когда `size.get_Width() > size.get_Height()`. Не подставляйте размеры A4 или Letter, если только вы не хотите изменить размер бумаги.

## **Установить и проверить пользовательский размер страницы заметок**

Назначьте обе размеры одновременно, затем используйте [Presentation::Save](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/save/) для записи презентации. Этот пример задаёт альбомную страницу 900 × 600 точек, сохраняет её как PPTX и снова открывает сохранённый файл, чтобы проверить сохранённые значения. Сравнение допускает погрешность 0,01 точки для чисел с плавающей запятой; это не гарантирует точность для каждого формата файла.

```cpp
#include <DOM/Presentation.h>
#include <DOM/INotesSize.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>
#include <system/console.h>
#include <system/smart_ptr.h>
#include <cmath>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto expectedSize = SizeF(900, 600);
presentation->get_NotesSize()->set_Size(expectedSize);
presentation->Save(u"custom-notes.pptx", SaveFormat::Pptx);

auto reopened = MakeObject<Presentation>(u"custom-notes.pptx");
auto actualSize = reopened->get_NotesSize()->get_Size();
auto widthMatches = std::abs(actualSize.get_Width() - expectedSize.get_Width()) < 0.01f;
auto heightMatches = std::abs(actualSize.get_Height() - expectedSize.get_Height()) < 0.01f;
auto preserved = widthMatches && heightMatches;

Console::WriteLine(u"Stored notes page: {0} x {1} points", actualSize.get_Width(), actualSize.get_Height());
Console::WriteLine(u"Size preserved: {0}", preserved);
```

Ожидаемый результат — `900 x 600 points` и `Size preserved: True`. Проверка вновь открытой презентации подтверждает сохранённый файл, а не только настройки в памяти.

## **Экспортировать заметки и раздаточные материалы**

Размеры страницы определяют доступную область для размещения заметок или раздаточных материалов. Они сами по себе не включают эти разметки: необходимо также настроить параметры экспорта. Экспорт обычных слайдов продолжает использовать размеры слайда.

### **Экспортировать заметки в PDF и PNG**

Назначьте [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export/notescommentslayoutingoptions/) объекту [PdfOptions::set_SlidesLayoutOptions](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export/pdfoptions/set_slideslayoutoptions/), чтобы включить заметки в PDF. Этот пример также рендерит первый слайд с заметками в PNG с помощью [Slide::GetImage](https://reference.aspose.com/slides/ru/cpp/aspose.slides/slide/getimage/) и [RenderingOptions](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export/renderingoptions/).

Режим [BottomTruncated](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export/notespositions/) оставляет заметки на одной странице; заметки, которые не помещаются, могут быть усечены. PDF использует страницы 900 × 600 точек. При масштабе изображения 1 × 1, использованном ниже, PNG имеет 900 × 600 пикселей. Точки описывают геометрию страницы; пиксели — растровый вывод, размеры которого также зависят от масштаба рендеринга.

```cpp
#include <DOM/Presentation.h>
#include <DOM/INotesSize.h>
#include <DOM/ISlide.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/NotesPositions.h>
#include <Export/PdfOptions.h>
#include <Export/RenderingOptions.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <drawing/size_f.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
presentation->get_NotesSize()->set_Size(SizeF(900, 600));

auto layout = MakeObject<NotesCommentsLayoutingOptions>();
layout->set_NotesPosition(NotesPositions::BottomTruncated);

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(layout);

presentation->Save(u"notes.pdf", SaveFormat::Pdf, pdfOptions);

auto renderingOptions = MakeObject<RenderingOptions>();
renderingOptions->set_SlidesLayoutOptions(layout);

auto image = presentation->get_Slide(0)->GetImage(renderingOptions, 1.0f, 1.0f);
image->Save(u"first-slide-notes.png", ImageFormat::Png);
image->Dispose();
```

Для экспорта PDF с длинными заметками [BottomFull](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export/notespositions/) позволяет добавлять дополнительные страницы по мере необходимости. Не используйте этот режим с вызовом рендеринга одного слайда выше, поскольку он его не поддерживает. После изменения размеров проверьте вывод на наличие обрезанных заметок и расположение существующих объектов мастера заметок; изменение размеров страницы само по себе не гарантирует, что весь контент поместится. См. [Convert PowerPoint to PDF with Notes](/slides/ru/cpp/convert-powerpoint-to-pdf-with-notes/) для получения дополнительной информации об экспорте заметок.

### **Экспортировать раздаточные материалы в PDF**

Используйте [HandoutLayoutingOptions](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export/handoutlayoutingoptions/) для размещения нескольких миниатюр слайдов на одной странице. В следующем примере задаётся страница 900 × 600 точек и используется [HandoutType::Handouts4Horizontal](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export/handouttype/) для размещения до четырёх слайдов на странице. Горизонтальный пресет определяет порядок слайдов; ориентация страницы берётся из её ширины и высоты.

```cpp
#include <DOM/Presentation.h>
#include <DOM/INotesSize.h>
#include <Export/HandoutLayoutingOptions.h>
#include <Export/HandoutType.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
presentation->get_NotesSize()->set_Size(SizeF(900, 600));

auto layout = MakeObject<HandoutLayoutingOptions>();
layout->set_Handout(HandoutType::Handouts4Horizontal);

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(layout);

presentation->Save(u"handouts.pdf", SaveFormat::Pdf, pdfOptions);
```

Изменение размера страницы меняет доступную область для сетки раздаточных материалов без изменения размеров исходных слайдов. Для изображений раздаточных материалов используйте [Presentation::GetImages](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/getimages/) с раздаточным макетом, а не метод получения изображения отдельного слайда. В Aspose.Slides рендеринг раздаточных материалов на уровне презентации использует размеры страницы заметок, тогда как вызов получения изображения отдельного слайда не создаёт страницу раздаточного материала. См. [Handout Mode](/slides/ru/cpp/convert-powerpoint-in-handout-mode/) для вариантов разметки.

## **Размер страницы в просмотровиках, экспорте и печати**

Сохраняйте размер презентации, размер экспортируемой страницы и размер печатной бумаги раздельными:

- **Просмотрщики презентаций:** Просмотрщик может отображать или печатать заметки, используя свои правила разметки. Если другое приложение сохраняет файл, откройте его снова и проверьте размеры; конвертация формата в этом приложении может нормализовать их.
- **Форматы экспорта:** Примеры PDF‑экспорта заметок и раздаточных материалов выше используют сконфигурированные размеры страницы. Растровые изображения используют целочисленные размеры в пикселях и масштаб рендеринга, поэтому дробные значения точек могут быть округлены в выводе изображения. Экспорт обычных слайдов не применяет размер страницы заметок.
- **Драйверы принтеров:** Выбор бумаги, автоматическое вращение и настройки «подогнать к странице» могут изменить физический вывод без изменения размеров, сохранённых в презентации или PDF. Для конкретного размера бумаги сопоставьте настройки принтера и проверьте предварительный просмотр печати.

## **Вопросы и ответы**

**Можно ли задать размер заметок только для одного слайда?**

Размер страницы заметок задаётся на уровне презентации. Отдельные слайды могут иметь различное содержание заметок, но это свойство не предоставляет отдельный размер страницы для каждого слайда.

**Почему изменение ориентации заметок не изменило мои слайды?**

Страницы заметок и обычные слайды имеют независимые размеры. Используйте настройки размера обычных слайдов, когда нужно изменить размеры самих слайдов.

**Почему мой сохранённый или распечатанный результат имеет иной размер?**

Сначала откройте сохранённую презентацию вновь и сравните её размеры заметок. Если они изменились, проверьте, изменило ли сохранение или конвертация файла в другом приложении настройки страницы. Если нет, проверьте разметку экспорта, масштаб изображения, настройки просмотрщика и выбор бумаги в принтере.