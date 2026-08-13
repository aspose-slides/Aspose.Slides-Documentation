---
title: Android でのプレゼンテーションにおけるスライド遷移の管理
linktitle: スライド遷移
type: docs
weight: 80
url: /ja/androidjava/slide-transition/
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
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java でスライド遷移をカスタマイズする方法を、PowerPoint と OpenDocument のプレゼンテーション向けにステップバイステップで解説します。"
---
## **概要**

この記事では、Aspose.Slides を使用してプレゼンテーションのスライド遷移を管理する方法を説明します。スライドに遷移タイプを適用する方法、クリックで進むか指定時間後に進むかといった遷移動作の設定、Morph 遷移とその種類の使用方法、遷移効果オプションの設定方法を示します。サンプルでは、プレゼンテーションを読み込むまたは作成し、選択したスライドの遷移設定を変更し、結果を PPTX ファイルとして保存する手順を示しています。また、遷移速度、遷移サウンド、複数スライドへの同一遷移の適用、スライド上に現在設定されている遷移の確認に関するよくある質問にも答えています。

## **スライド遷移の追加**
単純なスライド遷移効果を作成するには、以下の手順に従います。

1. [Presentation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation) クラスのインスタンスを作成します。
2. TransitionType 列挙体を使用して、Aspose.Slides for Android via Java が提供する遷移効果のいずれかをスライドに適用します。
3. 変更したプレゼンテーション ファイルを書き込みます。

```java
import com.aspose.slides.*;

// ソース プレゼンテーション ファイルを読み込むために Presentation クラスのインスタンスを作成します
Presentation presentation = new Presentation("AccessSlides.pptx");
try {
    // スライド 1 にサークル タイプの遷移を適用します
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);

    // スライド 2 にコンブ タイプの遷移を適用します
    presentation.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb);

    // プレゼンテーションをディスクに保存します
    presentation.save("SampleTransition_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **高度なスライド遷移の追加**
上記のセクションでは単純な遷移効果のみを適用しました。ここでは、同じ遷移効果をより細かく制御できるようにする手順をご紹介します。

1. [Presentation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation) クラスのインスタンスを作成します。
2. Aspose.Slides for Android via Java が提供する遷移効果のいずれかをスライドに適用します。
3. 遷移を「クリックで進む」や「指定時間後に進む」またはその両方に設定できます。
4. スライド遷移が「クリックで進む」ように設定されている場合、マウスをクリックしたときにのみ遷移が進みます。さらに、Advance After Time プロパティが設定されている場合、指定した時間が経過すると自動的に遷移が進みます。
5. 変更したプレゼンテーションをプレゼンテーション ファイルとして書き込みます。

```java
import com.aspose.slides.*;

// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します
Presentation pres = new Presentation("BetterSlideTransitions.pptx");
try {
    // スライド 1 にサークル タイプの遷移を適用します
    pres.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);

    // クリックで進むか、3 秒後に自動的に進むように設定します
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceAfterTime(3000);

    // スライド 2 にコンブ タイプの遷移を適用します
    pres.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb);
    
    // クリックで進むか、5 秒後に自動的に進むように設定します
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceAfterTime(5000);

    // スライド 3 にズーム タイプの遷移を適用します
    pres.getSlides().get_Item(2).getSlideShowTransition().setType(TransitionType.Zoom);
    
    // クリックで進むか、7 秒後に自動的に進むように設定します
    pres.getSlides().get_Item(2).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(2).getSlideShowTransition().setAdvanceAfterTime(7000);

    // プレゼンテーションをディスクに保存します
    pres.save("SampleTransition_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **モーフ遷移**
{{% alert color="info" %}} 

Aspose.Slides for Android via Java は現在、[Morph Transition](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/IMorphTransition) をサポートしています。これは PowerPoint 2019 で導入された新しいモーフ遷移です。

{{% /alert %}} 

モーフ遷移を使用すると、あるスライドから次のスライドへ滑らかな動きをアニメーション化できます。本稿ではモーフ遷移の概念と使用方法を説明します。モーフ遷移を有効に活用するには、少なくとも 1 つのオブジェクトが共通する 2 枚のスライドが必要です。最も簡単な方法はスライドを複製し、2 枚目のスライドでオブジェクトを別の位置に移動することです。

次のコードスニペットは、テキストを含むスライドのクローンをプレゼンテーションに追加し、2 枚目のスライドに [morph type](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/TransitionType) の遷移を設定する方法を示しています。

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

## **モーフ遷移の種類**
新しい [TransitionMorphType](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/TransitionMorphType) 列挙体が追加されました。これはモーフ スライド遷移のさまざまな種類を表します。

TransitionMorphType 列挙体には 3 つのメンバーがあります。

- ByObject: オブジェクトを不可分な形状として扱い、モーフ遷移を実行します。
- ByWord: 可能な場合は単語単位でテキストを転送しながらモーフ遷移を実行します。
- ByChar: 可能な場合は文字単位でテキストを転送しながらモーフ遷移を実行します。

以下のコードスニペットは、スライドにモーフ遷移を設定し、モーフ タイプを変更する方法を示しています。

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
Aspose.Slides for Android via Java は、黒からのフェード、左からのスライド、右からのスライドなどの遷移効果の設定をサポートしています。遷移効果を設定するには、以下の手順に従ってください。

- [Presentation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
- スライドの参照を取得します。
- 遷移効果を設定します。
- プレゼンテーションを [PPTX](https://docs.fileformat.com/presentation/pptx/) ファイルとして書き込みます。

以下の例では、遷移効果を設定しています。

```java
import com.aspose.slides.*;

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

## **FAQ**

### スライド遷移の再生速度を制御できますか？

はい。遷移の [speed](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/slideshowtransition/#setSpeed-int-) を、[TransitionSpeed](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/transitionspeed/) 設定（例：slow/medium/fast）で設定できます。

### 遷移にオーディオを添付してループ再生できますか？

はい。遷移にサウンドを埋め込み、サウンドモードやループ設定（例：[setSound](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/slideshowtransition/#setSound-com.aspose.slides.IAudio-)、[setSoundMode](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/slideshowtransition/#setSoundMode-int-)、[setSoundLoop](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/slideshowtransition/#setSoundLoop-boolean-)）で動作を制御できます。また、[setSoundIsBuiltIn](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/slideshowtransition/#setSoundIsBuiltIn-boolean-) や [setSoundName](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/slideshowtransition/#setSoundName-java.lang.String-) などのメタデータも設定可能です。

### すべてのスライドに同じ遷移を適用する最速の方法は？

各スライドの遷移設定で目的の遷移タイプを構成します。遷移はスライドごとに保存されるため、すべてのスライドに同一タイプを設定すれば一貫した結果になります。

### スライドに現在設定されている遷移を確認するには？

スライドの [transition settings](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/baseslide/#getSlideShowTransition--) を調べ、[transition type](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/slideshowtransition/#setType-int-) を取得します。その値が適用されている効果を正確に示します。