---
title: Java を使用したプレゼンテーションのスライド遷移管理
linktitle: スライド遷移
type: docs
weight: 80
url: /ja/java/slide-transition/
keywords:
- スライド遷移
- スライド遷移の追加
- スライド遷移の適用
- 高度なスライド遷移
- モーフ遷移
- 遷移タイプ
- 遷移効果
- PowerPoint
- OpenDocument
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Java でスライド遷移をカスタマイズする方法を、PowerPoint と OpenDocument プレゼンテーション向けにステップバイステップでご紹介します。"
---

## **概要**
{{% alert color="primary" %}} 
Aspose.Slides for Java は、開発者がスライドの遷移効果を管理またはカスタマイズできるようにします。このトピックでは、Aspose.Slides for Java を使用してスライド遷移を簡単に制御する方法について説明します。
{{% /alert %}} 

理解しやすくするために、Aspose.Slides for Java を使用してシンプルなスライド遷移を管理する方法を示しています。開発者はスライドにさまざまな遷移効果を適用できるだけでなく、これらの遷移効果の動作もカスタマイズできます。

## **スライド遷移の追加**
1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) クラスのインスタンスを作成します。  
1. Aspose.Slides for Java が提供する遷移効果のうちの一つを TransitionType 列挙体を使用してスライドに適用します。  
1. 変更されたプレゼンテーションファイルを書き込みます。  
```java
// ソースプレゼンテーションファイルをロードするために Presentation クラスをインスタンス化します
Presentation presentation = new Presentation("AccessSlides.pptx");
try {
    // スライド 1 に円形トランジションを適用します
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);

    // スライド 2 にコームトランジションを適用します
    presentation.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb);

    // プレゼンテーションをディスクに保存します
    presentation.save("SampleTransition_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **高度なスライド遷移の追加**
1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) クラスのインスタンスを作成します。  
1. Aspose.Slides for Java が提供する遷移効果のうちの一つをスライドに適用します。  
1. 遷移をクリックで進むよう、指定した時間後に進むよう、またはその両方に設定できます。  
1. スライド遷移が「クリックで進む」ように有効になっている場合、マウスクリック時にのみ遷移が進みます。さらに「指定時間後に進む」プロパティが設定されている場合、指定された時間が経過すると自動的に遷移が進みます。  
1. 変更されたプレゼンテーションをファイルとして書き込みます。  
```java
// プレゼンテーションファイルを表す Presentation クラスのインスタンスを作成します
Presentation pres = new Presentation("BetterSlideTransitions.pptx");
try {
    // スライド 1 に円形遷移を適用します
    pres.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);

    // 遷移時間を 3 秒に設定します
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceAfterTime(3000);

    // スライド 2 にコーム遷移を適用します
    pres.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb);
    
    // 遷移時間を 5 秒に設定します
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceAfterTime(5000);

    // スライド 3 にズーム遷移を適用します
    pres.getSlides().get_Item(2).getSlideShowTransition().setType(TransitionType.Zoom);
    
    // 遷移時間を 7 秒に設定します
    pres.getSlides().get_Item(2).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(2).getSlideShowTransition().setAdvanceAfterTime(7000);

    // プレゼンテーションをディスクに保存します
    pres.save("SampleTransition_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


## **モーフ遷移**
{{% alert color="primary" %}} 
Aspose.Slides for Java は現在、[Morph Transition](https://reference.aspose.com/slides/java/com.aspose.slides/IMorphTransition) をサポートしています。これは PowerPoint 2019 で導入された新しいモーフ遷移を表します。 
{{% /alert %}} 

Morph遷移を使用すると、あるスライドから次のスライドへの滑らかな移動をアニメーション化できます。本記事では概念とMorph遷移の使用方法を説明します。Morph遷移を効果的に使用するには、共通のオブジェクトが少なくとも1つある2枚のスライドが必要です。最も簡単な方法はスライドを複製し、2枚目のスライド上のオブジェクトを別の位置に移動することです。

以下のコードスニペットは、テキストを含むスライドのクローンをプレゼンテーションに追加し、2枚目のスライドに [morph type](https://reference.aspose.com/slides/java/com.aspose.slides/TransitionType) の遷移を設定する方法を示しています。
```java
Presentation presentation = new Presentation();
try {
    AutoShape autoshape = (AutoShape)presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 100);
    autoshape.getTextFrame().setText("Morph Transition in PowerPoint Presentations");

    presentation.getSlides().addClone(presentation.getSlides().get_Item(0));

    IShape shape = presentation.getSlides().get_Item(1).getShapes().get_Item(0);
    shape.setX(shape.getX() + 100);
    shape.setY(shape.getY() + 50);
    shape.setWidth(shape.getWidth() - 200);
    shape.setHeight(shape.getHeight() - 10);

    presentation.getSlides().get_Item(1).getSlideShowTransition().setType(com.aspose.slides.TransitionType.Morph);

    presentation.save("presentation-out.pptx", SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```


## **モーフ遷移タイプ**
新しい [TransitionMorphType](https://reference.aspose.com/slides/java/com.aspose.slides/TransitionMorphType) 列挙体が追加されました。これはモーフスライド遷移のさまざまなタイプを表します。

TransitionMorphType 列挙体には3つのメンバーがあります：

- ByObject: 形状を分割できないオブジェクトとして考慮してモーフ遷移が実行されます。  
- ByWord: 可能な場合、テキストを単語単位で転送してモーフ遷移が実行されます。  
- ByChar: 可能な場合、テキストを文字単位で転送してモーフ遷移が実行されます。  

以下のコードスニペットは、スライドにモーフ遷移を設定し、モーフタイプを変更する方法を示しています。
```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Morph);
    ((IMorphTransition)presentation.getSlides().get_Item(0).getSlideShowTransition().getValue()).setMorphType(TransitionMorphType.ByWord);
    presentation.save("presentation-out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **遷移効果の設定**
Aspose.Slides for Java は、黒から、左から、右からなどの遷移効果の設定をサポートしています。遷移効果を設定するには、以下の手順に従ってください：

- [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスのインスタンスを作成します。  
- スライドの参照を取得します。  
- 遷移効果を設定します。  
- プレゼンテーションを [PPTX](https://docs.fileformat.com/presentation/pptx/) ファイルとして書き込みます。  

以下の例では、遷移効果を設定しています。
```java
// Presentation クラスのインスタンスを作成します
Presentation presentation = new Presentation("AccessSlides.pptx");
try {
    // エフェクトを設定します
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Cut);
    ((OptionalBlackTransition)presentation.getSlides().get_Item(0).getSlideShowTransition().getValue()).setFromBlack(true);
    
    // プレゼンテーションをディスクに保存します
    presentation.save("SetTransitionEffects_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **FAQ**

**スライド遷移の再生速度を制御できますか？**

はい。遷移の [speed](https://reference.aspose.com/slides/java/com.aspose.slides/slideshowtransition/#setSpeed-int-) を [TransitionSpeed](https://reference.aspose.com/slides/java/com.aspose.slides/transitionspeed/) 設定で指定します（例：slow/medium/fast）。

**遷移にオーディオを添付してループさせることはできますか？**

はい。遷移にサウンドを埋め込み、サウンドモードやループなどの設定で動作を制御できます（例： [setSound](https://reference.aspose.com/slides/java/com.aspose.slides/slideshowtransition/#setSound-com.aspose.slides.IAudio-), [setSoundMode](https://reference.aspose.com/slides/java/com.aspose.slides/slideshowtransition/#setSoundMode-int-), [setSoundLoop](https://reference.aspose.com/slides/java/com.aspose.slides/slideshowtransition/#setSoundLoop-boolean-), さらに [setSoundIsBuiltIn](https://reference.aspose.com/slides/java/com.aspose.slides/slideshowtransition/#setSoundIsBuiltIn-boolean-) や [setSoundName](https://reference.aspose.com/slides/java/com.aspose.slides/slideshowtransition/#setSoundName-java.lang.String-) などのメタデータ）。

**すべてのスライドに同じ遷移を適用する最速の方法は何ですか？**

各スライドの遷移設定で目的の遷移タイプを設定します。遷移はスライドごとに保持されるため、すべてのスライドに同じタイプを設定すれば一貫した結果が得られます。

**スライドに現在設定されている遷移を確認するにはどうすればよいですか？**

スライドの [transition settings](https://reference.aspose.com/slides/java/com.aspose.slides/baseslide/#getSlideShowTransition--) を調べ、[transition type](https://reference.aspose.com/slides/java/com.aspose.slides/slideshowtransition/#setType-int-) を取得します。その値が適用されている効果を示します。