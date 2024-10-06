---
title: スライド遷移
type: docs
weight: 80
url: /ja/androidjava/slide-transition/
keywords: "PowerPointスライド遷移、JavaのMorph遷移"
description: "PowerPointスライド遷移、JavaのPowerPoint Morph遷移"
---


## **概要**
{{% alert color="primary" %}} 

Aspose.Slides for Android via Javaは、開発者がスライドのスライド遷移効果を管理またはカスタマイズできるようにします。このトピックでは、Aspose.Slides for Android via Javaを使用してスライド遷移を簡単に制御する方法を説明します。

{{% /alert %}} 

理解しやすくするために、Aspose.Slides for Android via Javaを使用して簡単なスライド遷移を管理する方法を示しました。開発者は、スライドに異なるスライド遷移効果を適用するだけでなく、これらの遷移効果の動作をカスタマイズすることもできます。

## **スライド遷移の追加**
簡単なスライド遷移効果を作成するには、以下の手順に従ってください。

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) クラスのインスタンスを作成します。
1. TransitionType列挙型を使用して、Aspose.Slides for Android via Javaによって提供される遷移効果の1つをスライドに適用します。
1. 修正されたプレゼンテーションファイルを書き込みます。

```java
// ソースプレゼンテーションファイルをロードするためにPresentationクラスをインスタンス化
Presentation presentation = new Presentation("AccessSlides.pptx");
try {
    // スライド1にサークル遷移を適用
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);

    // スライド2にコンボ遷移を適用
    presentation.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb);

    // プレゼンテーションをディスクに書き込む
    presentation.save("SampleTransition_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **高度なスライド遷移の追加**
上記のセクションでは、スライドに簡単な遷移効果を適用しました。今度は、その簡単な遷移効果をさらに良くし、制御するために、以下の手順に従ってください。

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) クラスのインスタンスを作成します。
1. Aspose.Slides for Android via Javaによって提供される遷移効果の1つをスライドに適用します。
1. 遷移をクリックで進める、特定の時間経過後、またはその両方に設定することもできます。
1. スライド遷移がクリックで進めるように有効になっている場合、遷移は誰かがマウスをクリックしたときのみ進みます。さらに、Advance After Timeプロパティが設定されている場合、指定された進行時間が経過した後、自動的に遷移が進みます。
1. 修正されたプレゼンテーションをプレゼンテーションファイルとして書き込みます。

```java
// プレゼンテーションファイルを表すPresentationクラスをインスタンス化
Presentation pres = new Presentation("BetterSlideTransitions.pptx");
try {
    // スライド1にサークル遷移を適用
    pres.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);

    // 3秒の遷移時間を設定
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceAfterTime(3000);

    // スライド2にコンボ遷移を適用
    pres.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb);
    
    // 5秒の遷移時間を設定
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceAfterTime(5000);

    // スライド3にズーム遷移を適用
    pres.getSlides().get_Item(2).getSlideShowTransition().setType(TransitionType.Zoom);
    
    // 7秒の遷移時間を設定
    pres.getSlides().get_Item(2).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(2).getSlideShowTransition().setAdvanceAfterTime(7000);

    // プレゼンテーションをディスクに書き込む
    pres.save("SampleTransition_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Morph遷移**
{{% alert color="primary" %}} 

Aspose.Slides for Android via Javaは、[Morph Transition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMorphTransition)をサポートするようになりました。これは、PowerPoint 2019で導入された新しいMorph遷移を示します。

{{% /alert %}} 

Morph遷移は、1つのスライドから次のスライドへの滑らかな動きをアニメーション化することを許可します。この記事では、Morph遷移の概念とその使用方法を説明します。Morph遷移を効果的に使用するには、少なくとも1つの共通オブジェクトを持つ2つのスライドが必要です。最も簡単な方法は、スライドを複製し、2番目のスライドのオブジェクトを別の場所に移動することです。

次のコードスニペットは、いくつかのテキストを持つスライドのクローンをプレゼンテーションに追加し、2番目のスライドに[morph type](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TransitionType)の遷移を設定する方法を示しています。

```java
Presentation presentation = new Presentation();
try {
    AutoShape autoshape = (AutoShape)presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 100);
    autoshape.getTextFrame().setText("PowerPointプレゼンテーションのMorph遷移");

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

## **Morph遷移タイプ**
新しい[TransitionMorphType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TransitionMorphType)列挙型が追加されました。これは、異なるタイプのMorphスライド遷移を表します。

TransitionMorphType列挙型には3つのメンバーがあります：

- ByObject: Morph遷移は、形状を不可分なオブジェクトとして考慮して実行されます。
- ByWord: Morph遷移は、可能な場合に単語ごとにテキストを移行します。
- ByChar: Morph遷移は、可能な場合に文字ごとにテキストを移行します。

次のコードスニペットは、スライドにMorph遷移を設定し、Morphタイプを変更する方法を示しています。

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
Aspose.Slides for Android via Javaは、黒から、左から、右からなどの遷移効果を設定することをサポートします。遷移効果を設定するには、以下の手順に従ってください。

- [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
- スライドの参照を取得します。
- 遷移効果を設定します。
- プレゼンテーションを [PPTX](https://docs.fileformat.com/presentation/pptx/)ファイルとして書き込みます。

以下の例では、遷移効果を設定しています。

```java
// Presentationクラスのインスタンスを作成
Presentation presentation = new Presentation("AccessSlides.pptx");
try {
    // 効果を設定
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Cut);
    ((OptionalBlackTransition)presentation.getSlides().get_Item(0).getSlideShowTransition().getValue()).setFromBlack(true);
    
    // プレゼンテーションをディスクに書き込む
    presentation.save("SetTransitionEffects_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```