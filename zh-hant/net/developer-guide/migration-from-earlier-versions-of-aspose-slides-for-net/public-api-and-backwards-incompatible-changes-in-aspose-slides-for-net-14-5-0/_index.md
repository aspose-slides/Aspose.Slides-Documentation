---
title: Aspose.Slides for .NET 14.5.0 中的公開 API 及向後相容性破壞之變更
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
description: "檢視 Aspose.Slides for .NET 的公開 API 更新與破壞性變更，以順利遷移您的 PowerPoint PPT、PPTX 與 ODP 簡報解決方案。"
---
{{% alert color="info" %}} 
此頁面列出所有[已新增](/slides/zh-hant/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/) 類別、方法、屬性等，任何新的[限制](/slides/zh-hant/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/)以及其他[變更](/slides/zh-hant/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/)，這些皆是隨著 Aspose.Slides for .NET 14.5.0 API 引入的。
{{% /alert %}} 
## **公開 API 與向後相容性破壞之變更**
### **已新增的介面、類別、屬性與方法**
#### **已新增 Aspose.Slides.IPresentationInfo 介面與 PresentationInfo 類別**
表示簡報的資訊。

- 布林屬性 IsEncrypted 若簡報已加密則傳回 True，否則傳回 False。
- 屬性 LoadFormat 取得簡報的類型。
#### **已新增 Aspose.Slides.IShape.IsGrouped 屬性**
Aspose.Slides.IShape.IsGrouped 屬性決定形狀是否已分組。
#### **已新增 Aspose.Slides.IShape.ParentGroup 屬性**
Aspose.Slides.IShape.ParentGroup 屬性在形狀已分組時傳回其父層 GroupShape 物件，否則傳回 null。
#### **已新增 Aspose.Slides.IShapeCollection.AddGroupShape() 方法**
Aspose.Slides.IShapeCollection.AddGroupShape() 方法建立新 GroupShape 並將其加入集合的末端。新增形狀時，GroupShape 的框架大小與位置會自動調整至內容。
#### **已新增 Aspose.Slides.IShapeCollection.Clear() 方法**
Aspose.Slides.IShapeCollection.Clear() 方法會移除集合中所有形狀。
#### **已新增 Aspose.Slides.IShapeCollection.InsertGroupShape(int) 方法**
Aspose.Slides.IShapeCollection.InsertGroupShape(int) 方法建立新 GroupShape 並在指定的索引位置插入集合。新增形狀時，GroupShape 的框架大小與位置會自動調整至內容。
#### **已新增 IPresentationFactory.GetPresentationInfo(string file)、IPresentationFactory.GetPresentationInfo(Stream stream) 方法**
這些方法允許在不完整載入簡報的情況下取得簡報檔案或資料流的資訊。
#### **已新增 IPresentationFactory PresentationFactory.Instance 屬性**
此屬性讓開發人員在不實例化的情況下使用工廠功能。
### **限制**
#### **IShape.Frame 的限制**
已加入對於使用未定義值於 IShape.Frame 的限制。嘗試將未定義的框架指派給 IShape.Frame 的程式碼在大多數情況下沒有意義（尤其是當父層 GroupShape 多層巢狀於其他 {{GroupShape}} 時）。例如：

``` csharp
using Aspose.Slides;

Presentation presentation = new Presentation();
IShape shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);

// 拋出 ArgumentException：框架值必須已定義。
shape.Frame = new ShapeFrame(float.NaN, float.NaN, float.NaN, float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, float.NaN);
``` 

或

``` csharp
using Aspose.Slides;

Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];

// 拋出 ArgumentException：x、y、寬度與高度必須已定義。
slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, float.NaN, float.NaN, float.NaN, float.NaN);
``` 

此類程式碼可能導致不明確的情況。因此已加入對於使用未定義值於 IShape.Frame 的限制。x、y、width、height、flipH、flipV 與 rotationAngle 必須有明確定義（且不可設為 float.NaN 或 NullableBool.NotDefined）。上述範例程式碼現在會拋出 ArgumentException 例外。
此限制適用於以下使用情境：

``` csharp
using Aspose.Slides;

Presentation presentation = new Presentation();
IShapeCollection shapes = presentation.Slides[0].Shapes;

// x、y、寬度與高度參數不能為 float.NaN，且 flipH、flipV
// 不能為 NullableBool.NotDefined：
IShape shape = shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);
shape.Frame = new ShapeFrame(100, 100, 200, 100, NullableBool.False, NullableBool.False, 0);

// 相同的限制適用於所有建立形狀的方法：
// AddAudioFrameCD, AddAudioFrameEmbedded, AddAudioFrameLinked, AddAutoShape, AddChart,
// AddConnector, AddOleObjectFrame, AddPictureFrame, AddSmartArt, AddTable, AddVideoFrame,
// InsertAudioFrameEmbedded, InsertAudioFrameLinked, InsertAutoShape, InsertChart,
// InsertConnector, InsertOleObjectFrame, InsertPictureFrame, InsertTable, InsertVideoFrame.
``` 

但 IShape.RawFrame 的框架屬性可以未定義。當形狀連結至占位符時，這是合理的。此時未定義的形狀框架值會從父層占位符形狀覆寫。若沒有父層占位符形狀，則該形狀在根據 IShape.RawFrame 評估有效框架時會使用預設值。預設值為 x、y、width、height、flipH、flipV 與 rotationAngle 為 0 與 NullableBool.False。例如：

``` csharp
using Aspose.Slides;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    // 此形狀已連結至占位符
    IShape shape = presentation.Slides[0].Shapes[0];

    shape.RawFrame = new ShapeFrame(float.NaN, float.NaN, 100, float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, 0);

    // 現在形狀從占位符繼承 x、y、height、flipH、flipV 值，並覆寫 width=100 與 rotationAngle=0。
}
``` 
### **已變更的屬性**
#### **變更 Aspose.Slides.IShapeCollection.Parent 屬性的名稱與類型**
- Aspose.Slides.IShapeCollection.Parent 屬性的類型已由 ISlideComponent 變更為新的 IGroupShape 介面。IGroupShape 繼承自 ISlideComponent，現有程式碼無需調整。
- Aspose.Slides.IShapeCollection.Parent 屬性的名稱已由 Parent 變更為 ParentGroup。
#### **變更 Aspose.Slides.IShapeFrame.FlipH、FlipV 屬性的類型**
- Aspose.Slides.IShapeFrame.FlipH 屬性的類型已由 bool 變更為 NullableBool。
- IShape.Frame 屬性會傳回一個具有所有屬性已定義有效值的 IShapeFrame 實例。
- IShape.RawFrame 屬性會傳回一個 IShapeFrame 實例，其每個屬性皆可為未定義值（特別是 FlipH 或 FlipV 可為 NullableBool.NotDefined）。