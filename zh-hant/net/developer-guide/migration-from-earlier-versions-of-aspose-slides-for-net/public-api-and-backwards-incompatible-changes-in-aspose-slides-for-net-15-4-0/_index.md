---
title: Aspose.Slides for .NET 15.4.0 的公共 API 以及向後不相容的變更
linktitle: Aspose.Slides 適用於 .NET 15.4.0
type: docs
weight: 150
url: /zh-hant/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-4-0/
keywords:
- 遷移
- 舊版程式碼
- 現代程式碼
- 舊式方法
- 現代方法
- PowerPoint
- OpenDocument
- 簡報
- .NET
- C#
- Aspose.Slides
description: "檢閱 Aspose.Slides for .NET 的公共 API 更新與相容性斷層變更，以順利遷移您的 PowerPoint PPT、PPTX 與 ODP 簡報解決方案。"
---
{{% alert color="primary" %}} 

此頁面列出所有 [已新增](/slides/zh-hant/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-4-0/) 或 [已移除](/slides/zh-hant/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-4-0/) 類別、方法、屬性等，以及其他隨 Aspose.Slides for .NET 15.4.0 API 引入的變更。

{{% /alert %}} 
## **公共 API 變更**
#### **Enum OrganizationChartLayoutType 已新增**
Aspose.Slides.SmartArt.OrganizationChartLayoutType 列舉代表組織圖中子節點的格式類型。
#### **Method IBulletFormat.ApplyDefaultParagraphIndentsShifts 已新增**
Aspose.Slides.IBulletFormat.ApplyDefaultParagraphIndentsShifts 方法於啟用項目符號時（如 PowerPoint 在啟用段落項目符號/編號時的行為），設定有效段落縮排和左邊距的預設非零偏移。若項目符號被停用，則僅重設段落縮排與左邊距（如 PowerPoint 在停用段落項目符號/編號時的行為）。
請參考範例 [此處](/slides/zh-hant/net/adding-and-formatting-text/#managing-paragraph-bullets-in-pptx)：
#### **Method IConnector.Reroute 已新增**
Aspose.Slides.IConnector.Reroute 方法會重新路由連接線，使其在連接的形狀之間走最短路徑。為此，Reroute() 方法可能會變更 StartShapeConnectionSiteIndex 與 EndShapeConnectionSiteIndex。

``` csharp

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
#### **Method IPresentation.GetSlideById 已新增**
Aspose.Slides.IPresentation.GetSlideById(System.UInt32) 方法依照投影片 ID 回傳 Slide、MasterSlide 或 LayoutSlide。

``` csharp

 using (Presentation presentation = new Presentation())

{

    uint id = presentation.Slides[0].SlideId;

    IBaseSlide slide = presentation.GetSlideById(id);

    Debug.Assert(presentation.Slides[0] == slide);

}

``` 
#### **Property IShape.ConnectionSiteCount 已新增**
Aspose.Slides.IShape.ConnectionSiteCount 屬性回傳形狀上的連接點數量。

``` csharp

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
#### **Property ISmartArt.IsReversed 已新增**
Aspose.Slides.SmartArt.ISmartArt.IsReversed 屬性允許取得或設定 SmartArt 圖表的方向狀態（自左至右 LTR 或自右至左 RTL），前提是圖表支援翻轉。

``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicProcess);

  smart.IsReversed = true;

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}

``` 
#### **Property ISmartArt.Nodes 已新增**
Aspose.Slides.SmartArt.ISmartArt.Nodes 屬性回傳 SmartArt 物件中根節點的集合。

``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.VerticalBulletList);

  ISmartArtNode node = smart.Nodes[1]; // 選取第二個根節點

  node.TextFrame.Text = "Second root node";

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}

``` 
#### **Property ISmartArtNode.IsHidden 已新增**
Aspose.Slides.SmartArt.ISmartArtNode.IsHidden 屬性若此節點在資料模型中為隱藏節點，則回傳 true。

``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);

  ISmartArtNode node = smart.AllNodes.AddNode();

  bool hidden = node.IsHidden; //傳回 true

  if(hidden)

  {

    //執行某些動作或通知

  }

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}
``` 
#### **Property ISmartArtNode.OrganizationChartLayout 已新增**
Aspose.Slides.SmartArt.ISmartArtNode.OrganizationChartLayout 屬性允許取得或設定與目前節點相關聯的組織圖類型。

``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);

  smart.Nodes[0].OrganizationChartLayout = OrganizationChartLayoutType.LeftHanging;

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}

``` 
#### **Set Method for Property ISmartArt.Layout 已新增**
已新增 Aspose.Slides.SmartArt.ISmartArt.Layout 屬性的設定方法，可變更現有圖表的版面配置類型。

``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

  smart.Layout = SmartArtLayoutType.BasicProcess;

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}
``` 
#### **次要 API 變更**
**以下為次要 API 變更清單：**

|Enum Aspose.Slides.BevelColorMode|已刪除，未使用的列舉|
| :- | :- |
|Property ThreeDFormatEffectiveData.BevelColorMode|已刪除，未使用的屬性|
|Property Aspose.Slides.Charts.ChartSeriesGroup.Chart <br>Property Aspose.Slides.Charts.IChartSeriesGroup.AsIChartComponent|已新增|
|Property Aspose.Slides.IParagraphFormatEffectiveData.AsISlideComponent <br>Inheritance of IParagraphFormatEffectiveData from ISlideComponent <br>Property Aspose.Slides.IThreeDFormat.AsISlideComponent <br>Inheritance of IThreeDFormat from ISlideComponent|已刪除|
|Property Aspose.Slides.ParagraphFormatEffectiveData.BulletChar <br>Property Aspose.Slides.ParagraphFormatEffectiveData.BulletFont <br>Property Aspose.Slides.ParagraphFormatEffectiveData.BulletHeight <br>Property Aspose.Slides.ParagraphFormatEffectiveData.BulletType <br>Property Aspose.Slides.ParagraphFormatEffectiveData.NumberedBulletStartWith <br>Property Aspose.Slides.ParagraphFormatEffectiveData.NumberedBulletStyle|已刪除，視為過時|