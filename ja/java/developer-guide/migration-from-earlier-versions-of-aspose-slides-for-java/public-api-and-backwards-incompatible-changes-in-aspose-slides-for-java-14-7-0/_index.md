---
title: Aspose.Slides for Java 14.7.0 のパブリック API と後方互換性のない変更
linktitle: Aspose.Slides for Java 14.7.0
type: docs
weight: 60
url: /ja/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-7-0/
keywords:
- マイグレーション
- レガシーコード
- モダンコード
- レガシーアプローチ
- モダンアプローチ
- PowerPoint
- OpenDocument
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Java のパブリック API の更新と破壊的変更を確認し、PowerPoint の PPT、PPTX、ODP プレゼンテーション ソリューションを円滑に移行できるようにします。"
---
{{% alert color="info" %}} 

このページでは、Aspose.Slides for Java 14.7.0 API に導入された、すべての[added](/slides/ja/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-7-0/)クラス、メソッド、プロパティなど、新しい制限やその他の変更を一覧表示します。

{{% /alert %}} 
## **パブリック API の変更**
### **一部の TransitionValueBase サブタイプのコンストラクタと TransitionValueFactory が削除されました**
一部の TransitionValueBase サブタイプ（具体的には CornerDirectionTransition、EightDirectionTransition、EmptyTransition、InOutTransition、OptionalBlackTransition、OrientationTransition、SideDirectionTransition、SplitTransition、WheelTransition）のコンストラクタはパブリック API では不要であり、削除されました。同様の理由で、関連クラスの TransitionValueFactory とそのインターフェイス ITransitionValueFactory も削除されました。
### **要素 SoundAction が com.aspose.slides.TransitionType 列挙体から削除されました**
要素 SoundAction は誤っており使用されていませんでした。サウンド設定は SlideShowTransition.SoundMode、.Sound、.SoundLoop、.SoundIsBuiltIn、.SoundName プロパティで定義されます。
### **FlyThroughTransition クラスと IFlyThroughTransition インターフェイスが追加されました**
com.aspose.slides.FlyThroughTransition クラス（およびそのインターフェイス com.aspose.slides.IFlyThroughTransition）は、このリリースでサポートされた Flythrough トランジションタイプに対応しています。
### **GlitterTransition クラス、IGlitterTransition インターフェイス、および TransitionPattern 列挙体が追加されました**
com.aspose.slides.GlitterTransition クラス（およびそのインターフェイス com.aspose.slides.IGlitterTransition）は、このリリースでサポートされた Glitter トランジションタイプに対応しています。com.aspose.slides.TransitionPattern 列挙体はこのクラスで使用され、より大きな領域を埋めるためにタイル状に配置される幾何学的パターンを指定します。
### **LeftRightDirectionTransition クラス、ILeftRightDirectionTransition インターフェイス、および TransitionLeftRightDirectionType 列挙体が追加されました**
com.aspose.slides.LeftRightDirectionTransition クラス（およびそのインターフェイス com.aspose.slides.ILeftRightDirectionTransition）は、このリリースでサポートされた Switch、Flip、Ferris、Gallery、Conveyor のトランジションタイプに対応しています。com.aspose.slides.TransitionLeftRightDirectionType 列挙体はこのクラスで使用され、方向を left と right の値に限定します。
### **新しい要素が com.aspose.slides.TransitionType 列挙体に追加されました**
com.aspose.slides.TransitionType 列挙体に新しい要素が追加されました。PowerPoint 2010 の新しいトランジションに関連する要素: Vortex、Switch、Flip、Ripple、Honeycomb、Cube、Box、Rotate、Orbit、Doors、Window、Ferris、Gallery、Conveyor、Pan、Glitter、Warp、Flythrough、Flash、Shred、Reveal、WheelReverse。PowerPoint 2013 の新しいトランジションに関連する要素: FallOver、Drape、Curtains、Wind、Prestige、Fracture、Crush、PeelOff、PageCurlDouble、PageCurlSingle、Airplane、Origami。
### **RevealTransition クラスと IRevealTransition インターフェイスが追加されました**
com.aspose.slides.RevealTransition クラス（およびそのインターフェイス com.aspose.slides.IRevealTransition）は、このリリースでサポートされた Reveal トランジションタイプに対応しています。
RippleTransition クラス、IRippleTransition インターフェイス、および TransitionCornerAndCenterDirectionType 列挙体が追加されました
com.aspose.slides.RippleTransition クラス（およびそのインターフェイス com.aspose.slides.IRippleTransition）は、このリリースでサポートされた Ripple トランジションタイプに対応しています。com.aspose.slides.TransitionCornerAndCenterDirectionType 列挙体はこのクラスで使用され、方向を角と中心に限定します。
### **ShredTransition クラス、IShredTransition インターフェイス、および TransitionShredPattern 列挙体が追加されました**
com.aspose.slides.ShredTransition クラス（およびそのインターフェイス com.aspose.slides.IShredTransition）は、このリリースでサポートされた Shred トランジションタイプに対応しています。com.aspose.slides.TransitionShredPattern 列挙体はこのクラスで使用され、より大きな領域を埋めるためにタイル状に配置される幾何学的形状を指定します。