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
description: "了解如何使用 Aspose.Slides for C++ 通过清晰的代码示例构建和编辑 PowerPoint SmartArt，加快幻灯片设计和自动化。"
---
## **概述**

SmartArt 是由节点、节点形状和布局组成的 PowerPoint 图表。使用 Aspose.Slides for C++，您可以创建 SmartArt、读取其节点中的文本、更改其布局、检查隐藏节点、配置组织结构图布局以及创建图片组织结构图。

## **获取 SmartArt 对象的文本**

SmartArt 节点可以包含一个或多个形状。要读取可见文本，请遍历 [ISmartArt::get_AllNodes](https://reference.aspose.com/slides/zh/cpp/aspose.slides.smartart/smartart/get_allnodes/)，然后读取由 [ISmartArtShape::get_TextFrame](https://reference.aspose.com/slides/zh/cpp/aspose.slides.smartart/smartartshape/get_textframe/) 返回的 [ITextFrame](https://reference.aspose.com/slides/zh/cpp/aspose.slides/itextframe/)。

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shape(0);

if (System::ObjectExt::Is<ISmartArt>(shape))
{
    auto smartArt = System::ExplicitCast<ISmartArt>(shape);

    for (int nodeIndex = 0; nodeIndex < smartArt->get_AllNodes()->get_Count(); nodeIndex++)
    {
        auto node = smartArt->get_AllNodes()->idx_get(nodeIndex);

        for (int shapeIndex = 0; shapeIndex < node->get_Shapes()->get_Count(); shapeIndex++)
        {
            auto nodeShape = node->get_Shape(shapeIndex);

            if (nodeShape->get_TextFrame() != nullptr)
            {
                System::Console::WriteLine(nodeShape->get_TextFrame()->get_Text());
            }
        }
    }
}

presentation->Dispose();
```

## **更改 SmartArt 对象的布局类型**

SmartArt 布局决定节点的排列和连接方式。下面的示例创建一个使用 [SmartArtLayoutType](https://reference.aspose.com/slides/zh/cpp/aspose.slides.smartart/smartartlayouttype/) `BasicBlockList` 值的 SmartArt 对象，将其更改为 `BasicProcess` 值，并保存演示文稿。

```cpp
auto presentation = System::MakeObject<Presentation>();

auto smartArt = presentation->get_Slide(0)->get_Shapes()->AddSmartArt(
    10.0f, 10.0f, 400.0f, 300.0f, SmartArtLayoutType::BasicBlockList);

smartArt->set_Layout(SmartArtLayoutType::BasicProcess);

presentation->Save(u"ChangeSmartArtLayout_out.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **检查 SmartArt 节点是否隐藏**

[ISmartArtNode::get_IsHidden](https://reference.aspose.com/slides/zh/cpp/aspose.slides.smartart/smartartnode/get_ishidden/) 指示节点在 SmartArt 数据模型中是否被隐藏。即使所选布局未将其显示为可见的图表元素，隐藏节点仍可能存在于结构中。

下面的示例向使用 [SmartArtLayoutType](https://reference.aspose.com/slides/zh/cpp/aspose.slides.smartart/smartartlayouttype/) `RadialCycle` 值的 SmartArt 对象添加一个节点，并检查该节点的隐藏状态。

```cpp
auto presentation = System::MakeObject<Presentation>();

auto smartArt = presentation->get_Slide(0)->get_Shapes()->AddSmartArt(
    10.0f, 10.0f, 400.0f, 300.0f, SmartArtLayoutType::RadialCycle);

auto node = smartArt->get_AllNodes()->AddNode();
bool isHidden = node->get_IsHidden();

if (isHidden)
{
    System::Console::WriteLine(u"The node is hidden in the SmartArt data model.");
}

presentation->Save(u"CheckSmartArtHiddenProperty_out.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **获取或设置组织结构图布局**

对于使用组织结构图布局的 SmartArt 图表，[ISmartArtNode::get_OrganizationChartLayout](https://reference.aspose.com/slides/zh/cpp/aspose.slides.smartart/smartartnode/get_organizationchartlayout/) 和 [ISmartArtNode::set_OrganizationChartLayout](https://reference.aspose.com/slides/zh/cpp/aspose.slides.smartart/smartartnode/set_organizationchartlayout/) 定义子节点在父节点下的排列方式。例如，您可以根据所选的 [OrganizationChartLayoutType](https://reference.aspose.com/slides/zh/cpp/aspose.slides.smartart/organizationchartlayouttype/) 将子节点挂在左侧、右侧或两侧。

下面的示例创建一个组织结构图，并将第一个节点的布局设置为 [OrganizationChartLayoutType](https://reference.aspose.com/slides/zh/cpp/aspose.slides.smartart/organizationchartlayouttype/) `LeftHanging` 值。

```cpp
auto presentation = System::MakeObject<Presentation>();

auto smartArt = presentation->get_Slide(0)->get_Shapes()->AddSmartArt(
    10.0f, 10.0f, 400.0f, 300.0f, SmartArtLayoutType::OrganizationChart);

auto rootNode = smartArt->get_Node(0);
rootNode->set_OrganizationChartLayout(OrganizationChartLayoutType::LeftHanging);

presentation->Save(u"OrganizationChartLayout_out.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **创建图片组织结构图**

图片组织结构图是一种为包含图像占位符的层次结构图设计的 SmartArt 布局。在将 SmartArt 对象添加到幻灯片时，请使用 [SmartArtLayoutType](https://reference.aspose.com/slides/zh/cpp/aspose.slides.smartart/smartartlayouttype/) `PictureOrganizationChart` 值。

```cpp
auto presentation = System::MakeObject<Presentation>();

auto smartArt = presentation->get_Slide(0)->get_Shapes()->AddSmartArt(
    0.0f, 0.0f, 400.0f, 400.0f, SmartArtLayoutType::PictureOrganizationChart);

presentation->Save(u"PictureOrganizationChart_out.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **FAQ**

**SmartArt 是否支持 RTL 语言的镜像或反转？**

是的。当所选 SmartArt 布局支持反转时，[SmartArt::set_IsReversed](https://reference.aspose.com/slides/zh/cpp/aspose.slides.smartart/smartart/set_isreversed/) 方法可将图表方向从从左到右切换为从右到左，或恢复。

**如何在保持格式的情况下将 SmartArt 复制到同一幻灯片或其他演示文稿？**

您可以使用 [ShapeCollection::AddClone](https://reference.aspose.com/slides/zh/cpp/aspose.slides/shapecollection/addclone/) [克隆 SmartArt 形状](/slides/zh/cpp/shape-manipulations/)，或 [克隆包含 SmartArt 的整个幻灯片](/slides/zh/cpp/clone-slides/)。两种方法都能保留大小、位置和格式。

**如何将 SmartArt 渲染为栅格图像以供预览或网络导出？**

[将幻灯片](/slides/zh/cpp/convert-powerpoint-to-png/)或整个演示文稿渲染为 PNG 或 JPEG。SmartArt 将作为幻灯片的一部分进行渲染。

**如果幻灯片上有多个 SmartArt 对象，如何找到特定的对象？**

在 SmartArt 形状上设置唯一的 [Shape::set_AlternativeText](https://reference.aspose.com/slides/zh/cpp/aspose.slides/shape/set_alternativetext/) 或 [Shape::set_Name](https://reference.aspose.com/slides/zh/cpp/aspose.slides/shape/set_name/) 值，在 [BaseSlide::get_Shapes](https://reference.aspose.com/slides/zh/cpp/aspose.slides/baseslide/get_shapes/) 中搜索该值，然后检查匹配的形状是否为 [ISmartArt](https://reference.aspose.com/slides/zh/cpp/aspose.slides.smartart/ismartart/)。