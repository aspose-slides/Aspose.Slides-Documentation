---
title: Управление разделами слайдов в презентациях на .NET
linktitle: Раздел слайдов
type: docs
weight: 100
url: /ru/net/slide-section/
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
- .NET
- C#
- Aspose.Slides
description: "Управляйте разделами слайдов с помощью Aspose.Slides для .NET: создавайте, переименовывайте, переупорядочивайте, получайте и обрабатывайте слайды разделов в презентациях PPTX."
---
## **Введение**

Разделы упорядочивают последовательные слайды в именованные группы без изменения содержимого слайдов. С помощью Aspose.Slides для .NET вы можете создавать, переупорядочивать, переименовывать, просматривать и удалять разделы через свойство [Presentation.Sections](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/sections/) .

Разделы особенно полезны, когда:
- большая презентация должна быть разделена на логические темы или главы;
- различные группы слайдов назначаются разным сотрудникам;
- требуется обработка, перемещение или объединение слайдов как групп.

Выбирайте короткие имена разделов, описывающие назначение сгруппированных слайдов. Поскольку разделы являются частью структуры презентации, используйте API разделов для определения членства, а не выводите его из позиций слайдов.

## **Создание и управление разделами**

Используйте [ISectionCollection.AddSection](https://reference.aspose.com/slides/ru/net/aspose.slides/sectioncollection/addsection/) чтобы создать раздел, указав его имя и начальный слайд. Aspose.Slides определяет, какие слайды принадлежат разделу, исходя из текущей структуры разделов презентации.

Тот же [ISectionCollection](https://reference.aspose.com/slides/ru/net/aspose.slides/isectioncollection/) также позволяет:
- переместить раздел вместе с его слайдами, используя [ISectionCollection.ReorderSectionWithSlides](https://reference.aspose.com/slides/ru/net/aspose.slides/sectioncollection/reordersectionwithslides/) ;
- удалить только определение раздела с помощью [ISectionCollection.RemoveSection](https://reference.aspose.com/slides/ru/net/aspose.slides/sectioncollection/removesection/), при этом сохраняются его слайды ;
- удалить раздел и его слайды с помощью [ISectionCollection.RemoveSectionWithSlides](https://reference.aspose.com/slides/ru/net/aspose.slides/sectioncollection/removesectionwithslides/) ;
- добавить пустой раздел в конец с помощью [ISectionCollection.AppendEmptySection](https://reference.aspose.com/slides/ru/net/aspose.slides/sectioncollection/appendemptysection/) .

В следующем примере создаются два раздела, перемещается один из них, удаляется вместе с его слайдами, а затем добавляется пустой раздел:

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var titleSlide = presentation.Slides[0];
presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);
var resultsSlide = presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);
presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);

presentation.Sections.AddSection("Introduction", titleSlide);
var resultsSection = presentation.Sections.AddSection("Results", resultsSlide);

presentation.Sections.ReorderSectionWithSlides(resultsSection, 0);
presentation.Sections.RemoveSectionWithSlides(resultsSection);
presentation.Sections.AppendEmptySection("Appendix");
```

После этих операций презентация содержит раздел `Introduction` со своими слайдами и пустой раздел `Appendix`. Раздел `Results` и его слайды были удалены.

## **Переименование разделов**

Чтобы переименовать раздел, установите его свойство [ISection.Name](https://reference.aspose.com/slides/ru/net/aspose.slides/isection/name/). Слайды раздела и его позиция остаются без изменений.

В следующем примере создаётся раздел и меняется его название:

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var section = presentation.Sections.AddSection("Overview", slide);
section.Name = "Introduction";
```

## **Получение слайдов из разделов**

Свойство [Presentation.Sections](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/sections/) возвращает [ISectionCollection](https://reference.aspose.com/slides/ru/net/aspose.slides/isectioncollection/), который можно перечислять. Для каждого [ISection](https://reference.aspose.com/slides/ru/net/aspose.slides/isection/) вызовите [ISection.GetSlidesListOfSection](https://reference.aspose.com/slides/ru/net/aspose.slides/isection/getslideslistofsection/), чтобы получить слайды, принадлежащие ему в данный момент. Метод возвращает [ISectionSlideCollection](https://reference.aspose.com/slides/ru/net/aspose.slides/isectionslidecollection/), который предоставляет количество, индексированный доступ и перечисление.

В следующем примере создаются два заполненных раздела и один пустой раздел, после чего выводятся [name](https://reference.aspose.com/slides/ru/net/aspose.slides/isection/name/) , [identifier](https://reference.aspose.com/slides/ru/net/aspose.slides/isection/sectionid/) , [starting slide](https://reference.aspose.com/slides/ru/net/aspose.slides/isection/startedfromslide/) , количество слайдов и номера слайдов каждого раздела. Для доступа к первому слайду используется индексатор коллекции, а `foreach` — для обработки каждого слайда. Для пустого раздела возвращённая коллекция имеет количество 0, индексатор не вызывается, и перечисление не выполняет итераций.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation();
var firstSlide = presentation.Slides[0];
presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);
var thirdSlide = presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);

presentation.Sections.AddSection("Introduction", firstSlide);
presentation.Sections.AddSection("Details", thirdSlide);
presentation.Sections.AppendEmptySection("Appendix");

foreach (var section in presentation.Sections)
{
    var sectionSlides = section.GetSlidesListOfSection();
    var startingSlide = section.StartedFromSlide == null ? "none" : section.StartedFromSlide.SlideNumber.ToString();

    Console.WriteLine($"Section: {section.Name}");
    Console.WriteLine($"ID: {section.SectionId}");
    Console.WriteLine($"Starting slide: {startingSlide}");
    Console.WriteLine($"Slide count: {sectionSlides.Count}");

    if (sectionSlides.Count > 0)
    {
        Console.WriteLine($"First slide via indexer: {sectionSlides[0].SlideNumber}");
    }

    Console.Write("Slide numbers:");
    foreach (var slide in sectionSlides)
    {
        Console.Write($" {slide.SlideNumber}");
    }
    Console.WriteLine();
}
```

Членство в разделе определяется структурой разделов презентации. Не вычисляйте диапазон раздела вручную, используя [ISection.StartedFromSlide](https://reference.aspose.com/slides/ru/net/aspose.slides/isection/startedfromslide/), индексы слайдов и начальный слайд следующего раздела.

Структурные правки могут менять как список слайдов, возвращаемый для раздела, так и их номера. Это включает переупорядочивание слайдов, клонирование слайда в раздел, перемещение раздела вместе с его слайдами, удаление слайдов и удаление разделов. В следующем примере [ISection.GetSlidesListOfSection](https://reference.aspose.com/slides/ru/net/aspose.slides/isection/getslideslistofsection/) вызывается после каждой такой правки, вместо того чтобы сохранять предположения о прежних границах раздела.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation();
var firstSlide = presentation.Slides[0];
presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);
var thirdSlide = presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);
presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);
var firstSection = presentation.Sections.AddSection("First", firstSlide);
var secondSection = presentation.Sections.AddSection("Second", thirdSlide);

static void PrintSectionSlides(string label, ISection section)
{
    var sectionSlides = section.GetSlidesListOfSection();
    Console.Write($"{label} ({sectionSlides.Count} slides):");
    foreach (var slide in sectionSlides)
    {
        Console.Write($" {slide.SlideNumber}");
    }
    Console.WriteLine();
}

PrintSectionSlides("Initially", firstSection);

var slidesBeforeClone = firstSection.GetSlidesListOfSection();
presentation.Slides.AddClone(slidesBeforeClone[0], firstSection);
PrintSectionSlides("After cloning into the section", firstSection);

var slidesBeforeReorder = firstSection.GetSlidesListOfSection();
var firstSectionPosition = slidesBeforeReorder[0].SlideNumber - 1;
presentation.Slides.Reorder(firstSectionPosition, slidesBeforeReorder[slidesBeforeReorder.Count - 1]);
PrintSectionSlides("After reordering slides", firstSection);

presentation.Sections.ReorderSectionWithSlides(firstSection, 1);
PrintSectionSlides("After moving the section", firstSection);

var slidesBeforeRemoval = firstSection.GetSlidesListOfSection();
presentation.Slides.Remove(slidesBeforeRemoval[0]);
PrintSectionSlides("After removing a slide", firstSection);

presentation.Sections.RemoveSectionWithSlides(secondSection);
foreach (var section in presentation.Sections)
{
    PrintSectionSlides("Remaining section", section);
}
```

Вызывайте [ISection.GetSlidesListOfSection](https://reference.aspose.com/slides/ru/net/aspose.slides/isection/getslideslistofsection/) каждый раз, когда слайды или разделы переупорядочиваются, клонируются, перемещаются или удаляются. Это гарантирует, что последующая обработка соответствует текущей структуре презентации.

Формат PPT (PowerPoint 97–2003) не сохраняет метаданные разделов. Используйте этот процесс с форматом, поддерживающим разделы, например PPTX; преобразование в PPT удаляет структуру разделов, необходимую для последующего перечисления.

## **FAQ**

**Сохраняются ли разделы при сохранении в формат PPT (PowerPoint 97–2003)?**

Нет. Формат PPT не поддерживает метаданные разделов, поэтому группировка разделов теряется при сохранении в .ppt.

**Можно ли полностью "скрыть" раздел?**

Нет. У раздела нет состояния видимости. Чтобы скрыть его содержимое, установите свойство [ISlide.Hidden](https://reference.aspose.com/slides/ru/net/aspose.slides/islide/hidden/) для каждого слайда в разделе.

**Как найти раздел, содержащий определённый слайд?**

Переберите [Presentation.Sections](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/sections/), вызовите [ISection.GetSlidesListOfSection](https://reference.aspose.com/slides/ru/net/aspose.slides/isection/getslideslistofsection/) для каждого раздела и сравните полученные слайды с целевым слайдом. Для непустого раздела [ISection.StartedFromSlide](https://reference.aspose.com/slides/ru/net/aspose.slides/isection/startedfromslide/) возвращает его первый слайд; для пустого раздела он возвращает `null`.