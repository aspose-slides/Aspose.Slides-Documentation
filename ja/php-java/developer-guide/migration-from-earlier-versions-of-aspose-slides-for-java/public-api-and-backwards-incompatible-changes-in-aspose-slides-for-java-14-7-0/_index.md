---
title: Aspose.Slides for PHP via Java 14.7.0の公開APIと後方互換性のない変更
type: docs
weight: 60
url: /ja/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-7-0/
---

{{% alert color="primary" %}} 

このページでは、Aspose.Slides for PHP via Java 14.7.0 APIで追加されたすべての[クラス](/slides/ja/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-7-0/)、メソッド、プロパティ、その他の変更点、追加された制限について説明しています。

{{% /alert %}} 
## **公開APIの変更**
### **一部のTransitionValueBaseサブタイプのコンストラクターが削除され、TransitionValueFactoryが削除されました**
一部のTransitionValueBaseサブタイプ（具体的にはCornerDirectionTransition、EightDirectionTransition、EmptyTransition、InOutTransition、OptionalBlackTransition、OrientationTransition、SideDirectionTransition、SplitTransition、WheelTransition）のコンストラクターは公開APIでは無意味であるため削除されました。関連するクラスTransitionValueFactoryおよびそのインターフェースITransitionValueFactoryも同じ理由で削除されました。
### **com.aspose.slides.TransitionType列挙型からElement SoundActionが削除されました**
Element SoundActionは不正確であり、使用されていませんでした。サウンド設定はSlideShowTransition.SoundMode、.Sound、.SoundLoop、.SoundIsBuiltIn、.SoundNameプロパティによって定義されています。
### **FlyThroughTransitionクラスとIFlyThroughTransitionインターフェースが追加されました**
com.aspose.slides.FlyThroughTransitionクラス（およびそのインターフェースcom.aspose.slides.IFlyThroughTransition）は、このリリースでサポートされたFlythroughトランジションタイプに関連しています。
### **GlitterTransitionクラス、IGlitterTransitionインターフェースおよびTransitionPattern列挙型が追加されました**
com.aspose.slides.GlitterTransitionクラス（およびそのインターフェースcom.aspose.slides.IGlitterTransition）は、このリリースでサポートされたGlitterトランジションタイプに関連しています。
com.aspose.slides.TransitionPattern列挙型は、このクラスで使用され、より大きな領域を埋めるためにタイル状に配置される幾何学的パターンを指定します。
### **LeftRightDirectionTransitionクラス、ILeftRightDirectionTransitionインターフェースおよびTransitionLeftRightDirectionType列挙型が追加されました**
com.aspose.slides.LeftRightDirectionTransitionクラス（およびそのインターフェースcom.aspose.slides.ILeftRightDirectionTransition）は、このリリースでサポートされたSwitch、Flip、Ferris、Gallery、Conveyorトランジションタイプに関連しています。
com.aspose.slides.TransitionLeftRightDirectionType列挙型は、このクラスで使用され、左と右の値に制限された方向を指定します。
### **com.aspose.slides.TransitionType列挙型に新しい要素が追加されました**
com.aspose.slides.TransitionType列挙型は、新しい要素で拡張されました。
新しい要素は、新しいPowerPoint 2010トランジションに関連しています：Vortex、Switch、Flip、Ripple、Honeycomb、Cube、Box、Rotate、Orbit、Doors、Window、Ferris、Gallery、Conveyor、Pan、Glitter、Warp、Flythrough、Flash、Shred、Reveal、WheelReverse。
新しい要素は、新しいPowerPoint 2013トランジションに関連しています：FallOver、Drape、Curtains、Wind、Prestige、Fracture、Crush、PeelOff、PageCurlDouble、PageCurlSingle、Airplane、Origami。
### **RevealTransitionクラスとIRevealTransitionインターフェースが追加されました**
com.aspose.slides.RevealTransitionクラス（およびそのインターフェースcom.aspose.slides.IRevealTransition）は、このリリースでサポートされたRevealトランジションタイプに関連しています。
RippleTransitionクラス、IRippleTransitionインターフェースおよびTransitionCornerAndCenterDirectionType列挙型が追加されました
com.aspose.slides.RippleTransitionクラス（およびそのインターフェースcom.aspose.slides.IRippleTransition）は、このリリースでサポートされたRippleトランジションタイプに関連しています。
com.aspose.slides.TransitionCornerAndCenterDirectionType列挙型は、このクラスで使用され、角と中心に制限された方向を指定します。
### **ShredTransitionクラス、IShredTransitionインターフェースおよびTransitionShredPattern列挙型が追加されました**
com.aspose.slides.ShredTransitionクラス（およびそのインターフェースcom.aspose.slides.IShredTransition）は、このリリースでサポートされたShredトランジションタイプに関連しています。
com.aspose.slides.TransitionShredPattern列挙型は、このクラスで使用され、より大きな領域を埋めるためにタイル状に配置される幾何学的形状を指定します。