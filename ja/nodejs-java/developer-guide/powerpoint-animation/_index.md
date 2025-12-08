---
title: PowerPoint アニメーション
type: docs
weight: 150
url: /ja/nodejs-java/powerpoint-animation/
keywords: "PowerPoint アニメーション"
description: "PowerPoint アニメーション、Aspose.Slides を使用した PowerPoint スライド アニメーション。"
---

プレゼンテーションは何かを提示するために作られるので、作成時には常にその見た目とインタラクティブな動作が考慮されます。

**PowerPoint アニメーション** は、プレゼンテーションを視聴者にとって目を引く魅力的なものにするために重要な役割を果たします。Aspose.Slides for Node.js via Java では、PowerPoint プレゼンテーションにアニメーションを追加するための幅広いオプションが提供されています。

- さまざまな種類の PowerPoint アニメーション効果を、図形、チャート、テーブル、OLE オブジェクト、その他のプレゼンテーション要素に適用できます。
- 1 つの図形に複数の PowerPoint アニメーション効果を使用できます。
- アニメーションタイムラインを使ってアニメーション効果を制御できます。
- カスタムアニメーションを作成できます。

Aspose.Slides for Node.js via Java では、図形にさまざまなアニメーション効果を適用できます。スライド上のテキスト、画像、OLE オブジェクト、テーブルなど、すべての要素は図形として扱われるため、スライド上のあらゆる要素にアニメーション効果を適用できることを意味します。

## **Animation Effects**
Aspose.Slides は **150 以上のアニメーション効果** をサポートしており、Bounce や PathFootball、Zoom などの基本効果や、OLEObjectShow、OLEObjectOpen などの特定効果が含まれます。すべてのアニメーション効果の一覧は [**EffectType**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effecttype/) 列挙体で確認できます。

さらに、これらのアニメーション効果は次の効果と組み合わせて使用できます。

- [ColorEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ColorEffect)
- [CommandEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/CommandEffect)
- [FilterEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FilterEffect)
- [MotionEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MotionEffect)
- [PropertyEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PropertyEffect)
- [RotationEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/RotationEffect)
- [ScaleEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ScaleEffect)
- [SetEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SetEffect)

## **Custom Animation**
Aspose.Slides では **カスタム アニメーション** を作成できます。複数のビヘイビアを組み合わせて新しいカスタム アニメーションを作成することで実現できます。

[**Behavior**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Behavior) は PowerPoint アニメーション効果の構成単位です。すべてのアニメーション効果は実際にはビヘイビアの集合であり、1 つの戦略にまとめられます。ビヘイビアをカスタム アニメーションに一度だけ組み合わせておけば、他のプレゼンテーションでも再利用できます。標準の PowerPoint アニメーション効果に新しいビヘイビアを追加すれば、別のカスタム アニメーションとなります。たとえば、アニメーションにリピート ビヘイビアを追加して数回繰り返すように設定できます。

[**Animation Point**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Point) はビヘイビアを適用すべき位置を示すポイントです。

## **Animation Time Line**
[**Sequence**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Sequence) は、特定の図形に適用されるアニメーション効果のコレクションです。

[**Timeline**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AnimationTimeLine) は、特定のスライドで使用される Sequence の集合です。PowerPoint 2002 以降で導入されたアニメーション エンジンで、従来の AnimationSettings クラスに代わり、PowerPoint アニメーション向けにより明確なオブジェクト モデルを提供します。1 つのスライドには **1 つの** アニメーション タイムラインしか設定できません。

## **Interactive Animation**
[**Trigger**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/EffectTriggerType) を使用すると、ユーザー操作（例: ボタンのクリック）に応じて特定のアニメーションを開始できます。トリガーは最新バージョンの PowerPoint にのみ追加されました。

## **Shape Animation**
Aspose.Slides では、テキスト、矩形、線、フレーム、OLE オブジェクトなど、実際には図形として扱われる要素にアニメーションを適用できます。

{{% alert color="primary" %}} 
詳しく読む [**About Shape Animation**](/slides/ja/nodejs-java/shape-animation/)。
{{% /alert %}}

## **Animated Charts**
アニメーション チャートを作成するには、図形と同じクラスを使用します。ただし、PowerPoint アニメーションはチャートのカテゴリまたは系列のみに適用できます。カテゴリ要素や系列要素にアニメーション効果を適用することも可能です。

{{% alert color="primary" %}} 
詳しく読む [**About Animated Charts**](/slides/ja/nodejs-java/animated-charts/)。
{{% /alert %}}

## **Animated text**
アニメーション テキストに加えて、段落全体にアニメーションを適用することも可能です。

{{% alert color="primary" %}} 
詳しく読む [**About Animated Text**](/slides/ja/nodejs-java/animated-text/)。
{{% /alert %}}

## **FAQ**

**Will animations be preserved when exporting to PDF?**

No. PDF is a static format, so animations and [slide transitions](/slides/ja/nodejs-java/slide-transition/) don’t play. If you need motion, export to [HTML5](/slides/ja/nodejs-java/export-to-html5/), [animated GIF](/slides/ja/nodejs-java/convert-powerpoint-to-animated-gif/), or [video](/slides/ja/nodejs-java/convert-powerpoint-to-video/) instead.

**Can I turn an animated presentation into a video and control the frame rate and frame size?**

Yes. You can [render the presentation as frames](/slides/ja/nodejs-java/convert-powerpoint-to-video/) and encode them into a video (e.g., via ffmpeg), choosing the FPS and resolution. Animations and slide transitions are played during rendering.

**Will animations remain intact when working with ODP (not just PPTX)?**

PPT, PPTX, and ODP are supported for [reading](/slides/ja/nodejs-java/open-presentation/) and [writing](/slides/ja/nodejs-java/save-presentation/), but format differences mean certain effects may look or behave slightly differently. Validate critical cases with real samples.