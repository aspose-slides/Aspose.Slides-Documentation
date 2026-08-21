---
title: Управление руководящими линиями в презентациях в .NET
linktitle: Руководящие линии
type: docs
weight: 85
url: /ru/net/drawing-guides/
keywords:
- руководящая линия
- горизонтальная линия
- вертикальная линия
- линия выравнивания
- просмотр слайда
- мастер‑слайд
- слайд‑макет
- мастер заметок
- мастер раздаточных материалов
- PowerPoint
- презентация
- .NET
- C#
- Aspose.Slides
description: "Добавляйте, получайте доступ и удаляйте горизонтальные и вертикальные руководящие линии в презентациях PowerPoint с помощью Aspose.Slides для .NET."
---
## **Обзор**

Руководящие линии — это регулируемые горизонтальные и вертикальные линии, помогающие пользователям выравнивать объекты последовательно при редактировании презентации в PowerPoint. Они особенно полезны, когда приложение генерирует презентацию, которую затем нужно доработать вручную: приложение может сохранить те же вспомогательные линии выравнивания, которым авторы должны следовать при добавлении или перемещении содержимого.

Руководящие линии являются средствами редактирования, а не содержимым слайда. Они не отображаются в показе слайдов и не включаются в вывод. Aspose.Slides for .NET предоставляет их через интерфейс [IDrawingGuidesCollection](https://reference.aspose.com/slides/ru/net/aspose.slides/idrawingguidescollection/). Одна линия представлена объектом [IDrawingGuide](https://reference.aspose.com/slides/ru/net/aspose.slides/idrawingguide/), у которой есть ориентация, позиция и цвет.

Позиция измеряется в пунктах от верхнего левого угла соответствующего слайда или шаблона. Вертикальная линия использует горизонтальную координату, обычно в диапазоне от нуля до ширины слайда. Горизонтальная линия использует вертикальную координату, обычно в диапазоне от нуля до высоты слайда.

## **Добавление руководящих линий в представление слайда**

Используйте [ICommonSlideViewProperties.DrawingGuides](https://reference.aspose.com/slides/ru/net/aspose.slides/icommonslideviewproperties/drawingguides/) для управления линиями, отображаемыми при редактировании обычных слайдов. Вызовите [IDrawingGuidesCollection.Add](https://reference.aspose.com/slides/ru/net/aspose.slides/idrawingguidescollection/add/) с параметром [Orientation](https://reference.aspose.com/slides/ru/net/aspose.slides/orientation/) и позицией в пунктах.

Следующий пример добавляет одну вертикальную линию справа от центра слайда и одну горизонтальную линию ниже него:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var slideSize = presentation.SlideSize.Size;
var guides = presentation.ViewProperties.SlideViewProperties.DrawingGuides;

guides.Add(Orientation.Vertical, slideSize.Width / 2 + 12.5f);
guides.Add(Orientation.Horizontal, slideSize.Height / 2 + 12.5f);

presentation.Save("drawing-guides.pptx", SaveFormat.Pptx);
```

## **Доступ к руководящим линиям**

Свойство [IDrawingGuidesCollection.Count](https://reference.aspose.com/slides/ru/net/aspose.slides/idrawingguidescollection/count/) и индексатор предоставляют доступ к существующим линиям. Свойства [IDrawingGuide.Orientation](https://reference.aspose.com/slides/ru/net/aspose.slides/idrawingguide/orientation/), [IDrawingGuide.Position](https://reference.aspose.com/slides/ru/net/aspose.slides/idrawingguide/position/) и [IDrawingGuide.Color](https://reference.aspose.com/slides/ru/net/aspose.slides/idrawingguide/color/) можно читать и изменять.

Следующий пример считывает линии представления слайдов из презентации, созданной выше:

```csharp
using Aspose.Slides;

using var presentation = new Presentation("drawing-guides.pptx");

var guides = presentation.ViewProperties.SlideViewProperties.DrawingGuides;

for (var index = 0; index < guides.Count; index++)
{
    var guide = guides[index];
    Console.WriteLine($"Guide {index}: orientation = {guide.Orientation}, position = {guide.Position}, color = {guide.Color}");
}
```

## **Добавление руководящих линий к мастеру и слайдам макета**

У мастера слайда и у каждого его слайда‑макета могут быть собственные коллекции руководящих линий. Используйте [IMasterSlide.DrawingGuides](https://reference.aspose.com/slides/ru/net/aspose.slides/imasterslide/drawingguides/) для мастера слайда и [ILayoutSlide.DrawingGuides](https://reference.aspose.com/slides/ru/net/aspose.slides/ilayoutslide/drawingguides/) для слайда‑макета.

Следующий пример добавляет вертикальную линию к первому мастеру слайдов и горизонтальную линию к первому слайду‑макету:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var slideSize = presentation.SlideSize.Size;
var masterGuides = presentation.Masters[0].DrawingGuides;
var layoutGuides = presentation.LayoutSlides[0].DrawingGuides;

masterGuides.Add(Orientation.Vertical, slideSize.Width / 2 - 20f);
layoutGuides.Add(Orientation.Horizontal, slideSize.Height / 2 + 20f);

presentation.Save("master-layout-drawing-guides.pptx", SaveFormat.Pptx);
```

## **Добавление руководящих линий к мастерам заметок и раздаточных материалов**

Мастера заметок и раздаточных материалов также поддерживают руководящие линии. Используйте [IMasterNotesSlide.DrawingGuides](https://reference.aspose.com/slides/ru/net/aspose.slides/imasternotesslide/drawingguides/) и [IMasterHandoutSlide.DrawingGuides](https://reference.aspose.com/slides/ru/net/aspose.slides/imasterhandoutslide/drawingguides/) для доступа к их коллекциям. Если презентация не содержит один из этих мастеров, [IMasterNotesSlideManager.SetDefaultMasterNotesSlide](https://reference.aspose.com/slides/ru/net/aspose.slides/imasternotesslidemanager/setdefaultmasternotesslide/) или [IMasterHandoutSlideManager.SetDefaultMasterHandoutSlide](https://reference.aspose.com/slides/ru/net/aspose.slides/imasterhandoutslidemanager/setdefaultmasterhandoutslide/) создаёт мастер по умолчанию и возвращает его.

Следующий пример добавляет горизонтальную линию к мастеру заметок и вертикальную линию к мастеру раздаточного материала:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var notesSize = presentation.NotesSize.Size;
var notesMaster = presentation.MasterNotesSlideManager.SetDefaultMasterNotesSlide();
var handoutMaster = presentation.MasterHandoutSlideManager.SetDefaultMasterHandoutSlide();

notesMaster.DrawingGuides.Add(Orientation.Horizontal, notesSize.Height / 2 + 50f);
handoutMaster.DrawingGuides.Add(Orientation.Vertical, notesSize.Width / 2 - 50f);

presentation.Save("notes-handout-drawing-guides.pptx", SaveFormat.Pptx);
```

## **Очистка руководящих линий**

Вызовите [IDrawingGuidesCollection.Clear](https://reference.aspose.com/slides/ru/net/aspose.slides/idrawingguidescollection/clear/) , чтобы удалить все линии из определенной коллекции. Очистка одной коллекции не влияет на линии, хранящиеся в другой области.

Следующий пример очищает линии представления слайдов и все линии на мастерах слайдов, слайдах‑макетах, мастере заметок и мастере раздаточного материала без создания отсутствующих мастеров:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation-with-guides.pptx");

presentation.ViewProperties.SlideViewProperties.DrawingGuides.Clear();

foreach (var masterSlide in presentation.Masters)
{
    masterSlide.DrawingGuides.Clear();
}

foreach (var layoutSlide in presentation.LayoutSlides)
{
    layoutSlide.DrawingGuides.Clear();
}

var notesMaster = presentation.MasterNotesSlideManager.MasterNotesSlide;
if (notesMaster != null)
{
    notesMaster.DrawingGuides.Clear();
}

var handoutMaster = presentation.MasterHandoutSlideManager.MasterHandoutSlide;
if (handoutMaster != null)
{
    handoutMaster.DrawingGuides.Clear();
}

presentation.Save("presentation-without-guides.pptx", SaveFormat.Pptx);
```

## **FAQ**

**Появляются ли руководящие линии в показе слайдов или экспортированных изображениях?**

Нет. Руководящие линии служат вспомогательными средствами выравнивания при редактировании и не отображаются как содержимое презентации.

**Можно ли добавить руководящую линию непосредственно к отдельному обычному слайду?**

Руководящие линии обычных слайдов хранятся в свойствах представления слайдов презентации. Отдельные коллекции линий доступны для мастеров слайдов, слайдов‑макетов, мастеров заметок и мастеров раздаточных материалов.

**Какие единицы измерения используются для позиций линий?**

Позиции задаются в пунктах, где 72 пункта равны одному дюйму. Вертикальные позиции измеряются от левого края, горизонтальные — от верхнего края.

**Удаляет ли очистка руководящих линий формы или изменяет содержимое слайда?**

Нет. Метод `Clear` удаляет только линии в выбранной коллекции. Формы и другое содержимое слайда остаются без изменений.