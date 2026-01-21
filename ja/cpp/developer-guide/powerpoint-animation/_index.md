---
title: C++でアニメーションを使用してPowerPointプレゼンテーションを強化する
linktitle: PowerPointアニメーション
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
- PowerPointアニメーション
- アニメーションタイムライン
- インタラクティブアニメーション
- カスタムアニメーション
- シェイプアニメーション
- アニメーションチャート
- アニメーションテキスト
- アニメーションシェイプ
- アニメーションOLEオブジェクト
- アニメーション画像
- アニメーションテーブル
- PowerPoint
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides for C++で高度なアニメーション効果を追加および制御し、動的なPowerPointおよびOpenDocumentプレゼンテーションを作成する方法を学びます。"
---

プレゼンテーションは何かを提示するために作成されるため、作成時には常にビジュアルな外観とインタラクティブな動作が考慮されます。

**PowerPoint animation** は、プレゼンテーションを目を引く魅力的なものにするために重要な役割を果たします。Aspose.Slides for C++ は、PowerPoint プレゼンテーションにアニメーションを追加するための幅広いオプションを提供します：

- さまざまな種類の PowerPoint アニメーション効果を図形、チャート、テーブル、OLE オブジェクト、その他のプレゼンテーション要素に適用します。
- 1 つの図形に複数の PowerPoint アニメーション効果を使用します。
- アニメーションタイムラインを使用してアニメーション効果を制御します。
- カスタム アニメーションを作成します。

Aspose.Slides for C++ では、さまざまなアニメーション効果を図形に適用できます。スライド上のテキスト、画像、OLE オブジェクト、テーブルなどすべての要素は図形として扱われるため、スライド上のあらゆる要素にアニメーション効果を適用できることを意味します。

[**Aspose.Slides.Animation**](https://reference.aspose.com/slides/cpp/namespace/aspose.slides.animation) **namespace** は、PowerPoint アニメーションを操作するためのクラスを提供します。
## **アニメーション効果**
Aspose.Slides は **150+ アニメーション効果** をサポートしており、Bounce や PathFootball、Zoom 効果といった基本的なアニメーション効果や OLEObjectShow、OLEObjectOpen といった特定のアニメーション効果が含まれます。すべてのアニメーション効果の一覧は [**EffectType**](https://reference.aspose.com/slides/cpp/namespace/aspose.slides.animation#ae0da11508d382465aa4e7a011df1bf31) 列挙型で確認できます。

さらに、これらのアニメーション効果は以下と組み合わせて使用できます：

- [ColorEffect](https://reference.aspose.com/slides/cpp/aspose.slides.animation/coloreffect/)
- [CommandEffect](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.command_effect)
- [FilterEffect](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.filter_effect)
- [MotionEffect](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.motion_effect)
- [PropertyEffect](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.property_effect)
- [RotationEffect](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.rotation_effect)
- [ScaleEffect](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.scale_effect)
- [SetEffect](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.set_effect)

## **カスタム アニメーション**
Aspose.Slides では独自の **カスタム アニメーション** を作成できます。いくつかのビヘイビアを組み合わせて新しいカスタム アニメーションを作成することで実現します。

[**Behavior**](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.behavior) は任意の PowerPoint アニメーション効果の構成要素です。すべてのアニメーション効果は実際にはビヘイビアの集合で構成されており、一度カスタム アニメーションとしてビヘイビアを組み合わせれば、他のプレゼンテーションでも再利用できます。標準の PowerPoint アニメーション効果に新しいビヘイビアを追加すれば、別のカスタム アニメーションとなります。たとえば、繰り返しビヘイビアを追加してアニメーションを数回繰り返すようにできます。

[**Animation Point**](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.point) はビヘイビアを適用すべき位置です。

## **アニメーション タイムライン**
[**Sequence**](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.sequence) は、特定の図形に適用されるアニメーション効果のコレクションです。

[**AnimationTimeLine**](https://reference.aspose.com/slides/cpp/class/aspose.slides.animation.animation_time_line) は、具体的なスライドで使用されるシーケンスの集合です。PowerPoint 2002 以降から提供されているアニメーションエンジンで、従来の PowerPoint バージョンではアニメーション効果の追加が困難で、さまざまな回避策が必要でした。タイムラインは旧来の AnimationSettings クラスに代わり、PowerPoint アニメーション用のより明確なオブジェクトモデルを提供します。1 つのスライドに設定できるアニメーション タイムラインは **1 つのみ** です。

## **インタラクティブ アニメーション**
[**EffectTriggerType**](https://reference.aspose.com/slides/cpp/namespace/aspose.slides.animation#add24fb49dd44eb3227aeeb3641fd2e81) を使用すると、ユーザー操作（例: ボタンのクリック）により特定のアニメーションを開始できます。トリガーは最新の PowerPoint バージョンでのみ追加されました。

## **シェイプ アニメーション**
Aspose.Slides は、テキスト、矩形、線、フレーム、OLE オブジェクトなど、実際にはさまざまな形状にアニメーションを適用できるようにします。

{{% alert color="primary" %}} 
続きを読む [**About Shape Animation**](/slides/ja/cpp/shape-animation/).
{{% /alert %}}

## **アニメーション チャート**
アニメーション チャートを作成するには、図形と同じクラスを使用します。ただし、PowerPoint アニメーションはチャートのカテゴリまたは系列にのみ適用できます。カテゴリ要素や系列要素にもアニメーション効果を適用できます。

{{% alert color="primary" %}} 
続きを読む [**About Animated Charts**](/slides/ja/cpp/animated-charts/).
{{% /alert %}}

## **アニメーション テキスト**
アニメーション テキストに加えて、段落にアニメーションを適用することも可能です。

{{% alert color="primary" %}} 
続きを読む [**About Animated Text**](/slides/ja/cpp/animated-text/).
{{% /alert %}}

## **よくある質問**

**PDF にエクスポートしたときにアニメーションは保持されますか？**

No. PDF は固定フォーマットであるため、アニメーションや [スライド トランジション](/slides/ja/cpp/slide-transition/) は再生されません。動きを必要とする場合は、代わりに [HTML5](/slides/ja/cpp/export-to-html5/)、[animated GIF](/slides/ja/cpp/convert-powerpoint-to-animated-gif/)、または [video](/slides/ja/cpp/convert-powerpoint-to-video/) にエクスポートしてください。

**アニメーション化されたプレゼンテーションをビデオに変換し、フレームレートやフレームサイズを制御できますか？**

Yes. プレゼンテーションをフレームとして [レンダリング](/slides/ja/cpp/convert-powerpoint-to-video/) し、ffmpeg などでビデオにエンコードする際に FPS と解像度を選択できます。レンダリング中にアニメーションとスライド トランジションが再生されます。

**ODP（PPTX だけでなく）で作業するときにアニメーションはそのまま保持されますか？**

PPT、PPTX、ODP は [読み取り](/slides/ja/cpp/open-presentation/) と [書き込み](/slides/ja/cpp/save-presentation/) がサポートされていますが、フォーマットの違いにより特定の効果が若干異なる見た目や挙動になることがあります。重要なケースは実際のサンプルで検証してください。