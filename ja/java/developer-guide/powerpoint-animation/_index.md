---
title: PowerPoint アニメーション
type: docs
weight: 150
url: /java/powerpoint-animation/
keywords: "PowerPoint アニメーション"
description: "PowerPoint アニメーション、Aspose.Slides を使用した PowerPoint スライドアニメーション。"
---

プレゼンテーションは何かを提示することを目的としているため、その視覚的な外観とインタラクティブな動作は常に作成時に考慮されます。

**PowerPoint アニメーション**は、プレゼンテーションを視聴者にとって目を引く魅力的なものにするために重要な役割を果たします。Aspose.Slides for Java は、PowerPoint プレゼンテーションにアニメーションを追加するための幅広いオプションを提供します。

- 形状、チャート、テーブル、OLEオブジェクトおよび他のプレゼンテーション要素にさまざまなタイプの PowerPoint アニメーション効果を適用します。
- 形状に複数の PowerPoint アニメーション効果を使用します。
- アニメーションタイムラインを使用してアニメーション効果を制御します。
- カスタムアニメーションを作成します。

Aspose.Slides for Java では、さまざまなアニメーション効果を形状に適用できます。スライド上のテキスト、画像、OLEオブジェクト、テーブルなど、すべての要素が形状と見なされるため、スライドのすべての要素にアニメーション効果を適用できることを意味します。

## **アニメーション効果**
Aspose.Slides は、Bounce、PathFootball、Zoom効果のような基本的なアニメーション効果や、OLEObjectShow、OLEObjectOpenのような特定のアニメーション効果を含む**150以上のアニメーション効果**をサポートしています。アニメーション効果の完全なリストは、[**EffectType**](https://reference.aspose.com/slides/net/aspose.slides.animation/effecttype)列挙体でご確認いただけます。

さらに、これらのアニメーション効果は以下のと組み合わせて使用できます：

- [ColorEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ColorEffect)
- [CommandEffect](https://reference.aspose.com/slides/java/com.aspose.slides/CommandEffect)
- [FilterEffect](https://reference.aspose.com/slides/java/com.aspose.slides/FilterEffect)
- [MotionEffect](https://reference.aspose.com/slides/java/com.aspose.slides/MotionEffect)
- [PropertyEffect](https://reference.aspose.com/slides/java/com.aspose.slides/PropertyEffect)
- [RotationEffect](https://reference.aspose.com/slides/java/com.aspose.slides/RotationEffect)
- [ScaleEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ScaleEffect)
- [SetEffect](https://reference.aspose.com/slides/java/com.aspose.slides/SetEffect)

## **カスタムアニメーション**
Aspose.Slides で**カスタムアニメーション**を作成することが可能です。これは、いくつかの動作を組み合わせて新しいカスタムアニメーションを作成することで達成できます。

[**Behavior**](https://reference.aspose.com/slides/java/com.aspose.slides/Behavior)は、任意の PowerPoint アニメーション効果の構成単位です。すべてのアニメーション効果は、実際には一つの戦略に構成された動作の集合です。動作をカスタムアニメーションに一度組み合わせて、他のプレゼンテーションで再利用できます。標準の PowerPoint アニメーション効果に新しい動作を追加すると、それは別のカスタムアニメーションになります。例えば、アニメーションに繰り返し動作を追加して、数回繰り返すようにすることができます。

[**Animation Point**](https://reference.aspose.com/slides/java/com.aspose.slides/Point)は、動作が適用される点です。

## **アニメーションタイムライン**
[**Sequence**](https://reference.aspose.com/slides/java/com.aspose.slides/Sequence)は、特定の形状に適用されたアニメーション効果のコレクションです。

[**Timeline**](https://reference.aspose.com/slides/java/com.aspose.slides/AnimationTimeLine)は、特定のスライドで使用されるシーケンスのセットです。これは、PowerPoint 2002 以降に取り入れられたアニメーションエンジンです。以前の PowerPoint バージョンでは、アニメーション効果をプレゼンテーションに追加するのが困難で、さまざまな回避策を使用してのみ可能でした。タイムラインは、古い AnimationSettings クラスを置き換え、PowerPoint アニメーションのためのより明確なオブジェクトモデルを提供します。1つのスライドには1つのアニメーションタイムラインしか持てません。

## **インタラクティブアニメーション**
[**Trigger**](https://reference.aspose.com/slides/java/com.aspose.slides/EffectTriggerType)は、特定のアニメーションを開始させるユーザーのアクション（例：ボタンクリック）を定義できるようにします。トリガーは最新の PowerPoint バージョンにのみ追加されました。

## **形状アニメーション**
Aspose.Slides は、テキスト、長方形、線、フレーム、OLEオブジェクトなどにアニメーションを適用することを許可します。

{{% alert color="primary" %}} 
詳細は[**形状アニメーションについて**](/slides/java/shape-animation/)をお読みください。
{{% /alert %}}

## **アニメーションチャート**
アニメーションチャートを作成するには、形状と同じクラスを使用する必要があります。ただし、PowerPoint アニメーションはチャートのカテゴリまたはチャート系列にのみ適用できます。また、カテゴリ要素または系列要素にアニメーション効果を適用することもできます。

{{% alert color="primary" %}} 
詳細は[**アニメーションチャートについて**](/slides/java/animated-charts/)をお読みください。
{{% /alert %}}

## **アニメーションテキスト**
アニメーションテキストに加えて、段落にアニメーションを適用することも可能です。

{{% alert color="primary" %}} 
詳細は[**アニメーションテキストについて**](/slides/java/animated-text/)をお読みください。
{{% /alert %}}