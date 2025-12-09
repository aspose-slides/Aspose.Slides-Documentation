---
title: Aspose.Slides for .NET 14.7.0 の公開 API と下位互換性のない変更
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
description: "Aspose.Slides for .NET の公開 API の更新と破壊的変更を確認し、PowerPoint PPT、PPTX、ODP のプレゼンテーション ソリューションをスムーズに移行できるようにします。"
---

{{% alert color="primary" %}} 

このページでは、Aspose.Slides for .NET 14.7.0 API で導入された、追加された[added](/slides/ja/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-7-0/)または削除された[removed](/slides/ja/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-7-0/)クラス、メソッド、プロパティ等、およびその他の変更を一覧します。

{{% /alert %}} 
## **パブリック API の変更**
### **削除されたコンストラクタと要素**
#### **いくつかの TransitionValueBase サブタイプ コンストラクタおよび TransitionValueFactory の削除**
一部の TransitionValueBase サブタイプ（具体的には CornerDirectionTransition、EightDirectionTransition、EmptyTransition、InOutTransition、OptionalBlackTransition、OrientationTransition、SideDirectionTransition、SplitTransition、WheelTransition）のコンストラクタはパブリック API では無意味であるため削除されました。

同様の理由で、関連クラス TransitionValueFactory とそのインターフェイス ITransitionValueFactory も削除されました。
#### **Aspose.Slides.SlideShow.TransitionType 列挙型から SoundAction 要素の削除**
SoundAction 要素は誤っており使用されていませんでした。サウンド設定は SlideShowTransition.SoundMode、.Sound、.SoundLoop、.SoundIsBuiltIn、.SoundName プロパティで定義されます。
### **追加されたクラスとインターフェイス**
#### **FlyThroughTransition クラスおよび IFlyThroughTransition インターフェイスの追加**
Aspose.Slides.SlideShow.FlyThroughTransition クラス（およびインターフェイス Aspose.Slides.SlideShow.IFlyThroughTransition）は、本リリースでサポートされる Flythrough トランジションタイプに対応します。
#### **GlitterTransition クラス、IGlitterTransition インターフェイス、および TransitionPattern 列挙型の追加**
Aspose.Slides.SlideShow.GlitterTransition クラス（およびインターフェイス Aspose.Slides.SlideShow.IGlitterTransition）は、本リリースでサポートされる Glitter トランジションタイプに対応します。

Aspose.Slides.SlideShow.TransitionPattern 列挙型はこのクラスで使用され、より大きな領域を埋めるためにタイル状に配置される幾何学的パターンを指定します。
#### **LeftRightDirectionTransition クラス、ILeftRightDirectionTransition インターフェイス、および TransitionLeftRightDirectionType 列挙型の追加**
Aspose.Slides.SlideShow.LeftRightDirectionTransition クラス（およびインターフェイス Aspose.Slides.SlideShow.ILeftRightDirectionTransition）は、Conveyor、Ferris、Flip、Gallery、Switch のトランジションタイプに対応します。すべて本リリースでサポートされます。

Aspose.Slides.SlideShow.TransitionLeftRightDirectionType 列挙型はこのクラスで使用され、left と right に限定された方向を指定します。
#### **Aspose.Slides.SlideShow.TransitionType 列挙型への新要素の追加**
Aspose.Slides.SlideShow.TransitionType 列挙型に新しい要素が追加されました。

- PowerPoint 2010 のトランジションに関連する新要素: Box, Conveyor, Cube, Doors, Ferris, Flash, Flip, Flythrough, Gallery, Glitter, Honeycomb, Orbit, Pan, Reveal, Ripple, Rotate, Shred, Switch, Vortex, Warp, WheelReverse, Window.
- PowerPoint 2013 の新トランジションに関連する新要素: Airplane, Crush, Curtains, Drape, FallOver, Fracture, Origami, PageCurlDouble, PageCurlSingle, PeelOff, Prestige, Wind.
#### **RevealTransition クラスおよび IRevealTransition インターフェイスの追加**
Aspose.Slides.SlideShow.RevealTransition クラス（およびインターフェイス Aspose.Slides.SlideShow.IRevealTransition）は、本リリースでサポートされる Reveal トランジションタイプに対応します。
#### **RippleTransition クラス、IRippleTransition インターフェイス、および TransitionCornerAndCenterDirectionType 列挙型の追加**
Aspose.Slides.SlideShow.RippleTransition クラス（およびインターフェイス Aspose.Slides.SlideShow.IRippleTransition）は、本リリースでサポートされる Ripple トランジションタイプに対応します。

Aspose.Slides.SlideShow.TransitionCornerAndCenterDirectionType 列挙型はこのクラスで使用され、コーナーと中心に限定された方向を指定します。