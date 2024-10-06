---
title: PowerPointアニメーション
type: docs
weight: 150
url: /ja/net/powerpoint-animation/
keywords: "アニメーション, アニメーション効果, PowerPointアニメーション, アニメーションタイムライン, インタラクティブアニメーション, 形状アニメーション, アニメーションチャート, アニメーションテキスト, PowerPointプレゼンテーション, C#, Csharp, Aspose.Slides for .NET"
description: "C#または.NETにおけるPowerPointプレゼンテーションのアニメーションと効果"
---

プレゼンテーションは何かを提示するためのものであるため、作成する際には視覚的な外観とインタラクティブな動作が常に考慮されます。

**PowerPointアニメーション**は、プレゼンテーションを視聴者にとって魅力的で目を引くものにするために重要な役割を果たします。Aspose.Slides for .NETは、PowerPointプレゼンテーションにアニメーションを追加するための幅広いオプションを提供します。

- 形状、チャート、表、OLEオブジェクトおよび他のプレゼンテーション要素にさまざまなタイプのPowerPointアニメーション効果を適用します。
- 1つの形状に複数のPowerPointアニメーション効果を使用します。
- アニメーション効果を制御するためにアニメーションタイムラインを使用します。
- カスタムアニメーションを作成します。

Aspose.Slides for .NETでは、さまざまなアニメーション効果を形状に適用できます。スライド上のすべての要素（テキスト、画像、OLEオブジェクト、表など）は形状と見なされるため、スライドのすべての要素にアニメーション効果を適用することができます。

[**Aspose.Slides.Animation**](https://reference.aspose.com/slides/net/aspose.slides.animation/) **名前空間**は、PowerPointアニメーションを操作するためのクラスを提供します。
## **アニメーション効果**
Aspose.Slidesは、**150以上のアニメーション効果**をサポートしており、BounceやPathFootball、Zoom効果などの基本的なアニメーション効果や、OLEObjectShow、OLEObjectOpenなどの特定のアニメーション効果を含みます。アニメーション効果の完全なリストは、[**EffectType**](https://reference.aspose.com/slides/net/aspose.slides.animation/effecttype)列挙型で確認できます。

さらに、これらのアニメーション効果は次のものと組み合わせて使用できます。

- [ColorEffect](https://reference.aspose.com/slides/net/aspose.slides.animation/coloreffect)
- [CommandEffect](https://reference.aspose.com/slides/net/aspose.slides.animation/commandeffect)
- [FilterEffect](https://reference.aspose.com/slides/net/aspose.slides.animation/filtereffect)
- [MotionEffect](https://reference.aspose.com/slides/net/aspose.slides.animation/motioneffect)
- [PropertyEffect](https://reference.aspose.com/slides/net/aspose.slides.animation/propertyeffect)
- [RotationEffect](https://reference.aspose.com/slides/net/aspose.slides.animation/rotationeffect)
- [ScaleEffect](https://reference.aspose.com/slides/net/aspose.slides.animation/scaleeffect)
- [SetEffect](https://reference.aspose.com/slides/net/aspose.slides.animation/seteffect)
## **カスタムアニメーション**
Aspose.Slidesでは、自分ownの**カスタムアニメーション**を作成することが可能です。これは、いくつかの動作を組み合わせて新しいカスタムアニメーションを作成することで実現できます。

[**Behaviour**](https://reference.aspose.com/slides/net/aspose.slides.animation/behavior)は、いかなるPowerPointアニメーション効果の構成要素です。すべてのアニメーション効果は実際には1つの戦略に組み合わされた動作のセットです。動作を一度カスタムアニメーションにまとめると、それを他のプレゼンテーションで再利用できます。標準のPowerPointアニメーション効果に新しい動作を追加すると、それは別のカスタムアニメーションになります。たとえば、アニメーションに繰り返し動作を追加して、何回も繰り返すようにすることができます。

[**Animation Point**](https://reference.aspose.com/slides/net/aspose.slides.animation/point)は、動作を適用すべきポイントです。
## **アニメーションタイムライン**
[**Sequence**](https://reference.aspose.com/slides/net/aspose.slides.animation/sequence)は、具体的な形状に適用されるアニメーション効果のコレクションです。

[**Timeline**](https://reference.aspose.com/slides/net/aspose.slides.animation/animationtimeline)は、具体的なスライドで使用されるSequenceのセットです。これはPowerPoint 2002以降のアニメーションエンジンを表しています。以前のPowerPointバージョンでは、プレゼンテーションにアニメーション効果を追加するのが難しく、さまざまな回避策を用いてのみ実現可能でした。タイムラインは旧式のAnimationSettingsクラスに代わり、PowerPointアニメーションのより明確なオブジェクトモデルを提供します。1つのスライドには1つのアニメーションタイムラインしかありません。
## **インタラクティブアニメーション**
[**Trigger**](https://reference.aspose.com/slides/net/aspose.slides.animation/effecttriggertype)は、特定のアニメーションを開始するユーザーアクション（例：ボタンのクリック）を定義することを可能にします。トリガーは最新のPowerPointバージョンにのみ追加されました。
## **形状アニメーション**
Aspose.Slidesでは、形状（テキスト、矩形、線、フレーム、OLEオブジェクトなど）にアニメーションを適用することが可能です。

{{% alert color="primary" %}} 
詳細は、[**形状アニメーションについて**](/slides/ja/net/shape-animation/)をご覧ください。
{{% /alert %}}

## **アニメーションチャート**
アニメーションチャートを作成するには、形状と同じクラスをすべて使用する必要があります。ただし、PowerPointアニメーションはチャートカテゴリーまたはチャートシリーズにのみ使用できます。カテゴリ要素やシリーズ要素にアニメーション効果を適用することもできます。

{{% alert color="primary" %}} 
詳細は、[**アニメーションチャートについて**](/slides/ja/net/animated-charts/)をご覧ください。
{{% /alert %}}

## **アニメーションテキスト**
アニメーションテキストの他に、段落にアニメーションを適用することも可能です。

{{% alert color="primary" %}} 
詳細は、[**アニメーションテキストについて**](/slides/ja/net/animated-text/)をご覧ください。
{{% /alert %}}