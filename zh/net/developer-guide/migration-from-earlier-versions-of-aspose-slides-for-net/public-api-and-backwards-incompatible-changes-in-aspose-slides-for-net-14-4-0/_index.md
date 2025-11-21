---
title: Aspose.Slides for .NET 14.4.0 的公共 API 和向后不兼容的更改
linktitle: Aspose.Slides for .NET 14.4.0
type: docs
weight: 60
url: /zh/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-4-0/
keywords:
- 迁移
- 旧版代码
- 现代代码
- 传统方法
- 现代方法
- PowerPoint
- OpenDocument
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "回顾 Aspose.Slides for .NET 中的公共 API 更新和破坏性更改，以顺利迁移您的 PowerPoint PPT、PPTX 和 ODP 演示文稿解决方案。"
---

## **公共 API 与向后不兼容的更改**
### **新增的接口、类、方法和属性**
#### **已添加 Aspose.Slides.ILayoutSlide.HasDependingSlides 属性**
Aspose.Slides.ILayoutSlide.HasDependingSlides 属性在存在至少一个依赖于此布局幻灯片的幻灯片时返回 true。例如：

``` csharp

 ILayoutSlide layout = ...;

if (!layout.HasDependingSlides)

    layout.Remove();

``` 
#### **Aspose.Slides.ILayoutSlide.Remove() 方法**
Aspose.Slides.ILayoutSlide.Remove() 方法允许您以最少的代码从演示文稿中删除布局。例如：

``` csharp

 ILayoutSlide layout = ...;

if (!layout.HasDependingSlides)

    layout.Remove();

``` 
#### **Aspose.Slides.ILayoutSlideCollection.Remove(ILayoutSlide) 方法**
Aspose.Slides.ILayoutSlideCollection.Remove(ILayoutSlide) 方法允许您从集合中移除布局。代码示例：

``` csharp

 ILayoutSlide layout = ...;

if (!layout.HasDependingSlides)

    presentation.LayoutSlides.Remove(layout);

``` 

或

``` csharp

 IMasterSlide masterSlide = ...;

ILayoutSlide layout = ...;

if (!layout.HasDependingSlides)

    masterSlide.LayoutSlides.Remove(layout);

``` 
#### **Aspose.Slides.ILayoutSlideCollection.RemoveUnused()**
Aspose.Slides.ILayoutSlideCollection.RemoveUnused() 方法允许您移除未使用的布局幻灯片（HasDependingSlides 为 false 的布局幻灯片）。代码示例：

``` csharp

 presentation.LayoutSlides.RemoveUnused();

``` 

或

``` csharp

 IMasterSlide masterSlide = ...;

masterSlide.LayoutSlides.RemoveUnused();

``` 
#### **Aspose.Slides.IMasterSlide.HasDependingSlides 属性**
Aspose.Slides.IMasterSlide.HasDependingSlides 属性在存在至少一个依赖于此母版幻灯片的幻灯片时返回 true。例如：

``` csharp

 IMasterSlide masterSlide = ...;

if (!masterSlide.HasDependingSlides)

    presentation.Masters.Remove(masterSlide);

``` 
#### **Aspose.Slides.ISlide.Remove() 方法**
Aspose.Slides.ISlide.Remove() 方法允许您以最少的代码从演示文稿中移除幻灯片。例如：

``` csharp

 ISlide slide = ...;

slide.Remove();

``` 
#### **Aspose.Slides.SmartArt.ISmartArtNode.BulletFillFormat**
Aspose.Slides.SmartArt.ISmartArtNode.BulletFillFormat 属性在布局提供项目符号时返回用于 SmartArt 节点项目符号的 IFillFormat，可用于设置项目符号图像。

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-SmartArts-BulletFillFormat-BulletFillFormat.cs" >}}
#### **Aspose.Slides.SmartArt.ISmartArtNode.Level 属性**
Aspose.Slides.SmartArt.ISmartArtNode.Level 属性返回 SmartArt 节点的嵌套级别。

``` csharp

 ISmartArtNode node = diagram.AllNodes[0];

if(node.Level == 1)

    node.TextFrame.Text = "First level";

``` 
#### **Aspose.Slides.SmartArt.ISmartArtNode.Position 属性**
Aspose.Slides.SmartArt.ISmartArtNode.Position 属性返回节点在其同级节点中的位置。

``` csharp

 ISmartArtNode node = diagram.AllNodes[0];

if (node.ChildNodes.Count > 3)

    node.ChildNodes[0].Position++;

``` 
#### **已添加 Aspose.Slides.SmartArt.ISmartArtNode.Remove() 方法**
Aspose.Slides.SmartArt.ISmartArtNode.Remove() 方法允许从图表中删除节点。

``` csharp

 ISmartArt node = diagram.AllNodes[0];

node.Remove();

``` 
#### **IGlobalLayoutSlideCollection 接口和 GlobalLayoutSlideCollection 类**
IGlobalLayoutSlideCollection 接口和 GlobalLayoutSlideCollection 类已添加到 Aspose.Slides 命名空间。

GlobalLayoutSlideCollection 类实现了 IGlobalLayoutSlideCollection 接口。

IGlobalLayoutSlideCollection 接口表示演示文稿中所有布局幻灯片的集合。IPresentation.LayoutSlides 属性的类型为 IGlobalLayoutSlideCollection。IGlobalLayoutSlideCollection 在 ILayoutSlideCollection 基础上扩展了用于在合并各母版布局幻灯片集合时添加和克隆布局幻灯片的方法：

- ILayoutSlide AddClone(ILayoutSlide sourceLayout); – 可用于将指定布局幻灯片的副本添加到演示文稿。此方法保留源格式（在不同演示文稿之间克隆布局时，布局的母版也会被克隆。内部注册表用于跟踪自动克隆的母版，以防止对同一母版幻灯片创建多个克隆。）
- ILayoutSlide AddClone(ILayoutSlide sourceLayout, IMasterSlide destMaster); – 用于将指定布局幻灯片的副本添加到演示文稿。新布局将链接到目标演示文稿中指定的母版。此选项类似于在 Microsoft PowerPoint 中使用 **Use Destination Theme** 进行复制或粘贴。
- ILayoutSlide Add(IMasterSlide master, SlideLayoutType layoutType, string layoutName); – 用于向演示文稿添加新的布局幻灯片。支持的布局类型：Title、TitleOnly、Blank、TitleAndObject、VerticalText、VerticalTitleAndText、TwoObjects、SectionHeader、TwoTextAndTwoObjects、TitleObjectAndCaption、PictureAndCaption、Custom。布局名称可以自动生成。类型为 SlideLayoutType.Custom 的布局不包含占位符和形状。该方法的类似实现是通过 IMasterSlide.LayoutSlides 属性访问的 IMasterLayoutSlideCollection.Add(SlideLayoutType, string) 方法。
#### **接口 IMasterLayoutSlideCollection 与类 MasterLayoutSlideCollection**
IMasterLayoutSlideCollection 接口和 MasterLayoutSlideCollection 类已添加到 Aspose.Slides 命名空间。MasterLayoutSlideCollection 类实现了 IMasterLayoutSlideCollection 接口。

IMasterLayoutSlideCollection 接口表示已定义母版幻灯片的所有布局幻灯片集合。它在 ILayoutSlideCollection 基础上扩展了在母版布局幻灯片各自集合上下文中添加、插入、移除或克隆布局幻灯片的方法：

``` csharp

 // 方法签名:

ILayoutSlide AddClone(ILayoutSlide sourceLayout);

// 将 sourceLayout 的副本附加到 destMasterSlide 的代码示例:

IMasterSlide destMasterSlide = ...;

destMasterSlide.LayoutSlides.AddClone(sourceLayout);

``` 

该方法可用于将指定布局幻灯片的副本添加到集合末尾。新布局将与此布局幻灯片集合的父母版幻灯片关联。因此它相当于在 PowerPoint 中使用 **Use Destination Theme** 进行复制或粘贴。该方法的类似实现是通过 IPresentation.LayoutSlides 属性访问的 IGlobalLayoutSlideCollection.AddClone(ILayoutSlide, IMasterSlide) 方法。

- ILayoutSlide InsertClone(int index, ILayoutSlide sourceLayout); – 用于将指定布局幻灯片的副本插入到集合的指定位置。新布局将链接到此布局幻灯片集合的父母版幻灯片。该操作类似于在 PowerPoint 中使用 **Use Destination Theme** 进行复制和粘贴。
- ILayoutSlide Add(SlideLayoutType layoutType, string layoutName);
- ILayoutSlide Insert(int index, SlideLayoutType layoutType, string layoutName); – 用于添加或插入新的布局幻灯片。支持的布局类型同上。布局名称可以自动生成。类型为 SlideLayoutType.Custom 的布局不包含占位符和形状。该方法的类似实现是通过 IPresentation.LayoutSlides 属性访问的 IGlobalLayoutSlideCollection.Add(IMasterSlide, SlideLayoutType, string) 方法。
- void RemoveAt(int index); – 用于移除集合中指定索引处的布局。
- void Reorder(int index, ILayoutSlide layoutSlide); – 用于将布局幻灯片从集合移动到指定位置。
### **已更改的方法和属性**
#### **Aspose.Slides.ISlideCollection.AddClone(ISlide, IMasterSlide) 方法的签名**
原签名：

ISlide AddClone(ISlide sourceSlide, IMasterSlide destMaster);

已过时并替换为：

ISSlide AddClone(ISlide sourceSlide, IMasterSlide destMaster, bool allowCloneMissingLayout)

allowCloneMissingLayout 参数指定当目标母版中没有适当的布局时的处理方式。适当的布局是与源幻灯片布局类型或名称相同的布局。如果指定的母版中没有适当的布局，则会克隆源幻灯片的布局（当 allowCloneMissingLayout 为 true 时），否则抛出 PptxEditException（当 allowCloneMissingLayout 为 false 时）。

调用已过时的方法如：

AddClone(sourceSlide, destMaster);

等同于 allowCloneMissingLayout 为 false（即若无适当布局将抛出 PptxEditException）。使用新签名的等价调用如下：

AddClone(sourceSlide, destMaster, false);

如果希望在缺少布局时自动克隆而不是抛出异常，请将 allowCloneMissingLayout 参数设为 true。

同样适用于已过时的 ISlideCollection 方法：

ISlide InsertClone(int index, ISlide sourceSlide, IMasterSlide destMaster);

已替换为：

ISlide InsertClone(int index, ISlide sourceSlide, IMasterSlide destMaster, bool allowCloneMissingLayout);
#### **Aspose.Slides.IMasterSlide.LayoutSlides 属性的类型**
Aspose.Slides.IMasterSlide.LayoutSlides 属性的类型已从 ILayoutSlideCollection 更改为新的 IMasterLayoutSlideCollection 接口。IMasterLayoutSlideCollection 是 ILayoutSlideCollection 的子接口，现有代码无需修改。
#### **Aspose.Slides.IPresentation.LayoutSlides 属性的类型已更改**
Aspose.Slides.IPresentation.LayoutSlides 属性的类型已从 ILayoutSlideCollection 更改为新的 IGlobalLayoutSlideCollection 接口。IGlobalLayoutSlideCollection 是 ILayoutSlideCollection 的子接口，现有代码无需修改。