---
title: JavaScriptでプレゼンテーションのスライドサイズを変更する
linktitle: スライドサイズ
type: docs
weight: 70
url: /ja/nodejs-java/slide-size/
keywords:
- スライドサイズ
- アスペクト比
- 標準
- ワイドスクリーン
- 4:3
- 16:9
- スライドサイズの設定
- スライドサイズの変更
- カスタムスライドサイズ
- 特別なスライドサイズ
- 独自のスライドサイズ
- フルサイズスライド
- 画面タイプ
- スケールしない
- フィットを保証
- 最大化
- PowerPoint
- OpenDocument
- プレゼンテーション
- Node.js
- JavaScript
- Aspose.Slides
description: "Node.js と Aspose.Slides を使用して、PPT、PPTX、ODP ファイルのスライドを迅速にサイズ変更する方法を学び、品質を失うことなく任意の画面向けにプレゼンテーションを最適化します。"
---
## **はじめに**

Aspose.Slides は、印刷および画面表示の両方に重要な、PowerPoint プレゼンテーションのスライドサイズとアスペクト比を調整するための包括的なツールを提供します。

一般的なスライドサイズと比率:

- **Standard (4:3 アスペクト比)**: 古い画面やデバイスに最適です。
- **Widescreen (16:9 アスペクト比)**: 現代のプロジェクターやディスプレイに推奨されます。

プレゼンテーション全体で一貫性を保つために、すべてのスライドに単一のスライドサイズとアスペクト比が適用されます。最適な結果を得るには、プレゼンテーション作成の最初にスライドの寸法を設定し、問題を回避してください。

{{% alert color="primary" %}} 
既定では、Aspose.Slides で作成されたプレゼンテーションは標準の 4:3 アスペクト比を使用します。
{{% /alert %}}

## **プレゼンテーションでスライドサイズを変更する**

このサンプルコードは、Aspose.Slides を使用して JavaScript でプレゼンテーションのスライドサイズを変更する方法を示しています。

```javascript
var pres = new aspose.slides.Presentation("pres-4x3-aspect-ratio.pptx");
try {
    pres.getSlideSize().setSize(aspose.slides.SlideSizeType.OnScreen16x9, aspose.slides.SlideSizeScaleType.DoNotScale);
    pres.save("pres-4x3-aspect-ratio.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **プレゼンテーションでカスタムスライドサイズを指定する**

一般的なスライドサイズ (4:3 および 16:9) が作業に適さない場合、特定またはユニークなスライドサイズを使用することができます。たとえば、カスタムページレイアウトでプレゼンテーションからフルサイズスライドを印刷する場合や、特定の画面タイプでプレゼンテーションを表示する場合は、カスタムサイズ設定を使用すると便利です。

このサンプルコードは、Node.js 用 Aspose.Slides を Java 経由で使用し、JavaScript のプレゼンテーションにカスタムスライドサイズを指定する方法を示しています。

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(780, 540, aspose.slides.SlideSizeScaleType.DoNotScale);// A4 用紙サイズ
    pres.save("pres-a4-slide-size.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **プレゼンテーションでスライドサイズを変更する際の問題への対処**

プレゼンテーションのスライドサイズを変更すると、スライドの内容（画像やオブジェクトなど）が歪むことがあります。既定では、オブジェクトは新しいスライドサイズに合わせて自動的にサイズ変更されます。ただし、スライドサイズを変更する際に、Aspose.Slides がスライド上の内容をどのように扱うかを決定する設定を指定できます。

目的や達成したいことに応じて、以下の設定のいずれかを使用できます。

- `DoNotScale`

  スライド上のオブジェクトをサイズ変更したくない場合は、この設定を使用してください。

- `EnsureFit`

  小さいスライドサイズに縮小し、すべてのオブジェクトがスライドに収まるように Aspose.Slides に縮小させたい（コンテンツが失われるのを防ぐ）場合は、この設定を使用してください。

- `Maximize`

  大きいスライドサイズに拡大し、オブジェクトを新しいスライドサイズに比例させて拡大させたい場合は、この設定を使用してください。

このサンプルコードは、プレゼンテーションのスライドサイズを変更する際に `Maximize` 設定を使用する方法を示しています。

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(aspose.slides.SlideSizeType.Ledger, aspose.slides.SlideSizeScaleType.Maximize);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **よくある質問**

**インチ以外の単位（例えばポイントやミリメートル）でカスタムスライドサイズを設定できますか？**

はい。Aspose.Slides は内部でポイントを使用しており、1 ポイントは 1/72 インチに相当します。ミリメートルやセンチメートルなどの任意の単位をポイントに変換し、その変換値でスライドの幅と高さを定義できます。

**非常に大きなカスタムスライドサイズは、レンダリング時のパフォーマンスとメモリ使用量に影響しますか？**

はい。ポイント単位での大きなスライド寸法と高いレンダリングスケールを組み合わせると、メモリ消費が増加し、処理時間が長くなります。実用的なスライドサイズを目指し、必要に応じてレンダリングスケールを調整して目的の出力品質を得てください。

**標準外のスライドサイズを定義した後、異なるサイズのプレゼンテーションからスライドをマージできますか？**

異なるスライドサイズのままでは[プレゼンテーションをマージ](/slides/ja/nodejs-java/merge-presentation/)できません — まず、どちらかのプレゼンテーションのサイズをもう一方に合わせてリサイズします。スライドサイズを変更する際は、[SlideSizeScaleType](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/slidesizescaletype/) オプションを使用して既存のコンテンツの処理方法を選択できます。サイズを揃えた後、書式を保持したままスライドをマージできます。

**スライドの個別のシェイプや特定領域のサムネイルを生成できますか？また、それらは新しいスライドサイズを考慮しますか？**

はい。Aspose.Slides は、[スライド全体](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/slide/#getImage)および[選択したシェイプ](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/shape/#getImage)のサムネイルをレンダリングできます。生成された画像は現在のスライドサイズとアスペクト比を反映し、一貫したフレーミングとジオメトリを保証します。