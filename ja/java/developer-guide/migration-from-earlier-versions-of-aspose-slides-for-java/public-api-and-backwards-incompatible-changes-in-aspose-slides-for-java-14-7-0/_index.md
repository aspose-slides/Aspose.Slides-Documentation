---
title: Aspose.Slides for Java 14.7.0における公開APIと非互換性のある変更
type: docs
weight: 60
url: /java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-7-0/
---

{{% alert color="primary" %}} 

このページでは、Aspose.Slides for Java 14.7.0 APIに導入されたすべての[class](/slides/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-7-0/)クラス、メソッド、プロパティなど、すべての新しい制約およびその他の変更をリストしています。

{{% /alert %}} 
## **公開APIの変更**
### **いくつかのTransitionValueBaseサブタイプのコンストラクタが削除され、TransitionValueFactoryが削除されました**
いくつかのTransitionValueBaseサブタイプ（特にCornerDirectionTransition、EightDirectionTransition、EmptyTransition、InOutTransition、OptionalBlackTransition、OrientationTransition、SideDirectionTransition、SplitTransition、WheelTransition）のコンストラクタは公開APIでは無用であるため削除されました。関連するクラスTransitionValueFactoryおよびそのインターフェイスITransitionValueFactoryも同様の理由で削除されました。
### **Element SoundActionがcom.aspose.slides.TransitionType列挙から削除されました**
Element SoundActionは不正確で使用されていませんでした。サウンド設定はSlideShowTransition.SoundMode、.Sound、.SoundLoop、.SoundIsBuiltIn、.SoundNameプロパティによって定義されています。
### **FlyThroughTransitionクラスとIFlyThroughTransitionインターフェイスが追加されました**
com.aspose.slides.FlyThroughTransitionクラス（およびそのインターフェイスcom.aspose.slides.IFlyThroughTransition）は、今回のリリースでサポートされている移行タイプFlythroughに関連しています。
### **GlitterTransitionクラス、IGlitterTransitionインターフェイスおよびTransitionPattern列挙が追加されました**
com.aspose.slides.GlitterTransitionクラス（およびそのインターフェイスcom.aspose.slides.IGlitterTransition）は、今回のリリースでサポートされている移行タイプGlitterに関連しています。
com.aspose.slides.TransitionPattern列挙はこのクラスで使用され、大きな面積を埋めるためにタイル状に並べられる幾何学的パターンを指定します。
### **LeftRightDirectionTransitionクラス、ILeftRightDirectionTransitionインターフェイスおよびTransitionLeftRightDirectionType列挙が追加されました**
com.aspose.slides.LeftRightDirectionTransitionクラス（およびそのインターフェイスcom.aspose.slides.ILeftRightDirectionTransition）は、今回のリリースでサポートされている移行タイプSwitch、Flip、Ferris、Gallery、Conveyorに関連しています。
com.aspose.slides.TransitionLeftRightDirectionType列挙はこのクラスで使用され、左と右の値に制限された方向を指定します。
### **新しい要素がcom.aspose.slides.TransitionType列挙に追加されました**
com.aspose.slides.TransitionType列挙は新しい要素で拡張されました。
新しい要素は新しいPowerPoint 2010の移行に関連しています: Vortex、Switch、Flip、Ripple、Honeycomb、Cube、Box、Rotate、Orbit、Doors、Window、Ferris、Gallery、Conveyor、Pan、Glitter、Warp、Flythrough、Flash、Shred、Reveal、WheelReverse。
新しい要素は新しいPowerPoint 2013の移行に関連しています: FallOver、Drape、Curtains、Wind、Prestige、Fracture、Crush、PeelOff、PageCurlDouble、PageCurlSingle、Airplane、Origami。
### **RevealTransitionクラスとIRevealTransitionインターフェイスが追加されました**
com.aspose.slides.RevealTransitionクラス（およびそのインターフェイスcom.aspose.slides.IRevealTransition）は、今回のリリースでサポートされている移行タイプRevealに関連しています。
RippleTransitionクラス、IRippleTransitionインターフェイスおよびTransitionCornerAndCenterDirectionType列挙が追加されました。
com.aspose.slides.RippleTransitionクラス（およびそのインターフェイスcom.aspose.slides.IRippleTransition）は、今回のリリースでサポートされている移行タイプRippleに関連しています。
com.aspose.slides.TransitionCornerAndCenterDirectionType列挙はこのクラスで使用され、角と中心に制限された方向を指定します。
### **ShredTransitionクラス、IShredTransitionインターフェイスおよびTransitionShredPattern列挙が追加されました**
com.aspose.slides.ShredTransitionクラス（およびそのインターフェイスcom.aspose.slides.IShredTransition）は、今回のリリースでサポートされている移行タイプShredに関連しています。
com.aspose.slides.TransitionShredPattern列挙はこのクラスで使用され、より大きな面積を埋めるためにタイル状に並べられる幾何学的形状を指定します。