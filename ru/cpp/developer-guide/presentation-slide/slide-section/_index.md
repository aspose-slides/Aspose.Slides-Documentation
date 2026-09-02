---
title: Управление разделами слайдов в презентациях с C++
linktitle: Раздел слайдов
type: docs
weight: 100
url: /ru/cpp/slide-section/
keywords:
- создать раздел
- добавить раздел
- редактировать раздел
- изменить раздел
- имя раздела
- получить слайды раздела
- обработать слайды раздела
- PowerPoint
- презентация
- C++
- Aspose.Slides
description: "Управляйте разделами слайдов с помощью Aspose.Slides для C++: создавайте, переименовывайте, переупорядочивайте, получайте и обрабатывайте слайды разделов в презентациях PPTX."
---
## **Введение**

Разделы организуют последовательные слайды в именованные группы, не изменяя содержимое слайдов. С помощью Aspose.Slides для C++ вы можете создавать, переупорядочивать, переименовывать, просматривать и удалять разделы через метод [Presentation::get_Sections](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/get_sections/) .

Разделы особенно полезны, когда:

- большая презентация должна быть разбита на логические темы или главы;
- разные группы слайдов назначаются различным сотрудникам;
- слайды нужно обрабатывать, перемещать или объединять группами.

Выбирайте короткие имена разделов, которые описывают назначение сгруппированных слайдов. Поскольку разделы являются частью структуры презентации, используйте API разделов для определения принадлежности, а не выводите её из позиций слайдов.

## **Создание и управление разделами**

Используйте [ISectionCollection::AddSection](https://reference.aspose.com/slides/ru/cpp/aspose.slides/isectioncollection/addsection/) для создания раздела, указав его имя и начальный слайд. Aspose.Slides определяет, какие слайды принадлежат разделу, исходя из текущей структуры разделов презентации.

Тот же [ISectionCollection](https://reference.aspose.com/slides/ru/cpp/aspose.slides/isectioncollection/) также позволяет вам:

- переместить раздел вместе с его слайдами, используя [ISectionCollection::ReorderSectionWithSlides](https://reference.aspose.com/slides/ru/cpp/aspose.slides/isectioncollection/reordersectionwithslides/) ;
- удалить только определение раздела с помощью [ISectionCollection::RemoveSection](https://reference.aspose.com/slides/ru/cpp/aspose.slides/isectioncollection/removesection/) , при этом слайды сохраняются;
- удалить раздел вместе с его слайдами с помощью [ISectionCollection::RemoveSectionWithSlides](https://reference.aspose.com/slides/ru/cpp/aspose.slides/isectioncollection/removesectionwithslides/) ;
- добавить пустой раздел в конец с помощью [ISectionCollection::AppendEmptySection](https://reference.aspose.com/slides/ru/cpp/aspose.slides/isectioncollection/appendemptysection/) .

Следующий пример создает два раздела, перемещает один из них, удаляет его вместе со слайдами и добавляет пустой раздел:

```cpp
#include <DOM/ISectionCollection.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>();
auto layoutSlide = presentation->get_LayoutSlide(0);
auto titleSlide = presentation->get_Slide(0);
presentation->get_Slides()->AddEmptySlide(layoutSlide);
auto resultsSlide = presentation->get_Slides()->AddEmptySlide(layoutSlide);
presentation->get_Slides()->AddEmptySlide(layoutSlide);

auto sections = presentation->get_Sections();
sections->AddSection(u"Introduction", titleSlide);
auto resultsSection = sections->AddSection(u"Results", resultsSlide);

sections->ReorderSectionWithSlides(resultsSection, 0);
sections->RemoveSectionWithSlides(resultsSection);
sections->AppendEmptySection(u"Appendix");
```

После выполнения этих операций презентация содержит раздел `Introduction` со своими слайдами и пустой раздел `Appendix`. Раздел `Results` и его слайды были удалены.

## **Переименование разделов**

Чтобы переименовать раздел, вызовите [ISection::set_Name](https://reference.aspose.com/slides/ru/cpp/aspose.slides/isection/set_name/) . Слайды раздела и его позиция остаются неизменными.

Следующий пример создает раздел и меняет его имя:

```cpp
#include <DOM/ISection.h>
#include <DOM/ISectionCollection.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto section = presentation->get_Sections()->AddSection(u"Overview", slide);
section->set_Name(u"Introduction");
```

## **Получение слайдов из разделов**

Метод [Presentation::get_Sections](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/get_sections/) возвращает [ISectionCollection](https://reference.aspose.com/slides/ru/cpp/aspose.slides/isectioncollection/) , который можно перечислять. Для каждого [ISection](https://reference.aspose.com/slides/ru/cpp/aspose.slides/isection/) вызовите [ISection::GetSlidesListOfSection](https://reference.aspose.com/slides/ru/cpp/aspose.slides/isection/getslideslistofsection/) , чтобы получить слайды, принадлежащие ему в текущий момент. Метод возвращает [ISectionSlideCollection](https://reference.aspose.com/slides/ru/cpp/aspose.slides/isectionslidecollection/) , предоставляющий количество, индексированный доступ и возможность перечисления.

Следующий пример создаёт два заполненных раздела и один пустой раздел, затем выводит для каждого раздела его [name](https://reference.aspose.com/slides/ru/cpp/aspose.slides/isection/get_name/) , [identifier](https://reference.aspose.com/slides/ru/cpp/aspose.slides/isection/get_sectionid/) , [starting slide](https://reference.aspose.com/slides/ru/cpp/aspose.slides/isection/get_startedfromslide/) , количество слайдов и номера слайдов. Он использует индексированный доступ для чтения первого слайда и диапазонный `for`‑цикл для обработки каждого слайда. Для пустого раздела возвращённая коллекция имеет нулевое количество, индексированный доступ не используется, а перечисление не совершает итераций.

```cpp
#include <DOM/ISection.h>
#include <DOM/ISectionCollection.h>
#include <DOM/ISectionSlideCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>();
auto layoutSlide = presentation->get_LayoutSlide(0);
auto firstSlide = presentation->get_Slide(0);
presentation->get_Slides()->AddEmptySlide(layoutSlide);
auto thirdSlide = presentation->get_Slides()->AddEmptySlide(layoutSlide);

auto sections = presentation->get_Sections();
sections->AddSection(u"Introduction", firstSlide);
sections->AddSection(u"Details", thirdSlide);
sections->AppendEmptySection(u"Appendix");

for (const auto& section : sections)
{
    auto sectionSlides = section->GetSlidesListOfSection();
    auto startingSlide = section->get_StartedFromSlide();

    System::Console::WriteLine(u"Section: {0}", section->get_Name());
    System::Console::WriteLine(u"ID: {0}", section->get_SectionId().ToString());
    if (startingSlide == nullptr)
    {
        System::Console::WriteLine(u"Starting slide: none");
    }
    else
    {
        System::Console::WriteLine(u"Starting slide: {0}", startingSlide->get_SlideNumber());
    }
    System::Console::WriteLine(u"Slide count: {0}", sectionSlides->get_Count());

    if (sectionSlides->get_Count() > 0)
    {
        System::Console::WriteLine(u"First slide via index: {0}", sectionSlides->idx_get(0)->get_SlideNumber());
    }

    System::Console::Write(u"Slide numbers:");
    for (const auto& slide : sectionSlides)
    {
        System::Console::Write(u" {0}", slide->get_SlideNumber());
    }
    System::Console::WriteLine();
}
```

Принадлежность к разделу определяется структурой разделов презентации. Не вычисляйте диапазон раздела вручную, используя [ISection::get_StartedFromSlide](https://reference.aspose.com/slides/ru/cpp/aspose.slides/isection/get_startedfromslide/) , индексы слайдов и начальный слайд следующего раздела.

Структурные изменения могут менять как набор слайдов, возвращаемых для раздела, так и их номера. К ним относятся переупорядочивание слайдов, клонирование слайда в раздел, перемещение раздела вместе с его слайдами, удаление слайдов и удаление разделов. Следующий пример вызывает [ISection::GetSlidesListOfSection](https://reference.aspose.com/slides/ru/cpp/aspose.slides/isection/getslideslistofsection/) после каждого такого изменения вместо сохранения предположений о прежних границах раздела.

```cpp
#include <DOM/ISection.h>
#include <DOM/ISectionCollection.h>
#include <DOM/ISectionSlideCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/shared_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>();
auto layoutSlide = presentation->get_LayoutSlide(0);
auto firstSlide = presentation->get_Slide(0);
presentation->get_Slides()->AddEmptySlide(layoutSlide);
auto thirdSlide = presentation->get_Slides()->AddEmptySlide(layoutSlide);
presentation->get_Slides()->AddEmptySlide(layoutSlide);

auto sections = presentation->get_Sections();
auto firstSection = sections->AddSection(u"First", firstSlide);
auto secondSection = sections->AddSection(u"Second", thirdSlide);

auto printSectionSlides = [](const System::String& label, const System::SharedPtr<ISection>& section)
{
    auto sectionSlides = section->GetSlidesListOfSection();
    System::Console::Write(u"{0} ({1} slides):", label, sectionSlides->get_Count());
    for (const auto& slide : sectionSlides)
    {
        System::Console::Write(u" {0}", slide->get_SlideNumber());
    }
    System::Console::WriteLine();
};

printSectionSlides(u"Initially", firstSection);

auto slidesBeforeClone = firstSection->GetSlidesListOfSection();
presentation->get_Slides()->AddClone(slidesBeforeClone->idx_get(0), firstSection);
printSectionSlides(u"After cloning into the section", firstSection);

auto slidesBeforeReorder = firstSection->GetSlidesListOfSection();
auto firstSlideInSection = slidesBeforeReorder->idx_get(0);
auto lastSlideInSection = slidesBeforeReorder->idx_get(slidesBeforeReorder->get_Count() - 1);
auto firstSectionPosition = firstSlideInSection->get_SlideNumber() - 1;
presentation->get_Slides()->Reorder(firstSectionPosition, lastSlideInSection);
printSectionSlides(u"After reordering slides", firstSection);

sections->ReorderSectionWithSlides(firstSection, 1);
printSectionSlides(u"After moving the section", firstSection);

auto slidesBeforeRemoval = firstSection->GetSlidesListOfSection();
presentation->get_Slides()->Remove(slidesBeforeRemoval->idx_get(0));
printSectionSlides(u"After removing a slide", firstSection);

sections->RemoveSectionWithSlides(secondSection);
for (const auto& section : sections)
{
    printSectionSlides(u"Remaining section", section);
}
```

Вызывайте [ISection::GetSlidesListOfSection](https://reference.aspose.com/slides/ru/cpp/aspose.slides/isection/getslideslistofsection/) снова каждый раз, когда слайды или разделы переупорядочиваются, клонируются, перемещаются или удаляются. Это сохраняет согласованность последующей обработки с текущей структурой презентации.

Формат PPT (PowerPoint 97–2003) не сохраняет метаданные разделов. Используйте этот рабочий процесс с форматом, поддерживающим разделы, например PPTX; преобразование в PPT удаляет структуру разделов, необходимую для последующего перечисления.

## **FAQ**

**Сохраняются ли разделы при сохранении в формат PPT (PowerPoint 97–2003)?**

Нет. Формат PPT не поддерживает метаданные разделов, поэтому группировка разделов теряется при сохранении в .ppt.

**Можно ли полностью скрыть раздел?**

Нет. У раздела нет состояния видимости. Чтобы скрыть его содержимое, вызовите [ISlide::set_Hidden](https://reference.aspose.com/slides/ru/cpp/aspose.slides/islide/set_hidden/) для каждого слайда в этом разделе.

**Как найти раздел, содержащий определённый слайд?**

Перечислите [Presentation::get_Sections](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/get_sections/), вызовите [ISection::GetSlidesListOfSection](https://reference.aspose.com/slides/ru/cpp/aspose.slides/isection/getslideslistofsection/) для каждого раздела и сравните полученные слайды с целевым слайдом. Для непустого раздела [ISection::get_StartedFromSlide](https://reference.aspose.com/slides/ru/cpp/aspose.slides/isection/get_startedfromslide/) возвращает его первый слайд; для пустого раздела он возвращает `nullptr`.