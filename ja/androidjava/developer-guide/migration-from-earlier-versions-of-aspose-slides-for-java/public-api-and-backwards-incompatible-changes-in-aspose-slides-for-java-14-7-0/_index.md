---
title: Aspose.Slides for Java 14.7.0 における公開 API と後方互換性のない変更
type: docs
weight: 60
url: /ja/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-7-0/
---

{{% alert color="primary" %}} 

このページは、Aspose.Slides for Java 14.7.0 API で導入されたすべての [追加された](/slides/ja/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-7-0/)クラス、メソッド、プロパティなど、新しい制限およびその他の変更を一覧表示しています。

{{% /alert %}} 
## **公開 API の変更**
### **一部の TransitionValueBase サブタイプのコンストラクターが削除され、TransitionValueFactory が削除されました**
一部の TransitionValueBase サブタイプ（具体的には CornerDirectionTransition、EightDirectionTransition、EmptyTransition、InOutTransition、OptionalBlackTransition、OrientationTransition、SideDirectionTransition、SplitTransition、WheelTransition）のコンストラクターは公開 API では無用であるため削除されました。関連クラス TransitionValueFactory およびそのインターフェース ITransitionValueFactory も同様の理由で削除されました。
### **com.aspose.slides.TransitionType 列挙型から SoundAction 要素が削除されました**
SoundAction 要素は不正確で使用されていませんでした。サウンド設定は、SlideShowTransition.SoundMode、.Sound、.SoundLoop、.SoundIsBuiltIn、.SoundName プロパティによって定義されます。
### **FlyThroughTransition クラスおよび IFlyThroughTransition インターフェースが追加されました**
com.aspose.slides.FlyThroughTransition クラス（およびそのインターフェース com.aspose.slides.IFlyThroughTransition）は、このリリースでサポートされた Flythrough トランジションタイプに関連しています。
### **GlitterTransition クラス、IGlitterTransition インターフェースおよび TransitionPattern 列挙型が追加されました**
com.aspose.slides.GlitterTransition クラス（およびそのインターフェース com.aspose.slides.IGlitterTransition）は、このリリースでサポートされた Glitter トランジションタイプに関連しています。
com.aspose.slides.TransitionPattern 列挙型はこのクラスで使用され、より大きな面積を埋めるための幾何学的パターンを指定します。
### **LeftRightDirectionTransition クラス、ILeftRightDirectionTransition インターフェースおよび TransitionLeftRightDirectionType 列挙型が追加されました**
com.aspose.slides.LeftRightDirectionTransition クラス（およびそのインターフェース com.aspose.slides.ILeftRightDirectionTransition）は、このリリースでサポートされた Switch、Flip、Ferris、Gallery、Conveyor トランジションタイプに関連しています。
com.aspose.slides.TransitionLeftRightDirectionType 列挙型はこのクラスで使用され、左と右の値に制限された方向を指定します。
### **com.aspose.slides.TransitionType 列挙型に新しい要素が追加されました**
com.aspose.slides.TransitionType 列挙型は新しい要素で拡張されました。
新しい要素は新しい PowerPoint 2010 トランジションに関連しています：Vortex、Switch、Flip、Ripple、Honeycomb、Cube、Box、Rotate、Orbit、Doors、Window、Ferris、Gallery、Conveyor、Pan、Glitter、Warp、Flythrough、Flash、Shred、Reveal、WheelReverse。
新しい要素は新しい PowerPoint 2013 トランジションに関連しています：FallOver、Drape、Curtains、Wind、Prestige、Fracture、Crush、PeelOff、PageCurlDouble、PageCurlSingle、Airplane、Origami。
### **RevealTransition クラスおよび IRevealTransition インターフェースが追加されました**
com.aspose.slides.RevealTransition クラス（およびそのインターフェース com.aspose.slides.IRevealTransition）は、このリリースでサポートされた Reveal トランジションタイプに関連しています。
RippleTransition クラス、IRippleTransition インターフェースおよび TransitionCornerAndCenterDirectionType 列挙型が追加されました
com.aspose.slides.RippleTransition クラス（およびそのインターフェース com.aspose.slides.IRippleTransition）は、このリリースでサポートされた Ripple トランジションタイプに関連しています。
com.aspose.slides.TransitionCornerAndCenterDirectionType 列挙型はこのクラスで使用され、コーナーと中央に制限された方向を指定します。
### **ShredTransition クラス、IShredTransition インターフェースおよび TransitionShredPattern 列挙型が追加されました**
com.aspose.slides.ShredTransition クラス（およびそのインターフェース com.aspose.slides.IShredTransition）は、このリリースでサポートされた Shred トランジションタイプに関連しています。
com.aspose.slides.TransitionShredPattern 列挙型はこのクラスで使用され、より大きな面積を埋めるための幾何学的形状を指定します。