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
description: "Aspose.Slides for .NET のパブリック API の更新と破壊的変更を確認し、PowerPoint の PPT、PPTX、ODP プレゼンテーション ソリューションをスムーズに移行できるようにします。"
---
{{% alert color="info" %}}

このページでは、追加された[added](/slides/ja/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-7-0/) または 削除された[removed](/slides/ja/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-7-0/) クラス、メソッド、プロパティ等、および Aspose.Slides for .NET 14.7.0 APIで導入されたその他の変更を一覧表示します。

{{% /alert %}} 
## **パブリック API の変更**
### **削除されたコンストラクタと要素**
#### **一部の TransitionValueBase サブタイプのコンストラクタと TransitionValueFactory の削除**
一部の TransitionValueBase サブタイプのコンストラクタ（具体的には CornerDirectionTransition、EightDirectionTransition、EmptyTransition、InOutTransition、OptionalBlackTransition、OrientationTransition、SideDirectionTransition、SplitTransition、WheelTransition）はパブリック API では不要であるため、削除されました。

同様の理由で、関連クラスの TransitionValueFactory とそのインターフェイス ITransitionValueFactory も削除されました。

#### **Aspose.Slides.SlideShow.TransitionType 列挙体から SoundAction 要素の削除**
SoundAction 要素は誤っており使用されていませんでした。サウンド設定は SlideShowTransition.SoundMode、.Sound、.SoundLoop、.SoundIsBuiltIn、.SoundName プロパティで定義されます。

### **追加されたクラスとインターフェイス**
#### **FlyThroughTransition クラス と IFlyThroughTransition インターフェイスの追加**
Aspose.Slides.SlideShow.FlyThroughTransition クラス（およびそのインターフェイス Aspose.Slides.SlideShow.IFlyThroughTransition）は、本リリースでサポートされる Flythrough トランジションタイプに関連しています。

#### **GlitterTransition クラス、IGlitterTransition インターフェイス、TransitionPattern 列挙体の追加**
Aspose.Slides.SlideShow.GlitterTransition クラス（およびそのインターフェイス Aspose.Slides.SlideShow.IGlitterTransition）は、本リリースでサポートされる Glitter トランジションタイプに関連しています。

このクラスで使用される Aspose.Slides.SlideShow.TransitionPattern 列挙体は、より大きな領域を埋めるためにタイル状に配置される幾何学的パターンを指定します。

#### **LeftRightDirectionTransition クラス、ILeftRightDirectionTransition インターフェイス、TransitionLeftRightDirectionType 列挙体の追加**
Aspose.Slides.SlideShow.LeftRightDirectionTransition クラス（およびそのインターフェイス Aspose.Slides.SlideShow.ILeftRightDirectionTransition）は、Conveyor、Ferris、Flip、Gallery、Switch のトランジションタイプに関連しています。すべて本リリースでサポートされます。

このクラスで使用される Aspose.Slides.SlideShow.TransitionLeftRightDirectionType 列挙体は、方向を指定し、left と right のみが有効です。

#### **Aspose.Slides.SlideShow.TransitionType 列挙体への新要素の追加**
Aspose.Slides.SlideShow.TransitionType 列挙体に新しい要素が追加されました。

- PowerPoint 2010 のトランジションに関連する新要素: Box, Conveyor, Cube, Doors, Ferris, Flash, Flip, Flythrough, Gallery, Glitter, Honeycomb, Orbit, Pan, Reveal, Ripple, Rotate, Shred, Switch, Vortex, Warp, WheelReverse, Window.
- PowerPoint 2013 の新しいトランジションに関連する新要素: Airplane, Crush, Curtains, Drape, FallOver, Fracture, Origami, PageCurlDouble, PageCurlSingle, PeelOff, Prestige, Wind.

#### **RevealTransition クラス と IRevealTransition インターフェイスの追加**
Aspose.Slides.SlideShow.RevealTransition クラス（およびそのインターフェイス Aspose.Slides.SlideShow.IRevealTransition）は、本リリースでサポートされる Reveal トランジションタイプに関連しています。

#### **RippleTransition クラス、IRippleTransition インターフェイス、TransitionCornerAndCenterDirectionType 列挙体の追加**
Aspose.Slides.SlideShow.RippleTransition クラス（およびそのインターフェイス Aspose.Slides.SlideShow.IRippleTransition）は、本リリースでサポートされる Ripple トランジションタイプに関連しています。

このクラスで使用される Aspose.Slides.SlideShow.TransitionCornerAndCenterDirectionType 列挙体は、方向を指定し、コーナーとセンターに限定されます。