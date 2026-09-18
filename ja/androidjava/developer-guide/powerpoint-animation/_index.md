---
title: AndroidでのアニメーションによるPowerPointプレゼンテーションの強化
linktitle: PowerPoint アニメーション
type: docs
weight: 150
url: /ja/androidjava/powerpoint-animation/
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
- シェイプ アニメーション
- アニメーション チャート
- アニメーション テキスト
- アニメーション シェイプ
- アニメーション OLE オブジェクト
- アニメーション 画像
- アニメーション テーブル
- PowerPoint
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Java を使用した Android 向け Aspose.Slides の機能を探り、PowerPoint アニメーションの取り扱いを概観します。主な機能をハイライトしています。"
---
## **導入**

プレゼンテーションは何かを伝えることが目的であるため、作成時には常に視覚的な外観とインタラクティブな動作が考慮されます。

**PowerPoint animation** は、プレゼンテーションを視覚的に魅力的かつ引き込むものにする上で重要な役割を果たします。Aspose.Slides は PowerPoint プレゼンテーションにアニメーションを追加するための幅広いオプションを提供します。

- 図形、チャート、テーブル、OLE オブジェクト、その他のプレゼンテーション要素にさまざまな種類の PowerPoint アニメーション効果を適用します。
- 1 つの図形に複数の PowerPoint アニメーション効果を使用します。
- アニメーションタイムラインを利用してアニメーション効果を制御します。
- カスタム アニメーションを作成します。

Aspose.Slides では、さまざまなアニメーション効果を図形に適用できます。スライド上のテキスト、画像、OLE オブジェクト、テーブルなど、すべての要素は図形として扱われるため、スライド上の任意の要素にアニメーション効果を適用できます。

## **アニメーション効果**
Aspose.Slides は **150+ アニメーション効果** をサポートしており、Bounce、PathFootball、Zoom といった基本効果や OLEObjectShow、OLEObjectOpen といった固有の効果が含まれます。完全な一覧は [EffectType](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/effecttype/) クラスで確認できます。

さらに、これらのアニメーション効果は以下の動作と組み合わせて使用できます。

- [ColorEffect](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ColorEffect)
- [CommandEffect](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/CommandEffect)
- [FilterEffect](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/FilterEffect)
- [MotionEffect](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/MotionEffect)
- [PropertyEffect](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/PropertyEffect)
- [RotationEffect](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/RotationEffect)
- [ScaleEffect](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ScaleEffect)
- [SetEffect](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/SetEffect)

## **カスタム アニメーション**

完全な Java サンプルで、動作や編集可能なモーション パスの作成・検査・変更方法を確認するには、[Custom Animation](/slides/ja/java/custom-animation/) を参照してください。

Aspose.Slides では独自の **カスタム アニメーション** を作成できます。これは、複数の動作を組み合わせて新しいカスタム アニメーションを作成することで実現できます。

[Behavior](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/behavior/) は PowerPoint アニメーション効果の構成要素です。動作を組み合わせて効果をカスタマイズしたり、既存の効果を拡張するために動作を追加したりできます。繰り返しは個別の repeat 動作ではなく、タイミング設定で構成されます。

[Animation Point](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/point/) は、動作を適用すべき位置を示すポイントです。

## **アニメーション タイムライン**
[Sequence](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/sequence/) は、異なる図形を対象にできるアニメーション効果のコレクションです。

[Timeline](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/animationtimeline/) は、特定のスライドで使用されるシーケンスのセットです。PowerPoint 2002 で導入されたアニメーション エンジンで、以前のバージョンではアニメーション効果の追加が困難で回避策が必要でした。タイムラインは PowerPoint アニメーションのオブジェクト モデルを明確にし、スライドには 1 つのアニメーション タイムラインしか持てません。

## **インタラクティブ アニメーション**
[Trigger](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/effecttriggertype/) を使用すると、ボタンのクリックなどユーザー アクションを定義して特定のアニメーションを開始できます。

## **シェイプ アニメーション**
Aspose.Slides はテキスト、長方形、線、フレーム、OLE オブジェクトなどを含む図形にアニメーションを適用できるようにします。

{{% alert color="info" title="Note" %}}
詳しくは[**シェイプ アニメーションについて**](/slides/ja/androidjava/shape-animation/)をご覧ください。
{{% /alert %}}

## **アニメーション チャート**
アニメーション化されたチャートを作成するには、図形と同じクラスを使用します。ただし、PowerPoint のアニメーションはチャートのカテゴリまたはシリーズにのみ適用でき、カテゴリ要素やシリーズ要素にもアニメーション効果を適用できます。

{{% alert color="info" title="Note" %}}
詳しくは[**アニメーション チャートについて**](/slides/ja/androidjava/animated-charts/)をご覧ください。
{{% /alert %}}

## **アニメーション テキスト**
テキストのアニメーションに加えて、段落にもアニメーションを適用できます。

{{% alert color="info" title="Note" %}}
詳しくは[**アニメーション テキストについて**](/slides/ja/androidjava/animated-text/)をご覧ください。
{{% /alert %}}

## **FAQ**

**PDF にエクスポートしたときにアニメーションは保持されますか？**

いいえ。PDF は静的フォーマットであるため、アニメーションや[スライド トランジション](/slides/ja/androidjava/slide-transition/)は再生されません。動きを必要とする場合は、代わりに[HTML5](/slides/ja/androidjava/export-to-html5/)、[Animated GIF](/slides/ja/androidjava/convert-powerpoint-to-animated-gif/)、または[ビデオ](/slides/ja/androidjava/convert-powerpoint-to-video/)へエクスポートしてください。

**アニメーション プレゼンテーションをビデオに変換し、フレームレートやフレームサイズを制御できますか？**

はい。プレゼンテーションをフレームとして[レンダリング](/slides/ja/androidjava/convert-powerpoint-to-video/)し、ffmpeg などを使用してビデオにエンコードする際に FPS と解像度を選択できます。レンダリング中にアニメーションとスライド トランジションが再生されます。

**ODP（PPTX だけでなく）でもアニメーションはそのまま残りますか？**

PPT、PPTX、ODP は[読み取り](/slides/ja/androidjava/open-presentation/)および[書き込み](/slides/ja/androidjava/save-presentation/)がサポートされていますが、アニメーションが保持されることは保証されません。ODP へ変換する際にカスタム アニメーション データが失われることがあります。形式互換性の確認方法については、[Custom Animation for Java](/slides/ja/java/custom-animation/) の例をご参照ください。