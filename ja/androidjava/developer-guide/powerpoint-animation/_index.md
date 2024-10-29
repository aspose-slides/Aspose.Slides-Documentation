---
title: PowerPoint アニメーション
type: docs
weight: 150
url: /ja/androidjava/powerpoint-animation/
keywords: "PowerPoint アニメーション"
description: "PowerPoint アニメーション、Aspose.Slides を使用した PowerPoint スライドアニメーション。"
---

プレゼンテーションは何かを提示するために作成されるため、その視覚的な外観とインタラクティブな動作は常に考慮されます。

**PowerPoint アニメーション** は、プレゼンテーションを視聴者にとって魅力的で目を引くものにするために重要な役割を果たします。Aspose.Slides for Android via Java は、PowerPoint プレゼンテーションにアニメーションを追加するためのさまざまなオプションを提供します：

- 図形、チャート、表、OLE オブジェクトおよびその他のプレゼンテーション要素に様々なタイプの PowerPoint アニメーション効果を適用します。
- 1つの図形に複数の PowerPoint アニメーション効果を使用します。
- アニメーションの効果を制御するためにアニメーションタイムラインを使用します。
- カスタムアニメーションを作成します。

Aspose.Slides for Android via Java では、図形にさまざまなアニメーション効果を適用できます。スライド上のすべての要素（テキスト、画像、OLE オブジェクト、表など）が図形と見なされるため、スライドのすべての要素にアニメーション効果を適用できます。

## **アニメーション効果**
Aspose.Slides は、**150以上のアニメーション効果**をサポートしており、バウンス、パスフットボール、ズーム効果のような基本的なアニメーション効果や、OLEObjectShow、OLEObjectOpenのような特定のアニメーション効果を含みます。アニメーション効果の完全なリストは、[**EffectType**](https://reference.aspose.com/slides/net/aspose.slides.animation/effecttype) 列挙型で確認できます。

さらに、これらのアニメーション効果は以下のものと組み合わせて使用できます：

- [ColorEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ColorEffect)
- [CommandEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/CommandEffect)
- [FilterEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FilterEffect)
- [MotionEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MotionEffect)
- [PropertyEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PropertyEffect)
- [RotationEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/RotationEffect)
- [ScaleEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ScaleEffect)
- [SetEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SetEffect)

## **カスタムアニメーション**
Aspose.Slides では、独自の **カスタムアニメーション** を作成することが可能です。これを実現するには、いくつかの動作を組み合わせて新しいカスタムアニメーションを作成します。

[**Behavior**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Behavior) は、任意の PowerPoint アニメーション効果の構成要素です。すべてのアニメーション効果は、実際には1つの戦略に組み込まれた行動の集合です。行動をカスタムアニメーションに一度組み合わせて、他のプレゼンテーションで再使用することができます。標準の PowerPoint アニメーション効果に新しい行動を追加すれば、それは別のカスタムアニメーションになります。たとえば、アニメーションに繰り返し動作を追加して数回繰り返すようにすることができます。

[**Animation Point**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Point) は、行動が適用されるポイントです。

## **アニメーションタイムライン**
[**Sequence**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Sequence) は、特定の図形に適用されるアニメーション効果のコレクションです。

[**Timeline**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AnimationTimeLine) は、特定のスライドで使用されるシーケンスのセットです。これは、PowerPoint 2002 以降に表現されたアニメーションエンジンです。以前の PowerPoint バージョンでは、アニメーション効果をプレゼンテーションに追加することが難しく、異なる回避策を用いる必要がありました。タイムラインは古い AnimationSettings クラスの代替として登場し、PowerPoint アニメーション用のより明確なオブジェクトモデルを提供します。1つのスライドには、1つのアニメーションタイムラインのみを持つことができます。

## **インタラクティブアニメーション**
[**Trigger**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/EffectTriggerType) は、特定のアニメーションを開始するユーザーアクション（例：ボタンクリック）を定義することを可能にします。トリガーは最新の PowerPoint バージョンにのみ追加されています。

## **図形アニメーション**
Aspose.Slides は、実際にはテキスト、長方形、線、フレーム、OLE オブジェクトなどの図形にアニメーションを適用することを可能にします。

{{% alert color="primary" %}} 
詳細情報は [**図形アニメーションについて**](/slides/ja/androidjava/shape-animation/) をお読みください。
{{% /alert %}}

## **アニメーション付きチャート**
アニメーション付きチャートを作成するには、図形と同じクラスを使用する必要があります。ただし、PowerPoint アニメーションはチャートのカテゴリまたはチャート系列にのみ使用できます。カテゴリ要素または系列要素にアニメーション効果を適用することもできます。

{{% alert color="primary" %}} 
詳細情報は [**アニメーション付きチャートについて**](/slides/ja/androidjava/animated-charts/) をお読みください。
{{% /alert %}}

## **アニメーション付きテキスト**
アニメーションテキストの他に、段落にもアニメーションを適用することが可能です。

{{% alert color="primary" %}} 
詳細情報は [**アニメーション付きテキストについて**](/slides/ja/androidjava/animated-text/) をお読みください。
{{% /alert %}}