---
title: Android でのプレゼンテーションのスライド トランジションの管理
linktitle: スライド トランジション
type: docs
weight: 80
url: /ja/androidjava/slide-transition/
keywords:
- スライド トランジション
- スライド トランジションの追加
- スライド トランジションの適用
- 高度なスライド トランジション
- モーフ トランジション
- トランジション タイプ
- トランジション 効果
- PowerPoint
- OpenDocument
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java でスライド トランジションをカスタマイズする方法を、PowerPoint と OpenDocument のプレゼンテーション向けのステップバイステップガイドとともに紹介します。"
---

## **概要**
{{% alert color="primary" %}} 

Aspose.Slides for Android via Java は、開発者がスライドのトランジション効果を管理またはカスタマイズできるようにします。本トピックでは、Aspose.Slides for Android via Java を使用してスライドトランジションを簡単に制御する方法について説明します。

{{% /alert %}} 

理解しやすくするために、Aspose.Slides for Android via Java を使用してシンプルなスライドトランジションを管理する方法をデモしています。開発者はスライドにさまざまなトランジション効果を適用できるだけでなく、これらの効果の動作もカスタマイズできます。

## **スライド トランジションの追加**
シンプルなスライドトランジション効果を作成するには、以下の手順に従います。

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) クラスのインスタンスを作成します。
2. Aspose.Slides for Android via Java が提供する TransitionType 列挙体を使用して、スライドにスライド トランジション タイプを適用します。
3. 変更されたプレゼンテーション ファイルを書き出します。
```java
// ソースプレゼンテーション ファイルを読み込むために Presentation クラスのインスタンスを作成します
Presentation presentation = new Presentation("AccessSlides.pptx");
try {
    // スライド 1 にサークル タイプのトランジションを適用します
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);

    // スライド 2 にコーム タイプのトランジションを適用します
    presentation.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb);

    // プレゼンテーションをディスクに保存します
    presentation.save("SampleTransition_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **高度なスライド トランジションの追加**
上記のセクションでは、シンプルなトランジション効果をスライドに適用しました。次に、シンプルなトランジション効果をさらに高度に制御できるように、以下の手順に従ってください。

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) クラスのインスタンスを作成します。
2. Aspose.Slides for Android via Java が提供するトランジション効果から、スライドにスライド トランジション タイプを適用します。
3. トランジションをクリックで進む、特定の時間経過後、またはその両方に設定できます。
4. スライド トランジションが「クリックで進む」ように有効になっている場合、マウスクリック時にのみトランジションが進みます。さらに、Advance After Time プロパティが設定されている場合、指定された時間が経過するとトランジションは自動的に進行します。
5. 変更されたプレゼンテーションをプレゼンテーション ファイルとして書き出します。
```java
// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します
Presentation pres = new Presentation("BetterSlideTransitions.pptx");
try {
    // スライド 1 にサークル タイプのトランジションを適用します
    pres.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);

    // トランジション時間を 3 秒に設定します
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceAfterTime(3000);

    // スライド 2 にコーム タイプのトランジションを適用します
    pres.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb);
    
    // トランジション時間を 5 秒に設定します
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceAfterTime(5000);

    // スライド 3 にズーム タイプのトランジションを適用します
    pres.getSlides().get_Item(2).getSlideShowTransition().setType(TransitionType.Zoom);
    
    // トランジション時間を 7 秒に設定します
    pres.getSlides().get_Item(2).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(2).getSlideShowTransition().setAdvanceAfterTime(7000);

    // プレゼンテーションをディスクに保存します
    pres.save("SampleTransition_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


## **モーフ トランジション**
{{% alert color="primary" %}} 

Aspose.Slides for Android via Java は、[Morph Transition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMorphTransition) をサポートするようになりました。これは PowerPoint 2019 で導入された新しいモーフ トランジションです。

{{% /alert %}} 

モーフ トランジションにより、あるスライドから次のスライドへスムーズな動きをアニメーション化できます。本稿では、モーフ トランジションの概念と使用方法について説明します。モーフ トランジションを効果的に使用するには、少なくとも1つの共通オブジェクトを持つ2つのスライドが必要です。最も簡単な方法は、スライドを複製し、2番目のスライド上のオブジェクトを別の位置に移動することです。

以下のコードスニペットは、テキストを含むスライドのクローンをプレゼンテーションに追加し、2番目のスライドに [morph type](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TransitionType) のトランジションを設定する方法を示しています。
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


## **モーフ トランジション タイプ**
新しい [TransitionMorphType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TransitionMorphType) 列挙体が追加されました。これはモーフ スライド トランジションのさまざまなタイプを表します。

TransitionMorphType 列挙体には次の 3 つのメンバーがあります。

- ByObject: 形状を分割不可能なオブジェクトとして扱い、モーフ トランジションを実行します。
- ByWord: 可能な場合は単語単位でテキストを転送し、モーフ トランジションを実行します。
- ByChar: 可能な場合は文字単位でテキストを転送し、モーフ トランジションを実行します。

以下のコードスニペットは、スライドにモーフ トランジションを設定し、モーフ タイプを変更する方法を示しています。
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


## **トランジション効果の設定**
Aspose.Slides for Android via Java は、左から、右から、黒からなどのトランジション効果の設定をサポートしています。トランジション効果を設定するには、以下の手順に従ってください。

- [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
- スライドの参照を取得します。
- トランジション効果を設定します。
- プレゼンテーションを [PPTX](https://docs.fileformat.com/presentation/pptx/) ファイルとして書き出します。

以下の例では、トランジション効果を設定しています。
```java
// Presentation クラスのインスタンスを作成します
Presentation presentation = new Presentation("AccessSlides.pptx");
try {
    // 効果を設定します
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Cut);
    ((OptionalBlackTransition)presentation.getSlides().get_Item(0).getSlideShowTransition().getValue()).setFromBlack(true);
    
    // プレゼンテーションをディスクに保存します
    presentation.save("SetTransitionEffects_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **FAQ**

**スライド トランジションの再生速度を制御できますか？**

はい。[TransitionSpeed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/transitionspeed/) 設定（例: slow/medium/fast）を使用して、トランジションの [speed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slideshowtransition/#setSpeed-int-) を設定できます。

**トランジションにオーディオを添付し、ループさせることはできますか？**

はい。トランジション用にサウンドを埋め込み、サウンド モードやループなどの設定（例: [setSound](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slideshowtransition/#setSound-com.aspose.slides.IAudio-), [setSoundMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slideshowtransition/#setSoundMode-int-), [setSoundLoop](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slideshowtransition/#setSoundLoop-boolean-), さらに [setSoundIsBuiltIn](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slideshowtransition/#setSoundIsBuiltIn-boolean-) や [setSoundName](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slideshowtransition/#setSoundName-java.lang.String-)) で動作を制御できます。

**すべてのスライドに同じトランジションを適用する最速の方法は何ですか？**

各スライドのトランジション設定で目的のトランジション タイプを構成します。トランジションはスライドごとに保存されるため、すべてのスライドに同じタイプを適用すれば一貫した結果が得られます。

**スライドに現在設定されているトランジションを確認するにはどうすればよいですか？**

スライドの [transition settings](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseslide/#getSlideShowTransition--) を調べ、[transition type](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slideshowtransition/#setType-int-) を取得します。その値が適用されている効果を正確に示します。