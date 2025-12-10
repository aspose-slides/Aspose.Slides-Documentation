---
title: ".NET で PowerPoint プレゼンテーションにアニメーションを追加する"
linktitle: "PowerPoint アニメーション"
type: docs
weight: 150
url: /ja/net/powerpoint-animation/
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
- シェイプ アニメーション
- アニメーション化されたチャート
- アニメーション化されたテキスト
- アニメーション化されたシェイプ
- アニメーション化された OLE オブジェクト
- アニメーション化された画像
- アニメーション化されたテーブル
- PowerPoint プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET が提供する PowerPoint アニメーションの機能を探ります。この一般的な概要では、主な機能をハイライトし、プレゼンテーションを向上させるための洞察を提供します。"
---

## **概要**

プレゼンテーションは何かを提示することが目的であるため、作成時には常に視覚的な外観とインタラクティブな動作が考慮されます。

**PowerPoint animation** は、プレゼンテーションを視覚的に魅力的かつ引き込むものにする重要な役割を果たします。Aspose.Slides for .NET は、PowerPoint プレゼンテーションにアニメーションを追加するための幅広いオプションを提供します。

- 図形、グラフ、表、OLE オブジェクト、その他のプレゼンテーション要素にさまざまな種類の PowerPoint アニメーション効果を適用します。
- 1 つの図形に複数の PowerPoint アニメーション効果を使用します。
- アニメーションタイムラインを利用してアニメーション効果を制御します。
- カスタム アニメーションを作成します。

Aspose.Slides for .NET では、さまざまなアニメーション効果を図形に適用できます。スライド上のテキスト、画像、OLE オブジェクト、表など、すべての要素は図形とみなされるため、スライド上の任意の要素にアニメーション効果を適用できます。

[Aspose.Slides.Animation](https://reference.aspose.com/slides/net/aspose.slides.animation/) 名前空間は、PowerPoint アニメーションを操作するためのクラスを提供します。

## **アニメーション効果**

Aspose.Slides は **150 以上のアニメーション効果** をサポートしており、Bounce、PathFootball、Zoom といった基本効果から OLEObjectShow、OLEObjectOpen といった特殊効果まで含まれます。アニメーション効果の完全な一覧は [EffectType](https://reference.aspose.com/slides/net/aspose.slides.animation/effecttype) 列挙体で確認できます。

さらに、これらのアニメーション効果は以下と組み合わせて使用できます。

- [ColorEffect](https://reference.aspose.com/slides/net/aspose.slides.animation/coloreffect)
- [CommandEffect](https://reference.aspose.com/slides/net/aspose.slides.animation/commandeffect)
- [FilterEffect](https://reference.aspose.com/slides/net/aspose.slides.animation/filtereffect)
- [MotionEffect](https://reference.aspose.com/slides/net/aspose.slides.animation/motioneffect)
- [PropertyEffect](https://reference.aspose.com/slides/net/aspose.slides.animation/propertyeffect)
- [RotationEffect](https://reference.aspose.com/slides/net/aspose.slides.animation/rotationeffect)
- [ScaleEffect](https://reference.aspose.com/slides/net/aspose.slides.animation/scaleeffect)
- [SetEffect](https://reference.aspose.com/slides/net/aspose.slides.animation/seteffect)

## **カスタム アニメーション**

Aspose.Slides では **カスタム アニメーション** を作成できます。これは、複数のビヘイビアを組み合わせて新しいカスタム アニメーションを作ることで実現します。

[Behaviour](https://reference.aspose.com/slides/net/aspose.slides.animation/behavior) は任意の PowerPoint アニメーション効果の構成要素です。すべてのアニメーション効果は本質的にビヘイビアの集合で構成されます。ビヘイビアをカスタム アニメーションにまとめておけば、他のプレゼンテーションでも再利用できます。標準の PowerPoint アニメーション効果に新しいビヘイビアを追加すると、別のカスタム アニメーションとなります。たとえば、アニメーションにリピート ビヘイビアを追加して数回繰り返すように設定できます。

[Animation Point](https://reference.aspose.com/slides/net/aspose.slides.animation/point) はビヘイビアを適用する位置を示すポイントです。

## **アニメーション タイムライン**

[Sequence](https://reference.aspose.com/slides/net/aspose.slides.animation/sequence) は特定の図形に適用されるアニメーション効果のコレクションです。

[Timeline](https://reference.aspose.com/slides/net/aspose.slides.animation/animationtimeline) は特定のスライドで使用されるシーケンスの集合です。これは PowerPoint 2002 で導入されたアニメーションエンジンで、従来の AnimationSettings クラスに代わり、PowerPoint アニメーションのオブジェクトモデルをより明確にします。スライドには 1 つのアニメーション タイムラインしか持てません。

## **インタラクティブ アニメーション**

[Trigger](https://reference.aspose.com/slides/net/aspose.slides.animation/effecttriggertype) を使用すると、ボタンのクリックなどのユーザー操作を定義でき、特定のアニメーションを開始させることができます。トリガーは最新バージョンの PowerPoint で導入されました。

## **シェイプ アニメーション**

Aspose.Slides は、テキスト、長方形、線、フレーム、OLE オブジェクトなど、さまざまな図形にアニメーションを適用できます。

{{% alert color="primary" %}} 
Read more [**シェイプ アニメーションについて**](/slides/ja/net/shape-animation/).
{{% /alert %}}

## **アニメーション化されたチャート**

アニメーション化されたチャートを作成するには、図形と同じクラスを使用します。ただし、PowerPoint のアニメーションはチャートのカテゴリまたは系列にのみ適用でき、カテゴリ要素や系列要素にもアニメーション効果を付与できます。

{{% alert color="primary" %}} 
Read more [**アニメーション化されたチャートについて**](/slides/ja/net/animated-charts/).
{{% /alert %}}

## **アニメーション テキスト**

アニメーションテキストに加えて、段落単位でアニメーションを適用することも可能です。

{{% alert color="primary" %}} 
Read more [**アニメーション テキストについて**](/slides/ja/net/animated-text/).
{{% /alert %}}

## **FAQ**

**アニメーションは PDF にエクスポートしても保持されますか？**

いいえ。PDF は静的フォーマットであるため、アニメーションや[スライドトランジション](/slides/ja/net/slide-transition/)は再生されません。動きを必要とする場合は、[HTML5](/slides/ja/net/export-to-html5/)、[アニメーション GIF](/slides/ja/net/convert-powerpoint-to-animated-gif/)、または[ビデオ](/slides/ja/net/convert-powerpoint-to-video/)にエクスポートしてください。

**アニメーション付きプレゼンテーションをビデオに変換し、フレームレートやフレームサイズを制御できますか？**

はい。プレゼンテーションをフレームとして[レンダリング](/slides/ja/net/convert-powerpoint-to-video/)し、ffmpeg などでビデオにエンコードすれば、FPS と解像度を指定できます。レンダリング中にアニメーションとスライドトランジションが再生されます。

**ODP（PPTX だけでなく）でもアニメーションは保持されますか？**

PPT、PPTX、ODP は[読み取り](/slides/ja/net/open-presentation/)と[書き込み](/slides/ja/net/save-presentation/)の両方でサポートされていますが、フォーマットの違いにより一部の効果が若干異なる表示・動作になる場合があります。重要なケースは実際のサンプルで検証してください。