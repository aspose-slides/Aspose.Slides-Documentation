---
title: Управление SmartArt в презентациях PowerPoint на .NET
linktitle: Управление SmartArt
type: docs
weight: 10
url: /ru/net/manage-smartart/
keywords:
- SmartArt
- Текст SmartArt
- Тип макета
- Скрытое свойство
- Организационная диаграмма
- Организационная диаграмма с изображениями
- PowerPoint
- презентация
- .NET
- C#
- Aspose.Slides
description: "Узнайте, как создавать и редактировать SmartArt в PowerPoint с помощью Aspose.Slides для .NET, используя понятные примеры кода на C#, ускоряющие разработку слайдов и автоматизацию."
---
## **Обзор**

SmartArt — это диаграмма PowerPoint, состоящая из узлов, форм узлов и макета. С помощью Aspose.Slides для .NET вы можете создавать SmartArt, считывать текст из его узлов, менять макет, просматривать скрытые узлы, настраивать макеты организационных диаграмм и создавать организационные диаграммы с изображениями.

## **Получить текст из объекта SmartArt**

Узел SmartArt может содержать одну или несколько фигур. Чтобы прочитать текст из фигур узла, переберите [ISmartArt.AllNodes](https://reference.aspose.com/slides/net/aspose.slides.smartart/ismartart/allnodes/), затем считайте [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) , возвращаемый [ISmartArtShape.TextFrame](https://reference.aspose.com/slides/net/aspose.slides.smartart/ismartartshape/textframe/).

Пример требует презентацию с как минимум одним слайдом и объектом SmartArt в качестве первой фигуры на этом слайде. Он выводит каждый доступный текстовый фрейм в консоль.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.SmartArt;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var smartArt = (ISmartArt) slide.Shapes[0];
foreach (var node in smartArt.AllNodes)
{
    foreach (var nodeShape in node.Shapes)
    {
        if (nodeShape.TextFrame != null)
        {
            Console.WriteLine(nodeShape.TextFrame.Text);
        }
    }
}
```

## **Изменить тип макета объекта SmartArt**

Макет SmartArt контролирует расположение и соединение узлов. В следующем примере создаётся объект SmartArt с типом макета [SmartArtLayoutType](https://reference.aspose.com/slides/net/aspose.slides.smartart/smartartlayouttype/) `BasicBlockList`, затем он меняется на `BasicProcess` и презентация сохраняется. Позиция и размер, передаваемые в [IShapeCollection.AddSmartArt](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addsmartart/) , измеряются в пунктах. Установите [ISmartArt.Layout](https://reference.aspose.com/slides/net/aspose.slides.smartart/ismartart/layout/) , чтобы изменить макет.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var smartArt = slide.Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);
smartArt.Layout = SmartArtLayoutType.BasicProcess;

presentation.Save("ChangeSmartArtLayout.pptx", SaveFormat.Pptx);
```

## **Проверить, скрыт ли узел SmartArt**

[ISmartArtNode.IsHidden](https://reference.aspose.com/slides/net/aspose.slides.smartart/ismartartnode/ishidden/) указывает, скрыт ли узел в модели данных SmartArt. Скрытые узлы могут присутствовать в структуре, даже если выбранный макет не отображает их как видимые элементы диаграммы.

В следующем примере к объекту SmartArt, использующему тип макета [SmartArtLayoutType](https://reference.aspose.com/slides/net/aspose.slides.smartart/smartartlayouttype/) `RadialCycle`, добавляется узел, и проверяется его скрытое состояние. Если узел скрыт, выводится сообщение, и диаграмма сохраняется.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var smartArt = slide.Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);
var node = smartArt.AllNodes.AddNode();
var isHidden = node.IsHidden;

if (isHidden)
{
    Console.WriteLine("The node is hidden in the SmartArt data model.");
}

presentation.Save("CheckSmartArtHiddenProperty.pptx", SaveFormat.Pptx);
```

## **Получить или задать макет организационной диаграммы**

Для диаграмм SmartArt, использующих макет организационной диаграммы, [ISmartArtNode.OrganizationChartLayout](https://reference.aspose.com/slides/net/aspose.slides.smartart/ismartartnode/organizationchartlayout/) определяет, как дочерние узлы располагаются под родительским узлом. Например, можно задать дочерним узлам зависание слева, справа или с обеих сторон, в зависимости от выбранного [OrganizationChartLayoutType](https://reference.aspose.com/slides/net/aspose.slides.smartart/organizationchartlayouttype/).

В следующем примере создаётся организационная диаграмма и задаётся макет первого узла значением [OrganizationChartLayoutType](https://reference.aspose.com/slides/net/aspose.slides.smartart/organizationchartlayouttype/) `LeftHanging`. Индекс `0` (ноль‑основанный) выбирает первый узел верхнего уровня; его дочерние узлы используют выбранное расположение. Затем изменённая презентация сохраняется.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var smartArt = slide.Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);
var rootNode = smartArt.Nodes[0];
rootNode.OrganizationChartLayout = OrganizationChartLayoutType.LeftHanging;

presentation.Save("OrganizationChartLayout.pptx", SaveFormat.Pptx);
```

## **Создать организационную диаграмму с изображениями**

Организационная диаграмма с изображениями — это макет SmartArt, предназначенный для иерархических диаграмм с заполнителями изображений. При добавлении объекта SmartArt на слайд используйте значение [SmartArtLayoutType](https://reference.aspose.com/slides/net/aspose.slides.smartart/smartartlayouttype/) `PictureOrganizationChart`. Этот пример сохраняет диаграмму с заполнителями изображений; они не заполняются реальными изображениями.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var smartArt = slide.Shapes.AddSmartArt(0, 0, 400, 400, SmartArtLayoutType.PictureOrganizationChart);

presentation.Save("PictureOrganizationChart.pptx", SaveFormat.Pptx);
```

## **Преобразовать устаревшие диаграммы в группы фигур**

При модернизации существующей презентации может потребоваться обновить организационную диаграмму, созданную в PowerPoint 97–2003. Aspose.Slides представляет такие устаревшие диаграммы как объекты [ILegacyDiagram](https://reference.aspose.com/slides/net/aspose.slides/ilegacydiagram/). Используйте [LegacyDiagram.ConvertToGroupShape](https://reference.aspose.com/slides/net/aspose.slides/legacydiagram/converttogroupshape/) , чтобы преобразовать диаграмму в группу фигур и затем редактировать отдельные визуальные элементы. Подробности см. в [LegacyDiagram API Reference](https://reference.aspose.com/slides/net/aspose.slides/legacydiagram/).

Преобразование добавляет новую группу в коллекцию фигур, не удаляя оригинальную диаграмму. После успешного преобразования удалите оригинал с помощью [IShapeCollection.Remove](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/remove/) , чтобы избежать дублирования контента. Сначала соберите устаревшие диаграммы в массив перед их преобразованием, чтобы добавление и удаление фигур не нарушали итерацию.

В следующем примере открывается презентация, просматриваются все слайды, диаграммы преобразуются в группы фигур и обновлённая презентация сохраняется как PPTX.

```csharp
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("legacy-diagrams.ppt");

foreach (var slide in presentation.Slides)
{
    var legacyDiagrams = slide.Shapes.OfType<ILegacyDiagram>().ToArray();
    foreach (var legacyDiagram in legacyDiagrams)
    {
        var groupShape = legacyDiagram.ConvertToGroupShape();

        if (groupShape != null)
        {
            slide.Shapes.Remove(legacyDiagram);
        }
    }
}

presentation.Save("modernized.pptx", SaveFormat.Pptx);
```

Сохранённая презентация содержит редактируемые группы фигур вместо преобразованных устаревших диаграмм, без оставшихся оригинальных диаграмм. Откройте PPTX в PowerPoint, чтобы редактировать отдельные элементы внутри каждой группы, такие как текст, заливка или позиция.

## **FAQ**

**Поддерживает ли SmartArt зеркальное отображение или обратную ориентацию для RTL‑языков?**

Да. Свойство [IsReversed](https://reference.aspose.com/slides/net/aspose.slides.smartart/smartart/isreversed/) переключает направление диаграммы слева направо на справа налево и обратно, если выбранный макет SmartArt поддерживает обратный порядок.

**Как скопировать SmartArt на тот же слайд или в другую презентацию, сохранив форматирование?**

Вы можете [клонировать фигуру SmartArt](/slides/ru/net/shape-manipulations/) с помощью [ShapeCollection.AddClone](https://reference.aspose.com/slides/net/aspose.slides/shapecollection/addclone/) либо [клонировать весь слайд](/slides/ru/net/clone-slides/) , содержащий SmartArt. Оба подхода сохраняют размер, позицию и форматирование.

**Как отрисовать SmartArt в растровое изображение для предпросмотра или экспорта в веб?**

[Отрендерите слайд](/slides/ru/net/convert-powerpoint-to-png/) или всю презентацию в PNG или JPEG. SmartArt отрисовывается как часть слайда.

**Как найти конкретный объект SmartArt на слайде, если их несколько?**

Задайте отличительное значение [AlternativeText](https://reference.aspose.com/slides/net/aspose.slides/shape/alternativetext/) или [Name](https://reference.aspose.com/slides/net/aspose.slides/shape/name/) у фигуры SmartArt, выполните поиск этого значения в [Slide.Shapes](https://reference.aspose.com/slides/net/aspose.slides/baseslide/shapes/), а затем проверьте, что найденная фигура является [ISmartArt](https://reference.aspose.com/slides/net/aspose.slides.smartart/ismartart/).