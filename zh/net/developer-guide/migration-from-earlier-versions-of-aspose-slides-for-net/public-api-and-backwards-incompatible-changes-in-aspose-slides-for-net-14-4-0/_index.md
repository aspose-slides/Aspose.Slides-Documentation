---
title: Aspose.Slides for .NET 14.4.0 中的公共 API 及向后不兼容的更改
linktitle: Aspose.Slides for .NET 14.4.0
type: docs
weight: 60
url: /zh/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-4-0/
keywords:
- 迁移
- 旧版代码
- 现代代码
- 旧版方法
- 现代方法
- PowerPoint
- OpenDocument
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "回顾 Aspose.Slides for .NET 的公共 API 更新和破坏性更改，帮助您平稳迁移 PowerPoint PPT、PPTX 和 ODP 演示文稿解决方案。"
---

## **公共 API 和向后不兼容的更改**
### **添加的接口、类、方法和属性**
#### **已添加 Aspose.Slides.ILayoutSlide.HasDependingSlides 属性**
属性 Aspose.Slides.ILayoutSlide.HasDependingSlides 返回 true，如果存在至少一个依赖此版式幻灯片的幻灯片。例如：

``` csharp

 ILayoutSlide layout = ...;

if (!layout.HasDependingSlides)

    layout.Remove();

``` 
#### **Aspose.Slides.ILayoutSlide.Remove() 方法**
方法 Aspose.Slides.ILayoutSlide.Remove() 允许您使用最少的代码从演示文稿中删除版式。例如：

``` csharp

 ILayoutSlide layout = ...;

if (!layout.HasDependingSlides)

    layout.Remove();

``` 
#### **Aspose.Slides.ILayoutSlideCollection.Remove(ILayoutSlide) 方法**
方法 Aspose.Slides.ILayoutSlideCollection.Remove(ILayoutSlide) 允许您从集合中删除版式。代码示例：

``` csharp

 ILayoutSlide layout = ...;

if (!layout.HasDependingSlides)

    presentation.LayoutSlides.Remove(layout);

``` 

or

``` csharp

 IMasterSlide masterSlide = ...;

ILayoutSlide layout = ...;

if (!layout.HasDependingSlides)

    masterSlide.LayoutSlides.Remove(layout);

``` 
#### **Aspose.Slides.ILayoutSlideCollection.RemoveUnused()**
方法 Aspose.Slides.ILayoutSlideCollection.RemoveUnused() 允许您删除未使用的版式幻灯片（其 HasDependingSlides 为 false 的版式幻灯片）。代码示例：

``` csharp

 presentation.LayoutSlides.RemoveUnused();

``` 

or

``` csharp

 IMasterSlide masterSlide = ...;

masterSlide.LayoutSlides.RemoveUnused();

``` 
#### **Aspose.Slides.IMasterSlide.HasDependingSlides 属性**
属性 Aspose.Slides.IMasterSlide.HasDependingSlides 返回 true，如果存在至少一个依赖此母版幻灯片的幻灯片。例如：

``` csharp

 IMasterSlide masterSlide = ...;

if (!masterSlide.HasDependingSlides)

    presentation.Masters.Remove(masterSlide);

``` 
#### **Aspose.Slides.ISlide.Remove() 方法**
方法 Aspose.Slides.ISlide.Remove() 允许您使用最少的代码从演示文稿中删除幻灯片。例如：

``` csharp

 ISlide slide = ...;

slide.Remove();

``` 
#### **Aspose.Slides.SmartArt.ISmartArtNode.BulletFillFormat**
属性 Aspose.Slides.SmartArt.ISmartArtNode.BulletFillFormat 返回 IFillFormat，用于 SmartArt 节点的项目符号（如果布局提供项目符号）。它可用于设置项目符号图像。

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-SmartArts-BulletFillFormat-BulletFillFormat.cs" >}}
#### **Aspose.Slides.SmartArt.ISmartArtNode.Level 属性**
属性 Aspose.Slides.SmartArt.ISmartArtNode.Level 返回 SmartArt 节点的嵌套层级。

``` csharp

 ISmartArtNode node = diagram.AllNodes[0];

if(node.Level == 1)

    node.TextFrame.Text = "First level";

``` 
#### **Aspose.Slides.SmartArt.ISmartArtNode.Position 属性**
属性 Aspose.Slides.SmartArt.ISmartArtNode.Position 返回节点在同级节点中的位置。

``` csharp

 ISmartArtNode node = diagram.AllNodes[0];

if (node.ChildNodes.Count > 3)

    node.ChildNodes[0].Position++;

``` 
#### **已添加 Aspose.Slides.SmartArt.ISmartArtNode.Remove() 方法**
方法 Aspose.Slides.SmartArt.ISmartArtNode.Remove() 允许从图表中删除节点。

``` csharp

 ISmartArt node = diagram.AllNodes[0];

node.Remove();

``` 
#### **IGlobalLayoutSlideCollection 接口和 GlobalLayoutSlideCollection 类**
已在 Aspose.Slides 命名空间中添加 IGlobalLayoutSlideCollection 接口和 GlobalLayoutSlideCollection 类。

GlobalLayoutSlideCollection 类实现 IGlobalLayoutSlideCollection 接口。

IGlobalLayoutSlideCollection 接口表示演示文稿中所有版式幻灯片的集合。IPresentation.LayoutSlides 属性的类型为 IGlobalLayoutSlideCollection。IGlobalLayoutSlideCollection 扩展了 ILayoutSlideCollection 接口，提供在合并各母版版式集合的上下文中添加和克隆版式的方法：

- ILayoutSlide AddClone(ILayoutSlide sourceLayout); – 可用于向演示文稿添加指定版式的副本。此方法保留源格式（在不同演示文稿之间克隆版式时，版式的母版也可以被克隆。内部注册表用于跟踪自动克隆的母版，以防止同一母版幻灯片被多次克隆。）
- ILayoutSlide AddClone(ILayoutSlide sourceLayout, IMasterSlide destMaster); – 用于向演示文稿添加指定版式的副本。新版式将链接到目标演示文稿中定义的母版。此选项相当于在 Microsoft PowerPoint 中使用 **使用目标主题** 进行复制或粘贴。
- ILayoutSlide Add(IMasterSlide master, SlideLayoutType layoutType, string layoutName); – 用于向演示文稿添加新的版式幻灯片。支持的版式类型：Title、TitleOnly、Blank、TitleAndObject、VerticalText、VerticalTitleAndText、TwoObjects、SectionHeader、TwoTextAndTwoObjects、TitleObjectAndCaption、PictureAndCaption、Custom。版式名称可以自动生成。类型为 SlideLayoutType.Custom 的添加版式不包含占位符和形状。此方法的类似形式是通过 IMasterSlide.LayoutSlides 属性访问的 IMasterLayoutSlideCollection.Add(SlideLayoutType, string) 方法。

#### **IMasterLayoutSlideCollection 接口和 MasterLayoutSlideCollection 类**
IMasterLayoutSlideCollection 接口和 MasterLayoutSlideCollection 类已添加到 Aspose.Slides 命名空间。MasterLayoutSlideCollection 类实现 IMasterLayoutSlideCollection 接口。

IMasterLayoutSlideCollection 接口表示定义的母版幻灯片的所有版式幻灯片集合。它在 ILayoutSlideCollection 接口基础上扩展了在各母版版式集合上下文中添加、插入、删除或克隆版式的方法：

``` csharp

 // Method signature:

ILayoutSlide AddClone(ILayoutSlide sourceLayout);

// Code example that attaches copy of the sourceLayout to the destMasterSlide:

IMasterSlide destMasterSlide = ...;

destMasterSlide.LayoutSlides.AddClone(sourceLayout);

``` 

该方法可用于将指定版式的副本添加到集合末尾。新版式将与该版式集合所属的父母版幻灯片关联。因此，这相当于在 PowerPoint 中使用 **使用目标主题** 进行复制或粘贴。该方法的类似形式是通过 IPresentation.LayoutSlides 属性访问的 IGlobalLayoutSlideCollection.AddClone(ILayoutSlide, IMasterSlide) 方法。

- ILayoutSlide InsertClone(int index, ILayoutSlide sourceLayout); – 用于在集合的指定位置插入指定版式的副本。新版式将与该版式集合所属的父母版幻灯片关联，等同于在 PowerPoint 中使用 **使用目标主题** 进行复制和粘贴。
- ILayoutSlide Add(SlideLayoutType layoutType, string layoutName);
- ILayoutSlide Insert(int index, SlideLayoutType layoutType, string layoutName); – 用于添加或插入新的版式幻灯片。支持的版式类型同上。版式名称可以自动生成。类型为 SlideLayoutType.Custom 的添加版式不包含占位符和形状。此方法的类似形式是通过 IPresentation.LayoutSlides 属性访问的 IGlobalLayoutSlideCollection.Add(IMasterSlide, SlideLayoutType, string) 方法。
- void RemoveAt(int index); – 用于移除集合中指定索引处的版式。
- void Reorder(int index, ILayoutSlide layoutSlide); – 用于将版式幻灯片从集合中移动到指定位置。

### **已更改的方法和属性**
#### **Aspose.Slides.ISlideCollection.AddClone(ISlide, IMasterSlide) 方法的签名**
ISlideCollection 方法的签名：
ISlide AddClone(ISlide sourceSlide, IMasterSlide destMaster);

已过时，并替换为以下签名：

ISlide AddClone(ISlide sourceSlide, IMasterSlide destMaster, bool allowCloneMissingLayout)

allowCloneMissingLayout 参数指定在 destMaster 中没有适当版式时该如何处理。适当的版式是与源幻灯片版式类型或名称相同的版式。如果指定的母版中没有适当的版式，则会克隆源幻灯片的版式（当 allowCloneMissingLayout 为 true 时），否则抛出 PptxEditException（当 allowCloneMissingLayout 为 false 时）。

对过时方法的调用，例如：

AddClone(sourceSlide, destMaster);

等同于 allowCloneMissingLayout 为 false（即如果没有适当版式会抛出 PptxEditException）。使用新签名的等效调用如下：

AddClone(sourceSlide, destMaster, false);

如果希望在缺少版式时自动克隆而不是抛出异常，请将 allowCloneMissingLayout 参数设为 true。

同样，以下 ISlideCollection 方法也已过时：

ISlide InsertClone(int index, ISlide sourceSlide, IMasterSlide destMaster);

已替换为签名：

ISlide InsertClone(int index, ISlide sourceSlide, IMasterSlide destMaster, bool allowCloneMissingLayout);
#### **Aspose.Slides.IMasterSlide.LayoutSlides 属性的类型**
Aspose.Slides.IMasterSlide.LayoutSlides 属性的类型已从 ILayoutSlideCollection 更改为新的 IMasterLayoutSlideCollection 接口。IMasterLayoutSlideCollection 是 ILayoutSlideCollection 的子接口，现有代码无需适配。
#### **Aspose.Slides.IPresentation.LayoutSlides 属性的类型已更改**
Aspose.Slides.IPresentation.LayoutSlides 属性的类型已从 ILayoutSlideCollection 更改为新的 IGlobalLayoutSlideCollection 接口。IGlobalLayoutSlideCollection 是 ILayoutSlideCollection 的子接口，现有代码无需适配。