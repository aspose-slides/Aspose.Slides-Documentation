---
title: 使用 C++ 在 PowerPoint 演示文稿中管理 SmartArt
linktitle: 管理 SmartArt
type: docs
weight: 10
url: /zh/cpp/manage-smartart/
keywords:
- SmartArt
- SmartArt 文本
- 布局类型
- 隐藏属性
- 组织结构图
- 图片组织结构图
- PowerPoint
- 演示文稿
- C++
- Aspose.Slides
description: "学习使用 Aspose.Slides for C++ 构建和编辑 PowerPoint SmartArt，通过清晰的代码示例加速幻灯片设计和自动化。"
---
## **概述**

SmartArt 是由节点、节点形状和布局组成的 PowerPoint 图表。使用 Aspose.Slides for C++，您可以创建 SmartArt、从其节点读取文本、更改布局、检查隐藏节点、配置组织结构图布局以及创建图片组织结构图。

## **从 SmartArt 对象获取文本**

SmartArt 节点可以包含一个或多个形状。要读取节点形状中的文本，请遍历 [ISmartArt::get_AllNodes](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/ismartart/get_allnodes/)，然后读取由 [ISmartArtShape::get_TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/ismartartshape/get_textframe/) 返回的 [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/)。

示例需要一个至少包含一张幻灯片且第一张幻灯片的第一个形状为 SmartArt 对象的演示文稿。它会将每个可用的文本框打印到控制台。

```cpp
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/SmartArt/ISmartArt.h>
#include <DOM/SmartArt/ISmartArtNode.h>
#include <DOM/SmartArt/ISmartArtNodeCollection.h>
#include <DOM/SmartArt/ISmartArtShape.h>
#include <DOM/SmartArt/ISmartArtShapeCollection.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::SmartArt;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

auto smartArt = ExplicitCast<ISmartArt>(slide->get_Shape(0));
for (auto nodeIndex = 0; nodeIndex < smartArt->get_AllNodes()->get_Count(); nodeIndex++)
{
    auto node = smartArt->get_AllNodes()->idx_get(nodeIndex);
    for (auto shapeIndex = 0; shapeIndex < node->get_Shapes()->get_Count(); shapeIndex++)
    {
        auto nodeShape = node->get_Shape(shapeIndex);
        if (nodeShape->get_TextFrame() != nullptr)
        {
            Console::WriteLine(nodeShape->get_TextFrame()->get_Text());
        }
    }
}

presentation->Dispose();
```
## **更改 SmartArt 对象的布局类型**

SmartArt 布局决定节点的排列和连接方式。下面的示例创建一个使用 [SmartArtLayoutType](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/smartartlayouttype/) `BasicBlockList` 值的 SmartArt 对象，将其更改为 `BasicProcess` 值，并保存演示文稿。传递给 [IShapeCollection::AddSmartArt](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addsmartart/) 的位置和大小以点为单位。使用 [ISmartArt::set_Layout](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/ismartart/set_layout/) 可更改布局。

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/SmartArt/ISmartArt.h>
#include <DOM/SmartArt/SmartArtLayoutType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SmartArt;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

auto smartArt = slide->get_Shapes()->AddSmartArt(10.0f, 10.0f, 400.0f, 300.0f, SmartArtLayoutType::BasicBlockList);
smartArt->set_Layout(SmartArtLayoutType::BasicProcess);

presentation->Save(u"ChangeSmartArtLayout.pptx", SaveFormat::Pptx);
presentation->Dispose();
```
## **检查 SmartArt 节点是否隐藏**

[ISmartArtNode::get_IsHidden](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/ismartartnode/get_ishidden/) 指示节点在 SmartArt 数据模型中是否隐藏。即使所选布局未将其显示为可见图表元素，隐藏节点仍可能存在于结构中。

下面的示例向使用 [SmartArtLayoutType](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/smartartlayouttype/) `RadialCycle` 值的 SmartArt 对象添加一个节点，并检查该节点的隐藏状态。如果节点被隐藏，则打印一条消息并保存图表。

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/SmartArt/ISmartArt.h>
#include <DOM/SmartArt/ISmartArtNode.h>
#include <DOM/SmartArt/ISmartArtNodeCollection.h>
#include <DOM/SmartArt/SmartArtLayoutType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SmartArt;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

auto smartArt = slide->get_Shapes()->AddSmartArt(10.0f, 10.0f, 400.0f, 300.0f, SmartArtLayoutType::RadialCycle);
auto node = smartArt->get_AllNodes()->AddNode();
auto isHidden = node->get_IsHidden();

if (isHidden)
{
    Console::WriteLine(u"The node is hidden in the SmartArt data model.");
}

presentation->Save(u"CheckSmartArtHiddenProperty.pptx", SaveFormat::Pptx);
presentation->Dispose();
```
## **获取或设置组织结构图布局**

对于使用组织结构图布局的 SmartArt 图表，[ISmartArtNode::get_OrganizationChartLayout](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/ismartartnode/get_organizationchartlayout/) 和 [ISmartArtNode::set_OrganizationChartLayout](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/ismartartnode/set_organizationchartlayout/) 定义子节点在父节点下的排列方式。例如，您可以根据所选的 [OrganizationChartLayoutType](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/organizationchartlayouttype/) 将子节点挂在左侧、右侧或两侧。

下面的示例创建一个组织结构图，并将第一个节点的布局设置为 [OrganizationChartLayoutType](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/organizationchartlayouttype/) `LeftHanging` 值。基于零的索引 `0` 选取第一个顶层节点；其子节点使用所选的排列方式。随后保存修改后的演示文稿。

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/SmartArt/ISmartArt.h>
#include <DOM/SmartArt/ISmartArtNode.h>
#include <DOM/SmartArt/OrganizationChartLayoutType.h>
#include <DOM/SmartArt/SmartArtLayoutType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SmartArt;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

auto smartArt = slide->get_Shapes()->AddSmartArt(10.0f, 10.0f, 400.0f, 300.0f, SmartArtLayoutType::OrganizationChart);
auto rootNode = smartArt->get_Node(0);
rootNode->set_OrganizationChartLayout(OrganizationChartLayoutType::LeftHanging);

presentation->Save(u"OrganizationChartLayout.pptx", SaveFormat::Pptx);
presentation->Dispose();
```
## **创建图片组织结构图**

图片组织结构图是一种为包含图像占位符的层次结构图设计的 SmartArt 布局。向幻灯片添加 SmartArt 对象时使用 [SmartArtLayoutType](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/smartartlayouttype/) `PictureOrganizationChart` 值。此示例保存了带有图像占位符的图表；它不会将占位符填充为图像。

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/SmartArt/SmartArtLayoutType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SmartArt;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

auto smartArt = slide->get_Shapes()->AddSmartArt(0.0f, 0.0f, 400.0f, 400.0f, SmartArtLayoutType::PictureOrganizationChart);

presentation->Save(u"PictureOrganizationChart.pptx", SaveFormat::Pptx);
presentation->Dispose();
```
## **将旧版图表转换为形状组**

在对现有演示文稿进行现代化改造时，可能需要更新最初在 PowerPoint 97–2003 中创建的组织结构图。Aspose.Slides 将这些旧版图表表示为 [ILegacyDiagram](https://reference.aspose.com/slides/cpp/aspose.slides/ilegacydiagram/) 对象。使用 [ILegacyDiagram::ConvertToGroupShape](https://reference.aspose.com/slides/cpp/aspose.slides/ilegacydiagram/converttogroupshape/) 可将图表转换为形状组，以便编辑各个可视元素。有关详细信息，请参阅 [LegacyDiagram API 参考](https://reference.aspose.com/slides/cpp/aspose.slides/legacydiagram/)。

转换会在形状集合中添加一个新组，而不会删除原始图表。转换成功后，使用 [IShapeCollection::Remove](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/remove/) 删除原始图表，以避免内容重复。在转换之前先将旧版图表收集到向量中，这样在添加和删除形状时不会扰乱迭代。

下面的示例打开一个演示文稿，遍历每张幻灯片，将图表转换为形状组，并将更新后的演示文稿保存为 PPTX。

```cpp
#include <DOM/ILegacyDiagram.h>
#include <DOM/IGroupShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <vector>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"legacy-diagrams.ppt");

for (auto slideIndex = 0; slideIndex < presentation->get_Slides()->get_Count(); slideIndex++)
{
    auto slide = presentation->get_Slide(slideIndex);
    std::vector<SharedPtr<ILegacyDiagram>> legacyDiagrams;

    for (auto shapeIndex = 0; shapeIndex < slide->get_Shapes()->get_Count(); shapeIndex++)
    {
        auto shape = slide->get_Shape(shapeIndex);
        if (ObjectExt::Is<ILegacyDiagram>(shape))
        {
            auto legacyDiagram = ExplicitCast<ILegacyDiagram>(shape);
            legacyDiagrams.push_back(legacyDiagram);
        }
    }

    for (auto legacyDiagram : legacyDiagrams)
    {
        auto groupShape = legacyDiagram->ConvertToGroupShape();

        if (groupShape != nullptr)
        {
            slide->get_Shapes()->Remove(legacyDiagram);
        }
    }
}

presentation->Save(u"modernized.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

保存的演示文稿在已转换的旧版图表位置包含可编辑的形状组，原始图表不再保留。打开 PPTX 并在 PowerPoint 中编辑每个组内的单独元素，例如文本、填充或位置。

## **常见问题解答**

**SmartArt 是否支持 RTL 语言的镜像或反转？**

是的。当所选 SmartArt 布局支持反转时，[SmartArt::set_IsReversed](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/smartart/set_isreversed/) 方法可将图表方向从从左到右切换为从右到左，或反之。

**如何在保留格式的前提下将 SmartArt 复制到同一幻灯片或另一演示文稿？**

您可以通过 [克隆 SmartArt 形状](/slides/zh/cpp/shape-manipulations/) 使用 [ShapeCollection::AddClone](https://reference.aspose.com/slides/cpp/aspose.slides/shapecollection/addclone/)，或通过 [克隆整个幻灯片](/slides/zh/cpp/clone-slides/) 将包含 SmartArt 的幻灯片整体克隆。两种方法都能保留大小、位置和格式。

**如何将 SmartArt 渲染为栅格图像以进行预览或网页导出？**

[渲染幻灯片](/slides/zh/cpp/convert-powerpoint-to-png/) 或将整个演示文稿渲染为 PNG 或 JPEG。SmartArt 将作为幻灯片的一部分进行渲染。

**如果幻灯片上有多个 SmartArt 对象，如何找到特定的对象？**

在 SmartArt 形状上设置唯一的 [Shape::set_AlternativeText](https://reference.aspose.com/slides/cpp/aspose.slides/shape/set_alternativetext/) 或 [Shape::set_Name](https://reference.aspose.com/slides/cpp/aspose.slides/shape/set_name/) 值，在 [BaseSlide::get_Shapes](https://reference.aspose.com/slides/cpp/aspose.slides/baseslide/get_shapes/) 中搜索该值，然后检查匹配的形状是否为 [ISmartArt](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/ismartart/)。