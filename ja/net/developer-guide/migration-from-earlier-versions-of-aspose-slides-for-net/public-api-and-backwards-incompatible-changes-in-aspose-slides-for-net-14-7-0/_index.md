---
title: "Aspose.Slides for .NET 14.7.0 のパブリック API と後方互換性がない変更"
linktitle: "Aspose.Slides for .NET 14.7.0"
type: docs
weight: 90
url: /ja/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-7-0/
keywords:
- "移行"
- "レガシーコード"
- "モダンコード"
- "レガシーアプローチ"
- "モダンアプローチ"
- "PowerPoint"
- "OpenDocument"
- "プレゼンテーション"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "Aspose.Slides for .NET のパブリック API の更新と破壊的変更を確認し、PowerPoint の PPT、PPTX、および ODP プレゼンテーション ソリューションをスムーズに移行できるようにします。"
---

{{% alert color="primary" %}} 

このページでは、Aspose.Slides for .NET 14.7.0 API で導入された、追加または削除されたクラス、メソッド、プロパティなどを一覧表示し、その他の変更点を示します。

{{% /alert %}} 
## **パブリック API の変更**
### **削除されたコンストラクタと要素**
#### **一部の TransitionValueBase サブタイプのコンストラクタと TransitionValueFactory の削除**
一部の TransitionValueBase サブタイプ（具体的には CornerDirectionTransition、EightDirectionTransition、EmptyTransition、InOutTransition、OptionalBlackTransition、OrientationTransition、SideDirectionTransition、SplitTransition、WheelTransition）のコンストラクタはパブリック API では使用できず、削除されました。

同様の理由で、関連クラス TransitionValueFactory とそのインターフェイス ITransitionValueFactory も削除されました。
#### **Aspose.Slides.SlideShow.TransitionType 列挙体から SoundAction 要素を削除**
SoundAction 要素は誤っており使用されていませんでした。サウンド設定は SlideShowTransition.SoundMode、.Sound、.SoundLoop、.SoundIsBuiltIn、.SoundName プロパティで定義されます。
### **追加されたクラスとインターフェイス**
#### **FlyThroughTransition クラスと IFlyThroughTransition インターフェイスの追加**
Aspose.Slides.SlideShow.FlyThroughTransition クラス（およびそのインターフェイス Aspose.Slides.SlideShow.IFlyThroughTransition）は、本リリースでサポートされる Flythrough トランジション タイプに対応します。
#### **GlitterTransition クラス、IGlitterTransition インターフェイス、および TransitionPattern 列挙体の追加**
Aspose.Slides.SlideShow.GlitterTransition クラス（およびそのインターフェイス Aspose.Slides.SlideShow.IGlitterTransition）は、本リリースでサポートされる Glitter トランジション タイプに対応します。

Aspose.Slides.SlideShow.TransitionPattern 列挙体はこのクラスで使用され、複数の図形をタイル状に配置して広い領域を埋める幾何学的パターンを指定します。
#### **LeftRightDirectionTransition クラス、ILeftRightDirectionTransition インターフェイス、および TransitionLeftRightDirectionType 列挙体の追加**
Aspose.Slides.SlideShow.LeftRightDirectionTransition クラス（およびそのインターフェイス Aspose.Slides.SlideShow.ILeftRightDirectionTransition）は、Conveyor、Ferris、Flip、Gallery、Switch のトランジション タイプに対応します。すべて本リリースでサポートされます。

Aspose.Slides.SlideShow.TransitionLeftRightDirectionType 列挙体はこのクラスで使用され、left と right の値に限定された方向を指定します。
#### **Aspose.Slides.SlideShow.TransitionType 列挙体への新要素の追加**
Aspose.Slides.SlideShow.TransitionType 列挙体に新しい要素が追加されました。

- PowerPoint 2010 のトランジションに関連する新要素: Box、Conveyor、Cube、Doors、Ferris、Flash、Flip、Flythrough、Gallery、Glitter、Honeycomb、Orbit、Pan、Reveal、Ripple、Rotate、Shred、Switch、Vortex、Warp、WheelReverse、Window。
- PowerPoint 2013 の新トランジションに関連する新要素: Airplane、Crush、Curtains、Drape、FallOver、Fracture、Origami、PageCurlDouble、PageCurlSingle、PeelOff、Prestige、Wind。
#### **RevealTransition クラスと IRevealTransition インターフェイスの追加**
Aspose.Slides.SlideShow.RevealTransition クラス（およびそのインターフェイス Aspose.Slides.SlideShow.IRevealTransition）は、本リリースでサポートされる Reveal トランジション タイプに対応します。
#### **RippleTransition クラス、IRippleTransition インターフェイス、および TransitionCornerAndCenterDirectionType 列挙体の追加**
Aspose.Slides.SlideShow.RippleTransition クラス（およびそのインターフェイス Aspose.Slides.SlideShow.IRippleTransition）は、本リリースでサポートされる Ripple トランジション タイプに対応します。

Aspose.Slides.SlideShow.TransitionCornerAndCenterDirectionType 列挙体はこのクラスで使用され、コーナーとセンターに限定された方向を指定します。