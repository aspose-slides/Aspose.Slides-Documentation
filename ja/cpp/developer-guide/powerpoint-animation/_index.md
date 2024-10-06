---
title: PowerPoint アニメーション
type: docs
weight: 150
url: /ja/cpp/powerpoint-animation/
keywords: "PowerPoint アニメーション"
description: "PowerPoint アニメーション、Aspose.Slides を使用した PowerPoint スライドのアニメーション。"
---

プレゼンテーションは何かを示すことを目的としているため、その視覚的外観とインタラクティブな動作は作成時に常に考慮されます。

**PowerPoint アニメーション**は、プレゼンテーションを観客にとって目を引く魅力的なものにするために重要な役割を果たします。Aspose.Slides for C++ は、PowerPoint プレゼンテーションにアニメーションを追加するための幅広いオプションを提供します：

- さまざまな種類の PowerPoint アニメーション効果を図形、チャート、表、OLE オブジェクト、その他のプレゼンテーション要素に適用します。
- 1 つの図形に複数の PowerPoint アニメーション効果を使用します。
- アニメーションのタイムラインを使用してアニメーション効果を制御します。
- カスタムアニメーションを作成します。

Aspose.Slides for C++では、さまざまなアニメーション効果を図形に適用できます。テキスト、画像、OLE オブジェクト、表など、スライド上のすべての要素は図形として扱われるため、スライドのすべての要素にアニメーション効果を適用できるということです。

[**Aspose.Slides.Animation**](https://reference.aspose.com/slides/cpp/namespace/aspose.slides.animation) **名前空間**は、PowerPoint アニメーションを操作するためのクラスを提供します。
## **アニメーション効果**
Aspose.Slides は、**150+ のアニメーション効果**をサポートしています。基本的なアニメーション効果には、Bounce、PathFootball、Zoom 効果が含まれ、特定のアニメーション効果には OLEObjectShow、OLEObjectOpen があります。アニメーション効果の完全なリストは、[**EffectType**](https://reference.aspose.com/slides/cpp/namespace/aspose.slides.animation#ae0da11508d382465aa4e7a011df1bf31) 列挙型で見つけることができます。

さらに、これらのアニメーション効果を以下のように組み合わせて使用することもできます：

- [ColorEffect](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.color_effect/t)
- [CommandEffect](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.command_effect)
- [FilterEffect](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.filter_effect)
- [MotionEffect](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.motion_effect)
- [PropertyEffect](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.property_effect)
- [RotationEffect](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.rotation_effect)
- [ScaleEffect](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.scale_effect)
- [SetEffect](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.set_effect)

## **カスタムアニメーション**
Aspose.Slides では、独自の**カスタムアニメーション**を作成することが可能です。これは、複数の動作を組み合わせて新しいカスタムアニメーションを作成することで実現できます。

[**Behavior**](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.behavior) は、任意の PowerPoint アニメーション効果の基本要素です。すべてのアニメーション効果は、実際には 1 つの戦略に組み込まれた一連の動作です。一度動作をカスタムアニメーションに組み合わせると、他のプレゼンテーションで再利用できます。標準の PowerPoint アニメーション効果に新しい動作を追加すると、それは別のカスタムアニメーションになります。たとえば、アニメーションに繰り返し動作を追加して、数回繰り返すようにすることができます。

[**Animation Point**](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.point) は、動作を適用すべきポイントです。

## **アニメーションタイムライン**
[**Sequence**](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.sequence) は、特定の図形に適用されたアニメーション効果のコレクションです。

[**AnimationTimeLine**](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.animation_time_line) は、特定のスライドで使用されるシーケンスのセットです。これは、PowerPoint 2002 から提供されているアニメーションエンジンです。以前の PowerPoint バージョンでは、アニメーション効果をプレゼンテーションに追加するのが困難で、異なるワークアラウンドでのみ実現できました。タイムラインは古い AnimationSettings クラスを置き換え、PowerPoint アニメーションのためのより明確なオブジェクトモデルを提供します。1 つのスライドには、1 つのアニメーションタイムラインのみが存在できます。
## **インタラクティブアニメーション**
[**EffectTriggerType**](https://reference.aspose.com/slides/cpp/namespace/aspose.slides.animation#add24fb49dd44eb3227aeeb3641fd2e81) は、特定のアニメーションを開始するユーザーアクション（例：ボタンのクリック）を定義することを可能にします。トリガーは最新の PowerPoint バージョンにのみ追加されました。

## **図形アニメーション**
Aspose.Slides では、図形にアニメーションを適用でき、その図形は実際にはテキスト、長方形、線、フレーム、OLE オブジェクトなどです。

{{% alert color="primary" %}} 
詳細については、[**図形アニメーションについて**](/slides/ja/cpp/shape-animation/)をご覧ください。
{{% /alert %}}

## **アニメーションチャート**
アニメーションチャートを作成するには、図形と同じクラスを使用する必要があります。ただし、PowerPoint アニメーションはチャートのカテゴリやチャートシリーズに対してのみ使用可能です。また、カテゴリ要素やシリーズ要素にアニメーション効果を適用することもできます。

{{% alert color="primary" %}} 
詳細については、[**アニメーションチャートについて**](/slides/ja/cpp/animated-charts/)をご覧ください。
{{% /alert %}}

## **アニメーションテキスト**
アニメーションテキストに加えて、段落にアニメーションを適用することもできます。

{{% alert color="primary" %}} 
詳細については、[**アニメーションテキストについて**](/slides/ja/cpp/animated-text/)をご覧ください。
{{% /alert %}}