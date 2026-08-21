---
title: 在 .NET 中管理演示文稿的绘图参考线
linktitle: 绘图参考线
type: docs
weight: 85
url: /zh/net/drawing-guides/
keywords:
- 绘图参考线
- 水平参考线
- 垂直参考线
- 对齐参考线
- 幻灯片视图
- 母版幻灯片
- 版式幻灯片
- 备注母版
- 讲义母版
- PowerPoint
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 在 PowerPoint 演示文稿中添加、访问和清除水平和垂直绘图参考线。"
---
## **概述**

绘图参考线是可调节的水平和垂直线，可帮助用户在 PowerPoint 中编辑演示文稿时始终如一地对齐形状。它们在应用程序生成演示文稿并随后需要手动精细调整时特别有用：应用程序可以保存相同的对齐辅助，作者在添加或移动内容时应遵循这些辅助。

绘图参考线是编辑辅助，而非幻灯片内容。它们不会出现在幻灯片放映或渲染的输出中。Aspose.Slides for .NET 通过 [IDrawingGuidesCollection](https://reference.aspose.com/slides/zh/net/aspose.slides/idrawingguidescollection/) 接口公开它们。参考线由 [IDrawingGuide](https://reference.aspose.com/slides/zh/net/aspose.slides/idrawingguide/) 表示，具有方向、位置和颜色。

位置以点为单位，从相关幻灯片或母版的左上角测量。垂直参考线使用水平坐标，通常在0到幻灯片宽度之间。水平参考线使用垂直坐标，通常在0到幻灯片高度之间。

## **在幻灯片视图中添加参考线**

使用 [ICommonSlideViewProperties.DrawingGuides](https://reference.aspose.com/slides/zh/net/aspose.slides/icommonslideviewproperties/drawingguides/) 来管理在编辑普通幻灯片时显示的参考线。使用带有 [Orientation](https://reference.aspose.com/slides/zh/net/aspose.slides/orientation/) 值和以点为单位位置的 [IDrawingGuidesCollection.Add](https://reference.aspose.com/slides/zh/net/aspose.slides/idrawingguidescollection/add/) 方法。

下面的示例在幻灯片中心右侧添加一条垂直参考线，并在其下方添加一条水平参考线：

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

## **访问绘图参考线**

[IDrawingGuidesCollection.Count](https://reference.aspose.com/slides/zh/net/aspose.slides/idrawingguidescollection/count/) 属性和索引器提供对现有参考线的访问。可以读取或更改 [IDrawingGuide.Orientation](https://reference.aspose.com/slides/zh/net/aspose.slides/idrawingguide/orientation/)、[IDrawingGuide.Position](https://reference.aspose.com/slides/zh/net/aspose.slides/idrawingguide/position/) 和 [IDDrawingGuide.Color](https://reference.aspose.com/slides/zh/net/aspose.slides/idrawingguide/color/) 属性。

下面的示例读取上面创建的演示文稿中的幻灯片视图参考线：

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

## **向母版和版式幻灯片添加参考线**

幻灯片母版及其每个版式幻灯片都可以拥有自己的绘图参考线集合。对母版幻灯片使用 [IMasterSlide.DrawingGuides](https://reference.aspose.com/slides/zh/net/aspose.slides/imasterslide/drawingguides/)，对版式幻灯片使用 [ILayoutSlide.DrawingGuides](https://reference.aspose.com/slides/zh/net/aspose.slides/ilayoutslide/drawingguides/)。

下面的示例向第一个母版幻灯片添加一条垂直参考线，并向第一个版式幻灯片添加一条水平参考线：

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

## **向备注和讲义母版添加参考线**

备注母版和讲义母版也支持绘图参考线。使用 [IMasterNotesSlide.DrawingGuides](https://reference.aspose.com/slides/zh/net/aspose.slides/imasternotesslide/drawingguides/) 和 [IMasterHandoutSlide.DrawingGuides](https://reference.aspose.com/slides/zh/net/aspose.slides/imasterhandoutslide/drawingguides/) 访问它们的集合。如果演示文稿不包含这些母版之一，[IMasterNotesSlideManager.SetDefaultMasterNotesSlide](https://reference.aspose.com/slides/zh/net/aspose.slides/imasternotesslidemanager/setdefaultmasternotesslide/) 或 [IMasterHandoutSlideManager.SetDefaultMasterHandoutSlide](https://reference.aspose.com/slides/zh/net/aspose.slides/imasterhandoutslidemanager/setdefaultmasterhandoutslide/) 将创建默认母版并返回它。

下面的示例向备注母版添加一条水平参考线，并向讲义母版添加一条垂直参考线：

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

## **清除绘图参考线**

调用 [IDrawingGuidesCollection.Clear](https://reference.aspose.com/slides/zh/net/aspose.slides/idrawingguidescollection/clear/) 可删除特定集合中的所有参考线。清除一个集合不会影响存储在其他范围中的参考线。

下面的示例在不创建缺失母版的情况下，清除幻灯片视图参考线以及幻灯片母版、版式幻灯片、备注母版和讲义母版上的所有参考线：

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

## **常见问题**

**绘图参考线会出现在幻灯片放映或导出的图像中吗？**

不会。绘图参考线是用于编辑的对齐辅助，不会作为演示内容进行渲染。

**可以直接向单个普通幻灯片添加绘图参考线吗？**

普通幻灯片的编辑参考线存储在演示文稿的幻灯片视图属性中。幻灯片母版、版式幻灯片、备注母版和讲义母版都有各自的参考线集合。

**参考线位置使用哪种单位？**

位置以点为单位指定，72 点等于一英寸。垂直位置从左边缘测量，水平位置从上边缘测量。

**清除绘图参考线会删除形状或更改幻灯片内容吗？**

不会。`Clear` 方法仅删除所选集合中的参考线。形状和其他幻灯片内容保持不变。