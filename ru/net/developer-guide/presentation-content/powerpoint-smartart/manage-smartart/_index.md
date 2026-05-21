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
- Свойство скрытия
- Организационная диаграмма
- Картинная организационная диаграмма
- PowerPoint
- Презентация
- .NET
- C#
- Aspose.Slides
description: "Изучите создание и редактирование SmartArt в PowerPoint с помощью Aspose.Slides для .NET, используя понятные примеры кода C#, ускоряющие разработку слайдов и автоматизацию."
---
## **Обзор**

SmartArt — это диаграмма PowerPoint, состоящая из узлов, форм узлов и макета. С помощью Aspose.Slides для .NET вы можете создавать SmartArt, читать текст из его узлов, менять макет, проверять скрытые узлы, настраивать макеты организационных диаграмм и создавать организационные диаграммы с изображениями.

## **Получить текст из объекта SmartArt**

Узел SmartArt может содержать одну или несколько форм. Чтобы прочитать видимый текст, пройдите по [ISmartArt.AllNodes](https://reference.aspose.com/slides/ru/net/aspose.slides.smartart/ismartart/allnodes/), затем считайте [ITextFrame](https://reference.aspose.com/slides/ru/net/aspose.slides/itextframe/) , возвращаемый [ISmartArtShape.TextFrame](https://reference.aspose.com/slides/ru/net/aspose.slides.smartart/ismartartshape/textframe/).

```c#
using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    if (slide.Shapes[0] is ISmartArt smartArt)
    {
        foreach (ISmartArtNode node in smartArt.AllNodes)
        {
            foreach (ISmartArtShape nodeShape in node.Shapes)
            {
                if (nodeShape.TextFrame != null)
                {
                    Console.WriteLine(nodeShape.TextFrame.Text);
                }
            }
        }
    }
}
```

## **Изменить тип макета объекта SmartArt**

Макет SmartArt определяет, как узлы размещаются и соединяются. В следующем примере создаётся объект SmartArt с типом [SmartArtLayoutType](https://reference.aspose.com/slides/ru/net/aspose.slides.smartart/smartartlayouttype/) `BasicBlockList`, затем он меняется на значение `BasicProcess` и сохраняется презентация.

```c#
using (Presentation presentation = new Presentation())
{
    ISmartArt smartArt = presentation.Slides[0].Shapes.AddSmartArt(
        10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

    smartArt.Layout = SmartArtLayoutType.BasicProcess;

    presentation.Save("ChangeSmartArtLayout_out.pptx", SaveFormat.Pptx);
}
```

## **Проверить, скрыт ли узел SmartArt**

[ISmartArtNode.IsHidden](https://reference.aspose.com/slides/ru/net/aspose.slides.smartart/ismartartnode/ishidden/) указывает, скрыт ли узел в модели данных SmartArt. Скрытые узлы могут присутствовать в структуре, даже если выбранный макет не отображает их как видимые элементы диаграммы.

В следующем примере к объекту SmartArt, использующему тип [SmartArtLayoutType](https://reference.aspose.com/slides/ru/net/aspose.slides.smartart/smartartlayouttype/) `RadialCycle`, добавляется узел и проверяется состояние скрытия узла.

```c#
using (Presentation presentation = new Presentation())
{
    ISmartArt smartArt = presentation.Slides[0].Shapes.AddSmartArt(
        10, 10, 400, 300, SmartArtLayoutType.RadialCycle);

    ISmartArtNode node = smartArt.AllNodes.AddNode();
    bool isHidden = node.IsHidden;

    if (isHidden)
    {
        Console.WriteLine("The node is hidden in the SmartArt data model.");
    }

    presentation.Save("CheckSmartArtHiddenProperty_out.pptx", SaveFormat.Pptx);
}
```

## **Получить или задать макет организационной диаграммы**

Для диаграмм SmartArt, использующих макет организационной диаграммы, [ISmartArtNode.OrganizationChartLayout](https://reference.aspose.com/slides/ru/net/aspose.slides.smartart/ismartartnode/organizationchartlayout/) определяет, как дочерние узлы располагаются под родительским узлом. Например, можно задать дочерним узлам висячее расположение слева, справа или с обеих сторон, в зависимости от выбранного [OrganizationChartLayoutType](https://reference.aspose.com/slides/ru/net/aspose.slides.smartart/organizationchartlayouttype/).

В следующем примере создаётся организационная диаграмма, и для первого узла задаётся макет [OrganizationChartLayoutType](https://reference.aspose.com/slides/ru/net/aspose.slides.smartart/organizationchartlayouttype/) `LeftHanging`.

```c#
using (Presentation presentation = new Presentation())
{
    ISmartArt smartArt = presentation.Slides[0].Shapes.AddSmartArt(
        10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);

    ISmartArtNode rootNode = smartArt.Nodes[0];
    rootNode.OrganizationChartLayout = OrganizationChartLayoutType.LeftHanging;

    presentation.Save("OrganizationChartLayout_out.pptx", SaveFormat.Pptx);
}
```

## **Создать картинную организационную диаграмму**

Картинная организационная диаграмма — это макет SmartArt, предназначенный для иерархических диаграмм с заполнителями изображений. При добавлении объекта SmartArt на слайд используйте тип [SmartArtLayoutType](https://reference.aspose.com/slides/ru/net/aspose.slides.smartart/smartartlayouttype/) `PictureOrganizationChart`.

```c#
using (Presentation presentation = new Presentation())
{
    ISmartArt smartArt = presentation.Slides[0].Shapes.AddSmartArt(
        0, 0, 400, 400, SmartArtLayoutType.PictureOrganizationChart);

    presentation.Save("PictureOrganizationChart_out.pptx", SaveFormat.Pptx);
}
```

## **Часто задаваемые вопросы**

**Поддерживает ли SmartArt зеркалирование или обратное отображение для RTL‑языков?**

Да. Свойство [IsReversed](https://reference.aspose.com/slides/ru/net/aspose.slides.smartart/smartart/isreversed/) изменяет направление диаграммы с слева направо на справа налево и обратно, если выбранный макет SmartArt поддерживает обратное отображение.

**Как скопировать SmartArt на тот же слайд или в другую презентацию, сохранив форматирование?**

Вы можете [клонировать форму SmartArt](/slides/ru/net/shape-manipulations/) с помощью [ShapeCollection.AddClone](https://reference.aspose.com/slides/ru/net/aspose.slides/shapecollection/addclone/) или [клонировать весь слайд](/slides/ru/net/clone-slides/), содержащий SmartArt. Оба подхода сохраняют размер, позицию и форматирование.

**Как отрендерить SmartArt в растровое изображение для предварительного просмотра или экспорта в веб?**

[Отрендерите слайд](/slides/ru/net/convert-powerpoint-to-png/) или всю презентацию в PNG или JPEG. SmartArt рендерится как часть слайда.

**Как найти конкретный объект SmartArt на слайде, если их несколько?**

Задайте уникальное значение [AlternativeText](https://reference.aspose.com/slides/ru/net/aspose.slides/shape/alternativetext/) или [Name](https://reference.aspose.com/slides/ru/net/aspose.slides/shape/name/) для формы SmartArt, выполните поиск этого значения в [Slide.Shapes](https://reference.aspose.com/slides/ru/net/aspose.slides/baseslide/shapes/), а затем проверьте, что найденная форма является [ISmartArt](https://reference.aspose.com/slides/ru/net/aspose.slides.smartart/ismartart/).