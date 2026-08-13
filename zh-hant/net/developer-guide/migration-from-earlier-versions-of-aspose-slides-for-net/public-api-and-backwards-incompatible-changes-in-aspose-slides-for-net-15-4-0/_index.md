---
title: Aspose.Slides for .NET 15.4.0 的公共 API 與向後不相容變更
linktitle: Aspose.Slides for .NET 15.4.0
type: docs
weight: 150
url: /zh-hant/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-4-0/
keywords:
- 移植
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
description: "檢視 Aspose.Slides for .NET 的公共 API 更新與重大破壞性變更，以順暢完成 PowerPoint PPT、PPTX 與 ODP 簡報解決方案的移植。"
---
{{% alert color="info" %}} 

此頁面列出所有[added](/slides/zh-hant/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-4-0/)或[removed](/slides/zh-hant/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-4-0/)類別、方法、屬性等，及 Aspose.Slides for .NET 15.4.0 API 所帶來的其他變更。

{{% /alert %}} 
## **公共 API 變更**
#### **已新增 Enum OrganizationChartLayoutType**
Aspose.Slides.SmartArt.OrganizationChartLayoutType 列舉表示組織圖中子節點的格式類型。
#### **已新增 方法 IBulletFormat.ApplyDefaultParagraphIndentsShifts**
Method Aspose.Slides.IBulletFormat.ApplyDefaultParagraphIndentsShifts 在啟用項目符號時（如 PowerPoint 在啟用段落項目符號/編號時的行為），設定有效段落縮排 (Indent) 與左側外距 (MarginLeft) 的預設非零位移。若項目符號被停用，則僅重設段落縮排與左側外距（如 PowerPoint 在停用段落項目符號/編號時的行為）。
參考範例[here](/slides/zh-hant/net/adding-and-formatting-text/#managing-paragraph-bullets-in-pptx)：
#### **已新增 方法 IConnector.Reroute**
Method Aspose.Slides.IConnector.Reroute 重新路由連接線，使其在連接的圖形之間走最短的路徑。為達成此目的，Reroute() 方法可能會變更 StartShapeConnectionSiteIndex 與 EndShapeConnectionSiteIndex。

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;


 using(Presentation input = new Presentation())

{

  IShapeCollection shapes = input.Slides[0].Shapes;

  IConnector connector = shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 10, 10);

  IAutoShape ellipse = shapes.AddAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);

  IAutoShape rectangle = shapes.AddAutoShape(ShapeType.Rectangle, 100, 300, 100, 100);

  connector.StartShapeConnectedTo = ellipse;

  connector.EndShapeConnectedTo = rectangle;

  connector.Reroute();

  input.Save("output.pptx", SaveFormat.Pptx);

}

``` 
#### **已新增 方法 IPresentation.GetSlideById**
Method Aspose.Slides.IPresentation.GetSlideById(System.UInt32) 依照投影片 Id 取得 Slide、MasterSlide 或 LayoutSlide。

``` csharp
using System.Diagnostics;
using Aspose.Slides;


 using (Presentation presentation = new Presentation())

{

    uint id = presentation.Slides[0].SlideId;

    IBaseSlide slide = presentation.GetSlideById(id);

    Debug.Assert(presentation.Slides[0] == slide);

}
``` 
#### **已新增 屬性 IShape.ConnectionSiteCount**
Property Aspose.Slides.IShape.ConnectionSiteCount 回傳圖形的連接點數量。

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;


 using(Presentation input = new Presentation())

{

  IShapeCollection shapes = input.Slides[0].Shapes;

  IConnector connector = shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 10, 10);

  IAutoShape ellipse = shapes.AddAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);

  IAutoShape rectangle = shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 100, 100);

  connector.StartShapeConnectedTo = ellipse;

  connector.EndShapeConnectedTo = rectangle;

  uint wantedIndex = 6;

  if (ellipse.ConnectionSiteCount > wantedIndex)

  {

    connector.StartShapeConnectionSiteIndex = wantedIndex;

  }

  input.Save("output.pptx", SaveFormat.Pptx);

}
``` 
#### **已新增 屬性 ISmartArt.IsReversed**
Property Aspose.Slides.SmartArt.ISmartArt.IsReversed 允許取得或設定 SmartArt 圖表的左右閱讀順序 (LTR 或 RTL)，前提是圖表支援反轉。

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;


 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicProcess);

  smart.IsReversed = true;

  pres.Save("out.pptx", SaveFormat.Pptx);

}
``` 
#### **已新增 屬性 ISmartArt.Nodes**
Property Aspose.Slides.SmartArt.ISmartArt.Nodes 回傳 SmartArt 物件中根節點的集合。

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;


 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.VerticalBulletList);

  ISmartArtNode node = smart.Nodes[1]; // 選取第二個根節點

  node.TextFrame.Text = "Second root node";

  pres.Save("out.pptx", SaveFormat.Pptx);

}
``` 
#### **已新增 屬性 ISmartArtNode.IsHidden**
Property Aspose.Slides.SmartArt.ISmartArtNode.IsHidden 若此節點在資料模型中為隱藏節點則回傳 true。

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;


 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);

  ISmartArtNode node = smart.AllNodes.AddNode();

  bool hidden = node.IsHidden; //返回 true

  if(hidden)

  {

    //執行某些操作或通知

  }

  pres.Save("out.pptx", SaveFormat.Pptx);

}
``` 
#### **已新增 屬性 ISmartArtNode.OrganizationChartLayout**
Property Aspose.Slides.SmartArt.ISmartArtNode.OrganizationChartLayout 允許取得或設定與目前節點相關聯的組織圖類型。

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;


 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);

  smart.Nodes[0].OrganizationChartLayout = OrganizationChartLayoutType.LeftHanging;

  pres.Save("out.pptx", SaveFormat.Pptx);

}
``` 
#### **已新增 屬性 ISmartArt.Layout 的設定方法**
已新增 Aspose.Slides.SmartArt.ISmartArt.Layout 屬性的設定方法。它允許變更現有圖表的版面配置類型。

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;


 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

  smart.Layout = SmartArtLayoutType.BasicProcess;

  pres.Save("out.pptx", SaveFormat.Pptx);

}
``` 
#### **次要 API 變更**
**以下為次要 API 變更列表：**

|Enum Aspose.Slides.BevelColorMode |已刪除，未使用的列舉 |
| :- | :- |
|Property ThreeDFormatEffectiveData.BevelColorMode |已刪除，未使用的屬性 |
|Property Aspose.Slides.Charts.ChartSeriesGroup.Chart <br>Property Aspose.Slides.Charts.IChartSeriesGroup.AsIChartComponent |已新增 |
|Property Aspose.Slides.IParagraphFormatEffectiveData.AsISlideComponent <br>Inheritance of IParagraphFormatEffectiveData from ISlideComponent <br>Property Aspose.Slides.IThreeDFormat.AsISlideComponent <br>Inheritance of IThreeDFormat from ISlideComponent |已刪除 |
|Property Aspose.Slides.ParagraphFormatEffectiveData.BulletChar <br>Property Aspose.Slides.ParagraphFormatEffectiveData.BulletFont <br>Property Aspose.Slides.ParagraphFormatEffectiveData.BulletHeight <br>Property Aspose.Slides.ParagraphFormatEffectiveData.BulletType <br>Property Aspose.Slides.ParagraphFormatEffectiveData.NumberedBulletStartWith <br>Property Aspose.Slides.ParagraphFormatEffectiveData.NumberedBulletStyle |已刪除，已過時 |