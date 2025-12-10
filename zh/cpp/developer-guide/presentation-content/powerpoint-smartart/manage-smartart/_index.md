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
description: "学习使用 Aspose.Slides for C++ 构建和编辑 PowerPoint SmartArt，提供清晰的代码示例，加快幻灯片设计和自动化。"
---

## **从 SmartArt 对象获取文本**
现在已在 ISmartArtShape 接口和 SmartArtShape 类中分别添加了 TextFrame 属性。该属性允许您获取 SmartArt 中的所有文本，即使它不仅包含节点文本。下面的示例代码演示如何从 SmartArt 节点获取文本。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-GetTextFromSmartArtNode-GetTextFromSmartArtNode.cpp" >}}

## **更改 SmartArt 对象的布局类型**
若要更改 SmartArt 的布局类型，请按以下步骤操作：

- 创建一个 [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) 实例。
- 使用索引获取幻灯片的引用。
- 添加 SmartArt BasicBlockList。
- 将 LayoutType 更改为 BasicProcess。
- 将演示文稿保存为 PPTX 文件。
  在下面的示例中，我们在两个形状之间添加了连接线。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChangeSmartArtLayout-ChangeSmartArtLayout.cpp" >}}

## **检查 SmartArt 对象的 Hidden 属性**
请注意，Method com.aspose.slides.ISmartArtNode.isHidden() 在该节点在数据模型中为隐藏节点时返回 true。若要检查 SmartArt 任意节点的隐藏属性，请按以下步骤操作：

- 创建一个 [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) 实例。
- 添加 SmartArt RadialCycle。
- 在 SmartArt 上添加节点。
- 检查 isHidden 属性。
- 将演示文稿保存为 PPTX 文件。

在下面的示例中，我们在两个形状之间添加了连接线。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CheckSmartArtHiddenProperty-CheckSmartArtHiddenProperty.cpp" >}}

## **获取或设置组织结构图类型**
Methods com.aspose.slides.ISmartArtNode.getOrganizationChartLayout(), setOrganizationChartLayout(int) 允许获取或设置与当前节点关联的组织结构图类型。若要获取或设置组织结构图类型，请按以下步骤操作：

- 创建一个 [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) 实例。
- 在幻灯片上添加 SmartArt。
- 获取或设置组织结构图类型。
- 将演示文稿保存为 PPTX 文件。
  在下面的示例中，我们在两个形状之间添加了连接线。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-OrganizeChartLayoutType-OrganizeChartLayoutType.cpp" >}}

## **获取或设置 SmartArt 的状态**
某些 SmartArt 图表不支持翻转，例如：Vertical bullet list、Vertical Process、Descending Process、Funnel、Gear、Balance、Circle Relationship、Hexagon Cluster、Reverse List、Stacked Venn。若要更改 SmartArt 的方向，请按以下步骤操作：

- 创建一个 [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) 实例。
- 在幻灯片上添加 SmartArt。
- 获取或设置 SmartArt 图表的状态。
- 将演示文稿保存为 PPTX 文件。
  在下面的示例中，我们在两个形状之间添加了连接线。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChangeSmartArtLayout-ChangeSmartArtLayout.cpp" >}}

## **创建图片组织结构图**
Aspose.Slides for C++ 提供了简便的 API，用于以轻松的方式创建 PictureOrganization 图表。在幻灯片上创建图表的步骤：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) 实例。
2. 通过索引获取幻灯片的引用。
3. 添加默认数据并指定所需类型（ChartType.PictureOrganizationChart）的图表。
4. 将修改后的演示文稿写入 PPTX 文件。

以下代码用于创建图表。
``` cpp
auto pres = System::MakeObject<Presentation>(u"test.pptx");
auto smartArt = pres->get_Slides()->idx_get(0)->get_Shapes()->AddSmartArt(0.0f, 0.0f, 400.0f, 400.0f, SmartArtLayoutType::PictureOrganizationChart);
pres->Save(u"OrganizationChart.pptx", SaveFormat::Pptx);
```


## **常见问题**

**SmartArt 是否支持 RTL 语言的镜像/翻转？**

是的。`set_IsReversed` 方法会在所选 SmartArt 类型支持翻转时切换图表方向（LTR/RTL）。

**如何在保持格式的情况下将 SmartArt 复制到同一幻灯片或其他演示文稿？**

您可以通过形状集合的 [ShapeCollection::AddClone](https://reference.aspose.com/slides/cpp/aspose.slides/shapecollection/addclone/) 克隆 SmartArt 形状，或克隆包含该形状的整个幻灯片（[clone the entire slide](/slides/zh/cpp/clone-slides/)）。两种方式均会保留大小、位置和样式。

**如何将 SmartArt 渲染为栅格图像以供预览或网页导出？**

通过 API 将幻灯片（或整个演示文稿）转换为 PNG/JPEG（[Render the slide](/slides/zh/cpp/convert-powerpoint-to-png/)），SmartArt 会作为幻灯片的一部分被绘制。

**如果幻灯片中有多个 SmartArt，如何以编程方式选中特定的一个？**

常用做法是为 SmartArt 设置[替代文本](https://reference.aspose.com/slides/cpp/aspose.slides/shape/set_alternativetext/)（Alt Text）或[名称](https://reference.aspose.com/slides/cpp/aspose.slides/shape/set_name/)，然后在[幻灯片形状](https://reference.aspose.com/slides/cpp/aspose.slides/baseslide/get_shapes/)中按该属性搜索形状，再检查类型以确认是 [SmartArt](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/smartart/)。文档中描述了查找和操作形状的典型技术。