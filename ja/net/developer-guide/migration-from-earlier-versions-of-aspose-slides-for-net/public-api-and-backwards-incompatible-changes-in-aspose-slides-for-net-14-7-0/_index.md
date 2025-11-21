---
title: Aspose.Slides for .NET 14.7.0 のパブリック API と下位互換性のない変更
linktitle: Aspose.Slides for .NET 14.7.0
type: docs
weight: 90
url: /ja/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-7-0/
keywords:
- 移行
- レガシーコード
- モダンコード
- レガシーアプローチ
- モダンアプローチ
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET のパブリック API の更新と破壊的変更を確認し、PowerPoint PPT、PPTX、ODP プレゼンテーション ソリューションをスムーズに移行しましょう。"
---

{{% alert color="primary" %}} 

このページでは、Aspose.Slides for .NET 14.7.0 APIで導入された、[added](/slides/ja/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-7-0/) または [removed](/slides/ja/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-7-0/) クラス、メソッド、プロパティなどをすべて一覧表示します。

{{% /alert %}} 
## **Public API Changes**
### **Removed Constructors and Elements**
#### **Removed Some TransitionValueBase Subtype Constructors and TransitionValueFactory**
いくつかの TransitionValueBase サブタイプ（具体的には CornerDirectionTransition、EightDirectionTransition、EmptyTransition、InOutTransition、OptionalBlackTransition、OrientationTransition、SideDirectionTransition、SplitTransition、WheelTransition）のコンストラクターはパブリック API では不要であるため削除されました。

同様の理由で、関連クラスの TransitionValueFactory とそのインターフェイス ITransitionValueFactory も削除されました。

#### **Removed the SoundAction Element from the Aspose.Slides.SlideShow.TransitionType Enumeration**
SoundAction 要素は誤っており使用されていませんでした。サウンド設定は SlideShowTransition.SoundMode、.Sound、.SoundLoop、.SoundIsBuiltIn、.SoundName プロパティで定義されます。

### **Added Classes and Interfaces**
#### **Added the FlyThroughTransition Class and IFlyThroughTransition Interface**
Aspose.Slides.SlideShow.FlyThroughTransition クラス（およびそのインターフェイス Aspose.Slides.SlideShow.IFlyThroughTransition）は、本リリースでサポートされる Flythrough 遷移タイプに対応します。

#### **Added the GlitterTransition Class, IGlitterTransition Interface and TransitionPattern Enumeration**
Aspose.Slides.SlideShow.GlitterTransition クラス（およびそのインターフェイス Aspose.Slides.SlideShow.IGlitterTransition）は、本リリースでサポートされる Glitter 遷移タイプに対応します。

Aspose.Slides.SlideShow.TransitionPattern 列挙体はこのクラスで使用され、より大きな領域を埋めるためにタイル状に配置される幾何学パターンを指定します。

#### **Added the LeftRightDirectionTransition Class, ILeftRightDirectionTransition Interface and TransitionLeftRightDirectionType Enumeration**
Aspose.Slides.SlideShow.LeftRightDirectionTransition クラス（およびそのインターフェイス Aspose.Slides.SlideShow.ILeftRightDirectionTransition）は、Conveyor、Ferris、Flip、Gallery、Switch の遷移タイプに対応します。すべて本リリースでサポートされます。

Aspose.Slides.SlideShow.TransitionLeftRightDirectionType 列挙体はこのクラスで使用され、left と right の値に限定された方向を指定します。

#### **Added New Elements to the Aspose.Slides.SlideShow.TransitionType Enumeration**
Aspose.Slides.SlideShow.TransitionType 列挙体に新しい要素が追加されました。

- PowerPoint 2010 の遷移に関連する新要素: Box、Conveyor、Cube、Doors、Ferris、Flash、Flip、Flythrough、Gallery、Glitter、Honeycomb、Orbit、Pan、Reveal、Ripple、Rotate、Shred、Switch、Vortex、Warp、WheelReverse、Window。
- PowerPoint 2013 の新遷移に関連する新要素: Airplane、Crush、Curtains、Drape、FallOver、Fracture、Origami、PageCurlDouble、PageCurlSingle、PeelOff、Prestige、Wind。

#### **Added the RevealTransition Class and IRevealTransition Interface**
Aspose.Slides.SlideShow.RevealTransition クラス（およびそのインターフェイス Aspose.Slides.SlideShow.IRevealTransition）は、本リリースでサポートされる Reveal 遷移タイプに対応します。

#### **Added the RippleTransition class, IRippleTransition Interface and TransitionCornerAndCenterDirectionType Enumeration**
Aspose.Slides.SlideShow.RippleTransition クラス（およびそのインターフェイス Aspose.Slides.SlideShow.IRippleTransition）は、本リリースでサポートされる Ripple 遷移タイプに対応します。

Aspose.Slides.SlideShow.TransitionCornerAndCenterDirectionType 列挙体はこのクラスで使用され、コーナーとセンターに限定された方向を指定します。