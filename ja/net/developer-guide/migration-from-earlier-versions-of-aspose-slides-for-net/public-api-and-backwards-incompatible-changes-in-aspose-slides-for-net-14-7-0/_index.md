---
title: .NET 14.7.0 における Aspose.Slides の公開 API および後方互換性のない変更
type: docs
weight: 90
url: /ja/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-7-0/
---

{{% alert color="primary" %}} 

このページでは、Aspose.Slides for .NET 14.7.0 API に導入されたすべての [追加された](/slides/ja/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-7-0/) または [削除された](/slides/ja/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-7-0/) クラス、メソッド、プロパティなど、およびその他の変更を一覧表示します。

{{% /alert %}} 
## **公開 API 変更**
### **削除されたコンストラクターと要素**
#### **いくつかの TransitionValueBase サブタイプのコンストラクターと TransitionValueFactory の削除**
いくつかの TransitionValueBase サブタイプ（具体的には CornerDirectionTransition、EightDirectionTransition、EmptyTransition、InOutTransition、OptionalBlackTransition、OrientationTransition、SideDirectionTransition、SplitTransition、WheelTransition）のコンストラクターは公開 API では無用であるため削除されました。

関連するクラス TransitionValueFactory とそのインターフェース ITransitionValueFactory も同様の理由で削除されました。
#### **Aspose.Slides.SlideShow.TransitionType 列挙体から SoundAction 要素の削除**
SoundAction 要素は不正確であり使用されていませんでした。音の設定は SlideShowTransition.SoundMode、.Sound、.SoundLoop、.SoundIsBuiltIn、.SoundName プロパティによって定義されています。
### **追加されたクラスとインターフェース**
#### **FlyThroughTransition クラスと IFlyThroughTransition インターフェースの追加**
Aspose.Slides.SlideShow.FlyThroughTransition クラス（およびそのインターフェース Aspose.Slides.SlideShow.IFlyThroughTransition）は、このリリースからサポートされる Flythrough トランジションタイプに関連しています。
#### **GlitterTransition クラス、IGlitterTransition インターフェース、および TransitionPattern 列挙体の追加**
Aspose.Slides.SlideShow.GlitterTransition クラス（およびそのインターフェース Aspose.Slides.SlideShow.IGlitterTransition）は、このリリースからサポートされる Glitter トランジションタイプに関連しています。

Aspose.Slides.SlideShow.TransitionPattern 列挙体はこのクラスで使用され、より大きな面積を埋めるためにタイル状に一緒に並べられる幾何学的パターンを指定します。
#### **LeftRightDirectionTransition クラス、ILeftRightDirectionTransition インターフェース、および TransitionLeftRightDirectionType 列挙体の追加**
Aspose.Slides.SlideShow.LeftRightDirectionTransition クラス（およびそのインターフェース Aspose.Slides.SlideShow.ILeftRightDirectionTransition）は、Conveyor、Ferris、Flip、Gallery、Switch のトランジションタイプに関連しています。すべて、このリリースからサポートされています。

Aspose.Slides.SlideShow.TransitionLeftRightDirectionType 列挙体はこのクラスで使用され、左と右の値に限定された方向を指定します。
#### **Aspose.Slides.SlideShow.TransitionType 列挙体への新しい要素の追加**
Aspose.Slides.SlideShow.TransitionType 列挙体は新しい要素で拡張されました。

- PowerPoint 2010 のトランジションに関連する新しい要素: Box、Conveyor、Cube、Doors、Ferris、Flash、Flip、Flythrough、Gallery、Glitter、Honeycomb、Orbit、Pan、Reveal、Ripple、Rotate、Shred、Switch、Vortex、Warp、WheelReverse、Window。
- 新しい PowerPoint 2013 トランジションに関連する新しい要素: Airplane、Crush、Curtains、Drape、FallOver、Fracture、Origami、PageCurlDouble、PageCurlSingle、PeelOff、Prestige、Wind。
#### **RevealTransition クラスと IRevealTransition インターフェースの追加**
Aspose.Slides.SlideShow.RevealTransition クラス（およびそのインターフェース Aspose.Slides.SlideShow.IRevealTransition）は、このリリースからサポートされる Reveal トランジションタイプに関連しています。
#### **RippleTransition クラス、IRippleTransition インターフェース、および TransitionCornerAndCenterDirectionType 列挙体の追加**
Aspose.Slides.SlideShow.RippleTransition クラス（およびそのインターフェース Aspose.Slides.SlideShow.IRippleTransition）は、このリリースからサポートされる Ripple トランジションタイプに関連しています。

Aspose.Slides.SlideShow.TransitionCornerAndCenterDirectionType 列挙体はこのクラスで使用され、角と中心に制限された方向を指定します。