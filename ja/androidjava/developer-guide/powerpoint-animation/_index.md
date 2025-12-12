---
title: Android でアニメーションを使用して PowerPoint プレゼンテーションを強化
linktitle: PowerPoint アニメーション
type: docs
weight: 150
url: /ja/androidjava/powerpoint-animation/
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
- 図形アニメーション
- アニメーションチャート
- アニメーション テキスト
- アニメーション 図形
- アニメーション OLE オブジェクト
- アニメーション画像
- アニメーションテーブル
- PowerPoint
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java が PowerPoint アニメーションを扱う機能を探ります。この一般的な概要では主な機能をハイライトしています。"
---

プレゼンテーションは何かを提示することを目的としているため、作成時には常にその視覚的外観とインタラクティブな動作が考慮されます。

**PowerPoint アニメーション** は、プレゼンテーションを目を引く魅力的なものにするために重要な役割を果たします。Aspose.Slides for Android via Java は、PowerPoint プレゼンテーションにアニメーションを追加するための幅広いオプションを提供します。

- さまざまな種類の PowerPoint アニメーション効果を図形、チャート、テーブル、OLE オブジェクトおよびその他のプレゼンテーション要素に適用します。
- 1 つの図形に複数の PowerPoint アニメーション効果を使用します。
- アニメーションタイムラインを使用してアニメーション効果を制御します。
- カスタム アニメーションを作成します。

Aspose.Slides for Android via Java では、図形にさまざまなアニメーション効果を適用できます。スライド上のテキスト、画像、OLE オブジェクト、テーブルなど、すべての要素は図形として扱われるため、スライド内のあらゆる要素にアニメーション効果を適用できることを意味します。

## **アニメーション効果**
Aspose.Slides は **150 以上のアニメーション効果** をサポートしており、Bounce、PathFootball、Zoom 効果などの基本的なアニメーション効果や、OLEObjectShow、OLEObjectOpen といった特定のアニメーション効果が含まれます。完全なアニメーション効果の一覧は [**EffectType** ](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effecttype/)enumeration にあります。

さらに、これらのアニメーション効果は次のものと組み合わせて使用できます。

- [ColorEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ColorEffect)
- [CommandEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/CommandEffect)
- [FilterEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FilterEffect)
- [MotionEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MotionEffect)
- [PropertyEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PropertyEffect)
- [RotationEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/RotationEffect)
- [ScaleEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ScaleEffect)
- [SetEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SetEffect)

## **カスタム アニメーション**
Aspose.Slides では独自の **カスタム アニメーション** を作成できます。これは、複数のビヘイビアを組み合わせて新しいカスタム アニメーションを作成することで実現できます。

[**Behavior**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Behavior) は任意の PowerPoint アニメーション効果の構成要素です。すべてのアニメーション効果は実質的にビヘイビアの集合で構成されており、1 回組み合わせたカスタム アニメーションは他のプレゼンテーションでも再利用できます。標準の PowerPoint アニメーション効果に新しいビヘイビアを追加すると、別のカスタム アニメーションとなります。たとえば、アニメーションにリピート ビヘイビアを追加して数回繰り返すように設定できます。

[**Animation Point**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Point) はビヘイビアを適用すべきポイントを示します。

## **アニメーション タイムライン**
[**Sequence**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Sequence) は、特定の図形に適用されるアニメーション効果のコレクションです。

[**Timeline**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AnimationTimeLine) は、具体的なスライドで使用される Sequence の集合です。PowerPoint 2002 以降で導入されたアニメーション エンジンで、従来の AnimationSettings クラスに代わり、PowerPoint アニメーションのオブジェクト モデルをより明確に提供します。1 つのスライドには **1 つの** アニメーション タイムラインしか設定できません。

## **インタラクティブ アニメーション**
[**Trigger**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/EffectTriggerType) を使用すると、ユーザー操作（例: ボタンのクリック）を定義でき、特定のアニメーションを開始させることができます。トリガーは最新の PowerPoint バージョンでのみ追加されました。

## **図形アニメーション**
Aspose.Slides は、テキスト、長方形、線、フレーム、OLE オブジェクトなど、実質的にすべての図形にアニメーションを適用できるようにします。

{{% alert color="primary" %}} 
詳しくは [**About Shape Animation**](/slides/ja/androidjava/shape-animation/) をご覧ください。
{{% /alert %}}

## **アニメーション チャート**
アニメーション チャートを作成するには、図形と同じクラスを使用します。ただし、チャートのカテゴリまたはシリーズに対してのみ PowerPoint アニメーションを使用できます。カテゴリ要素やシリーズ要素にもアニメーション効果を適用できます。

{{% alert color="primary" %}} 
詳しくは [**About Animated Charts**](/slides/ja/androidjava/animated-charts/) をご覧ください。
{{% /alert %}}

## **アニメーション テキスト**
アニメーション テキストに加えて、段落に対してもアニメーションを適用できます。

{{% alert color="primary" %}} 
詳しくは [**About Animated Text**](/slides/ja/androidjava/animated-text/) をご覧ください。
{{% /alert %}}

## **FAQ**

**アニメーションは PDF にエクスポートしても保持されますか？**

いいえ。PDF は静的フォーマットのため、アニメーションや [スライド トランジション](/slides/ja/androidjava/slide-transition/) は再生されません。動きを必要とする場合は、[HTML5](/slides/ja/androidjava/export-to-html5/)、[アニメーション GIF](/slides/ja/androidjava/convert-powerpoint-to-animated-gif/)、または [ビデオ](/slides/ja/androidjava/convert-powerpoint-to-video/) にエクスポートしてください。

**アニメーション プレゼンテーションをビデオに変換し、フレーム レートとフレーム サイズを制御できますか？**

はい。プレゼンテーションをフレームとして [レンダリング](/slides/ja/androidjava/convert-powerpoint-to-video/) し、ffmpeg などでビデオにエンコードする際に FPS と解像度を選択できます。レンダリング中にアニメーションとスライド トランジションが再生されます。

**ODP（PPTX だけでなく）でもアニメーションは維持されますか？**

PPT、PPTX、ODP は [読み取り](/slides/ja/androidjava/open-presentation/) と [書き込み](/slides/ja/androidjava/save-presentation/) がサポートされていますが、形式の違いにより一部の効果が若干異なる表示や動作になることがあります。重要なケースは実際のサンプルで検証してください。