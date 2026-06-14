---
title: Aspose.Slides for Java 14.5.0 的公共 API 與向後不相容的變更
linktitle: Aspose.Slides for Java 14.5.0
type: docs
weight: 40
url: /zh-hant/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/
keywords:
- 遷移
- 舊版程式碼
- 現代程式碼
- 舊版方法
- 現代方法
- PowerPoint
- OpenDocument
- 簡報
- Java
- Aspose.Slides
description: "檢視 Aspose.Slides for Java 的公共 API 更新與重大變更，以順利遷移您的 PowerPoint PPT、PPTX 與 ODP 簡報解決方案。"
---
{{% alert color="primary" %}} 
此頁面列出所有 [已新增](/slides/zh-hant/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/) 類別、方法、屬性等，任何新 [限制](/slides/zh-hant/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/) 與其他 [變更](/slides/zh-hant/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/)，這些皆是隨 Aspose.Slides for Java 14.5.0 API 所引入。
{{% /alert %}} 
## **公共 API 與向後不相容的變更**
### **已新增的類別與方法**
#### **已新增 Aspose.Slides.IPresentationInfo 介面與 PresentationInfo 類別**
代表簡報的資訊。

Method Boolean isEncrypted() 取得 True，如果簡報已加密，否則取得 False。

Method LoadFormat getLoadFormat() 取得簡報類型。
#### **已新增 Aspose.Slides.IShape.isGrouped() 方法**
Aspose.Slides.IShape.isGrouped() 方法判斷圖形是否已分組。
#### **已新增 Aspose.Slides.IShape.getParentGroup() 方法**
Aspose.Slides.IShape.getParentGroup() 方法在圖形已分組時返回其父 GroupShape 物件，否則返回 null。
#### **已新增 Aspose.Slides.IShapeCollection.addGroupShape() 方法**
Aspose.Slides.IShapeCollection.addGroupShape() 方法建立新的 GroupShape 並將其加入集合的末端。

當新圖形加入 GroupShape 時，GroupShape 的框架大小與位置會依內容自動調整。
#### **已新增 Aspose.Slides.IShapeCollection.clear() 方法**
Aspose.Slides.IShapeCollection.clear() 方法移除集合中的所有圖形。
#### **已新增 Aspose.Slides.IShapeCollection.insertGroupShape(int) 方法**
Aspose.Slides.IShapeCollection.insertGroupShape(int) 方法建立新的 GroupShape 並依指定索引插入集合。

當新圖形加入 GroupShape 時，GroupShape 的框架大小與位置會依內容自動調整。
#### **已新增 IPresentationFactory.getPresentationInfo(string file)、IPresentatoinFactory.getPresentationInfo(InputStream stream) 方法**
這些方法允許開發人員在不完整載入簡報的情況下取得簡報檔案/串流的資訊。
#### **已新增 IPresentationFactory PresentationFactory.getInstance() 方法**
允許在未實例化的情況下使用工廠功能。
### **限制**
#### **已為 IShape.getFrame() 使用未定義值加入限制**
嘗試將未定義的框架指派給 IShape.setFrame(IShapeFrame) 的程式碼在一般情況下並無意義（尤其是當父級 GroupShape 多層嵌套於其他 {{GroupShape}} 時）。例如：

``` java

 IShape shape = ...;

shape.setFrame(new ShapeFrame(Float.NaN, Float.NaN, Float.NaN, Float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, Float.NaN));

```

或

``` java

 slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, Float.NaN, Float.NaN, Float.NaN, Float.NaN);

```

此類程式碼可能導致不明確的情況。因此已為 IShape.Frame 加入限制。x、y、width、height、flipH、flipV 與 rotationAngle 的值必須已定義（不能為 Float.NaN 或 NullableBool.NotDefined）。上述範例程式碼現在會拋出 ArgumentException 例外。
此限制適用於以下使用情境：

``` java

 IShape shape = ...;

shape.setFrame(...); // 不能為未定義

IShapeCollection shapes = ...;

// x、y、width、height 參數不能為 Float.NaN:

{

    shapes.addAudioFrameCD(...);

    shapes.addAudioFrameEmbedded(...);

    shapes.addAudioFrameLinked(...);

    shapes.addAutoShape(...);

    shapes.addChart(...);

    shapes.addConnector(...);

    shapes.addOleObjectFrame(...);

    shapes.addPictureFrame(...);

    shapes.addSmartArt(...);

    shapes.addTable(...);

    shapes.addVideoFrame(...);

    shapes.insertAudioFrameEmbedded(...);

    shapes.insertAudioFrameLinked(...);

    shapes.insertAutoShape(...);

    shapes.insertChart(...);

    shapes.insertConnector(...);

    shapes.insertOleObjectFrame(...);

    shapes.insertPictureFrame(...);

    shapes.insertTable(...);

    shapes.insertVideoFrame(...);

}
```

但 IShape.getRawFrame() 的框架可以未定義。當圖形連結至佔位符時，此情況是合理的。未定義的圖形框架值會從父佔位符圖形覆寫。若該圖形沒有父佔位符圖形，則在根據 IShape.getRawFrame() 計算有效框架時會使用預設值。預設值為 x、y、width、height、flipH、flipV 與 rotationAngle 的 0 與 NullableBool.False。例如：

``` java

 IShape shape = ...; // 形狀已連結至佔位符

shape.setRawFrame(new ShapeFrame(Float.NaN, Float.NaN, 100, Float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, 0));

// 現在形狀會從佔位符繼承 x、y、height、flipH、flipV 的值，並覆寫 width=100 與 rotationAngle=0.

```
### **已變更的屬性**
#### **已變更 Aspose.Slides.IShapeCollection.getParent() 方法的類型與名稱**
Aspose.Slides.IShapeCollection.Parent 屬性的類型已由 ISlideComponent 改為新的 IGroupShape 介面。IGroupShape 介面是 ISlideComponent 的衍生介面，因此現有程式碼無需調整。

Aspose.Slides.IShapeCollection.getParent() 方法的名稱已由 getParent 改為 getParentGroup()。
#### **變更 Aspose.Slides.IShapeFrame.getFlipH() 與 .getFlipV() 方法的類型**
Aspose.Slides.IShapeFrame.getFlipH() 方法的類型已由 bool 改為 NullableBool。

IShape.getFrame() 方法返回 IShapeFrame 的有效實例（所有屬性皆具有已定義的有效值）。

IShape.getRawFrame() 方法返回 IShapeFrame 的實例，其中每個屬性皆可能為未定義值（特別是 FlipH 或 FlipV 可能為 NullableBool.NotDefined）。