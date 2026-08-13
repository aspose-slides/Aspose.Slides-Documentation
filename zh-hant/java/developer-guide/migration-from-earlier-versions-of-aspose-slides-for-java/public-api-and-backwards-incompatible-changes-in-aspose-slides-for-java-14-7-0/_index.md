---
title: Aspose.Slides for Java 14.7.0 的公共 API 與向後不相容的變更
linktitle: Aspose.Slides for Java 14.7.0
type: docs
weight: 60
url: /zh-hant/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-7-0/
keywords:
- 移植
- 傳統程式碼
- 現代程式碼
- 傳統方法
- 現代方法
- PowerPoint
- OpenDocument
- 簡報
- Java
- Aspose.Slides
description: "檢視 Aspose.Slides for Java 的公共 API 更新與重大變更，協助您順利遷移 PowerPoint PPT、PPTX 與 ODP 簡報解決方案。"
---
{{% alert color="info" %}} 

此頁面列出所有[added](/slides/zh-hant/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-7-0/)類別、方法、屬性等，以及隨 Aspose.Slides for Java 14.7.0 API 所引入的任何新限制與其他變更。

{{% /alert %}} 
## **公共 API 變更**
### **已移除部分 TransitionValueBase 子類型的建構函式，且已移除 TransitionValueFactory**
某些 TransitionValueBase 子類型的建構函式（特別是 CornerDirectionTransition、EightDirectionTransition、EmptyTransition、InOutTransition、OptionalBlackTransition、OrientationTransition、SideDirectionTransition、SplitTransition、WheelTransition）在公共 API 中已無效用，故已被移除。相關類別 TransitionValueFactory 及其介面 ITransitionValueFactory 亦因同樣原因被移除。
### **已從 com.aspose.slides.TransitionType 列舉中移除元素 SoundAction**
SoundAction 元素不正確且未被使用。聲音設定由 SlideShowTransition.SoundMode、.Sound、.SoundLoop、.SoundIsBuiltIn、.SoundName 屬性定義。
### **已加入 FlyThroughTransition 類別和 IFlyThroughTransition 介面**
com.aspose.slides.FlyThroughTransition 類別（以及其介面 com.aspose.slides.IFlyThroughTransition）與此發行版支援的 Flythrough 轉場類型相關。
### **已加入 GlitterTransition 類別、IGlitterTransition 介面與 TransitionPattern 列舉**
com.aspose.slides.GlitterTransition 類別（以及其介面 com.aspose.slides.IGlitterTransition）與此發行版支援的 Glitter 轉場類型相關。com.aspose.slides.TransitionPattern 列舉在此類別中使用，指定用於填滿更大區域的幾何圖案。
### **已加入 LeftRightDirectionTransition 類別、ILeftRightDirectionTransition 介面與 TransitionLeftRightDirectionType 列舉**
com.aspose.slides.LeftRightDirectionTransition 類別（以及其介面 com.aspose.slides.ILeftRightDirectionTransition）與此發行版支援的 Switch、Flip、Ferris、Gallery、Conveyor 轉場類型相關。com.aspose.slides.TransitionLeftRightDirectionType 列舉在此類別中使用，指定僅限 left 與 right 兩個方向的值。
### **已在 com.aspose.slides.TransitionType 列舉中加入新元素**
com.aspose.slides.TransitionType 列舉已擴充新元素。與 PowerPoint 2010 新轉場相關的元素有：Vortex、Switch、Flip、Ripple、Honeycomb、Cube、Box、Rotate、Orbit、Doors、Window、Ferris、Gallery、Conveyor、Pan、Glitter、Warp、Flythrough、Flash、Shred、Reveal、WheelReverse。與 PowerPoint 2013 新轉場相關的元素有：FallOver、Drape、Curtains、Wind、Prestige、Fracture、Crush、PeelOff、PageCurlDouble、PageCurlSingle、Airplane、Origami。
### **已加入 RevealTransition 類別與 IRevealTransition 介面**
com.aspose.slides.RevealTransition 類別（以及其介面 com.aspose.slides.IRevealTransition）與此發行版支援的 Reveal 轉場類型相關。RippleTransition 類別、IRippleTransition 介面與 TransitionCornerAndCenterDirectionType 列舉已加入。com.aspose.slides.RippleTransition 類別（以及其介面 com.aspose.slides.IRippleTransition）與此發行版支援的 Ripple 轉場類型相關。com.aspose.slides.TransitionCornerAndCenterDirectionType 列舉在此類別中使用，指定僅限於角落與中心的方向。
### **已加入 ShredTransition 類別、IShredTransition 介面與 TransitionShredPattern 列舉**
com.aspose.slides.ShredTransition 類別（以及其介面 com.aspose.slides.IShredTransition）與此發行版支援的 Shred 轉場類型相關。com.aspose.slides.TransitionShredPattern 列舉在此類別中使用，指定用於填滿更大區域的幾何形狀。