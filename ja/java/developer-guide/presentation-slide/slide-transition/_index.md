---
title: スライド遷移
type: docs
weight: 80
url: /ja/java/slide-transition/
keywords: "PowerPoint スライド遷移, Java におけるモーフ遷移"
description: "PowerPoint スライド遷移, Java における PowerPoint モーフ遷移"
---

## **概要**
{{% alert color="primary" %}} 

Aspose.Slides for Java は、開発者がスライドのスライド遷移効果を管理またはカスタマイズすることを可能にします。このトピックでは、Aspose.Slides for Java を使用してスライド遷移を簡単に制御する方法について説明します。

{{% /alert %}} 

理解しやすくするために、Aspose.Slides for Java を使用してシンプルなスライド遷移を管理する方法を示しています。開発者はスライドに異なるスライド遷移効果を適用するだけでなく、これらの遷移効果の動作をカスタマイズすることもできます。

## **スライド遷移の追加**
簡単なスライド遷移効果を作成するには、以下の手順に従います：

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) クラスのインスタンスを作成します。
1. Aspose.Slides for Java が提供する遷移効果のいずれかからスライドにスライド遷移タイプを適用します。
1. 変更されたプレゼンテーションファイルを書き込みます。

```java
// ソースプレゼンテーションファイルを読み込むために Presentation クラスをインスタンス化します
Presentation presentation = new Presentation("AccessSlides.pptx");
try {
    // スライド 1 にサークルタイプの遷移を適用
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);

    // スライド 2 にコンボタイプの遷移を適用
    presentation.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb);

    // プレゼンテーションをディスクに書き込みます
    presentation.save("SampleTransition_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **高度なスライド遷移の追加**
上記のセクションでは、スライドにシンプルな遷移効果を適用しました。次に、そのシンプルな遷移効果をさらに改善し、制御するために、以下の手順に従ってください：

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) クラスのインスタンスを作成します。
1. Aspose.Slides for Java が提供する遷移効果のいずれかからスライドにスライド遷移タイプを適用します。
1. クリックで進む、特定の時間経過後、またはその両方に遷移を設定することもできます。
1. スライド遷移がクリックで進むように設定されている場合、遷移は誰かがマウスをクリックしたときにのみ進みます。さらに、時間経過後の遷移属性が設定されている場合、遷移は指定した進行時間が経過した後に自動的に進みます。
1. 変更されたプレゼンテーションをプレゼンテーションファイルとして書き込みます。

```java
// プレゼンテーションファイルを表す Presentation クラスをインスタンス化します
Presentation pres = new Presentation("BetterSlideTransitions.pptx");
try {
    // スライド 1 にサークルタイプの遷移を適用
    pres.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);

    // 遷移時間を 3 秒に設定
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceAfterTime(3000);

    // スライド 2 にコンボタイプの遷移を適用
    pres.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb);
    
    // 遷移時間を 5 秒に設定
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceAfterTime(5000);

    // スライド 3 にズームタイプの遷移を適用
    pres.getSlides().get_Item(2).getSlideShowTransition().setType(TransitionType.Zoom);
    
    // 遷移時間を 7 秒に設定
    pres.getSlides().get_Item(2).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(2).getSlideShowTransition().setAdvanceAfterTime(7000);

    // プレゼンテーションをディスクに書き込みます
    pres.save("SampleTransition_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **モーフ遷移**
{{% alert color="primary" %}} 

Aspose.Slides for Java は現在、[モーフ遷移](https://reference.aspose.com/slides/java/com.aspose.slides/IMorphTransition)をサポートしています。これは、PowerPoint 2019 で導入された新しいモーフ遷移を表しています。

{{% /alert %}} 

モーフ遷移は、一つのスライドから次のスライドへの滑らかな動きのアニメーションを可能にします。この記事では、モーフ遷移の概念とその使用方法について説明します。モーフ遷移を効果的に使用するには、共通のオブジェクトを持つ2つのスライドが必要です。最も簡単な方法は、スライドを複製し、次のスライドのオブジェクトを異なる場所に移動することです。

以下のコードスニペットでは、スライドのクローンをプレゼンテーションに追加し、2 番目のスライドに [モーフタイプ](https://reference.aspose.com/slides/java/com.aspose.slides/TransitionType) の遷移を設定する方法を示しています。

```java
Presentation presentation = new Presentation();
try {
    AutoShape autoshape = (AutoShape)presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 100);
    autoshape.getTextFrame().setText("PowerPoint プレゼンテーションにおけるモーフ遷移");

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

## **モーフ遷移の種類**
新しい [TransitionMorphType](https://reference.aspose.com/slides/java/com.aspose.slides/TransitionMorphType) 列挙型が追加されました。これは、異なる種類のモーフスライド遷移を表します。

TransitionMorphType 列挙型には3つのメンバーがあります：

- ByObject: モーフ遷移は、図形を不可分なオブジェクトとして考慮して実行されます。
- ByWord: モーフ遷移は、可能な限り単語ごとにテキストを転送することで実行されます。
- ByChar: モーフ遷移は、可能な限り文字ごとにテキストを転送することで実行されます。

以下のコードスニペットでは、スライドにモーフ遷移を設定し、モーフタイプを変更する方法を示しています。

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
Aspose.Slides for Java は、黒からの遷移、左からの遷移、右からの遷移などの遷移効果を設定することをサポートしています。遷移効果を設定するには、以下の手順に従ってください：

- [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
- スライドの参照を取得します。
- 遷移効果を設定します。
- プレゼンテーションを [PPTX](https://docs.fileformat.com/presentation/pptx/)ファイルとして書き込みます。

以下の例では、遷移効果を設定しています。

```java
// Presentation クラスのインスタンスを作成します
Presentation presentation = new Presentation("AccessSlides.pptx");
try {
    // 効果を設定します
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Cut);
    ((OptionalBlackTransition)presentation.getSlides().get_Item(0).getSlideShowTransition().getValue()).setFromBlack(true);
    
    // プレゼンテーションをディスクに書き込みます
    presentation.save("SetTransitionEffects_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
``` 