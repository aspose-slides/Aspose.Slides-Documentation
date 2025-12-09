---
title: Aspose.Slides for .NET 14.7.0 のパブリック API と後方互換性のない変更
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
description: "Aspose.Slides for .NET のパブリック API の更新と破壊的変更を確認し、PowerPoint の PPT、PPTX、および ODP プレゼンテーション ソリューションを円滑に移行できるようにします。"
---

{{% alert color="primary" %}} 

このページでは、[added](/slides/ja/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-7-0/) または [removed](/slides/ja/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-7-0/) クラス、メソッド、プロパティ等、そして Aspose.Slides for .NET 14.7.0 APIで導入されたその他の変更をすべて一覧表示します。

{{% /alert %}} 
## **パブリック API の変更**
### **削除されたコンストラクタと要素**
#### **一部の TransitionValueBase サブタイプ コンストラクタと TransitionValueFactory の削除**
一部の TransitionValueBase サブタイプ（具体的には CornerDirectionTransition、EightDirectionTransition、EmptyTransition、InOutTransition、OptionalBlackTransition、OrientationTransition、SideDirectionTransition、SplitTransition、WheelTransition）のコンストラクタはパブリック API では無用であるため、削除されました。

同様の理由で、関連クラスの TransitionValueFactory とそのインターフェイス ITransitionValueFactory も削除されました。
#### **Aspose.Slides.SlideShow.TransitionType 列挙体から SoundAction 要素の削除**
SoundAction 要素は不正確で使用されていませんでした。サウンド設定は SlideShowTransition.SoundMode、.Sound、.SoundLoop、.SoundIsBuiltIn、.SoundName プロパティで定義されます。
### **追加されたクラスとインターフェイス**
#### **FlyThroughTransition クラスと IFlyThroughTransition インターフェイスの追加**
Aspose.Slides.SlideShow.FlyThroughTransition クラス（およびそのインターフェイス Aspose.Slides.SlideShow.IFlyThroughTransition）は、本リリースからサポートされる Flythrough トランジションタイプに対応しています。
#### **GlitterTransition クラス、IGlitterTransition インターフェイス、および TransitionPattern 列挙体の追加**
Aspose.Slides.SlideShow.GlitterTransition クラス（およびそのインターフェイス Aspose.Slides.SlideShow.IGlitterTransition）は、本リリースからサポートされる Glitter トランジションタイプに対応しています。

このクラスで使用される Aspose.Slides.SlideShow.TransitionPattern 列挙体は、より大きな領域を埋めるためにタイル状に並ぶ幾何学的パターンを指定します。
#### **LeftRightDirectionTransition クラス、ILeftRightDirectionTransition インターフェイス、および TransitionLeftRightDirectionType 列挙体の追加**
Aspose.Slides.SlideShow.LeftRightDirectionTransition クラス（およびそのインターフェイス Aspose.Slides.SlideShow.ILeftRightDirectionTransition）は、Conveyor、Ferris、Flip、Gallery、Switch のトランジションタイプに対応しています。すべて本リリースからサポートされます。

このクラスで使用される Aspose.Slides.SlideShow.TransitionLeftRightDirectionType 列挙体は、方向を指定し、left と right の値に限定されます。
#### **Aspose.Slides.SlideShow.TransitionType 列挙体への新要素の追加**
Aspose.Slides.SlideShow.TransitionType 列挙体に新しい要素が追加されました。

- PowerPoint 2010 のトランジションに関連する新要素: Box, Conveyor, Cube, Doors, Ferris, Flash, Flip, Flythrough, Gallery, Glitter, Honeycomb, Orbit, Pan, Reveal, Ripple, Rotate, Shred, Switch, Vortex, Warp, WheelReverse, Window.
- PowerPoint 2013 の新しいトランジションに関連する新要素: Airplane, Crush, Curtains, Drape, FallOver, Fracture, Origami, PageCurlDouble, PageCurlSingle, PeelOff, Prestige, Wind.
#### **RevealTransition クラスと IRevealTransition インターフェイスの追加**
Aspose.Slides.SlideShow.RevealTransition クラス（およびそのインターフェイス Aspose.Slides.SlideShow.IRevealTransition）は、本リリースからサポートされる Reveal トランジションタイプに対応しています。
#### **RippleTransition クラス、IRippleTransition インターフェイス、および TransitionCornerAndCenterDirectionType 列挙体の追加**
Aspose.Slides.SlideShow.RippleTransition クラス（およびそのインターフェイス Aspose.Slides.SlideShow.IRippleTransition）は、本リリースからサポートされる Ripple トランジションタイプに対応しています。

このクラスで使用される Aspose.Slides.SlideShow.TransitionCornerAndCenterDirectionType 列挙体は、方向を指定し、コーナーと中心に限定されます。