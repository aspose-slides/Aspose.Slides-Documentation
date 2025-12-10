---
title: Aspose.Slides for .NET 14.4.0 のパブリック API と後方互換性のない変更
linktitle: Aspose.Slides for .NET 14.4.0
type: docs
weight: 60
url: /ja/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-4-0/
keywords:
- 移行
- レガシーコード
- モダンコード
- レガシーアプローチ
- モダンアプローチ
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET のパブリック API の更新と破壊的変更を確認し、PowerPoint PPT、PPTX、ODP プレゼンテーション ソリューションをスムーズに移行しましょう。"
---

## **公開 API と後方互換性がない変更**
### **追加されたインターフェイス、クラス、メソッド、プロパティ**
#### **Aspose.Slides.ILayoutSlide.HasDependingSlides プロパティが追加されました**
The property Aspose.Slides.ILayoutSlide.HasDependingSlides は、このレイアウトスライドに依存しているスライドが少なくとも 1 つ存在する場合に true を返します。例:

``` csharp

 ILayoutSlide layout = ...;

if (!layout.HasDependingSlides)

    layout.Remove();

``` 
#### **Aspose.Slides.ILayoutSlide.Remove() メソッド**
The method Aspose.Slides.ILayoutSlide.Remove() は、最小限のコードでプレゼンテーションからレイアウトを削除できます。例:

``` csharp

 ILayoutSlide layout = ...;

if (!layout.HasDependingSlides)

    layout.Remove();

``` 
#### **Aspose.Slides.ILayoutSlideCollection.Remove(ILayoutSlide) メソッド**
The method Aspose.Slides.ILayoutSlideCollection.Remove(ILayoutSlide) は、コレクションからレイアウトを削除できます。コード例:

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
The method Aspose.Slides.ILayoutSlideCollection.RemoveUnused() は、未使用のレイアウトスライド（HasDependingSlides が false のレイアウトスライド）を削除できます。コード例:

``` csharp

 presentation.LayoutSlides.RemoveUnused();

``` 

or

``` csharp

 IMasterSlide masterSlide = ...;

masterSlide.LayoutSlides.RemoveUnused();

``` 
#### **Aspose.Slides.IMasterSlide.HasDependingSlides プロパティ**
The property Aspose.Slides.IMasterSlide.HasDependingSlides は、このマスタースライドに依存しているスライドが少なくとも 1 つ存在する場合に true を返します。例:

``` csharp

 IMasterSlide masterSlide = ...;

if (!masterSlide.HasDependingSlides)

    presentation.Masters.Remove(masterSlide);

``` 
#### **Aspose.Slides.ISlide.Remove() メソッド**
The method Aspose.Slides.ISlide.Remove() は、最小限のコードでプレゼンテーションからスライドを削除できます。例:

``` csharp

 ISlide slide = ...;

slide.Remove();

``` 
#### **Aspose.Slides.SmartArt.ISmartArtNode.BulletFillFormat**
The property Aspose.Slides.SmartArt.ISmartArtNode.BulletFillFormat は、レイアウトが箇条書きを提供している場合に SmartArt ノードの箇条書き用 IFillFormat を返します。箇条書きの画像を設定するために使用できます。

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-SmartArts-BulletFillFormat-BulletFillFormat.cs" >}}
#### **Aspose.Slides.SmartArt.ISmartArtNode.Level プロパティ**
The property Aspose.Slides.SmartArt.ISmartArtNode.Level は、SmartArt ノードの階層レベルを返します。

``` csharp

 ISmartArtNode node = diagram.AllNodes[0];

if(node.Level == 1)

    node.TextFrame.Text = "First level";

``` 
#### **Aspose.Slides.SmartArt.ISmartArtNode.Position プロパティ**
The property Aspose.Slides.SmartArt.ISmartArtNode.Position は、兄弟ノード間でのノードの位置を返します。

``` csharp

 ISmartArtNode node = diagram.AllNodes[0];

if (node.ChildNodes.Count > 3)

    node.ChildNodes[0].Position++;

``` 
#### **Aspose.Slides.SmartArt.ISmartArtNode.Remove() メソッドが追加されました**
The Aspose.Slides.SmartArt.ISmartArtNode.Remove() method は、ダイアグラムからノードを削除できます。

``` csharp

 ISmartArt node = diagram.AllNodes[0];

node.Remove();

``` 
#### **IGlobalLayoutSlideCollection インターフェイス と GlobalLayoutSlideCollection クラス**
The IGlobalLayoutSlideCollection interface and the GlobalLayoutSlideCollection class have been added into the Aspose.Slides namespace.

The GlobalLayoutSlideCollection class implements the IGlobalLayoutSlideCollection interface.

The IGlobalLayoutSlideCollection interface represents a collection of all layout slides in a presentation. The IPresentation.LayoutSlides property is of the type IGlobalLayoutSlideCollection. IGlobalLayoutSlideCollection extends the ILayoutSlideCollection interface with methods for adding and cloning layout slides in context of uniting of the individual collections of master's layout slides:

- ILayoutSlide AddClone(ILayoutSlide sourceLayout); – Can be used to add a copy of a specified layout slide to the presentation. This method keeps the source formatting (when cloning a layout between different presentations, the layout's master can be cloned too. The internal registry is used to track automatically cloned masters to prevent the creation of multiple clones of the same master slide.)
- ILayoutSlide AddClone(ILayoutSlide sourceLayout, IMasterSlide destMaster); – Used to add a copy of a specified layout slide to a presentation. The new layout will be linked to the defined master in the destination presentation. This option is analogue to copying or pasting with the **Use Destination Theme** option in Microsoft PowerPoint.
- ILayoutSlide Add(IMasterSlide master, SlideLayoutType layoutType, string layoutName); – Used to add a new layout slide to a presentation. Supported layout types: Title, TitleOnly, Blank, TitleAndObject, VerticalText, VerticalTitleAndText, TwoObjects, SectionHeader, TwoTextAndTwoObjects, TitleObjectAndCaption, PictureAndCaption, Custom. Layout name can be generated atomatically. An added layout of the type SlideLayoutType.Custom contains no placeholders and no shapes. An analogue of this method is the IMasterLayoutSlideCollection.Add(SlideLayoutType, string) method accessed with the IMasterSlide.LayoutSlides property.
#### **Interface IMasterLayoutSlideCollection と Class MasterLayoutSlideCollection**
The IMasterLayoutSlideCollection interface and MasterLayoutSlideCollection class had been added to the Aspose.Slides namespace. The MasterLayoutSlideCollection class implements the IMasterLayoutSlideCollection interface.

The IMasterLayoutSlideCollection interface represents a collections of all layout slides of a defined master slide. It extends the ILayoutSlideCollection interface with methods for adding, inserting, removing or cloning layout slides in the context of the individual collections of a master's layout slides:

``` csharp

 // Method signature:

ILayoutSlide AddClone(ILayoutSlide sourceLayout);

// Code example that attaches copy of the sourceLayout to the destMasterSlide:

IMasterSlide destMasterSlide = ...;

destMasterSlide.LayoutSlides.AddClone(sourceLayout);

``` 

The method can be used to add a copy of a specified layout slide to the end of the collection. The new layout will be linked with the parent master slide for this layout slides collection. So this is analogue of copying or pasting with the **Use Destination Theme** option in PowerPoint. Analogue of this method is the method IGlobalLayoutSlideCollection.AddClone(ILayoutSlide, IMasterSlide) accessed with the IPresentation.LayoutSlides property.

- ILayoutSlide InsertClone(int index, ILayoutSlide sourceLayout); – Used to insert a copy of a specified layout slide to specified position of the collection. New layout will be linked with parent master slide for this layout slides collection. So this is analogue of copying and pasting with the **Use Destination Theme** option in PowerPoint.
- ILayoutSlide Add(SlideLayoutType layoutType, string layoutName);
- ILayoutSlide Insert(int index, SlideLayoutType layoutType, string layoutName); – Used to add or inserts a new layout slide. Supported layout types: Title, TitleOnly, Blank, TitleAndObject, VerticalText, VerticalTitleAndText, TwoObjects, SectionHeader, TwoTextAndTwoObjects, TitleObjectAndCaption, PictureAndCaption, Custom. The layout name can be generated atomatically. Added layout of the SlideLayoutType.Custom type contains no placeholders and no shapes. Analogue of this method is the IGlobalLayoutSlideCollection.Add(IMasterSlide, SlideLayoutType, string) method accessed with the IPresentation.LayoutSlides property.
- void RemoveAt(int index); – Used to remove the layout at the specified index of the collection.
- void Reorder(int index, ILayoutSlide layoutSlide); – Used to move layout slide from the collection to the specified position.
### **変更されたメソッドとプロパティ**
#### **Aspose.Slides.ISlideCollection.AddClone(ISlide, IMasterSlide) メソッドのシグネチャ**
The signature of the ISlideCollection method:
ISlide AddClone(ISlide sourceSlide, IMasterSlide destMaster);

is obsolete now and is replaced with signature

ISlide AddClone(ISlide sourceSlide, IMasterSlide destMaster, bool allowCloneMissingLayout)

The allowCloneMissingLayout parameter specifies what to do if there is no appropriate layout in the destMaster for the new (cloned) slide. The appropriate layout is the layout with the same type or name as the layout of the source slide. If there is no appropriate layout in the specified master then the layout of the source slide will be cloned (if allowCloneMissingLayout is true) or a PptxEditException will be thrown (if allowCloneMissingLayout is false).

Call of the obsolete method like

AddClone(sourceSlide, destMaster);

assumes allowCloneMissingLayout is equal to false (that is, PptxEditException will be thrown if there is no appropriate layout). Functionally identical call that uses new signature looks like this:
AddClone(sourceSlide, destMaster, false);

If you want missing layouts to be automatically cloned instead PptxEditException throwing then pass the allowCloneMissingLayout parameter as true.

The same refers to the ISlideCollection method:

ISlide InsertClone(int index, ISlide sourceSlide, IMasterSlide destMaster);

is also obsolete now and is replaced with signature

ISlide InsertClone(int index, ISlide sourceSlide, IMasterSlide destMaster, bool allowCloneMissingLayout);
#### **Aspose.Slides.IMasterSlide.LayoutSlides プロパティの型**
The type of the Aspose.Slides.IMasterSlide.LayoutSlides property has been changed from ILayoutSlideCollection to the new IMasterLayoutSlideCollection interface. The IMasterLayoutSlideCollection interface is a descendant of the ILayoutSlideCollection so existing code needs no adaptations.
#### **Aspose.Slides.IPresentation.LayoutSlides プロパティの型が変更されました**
The type of the Aspose.Slides.IPresentation.LayoutSlides property has been changed from ILayoutSlideCollection to the new IGlobalLayoutSlideCollection interface. The IGlobalLayoutSlideCollection interface is a descendant of the ILayoutSlideCollection so existing code needs no adaptations.