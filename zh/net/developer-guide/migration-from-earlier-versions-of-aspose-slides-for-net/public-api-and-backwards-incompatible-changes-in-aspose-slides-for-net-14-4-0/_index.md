---
title: Aspose.Slides for .NET 14.4.0 的公共 API 和不兼容的更改
type: docs
weight: 60
url: /net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-4-0/
---

## **公共 API 和不兼容的更改**
### **新增接口、类、方法和属性**
#### **已添加 Aspose.Slides.ILayoutSlide.HasDependingSlides 属性**
属性 Aspose.Slides.ILayoutSlide.HasDependingSlides 如果存在至少一个依赖于此布局幻灯片的幻灯片，则返回 true。例如：

``` csharp

 ILayoutSlide layout = ...;

if (!layout.HasDependingSlides)

    layout.Remove();

``` 
#### **Aspose.Slides.ILayoutSlide.Remove() 方法**
方法 Aspose.Slides.ILayoutSlide.Remove() 允许您以最少的代码从演示文稿中删除布局。例如：

``` csharp

 ILayoutSlide layout = ...;

if (!layout.HasDependingSlides)

    layout.Remove();

``` 
#### **Aspose.Slides.ILayoutSlideCollection.Remove(ILayoutSlide) 方法**
方法 Aspose.Slides.ILayoutSlideCollection.Remove(ILayoutSlide) 允许您从集合中删除布局。代码示例：

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
方法 Aspose.Slides.ILayoutSlideCollection.RemoveUnused() 允许您删除未使用的布局幻灯片（HasDependingSlides 为 false 的布局幻灯片）。代码示例：

``` csharp

 presentation.LayoutSlides.RemoveUnused();

``` 

或

``` csharp

 IMasterSlide masterSlide = ...;

masterSlide.LayoutSlides.RemoveUnused();

``` 
#### **Aspose.Slides.IMasterSlide.HasDependingSlides 属性**
属性 Aspose.Slides.IMasterSlide.HasDependingSlides 如果存在至少一个依赖于此母版幻灯片的幻灯片，则返回 true。例如：

``` csharp

 IMasterSlide masterSlide = ...;

if (!masterSlide.HasDependingSlides)

    presentation.Masters.Remove(masterSlide);

``` 
#### **Aspose.Slides.ISlide.Remove() 方法**
方法 Aspose.Slides.ISlide.Remove() 允许您以最少的代码从演示文稿中删除一个幻灯片。例如：

``` csharp

 ISlide slide = ...;

slide.Remove();

``` 
#### **Aspose.Slides.SmartArt.ISmartArtNode.BulletFillFormat**
属性 Aspose.Slides.SmartArt.ISmartArtNode.BulletFillFormat 如果布局提供子弹，则返回 SmartArt 节点子弹的 IFillFormat。可用于设置子弹图像。

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-SmartArts-BulletFillFormat-BulletFillFormat.cs" >}}
#### **Aspose.Slides.SmartArt.ISmartArtNode.Level 属性**
属性 Aspose.Slides.SmartArt.ISmartArtNode.Level 返回 SmartArt 节点的嵌套级别。

``` csharp

 ISmartArtNode node = diagram.AllNodes[0];

if(node.Level == 1)

    node.TextFrame.Text = "第一层级";

``` 
#### **Aspose.Slides.SmartArt.ISmartArtNode.Position 属性**
属性 Aspose.Slides.SmartArt.ISmartArtNode.Position 返回节点在其兄弟节点中的位置。

``` csharp

 ISmartArtNode node = diagram.AllNodes[0];

if (node.ChildNodes.Count > 3)

    node.ChildNodes[0].Position++;

``` 
#### **已添加 Aspose.Slides.SmartArt.ISmartArtNode.Remove() 方法**
Aspose.Slides.SmartArt.ISmartArtNode.Remove() 方法允许从图表中移除一个节点。

``` csharp

 ISmartArt node = diagram.AllNodes[0];

node.Remove();

``` 
#### **IGlobalLayoutSlideCollection 接口和 GlobalLayoutSlideCollection 类**
IGlobalLayoutSlideCollection 接口和 GlobalLayoutSlideCollection 类已添加到 Aspose.Slides 命名空间。

GlobalLayoutSlideCollection 类实现了 IGlobalLayoutSlideCollection 接口。

IGlobalLayoutSlideCollection 接口表示演示文稿中所有布局幻灯片的集合。IPresentation.LayoutSlides 属性为 IGlobalLayoutSlideCollection 类型。IGlobalLayoutSlideCollection 扩展了 ILayoutSlideCollection 接口，增加了在合并各个母版布局幻灯片集合时添加和克隆布局幻灯片的方法：

- ILayoutSlide AddClone(ILayoutSlide sourceLayout); – 可用于将指定布局幻灯片的副本添加到演示文稿中。此方法保持源格式（在不同演示文稿之间克隆布局时，幻灯片的母版也可以被克隆。内部注册表用于自动跟踪克隆的母版，以防止创建多个相同母版幻灯片的克隆。）
- ILayoutSlide AddClone(ILayoutSlide sourceLayout, IMasterSlide destMaster); – 用于将指定布局幻灯片的副本添加到演示文稿中。新的布局将链接到目标演示文稿中定义的母版。这个选项与 Microsoft PowerPoint 中的 **使用目标主题** 选项类似。
- ILayoutSlide Add(IMasterSlide master, SlideLayoutType layoutType, string layoutName); – 用于向演示文稿添加一个新的布局幻灯片。支持的布局类型：标题、仅标题、空白、标题和对象、垂直文本、垂直标题和文本、两个对象、章节标题、两个文本和两个对象、标题对象和说明、图片和说明、自定义。布局名称可以自动生成。添加的 SlideLayoutType.Custom 类型的布局不包含占位符和形状。此方法的类似方法是通过 IMasterSlide.LayoutSlides 属性访问的 IMasterLayoutSlideCollection.Add(SlideLayoutType, string) 方法。
#### **IMasterLayoutSlideCollection 接口和 MasterLayoutSlideCollection 类**
IMasterLayoutSlideCollection 接口和 MasterLayoutSlideCollection 类已添加到 Aspose.Slides 命名空间。MasterLayoutSlideCollection 类实现了 IMasterLayoutSlideCollection 接口。

IMasterLayoutSlideCollection 接口表示定义母版幻灯片的所有布局幻灯片的集合。它扩展了 ILayoutSlideCollection 接口，并增加了在单个母版布局幻灯片集合的上下文中添加、插入、删除或克隆布局幻灯片的方法：

``` csharp

 // 方法签名：

ILayoutSlide AddClone(ILayoutSlide sourceLayout);

// 将源布局的副本附加到目标母版幻灯片的代码示例：

IMasterSlide destMasterSlide = ...;

destMasterSlide.LayoutSlides.AddClone(sourceLayout);

``` 

该方法可用于将指定布局幻灯片的副本添加到集合的末尾。新的布局将与该布局幻灯片集合的父版关联。因此，这与 PowerPoint 中的 **使用目标主题** 选项的复制或粘贴类似。该方法的类似方法是通过 IPresentation.LayoutSlides 属性访问的 IGlobalLayoutSlideCollection.AddClone(ILayoutSlide, IMasterSlide) 方法。

- ILayoutSlide InsertClone(int index, ILayoutSlide sourceLayout); – 用于将指定布局幻灯片的副本插入到集合的指定位置。新布局将与该布局幻灯片集合的父版关联。因此，这与 PowerPoint 中的 **使用目标主题** 选项的复制和粘贴类似。
- ILayoutSlide Add(SlideLayoutType layoutType, string layoutName);
- ILayoutSlide Insert(int index, SlideLayoutType layoutType, string layoutName); – 用于添加或插入一个新的布局幻灯片。支持的布局类型：标题、仅标题、空白、标题和对象、垂直文本、垂直标题和文本、两个对象、章节标题、两个文本和两个对象、标题对象和说明、图片和说明、自定义。布局名称可以自动生成。添加的 SlideLayoutType.Custom 类型的布局不包含占位符和形状。此方法的类似方法是通过 IPresentation.LayoutSlides 属性访问的 IGlobalLayoutSlideCollection.Add(IMasterSlide, SlideLayoutType, string) 方法。
- void RemoveAt(int index); – 用于删除集合指定索引处的布局。
- void Reorder(int index, ILayoutSlide layoutSlide); – 用于将布局幻灯片从集合移动到指定位置。
### **更改的方法和属性**
#### **Aspose.Slides.ISlideCollection.AddClone(ISlide, IMasterSlide) 方法的签名**
ISlideCollection 方法的签名：
ISlide AddClone(ISlide sourceSlide, IMasterSlide destMaster);

现在已经过时并被签名替代

ISlide AddClone(ISlide sourceSlide, IMasterSlide destMaster, bool allowCloneMissingLayout)

allowCloneMissingLayout 参数指定如果在目标母版中没有适当的布局时该如何处理。适当的布局是与源幻灯片的布局相同类型或名称的布局。如果在指定的母版中没有适当的布局，则源幻灯片的布局将被克隆（如果 allowCloneMissingLayout 为 true）或会抛出 PptxEditException（如果 allowCloneMissingLayout 为 false）。

像

AddClone(sourceSlide, destMaster);

这样的过时方法假定 allowCloneMissingLayout 等于 false（即如果没有适当布局将抛出 PptxEditException）。功能上相同的调用使用新签名如下：
AddClone(sourceSlide, destMaster, false);

如果您希望自动克隆缺失布局而不是抛出 PptxEditException，则将 allowCloneMissingLayout 参数传递为 true。

同样适用于 ISlideCollection 方法：

ISlide InsertClone(int index, ISlide sourceSlide, IMasterSlide destMaster);

也已过时并被签名替代为

ISlide InsertClone(int index, ISlide sourceSlide, IMasterSlide destMaster, bool allowCloneMissingLayout);
#### **Aspose.Slides.IMasterSlide.LayoutSlides 属性的类型**
Aspose.Slides.IMasterSlide.LayoutSlides 属性的类型已从 ILayoutSlideCollection 更改为新的 IMasterLayoutSlideCollection 接口。IMasterLayoutSlideCollection 接口是 ILayoutSlideCollection 的派生类，因此现有代码无需适应。
#### **Aspose.Slides.IPresentation.LayoutSlides 属性的类型已更改**
Aspose.Slides.IPresentation.LayoutSlides 属性的类型已从 ILayoutSlideCollection 更改为新的 IGlobalLayoutSlideCollection 接口。IGlobalLayoutSlideCollection 接口是 ILayoutSlideCollection 的派生类，因此现有代码无需适应。