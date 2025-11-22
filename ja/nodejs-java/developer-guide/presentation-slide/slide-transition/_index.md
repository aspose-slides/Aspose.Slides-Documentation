---
title: スライド遷移
type: docs
weight: 80
url: /ja/nodejs-java/slide-transition/
keywords: "PowerPoint スライド遷移、JavaScript におけるモーフ遷移"
description: "PowerPoint スライド遷移、JavaScript における PowerPoint モーフ遷移"
---

## **概要**
{{% alert color="primary" %}} 

Aspose.Slides for Node.js via Java でも、開発者はスライドの遷移効果を管理およびカスタマイズできます。このトピックでは、Aspose.Slides for Node.js via Java を使用してスライド遷移を簡単に制御する方法について説明します。

{{% /alert %}} 

理解しやすくするために、Aspose.Slides for Node.js via Java を使用してシンプルなスライド遷移を管理する方法を示しています。開発者はスライドにさまざまな遷移効果を適用できるだけでなく、これらの効果の動作をカスタマイズすることも可能です。

## **スライド トランジションの追加**
シンプルなスライド遷移効果を作成するには、以下の手順に従います。

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) クラスのインスタンスを作成します。
2. Aspose.Slides for Node.js via Java が提供する遷移効果のいずれかから、TransitionType 列挙体を使用してスライドに Slide Transition Type を適用します。
3. 変更したプレゼンテーション ファイルを書き込みます。
```javascript
// ソースプレゼンテーションファイルを読み込むために Presentation クラスをインスタンス化
var presentation = new aspose.slides.Presentation("AccessSlides.pptx");
try {
    // スライド 1 に円形遷移を適用
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(aspose.slides.TransitionType.Circle);
    // スライド 2 にコーム形遷移を適用
    presentation.getSlides().get_Item(1).getSlideShowTransition().setType(aspose.slides.TransitionType.Comb);
    // プレゼンテーションをディスクに保存
    presentation.save("SampleTransition_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **高度なスライド トランジションの追加**
上記のセクションではシンプルな遷移効果のみを適用しました。ここでは、その遷移効果をさらに制御できるように、以下の手順に従ってください。

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) クラスのインスタンスを作成します。
2. Aspose.Slides for Node.js via Java が提供する遷移効果のいずれかから、スライドに Slide Transition Type を適用します。
3. 遷移を「クリックで進む」(Advance On Click) に設定したり、特定の時間が経過した後に自動で進むように設定したり、両方を組み合わせることができます。
4. 「クリックで進む」設定が有効な場合、マウスクリック時にのみ遷移が進みます。さらに、Advance After Time プロパティを設定すると、指定した時間が経過した後に自動で遷移が進みます。
5. 変更したプレゼンテーションをファイルとして書き込みます。
```javascript
// プレゼンテーションファイルを表す Presentation クラスをインスタンス化
var pres = new aspose.slides.Presentation("BetterSlideTransitions.pptx");
try {
    // スライド 1 に円形遷移を適用
    pres.getSlides().get_Item(0).getSlideShowTransition().setType(aspose.slides.TransitionType.Circle);
    // 遷移時間を 3 秒に設定
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceAfterTime(3000);
    // スライド 2 にコーム形遷移を適用
    pres.getSlides().get_Item(1).getSlideShowTransition().setType(aspose.slides.TransitionType.Comb);
    // 遷移時間を 5 秒に設定
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceAfterTime(5000);
    // スライド 3 にズーム遷移を適用
    pres.getSlides().get_Item(2).getSlideShowTransition().setType(aspose.slides.TransitionType.Zoom);
    // 遷移時間を 7 秒に設定
    pres.getSlides().get_Item(2).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(2).getSlideShowTransition().setAdvanceAfterTime(7000);
    // プレゼンテーションをディスクに保存
    pres.save("SampleTransition_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


## **モーフ トランジション**
{{% alert color="primary" %}} 

Aspose.Slides for Node.js via Java は、[Morph Transition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MorphTransition) をサポートしています。これは PowerPoint 2019 で導入された新しいモーフ遷移です。

{{% /alert %}} 

モーフ遷移を使用すると、あるスライドから次のスライドへ滑らかな動きをアニメーション化できます。この記事では、モーフ遷移の概念と使用方法を説明します。モーフ遷移を効果的に使用するには、少なくとも 1 つの共通オブジェクトを持つ 2 つのスライドが必要です。最も簡単な方法は、スライドを複製し、2 番目のスライド上でオブジェクトを別の位置に移動することです。

以下のコードスニペットは、テキストを含むスライドのクローンをプレゼンテーションに追加し、2 番目のスライドに [morph type](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TransitionType) の遷移を設定する方法を示しています。
```javascript
var presentation = new aspose.slides.Presentation();
try {
    var autoshape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 400, 100);
    autoshape.getTextFrame().setText("Morph Transition in PowerPoint Presentations");
    presentation.getSlides().addClone(presentation.getSlides().get_Item(0));
    var shape = presentation.getSlides().get_Item(1).getShapes().get_Item(0);
    shape.setX(shape.getX() + 100);
    shape.setY(shape.getY() + 50);
    shape.setWidth(shape.getWidth() - 200);
    shape.setHeight(shape.getHeight() - 10);
    presentation.getSlides().get_Item(1).getSlideShowTransition().setType(aspose.slides.TransitionType.Morph);
    presentation.save("presentation-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **モーフ トランジションの種類**
新しい [TransitionMorphType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TransitionMorphType) 列挙体が追加されました。これはモーフスライド遷移のさまざまなタイプを表します。

TransitionMorphType 列挙体には次の 3 つのメンバーがあります。

- ByObject: 形状を分割できないオブジェクトとして扱い、モーフ遷移を実行します。
- ByWord: 可能な場合、単語単位でテキストを転送してモーフ遷移を実行します。
- ByChar: 可能な場合、文字単位でテキストを転送してモーフ遷移を実行します。

以下のコードスニペットは、スライドにモーフ遷移を設定し、モーフタイプを変更する方法を示しています。
```javascript
var presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(aspose.slides.TransitionType.Morph);
    presentation.getSlides().get_Item(0).getSlideShowTransition().getValue().setMorphType(aspose.slides.TransitionMorphType.ByWord);
    presentation.save("presentation-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **トランジション効果の設定**
Aspose.Slides for Node.js via Java は、黒から、左から、右からなどのトランジション効果の設定をサポートしています。トランジション効果を設定するには、以下の手順に従ってください。

- [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) クラスのインスタンスを作成します。
- スライドの参照を取得します。
- トランジション効果を設定します。
- プレゼンテーションを [PPTX](https://docs.fileformat.com/presentation/pptx/) ファイルとして書き込みます。

以下の例では、トランジション効果を設定しています。
```javascript
// Presentation クラスのインスタンスを作成
var presentation = new aspose.slides.Presentation("AccessSlides.pptx");
try {
    // エフェクトを設定
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(aspose.slides.TransitionType.Cut);
    presentation.getSlides().get_Item(0).getSlideShowTransition().getValue().setFromBlack(true);
    // プレゼンテーションをディスクに保存
    presentation.save("SetTransitionEffects_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **FAQ**

**スライド遷移の再生速度を制御できますか？**

はい。TransitionSpeed 設定 (例: slow/medium/fast) を使用して、遷移の [speed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/setspeed/) を設定します。

**遷移にオーディオを添付し、ループさせることはできますか？**

はい。遷移にサウンドを埋め込み、sound mode や looping などの設定 (例: [setSound](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/setsound/)、[setSoundMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/setsoundmode/)、[setSoundLoop](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/setsoundloop/)) を使用できます。また、[setSoundIsBuiltIn](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/setsoundisbuiltin/) や [setSoundName](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/setsoundname/) などのメタデータも設定可能です。

**すべてのスライドに同じ遷移を適用する最速の方法は何ですか？**

各スライドの遷移設定で目的の遷移タイプを構成します。遷移はスライド単位で保存されるため、すべてのスライドに同じタイプを設定すれば一貫した結果が得られます。

**スライドに現在設定されている遷移を確認するにはどうすればよいですか？**

スライドの [transition settings](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseslide/#getSlideShowTransition) を確認し、[transition type](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/gettype/) を取得します。その値が適用されている効果を正確に示します。