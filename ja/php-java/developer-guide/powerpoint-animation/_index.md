---
title: PowerPointアニメーション
type: docs
weight: 150
url: /php-java/powerpoint-animation/
keywords: "PowerPointアニメーション"
description: "PowerPointアニメーション、Aspose.Slidesを使用したPowerPointスライドアニメーション。"
---

プレゼンテーションは何かを提示することを目的としているため、作成時には視覚的な外観とインタラクティブな動作が常に考慮されます。

**PowerPointアニメーション**は、プレゼンテーションを視覚的に魅力的で興味を惹くものにするために重要な役割を果たします。Aspose.Slides for PHP via Javaは、PowerPointプレゼンテーションにアニメーションを追加するための幅広いオプションを提供します。

- 形状、グラフ、表、OLEオブジェクトおよびその他のプレゼンテーション要素にさまざまなタイプのPowerPointアニメーション効果を適用します。
- 形状に対して複数のPowerPointアニメーション効果を使用します。
- アニメーションタイムラインを使用してアニメーション効果を制御します。
- カスタムアニメーションを作成します。

Aspose.Slides for PHP via Javaでは、さまざまなアニメーション効果を形状に適用できます。スライド上のすべての要素、つまりテキスト、画像、OLEオブジェクト、表などは形状と見なされるため、スライドのすべての要素にアニメーション効果を適用できることを意味します。

## **アニメーション効果**
Aspose.Slidesは、Bounce、PathFootball、Zoom効果などの基本的なアニメーション効果や、OLEObjectShow、OLEObjectOpenなどの特定のアニメーション効果を含む**150以上のアニメーション効果**をサポートしています。アニメーション効果の完全なリストは[**EffectType**](https://reference.aspose.com/slides/net/aspose.slides.animation/effecttype)列挙型で見つけることができます。

さらに、これらのアニメーション効果は次のものと組み合わせて使用できます。

- [ColorEffect](https://reference.aspose.com/slides/php-java/aspose.slides/ColorEffect)
- [CommandEffect](https://reference.aspose.com/slides/php-java/aspose.slides/CommandEffect)
- [FilterEffect](https://reference.aspose.com/slides/php-java/aspose.slides/FilterEffect)
- [MotionEffect](https://reference.aspose.com/slides/php-java/aspose.slides/MotionEffect)
- [PropertyEffect](https://reference.aspose.com/slides/php-java/aspose.slides/PropertyEffect)
- [RotationEffect](https://reference.aspose.com/slides/php-java/aspose.slides/RotationEffect)
- [ScaleEffect](https://reference.aspose.com/slides/php-java/aspose.slides/ScaleEffect)
- [SetEffect](https://reference.aspose.com/slides/php-java/aspose.slides/SetEffect)

## **カスタムアニメーション**
Aspose.Slidesでは、独自の**カスタムアニメーション**を作成することが可能です。これは、複数の動作を組み合わせて新しいカスタムアニメーションを作成することで実現できます。

[**Behavior**](https://reference.aspose.com/slides/php-java/aspose.slides/Behavior)は、任意のPowerPointアニメーション効果の構成要素です。すべてのアニメーション効果は、実際には1つの戦略に構成された一連の動作です。動作をカスタムアニメーションに一度組み合わせて、他のプレゼンテーションで再利用できます。標準的なPowerPointアニメーション効果に新しい動作を追加すると、それは別のカスタムアニメーションになります。たとえば、アニメーションに繰り返し動作を加えて、数回繰り返すことができます。

[**Animation Point**](https://reference.aspose.com/slides/php-java/aspose.slides/Point)は、動作が適用されるポイントです。

## **アニメーションタイムライン**
[**Sequence**](https://reference.aspose.com/slides/php-java/aspose.slides/Sequence)は、特定の形状に適用されるアニメーション効果のコレクションです。

[**Timeline**](https://reference.aspose.com/slides/php-java/aspose.slides/AnimationTimeLine)は、特定のスライドで使用される一連のシーケンスです。これは、PowerPoint 2002以降に導入されたアニメーションエンジンです。以前のPowerPointバージョンでは、プレゼンテーションにアニメーション効果を追加することが困難であり、さまざまな回避策によってのみ実現できました。タイムラインは、古いAnimationSettingsクラスに代わって、PowerPointアニメーションのより明確なオブジェクトモデルを提供します。1つのスライドには、1つのアニメーションタイムラインのみを持つことができます。

## **インタラクティブアニメーション**
[**Trigger**](https://reference.aspose.com/slides/php-java/aspose.slides/EffectTriggerType)は、特定のアニメーションを開始するユーザーのアクション（例：ボタンクリック）を定義することを可能にします。トリガーは最新のPowerPointバージョンにのみ追加されました。

## **形状アニメーション**
Aspose.Slidesは、テキスト、長方形、線、フレーム、OLEオブジェクトなどの形状にアニメーションを適用することを許可します。

{{% alert color="primary" %}} 
詳細情報は[**形状アニメーションについて**](/slides/php-java/shape-animation/)をお読みください。
{{% /alert %}}

## **アニメーションチャート**
アニメーションチャートを作成するには、形状と同じすべてのクラスを使用する必要があります。しかし、PowerPointアニメーションはチャートカテゴリまたはチャートシリーズに対してのみ使用できます。また、カテゴリ要素またはシリーズ要素にアニメーション効果を適用することもできます。

{{% alert color="primary" %}} 
詳細情報は[**アニメーションチャートについて**](/slides/php-java/animated-charts/)をお読みください。
{{% /alert %}}

## **アニメーションテキスト**
アニメーションテキストに加えて、段落にアニメーションを適用することも可能です。

{{% alert color="primary" %}} 
詳細情報は[**アニメーションテキストについて**](/slides/php-java/animated-text/)をお読みください。
{{% /alert %}}