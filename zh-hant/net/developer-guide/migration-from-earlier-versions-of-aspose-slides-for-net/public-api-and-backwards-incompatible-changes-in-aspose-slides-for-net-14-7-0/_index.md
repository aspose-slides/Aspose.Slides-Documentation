---
title: "Aspose.Slides for .NET 14.7.0 的公開 API 以及向後相容性破壞變更"
linktitle: "Aspose.Slides for .NET 14.7.0"
type: docs
weight: 90
url: /zh-hant/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-7-0/
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
description: "檢視 Aspose.Slides for .NET 的公開 API 更新與破壞性變更，順利遷移您的 PowerPoint PPT、PPTX 與 ODP 簡報解決方案。"
---
{{% alert color="primary" %}} 

此頁面列出所有 [已新增](/slides/zh-hant/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-7-0/) 或 [已移除](/slides/zh-hant/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-7-0/) 類別、方法、屬性等，以及其他隨 Aspose.Slides for .NET 14.7.0 API 所引入的變更。

{{% /alert %}} 
## **公開 API 變更**
### **已移除的建構函式與元素**
#### **已移除部分 TransitionValueBase 子類別建構函式以及 TransitionValueFactory**
某些 TransitionValueBase 子類別的建構函式（具體而言，包括 CornerDirectionTransition、EightDirectionTransition、EmptyTransition、InOutTransition、OptionalBlackTransition、OrientationTransition、SideDirectionTransition、SplitTransition、WheelTransition）在公開 API 中無用，因此已被移除。 

相關的類別 TransitionValueFactory 及其介面 ITransitionValueFactory 亦因同樣原因被移除。 
#### **已從 Aspose.Slides.SlideShow.TransitionType 列舉中移除 SoundAction 元素**
SoundAction 元素不正確且未被使用。聲音設定由 SlideShowTransition.SoundMode、.Sound、.SoundLoop、.SoundIsBuiltIn、.SoundName 屬性定義。 
### **已新增的類別與介面**
#### **新增 FlyThroughTransition 類別與 IFlyThroughTransition 介面**
Aspose.Slides.SlideShow.FlyThroughTransition 類別（以及其介面 Aspose.Slides.SlideShow.IFlyThroughTransition）與此版本支援的 Flythrough 轉場類型相關。 
#### **新增 GlitterTransition 類別、IGlitterTransition 介面與 TransitionPattern 列舉**
Aspose.Slides.SlideShow.GlitterTransition 類別（以及其介面 Aspose.Slides.SlideShow.IGlitterTransition）與此版本支援的 Glitter 轉場類型相關。 

此類別使用 Aspose.Slides.SlideShow.TransitionPattern 列舉，該列舉指定可拼貼成較大區域的幾何圖案。 
#### **新增 LeftRightDirectionTransition 類別、ILeftRightDirectionTransition 介面與 TransitionLeftRightDirectionType 列舉**
Aspose.Slides.SlideShow.LeftRightDirectionTransition 類別（以及其介面 Aspose.Slides.SlideShow.ILeftRightDirectionTransition）與轉場類型 Conveyor、Ferris、Flip、Gallery 與 Switch 相關。以上全部自此版本起支援。 

此類別使用 Aspose.Slides.SlideShow.TransitionLeftRightDirectionType 列舉，該列舉指定方向，僅限 left 與 right 兩個值。 
#### **在 Aspose.Slides.SlideShow.TransitionType 列舉中新增元素**
Aspose.Slides.SlideShow.TransitionType 列舉已擴充新元素。 

- 與 PowerPoint 2010 轉場相關的新元素：Box、Conveyor、Cube、Doors、Ferris、Flash、Flip、Flythrough、Gallery、Glitter、Honeycomb、Orbit、Pan、Reveal、Ripple、Rotate、Shred、Switch、Vortex、Warp、WheelReverse、Window。 
- 與新版 PowerPoint 2013 轉場相關的新元素：Airplane、Crush、Curtains、Drape、FallOver、Fracture、Origami、PageCurlDouble、PageCurlSingle、PeelOff、Prestige、Wind。 
#### **新增 RevealTransition 類別與 IRevealTransition 介面**
Aspose.Slides.SlideShow.RevealTransition 類別（以及其介面 Aspose.Slides.SlideShow.IRevealTransition）與此版本支援的 Reveal 轉場類型相關。 
#### **新增 RippleTransition 類別、IRippleTransition 介面與 TransitionCornerAndCenterDirectionType 列舉**
Aspose.Slides.SlideShow.RippleTransition 類別（以及其介面 Aspose.Slides.SlideShow.IRippleTransition）與此版本支援的 Ripple 轉場類型相關。 

此類別使用 Aspose.Slides.SlideShow.TransitionCornerAndCenterDirectionType 列舉，該列舉指定方向，限於四角與中心。