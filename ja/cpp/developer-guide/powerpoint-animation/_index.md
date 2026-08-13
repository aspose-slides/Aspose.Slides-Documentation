---
title: C++ でアニメーションを使用して PowerPoint プレゼンテーションを強化する
linktitle: PowerPoint アニメーション
type: docs
weight: 150
url: /ja/cpp/powerpoint-animation/
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
- アニメーション チャート
- アニメーション テキスト
- アニメーション シェイプ
- アニメーション OLE オブジェクト
- アニメーション 画像
- アニメーション テーブル
- PowerPoint
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ で高度なアニメーション効果を追加および制御し、動的な PowerPoint および OpenDocument プレゼンテーションを作成する方法を学びます。"
---
## **はじめに**

プレゼンテーションは何かを提示することを目的としているため、その視覚的外観とインタラクティブな動作は作成時に常に考慮されます。

**PowerPoint アニメーション**は、プレゼンテーションを視覚的に魅力的にするために重要な役割を果たします。Aspose.Slides for C++ は、PowerPoint プレゼンテーションにアニメーションを追加するための幅広いオプションを提供します:
- さまざまな種類の PowerPoint アニメーション効果をシェイプ、チャート、テーブル、OLE オブジェクト、その他のプレゼンテーション要素に適用します。
- 1 つのシェイプに複数の PowerPoint アニメーション効果を使用します。
- アニメーションタイムラインを使用してアニメーション効果を制御します。
- カスタム アニメーションを作成します。

Aspose.Slides for C++ では、さまざまなアニメーション効果をシェイプに適用できます。スライド上のテキスト、画像、OLE オブジェクト、テーブルなど、すべての要素がシェイプとみなされるため、スライド上のあらゆる要素にアニメーション効果を適用できます。

[**Aspose.Slides.Animation**](https://reference.aspose.com/slides/ja/cpp/namespace/aspose.slides.animation) **namespace** は、PowerPoint アニメーションを操作するためのクラスを提供します。

## **アニメーション効果**

Aspose.Slides は、**150 以上のアニメーション効果**をサポートしており、Bounce、PathFootball、Zoom エフェクトなどの基本的な効果や、OLEObjectShow、OLEObjectOpen といった特定の効果が含まれます。すべてのアニメーション効果の一覧は、[**EffectType**](https://reference.aspose.com/slides/ja/cpp/namespace/aspose.slides.animation#ae0da11508d382465aa4e7a011df1bf31) 列挙型で確認できます。

さらに、これらのアニメーション効果は組み合わせて使用できます:
- [ColorEffect](https://reference.aspose.com/slides/ja/cpp/aspose.slides.animation/coloreffect/)
- [CommandEffect](https://reference.aspose.com/slides/ja/cpp/class/aspose.slides.animation.command_effect)
- [FilterEffect](https://reference.aspose.com/slides/ja/cpp/class/aspose.slides.animation.filter_effect)
- [MotionEffect](https://reference.aspose.com/slides/ja/cpp/class/aspose.slides.animation.motion_effect)
- [PropertyEffect](https://reference.aspose.com/slides/ja/cpp/class/aspose.slides.animation.property_effect)
- [RotationEffect](https://reference.aspose.com/slides/ja/cpp/class/aspose.slides.animation.rotation_effect)
- [ScaleEffect](https://reference.aspose.com/slides/ja/cpp/class/aspose.slides.animation.scale_effect)
- [SetEffect](https://reference.aspose.com/slides/ja/cpp/class/aspose.slides.animation.set_effect)

## **カスタム アニメーション**

Aspose.Slides で独自の **カスタム アニメーション** を作成することが可能です。  
複数のビヘイビアを組み合わせて新しいカスタム アニメーションを作成することで実現できます。

[**Behavior**](https://reference.aspose.com/slides/ja/cpp/class/aspose.slides.animation.behavior) は、任意の PowerPoint アニメーション効果の構成要素です。すべてのアニメーション効果は実際には 1 つの戦略にまとめられたビヘイビアの集合です。ビヘイビアをカスタム アニメーションに一度組み合わせれば、他のプレゼンテーションで再利用できます。標準の PowerPoint アニメーション効果に新しいビヘイビアを追加すると、別のカスタム アニメーションになります。たとえば、アニメーションにリピート ビヘイビアを追加して数回繰り返すようにできます。

[**Animation Point**](https://reference.aspose.com/slides/ja/cpp/class/aspose.slides.animation.point) は、ビヘイビアを適用すべきポイントです。

## **アニメーション タイムライン**

[**Sequence**](https://reference.aspose.com/slides/ja/cpp/class/aspose.slides.animation.sequence) は、特定のシェイプに適用されるアニメーション効果のコレクションです。

[**AnimationTimeLine**](https://reference.aspose.com/slides/ja/cpp/class/aspose.slides.animation.animation_time_line) は、特定のスライドで使用される Sequence の集合です。PowerPoint 2002 以降のアニメーションエンジンとして表現されています。以前の PowerPoint バージョンでは、プレゼンテーションにアニメーション効果を追加することが難しく、さまざまな回避策が必要でした。Timeline は旧版の AnimationSettings クラスに代わるもので、PowerPoint アニメーションのオブジェクトモデルをより明確に提供します。1 つのスライドには 1 つだけ のアニメーションタイムラインを持つことができます。

## **インタラクティブ アニメーション**

[**EffectTriggerType**](https://reference.aspose.com/slides/ja/cpp/namespace/aspose.slides.animation#add24fb49dd44eb3227aeeb3641fd2e81) は、特定のアニメーションを開始させるユーザーアクション（例: ボタンのクリック）を定義することを可能にします。トリガーは最新の PowerPoint バージョンでのみ追加されました。

## **シェイプ アニメーション**

Aspose.Slides は、テキスト、矩形、線、フレーム、OLE オブジェクトなど、実際にはシェイプである要素にアニメーションを適用できます。

{{% alert color="info" %}} 
詳細を見る [**シェイプ アニメーションについて**](/slides/ja/cpp/shape-animation/).
{{% /alert %}}

## **アニメーション チャート**

アニメーション チャートを作成するには、シェイプと同じクラスを使用します。ただし、PowerPoint アニメーションはチャートのカテゴリまたはシリーズにのみ適用できます。カテゴリ要素やシリーズ要素にもアニメーション効果を適用できます。

{{% alert color="info" %}} 
詳細を見る [**アニメーション チャートについて**](/slides/ja/cpp/animated-charts/).
{{% /alert %}}

## **アニメーション テキスト**

アニメーション テキストに加えて、段落にもアニメーションを適用することが可能です。

{{% alert color="info" %}} 
詳細を見る [**アニメーション テキストについて**](/slides/ja/cpp/animated-text/).
{{% /alert %}}

## **FAQ**

### PDF にエクスポートしたときにアニメーションは保持されますか？

いいえ。PDF は静的なフォーマットであるため、アニメーションや [スライド トランジション](/slides/ja/cpp/slide-transition/) は再生されません。動きが必要な場合は、代わりに [HTML5](/slides/ja/cpp/export-to-html5/)、[アニメーション GIF](/slides/ja/cpp/convert-powerpoint-to-animated-gif/)、または [ビデオ](/slides/ja/cpp/convert-powerpoint-to-video/) にエクスポートしてください。

### アニメーション付きプレゼンテーションをビデオに変換し、フレームレートとフレームサイズを制御できますか？

はい。[プレゼンテーションをフレームとしてレンダリング](/slides/ja/cpp/convert-powerpoint-to-video/) し、ffmpeg などでビデオにエンコードすることで、FPS と解像度を選択できます。レンダリング中にアニメーションとスライド トランジションが再生されます。

### ODP（PPTX だけでなく）で作業するときにアニメーションはそのまま保持されますか？

PPT、PPTX、ODP は、[読み取り](/slides/ja/cpp/open-presentation/) および [書き込み](/slides/ja/cpp/save-presentation/) がサポートされていますが、フォーマットの違いにより特定の効果が若干異なる外観や動作になることがあります。重要なケースは実際のサンプルで検証してください。