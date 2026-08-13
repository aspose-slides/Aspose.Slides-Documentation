---
title: Java を使用したプレゼンテーションのスライド遷移の管理
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
description: "Aspose.Slides for Java でスライド遷移をカスタマイズする方法を、PowerPoint と OpenDocument のプレゼンテーション向けにステップバイステップで解説します。"
---
## **概要**

この記事では、Aspose.Slides を使用してプレゼンテーションのスライド遷移を管理する方法を説明します。遷移タイプをスライドに適用する方法、クリック時や指定時間後に進むなどの遷移動作の設定方法、自動進行のチェックと無効化、Morph 遷移とそのタイプの使用方法、遷移効果オプションの設定方法を示します。例では、プレゼンテーションを読み込むまたは作成し、選択したスライドの遷移設定を変更し、結果を PPTX ファイルとして保存する手順を示します。また、遷移速度、遷移サウンド、複数スライドへの同一遷移の適用、スライドに現在設定されている遷移の確認など、よくある質問にも回答します。

## **スライド遷移の追加**
シンプルなスライド遷移効果を作成するには、以下の手順に従ってください。

1. [Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation) クラスのインスタンスを作成します。
2. Aspose.Slides for Java が提供する TransitionType 列挙体を使用して、スライドにスライド遷移タイプを適用します。
3. 変更されたプレゼンテーションを保存します。

```java
import com.aspose.slides.*;

// プレゼンテーション クラスのインスタンスを生成し、ソース プレゼンテーション ファイルをロードします
Presentation presentation = new Presentation("AccessSlides.pptx");
try {
    // スライド 1 にサークル タイプの遷移を適用します
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);

    // スライド 2 にコーム タイプの遷移を適用します
    presentation.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb);

    // プレゼンテーションをディスクに保存します
    presentation.save("SampleTransition_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **高度なスライド遷移の追加**
上記のセクションでは、シンプルな遷移効果をスライドに適用しました。これをさらに高度に制御するには、以下の手順に従ってください。

1. [Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation) クラスのインスタンスを作成します。
2. Aspose.Slides for Java が提供する遷移効果からスライド遷移タイプを適用します。
3. 遷移をクリックで進むよう、特定の時間後に進むよう、またはその両方に設定することもできます。
4. スライド遷移が「クリックで進む」に設定されている場合、マウスクリック時にのみ遷移が進みます。さらに「指定時間後に進む」プロパティが設定されている場合、指定された時間が経過すると自動的に遷移が進みます。
5. 変更されたプレゼンテーションをファイルとして保存します。

```java
import com.aspose.slides.*;

// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを生成します
Presentation pres = new Presentation("BetterSlideTransitions.pptx");
try {
    // スライド 1 にサークル タイプの遷移を適用します
    pres.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);

    // 遷移時間を 3 秒に設定します
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceAfterTime(3000);

    // スライド 2 にコーム タイプの遷移を適用します
    pres.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb);
    
    // 遷移時間を 5 秒に設定します
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceAfterTime(5000);

    // スライド 3 にズーム タイプの遷移を適用します
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

## **Morph 遷移**
{{% alert color="info" %}} 
Aspose.Slides for Java は現在、[Morph Transition](https://reference.aspose.com/slides/ja/java/com.aspose.slides/IMorphTransition) をサポートしています。これは PowerPoint 2019 で導入された新しいモーフ遷移を表します。
{{% /alert %}} 

Morph 遷移により、あるスライドから次のスライドへの滑らかな動きをアニメーション化できます。本記事では概念と Morph 遷移の使用方法を説明します。Morph 遷移を効果的に使用するには、少なくとも 1 つのオブジェクトが共通している 2 枚のスライドが必要です。最も簡単な方法はスライドを複製し、2 枚目のスライド上でオブジェクトを別の場所に移動することです。

以下のコードスニペットは、スライドのクローンにテキストを追加し、2 枚目のスライドに [morph type](https://reference.aspose.com/slides/ja/java/com.aspose.slides/TransitionType) の遷移を設定する方法を示しています。

```java
import com.aspose.slides.*;

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

## **Morph 遷移タイプ**
新しい [TransitionMorphType](https://reference.aspose.com/slides/ja/java/com.aspose.slides/TransitionMorphType) 列挙体が追加されました。これは Morph スライド遷移のさまざまなタイプを表します。

TransitionMorphType 列挙体には 3 つのメンバーがあります。

- ByObject: 形状を分割できないオブジェクトとして扱い、Morph 遷移が実行されます。
- ByWord: 可能な場合はテキストを単語単位で転送しながら Morph 遷移が実行されます。
- ByChar: 可能な場合はテキストを文字単位で転送しながら Morph 遷移が実行されます。

以下のコードスニペットは、スライドに Morph 遷移を設定し、Morph タイプを変更する方法を示しています。

```java
import com.aspose.slides.*;

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
Aspose.Slides for Java は、黒から、左から、右からなどの遷移効果の設定をサポートしています。遷移効果を設定するには、以下の手順に従ってください。

- [Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
- スライドの参照を取得します。
- 遷移効果を設定します。
- プレゼンテーションを [PPTX](https://docs.fileformat.com/presentation/pptx/) ファイルとして保存します。

以下の例では、遷移効果を設定しています。

```java
import com.aspose.slides.*;

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

### スライド遷移の再生速度を制御できますか？

はい。[TransitionSpeed](https://reference.aspose.com/slides/ja/java/com.aspose.slides/transitionspeed/) 設定を使用して遷移の[speed](https://reference.aspose.com/slides/ja/java/com.aspose.slides/slideshowtransition/#setSpeed-int-) を設定することで、再生速度を制御できます（例: slow/medium/fast）。

### 遷移に音声を添付してループさせることはできますか？

はい。遷移にサウンドを埋め込み、サウンドモードやループなどの設定で動作を制御できます（例: [setSound](https://reference.aspose.com/slides/ja/java/com.aspose.slides/slideshowtransition/#setSound-com.aspose.slides.IAudio-)、[setSoundMode](https://reference.aspose.com/slides/ja/java/com.aspose.slides/slideshowtransition/#setSoundMode-int-)、[setSoundLoop](https://reference.aspose.com/slides/ja/java/com.aspose.slides/slideshowtransition/#setSoundLoop-boolean-)、さらにメタデータとして [setSoundIsBuiltIn](https://reference.aspose.com/slides/ja/java/com.aspose.slides/slideshowtransition/#setSoundIsBuiltIn-boolean-) や [setSoundName](https://reference.aspose.com/slides/ja/java/com.aspose.slides/slideshowtransition/#setSoundName-java.lang.String-) があります）。

### すべてのスライドに同じ遷移を適用する最速の方法は何ですか？

各スライドの遷移設定で目的の遷移タイプを設定します。遷移はスライドごとに保存されるため、すべてのスライドに同じタイプを設定すれば一貫した結果が得られます。

### スライドに現在設定されている遷移を確認するにはどうすればよいですか？

スライドの[transition settings](https://reference.aspose.com/slides/ja/java/com.aspose.slides/baseslide/#getSlideShowTransition--) を調べ、[transition type](https://reference.aspose.com/slides/ja/java/com.aspose.slides/slideshowtransition/#setType-int-) を取得します。その値が適用された効果を正確に示します。