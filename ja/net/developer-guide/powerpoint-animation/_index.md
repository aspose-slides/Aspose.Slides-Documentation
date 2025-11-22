---
title: C# で PowerPoint プレゼンテーションをアニメーションで強化する
linktitle: PowerPoint アニメーション
type: docs
weight: 150
url: /ja/net/powerpoint-animation/
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
- 図形アニメーション
- アニメーション化されたチャート
- アニメーションテキスト
- アニメーション図形
- アニメーション OLE オブジェクト
- アニメーション画像
- アニメーションテーブル
- PowerPoint プレゼンテーション
- C#
- Csharp
- Aspose.Slides for .NET
description: "Aspose.Slides for .NET の PowerPoint アニメーション処理機能を探ります。この一般的な概要では、主な機能をハイライトし、プレゼンテーションを強化するための洞察を提供します。"
---

## **概要**

プレゼンテーションは何かを提示するものなので、作成時には視覚的な外観とインタラクティブな動作が常に考慮されます。

**PowerPoint アニメーション** は、プレゼンテーションを目を引くものにし、視聴者を引き込む重要な役割を果たします。Aspose.Slides for .NET は、PowerPoint プレゼンテーションにアニメーションを追加するための幅広いオプションを提供します：

- さまざまな種類の PowerPoint アニメーション効果を図形、チャート、テーブル、OLE オブジェクト、およびその他のプレゼンテーション要素に適用します。
- 単一の図形に複数の PowerPoint アニメーション効果を使用します。
- アニメーションタイムラインを利用してアニメーション効果を制御します。
- カスタム アニメーションを作成します。

Aspose.Slides for .NET では、さまざまなアニメーション効果を図形に適用できます。スライド上のすべての要素（テキスト、画像、OLE オブジェクト、テーブルなど）は図形とみなされるため、スライド上の任意の要素にアニメーション効果を適用できます。

[Aspose.Slides.Animation](https://reference.aspose.com/slides/net/aspose.slides.animation/) 名前空間は、PowerPoint アニメーションを操作するためのクラスを提供します。

## **アニメーション効果**

Aspose.Slides は **150+ アニメーション効果** をサポートしており、Bounce、PathFootball、Zoom などの基本効果や OLEObjectShow、OLEObjectOpen といった特定の効果が含まれます。完全な一覧は [EffectType](https://reference.aspose.com/slides/net/aspose.slides.animation/effecttype) 列挙体で確認できます。

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

Aspose.Slides では、独自の **カスタム アニメーション** を作成できます。これは、複数のビヘイビアを組み合わせて新しいカスタム アニメーションにすることで実現します。

[Behaviour](https://reference.aspose.com/slides/net/aspose.slides.animation/behavior) は PowerPoint アニメーション効果の構成要素です。すべてのアニメーション効果は本質的にビヘイビアの集合で構成されています。ビヘイビアをカスタム アニメーションにまとめておけば、他のプレゼンテーションでも再利用できます。標準の PowerPoint アニメーション効果に新しいビヘイビアを追加すると、別のカスタム アニメーションになります。たとえば、アニメーションにリピート ビヘイビアを追加して数回繰り返すように設定できます。

[Animation Point](https://reference.aspose.com/slides/net/aspose.slides.animation/point) は、ビヘイビアを適用すべき位置を示すポイントです。

## **アニメーション タイムライン**

[Sequence](https://reference.aspose.com/slides/net/aspose.slides.animation/sequence) は特定の図形に適用されるアニメーション効果のコレクションです。

[Timeline](https://reference.aspose.com/slides/net/aspose.slides.animation/animationtimeline) はスライド内で使用されるシーケンスのセットです。PowerPoint 2002 で導入されたアニメーション エンジンで、以前のバージョンではアニメーション効果の追加が困難で回避策が必要でした。タイムラインは旧 AnimationSettings クラスに取って代わり、PowerPoint アニメーションのオブジェクトモデルを明確にします。スライドにはタイムラインは 1 つだけ設定できます。

## **インタラクティブ アニメーション**

[Trigger](https://reference.aspose.com/slides/net/aspose.slides.animation/effecttriggertype) を使用すると、ユーザー アクション（例：ボタン クリック）で特定のアニメーションを開始できます。トリガーは最新バージョンの PowerPoint で導入されました。

## **図形 アニメーション**

Aspose.Slides を使用すると、テキスト、長方形、線、フレーム、OLE オブジェクトなど、さまざまな図形にアニメーションを適用できます。

{{% alert color="primary" %}} 
Read more [**図形アニメーションについて**](/slides/ja/net/shape-animation/).
{{% /alert %}}

## **アニメーション チャート**

アニメーション化されたチャートを作成するには、図形と同じクラスを使用します。ただし、PowerPoint のアニメーションはチャートのカテゴリまたはシリーズにのみ適用でき、カテゴリ要素やシリーズ要素にも効果を設定できます。

{{% alert color="primary" %}} 
Read more [**アニメーション化されたチャートについて**](/slides/ja/net/animated-charts/).
{{% /alert %}}

## **アニメーション テキスト**

アニメーション テキストに加え、段落単位でアニメーションを適用することも可能です。

{{% alert color="primary" %}} 
Read more [**アニメーションテキストについて**](/slides/ja/net/animated-text/).
{{% /alert %}}

## **FAQ**

**PDF にエクスポートしたときにアニメーションは保持されますか？**

いいえ。PDF は静的フォーマットのため、アニメーションや[スライド トランジション](/slides/ja/net/slide-transition/)は再生されません。モーションが必要な場合は、代わりに[HTML5](/slides/ja/net/export-to-html5/)、[animated GIF](/slides/ja/net/convert-powerpoint-to-animated-gif/)、または[video](/slides/ja/net/convert-powerpoint-to-video/)にエクスポートしてください。

**アニメーション化されたプレゼンテーションを動画に変換し、フレームレートやサイズを制御できますか？**

はい。プレゼンテーションをフレームとして[レンダリング](/slides/ja/net/convert-powerpoint-to-video/)し、ffmpeg などで動画にエンコードできます。この際、FPS と解像度を指定できます。レンダリング中にアニメーションとスライド トランジションは再生されます。

**ODP（PPTX だけでなく）でもアニメーションはそのまま残りますか？**

PPT、PPTX、ODP は[読み取り](/slides/ja/net/open-presentation/)および[書き込み](/slides/ja/net/save-presentation/)がサポートされていますが、フォーマットの差異により一部の効果が若干異なる場合があります。重要なケースは実際のサンプルで検証してください。