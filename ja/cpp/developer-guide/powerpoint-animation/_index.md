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
- アニメーションタイムライン
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

プレゼンテーションは何かを提示するために作られるため、その視覚的外観とインタラクティブな動作は作成時に常に考慮されます。

**PowerPoint animation** は、プレゼンテーションを目を引く魅力的なものにするために重要な役割を果たします。Aspose.Slides for C++ は、PowerPoint プレゼンテーションにアニメーションを追加するための幅広いオプションを提供します：

- さまざまな種類の PowerPoint アニメーション効果を、図形、チャート、テーブル、OLE オブジェクト、その他のプレゼンテーション要素に適用する。
- 1 つの図形に複数の PowerPoint アニメーション効果を使用する。
- アニメーション タイムラインを使用してアニメーション効果を制御する。
- カスタム アニメーションを作成する。

Aspose.Slides for C++ では、さまざまなアニメーション効果を図形に適用できます。スライド上のテキスト、画像、OLE オブジェクト、テーブルなど、すべての要素は図形として扱われるため、スライドのあらゆる要素にアニメーション効果を適用できることを意味します。

[**Aspose.Slides.Animation**](https://reference.aspose.com/slides/cpp/namespace/aspose.slides.animation) **名前空間** は、PowerPoint アニメーションを操作するクラスを提供します。

## **アニメーション効果**
Aspose.Slides は **150 以上のアニメーション効果** をサポートしており、Bounce、PathFootball、Zoom 効果などの基本的なアニメーション効果や、OLEObjectShow、OLEObjectOpen などの特定のアニメーション効果が含まれます。アニメーション効果の完全な一覧は、[**EffectType**](https://reference.aspose.com/slides/cpp/namespace/aspose.slides.animation#ae0da11508d382465aa4e7a011df1bf31) 列挙体で確認できます。

さらに、これらのアニメーション効果は組み合わせて使用できます：

- [ColorEffect](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.color_effect/t)
- [CommandEffect](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.command_effect)
- [FilterEffect](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.filter_effect)
- [MotionEffect](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.motion_effect)
- [PropertyEffect](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.property_effect)
- [RotationEffect](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.rotation_effect)
- [ScaleEffect](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.scale_effect)
- [SetEffect](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.set_effect)

## **カスタム アニメーション**
Aspose.Slides で独自の **カスタム アニメーション** を作成することが可能です。いくつかのビヘイビアを組み合わせて新しいカスタム アニメーションを作成することで実現できます。

[**Behavior**](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.behavior) は任意の PowerPoint アニメーション効果の構成要素です。すべてのアニメーション効果は実際には 1 つの戦略に組み込まれたビヘイビアの集合です。ビヘイビアをカスタム アニメーションに一度組み合わせれば、他のプレゼンテーションでも再利用できます。標準の PowerPoint アニメーション効果に新しいビヘイビアを追加すると、別のカスタム アニメーションになります。例えば、アニメーションにリピート ビヘイビアを追加して数回繰り返すようにすることができます。

[**Animation Point**](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.point) はビヘイビアを適用すべきポイントです。

## **アニメーション タイムライン**
[**Sequence**](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.sequence) は、特定の図形に適用されるアニメーション効果のコレクションです。

[**AnimationTimeLine**](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.animation_time_line) は、特定のスライドで使用される Sequence の集合です。PowerPoint 2002 以降、アニメーションエンジンとして実装されています。以前の PowerPoint バージョンでは、プレゼンテーションにアニメーション効果を追加することが困難で、さまざまな回避策しかありませんでした。Timeline は古い AnimationSettings クラスに代わるもので、PowerPoint アニメーションのオブジェクトモデルをより明確にします。1 つのスライドには **1 つだけ** のアニメーション タイムラインを持つことができます。

## **インタラクティブ アニメーション**
[**EffectTriggerType**](https://reference.aspose.com/slides/cpp/namespace/aspose.slides.animation#add24fb49dd44eb3227aeeb3641fd2e81) は、ユーザー操作（例：ボタンのクリック）を定義し、特定のアニメーションを開始させることができます。トリガーは最新の PowerPoint バージョンでのみ追加されました。

## **シェイプ アニメーション**
Aspose.Slides は、実際にはテキスト、矩形、線、フレーム、OLE オブジェクトなどであるシェイプにアニメーションを適用することを可能にします。

{{% alert color="primary" %}} 
詳しく読む [**About Shape Animation**](/slides/ja/cpp/shape-animation/).
{{% /alert %}}

## **アニメーション チャート**
アニメーション チャートを作成するには、シェイプと同じクラスを使用する必要があります。ただし、PowerPoint のアニメーションはチャートのカテゴリまたはシリーズにのみ適用できます。カテゴリ要素やシリーズ要素にもアニメーション効果を適用できます。

{{% alert color="primary" %}} 
詳しく読む [**About Animated Charts**](/slides/ja/cpp/animated-charts/).
{{% /alert %}}

## **アニメーション テキスト**
アニメーション テキストに加えて、段落にもアニメーションを適用することが可能です。

{{% alert color="primary" %}} 
詳しく読む [**About Animated Text**](/slides/ja/cpp/animated-text/).
{{% /alert %}}

## **FAQ**

**PDF にエクスポートしたときにアニメーションは保持されますか？**

いいえ。PDF は静的なフォーマットであるため、アニメーションや [slide transitions](/slides/ja/cpp/slide-transition/) が再生されません。動きを必要とする場合は、代わりに [HTML5](/slides/ja/cpp/export-to-html5/)、[animated GIF](/slides/ja/cpp/convert-powerpoint-to-animated-gif/)、または [video](/slides/ja/cpp/convert-powerpoint-to-video/) にエクスポートしてください。

**アニメーション化されたプレゼンテーションを動画に変換し、フレームレートやフレームサイズを制御できますか？**

はい。プレゼンテーションを[render the presentation as frames](/slides/ja/cpp/convert-powerpoint-to-video/)としてフレームに分割し、ffmpeg などで動画にエンコードすることで、FPS や解像度を選択できます。レンダリング中にアニメーションとスライド遷移が再生されます。

**ODP（PPTX だけでなく）でもアニメーションはそのまま残りますか？**

PPT、PPTX、ODP は[reading](/slides/ja/cpp/open-presentation/)および [writing](/slides/ja/cpp/save-presentation/) がサポートされていますが、フォーマットの違いにより一部の効果が若干異なる表示や動作になることがあります。重要なケースは実際のサンプルで検証してください。