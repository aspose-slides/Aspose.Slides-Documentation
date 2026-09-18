---
title: Python でアニメーションを使用して PowerPoint プレゼンテーションを強化する
linktitle: PowerPoint アニメーション
type: docs
weight: 150
url: /ja/python-net/powerpoint-animation/
keywords:
- アニメーションを追加
- アニメーションを更新
- アニメーションを変更
- アニメーションを削除
- アニメーションを管理
- アニメーションを制御
- アニメーション効果
- PowerPoint アニメーション
- アニメーション タイムライン
- インタラクティブ アニメーション
- カスタム アニメーション
- 図形アニメーション
- アニメーション チャート
- アニメーション テキスト
- アニメーション 図形
- アニメーション OLE オブジェクト
- アニメーション 画像
- アニメーション 表
- PowerPoint プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET が PowerPoint アニメーションを処理する機能を探ります。この一般的な概要では主な機能をハイライトし、プレゼンテーションを向上させるための洞察を提供します。"
---
## **導入**

プレゼンテーションは情報を伝えることが目的なので、視覚的な外観やインタラクティブな動作は作成時の重要な考慮事項です。

**PowerPoint アニメーション** は、プレゼンテーションを目を引くものにし、視聴者を引きつける重要な役割を果たします。Aspose.Slides for Python via .NET は、PowerPoint プレゼンテーションにアニメーションを追加するための幅広いオプションを提供します。できることは次のとおりです。

- 図形、グラフ、表、OLE オブジェクト、その他の要素にさまざまなアニメーション効果を適用する。
- 1 つの図形に複数のアニメーション効果を使用する。
- アニメーション タイムラインで効果を制御する。
- カスタム アニメーションを作成する。

Aspose.Slides for Python via .NET では、図形にアニメーション効果を適用できます。スライド上のすべての要素（テキスト、画像、OLE オブジェクト、表など）は図形として扱われるため、スライド上の任意の要素にアニメーション効果を適用できます。

[aspose.slides.animation](https://reference.aspose.com/slides/ja/python-net/aspose.slides.animation/) 名前空間は、PowerPoint アニメーションを扱うクラスを提供します。

## **インストール**

```bash
pip install aspose.slides
```

## **Python で図形にアニメーション効果を追加する**

アニメーション効果はスライドのメイン シーケンスに存在します。図形を追加し、`slide.timeline.main_sequence` の `add_effect` を呼び出して、効果タイプ、サブタイプ、開始トリガーを渡します。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 300, 100)
    shape.text_frame.text = "Animated shape"

    sequence = slide.timeline.main_sequence
    effect = sequence.add_effect(
        shape,
        slides.animation.EffectType.FLY,
        slides.animation.EffectSubtype.LEFT,
        slides.animation.EffectTriggerType.ON_CLICK,
    )
    effect.timing.duration = 2.0

    presentation.save("animated.pptx", slides.export.SaveFormat.PPTX)
```

保存されたファイルには、最初のスライドに 1 つの効果が含まれています。矩形が左側から 2 秒かけて飛び込んできて、プレゼンテーターがクリックすると再生されます。再度開いて `slide.timeline.main_sequence` を読み取るとその効果が返されるため、アニメーションはメモリ上にだけ残るのではなく、往復の間でも保持されます。

## **アニメーション効果**

Aspose.Slides は **150 以上のアニメーション効果** をサポートしており、Bounce、PathFootball、Zoom といった基本効果から、OLEObjectShow、OLEObjectOpen といった特殊効果まで含まれます。完全な一覧は [EffectType](https://reference.aspose.com/slides/ja/python-net/aspose.slides.animation/effecttype/) 列挙体で確認できます。

さらに、これらのアニメーション効果は次の効果と組み合わせることができます。

- [ColorEffect](https://reference.aspose.com/slides/ja/python-net/aspose.slides.animation/coloreffect/)
- [CommandEffect](https://reference.aspose.com/slides/ja/python-net/aspose.slides.animation/commandeffect/)
- [FilterEffect](https://reference.aspose.com/slides/ja/python-net/aspose.slides.animation/filtereffect/)
- [MotionEffect](https://reference.aspose.com/slides/ja/python-net/aspose.slides.animation/motioneffect/)
- [PropertyEffect](https://reference.aspose.com/slides/ja/python-net/aspose.slides.animation/propertyeffect/)
- [RotationEffect](https://reference.aspose.com/slides/ja/python-net/aspose.slides.animation/rotationeffect)
- [ScaleEffect](https://reference.aspose.com/slides/ja/python-net/aspose.slides.animation/scaleeffect/)
- [SetEffect](https://reference.aspose.com/slides/ja/python-net/aspose.slides.animation/seteffect/)

## **カスタム アニメーション**

作成、検査、変更が可能な Python の完全なサンプルは、[カスタム アニメーション](/slides/ja/python-net/custom-animation/) を参照してください。

Aspose.Slides では、複数のビヘイビアを 1 つの効果に組み合わせて **カスタム アニメーション** を作成できます。

[Behavior](https://reference.aspose.com/slides/ja/python-net/aspose.slides.animation/behavior/) は PowerPoint アニメーション効果の構成要素です。ビヘイビアを組み合わせて効果をカスタマイズしたり、ビヘイビアを追加して既定の効果を拡張したりできます。繰り返しは別個の repeat ビヘイビアではなく、タイミング設定で構成します。

[Animation Point](https://reference.aspose.com/slides/ja/python-net/aspose.slides.animation/point/) は、ビヘイビアが適用される瞬間または位置（キーフレーム）を示します。

## **アニメーション タイムライン**

[Sequence](https://reference.aspose.com/slides/ja/python-net/aspose.slides.animation/sequence/) は、異なる図形を対象にできるアニメーション効果のコレクションです。

[Timeline](https://reference.aspose.com/slides/ja/python-net/aspose.slides.animation/animationtimeline/) は、特定のスライドで使用されるシーケンスの集合です。PowerPoint 2002 で導入されました。以前のバージョンではアニメーション効果の追加が難しく、回避策が必要でした。タイムラインは旧 `AnimationSettings` クラスに取って代わり、PowerPoint アニメーション用のより明確なオブジェクト モデルを提供します。各スライドには 1 つのアニメーション タイムラインしか持てません。

## **インタラクティブ アニメーション**

[Trigger](https://reference.aspose.com/slides/ja/python-net/aspose.slides.animation/effecttriggertype/) を使用すると、ユーザー アクション（例: ボタンのクリック）で特定のアニメーションを開始できます。トリガーは最新バージョンの PowerPoint でのみ追加されました。

## **図形アニメーション**

Aspose.Slides では、テキスト、矩形、線、フレーム、OLE オブジェクトなどの図形にアニメーションを適用できます。

{{% alert color="info" title="Note" %}}
詳細は [**図形アニメーションについて**](/slides/ja/python-net/shape-animation/) を参照してください。
{{% /alert %}}

## **アニメーション チャート**

アニメーション チャートを作成するには、図形と同じクラスを使用します。ただし、PowerPoint のアニメーションはチャートのカテゴリまたは系列にのみ適用でき、個別のカテゴリ要素や系列要素にも効果を付与できます。

{{% alert color="info" title="Note" %}}
詳細は [**アニメーション チャートについて**](/slides/ja/python-net/animated-charts/) を参照してください。
{{% /alert %}}

## **アニメーション テキスト**

テキストのアニメーションに加えて、段落全体にアニメーションを適用できます。

{{% alert color="info" title="Note" %}}
詳細は [**アニメーション テキストについて**](/slides/ja/python-net/animated-text/) を参照してください。
{{% /alert %}}

## **FAQ**

**PDF にエクスポートしたときにアニメーションは保存されますか？**

いいえ。PDF は静的フォーマットのため、アニメーションや [スライド トランジション](/slides/ja/python-net/slide-transition/) は再生されません。動きを必要とする場合は、[HTML5](/slides/ja/python-net/export-to-html5/)、[アニメーション GIF](/slides/ja/python-net/convert-powerpoint-to-animated-gif/)、または [ビデオ](/slides/ja/python-net/convert-powerpoint-to-video/) にエクスポートしてください。

**アニメーション付きプレゼンテーションをビデオに変換し、フレームレートやフレームサイズを制御できますか？**

はい。プレゼンテーションをフレームとして [レンダリング](/slides/ja/python-net/convert-powerpoint-to-video/)し、ffmpeg などでビデオにエンコードすれば、FPS と解像度を選択できます。レンダリング中にアニメーションとスライド トランジションが再生されます。

**ODP（PPTX だけでなく）で作業する場合、アニメーションはそのまま残りますか？**

PPT、PPTX、ODP は [読み取り](/slides/ja/python-net/open-presentation/) と [書き込み](/slides/ja/python-net/save-presentation/) がサポートされていますが、アニメーションが保持されることは保証されません。ODP への変換時にカスタム アニメーション データが失われる可能性があります。形式互換性の確認方法は、[カスタム アニメーション](/slides/ja/python-net/custom-animation/) のサンプルをご参照ください。