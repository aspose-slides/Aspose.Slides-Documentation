---
title: PowerPoint アニメーション
type: docs
weight: 150
url: /python-net/powerpoint-animation/
keywords: "アニメーション, アニメーション効果, PowerPoint アニメーション, アニメーションタイムライン, インタラクティブアニメーション, 形状アニメーション, アニメーションチャート, アニメーションテキスト, PowerPoint プレゼンテーション, Python, Aspose.Slides for Python via .NET"
description: "Python における PowerPoint プレゼンテーションのアニメーションと効果"
---

プレゼンテーションは何かを提示するためのものであるため、その視覚的な外観やインタラクティブな動作は作成時に常に考慮されます。

**PowerPoint アニメーション**は、プレゼンテーションを視覚的に魅力的で観客の注意を引くものにするために重要な役割を果たします。Aspose.Slides for Python via .NET は、PowerPoint プレゼンテーションにアニメーションを追加するための幅広いオプションを提供します：

- 形状、チャート、テーブル、OLEオブジェクトなどのプレゼンテーション要素にさまざまなタイプの PowerPoint アニメーション効果を適用します。
- 1 つの形状に対して複数の PowerPoint アニメーション効果を使用します。
- アニメーション効果を制御するためにアニメーションタイムラインを使用します。
- カスタムアニメーションを作成します。

Aspose.Slides for Python via .NET では、さまざまなアニメーション効果を形状に適用できます。スライド上のすべての要素（テキスト、画像、OLEオブジェクト、テーブルなどを含む）は形状と見なされるため、スライドのすべての要素にアニメーション効果を適用できることを意味します。

[**Aspose.Slides.Animation**](https://reference.aspose.com/slides/python-net/aspose.slides.animation/) **名前空間** は、PowerPoint アニメーションを操作するためのクラスを提供します。
## **アニメーション効果**
Aspose.Slides は、バウンス、パスフットボール、ズーム効果、OLE オブジェクトの表示やOLE オブジェクトの開きなどの特定のアニメーション効果を含む**150以上のアニメーション効果**をサポートしています。アニメーション効果の完全なリストは、[**EffectType**](https://reference.aspose.com/slides/python-net/aspose.slides.animation/effecttype/)列挙型で見つけることができます。

さらに、これらのアニメーション効果は次の組み合わせで使用できます：

- [ColorEffect](https://reference.aspose.com/slides/python-net/aspose.slides.animation/coloreffect/)
- [CommandEffect](https://reference.aspose.com/slides/python-net/aspose.slides.animation/commandeffect/)
- [FilterEffect](https://reference.aspose.com/slides/python-net/aspose.slides.animation/filtereffect/)
- [MotionEffect](https://reference.aspose.com/slides/python-net/aspose.slides.animation/motioneffect/)
- [PropertyEffect](https://reference.aspose.com/slides/python-net/aspose.slides.animation/propertyeffect/)
- [RotationEffect](https://reference.aspose.com/slides/python-net/aspose.slides.animation/rotationeffect)
- [ScaleEffect](https://reference.aspose.com/slides/python-net/aspose.slides.animation/scaleeffect/)
- [SetEffect](https://reference.aspose.com/slides/python-net/aspose.slides.animation/seteffect/)
## **カスタムアニメーション**
Aspose.Slides では、独自の**カスタムアニメーション**を作成することが可能です。
これは、いくつかの動作を組み合わせて新しいカスタムアニメーションにすることで達成できます。

[**Behaviour**](https://reference.aspose.com/slides/python-net/aspose.slides.animation/behavior/) は、任意の PowerPoint アニメーション効果の構成要素です。すべてのアニメーション効果は、実際には1つの戦略に組み合わされた動作のセットです。動作をカスタムアニメーションに一度組み合わせると、他のプレゼンテーションで再利用できます。標準の PowerPoint アニメーション効果に新しい動作を追加すると、それは別のカスタムアニメーションになります。例えば、アニメーションに繰り返し動作を追加して、数回繰り返すようにすることができます。

[**Animation Point**](https://reference.aspose.com/slides/python-net/aspose.slides.animation/point/) は、動作が適用されるポイントです。
## **アニメーションタイムライン**
[**Sequence**](https://reference.aspose.com/slides/python-net/aspose.slides.animation/sequence/) は、特定の形状に適用されるアニメーション効果のコレクションです。

[**Timeline**](https://reference.aspose.com/slides/python-net/aspose.slides.animation/animationtimeline/) は、特定のスライドで使用されるシーケンスのセットです。これは、PowerPoint 2002 以来のアニメーションエンジンです。以前の PowerPoint バージョンでは、アニメーション効果をプレゼンテーションに追加することが難しく、さまざまな回避策のみで達成されていました。タイムラインは、古い AnimationSettings クラスを置き換え、PowerPoint アニメーションのより明確なオブジェクトモデルを提供します。1つのスライドには、1つのアニメーションタイムラインしかありません。
## **インタラクティブアニメーション**
[**Trigger**](https://reference.aspose.com/slides/python-net/aspose.slides.animation/effecttriggertype/) は、特定のアニメーションを開始するユーザーアクション（例：ボタンクリック）を定義することを可能にします。トリガーは、最新の PowerPoint バージョンにのみ追加されています。
## **形状アニメーション**
Aspose.Slides は、実際にテキスト、長方形、線、フレーム、OLE オブジェクトなどにアニメーションを適用することを許可します。

{{% alert color="primary" %}} 
詳細については、[**形状アニメーションについて**](/slides/python-net/shape-animation/)をお読みください。
{{% /alert %}}

## **アニメーションチャート**
アニメーションチャートを作成するには、形状のためと同じクラスを使用する必要があります。ただし、PowerPoint アニメーションはチャートカテゴリまたはチャート系列にのみ使用可能です。また、カテゴリ要素または系列要素にアニメーション効果を適用することもできます。

{{% alert color="primary" %}} 
詳細については、[**アニメーションチャートについて**](/slides/python-net/animated-charts/)をお読みください。
{{% /alert %}}

## **アニメーションテキスト**
アニメーションテキストに加えて、段落にアニメーションを適用することも可能です。

{{% alert color="primary" %}} 
詳細については、[**アニメーションテキストについて**](/slides/python-net/animated-text/)をお読みください。
{{% /alert %}}