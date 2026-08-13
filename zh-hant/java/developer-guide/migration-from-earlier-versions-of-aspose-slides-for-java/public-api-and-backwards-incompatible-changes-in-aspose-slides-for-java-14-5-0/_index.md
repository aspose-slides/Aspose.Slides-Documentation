---
title: Aspose.Slides for Java 14.5.0 的公開 API 與向後不相容的變更
linktitle: Aspose.Slides for Java 14.5.0
type: docs
weight: 40
url: /zh-hant/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/
keywords:
- 遷移
- 舊有程式碼
- 現代程式碼
- 舊有方法
- 現代方法
- PowerPoint
- OpenDocument
- 簡報
- Java
- Aspose.Slides
description: "檢視 Aspose.Slides for Java 的公開 API 更新與重大變更，順利將您的 PowerPoint PPT、PPTX 及 ODP 簡報解決方案遷移。"
---
{{% alert color="info" %}} 

此頁面列出隨 Aspose.Slides for Java 14.5.0 API 所引入的所有[新增](/slides/zh-hant/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/) 類別、方法、屬性等，以及任何新的[限制](/slides/zh-hant/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/)和其他[變更](/slides/zh-hant/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/)。

{{% /alert %}} 
## **公開 API 與不相容的向後相容變更**
### **新增的類別與方法**
#### **新增 Aspose.Slides.IPresentationInfo 介面及 PresentationInfo 類別**
表示簡報的資訊。

Method Boolean isEncrypted() 取得如果簡報已加密則為 True，否則為 False。

Method LoadFormat getLoadFormat() 取得簡報類型。
#### **新增 Aspose.Slides.IShape.isGrouped() 方法**
Aspose.Slides.IShape.isGrouped() 方法判斷形狀是否已分組。
#### **新增 Aspose.Slides.IShape.getParentGroup() 方法**
Aspose.Slides.IShape.getParentGroup() 方法在形狀已分組時回傳父層 GroupShape 物件，否則回傳 null。
#### **新增 Aspose.Slides.IShapeCollection.addGroupShape() 方法**
Aspose.Slides.IShapeCollection.addGroupShape() 方法建立新 GroupShape，並將其加入集合尾端。

當新形狀加入 GroupShape 時，GroupShape 的框架大小與位置將自動調整以符合內容。
#### **新增 Aspose.Slides.IShapeCollection.clear() 方法**
Aspose.Slides.IShapeCollection.clear() 方法移除集合中所有形狀。
#### **新增 Aspose.Slides.IShapeCollection.insertGroupShape(int) 方法**
Aspose.Slides.IShapeCollection.insertGroupShape(int) 方法建立新 GroupShape，並依指定索引插入集合。

當新形狀加入 GroupShape 時，GroupShape 的框架大小與位置將自動調整以符合內容。
#### **新增 IPresentationFactory.getPresentationInfo(string file) 及 IPresentationFactory.getPresentationInfo(InputStream stream) 方法**
這兩個方法讓開發人員在不完整載入簡報的情況下取得簡報檔案/串流的資訊。
#### **新增 IPresentationFactory PresentationFactory.getInstance() 方法**
允許在不建立實例的情況下使用工廠功能。
### **限制**
#### **對 IShape.getFrame() 使用未定義值的限制已新增**
嘗試將未定義的框架指派給 IShape.setFrame(IShapeFrame) 的程式碼在一般情況下（尤其是父層 GroupShape 多層巢狀於其他 {{GroupShape}} 時）並沒有意義。例如：

``` java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);

    // 拋出 ArgumentException：框架值必須被定義。
    shape.setFrame(new ShapeFrame(Float.NaN, Float.NaN, Float.NaN, Float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, Float.NaN));
} finally {
    if (pres != null) pres.dispose();
}
```

或

``` java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);

    // 拋出 ArgumentException：x、y、寬度與高度值必須被定義。
    slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, Float.NaN, Float.NaN, Float.NaN, Float.NaN);
} finally {
    if (pres != null) pres.dispose();
}
```

此類程式碼可能導致不明確的情況。因此已為 IShape.Frame 加入使用未定義值的限制。x、y、width、height、flipH、flipV 與 rotationAngle 必須具備已定義的值（不可為 Float.NaN 或 NullableBool.NotDefined）。上述範例程式碼現在會拋出 ArgumentException 例外。此限制適用於以下使用情境：

``` java
// 傳遞給 IShape.setFrame(IShapeFrame) 的框架不能包含未定義的值.

// 以下 IShapeCollection 方法的 x、y、寬度與高度參數
// 也不能是 Float.NaN：
//
//     addAudioFrameCD
//     addAudioFrameEmbedded
//     addAudioFrameLinked
//     addAutoShape
//     addChart
//     addConnector
//     addOleObjectFrame
//     addPictureFrame
//     addSmartArt
//     addTable
//     addVideoFrame
//     insertAudioFrameEmbedded
//     insertAudioFrameLinked
//     insertAutoShape
//     insertChart
//     insertConnector
//     insertOleObjectFrame
//     insertPictureFrame
//     insertTable
//     insertVideoFrame
```

但 IShape.getRawFrame() 的框架可以是未定義的。這在形狀連結至佔位符時是合理的。此時未定義的形狀框架值會由父佔位符形狀覆寫。若該形狀沒有父佔位符形狀，則在根據 IShape.getRawFrame() 評估有效框架時會使用預設值。預設值為 x、y、width、height、flipH、flipV 與 rotationAngle 的 0 與 NullableBool.False。例如：

``` java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    // 形狀連結到佔位符。
    IShape shape = pres.getSlides().get_Item(0).getShapes().get_Item(0);

    shape.setRawFrame(new ShapeFrame(Float.NaN, Float.NaN, 100, Float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, 0));

    // 現在形狀從佔位符繼承 x、y、height、flipH 與 flipV 的值
    // 並且覆寫 width = 100 與 rotationAngle = 0。
} finally {
    if (pres != null) pres.dispose();
}
```
### **已變更的屬性**
#### **變更 Aspose.Slides.IShapeCollection.getParent() 方法的型別與名稱**
Aspose.Slides.IShapeCollection.Parent 屬性的型別已從 ISlideComponent 改為新介面 IGroupShape。IGroupShape 介面繼承自 ISlideComponent，現有程式碼無需調整。

Aspose.Slides.IShapeCollection.getParent() 方法的名稱已從 getParent 改為 getParentGroup()。
#### **變更 Aspose.Slides.IShapeFrame.getFlipH() 與 .getFlipV() 方法的型別**
Aspose.Slides.IShapeFrame.getFlipH() 方法的型別已從 bool 改為 NullableBool。

IShape.getFrame() 方法回傳 IShapeFrame 的有效實例（所有屬性皆具有已定義的有效值）。

IShape.getRawFrame() 方法回傳 IShapeFrame 實例，其每個屬性皆可為未定義值（特別是 FlipH 或 FlipV 可能為 NullableBool.NotDefined）。