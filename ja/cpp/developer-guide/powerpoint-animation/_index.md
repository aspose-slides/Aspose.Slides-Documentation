---
title: C++ でアニメーションを使用して PowerPoint プレゼンテーションを強化する
linktitle: PowerPoint アニメーション
type: docs
weight: 150
url: /ja/cpp/powerpoint-animation/
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
- シェイプ アニメーション
- アニメーション チャート
- アニメーション テキスト
- アニメーション シェイプ
- アニメーション OLE オブジェクト
- アニメーション イメージ
- アニメーション テーブル
- PowerPoint
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ で高度なアニメーション効果を追加および制御し、動的な PowerPoint および OpenDocument プレゼンテーションを作成する方法を学びます。"
---
## **導入**

プレゼンテーションは何かを提示するためのものなので、作成時には視覚的な外観とインタラクティブな動作が常に考慮されます。

**PowerPoint アニメーション** は、プレゼンテーションを視覚的に魅力的かつ引き込むものにする重要な役割を果たします。Aspose.Slides は PowerPoint プレゼンテーションにアニメーションを追加するための幅広いオプションを提供します。

- さまざまな種類の PowerPoint アニメーション効果をシェイプ、チャート、テーブル、OLE オブジェクト、その他のプレゼンテーション要素に適用します。
- 1 つのシェイプに複数の PowerPoint アニメーション効果を使用します。
- アニメーションタイムラインを利用してアニメーション効果を制御します。
- カスタム アニメーションを作成します。

Aspose.Slides では、シェイプにさまざまなアニメーション効果を適用できます。テキスト、画像、OLE オブジェクト、テーブルなど、スライド上のすべての要素はシェイプとして扱われるため、スライド上の任意の要素にアニメーション効果を適用できます。

[Aspose::Slides::Animation](https://reference.aspose.com/slides/ja/cpp/aspose.slides.animation/) 名前空間は、PowerPoint アニメーションを操作するためのクラスを提供します。

## **アニメーション効果**
Aspose.Slides は **150 以上のアニメーション効果** をサポートしており、Bounce、PathFootball、Zoom といった基本効果や OLEObjectShow、OLEObjectOpen といった特定の効果が含まれます。すべての効果は [EffectType](https://reference.aspose.com/slides/ja/cpp/aspose.slides.animation/effecttype/) 列挙体で確認できます。

さらに、これらのアニメーション効果は以下の動作と組み合わせて使用できます。

- [ColorEffect](https://reference.aspose.com/slides/ja/cpp/aspose.slides.animation/coloreffect/)
- [CommandEffect](https://reference.aspose.com/slides/ja/cpp/aspose.slides.animation/commandeffect/)
- [FilterEffect](https://reference.aspose.com/slides/ja/cpp/aspose.slides.animation/filtereffect/)
- [MotionEffect](https://reference.aspose.com/slides/ja/cpp/aspose.slides.animation/motioneffect/)
- [PropertyEffect](https://reference.aspose.com/slides/ja/cpp/aspose.slides.animation/propertyeffect/)
- [RotationEffect](https://reference.aspose.com/slides/ja/cpp/aspose.slides.animation/rotationeffect/)
- [ScaleEffect](https://reference.aspose.com/slides/ja/cpp/aspose.slides.animation/scaleeffect/)
- [SetEffect](https://reference.aspose.com/slides/ja/cpp/aspose.slides.animation/seteffect/)

## **カスタム アニメーション**

C++ の完全なサンプルで、動作や編集可能なモーション パスを作成、検査、変更する方法については、[Custom Animation](/slides/ja/cpp/custom-animation/) を参照してください。

Aspose.Slides では **カスタム アニメーション** を作成できます。これは、複数の動作を組み合わせて新しいカスタム アニメーションを作成することで実現できます。

[Behavior](https://reference.aspose.com/slides/ja/cpp/aspose.slides.animation/behavior/) は PowerPoint アニメーション効果の構成要素です。動作を組み合わせて効果をカスタマイズしたり、事前定義された効果に動作を追加したりできます。繰り返しは別個のリピート動作ではなく、タイミング設定で構成されます。

[Animation Point](https://reference.aspose.com/slides/ja/cpp/aspose.slides.animation/point/) は、動作を適用すべき点を示します。

## **アニメーション タイムライン**
[Sequence](https://reference.aspose.com/slides/ja/cpp/aspose.slides.animation/sequence/) は、異なるシェイプを対象にできるアニメーション効果のコレクションです。

[IAnimationTimeLine](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ianimationtimeline/) は、特定のスライドで使用されるシーケンスのセットです。これは PowerPoint 2002 で導入されたアニメーション エンジンです。以前のバージョンの PowerPoint では、プレゼンテーションにアニメーション効果を追加するのが難しく、さまざまな回避策が必要でした。タイムラインは PowerPoint アニメーションのオブジェクト モデルをより明確にします。スライドには 1 つのアニメーション タイムラインしか設定できません。

## **インタラクティブ アニメーション**
[Trigger](https://reference.aspose.com/slides/ja/cpp/aspose.slides.animation/effecttriggertype/) を使用すると、ボタンのクリックなどユーザー操作を定義して特定のアニメーションを開始できます。

## **シェイプ アニメーション**
Aspose.Slides を使用すると、テキスト、矩形、線、フレーム、OLE オブジェクトなどを含むシェイプにアニメーションを適用できます。

{{% alert color="info" title="Note" %}}
Read more [**シェイプ アニメーションについて**](/slides/ja/cpp/shape-animation/).
{{% /alert %}}

## **アニメーション チャート**
アニメーション チャートを作成するには、シェイプと同じクラスを使用します。ただし、PowerPoint のアニメーションはチャートのカテゴリまたはシリーズにのみ適用でき、カテゴリ要素やシリーズ要素にも適用できます。

{{% alert color="info" title="Note" %}}
Read more [**アニメーション チャートについて**](/slides/ja/cpp/animated-charts/).
{{% /alert %}}

## **アニメーション テキスト**
テキストをアニメーション化するだけでなく、段落に対してもアニメーションを適用できます。

{{% alert color="info" title="Note" %}}
Read more [**アニメーション テキストについて**](/slides/ja/cpp/animated-text/).
{{% /alert %}}

## **FAQ**

**PDF にエクスポートした場合、アニメーションは保持されますか？**

いいえ。PDF は静的な形式なので、アニメーションや[スライド遷移](/slides/ja/cpp/slide-transition/)は再生されません。動きを必要とする場合は、[HTML5](/slides/ja/cpp/export-to-html5/)、[アニメーション GIF](/slides/ja/cpp/convert-powerpoint-to-animated-gif/)、または[ビデオ](/slides/ja/cpp/convert-powerpoint-to-video/) にエクスポートしてください。

**アニメーション付きプレゼンテーションをビデオに変換し、フレームレートやフレームサイズを制御できますか？**

はい。[プレゼンテーションをフレームとしてレンダリング](/slides/ja/cpp/convert-powerpoint-to-video/)し、ffmpeg などでビデオにエンコードすれば、FPS と解像度を選択できます。レンダリング中にアニメーションとスライド遷移が再生されます。

**ODP（PPTX だけでなく）で作業する場合、アニメーションはそのまま残りますか？**

PPT、PPTX、ODP は[読み取り](/slides/ja/cpp/open-presentation/) と[書き込み](/slides/ja/cpp/save-presentation/) がサポートされていますが、アニメーションの保持が保証されるわけではありません。カスタム アニメーション データは ODP への変換時に失われる可能性があります。形式の互換性を確認する方法については、[Custom Animation](/slides/ja/cpp/custom-animation/) の例をご参照ください。