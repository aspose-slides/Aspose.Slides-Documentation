---
title: Aspose.Slides for .NET 14.5.0 的公共 API 與向後不相容變更
linktitle: Aspose.Slides for .NET 14.5.0
type: docs
weight: 70
url: /zh-hant/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/
keywords:
- 遷移
- 舊版程式碼
- 現代程式碼
- 舊版方法
- 現代方法
- PowerPoint
- OpenDocument
- 簡報
- .NET
- C#
- Aspose.Slides
description: "檢視 Aspose.Slides for .NET 的公共 API 更新與破壞性變更，以順利遷移您的 PowerPoint PPT、PPTX 和 ODP 簡報解決方案。"
---
{{% alert color="primary" %}} 

此頁面列出所有在 Aspose.Slides for .NET 14.5.0 API 中[已新增](/slides/zh-hant/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/)的類別、方法、屬性等，以及任何新的[限制](/slides/zh-hant/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/)和其他[變更](/slides/zh-hant/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/)。

{{% /alert %}} 
## **公共 API 與不相容的變更**
### **已新增的介面、類別、屬性與方法**
#### **已新增 Aspose.Slides.IPresentationInfo 介面和 PresentationInfo 類別**
表示簡報的資訊。

- Boolean 屬性 IsEncrypted 在簡報被加密時返回 True，否則返回 False。
- 屬性 LoadFormat 獲得簡報的類型。
#### **已新增 Aspose.Slides.IShape.IsGrouped 屬性**
屬性 Aspose.Slides.IShape.IsGrouped 用於判斷形狀是否為群組的一部分。
#### **已新增 Aspose.Slides.IShape.ParentGroup 屬性**
屬性 Aspose.Slides.IShape.ParentGroup 若形狀屬於群組，則返回其父 GroupShape 物件；否則返回 null。
#### **已新增 Aspose.Slides.IShapeCollection.AddGroupShape() 方法**
方法 Aspose.Slides.IShapeCollection.AddGroupShape() 會建立新的 GroupShape 並將其加入集合的末尾。  
當新增形狀時，GroupShape 的框架大小和位置會自動調整以符合內容。
#### **已新增 Aspose.Slides.IShapeCollection.Clear() 方法**
方法 Aspose.Slides.IShapeCollection.Clear() 會從集合中移除所有形狀。
#### **已新增 Aspose.Slides.IShapeCollection.InsertGroupShape(int) 方法**
方法 Aspose.Slides.IShapeCollection.InsertGroupShape(int) 會建立新的 GroupShape，並在指定的索引位置插入到集合中。  
當新增形狀時，GroupShape 的框架大小和位置會自動調整以符合內容。
#### **已新增 IPresentationFactory.GetPresentationInfo(string file)、IPresentatoinFactory.GetPresentationInfo(Stream stream) 方法**
這些方法可在不完整載入簡報的情況下取得簡報檔案或串流的資訊。
#### **已新增 IPresentationFactory PresentationFactory.Instance 屬性**
此屬性允許開發人員在不實例化的情況下使用工廠功能。
### **限制**
#### **對 IShape.Frame 的限制**
已針對 IShape.Frame 使用未定義值加入限制。大多數情況下，嘗試將未定義的框架指派給 IShape.Frame 並無意義（尤其是當父 GroupShape 多層巢狀於其他 {{GroupShape}} 時）。例如：

``` csharp

 IShape shape = ...;

shape.Frame = new ShapeFrame(float.NaN, float.NaN, float.NaN, float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, float.NaN);


``` 

or

``` csharp

 slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, float.NaN, float.NaN, float.NaN, float.NaN);

``` 

此類程式碼可能導致不明確的情況。因此已對使用未定義的 IShape.Frame 值加入限制。x、y、width、height、flipH、flipV 以及 rotationAngle 必須被定義（且不能設定為 float.NaN 或 NullableBool.NotDefined）。上述範例程式碼現在會拋出 ArgumentException 例外。  
此限制適用於以下使用情況：

``` csharp

 IShape shape = ...;

shape.Frame = ...; // 不能為未定義

IShapeCollection shapes = ...;

// x、y、寬度、高度參數不能為 float.NaN:

{

    shapes.AddAudioFrameCD(...);

    shapes.AddAudioFrameEmbedded(...);

    shapes.AddAudioFrameLinked(...);

    shapes.AddAutoShape(...);

    shapes.AddChart(...);

    shapes.AddConnector(...);

    shapes.AddOleObjectFrame(...);

    shapes.AddPictureFrame(...);

    shapes.AddSmartArt(...);

    shapes.AddTable(...);

    shapes.AddVideoFrame(...);

    shapes.InsertAudioFrameEmbedded(...);

    shapes.InsertAudioFrameLinked(...);

    shapes.InsertAutoShape(...);

    shapes.InsertChart(...);

    shapes.InsertConnector(...);

    shapes.InsertOleObjectFrame(...);

    shapes.InsertPictureFrame(...);

    shapes.InsertTable(...);

    shapes.InsertVideoFrame(...);

}


``` 

但 IShape.RawFrame 的框架屬性可以是未定義的。當形狀連結到占位符時，這是合理的。此時未定義的形狀框架值會被父占位符形狀覆寫。若沒有父占位符形狀，則該形狀在基於其 IShape.RawFrame 評估有效框架時會使用預設值。預設值為 x、y、width、height、flipH、flipV 以及 rotationAngle 為 0 或 NullableBool.False。例如：

``` csharp

 IShape shape = ...; // shape 已連結至佔位符

shape.RawFrame = new ShapeFrame(float.NaN, float.NaN, 100, float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, 0);

// 現在 shape 繼承來自佔位符的 x、y、height、flipH、flipV 值，並覆寫 width=100 與 rotationAngle=0.

``` 
### **已變更的屬性**
#### **已變更 Aspose.Slides.IShapeCollection.Parent 屬性的名稱與類型**
- Aspose.Slides.IShapeCollection.Parent 屬性的類型已從 ISlideComponent 改為全新的 IGroupShape 介面。IGroupShape 介面是 ISlideComponent 的衍生介面，故現有程式碼無需調整。
- Aspose.Slides.IShapeCollection.Parent 屬性的名稱已由 Parent 改為 ParentGroup。
#### **已變更 Aspose.Slides.IShapeFrame.FlipH 與 .FlipV 屬性的類型**
- Aspose.Slides.IShapeFrame.FlipH 屬性的類型已從 bool 改為 NullableBool。
- IShape.Frame 屬性返回一個有效的 IShapeFrame 實例（其所有屬性皆具有已定義的有效值）。
- IShape.RawFrame 屬性返回 IShapeFrame 的一個實例，其中每個屬性皆可為未定義值（特別是 FlipH 或 FlipV 可為 NullableBool.NotDefined）。