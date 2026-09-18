---
title: .NET で PowerPoint プレゼンテーションをアニメーションで強化
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
- アニメーション タイムライン
- インタラクティブ アニメーション
- カスタム アニメーション
- 図形アニメーション
- アニメーション付きチャート
- アニメーション付きテキスト
- アニメーション付きシェイプ
- アニメーション付き OLE オブジェクト
- アニメーション付き画像
- アニメーション付き表
- PowerPoint プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET が PowerPoint アニメーションを処理する機能を探ります。この一般的な概要では主な機能をハイライトし、プレゼンテーションを向上させるための洞察を提供します。"
---
## **はじめに**

プレゼンテーションは何かを示すことが目的であるため、作成時には常に視覚的外観とインタラクティブな動作が考慮されます。

**PowerPoint アニメーション** は、プレゼンテーションを視覚的に引き付け、視聴者を惹きつける上で重要な役割を果たします。Aspose.Slides for .NET は、PowerPoint プレゼンテーションにアニメーションを追加するための豊富なオプションを提供します。

- さまざまな種類の PowerPoint アニメーション効果を、図形、グラフ、表、OLE オブジェクト、その他のプレゼンテーション要素に適用できます。
- 1 つの図形に複数の PowerPoint アニメーション効果を使用できます。
- アニメーション タイムラインを利用して、アニメーション効果を制御できます。
- カスタム アニメーションを作成できます。

Aspose.Slides for .NET では、図形に対してさまざまなアニメーション効果を適用できます。テキスト、画像、OLE オブジェクト、表など、スライド上のすべての要素は図形として扱われるため、スライド上の任意の要素にアニメーション効果を適用できます。

[Aspose.Slides.Animation](https://reference.aspose.com/slides/ja/net/aspose.slides.animation/) 名前空間は、PowerPoint アニメーションを操作するクラスを提供します。

## **アニメーション効果**

Aspose.Slides は **150 以上のアニメーション効果** をサポートしており、Bounce、PathFootball、Zoom といった基本効果から、OLEObjectShow や OLEObjectOpen といった特定効果まで含まれます。すべてのアニメーション効果の完全な一覧は、[EffectType](https://reference.aspose.com/slides/ja/net/aspose.slides.animation/effecttype) 列挙型で確認できます。

さらに、これらのアニメーション効果は以下と組み合わせて使用できます。

- [ColorEffect](https://reference.aspose.com/slides/ja/net/aspose.slides.animation/coloreffect)
- [CommandEffect](https://reference.aspose.com/slides/ja/net/aspose.slides.animation/commandeffect)
- [FilterEffect](https://reference.aspose.com/slides/ja/net/aspose.slides.animation/filtereffect)
- [MotionEffect](https://reference.aspose.com/slides/ja/net/aspose.slides.animation/motioneffect)
- [PropertyEffect](https://reference.aspose.com/slides/ja/net/aspose.slides.animation/propertyeffect)
- [RotationEffect](https://reference.aspose.com/slides/ja/net/aspose.slides.animation/rotationeffect)
- [ScaleEffect](https://reference.aspose.com/slides/ja/net/aspose.slides.animation/scaleeffect)
- [SetEffect](https://reference.aspose.com/slides/ja/net/aspose.slides.animation/seteffect)

## **カスタム アニメーション**

完全な C# サンプルで、作成、検査、動作や編集可能なモーション パスの変更方法を確認するには、[Custom Animation](/slides/ja/net/custom-animation/) を参照してください。

Aspose.Slides では、**カスタム アニメーション** を自分で作成できます。これは、複数のビヘイビアを組み合わせて新しいカスタム アニメーションにすることで実現できます。

[Behavior](https://reference.aspose.com/slides/ja/net/aspose.slides.animation/behavior) は PowerPoint アニメーション効果の構成要素です。ビヘイビアを組み合わせて効果をカスタマイズしたり、既存の効果にビヘイビアを追加して拡張したりできます。繰り返しは別個のリピート ビヘイビアではなく、タイミング設定で構成します。

[Animation Point](https://reference.aspose.com/slides/ja/net/aspose.slides.animation/point) は、ビヘイビアを適用すべき位置を示すポイントです。

## **アニメーション タイムライン**

[Sequence](https://reference.aspose.com/slides/ja/net/aspose.slides.animation/sequence) は、異なる図形を対象にできるアニメーション効果のコレクションです。

[Timeline](https://reference.aspose.com/slides/ja/net/aspose.slides.animation/animationtimeline) は、特定のスライドで使用されるシーケンスの集合です。PowerPoint 2002 で導入されたアニメーション エンジンで、従来の AnimationSettings クラスに代わり、PowerPoint アニメーション用のより明快なオブジェクト モデルを提供します。1 つのスライドには 1 つのアニメーション タイムラインしか設定できません。

## **インタラクティブ アニメーション**

[Trigger](https://reference.aspose.com/slides/ja/net/aspose.slides.animation/effecttriggertype) を使用すると、ユーザー操作（例: ボタン クリック）を定義して特定のアニメーションを開始できます。トリガーは最新バージョンの PowerPoint で導入されました。

## **図形アニメーション**

Aspose.Slides は、テキスト、長方形、線、フレーム、OLE オブジェクトなどを含む図形にアニメーションを適用できるようにします。

{{% alert color="info" title="Note" %}}
詳しくは [**シェイプ アニメーションについて**](/slides/ja/net/shape-animation/) をご覧ください。
{{% /alert %}}

## **アニメーション付きグラフ**

アニメーション付きグラフを作成するには、図形と同じクラスを使用します。ただし、PowerPoint のアニメーションはグラフのカテゴリまたは系列にのみ適用でき、カテゴリ要素や系列要素に対しても効果を付与できます。

{{% alert color="info" title="Note" %}}
詳しくは [**アニメーション付きグラフについて**](/slides/ja/net/animated-charts/) をご覧ください。
{{% /alert %}}

## **アニメーション付きテキスト**

テキスト全体をアニメーションさせるだけでなく、段落単位でアニメーションを適用することもできます。

{{% alert color="info" title="Note" %}}
詳しくは [**アニメーション付きテキストについて**](/slides/ja/net/animated-text/) をご覧ください。
{{% /alert %}}

## **FAQ**

**アニメーションは PDF にエクスポートしても保持されますか？**

いいえ。PDF は静的な形式のため、アニメーションや[スライド トランジション](/slides/ja/net/slide-transition/)は再生されません。モーションが必要な場合は、[HTML5](/slides/ja/net/export-to-html5/)、[アニメーション GIF](/slides/ja/net/convert-powerpoint-to-animated-gif/)、または[ビデオ](/slides/ja/net/convert-powerpoint-to-video/)へエクスポートしてください。

**アニメーション付きプレゼンテーションをビデオに変換し、フレーム レートやサイズを制御できますか？**

はい。プレゼンテーションをフレームとして[レンダリング](/slides/ja/net/convert-powerpoint-to-video/)し、ffmpeg などでビデオにエンコードすれば、FPS と解像度を選択できます。レンダリング中にアニメーションとスライド トランジションは再生されます。

**ODP（PPTX だけでなく）でもアニメーションは保持されますか？**

PPT、PPTX、ODP は[読み取り](/slides/ja/net/open-presentation/)および[書き込み](/slides/ja/net/save-presentation/)をサポートしていますが、アニメーションが必ず保持されるわけではありません。カスタム アニメーション データは ODP への変換時に失われる可能性があります。テスト済みの例と形式の制限については、[Custom Animation](/slides/ja/net/custom-animation/) を参照してください。