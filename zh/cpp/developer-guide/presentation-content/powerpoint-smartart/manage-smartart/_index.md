---
title: 管理SmartArt
type: docs
weight: 10
url: /cpp/manage-smartart/
---

## **从SmartArt获取文本**
现在已将TextFrame属性添加到ISmartArtShape接口和SmartArtShape类中。此属性允许您获取SmartArt中的所有文本，如果它不仅包含节点文本。以下示例代码将帮助您从SmartArt节点获取文本。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-GetTextFromSmartArtNode-GetTextFromSmartArtNode.cpp" >}}

## **更改任何SmartArt的布局类型**
要更改SmartArt的布局类型，请按照以下步骤操作：

- 创建一个[Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation)类的实例。
- 通过使用其索引获取幻灯片的引用。
- 添加SmartArt BasicBlockList。
- 将LayoutType更改为BasicProcess。
- 将演示文稿写入PPTX文件。
  在以下示例中，我们在两个形状之间添加了连线。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChangeSmartArtLayout-ChangeSmartArtLayout.cpp" >}}

## **检查SmartArt的隐藏属性**
请注意，方法com.aspose.slides.ISmartArtNode.isHidden() 返回true，如果该节点是数据模型中的隐藏节点。要检查SmartArt任何节点的隐藏属性，请按照以下步骤操作：

- 创建一个[Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation)类的实例。
- 添加SmartArt RadialCycle。
- 在SmartArt上添加节点。
- 检查isHidden属性。
- 将演示文稿写入PPTX文件。

在以下示例中，我们在两个形状之间添加了连线。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CheckSmartArtHiddenProperty-CheckSmartArtHiddenProperty.cpp" >}}

## **获取或设置组织结构图类型**
方法com.aspose.slides.ISmartArtNode.getOrganizationChartLayout()、setOrganizationChartLayout(int)允许获取或设置与当前节点关联的组织结构图类型。要获取或设置组织结构图类型，请按照以下步骤操作：

- 创建一个[Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation)类的实例。
- 在幻灯片上添加SmartArt。
- 获取或设置组织结构图类型。
- 将演示文稿写入PPTX文件。
  在以下示例中，我们在两个形状之间添加了连线。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-OrganizeChartLayoutType-OrganizeChartLayoutType.cpp" >}}

## **获取或设置SmartArt的状态**
一些SmartArt图形不支持反转，例如；垂直项目符号列表、垂直过程、递减过程、漏斗、齿轮、平衡、圆形关系、六边形簇、反向列表、堆叠的韵。为了更改SmartArt的方向，请按照以下步骤操作：

- 创建一个[Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation)类的实例。
- 在幻灯片上添加SmartArt。
- 获取或设置SmartArt图形的状态。
- 将演示文稿写入PPTX文件。
  在以下示例中，我们在两个形状之间添加了连线。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChangeSmartArtLayout-ChangeSmartArtLayout.cpp" >}}


## **创建图片组织结构图**
Aspose.Slides for C++提供了一个简单的API，以便以简单的方式创建和图片组织结构图。要在幻灯片上创建图表：

1. 创建一个[Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation)类的实例。
2. 通过索引获取幻灯片的引用。
3. 添加一个带有默认数据和所需类型（ChartType.PictureOrganizationChart）的图表。
4. 将修改后的演示文稿写入PPTX文件。

以下代码用于创建图表。

``` cpp
auto pres = System::MakeObject<Presentation>(u"test.pptx");
auto smartArt = pres->get_Slides()->idx_get(0)->get_Shapes()->AddSmartArt(0.0f, 0.0f, 400.0f, 400.0f, SmartArtLayoutType::PictureOrganizationChart);
pres->Save(u"OrganizationChart.pptx", SaveFormat::Pptx);
```