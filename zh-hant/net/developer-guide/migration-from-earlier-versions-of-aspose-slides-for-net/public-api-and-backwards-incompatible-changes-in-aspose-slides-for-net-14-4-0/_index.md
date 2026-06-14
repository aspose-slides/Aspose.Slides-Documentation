---
title: Aspose.Slides for .NET 14.4.0 的公共 API 與向後相容性破壞變更
linktitle: Aspose.Slides for .NET 14.4.0
type: docs
weight: 60
url: /zh-hant/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-4-0/
keywords:
- 遷移
- 傳統程式碼
- 現代程式碼
- 傳統方法
- 現代方法
- PowerPoint
- OpenDocument
- 簡報
- .NET
- C#
- Aspose.Slides
description: "檢視 Aspose.Slides for .NET 的公共 API 更新與相容性破壞變更，以順利遷移您的 PowerPoint PPT、PPTX 與 ODP 簡報解決方案。"
---
## **公共 API 與向後相容性破壞的變更**
### **新增的介面、類別、方法與屬性**
#### **已新增 Aspose.Slides.ILayoutSlide.HasDependingSlides 屬性**
屬性 Aspose.Slides.ILayoutSlide.HasDependingSlides 如果存在至少一張投影片依賴此版面投影片，則傳回 true。例如：

``` csharp

 ILayoutSlide layout = ...;

if (!layout.HasDependingSlides)

    layout.Remove();

``` 
#### **Aspose.Slides.ILayoutSlide.Remove() 方法**
方法 Aspose.Slides.ILayoutSlide.Remove() 允許您以最少的程式碼從簡報中移除版面。例如：

``` csharp

 ILayoutSlide layout = ...;

if (!layout.HasDependingSlides)

    layout.Remove();

``` 
#### **Aspose.Slides.ILayoutSlideCollection.Remove(ILayoutSlide) 方法**
方法 Aspose.Slides.ILayoutSlideCollection.Remove(ILayoutSlide) 允許您從集合中移除版面。程式碼範例：

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
方法 Aspose.Slides.ILayoutSlideCollection.RemoveUnused() 允許您移除未使用的版面投影片（HasDependingSlides 為 false 的版面投影片）。程式碼範例：

``` csharp

 presentation.LayoutSlides.RemoveUnused();

``` 

或

``` csharp

 IMasterSlide masterSlide = ...;

masterSlide.LayoutSlides.RemoveUnused();

``` 
#### **Aspose.Slides.IMasterSlide.HasDependingSlides 屬性**
屬性 Aspose.Slides.IMasterSlide.HasDependingSlides 如果存在至少一張投影片依賴此母片，則傳回 true。例如：

``` csharp

 IMasterSlide masterSlide = ...;

if (!masterSlide.HasDependingSlides)

    presentation.Masters.Remove(masterSlide);

``` 
#### **Aspose.Slides.ISlide.Remove() 方法**
方法 Aspose.Slides.ISlide.Remove() 允許您以最少的程式碼從簡報中移除投影片。例如：

``` csharp

 ISlide slide = ...;

slide.Remove();

``` 
#### **Aspose.Slides.SmartArt.ISmartArtNode.BulletFillFormat**
屬性 Aspose.Slides.SmartArt.ISmartArtNode.BulletFillFormat 在版面提供項目符號時，傳回 SmartArt 節點項目符號的 IFillFormat。可用於設定項目符號圖像。

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-SmartArts-BulletFillFormat-BulletFillFormat.cs" >}}
#### **Aspose.Slides.SmartArt.ISmartArtNode.Level 屬性**
屬性 Aspose.Slides.SmartArt.ISmartArtNode.Level 傳回 SmartArt 節點的巢狀層級。

``` csharp

 ISmartArtNode node = diagram.AllNodes[0];

if(node.Level == 1)

    node.TextFrame.Text = "First level";

``` 
#### **Aspose.Slides.SmartArt.ISmartArtNode.Position 屬性**
屬性 Aspose.Slides.SmartArt.ISmartArtNode.Position 傳回節點在同層兄弟節點中的位置。

``` csharp

 ISmartArtNode node = diagram.AllNodes[0];

if (node.ChildNodes.Count > 3)

    node.ChildNodes[0].Position++;

``` 
#### **已新增 Aspose.Slides.SmartArt.ISmartArtNode.Remove() 方法**
Aspose.Slides.SmartArt.ISmartArtNode.Remove() 方法允許從圖表中移除節點。

``` csharp

 ISmartArt node = diagram.AllNodes[0];

node.Remove();

``` 
#### **IGlobalLayoutSlideCollection 介面與 GlobalLayoutSlideCollection 類別**
已在 Aspose.Slides 命名空間中加入 IGlobalLayoutSlideCollection 介面與 GlobalLayoutSlideCollection 類別。

GlobalLayoutSlideCollection 類別實作 IGlobalLayoutSlideCollection 介面。

IGlobalLayoutSlideCollection 介面代表簡報中所有版面投影片的集合。IPresentation.LayoutSlides 屬性的型別為 IGlobalLayoutSlideCollection。IGlobalLayoutSlideCollection 繼承 ILayoutSlideCollection，並在合併各母片版面投影片的個別集合時，提供加入與複製版面投影片的方法：

- ILayoutSlide AddClone(ILayoutSlide sourceLayout); – 可用於將指定版面投影片的副本加入簡報。此方法保留來源格式（在不同簡報之間複製版面時，亦可複製版面的母片。內部登錄表用於自動追蹤已複製的母片，以防止同一母片被多次複製）。
- ILayoutSlide AddClone(ILayoutSlide sourceLayout, IMasterSlide destMaster); – 用於將指定版面投影片的副本加入簡報。新版面將連結至目標簡報中指定的母片。此選項相當於在 Microsoft PowerPoint 中使用 **使用目標佈景主題** 之複製或貼上。
- ILayoutSlide Add(IMasterSlide master, SlideLayoutType layoutType, string layoutName); – 用於在簡報中加入新的版面投影片。支援的版面類型：Title、TitleOnly、Blank、TitleAndObject、VerticalText、VerticalTitleAndText、TwoObjects、SectionHeader、TwoTextAndTwoObjects、TitleObjectAndCaption、PictureAndCaption、Custom。版面名稱可自動產生。類型為 SlideLayoutType.Custom 的版面不包含任何佔位符與圖形。此方法的類似功能可透過 IMasterSlide.LayoutSlides 屬性中的 IMasterLayoutSlideCollection.Add(SlideLayoutType, string) 方法取得。

#### **介面 IMasterLayoutSlideCollection 與類別 MasterLayoutSlideCollection**
已在 Aspose.Slides 命名空間中加入 IMasterLayoutSlideCollection 介面與 MasterLayoutSlideCollection 類別。MasterLayoutSlideCollection 類別實作 IMasterLayoutSlideCollection 介面。

IMasterLayoutSlideCollection 介面代表已定義母片的所有版面投影片集合。它繼承 ILayoutSlideCollection，並在個別母片版面投影片集合的情境下，提供加入、插入、移除或複製版面投影片的方法：

``` csharp

 // 方法簽章：

ILayoutSlide AddClone(ILayoutSlide sourceLayout);

// 示範程式碼：將 sourceLayout 的副本附加至 destMasterSlide：

IMasterSlide destMasterSlide = ...;

destMasterSlide.LayoutSlides.AddClone(sourceLayout);

``` 

此方法可用於將指定版面投影片的副本加入集合的末端。新版面將連結至此版面投影片集合所屬的母片，等同於在 PowerPoint 中使用 **使用目標佈景主題** 的複製或貼上。此方法與 IGlobalLayoutSlideCollection.AddClone(ILayoutSlide, IMasterSlide)（透過 IPresentation.LayoutSlides 屬性存取）類似。

- ILayoutSlide InsertClone(int index, ILayoutSlide sourceLayout); – 用於將指定版面投影片的副本插入至集合的指定位置。新版面將連結至此版面投影片集合所屬的母片，等同於在 PowerPoint 中使用 **使用目標佈景主題** 的複製與貼上。
- ILayoutSlide Add(SlideLayoutType layoutType, string layoutName);
- ILayoutSlide Insert(int index, SlideLayoutType layoutType, string layoutName); – 用於加入或插入新的版面投影片。支援的版面類型：Title、TitleOnly、Blank、TitleAndObject、VerticalText、VerticalTitleAndText、TwoObjects、SectionHeader、TwoTextAndTwoObjects、TitleObjectAndCaption、PictureAndCaption、Custom。版面名稱可自動產生。類型為 SlideLayoutType.Custom 的版面不包含任何佔位符與圖形。此方法的類似功能可透過 IPresentation.LayoutSlides 屬性存取的 IGlobalLayoutSlideCollection.Add(IMasterSlide, SlideLayoutType, string) 方法取得。
- void RemoveAt(int index); – 用於移除集合中指定索引處的版面。
- void Reorder(int index, ILayoutSlide layoutSlide); – 用於將版面投影片在集合中移動至指定位置。

### **已變更的方法與屬性**
#### **Aspose.Slides.ISlideCollection.AddClone(ISlide, IMasterSlide) 方法的簽章**
ISlideCollection 方法的簽章：
ISlide AddClone(ISlide sourceSlide, IMasterSlide destMaster);
已過時，取代為以下簽章：

ISlide AddClone(ISlide sourceSlide, IMasterSlide destMaster, bool allowCloneMissingLayout)

allowCloneMissingLayout 參數指定當 destMaster 中沒有適當的版面供新（已複製）投影片使用時的處理方式。適當的版面指的是與來源投影片版面類型或名稱相同的版面。若指定的母片中沒有適當的版面，則會根據 allowCloneMissingLayout 的值：為 true 時會複製來源投影片的版面，為 false 時會拋出 PptxEditException。

呼叫已過時的方法，例如：

AddClone(sourceSlide, destMaster);

等同於 allowCloneMissingLayout 為 false（即若沒有適當版面則拋出 PptxEditException）。使用新簽章的等效呼叫如下：

AddClone(sourceSlide, destMaster, false);

若希望在缺少版面時自動複製而不是拋出 PptxEditException，請將 allowCloneMissingLayout 參數設為 true。

相同情況亦適用於 ISlideCollection 方法：

ISlide InsertClone(int index, ISlide sourceSlide, IMasterSlide destMaster);

已過時，取代為：

ISlide InsertClone(int index, ISlide sourceSlide, IMasterSlide destMaster, bool allowCloneMissingLayout);

#### **Aspose.Slides.IMasterSlide.LayoutSlides 屬性的型別**
Aspose.Slides.IMasterSlide.LayoutSlides 屬性的型別已從 ILayoutSlideCollection 更改為新的 IMasterLayoutSlideCollection 介面。IMasterLayoutSlideCollection 繼承自 ILayoutSlideCollection，現有程式碼無需調整。

#### **Aspose.Slides.IPresentation.LayoutSlides 屬性的型別已變更**
Aspose.Slides.IPresentation.LayoutSlides 屬性的型別已從 ILayoutSlideCollection 更改為新的 IGlobalLayoutSlideCollection 介面。IGlobalLayoutSlideCollection 繼承自 ILayoutSlideCollection，現有程式碼無需調整。