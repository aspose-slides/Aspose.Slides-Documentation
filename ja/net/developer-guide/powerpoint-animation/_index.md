---
title: .NET で PowerPoint プレゼンテーションをアニメーションで強化する
linktitle: PowerPoint アニメーション
type: docs
weight: 150
url: /ja/net/powerpoint-animation/
keywords:
- アニメーションの追加
- アニメーションの更新
- アニメーションの変更
- アニメーションの削除
- アニメーションの管理
- アニメーションの制御
- アニメーション効果
- PowerPoint アニメーション
- アニメーションタイムライン
- インタラクティブ アニメーション
- カスタム アニメーション
- 図形アニメーション
- アニメーションチャート
- アニメーションテキスト
- アニメーション図形
- アニメーション OLE オブジェクト
- アニメーション画像
- アニメーションテーブル
- PowerPoint プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET が PowerPoint アニメーションを処理する機能を探ります。この概要では主な機能をハイライトし、プレゼンテーションを向上させるための洞察を提供します。"
---

## **概要**

プレゼンテーションは何かを提示することを目的としているため、作成時には視覚的な外観とインタラクティブな動作が常に考慮されます。

**PowerPoint アニメーション** は、プレゼンテーションを目を引く魅力的なものにする上で重要な役割を果たします。Aspose.Slides for .NET は、PowerPoint プレゼンテーションにアニメーションを追加するための幅広いオプションを提供します。

- さまざまな種類の PowerPoint アニメーション効果を、図形、チャート、表、OLE オブジェクト、その他のプレゼンテーション要素に適用します。
- 単一の図形に複数の PowerPoint アニメーション効果を使用します。
- アニメーションタイムラインを利用してアニメーション効果を制御します。
- カスタム アニメーションを作成します。

Aspose.Slides for .NET では、さまざまなアニメーション効果を図形に適用できます。スライド上のテキスト、画像、OLE オブジェクト、表などすべての要素は図形とみなされるため、スライド上の任意の要素にアニメーション効果を適用できます。

[Aspose.Slides.Animation](https://reference.aspose.com/slides/net/aspose.slides.animation/) 名前空間は、PowerPoint アニメーションを操作するクラスを提供します。

## **アニメーション効果**

Aspose.Slides は **150 以上のアニメーション効果** をサポートしており、Bounce、PathFootball、Zoom といった基本効果や OLEObjectShow、OLEObjectOpen といった固有の効果が含まれます。すべてのアニメーション効果の一覧は [EffectType](https://reference.aspose.com/slides/net/aspose.slides.animation/effecttype) 列挙体で確認できます。

さらに、これらのアニメーション効果は以下と組み合わせて使用できます。

- [ColorEffect](https://reference.aspose.com/slides/net/aspose.slides.animation/coloreffect)
- [CommandEffect](https://reference.aspose.com/slides/net/aspose.slides.animation/commandeffect)
- [FilterEffect](https://reference.aspose.com/slides/net/aspose.slides.animation/filtereffect)
- [MotionEffect](https://reference.aspose.com/slides/net/aspose.slides.animation/motioneffect)
- [PropertyEffect](https://reference.aspose.com/slides/net/aspose.slides.animation/propertyeffect)
- [RotationEffect](https://reference.aspose.com/slides/net/aspose.slides.animation/rotationeffect)
- [ScaleEffect](https://reference.aspose.com/slides/net/aspose.slides.animation/scaleeffect)
- [SetEffect](https://reference.aspose.com/slides/net/aspose.slides.animation/seteffect)

## **カスタム アニメーション**

Aspose.Slides では独自の **カスタム アニメーション** を作成できます。これは、複数のビヘイビアを組み合わせて新しいカスタム アニメーションにすることで実現できます。

[Behaviour](https://reference.aspose.com/slides/net/aspose.slides.animation/behavior) は、任意の PowerPoint アニメーション効果の構成要素です。すべてのアニメーション効果は本質的に、1 つの戦略に組み合わされたビヘイビアの集合です。ビヘイビアをカスタム アニメーションに結合して一度作成すれば、他のプレゼンテーションでも再利用できます。標準の PowerPoint アニメーション効果に新しいビヘイビアを追加すると、別のカスタム アニメーションになります。たとえば、アニメーションにリピート ビヘイビアを追加して数回繰り返すようにできます。

[Animation Point](https://reference.aspose.com/slides/net/aspose.slides.animation/point) は、ビヘイビアを適用すべき位置を表します。

## **アニメーション タイムライン**

[Sequence](https://reference.aspose.com/slides/net/aspose.slides.animation/sequence) は、特定の図形に適用されたアニメーション効果のコレクションです。

[Timeline](https://reference.aspose.com/slides/net/aspose.slides.animation/animationtimeline) は、特定のスライドで使用されるシーケンスの集合です。PowerPoint 2002 で導入されたアニメーション エンジンです。以前の PowerPoint バージョンでは、プレゼンテーションにアニメーション効果を追加することが困難で、さまざまな回避策が必要でした。タイムラインは従来の AnimationSettings クラスに取って代わり、PowerPoint アニメーションのオブジェクト モデルをより明確にします。1 つのスライドには 1 つのアニメーション タイムラインしか設定できません。

## **インタラクティブ アニメーション**

[Trigger](https://reference.aspose.com/slides/net/aspose.slides.animation/effecttriggertype) は、ユーザー アクション (例: ボタンのクリック) を定義し、特定のアニメーションを開始できるようにします。トリガーは最新バージョンの PowerPoint で導入されました。

## **図形 アニメーション**

Aspose.Slides は、テキスト、矩形、線、フレーム、OLE オブジェクトなど、さまざまな図形にアニメーションを適用できます。

{{% alert color="primary" %}} 
詳しく読む [**図形アニメーションについて**](/slides/ja/net/shape-animation/).
{{% /alert %}}

## **アニメーション チャート**

アニメーション チャートを作成するには、図形と同じクラスを使用します。ただし、PowerPoint のアニメーションはチャートのカテゴリまたはシリーズにのみ適用でき、カテゴリ要素やシリーズ要素にもアニメーション効果を適用できます。

{{% alert color="primary" %}} 
詳しく読む [**アニメーション チャートについて**](/slides/ja/net/animated-charts/).
{{% /alert %}}

## **アニメーション テキスト**

アニメーション テキストに加えて、段落にもアニメーションを適用できます。

{{% alert color="primary" %}} 
詳しく読む [**アニメーション テキストについて**](/slides/ja/net/animated-text/).
{{% /alert %}}

## **よくある質問**

**PDF にエクスポートしたときにアニメーションは保持されますか？**

いいえ。PDF は静的なフォーマットであるため、アニメーションや [スライド トランジション](/slides/ja/net/slide-transition/) は再生されません。モーションが必要な場合は、代わりに [HTML5](/slides/ja/net/export-to-html5/)、[アニメーション GIF](/slides/ja/net/convert-powerpoint-to-animated-gif/)、または [ビデオ](/slides/ja/net/convert-powerpoint-to-video/) にエクスポートしてください。

**アニメーション付きプレゼンテーションをビデオに変換し、フレームレートとフレームサイズを制御できますか？**

はい。プレゼンテーションをフレームとして [レンダリング](/slides/ja/net/convert-powerpoint-to-video/) し、ffmpeg などでビデオにエンコードすることで、FPS と解像度を選択できます。レンダリング中にアニメーションとスライド トランジションが再生されます。

**ODP（PPTX だけでなく）で作業する場合、アニメーションはそのまま保持されますか？**

PPT、PPTX、ODP は [読み取り](/slides/ja/net/open-presentation/) と [書き込み](/slides/ja/net/save-presentation/) をサポートしていますが、フォーマットの違いにより一部の効果が若干異なる表示や挙動になる場合があります。重要なケースは実際のサンプルで検証してください。