---
title: Aspose.Slides for Java 14.7.0 的公共 API 及不相容的向後變更
linktitle: Aspose.Slides for Java 14.7.0
type: docs
weight: 60
url: /zh-hant/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-7-0/
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
description: "檢視 Aspose.Slides for Java 的公共 API 更新與重大變更，順利遷移您的 PowerPoint PPT、PPTX 與 ODP 簡報解決方案。"
---
{{% alert color="primary" %}} 

此頁面列出所有[已新增](/slides/zh-hant/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-7-0/)的類別、方法、屬性等，以及在 Aspose.Slides for Java 14.7.0 API 中引入的任何新限制和其他變更。

{{% /alert %}} 
## **公共 API 變更**
### **已移除某些 TransitionValueBase 子類型的建構函式，且已移除 TransitionValueFactory**
某些 TransitionValueBase 子類型的建構函式（具體包括 CornerDirectionTransition、EightDirectionTransition、EmptyTransition、InOutTransition、OptionalBlackTransition、OrientationTransition、SideDirectionTransition、SplitTransition、WheelTransition）在公共 API 中已無用，因而被移除。相關類別 TransitionValueFactory 及其介面 ITransitionValueFactory 基於相同原因亦被移除。
### **已從 com.aspose.slides.TransitionType 列舉中移除元素 SoundAction**
元素 SoundAction 不正確且未被使用。音效設置由 SlideShowTransition.SoundMode、.Sound、.SoundLoop、.SoundIsBuiltIn、.SoundName 屬性定義。
### **已新增 FlyThroughTransition 類別和 IFlyThroughTransition 介面**
com.aspose.slides.FlyThroughTransition 類別（及其介面 com.aspose.slides.IFlyThroughTransition）與本次發行支援的過場類型 Flythrough 相關。
### **已新增 GlitterTransition 類別、IGlitterTransition 介面以及 TransitionPattern 列舉**
com.aspose.slides.Glit terTransition 類別（及其介面 com.aspose.slides.IGlitterTransition）與本次發行支援的過場類型 Glitter 相關。com.aspose.slides.TransitionPattern 列舉在此類別中使用，指定可平鋪以填滿較大區域的幾何圖案。
### **已新增 LeftRightDirectionTransition 類別、ILeftRightDirectionTransition 介面以及 TransitionLeftRightDirectionType 列舉**
com.aspose.slides.LeftRightDirectionTransition 類別（及其介面 com.aspose.slides.ILeftRightDirectionTransition）與本次發行支援的過場類型 Switch、Flip、Ferris、Gallery、Conveyor 相關。com.aspose.slides.TransitionLeftRightDirectionType 列舉在此類別中使用，指定僅限左或右的方向值。
### **已在 com.aspose.slides.TransitionType 列舉中新增元素**
com.aspose.slides.TransitionType 列舉已加入新元素。與 PowerPoint 2010 新增過場相關的元素包括：Vortex、Switch、Flip、Ripple、Honeycomb、Cube、Box、Rotate、Orbit、Doors、Window、Ferris、Gallery、Conveyor、Pan、Glitter、Warp、Flythrough、Flash、Shred、Reveal、WheelReverse。與 PowerPoint 2013 新增過場相關的元素包括：FallOver、Drape、Curtains、Wind、Prestige、Fracture、Crush、PeelOff、PageCurlDouble、PageCurlSingle、Airplane、Origami。
### **已新增 RevealTransition 類別和 IRevealTransition 介面**
com.aspose.slides.RevealTransition 類別（及其介面 com.aspose.slides.IRevealTransition）與本次發行支援的過場類型 Reveal 相關。
已新增 RippleTransition 類別、IRippleTransition 介面以及 TransitionCornerAndCenterDirectionType 列舉。
com.aspose.slides.RippleTransition 類別（及其介面 com.aspose.slides.IRippleTransition）與本次發行支援的過場類型 Ripple 相關。com.aspose.slides.TransitionCornerAndCenterDirectionType 列舉在此類別中使用，指定僅限於角落與中心的方向。
### **已新增 ShredTransition 類別、IShredTransition 介面以及 TransitionShredPattern 列舉**
com.aspose.slides.ShredTransition 類別（及其介面 com.aspose.slides.IShredTransition）與本次發行支援的過場類型 Shred 相關。com.aspose.slides.TransitionShredPattern 列舉在此類別中使用，指定可平鋪以填滿較大區域的幾何形狀。